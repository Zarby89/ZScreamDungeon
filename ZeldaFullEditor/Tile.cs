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
        public ushort id = 0;
        public bool mirror_x = false;
        public bool mirror_y = false;
        public bool ontop = false;
        public byte palette = 4;
        public Tile(ushort id, bool mirror_x = false, bool mirror_y = false, bool ontop = false, byte palette = 4) //custom tile
        {
            this.id = id;
            this.mirror_x = mirror_x;
            this.mirror_y = mirror_y;
            this.ontop = ontop;
            this.palette = palette;
        }


        public TileInfo GetTileInfo()
        {
            return new TileInfo(id, palette, mirror_y, mirror_x,ontop);
        }

        public Tile(byte b1, byte b2) //tile from game data
        {
            this.id = (ushort)(((b2 & 0x01) << 8)+(b1));
            this.mirror_y = ((b2 & 0x80) == 0x80) ? true : false;
            this.mirror_x = ((b2 & 0x40) == 0x40) ? true : false;
            this.ontop = ((b2 & 0x10) == 0x10) ? true : false;
            this.palette = (byte)((b2 >> 2) & 0x07);
        }

        public unsafe void SetTile(int xx, int yy, byte layer)
        {
            if (xx + (yy * 64) < 4096)
            {
                ushort t = GFX.getshortilesinfo(GetTileInfo());
                if (layer == 0)
                {

                    GFX.tilesBg1Buffer[xx + (yy * 64)] = t;
                }
                else
                {
                    GFX.tilesBg2Buffer[xx + (yy * 64)] = t;
                }
            }
            
        }

        public ushort getshortileinfo()
        {
            ushort tinfo = 0;
            //vhopppcc cccccccc
            tinfo |= (ushort)(id);
            tinfo |= (ushort)(palette << 10);
            if (ontop == true)
            {
                tinfo |= 0x2000;
            }
            if (mirror_x == true)
            {
                tinfo |= 0x4000;
            }
            if (mirror_y == true)
            {
                tinfo |= 0x8000;
            }
            return tinfo;

        }

        public unsafe void Draw(IntPtr bitmapPointer)
        {

        }

        public unsafe void CopyTile(int x, int y, int xx, int yy)
        {

        }
    }

}
