namespace ZeldaFullEditor.View.Drawing.SNESGraphics
{
	public unsafe class GraphicsSheet : IGraphicsSheet
	{
		private readonly IntPtr ptr;
		private byte* Pointer => (byte*) ptr.ToPointer();

		private readonly GraphicsTile[] tiles;

		public GFXSheetMeta Info { get; init; } = null;

		public byte ID { get; }
		public int Width { get; }
		public int Height { get; }
		public int TileCount { get; }

		public int TileMask => TileCount - 1;

		public Bitmap Bitmap { get; }

		public GraphicsTile this[int i] => tiles[i];

		public GraphicsTile this[int x, int y] => tiles[x + 16 * y];

		// TODO add grayscale palette for the image
		public GraphicsSheet(byte id, byte[] data, SNESPixelFormat format)
		{
			switch (format)
			{
				case SNESPixelFormat.SNES2BPP:
				case SNESPixelFormat.SNES2BPPCompressed:
					Width = 128;
					Height = 64;
					TileCount = 8 * 16;
					break;

				case SNESPixelFormat.SNES3BPP:
				case SNESPixelFormat.SNES3BPPCompressed:
					Width = 128;
					Height = 32;
					TileCount = 4 * 16;
					break;

				case SNESPixelFormat.SNES4BPP:
				case SNESPixelFormat.SNES4BPPCompressed:
					Width = 128;
					Height = 32;
					TileCount = 4 * 16;
					break;

				default:
					throw new NotImplementedException();
			}

			ID = id;
			tiles = new GraphicsTile[TileCount];
			ptr = Marshal.AllocHGlobal(Width * Height);
			Bitmap = new Bitmap(Width, Height, Width, PixelFormat.Format8bppIndexed, ptr);

			var draw = Pointer;

			for (int i = 0, t = 0; i < data.Length; t++)
			{
				var tiledata = new byte[64];
				for (var j = 0; j < 64; j++, i++)
				{
					draw[i] = data[i];
					tiledata[j] = data[i];
				}
				tiles[t] = new(tiledata);
			}
		}

		public static readonly GraphicsSheet Empty = new(0xFF, new byte[Constants.Uncompressed3BPPSize], SNESPixelFormat.SNES3BPP);
	}
}
