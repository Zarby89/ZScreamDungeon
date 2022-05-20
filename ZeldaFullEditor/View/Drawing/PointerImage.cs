﻿namespace ZeldaFullEditor.View.Drawing
{
	/// <summary>
	/// Encapsulates a bitmap and its related pointer for <see langword="unsafe"/> zarby drawing
	/// </summary>
	public unsafe class PointeredImage : IGraphicsCanvas
	{
		private readonly IntPtr ptr;
		private byte* Pointer => (byte*) ptr.ToPointer();

		public Bitmap Bitmap { get; }

		public int Width => Bitmap.Width;
		public int Height => Bitmap.Height;

		public byte this[int i]
		{
			get => Pointer[i];
			set => Pointer[i] = value;
		}

		public byte this[int x, int y]
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		public ColorPalette Palette
		{
			get => Bitmap.Palette;
			set => Bitmap.Palette = value;
		}

		public PointeredImage(int width, int height)
		{
			ptr = Marshal.AllocHGlobal(width * height);
			Bitmap = new Bitmap(width, height, width, PixelFormat.Format8bppIndexed, ptr);
		}
	}
}
