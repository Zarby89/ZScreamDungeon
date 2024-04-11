using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ZeldaFullEditor
{
    public unsafe class PointeredImage
    {

        private IntPtr ptr;
        private IntPtr indexedptr;

        private byte* Pointer => (byte*)ptr.ToPointer();
        public Bitmap bitmap { get; set; }
        private readonly int width = 16;
        private readonly int height = 16;
        private readonly int bufferLength = 256;
        public int indexedSize { get; set; } = 0;
        public byte this[int x, int y]
        {
            get => Pointer[x + y * width];
            set
            {
                if (x < 0 || x >= width || y < 0 || y >= height) { return; }
                Pointer[x + (y * width)] = value;
            }
        }

        public byte this[int p]
        {
            get => Pointer[p];
            set
            {
                if (p < 0 || p >= bufferLength) { return; }
                Pointer[p] = value;
            }
        }

        public void WriteBitmapRect(int x, int y, int w, int h, byte data = 240)
        {
            for (int i = 0; i <= w; i++)
            {
                this[x + i, y] = data;
                this[x + i, y + h] = data;
            }
            for (int i = 0; i <= h; i++)
            {
                this[x, y + i] = data;
                this[x + w, y + i] = data;
            }
        }



        public void FillBitmapRect(int x, int y, int w, int h, byte data)
        {
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    this[x + i, y + j] = data;
                }
            }
        }


        public PointeredImage(int width, int height, byte clear = 0)
        {
            this.width = width;
            this.height = height;
            this.bufferLength = ((width * height));
            this.indexedSize = bufferLength;
            ptr = Marshal.AllocHGlobal((width * height) * 4);
            indexedptr = Marshal.AllocHGlobal(width * height);
            bitmap = new Bitmap(width, height, width, PixelFormat.Format8bppIndexed, ptr);
            ClearBitmap(clear);

        }

        public void ClearBitmap(byte clear)
        {
            for (int i = 0; i < bufferLength; i++)
            {
                Pointer[i] = clear;
            }

        }

        private void WriteRealBitmapRect(byte* p, int x, int y, int w, int h, Color color)
        {

            for (int i = 0; i <= w; i++)
            {
                p[(i * 4) + ((x + y * width) * 4)] = color.R;
                p[(i * 4) + 1 + ((x + y * width) * 4)] = color.G;
                p[(i * 4) + 2 + ((x + y * width) * 4)] = color.B;
                p[(i * 4) + 3 + ((x + y * width) * 4)] = color.A;

                p[(i * 4) + ((x + (y + h) * width) * 4)] = color.R;
                p[(i * 4) + 1 + ((x + (y + h) * width) * 4)] = color.G;
                p[(i * 4) + 2 + ((x + (y + h) * width) * 4)] = color.B;
                p[(i * 4) + 3 + ((x + (y + h) * width) * 4)] = color.A;
            }
            for (int i = 0; i <= h; i++)
            {
                p[((i * width) * 4) + ((x + (y * width)) * 4)] = color.R;
                p[((i * width) * 4) + 1 + ((x + (y * width)) * 4)] = color.G;
                p[((i * width) * 4) + 2 + ((x + (y * width)) * 4)] = color.B;
                p[((i * width) * 4) + 3 + ((x + (y * width)) * 4)] = color.A;

                p[((x + w + (i + y) * width) * 4)] = color.R;
                p[(1 + (x + w + (i + y) * width) * 4)] = color.G;
                p[(2 + (x + w + (i + y) * width) * 4)] = color.B;
                p[(3 + (x + w + (i + y) * width) * 4)] = color.A;
            }
        }

        public void DrawBitmap(int x, int y, int w, int h, PointeredImage source, int srcX, int srcY, byte pal = 0, bool invis = false)
        {

            for (int xl = 0; xl < w; xl++)
            {
                for (int yl = 0; yl < h; yl++)
                {
                    if (source[srcX + xl, srcY + yl] == 0 && invis)
                    {
                        continue;
                    }
                    int xx = xl;
                    int yy = yl;

                    this[xx + x, yy + y] = (byte)((source[srcX + xl, srcY + yl]) + (pal * 4));

                }
            }
        }

        public void DrawBitmapTile(int x, int y, int w, int h, PointeredImage source, ushort tile, byte pal = 0, bool invis = false)
        {

            int xSource = (tile % 16) * 8;
            int ySource = (tile / 16) * 8;

            for (int xl = 0; xl < w; xl++)
            {
                for (int yl = 0; yl < h; yl++)
                {
                    if (source[xSource + xl, ySource + yl] == 0 && invis)
                    {
                        continue;
                    }
                    int xx = xl;
                    int yy = yl;

                    this[xx + x, yy + y] = (byte)((source[xSource + xl, ySource + yl]) + (pal * 4));

                }
            }
        }

        public void Draw8bppTiles(int x, int y, byte[] tiles8bpp, int widthTiles)
        {
            int tileXPos = 0;
            int tileYPos = 0;
            int tileId = 0;

            for (int i = 0; i < tiles8bpp.Length / 0x40; i++)
            {
                for (int yl = 0; yl < 8; yl++)
                {
                    for (int xl = 0; xl < 8; xl++)
                    {
                        //if (tiles8bpp[(tileId * 0x40) + xl + (yl * 8)] != 0)
                        //{
                        int xx = (tileXPos * 8) + xl;
                        int yy = (tileYPos * 8) + yl;

                        this[xx + x, yy + y] = tiles8bpp[(tileId * 0x40) + xl + (yl * 8)];
                        //}
                    }
                }
                tileId++;
                tileXPos++;
                if (tileXPos >= widthTiles)
                {
                    tileYPos++;
                    tileXPos = 0;
                }
            }
        }

        public void DrawBitmapTile(int x, int y, PointeredImage source, ushort tile, byte pal = 0, bool invis = false)
        {

            int xSource = (tile % 16) * 8;
            int ySource = (tile / 16) * 8;

            for (int xl = 0; xl < 8; xl++)
            {
                for (int yl = 0; yl < 8; yl++)
                {
                    if (source[xSource + xl, ySource + yl] == 0 && invis)
                    {
                        continue;
                    }
                    int xx = xl;
                    int yy = yl;

                    this[xx + x, yy + y] = (byte)((source[xSource + xl, ySource + yl]) + pal * 4);

                }
            }
        }
    }
}
