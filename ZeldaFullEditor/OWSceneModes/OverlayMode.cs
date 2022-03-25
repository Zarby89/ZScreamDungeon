using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.OWSceneModes.ClipboardData;

namespace ZeldaFullEditor.OWSceneModes
{
	public class OverlayMode
	{
		private readonly ZScreamer ZS;
		public OverlayMode(ZScreamer parent)
		{
			ZS = parent;
		}

		public void OnMouseDown(MouseEventArgs e)
		{
			if (!ZS.OverworldScene.mouse_down)
			{
				int tileX = (e.X / 16);
				int tileY = (e.Y / 16);
				int superX = (tileX / 32);
				int superY = (tileY / 32);
				int mapId = (superY * 8) + superX;
				ZS.OverworldScene.globalmouseTileDownX = tileX;
				ZS.OverworldScene.globalmouseTileDownY = tileY;

				ZS.OverworldScene.selectedMap = mapId + ZS.OverworldManager.worldOffset;
				ZS.OverworldScene.selectedMapParent = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap + ZS.OverworldManager.worldOffset].parent;

				int mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent;
				int superMX = (mid % 8) * 32;
				int superMY = (mid / 8) * 32;

				ZS.OverworldScene.tileBitmapPtr = ZS.GFXManager.mapblockset16;
				ZS.OverworldScene.tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, ZS.OverworldScene.tileBitmapPtr);
				ZS.OverworldScene.tileBitmap.Palette = ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[mapId].parent].gfxBitmap.Palette;

				if (ZS.OverworldScene.needRedraw)
				{
					ZS.OverworldScene.needRedraw = false;
					return;
				}

				ZS.OverworldScene.mouse_down = true;

				if (e.Button == MouseButtons.Left)
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

							/*
                            undotiles[i] = scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
                            scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
                            scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);
                            */

							TilePos tp = new TilePos((byte) ((ZS.OverworldScene.globalmouseTileDownX + x) - (superMX)), (byte) ((ZS.OverworldScene.globalmouseTileDownY + y) - (superMY)), ZS.OverworldScene.selectedTile[i]);
							TilePos tf = ZS.OverworldScene.compareTilePosT(tp, ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());

							if (ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].largeMap)
							{
								tp = new TilePos((byte) ((ZS.OverworldScene.globalmouseTileDownX + x) - (superMX)), (byte) ((ZS.OverworldScene.globalmouseTileDownY + y) - (superMY)), ZS.OverworldScene.selectedTile[i]);
								tf = ZS.OverworldScene.compareTilePosT(tp, ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());

							}

							if (Control.ModifierKeys == Keys.Control)
							{
								ZS.OverworldManager.alloverlays[mid].tilesData.Remove(tf);
								x++;
								if (x >= ZS.OverworldScene.selectedTileSizeX)
								{
									y++;
									x = 0;
								}

								continue;
							}

							if (tf == null)
							{
								ZS.OverworldManager.alloverlays[mid].tilesData.Add(tp);
							}
							else
							{
								ZS.OverworldManager.alloverlays[mid].tilesData.Remove(tf);
								ZS.OverworldManager.alloverlays[mid].tilesData.Add(tp);
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
				else if (e.Button == MouseButtons.Right)
				{
					ZS.OverworldScene.selecting = true;
				}
			}
		}

		public void OnMouseUp(MouseEventArgs e)
		{
			if (ZS.OverworldScene.mouse_down)
			{
				int tileX = (e.X / 16);
				int tileY = (e.Y / 16);
				int superX = (tileX / 32);
				int superY = (tileY / 32);
				int mapId = (superY * 8) + superX + ZS.OverworldManager.worldOffset;
				int mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent;
				int superMX = (mid % 8) * 32;
				int superMY = (mid / 8) * 32;

				if (e.Button == MouseButtons.Right)
				{
					if (tileX == ZS.OverworldScene.globalmouseTileDownX && tileY == ZS.OverworldScene.globalmouseTileDownY)
					{
						TilePos tp = new TilePos((byte) (tileX - (superMX)), (byte) (tileY - (superMY)), 0);
						TilePos tf = ZS.OverworldScene.compareTilePosT(tp, ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());

						if (tf == null)
						{
							if (tileX == ZS.OverworldScene.globalmouseTileDownX && tileY == ZS.OverworldScene.globalmouseTileDownY)
							{
								ZS.OverworldScene.selectedTile = new ushort[1] {
									ZS.OverworldManager.allmaps[mapId].tilesUsed[ZS.OverworldScene.globalmouseTileDownX, ZS.OverworldScene.globalmouseTileDownY]
								};
								ZS.OverworldScene.selectedTileSizeX = 1;
							}
						}
						else
						{
							ZS.OverworldScene.selectedTile = new ushort[1] { tf.tileId };
							ZS.OverworldScene.selectedTileSizeX = 1;
						}
					}
					else
					{
						bool reverseX = tileX < ZS.OverworldScene.globalmouseTileDownX;
						bool reverseY = tileY < ZS.OverworldScene.globalmouseTileDownY;

						int sizeX, sizeY;

						if (reverseX)
						{
							sizeX = (ZS.OverworldScene.globalmouseTileDownX - tileX) + 1;
						}
						else
						{
							sizeX = (tileX - ZS.OverworldScene.globalmouseTileDownX) + 1;
						}

						if (reverseY)
						{
							sizeY = (ZS.OverworldScene.globalmouseTileDownY - tileY) + 1;
						}
						else
						{
							sizeY = (tileY - ZS.OverworldScene.globalmouseTileDownY) + 1;
						}

						ZS.OverworldScene.selectedTileSizeX = sizeX;
						ZS.OverworldScene.selectedTile = new ushort[sizeX * sizeY];
						for (int y = 0; y < sizeY; y++)
						{
							for (int x = 0; x < sizeX; x++)
							{
								int pX = reverseX ? tileX : ZS.OverworldScene.globalmouseTileDownX;
								int pY = reverseY ? tileY : ZS.OverworldScene.globalmouseTileDownY;

								ZS.OverworldScene.selectedTile[x + (y * sizeX)] = ZS.OverworldManager.allmaps[mapId].tilesUsed[(pX) + x, (pY) + y];
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

			//scene.Refresh();
			//scene.mainForm.pictureboxOWTiles.Refresh();
			//scene.mainForm.pictureGroupTiles.Refresh();
		}

		public void OnMouseMove(MouseEventArgs e)
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
							int mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent;
							int superMX = (mid % 8) * 32;
							int superMY = (mid / 8) * 32;

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
									if (ZS.OverworldScene.globalmouseTileDownX + x < 255 && ZS.OverworldScene.globalmouseTileDownY + y < 255)
									{
										/*
                                        undotiles[i] = scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
                                        scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
                                        scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);
                                        */

										TilePos tp = new TilePos((byte) (tileX - (superMX) + x), (byte) (tileY - (superMY) + y), ZS.OverworldScene.selectedTile[i]);
										TilePos tf = ZS.OverworldScene.compareTilePosT(tp, ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());
										if (Control.ModifierKeys == Keys.Control)
										{
											ZS.OverworldManager.alloverlays[mid].tilesData.Remove(tf);
											x++;
											if (x >= ZS.OverworldScene.selectedTileSizeX)
											{
												y++;
												x = 0;
											}

											continue;
										}

										if (tf == null)
										{
											ZS.OverworldManager.alloverlays[mid].tilesData.Add(tp);
										}
										else
										{
											ZS.OverworldManager.alloverlays[mid].tilesData.Remove(tf);
											ZS.OverworldManager.alloverlays[mid].tilesData.Add(tp);
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
					}

					ZS.OverworldScene.lastTileHoverX = mouseTileX;
					ZS.OverworldScene.lastTileHoverY = mouseTileY;

					// Refresh the tile preview
					if (ZS.OverworldScene.selectedTile.Length >= 1)
					{
						int sX = (mouseTileX / 32);
						int sY = (mouseTileY / 32);
						int y = 0;
						int x = 0;
						int mapId = ZS.OverworldManager.worldOffset;

						for (int i = 0; i < ZS.OverworldScene.selectedTile.Length; i++)
						{
							if (ZS.OverworldScene.globalmouseTileDownX + x < 255 && ZS.OverworldScene.globalmouseTileDownY + y < 255)
							{
								sX = ((mouseTileX + x) / 32);
								sY = ((mouseTileY + y) / 32);
								mapId = (sY * 8) + sX + ZS.OverworldManager.worldOffset;

								if (mapId > 63 + ZS.OverworldManager.worldOffset)
								{
									break;
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

						//scene.Invalidate(new Rectangle((scene.owForm.splitContainer1.Panel2.HorizontalScroll.Value), (scene.owForm.splitContainer1.Panel2.VerticalScroll.Value), (scene.owForm.splitContainer1.Panel2.Width), (scene.owForm.splitContainer1.Panel2.Height)));
						//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
						//this.Refresh();
						//this.Invalidate(new Rectangle((mouseTileX * 16)-16, (mouseTileY * 16)-16, (selectedTileSizeX * 16)+32, (y * 16)+32));
					}
				}
			}
		}
	}
}
