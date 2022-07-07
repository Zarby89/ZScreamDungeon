namespace ZeldaFullEditor.Gui
{
	public partial class OverworldEditor : UserControl
	{
		// TODO move to Constants
		private const int ScratchPadSize = 225 * 16 * 2;
		private const int Tile16RowWidth = 8 * Tile16MasterSheet.TileSpan;

		public bool propertiesChangedFromForm = false;
		public Bitmap scratchPadBitmap = new(256, 3600);
		public ushort[,] scratchPadTiles = new ushort[16, 225];
		public byte gridDisplay = 0;

		private bool MouseIsDown = false;

		bool selecting = false;
		int globalmouseTileDownX = 0;
		int globalmouseTileDownY = 0;
		int mouseX_Real = 0;
		int mouseY_Real = 0;
		int lastTileHoverX = 0;
		int lastTileHoverY = 0;

		byte palSelected = 0;
		int tile8selected = 0;

		public int BGColorToUpdate = 0;

		readonly ColorDialog cd = new();

		public OverworldEditor()
		{
			InitializeComponent();

			stateCombobox.DataSource = GameStateInfo.ListOf;
		}

		public void OnProjectLoad()
		{
			//scene = new SceneOW(this, mainForm);
			splitContainer1.Panel2.Controls.Clear();
			splitContainer1.Panel2.Controls.Add(ZScreamer.ActiveOWScene);
			ZScreamer.ActiveOWScene.CreateScene();
			ZScreamer.ActiveOWScene.Refresh();
			stateCombobox.SelectedIndex = 1;
			scratchPicturebox.Image = scratchPadBitmap;
			SwapInAuxTab(null);
			OverworldAuxSideTabs.TabPages.Remove(Tiles8);
			//setTilesGfx();
			bool fromFile = false;
			byte[] file = new byte[ScratchPadSize];

			if (File.Exists("ScratchPad.dat"))
			{
				using FileStream fs = new("ScratchPad.dat", FileMode.Open, FileAccess.Read);
				fs.Read(file, 0, (int) fs.Length);
				fs.Close();
				fromFile = true;
			}

			int t = 0;
			for (ushort x = 0; x < 225; x++)
			{
				for (ushort y = 0; y < 16; y++, t += 2)
				{
					scratchPadTiles[y, x] = (ushort) (fromFile ? (file[t] << 8) | file[t + 1] : 0);
				}
			}

			ZScreamer.ActiveGraphicsManager.editort16Bitmap.Palette = ZScreamer.ActiveOWScene.CurrentMap.MyArtist.Layer1Canvas.Palette;
			updateTiles();
			pictureBox1.Refresh();
		}

		public void saveScratchPad()
		{
			byte[] file = new byte[ScratchPadSize];

			int t = 0;
			for (int x = 0; x < 225; x++)
			{
				for (int y = 0; y < 16; y++)
				{
					file[t++] = (byte) (scratchPadTiles[y, x] >> 8);
					file[t++] = (byte) scratchPadTiles[y, x];
				}
			}

			using FileStream fs = new FileStream("ScratchPad.dat", FileMode.OpenOrCreate, FileAccess.Write);
			fs.Write(file, 0, (int) fs.Length);
			fs.Close();
		}

		public void UpdateGUIProperties(OverworldScreen m, GameState gamestate = GameState.RainState)
		{
			OWProperty_BGGFX.HexValue = m.Tileset;
			OWProperty_BGPalette.HexValue = m.ScreenPalette;
			OWProperty_SPRGFX.HexValue = m.GetSpriteGraphicsForGameState(gamestate);
			OWProperty_SPRPalette.HexValue = m.GetSpritePaletteForGameState(gamestate);

			largemapCheckbox.Checked = m.IsPartOfLargeMap;
			BGColorToUpdate = m.ParentMapID;

		}

		public void UpdateForMode(OverworldEditMode m)
		{
			var s = m switch
			{
				OverworldEditMode.Entrances => OWTabEntranceProps,
				OverworldEditMode.Exits => OWTabExitProps,
				OverworldEditMode.Transports => OWTabTransportProps,
				_ => null
			};

			SwapInAuxTab(s);
		}

		private void SwapInAuxTab(TabPage t)
		{
			if (t != OWTabEntranceProps)
			{
				OverworldAuxSideTabs.TabPages.Remove(OWTabEntranceProps);
			}
			else
			{
				ZScreamer.ActiveOWScene.LastSelectedEntrance = null;
			}

			if (t != OWTabExitProps)
			{
				OverworldAuxSideTabs.TabPages.Remove(OWTabExitProps);
			}
			else
			{
				ZScreamer.ActiveOWScene.LastSelectedExit = null;
			}

			if (t != OWTabTransportProps)
			{
				OverworldAuxSideTabs.TabPages.Remove(OWTabTransportProps);
			}
			else
			{
				ZScreamer.ActiveOWScene.LastSelectedTransport = null;
			}

			if (t == null)
			{
				return;
			}

			OverworldAuxSideTabs.TabPages.Add(t);
			OverworldAuxSideTabs.SelectedTab = t;
		}

		public void SetSelectedExit(OverworldExit e)
		{
			UpdateSelectedExitProps(e);

			OWExitPanel.Enabled = e != null;
			OWExitDisabled.Visible = e == null;
		}

		public void UpdateSelectedExitProps(OverworldExit e)
		{
			OWExitPropID.HexValue = e?.MapID ?? 0;
			OWExitPropX.HexValue = e?.GlobalX ?? 0;
			OWExitPropY.HexValue = e?.GlobalY ?? 0;
		}

		public void SetSelectedEntrance(OverworldEntrance e)
		{
			UpdateSelectedEntranceProps(e);

			OWEntrancePanel.Enabled = e != null;
			OWEntranceDisabled.Visible = e == null;
		}

		public void UpdateSelectedEntranceProps(OverworldEntrance e)
		{
			OWEntrancePropID.HexValue = e?.MapID ?? 0;
			OWEntrancePropX.HexValue = e?.GlobalX ?? 0;
			OWEntrancePropY.HexValue = e?.GlobalY ?? 0;
		}

		public void SetSelectedTransport(OverworldTransport e)
		{
			UpdateSelectedTransportProps(e);

			OWTransportPanel.Enabled = e != null;
			OWTransportDisabled.Visible = e == null;
		}

		public void UpdateSelectedTransportProps(OverworldTransport e)
		{
			OWTransportPropID.HexValue = e?.MapID ?? 0;
			OWTransportPropX.HexValue = e?.GlobalX ?? 0;
			OWTransportPropY.HexValue = e?.GlobalY ?? 0;
		}

		private void stateCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ZScreamer.ActiveOW.ActiveGameState = ((GameStateInfo) stateCombobox.SelectedItem).State;
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			ZGUI.saveToolStripMenuItem_Click(sender, e);
		}

		private void gfxTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!propertiesChangedFromForm)
			{
				OverworldScreen screen = ZScreamer.ActiveOWScene.CurrentMap.ParentMap;

				screen.ScreenPalette = (byte) OWProperty_BGPalette.HexValue;
				screen.Tileset = (byte) OWProperty_BGGFX.HexValue;

				switch (ZScreamer.ActiveOW.ActiveGameStateIndex)
				{
					case 0:
						screen.State0SpriteGraphics = (byte) OWProperty_SPRGFX.HexValue;
						screen.State0SpritePalette = (byte) OWProperty_SPRPalette.HexValue;
						break;

					case 1:
						screen.State2SpriteGraphics = (byte) OWProperty_SPRGFX.HexValue;
						screen.State2SpritePalette = (byte) OWProperty_SPRPalette.HexValue;
						break;

					case 2:
						screen.State3SpriteGraphics = (byte) OWProperty_SPRGFX.HexValue;
						screen.State3SpritePalette = (byte) OWProperty_SPRPalette.HexValue;
						break;
				}

				//scene.updateMapGfx();
				ZScreamer.ActiveOWScene.Invalidate();
				//scene.Refresh();
			}
		}

		private static readonly RectangleF TileRect =
			new(8 * Tile16MasterSheet.TileSpan, 213 * Tile16MasterSheet.TileSpan, 8 * Tile16MasterSheet.TileSpan, 43 * Tile16MasterSheet.TileSpan);

		private void tilePictureBox_Paint(object sender, PaintEventArgs e)
		{
			if (ZScreamer.ActiveOW?.Tile16Sheet != null)
			{
				e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
				e.Graphics.CompositingMode = CompositingMode.SourceOver;
				e.Graphics.DrawImage(ZScreamer.ActiveOW.Tile16Sheet.PreviewCanvas.Bitmap,
					new Rectangle(0, 0, Tile16MasterSheet.ImageWidth, Tile16MasterSheet.ImageHeight),
					new Rectangle(0, 0, Tile16MasterSheet.ImageWidth, Tile16MasterSheet.ImageHeight),
					GraphicsUnit.Pixel);
				e.Graphics.DrawImage(ZScreamer.ActiveOW.Tile16Sheet.PreviewCanvas.Bitmap,
					new Rectangle(Tile16MasterSheet.ImageWidth, 0, Tile16MasterSheet.ImageWidth, Tile16MasterSheet.ImageHeight),
					new Rectangle(0, Tile16MasterSheet.ImageHeight, Tile16MasterSheet.ImageWidth, Tile16MasterSheet.ImageHeight),
					GraphicsUnit.Pixel);

				if (ZScreamer.ActiveOWScene.selectedTile.Length > 0)
				{
					int x = ZScreamer.ActiveOWScene.selectedTile[0] % 8 * Tile16MasterSheet.TileSpan;
					int y = ZScreamer.ActiveOWScene.selectedTile[0] / 8 * Tile16MasterSheet.TileSpan;

					if (ZScreamer.ActiveOWScene.selectedTile[0] >= Tile16MasterSheet.TilesPerBlock)
					{
						y -= Tile16MasterSheet.ImageHeight;
						x += Tile16MasterSheet.ImageWidth;
					}

					// TODO copy
					e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(x-1, y-1, Tile16MasterSheet.TileSpan, Tile16MasterSheet.TileSpan));
					selectedTileLabel.Text = "Selected tile: " + ZScreamer.ActiveOWScene.selectedTile[0].ToString("X4");
				}

				e.Graphics.FillRectangle(Brushes.Black, TileRect);
			}
		}

		private void tilePictureBox_MouseClick(object sender, MouseEventArgs e)
		{
			if (!ZScreamer.Active) return;

			ZScreamer.ActiveOWScene.selectedTileSizeX = 1;
			int x = (e.X % Tile16MasterSheet.ImageWidth) / Tile16MasterSheet.TileSpan;
			int y = e.Y / Tile16MasterSheet.TileSpan;

			ushort tile = (ushort) (x + y * Tile16MasterSheet.TilesPerRow);

			if (e.X >= Tile16MasterSheet.ImageWidth)
			{
				tile += Tile16MasterSheet.TilesPerBlock;
			}

			if (tile > 3751)
			{
				tile = 3751;
			}

			ZScreamer.ActiveOWScene.selectedTile = new ushort[1] { tile };

			tilePictureBox.Refresh();
		}

		/// <summary>
		/// Called when the LW button on the overworld editor form is clicked.
		/// </summary>
		private void lwButton_Click(object sender, EventArgs e)
		{
			SelectMapOffset(Worldiness.LightWorld);
		}

		/// <summary>
		/// Called when the DW button on the overworld editor form is clicked.
		/// </summary>
		private void dwButton_Click(object sender, EventArgs e)
		{
			SelectMapOffset(Worldiness.DarkWorld);
		}

		/// <summary>
		/// Called when the SP button on the overworld editor form is clicked.
		/// </summary>
		private void spButton_Click(object sender, EventArgs e)
		{
			SelectMapOffset(Worldiness.SpecialWorld);
		}

		private void SelectMapOffset(Worldiness o)
		{
			ZScreamer.ActiveOW.World = o;
			ZScreamer.ActiveOWScene.CurrentMapID = (int) o;
			ZScreamer.ActiveOWScene.Refresh();
		}

		private void runtestButton_Click(object sender, EventArgs e)
		{
			ZGUI.runtestButton_Click(sender, e);
		}

		private void RefreshAllMaps()
		{
			Thread.CurrentThread.IsBackground = true;
			ZScreamer.ActiveOW.ForAllScreens(map => map.InvalidateArt());
		}


		private void tilePictureBox_DoubleClick(object sender, EventArgs e)
		{
			Tile16Editor ted = new Tile16Editor();
			if (ted.ShowDialog() == DialogResult.OK)
			{
				new Thread(RefreshAllMaps).Start();
			}
		}

		private void undoButton_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveScreamer.OverworldScene.Undo();
		}

		private void redoButton_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveScreamer.OverworldScene.Redo();
		}

		private void refreshToolStrip_Click(object sender, EventArgs e)
		{
			new Thread(RefreshAllMaps).Start();
		}

		private void musicButton_Click(object sender, EventArgs e)
		{
			OWMusicForm owmf = new OWMusicForm
			{
				mapIndex = (byte) ZScreamer.ActiveOWScene.CurrentMapID
			};
			owmf.musics[0] = ZScreamer.ActiveOWScene.CurrentMap.musics[0];
			owmf.musics[1] = ZScreamer.ActiveOWScene.CurrentMap.musics[1];
			owmf.musics[2] = ZScreamer.ActiveOWScene.CurrentMap.musics[2];
			owmf.musics[3] = ZScreamer.ActiveOWScene.CurrentMap.musics[3];

			if (owmf.ShowDialog() == DialogResult.OK)
			{
				ZScreamer.ActiveOWScene.CurrentMap.musics[0] = owmf.musics[0];
				ZScreamer.ActiveOWScene.CurrentMap.musics[1] = owmf.musics[1];
				ZScreamer.ActiveOWScene.CurrentMap.musics[2] = owmf.musics[2];
				ZScreamer.ActiveOWScene.CurrentMap.musics[3] = owmf.musics[3];
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveScreamer.SetSelectedMessageID(OWProperty_MessageID.HexValue);
			ZGUI.editorsTabControl.SelectedIndex = (int) TabSelection.TextEditor;
		}

		private void previewTextPicturebox_Paint(object sender, PaintEventArgs e)
		{
			if (!ZScreamer.Active) return;

			e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			ColorPalette cp = ZScreamer.ActiveGraphicsManager.currentfontgfx16Bitmap.Palette;
			int defaultColor = 6;

			for (int i = 0; i < 4; i++)
			{
				if (i == 0)
				{
					cp.Entries[i] = Color.Transparent;
				}
				else
				{
					cp.Entries[i] = RoomEditingArtist.Layer1Canvas.Palette.Entries[(defaultColor * 4) + i];
				}
			}

			ZScreamer.ActiveGraphicsManager.currentfontgfx16Bitmap.Palette = cp;

			// TODO make new brushes
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.currentfontgfx16Bitmap, Constants.Rect_0_0_340_102, Constants.Rect_0_0_170_51, GraphicsUnit.Pixel);
			e.Graphics.FillRectangle(Constants.HalfRedBrush, Constants.Rect_336_0_4_102);
		}

		private void textidTextbox_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveScreamer.SetSelectedMessageID(OWProperty_MessageID.HexValue);
			previewTextPicturebox.Size = Constants.Size340x102;
			previewTextPicturebox.Visible = true;
			previewTextPicturebox.Refresh();
		}

		private void textidTextbox_Leave(object sender, EventArgs e)
		{
			previewTextPicturebox.Visible = false;
		}

		private void scratchPicturebox_MouseDown(object sender, MouseEventArgs e)
		{
			globalmouseTileDownX = e.X / Tile16MasterSheet.TileSpan;
			globalmouseTileDownY = e.Y / Tile16MasterSheet.TileSpan;

			if (ZScreamer.ActiveOWScene.TriggerRefresh)
			{
				ZScreamer.ActiveOWScene.TriggerRefresh = false;
				return;
			}

			MouseIsDown = true;

			if (e.Button == MouseButtons.Left)
			{
				if (ZScreamer.ActiveOWScene.selectedTile.Length >= 1)
				{
					int y = 0;
					int x = 0;
					//ushort[] undotiles = new ushort[scene.selectedTile.Length];

					for (int i = 0; i < ZScreamer.ActiveOWScene.selectedTile.Length; i++)
					{
						if (globalmouseTileDownX + x <= 15)
						{
							scratchPadTiles[globalmouseTileDownX + x, globalmouseTileDownY + y] = ZScreamer.ActiveOWScene.selectedTile[i];
						}

						x++;

						if (x >= ZScreamer.ActiveOWScene.selectedTileSizeX)
						{
							y++;
							x = 0;
						}
					}
				}
				else
				{
					scratchPadTiles[globalmouseTileDownX, globalmouseTileDownY] = ZScreamer.ActiveOWScene.selectedTile[0];
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				selecting = true;
			}

			BuildScratchTilesGfx();
			scratchPicturebox.Refresh();
		}

		private void scratchPicturebox_MouseUp(object sender, MouseEventArgs e)
		{
			if (MouseIsDown)
			{
				int tileX = e.X / Tile16MasterSheet.TileSpan;
				int tileY = e.Y / Tile16MasterSheet.TileSpan;

				if (e.Button == MouseButtons.Right)
				{
					if (tileX == globalmouseTileDownX && tileY == globalmouseTileDownY)
					{
						ZScreamer.ActiveOWScene.selectedTile = new ushort[1] { scratchPadTiles[globalmouseTileDownX, globalmouseTileDownY] };
						ZScreamer.ActiveOWScene.selectedTileSizeX = 1;
					}
					else
					{
						bool reverseX = false;
						bool reverseY = false;
						int sizeX = tileX - globalmouseTileDownX + 1;
						int sizeY = tileY - globalmouseTileDownY + 1;

						if (tileX < globalmouseTileDownX)
						{
							sizeX = globalmouseTileDownX - tileX + 1;
							reverseX = true;
						}
						if (tileY < globalmouseTileDownY)
						{
							sizeY = globalmouseTileDownY - tileY + 1;
							reverseY = true;
						}

						ZScreamer.ActiveOWScene.selectedTileSizeX = sizeX;
						ZScreamer.ActiveOWScene.selectedTile = new ushort[sizeX * sizeY];

						int pX = reverseX ? tileX : globalmouseTileDownX;
						int pY = reverseY ? tileY : globalmouseTileDownY;

						for (int y = 0; y < sizeY; y++)
						{
							for (int x = 0; x < sizeX; x++)
							{
								ZScreamer.ActiveOWScene.selectedTile[x + (y * sizeX)] = scratchPadTiles[pX + x, pY + y];
							}
						}
					}
				}
			}

			selecting = false;
			MouseIsDown = false;
			scratchPicturebox.Refresh();
		}

		private void scratchPicturebox_MouseMove(object sender, MouseEventArgs e)
		{
			if (ZScreamer.ActiveOWScene == null) return;
			
			mouseX_Real = e.X;
			mouseY_Real = e.Y;
			int mouseTileX = e.X / Tile16MasterSheet.TileSpan;
			int mouseTileY = e.Y / Tile16MasterSheet.TileSpan;

			if (lastTileHoverX != mouseTileX || lastTileHoverY != mouseTileY)
			{
				if (MouseIsDown)
				{
					if (e.Button == MouseButtons.Left)
					{
						int tileX = e.X / Tile16MasterSheet.TileSpan;
						int tileY = e.Y / Tile16MasterSheet.TileSpan;
						if (tileX <= 0) { tileX = 0; }
						if (tileY <= 0) { tileY = 0; }
						if (tileX > 16) { tileX = 16; }
						if (tileY > 225) { tileY = 225; }
						globalmouseTileDownX = tileX;
						globalmouseTileDownY = tileY;

						if (ZScreamer.ActiveOWScene.selectedTile.Length >= 1)
						{
							int y = 0;
							int x = 0;
							for (int i = 0; i < ZScreamer.ActiveOWScene.selectedTile.Length; i++)
							{
								if (globalmouseTileDownX + x < 16 && globalmouseTileDownY + y < 225)
								{
									scratchPadTiles[globalmouseTileDownX + x, globalmouseTileDownY + y] = ZScreamer.ActiveOWScene.selectedTile[i];
								}

								x++;

								if (x >= ZScreamer.ActiveOWScene.selectedTileSizeX)
								{
									y++;
									x = 0;
								}
							}
						}
					}

					BuildScratchTilesGfx();
				}

				scratchPicturebox.Refresh();
				lastTileHoverX = mouseTileX;
				lastTileHoverY = mouseTileY;
			}
			
		}

		private void scratchPicturebox_Paint(object sender, PaintEventArgs e)
		{
			if (ZScreamer.ActiveOW?.Tile16Sheet != null)
			{
				// USE mapblockset16 to draw tiles on this !! :GRIMACING:
				//public static IntPtr mapblockset16 = Marshal.AllocHGlobal(1048576);
				//public static Bitmap mapblockset16Bitmap;
				//base.OnPaint(e);
				Graphics g = e.Graphics;
				ColorMatrix cm = new ColorMatrix();
				ImageAttributes ia = new ImageAttributes();
				cm.Matrix33 = 0.50f;
				cm.Matrix22 = 2f;
				ia.SetColorMatrix(cm);
				g.CompositingMode = CompositingMode.SourceCopy;
				g.CompositingQuality = CompositingQuality.HighSpeed;
				g.InterpolationMode = InterpolationMode.NearestNeighbor;

				g.DrawImage(ZScreamer.ActiveGraphicsManager.OverworldScratchPadder.Bitmap, 0, 0);

				// DRAW ALL THE TILES 16x225

				g.CompositingMode = CompositingMode.SourceOver;

				if (selecting)
				{
					g.DrawRectangle(Pens.White, new Rectangle(globalmouseTileDownX * Tile16MasterSheet.TileSpan, globalmouseTileDownY * Tile16MasterSheet.TileSpan, (((mouseX_Real / Tile16MasterSheet.TileSpan) - globalmouseTileDownX) * Tile16MasterSheet.TileSpan) + Tile16MasterSheet.TileSpan, (((mouseY_Real / Tile16MasterSheet.TileSpan) - globalmouseTileDownY) * Tile16MasterSheet.TileSpan) + Tile16MasterSheet.TileSpan));
				}

				Rectangle r = new Rectangle(mouseX_Real & ~0xF, mouseY_Real & ~0xF, ZScreamer.ActiveOWScene.selectedTileSizeX * Tile16MasterSheet.TileSpan, ZScreamer.ActiveOWScene.selectedTile.Length / ZScreamer.ActiveOWScene.selectedTileSizeX * Tile16MasterSheet.TileSpan);

				g.DrawImage(ZScreamer.ActiveOWScene.tilesgfxBitmap, r, 0, 0, ZScreamer.ActiveOWScene.selectedTileSizeX * Tile16MasterSheet.TileSpan, ZScreamer.ActiveOWScene.selectedTile.Length / ZScreamer.ActiveOWScene.selectedTileSizeX * Tile16MasterSheet.TileSpan, GraphicsUnit.Pixel, ia);
				g.DrawRectangle(Pens.LightGreen, r);
				//g.DrawImage(ZScreamer.ActiveOWScene.tilesgfxBitmap, r, 0, 0, ZScreamer.ActiveOWScene.selectedTileSizeX * 16, (ZScreamer.ActiveOWScene.selectedTile.Length / ZScreamer.ActiveOWScene.selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
				//g.DrawRectangle(Pens.LightGreen, r);

				g.CompositingMode = CompositingMode.SourceCopy;
				//hideText = false;
			}
		}

		public unsafe void BuildScratchTilesGfx()
		{
			int ytile = 0;
			int xtile = 0;
			int x = 0;
			int y = 0;
			var canvas = ZScreamer.ActiveGraphicsManager.OverworldScratchPadder;
			canvas.Palette = ZScreamer.ActiveOW.Tile16Sheet.Palette;
			for (int i = 0; i < 3500; i++)
			{
				ushort srcTile = scratchPadTiles[xtile, ytile];

				ZScreamer.ActiveOW.Tile16Sheet.DrawTile16ToCanvas(canvas, x, y, srcTile);

				xtile++;
				x += 16;
				if (xtile >= 16)
				{
					xtile = 0;
					x = 0;
					ytile++;
					y += 16;
				}
			}
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			if (!ZScreamer.Active) return;

			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			//e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.currentOWgfx16Bitmap,new Rectangle(0,0,512,1024), new Rectangle(0,0,256,512),GraphicsUnit.Pixel);

			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
			e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.editort16Bitmap, Constants.Rect_0_0_256_1024);

			int y = tile8selected / 16;
			int x = tile8selected & 0xF;

			e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(x * Tile16MasterSheet.TileSpan, y * Tile16MasterSheet.TileSpan, Tile16MasterSheet.TileSpan, Tile16MasterSheet.TileSpan));
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			// TODO copy
			if (OverworldAuxSideTabs.SelectedTab.Name == "Tiles8")
			{
				// TODO: Add something here?

				/*
                int sx = 0;
                int sy = 0;
                int c = 0;

                int nx = 0;
                int ny = 0;
                for (int i = 0; i < 64; i++)
                {
                    for (int y = 0; y < 64; y += 2)
                    {
                        for (int x = 0; x < 64; x += 2)
                        {
                            //Console.WriteLine(overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile0.id);

                            overworld.tempTiles8_LW[x + (sx * 64), y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile0;
                            overworld.tempTiles8_LW[x + (sx * 64) + 1, y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile1;
                            overworld.tempTiles8_LW[x + (sx * 64), y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile2;
                            overworld.tempTiles8_LW[x + (sx * 64) + 1, y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile3;

                            overworld.tempTiles8_DW[x + (sx * 64), y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesDW[nx + (sx * 32), ny + (sy * 32)]].tile0;
                            overworld.tempTiles8_DW[x + (sx * 64) + 1, y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesDW[nx + (sx * 32), ny + (sy * 32)]].tile1;
                            overworld.tempTiles8_DW[x + (sx * 64), y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesDW[nx + (sx * 32), ny + (sy * 32)]].tile2;
                            overworld.tempTiles8_DW[x + (sx * 64) + 1, y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesDW[nx + (sx * 32), ny + (sy * 32)]].tile3;

                            if (i < 32)
                            {
                                overworld.tempTiles8_SP[x + (sx * 64), y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesSP[nx + (sx * 32), ny + (sy * 32)]].tile0;
                                overworld.tempTiles8_SP[x + (sx * 64) + 1, y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesSP[nx + (sx * 32), ny + (sy * 32)]].tile1;
                                overworld.tempTiles8_SP[x + (sx * 64), y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesSP[nx + (sx * 32), ny + (sy * 32)]].tile2;
                                overworld.tempTiles8_SP[x + (sx * 64) + 1, y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesSP[nx + (sx * 32), ny + (sy * 32)]].tile3;
                            }

                            nx++;
                        }

                        nx = 0;
                        ny++;
                    }

                    sx++;
                    if (sx >= 8)
                    {
                        sy++;
                        sx = 0;
                    }

                    c++;
                    if (c >= 64)
                    {
                        sx = 0;
                        sy = 0;
                        c = 0;
                    }

                    nx = 0;
                    ny = 0;
                }
                */
			}
			else
			{
				//overworld.createMap16Tilesmap();
				//Convert them back in tiles16
			}
		}

		public void updateSelectedTile16()
		{
			byte p = palSelected;
			tile8selected = 0;
			throw new NotImplementedException();
			//ZScreamer.ActiveOW.Tile16List.SetTile16At(ZScreamer.ActiveOWScene.selectedTile[0], null);
		}

		public unsafe void updateTiles()
		{
			byte p = palSelected;

			tile8selected = 0;
			byte* destPtr = (byte*) ZScreamer.ActiveGraphicsManager.editort16Ptr.ToPointer();
			byte* srcPtr = (byte*) ZScreamer.ActiveGraphicsManager.currentOWgfx16Ptr.ToPointer();
			int xx = 0;
			int yy = 0;
			for (int i = 0; i < 1024; i++)
			{
				for (int y = 0; y < 8; y++)
				{
					for (int x = 0; x < 4; x++)
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

			//Bitmap b = new Bitmap(128, 512, 64, System.Drawing.Imaging.PixelFormat.Format4bppIndexed, ZScreamer.ActiveGraphicsManager.currentOWgfx16Ptr);
			ZScreamer.ActiveGraphicsManager.editort16Bitmap.Palette = ZScreamer.ActiveOWScene.CurrentMap.MyArtist.Layer1Canvas.Palette;
			pictureBox1.Refresh();
			palette8Box.Refresh();
		}

		private unsafe void CopyTile(int x, int y, int xx, int yy, int id, byte p, byte* gfx16Pointer, byte* gfx8Pointer, int destwidth = 128)
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
			int index = xx + yy + (x * 2) + (my * destwidth);
			int pixel = gfx8Pointer[tx + (y * 64) + x];

			gfx16Pointer[index + r ^ 1] = (byte) ((pixel & 0x0F) | (p << 4));
			gfx16Pointer[index + r] = (byte) ((pixel >> 4) | (p << 4));
		}

		private void mirrorXCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			updateTiles();
		}

		private void palette8Box_Paint(object sender, PaintEventArgs e)
		{
			if (!ZScreamer.Active) return;

			var pal = ZScreamer.ActiveOWScene.CurrentMap.MyArtist.Layer1Canvas.Palette.Entries;

			for (int i = 0; i < 128; i++)
			{
				e.Graphics.FillRectangle(new SolidBrush(pal[i]), new Rectangle(i % 16 * 16, i & ~0xF, 16, 16));
			}

			e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(0, palSelected * 16, 256, 16));
		}

		private void palette8Box_MouseDown(object sender, MouseEventArgs e)
		{
			palSelected = (byte) (e.Y / 16);
			updateTiles();
		}

		private void searchtilesButton_Click(object sender, EventArgs e)
		{
			var alltilesIndexed = new Dictionary<ushort, int>();

			for (ushort i = 0; i < 3750; i++)
			{
				alltilesIndexed[i] = 0;
			}

			ZScreamer.ActiveOW.ForAllScreens(o =>
			{
				foreach (var tx in o.Tile16Map)
				{
					alltilesIndexed[tx]++;
				}
			});

			foreach (var ol in ZScreamer.ActiveOW.alloverlays)
			{
				foreach (var ot in ol.tilesData)
				{
					alltilesIndexed[ot.Tile16ID]++;
				}
			}

			StringBuilder sb = new StringBuilder();

			foreach (var (id, count) in alltilesIndexed.OrderBy(key => key.Value))
			{
				// TODO copy
				sb.AppendLine($"Tile {id:X4}: {count}");
			}

			SearchTilesForm stf = new SearchTilesForm();
			stf.textBox1.Text = sb.ToString();
			stf.ShowDialog();
		}

		private void textidTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!propertiesChangedFromForm)
			{
				ZScreamer.ActiveOWScene.CurrentMap.MessageID = (ushort) OWProperty_MessageID.HexValue;

				ZScreamer.ActiveScreamer.SetSelectedMessageID(OWProperty_MessageID.HexValue);
				previewTextPicturebox.Size = new Size(340, 102);
				previewTextPicturebox.Visible = true;
				previewTextPicturebox.Refresh();
			}
		}

		private void toolStripButton1_Click_1(object sender, EventArgs e)
		{
			for (int y = 0; y < 32; y++)
			{
				for (int x = 0; x < 32; x++)
				{
					ZScreamer.ActiveOWScene.CurrentMap.SetTile16At(0052, x, y);

					//overworld.allmapsTilesLW[x, y] = 0052;
				}
			}

			ZScreamer.ActiveOWScene.Refresh();
		}

		private void tilePictureBox_MouseEnter(object sender, EventArgs e)
		{
			tilePictureBox.Refresh();
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			tile8selected = (e.X / 16) + (e.Y & ~0xF);
			pictureBox1.Refresh();
		}

		private void currentTile8Box_Paint(object sender, PaintEventArgs e)
		{
			if (!ZScreamer.Active) return;

			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.CompositingMode = CompositingMode.SourceOver;
			updateSelectedTile16();
			e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.editingtile16Bitmap, Constants.Rect_0_0_64_64);
		}


		private static void UpdateEntireListForBigMap(IEnumerable<OverworldEntity> l, int map)
		{
			foreach (var o in l)
			{
				if (o.MapID != map) continue;

				byte copyOff = (o.MapX, o.MapY) switch
				{
					(< 32, < 32) => 0,
					(< 32, _   ) => 8,
					(_   , < 32) => 1,
					(_   , _   ) => 9,
				};

				o.MapID = ZScreamer.ActiveOW.allmaps[o.MapID + copyOff].MapID;

				if (o is OverworldDestination d)
				{
					d.UpdateMapProperties(ZScreamer.ActiveOW.allmaps[o.MapID].IsPartOfLargeMap);
				}

			}
		}

		// TODO maybe move to Overworld.cs?
		/// <summary>
		/// Updates world layout and sprites within the respective maps
		/// </summary>
		private void largemapCheckbox_Clicked(object sender, EventArgs e)
		{
			if (propertiesChangedFromForm) return;

			byte sel = ZScreamer.ActiveOWScene.CurrentMap.ParentMapID;

			if (largemapCheckbox.Checked)
			{
				// Prevent big maps on the edges
				if (((sel & 0x3F) > 0x37) || sel.BitsAllSet(0x07))
				{
					UIText.GeneralWarning("Maps on the edge of the screen cannot be made the origin of a large map.");

					largemapCheckbox.Checked = false;
					return;
				}

				// Search for adjacent maps already being large
				bool big1 = ZScreamer.ActiveOW.allmaps[sel + 1].IsPartOfLargeMap;
				bool big2 = ZScreamer.ActiveOW.allmaps[sel + 8].IsPartOfLargeMap;
				bool big3 = ZScreamer.ActiveOW.allmaps[sel + 9].IsPartOfLargeMap;

				if (big1 || big2 || big3)
				{
					StringBuilder no = new StringBuilder(4);
					no.Append($"Unable to make map {sel:X2} large because the following large maps are overlapping it:\n");

					if (big1)
					{
						no.Append($"{sel + 1:X2} ");
					}

					if (big2)
					{
						no.Append($"{sel + 8:X2} ");
					}

					if (big3)
					{
						no.Append($"{sel + 9:X2}");
					}

					UIText.GeneralWarning(no.ToString());

					largemapCheckbox.Checked = false;
					return;
				}
			} // End of failure to make map big

			bool big = largemapCheckbox.Checked;
			byte sel2 = (byte) (sel ^ 64);
			byte par1 = sel;
			byte par2, par3, par4;

			ZScreamer.ActiveOW.allmaps[sel].IsPartOfLargeMap = big;
			ZScreamer.ActiveOW.allmaps[sel + 1].IsPartOfLargeMap = big;
			ZScreamer.ActiveOW.allmaps[sel + 8].IsPartOfLargeMap = big;
			ZScreamer.ActiveOW.allmaps[sel + 9].IsPartOfLargeMap = big;

			ZScreamer.ActiveOW.allmaps[sel2].IsPartOfLargeMap = big;
			ZScreamer.ActiveOW.allmaps[sel2 + 1].IsPartOfLargeMap = big;
			ZScreamer.ActiveOW.allmaps[sel2 + 8].IsPartOfLargeMap = big;
			ZScreamer.ActiveOW.allmaps[sel2 + 9].IsPartOfLargeMap = big;

			int[] modthese;
			byte par = sel;

			if (big)
			{
				modthese = new int[] {
					par, par + 1, par + 8, par + 9,
					par ^ 64, (par ^ 64) + 1, (par ^ 64) + 8, (par ^ 64) + 9,
				};
				par2 = sel;
				par3 = sel;
				par4 = sel;
			}
			else
			{
				modthese = new int[] { par, par ^ 64 };
				par2 = (byte) (sel + 1);
				par3 = (byte) (sel + 8);
				par4 = (byte) (sel + 9);
			}

			ZScreamer.ActiveOW.allmaps[sel].ParentMap = ZScreamer.ActiveOW.allmaps[par1];
			ZScreamer.ActiveOW.allmaps[sel + 1].ParentMap = ZScreamer.ActiveOW.allmaps[par2];
			ZScreamer.ActiveOW.allmaps[sel + 8].ParentMap = ZScreamer.ActiveOW.allmaps[par3];
			ZScreamer.ActiveOW.allmaps[sel + 9].ParentMap = ZScreamer.ActiveOW.allmaps[par4];

			par1 ^= 64;
			par2 ^= 64;
			par3 ^= 64;
			par4 ^= 64;

			ZScreamer.ActiveOW.allmaps[sel2].ParentMap = ZScreamer.ActiveOW.allmaps[par1];
			ZScreamer.ActiveOW.allmaps[sel2 + 1].ParentMap = ZScreamer.ActiveOW.allmaps[par2];
			ZScreamer.ActiveOW.allmaps[sel2 + 8].ParentMap = ZScreamer.ActiveOW.allmaps[par3];
			ZScreamer.ActiveOW.allmaps[sel2 + 9].ParentMap = ZScreamer.ActiveOW.allmaps[par4];

			foreach (int m in modthese)
			{
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allentrances, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allholes, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allitems, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allBirds, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.AllTransports, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allexits, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.RainStateSprites, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.RescueStateSprites, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.AgaStateSprites, m);
			}
		}

		// TODO move to Overworld.cs and maybe make more generic
		/// <summary>
		/// Clears all overworld sprites of the selected
		/// </summary>
		public void clearOverworldSprites(GameState state)
		{
			ZScreamer.ActiveOW.GetSpritesForState(state).Clear();
		}

		/// <summary>
		/// Clears all overworld items
		/// </summary>
		public void clearOverworldItems()
		{
			ZScreamer.ActiveOW.allitems.Clear();
		}

		/// <summary>
		/// Clears all overworld entrances
		/// </summary>
		public void clearOverworldEntrances()
		{
			foreach (OverworldEntrance entrance in ZScreamer.ActiveOW.allentrances)
			{
				entrance.GlobalX = Constants.NullEntrance;
				entrance.GlobalY = Constants.NullEntrance;
			}
		}

		/// <summary>
		/// Clears all overworld entrances
		/// </summary>
		public void clearOverworldHoles()
		{
			foreach (var hole in ZScreamer.ActiveOW.allholes)
			{
				hole.GlobalX = Constants.NullEntrance;
				hole.GlobalY = Constants.NullEntrance;
			}
		}

		/// <summary>
		/// Clears all overworld exits
		/// </summary>
		public void clearOverworldExits()
		{
			foreach (var exit in ZScreamer.ActiveOW.allexits)
			{
				exit.GlobalX = Constants.NullEntrance;
				exit.GlobalY = Constants.NullEntrance;
			}
		}

		/// <summary>
		/// Clears all of the overworld overlays
		/// </summary>
		public void clearOverworldOverlays()
		{
			foreach (var overlay in ZScreamer.ActiveOW.alloverlays)
			{
				overlay.tilesData.Clear();
			}
		}

		private static readonly Predicate<OverworldEntity> removeFromMap =
			new(o => o.MapID == ZScreamer.ActiveOWScene.CurrentParentMapID);

		/// <summary>
		/// Clears all overworld sprites of the selected state
		/// </summary>
		public void clearAreaSprites(GameState state)
		{
			ZScreamer.ActiveOW.GetSpritesForState(state).RemoveAll(removeFromMap);
		}

		/// <summary>
		/// Clears all of the selected area's items
		/// </summary>
		public void clearAreaItems()
		{
			ZScreamer.ActiveOW.allitems.RemoveAll(removeFromMap);
		}

		/// <summary>
		/// Clears all the selected area's entrances
		/// </summary>
		public void clearAreaEntrances()
		{
			foreach (var entrance in ZScreamer.ActiveOW.allentrances)
			{
				if (entrance.MapID == ZScreamer.ActiveOWScene.CurrentParentMapID)
				{
					entrance.GlobalX = Constants.NullEntrance;
					entrance.GlobalY = Constants.NullEntrance;
					entrance.MapID = 0xFF;
					entrance.Map16Index = Constants.NullEntrance;
					entrance.TargetEntranceID = 0;
				}
			}
		}

		/// <summary>
		/// Clears all the slected area's entrances
		/// </summary>
		public void clearAreaHoles()
		{
			foreach (var hole in ZScreamer.ActiveOW.allholes)
			{
				if (hole.MapID == ZScreamer.ActiveOWScene.CurrentParentMapID)
				{
					hole.MapID = 0xFF;
					hole.GlobalX = Constants.NullEntrance;
					hole.GlobalY = Constants.NullEntrance;
					hole.Map16Index = Constants.NullEntrance;
					hole.TargetEntranceID = 0;
				}
			}
		}

		/// <summary>
		/// Clears all of the selected area's exits
		/// </summary>
		public void clearAreaExits()
		{
			foreach (var exit in ZScreamer.ActiveOW.allexits)
			{
				if (exit.MapID == ZScreamer.ActiveOWScene.CurrentParentMapID)
				{
					exit.MapID = 0xFF;
					exit.GlobalX = Constants.NullEntrance;
					exit.GlobalY = Constants.NullEntrance;
					exit.TargetRoomID = 0;
				}
			}
		}

		/// <summary>
		/// Clears all of the selected area's overlays
		/// </summary>
		public void clearAreaOverlays()
		{
			ZScreamer.ActiveOW.alloverlays[ZScreamer.ActiveOWScene.CurrentParentMapID].tilesData.Clear();
			ZScreamer.ActiveOWScene.Refresh();
		}

		/// <summary>
		/// Called when the area background color box is double cliked, brings up color editor.
		/// </summary>
		private void AreaBGColorPicturebox_MouseDoubleClick(object sender, EventArgs e)
		{
			cd.Color = ZScreamer.ActivePaletteManager.OverworldBackground[BGColorToUpdate];
			if (cd.ShowDialog() == DialogResult.OK)
			{
				ZScreamer.ActivePaletteManager.OverworldBackground[BGColorToUpdate] = cd.Color;
				areaBGColorPictureBox.Refresh();
			}

			ZScreamer.ActiveOWScene.CurrentMap.MyArtist.ReloadPalettes();
		}

		private void AreaBGColorPicturebox_Paint(object sender, PaintEventArgs e)
		{
			if (BGColorToUpdate < (ZScreamer.ActivePaletteManager?.OverworldBackground.Length ?? -999999999))
			{
				e.Graphics.FillRectangle(new SolidBrush(ZScreamer.ActivePaletteManager.OverworldBackground[BGColorToUpdate]), Constants.Rect_0_0_24_24);
			}
		}

		public void SetSelectedObjectLabels(int id, int x, int y)
		{
			SelectedObjectID.Text = id.ToString("X2");
			SelectedObjectX.Text = x.ToString("X2");
			SelectedObjectY.Text = y.ToString("X2");
		}
	}
}
