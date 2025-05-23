﻿using System.Windows.Forms;

namespace ZeldaFullEditor.OWSceneModes
{
    public class DoorMode
    {
        SceneOW scene;

        public DoorMode(SceneOW scene)
        {
            this.scene = scene;
        }

        public void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int mapy = scene.exitmode.lastselectedExit.MapID / 8;
                int mapx = scene.exitmode.lastselectedExit.MapID - (mapy * 8);
                int mouse_tile_x_down = (e.X / 16) - (mapx * 32);
                int mouse_tile_y_down = (e.Y / 16) - (mapy * 32);

                scene.exitmode.lastselectedExit.DoorXEditor = (byte)mouse_tile_x_down;
                scene.exitmode.lastselectedExit.DoorYEditor = (byte)mouse_tile_y_down;

                //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                scene.exitmode.exitProperty_Click(null, null);
            }
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            // TODO: Add something here?
        }

        public void onMouseMove(MouseEventArgs e)
        {
            if (scene.initialized)
            {
                scene.mouseX_Real = e.X;
                scene.mouseY_Real = e.Y;
                int mouseTileX = e.X.Clamp(0, 4080) / 16;
                int mouseTileY = e.Y.Clamp(0, 4080) / 16;
                int mapX = (mouseTileX / 32);
                int mapY = (mouseTileY / 32);

                scene.mapHover = mapX + (mapY * 8);

                if (scene.lastTileHoverX != mouseTileX || scene.lastTileHoverY != mouseTileY)
                {
                    int tileX = e.X / 16;
                    int tileY = e.Y / 16;
                    if (tileX < 0)
                    {
                        tileX = 0;
                    }

                    if (tileY < 0)
                    {
                        tileY = 0;
                    }

                    if (tileX > 255)
                    {
                        tileX = 255; 
                    }

                    if (tileY > 255)
                    {
                        tileY = 255;
                    }

                    int superX = tileX / 32;
                    int superY = tileY / 32;
                    scene.globalmouseTileDownX = tileX;
                    scene.globalmouseTileDownY = tileY;

                    // Refresh the tile preview
                    if (scene.selectedTile.Length >= 1)
                    {
                        int sX = mouseTileX / 32;
                        int sY = mouseTileY / 32;
                        int y = 0;
                        int x = 0;
                        int mapId = 0;
                        for (int i = 0; i < scene.selectedTile.Length; i++)
                        {
                            if (scene.globalmouseTileDownX + x < 255 && scene.globalmouseTileDownY + y < 255)
                            {
                                sX = (mouseTileX + x) / 32;
                                sY = (mouseTileY + y) / 32;
                                mapId = (sY * 8) + sX;
                                if (mapId > 63)
                                {
                                    break;
                                }

                                scene.ow.AllMaps[mapId].CopyTile8bpp16(x * 16, y * 16, scene.selectedTile[i], scene.temptilesgfxPtr, GFX.mapblockset16);
                            }

                            x++;
                            if (x >= scene.selectedTileSizeX)
                            {
                                y++;
                                x = 0;
                            }
                        }

                        if (mapId > 63)
                        {
                            return;
                        }

                        scene.tilesgfxBitmap.Palette = scene.ow.AllMaps[mapId].GFXBitmap.Palette;

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
    }
}
