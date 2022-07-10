namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneOW
{
	private readonly List<TileUndo> undoList = new();
	private readonly List<TileUndo> redoList = new();

	int globalmouseTileDownXLOCK = 0;
	int globalmouseTileDownYLOCK = 0;

	// TODO make an enum
	byte lockedDirection = 0x00;

	private enum LockingDirection
	{
		None = 0,
		Up = 1,
		Down = 2,
		Left = 4,
		Right = 8
	}

	private void Copy_Tiles()
	{
		Clipboard.Clear();
		var td = new TileClipboardData((ushort?[]) selectedTile.Clone(), selectedTileSpan);
		Clipboard.SetData(Constants.OverworldTilesClipboardData, td);
	}

	private void Delete_Tiles()
	{
		// TODO
	}

	private void Paste_Tiles()
	{
		var data = (TileClipboardData) Clipboard.GetData(Constants.OverworldTilesClipboardData);

		if (data is not null)
		{
			selectedTile = data.tiles;
			selectedTileSpan = data.length;
		}
	}

	private void PlaceSelectedTiles(int x, int y)
	{
		if (selectedTile.Length == 0) return;

		PlaceTiles(selectedTile, x, y, selectedTileSpan);
	}

	private void PlaceTiles(ushort?[] tiles, int x, int y, int span)
	{
		int xx = 0;
		int yy = 0;
		foreach (var t in tiles)
		{
			if (t is ushort ttt)
			{
				var (map, xxx, yyy) = GetScreenCoordinatesFromGlobalXY(x + xx, y + yy);

				map?.SetTile16At(ttt, xxx, yyy);
			}

			if (++xx == span)
			{
				xx = 0;
				yy++;
			}
		}
	}

	private ushort? GetTileFromCurrentXY()
	{
		return GetTileFromGlobalXY(globalmouseTileDownX, globalmouseTileDownY);
	}

	private ushort? GetTileFromGlobalXY(int x, int y)
	{
		var (map, xxx, yyy) = GetScreenCoordinatesFromGlobalXY(x, y);

		return map.GetTile16At(xxx, yyy);
	}

	public void SetOnlySelectedTile(ushort? s)
	{
		if (s is null) return;

		selectedTileSpan = 1;
		selectedTile = new ushort?[1] {
			s
		};

		return;
	}


	private ushort?[] GetBlockOfTiles(int x, int y, int w, int h)
	{
		var ret = new ushort?[w*h];

		for (int yy = 0; yy < h; yy++)
		{
			for (int xx = 0; xx < w; xx++)
			{
				ret[xx + (yy * w)] = GetTileFromGlobalXY(xx + x, yy + y) ?? 0;
			}
		}

		return ret;
	}


	private void OnMouseDown_Tiles(MouseEventArgs e)
	{
		//ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.worldOffset].BuildMap();

		if (CurrentMapID >= 160)
		{
			return;
		}

		if (e.Button == MouseButtons.Left)
		{
			if (ModifierKeys == Keys.Control)
			{
				throw new NotImplementedException();
				//if (selectedTile.Length >= 1)
				//{
				//	int y = 0;
				//	int x = 0;
				//
				//	for (int i = 0; i < selectedTile.Length; i++)
				//	{
				//		superX = ((tileX + x) / 32);
				//		superY = ((tileY + y) / 32);
				//		mapId = (superY * 8) + superX + ZS.OverworldManager.WorldOffset;
				//		if (ZS.OverworldManager.allmaps[mapId].GetTile16At(localTileDownX + x, localTileDownY + y) == 52)
				//		{
				//			ZS.OverworldManager.allmaps[mapId].SetTile16At(selectedTile[i], localTileDownX + x, localTileDownY + y);
				//		}
				//
				//		x++;
				//		if (x >= selectedTileSpan)
				//		{
				//			y++;
				//			x = 0;
				//		}
				//	}
				//}
				//else if (ZS.OverworldManager.allmaps[mapId].GetTile16At(localTileDownX, localTileDownY) == 52)
				//{
				//	ZS.OverworldManager.allmaps[mapId].SetTile16At(selectedTile[0], localTileDownX, localTileDownY);
				//}
			}
			else
			{
				PlaceSelectedTiles(globalmouseTileDownX, globalmouseTileDownY);
			}
		}
		else if (e.Button == MouseButtons.Right)
		{
			selecting = true;
		}
	}

	private void OnMouseUp_Tiles(MouseEventArgs e)
	{
		lockedDirection = 0x00;

		if (e.Button == MouseButtons.Right)
		{
			if (currentTileX == globalmouseTileDownX && currentTileY == globalmouseTileDownY)
			{
				SetOnlySelectedTile(GetTileFromCurrentXY());
			}
			else
			{
				int w = Math.Abs(globalmouseTileDownX - currentTileX) + 1;
				int h = Math.Abs(globalmouseTileDownY - currentTileY) + 1;

				int xx = Math.Min(currentTileX, globalmouseTileDownX);
				int yy = Math.Min(currentTileY, globalmouseTileDownY);

				selectedTile = GetBlockOfTiles(xx, yy, w, h);
				selectedTileSpan = w;
			}

			if (selectedTile.Length == 1)
			{
				ZGUI.OverworldEditor.ScrollToTile(selectedTile[0]);
			}
		}

	}

	private void OnMouseMove_Tiles(MouseEventArgs e)
	{
		if (hoveredMap + ZS.OverworldManager.WorldOffset >= 160)
		{
			return;
		}

		if (!MouseIsDown) return;

		if (lastTileHoverX == currentTileX && lastTileHoverY == currentTileY) return;

		
		if (e.Button == MouseButtons.Left)
		{
			int tileX = (e.X / 16).Clamp(0, 255);
			int tileY = (e.Y / 16).Clamp(0, 255);
			int superX = (tileX / 32);
			int superY = (tileY / 32);
			int mapId = (superY * 8) + superX;
			globalmouseTileDownX = tileX;
			globalmouseTileDownY = tileY;

			if (ModifierKeys == Keys.Shift && lockedDirection == 0x00)
			{
				if (lastTileHoverX != currentTileX)
				{
					lockedDirection = 0x01;
				}
				if (lastTileHoverY != currentTileY)
				{
					lockedDirection = 0x02;
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
		}
	}
}
