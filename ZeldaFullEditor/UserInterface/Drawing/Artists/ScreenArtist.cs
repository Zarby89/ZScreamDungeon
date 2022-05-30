namespace ZeldaFullEditor.UserInterface.Drawing.Artists
{
	public class ScreenArtist : Artist
	{
		public OverworldScreen MyScreen { get; }

		public override ushort[] Layer1TileMap => MyScreen.Tile16Map;

		public override PointeredImage Layer1Canvas { get; } = new(512, 512);

		public override ushort[] Layer2TileMap { get; } = new ushort[Constants.NumberOfTile16PerScreen];
		public override PointeredImage Layer2Canvas { get; } = new(512, 512);

		public override PointeredImage SpriteCanvas { get; } = new(512, 512);

		protected override GraphicsSet LoadedGraphics => MyScreen.LoadedGraphics;

		protected override NeedsNewArt Redrawing => MyScreen.Redrawing;

		public override Bitmap FinalOutput { get; } = new(512, 512);

		public ScreenArtist(OverworldScreen screen) : base()
		{
			MyScreen = screen;
		}

		protected override void ClearNeedForRedraw()
		{
			MyScreen.Redrawing = NeedsNewArt.Nothing;
		}

		public override Tile GetLayer1TileAt(int x, int y) => GetDrawnTileAt(x, y, Layer1TileMap);
		public override Tile GetLayer2TileAt(int x, int y) => GetDrawnTileAt(x, y, Layer2TileMap);

		private static Tile GetDrawnTileAt(int x, int y, ushort[] list)
		{
			var t16index = list[x / 2 + y / 2 * 32];

			var t16 = ZScreamer.ActiveOW.Tile16Sheet.GetTile16At(t16index);

			return (x % 2, y % 2) switch
			{
				(0, 0) => t16.Tile0,
				(1, 0) => t16.Tile1,
				(0, 1) => t16.Tile2,
				(1, 1) => t16.Tile0,
				_ => Tile.Empty // No, actually it does handle every case
			};
		}

		protected override void RedrawSpriteLayer()
		{
			// TODO how to do this?
			//DrawEntireList(CurrentRoom.SpritesList);
			//DrawEntireList(CurrentRoom.SecretsList);
		}

		public override void RebuildBitMap()
		{
			var g = Graphics.FromImage(FinalOutput);

			g.SetClip(Constants.ScreenSizedRectangle);

			g.Clear(Color.FromArgb(255, Layer1Canvas.Palette.Entries[0]));

			g.DrawScreen(Layer1Canvas.Bitmap, null);
			g.DrawScreen(SpriteCanvas.Bitmap, null);
		}

		public override void ReloadPalettes()
		{
			var copy = MyScreen?.GetPaletteForGameState(ZScreamer.ActiveOW.ActiveGameState);

			RefreshPalettesFrom(copy);
		}

		public override void DrawTileForPreview(Tile t, int indexoff) { }

		public void RebuidMap()
		{
			int x = 0, y = 0;
			foreach (var i in MyScreen.Tile16Map)
			{
				var t = ZScreamer.ActiveOW.Tile16Sheet.GetTile16At(i);

				ZScreamer.ActiveOW.Tile16Sheet.DrawTile16ToCanvas(Layer1Canvas, x, y, i);

				x += 16;
				if (x == 16 * Constants.NumberOfTile16PerStrip)
				{
					y += 16;
					x = 0;
				}

			}
		}
	}
}
