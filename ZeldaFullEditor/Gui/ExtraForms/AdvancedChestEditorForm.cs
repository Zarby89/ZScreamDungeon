namespace ZeldaFullEditor.Gui
{
	public partial class AdvancedChestEditorForm : Form
	{
		bool changedFromForm = false;
		ChestAdvancedData[] chestsdata = new ChestAdvancedData[76];

		public AdvancedChestEditorForm()
		{
			InitializeComponent();
		}

		private void AdvancedChestEditorForm_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < 76; i++)
			{
				listBox1.Items.Add(DefaultEntities.ListOfItemReceipts[i].Name);

				chestsdata[i] = new ChestAdvancedData
				(
					ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_backupitems + i],
					ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_yoffset + i],
					ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_xoffset + i],
					ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_itemsgfx + i],
					ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_itemswide + i],
					ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_itemsproperties + i],
					ZScreamer.ActiveROM.Read16(ZScreamer.ActiveOffsets.chests_sramaddress + (i * 2)),
					ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_sramvalue + i],
					ZScreamer.ActiveROM.Read16(ZScreamer.ActiveOffsets.chests_msgid + (i * 2))
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
				label8.Text = DefaultEntities.ListOfItemReceipts[chestsdata[listBox1.SelectedIndex].backupitems].Name;
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
				ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_backupitems + i] = chestsdata[i].backupitems;
				ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_yoffset + i] = chestsdata[i].yoffset;
				ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_xoffset + i] = chestsdata[i].xoffset;
				ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_itemsgfx + i] = chestsdata[i].itemsgfx;
				ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_itemswide + i] = chestsdata[i].itemswide;
				ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_itemsproperties + i] = chestsdata[i].itemsproperties;
				ZScreamer.ActiveROM.Write16(ZScreamer.ActiveOffsets.chests_sramaddress + (i * 2), chestsdata[i].sramaddress);
				ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.chests_sramvalue + i] = chestsdata[i].sramvalue;
				ZScreamer.ActiveROM.Write16(ZScreamer.ActiveOffsets.chests_msgid + (i * 2), chestsdata[i].msgid);
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
