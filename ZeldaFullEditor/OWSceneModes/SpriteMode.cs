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
    public class SpriteMode
    {
        Sprite selectedSprite;
        public Sprite lastselectedSprite;
        SceneOW scene;
        public SpriteMode(SceneOW scene)
        {

            this.scene = scene;
        }

        bool isLeftPress = false;
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

            for (int i = scene.ow.worldOffset; i < 64+ scene.ow.worldOffset; i++)
            {
                if (i > 159)
                {
                    continue;
                }
                int gs = scene.ow.gameState;
                foreach (Sprite spr in scene.ow.allsprites[gs]) //TODO : Check if that need to be changed to LINQ mapid == maphover
                {
                    if (e.X >= spr.map_x && e.X <= spr.map_x + 16 && e.Y >= spr.map_y && e.Y <= spr.map_y + 16)
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
            Delete();
            //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
        }

        public void Paste()
        {
            int data = (int)Clipboard.GetData("owsprite");
            if (data != -1)
            {
                
                scene.selectedFormSprite = new Sprite(0, (byte)data, 0, 0, 0, 0);
                byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
                if (mid == 255)
                {
                    mid = (byte)(scene.mapHover + scene.ow.worldOffset);
                }
                scene.selectedFormSprite.updateMapStuff((short)(mid));
                int gs = scene.ow.gameState;
                if (mid >= 64)
                {
                    if (gs == 0)
                    {
                        MessageBox.Show("Can't add sprite in rain state in the Dark World!");
                        return;
                    }
                }
                scene.ow.allsprites[gs].Add(scene.selectedFormSprite);
                selectedSprite = scene.ow.allsprites[gs].Last();
                scene.selectedFormSprite = null;
                scene.mouse_down = true;
                isLeftPress = true;
                //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
            }
        }


        public void onMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
                if (mid == 255)
                {
                    mid = (byte)(scene.mapHover + scene.ow.worldOffset);
                }
                if (scene.selectedFormSprite != null)
                {

                    scene.selectedFormSprite.updateMapStuff((short)(mid));
                    int gs = scene.ow.gameState;
                    if (mid >= 64)
                    {
                        if (gs == 0)
                        {
                            MessageBox.Show("Can't add sprite in rain state in the Dark World!");
                            return;
                        }
                    }
                    scene.ow.allsprites[gs].Add(scene.selectedFormSprite);
                    scene.selectedFormSprite = null;
                    //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                }
                if (selectedSprite != null)
                {
                    selectedSprite.updateMapStuff((short)mid);
                    lastselectedSprite = selectedSprite;
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
            //nothing for now
        }
        Gui.AddSprite addspr = new Gui.AddSprite();
        private void addSprite_Click(object sender, EventArgs e)
        {
            if (addspr.ShowDialog() == DialogResult.OK)
            {
                byte data = (byte)addspr.spriteListBox.SelectedIndex;
                scene.selectedFormSprite = new Sprite(0, (byte)data, 0, 0, (scene.mouseX_Real/16), (scene.mouseY_Real / 16));
                byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
                if (mid == 255)
                {
                    mid = (byte)(scene.mapHover + scene.ow.worldOffset);
                }
                scene.selectedFormSprite.updateMapStuff((short)(mid));
                int gs = scene.ow.gameState;
                if (mid >= 64)
                {
                    if (gs == 0)
                    {
                        MessageBox.Show("Can't add sprite in rain state in the Dark World!");
                        return;
                    }
                }
                scene.ow.allsprites[gs].Add(scene.selectedFormSprite);
                selectedSprite = scene.ow.allsprites[gs].Last();
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
                   // scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));

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
                for (int i = scene.ow.worldOffset; i < 64+ scene.ow.worldOffset; i++)
                {
                    int gs = scene.ow.gameState;
                    /*if (i >= 64)
                    {
                        gs = 0;
                    }*/
                    scene.ow.allsprites[gs].Remove(lastselectedSprite);
                }
                lastselectedSprite = null;
                if (scene.lowEndMode)
                {
                    int x = scene.ow.allmaps[scene.selectedMap].parent % 8;
                    int y = scene.ow.allmaps[scene.selectedMap].parent / 8;
                    if (!scene.ow.allmaps[scene.ow.allmaps[scene.selectedMap].parent].largeMap)
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

            if (scene.lowEndMode)
            {



                int transparency = 200;
                Brush bgrBrush = new SolidBrush(Color.FromArgb(transparency, 255, 0, 255));
                Pen contourPen = new Pen(Color.FromArgb(transparency, 0, 0, 0));
                g.CompositingMode = CompositingMode.SourceOver;
                for (int i = 0; i < scene.ow.allsprites[scene.ow.gameState].Count; i++)
                {
                    Sprite spr = scene.ow.allsprites[scene.ow.gameState][i];
                    if (spr.mapid != scene.ow.allmaps[scene.selectedMap].parent)
                    {
                        continue;
                    }
                    if (spr.mapid < 64 + scene.ow.worldOffset && spr.mapid >= scene.ow.worldOffset)
                    {
                        /*if (selectedEntrance != null)
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
                        }*/

                        g.FillRectangle(bgrBrush, new Rectangle(spr.map_x, spr.map_y, 16, 16));
                        g.DrawRectangle(contourPen, new Rectangle(spr.map_x, spr.map_y, 16, 16));
                        scene.drawText(g, spr.map_x + 4, spr.map_y + 4, spr.name);
                    }

                }

                g.CompositingMode = CompositingMode.SourceCopy;
            }
            else
            {
                int transparency = 200;
                Brush bgrBrush = new SolidBrush(Color.FromArgb(transparency, 255, 0, 255));
                Pen contourPen = new Pen(Color.FromArgb(transparency, 0, 0, 0));
                g.CompositingMode = CompositingMode.SourceOver;
                for (int i = 0; i < scene.ow.allsprites[scene.ow.gameState].Count; i++)
                {
                    Sprite spr = scene.ow.allsprites[scene.ow.gameState][i];

                    if (spr.mapid < 64 + scene.ow.worldOffset && spr.mapid >= scene.ow.worldOffset)
                    {
                        /*if (selectedEntrance != null)
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
                        }*/

                        g.FillRectangle(bgrBrush, new Rectangle(spr.map_x, spr.map_y, 16, 16));
                        g.DrawRectangle(contourPen, new Rectangle(spr.map_x, spr.map_y, 16, 16));
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
        }*/
    }
}
