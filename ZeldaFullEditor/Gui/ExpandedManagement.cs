namespace ZeldaFullEditor.Gui;

public partial class ExpandedManagement : Form
{
	public ExpandedManagement()
	{
		InitializeComponent();
	}

	private void ExpandedManagement_Load(object sender, EventArgs e)
	{
		dataGridView1.Rows.Add(new object[] { "Title screen tiles data", "108000" });
		dataGridView1.Rows.Add(new object[] { "Dungeon map expanded data", "109010" });
		dataGridView1.Rows.Add(new object[] { "Rooms headers pointers and data", "110000" });
		dataGridView1.Rows.Add(new object[] { "Dungeon rooms object expanded data", "1112C0" });
		dataGridView1.Rows.Add(new object[] { "Overworld overlays data and pointers", "120000" });
		dataGridView1.Rows.Add(new object[] { "Overworld maps expanded data", "130000" });
	}
}
