namespace ZeldaFullEditor.UserInterface.Drawing.SNESGraphics
{
	public unsafe class GraphicsSheet : IGraphicsSheet
	{

		private readonly GraphicsTile[] tiles;

		public GFXSheetMeta Info { get; init; } = null;

		public byte? ID => Info.ID ?? 0x00;

		public int Width { get; }
		public int Height { get; }
		public int TileCount { get; }

		public int TileMask => TileCount - 1;

		private PointeredImage bitmap;
		public Bitmap Bitmap => bitmap.Bitmap;

		public GraphicsTile this[int i] => tiles[i];

		public GraphicsTile this[int x, int y] => tiles[x + 16 * y];

		// TODO add grayscale palette for the image
		public GraphicsSheet(byte[] data, SNESPixelFormat format)
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
					throw new ArgumentException(@$"I was not expecting that {nameof(SNESPixelFormat)}! - {format}");
			}

			tiles = new GraphicsTile[TileCount];
			bitmap = new PointeredImage(Width, Height);

			for (int i = 0, t = 0; i < data.Length; t++)
			{
				var tiledata = new byte[64];
				for (var j = 0; j < 64; j++, i++)
				{
					tiledata[j] = data[i];
				}
				GraphicsTile tl = new(tiledata);
				tiles[t] = tl;
				tl.DrawToCanvas(bitmap, t % 16 * 8, t / 16 * 8);
			}

			var pal = bitmap.Palette;
			for (int i = 0; i < 8; i++)
			{
				pal.Entries[i] = GrayScaleKinda[i];
			}
			bitmap.Palette = pal;

			//using SaveFileDialog sf = new SaveFileDialog();
			//sf.DefaultExt = ".png";
			//if (sf.ShowDialog() == DialogResult.OK)
			//{
			//	Bitmap.Save(sf.FileName);
			//}

		}

		private static readonly Color[] GrayScaleKinda = 
		{
			Color.Transparent,
			Color.FromArgb(40, 40, 40),
			Color.FromArgb(90, 90, 90),
			Color.FromArgb(150, 150, 150),
			Color.FromArgb(200, 200, 200),
			Color.FromArgb(240, 240, 240),
			Color.FromArgb(140, 140, 0),
			Color.FromArgb(80, 80, 0),
		};


		public static readonly GraphicsSheet Empty = new(new byte[Constants.Uncompressed3BPPSize], SNESPixelFormat.SNES3BPP);
	}
}
