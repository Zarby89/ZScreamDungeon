using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lidgren.Network;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.OWSceneModes
{
    public class ExitMode
    {
        SceneOW scene;
        public ExitOW selectedExit = null;
        public ExitOW lastselectedExit = null;

        int mxRightclick = 0;
        int myRightclick = 0;

        ExitEditorForm exitPropForm = new ExitEditorForm();

        public ExitMode(SceneOW scene)
        {
            this.scene = scene;
        }

        public void Copy()
        {
            Clipboard.Clear();
            ExitOW ed = lastselectedExit.Copy();
            Clipboard.SetData("owexit", ed);
        }

        public void Cut()
        {
            Clipboard.Clear();
            ExitOW ed = lastselectedExit.Copy();
            Clipboard.SetData("owexit", ed);
            Delete();
        }

        public void Paste()
        {
            ExitOW ae = AddExit(true);
            if (ae != null)
            {
                selectedExit = ae;
                lastselectedExit = selectedExit;
                scene.mouse_down = true;
                SendExitData(lastselectedExit);
            }

        }

        public ExitOW AddExit(bool clipboard = false)
        {
            int found = -1;
            for (int i = 0; i < scene.ow.AllExits.Length; i++)
            {
                if (scene.ow.AllExits[i].Deleted)
                {
                    byte mid = scene.ow.AllMaps[scene.mapHover + scene.ow.WorldOffset].parent;
                    if (mid == 255)
                    {
                        mid = (byte)(scene.mapHover + scene.ow.WorldOffset);
                    }

                    scene.ow.AllExits[i].Deleted = false;
                    scene.ow.AllExits[i].MapID = mid;
                    scene.ow.AllExits[i].PlayerX = (ushort)((mxRightclick / 16) * 16);
                    scene.ow.AllExits[i].PlayerY = (ushort)((myRightclick / 16) * 16);

                    if (clipboard)
                    {
                        ExitOW data = (ExitOW)Clipboard.GetData("owexit");
                        if (data != null)
                        {
                            scene.ow.AllExits[i].CameraX = data.CameraX;
                            scene.ow.AllExits[i].CameraY = data.CameraY;
                            scene.ow.AllExits[i].XScroll = data.XScroll;
                            scene.ow.AllExits[i].YScroll = data.YScroll;
                            scene.ow.AllExits[i].ScrollModY = data.ScrollModY;
                            scene.ow.AllExits[i].ScrollModX = data.ScrollModX;
                            scene.ow.AllExits[i].RoomID = data.RoomID;
                            scene.ow.AllExits[i].DoorType1 = data.DoorType1;
                            scene.ow.AllExits[i].DoorType2 = data.DoorType2;
                            scene.ow.AllExits[i].DoorXEditor = data.DoorXEditor;
                            scene.ow.AllExits[i].DoorYEditor = data.DoorYEditor;
                            SendExitData(scene.ow.AllExits[i]);
                        }
                    }

                    scene.ow.AllExits[i].UpdateMapStuff(mid, scene.ow);

                    found = i;

                    //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                    break;
                }
            }

            if (found == -1)
            {
                MessageBox.Show("No space available for new exits, delete one first");
                return null;
            }

            return scene.ow.AllExits[found];
        }

        public void onMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < 78; i++)
                {
                    ExitOW en = scene.ow.AllExits[i];
                    if (en.MapID >= scene.ow.WorldOffset && en.MapID < 64 + scene.ow.WorldOffset)
                    {
                        if (e.X >= en.PlayerX && e.X < en.PlayerX + 16 && e.Y >= en.PlayerY && e.Y < en.PlayerY + 16)
                        {
                            if (!scene.mouse_down)
                            {
                                selectedExit = en;
                                lastselectedExit = en;
                                //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                                scene.mouse_down = true;
                            }
                        }
                    }
                }
            }

            if (selectedExit != null)
            {
                //scene.owForm.thumbnailBox.Visible = true;
                //scene.owForm.thumbnailBox.Size = new Size(256, 256);
                int roomId = selectedExit.RoomID;
                if (roomId >= Constants.NumberOfRooms)
                {
                    //scene.owForm.thumbnailBox.Visible = false;
                    return;
                }

                if (scene.mainForm.lastRoomID != roomId)
                {
                    scene.mainForm.previewRoom = DungeonsData.AllRooms[roomId];
                    scene.mainForm.previewRoom.reloadGfx();
                    GFX.loadedPalettes = GFX.LoadDungeonPalette(scene.mainForm.previewRoom.palette);
                    scene.mainForm.DrawRoom();
                    DrawTempExit();
                    scene.entrancePreview = true;
                    //scene.Refresh();

                    if (scene.mainForm.activeScene.room != null)
                    {
                        GFX.loadedPalettes = GFX.LoadDungeonPalette(scene.mainForm.activeScene.room.palette);
                        scene.mainForm.activeScene.room.reloadGfx();
                        scene.mainForm.activeScene.DrawRoom();
                    }
                }

                scene.mainForm.lastRoomID = roomId;
            }
        }

        public void Delete() // Set exit data to 0
        {
            lastselectedExit.PlayerX = 0xFFFF;
            lastselectedExit.PlayerY = 0xFFFF;
            lastselectedExit.MapID = 0;
            lastselectedExit.RoomID = 0;
            lastselectedExit.Deleted = true;
            SendExitData(lastselectedExit);
            //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
        }


        public void onMouseMove(MouseEventArgs e)
        {
            if (scene.mouse_down)
            {
                int mouseTileX = e.X / 16;
                int mouseTileY = e.Y / 16;
                int mapX = (mouseTileX / 32);
                int mapY = (mouseTileY / 32);

                scene.mapHover = mapX + (mapY * 8);

                if (selectedExit != null)
                {
                    selectedExit.PlayerX = (ushort)e.X;
                    selectedExit.PlayerY = (ushort)e.Y;

                    if (scene.snapToGrid)
                    {
                        selectedExit.PlayerX = (ushort)((e.X / 8) * 8);
                        selectedExit.PlayerY = (ushort)((e.Y / 8) * 8);
                    }

                    byte mid = scene.ow.AllMaps[scene.mapHover + scene.ow.WorldOffset].parent;
                    if (mid == 255)
                    {
                        mid = (byte)(scene.mapHover + scene.ow.WorldOffset);
                    }

                    selectedExit.UpdateMapStuff(mid, scene.ow);

                    //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                }
            }
        }

        public void onMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedExit != null)
                {
                    lastselectedExit = selectedExit;
                    selectedExit = null;
                    scene.mouse_down = false;
                    SendExitData(lastselectedExit);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                bool clickedon = false;
                ContextMenuStrip menu = new ContextMenuStrip();

                for (int i = 0; i < 78; i++)
                {
                    ExitOW en = scene.ow.AllExits[i];
                    if (en.MapID >= scene.ow.WorldOffset && en.MapID < 64 + scene.ow.WorldOffset)
                    {
                        if (e.X >= en.PlayerX && e.X < en.PlayerX + 16 && e.Y >= en.PlayerY && e.Y < en.PlayerY + 16)
                        {
                            menu.Items.Add("Exit Properties");
                            lastselectedExit = en;
                            selectedExit = null;
                            scene.mouse_down = false;

                            if (lastselectedExit == null)
                            {
                                menu.Items[0].Enabled = false;
                            }

                            clickedon = true;
                            menu.Items[0].Click += exitProperty_Click;
                            menu.Items.Add("Delete Exit");
                            menu.Items[1].Click += exitDelete_Click;
                            menu.Show(Cursor.Position);
                        }
                    }
                }

                if (!clickedon)
                {
                    mxRightclick = e.X;
                    myRightclick = e.Y;
                    menu.Items.Add("Insert Exit");
                    menu.Items[0].Click += insertExit_Click;
                    menu.Show(Cursor.Position);
                }
            }
        }

        public void insertExit_Click(object sender, EventArgs e)
        {
            AddExit();
        }

        public void exitDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public void exitProperty_Click(object sender, EventArgs e)
        {
            exitPropForm.SetExit(lastselectedExit);
            DialogResult dr = exitPropForm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                int index = Array.IndexOf(scene.ow.AllExits, lastselectedExit);
                scene.ow.AllExits[index] = exitPropForm.editingExit;
                lastselectedExit = scene.ow.AllExits[index];
                scene.selectedMode = ObjectMode.Exits;

                //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
            }
            else if (dr == DialogResult.Yes)
            {
                scene.selectedMode = ObjectMode.OWDoor;
                if (lastselectedExit.DoorType1 != 0) // Wooden door
                {
                    scene.selectedTile = new ushort[2];
                    scene.selectedTileSizeX = 2;
                    scene.selectedTile[0] = 1865;
                    scene.selectedTile[1] = 1866;

                }
                else if ((lastselectedExit.DoorType2 & 0x8000) != 0) // Castle door
                {
                    scene.selectedTile = new ushort[4];
                    scene.selectedTileSizeX = 2;
                    scene.selectedTile[0] = 3510;
                    scene.selectedTile[1] = 3511;
                    scene.selectedTile[2] = 3512;
                    scene.selectedTile[3] = 3513;
                }
                else if ((lastselectedExit.DoorType2 & 0x7FFF) != 0) // Sanctuary door
                {
                    scene.selectedTile = new ushort[2];
                    scene.selectedTileSizeX = 2;
                    scene.selectedTile[0] = 3502;
                    scene.selectedTile[1] = 3503;
                }
            }
            else
            {
                scene.selectedMode = ObjectMode.Exits;
            }

            SendExitData(lastselectedExit);
            selectedExit = null;
            scene.mouse_down = false;
        }

        public void Draw(Graphics g)
        {
            if (scene.lowEndMode)
            {
                for (int i = 0; i < 78; i++)
                {
                    g.CompositingMode = CompositingMode.SourceOver;
                    ExitOW ex = scene.ow.AllExits[i];
                    if (ex.MapID != scene.ow.AllMaps[scene.selectedMap].parent)
                    {
                        continue;
                    }

                    if (ex.MapID < 64 + scene.ow.WorldOffset && ex.MapID >= scene.ow.WorldOffset)
                    {
                        Brush bgrBrush = Constants.LightGray200Brush;
                        Brush fontBrush = Brushes.Black;

                        if (selectedExit == null)
                        {
                            if (lastselectedExit == ex)
                            {
                                g.CompositingMode = CompositingMode.SourceOver;
                                bgrBrush = Constants.MediumGray200Brush;
                                g.FillRectangle(bgrBrush, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                                g.DrawRectangle(Constants.Black200Pen, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                                scene.drawText(g, ex.PlayerX + 4, ex.PlayerY + 4, i.ToString("X2"));

                                //int sy = ex.mapId / 8;
                                //int sx = ex.mapId - (sy * 8);

                                g.DrawRectangle(Pens.LightPink, new Rectangle(ex.XScroll, ex.YScroll, 256, 224));
                                g.DrawLine(Pens.Blue, ex.CameraX - 8, ex.CameraY, ex.CameraX + 8, ex.CameraY);
                                g.DrawLine(Pens.Blue, ex.CameraX, ex.CameraY - 8, ex.CameraX, ex.CameraY + 8);
                                g.CompositingMode = CompositingMode.SourceCopy;
                                continue;
                            }

                            g.FillRectangle(bgrBrush, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                            g.DrawRectangle(Constants.Black200Pen, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                            scene.drawText(g, ex.PlayerX + 4, ex.PlayerY + 4, i.ToString("X2"));
                        }
                        else
                        {
                            if (selectedExit == ex)
                            {
                                g.CompositingMode = CompositingMode.SourceOver;

                                //g.DrawImage(jsonData.linkGfx, ex.playerX, ex.playerY, new Rectangle(16, 0, 16, 16), GraphicsUnit.Pixel);
                                //g.DrawImage(jsonData.linkGfx, ex.playerX, ex.playerY + 8, new Rectangle(48, 16, 16, 16), GraphicsUnit.Pixel);

                                g.CompositingMode = CompositingMode.SourceOver;
                                bgrBrush = Constants.MediumGray200Brush;
                                g.FillRectangle(bgrBrush, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                                g.DrawRectangle(Constants.Black200Pen, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                                scene.drawText(g, ex.PlayerX + 4, ex.PlayerY + 4, i.ToString("X2"));

                                g.CompositingMode = CompositingMode.SourceCopy;
                                //int sy = ex.mapId / 8;
                                //int sx = ex.mapId - (sy * 8);

                                g.DrawRectangle(Pens.LightPink, new Rectangle(ex.XScroll, ex.YScroll, 256, 224));
                                g.DrawLine(Pens.Blue, ex.CameraX - 8, ex.CameraY, ex.CameraX + 8, ex.CameraY);
                                g.DrawLine(Pens.Blue, ex.CameraX, ex.CameraY - 8, ex.CameraX, ex.CameraY + 8);
                            }
                            else
                            {
                                g.FillRectangle(bgrBrush, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                                g.DrawRectangle(Constants.Black200Pen, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));

                                scene.drawText(g, ex.PlayerX + 4, ex.PlayerY + 4, i.ToString("X2"));
                            }
                        }
                    }
                }

                g.CompositingMode = CompositingMode.SourceCopy;
            }
            else
            {
                for (int i = 0; i < 78; i++)
                {
                    g.CompositingMode = CompositingMode.SourceOver;
                    ExitOW ex = scene.ow.AllExits[i];

                    if (ex.MapID < 64 + scene.ow.WorldOffset && ex.MapID >= scene.ow.WorldOffset)
                    {
                        Brush bgrBrush = Constants.LightGray200Brush;
                        Brush fontBrush = Brushes.Black;

                        if (selectedExit == null)
                        {
                            if (lastselectedExit == ex)
                            {
                                g.CompositingMode = CompositingMode.SourceOver;
                                bgrBrush = Constants.MediumGray200Brush;
                                g.FillRectangle(bgrBrush, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                                g.DrawRectangle(Constants.Black200Pen, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                                scene.drawText(g, ex.PlayerX + 4, ex.PlayerY + 4, i.ToString("X2"));

                                //int sy = ex.mapId / 8;
                                //int sx = ex.mapId - (sy * 8);

                                g.DrawRectangle(Pens.LightPink, new Rectangle(ex.XScroll, ex.YScroll, 256, 224));
                                g.DrawLine(Pens.Blue, ex.CameraX - 8, ex.CameraY, ex.CameraX + 8, ex.CameraY);
                                g.DrawLine(Pens.Blue, ex.CameraX, ex.CameraY - 8, ex.CameraX, ex.CameraY + 8);
                                g.CompositingMode = CompositingMode.SourceCopy;
                                continue;
                            }

                            g.FillRectangle(bgrBrush, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                            g.DrawRectangle(Constants.Black200Pen, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                            scene.drawText(g, ex.PlayerX + 4, ex.PlayerY + 4, i.ToString("X2"));
                        }
                        else
                        {
                            if (selectedExit == ex)
                            {
                                g.CompositingMode = CompositingMode.SourceOver;

                                //g.DrawImage(jsonData.linkGfx, ex.playerX, ex.playerY, new Rectangle(16, 0, 16, 16), GraphicsUnit.Pixel);
                                //g.DrawImage(jsonData.linkGfx, ex.playerX, ex.playerY + 8, new Rectangle(48, 16, 16, 16), GraphicsUnit.Pixel);

                                g.CompositingMode = CompositingMode.SourceOver;
                                bgrBrush = Constants.MediumGray200Brush;
                                g.FillRectangle(bgrBrush, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                                g.DrawRectangle(Constants.Black200Pen, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                                scene.drawText(g, ex.PlayerX + 4, ex.PlayerY + 4, i.ToString("X2"));
                                g.CompositingMode = CompositingMode.SourceCopy;

                                //int sy = ex.mapId / 8;
                                //int sx = ex.mapId - (sy * 8);

                                g.DrawRectangle(Pens.LightPink, new Rectangle(ex.XScroll, ex.YScroll, 256, 224));
                                g.DrawLine(Pens.Blue, ex.CameraX - 8, ex.CameraY, ex.CameraX + 8, ex.CameraY);
                                g.DrawLine(Pens.Blue, ex.CameraX, ex.CameraY - 8, ex.CameraX, ex.CameraY + 8);
                            }
                            else
                            {
                                g.FillRectangle(bgrBrush, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));
                                g.DrawRectangle(Constants.Black200Pen, new Rectangle(ex.PlayerX, ex.PlayerY, 16, 16));

                                scene.drawText(g, ex.PlayerX + 4, ex.PlayerY + 4, i.ToString("X2"));
                            }
                        }
                    }
                }

                g.CompositingMode = CompositingMode.SourceCopy;
            }
        }

        public void DrawTempExit()
        {
            Graphics g = Graphics.FromImage(scene.owForm.tmpPreviewBitmap);
            g.InterpolationMode = InterpolationMode.Bilinear;
            if (scene.mainForm.previewRoom.bg2 != Background2.Translucent || scene.mainForm.previewRoom.bg2 != Background2.Transparent ||
             scene.mainForm.previewRoom.bg2 != Background2.OnTop || scene.mainForm.previewRoom.bg2 != Background2.Off)
            {
                g.DrawImage(GFX.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
            }

            g.DrawImage(GFX.roomBg1Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);

            if (scene.mainForm.previewRoom.bg2 == Background2.Translucent || scene.mainForm.previewRoom.bg2 == Background2.Transparent)
            {
                float[][] matrixItems ={
                new float[] {1f, 0, 0, 0, 0},
                new float[] {0, 1f, 0, 0, 0},
                new float[] {0, 0, 1f, 0, 0},
                new float[] {0, 0, 0, 0.5f, 0},
                new float[] {0, 0, 0, 0, 1}};
                ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

                // Create an ImageAttributes object and set its color matrix.
                ImageAttributes imageAtt = new ImageAttributes();
                imageAtt.SetColorMatrix(
                   colorMatrix,
                   ColorMatrixFlag.Default,
                   ColorAdjustType.Bitmap
                );

                //GFX.roomBg2Bitmap.MakeTransparent(Color.Black);
                g.DrawImage(GFX.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
            }
            else if (scene.mainForm.previewRoom.bg2 == Background2.OnTop)
            {
                g.DrawImage(GFX.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
            }

            scene.mainForm.activeScene.drawText(g, 0, 0, "ROOM : " + scene.mainForm.previewRoom.index.ToString("X2"));
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.Dispose();
        }

        public void SendExitData(ExitOW exit)
        {
            if (!NetZS.connected) { return; }
            NetZSBuffer buffer = new NetZSBuffer(48);
            buffer.Write((byte)08); // entrance data
            buffer.Write((byte)NetZS.userID); //user ID
            buffer.Write((int)exit.UniqueID);
            buffer.Write((byte)exit.ScrollModY);
            buffer.Write((byte)exit.ScrollModX);
            buffer.Write((byte)exit.DoorXEditor);
            buffer.Write((byte)exit.DoorYEditor);
            buffer.Write((byte)exit.AreaX);
            buffer.Write((byte)exit.AreaY);
            buffer.Write((short)exit.VRAMLocation);
            buffer.Write((short)exit.RoomID);
            buffer.Write((short)exit.XScroll);
            buffer.Write((short)exit.YScroll);
            buffer.Write((short)exit.CameraX);
            buffer.Write((short)exit.CameraY);
            buffer.Write((short)exit.DoorType1);
            buffer.Write((short)exit.DoorType2);
            buffer.Write((ushort)exit.PlayerX);
            buffer.Write((ushort)exit.PlayerY);
            buffer.Write((byte)(exit.IsAutomatic ? 1 : 0));
            buffer.Write((byte)(exit.Deleted ? 1 : 0));
            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();

        }

    }
}
