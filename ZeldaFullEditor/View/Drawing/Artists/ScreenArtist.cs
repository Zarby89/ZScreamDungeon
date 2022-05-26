namespace ZeldaFullEditor.View.Drawing.Artists
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

		public override Bitmap FinalOutput { get; } = new(512, 512);

		public ScreenArtist(OverworldScreen screen) : base()
		{
			MyScreen = screen;
		}

		public void RebuildTileMap()
		{

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

		public override void RebuildBitMap()
		{
			var g = Graphics.FromImage(FinalOutput);

			g.SetClip(Constants.ScreenSizedRectangle);
			g.Clear(Color.Black);

			g.DrawScreen(Layer1Canvas.Bitmap, null);
			g.DrawScreen(SpriteCanvas.Bitmap, null);
		}

		public override void DrawSelfToImage(Graphics g)
		{
			g.DrawImage(FinalOutput, 0, 0);
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

				CopyTile16ToCanvas(t, x, y);

				x++;
				if (x == 16)
				{
					y++;
					x = 0;
				}

			}
		}

		private void CopyTile16ToCanvas(Tile16 t, int x, int y)
		{
			x *= 2;
			y *= 2;
			CopyTile8ToCanvas(t.Tile0, x, y);
			CopyTile8ToCanvas(t.Tile1, x + 1, y);
			CopyTile8ToCanvas(t.Tile2, x, y + 1);
			CopyTile8ToCanvas(t.Tile3, x + 1, y + 1);

		}

		private void CopyTile8ToCanvas(Tile t, int x, int y)
		{

			//		int sourcePtrPos = ((tile & 0x7) << 4) + ((tile / 8) * 2048); //(sourceX * 16) + (sourceY * 128);
			//		byte* sourcePtr = (byte*) sourcebmpPtr.ToPointer();
			//
			//		int destPtrPos = (x + (y * 512));
			//		byte* destPtr = (byte*) destbmpPtr.ToPointer();
			//
			//		for (int ystrip = 0; ystrip < 16; ystrip++)
			//		{
			//			for (int xstrip = 0; xstrip < 16; xstrip++)
			//			{
			//				destPtr[destPtrPos + xstrip + (ystrip * 512)] = sourcePtr[sourcePtrPos + xstrip + (ystrip * 128)];
			//			}
			//		}



			throw new NotImplementedException();
		}
	}
}
