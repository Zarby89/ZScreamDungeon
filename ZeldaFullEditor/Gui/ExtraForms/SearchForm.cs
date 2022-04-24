using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor.Gui
{
	public partial class SearchForm : ScreamForm
	{

		public SearchForm(ZScreamer zs) : base(zs)
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			richTextBox1.Clear();
		}

		private void tileRadio_CheckedChanged(object sender, EventArgs e)
		{
			comboBox1.Items.Clear();
			if (tileRadio.Checked)
			{
				var list = new List<RoomObjectName>();
				list.Concat(DefaultEntities.ListOfSet0RoomObjects);
				list.Concat(DefaultEntities.ListOfSet1RoomObjects);
				list.Concat(DefaultEntities.ListOfSet2RoomObjects);
				comboBox1.DataSource = list;
			}
			else if (spriteRadio.Checked)
			{
				comboBox1.DataSource = DefaultEntities.ListOfSprites;
			}
			else if (itemRadio.Checked)
			{
				comboBox1.DataSource = DefaultEntities.ListOfSecrets;
			}
			else if (chestRadio.Checked)
			{
				comboBox1.DataSource = DefaultEntities.ListOfItemReceipts;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var v = comboBox1.SelectedItem as EntityName;

			var f = new Func<ITypeID, bool>(o => o.TypeID == v.ID);

			if (tileRadio.Checked)
			{
				foreach (var r in ZS.all_rooms)
				{
					int l = r.Layer1Objects.Where(f).ToArray().Length;
					l += r.Layer2Objects.Where(f).ToArray().Length;
					l += r.Layer3Objects.Where(f).ToArray().Length;
					if (l > 0)
					{
						richTextBox1.AppendText($"Found in room {r.RoomID:X3} : {l} x object {v.ID:X3}\r\n");
					}
				}
			}
			else if (spriteRadio.Checked)
			{
				foreach (var r in ZS.all_rooms)
				{
					int l = r.SpritesList.Where(f).ToArray().Length;
					if (l > 0)
					{
						richTextBox1.AppendText($"Found in room {r.RoomID:X4} : {l} x sprite {v.ID:X2}\r\n");
					}
				}
			}
			else if (itemRadio.Checked)
			{
				foreach (var r in ZS.all_rooms)
				{
					int l = r.SecretsList.Where(f).ToArray().Length;
					if (l > 0)
					{
						richTextBox1.AppendText($"Found in room {r.RoomID:X4} : {l} x secret {v.ID:X2}\r\n");
					}
				}
			}
			else if (chestRadio.Checked)
			{
				foreach (var r in ZS.all_rooms)
				{
					int l = r.ChestList.Where(f).ToArray().Length;
					if (l > 0)
					{
						richTextBox1.AppendText($"Found in room {r.RoomID:X4} : {l} x item receipt {v.ID:X2}\r\n");
					}
				}
			}
		}
	}
}
