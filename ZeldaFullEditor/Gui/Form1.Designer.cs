namespace ZeldaFullEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Entrances");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Starting Entrances");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Main Dungeon Palette");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Sprite Palettes");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Current Room", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Dungeon Palettes");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Sword Palettes");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Shield Palettes");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Armor Palettes");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Static Sprite Palettes");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Dynamic Sprite Palette");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Overworld Main Palettes");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Overworld Aux Palettes");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Overworld Animated Palettes");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Overworld Map Palettes");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Dungeon Map Palettes");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Hud Palettes");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Crystal Palettes");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Triforce Palette");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("All Palettes", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportOnJPROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.moveFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bringToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllMapForExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectedAllMapForExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textChestItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textPotItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x256ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBG2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBG1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectedBGTransparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightSideToolboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideAllTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideChestItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openfileButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.debugtestButton = new System.Windows.Forms.ToolStripButton();
            this.runtestButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.allbgsButton = new System.Windows.Forms.ToolStripButton();
            this.bg1modeButton = new System.Windows.Forms.ToolStripButton();
            this.bg2modeButton = new System.Windows.Forms.ToolStripButton();
            this.bg3modeButton = new System.Windows.Forms.ToolStripButton();
            this.spritemodeButton = new System.Windows.Forms.ToolStripButton();
            this.blockmodeButton = new System.Windows.Forms.ToolStripButton();
            this.torchmodeButton = new System.Windows.Forms.ToolStripButton();
            this.chestmodeButton = new System.Windows.Forms.ToolStripButton();
            this.potmodeButton = new System.Windows.Forms.ToolStripButton();
            this.doormodeButton = new System.Windows.Forms.ToolStripButton();
            this.warpmodeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveLayoutButton = new System.Windows.Forms.ToolStripButton();
            this.loadlayoutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.spriteImageList = new System.Windows.Forms.ImageList(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.nothingselectedcontextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.singleselectedcontextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bringToFrontToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseZBy1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBackToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseZBy1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBg1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBg1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBg1ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.editGfxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupselectedcontextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.bringToFrontToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBackToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBg1ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBg1ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBg1ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolboxPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.roomtabPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.mapPicturebox = new System.Windows.Forms.PictureBox();
            this.roomListView = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.roomProperty_sortsprite = new System.Windows.Forms.CheckBox();
            this.button_stair4 = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.roomProperty_stair4plane = new System.Windows.Forms.TextBox();
            this.roomProperty_stair4 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.button_stair3 = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.roomProperty_stair3plane = new System.Windows.Forms.TextBox();
            this.roomProperty_stair3 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.button_stair2 = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.roomProperty_stair2plane = new System.Windows.Forms.TextBox();
            this.roomProperty_stair2 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.button_stair1 = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.roomProperty_stair1plane = new System.Windows.Forms.TextBox();
            this.roomProperty_stair1 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.button_holewarp = new System.Windows.Forms.Button();
            this.roomProperty_msgid = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.roomProperty_pit = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.roomProperty_holeplane = new System.Windows.Forms.TextBox();
            this.roomProperty_hole = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.roomProperty_tag2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.roomProperty_tag1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.roomProperty_effect = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.roomProperty_spriteset = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.roomProperty_layout = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.roomProperty_palette = new System.Windows.Forms.TextBox();
            this.roomProperty_blockset = new System.Windows.Forms.TextBox();
            this.roomProperty_floor2 = new System.Windows.Forms.TextBox();
            this.roomProperty_floor1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.roomProperty_collision = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.roomProperty_bg2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.entrancetabPage = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.entrancetreeView = new System.Windows.Forms.TreeView();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.entranceProperty_FR = new System.Windows.Forms.TextBox();
            this.entranceProperty_HR = new System.Windows.Forms.TextBox();
            this.entranceProperty_FL = new System.Windows.Forms.TextBox();
            this.entranceProperty_HL = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.entranceProperty_FD = new System.Windows.Forms.TextBox();
            this.entranceProperty_HD = new System.Windows.Forms.TextBox();
            this.entranceProperty_FU = new System.Windows.Forms.TextBox();
            this.entranceProperty_HU = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.entranceProperty_bg = new System.Windows.Forms.CheckBox();
            this.entranceProperty_quadbr = new System.Windows.Forms.RadioButton();
            this.entranceProperty_quadtr = new System.Windows.Forms.RadioButton();
            this.entranceProperty_quadbl = new System.Windows.Forms.RadioButton();
            this.label42 = new System.Windows.Forms.Label();
            this.entranceProperty_quadtl = new System.Windows.Forms.RadioButton();
            this.entranceProperty_vscroll = new System.Windows.Forms.CheckBox();
            this.entranceProperty_hscroll = new System.Windows.Forms.CheckBox();
            this.entranceProperty_scrolly = new System.Windows.Forms.TextBox();
            this.entranceProperty_scrollx = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.entranceProperty_camy = new System.Windows.Forms.TextBox();
            this.entranceProperty_camx = new System.Windows.Forms.TextBox();
            this.entranceProperty_ypos = new System.Windows.Forms.TextBox();
            this.entranceProperty_xpos = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.entranceProperty_exit = new System.Windows.Forms.TextBox();
            this.entranceProperty_blockset = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.entranceProperty_music = new System.Windows.Forms.TextBox();
            this.entranceProperty_dungeon = new System.Windows.Forms.TextBox();
            this.entranceProperty_floor = new System.Windows.Forms.TextBox();
            this.entranceProperty_room = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cameraboxCheckbox = new System.Windows.Forms.CheckBox();
            this.entranceposCheckbox = new System.Windows.Forms.CheckBox();
            this.objectstabPage = new System.Windows.Forms.TabPage();
            this.panel1 = new ZeldaFullEditor.CustomPanel();
            this.objectViewer1 = new ZeldaFullEditor.ObjectViewer();
            this.showNameObjectCheckbox = new System.Windows.Forms.CheckBox();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.customPanel1 = new ZeldaFullEditor.CustomPanel();
            this.spritesView1 = new ZeldaFullEditor.SpritesView();
            this.searchspriteTextbox = new System.Windows.Forms.TextBox();
            this.palettestabPage = new System.Windows.Forms.TabPage();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.palettesTreeview = new System.Windows.Forms.TreeView();
            this.palettePicturebox = new System.Windows.Forms.PictureBox();
            this.gfxtabPage = new System.Windows.Forms.TabPage();
            this.customPanel2 = new ZeldaFullEditor.CustomPanel();
            this.gfxPicturebox = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.previewPaletteGfxTextbox = new System.Windows.Forms.TextBox();
            this.gfx8textBox = new System.Windows.Forms.TextBox();
            this.gfx7textBox = new System.Windows.Forms.TextBox();
            this.gfx6textBox = new System.Windows.Forms.TextBox();
            this.gfx5textBox = new System.Windows.Forms.TextBox();
            this.gfx4textBox = new System.Windows.Forms.TextBox();
            this.gfx3textBox = new System.Windows.Forms.TextBox();
            this.gfx2textBox = new System.Windows.Forms.TextBox();
            this.gfx1textBox = new System.Windows.Forms.TextBox();
            this.gfxgroupindexUpDown = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.gfxfromroomButton = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.gfxgroupCombobox = new System.Windows.Forms.ComboBox();
            this.debugtabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.hovergfxLabel = new System.Windows.Forms.Label();
            this.previewPaletteTextbox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.selectedGroupbox = new System.Windows.Forms.GroupBox();
            this.litCheckbox = new System.Windows.Forms.CheckBox();
            this.object_z_label = new System.Windows.Forms.Label();
            this.spritepropertyPanel = new System.Windows.Forms.Panel();
            this.spriteoverlordCheckbox = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.spritesubtypeUpDown = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.object_layer_label = new System.Windows.Forms.Label();
            this.object_size_label = new System.Windows.Forms.Label();
            this.object_y_label = new System.Windows.Forms.Label();
            this.object_x_label = new System.Windows.Forms.Label();
            this.doorselectPanel = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.potitemobjectPanel = new System.Windows.Forms.Panel();
            this.selecteditemobjectCombobox = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.nothingselectedcontextMenu.SuspendLayout();
            this.singleselectedcontextMenu.SuspendLayout();
            this.groupselectedcontextMenu.SuspendLayout();
            this.toolboxPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.roomtabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPicturebox)).BeginInit();
            this.panel2.SuspendLayout();
            this.entrancetabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.objectstabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.palettestabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).BeginInit();
            this.gfxtabPage.SuspendLayout();
            this.customPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gfxPicturebox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gfxgroupindexUpDown)).BeginInit();
            this.debugtabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.selectedGroupbox.SuspendLayout();
            this.spritepropertyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritesubtypeUpDown)).BeginInit();
            this.doorselectPanel.SuspendLayout();
            this.potitemobjectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(874, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.exportOnJPROMToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.openToolStripMenuItem.Text = "Open ROM";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.saveToolStripMenuItem.Text = "Save ROM";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveasToolStripMenuItem
            // 
            this.saveasToolStripMenuItem.Enabled = false;
            this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            this.saveasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveasToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.saveasToolStripMenuItem.Text = "Save ROM As...";
            this.saveasToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
            // 
            // exportOnJPROMToolStripMenuItem
            // 
            this.exportOnJPROMToolStripMenuItem.Name = "exportOnJPROMToolStripMenuItem";
            this.exportOnJPROMToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.exportOnJPROMToolStripMenuItem.Text = "Export Current ROM on JP ROM";
            this.exportOnJPROMToolStripMenuItem.Click += new System.EventHandler(this.exportOnJPROMToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator4,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator5,
            this.selectAllToolStripMenuItem,
            this.toolStripSeparator6,
            this.moveFrontToolStripMenuItem,
            this.bringToBackToolStripMenuItem,
            this.toolStripSeparator7,
            this.selectAllMapForExportToolStripMenuItem,
            this.deselectedAllMapForExportToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(236, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(236, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Enabled = false;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(236, 6);
            // 
            // moveFrontToolStripMenuItem
            // 
            this.moveFrontToolStripMenuItem.Enabled = false;
            this.moveFrontToolStripMenuItem.Name = "moveFrontToolStripMenuItem";
            this.moveFrontToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.moveFrontToolStripMenuItem.Text = "Bring to Front";
            this.moveFrontToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // bringToBackToolStripMenuItem
            // 
            this.bringToBackToolStripMenuItem.Enabled = false;
            this.bringToBackToolStripMenuItem.Name = "bringToBackToolStripMenuItem";
            this.bringToBackToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.bringToBackToolStripMenuItem.Text = "Send to Back";
            this.bringToBackToolStripMenuItem.Click += new System.EventHandler(this.bringToBackToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(236, 6);
            // 
            // selectAllMapForExportToolStripMenuItem
            // 
            this.selectAllMapForExportToolStripMenuItem.Name = "selectAllMapForExportToolStripMenuItem";
            this.selectAllMapForExportToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.selectAllMapForExportToolStripMenuItem.Text = "Select All Map (For Export)";
            this.selectAllMapForExportToolStripMenuItem.Click += new System.EventHandler(this.selectAllMapForExportToolStripMenuItem_Click);
            // 
            // deselectedAllMapForExportToolStripMenuItem
            // 
            this.deselectedAllMapForExportToolStripMenuItem.Name = "deselectedAllMapForExportToolStripMenuItem";
            this.deselectedAllMapForExportToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.deselectedAllMapForExportToolStripMenuItem.Text = "Deselected All Map (For Export)";
            this.deselectedAllMapForExportToolStripMenuItem.Click += new System.EventHandler(this.deselectedAllMapForExportToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoRoomToolStripMenuItem,
            this.globalOptionsToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // gotoRoomToolStripMenuItem
            // 
            this.gotoRoomToolStripMenuItem.Name = "gotoRoomToolStripMenuItem";
            this.gotoRoomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gotoRoomToolStripMenuItem.Text = "Goto Room";
            this.gotoRoomToolStripMenuItem.Click += new System.EventHandler(this.gotoRoomToolStripMenuItem_Click);
            // 
            // globalOptionsToolStripMenuItem
            // 
            this.globalOptionsToolStripMenuItem.Name = "globalOptionsToolStripMenuItem";
            this.globalOptionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.globalOptionsToolStripMenuItem.Text = "Global Options";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textSpriteToolStripMenuItem,
            this.textChestItemToolStripMenuItem,
            this.textPotItemToolStripMenuItem,
            this.showGridToolStripMenuItem,
            this.showBG2ToolStripMenuItem,
            this.showBG1ToolStripMenuItem,
            this.unselectedBGTransparentToolStripMenuItem,
            this.animatedToolStripMenuItem,
            this.darkThemeToolStripMenuItem,
            this.rightSideToolboxToolStripMenuItem,
            this.hideSpritesToolStripMenuItem,
            this.hideItemsToolStripMenuItem,
            this.hideAllTextToolStripMenuItem,
            this.hideChestItemsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // textSpriteToolStripMenuItem
            // 
            this.textSpriteToolStripMenuItem.CheckOnClick = true;
            this.textSpriteToolStripMenuItem.Name = "textSpriteToolStripMenuItem";
            this.textSpriteToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.textSpriteToolStripMenuItem.Text = "Text Sprite";
            this.textSpriteToolStripMenuItem.Click += new System.EventHandler(this.textSpriteToolStripMenuItem_Click);
            // 
            // textChestItemToolStripMenuItem
            // 
            this.textChestItemToolStripMenuItem.CheckOnClick = true;
            this.textChestItemToolStripMenuItem.Name = "textChestItemToolStripMenuItem";
            this.textChestItemToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.textChestItemToolStripMenuItem.Text = "Text ChestItem";
            // 
            // textPotItemToolStripMenuItem
            // 
            this.textPotItemToolStripMenuItem.CheckOnClick = true;
            this.textPotItemToolStripMenuItem.Name = "textPotItemToolStripMenuItem";
            this.textPotItemToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.textPotItemToolStripMenuItem.Text = "Text PotItem";
            // 
            // showGridToolStripMenuItem
            // 
            this.showGridToolStripMenuItem.CheckOnClick = true;
            this.showGridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x8ToolStripMenuItem,
            this.x16ToolStripMenuItem,
            this.x32ToolStripMenuItem,
            this.x64ToolStripMenuItem,
            this.x256ToolStripMenuItem});
            this.showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
            this.showGridToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.showGridToolStripMenuItem.Text = "Show Grid";
            this.showGridToolStripMenuItem.Click += new System.EventHandler(this.showGridToolStripMenuItem_Click);
            // 
            // x8ToolStripMenuItem
            // 
            this.x8ToolStripMenuItem.CheckOnClick = true;
            this.x8ToolStripMenuItem.Name = "x8ToolStripMenuItem";
            this.x8ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.x8ToolStripMenuItem.Text = "8x8";
            this.x8ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
            // 
            // x16ToolStripMenuItem
            // 
            this.x16ToolStripMenuItem.CheckOnClick = true;
            this.x16ToolStripMenuItem.Name = "x16ToolStripMenuItem";
            this.x16ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.x16ToolStripMenuItem.Text = "16x16";
            this.x16ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
            // 
            // x32ToolStripMenuItem
            // 
            this.x32ToolStripMenuItem.CheckOnClick = true;
            this.x32ToolStripMenuItem.Name = "x32ToolStripMenuItem";
            this.x32ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.x32ToolStripMenuItem.Text = "32x32";
            this.x32ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
            // 
            // x64ToolStripMenuItem
            // 
            this.x64ToolStripMenuItem.CheckOnClick = true;
            this.x64ToolStripMenuItem.Name = "x64ToolStripMenuItem";
            this.x64ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.x64ToolStripMenuItem.Text = "64x64";
            this.x64ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
            // 
            // x256ToolStripMenuItem
            // 
            this.x256ToolStripMenuItem.CheckOnClick = true;
            this.x256ToolStripMenuItem.Name = "x256ToolStripMenuItem";
            this.x256ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.x256ToolStripMenuItem.Text = "256x256";
            this.x256ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
            // 
            // showBG2ToolStripMenuItem
            // 
            this.showBG2ToolStripMenuItem.Checked = true;
            this.showBG2ToolStripMenuItem.CheckOnClick = true;
            this.showBG2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBG2ToolStripMenuItem.Name = "showBG2ToolStripMenuItem";
            this.showBG2ToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.showBG2ToolStripMenuItem.Text = "Show BG2";
            this.showBG2ToolStripMenuItem.Click += new System.EventHandler(this.showBG2ToolStripMenuItem_Click);
            // 
            // showBG1ToolStripMenuItem
            // 
            this.showBG1ToolStripMenuItem.Checked = true;
            this.showBG1ToolStripMenuItem.CheckOnClick = true;
            this.showBG1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBG1ToolStripMenuItem.Name = "showBG1ToolStripMenuItem";
            this.showBG1ToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.showBG1ToolStripMenuItem.Text = "Show BG1";
            this.showBG1ToolStripMenuItem.Click += new System.EventHandler(this.showBG1ToolStripMenuItem_Click);
            // 
            // unselectedBGTransparentToolStripMenuItem
            // 
            this.unselectedBGTransparentToolStripMenuItem.Checked = true;
            this.unselectedBGTransparentToolStripMenuItem.CheckOnClick = true;
            this.unselectedBGTransparentToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.unselectedBGTransparentToolStripMenuItem.Name = "unselectedBGTransparentToolStripMenuItem";
            this.unselectedBGTransparentToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.unselectedBGTransparentToolStripMenuItem.Text = "Unselected BG Transparent";
            this.unselectedBGTransparentToolStripMenuItem.Click += new System.EventHandler(this.unselectedBGTransparentToolStripMenuItem_Click);
            // 
            // animatedToolStripMenuItem
            // 
            this.animatedToolStripMenuItem.CheckOnClick = true;
            this.animatedToolStripMenuItem.Name = "animatedToolStripMenuItem";
            this.animatedToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.animatedToolStripMenuItem.Text = "Animated";
            // 
            // darkThemeToolStripMenuItem
            // 
            this.darkThemeToolStripMenuItem.CheckOnClick = true;
            this.darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
            this.darkThemeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.darkThemeToolStripMenuItem.Text = "Dark Theme";
            // 
            // rightSideToolboxToolStripMenuItem
            // 
            this.rightSideToolboxToolStripMenuItem.CheckOnClick = true;
            this.rightSideToolboxToolStripMenuItem.Name = "rightSideToolboxToolStripMenuItem";
            this.rightSideToolboxToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.rightSideToolboxToolStripMenuItem.Text = "Right side Toolbox";
            this.rightSideToolboxToolStripMenuItem.Click += new System.EventHandler(this.rightSideToolboxToolStripMenuItem_Click);
            // 
            // hideSpritesToolStripMenuItem
            // 
            this.hideSpritesToolStripMenuItem.CheckOnClick = true;
            this.hideSpritesToolStripMenuItem.Name = "hideSpritesToolStripMenuItem";
            this.hideSpritesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.hideSpritesToolStripMenuItem.Text = "Hide Sprites";
            // 
            // hideItemsToolStripMenuItem
            // 
            this.hideItemsToolStripMenuItem.CheckOnClick = true;
            this.hideItemsToolStripMenuItem.Name = "hideItemsToolStripMenuItem";
            this.hideItemsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.hideItemsToolStripMenuItem.Text = "Hide Items";
            // 
            // hideAllTextToolStripMenuItem
            // 
            this.hideAllTextToolStripMenuItem.CheckOnClick = true;
            this.hideAllTextToolStripMenuItem.Name = "hideAllTextToolStripMenuItem";
            this.hideAllTextToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.hideAllTextToolStripMenuItem.Text = "Hide All Text";
            // 
            // hideChestItemsToolStripMenuItem
            // 
            this.hideChestItemsToolStripMenuItem.CheckOnClick = true;
            this.hideChestItemsToolStripMenuItem.Name = "hideChestItemsToolStripMenuItem";
            this.hideChestItemsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.hideChestItemsToolStripMenuItem.Text = "Hide Chest Items";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem,
            this.patchNotesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.howToUseToolStripMenuItem.Text = "How to Use";
            this.howToUseToolStripMenuItem.Click += new System.EventHandler(this.howToUseToolStripMenuItem_Click);
            // 
            // patchNotesToolStripMenuItem
            // 
            this.patchNotesToolStripMenuItem.Name = "patchNotesToolStripMenuItem";
            this.patchNotesToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.patchNotesToolStripMenuItem.Text = "Patch Notes";
            this.patchNotesToolStripMenuItem.Click += new System.EventHandler(this.patchNotesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openfileButton,
            this.saveButton,
            this.debugtestButton,
            this.runtestButton,
            this.toolStripSeparator1,
            this.undoButton,
            this.redoButton,
            this.toolStripSeparator2,
            this.allbgsButton,
            this.bg1modeButton,
            this.bg2modeButton,
            this.bg3modeButton,
            this.spritemodeButton,
            this.blockmodeButton,
            this.torchmodeButton,
            this.chestmodeButton,
            this.potmodeButton,
            this.doormodeButton,
            this.warpmodeButton,
            this.toolStripSeparator3,
            this.saveLayoutButton,
            this.loadlayoutButton,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(874, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openfileButton
            // 
            this.openfileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openfileButton.Image = ((System.Drawing.Image)(resources.GetObject("openfileButton.Image")));
            this.openfileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openfileButton.Name = "openfileButton";
            this.openfileButton.Size = new System.Drawing.Size(23, 22);
            this.openfileButton.Text = "Open ROM";
            this.openfileButton.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Enabled = false;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 22);
            this.saveButton.Text = "Save ROM";
            this.saveButton.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // debugtestButton
            // 
            this.debugtestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.debugtestButton.Enabled = false;
            this.debugtestButton.Image = ((System.Drawing.Image)(resources.GetObject("debugtestButton.Image")));
            this.debugtestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debugtestButton.Name = "debugtestButton";
            this.debugtestButton.Size = new System.Drawing.Size(23, 22);
            this.debugtestButton.Text = "Save and Debug in emulator";
            this.debugtestButton.Click += new System.EventHandler(this.debugtestButton_Click);
            // 
            // runtestButton
            // 
            this.runtestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.runtestButton.Enabled = false;
            this.runtestButton.Image = ((System.Drawing.Image)(resources.GetObject("runtestButton.Image")));
            this.runtestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runtestButton.Name = "runtestButton";
            this.runtestButton.Size = new System.Drawing.Size(23, 22);
            this.runtestButton.Text = "Save and Run in emulator";
            this.runtestButton.Click += new System.EventHandler(this.runtestButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Enabled = false;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(23, 22);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Enabled = false;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(23, 22);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // allbgsButton
            // 
            this.allbgsButton.CheckOnClick = true;
            this.allbgsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.allbgsButton.Enabled = false;
            this.allbgsButton.Image = ((System.Drawing.Image)(resources.GetObject("allbgsButton.Image")));
            this.allbgsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.allbgsButton.Name = "allbgsButton";
            this.allbgsButton.Size = new System.Drawing.Size(23, 22);
            this.allbgsButton.Text = "All Layer";
            this.allbgsButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // bg1modeButton
            // 
            this.bg1modeButton.Checked = true;
            this.bg1modeButton.CheckOnClick = true;
            this.bg1modeButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bg1modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bg1modeButton.Enabled = false;
            this.bg1modeButton.Image = ((System.Drawing.Image)(resources.GetObject("bg1modeButton.Image")));
            this.bg1modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bg1modeButton.Name = "bg1modeButton";
            this.bg1modeButton.Size = new System.Drawing.Size(23, 22);
            this.bg1modeButton.Text = "Layer 1";
            this.bg1modeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // bg2modeButton
            // 
            this.bg2modeButton.CheckOnClick = true;
            this.bg2modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bg2modeButton.Enabled = false;
            this.bg2modeButton.Image = ((System.Drawing.Image)(resources.GetObject("bg2modeButton.Image")));
            this.bg2modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bg2modeButton.Name = "bg2modeButton";
            this.bg2modeButton.Size = new System.Drawing.Size(23, 22);
            this.bg2modeButton.Text = "Layer 2";
            this.bg2modeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // bg3modeButton
            // 
            this.bg3modeButton.CheckOnClick = true;
            this.bg3modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bg3modeButton.Enabled = false;
            this.bg3modeButton.Image = ((System.Drawing.Image)(resources.GetObject("bg3modeButton.Image")));
            this.bg3modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bg3modeButton.Name = "bg3modeButton";
            this.bg3modeButton.Size = new System.Drawing.Size(23, 22);
            this.bg3modeButton.Text = "Layer 3";
            this.bg3modeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // spritemodeButton
            // 
            this.spritemodeButton.CheckOnClick = true;
            this.spritemodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.spritemodeButton.Enabled = false;
            this.spritemodeButton.Image = ((System.Drawing.Image)(resources.GetObject("spritemodeButton.Image")));
            this.spritemodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.spritemodeButton.Name = "spritemodeButton";
            this.spritemodeButton.Size = new System.Drawing.Size(23, 22);
            this.spritemodeButton.Text = "Objects Mode";
            this.spritemodeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // blockmodeButton
            // 
            this.blockmodeButton.CheckOnClick = true;
            this.blockmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.blockmodeButton.Enabled = false;
            this.blockmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("blockmodeButton.Image")));
            this.blockmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.blockmodeButton.Name = "blockmodeButton";
            this.blockmodeButton.Size = new System.Drawing.Size(23, 22);
            this.blockmodeButton.Text = "Block Mode";
            this.blockmodeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // torchmodeButton
            // 
            this.torchmodeButton.CheckOnClick = true;
            this.torchmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.torchmodeButton.Enabled = false;
            this.torchmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("torchmodeButton.Image")));
            this.torchmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.torchmodeButton.Name = "torchmodeButton";
            this.torchmodeButton.Size = new System.Drawing.Size(23, 22);
            this.torchmodeButton.Text = "Torch Mode";
            this.torchmodeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // chestmodeButton
            // 
            this.chestmodeButton.CheckOnClick = true;
            this.chestmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chestmodeButton.Enabled = false;
            this.chestmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("chestmodeButton.Image")));
            this.chestmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chestmodeButton.Name = "chestmodeButton";
            this.chestmodeButton.Size = new System.Drawing.Size(23, 22);
            this.chestmodeButton.Text = "Chest Mode";
            this.chestmodeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // potmodeButton
            // 
            this.potmodeButton.CheckOnClick = true;
            this.potmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.potmodeButton.Enabled = false;
            this.potmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("potmodeButton.Image")));
            this.potmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.potmodeButton.Name = "potmodeButton";
            this.potmodeButton.Size = new System.Drawing.Size(23, 22);
            this.potmodeButton.Text = "Pots Item Mode";
            this.potmodeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // doormodeButton
            // 
            this.doormodeButton.CheckOnClick = true;
            this.doormodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.doormodeButton.Enabled = false;
            this.doormodeButton.Image = ((System.Drawing.Image)(resources.GetObject("doormodeButton.Image")));
            this.doormodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.doormodeButton.Name = "doormodeButton";
            this.doormodeButton.Size = new System.Drawing.Size(23, 22);
            this.doormodeButton.Text = "Doors Mode";
            this.doormodeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // warpmodeButton
            // 
            this.warpmodeButton.CheckOnClick = true;
            this.warpmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.warpmodeButton.Enabled = false;
            this.warpmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("warpmodeButton.Image")));
            this.warpmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.warpmodeButton.Name = "warpmodeButton";
            this.warpmodeButton.Size = new System.Drawing.Size(23, 22);
            this.warpmodeButton.Text = "warp/stairs/teleport";
            this.warpmodeButton.Click += new System.EventHandler(this.update_modes_buttons);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // saveLayoutButton
            // 
            this.saveLayoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveLayoutButton.Enabled = false;
            this.saveLayoutButton.Image = ((System.Drawing.Image)(resources.GetObject("saveLayoutButton.Image")));
            this.saveLayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveLayoutButton.Name = "saveLayoutButton";
            this.saveLayoutButton.Size = new System.Drawing.Size(23, 22);
            this.saveLayoutButton.Text = "Save layout";
            this.saveLayoutButton.Click += new System.EventHandler(this.saveLayoutButton_Click);
            // 
            // loadlayoutButton
            // 
            this.loadlayoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadlayoutButton.Enabled = false;
            this.loadlayoutButton.Image = ((System.Drawing.Image)(resources.GetObject("loadlayoutButton.Image")));
            this.loadlayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadlayoutButton.Name = "loadlayoutButton";
            this.loadlayoutButton.Size = new System.Drawing.Size(23, 22);
            this.loadlayoutButton.Text = "Load Layout";
            this.loadlayoutButton.Click += new System.EventHandler(this.loadlayoutButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Export selected as png";
            this.toolStripButton1.ToolTipText = "Export Map as png, Hold control and double click on the rooms you want to export";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Dungeon Generator";
            this.toolStripButton2.Click += new System.EventHandler(this.tabControl2_Click);
            // 
            // spriteImageList
            // 
            this.spriteImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.spriteImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.spriteImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // nothingselectedcontextMenu
            // 
            this.nothingselectedcontextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.pasteToolStripMenuItem3});
            this.nothingselectedcontextMenu.Name = "nothingselectedcontextMenu";
            this.nothingselectedcontextMenu.Size = new System.Drawing.Size(129, 48);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.insertToolStripMenuItem.Text = "Insert new";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem3
            // 
            this.pasteToolStripMenuItem3.Name = "pasteToolStripMenuItem3";
            this.pasteToolStripMenuItem3.Size = new System.Drawing.Size(128, 22);
            this.pasteToolStripMenuItem3.Text = "Paste";
            this.pasteToolStripMenuItem3.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // singleselectedcontextMenu
            // 
            this.singleselectedcontextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.changeObjectToolStripMenuItem,
            this.cutToolStripMenuItem1,
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.increaseZToolStripMenuItem,
            this.decreaseZToolStripMenuItem,
            this.sendToBg1ToolStripMenuItem,
            this.sendToBg1ToolStripMenuItem1,
            this.sendToBg1ToolStripMenuItem2,
            this.editGfxToolStripMenuItem});
            this.singleselectedcontextMenu.Name = "nothingselectedcontextMenu";
            this.singleselectedcontextMenu.Size = new System.Drawing.Size(152, 268);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem1.Text = "Insert new";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // changeObjectToolStripMenuItem
            // 
            this.changeObjectToolStripMenuItem.Name = "changeObjectToolStripMenuItem";
            this.changeObjectToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.changeObjectToolStripMenuItem.Text = "Change object";
            this.changeObjectToolStripMenuItem.Click += new System.EventHandler(this.changeObjectToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem1
            // 
            this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            this.cutToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.cutToolStripMenuItem1.Text = "Cut";
            this.cutToolStripMenuItem1.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // increaseZToolStripMenuItem
            // 
            this.increaseZToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bringToFrontToolStripMenuItem2,
            this.increaseZBy1ToolStripMenuItem});
            this.increaseZToolStripMenuItem.Name = "increaseZToolStripMenuItem";
            this.increaseZToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.increaseZToolStripMenuItem.Text = "Increase Z";
            // 
            // bringToFrontToolStripMenuItem2
            // 
            this.bringToFrontToolStripMenuItem2.Name = "bringToFrontToolStripMenuItem2";
            this.bringToFrontToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.bringToFrontToolStripMenuItem2.Text = "Bring to Front";
            this.bringToFrontToolStripMenuItem2.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // increaseZBy1ToolStripMenuItem
            // 
            this.increaseZBy1ToolStripMenuItem.Enabled = false;
            this.increaseZBy1ToolStripMenuItem.Name = "increaseZBy1ToolStripMenuItem";
            this.increaseZBy1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.increaseZBy1ToolStripMenuItem.Text = "Increase Z by 1";
            // 
            // decreaseZToolStripMenuItem
            // 
            this.decreaseZToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToBackToolStripMenuItem2,
            this.decreaseZBy1ToolStripMenuItem});
            this.decreaseZToolStripMenuItem.Name = "decreaseZToolStripMenuItem";
            this.decreaseZToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.decreaseZToolStripMenuItem.Text = "Decrease Z";
            // 
            // sendToBackToolStripMenuItem2
            // 
            this.sendToBackToolStripMenuItem2.Name = "sendToBackToolStripMenuItem2";
            this.sendToBackToolStripMenuItem2.Size = new System.Drawing.Size(156, 22);
            this.sendToBackToolStripMenuItem2.Text = "Send to Back";
            this.sendToBackToolStripMenuItem2.Click += new System.EventHandler(this.bringToBackToolStripMenuItem_Click);
            // 
            // decreaseZBy1ToolStripMenuItem
            // 
            this.decreaseZBy1ToolStripMenuItem.Enabled = false;
            this.decreaseZBy1ToolStripMenuItem.Name = "decreaseZBy1ToolStripMenuItem";
            this.decreaseZBy1ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.decreaseZBy1ToolStripMenuItem.Text = "Decrease Z by 1";
            this.decreaseZBy1ToolStripMenuItem.Click += new System.EventHandler(this.decreaseZBy1ToolStripMenuItem_Click);
            // 
            // sendToBg1ToolStripMenuItem
            // 
            this.sendToBg1ToolStripMenuItem.Name = "sendToBg1ToolStripMenuItem";
            this.sendToBg1ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.sendToBg1ToolStripMenuItem.Text = "Send to Bg1";
            this.sendToBg1ToolStripMenuItem.Click += new System.EventHandler(this.sendToBg1ToolStripMenuItem_Click);
            // 
            // sendToBg1ToolStripMenuItem1
            // 
            this.sendToBg1ToolStripMenuItem1.Name = "sendToBg1ToolStripMenuItem1";
            this.sendToBg1ToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.sendToBg1ToolStripMenuItem1.Text = "Send to Bg2";
            this.sendToBg1ToolStripMenuItem1.Click += new System.EventHandler(this.sendToBg1ToolStripMenuItem1_Click);
            // 
            // sendToBg1ToolStripMenuItem2
            // 
            this.sendToBg1ToolStripMenuItem2.Name = "sendToBg1ToolStripMenuItem2";
            this.sendToBg1ToolStripMenuItem2.Size = new System.Drawing.Size(151, 22);
            this.sendToBg1ToolStripMenuItem2.Text = "Send to Bg3";
            this.sendToBg1ToolStripMenuItem2.Click += new System.EventHandler(this.sendToBg1ToolStripMenuItem2_Click);
            // 
            // editGfxToolStripMenuItem
            // 
            this.editGfxToolStripMenuItem.Enabled = false;
            this.editGfxToolStripMenuItem.Name = "editGfxToolStripMenuItem";
            this.editGfxToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.editGfxToolStripMenuItem.Text = "Edit gfx";
            // 
            // groupselectedcontextMenu
            // 
            this.groupselectedcontextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.cutToolStripMenuItem2,
            this.copyToolStripMenuItem2,
            this.pasteToolStripMenuItem2,
            this.toolStripMenuItem3,
            this.bringToFrontToolStripMenuItem1,
            this.sendToBackToolStripMenuItem1,
            this.toolStripMenuItem4,
            this.sendToBg1ToolStripMenuItem3,
            this.sendToBg1ToolStripMenuItem4,
            this.sendToBg1ToolStripMenuItem5});
            this.groupselectedcontextMenu.Name = "nothingselectedcontextMenu";
            this.groupselectedcontextMenu.Size = new System.Drawing.Size(174, 246);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem2.Text = "Insert new";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem2
            // 
            this.cutToolStripMenuItem2.Name = "cutToolStripMenuItem2";
            this.cutToolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            this.cutToolStripMenuItem2.Text = "Cut";
            this.cutToolStripMenuItem2.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem2
            // 
            this.copyToolStripMenuItem2.Name = "copyToolStripMenuItem2";
            this.copyToolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            this.copyToolStripMenuItem2.Text = "Copy";
            this.copyToolStripMenuItem2.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem2
            // 
            this.pasteToolStripMenuItem2.Name = "pasteToolStripMenuItem2";
            this.pasteToolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            this.pasteToolStripMenuItem2.Text = "Paste";
            this.pasteToolStripMenuItem2.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem3.Text = "Delete";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // bringToFrontToolStripMenuItem1
            // 
            this.bringToFrontToolStripMenuItem1.Name = "bringToFrontToolStripMenuItem1";
            this.bringToFrontToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.bringToFrontToolStripMenuItem1.Text = "Bring to Front";
            this.bringToFrontToolStripMenuItem1.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // sendToBackToolStripMenuItem1
            // 
            this.sendToBackToolStripMenuItem1.Name = "sendToBackToolStripMenuItem1";
            this.sendToBackToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.sendToBackToolStripMenuItem1.Text = "Send to Back";
            this.sendToBackToolStripMenuItem1.Click += new System.EventHandler(this.bringToBackToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem4.Text = "Save as new layout";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // sendToBg1ToolStripMenuItem3
            // 
            this.sendToBg1ToolStripMenuItem3.Name = "sendToBg1ToolStripMenuItem3";
            this.sendToBg1ToolStripMenuItem3.Size = new System.Drawing.Size(173, 22);
            this.sendToBg1ToolStripMenuItem3.Text = "Send to Bg1";
            this.sendToBg1ToolStripMenuItem3.Click += new System.EventHandler(this.sendToBg1ToolStripMenuItem_Click);
            // 
            // sendToBg1ToolStripMenuItem4
            // 
            this.sendToBg1ToolStripMenuItem4.Name = "sendToBg1ToolStripMenuItem4";
            this.sendToBg1ToolStripMenuItem4.Size = new System.Drawing.Size(173, 22);
            this.sendToBg1ToolStripMenuItem4.Text = "Send to Bg2";
            this.sendToBg1ToolStripMenuItem4.Click += new System.EventHandler(this.sendToBg1ToolStripMenuItem1_Click);
            // 
            // sendToBg1ToolStripMenuItem5
            // 
            this.sendToBg1ToolStripMenuItem5.Name = "sendToBg1ToolStripMenuItem5";
            this.sendToBg1ToolStripMenuItem5.Size = new System.Drawing.Size(173, 22);
            this.sendToBg1ToolStripMenuItem5.Text = "Send to Bg3";
            this.sendToBg1ToolStripMenuItem5.Click += new System.EventHandler(this.sendToBg1ToolStripMenuItem2_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            // 
            // toolboxPanel
            // 
            this.toolboxPanel.Controls.Add(this.tabControl1);
            this.toolboxPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolboxPanel.Location = new System.Drawing.Point(0, 49);
            this.toolboxPanel.Name = "toolboxPanel";
            this.toolboxPanel.Size = new System.Drawing.Size(300, 592);
            this.toolboxPanel.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.roomtabPage);
            this.tabControl1.Controls.Add(this.entrancetabPage);
            this.tabControl1.Controls.Add(this.objectstabPage);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.palettestabPage);
            this.tabControl1.Controls.Add(this.gfxtabPage);
            this.tabControl1.Controls.Add(this.debugtabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(300, 592);
            this.tabControl1.TabIndex = 12;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // roomtabPage
            // 
            this.roomtabPage.Controls.Add(this.splitContainer2);
            this.roomtabPage.Location = new System.Drawing.Point(4, 40);
            this.roomtabPage.Name = "roomtabPage";
            this.roomtabPage.Padding = new System.Windows.Forms.Padding(3);
            this.roomtabPage.Size = new System.Drawing.Size(292, 548);
            this.roomtabPage.TabIndex = 0;
            this.roomtabPage.Text = "Rooms";
            this.roomtabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.mapPicturebox);
            this.splitContainer2.Panel1.Controls.Add(this.roomListView);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_sortsprite);
            this.splitContainer2.Panel2.Controls.Add(this.button_stair4);
            this.splitContainer2.Panel2.Controls.Add(this.label36);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_stair4plane);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_stair4);
            this.splitContainer2.Panel2.Controls.Add(this.label37);
            this.splitContainer2.Panel2.Controls.Add(this.button_stair3);
            this.splitContainer2.Panel2.Controls.Add(this.label34);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_stair3plane);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_stair3);
            this.splitContainer2.Panel2.Controls.Add(this.label35);
            this.splitContainer2.Panel2.Controls.Add(this.button_stair2);
            this.splitContainer2.Panel2.Controls.Add(this.label30);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_stair2plane);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_stair2);
            this.splitContainer2.Panel2.Controls.Add(this.label33);
            this.splitContainer2.Panel2.Controls.Add(this.button_stair1);
            this.splitContainer2.Panel2.Controls.Add(this.label27);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_stair1plane);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_stair1);
            this.splitContainer2.Panel2.Controls.Add(this.label28);
            this.splitContainer2.Panel2.Controls.Add(this.button_holewarp);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_msgid);
            this.splitContainer2.Panel2.Controls.Add(this.label20);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_pit);
            this.splitContainer2.Panel2.Controls.Add(this.label16);
            this.splitContainer2.Panel2.Controls.Add(this.label15);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_holeplane);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_hole);
            this.splitContainer2.Panel2.Controls.Add(this.label14);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_tag2);
            this.splitContainer2.Panel2.Controls.Add(this.label12);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_tag1);
            this.splitContainer2.Panel2.Controls.Add(this.label13);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_effect);
            this.splitContainer2.Panel2.Controls.Add(this.label11);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_spriteset);
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_layout);
            this.splitContainer2.Panel2.Controls.Add(this.label9);
            this.splitContainer2.Panel2.Controls.Add(this.label8);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_palette);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_blockset);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_floor2);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_floor1);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_collision);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.roomProperty_bg2);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(286, 542);
            this.splitContainer2.SplitterDistance = 264;
            this.splitContainer2.TabIndex = 0;
            // 
            // mapPicturebox
            // 
            this.mapPicturebox.Location = new System.Drawing.Point(0, 104);
            this.mapPicturebox.Name = "mapPicturebox";
            this.mapPicturebox.Size = new System.Drawing.Size(256, 304);
            this.mapPicturebox.TabIndex = 13;
            this.mapPicturebox.TabStop = false;
            this.mapPicturebox.Visible = false;
            this.mapPicturebox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mapPicturebox_MouseDoubleClick_1);
            // 
            // roomListView
            // 
            this.roomListView.AllowDrop = true;
            this.roomListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomListView.HideSelection = false;
            this.roomListView.LabelEdit = true;
            this.roomListView.Location = new System.Drawing.Point(0, 26);
            this.roomListView.Name = "roomListView";
            this.roomListView.Size = new System.Drawing.Size(269, 382);
            this.roomListView.TabIndex = 8;
            this.roomListView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.roomListView_AfterLabelEdit);
            this.roomListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.roomListView_ItemDrag);
            this.roomListView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.roomListView_NodeMouseDoubleClick);
            this.roomListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.roomListView_DragDrop);
            this.roomListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.roomListView_DragEnter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 26);
            this.panel2.TabIndex = 14;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(5, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(41, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "List";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(52, 6);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(49, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "Map ";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // roomProperty_sortsprite
            // 
            this.roomProperty_sortsprite.AutoSize = true;
            this.roomProperty_sortsprite.Location = new System.Drawing.Point(142, 192);
            this.roomProperty_sortsprite.Name = "roomProperty_sortsprite";
            this.roomProperty_sortsprite.Size = new System.Drawing.Size(80, 17);
            this.roomProperty_sortsprite.TabIndex = 52;
            this.roomProperty_sortsprite.Text = "Sort Sprites";
            this.roomProperty_sortsprite.UseVisualStyleBackColor = true;
            this.roomProperty_sortsprite.CheckedChanged += new System.EventHandler(this.roomProperty_pit_CheckedChanged);
            // 
            // button_stair4
            // 
            this.button_stair4.Location = new System.Drawing.Point(140, 404);
            this.button_stair4.Name = "button_stair4";
            this.button_stair4.Size = new System.Drawing.Size(75, 23);
            this.button_stair4.TabIndex = 51;
            this.button_stair4.Text = "Open";
            this.button_stair4.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(71, 390);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(40, 13);
            this.label36.TabIndex = 50;
            this.label36.Text = "Plane :";
            // 
            // roomProperty_stair4plane
            // 
            this.roomProperty_stair4plane.Location = new System.Drawing.Point(74, 406);
            this.roomProperty_stair4plane.Name = "roomProperty_stair4plane";
            this.roomProperty_stair4plane.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_stair4plane.TabIndex = 49;
            this.roomProperty_stair4plane.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // roomProperty_stair4
            // 
            this.roomProperty_stair4.Location = new System.Drawing.Point(8, 406);
            this.roomProperty_stair4.Name = "roomProperty_stair4";
            this.roomProperty_stair4.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_stair4.TabIndex = 48;
            this.roomProperty_stair4.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(5, 390);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(66, 13);
            this.label37.TabIndex = 47;
            this.label37.Text = "St.4/Door2 :";
            // 
            // button_stair3
            // 
            this.button_stair3.Location = new System.Drawing.Point(140, 365);
            this.button_stair3.Name = "button_stair3";
            this.button_stair3.Size = new System.Drawing.Size(75, 23);
            this.button_stair3.TabIndex = 46;
            this.button_stair3.Text = "Open";
            this.button_stair3.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(71, 351);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(40, 13);
            this.label34.TabIndex = 45;
            this.label34.Text = "Plane :";
            // 
            // roomProperty_stair3plane
            // 
            this.roomProperty_stair3plane.Location = new System.Drawing.Point(74, 367);
            this.roomProperty_stair3plane.Name = "roomProperty_stair3plane";
            this.roomProperty_stair3plane.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_stair3plane.TabIndex = 44;
            this.roomProperty_stair3plane.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // roomProperty_stair3
            // 
            this.roomProperty_stair3.Location = new System.Drawing.Point(8, 367);
            this.roomProperty_stair3.Name = "roomProperty_stair3";
            this.roomProperty_stair3.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_stair3.TabIndex = 43;
            this.roomProperty_stair3.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(5, 351);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(66, 13);
            this.label35.TabIndex = 42;
            this.label35.Text = "St.3/Door1 :";
            // 
            // button_stair2
            // 
            this.button_stair2.Location = new System.Drawing.Point(140, 326);
            this.button_stair2.Name = "button_stair2";
            this.button_stair2.Size = new System.Drawing.Size(75, 23);
            this.button_stair2.TabIndex = 41;
            this.button_stair2.Text = "Open";
            this.button_stair2.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(71, 312);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(40, 13);
            this.label30.TabIndex = 40;
            this.label30.Text = "Plane :";
            // 
            // roomProperty_stair2plane
            // 
            this.roomProperty_stair2plane.Location = new System.Drawing.Point(74, 328);
            this.roomProperty_stair2plane.Name = "roomProperty_stair2plane";
            this.roomProperty_stair2plane.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_stair2plane.TabIndex = 39;
            this.roomProperty_stair2plane.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // roomProperty_stair2
            // 
            this.roomProperty_stair2.Location = new System.Drawing.Point(8, 328);
            this.roomProperty_stair2.Name = "roomProperty_stair2";
            this.roomProperty_stair2.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_stair2.TabIndex = 38;
            this.roomProperty_stair2.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(5, 312);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(45, 13);
            this.label33.TabIndex = 37;
            this.label33.Text = "Stairs2 :";
            // 
            // button_stair1
            // 
            this.button_stair1.Location = new System.Drawing.Point(140, 287);
            this.button_stair1.Name = "button_stair1";
            this.button_stair1.Size = new System.Drawing.Size(75, 23);
            this.button_stair1.TabIndex = 36;
            this.button_stair1.Text = "Open";
            this.button_stair1.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(71, 273);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(40, 13);
            this.label27.TabIndex = 35;
            this.label27.Text = "Plane :";
            // 
            // roomProperty_stair1plane
            // 
            this.roomProperty_stair1plane.Location = new System.Drawing.Point(74, 289);
            this.roomProperty_stair1plane.Name = "roomProperty_stair1plane";
            this.roomProperty_stair1plane.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_stair1plane.TabIndex = 34;
            this.roomProperty_stair1plane.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // roomProperty_stair1
            // 
            this.roomProperty_stair1.Location = new System.Drawing.Point(8, 289);
            this.roomProperty_stair1.Name = "roomProperty_stair1";
            this.roomProperty_stair1.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_stair1.TabIndex = 33;
            this.roomProperty_stair1.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(5, 273);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(45, 13);
            this.label28.TabIndex = 32;
            this.label28.Text = "Stairs1 :";
            // 
            // button_holewarp
            // 
            this.button_holewarp.Location = new System.Drawing.Point(140, 248);
            this.button_holewarp.Name = "button_holewarp";
            this.button_holewarp.Size = new System.Drawing.Size(75, 23);
            this.button_holewarp.TabIndex = 31;
            this.button_holewarp.Text = "Open";
            this.button_holewarp.UseVisualStyleBackColor = true;
            // 
            // roomProperty_msgid
            // 
            this.roomProperty_msgid.Location = new System.Drawing.Point(8, 189);
            this.roomProperty_msgid.Name = "roomProperty_msgid";
            this.roomProperty_msgid.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_msgid.TabIndex = 30;
            this.roomProperty_msgid.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(5, 173);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 13);
            this.label20.TabIndex = 29;
            this.label20.Text = "Message ID :";
            // 
            // roomProperty_pit
            // 
            this.roomProperty_pit.AutoSize = true;
            this.roomProperty_pit.Location = new System.Drawing.Point(142, 176);
            this.roomProperty_pit.Name = "roomProperty_pit";
            this.roomProperty_pit.Size = new System.Drawing.Size(61, 17);
            this.roomProperty_pit.TabIndex = 28;
            this.roomProperty_pit.Text = "Pit Hurt";
            this.roomProperty_pit.UseVisualStyleBackColor = true;
            this.roomProperty_pit.CheckedChanged += new System.EventHandler(this.roomProperty_pit_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(5, 221);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(129, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Room Warps/Stairs : ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(71, 234);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Plane :";
            // 
            // roomProperty_holeplane
            // 
            this.roomProperty_holeplane.Location = new System.Drawing.Point(74, 250);
            this.roomProperty_holeplane.Name = "roomProperty_holeplane";
            this.roomProperty_holeplane.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_holeplane.TabIndex = 25;
            this.roomProperty_holeplane.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // roomProperty_hole
            // 
            this.roomProperty_hole.Location = new System.Drawing.Point(8, 250);
            this.roomProperty_hole.Name = "roomProperty_hole";
            this.roomProperty_hole.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_hole.TabIndex = 24;
            this.roomProperty_hole.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 234);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Hole/Warp :";
            // 
            // roomProperty_tag2
            // 
            this.roomProperty_tag2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomProperty_tag2.DropDownWidth = 200;
            this.roomProperty_tag2.FormattingEnabled = true;
            this.roomProperty_tag2.Location = new System.Drawing.Point(142, 149);
            this.roomProperty_tag2.Name = "roomProperty_tag2";
            this.roomProperty_tag2.Size = new System.Drawing.Size(124, 21);
            this.roomProperty_tag2.TabIndex = 22;
            this.roomProperty_tag2.SelectedIndexChanged += new System.EventHandler(this.roomProperty_bg2_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(139, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Tag 2 :";
            // 
            // roomProperty_tag1
            // 
            this.roomProperty_tag1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomProperty_tag1.DropDownWidth = 200;
            this.roomProperty_tag1.FormattingEnabled = true;
            this.roomProperty_tag1.Location = new System.Drawing.Point(8, 149);
            this.roomProperty_tag1.Name = "roomProperty_tag1";
            this.roomProperty_tag1.Size = new System.Drawing.Size(124, 21);
            this.roomProperty_tag1.TabIndex = 20;
            this.roomProperty_tag1.SelectedIndexChanged += new System.EventHandler(this.roomProperty_bg2_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Tag 1 :";
            // 
            // roomProperty_effect
            // 
            this.roomProperty_effect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomProperty_effect.FormattingEnabled = true;
            this.roomProperty_effect.Location = new System.Drawing.Point(142, 71);
            this.roomProperty_effect.Name = "roomProperty_effect";
            this.roomProperty_effect.Size = new System.Drawing.Size(124, 21);
            this.roomProperty_effect.TabIndex = 18;
            this.roomProperty_effect.SelectedIndexChanged += new System.EventHandler(this.roomProperty_bg2_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(139, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Effect :";
            // 
            // roomProperty_spriteset
            // 
            this.roomProperty_spriteset.Location = new System.Drawing.Point(74, 71);
            this.roomProperty_spriteset.Name = "roomProperty_spriteset";
            this.roomProperty_spriteset.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_spriteset.TabIndex = 16;
            this.roomProperty_spriteset.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(71, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Spr. Set :";
            // 
            // roomProperty_layout
            // 
            this.roomProperty_layout.Location = new System.Drawing.Point(8, 71);
            this.roomProperty_layout.Name = "roomProperty_layout";
            this.roomProperty_layout.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_layout.TabIndex = 14;
            this.roomProperty_layout.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Layout :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(203, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Palette :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Blockset :";
            // 
            // roomProperty_palette
            // 
            this.roomProperty_palette.Location = new System.Drawing.Point(206, 110);
            this.roomProperty_palette.Name = "roomProperty_palette";
            this.roomProperty_palette.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_palette.TabIndex = 10;
            this.roomProperty_palette.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // roomProperty_blockset
            // 
            this.roomProperty_blockset.Location = new System.Drawing.Point(140, 110);
            this.roomProperty_blockset.Name = "roomProperty_blockset";
            this.roomProperty_blockset.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_blockset.TabIndex = 9;
            this.roomProperty_blockset.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // roomProperty_floor2
            // 
            this.roomProperty_floor2.Location = new System.Drawing.Point(74, 110);
            this.roomProperty_floor2.Name = "roomProperty_floor2";
            this.roomProperty_floor2.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_floor2.TabIndex = 8;
            this.roomProperty_floor2.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // roomProperty_floor1
            // 
            this.roomProperty_floor1.Location = new System.Drawing.Point(8, 110);
            this.roomProperty_floor1.Name = "roomProperty_floor1";
            this.roomProperty_floor1.Size = new System.Drawing.Size(60, 20);
            this.roomProperty_floor1.TabIndex = 7;
            this.roomProperty_floor1.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Floor 2 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Floor 1 :";
            // 
            // roomProperty_collision
            // 
            this.roomProperty_collision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomProperty_collision.FormattingEnabled = true;
            this.roomProperty_collision.Location = new System.Drawing.Point(142, 31);
            this.roomProperty_collision.Name = "roomProperty_collision";
            this.roomProperty_collision.Size = new System.Drawing.Size(124, 21);
            this.roomProperty_collision.TabIndex = 4;
            this.roomProperty_collision.SelectedIndexChanged += new System.EventHandler(this.roomProperty_bg2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Collision :";
            // 
            // roomProperty_bg2
            // 
            this.roomProperty_bg2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomProperty_bg2.FormattingEnabled = true;
            this.roomProperty_bg2.Location = new System.Drawing.Point(8, 31);
            this.roomProperty_bg2.Name = "roomProperty_bg2";
            this.roomProperty_bg2.Size = new System.Drawing.Size(124, 21);
            this.roomProperty_bg2.TabIndex = 2;
            this.roomProperty_bg2.SelectedIndexChanged += new System.EventHandler(this.roomProperty_bg2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Background 2 Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Room Header : ";
            // 
            // entrancetabPage
            // 
            this.entrancetabPage.Controls.Add(this.splitContainer3);
            this.entrancetabPage.Controls.Add(this.groupBox2);
            this.entrancetabPage.Location = new System.Drawing.Point(4, 40);
            this.entrancetabPage.Name = "entrancetabPage";
            this.entrancetabPage.Size = new System.Drawing.Size(292, 548);
            this.entrancetabPage.TabIndex = 5;
            this.entrancetabPage.Text = "Entrances";
            this.entrancetabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.entrancetreeView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.label52);
            this.splitContainer3.Panel2.Controls.Add(this.label53);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_FR);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_HR);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_FL);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_HL);
            this.splitContainer3.Panel2.Controls.Add(this.label54);
            this.splitContainer3.Panel2.Controls.Add(this.label55);
            this.splitContainer3.Panel2.Controls.Add(this.label7);
            this.splitContainer3.Panel2.Controls.Add(this.label49);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_FD);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_HD);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_FU);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_HU);
            this.splitContainer3.Panel2.Controls.Add(this.label50);
            this.splitContainer3.Panel2.Controls.Add(this.label51);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_bg);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_quadbr);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_quadtr);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_quadbl);
            this.splitContainer3.Panel2.Controls.Add(this.label42);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_quadtl);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_vscroll);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_hscroll);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_scrolly);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_scrollx);
            this.splitContainer3.Panel2.Controls.Add(this.label43);
            this.splitContainer3.Panel2.Controls.Add(this.label44);
            this.splitContainer3.Panel2.Controls.Add(this.label45);
            this.splitContainer3.Panel2.Controls.Add(this.label46);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_camy);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_camx);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_ypos);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_xpos);
            this.splitContainer3.Panel2.Controls.Add(this.label47);
            this.splitContainer3.Panel2.Controls.Add(this.label48);
            this.splitContainer3.Panel2.Controls.Add(this.label38);
            this.splitContainer3.Panel2.Controls.Add(this.label39);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_exit);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_blockset);
            this.splitContainer3.Panel2.Controls.Add(this.label40);
            this.splitContainer3.Panel2.Controls.Add(this.label24);
            this.splitContainer3.Panel2.Controls.Add(this.label22);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_music);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_dungeon);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_floor);
            this.splitContainer3.Panel2.Controls.Add(this.entranceProperty_room);
            this.splitContainer3.Panel2.Controls.Add(this.label21);
            this.splitContainer3.Panel2.Controls.Add(this.label19);
            this.splitContainer3.Panel2.Controls.Add(this.label18);
            this.splitContainer3.Size = new System.Drawing.Size(292, 505);
            this.splitContainer3.SplitterDistance = 166;
            this.splitContainer3.TabIndex = 9;
            // 
            // entrancetreeView
            // 
            this.entrancetreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entrancetreeView.HideSelection = false;
            this.entrancetreeView.Location = new System.Drawing.Point(0, 0);
            this.entrancetreeView.Name = "entrancetreeView";
            treeNode1.Name = "EntranceNode";
            treeNode1.Text = "Entrances";
            treeNode2.Name = "StartingEntranceNode";
            treeNode2.Text = "Starting Entrances";
            this.entrancetreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.entrancetreeView.Size = new System.Drawing.Size(292, 166);
            this.entrancetreeView.TabIndex = 0;
            this.entrancetreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entrancetreeView_AfterSelect);
            this.entrancetreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.entrancetreeView_NodeMouseDoubleClick);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(206, 280);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(49, 13);
            this.label52.TabIndex = 57;
            this.label52.Text = "Edge FR";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(137, 280);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(51, 13);
            this.label53.TabIndex = 56;
            this.label53.Text = "Edge HR";
            // 
            // entranceProperty_FR
            // 
            this.entranceProperty_FR.Location = new System.Drawing.Point(206, 296);
            this.entranceProperty_FR.Name = "entranceProperty_FR";
            this.entranceProperty_FR.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_FR.TabIndex = 55;
            this.entranceProperty_FR.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_HR
            // 
            this.entranceProperty_HR.Location = new System.Drawing.Point(140, 296);
            this.entranceProperty_HR.Name = "entranceProperty_HR";
            this.entranceProperty_HR.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_HR.TabIndex = 54;
            this.entranceProperty_HR.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_FL
            // 
            this.entranceProperty_FL.Location = new System.Drawing.Point(74, 296);
            this.entranceProperty_FL.Name = "entranceProperty_FL";
            this.entranceProperty_FL.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_FL.TabIndex = 53;
            this.entranceProperty_FL.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_HL
            // 
            this.entranceProperty_HL.Location = new System.Drawing.Point(8, 296);
            this.entranceProperty_HL.Name = "entranceProperty_HL";
            this.entranceProperty_HL.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_HL.TabIndex = 52;
            this.entranceProperty_HL.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(71, 280);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(47, 13);
            this.label54.TabIndex = 51;
            this.label54.Text = "Edge FL";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(5, 280);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(49, 13);
            this.label55.TabIndex = 50;
            this.label55.Text = "Edge HL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Edge FD";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(137, 241);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(51, 13);
            this.label49.TabIndex = 48;
            this.label49.Text = "Edge HD";
            // 
            // entranceProperty_FD
            // 
            this.entranceProperty_FD.Location = new System.Drawing.Point(206, 257);
            this.entranceProperty_FD.Name = "entranceProperty_FD";
            this.entranceProperty_FD.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_FD.TabIndex = 47;
            this.entranceProperty_FD.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_HD
            // 
            this.entranceProperty_HD.Location = new System.Drawing.Point(140, 257);
            this.entranceProperty_HD.Name = "entranceProperty_HD";
            this.entranceProperty_HD.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_HD.TabIndex = 46;
            this.entranceProperty_HD.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_FU
            // 
            this.entranceProperty_FU.Location = new System.Drawing.Point(74, 257);
            this.entranceProperty_FU.Name = "entranceProperty_FU";
            this.entranceProperty_FU.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_FU.TabIndex = 45;
            this.entranceProperty_FU.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_HU
            // 
            this.entranceProperty_HU.Location = new System.Drawing.Point(8, 257);
            this.entranceProperty_HU.Name = "entranceProperty_HU";
            this.entranceProperty_HU.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_HU.TabIndex = 44;
            this.entranceProperty_HU.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(71, 241);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(49, 13);
            this.label50.TabIndex = 43;
            this.label50.Text = "Edge FU";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(5, 241);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(51, 13);
            this.label51.TabIndex = 42;
            this.label51.Text = "Edge HU";
            // 
            // entranceProperty_bg
            // 
            this.entranceProperty_bg.AutoSize = true;
            this.entranceProperty_bg.Location = new System.Drawing.Point(138, 74);
            this.entranceProperty_bg.Name = "entranceProperty_bg";
            this.entranceProperty_bg.Size = new System.Drawing.Size(47, 17);
            this.entranceProperty_bg.TabIndex = 41;
            this.entranceProperty_bg.Text = "BG2";
            this.entranceProperty_bg.UseVisualStyleBackColor = true;
            this.entranceProperty_bg.CheckedChanged += new System.EventHandler(this.entranceProperty_vscroll_CheckedChanged);
            // 
            // entranceProperty_quadbr
            // 
            this.entranceProperty_quadbr.AutoSize = true;
            this.entranceProperty_quadbr.Location = new System.Drawing.Point(91, 221);
            this.entranceProperty_quadbr.Name = "entranceProperty_quadbr";
            this.entranceProperty_quadbr.Size = new System.Drawing.Size(86, 17);
            this.entranceProperty_quadbr.TabIndex = 40;
            this.entranceProperty_quadbr.TabStop = true;
            this.entranceProperty_quadbr.Text = "Bottom Right";
            this.entranceProperty_quadbr.UseVisualStyleBackColor = true;
            this.entranceProperty_quadbr.CheckedChanged += new System.EventHandler(this.entranceProperty_quadtl_CheckedChanged);
            // 
            // entranceProperty_quadtr
            // 
            this.entranceProperty_quadtr.AutoSize = true;
            this.entranceProperty_quadtr.Location = new System.Drawing.Point(91, 201);
            this.entranceProperty_quadtr.Name = "entranceProperty_quadtr";
            this.entranceProperty_quadtr.Size = new System.Drawing.Size(72, 17);
            this.entranceProperty_quadtr.TabIndex = 39;
            this.entranceProperty_quadtr.TabStop = true;
            this.entranceProperty_quadtr.Text = "Top Right";
            this.entranceProperty_quadtr.UseVisualStyleBackColor = true;
            this.entranceProperty_quadtr.CheckedChanged += new System.EventHandler(this.entranceProperty_quadtl_CheckedChanged);
            // 
            // entranceProperty_quadbl
            // 
            this.entranceProperty_quadbl.AutoSize = true;
            this.entranceProperty_quadbl.Location = new System.Drawing.Point(6, 221);
            this.entranceProperty_quadbl.Name = "entranceProperty_quadbl";
            this.entranceProperty_quadbl.Size = new System.Drawing.Size(79, 17);
            this.entranceProperty_quadbl.TabIndex = 38;
            this.entranceProperty_quadbl.TabStop = true;
            this.entranceProperty_quadbl.Text = "Bottom Left";
            this.entranceProperty_quadbl.UseVisualStyleBackColor = true;
            this.entranceProperty_quadbl.CheckedChanged += new System.EventHandler(this.entranceProperty_quadtl_CheckedChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(3, 185);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(57, 13);
            this.label42.TabIndex = 37;
            this.label42.Text = "Quadrant :";
            // 
            // entranceProperty_quadtl
            // 
            this.entranceProperty_quadtl.AutoSize = true;
            this.entranceProperty_quadtl.Location = new System.Drawing.Point(6, 201);
            this.entranceProperty_quadtl.Name = "entranceProperty_quadtl";
            this.entranceProperty_quadtl.Size = new System.Drawing.Size(65, 17);
            this.entranceProperty_quadtl.TabIndex = 36;
            this.entranceProperty_quadtl.TabStop = true;
            this.entranceProperty_quadtl.Text = "Top Left";
            this.entranceProperty_quadtl.UseVisualStyleBackColor = true;
            this.entranceProperty_quadtl.CheckedChanged += new System.EventHandler(this.entranceProperty_quadtl_CheckedChanged);
            // 
            // entranceProperty_vscroll
            // 
            this.entranceProperty_vscroll.AutoSize = true;
            this.entranceProperty_vscroll.Location = new System.Drawing.Point(210, 164);
            this.entranceProperty_vscroll.Name = "entranceProperty_vscroll";
            this.entranceProperty_vscroll.Size = new System.Drawing.Size(65, 17);
            this.entranceProperty_vscroll.TabIndex = 35;
            this.entranceProperty_vscroll.Text = "V. Scroll";
            this.entranceProperty_vscroll.UseVisualStyleBackColor = true;
            this.entranceProperty_vscroll.CheckedChanged += new System.EventHandler(this.entranceProperty_vscroll_CheckedChanged);
            // 
            // entranceProperty_hscroll
            // 
            this.entranceProperty_hscroll.AutoSize = true;
            this.entranceProperty_hscroll.Location = new System.Drawing.Point(138, 164);
            this.entranceProperty_hscroll.Name = "entranceProperty_hscroll";
            this.entranceProperty_hscroll.Size = new System.Drawing.Size(66, 17);
            this.entranceProperty_hscroll.TabIndex = 34;
            this.entranceProperty_hscroll.Text = "H. Scroll";
            this.entranceProperty_hscroll.UseVisualStyleBackColor = true;
            this.entranceProperty_hscroll.CheckedChanged += new System.EventHandler(this.entranceProperty_vscroll_CheckedChanged);
            // 
            // entranceProperty_scrolly
            // 
            this.entranceProperty_scrolly.Location = new System.Drawing.Point(6, 162);
            this.entranceProperty_scrolly.Name = "entranceProperty_scrolly";
            this.entranceProperty_scrolly.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_scrolly.TabIndex = 33;
            this.entranceProperty_scrolly.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_scrollx
            // 
            this.entranceProperty_scrollx.Location = new System.Drawing.Point(72, 162);
            this.entranceProperty_scrollx.Name = "entranceProperty_scrollx";
            this.entranceProperty_scrollx.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_scrollx.TabIndex = 32;
            this.entranceProperty_scrollx.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(69, 146);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(49, 13);
            this.label43.TabIndex = 31;
            this.label43.Text = "Scroll Y :";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(3, 146);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(49, 13);
            this.label44.TabIndex = 30;
            this.label44.Text = "Scroll X :";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(204, 107);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(59, 13);
            this.label45.TabIndex = 29;
            this.label45.Text = "Camera Y :";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(135, 107);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 13);
            this.label46.TabIndex = 28;
            this.label46.Text = "Camera X :";
            // 
            // entranceProperty_camy
            // 
            this.entranceProperty_camy.Location = new System.Drawing.Point(204, 123);
            this.entranceProperty_camy.Name = "entranceProperty_camy";
            this.entranceProperty_camy.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_camy.TabIndex = 27;
            this.entranceProperty_camy.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_camx
            // 
            this.entranceProperty_camx.Location = new System.Drawing.Point(138, 123);
            this.entranceProperty_camx.Name = "entranceProperty_camx";
            this.entranceProperty_camx.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_camx.TabIndex = 26;
            this.entranceProperty_camx.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_ypos
            // 
            this.entranceProperty_ypos.Location = new System.Drawing.Point(72, 123);
            this.entranceProperty_ypos.Name = "entranceProperty_ypos";
            this.entranceProperty_ypos.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_ypos.TabIndex = 25;
            this.entranceProperty_ypos.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_xpos
            // 
            this.entranceProperty_xpos.Location = new System.Drawing.Point(6, 123);
            this.entranceProperty_xpos.Name = "entranceProperty_xpos";
            this.entranceProperty_xpos.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_xpos.TabIndex = 24;
            this.entranceProperty_xpos.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(69, 107);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(52, 13);
            this.label47.TabIndex = 23;
            this.label47.Text = "Player Y :";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(3, 107);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(52, 13);
            this.label48.TabIndex = 22;
            this.label48.Text = "Player X :";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(3, 94);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(270, 13);
            this.label38.TabIndex = 21;
            this.label38.Text = "Selected Entrance Position/Camera Properties";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(69, 55);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(36, 13);
            this.label39.TabIndex = 20;
            this.label39.Text = "Exit? :";
            // 
            // entranceProperty_exit
            // 
            this.entranceProperty_exit.Location = new System.Drawing.Point(72, 71);
            this.entranceProperty_exit.Name = "entranceProperty_exit";
            this.entranceProperty_exit.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_exit.TabIndex = 18;
            this.entranceProperty_exit.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_blockset
            // 
            this.entranceProperty_blockset.Location = new System.Drawing.Point(6, 71);
            this.entranceProperty_blockset.Name = "entranceProperty_blockset";
            this.entranceProperty_blockset.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_blockset.TabIndex = 17;
            this.entranceProperty_blockset.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(3, 55);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(54, 13);
            this.label40.TabIndex = 15;
            this.label40.Text = "Blockset :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(204, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 13;
            this.label24.Text = "Music :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(135, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "Dungeon :";
            // 
            // entranceProperty_music
            // 
            this.entranceProperty_music.Location = new System.Drawing.Point(204, 32);
            this.entranceProperty_music.Name = "entranceProperty_music";
            this.entranceProperty_music.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_music.TabIndex = 11;
            this.entranceProperty_music.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_dungeon
            // 
            this.entranceProperty_dungeon.Location = new System.Drawing.Point(138, 32);
            this.entranceProperty_dungeon.Name = "entranceProperty_dungeon";
            this.entranceProperty_dungeon.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_dungeon.TabIndex = 10;
            this.entranceProperty_dungeon.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_floor
            // 
            this.entranceProperty_floor.Location = new System.Drawing.Point(72, 32);
            this.entranceProperty_floor.Name = "entranceProperty_floor";
            this.entranceProperty_floor.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_floor.TabIndex = 9;
            this.entranceProperty_floor.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_room
            // 
            this.entranceProperty_room.Location = new System.Drawing.Point(6, 32);
            this.entranceProperty_room.Name = "entranceProperty_room";
            this.entranceProperty_room.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_room.TabIndex = 8;
            this.entranceProperty_room.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(69, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(36, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Floor :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Room Id :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(3, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(173, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Selected Entrance Properties";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cameraboxCheckbox);
            this.groupBox2.Controls.Add(this.entranceposCheckbox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 505);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 43);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Settings";
            // 
            // cameraboxCheckbox
            // 
            this.cameraboxCheckbox.AutoSize = true;
            this.cameraboxCheckbox.Checked = true;
            this.cameraboxCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cameraboxCheckbox.Location = new System.Drawing.Point(6, 19);
            this.cameraboxCheckbox.Name = "cameraboxCheckbox";
            this.cameraboxCheckbox.Size = new System.Drawing.Size(113, 17);
            this.cameraboxCheckbox.TabIndex = 23;
            this.cameraboxCheckbox.Text = "Show Camera Box";
            this.cameraboxCheckbox.UseVisualStyleBackColor = true;
            // 
            // entranceposCheckbox
            // 
            this.entranceposCheckbox.AutoSize = true;
            this.entranceposCheckbox.Checked = true;
            this.entranceposCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entranceposCheckbox.Location = new System.Drawing.Point(125, 19);
            this.entranceposCheckbox.Name = "entranceposCheckbox";
            this.entranceposCheckbox.Size = new System.Drawing.Size(139, 17);
            this.entranceposCheckbox.TabIndex = 2;
            this.entranceposCheckbox.Text = "Show Entrance Position";
            this.entranceposCheckbox.UseVisualStyleBackColor = true;
            // 
            // objectstabPage
            // 
            this.objectstabPage.Controls.Add(this.panel1);
            this.objectstabPage.Controls.Add(this.showNameObjectCheckbox);
            this.objectstabPage.Controls.Add(this.searchTextbox);
            this.objectstabPage.Location = new System.Drawing.Point(4, 40);
            this.objectstabPage.Name = "objectstabPage";
            this.objectstabPage.Size = new System.Drawing.Size(292, 548);
            this.objectstabPage.TabIndex = 4;
            this.objectstabPage.Text = "Objects";
            this.objectstabPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.objectViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 511);
            this.panel1.TabIndex = 1;
            // 
            // objectViewer1
            // 
            this.objectViewer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.objectViewer1.Location = new System.Drawing.Point(0, 0);
            this.objectViewer1.MinimumSize = new System.Drawing.Size(0, 180);
            this.objectViewer1.Name = "objectViewer1";
            this.objectViewer1.Size = new System.Drawing.Size(292, 380);
            this.objectViewer1.TabIndex = 0;
            this.objectViewer1.SelectedIndexChanged += new System.EventHandler(this.objectViewer1_SelectedIndexChanged);
            this.objectViewer1.Load += new System.EventHandler(this.objectViewer1_Load);
            // 
            // showNameObjectCheckbox
            // 
            this.showNameObjectCheckbox.AutoSize = true;
            this.showNameObjectCheckbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.showNameObjectCheckbox.Location = new System.Drawing.Point(0, 20);
            this.showNameObjectCheckbox.Name = "showNameObjectCheckbox";
            this.showNameObjectCheckbox.Size = new System.Drawing.Size(292, 17);
            this.showNameObjectCheckbox.TabIndex = 1;
            this.showNameObjectCheckbox.Text = "Show Names";
            this.showNameObjectCheckbox.UseVisualStyleBackColor = true;
            this.showNameObjectCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // searchTextbox
            // 
            this.searchTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchTextbox.Location = new System.Drawing.Point(0, 0);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(292, 20);
            this.searchTextbox.TabIndex = 0;
            this.searchTextbox.TextChanged += new System.EventHandler(this.searchTextbox_TextChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.customPanel1);
            this.tabPage4.Controls.Add(this.searchspriteTextbox);
            this.tabPage4.Location = new System.Drawing.Point(4, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(292, 548);
            this.tabPage4.TabIndex = 10;
            this.tabPage4.Text = "Sprites";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // customPanel1
            // 
            this.customPanel1.AutoScroll = true;
            this.customPanel1.Controls.Add(this.spritesView1);
            this.customPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel1.Location = new System.Drawing.Point(0, 20);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(292, 528);
            this.customPanel1.TabIndex = 2;
            // 
            // spritesView1
            // 
            this.spritesView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.spritesView1.Location = new System.Drawing.Point(0, 0);
            this.spritesView1.Name = "spritesView1";
            this.spritesView1.Size = new System.Drawing.Size(292, 374);
            this.spritesView1.TabIndex = 0;
            this.spritesView1.SelectedIndexChanged += new System.EventHandler(this.spritesView1_SelectedIndexChanged);
            this.spritesView1.Load += new System.EventHandler(this.spritesView1_Load);
            // 
            // searchspriteTextbox
            // 
            this.searchspriteTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchspriteTextbox.Location = new System.Drawing.Point(0, 0);
            this.searchspriteTextbox.Name = "searchspriteTextbox";
            this.searchspriteTextbox.Size = new System.Drawing.Size(292, 20);
            this.searchspriteTextbox.TabIndex = 1;
            this.searchspriteTextbox.TextChanged += new System.EventHandler(this.searchspriteTextbox_TextChanged);
            // 
            // palettestabPage
            // 
            this.palettestabPage.Controls.Add(this.splitContainer6);
            this.palettestabPage.Location = new System.Drawing.Point(4, 40);
            this.palettestabPage.Name = "palettestabPage";
            this.palettestabPage.Size = new System.Drawing.Size(292, 548);
            this.palettestabPage.TabIndex = 3;
            this.palettestabPage.Text = "Palettes";
            this.palettestabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.button2);
            this.splitContainer6.Panel1.Controls.Add(this.palettesTreeview);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.palettePicturebox);
            this.splitContainer6.Size = new System.Drawing.Size(292, 548);
            this.splitContainer6.SplitterDistance = 295;
            this.splitContainer6.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 270);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(286, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save Current Palette to YY-CHR Palettes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // palettesTreeview
            // 
            this.palettesTreeview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palettesTreeview.Enabled = false;
            this.palettesTreeview.Location = new System.Drawing.Point(0, 0);
            this.palettesTreeview.Name = "palettesTreeview";
            treeNode3.Name = "MainRoomPalette";
            treeNode3.Tag = "Main";
            treeNode3.Text = "Main Dungeon Palette";
            treeNode4.Name = "currentSpritePalette";
            treeNode4.Tag = "Sprite";
            treeNode4.Text = "Sprite Palettes";
            treeNode5.Name = "currentRoom";
            treeNode5.Text = "Current Room";
            treeNode5.ToolTipText = "Currently Used Palettes";
            treeNode6.Name = "Node6";
            treeNode6.Text = "Dungeon Palettes";
            treeNode7.Name = "SwordPalettes";
            treeNode7.Text = "Sword Palettes";
            treeNode8.Name = "ShieldPalettes";
            treeNode8.Text = "Shield Palettes";
            treeNode9.Name = "ArmorPalettes";
            treeNode9.Text = "Armor Palettes";
            treeNode9.ToolTipText = "Mail Palettes - Usually setted by the sprite file if used";
            treeNode10.Name = "StaticSpritePalette";
            treeNode10.Text = "Static Sprite Palettes";
            treeNode10.ToolTipText = "Sprite Palettes always loaded everywhere depends on the world you are in";
            treeNode11.Name = "DynamicSpritePalette";
            treeNode11.Text = "Dynamic Sprite Palette";
            treeNode12.Name = "OverworldPalettes";
            treeNode12.Text = "Overworld Main Palettes";
            treeNode13.Name = "OverworldAuxPalettes";
            treeNode13.Text = "Overworld Aux Palettes";
            treeNode14.Name = "OverworldAnimatedPalettes";
            treeNode14.Text = "Overworld Animated Palettes";
            treeNode15.Name = "OverworldMapPalettes";
            treeNode15.Text = "Overworld Map Palettes";
            treeNode16.Name = "DungeonMap";
            treeNode16.Text = "Dungeon Map Palettes";
            treeNode17.Name = "HudPalettes";
            treeNode17.Text = "Hud Palettes";
            treeNode18.Name = "CrystalPalettes";
            treeNode18.Text = "Crystal Palettes";
            treeNode19.Name = "TriforcePalette";
            treeNode19.Text = "Triforce Palette";
            treeNode20.Name = "allPalettes";
            treeNode20.Text = "All Palettes";
            this.palettesTreeview.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode20});
            this.palettesTreeview.Size = new System.Drawing.Size(292, 295);
            this.palettesTreeview.TabIndex = 0;
            // 
            // palettePicturebox
            // 
            this.palettePicturebox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.palettePicturebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palettePicturebox.Location = new System.Drawing.Point(0, 0);
            this.palettePicturebox.Name = "palettePicturebox";
            this.palettePicturebox.Size = new System.Drawing.Size(292, 249);
            this.palettePicturebox.TabIndex = 0;
            this.palettePicturebox.TabStop = false;
            this.palettePicturebox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseDoubleClick);
            this.palettePicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseDown);
            this.palettePicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseUp);
            // 
            // gfxtabPage
            // 
            this.gfxtabPage.AutoScroll = true;
            this.gfxtabPage.Controls.Add(this.customPanel2);
            this.gfxtabPage.Controls.Add(this.groupBox3);
            this.gfxtabPage.Location = new System.Drawing.Point(4, 40);
            this.gfxtabPage.Name = "gfxtabPage";
            this.gfxtabPage.Size = new System.Drawing.Size(292, 548);
            this.gfxtabPage.TabIndex = 6;
            this.gfxtabPage.Text = "Gfx";
            this.gfxtabPage.UseVisualStyleBackColor = true;
            // 
            // customPanel2
            // 
            this.customPanel2.AutoScroll = true;
            this.customPanel2.Controls.Add(this.gfxPicturebox);
            this.customPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel2.Location = new System.Drawing.Point(0, 167);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(292, 381);
            this.customPanel2.TabIndex = 14;
            // 
            // gfxPicturebox
            // 
            this.gfxPicturebox.Dock = System.Windows.Forms.DockStyle.Top;
            this.gfxPicturebox.Location = new System.Drawing.Point(0, 0);
            this.gfxPicturebox.Name = "gfxPicturebox";
            this.gfxPicturebox.Size = new System.Drawing.Size(275, 1024);
            this.gfxPicturebox.TabIndex = 12;
            this.gfxPicturebox.TabStop = false;
            this.gfxPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.gfxPicturebox_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label41);
            this.groupBox3.Controls.Add(this.previewPaletteGfxTextbox);
            this.groupBox3.Controls.Add(this.gfx8textBox);
            this.groupBox3.Controls.Add(this.gfx7textBox);
            this.groupBox3.Controls.Add(this.gfx6textBox);
            this.groupBox3.Controls.Add(this.gfx5textBox);
            this.groupBox3.Controls.Add(this.gfx4textBox);
            this.groupBox3.Controls.Add(this.gfx3textBox);
            this.groupBox3.Controls.Add(this.gfx2textBox);
            this.groupBox3.Controls.Add(this.gfx1textBox);
            this.groupBox3.Controls.Add(this.gfxgroupindexUpDown);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.gfxfromroomButton);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.gfxgroupCombobox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(292, 167);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gfx Groups - Note : Saved on change";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(3, 148);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(87, 13);
            this.label41.TabIndex = 18;
            this.label41.Text = "Preview Palette :";
            // 
            // previewPaletteGfxTextbox
            // 
            this.previewPaletteGfxTextbox.Location = new System.Drawing.Point(96, 145);
            this.previewPaletteGfxTextbox.Name = "previewPaletteGfxTextbox";
            this.previewPaletteGfxTextbox.Size = new System.Drawing.Size(168, 20);
            this.previewPaletteGfxTextbox.TabIndex = 17;
            this.previewPaletteGfxTextbox.TextChanged += new System.EventHandler(this.previewPaletteGfxTextbox_TextChanged);
            // 
            // gfx8textBox
            // 
            this.gfx8textBox.Location = new System.Drawing.Point(174, 89);
            this.gfx8textBox.Name = "gfx8textBox";
            this.gfx8textBox.Size = new System.Drawing.Size(50, 20);
            this.gfx8textBox.TabIndex = 16;
            this.gfx8textBox.TextChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx7textBox
            // 
            this.gfx7textBox.Location = new System.Drawing.Point(118, 89);
            this.gfx7textBox.Name = "gfx7textBox";
            this.gfx7textBox.Size = new System.Drawing.Size(50, 20);
            this.gfx7textBox.TabIndex = 15;
            this.gfx7textBox.TextChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx6textBox
            // 
            this.gfx6textBox.Location = new System.Drawing.Point(62, 89);
            this.gfx6textBox.Name = "gfx6textBox";
            this.gfx6textBox.Size = new System.Drawing.Size(50, 20);
            this.gfx6textBox.TabIndex = 14;
            this.gfx6textBox.TextChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx5textBox
            // 
            this.gfx5textBox.Location = new System.Drawing.Point(6, 89);
            this.gfx5textBox.Name = "gfx5textBox";
            this.gfx5textBox.Size = new System.Drawing.Size(50, 20);
            this.gfx5textBox.TabIndex = 13;
            this.gfx5textBox.TextChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx4textBox
            // 
            this.gfx4textBox.Location = new System.Drawing.Point(174, 63);
            this.gfx4textBox.Name = "gfx4textBox";
            this.gfx4textBox.Size = new System.Drawing.Size(50, 20);
            this.gfx4textBox.TabIndex = 12;
            this.gfx4textBox.TextChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx3textBox
            // 
            this.gfx3textBox.Location = new System.Drawing.Point(118, 63);
            this.gfx3textBox.Name = "gfx3textBox";
            this.gfx3textBox.Size = new System.Drawing.Size(50, 20);
            this.gfx3textBox.TabIndex = 11;
            this.gfx3textBox.TextChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx2textBox
            // 
            this.gfx2textBox.Location = new System.Drawing.Point(62, 63);
            this.gfx2textBox.Name = "gfx2textBox";
            this.gfx2textBox.Size = new System.Drawing.Size(50, 20);
            this.gfx2textBox.TabIndex = 10;
            this.gfx2textBox.TextChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx1textBox
            // 
            this.gfx1textBox.Location = new System.Drawing.Point(6, 63);
            this.gfx1textBox.Name = "gfx1textBox";
            this.gfx1textBox.Size = new System.Drawing.Size(50, 20);
            this.gfx1textBox.TabIndex = 9;
            this.gfx1textBox.TextChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfxgroupindexUpDown
            // 
            this.gfxgroupindexUpDown.Location = new System.Drawing.Point(120, 36);
            this.gfxgroupindexUpDown.Maximum = new decimal(new int[] {
            223,
            0,
            0,
            0});
            this.gfxgroupindexUpDown.Name = "gfxgroupindexUpDown";
            this.gfxgroupindexUpDown.Size = new System.Drawing.Size(104, 20);
            this.gfxgroupindexUpDown.TabIndex = 8;
            this.gfxgroupindexUpDown.ValueChanged += new System.EventHandler(this.gfxgroupindexUpDown_ValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(117, 20);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(39, 13);
            this.label32.TabIndex = 7;
            this.label32.Text = "Index :";
            // 
            // gfxfromroomButton
            // 
            this.gfxfromroomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gfxfromroomButton.Location = new System.Drawing.Point(6, 116);
            this.gfxfromroomButton.Name = "gfxfromroomButton";
            this.gfxfromroomButton.Size = new System.Drawing.Size(275, 23);
            this.gfxfromroomButton.TabIndex = 6;
            this.gfxfromroomButton.Text = "Load Index from selected room";
            this.gfxfromroomButton.UseVisualStyleBackColor = true;
            this.gfxfromroomButton.Click += new System.EventHandler(this.gfxfromroomButton_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 20);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(40, 13);
            this.label29.TabIndex = 1;
            this.label29.Text = "Type : ";
            // 
            // gfxgroupCombobox
            // 
            this.gfxgroupCombobox.FormattingEnabled = true;
            this.gfxgroupCombobox.Items.AddRange(new object[] {
            "Main Blockset",
            "Entrance Blockset",
            "Sprite Blockset",
            "Palettes"});
            this.gfxgroupCombobox.Location = new System.Drawing.Point(6, 36);
            this.gfxgroupCombobox.Name = "gfxgroupCombobox";
            this.gfxgroupCombobox.Size = new System.Drawing.Size(108, 21);
            this.gfxgroupCombobox.TabIndex = 0;
            this.gfxgroupCombobox.Text = "Main Blockset";
            this.gfxgroupCombobox.SelectedIndexChanged += new System.EventHandler(this.gfxgroupCombobox_SelectedIndexChanged);
            // 
            // debugtabPage
            // 
            this.debugtabPage.Controls.Add(this.groupBox1);
            this.debugtabPage.Location = new System.Drawing.Point(4, 40);
            this.debugtabPage.Name = "debugtabPage";
            this.debugtabPage.Size = new System.Drawing.Size(292, 548);
            this.debugtabPage.TabIndex = 11;
            this.debugtabPage.Text = "Debug";
            this.debugtabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 548);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Currently Loaded GFX";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(286, 480);
            this.panel3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 1024);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.hovergfxLabel);
            this.panel4.Controls.Add(this.previewPaletteTextbox);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(286, 49);
            this.panel4.TabIndex = 18;
            // 
            // hovergfxLabel
            // 
            this.hovergfxLabel.AutoSize = true;
            this.hovergfxLabel.Location = new System.Drawing.Point(5, 22);
            this.hovergfxLabel.Name = "hovergfxLabel";
            this.hovergfxLabel.Size = new System.Drawing.Size(77, 13);
            this.hovergfxLabel.TabIndex = 3;
            this.hovergfxLabel.Text = "Hovered Tile : ";
            this.hovergfxLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label41_MouseMove);
            // 
            // previewPaletteTextbox
            // 
            this.previewPaletteTextbox.Location = new System.Drawing.Point(101, 0);
            this.previewPaletteTextbox.Name = "previewPaletteTextbox";
            this.previewPaletteTextbox.Size = new System.Drawing.Size(100, 20);
            this.previewPaletteTextbox.TabIndex = 2;
            this.previewPaletteTextbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Preview Palette : ";
            // 
            // selectedGroupbox
            // 
            this.selectedGroupbox.BackColor = System.Drawing.SystemColors.Control;
            this.selectedGroupbox.Controls.Add(this.litCheckbox);
            this.selectedGroupbox.Controls.Add(this.object_z_label);
            this.selectedGroupbox.Controls.Add(this.spritepropertyPanel);
            this.selectedGroupbox.Controls.Add(this.object_layer_label);
            this.selectedGroupbox.Controls.Add(this.object_size_label);
            this.selectedGroupbox.Controls.Add(this.object_y_label);
            this.selectedGroupbox.Controls.Add(this.object_x_label);
            this.selectedGroupbox.Controls.Add(this.doorselectPanel);
            this.selectedGroupbox.Controls.Add(this.potitemobjectPanel);
            this.selectedGroupbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectedGroupbox.Location = new System.Drawing.Point(300, 49);
            this.selectedGroupbox.Name = "selectedGroupbox";
            this.selectedGroupbox.Size = new System.Drawing.Size(574, 69);
            this.selectedGroupbox.TabIndex = 0;
            this.selectedGroupbox.TabStop = false;
            this.selectedGroupbox.Text = "Selected Object : ";
            // 
            // litCheckbox
            // 
            this.litCheckbox.AutoSize = true;
            this.litCheckbox.Location = new System.Drawing.Point(229, 16);
            this.litCheckbox.Name = "litCheckbox";
            this.litCheckbox.Size = new System.Drawing.Size(81, 17);
            this.litCheckbox.TabIndex = 19;
            this.litCheckbox.Text = "Already Lit?";
            this.litCheckbox.UseVisualStyleBackColor = true;
            this.litCheckbox.Visible = false;
            this.litCheckbox.CheckedChanged += new System.EventHandler(this.litCheckbox_CheckedChanged);
            // 
            // object_z_label
            // 
            this.object_z_label.AutoSize = true;
            this.object_z_label.Location = new System.Drawing.Point(128, 35);
            this.object_z_label.Name = "object_z_label";
            this.object_z_label.Size = new System.Drawing.Size(49, 13);
            this.object_z_label.TabIndex = 10;
            this.object_z_label.Text = "Z Order :";
            // 
            // spritepropertyPanel
            // 
            this.spritepropertyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spritepropertyPanel.Controls.Add(this.spriteoverlordCheckbox);
            this.spritepropertyPanel.Controls.Add(this.label26);
            this.spritepropertyPanel.Controls.Add(this.spritesubtypeUpDown);
            this.spritepropertyPanel.Controls.Add(this.comboBox1);
            this.spritepropertyPanel.Controls.Add(this.label23);
            this.spritepropertyPanel.Location = new System.Drawing.Point(301, 16);
            this.spritepropertyPanel.Name = "spritepropertyPanel";
            this.spritepropertyPanel.Size = new System.Drawing.Size(270, 50);
            this.spritepropertyPanel.TabIndex = 12;
            this.spritepropertyPanel.Visible = false;
            // 
            // spriteoverlordCheckbox
            // 
            this.spriteoverlordCheckbox.AutoSize = true;
            this.spriteoverlordCheckbox.Location = new System.Drawing.Point(79, 28);
            this.spriteoverlordCheckbox.Name = "spriteoverlordCheckbox";
            this.spriteoverlordCheckbox.Size = new System.Drawing.Size(66, 17);
            this.spriteoverlordCheckbox.TabIndex = 16;
            this.spriteoverlordCheckbox.Text = "Overlord";
            this.spriteoverlordCheckbox.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(3, 10);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(46, 13);
            this.label26.TabIndex = 15;
            this.label26.Text = "Subtype";
            // 
            // spritesubtypeUpDown
            // 
            this.spritesubtypeUpDown.Location = new System.Drawing.Point(6, 27);
            this.spritesubtypeUpDown.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.spritesubtypeUpDown.Name = "spritesubtypeUpDown";
            this.spritesubtypeUpDown.Size = new System.Drawing.Size(57, 20);
            this.spritesubtypeUpDown.TabIndex = 14;
            this.spritesubtypeUpDown.ValueChanged += new System.EventHandler(this.spritesubtypeUpDown_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "No",
            "Small Key",
            "Big Key"});
            this.comboBox1.Location = new System.Drawing.Point(174, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(87, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "No";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(171, 10);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 13);
            this.label23.TabIndex = 9;
            this.label23.Text = "Drop Key ?";
            // 
            // object_layer_label
            // 
            this.object_layer_label.AutoSize = true;
            this.object_layer_label.Location = new System.Drawing.Point(61, 35);
            this.object_layer_label.Name = "object_layer_label";
            this.object_layer_label.Size = new System.Drawing.Size(39, 13);
            this.object_layer_label.TabIndex = 6;
            this.object_layer_label.Text = "Layer :";
            // 
            // object_size_label
            // 
            this.object_size_label.AutoSize = true;
            this.object_size_label.Location = new System.Drawing.Point(61, 21);
            this.object_size_label.Name = "object_size_label";
            this.object_size_label.Size = new System.Drawing.Size(33, 13);
            this.object_size_label.TabIndex = 5;
            this.object_size_label.Text = "Size :";
            // 
            // object_y_label
            // 
            this.object_y_label.AutoSize = true;
            this.object_y_label.Location = new System.Drawing.Point(9, 35);
            this.object_y_label.Name = "object_y_label";
            this.object_y_label.Size = new System.Drawing.Size(20, 13);
            this.object_y_label.TabIndex = 3;
            this.object_y_label.Text = "Y :";
            // 
            // object_x_label
            // 
            this.object_x_label.AutoSize = true;
            this.object_x_label.Location = new System.Drawing.Point(9, 21);
            this.object_x_label.Name = "object_x_label";
            this.object_x_label.Size = new System.Drawing.Size(20, 13);
            this.object_x_label.TabIndex = 1;
            this.object_x_label.Text = "X :";
            // 
            // doorselectPanel
            // 
            this.doorselectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doorselectPanel.Controls.Add(this.comboBox2);
            this.doorselectPanel.Controls.Add(this.label25);
            this.doorselectPanel.Location = new System.Drawing.Point(301, 16);
            this.doorselectPanel.Name = "doorselectPanel";
            this.doorselectPanel.Size = new System.Drawing.Size(270, 50);
            this.doorselectPanel.TabIndex = 18;
            this.doorselectPanel.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Normal Door 0x00",
            "Normal Layer2 0x02",
            "Normal Layer2 (2?) 0x40",
            "Locked Door 0x1C",
            "Locked Layer 2 0x26",
            "Entrance Layer 2 0x0C",
            "Shutter Door Layer 2 0x44",
            "Shutter Door (both) 0x18",
            "Shutter Door (trap bottom) 0x36",
            "Shutter Door (trap top) 0x38",
            "Big Key Door (top only) 0x1E",
            "Bomb Hole 0x2E",
            "Bomb Hole (dash) 0x28",
            "Layer2 Warp door 0x46",
            "Entrance Cave Door (bottom only) 0x0E",
            "Entrance Door (bottom only) 0x0A",
            "Explosion Wall (wrong draw) 0x30",
            "Exit Door (to combine with other door) 0x12",
            "ToBg2 Door (to combine with other door) 0x16",
            "Curtain Door 0x32"});
            this.comboBox2.Location = new System.Drawing.Point(6, 26);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(255, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(3, 8);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 13);
            this.label25.TabIndex = 9;
            this.label25.Text = "Door Type : ";
            // 
            // potitemobjectPanel
            // 
            this.potitemobjectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.potitemobjectPanel.Controls.Add(this.selecteditemobjectCombobox);
            this.potitemobjectPanel.Controls.Add(this.label31);
            this.potitemobjectPanel.Location = new System.Drawing.Point(301, 16);
            this.potitemobjectPanel.Name = "potitemobjectPanel";
            this.potitemobjectPanel.Size = new System.Drawing.Size(270, 50);
            this.potitemobjectPanel.TabIndex = 17;
            this.potitemobjectPanel.Visible = false;
            // 
            // selecteditemobjectCombobox
            // 
            this.selecteditemobjectCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selecteditemobjectCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selecteditemobjectCombobox.FormattingEnabled = true;
            this.selecteditemobjectCombobox.Items.AddRange(new object[] {
            "Nothing",
            "Rupee",
            "RockCrab",
            "Bee",
            "Random",
            "Bomb",
            "Rupee",
            "Blue Rupee",
            "Key",
            "Arrow",
            "Bomb",
            "Heart",
            "Magic",
            "Big Magic",
            "Chicken",
            "Green Soldier",
            "AliveRock?",
            "Blue Soldier",
            "Ground Bomb",
            "Heart",
            "Fairy",
            "Heart",
            "Nothing",
            "Hole",
            "Warp",
            "Staircase",
            "Bombable",
            "Switch "});
            this.selecteditemobjectCombobox.Location = new System.Drawing.Point(6, 26);
            this.selecteditemobjectCombobox.Name = "selecteditemobjectCombobox";
            this.selecteditemobjectCombobox.Size = new System.Drawing.Size(255, 21);
            this.selecteditemobjectCombobox.TabIndex = 8;
            this.selecteditemobjectCombobox.SelectedIndexChanged += new System.EventHandler(this.selecteditemobjectCombobox_SelectedIndexChanged);
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(3, 10);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(33, 13);
            this.label31.TabIndex = 9;
            this.label31.Text = "Item :";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(300, 118);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 523);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // tabControl2
            // 
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl2.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl2.ItemSize = new System.Drawing.Size(48, 18);
            this.tabControl2.Location = new System.Drawing.Point(303, 118);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(571, 22);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 17;
            this.tabControl2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl2_DrawItem);
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            this.tabControl2.SizeChanged += new System.EventHandler(this.tabControl2_SizeChanged);
            this.tabControl2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl2_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(874, 641);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.selectedGroupbox);
            this.Controls.Add(this.toolboxPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ZScream Magic - 1.1 Alpha Version";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.zscreamForm_FormClosing_1);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.nothingselectedcontextMenu.ResumeLayout(false);
            this.singleselectedcontextMenu.ResumeLayout(false);
            this.groupselectedcontextMenu.ResumeLayout(false);
            this.toolboxPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.roomtabPage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPicturebox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.entrancetabPage.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.objectstabPage.ResumeLayout(false);
            this.objectstabPage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.customPanel1.ResumeLayout(false);
            this.palettestabPage.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).EndInit();
            this.gfxtabPage.ResumeLayout(false);
            this.customPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gfxPicturebox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gfxgroupindexUpDown)).EndInit();
            this.debugtabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.selectedGroupbox.ResumeLayout(false);
            this.selectedGroupbox.PerformLayout();
            this.spritepropertyPanel.ResumeLayout(false);
            this.spritepropertyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritesubtypeUpDown)).EndInit();
            this.doorselectPanel.ResumeLayout(false);
            this.doorselectPanel.PerformLayout();
            this.potitemobjectPanel.ResumeLayout(false);
            this.potitemobjectPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ToolStripMenuItem gotoRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textChestItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textPotItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBG2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBG1ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openfileButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton blockmodeButton;
        private System.Windows.Forms.ToolStripButton torchmodeButton;
        private System.Windows.Forms.ToolStripButton chestmodeButton;
        private System.Windows.Forms.ToolStripButton potmodeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.ImageList spriteImageList;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem moveFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bringToBackToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripButton doormodeButton;
        private System.Windows.Forms.ToolStripButton saveLayoutButton;
        private System.Windows.Forms.ToolStripButton loadlayoutButton;
        private System.Windows.Forms.ToolStripMenuItem unselectedBGTransparentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem changeObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editGfxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sendToBackToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton warpmodeButton;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem sendToBg1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToBg1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sendToBg1ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sendToBg1ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem sendToBg1ToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem sendToBg1ToolStripMenuItem5;
        public System.Windows.Forms.ContextMenuStrip nothingselectedcontextMenu;
        public System.Windows.Forms.ContextMenuStrip singleselectedcontextMenu;
        public System.Windows.Forms.ContextMenuStrip groupselectedcontextMenu;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem darkThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem increaseZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem decreaseZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToBackToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem increaseZBy1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseZBy1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton debugtestButton;
        private System.Windows.Forms.ToolStripButton runtestButton;
        private System.Windows.Forms.Panel toolboxPanel;
        private System.Windows.Forms.TabPage roomtabPage;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView roomListView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TabPage entrancetabPage;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView entrancetreeView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage objectstabPage;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.TabPage palettestabPage;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.TreeView palettesTreeview;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox palettePicturebox;
        private System.Windows.Forms.TabPage gfxtabPage;
        private System.Windows.Forms.PictureBox gfxPicturebox;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox searchspriteTextbox;
        public System.Windows.Forms.GroupBox selectedGroupbox;
        public System.Windows.Forms.Panel doorselectPanel;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Panel potitemobjectPanel;
        public System.Windows.Forms.ComboBox selecteditemobjectCombobox;
        public System.Windows.Forms.Label label31;
        public System.Windows.Forms.Panel spritepropertyPanel;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.NumericUpDown spritesubtypeUpDown;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label label23;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem rightSideToolboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalOptionsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox gfxgroupCombobox;
        private System.Windows.Forms.NumericUpDown gfxgroupindexUpDown;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button gfxfromroomButton;
        public System.Windows.Forms.PictureBox mapPicturebox;
        private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hideSpritesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hideItemsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hideAllTextToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hideChestItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem selectAllMapForExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectedAllMapForExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_stair4;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button button_stair3;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button button_stair2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button button_stair1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button_holewarp;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox roomProperty_palette;
        public System.Windows.Forms.TextBox roomProperty_blockset;
        public System.Windows.Forms.TextBox roomProperty_floor2;
        public System.Windows.Forms.TextBox roomProperty_floor1;
        public System.Windows.Forms.ComboBox roomProperty_collision;
        public System.Windows.Forms.ComboBox roomProperty_bg2;
        public System.Windows.Forms.TextBox roomProperty_layout;
        public System.Windows.Forms.ComboBox roomProperty_effect;
        public System.Windows.Forms.TextBox roomProperty_spriteset;
        public System.Windows.Forms.ComboBox roomProperty_tag2;
        public System.Windows.Forms.ComboBox roomProperty_tag1;
        public System.Windows.Forms.CheckBox roomProperty_sortsprite;
        public System.Windows.Forms.TextBox roomProperty_stair4plane;
        public System.Windows.Forms.TextBox roomProperty_stair4;
        public System.Windows.Forms.TextBox roomProperty_stair3plane;
        public System.Windows.Forms.TextBox roomProperty_stair3;
        public System.Windows.Forms.TextBox roomProperty_stair2plane;
        public System.Windows.Forms.TextBox roomProperty_stair2;
        public System.Windows.Forms.TextBox roomProperty_stair1plane;
        public System.Windows.Forms.TextBox roomProperty_stair1;
        public System.Windows.Forms.TextBox roomProperty_msgid;
        public System.Windows.Forms.CheckBox roomProperty_pit;
        public System.Windows.Forms.TextBox roomProperty_holeplane;
        public System.Windows.Forms.TextBox roomProperty_hole;
        private System.Windows.Forms.ToolStripMenuItem x8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x64ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x256ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl2;
        public System.Windows.Forms.Label object_z_label;
        public System.Windows.Forms.Label object_layer_label;
        public System.Windows.Forms.Label object_size_label;
        public System.Windows.Forms.Label object_y_label;
        public System.Windows.Forms.Label object_x_label;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.TextBox entranceProperty_music;
        public System.Windows.Forms.TextBox entranceProperty_dungeon;
        public System.Windows.Forms.TextBox entranceProperty_floor;
        public System.Windows.Forms.TextBox entranceProperty_room;
        private System.Windows.Forms.RadioButton entranceProperty_quadbr;
        private System.Windows.Forms.RadioButton entranceProperty_quadtr;
        private System.Windows.Forms.RadioButton entranceProperty_quadbl;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.RadioButton entranceProperty_quadtl;
        private System.Windows.Forms.CheckBox entranceProperty_vscroll;
        private System.Windows.Forms.CheckBox entranceProperty_hscroll;
        public System.Windows.Forms.TextBox entranceProperty_scrolly;
        public System.Windows.Forms.TextBox entranceProperty_scrollx;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        public System.Windows.Forms.TextBox entranceProperty_camy;
        public System.Windows.Forms.TextBox entranceProperty_camx;
        public System.Windows.Forms.TextBox entranceProperty_ypos;
        public System.Windows.Forms.TextBox entranceProperty_xpos;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        public System.Windows.Forms.TextBox entranceProperty_exit;
        public System.Windows.Forms.TextBox entranceProperty_blockset;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.CheckBox entranceProperty_bg;
        public System.Windows.Forms.CheckBox cameraboxCheckbox;
        public System.Windows.Forms.CheckBox entranceposCheckbox;
        private CustomPanel panel1;
        public ObjectViewer objectViewer1;
        private System.Windows.Forms.CheckBox showNameObjectCheckbox;
        private CustomPanel customPanel1;
        private System.Windows.Forms.TabPage debugtabPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox previewPaletteTextbox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label hovergfxLabel;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.ToolStripButton allbgsButton;
        public System.Windows.Forms.ToolStripButton bg2modeButton;
        public System.Windows.Forms.ToolStripButton bg3modeButton;
        public System.Windows.Forms.ToolStripButton spritemodeButton;
        public System.Windows.Forms.ToolStripButton bg1modeButton;
        public SpritesView spritesView1;
        private System.Windows.Forms.TextBox gfx8textBox;
        private System.Windows.Forms.TextBox gfx7textBox;
        private System.Windows.Forms.TextBox gfx6textBox;
        private System.Windows.Forms.TextBox gfx5textBox;
        private System.Windows.Forms.TextBox gfx4textBox;
        private System.Windows.Forms.TextBox gfx3textBox;
        private System.Windows.Forms.TextBox gfx2textBox;
        private System.Windows.Forms.TextBox gfx1textBox;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox previewPaletteGfxTextbox;
        private CustomPanel customPanel2;
        public System.Windows.Forms.CheckBox litCheckbox;
        private System.Windows.Forms.ToolStripMenuItem patchNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportOnJPROMToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label49;
        public System.Windows.Forms.TextBox entranceProperty_FD;
        public System.Windows.Forms.TextBox entranceProperty_HD;
        public System.Windows.Forms.TextBox entranceProperty_FU;
        public System.Windows.Forms.TextBox entranceProperty_HU;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        public System.Windows.Forms.TextBox entranceProperty_FR;
        public System.Windows.Forms.TextBox entranceProperty_HR;
        public System.Windows.Forms.TextBox entranceProperty_FL;
        public System.Windows.Forms.TextBox entranceProperty_HL;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        public System.Windows.Forms.CheckBox spriteoverlordCheckbox;
    }
}

