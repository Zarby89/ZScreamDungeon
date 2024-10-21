using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Markup;
using Lidgren.Network;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.OWSceneModes
{
    public class SpriteMode
    {
        Sprite selectedSprite;
        public Sprite lastselectedSprite;
        SceneOW scene;

        bool isLeftPress = false;

        Gui.AddSprite addspr = new Gui.AddSprite();

        public SpriteMode(SceneOW scene)
        {
            this.scene = scene;
        }

        public void onMouseDown(MouseEventArgs e)
        {
            if (scene.selectedDragSprite != null)
            {
                int gs = scene.ow.GameState;

                scene.selectedFormSprite = new Sprite(0, (byte)scene.selectedDragSprite.ID, 0, 0, 0, 0);
                scene.ow.AllSprites[gs].Add(scene.selectedFormSprite);
                selectedSprite = scene.ow.AllSprites[gs].Last();
                scene.selectedDragSprite = null;
                scene.mouse_down = true;
                isLeftPress = true;
                return;
            }


            isLeftPress = e.Button == MouseButtons.Left;

            for (int i = scene.ow.WorldOffset; i < 64 + scene.ow.WorldOffset; i++)
            {
                if (i > 159)
                {
                    continue;
                }

                int gs = scene.ow.GameState;
                
                foreach (Sprite spr in scene.ow.AllSprites[gs]) // TODO : Check if that need to be changed to LINQ mapid == maphover
                {
                    if (e.X >= spr.map_x && e.X <= spr.map_x + 16 && e.Y >= spr.map_y && e.Y <= spr.map_y + 16 && spr.mapid == scene.selectedMapParent)
                    {
                        selectedSprite = spr;


                    }

                    //Console.WriteLine("X:" + spr.map_x + ", Y:" + spr.map_y);
                }
            }

            scene.mouse_down = true;
        }

        public void Copy()
        {
            Clipboard.Clear();
            int sd = lastselectedSprite.id;
            Clipboard.SetData("owsprite", sd);
        }

        public void Cut()
        {
            Clipboard.Clear();
            int sd = lastselectedSprite.id;
            Clipboard.SetData("owsprite", sd);
            SendSpriteData(lastselectedSprite);
            //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
        }


        public void Paste()
        {
            int data = (int)Clipboard.GetData("owsprite");
            if (data != -1)
            {
                scene.selectedFormSprite = new Sprite(0, (byte)data, 0, 0, 0, 0);
                byte mid = scene.ow.AllMaps[scene.mapHover + scene.ow.WorldOffset].ParentID;
                if (mid == 255)
                {
                    mid = (byte)(scene.mapHover + scene.ow.WorldOffset);
                }

                scene.selectedFormSprite.updateMapStuff(mid);
                int gs = scene.ow.GameState;
                if (mid >= 64)
                {
                    if (gs == 0)
                    {
                        MessageBox.Show("Can't add sprite in rain state in the Dark World!");
                        return;
                    }
                }

                scene.ow.AllSprites[gs].Add(scene.selectedFormSprite);
                selectedSprite = scene.ow.AllSprites[gs].Last();
                scene.selectedFormSprite = null;
                scene.mouse_down = true;
                isLeftPress = true;
                SendSpriteData(selectedSprite);
                //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
            }
        }


        public void onMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                byte mid = scene.ow.AllMaps[scene.mapHover + scene.ow.WorldOffset].ParentID;
                if (mid == 255)
                {
                    mid = (byte)(scene.mapHover + scene.ow.WorldOffset);
                }

                if (scene.selectedFormSprite != null)
                {
                    scene.selectedFormSprite.updateMapStuff(mid);
                    int gs = scene.ow.GameState;

                    if (mid >= 64)
                    {
                        if (gs == 0)
                        {
                            MessageBox.Show("Can't add sprite in rain state in the Dark World!");
                            return;
                        }
                    }

                    scene.ow.AllSprites[gs].Add(scene.selectedFormSprite);
                    scene.selectedFormSprite = null;

                    //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                }
                if (selectedSprite != null)
                {
                    selectedSprite.updateMapStuff(mid);
                    lastselectedSprite = selectedSprite;
                    SendSpriteData(selectedSprite);
                    selectedSprite = null;

                    //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                }
                else
                {
                    lastselectedSprite = null;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Add Sprite");
                menu.Items.Add("Sprite Properties");
                menu.Items.Add("Delete Sprite");

                if (lastselectedSprite == null)
                {
                    menu.Items[1].Enabled = false;
                    menu.Items[2].Enabled = false;
                }

                menu.Items[0].Click += addSprite_Click;
                menu.Items[1].Click += spriteProperties_Click;
                menu.Items[2].Click += deleteSprite_Click;
                menu.Show(Cursor.Position);
            }

            scene.mouse_down = false;
        }

        private void deleteSprite_Click(object sender, EventArgs e)
        {
            Delete();

        }

        private void spriteProperties_Click(object sender, EventArgs e)
        {
            // Nothing for now
        }

        private void addSprite_Click(object sender, EventArgs e)
        {
            if (addspr.ShowDialog() == DialogResult.OK)
            {
                byte data = (byte)addspr.spriteListBox.SelectedIndex;
                scene.selectedFormSprite = new Sprite(0, data, 0, 0, (scene.mouseX_Real / 16), (scene.mouseY_Real / 16));
                byte mid = scene.ow.AllMaps[scene.mapHover + scene.ow.WorldOffset].ParentID;

                if (mid == 255)
                {
                    mid = (byte)(scene.mapHover + scene.ow.WorldOffset);
                }

                scene.selectedFormSprite.updateMapStuff(mid);
                int gs = scene.ow.GameState;

                if (mid >= 64)
                {
                    if (gs == 0)
                    {
                        MessageBox.Show("Can't add sprite in rain state in the Dark World!");
                        return;
                    }
                }

                scene.ow.AllSprites[gs].Add(scene.selectedFormSprite);
                selectedSprite = scene.ow.AllSprites[gs].Last();
                scene.selectedFormSprite = null;
                scene.mouse_down = true;
                isLeftPress = true;
            }
        }

        public void onMouseMove(MouseEventArgs e)
        {
            if (scene.mouse_down)
            {
                if (scene.selectedFormSprite != null)
                {
                    scene.selectedFormSprite.map_x = (e.X / 16) * 16;
                    scene.selectedFormSprite.map_y = (e.Y / 16) * 16;

                    //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                }

                if (isLeftPress)
                {
                    int mouseTileX = e.X / 16;
                    int mouseTileY = e.Y / 16;
                    int mapX = (mouseTileX / 32);
                    int mapY = (mouseTileY / 32);

                    scene.mapHover = mapX + (mapY * 8);

                    if (selectedSprite != null)
                    {
                        selectedSprite.map_x = (e.X / 16) * 16;
                        selectedSprite.map_y = (e.Y / 16) * 16;

                        //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                    }
                }
            }
        }

        public void Delete()
        {
            if (lastselectedSprite != null)
            {
                int gs = scene.ow.GameState;
                lastselectedSprite.deleted = true;
                SendSpriteData(lastselectedSprite);
                scene.ow.AllSprites[gs].Remove(lastselectedSprite);

                lastselectedSprite = null;
                if (scene.lowEndMode)
                {
                    int x = scene.ow.AllMaps[scene.selectedMap].ParentID % 8;
                    int y = scene.ow.AllMaps[scene.selectedMap].ParentID / 8;

                    if (!scene.ow.AllMaps[scene.ow.AllMaps[scene.selectedMap].ParentID].LargeMap)
                    {
                        scene.Invalidate(new Rectangle(x * 512, y * 512, 512, 512));
                    }
                    else
                    {
                        scene.Invalidate(new Rectangle(x * 512, y * 512, 1024, 1024));
                    }
                }
                else
                {
                    scene.Invalidate(new Rectangle(scene.owForm.splitContainer1.Panel2.HorizontalScroll.Value, scene.owForm.splitContainer1.Panel2.VerticalScroll.Value, scene.owForm.splitContainer1.Panel2.Width, scene.owForm.splitContainer1.Panel2.Height));
                }

                //scene.Invalidate();
            }
        }

        public void Draw(Graphics g)
        {

            scene.ow.AllSprites[0].RemoveAll(x => x.deleted);
            scene.ow.AllSprites[1].RemoveAll(x => x.deleted);
            scene.ow.AllSprites[2].RemoveAll(x => x.deleted);

            if (scene.lowEndMode)
            {
                Brush bgrBrush = Constants.VibrantMagenta200Brush;
                g.CompositingMode = CompositingMode.SourceOver;

                for (int i = 0; i < scene.ow.AllSprites[scene.ow.GameState].Count; i++)
                {
                    Sprite spr = scene.ow.AllSprites[scene.ow.GameState][i];

                    if (spr.mapid != scene.ow.AllMaps[scene.selectedMap].ParentID)
                    {
                        continue;
                    }

                    if (spr.mapid < 64 + scene.ow.WorldOffset && spr.mapid >= scene.ow.WorldOffset)
                    {
                        /*
                        if (selectedEntrance != null)
                        {
                            if (e == selectedEntrance)
                            {
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 0, 55, 240));
                                scene.drawText(g, e.x - 1, e.y + 16, "map : " + e.mapId.ToString());
                                scene.drawText(g, e.x - 1, e.y + 26, "entrance : " + e.entranceId.ToString());
                                scene.drawText(g, e.x - 1, e.y + 36, "mpos : " + e.mapPos.ToString());
                            }
                            else
                            {
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 255, 200, 16));
                            }
                        }
                        */

                        g.FillRectangle(bgrBrush, new Rectangle(spr.map_x, spr.map_y, 16, 16));
                        g.DrawRectangle(Constants.Black200Pen, new Rectangle(spr.map_x, spr.map_y, 16, 16));
                        scene.drawText(g, spr.map_x + 4, spr.map_y + 4, spr.name);
                    }
                }

                g.CompositingMode = CompositingMode.SourceCopy;
            }
            else
            {
                Brush bgrBrush = Constants.VibrantMagenta200Brush;
                g.CompositingMode = CompositingMode.SourceOver;

                for (int i = 0; i < scene.ow.AllSprites[scene.ow.GameState].Count; i++)
                {
                    Sprite spr = scene.ow.AllSprites[scene.ow.GameState][i];

                    if (spr.mapid < 64 + scene.ow.WorldOffset && spr.mapid >= scene.ow.WorldOffset)
                    {
                        /*
                        if (selectedEntrance != null)
                        {
                            if (e == selectedEntrance)
                            {
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 0, 55, 240));
                                scene.drawText(g, e.x - 1, e.y + 16, "map : " + e.mapId.ToString());
                                scene.drawText(g, e.x - 1, e.y + 26, "entrance : " + e.entranceId.ToString());
                                scene.drawText(g, e.x - 1, e.y + 36, "mpos : " + e.mapPos.ToString());
                            }
                            else
                            {
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 255, 200, 16));
                            }
                        }
                        */

                        g.FillRectangle(bgrBrush, new Rectangle(spr.map_x, spr.map_y, 16, 16));
                        g.DrawRectangle(Constants.Black200Pen, new Rectangle(spr.map_x, spr.map_y, 16, 16));
                        scene.drawText(g, spr.map_x + 4, spr.map_y + 4, spr.name);
                    }
                }

                g.CompositingMode = CompositingMode.SourceCopy;
            }
        }

        /*
        public void Draw(Graphics g)
        {
            int transparency = 200;
            Brush bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 255, 0, 255));
            Pen contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
            g.CompositingMode = CompositingMode.SourceOver;

            for (int i = scene.ow.worldOffset; i < 64 + scene.ow.worldOffset; i++)
            {
                int gs = scene.ow.gameState;
                if (i >= 64 && i <= 128)
                {
                    gs = 0;
                }

                if (i <= 159)
                {
                    foreach (Sprite spr in scene.ow.allsprites[gs])
                    {
                        if (spr.mapid == 0)
                        {
                            if (selectedSprite == spr)
                            {
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 00, 255, 0));
                                contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
                            }
                            else if (lastselectedSprite == spr)
                            {
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 0, 180, 0));
                                contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
                            }
                            else
                            {
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 255, 0, 255));
                                contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
                            }

                            g.FillRectangle(bgrBrush, new Rectangle((spr.map_x), spr.map_y, 16, 16));
                            g.DrawRectangle(contourPen, new Rectangle(spr.map_x, spr.map_y, 16, 16));
                            scene.drawText(g, spr.map_x + 4, spr.map_y + 4, spr.name);
                        }
                    }
                }

                if (scene.selectedFormSprite != null)
                {
                    g.FillRectangle(bgrBrush, new Rectangle((scene.selectedFormSprite.map_x), (scene.selectedFormSprite.map_y), 16, 16));
                    g.DrawRectangle(contourPen, new Rectangle((scene.selectedFormSprite.map_x), (scene.selectedFormSprite.map_y), 16, 16));
                    scene.drawText(g, (scene.selectedFormSprite.map_x) + 4, (scene.selectedFormSprite.map_y) + 4, scene.selectedFormSprite.name);
                }
                
            }

            g.CompositingMode = CompositingMode.SourceCopy;
        }
        */


        private void SendSpriteData(Sprite spr)
        {
            if (!NetZS.connected) { return; }
            NetZSBuffer buffer = new NetZSBuffer(24);
            buffer.Write((byte)07); // sprite data
            buffer.Write((byte)NetZS.userID); //user ID
            buffer.Write((int)spr.uniqueID);
            buffer.Write((byte)scene.ow.GameState);
            buffer.Write((byte)spr.id);
            buffer.Write((byte)spr.mapid);
            buffer.Write((int)spr.map_x);
            buffer.Write((int)spr.map_y);
            buffer.Write((byte)spr.x);
            buffer.Write((byte)spr.y);
            buffer.Write((byte)(spr.deleted ? 1 : 0));
            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();
        }


    }
}
