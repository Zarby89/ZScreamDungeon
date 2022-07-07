namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneOW
{
	private void OnMouseDown_OWDoor(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			int mapy = LastSelectedExit.MapID / 8;
			int mapx = LastSelectedExit.MapID & 0x7;
			int mouse_tile_x_down = ((e.X / 16)) - (mapx * 32);
			int mouse_tile_y_down = ((e.Y / 16)) - (mapy * 32);

			LastSelectedExit.doorXEditor = (byte) mouse_tile_x_down;
			LastSelectedExit.doorYEditor = (byte) mouse_tile_y_down;
		}
	}

	private void OnMouseUp_OWDoor(MouseEventArgs e)
	{

	}

	private void OnMouseMove_OWDoor(MouseEventArgs e)
	{
		int mouseTileX = e.X / 16;
		int mouseTileY = e.Y / 16;
		int mapX = (mouseTileX / 32);
		int mapY = (mouseTileY / 32);

		if (lastTileHoverX != mouseTileX || lastTileHoverY != mouseTileY)
		{
			int tileX = (e.X / 16);
			int tileY = (e.Y / 16);
			if (tileX < 0) { tileX = 0; }
			if (tileY < 0) { tileY = 0; }
			if (tileX > 255) { tileX = 255; }
			if (tileY > 255) { tileY = 255; }
			int superX = (tileX / 32);
			int superY = (tileY / 32);
			globalmouseTileDownX = tileX;
			globalmouseTileDownY = tileY;

			// Refresh the tile preview
			if (selectedTile.Length >= 1)
			{
				int sX;
				int sY;
				int y = 0;
				int x = 0;
				int mapId = 0;
				for (int i = 0; i < selectedTile.Length; i++)
				{
					if (globalmouseTileDownX + x < 255 && globalmouseTileDownY + y < 255)
					{
						sX = ((mouseTileX + x) / 32);
						sY = ((mouseTileY + y) / 32);
						mapId = (sY * 8) + sX;
						if (mapId > 63)
						{
							break;
						}

						ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(x * 16, y * 16, selectedTile[i]);
					}

					x++;
					if (x >= selectedTileSizeX)
					{
						y++;
						x = 0;
					}
				}

				if (mapId > 63)
				{
					return;
				}

				tilesgfxBitmap.Palette = ZS.OverworldManager.allmaps[mapId].MyArtist.Layer1Canvas.Palette;
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

	// TODO

	private void Delete_OWDoor()
	{
		throw new NotImplementedException();
	}

	private void SelectAll_OWDoor()
	{
		throw new NotImplementedException();
	}
}
