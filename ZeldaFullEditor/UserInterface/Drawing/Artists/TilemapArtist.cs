namespace ZeldaFullEditor.UserInterface.Drawing.Artists
{
	public abstract class TilemapArtist : IDrawArt
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

		protected List<(OAMDrawInfo t, bool g)> SpriteDrawInstructions { get; } = new();

		public bool Valid { get; private set; }

		public abstract GraphicsSet LoadedGraphics { get; }

		public abstract NeedsNewArt Redrawing { get; }


		protected TilemapArtist() { }




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
			SpriteCanvas.Palette = palettes;
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
			if (Redrawing == NeedsNewArt.Nothing || Valid) return;

			if (Redrawing.HasFlag(NeedsNewArt.UpdatedAllPalettes))
			{
				ReloadPalettes();
			}
			
			if (Redrawing.HasFlag(NeedsNewArt.UpdatedLayer1Tilemap))
			{
				RebuildLayer1();
			}

			if (Redrawing.HasFlag(NeedsNewArt.UpdatedLayer2Tilemap))
			{
				RebuildLayer2();
			}

			if (Redrawing.HasFlag(NeedsNewArt.UpdatedSpritesLayer))
			{
				RedrawSpriteLayer();
			}

			RebuildBitMap();

			Valid = true;
			ClearNeedForRedraw();
		}

		protected abstract void ClearNeedForRedraw();

		protected void HardRevalidate()
		{
			ReloadPalettes();
			RebuildLayer1();
			RebuildLayer2();
			RebuildBitMap();

			Valid = true;
			ClearNeedForRedraw();
		}

		public abstract void RebuildBitMap();


		public void ResetSpritesList()
		{
			SpriteDrawInstructions.Clear();
		}

		protected virtual void RebuildLayer1()
		{
			for (var y = 0; y < 64; y++)
			{
				for (var x = 0; x < 64; x++)
				{
					var t = GetLayer1TileAt(x, y);
					DrawTileToBuffer(t, x * 8, y * 8, Layer1Canvas);
				}
			}
		}
		
		protected virtual void RebuildLayer2()
		{
			for (var y = 0; y < 64; y++)
			{
				for (var x = 0; x < 64; x++)
				{
					var t = GetLayer2TileAt(x, y);
					DrawTileToBuffer(t, x * 8, y * 8, Layer2Canvas);
				}
			}
		}

		public virtual void DrawSelfToImage(Graphics g)
		{
			Revalidate();

			g.DrawImage(FinalOutput, 0, 0);
		}

		public virtual void DrawSelfToImageSmall(Graphics g, int x, int y)
		{
			Revalidate();

			g.InterpolationMode = InterpolationMode.Bilinear;

			g.DrawImage(FinalOutput, x, y, 256, 256);
		}

		private void DrawTileToBuffer(in Tile tile, int x, int y, IGraphicsCanvas canvas)
		{
			var (til, pal) = LoadedGraphics.GetBackgroundTileWithPalette(tile);
			til.DrawToCanvas(canvas, x, y, (byte) pal, tile.HFlip, tile.VFlip);
		}

		public abstract void DrawTileForPreview(Tile t, int indexoff);

		protected virtual void RedrawSpriteLayer()
		{
			SpriteCanvas.ClearBitmap();

			foreach (var (tile, global) in SpriteDrawInstructions)
			{
				var graphics = global ? LoadedGraphics : LoadedGraphics;

				graphics.DrawSpriteTileToCanvas(SpriteCanvas, tile);
			}
		}

		protected void DrawEntireList(IEnumerable<IDelegatedDraw> list)
		{
			foreach (var o in list)
			{
				o.Draw(this);
			}
		}




		public virtual void DrawSprite(IDrawableSprite spr, OAMDrawInfo[] instructions,
			int xoff = 0, int yoff = 0, bool useGlobal = false)
		{
			foreach (var ti in instructions)
			{
				var x = spr.RealX + ti.X + xoff;
				var y = spr.RealY + ti.Y + yoff;

				if (ti.IsBig)
				{
					SpriteDrawInstructions.Add(
						(ti with
						{
							X = ti.HFlip ? x : x + 8,
							Y = ti.VFlip ? y : y + 8,
							HFlip = ti.HFlip,
							VFlip = ti.VFlip,
							IsBig = false,
						}, useGlobal));

					SpriteDrawInstructions.Add(
						(ti with
						{
							ID = (ushort) (ti.ID + 1),
							X = ti.HFlip ? x + 8 : x,
							Y = ti.VFlip ? y : y + 8,
							HFlip = ti.HFlip,
							VFlip = ti.VFlip,
							IsBig = false,
						}, useGlobal));

					SpriteDrawInstructions.Add(
						(ti with
						{
							ID = (ushort) (ti.ID + 16),
							X = ti.HFlip ? x + 8 : x,
							Y = ti.VFlip ? y + 8 : y,
							HFlip = ti.HFlip,
							VFlip = ti.VFlip,
							IsBig = false,
						}, useGlobal));

					SpriteDrawInstructions.Add(
						(ti with
						{
							ID = (ushort) (ti.ID + 17),
							X = ti.HFlip ? x + 8 : x,
							Y = ti.VFlip ? y + 8 : y,
							HFlip = ti.HFlip,
							VFlip = ti.VFlip,
							IsBig = false,
						}, useGlobal));
				}
				else
				{
					SpriteDrawInstructions.Add((ti, useGlobal));
				}
			}
		}
	}
}
