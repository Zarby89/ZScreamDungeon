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

namespace ZeldaFullEditor.Gui
{
	public partial class VramViewer : Panel
	{
		public PictureBox vramBox = new PictureBox();

		private readonly ZScreamer ZS;
		public VramViewer(ZScreamer zs)
		{
			InitializeComponent();
			ZS = zs;
			this.AutoScroll = true;
			this.Size = new Size(274, 512);
			vramBox.Location = new Point(0, 0);
			vramBox.Size = new Size(256, 1024);
			vramBox.Paint += VramBox_Paint;
			this.Controls.Add(vramBox);
		}

		private void VramBox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			using (Bitmap tempBitmap = (Bitmap) ZS.GFXManager.currentgfx16Bitmap.Clone())
			{
				ColorPalette cp = tempBitmap.Palette;
				for (int i = 0, j = 0; i < 16; i++, j += 15)
				{
					cp.Entries[i] = Color.FromArgb(j, j, j);
				}

				tempBitmap.Palette = cp;
				e.Graphics.DrawImage(tempBitmap, Constants.Rect_0_0_256_1024, 0, 0, 128, 512, GraphicsUnit.Pixel);
			}
		}
	}
}
