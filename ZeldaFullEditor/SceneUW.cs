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
using static ZeldaFullEditor.Form1;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ZeldaFullEditor
{
    public class SceneUW : Scene
    {

        public SceneUW(Form1 f)
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
        
        public short[] doorsObject = new short[] { 0x138, 0x139, 0x13A, 0x13B, 0xF9E, 0xF9F, 0xFA0, 0x12D, 0x12E, 0x12F, 0x12E, 0x12D, 0x4632, 0x4693 };
        Rectangle lastSelectedRectangle;
        byte[] spriteFontSpacing = new byte[] { 4, 3, 5, 7, 5, 6, 5, 3, 4, 4, 5, 5, 3, 5, 3, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 3, 3, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 5, 5, 6, 5, 5, 7, 6, 5, 5, 5, 5, 5, 5, 5, 5, 7, 5, 5, 5, 4, 5, 4 };
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
                        }

                    }
                    else if (e.Delta < 0)
                    {
                        if ((room.selectedObject[0] as Room_Object).size > 0)
                        {
                            (room.selectedObject[0] as Room_Object).UpdateSize();
                            (room.selectedObject[0] as Room_Object).size--;
                        }
                    }
                }
            }
            this.DrawRoom();
            this.Refresh();
        }
        
        public void drawText(Graphics g, int x, int y, string text)
        {
            text = text.ToUpper();
            int cpos = 0;
            for (int i = 0;i<text.Length;i++)
            {
                byte arrayPos = (byte)(text[i]-32);

                g.DrawImage(mainForm.spriteFont, new Rectangle(x + cpos, y, 8, 8), arrayPos*8, 0, 8, 8, GraphicsUnit.Pixel);
                cpos += spriteFontSpacing[arrayPos];
            }
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            bool colliding_chest = false;
            if (selectedMode == ObjectMode.Chestmode)
            {
                foreach (Chest c in room.chest_list)
                {
                    if (e.X >= (c.x * 8) && e.Y >= (c.y * 8) - 16 && e.X <= (c.x * 8) + 16 && e.Y <= (c.y * 8) + 16)
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
            /*if (mouse_down)
            {
                updating_info = true;
                setMouseSizeMode(e);
                //define the size of mx,my for each mode
                if (selectedMode != ObjectMode.Doormode)
                {
                    if (mx != last_mx || my != last_my)
                    {
                        if (room.selectedObject.Count > 0)
                        {
                            move_objects();
                            room.has_changed = true;
                            mainForm.checkAnyChanges();
                            last_mx = mx;
                            last_my = my;
                            updateSelectionObject(room.selectedObject[0]);
                        }
                        DrawRoom();
                        Refresh();
                    }
                }
            }*/



            if (mouse_down)
            {
                updating_info = true;

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
                    //TODO : Fix door draw when dragged on side position are not accurate anymore
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
                                        if (new Rectangle(e.X, e.Y, 1, 1).IntersectsWith(r))
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
            
            e.Graphics.SetClip(new Rectangle(0, 0, 512, 512));
            e.Graphics.Clear(Color.Black);
            if (room.bg2 != Background2.Translucent || room.bg2 != Background2.Transparent || room.bg2 != Background2.OnTop || room.bg2 != Background2.Off)
            {
                e.Graphics.DrawImage(GFX.roomBg2Bitmap, 0, 0);
            }


            //e.Graphics.DrawImage(GFX.roomBgLayoutBitmap,0,0);
            e.Graphics.DrawImage(GFX.roomBg1Bitmap, 0, 0);

            if (room.bg2 == Background2.Translucent || room.bg2 == Background2.Transparent)
            {
                float[][] matrixItems ={
               new float[] {1f, 0, 0, 0, 0},
               new float[] {0, 1f, 0, 0, 0},
               new float[] {0, 0, 1f, 0, 0},
               new float[] {0, 0, 0, 0.5f, 0},
               new float[] {0, 0, 0, 0, 1}};
                ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

                // Create an ImageAttributes object and set its color matrix.
                ImageAttributes imageAtt = new ImageAttributes();
                imageAtt.SetColorMatrix(
                   colorMatrix,
                   ColorMatrixFlag.Default,
                   ColorAdjustType.Bitmap);
                //GFX.roomBg2Bitmap.MakeTransparent(Color.Black);
                e.Graphics.DrawImage(GFX.roomBg2Bitmap, new Rectangle(0, 0, 512, 512), 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
            }
            else if (room.bg2 == Background2.OnTop)
            {
                e.Graphics.DrawImage(GFX.roomBg2Bitmap, 0, 0);
            }


            //e.Graphics.DrawImage(GFX.currentgfx16Bitmap, 0, -256);
            drawSelection(e.Graphics);

            drawGrid(e.Graphics);
            int superY = (room.index / 16);
            int superX = room.index - (superY * 16);

            int roomX = superX * 512;
            int roomY = superY * 512;
            if (mainForm.cameraboxCheckbox.Checked)
            {

                if (mainForm.selectedEntrance != null)
                {
                    int localCameraX = mainForm.selectedEntrance.XCamera - 128;
                    int localCameraY = mainForm.selectedEntrance.YCamera - 116;

                    e.Graphics.DrawRectangle(Pens.Orange, new Rectangle(localCameraX, localCameraY, 256, 224));
                    Console.WriteLine(localCameraX + "," + localCameraY);
                }
            }

            if (mainForm.entranceposCheckbox.Checked)
            {
                if (mainForm.selectedEntrance != null)
                {
                    int xpos = mainForm.selectedEntrance.XPosition - roomX;
                    int ypos = mainForm.selectedEntrance.YPosition - roomY;
                    e.Graphics.DrawLine(Pens.White, xpos - 4, ypos, xpos + 4, ypos);
                    e.Graphics.DrawLine(Pens.White, xpos, ypos - 4, xpos, ypos + 4);
                }
            }

            //e.Graphics.DrawImage(GFX.roomObjectsBitmap,0,0);
            //e.Graphics.DrawImage(GFX., 0, -512);
            //drawText(e.Graphics,4,4, "This is a test? []()abc 1234567890-+");
            int stairCount = 0;
            int chestCount = 0;
            int doorCount = 0;
            foreach(Room_Object o in room.tilesObjects)
            {
                if (mainForm.showChestIDs)
                {
                    if (o.id == 0xF99 || o.id == 0xFB1)
                    {
                        drawText(e.Graphics, (o.nx * 8) + 6, (o.ny * 8) + 8, chestCount.ToString());
                        chestCount++;
                    }
                }

                if (o.options == ObjectOption.Door)
                {
                    if (mainForm.showDoorsIDs)
                    {
                        drawText(e.Graphics, (o.x * 8) + 12, (o.y * 8), doorCount.ToString());
                    }
                    doorCount++;
                    if ((o.id >> 8) == 18) //exit door
                    {
                        drawText(e.Graphics, (o.x*8)+6, (o.y*8)+8, "Exit");
                    }
                    else if ((o.id >> 8) == 0x16) //exit door
                    {
                        drawText(e.Graphics, (o.x * 8) + 6, (o.y * 8) + 8, "to");
                        drawText(e.Graphics, (o.x * 8) + 4, (o.y * 8) + 16, "bg2");
                    }
                }

                if (o.options == ObjectOption.Block)
                {
                    e.Graphics.DrawImage(mainForm.moveableBlock, o.nx*8, o.ny*8);
                }

                if (doorsObject.Contains(o.id))
                {
                    drawText(e.Graphics, o.nx*8, o.ny*8, "to : " + room.staircase_rooms[stairCount].ToString());
                    stairCount++;
                }

            }

            if (mainForm.showSpriteText)
            {
                foreach (Sprite spr in room.sprites)
                {
                    drawText(e.Graphics, spr.nx*16, spr.ny*16, spr.name);
                }
            }

            if (mainForm.showChestText)
            {
                foreach (Chest c in room.chest_list)
                {
                    drawText(e.Graphics, c.x*8, c.y*8, ChestItems_Name.name[c.item]);
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
                    string name = PotItems_Name.name[dropboxid];
                    drawText(e.Graphics, c.nx*8, c.ny*8, name);
                }
            }

            drawDoorsPosition(e.Graphics);

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
            //graphics.Clear(this.BackColor);
        }


        bool clickedObject = false;
        private void onMouseDown(object sender, MouseEventArgs e)
        {
            this.Focus();
            mainForm.activeScene = this;

            if (mainForm.tabControl1.SelectedIndex == 2)//if we are on object tab
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
            else if (mainForm.tabControl1.SelectedIndex == 3)
            {
                if (selectedDragSprite != null)
                {
                    room.selectedObject.Clear();

                    Sprite spr = new Sprite(room, (byte)selectedDragSprite.id, 0, 0, selectedDragSprite.option, 0, 0);
                        
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
                    dragx = ((e.X) / 16);
                    dragy = ((e.Y) / 16);
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
                    dragx = ((e.X) / 8);
                    dragy = ((e.Y) / 8);
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

                    dragx = ((e.X) / 8);
                    dragy = ((e.Y) / 8);
                    bool already_in = false;
                    Room_Object objectFound = null;
                    found = false;
                    for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
                    {
                        Room_Object obj = room.tilesObjects[i];
                        if (isMouseCollidingWith(obj, e))
                        {
                            if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Door) != ObjectOption.Door && (obj.options & ObjectOption.Torch) != ObjectOption.Torch && (obj.options & ObjectOption.Block) != ObjectOption.Block)
                            {
                                if (room.selectedObject.Count == 0)
                                {
                                    //(byte)selectedMode >= 0 && (byte)selectedMode <= 3
                                    if (selectedMode == ObjectMode.Bgallmode || (byte)selectedMode == obj.layer)
                                    {
                                        room.selectedObject.Add(obj);
                                        found = true;
                                        break;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else //there's already objects selected
                                {
                                    //check if the object we found is already in selected object if so do nothing
                                    //otherwise clear objects and select the new one
                                    foreach (Room_Object o in room.selectedObject)
                                    {
                                        if (o == obj)
                                        {
                                            if (selectedMode == ObjectMode.Bgallmode || (byte)selectedMode == obj.layer)
                                            {
                                                found = true;
                                                objectFound = o;
                                                already_in = true;
                                                break;
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                    if (already_in == false)
                                    {

                                        //objectToRemove
                                        if (ModifierKeys == Keys.Shift)
                                        {
                                            if (selectedMode == ObjectMode.Bgallmode || (byte)selectedMode == obj.layer)
                                            {
                                                room.selectedObject.Add(obj);
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            room.selectedObject.Clear();
                                            if (selectedMode == ObjectMode.Bgallmode || (byte)selectedMode == obj.layer)
                                            {
                                                room.selectedObject.Add(obj);
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }

                                    }
                                    else //if item is already in but we hold control then remove it instead
                                    {
                                        if (selectedMode == ObjectMode.Bgallmode || (byte)selectedMode == obj.layer)
                                        {
                                            if (ModifierKeys == Keys.Control)
                                            {
                                                room.selectedObject.Remove(objectFound);
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                }
                                found = true;
                                break;
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
                    Console.Write("Door mode");
                    room.selectedObject.Clear();
                    dragx = ((e.X) / 8);
                    dragy = ((e.Y) / 8);
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
                    dragx = ((e.X) / 8);
                    dragy = ((e.Y) / 8);
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
                    dragx = ((e.X) / 8);
                    dragy = ((e.Y) / 8);
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
                    dragx = ((e.X) / 8);
                    dragy = ((e.Y) / 8);
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
                        mainForm.selectedGroupbox.Text = "Selected Object : " + id + " " + name;
                        mainForm.doorselectPanel.Visible = true;
                        int apos = mainForm.door_index.Select((s, i) => new { s, i }).Where(x => x.s == (oo as object_door).door_type).Select(x => x.i).ToArray()[0];
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
                    if (oo.overlord != 0)
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
                    string name = PotItems_Name.name[dropboxid];
                    string id = oo.id.ToString("X4");
                    mainForm.selectedGroupbox.Text = "Selected Item : " + id + " " + name;
                    mainForm.selecteditemobjectCombobox.SelectedIndex = dropboxid;
                    updating_info = false;
                }
            }
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
                o.Draw();
            }
            //draw object on bitmap

            foreach (Room_Object o in room.tilesObjects)
            {
                if (o.layer != 2)
                {
                    o.Draw();
                }
                if (o.options == ObjectOption.Door)
                {
                    o.Draw();
                }
            }
            foreach (Room_Object o in room.tilesObjects)
            {
                //Draw doors here since they'll all be put on bg3 anyways
                if (o.layer == 2)
                {
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
            

            if (mouse_down == true)
            {
                if (e.Button == MouseButtons.Left)
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

                }
                else if (e.Button == MouseButtons.Right) //that's a problem
                {
                    mainForm.nothingselectedcontextMenu.Items[0].Enabled = true;
                    mainForm.singleselectedcontextMenu.Items[0].Enabled = true;
                    mainForm.groupselectedcontextMenu.Items[0].Enabled = true;
                    string nname = "Unknown";
                    if ((byte)selectedMode >= 0 && (byte)selectedMode <= 3)
                    {
                        nname = "Object";
                        if (selectedMode == ObjectMode.Bgallmode)
                        {
                            mainForm.nothingselectedcontextMenu.Items[0].Enabled = false;
                            mainForm.singleselectedcontextMenu.Items[0].Enabled = false;
                            mainForm.groupselectedcontextMenu.Items[0].Enabled = false;
                        }
                    }
                    else if (selectedMode == ObjectMode.Spritemode)
                    {
                        nname = "Sprite";
                    }
                    else if (selectedMode == ObjectMode.Chestmode)
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
                    mainForm.nothingselectedcontextMenu.Items[0].Text = "Insert new " + nname;
                    mainForm.singleselectedcontextMenu.Items[0].Text = "Insert new " + nname;
                    mainForm.groupselectedcontextMenu.Items[0].Text = "Insert new " + nname;
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
                }
            }
            DrawRoom();
            Refresh();

        }
        
        private void onMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (selectedMode == ObjectMode.Chestmode)
            {
                Chest chestToRemove = null;
                bool foundChest = false;
                foreach (Chest c in room.chest_list)
                {
                    if (e.X >= (c.x * 8) && e.X <= (c.x * 8) + 16 &&
                        e.Y >= ((c.y - 2) * 8) && e.Y <= ((c.y) * 8) + 16)
                    {
                        mainForm.chestPicker.button1.Enabled = true;//enable delete button
                        DialogResult result = mainForm.chestPicker.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            //change chest item
                            int r = 0;
                            if (int.TryParse(mainForm.chestPicker.idtextbox.Text,out r))
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
                        Chest c = new Chest((byte)(e.X / 8), (byte)(e.Y / 8), (byte)mainForm.chestPicker.chestviewer1.selectedIndex, false, false);
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

        public void clearUselessRoomStuff(Room r)
        {


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

        }

        public void objects_ResizeMouseMove(MouseEventArgs e)
        {
            
        }

        public void setMouseSizeMode(MouseEventArgs e)
        {
            if (selectedMode == ObjectMode.Spritemode)
            {
                mx = ((e.X) / 16);
                my = ((e.Y) / 16);
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                mx = ((e.X) / 8);
                my = ((e.Y) / 8);
            }
            else if ((byte)selectedMode >= 0 && (byte)selectedMode <= 3)
            {
                mx = ((e.X) / 8);
                my = ((e.Y) / 8);
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
            if (o is Sprite)
            {
                if (e.X >= (o as Sprite).boundingbox.X && e.X <= (o as Sprite).boundingbox.X + (o as Sprite).boundingbox.Width &&
                e.Y >= (o as Sprite).boundingbox.Y && e.Y <= (o as Sprite).boundingbox.Y + (o as Sprite).boundingbox.Height)
                {
                    return true;
                }
            }
            else if (o is PotItem)
            {
                if (e.X >= ((o as PotItem).x * 8) && e.X <= ((o as PotItem).x * 8) + 16 &&
                    e.Y >= ((o as PotItem).y * 8) && e.Y <= ((o as PotItem).y * 8) + 16)
                {
                    return true;
                }
            }
            else if (o is Room_Object)
            {
                //if ((o as Room_Object).layer == (byte)selectedMode || selectedMode == ObjectMode.Bgallmode)
                //{
                    if (e.X >= ((o as Room_Object).x*8) && e.X <= ((o as Room_Object).x*8) + ((o as Room_Object).width) &&
                        e.Y >= ((o as Room_Object).y*8) && e.Y <= ((o as Room_Object).y*8) + ((o as Room_Object).height))
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

                        
                            if ((new Rectangle(((o as Room_Object).x) * 8, ((o as Room_Object).y) * 8, ((o as Room_Object).width), ((o as Room_Object).height))).IntersectsWith(new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
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

                }
            }

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


                    mainForm.object_x_label.Text = "X: " + (o as Room_Object).nx.ToString();
                    mainForm.object_y_label.Text = "Y: " + (o as Room_Object).ny;
                    mainForm.object_size_label.Text = "Size: " + (o as Room_Object).size;
                    mainForm.object_layer_label.Text = "Layer (BG): " + (o as Room_Object).layer+1;
                    int z = 0;
                    foreach (Room_Object door in room.tilesObjects)
                    {
                        if (door.options == ObjectOption.Door)
                        {
                            if (door == o)
                            {
                                mainForm.object_z_label.Text = "Z: " + z.ToString(); //where's my door 0 :scream:
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
                    mainForm.object_layer_label.Text = "Layer: " + (o as object_door).layer;


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
 
                    mainForm.object_layer_label.Text = "Layer: " + (o as Sprite).layer;
                    mainForm.spritesubtypeUpDown.Value = (o as Sprite).subtype;
                    if ((o as Sprite).overlord == 0)
                    {
                        mainForm.spriteoverlordCheckbox.Checked = false;
                    }
                    else
                    {
                        mainForm.spriteoverlordCheckbox.Checked = true;
                    }
                    mainForm.comboBox1.SelectedIndex = (o as Sprite).keyDrop;

 
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
                    mainForm.object_layer_label.Text = "Layer: " + (o as PotItem).layer;

                }
            }
        }


        public void Undo()
        {
            selection_resize = false;
            room.selectedObject.Clear();

        }

        public void Redo()
        {

        }

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
            List<SaveObject> data = (List<SaveObject>)Clipboard.GetData("ObjectZ");
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
                            Sprite spr = (new Sprite(room, o.id, (byte)(o.x - most_x), (byte)(o.y - most_y), o.overlord, o.subtype, o.layer));
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

        public override void copy()
        {
            Clipboard.Clear();
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
                        Sprite spr = (new Sprite(room, o.id, (byte)(o.x - most_x), (byte)(o.y - most_y), o.overlord, o.subtype, o.layer));
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
                    room.selectedObject.Add(ro);
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

        public override void changeObject()
        {
            if ((byte)selectedMode >= 0 && (byte)selectedMode < 3)
            {
                /*pObj.createObjects(room);
                if (pObj.ShowDialog() == DialogResult.OK)
                {
                    if (room.selectedObject.Count == 1)
                    {

                        if (pObj.selectedObject != -1)
                        {
                            byte x = (room.selectedObject[0] as Room_Object).x;
                            byte y = (room.selectedObject[0] as Room_Object).y;
                            room.tilesObjects.Remove((Room_Object)room.selectedObject[0]);
                            room.selectedObject.Clear();
                            Room_Object ro = room.addObject(pObj.selectedObject, (byte)x, (byte)y, 0, (byte)selectedMode);
                            if (ro != null)
                            {

                                ro.get_scroll_x();
                                ro.get_scroll_y();
                                if (ro.special_zero_size != 0)
                                {
                                    ro.size = 1;
                                }

                                ro.setRoom(room);
                                ro.options = ObjectOption.Nothing;
                                room.tilesObjects.Add(ro);
                                room.selectedObject.Add(ro);
                                dragx = 0;
                                dragy = 0;
                                //mouse_down = true;
                                need_refresh = true;
                                room.reloadGfx();
                            }

                        }
                    }
                }*/
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

        }

        private void pObj_Load(object sender, EventArgs e)
        {

        }

        public void updateRoomInfos(Form1 mainForm)
        {
            mainForm.propertiesChangedFromForm = true;
            mainForm.roomProperty_bg2.SelectedIndex = (int)room.Bg2;
            mainForm.roomProperty_blockset.Text = room.Blockset.ToString();
            mainForm.roomProperty_tag1.SelectedIndex = (int)room.Tag1;
            mainForm.roomProperty_tag2.SelectedIndex = (int)room.Tag2;
            mainForm.roomProperty_effect.SelectedIndex = (int)room.Effect;
            mainForm.roomProperty_collision.SelectedIndex = (int)room.Collision;
            mainForm.roomProperty_floor1.Text = room.Floor1.ToString();
            mainForm.roomProperty_floor2.Text = room.Floor2.ToString();
            mainForm.roomProperty_hole.Text = room.HoleWarp.ToString();
            mainForm.roomProperty_holeplane.Text = room.HoleWarpPlane.ToString();
            mainForm.roomProperty_layout.Text = room.Layout.ToString();
            mainForm.roomProperty_msgid.Text = room.Messageid.ToString();
            mainForm.roomProperty_palette.Text = room.Palette.ToString();
            mainForm.roomProperty_pit.Checked = room.Damagepit;
            mainForm.roomProperty_sortsprite.Checked = room.SortSprites;
            mainForm.roomProperty_spriteset.Text = room.Spriteset.ToString();
            mainForm.roomProperty_stair1.Text = room.Staircase1.ToString();
            mainForm.roomProperty_stair1plane.Text = room.Staircase1Plane.ToString();
            mainForm.roomProperty_stair2.Text = room.Staircase2.ToString();
            mainForm.roomProperty_stair2plane.Text = room.Staircase2Plane.ToString();
            mainForm.roomProperty_stair3.Text = room.Staircase3.ToString();
            mainForm.roomProperty_stair3plane.Text = room.Staircase3Plane.ToString();
            mainForm.roomProperty_stair4.Text = room.Staircase4.ToString();
            mainForm.roomProperty_stair4plane.Text = room.Staircase4Plane.ToString();
            mainForm.propertiesChangedFromForm = false;
        }

    }

    /*public class DScene : DockContent
    {
        public SceneUW scene;
        zscreamForm mainform;
        public string nameText = "";
        public bool namedChanged = false;
        public DScene(zscreamForm mainform,string nameText)
        {
            scene = new SceneUW(mainform);
            this.nameText = nameText;
            this.mainform = mainform;
            GotFocus += DScene_GotFocus;
            
            FormClosing += DScene_FormClosing;
        }

        private void DScene_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (scene.room.has_changed == true)
            {
                //prompt save message
                //e.Cancel = true;
                DialogResult dialogResult = MessageBox.Show("Room has changed. Do you want to save changes?", "Save", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes) //save
                {
                    scene.room.has_changed = false;
                    mainform.all_rooms[scene.room.index] = (Room)scene.room.Clone();
                   
                    mainform.rooms.Remove(this);
                    mainform.loadRoomList(0);
                    mainform.mapPicturebox.Refresh();
                }
                else if (dialogResult == DialogResult.No)
                {
                   
                    mainform.rooms.Remove(this);
                    mainform.loadRoomList(0);
                    mainform.mapPicturebox.Refresh();
                }
                else
                {
                    e.Cancel = true;
                }

            }
            else
            {
                mainform.rooms.Remove(this);
                mainform.loadRoomList(0);
                mainform.mapPicturebox.Refresh();
            }
        }

        private void DScene_GotFocus(object sender, EventArgs e)
        {
            mainform.activeScene = this.scene;
            //mainform.mapPropertyGrid.SelectedObject = scene.room;
            scene.updateRoomInfos(mainform);



            scene.room.reloadGfx();
            scene.need_refresh = true;
            GFX.loadedPalettes = GFX.LoadDungeonPalette(scene.room.palette);
            GFX.loadedSprPalettes = GFX.LoadSpritesPalette(scene.room.palette);

            scene.DrawRoom();
            scene.Refresh();
            
        }



        
    }*/


}
