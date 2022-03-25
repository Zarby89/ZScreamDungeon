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

				uint size = (uint) GlobalSize(handle);
				buff = new byte[size];

				Marshal.Copy(pointer, buff, 0, (int) size);
				for (int i = 0; i < 40; i++)
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
				byte* imgdata = (byte*) imgData.ToPointer();
				for (int i = 0; i < 40; i++)
				{
					imgdata[i] = headerData[i];
				}
				for (int i = 0; i < 64; i++) // Colors Palettes
				{
					imgdata[i + 40] = palData[i];
				}

				int spos = 0;
				for (int y = 31 * 63; y >= 0; y -= 64)
				{
					for (int x = 0; x < 64; x++)
					{
						imgdata[104 + spos] = idata[x + y];
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
				byte* imgdata = (byte*) imgData.ToPointer();
				for (int i = 0; i < 40; i++)
				{
					imgdata[i] = headerData[i];
				}
				for (int i = 0; i < 8 * 4; i += 4) // Colors Palettes
				{
					pals[i] = Color.FromArgb(palData[i + 2], palData[i + 1], palData[i]);
				}

				int spos = 0x1028; // 0x1000 + 0d40
				for (int y = 31 * 64; y >= 0; y -= 64)
				{
					for (int x = 0; x < 64; x++)
					{
						byte b1 = (byte) (idata[x + y] >> 4);
						byte b2 = (byte) (idata[x + y] & 0x0F);
						imgdata[spos++] = pals[b1].B;
						imgdata[spos++] = pals[b1].G;
						imgdata[spos++] = pals[b1].R;
						imgdata[spos++] = 255;
						imgdata[spos++] = pals[b2].B;
						imgdata[spos++] = pals[b2].G;
						imgdata[spos++] = pals[b2].R;
						imgdata[spos++] = 255;
					}
				}

				int v = 0;
				for (int p = 0, p2 = 0; p < 16; p++, p2 += 32) // each color
				{
					for (int i = 0; i < 8 * 512; i += 512) // each lines
					{
						for (int j = 0; j < 8 * 4; j += 4) // each pixels
						{
							v = p % 8;

							// 1 pixel
							imgdata[40 + j + p2 + i] = pals[v].B;
							imgdata[41 + j + p2 + i] = pals[v].G;
							imgdata[42 + j + p2 + i] = pals[v].R;
							imgdata[43 + j + p2 + i] = 255;
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
