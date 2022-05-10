﻿namespace ZeldaFullEditor.Gui
{
	public partial class VramViewer : Panel
	{
		public PictureBox vramBox = new();
		public VramViewer()
		{
			InitializeComponent();
			this.AutoScroll = true;
			this.Size = new Size(274, 512);
			vramBox.Location = new Point(0, 0);
			vramBox.Size = new Size(256, 1024);
			vramBox.Paint += VramBox_Paint;
			this.Controls.Add(vramBox);
		}

		private void VramBox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			using Bitmap tempBitmap = (Bitmap) ZScreamer.ActiveGraphicsManager.currentgfx16Bitmap.Clone();
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
