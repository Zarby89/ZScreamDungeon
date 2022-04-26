using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	public partial class SceneOW
	{
		private void OnMouseDown_Overlay(MouseEventArgs e)
		{
			if (!mouse_down)
			{
				int tileX = (e.X / 16);
				int tileY = (e.Y / 16);
				int superX = (tileX / 32);
				int superY = (tileY / 32);
				int mapId = (superY * 8) + superX;
				globalmouseTileDownX = tileX;
				globalmouseTileDownY = tileY;

				selectedMap = mapId + ZS.OverworldManager.worldOffset;
				selectedMapParent = ZS.OverworldManager.allmaps[selectedMap + ZS.OverworldManager.worldOffset].parent;

				int mid = ZS.OverworldManager.allmaps[selectedMap].parent;
				int superMX = (mid % 8) * 32;
				int superMY = (mid / 8) * 32;

				tileBitmapPtr = ZS.GFXManager.mapblockset16;
				tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, tileBitmapPtr);
				tileBitmap.Palette = ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[mapId].parent].gfxBitmap.Palette;

				if (needRedraw)
				{
					needRedraw = false;
					return;
				}

				mouse_down = true;

				if (e.Button == MouseButtons.Left)
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

							/*
                            undotiles[i] = scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
                            scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
                            scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);
                            */

							TilePos tp = new TilePos((byte) ((globalmouseTileDownX + x) - (superMX)), (byte) ((globalmouseTileDownY + y) - (superMY)), selectedTile[i]);
							TilePos tf = compareTilePosT(tp, ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());

							if (ZS.OverworldManager.allmaps[selectedMap].largeMap)
							{
								tp = new TilePos((byte) ((globalmouseTileDownX + x) - (superMX)), (byte) ((globalmouseTileDownY + y) - (superMY)), selectedTile[i]);
								tf = compareTilePosT(tp, ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());

							}

							if (Control.ModifierKeys == Keys.Control)
							{
								ZS.OverworldManager.alloverlays[mid].tilesData.Remove(tf);
								x++;
								if (x >= selectedTileSizeX)
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
							if (x >= selectedTileSizeX)
							{
								y++;
								x = 0;
							}
						}
					}

				}
				else if (e.Button == MouseButtons.Right)
				{
					selecting = true;
				}
			}
		}

		private void OnMouseUp_Overlay(MouseEventArgs e)
		{
			if (mouse_down)
			{
				int tileX = (e.X / 16);
				int tileY = (e.Y / 16);
				int superX = (tileX / 32);
				int superY = (tileY / 32);
				int mapId = (superY * 8) + superX + ZS.OverworldManager.worldOffset;
				int mid = ZS.OverworldManager.allmaps[selectedMap].parent;
				int superMX = (mid % 8) * 32;
				int superMY = (mid / 8) * 32;

				if (e.Button == MouseButtons.Right)
				{
					if (tileX == globalmouseTileDownX && tileY == globalmouseTileDownY)
					{
						TilePos tp = new TilePos((byte) (tileX - (superMX)), (byte) (tileY - (superMY)), 0);
						TilePos tf = compareTilePosT(tp, ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());

						if (tf == null)
						{
							if (tileX == globalmouseTileDownX && tileY == globalmouseTileDownY)
							{
								selectedTile = new ushort[1] {
									ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX, globalmouseTileDownY]
								};
								selectedTileSizeX = 1;
							}
						}
						else
						{
							selectedTile = new ushort[1] { tf.tileId };
							selectedTileSizeX = 1;
						}
					}
					else
					{
						bool reverseX = tileX < globalmouseTileDownX;
						bool reverseY = tileY < globalmouseTileDownY;

						int sizeX, sizeY;

						if (reverseX)
						{
							sizeX = (globalmouseTileDownX - tileX) + 1;
						}
						else
						{
							sizeX = (tileX - globalmouseTileDownX) + 1;
						}

						if (reverseY)
						{
							sizeY = (globalmouseTileDownY - tileY) + 1;
						}
						else
						{
							sizeY = (tileY - globalmouseTileDownY) + 1;
						}

						selectedTileSizeX = sizeX;
						selectedTile = new ushort[sizeX * sizeY];
						int pX = reverseX ? tileX : globalmouseTileDownX;
						int pY = reverseY ? tileY : globalmouseTileDownY;
						for (int y = 0; y < sizeY; y++)
						{
							for (int x = 0; x < sizeX; x++)
							{

								selectedTile[x + (y * sizeX)] = ZS.OverworldManager.allmaps[mapId].tilesUsed[pX + x, pY + y];
							}
						}
					}
					if (selectedTile.Length > 0)
					{
						int scrollpos = ((selectedTile[0] / 8) * 16);
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

			selecting = false;
			mouse_down = false;

			//scene.Refresh();
			//scene.mainForm.pictureboxOWTiles.Refresh();
			//scene.mainForm.pictureGroupTiles.Refresh();
		}

		private void OnMouseMove_Overlay(MouseEventArgs e)
		{
			if (initialized)
			{
				mouseX_Real = e.X;
				mouseY_Real = e.Y;
				int mouseTileX = e.X / 16;
				int mouseTileY = e.Y / 16;
				int mapX = (mouseTileX / 32);
				int mapY = (mouseTileY / 32);

				mapHover = mapX + (mapY * 8);

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
							int mid = ZS.OverworldManager.allmaps[selectedMap].parent;
							int superMX = (mid % 8) * 32;
							int superMY = (mid / 8) * 32;

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
									if (globalmouseTileDownX + x < 255 && globalmouseTileDownY + y < 255)
									{
										/*
                                        undotiles[i] = scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
                                        scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
                                        scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);
                                        */

										TilePos tp = new TilePos((byte) (tileX - (superMX) + x), (byte) (tileY - (superMY) + y), selectedTile[i]);
										TilePos tf = compareTilePosT(tp, ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());
										if (Control.ModifierKeys == Keys.Control)
										{
											ZS.OverworldManager.alloverlays[mid].tilesData.Remove(tf);
											x++;
											if (x >= selectedTileSizeX)
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
									if (x >= selectedTileSizeX)
									{
										y++;
										x = 0;
									}
								}
							}
						}
					}

					lastTileHoverX = mouseTileX;
					lastTileHoverY = mouseTileY;

					// Refresh the tile preview
					if (selectedTile.Length >= 1)
					{
						int sX = (mouseTileX / 32);
						int sY = (mouseTileY / 32);
						int y = 0;
						int x = 0;
						int mapId = ZS.OverworldManager.worldOffset;

						for (int i = 0; i < selectedTile.Length; i++)
						{
							if (globalmouseTileDownX + x < 255 && globalmouseTileDownY + y < 255)
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

						//scene.Invalidate(new Rectangle((scene.owForm.splitContainer1.Panel2.HorizontalScroll.Value), (scene.owForm.splitContainer1.Panel2.VerticalScroll.Value), (scene.owForm.splitContainer1.Panel2.Width), (scene.owForm.splitContainer1.Panel2.Height)));
						//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
						//this.Refresh();
						//this.Invalidate(new Rectangle((mouseTileX * 16)-16, (mouseTileY * 16)-16, (selectedTileSizeX * 16)+32, (y * 16)+32));
					}
				}
			}
		}

		// TODO
		private void Copy_Overlay()
		{
			throw new NotImplementedException();
		}

		private void Cut_Overlay()
		{
			throw new NotImplementedException();
		}

		private void Paste_Overlay()
		{
			throw new NotImplementedException();
		}

		private void Delete_Overlay()
		{
			throw new NotImplementedException();
		}
	}
}
