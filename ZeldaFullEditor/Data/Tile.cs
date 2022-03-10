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
    // Tiles Information
    // iiiiiiii vhoopppc
    // i = tile index
    // v - vertical flip
    // h - horizontal flip
    // p - palette
    // o - on top?
    // c - the 9th(and most significant) bit of the character number for this sprite.

    [Serializable]
    public class Tile
    {
        public ushort id = 0;
        public ushort mirror_x = 0;
        public ushort mirror_y = 0;
        public ushort ontop = 0;
        public byte palette = 4;

        public Tile(ushort id, ushort mirror_x = 0, ushort mirror_y = 0, ushort ontop = 0, byte palette = 4) // Custom tile
        {
            this.id = id;
            this.mirror_x = mirror_x;
            this.mirror_y = mirror_y;
            this.ontop = ontop;
            this.palette = palette;
        }

        public TileInfo GetTileInfo()
        {
            return new TileInfo(id, palette, mirror_y, mirror_x, ontop);
        }

        public Tile(byte b1, byte b2) // Tile from game data
        {
            this.id = (ushort)(((b2 & 0x01) << 8) + (b1));
            this.mirror_y = (ushort)(((b2 & 0x80) == 0x80) ? 1 : 0);
            this.mirror_x = (ushort)(((b2 & 0x40) == 0x40) ? 1 : 0);
            this.ontop = (ushort)(((b2 & 0x20) == 0x20) ? 1 : 0);
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
            ushort value = 0;
            // vhopppcc cccccccc
            if (this.ontop == 1) { value |= 0x2000; };
            if (this.mirror_x == 1) { value |= 0x4000; };
            if (this.mirror_y == 1) { value |= 0x8000; };
            value |= (ushort)((this.palette << 10) & 0x1C00);
            value |= (ushort)(this.id & 0x3FF);
            return value;
        }

        public unsafe void Draw(IntPtr bitmapPointer)
        {
            // TODO: Add something here?
        }

        public unsafe void CopyTile(int x, int y, int xx, int yy)
        {
            // TODO: Add something here?
        }
    }
}
