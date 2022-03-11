using System;
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
    public partial class SpritesView : UserControl
    {
        public List<Sprite> items = new List<Sprite>();
        ColorPalette palettes = null;

        public int selectedIndex = -1;
        public event EventHandler SelectedIndexChanged;

        public Sprite selectedObject = null;

        public SpritesView()
        {
            InitializeComponent();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(48,48,48));
            int w = (this.Size.Width / 68);
            int h = (((items.Count / w) + 1) * 68);
            int xpos = 0;
            int ypos = 0;

            foreach (Sprite o in items)
            {
                unsafe
                {
                    byte* ptr = (byte*)GFX.previewSpritesPtr[o.id].ToPointer();
                    for (int i = 0; i < (64 * 64); i++)
                    {
                        ptr[i] = 0;
                    }
                }

                o.Draw();

                e.Graphics.DrawImage(GFX.previewSpritesBitmap[o.id], new Point((xpos * 64)+(xpos*4), (ypos * 64)+(ypos * 4)));

                if (selectedObject == o)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 0, 0, 255)), new Rectangle(xpos * 64 + (xpos * 4), (ypos * 64) + (ypos * 4), 64, 64));
                }

                e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(xpos * 64 + (xpos * 4), ypos * 64 + (ypos * 4), 64, 64));
                if (o.subtype == 0)
                {
                    e.Graphics.DrawString(Sprites_Names.name[o.id], new Font("Arial",7), Brushes.White, new Rectangle(xpos * 64 + (xpos * 4), (ypos * 64) + (ypos * 4) + 40, 64, 24));
                    //e.Graphics.DrawString(Sprites_Names.name[o.id].Substring(0, 2), this.Font, Brushes.White, new Rectangle(xpos * 64 + (xpos * 4), (ypos * 64) + (ypos * 4), 64, 24));

                }
                else
                {
                    e.Graphics.DrawString((o.id-1).ToString("X2"), this.Font, Brushes.White, new Rectangle(xpos * 64 + (xpos * 4), (ypos * 64) + (ypos * 4), 64, 24));
                    e.Graphics.DrawString(Sprites_Names.overlordnames[o.id-1], new Font("Arial", 7), Brushes.White, new Rectangle(xpos * 64 + (xpos * 4), (ypos * 64) + 40 + (ypos * 4), 64, 24));
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
                palettes = GFX.previewSpritesBitmap[items[0].id].Palette;

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

                foreach (Sprite o in items)
                {
                    if (palettes != null)
                    {
                        GFX.previewSpritesBitmap[o.id].Palette = palettes;
                    }
                }
            }

            this.Refresh();
        }

        private void ObjectViewer_Load(object sender, EventArgs e)
        {
            // TODO: Add something here?
        }
        
        private void ObjectViewer_MouseClick(object sender, MouseEventArgs e)
        {
            int w = (this.Size.Width / 64);
            int h = (((items.Count / w) + 1) * 64);
            int xpos = 0;
            int ypos = 0;
            int index = 0;
            this.Size = new Size(this.Size.Width, h);

            foreach (Sprite o in items)
            {
                if (index < items.Count)
                {
                    Rectangle itemRect = new Rectangle(xpos * 64 + (xpos * 4), ypos * 64 + (ypos * 4), 64, 64);
                    if (itemRect.Contains(new Point(e.X, e.Y)))
                    {
                        selectedIndex = index;
                        selectedObject = o;
                        OnValueChanged(new EventArgs());
                    }

                    xpos++;
                    if (xpos >= w)
                    {
                        xpos = 0;
                        ypos++;
                    }

                    index++;
                }
            }
            
            Refresh();
        }

        private void SpritesView_Load(object sender, EventArgs e)
        {
            // TODO: Add something here?
        }
    }
}
