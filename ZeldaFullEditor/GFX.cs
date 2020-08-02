using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor
{
    public static class GFX
    {
        public static IntPtr allgfx16Ptr = Marshal.AllocHGlobal((128 * 7136) / 2);
        public static Bitmap allgfxBitmap;

        public static IntPtr allgfx16EDITPtr = Marshal.AllocHGlobal((128 * 7136));
        public static Bitmap allgfxEDITBitmap;

        public static IntPtr currentgfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
        public static Bitmap currentgfx16Bitmap;

        public static IntPtr currentEditinggfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
        public static Bitmap currentEditingfx16Bitmap;

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

        public static IntPtr fontgfx16Ptr = Marshal.AllocHGlobal((256 * 256));
        public static Bitmap fontgfxBitmap;

        public static IntPtr currentfontgfx16Ptr = Marshal.AllocHGlobal(172 * 20000);
        public static Bitmap currentfontgfx16Bitmap;

        public static bool[] isbpp3 = new bool[223];

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

        public static int animated_frame = 0;
        public static int animation_timer = 0;

        public static bool useOverworldGFX = false;

        public static Bitmap spriteFont;
        public static Bitmap moveableBlock;

        public static Color[] palettes = new Color[256];

        public unsafe static void DrawBG1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var alltilesData = (byte*)currentgfx16Ptr.ToPointer();
            byte* ptr = (byte*)roomBg1Ptr.ToPointer();
            for (int yy = 0; yy < 64; yy++) //for each tile on the tile buffer
            {
                for (int xx = 0; xx < 64; xx++)
                {
                    if (tilesBg1Buffer[xx + (yy * 64)] != 0xFFFF) //prevent draw if tile == 0xFFFF since it 0 indexed
                    {
                        TileInfo t = gettilesinfo(tilesBg1Buffer[xx + (yy * 64)]);
                        for (var yl = 0; yl < 8; yl++)
                        {
                            for (var xl = 0; xl < 4; xl++)
                            {
                                int mx = xl * (1 - t.h) + (3 - xl) * (t.h);
                                int my = yl * (1 - t.v) + (7 - yl) * (t.v);


                                //Formula information to get tile index position in the array
                                //((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                                /*int tx = ((t.id / 16) * 512) + ((t.id - ((t.id / 16) * 16)) * 4);
                                var pixel = alltilesData[tx + (yl * 64) + xl];
                                */
                                int ty = (t.id / 16) * 512;
                                int tx = (t.id % 16) * 4;
                                var pixel = alltilesData[(tx + ty) + (yl * 64) + xl];


                                //nx,ny = object position, xx,yy = tile position, xl,yl = pixel position

                                int index = (xx * 8) + (yy * 4096) + ((mx * 2) + (my * 512));
                                ptr[index + t.h ^ 1] = (byte)((pixel & 0x0F) + t.palette * 16);
                                ptr[index + t.h] = (byte)(((pixel >> 4) & 0x0F) + t.palette * 16);
                            }
                        }
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("Unsafe BG1 Buffer Copy - " + sw.ElapsedMilliseconds + "ms");
        }



        public unsafe static void DrawBG2()
        {
            var alltilesData = (byte*)currentgfx16Ptr.ToPointer();
            byte* ptr = (byte*)roomBg2Ptr.ToPointer();
            for (int yy = 0; yy < 64; yy++) //for each tile on the tile buffer
            {
                for (int xx = 0; xx < 64; xx++)
                {

                    if (tilesBg2Buffer[xx + (yy * 64)] != 0xFFFF) //prevent draw if tile == 0xFFFF since it 0 indexed
                    {
                        TileInfo t = gettilesinfo(tilesBg2Buffer[xx + (yy * 64)]);
                        for (var yl = 0; yl < 8; yl++)
                        {
                            for (var xl = 0; xl < 4; xl++)
                            {

                                int mx = xl * (1 - t.h) + (3 - xl) * (t.h);
                                int my = yl * (1 - t.v) + (7 - yl) * (t.v);
                                //Formula information to get tile index position in the array
                                //((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                                int tx = ((t.id / 16) * 512) + ((t.id - ((t.id / 16) * 16)) * 4);
                                var pixel = alltilesData[tx + (yl * 64) + xl];
                                //nx,ny = object position, xx,yy = tile position, xl,yl = pixel position

                                int index = (xx * 8) + (yy * 4096) + ((mx * 2) + (my * 512));
                                ptr[index + t.h ^ 1] = (byte)((pixel & 0x0F) + t.palette * 16);
                                ptr[index + t.h] = (byte)(((pixel >> 4) & 0x0F) + t.palette * 16);
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
            allgfxBitmap = new Bitmap(128, 7104, 64, PixelFormat.Format4bppIndexed, allgfx16Ptr);
            allgfxEDITBitmap = new Bitmap(128, 7104, 128, PixelFormat.Format8bppIndexed, allgfx16EDITPtr);
            currentgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentgfx16Ptr);
            currentEditingfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentEditinggfx16Ptr);
            roomObjectsBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, roomObjectsPtr);
            currentOWgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentOWgfx16Ptr);
            previewgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, previewgfx16Ptr);
            mapgfx16Bitmap = new Bitmap(128, 7520, 128, PixelFormat.Format8bppIndexed, mapgfx16Ptr);
            editort16Bitmap = new Bitmap(128, 512, 128, PixelFormat.Format8bppIndexed, editort16Ptr);
            editortileBitmap = new Bitmap(16, 16, 16, PixelFormat.Format8bppIndexed, editortilePtr);
            moveableBlock = new Bitmap(Resources.Mblock);
            spriteFont = new Bitmap(Resources.spriteFont);

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
            byte[] newData = new byte[0x4000]; //NEED TO GET THE APPROPRIATE SIZE FOR THAT
            byte[] mask = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
            int sheetPosition = 0;
            //8x8 tile
            for (int s = 0; s < 4; s++) //Per Sheet
            {
                for (int j = 0; j < 4; j++) //Per Tile Line Y
                {
                    for (int i = 0; i < 16; i++) //Per Tile Line X
                    {
                        for (int y = 0; y < 8; y++) //Per Pixel Line
                        {

                            byte lineBits0 = data[(y * 2) + (i * 16) + (j * 256) + sheetPosition];
                            byte lineBits1 = data[(y * 2) + (i * 16) + (j * 256) + 1 + sheetPosition];

                            for (int x = 0; x < 4; x++) //Per Pixel X
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

            //0-112 -> compressed 3bpp bgr -> (decompressed each) 0x600 bytes
            //113-114 -> compressed 2bpp -> (decompressed each) 0x800 bytes
            //115-126 -> uncompressed 3bpp sprites -> (each) 0x600 bytes
            //127-217 -> compressed 3bpp sprites -> (decompressed each) 0x600 bytes
            //218-222 -> compressed 2bpp -> (decompressed each) 0x800 bytes
            byte[] buffer = new byte[0x54A00];
            int bufferPos = 0;
            byte[] data = new byte[0x600];
            int compressedSize = 0;
            for (int i = 0; i < 223; i++)
            {
                bool c = true;
                if (i >= 0 && i <= 112) //compressed 3bpp bgr
                {
                    isbpp3[i] = true;
                }
                else if (i >= 113 && i <= 114) //compressed 2bpp
                {
                    isbpp3[i] = false;
                }
                else if (i >= 115 && i <= 126) //uncompressed 3bpp sprites
                {
                    isbpp3[i] = true;
                    c = false;
                }
                else if (i >= 127 && i <= 217) //compressed 3bpp sprites
                {
                    isbpp3[i] = true;
                }
                else if (i >= 218 && i <= 222) //compressed 2bpp
                {
                    isbpp3[i] = false;
                }

                if (c)//if data is compressed decompress it
                {
                    data = ZCompressLibrary.Decompress.ALTTPDecompressGraphics(romData, GetPCGfxAddress(romData, (byte)i), 0x800, ref compressedSize);

                }
                else
                {
                    data = new byte[0x600];
                    int startAddress = GetPCGfxAddress(romData, (byte)i);
                    for (int j = 0; j < 0x600; j++)
                    {
                        data[j] = romData[j + startAddress];
                    }
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
            int sourcePtrPos = ((tile - ((tile / 8) * 8)) * 16) + ((tile / 8) * 2048);//(sourceX * 16) + (sourceY * 128);
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
            byte[] newData = new byte[0x6F800]; //NEED TO GET THE APPROPRIATE SIZE FOR THAT
            byte[] mask = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
            int sheetPosition = 0;
            //8x8 tile
            for (int s = 0; s < 223; s++) //Per Sheet
            {

                for (int j = 0; j < 4; j++) //Per Tile Line Y
                {
                    for (int i = 0; i < 16; i++) //Per Tile Line X
                    {
                        for (int y = 0; y < 8; y++) //Per Pixel Line
                        {

                            if (isbpp3[s])
                            {
                                byte lineBits0 = data[(y * 2) + (i * 24) + (j * 384) + sheetPosition];
                                byte lineBits1 = data[(y * 2) + (i * 24) + (j * 384) + 1 + sheetPosition];
                                byte lineBits2 = data[(y) + (i * 24) + (j * 384) + 16 + sheetPosition];

                                for (int x = 0; x < 4; x++) //Per Pixel X
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

                                for (int x = 0; x < 4; x++) //Per Pixel X
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
                    sheetPosition += 0x600;
                }
                else
                {
                    sheetPosition += 0x800;
                }
            }

            unsafe
            {

                byte* allgfx16Data = (byte*)allgfx16Ptr.ToPointer();
                byte* allgfx16Data2 = (byte*)allgfx16EDITPtr.ToPointer();
                for (int i = 0; i < 0x6F800; i++)
                {
                    allgfx16Data[i] = newData[i];

                    allgfx16Data2[(i*2)+1] = (byte)(newData[i] & 0x0F);
                    allgfx16Data2[(i*2)] = (byte)((newData[i] & 0xF0) >> 4);
                }
            }
        }

        public static int GetPCGfxAddress(byte[] romData, byte id)
        {
            int gfxPointer1 = Utils.SnesToPc((romData[Constants.gfx_1_pointer + 1] << 8) + (romData[Constants.gfx_1_pointer])),
                gfxPointer2 = Utils.SnesToPc((romData[Constants.gfx_2_pointer + 1] << 8) + (romData[Constants.gfx_2_pointer])),
                gfxPointer3 = Utils.SnesToPc((romData[Constants.gfx_3_pointer + 1] << 8) + (romData[Constants.gfx_3_pointer]));

            byte gfxGamePointer1 = romData[gfxPointer1 + id];
            byte gfxGamePointer2 = romData[gfxPointer2 + id];
            byte gfxGamePointer3 = romData[gfxPointer3 + id];

            return Utils.SnesToPc(Utils.AddressFromBytes(gfxGamePointer1, gfxGamePointer2, gfxGamePointer3));
        }


        public static TileInfo gettilesinfo(ushort tile)
        {
            //vhopppcc cccccccc
            ushort o = 0;
            ushort v = 0;
            ushort h = 0;
            ushort tid = (ushort)(tile & 0x3FF);
            byte p = (byte)((tile >> 10) & 0x07);

            o = (ushort)((tile & 0x2000) >> 13);
            h = (ushort)((tile & 0x4000) >> 14);
            v = (ushort)((tile & 0x8000) >> 15);
            return new TileInfo(tid, p, v, h, o);

        }



        public static ushort getshortilesinfo(TileInfo t)
        {
            ushort tinfo = 0;
            //vhopppcc cccccccc
            tinfo |= (ushort)(t.id);
            tinfo |= (ushort)(t.palette << 10);
            if (t.o == 1)
            {
                tinfo |= 0x2000;
            }
            if (t.h == 1)
            {
                tinfo |= 0x4000;
            }
            if (t.v == 1)
            {
                tinfo |= 0x8000;
            }
            return tinfo;

        }
        public static Color getColor(short c)
        {
            return Color.FromArgb(((c & 0x1F) * 8), ((c & 0x3E0) >> 5) * 8, ((c & 0x7C00) >> 10) * 8);
        }



        //Todo: Change palette system entirely
        //Palettes must be loaded on rom load then being able to be modified - Done
        //without affecting the rom directly - Done
        //Change the way the room load the palettes, here change the code to load from the Palettes class



        public static Color[,] editingPalettes; //dynamic
        public static Color[,] loadedPalettes = new Color[1, 1];
        public static short paletteid;
        public static Color[,] LoadDungeonPalette(byte id)
        {

            Color[,] palettes = new Color[16, 8];


            //id = dungeon palette id
            byte dungeon_palette_ptr = (byte)(GfxGroups.paletteGfx[id][0]); //id of the 1st group of 4
            short palette_pos = (short)((ROM.DATA[0xDEC4B + dungeon_palette_ptr + 1] << 8) + ROM.DATA[0xDEC4B + dungeon_palette_ptr]);
            int pId = (palette_pos / 180);
            paletteid = palette_pos;



            int i = 0;
            /*for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    palettes[x, y] = Color.Black;
                }
            }*/
            int j = 0;
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    //Hud Palette load from hud array instead of rom
                    //getColor((short)((ROM.DATA[0xDD660 + 1 + j] << 8) + (ROM.DATA[0xDD660 + j])));
                    palettes[x, y] = Palettes.HudPalettes[0][j];
                    j += 1;
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
                    //Dungeon Palette
                    //palettes[x, y] = getColor((short)((ROM.DATA[Constants.dungeons_palettes + palette_pos + 1 + i] << 8) + ROM.DATA[Constants.dungeons_palettes + palette_pos + i]));
                    palettes[x, y] = Palettes.dungeonsMain_Palettes[pId][i];
                    if (x == 8)
                    {
                        palettes[x, y] = Color.Black;
                    }
                    i += 1;
                }
            }
            return palettes;
        }
        public static Color[,] loadedSprPalettes = new Color[1, 1];
        public static Color[,] LoadSpritesPalette(byte id)
        {
            Color[,] palettes = new Color[16, 8];
            byte sprite1_palette_ptr = ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 1]; //id of the 1st group of 4
            byte sprite2_palette_ptr = (byte)(ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 2] * 2); //id of the 1st group of 4
            byte sprite3_palette_ptr = (byte)(ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 3] * 2); //id of the 1st group of 4
                                                                                                                // Console.WriteLine(sprite2_palette_ptr);
            short palette_pos1 = (short)((ROM.DATA[0xDEBC6 + sprite1_palette_ptr])); // /14
            short palette_pos2 = (short)((ROM.DATA[0xDEBD6 + sprite2_palette_ptr + 1] << 8) + ROM.DATA[0xDEBD6 + sprite2_palette_ptr]);// /14
            short palette_pos3 = (short)((ROM.DATA[0xDEBD6 + sprite3_palette_ptr + 1] << 8) + ROM.DATA[0xDEBD6 + sprite3_palette_ptr]);// /14
            short palette_pos4 = (short)(ROM.DATA[0xDEBC6 + 10]); //140?
            //id = dungeon palette id
            int i = 0;
            palettes[9, 5] = Palettes.swords_Palettes[0][0];
            palettes[10, 5] = Palettes.swords_Palettes[0][1];
            palettes[11, 5] = Palettes.swords_Palettes[0][2];
            palettes[12, 5] = Palettes.shields_Palettes[0][0];
            palettes[13, 5] = Palettes.shields_Palettes[0][1];
            palettes[14, 5] = Palettes.shields_Palettes[0][2];
            palettes[15, 5] = Palettes.shields_Palettes[0][3];

            for (int x = 0; x < 15; x++)
            {
                if (x < 7)
                {
                    palettes[x + 1, 0] = Palettes.spritesAux1_Palettes[(palette_pos1 / 14)][x];
                    palettes[x + 1, 5] = Palettes.spritesAux3_Palettes[(palette_pos2 / 14)][x];
                    palettes[x + 1, 6] = Palettes.spritesAux3_Palettes[(palette_pos3 / 14)][x];

                }
                else
                {
                    palettes[x + 1, 0] = GFX.loadedPalettes[x - 7, 2];
                    if (x < 14)
                    {
                        palettes[x + 2, 6] = Palettes.spritesAux2_Palettes[10][x - 7];
                    }
                }

                //SP-1
                //getColor((short)((ROM.DATA[0xDD218 + i + 1] << 8) + ROM.DATA[0xDD218 + i]));
                palettes[x + 1, 1] = Palettes.globalSprite_Palettes[0][x];
                //SP-2
                palettes[x + 1, 2] = Palettes.globalSprite_Palettes[0][x + (15)];
                //SP-3
                palettes[x + 1, 3] = Palettes.globalSprite_Palettes[0][x + (30)];
                //SP-4
                palettes[x + 1, 4] = Palettes.globalSprite_Palettes[0][x + (45)];


                //SP-6
                /*palettes[x + 1, 12] = getColor((short)((ROM.DATA[0xDD4E0 AUX3 + palette_pos3 + i + 1] << 8) + ROM.DATA[0xDD4E0 + palette_pos3 + i]));
                palettes[x + 1, 13] = getColor((short)((ROM.DATA[0xDD446 AUX2 + palette_pos4 + i + 1] << 8) + ROM.DATA[0xDD446 + palette_pos4 + i])); //liftable objects
                */




                //IF GHOST PALETTE?
                //SP-7 ???? WTF IT LINK PALETTE
                //palettes[x + 1, 14] = getColor((short)((ROM.DATA[0xDD39E + palette_pos1 + i + 1] << 8) + ROM.DATA[0xDD39E + palette_pos1 + i]));
            }
            return palettes;

        }




    }
}
