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

        private bool priority, hflip, vflip;

        /// <summary>
        /// True if high priority
        /// </summary>
        public bool Priority { get => priority; set => priority = value; }

        /// <summary>
        /// True if h flip
        /// </summary>
        public bool HFlip { get => hflip; set => hflip = value; }

        /// <summary>
        /// True if v flip
        /// </summary>
        public bool VFlip { get => vflip; set => vflip = value; }

        /// <summary>
        /// 0x0001 if high priority
        /// </summary>
        public ushort PriorityShort
        {
            get
            {
                return (ushort)(priority ? 1 : 0);
            }
            set
            {
                priority = value == 0x0001;
            }
        }
        /// <summary>
        /// 0x0001 if h flip
        /// </summary>
        public ushort HFlipShort
        {
            get
            {
                return (ushort)(hflip ? 1 : 0);
            }
            set
            {
                hflip = value == 0x0001;
            }
        }

        /// <summary>
        /// 0x0001 if v flip
        /// </summary>
        public ushort VFlipShort
        {
            get
            {
                return (ushort)(vflip ? 1 : 0);
            }
            set
            {
                vflip = value == 0x0001;
            }
        }



        public ushort id = 0;
        public byte palette = 4;

        public Tile(ushort id, byte palette = 4, bool priority = false, bool hflip = false, bool vflip = false) // Custom tile
        {
            this.id = id;
            this.hflip = hflip;
            this.vflip = vflip;
            this.priority = priority;
            this.palette = palette;
        }

        public TileInfo GetTileInfo()
        {
            return new TileInfo(id, palette, priority, hflip, vflip);
        }

        public Tile(byte b1, byte b2) // Tile from game data
        {
            this.id = (ushort)(((b2 & 0x01) << 8) + (b1));
            this.vflip = (b2 & 0x80) == 0x80;
            this.hflip = (b2 & 0x40) == 0x40;
            this.priority = (b2 & 0x20) == 0x20;
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
            if (priority) { value |= Constants.TilePriorityBit; };
            if (hflip) { value |= Constants.TileHFlipBit; };
            if (vflip) { value |= Constants.TileVFlipBit; };
            value |= (ushort)((this.palette << 10) & 0x1C00);
            value |= (ushort)(this.id & Constants.TileNameMask);
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
