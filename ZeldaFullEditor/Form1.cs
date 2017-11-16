using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ZeldaFullEditor
{



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openRomFileDialog.ShowDialog();
        }
        Room room;
        private void openRomFileDialog_FileOk(object sender, CancelEventArgs e)
        {

            FileStream fs = new FileStream(openRomFileDialog.FileName,FileMode.Open ,FileAccess.Read );
            ROM.DATA = new byte[fs.Length];
            fs.Read(ROM.DATA, 0, (int)fs.Length);
            fs.Close();
            //56 54 43
            //5A 45 4C 44 41 4E
            if (ROM.DATA[0x07FC0] == 0x56 && ROM.DATA[0x07FC1] == 0x54 && ROM.DATA[0x07FC2] == 0x43)
            {
                Constants.Init_Jp(); //VT
                load_default_room();
            }
            else if (ROM.DATA[0x07FC0] == 0x5A && ROM.DATA[0x07FC1] == 0x45 && ROM.DATA[0x07FC2] == 0x4C
                 && ROM.DATA[0x07FC3] == 0x44 && ROM.DATA[0x07FC4] == 0x41 && ROM.DATA[0x07FC5] == 0x4E)
            {
                Constants.Init_Jp(); //JP
                load_default_room();
            }
            else if (ROM.DATA[0x07FC0] == 0x54 && ROM.DATA[0x07FC1] == 0x48 && ROM.DATA[0x07FC2] == 0x45
     && ROM.DATA[0x07FC3] == 0x20 && ROM.DATA[0x07FC4] == 0x4C && ROM.DATA[0x07FC5] == 0x45)
            {
                //US
                load_default_room();
            }
            else
            {
                ROM.DATA = null;
                MessageBox.Show("Sorry that ROM is not supported :(", "Error");
            }


        }

        public void load_default_room()
        {

            GFX.tilebufferbitmap = new Bitmap(512, 512);
            GFX.graphictilebuffer = Graphics.FromImage(GFX.tilebufferbitmap);
            byte[] bpp3data = Compression.DecompressTiles();
            GFX.gfxdata = Compression.bpp3tobpp4(bpp3data);
            GFX.load4bpp(GFX.gfxdata, new byte[] { 0, 1, 16, 6, 14, 31, 24, 15, 92, 94 }, 0);
            GFX.LoadDungeonPalette(0);
            GFX.create_gfxs();
            GFX.animate_gfxs();
            pictureBox1.Image = new Bitmap(512, 512);

            listBox1.Items.Clear();
            Room_Name room_names = new Room_Name();
            for (int i = 0; i < 296; i++)
            {
                listBox1.Items.Add(room_names.room_name[i]);
            }
            listBox1.SelectedIndex = 260;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {

            room.DrawObjects();
            room.redrawRoom();
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_down = true;
        }
        bool mouse_down = false;
        int mx = 0;
        int my = 0;
        int last_mx = 0;
        int last_my = 0;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
        }

        private void gotoRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GotoRoom formGoto = new GotoRoom();
            if (formGoto.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(512, 512);

                room = new Room(formGoto.selectedRoom);

                pictureBox1.Image = room.room_bitmap;


                pictureBox1.Refresh();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            room = new Room(listBox1.SelectedIndex);

            pictureBox1.Image = room.room_bitmap;


            pictureBox1.Refresh();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }
    }
}
