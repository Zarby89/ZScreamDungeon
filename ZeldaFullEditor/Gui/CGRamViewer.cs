using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ZeldaFullEditor.Gui
{
    public partial class CGRamViewer : PictureBox
    {
        public CGRamViewer()
        {
            InitializeComponent();
            this.Paint += CGRamViewer_Paint;
            this.MouseDown += CGRamViewer_MouseDown;
        }

        private void CGRamViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip cm = new ContextMenuStrip();
                cm.Items.Add("Export Palettes as .pal");
                cm.Items[0].Click += CGRamViewer_Click;
                cm.Show(MousePosition);
            }
        }

        private void CGRamViewer_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = ".pal";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sf.FileName, FileMode.Create, FileAccess.Write);
                ColorPalette cp = GFX.roomBg1Bitmap.Palette;

                foreach (Color c in cp.Entries)
                {
                    fs.WriteByte(c.R);
                    fs.WriteByte(c.G);
                    fs.WriteByte(c.B);
                }

                fs.Close();
            }
        }

        private void CGRamViewer_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 256; i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(GFX.roomBg1Bitmap.Palette.Entries[i]), new Rectangle(((i % 16) * 16), (i / 16) * 16, 16, 16));
            }
        }
    }
}
