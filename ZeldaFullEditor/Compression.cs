using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace ZeldaFullEditor
{
    public static class Compression
    {
        public static int[] addresses = new int[223];
        public static int[] blockSize = new int[223];
        public static byte[] bpp = new byte[223];

        public static byte[] DecompressTiles() //to gfx.bin
        {
            byte[] buffer = new byte[0x6F800];// (185)
            byte[] bufferBlock;
            int bufferPos = 0;
            for (int i = 0; i < 96; i++)
            {
                int gfxPointer1 = Addresses.snestopc((ROM.DATA[Constants.gfx_1_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_1_pointer]));
                int gfxPointer2 = Addresses.snestopc((ROM.DATA[Constants.gfx_2_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_2_pointer]));
                int gfxPointer3 = Addresses.snestopc((ROM.DATA[Constants.gfx_3_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_3_pointer]));
                byte[] b = new byte[] { ROM.DATA[gfxPointer3 + i], ROM.DATA[gfxPointer2 + i], ROM.DATA[gfxPointer1 + i], 0 };
                int addr = BitConverter.ToInt32(b, 0);
                addresses[i] = Addresses.snestopc(addr);
                //Console.WriteLine(Addresses.snestopc(addr).ToString("X6"));
                byte[] tbufferBlock = ZCompressLibrary.Decompress.ALTTPDecompressGraphics(ROM.DATA, Addresses.snestopc(addr), 0x800, ref blockSize[i]);
                bufferBlock = tbufferBlock;
                if (tbufferBlock.Length != 0x600)
                {
                    bpp[i] = 2;
                    bufferBlock = new byte[0x600];
                    for (int j = 0; j < 0x600; j++)
                    {
                        bufferBlock[j] = tbufferBlock[j];
                    }
                }
                else
                {
                    bpp[i] = 3;
                }
                //bufferBlock = Decompress(Addresses.snestopc(addr), ROM.DATA);
                for (int j = 0; j < bufferBlock.Length; j++)
                {
                    buffer[bufferPos] = bufferBlock[j];
                    bufferPos++;
                }
            }


            for (int i = 96; i < 223; i++)
            {
                bpp[i] = 3;
                if (i < 115 || i > 126) //not compressed
                {

                    int gfxPointer1 = Addresses.snestopc((ROM.DATA[Constants.gfx_1_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_1_pointer]));
                    int gfxPointer2 = Addresses.snestopc((ROM.DATA[Constants.gfx_2_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_2_pointer]));
                    int gfxPointer3 = Addresses.snestopc((ROM.DATA[Constants.gfx_3_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_3_pointer]));
                    byte[] b = new byte[] { ROM.DATA[gfxPointer3 + i], ROM.DATA[gfxPointer2 + i], ROM.DATA[gfxPointer1 + i], 0 };
                    int addr = BitConverter.ToInt32(b, 0);
                    addresses[i] = Addresses.snestopc(addr);
                    byte[] tbufferBlock = ZCompressLibrary.Decompress.ALTTPDecompressGraphics(ROM.DATA, Addresses.snestopc(addr), 0x800, ref blockSize[i]);
                    bufferBlock = tbufferBlock;
                    if (tbufferBlock.Length != 0x600)
                    {
                        bpp[i] = 2;
                        bufferBlock = new byte[0xC00];
                        Console.WriteLine(tbufferBlock.Length);
                        for (int j = 0; j < tbufferBlock.Length; j++)
                        {
                            bufferBlock[j] = tbufferBlock[j];
                        }
                    }

                    for (int j = 0; j < bufferBlock.Length; j++)
                    {
                        buffer[bufferPos] = bufferBlock[j];
                        bufferPos++;
                    }

                }
                else
                {
                    int gfxPointer1 = Addresses.snestopc((ROM.DATA[Constants.gfx_1_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_1_pointer]));
                    int gfxPointer2 = Addresses.snestopc((ROM.DATA[Constants.gfx_2_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_2_pointer]));
                    int gfxPointer3 = Addresses.snestopc((ROM.DATA[Constants.gfx_3_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_3_pointer]));
                    byte[] b = new byte[] { ROM.DATA[gfxPointer3 + i], ROM.DATA[gfxPointer2 + i], ROM.DATA[gfxPointer1 + i], 0 };
                    int addr = BitConverter.ToInt32(b, 0);
                    addr = Addresses.snestopc(addr);
                    bpp[i] = 3;
                    for (int j = 0; j < 0x600; j++)
                    {
                        buffer[bufferPos] = ROM.DATA[addr + j];
                        bufferPos++;
                    }
                }
            }
            FileStream fs = new FileStream("testgfx.gfx", FileMode.OpenOrCreate, FileAccess.Write);
            fs.Write(buffer.ToArray(), 0, buffer.Length);
            fs.Close();
            return buffer;
        }

        /*public static byte[] bpp3tobpp4(byte[] bpp3_data) //to gfx.bin
        {
            List<byte> buffer = new List<byte>();// (97)
                for (int j = 0; j < 64 * 198; j++) //number of 8x8 blocks
            {
                for (int i = 0; i < 16; i++) //those remain the same
                {
                    buffer.Add(bpp3_data[(j * 24) + i]);
                }
                for(int i = 0;i<8;i++)
                {
                    buffer.Add(bpp3_data[(j * 24) + 16 + i]);
                    buffer.Add(0);
                }
            }
            //FileStream fs = new FileStream("testgfx.gfx", FileMode.OpenOrCreate, FileAccess.Write);
            //fs.Write(buffer.ToArray(), 0, buffer.Count);
            //fs.Close();
            return buffer.ToArray();

        }*/
        //(512*512+(128*128))


    




        public static Tile32[] map16tiles = new Tile32[40960];
        public static List<Size> posSize = new List<Size>();
        public static void DecompressAllMapTiles()
        {
                int npos = 0;
            for (int i = 0; i < 160; i++)
            {
                
                int p1 =
                (ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 2 + (int)(3 * i)] << 16) +
                (ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 1 + (int)(3 * i)] << 8) +
                (ROM.DATA[(Constants.compressedAllMap32PointersHigh + (int)(3 * i))]);
                p1 = Addresses.snestopc(p1);

                int p2 =
                (ROM.DATA[(Constants.compressedAllMap32PointersLow) + 2 + (int)(3 * i)] << 16) +
                (ROM.DATA[(Constants.compressedAllMap32PointersLow) + 1 + (int)(3 * i)] << 8) +
                (ROM.DATA[(Constants.compressedAllMap32PointersLow + (int)(3 * i))]);
                p2 = Addresses.snestopc(p2);

                int ttpos = 0;
                int compressedSize1 = 0;
                int compressedSize2 = 0;


                byte[] bytes = ZCompressLibrary.Decompress.ALTTPDecompressOverworld(ROM.DATA, p2, 1000, ref compressedSize1);
                byte[] bytes2 = ZCompressLibrary.Decompress.ALTTPDecompressOverworld(ROM.DATA, p1, 1000, ref compressedSize2);

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        ushort tidD = (ushort)((bytes2[ttpos] << 8) + bytes[ttpos]);

                        int tpos = tidD;
                        if (tpos < GFX.tiles32.Count)
                        {
                            map16tiles[npos] = new Tile32(GFX.tiles32[tpos].tile0, GFX.tiles32[tpos].tile1, GFX.tiles32[tpos].tile2, GFX.tiles32[tpos].tile3);

                        }
                        else
                        {
                            map16tiles[npos] = new Tile32(0,0,0,0);
                        }
                        if (i == 0)
                        {
                            //Console.Write(tpos + ",");
                        }
                        npos++;
                        ttpos += 1;

                    }
                }
           }


        }

        public static void savemapstorom()
        {
            int pos = 0x1A0000;
            for (int i = 0; i < 160; i++)
            {
                int npos = 0;
                byte[] singlemap1 = new byte[256];
                byte[] singlemap2 = new byte[256];
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        singlemap1[npos] = (byte)(t32[npos + (i * 256)] & 0xFF);
                        singlemap2[npos] = (byte)((t32[npos + (i * 256)] >> 8) & 0xFF);
                        npos++;
                    }
                }

                int snesPos = Addresses.pctosnes(pos);
                ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 0 + (int)(3 * i)] = (byte)(snesPos & 0xFF);
                ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 1 + (int)(3 * i)] = (byte)((snesPos >> 8) & 0xFF);
                ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);

                ROM.DATA[pos] = 0xE0;
                ROM.DATA[pos+1] = 0xFF;
                pos += 2;
                for (int j = 0; j < 256; j++)
                {
                    ROM.DATA[pos] = singlemap2[j];
                    pos += 1;
                }
                ROM.DATA[pos] = 0xFF;
                pos += 1;
                snesPos = Addresses.pctosnes(pos);
                ROM.DATA[(Constants.compressedAllMap32PointersLow) + 0 + (int)(3 * i)] = (byte)(snesPos & 0xFF);
                ROM.DATA[(Constants.compressedAllMap32PointersLow) + 1 + (int)(3 * i)] = (byte)((snesPos >> 8) & 0xFF);
                ROM.DATA[(Constants.compressedAllMap32PointersLow) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);

                ROM.DATA[pos] = 0xE0;
                ROM.DATA[pos + 1] = 0xFF;
                pos += 2;
                for (int j = 0; j < 256; j++)
                {
                    ROM.DATA[pos] = singlemap1[j];
                    pos += 1;
                }
                ROM.DATA[pos] = 0xFF;
                pos += 1;

            }
            Save32Tiles();
        }

        public static void saveTile32(int i,int t)
        {
  

        }

        public static void Save32Tiles()
        {
            int index = 0;
            int c = tiles32count;
            for (int i = 0; i < c-4; i += 6)
            {
                if (i >= 0x33C0)
                {
                    Console.WriteLine("Too Many Unique Tiles !");
                    break;
                }

                //Top Left
                ROM.DATA[Constants.map32TilesTL + (i)] = (byte)(t32Unique[index].tile0 & 0xFF);
                ROM.DATA[Constants.map32TilesTL + (i + 1)] = (byte)(t32Unique[index + 1].tile0 & 0xFF);
                ROM.DATA[Constants.map32TilesTL + (i + 2)] = (byte)(t32Unique[index + 2].tile0 & 0xFF);
                ROM.DATA[Constants.map32TilesTL + (i + 3)] = (byte)(t32Unique[index + 3].tile0 & 0xFF);

                ROM.DATA[Constants.map32TilesTL + (i + 4)] = (byte)(((t32Unique[index].tile0 >> 4) & 0xF0) + ((t32Unique[index + 1].tile0 >> 8) & 0x0F));
                ROM.DATA[Constants.map32TilesTL + (i + 5)] = (byte)(((t32Unique[index+2].tile0 >> 4) & 0xF0) + ((t32Unique[index + 3].tile0 >> 8) & 0x0F));

                //Top Right
                ROM.DATA[Constants.map32TilesTR + (i)] = (byte)(t32Unique[index].tile1 & 0xFF);
                ROM.DATA[Constants.map32TilesTR + (i + 1)] = (byte)(t32Unique[index + 1].tile1 & 0xFF);
                ROM.DATA[Constants.map32TilesTR + (i + 2)] = (byte)(t32Unique[index + 2].tile1 & 0xFF);
                ROM.DATA[Constants.map32TilesTR + (i + 3)] = (byte)(t32Unique[index + 3].tile1 & 0xFF);

                ROM.DATA[Constants.map32TilesTR + (i + 4)] = (byte)(((t32Unique[index].tile1 >> 4) & 0xF0) | ((t32Unique[index + 1].tile1 >> 8) & 0x0F));
                ROM.DATA[Constants.map32TilesTR + (i + 5)] = (byte)(((t32Unique[index + 2].tile1 >> 4) & 0xF0) | ((t32Unique[index + 3].tile1 >> 8) & 0x0F));

                //Bottom Left
                ROM.DATA[Constants.map32TilesBL + (i)] = (byte)(t32Unique[index].tile2 & 0xFF);
                ROM.DATA[Constants.map32TilesBL + (i + 1)] = (byte)(t32Unique[index + 1].tile2 & 0xFF);
                ROM.DATA[Constants.map32TilesBL + (i + 2)] = (byte)(t32Unique[index + 2].tile2 & 0xFF);
                ROM.DATA[Constants.map32TilesBL + (i + 3)] = (byte)(t32Unique[index + 3].tile2 & 0xFF);

                ROM.DATA[Constants.map32TilesBL + (i + 4)] = (byte)(((t32Unique[index].tile2 >> 4) & 0xF0) | ((t32Unique[index + 1].tile2 >> 8) & 0x0F));
                ROM.DATA[Constants.map32TilesBL + (i + 5)] = (byte)(((t32Unique[index + 2].tile2 >> 4) & 0xF0) | ((t32Unique[index + 3].tile2 >> 8) & 0x0F));

                //Bottom Right
                ROM.DATA[Constants.map32TilesBR + (i)] = (byte)(t32Unique[index].tile3 & 0xFF);
                ROM.DATA[Constants.map32TilesBR + (i + 1)] = (byte)(t32Unique[index + 1].tile3 & 0xFF);
                ROM.DATA[Constants.map32TilesBR + (i + 2)] = (byte)(t32Unique[index + 2].tile3 & 0xFF);
                ROM.DATA[Constants.map32TilesBR + (i + 3)] = (byte)(t32Unique[index + 3].tile3 & 0xFF);

                ROM.DATA[Constants.map32TilesBR + (i + 4)] = (byte)(((t32Unique[index].tile3 >> 4) & 0xF0) | ((t32Unique[index + 1].tile3 >> 8) & 0x0F));
                ROM.DATA[Constants.map32TilesBR + (i + 5)] = (byte)(((t32Unique[index + 2].tile3 >> 4) & 0xF0) | ((t32Unique[index + 3].tile3 >> 8) & 0x0F));


                index += 4;
                c += 2;
            }

        }

    
        public static void AllMapTilesFromMap(int mapid, ushort[,] tiles,bool large = false)
        {
            if (large == true)
            {
                int tpos = mapid * 256;
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        map16tiles[tpos] = new Tile32(tiles[(x * 2), (y * 2)], tiles[(x * 2) + 1, (y * 2)], tiles[(x * 2), (y * 2) + 1], tiles[(x * 2) + 1, (y * 2) + 1]);
                        tpos++;
                    }
                }
                tpos = ((mapid+1) * 256);
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 16; x < 32; x++)
                    {
                        map16tiles[tpos] = new Tile32(tiles[(x * 2), (y * 2)], tiles[(x * 2) + 1, (y * 2)], tiles[(x * 2), (y * 2) + 1], tiles[(x * 2) + 1, (y * 2) + 1]);
                        tpos++;
                    }
                }
                tpos = ((mapid+8) * 256);
                for (int y = 16; y < 32; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        map16tiles[tpos] = new Tile32(tiles[(x * 2), (y * 2)], tiles[(x * 2) + 1, (y * 2)], tiles[(x * 2), (y * 2) + 1], tiles[(x * 2) + 1, (y * 2) + 1]);
                        tpos++;
                    }
                }
                tpos = ((mapid+9) * 256);
                for (int y = 16; y < 32; y++)
                {
                    for (int x = 16; x < 32; x++)
                    {
                        map16tiles[tpos] = new Tile32(tiles[(x * 2), (y * 2)], tiles[(x * 2) + 1, (y * 2)], tiles[(x * 2), (y * 2) + 1], tiles[(x * 2) + 1, (y * 2) + 1]);
                        tpos++;
                    }
                }
            }
            else
            {
                int tpos = mapid * 256;
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        map16tiles[tpos] = new Tile32(tiles[(x * 2), (y * 2)], tiles[(x * 2) + 1, (y * 2)], tiles[(x * 2), (y * 2) + 1], tiles[(x * 2) + 1, (y * 2) + 1]);
                        tpos++;
                    }
                }
            }
        }



        public static Tile32[] t32Unique = new Tile32[10000];
        public static List<ushort> t32 = new List<ushort>();
        public static int tiles32count = 0;
        public static void createMap32TilesFrom16()
        {
            t32.Clear();
            t32Unique = new Tile32[10000];
            tiles32count = 0;
            //69632 = numbers of 32x32 tiles

            for (int i = 0; i < 40960; i++)
            {
                short foundIndex = -1;
                for (int j = 0; j < tiles32count; j++)
                {
                    if (t32Unique[j].tile0 == map16tiles[i].tile0)
                    {
                        if (t32Unique[j].tile1 == map16tiles[i].tile1)
                        {
                            if (t32Unique[j].tile2 == map16tiles[i].tile2)
                            {
                                if (t32Unique[j].tile3 == map16tiles[i].tile3)
                                {
                                    foundIndex = (short)j;
                                    break;
                                }
                            }
                        }
                    }


                }

                if (foundIndex == -1)
                {
                    t32Unique[tiles32count] = new Tile32(map16tiles[i].tile0, map16tiles[i].tile1, map16tiles[i].tile2, map16tiles[i].tile3);
                    t32.Add((ushort)tiles32count);
                    tiles32count++;
                }
                else
                {
                    t32.Add((ushort)foundIndex);
                }


            }

            Console.WriteLine("Nbr of tiles32 = " + tiles32count);
           
        }
    }

    

 
}
