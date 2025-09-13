using System;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
    public partial class DungeonPropertiesForm : Form
    {
        DungeonProperty[] properties = new DungeonProperty[12];

        bool changedFromForm = false;

        public DungeonPropertiesForm()
        {
            InitializeComponent();
        }

        // TODO move elsewhere for consistency
        private void DungeonPropertiesForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Pendant 1 - Green (Eastern)");
            listBox1.Items.Add("Pendant 2 - Blue (Desert)");
            listBox1.Items.Add("Pendant 3 - Red (Hera)");
            listBox1.Items.Add("Agahnim 1");
            listBox1.Items.Add("Crystal 2 (Swamp)");
            listBox1.Items.Add("Crystal 1 (Darkness)");
            listBox1.Items.Add("Crystal 3 (Skull)");
            listBox1.Items.Add("Crystal 6 (Mire)");
            listBox1.Items.Add("Crystal 5 (Ice)");
            listBox1.Items.Add("Crystal 7 (Turtle)");
            listBox1.Items.Add("Crystal 4 (Thieves)");
            listBox1.Items.Add("Agahnim 2");

            for (int i = 0; i < properties.Length; i++)
            {
                properties[i] = new DungeonProperty
                (
                    ROM.DATA[Constants.dungeons_startrooms + i],
                    ROM.DATA[Constants.dungeons_endrooms + i],
                    (short)((ROM.DATA[Constants.dungeons_bossrooms + (i * 2) + 1] << 8) + ROM.DATA[Constants.dungeons_bossrooms + (i * 2)])
                );
            }

            listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedFromForm = true;
            startroomTextbox.HexValue = properties[listBox1.SelectedIndex].startroom;
            endroomTextbox.HexValue = properties[listBox1.SelectedIndex].endroom;
            bossroomTextbox.HexValue = properties[listBox1.SelectedIndex].bossroom;
            startroomTextbox.Text = properties[listBox1.SelectedIndex].startroom.ToString("X3");
            endroomTextbox.Text = properties[listBox1.SelectedIndex].endroom.ToString("X3");
            bossroomTextbox.Text = properties[listBox1.SelectedIndex].bossroom.ToString("X3");
            changedFromForm = false;
        }

        private void bossroomTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!changedFromForm)
            {
                properties[listBox1.SelectedIndex].startroom = (byte)startroomTextbox.HexValue;
                properties[listBox1.SelectedIndex].endroom = (byte)endroomTextbox.HexValue;
                properties[listBox1.SelectedIndex].bossroom = (short)bossroomTextbox.HexValue;
            }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                ROM.Write(Constants.dungeons_startrooms + i, properties[i].startroom, WriteType.DungeonPrize);
                ROM.Write(Constants.dungeons_endrooms + i, properties[i].endroom, WriteType.DungeonPrize);
                ROM.WriteShort(Constants.dungeons_bossrooms + (i * 2), properties[i].bossroom, WriteType.DungeonPrize);
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class DungeonProperty
    {
        public byte startroom = 0;
        public byte endroom = 0;
        public short bossroom = 0;

        public DungeonProperty(byte startroom, byte endroom, short bossroom)
        {
            this.startroom = startroom;
            this.endroom = endroom;
            this.bossroom = bossroom;
        }
    }
}
