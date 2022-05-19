namespace ZeldaFullEditor
{
	public abstract class Artist
	{
		private const int SheetHeight = 1024;

		public abstract ushort[] Layer1TileMap { get; }
		public abstract PointeredImage Layer1Canvas { get; }

		public abstract ushort[] Layer2TileMap { get; }
		public abstract PointeredImage Layer2Canvas { get; }

		public abstract PointeredImage SpriteCanvas { get; }

		public abstract Bitmap FinalOutput { get; }


		protected virtual bool HasUnacknowledgedChanges
		{
			get => BackgroundTileset != bgtilesflushed ||
				SpriteTileset != sprtilesflushed ||
				BackgroundPalette != bgpalflushed ||
				SpritePalette != sprpalflushed;

		}

		private byte bgtilesflushed = 0xFF;
		public byte BackgroundTileset { get; protected set; }


		private byte sprtilesflushed = 0xFF;
		public byte SpriteTileset { get; protected set; }


		private byte bgpalflushed = 0xFF;
		public byte BackgroundPalette { get; protected set; }

		private byte sprpalflushed = 0xFF;
		public byte SpritePalette { get; protected set; }

		public GraphicsSet LoadedGraphics { get; } = new();

		protected Artist() { }




		public abstract void ReloadPalettes();


		protected static readonly float[][] TranslucencyMatrix = {
			new[] { 1f, 0, 0, 0, 0 },
			new[] { 0, 1f, 0, 0, 0 },
			new[] { 0, 0, 1f, 0, 0 },
			new[] { 0, 0, 0, 0.5f, 0 },
			new[] { 0, 0, 0, 0, 1f }
		};

		public abstract Tile GetDrawnTileAt(int x, int y, RoomLayer l);

		public virtual void HardRefresh()
		{
			bgtilesflushed = BackgroundTileset;
			sprtilesflushed = SpriteTileset;
			bgpalflushed = BackgroundPalette;
			sprpalflushed = SpritePalette;
		}

		public abstract void RebuildBitMap();

		public virtual void RebuildLayers()
		{
			for (int y = 0; y < 64; y++)
			{
				for (int x = 0; x < 64; x++)
				{
					var t = GetDrawnTileAt(x, y, RoomLayer.Layer1);
					LoadedGraphics[t.ID].DrawToCanvas(Layer1Canvas, x * 8, y * 8, t);

					t = GetDrawnTileAt(x, y, RoomLayer.Layer2);
					LoadedGraphics[t.ID].DrawToCanvas(Layer2Canvas, x * 8, y * 8, t);
				}
			}
		}

		public abstract void DrawSelfToImage(Graphics g);

		public unsafe void DrawTileToBuffer(in Tile tile, int x, int y, IGraphicsCanvas canvas)
		{
			var gfx = LoadedGraphics[tile.ID];
			byte palnibble = (byte) (tile.Palette << 4);

			for (int yl = 0; yl < 8; yl++)
			{
				for (int xl = 0; xl < 8; xl++)
				{
					canvas[x + xl, y + yl] = (byte) (gfx.GetPixelAt(x, y, tile.HFlip, tile.VFlip) | palnibble);
				}
			}
		}

		public void ClearBgGfx()
		{
			for (int i = 0; i < 512 * 512; i++)
			{
				Layer1Canvas[i] = 0;
				Layer2Canvas[i] = 0;
			}
		}

		public abstract void DrawTileForPreview(Tile t, int indexoff);

		public virtual void DrawSprite(IDrawableSprite spr, OAMDrawInfo[] instructions,
			int xoff = 0, int yoff = 0, bool useGlobal = false)
		{
			var graphics = LoadedGraphics;
			foreach (var ti in instructions)
			{
				int x = spr.RealX + ti.XOff + xoff;
				int y = spr.RealY + ti.YOff + yoff;

				if (ti.IsBig)
				{
					graphics[ti.TileIndex].DrawToCanvas(SpriteCanvas, ti.HFlip ? x : x + 8, ti.VFlip ? y : y + 8, ti);
					graphics[ti.TileIndex + 1].DrawToCanvas(SpriteCanvas, ti.HFlip ? x + 8 : x, ti.VFlip ? y : y + 8, ti);
					graphics[ti.TileIndex + 16].DrawToCanvas(SpriteCanvas, ti.HFlip ? x : x + 8, ti.VFlip ? y + 8 : y, ti);
					graphics[ti.TileIndex + 17].DrawToCanvas(SpriteCanvas, ti.HFlip ? x + 8: x, ti.VFlip ? y + 8 : y, ti);
				}
				else
				{
					graphics[ti.TileIndex].DrawToCanvas(SpriteCanvas, x, y, ti);
				}
			}
		}
	}
}
