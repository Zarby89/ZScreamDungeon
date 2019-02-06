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
using System.IO.Compression;
using System.Runtime.InteropServices;


namespace ZeldaFullEditor
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public Room[] all_rooms = new Room[296];
        bool anychange = false;
        PaletteViewer paletteViewer;
        public List<Room> opened_rooms = new List<Room>();
        public SceneUW activeScene;
        string projectFilename;
        public Entrance[] entrances = new Entrance[0x85];
        Entrance[] starting_entrances = new Entrance[0x07];
        bool saved_changed = false;
        public TreeNode lastNode = null;
        RoomLayout layoutForm;
        List<short> selectedMapPng = new List<short>();
        public ChestPicker chestPicker = new ChestPicker();
        public byte[] door_index = new byte[] { 0x00, 0x02, 0x40, 0x1C, 0x26, 0x0C, 0x44, 0x18, 0x36, 0x38, 0x1E, 0x2E, 0x28, 0x46, 0x0E, 0x0A, 0x30, 0x12, 0x16, 0x32 };
        //List<dataObject> listoftilesobjects = new List<dataObject>();
        //List<dataObject> listofspritesobjects = new List<dataObject>();

        private void Form1_Load(object sender, EventArgs e)
        {
            layoutForm = new RoomLayout(this);
            initialize_properties();
            initialize_gfx();
            ROMStructure.loadDefaultProject();
            mapPicturebox.Image = new Bitmap(256, 304);
            mapPicturebox.Location = new Point(0, 26);
            palettePicturebox.Image = new Bitmap(256, 256);
            paletteViewer = new PaletteViewer(palettePicturebox);
            
        }

        public void initialize_gfx()
        {
            GFX.roomBgLayoutBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, GFX.roomBgLayoutPtr);
            GFX.roomBg1Bitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, GFX.roomBg1Ptr);
            GFX.roomBg2Bitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, GFX.roomBg2Ptr);
            GFX.allgfxBitmap = new Bitmap(128, 7104, 64, PixelFormat.Format4bppIndexed, GFX.allgfx16Ptr);
            GFX.currentgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, GFX.currentgfx16Ptr);
            GFX.roomObjectsBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, GFX.roomObjectsPtr);
            for (int i = 0; i < 4096; i++)
            {
                GFX.tilesBg1Buffer[i] = 0xFFFF;
                GFX.tilesBg2Buffer[i] = 0xFFFF;
            }
        }

        public void initialize_properties()
        {
            Background2[] bg2values = (Background2[])Enum.GetValues(typeof(Background2));
            foreach (Background2 s in bg2values)
            {
                roomProperty_bg2.Items.Add(s.ToString());
            }

            CollisionKey[] collisionvalues = (CollisionKey[])Enum.GetValues(typeof(CollisionKey));
            foreach (CollisionKey s in collisionvalues)
            {
                roomProperty_collision.Items.Add(s.ToString());
            }

            EffectKey[] effectvalues = (EffectKey[])Enum.GetValues(typeof(EffectKey));

            foreach (Background2 s in effectvalues)
            {
                roomProperty_effect.Items.Add(s.ToString());
            }

            TagKey[] tagvalues = (TagKey[])Enum.GetValues(typeof(TagKey));

            foreach (TagKey s in tagvalues)
            {
                roomProperty_tag1.Items.Add(s.ToString());
                roomProperty_tag2.Items.Add(s.ToString());
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save Functions
            //Expand ROM to 2MB
            bool anychange = false;

            foreach (Room room in opened_rooms)
            {
                if (room.has_changed)
                {
                    anychange = true;
                }
            }

            if (anychange == true)
            {
                DialogResult dialogResult = MessageBox.Show("Rooms has changed. Do you want to save changes?", "Save", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (TabPage p in tabControl2.TabPages)
                    {
                        if (p.Text.Contains("*"))
                        {
                            p.Text = p.Text.Trim('*');
                        }
                        
                        all_rooms[(p.Tag as Room).index] = (Room)(p.Tag as Room).Clone();
                        (p.Tag as Room).has_changed = false;
                        anychange = false;
                    }
                }
                tabControl2.Refresh();
            }

            //TODO : MOVE ALL THAT CODE TO PATCH ROM INSTEAD OF SAVE
            byte[] romBackup = (byte[])ROM.DATA.Clone();
            Save save = new Save(all_rooms);
            
            if (save.saveRoomsHeaders()) //no protection always the same size so we don't care :)
            {
                //MessageBox.Show("Failed to save, there is too many chest items", "Bad Error", MessageBoxButtons.OK);
            }
            
            if (save.saveallChests()) //chest there's a protection when there's too many chest - tested it works fine
            {
                MessageBox.Show("Failed to save, there is too many chest items", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveallSprites())//sprites, there's a protection -NOT TESTED-
            {
                MessageBox.Show("Failed to save, there is too many sprites", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveAllObjects())//There is a protection - Tested
            {
                MessageBox.Show("Failed to save, there is too many tiles objects", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveallPots())//There is a protection - Tested
            {
                MessageBox.Show("Failed to save, there is too many pot items", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveBlocks())//There is a protection - Tested
            {
                MessageBox.Show("Failed to save, there is too many pushable blocks", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveTorches())//There is a protection Tested
            {
                MessageBox.Show("Failed to save, there is too many torches", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveAllPits())//There is a protection - Tested
            {
                MessageBox.Show("Failed to save, there is too many damage pits", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveEntrances(entrances,starting_entrances))
            {
                MessageBox.Show("Failed to save entrances ?? no idea why LUL", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveOWExits())
            {
                MessageBox.Show("Failed to save ??, no idea why ", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }

            anychange = false;
            saved_changed = false;

            //ROMStructure.saveProjectFile(version, projectFilename);

            FileStream fs = new FileStream(projectFilename, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Write(ROM.DATA, 0, ROM.DATA.Length);
            fs.Close();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog projectFile = new OpenFileDialog();
            projectFile.Filter = "Alttp US ROM .sfc|*.sfc";
            projectFile.DefaultExt = ".sfc";
            if (projectFile.ShowDialog() == DialogResult.OK)
            {
                LoadProject(projectFile.FileName);
            }
        }

        public void checkAnyChanges()
        {
            foreach (TabPage p in tabControl2.TabPages)
            {
                if ((p.Tag as Room).has_changed)
                {
                    anychange = true;
                    if (!p.Text.Contains("*"))
                    {
                        p.Text += "*";
                    }
                }
            }
        }

        public void LoadProject(string filename)
        {
            ROMStructure.loadDefaultProject();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int size = (int)fs.Length;
            if (fs.Length == 0x100000)
            {
                size = 0x200000;
            }
            ROM.DATA = new byte[size];
            fs.Read(ROM.DATA, 0, (int)fs.Length);
            fs.Close();
            activeScene = new SceneUW(this);
            activeScene.Location = new Point(tabControl2.Location.X, tabControl2.Location.Y + 24);
            activeScene.Size = new Size(512, 512);
            this.Controls.Add(activeScene);
            initProject();
            projectFilename = filename;
            this.Text = "ZScream Magic - " + filename;
        }

        public void initRoomsMap()
        {
            using (Graphics g = Graphics.FromImage(mapPicturebox.Image))
            {
                int xd = 0;
                int yd = 0;
                g.Clear(Color.Black);
                for (int i = 0; i < 296; i++)
                {
                    if (all_rooms[i].tilesObjects.Count > 0)
                    {
                        g.FillRectangle(new SolidBrush(GFX.LoadDungeonPalette(all_rooms[i].palette)[4, 2]), new Rectangle(xd * 16, yd * 16, 16, 16));
                    }
                    xd++;
                    if (xd == 16)
                    {
                        yd++;
                        xd = 0;
                    }
                }
            }

            mapPicturebox.Refresh();
        }

        public void loadRoomList(int roomId)
        {
            if (radioButton2.Checked)
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

                            g.FillRectangle(new SolidBrush(GFX.LoadDungeonPalette(all_rooms[i].palette)[4, 2]), new Rectangle(xd * 16, yd * 16, 16, 16));

                            foreach (short s in selectedMapPng)
                            {
                                if (s == i)
                                {
                                    g.DrawRectangle(new Pen(Color.Aqua, 2), new Rectangle((xd * 16), (yd * 16), 16, 16));
                                }
                            }

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
                    xd = 0;
                    yd = 0;
                    for (int i = 0; i < 296; i++)
                    {
                        foreach (Room room in opened_rooms)
                        {
                            if (room.index == (short)i)
                            {
                                g.DrawRectangle(new Pen(Color.YellowGreen, 2), new Rectangle((xd * 16), (yd * 16), 16, 16));
                            }
                        }
                        xd++;
                        if (xd == 16)
                        {
                            yd++;
                            xd = 0;
                        }
                    }
                }
                mapPicturebox.Refresh();
            }



        }

        public void initProject() //first load of project need to be changed entirely
        {
            tabControl1.Enabled = true;

            GFX.CreateAllGfxData(ROM.DATA);

            for (int i = 0; i < 296; i++)
            {
                all_rooms[i] = (new Room(i)); // create all rooms
            }
            initEntrancesList();
            addRoomTab(260);
            tabControl2_SelectedIndexChanged(tabControl2.TabPages[0], new EventArgs());
            
            initRoomsList();
            enableProjectButtons();
            //Initialize the map draw
            initRoomsMap();
            GFX.previewObjectsPtr = new IntPtr[600];
            GFX.previewObjectsBitmap = new Bitmap[600];
            GFX.previewSpritesPtr = new IntPtr[256];
            GFX.previewSpritesBitmap = new Bitmap[256];
            GFX.previewChestsPtr = new IntPtr[75];
            GFX.previewChestsBitmap = new Bitmap[75];
            for (int i = 0; i < 600; i++)
            {
                GFX.previewObjectsPtr[i] = Marshal.AllocHGlobal(64 * 64);
                GFX.previewObjectsBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, GFX.previewObjectsPtr[i]);
            }
            for (int i = 0; i < 256; i++)
            {
                GFX.previewSpritesPtr[i] = Marshal.AllocHGlobal(64 * 64);
                GFX.previewSpritesBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, GFX.previewSpritesPtr[i]);
            }
            for (int i = 0; i < 75; i++)
            {
                GFX.previewChestsPtr[i] = Marshal.AllocHGlobal(64 * 64);
                GFX.previewChestsBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, GFX.previewChestsPtr[i]);
            }
            initObjectsList();

            GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
            GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
            objectViewer1.updateSize();
            spritesView1.updateSize();
            activeScene.DrawRoom();
            activeScene.Refresh();
            //Initialize the entrances list

        }


        public void initEntrancesList()
        {
            //entrances
            for (int i = 0; i < 0x07; i++)
            {
                starting_entrances[i] = new Entrance((byte)i, true);
                string tname = "[" + i.ToString("X2") + "] -> ";
                foreach (DataRoom d in ROMStructure.dungeonsRoomList)
                {
                    if (d.id == starting_entrances[i].Room)
                    {
                        tname += "[" + d.id.ToString() + "]" + d.name;
                        break;
                    }
                }
                TreeNode tn = new TreeNode(tname);
                tn.Tag = i;
                entrancetreeView.Nodes[1].Nodes.Add(tn);
            }

            for (int i = 0; i < 0x85; i++)
            {
                entrances[i] = new Entrance((byte)i, false);
                string tname = "[" + i.ToString("X2") + "] -> ";
                foreach (DataRoom d in ROMStructure.dungeonsRoomList)
                {
                    if (d.id == entrances[i].Room)
                    {
                        tname += "[" + d.id.ToString() + "]" + d.name;
                        break;
                    }
                }
                TreeNode tn = new TreeNode(tname);
                tn.Tag = i;
                
                entrancetreeView.Nodes[0].Nodes.Add(tn);
                
            }

            entrancetreeView.SelectedNode = entrancetreeView.Nodes[0].Nodes[0];
            selectedEntrance = entrances[0];
        }

        public void initRoomsList()
        {
            roomListView.Nodes.Clear();
            //create the 16 dungeons
            for (int i = 0; i < 17; i++)
            {
                TreeNode node = new TreeNode(ROMStructure.dungeonsNames[i]);
                roomListView.Nodes.Add(node);
            }
            //create the rooms inside the dungeons
            foreach (DataRoom r in ROMStructure.dungeonsRoomList)
            {
                TreeNode subnode = new TreeNode("[" + r.id + "] " + r.name);
                subnode.Tag = r.id;
                roomListView.Nodes[r.dungeonId].Nodes.Add(subnode);
            }

        }

        public void enableProjectButtons()
        {
            allbgsButton.Enabled = true;
            bg3modeButton.Enabled = true;
            bg2modeButton.Enabled = true;
            bg1modeButton.Enabled = true;
            chestmodeButton.Enabled = true;
            saveButton.Enabled = true;
            doormodeButton.Enabled = true; //door mode changed on bg
            blockmodeButton.Enabled = true;
            torchmodeButton.Enabled = true;
            spritemodeButton.Enabled = true;
            debugtestButton.Enabled = true;
            runtestButton.Enabled = true;
            potmodeButton.Enabled = true; //cant change to sprite since sprites are using 16x16
            saveToolStripMenuItem.Enabled = true;
            saveasToolStripMenuItem.Enabled = true;
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
        }

        public void clear_room()
        {
            if (activeScene.room != null)
            {
                activeScene.room.selectedObject.Clear();
            }
        }

        public void save_room(int roomId)
        {
            all_rooms[roomId] = (Room)activeScene.room.Clone();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                mapPicturebox.Visible = true;
                roomListView.Visible = false;
                if (roomListView.SelectedNode != null)
                {
                    if (roomListView.SelectedNode.Tag != null)
                    {
                        loadRoomList((short)roomListView.SelectedNode.Tag); //WHY ? for the map :D
                    }
                }
                loadRoomList(activeScene.room.index);
                mapPicturebox.Refresh();
            }
            else
            {
                mapPicturebox.Visible = false;
                roomListView.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomListView.Nodes.Clear();
            loadRoomList(260);
        }
        public int selectedLayer = -1;

        public void setmodeAllScene(ObjectMode mode)
        {
            activeScene.selectedMode = mode;
        }

        public void updateScenesMode()
        {
            foreach (Room room in opened_rooms)
            {
                room.selectedObject.Clear();
            }
            //objectsListbox.Enabled = false;
            setmodeAllScene(ObjectMode.Bgallmode);
            if (allbgsButton.Checked)
            {
                setmodeAllScene(ObjectMode.Bgallmode);
                selectedLayer = 3;
            }
            else if (bg1modeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Bg1mode);
                selectedLayer = 0;
                //objectsListbox.Enabled = true;
            }
            else if (bg2modeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Bg2mode);
                selectedLayer = 1;
                //objectsListbox.Enabled = true;
            }
            else if (bg3modeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Bg3mode);
                selectedLayer = 2;
               // objectsListbox.Enabled = true;
            }
            else if (spritemodeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Spritemode);
            }
            else if (potmodeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Itemmode);
            }
            else if (torchmodeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Torchmode);
            }
            else if (blockmodeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Blockmode);
            }
            else if (doormodeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Doormode);
            }
            else if (warpmodeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Warpmode);
            }
            else if (chestmodeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Chestmode);
            }
        }

        public void update_modes_buttons(object sender, EventArgs e)
        {

            activeScene.selectedDragObject = null;
            activeScene.selectedDragSprite = null;

            for (int i = 8; i < 19; i++)
            {
                (toolStrip1.Items[i] as ToolStripButton).Checked = false;
            }
            selectedLayer = -1;
            (sender as ToolStripButton).Checked = true;
            updateScenesMode();
            activeScene.room.update();
            activeScene.need_refresh = true;

        }

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.deleteSelected();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //scene.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //scene.Redo();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.selectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.paste();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.copy();

        }

        private void palettePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseDown(e))
            {

            }
        }

        private void palettePicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseUp(e))
            {

            }
        }

        private void palettePicturebox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseDoubleclick(e, colorDialog1))
            {

            }
        }

        private void showBG1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.showLayer1 = showBG1ToolStripMenuItem.Checked;
            activeScene.DrawRoom();
            activeScene.Refresh();
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
                foreach (Object o in activeScene.room.selectedObject)
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

        private void loadlayoutButton_Click(object sender, EventArgs e)
        {
            //scene.loadLayout();
            if ((byte)activeScene.selectedMode > 3)
            {
                bg1modeButton.Checked = true;
                update_modes_buttons(bg1modeButton, new EventArgs());
                // scene.selectedMode = ObjectMode.Bg1mode;
            }
            layoutForm.scene.room = (Room)activeScene.room.Clone();
            activeScene.room.selectedObject.Clear();
            if (layoutForm.ShowDialog() == DialogResult.OK)
            {

                int most_x = 512;
                int most_y = 512;
                foreach (Room_Object o in layoutForm.scene.room.tilesObjects)
                {
                    if (layoutForm.scene.room.tilesObjects.Count > 0)
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

                foreach (Room_Object o in layoutForm.scene.room.tilesObjects)
                {
                    o.x = (byte)(o.x - most_x);
                    o.y = (byte)(o.y - most_y);
                    activeScene.room.tilesObjects.Add(o);
                    activeScene.room.selectedObject.Add(o);

                }
                activeScene.dragx = 0;
                activeScene.dragy = 0;
                activeScene.mouse_down = true;
                activeScene.need_refresh = true;
                activeScene.room.reloadGfx(entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
            }
        }
        //Bring to front -_-
        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeScene.room.selectedObject.Count > 0)
            {
                if (activeScene.room.selectedObject[0] is Room_Object)
                {
                    foreach (Room_Object o in activeScene.room.selectedObject)
                    {
                        for (int i = 0; i < activeScene.room.tilesObjects.Count; i++)
                        {

                            if (o == activeScene.room.tilesObjects[i])
                            {
                                activeScene.room.tilesObjects.RemoveAt(i);
                                activeScene.room.tilesObjects.Add(o);
                                break;
                            }
                        }
                    }
                }
                activeScene.DrawRoom();
                activeScene.Refresh();
                activeScene.mouse_down = false;
                //scene.need_refresh = true;

            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            saveLayout(false);
        }

        private void textSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.showSpriteText = textSpriteToolStripMenuItem.Checked;
            activeScene.need_refresh = true;
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.insertNew();
        }

        private void bringToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.SendSelectedToBack();
        }

        private void sendToBg1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (activeScene.room.selectedObject.Count > 0)
            {
                //debuglabel.Text = activeScene.room.selectedObject[0].GetType().ToString();
                if (activeScene.room.selectedObject[0] is Room_Object)
                {
                    activeScene.updating_info = true;
                    foreach (Room_Object o in activeScene.room.selectedObject)
                    {
                        o.layer = 0;
                    }
                    activeScene.updating_info = false;
                }
                else if (activeScene.room.selectedObject[0] is Sprite)
                {
                    activeScene.updating_info = true;
                    foreach (Sprite o in activeScene.room.selectedObject)
                    {
                        o.layer = 0;
                    }
                    activeScene.updating_info = false;
                }
                else if (activeScene.room.selectedObject[0] is PotItem)
                {
                    activeScene.updating_info = true;
                    foreach (PotItem o in activeScene.room.selectedObject)
                    {
                        o.layer = 0;
                    }
                    activeScene.updating_info = false;
                }
                activeScene.need_refresh = true;
            }
        }

        private void sendToBg1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (activeScene.room.selectedObject.Count > 0)
            {
                if (activeScene.room.selectedObject[0] is Room_Object)
                {
                    activeScene.updating_info = true;
                    foreach (Room_Object o in activeScene.room.selectedObject)
                    {
                        o.layer = 1;
                    }
                    activeScene.updating_info = false;
                }
                else if (activeScene.room.selectedObject[0] is Sprite)
                {
                    activeScene.updating_info = true;
                    foreach (Sprite o in activeScene.room.selectedObject)
                    {
                        o.layer = 1;
                    }
                    activeScene.updating_info = false;
                }
                else if (activeScene.room.selectedObject[0] is PotItem)
                {
                    activeScene.updating_info = true;
                    foreach (PotItem o in activeScene.room.selectedObject)
                    {
                        o.layer = 1;
                    }
                    activeScene.updating_info = false;
                }

                activeScene.DrawRoom();
                activeScene.Refresh();
            }
        }

        private void sendToBg1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (activeScene.room.selectedObject.Count > 0)
            {
                if (activeScene.room.selectedObject[0] is Room_Object)
                {
                    activeScene.updating_info = true;
                    foreach (Room_Object o in activeScene.room.selectedObject)
                    {
                        o.layer = 2;
                    }
                    activeScene.updating_info = false;
                }
                activeScene.need_refresh = true;
            }
        }

        private void changeObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete the selected object and add the new one
            activeScene.changeObject();
        }

        private void zscreamForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (anychange)
            {
                all_rooms[activeScene.room.index] = activeScene.room;
                anychange = false;
                this.saved_changed = true;
            }
            if (saved_changed)
            {

                DialogResult dr = MessageBox.Show("There is unsaved change do you want to save first?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {

                    saveToolStripMenuItem_Click(this, new EventArgs());
                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    this.Activate();
                }
            }
        }

        private void roomListView_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = roomListView.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.

            TreeNode targetNode = roomListView.GetNodeAt(targetPoint);
            if (targetNode.Tag != null)
            {
                return;
            }


            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (!draggedNode.Equals(targetNode) && targetNode != null)
            {

                draggedNode.Remove();
                targetNode.Nodes.Add(draggedNode);
                //targetNode.Expand();

                for (int i = 0; i < 17; i++)
                {
                    if (targetNode == roomListView.Nodes[i])
                    {

                        DataRoom dr = ROMStructure.dungeonsRoomList.Where(o => (o.id == (short)draggedNode.Tag)).ToArray()[0];
                        dr.dungeonId = (byte)i;
                        break;
                    }
                }

            }
        }

        private void roomListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if ((e.Item as TreeNode).Tag != null)
            {

                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void roomListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void roomListView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Tag != null) //this is a room
            {
                DataRoom dr = ROMStructure.dungeonsRoomList.Where(o => (o.id == (short)e.Node.Tag)).ToArray()[0];
                dr.name = e.Label;
            }
            else //this is a dungeon
            {
                for (int i = 0; i < 17; i++)
                {
                    if (roomListView.Nodes[i] == e.Node)
                    {
                        ROMStructure.dungeonsNames[i] = e.Label;
                        break;
                    }
                }
            }
        }

        private void showBG2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.showLayer2 = showBG2ToolStripMenuItem.Checked;
            activeScene.DrawRoom();
            activeScene.Refresh();
        }

        private void exportProjectAsROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Snes ROM File|.sfc";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFile.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Write(ROM.DATA, 0, ROM.DATA.Length);
                fs.Close();
            }
        }

        private void roomListView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

        }

        private void loadInitialStuff()
        {

        }
        public Entrance selectedEntrance = null;
        public Bitmap spriteFont = new Bitmap("spriteFont.png");
        private void entrancetreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
                propertiesChangedFromForm = true;
                if (e.Node.Tag != null)
                {
                Entrance en = entrances[(int)e.Node.Tag];
                if (e.Node.Parent != null)
                {
                    if (e.Node.Parent.Name == "StartingEntranceNode")
                    {
                        en = starting_entrances[(int)e.Node.Tag];
                    }
                }
                    //propertyGrid2.SelectedObject = entrances[(int)e.Node.Tag];
                    
                    entranceProperty_room.Text = en.Room.ToString();
                    entranceProperty_floor.Text = en.Floor.ToString();
                    entranceProperty_scrollx.Text = en.XScroll.ToString();
                    entranceProperty_scrolly.Text = en.YScroll.ToString();
                    entranceProperty_xpos.Text = en.XPosition.ToString();
                    entranceProperty_ypos.Text = en.YPosition.ToString();
                    entranceProperty_camx.Text = en.XCamera.ToString();
                    entranceProperty_camy.Text = en.YCamera.ToString();
                    entranceProperty_exit.Text = en.Exit.ToString();
                    entranceProperty_dungeon.Text = en.Dungeon.ToString();
                    entranceProperty_blockset.Text = en.Blockset.ToString();
                    entranceProperty_music.Text = en.Music.ToString();


                    if ((en.Ladderbg & 0x10) == 0x10 )
                    {
                        entranceProperty_bg.Checked = true;
                    }

                    if ((en.Scrolling & 0x20) == 0x20)
                    {
                        entranceProperty_hscroll.Checked = true;
                    }

                    if ((en.Scrolling & 0x02) == 0x02)
                    {
                        entranceProperty_vscroll.Checked = true;
                    }

                    bool b = false;
                    bool r = false;
                    if ((en.Scrollquadrant & 0xF0) != 0x00)
                    {
                        r = false;//0x2X
                    }
                    else
                    {
                        r = true; //0x0X
                    }

                    if ((en.Scrollquadrant & 0x0F) == 0x00)
                    {
                        b = false; //0xX0
                    }
                    else
                    {
                        b = true; //0xX2
                    }
                    label39.Text = en.Scrollquadrant.ToString("X2");


                    /*if (b && r) //bottom right
                    {
                        entranceProperty_quadbr.Checked = true;
                    }

                    if (b && !r) //bottom left
                    {
                        entranceProperty_quadbl.Checked = true;
                    }

                    if (!b && r) //top right
                    {
                        entranceProperty_quadtl.Checked = true;
                    }

                    if (!b && !r) //top left
                    {
                        entranceProperty_quadtr.Checked = true;
                    }*/
                                   
                    if (en.Scrollquadrant == 0x12) //bottom right
                    {
                        entranceProperty_quadbr.Checked = true;
                    }
                    else if (en.Scrollquadrant == 0x02) //bottom left
                    {
                        entranceProperty_quadbl.Checked = true;
                    }
                    else if (en.Scrollquadrant == 0x00) //top left
                    {
                        entranceProperty_quadtl.Checked = true;
                    }
                    else if (en.Scrollquadrant == 0x10) //top right
                    {
                        entranceProperty_quadtr.Checked = true;
                    }


                    
                    selectedEntrance = en;
                    activeScene.room.reloadGfx(en.Blockset);
                    activeScene.DrawRoom();
                    activeScene.Refresh();

            }
            propertiesChangedFromForm = false;





        }

        private void objectsListbox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        public void sortObject()
        {
            //objectViewer1.BeginUpdate();
            objectViewer1.items.Clear();
            //Sorting sort;
            Sorting sortsizing = Sorting.All;
            string searchText = searchTextbox.Text.ToLower();
            //listView1
            objectViewer1.items.AddRange(listoftilesobjects
                .Where(x => x != null)
                .Where(x => (x.name.ToLower().Contains(searchText)))
                .OrderBy(x => x.id)
                .Select(x => x) //?
                .ToArray());

            objectViewer1.Refresh();
        }

        public void sortSprite()
        {
            spritesView1.items.Clear();
            string searchText = searchspriteTextbox.Text.ToLower();
            spritesView1.items.AddRange(listofspritesobjects
                .Where(x => x != null)
                .Where(x => (x.name.ToLower().Contains(searchText)))
                .OrderBy(x => x.id)
                .Select(x => x) //?
                .ToArray());

            spritesView1.Refresh();
        }


        private void searchTextbox_TextChanged(object sender, EventArgs e)
        {
            sortObject();
            objectViewer1.updateSize();
        }

        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.showGrid = showGridToolStripMenuItem.Checked;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                if (comboBox1.SelectedIndex > 0)
                {
                    foreach (Sprite spr in activeScene.room.sprites)
                    {
                        spr.keyDrop = 0;
                    }
                }
                (activeScene.room.selectedObject[0] as Sprite).keyDrop = (byte)comboBox1.SelectedIndex;
                activeScene.DrawRoom();
                activeScene.Refresh();
            }
        }

        private void spritesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchspriteTextbox_TextChanged(object sender, EventArgs e)
        {
            sortSprite();
        }

        private void selecteditemobjectCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selecteditemobjectCombobox.SelectedIndex != -1)
            {
                if (activeScene.room.selectedObject.Count > 0)
                {
                    if (activeScene.room.selectedObject[0] is PotItem)
                    {
                        PotItem oo = activeScene.room.selectedObject[0] as PotItem;

                        if (selecteditemobjectCombobox.SelectedIndex > 0x16)
                        {
                            oo.id = (byte)(0x80 + ((selecteditemobjectCombobox.SelectedIndex - 0x17) * 2));
                        }
                        else
                        {
                            oo.id = (byte)(selecteditemobjectCombobox.SelectedIndex);
                        }
                        // scene.need_refresh = true;
                    }
                    activeScene.DrawRoom();
                    activeScene.Refresh();
                }
            }
        }

        private void roomListView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null) //tag = room id
            {
                addRoomTab((short)e.Node.Tag);
            }
        }

        public void addRoomTab(short roomId)
        {

            bool alreadyFound = false;
            foreach (Room room in opened_rooms)
            {
                if (room.index == roomId)
                {
                    alreadyFound = true;
                    break;
                }
            }
            if (alreadyFound == true)
            {
                //display message error room already opened
                MessageBox.Show("That room is already opened !");
                return;
            }
            else
            {
                Room r = (Room)all_rooms[roomId].Clone();
                //mapPropertyGrid.SelectedObject = r;
                opened_rooms.Add(r); //add the double clicked room into rooms list     
                activeScene.room = r;
                TabPage tp = new TabPage(r.index.ToString("D3"));
                tp.Tag = r;
                tabControl2.TabPages.Add(tp);
                //objectsListbox.ClearSelected();
                tabControl2.SelectedTab = tp;

                activeScene.room.reloadGfx(entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
                GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
                GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
                activeScene.SetPalettesBlack();
                paletteViewer.update();
                activeScene.DrawRoom();
                activeScene.Refresh();
                
                objectViewer1.updateSize();
                spritesView1.updateSize();


            }

        }

        private void rightSideToolboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rightSideToolboxToolStripMenuItem.Checked)
            {
                toolboxPanel.Dock = DockStyle.Right;
                splitter1.Dock = DockStyle.Right;
            }
            else
            {
                toolboxPanel.Dock = DockStyle.Left;
                splitter1.Dock = DockStyle.Left;
            }
        }

        private void entrancetreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (e.Node.Parent == entrancetreeView.Nodes[0])
                {
                    addRoomTab(entrances[(int)e.Node.Tag].Room);
                }
                else
                {
                    addRoomTab(starting_entrances[(int)e.Node.Tag].Room);
                }
            }
        }

        private void mapPicturebox_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            int x = (e.X / 16);
            int y = (e.Y / 16);
            int roomId = x + (y * 16);
            if (ModifierKeys == Keys.Control)
            {
                //check if map is already in
                short alreadyIn = -1;
                foreach (short s in selectedMapPng)
                {
                    //if it was already in delete it
                    if (s == (short)roomId)
                    {
                        alreadyIn = s;
                    }
                }
                if (alreadyIn != -1)
                {
                    selectedMapPng.Remove(alreadyIn);
                }
                else
                {
                    selectedMapPng.Add((short)roomId);
                }
                loadRoomList(roomId);

            }
            else
            {
                if (roomId < 296)
                {

                    addRoomTab((short)roomId);
                    loadRoomList(roomId);
                }
            }
        }

        private void runtestButton_Click(object sender, EventArgs e)
        {
            /*
            if (File.Exists("temp.sfc"))
            {
                File.Delete("temp.sfc");
            }

            FileStream brom = new FileStream(baseROM, FileMode.Open, FileAccess.Read);
            brom.Read(ROM.DATA, 0, (int)brom.Length);
            brom.Close();

            saveToolStripMenuItem_Click(sender, e);
            
            FileStream fs = new FileStream("temp.sfc", FileMode.CreateNew, FileAccess.Write);

            fs.Write(ROM.DATA, 0, ROM.DATA.Length);
            fs.Close();
            Process p = Process.Start("temp.sfc");
            */
            saveToolStripMenuItem_Click(saveToolStripMenuItem, new EventArgs());
            Process p = Process.Start(projectFilename);

        }

        private void unselectedBGTransparentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            activeScene.canSelectUnselectedBG = unselectedBGTransparentToolStripMenuItem.Checked;
        }
        //Doors
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex != -1)
            {
                if (activeScene.room.selectedObject.Count == 1)
                {
                    if (activeScene.room.selectedObject[0] is Room_Object)
                    {
                            Room_Object o = (activeScene.room.selectedObject[0] as Room_Object);
                            if (o.options == ObjectOption.Door)
                            {
                                (o as object_door).door_type = ((byte)(door_index[comboBox2.SelectedIndex]));
                                (o as object_door).updateId();
                                activeScene.room.has_changed = true;
                                activeScene.DrawRoom();
                                activeScene.Refresh();
                            }
                    }
                }
            }
        }

        private void gfxgroupCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (gfxgroupCombobox.SelectedIndex == 0)
            {
                gfx5textBox.Enabled = true;
                gfx6textBox.Enabled = true;
                gfx7textBox.Enabled = true;
                gfx8textBox.Enabled = true;
                gfx1textBox.Enabled = true;
                gfx2textBox.Enabled = true;
                gfx3textBox.Enabled = true;
                gfx4textBox.Enabled = true;
            }
            else if (gfxgroupCombobox.SelectedIndex == 3)
            {
                gfx5textBox.Enabled = false;
                gfx6textBox.Enabled = false;
                gfx7textBox.Enabled = false;
                gfx8textBox.Enabled = false;
                gfx1textBox.Enabled = false;
                gfx2textBox.Enabled = false;
                gfx3textBox.Enabled = false;
                gfx4textBox.Enabled = false;
            }
            else if (gfxgroupCombobox.SelectedIndex == 2)
            {
                gfx1textBox.Enabled = true;
                gfx2textBox.Enabled = true;
                gfx3textBox.Enabled = true;
                gfx4textBox.Enabled = true;
                gfx5textBox.Enabled = false;
                gfx6textBox.Enabled = false;
                gfx7textBox.Enabled = false;
                gfx8textBox.Enabled = false;

            }
            else if (gfxgroupCombobox.SelectedIndex == 1)
            {
                gfx1textBox.Enabled = true;
                gfx2textBox.Enabled = true;
                gfx3textBox.Enabled = true;
                gfx4textBox.Enabled = true;
                gfx5textBox.Enabled = false;
                gfx6textBox.Enabled = false;
                gfx7textBox.Enabled = false;
                gfx8textBox.Enabled = false;

            }

            loadGfxGroups();
            
        }

        public void loadGfxGroups()
        {
            propertiesChangedFromForm = true;
            int gfxPointer = (ROM.DATA[Constants.gfx_groups_pointer + 1] << 8) + ROM.DATA[Constants.gfx_groups_pointer];
            gfxPointer = Addresses.snestopc(gfxPointer);
            if (gfxgroupCombobox.SelectedIndex == 0) //main gfx
            {
                if (gfxgroupindexUpDown.Value > 36) { gfxgroupindexUpDown.Value = 0; }
                gfx1textBox.Text = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 0].ToString();
                gfx2textBox.Text = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 1].ToString();
                gfx3textBox.Text = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 2].ToString();
                gfx4textBox.Text = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 3].ToString();
                gfx5textBox.Text = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 4].ToString();
                gfx6textBox.Text = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 5].ToString();
                gfx7textBox.Text = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 6].ToString();
                gfx8textBox.Text = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 7].ToString();
            }
            else if (gfxgroupCombobox.SelectedIndex == 1) //entrances
            {
                if (gfxgroupindexUpDown.Value > 81) { gfxgroupindexUpDown.Value = 0; }
                gfx1textBox.Text = ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 0)].ToString();
                gfx2textBox.Text = ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 1)].ToString();
                gfx3textBox.Text = ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 2)].ToString();
                gfx4textBox.Text = ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 3)].ToString();
            }
            else if (gfxgroupCombobox.SelectedIndex == 2) //sprites
            {
                if (gfxgroupindexUpDown.Value > 143) { gfxgroupindexUpDown.Value = 0; }
                gfx1textBox.Text = ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 0].ToString();
                gfx2textBox.Text = ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 1].ToString();
                gfx3textBox.Text = ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 2].ToString();
                gfx4textBox.Text = ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 3].ToString();
            }
            propertiesChangedFromForm = false;
        }

        private void gfxsinglechanged(object sender, EventArgs e)
        {
            if (propertiesChangedFromForm == false)
            {
                int gfxPointer = (ROM.DATA[Constants.gfx_groups_pointer + 1] << 8) + ROM.DATA[Constants.gfx_groups_pointer];
                gfxPointer = Addresses.snestopc(gfxPointer);
                if (gfxgroupCombobox.SelectedIndex == 0) //main gfx
                {
                    if (gfxgroupindexUpDown.Value > 36) { gfxgroupindexUpDown.Value = 0; }
                    int r = 0;
                    if (int.TryParse(gfx1textBox.Text,out r)){ ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 0] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx2textBox.Text, out r)) { ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 1] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx3textBox.Text, out r)) { ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 2] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx4textBox.Text, out r)) { ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 3] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx5textBox.Text, out r)) { ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 4] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx6textBox.Text, out r)) { ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 5] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx7textBox.Text, out r)) { ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 6] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx8textBox.Text, out r)) { ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 7] = (byte)r; };
                }
                else if (gfxgroupCombobox.SelectedIndex == 1) //entrances
                {
                    if (gfxgroupindexUpDown.Value > 81) { gfxgroupindexUpDown.Value = 0; }
                    int r = 0;
                    if (int.TryParse(gfx1textBox.Text, out r)) { ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 0)] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx2textBox.Text, out r)) { ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 1)] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx3textBox.Text, out r)) { ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 2)] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx4textBox.Text, out r)) { ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 3)] = (byte)r; };
                }
                else if (gfxgroupCombobox.SelectedIndex == 2) //sprites
                {
                    if (gfxgroupindexUpDown.Value > 143) { gfxgroupindexUpDown.Value = 0; }
                    int r = 0;
                    if (int.TryParse(gfx1textBox.Text, out r)) { ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 0] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx2textBox.Text, out r)) { ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 1] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx3textBox.Text, out r)) { ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 2] = (byte)r; };
                    r = 0;
                    if (int.TryParse(gfx4textBox.Text, out r)) { ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 3] = (byte)r; };
                }

                activeScene.room.reloadGfx(selectedEntrance.Blockset);
                activeScene.DrawRoom();
                activeScene.Refresh();
                gfxPicturebox.Refresh();
            }


        }



        private void gfxfromroomButton_Click(object sender, EventArgs e)
        {
            //gfxPicturebox.Image = GFX.singletobmp(GFX.gfxdata, 0, 5, false); //FULL ROOM GFX

            if (gfxgroupCombobox.SelectedIndex == 0)
            {
                gfxgroupindexUpDown.Value = activeScene.room.blockset;
            }
            else if (gfxgroupCombobox.SelectedIndex == 1) //entrances
            {

            }
            else if (gfxgroupCombobox.SelectedIndex == 2) //sprites
            {
                gfxgroupindexUpDown.Value = activeScene.room.spriteset + 64;
            }

        }

        private void gfxgroupindexUpDown_ValueChanged(object sender, EventArgs e)
        {
            loadGfxGroups();
        }

        private void debugtestButton_Click(object sender, EventArgs e)
        {
            /* if (File.Exists("temp.sfc"))
             {
                 File.Delete("temp.sfc");
             }

             FileStream brom = new FileStream(baseROM, FileMode.Open, FileAccess.Read);
             brom.Read(ROM.DATA, 0, (int)brom.Length);
             brom.Close();

             saveToolStripMenuItem_Click(sender, e);

             FileStream fs = new FileStream("temp.sfc", FileMode.CreateNew, FileAccess.Write);

             fs.Write(ROM.DATA, 0, ROM.DATA.Length);
             fs.Close();
             Process p = Process.Start("temp.sfc");*/
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = ".sfc";
            sf.Filter = "ZScream Project File .sfc|*.sfc";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                projectFilename = sf.FileName;
                ROMStructure.ProjectName = sf.FileName;
                saveToolStripMenuItem_Click(sender, e);
            }
        }

        private void selectAllMapForExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 296; i++)
            {
                selectedMapPng.Add((short)i);
            }
            loadRoomList(296);
        }

        private void deselectedAllMapForExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedMapPng.Clear();
            loadRoomList(296);
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            DungeonGenerator dg = new DungeonGenerator();
            dg.ShowDialog();
        }


        public int gridSize = 8;
        private void x8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x8ToolStripMenuItem.Checked = false;
            x16ToolStripMenuItem.Checked = false;
            x32ToolStripMenuItem.Checked = false;
            x64ToolStripMenuItem.Checked = false;
            x256ToolStripMenuItem.Checked = false;
            (sender as ToolStripMenuItem).Checked = true;
            showGridToolStripMenuItem.Checked = true;

            if (x8ToolStripMenuItem.Checked)
            {
                gridSize = 8;
            }
            if (x16ToolStripMenuItem.Checked)
            {
                gridSize = 16;
            }
            if (x32ToolStripMenuItem.Checked)
            {
                gridSize = 32;
            }
            if (x64ToolStripMenuItem.Checked)
            {
                gridSize = 64;
            }
            if (x256ToolStripMenuItem.Checked)
            {
                gridSize = 256;
            }
            activeScene.showGrid = true;
            activeScene.Refresh();
        }
        public bool propertiesChangedFromForm = false;
        private void roomProperty_bg2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            updateRoomInfos();
        }

        private void roomProperty_layout_TextChanged(object sender, EventArgs e)
        {
            //
            updateRoomInfos();
        }

        private void roomProperty_pit_CheckedChanged(object sender, EventArgs e)
        {
            //
            updateRoomInfos();
        }

        public void updateRoomInfos()
        {
            if (propertiesChangedFromForm == false)
            {
                activeScene.room.Bg2 = (Background2)roomProperty_bg2.SelectedIndex;
                byte r = 0;
                if (Byte.TryParse(roomProperty_blockset.Text, out r))
                {
                    activeScene.room.Blockset = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Blockset = 0;
                }

                activeScene.room.Tag1 = (TagKey)roomProperty_tag1.SelectedIndex;
                activeScene.room.Tag2 = (TagKey)roomProperty_tag2.SelectedIndex;
                activeScene.room.Effect = (EffectKey)roomProperty_effect.SelectedIndex;
                activeScene.room.Collision = (CollisionKey)roomProperty_collision.SelectedIndex;

                if (Byte.TryParse(roomProperty_floor1.Text, out r))
                {
                    activeScene.room.Floor1 = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Floor1 = 0;
                }

                if (Byte.TryParse(roomProperty_floor2.Text, out r))
                {
                    activeScene.room.Floor2 = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Floor2 = 0;
                }

                if (Byte.TryParse(roomProperty_hole.Text, out r))
                {
                    activeScene.room.HoleWarp = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.HoleWarp = 0;
                }

                if (Byte.TryParse(roomProperty_holeplane.Text, out r))
                {
                    activeScene.room.HoleWarpPlane = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.HoleWarpPlane = 0;
                }

                if (Byte.TryParse(roomProperty_layout.Text, out r))
                {
                    activeScene.room.Layout = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Layout = 0;
                }

                if (Byte.TryParse(roomProperty_msgid.Text, out r))
                {
                    activeScene.room.Messageid = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Messageid = 0;
                }

                if (Byte.TryParse(roomProperty_palette.Text, out r))
                {
                    activeScene.room.Palette = r;
                }
                else
                {
                    // MessageBox.Show("That value is invalid");
                    activeScene.room.Palette = 0;
                }



                activeScene.room.Damagepit = roomProperty_pit.Checked;
                activeScene.room.SortSprites = roomProperty_sortsprite.Checked;

                if (Byte.TryParse(roomProperty_spriteset.Text, out r))
                {
                    activeScene.room.Spriteset = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Spriteset = 0;
                }


                if (Byte.TryParse(roomProperty_stair1.Text, out r))
                {
                    activeScene.room.Staircase1 = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Staircase1 = 0;
                }

                if (Byte.TryParse(roomProperty_stair1plane.Text, out r))
                {
                    activeScene.room.Staircase1Plane = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Staircase1Plane = 0;
                }

                if (Byte.TryParse(roomProperty_stair2.Text, out r))
                {
                    activeScene.room.Staircase2 = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Staircase2 = 0;
                }

                if (Byte.TryParse(roomProperty_stair2plane.Text, out r))
                {
                    activeScene.room.Staircase2Plane = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Staircase2Plane = 0;
                }

                if (Byte.TryParse(roomProperty_stair3.Text, out r))
                {
                    activeScene.room.Staircase3 = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Staircase3 = 0;
                }

                if (Byte.TryParse(roomProperty_stair3plane.Text, out r))
                {
                    activeScene.room.Staircase3Plane = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Staircase3Plane = 0;
                }

                if (Byte.TryParse(roomProperty_stair4.Text, out r))
                {
                    activeScene.room.Staircase4 = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Staircase4 = 0;
                }

                if (Byte.TryParse(roomProperty_stair4plane.Text, out r))
                {
                    activeScene.room.Staircase4Plane = r;
                }
                else
                {
                    //MessageBox.Show("That value is invalid");
                    activeScene.room.Staircase4Plane = 0;
                }

                activeScene.room.reloadGfx(entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
                GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
                GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
                activeScene.SetPalettesBlack();
                paletteViewer.update();
                activeScene.DrawRoom();
                activeScene.Refresh();
                activeScene.room.has_changed = true;
            }
        }

        public void updateEntranceInfos()
        {
            if (propertiesChangedFromForm == false)
            {

                int r = 0;
                if (int.TryParse(entranceProperty_blockset.Text, out r))
                {
                    selectedEntrance.Blockset = (byte)r;
                }
                else
                {
                    selectedEntrance.Blockset = 0;
                }

                if (int.TryParse(entranceProperty_room.Text, out r))
                {
                    selectedEntrance.Room = (short)r;
                }
                else
                {
                    selectedEntrance.Room = 0;
                }

                if (int.TryParse(entranceProperty_camx.Text, out r))
                {
                    selectedEntrance.XCamera = (short)r;
                }
                else
                {
                    selectedEntrance.XCamera = 0;
                }

                if (int.TryParse(entranceProperty_camy.Text, out r))
                {
                    selectedEntrance.YCamera = (short)r;
                }
                else
                {
                    selectedEntrance.YCamera = 0;
                }

                if (int.TryParse(entranceProperty_xpos.Text, out r))
                {
                    selectedEntrance.XPosition = (short)r;
                }
                else
                {
                    selectedEntrance.XPosition = 0;
                }

                if (int.TryParse(entranceProperty_ypos.Text, out r))
                {
                    selectedEntrance.YPosition = (short)r;
                }
                else
                {
                    selectedEntrance.YPosition = 0;
                }

                if (int.TryParse(entranceProperty_scrollx.Text, out r))
                {
                    selectedEntrance.XScroll = (short)r;
                }
                else
                {
                    selectedEntrance.XScroll = 0;
                }

                if (int.TryParse(entranceProperty_scrolly.Text, out r))
                {
                    selectedEntrance.YScroll = (short)r;
                }
                else
                {
                    selectedEntrance.YScroll = 0;
                }

                if (int.TryParse(entranceProperty_floor.Text, out r))
                {
                    selectedEntrance.Floor = (byte)r;
                }
                else
                {
                    selectedEntrance.Floor = 0;
                }

                if (int.TryParse(entranceProperty_dungeon.Text, out r))
                {
                    selectedEntrance.Dungeon = (byte)r;
                }
                else
                {
                    selectedEntrance.Dungeon = 0;
                }

                if (int.TryParse(entranceProperty_music.Text, out r))
                {
                    selectedEntrance.Music = (byte)r;
                }
                else
                {
                    selectedEntrance.Music = 0;
                }

                if (int.TryParse(entranceProperty_exit.Text, out r))
                {
                    selectedEntrance.Exit = (short)r;
                }
                else
                {
                    selectedEntrance.Exit = 0;
                }

                if (entranceProperty_bg.Checked)
                {
                    selectedEntrance.Ladderbg = 0x10;
                }
                else
                {
                    selectedEntrance.Ladderbg = 0x00;
                }
                //byte scrolling;////1byte --h- --v- 
                byte b = 0;
                if (entranceProperty_hscroll.Checked)
                {
                    b += 0x20;
                }
                if (entranceProperty_vscroll.Checked)
                {
                    b += 0x02;
                }

                //if (entranceProperty_quadbl)

                selectedEntrance.Scrolling = b;

                GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
                GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
                activeScene.SetPalettesBlack();
                activeScene.room.reloadGfx(entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
                activeScene.DrawRoom();
                activeScene.Refresh();
                activeScene.room.has_changed = true;
            }
        }

        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (tabControl2.SelectedIndex == e.Index)
            {
                e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 2);
            }
            e.Graphics.DrawString(this.tabControl2.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        public void closeRoom(int index)
        {
            int closedRoom = -1;
            for (int j = 0; j < opened_rooms.Count; j++)
            {
                if (opened_rooms[j].index == index)
                {
                    closedRoom = j;
                    break;
                }
            }
            if (closedRoom != -1)
            {
                opened_rooms.RemoveAt(closedRoom);
            }
        }

        private void tabControl2_MouseClick(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Left)
            {

                Rectangle r = tabControl2.GetTabRect(tabControl2.SelectedIndex);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 12, r.Top + 2, 10, 10);
                if (closeButton.Contains(e.Location))
                {
                    if ((tabControl2.TabPages[tabControl2.SelectedIndex].Tag as Room).has_changed)
                    {
                        DialogResult dr = MessageBox.Show("Room has changed do you want to save?", "Warning", MessageBoxButtons.YesNoCancel);
                        if (dr == DialogResult.Yes)
                        {
                            all_rooms[(tabControl2.TabPages[tabControl2.SelectedIndex].Tag as Room).index] = (Room)(tabControl2.TabPages[tabControl2.SelectedIndex].Tag as Room).Clone();
                            closeRoom((tabControl2.TabPages[tabControl2.SelectedIndex].Tag as Room).index);
                            this.tabControl2.TabPages.RemoveAt(tabControl2.SelectedIndex);
                        }
                        else if (dr == DialogResult.No)
                        {
                            closeRoom((tabControl2.TabPages[tabControl2.SelectedIndex].Tag as Room).index);
                            this.tabControl2.TabPages.RemoveAt(tabControl2.SelectedIndex);
                        }
                        else if (dr == DialogResult.Cancel)
                        {

                        }
                    }
                    else
                    {
                        closeRoom((tabControl2.TabPages[tabControl2.SelectedIndex].Tag as Room).index);
                        this.tabControl2.TabPages.RemoveAt(tabControl2.SelectedIndex);
                    }
                   
                    this.tabControl2.TabPages.RemoveAt(tabControl2.SelectedIndex);
                }
            }
            else */if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < tabControl2.TabCount; i++)
                {
                    Rectangle r = tabControl2.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        if ((tabControl2.TabPages[i].Tag as Room).has_changed)
                        {
                            DialogResult dr = MessageBox.Show("Room has changed do you want to save?", "Warning", MessageBoxButtons.YesNoCancel);
                            if (dr == DialogResult.Yes)
                            {
                                all_rooms[(tabControl2.TabPages[i].Tag as Room).index] = (Room)(tabControl2.TabPages[i].Tag as Room).Clone();
                                closeRoom((tabControl2.TabPages[i].Tag as Room).index);
                                this.tabControl2.TabPages.RemoveAt(i);
                            }
                            else if (dr == DialogResult.No)
                            {
                                closeRoom((tabControl2.TabPages[i].Tag as Room).index);
                                this.tabControl2.TabPages.RemoveAt(i);
                            }
                            else if (dr == DialogResult.Cancel)
                            {
                               
                            }
                        }
                        else
                        {
                            closeRoom((tabControl2.TabPages[i].Tag as Room).index);
                            this.tabControl2.TabPages.RemoveAt(i);
                        }
                        
                        break;
                    }
                }
            }
            loadRoomList(0);
        }

        private void ZscreamForm_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.TabPages.Count > 0)
            {
                activeScene.room = (tabControl2.TabPages[tabControl2.SelectedIndex].Tag as Room);
                activeScene.updateRoomInfos(this);
                activeScene.room.reloadGfx(entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
                
                GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
                GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
                activeScene.SetPalettesBlack();
                
                paletteViewer.update();

                pictureBox1.Refresh();

                activeScene.DrawRoom();
                activeScene.Refresh();
                spritesView1.updateSize();
                spritesView1.Refresh();
                objectViewer1.updateSize();
                objectViewer1.Refresh();
            }
            else
            {
                activeScene.Clear();
            }
        }
        List<Room_Object> listoftilesobjects = new List<Room_Object>();
        List<Sprite> listofspritesobjects = new List<Sprite>();
        public void initObjectsList()
        {
            int index = 0;
            for (int i = 0; i < 0xE8; i++) //Type 1 objects 
            {
                Room_Object o = activeScene.room.addObject((short)i, 0, 0, 0, 0);
                o.preview = true;
                o.previewId = index;
                index++;
                o.setRoom(activeScene.room);
                if (o != null)
                {
                    //objectsListbox.Items.Add(new dataObject((short)i,i.ToString("X3") +" "+ o.name));
                    listoftilesobjects.Add(o);
                }
            }
            for (int i = 0x100; i < 0x140; i++) //Type 2 objects 
            {
                Room_Object o = activeScene.room.addObject((short)i, 0, 0, 0, 0);
                o.preview = true;
                o.previewId = index;
                index++;
                o.setRoom(activeScene.room);
                if (o != null)
                {
                    //objectsListbox.Items.Add(new dataObject((short)i, i.ToString("X3") + " " + o.name));
                    listoftilesobjects.Add(o);
                }
            }
            for (int i = 0xF80; i < 0xFFF; i++) //Type 3 objects 
            {

                Room_Object o = activeScene.room.addObject((short)i, 0, 0, 0, 0);
                o.preview = true;
                o.previewId = index;
                index++;
                o.setRoom(activeScene.room);
                if (o != null)
                {
                    //objectsListbox.Items.Add(new dataObject((short)i, i.ToString("X3") + " " + o.name));
                    listoftilesobjects.Add(o);
                }
            }

            for (int i = 0; i < 0xF2; i++)
            {
                Sprite s = new Sprite(activeScene.room, (byte)i, 0, 0, Sprites_Names.name[i], 0, 0, 0);
                s.preview = true;
                listofspritesobjects.Add(s);
            }



            //sortObject();
        }
        List<Chest> listofchests = new List<Chest>();

        private void objectViewer1_Load(object sender, EventArgs e)
        {
            foreach (Room_Object o in listoftilesobjects)
            {
                objectViewer1.items.Add((o));
            }
            foreach(Sprite spr in listofspritesobjects)
            {
                spritesView1.items.Add(spr);
            }


        }

        private void objectViewer1_Resize(object sender, EventArgs e)
        {
           // Refresh();
        }

        private void objectViewer1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void objectViewer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeScene.selectedDragObject = new dataObject(objectViewer1.selectedObject.id, objectViewer1.selectedObject.name);
        }

        private void tabControl2_SizeChanged(object sender, EventArgs e)
        {
            if (activeScene != null)
            {
                activeScene.Location = new Point(tabControl2.Location.X, tabControl2.Location.Y + 24);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            objectViewer1.updateSize();
            spritesView1.updateSize();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            objectViewer1.showName = showNameObjectCheckbox.Checked;
            objectViewer1.updateSize();
        }

        private void spritesView1_Load(object sender, EventArgs e)
        {
            foreach (Sprite o in listofspritesobjects)
            {
                spritesView1.items.Add((o));
            }
        }

        private void entranceProperty_room_TextChanged(object sender, EventArgs e)
        {
            updateEntranceInfos();
        }

        private void entranceProperty_vscroll_CheckedChanged(object sender, EventArgs e)
        {
            updateEntranceInfos();
        }

        private void entranceProperty_quadtl_CheckedChanged(object sender, EventArgs e)
        {
            updateEntranceInfos();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(GFX.currentgfx16Bitmap, new Rectangle(0,0,GFX.currentgfx16Bitmap.Width*2,GFX.currentgfx16Bitmap.Height*2),0,0, GFX.currentgfx16Bitmap.Width, GFX.currentgfx16Bitmap.Height,GraphicsUnit.Pixel);
            int ty = hovergfxTile / 16;
            int tx = hovergfxTile - (ty*16);
            e.Graphics.DrawRectangle(new Pen(Brushes.GreenYellow,2), new Rectangle(tx*16,ty*16,16,16));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int c = 0;
            if (int.TryParse(previewPaletteTextbox.Text,out c))
            {
                if (c <= 16)
                {

                }
                else
                {
                    c = 0;
                }
                ColorPalette cp = GFX.currentgfx16Bitmap.Palette;
                for (int i = 0; i < 16; i++)
                {
                    cp.Entries[i] = GFX.roomBg1Bitmap.Palette.Entries[i + (c * 16)];
                }
                GFX.currentgfx16Bitmap.Palette = cp;
                pictureBox1.Refresh();
            }
            
        }

        private void label41_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
        int lasthovergfxTile = -1;
        int hovergfxTile = -1;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int tx = e.X / 16;
            int ty = e.Y / 16;
            hovergfxTile = tx + (ty * 16);
            if (hovergfxTile != lasthovergfxTile)
            {
                hovergfxLabel.Text = "Hovered Tile : " + "X:"+tx.ToString() + " Y:"+ty.ToString() + " (HEX:" + hovergfxTile.ToString("X3")+ ")";
                pictureBox1.Refresh();
                lasthovergfxTile = hovergfxTile;
            }
        }

        private void spritesView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeScene.selectedDragSprite = new dataObject(spritesView1.selectedObject.id, spritesView1.selectedObject.name);
        }

        private void gfxPicturebox_Paint(object sender, PaintEventArgs e)
        {
            int c = 0;
            if (int.TryParse(previewPaletteGfxTextbox.Text, out c))
            {
                if (c <= 16)
                {

                }
                else
                {
                    c = 0;
                }
                ColorPalette cp = GFX.currentgfx16Bitmap.Palette;
                for (int i = 0; i < 16; i++)
                {
                    cp.Entries[i] = GFX.roomBg1Bitmap.Palette.Entries[i + (c * 16)];
                }
                GFX.currentgfx16Bitmap.Palette = cp;
                pictureBox1.Refresh();
            }


            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(GFX.currentgfx16Bitmap, new Rectangle(0, 0, GFX.currentgfx16Bitmap.Width * 2, GFX.currentgfx16Bitmap.Height * 2), 0, 0, GFX.currentgfx16Bitmap.Width, GFX.currentgfx16Bitmap.Height, GraphicsUnit.Pixel);

        }

        private void previewPaletteGfxTextbox_TextChanged(object sender, EventArgs e)
        {
            gfxPicturebox.Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //check what's the higher map and the left most, we don't care about right bottom

            //(map / 16) = Y position
            //map - (Y*16) = X position
            int lowerX = 16; //what we need to remove from the image to the left
            int lowerY = 16; //what we need to remove from the image to the right
            int higherX = 0; //what we need to remove from the image to the left
            int higherY = 0; //what we need to remove from the image to the right
            Room savedRoom = activeScene.room;

            if (selectedMapPng.Count > 0)
            {
                Bitmap b = new Bitmap(8192, 10752);
                using (Graphics gb = Graphics.FromImage(b))
                {

                    foreach (short s in selectedMapPng)
                    {
                        int cx = 0;
                        int cy = 0;
                        cy = (s / 16);
                        cx = s - (cy * 16);
                        if (cx < lowerX) { lowerX = cx; }
                        if (cy < lowerY) { lowerY = cy; }
                        if (cx > higherX) { higherX = cx; }
                        if (cy > higherY) { higherY = cy; }

                        activeScene.room = all_rooms[s];
                        activeScene.room.reloadGfx();
                        GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
                        GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.palette);
                        activeScene.DrawRoom();
                        activeScene.Refresh();
                        //gb.DrawImage(, new Point(cx * 512, cy * 512));
                        activeScene.DrawToBitmap(b, new Rectangle(cx * 512, cy * 512, 512, 512));
                    }
                }
                int image_size_x = ((higherX - lowerX) * 512) + 512;
                int image_size_y = ((higherY - lowerY) * 512) + 512;
                int image_start_x = lowerX * 512;
                int image_start_y = lowerY * 512;
                Bitmap nb = new Bitmap(image_size_x, image_size_y);
                using (Graphics gb = Graphics.FromImage(nb))
                {
                    gb.DrawImage(b, 0, 0, new Rectangle(image_start_x, image_start_y, image_size_x, image_size_y), GraphicsUnit.Pixel);
                }

                nb.Save("MapTest.png");
                b.Dispose();
                b = null;
                nb.Dispose();
                nb = null;
            }
            else
            {
                Bitmap b = new Bitmap(512, 512);
                activeScene.DrawToBitmap(b, new Rectangle(0, 0, 512, 512));
                b.Save("singlemap.png");
            }
            activeScene.room = savedRoom;
            activeScene.room.reloadGfx();
            GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
            GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.palette);
            activeScene.DrawRoom();
            activeScene.Refresh();

        }

        private void decreaseZBy1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Facepalm
        }
    }

    public class dataObject
    {
        public short id;
        public string Name { get; set; }
        
        public dataObject(short id, string name)
        {
            this.Name = name;
            this.id = id;
        }


    }


}
