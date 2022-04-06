using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
namespace ZeldaFullEditor
{
	// TODO
	// Split off ZS and make this mainform agnostic
	// turn parent into just a ROM
	// 
	// 
	// 
	class Save
	{
		Room[] all_rooms;

		int[] roomTilesPointers = new int[Constants.NumberOfRooms];
		int[] roomDoorsPointers = new int[Constants.NumberOfRooms];
		int saddr = 0;

		byte[][] mapDatap1 = new byte[Constants.NumberOfOWMaps][];
		byte[][] mapDatap2 = new byte[Constants.NumberOfOWMaps][];
		int[] mapPointers1id = new int[Constants.NumberOfOWMaps];
		int[] mapPointers2id = new int[Constants.NumberOfOWMaps];

		int[] mapPointers1 = new int[Constants.NumberOfOWMaps];
		int[] mapPointers2 = new int[Constants.NumberOfOWMaps];

		private readonly ZScreamer ZS;
		private readonly ROMFile ROM;
		public Save(ZScreamer parent,  Room[] all_rooms)
		{
			this.all_rooms = all_rooms;
			ZS = parent;
			ROM = ZS.ROM;
		}

		public bool saveEntrances(Entrance[] entrances, Entrance[] startingentrances)
		{
			for (int i = 0; i < 0x84; i++)
			{
				entrances[i].save(i);
			}
			for (int i = 0; i < 0x07; i++)
			{
				startingentrances[i].save(i, true);
			}

			return false;
		}

		public bool saveRoomsHeaders()
		{
			// Long??
			int headerPointer = SNESFunctions.SNEStoPC(ROM[ZS.Offsets.room_header_pointer, 3]);
			if (headerPointer < 0x100000)
			{
				MovePointer mp = new MovePointer();
				mp.ShowDialog();
				headerPointer = mp.address;

				ROM[ZS.Offsets.room_header_pointer, 3] = mp.address.PCtoSNES();
				ROM[ZS.Offsets.room_header_pointers_bank] = ROM[ZS.Offsets.room_header_pointer + 2];
			}

			// ROM.StartBlockLogWriting("Room Headers", headerPointer);
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				ROM[headerPointer + (i * 2), 2] = (headerPointer + 640 + (i * 14)).PCtoSNES();
				saveHeader(headerPointer + 640, i);
			}

			// ROM.EndBlockLogWriting();

			// ROM.StartBlockLogWriting("Rooms Messages", ZS.Offsets.messages_id_dungeon);
			//ROM.SaveLogs();
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				ROM[ZS.Offsets.messages_id_dungeon + (i * 2), 2] = all_rooms[i].messageid;
			}

			// ROM.EndBlockLogWriting();
			return false; // False = no error
		}

		public bool saveBlocks()
		{
			// If we reach 0x80 size jump to pointer2 etc...
			int[] region = new int[4] { ZS.Offsets.blocks_pointer1, ZS.Offsets.blocks_pointer2, ZS.Offsets.blocks_pointer3, ZS.Offsets.blocks_pointer4 };
			int blockCount = 0;
			int r = 0;
			int pos = SNESFunctions.SNEStoPC(ROM[region[r], 3]);
			int count = 0;
			// ROM.StartBlockLogWriting("Blocks Data", pos);

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				foreach (Room_Object o in all_rooms[i].tilesObjects)
				{
					if ((o.options & ObjectOption.Block) == ObjectOption.Block) // If we find a block save it
					{
						int xy = ((o.y * 64) + o.x) << 1;

						
						ROM.WriteContinuous(ref pos, 
							(byte) i,
							(byte) (i >> 8),
							(byte) xy,
							(byte) (((xy >> 8) & 0x1F) | (o.layer << 5))
						);

						count += 4;
						if (count >= 0x80)
						{
							r++;
							pos = SNESFunctions.SNEStoPC(ROM[region[r], 3]);
							count = 0;
						}

						blockCount++;
					}
				}
			}

			if (blockCount > 99)
			{
				return true; // False = no error
			}

			// ROM.EndBlockLogWriting();

			/*
            if (b3 == 0xFF && b4 == 0xFF) { break; }
            int address = ((b4 & 0x1F) << 8 | b3) >> 1;
            int px = address % 64;
            int py = address >> 6;
            Room_Object r = addObject(0x0E00, (byte)(px), (byte)(py), 0, (byte)((b4 & 0x20) >> 5));
            */

			return false; // False = no error
		}

		public bool saveCustomCollision()
		{
			/* 
            Format:
                dw<offset> : db width, height
                dw < tile data >, ...
                if < offset > == $F0F0, start doing single tiles
                format:
                dw<offset> : db<tiledata>
                if < offset > == $FFFF, stop
            */

			int room_pointer = 0x128090; // @zarby: save all 320 rooms pointers to 0x128000
			int data_pointer = 0x128450; // @zarby: the actual data at 0x1283C0

			//for ( int i = 0; i < Constants.NumberOfRooms; i++ )
			foreach (Room room in all_rooms)
			{
				// @zarby: for each room -> ROM.WriteLong(0x100000), Utils.PcToSnes(ptrsCounter))
				//         write pointers where data start + previous room data length

				//Clear the room's rectangle list and then re-populate it
				room.ClearCollisionLayout();
				room.loadCollisionLayout(false);

				// If there is triangle in the room, write the room pointer, otherwise wrtie 000000
				if (room.collision_rectangles.Count() > 0)
				{
					ROM[room_pointer, 3] = data_pointer.PCtoSNES();
				}
				else
				{
					ROM[room_pointer, 3] = 0x000000;
				}

				room_pointer += 3;

				foreach (var rectangle in room.collision_rectangles)
				{

					ROM[data_pointer, 2] = rectangle.index_data;
					data_pointer += 2;
					ROM[data_pointer++] = rectangle.width;
					ROM[data_pointer++] = rectangle.height;
					for (int j = 0; j < rectangle.width * rectangle.height; j++)
					{
						ROM[data_pointer++, 2] = rectangle.tile_data[j];
					}

					//ROM.WriteLong(data_pointer, 0x000000);
					//data_pointer += 3;
				}

				// Add 0xFFFF to the end of this rooms list to tell the asm to stop here
				if (room.collision_rectangles.Count() > 0)
				{
					ROM[data_pointer, 3] = 0x00FFFF;
					data_pointer += 2;
				}
			}

			string projectFilename = ZS.MainForm.projectFilename;

			byte[] data = new byte[ROM.Length];
			ROM.DataStream.CopyTo(data, 0);

			// TODO handle differently in projects
			if (File.Exists("CustomCollision.asm"))
			{
				ROM.ApplyPatch("CustomCollision.asm");
			}

			foreach (AsarCLR.Asarerror error in AsarCLR.Asar.geterrors())
			{
				Console.WriteLine(error.Fullerrdata.ToString());
			}

			return false;
		}

		public bool saveTorches()
		{
			int bytes_count = ROM[ZS.Offsets.torches_length_pointer, 2];

			int pos = ZS.Offsets.torch_data;
			// ROM.StartBlockLogWriting("Torches Data", pos);
			// 288 torches?

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				bool room = false;
				foreach (Room_Object o in all_rooms[i].tilesObjects)
				{
					if ((o.options & ObjectOption.Torch) == ObjectOption.Torch) // If we find a torch
					{
						// If we find a torch then store room if it not stored

						if (!room)
						{
							ROM[pos, 2] = i;
							pos += 2;
							room = true;
						}

						int xy = ((o.y * 64) + o.x) << 1;
						ROM[pos++] = (byte) xy;
						byte b2 = (byte) (xy >> 8);

						if (o.layer == 1)
						{
							b2 |= 0x20;
						}

						b2 |= (byte) (o.lit ? 0x80 : 0x00);
						ROM[pos++] = b2;
					}
				}
				if (room)
				{
					ROM[pos, 2] = 0xFFFF;
					pos += 2;
				}
			}

			if ((pos - ZS.Offsets.torch_data) > 0x120)
			{
				return true;
			}
			else
			{
				ROM[ZS.Offsets.torches_length_pointer, 2] = pos - ZS.Offsets.torch_data;
			}

			// ROM.EndBlockLogWriting();
			return false; // False = no error
		}

		public void saveHeader(int pos, int i)
		{
			ROM.Write(pos + (i * 14), 
				(byte) ((((byte)all_rooms[i].bg2 & 0x07) << 5) + ((int)all_rooms[i].collision << 2) + (all_rooms[i].light ? 1 : 0)),
				all_rooms[i].palette,
				all_rooms[i].blockset,
				all_rooms[i].spriteset,
				(byte) all_rooms[i].effect,
				(byte) all_rooms[i].tag1,
				(byte) all_rooms[i].tag2,
				(byte) ((all_rooms[i].holewarp_plane) | (all_rooms[i].staircase1Plane << 2) | (all_rooms[i].staircase2Plane << 4) | (all_rooms[i].staircase3Plane << 6)),
				all_rooms[i].staircase4Plane,
				all_rooms[i].holewarp,
				all_rooms[i].staircase1,
				all_rooms[i].staircase2,
				all_rooms[i].staircase3,
				all_rooms[i].staircase4
			);
		}

		public bool saveAllPits()
		{
			int pitCount = ROM[ZS.Offsets.pit_count] / 2;
			int pitPointer = SNESFunctions.SNEStoPC(ROM[ZS.Offsets.pit_pointer, 3]);
			// ROM.StartBlockLogWriting("Pits Data", pitPointer);
			int pitCountNew = 0;

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				if (all_rooms[i].damagepit)
				{
					ROM[pitPointer, 2] = all_rooms[i].index;
					pitPointer += 2;
					pitCountNew++;
				}
			}
			// ROM.EndBlockLogWriting();

			return pitCountNew > pitCount;
		}

		// TODO magic numbers
		public bool saveAllObjects()
		{
			int section1Index = 0x50008; // 0x50000 to 0x5374F  // 53730
			int section2Index = 0xF878A; // 0xF878A to 0xFFFFF
			int section3Index = 0x1EB90; // 0x1EB90 to 0x1FFFF
			int section4Index = 0x1112C0; // If vanilla space is used use expanded region
			int section4Start = 0x1112C0;
			/*
            while (ROM.DATA[section4Index] != 0)
            {
                 //section4Index += 0x010000;
            }
            */

			// Check if room is already using that space first before skipping position!!
			section4Start = section4Index;
			// Reorder room from bigger to lower

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				var roomBytes = all_rooms[i].getTilesBytes();
				int doorPos = roomBytes.Length - 2;

				if (roomBytes.Length < 10)
				{
					saveObjectBytes(all_rooms[i].index, 0x50000, roomBytes, doorPos); // Empty room pointer
					continue;
				}

				while (true)
				{
					if (doorPos >= 04)
					{
						if (roomBytes[doorPos] == 0xF0 && roomBytes[doorPos + 1] == 0xFF)
						{
							doorPos += 2;
							break;
						}

						doorPos -= 2;
					}
					else
					{
						break;
					}
				}

				if (section1Index + roomBytes.Length <= 0x53730) // 0x50000 to 0x5374F
				{
					// Write the room
					saveObjectBytes(all_rooms[i].index, section1Index, roomBytes, doorPos);
					section1Index += roomBytes.Length;
					continue;
				}
				else if (section2Index + roomBytes.Length <= 0xFFFFF) // 0xF878A to 0xFFFF7
				{
					// Write the room
					saveObjectBytes(all_rooms[i].index, section2Index, roomBytes, doorPos);
					section2Index += roomBytes.Length;
					continue;
				}
				else if (section3Index + roomBytes.Length <= 0x1FFFF) // 0x1EB90 to 0x1FFFF
				{
					// Write the room
					saveObjectBytes(all_rooms[i].index, section3Index, roomBytes, doorPos);
					section3Index += roomBytes.Length;
					continue;
				}
				else
				{
					// Ran out of space
					// Write the room
					//saveObjectBytes(i, section4Index, roomBytes);
					//section4Index += roomBytes.Length;
					saveObjectBytes(all_rooms[i].index, section4Index, roomBytes, doorPos);
					section4Index += roomBytes.Length;
					//usedSection4 = true;
					continue;
					// Move to EXPANDED region
					//Console.WriteLine("Room " + i + " no more space jump to 0x121210");
					//currentPos = 0x121210;
					//MessageBox.Show("We are running out space in the original portion of the ROM next data will be writed to : 0x121210");
				}
			}

			int objectPointer = SNESFunctions.SNEStoPC(ROM[ZS.Offsets.room_object_pointer, 3]);
			// ROM.StartBlockLogWriting("Room And Doors Pointers", objectPointer);
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				ROM[objectPointer + (i * 3), 3] = roomTilesPointers[i];
				ROM[ZS.Offsets.doorPointers + (i * 3), 3] = roomDoorsPointers[i];
			}

			// ROM.EndBlockLogWriting();

			return false; // False = no error
		}

		void saveObjectBytes(int roomId, int position, byte[] bytes, int doorOffset)
		{
			//int objectPointer = ROM[ZS.Offsets.room_object_pointer, 3].SNEStoPC();
			roomTilesPointers[roomId] = saddr = position.PCtoSNES();
			roomDoorsPointers[roomId] = (position + doorOffset).PCtoSNES();
			// Update the index

			// ROM.StartBlockLogWriting("Room " + roomId.ToString("D3") + " Tiles Data", position);
			//Array.Copy(bytes, 0, ROM.DATA, position, bytes.Length);
			// ROM.EndBlockLogWriting();
		}

		public void savePalettes() // room settings floor1, floor2, blockset, spriteset, palette
		{
			// TODO: Add something here?
		}

		public bool saveallChests()
		{
			int cpos = SNESFunctions.SNEStoPC(ROM[ZS.Offsets.chests_data_pointer1, 3]);
			int chestCount = 0;
			// ROM.StartBlockLogWriting("Chests Data", cpos);

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				// Number of possible chests
				foreach (Chest c in all_rooms[i].chest_list)
				{
					ushort room_index = (ushort) i;
					if (c.bigChest)
					{
						room_index |= 0x8000;
					}


					ROM.WriteContinuous(ref cpos,
						(byte) room_index,
						(byte) (room_index >> 8),
						c.item
					);
					chestCount++;
				}
			}

			//Console.WriteLine("Nbr of chests : " + chestCount);
			if (chestCount > 168)
			{
				return true; // False = no error
			}

			// ROM.EndBlockLogWriting();
			return false; // False = no error
		}

		public bool saveallPots()
		{
			int pos = ZS.Offsets.items_data_start + 2; // Skip 2 FF FF that are empty pointer
			// ROM.StartBlockLogWriting("Pots Items Data", pos);

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				if (all_rooms[i].pot_items.Count == 0)
				{
					ROM[ZS.Offsets.room_items_pointers + (i * 2), 2] = ZS.Offsets.items_data_start.PCtoSNES();
					continue;
				}

				// Pointer
				ROM[ZS.Offsets.room_items_pointers + (i * 2), 2] = pos.PCtoSNES();
				for (int j = 0; j < all_rooms[i].pot_items.Count; j++)
				{
					all_rooms[i].pot_items[j].bg2 = all_rooms[i].pot_items[j].layer != 0;

					int xy = ((all_rooms[i].pot_items[j].y * 64) + all_rooms[i].pot_items[j].x) << 1;

					ROM.WriteContinuous(ref pos, 
					   (byte) xy,
					   (byte) ((xy >> 8) | (all_rooms[i].pot_items[j].bg2 ? 0x20 : 0x00)),
					   all_rooms[i].pot_items[j].id
					);
				}

				ROM[pos, 2] = 0xFFFF;
				pos += 2;
				if (pos > ZS.Offsets.items_data_end)
				{
					//ROM.SaveLogs();
					return true;
				}
			}

			// ROM.EndBlockLogWriting();
			return false; // False = no error
		}

		/// <summary>
		/// Tells the text editor to save all the texts.
		/// </summary>
		/// <param name="te"></param>
		/// <returns></returns>
		/// Jared_Brian_: The check box save for the text editor was removed per redundancy.
		public bool saveAllText(TextEditor te)
		{
			return te.Save();
		}

		public bool saveallSprites()
		{
			int spritePointer = Constants.DungeonSpritePointers | ROM[ZS.Offsets.rooms_sprite_pointer];
			int spritePointerPC = spritePointer.SNEStoPC();
			// ROM.StartBlockLogWriting("Dungeon Sprites", spritePointerPC);
			byte[] sprites_buffer = new byte[ZS.Offsets.sprites_end_data - spritePointer.SNEStoPC()];

			// Empty room data = 0x280
			// Start of data = 0x282
			try
			{
				int pos = 0x282;
				// Set empty room
				sprites_buffer[0x280] = 0x00;
				sprites_buffer[0x281] = Constants.SpriteTerminator;

				for (int i = 0; i < 320; i++)
				{
					if (i >= Constants.NumberOfRooms || all_rooms[i].sprites.Count <= 0)
					{
						sprites_buffer[(i * 2)] = (byte) (spritePointer + 0x280).SNEStoPC().PCtoSNES();
						sprites_buffer[(i * 2) + 1] = (byte) ((spritePointer + 0x280).SNEStoPC() >> 8);
					}
					else
					{
						// Pointer: 
						// what the fuck?
						sprites_buffer[(i * 2)] = (byte) (spritePointer + pos).SNEStoPC().PCtoSNES();
						sprites_buffer[(i * 2) + 1] = (byte) ((spritePointer + pos).SNEStoPC().PCtoSNES() >> 8);

						sprites_buffer[pos++] = (byte) (all_rooms[i].sortsprites ? 0x01 : 0x00); // Unknown byte??

						foreach (Sprite spr in all_rooms[i].sprites) // 3bytes
						{
							sprites_buffer[pos++] = (byte) ((spr.layer << 7) + ((spr.subtype & 0x18) << 2) + spr.y);
							sprites_buffer[pos++] = (byte) (((spr.subtype & 0x07) << 5) + spr.x);
							sprites_buffer[pos++] = spr.id;

							// If current sprite hold a key then save it before 
							if (spr.keyDrop == 1)
							{
								sprites_buffer[pos++] = 0xFE;
								sprites_buffer[pos++] = 0x00;
								sprites_buffer[pos++] = 0xE4;
							}
							else if (spr.keyDrop == 2)
							{
								sprites_buffer[pos++] = 0xFD;
								sprites_buffer[pos++] = 0x00;
								sprites_buffer[pos++] = 0xE4;
							}
						}

						sprites_buffer[pos++] = Constants.SpriteTerminator;
					}
				}

				// ROM.EndBlockLogWriting();
				//sprites_buffer.CopyTo(ROM.DATA, spritePointerPC);
			}
			catch (Exception)
			{
				return true;
			}

			return false; // False = no error
		}

		public bool saveOWExits()
		{
			// ROM.StartBlockLogWriting("OW Exits", Constants.OWExitMapId);

			for (int i = 0, j = 0; i < 78; i++, j += 2)
			{
				ROM[ZS.Offsets.OWExitMapId + i] = ZS.OverworldManager.allexits[i].mapId;
				ROM[ZS.Offsets.OWExitXScroll + j, 2] = ZS.OverworldManager.allexits[i].xScroll;
				ROM[ZS.Offsets.OWExitYScroll + j, 2] = ZS.OverworldManager.allexits[i].yScroll;
				ROM[ZS.Offsets.OWExitXCamera + j, 2] = ZS.OverworldManager.allexits[i].cameraX;
				ROM[ZS.Offsets.OWExitYCamera + j, 2] = ZS.OverworldManager.allexits[i].cameraY;
				ROM[ZS.Offsets.OWExitVram + j, 2] = ZS.OverworldManager.allexits[i].vramLocation;
				ROM[ZS.Offsets.OWExitRoomId + j, 2] = ZS.OverworldManager.allexits[i].roomId;
				ROM[ZS.Offsets.OWExitXPlayer + j, 2] = ZS.OverworldManager.allexits[i].playerX;
				ROM[ZS.Offsets.OWExitYPlayer + j, 2] = ZS.OverworldManager.allexits[i].playerY;
				ROM[ZS.Offsets.OWExitDoorType1 + j, 2] = ZS.OverworldManager.allexits[i].doorType1;
				ROM[ZS.Offsets.OWExitDoorType2 + j, 2] = ZS.OverworldManager.allexits[i].doorType2;
			}

			// ROM.EndBlockLogWriting();
			return false;
		}

		public bool saveOWEntrances()
		{
			// ROM.StartBlockLogWriting("OW Entrances/Holes", Constants.OWEntranceMap);

			for (int i = 0, j = 0; i < ZS.OverworldManager.allentrances.Length; i++, j += 2)
			{
				ROM[ZS.Offsets.OWEntranceMap + j, 2] = ZS.OverworldManager.allentrances[i].mapId;
				ROM[ZS.Offsets.OWEntrancePos + j, 2] = ZS.OverworldManager.allentrances[i].mapPos;
				ROM[ZS.Offsets.OWEntranceEntranceId + i] = ZS.OverworldManager.allentrances[i].entranceId;
			}

			for (int i = 0, j = 0; i < ZS.OverworldManager.allholes.Length; i++, j += 2)
			{
				ROM[ZS.Offsets.OWHoleArea + j, 2] = ZS.OverworldManager.allholes[i].mapId;
				ROM[ZS.Offsets.OWHolePos + j, 2] = ZS.OverworldManager.allholes[i].mapPos - 0x400;
				ROM[ZS.Offsets.OWHoleEntrance + i] = ZS.OverworldManager.allholes[i].entranceId;
			}

			// ROM.EndBlockLogWriting();
			//WriteLog("Overworld Entrances data loaded properly", Color.Green);
			return false;
		}

		public bool saveOWItems()
		{
			// ROM.StartBlockLogWriting("Items OW DATA & Pointers", ZS.Offsets.overworldItemsPointers);
			List<RoomPotSaveEditor>[] roomItems = new List<RoomPotSaveEditor>[128];

			for (int i = 0; i < 128; i++)
			{
				roomItems[i] = new List<RoomPotSaveEditor>();
				foreach (RoomPotSaveEditor item in ZS.OverworldManager.allitems)
				{
					if (item.roomMapId == i)
					{
						roomItems[i].Add(item);
					}
				}
			}

			int dataPos = ZS.Offsets.overworldItemsPointers + 0x100;

			int[] itemPtrs = new int[128];
			int[] itemPtrsReuse = new int[128];
			int emptyPtr = 0;

			for (int i = 0; i < 128; i++)
			{
				itemPtrsReuse[i] = -1;
				for (int ci = 0; ci < i; ci++)
				{
					if (roomItems[i].Count == 0)
					{
						itemPtrsReuse[i] = -2;
						break;
					}
					if (compareItemsArrays(roomItems[i], roomItems[ci]))
					{
						itemPtrsReuse[i] = ci;
						break;
					}
				}
			}

			for (int i = 0; i < 128; i++)
			{
				if (itemPtrsReuse[i] == -1)
				{
					itemPtrs[i] = dataPos;
					foreach (RoomPotSaveEditor item in roomItems[i])
					{
						ushort mapPos = (ushort) (((item.gameY << 6) + item.gameX) << 1);
						ROM.WriteContinuous(ref dataPos,
							(byte) (mapPos >> 8),
							(byte) mapPos,
							item.id);
					}

					emptyPtr = dataPos;
					ROM[dataPos, 2] = 0xFFFF;
					dataPos += 2;
				}
				else if (itemPtrsReuse[i] == -2)
				{
					itemPtrs[i] = emptyPtr;
				}
				else
				{
					itemPtrs[i] = itemPtrs[itemPtrsReuse[i]];
				}

				ROM[ZS.Offsets.overworldItemsPointers + (i * 2), 2] = itemPtrs[i].PCtoSNES();
			}

			if (dataPos > ZS.Offsets.overworldItemsEndData)
			{
				return true;
			}

			// ROM.EndBlockLogWriting();

			return false;
		}

		public bool SaveOWSprites()
		{
			// ROM.StartBlockLogWriting("Sprites OW DATA & Pointers", ZS.Offsets.overworldSpritesBegining);
			int[] sprPointers = new int[Constants.NumberOfOWSprites];
			int?[] sprPointersReused = new int?[Constants.NumberOfOWSprites];
			List<Sprite>[] allspr = new List<Sprite>[Constants.NumberOfOWSprites];

			for (int j = 0; j < Constants.NumberOfOWSprites; j++)
			{
				sprPointersReused[j] = null;
				allspr[j] = new List<Sprite>();
			}

			for (int i = 0; i < Constants.NumberOfOWSprites; i++) // For each pointers
			{
				if (i < 64) // LW[0]
				{
					Sprite[] sprArray = ZS.OverworldManager.allsprites[0].Where(s => s.mapid == i).ToArray();
					foreach (Sprite spr in sprArray)
					{
						allspr[i].Add(spr);
					}
				}
				else if (i < 208) // LW & DW[1]
				{
					Sprite[] sprArray = ZS.OverworldManager.allsprites[1].Where(s => s.mapid == (i - 64)).ToArray();
					foreach (Sprite spr in sprArray)
					{
						allspr[i].Add(spr);
					}
				}
				else if (i < Constants.NumberOfOWSprites) // LW[2]
				{
					Sprite[] sprArray = ZS.OverworldManager.allsprites[2].Where(s => s.mapid == (i - 208)).ToArray();
					foreach (Sprite spr in sprArray)
					{
						allspr[i].Add(spr);
					}
				}
			}

			for (int i = 0; i < Constants.NumberOfOWSprites; i++)
			{
				sprPointersReused[i] = null;
				for (int ci = 0; ci < Constants.NumberOfOWSprites; ci++)
				{
					if (ci >= i)
					{
						break;
					}

					// the i != ci condition was useless, because it would have hit the break if we were equal
					if (compareSpriteArrays(allspr[i], allspr[ci]))
					{
						sprPointersReused[i] = ci;
					}
				}
			}

			int dataPos = 0x4CB41;
			// END OF OW SPRITES DATA = 0x4D62E
			//ROM.Write(0x4CB41,0xFF); // empty sprite data
			// 0x4CB42 // start of rooms data saves

			// write sprite data if sprPointersReused[i] == -1

			for (int i = 0; i < Constants.NumberOfOWSprites; i++)
			{
				if (sprPointersReused[i] == null)
				{
					sprPointers[i] = dataPos;
					foreach (Sprite spr in allspr[i])
					{
						ROM.WriteContinuous(ref dataPos, spr.y, spr.x, spr.id);
					}

					ROM[dataPos++] = Constants.SpriteTerminator;
				}
				else
				{
					sprPointers[i] = sprPointers[(int) sprPointersReused[i]];
				}

				ROM[ZS.Offsets.OverworldSpritesTableState0 + (i * 2), 2] = sprPointers[i].PCtoSNES();
			}

			if (dataPos > 0x4D62E)
			{
				return true; // Error
			}

			// ROM.EndBlockLogWriting();
			return false; // No errors
		}

		public bool compareSpriteArrays(List<Sprite> spr1, List<Sprite> spr2)
		{
			if (spr1.Count != spr2.Count)
			{
				return false;
			}

			bool match;
			foreach (Sprite i in spr1)
			{
				match = false;
				foreach (Sprite j in spr2)
				{
					if (i.x == j.x && i.y == j.y && i.id == j.id)
					{
						match = true;
						break;
					}
				}

				if (!match)
				{
					return false;
				}
			}

			return true;
		}

		public bool compareItemsArrays(List<RoomPotSaveEditor> itm1, List<RoomPotSaveEditor> itm2)
		{
			if (itm1.Count != itm2.Count)
			{
				return false;
			}

			bool match;
			foreach (RoomPotSaveEditor i in itm1)
			{
				match = false;
				foreach (RoomPotSaveEditor j in itm2)
				{
					if (i.x == j.x && i.y == j.y && i.id == j.id)
					{
						match = true;
						break;
					}
				}

				if (!match)
				{
					return false;
				}
			}

			return true;
		}

		public bool saveOWTransports()
		{
			// ROM.StartBlockLogWriting("Transports Data", Constants.OWExitMapIdWhirlpool);

			for (int i = 0, j = 0; i < 0x11; i++, j += 2)
			{
				ROM[ZS.Offsets.OWExitMapIdWhirlpool + j, 2] = ZS.OverworldManager.allWhirlpools[i].mapId;
				ROM[ZS.Offsets.OWExitXScrollWhirlpool + j, 2] = ZS.OverworldManager.allWhirlpools[i].xScroll;
				ROM[ZS.Offsets.OWExitYScrollWhirlpool + j, 2] = ZS.OverworldManager.allWhirlpools[i].yScroll;
				ROM[ZS.Offsets.OWExitXCameraWhirlpool + j, 2] = ZS.OverworldManager.allWhirlpools[i].cameraX;
				ROM[ZS.Offsets.OWExitYCameraWhirlpool + j, 2] = ZS.OverworldManager.allWhirlpools[i].cameraY;
				ROM[ZS.Offsets.OWExitVramWhirlpool + j, 2] = ZS.OverworldManager.allWhirlpools[i].vramLocation;
				ROM[ZS.Offsets.OWExitXPlayerWhirlpool + j, 2] = ZS.OverworldManager.allWhirlpools[i].playerX;
				ROM[ZS.Offsets.OWExitYPlayerWhirlpool + j, 2] = ZS.OverworldManager.allWhirlpools[i].playerY;

				if (i > 8)
				{
					ROM[ZS.Offsets.OWWhirlpoolPosition + ((i - 9) * 2), 2] = ZS.OverworldManager.allWhirlpools[i].whirlpoolPos;
				}
			}

			// ROM.EndBlockLogWriting();
			return false;
		}

		public bool saveMapProperties()
		{
			// ROM.StartBlockLogWriting("Map Properties", ZS.Offsets.mapGfx);

			for (int i = 0; i < 64; i++)
			{
				ROM[ZS.Offsets.mapGfx + i] = ZS.OverworldManager.allmaps[i].gfx;
				ROM[ZS.Offsets.overworldSpriteset + i] = ZS.OverworldManager.allmaps[i].sprgfx[0];
				ROM[ZS.Offsets.overworldSpriteset + 64 + i] = ZS.OverworldManager.allmaps[i].sprgfx[1];
				ROM[ZS.Offsets.overworldSpriteset + 128 + i] = ZS.OverworldManager.allmaps[i].sprgfx[2];
				ROM[ZS.Offsets.overworldMapPalette + i] = ZS.OverworldManager.allmaps[i].palette;
				ROM[ZS.Offsets.overworldSpritePalette + i] = ZS.OverworldManager.allmaps[i].sprpalette[0];
				ROM[ZS.Offsets.overworldSpritePalette + 64 + i] = ZS.OverworldManager.allmaps[i].sprpalette[1];
				ROM[ZS.Offsets.overworldSpritePalette + 128 + i] = ZS.OverworldManager.allmaps[i].sprpalette[2];
			}

			for (int i = 64; i < 128; i++)
			{
				ROM[ZS.Offsets.mapGfx + i] = ZS.OverworldManager.allmaps[i].gfx;
				ROM[ZS.Offsets.overworldSpriteset + 128 + i] = ZS.OverworldManager.allmaps[i].sprgfx[0];
				ROM[ZS.Offsets.overworldSpriteset + 128 + i] = ZS.OverworldManager.allmaps[i].sprgfx[1];
				ROM[ZS.Offsets.overworldSpriteset + 128 + i] = ZS.OverworldManager.allmaps[i].sprgfx[2];
				ROM[ZS.Offsets.overworldMapPalette + i] = ZS.OverworldManager.allmaps[i].palette;
				ROM[ZS.Offsets.overworldSpritePalette + 128 + i] = ZS.OverworldManager.allmaps[i].sprpalette[0];
				ROM[ZS.Offsets.overworldSpritePalette + 128 + i] = ZS.OverworldManager.allmaps[i].sprpalette[1];
				ROM[ZS.Offsets.overworldSpritePalette + 128 + i] = ZS.OverworldManager.allmaps[i].sprpalette[2];
			}

			// ROM.EndBlockLogWriting();
			return false;
		}

		public bool saveMapOverlays()
		{
			// ROM.StartBlockLogWriting("Map Overlays", ZS.Offsets.mapGfx);

			byte[] newOverlayCode = new byte[]
			{
				0xC2, 0x30, // REP #$30
                0xA5, 0x8A, // LDA $8A
                0x0A, 0x18, // ASL : CLC
                0x65, 0x8A, // ADC $8A
                0xAA, // TAX
                0xBF, 0x00, 0x00, 0x00, // LDA, X 
                0x85, 0x00, // STA $00
                0xBF, 0x00, 0x00, 0x00, // LDA, X +2
                0x85, 0x02, // STA $02
                0x4B, // PHK
                0xF4, 0x00, 0x00, // This position +3 ?
                0xDC, 0x00, 0x00, // JML [$00 00]
                0xE2, 0x30, // SEP #$30
                0xAB, // PLB
                0x6B // RTL
            };

			// Pointers

			ROM.Write(0x77657, newOverlayCode);

			int ptrStart = (0x77657 + 32);
			int snesptrstart = ptrStart.PCtoSNES();
			// 10, 16, 
			ROM[0x77657 + 10, 3] = snesptrstart;
			ROM[0x77657 + 16, 3] = snesptrstart + 2;

			int peaAddr = (0x77657 + 27).PCtoSNES();

			ROM[0x77657 + 23, 2] = peaAddr;

			// TODO : Optimize that routine to be smaller

			// 0x058000
			int pos = 0x120000;
			int ptrPos = 0x77657 + 32;
			for (int i = 0; i < 128; i++)
			{
				int snesaddr = pos.PCtoSNES();
				ROM[ptrPos,3] = snesaddr;
				ptrPos += 3;

				for (int t = 0; t < ZS.OverworldManager.alloverlays[i].tilesData.Count; t++)
				{
					ushort addr = (ushort) ((ZS.OverworldManager.alloverlays[i].tilesData[t].x * 2) + (ZS.OverworldManager.alloverlays[i].tilesData[t].y * 128) + 0x2000);
					// LDA TileID : STA $addr
					// A9 (LDA #$)
					// A2 (LDX #$)
					// 8D (STA $xxxx)

					// LDA :
					ROM[pos++, 2] = 0xA9;
					ROM[pos, 2] = ZS.OverworldManager.alloverlays[i].tilesData[t].tileId;
					pos += 2;

					// STA : 
					ROM[pos++] = 0x8D;
					ROM[pos, 2] = addr;
					pos += 2;
				}

				ROM[pos++] = 0x6B;
			}

			// ROM.EndBlockLogWriting();
			return false;
		}

		public bool saveOverworldTilesType()
		{
			// ROM.StartBlockLogWriting("Overworld Tiles Types", ZS.Offsets.overworldTilesType);
			for (int i = 0; i < 0x200; i++)
			{
				ROM[ZS.Offsets.overworldTilesType + i] = ZS.OverworldManager.allTilesTypes[i];
			}

			// ROM.EndBlockLogWriting();
			return false;
		}

		// ROM MAP
		// 0x110000 (S:228000) are rooms header Length 0x12C0 (Always the same size)
		// 120000 to 1343C0 (S:248000 to 26C3C0) are new overworld maps location always same size (fake compressed)
		// 0x058000 (OLD MAP DATA) Now Used for Overlays data

		// 0x6452A  // HOOK Replaced Code : INC $15 : LDA.b #$03
		// 1351C0 / 26D1C0 end of tilemap data where the jump code should be for DMA

		/*
        public bool saveTitleScreen()
        {
            int pos = 0x1343C0;
            // 134AC0 = BG2
            for (int i = 0; i < 0x380; i++)
            {
                ROM.WriteShort(pos, mainForm.screenEditor.tilesBG1Buffer[i], true, "Screen");
                ROM.WriteShort(pos+0x700, mainForm.screenEditor.tilesBG2Buffer[i], true, "Screen");
                pos += 2;
            }
            
            return false;
        }
        */

		public bool saveOverworldMessagesIds()
		{
			// ROM.StartBlockLogWriting("Overworld Messages IDs", ZS.Offsets.overworldMessages);

			for (int i = 0; i < 128; i++)
			{
				ROM[ZS.Offsets.overworldMessages + (i * 2), 2] = ZS.OverworldManager.allmaps[i].messageID;
			}

			// ROM.EndBlockLogWriting();

			return false;
		}

		public bool saveOverworldMusics()
		{
			// ROM.StartBlockLogWriting("Overworld Musics IDs", ZS.Offsets.overworldMessages);

			for (int i = 0; i < 64; i++)
			{
				ROM[ZS.Offsets.overworldMusicBegining + i] = ZS.OverworldManager.allmaps[i].musics[0];
				ROM[ZS.Offsets.overworldMusicZelda + i] = ZS.OverworldManager.allmaps[i].musics[1];
				ROM[ZS.Offsets.overworldMusicMasterSword + i] = ZS.OverworldManager.allmaps[i].musics[2];
				ROM[ZS.Offsets.overworldMusicAgahim + i] = ZS.OverworldManager.allmaps[i].musics[3];

			}

			for (int i = 0; i < 64; i++)
			{
				ROM[ZS.Offsets.overworldMusicDW + i] = ZS.OverworldManager.allmaps[i].musics[0];
			}

			// ROM.EndBlockLogWriting();

			return false;
		}

		public bool compareArray(byte[] array1, byte[] array2)
		{
			if (array1.Length != array2.Length)
			{
				return false;
			}

			for (int i = 0; i < array1.Length; i++)
			{
				if (array1[i] != array2[i])
				{
					return false;
				}
			}

			return true;
		}

		public bool saveOverworldMaps()
		{
			for (int i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				mapPointers1id[i] = -1;
				mapPointers2id[i] = -1;
			}

			int pos = 0x058000;
			for (int i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				int npos = 0;
				byte[] singlemap1 = new byte[512];
				byte[] singlemap2 = new byte[512];

				for (int y = 0; y < 16; y++)
				{
					for (int x = 0; x < 16; x++)
					{
						singlemap1[npos] = (byte) ZS.OverworldManager.t32[npos + (i * 256)];
						singlemap2[npos] = (byte) (ZS.OverworldManager.t32[npos + (i * 256)] >> 8);
						npos++;
					}
				}

				byte[] a = ZCompressLibrary.Compress.ALTTPCompressOverworld(singlemap1, 0, 256);
				byte[] b = ZCompressLibrary.Compress.ALTTPCompressOverworld(singlemap2, 0, 256);

				mapDatap1[i] = new byte[a.Length];
				mapDatap2[i] = new byte[b.Length];
				if (i == 0x54)
				{
					//Console.WriteLine((pos + a.Length).ToString("X6"));
					//Console.WriteLine((pos + b.Length).ToString("X6"));
				}

				// 05FE1C
				// 05FE05

				// 05FFA7
				// 05FF78
				if ((pos + a.Length) >= 0x5FE70 && (pos + a.Length) <= 0x60000)
				{
					pos = 0x60000;
				}
				if ((pos + a.Length) >= 0x6411F && (pos + a.Length) <= 0x70000)
				{
					pos = 0x130000; // 0x0F8780;
				}

				for (int j = 0; j < i; j++)
				{
					if (compareArray(a, mapDatap1[j]))
					{
						// Reuse pointer id j for P1 (a)
						mapPointers1id[i] = j;
					}
					if (compareArray(b, mapDatap2[j]))
					{
						mapPointers2id[i] = j;
						// Reuse pointer id j for P2 (b)
					}
				}

				// Before Saving it to the ROM check if it match an existing map already
				if (mapPointers1id[i] == -1)
				{
					a.CopyTo(mapDatap1[i], 0);
					int snesPos = pos.PCtoSNES();
					mapPointers1[i] = snesPos;
					ROM[ZS.Offsets.compressedAllMap32PointersLow + (3 * i), 3] = snesPos;

					ROM.Write(pos, a);
					for (int j = 0; j < a.Length; j++)
					{
						//ROM.DATA[pos] = a[j];
						pos += 1;
					}
				}
				else
				{
					int snesPos = mapPointers1[mapPointers1id[i]];
					ROM[ZS.Offsets.compressedAllMap32PointersLow + (3 * i), 3] = snesPos;
				}

				if ((pos + b.Length) >= 0x5FE70 && (pos + b.Length) <= 0x60000)
				{
					pos = 0x60000;
				}
				if ((pos + b.Length) >= 0x6411F && (pos + b.Length) <= 0x70000)
				{
					pos = 0x130000;
				}

				// Map2
				if (mapPointers2id[i] == -1)
				{
					b.CopyTo(mapDatap2[i], 0);
					int snesPos = pos.PCtoSNES();
					mapPointers2[i] = snesPos;

					ROM[ZS.Offsets.compressedAllMap32PointersHigh + (3 * i), 3] = snesPos;
					ROM.Write(pos, b);

					for (int j = 0; j < b.Length; j++)
					{
						//ROM.DATA[pos] = b[j];
						pos += 1;
					}
				}
				else
				{
					int snesPos = mapPointers2[mapPointers2id[i]];
					ROM[ZS.Offsets.compressedAllMap32PointersHigh + (3 * i), 3] = snesPos;
				}
			}

			if (pos > 0x137FFF)
			{
				// TODO messagebox for failure "Too many maps data {pos:X6}"
				return true;
			}

			SaveLargeMaps();

			return false;

			//Console.WriteLine("Map Pos Length: " + pos.ToString("X6"));
			//Save32Tiles();
		}

		/// <summary>
		/// Saves the overworld area layout (whether the area is big or small).
		/// </summary>
		/// <param name="scene"></param>
		/// <returns></returns>
		public bool SaveLargeMaps()
		{
			// TODO: these temp vars can be removed along with thier print once testing is done
			string parentMapLine = "";

			string[] parentMap = new string[8];
			List<byte> checkedMap = new List<byte>();

			for (int i = 0; i < 64; i++)
			{
				int yPos = i / 8;
				int xPos = i % 8;
				int parentyPos = ZS.OverworldManager.allmaps[i].parent / 8;
				int parentxPos = ZS.OverworldManager.allmaps[i].parent % 8;

				// Always write the map parent since it should not matter
				ROM[ZS.Offsets.overworldMapParentId + i] = ZS.OverworldManager.allmaps[i].parent;
				parentMapLine += ZS.OverworldManager.allmaps[i].parent.ToString("X2").PadLeft(2, '0') + " ";

				if ((i + 1) % 8 == 0)
				{
					parentMap[((i + 1) / 8) - 1] = parentMapLine;

					parentMapLine = "";
				}

				if (checkedMap.Contains((byte) i))
				{
					continue; // Ignore that map we already checked it
				}

				if (ZS.OverworldManager.allmaps[i].largeMap) // If it's large then save parent pos * 0x200 otherwise pos * 0x200
				{
					// Check 1
					ROM[ZS.Offsets.overworldMapSize + i] = 0x20;
					ROM[ZS.Offsets.overworldMapSize + i + 1] = 0x20;
					ROM[ZS.Offsets.overworldMapSize + i + 8] = 0x20;
					ROM[ZS.Offsets.overworldMapSize + i + 9] = 0x20;

					// Check 2
					ROM[ZS.Offsets.overworldMapSizeHighByte + i] = 0x03;
					ROM[ZS.Offsets.overworldMapSizeHighByte + i + 1] = 0x03;
					ROM[ZS.Offsets.overworldMapSizeHighByte + i + 8] = 0x03;
					ROM[ZS.Offsets.overworldMapSizeHighByte + i + 9] = 0x03;

					// Check 3
					ROM[ZS.Offsets.overworldScreenSize + i] = 0x00;
					ROM[ZS.Offsets.overworldScreenSize + i + 64] = 0x00;

					ROM[ZS.Offsets.overworldScreenSize + i + 1] = 0x00;
					ROM[ZS.Offsets.overworldScreenSize + i + 1 + 64] = 0x00;
						  
					ROM[ZS.Offsets.overworldScreenSize + i + 8] = 0x00;
					ROM[ZS.Offsets.overworldScreenSize + i + 8 + 64] = 0x00;
						  
					ROM[ZS.Offsets.overworldScreenSize + i + 9] = 0x00;
					ROM[ZS.Offsets.overworldScreenSize + i + 9 + 64] = 0x00;

					// Check 4
					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i] = 0x04;
					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 64] = 0x04;
					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 128] = 0x04;

					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 1] = 0x04;
					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 1 + 64] = 0x04;
					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 1 + 128] = 0x04;

					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 8] = 0x04;
					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 8 + 64] = 0x04;
					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 8 + 128] = 0x04;

					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 9] = 0x04;
					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 9 + 64] = 0x04;
					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 9 + 128] = 0x04;

					// Check 5 and 6
					ROM[ZS.Offsets.transition_target_north + (i * 2) + 2, 2] = ((parentyPos * 0x200) - 0xE0); // (short) is placed to reduce the int to 2 bytes.
					ROM[ZS.Offsets.transition_target_west + (i * 2) + 2, 2] = ((parentxPos * 0x200) - 0x100);

					ROM[ZS.Offsets.transition_target_north + (i * 2) + 16, 2] = ((parentyPos * 0x200) - 0xE0); // (short) is placed to reduce the int to 2 bytes.
					ROM[ZS.Offsets.transition_target_west + (i * 2) + 16, 2] = ((parentxPos * 0x200) - 0x100);

					ROM[ZS.Offsets.transition_target_north + (i * 2) + 18, 2] = ((parentyPos * 0x200) - 0xE0); // (short) is placed to reduce the int to 2 bytes.
					ROM[ZS.Offsets.transition_target_west + (i * 2) + 18, 2] = ((parentxPos * 0x200) - 0x100);

					// Check 7 and 8 
					ROM[ZS.Offsets.overworldTransitionPositionX + (i * 2), 2] = (parentxPos * 0x200);
					ROM[ZS.Offsets.overworldTransitionPositionY + (i * 2), 2] = (parentyPos * 0x200);

					ROM[ZS.Offsets.overworldTransitionPositionX + (i * 2) + 2, 2] = (parentxPos * 0x200);
					ROM[ZS.Offsets.overworldTransitionPositionY + (i * 2) + 2, 2] = (parentyPos * 0x200);

					ROM[ZS.Offsets.overworldTransitionPositionX + (i * 2) + 16, 2] = (parentxPos * 0x200);
					ROM[ZS.Offsets.overworldTransitionPositionY + (i * 2) + 16, 2] = (parentyPos * 0x200);

					ROM[ZS.Offsets.overworldTransitionPositionX + (i * 2) + 18, 2] = (parentxPos * 0x200);
					ROM[ZS.Offsets.overworldTransitionPositionY + (i * 2) + 18, 2] = (parentyPos * 0x200);

					// Check 9
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2), 2] = 0x0060; // Always 0x0060
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 2, 2] = 0x0060; // Always 0x0060

					// If parentX == 0 then lower submaps == 0x0060 too 
					if (parentxPos == 0)
					{
						ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16, 2] = 0x0060;
						ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18, 2] = 0x0060;
					}
					else
					{
						// Otherwise lower submaps == 0x1060
						ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16, 2] = 0x1060;
						ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18, 2] = 0x1060;
					}

					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 128, 2] = 0x0080; // Always 0x0080
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 2 + 128, 2] = 0x0080; // Always 0x0080
																												// Lower are always 8010
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16 + 128, 2] = 0x1080; // Always 0x1080
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18 + 128, 2] = 0x1080; // Always 0x1080


					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 256, 2] = 0x1800; // Always 0x1800
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16 + 256, 2] = 0x1800; // Always 0x1800
																												 // Right side is always 1840
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 2 + 256, 2] = 0x1840; // Always 0x1840
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18 + 256, 2] = 0x1840; // Always 0x1840


					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 384, 2] = 0x2000; // Always 0x2000
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16 + 384, 2] = 0x2000; // Always 0x2000
																												 // Right side is always 0x2040
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 2 + 384, 2] = 0x2040; // Always 0x2000
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18 + 384, 2] = 0x2040; // Always 0x2000


					checkedMap.Add((byte) i);
					checkedMap.Add((byte) (i + 1));
					checkedMap.Add((byte) (i + 8));
					checkedMap.Add((byte) (i + 9));
				}
				else
				{
					ROM[ZS.Offsets.overworldMapSize + i] = 0x00;
					ROM[ZS.Offsets.overworldMapSizeHighByte + i] = 0x01;
						  
					ROM[ZS.Offsets.overworldScreenSize + i] = 0x01;
					ROM[ZS.Offsets.overworldScreenSize + i + 64] = 0x01;
						  
					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i] = 0x02;
					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 64] = 0x02;
					ROM[ZS.Offsets.OverworldScreenSizeForLoading + i + 128] = 0x02;

					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2), 2] = 0x0060;
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 128, 2] = 0x0040;
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 256, 2] = 0x1800;
					ROM[ZS.Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 384, 2] = 0x1000;

					ROM[ZS.Offsets.transition_target_north + (i * 2), 2] = (ushort) ((yPos * 0x200) - 0xE0);
					ROM[ZS.Offsets.transition_target_west + (i * 2), 2] = (ushort) ((xPos * 0x200) - 0x100);

					ROM[ZS.Offsets.overworldTransitionPositionX + (i * 2), 2] = (xPos * 0x200);
					ROM[ZS.Offsets.overworldTransitionPositionY + (i * 2), 2] = (yPos * 0x200);

					checkedMap.Add((byte) i);
				}
			}

			return false;
		}

		public bool SaveGravestones()
		{
			for (int i = 0; i < 0x0F; i++)
			{
				ROM[ZS.Offsets.GravesXTilePos + (i * 2), 2] = ZS.OverworldManager.graves[i].xTilePos;
				ROM[ZS.Offsets.GravesYTilePos + (i * 2), 2] = ZS.OverworldManager.graves[i].yTilePos;
				ROM[ZS.Offsets.GravesTilemapPos + (i * 2), 2] = ZS.OverworldManager.graves[i].tilemapPos;

				if (i == 0x0E)
				{
					ROM[ZS.Offsets.GraveLinkSpecialStairs, 2] = ZS.OverworldManager.graves[i].tilemapPos - 0x80;
				}
				if (i == 0x0D)
				{
					ROM[ZS.Offsets.GraveLinkSpecialHole, 2] = ZS.OverworldManager.graves[i].tilemapPos - 0x80;
				}
			}

			return false;
		}

		public bool SaveTitleScreen()
		{
			return ZS.MainForm.screenEditor.Save();
		}

		public bool SaveDungeonMaps()
		{
			return ZS.MainForm.screenEditor.dungmapSaveAllCurrentDungeon();
		}

		public bool SaveOverworldMiniMap()
		{
			return ZS.MainForm.screenEditor.saveOverworldMap();
		}

		public bool SaveTriforce()
		{
			return ZS.MainForm.screenEditor.saveTriforce();
		}

		// TODO : OW Message Load/Save
		// OW Musics Saves

		// Move ROOM FEATURES
	}
}


