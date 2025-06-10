using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Lidgren.Network;
using ZeldaFullEditor.Gui.ExtraForms;
using ZeldaFullEditor.Properties;
using static ZeldaFullEditor.OverworldMap;

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
                    TransportOW en = scene.ow.AllWhirlpools[i];
                    if (en.MapID >= scene.ow.WorldOffset && en.MapID < 64 + scene.ow.WorldOffset)
                    {
                        if (e.X >= en.playerX && e.X < en.playerX + 16 && e.Y >= en.playerY && e.Y < en.playerY + 16)
                        {
                            if (!scene.mouse_down)
                            {
                                selectedTransport = en;
                                lastselectedTransport = en;

                                // scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                                scene.mouse_down = true;
                            }
                        }
                    }
                }
            }
        }

        public void onMouseMove(MouseEventArgs e)
        {
            int mouseTileX = e.X.Clamp(0, 4080) / 16;
            int mouseTileY = e.Y.Clamp(0, 4080) / 16;
            int mapX = mouseTileX / 32;
            int mapY = mouseTileY / 32;

            scene.mapHover = mapX + (mapY * 8);

            if (selectedTransport == null || !scene.mouse_down)
            {
                return;
            }

            ushort x = (ushort)e.X.Clamp(0, 4088);
            ushort y = (ushort)e.Y.Clamp(0, 4088);

            if (scene.mapHover + scene.ow.WorldOffset >= 0xA0)
            {
                selectedTransport.playerY = (ushort)e.Y.Clamp(0, 2040);
            }

            if (scene.snapToGrid)
            {
                x = (ushort)((e.X / 8) * 8).Clamp(0, 4088);
                y = (ushort)((e.Y / 8) * 8).Clamp(0, 4088);

                if (scene.mapHover + scene.ow.WorldOffset >= 0xA0)
                {
                    y = (ushort)((e.Y / 8) * 8).Clamp(0, 2040);
                }
            }

            selectedTransport.playerX = x;
            selectedTransport.playerY = y;

            int childMapID = scene.mapHover + scene.ow.WorldOffset;
            childMapID = childMapID.Clamp(0, 0x9F);
            byte mapID = scene.ow.AllMaps[childMapID].ParentID;

            if (mapID == 255)
            {
                mapID = (byte)childMapID;
            }

            selectedTransport.updateMapStuff(mapID, scene.ow);

            // scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
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
                    TransportOW transport = scene.ow.AllWhirlpools[i];
                    if (transport.MapID >= scene.ow.WorldOffset && transport.MapID < 64 + scene.ow.WorldOffset)
                    {
                        if (e.X >= transport.playerX && e.X < transport.playerX + 16 && e.Y >= transport.playerY && e.Y < transport.playerY + 16)
                        {
                            ContextMenuStrip menu = new ContextMenuStrip();
                            menu.Items.Add("Transport Properties");
                            lastselectedTransport = transport;
                            selectedTransport = null;
                            scene.mouse_down = false;

                            if (lastselectedTransport == null)
                            {
                                menu.Items[0].Enabled = false;
                            }

                            menu.Items[0].Click += TransportProperty_Click;
                            menu.Show(Cursor.Position);
                        }
                    }
                }

                // scene.Invalidate(new Rectangle((scene.owForm.splitContainer1.Panel2.HorizontalScroll.Value), (scene.owForm.splitContainer1.Panel2.VerticalScroll.Value), (scene.owForm.splitContainer1.Panel2.Width), (scene.owForm.splitContainer1.Panel2.Height)));
            }
        }

        private void TransportProperty_Click(object sender, EventArgs e)
        {
            TransportForm transportForm = new TransportForm();
            transportForm.mapDestinationBox.Text = lastselectedTransport.whirlpoolPos.ToString("X2");
            transportForm.worldComboBox.SelectedIndex = lastselectedTransport.MapID / 0x40;

            if (transportForm.ShowDialog() == DialogResult.OK)
            {
                lastselectedTransport.whirlpoolPos = (ushort)Int32.Parse(transportForm.mapDestinationBox.Text, NumberStyles.HexNumber);

                bool shifted = false;

                // If the new map ID is greater than 0xA0, subtract the Y coordinate by 1 (mapID - 0x08) until it is < 0xA0.
                int newMapID = (lastselectedTransport.MapID % 0x40) + (0x40 * transportForm.worldComboBox.SelectedIndex);
                while (newMapID >= 0xA0)
                {
                    newMapID -= 0x08;

                    lastselectedTransport.playerY -= 512;

                    shifted = true;
                }

                if (shifted)
                {
                    AreaSizeEnum areaSize = scene.ow.AllMaps[lastselectedTransport.MapID].AreaSize;
                    if (areaSize == AreaSizeEnum.LargeArea || areaSize == AreaSizeEnum.TallArea)
                    {
                        lastselectedTransport.playerY -= 512; 
                    }

                    lastselectedTransport.playerX = lastselectedTransport.playerX.Clamp(0, 2040);
                    lastselectedTransport.playerY = lastselectedTransport.playerY.Clamp(0, 2040);
                }

                lastselectedTransport.updateMapStuff((byte)newMapID, scene.ow);

                SendTransportData(lastselectedTransport);
            }
        }

        public void Draw(Graphics g)
        {
            if (scene.lowEndMode)
            {
                Brush bgrBrush = Constants.DarkMint200Brush;
                g.CompositingMode = CompositingMode.SourceOver;

                for (int i = 0; i < scene.ow.AllWhirlpools.Count; i++)
                {
                    TransportOW e = scene.ow.AllWhirlpools[i];
                    if (e.MapID != scene.ow.AllMaps[scene.selectedMap].ParentID)
                    {
                        continue;
                    }

                    if (e.MapID < 64 + scene.ow.WorldOffset && e.MapID >= scene.ow.WorldOffset)
                    {
                        if (selectedTransport != null)
                        {
                            if (e == selectedTransport)
                            {
                                bgrBrush = Constants.Azure200Brush;
                                scene.drawText(g, e.playerX - 1, e.playerY + 16, "map : " + e.MapID.ToString());

                                // scene.drawText(g, e.playerX - 1, e.playerY + 26, "entrance : " + e.mapId.ToString());
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

                for (int i = 0; i < scene.ow.AllWhirlpools.Count; i++)
                {
                    TransportOW e = scene.ow.AllWhirlpools[i];

                    if (e.MapID < 0x40 + scene.ow.WorldOffset && e.MapID >= scene.ow.WorldOffset)
                    {
                        if (selectedTransport != null)
                        {
                            if (e == selectedTransport)
                            {
                                bgrBrush = Constants.Azure200Brush;
                                scene.drawText(g, e.playerX - 1, e.playerY + 16, "map : " + e.MapID.ToString());

                                // scene.drawText(g, e.playerX - 1, e.playerY + 26, "entrance : " + e.mapId.ToString());
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
            if (!NetZS.connected)
            {
                return;
            }

            NetZSBuffer buffer = new NetZSBuffer(32);
            buffer.Write((byte)10); // transport data
            buffer.Write((byte)NetZS.userID); // user ID
            buffer.Write((int)transport.ID);

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
            buffer.Write((short)transport.MapID);
            buffer.Write((short)transport.whirlpoolPos);

            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();
        }
    }
}
