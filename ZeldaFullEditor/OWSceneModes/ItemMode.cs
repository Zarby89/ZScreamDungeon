using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            foreach (RoomPotSaveEditor item in scene.ow.allitems)
            {
                if (item.roomMapId >= 0 + (scene.ow.worldOffset) && item.roomMapId < (64 + scene.ow.worldOffset))
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
                scene.ow.allitems.Add(data);
                selectedItem = data;
                lastselectedItem = selectedItem;
                isLeftPress = true;
                scene.mouse_down = true;

                //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
            }
        }

        public void onMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedItem != null)
                {
                    byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
                    if (mid == 255)
                    {
                        mid = (byte)(scene.mapHover + scene.ow.worldOffset);
                    }
                    selectedItem.updateMapStuff(mid);
                    lastselectedItem = selectedItem;
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
            scene.ow.allitems.Add(pitem);
            selectedItem = pitem;
            lastselectedItem = selectedItem;
            isLeftPress = true;
            scene.mouse_down = true;

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
                        selectedItem.x = (e.X/16) * 16;
                        selectedItem.y = (e.Y/16) * 16;

                       // scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));

                    }
                }
            }
        }

        public void Delete()
        {
            if (lastselectedItem != null)
            {
                scene.ow.allitems.Remove(lastselectedItem);
                lastselectedItem = null;

                //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                //scene.mainForm.itemOWGroupbox.Visible = false;
            }
        }

        public void Draw(Graphics g)
        {
            if (scene.lowEndMode)
            {
                int transparency = 200;
                Brush bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 200, 0, 0));
                Pen contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
                g.CompositingMode = CompositingMode.SourceOver;
                foreach (RoomPotSaveEditor item in scene.ow.allitems)
                {
                    if (item.roomMapId != scene.ow.allmaps[scene.selectedMap].parent)
                    {
                        continue;
                    }

                    if (item.roomMapId >= (0 + scene.ow.worldOffset) && item.roomMapId < (64 + scene.ow.worldOffset))
                    {

                        if (selectedItem == item)
                        {
                            bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 00, 200, 200));
                            contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));

                        }
                        else
                        {
                            bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 200, 0, 0));
                            contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
                        }

                        g.FillRectangle(bgrBrush, new Rectangle((item.x), (item.y), 16, 16));
                        g.DrawRectangle(contourPen, new Rectangle((item.x), (item.y), 16, 16));
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
                int transparency = 200;
                Brush bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 200, 0, 0));
                Pen contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
                g.CompositingMode = CompositingMode.SourceOver;

                foreach (RoomPotSaveEditor item in scene.ow.allitems)
                {
                    if (item.roomMapId >= (0 + scene.ow.worldOffset) && item.roomMapId < (64 + scene.ow.worldOffset))
                    {
                        if (selectedItem == item)
                        {
                            bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 00, 200, 200));
                            contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));

                        }
                        else
                        {
                            bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 200, 0, 0));
                            contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
                        }

                        g.FillRectangle(bgrBrush, new Rectangle((item.x), (item.y), 16, 16));
                        g.DrawRectangle(contourPen, new Rectangle((item.x), (item.y), 16, 16));
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
    }
}
