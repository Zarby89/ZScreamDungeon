namespace ZeldaFullEditor;

partial class AboutBox1 : Form
{
	public AboutBox1()
	{
		InitializeComponent();
		AboutVersion.Text = $"Version: {UIText.VERSION}";
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(UIText.GITHUB);
	}

	private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(UIText.DISCORD);
	}
}
