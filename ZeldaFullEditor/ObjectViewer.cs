﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ZeldaFullEditor
{
    public partial class ObjectViewer : UserControl
    {
        public ObjectViewer()
        {
            InitializeComponent();
        }
        public List<Room_Object> items = new List<Room_Object>();
        private void ObjectViewer_Paint(object sender, PaintEventArgs e)
        {

        }
        ColorPalette palettes = null;
        public bool showName = false;
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            int w = (this.Size.Width / 64);
            int h = (((items.Count / w) + 1) * 64);
            int xpos = 0;
            int ypos = 0;



            foreach (Room_Object o in items)
            {

                

                e.Graphics.DrawImage(GFX.previewObjectsBitmap[o.previewId], new Point(xpos * 64, ypos * 64));
                
                if (selectedObject == o)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 0, 0, 255)), new Rectangle(xpos * 64, (ypos * 64), 64, 64));
                }
                e.Graphics.DrawRectangle(Pens.DarkGray, new Rectangle(xpos * 64, ypos * 64, 64, 64));
                if (showName == false)
                {
                    e.Graphics.DrawString(o.id.ToString("X3"), this.Font, Brushes.White, new Rectangle(xpos * 64, (ypos * 64) + 48, 64, 64));
                }
                else
                {
                    e.Graphics.DrawString(o.id.ToString("X3") + o.name.ToString(), this.Font, Brushes.White, new Rectangle(xpos * 64, (ypos * 64) + 24, 64, 40));
                }
                xpos++;
                if (xpos >= w)
                {
                    xpos = 0;
                    ypos++;
                    
                }
                
            }
            
            base.OnPaint(e);
        }
        public int selectedIndex = -1;
        public event EventHandler SelectedIndexChanged;

        protected virtual void OnValueChanged(EventArgs e)
        {
            SelectedIndexChanged?.Invoke(this, e);
        }

        public override void Refresh()
        {

            base.Refresh();
        }

        private void ObjectViewer_SizeChanged(object sender, EventArgs e)
        {


            Refresh();
        }

        public void updateSize()
        {
            int w = (this.Size.Width / 64);
            int h = (((items.Count / w) + 1) * 64);
            this.Size = new Size(this.Size.Width, h);

            if (items.Count > 0)
            {
                palettes = GFX.previewObjectsBitmap[items[0].previewId].Palette;

                int pindex = 0;
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
            }

            foreach (Room_Object o in items)
            {
                o.size = 5;
                unsafe
                {
                    byte* ptr = (byte*)GFX.previewObjectsPtr[o.previewId].ToPointer();
                    for (int i = 0; i < (64 * 64); i++)
                    {
                        ptr[i] = 0;
                    }
                }
                o.Draw();
                if (palettes != null)
                {
                    GFX.previewObjectsBitmap[o.previewId].Palette = palettes;
                }
            }
        }

        private void ObjectViewer_Load(object sender, EventArgs e)
        {

        }

        public Room_Object selectedObject = null;
        private void ObjectViewer_MouseClick(object sender, MouseEventArgs e)
        {
            int w = (this.Size.Width / 64);
            int h = (((items.Count / w)+1) * 64);
            int xpos = 0;
            int ypos = 0;
            int index = 0;
            this.Size = new Size(this.Size.Width, h);
            foreach (Room_Object o in items)
            {
                Rectangle itemRect = new Rectangle(xpos * 64, ypos * 64, 64, 64);
                if (itemRect.Contains(new Point(e.X,e.Y)))
                {
                    selectedIndex = index;
                    selectedObject = o;
                }
                xpos++;
                if (xpos >= w)
                {
                    xpos = 0;
                    ypos++;

                }
                index++;
            }
            OnValueChanged(new EventArgs());
            Refresh();
        }
    }
}
