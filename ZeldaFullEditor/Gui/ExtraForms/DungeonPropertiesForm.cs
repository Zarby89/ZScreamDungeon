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
    public partial class DungeonPropertiesForm : Form
    {
        public DungeonPropertiesForm()
        {
            InitializeComponent();
        }
        DungeonProperty[] properties = new DungeonProperty[12];
        private void DungeonPropertiesForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Pendant 1 - Green (Eastern)");
            listBox1.Items.Add("Pendant 2 - Blue (Desert)");
            listBox1.Items.Add("Pendant 3 - Red (Hera)");
            listBox1.Items.Add("Agahnim 1");
            listBox1.Items.Add("Crystal 2 (Swamp)");
            listBox1.Items.Add("Crystal 1 (Darkness)");
            listBox1.Items.Add("Crystal 3 (Skullswood)");
            listBox1.Items.Add("Crystal 6 (Mire)");
            listBox1.Items.Add("Crystal 5 (Ice)");
            listBox1.Items.Add("Crystal 7 (Turtle)");
            listBox1.Items.Add("Crystal 4 (Thieves)");
            listBox1.Items.Add("Agahnim 2");

            for(int i = 0; i < 12; i++)
            {
                properties[i] = new DungeonProperty(
                ROM.DATA[Constants.dungeons_startrooms + i],
                 ROM.DATA[Constants.dungeons_endrooms + i],
                  (short)((ROM.DATA[Constants.dungeons_bossrooms + (i*2) +1] << 8) + ROM.DATA[Constants.dungeons_bossrooms + (i * 2)]));
            }
            listBox1.SelectedIndex = 0;

        }
        bool changedFromForm = false;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedFromForm = true;
            startroomTextbox.Text = properties[listBox1.SelectedIndex].startroom.ToString();
            endroomTextbox.Text = properties[listBox1.SelectedIndex].endroom.ToString();
            bossroomTextbox.Text = properties[listBox1.SelectedIndex].bossroom.ToString();
            changedFromForm = false;
        }

        private void bossroomTextbox_TextChanged(object sender, EventArgs e)
        {
            if (changedFromForm == false)
            {
                int r = 0;
                if (int.TryParse(startroomTextbox.Text,out r))
                {
                    properties[listBox1.SelectedIndex].startroom = (byte)r;
                }
                if (int.TryParse(endroomTextbox.Text, out r))
                {
                    properties[listBox1.SelectedIndex].endroom = (byte)r;
                }
                if (int.TryParse(bossroomTextbox.Text, out r))
                {
                    properties[listBox1.SelectedIndex].bossroom = (short)r;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 12; i++)
            {

                ROM.Write(Constants.dungeons_startrooms + i,properties[i].startroom, true, "Dungeon Data Boss/pendantcrystall Rooms");
                ROM.Write(Constants.dungeons_endrooms + i,properties[i].endroom, true, "Dungeon Data Boss/pendantcrystall Rooms");
                ROM.WriteShort(Constants.dungeons_bossrooms + (i * 2), properties[i].bossroom, true, "Dungeon Data Boss/pendantcrystall Rooms");
                //ROM.DATA[Constants.dungeons_bossrooms + (i * 2) + 1] = (byte)(properties[i].bossroom>>8);
                //ROM.DATA[Constants.dungeons_bossrooms + (i * 2)] = (byte)(properties[i].bossroom & 0xFF);
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
        public DungeonProperty(byte startroom,byte endroom,short bossroom)
        {
            this.startroom = startroom;
            this.endroom = endroom;
            this.bossroom = bossroom;
        }

    }
}
