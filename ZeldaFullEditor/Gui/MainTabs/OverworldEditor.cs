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
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor.Gui
{
	public partial class OverworldEditor : UserControl
	{
		// TODO move to Constants
		private const int NullEntrance = 0xFFFF;
		private const int ScratchPadSize = 225 * 16 * 2;


		public bool propertiesChangedFromForm = false;
		public Bitmap tmpPreviewBitmap = new Bitmap(256, 256);
		public Bitmap scratchPadBitmap = new Bitmap(256, 3600);
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

		private TabControl.TabPageCollection AuxTabs;

		readonly ColorDialog cd = new ColorDialog();
		public OverworldEditor()
		{
			InitializeComponent();
		}
		public void InitOpen()
		{
			//scene = new SceneOW(this, mainForm);
			ZScreamer.ActiveOWScene.Location = Constants.Point_0_0;
			ZScreamer.ActiveOWScene.Size = Constants.Size4096x4096;
			splitContainer1.Panel2.Controls.Clear();
			splitContainer1.Panel2.Controls.Add(ZScreamer.ActiveOWScene);
			ZScreamer.ActiveOWScene.CreateScene();
			ZScreamer.ActiveOWScene.initialized = true;
			ZScreamer.ActiveOWScene.Refresh();
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
			byte[] file = new byte[ScratchPadSize];

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

			ZScreamer.ActiveGraphicsManager.editort16Bitmap.Palette = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].gfxBitmap.Palette;
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
			ZScreamer.ActiveScreamer.CurrentOWMode = (OverworldEditMode) (sender as ToolStripButton).Tag;
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
				ZScreamer.ActiveOWScene.LastSelectedEntrance = null;
			}

			if (t != OWTabExitProps)
			{
				AuxTabs.Remove(OWTabExitProps);
			}
			else
			{
				ZScreamer.ActiveOWScene.LastSelectedExit = null;
			}

			if (t != OWTabTransportProps)
			{
				AuxTabs.Remove(OWTabTransportProps);
			}
			else
			{
				ZScreamer.ActiveOWScene.LastSelectedTransport = null;
			}

			if (t == null)
			{
				return;
			}

			AuxTabs.Add(t);
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
			ZScreamer.ActiveOW.GameState = (byte) stateCombobox.SelectedIndex;
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			Program.MainForm.saveToolStripMenuItem_Click(sender, e);
		}

		private void gfxTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!propertiesChangedFromForm)
			{
				OverworldMap mapParent = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].parent];

				if (ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].parent == 0xFF)
				{
					mapParent = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap];
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
					ZScreamer.ActiveOW.allmaps[mapParent.index].sprgfx[ZScreamer.ActiveOW.GameState] = (byte) OWProperty_SPRGFX.HexValue;
					mapParent.sprpalette[ZScreamer.ActiveOW.GameState] = (byte) OWProperty_SPRPalette.HexValue;
				}

				if (mapParent.largeMap)
				{
					ZScreamer.ActiveOW.allmaps[mapParent.index + 1].gfx = mapParent.gfx;
					ZScreamer.ActiveOW.allmaps[mapParent.index + 1].sprgfx = mapParent.sprgfx;
					ZScreamer.ActiveOW.allmaps[mapParent.index + 1].palette = mapParent.palette;
					ZScreamer.ActiveOW.allmaps[mapParent.index + 1].sprpalette = mapParent.sprpalette;

					ZScreamer.ActiveOW.allmaps[mapParent.index + 8].gfx = mapParent.gfx;
					ZScreamer.ActiveOW.allmaps[mapParent.index + 8].sprgfx = mapParent.sprgfx;
					ZScreamer.ActiveOW.allmaps[mapParent.index + 8].palette = mapParent.palette;
					ZScreamer.ActiveOW.allmaps[mapParent.index + 8].sprpalette = mapParent.sprpalette;

					ZScreamer.ActiveOW.allmaps[mapParent.index + 9].gfx = mapParent.gfx;
					ZScreamer.ActiveOW.allmaps[mapParent.index + 9].sprgfx = mapParent.sprgfx;
					ZScreamer.ActiveOW.allmaps[mapParent.index + 9].palette = mapParent.palette;
					ZScreamer.ActiveOW.allmaps[mapParent.index + 9].sprpalette = mapParent.sprpalette;

					mapParent.BuildMap();
					ZScreamer.ActiveOW.allmaps[mapParent.index + 1].BuildMap();
					ZScreamer.ActiveOW.allmaps[mapParent.index + 8].BuildMap();
					ZScreamer.ActiveOW.allmaps[mapParent.index + 9].BuildMap();
				}
				else
				{
					mapParent.BuildMap();
				}

				//scene.updateMapGfx();
				ZScreamer.ActiveOWScene.Invalidate();
				//scene.Refresh();
			}
		}

		private static readonly RectangleF TileRect = new RectangleF(128, 3408, 128, 688);
		private void tilePictureBox_Paint(object sender, PaintEventArgs e)
		{
			if (ZScreamer.ActiveGraphicsManager.mapblockset16Bitmap != null)
			{
				e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
				e.Graphics.CompositingMode = CompositingMode.SourceOver;
				e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.mapblockset16Bitmap,
					Constants.Rect_0_0_128_4096,
					Constants.Rect_0_0_128_4096,
					GraphicsUnit.Pixel);
				e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.mapblockset16Bitmap,
					Constants.Rect_128_0_128_4096,
					Constants.Rect_0_4096_128_4096,
					GraphicsUnit.Pixel);

				if (ZScreamer.ActiveOWScene.selectedTile.Length > 0)
				{
					int x = ZScreamer.ActiveOWScene.selectedTile[0] % 8 * 16;
					int y = ZScreamer.ActiveOWScene.selectedTile[0] / 8 * 16;

					if (ZScreamer.ActiveOWScene.selectedTile[0] >= 2048)
					{
						y -= 4096;
						x += 128;
					}

					// TODO copy
					e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(x, y, 16, 16));
					selectedTileLabel.Text = "Selected tile: " + ZScreamer.ActiveOWScene.selectedTile[0].ToString("X4");
				}

				e.Graphics.FillRectangle(Brushes.Black, TileRect);
			}
		}

		private void tilePictureBox_MouseClick(object sender, MouseEventArgs e)
		{
			ZScreamer.ActiveOWScene.selectedTileSizeX = 1;
			if (e.X > 128)
			{
				ZScreamer.ActiveOWScene.selectedTile = new ushort[1] { (ushort) (((e.X - 128) / 16) + (e.Y / 16 * 8) + 2048) };
				if (ZScreamer.ActiveOWScene.selectedTile[0] > 3751)
				{
					ZScreamer.ActiveOWScene.selectedTile[0] = 3751;
				}
			}
			else
			{
				ZScreamer.ActiveOWScene.selectedTile = new ushort[1] { (ushort) ((e.X / 16) + (e.Y / 16 * 8)) };
			}

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
			ZScreamer.ActiveOWScene.CurrentMap = (int) o;
			ZScreamer.ActiveOWScene.CurrentMapParent = ZScreamer.ActiveOW.allmaps[(int) o].parent;
			ZScreamer.ActiveOWScene.Refresh();
		}


		private void runtestButton_Click(object sender, EventArgs e)
		{
			Program.MainForm.runtestButton_Click(sender, e);
		}

		private void tilePictureBox_DoubleClick(object sender, EventArgs e)
		{
			Tile16Editor ted = new Tile16Editor();
			if (ted.ShowDialog() == DialogResult.OK)
			{
				new Thread(() =>
				{
					Thread.CurrentThread.IsBackground = true;
					for (int i = 0; i < 159; i++)
					{
						if (ZScreamer.ActiveOW.allmaps[i].NeedsRefresh)
						{
							ZScreamer.ActiveOW.allmaps[i].BuildMap();
							ZScreamer.ActiveOW.allmaps[i].NeedsRefresh = false;
						}
					}
				}).Start();
			}
		}

		private void undoButton_Click(object sender, EventArgs e)
		{
			Program.MainForm.undoButton_Click(sender, e);
		}

		private void redoButton_Click(object sender, EventArgs e)
		{
			Program.MainForm.redoButton_Click(sender, e);
		}

		private void refreshToolStrip_Click(object sender, EventArgs e)
		{
			new Thread(() =>
			{
				Thread.CurrentThread.IsBackground = true;
				for (int i = 0; i < 159; i++)
				{
					if (ZScreamer.ActiveOW.allmaps[i].NeedsRefresh)
					{
						ZScreamer.ActiveOW.allmaps[i].BuildMap();
						ZScreamer.ActiveOW.allmaps[i].NeedsRefresh = false;
					}
				}
			}).Start();
		}

		private void musicButton_Click(object sender, EventArgs e)
		{
			OWMusicForm owmf = new OWMusicForm
			{
				mapIndex = (byte) ZScreamer.ActiveOWScene.CurrentMap
			};
			owmf.musics[0] = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].musics[0];
			owmf.musics[1] = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].musics[1];
			owmf.musics[2] = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].musics[2];
			owmf.musics[3] = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].musics[3];

			if (owmf.ShowDialog() == DialogResult.OK)
			{
				ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].musics[0] = owmf.musics[0];
				ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].musics[1] = owmf.musics[1];
				ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].musics[2] = owmf.musics[2];
				ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].musics[3] = owmf.musics[3];
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveScreamer.SetSelectedMessageID(OWProperty_MessageID.HexValue);
			ZScreamer.ActiveScreamer.SelectTab(TabSelection.TextEditor);
		}

		private void previewTextPicturebox_Paint(object sender, PaintEventArgs e)
		{
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
					cp.Entries[i] = ZScreamer.ActiveGraphicsManager.roomBg1Bitmap.Palette.Entries[(defaultColor * 4) + i];
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
			globalmouseTileDownX = e.X / 16;
			globalmouseTileDownY = e.Y / 16;

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
				int tileX = e.X / 16;
				int tileY = e.Y / 16;

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
			if (ZScreamer.ActiveOWScene.initialized)
			{
				mouseX_Real = e.X;
				mouseY_Real = e.Y;
				int mouseTileX = e.X / 16;
				int mouseTileY = e.Y / 16;

				if (lastTileHoverX != mouseTileX || lastTileHoverY != mouseTileY)
				{
					if (MouseIsDown)
					{
						if (e.Button == MouseButtons.Left)
						{
							int tileX = e.X / 16;
							int tileY = e.Y / 16;
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
		}

		private void scratchPicturebox_Paint(object sender, PaintEventArgs e)
		{
			if (ZScreamer.ActiveGraphicsManager.mapblockset16Bitmap != null)
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

				g.DrawImage(ZScreamer.ActiveGraphicsManager.scratchblockset16Bitmap, 0, 0);

				// DRAW ALL THE TILES 16x225

				g.CompositingMode = CompositingMode.SourceOver;

				if (selecting)
				{
					g.DrawRectangle(Pens.White, new Rectangle(globalmouseTileDownX * 16, globalmouseTileDownY * 16, (((mouseX_Real / 16) - globalmouseTileDownX) * 16) + 16, (((mouseY_Real / 16) - globalmouseTileDownY) * 16) + 16));
				}

				Rectangle r = new Rectangle(mouseX_Real & ~0xF, mouseY_Real & ~0xF, ZScreamer.ActiveOWScene.selectedTileSizeX * 16, ZScreamer.ActiveOWScene.selectedTile.Length / ZScreamer.ActiveOWScene.selectedTileSizeX * 16);

				g.DrawImage(ZScreamer.ActiveOWScene.tilesgfxBitmap, r, 0, 0, ZScreamer.ActiveOWScene.selectedTileSizeX * 16, ZScreamer.ActiveOWScene.selectedTile.Length / ZScreamer.ActiveOWScene.selectedTileSizeX * 16, GraphicsUnit.Pixel, ia);
				g.DrawRectangle(Pens.LightGreen, r);
				//g.DrawImage(ZScreamer.ActiveOWScene.tilesgfxBitmap, r, 0, 0, ZScreamer.ActiveOWScene.selectedTileSizeX * 16, (ZScreamer.ActiveOWScene.selectedTile.Length / ZScreamer.ActiveOWScene.selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
				//g.DrawRectangle(Pens.LightGreen, r);

				g.CompositingMode = CompositingMode.SourceCopy;
				//hideText = false;
			}
		}

		public unsafe void BuildScratchTilesGfx()
		{
			ZScreamer.ActiveGraphicsManager.scratchblockset16Bitmap.Palette = ZScreamer.ActiveGraphicsManager.mapblockset16Bitmap.Palette;
			var gfx16Data = (byte*) ZScreamer.ActiveGraphicsManager.mapblockset16.ToPointer(); //(byte*)allgfx8Ptr.ToPointer();
			var gfx16DataScratch = (byte*) ZScreamer.ActiveGraphicsManager.scratchblockset16.ToPointer(); //(byte*)allgfx16Ptr.ToPointer();
			int ytile = 0;
			int xtile = 0;

			for (var i = 0; i < 3500; i++)
			{
				ushort srcTile = scratchPadTiles[xtile, ytile];
				//Console.WriteLine(srcTile);
				int srcTileY = srcTile / 8;
				int srcTileX = srcTile - (srcTileY * 8);
				int tPos = (xtile * 16) + (ytile * 4096);
				int srctPos = (srcTileX * 16) + (srcTileY * 2048);

				for (int y = 0; y < 16; y++)
				{
					for (int x = 0; x < 16; x++)
					{
						gfx16DataScratch[tPos + x + (y * 256)] = gfx16Data[srctPos + x + (y * 128)];
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
			//e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.currentOWgfx16Bitmap,new Rectangle(0,0,512,1024), new Rectangle(0,0,256,512),GraphicsUnit.Pixel);

			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
			e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.editort16Bitmap, Constants.Rect_0_0_256_1024);

			int y = tile8selected / 16;
			int x = tile8selected & 0xF;

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
			byte* destPtr = (byte*) ZScreamer.ActiveGraphicsManager.editingtile16.ToPointer();
			byte* srcPtr = (byte*) ZScreamer.ActiveGraphicsManager.currentOWgfx16Ptr.ToPointer();
			Tile16 t = ZScreamer.ActiveOW.Tile16List[ZScreamer.ActiveOWScene.selectedTile[0]];

			for (int y = 0; y < 8; y++)
			{
				for (int x = 0; x < 4; x++)
				{
					CopyTile(x, y, 0, 0, t.Tile0.ID, p, destPtr, srcPtr, 16);
					CopyTile(x, y, 8, 0, t.Tile1.ID, p, destPtr, srcPtr, 16);
					CopyTile(x, y, 0, 8, t.Tile2.ID, p, destPtr, srcPtr, 16);
					CopyTile(x, y, 8, 8, t.Tile3.ID, p, destPtr, srcPtr, 16);
				}
			}

			//Bitmap b = new Bitmap(128, 512, 64, System.Drawing.Imaging.PixelFormat.Format4bppIndexed, ZScreamer.ActiveGraphicsManager.currentOWgfx16Ptr);
			ZScreamer.ActiveGraphicsManager.editort16Bitmap.Palette = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].gfxBitmap.Palette;
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
			ZScreamer.ActiveGraphicsManager.editort16Bitmap.Palette = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].gfxBitmap.Palette;
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
				Color c = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].gfxBitmap.Palette.Entries[i];
				e.Graphics.FillRectangle(new SolidBrush(c), new Rectangle(i % 16 * 16, i / 16 * 16, 16, 16));
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
						alltilesIndexed[ZScreamer.ActiveOW.allmapsTilesLW[x + (sx * 32), y + (sy * 32)]]++;
						alltilesIndexed[ZScreamer.ActiveOW.allmapsTilesDW[x + (sx * 32), y + (sy * 32)]]++;

						if (i < 32)
						{
							alltilesIndexed[ZScreamer.ActiveOW.allmapsTilesSP[x + (sx * 32), y + (sy * 32)]]++;
						}
					}
				}

				foreach (OverlayTile t in ZScreamer.ActiveOW.alloverlays[i].tilesData)
				{
					alltilesIndexed[t.Map16Value]++;
				}

				foreach (OverlayTile t in ZScreamer.ActiveOW.alloverlays[i + 64].tilesData)
				{
					alltilesIndexed[t.Map16Value]++;
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
				OverworldMap mapParent = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].parent];

				if (ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].parent == 255)
				{
					mapParent = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap];
				}

				mapParent.messageID = (ushort) OWProperty_MessageID.HexValue;

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
					ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].tilesUsed[x, y] = 0052;

					//overworld.allmapsTilesLW[x, y] = 0052;
				}
			}

			ZScreamer.ActiveOWScene.Refresh();
		}

		private void tilePictureBox_MouseEnter(object sender, EventArgs e)
		{
			ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].BuildMap();
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
			e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.editingtile16Bitmap, Constants.Rect_0_0_64_64);
		}


		private void UpdateEntireListForBigMap(IEnumerable<OverworldEntity> l, int map) 
		{
			foreach (var o in l)
			{
				if (o.MapID != map) continue;
				
				if (o.MapX < 32)
				{
					if (o.MapY < 32)
					{
						o.MapID = ZScreamer.ActiveOW.allmaps[o.MapID].index;
					}
					else
					{
						o.MapID = ZScreamer.ActiveOW.allmaps[o.MapID + 8].index;
					}
				}
				else
				{
					if (o.MapY < 32)
					{
						o.MapID = ZScreamer.ActiveOW.allmaps[o.MapID + 1].index;
					}
					else
					{
						o.MapID = ZScreamer.ActiveOW.allmaps[o.MapID + 9].index;
					}
				}

				if (o is OverworldDestination d)
				{
					d.UpdateMapProperties(ZScreamer.ActiveOW.allmaps[o.MapID].largeMap);
				}
				
			}
		}


		/// <summary>
		/// Updates world layout and sprites within the respective maps
		/// </summary>
		private void largemapCheckbox_Clicked(object sender, EventArgs e)
		{
			if (propertiesChangedFromForm) return;

			byte sel = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].parent;

			// Prevent big maps on the edges
			if (((sel & 0x3F) > 0x37) || sel.BitsAllSet(0x07))
			{
				UIText.GeneralWarning("Maps on the edge of the screen cannot be made the origin of a large map.");

				largemapCheckbox.Checked = false;
				return;
			}

			// Search for adjacent maps already being large
			bool big1 = ZScreamer.ActiveOW.allmaps[sel + 1].largeMap;
			bool big2 = ZScreamer.ActiveOW.allmaps[sel + 8].largeMap;
			bool big3 = ZScreamer.ActiveOW.allmaps[sel + 9].largeMap;

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

			bool big = largemapCheckbox.Checked;
			byte sel2 = (byte) (sel ^ 64);
			byte par1 = sel;
			byte par2, par3, par4;

			ZScreamer.ActiveOW.allmaps[sel].largeMap = big;
			ZScreamer.ActiveOW.allmaps[sel + 1].largeMap = big;
			ZScreamer.ActiveOW.allmaps[sel + 8].largeMap = big;
			ZScreamer.ActiveOW.allmaps[sel + 9].largeMap = big;

			ZScreamer.ActiveOW.allmaps[sel2].largeMap = big;
			ZScreamer.ActiveOW.allmaps[sel2 + 1].largeMap = big;
			ZScreamer.ActiveOW.allmaps[sel2 + 8].largeMap = big;
			ZScreamer.ActiveOW.allmaps[sel2 + 9].largeMap = big;

			int[] modthese;
			byte par = ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].parent;

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

			ZScreamer.ActiveOW.allmaps[sel].parent = par1;
			ZScreamer.ActiveOW.allmaps[sel + 1].parent = par2;
			ZScreamer.ActiveOW.allmaps[sel + 8].parent = par3;
			ZScreamer.ActiveOW.allmaps[sel + 9].parent = par4;

			par1 ^= 64;
			par2 ^= 64;
			par3 ^= 64;
			par4 ^= 64;

			ZScreamer.ActiveOW.allmaps[sel2].parent = par1;
			ZScreamer.ActiveOW.allmaps[sel2 + 1].parent = par2;
			ZScreamer.ActiveOW.allmaps[sel2 + 8].parent = par3;
			ZScreamer.ActiveOW.allmaps[sel2 + 9].parent = par4;

			foreach (int m in modthese)
			{
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allentrances, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allholes, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allitems, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allBirds, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.AllTransports, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allexits, m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allsprites[0], m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allsprites[1], m);
				UpdateEntireListForBigMap(ZScreamer.ActiveOW.allsprites[2], m);
			}
		}

		/// <summary>
		/// Clears all overworld sprites of the selected stage (beginning, 1st, and 2nd phase)
		/// </summary>
		public void clearOverworldSprites(int phase)
		{
			ZScreamer.ActiveOW.allsprites[phase].Clear();
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
				entrance.deleted = true;
			}
		}

		/// <summary>
		/// Clears all overworld entrances
		/// </summary>
		public void clearOverworldHoles()
		{
			foreach (var hole in ZScreamer.ActiveOW.allholes)
			{
				hole.deleted = true;
			}
		}

		/// <summary>
		/// Clears all overworld exits
		/// </summary>
		public void clearOverworldExits()
		{
			foreach (var exit in ZScreamer.ActiveOW.allexits)
			{
				exit.Deleted = true;
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
			new Predicate<OverworldEntity>(o => o.MapID == ZScreamer.ActiveOWScene.CurrentMapParent);

		/// <summary>
		/// Clears all overworld sprites of the selected stage (beginning, 1st, and 2nd phase)
		/// </summary>
		/// <param name="phase"></param>
		public void clearAreaSprites(int phase)
		{
			ZScreamer.ActiveOW.allsprites[phase].RemoveAll(removeFromMap);
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
			foreach (OverworldEntrance entrance in ZScreamer.ActiveOW.allentrances)
			{
				if (entrance.MapID == ZScreamer.ActiveOWScene.CurrentMapParent)
				{
					entrance.GlobalX = NullEntrance;
					entrance.GlobalY = NullEntrance;
					entrance.MapID = 0;
					entrance.mapPos = NullEntrance;
					entrance.TargetEntranceID = 0;
					entrance.deleted = true;
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
				if (hole.MapID == ZScreamer.ActiveOWScene.CurrentMapParent)
				{
					hole.GlobalX = NullEntrance;
					hole.GlobalY = NullEntrance;
					hole.MapID = 0;
					hole.mapPos = NullEntrance;
					hole.TargetEntranceID = 0;
					hole.deleted = true;
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
				if (exit.MapID == ZScreamer.ActiveOWScene.CurrentMapParent)
				{
					exit.GlobalX = NullEntrance;
					exit.GlobalY = NullEntrance;
					exit.MapID = 0;
					exit.TargetRoomID = 0;
					exit.Deleted = true;
				}
			}
		}

		/// <summary>
		/// Clears all of the selected area's overlays
		/// </summary>
		public void clearAreaOverlays()
		{
			ZScreamer.ActiveOW.alloverlays[ZScreamer.ActiveOWScene.CurrentMapParent].tilesData.Clear();
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

			ZScreamer.ActiveOW.allmaps[ZScreamer.ActiveOWScene.CurrentMap].ReloadPalettes();
		}

		private void AreaBGColorPicturebox_Paint(object sender, PaintEventArgs e)
		{
			if (BGColorToUpdate < ZScreamer.ActivePaletteManager.OverworldBackground.Length)
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
