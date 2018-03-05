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
using WeifenLuo.WinFormsUI.Docking;


namespace ZeldaFullEditor
{

    public partial class zscreamForm : Form
    {
        public zscreamForm()
        {
            InitializeComponent();

        }

        public Room[] all_rooms = new Room[296];
        int lastRoom = 32;
        bool anychange = false;
        PaletteViewer paletteViewer;
        string version = "us";
        public List<DScene> rooms = new List<DScene>();
        Charactertable table_char = new Charactertable(true);
        bool projectLoaded = false;
        bool schedulegfxSave = false;

        //List<string> recentProjects = new List<string>();


        private void Tsi_Click(object sender, EventArgs e)
        {
            string fileName = (sender as ToolStripMenuItem).Text;
            LoadProject(fileName);
        }
        DockPanel dockPanel = new DockPanel();
        private void Form1_Load(object sender, EventArgs e)
        {
            //settings.cfg format
            //5 last projects - string dynamic
            //
            searchtextListbox.DisplayMember = "Name";
            spritesListbox.DisplayMember = "Name";
            /*if (File.Exists("settings.cfg"))
            {
                BinaryReader br = new BinaryReader(new FileStream("settings.cfg", FileMode.Open, FileAccess.Read));
                for (int i = 0; i < 5; i++)
                {
                    string name = br.ReadString();
                    if (name != "")
                    {
                        recentProjects.Add(name);
                    }
                }
                br.Close();
            }

            if (recentProjects.Count > 0)
            {
                foreach (string s in recentProjects)
                {
                    ToolStripMenuItem tsi = new ToolStripMenuItem(s);
                    tsi.Click += Tsi_Click;
                    fileToolStripMenuItem.DropDownItems.Add(tsi);

                }
            }*/


            ROMStructure.loadDefaultProject();

            Controls.Add(dockPanel);
            dockPanel.BringToFront();
            dockPanel.Dock = DockStyle.Fill;
            dockPanel.ActiveDocumentChanged += DockPanel_ActiveDocumentChanged;

            actionsListbox.DisplayMember = "Name";
            palettePicturebox.Image = new Bitmap(256, 340);
            paletteViewer = new PaletteViewer(palettePicturebox);
            mapPicturebox.Image = new Bitmap(256, 304);
            layoutForm = new RoomLayout(this);
        }

        private void DockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            if (dockPanel.DocumentsCount > 0)
            {
                activeScene = (dockPanel.ActiveDocument as DScene).scene;
                propertyGrid1.SelectedObject = activeScene.room;
            }
            else
            {
                activeScene.Clear();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save Functions
            //Expand ROM to 2MB
            bool anychange = false;

            foreach (DScene ds in rooms)
            {
                if (ds.scene.room.has_changed)
                {
                    anychange = true;
                }
            }

            if (anychange == true)
            {
                DialogResult dialogResult = MessageBox.Show("Rooms has changed. Do you want to save changes?", "Save", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DScene ds in rooms)
                    {
                        ds.scene.room.has_changed = false;
                        all_rooms[ds.scene.room.index] = (Room)ds.scene.room.Clone();
                        ds.Text = ds.Text.Trim('*');
                        ds.namedChanged = false;
                    }

                }
            }

            //TODO : MOVE ALL THAT CODE TO PATCH ROM INSTEAD OF SAVE


            byte[] romBackup = (byte[])ROM.DATA.Clone();
            Save save = new Save(all_rooms,entrances,messages);
            if (save.saveRoomsHeaders()) //no protection always the same size so we don't care :)
            {
                MessageBox.Show("Failed to save, there is too many chest items", "Bad Error", MessageBoxButtons.OK);
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
            if (save.saveTexts(messages, table_char))//There is a protection - Tested
            {
                MessageBox.Show("Failed to save, there is too many texts", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveEntrances(entrances))
            {
                MessageBox.Show("Failed to save entrances ?? no idea why LUL", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            saveInitialStuff(); //can't overwrite anything

            anychange = false;
            saved_changed = false;

            ROMStructure.saveProjectFile(version, projectFilename);
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog projectFile = new OpenFileDialog();
            if (projectFile.ShowDialog() == DialogResult.OK)
            {
                LoadProject(projectFile.FileName);
                /*foreach (string s in recentProjects)
                {
                    if (s == projectFile.FileName)
                    {
                        return;
                    }
                }
                recentProjects.Insert(0, projectFile.FileName);*/
            }

        }
        string projectFilename;
        public void LoadProject(string filename)
        {
            if (ROMStructure.loadProject(filename))
            {
                version = ROMStructure.GameVersion;
                if (version == "vt")
                {
                    Constants.Init_Jp(true);
                }
                else if (version == "jp")
                {
                    Constants.Init_Jp();
                }

                initProject();
                projectFilename = filename;
                this.Text = "ZScream Magic - " + filename;
            }
        }

        public void CreateProject(string romFile) //use 5MB File, 4MB for the rom, 1MB for project data
        {

            //Chose a rom if that rom have header remove the header
            byte[] tempRom;
            FileStream fs = new FileStream(romFile, FileMode.Open, FileAccess.Read);
            tempRom = new byte[fs.Length];
            fs.Read(tempRom, 0, (int)fs.Length);
            fs.Close();

            if (tempRom.Length == 0x100200) //If Rom contain Header
            {
                ROM.DATA = new byte[0x100000];
                Array.Copy(tempRom, 0x200, ROM.DATA, 0x00, 0x100000);
            }
            else
            {
                ROM.DATA = new byte[tempRom.Length];
                tempRom.CopyTo(ROM.DATA, 0x00);
            }
            version = checkFileSupport();
            if (version != "error")
            {
                ROMStructure.createProjectFile(version);
                initProject();
            }
            else
            {

                version = "error";
                ROM.DATA = null;
                MessageBox.Show("Failed to create a project from that rom", "Error");
            }

            //Check the version of the rom, known version are "us","jp","vt", others are unknown or not allowed to load


        }


        public string checkFileSupport()
        {
            string v = "";
            string title = getHeaderTitle();

            if (title == "VT")
            {
                if (ROM.DATA[0x07FC2] == 0x20)
                {
                    ROM.DATA = null;
                    MessageBox.Show("Sorry that ROM is not supported :(", "Error");
                    v = "error";
                    return "error";
                }
                Constants.Init_Jp(true); //VT
                v = "vt";
            }
            else if (title == "ZE")
            {
                Constants.Init_Jp(); //JP
                v = "jp";
            }
            else if (title == "TH")
            {
                v = "us";
            }
            else
            {
                v = "us";

                MessageBox.Show("Sorry that ROM is not supported :(", "Error");
                //load_default_room();
                v = "error";
                return "error";
            }

            return v;
        }

        public string getHeaderTitle()
        {
            string title = "";
            for (int i = 0; i < 2; i++)
            {
                title += (char)ROM.DATA[0x07FC0 + i];
            }
            return title;
        }

        short[][] dungeons_rooms = new short[15][];

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
            GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
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
                        foreach (DScene ds in rooms)
                        {
                            if (ds.scene.room.index == (short)i)
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
                GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
                mapPicturebox.Refresh();
            }



        }
        TextPreview previewText;
        Entrance[] entrances = new Entrance[0x84];
        Entrance[] starting_entrances = new Entrance[0x07];
        List<dataObject> listoftilesobjects = new List<dataObject>();
        List<dataObject> listofspritesobjects = new List<dataObject>();
        public void initProject() //first load of project need to be changed entirely
        {
            tabControl1.Enabled = true;

            GFX.gfxdata = Compression.DecompressTiles(); //decompress all the gfx from the game
            for (int i = 0; i < 5; i++)
            {
                byte[] d = new byte[0];
                if (i != 4)
                {
                    d = GFX.bpp3snestoindexed(GFX.gfxdata, 205+i);
                }
                else
                {
                    d = GFX.bpp3snestoindexed(GFX.gfxdata, 165);
                }
                for (int j = 0; j < 0x1000; j++)
                {
                        GFX.itemsdataEDITOR[(i * 0x1000) + j] = d[j];
                }
            }
            for (int i = 0; i < 296; i++)
            {
                all_rooms[i] = (new Room(i)); // create all rooms
            }

            if (version == "jp" || version == "vt")
            {
                readAllText();//TODO : Change that to have it own class
                messageidUpDown.Maximum = messageUpDown.Maximum;
            }

            initRoomsList();

            GFX.LoadHudPalettes();
            previewText = new TextPreview(table_char);
            enableProjectButtons();


            Room r = (Room)all_rooms[260].Clone();
            DScene ds = new DScene(this, "Room : " + r.index);
            Scene s = ds.scene;

            s.room = r;
            propertyGrid1.SelectedObject = r;
            rooms.Add(ds); //add the double clicked room into rooms list            
            s.need_refresh = true;
            s.room.reloadGfx(false);
            paletteViewer.update();
            
            s.Enabled = true;
            s.Dock = DockStyle.Fill;
            gfxPicturebox.Image = GFX.selectedtobmp(new byte[] { 0, 1, 2, 3 }, (int)gfx2NumericUpDown.Value);

            s.initChestGfx();
            room_loaded = true;
            s.selectedMode = ObjectMode.Bg1mode;
            s.Enabled = true;
            ds.Text = "Room : " + r.index;
            ds.Show(dockPanel);
            ds.Controls.Add(s);
            s.BringToFront();
            s.Size = new Size(512, 512);

            activeScene = s;

            //scene.room = room;

            //Initialize the map draw
            initRoomsMap();
            //Initialize the entrances list
            initEntrancesList();
            //Initialize the tiles and sprites objects list - Require a temproom loaded
            initObjectsList();
            //Load initial equipment
            loadInitialStuff();
            projectLoaded = true;
            //Start the update timer to refresh the screen
            updateTimer.Enabled = true;
            paletteViewer.update();
        }

        public void initObjectsList()
        {
            for (int i = 0; i < 0xE8; i++) //Type 1 objects 
            {
                Room_Object o = activeScene.room.addObject((short)i, 0, 0, 0, 0);
                if (o != null)
                {
                    //objectsListbox.Items.Add(new dataObject((short)i,i.ToString("X3") +" "+ o.name));
                    listoftilesobjects.Add(new dataObject((short)i, i.ToString("X3") + " " + o.name));
                }
            }
            for (int i = 0x100; i < 0x140; i++) //Type 2 objects 
            {
                Room_Object o = activeScene.room.addObject((short)i, 0, 0, 0, 0);
                if (o != null)
                {
                    //objectsListbox.Items.Add(new dataObject((short)i, i.ToString("X3") + " " + o.name));
                    listoftilesobjects.Add(new dataObject((short)i, i.ToString("X3") + " " + o.name));
                }
            }
            for (int i = 0xF80; i < 0xFFF; i++) //Type 3 objects 
            {

                Room_Object o = activeScene.room.addObject((short)i, 0, 0, 0, 0);
                if (o != null)
                {
                    //objectsListbox.Items.Add(new dataObject((short)i, i.ToString("X3") + " " + o.name));
                    listoftilesobjects.Add(new dataObject((short)i, i.ToString("X3") + " " + o.name));
                }
            }

            for (int i = 0; i < 0xF2; i++)
            {
                listofspritesobjects.Add(new dataObject((byte)i, Sprites_Names.name[i]));
            }
            spritesListbox.Items.AddRange(listofspritesobjects.ToArray());
            objectsListbox.DisplayMember = "Name";
            sortObject();
        }

        public void initEntrancesList()
        {
            //entrances

            for(int i = 0; i <0x07;i++)
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

            for (int i = 0; i < 0x84; i++)
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

        public void updategfxinrom()
        {
            int gfxPointer = (ROM.DATA[Constants.gfx_groups_pointer + 1] << 8) + ROM.DATA[Constants.gfx_groups_pointer];
            gfxPointer = Addresses.snestopc(gfxPointer);

            if (gfxgroupCombobox.SelectedIndex == 0) //main gfx
            {
                if (gfxgroupindexUpDown.Value > 36) { gfxgroupindexUpDown.Value = 0; }
                ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 0] = (byte)gfx1NumericUpDown.Value;
                ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 1] = (byte)gfx2NumericUpDown.Value;
                ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 2] = (byte)gfx3NumericUpDown.Value;
                ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 3] = (byte)gfx4NumericUpDown.Value;
                ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 4] = (byte)gfx5NumericUpDown.Value;
                ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 5] = (byte)gfx6NumericUpDown.Value;
                ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 6] = (byte)gfx7NumericUpDown.Value;
                ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 7] = (byte)gfx8NumericUpDown.Value;
            }
            else if (gfxgroupCombobox.SelectedIndex == 1) //entrances
            {
                if (gfxgroupindexUpDown.Value > 81) { gfxgroupindexUpDown.Value = 0; }
                ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 0)] = (byte)gfx1NumericUpDown.Value;
                ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 1)] = (byte)gfx2NumericUpDown.Value;
                ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 2)] = (byte)gfx3NumericUpDown.Value;
                ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 3)] = (byte)gfx4NumericUpDown.Value;
            }
            else if (gfxgroupCombobox.SelectedIndex == 2) //sprites
            {
                if (gfxgroupindexUpDown.Value > 143) { gfxgroupindexUpDown.Value = 0; }
                ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 0] = (byte)gfx1NumericUpDown.Value;
                ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 1] = (byte)gfx2NumericUpDown.Value;
                ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 2] = (byte)gfx3NumericUpDown.Value;
                ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 3] = (byte)gfx4NumericUpDown.Value;
            }
            activeScene.room.needGfxRefresh = true;
        }


        private void updateTimer_Tick(object sender, EventArgs e)
        {
            foreach (DScene ds in rooms)
            {
                if (ds.scene.room.has_changed == true)
                {
                    if (ds.namedChanged == false)
                    {
                        ds.Text += "*";
                        ds.namedChanged = true;
                    }

                }
                //ds.scene.drawRoom();
            }
            activeScene.drawRoom();
            if (animated)
            {
                GFX.animation_timer++;
                if (GFX.animation_timer >= 8)
                {
                    activeScene.room.reloadGfx();
                    activeScene.need_refresh = true;
                    GFX.animation_timer = 0;
                    GFX.animated_frame++;
                    if (GFX.animated_frame >= 3)
                    {
                        GFX.animated_frame = 0;
                    }
                }
            }

            if (schedulegfxSave)
            {
                
                updategfxinrom();
                schedulegfxSave = false;
                activeScene.need_refresh = true;
            }

        }

        public enum ObjectResize //TODO : ASAP the scaling from top/left cause that's annoying to not have them :p
        {
            None, Left, Right, Up, Down, UpLeft, UpRight, DownLeft, DownRight
        }



        private void gotoRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void clear_room()
        {
            if (activeScene.room != null)
            {
                actionsListbox.Items.Clear();
                activeScene.room.selectedObject.Clear();
            }
        }
        bool saved_changed = false;
        public TreeNode lastNode = null;

        public void save_room(int roomId)
        {
            all_rooms[roomId] = (Room)activeScene.room.Clone();
            all_rooms[roomId].clearGFX();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        Room_Name room_names = new Room_Name();
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
                // scene.need_refresh = true;
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
        int selectedLayer = -1;
        public Scene activeScene;

        public void setmodeAllScene(ObjectMode mode)
        {
            foreach (DScene ds in rooms)
            {
                ds.scene.selectedMode = mode;
            }
        }

        public void updateScenesMode()
        {
            foreach (DScene ds in rooms)
            {
                ds.scene.room.selectedObject.Clear();
            }
            objectsListbox.Enabled = false;
            spritesListbox.Enabled = false;
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
                objectsListbox.Enabled = true;
            }
            else if (bg2modeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Bg2mode);
                selectedLayer = 1;
                objectsListbox.Enabled = true;
            }
            else if (bg3modeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Bg3mode);
                selectedLayer = 2;
                objectsListbox.Enabled = true;
            }
            else if (spritemodeButton.Checked)
            {
                setmodeAllScene(ObjectMode.Spritemode);
                spritesListbox.Enabled = true;
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
            foreach (DScene ds in rooms)
            {
                ds.scene.selectedDragObject = null;
                ds.scene.selectedDragSprite = null;
            }

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

        public Bitmap[] sprites_bitmap = new Bitmap[0xF3];
        public Bitmap[] chest_items_bitmap = new Bitmap[176];
        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        public PickObject objectSelector = new PickObject();


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
            if (messagetextBox.Focused)
            {
                messagetextBox.Cut();
                return;
            }

            activeScene.cut();
        }



        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messagetextBox.Focused) //OH HAHA
            {
                messagetextBox.Paste();
                return;
            }
            activeScene.paste();


        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messagetextBox.Focused)
            {
                messagetextBox.Copy();
                return;
            }
            activeScene.copy();

        }
        bool room_loaded = false;
        private void floor1UpDown_ValueChanged(object sender, EventArgs e)
        {

        }


        private void palettePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseDown(e))
            {
                activeScene.room.reloadGfx(true, entrance_blockset);
                activeScene.need_refresh = true;
            }
        }

        private void palettePicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseUp(e))
            {
                activeScene.room.reloadGfx(true, entrance_blockset);
                activeScene.need_refresh = true;
            }
        }

        private void palettePicturebox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseDoubleclick(e, colorDialog1))
            {
                activeScene.room.reloadGfx(true, entrance_blockset);
                activeScene.need_refresh = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paletteViewer.randomizePalette(activeScene.room.palette);
            activeScene.room.reloadGfx(true, entrance_blockset);
            activeScene.need_refresh = true;
        }







        private void showBG1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DScene ds in rooms)
            {
                ds.scene.showLayer1 = showBG1ToolStripMenuItem.Checked;
            }
            activeScene.need_refresh = true;
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


        RoomLayout layoutForm;

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
                activeScene.room.reloadGfx(false);
            }
        }

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
        List<short> selectedMapPng = new List<short>();
        private void mapPicturebox_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void entranceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {


            //entranceLabel.Text = "Room : " + roomId.ToString() + "\nX Position : " + xPosition.ToString() + "\nY Position : " + yPosition.ToString();
        }
        byte entrance_blockset = 0xFF;
        private void button3_Click(object sender, EventArgs e)
        {
            //byte blockset = (byte)(ROM.DATA[(Constants.entrance_blockset + entranceListBox.SelectedIndex)]);
            //entrance_blockset = blockset;
            if (entrancetreeView.SelectedNode.Tag != null)
            {

            }
            //roomgfxUpDown.Value = blockset;

        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }






        string[] messages = new string[400];
        int[] messagesPos = new int[400];
        public void readAllText()
        {


            int pos = 0xE0000;
            int msgid = 0;


            while (msgid < 400)
            {
                messagesPos[msgid] = pos;
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

                    if (ROM.DATA[pos] == 0xFD) //kanji
                    {
                        pos++;
                        messages[msgid] += table_char.hexToChar(ROM.DATA[pos], true);
                        pos++;
                        continue;
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
                        messages[msgid] += "\r\n[LN2]\r\n";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xF9)
                    {
                        messages[msgid] += "\r\n[LN3]\r\n";
                        pos++;
                        continue;
                    }
                    if (ROM.DATA[pos] == 0xF6)
                    {
                        messages[msgid] += "\r\n[SCL]\r\n";
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
                            messages[msgid] += ROM.DATA[pos].ToString("X2") + "]";
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

                    if (ROM.DATA[pos] == 0xFA) //wait for key
                    {
                        pos++;
                        messages[msgid] += "[WFK]";
                        continue;
                    }
                    messages[msgid] += "[" + ROM.DATA[pos].ToString("X2") + "]";
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
            //readAllText();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void messageUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (version == "jp" || version == "vt")
            {
                if (messages[(int)messageUpDown.Value] != null)
                {
                    messagetextBox.Text = messages[(int)messageUpDown.Value];
                    label16.Text = "Addr: " + messagesPos[(int)messageUpDown.Value].ToString("X6");
                }
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void messageshowButton_Click(object sender, EventArgs e)
        {
            if (version == "jp" || version == "vt")
            {
                tabControl1.SelectTab("texttabPage");
                messageUpDown.Value = activeScene.room.messageid;
            }
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.insertNew();
        }

        private void bringToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.SendSelectedToBack();
        }

        private void textpreviewButton_Click(object sender, EventArgs e)
        {
            if (version == "jp" || version == "vt")
            {
                previewText.text = messagetextBox.Text;
                previewText.ShowDialog();
            }

        }

        private void messagetextBox_TextChanged(object sender, EventArgs e)
        {
            if (version == "jp" || version == "vt")
            {
                messages[(int)messageUpDown.Value] = messagetextBox.Text.ToUpper();

            }
        }

        private void sendToBg1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (activeScene.room.selectedObject.Count > 0)
            {
                debuglabel.Text = activeScene.room.selectedObject[0].GetType().ToString();
                if (activeScene.room.selectedObject[0] is Room_Object)
                {
                    activeScene.updating_info = true;
                    foreach (Room_Object o in activeScene.room.selectedObject)
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
                activeScene.need_refresh = true;
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

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            gfxPicturebox.Image = GFX.selectedtobmp(new byte[] {0,1,2,3 },(int)gfx2NumericUpDown.Value);
        }

        private void changeObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete the selected object and add the new one
            activeScene.changeObject();
        }

        private void zscreamForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {

           /* BinaryWriter br = new BinaryWriter(new FileStream("settings.cfg", FileMode.OpenOrCreate, FileAccess.Write));
            for (int i = 0; i < 5; i++)
            {
                if (recentProjects.Count > i)
                {
                    br.Write(recentProjects[i]);
                }
                else
                {
                    br.Write("");
                }

            }
            br.Close();*/


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

        private void createProjectFromROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //openRomFileDialog.ShowDialog();
            OpenFileDialog projectFile = new OpenFileDialog();
            if (projectFile.ShowDialog() == DialogResult.OK)
            {
                CreateProject(projectFile.FileName);
            }
        }

        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            activeScene.need_refresh = true;
            activeScene.room.reloadLayout();
            activeScene.room.has_changed = true;
            activeScene.room.reloadGfx(false, entrance_blockset);
            //scene.sceneChanged = true;
            anychange = true;


            if (activeScene.room.damagepit == true)
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
                if (pitCountNew > pitCount)
                {
                    MessageBox.Show("Can't add more pit damage !");
                    activeScene.room.damagepit = false;
                }
                else
                {
                    activeScene.room.damagepit = true;
                }
            }
            else
            {

                activeScene.room.damagepit = false;
            }

        }

        private void showBG2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.showLayer2 = showBG2ToolStripMenuItem.Checked;
            activeScene.need_refresh = true;
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
            if (version == "vt" || version == "jp")
            {


                foreach (Control c in groupBox5.Controls)
                {
                    if (c.GetType() == typeof(CheckBox))
                    {
                        (c as CheckBox).Checked = false;
                    }
                }

                if (ROM.DATA[Constants.initial_equipement] == 1)
                {
                    equipBowCheckbox.Checked = true;
                }

                if (ROM.DATA[Constants.initial_equipement] == 3)
                {
                    equipSilverarrowCheckBox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 1] == 1)
                {
                    equipBoomerangCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 1] == 2)
                {
                    equipBoomerangredCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 2] == 1)
                {
                    equipHookshotCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 3] == 10)
                {
                    equipBombsCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 4] == 1)
                {
                    equipMushroomCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 4] == 2)
                {
                    equipPowderCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 5] == 1)
                {
                    equipFirerodCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 6] == 1)
                {
                    equipIcerodCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 7] == 1)
                {
                    equipBombosCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 8] == 1)
                {
                    equipEtherCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 9] == 1)
                {
                    equipQuakeCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 10] == 1)
                {
                    equipLanternCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 11] == 1)
                {
                    equipHammerCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 12] == 1)
                {
                    equipShovelCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 12] == 2)
                {
                    equipFluteCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 12] == 3)
                {
                    equipFluteactiveCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 13] == 1)
                {
                    equipNetCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 14] == 1)
                {
                    equipBookCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 16] == 1)
                {
                    equipSomariaCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 17] == 1)
                {
                    equipByrnaCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 18] == 1)
                {
                    equipCapeCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 19] == 1)
                {
                    equipMirrorCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 21] == 1)
                {
                    equipBootsCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 22] == 1)
                {
                    equipFlippersCheckbox.Checked = true;
                }
                if (ROM.DATA[Constants.initial_equipement + 23] == 1)
                {
                    equipMoonpearlCheckbox.Checked = true;
                }

            (equipGlovescomboBox.SelectedIndex) = ROM.DATA[Constants.initial_equipement + 20];
                (equipSwordcomboBox.SelectedIndex) = ROM.DATA[Constants.initial_equipement + 25];
                (equipShieldcomboBox.SelectedIndex) = ROM.DATA[Constants.initial_equipement + 26];
                (equipMailcomboBox.SelectedIndex) = ROM.DATA[Constants.initial_equipement + 27];
                (equipBottle1Combobox.SelectedIndex) = ROM.DATA[Constants.initial_equipement + 28];
                (equipBottle2Combobox.SelectedIndex) = ROM.DATA[Constants.initial_equipement + 29];
                (equipBottle3Combobox.SelectedIndex) = ROM.DATA[Constants.initial_equipement + 30];
                (equipBottle4Combobox.SelectedIndex) = ROM.DATA[Constants.initial_equipement + 31];

                byte[] rupeec = new byte[2];

                rupeec[0] = ROM.DATA[Constants.initial_equipement + 32];
                rupeec[1] = ROM.DATA[Constants.initial_equipement + 33];
                rupeeNumericupdown.Value = BitConverter.ToInt16(rupeec, 0);
            }
        }
        private void saveInitialStuff()
        {
            for (int i = 0; i < 35; i++)
            {
                ROM.DATA[Constants.initial_equipement + i] = 0;
            }

            if (equipBowCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement] = 1;
            }
            if (equipSilverarrowCheckBox.Checked)
            {
                ROM.DATA[Constants.initial_equipement] = 3;
            }
            if (equipBoomerangCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 1] = 1;
            }
            if (equipBoomerangredCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 1] = 2;
            }
            if (equipHookshotCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 2] = 1;
            }
            if (equipBombsCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 3] = 10;
            }
            if (equipMushroomCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 4] = 1;
            }
            if (equipPowderCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 4] = 2;
            }
            if (equipFirerodCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 5] = 1;
            }
            if (equipIcerodCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 6] = 1;
            }
            if (equipBombosCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 7] = 1;
            }
            if (equipEtherCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 8] = 1;
            }
            if (equipQuakeCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 9] = 1;
            }
            if (equipLanternCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 10] = 1;
            }
            if (equipHammerCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 11] = 1;
            }
            if (equipShovelCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 12] = 1;
            }
            if (equipFluteCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 12] = 2;
            }
            if (equipFluteactiveCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 12] = 3;
            }
            if (equipNetCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 13] = 1;
            }
            if (equipBookCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 14] = 1;
            }

            if (equipSomariaCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 16] = 1;
            }
            if (equipByrnaCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 17] = 1;
            }
            if (equipCapeCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 18] = 1;
            }
            if (equipMirrorCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 19] = 1;
            }

            if (equipBootsCheckbox.Checked) //79
            {
                ROM.DATA[Constants.initial_equipement + 21] = 1;
                ROM.DATA[Constants.initial_equipement + 57] |= 0x04;
            }
            if (equipFlippersCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 22] = 1;
            }
            if (equipMoonpearlCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 23] = 1;
            }

            ROM.DATA[Constants.initial_equipement + 20] = (byte)(equipGlovescomboBox.SelectedIndex);
            ROM.DATA[Constants.initial_equipement + 25] = (byte)(equipSwordcomboBox.SelectedIndex);
            ROM.DATA[Constants.initial_equipement + 26] = (byte)(equipShieldcomboBox.SelectedIndex);
            ROM.DATA[Constants.initial_equipement + 27] = (byte)(equipMailcomboBox.SelectedIndex);
            ROM.DATA[Constants.initial_equipement + 28] = (byte)(equipBottle1Combobox.SelectedIndex);
            ROM.DATA[Constants.initial_equipement + 29] = (byte)(equipBottle2Combobox.SelectedIndex);
            ROM.DATA[Constants.initial_equipement + 30] = (byte)(equipBottle3Combobox.SelectedIndex);
            ROM.DATA[Constants.initial_equipement + 31] = (byte)(equipBottle4Combobox.SelectedIndex);
            if (equipBottle1Combobox.SelectedIndex != 0 || equipBottle2Combobox.SelectedIndex != 0 ||
                equipBottle3Combobox.SelectedIndex != 0 || equipBottle4Combobox.SelectedIndex != 0)
            {
                ROM.DATA[Constants.initial_equipement + 15] = 1;
            }
            else
            {
                ROM.DATA[Constants.initial_equipement + 15] = 0;
            }

            byte[] rupeec = new byte[2];
            BitConverter.ToInt16(rupeec, 0);
            rupeec = BitConverter.GetBytes((int)rupeeNumericupdown.Value);
            //ROM.DATA[Constants.initial_equipement + 32] = rupeec[0]; //30, 31
            //ROM.DATA[Constants.initial_equipement + 33] = rupeec[1]; //30, 31
            //31,30,29,28
            ROM.DATA[Constants.initial_equipement + 32] = rupeec[0]; //30, 31
            ROM.DATA[Constants.initial_equipement + 33] = rupeec[1]; //30, 31
            ROM.DATA[Constants.initial_equipement + 34] = rupeec[0]; //30, 31
            ROM.DATA[Constants.initial_equipement + 35] = rupeec[1]; //30, 31
        }

        private void entrancetreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                propertyGrid2.SelectedObject = entrances[(int)e.Node.Tag];
            }
        }

        private void objectsListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (objectsListbox.SelectedIndex != -1)
            {
                activeScene.selectedDragObject = (dataObject)objectsListbox.Items[objectsListbox.SelectedIndex];
                Room_Object ro = activeScene.room.addObject((objectsListbox.SelectedItem as dataObject).id, 0, 0, 0, 0);
                ro.setRoom(activeScene.room);
                ro.resetSize();
                ro.get_scroll_x();
                ro.get_scroll_y();

                if (ro.special_zero_size != 0)
                {
                    ro.size = 1;
                }

                ro.DrawOnBitmap();

                Bitmap b = new Bitmap(previewObjectPicturebox.Width, previewObjectPicturebox.Height);


                using (Graphics g = Graphics.FromImage(b))
                {
                    g.DrawImage(ro.bitmap, (previewObjectPicturebox.Width / 2) - (ro.bitmap.Width / 2), (previewObjectPicturebox.Height / 2) - (ro.bitmap.Height / 2));
                    previewObjectPicturebox.Image = b;
                }
            }
            else
            {
                activeScene.selectedDragObject = null;
            }
        }



        public void sortObject()
        {

            objectsListbox.BeginUpdate();
            objectsListbox.Items.Clear();
            //Sorting sort;
            Sorting sortsizing = Sorting.All;
            string searchText = searchTextbox.Text.ToLower();
            //listView1
            objectsListbox.Items.AddRange(listoftilesobjects
                .Where(x => x != null)
                //.Where(x => sort == 0 || (x.sort & sort) > 0)
                //.Where(x => (x.sort & sortsizing) > 0) //TODO : add sorting in the objectDATA
                .Where(x => (x.Name.ToLower().Contains(searchText)))
                .OrderBy(x => x.id)
                .Select(x => x) //?
                .ToArray());
            objectsListbox.EndUpdate();
        }

        public void sortSprite()
        {

            spritesListbox.BeginUpdate();
            spritesListbox.Items.Clear();
            string searchText = searchspriteTextbox.Text.ToLower();

            spritesListbox.Items.AddRange(listofspritesobjects
                .Where(x => x != null)
                .Where(x => (x.Name.ToLower().Contains(searchText)))
                .OrderBy(x => x.id)
                .Select(x => x) //?
                .ToArray());
            spritesListbox.EndUpdate();

        }


        private void searchTextbox_TextChanged(object sender, EventArgs e)
        {
            sortObject();
        }

        private void objectsListbox_DragLeave(object sender, EventArgs e)
        {

        }
        private void objectsListbox_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void selectedXNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (activeScene.room.selectedObject.Count == 1)
            {
                if (activeScene.room.selectedObject[0] is Room_Object)
                {

                    Room_Object o = activeScene.room.selectedObject[0] as Room_Object;

                    //use linq to iterate with layers
                    if (activeScene.updating_info == false)
                    {

                        o.nx = (byte)selectedXNumericUpDown.Value;
                        o.ny = (byte)selectedYNumericUpDown.Value;
                        o.ox = (byte)selectedXNumericUpDown.Value;
                        o.oy = (byte)selectedYNumericUpDown.Value;
                        o.x = (byte)selectedXNumericUpDown.Value;
                        o.y = (byte)selectedYNumericUpDown.Value;
                        o.size = (byte)selectedSizeNumericUpDown.Value;
                        o.layer = (byte)selectedLayerNumericUpDown.Value;
                        o.resetSize();
                        o.DrawOnBitmap();
                        activeScene.need_refresh = true;
                    }
                }
                else if (activeScene.room.selectedObject[0] is Sprite)
                {
                    Sprite o = activeScene.room.selectedObject[0] as Sprite;

                    if (activeScene.updating_info == false)
                    {

                        o.nx = (byte)selectedXNumericUpDown.Value;
                        o.ny = (byte)selectedYNumericUpDown.Value;
                        o.x = (byte)selectedXNumericUpDown.Value;
                        o.y = (byte)selectedYNumericUpDown.Value;
                        o.layer = (byte)selectedLayerNumericUpDown.Value;
                        o.subtype = (byte)spritesubtypeUpDown.Value;
                        o.overlord = (byte)(spriteoverlordCheckbox.Checked == true ? 1 : 0);
                        if ((o.subtype & 0xE0) == 0xE0)
                        {
                            //it an overlord
                        }
                    }
                    activeScene.need_refresh = true;
                }
                else if (activeScene.room.selectedObject[0] is PotItem)
                {

                    PotItem o = activeScene.room.selectedObject[0] as PotItem;

                    if (activeScene.updating_info == false)
                    {

                        o.nx = (byte)selectedXNumericUpDown.Value;
                        o.ny = (byte)selectedYNumericUpDown.Value;
                        o.x = (byte)selectedXNumericUpDown.Value;
                        o.y = (byte)selectedYNumericUpDown.Value;
                        o.layer = (byte)selectedLayerNumericUpDown.Value;
                    }
                    activeScene.need_refresh = true;

                }
            }
        }

        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // scene.showGrid = showGridToolStripMenuItem.Checked;
            // scene.need_refresh = true;
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
                activeScene.need_refresh = true;
            }
        }

        private void messagetextBox_Validated(object sender, EventArgs e)
        {
            messagetextBox.Text = messagetextBox.Text.ToUpper();
            messages[(int)messageUpDown.Value] = messagetextBox.Text.ToUpper();
        }

        private void searchtextListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            messageUpDown.Value = (searchtextListbox.Items[searchtextListbox.SelectedIndex] as dataObject).id;
        }

        private void searchtextTextbox_TextChanged(object sender, EventArgs e)
        {
            string searchtextText = searchtextTextbox.Text.ToUpper();

            if (searchtextText != "")
            {
                searchtextListbox.BeginUpdate();
                searchtextListbox.Items.Clear();
                string[] result = messages
                .Where(x => x != null)
                .Where(x => (x.ToUpper().Contains(searchtextText)))
                .Select((x, i) => x)
                .ToArray();




                for (int i = 0; i < result.Length; i++)
                {
                    int index = Array.IndexOf(messages, result[i]);
                    searchtextListbox.Items.Add(new dataObject((short)index, result[i]));
                }


                searchtextListbox.EndUpdate();
            }
            else
            {
                searchtextListbox.BeginUpdate();
                for (int i = 0; i < 400; i++)
                {
                    if (messages[i] != null)
                    {
                        searchtextListbox.Items.Add(new dataObject((short)i, messages[i]));
                    }
                }
                searchtextListbox.EndUpdate();
            }
        }



        private void spritesListbox_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void spritesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (spritesListbox.SelectedIndex != -1)
            {
                dataObject sprdata = (spritesListbox.Items[spritesListbox.SelectedIndex] as dataObject);
                activeScene.selectedDragSprite = sprdata;
                Sprite spr = new Sprite(activeScene.room, (byte)sprdata.id, 0, 0, sprdata.Name, 0, 0, 0);

                Bitmap b = new Bitmap(spritePreviewBox.Width, spritePreviewBox.Height, PixelFormat.Format32bppArgb);
                GFX.begin_draw(b, spritePreviewBox.Width, spritePreviewBox.Height);
                spr.Draw(true);
                GFX.end_draw(b);
                spritePreviewBox.Image = b;

                //update_modes_buttons(spritemodeButton, new EventArgs());
            }
            else
            {
                activeScene.selectedDragSprite = null;
            }
        }

        private void searchspriteTextbox_TextChanged(object sender, EventArgs e)
        {
            sortSprite();
        }

        private void spritesubtypeUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void palettesTreeview_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void selectedZUpDown_ValueChanged(object sender, EventArgs e)
        {
            activeScene.UpdateSelectedZ((int)selectedZUpDown.Value);
        }

        private void selectedZUpDown_ValueChanged_1(object sender, EventArgs e)
        {
            //scene.UpdateSelectedZ((int)selectedZUpDown.Value);
        }

        private void decreaseZToolStripMenuItem_Click(object sender, EventArgs e)
        {

            selectedZUpDown.Value -= 1;
            //scene.need_refresh = true;
        }

        private void increaseZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //scene.IncreaseSelectedZ();
            selectedZUpDown.Value += 1;
            //scene.need_refresh = true;
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
                    activeScene.need_refresh = true;
                }
            }
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
                Bitmap b = new Bitmap(8192, 8192);
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
                        activeScene.need_refresh = true;
                        activeScene.drawRoom();
                        gb.DrawImage(activeScene.scene_bitmap, new Point(cx * 512, cy * 512));
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
                b = null;
                nb = null;
            }
            else
            {

                //scene.scene_bitmap.Save("singlemap.png");
            }
            activeScene.room = savedRoom;
            activeScene.room.reloadGfx();
            activeScene.need_refresh = true;
            activeScene.drawRoom();

        }


        private void mapPicturebox_MouseDoubleClick(object sender, MouseEventArgs e)
        {

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
            foreach (DScene ds in rooms)
            {
                if (ds.scene.room.index == roomId)
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
                DScene ds = new DScene(this, "Room : " + r.index);
                Scene s = ds.scene;
                s.room = r;
                propertyGrid1.SelectedObject = r;
                rooms.Add(ds); //add the double clicked room into rooms list            
                s.need_refresh = true;
                s.room.reloadGfx(false);
                s.canSelectUnselectedBG = unselectedBGTransparentToolStripMenuItem.Checked;
                paletteViewer.update();
                s.initChestGfx();
                s.Enabled = true;
                s.Dock = DockStyle.Fill;
                //gfxPicturebox.Image = GFX.singletobmp(new byte[] { 0, 1, 2, 3 }, (int)gfx2NumericUpDown.Value);
                room_loaded = true;
                s.selectedMode = ObjectMode.Bg1mode;
                s.Enabled = true;
                ds.Text = "Room : " + r.index;
                ds.Show(dockPanel);
                ds.Controls.Add(s);
                s.BringToFront();
                s.Size = new Size(512, 512);
                objectsListbox.ClearSelected();
                spritesListbox.ClearSelected();
                updateScenesMode();
            }

        }

        public void updateTabsRooms()
        {

            
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
        public bool animated = false;
        private void animatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            animated = animatedToolStripMenuItem.Checked;
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
            //saveToolStripMenuItem_Click(this, new EventArgs());
            if (File.Exists("temp.sfc"))
            {
                File.Delete("temp.sfc");
            }
            FileStream brom = new FileStream("randobase.sfc", FileMode.Open, FileAccess.Read);
            brom.Read(ROM.DATA, 0, (int)brom.Length);
            brom.Close();

            byte[] romBackup = (byte[])ROM.DATA.Clone();
            Save save = new Save(all_rooms, entrances, messages);
            if (save.saveRoomsHeaders()) //no protection always the same size so we don't care :)
            {
                MessageBox.Show("Failed to save header??", "Bad Error", MessageBoxButtons.OK);
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
            if (save.saveTexts(messages, table_char))//There is a protection - Tested
            {
                MessageBox.Show("Failed to save, there is too many texts", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveEntrances(entrances))
            {
                MessageBox.Show("Failed to save entrances ?? no idea why LUL", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            saveInitialStuff(); //can't overwrite anything
            
            FileStream fs = new FileStream("temp.sfc", FileMode.CreateNew, FileAccess.Write);

            fs.Write(ROM.DATA, 0, ROM.DATA.Length);
            fs.Close();
            Process p = Process.Start("temp.sfc");
            
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                fs.Read(ROM.DATA, 0, (int)fs.Length);
                fs.Close();
            }*/
            int keyCount = 0;
            foreach(Room r in all_rooms)
            {
                foreach(PotItem p in r.pot_items)
                {
                    if (p.id == 0x08)
                    {
                        keyCount++;
                    }
                }
                foreach(Sprite spr in r.sprites)
                {
                    if (spr.id == 0xE4)
                    {
                        keyCount++;
                    }
                    if (spr.keyDrop == 1)
                    {
                        keyCount++;
                    }
                }
                foreach (Chest c in r.chest_list)
                {
                    if (c.item == 36)
                    {
                        keyCount++;
                    }
                }
            }
            Console.WriteLine(keyCount);

        }

        private void unselectedBGTransparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DScene ds in rooms)
            {
                ds.scene.canSelectUnselectedBG = unselectedBGTransparentToolStripMenuItem.Checked;
            }
        }

        public byte[] door_index = new byte[] { 0x00, 0x02,0x40, 0x1C, 0x26,0x0C,0x44, 0x18, 0x36, 0x38, 0x1E, 0x2E, 0x28, 0x46, 0x0E, 0x0A, 0x30, 0x12, 0x16,0x32 };
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex != -1)
            {
                if (activeScene.room.selectedObject.Count == 1)
                {
                    if (activeScene.room.selectedObject[0] is Room_Object)
                    {
                        if (activeScene.updating_info == false)
                        {
                            Room_Object o = (activeScene.room.selectedObject[0] as Room_Object);
                            if (o.options == ObjectOption.Door)
                            {
                                (o as object_door).door_type = ((byte)(door_index[comboBox2.SelectedIndex]));
                                (o as object_door).updateId();
                                (o as object_door).DrawOnBitmap();
                                activeScene.room.has_changed = true;
                                activeScene.room.reloadGfx();
                                activeScene.need_refresh = true;
                            }
                        }
                    }
                }
            }
        }

        private void importRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load loader = new Load();
            loader.loadSingleRoom(185, activeScene);
        }

        private void globalOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string debugstring = "";
            debugstring += "----------------------------------------------------------------\n";
            debugstring += "TILES OBJECTS                                                   \n";
            debugstring += "----------------------------------------------------------------\n";
            int i = 185;

                debugstring += "Object Count : " + all_rooms[i].tilesObjects.Count.ToString() + "\n";

            for (int j = 0; j < all_rooms[i].tilesObjects.Count; j++)
            {
                debugstring += "ID: " + all_rooms[i].tilesObjects[j].id.ToString("X2") + ", X:" + all_rooms[i].tilesObjects[j].x.ToString() +
                ",Y:" + all_rooms[i].tilesObjects[j].y.ToString() + "Size:" + all_rooms[i].tilesObjects[j].size + "Layer:" + all_rooms[i].tilesObjects[j].layer + "\n";
            }

            File.WriteAllText("Room185LOG", debugstring);
        }

        private void gfxgroupCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gfxgroupCombobox.SelectedIndex == 0)
            {
                gfx5NumericUpDown.Enabled = true;
                gfx6NumericUpDown.Enabled = true;
                gfx7NumericUpDown.Enabled = true;
                gfx8NumericUpDown.Enabled = true;
            }
            else
            {
                gfx5NumericUpDown.Enabled = false;
                gfx6NumericUpDown.Enabled = false;
                gfx7NumericUpDown.Enabled = false;
                gfx8NumericUpDown.Enabled = false;
            }

            loadGfxGroups();

        }

        public void loadGfxGroups()
        {
            int gfxPointer = (ROM.DATA[Constants.gfx_groups_pointer + 1] << 8) + ROM.DATA[Constants.gfx_groups_pointer];
            gfxPointer = Addresses.snestopc(gfxPointer);
            if (gfxgroupCombobox.SelectedIndex == 0) //main gfx
            {
                if (gfxgroupindexUpDown.Value > 36) { gfxgroupindexUpDown.Value = 0; }
                gfx1NumericUpDown.Value = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 0];
                gfx2NumericUpDown.Value = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 1];
                gfx3NumericUpDown.Value = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 2];
                gfx4NumericUpDown.Value = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 3];
                gfx5NumericUpDown.Value = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 4];
                gfx6NumericUpDown.Value = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 5];
                gfx7NumericUpDown.Value = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 6];
                gfx8NumericUpDown.Value = ROM.DATA[gfxPointer + ((int)gfxgroupindexUpDown.Value * 8) + 7];
            }
            else if (gfxgroupCombobox.SelectedIndex == 1) //entrances
            {
                if (gfxgroupindexUpDown.Value > 81) { gfxgroupindexUpDown.Value = 0; }
                gfx1NumericUpDown.Value = ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 0)];
                gfx2NumericUpDown.Value = ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 1)];
                gfx3NumericUpDown.Value = ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 2)];
                gfx4NumericUpDown.Value = ROM.DATA[(Constants.entrance_gfx_group + ((int)gfxgroupindexUpDown.Value * 4) + 3)];
            }
            else if (gfxgroupCombobox.SelectedIndex == 2) //sprites
            {
                if (gfxgroupindexUpDown.Value > 143) { gfxgroupindexUpDown.Value = 0; }
                gfx1NumericUpDown.Value = ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 0];
                gfx2NumericUpDown.Value = ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 1];
                gfx3NumericUpDown.Value = ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 2];
                gfx4NumericUpDown.Value = ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 3];
            }
        }

        private void gfxsinglechanged(object sender, EventArgs e)
        {
            gfxPicturebox.Image.Dispose();
            byte[] blocksetGfx = new byte[0];
            bool spr = false;
            if (gfxgroupCombobox.SelectedIndex == 0)
            {
                blocksetGfx = new byte[8] { (byte)gfx1NumericUpDown.Value, (byte)gfx2NumericUpDown.Value, (byte)gfx3NumericUpDown.Value, (byte)gfx4NumericUpDown.Value,
                (byte)gfx5NumericUpDown.Value, (byte)gfx6NumericUpDown.Value, (byte)gfx7NumericUpDown.Value, (byte)gfx8NumericUpDown.Value };
            }
            else if (gfxgroupCombobox.SelectedIndex == 1) //entrances
            {
                blocksetGfx = new byte[4] { (byte)gfx1NumericUpDown.Value, (byte)gfx2NumericUpDown.Value, (byte)gfx3NumericUpDown.Value, (byte)gfx4NumericUpDown.Value };
            }
            else if (gfxgroupCombobox.SelectedIndex == 2) //sprites
            {
                blocksetGfx = new byte[4] { (byte)(gfx1NumericUpDown.Value+115), (byte)(gfx2NumericUpDown.Value+115), (byte)(gfx3NumericUpDown.Value+115), (byte)(gfx4NumericUpDown.Value+115) };
                spr = true;
            }
            Bitmap b = GFX.selectedtobmp(blocksetGfx, (int)5, spr); ;
            gfxPicturebox.Image = new Bitmap(256, 1024);
            using (Graphics gfxG = Graphics.FromImage(gfxPicturebox.Image))
            {
                //gfxPicturebox.Image =
                gfxG.InterpolationMode = InterpolationMode.NearestNeighbor;
                gfxG.Clear(Color.Black);
                gfxG.DrawImage(b, 0, 0, b.Width * 2, b.Height * 2);
            }
            gfxPicturebox.Refresh();
            schedulegfxSave = true;


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

        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                projectFilename = sf.FileName;
                saveToolStripMenuItem_Click(sender, e);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            byte[] data = new byte[16 * 16 * 3];
            FileStream fs = new FileStream(activeScene.room.name+".pal", FileMode.OpenOrCreate, FileAccess.Write);
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
