using Newtonsoft.Json;
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
    public class Room_Object
    {
        public byte x, y; //position of the object in the room (*8 for draw)
        public byte nx, ny;
        public byte ox, oy;
        public byte size; //size of the object
        public bool allBgs = false; //if the object is drawn on BG1 and BG2 regardless of type of BG
        public List<Tile> tiles = new List<Tile>();
        public short id;
        public string name; //name of the object will be shown on the form
        public byte layer = 0;
        public Room room;
        public int drawYFix = 0;
        public ObjectOption options = 0;//
        public bool specialDraw = false;
        public bool checksize = false;
        public bool selected = false;
        public bool redraw = false;
        public Bitmap bitmap;
        public int width = 16;
        public int height = 16;
        public byte scroll_x = 2;
        public byte scroll_y = 2;
        public byte base_width = 2;
        public byte base_height = 2;
        public byte oldSize = 0;
        public byte savedSize = 0;
        public byte special_zero_size = 0;
        public Sorting sort = Sorting.All;
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
            this.oldSize = size;
            this.savedSize = size;
            
        }

        public void get_scroll_x()
        {

            if (id == 0x00)
            {
                scroll_x = 2;
                special_zero_size = 32;
                base_width = 2;
                return;
            }
            else if (id == 0x01 || id == 0x02 || id == 0xB9 || id == 0xB8)
            {
                scroll_x = 2;
                special_zero_size = 26;
                base_width = 2;
                return;
            }
            else if ((id >= 0xC0 && id <= 0xF7))
            {
                byte oldBaseSize2 = size;
                size = 4;
                checksize = true;
                Draw();
                scroll_x = (byte)((width / 8));
                size = 0;
                resetSize();
                Draw();
                base_width = (byte)(width / 8);
                scroll_x -= base_width;
                size = oldBaseSize2;
                resetSize();
                checksize = false;
                return;
            }

            byte oldBaseSize = size;
            size = 1;
            checksize = true;
            Draw();
            scroll_x = (byte)((width / 8));
            size = 0;
            resetSize();
            Draw();
            base_width = (byte)(width / 8);
            scroll_x -= base_width;
            size = oldBaseSize;
            resetSize();
            checksize = false;
        }


        public void get_scroll_y()
        {
            if (id == 0x60) //WTF !?!
            {
                scroll_y = 2;
                special_zero_size = 32;
                base_height = 2;
                return;
            }
            else if (id == 0x61 || id == 0x62 || id == 0x90 || id == 0x91 || id == 0x92 || id == 0x93)
            {
                scroll_y = 2;
                special_zero_size = 26;
                base_height = 2;
                return;
            }
            byte oldBaseSize = size;
            size = 1;
            checksize = true;
            Draw();
            scroll_y = (byte)((height / 8));
            size = 0;
            resetSize();
            Draw();
            base_height = (byte)(height / 8);
            scroll_y -= base_height;
            size = oldBaseSize;
            resetSize();
            checksize = false;
        }

        public void setRoom(Room r)
        {
            this.room = r;
        }

        public virtual void Draw()
        {

        }



        public void DrawOnBitmap()
        {
            checksize = true;
            Draw();
            checksize = false;
            bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            GFX.begin_draw(bitmap, width, height);
            Draw();
            GFX.end_draw(bitmap);
        }

        public void resetSize()
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
            for (int s = 0; s < size + 6; s++)
            {
                draw_tile(tiles[0], ((s)) * 8, (0 - s) * 8, ((size + 6) * 8));
                draw_tile(tiles[1], ((s)) * 8, (1 - s) * 8, ((size + 6) * 8));
                draw_tile(tiles[2], ((s)) * 8, (2 - s) * 8, ((size + 6) * 8));
                draw_tile(tiles[3], ((s)) * 8, (3 - s) * 8, ((size + 6) * 8));
                draw_tile(tiles[4], ((s)) * 8, (4 - s) * 8, ((size + 6) * 8));
                drawYFix = -(size + 6);
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


        public void draw_tile(Tile t, int x, int y, int yfix = 0)
        {
            int tid = t.id;
            //if (tid >= 448 & tid < 464) { tid = 512 + (t.id - 448) + (16 * GFX.animated_frame); };
            //if (tid >= 432 & tid < 448) { tid = 576 + (t.id - 432) + (16 * GFX.animated_frame); };
            if (id == 0x94 || id == 0xBA) // transparent tiles !
            {
                t.palette = 6;
            }

            if (checksize)
            {
                int zx = x + 8;
                int zy = (y + 8 + yfix);

                if (zx > width)
                {
                    width = zx;
                }
                if (zy > height)
                {
                    height = zy;
                }

                return;
            }

            int ty = (tid / 16);
            int tx = tid - (ty * 16);
            int mx = 0;
            int my = 0;


            if (t.mirror_x == true)
            {
                mx = 8;
            }

            for (int xx = 0; xx < 8; xx++)
            {
                if (mx > 0)
                {
                    mx--;
                }
                if (t.mirror_y == true)
                {
                    my = 8;
                }
                for (int yy = 0; yy < 8; yy++)
                {
                    if (my > 0)
                    {
                        my--;
                    }
                    //int x_dest = ((this.x * 8) + x + (xx)) * 4;
                    //int y_dest = (((this.y * 8) + y + (yy)) * 512) * 4;

                    int x_dest = (x + (xx)) * 4;
                    int y_dest = (((y + yfix) + (yy)) * width) * 4;
                    int dest = x_dest + y_dest;

                    int x_src = ((tx * 8) + mx + (xx));
                    if (t.mirror_x)
                    {
                        x_src = ((tx * 8) + mx);
                    }
                    int y_src = (((ty * 8) + my + (yy)) * 128);
                    if (t.mirror_y)
                    {
                        y_src = (((ty * 8) + my) * 128);
                    }

                    int src = x_src + y_src;
                    int pp = 0;
                    if (src < 16384)
                    {
                        pp = 8;
                    }
                    if (dest < (width * height * 4))
                    {
                        byte alpha = 255;

                        if (GFX.singledata[(src)] == 0)
                        {
                            if (room.bg2 == Background2.Normal || room.bg2 == Background2.Parallax)
                            {
                                alpha = 0;
                            }
                            
                            if (room.bg2 == Background2.OnTop)
                            {
                                if (layer != 0)
                                {
                                    alpha = 0;
                                }
                                else
                                {
                                    alpha = 255;
                                }
                            }
                            if (room.bg2 == Background2.Transparent)
                            {
                                alpha = 128;
                            }
                        }
                        else
                        {
                            if (room.bg2 == Background2.Transparent)
                            {
                                if (layer == 1)
                                {
                                    alpha = 128;
                                }
                            }
                        }

                        if (allBgs)
                        {
                            alpha = 255;
                        }
                        unsafe
                        {
                            if (alpha == 0)
                            {
                                GFX.currentData[dest] = 255;
                                GFX.currentData[dest + 1] = 0;
                                GFX.currentData[dest + 2] = 255;
                                GFX.currentData[dest + 3] = 255;
                            }
                            else
                            {
                                GFX.currentData[dest] = (GFX.loadedPalettes[GFX.singledata[(src)] + pp, t.palette].B);
                                GFX.currentData[dest + 1] = (GFX.loadedPalettes[GFX.singledata[(src)] + pp, t.palette].G);
                                GFX.currentData[dest + 2] = (GFX.loadedPalettes[GFX.singledata[(src)] + pp, t.palette].R);
                                GFX.currentData[dest + 3] = alpha;
                            }
                        }
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



