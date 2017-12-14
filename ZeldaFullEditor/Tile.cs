using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ZeldaFullEditor
{
    //Tiles Information
    //iiiiiiii vhoopppc
    //i = tile index
    //v - vertical flip
    //h - horizontal flip
    //p - palette
    //o - on top?
    //c - the 9th(and most significant) bit of the character number for this sprite.

        [Serializable]
    public class Tile
    {
        public int id = 0;
        public bool mirror_x = false;
        public bool mirror_y = false;
        public byte ontop = 0;
        public byte palette = 4;
        public Tile(int id, bool mirror_x = false, bool mirror_y = false, byte ontop = 0, byte palette = 4) //custom tile
        {
            this.id = id;
            this.mirror_x = mirror_x;
            this.mirror_y = mirror_y;
            this.ontop = ontop;
            this.palette = palette;
        }

        public Tile(byte b1, byte b2) //tile from game data
        {
            this.id = ((b2 & 0x01) << 8)+(b1);
            this.mirror_y = ((b2 & 0x80) == 0x80) ? true : false;
            this.mirror_x = ((b2 & 0x40) == 0x40) ? true : false;
            this.ontop = (byte)((b2 >> 4) & 0x03);
            this.palette = (byte)((b2 >> 2) & 0x07);
        }



        public void Draw(int x, int y)
        {
            int ty = (id / 16);
            int tx = id - (ty * 16);
            int mx = 0;
            int my = 0;


            if (mirror_x == true)
            {
                mx = 8;
            }

            for (int xx = 0; xx < 8; xx++)
            {
                if (mx > 0)
                {
                    mx--;
                }
                if (mirror_y == true)
                {
                    my = 8;
                }
                for (int yy = 0; yy < 8; yy++)
                {
                    if (my > 0)
                    {
                        my--;
                    }
                    int x_dest = ((x * 8) + (xx)) * 4;
                    int y_dest = (((y * 8) + (yy)) * 512) * 4;
                    int dest = x_dest + y_dest;

                    int x_src = ((tx * 8) + mx + (xx));
                    if (mirror_x)
                    {
                        x_src = ((tx * 8) + mx);
                    }
                    int y_src = (((ty * 8) + my + (yy)) * 128);
                    if (mirror_y)
                    {
                        y_src = (((ty * 8) + my) * 128);
                    }

                    int src = x_src + y_src;
                    int pp = 0;
                    if (src < 16384)
                    {
                        pp = 8;
                    }
                    if (dest < (1048576))
                    {
                        unsafe
                        {
                            int alpha = 255;
                            if (GFX.singledata[(src)] == 0)
                            {
                                alpha = 0;
                            }
                            if (alpha == 0)
                            {
                                GFX.currentData[dest] = 255;
                                GFX.currentData[dest + 1] = 0;
                                GFX.currentData[dest + 2] = 255;
                                GFX.currentData[dest + 3] = 255;
                            }
                            else
                            {
                                GFX.currentData[dest] = (GFX.loadedPalettes[GFX.singledata[(src)] + pp, palette].B);
                                GFX.currentData[dest + 1] = (GFX.loadedPalettes[GFX.singledata[(src)] + pp, palette].G);
                                GFX.currentData[dest + 2] = (GFX.loadedPalettes[GFX.singledata[(src)] + pp, palette].R);
                                GFX.currentData[dest + 3] = 255;
                            }
                        }
                    }
                }
            }
        }
    }

}
