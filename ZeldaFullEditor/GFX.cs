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
    public static class GFX
    {

        public static Graphics graphictilebuffer;

        public static Bitmap tilebufferbitmap;





        public static Bitmap[] blocksets;
        public static byte[] gfxdata;

        public static byte[,] imgdata = new byte[128, 32];
        public static byte[] singledata = new byte[128 * 320];
        public static int[] positions = new int[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
        public static int superpos = 0;
        public static void load4bpp(byte[] data, byte[] blocks, int pos = 0)
        {


            int n = 0;
            for (int b = 0; b < 10; b++)
            {
                pos = blocks[b];
                for (int j = 0; j < 4; j++) //4 par y
                {
                    for (int i = 0; i < 16; i++)
                    {
                        int offset = ((pos * 0x800))+ ((j * 32) * 16) + (i * 32);
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

        }


        public static void create_gfxs()
        {
            blocksets = new Bitmap[8];
            for (int j = 0; j < 8; j++)
            {
                blocksets[j] = new Bitmap(128, 320, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            }

            for (int j = 2; j < 8; j++)
            {
                Rectangle rect = new Rectangle(0, 0, blocksets[j].Width, blocksets[j].Height);
                System.Drawing.Imaging.BitmapData bmpData =
                    blocksets[j].LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    blocksets[j].PixelFormat);

                IntPtr ptr = bmpData.Scan0;
                int bytes = Math.Abs(bmpData.Stride) * blocksets[j].Height;
                byte[] rgbValues = new byte[bytes];

                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                int pp; //palete position
                for (int i = 2; i < (rgbValues.Length); i += 3)
                {
                    if (singledata[(i / 3)] != 0)
                    {
                        pp = 0;
                        if ((i) < (49152)) //half of gfx use right side of palette other part use left side
                        {
                            pp = 8;
                        }
                        rgbValues[(i - 2)] = (byte)(GFX.loadedPalettes[singledata[(i / 3)] + pp, j-2].B);
                        rgbValues[(i) - 1] = (byte)(GFX.loadedPalettes[singledata[(i / 3)] + pp, j-2].G);
                        rgbValues[(i)] = (byte)(GFX.loadedPalettes[singledata[(i / 3)] + pp, j-2].R);
                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

                blocksets[j].UnlockBits(bmpData);

            }
        }


        public static void animate_gfxs()
        {
            for (int j = 2; j < 8; j++)
            {
                int frame = 0;
                Rectangle rect = new Rectangle(0, 216, 128, 16);
                System.Drawing.Imaging.BitmapData bmpData =
                blocksets[j].LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                blocksets[j].PixelFormat);

                IntPtr ptr = bmpData.Scan0;
                int bytes = Math.Abs(bmpData.Stride) * 16;
                byte[] rgbValues = new byte[bytes];

                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                int p = 0;
                for (int i = 2; i < (rgbValues.Length); i += 3)
                {

                    if ((i / 3) > 1024)
                    {
                        p = -5120;

                    }
                    if (singledata[36864 + p + (frame * 1024) + (i / 3)] != 0)
                    {
                        rgbValues[(i - 2)] = (byte)(GFX.loadedPalettes[singledata[(36864) + p + (frame * 1024) + (i / 3)], j - 2].B);
                        rgbValues[(i) - 1] = (byte)(GFX.loadedPalettes[singledata[(36864) + p + (frame * 1024) + (i / 3)], j - 2].G);
                        rgbValues[(i)] = (byte)(GFX.loadedPalettes[singledata[(36864) + p + (frame * 1024) + (i / 3)], j - 2].R);

                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

                blocksets[j].UnlockBits(bmpData);
            }
        }

        public static Color getColor(short c)
        {
            return Color.FromArgb(((c & 0x1F) * 8), ((c & 0x3E0) >> 5) * 8, ((c & 0x7C00) >> 10) * 8);
        }

        public static Color[,] loadedPalettes;

        public static void LoadDungeonPalette(byte id)
        {
            Color[,] palettes = new Color[16,6];
            //id = dungeon palette id
            byte dungeon_palette_ptr = ROM.DATA[Constants.dungeons_palettes_groups + (id * 4)]; //id of the 1st group of 4
            short palette_pos = (short)((ROM.DATA[0xDEC4B+ dungeon_palette_ptr +1] << 8) + ROM.DATA[0xDEC4B+dungeon_palette_ptr]);
            int i = 0;
            for (int y = 0; y < 6; y ++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (x == 0) { continue; };
                    palettes[x, y] = getColor((short)((ROM.DATA[Constants.dungeons_palettes + palette_pos + 1 + i] << 8) + ROM.DATA[Constants.dungeons_palettes + palette_pos + i]));
                    i+=2;
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


    }
}
