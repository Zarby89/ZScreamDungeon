using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public unsafe class GraphicsSheet : IGraphicsSheet
	{
		private readonly IntPtr ptr;
		public byte* Pointer => (byte*) ptr.ToPointer();

		public byte ID { get; }
		public int Width { get; }
		public int Height { get; }

		public Bitmap Bitmap { get; }

		public byte this[int i]
		{
			get
			{
				return Pointer[i];
			}
		}
		
		public byte this[int x, int y]
		{
			get
			{
				return Pointer[x + Width * y];
			}
		}

		// TODO add grayscale palette for the image
		public GraphicsSheet(byte id, byte[] data, SNESPixelFormat format)
		{
			switch (format)
			{
				case SNESPixelFormat.SNES2BPP:
				case SNESPixelFormat.SNES2BPPCompressed:
					Width = 128;
					Height = 64;
					break;

				case SNESPixelFormat.SNES3BPP:
				case SNESPixelFormat.SNES3BPPCompressed:
					Width = 128;
					Height = 32;
					break;

				default:
					throw new NotImplementedException();
			}

			ID = id;

			ptr = Marshal.AllocHGlobal(Width * Height);
			Bitmap = new Bitmap(Width, Height, Width, PixelFormat.Format8bppIndexed, ptr);

			var draw = Pointer;
			
			for (int i = 0; i < data.Length; i++)
			{
				draw[i] = data[i];
			}
		}
	}
}
