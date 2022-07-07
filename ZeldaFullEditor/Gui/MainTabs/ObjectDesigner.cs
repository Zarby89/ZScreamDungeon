namespace ZeldaFullEditor.Gui;

public partial class Object_Designer : UserControl
{
	public Object_Designer()
	{
		InitializeComponent();
	}

	private void pictureBox1_Paint(object sender, PaintEventArgs e)
	{
		e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.currentgfx16Bitmap, Constants.Rect_0_0_256_1024, 0, 0, 128, 512, GraphicsUnit.Pixel);
	}

	private void radioButton1_CheckedChanged(object sender, EventArgs e)
	{
		pictureBox1.Refresh();
	}
}
