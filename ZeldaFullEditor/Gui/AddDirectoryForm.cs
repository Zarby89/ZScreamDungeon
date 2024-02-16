using System;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
	public partial class AddDirectoryForm : Form
	{

		public string DirName = "";
		public AddDirectoryForm()
		{
			InitializeComponent();
		}

		private void AcceptButton_Click(object sender, EventArgs e)
		{
			DirName = directoryTextbox.Text;
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
