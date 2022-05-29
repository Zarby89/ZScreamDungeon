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
	// TODO LIST
	// 
	// 
	// 
	// 
	// 
	// 
	// 

	class Save
	{
		// ROM.DATA is a base rom loaded to get basic information it can either be JP1.0 or US1.2
		Room[] all_rooms;
		string[] texts;
		string debugstring = "";

		int[] roomTilesPointers = new int[Constants.NumberOfRooms];
		int[] roomDoorsPointers = new int[Constants.NumberOfRooms];
		int saddr = 0;

		byte[][] mapDatap1 = new byte[Constants.NumberOfOWMaps][];
		byte[][] mapDatap2 = new byte[Constants.NumberOfOWMaps][];
		int[] mapPointers1id = new int[Constants.NumberOfOWMaps];
		int[] mapPointers2id = new int[Constants.NumberOfOWMaps];

		int[] mapPointers1 = new int[Constants.NumberOfOWMaps];
		int[] mapPointers2 = new int[Constants.NumberOfOWMaps];

		DungeonMain mainForm;

		public Save(Room[] all_rooms, DungeonMain _mainForm)
		{
			this.all_rooms = all_rooms;
			mainForm = _mainForm;
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
			int headerPointer = getLongPointerSnestoPc(Constants.room_header_pointer);
			if (headerPointer < 0x100000)
			{
				MovePointer mp = new MovePointer();
				mp.ShowDialog();
				headerPointer = mp.address;

				int addr = Utils.PcToSnes(mp.address);
				ROM.WriteLong(Constants.room_header_pointer, addr, true, "Header Pointers Location");
				ROM.Write(Constants.room_header_pointers_bank, ROM.DATA[Constants.room_header_pointer + 2], true, "Header Bank");
			}

			ROM.StartBlockLogWriting("Room Headers", headerPointer);
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				int newsptraddr = (Utils.PcToSnes((headerPointer + 640) + (i * 14)));
				ROM.WriteShort((headerPointer) + (i * 2), newsptraddr, true, "Header " + i.ToString("D3") + " Pointer");
				saveHeader((headerPointer + 640), i);
			}

			ROM.EndBlockLogWriting();

			ROM.StartBlockLogWriting("Rooms Messages", Constants.messages_id_dungeon);
			//ROM.SaveLogs();
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				ROM.WriteShort(Constants.messages_id_dungeon + (i * 2), all_rooms[i].messageid, true, "Message Room ID : " + i.ToString("D3"));
			}

			ROM.EndBlockLogWriting();
			return false; // False = no error
		}

		public int getLongPointerSnestoPc(int pos)
		{
			return (Utils.SnesToPc(ROM.ReadLong(pos)));
		}

		public bool saveBlocks()
		{
			// If we reach 0x80 size jump to pointer2 etc...
			int[] region = new int[4] { Constants.blocks_pointer1, Constants.blocks_pointer2, Constants.blocks_pointer3, Constants.blocks_pointer4 };
			int blockCount = 0;
			int r = 0;
			int pos = getLongPointerSnestoPc(region[r]);
			int count = 0;
			ROM.StartBlockLogWriting("Blocks Data", pos);

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				foreach (Room_Object o in all_rooms[i].tilesObjects)
				{
					if ((o.options & ObjectOption.Block) == ObjectOption.Block) // If we find a block save it
					{
						int xy = (((o.y * 64) + o.x) << 1);
						byte[] data = new byte[4] {
							(byte)((i & 0xFF)),
							(byte)(((i >> 8) & 0xFF)),
							(byte)(xy & 0xFF),
							((byte)(((xy >> 8) & 0x1F) + (o.layer * 0x20)))
						};

						
						ROM.Write(pos, data, true, string.Format("Room: {0:3X} | X: {1:2X}, Y: {2:2X}, L: {3:2X}", i, o.x, o.y, o.size));

						pos += 4;
						count += 4;
						if (count >= 0x80)
						{
							r++;
							pos = getLongPointerSnestoPc(region[r]);
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

			ROM.EndBlockLogWriting();

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
			Console.WriteLine("Saving Custom Collision");
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

			Console.WriteLine(room_pointer + " " + data_pointer);

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
					ROM.WriteLong(room_pointer, Utils.PcToSnes(data_pointer));
				}
				else
				{
					ROM.WriteLong(room_pointer, 0x000000);
				}

				room_pointer += 3;

				foreach (var rectangle in room.collision_rectangles)
				{
					Console.WriteLine(rectangle.ToString());

					ROM.WriteShort(data_pointer, rectangle.index_data);
					data_pointer += 2;
					ROM.WriteShort(data_pointer, rectangle.width);
					data_pointer += 1;
					ROM.WriteShort(data_pointer, rectangle.height);
					data_pointer += 1;
					for (int j = 0; j < rectangle.width * rectangle.height; j++)
					{
						ROM.WriteShort(data_pointer, rectangle.tile_data[j]);
						data_pointer += 1;
					}

					//ROM.WriteLong(data_pointer, 0x000000);
					//data_pointer += 3;
				}

				// Add 0xFFFF to the end of this rooms list to tell the asm to stop here
				if (room.collision_rectangles.Count() > 0)
				{
					ROM.WriteLong(data_pointer, 0x00FFFF);
					data_pointer += 2;
				}
			}

			string projectFilename = mainForm.projectFilename;

			byte[] data = new byte[ROM.DATA.Length];
			ROM.DATA.CopyTo(data, 0);
			AsarCLR.Asar.init();

			// TODO handle differently in projects
			if (File.Exists("CustomCollision.asm"))
			{
				Console.WriteLine("Applying Custom Collision asm");
				AsarCLR.Asar.patch("CustomCollision.asm", ref ROM.DATA);
			}

			foreach (AsarCLR.Asarerror error in AsarCLR.Asar.geterrors())
			{
				Console.WriteLine(error.Fullerrdata.ToString());
			}

			return false;
		}

		public bool saveTorches()
		{
			int bytes_count = ROM.ReadShort(Constants.torches_length_pointer);

			int pos = Constants.torch_data;
			ROM.StartBlockLogWriting("Torches Data", pos);
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
							ROM.WriteShort(pos, i, true, "Torches in room " + i.ToString("D3"));
							pos += 2;
							room = true;
						}

						int xy = (((o.y * 64) + o.x) << 1);
						byte b1 = (byte) (xy & 0xFF);
						ROM.Write(pos++, b1, WriteType.TorchData);
						byte b2 = (byte) ((xy >> 8) & 0xFF);

						if (o.layer == 1)
						{
							b2 |= 0x20;
						}

						b2 |= (byte) ((o.lit ? 1 : 0) << 7);
						ROM.Write(pos++, b2, WriteType.TorchData);
					}
				}
				if (room)
				{
					ROM.WriteShort(pos, 0xFFFF);
					pos += 2;
				}
			}

			if ((pos - Constants.torch_data) > 0x120)
			{
				return true;
			}
			else
			{
				short npos = (short) (pos - Constants.torch_data);
				ROM.WriteShort(Constants.torches_length_pointer, npos);
			}

			ROM.EndBlockLogWriting();
			return false; // False = no error
		}

		public void saveHeader(int pos, int i)
		{
			byte[] headerData = new byte[14]
			{
				(byte)((((byte)all_rooms[i].bg2 & 0x07) << 5) + ((int)all_rooms[i].collision << 2) + (all_rooms[i].light ? 1 : 0)),
				all_rooms[i].palette,
				all_rooms[i].blockset,
				all_rooms[i].spriteset,
				((byte)all_rooms[i].effect),
				((byte)all_rooms[i].tag1),
				((byte)all_rooms[i].tag2),
				(byte)((all_rooms[i].holewarp_plane) + (all_rooms[i].staircase1Plane << 2) + (all_rooms[i].staircase2Plane << 4) + (all_rooms[i].staircase3Plane << 6)),
				all_rooms[i].staircase4Plane,
				all_rooms[i].holewarp,
				all_rooms[i].staircase1,
				all_rooms[i].staircase2,
				all_rooms[i].staircase3,
				all_rooms[i].staircase4
			};

			ROM.Write(pos + (i * 14), headerData, true, "Room Header " + i.ToString("D3"));
		}

		public bool saveAllPits()
		{
			int pitCount = (ROM.DATA[Constants.pit_count] / 2);
			int pitPointer = ROM.ReadLong(Constants.pit_pointer);
			pitPointer = Utils.SnesToPc(pitPointer);
			ROM.StartBlockLogWriting("Pits Data", pitPointer);
			int pitCountNew = 0;

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				if (all_rooms[i].damagepit)
				{
					ROM.WriteShort(pitPointer, all_rooms[i].index, true);
					pitPointer += 2;
					pitCountNew++;
				}
			}

			if (pitCountNew > pitCount)
			{
				return true;
			}

			ROM.EndBlockLogWriting();
			return false;
		}

		public bool saveAllObjects()
		{
			var section1Index = 0x50008; // 0x50000 to 0x5374F  // 53730
			var section2Index = 0xF878A; // 0xF878A to 0xFFFFF
			var section3Index = 0x1EB90; // 0x1EB90 to 0x1FFFF
			var section4Index = 0x1112C0; // If vanilla space is used use expanded region
			int section4Start = 0x1112C0;
			bool usedSection4 = false;
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
					usedSection4 = true;
					continue;
					// Move to EXPANDED region
					//Console.WriteLine("Room " + i + " no more space jump to 0x121210");
					//currentPos = 0x121210;
					//MessageBox.Show("We are running out space in the original portion of the ROM next data will be writed to : 0x121210");
				}
			}

			if (usedSection4)
			{
				Console.WriteLine("Used section4 for tiles index at location : " + section4Start.ToString("X6") + "Length of :" + (section4Index - section4Start).ToString("X6"));
			}

			int objectPointer = Utils.SnesToPc(ROM.ReadLong(Constants.room_object_pointer));
			ROM.StartBlockLogWriting("Room And Doors Pointers", objectPointer);
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				ROM.WriteLong(objectPointer + (i * 3), roomTilesPointers[i], true, "Room " + i.ToString("D3") + " Tiles Pointer");
				ROM.WriteLong(Constants.doorPointers + (i * 3), roomDoorsPointers[i], true, "Room " + i.ToString("D3") + " Doors Pointer");
			}

			ROM.EndBlockLogWriting();

			return false; // False = no error
		}

		void saveObjectBytes(int roomId, int position, byte[] bytes, int doorOffset)
		{
			int objectPointer = Utils.SnesToPc(ROM.ReadLong(Constants.room_object_pointer));
			saddr = Utils.PcToSnes(position);
			roomTilesPointers[roomId] = saddr;
			int daddr = Utils.PcToSnes(position + doorOffset);
			roomDoorsPointers[roomId] = daddr;
			// Update the index

			ROM.StartBlockLogWriting("Room " + roomId.ToString("D3") + " Tiles Data", position);
			if (ROM.AdvancedLogs)
			{
				int bp = 2;
				ROM.romLog.Append(bytes[0].ToString("X2") + ", " + bytes[1].ToString("X2") + "// Room Layout and Floors\r\n");
				while (bp < bytes.Length)
				{
					for (int i = 0; i < 32; i++)
					{
						if (bp >= bytes.Length)
						{
							break;
						}

						ROM.romLog.Append(bytes[bp++].ToString("X2") + " ");
					}

					ROM.romLog.Append("\r\n");
				}
			}

			Array.Copy(bytes, 0, ROM.DATA, position, bytes.Length);
			ROM.EndBlockLogWriting();
		}

		public void savePalettes() // room settings floor1, floor2, blockset, spriteset, palette
		{
			// TODO: Add something here?
		}

		public bool saveallChests()
		{
			int cpos = Utils.SnesToPc(ROM.ReadLong(Constants.chests_data_pointer1));
			int chestCount = 0;
			ROM.StartBlockLogWriting("Chests Data", cpos);

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

					byte[] data = new byte[3]
					{
						(byte)(room_index & 0xFF),
						(byte)((room_index >> 8) & 0xFF),
						c.item,
					};

					ROM.Write(cpos, data, true, string.Format("Chest: {0:2X}", i));
					cpos += 3;
					chestCount++;
				}
			}

			//Console.WriteLine("Nbr of chests : " + chestCount);
			if (chestCount > 168)
			{
				return true; // False = no error
			}

			ROM.EndBlockLogWriting();
			return false; // False = no error
		}

		public bool saveallPots()
		{
			int pos = Constants.items_data_start + 2; // Skip 2 FF FF that are empty pointer
			ROM.StartBlockLogWriting("Pots Items Data", pos);

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				if (all_rooms[i].pot_items.Count == 0)
				{
					ROM.WriteShort(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(Constants.items_data_start), true, "Items Pointer for Room " + i.ToString("D3"));
					continue;
				}

				// Pointer
				ROM.WriteShort(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(pos), true, "Items Pointer for Room " + i.ToString("D3"));
				for (int j = 0; j < all_rooms[i].pot_items.Count; j++)
				{
					if (all_rooms[i].pot_items[j].layer == 0)
					{
						all_rooms[i].pot_items[j].bg2 = false;
					}
					else
					{
						all_rooms[i].pot_items[j].bg2 = true;
					}

					int xy = (((all_rooms[i].pot_items[j].y * 64) + all_rooms[i].pot_items[j].x) << 1);

					byte[] data = new byte[3]
					{
					   (byte)(xy & 0xFF),
					   (byte)(((xy >> 8) & 0xFF) + (all_rooms[i].pot_items[j].bg2 ? 0x20 : 0x00)),
					   all_rooms[i].pot_items[j].id
					};
					ROM.Write(pos, data, true, "Items Data for Room " + i.ToString("D3"));
					pos += 3;
				}

				ROM.WriteShort(pos, 0xFFFF, true);
				pos += 2;
				if (pos > Constants.items_data_end)
				{
					ROM.SaveLogs();
					return true;
				}
			}

			ROM.EndBlockLogWriting();
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
			if (te.Save())
			{
				return true;
			}

			return false;
		}

		public bool saveallSprites()
		{
			int spritePointer = (09 << 16) + (ROM.DATA[Constants.rooms_sprite_pointer + 1] << 8) + (ROM.DATA[Constants.rooms_sprite_pointer]);
			int spritePointerPC = Utils.SnesToPc(spritePointer);
			ROM.StartBlockLogWriting("Dungeon Sprites", spritePointerPC);
			byte[] sprites_buffer = new byte[Constants.sprites_end_data - Utils.SnesToPc(spritePointer)];

			// Empty room data = 0x280
			// Start of data = 0x282
			try
			{
				int pos = 0x282;
				// Set empty room
				sprites_buffer[0x280] = 0x00;
				sprites_buffer[0x281] = 0xFF;

				for (int i = 0; i < 320; i++)
				{
					if (i >= Constants.NumberOfRooms || all_rooms[i].sprites.Count <= 0)
					{
						sprites_buffer[(i * 2)] = (byte) ((Utils.PcToSnes(Utils.SnesToPc(spritePointer + 0x280)) & 0xFF));
						sprites_buffer[(i * 2) + 1] = (byte) (((Utils.SnesToPc(spritePointer + 0x280)) >> 8) & 0xFF);
					}
					else
					{
						// Pointer: 
						sprites_buffer[(i * 2)] = (byte) ((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) & 0xFF));
						sprites_buffer[(i * 2) + 1] = (byte) ((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) >> 8) & 0xFF);

						sprites_buffer[pos++] = (byte) (all_rooms[i].sortsprites ? 0x01 : 0x00); // Unknown byte??

						foreach (Sprite spr in all_rooms[i].sprites) // 3bytes
						{
							sprites_buffer[pos++] = (byte) ((spr.layer << 7) + ((spr.subtype & 0x18) << 2) + spr.y);
							sprites_buffer[pos++] = (byte) (((spr.subtype & 0x07) << 5) + spr.x);
							sprites_buffer[pos++] = (spr.id);

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

						sprites_buffer[pos++] = 0xFF; // End of sprites
					}
				}

				ROM.EndBlockLogWriting();
				sprites_buffer.CopyTo(ROM.DATA, spritePointerPC);
			}
			catch (Exception)
			{
				return true;
			}

			return false; // False = no error
		}

		public bool saveOWExits(SceneOW scene)
		{
			ROM.StartBlockLogWriting("OW Exits", Constants.OWExitMapId);

			for (int i = 0; i < 78; i++)
			{
				ROM.Write(Constants.OWExitMapId + (i), (byte) ((scene.ow.allexits[i].mapId) & 0xFF), WriteType.ExitProperties);
				ROM.WriteShort(Constants.OWExitXScroll + (i * 2), ((scene.ow.allexits[i].xScroll)), WriteType.ExitProperties);
				ROM.WriteShort(Constants.OWExitYScroll + (i * 2), ((scene.ow.allexits[i].yScroll)), WriteType.ExitProperties);
				ROM.WriteShort(Constants.OWExitXCamera + (i * 2), ((scene.ow.allexits[i].cameraX)), WriteType.ExitProperties);
				ROM.WriteShort(Constants.OWExitYCamera + (i * 2), ((scene.ow.allexits[i].cameraY)), WriteType.ExitProperties);
				ROM.WriteShort(Constants.OWExitVram + (i * 2), ((scene.ow.allexits[i].vramLocation)), WriteType.ExitProperties);
				ROM.WriteShort(Constants.OWExitRoomId + (i * 2), ((scene.ow.allexits[i].roomId)), WriteType.ExitProperties);
				ROM.WriteShort(Constants.OWExitXPlayer + (i * 2), ((scene.ow.allexits[i].playerX)), WriteType.ExitProperties);
				ROM.WriteShort(Constants.OWExitYPlayer + (i * 2), ((scene.ow.allexits[i].playerY)), WriteType.ExitProperties);
				ROM.WriteShort(Constants.OWExitDoorType1 + (i * 2), ((scene.ow.allexits[i].doorType1)), WriteType.ExitProperties);
				ROM.WriteShort(Constants.OWExitDoorType2 + (i * 2), ((scene.ow.allexits[i].doorType2)), WriteType.ExitProperties);
			}

			ROM.EndBlockLogWriting();
			return false;
		}

		public bool saveOWEntrances(SceneOW scene)
		{
			ROM.StartBlockLogWriting("OW Entrances/Holes", Constants.OWEntranceMap);

			for (int i = 0; i < scene.ow.allentrances.Length; i++)
			{
				ROM.WriteShort(Constants.OWEntranceMap + (i * 2), ((scene.ow.allentrances[i].mapId)), WriteType.EntranceProperties);
				ROM.WriteShort(Constants.OWEntrancePos + (i * 2), ((scene.ow.allentrances[i].mapPos)), WriteType.EntranceProperties);
				ROM.Write(Constants.OWEntranceEntranceId + i, (byte) ((scene.ow.allentrances[i].entranceId) & 0xFF), WriteType.EntranceProperties);
			}

			for (int i = 0; i < scene.ow.allholes.Length; i++)
			{
				ROM.WriteShort(Constants.OWHoleArea + (i * 2), ((scene.ow.allholes[i].mapId)), WriteType.EntranceProperties);
				ROM.WriteShort(Constants.OWHolePos + (i * 2), (((scene.ow.allholes[i].mapPos - 0x400))), WriteType.EntranceProperties);
				ROM.Write(Constants.OWHoleEntrance + i, (byte) ((scene.ow.allholes[i].entranceId) & 0xFF), WriteType.EntranceProperties);
			}

			ROM.EndBlockLogWriting();
			//WriteLog("Overworld Entrances data loaded properly", Color.Green);
			return false;
		}

		public bool saveOWItems(SceneOW scene)
		{
			ROM.StartBlockLogWriting("Items OW DATA & Pointers", Constants.overworldItemsPointers);
			List<RoomPotSaveEditor>[] roomItems = new List<RoomPotSaveEditor>[128];

			for (int i = 0; i < 128; i++)
			{
				roomItems[i] = new List<RoomPotSaveEditor>();
				foreach (RoomPotSaveEditor item in scene.ow.allitems)
				{
					if (item.roomMapId == i)
					{
						roomItems[i].Add(item);
					}
				}
			}

			int dataPos = Constants.overworldItemsPointers + 0x100;

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
					if (compareItemsArrays(roomItems[i].ToArray(), roomItems[ci].ToArray()))
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
						
						short mapPos = (short) (((item.gameY << 6) + item.gameX) << 1);

						ROM.Write(
							dataPos, 
							new byte[3] { (byte) (mapPos & 0xFF), (byte) (mapPos >> 8), (byte) (item.id) },
							WriteType.PotItemData
						);
						
						dataPos += 3;
					}

					emptyPtr = dataPos;
					ROM.WriteShort(dataPos, 0xFFFF, true, "End Item Data");
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

				int snesaddr = Utils.PcToSnes(itemPtrs[i]);
				ROM.WriteShort(Constants.overworldItemsPointers + (i * 2), (snesaddr), true, "Item Pointer for room" + i.ToString("D3"));
			}

			if (dataPos > Constants.overworldItemsEndData)
			{
				return true;
			}

			ROM.EndBlockLogWriting();
			Console.WriteLine("End of Items : " + dataPos.ToString("X6"));

			return false;
		}

		public bool SaveOWSprites(SceneOW scene)
		{
			ROM.StartBlockLogWriting("Sprites OW DATA & Pointers", Constants.overworldSpritesBegining);
			int[] sprPointers = new int[Constants.NumberOfOWSprites];
			int[] sprPointersReused = new int[Constants.NumberOfOWSprites];
			List<Sprite>[] allspr = new List<Sprite>[Constants.NumberOfOWSprites];

			for (int j = 0; j < Constants.NumberOfOWSprites; j++)
			{
				sprPointersReused[j] = -1;
				allspr[j] = new List<Sprite>();
			}

			for (int i = 0; i < Constants.NumberOfOWSprites; i++) // For each pointers
			{
				if (i < 64) // LW[0]
				{
					Sprite[] sprArray = scene.ow.allsprites[0].Where(s => s.mapid == i).ToArray();
					foreach (Sprite spr in sprArray)
					{
						allspr[i].Add(spr);
					}
				}
				else if (i >= 64 && i < 208) // LW & DW[1]
				{
					Sprite[] sprArray = scene.ow.allsprites[1].Where(s => s.mapid == (i - 64)).ToArray();
					foreach (Sprite spr in sprArray)
					{
						allspr[i].Add(spr);
					}
				}
				else if (i >= 208 && i < Constants.NumberOfOWSprites) // LW[2]
				{
					Sprite[] sprArray = scene.ow.allsprites[2].Where(s => s.mapid == (i - 208)).ToArray();
					foreach (Sprite spr in sprArray)
					{
						allspr[i].Add(spr);
					}
				}
			}

			for (int i = 0; i < Constants.NumberOfOWSprites; i++)
			{
				sprPointersReused[i] = -1;
				for (int ci = 0; ci < Constants.NumberOfOWSprites; ci++)
				{
					if (ci >= i)
					{
						break;
					}

					// the i != ci condition is useless, because it would have hit the break if we were equal
					if (compareSpriteArrays(allspr[i].ToArray(), allspr[ci].ToArray()))
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
				if (sprPointersReused[i] == -1)
				{
					sprPointers[i] = dataPos;
					foreach (Sprite spr in allspr[i])
					{
						ROM.Write(dataPos, new byte[] { spr.y, spr.x, spr.id }, WriteType.SpriteData);
						dataPos += 3;
					}

					ROM.Write(dataPos++, 0xFF, true, "Termination Byte");
				}
				else
				{
					sprPointers[i] = sprPointers[sprPointersReused[i]];
				}

				int snesaddr = Utils.PcToSnes(sprPointers[i]);
				ROM.WriteShort(Constants.overworldSpritesBegining + (i * 2), (snesaddr), true, "Sprite Pointer for map" + i.ToString("D3"));
			}

			if (dataPos > 0x4D62E)
			{
				Console.WriteLine("Position " + dataPos.ToString("X6"));
				return true; // Error
			}

			ROM.EndBlockLogWriting();
			return false; // No errors
		}

		public bool compareSpriteArrays(Sprite[] spr1, Sprite[] spr2)
		{
			if (spr1.Length != spr2.Length)
			{
				return false;
			}

			bool match;
			for (int i = 0; i < spr1.Length; i++)
			{
				match = false;
				for (int j = 0; j < spr2.Length; j++)
				{
					// Check all sprite in 2nd array if one match
					if (spr1[i].x == spr2[j].x &&
						spr1[i].y == spr2[j].y &&
						spr1[i].id == spr2[j].id)
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

		public bool compareItemsArrays(RoomPotSaveEditor[] itm1, RoomPotSaveEditor[] itm2)
		{
			if (itm1.Length != itm2.Length)
			{
				return false;
			}

			bool match;
			for (int i = 0; i < itm1.Length; i++)
			{
				match = false;
				for (int j = 0; j < itm2.Length; j++)
				{
					// Check all sprite in 2nd array if one match
					if (itm1[i].x == itm2[j].x &&
						itm1[i].y == itm2[j].y &&
						itm1[i].id == itm2[j].id)
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

		public bool saveOWTransports(SceneOW scene)
		{
			ROM.StartBlockLogWriting("Transports Data", Constants.OWExitMapIdWhirlpool);

			for (int i = 0; i < 0x11; i++)
			{
				ROM.WriteShort(Constants.OWExitMapIdWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].mapId), true, "MapId");

				ROM.WriteShort(Constants.OWExitXScrollWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].xScroll), true, "XScroll");

				ROM.WriteShort(Constants.OWExitYScrollWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].yScroll), true, "YScroll");

				ROM.WriteShort(Constants.OWExitXCameraWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].cameraX), true, "XCamera");

				ROM.WriteShort(Constants.OWExitYCameraWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].cameraY), true, "YCamera");

				ROM.WriteShort(Constants.OWExitVramWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].vramLocation), true, "VRAM");

				ROM.WriteShort(Constants.OWExitXPlayerWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].playerX), true, "XPlayer");

				ROM.WriteShort(Constants.OWExitYPlayerWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].playerY), true, "YPlayer");

				if (i > 8)
				{
					ROM.WriteShort(Constants.OWWhirlpoolPosition + ((i - 9) * 2), (scene.ow.allWhirlpools[i].whirlpoolPos), true, "Pos");
				}
			}

			ROM.EndBlockLogWriting();
			return false;
		}

		public bool saveMapProperties(SceneOW scene)
		{
			ROM.StartBlockLogWriting("Map Properties", Constants.mapGfx);

			for (int i = 0; i < 64; i++)
			{
				ROM.Write(Constants.mapGfx + i, scene.ow.allmaps[i].gfx,WriteType.GFX);
				ROM.Write(Constants.overworldSpriteset + i, scene.ow.allmaps[i].sprgfx[0], WriteType.SpriteSet);
				ROM.Write(Constants.overworldSpriteset + 64 + i, scene.ow.allmaps[i].sprgfx[1], WriteType.SpriteSet);
				ROM.Write(Constants.overworldSpriteset + 128 + i, scene.ow.allmaps[i].sprgfx[2], WriteType.SpriteSet);
				ROM.Write(Constants.overworldMapPalette + i, scene.ow.allmaps[i].palette, WriteType.Palette);
				ROM.Write(Constants.overworldSpritePalette + i, scene.ow.allmaps[i].sprpalette[0], WriteType.SpritePalette);
				ROM.Write(Constants.overworldSpritePalette + 64 + i, scene.ow.allmaps[i].sprpalette[1], WriteType.SpritePalette);
				ROM.Write(Constants.overworldSpritePalette + 128 + i, scene.ow.allmaps[i].sprpalette[2], WriteType.SpritePalette);
			}

			for (int i = 64; i < 128; i++)
			{
				ROM.Write(Constants.mapGfx + i, scene.ow.allmaps[i].gfx,WriteType.GFX);
				ROM.Write(Constants.overworldSpriteset + 128 + i, scene.ow.allmaps[i].sprgfx[0], WriteType.SpriteSet);
				ROM.Write(Constants.overworldSpriteset + 128 + i, scene.ow.allmaps[i].sprgfx[1], WriteType.SpriteSet);
				ROM.Write(Constants.overworldSpriteset + 128 + i, scene.ow.allmaps[i].sprgfx[2], WriteType.SpriteSet);
				ROM.Write(Constants.overworldMapPalette + i, scene.ow.allmaps[i].palette, WriteType.Palette);
				ROM.Write(Constants.overworldSpritePalette + 128 + i, scene.ow.allmaps[i].sprpalette[0], WriteType.SpritePalette);
				ROM.Write(Constants.overworldSpritePalette + 128 + i, scene.ow.allmaps[i].sprpalette[1], WriteType.SpritePalette);
				ROM.Write(Constants.overworldSpritePalette + 128 + i, scene.ow.allmaps[i].sprpalette[2], WriteType.SpritePalette);
			}

			ROM.EndBlockLogWriting();
			return false;
		}

		public bool saveMapOverlays(SceneOW scene)
		{
			ROM.StartBlockLogWriting("Map Overlays", Constants.mapGfx);

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

			ROM.Write(0x77657, newOverlayCode, true, "New Overlay Code");

			int ptrStart = (0x77657 + 32);
			int snesptrstart = Utils.PcToSnes(ptrStart);
			// 10, 16, 
			ROM.WriteLong(0x77657 + 10, snesptrstart, true, "Overlay Pointerp1");
			ROM.WriteLong(0x77657 + 16, snesptrstart + 2, true, "Overlay Pointerp2");

			int peaAddr = Utils.PcToSnes(0x77657 + 27);

			ROM.WriteShort(0x77657 + 23, peaAddr, true, "Pea Addr (don't ask)");

			// TODO : Optimize that routine to be smaller

			// 0x058000
			int pos = 0x120000;
			int ptrPos = 0x77657 + 32;
			for (int i = 0; i < 128; i++)
			{
				int snesaddr = Utils.PcToSnes(pos);
				ROM.WriteLong(ptrPos, snesaddr, true, "Overlay actual Pointers");
				ptrPos += 3;

				for (int t = 0; t < scene.ow.alloverlays[i].tilesData.Count; t++)
				{
					ushort addr = (ushort) ((scene.ow.alloverlays[i].tilesData[t].x * 2) + (scene.ow.alloverlays[i].tilesData[t].y * 128) + 0x2000);
					// LDA TileID : STA $addr
					// A9 (LDA #$)
					// A2 (LDX #$)
					// 8D (STA $xxxx)

					// LDA :
					ROM.Write(pos, 0xA9, true, "Overlay Data, LDA");
					ROM.WriteShort(pos + 1, (scene.ow.alloverlays[i].tilesData[t].tileId), true, "Overlay Data, TileID");
					pos += 3;

					// STA : 
					ROM.Write(pos, 0x8D, true, "Overlay Data, STA");
					ROM.WriteShort(pos + 1, addr, true, "Overlay Data, TilePos");
					pos += 3;
				}

				ROM.Write(pos, 0x6B, true, "RTL"); // RTL
				pos++;
			}

			ROM.EndBlockLogWriting();
			return false;
		}

		public bool saveOverworldTilesType(SceneOW scene)
		{
			ROM.StartBlockLogWriting("Overworld Tiles Types", Constants.overworldTilesType);
			for (int i = 0; i < 0x200; i++)
			{
				ROM.Write(Constants.overworldTilesType + i, scene.ow.allTilesTypes[i], true, "Tile ID" + i.ToString("D3") + " Type:" + scene.ow.allTilesTypes[i].ToString("D3"));
			}

			ROM.EndBlockLogWriting();
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

		public bool saveOverworldMessagesIds(SceneOW scene)
		{
			ROM.StartBlockLogWriting("Overworld Messages IDs", Constants.overworldMessages);

			for (int i = 0; i < 128; i++)
			{
				ROM.WriteShort(Constants.overworldMessages + (i * 2), scene.ow.allmaps[i].messageID, true, "OW Message ID for map " + i.ToString("D3"));
			}

			ROM.EndBlockLogWriting();

			return false;
		}

		public bool saveOverworldMusics(SceneOW scene)
		{
			ROM.StartBlockLogWriting("Overworld Musics IDs", Constants.overworldMessages);

			for (int i = 0; i < 64; i++)
			{
				ROM.Write(Constants.overworldMusicBegining + i, scene.ow.allmaps[i].musics[0], true, "OW Musics ID for map " + i.ToString("D3"));
				ROM.Write(Constants.overworldMusicZelda + i, scene.ow.allmaps[i].musics[1], true, "OW Musics ID for map " + i.ToString("D3"));
				ROM.Write(Constants.overworldMusicMasterSword + i, scene.ow.allmaps[i].musics[2], true, "OW Musics ID for map " + i.ToString("D3"));
				ROM.Write(Constants.overworldMusicAgahim + i, scene.ow.allmaps[i].musics[3], true, "OW Musics ID for map " + i.ToString("D3"));

			}

			for (int i = 0; i < 64; i++)
			{
				ROM.Write(Constants.overworldMusicDW + i, scene.ow.allmaps[i].musics[0], true, "OW Musics ID for map " + (i + 64).ToString("D3"));

			}

			ROM.EndBlockLogWriting();

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

		public bool saveOverworldMaps(SceneOW scene)
		{
			for (int i = 0; i < 160; i++)
			{
				mapPointers1id[i] = -1;
				mapPointers2id[i] = -1;
			}

			int pos = 0x058000;
			for (int i = 0; i < 160; i++)
			{
				int npos = 0;
				byte[]
					singlemap1 = new byte[512],
					singlemap2 = new byte[512];

				for (int y = 0; y < 16; y++)
				{
					for (int x = 0; x < 16; x++)
					{
						singlemap1[npos] = (byte) (scene.ow.t32[npos + (i * 256)] & 0xFF);
						singlemap2[npos] = (byte) ((scene.ow.t32[npos + (i * 256)] >> 8) & 0xFF);
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
					int snesPos = Utils.PcToSnes(pos);
					mapPointers1[i] = snesPos;
					ROM.Write((Constants.compressedAllMap32PointersLow) + 0 + 3 * i, (byte) (snesPos & 0xFF), WriteType.OverworldMapPointer);
					ROM.Write((Constants.compressedAllMap32PointersLow) + 1 + 3 * i, (byte) ((snesPos >> 8) & 0xFF), WriteType.OverworldMapPointer);
					ROM.Write((Constants.compressedAllMap32PointersLow) + 2 + 3 * i, (byte) ((snesPos >> 16) & 0xFF), WriteType.OverworldMapPointer);
					/*
                    ROM.DATA[(Constants.compressedAllMap32PointersLow) + 0 + (int)(3 * i)] = (byte)(snesPos & 0xFF);
                    ROM.DATA[(Constants.compressedAllMap32PointersLow) + 1 + (int)(3 * i)] = (byte)((snesPos >> 8) & 0xFF);
                    ROM.DATA[(Constants.compressedAllMap32PointersLow) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);
                    */

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
					ROM.Write((Constants.compressedAllMap32PointersLow) + 0 + 3 * i, (byte) (snesPos & 0xFF), WriteType.OverworldMapPointer);
					ROM.Write((Constants.compressedAllMap32PointersLow) + 1 + 3 * i, (byte) ((snesPos >> 8) & 0xFF), WriteType.OverworldMapPointer);
					ROM.Write((Constants.compressedAllMap32PointersLow) + 2 + 3 * i, (byte) ((snesPos >> 16) & 0xFF), WriteType.OverworldMapPointer);
					/*
                    ROM.DATA[(Constants.compressedAllMap32PointersLow) + 0 + (int)(3 * i)] = (byte)(snesPos & 0xFF);
                    ROM.DATA[(Constants.compressedAllMap32PointersLow) + 1 + (int)(3 * i)] = (byte)((snesPos >> 8) & 0xFF);
                    ROM.DATA[(Constants.compressedAllMap32PointersLow) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);
                    */
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
					int snesPos = Utils.PcToSnes(pos);
					mapPointers2[i] = snesPos;

					ROM.Write((Constants.compressedAllMap32PointersHigh) + 0 + 3 * i, (byte) (snesPos & 0xFF), WriteType.OverworldMapPointer);
					ROM.Write((Constants.compressedAllMap32PointersHigh) + 1 + 3 * i, (byte) ((snesPos >> 8) & 0xFF), WriteType.OverworldMapPointer);
					ROM.Write((Constants.compressedAllMap32PointersHigh) + 2 + 3 * i, (byte) ((snesPos >> 16) & 0xFF), WriteType.OverworldMapPointer);

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
					/*
                    ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 0 + (int)(3 * i)] = (byte)(snesPos & 0xFF);
                    ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 1 + (int)(3 * i)] = (byte)((snesPos >> 8) & 0xFF);
                    ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);
                    */

					ROM.Write((Constants.compressedAllMap32PointersHigh) + 0 + 3 * i, (byte) (snesPos & 0xFF), WriteType.OverworldMapPointer);
					ROM.Write((Constants.compressedAllMap32PointersHigh) + 1 + 3 * i, (byte) ((snesPos >> 8) & 0xFF), WriteType.OverworldMapPointer);
					ROM.Write((Constants.compressedAllMap32PointersHigh) + 2 + 3 * i, (byte) ((snesPos >> 16) & 0xFF), WriteType.OverworldMapPointer);
				}
			}

			if (pos > 0x137FFF)
			{
				Console.WriteLine("Too many maps data " + pos.ToString("X6"));
				return true;
			}

			SaveLargeMaps(scene);

			return false;

			//Console.WriteLine("Map Pos Length: " + pos.ToString("X6"));
			//Save32Tiles();
		}

		/// <summary>
		/// Saves the overworld area layout (whether the area is big or small).
		/// </summary>
		/// <param name="scene"></param>
		/// <returns></returns>
		public bool SaveLargeMaps(SceneOW scene)
		{
			// TODO: these temp vars can be removed along with thier print once testing is done
			string parentMapLine = "";

			string[] parentMap = new string[8];

			Console.WriteLine("\n");
			List<byte> checkedMap = new List<byte>();

			for (int i = 0; i < 64; i++)
			{
				int yPos = i / 8;
				int xPos = i % 8;
				int parentyPos = scene.ow.allmaps[i].parent / 8;
				int parentxPos = scene.ow.allmaps[i].parent % 8;

				// Always write the map parent since it should not matter
				ROM.Write(Constants.overworldMapParentId + i, scene.ow.allmaps[i].parent);
				parentMapLine += scene.ow.allmaps[i].parent.ToString("X2").PadLeft(2, '0') + " ";

				if ((i + 1) % 8 == 0)
				{
					parentMap[((i + 1) / 8) - 1] = parentMapLine;

					parentMapLine = "";
				}

				if (checkedMap.Contains((byte) i))
				{
					continue; // Ignore that map we already checked it
				}

				if (scene.ow.allmaps[i].largeMap) // If it's large then save parent pos * 0x200 otherwise pos * 0x200
				{
					// Check 1
					ROM.Write(Constants.overworldMapSize + i, 0x20);
					ROM.Write(Constants.overworldMapSize + i + 1, 0x20);
					ROM.Write(Constants.overworldMapSize + i + 8, 0x20);
					ROM.Write(Constants.overworldMapSize + i + 9, 0x20);

					// Check 2
					ROM.Write(Constants.overworldMapSizeHighByte + i, 0x03);
					ROM.Write(Constants.overworldMapSizeHighByte + i + 1, 0x03);
					ROM.Write(Constants.overworldMapSizeHighByte + i + 8, 0x03);
					ROM.Write(Constants.overworldMapSizeHighByte + i + 9, 0x03);

					// Check 3
					ROM.Write(Constants.overworldScreenSize + i, 0x00);
					ROM.Write(Constants.overworldScreenSize + i + 64, 0x00);

					ROM.Write(Constants.overworldScreenSize + i + 1, 0x00);
					ROM.Write(Constants.overworldScreenSize + i + 1 + 64, 0x00);

					ROM.Write(Constants.overworldScreenSize + i + 8, 0x00);
					ROM.Write(Constants.overworldScreenSize + i + 8 + 64, 0x00);

					ROM.Write(Constants.overworldScreenSize + i + 9, 0x00);
					ROM.Write(Constants.overworldScreenSize + i + 9 + 64, 0x00);

					// Check 4
					ROM.Write(Constants.OverworldScreenSizeForLoading + i, 0x04);
					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 64, 0x04);
					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 128, 0x04);

					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 1, 0x04);
					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 1 + 64, 0x04);
					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 1 + 128, 0x04);

					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 8, 0x04);
					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 8 + 64, 0x04);
					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 8 + 128, 0x04);

					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 9, 0x04);
					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 9 + 64, 0x04);
					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 9 + 128, 0x04);

					// Check 5 and 6
					ROM.WriteShort(Constants.transition_target_north + (i * 2) + 2, (short) ((parentyPos * 0x200) - 0xE0)); // (short) is placed to reduce the int to 2 bytes.
					ROM.WriteShort(Constants.transition_target_west + (i * 2) + 2, (short) ((parentxPos * 0x200) - 0x100));

					ROM.WriteShort(Constants.transition_target_north + (i * 2) + 16, (short) ((parentyPos * 0x200) - 0xE0)); // (short) is placed to reduce the int to 2 bytes.
					ROM.WriteShort(Constants.transition_target_west + (i * 2) + 16, (short) ((parentxPos * 0x200) - 0x100));

					ROM.WriteShort(Constants.transition_target_north + (i * 2) + 18, (short) ((parentyPos * 0x200) - 0xE0)); // (short) is placed to reduce the int to 2 bytes.
					ROM.WriteShort(Constants.transition_target_west + (i * 2) + 18, (short) ((parentxPos * 0x200) - 0x100));

					// Check 7 and 8 
					ROM.WriteShort(Constants.overworldTransitionPositionX + (i * 2), (parentxPos * 0x200));
					ROM.WriteShort(Constants.overworldTransitionPositionY + (i * 2), (parentyPos * 0x200));

					ROM.WriteShort(Constants.overworldTransitionPositionX + (i * 2) + 2, (parentxPos * 0x200));
					ROM.WriteShort(Constants.overworldTransitionPositionY + (i * 2) + 2, (parentyPos * 0x200));

					ROM.WriteShort(Constants.overworldTransitionPositionX + (i * 2) + 16, (parentxPos * 0x200));
					ROM.WriteShort(Constants.overworldTransitionPositionY + (i * 2) + 16, (parentyPos * 0x200));

					ROM.WriteShort(Constants.overworldTransitionPositionX + (i * 2) + 18, (parentxPos * 0x200));
					ROM.WriteShort(Constants.overworldTransitionPositionY + (i * 2) + 18, (parentyPos * 0x200));

					// Check 9
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2), 0x0060); // Always 0x0060
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 2, 0x0060); // Always 0x0060

					// If parentX == 0 then lower submaps == 0x0060 too 
					if (parentxPos == 0)
					{
						ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 16, 0x0060);
						ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 18, 0x0060);
					}
					else
					{
						// Otherwise lower submaps == 0x1060
						ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 16, 0x1060);
						ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 18, 0x1060);
					}

					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 128, 0x0080); // Always 0x0080
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 2 + 128, 0x0080); // Always 0x0080
																												// Lower are always 8010
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 16 + 128, 0x1080); // Always 0x1080
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 18 + 128, 0x1080); // Always 0x1080


					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 256, 0x1800); // Always 0x1800
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 16 + 256, 0x1800); // Always 0x1800
																												 // Right side is always 1840
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 2 + 256, 0x1840); // Always 0x1840
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 18 + 256, 0x1840); // Always 0x1840


					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 384, 0x2000); // Always 0x2000
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 16 + 384, 0x2000); // Always 0x2000
																												 // Right side is always 0x2040
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 2 + 384, 0x2040); // Always 0x2000
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 18 + 384, 0x2040); // Always 0x2000


					checkedMap.Add((byte) i);
					checkedMap.Add((byte) (i + 1));
					checkedMap.Add((byte) (i + 8));
					checkedMap.Add((byte) (i + 9));
				}
				else
				{
					ROM.Write(Constants.overworldMapSize + i, 0x00);
					ROM.Write(Constants.overworldMapSizeHighByte + i, 0x01);

					ROM.Write(Constants.overworldScreenSize + i, 0x01);
					ROM.Write(Constants.overworldScreenSize + i + 64, 0x01);

					ROM.Write(Constants.OverworldScreenSizeForLoading + i, 0x02);
					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 64, 0x02);
					ROM.Write(Constants.OverworldScreenSizeForLoading + i + 128, 0x02);

					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2), 0x0060);
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 128, 0x0040);
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 256, 0x1800);
					ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen + (i * 2) + 384, 0x1000);

					ROM.WriteShort(Constants.transition_target_north + (i * 2), (short) ((yPos * 0x200) - 0xE0));
					ROM.WriteShort(Constants.transition_target_west + (i * 2), (short) ((xPos * 0x200) - 0x100));

					ROM.WriteShort(Constants.overworldTransitionPositionX + (i * 2), (xPos * 0x200));
					ROM.WriteShort(Constants.overworldTransitionPositionY + (i * 2), (yPos * 0x200));

					checkedMap.Add((byte) i);
				}
			}

			Console.WriteLine("Overworld parent map: \n");
			for (int i = 0; i < 8; i++)
			{
				Console.WriteLine(parentMap[i]);
			}
			Console.WriteLine("");

			return false;
		}

		public bool SaveGravestones(SceneOW scene)
		{
			for (int i = 0; i < 0x0F; i++)
			{
				ROM.WriteShort(Constants.GravesXTilePos + (i * 2), scene.ow.graves[i].xTilePos, WriteType.Gravestone);
				ROM.WriteShort(Constants.GravesYTilePos + (i * 2), scene.ow.graves[i].yTilePos, WriteType.Gravestone);
				ROM.WriteShort(Constants.GravesTilemapPos + (i * 2), scene.ow.graves[i].tilemapPos, WriteType.Gravestone);

				if (i == 0x0E)
				{
					ROM.WriteShort(Constants.GraveLinkSpecialStairs, scene.ow.graves[i].tilemapPos - 0x80, WriteType.Gravestone);
				}
				if (i == 0x0D)
				{
					ROM.WriteShort(Constants.GraveLinkSpecialHole, scene.ow.graves[i].tilemapPos - 0x80, WriteType.Gravestone);
				}
			}

			return false;
		}

		public bool SaveTitleScreen()
		{
			mainForm.screenEditor.Save();
			return false;
		}

		public bool SaveDungeonMaps()
		{
			return mainForm.screenEditor.dungmapSaveAllCurrentDungeon();
		}

		public bool SaveOverworldMiniMap()
		{
			mainForm.screenEditor.saveOverworldMap();
			return false;
		}

		public bool SaveTriforce()
		{
			mainForm.screenEditor.saveTriforce();
			return false;
		}

		// TODO : OW Message Load/Save
		// OW Musics Saves

		// Move ROOM FEATURES

		public bool saveRoomsHeaders2()
		{
			// Long??
			int headerPointer = getLongPointerSnestoPc(Constants.room_header_pointer);
			if (headerPointer < 0x100000)
			{
				MovePointer mp = new MovePointer();
				mp.ShowDialog();
				headerPointer = mp.address;

				int addr = Utils.PcToSnes(mp.address);
				ROM.WriteLong2(Constants.room_header_pointer, addr, true, "Header Pointers Location");
				ROM.Write2(Constants.room_header_pointers_bank, ROM.DATA2[Constants.room_header_pointer + 2], true, "Header Bank");
			}

			ROM.StartBlockLogWriting("Room Headers", headerPointer);
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				int newsptraddr = (Utils.PcToSnes((headerPointer + 640) + (i * 14)));
				ROM.WriteShort2((headerPointer) + (i * 2), newsptraddr, true, "Header " + i.ToString("D3") + " Pointer");
				saveHeader2((headerPointer + 640), i);
			}

			ROM.EndBlockLogWriting();

			ROM.StartBlockLogWriting("Rooms Messages", Constants.messages_id_dungeon);
			//ROM.SaveLogs();
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				ROM.WriteShort2(Constants.messages_id_dungeon + (i * 2), all_rooms[i].messageid, true, "Message Room ID : " + i.ToString("D3"));
			}

			ROM.EndBlockLogWriting();
			return false; // False = no error
		}

		public void saveHeader2(int pos, int i)
		{
			byte[] headerData = new byte[14]
			{
				(byte)((((byte)all_rooms[i].bg2 & 0x07) << 5) + ((int)all_rooms[i].collision << 2) + (all_rooms[i].light ? 1 : 0)),
				all_rooms[i].palette,
				all_rooms[i].blockset,
				all_rooms[i].spriteset,
				((byte)all_rooms[i].effect),
				((byte)all_rooms[i].tag1),
				((byte)all_rooms[i].tag2),
				(byte)((all_rooms[i].holewarp_plane) + (all_rooms[i].staircase1Plane << 2) + (all_rooms[i].staircase2Plane << 4) + (all_rooms[i].staircase3Plane << 6)),
				all_rooms[i].staircase4Plane,
				all_rooms[i].holewarp,
				all_rooms[i].staircase1,
				all_rooms[i].staircase2,
				all_rooms[i].staircase3,
				all_rooms[i].staircase4
			};

			ROM.Write2(pos + (i * 14), headerData, true, "Room Header " + i.ToString("D3"));
		}

		public bool saveallChests2()
		{
			int cpos = Utils.SnesToPc(ROM.ReadLong(Constants.chests_data_pointer1));
			int chestCount = 0;
			ROM.StartBlockLogWriting("Chests Data", cpos);
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				// Number of possible chests
				foreach (Chest c in all_rooms[i].chest_list)
				{
					ushort room_index = (ushort) i;
					if (c.bigChest)
					{
						room_index += 0x8000;
					}
					byte[] data = new byte[3]
					{
						(byte)(room_index & 0xFF),
						(byte)((room_index >> 8) & 0xFF),
						c.item,
					};
					ROM.Write2(cpos, data, true, "Chest Data " + i.ToString("D3"));
					cpos += 3;
					chestCount++;
				}
			}

			//Console.WriteLine("Nbr of chests : " + chestCount);
			if (chestCount > 168)
			{
				return true; // False = no error
			}

			ROM.EndBlockLogWriting();
			return false; // False = no error
		}

		public bool saveallSprites2(short[] listofrooms)
		{
			int spritePointer = (09 << 16) + (ROM.DATA2[Constants.rooms_sprite_pointer + 1] << 8) + (ROM.DATA2[Constants.rooms_sprite_pointer]);
			int spritePointerPC = Utils.SnesToPc(spritePointer);
			ROM.StartBlockLogWriting("Dungeon Sprites", spritePointerPC);
			byte[] sprites_buffer = new byte[Constants.sprites_end_data - Utils.SnesToPc(spritePointer)];

			// Empty room data = 0x280
			// Start of data = 0x282
			try
			{
				int pos = 0x282;
				// Set empty room
				sprites_buffer[0x280] = 0x00;
				sprites_buffer[0x281] = 0xFF;

				for (int i = 0; i < 320; i++)
				{
					if (listofrooms.Contains((short) i))
					{
						if (i >= Constants.NumberOfRooms || all_rooms[i].sprites.Count <= 0)
						{
							sprites_buffer[(i * 2)] = (byte) ((Utils.PcToSnes(Utils.SnesToPc(spritePointer + 0x280)) & 0xFF));
							sprites_buffer[(i * 2) + 1] = (byte) (((Utils.SnesToPc(spritePointer + 0x280)) >> 8) & 0xFF);
						}
						else
						{
							// Pointer: 
							sprites_buffer[(i * 2)] = (byte) ((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) & 0xFF));
							sprites_buffer[(i * 2) + 1] = (byte) ((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) >> 8) & 0xFF);

							sprites_buffer[pos] = (byte) (all_rooms[i].sortsprites ? 0x01 : 0x00); // Unknown byte??
							pos++;
							foreach (Sprite spr in all_rooms[i].sprites) // 3bytes
							{
								byte b1 = (byte) ((spr.layer << 7) + ((spr.subtype & 0x18) << 2) + spr.y);
								byte b2 = (byte) (((spr.subtype & 0x07) << 5) + spr.x);
								byte b3 = (spr.id);

								sprites_buffer[pos] = b1;
								pos++;
								sprites_buffer[pos] = b2;
								pos++;
								sprites_buffer[pos] = b3;
								pos++;

								// If current sprite hold a key then save it before 
								if (spr.keyDrop == 1)
								{
									byte bb1 = 0xFE;
									byte bb2 = 0x00;
									byte bb3 = 0xE4;

									sprites_buffer[pos] = bb1;
									pos++;
									sprites_buffer[pos] = bb2;
									pos++;
									sprites_buffer[pos] = bb3;
									pos++;
								}
								if (spr.keyDrop == 2)
								{
									byte bb1 = 0xFD;
									byte bb2 = 0x00;
									byte bb3 = 0xE4;

									sprites_buffer[pos] = bb1;
									pos++;
									sprites_buffer[pos] = bb2;
									pos++;
									sprites_buffer[pos] = bb3;
									pos++;
								}
							}

							sprites_buffer[pos] = 0xFF; // End of sprites
							pos++;
						}
					}
					else
					{

						if (i >= Constants.NumberOfRooms || DungeonsData.all_rooms_moved[i].sprites.Count <= 0)
						{
							sprites_buffer[(i * 2)] = (byte) ((Utils.PcToSnes(Utils.SnesToPc(spritePointer + 0x280)) & 0xFF));
							sprites_buffer[(i * 2) + 1] = (byte) (((Utils.SnesToPc(spritePointer + 0x280)) >> 8) & 0xFF);
						}
						else
						{
							// Pointer: 
							sprites_buffer[(i * 2)] = (byte) ((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) & 0xFF));
							sprites_buffer[(i * 2) + 1] = (byte) ((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) >> 8) & 0xFF);

							sprites_buffer[pos] = (byte) (DungeonsData.all_rooms_moved[i].sortsprites ? 0x01 : 0x00); // Unknown byte??
							pos++;

							foreach (Sprite spr in DungeonsData.all_rooms_moved[i].sprites) // 3bytes
							{
								byte b1 = (byte) ((spr.layer << 7) + ((spr.subtype & 0x18) << 2) + spr.y);
								byte b2 = (byte) (((spr.subtype & 0x07) << 5) + spr.x);
								byte b3 = (spr.id);

								sprites_buffer[pos] = b1;
								pos++;
								sprites_buffer[pos] = b2;
								pos++;
								sprites_buffer[pos] = b3;
								pos++;

								// If current sprite hold a key then save it before 
								if (spr.keyDrop == 1)
								{
									byte bb1 = 0xFE;
									byte bb2 = 0x00;
									byte bb3 = 0xE4;

									sprites_buffer[pos] = bb1;
									pos++;
									sprites_buffer[pos] = bb2;
									pos++;
									sprites_buffer[pos] = bb3;
									pos++;
								}

								if (spr.keyDrop == 2)
								{
									byte bb1 = 0xFD;
									byte bb2 = 0x00;
									byte bb3 = 0xE4;

									sprites_buffer[pos] = bb1;
									pos++;
									sprites_buffer[pos] = bb2;
									pos++;
									sprites_buffer[pos] = bb3;
									pos++;
								}
							}

							sprites_buffer[pos] = 0xFF; // End of sprites
							pos++;
						}
					}
				}

				ROM.EndBlockLogWriting();
				sprites_buffer.CopyTo(ROM.DATA2, spritePointerPC);
			}
			catch (Exception e)
			{
				return true;
			}

			return false; // False = no error
		}

		public bool saveAllObjects2(short[] listofrooms)
		{
			var section1Index = 0x50008; // 0x50000 to 0x5374F  // 53730
			var section2Index = 0xF878A; // 0xF878A to 0xFFFFF
			var section3Index = 0x1EB90; // 0x1EB90 to 0x1FFFF
			var section4Index = 0x1112C0; // If vanilla space is used use expanded region
			int section4Start = 0x1112C0;
			bool usedSection4 = false;
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
				if (listofrooms.Contains((short) i))
				{
					var roomBytes = all_rooms[i].getTilesBytes();
					int doorPos = roomBytes.Length - 2;

					if (roomBytes.Length < 10)
					{
						saveObjectBytes2(all_rooms[i].index, 0x50000, roomBytes, doorPos); // Empty room pointer
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
						saveObjectBytes2(all_rooms[i].index, section1Index, roomBytes, doorPos);
						section1Index += roomBytes.Length;
						continue;
					}
					else if (section2Index + roomBytes.Length <= 0xFFFFF) // 0xF878A to 0xFFFF7
					{
						// Write the room
						saveObjectBytes2(all_rooms[i].index, section2Index, roomBytes, doorPos);
						section2Index += roomBytes.Length;
						continue;
					}
					else if (section3Index + roomBytes.Length <= 0x1FFFF) // 0x1EB90 to 0x1FFFF
					{
						// Write the room
						saveObjectBytes2(all_rooms[i].index, section3Index, roomBytes, doorPos);
						section3Index += roomBytes.Length;
						continue;
					}
					else
					{
						// Ran out of space
						// Write the room
						//saveObjectBytes(i, section4Index, roomBytes);
						//section4Index += roomBytes.Length;

						saveObjectBytes2(all_rooms[i].index, section4Index, roomBytes, doorPos);
						section4Index += roomBytes.Length;
						usedSection4 = true;
						continue;

						// Move to EXPANDED region
						//Console.WriteLine("Room " + i + " no more space jump to 0x121210");
						//currentPos = 0x121210;
						//MessageBox.Show("We are running out space in the original portion of the ROM next data will be writed to : 0x121210");
					}
				}
				else
				{
					var roomBytes = DungeonsData.all_rooms_moved[i].getTilesBytes();
					int doorPos = roomBytes.Length - 2;

					if (roomBytes.Length < 10)
					{
						saveObjectBytes2(DungeonsData.all_rooms_moved[i].index, 0x50000, roomBytes, doorPos); // Empty room pointer
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
						saveObjectBytes2(DungeonsData.all_rooms_moved[i].index, section1Index, roomBytes, doorPos);
						section1Index += roomBytes.Length;
						continue;
					}
					else if (section2Index + roomBytes.Length <= 0xFFFFF) // 0xF878A to 0xFFFF7
					{
						// Write the room
						saveObjectBytes2(DungeonsData.all_rooms_moved[i].index, section2Index, roomBytes, doorPos);
						section2Index += roomBytes.Length;
						continue;
					}
					else if (section3Index + roomBytes.Length <= 0x1FFFF) // 0x1EB90 to 0x1FFFF
					{
						// Write the room
						saveObjectBytes2(DungeonsData.all_rooms_moved[i].index, section3Index, roomBytes, doorPos);
						section3Index += roomBytes.Length;
						continue;
					}
					else
					{
						// Ran out of space
						// Write the room
						//saveObjectBytes(i, section4Index, roomBytes);
						//section4Index += roomBytes.Length;

						saveObjectBytes2(DungeonsData.all_rooms_moved[i].index, section4Index, roomBytes, doorPos);
						section4Index += roomBytes.Length;
						usedSection4 = true;
						continue;

						// Move to EXPANDED region
						//Console.WriteLine("Room " + i + " no more space jump to 0x121210");
						//currentPos = 0x121210;
						//MessageBox.Show("We are running out space in the original portion of the ROM next data will be writed to : 0x121210");
					}
				}
			}

			if (usedSection4)
			{
				Console.WriteLine("Used section4 for tiles index at location : " + section4Start.ToString("X6") + "Length of :" + (section4Index - section4Start).ToString("X6"));
			}

			int objectPointer = Utils.SnesToPc(ROM.ReadLong(Constants.room_object_pointer));
			ROM.StartBlockLogWriting("Room And Doors Pointers", objectPointer);
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				ROM.WriteLong2(objectPointer + (i * 3), roomTilesPointers[i], true, "Room " + i.ToString("D3") + " Tiles Pointer");
				ROM.WriteLong2(Constants.doorPointers + (i * 3), roomDoorsPointers[i], true, "Room " + i.ToString("D3") + " Doors Pointer");
			}

			ROM.EndBlockLogWriting();

			return false; // False = no error
		}

		void saveObjectBytes2(int roomId, int position, byte[] bytes, int doorOffset)
		{
			roomTilesPointers[roomId] = Utils.PcToSnes(position);
			roomDoorsPointers[roomId] = Utils.PcToSnes(position + doorOffset);
			// Update the index

			ROM.StartBlockLogWriting("Room " + roomId.ToString("D3") + " Tiles Data", position);
			if (ROM.AdvancedLogs)
			{
				int bp = 2;
				ROM.romLog.Append(bytes[0].ToString("X2") + ", " + bytes[1].ToString("X2") + "// Room Layout and Floors\r\n");
				while (bp < bytes.Length)
				{
					for (int i = 0; i < 32; i++)
					{
						if (bp >= bytes.Length)
						{
							break;
						}

						ROM.romLog.Append(bytes[bp].ToString("X2") + " ");
						bp++;
					}

					ROM.romLog.Append("\r\n");
				}
			}

			Array.Copy(bytes, 0, ROM.DATA2, position, bytes.Length);
			ROM.EndBlockLogWriting();
		}

		public bool saveallPots2(short[] listofrooms)
		{
			int pos = Constants.items_data_start + 2; // Skip 2 FF FF that are empty pointer
			ROM.StartBlockLogWriting("Pots Items Data", pos);
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				if (listofrooms.Contains((short) i))
				{
					if (all_rooms[i].pot_items.Count == 0)
					{
						ROM.WriteShort2(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(Constants.items_data_start), true, "Items Pointer for Room " + i.ToString("D3"));
						continue;
					}

					// Pointer:
					ROM.WriteShort2(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(pos), true, "Items Pointer for Room " + i.ToString("D3"));
					for (int j = 0; j < all_rooms[i].pot_items.Count; j++)
					{
						if (all_rooms[i].pot_items[j].layer == 0)
						{
							all_rooms[i].pot_items[j].bg2 = false;
						}
						else
						{
							all_rooms[i].pot_items[j].bg2 = true;
						}

						int xy = (((all_rooms[i].pot_items[j].y * 64) + all_rooms[i].pot_items[j].x) << 1);

						byte[] data = new byte[3]
						{
						   (byte)(xy & 0xFF),
						   (byte)(((xy >> 8) & 0xFF) + (all_rooms[i].pot_items[j].bg2 ? 0x20 : 0x00)),
						   all_rooms[i].pot_items[j].id
						};

						ROM.Write2(pos, data, true, "Items Data for Room " + i.ToString("D3"));
						pos += 3;
					}

					ROM.WriteShort2(pos, 0xFFFF, true);
					pos += 2;
					if (pos > Constants.items_data_end)
					{
						ROM.SaveLogs();
						return true;
					}
				}
				else
				{
					if (DungeonsData.all_rooms_moved[i].pot_items.Count == 0)
					{
						ROM.WriteShort2(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(Constants.items_data_start), true, "Items Pointer for Room " + i.ToString("D3"));
						continue;
					}

					// Pointer:
					ROM.WriteShort2(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(pos), true, "Items Pointer for Room " + i.ToString("D3"));
					for (int j = 0; j < DungeonsData.all_rooms_moved[i].pot_items.Count; j++)
					{
						if (DungeonsData.all_rooms_moved[i].pot_items[j].layer == 0)
						{
							DungeonsData.all_rooms_moved[i].pot_items[j].bg2 = false;
						}
						else
						{
							DungeonsData.all_rooms_moved[i].pot_items[j].bg2 = true;
						}

						int xy = (((DungeonsData.all_rooms_moved[i].pot_items[j].y * 64) + DungeonsData.all_rooms_moved[i].pot_items[j].x) << 1);

						byte[] data = new byte[3]
						{
						   (byte)(xy & 0xFF),
						   (byte)(((xy >> 8) & 0xFF) + (DungeonsData.all_rooms_moved[i].pot_items[j].bg2 ? 0x20 : 0x00)),
						   DungeonsData.all_rooms_moved[i].pot_items[j].id
						};

						ROM.Write2(pos, data, true, "Items Data for Room " + i.ToString("D3"));
						pos += 3;
					}

					ROM.WriteShort2(pos, 0xFFFF, true);
					pos += 2;
					if (pos > Constants.items_data_end)
					{
						ROM.SaveLogs();
						return true;
					}
				}
			}

			ROM.EndBlockLogWriting();
			return false; // False = no error
		}

		public bool saveBlocks2()
		{
			// If we reach 0x80 size jump to pointer2 etc...
			int[] region = new int[4] { Constants.blocks_pointer1, Constants.blocks_pointer2, Constants.blocks_pointer3, Constants.blocks_pointer4 };
			int blockCount = 0;
			int r = 0;
			int pos = getLongPointerSnestoPc(region[r]);
			int count = 0;
			ROM.StartBlockLogWriting("Blocks Data", pos);

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				foreach (Room_Object o in all_rooms[i].tilesObjects)
				{
					if ((o.options & ObjectOption.Block) == ObjectOption.Block) // If we find a block save it
					{
						int xy = (((o.y * 64) + o.x) << 1);
						byte[] data = new byte[4]
						{
							(byte)((i & 0xFF)),
							(byte)(((i >> 8) & 0xFF)),
							(byte)(xy & 0xFF),
							((byte)(((xy >> 8) & 0x1F) + (o.layer * 0x20)))
						};

						ROM.Write2(pos, data, true, "Room:" + i.ToString("D3") + "X:" + o.x.ToString("D2") + " Y:" + o.x.ToString("D2") + " L:" + o.x.ToString("D2"));

						pos += 4;
						count += 4;
						if (count >= 0x80)
						{
							r++;
							pos = getLongPointerSnestoPc(region[r]);
							count = 0;
						}

						blockCount++;
					}
				}
			}

			if (blockCount > 99)
			{
				// Too many blocks
				return true; // False = no error
			}

			ROM.EndBlockLogWriting();

			/*
            if (b3 == 0xFF && b4 == 0xFF) 
            {
                break;
            }

            int address = ((b4 & 0x1F) << 8 | b3) >> 1;
            int px = address % 64;
            int py = address >> 6;
            Room_Object r = addObject(0x0E00, (byte)(px), (byte)(py), 0, (byte)((b4 & 0x20) >> 5));
            */

			return false; // False = no error
		}

		public bool saveTorches2()
		{
			int bytes_count = ROM.ReadShort(Constants.torches_length_pointer);

			int pos = Constants.torch_data;
			ROM.StartBlockLogWriting("Torches Data", pos);
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
							ROM.WriteShort2(pos, i, true, "Torches in room " + i.ToString("D3"));

							pos += 2;
							room = true;
						}

						int xy = (((o.y * 64) + o.x) << 1);
						byte b1 = (byte) (xy & 0xFF);
						ROM.Write2(pos, b1);
						pos++;
						byte b2 = (byte) ((xy >> 8) & 0xFF);

						if (o.layer == 1)
						{
							b2 |= 0x20;
						}

						b2 |= (byte) ((o.lit ? 1 : 0) << 7);
						ROM.Write2(pos, b2);
						pos++;
					}
				}

				if (room)
				{
					ROM.WriteShort2(pos, 0xFFFF);
					pos += 2;
				}
			}

			if ((pos - Constants.torch_data) > bytes_count)
			{
				return true;
			}
			else
			{
				short npos = (short) (pos - Constants.torch_data);
				ROM.WriteShort2(Constants.torches_length_pointer, npos);
			}

			ROM.EndBlockLogWriting();
			return false; // False = no error
		}
	}
}


