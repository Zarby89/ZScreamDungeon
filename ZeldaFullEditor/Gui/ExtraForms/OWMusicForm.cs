using System;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui.ExtraForms
{
    public partial class OWMusicForm : Form
    {
        public byte mapIndex = 0;
        public byte[] musics = new byte[4];
        bool fromForm = false;

        public OWMusicForm()
        {
            InitializeComponent();
        }

        private void OWMusicForm_Load(object sender, EventArgs e)
        {
            music1Box.Items.AddRange(Constants.musicNamesOW);
            music2Box.Items.AddRange(Constants.musicNamesOW);
            music3Box.Items.AddRange(Constants.musicNamesOW);
            music4Box.Items.AddRange(Constants.musicNamesOW);

            ambient1Box.Items.AddRange(Constants.ambientNamesOW);
            ambient2Box.Items.AddRange(Constants.ambientNamesOW);
            ambient3Box.Items.AddRange(Constants.ambientNamesOW);
            ambient4Box.Items.AddRange(Constants.ambientNamesOW);

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
            if (mapIndex >= 0x40)
            {
                music2Box.Enabled = false;
                music3Box.Enabled = false;
                music4Box.Enabled = false;
                ambient2Box.Enabled = false;
                ambient3Box.Enabled = false;
                ambient4Box.Enabled = false;
            }
            else
            {
                music2Box.Enabled = true;
                music3Box.Enabled = true;
                music4Box.Enabled = true;
                ambient2Box.Enabled = true;
                ambient3Box.Enabled = true;
                ambient4Box.Enabled = true;
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
