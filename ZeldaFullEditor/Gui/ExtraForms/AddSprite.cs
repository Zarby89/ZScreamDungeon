using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
	public partial class AddSprite : ScreamForm
	{
		public AddSprite(ZScreamer zs) : base(zs)
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
			spriteListBox.DataSource = DefaultEntities.ListOfSprites;
			spriteListBox.SelectedIndex = 0;
		}
	}
}
