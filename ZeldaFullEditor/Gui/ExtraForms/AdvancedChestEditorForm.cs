using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace ZeldaFullEditor.Gui
{
	public partial class AdvancedChestEditorForm : ScreamForm
	{
		bool changedFromForm = false;
		ChestAdvancedData[] chestsdata = new ChestAdvancedData[76];

		public AdvancedChestEditorForm(ZScreamer parent) : base(parent)
		{
			InitializeComponent();
		}

		private void AdvancedChestEditorForm_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < 76; i++)
			{
				listBox1.Items.Add(ChestItems_Name.name[i]);

				chestsdata[i] = new ChestAdvancedData
				(
					ZS.ROM[Constants.chests_backupitems + i],
					ZS.ROM[Constants.chests_yoffset + i],
					ZS.ROM[Constants.chests_xoffset + i],
					ZS.ROM[Constants.chests_itemsgfx + i],
					ZS.ROM[Constants.chests_itemswide + i],
					ZS.ROM[Constants.chests_itemsproperties + i],
					ZS.ROM[Constants.chests_sramaddress + (i * 2), 2],
					ZS.ROM[Constants.chests_sramvalue + i],
					ZS.ROM[Constants.chests_msgid + (i * 2), 2]
				);
			}

			listBox1.SelectedIndex = 0;
		}

		private void alternateTextbox_TextChanged(object sender, EventArgs e)
		{
			// TODO hexbox
			if (!changedFromForm)
			{
				if (int.TryParse(alternateTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out int r))
				{
					chestsdata[listBox1.SelectedIndex].backupitems = (byte) r;
				}
				if (int.TryParse(xoffsetTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
				{
					chestsdata[listBox1.SelectedIndex].xoffset = (byte) r;
				}
				if (int.TryParse(yoffsetTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
				{
					chestsdata[listBox1.SelectedIndex].yoffset = (byte) r;
				}
				if (int.TryParse(sramaddrTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
				{
					chestsdata[listBox1.SelectedIndex].sramaddress = (ushort) r;
				}
				if (int.TryParse(sramvalueTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
				{
					chestsdata[listBox1.SelectedIndex].sramvalue = (byte) r;
				}
				if (int.TryParse(wideflagTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
				{
					chestsdata[listBox1.SelectedIndex].itemswide = (byte) r;
				}
				if (int.TryParse(msgidTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
				{
					chestsdata[listBox1.SelectedIndex].msgid = (ushort) r;
				}
			}

			if (chestsdata[listBox1.SelectedIndex].backupitems >= 76)
			{
				if (chestsdata[listBox1.SelectedIndex].backupitems != 255)
				{
					chestsdata[listBox1.SelectedIndex].backupitems = 75;
				}

				label8.Text = "Same as the current item";
			}
			else
			{
				label8.Text = ChestItems_Name.name[chestsdata[listBox1.SelectedIndex].backupitems];
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			changedFromForm = true;
			alternateTextbox.Text = chestsdata[listBox1.SelectedIndex].backupitems.ToString();
			xoffsetTextbox.Text = chestsdata[listBox1.SelectedIndex].xoffset.ToString("X2");
			yoffsetTextbox.Text = chestsdata[listBox1.SelectedIndex].yoffset.ToString("X2");
			sramaddrTextbox.Text = chestsdata[listBox1.SelectedIndex].sramaddress.ToString("X4");
			sramvalueTextbox.Text = chestsdata[listBox1.SelectedIndex].sramvalue.ToString("X2");
			wideflagTextbox.Text = chestsdata[listBox1.SelectedIndex].itemswide.ToString("X2");
			msgidTextbox.Text = chestsdata[listBox1.SelectedIndex].msgid.ToString("X4");
			changedFromForm = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 76; i++)
			{
				ZS.ROM[Constants.chests_backupitems + i] = chestsdata[i].backupitems;
				ZS.ROM[Constants.chests_yoffset + i] = chestsdata[i].yoffset;
				ZS.ROM[Constants.chests_xoffset + i] = chestsdata[i].xoffset;
				ZS.ROM[Constants.chests_itemsgfx + i] = chestsdata[i].itemsgfx;
				ZS.ROM[Constants.chests_itemswide + i] = chestsdata[i].itemswide;
				ZS.ROM[Constants.chests_itemsproperties + i] = chestsdata[i].itemsproperties;
				ZS.ROM[Constants.chests_sramaddress + (i * 2), 2] = chestsdata[i].sramaddress;
				ZS.ROM[Constants.chests_sramvalue + i] = chestsdata[i].sramvalue;
				ZS.ROM[Constants.chests_msgid + (i * 2), 2] = chestsdata[i].msgid;
			}

			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}

	public class ChestAdvancedData
	{
		public byte backupitems = 0;
		public byte yoffset = 0;
		public byte xoffset = 0;
		public byte itemsgfx = 0;
		public byte itemswide = 0;
		public byte itemsproperties = 0;
		public ushort sramaddress = 0;
		public byte sramvalue = 0;
		public ushort msgid = 0;

		public ChestAdvancedData(byte b, byte y, byte x, byte gfx, byte wide, byte p, ushort addr, byte v, ushort msgid)
		{
			this.backupitems = b;
			this.yoffset = y;
			this.xoffset = x;
			this.itemsgfx = gfx;
			this.itemswide = wide;
			this.itemsproperties = p;
			this.sramaddress = addr;
			this.sramvalue = v;
			this.msgid = msgid;
		}
	}
}
