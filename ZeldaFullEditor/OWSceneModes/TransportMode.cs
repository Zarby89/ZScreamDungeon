using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lidgren.Network;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.OWSceneModes
{
    public class TransportMode
    {
        SceneOW scene;
        public TransportOW selectedTransport = null;
        public TransportOW lastselectedTransport = null;

        public TransportMode(SceneOW scene)
        {
            this.scene = scene;
        }

        public void onMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < 0x11; i++)
                {
                    TransportOW en = scene.ow.allWhirlpools[i];
                    if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
                    {
                        if (e.X >= en.playerX && e.X < en.playerX + 16 && e.Y >= en.playerY && e.Y < en.playerY + 16)
                        {
                            if (!scene.mouse_down)
                            {
                                selectedTransport = en;
                                lastselectedTransport = en;
                                //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                                scene.mouse_down = true;
                            }
                        }
                    }
                }
            }
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

                if (selectedTransport != null)
                {
                    selectedTransport.playerX = (short)e.X;
                    selectedTransport.playerY = (short)e.Y;
                    if (scene.snapToGrid)
                    {
                        selectedTransport.playerX = (short)((e.X / 8) * 8);
                        selectedTransport.playerY = (short)((e.Y / 8) * 8);
                    }

                    byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
                    if (mid == 255)
                    {
                        mid = (byte)(scene.mapHover + scene.ow.worldOffset);
                    }

                    selectedTransport.updateMapStuff(mid, scene.ow);

                    //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                }
            }
        }

        public void onMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedTransport != null)
                {
                    lastselectedTransport = selectedTransport;
                    SendTransportData(selectedTransport);
                    selectedTransport = null;
                    scene.mouse_down = false;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < 0x11; i++)
                {
                    TransportOW en = scene.ow.allWhirlpools[i];
                    if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
                    {
                        if (e.X >= en.playerX && e.X < en.playerX + 16 && e.Y >= en.playerY && e.Y < en.playerY + 16)
                        {
                            ContextMenuStrip menu = new ContextMenuStrip();
                            menu.Items.Add("Whirlpool Properties");
                            lastselectedTransport = en;
                            selectedTransport = null;
                            scene.mouse_down = false;

                            if (lastselectedTransport == null)
                            {
                                menu.Items[0].Enabled = false;
                            }

                            menu.Items[0].Click += exitProperty_Click;
                            menu.Show(Cursor.Position);
                        }
                    }
                }

                //scene.Invalidate(new Rectangle((scene.owForm.splitContainer1.Panel2.HorizontalScroll.Value), (scene.owForm.splitContainer1.Panel2.VerticalScroll.Value), (scene.owForm.splitContainer1.Panel2.Width), (scene.owForm.splitContainer1.Panel2.Height)));
            }
        }

        private void exitProperty_Click(object sender, EventArgs e)
        {
            WhirlpoolForm wf = new WhirlpoolForm();
            wf.textBox1.Text = lastselectedTransport.whirlpoolPos.ToString();

            if (wf.ShowDialog() == DialogResult.OK)
            {
                short.TryParse(wf.textBox1.Text, out short v);
                lastselectedTransport.whirlpoolPos = v;
                SendTransportData(lastselectedTransport);
            }
        }

        public void Draw(Graphics g)
        {
            if (scene.lowEndMode)
            {
                Brush bgrBrush = Constants.DarkMint200Brush;
                g.CompositingMode = CompositingMode.SourceOver;

                for (int i = 0; i < scene.ow.allWhirlpools.Count; i++)
                {
                    TransportOW e = scene.ow.allWhirlpools[i];
                    if (e.mapId != scene.ow.allmaps[scene.selectedMap].parent)
                    {
                        continue;
                    }

                    if (e.mapId < 64 + scene.ow.worldOffset && e.mapId >= scene.ow.worldOffset)
                    {
                        if (selectedTransport != null)
                        {
                            if (e == selectedTransport)
                            {
                                bgrBrush = Constants.Azure200Brush;
                                scene.drawText(g, e.playerX - 1, e.playerY + 16, "map : " + e.mapId.ToString());
                                //scene.drawText(g, e.playerX - 1, e.playerY + 26, "entrance : " + e.mapId.ToString());
                                scene.drawText(g, e.playerX - 4, e.playerY + 36, "mpos : " + e.vramLocation.ToString());
                            }
                            else
                            {
                                bgrBrush = Constants.Goldenrod200Brush;
                            }
                        }

                        g.FillRectangle(bgrBrush, new Rectangle(e.playerX, e.playerY, 16, 16));
                        g.DrawRectangle(Constants.Black200Pen, new Rectangle(e.playerX, e.playerY, 16, 16));
                        scene.drawText(g, e.playerX + 4, e.playerY + 4, i.ToString("X2") + " - Transport - " + i.ToString("X2"));

                        /*
                        if (i > 8)
                        {
                            scene.drawText(g, e.playerX + 4, e.playerY + 4, i.ToString("X2") + " - Transport - " + i.ToString("X2"));
                        }
                        else
                        {
                            scene.drawText(g, e.playerX + 4, e.playerY + 4, i.ToString("X2") + " - Transport - " + i.ToString("X2"));
                        }
                        */
                    }
                }
            }
            else
            {
                Brush bgrBrush = Constants.DarkMint200Brush;
                g.CompositingMode = CompositingMode.SourceOver;

                for (int i = 0; i < scene.ow.allWhirlpools.Count; i++)
                {
                    TransportOW e = scene.ow.allWhirlpools[i];

                    if (e.mapId < 64 + scene.ow.worldOffset && e.mapId >= scene.ow.worldOffset)
                    {
                        if (selectedTransport != null)
                        {
                            if (e == selectedTransport)
                            {
                                bgrBrush = Constants.Azure200Brush;
                                scene.drawText(g, e.playerX - 1, e.playerY + 16, "map : " + e.mapId.ToString());
                                //scene.drawText(g, e.playerX - 1, e.playerY + 26, "entrance : " + e.mapId.ToString());
                                scene.drawText(g, e.playerX - 4, e.playerY + 36, "mpos : " + e.vramLocation.ToString());
                            }
                            else
                            {
                                bgrBrush = Constants.Goldenrod200Brush;
                            }
                        }

                        g.FillRectangle(bgrBrush, new Rectangle(e.playerX, e.playerY, 16, 16));
                        g.DrawRectangle(Constants.Black200Pen, new Rectangle(e.playerX, e.playerY, 16, 16));
                        scene.drawText(g, e.playerX + 4, e.playerY + 4, i.ToString("X2") + " - Transport - " + i.ToString("X2"));

                        /*
                         if (i > 8)
                        {
                            scene.drawText(g, e.playerX + 4, e.playerY + 4, i.ToString("X2") + " - Transport - " + i.ToString("X2"));
                        }
                        else
                        {
                            scene.drawText(g, e.playerX + 4, e.playerY + 4, i.ToString("X2") + " - Transport - " + i.ToString("X2"));
                        }
                        */
                    }
                }
            }
        }

        void SendTransportData(TransportOW transport)
        {
            if (!NetZS.connected) { return; }
            NetZSBuffer buffer = new NetZSBuffer(32);
            buffer.Write((byte)10); // transport data
            buffer.Write((byte)NetZS.userID); //user ID
            buffer.Write((int)transport.uniqueID);

            buffer.Write((byte)transport.unk1);
            buffer.Write((byte)transport.unk2);
            buffer.Write((byte)transport.AreaX);
            buffer.Write((byte)transport.AreaY);

            buffer.Write((short)transport.vramLocation);
            buffer.Write((short)transport.xScroll);
            buffer.Write((short)transport.yScroll);
            buffer.Write((short)transport.playerX);
            buffer.Write((short)transport.playerY);
            buffer.Write((short)transport.cameraX);
            buffer.Write((short)transport.cameraY);
            buffer.Write((short)transport.mapId);
            buffer.Write((short)transport.whirlpoolPos);

            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();
        }


    }
}
