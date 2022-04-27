﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.SceneModes.ClipboardData;

namespace ZeldaFullEditor
{
	public partial class SceneOW
	{
		List<TileUndo> undoList = new List<TileUndo>();
		List<TileUndo> redoList = new List<TileUndo>();

		int globalmouseTileDownXLOCK = 0;
		int globalmouseTileDownYLOCK = 0;

		byte lockedDirection = 0x00;

		private void Undo_Tiles()
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

		private void Redo_Tiles()
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

		private void Copy_Tiles()
		{
			Clipboard.Clear();
			TileData td = new TileData((ushort[]) selectedTile.Clone(), selectedTileSizeX);
			Clipboard.SetData(Constants.OverworldTilesClipboardData, td);
		}

		private void Delete_Tiles()
		{
			// TODO
		}

		private void Paste_Tiles()
		{
			TileData data = (TileData) Clipboard.GetData(Constants.OverworldTilesClipboardData);

			if (data != null)
			{
				selectedTile = data.tiles;
				selectedTileSizeX = data.length;
			}
		}

		private void OnMouseDown_Tiles(MouseEventArgs e)
		{
			//Buildtileset();
			//BuildTiles16Gfx();

			if (!mouse_down)
			{
				int tileX = (e.X / 16);
				int tileY = (e.Y / 16);
				int superX = (tileX / 32);
				int superY = (tileY / 32);
				int mapId = (superY * 8) + superX;
				globalmouseTileDownX = tileX;
				globalmouseTileDownY = tileY;
				globalmouseTileDownXLOCK = tileX;
				globalmouseTileDownYLOCK = tileY;

				selectedMap = mapId + ZS.OverworldManager.worldOffset;
				selectedMapParent = ZS.OverworldManager.allmaps[selectedMap].parent;
				//ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.worldOffset].BuildMap();

				tileBitmapPtr = ZS.GFXManager.mapblockset16;
				tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, tileBitmapPtr)
				{
					Palette = ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[mapId].parent].gfxBitmap.Palette
				};

				if (selectedMap >= 160)
				{
					return;
				}

				if (needRedraw)
				{
					needRedraw = false;
					return;
				}

				mouse_down = true;

				if (e.Button == MouseButtons.Left)
				{
					if (ModifierKeys == Keys.Control)
					{
						if (selectedTile.Length >= 1)
						{
							int y = 0;
							int x = 0;

							for (int i = 0; i < selectedTile.Length; i++)
							{
								superX = ((tileX + x) / 32);
								superY = ((tileY + y) / 32);
								mapId = (superY * 8) + superX + ZS.OverworldManager.worldOffset;
								if (ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX + x, globalmouseTileDownY + y] == 52)
								{
									ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX + x, globalmouseTileDownY + y] = selectedTile[i];
									ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), selectedTile[i], ZS.OverworldManager.allmaps[mapId].gfxPtr, ZS.GFXManager.mapblockset16);
								}

								x++;
								if (x >= selectedTileSizeX)
								{
									y++;
									x = 0;
								}
							}
						}
						else
						{
							if (ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX, globalmouseTileDownY] == 52)
							{
								ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX, globalmouseTileDownY] = selectedTile[0];
								ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX) * 16) - (superX * 512), ((tileY) * 16) - (superY * 512), selectedTile[0], ZS.OverworldManager.allmaps[mapId].gfxPtr, ZS.GFXManager.mapblockset16);

								//Invalidate(new Rectangle(e.X - 16, e.Y - 16, 32,  32));
							}
						}
					}
					else
					{
						if (selectedTile.Length >= 1)
						{
							int y = 0;
							int x = 0;
							ushort[] undotiles = new ushort[selectedTile.Length];

							for (int i = 0; i < selectedTile.Length; i++)
							{
								superX = ((tileX + x) / 32);
								superY = ((tileY + y) / 32);
								mapId = (superY * 8) + superX + ZS.OverworldManager.worldOffset;
								undotiles[i] = ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX + x, globalmouseTileDownY + y];
								ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX + x, globalmouseTileDownY + y] = selectedTile[i];
								ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), selectedTile[i], ZS.OverworldManager.allmaps[mapId].gfxPtr, ZS.GFXManager.mapblockset16);

								x++;
								if (x >= selectedTileSizeX)
								{
									y++;
									x = 0;
								}
							}

							undoList.Add(new TileUndo(globalmouseTileDownX, globalmouseTileDownY, selectedTileSizeX, undotiles, (ushort[]) selectedTile.Clone(), ref ZS.OverworldManager.allmaps[mapId].tilesUsed));
							redoList.Clear();
						}
						else
						{
							undoList.Add(new TileUndo(globalmouseTileDownX, globalmouseTileDownY, 1, new ushort[] { ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX, globalmouseTileDownY] }, (ushort[]) selectedTile.Clone(), ref ZS.OverworldManager.allmaps[mapId].tilesUsed));
							redoList.Clear();
							ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX, globalmouseTileDownY] = selectedTile[0];
							ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX) * 16) - (superX * 512), ((tileY) * 16) - (superY * 512), selectedTile[0], ZS.OverworldManager.allmaps[mapId].gfxPtr, ZS.GFXManager.mapblockset16);

							//Invalidate(new Rectangle(e.X - 16, e.Y - 16, 32,  32));
						}
					}
				}
				else if (e.Button == MouseButtons.Right)
				{
					selecting = true;
					Program.OverworldForm.selectedTileLabel.Text = "Selected Tile : " + selectedTile[0].ToString("X4");
				}
			}
		}

		private void OnMouseUp_Tiles(MouseEventArgs e)
		{
			if (mouse_down)
			{
				int tileX = (e.X / 16);
				int tileY = (e.Y / 16);
				int superX = (tileX / 32);
				int superY = (tileY / 32);
				int mapId = (superY * 8) + superX + ZS.OverworldManager.worldOffset;
				lockedDirection = 0x00;

				if (e.Button == MouseButtons.Right)
				{
					if (tileX == globalmouseTileDownX && tileY == globalmouseTileDownY)
					{
						selectedTile = new ushort[1] { ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX, globalmouseTileDownY] };
						selectedTileSizeX = 1;
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

						selectedTileSizeX = sizeX;
						selectedTile = new ushort[sizeX * sizeY];
						for (int y = 0; y < sizeY; y++)
						{
							for (int x = 0; x < sizeX; x++)
							{
								int pX = reverseX ? tileX : globalmouseTileDownX;
								int pY = reverseY ? tileY : globalmouseTileDownY;
								selectedTile[x + (y * sizeX)] =
									ZS.OverworldManager.allmaps[mapId].tilesUsed[pX + x, pY + y];
							}
						}
					}

					if (selectedTile.Length > 0)
					{
						int scrollpos = ((selectedTile[0] / 8) * 16);
						if (scrollpos >= Program.OverworldForm.splitContainer1.Panel1.VerticalScroll.Maximum)
						{
							Program.OverworldForm.splitContainer1.Panel1.VerticalScroll.Value = Program.OverworldForm.splitContainer1.Panel1.VerticalScroll.Maximum;
						}
						else
						{
							Program.OverworldForm.splitContainer1.Panel1.VerticalScroll.Value = scrollpos;
						}

						Program.OverworldForm.tilePictureBox.Refresh();
					}
				}
			}

			selecting = false;
			mouse_down = false;

			//Refresh();
			//mainForm.pictureboxOWTiles.Refresh();
			//mainForm.pictureGroupTiles.Refresh();
		}

		private void OnMouseMove_Tiles(MouseEventArgs e)
		{
			
			mouseX_Real = e.X;
			mouseY_Real = e.Y;
			int mouseTileX = e.X / 16;
			int mouseTileY = e.Y / 16;
			int mapX = (mouseTileX / 32);
			int mapY = (mouseTileY / 32);
			
			mapHover = mapX + (mapY * 8);
			
			if (mapHover + ZS.OverworldManager.worldOffset >= 160)
			{
				return;
			}
			
			if (lastHover != mapHover)
			{
				ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.worldOffset].BuildMap();
				lastHover = mapHover;
			}
			
			if (lastTileHoverX != mouseTileX || lastTileHoverY != mouseTileY)
			{
				if (mouse_down)
				{
					if (e.Button == MouseButtons.Left)
					{
						int tileX = (e.X / 16).Clamp(0, 255);
						int tileY = (e.Y / 16).Clamp(0, 255);
						int superX = (tileX / 32);
						int superY = (tileY / 32);
						int mapId = (superY * 8) + superX;
						globalmouseTileDownX = tileX;
						globalmouseTileDownY = tileY;
			
						if (ModifierKeys == Keys.Shift)
						{
							if (lockedDirection == 0x00)
							{
								if (lastTileHoverX != mouseTileX)
								{
									lockedDirection = 0x01;
								}
								if (lastTileHoverY != mouseTileY)
								{
									lockedDirection = 0x02;
								}
							}
						}
			
						if (lockedDirection == 0x01)
						{
							globalmouseTileDownY = tileY = globalmouseTileDownYLOCK;
						}
						else if (lockedDirection == 0x02)
						{
							globalmouseTileDownX = tileX = globalmouseTileDownXLOCK;
						}
			
						if (Control.ModifierKeys == Keys.Control)
						{
							if (selectedTile.Length >= 1)
							{
								int y = 0;
								int x = 0;
								for (int i = 0; i < selectedTile.Length; i++)
								{
									superX = ((tileX + x) / 32);
									superY = ((tileY + y) / 32);
									mapId = (superY * 8) + superX + ZS.OverworldManager.worldOffset;
			
									if (globalmouseTileDownX + x < 256 && globalmouseTileDownY + y < 256)
									{
										if (ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX + x, globalmouseTileDownY + y] == 52)
										{
											ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX + x, globalmouseTileDownY + y] = selectedTile[i];
											ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), selectedTile[i], ZS.OverworldManager.allmaps[mapId].gfxPtr, ZS.GFXManager.mapblockset16);
										}
									}
			
									x++;
									if (x >= selectedTileSizeX)
									{
										y++;
										x = 0;
									}
								}
							}
						}
						else
						{
							if (selectedTile.Length >= 1)
							{
								ushort[] undotiles = new ushort[selectedTile.Length];
								int y = 0;
								int x = 0;
			
								for (int i = 0; i < selectedTile.Length; i++)
								{
									superX = ((tileX + x) / 32);
									superY = ((tileY + y) / 32);
									mapId = (superY * 8) + superX + ZS.OverworldManager.worldOffset;
			
									if (globalmouseTileDownX + x < 256 && globalmouseTileDownY + y < 256)
									{
										undotiles[i] = ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX + x, globalmouseTileDownY + y];
										ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX + x, globalmouseTileDownY + y] = selectedTile[i];
										ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), selectedTile[i], ZS.OverworldManager.allmaps[mapId].gfxPtr, ZS.GFXManager.mapblockset16);
									}
			
									x++;
									if (x >= selectedTileSizeX)
									{
										y++;
										x = 0;
									}
								}
			
								undoList.Add(new TileUndo(globalmouseTileDownX, globalmouseTileDownY, selectedTileSizeX, undotiles, (ushort[]) selectedTile.Clone(), ref ZS.OverworldManager.allmaps[mapId].tilesUsed));
								redoList.Clear();
			
								//Invalidate(new Rectangle((globalmouseTileDownX * 16), globalmouseTileDownY * 16, selectedTileSizeX * 16, y * 16));
								// }
			
								/*
                                 else
                                 {
                                     ow.allmaps[mapId].tilesUsed[globalmouseTileDownX, globalmouseTileDownY] = selectedTile[0];
                                     ow.allmaps[mapId].CopyTile8bpp16(((tileX) * 16) - (superX * 512), ((tileY) * 16) - (superY * 512), selectedTile[0], ow.allmaps[mapId].gfxPtr, ow.allmaps[mapId].blockset16);
                                     this.Invalidate(new Rectangle(e.X - 16, e.Y - 16, 32, 32));
                                 }
                                 */
							}
						}
					}
				}
			
				// Refresh the tile preview
				if (selectedTile.Length >= 1)
				{
					int sX, sY;
					int y = 0;
					int x = 0;
					int mapId = 0 + ZS.OverworldManager.worldOffset;
			
					for (int i = 0; i < selectedTile.Length; i++)
					{
						if (globalmouseTileDownX + x < 255 && globalmouseTileDownY + y < 255)
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
								ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(x * 16, y * 16, selectedTile[i], temptilesgfxPtr, ZS.GFXManager.mapblockset16);
							}
						}
			
						x++;
						if (x >= selectedTileSizeX)
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
						tilesgfxBitmap.Palette = ZS.OverworldManager.allmaps[mapId].gfxBitmap.Palette;
					}
					//Invalidate(new Rectangle((ZS.OverworldManagerForm.splitContainer1.Panel2.HorizontalScroll.Value), (ZS.OverworldManagerForm.splitContainer1.Panel2.VerticalScroll.Value), (ZS.OverworldManagerForm.splitContainer1.Panel2.Width), (ZS.OverworldManagerForm.splitContainer1.Panel2.Height)));
					//Invalidate(new Rectangle(mainForm.panel5.HorizontalScroll.Value, mainForm.panel5.VerticalScroll.Value, mainForm.panel5.Width, mainForm.panel5.Height));
					//this.Refresh();
					//this.Invalidate(new Rectangle((mouseTileX * 16)-16, (mouseTileY * 16)-16, (selectedTileSizeX * 16)+32, (y * 16)+32));
				}
			
				/*
                 if (selecting)
                 {
                     this.Invalidate(new Rectangle((globalmouseTileDownX * 16), (globalmouseTileDownY * 16), (mouseTileX * 16) - (globalmouseTileDownX * 16) + 48, (mouseTileY * 16) - (globalmouseTileDownY * 16) + 48));
                 }
                 */
			
				lastTileHoverX = mouseTileX;
				lastTileHoverY = mouseTileY;
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
}
