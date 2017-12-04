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

        public static Bitmap tilebufferbitmap;

        public static Bitmap[] blocksets;
        public static byte[] gfxdata;

        public static byte[,] imgdata = new byte[128, 32];
        public static byte[] singledata = new byte[128 * 800];

        public static Bitmap bgr_bitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);
        public static Bitmap bg1_bitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);
        public static Bitmap room_bitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb); //act as bg2

        public static int[] positions = new int[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
        public static int superpos = 0;
        public static void load4bpp(byte[] data, byte[] blocks, int pos = 0)
        {
            int n = 0;
            for (int b = 0; b < 24; b++)
            {

                pos = blocks[b];

                for (int j = 0; j < 4; j++) //4 par y
                {
                    for (int i = 0; i < 16; i++)
                    {
                        int offset = ((pos * 0x800)) + ((j * 32) * 16) + (i * 32);
                        if (b >= 10)
                        {
                            offset = (((pos + 96) * 0x800)) + ((j * 32) * 16) + (i * 32);
                        }
    
                        for (int x = 0; x < 8; x++)
                        {
                            for (int y = 0; y < 8; y++)
                            {
                                byte tmpbyte = 0;

                                if ((data[offset + (x * 2)] & positions[y]) == positions[y])
                                {
                                    tmpbyte += 1;
                                }
                                if ((data[offset + (x * 2) + 1] & positions[y]) == positions[y])
                                {
                                    tmpbyte += 2;
                                }

                                if ((data[offset + 16 + (x * 2)] & positions[y]) == positions[y])
                                {
                                    tmpbyte += 4;
                                }
                                if ((data[offset + 16 + (x * 2) + 1] & positions[y]) == positions[y])
                                {
                                    tmpbyte += 8;
                                }

                                imgdata[y + (i * 8), x + (j * 8)] = tmpbyte;
                            }
                        }
                        // pos++;
                    }
                }


                    for (int y = 0; y < 32; y++)
                    {
                        for (int x = 0; x < 128; x++)
                        {

                            singledata[n] = imgdata[x, y];
                            n++;

                        }
                    }
            }

            for (int b = 8; b < 10; b++)
            {
                pos = blocks[b];
                for (int j = 0; j < 4; j++) //4 par y
                {
                    for (int i = 0; i < 16; i++)
                    {
                        int offset = ((pos * 0x800)) + ((j * 32) * 16) + (i * 32);
                        if (b >= 10)
                        {
                            offset = (((pos + 96) * 0x800)) + ((j * 32) * 16) + (i * 32);
                        }
                        for (int x = 0; x < 8; x++)
                        {
                            for (int y = 0; y < 8; y++)
                            {
                                byte tmpbyte = 0;

                                if ((data[offset + (x * 2)] & positions[y]) == positions[y])
                                {
                                    tmpbyte += 1;
                                }
                                if ((data[offset + (x * 2) + 1] & positions[y]) == positions[y])
                                {
                                    tmpbyte += 2;
                                }

                                if ((data[offset + 16 + (x * 2)] & positions[y]) == positions[y])
                                {
                                    tmpbyte += 4;
                                }
                                if ((data[offset + 16 + (x * 2) + 1] & positions[y]) == positions[y])
                                {
                                    tmpbyte += 8;
                                }

                                imgdata[y + (i * 8), x + (j * 8)] = tmpbyte;
                            }
                        }
                        // pos++;
                    }
                }
                if (b == 8)
                {
                    int nn = 0;
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 128; x++)
                        {
                            singledata[0x7000 + nn] = imgdata[x, y];
                            nn++;
                        }
                    }

                }
                else if (b == 9)
                {
                    int nn = 0;
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 128; x++)
                        {
                            singledata[0x6C00 + nn] = imgdata[x, y];
                            nn++;
                        }
                    }
                }
            }
        }


        public static Bitmap

        public static byte[] blocksetData;

        public static byte[] currentData;
        public static IntPtr currentPtr;
        public static BitmapData currentbmpData;
        
        public static void begin_draw(Bitmap b, int width = 512, int height = 512)
        {
            currentbmpData = b.LockBits(new Rectangle(0,0,width,height), ImageLockMode.ReadWrite, b.PixelFormat);
            currentPtr = currentbmpData.Scan0;
            int bytes = Math.Abs(currentbmpData.Stride) * b.Height;
            currentData = new byte[bytes];
            Marshal.Copy(currentPtr, currentData, 0, bytes);
        }

        public static void end_draw(Bitmap b)
        {
            int bytes = Math.Abs(currentbmpData.Stride) * b.Height;
            Marshal.Copy(currentData, 0, currentPtr, bytes);
            b.UnlockBits(currentbmpData);
        }

        public static Color getColor(short c)
        {
            return Color.FromArgb(((c & 0x1F) * 8), ((c & 0x3E0) >> 5) * 8, ((c & 0x7C00) >> 10) * 8);
        }

        public static Color[,] loadedPalettes;
        public static Color[,] itemsPalettes;
        public static Color[,] spritesPalettes;
        public static void LoadDungeonPalette(byte id)
        {
            Color[,] palettes = new Color[16,10];
            //id = dungeon palette id
            byte dungeon_palette_ptr = ROM.DATA[Constants.dungeons_palettes_groups + (id * 4)]; //id of the 1st group of 4
            short palette_pos = (short)((ROM.DATA[0xDEC4B+ dungeon_palette_ptr +1] << 8) + ROM.DATA[0xDEC4B+dungeon_palette_ptr]);
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
            loadedPalettes = palettes;
            //return palettes;
            //TODO : Sprites Palettes loaded from dungeons
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


        public static void LoadSpritesPalette(byte id)
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
            spritesPalettes = palettes;
        }



    }
}
