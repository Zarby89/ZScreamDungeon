using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    public static class ImgClipboard
    {
        [DllImport("User32.dll", SetLastError = true)]
        private static extern uint RegisterClipboardFormat(string lpszFormat);
        // Or specifically - private static extern uint RegisterClipboardFormatA(string lpszFormat);

        [DllImport("User32.dll", SetLastError = true)]
        private static extern bool IsClipboardFormatAvailable(uint format);

        [DllImport("User32.dll", SetLastError = true)]
        private static extern IntPtr GetClipboardData(uint uFormat);

        [DllImport("User32.dll", SetLastError = true)]
        private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseClipboard();

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern IntPtr GlobalLock(IntPtr hMem);

        [DllImport("Kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GlobalUnlock(IntPtr hMem);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern int GlobalSize(IntPtr hMem);

        public static byte[] GetImageData()
        {
            byte[] buff = new byte[0];
            if (!OpenClipboard(IntPtr.Zero))
                return null;

            IntPtr pointer = IntPtr.Zero;

            if (IsClipboardFormatAvailable(8))
            {
                IntPtr handle = GetClipboardData(8); // CF_DIB
                if (handle == IntPtr.Zero)
                    return null;

                pointer = GlobalLock(handle);
                if (pointer == IntPtr.Zero)
                    return null;

                uint size = (uint)GlobalSize(handle);
                buff = new byte[size];

                Marshal.Copy(pointer, buff, 0, (int)size);
                for(int i = 0;i<40;i++)
                {
                    Console.Write(buff[i].ToString("X2") + " ");
                }
            }

            CloseClipboard();
            return buff;
        }

        
        //static IntPtr imgData = Marshal.AllocHGlobal(4200);
        public static void SetImageData(byte[] idata, byte[] palData)
        {
            IntPtr imgData = Marshal.AllocHGlobal(2152);
            Clipboard.Clear();
            // Header is always the same so no need to write a dynamic one (except for 2bpp but that'll be later)
            byte[] headerData = new byte[40] {
                0x28, 0x00, 0x00, 0x00, // ? dib header
                0x80, 0x00, 0x00, 0x00, // Width
                0x20, 0x00, 0x00, 0x00, // Height
                0x01, 0x00, // Planes
                0x04, 0x00, // Bpp
                0x00, 0x00, 0x00, 0x00, // ??
                0x00, 0x08, 0x00, 0x00, // Numbers of byte for the image (0x800
                0x00, 0x00, 0x00, 0x00, // ??
                0x00, 0x00, 0x00, 0x00, // ??
                0x00, 0x00, 0x00, 0x00, // ??
                0x00, 0x00, 0x00, 0x00 // ??
            };

            unsafe
            {
                byte* imgdata = (byte*)imgData.ToPointer();
                for(int i = 0;i<40;i++)
                {
                    imgdata[i] = headerData[i];
                }
                for(int i = 0; i<64;i++) // Colors Palettes
                {
                    imgdata[i + 40] = palData[i];
                }

                int spos = 0;
                for (int y = 31; y >= 0; y--)
                {
                    for (int x = 0; x < 64; x++)
                    {
                        imgdata[104 + (spos)] = idata[(x + (y * 64))];
                        spos++;
                    }
                }
            }

            GlobalLock(imgData);
            OpenClipboard(IntPtr.Zero);

            SetClipboardData(8, imgData);
            //SetClipboardData(8, imgDataB);

            CloseClipboard();
            GlobalUnlock(imgData);
            //Marshal.FreeHGlobal(imgData);
        }

        public static void SetImageDataWithPal(byte[] idata, byte[] palData)
        {
            IntPtr imgData = Marshal.AllocHGlobal(0x5028);
            Clipboard.Clear();
            // Header is always the same so no need to write a dynamic one (except for 2bpp but that'll be later)
            byte[] headerData = new byte[40] {
                0x28, 0x00, 0x00, 0x00, // ? dib header
                0x80, 0x00, 0x00, 0x00, // Width
                0x28, 0x00, 0x00, 0x00, // Height
                0x01, 0x00, // Planes
                0x20, 0x00, // Bpp 
                0x00, 0x00, 0x00, 0x00, // ??
                0x00, 0x50, 0x00, 0x00, // Numbers of byte for the image (0x5000)
                0x00, 0x00, 0x00, 0x00, // ??
                0x00, 0x00, 0x00, 0x00, // ??
                0x00, 0x00, 0x00, 0x00, // ??
                0x00, 0x00, 0x00, 0x00 // ??
            };

            Color[] pals = new Color[8];
            unsafe
            {
                byte* imgdata = (byte*)imgData.ToPointer();
                for (int i = 0; i < 40; i++)
                {
                    imgdata[i] = headerData[i];
                }
                for (int i = 0; i < 8; i++) // Colors Palettes
                {
                    pals[i] = Color.FromArgb(palData[(i*4)+2], palData[(i * 4) + 1], palData[(i * 4)]);
                }

                int spos = 0x1000;
                for (int y = 31; y >= 0; y--)
                {
                    for (int x = 0; x < 64; x++)
                    {
                        byte b1 = (byte)((idata[(x + (y * 64))]>>4) & 0x0F);
                        byte b2 = (byte)((idata[(x + (y * 64))]) & 0x0F);
                        imgdata[40 + (spos)] = pals[b1].B;
                        imgdata[40 + (spos) + 1] = pals[b1].G;
                        imgdata[40 + (spos) + 2] = pals[b1].R;
                        imgdata[40 + (spos) + 3] = 255;

                        imgdata[40 + (spos) + 4] = pals[b2].B;
                        imgdata[40 + (spos) + 5] = pals[b2].G;
                        imgdata[40 + (spos) + 6] = pals[b2].R;
                        imgdata[40 + (spos) + 7] = 255;
                        spos +=8;
                    }
                }

                int v = 0;
                for (int p = 0; p < 16; p++) // each color
                {
                    for (int i = 0; i < 8; i++) // each lines
                    {
                        for (int j = 0; j < 8; j++) // each pixels
                        {
                            v = p;
                            if (p >= 8)
                            {
                                v = p - 8;
                            }

                            // 1 pixel
                            imgdata[40 + (j * 4)+ (p * 32) + 0 + (i * 512)] = pals[v].B;
                            imgdata[40 + (j * 4)+ (p * 32) + 1 + (i * 512)] = pals[v].G;
                            imgdata[40 + (j * 4)+ (p * 32) + 2 + (i * 512)] = pals[v].R;
                            imgdata[40 + (j * 4)+ (p * 32) + 3 + (i * 512)] = 255;
                        }
                    }
                }

            }

            OpenClipboard(IntPtr.Zero);

            SetClipboardData(8, imgData);
            //SetClipboardData(8, imgDataB);

            CloseClipboard();
            //Marshal.FreeHGlobal(imgData);
        }
    }
}
