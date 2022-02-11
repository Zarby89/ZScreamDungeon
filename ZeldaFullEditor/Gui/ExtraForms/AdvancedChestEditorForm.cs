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
        bool changedFromForm = false;
        ChestAdvancedData[] chestsdata = new ChestAdvancedData[76];

        public AdvancedChestEditorForm()
        {
            InitializeComponent();
        }

        private void AdvancedChestEditorForm_Load(object sender, EventArgs e)
        {
            for(int i = 0;i<76;i++)
            {
                listBox1.Items.Add(ChestItems_Name.name[i]);

                chestsdata[i] = new ChestAdvancedData(
                     ROM.DATA[Constants.chests_backupitems + i],
                     ROM.DATA[Constants.chests_yoffset + i],
                     ROM.DATA[Constants.chests_xoffset + i],
                     ROM.DATA[Constants.chests_itemsgfx + i],
                     ROM.DATA[Constants.chests_itemswide + i],
                     ROM.DATA[Constants.chests_itemsproperties + i],
                     (short)((ROM.DATA[Constants.chests_sramaddress + (i * 2) + 1] << 8) + ROM.DATA[Constants.chests_sramaddress + (i * 2)]),
                     ROM.DATA[Constants.chests_sramvalue + i],
                     (short)((ROM.DATA[Constants.chests_msgid + (i * 2) + 1] << 8) + ROM.DATA[Constants.chests_msgid + (i * 2)])
                     );
            }

            listBox1.SelectedIndex = 0;
        }

        private void alternateTextbox_TextChanged(object sender, EventArgs e)
        {
            if (changedFromForm == false)
            {
                int r = 0;

                if (int.TryParse(alternateTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
                {
                    chestsdata[listBox1.SelectedIndex].backupitems = (byte)r;
                }
                if (int.TryParse(xoffsetTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
                {
                    chestsdata[listBox1.SelectedIndex].xoffset = (byte)r;
                }
                if (int.TryParse(yoffsetTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
                {
                    chestsdata[listBox1.SelectedIndex].yoffset = (byte)r;
                }
                if (int.TryParse(sramaddrTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
                {
                    chestsdata[listBox1.SelectedIndex].sramaddress = (short)r;
                }
                if (int.TryParse(sramvalueTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
                {
                    chestsdata[listBox1.SelectedIndex].sramvalue = (byte)r;
                }
                if (int.TryParse(wideflagTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
                {
                    chestsdata[listBox1.SelectedIndex].itemswide = (byte)r;
                }
                if (int.TryParse(msgidTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r))
                {
                    chestsdata[listBox1.SelectedIndex].msgid = (short)r;
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
                ROM.Write(Constants.chests_backupitems + i,chestsdata[i].backupitems, true, "Chests Items Data");
                ROM.Write(Constants.chests_yoffset + i,(chestsdata[i].yoffset), true, "Chests Items Data");
                ROM.Write(Constants.chests_xoffset + i,(chestsdata[i].xoffset), true, "Chests Items Data");
                ROM.Write(Constants.chests_itemsgfx + i,chestsdata[i].itemsgfx, true, "Chests Items Data");
                ROM.Write(Constants.chests_itemswide + i,chestsdata[i].itemswide, true, "Chests Items Data");
                ROM.Write(Constants.chests_itemsproperties + i,chestsdata[i].itemsproperties, true, "Chests Items Data");
                ROM.WriteShort(Constants.chests_sramaddress + (i * 2), chestsdata[i].sramaddress, true, "Chests Items Data");
                ROM.Write(Constants.chests_sramvalue + i,chestsdata[i].sramvalue, true, "Chests Items Data");
                ROM.Write(Constants.chests_msgid + (i * 2)+1,(byte)(chestsdata[i].msgid>>8), true, "Chests Items Data");
                ROM.Write(Constants.chests_msgid + (i * 2),(byte)(chestsdata[i].msgid & 0xFF), true, "Chests Items Data");
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
        public short sramaddress = 0;
        public byte sramvalue = 0;
        public short msgid = 0;

        public ChestAdvancedData(byte b,byte y, byte x, byte gfx,byte wide, byte p, short addr, byte v,short msgid)
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
