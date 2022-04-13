using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.OWSceneModes
{
	public class DoorMode : SceneMode
	{
		public DoorMode(ZScreamer parent) : base(parent)
		{
		}

		public override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int mapy = (ZS.OverworldScene.exitmode.lastselectedExit.mapId / 8);
				int mapx = ZS.OverworldScene.exitmode.lastselectedExit.mapId - (mapy * 8);
				int mouse_tile_x_down = ((e.X / 16)) - (mapx * 32);
				int mouse_tile_y_down = ((e.Y / 16)) - (mapy * 32);

				ZS.OverworldScene.exitmode.lastselectedExit.doorXEditor = (byte) mouse_tile_x_down;
				ZS.OverworldScene.exitmode.lastselectedExit.doorYEditor = (byte) mouse_tile_y_down;
				//ZS.OverworldScene.Invalidate(new Rectangle(ZS.OverworldScene.mainForm.panel5.HorizontalScroll.Value, ZS.OverworldScene.mainForm.panel5.VerticalScroll.Value, ZS.OverworldScene.mainForm.panel5.Width, ZS.OverworldScene.mainForm.panel5.Height));
				ZS.OverworldScene.exitmode.exitProperty_Click(null, null);
			}
		}

		public override void OnMouseUp(MouseEventArgs e)
		{
			// TODO: Add something here?
		}

		public override void OnMouseMove(MouseEventArgs e)
		{
			if (ZS.OverworldScene.initialized)
			{
				ZS.OverworldScene.mouseX_Real = e.X;
				ZS.OverworldScene.mouseY_Real = e.Y;
				int mouseTileX = e.X / 16;
				int mouseTileY = e.Y / 16;
				int mapX = (mouseTileX / 32);
				int mapY = (mouseTileY / 32);

				ZS.OverworldScene.mapHover = mapX + (mapY * 8);

				if (ZS.OverworldScene.lastTileHoverX != mouseTileX || ZS.OverworldScene.lastTileHoverY != mouseTileY)
				{
					int tileX = (e.X / 16);
					int tileY = (e.Y / 16);
					if (tileX < 0) { tileX = 0; }
					if (tileY < 0) { tileY = 0; }
					if (tileX > 255) { tileX = 255; }
					if (tileY > 255) { tileY = 255; }
					int superX = (tileX / 32);
					int superY = (tileY / 32);
					ZS.OverworldScene.globalmouseTileDownX = tileX;
					ZS.OverworldScene.globalmouseTileDownY = tileY;

					// Refresh the tile preview
					if (ZS.OverworldScene.selectedTile.Length >= 1)
					{
						int sX = (mouseTileX / 32);
						int sY = (mouseTileY / 32);
						int y = 0;
						int x = 0;
						int mapId = 0;
						for (int i = 0; i < ZS.OverworldScene.selectedTile.Length; i++)
						{
							if (ZS.OverworldScene.globalmouseTileDownX + x < 255 && ZS.OverworldScene.globalmouseTileDownY + y < 255)
							{
								sX = ((mouseTileX + x) / 32);
								sY = ((mouseTileY + y) / 32);
								mapId = (sY * 8) + sX;
								if (mapId > 63)
								{
									break;
								}

								ZS.OverworldManager.allmaps[mapId].CopyTile8bpp16(x * 16, y * 16, ZS.OverworldScene.selectedTile[i], ZS.OverworldScene.temptilesgfxPtr, ZS.GFXManager.mapblockset16);
							}

							x++;
							if (x >= ZS.OverworldScene.selectedTileSizeX)
							{
								y++;
								x = 0;
							}
						}

						if (mapId > 63)
						{
							return;
						}

						ZS.OverworldScene.tilesgfxBitmap.Palette = ZS.OverworldManager.allmaps[mapId].gfxBitmap.Palette;

						//ZS.OverworldScene.Invalidate(new Rectangle(ZS.OverworldScene.mainForm.panel5.HorizontalScroll.Value, ZS.OverworldScene.mainForm.panel5.VerticalScroll.Value, ZS.OverworldScene.mainForm.panel5.Width, ZS.OverworldScene.mainForm.panel5.Height));
						//this.Refresh();
						//this.Invalidate(new Rectangle((mouseTileX * 16)-16, (mouseTileY * 16)-16, (selectedTileSizeX * 16)+32, (y * 16)+32));
					}

					/*
                    if (selecting)
                    {
                        this.Invalidate(new Rectangle((globalmouseTileDownX * 16), (globalmouseTileDownY * 16), (mouseTileX * 16) - (globalmouseTileDownX * 16) + 48, (mouseTileY * 16) - (globalmouseTileDownY * 16) + 48));
                    }
                    */

					ZS.OverworldScene.lastTileHoverX = mouseTileX;
					ZS.OverworldScene.lastTileHoverY = mouseTileY;
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
		public override void Copy()
		{
			throw new NotImplementedException();
		}

		public override void Cut()
		{
			throw new NotImplementedException();
		}

		public override void Paste()
		{
			throw new NotImplementedException();
		}

		public override void Delete()
		{
			throw new NotImplementedException();
		}
	}
}
