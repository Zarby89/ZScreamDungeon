namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneOW
{
	private void OnMouseDown_OWDoor(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			LastSelectedExit.doorXEditor = (byte) localTileDownX;
			LastSelectedExit.doorYEditor = (byte) localTileDownY;
		}
	}

	private void OnMouseUp_OWDoor(MouseEventArgs e)
	{

	}

	private void OnMouseMove_OWDoor(MouseEventArgs e)
	{
		if (lastTileHoverX == currentTileX && lastTileHoverY == currentTileY) return;
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

	// TODO

	private void Delete_OWDoor()
	{
		throw new NotImplementedException();
	}
}
