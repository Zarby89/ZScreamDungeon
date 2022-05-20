namespace ZeldaFullEditor
{
	public unsafe class Tile16MasterSheet : IByteable, IPowerfulGraphicsSheet
	{
		private const int TileSpan = 16;
		private const int TilesPerRow = 8;
		private const int TilesPerColumn = 0xE1;
		private const int TilesPerBlock = TilesPerRow * TilesPerColumn;
		private const int ImageWidth = TilesPerRow * TileSpan;
		private const int ImageHeight = TilesPerColumn * TileSpan * 2;

		private readonly Tile16[] ListOf = new Tile16[Constants.NumberOfUniqueTile16Definitions];

		public GraphicsSet Graphics { get; set; }

		public PointeredImage PreviewCanvas { get; }

		public ColorPalette Palette
		{
			get => PreviewCanvas.Palette;
			set => PreviewCanvas.Palette = value;
		}

		public Tile16MasterSheet()
		{
			PreviewCanvas = new PointeredImage(ImageWidth, ImageHeight);
		}

		public void UpdateToMatchScreen(OverworldScreen screen)
		{
			throw new NotImplementedException();
		}

		public void RedrawImageForGraphicsSet()
		{
			throw new NotImplementedException();
		}

		public void RedrawImageForPaletteChange()
		{
			throw new NotImplementedException();
		}

		private static int GetIndexFromXY(int x, int y)
		{
			int X = x / TileSpan / TilesPerRow;
			int block = X / TilesPerBlock * TilesPerBlock;
			X %= TilesPerBlock;
			int Y = TilesPerRow * (y / TileSpan / TilesPerColumn);
			return block + X + Y;
		}

		public void SetTile16At(int id, Tile16 t) => ListOf[id] = t;
		public void SetTile16At(MouseEventArgs e, Tile16 t) => ListOf[GetIndexFromXY(e.X, e.Y)] = t;
		public void SetTile16At(int x, int y, Tile16 t) => ListOf[GetIndexFromXY(x, y)] = t;
		public Tile16 GetTile16At(int id) => ListOf[id];
		public Tile16 SetTile16At(MouseEventArgs e) => ListOf[GetIndexFromXY(e.X, e.Y)];
		public Tile16 GetTile16At(int x, int y) => ListOf[GetIndexFromXY(x, y)];

		public void RefreshGraphicsSheet()
		{
			int x = 0;
			int y = 0;

			foreach(var t in ListOf)
			{
				DrawTile16ToCanvas(PreviewCanvas, x, y, t);

				x += TileSpan;

				if (x >= (TileSpan * TilesPerRow))
				{
					x = 0;
					y += TileSpan;
				}
			}
		}

		public void DrawTile16ToCanvas(IGraphicsCanvas canvas, int x, int y, Tile16 t16)
		{
			Graphics[t16.Tile0.ID].DrawToCanvas(canvas, x, y, t16.Tile0);
			Graphics[t16.Tile1.ID].DrawToCanvas(canvas, x + 8, y, t16.Tile1);
			Graphics[t16.Tile2.ID].DrawToCanvas(canvas, x, y + 8, t16.Tile2);
			Graphics[t16.Tile3.ID].DrawToCanvas(canvas, x + 8, y + 8, t16.Tile3);
		}

		public void DrawTile16ToCanvas(IGraphicsCanvas canvas, int x, int y, ushort t16)
		{
			var t16x = ListOf[t16];
			Graphics[t16x.Tile0.ID].DrawToCanvas(canvas, x, y, t16x.Tile0);
			Graphics[t16x.Tile1.ID].DrawToCanvas(canvas, x + 8, y, t16x.Tile1);
			Graphics[t16x.Tile2.ID].DrawToCanvas(canvas, x, y + 8, t16x.Tile2);
			Graphics[t16x.Tile3.ID].DrawToCanvas(canvas, x + 8, y + 8, t16x.Tile3);
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
