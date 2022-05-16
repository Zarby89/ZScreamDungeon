namespace ZeldaFullEditor.Gui
{
	public partial class Tile16Editor : Form
	{
		private ushort tile8selected = 0;
		private bool fromForm = false;
		private readonly byte[] tempTiletype = new byte[0x200];

		private readonly Tile16[] allTiles = new Tile16[Constants.NumberOfUniqueTile16Definitions];

		private ushort searchedTile = 0xFFFF;

		public Tile16Editor()
		{
			InitializeComponent();

			panel1.VerticalScroll.SmallChange = 32;
			panel1.VerticalScroll.LargeChange = 32;
		}

		/// <summary>
		/// Called every frame? updates the appearance of the tile 8 window
		/// </summary>
		public unsafe void updateTiles()
		{
			ushort.TryParse(tileUpDown.Text, NumberStyles.HexNumber, null, out ushort tempTile);

			tile8selected = tempTile;

			byte p = (byte) paletteUpDown.Value;
			byte* destPtr = (byte*) ZScreamer.ActiveGraphicsManager.editort16Ptr.ToPointer();
			byte* srcPtr = (byte*) ZScreamer.ActiveGraphicsManager.currentOWgfx16Ptr.ToPointer();
			int xx = 0;
			int yy = 0;

			for (int i = 0; i < 1024; i++)
			{
				for (var y = 0; y < 8; y++)
				{
					for (var x = 0; x < 4; x++)
					{
						CopyTile(x, y, xx, yy, i, p, destPtr, srcPtr);
					}
				}

				xx += 8;
				if (xx >= 128)
				{
					yy += 1024;
					xx = 0;
				}
			}

			ZScreamer.ActiveGraphicsManager.editort16Bitmap.Palette = ZScreamer.ActiveOWScene.CurrentMap.MyArtist.Layer1Canvas.Palette;
			pictureboxTile8.Refresh();
		}

		private unsafe void CopyTile(int x, int y, int xx, int yy, int id, byte p, byte* gfx16Pointer, byte* gfx8Pointer)
		{
			int mx;
			int my = mirrorYCheckbox.Checked ? 7 - y : y;
			byte r;

			if (mirrorXCheckbox.Checked)
			{
				mx = 3 - x;
				r = 1;
			}
			else
			{
				mx = x;
				r = 0;
			}

			int tx = ((id & ~0xF) << 5) | ((id & 0xF) << 2);
			int index = xx + yy + (x * 2) + (my * 128);
			int pixel = gfx8Pointer[tx + (y * 64) + x];

			gfx16Pointer[index + r ^ 1] = (byte) ((pixel & 0x0F) | (p << 4));
			gfx16Pointer[index + r] = (byte) ((pixel >> 4) | (p << 4));
		}

		private void pictureboxTile8_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
			e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.editort16Bitmap, Constants.Rect_0_0_256_1024);

			if (gridcheckBox.Checked)
			{
				for (int xs = 0; xs < 16 * 16; xs += 16)
				{
					e.Graphics.DrawLine(Constants.ThirdWhitePen1, xs, 0, xs, 1024);
				}

				for (int ys = 0; ys < 256 * 16; ys += 16)
				{
					e.Graphics.DrawLine(Constants.ThirdWhitePen1, 0, ys, 256, ys);
				}
			}

			int y = tile8selected & ~0xF;
			int x = (tile8selected & 0xF) * 16;

			e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(x, y, 16, 16));
		}

		private void mirrorXCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!fromForm)
			{
				updateTiles();
			}

			if (tile8selected >= 512)
			{
				tileTypeBox.Enabled = false;
			}
			else
			{
				tileTypeBox.Enabled = true;
				tileTypeBox.SelectedIndex = tempTiletype[tile8selected];
			}
		}

		private static readonly RectangleF RectF1 = new(0f, 0f, 256.5f, 16000f);
		private static readonly RectangleF RectF2 = new(0, 0, 128, 8000);
		private void pictureboxTile16_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.CompositingQuality = CompositingQuality.AssumeLinear;
			//e.Graphics.DrawImage(GFX.editortileBitmap, new Rectangle(0, 0, 64, 64));
			e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.mapblockset16Bitmap, RectF1, RectF2, GraphicsUnit.Pixel);
			//e.Graphics.DrawImage(GFX.mapblockset16Bitmap, new RectangleF(256f, 0f, 256.5f, 8000f), new RectangleF(0, 4000, 128, 4000-192), GraphicsUnit.Pixel);

			if (gridcheckBox.Checked)
			{
				for (int x = 0; x < 16 * 32; x += 32)
				{
					e.Graphics.DrawLine(Constants.White100Pen1, x, 0, x, 16000);

				}

				for (int y = 0; y < 512 * 32; y += 32)
				{
					e.Graphics.DrawLine(Constants.White100Pen1, 0, y, 256, y);
				}
			}

			int xP = (ZScreamer.ActiveOWScene.selectedTile[0] % 8) * 32;
			int yP = (ZScreamer.ActiveOWScene.selectedTile[0] / 8) * 32;

			if (searchedTile != 0xFFFF)
			{
				int xP2 = (searchedTile % 8) * 32;
				int yP2 = ((searchedTile / 8)) * 32;
				e.Graphics.DrawRectangle(Constants.Orange220Pen1, new Rectangle(xP2, yP2, 32, 32));
			}

			/*
            if (scene.selectedTile[0] >= 2000)
            {
                yP -= 8000;
                xP += 256;
            }
            */
			e.Graphics.DrawRectangle(Constants.Red220Pen1, new Rectangle(xP, yP, 32, 32));

			//e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), 32, 0, 32, 64);
			//e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), 0, 32, 64, 32);
		}

		/// <summary>
		/// Called when the tile 8 window is single left clicked
		/// </summary>
		private void pictureboxTile8_MouseDown(object sender, MouseEventArgs e)
		{
			int tid = (e.X / 16) + (e.Y & ~0xF);
			tileUpDown.Text = tid.ToString("X2");
			pictureboxTile8.Refresh();

			updateTiles();
		}

		/// <summary>
		/// Called when the tile 16 window is clicked
		/// </summary>
		private void pictureboxTile16_MouseDown(object sender, MouseEventArgs e)
		{
			int offset = (e.X < 256) ? 0 : 1992;

			int t16 = offset + (e.X / 32) + ((e.Y / 32) * 8);
			bool t8x = ((e.X / 16) & 0x01) == 0x01;
			bool t8y = ((e.Y / 16) & 0x01) == 0x01;

			// When left clicked, draw the tile 8 selected in the corrisponding quadrant of the tile 16
			if (e.Button == MouseButtons.Left)
			{
				Tile t = new Tile(
					tile8selected,
					(byte) paletteUpDown.Value,
					inFrontCheckbox.Checked,
					mirrorXCheckbox.Checked,
					mirrorYCheckbox.Checked);

				allTiles[t16] = (t8x, t8y) switch
				{
					(false, false) => allTiles[t16].ChangeTiles(tile0: t),
					(false, true) => allTiles[t16].ChangeTiles(tile2: t),
					(true, false) => allTiles[t16].ChangeTiles(tile1: t),
					(true, true) => allTiles[t16].ChangeTiles(tile3: t),
				};

				BuildTiles16Gfx();
				pictureboxTile16.Refresh();
			}
			// When right clicked, get the select the tile 8 from the corrisponding quadrant of the tile 16
			else
			{
				updateTileInfoFrom16((t8x, t8y) switch
				{
					(false, false) => allTiles[t16].Tile0,
					(false, true) => allTiles[t16].Tile2,
					(true, false) => allTiles[t16].Tile1,
					(true, true) => allTiles[t16].Tile3,
				});
			}
		}

		private void updateTileInfoFrom16(in Tile t)
		{
			fromForm = true;
			tileUpDown.Text = t.ID.ToString("X2");
			paletteUpDown.Value = t.Palette;
			mirrorXCheckbox.Checked = t.HFlip;
			mirrorYCheckbox.Checked = t.VFlip;
			inFrontCheckbox.Checked = t.Priority;
			tileTypeBox.SelectedIndex = tempTiletype[t.ID];
			fromForm = false;

			updateTiles();
		}

		private static readonly int[] m16offsets = { 0, 8, 1024, 1032 };

		private unsafe void BuildTiles16Gfx()
		{
			var gfx16Data = (byte*) ZScreamer.ActiveGraphicsManager.mapblockset16.ToPointer(); //(byte*)allgfx8Ptr.ToPointer();
			var gfx8Data = (byte*) ZScreamer.ActiveGraphicsManager.currentOWgfx16Ptr.ToPointer(); //(byte*)allgfx16Ptr.ToPointer();

			int yy = 0;
			int xx = 0;

			for (int i = 0; i < Constants.NumberOfUniqueTile16Definitions; i++) // Number of tiles16 3748? // its 3752
			{
				// 8x8 tile draw
				// gfx8 = 4bpp so everyting is /2
				var tiles = allTiles[i];

				for (int tile = 0; tile < 4; tile++)
				{
					Tile info = tiles[tile];
					int offset = m16offsets[tile];

					for (int y = 0; y < 8; y++)
					{
						for (int x = 0; x < 4; x++)
						{
							CopyTile16(x, y, xx, yy, offset, info, gfx16Data, gfx8Data);
						}
					}
				}

				xx += 16;
				if (xx >= 128)
				{
					yy += 2048;
					xx = 0;
				}
			}
		}

		private unsafe void CopyTile16(int x, int y, int xx, int yy, int offset, in Tile tile, byte* gfx16Pointer, byte* gfx8Pointer) // map,current
		{
			int mx = tile.HFlip ? 3 - x : x;
			int my = tile.VFlip ? 7 - y : y;

			int tx = (tile.ID / 16 * 512) + ((tile.ID & 0xF) * 4);
			var index = xx + yy + offset + (mx * 2) + (my * 128);
			var pixel = gfx8Pointer[tx + (y * 64) + x];

			//gfx16Pointer[index + tile.HFlipByte ^ 1] = (byte) ((pixel & 0x0F) | (tile.Palette << 4));
			//gfx16Pointer[index + tile.HFlipByte] = (byte) (((pixel >> 4)) | (tile.Palette << 4));
		}

		private void Tile16Editor_Load(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			tileTypeBox.DataSource = DefaultEntities.ListOfTileTypes;

			for (int i = 0; i < 0x200; i++)
			{
				tempTiletype[i] = ZScreamer.ActiveOW.allTilesTypes[i];
			}

			//ZScreamer.ActiveOW.Tile16List.ListOf.CopyTo(allTiles);

			unsafe
			{
				// Update gfx to be on selected map
				byte* currentmapgfx8Data = (byte*) ZScreamer.ActiveGraphicsManager.currentOWgfx16Ptr.ToPointer(); // Loaded gfx for the current map (empty at this point)
				byte* allgfxData = (byte*) ZScreamer.ActiveGraphicsManager.allgfx16Ptr.ToPointer(); // All gfx of the game pack of 2048 bytes (4bpp)
				for (int i = 0, i4 = 0; i < 16; i++, i4 += 2048)
				{
					int i2 = ZScreamer.ActiveOWScene.CurrentMap.staticgfx[i] * 2048;
					var i3 = i switch
					{
						0 or 3 or 4 or 5 => 0x88,
						_ => 0,
					};
					for (int j = 0; j < 2048; j++)
					{
						byte mapByte = (byte) (allgfxData[j + i2] + i3);
						currentmapgfx8Data[i4 + j] = mapByte;
					}
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//for (int i = 0; i < Constants.NumberOfMap16; i++)
			//{
			//	ZScreamer.ActiveOW.Tile16List.ListOf[i] = allTiles[i];
			//}
			//
			//for (int i = 0; i < 0x200; i++)
			//{
			//	ZScreamer.ActiveOW.allTilesTypes[i] = tempTiletype[i];
			//}
			//
			//for (int i = 0; i < 159; i++)
			//{
			//	ZScreamer.ActiveOW.allmaps[i].NeedsRefresh = true;
			//}

			ZScreamer.ActiveOWScene.CurrentMap.HardRefresh();

			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tileTypeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!fromForm)
			{
				tempTiletype[tile8selected] = (byte) tileTypeBox.SelectedIndex;
			}
		}

		private void gridcheckBox_CheckedChanged(object sender, EventArgs e)
		{
			pictureboxTile16.Refresh();
			pictureboxTile8.Refresh();
		}

		private void pictureboxTile8_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ZGUI.editorsTabControl.SelectedIndex = 2;
			ZGUI.gfxEditor.selectedSheet = ZScreamer.ActiveOWScene.CurrentMap.staticgfx[(e.Y / 64)];
			ZGUI.gfxEditor.allgfxPicturebox.Refresh();
			Close();
		}

		private void Tile16Editor_Shown(object sender, EventArgs e)
		{
			panel1.VerticalScroll.Value = ZScreamer.ActiveOWScene.selectedTile[0] / 8 * 32;
			panel1.PerformLayout();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ushort.TryParse(tile16searchTextbox.Text, NumberStyles.HexNumber, null, out searchedTile);
			panel1.VerticalScroll.Value = searchedTile / 8 * 32;
			panel1.PerformLayout();
		}
	}
}
