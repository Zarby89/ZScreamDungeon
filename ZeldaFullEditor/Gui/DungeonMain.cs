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
using System.Threading;
using ZeldaFullEditor.Gui;

namespace ZeldaFullEditor
{

    public partial class DungeonMain : Form
    {
        public DungeonMain()
        {
            InitializeComponent();

        }
        //TODO : Move that to a data class

        //TODO : Move that?
        public byte[] door_index = new byte[] { 0x00, 0x06, 0x02, 0x40, 0x1C, 0x26, 0x0C, 0x44, 0x18, 0x36, 0x38, 0x1E, 0x2E, 0x28, 0x46, 0x0E, 0x0A, 0x30, 0x12, 0x16, 0x32, 0x20, 0x14, 0x2A, 0x22 };

        TextEditor textEditor = new TextEditor();
        OverworldEditor overworldEditor = new OverworldEditor();
        Object_Designer objDesigner = new Object_Designer();
        string projectFilename = "";
        public bool projectLoaded = false;
        bool anychange = false;
        public SceneUW activeScene;
        public List<Room> opened_rooms = new List<Room>();
        bool saved_changed = false;
        public TreeNode lastNode = null;
        RoomLayout layoutForm;
        List<short> selectedMapPng = new List<short>();
        public ChestPicker chestPicker = new ChestPicker();
        public bool settingEntrance = false;
        public int selectedLayer = -1;
        public Entrance selectedEntrance = null;
        PaletteEditor paletteForm;
        Bitmap xTabButton;
        Room previewRoom = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            xTabButton = new Bitmap(Resources.xbutton);
            layoutForm = new RoomLayout(this);
            initialize_properties();
            GFX.initGfx();
            ROMStructure.loadDefaultProject();
            mapPicturebox.Image = new Bitmap(256, 304);
            thumbnailBox.Size = new Size(256, 256);
            roomProperty_floor1.MouseWheel += RoomProperty_MouseWheel;
            roomProperty_floor2.MouseWheel += RoomProperty_MouseWheel;
            roomProperty_spriteset.MouseWheel += RoomProperty_MouseWheel;
            roomProperty_blockset.MouseWheel += RoomProperty_MouseWheel;
            roomProperty_palette.MouseWheel += RoomProperty_MouseWheel;
            refreshRecentsFiles();
            textEditor.Visible = false;
            overworldEditor.Visible = false;
            objDesigner.Visible = false;
            objDesigner.Dock = DockStyle.Fill;
            overworldEditor.Dock = DockStyle.Fill;
            textEditor.Dock = DockStyle.Fill;
            Controls.Add(overworldEditor);
            Controls.Add(textEditor);
            Controls.Add(objDesigner);

            
        }
        //Need to stay here
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


        //TODO : Move that to the save class
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
                /*DialogResult dialogResult = MessageBox.Show("Rooms has changed. Do you want to save changes?", "Save", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {

                }*/
                foreach (TabPage p in tabControl2.TabPages)
                {
                    if (p.Text.Contains("*"))
                    {
                        p.Text = p.Text.Trim('*');
                    }

                    DungeonsData.all_rooms[(p.Tag as Room).index] = (Room)(p.Tag as Room).Clone();
                    (p.Tag as Room).has_changed = false;
                    anychange = false;
                }
                tabControl2.Refresh();
            }

            byte[] romBackup = (byte[])ROM.DATA.Clone();
            Save save = new Save(DungeonsData.all_rooms);
            
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
            if (save.saveEntrances(DungeonsData.entrances, DungeonsData.starting_entrances))
            {
                MessageBox.Show("Failed to save entrances ?? no idea why LUL", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveAllText(textEditor))
            {
                MessageBox.Show("Impossible to save Texts", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }

            if (save.saveOWEntrances(overworldEditor.scene))
            {
                MessageBox.Show("Failed to save ??, no idea why ", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }

            if (save.saveOWItems(overworldEditor.scene))
            {
                MessageBox.Show("Failed to save overworld items out of range ", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }

            if (save.SaveOWSprites(overworldEditor.scene))
            {
                MessageBox.Show("Failed to save overworld sprites out of range ", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }

            if (save.saveOWTransports(overworldEditor.scene))
            {
                MessageBox.Show("Failed to save overworld transports out of range ", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }

            if (save.saveMapProperties(overworldEditor.scene))
            {
                MessageBox.Show("Failed to save overworld map properties ??? ", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }

            overworldEditor.scene.SaveTiles();

            Console.WriteLine("ROMDATA[" + (Constants.overworldMapPalette + 2).ToString("X6") + "]" + " : " + ROM.DATA[Constants.overworldMapPalette + 2]);
            AsarCLR.Asar.init();
            AsarCLR.Asar.patch("spritesmove.asm", ref ROM.DATA);

            Palettes.SavePalettesToROM(ROM.DATA);
            GfxGroups.SaveGroupsToROM();


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
            projectFile.Filter = "Alttp US ROM .sfc|*.sfc;*.smc";
            projectFile.DefaultExt = ".sfc";
            if (projectFile.ShowDialog() == DialogResult.OK)
            {
                projectFilename = projectFile.FileName;
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
            //TODO : Add Headered ROM

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int size = (int)fs.Length;
            if (fs.Length < 0x200000)
            {
                size = 0x200000;
            }
            ROM.DATA = new byte[size];
            if ((fs.Length & 0x200) == 0x200)
            {
                size = (int)(fs.Length - 0x200);
                byte[] tempRomData = new byte[fs.Length];
                fs.Read(tempRomData, 0, (int)fs.Length);
                Array.Copy(tempRomData, 0x200, ROM.DATA, 0, size);
            }
            else
            {
                fs.Read(ROM.DATA, 0, (int)fs.Length);
            }
            
            
            fs.Close();

            LoadPalettes();

            activeScene = new SceneUW(this);
            activeScene.Location = new Point(0, 0);
            activeScene.Size = new Size(512, 512);

            initProject();
            
            this.Text = "ZScream Magic - " + filename;

        }

        //TODO : Move that to a data class
        public void LoadPalettes()
        {
            Palettes.CreateAllPalettes(ROM.DATA);
        }

        public unsafe void initProject() 
        {
            tabControl1.Enabled = true;
            GfxGroups.LoadGfxGroups();
            GFX.CreateAllGfxData(ROM.DATA);

            for (int i = 0; i < 296; i++)
            {
                DungeonsData.all_rooms[i] = (new Room(i)); // create all rooms
                DungeonsData.undoRoom[i] = new List<Room>();
                DungeonsData.redoRoom[i] = new List<Room>();
            }





                initEntrancesList();
            this.customPanel3.Controls.Add(activeScene);
            addRoomTab(260);

            projectLoaded = true;

            tabControl2_SelectedIndexChanged(tabControl2.TabPages[0], new EventArgs());
            enableProjectButtons();



            //Initialize the map draw
            GFX.previewObjectsPtr = new IntPtr[600];
            GFX.previewObjectsBitmap = new Bitmap[600];
            GFX.previewSpritesPtr = new IntPtr[256];
            GFX.previewSpritesBitmap = new Bitmap[256];
            GFX.previewChestsPtr = new IntPtr[76];
            GFX.previewChestsBitmap = new Bitmap[76];
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
            for (int i = 0; i < 76; i++)
            {
                GFX.previewChestsPtr[i] = Marshal.AllocHGlobal(64 * 64);
                GFX.previewChestsBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, GFX.previewChestsPtr[i]);
            }
            Sprites_Names.loadFromFile();
            Room_Name.loadFromFile();
            ChestItems_Name.loadFromFile();
            ItemsNames.loadFromFile();
            
            initObjectsList();
            spritesView1.items.Clear();
            foreach (Sprite o in listofspritesobjects)
            {
                spritesView1.items.Add((o));
            }

            objectViewer1.items.Clear();
            foreach (Room_Object o in listoftilesobjects)
            {
                objectViewer1.items.Add((o));
            }
            selecteditemobjectCombobox.Items.Clear();
            for (int i = 0; i < ItemsNames.name.Length; i++)
            {
                selecteditemobjectCombobox.Items.Add(ItemsNames.name[i]);
            }

            GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
            GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
            objectViewer1.updateSize();
            spritesView1.updateSize();

            textSpriteToolStripMenuItem.Checked = Settings.Default.spriteText;
            textChestItemToolStripMenuItem.Checked = Settings.Default.chestText;
            textPotItemToolStripMenuItem.Checked = Settings.Default.itemText;
            unselectedBGTransparentToolStripMenuItem.Checked = Settings.Default.transparentBG;
            rightSideToolboxToolStripMenuItem.Checked = Settings.Default.rightToolbox;
            hideSpritesToolStripMenuItem.Checked = Settings.Default.spriteShow;
            hideItemsToolStripMenuItem.Checked = Settings.Default.itemsShow;
            hideChestItemsToolStripMenuItem.Checked = Settings.Default.chestitemShow;
            showDoorIDsToolStripMenuItem.Checked = Settings.Default.dooridShow;
            showChestsIDsToolStripMenuItem.Checked = Settings.Default.chestidShow;
            disableEntranceGFXToolStripMenuItem.Checked = Settings.Default.disableentranceGfx;
            showBG2MaskOutlineToolStripMenuItem.Checked = Settings.Default.bg2maskShow;
            entranceCameraToolStripMenuItem.Checked = Settings.Default.entranceCamera;
            entrancePositionToolStripMenuItem.Checked = Settings.Default.entrancePos;

            activeScene.DrawRoom();
            activeScene.Refresh();

            undoButton.Enabled = true;
            redoButton.Enabled = true;

            if (Settings.Default.recentFiles.Contains(projectFilename))
            {
                Settings.Default.recentFiles.Remove(projectFilename);
            }
            Settings.Default.recentFiles.Insert(0, projectFilename);
            while (Settings.Default.recentFiles.Count > 5)
            {
                Settings.Default.recentFiles.RemoveAt(4);
            }

            entrancetreeView_AfterSelect(null, null);
            gfxGroupsForm = new GfxGroupsForm(this);
            gfxGroupsForm.CreateTempGfx();
            gfxGroupsForm.Location = new Point(0, 0);

            paletteForm = new PaletteEditor(this);
           
            paletteForm.Location = new Point(0, 0);
            refreshRecentsFiles();
            overworldEditor.InitOpen(this);
            textEditor.initOpen();

            

        }

        private void OpenRecentProject(object sender, EventArgs e)
        {
            projectFilename = (sender as ToolStripMenuItem).Text;
            LoadProject((sender as ToolStripMenuItem).Text);
        }

        private void refreshRecentsFiles()
        {
            if (Settings.Default.recentFiles != null)
            {
                foreach (string s in Settings.Default.recentFiles)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(s);
                    tsmi.Click += OpenRecentProject;
                    recentROMToolStripMenuItem.DropDownItems.Add(tsmi);

                }
            }
        }

        public void initEntrancesList()
        {
            //entrances
            for (int i = 0; i < 0x07; i++)
            {
                DungeonsData.starting_entrances[i] = new Entrance((byte)i, true);
                string tname = "[" + i.ToString("X2") + "] -> ";
                foreach (DataRoom d in ROMStructure.dungeonsRoomList)
                {
                    if (d.id == DungeonsData.starting_entrances[i].Room)
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
                DungeonsData.entrances[i] = new Entrance((byte)i, false);
                string tname = "[" + i.ToString("X2") + "] -> ";
                foreach (DataRoom d in ROMStructure.dungeonsRoomList)
                {
                    if (d.id == DungeonsData.entrances[i].Room)
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
            selectedEntrance = DungeonsData.entrances[0];
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
            debugtestButton.Enabled = false;
            runtestButton.Enabled = true;
            potmodeButton.Enabled = true; //cant change to sprite since sprites are using 16x16
            saveToolStripMenuItem.Enabled = true;
            saveasToolStripMenuItem.Enabled = true;
            warpmodeButton.Enabled = true;
            saveLayoutButton.Enabled = true;
            loadlayoutButton.Enabled = true;
            toolStripButton1.Enabled = true;
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
            DungeonsData.all_rooms[roomId] = (Room)activeScene.room.Clone();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

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
            MessageBox.Show("Sorry this section do not exist yet :)\n" +
                "you can however find shortcuts not mentionned\n" +
                "- Mouse Wheel is used to resize objects for now\n" +
                "- Mouse Wheel Button is used to close rooms tabs");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editorsTabControl.SelectedIndex == 0) //dungeon editor
            {
                activeScene.mouse_down = false;
                activeScene.deleteSelected();
            }
            else if (editorsTabControl.SelectedIndex == 1) //overworld editor
            {
                overworldEditor.scene.mouse_down = false;
                overworldEditor.scene.deleteSelected();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editorsTabControl.SelectedIndex == 0) //dungeon editor
            {
                activeScene.mouse_down = false;
                activeScene.selectAll();
            }
            else if (editorsTabControl.SelectedIndex == 1) //overworld editor
            {
                overworldEditor.scene.mouse_down = false;
                overworldEditor.scene.selectAll();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editorsTabControl.SelectedIndex == 0) //dungeon editor
            {
                activeScene.mouse_down = false;
                activeScene.cut();
            }
            else if (editorsTabControl.SelectedIndex == 1) //overworld editor
            {
                overworldEditor.scene.mouse_down = false;
                overworldEditor.scene.cut();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editorsTabControl.SelectedIndex == 0) //dungeon editor
            {
                activeScene.paste();
            }
            else if (editorsTabControl.SelectedIndex == 1) //overworld editor
            {
                overworldEditor.scene.paste();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editorsTabControl.SelectedIndex == 0) //dungeon editor
            {
                activeScene.mouse_down = false;
                activeScene.copy();
            }
            else if (editorsTabControl.SelectedIndex == 1) //overworld editor
            {
                overworldEditor.scene.mouse_down = false;
                overworldEditor.scene.copy();
            }
        }

        private void showBG1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editorsTabControl.SelectedIndex == 0) //dungeon editor
            {
                activeScene.showLayer1 = showBG1ToolStripMenuItem.Checked;
                activeScene.DrawRoom();
                activeScene.Refresh();
            }

        }

        private void saveLayoutButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("Layout"))
            {
                Directory.CreateDirectory("Layout");
            }

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
            if (!Directory.Exists("Layout"))
            {
                Directory.CreateDirectory("Layout");
            }

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
                if (!visibleEntranceGFX)
                {
                    activeScene.room.reloadGfx(DungeonsData.entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
                }
                else
                {
                    activeScene.room.reloadGfx();
                }
                
            }
        }

        
        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bring to front -_-
            activeScene.mouse_down = false;
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
            activeScene.mouse_down = false;
            activeScene.insertNew();
            
        }

        private void bringToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.mouse_down = false;
            activeScene.SendSelectedToBack();
        }

        private void sendToBg1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.mouse_down = false;
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
                activeScene.DrawRoom();
                activeScene.Refresh();
            }
        }

        private void sendToBg1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            activeScene.mouse_down = false;
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
            activeScene.mouse_down = false;
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
                activeScene.DrawRoom();
                activeScene.Refresh();
            }
        }

        private void zscreamForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (projectLoaded)
            {

                //Properties.Settings.Default.ViewParameters;
                Settings.Default.spriteText = textSpriteToolStripMenuItem.Checked;
                Settings.Default.chestText = textChestItemToolStripMenuItem.Checked;
                Settings.Default.itemText = textPotItemToolStripMenuItem.Checked;
                Settings.Default.transparentBG = unselectedBGTransparentToolStripMenuItem.Checked;
                Settings.Default.rightToolbox = rightSideToolboxToolStripMenuItem.Checked;
                Settings.Default.spriteShow = hideSpritesToolStripMenuItem.Checked;
                Settings.Default.itemsShow = hideItemsToolStripMenuItem.Checked;
                Settings.Default.chestitemShow = hideChestItemsToolStripMenuItem.Checked;
                Settings.Default.dooridShow = showDoorIDsToolStripMenuItem.Checked;
                Settings.Default.chestidShow = showChestsIDsToolStripMenuItem.Checked;
                Settings.Default.disableentranceGfx = disableEntranceGFXToolStripMenuItem.Checked;
                Settings.Default.bg2maskShow = showBG2MaskOutlineToolStripMenuItem.Checked;
                Settings.Default.entranceCamera = entranceCameraToolStripMenuItem.Checked;
                Settings.Default.entrancePos = entrancePositionToolStripMenuItem.Checked;
                Settings.Default.Save();
            }


            if (anychange)
            {
                DungeonsData.all_rooms[activeScene.room.index] = activeScene.room;
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

        public void entrancetreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!projectLoaded)
            {
                return;
            }
            propertiesChangedFromForm = true;
            Entrance en = selectedEntrance;
            if (e != null)
            {
                if (e.Node.Tag != null)
                {
                    en = DungeonsData.entrances[(int)e.Node.Tag];
                    if (e.Node.Parent != null)
                    {
                        if (e.Node.Parent.Name == "StartingEntranceNode")
                        {
                            en = DungeonsData.starting_entrances[(int)e.Node.Tag];
                        }
                    }
                }
            }
            //propertyGrid2.SelectedObject = entrances[(int)e.Node.Tag];
            entranceProperty_bg.Checked = false;

            entranceProperty_room.Text = en.Room.ToString();
            entranceProperty_floor.Text = en.Floor.ToString();
            entranceProperty_exit.Text = en.Exit.ToString();
            entranceProperty_dungeon.Text = en.Dungeon.ToString();
            entranceProperty_blockset.Text = en.Blockset.ToString();
            entranceProperty_music.Text = en.Music.ToString();

            

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
            if ((en.Ladderbg & 0x10) == 0x10)
            {
                entranceProperty_bg.Checked = true;
            }

            if (activeScene.room != null)
            {

                selectedEntrance = en;
                if (!visibleEntranceGFX)
                {
                    activeScene.room.reloadGfx(en.Blockset);
                }
                else
                {
                    activeScene.room.reloadGfx();
                }
                activeScene.DrawRoom();
                activeScene.Refresh();
            }

            propertiesChangedFromForm = false;





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

            panel1.VerticalScroll.Value = 0;
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
            customPanel1.VerticalScroll.Value = 0;
            

            if (searchText == "")
            {
                spritesView1.items.Clear();
                foreach (Sprite o in listofspritesobjects)
                {
                    spritesView1.items.Add((o));
                }

            }
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
                //MessageBox.Show("That room is already opened !");
                foreach(TabPage tp in tabControl2.TabPages)
                {
                    if ((tp.Tag as Room).index == roomId)
                    {
                        tabControl2.SelectTab(tp);
                        break;
                        //tp.Select();
                    }
                }
                return;
            }
            else
            {
                Room r = (Room)DungeonsData.all_rooms[roomId].Clone();
                if (DungeonsData.undoRoom[r.index].Count == 0)
                {
                    DungeonsData.undoRoom[r.index].Add((Room)r.Clone());
                    DungeonsData.redoRoom[r.index].Clear();
                    undoButton.Enabled = false;
                    undoToolStripMenuItem.Enabled = false;
                }
                else
                {
                    undoButton.Enabled = true;
                    undoToolStripMenuItem.Enabled = true;
                }
                if (DungeonsData.redoRoom[r.index].Count > 0)
                {
                    redoButton.Enabled = true;
                    redoToolStripMenuItem.Enabled = true;
                }
                else
                {
                    redoButton.Enabled = false;
                    redoToolStripMenuItem.Enabled = false;
                }
                //mapPropertyGrid.SelectedObject = r;
                opened_rooms.Add(r); //add the double clicked room into rooms list     
                activeScene.room = r;
                TabPage tp = new TabPage(r.index.ToString("D3"));
                tp.Tag = r;
                tabControl2.TabPages.Add(tp);
                //objectsListbox.ClearSelected();
                tabControl2.SelectedTab = tp;

                if (!visibleEntranceGFX)
                {
                    activeScene.room.reloadGfx(DungeonsData.entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
                }
                else
                {
                    activeScene.room.reloadGfx();
                }
                
                GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
                GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
                activeScene.SetPalettesBlack();
                //paletteViewer.update();
                activeScene.DrawRoom();
                activeScene.Refresh();
                
                objectViewer1.updateSize();
                spritesView1.updateSize();


            }

            if (tabControl2.TabPages.Count > 0)
            {
                tabControl2.Visible = true;
                activeScene.Refresh();
            }

            cgramViewer.Refresh();

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
                    addRoomTab(DungeonsData.entrances[(int)e.Node.Tag].Room);
                }
                else
                {
                    addRoomTab(DungeonsData.starting_entrances[(int)e.Node.Tag].Room);
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
                //loadRoomList(roomId);

            }
            else
            {
                if (roomId < 296)
                {

                    addRoomTab((short)roomId);
                    //loadRoomList(roomId);
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
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Doors
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


        private void debugtestButton_Click(object sender, EventArgs e)
        {
             if (File.Exists("temp.sfc"))
             {
                 File.Delete("temp.sfc");
             }
            byte[] data = new byte[ROM.DATA.Length];
            ROM.DATA.CopyTo(data,0);
             saveToolStripMenuItem_Click(sender, e);
            AsarCLR.Asar.init();
            AsarCLR.Asar.patch("debug.asm", ref data);


            foreach (AsarCLR.Asarerror error in AsarCLR.Asar.geterrors())
            {
                Console.WriteLine(error.Fullerrdata.ToString());
            }

            FileStream fs = new FileStream("temp.sfc", FileMode.CreateNew, FileAccess.Write);
             fs.Write(data, 0, data.Length);
             fs.Close();
             Process p = Process.Start("temp.sfc");
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
            //loadRoomList(296);
        }

        private void deselectedAllMapForExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedMapPng.Clear();
            //loadRoomList(296);
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
            updateRoomInfos();
        }

        private void roomProperty_layout_TextChanged(object sender, EventArgs e)
        {
            updateRoomInfos();
        }

        private void roomProperty_pit_CheckedChanged(object sender, EventArgs e)
        {
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
                    if (r <= 40)
                    {
                        activeScene.room.Palette = r;
                    }
                    else
                    {
                        roomProperty_palette.Text = "40";
                        activeScene.room.Palette = 40;
                    }
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


                if (!visibleEntranceGFX)
                {
                    activeScene.room.reloadGfx(DungeonsData.entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
                }
                else
                {
                    activeScene.room.reloadGfx();
                }

                /*undoRoom[activeScene.room.index].Add((Room)activeScene.room.Clone());
                redoRoom[activeScene.room.index].Clear();
                */
                GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
                GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
                activeScene.SetPalettesBlack();
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


                GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
                GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
                activeScene.SetPalettesBlack();
                if (!visibleEntranceGFX)
                {
                    activeScene.room.reloadGfx(DungeonsData.entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
                }
                else
                {
                    activeScene.room.reloadGfx();
                }
                activeScene.DrawRoom();
                activeScene.Refresh();
                activeScene.room.has_changed = true;
            }
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

        private void CloseTab(int i)
        {
            if ((tabControl2.TabPages[i].Tag as Room).has_changed)
            {
                DialogResult dr = MessageBox.Show("Room has changed do you want to save?", "Warning", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    DungeonsData.all_rooms[(tabControl2.TabPages[i].Tag as Room).index] = (Room)(tabControl2.TabPages[i].Tag as Room).Clone();
                    closeRoom((tabControl2.TabPages[i].Tag as Room).index);
                    this.tabControl2.TabPages.RemoveAt(i);
                    if (tabControl2.TabPages.Count == 0)
                    {
                        activeScene.Clear();
                        tabControl2.Visible = false;
                        activeScene.Refresh();
                    }
                }
                else if (dr == DialogResult.No)
                {
                    closeRoom((tabControl2.TabPages[i].Tag as Room).index);
                    this.tabControl2.TabPages.RemoveAt(i);
                    if (tabControl2.TabPages.Count == 0)
                    {
                        activeScene.Clear();
                        tabControl2.Visible = false;
                        activeScene.Refresh();
                    }
                }
                else if (dr == DialogResult.Cancel)
                {

                }
            }
            else
            {
                closeRoom((tabControl2.TabPages[i].Tag as Room).index);
                this.tabControl2.TabPages.RemoveAt(i);
                if (tabControl2.TabPages.Count == 0)
                {
                    tabControl2.Visible = false;
                    activeScene.Clear();
                    activeScene.room = null;
                    activeScene.Refresh();
                }
            }
            tabControl2.Refresh();
        }

        private void tabControl2_MouseClick(object sender, MouseEventArgs e)
        {



            //loadRoomList(0);
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl2.TabPages.Count > 0)
            {
                activeScene.room = (tabControl2.TabPages[tabControl2.SelectedIndex].Tag as Room);
                activeScene.updateRoomInfos(this);
                if (DungeonsData.undoRoom[activeScene.room.index].Count > 0)
                { 
                    undoButton.Enabled = true;
                    undoToolStripMenuItem.Enabled = true;
                }
                else
                {
                    redoButton.Enabled = false;
                    redoToolStripMenuItem.Enabled = false;
                }
                if (DungeonsData.redoRoom[activeScene.room.index].Count > 0)
                {
                    redoButton.Enabled = true;
                    redoToolStripMenuItem.Enabled = true;
                }
                else
                {
                    redoButton.Enabled = false;
                    redoToolStripMenuItem.Enabled = false;
                }
                if (!visibleEntranceGFX)
                {
                    activeScene.room.reloadGfx(DungeonsData.entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
                }
                else
                {
                    activeScene.room.reloadGfx();
                }

                GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
                GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
                activeScene.SetPalettesBlack();

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
            mapPicturebox.Refresh();
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
                Sprite s = new Sprite(activeScene.room, (byte)i, 0, 0, 0, 0);
                s.preview = true;
                listofspritesobjects.Add(s);
            }
            for (int i = 1; i < 0x1B; i++)
            {
                Sprite s = new Sprite(activeScene.room, (byte)i, 0, 0, 7, 0);
                s.preview = true;
                listofspritesobjects.Add(s);
            }


                //sortObject();
            }
        List<Chest> listofchests = new List<Chest>();


        private void objectViewer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeScene.selectedDragObject = new dataObject(objectViewer1.selectedObject.id, objectViewer1.selectedObject.name);
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


        private void spritesView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeScene.selectedDragSprite = new dataObject(spritesView1.selectedObject.id, spritesView1.selectedObject.name, spritesView1.selectedObject.subtype);
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

                        activeScene.room = DungeonsData.all_rooms[s];
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

        private void litCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (activeScene.updating_info)
            {
                if (activeScene.room.selectedObject[0] is Room_Object)
                {
                    (activeScene.room.selectedObject[0] as Room_Object).lit = litCheckbox.Checked;
                }
            }

        }

        private void patchNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Zarby89/ZScreamDungeon/blob/master/ZeldaFullEditor/PatchNotes.txt");
        }

        private void spritesubtypeUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!activeScene.updating_info)
            {
                if (activeScene.room.selectedObject[0] is Sprite)
                {
                    (activeScene.room.selectedObject[0] as Sprite).subtype = (byte)spritesubtypeUpDown.Value;
                    
                }
                Console.WriteLine("WTF!");
            }
            
        }

        private void gotoRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoRoom gotoRoom = new GotoRoom();
            if (gotoRoom.ShowDialog() == DialogResult.OK)
            {
                addRoomTab((short)gotoRoom.SelectedRoom);
            }
        }

        private void advancedChestEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gui.AdvancedChestEditorForm chestEditorForm = new Gui.AdvancedChestEditorForm();
            chestEditorForm.ShowDialog();

        }

        private void RoomProperty_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (sender == roomProperty_spriteset)
                {
                    activeScene.room.Spriteset++;
                }
                if (sender == roomProperty_blockset)
                {
                    activeScene.room.Blockset++;
                }
                if (sender == roomProperty_palette)
                {
                    if (activeScene.room.Palette < 40)
                    {
                        activeScene.room.Palette++;
                    }
                }
                if (sender == roomProperty_floor1)
                {
                    activeScene.room.Floor1++;
                }
                if (sender == roomProperty_floor2)
                {
                    activeScene.room.Floor2++;
                }
            }
            else if (e.Delta < 0)
            {
                if (sender == roomProperty_spriteset)
                {
                    if (activeScene.room.Spriteset > 0)
                    {
                        activeScene.room.Spriteset--;
                    }
                }
                if (sender == roomProperty_blockset)
                {
                    if (activeScene.room.Blockset > 0)
                    {
                        activeScene.room.Blockset--;
                    }
                }
                if (sender == roomProperty_palette)
                {
                    if (activeScene.room.Palette > 0)
                    {
                        activeScene.room.Palette--;
                    }
                }
                if (sender == roomProperty_floor1)
                {
                    if (activeScene.room.Floor1 > 0)
                    {
                        activeScene.room.Floor1--;
                    }
                }
                if (sender == roomProperty_floor2)
                {
                    if (activeScene.room.Floor2 > 0)
                    {
                        activeScene.room.Floor2--;
                    }
                }

            }
            activeScene.updateRoomInfos(this);
            GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
            GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
            activeScene.SetPalettesTransparent();
            if (!visibleEntranceGFX)
            {
                activeScene.room.reloadGfx(selectedEntrance.Blockset);
            }
            else
            {
                activeScene.room.reloadGfx();
            }
            activeScene.DrawRoom();
            activeScene.Refresh();
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void mapPicturebox_Paint(object sender, PaintEventArgs e)
        {
            if (!projectLoaded)
            {
                return;
            }
            int xd = 0;
            int yd = 0;
            e.Graphics.Clear(Color.Black);
            for (int i = 0; i < 296; i++)
            {
                if (DungeonsData.all_rooms[i].tilesObjects.Count > 0)
                {

                    e.Graphics.FillRectangle(new SolidBrush(GFX.LoadDungeonPalette(DungeonsData.all_rooms[i].palette)[4, 2]), new Rectangle(xd * 16, yd * 16, 16, 16));

                    foreach (short s in selectedMapPng)
                    {
                        if (s == i)
                        {
                            e.Graphics.DrawRectangle(new Pen(Color.Aqua, 2), new Rectangle((xd * 16), (yd * 16), 16, 16));
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
                e.Graphics.DrawLine(Pens.White, 0, i * 16, 256, i * 16);
                e.Graphics.DrawLine(Pens.White, i * 16, 0, i * 16, 304);
            }
            xd = 0;
            yd = 0;
            int selectedxd = 0;
            int selectedyd = 0;
            for (int i = 0; i < 296; i++)
            {
                
                foreach (TabPage tp in tabControl2.TabPages)
                {
                    if ((tp.Tag as Room).index == (short)i)
                    {
                        if (tabControl2.SelectedTab == tp)
                        {
                            selectedxd = xd;
                            selectedyd = yd;
                        }
                        else
                        {
                            e.Graphics.DrawRectangle(new Pen(Color.DarkGreen, 2), new Rectangle((xd * 16), (yd * 16), 16, 16));
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
            e.Graphics.DrawRectangle(new Pen(Color.YellowGreen, 2), new Rectangle((selectedxd * 16), (selectedyd * 16), 16, 16));


        }
        //Groups of options for the Scene
        public bool showSprite = true;
        public bool showChest = true;
        public bool showItems = true;
        public bool showDoorsIDs = true;
        public bool showChestIDs = true;

        public bool showSpriteText = false;
        public bool showChestText = false;
        public bool showItemsText = false;

        public bool visibleEntranceGFX = false;
        public bool x2zoom = false;

        private void hideSpritesToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            showSprite = hideSpritesToolStripMenuItem.Checked;
            showChest = hideChestItemsToolStripMenuItem.Checked;
            showItems = hideItemsToolStripMenuItem.Checked;
            showDoorsIDs = showDoorIDsToolStripMenuItem.Checked;
            showChestIDs = showChestsIDsToolStripMenuItem.Checked;
            showSpriteText = textSpriteToolStripMenuItem.Checked;
            showChestText = textChestItemToolStripMenuItem.Checked;
            showItemsText = textPotItemToolStripMenuItem.Checked;
            visibleEntranceGFX = disableEntranceGFXToolStripMenuItem.Checked;
            x2zoom = xScreenToolStripMenuItem.Checked;

            if (x2zoom)
            {
                activeScene.Size = new Size(1024, 1024);
            }
            else
            {
                activeScene.Size = new Size(512, 512);
            }
            activeScene.Refresh();

        }

        private void dungeonsPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gui.DungeonPropertiesForm propertiesEditorForm = new Gui.DungeonPropertiesForm();
            propertiesEditorForm.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex != -1)
            {
                this.tabControl2.TabPages.RemoveAt(tabControl2.SelectedIndex);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool LockWindowUpdate(IntPtr hWnd);

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_COMPOSITED = 0x02000000;
                var cp = base.CreateParams;
                cp.ExStyle |= WS_EX_COMPOSITED;
                return cp;
            }
        }


        private void printRoomObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Room_Object o in activeScene.room.tilesObjects)
            {
                if (o.options == ObjectOption.Door)
                {
                    if (o is object_door)
                    {
                        object_door d = (o as object_door);
                        Console.WriteLine("n:" + d.name + ", door dir:" + d.door_dir + ", door pos:" + d.door_pos + ", door type:" + d.door_type);
                    }
                }
                else
                {
                    Console.WriteLine("n:" + o.name + ", w:" + o.width + ", h:" + o.height + ", L:" + o.layer);
                }
            }
            
        }

        private void removeMasksObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Room_Object> toRemove = new List<Room_Object>();
            foreach (Room_Object o in activeScene.room.tilesObjects)
            {
                if (o.name.ToLower().Contains("bg2"))
                {
                    toRemove.Add(o);
                }
                else if (o.name.ToLower().Contains("mask"))
                {
                    toRemove.Add(o);
                }
                if (o.id >= 0xA9 && o.id <= 0xAC)
                {
                    toRemove.Add(o);
                }
            }

            foreach (Room_Object o in toRemove)
            {
                activeScene.room.tilesObjects.Remove(o);
            }
        }

        private void gotoRoomToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GotoRoom gotoRoom = new GotoRoom();
            if (gotoRoom.ShowDialog() == DialogResult.OK)
            {
                addRoomTab((short)gotoRoom.SelectedRoom);
            }
        }

        private void clearSelectedRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.room.tilesObjects.Clear();
            activeScene.room.pot_items.Clear();
            activeScene.room.sprites.Clear();
            activeScene.room.chest_list.Clear();
            activeScene.DrawRoom();
            activeScene.Refresh();
        }

        private void clearAllRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear every rooms?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach(Room r in DungeonsData.all_rooms)
                {
                    r.tilesObjects.Clear();
                    r.pot_items.Clear();
                    r.sprites.Clear();
                    r.chest_list.Clear();
                }
                activeScene.DrawRoom();
                activeScene.Refresh();
            }

        }

        private void mouseEntranceButton_Click(object sender, EventArgs e)
        {
            settingEntrance = true;
            activeScene.mouse_down = false;
            activeScene.selectedDragObject = null;
            activeScene.selectedDragSprite = null;
            activeScene.room.selectedObject.Clear();
            activeScene.selectedMode = ObjectMode.EntrancePlacing;
        }

        private void exportAsASMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "ZScream Room Data|*.zrd";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(sf.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    byte[] roomdata = activeScene.room.getTilesBytes();
                    fs.Write(roomdata, 0, roomdata.Length);
                    fs.Close();
                }
            }
        }
        VramViewer vramViewer = new VramViewer();
        private void vramViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vramViewer = new VramViewer();
            WindowPanel wp = new WindowPanel();
            wp.Location = new Point(512, 0);
            wp.containerPanel.Controls.Add(vramViewer);
            wp.Tag = "Vram Viewer";
            wp.Size = new Size(vramViewer.Size.Width + 2, vramViewer.Size.Height + 26);
            customPanel3.Controls.Add(wp);
            wp.BringToFront();
        }

        private void warpButton_Click(object sender, EventArgs e)
        {
            WarpsForm warpForm = new WarpsForm();
            warpForm.roomProperty_hole.Text = activeScene.room.HoleWarp.ToString();
            warpForm.roomProperty_holeplane.Text = activeScene.room.HoleWarpPlane.ToString();
            warpForm.roomProperty_stair1.Text = activeScene.room.Staircase1.ToString();
            warpForm.roomProperty_stair1plane.Text = activeScene.room.Staircase1Plane.ToString();
            warpForm.roomProperty_stair2.Text = activeScene.room.Staircase2.ToString();
            warpForm.roomProperty_stair2plane.Text = activeScene.room.Staircase2Plane.ToString();
            warpForm.roomProperty_stair3.Text = activeScene.room.Staircase3.ToString();
            warpForm.roomProperty_stair3plane.Text = activeScene.room.Staircase3Plane.ToString();
            warpForm.roomProperty_stair4.Text = activeScene.room.Staircase4.ToString();
            warpForm.roomProperty_stair4plane.Text = activeScene.room.Staircase4Plane.ToString();
            if (warpForm.ShowDialog() == DialogResult.OK)
            {
                activeScene.room.HoleWarp = warpForm.properties[0];
                activeScene.room.HoleWarpPlane = warpForm.properties[1];

                activeScene.room.Staircase1 = warpForm.properties[2];

                activeScene.room.Staircase1Plane = warpForm.properties[3];

                activeScene.room.Staircase2 = warpForm.properties[4];

                activeScene.room.Staircase2Plane = warpForm.properties[5];

                activeScene.room.Staircase3 = warpForm.properties[6];

                activeScene.room.Staircase3Plane = warpForm.properties[7];

                activeScene.room.Staircase4 = warpForm.properties[8];

                activeScene.room.Staircase4Plane = warpForm.properties[9];

                activeScene.updateRoomInfos(this);
            }
        }

        private void showBG2MaskOutlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.showBG2Outline = showBG2MaskOutlineToolStripMenuItem.Checked;
            activeScene.Refresh();
        }

        private void entrancePropertyButton_Click(object sender, EventArgs e)
        {
            EntrancePropertyForm epForm = new EntrancePropertyForm();

            Entrance en = selectedEntrance;

            if (entrancetreeView.SelectedNode.Tag != null)
            {
                en = DungeonsData.entrances[(int)entrancetreeView.SelectedNode.Tag];
                if (entrancetreeView.SelectedNode.Parent != null)
                {
                    if (entrancetreeView.SelectedNode.Parent.Name == "StartingEntranceNode")
                    {
                        en = DungeonsData.starting_entrances[(int)entrancetreeView.SelectedNode.Tag];
                    }
                }
            }


            epForm.entranceProperty_vscroll.Checked = false;
            epForm.entranceProperty_hscroll.Checked = false;
            epForm.entranceProperty_quadbr.Checked = false;
            epForm.entranceProperty_quadbl.Checked = false;
            epForm.entranceProperty_quadtl.Checked = false;
            epForm.entranceProperty_quadtr.Checked = false;
            epForm.entranceProperty_scrollx.Text = en.XScroll.ToString();
            epForm.entranceProperty_scrolly.Text = en.YScroll.ToString();
            epForm.entranceProperty_xpos.Text = en.XPosition.ToString();
            epForm.entranceProperty_ypos.Text = en.YPosition.ToString();
            epForm.entranceProperty_camx.Text = en.XCamera.ToString();
            epForm.entranceProperty_camy.Text = en.YCamera.ToString();
            epForm.entranceProperty_FU.Text = en.scrolledge_FU.ToString();
            epForm.entranceProperty_HU.Text = en.scrolledge_HU.ToString();
            epForm.entranceProperty_HD.Text = en.scrolledge_HD.ToString();
            epForm.entranceProperty_FD.Text = en.scrolledge_FD.ToString();
            epForm.entranceProperty_FL.Text = en.scrolledge_FL.ToString();
            epForm.entranceProperty_FR.Text = en.scrolledge_FR.ToString();
            epForm.entranceProperty_HL.Text = en.scrolledge_HL.ToString();
            epForm.entranceProperty_HR.Text = en.scrolledge_HR.ToString();

            if ((en.Scrolling & 0x20) == 0x20)
            {
                epForm.entranceProperty_hscroll.Checked = true;
            }

            if ((en.Scrolling & 0x02) == 0x02)
            {
                epForm.entranceProperty_vscroll.Checked = true;
            }

            if (en.Scrollquadrant == 0x12) //bottom right
            {
                epForm.entranceProperty_quadbr.Checked = true;
            }
            else if (en.Scrollquadrant == 0x02) //bottom left
            {
                epForm.entranceProperty_quadbl.Checked = true;
            }
            else if (en.Scrollquadrant == 0x00) //top left
            {
                epForm.entranceProperty_quadtl.Checked = true;
            }
            else if (en.Scrollquadrant == 0x10) //top right
            {
                epForm.entranceProperty_quadtr.Checked = true;
            }


            if (epForm.ShowDialog() == DialogResult.OK)
            {
                int r = 0;
                if (int.TryParse(epForm.entranceProperty_HU.Text, out r))
                {
                    selectedEntrance.scrolledge_HU = (byte)r;
                }

                if (int.TryParse(epForm.entranceProperty_FU.Text, out r))
                {
                    selectedEntrance.scrolledge_FU = (byte)r;
                }

                if (int.TryParse(epForm.entranceProperty_HD.Text, out r))
                {
                    selectedEntrance.scrolledge_HD = (byte)r;
                }

                if (int.TryParse(epForm.entranceProperty_FD.Text, out r))
                {
                    selectedEntrance.scrolledge_FD = (byte)r;
                }

                if (int.TryParse(epForm.entranceProperty_HL.Text, out r))
                {
                    selectedEntrance.scrolledge_HL = (byte)r;
                }

                if (int.TryParse(epForm.entranceProperty_HR.Text, out r))
                {
                    selectedEntrance.scrolledge_HR = (byte)r;
                }

                if (int.TryParse(epForm.entranceProperty_FL.Text, out r))
                {
                    selectedEntrance.scrolledge_FL = (byte)r;
                }

                if (int.TryParse(epForm.entranceProperty_FR.Text, out r))
                {
                    selectedEntrance.scrolledge_FR = (byte)r;
                }


                if (int.TryParse(epForm.entranceProperty_camx.Text, out r))
                {
                    selectedEntrance.XCamera = (short)r;
                }
                else
                {
                    selectedEntrance.XCamera = 0;
                }

                if (int.TryParse(epForm.entranceProperty_camy.Text, out r))
                {
                    selectedEntrance.YCamera = (short)r;
                }
                else
                {
                    selectedEntrance.YCamera = 0;
                }

                if (int.TryParse(epForm.entranceProperty_xpos.Text, out r))
                {
                    selectedEntrance.XPosition = (short)r;
                }
                else
                {
                    selectedEntrance.XPosition = 0;
                }

                if (int.TryParse(epForm.entranceProperty_ypos.Text, out r))
                {
                    selectedEntrance.YPosition = (short)r;
                }
                else
                {
                    selectedEntrance.YPosition = 0;
                }

                if (int.TryParse(epForm.entranceProperty_scrollx.Text, out r))
                {
                    selectedEntrance.XScroll = (short)r;
                }
                else
                {
                    selectedEntrance.XScroll = 0;
                }

                if (int.TryParse(epForm.entranceProperty_scrolly.Text, out r))
                {
                    selectedEntrance.YScroll = (short)r;
                }
                else
                {
                    selectedEntrance.YScroll = 0;
                }

                byte b = 0;
                if (epForm.entranceProperty_hscroll.Checked)
                {
                    b += 0x20;
                }
                if (epForm.entranceProperty_vscroll.Checked)
                {
                    b += 0x02;
                }

                if (epForm.entranceProperty_quadbr.Checked) //bottom right
                {
                    selectedEntrance.Scrollquadrant = 0x12;
                }
                else if (epForm.entranceProperty_quadbl.Checked) //bottom left
                {
                    selectedEntrance.Scrollquadrant = 0x02;
                }
                else if (epForm.entranceProperty_quadtl.Checked) //top left
                {
                    selectedEntrance.Scrollquadrant = 0x00;
                }
                else if (epForm.entranceProperty_quadtr.Checked) //top right
                {
                    selectedEntrance.Scrollquadrant = 0x10;
                }
                //if (entranceProperty_quadbl)

                selectedEntrance.Scrolling = b;

            }

        }

        private void entranceCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.Refresh();
        }

        private void entrancePositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.Refresh();
        }

        private void loadNamesFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Sprites_Names.loadFromFile(ofd.FileName);
                    Room_Name.loadFromFile(ofd.FileName);
                    ChestItems_Name.loadFromFile(ofd.FileName);
                    ItemsNames.loadFromFile(ofd.FileName);
                    selecteditemobjectCombobox.Items.Clear();
                    for(int i = 0;i<ItemsNames.name.Length;i++)
                    {
                        selecteditemobjectCombobox.Items.Add(ItemsNames.name[i]);
                    }
                }
            }

                
        }
        public CGRamViewer cgramViewer = new CGRamViewer();
        private void cGramViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cgramViewer = new CGRamViewer();
            WindowPanel wp = new WindowPanel();
            wp.Tag = "CGRam Viewer - Right click to export palettes";
            wp.Location = new Point(512, 0);
            wp.containerPanel.Controls.Add(cgramViewer);
            wp.Size = new Size(cgramViewer.Size.Width + 2, cgramViewer.Size.Height + 26);
            customPanel3.Controls.Add(wp);
            wp.BringToFront();
        }

        public GfxGroupsForm gfxGroupsForm;
        private void gfxGroupsetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowPanel wp = new WindowPanel();
            wp.Tag = "Gfx Groupset Editor";
            wp.Location = new Point(512, 0);
            wp.containerPanel.Controls.Add(gfxGroupsForm);
            wp.Size = new Size(gfxGroupsForm.Size.Width + 2, gfxGroupsForm.Size.Height + 26);
            customPanel3.Controls.Add(wp);
            wp.BringToFront();
        }

        private void insertToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            activeScene.mouse_down = false;
            activeScene.insertNew();
        }

        private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            activeScene.mouse_down = false;
            activeScene.insertNew();
        }

        private void insertToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            activeScene.mouse_down = false;
            activeScene.insertNew();
        }

        private void palettesEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowPanel wp = new WindowPanel();
            wp.Tag = "Palettes Editor";
            wp.Location = new Point(512, 0);
            wp.containerPanel.Controls.Add(paletteForm);
            wp.Size = new Size(paletteForm.Size.Width + 2, paletteForm.Size.Height + 26);
            customPanel3.Controls.Add(wp);
            paletteForm.BringToFront();
            wp.BringToFront();
        }

        //Export Palette to YY-CHR Palette Format
        /*            

            }*/
        int tpHotTracked = -1;
        int tpHotTrackedToClose = -1;
        int tpHotTrackedToCloseLast = -2;
        int lasttpHotTracked = -2;
        private void DrawOnTab(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Blue);
            Font font = (sender as TabControl).Font;
            SolidBrush b = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
            SolidBrush bs = new SolidBrush(Color.FromKnownColor(KnownColor.ControlLight));
            if (tpHotTracked == e.Index || e.State == DrawItemState.Selected)
            {
                g.FillRectangle(bs, e.Bounds);
                g.DrawString(tabControl2.TabPages[e.Index].Text, font, Brushes.Blue, new Rectangle(e.Bounds.X, e.Bounds.Y + 2, 64, 24));
                if (tpHotTrackedToClose == e.Index)
                {
                    g.DrawImage(xTabButton, new Rectangle(e.Bounds.X+30, e.Bounds.Y, 16, 16), 16, 0, 16, 16, GraphicsUnit.Pixel);
                }
                else
                {
                    g.DrawImage(xTabButton, new Rectangle(e.Bounds.X+30, e.Bounds.Y, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel);
                }
                
                //g.DrawString("000", font, Brushes.Blue, new Rectangle(e.Bounds.X, e.Bounds.Y + 4, 64, 24));
            }
            else
            {
                g.FillRectangle(b, e.Bounds);
                g.DrawString(tabControl2.TabPages[e.Index].Text, font, Brushes.Black, new Rectangle(e.Bounds.X, e.Bounds.Y + 2, 64, 24));
            }
            b.Dispose();
            bs.Dispose();
           

        }

        private void tabControl2_MouseMove(object sender, MouseEventArgs e)
        {
            tpHotTrackedToClose = -1;
            for (int i = 0; i < tabControl2.TabPages.Count; i++)
            {
                Rectangle itemRect = tabControl2.GetTabRect(i);

                if (itemRect.Contains(e.Location))
                {
                    Rectangle xRect = tabControl2.GetTabRect(i);
                    xRect.X += 30;
                    xRect.Width = 16;

                    tpHotTracked = i;
                    if (xRect.Contains(e.Location))
                    {
                        tpHotTrackedToClose = i;
                    }
                    

                    //tabControl2.TabPages[i].Refresh();

                }
            }
            if (lasttpHotTracked != tpHotTracked || tpHotTrackedToCloseLast != tpHotTrackedToClose)
            {
                tabControl2.Refresh();
            }
            tpHotTrackedToCloseLast = tpHotTrackedToClose;
            lasttpHotTracked = tpHotTracked;


        }

        private void tabControl2_MouseLeave(object sender, EventArgs e)
        {
            tpHotTracked = -1;
            lasttpHotTracked = -2;
            tpHotTrackedToClose = -1;
            tpHotTrackedToCloseLast = -2;
            tabControl2.Refresh();

        }

        private void tabControl2_MouseEnter(object sender, EventArgs e)
        {
            tpHotTracked = -1;
            lasttpHotTracked = -2;
            tpHotTrackedToClose = -1;
            tpHotTrackedToCloseLast = -2;
            tabControl2.Refresh();
        }

        private void tabControl2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < tabControl2.TabCount; i++)
                {
                    Rectangle r = tabControl2.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        CloseTab(i);
                    }
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (tpHotTrackedToClose != -1)
                {
                    int ctab = tpHotTrackedToClose;
                    if (tpHotTrackedToClose == tabControl2.SelectedIndex)
                    {
                        tpHotTrackedToClose = -1;
                        tabControl2.SelectedIndex = 0;
                    }
                    CloseTab(ctab);

                }

            }
        }

        private void tabControl2_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (tpHotTrackedToClose != -1)
            {
                e.Cancel = true;
            }

        }

        private void customPanel3_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void goToRightRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mapPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                thumbnailBox.Visible = true;
                
                int x = (e.X / 16);
                int y = (e.Y / 16);
                int roomId = x + (y * 16);
                if (roomId > 295)
                {
                    return;
                }
                previewRoom = DungeonsData.all_rooms[roomId];
                previewRoom.reloadGfx();
                GFX.loadedPalettes = GFX.LoadDungeonPalette(previewRoom.Palette);
                DrawRoom();
                thumbnailBox.Refresh();
                if (activeScene.room != null)
                {
                    GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
                    activeScene.room.reloadGfx();
                    activeScene.DrawRoom();
                }

            }
        }

        public unsafe void ClearBgGfx()
        {
            byte* bg1data = (byte*)GFX.roomBg1Ptr.ToPointer();
            byte* bg2data = (byte*)GFX.roomBg2Ptr.ToPointer();
            for (int i = 0; i < 512 * 512; i++)
            {
                bg1data[i] = 0;
                bg2data[i] = 0;
            }
        }

        public unsafe void DrawRoom()
        {
            if (previewRoom == null)
            {
                return;
            }

            //Tile t = new Tile(0, false, false, 0, 0);
            //t.Draw(0, 0);
            ClearBgGfx(); //technically not required

            previewRoom.DrawFloor1();

            if (previewRoom.bg2 != Background2.Off)
            {
                SetPalettesTransparent();
                    previewRoom.DrawFloor2();
            }
            else
            {
                SetPalettesBlack();

            }


            previewRoom.reloadLayout();
            foreach (Room_Object o in previewRoom.tilesLayoutObjects)
            {
                o.Draw();

            }
            //draw object on bitmap

            foreach (Room_Object o in previewRoom.tilesObjects)
            {
                if (o.layer != 2)
                {
                    o.Draw();
                }
                if (o.options == ObjectOption.Door)
                {
                    o.Draw();
                }
            }
            foreach (Room_Object o in previewRoom.tilesObjects)
            {
                //Draw doors here since they'll all be put on bg3 anyways
                if (o.layer == 2)
                {
                    o.Draw();
                }
            }
                GFX.DrawBG1();
                GFX.DrawBG2();

        }

        public void SetPalettesTransparent()
        {
            int pindex = 0;
            ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
            for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
                {
                    palettes.Entries[pindex] = GFX.loadedPalettes[x, y];
                    pindex++;
                }
            }

            for (int y = 0; y < GFX.loadedSprPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedSprPalettes.GetLength(0); x++)
                {
                    if (pindex < 256)
                    {
                        palettes.Entries[pindex] = GFX.loadedSprPalettes[x, y];
                        pindex++;
                    }
                }
            }

            for (int i = 0; i < 16; i++)
            {
                palettes.Entries[i * 16] = Color.Transparent;
                palettes.Entries[(i * 16) + 8] = Color.Transparent;
            }
            GFX.roomBg1Bitmap.Palette = palettes;
            GFX.roomBg2Bitmap.Palette = palettes;
            GFX.roomBgLayoutBitmap.Palette = palettes;
        }

        public void SetPalettesBlack()
        {
            int pindex = 0;
            ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
            for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
                {
                    palettes.Entries[pindex] = GFX.loadedPalettes[x, y];
                    pindex++;
                }
            }

            for (int i = 0; i < 16; i++)
            {
                palettes.Entries[i * 16] = Color.Black;
                palettes.Entries[(i * 16) + 8] = Color.Black;
            }
            GFX.roomBg1Bitmap.Palette = palettes;
            GFX.roomBg2Bitmap.Palette = palettes;
            GFX.roomBgLayoutBitmap.Palette = palettes;
        }

        private void thumbnailBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.Bilinear;
            e.Graphics.Clear(Color.Black);
            if (previewRoom.bg2 != Background2.Translucent || previewRoom.bg2 != Background2.Transparent ||
                previewRoom.bg2 != Background2.OnTop || previewRoom.bg2 != Background2.Off)
            {
                e.Graphics.DrawImage(GFX.roomBg2Bitmap, new Rectangle(0,0,256,256),0,0,512,512,GraphicsUnit.Pixel);
            }


            //e.Graphics.DrawImage(GFX.roomBgLayoutBitmap,0,0);
            e.Graphics.DrawImage(GFX.roomBg1Bitmap, new Rectangle(0, 0, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel);

            if (previewRoom.bg2 == Background2.Translucent || previewRoom.bg2 == Background2.Transparent)
            {
                float[][] matrixItems ={
               new float[] {1f, 0, 0, 0, 0},
               new float[] {0, 1f, 0, 0, 0},
               new float[] {0, 0, 1f, 0, 0},
               new float[] {0, 0, 0, 0.5f, 0},
               new float[] {0, 0, 0, 0, 1}};
                ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

                // Create an ImageAttributes object and set its color matrix.
                ImageAttributes imageAtt = new ImageAttributes();
                imageAtt.SetColorMatrix(
                   colorMatrix,
                   ColorMatrixFlag.Default,
                   ColorAdjustType.Bitmap);
                //GFX.roomBg2Bitmap.MakeTransparent(Color.Black);
                e.Graphics.DrawImage(GFX.roomBg2Bitmap, new Rectangle(0, 0, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
            }
            else if (previewRoom.bg2 == Background2.OnTop)
            {
                e.Graphics.DrawImage(GFX.roomBg2Bitmap, new Rectangle(0, 0, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel);
            }

            activeScene.drawText(e.Graphics, 0, 0,"ROOM : " + previewRoom.index.ToString());

        }

        private void mapPicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            thumbnailBox.Visible = false;
        }
        int lastRoomID = -1; 
        private void mapPicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (maphoverCheckbox.Checked)
            {
                thumbnailBox.Visible = true;

                int x = (e.X / 16);
                int y = (e.Y / 16);
                int roomId = x + (y * 16);
                if (roomId >= 296)
                {
                    thumbnailBox.Visible = false;
                    return;
                }

                if (lastRoomID != roomId)
                {
                    previewRoom = DungeonsData.all_rooms[roomId];
                    previewRoom.reloadGfx();
                    GFX.loadedPalettes = GFX.LoadDungeonPalette(previewRoom.Palette);
                    DrawRoom();
                    thumbnailBox.Refresh();
                    if (activeScene.room != null)
                    {
                        GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
                        activeScene.room.reloadGfx();
                        activeScene.DrawRoom();
                    }
                }

                lastRoomID = roomId;
            }


        }

        private void mapPicturebox_MouseLeave(object sender, EventArgs e)
        {
            thumbnailBox.Visible = false;
        }

        private void openRightRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeScene.room != null)
            {
                int id = activeScene.room.index + 1;
                if (id < 296)
                {
                    addRoomTab((short)id);
                }
                else
                {
                    addRoomTab(0);
                }
            }
        }

        private void openLeftRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeScene.room != null)
            {
                int id = activeScene.room.index - 1;
                if (id >= 0)
                {
                    addRoomTab((short)id);
                }
                else
                {
                    addRoomTab(295);
                }
            }
        }

        private void openUpRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeScene.room != null)
            {
                int id = (activeScene.room.index - 16);
                if (id >= 0)
                {
                    addRoomTab((short)id);
                }
                else
                {
                    if (304 + id > 295)
                    {
                        addRoomTab((short)(295));

                    }
                    else
                    {
                        addRoomTab((short)(304 + id));
                    }
                }
            }
        }

        private void openDownRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeScene.room != null)
            {
                int id = activeScene.room.index + 16;
                if (id < 296)
                {
                    addRoomTab((short)id);
                }
                else
                {
                    if (id > 304)
                    {
                        addRoomTab((short)(id - 304));
                    }
                    else
                    {
                        addRoomTab((short)(id - 288));
                    }
                }
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            activeScene.Undo();
        }

        private  void redoButton_Click(object sender, EventArgs e)
        {
            activeScene.Redo();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.Redo();
        }

        private void DungeonMain_LocationChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void editorsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editorsTabControl.SelectedTab.Name == "textPage")
            {
                textEditor.BringToFront();
                textEditor.Visible = true;
                
            }
            else
            {
                textEditor.Visible = false;
            }
            if (editorsTabControl.SelectedTab.Name == "dungeonPage")
            {
                toolStrip1.Visible = true;
                panel1.Visible = true;
                toolboxPanel.Visible = true;
                customPanel3.Visible = true;
                headerGroupbox.Visible = true;
                tabControl2.Visible = true;

            }
            else
            {
                toolStrip1.Visible = false;
                panel1.Visible = false;
                toolboxPanel.Visible = false;
                customPanel3.Visible = false;
                headerGroupbox.Visible = false;
                tabControl2.Visible = false;
            }
            if (editorsTabControl.SelectedTab.Name == "objDesignerPage")
            {
                objDesigner.BringToFront();
                objDesigner.Visible = true;

            }
            else
            {
                objDesigner.Visible = false;
            }
            if (editorsTabControl.SelectedTab.Name == "overworldPage")
            {
                overworldEditor.BringToFront();
                overworldEditor.Visible = true;
            }
            else
            {
                overworldEditor.Visible = false;
            }
        }

        private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSettings st = new SaveSettings();
            st.ShowDialog();
            
        }



        public enum Direction
        {
            gauche = 0x01, droit = 0x02, haut = 0x04, bas = 0x08
        };

    }

}
