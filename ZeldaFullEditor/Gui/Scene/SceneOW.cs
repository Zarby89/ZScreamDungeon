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
	public class SceneOW : Scene
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
		public OWTileMode tilemode;
		public OWExitMode exitmode;
		public OWDoorMode doorMode;
		public OWEntranceMode entranceMode;
		public OWSpriteMode spriteMode;
		public OWSecretsMode itemMode;
		public OverworldSprite selectedFormSprite;
		public OWTransportMode transportMode;
		public OWOverlayMode overlayMode;
		public OWGravesMode gravestoneMode;
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
			MouseUp += new MouseEventHandler(OnMouseUp);
			MouseMove += new MouseEventHandler(OnMouseMove);
			MouseDoubleClick += new MouseEventHandler(OnMouseDoubleClick);
			MouseWheel += SceneOW_MouseWheel;
			tilesgfxBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, temptilesgfxPtr);
			tilemode = new OWTileMode(ZS);
			exitmode = new OWExitMode(ZS);
			entranceMode = new OWEntranceMode(ZS);
			itemMode = new OWSecretsMode(ZS);
			spriteMode = new OWSpriteMode(ZS);
			transportMode = new OWTransportMode(ZS);
			overlayMode = new OWOverlayMode(ZS);
			gravestoneMode = new OWGravesMode(ZS);

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

		private void SceneOW_MouseWheel(object sender, MouseEventArgs e)
		{
			((HandledMouseEventArgs) e).Handled = true;
			int xPos = ZS.OverworldForm.splitContainer1.Panel2.HorizontalScroll.Value;
			int yPos = ZS.OverworldForm.splitContainer1.Panel2.VerticalScroll.Value;

			if (ModifierKeys == Keys.Shift)
			{
				e.ScrollByValue(ref xPos, 48);
			}
			else
			{
				e.ScrollByValue(ref yPos, 48);
			}

			ZS.OverworldForm.splitContainer1.Panel2.AutoScrollPosition = new Point(xPos, yPos);
			//e.Delta
		}

		public void updateMapGfx()
		{
			if (selectedMap + ZS.OverworldManager.worldOffset <= 159)
			{
				ZS.OverworldForm.propertiesChangedFromForm = true;
				OverworldMap map = ZS.OverworldManager.allmaps[selectedMap + ZS.OverworldManager.worldOffset];

				if (map.needRefresh)
				{
					map.BuildMap();
					map.needRefresh = false;
				}

				ZS.OverworldForm.mapGroupbox.Text = string.Format(
					ZS.MainForm.showMapIndexInHexToolStripMenuItem.Checked ? "Selected map: {0}" : "Selected map: {0}",
					map.parent
					);

				ZS.OverworldForm.OWProperty_MessageID.HexValue = ZS.OverworldManager.allmaps[map.parent].messageID;

				ZS.OverworldForm.UpdateGUIProperties(ZS.OverworldManager.allmaps[map.parent], ZS.OverworldManager.worldOffset >= 64 ? 0 : ZS.OverworldManager.gameState);

				ZS.OverworldForm.propertiesChangedFromForm = false;
				ZS.OverworldForm.tilePictureBox.Refresh();

				ZS.OverworldForm.areaBGColorPictureBox.Refresh();
			}

			ZS.OverworldForm.BuildScratchTilesGfx();
			ZS.OverworldForm.scratchPicturebox.Refresh();
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

				ZS.MainForm.anychange = true;
				selectedMap = mapId;

				selectedMapParent = ZS.OverworldManager.allmaps[selectedMap + ZS.OverworldManager.worldOffset].parent;

				ZS.OverworldForm.previewTextPicturebox.Visible = false;
				updateMapGfx();
				ZS.OverworldForm.updateTiles();

				ActiveMode.OnMouseDown(e);

				InvalidateHighEnd();

				base.OnMouseDown(e);
			}
			else
			{
				// TODO messagebox for failure "Invalid area selected"
			}
		}

		public void SetSelectedExit(ExitOW e)
		{
			ZS.OverworldForm.SetSelectedExit(e);
			exitmode.lastselectedExit = e;
		}

		public void SetSelectedExitSilently(ExitOW e)
		{
			exitmode.lastselectedExit = e;
		}

		public void SetSelectedEntrance(EntranceOWEditor e)
		{
			ZS.OverworldForm.SetSelectedEntrance(e);
			entranceMode.lastselectedEntrance = e;
		}

		public void SetSelectedEntranceSilently(EntranceOWEditor e)
		{
			entranceMode.lastselectedEntrance = e;
		}

		public void SetSelectedTransport(TransportOW e)
		{
			ZS.OverworldForm.SetSelectedTransport(e);
			transportMode.lastselectedTransport = e;
		}

		public void SetSelectedTransportSilently(TransportOW e)
		{
			transportMode.lastselectedTransport = e;
		}

		// TODO switch statements
		private unsafe void OnMouseUp(object sender, MouseEventArgs e)
		{
			ZS.OverworldForm.objCombobox.Items.Clear();
			ZS.OverworldForm.objCombobox.SelectedIndexChanged -= ObjCombobox_SelectedIndexChangedSprite;
			ZS.OverworldForm.objCombobox.SelectedIndexChanged -= ObjCombobox_SelectedIndexChangedItem;
			string text = "Selected object: ";

			ActiveMode.OnMouseUp(e);
			switch (ZS.CurrentOWMode) {
				// TODO tab for items
				case OverworldEditMode.Secrets:
					text += "Item";

					if (itemMode.lastselectedItem != null)
					{
						ZS.OverworldForm.SetSelectedObjectLabels(
							itemMode.lastselectedItem.ID,
							itemMode.lastselectedItem.X,
							itemMode.lastselectedItem.Y);

						ZS.OverworldForm.objCombobox.DataSource = DefaultEntities.ListOfSecrets;

						// TODO
						//ZS.OverworldForm.objCombobox.SelectedItem = 

						ZS.OverworldForm.objCombobox.SelectedIndexChanged += ObjCombobox_SelectedIndexChangedItem;
					}
					break;

				// TODO tab for sprites
				case OverworldEditMode.Sprites:
					text += "Sprite";

					if (spriteMode.lastselectedSprite != null)
					{
						ZS.OverworldForm.SetSelectedObjectLabels(
							spriteMode.lastselectedSprite.ID,
							spriteMode.lastselectedSprite.X,
							spriteMode.lastselectedSprite.Y);
						ZS.OverworldForm.objCombobox.DataSource = DefaultEntities.ListOfTileTypes;
						ZS.OverworldForm.objCombobox.SelectedIndex = spriteMode.lastselectedSprite.ID;

						ZS.OverworldForm.objCombobox.SelectedIndexChanged += ObjCombobox_SelectedIndexChangedSprite;
					}
					break;
			}
			ZS.OverworldForm.objectGroupbox.Text = text;
			InvalidateHighEnd();
		}


		private void ObjCombobox_SelectedIndexChangedSprite(object sender, EventArgs e)
		{
			byte id = (byte) (ZS.OverworldForm.objCombobox.SelectedItem as SpriteName).ID;
			spriteMode.lastselectedSprite.Species = SpriteType.GetSpriteType(id);

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
					ZS.OverworldForm.splitContainer1.Panel2.HorizontalScroll.Value,
					ZS.OverworldForm.splitContainer1.Panel2.VerticalScroll.Value,
					ZS.OverworldForm.splitContainer1.Panel2.Width,
					ZS.OverworldForm.splitContainer1.Panel2.Height
					));
			}
		}



		private void ObjCombobox_SelectedIndexChangedItem(object sender, EventArgs e)
		{
			byte id = (byte) (ZS.OverworldForm.objCombobox.SelectedItem as SecretsName).ID;
			itemMode.lastselectedItem.SecretType = SecretItemType.FindSecretFromID(id);
			InvalidateHighEnd();
		}

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			//Stopwatch sw = new Stopwatch();
			//sw.Start();

			ActiveMode.OnMouseMove(e);

			InvalidateHighEnd();

			//sw.Stop();
			//Console.WriteLine("Entire OW draw ms: " + sw.ElapsedMilliseconds);
		}

		public void Undo()
		{
			tilemode.Undo();
			InvalidateHighEnd();
		}

		public void Redo()
		{
			tilemode.Redo();
			InvalidateHighEnd();
		}

		public override void Paste()
		{
			ActiveMode.Paste();

			InvalidateHighEnd();
		}

		public override void Copy()
		{
			ActiveMode.Copy();
		}

		public override void Delete()
		{
			ActiveMode.Delete();
			InvalidateHighEnd();
		}

		public override void SelectAll()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates a map32 tile map and saves the overworld tiles in the rom. 
		/// </summary>
		/// <returns>True if saving failed. For example if the unique tile32 limit was passed. </returns>
		public bool SaveTiles()
		{
			if (!ZS.OverworldManager.createMap32Tilesmap())
			{
				ZS.OverworldManager.SaveMap32DefinitionsToROM();
				//ZS.OverworldManager.savemapstorom();
				ZS.OverworldManager.SaveMap16DefinitionsToROM();

				return false;
			}
			else
			{
				return true;
			}
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
							if (ZS.MainForm.overworldOverlayVisibleToolStripMenuItem.Checked)
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
								else if (i >= 64 && i < 128)
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

							if (ZS.MainForm.overworldOverlayVisibleToolStripMenuItem.Checked)
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
					exitmode.Draw(g);
				}

				if (showEntrances)
				{
					entranceMode.Draw(g);
				}

				if (showItems)
				{
					itemMode.Draw(g);
				}

				gravestoneMode.Draw(g);

				if (showSprites)
				{
					spriteMode.Draw(g);
				}

				if (showFlute)
				{
					transportMode.Draw(g);
				}

				if (entrancePreview)
				{
					if (entranceMode.selectedEntrance != null)
					{
						g.DrawImage(ZS.OverworldForm.tmpPreviewBitmap, entranceMode.selectedEntrance.GlobalX + 16, entranceMode.selectedEntrance.GlobalY + 16);
					}
					if (exitmode.selectedExit != null)
					{
						g.DrawImage(ZS.OverworldForm.tmpPreviewBitmap, exitmode.selectedExit.GlobalX + 16, exitmode.selectedExit.GlobalY + 16);
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
						int xo = ZS.OverworldManager.alloverlays[mid].tilesData[i].x * 16;
						int yo = ZS.OverworldManager.alloverlays[mid].tilesData[i].y * 16;
						int to = ZS.OverworldManager.alloverlays[mid].tilesData[i].tileId;
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

				if (ZS.OverworldForm.gridDisplay != 0)
				{
					int gridsize = 512;
					if (ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[selectedMap].parent].largeMap)
					{
						gridsize = 1024;
					}

					int x = 512 * (ZS.OverworldManager.allmaps[selectedMap].parent % 8);
					int y = 512 * (ZS.OverworldManager.allmaps[selectedMap].parent / 8);

					for (int gx = 0; gx < (gridsize / ZS.OverworldForm.gridDisplay); gx++)
					{
						g.DrawLine(Constants.ThirdWhitePen1,
							new Point(x + gx * ZS.OverworldForm.gridDisplay, y),
							new Point(x + gx * ZS.OverworldForm.gridDisplay, y + gridsize));
					}

					for (int gy = 0; gy < (gridsize / ZS.OverworldForm.gridDisplay); gy++)
					{
						g.DrawLine(Constants.ThirdWhitePen1,
							new Point(x, y + (gy * ZS.OverworldForm.gridDisplay)),
							new Point(x + gridsize, y + (gy * ZS.OverworldForm.gridDisplay)));
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
				if (t.x == tpc.x - 1 && t.y == tpc.y)
				{
					detected |= 0x01;
				}
				else if (t.x == tpc.x + 1 && t.y == tpc.y)
				{
					detected |= 0x04;
				}
				else if (t.x == tpc.x && t.y == tpc.y - 1)
				{
					detected |= 0x02;
				}
				else if (t.x == tpc.x && t.y == tpc.y + 1)
				{
					detected |= 0x08;
				}
				else if (t.x == tpc.x && t.y == tpc.y)
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
				if (t.x == tpc.x && t.y == tpc.y)
				{
					return t;
				}
			}
			return null;
		}

		public void ReLoadPalettes()
		{
			ZS.OverworldManager.allmaps[selectedMap].LoadPalette();
		}


		public void drawGrid(Graphics graphics)
		{
			// TODO: Add something here?

			/*
            if (showGrid)
            {
                //int s = mainForm.gridSize;
                int wh = (512 / s)+1;

                for (int x = 0; x < wh; x++)
                {
                    graphics.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), x * s, 0, x * s, 512);
                }
                for (int y = 0; y < wh; y++)
                {
                    graphics.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), 0, y * s, 512, y * s);
                }
            }
            */
		}

		public void SetPalettesTransparent()
		{
			int pindex = 0;
			ColorPalette palettes = ZS.GFXManager.roomBg1Bitmap.Palette;
			for (int y = 0; y < ZS.GFXManager.loadedPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < ZS.GFXManager.loadedPalettes.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = ZS.GFXManager.loadedPalettes[x, y];
				}
			}

			for (int y = 0; y < ZS.GFXManager.loadedSprPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < ZS.GFXManager.loadedSprPalettes.GetLength(0); x++)
				{
					if (pindex < 256)
					{
						palettes.Entries[pindex++] = ZS.GFXManager.loadedSprPalettes[x, y];
					}
				}
			}

			for (int i = 0; i < 16 * 16; i += 8)
			{
				palettes.Entries[i] = Color.Transparent;
			}

			ZS.GFXManager.roomBg1Bitmap.Palette = palettes;
			ZS.GFXManager.roomBg2Bitmap.Palette = palettes;
			ZS.GFXManager.roomBgLayoutBitmap.Palette = palettes;
		}

		public void SetPalettesBlack()
		{
			int pindex = 0;
			ColorPalette palettes = ZS.GFXManager.roomBg1Bitmap.Palette;
			for (int y = 0; y < ZS.GFXManager.loadedPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < ZS.GFXManager.loadedPalettes.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = ZS.GFXManager.loadedPalettes[x, y];
				}
			}

			for (int i = 0; i < 16 * 16; i += 8)
			{
				palettes.Entries[i] = Color.Black;
			}

			ZS.GFXManager.roomBg1Bitmap.Palette = palettes;
			ZS.GFXManager.roomBg2Bitmap.Palette = palettes;
			ZS.GFXManager.roomBgLayoutBitmap.Palette = palettes;
		}

		private void OnMouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (ZS.CurrentOWMode == OverworldEditMode.Entrances)
			{
				entranceMode.OnMouseDoubleClick(e);
			}
		}

		protected override void RequestRefresh()
		{
			InvalidateHighEnd();
		}
	}
}
