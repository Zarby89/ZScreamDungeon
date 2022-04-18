using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.SceneModes.ClipboardData;

namespace ZeldaFullEditor.SceneModes
{
	public class OWTileMode : SceneMode
	{
		List<TileUndo> undoList = new List<TileUndo>();
		List<TileUndo> redoList = new List<TileUndo>();

		int globalmouseTileDownXLOCK = 0;
		int globalmouseTileDownYLOCK = 0;

		byte lockedDirection = 0x00;
		
		public OWTileMode(ZScreamer zs) : base(zs)
		{

		}

		public void Undo()
		{
			if (undoList.Count > 0)
			{
				undoList[undoList.Count - 1].Restore(ZS.OverworldManager);
				TileUndo tundo = (TileUndo) undoList[undoList.Count - 1].Clone();
				tundo.usedTiles = undoList[undoList.Count - 1].usedTiles;
				redoList.Add(tundo);
				undoList.RemoveAt(undoList.Count - 1);
			}
		}

		public void Redo()
		{
			if (redoList.Count > 0)
			{
				redoList[redoList.Count - 1].RestoreRedo(ZS.OverworldManager);
				TileUndo tundo = (TileUndo) redoList[redoList.Count - 1].Clone();
				tundo.usedTiles = redoList[redoList.Count - 1].usedTiles;
				undoList.Add(tundo);
				redoList.RemoveAt(redoList.Count - 1);
			}
		}

		public override void Copy()
		{
			Clipboard.Clear();
			TileData td = new TileData((ushort[]) ZS.OverworldScene.selectedTile.Clone(), ZS.OverworldScene.selectedTileSizeX);
			Clipboard.SetData(Constants.OverworldTilesClipboardData, td);
		}

		public override void Cut()
		{
			// TODO
		}

		public override void Delete()
		{
			// TODO
		}

		public override void Paste()
		{
			TileData data = (TileData) Clipboard.GetData(Constants.OverworldTilesClipboardData);

			if (data != null)
			{
				ZS.OverworldScene.selectedTile = data.tiles;
				ZS.OverworldScene.selectedTileSizeX = data.length;
			}
		}

		public override void OnMouseDown(MouseEventArgs e)
		{
			//Buildtileset();
			//BuildTiles16Gfx();

			if (!ZS.OverworldScene.mouse_down)
			{
				int tileX = (e.X / 16);
				int tileY = (e.Y / 16);
				int superX = (tileX / 32);
				int superY = (tileY / 32);
				int mapId = (superY * 8) + superX;
				ZS.OverworldScene.globalmouseTileDownX = tileX;
				ZS.OverworldScene.globalmouseTileDownY = tileY;
				globalmouseTileDownXLOCK = tileX;
				globalmouseTileDownYLOCK = tileY;

				ZS.OverworldScene.selectedMap = mapId + ZS.OverworldManager.worldOffset;
				ZS.OverworldScene.selectedMapParent = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent;
				//ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].BuildMap();

				ZS.OverworldScene.tileBitmapPtr = ZS.GFXManager.mapblockset16;
				ZS.OverworldScene.tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, ZS.OverworldScene.tileBitmapPtr);
				ZS.OverworldScene.tileBitmap.Palette = ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[mapId].parent].gfxBitmap.Palette;

				if (ZS.OverworldScene.selectedMap >= 160)
				{
					return;
				}

				if (ZS.OverworldScene.needRedraw)
				{
					ZS.OverworldScene.needRedraw = false;
					return;
				}

				ZS.OverworldScene.mouse_down = true;

				if (e.Button == MouseButtons.Left)
				{
					if (Control.ModifierKeys == Keys.Control)
					{
						if (ZS.OverworldScene.selectedTile.Length >= 1)
						{
							int y = 0;
							int x = 0;

							for (int i = 0; i < ZS.OverworldScene.selectedTile.Length; i++)
							{
								superX = ((tileX + x) / 32);
								superY = ((tileY + y) / 32);
								mapId = (superY * 8) + superX + ZS.OverworldManager.worldOffset;
								if (ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX + x, ZS.OverworldScene.globalmouseTileDownY + y] == 52)
								{
									ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX + x, ZS.OverworldScene.globalmouseTileDownY + y] = ZS.OverworldScene.selectedTile[i];
									ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), ZS.OverworldScene.selectedTile[i], ZS.OverworldManager.allmaps[mapId].gfxPtr, ZS.GFXManager.mapblockset16);
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
							if (ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX, ZS.OverworldScene.globalmouseTileDownY] == 52)
							{
								ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX, ZS.OverworldScene.globalmouseTileDownY] = ZS.OverworldScene.selectedTile[0];
								ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX) * 16) - (superX * 512), ((tileY) * 16) - (superY * 512), ZS.OverworldScene.selectedTile[0], ZS.OverworldManager.allmaps[mapId].gfxPtr, ZS.GFXManager.mapblockset16);

								//ZS.OverworldScene.Invalidate(new Rectangle(e.X - 16, e.Y - 16, 32,  32));
							}
						}
					}
					else
					{
						if (ZS.OverworldScene.selectedTile.Length >= 1)
						{
							int y = 0;
							int x = 0;
							ushort[] undotiles = new ushort[ZS.OverworldScene.selectedTile.Length];

							for (int i = 0; i < ZS.OverworldScene.selectedTile.Length; i++)
							{
								superX = ((tileX + x) / 32);
								superY = ((tileY + y) / 32);
								mapId = (superY * 8) + superX + ZS.OverworldManager.worldOffset;
								undotiles[i] = ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX + x, ZS.OverworldScene.globalmouseTileDownY + y];
								ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX + x, ZS.OverworldScene.globalmouseTileDownY + y] = ZS.OverworldScene.selectedTile[i];
								ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), ZS.OverworldScene.selectedTile[i], ZS.OverworldManager.allmaps[mapId].gfxPtr, ZS.GFXManager.mapblockset16);

								x++;
								if (x >= ZS.OverworldScene.selectedTileSizeX)
								{
									y++;
									x = 0;
								}
							}

							undoList.Add(new TileUndo(ZS.OverworldScene.globalmouseTileDownX, ZS.OverworldScene.globalmouseTileDownY, ZS.OverworldScene.selectedTileSizeX, undotiles, (ushort[]) ZS.OverworldScene.selectedTile.Clone(), ref ZS.OverworldManager.allmaps[mapId].tilesUsed));
							redoList.Clear();
						}
						else
						{
							undoList.Add(new TileUndo(ZS.OverworldScene.globalmouseTileDownX, ZS.OverworldScene.globalmouseTileDownY, 1, new ushort[] { ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX, ZS.OverworldScene.globalmouseTileDownY] }, (ushort[]) ZS.OverworldScene.selectedTile.Clone(), ref ZS.OverworldManager.allmaps[mapId].tilesUsed));
							redoList.Clear();
							ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX, ZS.OverworldScene.globalmouseTileDownY] = ZS.OverworldScene.selectedTile[0];
							ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX) * 16) - (superX * 512), ((tileY) * 16) - (superY * 512), ZS.OverworldScene.selectedTile[0], ZS.OverworldManager.allmaps[mapId].gfxPtr, ZS.GFXManager.mapblockset16);

							//ZS.OverworldScene.Invalidate(new Rectangle(e.X - 16, e.Y - 16, 32,  32));
						}
					}
				}
				else if (e.Button == MouseButtons.Right)
				{
					ZS.OverworldScene.selecting = true;
					ZS.OverworldForm.selectedTileLabel.Text = "Selected Tile : " + ZS.OverworldScene.selectedTile[0].ToString("X4");
				}
			}
		}

		public override void OnMouseUp(MouseEventArgs e)
		{
			if (ZS.OverworldScene.mouse_down)
			{
				int tileX = (e.X / 16);
				int tileY = (e.Y / 16);
				int superX = (tileX / 32);
				int superY = (tileY / 32);
				int mapId = (superY * 8) + superX + ZS.OverworldManager.worldOffset;
				lockedDirection = 0x00;

				if (e.Button == MouseButtons.Right)
				{
					if (tileX == ZS.OverworldScene.globalmouseTileDownX && tileY == ZS.OverworldScene.globalmouseTileDownY)
					{
						ZS.OverworldScene.selectedTile = new ushort[1] { ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX, ZS.OverworldScene.globalmouseTileDownY] };
						ZS.OverworldScene.selectedTileSizeX = 1;
					}
					else
					{
						bool reverseX = false;
						bool reverseY = false;
						int sizeX = (tileX - ZS.OverworldScene.globalmouseTileDownX) + 1;
						int sizeY = (tileY - ZS.OverworldScene.globalmouseTileDownY) + 1;

						if (tileX < ZS.OverworldScene.globalmouseTileDownX)
						{
							sizeX = (ZS.OverworldScene.globalmouseTileDownX - tileX) + 1;
							reverseX = true;
						}

						if (tileY < ZS.OverworldScene.globalmouseTileDownY)
						{
							sizeY = (ZS.OverworldScene.globalmouseTileDownY - tileY) + 1;
							reverseY = true;
						}

						ZS.OverworldScene.selectedTileSizeX = sizeX;
						ZS.OverworldScene.selectedTile = new ushort[sizeX * sizeY];
						for (int y = 0; y < sizeY; y++)
						{
							for (int x = 0; x < sizeX; x++)
							{
								int pX = reverseX ? tileX : ZS.OverworldScene.globalmouseTileDownX;
								int pY = reverseY ? tileY : ZS.OverworldScene.globalmouseTileDownY;
								ZS.OverworldScene.selectedTile[x + (y * sizeX)] =
									ZS.OverworldManager.allmaps[mapId].tilesUsed[pX + x, pY + y];
							}
						}
					}

					if (ZS.OverworldScene.selectedTile.Length > 0)
					{
						int scrollpos = ((ZS.OverworldScene.selectedTile[0] / 8) * 16);
						if (scrollpos >= ZS.OverworldForm.splitContainer1.Panel1.VerticalScroll.Maximum)
						{
							ZS.OverworldForm.splitContainer1.Panel1.VerticalScroll.Value = ZS.OverworldForm.splitContainer1.Panel1.VerticalScroll.Maximum;
						}
						else
						{
							ZS.OverworldForm.splitContainer1.Panel1.VerticalScroll.Value = scrollpos;
						}

						ZS.OverworldForm.tilePictureBox.Refresh();
					}
				}
			}

			ZS.OverworldScene.selecting = false;
			ZS.OverworldScene.mouse_down = false;

			//ZS.OverworldScene.Refresh();
			//ZS.OverworldScene.mainForm.pictureboxOWTiles.Refresh();
			//ZS.OverworldScene.mainForm.pictureGroupTiles.Refresh();
		}

		public override void OnMouseWheel(MouseEventArgs e)
		{

		}

		public override void OnMouseMove(MouseEventArgs e)
		{
			if (ZS.OverworldScene.initialized)
			{
				ZS.OverworldScene.mouseX_Real = e.X;
				ZS.OverworldScene.mouseY_Real = e.Y;
				int mouseTileX = e.X / 16;
				int mouseTileY = e.Y / 16;
				int mapX = (mouseTileX / 32);
				int mapY = (mouseTileY / 32);

				ZS.OverworldScene.mapHover = mapX + (mapY * 8);

				if (ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset >= 160)
				{
					return;
				}

				if (ZS.OverworldScene.lastHover != ZS.OverworldScene.mapHover)
				{
					ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].BuildMap();
					ZS.OverworldScene.lastHover = ZS.OverworldScene.mapHover;
				}

				if (ZS.OverworldScene.lastTileHoverX != mouseTileX || ZS.OverworldScene.lastTileHoverY != mouseTileY)
				{
					if (ZS.OverworldScene.mouse_down)
					{
						if (e.Button == MouseButtons.Left)
						{
							int tileX = (e.X / 16).Clamp(0, 255);
							int tileY = (e.Y / 16).Clamp(0, 255);
							int superX = (tileX / 32);
							int superY = (tileY / 32);
							int mapId = (superY * 8) + superX;
							ZS.OverworldScene.globalmouseTileDownX = tileX;
							ZS.OverworldScene.globalmouseTileDownY = tileY;

							if (Control.ModifierKeys == Keys.Shift)
							{
								if (lockedDirection == 0x00)
								{
									if (ZS.OverworldScene.lastTileHoverX != mouseTileX)
									{
										lockedDirection = 0x01;
									}
									if (ZS.OverworldScene.lastTileHoverY != mouseTileY)
									{
										lockedDirection = 0x02;
									}
								}
							}

							if (lockedDirection == 0x01)
							{
								ZS.OverworldScene.globalmouseTileDownY = tileY = globalmouseTileDownYLOCK;
							}
							else if (lockedDirection == 0x02)
							{
								ZS.OverworldScene.globalmouseTileDownX = tileX = globalmouseTileDownXLOCK;
							}

							if (Control.ModifierKeys == Keys.Control)
							{
								if (ZS.OverworldScene.selectedTile.Length >= 1)
								{
									int y = 0;
									int x = 0;
									for (int i = 0; i < ZS.OverworldScene.selectedTile.Length; i++)
									{
										superX = ((tileX + x) / 32);
										superY = ((tileY + y) / 32);
										mapId = (superY * 8) + superX + ZS.OverworldManager.worldOffset;

										if (ZS.OverworldScene.globalmouseTileDownX + x < 256 && ZS.OverworldScene.globalmouseTileDownY + y < 256)
										{
											if (ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX + x, ZS.OverworldScene.globalmouseTileDownY + y] == 52)
											{
												ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX + x, ZS.OverworldScene.globalmouseTileDownY + y] = ZS.OverworldScene.selectedTile[i];
												ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), ZS.OverworldScene.selectedTile[i], ZS.OverworldManager.allmaps[mapId].gfxPtr, ZS.GFXManager.mapblockset16);
											}
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
							else
							{
								if (ZS.OverworldScene.selectedTile.Length >= 1)
								{
									ushort[] undotiles = new ushort[ZS.OverworldScene.selectedTile.Length];
									int y = 0;
									int x = 0;

									for (int i = 0; i < ZS.OverworldScene.selectedTile.Length; i++)
									{
										superX = ((tileX + x) / 32);
										superY = ((tileY + y) / 32);
										mapId = (superY * 8) + superX + ZS.OverworldManager.worldOffset;

										if (ZS.OverworldScene.globalmouseTileDownX + x < 256 && ZS.OverworldScene.globalmouseTileDownY + y < 256)
										{
											undotiles[i] = ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX + x, ZS.OverworldScene.globalmouseTileDownY + y];
											ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX + x, ZS.OverworldScene.globalmouseTileDownY + y] = ZS.OverworldScene.selectedTile[i];
											ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), ZS.OverworldScene.selectedTile[i], ZS.OverworldManager.allmaps[mapId].gfxPtr, ZS.GFXManager.mapblockset16);
										}

										x++;
										if (x >= ZS.OverworldScene.selectedTileSizeX)
										{
											y++;
											x = 0;
										}
									}

									undoList.Add(new TileUndo(ZS.OverworldScene.globalmouseTileDownX, ZS.OverworldScene.globalmouseTileDownY, ZS.OverworldScene.selectedTileSizeX, undotiles, (ushort[]) ZS.OverworldScene.selectedTile.Clone(), ref ZS.OverworldManager.allmaps[mapId].tilesUsed));
									redoList.Clear();

									//ZS.OverworldScene.Invalidate(new Rectangle((ZS.OverworldScene.globalmouseTileDownX * 16), ZS.OverworldScene.globalmouseTileDownY * 16, ZS.OverworldScene.selectedTileSizeX * 16, y * 16));
									// }

									/*
                                    else
                                    {
                                        ow.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX, ZS.OverworldScene.globalmouseTileDownY] = selectedTile[0];
                                        ow.allmaps[mapId].CopyTile8bpp16(((tileX) * 16) - (superX * 512), ((tileY) * 16) - (superY * 512), selectedTile[0], ow.allmaps[mapId].gfxPtr, ow.allmaps[mapId].blockset16);
                                        this.Invalidate(new Rectangle(e.X - 16, e.Y - 16, 32, 32));
                                    }
                                    */
								}
							}
						}
					}

					// Refresh the tile preview
					if (ZS.OverworldScene.selectedTile.Length >= 1)
					{
						int sX, sY;
						int y = 0;
						int x = 0;
						int mapId = 0 + ZS.OverworldManager.worldOffset;

						for (int i = 0; i < ZS.OverworldScene.selectedTile.Length; i++)
						{
							if (ZS.OverworldScene.globalmouseTileDownX + x < 255 && ZS.OverworldScene.globalmouseTileDownY + y < 255)
							{
								sX = ((mouseTileX + x) / 32);
								sY = ((mouseTileY + y) / 32);
								mapId = (sY * 8) + sX + ZS.OverworldManager.worldOffset;

								if (mapId > 63 + ZS.OverworldManager.worldOffset)
								{
									return;
								}
								if (mapId <= 159)
								{
									ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(x * 16, y * 16, ZS.OverworldScene.selectedTile[i], ZS.OverworldScene.temptilesgfxPtr, ZS.GFXManager.mapblockset16);
								}
							}

							x++;
							if (x >= ZS.OverworldScene.selectedTileSizeX)
							{

								y++;
								x = 0;
							}
						}

						if (mapId > 63 + ZS.OverworldManager.worldOffset)
						{
							return;
						}
						if (mapId <= 159)
						{
							ZS.OverworldScene.tilesgfxBitmap.Palette = ZS.OverworldManager.allmaps[mapId].gfxBitmap.Palette;
						}
						//ZS.OverworldScene.Invalidate(new Rectangle((ZS.OverworldManagerForm.splitContainer1.Panel2.HorizontalScroll.Value), (ZS.OverworldManagerForm.splitContainer1.Panel2.VerticalScroll.Value), (ZS.OverworldManagerForm.splitContainer1.Panel2.Width), (ZS.OverworldManagerForm.splitContainer1.Panel2.Height)));
						//ZS.OverworldScene.Invalidate(new Rectangle(ZS.OverworldScene.mainForm.panel5.HorizontalScroll.Value, ZS.OverworldScene.mainForm.panel5.VerticalScroll.Value, ZS.OverworldScene.mainForm.panel5.Width, ZS.OverworldScene.mainForm.panel5.Height));
						//this.Refresh();
						//this.Invalidate(new Rectangle((mouseTileX * 16)-16, (mouseTileY * 16)-16, (selectedTileSizeX * 16)+32, (y * 16)+32));
					}

					/*
                    if (selecting)
                    {
                        this.Invalidate(new Rectangle((globalmouseTileDownX * 16), (globalmouseTileDownY * 16), (mouseTileX * 16) - (globalmouseTileDownX * 16) + 48, (mouseTileY * 16) - (globalmouseTileDownY * 16) + 48));
                    }
                    */

					ZS.OverworldScene.lastTileHoverX = mouseTileX;
					ZS.OverworldScene.lastTileHoverY = mouseTileY;
					/*
                    int tileX = (e.X / 16);
                    int tileY = (e.Y / 16);
                    int superX = (tileX / 32);
                    int superY = (tileY / 32);
                    int mapId = (superY * 8) + superX;
                    ow.allmapsTiles[tileX, tileY] = selectedTile[0];
                    ow.allmaps[mapId].CopyTile8bpp16(((e.X / 16)*16)-(superX*512), ((e.Y / 16)*16) - (superY * 512), selectedTile[0], ow.allmaps[mapId].gfxPtr, ow.allmaps[mapId].blockset16);
                    this.Invalidate(new Rectangle(e.X-16, e.Y-16, 48, 48));
                    //this.Refresh();
                    */
				}
			}
		}

		public override void SelectAll()
		{
			throw new NotImplementedException();
		}
	}
}
