namespace ZeldaFullEditor.UserInterface.Drawing.Artists
{
	public abstract class Artist
	{
		public abstract ushort[] Layer1TileMap { get; }
		public abstract PointeredImage Layer1Canvas { get; }

		public abstract ushort[] Layer2TileMap { get; }
		public abstract PointeredImage Layer2Canvas { get; }

		public abstract PointeredImage SpriteCanvas { get; }

		/// <summary>
		/// The final, fully-processed and fully-drawn <see cref="Bitmap"/> image produced by this artist.
		/// </summary>
		public abstract Bitmap FinalOutput { get; }

		public bool Valid { get; private set; }

		protected abstract GraphicsSet LoadedGraphics { get; }

		protected Artist() { }




		public abstract void ReloadPalettes();

		protected void RefreshPalettesFrom(FullPalette pal)
		{
			var copy = pal.ToColorArray();
			var palettes = Layer1Canvas.Palette;

			for (int i = 0; i < copy.Length; i++)
			{
				palettes.Entries[i] = copy[i];
			}

			Layer1Canvas.Palette = palettes;
			Layer2Canvas.Palette = palettes;
		}

		protected static readonly float[][] TranslucencyMatrix = {
			new[] { 1f, 0, 0, 0, 0 },
			new[] { 0, 1f, 0, 0, 0 },
			new[] { 0, 0, 1f, 0, 0 },
			new[] { 0, 0, 0, 0.5f, 0 },
			new[] { 0, 0, 0, 0, 1f }
		};

		public abstract Tile GetLayer1TileAt(int x, int y);
		public abstract Tile GetLayer2TileAt(int x, int y);

		public void Invalidate()
		{
			Valid = false;
		}

		protected void Revalidate()
		{
			if (Valid) return;

			ReloadPalettes();
			RebuildBitMap();

			Valid = true;
		}

		public abstract void RebuildBitMap();

		public virtual void RebuildLayers()
		{
			for (var y = 0; y < 64; y++)
			{
				for (var x = 0; x < 64; x++)
				{
					var t = GetLayer1TileAt(x, y);
					DrawTileToBuffer(t, x * 8, y * 8, Layer1Canvas);

					t = GetLayer2TileAt(x, y);
					DrawTileToBuffer(t, x * 8, y * 8, Layer2Canvas);
				}
			}
		}

		public abstract void DrawSelfToImage(Graphics g);

		public void DrawTileToBuffer(in Tile tile, int x, int y, IGraphicsCanvas canvas)
		{
			var (til, pal) = LoadedGraphics.GetBackgroundTileWithPalette(tile);
			til.DrawToCanvas(canvas, x, y, (byte) pal, tile.HFlip, tile.VFlip);


			//var gfx = LoadedGraphics[tile.ID];
			//var palnibble = (byte) (tile.Palette << 4);
			//for (var yl = 0; yl < 8; yl++)
			//{
			//	for (var xl = 0; xl < 8; xl++)
			//	{
			//		canvas[x + xl, y + yl] = (byte) (gfx.GetPixelAt(x, y, tile.HFlip, tile.VFlip) | palnibble);
			//	}
			//}
		}

		public void ClearBgGfx()
		{
			for (var i = 0; i < 512 * 512; i++)
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
				var x = spr.RealX + ti.XOff + xoff;
				var y = spr.RealY + ti.YOff + yoff;

				var (tnw, pnw) = graphics.GetSpriteTileWithPalette(ti);

				if (ti.IsBig)
				{
					var (tne, pne) = graphics.GetSpriteTileWithPalette((ushort) (ti.TileIndex + 1), ti.Palette);
					var (tsw, psw) = graphics.GetSpriteTileWithPalette((ushort) (ti.TileIndex + 16), ti.Palette);
					var (tse, pse) = graphics.GetSpriteTileWithPalette((ushort) (ti.TileIndex + 17), ti.Palette);

					tnw.DrawToCanvas(SpriteCanvas, ti.HFlip ? x : x + 8, ti.VFlip ? y : y + 8, (byte) pnw, ti.HFlip, ti.VFlip);
					tne.DrawToCanvas(SpriteCanvas, ti.HFlip ? x + 8 : x, ti.VFlip ? y : y + 8, (byte) pne, ti.HFlip, ti.VFlip);
					tsw.DrawToCanvas(SpriteCanvas, ti.HFlip ? x : x + 8, ti.VFlip ? y + 8 : y, (byte) psw, ti.HFlip, ti.VFlip);
					tse.DrawToCanvas(SpriteCanvas, ti.HFlip ? x + 8 : x, ti.VFlip ? y + 8 : y, (byte) pse, ti.HFlip, ti.VFlip);
				}
				else
				{
					tnw.DrawToCanvas(SpriteCanvas, x, y, (byte) pnw, ti.HFlip, ti.VFlip);
				}
			}
		}
	}
}
