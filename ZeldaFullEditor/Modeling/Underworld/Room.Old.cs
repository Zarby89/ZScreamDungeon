namespace ZeldaFullEditor.Modeling.Underworld
{
	//	[Serializable]
	//	public class Room : ICloneable
	//	{
	//		//List<SpriteName> stringtodraw = new List<SpriteName>();
	//		public int index;
	//		int header_location;
	//		public bool has_changed = false;
	//		public string name;
	//
	//		public bool light;
	//		public byte[] blocks = new byte[16];
	//		public List<Chest> chest_list = new List<Chest>();
	//		public List<Room_Object> tilesObjects = new List<Room_Object>();
	//		public byte[] collisionMap = new byte[4096];
	//		public List<Sprite> sprites = new List<Sprite>();
	//		public List<PotItem> pot_items = new List<PotItem>();
	//		public List<object> selectedObject = new List<object>();
	//		public List<Room_Object> tilesLayoutObjects = new List<Room_Object>();
	//		public bool objectInitialized = false;
	//		public bool onlyLayout = false;
	//
	//		public Room(ZScreamer zs, int index, string fromExported = "")
	//		{
	//			ZS = zs;
	//			this.fromExported = fromExported;
	//			this.index = index;
	//			loadHeader();
	//			loadLayoutObjects();
	//
	//			if (fromExported != "")
	//			{
	//
	//				if (File.Exists(fromExported + "\\ExportedRooms\\" + "room" + index.ToString("D3") + ".bin"))
	//				{
	//					using (FileStream fs = new FileStream(fromExported + "\\ExportedRooms\\" + "room" + index.ToString("D3") + ".bin", FileMode.Open, FileAccess.Read))
	//					{
	//						byte[] data = new byte[fs.Length];
	//						fs.Read(data, 0, data.Length);
	//						fs.Close();
	//						loadTilesObjectsFromArray(data);
	//					}
	//				}
	//				else
	//				{
	//					loadTilesObjects();
	//				}
	//			}
	//			else
	//			{
	//				loadTilesObjects();
	//			}
	//
	//			for (int i = 0; i < Constants.TilesPerTilemap; i++)
	//			{
	//				collisionMap[i] = 0xFF; // Null byte
	//			}
	//
	//			addSprites();
	//			addBlocks();
	//			addTorches();
	//			setObjectsRoom();
	//			addPotsItems();
	//			isdamagePit();
	//			this.name = ROMStructure.roomsNames[index];
	//			messageid = ZS.ROM[ZS.Offsets.messages_id_dungeon + (index * 2), 2];
	//
	//			LoadCustomCollisionFromRom();
	//		}
	//
	//
	//		public void reloadLayout()
	//		{
	//			tilesLayoutObjects.Clear();
	//			loadLayoutObjects();
	//
	//			foreach (Room_Object o in tilesLayoutObjects)
	//			{
	//				o.setRoom(this);
	//			}
	//		}
	//
	//		public void isdamagePit()
	//		{
	//			int pitCount = ZS.ROM[ZS.Offsets.pit_count] / 2;
	//			int pitPointer = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.pit_pointer, 3]);
	//
	//			for (int i = 0; i < pitCount; i++)
	//			{
	//				if (ZS.ROM[pitPointer + (i * 2), 2] == index)
	//				{
	//					damagepit = true;
	//					return;
	//				}
	//			}
	//		}
	//
	//
	//		// @author: scawful
	//		// @brief: Data structure for storing rectangles of tile data 
	//		[Serializable]
	//		public struct CollisionRectangle
	//		{
	//			public byte width;
	//			public byte height;
	//			public ushort index_data;
	//			public ushort[] tile_data;
	//
	//			public CollisionRectangle(byte w, byte h, ushort id, ushort[] td)
	//			{
	//				this.width = w;
	//				this.height = h;
	//				this.index_data = id;
	//				this.tile_data = td;
	//			}
	//
	//			public override string ToString()
	//			{
	//				StringBuilder temp = new StringBuilder();
	//				temp.Append($"[width: {width} | height: {height} | index_data: {index_data} | TileData: " );
	//
	//				foreach (ushort u in tile_data)
	//				{
	//					temp.Append(u);
	//					temp.Append("; ");
	//				}
	//
	//				temp.Remove(temp.Length - 2, 2);
	//
	//				temp.Append("]");
	//
	//				return temp.ToString();
	//			}
	//		}
	//
	//		// @author: scawful
	//		// @brief: Creates a list of valid rectangles from user inputted collision 
	//		public void loadCollisionLayout(bool output = false)
	//		{
	//			Dictionary<int, bool> collision_validity = new Dictionary<int, bool>();
	//
	//			for (int i = 0; i < collisionMap.Length; ++i)
	//			{
	//				collision_validity[i] = false;
	//			}
	//
	//			int rectangle_index = 0;
	//			for (int i = 0; i < collisionMap.Length; ++i)
	//			{
	//				if (collisionMap[i] != 0xFF && !collision_validity[i])
	//				{
	//					int rectangle_width = 1;
	//					int rectangle_height = 1;
	//					bool found_blank = false;
	//
	//					if (collisionMap[i + 1] == 0xFF && collisionMap[i + 64] == 0xFF)
	//					{
	//						ushort[] new_tile_data = { collisionMap[i] };
	//						collision_validity[i] = true;
	//						collision_rectangles.Add(new CollisionRectangle(1, 1, (ushort) i, new_tile_data));
	//					}
	//					else
	//					{
	//						while (!found_blank)
	//						{
	//							if (collisionMap[i + rectangle_width] != 0xFF)
	//							{
	//								rectangle_width++;
	//							}
	//							else
	//							{
	//								found_blank = true;
	//							}
	//						}
	//
	//						found_blank = false;
	//						while (!found_blank)
	//						{
	//							if ((i + (rectangle_height * 64)) < 4096)
	//							{
	//								if (collisionMap[i + (rectangle_height * 64)] != 0xFF)
	//								{
	//									rectangle_height++;
	//								}
	//								else
	//								{
	//									found_blank = true;
	//								}
	//							}
	//							else
	//							{
	//								found_blank = true;
	//							}
	//						}
	//
	//						/* 
	//                        //removed as it is unnecessary and causes errors when you have a rectangle with different tile data in it
	//                        bool discrepancy = false;
	//                        byte rectangle_type = collisionMap[i];
	//
	//                        for (int y = 0; y < rectangle_height; ++y)
	//                        {
	//                            for (int x = 0; x < rectangle_width; ++x)
	//                            {
	//                                if (collisionMap[i + (x + (y * 64))] != rectangle_type && !discrepancy)
	//                                {
	//                                    if (rectangle_width > x)
	//                                    {
	//                                        rectangle_height = y;
	//                                        discrepancy = true;
	//                                        break;
	//                                    }
	//                                }
	//                            }
	//                        }
	//                        */
	//
	//						List<ushort> new_tile_data = new List<ushort>();
	//						for (int y = 0; y < rectangle_height; ++y)
	//						{
	//							for (int x = 0; x < rectangle_width; ++x)
	//							{
	//								new_tile_data.Add(collisionMap[i + (x + (y * 64))]);
	//								collision_validity[i + (x + (y * 64))] = true;
	//							}
	//						}
	//
	//						ushort[] _new_tile_data = new_tile_data.ToArray();
	//						collision_rectangles.Add(new CollisionRectangle((byte) rectangle_width, (byte) rectangle_height, (ushort) i, _new_tile_data));
	//					}
	//				}
	//			}
	//
	//			/* 
	//            upper bound 
	//            512 pixels/8px per tile, so 64
	//            a full room would be dw $0000 : db 64, 64
	//            followed by 64x64 bytes
	//            then FFFF
	//            */
	//
	//			/*
	//            put $F0F0 then put 2 byte index and the 1 byte of data
	//            index is just Y*64+X
	//            +$1000 if lower layer
	//
	//            only the index and tokens are 16 bit
	//            everything else, width, height, data, are 8 bit 
	//            */
	//		}
	//
	//		/// <summary>
	//		/// clears the list of valid rectangles from user inputted collision 
	//		/// </summary>
	//		public void ClearCollisionLayout()
	//		{
	//			collision_rectangles.Clear();
	//		}
	//
	//		/// <summary>
	//		/// Reads the custom collsion data from the ROM and adds it to the collisionMap for the room
	//		/// </summary>
	//		public void LoadCustomCollisionFromRom()
	//		{
	//			int room_pointer = 0x128090 + (3 * index);
	//
	//			int data_pointer = ZS.ROM[room_pointer, 3];
	//
	//			if (data_pointer >= 0x128450)
	//			{
	//				while (ZS.ROM[data_pointer.SNEStoPC(), 2] != ((ushort) 0xFFFF))
	//				{
	//					int offset = ZS.ROM[data_pointer.SNEStoPC(), 2];
	//					data_pointer += 2;
	//
	//					int width = ZS.ROM[data_pointer.SNEStoPC()];
	//					int height = ZS.ROM[data_pointer.SNEStoPC()];
	//					data_pointer += 2;
	//
	//					for (int i = 0; i < height; i++)
	//					{
	//						for (int j = 0; j < width; j++)
	//						{
	//							collisionMap[(offset + j + (i * 64))] = ZS.ROM[data_pointer.SNEStoPC()];
	//							data_pointer++;
	//						}
	//					}
	//				}
	//			}
	//		}
	//
	//		public void loadChests(ref List<ChestData> chests_in_room)
	//		{
	//			int cpos = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.chests_data_pointer1, 3]);
	//			int clength = ZS.ROM[ZS.Offsets.chests_length_pointer, 2];
	//
	//			for (int i = 0; i < clength; i++)
	//			{
	//				if ((ZS.ROM[cpos + (i * 3), 2] & 0x7FFF) == index)
	//				{
	//					//There's a chest in that room !
	//					// HACK: need to make this bigger than ushort.max to avoid confusion between int and ushort when using dynamic
	//					bool big = IntFunctions.BitIsOn(ZS.ROM[cpos + (i * 3), 2], 0x18000);  
	//
	//					chests_in_room.Add(new ChestData(ZS.ROM[cpos + (i * 3) + 2], big));
	//				}
	//			}
	//		}
	//
	//		public void loadTilesObjects(bool floor = true)
	//		{
	//			// Adddress of the room objects
	//			int objectPointer = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.room_object_pointer, 3]);
	//			int room_address = objectPointer + (index * 3);
	//
	//			int objects_location = SNESFunctions.SNEStoPC(ZS.ROM[room_address, 3]);
	//
	//			LoadAllRoomObjects(ZS.ROM.DataStream, objects_location, floor);
	//		}
	//
	//
	//		public void loadTilesObjectsFromArray(byte[] DATA, bool floor = true)
	//		{
	//			// Adddress of the room objects
	//			tilesObjects.Clear();
	//			LoadAllRoomObjects(DATA, 0, floor);
	//		}
	//
	//		public void Draw()
	//		{
	//			// TODO: Add somehting here?
	//		}
	//
	//
	//		public void CloneToFile(string file)
	//		{
	//			using (var ms = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))
	//			{
	//				var formatter = new BinaryFormatter();
	//				formatter.Serialize(ms, this);
	//			}
	//		}
	//
	//		public void Delete()
	//		{
	//			tilesObjects.Clear();
	//			tilesLayoutObjects.Clear();
	//			pot_items.Clear();
	//			sprites.Clear();
	//		}
	//
	//		~Room()
	//		{
	//			for (int i = 0; i < chest_list.Count; i++)
	//			{
	//				chest_list[i] = null;
	//			}
	//			for (int i = 0; i < tilesObjects.Count; i++)
	//			{
	//				tilesObjects[i] = null;
	//			}
	//			for (int i = 0; i < tilesLayoutObjects.Count; i++)
	//			{
	//				tilesLayoutObjects[i].tiles.Clear();
	//				tilesLayoutObjects[i] = null;
	//			}
	//			for (int i = 0; i < sprites.Count; i++)
	//			{
	//				sprites[i] = null;
	//			}
	//			for (int i = 0; i < pot_items.Count; i++)
	//			{
	//				pot_items[i] = null;
	//			}
	//			for (int i = 0; i < selectedObject.Count; i++)
	//			{
	//				selectedObject[i] = null;
	//			}
	//
	//			chest_list = null;
	//			tilesObjects = null;
	//			tilesLayoutObjects = null;
	//			sprites = null;
	//			pot_items = null;
	//			selectedObject = null;
	//		}
	//	}
}
