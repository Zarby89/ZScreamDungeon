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
using static ZeldaFullEditor.zscreamForm;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using WeifenLuo.WinFormsUI.Docking;

namespace ZeldaFullEditor
{
    public class Scene : PictureBox
    {
        public bool active = false;
        public Graphics graphics;
        public Bitmap scene_bitmap = new Bitmap(512, 512, PixelFormat.Format32bppRgb);
        public Bitmap scene_bitmap_overlay = new Bitmap(1024,1024, PixelFormat.Format32bppRgb);
        public bool found = false;
        public bool mouse_down = false;
        public int mx = 0;
        public int my = 0;
        public int last_mx = 0;
        public int last_my = 0;
        public int dragx = 0;
        public int dragy = 0;
        public int move_x = 0;
        public int move_y = 0;
        public bool selection_resize = false;
        public bool need_refresh = false;
        public ObjectResize resizing;
        public Rectangle[] doorArray = new Rectangle[48];
        public Room room;
        public ObjectMode selectedMode;
        public short[] doorsObject = new short[] { 0x13B, 0x138, 0x139, 0x12E, 0x12D, 0x4632, 0x4693 };
        public bool showLayer1 = true;
        public bool showLayer2 = true;
        public bool showGrid = false;
        public bool showSpriteText = false;
        public zscreamForm mainForm;
        public bool canSelectUnselectedBG = true;
        public bool isDungeon = true;
        //public List<Room> undoRooms = new List<Room>();
        //public List<Room> redoRooms = new List<Room>();
        public PickObject pObj = new PickObject();
        public dataObject selectedDragObject = null;
        public dataObject selectedDragSprite = null;
        public bool updating_info = false;
        public virtual void drawRoom()
        {
            if (room == null)
            {
                //Console.WriteLine("Problem!");
                //need_refresh = false;
                return;
            }

            if (room.needGfxRefresh)
            {
                room.reloadGfx();
                room.needGfxRefresh = false;
            }

            if (need_refresh)
            {
                //updateSelectionObject();
                addSpecialErasedDraw();
                drawLayout();
                drawLayer1and3plusDoors();
                drawLayer2();
                drawLayersOnBgr();
                drawChests();
                drawSprites();
                GFX.begin_draw(scene_bitmap);
                room.drawPotsItems();
                GFX.end_draw(scene_bitmap);
                drawWarp();
                drawGrid();
                drawSelection();
                drawEntrancePosition();
                drawDoorsPosition();
                this.Image = scene_bitmap;
                this.Refresh();
                need_refresh = false;
            }

        }

        public virtual void Clear()
        {

        }

        public virtual void deleteSelected()
        {

        }

        public virtual void selectAll()
        {

        }

        public virtual void copy()
        {

        }
        public virtual void cut()
        {

        }
        public virtual void paste()
        {

        }
        public virtual void insertNew()
        {

        }
        public virtual void SendSelectedToBack()
        {

        }


        public virtual void UpdateSelectedZ(int i)
        {

        }
        public virtual void changeObject()
        {

        }
        public virtual void loadLayout()
        {

        }
        public virtual void DecreaseSelectedZ()
        {

        }


        List<Room_Object> borderlessobject = new List<Room_Object>();
        public void addSpecialErasedDraw()
        {
            borderlessobject.Clear();
            for (int i = 0; i < room.tilesObjects.Count - 1; i++)
            {
                Room_Object o = room.tilesObjects[i];
                o.specialDraw = false;
                if (o is object_69 || o is object_8A || o is object_3F || o is object_40 || o is object_41 || o is object_42 || o is object_43 || o is object_44 || o is object_46 || o is object_2A || o is object_29 || o is object_22)
                {
                    borderlessobject.Add(o);
                }
                foreach (Room_Object bo in borderlessobject)
                {
                    if (o is object_69 || o is object_8A || o is object_3F || o is object_40 || o is object_41 || o is object_42 || o is object_43 || o is object_44 || o is object_46 || o is object_2A || o is object_29 || o is object_22)
                    {
                        if (o != bo)
                        {
                            if (new Rectangle(o.nx * 8, o.ny * 8, 8, 8).IntersectsWith(new Rectangle(bo.nx * 8, bo.ny * 8, bo.width, bo.height)))
                            {
                                o.specialDraw = true;
                            }
                        }
                    }
                }
            }
        }

        public void drawLayer1and3plusDoors()
        {
            using (Graphics gg = Graphics.FromImage(GFX.bg1_bitmap))
            {

                gg.DrawImage(GFX.bgr_bitmap, 0, 0); //floor 1

                foreach (Room_Object o in room.tilesObjects)
                {
                    if (o.layer == 0 || o.allBgs == true)
                    {
                        drawObject(gg, o);
                    }
                }

                foreach (Room_Object o in room.tilesObjects)
                {
                    if (o.layer == 2)
                    {
                        drawObject(gg, o);
                    }
                }

                foreach (Room_Object o in room.tilesObjects)
                {
                    drawDoors(gg, o);
                }

            }
        }

        public void drawLayout()
        {
            using (Graphics gg = Graphics.FromImage(GFX.bgr_bitmap))
            {

                foreach (Room_Object o in room.tilesLayoutObjects)
                {
                    gg.DrawImage(o.bitmap, (o.nx * 8), ((o.drawYFix * 8) + o.ny * 8));
                }

            }
        }

        public void drawLayer2()
        {
            using (Graphics gg = Graphics.FromImage(GFX.bg2_bitmap))
            {
                using (Graphics ggT = Graphics.FromImage(GFX.bg2_trans_bitmap))
                {
                    ggT.Clear(Color.Transparent);
                    gg.DrawImage(GFX.floor2_bitmap, 0, 0);

                    foreach (Room_Object o in room.tilesObjects)
                    {
                        if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr)
                        {
                            if (o.layer == 1 || o.allBgs)
                            {

                                if (!o.allBgs)
                                {
                                    if (room.bg2 == Background2.Transparent || room.bg2 == Background2.Translucent)
                                    {
                                        ggT.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + o.ny * 8);
                                    }
                                    else
                                    {
                                        gg.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + o.ny * 8);
                                    }
                                }
                                else
                                {

                                    gg.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + o.ny * 8);
                                }

                            }
                        }
                    }
                }
            }
        }

        public void drawLayersOnBgr()
        {
            graphics.Clear(Color.Black);
            GFX.bg2_bitmap.MakeTransparent(Color.Fuchsia);
            GFX.bg1_bitmap.MakeTransparent(Color.Fuchsia);
            GFX.bg2_trans_bitmap.MakeTransparent(Color.Fuchsia);
            if (room.bg2 == Background2.OnTop || room.bg2 == Background2.Transparent || room.bg2 == Background2.Translucent)
            {

                ColorMatrix cm = new ColorMatrix();
                cm.Matrix00 = cm.Matrix11 = cm.Matrix22 = cm.Matrix44 = 1;
                cm.Matrix33 = 0.5f;
                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm);

                if (showLayer1)
                {
                    if (room.bg2 == Background2.Transparent)
                    {
                        graphics.DrawImage(GFX.bg2_bitmap, 0, 0);
                    }
                    graphics.DrawImage(GFX.bg1_bitmap, 0, 0);
                }
                if (showLayer2)
                {
                    if (room.bg2 == Background2.OnTop)
                    {
                        graphics.DrawImage(GFX.bg2_bitmap, 0, 0);
                    }
                    graphics.DrawImage(GFX.bg2_trans_bitmap, new Rectangle(0, 0, 512, 512), 0, 0, 512, 512, GraphicsUnit.Pixel, ia);
                }
            }
            else
            {
                if (showLayer2)
                {
                    graphics.DrawImage(GFX.bg2_bitmap, 0, 0);
                }
                if (showLayer1)
                {
                    graphics.DrawImage(GFX.bg1_bitmap, 0, 0);
                }
            }
        }

        public void drawGrid()
        {
            if (showGrid)
            {
                for (int x = 0; x < 32; x++)
                {
                    graphics.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), x * 16, 0, x * 16, 512);
                }
                for (int y = 0; y < 32; y++)
                {
                    graphics.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), 0, y * 16, 512, y * 16);
                }
            }
        }
        public PickChestItem chestpicker = new PickChestItem();
        public void initChestGfx()
        {
            int length = 75;
            if (Constants.Rando == true)
            {
                length = 175;
            }
            for (int i = 0; i < length; i++)
            {
                GFX.chestitems_bitmap[i] = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
                GFX.begin_draw(GFX.chestitems_bitmap[i], 16, 16);
                new Chest(0, 0, (byte)i, false, true).ItemsDraw((byte)i, 0, 0);
                GFX.end_draw(GFX.chestitems_bitmap[i]);

                chestpicker.listView1.Items.Add(ChestItems_Name.name[i]);
                chestpicker.listView1.Items[i].ImageIndex = i;
                chestpicker.chestItemsImagesList.Images.Add(GFX.chestitems_bitmap[i]);
            }
            Console.WriteLine("???");
            chestpicker.listView1.LargeImageList = chestpicker.chestItemsImagesList;

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
                    if (c.item < 175)
                    {
                        graphics.DrawImage(GFX.chestitems_bitmap[c.item], (c.x * 8), (c.y - 2) * 8);
                    }
                }

            }
        }

        public void drawSprites()
        {
            GFX.begin_draw(scene_bitmap);
            room.drawSprites(showLayer1, showLayer2);
            GFX.end_draw(scene_bitmap);
            if (showSpriteText)
            {
                DrawSpritesTexts();
                need_refresh = true;
            }
        }
        public void DrawSpritesTexts()
        {
            foreach (Sprite spr in room.sprites)
            {
                graphics.DrawString("(" + spr.layer + ") " + spr.name, this.Font, Brushes.Azure, new Point(spr.x * 16, spr.y * 16));
            }
        }

        public void drawSelection()
        {
            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    graphics.DrawRectangle(Pens.Green, (o as Sprite).boundingbox);
                }
                else if (o is PotItem)
                {
                    graphics.DrawRectangle(Pens.Green, new Rectangle((o as PotItem).nx * 8, (o as PotItem).ny * 8, 16, 16));
                }
                else if (o is Room_Object)
                {
                    graphics.DrawRectangle(Pens.Green, new Rectangle(((o as Room_Object).nx) * 8, ((o as Room_Object).ny + (o as Room_Object).drawYFix) * 8, (o as Room_Object).width, (o as Room_Object).height));
                }
            }

            if (mouse_down)
            {
                int rx = dragx;
                int ry = dragy;
                if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
                if (move_y < 0) { Math.Abs(ry = dragy + move_y); }


                if (room.selectedObject.Count == 0)
                {
                    if (selectedMode == ObjectMode.Spritemode)
                    {
                        graphics.DrawRectangle(new Pen(Brushes.White), new Rectangle(rx * 16, ry * 16, Math.Abs(move_x) * 16, Math.Abs(move_y) * 16));
                    }
                    else
                    {
                        graphics.DrawRectangle(new Pen(Brushes.White), new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8));
                    }
                }


                foreach (Object o in room.selectedObject)
                {
                    if (o is Sprite)
                    {
                        graphics.DrawRectangle(Pens.LimeGreen, (o as Sprite).boundingbox);
                    }
                    else if (o is PotItem)
                    {
                        graphics.DrawRectangle(Pens.LimeGreen, new Rectangle((o as PotItem).nx * 8, (o as PotItem).ny * 8, 16, 16));
                    }
                    else if (o is Room_Object)
                    {
                        graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(((o as Room_Object).nx) * 8, ((o as Room_Object).ny + (o as Room_Object).drawYFix) * 8, (o as Room_Object).width, (o as Room_Object).height));
                    }
                }
            }
        }

        public void drawEntrancePosition()
        {
            /*if (entranceposCheckbox.Checked)
            {
                short yPosition = (short)(((ROM.DATA[(Constants.entrance_yposition + (entranceListBox.SelectedIndex * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.entrance_yposition + (entranceListBox.SelectedIndex * 2)]);
                short xPosition = (short)(((ROM.DATA[(Constants.entrance_xposition + (entranceListBox.SelectedIndex * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.entrance_xposition + (entranceListBox.SelectedIndex * 2)]);
                graphics.DrawLine(new Pen(Color.FromArgb(255, 255, 200, 16)), xPosition - 8, yPosition, xPosition + 8, yPosition);
                graphics.DrawLine(new Pen(Color.FromArgb(255, 255, 200, 16)), xPosition, yPosition - 8, xPosition, yPosition + 8);
            }
            if (cameraboxCheckbox.Checked)
            {
                graphics.DrawRectangle(Pens.Azure, new Rectangle((int)entrancecameraxUpDown.Value - 128, (int)entrancecamerayUpDown.Value - 112, 256, 224));

            }*/
        }

        public void drawDoorsPosition()
        {
            if (mouse_down)
            {
                if (room.selectedObject.Count > 0)
                {
                    if (room.selectedObject[0] is Room_Object)
                    {
                        if (((room.selectedObject[0] as Room_Object).options & ObjectOption.Door) == ObjectOption.Door)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                graphics.DrawRectangles(new Pen(new SolidBrush(Color.FromArgb(10, 0, 200, 0))), doorArray);
                            }
                        }
                    }
                }
            }
        }


        public void drawObject(Graphics g, Room_Object o)
        {
            if ((o.options & ObjectOption.Door) != ObjectOption.Door)
            {

                if (o.specialDraw)
                {
                    if (o is object_69 || o is object_8A) //vertical objects
                    {
                        g.DrawImage(o.bitmap, o.nx * 8, ((o.drawYFix * 8) + o.ny * 8) + 8, new Rectangle(0, 8, o.bitmap.Width, o.bitmap.Height), GraphicsUnit.Pixel);
                    }
                    else if (o is object_3F || o is object_40 || o is object_41 || o is object_42 || o is object_43 || o is object_44 || o is object_46 || o is object_2A || o is object_29 || o is object_22) //horizontal objects
                    {
                        g.DrawImage(o.bitmap, (o.nx * 8) + 8, ((o.drawYFix * 8) + o.ny * 8), new Rectangle(8, 0, o.bitmap.Width, o.bitmap.Height), GraphicsUnit.Pixel);
                    }
                }
                else
                {
                    g.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + o.ny * 8);
                }
            }
        }



        public void drawWarp()
        {
            bool foundWarp = false;
            int doorCount = 0;
            int indexEG2 = 0;
            if (room.index > 255)
            {
                indexEG2 = 256;
            }
            foreach (Room_Object o in room.tilesObjects)
            {
                if (doorCount < 4)
                {
                    if (doorsObject.Contains(o.id))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        GraphicsPath gpath = new GraphicsPath();
                        gpath.AddString("To : " + (room.staircase_rooms[doorCount] + indexEG2).ToString(), new FontFamily("Consolas"), 1, 12, new Point(o.x * 8, o.y * 8), StringFormat.GenericDefault);
                        Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
                        graphics.DrawPath(pen, gpath);
                        SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                        graphics.FillPath(brush, gpath);

                        //graphics.DrawString("To : " + room.staircase_rooms[doorCount].ToString(), new Font("Arial", 10), Brushes.White, o.x*8, o.y*8);
                        doorCount++;
                    }
                }
                if (o.id == 0xFCA)
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    GraphicsPath gpath = new GraphicsPath();
                    gpath.AddString("To : " + (room.holewarp + indexEG2).ToString(), new FontFamily("Consolas"), 1, 12, new Point(o.x * 8, o.y * 8), StringFormat.GenericDefault);
                    Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
                    graphics.DrawPath(pen, gpath);
                    SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                    graphics.FillPath(brush, gpath);
                    //graphics.DrawString("To : " + room.holewarp.ToString(), new Font("Arial", 10), Brushes.White, o.x * 8, o.y * 8);
                    //warp
                    foundWarp = true;
                }
            }
            if (foundWarp == false)
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                GraphicsPath gpath = new GraphicsPath();
                gpath.AddString("Hole : " + (room.holewarp + indexEG2).ToString(), new FontFamily("Consolas"), 1, 12, new Point(4, 4), StringFormat.GenericDefault);
                Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
                graphics.DrawPath(pen, gpath);
                SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                graphics.FillPath(brush, gpath);
                //graphics.DrawString("To : " + room.holewarp.ToString(), new Font("Arial", 10), Brushes.White, o.x * 8, o.y * 8);
                //warp
            }
        }

        public void drawDoors(Graphics g, Room_Object o)
        {
            if ((o.options & ObjectOption.Door) == ObjectOption.Door)
            {

                if (o is object_door)
                {
                    if ((o.id & 0xFF00) == 0x1200)
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        GraphicsPath gpath = new GraphicsPath();
                        gpath.AddString("Exit", new FontFamily("Consolas"), 1, 12, new Point(o.x * 8, ((o.y) * 8) + 8), StringFormat.GenericDefault);
                        Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
                        g.DrawPath(pen, gpath);
                        SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                        g.FillPath(brush, gpath);

                        return;
                    }
                    if ((o.id & 0xFF00) == 0x1600)
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        GraphicsPath gpath = new GraphicsPath();
                        gpath.AddString("toBG2", new FontFamily("Consolas"), 1, 12, new Point(o.x * 8, ((o.y) * 8) + 8), StringFormat.GenericDefault);
                        Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
                        g.DrawPath(pen, gpath);
                        SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                        g.FillPath(brush, gpath);

                        return;
                    }

                    if ((o as object_door).door_dir == 0)
                    {
                        if ((o as object_door).door_pos >= 12)
                        {
                            int drawPos = 9;
                            if ((o as object_door).door_pos <= 16)
                            {
                                drawPos = 9;
                            }
                            else
                            {
                                drawPos = 14;
                            }
                            o.bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            g.DrawImage(o.bitmap, o.nx * 8, (o.y - drawPos) * 8);
                            o.bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        }
                    }
                    else if ((o as object_door).door_dir == 2)
                    {
                        if ((o as object_door).door_pos >= 12)
                        {
                            int drawPos = 7;
                            if ((o as object_door).door_pos <= 16)
                            {
                                drawPos = 7;
                            }
                            else
                            {
                                drawPos = 13;
                            }
                            o.bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            g.DrawImage(o.bitmap, (o.nx - drawPos) * 8, (o.y) * 8);
                            o.bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        }
                    }

                    g.DrawImage(o.bitmap, o.nx * 8, o.ny * 8);
                }
            }
        }

        //END OF DRAW CODE

    }
}
