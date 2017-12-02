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
using AutoMapper;
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
            actionsListbox.DisplayMember = "Name";
            palettePicturebox.Image = new Bitmap(256, 256);

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (anychange == true)
            {
                DialogResult dialogResult = MessageBox.Show("Room has changed. Do you want to save changes?", "Save", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    all_rooms[room.index] = room;
                }
            }
            saveallChests();
            saveallSprites();
            FileStream fs = new FileStream(openRomFileDialog.FileName, FileMode.Open, FileAccess.Write);
            fs.Write(ROM.DATA, 0, (int)fs.Length);
            fs.Close();
        }

        public void saveAllRooms()//room settings floor1, floor2, blockset, spriteset, palette
        {

        }

        public void savePalettes()//room settings floor1, floor2, blockset, spriteset, palette
        {

        }

        public void saveallChests()
        {
            int pos = Constants.room_chest;
            for (int i = 0; i < 296; i++)
            {
                foreach(Chest c in all_rooms[i].chest_list)
                {
                    ushort room_index = (ushort)i;
                    if (c.bigChest == true)
                    {
                        room_index += 0x8000;
                    }
                    ROM.DATA[pos] = (byte)(room_index & 0xFF);
                    ROM.DATA[pos+1] = (byte)((room_index>>8) & 0xFF);
                    ROM.DATA[pos+2] = (byte)(c.item);
                    pos += 3;
                }
            }
        }
    

        public void saveallSprites()
        {

            byte[] sprites_buffer = new byte[0x1670];
            //empty room data = 0x250
            //start of data = 0x252
            try
            {
                int pos = 0x252;
                //set empty room
                sprites_buffer[0x250] = 0x00;
                sprites_buffer[0x251] = 0xFF;

                for (int i = 0; i < 296; i++)
                {
                    if (all_rooms[i].sprites.Count <= 0)
                    {
                        sprites_buffer[(i * 2)] = (byte)((Addresses.pctosnes(Constants.sprites_data_empty_room) & 0xFF));
                        sprites_buffer[(i * 2) + 1] = (byte)((Addresses.pctosnes(Constants.sprites_data_empty_room) >> 8) & 0xFF);
                    }
                    else
                    {
                        //pointer : 
                        sprites_buffer[(i * 2)] = (byte)((Addresses.pctosnes(Constants.sprites_data + (pos - 0x252)) & 0xFF));
                        sprites_buffer[(i * 2) + 1] = (byte)((Addresses.pctosnes(Constants.sprites_data + (pos - 0x252)) >> 8) & 0xFF);

                        sprites_buffer[pos] = 0x00;//Unknown byte??
                        pos++;
                        foreach (Sprite spr in all_rooms[i].sprites) //3bytes
                        {
                            //BG2, Subtype, Y Position
                            //b1 = BSSY YYYY
                            //Overlord, X Position 
                            //b2 = OOOX XXXX
                            byte b1 = (byte)((spr.layer << 7) + (spr.subtype << 5) + spr.y);
                            byte b2 = (byte)((spr.overlord << 5) + spr.x);
                            byte b3 = (byte)((spr.id));

                            sprites_buffer[pos] = b1;
                            pos++;
                            sprites_buffer[pos] = b2;
                            pos++;
                            sprites_buffer[pos] = b3;
                            pos++;
                        }
                        sprites_buffer[pos] = 0xFF;//End of sprites
                        pos++;
                    }
                }

                sprites_buffer.CopyTo(ROM.DATA, Constants.room_sprites_pointers);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openRomFileDialog.ShowDialog();
        }
        Room room;
        bool header = false;
        Room[] all_rooms = new Room[296];
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
                header = true;
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
                //Constants.Init_Jp(true); //VT
                ROM.DATA = null;
                MessageBox.Show("Sorry that ROM is not supported :(", "Error");
                //load_default_room();
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
            for (int i = 0; i < 60; i++)
            {
                string ts = "[" + i.ToString() + "] ";
                for (int j = 0; j < 4; j++)
                {
                    if (ROM.DATA[(Constants.sprite_blockset_pointer + ((i + 64) * 4) + j)] < 96)
                    {
                        ts += Sprite_SubsetNames.names[ROM.DATA[(Constants.sprite_blockset_pointer + ((i + 64) * 4) + j)]] + "|";
                    }
                }
                SpritesetcomboBox.Items.Add(ts);
            }


            byte[] bpp3data = Compression.DecompressTiles(); //decompress almost all the gfx from the game
            GFX.gfxdata = Compression.bpp3tobpp4(bpp3data); //transform them into 4bpp

            for (int i = 0; i < 296; i++)
            {
                all_rooms[i] = (new Room(i));
            }

            roomListBox.Items.Clear();
            roomListBox.ValueMember = "Name";
            Room_Name room_names = new Room_Name();
            loadRoomList();

            roomListBox.SelectedIndex = 260;//set start room on link's house
            updatePalettebox();


            //Load sprites group and store them into

        }

        public void updatePalettebox()
        {
            using (Graphics g = Graphics.FromImage(palettePicturebox.Image))
            {
                g.Clear(Color.Black);
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        g.FillRectangle(new SolidBrush(GFX.loadedPalettes[x, y]), new Rectangle(x * 16, y * 16, 16, 16));
                    }
                }
            }
            palettePicturebox.Refresh();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            //Not sure if i'll use that or not maybe for animation?
        }
        bool found = false;
        bool alreadyin = false;
        bool moved = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouse_down == false)
            {
                found = false;
                alreadyin = false;


                if (spritemodeButton.Checked)
                {
                    dragx = ((e.X) / 16);
                    dragy = ((e.Y) / 16);
                    foreach (Sprite spr in room.sprites)
                    {

                        if (e.X >= spr.boundingbox.X && e.X <= spr.boundingbox.X + spr.boundingbox.Width &&
                            e.Y >= spr.boundingbox.Y && e.Y <= spr.boundingbox.Y + spr.boundingbox.Height)
                        {
                            //IF WE ARE HOLDING SHIFT THEN ADD
                            if (ModifierKeys == Keys.Shift)
                            {

                            }
                            else
                            {
                                //IF SHIFT IS NOT HOLD THEN CLEAR BEFORE ADD
                                if (room.selectedObject.Count == 1)
                                {
                                    room.selectedObject.Clear();
                                }
                            }
                            foreach (Object o in room.selectedObject)
                            {
                                if (o == spr)
                                {
                                    alreadyin = true;
                                    break;
                                }
                            }
                            if (ModifierKeys == Keys.Shift)
                            {
                                if (alreadyin == false)//prevent adding multiple time the same object
                                {
                                    room.selectedObject.Add(spr);
                                }
                            }
                            else
                            {
                                if (alreadyin == false)
                                {
                                    room.selectedObject.Clear();
                                    room.selectedObject.Add(spr);
                                }
                            }
                            room.update();
                            drawRoom();
                            found = true;
                            break;
                        }
                    }
                    if (found == false)
                    {
                        room.selectedObject.Clear();
                        room.update();
                        drawRoom();
                    }
                }
                else if (potmodeButton.Checked)
                {
                    dragx = ((e.X) / 8);
                    dragy = ((e.Y) / 8);
                    foreach (PotItem item in room.pot_items)
                        {

                            if (e.X >= (item.x*8) && e.X <= (item.x*8)+16 &&
                                e.Y >= (item.y*8) && e.Y <= (item.y*8)+16)
                            {
                                //IF WE ARE HOLDING SHIFT THEN ADD
                                if (ModifierKeys == Keys.Shift)
                                {
                                    
                                }
                                else
                                {
                                    //IF SHIFT IS NOT HOLD THEN CLEAR BEFORE ADD
                                    if (room.selectedObject.Count == 1)
                                    {
                                        room.selectedObject.Clear();
                                    }
                                }
                                foreach (Object o in room.selectedObject)
                                {
                                    if (o == item)
                                    {
                                        alreadyin = true;
                                        break;
                                    }
                                }
                                if (ModifierKeys == Keys.Shift)
                                {
                                    if (alreadyin == false)//prevent adding multiple time the same object
                                    {
                                        room.selectedObject.Add(item);
                                    }
                                }
                                else
                                {
                                    if (alreadyin == false)
                                    {
                                        room.selectedObject.Clear();
                                        room.selectedObject.Add(item);
                                    }
                                }
                                room.update();
                                drawRoom();
                                found = true;
                                break;
                            }
                        }
                        if (found == false)
                        {
                            room.selectedObject.Clear();
                            room.update();
                            drawRoom();
                        }
                    }

                mouse_down = true;
            }
        }

        bool mouse_down = false;
        int mx = 0;
        int my = 0;
        int last_mx = 0;
        int last_my = 0;
        int dragx = 0;
        int dragy = 0;
        int move_x = 0;
        int move_y = 0;
        List<Object> oldObjectList = new List<object>();
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (spritemodeButton.Checked)
            {
                mx = ((e.X) / 16);
                my = ((e.Y) / 16);
            }
            else if (potmodeButton.Checked)
            {
                mx = ((e.X) / 8);
                my = ((e.Y) / 8);
            }
            move_x = mx - dragx; //mx = 24, dragx = 28, mx-dragx = move_x = -4, so x = dragx + move_x
            move_y = my - dragy;

            if (mouse_down)
            {
                    if (mx != last_mx || my != last_my)
                    {
                        if (oldObjectList != room.selectedObject)
                        {
                            room.update(); //Slow function prevent room from updating everyframe if object didnt changed
                            oldObjectList = room.selectedObject;
                        }

                        anychange = true;
                        moved = true;
                        drawRoom();
                    }

            }
            last_mx = mx;
            last_my = my;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
            if (spritemodeButton.Checked)
            {
                List<Object> parameters = new List<Object>();
                List<Sprite> moved_sprites = new List<Sprite>();
                List<int> x_pos = new List<int>();
                List<int> y_pos = new List<int>();
                if (room.selectedObject.Count > 0)
                {
                    if (moved == true)
                    {
                        foreach (Object o in room.selectedObject)
                        {
                            moved_sprites.Add((o as Sprite));
                            x_pos.Add((o as Sprite).x);
                            y_pos.Add((o as Sprite).y);
                            (o as Sprite).x = (o as Sprite).nx;
                            (o as Sprite).y = (o as Sprite).ny;
                        }
                        parameters.Add(moved_sprites.ToArray());
                        parameters.Add(x_pos.ToArray());
                        parameters.Add(y_pos.ToArray());
                        actionsListbox.Items.Add(new DoAction(ActionType.Move, parameters.ToArray()));

                        tempActionList.Clear();
                    }
                }
                else
                {
                    foreach (Sprite spr in room.sprites)
                    {
                        int rx = dragx;
                        int ry = dragy;
                        if (move_x < 0)
                        {
                            Math.Abs(rx = dragx + move_x);
                        }
                        if (move_y < 0)
                        {
                            Math.Abs(ry = dragy + move_y);
                        }

                        if (spr.boundingbox.IntersectsWith(new Rectangle(rx * 16, ry * 16, Math.Abs(move_x) * 16, Math.Abs(move_y) * 16)))
                        {
                            room.selectedObject.Add(spr);
                        }
                    }
                }
            }
            else if (potmodeButton.Checked)
            {
                List<Object> parameters = new List<Object>();
                List<PotItem> moved_items = new List<PotItem>();
                List<int> x_pos = new List<int>();
                List<int> y_pos = new List<int>();
                if (room.selectedObject.Count > 0)
                {
                    if (moved == true)
                    {
                        foreach (Object o in room.selectedObject)
                        {
                            moved_items.Add((o as PotItem));
                            x_pos.Add((o as PotItem).x);
                            y_pos.Add((o as PotItem).y);
                            (o as PotItem).x = (o as PotItem).nx;
                            (o as PotItem).y = (o as PotItem).ny;
                        }
                        parameters.Add(moved_items.ToArray());
                        parameters.Add(x_pos.ToArray());
                        parameters.Add(y_pos.ToArray());
                        actionsListbox.Items.Add(new DoAction(ActionType.Move, parameters.ToArray()));

                        tempActionList.Clear();
                    }
                }
                else
                {
                    foreach (PotItem item in room.pot_items)
                    {
                        int rx = dragx;
                        int ry = dragy;
                        if (move_x < 0)
                        {
                            Math.Abs(rx = dragx + move_x);
                        }
                        if (move_y < 0)
                        {
                            Math.Abs(ry = dragy + move_y);
                        }

                        if (new Rectangle(item.x*8,item.y*8,16,16).IntersectsWith(new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
                        {
                            room.selectedObject.Add(item);
                        }
                    }
                }
            }
            moved = false;
            room.update();
            drawRoom();
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
        int lastRoom = 260;
        bool anychange = false;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            change_room();

        }

        public void clear_room()
        {
            if (room != null)
            {
                tempActionList.Clear();
                actionsListbox.Items.Clear();
                room.selectedObject.Clear();
            }
        }

        public void change_room()
        {
            room_loaded = false;
            if (anychange)
            {
                if (roomListBox.SelectedIndex != lastRoom)
                {
                    DialogResult dialogResult = MessageBox.Show("Room has changed. Do you want to save changes?", "Save", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {

                        //save here
                        clear_room();
                        save_room(lastRoom);
                        room = (Room)all_rooms[(roomListBox.SelectedItem as ListRoomName).id].Clone();
                        room.reloadGfx();
                        room.update();
                        
                        drawRoom();
                        lastRoom = roomListBox.SelectedIndex;
                        anychange = false;

                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        roomListBox.SelectedIndex = lastRoom;
                    }
                    else
                    {
                        clear_room();
                            room = (Room)all_rooms[(roomListBox.SelectedItem as ListRoomName).id].Clone();
                            room.reloadGfx();
                            room.update();
                        drawRoom();
                        lastRoom = roomListBox.SelectedIndex;
                        anychange = false;
                    }
                }
            }
            else
            {
                clear_room();
                room = (Room)all_rooms[(roomListBox.SelectedItem as ListRoomName).id].Clone();
                room.reloadGfx();
                room.update();
                drawRoom();
                lastRoom = roomListBox.SelectedIndex;
            }
            using (Graphics g = Graphics.FromImage(palettePicturebox.Image))
            {
                g.Clear(Color.Black);
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        g.FillRectangle(new SolidBrush(GFX.loadedPalettes[x, y]), new Rectangle(x * 16, y * 16, 16, 16));
                    }
                }
            }
            floor1UpDown.Value = room.floor1;
            floor2UpDown.Value = room.floor2;
            roomgfxUpDown.Value = room.blockset;
            paletteUpDown.Value =  room.palette;

            if (SpritesetcomboBox.Items.Count > 0)
            {
                SpritesetcomboBox.SelectedIndex = room.spriteset;
            }
            room_loaded = true;
        }

        public void save_room(int roomId)
        {
            all_rooms[roomId] = room;
        }





        List<Rectangle> drawRectangles = new List<Rectangle>();
        public void drawRoom()
        {
            Bitmap roomBitmap = new Bitmap(512, 512);
            using (Graphics g = Graphics.FromImage(roomBitmap))
            {
                drawRectangles.Clear();
                g.DrawImage(GFX.room_bitmap,0,0);
                if (room.selectedObject.Count>0)
                {
                    GFX.begin_draw(roomBitmap);
                    foreach (Object o in room.selectedObject)
                    {
                        if (o is Sprite)
                        {
                            if (moved == true)
                            {
                                (o as Sprite).nx = (byte)((o as Sprite).x + move_x);
                                (o as Sprite).ny = (byte)((o as Sprite).y + move_y);
                            }

                            (o as Sprite).Draw();
                            drawRectangles.Add((o as Sprite).boundingbox);
                        }
                        else if (o is PotItem)
                        {
                            if (moved == true)
                            {
                                (o as PotItem).nx = (byte)((o as PotItem).x + move_x);
                                (o as PotItem).ny = (byte)((o as PotItem).y + move_y);
                            }

                            (o as PotItem).Draw();
                            drawRectangles.Add(new Rectangle((o as PotItem).nx*8, (o as PotItem).ny*8,16,16));
                        }

                    }
                    GFX.end_draw(roomBitmap);

                    if (mouse_down)
                    {
                        foreach (Rectangle r in drawRectangles)
                        {
                            g.DrawRectangle(new Pen(Brushes.LightGreen), r);
                        }
                    }
                    else
                    {
                        foreach (Rectangle r in drawRectangles)
                        {
                            g.DrawRectangle(new Pen(Brushes.Green), r);
                        }
                    }
                    
                }
                else
                {
                    if (mouse_down)
                    {
                        int rx = dragx;
                        int ry = dragy;
                        if (move_x < 0)
                        {
                            Math.Abs(rx = dragx + move_x);
                        }
                        if (move_y < 0)
                        {
                            Math.Abs(ry = dragy + move_y);
                        }

                        if (spritemodeButton.Checked)
                        {
                            g.DrawRectangle(new Pen(Brushes.White), new Rectangle(rx * 16, ry * 16, Math.Abs(move_x) * 16, Math.Abs(move_y) * 16));
                        }
                        else if (potmodeButton.Checked)
                        {
                            g.DrawRectangle(new Pen(Brushes.White), new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8));
                        }
                    }
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
            room.selectedObject.Clear();
            room.update();
            drawRoom();
        }

        public Bitmap[] sprites_bitmap = new Bitmap[0xF3];
        public Bitmap[] chest_items_bitmap = new Bitmap[176];
        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HowToUse howBox = new HowToUse();
            howBox.ShowDialog();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (spritemodeButton.Checked)
            {
                if (room.selectedObject.Count > 0)
                {
                    if (room.selectedObject[0] is Sprite)
                    {
                        PickSprite spritepicker = new PickSprite();
                        for (int i = 0; i < 0xF3; i++)
                        {
                            sprites_bitmap[i] = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                            GFX.begin_draw(sprites_bitmap[i], 32, 32);
                            new Sprite(room, (byte)i, 0, 0, Sprites_Names.name[i], 0, 0, 0).Draw(true);
                            GFX.end_draw(sprites_bitmap[i]);

                            spritepicker.listView1.Items.Add(Sprites_Names.name[i]);
                            spritepicker.listView1.Items[i].ImageIndex = i;
                        }
                        //spritepicker.listView1.LargeImageList = new ImageList();
                        // spritepicker.listView1.LargeImageList
                        spriteImageList.Images.Clear();
                        spriteImageList.Images.AddRange(sprites_bitmap);
                        spritepicker.listView1.LargeImageList = spriteImageList;
                        //recreate all sprites images


                        if (spritepicker.ShowDialog() == DialogResult.OK)
                        {
                            List<Object> parameters = new List<Object>();
                            List<Sprite> changed_sprites = new List<Sprite>();
                            List<int> old_id = new List<int>();
                            foreach (Object o in room.selectedObject)
                            {
                                changed_sprites.Add((o as Sprite));
                                old_id.Add((o as Sprite).id);
                                (o as Sprite).id = (byte)spritepicker.listView1.SelectedIndices[0];
                                (o as Sprite).updateBBox();
                            }
                            parameters.Add(changed_sprites.ToArray());
                            parameters.Add(old_id.ToArray());
                            actionsListbox.Items.Add(new DoAction(ActionType.Change, parameters.ToArray()));
                            room.update();
                            drawRoom();

                        }
                    }

                }
                else
                {
                    PickSprite spritepicker = new PickSprite();
                    for (int i = 0; i < 0xF3; i++)
                    {
                        sprites_bitmap[i] = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GFX.begin_draw(sprites_bitmap[i], 32, 32);
                        new Sprite(room, (byte)i, 0, 0, Sprites_Names.name[i], 0, 0, 0).Draw(true);
                        GFX.end_draw(sprites_bitmap[i]);

                        spritepicker.listView1.Items.Add(Sprites_Names.name[i]);
                        spritepicker.listView1.Items[i].ImageIndex = i;
                    }
                    //spritepicker.listView1.LargeImageList = new ImageList();
                    // spritepicker.listView1.LargeImageList
                    spriteImageList.Images.Clear();
                    spriteImageList.Images.AddRange(sprites_bitmap);
                    spritepicker.listView1.LargeImageList = spriteImageList;

                    if (spritepicker.ShowDialog() == DialogResult.OK)
                    {
                        List<Object> parameters = new List<Object>();
                        List<Sprite> new_sprite = new List<Sprite>();
                        List<int> old_id = new List<int>();
                        Sprite o = new Sprite(room, (byte)spritepicker.listView1.SelectedIndices[0], (byte)mx, (byte)my, Sprites_Names.name[spritepicker.listView1.SelectedIndices[0]], 0, 0, 0);
                        new_sprite.Add((o as Sprite));
                        parameters.Add(new_sprite.ToArray());
                        room.sprites.Add(o);
                        actionsListbox.Items.Add(new DoAction(ActionType.Add, parameters.ToArray()));

                        room.update();
                        drawRoom();

                    }
                }
            }
            else if (chestmodeButton.Checked)
            {
                foreach (Chest c in room.chest_list)
                {
                    Console.WriteLine((c.x*16) + "," + (c.y*16));
                    Console.WriteLine("Mouse:" +e.X + "," + e.Y);
                    if (e.X >= (c.x * 8) && e.X <= (c.x * 8) + 16 &&
                        e.Y >= (c.y * 8) && e.Y <= (c.y * 8) + 16)
                    {
                        PickChestItem chestpicker = new PickChestItem();
                        for (int i = 0; i < 176; i++)
                        {
                            chest_items_bitmap[i] = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                            GFX.begin_draw(chest_items_bitmap[i], 16, 16);
                            new Chest(0, 0, (byte)i,false,true).ItemsDraw((byte)i, 0, 0); ;
                            
                            GFX.end_draw(chest_items_bitmap[i]);

                            chestpicker.listView1.Items.Add(ChestItems_Name.name[i]);
                            chestpicker.listView1.Items[i].ImageIndex = i;

                        }
                        chestpicker.chestItemsImagesList.Images.AddRange(chest_items_bitmap);
                        chestpicker.listView1.LargeImageList = chestpicker.chestItemsImagesList;
                        if (chestpicker.ShowDialog() == DialogResult.OK)
                        {
                            //change chest item
                            c.item = (byte)chestpicker.listView1.SelectedIndices[0];
                            room.update();
                            drawRoom();
                            anychange = true;
                        }


                        break;
                    }
                }
                
            }
        }

        List<DoAction> tempActionList = new List<DoAction>();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Object> parameters = new List<Object>();
            List<Sprite> deleted_sprites = new List<Sprite>();
            List<int> deleted_index = new List<int>();
            foreach (Object o in room.selectedObject)
            {
                deleted_sprites.Add((Sprite)o);
                deleted_index.Add(room.sprites.FindIndex(a => a == o));
                room.sprites.Remove((o as Sprite));
            }
            parameters.Add(deleted_sprites.ToArray());
            parameters.Add(deleted_index.ToArray());
            
            actionsListbox.Items.Add(new DoAction(ActionType.Delete, parameters.ToArray()));
            tempActionList.Clear(); //reset the temp actionlist we can't redo anymore since we changed something
            room.selectedObject.Clear();
            room.update();
            drawRoom();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (actionsListbox.Items.Count > 0)
            {
                (actionsListbox.Items[actionsListbox.Items.Count-1] as DoAction).undo(room,tempActionList);
                actionsListbox.Items.RemoveAt(actionsListbox.Items.Count - 1);
            }
            room.selectedObject.Clear();
            room.update();
            drawRoom();

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tempActionList.Count > 0)
            {
                (tempActionList[0] as DoAction).redo(room,actionsListbox);
                tempActionList.RemoveAt(0);
            }
            room.selectedObject.Clear();
            room.update();
            drawRoom();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Sprite spr in room.sprites)
            {
               room.selectedObject.Add(spr);
            }
            room.update();
            drawRoom();
        }
        
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (spritemodeButton.Checked)
            {
                Clipboard.Clear();
                List<SaveObject> odata = new List<SaveObject>();

                foreach (Sprite o in room.selectedObject)
                {
                    odata.Add(new SaveObject(o));
                }
                Clipboard.SetData("ObjectZ", odata);

                List<Object> parameters = new List<Object>();
                List<Sprite> deleted_sprites = new List<Sprite>();
                List<int> deleted_index = new List<int>();
                foreach (Object o in room.selectedObject)
                {
                    deleted_sprites.Add((Sprite)o);
                    deleted_index.Add(room.sprites.FindIndex(a => a == o));
                    room.sprites.Remove((o as Sprite));
                }
                parameters.Add(deleted_sprites.ToArray());
                parameters.Add(deleted_index.ToArray());

                actionsListbox.Items.Add(new DoAction(ActionType.Delete, parameters.ToArray()));
                tempActionList.Clear(); //reset the temp actionlist we can't redo anymore since we changed something
                room.selectedObject.Clear();
                room.update();
                drawRoom();
            }

        }



        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            List<SaveObject> data = (List<SaveObject>)Clipboard.GetData("ObjectZ");
            List<Object> parameters = new List<Object>();
            List<Sprite> new_sprite = new List<Sprite>();
            int most_x = 512;
            int most_y = 512;
            foreach (SaveObject o in data)
            {
                if (data.Count > 0)
                {
                    if (o.x < most_x)
                    {
                        most_x = o.x;
                    }
                    if (o.y < most_y)
                    {
                        most_y = o.y;
                    }
                }
                else
                {
                    most_x = 0;
                    most_y = 0;
                }
            }
            room.selectedObject.Clear();
            foreach (SaveObject o in data)
            {
                Sprite spr = (new Sprite(room, o.id, (byte)(o.x-most_x), (byte)(o.y-most_y), Sprites_Names.name[o.id], o.overlord, o.subtype, o.layer));
                new_sprite.Add(spr);
                room.sprites.Add(spr);
                room.selectedObject.Add(spr);
            }
            dragx = 0;
            dragy = 0;
            mouse_down = true;
            moved = true;
            parameters.Add(new_sprite.ToArray());
            actionsListbox.Items.Add(new DoAction(ActionType.Add, parameters.ToArray()));
            room.update();
            drawRoom();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            List<SaveObject> odata = new List<SaveObject>();
            foreach (Sprite o in room.selectedObject)
            {
                odata.Add(new SaveObject(o));
            }
            Clipboard.SetData("ObjectZ", odata);

        }
        bool room_loaded = false;
        private void floor1UpDown_ValueChanged(object sender, EventArgs e)
        {
            if (room_loaded)
            {
                room.floor1 = (byte)floor1UpDown.Value;
                room.floor2 = (byte)floor2UpDown.Value;
                room.spriteset = (byte)SpritesetcomboBox.SelectedIndex;
                room.palette = (byte)paletteUpDown.Value;
                room.blockset = (byte)roomgfxUpDown.Value;
                
                room.reloadGfx();
                drawRoom();
            }
        }
        bool palette_mouse_down = false;
        Color oldColor;
        int palX = 0;
        int palY = 0;
        private void palettePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int px = (e.X / 16);
                int py = (e.Y / 16);
                palX = px;
                palY = py;
                oldColor = GFX.loadedPalettes[px, py];
                GFX.loadedPalettes[px, py] = Color.Fuchsia;
                updatePalettebox();
                palette_mouse_down = true;
                room.reloadGfx(true);
                drawRoom();
                
            }

            
        }

        private void palettePicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            if (palette_mouse_down)
            {
                GFX.loadedPalettes[palX, palY] = oldColor;
                updatePalettebox();
                palette_mouse_down = false;
                room.reloadGfx(true);
                drawRoom();
            }
        }

        private void palettePicturebox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int px = (e.X / 16);
                int py = (e.Y / 16);
                palX = px;
                palY = py;
                colorDialog1.Color = GFX.loadedPalettes[palX, palY];
                colorDialog1.ShowDialog();
                GFX.loadedPalettes[palX, palY] = colorDialog1.Color;
                updatePalettebox();
                palette_mouse_down = false;
                room.reloadGfx(true);
                drawRoom();
            }
        }
        Random rand;
        byte dungeon_palette_id;
        private void button1_Click(object sender, EventArgs e)
        {
            rand = new Random();
            dungeon_palette_id = ROM.DATA[Constants.dungeons_palettes_groups + (room.palette * 4)]; //id of the 1st group of 4
            randomize_wall(dungeon_palette_id);
            randomize_floors();
            room.reloadGfx(true);
            updatePalettebox();
            drawRoom();
        }

        public void randomize_wall(int dungeon)
        {
            Color wall_color = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));

            for (int i = 0; i < 5; i++)
            {
                byte shadex = (byte)(10 - (i * 2));
                setColor(1+i ,2, wall_color, shadex);
                setColor(9+i,2, wall_color, shadex);
                setColor(1+i,7, wall_color, shadex);
            }


            setColor(14,7, wall_color, (byte)(4)); //outer wall darker
            setColor(15,7, wall_color, (byte)(2)); //outter wall brighter

            setColor(14, 4, wall_color, (byte)(8)); //contour wall
            setColor(15, 4, wall_color, (byte)(6)); //contour wall
            setColor(9, 4, wall_color, (byte)(10)); //contour wall
            setColor(15, 2, wall_color, (byte)(6)); //contour wall



            setColor(14, 3, wall_color, (byte)(4)); //contour wall
            setColor(15, 3, wall_color, (byte)(2)); //contour wall
            setColor(9, 3, wall_color, (byte)(10)); //contour wall
            setColor(14, 2, wall_color, (byte)(4)); //contour wall

            setColor(2, 4, wall_color, (byte)(8)); //contour wall
        }

        public void randomize_floors()
        {
            Color floor_color1 = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));
            Color floor_color2 = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));
            Color floor_color3 = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));

            for (int i = 0; i < 3; i++)
            {
                byte shadex = (byte)(6 - (i * 2));
                setColor(10+i, 3, floor_color1, shadex);
                setColor(10+i, 4, floor_color1, (byte)(shadex + 3));

                //setColor(0x0DD7A0 + (0xB4 * dungeon) + (i * 2), floor_color2, shadex);
                //setColor(0x0DD7BE + (0xB4 * dungeon) + (i * 2), floor_color2, (byte)(shadex + 3));
            }

            setColor(13, 7, floor_color2, (byte)(2)); //outer wall darker
            setColor(6, 2, floor_color2, (byte)(4)); //outer wall darker
            setColor(7, 2, floor_color2, (byte)(6)); //outer wall darker
            //setColor(0x0DD7E2 + (0xB4 * dungeon), floor_color3, 3);
            //setColor(0x0DD796 + (0xB4 * dungeon), floor_color3, 4);
        }
    
        public void setColor(int x, int y, Color col, byte shade)
        {

            int r = col.R;
            int g = col.G;
            int b = col.B;

            for (int i = 0; i < shade; i++)
            {
                r = (r - (r / 5));
                g = (g - (g / 5));
                b = (b - (b / 5));
            }

            r = (int)((float)r / 255f * 0x1F);
            g = (int)((float)g / 255f * 0x1F);
            b = (int)((float)b / 255f * 0x1F);

            //short s = (short)(((b) << 10) | ((g) << 5) | ((r) << 0));


            GFX.loadedPalettes[x, y] = Color.FromArgb(r*8, g*8, b*8);

            //ROM_DATA[address] = (byte)(s & 0x00FF);
            //ROM_DATA[address + 1] = (byte)((s >> 8) & 0x00FF);


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

    

    public class DoAction
    {
        public ActionType type;
        public object[] parameters;
        public string Name { get; set; } //Used to display name in action list
        public DoAction(ActionType type, object[] parameters)
        {
            this.type = type;
            this.parameters = parameters;
            if (type == ActionType.Delete) //parameters = Object[],position in array
            {
                if (parameters[0] is Sprite[]) //deleted sprites
                {
                    if ((parameters[0] as Sprite[]).Length == 1)
                    {
                        Name = "Sprite[" + (parameters[0] as Sprite[])[0].id + "]" + "Deleted from pos : " + (parameters[1] as int[])[0].ToString();
                    }
                    else
                    {
                        Name = "Group of sprites Deleted";
                    }
                }
            }
            else if (type == ActionType.Move) //parameters = Object[],old_x,old_y
            {
                if (parameters[0] is Sprite[]) //deleted sprites
                {
                    if ((parameters[0] as Sprite[]).Length == 1)
                    {
                        Name = "Sprite[" + (parameters[0] as Sprite[])[0].id + "]" + "Moved from pos : X:" + (parameters[1] as int[])[0].ToString() + ",Y:" + (parameters[2] as int[])[0].ToString();
                    }
                    else
                    {
                        Name = "Group of sprites Moved";
                    }
                }
            }
            else if (type == ActionType.Change)
            {
                if ((parameters[0] as Sprite[]).Length == 1)
                {
                    Name = "Sprite[" + (parameters[0] as Sprite[])[0].id + "]" + "Changed to id : :" + (parameters[1] as int[])[0].ToString();
                }
                else
                {
                    Name = "Group of sprites Changed Id";
                }
            }
        }

        public void undo(Room room, List<DoAction> tempAction)
        {
            if (type == ActionType.Delete)
            {
                if (parameters[0] is Sprite[]) //deleted sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        room.sprites.Insert((parameters[1] as int[])[i], (parameters[0] as Sprite[])[i]);
                    }
                }
            }
            else if (type == ActionType.Move)
            {
                if (parameters[0] is Sprite[]) //moved sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        int new_old_x = (parameters[0] as Sprite[])[i].x;
                        int new_old_y = (parameters[0] as Sprite[])[i].y;
                        (parameters[0] as Sprite[])[i].x = (byte)(parameters[1] as int[])[i]; //return to old_x
                        (parameters[0] as Sprite[])[i].y = (byte)(parameters[2] as int[])[i]; //return to old_y
                        (parameters[0] as Sprite[])[i].nx = (parameters[0] as Sprite[])[i].x;
                        (parameters[0] as Sprite[])[i].ny = (parameters[0] as Sprite[])[i].y;
                        (parameters[1] as int[])[i] = new_old_x;//set them to oldpos for the redo function
                        (parameters[2] as int[])[i] = new_old_y;//set them to oldpos for the redo function
                    }
                }
            }
            else if (type == ActionType.Change)
            {
                if (parameters[0] is Sprite[]) //changed sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        int new_old_id = (parameters[0] as Sprite[])[i].id;
                        (parameters[0] as Sprite[])[i].id = (byte)(parameters[1] as int[])[i]; //return to old_x
                        (parameters[1] as int[])[i] = new_old_id;//set them to oldid for the undo function
                        (parameters[0] as Sprite[])[i].updateBBox();
                    }
                }
            }
            else if (type == ActionType.Add)
            {
                if (parameters[0] is Sprite[]) //changed sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        room.sprites.Remove((parameters[0] as Sprite[])[i]);
                    }
                }
            }
            tempAction.Insert(0,new DoAction(type, parameters));

        }

        public void redo(Room room, ListBox actionlist)
        {
            if (type == ActionType.Delete)
            {
                if (parameters[0] is Sprite[]) //deleted sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        room.sprites.Remove((parameters[0] as Sprite[])[i]);
                    }
                }
            }
            else if (type == ActionType.Move)
            {
                if (parameters[0] is Sprite[]) //moved sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        int new_old_x = (parameters[0] as Sprite[])[i].x;
                        int new_old_y = (parameters[0] as Sprite[])[i].y;
                        (parameters[0] as Sprite[])[i].x = (byte)(parameters[1] as int[])[i]; //return to old_x
                        (parameters[0] as Sprite[])[i].y = (byte)(parameters[2] as int[])[i]; //return to old_y
                        (parameters[0] as Sprite[])[i].nx = (parameters[0] as Sprite[])[i].x;
                        (parameters[0] as Sprite[])[i].ny = (parameters[0] as Sprite[])[i].y;
                        (parameters[1] as int[])[i] = new_old_x;//set them to oldpos for the undo function
                        (parameters[2] as int[])[i] = new_old_y;//set them to oldpos for the undo function
                    }
                }
            }
            else if (type == ActionType.Change)
            {
                if (parameters[0] is Sprite[]) //changed sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        int new_old_id = (parameters[0] as Sprite[])[i].id;
                        (parameters[0] as Sprite[])[i].id = (byte)(parameters[1] as int[])[i]; //return to old_x
                        (parameters[1] as int[])[i] = new_old_id;//set them to oldid for the undo function
                        (parameters[0] as Sprite[])[i].updateBBox();
                    }
                }
            }
            else if (type == ActionType.Add)
            {
                if (parameters[0] is Sprite[]) //changed sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        room.sprites.Add((parameters[0] as Sprite[])[i]);
                    }
                }
            }
            actionlist.Items.Add(new DoAction(type, parameters));
        }

    }

    public enum ActionType
    {
        Move,Delete,Add,Change
    }

    [Serializable]
    public class SaveObject
    {
        public byte x { get; set; }
        public byte y { get; set; }
        public byte layer { get; set; }
        public byte subtype { get; set; }
        public byte overlord { get; set; }
        public byte id { get; set; }
        public Type type;
        public SaveObject(Sprite sprite) //Sprite Format
        {
            this.x = sprite.x;
            this.y = sprite.y;
            this.id = sprite.id;
            this.layer = sprite.layer;
            this.subtype = sprite.subtype;
            this.overlord = sprite.overlord;
            type = typeof(Sprite);
        }
    }
}
