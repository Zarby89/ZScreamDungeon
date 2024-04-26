using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Documents;
using System.Windows.Forms;
using Lidgren.Network;
using ZeldaFullEditor.Gui.ExtraForms;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.OWSceneModes
{
	public class TileMode
	{
		SceneOW scene;
		List<TileUndo> undoList = new List<TileUndo>();
		List<TileUndo> redoList = new List<TileUndo>();

		int globalmouseTileDownXLOCK = 0;
		int globalmouseTileDownYLOCK = 0;

		byte lockedDirection = 0x00;
		Stopwatch sw = new Stopwatch();

		public TileMode(SceneOW scene)
		{
			this.scene = scene;
		}

		public void Undo()
		{
			if (undoList.Count > 0)
			{
				undoList[undoList.Count - 1].Restore(scene);
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
				redoList[redoList.Count - 1].RestoreRedo(scene);
				TileUndo tundo = (TileUndo) redoList[redoList.Count - 1].Clone();
				tundo.usedTiles = redoList[redoList.Count - 1].usedTiles;
				undoList.Add(tundo);
				redoList.RemoveAt(redoList.Count - 1);
			}
		}

		public void Copy()
		{
			Clipboard.Clear();
			//TileData td = new TileData((ushort[]) scene.selectedTile.Clone(), scene.selectedTileSizeX);
			//Clipboard.SetData("owtiles", td);
			string c = "ZSTD";
			c += scene.selectedTileSizeX.ToString("X4");

			for (int i = 0; i < scene.selectedTile.Length; i++)
			{
				c += scene.selectedTile[i].ToString("X4");
			}

			Clipboard.SetText(c);
		}

		public void Paste()
		{
			/*TileData data = (TileData) Clipboard.GetData("owtiles");
			Console.WriteLine("Paste ! " + data);
			if (data != null)
			{
				scene.selectedTile = data.tiles;
				scene.selectedTileSizeX = data.length;
			}*/
			string c = Clipboard.GetText();
			if (c.Length < 5)
			{
				return;
			}
			if (c.Substring(0, 4) == "ZSTD")
			{
				int p = 8;
				scene.selectedTileSizeX = int.Parse(c.Substring(4, 4), NumberStyles.HexNumber);
				scene.selectedTile = new ushort[((c.Length - 8) / 4)];
				for (int i = 0; i < ((c.Length - 8) / 4); i++)
				{
					scene.selectedTile[i] = ushort.Parse(c.Substring(p, 4), NumberStyles.HexNumber);
					p += 4;
				}
			}

		}

		public void OnMouseDown(MouseEventArgs e)
		{
			//Buildtileset();
			//BuildTiles16Gfx();

			if (!scene.mouse_down)
			{
				int tileX = (e.X / 16);
				int tileY = (e.Y / 16);
                lastTileX = tileX;
                lastTileY = tileY;
                int superX = (tileX / 32);
				int superY = (tileY / 32);
				int mapId = (superY * 8) + superX;
				scene.globalmouseTileDownX = tileX;
				scene.globalmouseTileDownY = tileY;
				globalmouseTileDownXLOCK = tileX;
				globalmouseTileDownYLOCK = tileY;

				scene.selectedMap = mapId + scene.ow.WorldOffset;
				scene.selectedMapParent = scene.ow.AllMaps[scene.selectedMap].ParentID;
				//scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].BuildMap();

				scene.tileBitmapPtr = GFX.mapblockset16;
				scene.tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, scene.tileBitmapPtr);
				scene.tileBitmap.Palette = scene.ow.AllMaps[scene.ow.AllMaps[mapId].ParentID].GFXBitmap.Palette;

				if (scene.selectedMap >= 160)
				{
					return;
				}

				if (scene.needRedraw)
				{
					scene.needRedraw = false;
					return;
				}

				scene.mouse_down = true;

				if (e.Button == MouseButtons.Left)
				{
					if (Control.ModifierKeys == Keys.Control)
					{
						if (scene.selectedTile.Length >= 1)
						{
							int y = 0;
							int x = 0;
							ushort[] undotiles = new ushort[scene.selectedTile.Length];

							for (int i = 0; i < scene.selectedTile.Length; i++)
							{
								superX = ((tileX + x) / 32);
								superY = ((tileY + y) / 32);
								mapId = (superY * 8) + superX + scene.ow.WorldOffset;
								if (scene.ow.AllMaps[mapId].TilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] == 52)
								{
									scene.ow.AllMaps[mapId].TilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
									scene.ow.AllMaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.AllMaps[mapId].GFXPointer, GFX.mapblockset16);
								}

								x++;
								if (x >= scene.selectedTileSizeX)
								{
									y++;
									x = 0;
								}
							}
						}
						else
						{
							if (scene.ow.AllMaps[mapId].TilesUsed[scene.globalmouseTileDownX, scene.globalmouseTileDownY] == 52)
							{
								scene.ow.AllMaps[mapId].TilesUsed[scene.globalmouseTileDownX, scene.globalmouseTileDownY] = scene.selectedTile[0];
								scene.ow.AllMaps[mapId].CopyTile8bpp16(((tileX) * 16) - (superX * 512), ((tileY) * 16) - (superY * 512), scene.selectedTile[0], scene.ow.AllMaps[mapId].GFXPointer, GFX.mapblockset16);

								//scene.Invalidate(new Rectangle(e.X - 16, e.Y - 16, 32,  32));
							}
						}
					}
					else
					{
						if (scene.selectedTile.Length >= 1)
						{
							SendTileData();


							int y = 0;
							int x = 0;
							ushort[] undotiles = new ushort[scene.selectedTile.Length];

							for (int i = 0; i < scene.selectedTile.Length; i++)
							{
								superX = ((tileX + x) / 32);
								superY = ((tileY + y) / 32);
								mapId = (superY * 8) + superX + scene.ow.WorldOffset;
								undotiles[i] = scene.ow.AllMaps[mapId].TilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
								scene.ow.AllMaps[mapId].TilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
								scene.ow.AllMaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.AllMaps[mapId].GFXPointer, GFX.mapblockset16);

								x++;
								if (x >= scene.selectedTileSizeX)
								{
									y++;
									x = 0;
								}
							}

							undoList.Add(new TileUndo(scene.globalmouseTileDownX, scene.globalmouseTileDownY, scene.selectedTileSizeX, undotiles, (ushort[]) scene.selectedTile.Clone(), ref scene.ow.AllMaps[mapId].TilesUsed));
							redoList.Clear();
						}
						else
						{
							undoList.Add(new TileUndo(scene.globalmouseTileDownX, scene.globalmouseTileDownY, 1, new ushort[] { scene.ow.AllMaps[mapId].TilesUsed[scene.globalmouseTileDownX, scene.globalmouseTileDownY] }, (ushort[]) scene.selectedTile.Clone(), ref scene.ow.AllMaps[mapId].TilesUsed));
							redoList.Clear();
							scene.ow.AllMaps[mapId].TilesUsed[scene.globalmouseTileDownX, scene.globalmouseTileDownY] = scene.selectedTile[0];
							scene.ow.AllMaps[mapId].CopyTile8bpp16(((tileX) * 16) - (superX * 512), ((tileY) * 16) - (superY * 512), scene.selectedTile[0], scene.ow.AllMaps[mapId].GFXPointer, GFX.mapblockset16);

							//scene.Invalidate(new Rectangle(e.X - 16, e.Y - 16, 32,  32));
						}
					}
				}
				else if (e.Button == MouseButtons.Right)
				{
					scene.selecting = true;
					scene.owForm.selectedTileLabel.Text = "Selected Tile : " + scene.selectedTile[0].ToString("X4");
				}
			}
		}

		public void OnMouseUp(MouseEventArgs e)
		{
			if (scene.mouse_down)
			{
				int tileX = (e.X / 16);
				int tileY = (e.Y / 16);
				int superX = (tileX / 32);
				int superY = (tileY / 32);
				int mapId = (superY * 8) + superX + scene.ow.WorldOffset;
				lockedDirection = 0x00;

				if (e.Button == MouseButtons.Right)
				{
					if (tileX == scene.globalmouseTileDownX && tileY == scene.globalmouseTileDownY)
					{
						scene.selectedTile = new ushort[1] { scene.ow.AllMaps[mapId].TilesUsed[scene.globalmouseTileDownX, scene.globalmouseTileDownY] };
						scene.selectedTileSizeX = 1;
					}
					else
					{
						bool reverseX = false;
						bool reverseY = false;
						int sizeX = (tileX - scene.globalmouseTileDownX) + 1;
						int sizeY = (tileY - scene.globalmouseTileDownY) + 1;

						if (tileX < scene.globalmouseTileDownX)
						{
							sizeX = (scene.globalmouseTileDownX - tileX) + 1;
							reverseX = true;
						}

						if (tileY < scene.globalmouseTileDownY)
						{
							sizeY = (scene.globalmouseTileDownY - tileY) + 1;
							reverseY = true;
						}

						scene.selectedTileSizeX = sizeX;
						scene.selectedTile = new ushort[(sizeX) * (sizeY)];
						for (int y = 0; y < sizeY; y++)
						{
							for (int x = 0; x < sizeX; x++)
							{
								int pX = scene.globalmouseTileDownX;
								int pY = scene.globalmouseTileDownY;

								if (reverseX) { pX = tileX; }
								if (reverseY) { pY = tileY; }
								scene.selectedTile[x + (y * sizeX)] =
									scene.ow.AllMaps[mapId].TilesUsed[(pX) + x, (pY) + y];
							}
						}
					}

					if (scene.selectedTile.Length > 0)
					{
						int scrollpos = ((scene.selectedTile[0] / 8) * 16);
						if (scrollpos >= scene.owForm.splitContainer1.Panel1.VerticalScroll.Maximum)
						{
							scene.owForm.splitContainer1.Panel1.VerticalScroll.Value = scene.owForm.splitContainer1.Panel1.VerticalScroll.Maximum;
						}
						else
						{
							scene.owForm.splitContainer1.Panel1.VerticalScroll.Value = scrollpos;
						}
					}

					scene.owForm.AdjustTile16BoxScrollBar();
				}
			}

			scene.selecting = false;
			scene.mouse_down = false;

			//scene.Refresh();
			//scene.mainForm.pictureboxOWTiles.Refresh();
			//scene.mainForm.pictureGroupTiles.Refresh();
		}
		int lastTileX;
		int lastTileY;
        public void OnMouseMove(MouseEventArgs e)
		{
			if (scene.initialized)
			{
				scene.mouseX_Real = e.X;
				scene.mouseY_Real = e.Y;
				int mouseTileX = e.X / 16;
				int mouseTileY = e.Y / 16;

				int mapX = (mouseTileX / 32);
				int mapY = (mouseTileY / 32);

				scene.mapHover = mapX + (mapY * 8);

				if (scene.mapHover + scene.ow.WorldOffset >= 160)
				{
					return;
				}

				if (scene.lastHover != scene.mapHover)
				{
					scene.ow.AllMaps[scene.mapHover + scene.ow.WorldOffset].BuildMap();
					scene.lastHover = scene.mapHover;
				}

				if (scene.lastTileHoverX != mouseTileX || scene.lastTileHoverY != mouseTileY)
				{
					if (scene.mouse_down)
					{
						if (e.Button == MouseButtons.Left)
						{
							int tileX = (e.X / 16);
							int tileY = (e.Y / 16);
							if (tileX < 0) { tileX = 0; }
							if (tileY < 0) { tileY = 0; }
							if (tileX > 255) { tileX = 255; }
							if (tileY > 255) { tileY = 255; }
							int superX = (tileX / 32);
							int superY = (tileY / 32);
							int mapId = (superY * 8) + superX;
							scene.globalmouseTileDownX = tileX;
							scene.globalmouseTileDownY = tileY;

							if (Control.ModifierKeys == Keys.Shift)
							{
								if (lockedDirection == 0x00)
								{
									if (scene.lastTileHoverX != mouseTileX)
									{
										lockedDirection = 0x01;
									}
									if (scene.lastTileHoverY != mouseTileY)
									{
										lockedDirection = 0x02;
									}
								}
							}

							if (lockedDirection == 0x01)
							{
								scene.globalmouseTileDownY = tileY = globalmouseTileDownYLOCK;
							}
							if (lockedDirection == 0x02)
							{
								scene.globalmouseTileDownX = tileX = globalmouseTileDownXLOCK;
							}

							if (Control.ModifierKeys == Keys.Control)
							{
								if (scene.selectedTile.Length >= 1)
								{
									ushort[] undotiles = new ushort[scene.selectedTile.Length];
									int y = 0;
									int x = 0;
									for (int i = 0; i < scene.selectedTile.Length; i++)
									{
										superX = ((tileX + x) / 32);
										superY = ((tileY + y) / 32);
										mapId = (superY * 8) + superX + scene.ow.WorldOffset;

										if (scene.globalmouseTileDownX + x < 256 && scene.globalmouseTileDownY + y < 256)
										{
											if (scene.ow.AllMaps[mapId].TilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] == 52)
											{
												scene.ow.AllMaps[mapId].TilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
												scene.ow.AllMaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.AllMaps[mapId].GFXPointer, GFX.mapblockset16);
											}
										}

										x++;
										if (x >= scene.selectedTileSizeX)
										{
											y++;
											x = 0;
										}
									}
								}
							}
							else
                            {
								if (scene.selectedTile.Length >= 1)
								{
									IEnumerable<Point> points = DrawLine.GetPointsOnLine(lastTileX, lastTileY, mouseTileX, mouseTileY);
									ushort[] undotiles = new ushort[scene.selectedTile.Length];
									int y = 0;
									int x = 0;




									//SendTileDataMove(p.X, p.Y);
									for (int i = 0; i < scene.selectedTile.Length; i++)
									{
										foreach (Point p in points)
										{
											superX = ((p.X + x) / 32);
											superY = ((p.Y + y) / 32);
											mapId = (superY * 8) + superX + scene.ow.WorldOffset;


											if (p.X + x < 256 && p.Y + y < 256 && p.X >= 0 && p.Y >= 0)
											{

												undotiles[i] = scene.ow.AllMaps[mapId].TilesUsed[p.X + x, p.Y + y];
												scene.ow.AllMaps[mapId].TilesUsed[p.X + x, p.Y + y] = scene.selectedTile[i];

												scene.ow.AllMaps[mapId].CopyTile8bpp16(((p.X + x) * 16) - (superX * 512), ((p.Y + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.AllMaps[mapId].GFXPointer, GFX.mapblockset16);
											}
										}

										x++;
										if (x >= scene.selectedTileSizeX)
										{
											y++;
											x = 0;
										}
									}
								

									lastTileX = mouseTileX;
									lastTileY = mouseTileY;

									//undoList.Add(new TileUndo(scene.globalmouseTileDownX, scene.globalmouseTileDownY, scene.selectedTileSizeX, undotiles, (ushort[]) scene.selectedTile.Clone(), ref scene.ow.AllMaps[mapId].TilesUsed));
									//redoList.Clear();

									//scene.Invalidate(new Rectangle((scene.globalmouseTileDownX * 16), scene.globalmouseTileDownY * 16, scene.selectedTileSizeX * 16, y * 16));
									// }

									/*
                                    else
                                    {
                                        ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX, scene.globalmouseTileDownY] = selectedTile[0];
                                        ow.allmaps[mapId].CopyTile8bpp16(((tileX) * 16) - (superX * 512), ((tileY) * 16) - (superY * 512), selectedTile[0], ow.allmaps[mapId].gfxPtr, ow.allmaps[mapId].blockset16);
                                        this.Invalidate(new Rectangle(e.X - 16, e.Y - 16, 32, 32));
                                    }
                                    */
								}
							}
						}
					}

					// Refresh the tile preview
					if (scene.selectedTile.Length >= 1)
					{
						int sX = (mouseTileX / 32);
						int sY = (mouseTileY / 32);
						int y = 0;
						int x = 0;
						int mapId = 0 + scene.ow.WorldOffset;






						for (int i = 0; i < scene.selectedTile.Length; i++)
						{
							if (scene.globalmouseTileDownX + x < 255 && scene.globalmouseTileDownY + y < 255)
							{
								sX = ((mouseTileX + x) / 32);
								sY = ((mouseTileY + y) / 32);
								mapId = (sY * 8) + sX + scene.ow.WorldOffset;

								if (mapId > 63 + scene.ow.WorldOffset)
								{
									break;
								}
								if (mapId <= 159)
								{
									scene.ow.AllMaps[mapId].CopyTile8bpp16(x * 16, y * 16, scene.selectedTile[i], scene.temptilesgfxPtr, GFX.mapblockset16);
								}
							}

							x++;
							if (x >= scene.selectedTileSizeX)
							{

								y++;
								x = 0;
							}
						}

						if (mapId > 63 + scene.ow.WorldOffset)
						{
							return;
						}
						if (mapId <= 159)
						{
							scene.tilesgfxBitmap.Palette = scene.ow.AllMaps[mapId].GFXBitmap.Palette;
						}
						//scene.Invalidate(new Rectangle((scene.owForm.splitContainer1.Panel2.HorizontalScroll.Value), (scene.owForm.splitContainer1.Panel2.VerticalScroll.Value), (scene.owForm.splitContainer1.Panel2.Width), (scene.owForm.splitContainer1.Panel2.Height)));
						//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
						//this.Refresh();
						//this.Invalidate(new Rectangle((mouseTileX * 16)-16, (mouseTileY * 16)-16, (selectedTileSizeX * 16)+32, (y * 16)+32));
					}

					/*
                    if (selecting)
                    {
                        this.Invalidate(new Rectangle((globalmouseTileDownX * 16), (globalmouseTileDownY * 16), (mouseTileX * 16) - (globalmouseTileDownX * 16) + 48, (mouseTileY * 16) - (globalmouseTileDownY * 16) + 48));
                    }
                    */

					scene.lastTileHoverX = mouseTileX;
					scene.lastTileHoverY = mouseTileY;
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



		private void SendTileData()
		{
			if (!NetZS.connected) { return; }
			NetZSBuffer buffer = new NetZSBuffer((short) (24 + (scene.selectedTile.Length * 2)));
			buffer.Write((byte) 04); // tile data cmd
			buffer.Write(NetZS.userID); // user id
			buffer.Write(scene.globalmouseTileDownX);
			buffer.Write(scene.globalmouseTileDownY);
			buffer.Write(scene.selectedTileSizeX);
			buffer.Write((byte) scene.ow.WorldOffset);
			buffer.Write(scene.selectedTile.Length);
			for (int i = 0; i < scene.selectedTile.Length; i++)
			{
				buffer.Write(scene.selectedTile[i]);
			}
			// write tiles
			NetOutgoingMessage msg = NetZS.client.CreateMessage();
			msg.Write(buffer.buffer);
			NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
			NetZS.client.FlushSendQueue();

		}


		private void SendTileDataMove(int tileX, int tileY)
		{
			if (!NetZS.connected) { return; }



			NetZSBuffer buffer = new NetZSBuffer((short) (24 + (scene.selectedTile.Length * 2)));
			buffer.Write((byte) 05); // tile data cmd
			buffer.Write(NetZS.userID); // user id
			buffer.Write(tileX);
			buffer.Write(tileY);
			buffer.Write(scene.selectedTileSizeX);
			buffer.Write((byte) scene.ow.WorldOffset); // tile data cmd
			buffer.Write(scene.selectedTile.Length);
			for (int i = 0; i < scene.selectedTile.Length; i++)
			{
				buffer.Write(scene.selectedTile[i]);
			}
			// write tiles
			NetOutgoingMessage msg = NetZS.client.CreateMessage();
			msg.Write(buffer.buffer);
			NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
			NetZS.client.FlushSendQueue();

		}
	}
}
