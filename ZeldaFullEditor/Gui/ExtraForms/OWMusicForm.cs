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
    public partial class OWMusicForm : Form
    {
        public byte mapIndex = 0;
        public byte[] musics = new byte[4];
        bool fromForm = false;

        // TODO move to DefaultEntities
        string[] musicNames = new string[]
        {
            "0x00 None",
            "0x01 Title",
            "0x02 World Map",
            "0x03 Beginning",
            "0x04 Rabbit",
            "0x05 Forest",
            "0x06 Intro",
            "0x07 Town",
            "0x08 Warp",
            "0x09 Dark World",
            "0x0A Mastersword",
            "0x0B File Select",
            "0x0C Soldier",
            "0x0D Mountain",
            "0x0E Shop",
            "0x0F Fanfare"
        };

        string[] ambientNames = new string[]
        {
            "0x00 Nothing",
            "0x01 Rain/Zora area",
            "0x02 Quiet rain",
            "0x03 More rain",
            "0x04 Even more rain",
            "0x05 Silence",
            "0x06 Quiets ambient sound",
            "0x07 Rumbling",
            "0x08 Endless rumbling",
            "0x09 DM wind/Telepathy",
            "0x0A Quiet wind",
            "0x0B Flute song",
            "0x0C Flute again",
            "0x0D Magic bat/Witch shroom",
            "0x0E Short jingle",
            "0x0F Crystal get/Save and quit",
            "0x10 SQ sound",
            "0x11 Choir melody",
            "0x12 Choir countermelody",
            "0x13 Lanmo/Blind swoosh",
            "0x14 Another swoosh",
            "0x15 Triforce door/Pyramid hole opening",
            "0x16 VOMP",
            "0x17 Flute again again",
            "0x18 Why is there so much flute",
            "0x19 Nothing",
            "0x1A Nothing",
            "0x1B All flute and no play",
            "0x1C Makes flute a flutey flute",
            "0x1D Some jingle",
            "0x1E That broken jingle again",
            "0x1F Crystal get again",
            "0x20 Some other jingle"
        };

        public OWMusicForm()
        {
            InitializeComponent();
        }

        private void OWMusicForm_Load(object sender, EventArgs e)
        {
            music1Box.Items.AddRange(musicNames);
            music2Box.Items.AddRange(musicNames);
            music3Box.Items.AddRange(musicNames);
            music4Box.Items.AddRange(musicNames);

            ambient1Box.Items.AddRange(ambientNames);
            ambient2Box.Items.AddRange(ambientNames);
            ambient3Box.Items.AddRange(ambientNames);
            ambient4Box.Items.AddRange(ambientNames);

            fromForm = true;
            music1Box.SelectedIndex = musics[0] & 0x0F;
            music2Box.SelectedIndex = musics[1] & 0x0F;
            music3Box.SelectedIndex = musics[2] & 0x0F;
            music4Box.SelectedIndex = musics[3] & 0x0F;

            ambient1Box.SelectedIndex = ((musics[0] & 0xF0) >> 4);
            ambient2Box.SelectedIndex = ((musics[1] & 0xF0) >> 4);
            ambient3Box.SelectedIndex = ((musics[2] & 0xF0) >> 4);
            ambient4Box.SelectedIndex = ((musics[3] & 0xF0) >> 4);
            fromForm = false;
            groupBox1.Text = "Map ID : " + mapIndex.ToString("D3");

            if (mapIndex >= 0x40)
            {
                music2Box.Enabled = false;
                music3Box.Enabled = false;
                music4Box.Enabled = false;
                ambient2Box.Enabled = false;
                ambient3Box.Enabled = false;
                ambient4Box.Enabled = false;
                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void music1Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fromForm)
            {
                musics[0] = (byte)((ambient1Box.SelectedIndex << 4) + music1Box.SelectedIndex);
                musics[1] = (byte)((ambient2Box.SelectedIndex << 4) + music2Box.SelectedIndex);
                musics[2] = (byte)((ambient3Box.SelectedIndex << 4) + music3Box.SelectedIndex);
                musics[3] = (byte)((ambient4Box.SelectedIndex << 4) + music4Box.SelectedIndex);
            }
        }
    }
}
