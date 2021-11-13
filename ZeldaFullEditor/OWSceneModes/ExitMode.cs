using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.OWSceneModes
{
    public class ExitMode
    {
        SceneOW scene;
        public ExitOW selectedExit = null;
        public ExitOW lastselectedExit = null;
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
            }
        }

        public ExitOW AddExit(bool clipboard = false)
        {
            int found = -1;
            for (int i = 0; i < scene.ow.allexits.Length; i++)
            {
                if (scene.ow.allexits[i].deleted)
                {
                    byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
                    if (mid == 255)
                    {
                        mid = (byte)(scene.mapHover + scene.ow.worldOffset);
                    }
                    scene.ow.allexits[i].deleted = false;
                    scene.ow.allexits[i].mapId = mid;
                    scene.ow.allexits[i].playerX = (ushort)((mxRightclick / 16) * 16);
                    scene.ow.allexits[i].playerY = (ushort)((myRightclick / 16) * 16);

                    if (clipboard)
                    {
                        ExitOW data = (ExitOW)Clipboard.GetData("owexit");
                        if (data != null)
                        {
                            scene.ow.allexits[i].cameraX = data.cameraX;
                            scene.ow.allexits[i].cameraY = data.cameraY;
                            scene.ow.allexits[i].xScroll = data.xScroll;
                            scene.ow.allexits[i].yScroll = data.yScroll;
                            scene.ow.allexits[i].unk1 = data.unk1;
                            scene.ow.allexits[i].unk2 = data.unk2;
                            scene.ow.allexits[i].roomId = data.roomId;
                            scene.ow.allexits[i].doorType1 = data.doorType1;
                            scene.ow.allexits[i].doorType2 = data.doorType2;
                            scene.ow.allexits[i].doorXEditor = data.doorXEditor;
                            scene.ow.allexits[i].doorYEditor = data.doorYEditor;
                        }
                    }

                    scene.ow.allexits[i].updateMapStuff(mid, scene.ow);


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

                return scene.ow.allexits[found];
        }


        public void onMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
                for (int i = 0; i < 78; i++)
                {
                    ExitOW en = scene.ow.allexits[i];
                    if (en.mapId >= scene.ow.worldOffset && en.mapId < 64+ scene.ow.worldOffset)
                    {
                        if (e.X >= en.playerX && e.X < en.playerX + 16 && e.Y >= en.playerY && e.Y < en.playerY + 16)
                        {
                            if (scene.mouse_down == false)
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
                int roomId = selectedExit.roomId;
                if (roomId >= 296)
                {
                    //scene.owForm.thumbnailBox.Visible = false;
                    return;
                }

                if (scene.mainForm.lastRoomID != roomId)
                {
                    scene.mainForm.previewRoom = DungeonsData.all_rooms[roomId];
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

        public void Delete() //set exit data to 0
        {
            lastselectedExit.playerX = 0xFFFF;
            lastselectedExit.playerY = 0xFFFF;
            lastselectedExit.mapId = 0;
            lastselectedExit.roomId = 0;
            lastselectedExit.deleted = true;
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
                    selectedExit.playerX = (ushort)e.X;
                    selectedExit.playerY = (ushort)e.Y;
                    if (scene.snapToGrid)
                    {
                        selectedExit.playerX = (ushort)((e.X / 8) * 8);
                        selectedExit.playerY = (ushort)((e.Y / 8) * 8);
                    }
                    byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
                    if (mid == 255)
                    {
                        mid = (byte)(scene.mapHover + scene.ow.worldOffset);
                    }
                    selectedExit.updateMapStuff(mid, scene.ow);

                    //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                }
            }
        }

        int mxRightclick = 0;
        int myRightclick = 0;
        public void onMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedExit != null)
                {
                    lastselectedExit = selectedExit;
                    selectedExit = null;
                    scene.mouse_down = false;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                bool clickedon = false;
                ContextMenuStrip menu = new ContextMenuStrip();
                for (int i = 0; i < 78; i++)
                {

                    ExitOW en = scene.ow.allexits[i];
                    if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
                    {
                        if (e.X >= en.playerX && e.X < en.playerX + 16 && e.Y >= en.playerY && e.Y < en.playerY + 16)
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

            ExitEditorForm exitPropForm = new ExitEditorForm();
        public void exitProperty_Click(object sender, EventArgs e)
        {

            exitPropForm.SetExit(lastselectedExit);
            DialogResult dr = exitPropForm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                int index = Array.IndexOf(scene.ow.allexits, lastselectedExit);
                scene.ow.allexits[index] = exitPropForm.editingExit;
                lastselectedExit = scene.ow.allexits[index];
                scene.selectedMode = ObjectMode.Exits;
                //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
            }
            else if (dr == DialogResult.Yes)
            {
                scene.selectedMode = ObjectMode.OWDoor;
                if (lastselectedExit.doorType1 != 0) //wooden door
                {
                    scene.selectedTile = new ushort[2];
                    scene.selectedTileSizeX = 2;
                    scene.selectedTile[0] = 1865;
                    scene.selectedTile[1] = 1866;
                    
                }
                else if ((lastselectedExit.doorType2 & 0x8000) != 0) //castle door
                {
                    scene.selectedTile = new ushort[4];
                    scene.selectedTileSizeX = 2;
                    scene.selectedTile[0] = 3510;
                    scene.selectedTile[1] = 3511;
                    scene.selectedTile[2] = 3512;
                    scene.selectedTile[3] = 3513;
                }
                else if ((lastselectedExit.doorType2 & 0x7FFF) != 0) //sanc door
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
            selectedExit = null;
            scene.mouse_down = false;
        }

        public void Draw(Graphics g)
        {
            int transparency = 200;
            if (scene.lowEndMode)
            {
                for (int i = 0; i < 78; i++)
                {
                    g.CompositingMode = CompositingMode.SourceOver;
                    ExitOW ex = scene.ow.allexits[i];
                    if (ex.mapId != scene.ow.allmaps[scene.selectedMap].parent)
                    {
                        continue;
                    }
                    if (ex.mapId < 64 + scene.ow.worldOffset && ex.mapId >= scene.ow.worldOffset)
                    {

                        Brush bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 222, 222, 222));
                        Pen contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
                        Brush fontBrush = Brushes.Black;

                        if (selectedExit == null)
                        {
                            if (lastselectedExit == ex)
                            {
                                g.CompositingMode = CompositingMode.SourceOver;
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 160, 160, 160));
                                g.FillRectangle(bgrBrush, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                                g.DrawRectangle(contourPen, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                                scene.drawText(g, ex.playerX + 4, ex.playerY + 4, i.ToString("X2"));

                                int sy = ex.mapId / 8;
                                int sx = ex.mapId - (sy * 8);

                                g.DrawRectangle(Pens.LightPink, new Rectangle(ex.xScroll, ex.yScroll, 256, 224));
                                g.DrawLine(Pens.Blue, ex.cameraX - 8, ex.cameraY, ex.cameraX + 8, ex.cameraY);
                                g.DrawLine(Pens.Blue, ex.cameraX, ex.cameraY - 8, ex.cameraX, ex.cameraY + 8);
                                g.CompositingMode = CompositingMode.SourceCopy;
                                continue;
                            }
                            g.FillRectangle(bgrBrush, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                            g.DrawRectangle(contourPen, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                            scene.drawText(g, ex.playerX + 4, ex.playerY + 4, i.ToString("X2"));
                        }
                        else
                        {
                            if (selectedExit == ex)
                            {
                                g.CompositingMode = CompositingMode.SourceOver;

                                //g.DrawImage(jsonData.linkGfx, ex.playerX, ex.playerY, new Rectangle(16, 0, 16, 16), GraphicsUnit.Pixel);
                                //g.DrawImage(jsonData.linkGfx, ex.playerX, ex.playerY + 8, new Rectangle(48, 16, 16, 16), GraphicsUnit.Pixel);
                                g.CompositingMode = CompositingMode.SourceOver;
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 160, 160, 160));
                                g.FillRectangle(bgrBrush, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                                g.DrawRectangle(contourPen, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                                scene.drawText(g, ex.playerX + 4, ex.playerY + 4, i.ToString("X2"));
                                g.CompositingMode = CompositingMode.SourceCopy;
                                int sy = ex.mapId / 8;
                                int sx = ex.mapId - (sy * 8);
                                g.DrawRectangle(Pens.LightPink, new Rectangle(ex.xScroll, ex.yScroll, 256, 224));
                                g.DrawLine(Pens.Blue, ex.cameraX - 8, ex.cameraY, ex.cameraX + 8, ex.cameraY);
                                g.DrawLine(Pens.Blue, ex.cameraX, ex.cameraY - 8, ex.cameraX, ex.cameraY + 8);
                            }
                            else
                            {
                                g.FillRectangle(bgrBrush, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                                g.DrawRectangle(contourPen, new Rectangle(ex.playerX, ex.playerY, 16, 16));

                                scene.drawText(g, ex.playerX + 4, ex.playerY + 4, i.ToString("X2"));
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
                    ExitOW ex = scene.ow.allexits[i];

                    if (ex.mapId < 64 + scene.ow.worldOffset && ex.mapId >= scene.ow.worldOffset)
                    {

                        Brush bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 222, 222, 222));
                        Pen contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
                        Brush fontBrush = Brushes.Black;

                        if (selectedExit == null)
                        {
                            if (lastselectedExit == ex)
                            {
                                g.CompositingMode = CompositingMode.SourceOver;
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 160, 160, 160));
                                g.FillRectangle(bgrBrush, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                                g.DrawRectangle(contourPen, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                                scene.drawText(g, ex.playerX + 4, ex.playerY + 4, i.ToString("X2"));

                                int sy = ex.mapId / 8;
                                int sx = ex.mapId - (sy * 8);

                                g.DrawRectangle(Pens.LightPink, new Rectangle(ex.xScroll, ex.yScroll, 256, 224));
                                g.DrawLine(Pens.Blue, ex.cameraX - 8, ex.cameraY, ex.cameraX + 8, ex.cameraY);
                                g.DrawLine(Pens.Blue, ex.cameraX, ex.cameraY - 8, ex.cameraX, ex.cameraY + 8);
                                g.CompositingMode = CompositingMode.SourceCopy;
                                continue;
                            }
                            g.FillRectangle(bgrBrush, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                            g.DrawRectangle(contourPen, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                            scene.drawText(g, ex.playerX + 4, ex.playerY + 4, i.ToString("X2"));
                        }
                        else
                        {
                            if (selectedExit == ex)
                            {
                                g.CompositingMode = CompositingMode.SourceOver;

                                //g.DrawImage(jsonData.linkGfx, ex.playerX, ex.playerY, new Rectangle(16, 0, 16, 16), GraphicsUnit.Pixel);
                                //g.DrawImage(jsonData.linkGfx, ex.playerX, ex.playerY + 8, new Rectangle(48, 16, 16, 16), GraphicsUnit.Pixel);
                                g.CompositingMode = CompositingMode.SourceOver;
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 160, 160, 160));
                                g.FillRectangle(bgrBrush, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                                g.DrawRectangle(contourPen, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                                scene.drawText(g, ex.playerX + 4, ex.playerY + 4, i.ToString("X2"));
                                g.CompositingMode = CompositingMode.SourceCopy;
                                int sy = ex.mapId / 8;
                                int sx = ex.mapId - (sy * 8);
                                g.DrawRectangle(Pens.LightPink, new Rectangle(ex.xScroll, ex.yScroll, 256, 224));
                                g.DrawLine(Pens.Blue, ex.cameraX - 8, ex.cameraY, ex.cameraX + 8, ex.cameraY);
                                g.DrawLine(Pens.Blue, ex.cameraX, ex.cameraY - 8, ex.cameraX, ex.cameraY + 8);
                            }
                            else
                            {
                                g.FillRectangle(bgrBrush, new Rectangle(ex.playerX, ex.playerY, 16, 16));
                                g.DrawRectangle(contourPen, new Rectangle(ex.playerX, ex.playerY, 16, 16));

                                scene.drawText(g, ex.playerX + 4, ex.playerY + 4, i.ToString("X2"));
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
                g.DrawImage(GFX.roomBg2Bitmap, new Rectangle(0, 0, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel);
            }

            g.DrawImage(GFX.roomBg1Bitmap, new Rectangle(0, 0, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel);

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
                   ColorAdjustType.Bitmap);
                //GFX.roomBg2Bitmap.MakeTransparent(Color.Black);
                g.DrawImage(GFX.roomBg2Bitmap, new Rectangle(0, 0, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
            }
            else if (scene.mainForm.previewRoom.bg2 == Background2.OnTop)
            {
                g.DrawImage(GFX.roomBg2Bitmap, new Rectangle(0, 0, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel);
            }

            scene.mainForm.activeScene.drawText(g, 0, 0, "ROOM : " + scene.mainForm.previewRoom.index.ToString());
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.Dispose();
        }
    }
}
