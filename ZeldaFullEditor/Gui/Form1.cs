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

    public partial class zscreamForm : Form
    {
        public zscreamForm()
        {
            InitializeComponent();
            
        }



        Room room;
        Room[] all_rooms = new Room[296];
        int lastRoom = 32;
        bool anychange = false;
        bool project_loaded = false;
        PaletteViewer paletteViewer;
        Scene scene;
        string version = "us";

        Charactertable table_char = new Charactertable(true);
        private void Form1_Load(object sender, EventArgs e)
        {
            ROMStructure.loadDefaultProject();
            scene = new Scene(this);
            scene.Enabled = false;
            splitContainer1.Panel2.Controls.Add(scene);
            //this.Controls.Add();
            scene.Location = new Point(0, 0);
            scene.Size = new Size(512, 512);
            actionsListbox.DisplayMember = "Name";
            palettePicturebox.Image = new Bitmap(256, 340);
            paletteViewer = new PaletteViewer(palettePicturebox);
            mapPicturebox.Image = new Bitmap(256, 304);
            layoutForm = new RoomLayout(this);

            /*#if DEBUG
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
                        version = checkFileSupport();
                        load_default_room();
            #endif*/
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save Functions
            //Expand ROM to 2MB
            if (scene.sceneChanged == true)
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
                MessageBox.Show("Failed to save, there is too many sprites", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveAllObjects())
            {
                MessageBox.Show("Failed to save, there is too many tiles objects", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveallPots())
            {
                MessageBox.Show("Failed to save, there is too many pot items", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveBlocks())
            {
                MessageBox.Show("Failed to save, there is too many pushable blocks", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveTorches())
            {
                MessageBox.Show("Failed to save, there is too many torches", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveAllPits())
            {
                MessageBox.Show("Failed to save, there is too many damage pits", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }
            if (save.saveTexts(messages, table_char))
            {
                MessageBox.Show("Failed to save, there is too many texts", "Bad Error", MessageBoxButtons.OK);
                ROM.DATA = (byte[])romBackup.Clone(); //restore previous rom data to prevent corrupting anything
                return;
            }

            saveInitialStuff();

            anychange = false;
            saved_changed = false;

            ROMStructure.saveProjectFile(version, projectFilename);
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //need to be replaced by open project
            OpenFileDialog projectFile = new OpenFileDialog();
            if (projectFile.ShowDialog() == DialogResult.OK)
            {
                LoadProject(projectFile.FileName);
            }

        }
        string projectFilename;
        public void LoadProject(string filename)
        {
            ROMStructure.loadProject(filename);
            version = "jp";
            Constants.Init_Jp(true);
            load_default_room();
            projectFilename = filename;
            this.Text = "ZScream Magic - " + filename;
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
                load_default_room();
            }
            else
            {
                MessageBox.Show("Failed to create a project from that rom","Error");
            }

            //Check the version of the rom, known version are "us","jp","vt", others are unknown or not allowed to load
            

        }


        public string checkFileSupport()
        {
            string v = "";
            string title = getHeaderTitle();
            if (title == "VTC")
            {
                Constants.Init_Jp(true); //VT
                v = "vt";
            }
            else if (title == "ZEL")
            {
                Constants.Init_Jp(); //JP
                v = "jp";
            }
            else if (title == "THE")
            {
                v = "us";
            }
            else
            {
                v = "error";
                ROM.DATA = null;
                MessageBox.Show("Sorry that ROM is not supported :(", "Error");
                load_default_room();
            }

            return v;
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
                roomListView.Nodes.Clear();
                for (int i = 0; i < 17; i++)
                {
                    TreeNode node = new TreeNode(ROMStructure.dungeonsNames[i]);
                    roomListView.Nodes.Add(node);
                }
                foreach (DataRoom r in ROMStructure.dungeonsRoomList)
                {
                    TreeNode subnode = new TreeNode("[" + r.id + "] " + r.name);
                    subnode.Tag = r.id;
                    roomListView.Nodes[r.dungeonId].Nodes.Add(subnode);
                }
                //roomListView.SelectedNode = roomListView.Nodes[260]; //why ?

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



        }
        TextPreview previewText;
        public void load_default_room()
        {
            tabControl1.Enabled = true;

            byte[] bpp3data = Compression.DecompressTiles(); //decompress almost all the gfx from the game
            GFX.gfxdata = Compression.bpp3tobpp4(bpp3data); //transform them into 4bpp

            for (int i = 0; i < 296; i++)
            {
                all_rooms[i] = (new Room(i)); // create all rooms
            }


            roomListView.Nodes.Clear();
            Room_Name room_names = new Room_Name();
            if (version == "jp")
            {
                if (Constants.Rando)
                {
                    readAllText();
                }
                messageidUpDown.Maximum = messageUpDown.Maximum;
            }
            loadRoomList(260);
            scene.Enabled = true;

            //roomListView.SelectedNode = roomListView.Nodes[260];//set start room on link's house

            paletteViewer.update();
            GFX.LoadHudPalettes();
            previewText = new TextPreview(table_char);

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
            //pictureBox2.Image = GFX.singletobmp();
            entranceListBox.Items.Clear();
            for (int i = 0; i < 0x84; i++)
            {
                entranceListBox.Items.Add("Entrance " + i.ToString("X2"));
            }
            for (int i = 0; i < 0x07; i++)
            {
                entranceListBox.Items.Add("Starting Entrance " + i.ToString("X2"));
            }
            entranceListBox.SelectedIndex = 0;
            loadInitialStuff();
            project_loaded = true;
            updateTimer.Enabled = true;
            //pictureBox1.Image = roomBitmap;

            scene.need_refresh = true;

        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (project_loaded == true)
            {
                undoredoButtonsEnables();
                scene.drawRoom();
                splitContainer1.Panel2.Enabled = true;
            }
        }

        public enum ObjectResize
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
            if (room != null)
            {
                scene.redoRooms.Clear();
                actionsListbox.Items.Clear();
                room.selectedObject.Clear();
            }
        }
        bool saved_changed = false;
        public TreeNode lastNode = null;
        public void change_room(int roomId)
        {
            if (radioButton1.Checked)
            {
                room = (Room)all_rooms[(short)roomListView.SelectedNode.Tag].Clone();
            }
            else
            {
                room = (Room)all_rooms[(short)roomId].Clone();
            }
            scene.room = room;
            scene.project_loaded = true;
            propertyGrid1.SelectedObject = room;
            scene.need_refresh = true;
            room.reloadGfx(false);
            paletteViewer.update();
            floor1UpDown.Value = room.floor1;
            floor2UpDown.Value = room.floor2;
            roomgfxUpDown.Value = room.blockset;
            paletteUpDown.Value = room.palette;
            spritesetUpDown.Value = room.spriteset;
            layoutUpDown.Value = room.layout;
            collisioncomboBox.SelectedIndex = room.collision;
            //tag1comboBox.SelectedIndex = room.tag1;
            //tag2comboBox.SelectedIndex = room.tag2;
            effectcomboBox.SelectedIndex = room.effect;
            if (room.light)
            {
                bg2comboBox.SelectedIndex = 8;
            }
            else
            {
                bg2comboBox.SelectedIndex = (byte)room.bg2;
            }
            if (version == "jp")
            {
                messageidUpDown.Value = room.messageid;
            }

            scene.initChestGfx();
            pithurtcheckbox.Checked = room.damagepit;
            scene.undoRooms.Clear();
            scene.redoRooms.Clear();
            pictureBox2.Image = GFX.singletobmp((int)numericUpDown1.Value);
            room_loaded = true;
        }

        private void loadInitialStuff()
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

            if (equipBootsCheckbox.Checked)
            {
                ROM.DATA[Constants.initial_equipement + 21] = 1;
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

        public void save_room(int roomId)
        {
            all_rooms[roomId] = room;
        }





        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        public void undoredoButtonsEnables()
        {
            if (scene.undoRooms.Count > 0)
            {
                undoButton.Enabled = true;
            }
            else
            {
                undoButton.Enabled = false;
            }
            if (scene.redoRooms.Count > 0)
            {
                redoButton.Enabled = true;
            }
            else
            {
                redoButton.Enabled = false;
            }
        }


        Room_Name room_names = new Room_Name();
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            loadRoomList(lastRoom);
            mapPicturebox.Refresh();
            scene.need_refresh = true;
            if (radioButton2.Checked)
            {
                mapPicturebox.Visible = true;
                roomListView.Visible = false;
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
        public void update_modes_buttons(object sender, EventArgs e)
        {
            for (int i = 6; i < 17; i++)
            {
                (toolStrip1.Items[i] as ToolStripButton).Checked = false;
            }
            selectedLayer = -1;
            (sender as ToolStripButton).Checked = true;
            room.selectedObject.Clear();
            scene.selectedMode = ObjectMode.Bgallmode;
            if (allbgsButton.Checked)
            {
                scene.selectedMode = ObjectMode.Bgallmode;
                selectedLayer = 3;
            }
            else if (bg1modeButton.Checked)
            {
                scene.selectedMode = ObjectMode.Bg1mode;
                selectedLayer = 0;
            }
            else if (bg2modeButton.Checked)
            {
                scene.selectedMode = ObjectMode.Bg2mode;
                selectedLayer = 1;
            }
            else if (bg3modeButton.Checked)
            {
                scene.selectedMode = ObjectMode.Bg3mode;
                selectedLayer = 2;
            }
            else if (spritemodeButton.Checked)
            {
                scene.selectedMode = ObjectMode.Spritemode;
            }
            else if (potmodeButton.Checked)
            {
                scene.selectedMode = ObjectMode.Itemmode;
            }
            else if (torchmodeButton.Checked)
            {
                scene.selectedMode = ObjectMode.Torchmode;
            }
            else if (blockmodeButton.Checked)
            {
                scene.selectedMode = ObjectMode.Blockmode;
            }
            else if (doormodeButton.Checked)
            {
                scene.selectedMode = ObjectMode.Doormode;
            }
            else if (warpmodeButton.Checked)
            {
                scene.selectedMode = ObjectMode.Warpmode;
            }
            else if (chestmodeButton.Checked)
            {
                scene.selectedMode = ObjectMode.Chestmode;
            }

            //room.update();
            scene.need_refresh = true;
            scene.drawRoom();
        }

        public Bitmap[] sprites_bitmap = new Bitmap[0xF3];
        public Bitmap[] chest_items_bitmap = new Bitmap[176];
        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        public PickObject objectSelector = new PickObject();


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.deleteSelected();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.Undo();
        }



        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.Redo();

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.selectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messagetextBox.Focused)
            {
                messagetextBox.Cut();
                return;
            }

            scene.cut();
        }



        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messagetextBox.Focused) //OH HAHA
            {
                messagetextBox.Paste();
                return;
            }
            scene.paste();


        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messagetextBox.Focused)
            {
                messagetextBox.Copy();
                return;
            }
            scene.copy();

        }
        bool room_loaded = false;
        private void floor1UpDown_ValueChanged(object sender, EventArgs e)
        {

        }


        private void palettePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseDown(e))
            {
                room.reloadGfx(true, entrance_blockset);
                scene.need_refresh = true;
            }
        }

        private void palettePicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseUp(e))
            {
                room.reloadGfx(true, entrance_blockset);
                scene.need_refresh = true;
            }
        }

        private void palettePicturebox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseDoubleclick(e, colorDialog1))
            {
                room.reloadGfx(true, entrance_blockset);
                scene.need_refresh = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paletteViewer.randomizePalette(room.palette);
            room.reloadGfx(true, entrance_blockset);
            scene.need_refresh = true;
        }







        private void showBG1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.showLayer1 = showBG1ToolStripMenuItem.Checked;
            scene.need_refresh = true;
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
            if ((byte)scene.selectedMode > 3)
            {
                bg1modeButton.Checked = true;
                update_modes_buttons(bg1modeButton,new EventArgs());
               // scene.selectedMode = ObjectMode.Bg1mode;
            }
            layoutForm.scene.room = (Room)room.Clone();
            room.selectedObject.Clear();
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
                    room.tilesObjects.Add(o);
                    room.selectedObject.Add(o);
                    
                }
                
                scene.dragx = 0;
                scene.dragy = 0;
                scene.mouse_down = true;
                scene.need_refresh = true;
                room.reloadGfx(false);
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
                scene.need_refresh = true;

            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            saveLayout(false);
        }

        private void textSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.showSpriteText = textSpriteToolStripMenuItem.Checked;
            scene.need_refresh = true;
        }

        private void mapPicturebox_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (e.X / 16);
            int y = (e.Y / 16);
            int roomId = x + (y * 16);
            if (roomId <= 296)
            {
                change_room(roomId);
                loadRoomList(roomId);
            }
        }

        private void entranceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            short roomId = (short)((ROM.DATA[(Constants.entrance_room + (entranceListBox.SelectedIndex * 2)) + 1] << 8) + ROM.DATA[Constants.entrance_room + (entranceListBox.SelectedIndex * 2)]);
            short yPosition = (short)(((ROM.DATA[(Constants.entrance_yposition + (entranceListBox.SelectedIndex * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.entrance_yposition + (entranceListBox.SelectedIndex * 2)]);
            short xPosition = (short)(((ROM.DATA[(Constants.entrance_xposition + (entranceListBox.SelectedIndex * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.entrance_xposition + (entranceListBox.SelectedIndex * 2)]);
            short xScroll = (short)(((ROM.DATA[(Constants.entrance_yscroll + (entranceListBox.SelectedIndex * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.entrance_yscroll + (entranceListBox.SelectedIndex * 2)]);
            short yScroll = (short)(((ROM.DATA[(Constants.entrance_xscroll + (entranceListBox.SelectedIndex * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.entrance_xscroll + (entranceListBox.SelectedIndex * 2)]);
            short yCamera = (short)(((ROM.DATA[(Constants.entrance_camerayposition + (entranceListBox.SelectedIndex * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.entrance_camerayposition + (entranceListBox.SelectedIndex * 2)]);
            short xCamera = (short)(((ROM.DATA[(Constants.entrance_cameraxposition + (entranceListBox.SelectedIndex * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.entrance_cameraxposition + (entranceListBox.SelectedIndex * 2)]);
            byte blockset = (byte)(ROM.DATA[(Constants.entrance_blockset + entranceListBox.SelectedIndex)]);
            byte music = (byte)(ROM.DATA[(Constants.entrance_music + entranceListBox.SelectedIndex)]);
            byte dungeonid = (byte)(ROM.DATA[(Constants.entrance_dungeon + entranceListBox.SelectedIndex)]);

            if (entranceListBox.SelectedIndex >= 0x84)
            {
                roomId = (short)((ROM.DATA[(Constants.startingentrance_room + ((entranceListBox.SelectedIndex - 0x84) * 2)) + 1] << 8) + ROM.DATA[Constants.startingentrance_room + ((entranceListBox.SelectedIndex - 0x84) * 2)]);
                yPosition = (short)(((ROM.DATA[(Constants.startingentrance_yposition + ((entranceListBox.SelectedIndex - 0x84) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_yposition + ((entranceListBox.SelectedIndex - 0x84) * 2)]);
                xPosition = (short)(((ROM.DATA[(Constants.startingentrance_xposition + ((entranceListBox.SelectedIndex - 0x84) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_xposition + ((entranceListBox.SelectedIndex - 0x84) * 2)]);
                xScroll = (short)(((ROM.DATA[(Constants.startingentrance_yscroll + ((entranceListBox.SelectedIndex - 0x84) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_yscroll + ((entranceListBox.SelectedIndex - 0x84) * 2)]);
                yScroll = (short)(((ROM.DATA[(Constants.startingentrance_xscroll + ((entranceListBox.SelectedIndex - 0x84) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_xscroll + ((entranceListBox.SelectedIndex - 0x84) * 2)]);
                yCamera = (short)(((ROM.DATA[(Constants.startingentrance_camerayposition + ((entranceListBox.SelectedIndex - 0x84) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_camerayposition + ((entranceListBox.SelectedIndex - 0x84) * 2)]);
                xCamera = (short)(((ROM.DATA[(Constants.startingentrance_cameraxposition + ((entranceListBox.SelectedIndex - 0x84) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_cameraxposition + ((entranceListBox.SelectedIndex - 0x84) * 2)]);
                blockset = (byte)(ROM.DATA[(Constants.startingentrance_blockset + entranceListBox.SelectedIndex - 0x84)]);
                music = (byte)(ROM.DATA[(Constants.startingentrance_music + entranceListBox.SelectedIndex - 0x84)]);
                dungeonid = (byte)(ROM.DATA[(Constants.startingentrance_dungeon + entranceListBox.SelectedIndex - 0x84)]);
            }

            entranceXUpDown.Value = xPosition;
            entranceYUpDown.Value = yPosition;
            entranceRoomUpDown.Value = roomId;
            entrancescrollxUpDown.Value = xScroll;
            entrancescrollyUpDown.Value = yScroll;
            entrancecameraxUpDown.Value = xCamera;
            entrancecamerayUpDown.Value = yCamera;
            entrancemusicUpDown.Value = music;
            entrancedungidUpDown.Value = dungeonid;
            entranceblocksetUpDown.Value = blockset;
            //entranceLabel.Text = "Room : " + roomId.ToString() + "\nX Position : " + xPosition.ToString() + "\nY Position : " + yPosition.ToString();
        }
        byte entrance_blockset = 0xFF;
        private void button3_Click(object sender, EventArgs e)
        {
            //byte blockset = (byte)(ROM.DATA[(Constants.entrance_blockset + entranceListBox.SelectedIndex)]);
            //entrance_blockset = blockset;
            if (entranceListBox.SelectedIndex >= 0x84)
            {
                change_room((short)((ROM.DATA[(Constants.startingentrance_room + ((entranceListBox.SelectedIndex - 0x84) * 2)) + 1] << 8) + ROM.DATA[Constants.startingentrance_room + ((entranceListBox.SelectedIndex - 0x84) * 2)]));
            }
            else
            {
                change_room((short)((ROM.DATA[(Constants.entrance_room + (entranceListBox.SelectedIndex * 2)) + 1] << 8) + ROM.DATA[Constants.entrance_room + (entranceListBox.SelectedIndex * 2)]));
            }
            //roomgfxUpDown.Value = blockset;

        }

        private void button4_Click(object sender, EventArgs e)//What is button4 ?
        {
            //Switch layer button
            //TODO : Replace that button by a real thing
            if (room.selectedObject.Count > 0)
            {
                scene.need_refresh = true;
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



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pithurtcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (room_loaded)
            {

            }
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

                    if (ROM.DATA[pos] == 0xFA) //NewLine
                    {
                        pos++;
                        messages[msgid] += "[NWL]\n";
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
            if (version == "jp")
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
            if (version == "jp")
            {
                tabControl1.SelectTab("texttabPage");
                messageUpDown.Value = room.messageid;
            }
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.insertNew();
        }

        private void bringToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.SendSelectedToBack();
        }

        private void textpreviewButton_Click(object sender, EventArgs e)
        {
            if (version == "jp")
            {
                previewText.text = messagetextBox.Text;
                previewText.ShowDialog();
            }

        }

        private void messagetextBox_TextChanged(object sender, EventArgs e)
        {
            if (version == "jp")
            {
                messages[(int)messageUpDown.Value] = messagetextBox.Text;
            }
        }

        private void sendToBg1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (room.selectedObject.Count > 0)
            {
                if (room.selectedObject[0] is Room_Object)
                {
                    foreach (Room_Object o in room.selectedObject)
                    {
                        o.layer = 0;
                    }
                }
                scene.need_refresh = true;
            }
        }

        private void sendToBg1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (room.selectedObject.Count > 0)
            {
                if (room.selectedObject[0] is Room_Object)
                {
                    foreach (Room_Object o in room.selectedObject)
                    {
                        o.layer = 1;
                    }
                }
                scene.need_refresh = true;
            }
        }

        private void sendToBg1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (room.selectedObject.Count > 0)
            {
                if (room.selectedObject[0] is Room_Object)
                {
                    foreach (Room_Object o in room.selectedObject)
                    {
                        o.layer = 2;
                    }
                }
                scene.need_refresh = true;
            }
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            pictureBox2.Image = GFX.singletobmp((int)numericUpDown1.Value);
        }

        private void changeObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete the selected object and add the new one
            scene.changeObject();
        }

        private void zscreamForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (anychange)
            {
                all_rooms[room.index] = room;
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

        private void entranceRoomUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (entranceListBox.SelectedIndex <= 0x83)
            {
                ROM.DATA[Constants.entrance_room + (entranceListBox.SelectedIndex * 2)] = (byte)((short)entranceRoomUpDown.Value & 0xFF);
                ROM.DATA[Constants.entrance_room + (entranceListBox.SelectedIndex * 2) + 1] = (byte)(((short)entranceRoomUpDown.Value >> 8) & 0xFF);
            }
            else
            {
                ROM.DATA[Constants.startingentrance_room + ((entranceListBox.SelectedIndex - 0x84) * 2)] = (byte)((short)entranceRoomUpDown.Value & 0xFF);
                ROM.DATA[Constants.startingentrance_room + ((entranceListBox.SelectedIndex - 0x84) * 2) + 1] = (byte)(((short)entranceRoomUpDown.Value >> 8) & 0xFF);
            }
        }

        private void entranceblocksetUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (entranceListBox.SelectedIndex <= 0x83)
            {
                ROM.DATA[Constants.entrance_blockset + (entranceListBox.SelectedIndex)] = (byte)((short)entranceblocksetUpDown.Value & 0xFF);
            }
            else
            {
                ROM.DATA[Constants.startingentrance_blockset + ((entranceListBox.SelectedIndex - 0x84))] = (byte)((short)entranceblocksetUpDown.Value & 0xFF);
            }

        }

        private void roomListView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void roomListView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            if (e.Node.Tag != null)
            {
                change_room(((short)e.Node.Tag));
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

        private void openProjectFileDialog_FileOk(object sender, CancelEventArgs e)
        {

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

                for(int i = 0;i<17;i++)
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
                for(int i = 0;i<17;i++)
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
            scene.need_refresh = true;
            room.reloadLayout();
            room.reloadGfx(false, entrance_blockset);
            scene.sceneChanged = true;
            anychange = true;


            if (room.damagepit == true)
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
                    room.damagepit = false;
                }
                else
                {
                    room.damagepit = true;
                }
            }
            else
            {

                room.damagepit = false;
            }

        }

        private void showBG2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.showLayer2 = showBG2ToolStripMenuItem.Checked;
            scene.need_refresh = true;
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
            if (scene.project_loaded)
            {
                scene.need_refresh = true;
                room_loaded = false;
                if (scene.sceneChanged)
                {
                    if (lastNode != roomListView.SelectedNode)
                    {
                        DialogResult dialogResult = MessageBox.Show("Room has changed. Do you want to keep changes?", "Keep Changes", MessageBoxButtons.YesNoCancel);
                        if (dialogResult == DialogResult.Yes)
                        {
                            clear_room();
                            save_room((short)roomListView.SelectedNode.Tag);
                            saved_changed = true;
                            scene.sceneChanged = false;
                        }
                        else if (dialogResult == DialogResult.Cancel)
                        { 
                            e.Cancel = true; //prevent list from going on the new room if we cancel
                        }
                        else //if we just press no to not save
                        {
                            clear_room();
                            scene.sceneChanged = false;
                        }
                    }
                }
                else //if there was no change we can change rooms
                {
                    clear_room();
                    saved_changed = true;
                    scene.sceneChanged = false;
                }
            }
        }

       

        private void propertyGrid1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void propertyGrid1_CausesValidationChanged(object sender, EventArgs e)
        {
   
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
