﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using ZeldaFullEditor.Rooms;
using static ZeldaFullEditor.Room_Object;

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
        private Background2 _bg2;

        public TagKey tag1 { get; set; }

        public TagKey tag2 { get; set; }

        public CollisionKey collision { get; set; }

        public EffectKey effect { get; set; }

        private byte _holewarp;
        private byte _holewarp_plane;

        private short _messageid;

        public bool damagepit { get; set; }

        public bool sortsprites { get; set; }

        public byte[] staircase_rooms = new byte[4];

        private byte[] staircase_plane = new byte[4];

        short[] stairsObjects = new short[] { 0x139, 0x138, 0x13B, 0x12E, 0x12D };
        public List<StaircaseRoom> staircaseRooms = new List<StaircaseRoom>();

        public int roomSize = 0;

        public List<CollisionRectangle> collision_rectangles = new List<CollisionRectangle>();

        public byte layout
        {
            get => _layout;
            set => _layout = Utils.Clamp(value, 0, 7);
        }

        public byte floor1
        {
            get => _floor1;
            set => _floor1 = Utils.Clamp(value, 0, 15);
        }

        public byte floor2
        {
            get => _floor2;
            set => _floor2 = Utils.Clamp(value, 0, 15);
        }

        public byte blockset
        {
            get => _blockset;
            set => _blockset = Utils.Clamp(value, 0, 23);
        }

        public byte spriteset
        {
            get => _spriteset;
            set => _spriteset = Utils.Clamp(value, 0, 64);
        }

        public byte palette
        {
            get => _palette;
            set => _palette = Utils.Clamp(value, 0, 71);
        }

        public Background2 bg2
        {
            get => _bg2;
            set
            {
                _bg2 = value;
                if (_bg2 == Background2.DarkRoom)
                {
                    light = true;
                }
                else
                {
                    light = false;
                }
            }
        }

        public short messageid
        {
            get => _messageid;
            set => _messageid = Utils.Clamp(value, 0, 397);
        }

        public byte holewarp
        {
            get => _holewarp;
            set => _holewarp = Utils.Clamp(value, 0, 255);
        }

        public byte staircase1
        {
            get => staircase_rooms[0];
            set => staircase_rooms[0] = Utils.Clamp(value, 0, 255);
        }

        public byte staircase2
        {
            get => staircase_rooms[1];
            set => staircase_rooms[1] = Utils.Clamp(value, 0, 255);
        }

        public byte staircase3
        {
            get => staircase_rooms[2];
            set => staircase_rooms[2] = Utils.Clamp(value, 0, 255);
        }

        public byte staircase4
        {
            get => staircase_rooms[3];
            set => staircase_rooms[3] = Utils.Clamp(value, 0, 255);
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

        public Room(int index, string fromExported = "")
        {
            this.fromExported = fromExported;
            this.index = index;
            loadHeader();
            loadLayoutObjects();

            if (fromExported != "")
            {
                Console.WriteLine(fromExported + "\\ExportedRooms\\" + "room" + index.ToString("D3") + ".bin");

                if (File.Exists(fromExported + "\\ExportedRooms\\" + "room" + index.ToString("D3") + ".bin"))
                {
                    using (FileStream fs = new FileStream(fromExported + "\\ExportedRooms\\" + "room" + index.ToString("D3") + ".bin", FileMode.Open, FileAccess.Read))
                    {
                        byte[] data = new byte[fs.Length];
                        fs.Read(data, 0, data.Length);
                        fs.Close();
                        loadTilesObjectsFromArray(data);
                        Console.WriteLine("Room " + index.ToString("D3" + " Loaded from exported files"));
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

            for (int i = 0; i < 4096; i++)
            {
                collisionMap[i] = 0xFF; // Null byte
            }

            addSprites();
            addBlocks();
            addTorches();
            setObjectsRoom();
            addPotsItems();
            isdamagePit();
            //palette
            byte aux1 = (byte)ROM.DATA[Constants.dungeons_palettes_groups + (palette * 4) + 1];
            byte aux2 = (byte)ROM.DATA[Constants.dungeons_palettes_groups + (palette * 4) + 2];
            byte aux3 = (byte)ROM.DATA[Constants.dungeons_palettes_groups + (palette * 4) + 3];

            this.name = ROMStructure.roomsNames[index];
            messageid = (short)((ROM.DATA[Constants.messages_id_dungeon + (index * 2) + 1] << 8) + ROM.DATA[Constants.messages_id_dungeon + (index * 2)]);

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
            int pitCount = (ROM.DATA[Constants.pit_count] / 2);
            int pitPointer = (ROM.DATA[Constants.pit_pointer + 2] << 16) + (ROM.DATA[Constants.pit_pointer + 1] << 8) + (ROM.DATA[Constants.pit_pointer]);
            pitPointer = Utils.SnesToPc(pitPointer);

            for (int i = 0; i < pitCount; i++)
            {
                if (((ROM.DATA[pitPointer + 1 + (i * 2)] << 8) + (ROM.DATA[pitPointer + (i * 2)])) == index)
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

            public string ToString()
            {
                string temp = "[width: " + this.width + " height: " + this.height + " index_data: " + this.index_data + " TileData: ";
                foreach (ushort u in tile_data)
                {
                    temp += u + ", ";
                }

                temp = temp.Remove(temp.Length - 2, 2);

                temp += "]";
                return temp;
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
                        collision_rectangles.Add(new CollisionRectangle(1, 1, (ushort)i, new_tile_data));
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
                        collision_rectangles.Add(new CollisionRectangle((byte)rectangle_width, (byte)rectangle_height, (ushort)i, _new_tile_data));
                    }
                }
            }

            if (output)
            {
                Console.WriteLine("\nGenerate Rectangles:");
                foreach (CollisionRectangle each_rect in collision_rectangles)
                {
                    Console.WriteLine((int)each_rect.index_data + " : " + (int)each_rect.width + " x " + (int)each_rect.height);
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
            int room_pointer = Constants.customCollisionRoomPointers;
            room_pointer = room_pointer + (3 * index);

            int data_pointer = ROM.ReadLong(room_pointer);

            if (data_pointer >= Constants.customCollisionDataPosition)
            {
                Console.WriteLine("valid Custom collision data pointer found for room " + index + " " + data_pointer.ToString("X"));

                while (ROM.ReadShort(Utils.SnesToPc(data_pointer)) != 0x00FFFF)
                {
                    int offset = ROM.ReadShort(Utils.SnesToPc(data_pointer));
                    data_pointer += 2;

                    int width = ROM.ReadByte(Utils.SnesToPc(data_pointer));
                    data_pointer += 1;
                    int height = ROM.ReadByte(Utils.SnesToPc(data_pointer));
                    data_pointer += 1;

                    int i = 0;
                    while (i < height)
                    {
                        int j = 0;
                        while (j < width)
                        {
                            collisionMap[(offset + j + (i * 64))] = (byte)(ROM.ReadByte(Utils.SnesToPc(data_pointer)));
                            data_pointer += 1;

                            j++;
                        }

                        i++;
                    }
                }
            }
        }

        public unsafe void reloadAnimatedGfx()
        {
            int gfxanimatedPointer = (ROM.DATA[Constants.gfx_animated_pointer + 2] << 16) + (ROM.DATA[Constants.gfx_animated_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_animated_pointer]);
            gfxanimatedPointer = Utils.SnesToPc(gfxanimatedPointer);
            byte* newPdata = (byte*)GFX.allgfx16Ptr.ToPointer(); // Turn gfx16 (all 222 of them)
            byte* sheetsData = (byte*)GFX.currentgfx16Ptr.ToPointer(); // Into "room gfx16" 16 of them

            int data = 0;
            while (data < 512)
            {
                byte mapByte = newPdata[data + (92 * 2048) + (512 * GFX.animated_frame)];
                sheetsData[data + (7 * 2048)] = mapByte;

                mapByte = newPdata[data + (ROM.DATA[gfxanimatedPointer + blockset] * 2048) + (512 * GFX.animated_frame)];
                sheetsData[data + (7 * 2048) - 512] = mapByte;
                data++;
            }
        }

        public void reloadGfx(byte entrance_blockset = 0xFF)
        {
            for (int i = 0; i < 8; i++)
            {
                blocks[i] = GfxGroups.mainGfx[blockset][i];
                if (i >= 6 && i <= 6)
                {
                    if (entrance_blockset != 0xFF) //3-6
                    {
                        // 6 is wrong for the entrance? -NOP need to fix that 
                        // TODO: Find why this is wrong - Thats because of the stairs need to find a workaround
                        if (GfxGroups.roomGfx[entrance_blockset][i - 3] != 0)
                        {
                            blocks[i] = GfxGroups.roomGfx[entrance_blockset][i - 3];
                        }
                    }
                }
            }

            blocks[8] = 115 + 0; blocks[9] = 115 + 10; blocks[10] = 115 + 6; blocks[11] = 115 + 7; // Static Sprites Blocksets (fairy,pot,ect...)
            for (int i = 0; i < 4; i++)
            {
                blocks[12 + i] = (byte)(GfxGroups.spriteGfx[spriteset + 64][i] + 115);
            } // 12-16 sprites

            unsafe
            {
                byte* newPdata = (byte*)GFX.allgfx16Ptr.ToPointer(); // Turn gfx16 (all 222 of them)
                byte* sheetsData = (byte*)GFX.currentgfx16Ptr.ToPointer(); // Into "room gfx16" 16 of them
                int sheetPos = 0;
                for (int i = 0; i < 16; i++)
                {
                    int d = 0;
                    while (d < 2048)
                    {
                        // NOTE LOAD BLOCKSETS SOMEWHERE FIRST
                        byte mapByte = newPdata[d + (blocks[i] * 2048)];
                        if (i < 4) //removed switch
                        {
                            mapByte += 0x88;
                        } // Last line of 6, first line of 7 ?

                        sheetsData[d + (sheetPos * 2048)] = mapByte;
                        d++;
                    }

                    sheetPos++;
                }

                reloadAnimatedGfx();
            }
        }

        public void addSprites()
        {
            int spritePointer = (04 << 16) + (ROM.DATA[Constants.rooms_sprite_pointer + 1] << 8) + (ROM.DATA[Constants.rooms_sprite_pointer]);
            // 09 bank ? Need to check if HM change that
            int sprite_address_snes = (09 << 16) +
            (ROM.DATA[spritePointer + (index * 2) + 1] << 8) +
            ROM.DATA[spritePointer + (index * 2)];

            int sprite_address = Utils.SnesToPc(sprite_address_snes);
            sortsprites = ROM.DATA[sprite_address] == 1;
            sprite_address += 1;

            while (true)
            {
                byte b1 = ROM.DATA[sprite_address];
                byte b2 = ROM.DATA[sprite_address + 1];
                byte b3 = ROM.DATA[sprite_address + 2];

                if (b1 == 0xFF) { break; }

                sprites.Add(new Sprite(this, b3, (byte)(b2 & 0x1F), (byte)(b1 & 0x1F), (byte)(((b2 & 0xE0) >> 5) + ((b1 & 0x60) >> 2)), (byte)((b1 & 0x80) >> 7)));

                if (sprites.Count > 1)
                {
                    Sprite spr = sprites[sprites.Count - 1];
                    Sprite prevSprite = sprites[sprites.Count - 2];

                    if (spr.id == 0xE4 && spr.x == 0x00 && spr.y == 0x1E && spr.layer == 1 && ((spr.subtype)) == 0x18)
                    {
                        if (prevSprite != null)
                        {
                            prevSprite.keyDrop = 1;
                            sprites.RemoveAt(sprites.Count - 1);
                        }
                    }

                    if (spr.id == 0xE4 && spr.x == 0x00 && spr.y == 0x1D && spr.layer == 1 && ((spr.subtype)) == 0x18)
                    {
                        if (prevSprite != null)
                        {
                            prevSprite.keyDrop = 2;
                            sprites.RemoveAt(sprites.Count - 1);
                        }
                    }
                }

                sprite_address += 3;
            }
        }

        public Dictionary<DungeonLimits, int> GetLimitedObjectCounts()
        {
            var limList = DungeonLimitsHelper.CreateCounter();

            foreach (var obj in tilesObjects) {
                DungeonLimits dl = obj.LimitClass;

                switch (dl) {
					case DungeonLimits.Chest:
					case DungeonLimits.StarTile:
					case DungeonLimits.StairsNorth:
					case DungeonLimits.StairsSouth:
					case DungeonLimits.StairsTransition:
					case DungeonLimits.SomariaLine:
					case DungeonLimits.Watergate:
					case DungeonLimits.WaterVomit:
						limList[dl]++;
						break;

					case DungeonLimits.GeneralManipulable:
						limList[DungeonLimits.GeneralManipulable]++;
						break;

					case DungeonLimits.GeneralManipulable4x:
						limList[DungeonLimits.GeneralManipulable] += 4;
						break;

					case DungeonLimits.GeneralManipulableLengthy:
						limList[DungeonLimits.GeneralManipulable] += obj.Size + 1;
						break;

					case DungeonLimits.Doors:
						limList[DungeonLimits.Doors]++;
                        break;

					case DungeonLimits.SpecialDoors:
						limList[DungeonLimits.SpecialDoors]++;
						limList[DungeonLimits.Doors]++;
                        break;

					case DungeonLimits.ExitMods:
						limList[DungeonLimits.ExitMods]++;
						limList[DungeonLimits.Doors]++;
                        break;
				}
            }


            foreach (var sp in sprites) {
                if (sp.IsOverlord) {
					limList[DungeonLimits.Overlords]++;
				} else {
					limList[DungeonLimits.Sprites]++;
				}
			}

            return limList;
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
                if (!layer1)
                {
                    if (spr.layer == 0)
                    {
                        continue;
                    }
                }
                if (!layer2)
                {
                    if (spr.layer == 1)
                    {
                        continue;
                    }
                }
                //if (spr.id != 0xE4)
                //{
                spr.Draw();
                //} // 1D big key
                if (spr.keyDrop == 1)
                {
                    spr.DrawKey();
                }
                if (spr.keyDrop == 2)
                {
                    spr.DrawKey(true);
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
                        if ((tilesObjects[j].id & 0xF00) == 0xF00) // Type3
                        {
                            // xxxxxxii yyyyyyii 11111iii
                            byte b3 = (byte)(o.id >> 4);
                            byte b1 = (byte)((o.X << 2) + (o.id & 0x03));
                            byte b2 = (byte)((o.Y << 2) + ((o.id >> 2) & 0x03));

                            bytes[0] = b1;
                            bytes[1] = b2;
                            bytes[2] = b3;
                        }
                        else if ((tilesObjects[j].id & 0x100) == 0x100) // Type2
                        {
                            // 111111xx xxxxyyyy yyiiiiii
                            byte b1 = (byte)(0xFC + (((o.X & 0x30) >> 4)));
                            byte b2 = (byte)(((o.X & 0x0F) << 4) + ((o.Y & 0x3C) >> 2));
                            byte b3 = (byte)(((o.Y & 0x03) << 6) + ((o.id & 0x3F))); // wtf? 

                            bytes[0] = b1;
                            bytes[1] = b2;
                            bytes[2] = b3;
                        }
                        else // Type1
                        {
                            // xxxxxxss yyyyyyss iiiiiiii
                            if (o.Size > 16)
                            {
                                o.Size = 0;
                            }

                            byte b1 = (byte)((o.X << 2) + ((o.Size >> 2) & 0x03));
                            byte b2 = (byte)((o.Y << 2) + (o.Size & 0x03));
                            byte b3 = (byte)(o.id);

                            bytes[0] = b1;
                            bytes[1] = b2;
                            bytes[2] = b3;
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
                    if (o.Layer == (LayerType)layer)
                    {
                        // If we encounter a door store it somewhere else for now and wait the end of objects layer1
                        if ((tilesObjects[j].options & ObjectOption.Door) == ObjectOption.Door)
                        {
                            byte p = (o as object_door).door_dir;
                            doorfound = true;
                            byte b1 = (byte)((((o as object_door).door_pos) << 3) + p);
                            byte b2 = ((o as object_door).door_type);
                            doorsBytes.Add(b1);
                            doorsBytes.Add(b2);
                        }
                        else
                        {
                            if ((tilesObjects[j].id & 0xF00) == 0xF00) // Type3
                            {
                                // xxxxxxii yyyyyyii 11111iii
                                byte b3 = (byte)(o.id >> 4);
                                byte b1 = (byte)((o.X << 2) + (o.id & 0x03));
                                byte b2 = (byte)((o.Y << 2) + ((o.id >> 2) & 0x03));

                                objectsBytes.Add(b1);
                                objectsBytes.Add(b2);
                                objectsBytes.Add(b3);
                            }
                            else if ((tilesObjects[j].id & 0x100) == 0x100) // Type2
                            {
                                // 111111xx xxxxyyyy yyiiiiii
                                byte b1 = (byte)(0xFC + (((o.X & 0x30) >> 4)));
                                byte b2 = (byte)(((o.X & 0x0F) << 4) + ((o.Y & 0x3C) >> 2));
                                byte b3 = (byte)(((o.Y & 0x03) << 6) + ((o.id & 0x3F))); // wtf? 

                                objectsBytes.Add(b1);
                                objectsBytes.Add(b2);
                                objectsBytes.Add(b3);
                            }
                            else // Type1
                            {
                                // xxxxxxss yyyyyyss iiiiiiii
                                if (o.Size > 16)
                                {
                                    o.Size = 0;
                                }

                                byte b1 = (byte)((o.X << 2) + ((o.Size >> 2) & 0x03));
                                byte b2 = (byte)((o.Y << 2) + (o.Size & 0x03));
                                byte b3 = (byte)(o.id);

                                objectsBytes.Add(b1);
                                objectsBytes.Add(b2);
                                objectsBytes.Add(b3);
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
            bool found_door = false;
            bool found_door2 = false;
            bool found_door3 = false;

            byte floorbyte = (byte)((floor2 << 4) + floor1);
            byte layoutbyte = (byte)(layout << 2);
            objectsBytes.Add(floorbyte);
            objectsBytes.Add(layoutbyte);

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

                foreach (byte b in doorsBytes)
                {
                    objectsBytes.Add(b);
                }
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
            short pos = 0;

            int xf = 0;
            int yf = 0;
            int wf = 0;
            int hf = 0;
            for (int i = 0; i < 24; i += 2) // Top
            {
                pos = (short)(((ROM.DATA[(0x197E + 1 + (i & 0xFF))] << 8) + ROM.DATA[(0x197E + (i & 0xFF))]) / 2);
                hf = 24;
                wf = 32;
                float n = (((float)pos / 64) - (byte)(pos / 64)) * 64;
                rects[(i / 2)] = new Rectangle(((byte)n + xf) * 8, (byte)((pos / 64) + yf) * 8, wf, hf);
            }

            xf = 0;
            yf = 0;
            wf = 0;
            hf = 0;
            for (int i = 0; i < 24; i += 2) // Down
            {
                pos = (short)(((ROM.DATA[(0x1996 + 1 + (i & 0xFF))] << 8) + ROM.DATA[(0x1996 + (i & 0xFF))]) / 2);
                yf = 1;
                hf = 24;
                wf = 32;
                float n = (((float)pos / 64) - (byte)(pos / 64)) * 64;
                rects[(i / 2) + 12] = new Rectangle(((byte)n + xf) * 8, (byte)((pos / 64) + yf) * 8, wf, hf);
            }

            xf = 0;
            yf = 0;
            wf = 0;
            hf = 0;
            for (int i = 0; i < 24; i += 2) // Left
            {
                pos = (short)(((ROM.DATA[(0x19AE + 1 + (i & 0xFF))] << 8) + ROM.DATA[(0x19AE + (i & 0xFF))]) / 2);
                hf = 32;
                wf = 24;
                float n = (((float)pos / 64) - (byte)(pos / 64)) * 64;
                rects[(i / 2) + 24] = new Rectangle(((byte)n + xf) * 8, (byte)((pos / 64) + yf) * 8, wf, hf);
            }

            xf = 0;
            yf = 0;
            wf = 0;
            hf = 0;
            for (int i = 0; i < 24; i += 2) // Right
            {
                xf = 1;
                pos = (short)(((ROM.DATA[(0x19C6 + 1 + (i & 0xFF))] << 8) + ROM.DATA[(0x19C6 + (i & 0xFF))]) / 2);
                hf = 32;
                wf = 24;
                float n = (((float)pos / 64) - (byte)(pos / 64)) * 64;
                rects[(i / 2) + 36] = new Rectangle(((byte)n + xf) * 8, (byte)((pos / 64) + yf) * 8, wf, hf);
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
            int pos1 = (ROM.DATA[Constants.blocks_pointer1 + 2] << 16) + (ROM.DATA[Constants.blocks_pointer1 + 1] << 8) + (ROM.DATA[Constants.blocks_pointer1]);
            pos1 = Utils.SnesToPc(pos1);
            int pos2 = (ROM.DATA[Constants.blocks_pointer2 + 2] << 16) + (ROM.DATA[Constants.blocks_pointer2 + 1] << 8) + (ROM.DATA[Constants.blocks_pointer2]);
            pos2 = Utils.SnesToPc(pos2);
            int pos3 = (ROM.DATA[Constants.blocks_pointer3 + 2] << 16) + (ROM.DATA[Constants.blocks_pointer3 + 1] << 8) + (ROM.DATA[Constants.blocks_pointer3]);
            pos3 = Utils.SnesToPc(pos3);
            int pos4 = (ROM.DATA[Constants.blocks_pointer4 + 2] << 16) + (ROM.DATA[Constants.blocks_pointer4 + 1] << 8) + (ROM.DATA[Constants.blocks_pointer4]);
            pos4 = Utils.SnesToPc(pos4);

            for (int i = 0; i < 0x80; i += 1)
            {
                blocksdata[i] = (ROM.DATA[i + pos1]);
                blocksdata[i + 0x80] = (ROM.DATA[i + pos2]);

                if (i + 0x100 < maxCount)
                {
                    blocksdata[i + 0x100] = (ROM.DATA[i + pos3]);
                }
                if (i + 0x180 < maxCount)
                {
                    blocksdata[i + 0x180] = (ROM.DATA[i + pos4]);
                }
            }
        }

        public void addBlocks()
        {
            // 288

            int blocksCount = (short)((ROM.DATA[Constants.blocks_length + 1] << 8) + ROM.DATA[Constants.blocks_length]);
            byte[] blocksdata = new byte[blocksCount];
            //int blocksCount = (short)((ROM.DATA[Constants.blocks_length + 1] << 8) + ROM.DATA[Constants.blocks_length]);
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
                    Room_Object r = addObject(0x0E00, (byte)(px), (byte)(py), 0, (byte)((b4 & 0x20) >> 5));

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
            int bytes_count = (ROM.DATA[Constants.torches_length_pointer + 1] << 8) + ROM.DATA[Constants.torches_length_pointer];

            for (int i = 0; i < bytes_count; i += 2)
            {
                byte b1 = ROM.DATA[Constants.torch_data + i];
                byte b2 = ROM.DATA[Constants.torch_data + i + 1];

                if (b1 == 0xFF && b2 == 0xFF) { continue; }

                if (((b2 << 8) + b1) == index) // If roomindex = indexread
                {
                    i += 2;
                    while (true)
                    {
                        b1 = ROM.DATA[Constants.torch_data + i];
                        b2 = ROM.DATA[Constants.torch_data + i + 1];

                        if (b1 == 0xFF && b2 == 0xFF) { break; }
                        int address = ((b2 & 0x1F) << 8 | b1) >> 1;
                        int px = address % 64;
                        int py = address >> 6;

                        Room_Object r = addObject(0x150, (byte)px, (byte)py, 0, (byte)((b2 & 0x20) >> 5));
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
                        b1 = ROM.DATA[Constants.torch_data + i];
                        b2 = ROM.DATA[Constants.torch_data + i + 1];
                        if (b1 == 0xFF && b2 == 0xFF) { break; }
                        i += 2;
                    }
                }
            }
        }


        public void addPotsItems()
        {

            int ptrOfPointers = ROM.ReadLong(Constants.room_items_pointers_ptr);
            int item_address_snes = (ptrOfPointers & 0xFF0000) +
            (ROM.DATA[Utils.SnesToPc(ptrOfPointers) + (index * 2) + 1] << 8) +
            ROM.DATA[Utils.SnesToPc(ptrOfPointers) + (index * 2)];

            int item_address = Utils.SnesToPc(item_address_snes);

            while (true)
            {
                byte b1 = ROM.DATA[item_address];
                byte b2 = ROM.DATA[item_address + 1];
                byte b3 = ROM.DATA[item_address + 2];
                //0x20 = bg2

                if (b1 == 0xFF && b2 == 0xFF) { break; }
                int address = ((b2 & 0x1F) << 8 | b1) >> 1;
                int px = address % 64;
                int py = address >> 6;
                PotItem p = new PotItem(b3, (byte)((px)), (byte)((py)), (b2 & 0x20) == 0x20);
                if (p.bg2)
                {
                    p.layer = 1;
                }
                else
                {
                    p.layer = 0;
                }

                pot_items.Add(p);

                // Bit 7 is set if the object is a special object holes, switches
                // After 0x16 it goes to 0x80

                item_address += 3;
            }
        }

        public void loadChests(ref List<ChestData> chests_in_room)
        {
            int cpos = (ROM.DATA[Constants.chests_data_pointer1 + 2] << 16) + (ROM.DATA[Constants.chests_data_pointer1 + 1] << 8) + (ROM.DATA[Constants.chests_data_pointer1]);
            cpos = Utils.SnesToPc(cpos);
            int clength = (ROM.DATA[Constants.chests_length_pointer + 1] << 8) + (ROM.DATA[Constants.chests_length_pointer]);

            for (int i = 0; i < clength; i++)
            {
                if ((((ROM.DATA[cpos + (i * 3) + 1] << 8) + (ROM.DATA[cpos + (i * 3)])) & 0x7FFF) == index)
                {
                    //There's a chest in that room !
                    bool big = false;
                    if ((((ROM.DATA[cpos + (i * 3) + 1] << 8) + (ROM.DATA[cpos + (i * 3)])) & 0x8000) == 0x8000) // ????? 
                    {
                        big = true;
                    }

                    chests_in_room.Add(new ChestData(ROM.DATA[cpos + (i * 3) + 2], big));
                }
            }
        }

        public void loadTilesObjects(bool floor = true)
        {
            // Adddress of the room objects
            int objectPointer = (ROM.DATA[Constants.room_object_pointer + 2] << 16) + (ROM.DATA[Constants.room_object_pointer + 1] << 8) + (ROM.DATA[Constants.room_object_pointer]);
            objectPointer = Utils.SnesToPc(objectPointer);
            int room_address = objectPointer + (index * 3);

            int tile_address =
                (ROM.DATA[room_address + 2] << 16) +
                (ROM.DATA[room_address + 1] << 8) +
                ROM.DATA[room_address];

            int objects_location = Utils.SnesToPc(tile_address);

            if (objects_location == 0x52CA2)
            {
                Console.WriteLine("Room ID : " + index);
            }

            if (floor)
            {
                floor1 = (byte)(ROM.DATA[objects_location] & 0x0F);
                floor2 = (byte)((ROM.DATA[objects_location] >> 4) & 0x0F);
            }

            layout = (byte)((ROM.DATA[objects_location + 1] >> 2) & 0x07);

            List<ChestData> chests_in_room = new List<ChestData>();
            loadChests(ref chests_in_room);

            staircaseRooms.Clear();
            int nbr_of_staircase = 0;

            int pos = objects_location + 2;
            byte b1 = 0;
            byte b2 = 0;
            byte b3 = 0;
            byte posX = 0;
            byte posY = 0;
            byte sizeX = 0;
            byte sizeY = 0;
            byte sizeXY = 0;
            ushort oid = 0;
            int layer = 0;
            bool door = false;
            bool endRead = false;

            while (!endRead)
            {
                b1 = ROM.DATA[pos];
                b2 = ROM.DATA[pos + 1];

                if (b1 == 0xFF && b2 == 0xFF)
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

                b3 = ROM.DATA[pos + 2];
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
                    if (b3 >= 0xF8)
                    {
                        oid = (ushort)((b3 << 4) | 0x80 + (((b2 & 0x03) << 2) + ((b1 & 0x03))));
                        posX = (byte)((b1 & 0xFC) >> 2);
                        posY = (byte)((b2 & 0xFC) >> 2);
                        sizeXY = (byte)((((b1 & 0x03) << 2) + (b2 & 0x03)));
                    }
                    else // Subtype1
                    {
                        oid = b3;
                        posX = (byte)((b1 & 0xFC) >> 2);
                        posY = (byte)((b2 & 0xFC) >> 2);
                        sizeX = (byte)((b1 & 0x03));
                        sizeY = (byte)((b2 & 0x03));
                        sizeXY = (byte)(((sizeX << 2) + sizeY));
                    }

                    if (b1 >= 0xFC) // Subtype2 (not scalable? )
                    {
                        oid = (ushort)((b3 & 0x3F) + 0x100);
                        posX = (byte)(((b2 & 0xF0) >> 4) + ((b1 & 0x3) << 4));
                        posY = (byte)(((b2 & 0x0F) << 2) + ((b3 & 0xC0) >> 6));
                        sizeXY = 0;
                    }

                    if (oid == 0x31 || oid == 0x32)
                    {
                        Console.WriteLine("0x31 or 0x32 found in room  " + index.ToString("X3"));
                    }

                    Room_Object r = addObject(oid, posX, posY, sizeXY, (byte)layer);
                    //GFX.objects[oid] = true;

                    if (r != null)
                    {
                        tilesObjects.Add(r);

                    }

                    foreach (short stair in stairsObjects)
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

                    // IF Object is a chest loaded and there's object in the list chest
                    if (oid == 0xF99)
                    {
                        if (chests_in_room.Count > 0)
                        {
                            tilesObjects[tilesObjects.Count - 1].options |= ObjectOption.Chest;
                            chest_list.Add(new Chest(posX, posY, chests_in_room[0].itemIn, false));
                            chests_in_room.RemoveAt(0);
                        }
                    }
                    else if (oid == 0xFB1)
                    {
                        if (chests_in_room.Count > 0)
                        {
                            tilesObjects[tilesObjects.Count - 1].options |= ObjectOption.Chest;
                            chest_list.Add(new Chest((byte)(posX + 1), posY, chests_in_room[0].itemIn, true));
                            chests_in_room.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    //byte door_pos = b1;//(byte)((b1 & 0xF0) >> 3);
                    //byte door_type = b2;
                    tilesObjects.Add(new object_door((ushort)((b2 << 8) + b1), 0, 0, 0, (byte)layer));
                    continue;
                }
            }
        }

        public void loadTilesObjectsFromArray(byte[] DATA, bool floor = true)
        {
            // Adddress of the room objects
            tilesObjects.Clear();
            floor1 = (byte)(DATA[0] & 0x0F);
            floor2 = (byte)((DATA[0] >> 4) & 0x0F);

            layout = (byte)((DATA[1] >> 2) & 0x07);

            List<ChestData> chests_in_room = new List<ChestData>();
            loadChests(ref chests_in_room);

            staircaseRooms.Clear();
            int nbr_of_staircase = 0;

            int pos = 2;
            byte b1 = 0;
            byte b2 = 0;
            byte b3 = 0;
            byte posX = 0;
            byte posY = 0;
            byte sizeX = 0;
            byte sizeY = 0;
            byte sizeXY = 0;
            ushort oid = 0;
            int layer = 0;
            bool door = false;
            bool endRead = false;

            while (!endRead)
            {
                b1 = DATA[pos];
                b2 = DATA[pos + 1];
                if (b1 == 0xFF && b2 == 0xFF)
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

                b3 = DATA[pos + 2];
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
                    if (b3 >= 0xF8) // Subtype3
                    {
                        oid = (ushort)((b3 << 4) | 0x80 + (((b2 & 0x03) << 2) + ((b1 & 0x03))));
                        posX = (byte)((b1 & 0xFC) >> 2);
                        posY = (byte)((b2 & 0xFC) >> 2);
                        sizeXY = (byte)((((b1 & 0x03) << 2) + (b2 & 0x03)));
                    }
                    else // Subtype1
                    {
                        oid = b3;
                        posX = (byte)((b1 & 0xFC) >> 2);
                        posY = (byte)((b2 & 0xFC) >> 2);
                        sizeX = (byte)((b1 & 0x03));
                        sizeY = (byte)((b2 & 0x03));
                        sizeXY = (byte)(((sizeX << 2) + sizeY));
                    }

                    if (b1 >= 0xFC) // Subtype2 (not scalable? )
                    {
                        oid = (ushort)((b3 & 0x3F) + 0x100);
                        posX = (byte)(((b2 & 0xF0) >> 4) + ((b1 & 0x3) << 4));
                        posY = (byte)(((b2 & 0x0F) << 2) + ((b3 & 0xC0) >> 6));
                        sizeXY = 0;
                    }

                    Room_Object r = addObject(oid, posX, posY, sizeXY, (byte)layer);
                    if (r != null)
                    {
                        tilesObjects.Add(r);
                    }

                    foreach (short stair in stairsObjects)
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

                    // IF Object is a chest loaded and there's object in the list chest
                    if (oid == 0xF99)
                    {
                        if (chests_in_room.Count > 0)
                        {
                            tilesObjects[tilesObjects.Count - 1].options |= ObjectOption.Chest;
                            chest_list.Add(new Chest(posX, posY, chests_in_room[0].itemIn, false));
                            chests_in_room.RemoveAt(0);
                        }
                    }
                    else if (oid == 0xFB1)
                    {
                        if (chests_in_room.Count > 0)
                        {
                            tilesObjects[tilesObjects.Count - 1].options |= ObjectOption.Chest;
                            chest_list.Add(new Chest((byte)(posX + 1), posY, chests_in_room[0].itemIn, true));
                            chests_in_room.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    //byte door_pos = b1;//(byte)((b1 & 0xF0) >> 3);
                    //byte door_type = b2;
                    tilesObjects.Add(new object_door((ushort)((b2 << 8) + b1), 0, 0, 0, (byte)layer));
                    continue;
                }
            }
        }

        public void loadLayoutObjects(bool floor = true) // That is dumb!
        {
            int pointer = ROM.ReadLong(Constants.room_object_layout_pointer);
            pointer = Utils.SnesToPc(pointer);
            int layout_address = ROM.ReadLong(pointer + (layout * 3));

            int layout_location = Utils.SnesToPc(layout_address);

            int pos = layout_location;
            byte b1 = 0;
            byte b2 = 0;
            byte b3 = 0;
            byte posX = 0;
            byte posY = 0;
            byte sizeX = 0;
            byte sizeY = 0;
            byte sizeXY = 0;
            ushort oid = 0;
            int layer = 0;

            while (true)
            {
                b1 = ROM.DATA[pos];
                b2 = ROM.DATA[pos + 1];

                if (b1 == 0xFF && b2 == 0xFF)
                {
                    break;
                }

                b3 = ROM.DATA[pos + 2];
                pos += 3; // We jump to layer2

                if (b3 >= 0xF8)
                {
                    oid = (ushort)((b3 << 4) | 0x80 + (((b2 & 0x03) << 2) + ((b1 & 0x03))));
                    posX = (byte)((b1 & 0xFC) >> 2);
                    posY = (byte)((b2 & 0xFC) >> 2);
                    sizeXY = (byte)((((b1 & 0x03) << 2) + (b2 & 0x03)));
                }
                else // Subtype1
                {
                    oid = b3;
                    posX = (byte)((b1 & 0xFC) >> 2);
                    posY = (byte)((b2 & 0xFC) >> 2);
                    sizeX = (byte)((b1 & 0x03));
                    sizeY = (byte)((b2 & 0x03));
                    sizeXY = (byte)(((sizeX << 2) + sizeY));
                }
                if (b1 >= 0xFC) // Subtype2 (not scalable?)
                {
                    oid = (ushort)((b3 & 0x3F) + 0x100);
                    posX = (byte)(((b2 & 0xF0) >> 4) + ((b1 & 0x3) << 4));
                    posY = (byte)(((b2 & 0x0F) << 2) + ((b3 & 0xC0) >> 6));
                    sizeXY = 0;
                }

                Room_Object r = addObject(oid, posX, posY, sizeXY, (byte)layer);
                if (r != null)
                {
                    r.options |= ObjectOption.Bgr;
                    tilesLayoutObjects.Add(r);
                }
            }
        }

        public Room_Object addObject(ushort oid, byte x, byte y, byte size, byte layer)
        {
            if (oid == 0xE00) // Block
            {
                return new object_Block(oid, x, y, 0, layer);
            }

            if (oid <= 0xFF)
            {
                switch (oid)
                {
                    case 0x00:
                        return new object_00(oid, x, y, size, layer);

                    case 0x01:
                        return new object_01(oid, x, y, size, layer);

                    case 0x02:
                        return new object_02(oid, x, y, size, layer);

                    case 0x03:
                        return new object_03(oid, x, y, size, layer);

                    case 0x04:
                        return new object_04(oid, x, y, size, layer);

                    case 0x05:
                        return new object_05(oid, x, y, size, layer);

                    case 0x06:
                        return new object_06(oid, x, y, size, layer);

                    case 0x07:
                        return new object_07(oid, x, y, size, layer);

                    case 0x08:
                        return new object_08(oid, x, y, size, layer);

                    case 0x09:
                        return new object_09(oid, x, y, size, layer);

                    case 0x0A:
                        return new object_0A(oid, x, y, size, layer);

                    case 0x0B:
                        return new object_0B(oid, x, y, size, layer);

                    case 0x0C:
                        return new object_0C(oid, x, y, size, layer);

                    case 0x0D:
                        return new object_0D(oid, x, y, size, layer);

                    case 0x0E:
                        return new object_0E(oid, x, y, size, layer);

                    case 0x0F:
                        return new object_0F(oid, x, y, size, layer);

                    case 0x10:
                        return new object_10(oid, x, y, size, layer);

                    case 0x11:
                        return new object_11(oid, x, y, size, layer);

                    case 0x12:
                        return new object_12(oid, x, y, size, layer);

                    case 0x13:
                        return new object_13(oid, x, y, size, layer);

                    case 0x14:
                        return new object_14(oid, x, y, size, layer);

                    case 0x15:
                        return new object_15(oid, x, y, size, layer);

                    case 0x16:
                        return new object_16(oid, x, y, size, layer);

                    case 0x17:
                        return new object_17(oid, x, y, size, layer);

                    case 0x18:
                        return new object_18(oid, x, y, size, layer);

                    case 0x19:
                        return new object_19(oid, x, y, size, layer);

                    case 0x1A:
                        return new object_1A(oid, x, y, size, layer);

                    case 0x1B:
                        return new object_1B(oid, x, y, size, layer);

                    case 0x1C:
                        return new object_1C(oid, x, y, size, layer);

                    case 0x1D:
                        return new object_1D(oid, x, y, size, layer);

                    case 0x1E:
                        return new object_1E(oid, x, y, size, layer);

                    case 0x1F:
                        return new object_1F(oid, x, y, size, layer);

                    case 0x20:
                        return new object_20(oid, x, y, size, layer);

                    case 0x21:
                        return new object_21(oid, x, y, size, layer);

                    case 0x22:
                        return new object_22(oid, x, y, size, layer);

                    case 0x23:
                        return new object_23(oid, x, y, size, layer);

                    case 0x24:
                        return new object_24(oid, x, y, size, layer);

                    case 0x25:
                        return new object_25(oid, x, y, size, layer);

                    case 0x26:
                        return new object_26(oid, x, y, size, layer);

                    case 0x27:
                        return new object_27(oid, x, y, size, layer);

                    case 0x28:
                        return new object_28(oid, x, y, size, layer);

                    case 0x29:
                        return new object_29(oid, x, y, size, layer);

                    case 0x2A:
                        return new object_2A(oid, x, y, size, layer);

                    case 0x2B:
                        return new object_2B(oid, x, y, size, layer);

                    case 0x2C:
                        return new object_2C(oid, x, y, size, layer);

                    case 0x2D:
                        return new object_2D(oid, x, y, size, layer);

                    case 0x2E:
                        return new object_2E(oid, x, y, size, layer);

                    case 0x2F:
                        return new object_2F(oid, x, y, size, layer);

                    case 0x30:
                        return new object_30(oid, x, y, size, layer);

                    case 0x31:
                        return new object_31(oid, x, y, size, layer);

                    case 0x32:
                        return new object_32(oid, x, y, size, layer);

                    case 0x33:
                        return new object_33(oid, x, y, size, layer);

                    case 0x34:
                        return new object_34(oid, x, y, size, layer);

                    case 0x35:
                        return new object_35(oid, x, y, size, layer);

                    case 0x36:
                        return new object_36(oid, x, y, size, layer);

                    case 0x37:
                        return new object_37(oid, x, y, size, layer);

                    case 0x38:
                        return new object_38(oid, x, y, size, layer);

                    case 0x39:
                        return new object_39(oid, x, y, size, layer);

                    case 0x3A:
                        return new object_3A(oid, x, y, size, layer);

                    case 0x3B:
                        return new object_3B(oid, x, y, size, layer);

                    case 0x3C:
                        return new object_3C(oid, x, y, size, layer);

                    case 0x3D:
                        return new object_3D(oid, x, y, size, layer);

                    case 0x3E:
                        return new object_3E(oid, x, y, size, layer);

                    case 0x3F:
                        return new object_3F(oid, x, y, size, layer);

                    case 0x40:
                        return new object_40(oid, x, y, size, layer);

                    case 0x41:
                        return new object_41(oid, x, y, size, layer);

                    case 0x42:
                        return new object_42(oid, x, y, size, layer);

                    case 0x43:
                        return new object_43(oid, x, y, size, layer);

                    case 0x44:
                        return new object_44(oid, x, y, size, layer);

                    case 0x45:
                        return new object_45(oid, x, y, size, layer);

                    case 0x46:
                        return new object_46(oid, x, y, size, layer);

                    case 0x47:
                        return new object_47(oid, x, y, size, layer);

                    case 0x48:
                        return new object_48(oid, x, y, size, layer);

                    case 0x49:
                        return new object_49(oid, x, y, size, layer);

                    case 0x4A:
                        return new object_4A(oid, x, y, size, layer);

                    case 0x4B:
                        return new object_4B(oid, x, y, size, layer);

                    case 0x4C:
                        return new object_4C(oid, x, y, size, layer);

                    case 0x4D:
                        return new object_4D(oid, x, y, size, layer);

                    case 0x4E:
                        return new object_4E(oid, x, y, size, layer);

                    case 0x4F:
                        return new object_4F(oid, x, y, size, layer);

                    case 0x50:
                        // Console.WriteLine("50 " + index);
                        return new object_50(oid, x, y, size, layer);

                    case 0x51:
                        return new object_51(oid, x, y, size, layer);

                    case 0x52:
                        return new object_52(oid, x, y, size, layer);

                    case 0x53:
                        return new object_53(oid, x, y, size, layer);

                    case 0x54:
                        return new object_54(oid, x, y, size, layer);

                    case 0x55:
                        return new object_55(oid, x, y, size, layer);

                    case 0x56:
                        return new object_56(oid, x, y, size, layer);

                    case 0x57:
                        return new object_57(oid, x, y, size, layer);

                    case 0x58:
                        return new object_58(oid, x, y, size, layer);

                    case 0x59:
                        return new object_59(oid, x, y, size, layer);

                    case 0x5A:
                        return new object_5A(oid, x, y, size, layer);

                    case 0x5B:
                        return new object_5B(oid, x, y, size, layer);

                    case 0x5C:
                        return new object_5C(oid, x, y, size, layer);

                    case 0x5D:
                        return new object_5D(oid, x, y, size, layer);

                    case 0x5E:
                        return new object_5E(oid, x, y, size, layer);

                    case 0x5F:
                        return new object_5F(oid, x, y, size, layer);

                    case 0x60:
                        return new object_60(oid, x, y, size, layer);

                    case 0x61:
                        return new object_61(oid, x, y, size, layer);

                    case 0x62:
                        return new object_62(oid, x, y, size, layer);

                    case 0x63:
                        return new object_63(oid, x, y, size, layer);

                    case 0x64:
                        return new object_64(oid, x, y, size, layer);

                    case 0x65:
                        return new object_65(oid, x, y, size, layer);

                    case 0x66:
                        return new object_66(oid, x, y, size, layer);

                    case 0x67:
                        return new object_67(oid, x, y, size, layer);

                    case 0x68:
                        return new object_68(oid, x, y, size, layer);

                    case 0x69:
                        return new object_69(oid, x, y, size, layer);

                    case 0x6A:
                        return new object_6A(oid, x, y, size, layer);

                    case 0x6B:
                        return new object_6B(oid, x, y, size, layer);

                    case 0x6C:
                        return new object_6C(oid, x, y, size, layer);

                    case 0x6D:
                        return new object_6D(oid, x, y, size, layer);

                    case 0x6E:
                        return new object_6E(oid, x, y, size, layer);

                    case 0x6F:
                        return new object_6F(oid, x, y, size, layer);

                    case 0x70:
                        return new object_70(oid, x, y, size, layer);

                    case 0x71:
                        return new object_71(oid, x, y, size, layer);

                    case 0x72:
                        return new object_72(oid, x, y, size, layer);

                    case 0x73:
                        return new object_73(oid, x, y, size, layer);

                    case 0x74:
                        return new object_74(oid, x, y, size, layer);

                    case 0x75:
                        return new object_75(oid, x, y, size, layer);

                    case 0x76:
                        return new object_76(oid, x, y, size, layer);

                    case 0x77:
                        return new object_77(oid, x, y, size, layer);

                    case 0x78:
                        return new object_78(oid, x, y, size, layer);

                    case 0x79:
                        return new object_79(oid, x, y, size, layer);

                    case 0x7A:
                        return new object_7A(oid, x, y, size, layer);

                    case 0x7B:
                        return new object_7B(oid, x, y, size, layer);

                    case 0x7C:
                        return new object_7C(oid, x, y, size, layer);

                    case 0x7D:
                        return new object_7D(oid, x, y, size, layer);

                    case 0x7E:
                        return new object_7E(oid, x, y, size, layer);

                    case 0x7F:
                        return new object_7F(oid, x, y, size, layer);

                    case 0x80:
                        return new object_80(oid, x, y, size, layer);

                    case 0x81:
                        return new object_81(oid, x, y, size, layer);

                    case 0x82:
                        return new object_82(oid, x, y, size, layer);

                    case 0x83:
                        return new object_83(oid, x, y, size, layer);

                    case 0x84:
                        return new object_84(oid, x, y, size, layer);

                    case 0x85:
                        return new object_85(oid, x, y, size, layer);

                    case 0x86:
                        return new object_86(oid, x, y, size, layer);

                    case 0x87:
                        return new object_87(oid, x, y, size, layer);

                    case 0x88:
                        return new object_88(oid, x, y, size, layer);

                    case 0x89:
                        return new object_89(oid, x, y, size, layer);

                    case 0x8A:
                        return new object_8A(oid, x, y, size, layer);

                    case 0x8B:
                        return new object_8B(oid, x, y, size, layer);

                    case 0x8C:
                        return new object_8C(oid, x, y, size, layer);

                    case 0x8D:
                        return new object_8D(oid, x, y, size, layer);

                    case 0x8E:
                        return new object_8E(oid, x, y, size, layer);

                    case 0x8F:
                        return new object_8F(oid, x, y, size, layer);

                    case 0x90:
                        return new object_90(oid, x, y, size, layer);

                    case 0x91:
                        return new object_91(oid, x, y, size, layer);

                    case 0x92:
                        return new object_92(oid, x, y, size, layer);

                    case 0x93:
                        return new object_93(oid, x, y, size, layer);

                    case 0x94:
                        return new object_94(oid, x, y, size, layer);

                    case 0x95:
                        return new object_95(oid, x, y, size, layer);

                    case 0x96:
                        return new object_96(oid, x, y, size, layer);

                    case 0x97:
                        return new object_97(oid, x, y, size, layer);

                    case 0x98:
                        return new object_98(oid, x, y, size, layer);

                    case 0x99:
                        return new object_99(oid, x, y, size, layer);

                    case 0x9A:
                        return new object_9A(oid, x, y, size, layer);

                    case 0x9B:
                        return new object_9B(oid, x, y, size, layer);

                    case 0x9C:
                        return new object_9C(oid, x, y, size, layer);

                    case 0x9D:
                        return new object_9D(oid, x, y, size, layer);

                    case 0x9E:
                        return new object_9E(oid, x, y, size, layer);

                    case 0x9F:
                        return new object_9F(oid, x, y, size, layer);

                    case 0xA0:
                        return new object_A0(oid, x, y, size, layer);

                    case 0xA1:
                        return new object_A1(oid, x, y, size, layer);

                    case 0xA2:
                        return new object_A2(oid, x, y, size, layer);

                    case 0xA3:
                        return new object_A3(oid, x, y, size, layer);

                    case 0xA4:
                        return new object_A4(oid, x, y, size, layer);

                    case 0xA5:
                        return new object_A5(oid, x, y, size, layer);

                    case 0xA6:
                        return new object_A6(oid, x, y, size, layer);

                    case 0xA7:
                        return new object_A7(oid, x, y, size, layer);

                    case 0xA8:
                        return new object_A8(oid, x, y, size, layer);

                    case 0xA9:
                        return new object_A9(oid, x, y, size, layer);

                    case 0xAA:
                        return new object_AA(oid, x, y, size, layer);

                    case 0xAB:
                        return new object_AB(oid, x, y, size, layer);

                    case 0xAC:
                        return new object_AC(oid, x, y, size, layer);

                    case 0xAD:
                        return new object_AD(oid, x, y, size, layer);

                    case 0xAE:
                        return new object_AE(oid, x, y, size, layer);

                    case 0xAF:
                        return new object_AF(oid, x, y, size, layer);

                    case 0xB0:
                        return new object_B0(oid, x, y, size, layer);

                    case 0xB1:
                        return new object_B1(oid, x, y, size, layer);

                    case 0xB2:
                        return new object_B2(oid, x, y, size, layer);

                    case 0xB3:
                        return new object_B3(oid, x, y, size, layer);

                    case 0xB4:
                        return new object_B4(oid, x, y, size, layer);

                    case 0xB5:
                        return new object_B5(oid, x, y, size, layer);

                    case 0xB6:
                        return new object_B6(oid, x, y, size, layer);

                    case 0xB7:
                        return new object_B7(oid, x, y, size, layer);

                    case 0xB8:
                        return new object_B8(oid, x, y, size, layer);

                    case 0xB9:
                        return new object_B9(oid, x, y, size, layer);

                    case 0xBA:
                        return new object_BA(oid, x, y, size, layer);

                    case 0xBB:
                        return new object_BB(oid, x, y, size, layer);

                    case 0xBC:
                        return new object_BC(oid, x, y, size, layer);

                    case 0xBD:
                        return new object_BD(oid, x, y, size, layer);

                    case 0xBE:
                        return new object_BE(oid, x, y, size, layer);

                    case 0xBF:
                        return new object_BF(oid, x, y, size, layer);

                    case 0xC0:
                        return new object_C0(oid, x, y, size, layer);

                    case 0xC1:
                        return new object_C1(oid, x, y, size, layer);

                    case 0xC2:
                        return new object_C2(oid, x, y, size, layer);

                    case 0xC3:
                        return new object_C3(oid, x, y, size, layer);

                    case 0xC4:
                        return new object_C4(oid, x, y, size, layer);

                    case 0xC5:
                        return new object_C5(oid, x, y, size, layer);

                    case 0xC6:
                        return new object_C6(oid, x, y, size, layer);

                    case 0xC7:
                        return new object_C7(oid, x, y, size, layer);

                    case 0xC8:
                        return new object_C8(oid, x, y, size, layer);

                    case 0xC9:
                        return new object_C9(oid, x, y, size, layer);

                    case 0xCA:
                        return new object_CA(oid, x, y, size, layer);

                    case 0xCB:
                        return new object_CB(oid, x, y, size, layer);

                    case 0xCC:
                        return new object_CC(oid, x, y, size, layer);

                    case 0xCD:
                        return new object_CD(oid, x, y, size, layer);

                    case 0xCE:
                        return new object_CE(oid, x, y, size, layer);

                    case 0xCF:
                        return new object_CF(oid, x, y, size, layer);

                    case 0xD0:
                        return new object_D0(oid, x, y, size, layer);

                    case 0xD1:
                        return new object_D1(oid, x, y, size, layer);

                    case 0xD2:
                        return new object_D2(oid, x, y, size, layer);

                    case 0xD3:
                        return new object_D3(oid, x, y, size, layer);

                    case 0xD4:
                        return new object_D4(oid, x, y, size, layer);

                    case 0xD5:
                        return new object_D5(oid, x, y, size, layer);

                    case 0xD6:
                        return new object_D6(oid, x, y, size, layer);

                    case 0xD7:
                        return new object_D7(oid, x, y, size, layer);

                    case 0xD8:
                        return new object_D8(oid, x, y, size, layer);

                    case 0xD9:
                        return new object_D9(oid, x, y, size, layer);

                    case 0xDA:
                        return new object_DA(oid, x, y, size, layer);

                    case 0xDB:
                        return new object_DB(oid, x, y, size, layer);

                    case 0xDC:
                        return new object_DC(oid, x, y, size, layer);

                    case 0xDD:
                        return new object_DD(oid, x, y, size, layer);

                    case 0xDE:
                        return new object_DE(oid, x, y, size, layer);

                    case 0xDF:
                        return new object_DF(oid, x, y, size, layer);

                    case 0xE0:
                        return new object_E0(oid, x, y, size, layer);

                    case 0xE1:
                        return new object_E1(oid, x, y, size, layer);

                    case 0xE2:
                        return new object_E2(oid, x, y, size, layer);

                    case 0xE3:
                        return new object_E3(oid, x, y, size, layer);

                    case 0xE4:
                        return new object_E4(oid, x, y, size, layer);

                    case 0xE5:
                        return new object_E5(oid, x, y, size, layer);

                    case 0xE6:
                        return new object_E6(oid, x, y, size, layer);

                    case 0xE7:
                        return new object_E7(oid, x, y, size, layer);

                    case 0xE8:
                        return new object_E8(oid, x, y, size, layer);

                    case 0xE9:
                        return new object_E9(oid, x, y, size, layer);

                    case 0xEA:
                        return new object_EA(oid, x, y, size, layer);

                    case 0xEB:
                        return new object_EB(oid, x, y, size, layer);

                    case 0xEC:
                        return new object_EC(oid, x, y, size, layer);

                    case 0xED:
                        return new object_ED(oid, x, y, size, layer);

                    case 0xEE:
                        return new object_EE(oid, x, y, size, layer);

                    case 0xEF:
                        return new object_EF(oid, x, y, size, layer);

                    case 0xF0:
                        return new object_F0(oid, x, y, size, layer);

                    case 0xF1:
                        return new object_F0(oid, x, y, size, layer);

                    case 0xF2:
                        return new object_F0(oid, x, y, size, layer);

                    case 0xF3:
                        return new object_F0(oid, x, y, size, layer);

                    case 0xF4:
                        return new object_F0(oid, x, y, size, layer);

                    case 0xF5:
                        return new object_F0(oid, x, y, size, layer);

                    case 0xF6:
                        return new object_F0(oid, x, y, size, layer);

                    case 0xF7:
                        return new object_F0(oid, x, y, size, layer);
                }
            }
            else
            {
                if (oid >= 0xF00) // Subtype3
                {
                    switch (oid)
                    {
                        case 0xF80:
                            return new object_F80(oid, x, y, size, layer);

                        case 0xF81:
                            return new object_F81(oid, x, y, size, layer);

                        case 0xF82:
                            return new object_F82(oid, x, y, size, layer);

                        case 0xF83:
                            return new object_F83(oid, x, y, size, layer);

                        case 0xF84:
                            return new object_F84(oid, x, y, size, layer);

                        case 0xF85:
                            return new object_F85(oid, x, y, size, layer);

                        case 0xF86:
                            return new object_F86(oid, x, y, size, layer);

                        case 0xF87:
                            return new object_F87(oid, x, y, size, layer);

                        case 0xF88:
                            return new object_F88(oid, x, y, size, layer);

                        case 0xF89:
                            return new object_F89(oid, x, y, size, layer);

                        case 0xF8A:
                            return new object_F8A(oid, x, y, size, layer);

                        case 0xF8B:
                            return new object_F8B(oid, x, y, size, layer);

                        case 0xF8C:
                            return new object_F8C(oid, x, y, size, layer);

                        case 0xF8D:
                            return new object_F8D(oid, x, y, size, layer);

                        case 0xF8E:
                            return new object_F8E(oid, x, y, size, layer);

                        case 0xF8F:
                            return new object_F8F(oid, x, y, size, layer);

                        case 0xF90:
                            return new object_F90(oid, x, y, size, layer);

                        case 0xF91:
                            return new object_F91(oid, x, y, size, layer);

                        case 0xF92:
                            return new object_F92(oid, x, y, size, layer);

                        case 0xF93:
                            return new object_F93(oid, x, y, size, layer);

                        case 0xF94:
                            return new object_F94(oid, x, y, size, layer);

                        case 0xF95:
                            return new object_F95(oid, x, y, size, layer);

                        case 0xF96:
                            return new object_F96(oid, x, y, size, layer);

                        case 0xF97:
                            return new object_F97(oid, x, y, size, layer);

                        case 0xF98:
                            return new object_F98(oid, x, y, size, layer);

                        case 0xF99:
                            return new object_F99(oid, x, y, size, layer);

                        case 0xF9A:
                            return new object_F9A(oid, x, y, size, layer);

                        case 0xF9B:
                            return new object_F9B(oid, x, y, size, layer);

                        case 0xF9C:
                            return new object_F9C(oid, x, y, size, layer);

                        case 0xF9D:
                            return new object_F9D(oid, x, y, size, layer);

                        case 0xF9E:
                            return new object_F9E(oid, x, y, size, layer);

                        case 0xF9F:
                            return new object_F9F(oid, x, y, size, layer);

                        case 0xFA0:
                            return new object_FA0(oid, x, y, size, layer);

                        case 0xFA1:
                            return new object_FA1(oid, x, y, size, layer);

                        case 0xFA2:
                            return new object_FA2(oid, x, y, size, layer);

                        case 0xFA3:
                            return new object_FA3(oid, x, y, size, layer);

                        case 0xFA4:
                            return new object_FA4(oid, x, y, size, layer);

                        case 0xFA5:
                            return new object_FA5(oid, x, y, size, layer);

                        case 0xFA6:
                            return new object_FA6(oid, x, y, size, layer);

                        case 0xFA7:
                            return new object_FA7(oid, x, y, size, layer);

                        case 0xFA8:
                            return new object_FA8(oid, x, y, size, layer);

                        case 0xFA9:
                            return new object_FA9(oid, x, y, size, layer);

                        case 0xFAA:
                            return new object_FAA(oid, x, y, size, layer);

                        case 0xFAB:
                            return new object_FAB(oid, x, y, size, layer);

                        case 0xFAC:
                            return new object_FAC(oid, x, y, size, layer);

                        case 0xFAD:
                            return new object_FAD(oid, x, y, size, layer);

                        case 0xFAE:
                            return new object_FAE(oid, x, y, size, layer);

                        case 0xFAF:
                            return new object_FAF(oid, x, y, size, layer);

                        case 0xFB0:
                            return new object_FB0(oid, x, y, size, layer);

                        case 0xFB1:
                            return new object_FB1(oid, x, y, size, layer);

                        case 0xFB2:
                            return new object_FB2(oid, x, y, size, layer);

                        case 0xFB3:
                            return new object_FB3(oid, x, y, size, layer);

                        case 0xFB4:
                            return new object_FB4(oid, x, y, size, layer);

                        case 0xFB5:
                            return new object_FB5(oid, x, y, size, layer);

                        case 0xFB6:
                            return new object_FB6(oid, x, y, size, layer);

                        case 0xFB7:
                            return new object_FB7(oid, x, y, size, layer);

                        case 0xFB8:
                            return new object_FB8(oid, x, y, size, layer);

                        case 0xFB9:
                            return new object_FB9(oid, x, y, size, layer);

                        case 0xFBA:
                            return new object_FBA(oid, x, y, size, layer);

                        case 0xFBB:
                            return new object_FBA(oid, x, y, size, layer);

                        case 0xFBC:
                            return new object_FBC(oid, x, y, size, layer);

                        case 0xFBD:
                            return new object_FBD(oid, x, y, size, layer);

                        case 0xFBE:
                            return new object_FBE(oid, x, y, size, layer);

                        case 0xFBF:
                            return new object_FBF(oid, x, y, size, layer);

                        case 0xFC0:
                            return new object_FC0(oid, x, y, size, layer);

                        case 0xFC1:
                            return new object_FC1(oid, x, y, size, layer);

                        case 0xFC2:
                            return new object_FC2(oid, x, y, size, layer);

                        case 0xFC3:
                            return new object_FC3(oid, x, y, size, layer);

                        case 0xFC4:
                            return new object_FC4(oid, x, y, size, layer);

                        case 0xFC5:
                            return new object_FC5(oid, x, y, size, layer);

                        case 0xFC6:
                            return new object_FC6(oid, x, y, size, layer);

                        case 0xFC7:
                            return new object_FC7(oid, x, y, size, layer);

                        case 0xFC8:
                            return new object_FC8(oid, x, y, size, layer);

                        case 0xFC9:
                            return new object_FC9(oid, x, y, size, layer);

                        case 0xFCA:
                            return new object_FCA(oid, x, y, size, layer);

                        case 0xFCB:
                            return new object_FCB(oid, x, y, size, layer);

                        case 0xFCC:
                            return new object_FCC(oid, x, y, size, layer);

                        case 0xFCD:
                            return new object_FCD(oid, x, y, size, layer);

                        case 0xFCE:
                            return new object_FCE(oid, x, y, size, layer);

                        case 0xFCF:
                            return new object_FCF(oid, x, y, size, layer);

                        case 0xFD0:
                            return new object_FD0(oid, x, y, size, layer);

                        case 0xFD1:
                            return new object_FD1(oid, x, y, size, layer);

                        case 0xFD2:
                            return new object_FD2(oid, x, y, size, layer);

                        case 0xFD3:
                            return new object_FD3(oid, x, y, size, layer);

                        case 0xFD4:
                            return new object_FD4(oid, x, y, size, layer);

                        case 0xFD5:
                            return new object_FD5(oid, x, y, size, layer);

                        case 0xFD6:
                            return new object_FD6(oid, x, y, size, layer);

                        case 0xFD7:
                            return new object_FD7(oid, x, y, size, layer);

                        case 0xFD8:
                            return new object_FD8(oid, x, y, size, layer);

                        case 0xFD9:
                            return new object_FD9(oid, x, y, size, layer);

                        case 0xFDA:
                            return new object_FDA(oid, x, y, size, layer);

                        case 0xFDB:
                            return new object_FDB(oid, x, y, size, layer);

                        case 0xFDC:
                            return new object_FDC(oid, x, y, size, layer);

                        case 0xFDD:
                            return new object_FDD(oid, x, y, size, layer);

                        case 0xFDE:
                            return new object_FDE(oid, x, y, size, layer);

                        case 0xFDF:
                            return new object_FDF(oid, x, y, size, layer);

                        case 0xFE0:
                            return new object_FE0(oid, x, y, size, layer);

                        case 0xFE1:
                            return new object_FE1(oid, x, y, size, layer);

                        case 0xFE2:
                            return new object_FE2(oid, x, y, size, layer);

                        case 0xFE3:
                            return new object_FE3(oid, x, y, size, layer);

                        case 0xFE4:
                            return new object_FE4(oid, x, y, size, layer);

                        case 0xFE5:
                            return new object_FE5(oid, x, y, size, layer);

                        case 0xFE6:
                            return new object_FE6(oid, x, y, size, layer);

                        case 0xFE7:
                            return new object_FE7(oid, x, y, size, layer);

                        case 0xFE8:
                            return new object_FE8(oid, x, y, size, layer);

                        case 0xFE9:
                            return new object_FE9(oid, x, y, size, layer);

                        case 0xFEA:
                            return new object_FEA(oid, x, y, size, layer);

                        case 0xFEB:
                            return new object_FEB(oid, x, y, size, layer);

                        case 0xFEC:
                            return new object_FEC(oid, x, y, size, layer);

                        case 0xFED:
                            return new object_FED(oid, x, y, size, layer);

                        case 0xFEE:
                            return new object_FEE(oid, x, y, size, layer);

                        case 0xFEF:
                            return new object_FEF(oid, x, y, size, layer);

                        case 0xFF0:
                            return new object_FF0(oid, x, y, size, layer);

                        case 0xFF1:
                            return new object_FF1(oid, x, y, size, layer);

                        case 0xFF2:
                            return new object_FF2(oid, x, y, size, layer);

                        case 0xFF3:
                            return new object_FF3(oid, x, y, size, layer);

                        case 0xFF4:
                            return new object_FF4(oid, x, y, size, layer);

                        case 0xFF5:
                            return new object_FF5(oid, x, y, size, layer);

                        case 0xFF6:
                            return new object_FF6(oid, x, y, size, layer);

                        case 0xFF7:
                            return new object_FF7(oid, x, y, size, layer);

                        case 0xFF8:
                            return new object_FF8(oid, x, y, size, layer);

                        case 0xFF9:
                            return new object_FF9(oid, x, y, size, layer);

                        case 0xFFA:
                            return new object_FFA(oid, x, y, size, layer);

                        case 0xFFB:
                            return new object_FFB(oid, x, y, size, layer);

                        case 0xFFC:
                            return new object_FFC(oid, x, y, size, layer);

                        case 0xFFD:
                            return new object_FFD(oid, x, y, size, layer);

                        case 0xFFE:
                            return new object_FFE(oid, x, y, size, layer);
                    }
                }
                else if ((oid & 0x100) == 0x100) // Subtype2? non scalable
                {
                    return new Subtype2_Multiple(oid, x, y, 0, layer);
                }
            }

            return null;
        }

        public void DrawFloor2()
        {
            byte layer = 1;
            byte f = (byte)(floor2 << 4);
            //int f = 1024+ (floor2 << 4);
            //x x 4
            Tile floorTile1 = new Tile(ROM.DATA[Constants.tile_address + f], ROM.DATA[Constants.tile_address + f + 1]);
            Tile floorTile2 = new Tile(ROM.DATA[Constants.tile_address + f + 2], ROM.DATA[Constants.tile_address + f + 3]);
            Tile floorTile3 = new Tile(ROM.DATA[Constants.tile_address + f + 4], ROM.DATA[Constants.tile_address + f + 5]);
            Tile floorTile4 = new Tile(ROM.DATA[Constants.tile_address + f + 6], ROM.DATA[Constants.tile_address + f + 7]);

            Tile floorTile5 = new Tile(ROM.DATA[Constants.tile_address_floor + f], ROM.DATA[Constants.tile_address_floor + f + 1]);
            Tile floorTile6 = new Tile(ROM.DATA[Constants.tile_address_floor + f + 2], ROM.DATA[Constants.tile_address_floor + f + 3]);
            Tile floorTile7 = new Tile(ROM.DATA[Constants.tile_address_floor + f + 4], ROM.DATA[Constants.tile_address_floor + f + 5]);
            Tile floorTile8 = new Tile(ROM.DATA[Constants.tile_address_floor + f + 6], ROM.DATA[Constants.tile_address_floor + f + 7]);

            for (int xx = 0; xx < 16; xx++)
            {
                for (int yy = 0; yy < 32; yy++)
                {
                    floorTile1.SetTile((xx * 4), (yy * 2), layer); floorTile2.SetTile((xx * 4) + 1, (yy * 2), layer);
                    floorTile3.SetTile((xx * 4) + 2, (yy * 2), layer); floorTile4.SetTile((xx * 4) + 3, (yy * 2), layer);

                    floorTile5.SetTile((xx * 4), (yy * 2) + 1, layer); floorTile6.SetTile((xx * 4) + 1, (yy * 2) + 1, layer);
                    floorTile7.SetTile((xx * 4) + 2, (yy * 2) + 1, layer); floorTile8.SetTile((xx * 4) + 3, (yy * 2) + 1, layer);
                }
            }
        }

        public void DrawFloor1()
        {
            byte layer = 0;
            byte f = (byte)(floor1 << 4);
            //int f = 1024 + (floor1<<4);
            //x x 4
            Tile floorTile1 = new Tile(ROM.DATA[Constants.tile_address + f], ROM.DATA[Constants.tile_address + f + 1]);
            Tile floorTile2 = new Tile(ROM.DATA[Constants.tile_address + f + 2], ROM.DATA[Constants.tile_address + f + 3]);
            Tile floorTile3 = new Tile(ROM.DATA[Constants.tile_address + f + 4], ROM.DATA[Constants.tile_address + f + 5]);
            Tile floorTile4 = new Tile(ROM.DATA[Constants.tile_address + f + 6], ROM.DATA[Constants.tile_address + f + 7]);

            Tile floorTile5 = new Tile(ROM.DATA[Constants.tile_address_floor + f], ROM.DATA[Constants.tile_address_floor + f + 1]);
            Tile floorTile6 = new Tile(ROM.DATA[Constants.tile_address_floor + f + 2], ROM.DATA[Constants.tile_address_floor + f + 3]);
            Tile floorTile7 = new Tile(ROM.DATA[Constants.tile_address_floor + f + 4], ROM.DATA[Constants.tile_address_floor + f + 5]);
            Tile floorTile8 = new Tile(ROM.DATA[Constants.tile_address_floor + f + 6], ROM.DATA[Constants.tile_address_floor + f + 7]);

            for (int xx = 0; xx < 16; xx++)
            {
                for (int yy = 0; yy < 32; yy++)
                {
                    floorTile1.SetTile((xx * 4), (yy * 2), layer); floorTile2.SetTile((xx * 4) + 1, (yy * 2), layer);
                    floorTile3.SetTile((xx * 4) + 2, (yy * 2), layer); floorTile4.SetTile((xx * 4) + 3, (yy * 2), layer);

                    floorTile5.SetTile((xx * 4), (yy * 2) + 1, layer); floorTile6.SetTile((xx * 4) + 1, (yy * 2) + 1, layer);
                    floorTile7.SetTile((xx * 4) + 2, (yy * 2) + 1, layer); floorTile8.SetTile((xx * 4) + 3, (yy * 2) + 1, layer);
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
            int headerPointer = (ROM.DATA[Constants.room_header_pointer + 2] << 16) + (ROM.DATA[Constants.room_header_pointer + 1] << 8) + (ROM.DATA[Constants.room_header_pointer]);
            headerPointer = Utils.SnesToPc(headerPointer);

            int address = (ROM.DATA[Constants.room_header_pointers_bank] << 16) +
                            (ROM.DATA[(headerPointer + 1) + (index * 2)] << 8) +
                            ROM.DATA[(headerPointer) + (index * 2)];

            header_location = Utils.SnesToPc(address);

            bg2 = (Background2)((ROM.DATA[header_location] >> 5) & 0x07);
            collision = (CollisionKey)((ROM.DATA[header_location] >> 2) & 0x07);
            light = ((ROM.DATA[header_location]) & 0x01) == 1;

            if (light)
            {
                bg2 = Background2.DarkRoom;
            }

            palette = (byte)((ROM.DATA[header_location + 1] & 0x3F));
            blockset = (ROM.DATA[header_location + 2]);
            spriteset = (ROM.DATA[header_location + 3]);
            effect = (EffectKey)((ROM.DATA[header_location + 4]));
            tag1 = (TagKey)((ROM.DATA[header_location + 5]));
            tag2 = (TagKey)((ROM.DATA[header_location + 6]));

            holewarp_plane = (byte)((ROM.DATA[header_location + 7]) & 0x03);
            staircase_plane[0] = (byte)((ROM.DATA[header_location + 7] >> 2) & 0x03);
            staircase_plane[1] = (byte)((ROM.DATA[header_location + 7] >> 4) & 0x03);
            staircase_plane[2] = (byte)((ROM.DATA[header_location + 7] >> 6) & 0x03);
            staircase_plane[3] = (byte)((ROM.DATA[header_location + 8]) & 0x03);

            if (holewarp_plane == 2)
            {
                Console.WriteLine("Room Index Plane 1 : Used in room id = " + index.ToString("X2"));
            }
            else if (staircase_plane[0] == 2)
            {
                Console.WriteLine("Room Index Plane 1 : Used in room id = " + index.ToString("X2"));
            }
            else if (staircase_plane[1] == 2)
            {
                Console.WriteLine("Room Index Plane 1 : Used in room id = " + index.ToString("X2"));
            }
            else if (staircase_plane[2] == 2)
            {
                Console.WriteLine("Room Index Plane 1 : Used in room id = " + index.ToString("X2"));
            }
            else if (staircase_plane[3] == 2)
            {
                Console.WriteLine("Room Index Plane 1 : Used in room id = " + index.ToString("X2"));
            }

            holewarp = (ROM.DATA[header_location + 9]);
            staircase_rooms[0] = (ROM.DATA[header_location + 10]);
            staircase_rooms[1] = (ROM.DATA[header_location + 11]);
            staircase_rooms[2] = (ROM.DATA[header_location + 12]);
            staircase_rooms[3] = (ROM.DATA[header_location + 13]);
        }

        public object Clone()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;
                Console.WriteLine("Size of serializing for room " + index.ToString() + " : " + ms.Length.ToString() + "Bytes");
                return (Room)formatter.Deserialize(ms);
            }
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

            Console.WriteLine("Room was deleted");
        }
    }

    [Serializable]
    public class SpriteName
    {
        public int x;
        public int y;
        public string name;

        public SpriteName(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
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
