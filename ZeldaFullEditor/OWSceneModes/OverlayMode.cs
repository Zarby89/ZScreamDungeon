using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lidgren.Network;
using ZeldaFullEditor.OWSceneModes.ClipboardData;
using ZeldaFullEditor.Properties;

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
                scene.selectedMapParent = scene.ow.allmaps[scene.selectedMap].parent;

                int mid = scene.ow.allmaps[scene.selectedMap].parent;
                int superMX = (mid % 8) * 32;
                int superMY = (mid / 8) * 32;

                scene.tileBitmapPtr = GFX.mapblockset16;
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

                        SendTileData((byte)(Control.ModifierKeys == Keys.Control ? 1 : 0));


                        for (int i = 0; i < scene.selectedTile.Length; i++)
                        {
                            superX = ((tileX + x) / 32);
                            superY = ((tileY + y) / 32);
                            mapId = (superY * 8) + superX + scene.ow.worldOffset;

                            /*
                            undotiles[i] = scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
                            scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
                            scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);
                            */

                            TilePos tp = new TilePos((byte)((scene.globalmouseTileDownX + x) - (superMX)), (byte)((scene.globalmouseTileDownY + y) - (superMY)), scene.selectedTile[i]);
                            TilePos tf = scene.compareTilePosT(tp, scene.ow.alloverlays[mid].tilesData.ToArray());

                            if (scene.ow.allmaps[scene.selectedMap].largeMap)
                            {
                                tp = new TilePos((byte)((scene.globalmouseTileDownX + x) - (superMX)), (byte)((scene.globalmouseTileDownY + y) - (superMY)), scene.selectedTile[i]);
                                tf = scene.compareTilePosT(tp, scene.ow.alloverlays[mid].tilesData.ToArray());

                            }

                            if (Control.ModifierKeys == Keys.Control)
                            {
                                scene.ow.alloverlays[mid].tilesData.Remove(tf);
                                x++;
                                if (x >= scene.selectedTileSizeX)
                                {
                                    y++;
                                    x = 0;
                                }

                                continue;
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

                }
                else if (e.Button == MouseButtons.Right)
                {
                    scene.selecting = true;
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
                int mid = scene.ow.allmaps[scene.selectedMap].parent;
                int superMX = (mid % 8) * 32;
                int superMY = (mid / 8) * 32;

                if (e.Button == MouseButtons.Right)
                {
                    if (tileX == scene.globalmouseTileDownX && tileY == scene.globalmouseTileDownY)
                    {
                        TilePos tp = new TilePos((byte)(tileX - (superMX)), (byte)(tileY - (superMY)), 0);
                        TilePos tf = scene.compareTilePosT(tp, scene.ow.alloverlays[mid].tilesData.ToArray());

                        if (tf == null)
                        {
                            if (tileX == scene.globalmouseTileDownX && tileY == scene.globalmouseTileDownY)
                            {
                                scene.selectedTile = new ushort[1] { scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX, scene.globalmouseTileDownY] };
                                scene.selectedTileSizeX = 1;
                            }
                        }
                        else
                        {
                            scene.selectedTile = new ushort[1] { tf.tileId };
                            scene.selectedTileSizeX = 1;

                        }
                    }
                    else
                    {
                        bool reverseX = false;
                        bool reverseY = false;
                        int sizeX = (tileX - scene.globalmouseTileDownX) + 1;
                        int sizeY = (tileY - scene.globalmouseTileDownY) + 1;

                        if (tileX < scene.globalmouseTileDownX)
                        {
                            sizeX = (scene.globalmouseTileDownX - tileX) + 1;
                            reverseX = true;
                        }

                        if (tileY < scene.globalmouseTileDownY)
                        {
                            sizeY = (scene.globalmouseTileDownY - tileY) + 1;
                            reverseY = true;
                        }

                        scene.selectedTileSizeX = sizeX;
                        scene.selectedTile = new ushort[(sizeX) * (sizeY)];
                        for (int y = 0; y < sizeY; y++)
                        {
                            for (int x = 0; x < sizeX; x++)
                            {
                                int pX = scene.globalmouseTileDownX;
                                int pY = scene.globalmouseTileDownY;

                                if (reverseX) { pX = tileX; }
                                if (reverseY) { pY = tileY; }

                                scene.selectedTile[x + (y * sizeX)] = scene.ow.allmaps[mapId].tilesUsed[(pX) + x, (pY) + y];
                            }
                        }
                    }
                    if (scene.selectedTile.Length > 0)
                    {
                        int scrollpos = ((scene.selectedTile[0] / 8) * 16);
                        if (scrollpos >= scene.owForm.splitContainer1.Panel1.VerticalScroll.Maximum)
                        {
                            scene.owForm.splitContainer1.Panel1.VerticalScroll.Value = scene.owForm.splitContainer1.Panel1.VerticalScroll.Maximum;
                        }
                        else
                        {
                            scene.owForm.splitContainer1.Panel1.VerticalScroll.Value = scrollpos;
                        }

                        scene.owForm.tilePictureBox.Refresh();
                    }
                }
            }

            scene.selecting = false;
            scene.mouse_down = false;

            //scene.Refresh();
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


                            SendTileDataMove(tileX, tileY, (byte)(Control.ModifierKeys == Keys.Control ? 1 : 0));

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
                                        /*
                                        undotiles[i] = scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
                                        scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
                                        scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);
                                        */

                                        TilePos tp = new TilePos((byte)(tileX - (superMX) + x), (byte)(tileY - (superMY) + y), scene.selectedTile[i]);
                                        TilePos tf = scene.compareTilePosT(tp, scene.ow.alloverlays[mid].tilesData.ToArray());
                                        if (Control.ModifierKeys == Keys.Control)
                                        {
                                            scene.ow.alloverlays[mid].tilesData.Remove(tf);
                                            x++;
                                            if (x >= scene.selectedTileSizeX)
                                            {
                                                y++;
                                                x = 0;
                                            }

                                            continue;
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

                    // Refresh the tile preview
                    if (scene.selectedTile.Length >= 1)
                    {
                        int sX = (mouseTileX / 32);
                        int sY = (mouseTileY / 32);
                        int y = 0;
                        int x = 0;
                        int mapId = 0 + scene.ow.worldOffset;

                        for (int i = 0; i < scene.selectedTile.Length; i++)
                        {
                            if (scene.globalmouseTileDownX + x < 255 && scene.globalmouseTileDownY + y < 255)
                            {
                                sX = ((mouseTileX + x) / 32);
                                sY = ((mouseTileY + y) / 32);
                                mapId = (sY * 8) + sX + scene.ow.worldOffset;

                                if (mapId > 63 + scene.ow.worldOffset)
                                {
                                    break;
                                }

                                if (mapId <= 159)
                                {
                                    scene.ow.allmaps[mapId].CopyTile8bpp16(x * 16, y * 16, scene.selectedTile[i], scene.temptilesgfxPtr, GFX.mapblockset16);
                                }
                            }

                            x++;
                            if (x >= scene.selectedTileSizeX)
                            {
                                y++;
                                x = 0;
                            }
                        }

                        if (mapId > 63 + scene.ow.worldOffset)
                        {
                            return;
                        }

                        if (mapId <= 159)
                        {
                            scene.tilesgfxBitmap.Palette = scene.ow.allmaps[mapId].gfxBitmap.Palette;
                        }

                        //scene.Invalidate(new Rectangle((scene.owForm.splitContainer1.Panel2.HorizontalScroll.Value), (scene.owForm.splitContainer1.Panel2.VerticalScroll.Value), (scene.owForm.splitContainer1.Panel2.Width), (scene.owForm.splitContainer1.Panel2.Height)));
                        //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                        //this.Refresh();
                        //this.Invalidate(new Rectangle((mouseTileX * 16)-16, (mouseTileY * 16)-16, (selectedTileSizeX * 16)+32, (y * 16)+32));
                    }
                }
            }
        }


        private void SendTileData(byte deleting)
        {
            if (!NetZS.connected) { return; }
            NetZSBuffer buffer = new NetZSBuffer((short)(24 + (scene.selectedTile.Length * 2)));
            buffer.Write((byte)16); // tile data cmd
            buffer.Write((byte)NetZS.userID); // user id
            buffer.Write((int)scene.globalmouseTileDownX);
            buffer.Write((int)scene.globalmouseTileDownY);
            buffer.Write((int)scene.selectedTileSizeX);
            buffer.Write((byte)deleting); // tile data cmd
            buffer.Write((byte)scene.ow.worldOffset);
            buffer.Write((int)scene.selectedTile.Length);
            for (int i = 0; i < scene.selectedTile.Length; i++)
            {
                buffer.Write((ushort)scene.selectedTile[i]);
            }
            // write tiles
            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();
        }

        private void SendTileDataMove(int tileX, int tileY, byte deleting)
        {
            if (!NetZS.connected) { return; }
            NetZSBuffer buffer = new NetZSBuffer((short)(24 + (scene.selectedTile.Length * 2)));
            buffer.Write((byte)17); // tile data cmd
            buffer.Write((byte)NetZS.userID); // user id
            buffer.Write((int)tileX);
            buffer.Write((int)tileY);
            buffer.Write((int)scene.selectedTileSizeX);
            buffer.Write((byte)deleting); // tile data cmd
            buffer.Write((byte)scene.ow.worldOffset);
            buffer.Write((int)scene.selectedTile.Length);
            for (int i = 0; i < scene.selectedTile.Length; i++)
            {
                buffer.Write((ushort)scene.selectedTile[i]);
            }
            // write tiles
            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();

        }

    }
}
