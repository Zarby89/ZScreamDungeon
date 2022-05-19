namespace ZeldaFullEditor
{
	public partial class ZScreamer
	{
		public DungeonRoom[] all_rooms = new DungeonRoom[Constants.NumberOfRooms];
		public Entrance[] entrances = new Entrance[Constants.NumberOfEntrances];
		public Entrance[] starting_entrances = new Entrance[0x07];
		public List<DungeonRoom>[] undoRoom = new List<DungeonRoom>[Constants.NumberOfRooms];
		public List<DungeonRoom>[] redoRoom = new List<DungeonRoom>[Constants.NumberOfRooms];

		public void saveEntrances()
		{
			for (int i = 0; i < 0x84; i++)
			{
				entrances[i].save(this, i);
			}

			for (int i = 0; i < 0x07; i++)
			{
				starting_entrances[i].save(this, i);
			}
		}

		public void saveRoomsHeaders()
		{
			int headerPointer = ROM.Read24(Offsets.room_header_pointer).SNEStoPC();
			if (headerPointer < 0x100000)
			{
				MovePointer mp = new MovePointer();
				mp.ShowDialog();
				headerPointer = mp.address;

				ROM.Write24(Offsets.room_header_pointer, mp.address.PCtoSNES());
				ROM[Offsets.room_header_pointers_bank] = ROM[Offsets.room_header_pointer + 2];
			}

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				ROM.Write16(headerPointer + (i * 2), (headerPointer + 640 + (i * 14)).PCtoSNES());
				ROM.Write(headerPointer + 640 + (i * 14), all_rooms[i].GetHeaderData());
				ROM.Write16(Offsets.messages_id_dungeon + (i * 2), all_rooms[i].MessageID);
			}
		}

		public void saveBlocks()
		{
			// If we reach 0x80 size jump to pointer2 etc...
			int[] region = new int[4] { Offsets.blocks_pointer1, Offsets.blocks_pointer2, Offsets.blocks_pointer3, Offsets.blocks_pointer4 };
			int blockCount = 0;
			int r = 0;
			int pos = ROM.Read24(region[r]).SNEStoPC();
			int count = 0;

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				foreach (DungeonBlock b in all_rooms[i].BlocksList)
				{
					int xy = ((b.GridY * 64) + b.GridX) << 1;

					ROM.WriteContinuous(ref pos,
						(byte) i,
						(byte) (i >> 8),
						(byte) xy,
						(byte) (((xy >> 8) & 0x1F) | (((int) b.Layer) << 5))
					);

					count += 4;
					if (count >= 0x80)
					{
						r++;
						pos = ROM.Read24(region[r]).SNEStoPC();
						count = 0;
					}

					blockCount++;
				}
			}

			if (blockCount > 99)
			{
				throw new ZeldaException("There are too many pushable blocks.");
			}
		}

		public void saveCustomCollision()
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

			foreach (DungeonRoom room in all_rooms)
			{
				// @zarby: for each room -> ROM.WriteLong(0x100000), Utils.PcToSnes(ptrsCounter))
				//         write pointers where data start + previous room data length

				// If there is triangle in the room, write the room pointer, otherwise wrtie 000000
				if (room.CheckForNonemptyCollision())
				{
					ROM.Write24(room_pointer, data_pointer.PCtoSNES());
					ROM.WriteContinuous(ref data_pointer, room.GetCollisionData());
				}
				else
				{
					ROM.Write24(room_pointer, 0x000000);
				}

				room_pointer += 3;

			}

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
		}

		public void saveTorches()
		{
			int pos = Offsets.torch_data;
			int end = pos + ROM.Read16(Offsets.torches_length_pointer);

			foreach (DungeonRoom r in all_rooms)
			{
				if (r.TorchList.Count > 0)
				{
					ROM.WriteContinuous(ref pos, r.GetTorchesData());
				}
			}

			if (pos > end)
			{
				throw new ZeldaException("There are too many torches.");
			}

			while (pos < end)
			{
				ROM[pos++] = 0xFF;
			}
		}

		public void saveAllPits()
		{
			int pitCount = ROM[Offsets.pit_count] / 2;
			int pitPointer = ROM.Read24(Offsets.pit_pointer).SNEStoPC();
			int pitCountNew = 0;

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				if (all_rooms[i].HasDamagingPits)
				{
					ROM.Write16(pitPointer, all_rooms[i].RoomID);
					pitPointer += 2;
					pitCountNew++;
				}
			}

			if (pitCountNew > pitCount)
			{
				throw new ZeldaException("There are too many rooms that have pit damage.");
			}
		}

		// TODO magic numbers
		public void saveAllObjects()
		{
			var roomsaves = new List<RoomSaveEntry>();

			foreach (var room in all_rooms)
			{
				roomsaves.Add(new RoomSaveEntry(room));
			}

			roomsaves.Sort((r1, r2) => r1.Length - r2.Length);

			var section1saves = new List<RoomSaveEntry>();
			var section2saves = new List<RoomSaveEntry>();
			var section3saves = new List<RoomSaveEntry>();
			var section4saves = new List<RoomSaveEntry>();

			int section1Index = 0x50008; // 0x50000 to 0x5374F  // 53730
			int section2Index = 0xF878A; // 0xF878A to 0xFFFFF
			int section3Index = 0x1EB90; // 0x1EB90 to 0x1FFFF
			int section4Index = 0x1112C0; // If vanilla space is used use expanded region

			int i = 0;

			int size = 0;
			while ((size + roomsaves[i].Length) < 0x374F)
			{
				section1saves.Add(roomsaves[i]);
				size += roomsaves[i++].Length;
			}

			size = 0;
			while ((size + roomsaves[i].Length) < 0x7875)
			{
				section2saves.Add(roomsaves[i]);
				size += roomsaves[i++].Length;
			}

			size = 0;
			while ((size + roomsaves[i].Length) < 0x146F)
			{
				section3saves.Add(roomsaves[i]);
				size += roomsaves[i++].Length;
			}

			size = 0;
			while ((size + roomsaves[i].Length) < 0xFFFF)
			{
				section4saves.Add(roomsaves[i]);
				size += roomsaves[i++].Length;
			}

			if (i < all_rooms.Length)
			{
				throw new ZeldaException("There were too many objects to save every room.");
			}

			int objectPointer = ROM.Read24(Offsets.room_object_pointer).SNEStoPC();

			foreach (var room in section1saves)
			{
				ROM.Write24(objectPointer + room.TableIndex, section1Index);
				ROM.Write24(Offsets.doorPointers + room.TableIndex, section1Index + room.DoorOffset);
				ROM.WriteContinuous(ref section1Index, room.Data);

			}
			foreach (var room in section2saves)
			{
				ROM.Write24(objectPointer + room.TableIndex, section2Index);
				ROM.Write24(Offsets.doorPointers + room.TableIndex, section2Index + room.DoorOffset);
				ROM.WriteContinuous(ref section2Index, room.Data);
			}

			foreach (var room in section3saves)
			{
				ROM.Write24(objectPointer + room.TableIndex, section3Index);
				ROM.Write24(Offsets.doorPointers + room.TableIndex, section3Index + room.DoorOffset);
				ROM.WriteContinuous(ref section3Index, room.Data);
			}

			foreach (var room in section4saves)
			{
				ROM.Write24(objectPointer + room.TableIndex, section4Index);
				ROM.Write24(Offsets.doorPointers + room.TableIndex, section4Index + room.DoorOffset);
				ROM.WriteContinuous(ref section4Index, room.Data);
			}
		}

		public void SaveUnderworldChests()
		{
			int pos = ROM.Read24(Offsets.chests_data_pointer1).SNEStoPC();
			int chestCount = 0;

			foreach (var room in all_rooms)
			{
				if (room.ChestList.Count > 0)
				{
					ROM.WriteContinuous(ref pos, room.ChestList.GetByteData());
					chestCount += room.ChestList.Count;
				}
			}
			if (chestCount > Constants.NumberOfChests)
			{
				throw new ZeldaException("There are too many chest items.");
			}
		}

		public void SaveUnderworldSecrets()
		{
			int pos = Offsets.items_data_start + 2;

			int empty = Offsets.items_data_start.PCtoSNES();

			foreach (var room in all_rooms)
			{
				if (room.SecretsList.Count == 0)
				{
					ROM.Write16(Offsets.room_items_pointers + (room.RoomID * 2), empty);
					continue;
				}

				ROM.Write16(Offsets.room_items_pointers + (room.RoomID * 2), pos.PCtoSNES());
				ROM.WriteContinuous(ref pos, room.SecretsList.GetByteData());
				ROM.Write16Continuous(ref pos, 0xFFFF);
			}

			if (pos > Offsets.items_data_end)
			{
				throw new ZeldaException("There are too many underworld pot items.");
			}
		}

		public void SaveUnderworldSprites()
		{
			int spritePointer = Constants.DungeonSpritePointers | ROM[Offsets.rooms_sprite_pointer];
			int pointerpointer = spritePointer.SNEStoPC();
			int datapointer = pointerpointer + 0x280;

			ushort emptyroom = (ushort) (datapointer.PCtoSNES() & 0xFFFF);

			ROM[datapointer++] = 0x00;
			ROM[datapointer++] = Constants.SpriteSentinel;

			foreach (var room in all_rooms)
			{
				if (room.SpritesList.Count == 0)
				{
					ROM.Write16Continuous(ref pointerpointer, emptyroom);
					continue;
				}

				ROM.Write16Continuous(ref pointerpointer, datapointer);

				ROM[datapointer++] = (byte) (room.MultiLayerOAM ? 1 : 0);
				ROM.WriteContinuous(ref datapointer, room.SpritesList.GetByteData());
				ROM[datapointer++] = Constants.SpriteSentinel;
			}

			if (datapointer > Offsets.sprites_end_data)
			{
				throw new ZeldaException("There are too many underworld sprites!");
			}
		}

		public void SaveOverworldExits()
		{
			for (int i = 0, j = 0; i < 78; i++, j += 2)
			{
				ROM[Offsets.OWExitMapId + i] = OverworldManager.allexits[i].MapID;
				ROM.Write16(Offsets.OWExitXScroll + j, OverworldManager.allexits[i].ScrollX);
				ROM.Write16(Offsets.OWExitYScroll + j, OverworldManager.allexits[i].ScrollY);
				ROM.Write16(Offsets.OWExitXCamera + j, OverworldManager.allexits[i].CameraX);
				ROM.Write16(Offsets.OWExitYCamera + j, OverworldManager.allexits[i].CameraY);
				ROM.Write16(Offsets.OWExitVram + j, OverworldManager.allexits[i].VRAMBase);
				ROM.Write16(Offsets.OWExitRoomId + j, OverworldManager.allexits[i].TargetRoomID);
				ROM.Write16(Offsets.OWExitXPlayer + j, OverworldManager.allexits[i].GlobalX);
				ROM.Write16(Offsets.OWExitYPlayer + j, OverworldManager.allexits[i].GlobalY);
				ROM.Write16(Offsets.OWExitDoorType1 + j, OverworldManager.allexits[i].doorType1);
				ROM.Write16(Offsets.OWExitDoorType2 + j, OverworldManager.allexits[i].doorType2);
			}
		}

		public void SaveOverworldEntrances()
		{
			for (int i = 0, j = 0; i < OverworldManager.allentrances.Length; i++, j += 2)
			{
				ROM.Write16(Offsets.OWEntranceMap + j, OverworldManager.allentrances[i].MapID);
				ROM.Write16(Offsets.OWEntrancePos + j, OverworldManager.allentrances[i].Map16Index);
				ROM[Offsets.OWEntranceEntranceId + i] = OverworldManager.allentrances[i].TargetEntranceID;
			}

			for (int i = 0, j = 0; i < OverworldManager.allholes.Length; i++, j += 2)
			{
				ROM.Write16(Offsets.OWHoleArea + j, OverworldManager.allholes[i].MapID);
				ROM.Write16(Offsets.OWHolePos + j, OverworldManager.allholes[i].Map16Index - 0x400);
				ROM[Offsets.OWHoleEntrance + i] = OverworldManager.allholes[i].TargetEntranceID;
			}
		}

		public void SaveOverworldSecrets()
		{
			List<OverworldSecret>[] screenItems = new List<OverworldSecret>[128];

			for (int i = 0; i < 128; i++)
			{
				screenItems[i] = new List<OverworldSecret>();
			}

			foreach (var item in OverworldManager.allitems)
			{
				screenItems[item.MapID].Add(item);
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
					if (screenItems[i].Count == 0)
					{
						itemPtrsReuse[i] = -2;
						break;
					}
					if (CompareOverworldArrays(screenItems[i], screenItems[ci]))
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
					foreach (var item in screenItems[i])
					{
						ushort mapPos = (ushort) (((item.MapY << 6) + item.MapX) << 1);
						ROM.WriteContinuous(ref dataPos,
							(byte) (mapPos >> 8),
							(byte) mapPos,
							item.ID);
					}

					emptyPtr = dataPos;
					ROM.Write16Continuous(ref dataPos, 0xFFFF);
				}
				else if (itemPtrsReuse[i] == -2)
				{
					itemPtrs[i] = emptyPtr;
				}
				else
				{
					itemPtrs[i] = itemPtrs[itemPtrsReuse[i]];
				}

				ROM.Write16(Offsets.overworldItemsPointers + (i * 2), itemPtrs[i].PCtoSNES());
			}

			if (dataPos > Offsets.overworldItemsEndData)
			{
				throw new ZeldaException("Overworld secrets: there are too many!");
			}
		}

		public void SaveOverworldSprites()
		{
			int[] sprPointers = new int[Constants.NumberOfOWSprites];
			int?[] sprPointersReused = new int?[Constants.NumberOfOWSprites];
			List<OverworldSprite>[] allspr = new List<OverworldSprite>[Constants.NumberOfOWSprites];

			for (int j = 0; j < Constants.NumberOfOWSprites; j++)
			{
				allspr[j] = new List<OverworldSprite>();
			}

			for (int i = 0; i < Constants.NumberOfOWSprites; i++) // For each pointers
			{
				IEnumerable<OverworldSprite> temp = i switch
				{
					< 64 => OverworldManager.allsprites[0].Where(s => s.MapID == i),
					>= 64 and < 208 => OverworldManager.allsprites[1].Where(s => s.MapID == (i - 64)),
					>= 208 and < Constants.NumberOfOWSprites => OverworldManager.allsprites[2].Where(s => s.MapID == (i - 208)),
					_ => null
				};

				if (temp is not null)
				{
					foreach (var spr in temp)
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
					if (CompareOverworldArrays(allspr[i], allspr[ci]))
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
					foreach (var spr in allspr[i])
					{
						ROM.WriteContinuous(ref dataPos, spr.GetByteData());
					}

					ROM[dataPos++] = Constants.SpriteSentinel;
				}
				else
				{
					sprPointers[i] = sprPointers[(int) sprPointersReused[i]];
				}

				ROM.Write16(Offsets.OverworldSpritesTableState0 + (i * 2), sprPointers[i].PCtoSNES());
			}

			if (dataPos > 0x4D62E)
			{
				throw new ZeldaException("There are too many overworld sprites.");
			}
		}

		// TODO is probably bad and we should probably use IComparable to sort the lists firsts
		public static bool CompareOverworldArrays<T>(List<T> list1, List<T> list2) where T : IEquatable<T>
		{
			if (list1.Count != list2.Count)
			{
				return false;
			}

			bool match;

			foreach (var i in list1)
			{
				match = false;

				foreach (var j in list2)
				{
					if (i.Equals(j))
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

		public void saveOWTransports()
		{
			for (int i = 0, j = 0; i < 0x11; i++, j += 2)
			{
				ROM.Write16(Offsets.OWExitMapIdWhirlpool + j, OverworldManager.AllTransports[i].MapID);
				ROM.Write16(Offsets.OWExitXScrollWhirlpool + j, OverworldManager.AllTransports[i].ScrollX);
				ROM.Write16(Offsets.OWExitYScrollWhirlpool + j, OverworldManager.AllTransports[i].ScrollY);
				ROM.Write16(Offsets.OWExitXCameraWhirlpool + j, OverworldManager.AllTransports[i].CameraX);
				ROM.Write16(Offsets.OWExitYCameraWhirlpool + j, OverworldManager.AllTransports[i].CameraY);
				ROM.Write16(Offsets.OWExitVramWhirlpool + j, OverworldManager.AllTransports[i].VRAMBase);
				ROM.Write16(Offsets.OWExitXPlayerWhirlpool + j, OverworldManager.AllTransports[i].GlobalX);
				ROM.Write16(Offsets.OWExitYPlayerWhirlpool + j, OverworldManager.AllTransports[i].GlobalY);

				if (i > 8)
				{
					ROM.Write16(Offsets.OWWhirlpoolPosition + ((i - 9) * 2), OverworldManager.AllTransports[i].whirlpoolPos);
				}
			}
		}

		public void saveMapProperties()
		{
			for (int i = 0; i < 128; i++)
			{
				var map = OverworldManager.allmaps[i];
				ROM[Offsets.OverworldIDToMainGFXSet + i] = map.Tileset;
				ROM[Offsets.overworldMapPalette + i] = map.ScreenPalette;

				if (map.World == Worldiness.LightWorld)
				{
					ROM[Offsets.overworldSpriteset + i] = map.State0SpriteGraphics;
					ROM[Offsets.overworldSpriteset + 64 + i] = map.State2SpriteGraphics;
					ROM[Offsets.overworldSpriteset + 128 + i] = map.State3SpriteGraphics;

					ROM[Offsets.overworldSpritePalette + i] = map.State0SpritePalette;
					ROM[Offsets.overworldSpritePalette + 64 + i] = map.State2SpritePalette;
					ROM[Offsets.overworldSpritePalette + 128 + i] = map.State3SpritePalette;
				}
				else
				{
					ROM[Offsets.overworldSpriteset + 128 + i] = map.State0SpriteGraphics;
					ROM[Offsets.overworldSpritePalette + 128 + i] = map.State0SpritePalette;
				}
			}
		}

		public void saveMapOverlays()
		{
			// TODO fucking stupid, make this an asm file
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
			ROM.Write24(0x77657 + 10, snesptrstart);
			ROM.Write24(0x77657 + 16, snesptrstart + 2);

			int peaAddr = (0x77657 + 27).PCtoSNES();

			ROM.Write16(0x77657 + 23, peaAddr);

			// TODO : Optimize that routine to be smaller

			// 0x058000
			int pos = 0x120000;
			int ptrPos = 0x77657 + 32;
			for (int i = 0; i < 128; i++)
			{
				int snesaddr = pos.PCtoSNES();
				ROM.Write24(ptrPos, snesaddr);
				ptrPos += 3;

				for (int t = 0; t < OverworldManager.alloverlays[i].tilesData.Count; t++)
				{
					ushort addr = (ushort) ((OverworldManager.alloverlays[i].tilesData[t].MapX * 2) + (OverworldManager.alloverlays[i].tilesData[t].MapY * 128) + 0x2000);
					// LDA TileID : STA $addr
					// A9 (LDA #$)
					// A2 (LDX #$)
					// 8D (STA $xxxx)

					// LDA :
					ROM[pos++] = 0xA9;
					ROM.Write16(pos, OverworldManager.alloverlays[i].tilesData[t].Tile16ID);
					pos += 2;

					// STA : 
					ROM[pos++] = 0x8D;
					ROM.Write16(pos, addr);
					pos += 2;
				}

				ROM[pos++] = 0x6B;
			}
		}

		public void saveOverworldTilesType()
		{
			for (int i = 0; i < 0x200; i++)
			{
				ROM[Offsets.overworldTilesType + i] = OverworldManager.allTilesTypes[i];
			}
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

		public void SaveOverworldMessageIDs()
		{
			for (int i = 0; i < 128; i++)
			{
				ROM.Write16(Offsets.overworldMessages + (i * 2), OverworldManager.allmaps[i].MessageID);
			}
		}

		public void saveOverworldMusics()
		{
			for (int i = 0; i < 64; i++)
			{
				ROM[Offsets.overworldMusicBegining + i] = OverworldManager.allmaps[i].musics[0];
				ROM[Offsets.overworldMusicZelda + i] = OverworldManager.allmaps[i].musics[1];
				ROM[Offsets.overworldMusicMasterSword + i] = OverworldManager.allmaps[i].musics[2];
				ROM[Offsets.overworldMusicAgahim + i] = OverworldManager.allmaps[i].musics[3];
				ROM[Offsets.overworldMusicDW + i] = OverworldManager.allmaps[i].musics[0];
			}
		}

		public static bool CompareByteArray(byte[] array1, byte[] array2)
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

		public void SaveOverworldScreens()
		{

			var mapPointers1 = new int[Constants.NumberOfOWMaps];
			var mapPointers2 = new int[Constants.NumberOfOWMaps];

			var mapPointers1id = new int[Constants.NumberOfOWMaps];
			var mapPointers2id = new int[Constants.NumberOfOWMaps];

			var mapDatap1 = new byte[Constants.NumberOfOWMaps][];
			var mapDatap2 = new byte[Constants.NumberOfOWMaps][];

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
				else if ((pos + a.Length) >= 0x6411F && (pos + a.Length) <= 0x70000)
				{
					pos = 0x130000; // 0x0F8780;
				}

				for (int j = 0; j < i; j++)
				{
					if (CompareByteArray(a, mapDatap1[j]))
					{
						mapPointers1id[i] = j;
					}
					if (CompareByteArray(b, mapDatap2[j]))
					{
						mapPointers2id[i] = j;
					}
				}

				// Before Saving it to the ROM check if it match an existing map already
				int snesPos;
				if (mapPointers1id[i] == -1)
				{
					a.CopyTo(mapDatap1[i], 0);
					snesPos = pos.PCtoSNES();
					mapPointers1[i] = snesPos;

					ROM.WriteContinuous(ref pos, a);
				}
				else
				{
					snesPos = mapPointers1[mapPointers1id[i]];
				}

				ROM.Write24(Offsets.compressedAllMap32PointersLow + (3 * i), snesPos);

				if ((pos + b.Length) >= 0x5FE70 && (pos + b.Length) <= 0x60000)
				{
					pos = 0x60000;
				}
				else if ((pos + b.Length) >= 0x6411F && (pos + b.Length) <= 0x70000)
				{
					pos = 0x130000;
				}

				// Map2
				if (mapPointers2id[i] == -1)
				{
					b.CopyTo(mapDatap2[i], 0);
					snesPos = pos.PCtoSNES();
					mapPointers2[i] = snesPos;

					ROM.WriteContinuous(ref pos, b);
				}
				else
				{
					snesPos = mapPointers2[mapPointers2id[i]];
				}
				ROM.Write24(Offsets.compressedAllMap32PointersHigh + (3 * i), snesPos);
			}

			if (pos > 0x137FFF)
			{
				throw new ZeldaException("Too much map data: {pos:X6}!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
			}

			SaveLargeMaps();
		}

		/// <summary>
		/// Saves the overworld area layout (whether the area is big or small).
		/// </summary>
		public void SaveLargeMaps()
		{
			// TODO: these temp vars can be removed along with thier print once testing is done
			//string parentMapLine = "";
			//string[] parentMap = new string[8];

			List<byte> checkedMap = new List<byte>();

			for (int i = 0; i < 64; i++)
			{
				int yPos = i / 8;
				int xPos = i % 8;
				int parentyPos = OverworldManager.allmaps[i].ParentMapID / 8;
				int parentxPos = OverworldManager.allmaps[i].ParentMapID % 8;

				// Always write the map parent since it should not matter
				ROM[Offsets.overworldMapParentId + i] = OverworldManager.allmaps[i].ParentMapID;
				//parentMapLine += OverworldManager.allmaps[i].parent.ToString("X2").PadLeft(2, '0') + " ";

				//if ((i + 1) % 8 == 0)
				//{
				//	parentMap[((i + 1) / 8) - 1] = parentMapLine;
				//
				//	parentMapLine = "";
				//}

				if (checkedMap.Contains((byte) i))
				{
					continue; // Ignore that map we already checked it
				}

				if (OverworldManager.allmaps[i].IsPartOfLargeMap) // If it's large then save parent pos * 0x200 otherwise pos * 0x200
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
					ROM.Write16(Offsets.transition_target_north + (i * 2) + 2, (parentyPos * 0x200) - 0xE0);
					ROM.Write16(Offsets.transition_target_west + (i * 2) + 2, (parentxPos * 0x200) - 0x100);

					ROM.Write16(Offsets.transition_target_north + (i * 2) + 16, (parentyPos * 0x200) - 0xE0);
					ROM.Write16(Offsets.transition_target_west + (i * 2) + 16, (parentxPos * 0x200) - 0x100);

					ROM.Write16(Offsets.transition_target_north + (i * 2) + 18, (parentyPos * 0x200) - 0xE0);
					ROM.Write16(Offsets.transition_target_west + (i * 2) + 18, (parentxPos * 0x200) - 0x100);

					// Check 7 and 8 
					ROM.Write16(Offsets.overworldTransitionPositionX + (i * 2), parentxPos * 0x200);
					ROM.Write16(Offsets.overworldTransitionPositionY + (i * 2), parentyPos * 0x200);

					ROM.Write16(Offsets.overworldTransitionPositionX + (i * 2) + 2, parentxPos * 0x200);
					ROM.Write16(Offsets.overworldTransitionPositionY + (i * 2) + 2, parentyPos * 0x200);

					ROM.Write16(Offsets.overworldTransitionPositionX + (i * 2) + 16, parentxPos * 0x200);
					ROM.Write16(Offsets.overworldTransitionPositionY + (i * 2) + 16, parentyPos * 0x200);

					ROM.Write16(Offsets.overworldTransitionPositionX + (i * 2) + 18, parentxPos * 0x200);
					ROM.Write16(Offsets.overworldTransitionPositionY + (i * 2) + 18, parentyPos * 0x200);

					// Check 9
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2), 0x0060);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 2, 0x0060);

					int lowmap = (parentxPos == 0) ? 0x0060 : 0x1060;

					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16, lowmap);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18, lowmap);

					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 128, 0x0080);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 2 + 128, 0x0080);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16 + 128, 0x1080);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18 + 128, 0x1080);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 256, 0x1800);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16 + 256, 0x1800);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 2 + 256, 0x1840);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18 + 256, 0x1840);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 384, 0x2000);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 16 + 384, 0x2000);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 2 + 384, 0x2040);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 18 + 384, 0x2040);


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

					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2), 0x0060);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 128, 0x0040);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 256, 0x1800);
					ROM.Write16(Offsets.OverworldScreenTileMapChangeByScreen + (i * 2) + 384, 0x1000);

					ROM.Write16(Offsets.transition_target_north + (i * 2), (yPos * 0x200) - 0xE0);
					ROM.Write16(Offsets.transition_target_west + (i * 2), (xPos * 0x200) - 0x100);

					ROM.Write16(Offsets.overworldTransitionPositionX + (i * 2), xPos * 0x200);
					ROM.Write16(Offsets.overworldTransitionPositionY + (i * 2), yPos * 0x200);

					checkedMap.Add((byte) i);
				}
			}
		}

		public void SaveGravestones()
		{
			for (int i = 0; i < 0x0F; i++)
			{
				ROM.Write16(Offsets.GravesXTilePos + (i * 2), OverworldManager.graves[i].xTilePos);
				ROM.Write16(Offsets.GravesYTilePos + (i * 2), OverworldManager.graves[i].yTilePos);
				ROM.Write16(Offsets.GravesTilemapPos + (i * 2), OverworldManager.graves[i].tilemapPos);

				if (i == 0x0E)
				{
					ROM.Write16(Offsets.GraveLinkSpecialStairs, OverworldManager.graves[i].tilemapPos - 0x80);
				}
				else if (i == 0x0D)
				{
					ROM.Write16(Offsets.GraveLinkSpecialHole, OverworldManager.graves[i].tilemapPos - 0x80);
				}
			}
		}

		// TODO these should all be elsewhere
		public void SaveTitleScreen()
		{
			ZGUI.screenEditor.Save();
		}

		public void SaveDungeonMaps()
		{
			ZGUI.screenEditor.dungmapSaveAllCurrentDungeon();
		}

		public void SaveOverworldMiniMap()
		{
			ZGUI.screenEditor.saveOverworldMap();
		}

		public void SaveTriforce()
		{
			ZGUI.screenEditor.saveTriforce();
		}

		// TODO : OW Message Load/Save
		// OW Musics Saves

		// Move ROOM FEATURES

		public SpriteProperties[] SpriteProps { get; private set; }
		public void SaveSpriteProps()
		{
			int i = 0;
			foreach (var sprite in SpriteProps)
			{
				ROM[Offsets.SpriteOAMHarmData + i] = sprite.DataOAMHarm;
				ROM[Offsets.SpriteHealthData + i] = sprite.Health;
				ROM[Offsets.SpriteBumpData + i] = sprite.DataBump;
				ROM[Offsets.SpriteOAMPropData + i] = sprite.DataOAMProp;
				ROM[Offsets.SpriteHitboxData + i] = sprite.DataHitbox;
				ROM[Offsets.SpriteTileIntData + i] = sprite.DataTileInteraction;
				ROM[Offsets.SpritePrizePackData + i] = sprite.DataPrizePack;
				ROM[Offsets.SpriteDeflectionData + i] = sprite.DataDeflection;

				i++;
			}
		}
	}
}


