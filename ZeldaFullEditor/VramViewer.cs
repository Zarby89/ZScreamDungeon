using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    public partial class VramViewer : Form
    {
        public VramViewer()
        {
            InitializeComponent();
            
        }

        private void vramPicturebox_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            using (Bitmap tempBitmap = (Bitmap)GFX.currentgfx16Bitmap.Clone())
            {
                ColorPalette cp = tempBitmap.Palette;
                for (int i = 0; i < 16; i++)
                {
                    cp.Entries[i] = Color.FromArgb(i * 15, i * 15, i * 15);
                }
                tempBitmap.Palette = cp;
                e.Graphics.DrawImage(tempBitmap, new Rectangle(0, 0, 256, 1024), 0, 0, 128, 512, GraphicsUnit.Pixel);

            }
        }
    }
}
