using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ZeldaFullEditor.Properties;

// TODO: Move all the magic numbers to the constants.cs file.
namespace ZeldaFullEditor
{
    public static class GFX
    {
        public static IntPtr allgfx16Ptr = Marshal.AllocHGlobal((128 * 7136) / 2);
        public static Bitmap allgfxBitmap;

        public static IntPtr allgfx2bpp16Ptr = Marshal.AllocHGlobal((0x1000 * 10));
        public static Bitmap allgfx2bppBitmap;

        public static StringBuilder DEBUGSB = new StringBuilder();

        /*
        public static IntPtr allgfx16EDITPtr = Marshal.AllocHGlobal((128 * 7136));
        public static Bitmap allgfxEDITBitmap;
        */

        public static IntPtr currentgfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
        public static Bitmap currentgfx16Bitmap;

        public static IntPtr currentEditinggfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
        public static Bitmap currentEditingfx16Bitmap;

        public static IntPtr currentTileScreengfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
        public static Bitmap currentTileScreengfx16Bitmap;

        public static IntPtr currentOWgfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
        public static Bitmap currentOWgfx16Bitmap;

        public static IntPtr previewgfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
        public static Bitmap previewgfx16Bitmap;

        public static IntPtr editort16Ptr = Marshal.AllocHGlobal((128 * 512));
        public static Bitmap editort16Bitmap;

        public static IntPtr editortilePtr = Marshal.AllocHGlobal((256));
        public static Bitmap editortileBitmap;

        public static IntPtr mapgfx16Ptr = Marshal.AllocHGlobal(1048576);
        public static Bitmap mapgfx16Bitmap;

        public static IntPtr fontgfx16Ptr; // = Marshal.AllocHGlobal((256 * 256));
        public static Bitmap fontgfxBitmap;

        public static IntPtr currentfontgfx16Ptr; // = Marshal.AllocHGlobal(172 * 20000);
        public static Bitmap currentfontgfx16Bitmap;

        public static IntPtr mapblockset16; // = Marshal.AllocHGlobal(1048576);
        public static Bitmap mapblockset16Bitmap;

        public static IntPtr scratchblockset16; // = Marshal.AllocHGlobal(1048576);
        public static Bitmap scratchblockset16Bitmap;

        public static IntPtr OverworldMapPointer; // = Marshal.AllocHGlobal(0x4000);
        public static Bitmap OverworldMapBitmap;

        public static IntPtr OWActualMapPointer; // = Marshal.AllocHGlobal(0x40000);
        public static Bitmap OWActualMapBitmap;

        public static bool[] isbpp3 = new bool[Constants.NumberOfSheets];

        public static byte[] gfxdata;

        public static IntPtr roomBgLayoutPtr = Marshal.AllocHGlobal(512 * 512);
        public static Bitmap roomBgLayoutBitmap;

        public static IntPtr[] previewObjectsPtr;
        public static Bitmap[] previewObjectsBitmap;

        public static IntPtr[] previewSpritesPtr;
        public static Bitmap[] previewSpritesBitmap;

        public static IntPtr[] previewChestsPtr;
        public static Bitmap[] previewChestsBitmap;

        public static ushort[] tilesBg1Buffer = new ushort[4096];
        public static IntPtr roomBg1Ptr = Marshal.AllocHGlobal(512 * 512);
        public static Bitmap roomBg1Bitmap;

        public static ushort[] tilesBg2Buffer = new ushort[4096];
        public static IntPtr roomBg2Ptr = Marshal.AllocHGlobal(512 * 512);
        public static Bitmap roomBg2Bitmap;

        public static ushort[] tilesObjectsBuffer = new ushort[4096];
        public static IntPtr roomObjectsPtr = Marshal.AllocHGlobal(512 * 512);
        public static Bitmap roomObjectsBitmap;

        public static IntPtr editingtile16 = Marshal.AllocHGlobal(16 * 16);
        public static Bitmap editingtile16Bitmap;

        public static int animated_frame = 0;
        public static int animation_timer = 0;

        public static bool useOverworldGFX = false;

        public static Bitmap spriteFont;
        public static Bitmap moveableBlock;
        public static Bitmap favStar1;
        public static Bitmap favStar2;

        public static Color[] palettes = new Color[256];

        public static bool paletteWarning = true;
        public static Random random = new Random();

        // Test code
        public static string[] objectsName = new string[0xFFF];
        public static bool[] objects = new bool[0xFFF];

        public static Color[,] editingPalettes; // Dynamic
        public static Color[,] loadedPalettes = new Color[1, 1];
        public static ushort paletteid;

        public static Color[,] loadedSprPalettes = new Color[1, 1];

        public static byte[] spriteFontSpacing = Utils.DeepCopyBytes(Constants.FontSpacings);
        
        public static byte[] bpp2SheetsIndex = new byte[] {0x71, 0x72, 0xDA, 0xDB, 0xDC, 0xDD, 0xDE };


        public static unsafe void DrawBG1()
        {
            var alltilesData = (byte*)currentgfx16Ptr.ToPointer();
            byte* ptr = (byte*)roomBg1Ptr.ToPointer();

            for (int yy = 0; yy < 64; yy++) // For each tile on the tile buffer
            {
                for (int xx = 0; xx < 64; xx++)
                {
                    if (tilesBg1Buffer[xx + (yy * 64)] != 0xFFFF) // Prevent draw if tile == 0xFFFF since it 0 indexed
                    {
                        TileInfo t = gettilesinfo(tilesBg1Buffer[xx + (yy * 64)]);
                        for (var yl = 0; yl < 8; yl++)
                        {
                            for (var xl = 0; xl < 4; xl++)
                            {
                                int mx = xl * (1 - t.HS) + (3 - xl) * (t.HS);
                                int my = yl * (1 - t.VS) + (7 - yl) * (t.VS);

                                // Formula information to get tile index position in the array
                                //((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                                /*
                                int tx = ((t.id / 16) * 512) + ((t.id - ((t.id / 16) * 16)) * 4);
                                var pixel = alltilesData[tx + (yl * 64) + xl];
                                */

                                int ty = (t.id / 16) * 512;
                                int tx = (t.id % 16) * 4;
                                var pixel = alltilesData[(tx + ty) + (yl * 64) + xl];

                                //nx,ny = object position, xx,yy = tile position, xl,yl = pixel position

                                int index = (xx * 8) + (yy * 4096) + ((mx * 2) + (my * 512));
                                ptr[index + t.HS ^ 1] = (byte)((pixel & 0x0F) + t.palette * 16);
                                ptr[index + t.HS] = (byte)(((pixel >> 4) & 0x0F) + t.palette * 16);
                            }
                        }
                    }
                }
            }
        }

        public static unsafe void DrawBG2()
        {
            var alltilesData = (byte*)currentgfx16Ptr.ToPointer();
            byte* ptr = (byte*)roomBg2Ptr.ToPointer();

            for (int yy = 0; yy < 64; yy++) // for each tile on the tile buffer
            {
                for (int xx = 0; xx < 64; xx++)
                {
                    if (tilesBg2Buffer[xx + (yy * 64)] != 0xFFFF) // Prevent draw if tile == 0xFFFF since it 0 indexed
                    {
                        TileInfo t = gettilesinfo(tilesBg2Buffer[xx + (yy * 64)]);

                        for (var yl = 0; yl < 8; yl++)
                        {
                            for (var xl = 0; xl < 4; xl++)
                            {

                                int mx = xl * (1 - t.HS) + (3 - xl) * (t.HS);
                                int my = yl * (1 - t.VS) + (7 - yl) * (t.VS);

                                // Formula information to get tile index position in the array
                                //((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                                int tx = ((t.id / 16) * 512) + ((t.id - ((t.id / 16) * 16)) * 4);
                                var pixel = alltilesData[tx + (yl * 64) + xl];
                                //nx,ny = object position, xx,yy = tile position, xl,yl = pixel position

                                int index = (xx * 8) + (yy * 4096) + ((mx * 2) + (my * 512));
                                ptr[index + t.HS ^ 1] = (byte)((pixel & 0x0F) + t.palette * 16);
                                ptr[index + t.HS] = (byte)(((pixel >> 4) & 0x0F) + t.palette * 16);
                            }
                        }
                    }
                }
            }
        }

        public static void initGfx()
        {
            roomBgLayoutBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, roomBgLayoutPtr);
            roomBg1Bitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, roomBg1Ptr);
            roomBg2Bitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, roomBg2Ptr);
            allgfxBitmap = new Bitmap(128, 7136, 64, PixelFormat.Format4bppIndexed, allgfx16Ptr);
            allgfx2bppBitmap = new Bitmap(128, 640, 64, PixelFormat.Format4bppIndexed, allgfx2bpp16Ptr);
            //allgfxEDITBitmap = new Bitmap(128, 7104, 128, PixelFormat.Format8bppIndexed, allgfx16EDITPtr);
            currentgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentgfx16Ptr);
            currentEditingfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentEditinggfx16Ptr);
            currentTileScreengfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentEditinggfx16Ptr);
            roomObjectsBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, roomObjectsPtr);
            editingtile16Bitmap = new Bitmap(16, 16, 16, PixelFormat.Format8bppIndexed, roomObjectsPtr);
            currentOWgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentOWgfx16Ptr);
            previewgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, previewgfx16Ptr);
            mapgfx16Bitmap = new Bitmap(128, 7520, 128, PixelFormat.Format8bppIndexed, mapgfx16Ptr);
            editort16Bitmap = new Bitmap(128, 512, 128, PixelFormat.Format8bppIndexed, editort16Ptr);
            editortileBitmap = new Bitmap(16, 16, 16, PixelFormat.Format8bppIndexed, editortilePtr);
            mapblockset16Bitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, mapblockset16);
            scratchblockset16Bitmap = new Bitmap(256, 4096, 256, PixelFormat.Format8bppIndexed, scratchblockset16);

            moveableBlock = new Bitmap(Resources.Mblock);
            spriteFont = new Bitmap(Resources.spriteFont);
            favStar1 = new Bitmap(Resources.starn);
            favStar2 = new Bitmap(Resources.starl);

            favStar1.MakeTransparent(Color.Fuchsia);
            favStar2.MakeTransparent(Color.Fuchsia);

            previewObjectsPtr = new IntPtr[600];
            previewObjectsBitmap = new Bitmap[600];
            previewSpritesPtr = new IntPtr[256];
            previewSpritesBitmap = new Bitmap[256];
            previewChestsPtr = new IntPtr[76];
            previewChestsBitmap = new Bitmap[76];

            for (int i = 0; i < 600; i++)
            {
                previewObjectsPtr[i] = Marshal.AllocHGlobal(64 * 64);
                previewObjectsBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, GFX.previewObjectsPtr[i]);
            }
            for (int i = 0; i < 256; i++)
            {
                previewSpritesPtr[i] = Marshal.AllocHGlobal(64 * 64);
                previewSpritesBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, GFX.previewSpritesPtr[i]);
            }
            for (int i = 0; i < 76; i++)
            {
                previewChestsPtr[i] = Marshal.AllocHGlobal(64 * 64);
                previewChestsBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, GFX.previewChestsPtr[i]);
            }
            for (int i = 0; i < 4096; i++)
            {
                tilesBg1Buffer[i] = 0xFFFF;
                tilesBg2Buffer[i] = 0xFFFF;
            }
        }

        public static void CreateFontGfxData(byte[] romData)
        {
            byte[] data = new byte[0x2000];
            for (int i = 0; i < 0x2000; i++)
            {
                data[i] = romData[Constants.gfx_font + i];
            }

            byte[] newData = new byte[0x4000]; // NEED TO GET THE APPROPRIATE SIZE FOR THAT
            byte[] mask = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
            int sheetPosition = 0;

            // 8x8 tile
            for (int s = 0; s < 4; s++) // Per Sheet
            {
                for (int j = 0; j < 4; j++) // Per Tile Line Y
                {
                    for (int i = 0; i < 16; i++) // Per Tile Line X
                    {
                        for (int y = 0; y < 8; y++) // Per Pixel Line
                        {
                            byte lineBits0 = data[(y * 2) + (i * 16) + (j * 256) + sheetPosition];
                            byte lineBits1 = data[(y * 2) + (i * 16) + (j * 256) + 1 + sheetPosition];

                            for (int x = 0; x < 4; x++) // Per Pixel X
                            {
                                byte pixdata = 0;
                                byte pixdata2 = 0;

                                if ((lineBits0 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 1; }
                                if ((lineBits1 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 2; }

                                if ((lineBits0 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 1; }
                                if ((lineBits1 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 2; }

                                newData[(y * 64) + (x) + (i * 4) + (j * 512) + (s * 2048)] = (byte)((pixdata << 4) | pixdata2);
                            }
                        }
                    }
                }

                sheetPosition += 0x400;
            }

            unsafe
            {
                byte* fontgfx16Data = (byte*)fontgfx16Ptr.ToPointer();
                for (int i = 0; i < 0x4000; i++)
                {
                    fontgfx16Data[i] = newData[i];
                }
            }
        }

        public static byte[] CreateAllGfxDataRaw(byte[] romData)
        {
            // 0-112 -> compressed 3bpp bgr -> (decompressed each) 0x600 bytes
            // 113-114 -> compressed 2bpp -> (decompressed each) 0x800 bytes
            // 115-126 -> uncompressed 3bpp sprites -> (each) 0x600 bytes
            // 127-217 -> compressed 3bpp sprites -> (decompressed each) 0x600 bytes
            // 218-222 -> compressed 2bpp -> (decompressed each) 0x800 bytes

            byte[] buffer = new byte[0x54A00];
            int bufferPos = 0;
            byte[] data;
            int compressedSize = 0;

            for (int i = 0; i < Constants.NumberOfSheets; i++)
            {
                isbpp3[i] = (
                    (i >= 0 && i <= 112) || // Compressed 3bpp bg
                    (i >= 115 && i <= 126) || // Uncompressed 3bpp sprites
                    (i >= 127 && i <= 217)    // Compressed 3bpp sprites
                    );

                // uncompressed sheets
                if (i >= 115 && i <= 126)
                {
                    data = new byte[Constants.Uncompressed3BPPSize];
                    int startAddress = GetPCGfxAddress(romData, (byte)i);
                    for (int j = 0; j < Constants.Uncompressed3BPPSize; j++)
                    {
                        data[j] = romData[j + startAddress];
                    }
                }
                else
                {

                        data = ZCompressLibrary.Decompress.ALTTPDecompressGraphics(romData,
                            GetPCGfxAddress(romData, (byte)i)
                            , Constants.UncompressedSheetSize,
                            ref compressedSize);
                        
                }

                for (int j = 0; j < data.Length; j++)
                {
                    buffer[j + bufferPos] = data[j];
                }

                bufferPos += data.Length;
            }

            return buffer;
        }

        public static unsafe void CopyTile8bpp16(int x, int y, int tile, int sizeX, IntPtr destbmpPtr, IntPtr sourcebmpPtr)
        {
            int sourceY = (tile / 8);
            int sourceX = (tile) - ((sourceY) * 8);
            int sourcePtrPos = ((tile - ((tile / 8) * 8)) * 16) + ((tile / 8) * 2048); //(sourceX * 16) + (sourceY * 128);
            byte* sourcePtr = (byte*)sourcebmpPtr.ToPointer();

            int destPtrPos = (x + (y * sizeX));
            byte* destPtr = (byte*)destbmpPtr.ToPointer();

            for (int ystrip = 0; ystrip < 16; ystrip++)
            {
                for (int xstrip = 0; xstrip < 16; xstrip++)
                {
                    destPtr[destPtrPos + xstrip + (ystrip * sizeX)] = sourcePtr[sourcePtrPos + xstrip + (ystrip * 128)];
                }
            }
        }

        public static void CreateAllGfxData(byte[] romData)
        {
            byte[] data = CreateAllGfxDataRaw(romData);
            byte[] newData = new byte[0x6F800]; // NEED TO GET THE APPROPRIATE SIZE FOR THAT
            byte[] bpp2Data = new byte[0x10000];
            byte[] mask = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
            int sheetPosition = 0;
            int s2 = 0;
            // 8x8 tile
            for (int s = 0; s < Constants.NumberOfSheets; s++) // Per Sheet
            {
                for (int j = 0; j < 4; j++) // Per Tile Line Y
                {
                    for (int i = 0; i < 16; i++) // Per Tile Line X
                    {
                        for (int y = 0; y < 8; y++) // Per Pixel Line
                        {
                            if (isbpp3[s])
                            {
                                byte lineBits0 = data[(y * 2) + (i * 24) + (j * 384) + sheetPosition];
                                byte lineBits1 = data[(y * 2) + (i * 24) + (j * 384) + 1 + sheetPosition];
                                byte lineBits2 = data[(y) + (i * 24) + (j * 384) + 16 + sheetPosition];

                                for (int x = 0; x < 4; x++) // Per Pixel X
                                {
                                    byte pixdata = 0;
                                    byte pixdata2 = 0;

                                    if ((lineBits0 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 1; }
                                    if ((lineBits1 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 2; }
                                    if ((lineBits2 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 4; }

                                    if ((lineBits0 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 1; }
                                    if ((lineBits1 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 2; }
                                    if ((lineBits2 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 4; }

                                    newData[(y * 64) + (x) + (i * 4) + (j * 512) + (s * 2048)] = (byte)((pixdata << 4) | pixdata2);
                                }
                            }
                            else
                            {
                                byte lineBits0 = data[(y * 2) + (i * 16) + (j * 256) + sheetPosition];
                                byte lineBits1 = data[(y * 2) + (i * 16) + (j * 256) + 1 + sheetPosition];

                                for (int x = 0; x < 4; x++) // Per Pixel X
                                {
                                    byte pixdata = 0;
                                    byte pixdata2 = 0;

                                    if ((lineBits0 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 1; }
                                    if ((lineBits1 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 2; }

                                    if ((lineBits0 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 1; }
                                    if ((lineBits1 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 2; }

                                    newData[(y * 64) + (x) + (i * 4) + (j * 512) + (s * 2048)] = (byte)((pixdata << 4) | pixdata2);
                                }
                                
                            }
                        }
                    }
                }

                if (isbpp3[s])
                {
                    sheetPosition += Constants.Uncompressed3BPPSize;
                }
                else
                {
                    sheetPosition += Constants.UncompressedSheetSize;
                }
            }
            //public static byte[] bpp2SheetsIndex = new byte[] {0x71, 0x72, 0xDA, 0xDB, 0xDC, 0xDD, 0xDE };
            int[] sheetPos2bpp = new int[7] { 0x2A600, 0x2AE00, 0x52000, 0x52800, 0x53000, 0x53800, 0x54000 };
            for (int s = 0; s < bpp2SheetsIndex.Length; s++) // Per Sheet
            {
                for (int j = 0; j < 8; j++) // Per Tile Line Y
                {
                    for (int i = 0; i < 16; i++) // Per Tile Line X
                    {
                        for (int y = 0; y < 8; y++) // Per Pixel Line
                        {
                            byte lineBits0 = data[(y * 2) + (i * 16) + (j * 256) + sheetPos2bpp[s]];
                            byte lineBits1 = data[(y * 2) + (i * 16) + (j * 256) + 1 + sheetPos2bpp[s]];

                            for (int x = 0; x < 4; x++) // Per Pixel X
                            {
                                byte pixdata = 0;
                                byte pixdata2 = 0;

                                if ((lineBits0 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 1; }
                                if ((lineBits1 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 2; }

                                if ((lineBits0 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 1; }
                                if ((lineBits1 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 2; }

                                bpp2Data[(y * 64) + (x) + (i * 4) + (j * 512) + (s * 4096)] = (byte)((pixdata << 4) | pixdata2);
                            }
                        }
                    }
                }
            }

                unsafe
            {
                byte* allgfx16Data = (byte*)allgfx16Ptr.ToPointer();
                byte* allgfx2bpp16Data = (byte*)allgfx2bpp16Ptr.ToPointer();
                //byte* allgfx16Data2 = (byte*)allgfx16EDITPtr.ToPointer();

                for (int i = 0; i < 0x6F800; i++)
                {
                    allgfx16Data[i] = newData[i];
                }

                for (int i = 0; i < 0x10000; i++)
                {
                    allgfx2bpp16Data[i] = bpp2Data[i];
                }
            }
        }

        public static int GetPCGfxAddress(byte[] romData, byte id)
        {
            int gfxPointer1 = Utils.SnesToPc((romData[Constants.gfx_1_pointer + 1] << 8) + (romData[Constants.gfx_1_pointer]));
            int gfxPointer2 = Utils.SnesToPc((romData[Constants.gfx_2_pointer + 1] << 8) + (romData[Constants.gfx_2_pointer]));
            int gfxPointer3 = Utils.SnesToPc((romData[Constants.gfx_3_pointer + 1] << 8) + (romData[Constants.gfx_3_pointer]));

            byte gfxGamePointer1 = romData[gfxPointer1 + id];
            byte gfxGamePointer2 = romData[gfxPointer2 + id];
            byte gfxGamePointer3 = romData[gfxPointer3 + id];

            return Utils.SnesToPc(Utils.AddressFromBytes(gfxGamePointer1, gfxGamePointer2, gfxGamePointer3));
        }

        public static TileInfo gettilesinfo(ushort tile)
        {
            // vhopppcc cccccccc
            ushort tid = (ushort)(tile & Constants.TileNameMask);
            byte p = (byte)((tile >> 10) & 0x07);

            bool o = (tile & Constants.TilePriorityBit) == Constants.TilePriorityBit;
            bool h = (tile & Constants.TileHFlipBit) == Constants.TileHFlipBit;
            bool v = (tile & Constants.TileVFlipBit) == Constants.TileVFlipBit;

            return new TileInfo(tid, p, o, h, v);
        }

        public static ushort getshortilesinfo(TileInfo t)
        {
            ushort tinfo = 0;
            // vhopppcc cccccccc
            tinfo |= t.id;
            tinfo |= (ushort)(t.palette << 10);

            if (t.O)
            {
                tinfo |= Constants.TilePriorityBit;
            }
            if (t.H)
            {
                tinfo |= Constants.TileHFlipBit;
            }
            if (t.V)
            {
                tinfo |= Constants.TileVFlipBit;
            }

            return tinfo;
        }

        public static Color getColor(short c)
        {
            return Color.FromArgb(((c & 0x1F) * 8), ((c & 0x3E0) >> 5) * 8, ((c & 0x7C00) >> 10) * 8);
        }

        // Todo: Change palette system entirely
        // TODO magic number
        // Palettes must be loaded on rom load then being able to be modified - Done
        // without affecting the rom directly - Done
        // Change the way the room load the palettes, here change the code to load from the Palettes class
        public static Color[,] LoadDungeonPalette(byte id)
        {
            Color[,] palettes = new Color[16, 8];

            // id = dungeon palette id
            byte dungeon_palette_ptr = GfxGroups.paletteGfx[id][0]; //id of the 1st group of 4

            ushort palette_pos = (ushort)((ROM.DATA[0xDEC4B + dungeon_palette_ptr + 1] << 8) + ROM.DATA[0xDEC4B + dungeon_palette_ptr]);
            int pId = (palette_pos / 180);
            paletteid = palette_pos;

            int i = 0;
            /*
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    palettes[x, y] = Color.Black;
                }
            }
            */

            int j = 0;
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    // Hud Palette load from hud array instead of rom
                    //getColor((short)((ROM.DATA[0xDD660 + 1 + j] << 8) + (ROM.DATA[0xDD660 + j])));
                    palettes[x, y] = Palettes.HudPalettes[0][j++];
                }
            }

            for (int y = 2; y < 8; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (x == 0)
                    {
                        palettes[x, y] = Color.Black;
                        continue;
                    }

                    // In order to make it possible to use expanded data, I'm adding this check here to prevent ZS
                    // rom crashing if a value above one of the valid palette values is found.
                    if (pId >= 20 && paletteWarning)
                    {
                        DialogResult check = MessageBox.Show(
                        "Error: Invalid value for Dungeon palette number 0x" + id.ToString("X2") + " detected.\n" +
                        "Note, the palette will still save as this value however the palette will not draw correctly within ZScream.\n" +
                        "Press OK to no longer see this error.",
                        "Palette Error",
                        MessageBoxButtons.OKCancel);

                        if (check == DialogResult.OK)
                        {
                            paletteWarning = false;
                        }
                    }

                    // Dungeon Palette
                    if (pId < 20)
                    {
                        //palettes[x, y] = getColor((short)((ROM.DATA[Constants.dungeons_palettes + palette_pos + 1 + i] << 8) + ROM.DATA[Constants.dungeons_palettes + palette_pos + i]));
                        palettes[x, y] = Palettes.DungeonsMainPalettes[pId][i];
                    }
                    else
                    {
                        // Our palette is invlaid, so instead just make up a random color to show instead of throwing an error.
                        palettes[x, y] = Color.FromArgb(255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                    }
                    
                    if (x == 8)
                    {
                        palettes[x, y] = Color.Black;
                    }

                    i++;
                }
            }

            return palettes;
        }

        // TODO: clean up magic numbers
        public static Color[,] LoadSpritesPalette(byte id)
        {
            Color[,] palettes = new Color[16, 8];
            byte sprite1_palette_ptr = ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 1]; // ID of the 1st group of 4
            byte sprite2_palette_ptr = (byte)(ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 2] * 2); // ID of the 1st group of 4
            byte sprite3_palette_ptr = (byte)(ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 3] * 2); // ID of the 1st group of 4
                                                                                                                // Console.WriteLine(sprite2_palette_ptr);
            ushort palette_pos1 = (ROM.DATA[0xDEBC6 + sprite1_palette_ptr]); // /14
            ushort palette_pos2 = (ushort)((ROM.DATA[0xDEBD6 + sprite2_palette_ptr + 1] << 8) + ROM.DATA[0xDEBD6 + sprite2_palette_ptr]);// /14
            ushort palette_pos3 = (ushort)((ROM.DATA[0xDEBD6 + sprite3_palette_ptr + 1] << 8) + ROM.DATA[0xDEBD6 + sprite3_palette_ptr]);// /14
                                                                                                                                         //short palette_pos4 = (short)(ROM.DATA[0xDEBC6 + 10]); // 140?

            // In order to make it possible to use expanded data, I'm adding this check here to prevent ZS
            // rom crashing if a value above one of the valid palette values is found.
            if (paletteWarning)
            {
                if (palette_pos1 / 14 >= 12)
                {
                    DialogResult check = MessageBox.Show(
                    "Error: Invalid value for sprite palette 1 number 0x" + id.ToString("X2") + " detected.\n" +
                    "Note, the palette will still save as this value however the palette will not draw correctly within ZScream.\n" +
                    "Press OK to no longer see this error.",
                    "Palette Error",
                    MessageBoxButtons.OKCancel);

                    if (check == DialogResult.OK)
                    {
                        paletteWarning = false;
                    }
                }
                else if (palette_pos2 / 14 >= 24)
                {
                    DialogResult check = MessageBox.Show(
                    "Error: Invalid value for sprite palette 2 number 0x" + id.ToString("X2") + " detected.\n" +
                    "Note, the palette will still save as this value however the palette will not draw correctly within ZScream.\n" +
                    "Press OK to no longer see this error.",
                    "Palette Error",
                    MessageBoxButtons.OKCancel);

                    if (check == DialogResult.OK)
                    {
                        paletteWarning = false;
                    }
                }
                else if (palette_pos3 / 14 >= 24)
                {
                    DialogResult check = MessageBox.Show(
                    "Error: Invalid value for sprite palette 3 number 0x" + id.ToString("X2") + " detected.\n" +
                    "Note, the palette will still save as this value however the palette will not draw correctly within ZScream.\n" +
                    "Press OK to no longer see this error.",
                    "Palette Error",
                    MessageBoxButtons.OKCancel);

                    if (check == DialogResult.OK)
                    {
                        paletteWarning = false;
                    }
                }
            }

            // ID = dungeon palette id
            palettes[9, 5] = Palettes.SwordsPalettes[0][0];
            palettes[10, 5] = Palettes.SwordsPalettes[0][1];
            palettes[11, 5] = Palettes.SwordsPalettes[0][2];
            palettes[12, 5] = Palettes.ShieldsPalettes[0][0];
            palettes[13, 5] = Palettes.ShieldsPalettes[0][1];
            palettes[14, 5] = Palettes.ShieldsPalettes[0][2];
            palettes[15, 5] = Palettes.ShieldsPalettes[0][3];

            for (int x = 0; x < 15; x++)
            {
                if (x < 7)
                {
                    if ((palette_pos1 / 14) < 12)
                    {
                        palettes[x + 1, 0] = Palettes.SpritesAux1Palettes[palette_pos1 / 14][x];
                    }
                    else
                    {
                        // Our palette is invlaid, so instead just make up a random color to show instead of throwing an error.
                        palettes[x + 1, 0] = Color.FromArgb(255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                    }
                    
                    if ((palette_pos2 / 14) < 11)
                    {
                        palettes[x + 1, 5] = Palettes.SpritesAux3Palettes[palette_pos2 / 14][x];
                    }
                    else
                    {
                        // Our palette is invlaid, so instead just make up a random color to show instead of throwing an error.
                        palettes[x + 1, 0] = Color.FromArgb(255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                    }

                    if ((palette_pos3 / 14) < 24)
                    {
                        palettes[x + 1, 6] = Palettes.SpritesAux3Palettes[palette_pos3 / 14][x];
                    }
                    else
                    {
                        // Our palette is invlaid, so instead just make up a random color to show instead of throwing an error.
                        palettes[x + 1, 0] = Color.FromArgb(255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                    }
                }
                else
                {
                    palettes[x + 1, 0] = GFX.loadedPalettes[x - 7, 2];
                    if (x < 14)
                    {
                        palettes[x + 2, 6] = Palettes.SpritesAux2Palettes[10][x - 7];
                    }
                }

                // SP-1
                //getColor((ushort)((ROM.DATA[0xDD218 + i + 1] << 8) + ROM.DATA[0xDD218 + i]));
                palettes[x + 1, 1] = Palettes.GlobalSpritePalettes[0][x];
                // SP-2
                palettes[x + 1, 2] = Palettes.GlobalSpritePalettes[0][x + 15];
                // SP-3
                palettes[x + 1, 3] = Palettes.GlobalSpritePalettes[0][x + 30];
                // SP-4
                palettes[x + 1, 4] = Palettes.GlobalSpritePalettes[0][x + 45];

                //SP-6
                /*
                palettes[x + 1, 12] = getColor((ushort)((ROM.DATA[0xDD4E0 AUX3 + palette_pos3 + i + 1] << 8) + ROM.DATA[0xDD4E0 + palette_pos3 + i]));
                palettes[x + 1, 13] = getColor((ushort)((ROM.DATA[0xDD446 AUX2 + palette_pos4 + i + 1] << 8) + ROM.DATA[0xDD446 + palette_pos4 + i])); //liftable objects
                */

                // IF GHOST PALETTE?
                // SP-7 ???? WTF IT LINK PALETTE
                //palettes[x + 1, 14] = getColor((ushort)((ROM.DATA[0xDD39E + palette_pos1 + i + 1] << 8) + ROM.DATA[0xDD39E + palette_pos1 + i]));
            }

            return palettes;
        }

        public static byte[] pc4bppto3bppsnes(byte[] sheetData)
        {
            // [r0, bp1], [r0, bp2], [r1, bp1], [r1, bp2], [r2, bp1], [r2, bp2], [r3, bp1], [r3, bp2]
            // [r4, bp1], [r4, bp2], [r5, bp1], [r5, bp2], [r6, bp1], [r6, bp2], [r7, bp1], [r7, bp2]
            // [r0, bp3], [r1, bp3], [r2, bp3], [r3, bp3], [r4, bp3], [r5, bp3], [r6, bp3], [r7, bp3]

            // 4 bytes = 1 line of a 8x8 tile
            int dpos; // Destination pos

            byte[] blockdata = new byte[24 * 64];
            byte l1d, l2d, l3d;
            int bpos = 0;

            for (int b = 0; b < 64; b++)
            {
                int y = (b / 16);
                int x = (b % 16);
                // Do that x8 for each blocks

                dpos = 0;
                for (int l = 0; l < 8; l++)
                {
                    l1d = 0;
                    l2d = 0;
                    l3d = 0;

                    for (int i = 0; i < 4; i++) // 1 line
                    {
                        // 1111 0000 | 3333 2222 | 5555 4444 | 7777 6666  (4 bytes (i))
                        l1d += (byte)((sheetData[i + (l * 64) + (y * 512) + (x * 4)] >> 4) & 0x01); // Load bpp1 of line1 pixel2 + i (pixel 4, 6, 7)
                        l1d = (byte)(l1d << 1); // Put it in linebpp1data and shift it by 1
                        l1d += (byte)(sheetData[i + (l * 64) + (y * 512) + (x * 4)] & 0x01); // Load bpp1 of line1 pixel1 + i (pixel 3, 5, 7)

                        l2d += (byte)((sheetData[i + (l * 64) + (y * 512) + (x * 4)] >> 5) & 0x01); // Load bpp2 of line1 pixel2 + i (pixel 4, 6, 7)
                        l2d = (byte)(l2d << 1); // Put it in linebpp2data and shift it by 1
                        l2d += (byte)((sheetData[i + (l * 64) + (y * 512) + (x * 4)] >> 1) & 0x01); // Load bpp2 of line1 pixel1 + i (pixel 3, 5, 7)

                        l3d += (byte)((sheetData[i + (l * 64) + (y * 512) + (x * 4)] >> 6) & 0x01); // Load bpp3 of line1 pixel2 + i (pixel 4, 6, 7)
                        l3d = (byte)(l3d << 1); // Put it in linebpp3data and shift it by 1
                        l3d += (byte)((sheetData[i + (l * 64) + (y * 512) + (x * 4)] >> 2) & 0x01); // Load bpp3 of line1 pixel1 + i (pixel 3, 5, 7)


                        if (i != 3) // Shift all the linebpp data for the next bit except for the last one
                        {
                            l1d = (byte)(l1d << 1);
                            l2d = (byte)(l2d << 1);
                            l3d = (byte)(l3d << 1);
                        }
                    }

                    blockdata[(bpos * 24) + 0 + (dpos * 2)] = l1d;
                    blockdata[(bpos * 24) + 1 + (dpos * 2)] = l2d;
                    blockdata[(bpos * 24) + 16 + dpos] = l3d;
                    dpos++;
                }

                bpos++;
            }

            // l1d = byte0
            // l2d = byte1
            // l3d = byte16

            return blockdata;
        }

        public static byte[] pc4bppto2bppsnes(byte[] sheetData)
        {
            // [r0, bp1], [r0, bp2], [r1, bp1], [r1, bp2], [r2, bp1], [r2, bp2], [r3, bp1], [r3, bp2]
            // [r4, bp1], [r4, bp2], [r5, bp1], [r5, bp2], [r6, bp1], [r6, bp2], [r7, bp1], [r7, bp2]

            // 4 bytes = 1 line of a 8x8 tile
            int dpos; // Destination pos

            byte[] blockdata = new byte[16 * 128];
            byte l1d, l2d;
            int bpos = 0;

            for (int b = 0; b < 128; b++)
            {
                int y = (b / 16);
                int x = (b % 16);
                // Do that x8 for each blocks

                dpos = 0;
                for (int l = 0; l < 8; l++)
                {
                    l1d = 0;
                    l2d = 0;

                    for (int i = 0; i < 4; i++) // 1 line
                    {
                        // 1111 0000 | 3333 2222 | 5555 4444 | 7777 6666  (4 bytes (i))
                        l1d += (byte)((sheetData[i + (l * 64) + (y * 512) + (x * 4)] >> 4) & 0x01); // Load bpp1 of line1 pixel2 + i (pixel 4, 6, 7)
                        l1d = (byte)(l1d << 1); // Put it in linebpp1data and shift it by 1
                        l1d += (byte)(sheetData[i + (l * 64) + (y * 512) + (x * 4)] & 0x01); // Load bpp1 of line1 pixel1 + i (pixel 3, 5, 7)

                        l2d += (byte)((sheetData[i + (l * 64) + (y * 512) + (x * 4)] >> 5) & 0x01);// Load bpp2 of line1 pixel2 + i (pixel 4, 6, 7)
                        l2d = (byte)(l2d << 1); // Put it in linebpp2data and shift it by 1
                        l2d += (byte)((sheetData[i + (l * 64) + (y * 512) + (x * 4)] >> 1) & 0x01);// Load bpp2 of line1 pixel1 + i (pixel 3, 5, 7)

                        if (i != 3) // Shift all the linebpp data for the next bit except for the last one
                        {
                            l1d = (byte)(l1d << 1);
                            l2d = (byte)(l2d << 1);
                        }
                    }

                    blockdata[(bpos * 16) + 0 + (dpos * 2)] = l1d;
                    blockdata[(bpos * 16) + 1 + (dpos * 2)] = l2d;
                    dpos++;
                }

                bpos++;
            }

            return blockdata;
        }

        public static byte[] Convert32to4bpp(byte[] data)
        {
            return null;
        }

        public static void LoadOverworldMap()
        {
            OverworldMapBitmap = new Bitmap(128, 128, 128, PixelFormat.Format8bppIndexed, OverworldMapPointer);
            OWActualMapBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, OWActualMapPointer);

            // Mode 7
            unsafe
            {
                byte* pointer = (byte*)OverworldMapPointer.ToPointer();

                int pos = 0;
                for (int sy = 0; sy < 16; sy++)
                {
                    for (int sx = 0; sx < 16; sx++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            for (int x = 0; x < 8; x++)
                            {
                                pointer[x + (sx * 8) + (y * 128) + (sy * 1024)] = ROM.DATA[0x0C4000 + pos];
                                pos++;
                            }
                        }
                    }
                }
            }

            UpdatePalette(false);
        }

        public static void UpdatePalette(bool DW)
        {
            int offset = 0;
            if (DW)
            {
                offset = 1;
            }

            ColorPalette cp = OverworldMapBitmap.Palette;
            for (int i = 0; i < 128; i++)
            {
                // 55B27 = US LW
                // 55C27 = US DW
                cp.Entries[i] = Palettes.OverworldMiniMapPalettes[offset][i];
            }

            int k = 0;
            int j = 0;
            for (int y = 10; y < 14; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    cp.Entries[145 + k] = Palettes.GlobalSpritePalettes[0][j++];
                    k++;
                }

                k++;
            }

            OverworldMapBitmap.Palette = cp;
            OWActualMapBitmap.Palette = cp;
        }

        public static void drawText(Graphics g, int x, int y, string text, ImageAttributes ai = null, bool x2 = false)
        {
            text = text.ToUpper();
            int cpos = 0;
            for (int i = 0; i < text.Length; i++)
            {
                byte arrayPos = (byte)(text[i] - 32);
                if ((byte)text[i] == 10)
                {
                    y += 10;
                    cpos = 0;
                    continue;
                }

                if (ai == null)
                {
                    if (x2)
                    {
                        g.DrawImage(spriteFont, new Rectangle(x + cpos, y, 16, 16), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g.DrawImage(spriteFont, new Rectangle(x + cpos, y, 8, 8), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel);
                    }
                }
                else
                {
                    g.DrawImage(spriteFont, new Rectangle(x + cpos, y, 8, 8), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel, ai);
                }

                if (arrayPos > spriteFontSpacing.Length - 1)
                {
                    cpos += 8;
                    continue;
                }

                if (x2)
                {
                    cpos += (spriteFontSpacing[arrayPos] * 2);
                }
                else
                {
                    cpos += spriteFontSpacing[arrayPos];
                }
            }
        }
    }
}
