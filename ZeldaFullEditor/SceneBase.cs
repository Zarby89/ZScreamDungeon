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
    public class Scene : PictureBox
    {
        public bool active = false;
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
        public Rectangle[] doorArray = new Rectangle[48];
        public Room room;
        public ObjectMode selectedMode;
        
        public bool showLayer1 = true;
        public bool showLayer2 = true;
        public bool showGrid = false;
        public bool showSpriteText = false;
        public Form1 mainForm;
        public bool canSelectUnselectedBG = true;
        public bool isDungeon = true;
        //public List<Room> undoRooms = new List<Room>();
        //public List<Room> redoRooms = new List<Room>();
        //public PickObject pObj = new PickObject();
        public dataObject selectedDragObject = null;
        public dataObject selectedDragSprite = null;
        public bool updating_info = false;


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

        public void drawSelection(Graphics graphics)
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
                    graphics.DrawRectangle(Pens.Green, new Rectangle(((o as Room_Object).nx) * 8, ((o as Room_Object).ny) * 8, (o as Room_Object).width, (o as Room_Object).height));
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
                        graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(((o as Room_Object).nx) * 8, ((o as Room_Object).ny) * 8, (o as Room_Object).width, (o as Room_Object).height));
                    }
                }
            }
        }

        public void drawEntrancePosition()
        {

        }

        public void drawDoorsPosition()
        {
            /*if (mouse_down)
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
            }*/
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        //END OF DRAW CODE

    }
}
