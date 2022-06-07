namespace ZeldaFullEditor.UserInterface.Drawing.Artists
{
	public class RoomArtist : TilemapArtist
	{
		private Room curroom;
		public Room CurrentRoom
		{
			get => curroom;
			set
			{
				if (curroom == value) return;
				curroom = value;
				HardRevalidate();
			}
		}

		public override GraphicsSet LoadedGraphics => CurrentRoom.LoadedGraphics;
		public override NeedsNewArt Redrawing => CurrentRoom.Redrawing;

		public override ushort[] Layer1TileMap { get; } = new ushort[Constants.TilesPerUnderworldRoom];
		public override PointeredImage Layer1Canvas { get; } = new(512, 512);

		public override ushort[] Layer2TileMap { get; } = new ushort[Constants.TilesPerUnderworldRoom];
		public override PointeredImage Layer2Canvas { get; } = new(512, 512);

		public override PointeredImage SpriteCanvas { get; } = new(512, 512);

		public override Bitmap FinalOutput { get; } = new(512, 512);

		public RoomArtist() : base() { }

		private void RebuildTileMap()
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
		}


		protected override void RedrawSpriteLayer()
		{
			if (CurrentRoom == null) return;

			ResetSpritesList();

			DrawEntireList(CurrentRoom.SpritesList);
			DrawEntireList(CurrentRoom.SecretsList);
			DrawEntireList(CurrentRoom.ChestList);

			base.RedrawSpriteLayer();
		}

		public override Tile GetLayer1TileAt(int x, int y) => new(Layer1TileMap[x + 64 * y]);
		public override Tile GetLayer2TileAt(int x, int y) => new(Layer2TileMap[x + 64 * y]);

		protected override void RebuildLayer1()
		{
			if (CurrentRoom == null) return;

			RebuildTileMap();

			base.RebuildLayer1();
			base.RebuildLayer2();
		}

		// because of how things work with the room artist
		protected override void RebuildLayer2()
		{
			if (CurrentRoom == null) return;

			//RebuildTileMap();
			//base.RebuildLayer2();
		}

		protected override void ClearNeedForRedraw()
		{
			if (CurrentRoom == null) return;

			CurrentRoom.Redrawing = NeedsNewArt.Nothing;
		}

		public override void RebuildBitMap()
		{
			if (CurrentRoom == null) return;

			var g = Graphics.FromImage(FinalOutput);

			g.SetClip(Constants.ScreenSizedRectangle);
			g.Clear(Color.FromArgb(255, Layer1Canvas.Palette.Entries[0]));

			ImageAttributes draw = null;

			if (CurrentRoom.LayerCoupling.Layer2Translucent)
			{
				draw = new ImageAttributes();
				draw.SetColorMatrix(
					new ColorMatrix(TranslucencyMatrix),
					ColorMatrixFlag.Default,
					ColorAdjustType.Bitmap
				);
			}

			PointeredImage top, bottom;

			if (!CurrentRoom.LayerCoupling.Layer2Visible)
			{
				top = Layer1Canvas;
				bottom = null;
			}
			else if (CurrentRoom.LayerCoupling.Layer2OnTop)
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
				g.DrawScreen(bottom.Bitmap);
			}

			g.DrawScreen(top.Bitmap, draw);

			g.DrawScreen(SpriteCanvas.Bitmap, null);
		}

		public override void DrawSelfToImage(Graphics g)
		{
			if (CurrentRoom == null) return;

			base.DrawSelfToImage(g);
		}

		public override void DrawSelfToImageSmall(Graphics g, int x, int y)
		{
			if (CurrentRoom == null) return;

			base.DrawSelfToImageSmall(g, x, y);
		}

		public void DrawIDToImage(Graphics g)
		{
			if (CurrentRoom == null) return;

			g.DrawText(0, 0, $"ROOM: {CurrentRoom.RoomID:X3}");
		}

		public override void ReloadPalettes()
		{
			RefreshPalettesFrom(CurrentRoom.CGPalette);
		}

		private static void FillTilemapWithFloorShort(ushort[] tilemap, ushort[] floor)
		{
			for (var x = 0; x < 16 * 4; x += 4)
			{
				for (var y = 0; y < 64 * 32 * 2; y += 2 * 64)
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

		public void AddTilesToTilemap(RoomObject obj)
		{
			var t = obj.ObjectType;
			var instructions = t.GetDrawingForSize(obj.Size);

			// declare these now so they can be captured by our dumb delegate idea
			int tm = 0;
			ushort td = 0;
			ushort? tileUnder = null;

			Action draw = null;
			
			if (t.BothBG || obj.Layer is RoomLayer.Layer1 or RoomLayer.Layer3)
			{
				draw += DrawToLayer1;
			}
			
			if (t.BothBG || obj.Layer is RoomLayer.Layer2)
			{
				draw += DrawToLayer2;
			}

			foreach (DrawInfo d in instructions)
			{
				// TODO move this to the RoomObjectType class and calc them all from the start
				if (obj.Width < d.XOff + 8)
				{
					obj.Width = d.XOff + 8;
				}
				if (obj.Height < d.YOff + 8)
				{
					obj.Height = d.YOff + 8;
				}

				tm = (d.XOff / 8) + obj.GridX + ((obj.GridY + (d.YOff / 8)) * 64);

				if (tm is <Constants.TilesPerUnderworldRoom and >= 0)
				{
					td = obj.Tiles[d.TileIndex].GetModifiedUnsignedShort(hflip: d.HFlip, vflip: d.VFlip);

					obj.CollisionRectangles.Add(new(d.XOff + obj.RealX, d.YOff + obj.RealY, 8, 8));

					tileUnder = d.TileUnder switch
					{
						not null => obj.Tiles[(int) d.TileUnder].ToUnsignedShort(),
						null => null,
					};

					draw();
				}
			}

			// Local functions so we can use fewer ifs
			void DrawToLayer1()
			{
				if (tileUnder == Layer1TileMap[tm])
				{
					return;
				}

				Layer1TileMap[tm] = td;
			}

			void DrawToLayer2()
			{
				if (tileUnder == Layer2TileMap[tm])
				{
					return;
				}

				Layer2TileMap[tm] = td;
			}

		}


	}
}
