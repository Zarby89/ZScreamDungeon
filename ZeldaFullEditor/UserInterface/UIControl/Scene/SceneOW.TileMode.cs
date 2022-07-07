namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneOW
{
	private readonly List<TileUndo> undoList = new();
	private readonly List<TileUndo> redoList = new();

	int globalmouseTileDownXLOCK = 0;
	int globalmouseTileDownYLOCK = 0;

	byte lockedDirection = 0x00;

	private void Copy_Tiles()
	{
		Clipboard.Clear();
		var td = new TileClipboardData((ushort[]) selectedTile.Clone(), selectedTileSizeX);
		Clipboard.SetData(Constants.OverworldTilesClipboardData, td);
	}

	private void Delete_Tiles()
	{
		// TODO
	}

	private void Paste_Tiles()
	{
		var data = (TileClipboardData) Clipboard.GetData(Constants.OverworldTilesClipboardData);

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
		int tileX = (e.X / 16);
		int tileY = (e.Y / 16);
		int superX = (tileX / 32);
		int superY = (tileY / 32);
		int mapId = CurrentMapID;
		globalmouseTileDownX = globalmouseTileDownXLOCK = e.X / 16;
		globalmouseTileDownY = globalmouseTileDownYLOCK = e.Y / 16;

		//ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.worldOffset].BuildMap();

		if (CurrentMapID >= 160)
		{
			return;
		}

		if (TriggerRefresh)
		{
			TriggerRefresh = false;
			return;
		}

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
						mapId = (superY * 8) + superX + ZS.OverworldManager.WorldOffset;
						if (ZS.OverworldManager.allmaps[mapId].GetTile16At(localTileDownX + x, localTileDownY + y) == 52)
						{
							ZS.OverworldManager.allmaps[mapId].SetTile16At(selectedTile[i], localTileDownX + x, localTileDownY + y);
							ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), selectedTile[i]);
						}

						x++;
						if (x >= selectedTileSizeX)
						{
							y++;
							x = 0;
						}
					}
				}
				else if (ZS.OverworldManager.allmaps[mapId].GetTile16At(localTileDownX, localTileDownY) == 52)
				{
					ZS.OverworldManager.allmaps[mapId].SetTile16At(selectedTile[0], localTileDownX, localTileDownY);
					ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16((tileX * 16) - (superX * 512), (tileY * 16) - (superY * 512), selectedTile[0]);
				}
			}
			else
			{
				if (selectedTile.Length >= 1)
				{
					int y = 0;
					int x = 0;
					var undotiles = new ushort[selectedTile.Length];

					for (int i = 0; i < selectedTile.Length; i++)
					{
						superX = ((tileX + x) / 32);
						superY = ((tileY + y) / 32);
						mapId = (superY * 8) + superX + ZS.OverworldManager.WorldOffset;
						undotiles[i] = ZS.OverworldManager.allmaps[mapId].GetTile16At(localTileDownX + x, localTileDownY + y);
						ZS.OverworldManager.allmaps[mapId].SetTile16At(selectedTile[i], localTileDownX + x, localTileDownY + y);
						ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), selectedTile[i]);

						x++;
						if (x >= selectedTileSizeX)
						{
							y++;
							x = 0;
						}
					}

					//undoList.Add(new TileUndo(globalmouseTileDownX, globalmouseTileDownY, selectedTileSizeX, undotiles, (ushort[]) selectedTile.Clone(), ref ZS.OverworldManager.allmaps[mapId].tilesUsed));
					//redoList.Clear();
				}
				else
				{
					//undoList.Add(new TileUndo(globalmouseTileDownX, globalmouseTileDownY, 1, new ushort[] {
					//	ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX, globalmouseTileDownY]
					//}, (ushort[]) selectedTile.Clone(), ref ZS.OverworldManager.allmaps[mapId].tilesUsed));
					//redoList.Clear();
					//ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX, globalmouseTileDownY] = selectedTile[0];
					//ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16((tileX * 16) - (superX * 512), (tileY * 16) - (superY * 512), selectedTile[0]);
				}
			}
		}
		else if (e.Button == MouseButtons.Right)
		{
			selecting = true;
			ZGUI.OverworldEditor.selectedTileLabel.Text = "Selected Tile : " + selectedTile[0].ToString("X4");
		}
	}

	private void OnMouseUp_Tiles(MouseEventArgs e)
	{
		int tileX = (e.X / 16);
		int tileY = (e.Y / 16);
		int superX = (tileX / 32);
		int superY = (tileY / 32);
		int mapId = (superY * 8) + superX + ZS.OverworldManager.WorldOffset;
		lockedDirection = 0x00;

		if (e.Button == MouseButtons.Right)
		{
			if (tileX == globalmouseTileDownX && tileY == globalmouseTileDownY)
			{
				selectedTile = new ushort[1] {
					CurrentMap.GetTile16At(globalmouseTileDownX % Constants.NumberOfTile16PerStrip, globalmouseTileDownY % Constants.NumberOfTile16PerStrip)
				};
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
						selectedTile[x + (y * sizeX)] = CurrentMap.GetTile16At(pX + x, pY + y);
					}
				}
			}

			if (selectedTile.Length > 0)
			{
				int scrollpos = selectedTile[0] / 8 * 16;
				if (scrollpos >= ZGUI.OverworldEditor.splitContainer1.Panel1.VerticalScroll.Maximum)
				{
					ZGUI.OverworldEditor.splitContainer1.Panel1.VerticalScroll.Value = ZGUI.OverworldEditor.splitContainer1.Panel1.VerticalScroll.Maximum;
				}
				else
				{
					ZGUI.OverworldEditor.splitContainer1.Panel1.VerticalScroll.Value = scrollpos;
				}

				ZGUI.OverworldEditor.tilePictureBox.Refresh();
			}
		}

	}

	private void OnMouseMove_Tiles(MouseEventArgs e)
	{
		int mouseTileX = e.X / 16;
		int mouseTileY = e.Y / 16;

		if (hoveredMap + ZS.OverworldManager.WorldOffset >= 160)
		{
			return;
		}

		if (lastHover != hoveredMap)
		{
			//ZS.OverworldManager.allmaps[hoveredMap + ZS.OverworldManager.WorldOffset].InvalidateArtist();
			lastHover = hoveredMap;
		}

		if (lastTileHoverX != mouseTileX || lastTileHoverY != mouseTileY)
		{
			if (MouseIsDown)
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
								mapId = (superY * 8) + superX + ZS.OverworldManager.WorldOffset;

								if (globalmouseTileDownX + x < 256 && globalmouseTileDownY + y < 256)
								{
									if (ZS.OverworldManager.allmaps[mapId].GetTile16At(localTileDownX + x, localTileDownY + y) == 52)
									{
										ZS.OverworldManager.allmaps[mapId].SetTile16At(selectedTile[i], localTileDownX + x, localTileDownY + y);
										ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), selectedTile[i]);
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
								mapId = (superY * 8) + superX + ZS.OverworldManager.WorldOffset;

								if (globalmouseTileDownX + x < 256 && globalmouseTileDownY + y < 256)
								{
									//undotiles[i] = ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX + x, globalmouseTileDownY + y];
									//ZS.OverworldManager.allmaps[mapId].tilesUsed[globalmouseTileDownX + x, globalmouseTileDownY + y] = selectedTile[i];
									//ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), selectedTile[i]);
								}

								x++;
								if (x >= selectedTileSizeX)
								{
									y++;
									x = 0;
								}
							}

							//undoList.Add(new TileUndo(globalmouseTileDownX, globalmouseTileDownY, selectedTileSizeX, undotiles, (ushort[]) selectedTile.Clone(), ref ZS.OverworldManager.allmaps[mapId].tilesUsed));
							redoList.Clear();

							// }

							/*
                                 else
                                 {
                                     ow.allmaps[mapId].tilesUsed[globalmouseTileDownX, globalmouseTileDownY] = selectedTile[0];
                                     ow.allmaps[mapId].CopyTile8bpp16((tileX * 16) - (superX * 512), (tileY * 16) - (superY * 512), selectedTile[0], ow.allmaps[mapId].gfxPtr, ow.allmaps[mapId].blockset16);
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
				int mapId = 0 + ZS.OverworldManager.WorldOffset;

				for (int i = 0; i < selectedTile.Length; i++)
				{
					if (globalmouseTileDownX + x < 255 && globalmouseTileDownY + y < 255)
					{
						sX = ((mouseTileX + x) / 32);
						sY = ((mouseTileY + y) / 32);
						mapId = (sY * 8) + sX + ZS.OverworldManager.WorldOffset;

						if (mapId > 63 + ZS.OverworldManager.WorldOffset)
						{
							return;
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

				if (mapId >= 63 + ZS.OverworldManager.WorldOffsetEnd)
				{
					return;
				}
				if (mapId <= 159)
				{
					tilesgfxBitmap.Palette = ZS.OverworldManager.allmaps[mapId].MyArtist.Layer1Canvas.Palette;
				}
			}

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
                 */
		}

	}
}
