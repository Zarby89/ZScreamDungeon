using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using ZeldaFullEditor.Data.DungeonObjects;

namespace ZeldaFullEditor
{
	public partial class ZScreamer
	{
		public DungeonRoom[] all_rooms = DungeonsData.all_rooms; // TODO this is bad


		int[] roomTilesPointers = new int[Constants.NumberOfRooms];
		int[] roomDoorsPointers = new int[Constants.NumberOfRooms];
		int saddr = 0;

		byte[][] mapDatap1 = new byte[Constants.NumberOfOWMaps][];
		byte[][] mapDatap2 = new byte[Constants.NumberOfOWMaps][];
		int[] mapPointers1id = new int[Constants.NumberOfOWMaps];
		int[] mapPointers2id = new int[Constants.NumberOfOWMaps];

		int[] mapPointers1 = new int[Constants.NumberOfOWMaps];
		int[] mapPointers2 = new int[Constants.NumberOfOWMaps];
		
		public bool saveEntrances()
		{
			for (int i = 0; i < 0x84; i++)
			{
				DungeonsData.entrances[i].save(this, i);
			}

			for (int i = 0; i < 0x07; i++)
			{
				DungeonsData.starting_entrances[i].save(this, i);
			}

			return false;
		}

		public bool saveRoomsHeaders()
		{
			// Long??
			int headerPointer = SNESFunctions.SNEStoPC(ROM[Offsets.room_header_pointer, 3]);
			if (headerPointer < 0x100000)
			{
				MovePointer mp = new MovePointer();
				mp.ShowDialog();
				headerPointer = mp.address;

				ROM[Offsets.room_header_pointer, 3] = mp.address.PCtoSNES();
				ROM[Offsets.room_header_pointers_bank] = ROM[Offsets.room_header_pointer + 2];
			}

			// ROM.StartBlockLogWriting("Room Headers", headerPointer);
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				ROM[headerPointer + (i * 2), 2] = (headerPointer + 640 + (i * 14)).PCtoSNES();
				ROM.Write(headerPointer + 640 + (i * 14), all_rooms[i].HeaderData);
			}

			// ROM.EndBlockLogWriting();

			// ROM.StartBlockLogWriting("Rooms Messages", Offsets.messages_id_dungeon);
			//ROM.SaveLogs();
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				ROM[Offsets.messages_id_dungeon + (i * 2), 2] = all_rooms[i].MessageID;
			}

			// ROM.EndBlockLogWriting();
			return false; // False = no error
		}

		public bool saveBlocks()
		{
			// If we reach 0x80 size jump to pointer2 etc...
			int[] region = new int[4] { Offsets.blocks_pointer1, Offsets.blocks_pointer2, Offsets.blocks_pointer3, Offsets.blocks_pointer4 };
			int blockCount = 0;
			int r = 0;
			int pos = SNESFunctions.SNEStoPC(ROM[region[r], 3]);
			int count = 0;
			// ROM.StartBlockLogWriting("Blocks Data", pos);

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				foreach (DungeonBlock b in all_rooms[i].BlocksList)
				{
					int xy = ((b.Y * 64) + b.X) << 1;

					
					ROM.WriteContinuous(ref pos, 
						(byte) i,
						(byte) (i >> 8),
						(byte) xy,
						(byte) (((xy >> 8) & 0x1F) | (b.Layer << 5))
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

			return blockCount > 99;
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
			foreach (DungeonRoom room in all_rooms)
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

			string projectFilename = MainForm.projectFilename;

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
			int bytes_count = ROM[Offsets.torches_length_pointer, 2];

			int pos = Offsets.torch_data;
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

			if ((pos - Offsets.torch_data) > 0x120)
			{
				return true;
			}
			else
			{
				ROM[Offsets.torches_length_pointer, 2] = pos - Offsets.torch_data;
			}

			// ROM.EndBlockLogWriting();
			return false; // False = no error
		}

		public void saveHeader(int pos, int i)
		{
			
		}

		public bool saveAllPits()
		{
			int pitCount = ROM[Offsets.pit_count] / 2;
			int pitPointer = SNESFunctions.SNEStoPC(ROM[Offsets.pit_pointer, 3]);
			// ROM.StartBlockLogWriting("Pits Data", pitPointer);
			int pitCountNew = 0;

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				if (all_rooms[i].damagepit)
				{
					ROM[pitPointer, 2] = all_rooms[i].RoomID;
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


			// TODO write more things
			throw new NotImplementedException("Add rom positioning and pointer placement");
			int pos = 0;
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				ROM.WriteContinuous(ref pos, all_rooms[i].TileObjectData);
			}

			int objectPointer = SNESFunctions.SNEStoPC(ROM[Offsets.room_object_pointer, 3]);

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				ROM[objectPointer + (i * 3), 3] = roomTilesPointers[i];
				ROM[Offsets.doorPointers + (i * 3), 3] = roomDoorsPointers[i];
			}

			return false; // False = no error
		}

		public void savePalettes() // room settings floor1, floor2, blockset, spriteset, palette
		{
			// TODO: Add something here?
		}

		public bool saveallChests()
		{
			int pos = SNESFunctions.SNEStoPC(ROM[Offsets.chests_data_pointer1, 3]);
			int chestCount = 0;

			foreach (var room in all_rooms)
			{
				if (room.ChestList.Count > 0)
				{
					ROM.WriteContinuous(ref pos, room.ChestList.Data);
					chestCount += room.ChestList.Count;
				}
			}
			return chestCount > Constants.NumberOfChests;
		}

		public bool saveallPots()
		{
			int pos = Offsets.items_data_start + 2;

			int empty = Offsets.items_data_start.PCtoSNES();

			foreach (var room in all_rooms)
			{
				if (room.SecretsList.Count == 0)
				{
					ROM[Offsets.room_items_pointers + (room.RoomID * 2), size: 2] = empty;
					continue;
				}

				ROM[Offsets.room_items_pointers + (room.RoomID * 2), 2] = pos.PCtoSNES();
				ROM.WriteContinuous(ref pos, room.SecretsList.Data);
				ROM[pos++] = 0xFF;
				ROM[pos++] = 0xFF;
			}

			return pos > Offsets.items_data_end;
		}

		public bool saveallSprites()
		{
			int spritePointer = Constants.DungeonSpritePointers | ROM[Offsets.rooms_sprite_pointer];
			int pointerpointer = spritePointer.SNEStoPC();
			int datapointer = pointerpointer + 0x280;
			// ROM.StartBlockLogWriting("Dungeon Sprites", spritePointerPC);
			byte[] sprites_buffer = new byte[Offsets.sprites_end_data - spritePointer.SNEStoPC()];

			ushort emptyroom = (ushort) (datapointer.PCtoSNES() & 0xFFFF);

			ROM[datapointer++] = 0x00;
			ROM[datapointer++] = Constants.SpriteTerminator;

			foreach (var room in all_rooms)
			{
				if (room.SpritesList.Count == 0)
				{
					ROM[pointerpointer + 2 * room.RoomID, size: 2] = emptyroom;
					continue;
				}

				ROM[pointerpointer + 2 * room.RoomID, size: 2] = datapointer;

				ROM[datapointer++] = (byte) (room.MultiLayerOAM ? 1 : 0);
				ROM.WriteContinuous(ref datapointer, room.SpritesList.Data);
				ROM[datapointer++] = Constants.SpriteTerminator;
			}

			return datapointer > Offsets.sprites_end_data;
		}

		public bool saveOWExits()
		{
			// ROM.StartBlockLogWriting("OW Exits", Constants.OWExitMapId);

			for (int i = 0, j = 0; i < 78; i++, j += 2)
			{
				ROM[Offsets.OWExitMapId + i] = OverworldManager.allexits[i].mapId;
				ROM[Offsets.OWExitXScroll + j, 2] = OverworldManager.allexits[i].xScroll;
				ROM[Offsets.OWExitYScroll + j, 2] = OverworldManager.allexits[i].yScroll;
				ROM[Offsets.OWExitXCamera + j, 2] = OverworldManager.allexits[i].cameraX;
				ROM[Offsets.OWExitYCamera + j, 2] = OverworldManager.allexits[i].cameraY;
				ROM[Offsets.OWExitVram + j, 2] = OverworldManager.allexits[i].vramLocation;
				ROM[Offsets.OWExitRoomId + j, 2] = OverworldManager.allexits[i].roomId;
				ROM[Offsets.OWExitXPlayer + j, 2] = OverworldManager.allexits[i].playerX;
				ROM[Offsets.OWExitYPlayer + j, 2] = OverworldManager.allexits[i].playerY;
				ROM[Offsets.OWExitDoorType1 + j, 2] = OverworldManager.allexits[i].doorType1;
				ROM[Offsets.OWExitDoorType2 + j, 2] = OverworldManager.allexits[i].doorType2;
			}

			// ROM.EndBlockLogWriting();
			return false;
		}

		public bool saveOWEntrances()
		{
			// ROM.StartBlockLogWriting("OW Entrances/Holes", Constants.OWEntranceMap);

			for (int i = 0, j = 0; i < OverworldManager.allentrances.Length; i++, j += 2)
			{
				ROM[Offsets.OWEntranceMap + j, 2] = OverworldManager.allentrances[i].mapId;
				ROM[Offsets.OWEntrancePos + j, 2] = OverworldManager.allentrances[i].mapPos;
				ROM[Offsets.OWEntranceEntranceId + i] = OverworldManager.allentrances[i].entranceId;
			}

			for (int i = 0, j = 0; i < OverworldManager.allholes.Length; i++, j += 2)
			{
				ROM[Offsets.OWHoleArea + j, 2] = OverworldManager.allholes[i].mapId;
				ROM[Offsets.OWHolePos + j, 2] = OverworldManager.allholes[i].mapPos - 0x400;
				ROM[Offsets.OWHoleEntrance + i] = OverworldManager.allholes[i].entranceId;
			}

			// ROM.EndBlockLogWriting();
			//WriteLog("Overworld Entrances data loaded properly", Color.Green);
			return false;
		}

		public bool saveOWItems()
		{
			// ROM.StartBlockLogWriting("Items OW DATA & Pointers", Offsets.overworldItemsPointers);
			List<RoomPotSaveEditor>[] roomItems = new List<RoomPotSaveEditor>[128];

			for (int i = 0; i < 128; i++)
			{
				roomItems[i] = new List<RoomPotSaveEditor>();
				foreach (RoomPotSaveEditor item in OverworldManager.allitems)
				{
					if (item.roomMapId == i)
					{
						roomItems[i].Add(item);
					}
				}
			}

			int dataPos = Offsets.overworldItemsPointers + 0x100;

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

				ROM[Offsets.overworldItemsPointers + (i * 2), 2] = itemPtrs[i].PCtoSNES();
			}

			if (dataPos > Offsets.overworldItemsEndData)
			{
				return true;
			}

			// ROM.EndBlockLogWriting();

			return false;
		}

		public bool SaveOWSprites()
		{
			// ROM.StartBlockLogWriting("Sprites OW DATA & Pointers", Offsets.overworldSpritesBegining);
			int[] sprPointers = new int[Constants.NumberOfOWSprites];
			int?[] sprPointersReused = new int?[Constants.NumberOfOWSprites];
			List<OverworldSprite>[] allspr = new List<OverworldSprite>[Constants.NumberOfOWSprites];

			for (int j = 0; j < Constants.NumberOfOWSprites; j++)
			{
				sprPointersReused[j] = null;
				allspr[j] = new List<Sprite>();
			}

			for (int i = 0; i < Constants.NumberOfOWSprites; i++) // For each pointers
			{
				if (i < 64) // LW[0]
				{
					Sprite[] sprArray = OverworldManager.allsprites[0].Where(s => s.mapid == i).ToArray();
					foreach (Sprite spr in sprArray)
					{
						allspr[i].Add(spr);
					}
				}
				else if (i < 208) // LW & DW[1]
				{
					Sprite[] sprArray = OverworldManager.allsprites[1].Where(s => s.mapid == (i - 64)).ToArray();
					foreach (Sprite spr in sprArray)
					{
						allspr[i].Add(spr);
					}
				}
				else if (i < Constants.NumberOfOWSprites) // LW[2]
				{
					Sprite[] sprArray = OverworldManager.allsprites[2].Where(s => s.mapid == (i - 208)).ToArray();
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

				ROM[Offsets.OverworldSpritesTableState0 + (i * 2), 2] = sprPointers[i].PCtoSNES();
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
				ROM[Offsets.OWExitMapIdWhirlpool + j, 2] = OverworldManager.allWhirlpools[i].mapId;
				ROM[Offsets.OWExitXScrollWhirlpool + j, 2] = OverworldManager.allWhirlpools[i].xScroll;
				ROM[Offsets.OWExitYScrollWhirlpool + j, 2] = OverworldManager.allWhirlpools[i].yScroll;
				ROM[Offsets.OWExitXCameraWhirlpool + j, 2] = OverworldManager.allWhirlpools[i].cameraX;
				ROM[Offsets.OWExitYCameraWhirlpool + j, 2] = OverworldManager.allWhirlpools[i].cameraY;
				ROM[Offsets.OWExitVramWhirlpool + j, 2] = OverworldManager.allWhirlpools[i].vramLocation;
				ROM[Offsets.OWExitXPlayerWhirlpool + j, 2] = OverworldManager.allWhirlpools[i].playerX;
				ROM[Offsets.OWExitYPlayerWhirlpool + j, 2] = OverworldManager.allWhirlpools[i].playerY;

				if (i > 8)
				{
					ROM[Offsets.OWWhirlpoolPosition + ((i - 9) * 2), 2] = OverworldManager.allWhirlpools[i].whirlpoolPos;
				}
			}

			// ROM.EndBlockLogWriting();
			return false;
		}

		public bool saveMapProperties()
		{
			// ROM.StartBlockLogWriting("Map Properties", Offsets.mapGfx);

			for (int i = 0; i < 64; i++)
			{
				ROM[Offsets.mapGfx + i] = OverworldManager.allmaps[i].gfx;
				ROM[Offsets.overworldSpriteset + i] = OverworldManager.allmaps[i].sprgfx[0];
				ROM[Offsets.overworldSpriteset + 64 + i] = OverworldManager.allmaps[i].sprgfx[1];
				ROM[Offsets.overworldSpriteset + 128 + i] = OverworldManager.allmaps[i].sprgfx[2];
				ROM[Offsets.overworldMapPalette + i] = OverworldManager.allmaps[i].palette;
				ROM[Offsets.overworldSpritePalette + i] = OverworldManager.allmaps[i].sprpalette[0];
				ROM[Offsets.overworldSpritePalette + 64 + i] = OverworldManager.allmaps[i].sprpalette[1];
				ROM[Offsets.overworldSpritePalette + 128 + i] = OverworldManager.allmaps[i].sprpalette[2];
			}

			for (int i = 64; i < 128; i++)
			{
				ROM[Offsets.mapGfx + i] = OverworldManager.allmaps[i].gfx;
				ROM[Offsets.overworldSpriteset + 128 + i] = OverworldManager.allmaps[i].sprgfx[0];
				ROM[Offsets.overworldSpriteset + 128 + i] = OverworldManager.allmaps[i].sprgfx[1];
				ROM[Offsets.overworldSpriteset + 128 + i] = OverworldManager.allmaps[i].sprgfx[2];
				ROM[Offsets.overworldMapPalette + i] = OverworldManager.allmaps[i].palette;
				ROM[Offsets.overworldSpritePalette + 128 + i] = OverworldManager.allmaps[i].sprpalette[0];
				ROM[Offsets.overworldSpritePalette + 128 + i] = OverworldManager.allmaps[i].sprpalette[1];
				ROM[Offsets.overworldSpritePalette + 128 + i] = OverworldManager.allmaps[i].sprpalette[2];
			}

			// ROM.EndBlockLogWriting();
			return false;
		}

		public bool saveMapOverlays()
		{
			// ROM.StartBlockLogWriting("Map Overlays", Offsets.mapGfx);

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

				for (int t = 0; t < OverworldManager.alloverlays[i].tilesData.Count; t++)
				{
					ushort addr = (ushort) ((OverworldManager.alloverlays[i].tilesData[t].x * 2) + (OverworldManager.alloverlays[i].tilesData[t].y * 128) + 0x2000);
					// LDA TileID : STA $addr
					// A9 (LDA #$)
					// A2 (LDX #$)
					// 8D (STA $xxxx)

					// LDA :
					ROM[pos++, 2] = 0xA9;
					ROM[pos, 2] = OverworldManager.alloverlays[i].tilesData[t].tileId;
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
			// ROM.StartBlockLogWriting("Overworld Tiles Types", Offsets.overworldTilesType);
			for (int i = 0; i < 0x200; i++)
			{
				ROM[Offsets.overworldTilesType + i] = OverworldManager.allTilesTypes[i];
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
			// ROM.StartBlockLogWriting("Overworld Messages IDs", Offsets.overworldMessages);

			for (int i = 0; i < 128; i++)
			{
				ROM[Offsets.overworldMessages + (i * 2), 2] = OverworldManager.allmaps[i].messageID;
			}

			// ROM.EndBlockLogWriting();

			return false;
		}

		public bool saveOverworldMusics()
		{
			// ROM.StartBlockLogWriting("Overworld Musics IDs", Offsets.overworldMessages);

			for (int i = 0; i < 64; i++)
			{
				ROM[Offsets.overworldMusicBegining + i] = OverworldManager.allmaps[i].musics[0];
				ROM[Offsets.overworldMusicZelda + i] = OverworldManager.allmaps[i].musics[1];
				ROM[Offsets.overworldMusicMasterSword + i] = OverworldManager.allmaps[i].musics[2];
				ROM[Offsets.overworldMusicAgahim + i] = OverworldManager.allmaps[i].musics[3];

			}

			for (int i = 0; i < 64; i++)
			{
				ROM[Offsets.overworldMusicDW + i] = OverworldManager.allmaps[i].musics[0];
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
						singlemap1[npos] = (byte) OverworldManager.t32[npos + (i * 256)];
						singlemap2[npos] = (byte) (OverworldManager.t32[npos + (i * 256)] >> 8);
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
					ROM[Offsets.compressedAllMap32PointersLow + (3 * i), 3] = snesPos;

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
					ROM[Offsets.compressedAllMap32PointersLow + (3 * i), 3] = snesPos;
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

					ROM[Offsets.compressedAllMap32PointersHigh + (3 * i), 3] = snesPos;
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
					ROM[Offsets.compressedAllMap32PointersHigh + (3 * i), 3] = snesPos;
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
				int parentyPos = OverworldManager.allmaps[i].parent / 8;
				int parentxPos = OverworldManager.allmaps[i].parent % 8;

				// Always write the map parent since it should not matter
				ROM[Offsets.overworldMapParentId + i] = OverworldManager.allmaps[i].parent;
				parentMapLine += OverworldManager.allmaps[i].parent.ToString("X2").PadLeft(2, '0') + " ";

				if ((i + 1) % 8 == 0)
				{
					parentMap[((i + 1) / 8) - 1] = parentMapLine;

					parentMapLine = "";
				}

				if (checkedMap.Contains((byte) i))
				{
					continue; // Ignore that map we already checked it
				}

				if (OverworldManager.allmaps[i].largeMap) // If it's large then save parent pos * 0x200 otherwise pos * 0x200
				{
					// Check 1
					ROM[Offsets.overworldMapSize + i] = 0x20;
					ROM[Offsets.overworldMapSize + i + 1] = 0x20;
					ROM[Offsets.overworldMapSize + i + 8] = 0x20;
					ROM[Offsets.overworldMapSize + i + 9] = 0x20;

					// Check 2
					ROM[Offsets.overworldMapSizeHighByte + i] = 0x03;
					ROM[Offsets.overworldMapSizeHighByte + i + 1] = 0x03;
					ROM[Offsets.overworldMapSizeHighByte + i + 8] = 0x03;
					ROM[Offsets.overworldMapSizeHighByte + i + 9] = 0x03;

					// Check 3
					ROM[Offsets.overworldScreenSize + i] = 0x00;
					ROM[Offsets.overworldScreenSize + i + 64] = 0x00;

					ROM[Offsets.overworldScreenSize + i + 1] = 0x00;
					ROM[Offsets.overworldScreenSize + i + 1 + 64] = 0x00;
						  
					ROM[Offsets.overworldScreenSize + i + 8] = 0x00;
					ROM[Offsets.overworldScreenSize + i + 8 + 64] = 0x00;
						  
					ROM[Offsets.overworldScreenSize + i + 9] = 0x00;
					ROM[Offsets.overworldScreenSize + i + 9 + 64] = 0x00;

					// Check 4
					ROM[Offsets.OverworldScreenSizeForLoading + i] = 0x04;
					ROM[Offsets.OverworldScreenSizeForLoading + i + 64] = 0x04;
					ROM[Offsets.OverworldScreenSizeForLoading + i + 128] = 0x04;

					ROM[Offsets.OverworldScreenSizeForLoading + i + 1] = 0x04;
					ROM[Offsets.OverworldScreenSizeForLoading + i + 1 + 64] = 0x04;
					ROM[Offsets.OverworldScreenSizeForLoading + i + 1 + 128] = 0x04;

					ROM[Offsets.OverworldScreenSizeForLoading + i + 8] = 0x04;
					ROM[Offsets.OverworldScreenSizeForLoading + i + 8 + 64] = 0x04;
					ROM[Offsets.OverworldScreenSizeForLoading + i + 8 + 128] = 0x04;

					ROM[Offsets.OverworldScreenSizeForLoading + i + 9] = 0x04;
					ROM[Offsets.OverworldScreenSizeForLoading + i + 9 + 64] = 0x04;
					ROM[Offsets.OverworldScreenSizeForLoading + i + 9 + 128] = 0x04;

					// Check 5 and 6
					ROM[Offsets.transition_target_north + (i * 2) + 2, 2] = ((parentyPos * 0x200) - 0xE0); // (short) is placed to reduce the int to 2 bytes.
					ROM[Offsets.transition_target_west + (i * 2) + 2, 2] = ((parentxPos * 0x200) - 0x100);

					ROM[Offsets.transition_target_north + (i * 2) + 16, 2] = ((parentyPos * 0x200) - 0xE0); // (short) is placed to reduce the int to 2 bytes.
					ROM[Offsets.transition_target_west + (i * 2) + 16, 2] = ((parentxPos * 0x200) - 0x100);

					ROM[Offsets.transition_target_north + (i * 2) + 18, 2] = ((parentyPos * 0x200) - 0xE0); // (short) is placed to reduce the int to 2 bytes.
					ROM[Offsets.transition_target_west + (i * 2) + 18, 2] = ((parentxPos * 0x200) - 0x100);

					// Check 7 and 8 
					ROM[Offsets.overworldTransitionPositionX + (i * 2), 2] = (parentxPos * 0x200);
					ROM[Offsets.overworldTransitionPositionY + (i * 2), 2] = (parentyPos * 0x200);

					ROM[Offsets.overworldTransitionPositionX + (i * 2) + 2, 2] = (parentxPos * 0x200);
					ROM[Offsets.overworldTransitionPositionY + (i * 2) + 2, 2] = (parentyPos * 0x200);

					ROM[Offsets.overworldTransitionPositionX + (i * 2) + 16, 2] = (parentxPos * 0x200);
					ROM[Offsets.overworldTransitionPositionY + (i * 2) + 16, 2] = (parentyPos * 0x200);

					ROM[Offsets.overworldTransitionPositionX + (i * 2) + 18, 2] = (parentxPos * 0x200);
					ROM[Offsets.overworldTransitionPositionY + (i * 2) + 18, 2] = (parentyPos * 0x200);

					// Check 9
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2), 2] = 0x0060; // Always 0x0060
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 2, 2] = 0x0060; // Always 0x0060

					// If parentX == 0 then lower submaps == 0x0060 too 
					if (parentxPos == 0)
					{
						ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16, 2] = 0x0060;
						ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18, 2] = 0x0060;
					}
					else
					{
						// Otherwise lower submaps == 0x1060
						ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16, 2] = 0x1060;
						ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18, 2] = 0x1060;
					}

					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 128, 2] = 0x0080; // Always 0x0080
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 2 + 128, 2] = 0x0080; // Always 0x0080
																												// Lower are always 8010
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16 + 128, 2] = 0x1080; // Always 0x1080
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18 + 128, 2] = 0x1080; // Always 0x1080


					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 256, 2] = 0x1800; // Always 0x1800
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16 + 256, 2] = 0x1800; // Always 0x1800
																												 // Right side is always 1840
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 2 + 256, 2] = 0x1840; // Always 0x1840
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18 + 256, 2] = 0x1840; // Always 0x1840


					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 384, 2] = 0x2000; // Always 0x2000
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16 + 384, 2] = 0x2000; // Always 0x2000
																												 // Right side is always 0x2040
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 2 + 384, 2] = 0x2040; // Always 0x2000
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18 + 384, 2] = 0x2040; // Always 0x2000


					checkedMap.Add((byte) i);
					checkedMap.Add((byte) (i + 1));
					checkedMap.Add((byte) (i + 8));
					checkedMap.Add((byte) (i + 9));
				}
				else
				{
					ROM[Offsets.overworldMapSize + i] = 0x00;
					ROM[Offsets.overworldMapSizeHighByte + i] = 0x01;
						  
					ROM[Offsets.overworldScreenSize + i] = 0x01;
					ROM[Offsets.overworldScreenSize + i + 64] = 0x01;
						  
					ROM[Offsets.OverworldScreenSizeForLoading + i] = 0x02;
					ROM[Offsets.OverworldScreenSizeForLoading + i + 64] = 0x02;
					ROM[Offsets.OverworldScreenSizeForLoading + i + 128] = 0x02;

					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2), 2] = 0x0060;
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 128, 2] = 0x0040;
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 256, 2] = 0x1800;
					ROM[Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 384, 2] = 0x1000;

					ROM[Offsets.transition_target_north + (i * 2), 2] = (ushort) ((yPos * 0x200) - 0xE0);
					ROM[Offsets.transition_target_west + (i * 2), 2] = (ushort) ((xPos * 0x200) - 0x100);

					ROM[Offsets.overworldTransitionPositionX + (i * 2), 2] = (xPos * 0x200);
					ROM[Offsets.overworldTransitionPositionY + (i * 2), 2] = (yPos * 0x200);

					checkedMap.Add((byte) i);
				}
			}

			return false;
		}

		public bool SaveGravestones()
		{
			for (int i = 0; i < 0x0F; i++)
			{
				ROM[Offsets.GravesXTilePos + (i * 2), 2] = OverworldManager.graves[i].xTilePos;
				ROM[Offsets.GravesYTilePos + (i * 2), 2] = OverworldManager.graves[i].yTilePos;
				ROM[Offsets.GravesTilemapPos + (i * 2), 2] = OverworldManager.graves[i].tilemapPos;

				if (i == 0x0E)
				{
					ROM[Offsets.GraveLinkSpecialStairs, 2] = OverworldManager.graves[i].tilemapPos - 0x80;
				}
				if (i == 0x0D)
				{
					ROM[Offsets.GraveLinkSpecialHole, 2] = OverworldManager.graves[i].tilemapPos - 0x80;
				}
			}

			return false;
		}

		public bool SaveTitleScreen()
		{
			return MainForm.screenEditor.Save();
		}

		public bool SaveDungeonMaps()
		{
			return MainForm.screenEditor.dungmapSaveAllCurrentDungeon();
		}

		public bool SaveOverworldMiniMap()
		{
			return MainForm.screenEditor.saveOverworldMap();
		}

		public bool SaveTriforce()
		{
			return MainForm.screenEditor.saveTriforce();
		}

		// TODO : OW Message Load/Save
		// OW Musics Saves

		// Move ROOM FEATURES
	}
}


