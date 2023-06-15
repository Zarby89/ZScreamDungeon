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
                if (item.roomMapId >= 0 + (scene.ow.WorldOffset) && item.roomMapId < (64 + scene.ow.WorldOffset))
                {
                    if (e.X >= item.x && e.X <= item.x + 16 && e.Y >= item.y && e.Y <= item.y + 16)
                    {
                        selectedItem = item;
                        lastselectedItem = item;
                        byte nid = item.id;
                        if ((item.id & 0x80) == 0x80)
                        {
                            nid = (byte)(((item.id - 0x80) / 2) + 0x17);
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
                    byte mid = scene.ow.AllMaps[scene.mapHover + scene.ow.WorldOffset].parent;
                    if (mid == 255)
                    {
                        mid = (byte)(scene.mapHover + scene.ow.WorldOffset);
                    }
                    selectedItem.updateMapStuff(mid);
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
            int mouseTileX = e.X / 16;
            int mouseTileY = e.Y / 16;
            int mapX = (mouseTileX / 32);
            int mapY = (mouseTileY / 32);

            scene.mapHover = mapX + (mapY * 8);

            if (selectedItem != null)
            {
                if (isLeftPress)
                {
                    if (scene.mouse_down)
                    {
                        selectedItem.x = (e.X / 16) * 16;
                        selectedItem.y = (e.Y / 16) * 16;

                        // scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));

                    }
                }
            }
        }

        public void Delete()
        {
            if (lastselectedItem != null)
            {
                lastselectedItem.deleted = true;
                SendItemData(lastselectedItem);
                scene.ow.AllItems.Remove(lastselectedItem);
                lastselectedItem = null;

                //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                //scene.mainForm.itemOWGroupbox.Visible = false;
            }
        }

        public void Draw(Graphics g)
        {
            scene.ow.AllItems.RemoveAll(x => x.deleted);
            if (scene.lowEndMode)
            {
                Brush bgrBrush;
                g.CompositingMode = CompositingMode.SourceOver;
                foreach (RoomPotSaveEditor item in scene.ow.AllItems)
                {
                    if (item.roomMapId != scene.ow.AllMaps[scene.selectedMap].parent)
                    {
                        continue;
                    }

                    if (item.roomMapId >= (0 + scene.ow.WorldOffset) && item.roomMapId < (64 + scene.ow.WorldOffset))
                    {

                        bgrBrush = (selectedItem == item) ? Constants.Turquoise200Brush : Constants.Scarlet200Brush;

                        g.FillRectangle(bgrBrush, new Rectangle((item.x), (item.y), 16, 16));
                        g.DrawRectangle(Constants.Black200Pen, new Rectangle((item.x), (item.y), 16, 16));
                        byte nid = item.id;

                        if ((item.id & 0x80) == 0x80)
                        {
                            nid = (byte)(((item.id - 0x80) / 2) + 0x17);
                        }

                        if (nid > ItemsNames.name.Length)
                        {
                            continue;
                        }

                        scene.drawText(g, (item.x) - 1, (item.y) + 1, item.id.ToString("X2") + " - " + ItemsNames.name[nid]);
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
                    if (item.roomMapId >= (0 + scene.ow.WorldOffset) && item.roomMapId < (64 + scene.ow.WorldOffset))
                    {
                        bgrBrush = (selectedItem == item) ? Constants.Turquoise200Brush : Constants.Scarlet200Brush;

                        g.FillRectangle(bgrBrush, new Rectangle((item.x), (item.y), 16, 16));
                        g.DrawRectangle(Constants.Black200Pen, new Rectangle((item.x), (item.y), 16, 16));
                        byte nid = item.id;

                        if ((item.id & 0x80) == 0x80)
                        {
                            nid = (byte)(((item.id - 0x80) / 2) + 0x17);
                        }

                        if (nid > ItemsNames.name.Length)
                        {
                            continue;
                        }

                        scene.drawText(g, (item.x) - 1, (item.y) + 1, item.id.ToString("X2") + " - " + ItemsNames.name[nid]);
                    }
                }

                g.CompositingMode = CompositingMode.SourceCopy;
            }
        }

        public void SendItemData(RoomPotSaveEditor item)
        {
            if (!NetZS.connected) { return; }
            NetZSBuffer buffer = new NetZSBuffer(24);
            buffer.Write((byte)09); // pot item data
            buffer.Write((byte)NetZS.userID); //user ID
            buffer.Write((int)item.uniqueID);
            buffer.Write((byte)item.gameX);
            buffer.Write((byte)item.gameY);
            buffer.Write((byte)item.id);
            buffer.Write((int)item.x);
            buffer.Write((int)item.y);
            buffer.Write((ushort)item.roomMapId);
            buffer.Write((byte)(item.bg2 ? 1 : 0));
            buffer.Write((byte)(item.deleted ? 1 : 0));
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
