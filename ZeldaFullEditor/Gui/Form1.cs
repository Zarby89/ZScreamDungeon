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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using ZeldaFullEditor.Properties;
using Microsoft.VisualBasic;

namespace ZeldaFullEditor
{

    public partial class zscreamForm : Form
    {
        public zscreamForm()
        {
            InitializeComponent();
        }

        Room room;
        Room[] all_rooms = new Room[296];

        bool found = false;
        bool mouse_down = false;
        int mx = 0;
        int my = 0;
        int last_mx = 0;
        int last_my = 0;
        int dragx = 0;
        int dragy = 0;
        int move_x = 0;
        int move_y = 0;
        bool selection_resize = false;
        bool project_loaded = false;
        bool need_refresh = false;
        ObjectResize resizing;
        int lastRoom = 32;
        bool anychange = false;
        Graphics g;
        Bitmap roomBitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);
        Bitmap overlayBitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);
        List<Room_Object> borderlessobject = new List<Room_Object>();
        PaletteViewer paletteViewer;
        Rectangle[] doorArray = new Rectangle[48];

        //====================================================================
        //Start of the picturebox1 (Main draw window), handlings             |
        //====================================================================
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mouse_down == false)
                {
                    doorArray = new Rectangle[48];
                    if (resizing != ObjectResize.None)
                    {
                        selection_resize = true;
                        mouse_down = true;
                        dragx = ((e.X) / 8);
                        dragy = ((e.Y) / 8);
                        (room.selectedObject[0] as Room_Object).oldSize = (room.selectedObject[0] as Room_Object).size;
                        (room.selectedObject[0] as Room_Object).savedSize = (room.selectedObject[0] as Room_Object).size;
                        return;
                    }
                    found = false;
                    if (spritemodeButton.Checked)
                    {
                        dragx = ((e.X) / 16);
                        dragy = ((e.Y) / 16);
                        if (room.selectedObject.Count == 1)
                        {
                            room.selectedObject.Clear();
                        }
                        foreach (Sprite spr in room.sprites)
                        {
                            if (isMouseCollidingWith(spr, e))
                            {
                                if (spr.selected == false)
                                {
                                    room.selectedObject.Add(spr);
                                    found = true;
                                    break;
                                }
                            }
                        }
                        if (found == false) //we didnt find any sprites to click on so just clear the selection
                        {
                            room.selectedObject.Clear();
                        }
                    }
                    else if (potmodeButton.Checked)
                    {
                        dragx = ((e.X) / 8);
                        dragy = ((e.Y) / 8);
                        if (room.selectedObject.Count == 1)
                        {
                            foreach (Object o in room.pot_items)
                            {
                                //(o as PotItem).selected = false;
                            }
                            room.selectedObject.Clear();
                        }
                        foreach (PotItem item in room.pot_items)
                        {
                            if (isMouseCollidingWith(item, e))
                            {
                                if (item.selected == false)
                                {
                                    room.selectedObject.Add(item);
                                    found = true;
                                    break;
                                }
                            }
                        }
                        if (found == false) //we didnt find any items to click on so just clear the selection
                        {
                            room.selectedObject.Clear();
                        }
                    }
                    else if (selectedLayer >= 0)
                    {

                        dragx = ((e.X) / 8);
                        dragy = ((e.Y) / 8);
                        bool already_in = false;
                        Room_Object objectFound = null;
                        found = false;
                        for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
                        {
                            Room_Object obj = room.tilesObjects[i];
                            if (isMouseCollidingWith(obj, e))
                            {
                                if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Door) != ObjectOption.Door && (obj.options & ObjectOption.Torch) != ObjectOption.Torch && (obj.options & ObjectOption.Block) != ObjectOption.Block)
                                {
                                    if (room.selectedObject.Count == 0)
                                    {
                                        if (selectedLayer == 3 || selectedLayer == obj.layer)
                                        {
                                            room.selectedObject.Add(obj);
                                            found = true;
                                            break;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    else //there's already objects selected
                                    {
                                        //check if the object we found is already in selected object if so do nothing
                                        //otherwise clear objects and select the new one
                                        foreach (Room_Object o in room.selectedObject)
                                        {
                                            if (o == obj)
                                            {
                                                if (selectedLayer == 3 || selectedLayer == obj.layer)
                                                {
                                                    found = true;
                                                    objectFound = o;
                                                    already_in = true;
                                                    break;
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                            }
                                        }
                                        if (already_in == false)
                                        {

                                            //objectToRemove
                                            if (ModifierKeys == Keys.Shift)
                                            {
                                                if (selectedLayer == 3 || selectedLayer == obj.layer)
                                                {
                                                    room.selectedObject.Add(obj);
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                room.selectedObject.Clear();
                                                if (selectedLayer == 3 || selectedLayer == obj.layer)
                                                {
                                                    room.selectedObject.Add(obj);
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                            }

                                        }
                                        else //if item is already in but we hold control then remove it instead
                                        {
                                            if (selectedLayer == 3 || selectedLayer == obj.layer)
                                            {
                                                if (ModifierKeys == Keys.Control)
                                                {
                                                    room.selectedObject.Remove(objectFound);
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                    found = true;
                                    break;
                                }
                            }
                        }
                        if (found == false) //we didnt find any Tiles to click on so just clear the selection
                        {
                            if (ModifierKeys != Keys.Shift && ModifierKeys != Keys.Control)
                            {
                                Console.WriteLine("we didnt find any object so clear all");
                                room.selectedObject.Clear();
                            }
                        }
                    }
                    else if (doormodeButton.Checked)
                    {
                        room.selectedObject.Clear();
                        dragx = ((e.X) / 8);
                        dragy = ((e.Y) / 8);
                        for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
                        {
                            Room_Object obj = room.tilesObjects[i];
                            if (isMouseCollidingWith(obj, e))
                            {
                                if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Door) == ObjectOption.Door)
                                {
                                    //we found a door
                                    room.selectedObject.Add(obj);
                                    obj.selected = true;
                                    doorArray = room.getAllDoorPosition(obj);
                                    need_refresh = true;
                                    break;
                                }

                            }

                        }
                    }
                    else if (blockmodeButton.Checked)
                    {
                        room.selectedObject.Clear();
                        dragx = ((e.X) / 8);
                        dragy = ((e.Y) / 8);
                        for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
                        {
                            Room_Object obj = room.tilesObjects[i];
                            if (isMouseCollidingWith(obj, e))
                            {
                                if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Block) == ObjectOption.Block)
                                {
                                    room.selectedObject.Add(obj);
                                    need_refresh = true;
                                    break;
                                }

                            }

                        }
                    }
                    else if (torchmodeButton.Checked)
                    {
                        room.selectedObject.Clear();
                        dragx = ((e.X) / 8);
                        dragy = ((e.Y) / 8);
                        for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
                        {
                            Room_Object obj = room.tilesObjects[i];
                            if (isMouseCollidingWith(obj, e))
                            {
                                if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Torch) == ObjectOption.Torch)
                                {
                                    //we found a door
                                    room.selectedObject.Add(obj);
                                    need_refresh = true;
                                    break;
                                }

                            }

                        }
                    }
                    else if (warpmodeButton.Checked)
                    {
                        room.selectedObject.Clear();
                        dragx = ((e.X) / 8);
                        dragy = ((e.Y) / 8);
                        int doorCount = 0;
                        foreach (Room_Object o in room.tilesObjects)
                        {
                            if (doorsObject.Contains(o.id))
                            {
                                if (isMouseCollidingWith(o, e))
                                {
                                    string warpid = Interaction.InputBox("New Warp Room", "Room Id", room.staircase_rooms[doorCount].ToString());
                                    room.staircase_rooms[doorCount] = Convert.ToByte(warpid);

                                }
                                doorCount++;
                            }
                            else if (o.id == 0xFCA)
                            {
                                if (isMouseCollidingWith(o, e))
                                {
                                    string warpid = Interaction.InputBox("New Warp Room", "Room Id", room.holewarp.ToString());
                                    room.holewarp = Convert.ToByte(warpid);
                                }
                            }
                        }
                    }
                    mouse_down = true;
                    move_x = 0;
                    move_y = 0;
                    mx = dragx;
                    my = dragy;
                }

                updateSelectionObject();


            }
        }

        Rectangle lastSelectedRectangle = new Rectangle();

        private static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return (Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (project_loaded == true)
            {
                //Cursor.Current = Cursors.Default;
                if (room.selectedObject.Count == 1)
                {
                    if (room.selectedObject[0] is Room_Object)
                    {
                        objects_ResizeMouseMove(e); //show the arrows on selected object to resize them
                    }
                }

                if (mouse_down)
                {

                    setMouseSizeMode(e); //define the size of mx,my for each mode
                    if (doormodeButton.Checked == false)
                    {
                        if (selection_resize == false)
                        {
                            if (mx != last_mx || my != last_my)
                            {
                                need_refresh = true;
                            }
                            if (room.selectedObject.Count > 0)
                            {
                                if (mx != last_mx || my != last_my)
                                {
                                    move_objects();
                                    anychange = true;
                                    last_mx = mx;
                                    last_my = my;
                                }
                            }

                        }
                        else
                        {
                            resizing_objects();
                        }
                    }
                    else //if it a door
                    {

                        if (room.selectedObject.Count > 0)
                        {
                            if (room.selectedObject[0] is object_door)
                            {
                                if (doorArray != null)
                                {
                                    for (int i = 0; i < 48; i++)
                                    {
                                        Rectangle r = doorArray[i];
                                        if (lastSelectedRectangle != r)
                                        {
                                            if (new Rectangle(e.X, e.Y, 1, 1).IntersectsWith(r))
                                            {
                                                lastSelectedRectangle = r;
                                                int doordir = (i / 12);
                                                if ((room.selectedObject[0] as object_door).door_pos != (byte)((i * 2) - (doordir * 12)) || (room.selectedObject[0] as object_door).door_dir != (byte)(doordir))
                                                {
                                                    (room.selectedObject[0] as object_door).door_pos = (((byte)((i - (doordir * 12)) * 2)));
                                                    (room.selectedObject[0] as object_door).door_dir = ((byte)(doordir));
                                                    (room.selectedObject[0] as object_door).updateId();
                                                    (room.selectedObject[0] as object_door).DrawOnBitmap();


                                                }
                                                need_refresh = true;
                                                break;

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selection_resize = false;

                if (mouse_down == true)
                {
                    anychange = true;
                    mouse_down = false;
                    need_refresh = true;
                    if (room.selectedObject.Count == 0) //if we don't have any objects select we select what is in the rectangle
                    {
                        getObjectsRectangle();
                    }
                    else
                    {
                        setObjectsPosition();
                    }

                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                nothingselectedcontextMenu.Items[0].Enabled = true;
                singleselectedcontextMenu.Items[0].Enabled = true;
                groupselectedcontextMenu.Items[0].Enabled = true;
                string nname = "Unknown";
                if (selectedLayer >= 0)
                {
                    nname = "Object";
                    if (selectedLayer == 3)
                    {
                        nothingselectedcontextMenu.Items[0].Enabled = false;
                        singleselectedcontextMenu.Items[0].Enabled = false;
                        groupselectedcontextMenu.Items[0].Enabled = false;
                    }
                }
                else if (spritemodeButton.Checked == true)
                {
                    nname = "Sprite";
                }
                else if (chestmodeButton.Checked == true)
                {
                    nname = "Chest Item";
                }
                else if (potmodeButton.Checked == true)
                {
                    nname = "Pot Item";
                }
                nothingselectedcontextMenu.Items[0].Text = "Insert new " + nname;
                singleselectedcontextMenu.Items[0].Text = "Insert new " + nname;
                groupselectedcontextMenu.Items[0].Text = "Insert new " + nname;
                if (room.selectedObject.Count == 0)
                {
                    nothingselectedcontextMenu.Show(Cursor.Position);
                }
                else if (room.selectedObject.Count == 1)
                {
                    singleselectedcontextMenu.Show(Cursor.Position);
                }
                else if (room.selectedObject.Count > 1)
                {
                    groupselectedcontextMenu.Show(Cursor.Position);
                }
            }

        }
        //====================================================================
        //End of the picturebox1 (Main draw window), handlings               |
        //====================================================================
        Charactertable table_char = new Charactertable(true);
        private void Form1_Load(object sender, EventArgs e)
        {
            actionsListbox.DisplayMember = "Name";
            palettePicturebox.Image = new Bitmap(256, 340);
            paletteViewer = new PaletteViewer(palettePicturebox);
            mapPicturebox.Image = new Bitmap(256, 304);

#if DEBUG
            openRomFileDialog.FileName = "C:\\zscream\\randotest.sfc";
            byte[] tempRom;
            FileStream fs = new FileStream("C:\\zscream\\randotest.sfc", FileMode.Open, FileAccess.Read);
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
#endif
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save Functions
            //Expand ROM to 2MB
            if (anychange == true)
            {
                DialogResult dialogResult = MessageBox.Show("Room has changed. Do you want to save changes?", "Save", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    all_rooms[room.index] = room;
                }
            }

            byte[] romBackup = (byte[])ROM.DATA.Clone();
            Save save = new Save(all_rooms);
            if (save.saveRoomsHeaders())
            {

            }
            if (save.saveallChests())
            {
                MessageBox.Show("Failed to save, there is too many chest items", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveallSprites())
            {

            }
            if (save.saveAllObjects())
            {

            }
            if (save.saveallPots())
            {

            }
            if (save.saveBlocks())
            {
                MessageBox.Show("Failed to save, there is too many pushable blocks", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveAllPits())
            {

            }

            FileStream fs = new FileStream(openRomFileDialog.FileName, FileMode.Open, FileAccess.Write);
            fs.Write(ROM.DATA, 0, 0x200000);
            fs.Close();
        }

        public void initChestGfx()
        {
            int length = 75;
            if (Constants.Rando == true)
            {
                length = 75;
            }
            for (int i = 0; i < length; i++)
            {
                GFX.chestitems_bitmap[i] = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
                GFX.begin_draw(GFX.chestitems_bitmap[i], 16, 16);
                new Chest(0, 0, (byte)i, false, true).ItemsDraw((byte)i, 0, 0);
                GFX.end_draw(GFX.chestitems_bitmap[i]);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openRomFileDialog.ShowDialog();
        }

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
                title += (char)ROM.DATA[0x07FC0 + i];
            }
            return title;
        }

        short[][] dungeons_rooms = new short[15][];

        public void loadRoomList(int roomId)
        {


            if (radioButton1.Checked)
            {
                roomListBox.Items.Clear();
                for (int i = 0; i < 296; i++)
                {
                    roomListBox.Items.Add(new ListRoomName(i, "[" + i + "] " + room_names.room_name[i]));

                }
                roomListBox.SelectedIndex = 260;
            }
            else if (radioButton2.Checked)
            {
                int xd = 0;
                int yd = 0;

                using (Graphics g = Graphics.FromImage(mapPicturebox.Image))
                {
                    g.Clear(Color.Black);
                    for (int i = 0; i < 296; i++)
                    {
                        if (all_rooms[i].tilesObjects.Count > 0)
                        {
                            GFX.LoadDungeonPalette(all_rooms[i].palette);
                            g.FillRectangle(new SolidBrush(GFX.loadedPalettes[4, 2]), new Rectangle(xd * 16, yd * 16, 16, 16));
                        }
                        xd++;
                        if (xd == 16)
                        {
                            yd++;
                            xd = 0;
                        }
                    }
                    for (int i = 0; i < 19; i++)
                    {
                        g.DrawLine(Pens.White, 0, i * 16, 256, i * 16);
                        g.DrawLine(Pens.White, i * 16, 0, i * 16, 304);
                    }
                    yd = (roomId / 16);
                    xd = roomId - (yd * 16);
                    g.DrawRectangle(new Pen(Color.Red, 2), new Rectangle((xd * 16), (yd * 16), 16, 16));

                }
                mapPicturebox.Refresh();
            }



        } //That will be removed in the future

        public void load_default_room()
        {
            tabControl1.Enabled = true;

            byte[] bpp3data = Compression.DecompressTiles(); //decompress almost all the gfx from the game
            GFX.gfxdata = Compression.bpp3tobpp4(bpp3data); //transform them into 4bpp

            int totalSize = 0;
            for (int i = 0; i < 296; i++)
            {
                all_rooms[i] = (new Room(i)); // create all rooms
                totalSize += all_rooms[i].roomSize;
            }
            Console.WriteLine(totalSize.ToString("X6"));


            roomListBox.Items.Clear();
            roomListBox.ValueMember = "Name";
            Room_Name room_names = new Room_Name();
            loadRoomList(260);
            initChestGfx();
            for (int i = 0; i < 75; i++)
            {
                chestpicker.listView1.Items.Add(ChestItems_Name.name[i]);
                chestpicker.listView1.Items[i].ImageIndex = i;
            }
            chestpicker.chestItemsImagesList.Images.AddRange(GFX.chestitems_bitmap);
            chestpicker.listView1.LargeImageList = chestpicker.chestItemsImagesList;


            objectSelector.room = all_rooms[260];
            room.bg2 = Background2.Normal;
            objectSelector.createObjects();

            roomListBox.SelectedIndex = 260;//set start room on link's house
            paletteViewer.update();

            bg3modeButton.Enabled = true;
            bg2modeButton.Enabled = true;
            bg1modeButton.Enabled = true;
            allbgsButton.Enabled = true;
            chestmodeButton.Enabled = true;
            saveButton.Enabled = true;
            blockmodeButton.Enabled = true;
            torchmodeButton.Enabled = true;
            spritemodeButton.Enabled = true;
            potmodeButton.Enabled = true;
            doormodeButton.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            warpmodeButton.Enabled = true;
            saveLayoutButton.Enabled = true;
            loadlayoutButton.Enabled = true;
            foreach (object ti in editToolStripMenuItem.DropDownItems)
            {
                if (ti is ToolStripDropDownItem)
                {
                    (ti as ToolStripDropDownItem).Enabled = true;
                }
            }
            pictureBox2.Image = GFX.singletobmp();
            entranceListBox.Items.Clear();
            for (int i = 0; i < 0x84; i++)
            {
                entranceListBox.Items.Add("Entrance " + i.ToString("X2"));
            }
            project_loaded = true;
            updateTimer.Enabled = true;
            pictureBox1.Image = roomBitmap;
            g = Graphics.FromImage(roomBitmap);
            need_refresh = true;

        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            drawRoom();
        }

        public enum ObjectResize
        {
            None, Left, Right, Up, Down, UpLeft, UpRight, DownLeft, DownRight
        }

        public void objects_ResizeMouseMove(MouseEventArgs e)
        {
            int rightBorder = ((room.selectedObject[0] as Room_Object).x * 8) + (room.selectedObject[0] as Room_Object).width;
            int bottomBorder = ((room.selectedObject[0] as Room_Object).y * 8) + (room.selectedObject[0] as Room_Object).height;
            int leftBorder = ((room.selectedObject[0] as Room_Object).x * 8);
            int topBorder = ((room.selectedObject[0] as Room_Object).y * 8);

            if (mouse_down == false)
            {
                resizing = ObjectResize.None;
                Room_Object obj = (room.selectedObject[0] as Room_Object);
                if ((obj.id >= 0x00 && obj.id <= 0x5F) || (obj.id >= 0xA0 && obj.id <= 0xBF) || (obj.id >= 0xC0 && obj.id <= 0xF7)) //horizontally scrollable
                {
                    if (e.X >= (rightBorder - 2) && e.X <= (rightBorder + 4) && //right
                        e.Y >= topBorder + 2 && e.Y <= bottomBorder - 2)
                    {
                        Cursor.Current = Cursors.SizeWE;
                        resizing = ObjectResize.Right;

                    }
                }
                /*else if (e.X >= (leftBorder - 4) && e.X <= (leftBorder + 2) && //left
                    e.Y >= topBorder + 2 && e.Y <= bottomBorder - 2)
                {
                    Cursor.Current = Cursors.SizeWE;
                    resizing = ObjectResize.Left;
                }
                else if (e.X >= (leftBorder + 4) && e.X <= (rightBorder - 4) && //up
                    e.Y >= topBorder - 4 && e.Y <= topBorder + 2)
                {
                    Cursor.Current = Cursors.SizeNS;
                    resizing = ObjectResize.Up;
                }*/
                if ((obj.id >= 0x60 && obj.id <= 0x96) || (obj.id >= 0xA0 && obj.id <= 0xAF) || (obj.id >= 0xC0 && obj.id <= 0xF7))
                {
                    if (e.X >= (leftBorder + 4) && e.X <= (rightBorder - 4) && //down
                    e.Y >= bottomBorder - 2 && e.Y <= bottomBorder + 4)
                    {
                        Cursor.Current = Cursors.SizeNS;
                        resizing = ObjectResize.Down;
                    }
                }
                /*else if (e.X >= (leftBorder - 4) && e.X <= (leftBorder + 2) && //diagonal up left
                    e.Y >= topBorder - 4 && e.Y <= topBorder + 2)
                {
                    Cursor.Current = Cursors.SizeNWSE;
                    resizing = ObjectResize.UpLeft;
                }
                else if (e.X >= (rightBorder - 2) && e.X <= (rightBorder + 4) && //diagonal bottom right
                    e.Y >= bottomBorder - 2 && e.Y <= bottomBorder + 4)
                {
                    Cursor.Current = Cursors.SizeNWSE;
                    resizing = ObjectResize.DownRight;
                }
                else if (e.X >= (rightBorder - 2) && e.X <= (rightBorder + 4) && //diagonal up right
                    e.Y >= topBorder - 4 && e.Y <= topBorder + 2)
                {
                    Cursor.Current = Cursors.SizeNESW;
                    resizing = ObjectResize.UpRight;
                }
                else if (e.X >= (leftBorder - 4) && e.X <= (leftBorder + 2) && //diagonal bottom left
                    e.Y >= bottomBorder - 2 && e.Y <= bottomBorder + 4)
                {
                    Cursor.Current = Cursors.SizeNESW;
                    resizing = ObjectResize.DownLeft;
                }*/
            }
            else
            {
                if (resizing != ObjectResize.None)
                {
                    if (resizing == ObjectResize.Right)
                    {
                        Cursor.Current = Cursors.SizeWE;
                        dragx = (room.selectedObject[0] as Room_Object).x;
                    }
                    else if (resizing == ObjectResize.Down)
                    {
                        Cursor.Current = Cursors.SizeNS;
                        dragy = (room.selectedObject[0] as Room_Object).y;
                    }
                }
            }
        }

        public void setMouseSizeMode(MouseEventArgs e)
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
            else if (selectedLayer >= 0)
            {
                mx = ((e.X) / 8);
                my = ((e.Y) / 8);
            }
            else if (torchmodeButton.Checked || blockmodeButton.Checked)
            {
                mx = ((e.X) / 8);
                my = ((e.Y) / 8);
            }

            move_x = mx - dragx; //number of tiles mouse is compared to starting drag point X
            move_y = my - dragy; //number of tiles mouse is compared to starting drag point Y
        }

        public void resizing_objects()
        {
            if (mx != last_mx || my != last_my)
            {
                //TODO : Finish resizing objects, only right side is working !
                anychange = true; //will prompt room has changed dialog
                last_mx = mx;
                last_my = my;
                need_refresh = true;
                Room_Object obj = (room.selectedObject[0] as Room_Object);
                //move_x = nbr of tiles the mouse moved x axis from drag
                //move_y = nbr of tiles the mouse moved y axis from drag
                if (resizing == ObjectResize.Right)
                {

                    //0C0 to 0F7

                    if ((obj.id >= 0x00 && obj.id <= 0x5F) || (obj.id >= 0xA0 && obj.id <= 0xBF) || (obj.id >= 0xC0 && obj.id <= 0xF7)) //horizontally scrollable
                    {
                        byte w = obj.base_width;
                        if ((obj.id >= 0xC0 && obj.id <= 0xF7))
                        {
                            if (move_x > w - 1)
                            {
                                byte sizeX = (byte)((move_x - w) / obj.scroll_x);

                                if ((sizeX >= 03))
                                {
                                    sizeX = 03;
                                }
                                else if (sizeX <= 0)
                                {
                                    sizeX = 0;
                                }
                                obj.size = (byte)(((sizeX & 03) << 2) + (obj.size & 0x03));
                                if (obj.oldSize != obj.size)
                                {
                                    obj.resetSize();
                                    obj.DrawOnBitmap();
                                    obj.oldSize = obj.size;
                                }
                            }
                        }
                        else
                        {
                            if (obj.special_zero_size != 0)
                            {
                                w = 0;
                            }
                            if (move_x > w - 1)
                            {
                                obj.size = (byte)((move_x - w) / obj.scroll_x);

                                if ((obj.size >= 15))
                                {
                                    if (obj.special_zero_size != 0)
                                    {
                                        obj.size = 0;
                                    }
                                    else
                                    {
                                        obj.size = 15;
                                    }
                                }
                                else if (obj.size <= 0)
                                {
                                    if (obj.special_zero_size != 0)
                                    {
                                        obj.size = 1;
                                    }
                                    else
                                    {
                                        obj.size = 0;
                                        obj.DrawOnBitmap();
                                    }
                                }

                                if (obj.oldSize != obj.size)
                                {
                                    obj.resetSize();
                                    obj.DrawOnBitmap();
                                    obj.oldSize = obj.size;
                                }
                            }
                            else if (move_x < obj.base_width)
                            {
                                if (obj.special_zero_size != 0)
                                {
                                    obj.size = 1;
                                }
                                else
                                {
                                    obj.size = 0;
                                    obj.DrawOnBitmap();
                                }
                            }
                        }
                    }

                }
                else if (resizing == ObjectResize.Down)
                {
                    if ((obj.id >= 0x60 && obj.id <= 0x96) || (obj.id >= 0xA0 && obj.id <= 0xAF) || (obj.id >= 0xC0 && obj.id <= 0xF7)) //vertically scrollable
                    {
                        byte h = obj.base_height;
                        if ((obj.id >= 0xC0 && obj.id <= 0xF7))
                        {
                            if (move_y > h - 1)
                            {
                                byte sizeY = (byte)((move_y - h) / obj.scroll_y);

                                if ((sizeY >= 03))
                                {
                                    sizeY = 03;
                                }
                                else if (sizeY <= 0)
                                {
                                    sizeY = 0;
                                }
                                obj.size = (byte)(((obj.size & 0x0C)) + (sizeY & 03));
                                if (obj.oldSize != obj.size)
                                {
                                    obj.resetSize();
                                    obj.DrawOnBitmap();
                                    obj.oldSize = obj.size;
                                }
                            }
                        }
                        else
                        {
                            if (obj.special_zero_size != 0)
                            {
                                h = 0;
                            }
                            if (move_y > h - 1)
                            {
                                obj.size = (byte)((move_y - h) / obj.scroll_y);

                                if ((obj.size >= 15))
                                {
                                    if (obj.special_zero_size != 0)
                                    {
                                        obj.size = 0;
                                    }
                                    else
                                    {
                                        obj.size = 15;
                                    }
                                }
                                else if (obj.size <= 0)
                                {
                                    if (obj.special_zero_size != 0)
                                    {
                                        obj.size = 1;
                                    }
                                    else
                                    {
                                        obj.size = 0;
                                        obj.DrawOnBitmap();
                                    }
                                }

                                if (obj.oldSize != obj.size)
                                {
                                    obj.resetSize();
                                    obj.DrawOnBitmap();
                                    obj.oldSize = obj.size;
                                }
                            }
                            else if (move_y < obj.base_width)
                            {
                                if (obj.special_zero_size != 0)
                                {
                                    obj.size = 1;
                                }
                                else
                                {
                                    obj.size = 0;
                                    obj.DrawOnBitmap();
                                }
                            }
                        }
                    }
                }

            }
        }

        private void gotoRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            change_room((roomListBox.SelectedItem as ListRoomName).id);
        }

        public void clear_room()
        {
            if (room != null)
            {
                redoRooms.Clear();
                actionsListbox.Items.Clear();
                room.selectedObject.Clear();
            }
        }

        public void change_room(int roomId)
        {
            need_refresh = true;
            room_loaded = false;
            if (anychange)
            {
                if (roomId != lastRoom)
                {
                    DialogResult dialogResult = MessageBox.Show("Room has changed. Do you want to keep changes?", "Keep Changes", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        clear_room();
                        save_room(lastRoom);
                        room = (Room)all_rooms[roomId].Clone();
                        lastRoom = roomId;
                        anychange = false;
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        roomListBox.SelectedIndex = lastRoom;
                    }
                    else
                    {
                        clear_room();
                        room = (Room)all_rooms[roomId].Clone();
                        lastRoom = roomId;
                        anychange = false;
                    }
                }
            }
            else
            {
                clear_room();
                room = (Room)all_rooms[roomId].Clone();
                lastRoom = roomId;
            }
            room.reloadGfx();
            need_refresh = true;
            paletteViewer.update();
            floor1UpDown.Value = room.floor1;
            floor2UpDown.Value = room.floor2;
            roomgfxUpDown.Value = room.blockset;
            paletteUpDown.Value = room.palette;
            spritesetUpDown.Value = room.spriteset;
            layoutUpDown.Value = room.layout;
            collisioncomboBox.SelectedIndex = room.collision;
            tag1comboBox.SelectedIndex = room.tag1;
            tag2comboBox.SelectedIndex = room.tag2;
            effectcomboBox.SelectedIndex = room.effect;
            messageidUpDown.Value = room.messageid;
            pithurtcheckbox.Checked = room.damagepit;
            undoRooms.Clear();
            redoRooms.Clear();

            room_loaded = true;
        }

        public void save_room(int roomId)
        {
            all_rooms[roomId] = room;
        }

        public void drawObject(Graphics g, Room_Object o)
        {
            if ((o.options & ObjectOption.Door) != ObjectOption.Door)
            {
                if (o.specialDraw)
                {
                    if (o is object_69 || o is object_8A) //vertical objects
                    {
                        g.DrawImage(o.bitmap, o.nx * 8, ((o.drawYFix * 8) + o.ny * 8) + 8, new Rectangle(0, 8, o.bitmap.Width, o.bitmap.Height), GraphicsUnit.Pixel);
                    }
                    else if (o is object_3F || o is object_40 || o is object_41 || o is object_42 || o is object_43 || o is object_44 || o is object_46 || o is object_2A || o is object_29 || o is object_22) //horizontal objects
                    {
                        g.DrawImage(o.bitmap, (o.nx * 8) + 8, ((o.drawYFix * 8) + o.ny * 8), new Rectangle(8, 0, o.bitmap.Width, o.bitmap.Height), GraphicsUnit.Pixel);
                    }
                }
                else
                {
                    g.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + o.ny * 8);
                }
            }
        }

        public void drawDoors(Graphics g, Room_Object o)
        {
            if ((o.options & ObjectOption.Door) == ObjectOption.Door)
            {
                if (o is object_door)
                {
                    if ((o.id & 0xFF00) == 0x1200)
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        GraphicsPath gpath = new GraphicsPath();
                        gpath.AddString("Exit", new FontFamily("Consolas"), 1, 12, new Point(o.x * 8, ((o.y) * 8) + 8), StringFormat.GenericDefault);
                        Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
                        g.DrawPath(pen, gpath);
                        SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                        g.FillPath(brush, gpath);

                        return;
                    }
                    if ((o.id & 0xFF00) == 0x1600)
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        GraphicsPath gpath = new GraphicsPath();
                        gpath.AddString("toBG2", new FontFamily("Consolas"), 1, 12, new Point(o.x * 8, ((o.y) * 8) + 8), StringFormat.GenericDefault);
                        Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
                        g.DrawPath(pen, gpath);
                        SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                        g.FillPath(brush, gpath);

                        return;
                    }

                    if ((o as object_door).door_dir == 0)
                    {
                        if ((o as object_door).door_pos >= 12)
                        {
                            int drawPos = 9;
                            if ((o as object_door).door_pos <= 16)
                            {
                                drawPos = 9;
                            }
                            else
                            {
                                drawPos = 15;
                            }
                            o.bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            g.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + (o.ny - drawPos) * 8);
                            o.bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        }
                    }
                }
                if (o is object_door)
                {
                    if ((o as object_door).door_dir == 2)
                    {
                        if ((o as object_door).door_pos >= 12)
                        {
                            int drawPos = 7;
                            if ((o as object_door).door_pos <= 16)
                            {
                                drawPos = 7;
                            }
                            else
                            {
                                drawPos = 13;
                            }
                            o.bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            g.DrawImage(o.bitmap, (o.nx - drawPos) * 8, (o.drawYFix * 8) + (o.ny) * 8);
                            o.bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        }
                    }
                }
                g.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + o.ny * 8);
            }
        }

        public void undoredoButtonsEnables()
        {
            if (undoRooms.Count > 0)
            {
                undoButton.Enabled = true;
            }
            else
            {
                undoButton.Enabled = false;
            }
            if (redoRooms.Count > 0)
            {
                redoButton.Enabled = true;
            }
            else
            {
                redoButton.Enabled = false;
            }
        }

        public void addSpecialErasedDraw()
        {
            borderlessobject.Clear();
            for (int i = 0; i < room.tilesObjects.Count - 1; i++)
            {
                Room_Object o = room.tilesObjects[i];
                o.specialDraw = false;
                if (o is object_69 || o is object_8A || o is object_3F || o is object_40 || o is object_41 || o is object_42 || o is object_43 || o is object_44 || o is object_46 || o is object_2A || o is object_29 || o is object_22)
                {
                    borderlessobject.Add(o);
                }
                foreach (Room_Object bo in borderlessobject)
                {
                    if (o is object_69 || o is object_8A || o is object_3F || o is object_40 || o is object_41 || o is object_42 || o is object_43 || o is object_44 || o is object_46 || o is object_2A || o is object_29 || o is object_22)
                    {
                        if (o != bo)
                        {
                            if (new Rectangle(o.nx * 8, o.ny * 8, 8, 8).IntersectsWith(new Rectangle(bo.nx * 8, bo.ny * 8, bo.width, bo.height)))
                            {
                                o.specialDraw = true;
                            }
                        }
                    }
                }
            }
        }

        public void drawLayer1and3plusDoors()
        {
            using (Graphics gg = Graphics.FromImage(GFX.bg1_bitmap))
            {

                gg.DrawImage(GFX.bgr_bitmap, 0, 0); //floor 1

                foreach (Room_Object o in room.tilesObjects)
                {
                    if (o.layer == 0 || o.allBgs == true)
                    {
                        drawObject(gg, o);
                    }
                }

                foreach (Room_Object o in room.tilesObjects)
                {
                    if (o.layer == 2)
                    {
                        drawObject(gg, o);
                    }
                }

                foreach (Room_Object o in room.tilesObjects)
                {
                    drawDoors(gg, o);
                }

            }
        }

        public void drawLayout()
        {
            using (Graphics gg = Graphics.FromImage(GFX.bgr_bitmap))
            {

                foreach (Room_Object o in room.tilesLayoutObjects)
                {
                    gg.DrawImage(o.bitmap, (o.nx * 8), ((o.drawYFix * 8) + o.ny * 8));
                }

            }
        }

        public void drawLayer2()
        {
            using (Graphics gg = Graphics.FromImage(GFX.bg2_bitmap))
            {
                using (Graphics ggT = Graphics.FromImage(GFX.bg2_trans_bitmap))
                {
                    ggT.Clear(Color.Transparent);
                    gg.DrawImage(GFX.floor2_bitmap, 0, 0);

                    foreach (Room_Object o in room.tilesObjects)
                    {
                        if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr)
                        {
                            if (o.layer == 1 || o.allBgs)
                            {

                                if (!o.allBgs)
                                {
                                    if (room.bg2 == Background2.Transparent || room.bg2 == Background2.Translucent)
                                    {
                                        ggT.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + o.ny * 8);
                                    }
                                    else
                                    {
                                        gg.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + o.ny * 8);
                                    }
                                }
                                else
                                {

                                    gg.DrawImage(o.bitmap, o.nx * 8, (o.drawYFix * 8) + o.ny * 8);
                                }

                            }
                        }
                    }
                }
            }
        }

        public void drawLayersOnBgr()
        {
            g.Clear(Color.Black);
            GFX.bg2_bitmap.MakeTransparent(Color.Fuchsia);
            GFX.bg1_bitmap.MakeTransparent(Color.Fuchsia);
            GFX.bg2_trans_bitmap.MakeTransparent(Color.Fuchsia);
            if (room.bg2 == Background2.OnTop || room.bg2 == Background2.Transparent || room.bg2 == Background2.Translucent)
            {

                ColorMatrix cm = new ColorMatrix();
                cm.Matrix00 = cm.Matrix11 = cm.Matrix22 = cm.Matrix44 = 1;
                cm.Matrix33 = 0.5f;
                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm);

                if (showBG1ToolStripMenuItem.Checked)
                {
                    if (room.bg2 == Background2.Transparent)
                    {
                        g.DrawImage(GFX.bg2_bitmap, 0, 0);
                    }
                    g.DrawImage(GFX.bg1_bitmap, 0, 0);
                }
                if (showBG2ToolStripMenuItem.Checked)
                {
                    if (room.bg2 == Background2.OnTop)
                    {
                        g.DrawImage(GFX.bg2_bitmap, 0, 0);
                    }
                    g.DrawImage(GFX.bg2_trans_bitmap, new Rectangle(0, 0, 512, 512), 0, 0, 512, 512, GraphicsUnit.Pixel, ia);
                }
            }
            else
            {
                if (showBG2ToolStripMenuItem.Checked)
                {
                    g.DrawImage(GFX.bg2_bitmap, 0, 0);
                }
                if (showBG1ToolStripMenuItem.Checked)
                {
                    g.DrawImage(GFX.bg1_bitmap, 0, 0);
                }
            }
        }

        public void drawGrid()
        {
            if (showGridToolStripMenuItem.Checked)
            {
                for (int x = 0; x < 32; x++)
                {
                    g.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), x * 16, 0, x * 16, 512);
                }
                for (int y = 0; y < 32; y++)
                {
                    g.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), 0, y * 16, 512, y * 16);
                }
            }
        }

        public void drawChests()
        {
            if (room.chest_list.Count > 0)
            {
                int chest_count = 0;
                foreach (Room_Object o in room.tilesObjects)
                {
                    if (((o as Room_Object).options & ObjectOption.Chest) == ObjectOption.Chest)
                    {
                        if (room.chest_list.Count > chest_count)
                        {
                            room.chest_list[chest_count].x = (o as Room_Object).nx;
                            room.chest_list[chest_count].y = (o as Room_Object).ny;
                        }
                        chest_count++;
                    }
                }
                foreach (Chest c in room.chest_list)
                {
                    if (c.item < 75)
                    {
                        g.DrawImage(GFX.chestitems_bitmap[c.item], (c.x * 8), (c.y - 2) * 8);
                    }
                }
            }
        }

        public void drawSprites()
        {
            GFX.begin_draw(roomBitmap);
            room.drawSprites();
            GFX.end_draw(roomBitmap);
            if (showTextSprite)
            {
                DrawSpritesTexts();
                need_refresh = true;
            }
        }
        public void DrawSpritesTexts()
        {
            foreach (Sprite spr in room.sprites)
            {

                g.DrawString("(" + spr.layer + ") " + spr.name, this.Font, Brushes.Azure, new Point(spr.x * 16, spr.y * 16));
            }
        }

        public void drawSelection()
        {
            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    g.DrawRectangle(Pens.Green, (o as Sprite).boundingbox);
                }
                else if (o is PotItem)
                {
                    g.DrawRectangle(Pens.Green, new Rectangle((o as PotItem).nx * 8, (o as PotItem).ny * 8, 16, 16));
                }
                else if (o is Room_Object)
                {
                    g.DrawRectangle(Pens.Green, new Rectangle(((o as Room_Object).nx) * 8, ((o as Room_Object).ny + (o as Room_Object).drawYFix) * 8, (o as Room_Object).width, (o as Room_Object).height));
                }
            }

            if (mouse_down)
            {
                int rx = dragx;
                int ry = dragy;
                if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
                if (move_y < 0) { Math.Abs(ry = dragy + move_y); }


                if (room.selectedObject.Count == 0)
                {
                    if (spritemodeButton.Checked)
                    {
                        g.DrawRectangle(new Pen(Brushes.White), new Rectangle(rx * 16, ry * 16, Math.Abs(move_x) * 16, Math.Abs(move_y) * 16));
                    }
                    else
                    {
                        g.DrawRectangle(new Pen(Brushes.White), new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8));
                    }
                }


                foreach (Object o in room.selectedObject)
                {
                    if (o is Sprite)
                    {
                        g.DrawRectangle(Pens.LimeGreen, (o as Sprite).boundingbox);
                    }
                    else if (o is PotItem)
                    {
                        g.DrawRectangle(Pens.LimeGreen, new Rectangle((o as PotItem).nx * 8, (o as PotItem).ny * 8, 16, 16));
                    }
                    else if (o is Room_Object)
                    {
                        g.DrawRectangle(Pens.LimeGreen, new Rectangle(((o as Room_Object).nx) * 8, ((o as Room_Object).ny + (o as Room_Object).drawYFix) * 8, (o as Room_Object).width, (o as Room_Object).height));
                    }
                }
            }
        }

        public void drawEntrancePosition()
        {
            if (entranceposCheckbox.Checked)
            {
                short yPosition = (short)(((ROM.DATA[(Constants.entrance_yposition + (entranceListBox.SelectedIndex * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.entrance_yposition + (entranceListBox.SelectedIndex * 2)]);
                short xPosition = (short)(((ROM.DATA[(Constants.entrance_xposition + (entranceListBox.SelectedIndex * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.entrance_xposition + (entranceListBox.SelectedIndex * 2)]);
                g.DrawLine(new Pen(Color.FromArgb(255, 255, 200, 16)), xPosition - 8, yPosition, xPosition + 8, yPosition);
                g.DrawLine(new Pen(Color.FromArgb(255, 255, 200, 16)), xPosition, yPosition - 8, xPosition, yPosition + 8);
            }
        }

        public void drawDoorsPosition()
        {
            if (mouse_down)
            {
                if (room.selectedObject.Count > 0)
                {
                    if (room.selectedObject[0] is Room_Object)
                    {
                        if (((room.selectedObject[0] as Room_Object).options & ObjectOption.Door) == ObjectOption.Door)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                g.DrawRectangles(new Pen(new SolidBrush(Color.FromArgb(10, 0, 200, 0))), doorArray);
                            }
                        }
                    }
                }
            }
        }
        short[] doorsObject = new short[] { 0x13B, 0x138, 0x139, 0x12E, 0x12D, 0x4632, 0x4693 };

        public void drawWarp()
        {
            bool foundWarp = false;
            int doorCount = 0;
            int indexEG2 = 0;
            if (room.index > 255)
            {
                indexEG2 = 256;
            }
            foreach (Room_Object o in room.tilesObjects)
            {
                if (doorCount < 4)
                {
                    if (doorsObject.Contains(o.id))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        GraphicsPath gpath = new GraphicsPath();
                        gpath.AddString("To : " + (room.staircase_rooms[doorCount] + indexEG2).ToString(), new FontFamily("Consolas"), 1, 12, new Point(o.x * 8, o.y * 8), StringFormat.GenericDefault);
                        Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
                        g.DrawPath(pen, gpath);
                        SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                        g.FillPath(brush, gpath);

                        //g.DrawString("To : " + room.staircase_rooms[doorCount].ToString(), new Font("Arial", 10), Brushes.White, o.x*8, o.y*8);
                        doorCount++;
                    }
                }
                if (o.id == 0xFCA)
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    GraphicsPath gpath = new GraphicsPath();
                    gpath.AddString("To : " + (room.holewarp + indexEG2).ToString(), new FontFamily("Consolas"), 1, 12, new Point(o.x * 8, o.y * 8), StringFormat.GenericDefault);
                    Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
                    g.DrawPath(pen, gpath);
                    SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                    g.FillPath(brush, gpath);
                    //g.DrawString("To : " + room.holewarp.ToString(), new Font("Arial", 10), Brushes.White, o.x * 8, o.y * 8);
                    //warp
                    foundWarp = true;
                }
            }
            if (foundWarp == false)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                GraphicsPath gpath = new GraphicsPath();
                gpath.AddString("Hole : " + (room.holewarp + indexEG2).ToString(), new FontFamily("Consolas"), 1, 12, new Point(4, 4), StringFormat.GenericDefault);
                Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
                g.DrawPath(pen, gpath);
                SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                g.FillPath(brush, gpath);
                //g.DrawString("To : " + room.holewarp.ToString(), new Font("Arial", 10), Brushes.White, o.x * 8, o.y * 8);
                //warp
            }
        }

        public void drawRoom()
        {

            if (room.needGfxRefresh)
            {
                room.needGfxRefresh = false;
            }

            if (need_refresh)
            {
                updateSelectionObject();
                undoredoButtonsEnables();
                addSpecialErasedDraw();
                drawLayout();
                drawLayer1and3plusDoors();
                drawLayer2();
                drawLayersOnBgr();
                drawChests();
                drawSprites();
                GFX.begin_draw(roomBitmap);
                room.drawPotsItems();
                GFX.end_draw(roomBitmap);
                drawWarp();
                drawGrid();
                drawSelection();
                drawEntrancePosition();
                drawDoorsPosition();
                pictureBox1.Refresh();
                need_refresh = false;
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }


        Room_Name room_names = new Room_Name();
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            loadRoomList(roomListBox.SelectedIndex);
            mapPicturebox.Refresh();
            need_refresh = true;
            if (radioButton2.Checked)
            {
                mapPicturebox.Visible = true;
                roomListBox.Visible = false;
            }
            else
            {
                mapPicturebox.Visible = false;
                roomListBox.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomListBox.Items.Clear();
            loadRoomList(260);
        }
        int selectedLayer = -1;
        public void update_modes_buttons(object sender, EventArgs e)
        {
            for (int i = 6; i < 17; i++)
            {
                (toolStrip1.Items[i] as ToolStripButton).Checked = false;
            }
            (sender as ToolStripButton).Checked = true;
            room.selectedObject.Clear();

            if (allbgsButton.Checked)
            {
                selectedLayer = 3;
            }
            else if (bg1modeButton.Checked)
            {
                selectedLayer = 0;
            }
            else if (bg2modeButton.Checked)
            {
                selectedLayer = 1;
            }
            else if (bg3modeButton.Checked)
            {
                selectedLayer = 2;
            }
            else
            {
                selectedLayer = -1;
            }
            //room.update();
            need_refresh = true;
            drawRoom();
        }

        public Bitmap[] sprites_bitmap = new Bitmap[0xF3];
        public Bitmap[] chest_items_bitmap = new Bitmap[176];
        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

                        //room.update();
                        drawRoom();

                    }
                }
            }
            else if (chestmodeButton.Checked)
            {
                Chest chestToRemove = null;
                bool foundChest = false;
                foreach (Chest c in room.chest_list)
                {
                    if (e.X >= (c.x * 8) && e.X <= (c.x * 8) + 16 &&
                        e.Y >= ((c.y - 2) * 8) && e.Y <= ((c.y) * 8) + 16)
                    {
                        chestpicker.button3.Enabled = true;
                        DialogResult result = chestpicker.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            //change chest item
                            c.item = (byte)chestpicker.listView1.SelectedIndices[0];

                        }
                        else if (result == DialogResult.No)
                        {
                            chestToRemove = c;
                        }
                        foundChest = true;
                        break;
                    }
                }
                if (foundChest == false)
                {
                    chestpicker.button3.Enabled = false;
                    DialogResult result = chestpicker.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //change chest item
                        Chest c = new Chest((byte)(e.X / 8), (byte)(e.Y / 8), (byte)chestpicker.listView1.SelectedIndices[0], false, false);
                        room.chest_list.Add(c);
                    }
                }

                if (chestToRemove != null)
                {
                    room.chest_list.Remove(chestToRemove);
                }
                need_refresh = true;
                anychange = true;
            }
            else if (selectedLayer >= 0 && selectedLayer < 3)
            {
                if (objectSelector.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem selectedItem = (ListViewItem)(objectSelector.tileobjectsListview.SelectedItems[0]);
                    Room_Object ro = room.addObject((short)selectedItem.Tag, (byte)mx, (byte)my, 0, (byte)selectedLayer);
                    anychange = true;
                    need_refresh = true;
                }
            }
        }
        PickObject objectSelector = new PickObject();
        PickChestItem chestpicker = new PickChestItem();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Room r = (Room)room.Clone();
            clearUselessRoomStuff(r);
            undoRooms.Add(r);

            foreach (Object o in room.selectedObject)
            {
                if (o is Room_Object)
                {
                    room.tilesObjects.Remove((o as Room_Object));
                }
                else if (o is Sprite)
                {
                    room.sprites.Remove((o as Sprite));
                }
                else if (o is PotItem)
                {
                    room.pot_items.Remove((o as PotItem));
                }
            }
            resizing = ObjectResize.None;
            selection_resize = false;
            redoRooms.Clear();
            room.selectedObject.Clear();
            need_refresh = true;
        }
        List<Room> undoRooms = new List<Room>();
        List<Room> redoRooms = new List<Room>();
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selection_resize = false;
            room.selectedObject.Clear();
            if (undoRooms.Count > 0)
            {
                Room r = (Room)room.Clone();
                clearUselessRoomStuff(r);
                redoRooms.Add(r);
                room = (Room)(undoRooms[undoRooms.Count - 1] as Room);

                foreach (Room_Object o in room.tilesObjects)
                {
                    o.nx = o.x;
                    o.ny = o.y;
                    o.size = o.savedSize;
                }
                foreach (Sprite o in room.sprites)
                {
                    o.nx = o.x;
                    o.ny = o.y;
                }
                foreach (PotItem o in room.pot_items)
                {
                    o.nx = o.x;
                    o.ny = o.y;
                }

                room.reloadGfx();
                need_refresh = true;

                undoRooms.RemoveAt(undoRooms.Count - 1);

            }

            //room.update();


        }

        public void clearUselessRoomStuff(Room r)
        {
            foreach (Object o in r.tilesObjects)
            {
                (o as Room_Object).bitmap = null;
            }

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (redoRooms.Count > 0)
            {
                Room r = (Room)room.Clone();
                clearUselessRoomStuff(r);
                undoRooms.Add(r);
                room = (redoRooms[redoRooms.Count - 1] as Room);
                foreach (Room_Object o in room.tilesObjects)
                {
                    o.nx = o.x;
                    o.ny = o.y;
                    o.size = o.savedSize;
                }
                foreach (Sprite o in room.sprites)
                {
                    o.nx = o.x;
                    o.ny = o.y;
                }
                foreach (PotItem o in room.pot_items)
                {
                    o.nx = o.x;
                    o.ny = o.y;
                }

                room.reloadGfx();
                need_refresh = true;
                redoRooms.RemoveAt(redoRooms.Count - 1);
            }
            room.selectedObject.Clear();

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Sprite spr in room.sprites)
            {
                room.selectedObject.Add(spr);
            }
            // room.update();
            drawRoom();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Clipboard.Clear();
            Room r = (Room)room.Clone();
            clearUselessRoomStuff(r);
            undoRooms.Add(r);

            List<SaveObject> odata = new List<SaveObject>();
            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    odata.Add(new SaveObject((Sprite)o));
                }
                if (o is PotItem)
                {
                    odata.Add(new SaveObject((PotItem)o));
                }
                if (o is Room_Object)
                {
                    odata.Add(new SaveObject((Room_Object)o));
                }

            }
            Clipboard.SetData("ObjectZ", odata);

            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    room.sprites.Remove((Sprite)o);
                }
                if (o is PotItem)
                {
                    room.pot_items.Remove((PotItem)o);
                }
                if (o is Room_Object)
                {
                    room.tilesObjects.Remove((Room_Object)o);
                }
            }
            room.selectedObject.Clear();
            need_refresh = true;
            redoRooms.Clear();
            /*
            Room r = (Room)room.Clone();
            clearUselessRoomStuff(r);
            undoRooms.Add(r);*/

        }



        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            List<SaveObject> data = (List<SaveObject>)Clipboard.GetData("ObjectZ");
            if (data.Count > 0)
            {
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
                    if (o.type == typeof(Sprite))
                    {
                        Sprite spr = (new Sprite(room, o.id, (byte)(o.x - most_x), (byte)(o.y - most_y), Sprites_Names.name[o.id], o.overlord, o.subtype, o.layer));
                        room.sprites.Add(spr);
                        room.selectedObject.Add(spr);
                    }
                    else if (o.type == typeof(Room_Object))
                    {
                        if ((o.options & ObjectOption.Door) == ObjectOption.Door)
                        {
                            object_door ro = new object_door(o.tid, o.x, o.y, 0, o.layer);
                            ro.setRoom(room);
                            ro.options = (ObjectOption)o.options;
                            room.tilesObjects.Add(ro);
                            room.selectedObject.Add(ro);

                        }
                        else
                        {
                            Room_Object ro = room.addObject(o.tid, (byte)(o.x - most_x), (byte)(o.y - most_y), o.size, o.layer);
                            if (ro != null)
                            {
                                ro.setRoom(room);
                                ro.options = (ObjectOption)o.options;
                                room.tilesObjects.Add(ro);
                                room.selectedObject.Add(ro);
                            }
                        }
                    }
                    else if (o.type == typeof(PotItem))
                    {
                        PotItem item = (new PotItem((byte)o.tid, (byte)(o.x - most_x), (byte)(o.y - most_y), (o.layer == 1 ? true : false)));
                        room.pot_items.Add(item);
                        room.selectedObject.Add(item);
                    }
                }

                dragx = 0;
                dragy = 0;
                mouse_down = true;
                need_refresh = true;
                room.reloadGfx();
            }


        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            List<SaveObject> odata = new List<SaveObject>();
            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    odata.Add(new SaveObject((Sprite)o));
                }
                if (o is PotItem)
                {
                    odata.Add(new SaveObject((PotItem)o));
                }
                if (o is Room_Object)
                {
                    odata.Add(new SaveObject((Room_Object)o));
                }
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
                room.spriteset = (byte)spritesetUpDown.Value;
                room.palette = (byte)paletteUpDown.Value;
                room.blockset = (byte)roomgfxUpDown.Value;
                room.layout = (byte)layoutUpDown.Value;
                room.collision = (byte)collisioncomboBox.SelectedIndex;
                room.tag1 = (byte)tag1comboBox.SelectedIndex;
                room.tag2 = (byte)tag2comboBox.SelectedIndex;
                room.effect = (byte)effectcomboBox.SelectedIndex;
                room.messageid = (byte)messageidUpDown.Value;
                need_refresh = true;
                room.reloadLayout();
                room.reloadGfx();
                anychange = true;
            }
        }


        private void palettePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseDown(e))
            {
                room.reloadGfx(true);
                need_refresh = true;
            }
        }

        private void palettePicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseUp(e))
            {
                room.reloadGfx(true);
                need_refresh = true;
            }
        }

        private void palettePicturebox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseDoubleclick(e, colorDialog1))
            {
                room.reloadGfx(true);
                need_refresh = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paletteViewer.randomizePalette(room.palette);
            room.reloadGfx(true);
            need_refresh = true;
        }

        public bool isMouseCollidingWith(Object o, MouseEventArgs e)
        {
            if (o is Sprite)
            {
                if (e.X >= (o as Sprite).boundingbox.X && e.X <= (o as Sprite).boundingbox.X + (o as Sprite).boundingbox.Width &&
                e.Y >= (o as Sprite).boundingbox.Y && e.Y <= (o as Sprite).boundingbox.Y + (o as Sprite).boundingbox.Height)
                {
                    return true;
                }
            }
            else if (o is PotItem)
            {
                if (e.X >= ((o as PotItem).x * 8) && e.X <= ((o as PotItem).x * 8) + 16 &&
                    e.Y >= ((o as PotItem).y * 8) && e.Y <= ((o as PotItem).y * 8) + 16)
                {
                    return true;
                }
            }
            else if (o is Room_Object)
            {
                if (e.X >= ((o as Room_Object).x * 8) && e.X <= (((o as Room_Object).x) * 8) + (o as Room_Object).width &&
                e.Y >= (((o as Room_Object).y + (o as Room_Object).drawYFix) * 8) && e.Y <= ((((o as Room_Object).y + (o as Room_Object).drawYFix)) * 8) + (o as Room_Object).height)
                {
                    return true;
                }
            }
            return false;
        }

        public void getObjectsRectangle()
        {
            if (room.selectedObject.Count == 0)
            {
                if (spritemodeButton.Checked) //we're looking for sprites
                {
                    foreach (Sprite spr in room.sprites)
                    {
                        int rx = dragx;
                        int ry = dragy;
                        if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
                        if (move_y < 0) { Math.Abs(ry = dragy + move_y); }

                        if (spr.boundingbox.IntersectsWith(new Rectangle(rx * 16, ry * 16, Math.Abs(move_x) * 16, Math.Abs(move_y) * 16)))
                        {
                            room.selectedObject.Add(spr);
                        }
                    }
                }
                else if (potmodeButton.Checked)//we're looking for pot items
                {
                    foreach (PotItem item in room.pot_items)
                    {
                        int rx = dragx;
                        int ry = dragy;
                        if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
                        if (move_y < 0) { Math.Abs(ry = dragy + move_y); }

                        if ((new Rectangle(item.x * 8, item.y * 8, 16, 16)).IntersectsWith(new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
                        {
                            room.selectedObject.Add(item);
                        }
                    }
                }
                else if (selectedLayer >= 0)//we're looking for tiles
                {

                    foreach (Room_Object o in room.tilesObjects)
                    {
                        int rx = dragx;
                        int ry = dragy;
                        if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
                        if (move_y < 0) { Math.Abs(ry = dragy + move_y); }

                        if ((new Rectangle((o as Room_Object).x * 8, ((o as Room_Object).y + (o as Room_Object).drawYFix) * 8, (o as Room_Object).width, (o as Room_Object).height)).IntersectsWith(new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
                        {
                            if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr && (o.options & ObjectOption.Door) != ObjectOption.Door && (o.options & ObjectOption.Torch) != ObjectOption.Torch && (o.options & ObjectOption.Block) != ObjectOption.Block)
                            {
                                if (selectedLayer == 3)
                                {
                                    room.selectedObject.Add(o);
                                }
                                else
                                {
                                    if (selectedLayer == o.layer)
                                    {
                                        room.selectedObject.Add(o);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {


                }
            }

        }

        public void setObjectsPosition()
        {
            if (room.selectedObject.Count > 0)
            {
                Room r = (Room)room.Clone();
                clearUselessRoomStuff(r);
                undoRooms.Add(r);

                if (spritemodeButton.Checked)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as Sprite).x = (o as Sprite).nx;
                        (o as Sprite).y = (o as Sprite).ny;
                        //(o as Sprite).boundingbox
                    }
                }
                else if (potmodeButton.Checked)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as PotItem).x = (o as PotItem).nx;
                        (o as PotItem).y = (o as PotItem).ny;
                    }
                }
                else if (selectedLayer >= 0)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as Room_Object).x = (o as Room_Object).nx;
                        (o as Room_Object).y = (o as Room_Object).ny;
                        (o as Room_Object).ox = (o as Room_Object).x;
                        (o as Room_Object).oy = (o as Room_Object).y;
                        (o as Room_Object).savedSize = (o as Room_Object).size;
                        (o as Room_Object).oldSize = (o as Room_Object).size;
                    }
                }
                else if (torchmodeButton.Checked)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as Room_Object).x = (o as Room_Object).nx;
                        (o as Room_Object).y = (o as Room_Object).ny;
                        (o as Room_Object).ox = (o as Room_Object).x;
                        (o as Room_Object).oy = (o as Room_Object).y;
                        (o as Room_Object).savedSize = (o as Room_Object).size;
                        (o as Room_Object).oldSize = (o as Room_Object).size;
                    }
                }
                else if (blockmodeButton.Checked)
                {
                    foreach (Object o in room.selectedObject)
                    {
                        (o as Room_Object).x = (o as Room_Object).nx;
                        (o as Room_Object).y = (o as Room_Object).ny;
                        (o as Room_Object).ox = (o as Room_Object).x;
                        (o as Room_Object).oy = (o as Room_Object).y;
                        (o as Room_Object).savedSize = (o as Room_Object).size;
                        (o as Room_Object).oldSize = (o as Room_Object).size;
                    }
                }
                need_refresh = true;
                redoRooms.Clear();
            }
        }

        public void move_objects()
        {
            byte chest_count = 0;
            foreach (Object o in room.selectedObject)
            {
                if (o is Sprite)
                {
                    (o as Sprite).nx = (byte)((o as Sprite).x + move_x);
                    (o as Sprite).ny = (byte)((o as Sprite).y + move_y);
                    if ((o as Sprite).nx > 80)
                    {
                        (o as Sprite).nx = 0;
                    }
                    if ((o as Sprite).ny > 80)
                    {
                        (o as Sprite).ny = 0;
                    }
                }
                else if (o is PotItem)
                {
                    (o as PotItem).nx = (byte)((o as PotItem).x + move_x);
                    (o as PotItem).ny = (byte)((o as PotItem).y + move_y);
                    if ((o as PotItem).nx > 80)
                    {
                        (o as PotItem).nx = 0;
                    }
                    if ((o as PotItem).ny > 80)
                    {
                        (o as PotItem).ny = 0;
                    }
                }
                else if (o is Room_Object)
                {
                    (o as Room_Object).nx = (byte)((o as Room_Object).x + move_x);
                    (o as Room_Object).ny = (byte)((o as Room_Object).y + move_y);
                    if ((o as Room_Object).nx > 80)
                    {
                        (o as Room_Object).nx = 0;
                    }
                    if ((o as Room_Object).ny > 80)
                    {
                        (o as Room_Object).ny = 0;
                    }
                }
            }



        }

        private void showBG1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            need_refresh = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[16 * 16 * 3];
            FileStream fs = new FileStream("generatedPalette.pal", FileMode.OpenOrCreate, FileAccess.Write);
            int i = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (x < 8)
                    {
                        data[i] = GFX.spritesPalettes[x, y].R;
                        data[i + 1] = GFX.spritesPalettes[x, y].G;
                        data[i + 2] = GFX.spritesPalettes[x, y].B;
                    }
                    else
                    {
                        data[i] = 0x00;
                        data[i + 1] = 0x00;
                        data[i + 2] = 0x00;
                    }
                    i += 3;
                }
            }
            fs.Write(data, 0, data.Length);
            fs.Close();
        }



        private void saveLayoutButton_Click(object sender, EventArgs e)
        {
            saveLayout();
        }

        public void saveLayout(bool clipboard = true)
        {

            List<SaveObject> data = new List<SaveObject>();
            if (clipboard == true)
            {
                data = (List<SaveObject>)Clipboard.GetData("ObjectZ");
            }
            else
            {
                foreach (Object o in room.selectedObject)
                {
                    if (selectedLayer >= 0)
                    {
                        data.Add(new SaveObject((Room_Object)o));
                    }
                    else if (spritemodeButton.Checked)
                    {
                        data.Add(new SaveObject((Sprite)o));
                    }
                    else if (potmodeButton.Checked)
                    {
                        data.Add(new SaveObject((PotItem)o));
                    }
                }
            }
            if (data != null)
            {
                if (data.Count > 0)
                {
                    //Name that layout
                    string name = "Room_Object";
                    if (data[0].type == typeof(Room_Object))
                    {
                        name = "Room_Object";
                    }
                    string f = Interaction.InputBox("Name of the new layout", "Name?", "Layout00");
                    if (f != "")
                    {
                        BinaryWriter bw = new BinaryWriter(new FileStream("Layout\\" + f, FileMode.OpenOrCreate, FileAccess.Write));
                        bw.Write((string)(name));
                        foreach (SaveObject o in data)
                        {
                            o.saveToFile(bw);
                        }
                        bw.Close();
                    }
                }
            }
        }


        RoomLayout layoutForm = new RoomLayout();

        public Bitmap drawCustomLayout(Rectangle rect)
        {
            Bitmap b = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(b))
            {

            }


            return b;
        }

        private void loadlayoutButton_Click(object sender, EventArgs e)
        {

            /*string[] files;
            foreach (string s in Directory.EnumerateDirectories("Layout\\"))
            {
                files = Directory.EnumerateFiles(s+"\\");
            }*/
            /*string[] files = Directory.EnumerateFiles("Layout\\Quadrants\\").ToArray();
            foreach(string f in files)
            {

            }

            layoutForm.ShowDialog();
            */
            Room r = (Room)room.Clone();
            clearUselessRoomStuff(r);
            undoRooms.Add(r);

            allbgsButton.Checked = true;
            update_modes_buttons(allbgsButton, e);
            string f = Interaction.InputBox("Name of the layout to load", "Name?", "Layout00");
            BinaryReader br = new BinaryReader(new FileStream("Layout\\" + f, FileMode.Open, FileAccess.Read));

            string type = br.ReadString();
            List<SaveObject> data = new List<SaveObject>();
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                data.Add(new SaveObject(br, typeof(Room_Object)));
            }

            if (data.Count > 0)
            {
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
                    if (o.type == typeof(Sprite))
                    {
                        Sprite spr = (new Sprite(room, o.id, (byte)(o.x - most_x), (byte)(o.y - most_y), Sprites_Names.name[o.id], o.overlord, o.subtype, o.layer));
                        room.sprites.Add(spr);
                        room.selectedObject.Add(spr);
                    }
                    else if (o.type == typeof(Room_Object))
                    {
                        Room_Object ro = room.addObject(o.tid, (byte)(o.x - most_x), (byte)(o.y - most_y), o.size, o.layer);
                        if (ro != null)
                        {
                            ro.setRoom(room);
                            ro.options = o.options;
                            room.tilesObjects.Add(ro);
                            room.selectedObject.Add(ro);
                        }
                    }
                }

                dragx = 0;
                dragy = 0;
                mouse_down = true;
                need_refresh = true;
                room.reloadGfx();
            }

        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (room.selectedObject.Count > 0)
            {
                if (room.selectedObject[0] is Room_Object)
                {
                    foreach (Room_Object o in room.selectedObject)
                    {
                        for (int i = 0; i < room.tilesObjects.Count; i++)
                        {

                            if (o == room.tilesObjects[i])
                            {
                                room.tilesObjects.RemoveAt(i);
                                room.tilesObjects.Add(o);
                                break;
                            }
                        }
                    }
                }
                need_refresh = true;

            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            saveLayout(false);
        }
        bool showTextSprite = false;
        private void textSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showTextSprite = textSpriteToolStripMenuItem.Checked;
        }

        private void mapPicturebox_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (e.X / 16);
            int y = (e.Y / 16);
            int roomId = x + (y * 16);
            change_room(roomId);
            loadRoomList(roomId);
        }

        private void entranceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            short roomId = (short)((ROM.DATA[(Constants.entrance_room + (entranceListBox.SelectedIndex * 2)) + 1] << 8) + ROM.DATA[Constants.entrance_room + (entranceListBox.SelectedIndex * 2)]);
            short yPosition = (short)(((ROM.DATA[(Constants.entrance_yposition + (entranceListBox.SelectedIndex * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.entrance_yposition + (entranceListBox.SelectedIndex * 2)]);
            short xPosition = (short)(((ROM.DATA[(Constants.entrance_xposition + (entranceListBox.SelectedIndex * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.entrance_xposition + (entranceListBox.SelectedIndex * 2)]);

            entranceLabel.Text = "Room : " + roomId.ToString() + "\nX Position : " + xPosition.ToString() + "\nY Position : " + yPosition.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            change_room((short)((ROM.DATA[(Constants.entrance_room + (entranceListBox.SelectedIndex * 2)) + 1] << 8) + ROM.DATA[Constants.entrance_room + (entranceListBox.SelectedIndex * 2)]));
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (room.selectedObject.Count > 0)
            {
                need_refresh = true;
                if ((room.selectedObject[0] is Room_Object))
                {
                    Room_Object o = room.selectedObject[0] as Room_Object;
                    if ((o.options & ObjectOption.Block) == ObjectOption.Block)
                    {
                        o.layer ^= 1;

                    }
                }
            }
        }

        public void updateSelectionObject()
        {
            if (room.selectedObject.Count == 1)
            {
                if (room.selectedObject[0] is Room_Object)
                {
                    Room_Object o = room.selectedObject[0] as Room_Object;
                    string name = o.name;
                    string id = o.id.ToString("X4");
                    if ((o.options & ObjectOption.Door) == ObjectOption.Door)
                    {
                        byte door_pos = (byte)((o.id & 0xF0) >> 3);
                        byte door_dir = (byte)((o.id & 0x03));
                        byte door_type = (byte)((o.id >> 8) & 0xFF);
                        id = o.id.ToString("X4") + "\nDoor Type : " + door_type.ToString("X2");
                        id += "\nDoor Direction : " + door_dir.ToString("X2");
                        id += "\nDoor Position : " + door_pos.ToString("X2");
                    }

                    string x = o.nx.ToString("X2");
                    string y = o.ny.ToString("X2");
                    string layer = (o.layer + 1).ToString("X2");
                    objectinfoLabel.Text = name + "\nId : " + id + "\nX : " + x + "\nY : " + y + "\nLayer : " + layer;
                }
                else if (room.selectedObject[0] is Sprite)
                {
                    Sprite o = room.selectedObject[0] as Sprite;
                    string name = o.name;
                    string id = o.id.ToString("X4");
                    string x = o.nx.ToString("X2");
                    string y = o.ny.ToString("X2");
                    string layer = (o.layer + 1).ToString("X2");
                    objectinfoLabel.Text = name + "\nId : " + id + "\nX : " + x + "\nY : " + y + "\nLayer : " + layer;
                }
                else if (room.selectedObject[0] is PotItem)
                {
                    PotItem o = room.selectedObject[0] as PotItem;
                    string id = o.id.ToString("X4");
                    string x = o.nx.ToString("X2");
                    string y = o.ny.ToString("X2");
                    string layer = (o.layer + 1).ToString("X2");
                    objectinfoLabel.Text = "Id : " + id + "\nX : " + x + "\nY : " + y + "\nLayer : " + layer;
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pithurtcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (room_loaded)
            {
                if (pithurtcheckbox.Checked == true)
                {
                    int pitCount = (ROM.DATA[Constants.pit_count] / 2);
                    int pitPointer = (ROM.DATA[Constants.pit_pointer + 2] << 16) + (ROM.DATA[Constants.pit_pointer + 1] << 8) + (ROM.DATA[Constants.pit_pointer]);
                    pitPointer = Addresses.snestopc(pitPointer);
                    int pitCountNew = 0;
                    for (int i = 0; i < 296; i++)
                    {
                        if (all_rooms[i].damagepit)
                        {
                            pitCountNew++;
                        }
                    }
                    if (pitCountNew >= pitCount)
                    {
                        Console.WriteLine("Too many pit");
                        MessageBox.Show("Can't add more pit damage !");
                        pithurtcheckbox.Checked = false;
                    }
                    else
                    {
                        Console.WriteLine("changedtotrue");
                        room.damagepit = true;
                    }
                }
                else
                {

                    room.damagepit = false;
                }
                anychange = true;
            }
        }



        



        string[] messages = new string[400];
        public void readAllText()
        {
            int pos = 0xE0000;
            int msgid = 0;
            

            while (msgid < 400)
            {

                //Console.WriteLine(msgid + " Message");
                messages[msgid] = "";
                while (ROM.DATA[pos] != 0xFB)
                {
                    if (ROM.DATA[pos] <= 0xF0)
                    {
                        string s = table_char.hexToChar(ROM.DATA[pos]);
                        if (s != null)
                        {
                            messages[msgid] += s;
                            pos++;
                            continue;
                        }
                    }
                    if (ROM.DATA[pos] == 0xD2)
                    {
                        messages[msgid] += "[D2]";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xD3)
                    {
                        messages[msgid] += "[D3]";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xE5)
                    {
                        messages[msgid] += "[E5]";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xE6)
                    {
                        messages[msgid] += "[E6]";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xE7)
                    {
                        messages[msgid] += "[E7]";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xE8)
                    {
                        messages[msgid] += "[E8]";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xE9)
                    {
                        messages[msgid] += "[E9]";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xEA)
                    {
                        messages[msgid] += "[EA]";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xEB)
                    {
                        messages[msgid] += "[EB]";
                        pos++;
                        continue;
                    }

                    if (ROM.DATA[pos] == 0xFF)
                    {
                        messages[msgid] += " ";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xFC) //speed
                    {
                        messages[msgid] += "[SPD ";
                        pos++;
                        messages[msgid] += ROM.DATA[pos].ToString("X2") + "]";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xF7)
                    {
                        messages[msgid] += "[LN1]";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xF8)
                    {
                        messages[msgid] += "[LN2]\n";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xF9)
                    {
                        messages[msgid] += "[LN3]\n";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xF6)
                    {
                        messages[msgid] += "[SCL]";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xFE) //command
                    {
                        pos++;
                        if (ROM.DATA[pos] == 0x67) //changepic?
                        {
                            messages[msgid] += "[PIC]";
                            pos++;
                            continue;
                        }
                        if (ROM.DATA[pos] == 0x69) //waterfall item
                        {
                            messages[msgid] += "[ITM]";
                            pos++;
                            continue;
                        }
                        if (ROM.DATA[pos] == 0x6A) //player name
                        {
                            messages[msgid] += "[NAM]";
                            pos++;
                            continue;
                        }
                        if (ROM.DATA[pos] == 0x78) //pause + arg
                        {
                            messages[msgid] += "[WAI ";
                            pos++;
                            messages[msgid] += ROM.DATA[pos].ToString("X2")+"]";
                            pos++;
                            continue;
                        }
                        if (ROM.DATA[pos] == 0x68) //choice1
                        {
                            messages[msgid] += "[CH1]";
                            pos++;
                            continue;
                        }
                        if (ROM.DATA[pos] == 0x71) //choice2
                        {
                            messages[msgid] += "[CH2]";
                            pos++;
                            continue;
                        }
                        if (ROM.DATA[pos] == 0x72) //choice3
                        {
                            messages[msgid] += "[CH3]";
                            pos++;
                            continue;
                        }
                        if (ROM.DATA[pos] == 0x6B)//Window Effect, arg = 02 = no border
                        {
                            messages[msgid] += "[WIN ";
                            pos++;
                            messages[msgid] += ROM.DATA[pos].ToString("X2") + "]";
                            pos++;
                            continue;
                        }
                        if (ROM.DATA[pos] == 0x6C)//Number? arg1
                        {
                            messages[msgid] += "[NBR ";
                            pos++;
                            messages[msgid] += ROM.DATA[pos].ToString("X2") + "]";
                            pos++;
                            continue;
                        }
                        if (ROM.DATA[pos] == 0x6D)//position arg1
                        {
                            messages[msgid] += "[POS ";
                            pos++;
                            messages[msgid] += ROM.DATA[pos].ToString("X2") + "]";
                            pos++;
                            continue;
                        }
                        if (ROM.DATA[pos] == 0x6E)//scroll speed arg1
                        {
                            messages[msgid] += "[SCS ";
                            pos++;
                            messages[msgid] += ROM.DATA[pos].ToString("X2") + "]";
                            pos++;
                            pos++;
                            continue;
                        }
                        if (ROM.DATA[pos] == 0x77)//Color arg1?
                        {
                            messages[msgid] += "[COL ";
                            pos++;
                            messages[msgid] += ROM.DATA[pos].ToString("X2") + "]";
                            pos++;
                            continue;
                        }
                        if (ROM.DATA[pos] == 0x79)//Sound arg1
                        {
                            
                            messages[msgid] += "[SND ";
                            pos++;
                            messages[msgid] += ROM.DATA[pos].ToString("X2") + "]";
                            pos++;
                            continue;
                        }
                        //if it reach that part then it an unknown command just loop back and hope everything will be fine
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xFD) //kanji
                    {
                        pos++;
                        messages[msgid] += table_char.hexToChar(ROM.DATA[pos],true);
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xFA) //NewLine
                    {
                        pos++;
                        messages[msgid] += "[NWL]\n";
                        continue;
                    }
                    Console.WriteLine("Missing Commands for : "+ ROM.DATA[pos].ToString("X2"));
                    messages[msgid] += "["+ROM.DATA[pos].ToString("X2")+"]";
                    pos++;
                    continue;
                }
                if (pos >= 0xE7355)
                {
                    messageUpDown.Maximum = msgid;
                    break;
                }
                pos++;
                
                msgid++;
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            readAllText();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void messageUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (messages[(int)messageUpDown.Value] != null)
            {
                messagetextBox.Text = messages[(int)messageUpDown.Value];
            }
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

    [Serializable]
    public class SaveObject
    {
        public byte x { get; set; }
        public byte y { get; set; }
        public byte layer { get; set; }
        public byte subtype { get; set; }
        public byte overlord { get; set; }
        public byte id { get; set; }
        public short tid { get; set; }
        public byte size { get; set; }
        public ObjectOption options { get; set; }

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

        public SaveObject(Room_Object o) //Room_Object
        {
            this.x = o.x;
            this.y = o.y;
            this.tid = o.id;
            this.layer = o.layer;
            this.size = o.size;
            this.options = o.options;
            type = typeof(Room_Object);
        }

        public SaveObject(PotItem o) //Pot Item
        {
            this.x = o.x;
            this.y = o.y;
            this.tid = o.id;
            this.layer = (byte)(o.bg2 == true ? 1 : 0);
            type = typeof(PotItem);
        }

        public void saveToFile(BinaryWriter bw)
        {
            if (type == typeof(Room_Object))
            {
                bw.Write(tid);
                bw.Write(x);
                bw.Write(y);
                bw.Write(layer);
                bw.Write(size);
                bw.Write((byte)options);
            }
        }

        public SaveObject(BinaryReader br,Type type) // from file
        {

            tid = br.ReadInt16();
            x = br.ReadByte();
            y = br.ReadByte();
            layer = br.ReadByte();
            size = br.ReadByte();
            options = (ObjectOption)br.ReadByte();
            this.type = type;
        }

    }
}
