namespace ZeldaFullEditor.UserInterface.PrimaryEditors;

public partial class GraphicsManagerForm : UserControl
{
	public GraphicsManagerForm()
	{
		InitializeComponent();
	}

	// TODO:
	// Draw every sheet with spacing between each sheet
	// Draw sheet ID in hex next to left of the sheet

	private GraphicsSheetEntry selectedSheet = null;

	private readonly GraphicsSheetEntry[] sheets = new GraphicsSheetEntry[0xDF];
	public void OnProjectLoad()
	{
		var gfx = ZScreamer.ActiveGraphicsManager;
		SheetsPanel.Controls.Clear();

		byte i = 0;
		foreach (var s in gfx.AllSheets)
		{
			GraphicsSheetEntry add = new(i, s);
			SheetsPanel.Controls.Add(add);
			SheetsPanel.Controls.SetChildIndex(add, 0);
			sheets[i] = add;
			add.Dock = DockStyle.Top;
			add.MouseClick += new(OnSheetClick);
			add.Visible = true;
			i++;
		}

		SheetsPanel.Refresh();
		Refresh();
	}


	private void OnSheetClick(object sender, MouseEventArgs e)
	{
		if (selectedSheet is not null && selectedSheet != sender)
		{
			selectedSheet.Selected = false;
		}

		selectedSheet = (GraphicsSheetEntry) sender;
		selectedSheet.Selected = true;
		BigPreviewPane.Refresh();
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
		if (selectedSheet is null)
		{
			return;
		}

		e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		e.Graphics.SmoothingMode = SmoothingMode.None;
		e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
		e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
		e.Graphics.DrawImage(selectedSheet.Sheet.Bitmap, Constants.GraphicsSheet4X, 0, 0, 128, 32, GraphicsUnit.Pixel);
	}
}
