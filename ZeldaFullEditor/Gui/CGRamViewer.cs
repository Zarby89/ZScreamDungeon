namespace ZeldaFullEditor.Gui
{
	public partial class CGRamViewer : PictureBox
	{
		public CGRamViewer()
		{
			InitializeComponent();
			Paint += CGRamViewer_Paint;
			MouseDown += CGRamViewer_MouseDown;
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
			// TODO UIText
			SaveFileDialog sf = new SaveFileDialog
			{
				DefaultExt = ".pal"
			};

			if (sf.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(sf.FileName, FileMode.Create, FileAccess.Write);
				ColorPalette cp = RoomEditingArtist.Layer1Canvas.Palette;

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
				e.Graphics.FillRectangle(
					new SolidBrush(RoomEditingArtist.Layer1Canvas.Palette.Entries[i]),
					new Rectangle((i % 16) * 16, i & ~0xF, 16, 16));
			}
		}
	}
}
