using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    public static class GFX
    {
        public static IntPtr allgfx16Ptr = Marshal.AllocHGlobal((128 * 7136) / 2);
        public static Bitmap allgfxBitmap;
        
        public static IntPtr currentgfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
        public static Bitmap currentgfx16Bitmap;
        
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

        public unsafe static void DrawBG1()
        {
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
                                int mx = xl;
                                int my = yl;
                                byte r = 0;

                                if (t.h)
                                {
                                    mx = 3 - xl;
                                    r = 1;
                                }
                                if (t.v)
                                {
                                    my = 7 - yl;
                                }
                                //Formula information to get tile index position in the array
                                //((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                                int tx = ((t.id / 16) * 512) + ((t.id - ((t.id / 16) * 16)) * 4);
                                var pixel = alltilesData[tx + (yl * 64) + xl];
                                //nx,ny = object position, xx,yy = tile position, xl,yl = pixel position

                                int index = (xx * 8) + (yy * 4096) + ((mx * 2) + (my * 512));
                                ptr[index + r ^ 1] = (byte)((pixel & 0x0F) + t.palette * 16);
                                ptr[index + r] = (byte)(((pixel >> 4) & 0x0F) + t.palette * 16);
                            }
                        }
                    }
                }
            }
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


                                int mx = xl;
                                int my = yl;
                                byte r = 0;

                                if (t.h)
                                {
                                    mx = 3 - xl;
                                    r = 1;
                                }
                                if (t.v)
                                {
                                    my = 7 - yl;
                                }
                                //Formula information to get tile index position in the array
                                //((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                                int tx = ((t.id / 16) * 512) + ((t.id - ((t.id / 16) * 16)) * 4);
                                var pixel = alltilesData[tx + (yl * 64) + xl];
                                //nx,ny = object position, xx,yy = tile position, xl,yl = pixel position

                                int index = (xx * 8) + (yy * 4096) + ((mx * 2) + (my * 512));
                                ptr[index + r ^ 1] = (byte)((pixel & 0x0F) + t.palette * 16);
                                ptr[index + r] = (byte)(((pixel >> 4) & 0x0F) + t.palette * 16);
                            }
                        }
                    }
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
                for (int i = 0; i < 0x6F800; i++)
                {
                    allgfx16Data[i] = newData[i];
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
            bool o = false;
            bool v = false;
            bool h = false;
            ushort tid = (ushort)(tile & 0x3FF);
            byte p = (byte)((tile >> 10) & 0x07);
            
            if ((tile & 0x2000) == 0x2000)
            {
                o = true;
            }
            if ((tile & 0x4000) == 0x4000)
            {
                h = true;
            }
            if ((tile & 0x8000) == 0x8000)
            {
                v = true;
            }
            return new TileInfo(tid, p, v, h, o);

        }



        public static ushort getshortilesinfo(TileInfo t)
        {
            ushort tinfo = 0;
            //vhopppcc cccccccc
            tinfo |= (ushort)(t.id);
            tinfo |= (ushort)(t.palette << 10);
            if (t.o == true)
            {
                tinfo |= 0x2000;
            }
            if (t.h == true)
            {
                tinfo |= 0x4000;
            }
            if (t.v == true)
            {
                tinfo |= 0x8000;
            }
            return tinfo;

        }
        public static Color getColor(short c)
        {
            return Color.FromArgb(((c & 0x1F) * 8), ((c & 0x3E0) >> 5) * 8, ((c & 0x7C00) >> 10) * 8);
        }
        

        public static Color[,] editingPalettes; //dynamic
        public static Color[,] loadedPalettes = new Color[1,1];
        public static short paletteid;
        public static Color[,] LoadDungeonPalette(byte id)
        {

            Color[,] palettes = new Color[16,8];


            //id = dungeon palette id
            byte dungeon_palette_ptr = ROM.DATA[Constants.dungeons_palettes_groups + (id * 4)]; //id of the 1st group of 4
            short palette_pos = (short)((ROM.DATA[0xDEC4B+ dungeon_palette_ptr +1] << 8) + ROM.DATA[0xDEC4B+dungeon_palette_ptr]);
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
                    palettes[x, y] = getColor((short)((ROM.DATA[0xDD660 + 1 + j] << 8) + (ROM.DATA[0xDD660 + j])));
                    j += 2;
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

                    palettes[x, y] = getColor((short)((ROM.DATA[Constants.dungeons_palettes + palette_pos + 1 + i] << 8) + ROM.DATA[Constants.dungeons_palettes + palette_pos + i]));
                    if (x == 8)
                    {
                        palettes[x, y] = Color.Black;
                    }
                    i += 2;
                }
            }
            return palettes;
        }
        public static Color[,] loadedSprPalettes = new Color[1, 1];
        public static Color[,] LoadSpritesPalette(byte id)
        {
            Color[,] palettes = new Color[8, 16];
            byte sprite1_palette_ptr = ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 1]; //id of the 1st group of 4
            byte sprite2_palette_ptr = (byte)(ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 2] * 2); //id of the 1st group of 4
            byte sprite3_palette_ptr = (byte)(ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 3] * 2); //id of the 1st group of 4
                                                                                                                // Console.WriteLine(sprite2_palette_ptr);
            short palette_pos1 = (short)((ROM.DATA[0xDEBC6 + sprite1_palette_ptr]));
            short palette_pos2 = (short)((ROM.DATA[0xDEBD6 + sprite2_palette_ptr + 1] << 8) + ROM.DATA[0xDEBD6 + sprite2_palette_ptr]);
            short palette_pos3 = (short)((ROM.DATA[0xDEBD6 + sprite3_palette_ptr + 1] << 8) + ROM.DATA[0xDEBD6 + sprite3_palette_ptr]);
            short palette_pos4 = (short)(ROM.DATA[0xDEBC6 + 10]);
            //id = dungeon palette id
            int i = 0;
            for (int x = 0; x < 7; x++)
            {
                if (x == 0)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        palettes[0, y] = Color.Black;
                    }
                }


                //
                //variable SP-0
                palettes[x + 1, 0] = getColor((short)((ROM.DATA[0xDD39E + palette_pos1 + i + 1] << 8) + ROM.DATA[0xDD39E + palette_pos1 + i]));
                palettes[x + 1, 1] = GFX.loadedPalettes[x + 1, 2];
                //SP-1
                palettes[x + 1, 2] = getColor((short)((ROM.DATA[0xDD218 + i + 1] << 8) + ROM.DATA[0xDD218 + i]));
                palettes[x + 1, 3] = getColor((short)((ROM.DATA[0xDD228 + i + 1] << 8) + ROM.DATA[0xDD228 + i]));
                //SP-2
                palettes[x + 1, 4] = getColor((short)((ROM.DATA[0xDD236 + i + 1] << 8) + ROM.DATA[0xDD236 + i]));
                palettes[x + 1, 5] = getColor((short)((ROM.DATA[0xDD246 + i + 1] << 8) + ROM.DATA[0xDD246 + i]));
                //SP-3
                palettes[x + 1, 6] = getColor((short)((ROM.DATA[0xDD254 + i + 1] << 8) + ROM.DATA[0xDD254 + i]));
                palettes[x + 1, 7] = getColor((short)((ROM.DATA[0xDD264 + i + 1] << 8) + ROM.DATA[0xDD264 + i]));
                //SP-4
                palettes[x + 1, 8] = getColor((short)((ROM.DATA[0xDD272 + i + 1] << 8) + ROM.DATA[0xDD272 + i]));
                palettes[x + 1, 9] = getColor((short)((ROM.DATA[0xDD282 + i + 1] << 8) + ROM.DATA[0xDD282 + i]));
                //SP-5
                palettes[x + 1, 10] = getColor((short)((ROM.DATA[0xDD4E0 + palette_pos2 + i + 1] << 8) + ROM.DATA[0xDD4E0 + palette_pos2 + i]));
                palettes[x + 1, 11] = Color.Black; //SWORD AND SHIELD
                //SP-6
                palettes[x + 1, 12] = getColor((short)((ROM.DATA[0xDD4E0 + palette_pos3 + i + 1] << 8) + ROM.DATA[0xDD4E0 + palette_pos3 + i]));
                palettes[x + 1, 13] = getColor((short)((ROM.DATA[0xDD446 + palette_pos4 + i + 1] << 8) + ROM.DATA[0xDD446 + palette_pos4 + i])); //liftable objects



                //IF GHOST PALETTE?
                //SP-7 ???? WTF IT LINK PALETTE
                palettes[x + 1, 14] = getColor((short)((ROM.DATA[0xDD39E + palette_pos1 + i + 1] << 8) + ROM.DATA[0xDD39E + palette_pos1 + i]));

                i += 2;
            }
            return palettes;

        }


}
}
