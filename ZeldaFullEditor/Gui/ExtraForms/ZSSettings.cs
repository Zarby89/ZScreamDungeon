using System;
using System.IO;
using System.Windows.Forms;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.Gui.ExtraForms
{
	public partial class ZSSettings : Form
	{
		public ZSSettings()
		{
			InitializeComponent();
		}

		private void ZSSettings_Load(object sender, EventArgs e)
		{
			emulatorpathTextbox.Text = Settings.Default.emulatorPath;
		}

		private void emulatorpathTextbox_TextChanged(object sender, EventArgs e)
		{

		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (Settings.Default.emulatorPath != "")
			{
				if (File.Exists(emulatorpathTextbox.Text))
				{
					Settings.Default.emulatorPath = emulatorpathTextbox.Text;
				}
				else
				{
					MessageBox.Show("Emulator cannot be found");
				}
			}
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void emulatorPathButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog of = new OpenFileDialog())
			{
				of.Filter = "Snes emulator .exe (*.exe)|*.exe";
				of.DefaultExt = "exe";
				if (of.ShowDialog() == DialogResult.OK)
				{
					emulatorpathTextbox.Text = of.FileName;
				}
			}
		}

	}
}
