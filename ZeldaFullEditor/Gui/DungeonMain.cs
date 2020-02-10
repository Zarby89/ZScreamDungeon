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

        public Room[] all_rooms = new Room[296];
        bool anychange = false;
        PaletteViewer paletteViewer;
        public List<Room> opened_rooms = new List<Room>();
        public SceneUW activeScene;
        string projectFilename = "";
        public Entrance[] entrances = new Entrance[0x85];
        Entrance[] starting_entrances = new Entrance[0x07];
        bool saved_changed = false;
        public TreeNode lastNode = null;
        RoomLayout layoutForm;
        List<short> selectedMapPng = new List<short>();
        public ChestPicker chestPicker = new ChestPicker();
        public byte[] door_index = new byte[] { 0x00, 0x02, 0x40, 0x1C, 0x26, 0x0C, 0x44, 0x18, 0x36, 0x38, 0x1E, 0x2E, 0x28, 0x46, 0x0E, 0x0A, 0x30, 0x12, 0x16, 0x32,0x20,0x14 };

        public bool settingEntrance = false;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            layoutForm = new RoomLayout(this);
            initialize_properties();
            GFX.initGfx();
            ROMStructure.loadDefaultProject();
            mapPicturebox.Image = new Bitmap(256, 304);
            //mapPicturebox.Location = new Point(0, 26);

            roomProperty_floor1.MouseWheel += RoomProperty_MouseWheel;
            roomProperty_floor2.MouseWheel += RoomProperty_MouseWheel;
            roomProperty_spriteset.MouseWheel += RoomProperty_MouseWheel;
            roomProperty_blockset.MouseWheel += RoomProperty_MouseWheel;
            roomProperty_palette.MouseWheel += RoomProperty_MouseWheel;
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
            //Palettes.SavePalettesToROM(ROM.DATA);

           /* Console.WriteLine("ROMDATA[" + (Constants.overworldMapPalette + 2).ToString("X6") + "]" + " : " + ROM.DATA[Constants.overworldMapPalette + 2]);
            AsarCLR.Asar.init();
            AsarCLR.Asar.patch("spritesmove.asm", ref ROM.DATA);*/


            /*
            foreach(AsarCLR.Asarerror error in AsarCLR.Asar.geterrors())
            {
                Console.WriteLine(error.Fullerrdata.ToString());
            }
            */
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

        //TODO: Redo the map data add border between EG Maps


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
            //Randomize_Dungeons_Palettes();
            //Randomize_Overworld_Palettes();
            LoadPalettes();

            activeScene = new SceneUW(this);
            activeScene.Location = new Point(0, 0);
            activeScene.Size = new Size(512, 512);

            initProject();
            projectFilename = filename;
            this.Text = "ZScream Magic - " + filename;

        }

        public void LoadPalettes()
        {
            Palettes.CreateAllPalettes(ROM.DATA);
            /*//Dungeons Palettes
            for (int i = 0; i < 20; i++)
            {
                TreeNode tn = new TreeNode("Dungeon Pal - " + i.ToString());
                tn.Tag = Palettes.dungeonsMain_Palettes[i];
                palettesTreeview.Nodes["allPalettes"].Nodes[0].Nodes.Add(tn);
            }
            //Sword Palettes
            for (int i = 0; i < 4; i++)
            {
                TreeNode tn = new TreeNode("Sword - " + i.ToString());
                tn.Tag = Palettes.swords_Palettes[i];
                palettesTreeview.Nodes["allPalettes"].Nodes[1].Nodes.Add(tn);
            }
            for (int i = 0; i < 3; i++)
            {
                TreeNode tn = new TreeNode("Shield - " + i.ToString());
                tn.Tag = Palettes.shields_Palettes[i];
                palettesTreeview.Nodes["allPalettes"].Nodes[2].Nodes.Add(tn);
            }

            for (int i = 0; i < 3; i++)
            {
                TreeNode tn = new TreeNode("Armor - " + i.ToString());
                tn.Tag = Palettes.armors_Palettes[i];
                palettesTreeview.Nodes["allPalettes"].Nodes[3].Nodes.Add(tn);
            }

            for (int i = 0; i < 2; i++)
            {
                TreeNode tn = new TreeNode("Global Sprites - " + i.ToString());
                tn.Tag = Palettes.globalSprite_Palettes[i];
                palettesTreeview.Nodes["allPalettes"].Nodes[4].Nodes.Add(tn);
            }

            for (int i = 0; i < 12; i++)
            {
                TreeNode tn = new TreeNode("Sprite Aux1 - " + i.ToString());
                tn.Tag = Palettes.spritesAux1_Palettes[i];
                palettesTreeview.Nodes["allPalettes"].Nodes[5].Nodes.Add(tn);
            }
            for (int i = 0; i < 11; i++)
            {
                TreeNode tn = new TreeNode("Sprite Aux2 - " + i.ToString());
                tn.Tag = Palettes.spritesAux2_Palettes[i];
                palettesTreeview.Nodes["allPalettes"].Nodes[5].Nodes.Add(tn);
            }
            for (int i = 0; i < 24; i++)
            {
                TreeNode tn = new TreeNode("Sprite Aux3 - " + i.ToString());
                tn.Tag = Palettes.spritesAux3_Palettes[i];
                palettesTreeview.Nodes["allPalettes"].Nodes[5].Nodes.Add(tn);
            }

            for (int i = 0; i < 6; i++)
            {
                TreeNode tn = new TreeNode("Overworld Main - " + i.ToString());
                tn.Tag = Palettes.overworld_MainPalettes[i];
                palettesTreeview.Nodes["allPalettes"].Nodes[6].Nodes.Add(tn);
            }

            for (int i = 0; i < 20; i++)
            {
                TreeNode tn = new TreeNode("Overworld Aux - " + i.ToString());
                tn.Tag = Palettes.overworld_AuxPalettes[i];
                palettesTreeview.Nodes["allPalettes"].Nodes[7].Nodes.Add(tn);
            }

            for (int i = 0; i < 14; i++)
            {
                TreeNode tn = new TreeNode("Overworld Animated - " + i.ToString());
                tn.Tag = Palettes.overworld_AnimatedPalettes[i];
                palettesTreeview.Nodes["allPalettes"].Nodes[8].Nodes.Add(tn);
            }
            //TODO : Add Missing Palettes here

            for (int i = 0; i < 2; i++)
            {
                TreeNode tn = new TreeNode("Hud Pal - " + i.ToString());
                tn.Tag = Palettes.HudPalettes[i];
                palettesTreeview.Nodes["allPalettes"].Nodes[11].Nodes.Add(tn);
            }
            */

        }


        public void initRoomsMap()
        {
            /*using (Graphics g = Graphics.FromImage(mapPicturebox.Image))
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
            }*/
        }

        public void loadRoomList(int roomId)
        {

        }

        public void Randomize_Dungeons_Palettes()
        {
            for (int i = 0; i < 20; i++)
            {
                randomize_wall(i);
                randomize_floors(i);
            }
        }

        public void randomize_wall(int dungeon, int brigthness = 60)
        {

            Color wall_color = getColorBrigthness();

            for (int i = 0; i < 5; i++)
            {
                //166
                byte shadex = (byte)(10 - (i * 2));
                setColor((0x0DD734 + (0xB4 * dungeon)) + (i * 2), wall_color, shadex);
                setColor((0x0DD770 + (0xB4 * dungeon)) + (i * 2), wall_color, shadex);
                setColor((0x0DD744 + (0xB4 * dungeon)) + (i * 2), wall_color, shadex);

                if (dungeon == 0)
                {
                    setColor((0x0DD7CA + (0xB4 * dungeon)) + (i * 2), wall_color, shadex);
                }
            }

            if (dungeon == 2)
            {
                setColor((0x0DD74E + (0xB4 * dungeon)), wall_color, 3);
                setColor((0x0DD74E + 2 + (0xB4 * dungeon)), wall_color, 5);
                setColor((0x0DD73E + (0xB4 * dungeon)), wall_color, 3);
                setColor((0x0DD73E + 2 + (0xB4 * dungeon)), wall_color, 5);

            }

            //Ceiling
            setColor(0x0DD7E4 + (0xB4 * dungeon), wall_color, (byte)(4)); //outer wall darker
            setColor(0x0DD7E6 + (0xB4 * dungeon), wall_color, (byte)(2)); //outter wall brighter

            //pits walls
            setColor(0x0DD7DA + (0xB4 * dungeon), wall_color, (byte)(10));
            setColor(0x0DD7DC + (0xB4 * dungeon), wall_color, (byte)(8));


            Color pot_color = getColorBrigthness();
            //Pots
            setColor(0x0DD75A + (0xB4 * dungeon), pot_color, 7);
            setColor(0x0DD75C + (0xB4 * dungeon), pot_color, 1);
            setColor(0x0DD75E + (0xB4 * dungeon), pot_color, 3);

            //Wall Contour?
            //f,c,m
            setColor(0x0DD76A + (0xB4 * dungeon), wall_color, 7);
            setColor(0x0DD76C + (0xB4 * dungeon), wall_color, 2);
            setColor(0x0DD76E + (0xB4 * dungeon), wall_color, 4);


            Color chest_color = getColorBrigthness();
            setColor(0x0DD7AE + (0xB4 * dungeon), chest_color, 2);
            setColor(0x0DD7B0 + (0xB4 * dungeon), chest_color, 0);

        }
        Random rand = new Random();
        public Color getColorBrigthness()
        {
            int brigthness = 60;
            int r = brigthness + rand.Next(240 - brigthness);
            int g = brigthness + rand.Next(240 - brigthness);
            int b = brigthness + rand.Next(240 - brigthness);

            return Color.FromArgb(r, g, b);
        }

        public void randomize_floors(int dungeon, int brigthness = 60)
        {

            Color floor_color1 = getColorBrigthness();
            Color floor_color2 = getColorBrigthness();
            Color floor_color3 = getColorBrigthness();

            for (int i = 0; i < 3; i++)
            {
                byte shadex = (byte)(6 - (i * 2));
                setColor(0x0DD764 + (0xB4 * dungeon) + (i * 2), floor_color1, shadex);
                setColor(0x0DD782 + (0xB4 * dungeon) + (i * 2), floor_color1, (byte)(shadex + 3));

                setColor(0x0DD7A0 + (0xB4 * dungeon) + (i * 2), floor_color2, shadex);
                setColor(0x0DD7BE + (0xB4 * dungeon) + (i * 2), floor_color2, (byte)(shadex + 3));
            }

            setColor(0x0DD7E2 + (0xB4 * dungeon), floor_color3, 3);
            setColor(0x0DD796 + (0xB4 * dungeon), floor_color3, 4);
        }

        public void setColor(int address, Color col, byte shade)
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


            short s = (short)(((b) << 10) | ((g) << 5) | ((r) << 0));

            ROM.DATA[address] = (byte)(s & 0x00FF);
            ROM.DATA[address + 1] = (byte)((s >> 8) & 0x00FF);
        }


        public void Randomize_Overworld_Palettes()
        {
            Color grass = Color.FromArgb(60 + (rand.Next(155)), 60 + rand.Next(155), 60 + rand.Next(155));
            Color grass2 = Color.FromArgb(60 + (rand.Next(155)), 60 + rand.Next(155), 60 + rand.Next(155));
            Color grass3 = Color.FromArgb(60 + (rand.Next(155)), 60 + rand.Next(155), 60 + rand.Next(155));
            Color dirt = Color.FromArgb(60 + rand.Next(155), 60 + rand.Next(155), 60 + rand.Next(155));
            Color dirt2 = Color.FromArgb(60 + rand.Next(155), 60 + rand.Next(155), 60 + rand.Next(155));
            //Color grass = Color.FromArgb(230, 230, 230);
            //Color dirt = Color.FromArgb(140,120,64);

            // TODO: unused?
            Color wall = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));

            // TODO: unused?
            Color roof = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));


            Color btreetrunk = Color.FromArgb(172, 144, 96);

            // TODO: unused?
            Color treetrunk = Color.FromArgb(btreetrunk.R - 40 + rand.Next(80), btreetrunk.G - 20 + rand.Next(30), btreetrunk.B - 30 + rand.Next(60));


            Color treeleaf = Color.FromArgb(grass.R - 20 + rand.Next(30), grass.G - 20 + rand.Next(30), grass.B - 20 + rand.Next(30));

            // TODO: unused?
            Color bridge = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));

            //Hardcoded Grass (hobo an special area?)
            setColor(0x67FB4, grass, 0);
            setColor(0x67F94, grass, 0);
            setColor(0x67FC6, grass, 0);
            setColor(0x67FE6, grass, 0);

            setColor(0x05FEA9, grass, 0);//hardcoded grass palette LW

            setColor(0x0DD4AC, grass, 2); //desert shadow

            setColor(0x0DE6DE, grass2, 2);
            setColor(0x0DE75C, grass2, 2);
            setColor(0x0DE786, grass2, 2);
            setColor(0x0DE794, grass2, 2);
            setColor(0x0DE99A, grass2, 2);

            setColor(0x0DE6E0, grass2, 1);
            setColor(0x0DE6E2, grass2, 0);

            setColor(0x0DD4AE, grass2, 1);
            setColor(0x0DE6E0, grass2, 1);
            setColor(0x0DE9FA, grass2, 1);
            setColor(0x0DEA0E, grass2, 1);

            setColor(0x0DE9FE, grass2, 0);

            setColor(0x0DD3D2, grass2, 2);
            setColor(0x0DE88C, grass2, 2);
            setColor(0x0DE8A8, grass2, 2);
            setColor(0x0DE9F8, grass2, 2);
            setColor(0x0DEA4E, grass2, 2);
            setColor(0x0DEAF6, grass2, 2);
            setColor(0x0DEB2E, grass2, 2);
            setColor(0x0DEB4A, grass2, 2);

            int i = 0;
            setColor(0x0DE892 + (i * 70), grass, 1);
            setColor(0x0DE886 + (i * 70), grass, 0);

            setColor(0x0DE6D0 + (i * 70), grass, 1);//grass shade
            setColor(0x0DE6D2 + (i * 70), grass, 0); //grass



            setColor(0x0DE6FA + (i * 70), grass, 3);
            setColor(0x0DE6FC + (i * 70), grass, 0);//grass shade2
            setColor(0x0DE6FE + (i * 70), grass, 0);//??

            setColor(0x0DE884 + (i * 70), grass, 4);//tree shadow


            setColor(0x0DE70A + (i * 70), grass, 0); //grass?
            setColor(0x0DE708 + (i * 70), grass, 2); //bush?

            setColor(0x0DE70C + (i * 70), grass, 1); //bush?

            setColor(0x0DE6D4 + (i * 70), dirt, 2);

            setColor(0x0DE6CA + (i * 70), dirt, 5);
            setColor(0x0DE6CC + (i * 70), dirt, 4);
            setColor(0x0DE6CE + (i * 70), dirt, 3);
            setColor(0x0DE6E2 + (i * 70), dirt, 2);

            setColor(0x0DE6D8 + (i * 70), dirt, 5);
            setColor(0x0DE6DA + (i * 70), dirt, 4);
            setColor(0x0DE6DC + (i * 70), dirt, 2);
            setColor(0x0DE6F0 + (i * 70), dirt, 2);

            setColor(0x0DE6E6 + (i * 70), dirt, 5);
            setColor(0x0DE6E8 + (i * 70), dirt, 4);
            setColor(0x0DE6EA + (i * 70), dirt, 2);
            setColor(0x0DE6EC + (i * 70), dirt, 4);
            setColor(0x0DE6EE + (i * 70), dirt, 2);
            setColor(0x0DE6F0 + (i * 70), dirt, 2);

            


            //lake borders
            setColor(0x0DE91E, grass, 0);
            setColor(0x0DE920, dirt, 2);
            setColor(0x0DE916, dirt, 3);


            setColor(0x0DE932, dirt, 2);
            setColor(0x0DE934, dirt, 3);
            setColor(0x0DE936, dirt, 4);
            setColor(0x0DE93C, dirt, 1);


            setColor(0x0DE938, grass, 2);
            setColor(0x0DE93A, grass, 0);




            setColor(0x0DE92C, grass, 0);
            setColor(0x0DE93A, grass, 0);
            setColor(0x0DE93C, dirt, 2);


            setColor(0x0DE91C, grass, 1);

            setColor(0x0DE92A, grass, 1);
            setColor(0x0DE938, grass, 1);//darker?

            //zora domain
            setColor(0x0DEA1C, grass, 0);
            setColor(0x0DEA2A, grass, 0);
            setColor(0x0DEA30, grass, 0);

            setColor(0x0DEA2E, dirt, 5);
            setColor(0X067FE1, grass, 3); //Zora Domain Shadow

            setColor(0xDE9F2, dirt, 3); //Desert edges

            setColor(0X0DE6D0, grass, 3); //Test2
            setColor(0x0DE884, grass, 3);
            setColor(0x0DE8AE, grass, 3);
            setColor(0x0DE8BE, grass, 3);
            setColor(0x0DE8E4, grass, 3);
            setColor(0x0DE938, grass, 3);
            setColor(0x0DE9C4, grass, 3);


            setColor(0x0DE6D0, grass, 4);//tree shadow

            setColor(0x0DE890, treeleaf, 1);
            setColor(0x0DE894, treeleaf, 0);

            Color water = Color.FromArgb(60 + rand.Next(155), 60 + rand.Next(155), 60 + rand.Next(155));
            setColor(0x0DE924, water, 3);//water dark
            setColor(0x0DE668, water, 3);//water dark
            setColor(0x0DE66A, water, 2);//water light
            setColor(0x0DE670, water, 1); // water light
            setColor(0x0DE918, water, 1);// water light
            setColor(0x0DE66C, water, 0); //water lighter
            setColor(0x0DE91A, water, 0); //water lighter
            setColor(0x0DE92E, water, 1);// water light

            setColor(0x0DEA1A, water, 1);//light
            setColor(0x0DEA16, water, 3);//dark
            setColor(0x0DEA10, water, 4);//darker


            setColor(0x0DE66E, dirt, 3); //ground dark

            setColor(0x0DE672, dirt, 2);  // ground light


            setColor(0x0DE932, dirt, 4);  //ground darker
            setColor(0x0DE934, dirt, 3);  //ground dark
            setColor(0x0DE936, dirt, 2);  // ground light
            setColor(0x0DE93C, dirt, 1);  // ground lighter

            setColor(0x0DE756, dirt2, 4);
            setColor(0x0DE764, dirt2, 4);
            setColor(0x0DE772, dirt2, 4);
            setColor(0x0DE994, dirt2, 4);
            setColor(0x0DE9A2, dirt2, 4);

            setColor(0x0DE758, dirt2, 3);
            setColor(0x0DE766, dirt2, 3);
            setColor(0x0DE774, dirt2, 3);
            setColor(0x0DE996, dirt2, 3);
            setColor(0x0DE9A4, dirt2, 3);


            setColor(0x0DE75A, dirt2, 2);
            setColor(0x0DE768, dirt2, 2);
            setColor(0x0DE776, dirt2, 2);
            setColor(0x0DE778, dirt2, 2);
            setColor(0x0DE998, dirt2, 2);
            setColor(0x0DE9A6, dirt2, 2);


            setColor(0x0DE9AC, dirt2, 1);
            setColor(0x0DE99E, dirt2, 1);
            setColor(0x0DE760, dirt2, 1);
            setColor(0x0DE77A, dirt2, 1);
            setColor(0x0DE77C, dirt2, 1);
            setColor(0x0DE798, dirt2, 1);
            setColor(0x0DE664, dirt2, 1);
            setColor(0x0DE980, dirt2, 1);



            setColor(0x0DE75C, grass3, 2);
            setColor(0x0DE786, grass3, 2);
            setColor(0x0DE794, grass3, 2);
            setColor(0x0DE99A, grass3, 2);

            setColor(0x0DE75E, grass3, 1);
            setColor(0x0DE788, grass3, 1);
            setColor(0x0DE796, grass3, 1);
            setColor(0x0DE99C, grass3, 1);


            Color clouds = Color.FromArgb(60 + rand.Next(155), 60 + rand.Next(155), 60 + rand.Next(155));
            setColor(0x0DE76A, clouds, 2);
            setColor(0x0DE9A8, clouds, 2);

            setColor(0x0DE76E, clouds, 0);
            setColor(0x0DE9AA, clouds, 0);
            //setColor(0x0DE8E8, clouds,0);
            setColor(0x0DE8DA, clouds, 0);
            setColor(0x0DE8D8, clouds, 0);
            setColor(0x0DE8D0, clouds, 0);

            setColor(0x0DE98C, clouds, 2);
            setColor(0x0DE990, clouds, 0);



            //DW
            Color dwdirt = Color.FromArgb(60 + rand.Next(155), 60 + rand.Next(155), 60 + rand.Next(155));
            Color dwgrass = Color.FromArgb(60 + (rand.Next(155)), 60 + rand.Next(155), 60 + rand.Next(155));
            Color dwwater = Color.FromArgb(60 + (rand.Next(155)), 60 + rand.Next(155), 60 + rand.Next(155));
            Color dwtree = Color.FromArgb(dwgrass.R - 20 + rand.Next(30), dwgrass.G - 20 + rand.Next(30), dwgrass.B - 20 + rand.Next(30));


            setColor(0x05FEB3, dwgrass, 1);//hardcoded grass color in dw


            setColor(0x0DEB34, dwtree, 4);
            setColor(0x0DEB30, dwtree, 3);
            setColor(0x0DEB32, dwtree, 1);

            //dwdirt - dark to light
            setColor(0x0DE710, dwdirt, 5);
            setColor(0x0DE71E, dwdirt, 5);
            setColor(0x0DE72C, dwdirt, 5);
            setColor(0x0DEAD6, dwdirt, 5);

            setColor(0x0DE712, dwdirt, 4);
            setColor(0x0DE720, dwdirt, 4);
            setColor(0x0DE72E, dwdirt, 4);
            setColor(0x0DE660, dwdirt, 4);
            setColor(0x0DEAD8, dwdirt, 4);

            setColor(0x0DEADA, dwdirt, 3);
            setColor(0x0DE714, dwdirt, 3);
            setColor(0x0DE722, dwdirt, 3);
            setColor(0x0DE730, dwdirt, 3);
            setColor(0x0DE732, dwdirt, 3);

            setColor(0x0DE734, dwdirt, 2);
            setColor(0x0DE736, dwdirt, 2);
            setColor(0x0DE728, dwdirt, 2);
            setColor(0x0DE71A, dwdirt, 2);
            setColor(0x0DE664, dwdirt, 2);
            setColor(0x0DEAE0, dwdirt, 2);


            //grass
            setColor(0x0DE716, dwgrass, 3);
            setColor(0x0DE740, dwgrass, 3);
            setColor(0x0DE74E, dwgrass, 3);
            setColor(0x0DEAC0, dwgrass, 3);
            setColor(0x0DEACE, dwgrass, 3);
            setColor(0x0DEADC, dwgrass, 3);
            setColor(0x0DEB24, dwgrass, 3);

            setColor(0x0DE752, dwgrass, 2);

            setColor(0x0DE718, dwgrass, 1);
            setColor(0x0DE742, dwgrass, 1);
            setColor(0x0DE750, dwgrass, 1);
            setColor(0x0DEB26, dwgrass, 1);
            setColor(0x0DEAC2, dwgrass, 1);
            setColor(0x0DEAD0, dwgrass, 1);
            setColor(0x0DEADE, dwgrass, 1);



            //water

            setColor(0x0DE65A, dwwater, 5); //very dark water

            setColor(0x0DE65C, dwwater, 3); //main water color
            setColor(0x0DEAC8, dwwater, 3); //main water color
            setColor(0x0DEAD2, dwwater, 2); //main water color
            setColor(0x0DEABC, dwwater, 2);//light
            setColor(0x0DE662, dwwater, 2); //light
            setColor(0x0DE65E, dwwater, 1); //lighter
            setColor(0x0DEABE, dwwater, 1);//lighter
            setColor(0x0DEA98, dwwater, 2);//light

            setColor(0xDE86C + 0x232, dwwater, 2); //main water color
            setColor(0xDE86C + 0x240, dwwater, 3); //main water color
            setColor(0xDE86C + 0x242, dwwater, 3); //main water color
            setColor(0xDE86C + 0x24A, dwwater, 2); //main water color

            //Death Mountain


            //dw dm
            //dirt
            Color dwdmdirt = Color.FromArgb(60 + rand.Next(155), 60 + rand.Next(155), 60 + rand.Next(155));
            Color dwdmgrass = Color.FromArgb(60 + (rand.Next(155)), 60 + rand.Next(155), 60 + rand.Next(155));


            //Flashes on DM
            setColor(0x0DEA1A, dwdmgrass, 1);
            
            setColor(0x0DEA16, dwdmgrass, 1);
            

            setColor(0x067FE1, dwdmgrass, 1);
            
            setColor(0x067F94, dwdmgrass, 1);
            
            setColor(0x067FB4, dwdmgrass, 1);
            
            setColor(0x067FC6, dwdmgrass, 1);
            
            setColor(0x067FE6, dwdmgrass, 1);

            setColor(0x0DD4A0, dwdmgrass, 1);
            
            setColor(0x0DE8E6, dwdmgrass, 1); ////grass


            setColor(0x0DEA1C, dwdmgrass, 1);////grass



            setColor(0x0DE79A, dwdmdirt, 6); //super dark (6)
            setColor(0x0DE7A8, dwdmdirt, 6);
            setColor(0x0DE7B6, dwdmdirt, 6);
            setColor(0x0DEB60, dwdmdirt, 6);
            setColor(0x0DEB6E, dwdmdirt, 6);
            setColor(0x0DE93E, dwdmdirt, 6);
            setColor(0x0DE94C, dwdmdirt, 6);
            setColor(0x0DEBA6, dwdmdirt, 6);

            setColor(0x0DE79C, dwdmdirt, 4); //dark (4)
            setColor(0x0DE7AA, dwdmdirt, 4);
            setColor(0x0DE7B8, dwdmdirt, 4);
            setColor(0x0DE7BE, dwdmdirt, 4);
            setColor(0x0DE7CC, dwdmdirt, 4);
            setColor(0x0DE7DA, dwdmdirt, 4);
            setColor(0x0DEB70, dwdmdirt, 4);
            setColor(0x0DEBA8, dwdmdirt, 4);
            setColor(0x0DEB72, dwdmdirt, 3);
            setColor(0x0DEB74, dwdmdirt, 3);
            //light (3)
            setColor(0x0DE79E, dwdmdirt, 3);
            setColor(0x0DE7AC, dwdmdirt, 3);
            setColor(0x0DEB6A, dwdmdirt, 3);
            setColor(0x0DE948, dwdmdirt, 3);
            setColor(0x0DE956, dwdmdirt, 3);
            setColor(0x0DE964, dwdmdirt, 3);
            setColor(0x0DEBAA, dwdmdirt, 3);
            setColor(0x0DE7A0, dwdmdirt, 3);
            setColor(0x0DE7BC, dwdmgrass, 3);

            //lighter (2)
            setColor(0x0DEBAC, dwdmdirt, 2);

            setColor(0x0DE7AE, dwdmdirt, 2);
            setColor(0x0DE7C2, dwdmdirt, 2);
            setColor(0x0DE7A6, dwdmdirt, 2);
            setColor(0x0DEB7A, dwdmdirt, 2);
            setColor(0x0DEB6C, dwdmdirt, 2);
            setColor(0x0DE7C0, dwdmdirt, 2);

            //grass
            setColor(0x0DE7A2, dwdmgrass, 3);
            setColor(0x0DE7BE, dwdmgrass, 3);
            setColor(0x0DE7CC, dwdmgrass, 3);
            setColor(0x0DE7DA, dwdmgrass, 3);
            setColor(0x0DEB6A, dwdmgrass, 3);
            setColor(0x0DE948, dwdmgrass, 3);
            setColor(0x0DE956, dwdmgrass, 3);
            setColor(0x0DE964, dwdmgrass, 3);


            setColor(0x0DE7CE, dwdmgrass, 1);
            setColor(0x0DE7A4, dwdmgrass, 1);
            setColor(0x0DEBA2, dwdmgrass, 1);
            setColor(0x0DEBB0, dwdmgrass, 1);

            Color dwdmclouds1 = Color.FromArgb(60 + rand.Next(155), 60 + rand.Next(155), 60 + rand.Next(155));
            Color dwdmclouds2 = Color.FromArgb(60 + rand.Next(155), 60 + rand.Next(155), 60 + rand.Next(155));
            //clouds 1
            setColor(0x0DE644, dwdmclouds1, 2); //dark
            setColor(0x0DEB84, dwdmclouds1, 2);

            setColor(0x0DE648, dwdmclouds1, 1); //light dark
            setColor(0x0DEB88, dwdmclouds1, 1);

            //clouds2
            setColor(0x0DEBAE, dwdmclouds2, 2); //dark
            setColor(0x0DE7B0, dwdmclouds2, 2);


            setColor(0x0DE7B4, dwdmclouds2, 0);//light dark
            setColor(0x0DEB78, dwdmclouds2, 0);
            setColor(0x0DEBB2, dwdmclouds2, 0);
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
            this.customPanel3.Controls.Add(activeScene);
            addRoomTab(260);
            tabControl2_SelectedIndexChanged(tabControl2.TabPages[0], new EventArgs());
            
            initRoomsList();
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
            initObjectsList();

            GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
            GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
            objectViewer1.updateSize();
            spritesView1.updateSize();
            activeScene.DrawRoom();
            activeScene.Refresh();

            undoButton.Enabled = true;
            redoButton.Enabled = true;

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
            all_rooms[roomId] = (Room)activeScene.room.Clone();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadRoomList(260);
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
            MessageBox.Show("Sorry this section do not exist yet :)\n" +
                "you can however find shortcuts not mentionned\n" +
                "- Mouse Wheel is used to resize objects for now\n" +
                "- Mouse Wheel Button is used to close rooms tabs");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.mouse_down = false;
            activeScene.deleteSelected();
            
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.mouse_down = false;
            activeScene.selectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.mouse_down = false;
            activeScene.cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.paste();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.mouse_down = false;
            activeScene.copy();
        }

        private void palettePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseDown(e))
            {
                GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
                GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
                activeScene.DrawRoom();
                activeScene.Refresh();
            }
        }

        private void palettePicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            if (paletteViewer.mouseUp(e))
            {
                GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.Palette);
                GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.Palette);
                activeScene.DrawRoom();
                activeScene.Refresh();
            }
        }

        private void palettePicturebox_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void showBG1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.showLayer1 = showBG1ToolStripMenuItem.Checked;
            activeScene.DrawRoom();
            activeScene.Refresh();
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
                    activeScene.room.reloadGfx(entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
                }
                else
                {
                    activeScene.room.reloadGfx();
                }
                
            }
        }
        //Bring to front -_-
        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                activeScene.need_refresh = true;
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
                activeScene.need_refresh = true;
            }
        }

        private void changeObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete the selected object and add the new one
            activeScene.mouse_down = false;
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

        }

        private void roomListView_ItemDrag(object sender, ItemDragEventArgs e)
        {

        }

        private void roomListView_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void roomListView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

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

        public void entrancetreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (projectFilename == "")
            {
                return;
            }
            propertiesChangedFromForm = true;
            Entrance en = selectedEntrance;
            if (e != null)
            {
                if (e.Node.Tag != null)
                {
                    en = entrances[(int)e.Node.Tag];
                    if (e.Node.Parent != null)
                    {
                        if (e.Node.Parent.Name == "StartingEntranceNode")
                        {
                            en = starting_entrances[(int)e.Node.Tag];
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
                Room r = (Room)all_rooms[roomId].Clone();
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
                    activeScene.room.reloadGfx(entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
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
            gfxPointer = Utils.SnesToPc(gfxPointer);
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
            Buildtileset();
            gfxPicturebox.Refresh();
            propertiesChangedFromForm = false;
        }

        private void gfxsinglechanged(object sender, EventArgs e)
        {
            if (propertiesChangedFromForm == false)
            {
                int gfxPointer = (ROM.DATA[Constants.gfx_groups_pointer + 1] << 8) + ROM.DATA[Constants.gfx_groups_pointer];
                gfxPointer = Utils.SnesToPc(gfxPointer);
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
            loadRoomList(296);
        }

        private void deselectedAllMapForExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedMapPng.Clear();
            loadRoomList(296);
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {

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
                    activeScene.room.reloadGfx(entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
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
                    activeScene.room.reloadGfx(entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
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
                        
                        break;
                    }
                }
            }
            loadRoomList(0);
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.TabPages.Count > 0)
            {
                activeScene.room = (tabControl2.TabPages[tabControl2.SelectedIndex].Tag as Room);
                activeScene.updateRoomInfos(this);
                if (!visibleEntranceGFX)
                {
                    activeScene.room.reloadGfx(entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
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
                Sprite s = new Sprite(activeScene.room, (byte)i, 0, 0, 0, 0, 0);
                s.preview = true;
                listofspritesobjects.Add(s);
            }
            for (int i = 1; i < 0x1B; i++)
            {
                Sprite s = new Sprite(activeScene.room, (byte)i, 0, 0, 7, 0, 0);
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
            /*foreach(Sprite spr in listofspritesobjects)
            {
                spritesView1.items.Add(spr);
            }*/


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
            //if (activeScene.mouse_down == false)
            //{
                activeScene.selectedDragObject = new dataObject(objectViewer1.selectedObject.id, objectViewer1.selectedObject.name);
           // }
        }

        private void tabControl2_SizeChanged(object sender, EventArgs e)
        {
            if (activeScene != null)
            {
                //activeScene.Location = new Point(tabControl2.Location.X, tabControl2.Location.Y + 24);
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

        private void label41_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void spritesView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeScene.selectedDragSprite = new dataObject(spritesView1.selectedObject.id, spritesView1.selectedObject.name, spritesView1.selectedObject.overlord);
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

                    ColorPalette cp = GFX.currentOWgfx16Bitmap.Palette;
                    for (int i = 0; i < 16; i++)
                    {
                        cp.Entries[i] = GFX.roomBg1Bitmap.Palette.Entries[i + (c * 16)];
                    }
                    GFX.currentOWgfx16Bitmap.Palette = cp;
                    GFX.previewgfx16Bitmap.Palette = cp;
            }
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

                e.Graphics.DrawImage(GFX.previewgfx16Bitmap, new Rectangle(0, 0, GFX.currentOWgfx16Bitmap.Width * 2, GFX.currentOWgfx16Bitmap.Height * 2), 0, 0, GFX.currentOWgfx16Bitmap.Width, GFX.currentOWgfx16Bitmap.Height, GraphicsUnit.Pixel);
            

        }

        public void Buildtileset()
        {


            byte[] staticgfx = new byte[16];
            for (int i = 0; i < 16; i++)
            {
                staticgfx[i] = 0;
            }
            staticgfx[8] = 115 + 0;
            staticgfx[9] = 115 + 1;
            staticgfx[10] = 115 + 6;
            staticgfx[11] = 115 + 7;
            if (gfxgroupCombobox.SelectedIndex == 2) //sprites
            {
                staticgfx[12] = (byte)(115 + ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 0]);
                staticgfx[13] = (byte)(115 + ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 1]);
                staticgfx[14] = (byte)(115 + ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 2]);
                staticgfx[15] = (byte)(115 + ROM.DATA[Constants.sprite_blockset_pointer + (((int)gfxgroupindexUpDown.Value) * 4) + 3]);
            }

            unsafe
            {
                //NEED TO BE EXECUTED AFTER THE TILESET ARE LOADED NOT BEFORE -_-
                byte* currentmapgfx8Data = (byte*)GFX.previewgfx16Ptr.ToPointer();//loaded gfx for the current map (empty at this point)
                byte* allgfxData = (byte*)GFX.allgfx16Ptr.ToPointer(); //all gfx of the game pack of 2048 bytes (4bpp)
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 2048; j++)
                    {
                        byte mapByte = allgfxData[j + (staticgfx[i] * 2048)];
                        switch (i)
                        {
                            case 0:
                            case 3:
                            case 4:
                            case 5:
                                mapByte += 0x88;
                                break;
                        }

                        currentmapgfx8Data[(i * 2048) + j] = mapByte; //Upload used gfx data
                    }
                }
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = ".pal";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sf.FileName, FileMode.Create, FileAccess.Write);
                ColorPalette cp = GFX.roomBg1Bitmap.Palette;
                foreach (Color c in cp.Entries)
                {
                    fs.WriteByte(c.R);
                    fs.WriteByte(c.G);
                    fs.WriteByte(c.B);
                }
                fs.Close();
            }
            
        }

        private void exportOnJPROMToolStripMenuItem_Click(object sender, EventArgs e)
        {

    }

        private void spritesubtypeUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!activeScene.updating_info)
            {
                if (activeScene.room.selectedObject[0] is Sprite)
                {
                    (activeScene.room.selectedObject[0] as Sprite).subtype = (byte)spritesubtypeUpDown.Value;
                }
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
            if (projectFilename == "")
            {
                return;
            }
            int xd = 0;
            int yd = 0;
            e.Graphics.Clear(Color.Black);
            for (int i = 0; i < 296; i++)
            {
                if (all_rooms[i].tilesObjects.Count > 0)
                {

                    e.Graphics.FillRectangle(new SolidBrush(GFX.LoadDungeonPalette(all_rooms[i].palette)[4, 2]), new Rectangle(xd * 16, yd * 16, 16, 16));

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

        private void hideItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void generateChestsAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            List<string> chestsaddress = new List<string>();
            int cpos = (ROM.DATA[Constants.chests_data_pointer1 + 2] << 16) + (ROM.DATA[Constants.chests_data_pointer1 + 1] << 8) + (ROM.DATA[Constants.chests_data_pointer1]);
            cpos = Utils.SnesToPc(cpos);
            int clength = (ROM.DATA[Constants.chests_length_pointer + 1] << 8) + (ROM.DATA[Constants.chests_length_pointer]);
            //Console.WriteLine(clength);
            for (int index = 0; index < 296; index++)
            {
                for (int i = 0; i < clength; i++)
                {
                    if ((((ROM.DATA[cpos + (i * 3) + 1] << 8) + (ROM.DATA[cpos + (i * 3)])) & 0x7FFF) == index)
                    {
                        //there's a chest in that room !
                        bool big = false;
                        if ((((ROM.DATA[cpos + (i * 3) + 1] << 8) + (ROM.DATA[cpos + (i * 3)])) & 0x8000) == 0x8000) //????? 
                        {
                            big = true;
                        }

                        chestsaddress.Add(ROMStructure.roomsNames[index] + ", " + (cpos+(i*3)).ToString("X6"));
                        //chests_in_room.Add(new ChestData(ROM.DATA[cpos + (i * 3) + 2], big));

                        //
                    }
                }
            }

            File.WriteAllLines("ChestsAddresses.txt", chestsaddress.ToArray());
        }

        private void palettesTreeview_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            if (e.Node.Name == "currentRoom")
            {
                    paletteViewer.update(true,true);
            }

            if (e.Node.Tag != null)
            {

                if (e.Node.Parent.Name == "DungeonPalettes")
                {
                    paletteViewer.xSize = 15;
                }

                if (e.Node.Parent.Name == "SwordPalettes")
                {
                    paletteViewer.xSize = 3;
                }

                if (e.Node.Parent.Name == "ShieldPalettes")
                {
                    paletteViewer.xSize = 4;
                }

                if (e.Node.Parent.Name == "ArmorPalettes")
                {
                    paletteViewer.xSize = 15;
                }

                if (e.Node.Parent.Name == "StaticSpritePalette")
                {
                    paletteViewer.xSize = 15;
                }

                if (e.Node.Parent.Name == "DynamicSpritePalette")
                {
                    paletteViewer.xSize = 7;

                }

                if (e.Node.Parent.Name == "OverworldPalettes")
                {
                    paletteViewer.xSize = 7;
                }


                if (e.Node.Parent.Name == "OverworldAuxPalettes")
                {
                    paletteViewer.xSize = 7;
                }

                if (e.Node.Parent.Name == "OverworldAnimatedPalettes")
                {
                    paletteViewer.xSize = 7;
                }

                if (e.Node.Parent.Name == "HudPalettes")
                {
                    paletteViewer.xSize = 16;//15 or 16?

                }
                if (e.Node.Tag.GetType() == typeof(Color[]))
                {
                    paletteViewer.setColor(e.Node.Tag as Color[]);
                    paletteViewer.update();
                }
                //TODO:  Add missing palettes here
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            paletteViewer.resetColor();
        }

        private void globalOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void overworldButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void dungeonButton_Click(object sender, EventArgs e)
        {
            

                customPanel3.Visible = true;
                spritesView1.updateSize();
                spritesView1.Refresh();
                headerGroupbox.Visible = true;
                allbgsButton.Visible = true;
                bg1modeButton.Visible = true;
                bg2modeButton.Visible = true;
                bg3modeButton.Visible = true;
                spritemodeButton.Visible = true;
                blockmodeButton.Visible = true;
                torchmodeButton.Visible = true;
                doormodeButton.Visible = true;
                chestmodeButton.Visible = true;
                potmodeButton.Visible = true;
                warpmodeButton.Visible = true;
                toolStripButton1.Visible = true;
                toolStripSeparator3.Visible = true;
                saveLayoutButton.Visible = true;
                loadlayoutButton.Visible = true;
        }

        private void overworldButton_Click(object sender, EventArgs e)
        {

        }

        private void customPanel5_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void panel5_Scroll(object sender, ScrollEventArgs e)
        {

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
                foreach(Room r in all_rooms)
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

        private void tag1Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WIP :(");
        }

        private void tag2Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WIP :(");
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

        private void vramViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VramViewer vramViewer = new VramViewer();
            vramViewer.TopLevel = false;
            customPanel3.Controls.Add(vramViewer);
            vramViewer.Parent = customPanel3;
            vramViewer.BringToFront();
            vramViewer.Show();
        }

        private void selectedGroupbox_Enter(object sender, EventArgs e)
        {

        }

        private void button_holewarp_Click(object sender, EventArgs e)
        {

        }

        private void warpPreviewLabel_Click(object sender, EventArgs e)
        {

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
                en = entrances[(int)entrancetreeView.SelectedNode.Tag];
                if (entrancetreeView.SelectedNode.Parent != null)
                {
                    if (entrancetreeView.SelectedNode.Parent.Name == "StartingEntranceNode")
                    {
                        en = starting_entrances[(int)entrancetreeView.SelectedNode.Tag];
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

        private void mapPicturebox_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void entranceCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.Refresh();
        }

        private void entrancePositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene.Refresh();
        }
    }



    public class dataObject
    {
        public short id;
        public string Name { get; set; }
        public byte option = 0;
        public dataObject(short id, string name, byte option = 0)
        {
            this.Name = name;
            this.id = id;
            this.option = option;
        }


    }


}
