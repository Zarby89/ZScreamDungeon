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



        public void Draw(int x, int y, Bitmap floor)
        {
            //y * image width *8 position * pixel data (rgba 32bit),
            int ty = (id / 16);
            int tx = id - (ty * 16);
           
            for (int xx = 0; xx < 8; xx++)
            {
                for (int yy = 0; yy < 8; yy++)
                {
                    //(((((y * (512)) * 8) + (yy * 512)) * 4) + ((x * 8) * 4) + (xx * 4));
                    int x_dest = ((x * 8) + (xx)) * 4;
                    int y_dest = (((y * 8) + (yy)) * 512) * 4;
                    int dest = x_dest + y_dest;

                    int x_src = ((tx * 8) + (xx)) * 4;
                    int y_src = (((ty * 8) + (yy)) * 128) * 4;
                    int src = x_src + y_src;
                    GFX.currentData[dest] = GFX.blocksetData[src];
                    GFX.currentData[dest + 1] = GFX.blocksetData[src + 1];
                    GFX.currentData[dest + 2] = GFX.blocksetData[src + 2];
                    GFX.currentData[dest + 3] = 255;//A
                }
            }
            
            /*using (Bitmap b = new Bitmap(8, 8))
            {

                using (Graphics g = Graphics.FromImage(b))
                {
                    g.DrawImage(GFX.blocksets[palette], new Rectangle(0, 0, 8, 8), tx * 8, ty * 8, 8, 8, GraphicsUnit.Pixel);
                }

                if (mirror_x) //mirror x
                    b.RotateFlip(RotateFlipType.RotateNoneFlipX);
                if (mirror_y) //mirror y
                    b.RotateFlip(RotateFlipType.RotateNoneFlipY);

                using (Graphics g = Graphics.FromImage(floor))
                {
                    g.DrawImage(b, new Point(x * 8, y * 8));
                }

            }*/
        }

    }
}
