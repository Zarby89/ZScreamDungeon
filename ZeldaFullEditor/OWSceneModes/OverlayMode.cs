using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.OWSceneModes.ClipboardData;

namespace ZeldaFullEditor.OWSceneModes
{
    public class OverlayMode
    {
        SceneOW scene;
        public OverlayMode(SceneOW scene)
        {
            this.scene = scene;
        }

        public void OnMouseDown(MouseEventArgs e)
        {

            if (!scene.mouse_down)
            {
                int tileX = (e.X / 16);
                int tileY = (e.Y / 16);
                int superX = (tileX / 32);
                int superY = (tileY / 32);
                int mapId = (superY * 8) + superX;
                scene.globalmouseTileDownX = tileX;
                scene.globalmouseTileDownY = tileY;
                scene.selectedMap = mapId + scene.ow.worldOffset;
                int mid = scene.ow.allmaps[scene.selectedMap].parent;
                int superMX = (mid % 8) * 32;
                int superMY = (mid / 8) * 32;

                scene.tileBitmapPtr = scene.ow.allmaps[scene.ow.allmaps[mapId].parent].blockset16;
                scene.tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, scene.tileBitmapPtr);
                scene.tileBitmap.Palette = scene.ow.allmaps[scene.ow.allmaps[mapId].parent].gfxBitmap.Palette;


                if (scene.needRedraw)
                {
                    scene.needRedraw = false;
                    return;
                }
                scene.mouse_down = true;

                if (e.Button == MouseButtons.Left)
                {
                    if (scene.selectedTile.Length >= 1)
                    {
                        int y = 0;
                        int x = 0;
                        ushort[] undotiles = new ushort[scene.selectedTile.Length];
                        for (int i = 0; i < scene.selectedTile.Length; i++)
                        {
                            superX = ((tileX + x) / 32);
                            superY = ((tileY + y) / 32);
                            mapId = (superY * 8) + superX + scene.ow.worldOffset;
                            /*undotiles[i] = scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
                            scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
                            scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);
                            */
                            TilePos tp = new TilePos((byte)((int)((scene.globalmouseTileDownX + x) - (superMX))), (byte)((int)((scene.globalmouseTileDownY + y) - (superMY))), scene.selectedTile[i]);
                            TilePos tf = scene.compareTilePosT(tp, scene.ow.alloverlays[mid].tilesData.ToArray());
                            if (scene.ow.allmaps[scene.selectedMap].largeMap)
                            {
                                tp = new TilePos((byte)((int)((scene.globalmouseTileDownX + x) - (superMX))), (byte)((int)((scene.globalmouseTileDownY + y) - (superMY))), scene.selectedTile[i]);
                                tf = scene.compareTilePosT(tp, scene.ow.alloverlays[mid].tilesData.ToArray());
                                
                            }

                            if (Control.ModifierKeys == Keys.Control)
                            {
                                scene.ow.alloverlays[mid].tilesData.Remove(tf);
                                return;
                            }

                            
                            if (tf == null)
                            {
                                scene.ow.alloverlays[mid].tilesData.Add(tp);
                            }
                            else
                            {
                                scene.ow.alloverlays[mid].tilesData.Remove(tf);
                                scene.ow.alloverlays[mid].tilesData.Add(tp);
                            }

                            x++;
                            if (x >= scene.selectedTileSizeX)
                            {

                                y++;
                                x = 0;
                            }
                        }
                    }
                    /*else
                    {
                        scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX, scene.globalmouseTileDownY] = scene.selectedTile[0];
                         scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX) * 16) - (superX * 512), ((tileY) * 16) - (superY * 512), scene.selectedTile[0], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);
                         //this.Invalidate(new Rectangle(e.X - 16, e.Y - 16, 32,  32));
                        TilePos tp = new TilePos((byte)(scene.globalmouseTileDownX), (byte)(scene.globalmouseTileDownY), scene.selectedTile[0]);
                        if ((scene.compareTilePosT(tp, scene.ow.alloverlays[mapId].tilesData.ToArray())) == null)
                        {
                            scene.ow.alloverlays[mapId].tilesData.Add(tp);
                        }

                    
                    }*/

                }
                else if (e.Button == MouseButtons.Right)
                {

                }


            }

        }

        public void OnMouseUp(MouseEventArgs e)
        {
            if (scene.mouse_down)
            {
                int tileX = (e.X / 16);
                int tileY = (e.Y / 16);
                int superX = (tileX / 32);
                int superY = (tileY / 32);
                int mapId = (superY * 8) + superX + scene.ow.worldOffset;

                if (e.Button == MouseButtons.Right)
                {
                    if (tileX == scene.globalmouseTileDownX && tileY == scene.globalmouseTileDownY)
                    {
                        scene.selectedTile = new ushort[1] { scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX, scene.globalmouseTileDownY] };
                        scene.selectedTileSizeX = 1;
                    }
                }

            }
            scene.selecting = false;
            scene.mouse_down = false;
            scene.Refresh();
            //scene.mainForm.pictureboxOWTiles.Refresh();
            //scene.mainForm.pictureGroupTiles.Refresh();

        }

        public void OnMouseMove(MouseEventArgs e)
        {
            if (scene.initialized)
            {
                scene.mouseX_Real = e.X;
                scene.mouseY_Real = e.Y;
                int mouseTileX = e.X / 16;
                int mouseTileY = e.Y / 16;
                int mapX = (mouseTileX / 32);
                int mapY = (mouseTileY / 32);
                scene.mapHover = mapX + (mapY * 8);
                if (scene.lastTileHoverX != mouseTileX || scene.lastTileHoverY != mouseTileY)
                {


                    if (scene.mouse_down)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            int tileX = (e.X / 16);
                            int tileY = (e.Y / 16);
                            if (tileX < 0) { tileX = 0; }
                            if (tileY < 0) { tileY = 0; }
                            if (tileX > 255) { tileX = 255; }
                            if (tileY > 255) { tileY = 255; }
                            int superX = (tileX / 32);
                            int superY = (tileY / 32);
                            int mapId = (superY * 8) + superX;
                            scene.globalmouseTileDownX = tileX;
                            scene.globalmouseTileDownY = tileY;
                            int mid = scene.ow.allmaps[scene.selectedMap].parent;
                            int superMX = (mid % 8) * 32;
                            int superMY = (mid / 8) * 32;



                            if (scene.selectedTile.Length >= 1)
                            {
                                ushort[] undotiles = new ushort[scene.selectedTile.Length];
                                int y = 0;
                                int x = 0;
                                for (int i = 0; i < scene.selectedTile.Length; i++)
                                {
                                    superX = ((tileX + x) / 32);
                                    superY = ((tileY + y) / 32);
                                    mapId = (superY * 8) + superX + scene.ow.worldOffset;
                                    if (scene.globalmouseTileDownX + x < 255 && scene.globalmouseTileDownY + y < 255)
                                    {
                                        /*undotiles[i] = scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
                                        scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
                                        scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);*/

                                        TilePos tp = new TilePos((byte)(tileX -(superMX) + x), (byte)(tileY - (superMY) + y), scene.selectedTile[i]);
                                        TilePos tf = scene.compareTilePosT(tp, scene.ow.alloverlays[mid].tilesData.ToArray());
                                        if (Control.ModifierKeys == Keys.Control)
                                        {
                                            scene.ow.alloverlays[mid].tilesData.Remove(tf);
                                            return;
                                        }
                                        if (tf == null)
                                        {
                                            scene.ow.alloverlays[mid].tilesData.Add(tp);
                                        }
                                        else
                                        {
                                            scene.ow.alloverlays[mid].tilesData.Remove(tf);
                                            scene.ow.alloverlays[mid].tilesData.Add(tp);
                                        }
                                        

                                    }
                                    x++;
                                    if (x >= scene.selectedTileSizeX)
                                    {

                                        y++;
                                        x = 0;
                                    }
                                }
                            }
                        }
                    }
                    scene.lastTileHoverX = mouseTileX;
                    scene.lastTileHoverY = mouseTileY;

                }
            }

        }

    }
}
