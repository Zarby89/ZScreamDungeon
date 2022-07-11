namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneOW
{
	private void PlaceSelectedOverlayTiles(int x, int y)
	{
		if (selectedTile.Length == 0) return;

		PlaceOverlayTiles(selectedTile, x, y, selectedTileSpan);
	}

	private void PlaceOverlayTiles(ushort?[] tiles, int x, int y, int span)
	{
		int xx = 0;
		int yy = 0;
		foreach (var t in tiles)
		{
			var (map, xxx, yyy) = GetScreenCoordinatesFromGlobalXY(x + xx, y + yy);

			map?.SetOverlayTile16At(t, xxx, yyy);

			if (++xx == span)
			{
				xx = 0;
				yy++;
			}
		}
	}

	private ushort? GetOverlayTileFromCurrentXY()
	{
		return GetOverlayTileFromGlobalXY(globalmouseTileDownX, globalmouseTileDownY);
	}

	private void DeleteOverlayTileFromCurrentXY()
	{
		var (map, xxx, yyy) = GetScreenCoordinatesFromGlobalXY(globalmouseTileDownX, globalmouseTileDownY);

		map?.DeleteOverlayTile16At(xxx, yyy);;
	}

	private ushort? GetOverlayTileFromGlobalXY(int x, int y)
	{
		var (map, xxx, yyy) = GetScreenCoordinatesFromGlobalXY(x, y);

		return map.GetOverlayTile16At(xxx, yyy);
	}


	private ushort?[] GetBlockOfOverlayTiles(int x, int y, int w, int h)
	{
		var ret = new ushort?[w * h];

		for (int yy = 0; yy < h; yy++)
		{
			for (int xx = 0; xx < w; xx++)
			{
				ret[xx + (yy * w)] = GetOverlayTileFromGlobalXY(xx + x, yy + y);
			}
		}

		return ret;
	}









	private void OnMouseDown_Overlay(MouseEventArgs e)
	{
		if (CurrentMapID >= 160) return;

		if (e.Button == MouseButtons.Left)
		{
			if (ModifierKeys == Keys.Control)
			{
				DeleteOverlayTileFromCurrentXY();
			}
			else
			{
				PlaceSelectedOverlayTiles(globalmouseTileDownX, globalmouseTileDownY);
			}
		}
		else if (e.Button == MouseButtons.Right)
		{
			selecting = true;
		}
	}

	private void OnMouseUp_Overlay(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			if (currentTileX == globalmouseTileDownX && currentTileY == globalmouseTileDownY)
			{
				SetOnlySelectedTile(
					GetOverlayTileFromCurrentXY() ?? GetTileFromCurrentXY()
				);
			}
			else
			{
				int w = Math.Abs(globalmouseTileDownX - currentTileX) + 1;
				int h = Math.Abs(globalmouseTileDownY - currentTileY) + 1;

				int xx = Math.Min(currentTileX, globalmouseTileDownX);
				int yy = Math.Min(currentTileY, globalmouseTileDownY);

				selectedTile = GetBlockOfOverlayTiles(xx, yy, w, h);
				selectedTileSpan = w;
				RefreshTilePreview();
			}

			if (selectedTile.Length == 1)
			{
				ZGUI.OverworldEditor.ScrollToTile(selectedTile[0]);
			}
		}
	}

	private void OnMouseMove_Overlay(MouseEventArgs e)
	{
		if (lastTileHoverX == currentTileX && lastTileHoverY == currentTileY) return;

		if (MouseIsDown && e.Button == MouseButtons.Left)
		{
			if (ModifierKeys == Keys.Control)
			{
				DeleteOverlayTileFromCurrentXY();
				return;
			}

			PlaceSelectedOverlayTiles(globalmouseTileDownX, globalmouseTileDownY);
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
