using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ZeldaFullEditor
{
    [Serializable]
    public unsafe class Room_Object
    {
        //==========================================================================================
        //Game Related Variables that are used to save data in the rom 
        //==========================================================================================
        public byte x, y; //position of the object in the room (*8 for draw)
        public byte layer = 0;
        public byte size; //size of the object
        public bool allBgs = false; //if the object is drawn on BG1 and BG2 regardless of type of BG
        //==========================================================================================
        //Editor Related Variables that are used to draw/position objects
        //==========================================================================================
        public bool lit = false;
        public List<Tile> tiles = new List<Tile>();
        public short id;
        public int tileIndex = 0;
        public string name; //name of the object will be shown on the form
        public byte nx, ny;
        public byte ox, oy;
        public int width, height;
        public Room room;
        public ObjectOption options = 0;//
        public bool specialDraw = false;
        public bool selected = false;
        public bool redraw = false;
        public Sorting sort = Sorting.All;
        public bool preview = false;
        public int previewId = 0;
        public Room_Object(short id, byte x, byte y, byte size, byte layer = 0)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            this.id = id;
            this.layer = layer;
            this.nx = x;
            this.ny = y;
            this.ox = x;
            this.oy = y;

        }

        public void setRoom(Room r)
        {
            this.room = r;
        }

        public virtual void Draw()
        {
            
        }

        public void UpdateSize()
        {
            width = 16;
            height = 16;
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
            for (int s = 0; s < size + 6; s++)
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
            for (int s = 0; s < size + 6; s++)
            {
                draw_tile(tiles[0], ((s)) * 8, (0 + s) * 8);
                draw_tile(tiles[1], ((s)) * 8, (1 + s) * 8);
                draw_tile(tiles[2], ((s)) * 8, (2 + s) * 8);
                draw_tile(tiles[3], ((s)) * 8, (3 + s) * 8);
                draw_tile(tiles[4], ((s)) * 8, (4 + s) * 8);
            }
        }
        //Object Initialization (Tiles and special stuff)
        public void init_objects()
        {

        }

        public void updatePos()
        {
            this.x = nx;
            this.y = ny;
        }
        int lowestX = 0;
        int lowestY = 0;

        public unsafe void draw_tile(Tile t, int xx, int yy, ushort tileUnder = 0xFFFF)
        {
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

                            if (ti.h)
                            {
                                mx = 3 - xl;
                                r = 1;
                            }
                            if (ti.v)
                            {
                                my = 7 - yl;
                            }
                            //Formula information to get tile index position in the array
                            //((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                            int tx = ((ti.id / 16) * 512) + ((ti.id - ((ti.id / 16) * 16)) * 4);
                            var pixel = alltilesData[tx + (yl * 64) + xl];
                            //nx,ny = object position, xx,yy = tile position, xl,yl = pixel position

                            int index = ((xx/8) * 8) + ((yy/8) * 512) + ((mx * 2) + (my * 64));
                            ptr[index + r ^ 1] = (byte)((pixel & 0x0F) + ti.palette * 16);
                            ptr[index + r] = (byte)(((pixel >> 4) & 0x0F) + ti.palette * 16);
                        }
                    }
                }
            }
            else
            {
                if (((xx / 8) + nx) + ((ny + (yy / 8)) * 64) < 4096 && ((xx / 8) + nx) + ((ny + (yy / 8)) * 64) >= 0)
                {
                    ushort td = GFX.getshortilesinfo(t.GetTileInfo());
                    if (layer == 0 || layer == 2 || allBgs)
                    {

                        if (tileUnder == GFX.tilesBg1Buffer[((xx / 8) + nx) + ((ny + (yy / 8)) * 64)])
                        {
                            return;
                        }
                        GFX.tilesBg1Buffer[((xx / 8) + nx) + ((ny + (yy / 8)) * 64)] = td;
                    }
                    if (layer == 1 || allBgs)
                    {
                        if (tileUnder == GFX.tilesBg2Buffer[((xx / 8) + nx) + ((ny + (yy / 8)) * 64)])
                        {
                            return;
                        }
                        GFX.tilesBg2Buffer[((xx / 8) + nx) + ((ny + (yy / 8)) * 64)] = td;
                    }
                    if (width < xx + 8)
                    {
                        width = xx + 8;
                    }
                    if (height < yy + 8)
                    {
                        height = yy + 8;
                    }
                }
            }

        }



    }

    [Flags]
    public enum Sorting
    {
        All = 0, Wall = 1, Horizontal = 2, Vertical = 4, NonScalable = 8, Dungeons = 16,Floors = 32, Stairs = 64
    }
    [Flags]
    public enum ObjectOption
    {
        Nothing = 0, Door = 1, Chest = 2, Block = 4, Torch = 8, Bgr = 16, Stairs = 32
    }

    public static class EnumEx
    {
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
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
            // or return default(T);
        }


        public static string GetDescription<T>(this T enumerationValue)
        where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }
    }
}



