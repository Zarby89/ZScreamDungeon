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
using System.Diagnostics;

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
            byte[] tempRom;
            FileStream fs = new FileStream(openRomFileDialog.FileName, FileMode.Open, FileAccess.Read);
            tempRom = new byte[fs.Length];
            fs.Read(tempRom, 0, (int)fs.Length);
            fs.Close();

            if (tempRom.Length == 0x100200)
            {
                ROM.DATA = new byte[0x100000];
                Array.Copy(tempRom, 0x200, ROM.DATA, 0x00, 0x100000);
            }
            else
            {
                ROM.DATA = new byte[tempRom.Length];
                tempRom.CopyTo(ROM.DATA, 0x0);
            }
            checkFileSupport();


        }

        public void checkFileSupport()
        {
            string title = getHeaderTitle();
            if (title == "VTC")
            {
                Constants.Init_Jp(true); //VT
                load_default_room();
            }
            else if (title == "ZEL")
            {
                Constants.Init_Jp(); //JP
                load_default_room();
            }
            else if (title == "THE")
            {
                //US
                load_default_room();
            }
            else
            {
                Constants.Init_Jp(true); //VT
                load_default_room();
                //ROM.DATA = null;
                //MessageBox.Show("Sorry that ROM is not supported :(", "Error");
            }
        }

        public string getHeaderTitle()
        {
            string title = "";
            for (int i = 0; i < 3; i++)
            {
                 title += (char)ROM.DATA[0x07FC0+i];
            }
            return title;
        }

        short[][] dungeons_rooms = new short[15][];
        public void loadRoomList()
        {
            dungeons_rooms[0] = new short[] { 1, 2, 17, 18, 32, 33, 34, 48, 50, 64, 65, 66, 80, 81, 82, 85, 96, 97, 98, 112, 113, 114, 128, 129, 130, 176, 192, 208, 224 };
            dungeons_rooms[1] = new short[] { 137, 153, 168, 169, 170, 184, 185, 186, 200, 201, 216, 217, 218 };
            dungeons_rooms[2] = new short[] { 51, 67, 83, 99, 115, 116, 117, 131, 132, 133 };
            dungeons_rooms[3] = new short[] { 7, 23, 39, 49, 119, 135, 167 };
            dungeons_rooms[4] = new short[] { 9, 10, 11, 25, 26, 27, 42, 43, 58, 59, 74, 75, 90, 106 };
            dungeons_rooms[5] = new short[] { 6, 22, 38, 40, 52, 53, 54, 55, 56, 70, 84, 102, 118 };
            dungeons_rooms[6] = new short[] { 68, 69, 100, 101, 171, 172, 187, 188, 203, 204, 219, 220 };
            dungeons_rooms[7] = new short[] { 41, 57, 73, 86, 87, 88, 89, 103, 104 };
            dungeons_rooms[8] = new short[] { 14, 30, 31, 46, 62, 63, 78, 79, 94, 95, 110, 126, 127, 142, 158, 159, 174, 175, 190, 191, 206, 222 };
            dungeons_rooms[9] = new short[] { 144, 145, 146, 147, 151, 152, 160, 161, 162, 163, 177, 178, 179, 193, 194, 195, 209, 210 };
            dungeons_rooms[10] = new short[] { 4, 19, 20, 21, 35, 36, 164, 180, 181, 182, 183, 196, 197, 198, 199, 213, 214 };
            dungeons_rooms[11] = new short[] { 12, 13, 28, 29, 61, 76, 77, 91, 92, 93, 107, 108, 109, 123, 124, 125, 139, 140, 141, 149, 150, 155, 156, 157, 165, 166 };
            dungeons_rooms[12] = new short[] { 0, 3, 8, 16, 24, 44, 47, 60, 223, 225, 226, 227, 228, 229, 230, 231, 232, 234, 235, 237, 238, 239, 240, 241, 248, 249, 250, 251, 253, 254, 255, 266, 267, 268, 269, 270, 274, 275, 276, 277, 278, 279, 283, 286, 288, 291, 292, 293, 294, 295 };
            dungeons_rooms[13] = new short[] { 242, 243, 244, 245, 256, 257, 258, 259, 260, 261, 262, 263, 264, 265, 271, 272, 273, 280, 281, 282, 284, 285, 287 };
            dungeons_rooms[14] = new short[] { 5, 15, 37, 45, 71, 72, 105, 111, 120, 121, 122, 134, 136, 138, 143, 148, 154, 173, 189, 202, 205, 207, 211, 212, 215, 221, 233, 236, 246, 247, 252 };
                        if (radioButton2.Checked == true)
            {
                roomListBox.Items.Clear();
                if (comboBox1.SelectedIndex != -1)
                {
                    foreach (short rid in dungeons_rooms[comboBox1.SelectedIndex])
                    {
                        roomListBox.Items.Add(new ListRoomName(rid, "[" + rid + "] " + room_names.room_name[rid]));
                    }
                }
            }
            else
            {
                roomListBox.Items.Clear();
                
                for (int i = 0; i < 296; i++)
                {
                    roomListBox.Items.Add(new ListRoomName(i,"["+ i +"] "+ room_names.room_name[i]));
                }

                roomListBox.SelectedIndex = 260;
            }


        }


        public void load_default_room()
        {

            byte[] bpp3data = Compression.DecompressTiles(); //decompress almost all the gfx from the game
            GFX.gfxdata = Compression.bpp3tobpp4(bpp3data); //transform them into 4bpp
            roomListBox.Items.Clear();
            roomListBox.ValueMember = "Name";
            Room_Name room_names = new Room_Name();
            loadRoomList();
            roomListBox.SelectedIndex = 260;//set start room on link's house

        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            //Not sure if i'll use that or not maybe for animation?
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
        Object lastSelectedObject = null;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_down)
            {
                mx = e.X / 8;
                my = e.Y / 8;
                if (mx != last_mx || my != last_my)
                {
                    drawRoom();
                    if (lastSelectedObject != room.selectedObject)
                    {
                        room.update();
                        lastSelectedObject = room.selectedObject;
                    }
                }

                last_mx = mx;
                last_my = my;
            }
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
                room = new Room(formGoto.selectedRoom);
                drawRoom();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            room = new Room((roomListBox.SelectedItem as ListRoomName).id);
            drawRoom();

        }

        public void drawRoom()
        {
            Bitmap roomBitmap = new Bitmap(512, 512);
            using (Graphics g = Graphics.FromImage(roomBitmap))
            {
                g.DrawImage(room.room_bitmap,0,0);
                
                room.selectedObject = room.sprites[0];
                
                if (room.selectedObject is Sprite)
                {
                    GFX.begin_draw(roomBitmap);
                    (room.selectedObject as Sprite).x = (byte)(mx / 2);
                    (room.selectedObject as Sprite).y = (byte)(my / 2);
                    (room.selectedObject as Sprite).Draw();
                    GFX.end_draw(roomBitmap);
                    g.DrawRectangle(new Pen(Brushes.LightGreen), (room.selectedObject as Sprite).boundingbox);
                }
                

            }

            pictureBox1.Image = roomBitmap;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        
        Room_Name room_names = new Room_Name();
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = radioButton2.Checked;
            loadRoomList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomListBox.Items.Clear();
            loadRoomList();
        }

        public void update_modes_buttons(object sender, EventArgs e)
        {
            for(int i = 6;i<14;i++)
            {
                (toolStrip1.Items[i] as ToolStripButton).Checked = false;
            }
            (sender as ToolStripButton).Checked = true;
        }

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HowToUse howBox = new HowToUse();
            howBox.ShowDialog();
        }
    }

    public class ListRoomName
    {
        public string Name { get; set; }
        public int id;

        public ListRoomName(int id,string name)
        {
            this.id = id;
            this.Name = name;
        }
        
    }
}
