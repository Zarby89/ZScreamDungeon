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

        public static Graphics graphictilebuffer;

        //public static Bitmap tilebufferbitmap;

        //public static Bitmap[] blocksets;
        public static byte[] gfxdata;

        public static byte[,] imgdata = new byte[128, 32];
        public static byte[] singledata = new byte[128 * 800];
        public static byte[] itemsdataEDITOR = new byte[0x1000*6];

        
        public static Bitmap bgr_bitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);
        public static Bitmap floor2_bitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);
        public static Bitmap bg1_bitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);
        public static Bitmap bg2_bitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);
        public static Bitmap bg2_trans_bitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);
        public static Bitmap room_bitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);
        public static Bitmap[] chestitems_bitmap = new Bitmap[175];
        public static int animated_frame = 0;
        public static int animation_timer = 0;

        public static int[] positions = new int[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
        public static int superpos = 0;

        public static byte[] bpp3snestoindexed(byte[] data, int index)
        {
            //3BPP
            //[r0, bp1], [r0, bp2], [r1, bp1], [r1, bp2], [r2, bp1], [r2, bp2], [r3, bp1], [r3, bp2]
            //[r4, bp1], [r4, bp2], [r5, bp1], [r5, bp2], [r6, bp1], [r6, bp2], [r7, bp1], [r7, bp2]
            //[r0, bp3], [r1, bp3], [r2, bp3], [r3, bp3], [r4, bp3], [r5, bp3], [r6, bp3], [r7, bp3]
            //2BPP
            //[r0, bp1], [r0, bp2], [r1, bp1], [r1, bp2], [r2, bp1], [r2, bp2], [r3, bp1], [r3, bp2]
            //[r4, bp1], [r4, bp2], [r5, bp1], [r5, bp2], [r6, bp1], [r6, bp2], [r7, bp1], [r7, bp2]

            byte[] buffer = new byte[128 * 32];
            byte[,] imgdata = new byte[128, 32];
            int yy = 0;
            int xx = 0;
            int pos = 0;

            for (int i = 0; i < index; i++)
            {
                if (Compression.bpp[i] == 3)
                {
                    pos += 64;
                }
                else
                {
                    pos += 128;
                }
            }

            if (Compression.bpp[index] == 3)
            {
                int ypos = 0;
                for (int i = 0; i < 64; i++) //for each tiles //16 per lines
                {
                    for (int y = 0; y < 8; y++)//for each lines
                    {
                        //[0] + [1] + [16]
                        for (int x = 0; x < 8; x++)
                        {
                            byte[] bitmask = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
                            byte b1 = (byte)((data[(y * 2) + (24 * pos)] & (bitmask[x])));
                            byte b2 = (byte)(data[((y * 2) + (24 * pos)) + 1] & (bitmask[x]));
                            byte b3 = (byte)(data[(16 + y) + (24 * pos)] & (bitmask[x]));
                            byte b = 0;
                            if (b1 != 0) { b |= 1; };
                            if (b2 != 0) { b |= 2; };
                            if (b3 != 0) { b |= 4; };
                            imgdata[x + xx, y + (yy * 8)] = b;
                        }

                    }
                    pos++;
                    ypos++;
                    xx += 8;
                    if (ypos >= 16)
                    {
                        yy++;
                        xx = 0;
                        ypos = 0;

                    }

                }
            }
            else if (Compression.bpp[index] == 2)
            {
                imgdata = new byte[128, 64];
                int ypos = 0;
                for (int i = 0; i < 128; i++) //for each tiles //16 per lines
                {
                    for (int y = 0; y < 8; y++)//for each lines
                    {
                        //[0] + [1] + [16]
                        for (int x = 0; x < 8; x++)
                        {
                            byte[] bitmask = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
                            byte b1 = (byte)((data[(y * 2) + (16 * pos)] & (bitmask[x])));
                            byte b2 = (byte)(data[((y * 2) + (16 * pos)) + 1] & (bitmask[x]));
                            byte b = 0;
                            if (b1 != 0) { b |= 1; };
                            if (b2 != 0) { b |= 2; };
                            imgdata[x + xx, y + (yy * 8)] = b;
                        }

                    }
                    pos++;
                    ypos++;
                    xx += 8;
                    if (ypos >= 16)
                    {
                        yy++;
                        xx = 0;
                        ypos = 0;

                    }

                }
            }
            int n = 0;
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 128; x++)
                {

                    buffer[n] = imgdata[x, y];
                    n++;

                }
            }
            return buffer;//buffer.ToArray();
        }







        public static byte[] blocksetData;

        public static unsafe byte* currentData;
        public static IntPtr currentPtr;
        public static BitmapData currentbmpData;
        public static int currentWidth;
        public static int currentHeight;
        public static unsafe void begin_draw(Bitmap b, int width = 512, int height = 512)
        {
            currentbmpData = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            currentData = (byte*)currentbmpData.Scan0.ToPointer();
            currentWidth = width;
            currentHeight = height;
        }

        public static void end_draw(Bitmap b)
        {
            b.UnlockBits(currentbmpData);
        }

        public static Bitmap singletobmp(byte[] data, int index, int p = 4, bool trans = false)
        {
            Bitmap b = new Bitmap(128, 128);
            
            begin_draw(b, 128, 128);
            unsafe
            {
                for (int x = 0; x < 128; x++)
                {
                    for (int y = 0; y < 128; y++)
                    {

                        int dest = (x + (y * 128)) * 4;
                        if (trans)
                        {
                            if (GFX.singledata[(dest / 4)] == 0)
                            {
                                continue;
                            }
                        }
                        currentData[dest] = (spritesPalettes[GFX.itemsdataEDITOR[(dest / 4)], p].B);
                        currentData[dest + 1] = (spritesPalettes[GFX.itemsdataEDITOR[(dest / 4)], p].G);
                        currentData[dest + 2] = (spritesPalettes[GFX.itemsdataEDITOR[(dest / 4)], p].R);
                        currentData[dest + 3] = 255;
                    }
                }
            }
            end_draw(b);
            return b;
        }
        


        public static Bitmap selectedtobmp(byte[] sheets, int p = 4,bool sprite = false)
        {
            byte[] blocks = new byte[24];
            byte[] data = new byte[blocks.Length * 0x1000];
            int gfxanimatedPointer = (ROM.DATA[Constants.gfx_animated_pointer + 2] << 16) + (ROM.DATA[Constants.gfx_animated_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_animated_pointer]);
            gfxanimatedPointer = Addresses.snestopc(gfxanimatedPointer);
            for (int i = 0; i < blocks.Length; i++)
            {
                if (i < sheets.Length)
                {
                    byte[] d = GFX.bpp3snestoindexed(GFX.gfxdata, sheets[i]);
                    byte[] dd = new byte[0];
                    if (i == 6)
                    {
                        dd = GFX.bpp3snestoindexed(GFX.gfxdata, ROM.DATA[gfxanimatedPointer + 0]); //static animated gfx1
                    }
                    if (i == 7)
                    {
                        dd = GFX.bpp3snestoindexed(GFX.gfxdata, 92); //static animated gfx1
                    }
                    for (int j = 0; j < d.Length; j++)
                    {
                        data[(i * 0x1000) + j] = d[j];
                        if (i == 6)
                        {
                            if (j >= 0xC00)
                            {
                                data[(i * 0x1000) + j] = dd[j-0xC00];
                            }
                        }
                        if (i == 7)
                        {
                            if (j < 0x400)
                            {
                                data[(i * 0x1000) + j] = dd[j];
                            }
                        }
                    }
                }
            }




            Bitmap b = new Bitmap(128, 256);
            begin_draw(b, 128, 256);
            unsafe
            {
                for (int x = 0; x < 128; x++)
                {
                    for (int y = 0; y < 32*sheets.Length; y++)
                    {
                        int dest = (x + (y * 128)) * 4;
                        if (sprite == true)
                        {
                            GFX.currentData[dest] = (GFX.spritesPalettes[data[(dest / 4)], p].B);
                            GFX.currentData[dest + 1] = (GFX.spritesPalettes[data[(dest / 4)], p].G);
                            GFX.currentData[dest + 2] = (GFX.spritesPalettes[data[(dest / 4)], p].R);
                            GFX.currentData[dest + 3] = 255;
                        }
                        else
                        {
                            GFX.currentData[dest] = (GFX.loadedPalettes[data[(dest / 4)], p].B);
                            GFX.currentData[dest + 1] = (GFX.loadedPalettes[data[(dest / 4)], p].G);
                            GFX.currentData[dest + 2] = (GFX.loadedPalettes[data[(dest / 4)], p].R);
                            GFX.currentData[dest + 3] = 255;
                        }
                    }
                }
            }
            end_draw(b);
            return b;
        }


        public static Color getColor(short c)
        {
            return Color.FromArgb(((c & 0x1F) * 8), ((c & 0x3E0) >> 5) * 8, ((c & 0x7C00) >> 10) * 8);
        }
        

        public static Color[,] editingPalettes; //dynamic
        public static Color[,] loadedPalettes;
        public static Color[,] itemsPalettes;
        public static Color[,] spritesPalettes;
        public static short paletteid;
        public static Color[,] LoadDungeonPalette(byte id)
        {
            
            Color[,] palettes = new Color[16,10];
            //id = dungeon palette id
            byte dungeon_palette_ptr = ROM.DATA[Constants.dungeons_palettes_groups + (id * 4)]; //id of the 1st group of 4
            short palette_pos = (short)((ROM.DATA[0xDEC4B+ dungeon_palette_ptr +1] << 8) + ROM.DATA[0xDEC4B+dungeon_palette_ptr]);
            paletteid = palette_pos;
            int i = 0;
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    palettes[x, y] = Color.Black;
                }
            }
            for (int y = 2; y < 10; y++)
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

            //loadedPalettes = palettes;
            //return palettes;
            //int spr1_dungeon_palette = Constants.dungeons_palettes_groups + (id * 4) + 1;
            //int spr2_dungeon_palette = Constants.dungeons_palettes_groups + (id * 4) + 2;
            //int spr3_dungeon_palette = Constants.dungeons_palettes_groups + (id * 4) + 3;



        }

        public static Color[,] testpalette;
        public static void LoadTestPalette(byte id)
        {
            Color[,] palettes = new Color[8, 48];
            //id = dungeon palette id
            int i = 0;
            for (int y = 0; y < 48; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (x == 0) { continue; };
                    palettes[x, y] = getColor((short)((ROM.DATA[0xDD39E + 1 + i] << 8) + ROM.DATA[0xDD39E + i]));
                    i += 2;
                }
            }
            testpalette = palettes;



        }

        public static void LoadItemsPalette(byte id)
        {
            Color[,] palettes = new Color[8, 3];
            //id = dungeon palette id
            int i = 0;
            for (int x = 0; x < 7; x++)
            {
                if (x == 0)
                {
                    palettes[0, 0] = Color.Black;
                    palettes[0, 1] = Color.Black;
                    palettes[0, 2] = Color.Black;
                };
                
                palettes[x+1, 0] = getColor((short)((ROM.DATA[0xDD246+i+1] << 8) + ROM.DATA[0xDD246+i]));
                palettes[x+1, 1] = getColor((short)((ROM.DATA[0xDD228 + i + 1] << 8) + ROM.DATA[0xDD228 + i]));
                palettes[x+1, 2] = getColor((short)((ROM.DATA[0xDD282 + i + 1] << 8) + ROM.DATA[0xDD282 + i]));
                i += 2;
            }
            itemsPalettes = palettes;
        }

        public static Color[,] hudPalettes = new Color[4,16];
        public static void LoadHudPalettes()
        {

            for (int i = 0; i < 16; i++)
            {
                for (int x = 0; x < 4; x++)
                {
                    hudPalettes[x, i] = getColor((short)((ROM.DATA[(Constants.hud_palettes + 1) + (i * 8) + (x * 2)] << 8) + ROM.DATA[(Constants.hud_palettes) + (i * 8) + (x * 2)]));
                }

            }

        }


        public static Color[,] LoadSpritesPalette(byte id)
        {
            Color[,] palettes = new Color[8, 16];
            byte sprite1_palette_ptr = ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 1]; //id of the 1st group of 4
            byte sprite2_palette_ptr = (byte)(ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 2]*2); //id of the 1st group of 4
            byte sprite3_palette_ptr = (byte)(ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 3]*2); //id of the 1st group of 4
           // Console.WriteLine(sprite2_palette_ptr);
            short palette_pos1 = (short)((ROM.DATA[0xDEBC6 + sprite1_palette_ptr ]));
            short palette_pos2 = (short)((ROM.DATA[0xDEBD6 + sprite2_palette_ptr + 1] << 8) + ROM.DATA[0xDEBD6 + sprite2_palette_ptr]);
            short palette_pos3 = (short)((ROM.DATA[0xDEBD6 + sprite3_palette_ptr + 1 ] << 8) + ROM.DATA[0xDEBD6 + sprite3_palette_ptr]);
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
                palettes[x + 1, 1] = loadedPalettes[x+1, 2];
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
