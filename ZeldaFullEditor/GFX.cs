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
        public static Bitmap[] blocksets_items;
        public static byte[] gfxdata;

        public static byte[,] imgdata = new byte[128, 32];
        public static byte[] singledata = new byte[128 * 448];

        public static byte[,] imgdataitems = new byte[128, 32];
        public static byte[] singledataitems = new byte[128 * 128];
        public static int[] positions = new int[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
        public static int superpos = 0;
        public static void load4bpp(byte[] data, byte[] blocks, int pos = 0)
        {
            int n = 0;
            for (int b = 0; b < 14; b++)
            {
                pos = blocks[b];
                for (int j = 0; j < 4; j++) //4 par y
                {
                    for (int i = 0; i < 16; i++)
                    {
                        int offset = ((pos * 0x800))+ ((j * 32) * 16) + (i * 32);
                        if (b >= 10)
                        {
                            offset = (((pos+96) * 0x800)) + ((j * 32) * 16) + (i * 32);
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

        }


        public static void load4bppItems(byte[] data, byte[] blocks, int pos = 0)
        {
            int n = 0;
            for (int b = 0; b < 4; b++)
            {
                pos = 186+b;
                for (int j = 0; j < 4; j++) //4 par y
                {
                    for (int i = 0; i < 16; i++)
                    {
                        int offset = ((pos * 0x800)) + ((j * 32) * 16) + (i * 32);
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

                                imgdataitems[y + (i * 8), x + (j * 8)] = tmpbyte;
                            }
                        }
                        // pos++;
                    }
                }



                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 128; x++)
                    {

                        singledataitems[n] = imgdataitems[x, y];
                        n++;

                    }
                }


            }

        }


        public static void create_gfxs()
        {
            blocksets = new Bitmap[14];
            for (int j = 0; j < 14; j++)
            {
                blocksets[j] = new Bitmap(128, 448, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            }

            for (int j = 2; j < 14; j++)
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
                            if (j < 8)
                            {
                                pp = 8;
                                rgbValues[(i - 2)] = (byte)(GFX.loadedPalettes[singledata[(i / 3)] + pp, j - 2].B);
                                rgbValues[(i) - 1] = (byte)(GFX.loadedPalettes[singledata[(i / 3)] + pp, j - 2].G);
                                rgbValues[(i)] = (byte)(GFX.loadedPalettes[singledata[(i / 3)] + pp, j - 2].R);
                            }
                        }
                        else if (i >= 122880)
                        {

                            rgbValues[(i - 2)] = (byte)(GFX.spritesPalettes[singledata[(i / 3)], j - 2].B);
                            rgbValues[(i) - 1] = (byte)(GFX.spritesPalettes[singledata[(i / 3)] + pp, j - 2].G);
                            rgbValues[(i)] = (byte)(GFX.spritesPalettes[singledata[(i / 3)] + pp, j - 2].R);
                        }
                        else
                        {
                            if (j < 8)
                            {
                                rgbValues[(i - 2)] = (byte)(GFX.loadedPalettes[singledata[(i / 3)] + pp, j - 2].B);
                                rgbValues[(i) - 1] = (byte)(GFX.loadedPalettes[singledata[(i / 3)] + pp, j - 2].G);
                                rgbValues[(i)] = (byte)(GFX.loadedPalettes[singledata[(i / 3)] + pp, j - 2].R);
                            }
                        }
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
        public static Color[,] itemsPalettes;
        public static Color[,] spritesPalettes;
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
            Color[,] palettes = new Color[8, 14];
            byte sprite1_palette_ptr = ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 1]; //id of the 1st group of 4
            byte sprite2_palette_ptr = ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 2]; //id of the 1st group of 4
            byte sprite3_palette_ptr = ROM.DATA[Constants.dungeons_palettes_groups + (id * 4) + 3]; //id of the 1st group of 4
            Console.WriteLine(sprite2_palette_ptr);
            short palette_pos1 = (short)((ROM.DATA[0xDEBC6 + sprite1_palette_ptr ]));
            short palette_pos2 = (short)((ROM.DATA[0xDEBD6 + sprite2_palette_ptr + 1] << 8) + ROM.DATA[0xDEBD6 + sprite2_palette_ptr]);
            short palette_pos3 = (short)((ROM.DATA[0xDEBD6 + sprite3_palette_ptr + 1 ] << 8) + ROM.DATA[0xDEBD6 + sprite3_palette_ptr]);
            //id = dungeon palette id
            int i = 0;
            for (int x = 0; x < 7; x++)
            {
                if (x == 0)
                {
                    palettes[0, 0] = Color.Black;
                    palettes[0, 1] = Color.Black;
                    palettes[0, 2] = Color.Black;
                    palettes[0, 3] = Color.Black;
                    palettes[0, 4] = Color.Black;
                    palettes[0, 5] = Color.Black;
                    palettes[0, 6] = Color.Black;
                    palettes[0, 7] = Color.Black;
                    palettes[0, 8] = Color.Black;
                    palettes[0, 9] = Color.Black;
                    palettes[0, 10] = Color.Black;
                    palettes[0, 11] = Color.Black;
                    palettes[0, 13] = Color.Black;
                };


                //
                //variable
                palettes[x + 1, 0] = getColor((short)((ROM.DATA[0xDD4E0 + palette_pos2 + i + 1] << 8) + ROM.DATA[0xDD4E0 + palette_pos2 + i]));
                palettes[x + 1, 1] = getColor((short)((ROM.DATA[0xDD4E0 + palette_pos2 + i + 1] << 8) + ROM.DATA[0xDD4E0 + palette_pos2 + i]));
                //variable


                palettes[x + 1, 2] = getColor((short)((ROM.DATA[0xDD218 + i + 1] << 8) + ROM.DATA[0xDD218 + i]));
                palettes[x + 1, 3] = getColor((short)((ROM.DATA[0xDD228 + i + 1] << 8) + ROM.DATA[0xDD228 + i]));
                palettes[x + 1, 4] = getColor((short)((ROM.DATA[0xDD236 + i + 1] << 8) + ROM.DATA[0xDD236 + i]));
                palettes[x + 1, 5] = getColor((short)((ROM.DATA[0xDD246 + i + 1] << 8) + ROM.DATA[0xDD246 + i]));
                palettes[x + 1, 6] = getColor((short)((ROM.DATA[0xDD254 + i + 1] << 8) + ROM.DATA[0xDD254 + i]));
                palettes[x + 1, 7] = getColor((short)((ROM.DATA[0xDD264 + i + 1] << 8) + ROM.DATA[0xDD264 + i]));
                palettes[x + 1, 8] = getColor((short)((ROM.DATA[0xDD272 + i + 1] << 8) + ROM.DATA[0xDD272 + i]));
                palettes[x + 1, 9] = getColor((short)((ROM.DATA[0xDD282 + i + 1] << 8) + ROM.DATA[0xDD282 + i]));
                //variable
                palettes[x + 1, 10] = getColor((short)((ROM.DATA[0xDD39E + palette_pos1 + i + 1] << 8) + ROM.DATA[0xDD39E + palette_pos1 + i]));
                
                palettes[x + 1, 11] = getColor((short)((ROM.DATA[0xDD4E0 + palette_pos2 + i + 1] << 8) + ROM.DATA[0xDD4E0 + palette_pos2 + i])); //SWORD AND SHIELD
                palettes[x + 1, 12] = getColor((short)((ROM.DATA[0xDD4E0 + palette_pos3 + i + 1] << 8) + ROM.DATA[0xDD4E0 + palette_pos3 + i]));
                palettes[x + 1, 13] = getColor((short)((ROM.DATA[0xDD4E0 + palette_pos3 + i + 1] << 8) + ROM.DATA[0xDD4E0 + palette_pos3 + i]));
                i += 2;
            }
            spritesPalettes = palettes;
        }

        public static void create_items_gfxs()
        {
            blocksets_items = new Bitmap[3];
            for (int j = 0; j < 3; j++)
            {
                blocksets_items[j] = new Bitmap(128, 128, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            }

            for (int j = 0; j < 3; j++)
            {
                Rectangle rect = new Rectangle(0, 0, blocksets_items[j].Width, blocksets_items[j].Height);
                System.Drawing.Imaging.BitmapData bmpData =
                    blocksets_items[j].LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    blocksets_items[j].PixelFormat);

                IntPtr ptr = bmpData.Scan0;
                int bytes = Math.Abs(bmpData.Stride) * blocksets_items[j].Height;
                byte[] rgbValues = new byte[bytes];

                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                int pp = 0; //palete position
                for (int i = 2; i < (rgbValues.Length); i += 3)
                {
                    if (singledataitems[(i / 3)] != 0)
                    {
                        pp = 0;
                        rgbValues[(i - 2)] = (byte)(GFX.itemsPalettes[singledataitems[(i / 3)] + pp, j].B);
                        rgbValues[(i) - 1] = (byte)(GFX.itemsPalettes[singledataitems[(i / 3)] + pp, j].G);
                        rgbValues[(i) ] = (byte)(GFX.itemsPalettes[singledataitems[(i / 3)] + pp, j].R);
                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

                blocksets_items[j].UnlockBits(bmpData);
                
            }
        }


    }
}
