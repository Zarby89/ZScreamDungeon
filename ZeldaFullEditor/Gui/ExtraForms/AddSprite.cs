namespace ZeldaFullEditor.Gui;

public partial class AddSprite : Form
{
	public AddSprite()
	{
		InitializeComponent();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AddSprite_Load(object sender, EventArgs e)
	{
		spriteListBox.DataSource = SpriteName.ListOfSprites;
		spriteListBox.SelectedIndex = 0;
	}
}
