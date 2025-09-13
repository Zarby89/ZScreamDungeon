using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public unsafe class PointeredImage
    {

        //private nint ptr;
        private IntPtr indexedptr;

        //private byte* Pointer => (byte*)ptr.ToPointer();
        private byte* IndexedPointer => (byte*)indexedptr.ToPointer();
        public Bitmap bitmap { get; set; }
        private readonly int width = 16;
        private readonly int height = 16;
        private readonly int bufferLength = 256;
        private Color[] colors = new Color[256];
        public int indexedSize { get; set; } = 0;
        public byte this[int x, int y]
        {
            get => IndexedPointer[x + y * width];
            set
            {
                if (x < 0 || x >= width || y < 0 || y >= height) { return; }
                IndexedPointer[x + (y * width)] = value;
            }
        }

        public byte this[int p]
        {
            get => IndexedPointer[p];
            set
            {
                if (p < 0 || p >= bufferLength) { return; }
                IndexedPointer[p] = value;
            }
        }
        public void Draw8bppTiles(int x, int y, byte[] tiles8bpp, int widthTiles, byte mx, byte my)
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
                        if (tiles8bpp[(tileId * 0x40) + xl + (yl * 8)] != 0)
                        {

                            int xx = (tileXPos * 8) +  xl * (1 - mx) + ((8 - 1) - xl) * (mx);
                            int yy = (tileYPos * 8) + yl * (1 - my) + ((8 - 1) - yl) * (my);
                            //int xx = (tileXPos * 8) + xl;
                            //int yy = (tileYPos * 8) + yl;

                            this[xx + x, yy + y] = tiles8bpp[(tileId * 0x40) + xl + (yl * 8)];
                        }
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
        public PointeredImage(int width, int height, byte clear = 0)
        {
            this.width = width;
            this.height = height;
            this.bufferLength = ((width * height));
            this.indexedSize = bufferLength;
            indexedptr = Marshal.AllocHGlobal(width * height);
            bitmap = new Bitmap(width, height, width, PixelFormat.Format8bppIndexed, indexedptr);

            ColorPalette cp = bitmap.Palette;
            for (int i = 0; i < 256; i++)
            {
                colors[i] = Color.FromArgb(255, (byte)(i * 15), (byte)(i * 15), (byte)(i * 15));
                cp.Entries[i] = colors[i];
            }
            bitmap.Palette = cp;
            
            ClearBitmap(clear);
        }

        public void DrawTilemap(ushort[] tilemap, int width, PointeredImage source)
        {
            for (int i = 0; i < tilemap.Length; i++)
            {
                int x = (i % width) * 8;
                int y = (i / width) * 8;

                DrawBitmapTile(x, y, source, tilemap[i]);

            }
        }

        public void DrawBitmapTile(int x, int y, PointeredImage source, ushort tile)
        {
            byte bppLength = 4;

            byte palSource = (byte)((tile >> 10) & 0x07);
            byte mx = (byte)((tile & 0x4000) >> 14);
            byte my = (byte)((tile & 0x8000) >> 15);

            ushort tid = (ushort)(tile & 0x3FF);

            int xSource = (tid % 16) * 8;
            int ySource = (tid / 16) * 8;

            for (int xl = 0; xl < 8; xl++)
            {
                for (int yl = 0; yl < 8; yl++)
                {
                    if (source[xSource + xl, ySource + yl] != 0)
                    {
                        int xx = xl * (1 - mx) + ((8 - 1) - xl) * (mx);
                        int yy = yl * (1 - my) + ((8 - 1) - yl) * (my);

                        this[xx + x, yy + y] = (byte)(source[xSource + xl, ySource + yl] + (palSource * bppLength));
                    }
                }
            }
        }

        public void UpdatePalettes(Color[] palettes)
        {
            ColorPalette cp = bitmap.Palette;
            for (int i = 0; i < palettes.Length; i++)
            {
                colors[i] = palettes[i];
                cp.Entries[i] = colors[i];
            }
            bitmap.Palette = cp;
        }

        public void ClearBitmap(byte clear)
        {
            for (int i = 0; i < bufferLength; i++)
            {
                IndexedPointer[i] = clear;
            }

        }
    }