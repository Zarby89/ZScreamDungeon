namespace ZeldaFullEditor
{
	public unsafe class Map16MasterSheet : IGraphicsCanvas, IGraphicsSheet, IByteable
	{
		private readonly IntPtr ptr;
		private byte* Pointer => (byte*) ptr.ToPointer();

		public List<Tile16> ListOf { get; private set; } = new List<Tile16>();

		public GraphicsSet Graphics { get; set; }


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

		public Map16MasterSheet()
		{
			ptr = Marshal.AllocHGlobal(128 * 7136 / 2);
			Bitmap = new Bitmap(128, 7136, 64, PixelFormat.Format4bppIndexed, ptr);
		}

		public byte[] GetByteData()
		{
			var ret = new List<byte>();

			foreach (var tile in ListOf)
			{
				ret.AddRange(tile.GetByteData());
			}

			return ret.ToArray();
		}
	}
}
