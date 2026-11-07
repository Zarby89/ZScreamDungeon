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
                    if (en._mapId >= scene.ow.WorldOffset && en._mapId < 64 + scene.ow.WorldOffset)
                    {
                        if (e.X >= en._playerX && e.X < en._playerX + 16 && e.Y >= en._playerY && e.Y < en._playerY + 16)
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

            if (scene.mapHover + scene.ow.WorldOffset >= Constants.NumberOfOWMaps)
            {
                selectedTransport._playerY = (ushort)e.Y.Clamp(0, 2040);
            }

            if (scene.snapToGrid)
            {
                x = (ushort)((e.X / 8) * 8).Clamp(0, 4088);
                y = (ushort)((e.Y / 8) * 8).Clamp(0, 4088);

                if (scene.mapHover + scene.ow.WorldOffset >= Constants.NumberOfOWMaps)
                {
                    y = (ushort)((e.Y / 8) * 8).Clamp(0, 2040);
                }
            }

            selectedTransport._playerX = x;
            selectedTransport._playerY = y;

            int childMapID = scene.mapHover + scene.ow.WorldOffset;
            childMapID = childMapID.Clamp(0, 0x9F);
            byte mapID = scene.ow.AllMaps[childMapID].ParentID;

            if (mapID == 0xFF)
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
                    if (transport._mapId >= scene.ow.WorldOffset && transport._mapId < 0x40 + scene.ow.WorldOffset)
                    {
                        if (e.X >= transport._playerX && e.X < transport._playerX + 16 && e.Y >= transport._playerY && e.Y < transport._playerY + 16)
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
            transportForm.mapDestinationBox.Text = lastselectedTransport._whirlpoolPos.ToString("X2");
            transportForm.worldComboBox.SelectedIndex = lastselectedTransport._mapId / 0x40;

            if (transportForm.ShowDialog() == DialogResult.OK)
            {
                lastselectedTransport._whirlpoolPos = (ushort)Int32.Parse(transportForm.mapDestinationBox.Text, NumberStyles.HexNumber);

                bool shifted = false;

                // If the new map ID is greater than 0xA0, subtract the Y coordinate by 1 (mapID - 0x08) until it is < 0xA0.
                int newMapID = (lastselectedTransport._mapId % 0x40) + (0x40 * transportForm.worldComboBox.SelectedIndex);
                while (newMapID >= Constants.NumberOfOWMaps)
                {
                    newMapID -= 0x08;

                    lastselectedTransport._playerY -= 512;

                    shifted = true;
                }

                if (shifted)
                {
                    AreaSizeEnum areaSize = scene.ow.AllMaps[lastselectedTransport._mapId].AreaSize;
                    if (areaSize == AreaSizeEnum.LargeArea || areaSize == AreaSizeEnum.TallArea)
                    {
                        lastselectedTransport._playerY -= 512; 
                    }

                    lastselectedTransport._playerX = Math.Clamp(lastselectedTransport._playerX, 0, 2040);
                    lastselectedTransport._playerY = Math.Clamp(lastselectedTransport._playerY, 0, 2040);
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
                    if (e._mapId != scene.ow.AllMaps[scene.selectedMap].ParentID)
                    {
                        continue;
                    }

                    if (e._mapId < 0x40 + scene.ow.WorldOffset && e._mapId >= scene.ow.WorldOffset)
                    {
                        if (selectedTransport != null)
                        {
                            if (e == selectedTransport)
                            {
                                bgrBrush = Constants.Azure200Brush;
                                scene.drawText(g, e._playerX - 1, e._playerY + 16, "map : " + e._mapId.ToString());

                                // scene.drawText(g, e.playerX - 1, e.playerY + 26, "entrance : " + e.mapId.ToString());
                                scene.drawText(g, e._playerX - 4, e._playerY + 36, "mpos : " + e._vramLocation.ToString());
                            }
                            else
                            {
                                bgrBrush = Constants.Goldenrod200Brush;
                            }
                        }

                        g.FillRectangle(bgrBrush, new Rectangle(e._playerX, e._playerY, 16, 16));
                        g.DrawRectangle(Constants.Black200Pen, new Rectangle(e._playerX, e._playerY, 16, 16));
                        scene.drawText(g, e._playerX + 4, e._playerY + 4, i.ToString("X2") + " - Transport - " + i.ToString("X2"));

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

                    if (e._mapId < 0x40 + scene.ow.WorldOffset && e._mapId >= scene.ow.WorldOffset)
                    {
                        if (selectedTransport != null)
                        {
                            if (e == selectedTransport)
                            {
                                bgrBrush = Constants.Azure200Brush;
                                scene.drawText(g, e._playerX - 1, e._playerY + 16, "map : " + e._mapId.ToString());

                                // scene.drawText(g, e.playerX - 1, e.playerY + 26, "entrance : " + e.mapId.ToString());
                                scene.drawText(g, e._playerX - 4, e._playerY + 36, "mpos : " + e._vramLocation.ToString());
                            }
                            else
                            {
                                bgrBrush = Constants.Goldenrod200Brush;
                            }
                        }

                        g.FillRectangle(bgrBrush, new Rectangle(e._playerX, e._playerY, 16, 16));
                        g.DrawRectangle(Constants.Black200Pen, new Rectangle(e._playerX, e._playerY, 16, 16));
                        scene.drawText(g, e._playerX + 4, e._playerY + 4, i.ToString("X2") + " - Transport - " + i.ToString("X2"));

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

            buffer.Write((byte)transport._unk1);
            buffer.Write((byte)transport._unk2);
            buffer.Write((byte)transport.AreaX);
            buffer.Write((byte)transport.AreaY);

            buffer.Write((short)transport._vramLocation);
            buffer.Write((short)transport._xScroll);
            buffer.Write((short)transport._yScroll);
            buffer.Write((short)transport._playerX);
            buffer.Write((short)transport._playerY);
            buffer.Write((short)transport._cameraX);
            buffer.Write((short)transport._cameraY);
            buffer.Write((short)transport._mapId);
            buffer.Write((short)transport._whirlpoolPos);

            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();
        }
    }
}
