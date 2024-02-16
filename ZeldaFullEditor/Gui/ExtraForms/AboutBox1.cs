using System;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	partial class AboutBox1 : Form
	{
		// TODO KAN REFACTOR - remove all the hardcoded label text and use an array of strings in this file
		public AboutBox1()
		{
			InitializeComponent();
			this.Text = $"About {UIText.APPNAME}";
			this.AboutVersion.Text = string.Format("Version: {0}", UIText.VERSION);
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(UIText.GITHUB);
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(UIText.DISCORD);
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(UIText.ASAR);
		}

		private void AboutBox1_Load(object sender, EventArgs e)
		{

		}
	}
}
