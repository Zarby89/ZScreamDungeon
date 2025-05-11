using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Lidgren.Network;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.OWSceneModes
{
    public class ItemMode
    {
        public RoomPotSaveEditor selectedItem;
        public RoomPotSaveEditor lastselectedItem;
        SceneOW scene;
        public bool isLeftPress = false;

        public ItemMode(SceneOW scene)
        {
            this.scene = scene;
        }

        public void onMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLeftPress = true;
            }
            else
            {
                isLeftPress = false;
            }

            foreach (RoomPotSaveEditor item in scene.ow.AllItems)
            {
                if (item.RoomMapID >= 0 + (scene.ow.WorldOffset) && item.RoomMapID < (64 + scene.ow.WorldOffset))
                {
                    if (e.X >= item.X && e.X <= item.X + 16 && e.Y >= item.Y && e.Y <= item.Y + 16)
                    {
                        selectedItem = item;
                        lastselectedItem = item;
                        byte nid = item.ID;
                        if ((item.ID & 0x80) == 0x80)
                        {
                            nid = (byte)(((item.ID - 0x80) / 2) + 0x17);
                        }

                        //scene.mainForm.owcombobox.SelectedIndex = nid;
                        //scene.mainForm.itemOWGroupbox.Visible = true;
                    }
                }
            }

            scene.mouse_down = true;
        }

        public void Copy()
        {
            Clipboard.Clear();
            RoomPotSaveEditor id = lastselectedItem.Copy();
            Clipboard.SetData("owitem", id);
        }

        public void Cut()
        {
            Clipboard.Clear();
            RoomPotSaveEditor id = lastselectedItem.Copy();
            Clipboard.SetData("owitem", id);
            Delete();

            //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
        }

        public void Paste()
        {
            RoomPotSaveEditor data = (RoomPotSaveEditor)Clipboard.GetData("owitem");
            if (data != null)
            {
                scene.ow.AllItems.Add(data);
                selectedItem = data;
                lastselectedItem = selectedItem;
                isLeftPress = true;
                scene.mouse_down = true;
                SendItemData(lastselectedItem);
                //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
            }
        }

        public void onMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedItem != null)
                {
                    byte mapID = scene.ow.AllMaps[scene.mapHover + scene.ow.WorldOffset].ParentID;
                    if (mapID == 255)
                    {
                        mapID = (byte)(scene.mapHover + scene.ow.WorldOffset);
                    }

                    bool large = scene.ow.AllMaps[mapID].AreaSize;
                    selectedItem.UpdateMapStuff(mapID, large);
                    lastselectedItem = selectedItem;
                    SendItemData(lastselectedItem);
                    selectedItem = null;
                }
                else
                {
                    lastselectedItem = null;
                    //scene.mainForm.itemOWGroupbox.Visible = false;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Add Item");
                menu.Items.Add("Delete Item");

                if (lastselectedItem == null)
                {
                    menu.Items[1].Enabled = false;
                }

                menu.Items[0].Click += addItem_Click;
                menu.Items[1].Click += deleteItem_Click;
                menu.Show(Cursor.Position);
            }

            scene.mouse_down = false;
        }

        private void deleteItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            RoomPotSaveEditor pitem = new RoomPotSaveEditor(0, 0, 0, 0, false);
            scene.ow.AllItems.Add(pitem);
            selectedItem = pitem;
            lastselectedItem = selectedItem;
            isLeftPress = true;
            scene.mouse_down = true;
            SendItemData(lastselectedItem);
            //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
        }

        public void onMouseMove(MouseEventArgs e)
        {
            scene.mouseX_Real = e.X;
            scene.mouseY_Real = e.Y;
            int mouseTileX = e.X.Clamp(0, 4080) / 16;
            int mouseTileY = e.Y.Clamp(0, 4080) / 16;
            int mapX = (mouseTileX / 32);
            int mapY = (mouseTileY / 32);

            scene.mapHover = mapX + (mapY * 8);

            if (selectedItem != null)
            {
                if (isLeftPress)
                {
                    if (scene.mouse_down)
                    {
                        selectedItem.X = ((e.X / 16) * 16).Clamp(0, 4080);
                        selectedItem.Y = ((e.Y / 16) * 16).Clamp(0, 4080);

                        // scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                    }
                }
            }
        }

        public void Delete()
        {
            if (lastselectedItem != null)
            {
                lastselectedItem.Deleted = true;
                SendItemData(lastselectedItem);
                scene.ow.AllItems.Remove(lastselectedItem);
                lastselectedItem = null;

                //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                //scene.mainForm.itemOWGroupbox.Visible = false;
            }
        }

        public void Draw(Graphics g)
        {
            scene.ow.AllItems.RemoveAll(x => x.Deleted);
            if (scene.lowEndMode)
            {
                Brush bgrBrush;
                g.CompositingMode = CompositingMode.SourceOver;
                foreach (RoomPotSaveEditor item in scene.ow.AllItems)
                {
                    if (item.RoomMapID != scene.ow.AllMaps[scene.selectedMap].ParentID)
                    {
                        continue;
                    }

                    if (item.RoomMapID >= (0 + scene.ow.WorldOffset) && item.RoomMapID < (64 + scene.ow.WorldOffset))
                    {

                        bgrBrush = (selectedItem == item) ? Constants.Turquoise200Brush : Constants.Scarlet200Brush;

                        g.FillRectangle(bgrBrush, new Rectangle((item.X), (item.Y), 16, 16));
                        g.DrawRectangle(Constants.Black200Pen, new Rectangle((item.X), (item.Y), 16, 16));
                        byte nid = item.ID;

                        if ((item.ID & 0x80) == 0x80)
                        {
                            nid = (byte)(((item.ID - 0x80) / 2) + 0x17);
                        }

                        if (nid > ItemsNames.name.Length)
                        {
                            continue;
                        }

                        scene.drawText(g, (item.X) - 1, (item.Y) + 1, item.ID.ToString("X2") + " - " + ItemsNames.name[nid]);
                    }
                }

                g.CompositingMode = CompositingMode.SourceCopy;
            }
            else
            {
                Brush bgrBrush;
                g.CompositingMode = CompositingMode.SourceOver;

                foreach (RoomPotSaveEditor item in scene.ow.AllItems)
                {
                    if (item.RoomMapID >= (0 + scene.ow.WorldOffset) && item.RoomMapID < (64 + scene.ow.WorldOffset))
                    {
                        bgrBrush = (selectedItem == item) ? Constants.Turquoise200Brush : Constants.Scarlet200Brush;

                        g.FillRectangle(bgrBrush, new Rectangle((item.X), (item.Y), 16, 16));
                        g.DrawRectangle(Constants.Black200Pen, new Rectangle((item.X), (item.Y), 16, 16));
                        byte nid = item.ID;

                        if ((item.ID & 0x80) == 0x80)
                        {
                            nid = (byte)(((item.ID - 0x80) / 2) + 0x17);
                        }

                        if (nid > ItemsNames.name.Length)
                        {
                            continue;
                        }

                        scene.drawText(g, (item.X) - 1, (item.Y) + 1, item.ID.ToString("X2") + " - " + ItemsNames.name[nid]);
                    }
                }

                g.CompositingMode = CompositingMode.SourceCopy;
            }
        }

        public void SendItemData(RoomPotSaveEditor item)
        {
            if (!NetZS.connected)
            {
                return;
            }

            NetZSBuffer buffer = new NetZSBuffer(24);
            buffer.Write((byte)09); // pot item data
            buffer.Write((byte)NetZS.userID); //user ID
            buffer.Write((int)item.UniqueID);
            buffer.Write((byte)item.GameX);
            buffer.Write((byte)item.GameY);
            buffer.Write((byte)item.ID);
            buffer.Write((int)item.X);
            buffer.Write((int)item.Y);
            buffer.Write((ushort)item.RoomMapID);
            buffer.Write((byte)(item.BG2 ? 1 : 0));
            buffer.Write((byte)(item.Deleted ? 1 : 0));
            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();
            /*
		public byte gameX, 
			gameY, 
			id;
		public int x, 
			y;
		public bool bg2 = false;
		public ushort roomMapId;
			 */
        }
    }
}
