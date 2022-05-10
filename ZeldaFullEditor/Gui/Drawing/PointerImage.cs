namespace ZeldaFullEditor
{
	public unsafe class PointeredImage : IGraphicsCanvas
	{

		private readonly IntPtr ptr;
		private byte* Pointer => (byte*) ptr.ToPointer();

		public Bitmap Bitmap { get; }

		public byte this[int i]
		{
			get => Pointer[i];
			set => Pointer[i] = value;
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
