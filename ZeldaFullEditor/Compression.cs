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

    }
}
