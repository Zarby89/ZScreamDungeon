using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
	public partial class Object_Designer : ScreamControl
	{
		public Object_Designer(ZScreamer parent) : base(parent)
		{
			InitializeComponent();
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(ZS.GFXManager.currentgfx16Bitmap, Constants.Rect_0_0_256_1024, 0, 0, 128, 512, GraphicsUnit.Pixel);
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			pictureBox1.Refresh();
		}
	}
}
