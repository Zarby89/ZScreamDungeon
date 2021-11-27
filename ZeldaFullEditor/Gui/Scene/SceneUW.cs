using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using ZeldaFullEditor.Properties;
using Microsoft.VisualBasic;
using System.IO.Compression;
using static ZeldaFullEditor.DungeonMain;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ZeldaFullEditor
{
    public class SceneUW : Scene
    {
        public Bitmap tempBitmap = new Bitmap(512, 512);
        public short[] doorsObject = new short[] { 0x138, 0x139, 0x13A, 0x13B, 0xF9E, 0xFA9, 0xF9F, 0xFA0, 0x12D, 0x12E, 0x12F, 0x12E, 0x12D, 0x4632, 0x4693 };
        Rectangle lastSelectedRectangle;
        DragMode dragMode = DragMode.none;
        SceneResizing resizeType = SceneResizing.none;
        bool digit2 = false;

        public bool forPreview = false;

        bool resizing = false;
        bool clickedObject = false;

        int rmx = 0;
        int rmy = 0;

        public SceneUW(DungeonMain f)
        {
            //graphics = Graphics.FromImage(scene_bitmap);
            
            this.MouseDown += new MouseEventHandler(onMouseDown);
            this.MouseUp += new MouseEventHandler(onMouseUp);
            this.MouseMove += new MouseEventHandler(onMouseMove);
            this.MouseDoubleClick += new MouseEventHandler(onMouseDoubleClick);
            this.MouseWheel += SceneUW_MouseWheel;
            this.Paint += SceneUW_Paint;
            mainForm = f;
        }
        
        private void SceneUW_MouseWheel(object sender, MouseEventArgs e)
        {
            if (room.selectedObject.Count > 0)
            {
                if (room.selectedObject[0] is Room_Object)
                {
                    if (e.Delta > 0)
                    {
                        if ((room.selectedObject[0] as Room_Object).size < 15)
                        {
                            (room.selectedObject[0] as Room_Object).UpdateSize();
                            (room.selectedObject[0] as Room_Object).size++;
                            updateSelectionObject(room.selectedObject[0]);
                        }
                    }
                    else if (e.Delta < 0)
                    {
                        if ((room.selectedObject[0] as Room_Object).size > 0)
                        {
                            (room.selectedObject[0] as Room_Object).UpdateSize();
                            (room.selectedObject[0] as Room_Object).size--;

                            if ((room.selectedObject[0] as Room_Object).size >= 16)
                            {
                                (room.selectedObject[0] as Room_Object).size = 15;
                            }

                            updateSelectionObject(room.selectedObject[0]);
                        }
                    }
                }
            }

            this.DrawRoom();
            this.Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        private void ResizeObject(Room_Object lastElement, int x, int y)
        {
            lastElement.UpdateSize();
            //if (8 != 0)
            //{

            if ((resizeType & SceneResizing.left) == SceneResizing.left)
            {
                if (x <= (dragx) - lastElement.sizewidth)
                {
                    if (lastElement.size < 15)
                    {
                        if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
                        {
                            byte bsize = lastElement.size;
                            int sizex = ((bsize >> 2) & 0x03);
                            int sizey = ((bsize) & 0x03);
                            sizex += 1;
                            lastElement.size = (byte)((sizex << 2) | sizey);
                        }
                        else
                        {
                            lastElement.size += 1;
                        }

                        lastElement.x -= (byte)(lastElement.sizewidth/8); //object length size
                        lastElement.nx -= (byte)(lastElement.sizewidth / 8); //object length size
                        dragx -= lastElement.sizewidth;
                    }
                }
                else if (x >= (dragx) + lastElement.sizewidth)
                {
                    if (lastElement.size > 0)
                    {
                        if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
                        {
                            byte bsize = lastElement.size;
                            int sizex = ((bsize >> 2) & 0x03);
                            int sizey = ((bsize) & 0x03);
                            sizex -= 1;
                            lastElement.size = (byte)((sizex << 2) | sizey);
                        }
                        else
                        {
                            lastElement.size -= 1;
                        }

                        lastElement.x += (byte)(lastElement.sizewidth / 8); //object length size
                        lastElement.nx += (byte)(lastElement.sizewidth / 8); //object length size
                        dragx += lastElement.sizewidth;
                    }
                }
            }

            if ((resizeType & SceneResizing.right) == SceneResizing.right)
            {
                if (x >= (dragx) + lastElement.sizewidth)
                {
                    if (lastElement.size < 15)
                    {
                        if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
                        {
                            byte bsize = lastElement.size;
                            int sizex = ((bsize >> 2) & 0x03);
                            int sizey = ((bsize) & 0x03);
                            sizex += 1;
                            lastElement.size = (byte)((sizex << 2) | sizey);
                        }
                        else
                        {
                            lastElement.size += 1;
                        }

                        //lastElement.x = 16; //object length size
                        dragx += lastElement.sizewidth;
                    }
                }
                else if (x <= (dragx) - lastElement.sizewidth)
                {
                    if (lastElement.size > 0)
                    {
                        if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
                        {
                            byte bsize = lastElement.size;
                            int sizex = ((bsize >> 2) & 0x03);
                            int sizey = ((bsize) & 0x03);
                            sizex -= 1;
                            lastElement.size = (byte)((sizex << 2) | sizey);
                        }
                        else
                        {
                            lastElement.size -= 1;
                        }

                        //lastElement.x += 16; //object length size
                        dragx -= lastElement.sizewidth;
                    }
                }
            }

            //}
            //if (8 != 0)
            //{
            if ((resizeType & SceneResizing.down) == SceneResizing.down)
            {
                if (y >= (dragy) + lastElement.sizeheight)
                {
                    if (lastElement.size < 15)
                    {
                        if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
                        {
                            byte bsize = lastElement.size;
                            int sizex = ((bsize >> 2) & 0x03);
                            int sizey = ((bsize) & 0x03);
                            sizey += 1;
                            lastElement.size = (byte)((sizex << 2) | sizey);
                        }
                        else
                        {
                            //Console.WriteLine(lastElement.sizeheight + "  Base Heigth : " + lastElement.baseheight);
                            lastElement.size += 1;
                        }

                        //lastElement.x = 16; //object length size
                        dragy += lastElement.sizeheight;
                    }
                }
                else if (y <= (dragy) - lastElement.sizeheight)
                {
                    if (lastElement.size > 0)
                    {
                        if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
                        {
                            byte bsize = lastElement.size;
                            int sizex = ((bsize >> 2) & 0x03);
                            int sizey = ((bsize) & 0x03);
                            sizey -= 1;
                            lastElement.size = (byte)((sizex << 2) | sizey);
                        }
                        else
                        {
                            lastElement.size -= 1;
                        }

                        //lastElement.x += 16; //object length size
                        dragy -= lastElement.sizeheight;
                    }
                }
            }

            if ((resizeType & SceneResizing.up) == SceneResizing.up)
            {
                if (y <= (dragy) - lastElement.sizeheight)
                {
                    if (lastElement.size < 15)
                    {
                        if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
                        {
                            byte bsize = lastElement.size;
                            int sizex = ((bsize >> 2) & 0x03);
                            int sizey = ((bsize) & 0x03);
                            sizey += 1;
                            lastElement.size = (byte)((sizex << 2) | sizey);
                        }
                        else
                        {
                            lastElement.size += 1;
                        }

                        lastElement.y -= (byte)(lastElement.sizeheight / 8); //object length size
                        lastElement.ny -= (byte)(lastElement.sizeheight / 8); //object length size
                        dragy -= lastElement.sizeheight;
                    }
                }
                else if (y >= (dragy) + lastElement.sizeheight)
                {
                    if (lastElement.size > 0)
                    {
                        if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
                        {
                            byte bsize = lastElement.size;
                            int sizex = ((bsize >> 2) & 0x03);
                            int sizey = ((bsize) & 0x03);
                            sizey -= 1;
                            lastElement.size = (byte)((sizex << 2) | sizey);
                        }
                        else
                        {
                            lastElement.size -= 1;
                        }

                        lastElement.y += (byte)(lastElement.sizeheight / 8); //object length size
                        lastElement.ny += (byte)(lastElement.sizeheight / 8); //object length size
                        dragy += lastElement.sizeheight;
                    }
                }
            }

            //}
        }

        //TODO FIND PROBLEM THAT IS INCREASING SAVE TIME!!
        private void onMouseMove(object sender, MouseEventArgs e)
        {
            int MX = e.X;
            int MY = e.Y;
            if (mainForm.x2zoom)
            {
                MX = e.X / 2;
                MY = e.Y / 2;
            }

            Cursor = Cursors.Default;
            if (room == null)
            {
                return;
            }

            if (room.selectedObject.Count == 1)
            {
                if (room.selectedObject[0] is Room_Object)
                {
                    Room_Object lastElement = room.selectedObject[0] as Room_Object;

                    if (resizeType != SceneResizing.none)
                    {
                        if (resizing) //just to be sure
                        {
                            ResizeObject(lastElement, MX, MY);
                            updateSelectionObject(lastElement); //that is just updating the texts/options on form
                            DrawRoom();
                            Refresh();
                            return;
                        }
                    }

                    resizeType = SceneResizing.none;

                    if ((lastElement.sort & Sorting.Horizontal) == (Sorting.Horizontal))
                    {
                        if (e.X >= (lastElement.x * 8) - 2 &&
                            e.X <= ((lastElement.x * 8) + 2) &&
                            e.Y >= (lastElement.y * 8) - 2 &&
                            e.Y <= (lastElement.y * 8) + lastElement.height + 2)
                        {
                            resizeType |= SceneResizing.left;
                        }

                        if (e.X >= (lastElement.x * 8) + lastElement.width - 2 &&
                            e.X <= (lastElement.x * 8) + lastElement.width + 2 &&
                            e.Y >= (lastElement.y * 8) - 2 &&
                            e.Y <= (lastElement.y * 8) + lastElement.height + 2)
                        {
                            resizeType |= SceneResizing.right;
                        }
                    }

                    if ((lastElement.sort & Sorting.Vertical) == (Sorting.Vertical))
                    {
                        if (e.Y >= (lastElement.y * 8) - 2 &&
                            e.Y <= (lastElement.y * 8) + 2 &&
                            e.X >= (lastElement.x * 8) - 2 &&
                            e.X <= (lastElement.x * 8) + lastElement.width + 2)
                        {
                            resizeType |= SceneResizing.up;
                        }

                        if (e.Y >= ((lastElement.y * 8) + lastElement.height) - 2 &&
                            e.Y <= (lastElement.y * 8) + lastElement.height + 2 &&
                                                    e.X >= (lastElement.x * 8) - 2 &&
                            e.X <= (lastElement.x * 8) + lastElement.width + 2)
                        {
                            resizeType |= SceneResizing.down;
                        }
                    }
                    //debugVariable = (int)resizeType;

                    if (resizeType == (SceneResizing.left | SceneResizing.down))
                    {
                        Cursor = Cursors.SizeNESW;
                    }
                    else if (resizeType == (SceneResizing.up | SceneResizing.right))
                    {
                        Cursor = Cursors.SizeNESW;
                    }
                    else if (resizeType == (SceneResizing.up | SceneResizing.left))
                    {
                        Cursor = Cursors.SizeNWSE;
                    }
                    else if (resizeType == (SceneResizing.down | SceneResizing.right))
                    {
                        Cursor = Cursors.SizeNWSE;
                    }
                    else if (resizeType == SceneResizing.left || resizeType == SceneResizing.right)
                    {
                        Cursor = Cursors.SizeWE;
                    }
                    else if (resizeType == SceneResizing.up || resizeType == SceneResizing.down)
                    {
                        Cursor = Cursors.SizeNS;
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                    }

                    if (resizeType != SceneResizing.none)
                    {
                        return;
                    }
                }
            }

            if (selectedMode == ObjectMode.EntrancePlacing)
            {
                if (mainForm.selectedEntrance != null)
                {
                    int ey = (room.index / 16);
                    int ex = room.index - (ey*16);
                    if (mainForm.gridEntranceCheckbox.Checked)
                    {
                        MX = (MX / 8) * 8;
                        MY = (MY / 8) * 8;
                    }

                    mainForm.selectedEntrance.XPosition = (short)(MX + (ex*512));
                    mainForm.selectedEntrance.YPosition = (short)(MY + (ey*512));
                    mainForm.selectedEntrance.XCamera = (short)(MX);
                    mainForm.selectedEntrance.YCamera = (short)(MY);
                    mainForm.selectedEntrance.Room = (short)room.index;
                    if (mainForm.selectedEntrance.XCamera > 383)
                    {
                        mainForm.selectedEntrance.XCamera = 383;

                    }
                    if (mainForm.selectedEntrance.YCamera > 392)
                    {
                        mainForm.selectedEntrance.YCamera = 392;
                    }
                    if (mainForm.selectedEntrance.XCamera < 128)
                    {
                        mainForm.selectedEntrance.XCamera = 128;

                    }
                    if (mainForm.selectedEntrance.YCamera < 112)
                    {
                        mainForm.selectedEntrance.YCamera = 112;
                    }

                    mainForm.selectedEntrance.YScroll = (short)(mainForm.selectedEntrance.XCamera + (ex * 512));
                    mainForm.selectedEntrance.XScroll = (short)(mainForm.selectedEntrance.YCamera + (ey * 512));

                    mainForm.selectedEntrance.scrolledge_HL = (byte)(ex * 2);
                    mainForm.selectedEntrance.scrolledge_FL = (byte)(ex * 2);
                    mainForm.selectedEntrance.scrolledge_HR = (byte)(ex * 2);
                    mainForm.selectedEntrance.scrolledge_FR = (byte)((ex * 2) + 1);

                    mainForm.selectedEntrance.scrolledge_HU = (byte)((ey * 2) + 1);
                    mainForm.selectedEntrance.scrolledge_FU = (byte)(ey * 2);
                    mainForm.selectedEntrance.scrolledge_HD = (byte)((ey * 2) + 1);
                    mainForm.selectedEntrance.scrolledge_FD = (byte)((ey * 2) + 1);

                    if (MX < 256 && MY < 256) //top left quadrant
                    {
                        mainForm.selectedEntrance.Scrollquadrant = 0x00;

                        mainForm.selectedEntrance.scrolledge_HU = (byte)((ey * 2) + 1);
                        mainForm.selectedEntrance.scrolledge_FU = (byte)(ey * 2);
                        mainForm.selectedEntrance.scrolledge_HD = (byte)((ey * 2) + 1);
                        mainForm.selectedEntrance.scrolledge_FD = (byte)((ey * 2) + 1);

                        mainForm.selectedEntrance.scrolledge_HL = (byte)(ex * 2);
                        mainForm.selectedEntrance.scrolledge_FL = (byte)(ex * 2);
                        mainForm.selectedEntrance.scrolledge_HR = (byte)(ex * 2);
                        mainForm.selectedEntrance.scrolledge_FR = (byte)((ex * 2) + 1);
                    }

                    if (MX > 256 && MY < 256) //top right quadrant
                    {
                        mainForm.selectedEntrance.Scrollquadrant = 0x10;
                        mainForm.selectedEntrance.scrolledge_HU = (byte)((ey * 2)+1);
                        mainForm.selectedEntrance.scrolledge_FU = (byte)(ey * 2);
                        mainForm.selectedEntrance.scrolledge_HD = (byte)((ey * 2)+1);
                        mainForm.selectedEntrance.scrolledge_FD = (byte)((ey * 2)+1);

                        mainForm.selectedEntrance.scrolledge_HL = (byte)((ex * 2) + 1);
                        mainForm.selectedEntrance.scrolledge_FL = (byte)((ex * 2) + 1);
                        mainForm.selectedEntrance.scrolledge_HR = (byte)((ex * 2) + 1);
                        mainForm.selectedEntrance.scrolledge_FR = (byte)((ex * 2) + 2);
                    }

                    if (MX < 256 && MY > 256) //bottom left quadrant
                    {
                        mainForm.selectedEntrance.Scrollquadrant = 0x02;
                        mainForm.selectedEntrance.scrolledge_HL = (byte)(ex * 2);
                        mainForm.selectedEntrance.scrolledge_FL = (byte)(ex * 2);
                        mainForm.selectedEntrance.scrolledge_HR = (byte)(ex * 2);
                        mainForm.selectedEntrance.scrolledge_FR = (byte)((ex * 2) + 1);
                    }

                    if (MX > 256 && MY > 256) //bottom right quadrant
                    {
                        mainForm.selectedEntrance.Scrollquadrant = 0x12;
                        mainForm.selectedEntrance.scrolledge_HL = (byte)((ex * 2) + 1);
                        mainForm.selectedEntrance.scrolledge_FL = (byte)((ex * 2) + 1);
                        mainForm.selectedEntrance.scrolledge_HR = (byte)((ex * 2) + 1);
                        mainForm.selectedEntrance.scrolledge_FR = (byte)((ex * 2) + 2);
                        mainForm.selectedEntrance.YScroll = (short)((ex * 512) + 256);
                        mainForm.selectedEntrance.XScroll = (short)((ey * 512) + 256);
                    }

                    mainForm.selectedEntrance.YScroll = (short)(mainForm.selectedEntrance.XPosition);
                    mainForm.selectedEntrance.XScroll = (short)(mainForm.selectedEntrance.YPosition);

                    int scrollXRange = mainForm.selectedEntrance.XScroll % 512;
                    if (scrollXRange >= 350)
                    {
                        mainForm.selectedEntrance.XScroll = (short)((ey * 512) + 256+16);
                    }
                    else if (scrollXRange <= 150)
                    {
                        mainForm.selectedEntrance.XScroll = (short)((ey * 512));
                    }
                    else
                    {
                        mainForm.selectedEntrance.XScroll = (short)(mainForm.selectedEntrance.YPosition - 112);
                    }

                    int scrollYRange = mainForm.selectedEntrance.YScroll % 512;
                    if (scrollYRange >= 350)
                    {
                        mainForm.selectedEntrance.YScroll = (short)((ex * 512) + 256);
                    }
                    else if (scrollYRange <= 150)
                    {
                        mainForm.selectedEntrance.YScroll = (short)((ex * 512));
                    }
                    else
                    {
                        mainForm.selectedEntrance.YScroll = (short)(mainForm.selectedEntrance.XPosition - 128);
                    }

                    //mainForm.selectedEntrance.YPosition = (short)(e.Y + (ey * 512));
                    //mainForm.selectedEntrance.YPosition = (short)(e.Y + (ey * 512));

                    DrawRoom();
                    Refresh();
                    return;
                }
            }

            bool colliding_chest = false;
            if (selectedMode == ObjectMode.Chestmode)
            {
                foreach (Chest c in room.chest_list)
                {
                    if (MX >= (c.x * 8) && MY >= (c.y * 8) - 16 && MX <= (c.x * 8) + 16 && MY <= (c.y * 8) + 16)
                    {
                        mainForm.toolTip1.Show(ChestItems_Name.name[c.item] + " " + c.item.ToString("X2"), this, new Point(e.X, e.Y + 16));
                        colliding_chest = true;
                    }
                }
            }

            if (colliding_chest == false)
            {
                mainForm.toolTip1.Hide(this);
            }

            if (mouse_down) //Slowdown problem in save caused by something here
            {
                //updating_info = true;

                setMouseSizeMode(e); //define the size of mx,my for each mode
                if (selectedMode != ObjectMode.Doormode)
                {
                    if (mx != last_mx || my != last_my)
                    {
                        need_refresh = true;
                    }

                    if (room.selectedObject.Count > 0)
                    {
                        if (mx != last_mx || my != last_my)
                        {
                            move_objects();
                            room.has_changed = true;
                            last_mx = mx;
                            last_my = my;
                            updateSelectionObject(room.selectedObject[0]);
                        }
                    }
                }
                else //if it a door
                {
                    if (room.selectedObject.Count > 0)
                    {
                        if (room.selectedObject[0] is object_door)
                        {
                            if (doorArray != null)
                            {
                                for (int i = 0; i < 48; i++)
                                {
                                    Rectangle r = doorArray[i];
                                    if (lastSelectedRectangle != r)
                                    {
                                        if (new Rectangle(MX, MY, 1, 1).IntersectsWith(r))
                                        {
                                            lastSelectedRectangle = r;
                                            int doordir = (i / 12);
                                            if ((room.selectedObject[0] as object_door).door_pos != (byte)((i * 2) - (doordir * 12)) || (room.selectedObject[0] as object_door).door_dir != (byte)(doordir))
                                            {
                                                (room.selectedObject[0] as object_door).door_pos = (((byte)((i - (doordir * 12)) * 2)));
                                                (room.selectedObject[0] as object_door).door_dir = ((byte)(doordir));
                                                (room.selectedObject[0] as object_door).updateId();
                                                (room.selectedObject[0] as object_door).Draw();
                                                room.has_changed = true;
                                            }

                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                DrawRoom();
                Refresh();
            }
        }

        public void move_objects()
        {
            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    (o as Sprite).nx = (byte)((o as Sprite).x + move_x);
                    (o as Sprite).ny = (byte)((o as Sprite).y + move_y);
                    if ((o as Sprite).nx > 80)
                    {
                        (o as Sprite).nx = 0;
                    }
                    if ((o as Sprite).ny > 80)
                    {
                        (o as Sprite).ny = 0;
                    }
                }
                else if (o is PotItem)
                {
                    (o as PotItem).nx = (byte)((o as PotItem).x + move_x);
                    (o as PotItem).ny = (byte)((o as PotItem).y + move_y);
                    if ((o as PotItem).nx > 80)
                    {
                        (o as PotItem).nx = 0;
                    }
                    if ((o as PotItem).ny > 80)
                    {
                        (o as PotItem).ny = 0;
                    }
                }
                else if (o is Room_Object)
                {
                    (o as Room_Object).nx = (byte)((o as Room_Object).x + move_x);
                    (o as Room_Object).ny = (byte)((o as Room_Object).y + move_y);
                    if ((o as Room_Object).nx > 80)
                    {
                        (o as Room_Object).nx = 0;
                    }
                    if ((o as Room_Object).ny > 80)
                    {
                        (o as Room_Object).ny = 0;
                    }
                }
            }
        }

        private unsafe void SceneUW_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (room == null)
            {
                g.Clear(this.BackColor);

                return;
            }

            if (mainForm.x2zoom)
            {
                g = Graphics.FromImage(tempBitmap);
            }

            if (forPreview)
            {
                g = Graphics.FromImage(tempBitmap);
            }

            g.SetClip(new Rectangle(0, 0, 512, 512));
            g.Clear(Color.Black);
            if (room.bg2 != Background2.Translucent || room.bg2 != Background2.Transparent || room.bg2 != Background2.OnTop || room.bg2 != Background2.Off)
            {
                g.DrawImage(GFX.roomBg2Bitmap, 0, 0);
            }

            //e.Graphics.DrawImage(GFX.roomBgLayoutBitmap,0,0);
            g.DrawImage(GFX.roomBg1Bitmap, 0, 0);

            if (room.bg2 == Background2.Translucent || room.bg2 == Background2.Transparent)
            {
                float[][] matrixItems ={
                    new float[] {1f, 0, 0, 0, 0},
                    new float[] {0, 1f, 0, 0, 0},
                    new float[] {0, 0, 1f, 0, 0},
                    new float[] {0, 0, 0, 0.5f, 0},
                    new float[] {0, 0, 0, 0, 1} 
                };

                ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

                // Create an ImageAttributes object and set its color matrix.
                ImageAttributes imageAtt = new ImageAttributes();
                imageAtt.SetColorMatrix(
                   colorMatrix,
                   ColorMatrixFlag.Default,
                   ColorAdjustType.Bitmap);

                //GFX.roomBg2Bitmap.MakeTransparent(Color.Black);
                g.DrawImage(GFX.roomBg2Bitmap, new Rectangle(0, 0, 512, 512), 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
            }
            else if (room.bg2 == Background2.OnTop)
            {
                g.DrawImage(GFX.roomBg2Bitmap, 0, 0);
            }

            //e.Graphics.DrawImage(GFX.currentgfx16Bitmap, 0, -256);
            drawSelection(g);

            drawGrid(g);
            int superY = (room.index / 16);
            int superX = room.index - (superY * 16);

            int roomX = superX * 512;
            int roomY = superY * 512;
            
            if (mainForm.entranceCameraToolStripMenuItem.Checked)
            {
                if (mainForm.selectedEntrance != null)
                {
                    int localCameraX = mainForm.selectedEntrance.XCamera - 128;
                    int localCameraY = mainForm.selectedEntrance.YCamera - 116;

                    g.DrawRectangle(Pens.Orange, new Rectangle(localCameraX, localCameraY, 256, 224));
                    //Console.WriteLine(localCameraX + "," + localCameraY);
                }
            }

            if (mainForm.entrancePositionToolStripMenuItem.Checked)
            {
                if (mainForm.selectedEntrance != null)
                {
                    int xpos = mainForm.selectedEntrance.XPosition - roomX;
                    int ypos = mainForm.selectedEntrance.YPosition - roomY;
                    g.DrawLine(Pens.White, xpos - 4, ypos, xpos + 4, ypos);
                    g.DrawLine(Pens.White, xpos, ypos - 4, xpos, ypos + 4);
                }
            }

            //e.Graphics.DrawImage(GFX.roomObjectsBitmap,0,0);
            //e.Graphics.DrawImage(GFX., 0, -512);
            //drawText(e.Graphics,4,4, "This is a test? []()abc 1234567890-+");
            int stairCount = 0;
            int chestCount = 0;
            int doorCount = 0;
            foreach (Room_Object o in room.tilesObjects)
            {
                if (mainForm.showChestIDs)
                {
                    if (o.id == 0xF99 || o.id == 0xFB1)
                    {
                        drawText(g, (o.nx * 8) + 6, (o.ny * 8) + 8, chestCount.ToString());
                        chestCount++;
                    }
                }

                if (mainForm.invisibleObjectsTextToolStripMenuItem.Checked)
                {
                    if (o.id == 0xFF3)
                    {
                        drawText(e.Graphics, o.x * 8, o.y * 8, "BG2\nFull\nMask");
                    }
                    else if (o.id == 0xFAA)
                    {
                        drawText(e.Graphics, o.x * 8, o.y * 8, "Lamp");
                    }
                    else if (o.id == 0xAD)
                    {
                        drawText(e.Graphics, o.x * 8, o.y * 8, "AD ?");
                    }
                    else if (o.id == 0xAE)
                    {
                        drawText(e.Graphics, o.x * 8, o.y * 8, "AE ?");
                    }
                    else if (o.id == 0xAF)
                    {
                        drawText(e.Graphics, o.x * 8, o.y * 8, "AF ?");
                    }
                }

                if (o.options == ObjectOption.Door)
                {
                    if (mainForm.showDoorsIDs)
                    {
                        drawText(g, (o.x * 8) + 12, (o.y * 8), doorCount.ToString());
                    }

                    doorCount++;
                    if ((o.id >> 8) == 18) //exit door
                    {
                        drawText(g, (o.x * 8) + 6, (o.y * 8) + 8, "Exit");
                    }
                    else if ((o.id >> 8) == 0x16) //exit door
                    {
                        drawText(g, (o.x * 8) + 6, (o.y * 8) + 8, "to");
                        drawText(g, (o.x * 8) + 4, (o.y * 8) + 16, "bg2");
                    }
                }

                if (o.options == ObjectOption.Block)
                {
                    g.DrawImage(GFX.moveableBlock, o.nx * 8, o.ny * 8);
                }

                if (doorsObject.Contains(o.id))
                {
                    drawText(g, o.nx * 8, o.ny * 8, "to : " + room.staircase_rooms[stairCount].ToString());
                    stairCount++;
                }
            }

            if (mainForm.showSpriteText)
            {
                foreach (Sprite spr in room.sprites)
                {
                    drawText(g, spr.nx * 16, spr.ny * 16, spr.name);
                }
            }

            if (mainForm.showChestText)
            {
                foreach (Chest c in room.chest_list)
                {
                    drawText(g, c.x * 8, c.y * 8, ChestItems_Name.name[c.item]);
                }
            }

            if (mainForm.showItemsText)
            {
                foreach (PotItem c in room.pot_items)
                {
                    int dropboxid = c.id;
                    if ((c.id & 0x80) == 0x80) //it is a special object
                    {
                        dropboxid = ((c.id - 0x80) / 2) + 0x17; //no idea if it will work
                    }

                    //if for some reason the dropboxid >= 28
                    if (dropboxid >= 28)
                    {
                        dropboxid = 27; //prevent crash :yay:
                    }

                    string name = ItemsNames.name[dropboxid];
                    drawText(g, c.nx * 8, c.ny * 8, name);
                }
            }

            drawDoorsPosition(g);
            if (mainForm.x2zoom)
            {
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(tempBitmap, new Rectangle(0, 0, 1024, 1024));
            }

            if (selectedMode == ObjectMode.CollisionMap)
            {
                for (int i = 0; i < 4096; i++)
                {
                    if (room.collisionMap[i] != 0xFF)
                    {
                        drawText(e.Graphics, ((i % 64) * 16)+4, (((i / 64) * 16))+4, room.collisionMap[i].ToString("X2"));
                    }
                }
            }
        }

        public void drawDoorsPosition(Graphics g)
        {
            if (mouse_down)
            {
                if (room.selectedObject.Count > 0)
                {
                    if (room.selectedObject[0] is Room_Object)
                    {
                        if (((room.selectedObject[0] as Room_Object).options & ObjectOption.Door) == ObjectOption.Door)
                        {
                            //for (int i = 0; i < 12; i++)
                            //{
                            g.DrawRectangles(new Pen(new SolidBrush(Color.FromArgb(100, 0, 200, 0))), doorArray);
                               // drawText(g,doorArray)
                            //}
                        }
                    }
                }
            }
        }

        public override void Clear()
        {
            //TODO: Add something here?
            //graphics.Clear(this.BackColor);
        }

        private void onMouseDown(object sender, MouseEventArgs e)
        {
            if (room == null)
            {
                return;
            }

            int MX = e.X;
            int MY = e.Y;
            if (mainForm.x2zoom)
            {
                MX = e.X / 2;
                MY = e.Y / 2;
            }

            //this.Focus();
            mainForm.activeScene = this;

            room.has_changed = true;
            mainForm.checkAnyChanges();

            if (selectedMode == ObjectMode.EntrancePlacing)
            {
                mainForm.entrancetreeView_AfterSelect(null, null);
                selectedMode = ObjectMode.Bgallmode;
                return;
            }

            if ((byte)selectedMode >= 0 && (byte)selectedMode <= 3)
            {
                if (room.selectedObject.Count == 1)
                {
                    if (resizeType != SceneResizing.none)
                    {
                        Room_Object obj = (room.selectedObject[0] as Room_Object);
                        mouse_down = true;
                        resizing = true;
                        dragx = ((MX));
                        dragy = ((MY));
                        return;
                    }
                }
            }

            if (mainForm.tabControl1.SelectedIndex == 1)//if we are on object tab
            {
                if ((byte)selectedMode <= 2) //if selected mode == bg1,bg2,bg3
                {
                    if (selectedDragObject != null) //if there's an object selected
                    {
                        room.selectedObject.Clear(); //clear the object buffer
                        //add the new object in the buffer
                        Room_Object ro = room.addObject(selectedDragObject.id, (byte)0, (byte)0, 0, (byte)selectedMode);
                        
                        if (ro != null)
                        {
                            ro.setRoom(room);
                            ro.getObjectSize();
                            room.tilesObjects.Add(ro);
                            room.selectedObject.Add(ro);
                            dragx = 0;
                            dragy = 0;
                        }

                        room.has_changed = true;
                        mouse_down = true;
                        selectedDragObject = null;
                        mainForm.objectViewer1.selectedObject = null;
                        mainForm.objectViewer1.Refresh();
                    }
                }
                else // if we are on a different tab than objects
                {
                    if (selectedDragObject != null) //if there's an object selected
                    {
                        selectedDragObject = null; //set the object null
                        mainForm.objectViewer1.selectedIndex = -1;
                        mainForm.objectViewer1.selectedObject = null;
                        mainForm.objectViewer1.Refresh();
                        mouse_down = false;
                        MessageBox.Show("You must be selected on bg 1-3 to place new objects");
                        return;
                    }
                }
            }
            else if (mainForm.tabControl1.SelectedIndex == 2)
            {
                if (selectedDragSprite != null)
                {
                    room.selectedObject.Clear();

                    Sprite spr = new Sprite(room, (byte)selectedDragSprite.id, 0, 0, selectedDragSprite.option, 0);

                    if (spr != null)
                    {
                        mainForm.update_modes_buttons(mainForm.spritemodeButton, new EventArgs());
                        room.selectedObject.Add(spr);
                        dragx = 0;
                        dragy = 0;
                        room.sprites.Add(spr);
                    }

                    room.has_changed = true;
                    mouse_down = true;
                    selectedDragObject = null;
                    selectedDragSprite = null;

                    mainForm.spritesView1.selectedObject = null;
                    mainForm.spritesView1.Refresh();
                }
            }

            if (mouse_down == false)
            {
                doorArray = new Rectangle[48];
                found = false;

                if (selectedMode == ObjectMode.Spritemode)
                {
                    dragx = ((MX) / 16);
                    dragy = ((MY) / 16);

                    if (room.selectedObject.Count == 1)
                    {
                        room.selectedObject.Clear();
                    }

                    foreach (Sprite spr in room.sprites)
                    {
                        if (isMouseCollidingWith(spr, e))
                        {
                            if (spr.selected == false)
                            {
                                room.selectedObject.Add(spr);
                                found = true;
                                break;
                            }
                        }
                    }

                    if (found == false) //we didnt find any sprites to click on so just clear the selection
                    {
                        room.selectedObject.Clear();
                    }
                }
                else if (selectedMode == ObjectMode.Itemmode)
                {
                    dragx = ((MX) / 8);
                    dragy = ((MY) / 8);

                    if (room.selectedObject.Count == 1)
                    {
                        foreach (Object o in room.pot_items)
                        {
                            //(o as PotItem).selected = false;
                        }

                        room.selectedObject.Clear();
                    }

                    foreach (PotItem item in room.pot_items)
                    {
                        if (isMouseCollidingWith(item, e))
                        {
                            if (item.selected == false)
                            {
                                room.selectedObject.Add(item);
                                found = true;
                                break;
                            }
                        }
                    }

                    if (found == false) //we didnt find any items to click on so just clear the selection
                    {
                        room.selectedObject.Clear();
                    }
                }
                else if ((byte)selectedMode >= 0 && (byte)selectedMode <= 3)
                {
                    dragx = ((MX) / 8);
                    dragy = ((MY) / 8);
                    bool already_in = false;
                    Room_Object objectFound = null;
                    found = false;

                    for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
                    {
                        Room_Object obj = room.tilesObjects[i];
                        if (selectedMode != ObjectMode.Bgallmode)
                        {
                            if ((byte)selectedMode != obj.layer)
                            {
                                continue;
                            }
                        }

                        if (isMouseCollidingWith(obj, e))
                        {
                            if (room.selectedObject.Count != 0)
                            {
                                if (room.selectedObject.Contains(obj))
                                {
                                    found = true;
                                    break;
                                }
                                if (ModifierKeys != Keys.Shift && ModifierKeys != Keys.Control)
                                {
                                    room.selectedObject.Clear();
                                }
                            }

                            int msx = MX;
                            int msy = MY;

                            if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Door) != ObjectOption.Door && (obj.options & ObjectOption.Torch) != ObjectOption.Torch && (obj.options & ObjectOption.Block) != ObjectOption.Block)
                            {
                                for (int p = 0; p < obj.collisionPoint.Count; p++)
                                {
                                    //Console.WriteLine(obj.collisionPoint[p].X);
                                    if (MX >= obj.collisionPoint[p].X && MX <= obj.collisionPoint[p].X + 8
                                        && MY >= obj.collisionPoint[p].Y && MY <= obj.collisionPoint[p].Y + 8)
                                    {
                                        room.selectedObject.Add(obj);
                                        found = true;
                                        break;
                                    }
                                }

                                if (found)
                                {
                                    break;
                                }
                            }
                        }
                    }

                    if (found == false) //we didnt find any Tiles to click on so just clear the selection
                    {
                        if (ModifierKeys != Keys.Shift && ModifierKeys != Keys.Control)
                        {
                            //Console.WriteLine("we didnt find any object so clear all");
                            room.selectedObject.Clear();
                        }
                    }
                }
                else if (selectedMode == ObjectMode.Doormode)
                {
                   // Console.Write("Door mode");
                    room.selectedObject.Clear();
                    dragx = ((MX) / 8);
                    dragy = ((MY) / 8);

                    for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
                    {
                        Room_Object obj = room.tilesObjects[i];
                        if (isMouseCollidingWith(obj, e))
                        {
                            if ((obj.options & ObjectOption.Door) == ObjectOption.Door)
                            {
                                //we found a door
                                room.selectedObject.Add(obj);
                                obj.selected = true;
                                doorArray = room.getAllDoorPosition(obj);
                                need_refresh = true;
                                break;
                            }
                        }
                    }
                }
                else if (selectedMode == ObjectMode.Blockmode)
                {
                    room.selectedObject.Clear();
                    dragx = ((MX) / 8);
                    dragy = ((MY) / 8);

                    for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
                    {
                        Room_Object obj = room.tilesObjects[i];
                        if (isMouseCollidingWith(obj, e))
                        {
                            if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Block) == ObjectOption.Block)
                            {
                                room.selectedObject.Add(obj);
                                need_refresh = true;
                                break;
                            }
                        }
                    }
                }
                else if (selectedMode == ObjectMode.Torchmode)
                {
                    room.selectedObject.Clear();
                    dragx = ((MX) / 8);
                    dragy = ((MY) / 8);

                    for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
                    {
                        Room_Object obj = room.tilesObjects[i];
                        if (isMouseCollidingWith(obj, e))
                        {
                            if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Torch) == ObjectOption.Torch)
                            {
                                //we found a door
                                room.selectedObject.Add(obj);
                                need_refresh = true;
                                DrawRoom();
                                Refresh();
                                break;
                            }
                        }
                    }
                }
                else if (selectedMode == ObjectMode.Warpmode)
                {
                    room.selectedObject.Clear();
                    dragx = ((MX) / 8);
                    dragy = ((MY) / 8);
                    int doorCount = 0;
                    foreach (Room_Object o in room.tilesObjects)
                    {
                        if (doorsObject.Contains(o.id))
                        {
                            if (isMouseCollidingWith(o, e))
                            {
                                string warpid = Interaction.InputBox("New Warp Room", "Room Id", room.staircase_rooms[doorCount].ToString());
                                byte b;
                                if (byte.TryParse(warpid, out b))
                                {
                                    room.staircase_rooms[doorCount] = b;
                                    updateRoomInfos(mainForm);
                                }
                                else
                                {
                                    MessageBox.Show("The value need to be a number between 0-256");
                                }
                            }

                            doorCount++;
                        }
                        else if (o.id == 0xFCA)
                        {
                            if (isMouseCollidingWith(o, e))
                            {
                                string warpid = Interaction.InputBox("New Warp Room", "Room Id", room.holewarp.ToString());
                                byte b;
                                if (byte.TryParse(warpid, out b))
                                {
                                    room.holewarp = b;
                                    updateRoomInfos(mainForm);
                                }
                                else
                                {
                                    MessageBox.Show("The value need to be a number between 0-256");
                                }
                            }
                        }
                    }
                }
                else if (selectedMode == ObjectMode.CollisionMap)
                {
                    //what happens when the mouse is clicked in the Collision map mode
                    if(e.Button == MouseButtons.Left)
                    {
                        int px = e.X / 16;
                        int py = e.Y / 16;

                        room.collisionMap[px + (py * 64)] = (byte)mainForm.tileTypeCombobox.SelectedIndex;
                    }
                }

                mouse_down = true;
                move_x = 0;
                move_y = 0;
                mx = dragx;
                my = dragy;
                last_mx = mx;
                last_my = my;
            }

            mainForm.spritepropertyPanel.Visible = false;
            mainForm.potitemobjectPanel.Visible = false;
            mainForm.doorselectPanel.Visible = false;
            mainForm.litCheckbox.Visible = false;
            updating_info = false;

            if (room.selectedObject.Count > 0)
            {
                if (room.selectedObject[0] is Room_Object)
                {
                    updating_info = true;
                    Room_Object oo = room.selectedObject[0] as Room_Object;

                    if (oo.options == ObjectOption.Door)
                    {
                        string name = oo.name;
                        string id = oo.id.ToString("X4");
                        mainForm.comboBox1.Enabled = false;
                        mainForm.selectedGroupbox.Text = "Selected Object : " + id + " " + name + "";
                        mainForm.doorselectPanel.Visible = true;
                        int[] aposes = mainForm.door_index.Select((s, i) => new { s, i }).Where(x => x.s == (oo as object_door).door_type).Select(x => x.i).ToArray();
                        int apos = 0;

                        if (aposes.Length > 0)
                        {
                            apos = aposes[0];   
                        }

                        mainForm.comboBox2.SelectedIndex = apos;
                        for (int i = 0; i < room.tilesObjects.Count; i++)
                        {
                            if (room.tilesObjects[i] == oo)
                            {
                                //mainForm.selectedZUpDown.Value = i;
                            }
                        }

                        updateSelectionObject(oo);
                    }
                    else if (oo.options == ObjectOption.Torch)
                    {
                        mainForm.selectedGroupbox.Text = "Selected Object : " + oo.id + " " + "Torch";
                        updating_info = true;
                        mainForm.litCheckbox.Visible = true;
                        mainForm.litCheckbox.Checked = oo.lit;
                        updateSelectionObject(oo);
                        updating_info = false;
                    }
                    else
                    {
                        string name = oo.name;
                        string id = oo.id.ToString("X4");
                        mainForm.comboBox1.Enabled = false;

                        mainForm.selectedGroupbox.Text = "Selected Object : " + id + " " + name;

                        for (int i = 0; i < room.tilesObjects.Count; i++)
                        {
                            if (room.tilesObjects[i] == oo)
                            {
                                //mainForm.selectedZUpDown.Value = i;
                            }
                        }

                        updateSelectionObject(oo);
                    }
                }
                else if (room.selectedObject[0] is Sprite)
                {
                    mainForm.spritepropertyPanel.Visible = true;
                    updating_info = true;
                    Sprite oo = room.selectedObject[0] as Sprite;
                    string name = Sprites_Names.name[oo.id];
                    if ((oo.subtype & 0x07) == 0x07)
                    {
                        if (oo.id <= 0x1A && oo.id > 0)
                        {
                            name = Sprites_Names.overlordnames[oo.id - 1];
                        }

                        mainForm.spriteoverlordCheckbox.Checked = true;
                    }
                    else
                    {
                        mainForm.spriteoverlordCheckbox.Checked = false;
                    }

                    string id = oo.id.ToString("X4");
                    mainForm.selectedGroupbox.Text = "Selected Sprite : " + id + " " + name;
                    mainForm.comboBox1.Enabled = true;
                    updateSelectionObject(oo);
                }
                else if (room.selectedObject[0] is PotItem)
                {
                    updating_info = true;//?
                    PotItem oo = room.selectedObject[0] as PotItem;
                    mainForm.potitemobjectPanel.Visible = true; //oO why this is not appearing
                    int dropboxid = oo.id;

                    if ((oo.id & 0x80) == 0x80) //it is a special object
                    {
                        dropboxid = ((oo.id - 0x80) / 2) + 0x17; //no idea if it will work
                    }

                    //if for some reason the dropboxid >= 28
                    if (dropboxid >= 28)
                    {
                        dropboxid = 27; //prevent crash :yay:
                    }

                    string name = ItemsNames.name[dropboxid];
                    string id = oo.id.ToString("X4");
                    mainForm.selectedGroupbox.Text = "Selected Item : " + id + " " + name;
                    mainForm.selecteditemobjectCombobox.SelectedIndex = dropboxid;
                    updateSelectionObject(oo);
                    updating_info = false;
                }
            }

            updating_info = false;
        }

        public unsafe void ClearBgGfx()
        {
            byte* bg1data = (byte*)GFX.roomBg1Ptr.ToPointer();
            byte* bg2data = (byte*)GFX.roomBg2Ptr.ToPointer();

            for (int i = 0; i < 512 * 512; i++)
            {
                bg1data[i] = 0;
                bg2data[i] = 0;
            }
        }

        public unsafe void DrawRoom()
        {
            if (room == null)
            {
                return;
            }
            
            //Tile t = new Tile(0, false, false, 0, 0);
            //t.Draw(0, 0);
            ClearBgGfx(); //technically not required
            if (showLayer1)
            {
                room.DrawFloor1();
            }

            if (room.bg2 != Background2.Off)
            {
                SetPalettesTransparent();
                if (showLayer2)
                {
                    room.DrawFloor2();
                }
            }
            else
            {
                SetPalettesBlack();
            }

            room.reloadLayout();
            
            foreach (Room_Object o in room.tilesLayoutObjects)
            {
                o.collisionPoint.Clear();
                o.Draw();
                
            }

            //draw object on bitmap

            foreach (Room_Object o in room.tilesObjects)
            {
                if (o.layer != 2)
                {
                    o.collisionPoint.Clear();
                    o.Draw();
                }

                if (o.options == ObjectOption.Door)
                {
                    o.collisionPoint.Clear();
                    o.Draw();
                }
            }

            foreach (Room_Object o in room.tilesObjects)
            {
                //Draw doors here since they'll all be put on bg3 anyways
                if (o.layer == 2)
                {
                    o.collisionPoint.Clear();
                    o.Draw();
                }
            }
            
            if (showLayer1)
            {
                GFX.DrawBG1();
            }
            if (showLayer2)
            {
                GFX.DrawBG2();
            }
            if (mainForm.showSprite)
            {
                room.drawSprites();
            }
            if (mainForm.showChest)
            {
                drawChests();
            }
            if (mainForm.showItems)
            {
                room.drawPotsItems();
            }

            mainForm.cgramViewer.Refresh();

        }

        public void drawChests()
        {
            if (room.chest_list.Count > 0)
            {
                int chest_count = 0;
                foreach (Room_Object o in room.tilesObjects)
                {
                    if (((o as Room_Object).options & ObjectOption.Chest) == ObjectOption.Chest)
                    {
                        if (room.chest_list.Count > chest_count)
                        {
                            room.chest_list[chest_count].x = (o as Room_Object).nx;
                            room.chest_list[chest_count].y = (o as Room_Object).ny;
                            if (o.id == 0xFB1)
                            {
                                room.chest_list[chest_count].bigChest = true;
                            }
                        }

                        chest_count++;
                    }
                }

                foreach (Chest c in room.chest_list)
                {
                    if (c.item <= 75)
                    {
                        //g.DrawRectangle(Pens.Blue,(c.x * 8), (c.y - 2) * 8, 16, 16);
                        
                        if (c.bigChest)
                        {
                            c.ItemsDraw(c.item, (c.x+1) * 8, (c.y - 2) * 8);
                        }
                        else
                        {
                            c.ItemsDraw(c.item, c.x * 8, (c.y - 2) * 8);
                        }
                        //graphics.DrawImage(GFX.chestitems_bitmap[c.item], (c.x * 8), (c.y - 2) * 8);
                    }
                }
            }
        }

        public void drawGrid(Graphics graphics)
        {
            if (showGrid)
            {
                int s = mainForm.gridSize;
                int wh = (512 / s)+1;

                for (int x = 0; x < wh; x++)
                {
                    graphics.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), x * s, 0, x * s, 512);
                }
                for (int y = 0; y < wh; y++)
                {
                    graphics.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), 0, y * s, 512, y * s);
                }
            }
        }

        public void SetPalettesTransparent()
        {
            int pindex = 0;
            ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
            for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
                {
                    palettes.Entries[pindex] = GFX.loadedPalettes[x, y];
                    pindex++;
                }
            }

            for (int y = 0; y < GFX.loadedSprPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedSprPalettes.GetLength(0); x++)
                {
                    if (pindex < 256)
                    {
                        palettes.Entries[pindex] = GFX.loadedSprPalettes[x, y];
                        pindex++;
                    }
                }
            }

            for (int i = 0; i < 16; i++)
            {
                palettes.Entries[i * 16] = Color.Transparent;
                palettes.Entries[(i * 16) + 8] = Color.Transparent;
            }

            GFX.roomBg1Bitmap.Palette = palettes;
            GFX.roomBg2Bitmap.Palette = palettes;
            GFX.roomBgLayoutBitmap.Palette = palettes;
        }

        public void SetPalettesBlack()
        {
            int pindex = 0;
            ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
            for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
                {
                    palettes.Entries[pindex] = GFX.loadedPalettes[x, y];
                    pindex++;
                }
            }

            for (int i = 0; i < 16; i++)
            {
                palettes.Entries[i * 16] = Color.Black;
                palettes.Entries[(i * 16) + 8] = Color.Black;
            }

            GFX.roomBg1Bitmap.Palette = palettes;
            GFX.roomBg2Bitmap.Palette = palettes;
            GFX.roomBgLayoutBitmap.Palette = palettes;
        }

        private unsafe void onMouseUp(object sender, MouseEventArgs e)
        {
            resizing = false;
            if (mouse_down == true)
            {
                setMouseSizeMode(e);

                mouse_down = false;
                if (room.selectedObject.Count == 0) //if we don't have any objects select we select what is in the rectangle
                {
                    getObjectsRectangle();
                }
                else
                {
                    setObjectsPosition();
                }

                if (e.Button == MouseButtons.Right) //that's a problem
                {
                    rmx = e.X;
                    rmy = e.Y;
                    mainForm.nothingselectedcontextMenu.Items[0].Enabled = true;
                    mainForm.singleselectedcontextMenu.Items[0].Enabled = true;
                    mainForm.groupselectedcontextMenu.Items[0].Enabled = true;
                    mainForm.nothingselectedcontextMenu.Items[0].Visible = true;
                    mainForm.singleselectedcontextMenu.Items[0].Visible = true;
                    mainForm.groupselectedcontextMenu.Items[0].Visible = true;
                    string nname = "Unknown";

                    if (selectedMode == ObjectMode.Chestmode)
                    {
                        nname = "Chest Item";
                    }
                    else if (selectedMode == ObjectMode.Itemmode)
                    {
                        nname = "Pot Item";
                    }
                    else if (selectedMode == ObjectMode.Blockmode)
                    {
                        nname = "Block";
                    }
                    else if (selectedMode == ObjectMode.Torchmode)
                    {
                        nname = "Torch";
                    }
                    else if (selectedMode == ObjectMode.Doormode)
                    {
                        nname = "Door";
                    }
                    else if (selectedMode == ObjectMode.CollisionMap)
                    {
                        nname = "Collision Map";
                    }

                    if (selectedMode != ObjectMode.Bg1mode && selectedMode != ObjectMode.Bg2mode && selectedMode != ObjectMode.Bg3mode && selectedMode != ObjectMode.Bgallmode)
                    {
                        mainForm.nothingselectedcontextMenu.Items[0].Text = "Insert new " + nname;
                        mainForm.singleselectedcontextMenu.Items[0].Text = "Insert new " + nname;
                        mainForm.groupselectedcontextMenu.Items[0].Text = "Insert new " + nname;
                    }
                    else
                    {
                        mainForm.nothingselectedcontextMenu.Items[0].Visible = false;
                        mainForm.nothingselectedcontextMenu.Items[2].Visible = false;
                        mainForm.singleselectedcontextMenu.Items[0].Visible = false;
                        mainForm.groupselectedcontextMenu.Items[0].Visible = false;
                    }

                    if (selectedMode == ObjectMode.Spritemode)
                    {
                        mainForm.nothingselectedcontextMenu.Items[0].Visible = false;
                        mainForm.nothingselectedcontextMenu.Items[2].Visible = false;
                        mainForm.singleselectedcontextMenu.Items[0].Visible = false;
                        mainForm.groupselectedcontextMenu.Items[0].Visible = false;
                    }

                    if (selectedMode == ObjectMode.Chestmode)
                    {
                        mainForm.nothingselectedcontextMenu.Items[2].Visible = true;
                    }

                    if (selectedMode == ObjectMode.CollisionMap)
                    {
                        mainForm.nothingselectedcontextMenu.Items[0].Visible = false;
                        mainForm.nothingselectedcontextMenu.Items[1].Visible = false;
                        mainForm.nothingselectedcontextMenu.Items[2].Visible = true;
                    }

                    if (room.selectedObject.Count == 0)
                    {
                        mainForm.nothingselectedcontextMenu.Show(Cursor.Position);
                    }
                    else if (room.selectedObject.Count == 1)
                    {
                        mainForm.singleselectedcontextMenu.Show(Cursor.Position);
                    }
                    else if (room.selectedObject.Count > 1)
                    {
                        mainForm.groupselectedcontextMenu.Show(Cursor.Position);
                    }

                    mouse_down = false;
                }
            }

            DrawRoom();
            Refresh();
        }
        
        private void onMouseDoubleClick(object sender, MouseEventArgs e)
        {
            rmx = e.X;
            rmy = e.Y;
            addChest();
        }

        public void addChest()
        {
            int MX = rmx;
            int MY = rmy;

            if (mainForm.x2zoom)
            {
                MX = rmx / 2;
                MY = rmy / 2;
            }

            if (selectedMode == ObjectMode.Chestmode)
            {
                Chest chestToRemove = null;
                bool foundChest = false;

                foreach (Chest c in room.chest_list)
                {
                    if (MX >= (c.x * 8) && MX <= (c.x * 8) + 16 &&
                        MY >= ((c.y - 2) * 8) && MY <= ((c.y) * 8) + 16)
                    {
                        mainForm.chestPicker.button1.Enabled = true;//enable delete button
                        DialogResult result = mainForm.chestPicker.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            //change chest item
                            int r = 0;
                            if (int.TryParse(mainForm.chestPicker.idtextbox.Text, out r))
                            {
                                c.item = (byte)r;
                            }

                            room.has_changed = true;
                        }
                        else if (result == DialogResult.Abort)
                        {
                            chestToRemove = c;
                        }

                        foundChest = true;
                        break;
                    }
                }

                if (foundChest == false)
                {
                    mainForm.chestPicker.button1.Enabled = false;//disable delete button
                    DialogResult result = mainForm.chestPicker.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        room.has_changed = true;
                        //change chest item
                        Chest c = new Chest((byte)(MX / 8), (byte)(MY / 8), (byte)mainForm.chestPicker.chestviewer1.selectedIndex, false, false);
                        room.chest_list.Add(c);
                    }
                }

                if (chestToRemove != null)
                {
                    room.chest_list.Remove(chestToRemove);
                }

                need_refresh = true;
            }
        }

        public void deleteChestItem()
        {
            int MX = rmx;
            int MY = rmy;

            if (mainForm.x2zoom)
            {
                MX = rmx / 2;
                MY = rmy / 2;
            }

            if (selectedMode == ObjectMode.Chestmode)
            {
                Chest chestToRemove = null;
                bool foundChest = false;

                foreach (Chest c in room.chest_list)
                {
                    if (MX >= (c.x * 8) && MX <= (c.x * 8) + 16 &&
                        MY >= ((c.y - 2) * 8) && MY <= ((c.y) * 8) + 16)
                    {
                        //mainForm.chestPicker.button1.Enabled = true;//enable delete button
                        //DialogResult result = mainForm.chestPicker.ShowDialog();

                        chestToRemove = c;

                        foundChest = true;
                        break;
                    }
                }

                if (chestToRemove != null)
                {
                    Console.WriteLine("delete chest item." + chestToRemove.item);

                    room.chest_list.Remove(chestToRemove);
                }

                need_refresh = true;
                DrawRoom();
                Refresh();
            }
        }

        public void clearUselessRoomStuff(Room r)
        {
            //TODO: Add something here?
        }
        
        public void setObjectsPosition()
        {
            if (room.selectedObject.Count > 0)
            {
                if (selectedMode == ObjectMode.Spritemode)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as Sprite).x = (o as Sprite).nx;
                        (o as Sprite).y = (o as Sprite).ny;
                        //(o as Sprite).boundingbox
                    }
                }
                else if (selectedMode == ObjectMode.Itemmode)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as PotItem).x = (o as PotItem).nx;
                        (o as PotItem).y = (o as PotItem).ny;
                    }
                }
                else if ((byte)selectedMode >= 0 && (byte)selectedMode <= 3)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as Room_Object).x = (o as Room_Object).nx;
                        (o as Room_Object).y = (o as Room_Object).ny;
                        (o as Room_Object).ox = (o as Room_Object).x;
                        (o as Room_Object).oy = (o as Room_Object).y;
                    }
                }
                else if (selectedMode == ObjectMode.Torchmode)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as Room_Object).x = (o as Room_Object).nx;
                        (o as Room_Object).y = (o as Room_Object).ny;
                        (o as Room_Object).ox = (o as Room_Object).x;
                        (o as Room_Object).oy = (o as Room_Object).y;
                    }
                }
                else if (selectedMode == ObjectMode.Blockmode)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as Room_Object).x = (o as Room_Object).nx;
                        (o as Room_Object).y = (o as Room_Object).ny;
                        (o as Room_Object).ox = (o as Room_Object).x;
                        (o as Room_Object).oy = (o as Room_Object).y;
                    }
                }
            }

            room.has_changed = true;

            /*if (mainForm.undoRoom[room.index].Count > 10)
            {
                Room a = mainForm.undoRoom[room.index][0];
                mainForm.undoRoom[room.index].RemoveAt(0);
                a = null;


                mainForm.undoRoom[room.index].Add((Room)room.Clone());
                mainForm.redoRoom[room.index].Clear();
                mainForm.undoButton.Enabled = true;
                mainForm.undoToolStripMenuItem.Enabled = true;
                mainForm.redoButton.Enabled = false;
                mainForm.redoToolStripMenuItem.Enabled = false;
            }
            else
            {
                mainForm.undoRoom[room.index].Add((Room)room.Clone());
                mainForm.redoRoom[room.index].Clear();
                mainForm.undoButton.Enabled = true;
                mainForm.undoToolStripMenuItem.Enabled = true;
                mainForm.redoButton.Enabled = false;
                mainForm.redoToolStripMenuItem.Enabled = false;
            }*/
        }

        public void objects_ResizeMouseMove(MouseEventArgs e)
        {
            //TODO: Add something here?
        }

        public void setMouseSizeMode(MouseEventArgs e)
        {
            int MX = e.X;
            int MY = e.Y;
            if (mainForm.x2zoom)
            {
                MX = e.X / 2;
                MY = e.Y / 2;
            }

            if (selectedMode == ObjectMode.Spritemode)
            {
                mx = ((MX) / 16);
                my = ((MY) / 16);
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                mx = ((MX) / 8);
                my = ((MY) / 8);
            }
            else if ((byte)selectedMode >= 0 && (byte)selectedMode <= 3)
            {
                mx = ((MX) / 8);
                my = ((MY) / 8);
            }
            else if (selectedMode == ObjectMode.Torchmode || selectedMode == ObjectMode.Blockmode)
            {
                mx = ((e.X) / 8);
                my = ((e.Y) / 8);
            }

            move_x = mx - dragx; //number of tiles mouse is compared to starting drag point X
            move_y = my - dragy; //number of tiles mouse is compared to starting drag point Y
        }

        public bool isMouseCollidingWith(Object o, MouseEventArgs e)
        {
            int MX = e.X;
            int MY = e.Y;
            if (mainForm.x2zoom)
            {
                MX = e.X / 2;
                MY = e.Y / 2;
            }

            if (o is Sprite)
            {
                if (MX >= (o as Sprite).boundingbox.X && MX <= (o as Sprite).boundingbox.X + (o as Sprite).boundingbox.Width &&
                MY >= (o as Sprite).boundingbox.Y && MY <= (o as Sprite).boundingbox.Y + (o as Sprite).boundingbox.Height)
                {
                    return true;
                }
            }
            else if (o is PotItem)
            {
                if (MX >= ((o as PotItem).x * 8) && MX <= ((o as PotItem).x * 8) + 16 &&
                    MY >= ((o as PotItem).y * 8) && MY <= ((o as PotItem).y * 8) + 16)
                {
                    return true;
                }
            }
            else if (o is Room_Object)
            {
                //if ((o as Room_Object).layer == (byte)selectedMode || selectedMode == ObjectMode.Bgallmode)
                //{

                Room_Object obj = (o as Room_Object);
                int yfix = 0;
                if (obj.diagonalFix)
                {
                    yfix = -(6 + obj.size);
                }

                if (MX >= ((obj.x+obj.offsetX)*8) && MX <= ((obj.x+obj.offsetX)*8) + (obj.width) &&
                        MY >= ((obj.y + obj.offsetY +yfix) *8) && MY <= ((obj.y + obj.offsetY+yfix) *8) + (obj.height))
                {
                    return true;
                }
               //}
            }

            return false;
        }

        public void getObjectsRectangle()
        {
            if (room.selectedObject.Count == 0)
            {
                if (selectedMode == ObjectMode.Spritemode) //we're looking for sprites
                {
                    foreach (Sprite spr in room.sprites)
                    {
                        int rx = dragx;
                        int ry = dragy;
                        if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
                        if (move_y < 0) { Math.Abs(ry = dragy + move_y); }

                        if (spr.boundingbox.IntersectsWith(new Rectangle(rx * 16, ry * 16, Math.Abs(move_x) * 16, Math.Abs(move_y) * 16)))
                        {
                            room.selectedObject.Add(spr);
                        }
                    }
                }
                else if (selectedMode == ObjectMode.Itemmode)//we're looking for pot items
                {
                    foreach (PotItem item in room.pot_items)
                    {
                        int rx = dragx;
                        int ry = dragy;
                        if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
                        if (move_y < 0) { Math.Abs(ry = dragy + move_y); }

                        if ((new Rectangle(item.x * 8, item.y * 8, 16, 16)).IntersectsWith(new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
                        {
                            room.selectedObject.Add(item);
                        }
                    }
                }
                else if ((byte)selectedMode >= 0 && (byte)selectedMode <= 3)//we're looking for tiles
                {
                    foreach (Room_Object o in room.tilesObjects)
                    {
                        int rx = dragx;
                        int ry = dragy;
                        if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
                        if (move_y < 0) { Math.Abs(ry = dragy + move_y); }

                        Room_Object obj = (o as Room_Object);

                        int yfix = 0;
                        if (obj.diagonalFix)
                        {
                            yfix = -(6+obj.size);
                        }

                        if ((new Rectangle((obj.x+obj.offsetX) * 8, (obj.y + obj.offsetY + yfix) * 8, (obj.width + obj.offsetX), (obj.height + obj.offsetY + yfix))).IntersectsWith(new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
                        {
                            if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr && (o.options & ObjectOption.Door) != ObjectOption.Door && (o.options & ObjectOption.Torch) != ObjectOption.Torch && (o.options & ObjectOption.Block) != ObjectOption.Block)
                            {
                                if (selectedMode == ObjectMode.Bgallmode)
                                {
                                    room.selectedObject.Add(o);
                                }
                                else
                                {
                                    if ((byte)selectedMode == o.layer)
                                    {
                                        room.selectedObject.Add(o);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    //TODO: Add condition here?
                }
            }

            /*foreach(Room_Object o in room.selectedObject)
            {
                Console.WriteLine(o.id.ToString("X4") + o.name);
            }*/
        }

        public void updateSelectionObject(object o)
        {
            if (room.selectedObject.Count == 1)
            {
                if (o is Room_Object)
                {
                    if ((o as Room_Object).nx >= 63)
                    {
                        (o as Room_Object).nx = 63;
                    }
                    if ((o as Room_Object).ny >= 63)
                    {
                        (o as Room_Object).ny = 63;
                    }
                    if ((o as Room_Object).size >= 16)
                    {
                        (o as Room_Object).size = 0;
                    }
                    if ((o as Room_Object).layer >= 3)
                    {
                        (o as Room_Object).size = 2;
                    }

                    byte[] databytes = room.getSelectedObjectHex();
                    string sdatabytes = "";
                    if (databytes != null)
                    {
                        sdatabytes = databytes[0].ToString("X2") + " " + databytes[1].ToString("X2") + " " + databytes[2].ToString("X2");
                    }

                    mainForm.object_x_label.Text = "X: " + (o as Room_Object).nx.ToString("X2");
                    mainForm.object_y_label.Text = "Y: " + (o as Room_Object).ny.ToString("X2"); ;
                    mainForm.object_size_label.Text = "Size: " + (o as Room_Object).size + "   HEX : " + sdatabytes;
                    mainForm.object_layer_label.Text = "Layer (BG): " + ((o as Room_Object).layer+1).ToString();
                    int z = 0;

                    foreach (Room_Object door in room.tilesObjects)
                    {
                        if (door.options == ObjectOption.Door)
                        {
                            if (door == o)
                            {
                                //mainForm.object_z_label.Text = "Z: " + z.ToString(); //where's my door 0 :scream:
                                break;
                            }
                            z++;
                        }
                    }

                    /*
                    if ((o.options & ObjectOption.Door) == ObjectOption.Door)
                    {
                        byte door_pos = (byte)((o.id & 0xF0) >> 3);
                        byte door_dir = (byte)((o.id & 0x03));
                        byte door_type = (byte)((o.id >> 8) & 0xFF);
                        id = o.id.ToString("X4") + "\nDoor Type : " + door_type.ToString("X2");
                        id += "\nDoor Direction : " + door_dir.ToString("X2");
                        id += "\nDoor Position : " + door_pos.ToString("X2");
                    }
                    if ((o.options & ObjectOption.Chest) == ObjectOption.Chest)
                    {
                        id += "\nBig Chest ? : " + room.chest_list[0].bigChest.ToString();
                    }*/
                }
                else if (o is object_door)
                {
                    if ((o as object_door).nx >= 63)
                    {
                        (o as object_door).nx = 63;
                    }
                    if ((o as object_door).ny >= 63)
                    {
                        (o as object_door).ny = 63;
                    }
                    if ((o as object_door).size >= 16)
                    {
                        (o as object_door).size = 0;
                    }
                    if ((o as object_door).layer >= 3)
                    {
                        (o as object_door).size = 2;
                    }

                    mainForm.object_x_label.Text = "X: " + (o as object_door).nx.ToString();
                    mainForm.object_y_label.Text = "Y: " + (o as object_door).ny;
                    mainForm.object_size_label.Text = "Size: " + (o as object_door).size;
                    mainForm.object_layer_label.Text = "Layer: " + ((o as object_door).layer + 1).ToString();
                }
                else if (o is Sprite)
                {
                    if ((o as Sprite).nx >= 31)
                    {
                        (o as Sprite).nx = 31;
                    }
                    if ((o as Sprite).ny >= 31)
                    {
                        (o as Sprite).ny = 31;
                    }
                    if ((o as Sprite).layer >= 2)
                    {
                        (o as Sprite).layer = 1;
                    }
                    mainForm.object_x_label.Text = "X: " + (o as Sprite).nx;
                    mainForm.object_y_label.Text = "Y: " + (o as Sprite).ny;
 
                    mainForm.object_layer_label.Text = "Layer: " + ((o as Sprite).layer+1).ToString();

                    mainForm.spritesubtypeUpDown.Value = (o as Sprite).subtype;
                    
                    if (((o as Sprite).subtype & 0x07) == 0x07)
                    {
                        mainForm.spriteoverlordCheckbox.Checked = true;
                    }
                    else
                    {
                        mainForm.spriteoverlordCheckbox.Checked = false;
                    }

                    mainForm.comboBox1.SelectedIndex = (o as Sprite).keyDrop;

                    updating_info = false;
                    //info = name + "\nId : " + id + "\nX : " + x + "\nY : " + y + "\nLayer : " + layer;
                }
                else if (o is PotItem)
                {
                    if ((o as PotItem).nx >= 63)
                    {
                        (o as PotItem).nx = 63;
                    }
                    if ((o as PotItem).ny >= 63)
                    {
                        (o as PotItem).ny = 63;
                    }
                    if ((o as PotItem).layer >= 2) //NVM
                    {
                        (o as PotItem).layer = 1;
                    }

                    mainForm.object_x_label.Text = "X: " + (o as PotItem).nx;
                    mainForm.object_y_label.Text = "Y: " + (o as PotItem).ny;
                    mainForm.object_layer_label.Text = "Layer: " + ((o as PotItem).layer + 1).ToString();
                }
            }
        }

        /*public void Undo()
        {
            if (DungeonsData.undoRoom[room.index].Count > 0)
            {
                DungeonsData.redoRoom[room.index].Add((Room)room.Clone());
                room = DungeonsData.undoRoom[room.index][(DungeonsData.undoRoom[room.index].Count - 1)];
                DungeonsData.undoRoom[room.index].RemoveAt(DungeonsData.undoRoom[room.index].Count - 1);
                updateRoomInfos(mainForm);
                room.reloadGfx();
                DrawRoom();
                Refresh();
                mainForm.redoButton.Enabled = true;
                mainForm.redoToolStripMenuItem.Enabled = true;
            }
            else
            {
                mainForm.undoButton.Enabled = false;
                mainForm.undoToolStripMenuItem.Enabled = false;
            }

            //selection_resize = false;
            //room.selectedObject.Clear();
        }*/

        /*public void Redo()
        {
            if (DungeonsData.redoRoom[room.index].Count > 0)
            {
                DungeonsData.undoRoom[room.index].Add((Room)room.Clone());
                room = DungeonsData.redoRoom[room.index][(DungeonsData.redoRoom[room.index].Count - 1)];
                DungeonsData.redoRoom[room.index].RemoveAt(DungeonsData.redoRoom[room.index].Count - 1);
                updateRoomInfos(mainForm);
                room.reloadGfx();
                DrawRoom();
                Refresh();
                mainForm.undoButton.Enabled = true;
                mainForm.undoToolStripMenuItem.Enabled = true;
            }
            else
            {
                mainForm.redoButton.Enabled = false;
                mainForm.redoToolStripMenuItem.Enabled = false;
            }
        }*/

        public override void selectAll()
        {
            room.selectedObject.Clear();
            if (selectedMode == ObjectMode.Spritemode)
            {
                foreach (Sprite spr in room.sprites)
                {
                    room.selectedObject.Add(spr);
                }
            }

            foreach (Room_Object o in room.tilesObjects)
            {
                if (o.options == ObjectOption.Nothing)
                {
                    if ((byte)selectedMode <= 3)
                    {
                        if (selectedMode == ObjectMode.Bgallmode)
                        {
                            room.selectedObject.Add(o);
                        }
                        else
                        {
                            if ((byte)selectedMode == o.layer)
                            {
                                room.selectedObject.Add(o);
                            }
                        }
                    }
                }
            }

            Refresh();
        }

        public override void deleteSelected()
        {
            room.has_changed = true;
            mainForm.checkAnyChanges();

            foreach (Object o in room.selectedObject)
            {
                if (o is Room_Object)
                {
                    room.tilesObjects.Remove((o as Room_Object));
                }
                else if (o is Sprite)
                {
                    room.sprites.Remove((o as Sprite));
                }
                else if (o is PotItem)
                {
                    room.pot_items.Remove((o as PotItem));
                }
            }

            room.selectedObject.Clear();
            DrawRoom();
            Refresh();
        }

        public override void paste()
        {
            if (mouse_down == false)
            {
                List<SaveObject> data = null;
                try
                {
                    data = (List<SaveObject>)Clipboard.GetData("ObjectZ");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                if (data != null)
                {
                    if (data.Count > 0)
                    {
                        int most_x = 512;
                        int most_y = 512;
                        foreach (SaveObject o in data)
                        {
                            if (data.Count > 0)
                            {
                                if (o.x < most_x)
                                {
                                    most_x = o.x;
                                }
                                if (o.y < most_y)
                                {
                                    most_y = o.y;
                                }
                            }
                            else
                            {
                                most_x = 0;
                                most_y = 0;
                            }
                        }

                        room.selectedObject.Clear();

                        foreach (SaveObject o in data)
                        {
                            if (o.type == typeof(Sprite))
                            {
                                selectedMode = ObjectMode.Spritemode;
                                Sprite spr = (new Sprite(room, o.id, (byte)(o.x - most_x), (byte)(o.y - most_y), o.subtype, o.layer));
                                room.sprites.Add(spr);
                                room.selectedObject.Add(spr);
                            }
                            else if (o.type == typeof(Room_Object))
                            {
                                if ((o.options & ObjectOption.Door) == ObjectOption.Door)
                                {
                                    selectedMode = ObjectMode.Doormode;
                                    object_door ro = new object_door(o.tid, o.x, o.y, 0, o.layer);
                                    ro.setRoom(room);
                                    ro.options = (ObjectOption)o.options;
                                    room.tilesObjects.Add(ro);
                                    room.selectedObject.Add(ro);
                                }
                                else
                                {
                                    Room_Object ro = room.addObject(o.tid, (byte)(o.x - most_x), (byte)(o.y - most_y), o.size, o.layer);

                                    if (ro != null)
                                    {
                                        if ((byte)selectedMode > 3) //if it not BGAll or bg1-3
                                        {
                                            selectedMode = ObjectMode.Bg1mode; //set it on bg1 by default
                                        }
                                        else if ((byte)selectedMode == 3) //if it bgall do nothing
                                        {

                                        }
                                        else //if it actually a layer set the roomobject on the current selected layer
                                        {
                                            ro.layer = (byte)selectedMode;
                                        }
                                        ro.setRoom(room);
                                        ro.options = (ObjectOption)o.options;
                                        room.tilesObjects.Add(ro);
                                        room.selectedObject.Add(ro);
                                    }
                                }
                            }
                            else if (o.type == typeof(PotItem))
                            {
                                selectedMode = ObjectMode.Itemmode;
                                PotItem item = (new PotItem((byte)o.tid, (byte)(o.x - most_x), (byte)(o.y - most_y), (o.layer == 1 ? true : false)));
                                room.pot_items.Add(item);
                                room.selectedObject.Add(item);
                            }
                        }

                        dragx = 0;
                        dragy = 0;
                        mouse_down = true;
                    }

                    DrawRoom();
                    Refresh();
                }
            }
        }

        public override void copy()
        {
            Clipboard.Clear();
            List<SaveObject> odata = new List<SaveObject>();

            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    odata.Add(new SaveObject((Sprite)o));
                    mouse_down = false;
                }
                if (o is PotItem)
                {
                    odata.Add(new SaveObject((PotItem)o));
                    mouse_down = false;
                }
                if (o is Room_Object)
                {
                    odata.Add(new SaveObject((Room_Object)o));
                    mouse_down = false;
                }
            }

            Clipboard.SetData("ObjectZ", odata);
        }

        public override void loadLayout()
        {
            string f = Interaction.InputBox("Name of the layout to load", "Name?", "Layout00");
            BinaryReader br = new BinaryReader(new FileStream("Layout\\" + f, FileMode.Open, FileAccess.Read));

            string type = br.ReadString();
            List<SaveObject> data = new List<SaveObject>();

            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                data.Add(new SaveObject(br, typeof(Room_Object)));
            }

            if (data.Count > 0)
            {
                int most_x = 512;
                int most_y = 512;
                foreach (SaveObject o in data)
                {
                    if (data.Count > 0)
                    {
                        if (o.x < most_x)
                        {
                            most_x = o.x;
                        }
                        if (o.y < most_y)
                        {
                            most_y = o.y;
                        }
                    }
                    else
                    {
                        most_x = 0;
                        most_y = 0;
                    }
                }
                room.selectedObject.Clear();

                foreach (SaveObject o in data)
                {
                    if (o.type == typeof(Sprite))
                    {
                        Sprite spr = (new Sprite(room, o.id, (byte)(o.x - most_x), (byte)(o.y - most_y), o.subtype, o.layer));
                        room.sprites.Add(spr);
                        room.selectedObject.Add(spr);
                    }
                    else if (o.type == typeof(Room_Object))
                    {
                        Room_Object ro = room.addObject(o.tid, (byte)(o.x - most_x), (byte)(o.y - most_y), o.size, o.layer);
                        if (ro != null)
                        {
                            ro.setRoom(room);
                            ro.options = o.options;
                            room.tilesObjects.Add(ro);
                            room.selectedObject.Add(ro);
                        }
                    }
                }

                dragx = 0;
                dragy = 0;
                mouse_down = true;
            }
        }

        public override void cut()
        {
            Clipboard.Clear();
            //Room r = (Room)room.Clone();
            //clearUselessRoomStuff(r);
            room.has_changed = true;
            mainForm.checkAnyChanges();
            //undoRooms.Add(r);

            List<SaveObject> odata = new List<SaveObject>();
            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    odata.Add(new SaveObject((Sprite)o));
                }
                if (o is PotItem)
                {
                    odata.Add(new SaveObject((PotItem)o));
                }
                if (o is Room_Object)
                {
                    odata.Add(new SaveObject((Room_Object)o));
                }
            }

            Clipboard.SetData("ObjectZ", odata);

            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    room.sprites.Remove((Sprite)o);
                }
                if (o is PotItem)
                {
                    room.pot_items.Remove((PotItem)o);
                }
                if (o is Room_Object)
                {
                    room.tilesObjects.Remove((Room_Object)o);
                }
            }

            room.selectedObject.Clear();
            DrawRoom();
            Refresh();
        }

        public override void insertNew()
        {
            //if block selected
            if (selectedMode == ObjectMode.Blockmode)
            {
                room.selectedObject.Clear();
                Room_Object ro = room.addObject(0x0E00, (byte)0, (byte)0, 0, 0);
                if (ro != null)
                {
                    ro.setRoom(room);
                    ro.options = ObjectOption.Block;
                    room.tilesObjects.Add(ro);
                    room.selectedObject.Add(ro);
                    dragx = 0;
                    dragy = 0;
                    mouse_down = true;
                }
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                room.selectedObject.Clear();
                PotItem p = new PotItem(1, 0, 0, false);
                room.pot_items.Add(p);
                    room.selectedObject.Add(p);
                    dragx = 0;
                    dragy = 0;
                    mouse_down = true;
            }
            else if (selectedMode == ObjectMode.Chestmode)
            {
                addChest();
            }
            else if (selectedMode == ObjectMode.Torchmode)
            {
                room.selectedObject.Clear();
                Room_Object ro = room.addObject(0x150, (byte)0, (byte)0, 0, 0);
                if (ro != null)
                {
                    ro.setRoom(room);
                    ro.options = ObjectOption.Torch;
                    room.tilesObjects.Add(ro);
                    room.selectedObject.Add(ro);
                    dragx = 0;
                    dragy = 0;
                    mouse_down = true;
                }
            }
            else if (selectedMode == ObjectMode.Doormode)
            {
                room.selectedObject.Clear();
                Room_Object ro = new object_door(0, 0, 0, 0, 0);
                if (ro != null)
                {
                    ro.setRoom(room);
                    ro.options = ObjectOption.Door;
                    room.tilesObjects.Add(ro);
                    this.Focus();
                    mainForm.activeScene = this;
                    //room.selectedObject.Add(ro);
                }
            }
            else if ((byte)selectedMode >= 0 && (byte)selectedMode < 3) //if != allbg
            {
                //picker object :thinking:
                //pObj.createObjects(room);
                //pObj.ShowDialog();
                /*if (pObj.selectedObject != -1)
                {
                    room.selectedObject.Clear();
                    Room_Object ro = room.addObject(pObj.selectedObject, (byte)0, (byte)0, 0, (byte)selectedMode);
                    if (ro != null)
                    {
                        ro.setRoom(room);
                        ro.get_scroll_x();
                        ro.get_scroll_y();
                        if (ro.special_zero_size != 0)
                        {
                            ro.size = 1;
                        }
       
                        room.tilesObjects.Add(ro);
                        room.selectedObject.Add(ro);
                        dragx = 0;
                        dragy = 0;
                        mouse_down = true;
                        need_refresh = true;
                        room.reloadGfx();
                    }
                }*/
            }

            DrawRoom();
            Refresh();
        }

        public override void SendSelectedToBack()
        {
            if (room.selectedObject.Count > 0)
            {
                if (room.selectedObject[0] is Room_Object)
                {
                    foreach (Room_Object o in room.selectedObject)
                    {
                        for (int i = 0; i < room.tilesObjects.Count; i++)
                        {

                            if (o == room.tilesObjects[i])
                            {
                                room.tilesObjects.RemoveAt(i);
                                room.tilesObjects.Insert(0, o);
                                break;
                            }
                        }
                    }
                }

                DrawRoom();
                Refresh();
                mouse_down = false;
            }
        }

        public override void DecreaseSelectedZ()
        {
            if (room.selectedObject.Count > 0)
            {
                if (room.selectedObject[0] is Room_Object)
                {
                    foreach (Room_Object o in room.selectedObject)
                    {
                        for (int i = 0; i < room.tilesObjects.Count; i++)
                        {
                            if (o == room.tilesObjects[i])
                            {
                                if (i > 0)
                                {
                                    room.tilesObjects.RemoveAt(i);
                                    room.tilesObjects.Insert(i - 1, o);
                                }
                                break;
                            }
                        }
                    }
                }

                DrawRoom();
                Refresh();
                mouse_down = false;
            }
        }

        public override void UpdateSelectedZ(int position)
        {
            if (room.selectedObject.Count > 0)
            {
                if (room.selectedObject[0] is Room_Object)
                {
                    foreach (Room_Object o in room.selectedObject)
                    {
                        for (int i = 0; i < room.tilesObjects.Count; i++)
                        {
                            if (o == room.tilesObjects[i])
                            {
                                if (i < room.tilesObjects.Count-1)
                                {
                                    room.tilesObjects.RemoveAt(i);
                                    room.tilesObjects.Insert(position, o);
                                }
                                break;
                            }
                        }
                    }
                }

                DrawRoom();
                Refresh();
                mouse_down = false;
            }
        }
        
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        private void chestpicker_Load(object sender, EventArgs e)
        {
            //TODO: Add something here?
        }

        private void pObj_Load(object sender, EventArgs e)
        {
            //TODO: Add something here?
        }

        public void updateRoomInfos(DungeonMain mainForm)
        {
            mainForm.propertiesChangedFromForm = true;
            mainForm.roomProperty_bg2.SelectedIndex = (int)room.bg2;
            mainForm.roomProperty_blockset.Text = room.blockset.ToString("X2");
            mainForm.roomProperty_tag1.SelectedIndex = (int)room.tag1;
            mainForm.roomProperty_tag2.SelectedIndex = (int)room.tag2;
            mainForm.roomProperty_effect.SelectedIndex = (int)room.effect;
            mainForm.roomProperty_collision.SelectedIndex = (int)room.collision;
            mainForm.roomProperty_floor1.Text = room.floor1.ToString("X2");
            mainForm.roomProperty_floor2.Text = room.floor2.ToString("X2");

            mainForm.roomProperty_layout.Text = room.layout.ToString("X2");
            mainForm.roomProperty_msgid.Text = room.messageid.ToString("X2");
            mainForm.roomProperty_palette.Text = room.palette.ToString("X2");
            mainForm.roomProperty_pit.Checked = room.damagepit;
            mainForm.roomProperty_sortsprite.Checked = room.sortsprites;
            mainForm.roomProperty_spriteset.Text = room.spriteset.ToString("X2");


            mainForm.roomProperty_hole.Text = room.holewarp.ToString("X2");
            mainForm.bg2checkbox1.Checked = room.holewarp_plane == 2 ? true : false;
            mainForm.roomProperty_stair1.Text = room.staircase1.ToString("X2");
            mainForm.bg2checkbox2.Checked = room.staircase1Plane == 2 ? true : false;
            mainForm.roomProperty_stair2.Text = room.staircase2.ToString("X2");
            mainForm.bg2checkbox3.Checked = room.staircase2Plane == 2 ? true : false;
            mainForm.roomProperty_stair3.Text = room.staircase3.ToString("X2");
            mainForm.bg2checkbox4.Checked = room.staircase3Plane == 2 ? true : false;
            mainForm.roomProperty_stair4.Text = room.staircase4.ToString("X2");
            mainForm.bg2checkbox5.Checked = room.staircase4Plane == 2 ? true : false;

            mainForm.propertiesChangedFromForm = false;
        }
    }
}
