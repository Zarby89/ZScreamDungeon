namespace ZeldaFullEditor.UserInterface.GeneralControls;

public partial class GraphicsSheetEntry : UserControl
{
	[Browsable(false)]
	public GraphicsSheet Sheet { get; set; } = null;

	[Browsable(false)]
	public byte ID { get; init; }

	private bool _selected = false;
	[Browsable(false)]
	public bool Selected {
		get => _selected;
		set
		{
			if (_selected == value) return;
			_selected = value;
			BackColor = _selected ? Color.DeepSkyBlue : Color.Transparent;
		}
	}

	public GraphicsSheetEntry()
	{
		InitializeComponent();
	}

	public GraphicsSheetEntry(byte id, GraphicsSheet sheet)
	{
		ID = id;
		Sheet = sheet;
		InitializeComponent();
		IDLabel.Text = $"{ID:X2}";
	}

	private void SheetPreview_Paint(object sender, PaintEventArgs e)
	{
		e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		e.Graphics.SmoothingMode = SmoothingMode.None;
		e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
		e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
		e.Graphics.DrawImage(Sheet.Bitmap, Constants.GraphicsSheet2X, 0, 0, 128, 32, GraphicsUnit.Pixel);
	}

	private void AllMouseClick(object sender, MouseEventArgs e)
	{
		OnMouseClick(e);
	}
}
