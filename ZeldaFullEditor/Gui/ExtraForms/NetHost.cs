using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
