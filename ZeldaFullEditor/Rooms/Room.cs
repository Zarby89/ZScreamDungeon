using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor
{
	[Serializable]
	public class Room : ICloneable
	{
		//List<SpriteName> stringtodraw = new List<SpriteName>();
		public int index;
		int header_location;
		public bool has_changed = false;
		public string name;

		public bool light;
		public byte[] blocks = new byte[16];
		public List<Chest> chest_list = new List<Chest>();
		public List<Room_Object> tilesObjects = new List<Room_Object>();
		public byte[] collisionMap = new byte[4096];
		public List<Sprite> sprites = new List<Sprite>();
		public List<PotItem> pot_items = new List<PotItem>();
		public List<object> selectedObject = new List<object>();
		public List<Room_Object> tilesLayoutObjects = new List<Room_Object>();
		public bool objectInitialized = false;
		public bool onlyLayout = false;

		public string fromExported = "";

		private byte _layout;
		private byte _floor1;
		private byte _floor2;
		private byte _blockset;
		private byte _spriteset;
		private byte _palette;
		private byte _bg2;

		public byte tag1 { get; set; }
		public byte tag2 { get; set; }

		public byte collision { get; set; }
		public byte effect { get; set; }

		private byte _holewarp;
		private byte _holewarp_plane;

		private ushort _messageid;

		public bool damagepit { get; set; }

		public bool sortsprites { get; set; }

		public byte[] staircase_rooms = new byte[4];

		private byte[] staircase_plane = new byte[4];

		//byte[] keysDoors = new byte[] { 0x1C, 0x26, 0x1E, 0x2E, 0x28, 0x32, 0x30, 0x22 };
		//byte[] shutterDoors = new byte[] { 0x44, 0x18, 0x36, 0x38, 0x48, 0x4A };

		static readonly ushort[] stairsObjects = new ushort[] { 0x139, 0x138, 0x13B, 0x12E, 0x12D };
		public List<StaircaseRoom> staircaseRooms = new List<StaircaseRoom>();

		public int roomSize = 0;

		public List<CollisionRectangle> collision_rectangles = new List<CollisionRectangle>();

		public byte layout
		{
			get => _layout;
			set => _layout = value.Clamp(0, 7);
		}

		public byte floor1
		{
			get => _floor1;
			set => _floor1 = value.Clamp(0, 15);
		}

		public byte floor2
		{
			get => _floor2;
			set => _floor2 = value.Clamp(0, 15);
		}

		public byte blockset
		{
			get => _blockset;
			set => _blockset = value.Clamp(0, 23);
		}

		public byte spriteset
		{
			get => _spriteset;
			set => _spriteset = value.Clamp(0, 64);
		}

		public byte palette
		{
			get => _palette;
			set => _palette = value.Clamp(0, 71);
		}

		public byte bg2
		{
			get => _bg2;
			set
			{
				_bg2 = value;
				light = _bg2 == 0x08;
			}
		}

		public ushort messageid
		{
			get => _messageid;
			set => _messageid = value.Clamp(0, 397);
		}

		public byte holewarp
		{
			get => _holewarp;
			set => _holewarp = value.Clamp(0, 255);
		}

		public byte staircase1
		{
			get => staircase_rooms[0];
			set => staircase_rooms[0] = value.Clamp(0, 255);
		}

		public byte staircase2
		{
			get => staircase_rooms[1];
			set => staircase_rooms[1] = value.Clamp(0, 255);
		}

		public byte staircase3
		{
			get => staircase_rooms[2];
			set => staircase_rooms[2] = value.Clamp(0, 255);
		}

		public byte staircase4
		{
			get => staircase_rooms[3];
			set => staircase_rooms[3] = value.Clamp(0, 255);
		}

		public byte holewarp_plane
		{
			get => _holewarp_plane;
			set => _holewarp_plane = value;
		}

		public byte staircase1Plane
		{
			get => staircase_plane[0];
			set => staircase_plane[0] = value;
		}

		public byte staircase2Plane
		{
			get => staircase_plane[1];
			set => staircase_plane[1] = value;
		}

		public byte staircase3Plane
		{
			get => staircase_plane[2];
			set => staircase_plane[2] = value;
		}

		public byte staircase4Plane
		{
			get => staircase_plane[3];
			set => staircase_plane[3] = value;
		}

		protected readonly ZScreamer ZS;
		public ZScreamer Screamer { get => ZS; }

		private Room(ZScreamer parent)
		{
			ZS = parent;
		}

		public Room(ZScreamer parent, int index, string fromExported = "")
		{
			ZS = parent;
			this.fromExported = fromExported;
			this.index = index;
			loadHeader();
			loadLayoutObjects();

			if (fromExported != "")
			{

				if (File.Exists(fromExported + "\\ExportedRooms\\" + "room" + index.ToString("D3") + ".bin"))
				{
					using (FileStream fs = new FileStream(fromExported + "\\ExportedRooms\\" + "room" + index.ToString("D3") + ".bin", FileMode.Open, FileAccess.Read))
					{
						byte[] data = new byte[fs.Length];
						fs.Read(data, 0, data.Length);
						fs.Close();
						loadTilesObjectsFromArray(data);
					}
				}
				else
				{
					loadTilesObjects();
				}
			}
			else
			{
				loadTilesObjects();
			}

			for (int i = 0; i < Constants.TilesPerTilemap; i++)
			{
				collisionMap[i] = 0xFF; // Null byte
			}

			addSprites();
			addBlocks();
			addTorches();
			setObjectsRoom();
			addPotsItems();
			isdamagePit();
			this.name = ROMStructure.roomsNames[index];
			messageid = ZS.ROM[ZS.Offsets.messages_id_dungeon + (index * 2), 2];

			LoadCustomCollisionFromRom();
		}


		public void reloadLayout()
		{
			tilesLayoutObjects.Clear();
			loadLayoutObjects();

			foreach (Room_Object o in tilesLayoutObjects)
			{
				o.setRoom(this);
			}
		}

		public void isdamagePit()
		{
			int pitCount = ZS.ROM[ZS.Offsets.pit_count] / 2;
			int pitPointer = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.pit_pointer, 3]);

			for (int i = 0; i < pitCount; i++)
			{
				if (ZS.ROM[pitPointer + (i * 2), 2] == index)
				{
					damagepit = true;
					return;
				}
			}
		}


		// @author: scawful
		// @brief: Data structure for storing rectangles of tile data 
		[Serializable]
		public struct CollisionRectangle
		{
			public byte width;
			public byte height;
			public ushort index_data;
			public ushort[] tile_data;

			public CollisionRectangle(byte w, byte h, ushort id, ushort[] td)
			{
				this.width = w;
				this.height = h;
				this.index_data = id;
				this.tile_data = td;
			}

			public override string ToString()
			{
				StringBuilder temp = new StringBuilder();
				temp.Append($"[width: {width} | height: {height} | index_data: {index_data} | TileData: " );

				foreach (ushort u in tile_data)
				{
					temp.Append(u);
					temp.Append("; ");
				}

				temp.Remove(temp.Length - 2, 2);

				temp.Append("]");

				return temp.ToString();
			}
		}

		// @author: scawful
		// @brief: Creates a list of valid rectangles from user inputted collision 
		public void loadCollisionLayout(bool output = false)
		{
			Dictionary<int, bool> collision_validity = new Dictionary<int, bool>();

			for (int i = 0; i < collisionMap.Length; ++i)
			{
				collision_validity[i] = false;
			}

			int rectangle_index = 0;
			for (int i = 0; i < collisionMap.Length; ++i)
			{
				if (collisionMap[i] != 0xFF && !collision_validity[i])
				{
					int rectangle_width = 1;
					int rectangle_height = 1;
					bool found_blank = false;

					if (collisionMap[i + 1] == 0xFF && collisionMap[i + 64] == 0xFF)
					{
						ushort[] new_tile_data = { collisionMap[i] };
						collision_validity[i] = true;
						collision_rectangles.Add(new CollisionRectangle(1, 1, (ushort) i, new_tile_data));
					}
					else
					{
						while (!found_blank)
						{
							if (collisionMap[i + rectangle_width] != 0xFF)
							{
								rectangle_width++;
							}
							else
							{
								found_blank = true;
							}
						}

						found_blank = false;
						while (!found_blank)
						{
							if ((i + (rectangle_height * 64)) < 4096)
							{
								if (collisionMap[i + (rectangle_height * 64)] != 0xFF)
								{
									rectangle_height++;
								}
								else
								{
									found_blank = true;
								}
							}
							else
							{
								found_blank = true;
							}
						}

						/* 
                        //removed as it is unnecessary and causes errors when you have a rectangle with different tile data in it
                        bool discrepancy = false;
                        byte rectangle_type = collisionMap[i];

                        for (int y = 0; y < rectangle_height; ++y)
                        {
                            for (int x = 0; x < rectangle_width; ++x)
                            {
                                if (collisionMap[i + (x + (y * 64))] != rectangle_type && !discrepancy)
                                {
                                    if (rectangle_width > x)
                                    {
                                        rectangle_height = y;
                                        discrepancy = true;
                                        break;
                                    }
                                }
                            }
                        }
                        */

						List<ushort> new_tile_data = new List<ushort>();
						for (int y = 0; y < rectangle_height; ++y)
						{
							for (int x = 0; x < rectangle_width; ++x)
							{
								new_tile_data.Add(collisionMap[i + (x + (y * 64))]);
								collision_validity[i + (x + (y * 64))] = true;
							}
						}

						ushort[] _new_tile_data = new_tile_data.ToArray();
						collision_rectangles.Add(new CollisionRectangle((byte) rectangle_width, (byte) rectangle_height, (ushort) i, _new_tile_data));
					}
				}
			}

			/* 
            upper bound 
            512 pixels/8px per tile, so 64
            a full room would be dw $0000 : db 64, 64
            followed by 64x64 bytes
            then FFFF
            */

			/*
            put $F0F0 then put 2 byte index and the 1 byte of data
            index is just Y*64+X
            +$1000 if lower layer

            only the index and tokens are 16 bit
            everything else, width, height, data, are 8 bit 
            */
		}

		/// <summary>
		/// clears the list of valid rectangles from user inputted collision 
		/// </summary>
		public void ClearCollisionLayout()
		{
			collision_rectangles.Clear();
		}

		/// <summary>
		/// Reads the custom collsion data from the ROM and adds it to the collisionMap for the room
		/// </summary>
		public void LoadCustomCollisionFromRom()
		{
			int room_pointer = 0x128090 + (3 * index);

			int data_pointer = ZS.ROM[room_pointer, 3];

			if (data_pointer >= 0x128450)
			{
				while (ZS.ROM[data_pointer.SNEStoPC(), 2] != ((ushort) 0xFFFF))
				{
					int offset = ZS.ROM[data_pointer.SNEStoPC(), 2];
					data_pointer += 2;

					int width = ZS.ROM[data_pointer.SNEStoPC()];
					int height = ZS.ROM[data_pointer.SNEStoPC()];
					data_pointer += 2;

					for (int i = 0; i < height; i++)
					{
						for (int j = 0; j < width; j++)
						{
							collisionMap[(offset + j + (i * 64))] = ZS.ROM[data_pointer.SNEStoPC()];
							data_pointer++;
						}
					}
				}
			}
		}

		public unsafe void reloadAnimatedGfx()
		{
			int gfxanimatedPointer = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.gfx_animated_pointer, 3]);

			byte* newPdata = (byte*) ZS.GFXManager.allgfx16Ptr.ToPointer(); // Turn gfx16 (all 222 of them)
			byte* sheetsData = (byte*) ZS.GFXManager.currentgfx16Ptr.ToPointer(); // Into "room gfx16" 16 of them

			int data = 0;
			while (data < 512)
			{
				byte mapByte = newPdata[data + (92 * 2048) + (512 * ZS.GFXManager.animated_frame)];
				sheetsData[data + (7 * 2048)] = mapByte;

				mapByte = newPdata[data + (ZS.ROM[gfxanimatedPointer + blockset] * 2048) + (512 * ZS.GFXManager.animated_frame)];
				sheetsData[data + (7 * 2048) - 512] = mapByte;
				data++;
			}
		}

		public void reloadGfx(byte entrance_blockset = 0xFF)
		{
			for (int i = 0; i < 8; i++)
			{
				blocks[i] = ZS.GFXGroups.mainGfx[blockset][i];
				if (i >= 6 && i <= 6)
				{
					if (entrance_blockset != 0xFF) //3-6
					{
						// 6 is wrong for the entrance? -NOP need to fix that 
						// TODO: Find why this is wrong - Thats because of the stairs need to find a workaround
						if (ZS.GFXGroups.roomGfx[entrance_blockset][i - 3] != 0)
						{
							blocks[i] = ZS.GFXGroups.roomGfx[entrance_blockset][i - 3];
						}
					}
				}
			}

			blocks[8] = 115 + 0; // Static Sprites Blocksets (fairy,pot,ect...)
			blocks[9] = 115 + 10;
			blocks[10] = 115 + 6;
			blocks[11] = 115 + 7;
			for (int i = 0; i < 4; i++)
			{
				blocks[12 + i] = (byte) (ZS.GFXGroups.spriteGfx[spriteset + 64][i] + 115);
			} // 12-16 sprites

			unsafe
			{
				byte* newPdata = (byte*) ZS.GFXManager.allgfx16Ptr.ToPointer(); // Turn gfx16 (all 222 of them)
				byte* sheetsData = (byte*) ZS.GFXManager.currentgfx16Ptr.ToPointer(); // Into "room gfx16" 16 of them
				int sheetPos = 0;
				for (int i = 0; i < 16; i++)
				{
					int d = 0;
					int ioff = blocks[i] * 2048;
					while (d < 2048)
					{
						// NOTE LOAD BLOCKSETS SOMEWHERE FIRST
						byte mapByte = newPdata[d + ioff];
						if (i < 4) //removed switch
						{
							mapByte += 0x88;
						} // Last line of 6, first line of 7 ?

						sheetsData[d + sheetPos] = mapByte;
						d++;
					}

					sheetPos += 2048;
				}

				reloadAnimatedGfx();
			}
		}

		public void addSprites()
		{
			int spritePointer = 0x040000 | ZS.ROM[ZS.Offsets.rooms_sprite_pointer, 2];

			// 09 bank ? Need to check if HM change that
			int sprite_address = SNESFunctions.SNEStoPC(Constants.DungeonSpritePointers | ZS.ROM[spritePointer + (index * 2), 2]);
			sortsprites = ZS.ROM[sprite_address] == 1;
			sprite_address++;

			while (true)
			{
				byte b1 = ZS.ROM[sprite_address];

				if (b1 == Constants.SpriteTerminator) break;

				byte b2 = ZS.ROM[sprite_address + 1];
				byte b3 = ZS.ROM[sprite_address + 2];


				sprites.Add(new Sprite(this, b3, (byte) (b2 & 0x1F), (byte) (b1 & 0x1F), (byte) (((b2 & 0xE0) >> 5) + ((b1 & 0x60) >> 2)), (byte) ((b1 & 0x80) >> 7)));

				if (sprites.Count > 1)
				{
					Sprite spr = sprites[sprites.Count - 1];
					Sprite prevSprite = sprites[sprites.Count - 2];

					if (spr.id == 0xE4 && spr.x == 0x00 && spr.layer == 1 && spr.subtype == 0x18)
					{
						byte? drop = null;

						if (spr.y == 0x1E)
						{
							drop = 1;
						}
						else if (spr.y == 0x1D)
						{
							drop = 2;
						}

						if (prevSprite != null && drop != null)
						{
							prevSprite.keyDrop = (byte) drop;
							sprites.RemoveAt(sprites.Count - 1);
						}
					}
				}

				sprite_address += 3;
			}
		}

		public void update()
		{
			if (!objectInitialized)
			{
				// TODO: Add condition?
			}

			objectInitialized = true;
		}

		public void drawSprites(bool layer1 = true, bool layer2 = true)
		{
			foreach (Sprite spr in sprites)
			{
				if (!layer1 && spr.layer == 0)
				{
					continue;
				}
				if (!layer2 && spr.layer == 1)
				{
					continue;
				}
				//if (spr.id != 0xE4)
				//{
				spr.Draw();
				//} // 1D big key
				if (spr.keyDrop == 1)
				{
					spr.DrawKey(bigKey: false);
				}
				else if (spr.keyDrop == 2)
				{
					spr.DrawKey(bigKey: true);
				}
			}
		}

		public byte[] getSelectedObjectHex()
		{
			byte[] bytes = new byte[3];
			bool doorfound = false;

			for (int j = 0; j < tilesObjects.Count; j++) // Save layer1 object 
			{
				Room_Object o = tilesObjects[j];
				if (o == selectedObject[0])
				{
					if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr && (o.options & ObjectOption.Block) != ObjectOption.Block && (o.options & ObjectOption.Torch) != ObjectOption.Torch)
					{
						if ((tilesObjects[j].id & 0x200) == 0x200) // Type3
						{
							// xxxxxxii yyyyyyii 11111iii
							bytes[0] = (byte) ((o.x << 2) + (o.id & 0x03));
							bytes[1] = (byte) ((o.y << 2) + ((o.id >> 2) & 0x03));
							bytes[2] = (byte) (o.id >> 4);
						}
						else if ((tilesObjects[j].id & 0x100) == 0x100) // Type2
						{
							// 111111xx xxxxyyyy yyiiiiii
							bytes[0] = (byte) (0xFC + (((o.x & 0x30) >> 4)));
							bytes[1] = (byte) (((o.x & 0x0F) << 4) + ((o.y & 0x3C) >> 2));
							bytes[2] = (byte) (((o.y & 0x03) << 6) + ((o.id & 0x3F))); // wtf?
						}
						else // Type1
						{
							// xxxxxxss yyyyyyss iiiiiiii
							if (o.size > 16)
							{
								o.size = 0;
							}

							bytes[0] = (byte) ((o.x << 2) | ((o.size >> 2) & 0x03));
							bytes[1] = (byte) ((o.y << 2) | (o.size & 0x03));
							bytes[2] = (byte) o.id;
						}
					}

					return bytes;
				}
			}

			return null;
		}

		public bool getLayerTiles(byte layer, ref List<byte> objectsBytes, ref List<byte> doorsBytes)
		{
			bool doorfound = false;
			for (int j = 0; j < tilesObjects.Count; j++) // Save layer1 object 
			{
				Room_Object o = tilesObjects[j];

				if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr && (o.options & ObjectOption.Block) != ObjectOption.Block && (o.options & ObjectOption.Torch) != ObjectOption.Torch)
				{
					if (o.layer == layer)
					{
						// If we encounter a door store it somewhere else for now and wait the end of objects layer1
						if ((tilesObjects[j].options & ObjectOption.Door) == ObjectOption.Door)
						{
							byte p = (o as object_door).door_dir;
							doorfound = true;
							byte b1 = (byte) ((((o as object_door).door_pos) << 3) + p);
							byte b2 = (o as object_door).door_type;
							doorsBytes.Add(b1);
							doorsBytes.Add(b2);
						}
						else
						{
							if ((tilesObjects[j].id & 0x200) == 0x200) // Type3
							{
								// xxxxxxii yyyyyyii 11111iii
								objectsBytes.Add((byte) ((o.x << 2) | (o.id & 0x03)));
								objectsBytes.Add((byte) ((o.y << 2) | ((o.id >> 2) & 0x03)));
								objectsBytes.Add((byte) (o.id >> 4));
							}
							else if ((tilesObjects[j].id & 0x100) == 0x100) // Type2
							{
								// 111111xx xxxxyyyy yyiiiiii

								objectsBytes.Add((byte) (0xFC | ((o.x & 0x30) >> 4)));
								objectsBytes.Add((byte) (((o.x & 0x0F) << 4) | ((o.y & 0x3C) >> 2)));
								objectsBytes.Add((byte) (((o.y & 0x03) << 6) | (o.id & 0x3F))); // wtf? 
							}
							else // Type1
							{
								// xxxxxxss yyyyyyss iiiiiiii
								if (o.size > 16)
								{
									o.size = 0;
								}

								objectsBytes.Add((byte) ((o.x << 2) | ((o.size >> 2) & 0x03)));
								objectsBytes.Add((byte) ((o.y << 2) | (o.size & 0x03)));
								objectsBytes.Add((byte) o.id);
							}
						}
					}
				}
			}

			return doorfound;
		}

		public byte[] getTilesBytes()
		{
			List<byte> objectsBytes = new List<byte>();
			List<byte> doorsBytes = new List<byte>();
			bool found_door, found_door2, found_door3;

			objectsBytes.Add((byte) ((floor2 << 4) | floor1));
			objectsBytes.Add((byte) (layout << 2));

			doorsBytes.Clear();
			found_door = getLayerTiles(0, ref objectsBytes, ref doorsBytes);

			objectsBytes.Add(0xFF); // End layer1
			objectsBytes.Add(0xFF); // End layer1
			found_door2 = getLayerTiles(1, ref objectsBytes, ref doorsBytes);

			objectsBytes.Add(0xFF); // End layer2
			objectsBytes.Add(0xFF); // End layer2
			found_door3 = getLayerTiles(2, ref objectsBytes, ref doorsBytes);

			if (found_door || found_door2 || found_door3) // If we found door during any layer
			{
				objectsBytes.Add(0xF0);
				objectsBytes.Add(0xFF);

				objectsBytes.Concat(doorsBytes);
			}

			objectsBytes.Add(0xFF); // End layer3
			objectsBytes.Add(0xFF); // End layer3
			doorsBytes.Clear();

			return objectsBytes.ToArray();
		}

		public void drawPotsItems()
		{
			foreach (PotItem item in pot_items)
			{
				item.Draw();
			}
		}

		public Rectangle[] getAllDoorPosition(Room_Object o)
		{
			Rectangle[] rects = new Rectangle[48];
			int pos;
			float n;

			for (int i = 0, j = 0; i < 12; i++, j += 2) // Left
			{
				pos = ZS.ROM[0x197E + j, 2] / 2;
				n = (((float) pos / 64) - (byte) (pos / 64)) * 64;
				rects[i] = new Rectangle(((byte) n) * 8, (byte) (pos / 64) * 8, 32, 24);

				pos = ZS.ROM[0x1996 + j, 2] / 2;
				n = (((float) pos / 64) - (byte) (pos / 64)) * 64;
				rects[i + 12] = new Rectangle(((byte) n) * 8, (byte) ((pos / 64) + 1) * 8, 32, 24);

				pos = ZS.ROM[0x19AE + j, 2] / 2;
				n = (((float) pos / 64) - (byte) (pos / 64)) * 64;
				rects[i + 24] = new Rectangle(((byte) n) * 8, (byte) (pos / 64) * 8, 24, 32);

				pos = ZS.ROM[0x19C6 + j, 2] / 2;
				n = (((float) pos / 64) - (byte) (pos / 64)) * 64;
				rects[i + 36] = new Rectangle(((byte) n + 1) * 8, (byte) (pos / 64) * 8, 24, 32);
			}

			return rects;
		}

		public void setObjectsRoom()
		{
			foreach (Room_Object o in tilesObjects)
			{
				o.setRoom(this);
				o.getObjectSize();
			}
		}

		public void addlistBlock(ref byte[] blocksdata, int maxCount)
		{
			int pos1 = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.blocks_pointer1, 3]);
			int pos2 = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.blocks_pointer2, 3]);
			int pos3 = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.blocks_pointer3, 3]);
			int pos4 = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.blocks_pointer4, 3]);

			for (int i = 0; i < 0x80; i += 1)
			{
				blocksdata[i] = ZS.ROM[i + pos1];
				blocksdata[i + 0x80] = ZS.ROM[i + pos2];

				if (i + 0x100 < maxCount)
				{
					blocksdata[i + 0x100] = ZS.ROM[i + pos3];
				}
				if (i + 0x180 < maxCount)
				{
					blocksdata[i + 0x180] = ZS.ROM[i + pos4];
				}
			}
		}

		public void addBlocks()
		{
			// 288

			int blocksCount = ZS.ROM[ZS.Offsets.blocks_length, 2];
			byte[] blocksdata = new byte[blocksCount];

			addlistBlock(ref blocksdata, blocksCount);
			for (int i = 0; i < blocksCount; i += 4)
			{
				byte b1 = blocksdata[i];
				byte b2 = blocksdata[i + 1];
				byte b3 = blocksdata[i + 2];
				byte b4 = blocksdata[i + 3];

				if (((b2 << 8) + b1) == index)
				{
					if (b3 == 0xFF && b4 == 0xFF) { break; }
					int address = ((b4 & 0x1F) << 8 | b3) >> 1;
					int px = address % 64;
					int py = address >> 6;
					Room_Object r = addObject(Constants.TorchPseudoID, (byte) (px), (byte) (py), 0, (byte) ((b4 & 0x20) >> 5));

					if (r != null)
					{
						r.options |= ObjectOption.Block;
						tilesObjects.Add(r);
					}
				}
			}
		}

		public void addTorches()
		{
			int bytes_count = ZS.ROM[ZS.Offsets.torches_length_pointer, 2];

			for (int i = 0; i < bytes_count; i += 2)
			{
				byte b1 = ZS.ROM[ZS.Offsets.torch_data + i];
				byte b2 = ZS.ROM[ZS.Offsets.torch_data + i + 1];

				if (b1 == 0xFF && b2 == 0xFF) { continue; }

				if (((b2 << 8) + b1) == index) // If roomindex = indexread
				{
					i += 2;
					while (true)
					{
						b1 = ZS.ROM[ZS.Offsets.torch_data + i];
						b2 = ZS.ROM[ZS.Offsets.torch_data + i + 1];

						if (b1 == 0xFF && b2 == 0xFF) { break; }
						int address = ((b2 & 0x1F) << 8 | b1) >> 1;
						int px = address % 64;
						int py = address >> 6;

						Room_Object r = addObject(0x150, (byte) px, (byte) py, 0, (byte) ((b2 & 0x20) >> 5));
						if ((b2 & 0x80) == 0x80)
						{
							r.lit = true;
						}
						if (r != null)
						{
							r.options |= ObjectOption.Torch;
							tilesObjects.Add(r);
						}

						//tilesObjects[tilesObjects.Count - 1].is_torch = true;
						i += 2;
					}
				}
				else
				{
					while (true)
					{
						b1 = ZS.ROM[ZS.Offsets.torch_data + i];
						b2 = ZS.ROM[ZS.Offsets.torch_data + i + 1];
						if (b1 == 0xFF && b2 == 0xFF) { break; }
						i += 2;
					}
				}
			}
		}


		public void addPotsItems()
		{
			int item_address_snes = 0x010000 | ZS.ROM[ZS.Offsets.room_items_pointers + (index * 2), 2];

			int item_address = item_address_snes.SNEStoPC();

			while (true)
			{
				byte b1 = ZS.ROM[item_address];
				byte b2 = ZS.ROM[item_address + 1];
				byte b3 = ZS.ROM[item_address + 2];
				//0x20 = bg2

				if (b1 == 0xFF && b2 == 0xFF) { break; }
				int address = ((b2 & 0x1F) << 8 | b1) >> 1;
				int px = address % 64;
				int py = address >> 6;
				PotItem p = new PotItem(b3, (byte) ((px)), (byte) ((py)), (b2 & 0x20) == 0x20, ZS);

				p.layer = (byte) (p.bg2 ? 1 : 0);

				// Bit 7 is set if the object is a special object holes, switches
				// After 0x16 it goes to 0x80

				item_address += 3;
			}
		}

		public void loadChests(ref List<ChestData> chests_in_room)
		{
			int cpos = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.chests_data_pointer1, 3]);
			int clength = ZS.ROM[ZS.Offsets.chests_length_pointer, 2];

			for (int i = 0; i < clength; i++)
			{
				if ((ZS.ROM[cpos + (i * 3), 2] & 0x7FFF) == index)
				{
					//There's a chest in that room !
					// HACK: need to make this bigger than ushort.max to avoid confusion between int and ushort when using dynamic
					bool big = IntFunctions.BitIsOn(ZS.ROM[cpos + (i * 3), 2], 0x18000);  

					chests_in_room.Add(new ChestData(ZS.ROM[cpos + (i * 3) + 2], big));
				}
			}
		}

		public void loadTilesObjects(bool floor = true)
		{
			// Adddress of the room objects
			int objectPointer = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.room_object_pointer, 3]);
			int room_address = objectPointer + (index * 3);

			int objects_location = SNESFunctions.SNEStoPC(ZS.ROM[room_address, 3]);

			LoadAllRoomObjects(ZS.ROM.DataStream, objects_location, floor);
		}

		private Room_Object ParseRoomObject(in int layer, in byte b1, in byte b2, in byte b3, out byte posX, out byte posY)
		{
			ushort oid;
			byte sizeX, sizeY, sizeXY;

			if (b3 >= 0xF8)
			{
				oid = (ushort) (((b3 << 4) | 0x80 + (((b2 & 0x03) << 2) + (b1 & 0x03))) - 0xD80); // TODO fix this ugly shit
				posX = (byte) ((b1 & 0xFC) >> 2);
				posY = (byte) ((b2 & 0xFC) >> 2);
				sizeXY = (byte) ((((b1 & 0x03) << 2) + (b2 & 0x03)));
			}
			else // Subtype1
			{
				oid = b3;
				posX = (byte) ((b1 & 0xFC) >> 2);
				posY = (byte) ((b2 & 0xFC) >> 2);
				sizeX = (byte) (b1 & 0x03);
				sizeY = (byte) (b2 & 0x03);
				sizeXY = (byte) ((sizeX << 2) + sizeY);
			}

			if (b1 >= 0xFC) // Subtype2 (not scalable?)
			{
				oid = (ushort) ((b3 & 0x3F) | 0x100);
				posX = (byte) (((b2 & 0xF0) >> 4) + ((b1 & 0x3) << 4));
				posY = (byte) (((b2 & 0x0F) << 2) + ((b3 & 0xC0) >> 6));
				sizeXY = 0;
			}

			return addObject(oid, posX, posY, sizeXY, (byte) layer);
		}
		private void LoadAllRoomObjects(byte[] datasource, int pos, bool floor = true)
		{
			List<ChestData> chests_in_room = new List<ChestData>();
			loadChests(ref chests_in_room);

			staircaseRooms.Clear();
			int nbr_of_staircase = 0;

			if (floor)
			{
				byte t = datasource[pos++];
				floor2 = (byte) (t >> 4);
				floor1 = (byte) (t & 0xF);
			}

			layout = (byte) ((datasource[pos++] >> 2) & 0x07);

			byte b1, b2, b3;
			ushort oid = 0;
			int layer = 0;
			bool door = false;
			bool endRead = false;

			while (!endRead)
			{
				b1 = datasource[pos];
				b2 = datasource[pos + 1];

				if ((b1 & b2) == 0xFF)
				{
					pos += 2; // We jump to layer2
					layer++;
					door = false;
					if (layer == 3)
					{
						break;
					}

					continue;
				}

				if (b1 == 0xF0 && b2 == 0xFF)
				{
					pos += 2; // We jump to layer2
					door = true;

					continue;
				}

				b3 = datasource[pos + 2];
				if (door)
				{
					pos += 2;

				}
				else
				{
					pos += 3;
				}

				if (!door)
				{

					Room_Object r = ParseRoomObject(layer, in b1, in b2, in b3, out byte posX, out byte posY);
					//GFX.objects[oid] = true;

					if (r != null)
					{
						tilesObjects.Add(r);
					}

					foreach (ushort stair in stairsObjects)
					{
						if (stair == oid) // We found stairs that lead to another room
						{
							if (nbr_of_staircase < 4)
							{
								tilesObjects[tilesObjects.Count - 1].options |= ObjectOption.Stairs;
								staircaseRooms.Add(new StaircaseRoom(posX, posY, "To " + staircase_rooms[nbr_of_staircase]));
								nbr_of_staircase++;
							}
							else
							{
								tilesObjects[tilesObjects.Count - 1].options |= ObjectOption.Stairs;
								staircaseRooms.Add(new StaircaseRoom(posX, posY, "To ???"));
							}
						}
					}

					// TODO magic numbers
					// IF Object is a chest loaded and there's object in the list chest
					if (oid == Constants.ChestID)
					{
						if (chests_in_room.Count > 0)
						{
							tilesObjects[tilesObjects.Count - 1].options |= ObjectOption.Chest;
							chest_list.Add(new Chest(ZS, posX, posY, chests_in_room[0].itemIn, false));
							chests_in_room.RemoveAt(0);
						}
					}
					else if (oid == Constants.BigChestID)
					{
						if (chests_in_room.Count > 0)
						{
							tilesObjects[tilesObjects.Count - 1].options |= ObjectOption.Chest;
							chest_list.Add(new Chest(ZS, (byte) (posX + 1), posY, chests_in_room[0].itemIn, true));
							chests_in_room.RemoveAt(0);
						}
					}
				}
				else
				{
					//byte door_pos = b1;//(byte)((b1 & 0xF0) >> 3);
					//byte door_type = b2;
					tilesObjects.Add(new object_door((ushort) ((b2 << 8) + b1), 0, 0, 0, (byte) layer, ZS));
					continue;
				}
			}
		}

		public void loadTilesObjectsFromArray(byte[] DATA, bool floor = true)
		{
			// Adddress of the room objects
			tilesObjects.Clear();
			LoadAllRoomObjects(DATA, 0, floor);
		}

		public void loadLayoutObjects(bool floor = true) // That is dumb!
		{
			int pointer = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.room_object_layout_pointer, 3]);
			int layout_address = ZS.ROM[pointer + (layout * 3), 3];

			int pos = layout_address.SNEStoPC();
			byte b1, b2, b3;
			int layer = 0;

			while (true)
			{
				b1 = ZS.ROM[pos];
				b2 = ZS.ROM[pos + 1];

				if ((b1 & b2) == 0xFF)
				{
					break;
				}

				b3 = ZS.ROM[pos + 2];
				pos += 3; // We jump to layer2

				Room_Object r = ParseRoomObject(in layer, in b1, in b2, in b3, out byte posX, out byte posY);
				if (r != null)
				{
					r.options |= ObjectOption.Bgr;
					tilesLayoutObjects.Add(r);
				}
			}
		}

		public Room_Object addObject(ushort oid, byte x, byte y, byte size, byte layer)
		{
			if (oid == Constants.TorchPseudoID) // Block
			{
				return new object_Block(oid, x, y, 0, layer, ZS);
			}

			if (oid < 0x100 || (oid >= 0x200 && oid < 0x300))
			{
				switch (oid)
				{
					case 0x00: return new object_00(x, y, size, layer, ZS);
					case 0x01: return new object_01(x, y, size, layer, ZS);
					case 0x02: return new object_02(x, y, size, layer, ZS);
					case 0x03: return new object_03(x, y, size, layer, ZS);
					case 0x04: return new object_04(x, y, size, layer, ZS);
					case 0x05: return new object_05(x, y, size, layer, ZS);
					case 0x06: return new object_06(x, y, size, layer, ZS);
					case 0x07: return new object_07(x, y, size, layer, ZS);
					case 0x08: return new object_08(x, y, size, layer, ZS);
					case 0x09: return new object_09(x, y, size, layer, ZS);
					case 0x0A: return new object_0A(x, y, size, layer, ZS);
					case 0x0B: return new object_0B(x, y, size, layer, ZS);
					case 0x0C: return new object_0C(x, y, size, layer, ZS);
					case 0x0D: return new object_0D(x, y, size, layer, ZS);
					case 0x0E: return new object_0E(x, y, size, layer, ZS);
					case 0x0F: return new object_0F(x, y, size, layer, ZS);
					case 0x10: return new object_10(x, y, size, layer, ZS);
					case 0x11: return new object_11(x, y, size, layer, ZS);
					case 0x12: return new object_12(x, y, size, layer, ZS);
					case 0x13: return new object_13(x, y, size, layer, ZS);
					case 0x14: return new object_14(x, y, size, layer, ZS);
					case 0x15: return new object_15(x, y, size, layer, ZS);
					case 0x16: return new object_16(x, y, size, layer, ZS);
					case 0x17: return new object_17(x, y, size, layer, ZS);
					case 0x18: return new object_18(x, y, size, layer, ZS);
					case 0x19: return new object_19(x, y, size, layer, ZS);
					case 0x1A: return new object_1A(x, y, size, layer, ZS);
					case 0x1B: return new object_1B(x, y, size, layer, ZS);
					case 0x1C: return new object_1C(x, y, size, layer, ZS);
					case 0x1D: return new object_1D(x, y, size, layer, ZS);
					case 0x1E: return new object_1E(x, y, size, layer, ZS);
					case 0x1F: return new object_1F(x, y, size, layer, ZS);
					case 0x20: return new object_20(x, y, size, layer, ZS);
					case 0x21: return new object_21(x, y, size, layer, ZS);
					case 0x22: return new object_22(x, y, size, layer, ZS);
					case 0x23: return new object_23(x, y, size, layer, ZS);
					case 0x24: return new object_24(x, y, size, layer, ZS);
					case 0x25: return new object_25(x, y, size, layer, ZS);
					case 0x26: return new object_26(x, y, size, layer, ZS);
					case 0x27: return new object_27(x, y, size, layer, ZS);
					case 0x28: return new object_28(x, y, size, layer, ZS);
					case 0x29: return new object_29(x, y, size, layer, ZS);
					case 0x2A: return new object_2A(x, y, size, layer, ZS);
					case 0x2B: return new object_2B(x, y, size, layer, ZS);
					case 0x2C: return new object_2C(x, y, size, layer, ZS);
					case 0x2D: return new object_2D(x, y, size, layer, ZS);
					case 0x2E: return new object_2E(x, y, size, layer, ZS);
					case 0x2F: return new object_2F(x, y, size, layer, ZS);
					case 0x30: return new object_30(x, y, size, layer, ZS);
					case 0x31: return new object_31(x, y, size, layer, ZS);
					case 0x32: return new object_32(x, y, size, layer, ZS);
					case 0x33: return new object_33(x, y, size, layer, ZS);
					case 0x34: return new object_34(x, y, size, layer, ZS);
					case 0x35: return new object_35(x, y, size, layer, ZS);
					case 0x36: return new object_36(x, y, size, layer, ZS);
					case 0x37: return new object_37(x, y, size, layer, ZS);
					case 0x38: return new object_38(x, y, size, layer, ZS);
					case 0x39: return new object_39(x, y, size, layer, ZS);
					case 0x3A: return new object_3A(x, y, size, layer, ZS);
					case 0x3B: return new object_3B(x, y, size, layer, ZS);
					case 0x3C: return new object_3C(x, y, size, layer, ZS);
					case 0x3D: return new object_3D(x, y, size, layer, ZS);
					case 0x3E: return new object_3E(x, y, size, layer, ZS);
					case 0x3F: return new object_3F(x, y, size, layer, ZS);
					case 0x40: return new object_40(x, y, size, layer, ZS);
					case 0x41: return new object_41(x, y, size, layer, ZS);
					case 0x42: return new object_42(x, y, size, layer, ZS);
					case 0x43: return new object_43(x, y, size, layer, ZS);
					case 0x44: return new object_44(x, y, size, layer, ZS);
					case 0x45: return new object_45(x, y, size, layer, ZS);
					case 0x46: return new object_46(x, y, size, layer, ZS);
					case 0x47: return new object_47(x, y, size, layer, ZS);
					case 0x48: return new object_48(x, y, size, layer, ZS);
					case 0x49: return new object_49(x, y, size, layer, ZS);
					case 0x4A: return new object_4A(x, y, size, layer, ZS);
					case 0x4B: return new object_4B(x, y, size, layer, ZS);
					case 0x4C: return new object_4C(x, y, size, layer, ZS);
					case 0x4D: return new object_4D(x, y, size, layer, ZS);
					case 0x4E: return new object_4E(x, y, size, layer, ZS);
					case 0x4F: return new object_4F(x, y, size, layer, ZS);
					case 0x50: return new object_50(x, y, size, layer, ZS);
					case 0x51: return new object_51(x, y, size, layer, ZS);
					case 0x52: return new object_52(x, y, size, layer, ZS);
					case 0x53: return new object_53(x, y, size, layer, ZS);
					case 0x54: return new object_54(x, y, size, layer, ZS);
					case 0x55: return new object_55(x, y, size, layer, ZS);
					case 0x56: return new object_56(x, y, size, layer, ZS);
					case 0x57: return new object_57(x, y, size, layer, ZS);
					case 0x58: return new object_58(x, y, size, layer, ZS);
					case 0x59: return new object_59(x, y, size, layer, ZS);
					case 0x5A: return new object_5A(x, y, size, layer, ZS);
					case 0x5B: return new object_5B(x, y, size, layer, ZS);
					case 0x5C: return new object_5C(x, y, size, layer, ZS);
					case 0x5D: return new object_5D(x, y, size, layer, ZS);
					case 0x5E: return new object_5E(x, y, size, layer, ZS);
					case 0x5F: return new object_5F(x, y, size, layer, ZS);
					case 0x60: return new object_60(x, y, size, layer, ZS);
					case 0x61: return new object_61(x, y, size, layer, ZS);
					case 0x62: return new object_62(x, y, size, layer, ZS);
					case 0x63: return new object_63(x, y, size, layer, ZS);
					case 0x64: return new object_64(x, y, size, layer, ZS);
					case 0x65: return new object_65(x, y, size, layer, ZS);
					case 0x66: return new object_66(x, y, size, layer, ZS);
					case 0x67: return new object_67(x, y, size, layer, ZS);
					case 0x68: return new object_68(x, y, size, layer, ZS);
					case 0x69: return new object_69(x, y, size, layer, ZS);
					case 0x6A: return new object_6A(x, y, size, layer, ZS);
					case 0x6B: return new object_6B(x, y, size, layer, ZS);
					case 0x6C: return new object_6C(x, y, size, layer, ZS);
					case 0x6D: return new object_6D(x, y, size, layer, ZS);
					case 0x6E: return new object_6E(x, y, size, layer, ZS);
					case 0x6F: return new object_6F(x, y, size, layer, ZS);
					case 0x70: return new object_70(x, y, size, layer, ZS);
					case 0x71: return new object_71(x, y, size, layer, ZS);
					case 0x72: return new object_72(x, y, size, layer, ZS);
					case 0x73: return new object_73(x, y, size, layer, ZS);
					case 0x74: return new object_74(x, y, size, layer, ZS);
					case 0x75: return new object_75(x, y, size, layer, ZS);
					case 0x76: return new object_76(x, y, size, layer, ZS);
					case 0x77: return new object_77(x, y, size, layer, ZS);
					case 0x78: return new object_78(x, y, size, layer, ZS);
					case 0x79: return new object_79(x, y, size, layer, ZS);
					case 0x7A: return new object_7A(x, y, size, layer, ZS);
					case 0x7B: return new object_7B(x, y, size, layer, ZS);
					case 0x7C: return new object_7C(x, y, size, layer, ZS);
					case 0x7D: return new object_7D(x, y, size, layer, ZS);
					case 0x7E: return new object_7E(x, y, size, layer, ZS);
					case 0x7F: return new object_7F(x, y, size, layer, ZS);
					case 0x80: return new object_80(x, y, size, layer, ZS);
					case 0x81: return new object_81(x, y, size, layer, ZS);
					case 0x82: return new object_82(x, y, size, layer, ZS);
					case 0x83: return new object_83(x, y, size, layer, ZS);
					case 0x84: return new object_84(x, y, size, layer, ZS);
					case 0x85: return new object_85(x, y, size, layer, ZS);
					case 0x86: return new object_86(x, y, size, layer, ZS);
					case 0x87: return new object_87(x, y, size, layer, ZS);
					case 0x88: return new object_88(x, y, size, layer, ZS);
					case 0x89: return new object_89(x, y, size, layer, ZS);
					case 0x8A: return new object_8A(x, y, size, layer, ZS);
					case 0x8B: return new object_8B(x, y, size, layer, ZS);
					case 0x8C: return new object_8C(x, y, size, layer, ZS);
					case 0x8D: return new object_8D(x, y, size, layer, ZS);
					case 0x8E: return new object_8E(x, y, size, layer, ZS);
					case 0x8F: return new object_8F(x, y, size, layer, ZS);
					case 0x90: return new object_90(x, y, size, layer, ZS);
					case 0x91: return new object_91(x, y, size, layer, ZS);
					case 0x92: return new object_92(x, y, size, layer, ZS);
					case 0x93: return new object_93(x, y, size, layer, ZS);
					case 0x94: return new object_94(x, y, size, layer, ZS);
					case 0x95: return new object_95(x, y, size, layer, ZS);
					case 0x96: return new object_96(x, y, size, layer, ZS);
					case 0x97: return new object_97(x, y, size, layer, ZS);
					case 0x98: return new object_98(x, y, size, layer, ZS);
					case 0x99: return new object_99(x, y, size, layer, ZS);
					case 0x9A: return new object_9A(x, y, size, layer, ZS);
					case 0x9B: return new object_9B(x, y, size, layer, ZS);
					case 0x9C: return new object_9C(x, y, size, layer, ZS);
					case 0x9D: return new object_9D(x, y, size, layer, ZS);
					case 0x9E: return new object_9E(x, y, size, layer, ZS);
					case 0x9F: return new object_9F(x, y, size, layer, ZS);
					case 0xA0: return new object_A0(x, y, size, layer, ZS);
					case 0xA1: return new object_A1(x, y, size, layer, ZS);
					case 0xA2: return new object_A2(x, y, size, layer, ZS);
					case 0xA3: return new object_A3(x, y, size, layer, ZS);
					case 0xA4: return new object_A4(x, y, size, layer, ZS);
					case 0xA5: return new object_A5(x, y, size, layer, ZS);
					case 0xA6: return new object_A6(x, y, size, layer, ZS);
					case 0xA7: return new object_A7(x, y, size, layer, ZS);
					case 0xA8: return new object_A8(x, y, size, layer, ZS);
					case 0xA9: return new object_A9(x, y, size, layer, ZS);
					case 0xAA: return new object_AA(x, y, size, layer, ZS);
					case 0xAB: return new object_AB(x, y, size, layer, ZS);
					case 0xAC: return new object_AC(x, y, size, layer, ZS);
					case 0xAD: return new object_AD(x, y, size, layer, ZS);
					case 0xAE: return new object_AE(x, y, size, layer, ZS);
					case 0xAF: return new object_AF(x, y, size, layer, ZS);
					case 0xB0: return new object_B0(x, y, size, layer, ZS);
					case 0xB1: return new object_B1(x, y, size, layer, ZS);
					case 0xB2: return new object_B2(x, y, size, layer, ZS);
					case 0xB3: return new object_B3(x, y, size, layer, ZS);
					case 0xB4: return new object_B4(x, y, size, layer, ZS);
					case 0xB5: return new object_B5(x, y, size, layer, ZS);
					case 0xB6: return new object_B6(x, y, size, layer, ZS);
					case 0xB7: return new object_B7(x, y, size, layer, ZS);
					case 0xB8: return new object_B8(x, y, size, layer, ZS);
					case 0xB9: return new object_B9(x, y, size, layer, ZS);
					case 0xBA: return new object_BA(x, y, size, layer, ZS);
					case 0xBB: return new object_BB(x, y, size, layer, ZS);
					case 0xBC: return new object_BC(x, y, size, layer, ZS);
					case 0xBD: return new object_BD(x, y, size, layer, ZS);
					case 0xBE: return new object_BE(x, y, size, layer, ZS);
					case 0xBF: return new object_BF(x, y, size, layer, ZS);
					case 0xC0: return new object_C0(x, y, size, layer, ZS);
					case 0xC1: return new object_C1(x, y, size, layer, ZS);
					case 0xC2: return new object_C2(x, y, size, layer, ZS);
					case 0xC3: return new object_C3(x, y, size, layer, ZS);
					case 0xC4: return new object_C4(x, y, size, layer, ZS);
					case 0xC5: return new object_C5(x, y, size, layer, ZS);
					case 0xC6: return new object_C6(x, y, size, layer, ZS);
					case 0xC7: return new object_C7(x, y, size, layer, ZS);
					case 0xC8: return new object_C8(x, y, size, layer, ZS);
					case 0xC9: return new object_C9(x, y, size, layer, ZS);
					case 0xCA: return new object_CA(x, y, size, layer, ZS);
					case 0xCB: return new object_CB(x, y, size, layer, ZS);
					case 0xCC: return new object_CC(x, y, size, layer, ZS);
					case 0xCD: return new object_CD(x, y, size, layer, ZS);
					case 0xCE: return new object_CE(x, y, size, layer, ZS);
					case 0xCF: return new object_CF(x, y, size, layer, ZS);
					case 0xD0: return new object_D0(x, y, size, layer, ZS);
					case 0xD1: return new object_D1(x, y, size, layer, ZS);
					case 0xD2: return new object_D2(x, y, size, layer, ZS);
					case 0xD3: return new object_D3(x, y, size, layer, ZS);
					case 0xD4: return new object_D4(x, y, size, layer, ZS);
					case 0xD5: return new object_D5(x, y, size, layer, ZS);
					case 0xD6: return new object_D6(x, y, size, layer, ZS);
					case 0xD7: return new object_D7(x, y, size, layer, ZS);
					case 0xD8: return new object_D8(x, y, size, layer, ZS);
					case 0xD9: return new object_D9(x, y, size, layer, ZS);
					case 0xDA: return new object_DA(x, y, size, layer, ZS);
					case 0xDB: return new object_DB(x, y, size, layer, ZS);
					case 0xDC: return new object_DC(x, y, size, layer, ZS);
					case 0xDD: return new object_DD(x, y, size, layer, ZS);
					case 0xDE: return new object_DE(x, y, size, layer, ZS);
					case 0xDF: return new object_DF(x, y, size, layer, ZS);
					case 0xE0: return new object_E0(x, y, size, layer, ZS);
					case 0xE1: return new object_E1(x, y, size, layer, ZS);
					case 0xE2: return new object_E2(x, y, size, layer, ZS);
					case 0xE3: return new object_E3(x, y, size, layer, ZS);
					case 0xE4: return new object_E4(x, y, size, layer, ZS);
					case 0xE5: return new object_E5(x, y, size, layer, ZS);
					case 0xE6: return new object_E6(x, y, size, layer, ZS);
					case 0xE7: return new object_E7(x, y, size, layer, ZS);
					case 0xE8: return new object_E8(x, y, size, layer, ZS);
					case 0xE9: return new object_E9(x, y, size, layer, ZS);
					case 0xEA: return new object_EA(x, y, size, layer, ZS);
					case 0xEB: return new object_EB(x, y, size, layer, ZS);
					case 0xEC: return new object_EC(x, y, size, layer, ZS);
					case 0xED: return new object_ED(x, y, size, layer, ZS);
					case 0xEE: return new object_EE(x, y, size, layer, ZS);
					case 0xEF: return new object_EF(x, y, size, layer, ZS);
					case 0xF0: return new object_F0(x, y, size, layer, ZS);
					case 0xF1: return new object_F1(x, y, size, layer, ZS);
					case 0xF2: return new object_F2(x, y, size, layer, ZS);
					case 0xF3: return new object_F3(x, y, size, layer, ZS);
					case 0xF4: return new object_F4(x, y, size, layer, ZS);
					case 0xF5: return new object_F5(x, y, size, layer, ZS);
					case 0xF6: return new object_F6(x, y, size, layer, ZS);
					case 0xF7: return new object_F7(x, y, size, layer, ZS);

					// subtype 3
					case 0x200: return new object_200(x, y, size, layer, ZS);
					case 0x201: return new object_201(x, y, size, layer, ZS);
					case 0x202: return new object_202(x, y, size, layer, ZS);
					case 0x203: return new object_203(x, y, size, layer, ZS);
					case 0x204: return new object_204(x, y, size, layer, ZS);
					case 0x205: return new object_205(x, y, size, layer, ZS);
					case 0x206: return new object_206(x, y, size, layer, ZS);
					case 0x207: return new object_207(x, y, size, layer, ZS);
					case 0x208: return new object_208(x, y, size, layer, ZS);
					case 0x209: return new object_209(x, y, size, layer, ZS);
					case 0x20A: return new object_20A(x, y, size, layer, ZS);
					case 0x20B: return new object_20B(x, y, size, layer, ZS);
					case 0x20C: return new object_20C(x, y, size, layer, ZS);
					case 0x20D: return new object_20D(x, y, size, layer, ZS);
					case 0x20E: return new object_20E(x, y, size, layer, ZS);
					case 0x20F: return new object_20F(x, y, size, layer, ZS);
					case 0x210: return new object_210(x, y, size, layer, ZS);
					case 0x211: return new object_211(x, y, size, layer, ZS);
					case 0x212: return new object_212(x, y, size, layer, ZS);
					case 0x213: return new object_213(x, y, size, layer, ZS);
					case 0x214: return new object_214(x, y, size, layer, ZS);
					case 0x215: return new object_215(x, y, size, layer, ZS);
					case 0x216: return new object_216(x, y, size, layer, ZS);
					case 0x217: return new object_217(x, y, size, layer, ZS);
					case 0x218: return new object_218(x, y, size, layer, ZS);
					case 0x219: return new object_219(x, y, size, layer, ZS);
					case 0x21A: return new object_21A(x, y, size, layer, ZS);
					case 0x21B: return new object_21B(x, y, size, layer, ZS);
					case 0x21C: return new object_21C(x, y, size, layer, ZS);
					case 0x21D: return new object_21D(x, y, size, layer, ZS);
					case 0x21E: return new object_21E(x, y, size, layer, ZS);
					case 0x21F: return new object_21F(x, y, size, layer, ZS);
					case 0x220: return new object_220(x, y, size, layer, ZS);
					case 0x221: return new object_221(x, y, size, layer, ZS);
					case 0x222: return new object_222(x, y, size, layer, ZS);
					case 0x223: return new object_223(x, y, size, layer, ZS);
					case 0x224: return new object_224(x, y, size, layer, ZS);
					case 0x225: return new object_225(x, y, size, layer, ZS);
					case 0x226: return new object_226(x, y, size, layer, ZS);
					case 0x227: return new object_227(x, y, size, layer, ZS);
					case 0x228: return new object_228(x, y, size, layer, ZS);
					case 0x229: return new object_229(x, y, size, layer, ZS);
					case 0x22A: return new object_22A(x, y, size, layer, ZS);
					case 0x22B: return new object_22B(x, y, size, layer, ZS);
					case 0x22C: return new object_22C(x, y, size, layer, ZS);
					case 0x22D: return new object_22D(x, y, size, layer, ZS);
					case 0x22E: return new object_22E(x, y, size, layer, ZS);
					case 0x22F: return new object_22F(x, y, size, layer, ZS);
					case 0x230: return new object_230(x, y, size, layer, ZS);
					case 0x231: return new object_231(x, y, size, layer, ZS);
					case 0x232: return new object_232(x, y, size, layer, ZS);
					case 0x233: return new object_233(x, y, size, layer, ZS);
					case 0x234: return new object_234(x, y, size, layer, ZS);
					case 0x235: return new object_235(x, y, size, layer, ZS);
					case 0x236: return new object_236(x, y, size, layer, ZS);
					case 0x237: return new object_237(x, y, size, layer, ZS);
					case 0x238: return new object_238(x, y, size, layer, ZS);
					case 0x239: return new object_239(x, y, size, layer, ZS);
					case 0x23A: return new object_23A(x, y, size, layer, ZS);
					case 0x23B: return new object_23A(x, y, size, layer, ZS);
					case 0x23C: return new object_23C(x, y, size, layer, ZS);
					case 0x23D: return new object_23D(x, y, size, layer, ZS);
					case 0x23E: return new object_23E(x, y, size, layer, ZS);
					case 0x23F: return new object_23F(x, y, size, layer, ZS);
					case 0x240: return new object_240(x, y, size, layer, ZS);
					case 0x241: return new object_241(x, y, size, layer, ZS);
					case 0x242: return new object_242(x, y, size, layer, ZS);
					case 0x243: return new object_243(x, y, size, layer, ZS);
					case 0x244: return new object_244(x, y, size, layer, ZS);
					case 0x245: return new object_245(x, y, size, layer, ZS);
					case 0x246: return new object_246(x, y, size, layer, ZS);
					case 0x247: return new object_247(x, y, size, layer, ZS);
					case 0x248: return new object_248(x, y, size, layer, ZS);
					case 0x249: return new object_249(x, y, size, layer, ZS);
					case 0x24A: return new object_24A(x, y, size, layer, ZS);
					case 0x24B: return new object_24B(x, y, size, layer, ZS);
					case 0x24C: return new object_24C(x, y, size, layer, ZS);
					case 0x24D: return new object_24D(x, y, size, layer, ZS);
					case 0x24E: return new object_24E(x, y, size, layer, ZS);
					case 0x24F: return new object_24F(x, y, size, layer, ZS);
					case 0x250: return new object_250(x, y, size, layer, ZS);
					case 0x251: return new object_251(x, y, size, layer, ZS);
					case 0x252: return new object_252(x, y, size, layer, ZS);
					case 0x253: return new object_253(x, y, size, layer, ZS);
					case 0x254: return new object_254(x, y, size, layer, ZS);
					case 0x255: return new object_255(x, y, size, layer, ZS);
					case 0x256: return new object_256(x, y, size, layer, ZS);
					case 0x257: return new object_257(x, y, size, layer, ZS);
					case 0x258: return new object_258(x, y, size, layer, ZS);
					case 0x259: return new object_259(x, y, size, layer, ZS);
					case 0x25A: return new object_25A(x, y, size, layer, ZS);
					case 0x25B: return new object_25B(x, y, size, layer, ZS);
					case 0x25C: return new object_25C(x, y, size, layer, ZS);
					case 0x25D: return new object_25D(x, y, size, layer, ZS);
					case 0x25E: return new object_25E(x, y, size, layer, ZS);
					case 0x25F: return new object_25F(x, y, size, layer, ZS);
					case 0x260: return new object_260(x, y, size, layer, ZS);
					case 0x261: return new object_261(x, y, size, layer, ZS);
					case 0x262: return new object_262(x, y, size, layer, ZS);
					case 0x263: return new object_263(x, y, size, layer, ZS);
					case 0x264: return new object_264(x, y, size, layer, ZS);
					case 0x265: return new object_265(x, y, size, layer, ZS);
					case 0x266: return new object_266(x, y, size, layer, ZS);
					case 0x267: return new object_267(x, y, size, layer, ZS);
					case 0x268: return new object_268(x, y, size, layer, ZS);
					case 0x269: return new object_269(x, y, size, layer, ZS);
					case 0x26A: return new object_26A(x, y, size, layer, ZS);
					case 0x26B: return new object_26B(x, y, size, layer, ZS);
					case 0x26C: return new object_26C(x, y, size, layer, ZS);
					case 0x26D: return new object_26D(x, y, size, layer, ZS);
					case 0x26E: return new object_26E(x, y, size, layer, ZS);
					case 0x26F: return new object_26F(x, y, size, layer, ZS);
					case 0x270: return new object_270(x, y, size, layer, ZS);
					case 0x271: return new object_271(x, y, size, layer, ZS);
					case 0x272: return new object_272(x, y, size, layer, ZS);
					case 0x273: return new object_273(x, y, size, layer, ZS);
					case 0x274: return new object_274(x, y, size, layer, ZS);
					case 0x275: return new object_275(x, y, size, layer, ZS);
					case 0x276: return new object_276(x, y, size, layer, ZS);
					case 0x277: return new object_277(x, y, size, layer, ZS);
					case 0x278: return new object_278(x, y, size, layer, ZS);
					case 0x279: return new object_279(x, y, size, layer, ZS);
					case 0x27A: return new object_27A(x, y, size, layer, ZS);
					case 0x27B: return new object_27B(x, y, size, layer, ZS);
					case 0x27C: return new object_27C(x, y, size, layer, ZS);
					case 0x27D: return new object_27D(x, y, size, layer, ZS);
					case 0x27E: return new object_27E(x, y, size, layer, ZS);
				}
			}
			else if ((oid & 0x100) == 0x100) // Subtype2
			{
				return new Subtype2_Multiple(oid, x, y, 0, layer, ZS);
			}

			return null;
		}

		public void DrawFloor2()
		{
			byte layer = 1;
			byte f = (byte) (floor2 << 4);
			//int f = 1024+ (floor2 << 4);
			//x x 4
			Tile floorTile1 = new Tile(ZS.ROM[ZS.Offsets.tile_address + f], ZS.ROM[ZS.Offsets.tile_address + f + 1]);
			Tile floorTile2 = new Tile(ZS.ROM[ZS.Offsets.tile_address + f + 2], ZS.ROM[ZS.Offsets.tile_address + f + 3]);
			Tile floorTile3 = new Tile(ZS.ROM[ZS.Offsets.tile_address + f + 4], ZS.ROM[ZS.Offsets.tile_address + f + 5]);
			Tile floorTile4 = new Tile(ZS.ROM[ZS.Offsets.tile_address + f + 6], ZS.ROM[ZS.Offsets.tile_address + f + 7]);

			Tile floorTile5 = new Tile(ZS.ROM[ZS.Offsets.tile_address_floor + f], ZS.ROM[ZS.Offsets.tile_address_floor + f + 1]);
			Tile floorTile6 = new Tile(ZS.ROM[ZS.Offsets.tile_address_floor + f + 2], ZS.ROM[ZS.Offsets.tile_address_floor + f + 3]);
			Tile floorTile7 = new Tile(ZS.ROM[ZS.Offsets.tile_address_floor + f + 4], ZS.ROM[ZS.Offsets.tile_address_floor + f + 5]);
			Tile floorTile8 = new Tile(ZS.ROM[ZS.Offsets.tile_address_floor + f + 6], ZS.ROM[ZS.Offsets.tile_address_floor + f + 7]);

			for (int xx = 0; xx < 16; xx++)
			{
				for (int yy = 0; yy < 32; yy++)
				{
					floorTile1.SetTile((xx * 4), (yy * 2), layer, ZS);
					floorTile2.SetTile((xx * 4) + 1, (yy * 2), layer, ZS);
					floorTile3.SetTile((xx * 4) + 2, (yy * 2), layer, ZS);
					floorTile4.SetTile((xx * 4) + 3, (yy * 2), layer, ZS);

					floorTile5.SetTile((xx * 4), (yy * 2) + 1, layer, ZS);
					floorTile6.SetTile((xx * 4) + 1, (yy * 2) + 1, layer, ZS);
					floorTile7.SetTile((xx * 4) + 2, (yy * 2) + 1, layer, ZS);
					floorTile8.SetTile((xx * 4) + 3, (yy * 2) + 1, layer, ZS);
				}
			}
		}

		public void DrawFloor1()
		{
			byte layer = 0;
			byte f = (byte) (floor1 << 4);
			//int f = 1024 + (floor1<<4);
			//x x 4
			Tile floorTile1 = new Tile(ZS.ROM[ZS.Offsets.tile_address + f], ZS.ROM[ZS.Offsets.tile_address + f + 1]);
			Tile floorTile2 = new Tile(ZS.ROM[ZS.Offsets.tile_address + f + 2], ZS.ROM[ZS.Offsets.tile_address + f + 3]);
			Tile floorTile3 = new Tile(ZS.ROM[ZS.Offsets.tile_address + f + 4], ZS.ROM[ZS.Offsets.tile_address + f + 5]);
			Tile floorTile4 = new Tile(ZS.ROM[ZS.Offsets.tile_address + f + 6], ZS.ROM[ZS.Offsets.tile_address + f + 7]);

			Tile floorTile5 = new Tile(ZS.ROM[ZS.Offsets.tile_address_floor + f], ZS.ROM[ZS.Offsets.tile_address_floor + f + 1]);
			Tile floorTile6 = new Tile(ZS.ROM[ZS.Offsets.tile_address_floor + f + 2], ZS.ROM[ZS.Offsets.tile_address_floor + f + 3]);
			Tile floorTile7 = new Tile(ZS.ROM[ZS.Offsets.tile_address_floor + f + 4], ZS.ROM[ZS.Offsets.tile_address_floor + f + 5]);
			Tile floorTile8 = new Tile(ZS.ROM[ZS.Offsets.tile_address_floor + f + 6], ZS.ROM[ZS.Offsets.tile_address_floor + f + 7]);

			for (int xx = 0; xx < 16; xx++)
			{
				for (int yy = 0; yy < 32; yy++)
				{
					floorTile1.SetTile((xx * 4), (yy * 2), layer, ZS);
					floorTile2.SetTile((xx * 4) + 1, (yy * 2), layer, ZS);
					floorTile3.SetTile((xx * 4) + 2, (yy * 2), layer, ZS);
					floorTile4.SetTile((xx * 4) + 3, (yy * 2), layer, ZS);

					floorTile5.SetTile((xx * 4), (yy * 2) + 1, layer, ZS);
					floorTile6.SetTile((xx * 4) + 1, (yy * 2) + 1, layer, ZS);
					floorTile7.SetTile((xx * 4) + 2, (yy * 2) + 1, layer, ZS);
					floorTile8.SetTile((xx * 4) + 3, (yy * 2) + 1, layer, ZS);
				}
			}
		}

		public void Draw()
		{
			// TODO: Add somehting here?
		}

		public void loadHeader()
		{
			// Sddress of the room header
			int headerPointer = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.room_header_pointer, 3]);

			int address = (ZS.ROM[ZS.Offsets.room_header_pointers_bank] << 16) | ZS.ROM[headerPointer + (index * 2), 2];

			header_location = address.SNEStoPC();

			bg2 = (byte) ((ZS.ROM[header_location] >> 5) & 0x07);
			collision = (byte) ((ZS.ROM[header_location] >> 2) & 0x07);
			light = ((ZS.ROM[header_location]) & 0x01) == 1;

			if (light)
			{
				bg2 = Constants.LayerMergeDarkRoom;
			}

			palette = (byte) (ZS.ROM[header_location + 1] & 0x3F);
			blockset = ZS.ROM[header_location + 2];
			spriteset = ZS.ROM[header_location + 3];
			effect = ZS.ROM[header_location + 4];
			tag1 = ZS.ROM[header_location + 5];
			tag2 = ZS.ROM[header_location + 6];

			holewarp_plane = (byte) ((ZS.ROM[header_location + 7]) & 0x03);
			staircase_plane[0] = (byte) ((ZS.ROM[header_location + 7] >> 2) & 0x03);
			staircase_plane[1] = (byte) ((ZS.ROM[header_location + 7] >> 4) & 0x03);
			staircase_plane[2] = (byte) ((ZS.ROM[header_location + 7] >> 6) & 0x03);
			staircase_plane[3] = (byte) ((ZS.ROM[header_location + 8]) & 0x03);

			holewarp = ZS.ROM[header_location + 9];
			staircase_rooms[0] = ZS.ROM[header_location + 10];
			staircase_rooms[1] = ZS.ROM[header_location + 11];
			staircase_rooms[2] = ZS.ROM[header_location + 12];
			staircase_rooms[3] = ZS.ROM[header_location + 13];
		}

		public object Clone()
		{
			return this;
			//using (var ms = new MemoryStream())
			//{
			//	var formatter = new BinaryFormatter();
			//	formatter.Serialize(ms, this);
			//	ms.Position = 0;
			//	return (Room) formatter.Deserialize(ms);
			//}
		}

		public void CloneToFile(string file)
		{
			using (var ms = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(ms, this);
			}
		}

		public void Delete()
		{
			tilesObjects.Clear();
			tilesLayoutObjects.Clear();
			pot_items.Clear();
			sprites.Clear();
		}

		~Room()
		{
			for (int i = 0; i < chest_list.Count; i++)
			{
				chest_list[i] = null;
			}
			for (int i = 0; i < tilesObjects.Count; i++)
			{
				tilesObjects[i] = null;
			}
			for (int i = 0; i < tilesLayoutObjects.Count; i++)
			{
				tilesLayoutObjects[i].tiles.Clear();
				tilesLayoutObjects[i] = null;
			}
			for (int i = 0; i < sprites.Count; i++)
			{
				sprites[i] = null;
			}
			for (int i = 0; i < pot_items.Count; i++)
			{
				pot_items[i] = null;
			}
			for (int i = 0; i < selectedObject.Count; i++)
			{
				selectedObject[i] = null;
			}

			chest_list = null;
			tilesObjects = null;
			tilesLayoutObjects = null;
			sprites = null;
			pot_items = null;
			selectedObject = null;
		}
	}


	[Serializable]
	public class StaircaseRoom
	{
		public int x;
		public int y;
		public string name;

		public StaircaseRoom(int x, int y, string name)
		{
			this.x = x;
			this.y = y;
			this.name = name;
		}
	}

	[Serializable]
	public class ChestData
	{
		public bool bigChest = false;
		public byte itemIn = 0;

		public ChestData(byte itemIn, bool bigChest)
		{
			this.itemIn = itemIn;
			this.bigChest = bigChest;
		}
	}
}
