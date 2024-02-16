using System;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui.ExtraForms
{
	public partial class NetHost : Form
	{
		public string port;
		public NetHost()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			port = portBox.Text;
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
