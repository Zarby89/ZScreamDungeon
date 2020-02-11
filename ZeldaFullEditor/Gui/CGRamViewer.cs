using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
    public partial class CGRamViewer : Form
    {
        public CGRamViewer()
        {
            InitializeComponent();
        }

        private void cgramPicturebox_Paint(object sender, PaintEventArgs e)
        {
            for(int i = 0;i<256;i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(GFX.roomBg1Bitmap.Palette.Entries[i]), new Rectangle(((i%16) * 16),(i/16)*16,16,16));
            }
        }
    }
}
