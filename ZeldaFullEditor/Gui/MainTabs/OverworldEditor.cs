using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;
using ZeldaFullEditor.Gui.ExtraForms;

namespace ZeldaFullEditor.Gui
{
	public partial class OverworldEditor : ScreamControl
	{
		private const int NullEntrance = 0xFFFF;
		public bool propertiesChangedFromForm = false;
		public Bitmap tmpPreviewBitmap = new Bitmap(256, 256);
		public Bitmap scratchPadBitmap = new Bitmap(256, 3600);
		public ushort[,] scratchPadTiles = new ushort[16, 225];
		public byte gridDisplay = 0;

		bool mouse_down = false;

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

		private TabControl.TabPageCollection AuxTabs;

		readonly ColorDialog cd = new ColorDialog();
		public OverworldEditor(ZScreamer parent = null) : base(parent)
		{
			InitializeComponent();
		}
		public void InitOpen()
		{
			//scene = new SceneOW(this, mainForm);
			ZS.OverworldScene.Location = Constants.Point_0_0;
			ZS.OverworldScene.Size = Constants.Size4096x4096;
			splitContainer1.Panel2.Controls.Clear();
			splitContainer1.Panel2.Controls.Add(ZS.OverworldScene);
			ZS.OverworldScene.CreateScene();
			ZS.OverworldScene.initialized = true;
			ZS.OverworldScene.Refresh();
			penModeButton.Tag = OverworldEditMode.Tile16;
			fillModeButton.Tag = OverworldEditMode.Tile16;
			entranceModeButton.Tag = OverworldEditMode.Entrances;
			exitModeButton.Tag = OverworldEditMode.Exits;
			itemModeButton.Tag = OverworldEditMode.Secrets;
			spriteModeButton.Tag = OverworldEditMode.Sprites;
			transportModeButton.Tag = OverworldEditMode.Transports;
			overlayButton.Tag = OverworldEditMode.Overlay;
			gravestoneButton.Tag = OverworldEditMode.Gravestones;
			stateCombobox.SelectedIndex = 1;
			scratchPicturebox.Image = scratchPadBitmap;
			AuxTabs = OverworldAuxSideTabs.TabPages;
			SwapInAuxTab(null);
			AuxTabs.Remove(Tiles8);
			//setTilesGfx();
			bool fromFile = false;
			byte[] file = new byte[(225 * 16) * 2];

			if (File.Exists("ScratchPad.dat"))
			{
				using (FileStream fs = new FileStream("ScratchPad.dat", FileMode.Open, FileAccess.Read))
				{
					fs.Read(file, 0, (int) fs.Length);
					fs.Close();
					fromFile = true;
				}
			}

			int t = 0;
			for (ushort x = 0; x < 225; x++)
			{
				for (ushort y = 0; y < 16; y++, t+=2)
				{
					scratchPadTiles[y, x] = (ushort) (fromFile ? (file[t] << 8) | file[t + 1] : 0);
				}
			}

			ZS.GFXManager.editort16Bitmap.Palette = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].gfxBitmap.Palette;
			updateTiles();
			pictureBox1.Refresh();
		}

		public void saveScratchPad()
		{
			byte[] file = new byte[225 * 16 * 2];

			int t = 0;
			for (int x = 0; x < 225; x++)
			{
				for (int y = 0; y < 16; y++)
				{
					file[t++] = (byte) (scratchPadTiles[y, x] >> 8);
					file[t++] = (byte) scratchPadTiles[y, x];
				}
			}

			using (FileStream fs = new FileStream("ScratchPad.dat", FileMode.OpenOrCreate, FileAccess.Write))
			{
				fs.Write(file, 0, (int) fs.Length);
				fs.Close();
			}
		}

		public void UpdateGUIProperties(OverworldMap m, int gamestate = 0)
		{
			OWProperty_BGGFX.HexValue = m.gfx;
			OWProperty_BGPalette.HexValue = m.palette;
			OWProperty_SPRGFX.HexValue = m.sprgfx[gamestate];
			OWProperty_SPRPalette.HexValue = m.sprpalette[gamestate];

			largemapCheckbox.Checked = m.largeMap;
			BGColorToUpdate = m.parent;

		}
		private void ModeButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < owToolStrip.Items.Count; i++) // Uncheck all the other modes.
			{
				if (owToolStrip.Items[i] is ToolStripButton tt)
				{
					tt.Checked = false;
				}
			}

			(sender as ToolStripButton).Checked = true;
			ZS.CurrentOWMode = (OverworldEditMode) ((sender as ToolStripButton).Tag);
			UpdateForMode(ZS.CurrentOWMode);
		}

		public void UpdateForMode(OverworldEditMode m)
		{
			switch (m)
			{
				case OverworldEditMode.Entrances:
					SwapInAuxTab(OWTabEntranceProps);
					break;

				case OverworldEditMode.Exits:
					SwapInAuxTab(OWTabExitProps);
					break;

				case OverworldEditMode.Transports:
					SwapInAuxTab(OWTabTransportProps);
					break;

				default:
					SwapInAuxTab(null);
					break;

			}
		}

		private void SwapInAuxTab(TabPage t)
		{
			if (t != OWTabEntranceProps)
			{
				AuxTabs.Remove(OWTabEntranceProps);
			}
			else
			{
				ZS.OverworldScene.SetSelectedEntrance(null);
			}

			if (t != OWTabExitProps)
			{
				AuxTabs.Remove(OWTabExitProps);
			}
			else
			{
				ZS.OverworldScene.SetSelectedExit(null);
			}

			if (t != OWTabTransportProps)
			{
				AuxTabs.Remove(OWTabTransportProps);
			}
			else
			{
				ZS.OverworldScene.SetSelectedTransport(null);
			}

			if (t == null)
			{
				return;
			}

			AuxTabs.Add(t);
			OverworldAuxSideTabs.SelectedTab = t;
		}

		public void SetSelectedExit(ExitOW e)
		{
			ZS.OverworldScene.SetSelectedExitSilently(e);
			UpdateSelectedExitProps(e);

			OWExitPanel.Enabled = e != null;
			OWExitDisabled.Visible = e == null;
		}

		public void UpdateSelectedExitProps(ExitOW e)
		{
			OWExitPropID.HexValue = e?.mapId ?? 0;
			OWExitPropX.HexValue = e?.playerX ?? 0;
			OWExitPropY.HexValue = e?.playerY ?? 0;
		}
		public void SetSelectedEntrance(EntranceOWEditor e)
		{
			ZS.OverworldScene.SetSelectedEntranceSilently(e);
			UpdateSelectedEntranceProps(e);

			OWEntrancePanel.Enabled = e != null;
			OWEntranceDisabled.Visible = e == null;
		}

		public void UpdateSelectedEntranceProps(EntranceOWEditor e)
		{
			OWEntrancePropID.HexValue = e?.mapId ?? 0;
			OWEntrancePropX.HexValue = e?.x ?? 0;
			OWEntrancePropY.HexValue = e?.y ?? 0;
		}

		public void SetSelectedTransport(TransportOW e)
		{
			ZS.OverworldScene.SetSelectedTransportSilently(e);
			UpdateSelectedransportProps(e);

			OWTransportPanel.Enabled = e != null;
			OWTransportDisabled.Visible = e == null;
		}

		public void UpdateSelectedransportProps(TransportOW e)
		{
			OWTransportPropID.HexValue = e?.mapId ?? 0;
			OWTransportPropX.HexValue = e?.playerX ?? 0;
			OWTransportPropY.HexValue = e?.playerY ?? 0;
		}

		private void stateCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ZS.OverworldManager.gameState = (byte) stateCombobox.SelectedIndex;
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			ZS.MainForm.saveToolStripMenuItem_Click(sender, e);
		}

		private void gfxTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!propertiesChangedFromForm)
			{
				OverworldMap mapParent = ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent];

				if (ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent == 255)
				{
					mapParent = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap];
				}

				mapParent.palette = (byte) OWProperty_BGPalette.HexValue;
				mapParent.gfx = (byte) OWProperty_BGGFX.HexValue;

				if (mapParent.index >= 64)
				{
					mapParent.sprgfx[0] = (byte) OWProperty_SPRGFX.HexValue;
					mapParent.sprpalette[0] = (byte) OWProperty_SPRPalette.HexValue;
				}
				else
				{
					ZS.OverworldManager.allmaps[mapParent.index].sprgfx[ZS.OverworldManager.gameState] = (byte) OWProperty_SPRGFX.HexValue;
					mapParent.sprpalette[ZS.OverworldManager.gameState] = (byte) OWProperty_SPRPalette.HexValue;
				}

				if (mapParent.largeMap)
				{
					ZS.OverworldManager.allmaps[mapParent.index + 1].gfx = mapParent.gfx;
					ZS.OverworldManager.allmaps[mapParent.index + 1].sprgfx = mapParent.sprgfx;
					ZS.OverworldManager.allmaps[mapParent.index + 1].palette = mapParent.palette;
					ZS.OverworldManager.allmaps[mapParent.index + 1].sprpalette = mapParent.sprpalette;

					ZS.OverworldManager.allmaps[mapParent.index + 8].gfx = mapParent.gfx;
					ZS.OverworldManager.allmaps[mapParent.index + 8].sprgfx = mapParent.sprgfx;
					ZS.OverworldManager.allmaps[mapParent.index + 8].palette = mapParent.palette;
					ZS.OverworldManager.allmaps[mapParent.index + 8].sprpalette = mapParent.sprpalette;

					ZS.OverworldManager.allmaps[mapParent.index + 9].gfx = mapParent.gfx;
					ZS.OverworldManager.allmaps[mapParent.index + 9].sprgfx = mapParent.sprgfx;
					ZS.OverworldManager.allmaps[mapParent.index + 9].palette = mapParent.palette;
					ZS.OverworldManager.allmaps[mapParent.index + 9].sprpalette = mapParent.sprpalette;

					mapParent.BuildMap();
					ZS.OverworldManager.allmaps[mapParent.index + 1].BuildMap();
					ZS.OverworldManager.allmaps[mapParent.index + 8].BuildMap();
					ZS.OverworldManager.allmaps[mapParent.index + 9].BuildMap();
				}
				else
				{
					mapParent.BuildMap();
				}

				//scene.updateMapGfx();
				ZS.OverworldScene.Invalidate();
				//scene.Refresh();
			}
		}

		private static readonly RectangleF TileRect = new RectangleF(128, 3408, 128, 688);
		private void tilePictureBox_Paint(object sender, PaintEventArgs e)
		{
			if (ZS.GFXManager.mapblockset16Bitmap != null)
			{
				e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
				e.Graphics.CompositingMode = CompositingMode.SourceOver;
				e.Graphics.DrawImage(ZS.GFXManager.mapblockset16Bitmap,
					Constants.Rect_0_0_128_4096,
					Constants.Rect_0_0_128_4096,
					GraphicsUnit.Pixel);
				e.Graphics.DrawImage(ZS.GFXManager.mapblockset16Bitmap,
					Constants.Rect_128_0_128_4096,
					Constants.Rect_0_4096_128_4096,
					GraphicsUnit.Pixel);

				if (ZS.OverworldScene.selectedTile.Length > 0)
				{
					int x = (ZS.OverworldScene.selectedTile[0] % 8) * 16;
					int y = ((ZS.OverworldScene.selectedTile[0] / 8)) * 16;

					if (ZS.OverworldScene.selectedTile[0] >= 2048)
					{
						y -= 4096;
						x += 128;
					}

					// TODO copy
					e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(x, y, 16, 16));
					selectedTileLabel.Text = "Selected Tile : " + ZS.OverworldScene.selectedTile[0].ToString("X4");
				}

				e.Graphics.FillRectangle(Brushes.Black, TileRect);
			}
		}

		private void tilePictureBox_MouseClick(object sender, MouseEventArgs e)
		{
			ZS.OverworldScene.selectedTileSizeX = 1;
			if (e.X > 128)
			{
				ZS.OverworldScene.selectedTile = new ushort[1] { (ushort) (((e.X - 128) / 16) + ((e.Y / 16) * 8) + 2048) };
				if (ZS.OverworldScene.selectedTile[0] > 3751)
				{
					ZS.OverworldScene.selectedTile[0] = 3751;
				}
			}
			else
			{
				ZS.OverworldScene.selectedTile = new ushort[1] { (ushort) ((e.X / 16) + ((e.Y / 16) * 8)) };
			}

			tilePictureBox.Refresh();
		}

		/// <summary>
		/// Called when the LW button on the overworld editor form is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lwButton_Click(object sender, EventArgs e)
		{
			SelectMapOffset(0);
		}

		/// <summary>
		/// Called when the DW button on the overworld editor form is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dwButton_Click(object sender, EventArgs e)
		{
			SelectMapOffset(64);
		}

		/// <summary>
		/// Called when the SP button on the overworld editor form is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void spButton_Click(object sender, EventArgs e)
		{
			SelectMapOffset(128);
		}

		private void SelectMapOffset(int o)
		{
			ZS.OverworldScene.selectedMap = o;
			ZS.OverworldScene.selectedMapParent = ZS.OverworldManager.allmaps[o].parent;
			ZS.OverworldManager.worldOffset = o;
			ZS.OverworldScene.Refresh();
		}


		private void runtestButton_Click(object sender, EventArgs e)
		{
			ZS.MainForm.runtestButton_Click(sender, e);
		}

		private void tilePictureBox_DoubleClick(object sender, EventArgs e)
		{
			Tile16Editor ted = new Tile16Editor(ZS);
			if (ted.ShowDialog() == DialogResult.OK)
			{
				new Thread(() =>
				{
					Thread.CurrentThread.IsBackground = true;
					for (int i = 0; i < 159; i++)
					{
						if (ZS.OverworldManager.allmaps[i].needRefresh)
						{
							ZS.OverworldManager.allmaps[i].BuildMap();
							ZS.OverworldManager.allmaps[i].needRefresh = false;
						}
					}
				}).Start();
			}
		}

		private void undoButton_Click(object sender, EventArgs e)
		{
			ZS.MainForm.undoButton_Click(sender, e);
		}

		private void redoButton_Click(object sender, EventArgs e)
		{
			ZS.MainForm.redoButton_Click(sender, e);
		}

		private void refreshToolStrip_Click(object sender, EventArgs e)
		{
			new Thread(() =>
			{
				Thread.CurrentThread.IsBackground = true;
				for (int i = 0; i < 159; i++)
				{
					if (ZS.OverworldManager.allmaps[i].needRefresh)
					{
						ZS.OverworldManager.allmaps[i].BuildMap();
						ZS.OverworldManager.allmaps[i].needRefresh = false;
					}
				}
			}).Start();
		}

		private void musicButton_Click(object sender, EventArgs e)
		{
			OWMusicForm owmf = new OWMusicForm(ZS);
			owmf.mapIndex = (byte) ZS.OverworldScene.selectedMap;
			owmf.musics[0] = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].musics[0];
			owmf.musics[1] = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].musics[1];
			owmf.musics[2] = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].musics[2];
			owmf.musics[3] = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].musics[3];

			if (owmf.ShowDialog() == DialogResult.OK)
			{
				ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].musics[0] = owmf.musics[0];
				ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].musics[1] = owmf.musics[1];
				ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].musics[2] = owmf.musics[2];
				ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].musics[3] = owmf.musics[3];
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ZS.SetSelectedMessageID(OWProperty_MessageID.HexValue);
			ZS.SelectTab(TabSelection.TextEditor);
		}

		private void previewTextPicturebox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			ColorPalette cp = ZS.GFXManager.currentfontgfx16Bitmap.Palette;
			int defaultColor = 6;

			for (int i = 0; i < 4; i++)
			{
				if (i == 0)
				{
					cp.Entries[i] = Color.Transparent;
				}
				else
				{
					cp.Entries[i] = ZS.GFXManager.roomBg1Bitmap.Palette.Entries[(defaultColor * 4) + i];
				}
			}

			ZS.GFXManager.currentfontgfx16Bitmap.Palette = cp;

			// TODO make new brushes
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(ZS.GFXManager.currentfontgfx16Bitmap, Constants.Rect_0_0_340_102, Constants.Rect_0_0_170_51, GraphicsUnit.Pixel);
			e.Graphics.FillRectangle(Constants.HalfRedBrush, Constants.Rect_336_0_4_102);
		}

		private void textidTextbox_Click(object sender, EventArgs e)
		{
			ZS.SetSelectedMessageID(OWProperty_MessageID.HexValue);
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
			globalmouseTileDownX = e.X / 16;
			globalmouseTileDownY = e.Y / 16;

			if (ZS.OverworldScene.needRedraw)
			{
				ZS.OverworldScene.needRedraw = false;
				return;
			}

			mouse_down = true;

			if (e.Button == MouseButtons.Left)
			{
				if (ZS.OverworldScene.selectedTile.Length >= 1)
				{
					int y = 0;
					int x = 0;
					//ushort[] undotiles = new ushort[scene.selectedTile.Length];

					for (int i = 0; i < ZS.OverworldScene.selectedTile.Length; i++)
					{
						if (globalmouseTileDownX + x <= 15)
						{
							scratchPadTiles[globalmouseTileDownX + x, globalmouseTileDownY + y] = ZS.OverworldScene.selectedTile[i];
						}

						x++;

						if (x >= ZS.OverworldScene.selectedTileSizeX)
						{
							y++;
							x = 0;
						}
					}
				}
				else
				{
					scratchPadTiles[globalmouseTileDownX, globalmouseTileDownY] = ZS.OverworldScene.selectedTile[0];
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
			if (mouse_down)
			{
				int tileX = (e.X / 16);
				int tileY = (e.Y / 16);

				if (e.Button == MouseButtons.Right)
				{
					if (tileX == globalmouseTileDownX && tileY == globalmouseTileDownY)
					{
						ZS.OverworldScene.selectedTile = new ushort[1] { scratchPadTiles[globalmouseTileDownX, globalmouseTileDownY] };
						ZS.OverworldScene.selectedTileSizeX = 1;
					}
					else
					{
						bool reverseX = false;
						bool reverseY = false;
						int sizeX = (tileX - globalmouseTileDownX) + 1;
						int sizeY = (tileY - globalmouseTileDownY) + 1;

						if (tileX < globalmouseTileDownX)
						{
							sizeX = (globalmouseTileDownX - tileX) + 1;
							reverseX = true;
						}
						if (tileY < globalmouseTileDownY)
						{
							sizeY = (globalmouseTileDownY - tileY) + 1;
							reverseY = true;
						}

						ZS.OverworldScene.selectedTileSizeX = sizeX;
						ZS.OverworldScene.selectedTile = new ushort[sizeX * sizeY];

						for (int y = 0; y < sizeY; y++)
						{
							for (int x = 0; x < sizeX; x++)
							{
								int pX = reverseX ? tileX : globalmouseTileDownX;
								int pY = reverseY ? tileY : globalmouseTileDownY;

								ZS.OverworldScene.selectedTile[x + (y * sizeX)] = scratchPadTiles[pX + x, pY + y];
							}
						}
					}
				}
			}

			selecting = false;
			mouse_down = false;
			scratchPicturebox.Refresh();
		}

		private void scratchPicturebox_MouseMove(object sender, MouseEventArgs e)
		{
			if (ZS.OverworldScene.initialized)
			{
				mouseX_Real = e.X;
				mouseY_Real = e.Y;
				int mouseTileX = e.X / 16;
				int mouseTileY = e.Y / 16;

				if (lastTileHoverX != mouseTileX || lastTileHoverY != mouseTileY)
				{
					if (mouse_down)
					{
						if (e.Button == MouseButtons.Left)
						{
							int tileX = (e.X / 16);
							int tileY = (e.Y / 16);
							if (tileX <= 0) { tileX = 0; }
							if (tileY <= 0) { tileY = 0; }
							if (tileX > 16) { tileX = 16; }
							if (tileY > 225) { tileY = 225; }
							globalmouseTileDownX = tileX;
							globalmouseTileDownY = tileY;

							if (ZS.OverworldScene.selectedTile.Length >= 1)
							{
								int y = 0;
								int x = 0;
								for (int i = 0; i < ZS.OverworldScene.selectedTile.Length; i++)
								{
									if (globalmouseTileDownX + x < 16 && globalmouseTileDownY + y < 225)
									{
										scratchPadTiles[globalmouseTileDownX + x, globalmouseTileDownY + y] = ZS.OverworldScene.selectedTile[i];
									}

									x++;

									if (x >= ZS.OverworldScene.selectedTileSizeX)
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
		}

		private void scratchPicturebox_Paint(object sender, PaintEventArgs e)
		{
			if (ZS.GFXManager.mapblockset16Bitmap != null)
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

				g.DrawImage(ZS.GFXManager.scratchblockset16Bitmap, 0, 0);

				// DRAW ALL THE TILES 16x225

				g.CompositingMode = CompositingMode.SourceOver;

				if (selecting)
				{
					g.DrawRectangle(Pens.White, new Rectangle((globalmouseTileDownX * 16), (globalmouseTileDownY * 16), (((mouseX_Real / 16) - globalmouseTileDownX) * 16) + 16, (((mouseY_Real / 16) - globalmouseTileDownY) * 16) + 16));
				}

				Rectangle r = new Rectangle(mouseX_Real & ~0xF, mouseY_Real & ~0xF, ZS.OverworldScene.selectedTileSizeX * 16, (ZS.OverworldScene.selectedTile.Length / ZS.OverworldScene.selectedTileSizeX) * 16);

				g.DrawImage(ZS.OverworldScene.tilesgfxBitmap, r, 0, 0, ZS.OverworldScene.selectedTileSizeX * 16, (ZS.OverworldScene.selectedTile.Length / ZS.OverworldScene.selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
				g.DrawRectangle(Pens.LightGreen, r);
				//g.DrawImage(ZS.OverworldScene.tilesgfxBitmap, r, 0, 0, ZS.OverworldScene.selectedTileSizeX * 16, (ZS.OverworldScene.selectedTile.Length / ZS.OverworldScene.selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
				//g.DrawRectangle(Pens.LightGreen, r);

				g.CompositingMode = CompositingMode.SourceCopy;
				//hideText = false;
			}
		}

		public unsafe void BuildScratchTilesGfx()
		{
			ZS.GFXManager.scratchblockset16Bitmap.Palette = ZS.GFXManager.mapblockset16Bitmap.Palette;
			var gfx16Data = (byte*) ZS.GFXManager.mapblockset16.ToPointer(); //(byte*)allgfx8Ptr.ToPointer();
			var gfx16DataScratch = (byte*) ZS.GFXManager.scratchblockset16.ToPointer(); //(byte*)allgfx16Ptr.ToPointer();
			int ytile = 0;
			int xtile = 0;

			for (var i = 0; i < 3500; i++)
			{
				ushort srcTile = scratchPadTiles[xtile, ytile];
				//Console.WriteLine(srcTile);
				int srcTileY = (srcTile / 8);
				int srcTileX = srcTile - (srcTileY * 8);
				int tPos = (xtile * 16) + (ytile * 4096);
				int srctPos = (srcTileX * 16) + (srcTileY * 2048);

				for (int y = 0; y < 16; y++)
				{
					for (int x = 0; x < 16; x++)
					{
						gfx16DataScratch[tPos + (x + (y * 256))] = gfx16Data[srctPos + (x + (y * 128))];
					}
				}

				xtile++;
				if (xtile >= 16)
				{
					xtile = 0;
					ytile++;
				}
			}
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			//e.Graphics.DrawImage(ZS.GFXManager.currentOWgfx16Bitmap,new Rectangle(0,0,512,1024), new Rectangle(0,0,256,512),GraphicsUnit.Pixel);

			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
			e.Graphics.DrawImage(ZS.GFXManager.editort16Bitmap, Constants.Rect_0_0_256_1024);

			int y = (tile8selected / 16);
			int x = tile8selected - (y * 16);

			e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(x * 16, y * 16, 16, 16));
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

		public unsafe void updateSelectedTile16()
		{
			byte p = palSelected;
			tile8selected = 0;
			byte* destPtr = (byte*) ZS.GFXManager.editingtile16.ToPointer();
			byte* srcPtr = (byte*) ZS.GFXManager.currentOWgfx16Ptr.ToPointer();
			Tile16 t = ZS.OverworldManager.Tile16List[ZS.OverworldScene.selectedTile[0]];

			for (int y = 0; y < 8; y++)
			{
				for (int x = 0; x < 4; x++)
				{
					CopyTile(x, y, 0, 0, t.tile0.ID, p, destPtr, srcPtr, 16);
					CopyTile(x, y, 8, 0, t.tile1.ID, p, destPtr, srcPtr, 16);
					CopyTile(x, y, 0, 8, t.tile2.ID, p, destPtr, srcPtr, 16);
					CopyTile(x, y, 8, 8, t.tile3.ID, p, destPtr, srcPtr, 16);
				}
			}

			//Bitmap b = new Bitmap(128, 512, 64, System.Drawing.Imaging.PixelFormat.Format4bppIndexed, ZS.GFXManager.currentOWgfx16Ptr);
			ZS.GFXManager.editort16Bitmap.Palette = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].gfxBitmap.Palette;
		}

		public unsafe void updateTiles()
		{
			byte p = palSelected;

			tile8selected = 0;
			byte* destPtr = (byte*) ZS.GFXManager.editort16Ptr.ToPointer();
			byte* srcPtr = (byte*) ZS.GFXManager.currentOWgfx16Ptr.ToPointer();
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

			//Bitmap b = new Bitmap(128, 512, 64, System.Drawing.Imaging.PixelFormat.Format4bppIndexed, ZS.GFXManager.currentOWgfx16Ptr);
			ZS.GFXManager.editort16Bitmap.Palette = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].gfxBitmap.Palette;
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
			for (int i = 0; i < 128; i++)
			{
				Color c = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].gfxBitmap.Palette.Entries[i];
				e.Graphics.FillRectangle(new SolidBrush(c), new Rectangle((i % 16) * 16, (i / 16) * 16, 16, 16));
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
			Dictionary<ushort, ushort> alltilesIndexed = new Dictionary<ushort, ushort>();
			int sx = 0;
			int sy = 0;

			for (ushort i = 0; i < 3750; i++)
			{
				alltilesIndexed.Add(i, 0);
			}

			for (int i = 0; i < 64; i++)
			{
				for (int y = 0; y < 32; y += 1)
				{
					for (int x = 0; x < 32; x += 1)
					{
						alltilesIndexed[ZS.OverworldManager.allmapsTilesLW[x + (sx * 32), y + (sy * 32)]]++;
						alltilesIndexed[ZS.OverworldManager.allmapsTilesDW[x + (sx * 32), y + (sy * 32)]]++;

						if (i < 32)
						{
							alltilesIndexed[ZS.OverworldManager.allmapsTilesSP[x + (sx * 32), y + (sy * 32)]]++;
						}
					}
				}

				foreach (TilePos t in ZS.OverworldManager.alloverlays[i].tilesData)
				{
					alltilesIndexed[t.tileId]++;
				}

				foreach (TilePos t in ZS.OverworldManager.alloverlays[i + 64].tilesData)
				{
					alltilesIndexed[t.tileId]++;
				}

				sx++;
				if (sx >= 8)
				{
					sy++;
					sx = 0;
				}
			}

			StringBuilder sb = new StringBuilder();
			foreach (KeyValuePair<ushort, ushort> tiles in alltilesIndexed.OrderBy(key => key.Value))
			{
				// TODO copy
				sb.AppendLine("Tile - " + tiles.Key.ToString("X4") + " : " + tiles.Value.ToString("X4"));
			}

			SearchTilesForm stf = new SearchTilesForm();
			stf.textBox1.Text = sb.ToString();
			stf.ShowDialog();
		}

		private void textidTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!propertiesChangedFromForm)
			{
				OverworldMap mapParent = ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent];

				if (ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent == 255)
				{
					mapParent = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap];
				}

				mapParent.messageID = (ushort) OWProperty_MessageID.HexValue;

				ZS.SetSelectedMessageID(OWProperty_MessageID.HexValue);
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
					ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].tilesUsed[x, y] = 0052;

					//overworld.allmapsTilesLW[x, y] = 0052;
				}
			}

			ZS.OverworldScene.Refresh();
		}

		private void tilePictureBox_MouseEnter(object sender, EventArgs e)
		{
			ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].BuildMap();
			tilePictureBox.Refresh();
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			tile8selected = (e.X / 16) + (e.Y & ~0xF);
			pictureBox1.Refresh();
		}

		private void currentTile8Box_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.CompositingMode = CompositingMode.SourceOver;
			updateSelectedTile16();
			e.Graphics.DrawImage(ZS.GFXManager.editingtile16Bitmap, Constants.Rect_0_0_64_64);
		}

		/// <summary>
		/// Called when the largemap checkbox is clicke, upataes the world layout and then updates all of the sprites within that area.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// TODO copy and string builder
		private void largemapCheckbox_Clicked(object sender, EventArgs e)
		{
			if (!propertiesChangedFromForm)
			{
				int m = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent;

				if (largemapCheckbox.Checked) // Large map
				{
					// If we are trying to overlap large areas, fail.
					if (ZS.OverworldManager.allmaps[m + 1].largeMap || ZS.OverworldManager.allmaps[m + 8].largeMap || ZS.OverworldManager.allmaps[m + 9].largeMap)
					{
						int i = 0;
						string temp = "";

						if (ZS.OverworldManager.allmaps[m + 1].largeMap)
						{
							temp += (m + 1).ToString("X2") + ", ";
							i++;
						}
						if (ZS.OverworldManager.allmaps[m + 8].largeMap)
						{
							temp += (m + 8).ToString("X2") + ", ";
							i++;
						}
						if (ZS.OverworldManager.allmaps[m + 9].largeMap)
						{
							temp += (m + 9).ToString("X2") + ", ";
							i++;
						}

						temp = temp.Remove(temp.Length - 2);
						if (i == 1)
						{
							MessageBox.Show("Cannot make overlapping large area. Area: " + temp + " is already part of a large area.", "Bad Error", MessageBoxButtons.OK);
						}
						else if (i == 2)
						{
							temp = temp.Remove(2, 1);
							temp = temp.Insert(temp.Length - 2, "and ");
							MessageBox.Show("Cannot make overlapping large area. Areas: " + temp + " are already part of a large area.", "Bad Error", MessageBoxButtons.OK);
						}
						else
						{
							temp = temp.Insert(temp.Length - 2, "and ");
							MessageBox.Show("Cannot make overlapping large area. Areas: " + temp + " are already part of a large area.", "Bad Error", MessageBoxButtons.OK);
						}

						largemapCheckbox.Checked = false;
					}
					else
					{
						ZS.OverworldManager.allmaps[m].largeMap = true;
						ZS.OverworldManager.allmaps[m + 1].largeMap = true;
						ZS.OverworldManager.allmaps[m + 8].largeMap = true;
						ZS.OverworldManager.allmaps[m + 9].largeMap = true;

						ZS.OverworldManager.allmaps[m].parent = (byte) m;
						ZS.OverworldManager.allmaps[m + 1].parent = (byte) m;
						ZS.OverworldManager.allmaps[m + 8].parent = (byte) m;
						ZS.OverworldManager.allmaps[m + 9].parent = (byte) m;

						if (m < 64)
						{
							ZS.OverworldManager.allmaps[m + 64].largeMap = true;
							ZS.OverworldManager.allmaps[m + 64 + 1].largeMap = true;
							ZS.OverworldManager.allmaps[m + 64 + 8].largeMap = true;
							ZS.OverworldManager.allmaps[m + 64 + 9].largeMap = true;

							ZS.OverworldManager.allmaps[m + 64].parent = (byte) (m + 64);
							ZS.OverworldManager.allmaps[m + 64 + 1].parent = (byte) (m + 64);
							ZS.OverworldManager.allmaps[m + 64 + 8].parent = (byte) (m + 64);
							ZS.OverworldManager.allmaps[m + 64 + 9].parent = (byte) (m + 64);
						}
						else if (m >= 64 && m < 128)
						{
							ZS.OverworldManager.allmaps[m - 64].largeMap = true;
							ZS.OverworldManager.allmaps[m - 64 + 1].largeMap = true;
							ZS.OverworldManager.allmaps[m - 64 + 8].largeMap = true;
							ZS.OverworldManager.allmaps[m - 64 + 9].largeMap = true;

							ZS.OverworldManager.allmaps[m - 64].parent = (byte) (m - 64);
							ZS.OverworldManager.allmaps[m - 64 + 1].parent = (byte) (m - 64);
							ZS.OverworldManager.allmaps[m - 64 + 8].parent = (byte) (m - 64);
							ZS.OverworldManager.allmaps[m - 64 + 9].parent = (byte) (m - 64);
						}

						ZS.OverworldManager.getLargeMaps();

						if (m < 64)
						{
							int[] mtable = new int[8] { 0, 1, 8, 9, 64, 64 + 1, 64 + 8, 64 + 9 };

							for (int i = 0; i < 8; i++)
							{
								m = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent + mtable[i];

								foreach (EntranceOWEditor o in ZS.OverworldManager.allentrances)
								{
									if (o.mapId == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent);
									}
								}
								foreach (EntranceOWEditor o in ZS.OverworldManager.allholes)
								{
									if (o.mapId == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent);
									}
								}
								foreach (TransportOW o in ZS.OverworldManager.allBirds)
								{
									if (o.mapId == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent, ZS.OverworldManager);
									}
								}
								foreach (TransportOW o in ZS.OverworldManager.allWhirlpools)
								{
									if (o.mapId == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent, ZS.OverworldManager);
									}
								}
								foreach (ExitOW o in ZS.OverworldManager.allexits)
								{
									if (o.mapId == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent, ZS.OverworldManager);
									}
								}
								foreach (RoomPotSaveEditor o in ZS.OverworldManager.allitems)
								{
									if (o.roomMapId == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent);
									}
								}
								foreach (Sprite o in ZS.OverworldManager.allsprites[0])
								{
									if (o.mapid == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent);
									}
								}
								foreach (Sprite o in ZS.OverworldManager.allsprites[1])
								{
									if (o.mapid == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent);
									}
								}
								foreach (Sprite o in ZS.OverworldManager.allsprites[2])
								{
									if (o.mapid == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent);
									}
								}
							}
						}
						else if (m >= 64 && m < 128)
						{
							int[] mtable = new int[8] { 0, 1, 8, 9, -64, -64 + 1, -64 + 8, -64 + 9 };

							for (int i = 0; i < 8; i++)
							{
								m = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent + mtable[i];

								foreach (EntranceOWEditor o in ZS.OverworldManager.allentrances)
								{
									if (o.mapId == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent);
									}
								}
								foreach (EntranceOWEditor o in ZS.OverworldManager.allholes)
								{
									if (o.mapId == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent);
									}
								}
								foreach (TransportOW o in ZS.OverworldManager.allBirds)
								{
									if (o.mapId == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent, ZS.OverworldManager);
									}
								}
								foreach (TransportOW o in ZS.OverworldManager.allWhirlpools)
								{
									if (o.mapId == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent, ZS.OverworldManager);
									}
								}
								foreach (ExitOW o in ZS.OverworldManager.allexits)
								{
									if (o.mapId == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent, ZS.OverworldManager);
									}
								}
								foreach (RoomPotSaveEditor o in ZS.OverworldManager.allitems)
								{
									if (o.roomMapId == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent);
									}
								}
								foreach (Sprite o in ZS.OverworldManager.allsprites[0])
								{
									if (o.mapid == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent);
									}
								}
								foreach (Sprite o in ZS.OverworldManager.allsprites[1])
								{
									if (o.mapid == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent);
									}
								}
								foreach (Sprite o in ZS.OverworldManager.allsprites[2])
								{
									if (o.mapid == m)
									{
										o.updateMapStuff(ZS.OverworldManager.allmaps[m].parent);
									}
								}
							}
						}
					}
				}
				else // Small maps
				{
					ZS.OverworldManager.allmaps[m].largeMap = false;
					ZS.OverworldManager.allmaps[m + 1].largeMap = false;
					ZS.OverworldManager.allmaps[m + 8].largeMap = false;
					ZS.OverworldManager.allmaps[m + 9].largeMap = false;

					ZS.OverworldManager.allmaps[m].parent = (byte) m;
					ZS.OverworldManager.allmaps[m + 1].parent = (byte) (m + 1);
					ZS.OverworldManager.allmaps[m + 8].parent = (byte) (m + 8);
					ZS.OverworldManager.allmaps[m + 9].parent = (byte) (m + 9);

					if (m < 64)
					{
						ZS.OverworldManager.allmaps[m + 64].largeMap = false;
						ZS.OverworldManager.allmaps[m + 64 + 1].largeMap = false;
						ZS.OverworldManager.allmaps[m + 64 + 8].largeMap = false;
						ZS.OverworldManager.allmaps[m + 64 + 9].largeMap = false;

						ZS.OverworldManager.allmaps[m + 64].parent = (byte) (m + 64);
						ZS.OverworldManager.allmaps[m + 64 + 1].parent = (byte) (m + 64 + 1);
						ZS.OverworldManager.allmaps[m + 64 + 8].parent = (byte) (m + 64 + 8);
						ZS.OverworldManager.allmaps[m + 64 + 9].parent = (byte) (m + 64 + 9);
					}
					else if (m >= 64 && m < 128)
					{
						ZS.OverworldManager.allmaps[m - 64].largeMap = false;
						ZS.OverworldManager.allmaps[m - 64 + 1].largeMap = false;
						ZS.OverworldManager.allmaps[m - 64 + 8].largeMap = false;
						ZS.OverworldManager.allmaps[m - 64 + 9].largeMap = false;

						ZS.OverworldManager.allmaps[m - 64].parent = (byte) (m - 64);
						ZS.OverworldManager.allmaps[m - 64 + 1].parent = (byte) (m - 64 + 1);
						ZS.OverworldManager.allmaps[m - 64 + 8].parent = (byte) (m - 64 + 8);
						ZS.OverworldManager.allmaps[m - 64 + 9].parent = (byte) (m - 64 + 9);
					}

					ZS.OverworldManager.getLargeMaps();

					if (m < 64)
					{
						int[] mtable = new int[2] { 0, 64 };

						for (int i = 0; i < 2; i++)
						{
							m = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent + mtable[i];

							int j = 0;
							// We are unchecking the large map box so all sprites on map00 are returning to other maps
							foreach (EntranceOWEditor o in ZS.OverworldManager.allentrances)
							{
								if (o.mapId == m)
								{
									if (o.AreaX < 32)
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index);
											j++;
										}
									}
									else
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index);
											j++;
										}
									}
								}
							}
							j = 0;
							foreach (EntranceOWEditor o in ZS.OverworldManager.allholes)
							{
								if (o.mapId == m)
								{
									if (o.AreaX < 32)
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index);
											j++;
										}
									}
									else
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index);
											j++;
										}
									}
								}
							}
							j = 0;
							foreach (TransportOW o in ZS.OverworldManager.allBirds)
							{
								if (o.mapId == m)
								{
									if (o.AreaX < 32)
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index, ZS.OverworldManager);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index, ZS.OverworldManager);
											j++;
										}
									}
									else
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index, ZS.OverworldManager);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index, ZS.OverworldManager);
											j++;
										}
									}
								}
							}
							j = 0;
							foreach (TransportOW o in ZS.OverworldManager.allWhirlpools)
							{
								if (o.mapId == m)
								{
									if (o.AreaX < 32)
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index, ZS.OverworldManager);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index, ZS.OverworldManager);
											j++;
										}
									}
									else
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index, ZS.OverworldManager);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index, ZS.OverworldManager);
											j++;
										}
									}
								}
							}
							j = 0;
							foreach (ExitOW o in ZS.OverworldManager.allexits)
							{
								if (o.mapId == m)
								{
									if (o.AreaX < 32)
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index, ZS.OverworldManager);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index, ZS.OverworldManager);
											j++;
										}
									}
									else
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index, ZS.OverworldManager);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index, ZS.OverworldManager);
											j++;
										}
									}
								}
							}
							j = 0;
							foreach (RoomPotSaveEditor o in ZS.OverworldManager.allitems)
							{
								if (o.roomMapId == m)
								{
									if (o.gameX < 32)
									{
										if (o.gameY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index);
											j++;
										}
									}
									else
									{
										if (o.gameY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index);
											j++;
										}
									}
								}
							}
							j = 0;
							foreach (Sprite o in ZS.OverworldManager.allsprites[0])
							{
								if (o.mapid == m)
								{
									if (o.x < 32)
									{
										if (o.y < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index);
											j++;
										}
									}
									else
									{
										if (o.y < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index);
											j++;
										}
									}
								}
							}
							j = 0;
							foreach (Sprite o in ZS.OverworldManager.allsprites[1])
							{
								if (o.mapid == m)
								{
									if (o.x < 32)
									{
										if (o.y < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index);
											j++;
										}
									}
									else
									{
										if (o.y < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index);
											j++;
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index);
											j++;
										}
									}
								}
							}
							j = 0;
							foreach (Sprite o in ZS.OverworldManager.allsprites[2])
							{
								if (o.mapid == m)
								{
									if (o.x < 32)
									{
										if (o.y < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index);
										}
									}
									else
									{
										if (o.y < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index);
										}
									}
									j++;
								}
							}
							j = 0;
						}
					}
					else if (m >= 64 && m < 128)
					{
						int[] mtable = new int[2] { 0, -64 };

						for (int i = 0; i < 2; i++)
						{
							m = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent + mtable[i];

							// We are unchecking the large map box so all sprites on map00 are returning to other maps.
							foreach (EntranceOWEditor o in ZS.OverworldManager.allentrances)
							{
								if (o.mapId == m)
								{
									if (o.AreaX < 32)
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index);
										}
									}
									else
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index);
										}
									}
								}
							}
							foreach (EntranceOWEditor o in ZS.OverworldManager.allholes)
							{
								if (o.mapId == m)
								{
									if (o.AreaX < 32)
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index);
										}
									}
									else
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index);
										}
									}
								}
							}
							foreach (TransportOW o in ZS.OverworldManager.allBirds)
							{
								if (o.mapId == m)
								{
									if (o.AreaX < 32)
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index, ZS.OverworldManager);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index, ZS.OverworldManager);
										}
									}
									else
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index, ZS.OverworldManager);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index, ZS.OverworldManager);
										}
									}
								}
							}
							foreach (TransportOW o in ZS.OverworldManager.allWhirlpools)
							{
								if (o.mapId == m)
								{
									if (o.AreaX < 32)
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index, ZS.OverworldManager);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index, ZS.OverworldManager);
										}
									}
									else
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index, ZS.OverworldManager);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index, ZS.OverworldManager);
										}
									}
								}
							}
							foreach (ExitOW o in ZS.OverworldManager.allexits)
							{
								if (o.mapId == m)
								{
									if (o.AreaX < 32)
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index, ZS.OverworldManager);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index, ZS.OverworldManager);
										}
									}
									else
									{
										if (o.AreaY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index, ZS.OverworldManager);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index, ZS.OverworldManager);
										}
									}
								}
							}
							foreach (RoomPotSaveEditor o in ZS.OverworldManager.allitems)
							{
								if (o.roomMapId == m)
								{
									if (o.gameX < 32)
									{
										if (o.gameY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index);
										}
									}
									else
									{
										if (o.gameY < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index);
										}
									}
								}
							}
							foreach (Sprite o in ZS.OverworldManager.allsprites[0])
							{
								if (o.mapid == m)
								{
									if (o.x < 32)
									{
										if (o.y < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index);
										}
									}
									else
									{
										if (o.y < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index);
										}
									}
								}
							}
							foreach (Sprite o in ZS.OverworldManager.allsprites[1])
							{
								if (o.mapid == m)
								{
									if (o.x < 32)
									{
										if (o.y < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index);
										}
									}
									else
									{
										if (o.y < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index);
										}
									}
								}
							}
							foreach (Sprite o in ZS.OverworldManager.allsprites[2])
							{
								if (o.mapid == m)
								{
									if (o.x < 32)
									{
										if (o.y < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 8].index);
										}
									}
									else
									{
										if (o.y < 32)
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 1].index);
										}
										else
										{
											o.updateMapStuff(ZS.OverworldManager.allmaps[m + 9].index);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Clears all overworld sprites of the selected stage (beginning, 1st, and 2nd phase)
		/// </summary>
		/// <param name="phase"></param>
		public void clearOverworldSprites(int phase)
		{
			ZS.OverworldManager.allsprites[phase].Clear();
		}

		/// <summary>
		/// Clears all overworld items
		/// </summary>
		public void clearOverworldItems()
		{
			ZS.OverworldManager.allitems.Clear();
		}

		/// <summary>
		/// Clears all overworld entrances
		/// </summary>
		public void clearOverworldEntrances()
		{
			foreach (EntranceOWEditor entrance in ZS.OverworldManager.allentrances)
			{
				entrance.x = NullEntrance;
				entrance.y = NullEntrance;
				entrance.mapId = 0;
				entrance.mapPos = NullEntrance;
				entrance.entranceId = 0;
				entrance.deleted = true;
			}
		}

		/// <summary>
		/// Clears all overworld entrances
		/// </summary>
		public void clearOverworldHoles()
		{
			foreach (var hole in ZS.OverworldManager.allholes)
			{
				hole.x = NullEntrance;
				hole.y = NullEntrance;
				hole.mapId = 0;
				hole.mapPos = NullEntrance;
				hole.entranceId = 0;
				hole.deleted = true;
			}
		}

		/// <summary>
		/// Clears all overworld exits
		/// </summary>
		public void clearOverworldExits()
		{
			foreach (var exit in ZS.OverworldManager.allexits)
			{
				exit.playerX = NullEntrance;
				exit.playerY = NullEntrance;
				exit.mapId = 0;
				exit.roomId = 0;
				exit.deleted = true;
			}
		}

		/// <summary>
		/// Clears all of the overworld overlays
		/// </summary>
		public void clearOverworldOverlays()
		{
			foreach (var overlay in ZS.OverworldManager.alloverlays)
			{
				overlay.tilesData.Clear();
			}
		}

		/// <summary>
		/// Clears all overworld sprites of the selected stage (beginning, 1st, and 2nd phase)
		/// </summary>
		/// <param name="phase"></param>
		public void clearAreaSprites(int phase)
		{
			ZS.OverworldManager.allsprites[phase].RemoveAll(o => o.mapid == ZS.OverworldScene.selectedMapParent);
		}

		/// <summary>
		/// Clears all of the selected area's items
		/// </summary>
		public void clearAreaItems()
		{
			ZS.OverworldManager.allitems.RemoveAll(o => o.roomMapId == ZS.OverworldScene.selectedMapParent);
		}

		/// <summary>
		/// Clears all the selected area's entrances
		/// </summary>
		public void clearAreaEntrances()
		{
			foreach (EntranceOWEditor entrance in ZS.OverworldManager.allentrances)
			{
				if (entrance.mapId == ZS.OverworldScene.selectedMapParent)
				{
					entrance.x = NullEntrance;
					entrance.y = NullEntrance;
					entrance.mapId = 0;
					entrance.mapPos = NullEntrance;
					entrance.entranceId = 0;
					entrance.deleted = true;
				}
			}
		}

		/// <summary>
		/// Clears all the slected area's entrances
		/// </summary>
		public void clearAreaHoles()
		{
			foreach (var hole in ZS.OverworldManager.allholes)
			{
				if (hole.mapId == ZS.OverworldScene.selectedMapParent)
				{
					hole.x = NullEntrance;
					hole.y = NullEntrance;
					hole.mapId = 0;
					hole.mapPos = NullEntrance;
					hole.entranceId = 0;
					hole.deleted = true;
				}
			}
		}

		/// <summary>
		/// Clears all of the selected area's exits
		/// </summary>
		public void clearAreaExits()
		{
			foreach (var exit in ZS.OverworldManager.allexits)
			{
				if (exit.mapId == ZS.OverworldScene.selectedMapParent)
				{
					exit.playerX = NullEntrance;
					exit.playerY = NullEntrance;
					exit.mapId = 0;
					exit.roomId = 0;
					exit.deleted = true;
				}
			}
		}

		/// <summary>
		/// Clears all of the selected area's overlays
		/// </summary>
		public void clearAreaOverlays()
		{
			ZS.OverworldManager.alloverlays[ZS.OverworldScene.selectedMapParent].tilesData.Clear();
			ZS.OverworldScene.Refresh();
		}

		/// <summary>
		/// Called when the area background color box is double cliked, brings up color editor.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AreaBGColorPicturebox_MouseDoubleClick(object sender, EventArgs e)
		{
			cd.Color = ZS.PaletteManager.OverworldBackground[BGColorToUpdate];
			if (cd.ShowDialog() == DialogResult.OK)
			{
				ZS.PaletteManager.OverworldBackground[BGColorToUpdate] = cd.Color;
				areaBGColorPictureBox.Refresh();
			}

			ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].ReloadPalettes();
		}

		/// <summary>
		/// Paints the Area Background color box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AreaBGColorPicturebox_Paint(object sender, PaintEventArgs e)
		{
			if (BGColorToUpdate < ZS.PaletteManager.OverworldBackground.Length)
			{
				e.Graphics.FillRectangle(new SolidBrush(ZS.PaletteManager.OverworldBackground[BGColorToUpdate]), Constants.Rect_0_0_24_24);
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
