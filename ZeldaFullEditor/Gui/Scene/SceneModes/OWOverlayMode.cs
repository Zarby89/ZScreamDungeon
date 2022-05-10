namespace ZeldaFullEditor
{
	public partial class SceneOW
	{
		private void OnMouseDown_Overlay(MouseEventArgs e)
		{
			int tileX = e.X / 16;
			int tileY = e.Y / 16;
			int superX = tileX / 32;
			int superY = tileY / 32;
			int mapId = (superY * 8) + superX;
			globalmouseTileDownX = tileX;
			globalmouseTileDownY = tileY;

			CurrentMap = mapId + ZS.OverworldManager.WorldOffset;
			CurrentMapParent = ZS.OverworldManager.allmaps[CurrentMap + ZS.OverworldManager.WorldOffset].ParentMapID;

			int mid = ZS.OverworldManager.allmaps[CurrentMap].ParentMapID;
			int superMX = mid % 8 * 32;
			int superMY = mid / 8 * 32;

			tileBitmapPtr = ZS.GFXManager.mapblockset16;
			tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, tileBitmapPtr)
			{
				Palette = ZS.OverworldManager.allmaps[mapId].MyArtist.Layer1Canvas.Palette
			};

			if (TriggerRefresh)
			{
				TriggerRefresh = false;
				return;
			}

			if (e.Button == MouseButtons.Left)
			{
				if (selectedTile.Length >= 1)
				{
					int y = 0;
					int x = 0;
					ushort[] undotiles = new ushort[selectedTile.Length];
					for (int i = 0; i < selectedTile.Length; i++)
					{
						superX = (tileX + x) / 32;
						superY = (tileY + y) / 32;

						/*
                          undotiles[i] = scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
                          scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
                          scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);
                          */

						OverlayTile tp = new OverlayTile((byte) (globalmouseTileDownX + x - superMX), (byte) (globalmouseTileDownY + y - superMY), selectedTile[i]);
						OverlayTile tf = compareTilePosT(tp, ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());

						if (ZS.OverworldManager.allmaps[CurrentMap].IsPartOfLargeMap)
						{
							tp = new OverlayTile((byte) (globalmouseTileDownX + x - superMX), (byte) (globalmouseTileDownY + y - superMY), selectedTile[i]);
							tf = compareTilePosT(tp, ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());
						}

						if (ModifierKeys == Keys.Control)
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

						if (tf.IsGarbage)
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

		private void OnMouseUp_Overlay(MouseEventArgs e)
		{			
			int tileX = e.X / 16;
			int tileY = e.Y / 16;
			int superX = tileX / 32;
			int superY = tileY / 32;
			int mapId = (superY * 8) + superX + ZS.OverworldManager.WorldOffset;
			int mid = ZS.OverworldManager.allmaps[CurrentMap].ParentMapID;
			int superMX = mid % 8 * 32;
			int superMY = mid / 8 * 32;

			if (e.Button == MouseButtons.Right)
			{
				if (tileX == globalmouseTileDownX && tileY == globalmouseTileDownY)
				{
					OverlayTile tp = new OverlayTile((byte) (tileX - superMX), (byte) (tileY - superMY), 0);
					OverlayTile tf = compareTilePosT(tp, ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());

					if (tf.IsGarbage)
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
						selectedTile = new ushort[1] { tf.Map16Value };
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
						sizeX = globalmouseTileDownX - tileX + 1;
					}
					else
					{
						sizeX = tileX - globalmouseTileDownX + 1;
					}

					if (reverseY)
					{
						sizeY = globalmouseTileDownY - tileY + 1;
					}
					else
					{
						sizeY = tileY - globalmouseTileDownY + 1;
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
					int scrollpos = selectedTile[0] / 8 * 16;
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

		private void OnMouseMove_Overlay(MouseEventArgs e)
		{
			int mouseTileX = e.X / 16;
			int mouseTileY = e.Y / 16;

			if (lastTileHoverX != mouseTileX || lastTileHoverY != mouseTileY)
			{
				if (MouseIsDown)
				{
					if (e.Button == MouseButtons.Left)
					{
						int tileX = (e.X / 16).Clamp(0, 255);
						int tileY = (e.Y / 16).Clamp(0, 255);

						int superX = tileX / 32;
						int superY = tileY / 32;
						int mapId;
						globalmouseTileDownX = tileX;
						globalmouseTileDownY = tileY;
						int mid = ZS.OverworldManager.allmaps[CurrentMap].ParentMapID;
						int superMX = mid % 8 * 32;
						int superMY = mid / 8 * 32;

						if (selectedTile.Length >= 1)
						{
							ushort[] undotiles = new ushort[selectedTile.Length];
							int y = 0;
							int x = 0;

							for (int i = 0; i < selectedTile.Length; i++)
							{
								superX = (tileX + x) / 32;
								superY = (tileY + y) / 32;
								mapId = (superY * 8) + superX + ZS.OverworldManager.WorldOffset;
								if (globalmouseTileDownX + x < 255 && globalmouseTileDownY + y < 255)
								{
									/*
                                    undotiles[i] = scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
                                    scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
                                    scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);
                                    */

									OverlayTile tp = new OverlayTile((byte) (tileX - superMX + x), (byte) (tileY - superMY + y), selectedTile[i]);
									OverlayTile tf = compareTilePosT(tp, ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());
									if (ModifierKeys == Keys.Control)
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

									if (tf.IsGarbage)
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
					int sX;
					int sY;
					int y = 0;
					int x = 0;
					int mapId = ZS.OverworldManager.WorldOffset;

					for (int i = 0; i < selectedTile.Length; i++)
					{
						if (globalmouseTileDownX + x < 255 && globalmouseTileDownY + y < 255)
						{
							sX = (mouseTileX + x) / 32;
							sY = (mouseTileY + y) / 32;
							mapId = (sY * 8) + sX + ZS.OverworldManager.WorldOffset;

							if (mapId > 63 + ZS.OverworldManager.WorldOffset)
							{
								break;
							}

							if (mapId <= 159)
							{
								ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(x * 16, y * 16, selectedTile[i]);
							}
						}

						x++;
						if (x >= selectedTileSizeX)
						{
							y++;
							x = 0;
						}
					}

					if (mapId >= ZS.OverworldManager.WorldOffsetEnd)
					{
						return;
					}

					if (mapId <= 159)
					{
						tilesgfxBitmap.Palette = ZS.OverworldManager.allmaps[mapId].MyArtist.Layer1Canvas.Palette;
					}
				}
			}
			
		}

		// TODO
		private void Copy_Overlay()
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
