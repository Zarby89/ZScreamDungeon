﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;

namespace ZeldaFullEditor
{
    /// <summary>
    ///		A class used to store the info for each dungeon object.
    /// </summary>
    [Serializable]
    public unsafe class Room_Object
    {
        // ==========================================================================================
        // Game Related Variables that are used to save data in the rom.
        // ==========================================================================================

        /// <summary>
        ///     Gets or sets the x position of the object in the room (*8 for draw).
        /// </summary>
        public byte X { get; set; }

        /// <summary>
        ///     Gets or sets the x position of the object in the room (*8 for draw).
        /// </summary>
        public byte Y { get; set; }

        /// <summary>
        ///     Gets or sets the layer position of the object in the room.
        /// </summary>
        public LayerType Layer { get; set; }

        /// <summary>
        ///     All Possible Layers that dungeon objects can exist on.
        /// </summary>
        public enum LayerType
        {
            /// <summary>
            ///     Background 1.
            /// </summary>
            BG1 = 0,

            /// <summary>
            ///     Background 2.
            /// </summary>
            BG2 = 1,

            /// <summary>
            ///     Background 3.
            /// </summary>
            BG3 = 2,
        }

        public byte Size { get; set; } // Size of the object
        public bool allBgs { get; set; } = false; // If the object is drawn on BG1 and BG2 regardless of type of BG

        // ==========================================================================================
        // Editor Related Variables that are used to draw/position objects.
        // ==========================================================================================
        public bool lit = false;
        public List<Tile> tiles = new List<Tile>();
        public ushort id;
        public int tileIndex = 0;
        public string name; // Name of the object will be shown on the form
        public byte nx, ny;
        public byte ox, oy;
        public int width, height;
        public int basewidth, baseheight;
        public int sizewidth, sizeheight;
        public Room room;
        public ObjectOption options = 0;
        public int offsetX = 0;
        public int offsetY = 0;
        public bool diagonalFix = false;
        public bool selected = false;
        public bool redraw = false;
        public Sorting sort = Sorting.All;
        public bool preview = false;
        public int previewId = 0;
        byte previousSize = 0;
        public bool showRectangle = false;
        public List<Point> collisionPoint = new List<Point>();
        public int uniqueID = 0;
        public byte z = 0;
        public bool deleted = false;

        public DungeonLimits LimitClass = DungeonLimits.None;

        public Room_Object(ushort id, byte x, byte y, byte size, byte layer = 0)
        {
            this.X = x;
            this.Y = y;
            this.Size = size;
            this.id = id;
            this.Layer = (LayerType)layer;
            this.nx = x;
            this.ny = y;
            this.ox = x;
            this.oy = y;
            width = 8;
            height = 8;
            uniqueID = ROM.uniqueRoomObjectID++;
        }

        public void getObjectSize()
        {
            previousSize = Size;
            Size = 1;
            Draw();
            getBaseSize(); // 48
            UpdateSize();
            Size = 2;
            Draw();
            getSizeSized(); // 64 - 48
            UpdateSize();
            Size = previousSize;
            collisionPoint.Clear();
            
        }

        public void getBaseSize()
        {
            // Set size on 1
            basewidth = width;
            baseheight = height;
        }

        public void getSizeSized()
        {
            sizeheight = (height - baseheight);
            sizewidth = (width - basewidth);
        }

        public void setRoom(Room r)
        {
            room = r;
        }

        public virtual void Draw()
        {
            if (room == null)
            {
                room = DungeonsData.AllRooms[0];
                
            }
            collisionPoint.Clear();
        }

        public void UpdateSize()
        {
            width = 8;
            height = 8;
        }

        public void addTiles(int nbr, int pos)
        {
            for (int i = 0; i < nbr; i++)
            {
                tiles.Add(new Tile(ROM.DATA[pos + ((i * 2))], ROM.DATA[pos + ((i * 2)) + 1]));
            }
        }

        public void draw_diagonal_up()
        {
            height = (Size + 10) * 8;
            width = (Size + 6) * 8;
            diagonalFix = true;

            for (int s = 0; s < Size + 6; s++)
            {
                draw_tile(tiles[0], ((s)) * 8, (0 - s) * 8);
                draw_tile(tiles[1], ((s)) * 8, (1 - s) * 8);
                draw_tile(tiles[2], ((s)) * 8, (2 - s) * 8);
                draw_tile(tiles[3], ((s)) * 8, (3 - s) * 8);
                draw_tile(tiles[4], ((s)) * 8, (4 - s) * 8);
            }
        }

        public void draw_diagonal_down()
        {
            for (int s = 0; s < Size + 6; s++)
            {
                draw_tile(tiles[0], ((s)) * 8, (0 + s) * 8);
                draw_tile(tiles[1], ((s)) * 8, (1 + s) * 8);
                draw_tile(tiles[2], ((s)) * 8, (2 + s) * 8);
                draw_tile(tiles[3], ((s)) * 8, (3 + s) * 8);
                draw_tile(tiles[4], ((s)) * 8, (4 + s) * 8);
            }
        }

        public unsafe void draw_tile(Tile t, int xx, int yy, ushort tileUnder = 0xFFFF)
        {
            if (width < xx + 8)
            {
                width = xx + 8;
            }
            if (height < yy + 8)
            {
                height = yy + 8;
            }
            if (preview)
            {
                if (xx < 57 && yy < 57 && xx >= 0 && yy >= 0)
                {
                    var alltilesData = (byte*)GFX.currentgfx16Ptr.ToPointer();
                    byte* ptr = (byte*)GFX.previewObjectsPtr[previewId].ToPointer();
                    TileInfo ti = t.GetTileInfo();
                    for (var yl = 0; yl < 8; yl++)
                    {
                        for (var xl = 0; xl < 4; xl++)
                        {
                            int mx = xl;
                            int my = yl;
                            byte r = 0;

                            if (ti.H)
                            {
                                mx = 3 - xl;
                                r = 1;
                            }
                            if (ti.V)
                            {
                                my = 7 - yl;
                            }

                            // Formula information to get tile index position in the array.
                            //((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                            int tx = ((ti.id / 16) * 512) + ((ti.id - ((ti.id / 16) * 16)) * 4);
                            var pixel = alltilesData[tx + (yl * 64) + xl];
                            //nx,ny = object position, xx,yy = tile position, xl,yl = pixel position

                            int index = ((xx / 8) * 8) + ((yy / 8) * 512) + ((mx * 2) + (my * 64));
                            ptr[index + r ^ 1] = (byte)((pixel & 0x0F) + ti.palette * 16);
                            ptr[index + r] = (byte)(((pixel >> 4) & 0x0F) + ti.palette * 16);
                        }
                    }
                }
            }
            else
            {
                if (((xx / 8) + nx + offsetX) + ((ny + offsetY + (yy / 8)) * 64) < 4096 && ((xx / 8) + nx + offsetX) + ((ny + offsetY + (yy / 8)) * 64) >= 0)
                {
                    ushort td = GFX.getshortilesinfo(t.GetTileInfo());

                    collisionPoint.Add(new Point(xx + ((nx + offsetX) * 8), yy + ((ny + +offsetY) * 8)));

                    if (this.Layer == 0 || (byte)this.Layer == 2 || this.allBgs)
                    {
                        if (tileUnder == GFX.tilesBg1Buffer[((xx / 8) + offsetX + nx) + ((ny + offsetY + (yy / 8)) * 64)])
                        {
                            return;
                        }

                        GFX.tilesBg1Buffer[((xx / 8) + offsetX + nx) + ((ny + offsetY + (yy / 8)) * 64)] = td;
                    }

                    if ((byte)this.Layer == 1 || this.allBgs)
                    {
                        if (tileUnder == GFX.tilesBg2Buffer[((xx / 8) + nx + offsetX) + ((ny + offsetY + (yy / 8)) * 64)])
                        {
                            return;
                        }

                        GFX.tilesBg2Buffer[((xx / 8) + nx) + offsetX + ((ny + offsetY + (yy / 8)) * 64)] = td;
                    }
                }
            }
        }
    }

    [Flags]
    public enum Sorting
    {
        All = 0, Wall = 1, Horizontal = 2, Vertical = 4, NonScalable = 8, Dungeons = 16, Floors = 32, Stairs = 64
    }

    [Flags]
    public enum ObjectOption
    {
        Nothing = 0, Door = 1, Chest = 2, Block = 4, Torch = 8, Bgr = 16, Stairs = 32, Overlay = 64
    }

    public static class EnumEx
    {
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", nameof(description));
            // Or return default(T);
        }

        public static string GetDescription<T>(this T enumerationValue)
        where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            // Tries to find a DescriptionAttribute for a potential friendly name for the enum.
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    // Pull out the description value.
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            // If we have no description attribute, just return the ToString of the enum.
            return enumerationValue.ToString();
        }
    }
}