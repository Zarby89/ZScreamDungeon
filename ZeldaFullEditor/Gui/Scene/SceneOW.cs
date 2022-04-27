using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using ZeldaFullEditor.SceneModes;
using ZeldaFullEditor.Gui;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor
{
	public partial class SceneOW : Scene
	{
		//public IntPtr allgfx8array = Marshal.AllocHGlobal(32768);

		//int selectedIndex = 0;
		public int selectedMap = 0;
		public int selectedMapParent = 0;
		//public int lockedMap = -1;
		//must load all current map gfx
		public bool initialized = false;
		public bool needRedraw = true;
		public ushort[] selectedTile = new ushort[] { 0 };
		public int selectedTileSizeX = 1;
		public int globalmouseTileDownX = 0;
		public int globalmouseTileDownY = 0;
		public int mouseX_Real = 0;
		public int mouseY_Real = 0;
		public int lastTileHoverX = 0;
		public int lastTileHoverY = 0;
		public int mapHover = 0;
		public int lastHover = -1;
		public bool selecting = false;
		public IntPtr overlaygfxPtr = Marshal.AllocHGlobal(1024 * 1024);
		public IntPtr temptilesgfxPtr = Marshal.AllocHGlobal(1024 * 1024);
		public Bitmap tilesgfxBitmap;
		public Bitmap tileBitmap;
		public IntPtr tileBitmapPtr;
		public bool snapToGrid = true;
		public OverworldSprite selectedFormSprite;

		private readonly ModeActions tilemode;
		private readonly ModeActions exitmode;
		private readonly ModeActions doorMode;
		private readonly ModeActions entranceMode;
		private readonly ModeActions spriteMode;
		private readonly ModeActions itemMode;
		private readonly ModeActions transportMode;
		private readonly ModeActions overlayMode;
		private readonly ModeActions gravestoneMode;

		public bool showEntrances = true;
		public bool showExits = true;
		public bool showFlute = true;
		public bool showItems = true;
		public bool showSprites = true;
		public bool hideText = false;
		public bool entrancePreview = false;

		public bool lowEndMode = false;
		internal bool mouse_down;

		// TODO move Overworld ow to ZScreamer
		public SceneOW(ZScreamer zs) : base(zs)
		{
			//graphics = Graphics.FromImage(scene_bitmap);
			//this.Image = new Bitmap(4096, 4096);
			tilesgfxBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, temptilesgfxPtr);


			tilemode = new ModeActions(OnMouseDown_Tiles, OnMouseUp_Tiles, OnMouseMove_Tiles, null,
				Copy_Tiles, Paste_Tiles, null, Delete_Tiles, null);

			exitmode = new ModeActions(OnMouseDown_Exit, OnMouseUp_Exit, OnMouseMove_Exit, null,
				Copy_Exit, Paste_Exit, null, Delete_Exit, null);

			doorMode = new ModeActions(OnMouseDown_OWDoor, OnMouseUp_OWDoor, OnMouseMove_OWDoor, null,
				Copy_OWDoor, Paste_OWDoor, null, Delete_OWDoor, SelectAll_OWDoor);

			entranceMode = new ModeActions(OnMouseDown_Entrance, OnMouseUp_Entrance, OnMouseMove_Entrance, null,
				Copy_Entrance, Paste_Entrance, null, Delete_Entrance, null);

			spriteMode = new ModeActions(OnMouseDown_Sprites, OnMouseUp_Sprites, OnMouseMove_Sprites, null,
				Copy_Sprites, Paste_Sprites, null, Delete_Sprites, SelectAll_Sprites);

			itemMode = new ModeActions(OnMouseDown_Secrets, OnMouseUp_Secrets, OnMouseMove_Secrets, null,
				Copy_Secrets, Paste_Secrets, null, Delete_Secrets, null);

			transportMode = new ModeActions(OnMouseDown_Transports, OnMouseUp_Transports, OnMouseMove_Transports, null,
				null, null, null, null, null);

			overlayMode = new ModeActions(OnMouseDown_Overlay, OnMouseUp_Overlay, OnMouseMove_Overlay, null,
				Copy_Overlay, Paste_Overlay, null, Delete_Overlay, null);

			gravestoneMode = new ModeActions(OnMouseDown_Graves, OnMouseUp_Graves, OnMouseMove_Graves, null,
				null, null, null, Delete_Graves, null);

			//this.Width = 8192;
			//this.Height = 8192;
			//this.Size = new Size(8192, 8192);
			//this.Refresh();
		}

		public void UpdateForMode(OverworldEditMode e)
		{
			switch (e)
			{
				case OverworldEditMode.Tile16:
					ActiveMode = tilemode;
					break;

				case OverworldEditMode.Sprites:
					ActiveMode = spriteMode;
					break;

				case OverworldEditMode.Secrets:
					ActiveMode = itemMode;
					break;

				case OverworldEditMode.Entrances:
					ActiveMode = entranceMode;
					break;

				case OverworldEditMode.Exits:
					ActiveMode = exitmode;
					break;

				case OverworldEditMode.Transports:
					ActiveMode = transportMode;
					break;

				case OverworldEditMode.Overlay:
					ActiveMode = overlayMode;
					break;

				case OverworldEditMode.Gravestones:
					ActiveMode = gravestoneMode;
					break;

				case OverworldEditMode.Doors:
					ActiveMode = doorMode;
					break;
			}
		}


		public void CreateScene()
		{
			//tileBitmapPtr = ZS.OverworldManager.allmaps[0].blockset16;
			//tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, tileBitmapPtr);
		}

		protected override void OnMouseWheel(object sender, MouseEventArgs e)
		{
			((HandledMouseEventArgs) e).Handled = true;
			int xPos = Program.OverworldForm.splitContainer1.Panel2.HorizontalScroll.Value;
			int yPos = Program.OverworldForm.splitContainer1.Panel2.VerticalScroll.Value;

			if (ModifierKeys == Keys.Shift)
			{
				e.ScrollByValue(ref xPos, 48);
			}
			else
			{
				e.ScrollByValue(ref yPos, 48);
			}

			Program.OverworldForm.splitContainer1.Panel2.AutoScrollPosition = new Point(xPos, yPos);
			//e.Delta
			//base.OnMouseWheel(sender, e);
		}

		public void updateMapGfx()
		{
			if (selectedMap + ZS.OverworldManager.worldOffset <= 159)
			{
				Program.OverworldForm.propertiesChangedFromForm = true;
				OverworldMap map = ZS.OverworldManager.allmaps[selectedMap + ZS.OverworldManager.worldOffset];

				if (map.needRefresh)
				{
					map.BuildMap();
					map.needRefresh = false;
				}

				Program.OverworldForm.mapGroupbox.Text = string.Format(
					Program.MainForm.showMapIndexInHexToolStripMenuItem.Checked ? "Selected map: {0}" : "Selected map: {0}",
					map.parent
					);

				Program.OverworldForm.OWProperty_MessageID.HexValue = ZS.OverworldManager.allmaps[map.parent].messageID;

				Program.OverworldForm.UpdateGUIProperties(ZS.OverworldManager.allmaps[map.parent], ZS.OverworldManager.worldOffset >= 64 ? 0 : ZS.OverworldManager.gameState);

				Program.OverworldForm.propertiesChangedFromForm = false;
				Program.OverworldForm.tilePictureBox.Refresh();

				Program.OverworldForm.areaBGColorPictureBox.Refresh();
			}

			Program.OverworldForm.BuildScratchTilesGfx();
			Program.OverworldForm.scratchPicturebox.Refresh();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			int tileX = e.X / 16;
			int tileY = e.Y / 16;
			int mapId = (tileY / 32 * 8) + (tileX / 32);

			if (mapId + ZS.OverworldManager.worldOffset < ZS.OverworldManager.allmaps.Length)
			{
				globalmouseTileDownX = tileX;
				globalmouseTileDownY = tileY;

				Program.MainForm.anychange = true;
				selectedMap = mapId;

				selectedMapParent = ZS.OverworldManager.allmaps[selectedMap + ZS.OverworldManager.worldOffset].parent;

				Program.OverworldForm.previewTextPicturebox.Visible = false;
				updateMapGfx();
				Program.OverworldForm.updateTiles();

				base.OnMouseDown(e);

				InvalidateHighEnd();
			}
			else
			{
				// TODO messagebox for failure "Invalid area selected"
			}
		}

		public void SetSelectedExit(ExitOW e)
		{
			Program.OverworldForm.SetSelectedExit(e);
			lastselectedExit = e;
		}

		public void SetSelectedExitSilently(ExitOW e)
		{
			lastselectedExit = e;
		}

		public void SetSelectedEntrance(EntranceOWEditor e)
		{
			Program.OverworldForm.SetSelectedEntrance(e);
			lastselectedEntrance = e;
		}

		public void SetSelectedEntranceSilently(EntranceOWEditor e)
		{
			lastselectedEntrance = e;
		}

		public void SetSelectedTransport(TransportOW e)
		{
			Program.OverworldForm.SetSelectedTransport(e);
			lastselectedTransport = e;
		}

		public void SetSelectedTransportSilently(TransportOW e)
		{
			lastselectedTransport = e;
		}

		protected override void OnMouseUp(object sender, MouseEventArgs e)
		{
			Program.OverworldForm.objCombobox.Items.Clear();
			Program.OverworldForm.objCombobox.SelectedIndexChanged -= ObjCombobox_SelectedIndexChangedSprite;
			Program.OverworldForm.objCombobox.SelectedIndexChanged -= ObjCombobox_SelectedIndexChangedItem;
			string text = "Selected object: ";

			base.OnMouseUp(sender, e);
			switch (ZS.CurrentOWMode) {
				// TODO tab for items
				case OverworldEditMode.Secrets:
					text += "Item";

					if (lastselectedItem != null)
					{
						Program.OverworldForm.SetSelectedObjectLabels(
							lastselectedItem.ID,
							lastselectedItem.GridX,
							lastselectedItem.GridY);

						Program.OverworldForm.objCombobox.DataSource = DefaultEntities.ListOfSecrets;

						// TODO
						//Program.OverworldForm.objCombobox.SelectedItem = 

						Program.OverworldForm.objCombobox.SelectedIndexChanged += ObjCombobox_SelectedIndexChangedItem;
					}
					break;

				// TODO tab for sprites
				case OverworldEditMode.Sprites:
					text += "Sprite";

					if (lastselectedSprite != null)
					{
						Program.OverworldForm.SetSelectedObjectLabels(
							lastselectedSprite.ID,
							lastselectedSprite.GridX,
							lastselectedSprite.GridY);
						Program.OverworldForm.objCombobox.DataSource = DefaultEntities.ListOfTileTypes;
						Program.OverworldForm.objCombobox.SelectedIndex = lastselectedSprite.ID;

						Program.OverworldForm.objCombobox.SelectedIndexChanged += ObjCombobox_SelectedIndexChangedSprite;
					}
					break;
			}
			Program.OverworldForm.objectGroupbox.Text = text;
			InvalidateHighEnd();
		}


		private void ObjCombobox_SelectedIndexChangedSprite(object sender, EventArgs e)
		{
			byte id = (byte) (Program.OverworldForm.objCombobox.SelectedItem as SpriteName).ID;
			lastselectedSprite.Species = SpriteType.GetSpriteType(id);

			InvalidateHighEnd();
		}

		private void InvalidateHighEnd()
		{
			if (lowEndMode)
			{
				int x = 512 * (ZS.OverworldManager.allmaps[selectedMap].parent % 8);
				int y = 512 * (ZS.OverworldManager.allmaps[selectedMap].parent / 8);
				if (ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[selectedMap].parent].largeMap)
				{
					Invalidate(new Rectangle(x, y, 1024, 1024));
				}
				else
				{
					Invalidate(new Rectangle(x, y, 512, 512));
				}
			}
			else
			{
				Invalidate(new Rectangle(
					Program.OverworldForm.splitContainer1.Panel2.HorizontalScroll.Value,
					Program.OverworldForm.splitContainer1.Panel2.VerticalScroll.Value,
					Program.OverworldForm.splitContainer1.Panel2.Width,
					Program.OverworldForm.splitContainer1.Panel2.Height
				));
			}
		}

		private void ObjCombobox_SelectedIndexChangedItem(object sender, EventArgs e)
		{
			byte id = (byte) (Program.OverworldForm.objCombobox.SelectedItem as SecretsName).ID;
			lastselectedItem.SecretType = SecretItemType.FindSecretFromID(id);
			InvalidateHighEnd();
		}

		protected override void OnMouseMove(object sender, MouseEventArgs e)
		{
			base.OnMouseMove(sender, e);
		}

		public override void Undo()
		{
			//tilemode.Undo();
			RequestRefresh();
		}

		public override void Redo()
		{
			//tilemode.Redo();
			RequestRefresh();
		}

		public override void SelectAll()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates a map32 tile map and saves the overworld tiles in the rom. 
		/// </summary>
		public void SaveTiles()
		{
			ZS.OverworldManager.createMap32Tilesmap()
			ZS.OverworldManager.SaveMap32DefinitionsToROM();
			//ZS.OverworldManager.savemapstorom();
			ZS.OverworldManager.SaveMap16DefinitionsToROM();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			Graphics g = e.Graphics;

			ColorMatrix cm = new ColorMatrix();
			ImageAttributes ia = new ImageAttributes();
			cm.Matrix33 = 0.50f;
			cm.Matrix22 = 2f;
			ia.SetColorMatrix(cm);
			g.CompositingMode = CompositingMode.SourceCopy;
			g.CompositingQuality = CompositingQuality.HighSpeed;
			g.InterpolationMode = InterpolationMode.NearestNeighbor;

			if (initialized)
			{
				if (lowEndMode)
				{
					int x = ZS.OverworldManager.allmaps[selectedMap].parent % 8;
					int y = ZS.OverworldManager.allmaps[selectedMap].parent / 8;

					if (ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[selectedMap].parent].largeMap)
					{
						g.FillRectangle(new SolidBrush(ZS.PaletteManager.OverworldGrass[0]), new RectangleF(x * 512, y * 512, 1024, 1024));
						g.DrawImage(ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[selectedMap].parent].gfxBitmap, new PointF(x * 512, y * 512));
						g.DrawImage(ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[selectedMap].parent + 1].gfxBitmap, new PointF((x + 1) * 512, y * 512));
						g.DrawImage(ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[selectedMap].parent + 8].gfxBitmap, new PointF((x) * 512, (y + 1) * 512));
						g.DrawImage(ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[selectedMap].parent + 9].gfxBitmap, new PointF((x + 1) * 512, (y + 1) * 512));
					}
					else
					{
						g.FillRectangle(new SolidBrush(ZS.PaletteManager.OverworldGrass[0]), new RectangleF(x * 512, y * 512, 512, 512));
						g.DrawImage(ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[selectedMap].parent].gfxBitmap, new PointF(x * 512, y * 512));
					}
				}
				else
				{
					if (ZS.OverworldManager.worldOffset == 64)
					{
						g.Clear(ZS.PaletteManager.OverworldGrass[1]);
					}
					else if (ZS.OverworldManager.worldOffset == 128)
					{
						g.Clear(ZS.PaletteManager.OverworldGrass[2]);
					}
					else
					{
						g.Clear(ZS.PaletteManager.OverworldGrass[0]);
					}

					// TODO make a single PointF and Rectangle variable to reuse
					int x = 0;
					int y = 0;
					for (int i = (0 + ZS.OverworldManager.worldOffset); i < 64 + (ZS.OverworldManager.worldOffset); i++)
					{
						if (i <= 159)
						{
							if (Program.MainForm.overworldOverlayVisibleToolStripMenuItem.Checked)
							{
								if ((i >= 0x03) && (i <= 0x07))
								{
									g.CompositingMode = CompositingMode.SourceOver;
									g.DrawImage(ZS.OverworldManager.allmaps[149].gfxBitmap, new PointF(x, y));
								}
								else if (i == 91 || i == 92)
								{
									g.CompositingMode = CompositingMode.SourceOver;
									g.DrawImage(ZS.OverworldManager.allmaps[150].gfxBitmap, new PointF(x, y));
								}
							}
							else
							{
								if (i < 64)
								{
									g.CompositingMode = CompositingMode.SourceOver;
									g.DrawRectangle(new Pen(ZS.PaletteManager.OverworldGrass[0]), new Rectangle(x, y, 512, 512));
								}
								else if (i < 128)
								{
									g.CompositingMode = CompositingMode.SourceOver;
									g.DrawRectangle(new Pen(ZS.PaletteManager.OverworldGrass[1]), new Rectangle(x, y, 512, 512));
								}
								else
								{
									g.CompositingMode = CompositingMode.SourceOver;
									g.DrawRectangle(new Pen(ZS.PaletteManager.OverworldGrass[2]), new Rectangle(x, y, 512, 512));
								}
							}

							g.DrawImage(ZS.OverworldManager.allmaps[i].gfxBitmap, new PointF(x, y));

							if (Program.MainForm.overworldOverlayVisibleToolStripMenuItem.Checked)
							{
								if (i == 0 || i == 1 || i == 8 || i == 9)
								{
									g.CompositingMode = CompositingMode.SourceOver;
									g.DrawImage(ZS.OverworldManager.allmaps[157].gfxBitmap, new Rectangle(x, y, 512, 512), 0, 0, 512, 512, GraphicsUnit.Pixel, ia);
								}
							}

							x += 512;
							if (x >= (8 * 512))
							{
								x = 0;
								y += 512;
							}
						}
					}
				}

				g.CompositingMode = CompositingMode.SourceOver;

				if (selecting)
				{
					g.DrawRectangle(Pens.White, new Rectangle((globalmouseTileDownX * 16), (globalmouseTileDownY * 16), (((mouseX_Real / 16) - globalmouseTileDownX) * 16) + 16, (((mouseY_Real / 16) - globalmouseTileDownY) * 16) + 16));
				}

				//if (ZS.CurrentOWMode == ObjectMode.OWDoor || ZS.CurrentOWMode == OverworldEditMode.Tile16)
				if (ZS.CurrentOWMode == OverworldEditMode.Tile16)
				{
					Rectangle temp = new Rectangle(mouseX_Real & ~0xF, mouseY_Real & ~0x0F, selectedTileSizeX * 16, selectedTile.Length / selectedTileSizeX * 16);
					g.DrawImage(tilesgfxBitmap, temp , 0, 0, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
					g.DrawRectangle(Pens.LightGreen, temp);
				}

				int offset = 0;
				if (selectedMap >= 128)
				{
					offset = 128;
				}

				if ((mapHover + offset) < ZS.OverworldManager.allmaps.Length)
				{
					int my = (ZS.OverworldManager.allmaps[mapHover + offset].parent - offset) / 8;
					int mx = (ZS.OverworldManager.allmaps[mapHover + offset].parent - offset) - (my * 8);

					if (ZS.OverworldManager.allmaps[mapHover + offset].largeMap)
					{
						g.DrawRectangle(Pens.Orange, new Rectangle(mx * 512, my * 512, 1024, 1024));
					}
					else
					{
						g.DrawRectangle(Pens.Orange, new Rectangle(mx * 512, my * 512, 512, 512));
					}
				}

				if (showExits)
				{
					Draw_Exit(g);
				}

				if (showEntrances)
				{
					Draw_Entrance(g);
				}

				if (showItems)
				{
					Draw_Secrets(g);
				}

				Draw_Graves(g);

				if (showSprites)
				{
					Draw_Sprites(g);
				}

				if (showFlute)
				{
					Draw_Transports(g);
				}

				if (entrancePreview)
				{
					if (selectedEntrance != null)
					{
						g.DrawImage(Program.OverworldForm.tmpPreviewBitmap, selectedEntrance.GlobalX + 16, selectedEntrance.GlobalY + 16);
					}
					if (selectedExit != null)
					{
						g.DrawImage(Program.OverworldForm.tmpPreviewBitmap, selectedExit.GlobalX + 16, selectedExit.GlobalY + 16);
					}
				}

				if (ZS.CurrentOWMode == OverworldEditMode.Overlay)
				{
					int mid = ZS.OverworldManager.allmaps[selectedMap].parent;
					int msy = 512 * (((ZS.OverworldManager.allmaps[selectedMap].parent - ZS.OverworldManager.worldOffset) / 8));
					int msx = 512 * ((ZS.OverworldManager.allmaps[selectedMap].parent - ZS.OverworldManager.worldOffset) - (msy * 8));
					drawText(g, 0 + 4, 0 + 64, "Selected Map : " + selectedMap.ToString());
					drawText(g, 0 + 4, 0 + 80, "Selected Map PARENT : " + ZS.OverworldManager.allmaps[selectedMap].parent.ToString());
					drawText(g, msx + 4, msy + 4, "use ctrl key + click to delete overlay tiles");

					for (int i = 0; i < ZS.OverworldManager.alloverlays[mid].tilesData.Count; i++)
					{
						int xo = ZS.OverworldManager.alloverlays[mid].tilesData[i].MapX * 16;
						int yo = ZS.OverworldManager.alloverlays[mid].tilesData[i].MapY * 16;
						int to = ZS.OverworldManager.alloverlays[mid].tilesData[i].Map16Value;
						int toy = (to / 8) * 16;
						int tox = (to % 8) * 16;
						g.DrawImage(ZS.GFXManager.mapblockset16Bitmap, new Rectangle(msx + xo, msy + yo, 16, 16), new Rectangle(tox, toy, 16, 16), GraphicsUnit.Pixel);
						//g.DrawImage(GFX.currentOWgfx16Bitmap, new Rectangle(0, 0, 64, 64), new Rectangle(0, 0, 64, 64), GraphicsUnit.Pixel);
						byte detect = compareTilePos(ZS.OverworldManager.alloverlays[mid].tilesData[i], ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());

						if (detect == 0)
						{
							g.DrawRectangle(Pens.White, new Rectangle(msx + xo, msy + yo, msx + 16, msy + 16));
						}
						if (!detect.BitIsOn(0x01))
						{
							g.DrawLine(Pens.White, msx + xo, msy + yo, msx + xo, msy + yo + 16);
						}
						if (!detect.BitIsOn(0x02))
						{
							g.DrawLine(Pens.White, msx + xo, msy + yo, msx + xo + 16, msy + yo);
						}
						if (!detect.BitIsOn(0x04))
						{
							g.DrawLine(Pens.White, msx + xo + 16, msy + yo, msx + xo + 16, msy + yo + 16);
						}
						if (!detect.BitIsOn(0x08))
						{
							g.DrawLine(Pens.White, msx + xo, msy + yo + 16, msx + xo + 16, msy + yo + 16);
						}
					}

					Rectangle temp = new Rectangle(mouseX_Real & ~0xF, mouseY_Real & ~0x0F, selectedTileSizeX * 16, selectedTile.Length / selectedTileSizeX * 16);
					g.DrawImage(tilesgfxBitmap,temp, 0, 0, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
					g.DrawRectangle(Pens.LightGreen, temp);

					drawText(g, 4, 24, globalmouseTileDownX.ToString());
					drawText(g, 4, 48, globalmouseTileDownY.ToString());
				}

				if (Program.OverworldForm.gridDisplay != 0)
				{
					int gridsize = 512;
					if (ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[selectedMap].parent].largeMap)
					{
						gridsize = 1024;
					}

					int x = 512 * (ZS.OverworldManager.allmaps[selectedMap].parent % 8);
					int y = 512 * (ZS.OverworldManager.allmaps[selectedMap].parent / 8);

					for (int gx = 0; gx < (gridsize / Program.OverworldForm.gridDisplay); gx++)
					{
						g.DrawLine(Constants.ThirdWhitePen1,
							new Point(x + gx * Program.OverworldForm.gridDisplay, y),
							new Point(x + gx * Program.OverworldForm.gridDisplay, y + gridsize));
					}

					for (int gy = 0; gy < (gridsize / Program.OverworldForm.gridDisplay); gy++)
					{
						g.DrawLine(Constants.ThirdWhitePen1,
							new Point(x, y + (gy * Program.OverworldForm.gridDisplay)),
							new Point(x + gridsize, y + (gy * Program.OverworldForm.gridDisplay)));
					}
				}

				g.CompositingMode = CompositingMode.SourceCopy;
				//hideText = false;
			}
		}

		// 0 = none
		// 1 = left
		// 2 = up
		// 4 = right
		// 8 = bottom

		public byte compareTilePos(TilePos tpc, TilePos[] tpa)
		{
			byte detected = 0;
			foreach (TilePos t in tpa)
			{
				if (t.MapX == tpc.MapX - 1 && t.MapY == tpc.MapY)
				{
					detected |= 0x01;
				}
				else if (t.MapX == tpc.MapX + 1 && t.MapY == tpc.MapY)
				{
					detected |= 0x04;
				}
				else if (t.MapX == tpc.MapX && t.MapY == tpc.MapY - 1)
				{
					detected |= 0x02;
				}
				else if (t.MapX == tpc.MapX && t.MapY == tpc.MapY + 1)
				{
					detected |= 0x08;
				}
				else if (t.MapX == tpc.MapX && t.MapY == tpc.MapY)
				{
					detected |= 0x80;
				}
			}

			return detected;
		}

		public TilePos compareTilePosT(TilePos tpc, TilePos[] tpa)
		{
			foreach (TilePos t in tpa)
			{
				if (t.MapX == tpc.MapX && t.MapY == tpc.MapY)
				{
					return t;
				}
			}
			return TilePos.GarbageTile;
		}

		protected override void RequestRefresh()
		{
			InvalidateHighEnd();
		}
	}
}
