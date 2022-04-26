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
		// TODO changes door type
		private void OnMouseWheel_OWDoor(MouseEventArgs e)
		{

		}

		private void OnMouseDown_OWDoor(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int mapy = lastselectedExit.MapID / 8;
				int mapx = lastselectedExit.MapID - (mapy * 8);
				int mouse_tile_x_down = ((e.X / 16)) - (mapx * 32);
				int mouse_tile_y_down = ((e.Y / 16)) - (mapy * 32);

				lastselectedExit.doorXEditor = (byte) mouse_tile_x_down;
				lastselectedExit.doorYEditor = (byte) mouse_tile_y_down;
			}
		}

		private void OnMouseUp_OWDoor(MouseEventArgs e)
		{
			// TODO: Add something here?
		}

		private void OnMouseMove_OWDoor(MouseEventArgs e)
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
						int sX = (mouseTileX / 32);
						int sY = (mouseTileY / 32);
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

								ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(x * 16, y * 16, selectedTile[i], temptilesgfxPtr, ZS.GFXManager.mapblockset16);
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

						tilesgfxBitmap.Palette = ZS.OverworldManager.allmaps[mapId].gfxBitmap.Palette;

						//Invalidate(new Rectangle(mainForm.panel5.HorizontalScroll.Value, mainForm.panel5.VerticalScroll.Value, mainForm.panel5.Width, mainForm.panel5.Height));
						//this.Refresh();
						//this.Invalidate(new Rectangle((mouseTileX * 16)-16, (mouseTileY * 16)-16, (selectedTileSizeX * 16)+32, (y * 16)+32));
					}

					/*
                    if (selecting)
                    {
                        this.Invalidate(new Rectangle((globalmouseTileDownX * 16), (globalmouseTileDownY * 16), (mouseTileX * 16) - (globalmouseTileDownX * 16) + 48, (mouseTileY * 16) - (globalmouseTileDownY * 16) + 48));
                    }
                    */

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
                    this.Invalidate(new Rectangle(e.X-16, e.Y-16, 48, 48));
                    //this.Refresh();
                    */
				}
			}
		}

		// TODO
		private void Copy_OWDoor()
		{
			throw new NotImplementedException();
		}

		private void Cut_OWDoor()
		{
			throw new NotImplementedException();
		}

		private void Paste_OWDoor()
		{
			throw new NotImplementedException();
		}

		private void Delete_OWDoor()
		{
			throw new NotImplementedException();
		}

		private void SelectAll_OWDoor()
		{
			throw new NotImplementedException();
		}
	}
}
