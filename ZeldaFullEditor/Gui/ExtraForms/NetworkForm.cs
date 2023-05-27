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
	public partial class NetworkForm : Form
	{
		public NetworkForm()
		{
			InitializeComponent();
		}
		public string ip = "127.0.0.1";
		public string port = "14242";
		private void button1_Click(object sender, EventArgs e)
		{
			this.ip = textBox1.Text;
			this.port = textBox2.Text;
			this.Close();
		}
	}
}
