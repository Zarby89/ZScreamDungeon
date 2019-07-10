using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Gui;

namespace ZeldaFullEditor.OWSceneModes
{
    public class EntranceMode
    {
        SceneOW scene;
        public EntranceOWEditor selectedEntrance = null;
        public EntranceOWEditor lastselectedEntrance = null;
        bool isLeftPress = false;
        public EntranceMode(SceneOW scene)
        {
            this.scene = scene;
        }


        public void Copy()
        {
            Clipboard.Clear();
            EntranceOWEditor ed = lastselectedEntrance.Copy();
            Clipboard.SetData("owentrance", ed);
        }

        public void Cut()
        {
            Clipboard.Clear();
            EntranceOWEditor ed = lastselectedEntrance.Copy();
            Clipboard.SetData("owentrance", ed);
            Delete();

        }

        public void Paste()
        {
            selectedEntrance = AddEntrance(true);
            if (selectedEntrance != null)
            {
                lastselectedEntrance = selectedEntrance;
                scene.mouse_down = true;
                scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
            }
        }

        public EntranceOWEditor AddEntrance(bool clipboard = false)
        {
            byte entranceID = 0;
            bool ishole = false;
            if (clipboard)
            {
                EntranceOWEditor data = (EntranceOWEditor)Clipboard.GetData("owentrance");
                if (data != null)
                {
                    entranceID = data.entranceId;
                    ishole = data.isHole;
                }
            }

            
            int found = -1;
            if (ishole)
            {
                for (int i = 0; i < scene.ow.allholes.Length; i++)
                {
                    if (scene.ow.allholes[i].deleted)
                    {
                        byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
                        if (mid == 255)
                        {
                            mid = (byte)(scene.mapHover + scene.ow.worldOffset);
                        }
                        scene.ow.allholes[i].deleted = false;
                        scene.ow.allholes[i].mapId = mid;
                        scene.ow.allholes[i].x = (ushort)((mxRightclick / 16) * 16);
                        scene.ow.allholes[i].y = (ushort)((myRightclick / 16) * 16);
                        scene.ow.allholes[i].entranceId = entranceID;


                        scene.ow.allholes[i].updateMapStuff(mid);


                        found = i;
                        scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < scene.ow.allentrances.Length; i++)
                {
                    if (scene.ow.allentrances[i].deleted)
                    {
                        byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
                        if (mid == 255)
                        {
                            mid = (byte)(scene.mapHover + scene.ow.worldOffset);
                        }
                        scene.ow.allentrances[i].deleted = false;
                        scene.ow.allentrances[i].mapId = mid;
                        scene.ow.allentrances[i].x = (ushort)((mxRightclick / 16) * 16);
                        scene.ow.allentrances[i].y = (ushort)((myRightclick / 16) * 16);
                        scene.ow.allentrances[i].entranceId = entranceID;
                        

                        scene.ow.allentrances[i].updateMapStuff(mid);


                        found = i;
                        scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                        break;
                    }
                }
            }


            if (found == -1)
            {
                if (ishole)
                {
                    MessageBox.Show("No space available for new hole, delete one first");
                }
                else
                {
                    MessageBox.Show("No space available for new entrance, delete one first");
                }
                return null;
            }

            return scene.ow.allentrances[found];
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
            for (int i = 0; i < scene.ow.allentrances.Length; i++)
            {
                EntranceOWEditor en = scene.ow.allentrances[i];
                if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
                {
                    if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
                    {
                        if (scene.mouse_down == false)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                selectedEntrance = en;
                                lastselectedEntrance = en;
                                scene.mouse_down = true;
                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                                lastselectedEntrance = en;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < scene.ow.allholes.Length; i++)
            {
                EntranceOWEditor en = scene.ow.allholes[i];
                if (en.mapId >= scene.ow.worldOffset && en.mapId < 64+ scene.ow.worldOffset)
                {
                    if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
                    {
                        if (scene.mouse_down == false)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                selectedEntrance = en;
                                lastselectedEntrance = en;
                                scene.mouse_down = true;
                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                                lastselectedEntrance = en;
                            }
                        }
                    }
                }
            }
 
        }

        public void onMouseDoubleClick(MouseEventArgs e)
        {
            for (int i = 0; i < scene.ow.allentrances.Length; i++)
            {
                EntranceOWEditor en = scene.ow.allentrances[i];
                if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
                {
                    if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            scene.mainForm.selectedEntrance = scene.mainForm.entrances[en.entranceId];
                            scene.mainForm.addRoomTab(scene.mainForm.entrances[en.entranceId].Room);
                            scene.mainForm.dungeonButton_Click(scene.mainForm.dungeonButton, null);
                        }
                    }
                }
            }

            for (int i = 0; i < scene.ow.allholes.Length; i++)
            {
                EntranceOWEditor en = scene.ow.allholes[i];
                if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
                {
                    if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
                    {
                        if (scene.mouse_down == false)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                selectedEntrance = en;
                                lastselectedEntrance = en;
                                scene.mouse_down = true;
                            }
                        }
                    }
                }
            }
        }

        public void Delete() 
        {
            lastselectedEntrance.x = 0xFFFF;
            lastselectedEntrance.y = 0xFFFF;
            lastselectedEntrance.mapId = 0;
            lastselectedEntrance.mapPos = 0xFFFF;
            lastselectedEntrance.entranceId = 0;
            lastselectedEntrance.deleted = true;
            scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
        }


        public void onMouseMove(MouseEventArgs e)
        {
            int mouseTileX = e.X / 16;
            int mouseTileY = e.Y / 16;
            int mapX = (mouseTileX / 32);
            int mapY = (mouseTileY / 32);
            scene.mapHover = mapX + (mapY * 8);
            if (selectedEntrance != null)
            {

                if (isLeftPress)
                {
                    if (scene.mouse_down)
                    {
                        selectedEntrance.x = (e.X/16) * 16;
                        selectedEntrance.y = (e.Y/16) * 16;
                    }
                }
                scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
            }
        }


        int mxRightclick = 0;
        int myRightclick = 0;
        public void onMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedEntrance != null)
                {
                    byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
                    if (mid == 255)
                    {
                        mid = (byte)(scene.mapHover + scene.ow.worldOffset);
                    }
                    selectedEntrance.updateMapStuff((short)mid);
                    selectedEntrance = null;
                    scene.mouse_down = false;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                for (int i = 0; i < scene.ow.allentrances.Length; i++)
                {

                    EntranceOWEditor en = scene.ow.allentrances[i];
                    if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
                    {
                        if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
                        {
                            menu.Items.Add("Add Entrance");
                            menu.Items.Add("Entrance Properties");
                            menu.Items.Add("Delete Entrance");
                            lastselectedEntrance = en;
                            selectedEntrance = null;
                            scene.mouse_down = false;
                            if (lastselectedEntrance == null)
                            {
                                menu.Items[1].Enabled = false;
                                menu.Items[2].Enabled = false;
                            }
                            menu.Items[0].Click += entranceAdd_Click;
                            menu.Items[1].Click += entranceProperty_Click;
                            menu.Items[2].Click += Delete_Click;
                            menu.Show(Cursor.Position);
                        }
                    }
                }
            }
        }

        private void entranceAdd_Click(object sender, EventArgs e)
        {
            AddEntrance();
        }

        private void insertEntrance_Click(object sender, EventArgs e)
        {
            bool found = false;
            for(int i = 0; i < scene.ow.allentrances.Length;i++)
            {
                if (scene.ow.allentrances[i].deleted)
                {
                    byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
                    if (mid == 255)
                    {
                        mid = (byte)(scene.mapHover + scene.ow.worldOffset);
                    }
                    scene.ow.allentrances[i].deleted = false;
                    scene.ow.allentrances[i].mapId = mid;
                    scene.ow.allentrances[i].x = (mxRightclick / 16) * 16;
                    scene.ow.allentrances[i].y = (myRightclick / 16) * 16;
                    scene.ow.allentrances[i].updateMapStuff(mid);
                    found = true;
                    scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                    break;
                }
            }
            if (!found)
            {
                MessageBox.Show("No space available for new entrances, delete one first");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void entranceProperty_Click(object sender, EventArgs e)
        {
            EntranceForm ef = new EntranceForm();
            ef.entranceId = lastselectedEntrance.entranceId;
            ef.mapId = lastselectedEntrance.mapId;
            ef.mapPos = lastselectedEntrance.mapPos;
            ef.x = lastselectedEntrance.x;
            ef.y = lastselectedEntrance.y;
            ef.isHole = lastselectedEntrance.isHole;

            if (ef.ShowDialog() == DialogResult.OK)
            {
                lastselectedEntrance.entranceId = ef.entranceId;
                lastselectedEntrance.mapId = ef.mapId;
                lastselectedEntrance.x = ef.x;
                lastselectedEntrance.y = ef.y;

            }
        }


        public void Draw(Graphics g)
        {
            int transparency = 200;
            Brush bgrBrush = new SolidBrush(Color.FromArgb(transparency, 255, 200, 16));
            Pen contourPen = new Pen(Color.FromArgb(transparency, 0, 0, 0));
            g.CompositingMode = CompositingMode.SourceOver;
            for (int i = 0; i < scene.ow.allentrances.Length; i++)
            {
                EntranceOWEditor e = scene.ow.allentrances[i];

                if (e.mapId < 64+ scene.ow.worldOffset && e.mapId >= scene.ow.worldOffset)
                {
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
                    
                    g.FillRectangle(bgrBrush, new Rectangle(e.x, e.y, 16, 16));
                    g.DrawRectangle(contourPen, new Rectangle(e.x, e.y, 16, 16));
                    scene.drawText(g, e.x - 1, e.y + 1, e.entranceId.ToString("X2") + "- " + scene.mainForm.all_rooms[scene.mainForm.entrances[e.entranceId].Room].name);
                }

            }

            for (int i = 0; i < scene.ow.allholes.Length; i++)
            {
                EntranceOWEditor e = scene.ow.allholes[i];
                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 32, 32, 32));
                if (e.mapId < 64+ scene.ow.worldOffset && e.mapId >= scene.ow.worldOffset)
                {
                    if (selectedEntrance != null)
                    {
                        if (e == selectedEntrance)
                        {
                            bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 0, 55, 240));
                        }
                    }

                    g.FillRectangle(bgrBrush, new Rectangle(e.x, e.y, 16, 16));
                    g.DrawRectangle(contourPen, new Rectangle(e.x, e.y, 16, 16));
                    scene.drawText(g, e.x - 1, e.y + 1, e.entranceId.ToString("X2") + "- " + scene.mainForm.all_rooms[scene.mainForm.entrances[e.entranceId].Room].name);
                }

            }
            g.CompositingMode = CompositingMode.SourceCopy;

        }
    }
}
