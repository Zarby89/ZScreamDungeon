namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneOW
{
	private readonly List<TileUndo> undoList = new();
	private readonly List<TileUndo> redoList = new();

	private int globalmouseTileDownXLOCK = 0;
	private int globalmouseTileDownYLOCK = 0;

	// TODO make an enum
	private LockingDirection lockedDirection = LockingDirection.None;

	private enum LockingDirection
	{
		None = 0,
		Vertical = 1,
		Horizontal = 2,
	}

	public void RefreshTilePreview()
	{
		int xx = 0;
		int yy = 0;

		tilesgfxBitmap.ClearBitmap();
		tilesgfxBitmap.CopyPalette(ZS.OverworldManager.Tile16Sheet.Palette);

		var sheet = ZScreamer.ActiveOW.Tile16Sheet;
		var gfx = sheet.Graphics;

		foreach (var t in selectedTile)
		{
			if (t is ushort ttt)
			{
				var t16 = sheet.GetTile16At(ttt);

				var (t0, p0) = gfx.GetBackgroundTileWithPalette(t16.Tile0);
				t0.DrawToCanvas(tilesgfxBitmap, xx * 16, yy * 16, (byte) p0, t16.Tile0.HFlip, t16.Tile0.VFlip);

				var (t1, p1) = gfx.GetBackgroundTileWithPalette(t16.Tile1);
				t1.DrawToCanvas(tilesgfxBitmap, xx * 16 + 8, yy * 16, (byte) p1, t16.Tile1.HFlip, t16.Tile1.VFlip);

				var (t2, p2) = gfx.GetBackgroundTileWithPalette(t16.Tile2);
				t2.DrawToCanvas(tilesgfxBitmap, xx * 16, yy * 16 + 8, (byte) p2, t16.Tile2.HFlip, t16.Tile2.VFlip);

				var (t3, p3) = gfx.GetBackgroundTileWithPalette(t16.Tile3);
				t3.DrawToCanvas(tilesgfxBitmap, xx * 16 + 8, yy * 16 + 8, (byte) p3, t16.Tile3.HFlip, t16.Tile3.VFlip);
			}

			if (++xx == selectedTileSpan)
			{
				xx = 0;
				yy++;
			}
		}
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
			RefreshTilePreview();
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

		RefreshTilePreview();
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
		lockedDirection = LockingDirection.None;

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
				RefreshTilePreview();
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
			if (ModifierKeys == Keys.Shift)
			{
				if (lockedDirection == LockingDirection.None)
				{
					if (lastTileHoverX != currentTileX)
					{
						lockedDirection = LockingDirection.Horizontal;
						globalmouseTileDownYLOCK = currentTileY;
					}
					else if (lastTileHoverY != currentTileY)
					{
						lockedDirection = LockingDirection.Vertical;
						globalmouseTileDownXLOCK = currentTileX;
					}
				}
			}
			else
			{
				lockedDirection = LockingDirection.None;
			}

			int useX = lockedDirection switch
			{
				LockingDirection.Vertical => globalmouseTileDownXLOCK,
				_ => currentTileX
			};

			int useY = lockedDirection switch
			{
				LockingDirection.Horizontal => globalmouseTileDownYLOCK,
				_ => currentTileY
			};

			PlaceSelectedTiles(useX, useY);
		}
	}
}
