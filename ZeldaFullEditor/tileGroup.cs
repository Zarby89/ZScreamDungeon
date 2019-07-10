using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class tileGroup
    {
        public ushort sizeX = 0;
        public ushort[,] tiles;
        public IntPtr gfxPtr;
        public Bitmap gfxBitmap;
        public tileGroup(ushort sizeX, ushort[] tiles, IntPtr mapgfxPtr)
        {
            this.sizeX = sizeX;
            this.tiles = new ushort[sizeX, tiles.Length / sizeX];
            gfxPtr = Marshal.AllocHGlobal(tiles.Length*256);
            gfxBitmap = new Bitmap((sizeX * 16), (tiles.Length / sizeX)*16, (sizeX * 16), PixelFormat.Format8bppIndexed, gfxPtr);
            int x = 0;
            int y = 0;
            for (int i = 0; i < tiles.Length; i++)
            {
                this.tiles[x, y] = tiles[i];
                GFX.CopyTile8bpp16(x * 16, y * 16, this.tiles[x,y], (sizeX * 16), gfxPtr, mapgfxPtr);

                x++;
                if (x >= sizeX)
                {

                    y++;
                    x = 0;
                }
            }
        }
        
        public void updateGfx(ColorPalette cp, IntPtr mapgfxPtr)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < tiles.Length; i++)
            {

                GFX.CopyTile8bpp16(x * 16, y * 16, tiles[x,y], (sizeX * 16), gfxPtr, mapgfxPtr);

                x++;
                if (x >= sizeX)
                {

                    y++;
                    x = 0;
                }
            }
            gfxBitmap.Palette = cp;
        }
        public void Dispose()
        {
            Marshal.FreeHGlobal(gfxPtr);
        }


    }
}
