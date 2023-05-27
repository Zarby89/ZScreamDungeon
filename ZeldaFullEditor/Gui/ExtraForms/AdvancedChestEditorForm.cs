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
	public partial class AdvancedChestEditorForm : Form
	{
		int prevSelected = -1;
		ChestAdvancedData[] chestsdata = new ChestAdvancedData[76];

		public AdvancedChestEditorForm()
		{
			InitializeComponent();
		}


		private void AdvancedChestEditorForm_Load_1(object sender, EventArgs e)
		{
			for (int i = 0; i < 76; i++)
			{
				listBox1.Items.Add(ChestItems_Name.name[i]);

				chestsdata[i] = new ChestAdvancedData
				(
					 ROM.DATA[Constants.chests_backupitems + i],
					 ROM.DATA[Constants.chests_yoffset + i],
					 ROM.DATA[Constants.chests_xoffset + i],
					 ROM.DATA[Constants.chests_itemsgfx + i],
					 ROM.DATA[Constants.chests_itemswide + i],
					 ROM.DATA[Constants.chests_itemsproperties + i],
					 (ushort) ((ROM.DATA[Constants.chests_sramaddress + (i * 2) + 1] << 8) + ROM.DATA[Constants.chests_sramaddress + (i * 2)]),
					 ROM.DATA[Constants.chests_sramvalue + i],
					 (short) ((ROM.DATA[Constants.chests_msgid + (i * 2) + 1] << 8) + ROM.DATA[Constants.chests_msgid + (i * 2)])
				);
			}

			listBox1.SelectedIndex = 0;
		}

		private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			if (prevSelected != -1)
			{

				chestsdata[prevSelected].backupitems = (byte) alternateHexbox.HexValue;
				chestsdata[prevSelected].xoffset = (byte) xHexbox.HexValue;
				chestsdata[prevSelected].yoffset = (byte) yHexbox.HexValue;
				chestsdata[prevSelected].sramaddress = (ushort) addressHexbox.HexValue;
				chestsdata[prevSelected].sramvalue = (byte) valueHexbox.HexValue;
				chestsdata[prevSelected].itemswide = (byte) widthHexbox.HexValue;
				chestsdata[prevSelected].msgid = (short) messageHexbox.HexValue;
				chestsdata[prevSelected].itemsproperties = (byte) paletteHexbox.HexValue;
				chestsdata[prevSelected].itemsgfx = (byte) gfxHexbox.HexValue;
			}



			alternateHexbox.HexValue = chestsdata[listBox1.SelectedIndex].backupitems;
			xHexbox.HexValue = chestsdata[listBox1.SelectedIndex].xoffset;
			yHexbox.HexValue = chestsdata[listBox1.SelectedIndex].yoffset;
			addressHexbox.HexValue = chestsdata[listBox1.SelectedIndex].sramaddress;
			valueHexbox.HexValue = chestsdata[listBox1.SelectedIndex].sramvalue;
			widthHexbox.HexValue = chestsdata[listBox1.SelectedIndex].itemswide;
			messageHexbox.HexValue = chestsdata[listBox1.SelectedIndex].msgid;
			paletteHexbox.HexValue = chestsdata[listBox1.SelectedIndex].itemsproperties;
			gfxHexbox.HexValue = chestsdata[listBox1.SelectedIndex].itemsgfx;

			prevSelected = listBox1.SelectedIndex;
		}

		private void button1_Click_1(object sender, EventArgs e)
		{

			if (prevSelected != -1)
			{

				chestsdata[prevSelected].backupitems = (byte) alternateHexbox.HexValue;
				chestsdata[prevSelected].xoffset = (byte) xHexbox.HexValue;
				chestsdata[prevSelected].yoffset = (byte) yHexbox.HexValue;
				chestsdata[prevSelected].sramaddress = (ushort) addressHexbox.HexValue;
				chestsdata[prevSelected].sramvalue = (byte) valueHexbox.HexValue;
				chestsdata[prevSelected].itemswide = (byte) widthHexbox.HexValue;
				chestsdata[prevSelected].msgid = (short) messageHexbox.HexValue;
				chestsdata[prevSelected].itemsproperties = (byte) paletteHexbox.HexValue;
				chestsdata[prevSelected].itemsgfx = (byte) gfxHexbox.HexValue;
			}


			for (int i = 0; i < 76; i++)
			{
				ROM.Write(Constants.chests_backupitems + i, chestsdata[i].backupitems, WriteType.ChestData);
				ROM.Write(Constants.chests_yoffset + i, (chestsdata[i].yoffset), WriteType.ChestData);
				ROM.Write(Constants.chests_xoffset + i, (chestsdata[i].xoffset), WriteType.ChestData);
				ROM.Write(Constants.chests_itemsgfx + i, chestsdata[i].itemsgfx, WriteType.ChestData);
				ROM.Write(Constants.chests_itemswide + i, chestsdata[i].itemswide, WriteType.ChestData);
				ROM.Write(Constants.chests_itemsproperties + i, chestsdata[i].itemsproperties, WriteType.ChestData);
				ROM.WriteShort(Constants.chests_sramaddress + (i * 2), chestsdata[i].sramaddress, WriteType.ChestData);
				ROM.Write(Constants.chests_sramvalue + i, chestsdata[i].sramvalue, WriteType.ChestData);
				ROM.WriteShort(Constants.chests_msgid + (i * 2), (ushort) (chestsdata[i].msgid), WriteType.ChestData);
			}

			this.Close();
		}

		private void button2_Click_1(object sender, EventArgs e)
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
		public short msgid = 0;

		public ChestAdvancedData(byte b, byte y, byte x, byte gfx, byte wide, byte p, ushort addr, byte v, short msgid)
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
