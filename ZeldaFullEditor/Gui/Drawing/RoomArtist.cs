namespace ZeldaFullEditor
{
	public class RoomArtist : Artist
	{
		public DungeonRoom CurrentRoom { get; set; }

		public override ushort[] Layer1TileMap { get; } = new ushort[Constants.TilesPerUnderworldRoom];
		public override PointeredImage Layer1Canvas { get; } = new PointeredImage(512, 512);

		public override ushort[] Layer2TileMap { get; } = new ushort[Constants.TilesPerUnderworldRoom];
		public override PointeredImage Layer2Canvas { get; } = new PointeredImage(512, 512);

		public override PointeredImage SpriteCanvas { get; } = new PointeredImage(512, 512);

		public override Bitmap FinalOutput { get; } = new Bitmap(512, 512);

		private readonly bool drawid;

		public RoomArtist(bool includeRoomID) : base()
		{
			drawid = includeRoomID;
		}

		public void RebuildTileMap()
		{
			ZScreamer.ActiveScreamer.TileLister.CurrentFloor1 = CurrentRoom.Floor1Graphics;
			ZScreamer.ActiveScreamer.TileLister.CurrentFloor2 = CurrentRoom.Floor2Graphics;

			var Floor2Shorts = ZScreamer.ActiveScreamer.TileLister[Constants.Floor2ObjectID].ToUnsignedShorts();
			FillTilemapWithFloorShort(Layer2TileMap, Floor2Shorts);

			var Floor1Shorts = ZScreamer.ActiveScreamer.TileLister[Constants.Floor1ObjectID].ToUnsignedShorts();
			FillTilemapWithFloorShort(Layer1TileMap, Floor1Shorts);

			DrawEntireList(ZScreamer.ActiveScreamer.LayoutLister[CurrentRoom.Layout]);
			DrawEntireList(CurrentRoom.Layer1Objects);
			DrawEntireList(CurrentRoom.Layer2Objects);
			DrawEntireList(CurrentRoom.Layer3Objects);
			DrawEntireList(CurrentRoom.DoorsList);

			//if (Layer2Mode != Constants.LayerMergeOff)
			//{
			//	ZGUI.DungeonEditor.SetPalettesTransparent();
			//}
			//else
			//{
			//	ZGUI.DungeonEditor.SetPalettesBlack();
			//}

			void DrawEntireList(IEnumerable<IDelegatedDraw> list)
			{
				foreach (var o in list)
				{
					o.Draw(this);
				}
			}
		}

		public override void RebuildBitMap()
		{
			if (CurrentRoom == null) return;

			Graphics g = Graphics.FromImage(FinalOutput);

			g.SetClip(Constants.Rect_0_0_512_512);
			g.Clear(Color.Black);

			ImageAttributes draw = null;

			if (CurrentRoom.LayerMerging.Layer2Translucent)
			{
				draw = new ImageAttributes();
				draw.SetColorMatrix(
					new ColorMatrix(TranslucencyMatrix),
					ColorMatrixFlag.Default,
					ColorAdjustType.Bitmap
				);
			}

			PointeredImage top;
			PointeredImage bottom;

			if (CurrentRoom.LayerMerging.Layer2Visible)
			{
				top = Layer1Canvas;
				bottom = null;
			}
			else if (CurrentRoom.LayerMerging.Layer2OnTop)
			{
				top = Layer2Canvas;
				bottom = Layer1Canvas;
			}
			else
			{
				top = Layer1Canvas;
				bottom = Layer2Canvas;
			}

			if (bottom != null)
			{
				g.DrawImage(bottom.Bitmap, Constants.Rect_0_0_512_512, 0, 0, 512, 512, GraphicsUnit.Pixel, draw);
			}

			g.DrawImage(top.Bitmap, Constants.Rect_0_0_512_512, 0, 0, 512, 512, GraphicsUnit.Pixel, draw);

			g.DrawImage(SpriteCanvas.Bitmap, Constants.Rect_0_0_512_512, 0, 0, 512, 512, GraphicsUnit.Pixel, null);

		}

		public override void DrawSelfToImage(Graphics g)
		{
			if (CurrentRoom == null) return;

			g.DrawImage(FinalOutput, 0, 0);

			if (drawid)
			{
				g.DrawText(0, 0, $"ROOM: {CurrentRoom.RoomID:X3}");
			}
		}

		public void SetRoomAndDrawImmediately(DungeonRoom room)
		{
			if (CurrentRoom == room) return;

			CurrentRoom = room;
			HardRefresh();
		}

		public override void HardRefresh()
		{
			BackgroundPalette = CurrentRoom?.Palette ?? 0;
			SpritePalette = CurrentRoom?.Palette ?? 0;

			BackgroundTileset = CurrentRoom?.BackgroundTileset ?? 0;
			SpriteTileset = CurrentRoom?.SpriteTileset ?? 0;

			if (HasUnsavedChanges)
			{
				ReloadPalettes();
				RebuildTileMap();
				RebuildBitMap();
			}

			base.HardRefresh();
		}

		public override void ReloadPalettes()
		{
			var copy = ZScreamer.ActivePaletteManager.LoadDungeonPalette(BackgroundPalette);

			int pindex = 0;
			ColorPalette palettes = Layer1Canvas.Palette;

			for (int y = 0; y < copy.GetLength(1); y++)
			{
				for (int x = 0; x < copy.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = copy[x, y];
				}
			}

			Palettes.FillInHalfPaletteZeros(palettes.Entries, Color.Black);

			Layer1Canvas.Palette = palettes;
			Layer2Canvas.Palette = palettes;
		}

		private void FillTilemapWithFloorShort(ushort[] tilemap, ushort[] floor)
		{
			for (int x = 0; x < 16 * 4; x += 4)
			{
				for (int y = 0; y < (64 * 32 * 2); y += 2 * 64)
				{
					tilemap[x + y] = floor[0];
					tilemap[x + y + 1] = floor[1];
					tilemap[x + y + 2] = floor[2];
					tilemap[x + y + 3] = floor[3];
					tilemap[x + y + 64] = floor[4];
					tilemap[x + y + 65] = floor[5];
					tilemap[x + y + 66] = floor[6];
					tilemap[x + y + 67] = floor[7];
				}
			}
		}



		public override void DrawTileForPreview(Tile t, int indexoff) { }
	}
}
