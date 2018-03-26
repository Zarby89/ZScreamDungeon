namespace ZeldaFullEditor
{
    partial class zscreamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(zscreamForm));
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
            this.createProjectFromROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportProjectAsROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBaseROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textChestItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textPotItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBG2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBG1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectedBGTransparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightSideToolboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mapPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.entrancetabPage = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.entrancetreeView = new System.Windows.Forms.TreeView();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cameraboxCheckbox = new System.Windows.Forms.CheckBox();
            this.entranceposCheckbox = new System.Windows.Forms.CheckBox();
            this.objectstabPage = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.objectsListbox = new System.Windows.Forms.ListBox();
            this.searchobjectPanel = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.previewObjectPicturebox = new System.Windows.Forms.PictureBox();
            this.settingstabPage = new System.Windows.Forms.TabPage();
            this.DEBUGMirrorCheckbox = new System.Windows.Forms.CheckBox();
            this.DEBUGWallCheckbox = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.DEBUGEquipmentCheckbox = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.objectinfoLabel = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.palettestabPage = new System.Windows.Forms.TabPage();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.palettesTreeview = new System.Windows.Forms.TreeView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.palettePicturebox = new System.Windows.Forms.PictureBox();
            this.gfxtabPage = new System.Windows.Forms.TabPage();
            this.gfxPicturebox = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gfx8NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gfx7NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gfx6NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gfx5NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gfxgroupindexUpDown = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.gfxfromroomButton = new System.Windows.Forms.Button();
            this.gfx4NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gfx3NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gfx2NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gfx1NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.gfxgroupCombobox = new System.Windows.Forms.ComboBox();
            this.texttabPage = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.commandstextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.searchtextListbox = new System.Windows.Forms.ListBox();
            this.searchtextTextbox = new System.Windows.Forms.TextBox();
            this.textpreviewButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.messageUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.messagetextBox = new System.Windows.Forms.TextBox();
            this.randoPage = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rupeeNumericupdown = new System.Windows.Forms.NumericUpDown();
            this.label41 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.equipBottle4Combobox = new System.Windows.Forms.ComboBox();
            this.equipBottle3Combobox = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.equipBottle2Combobox = new System.Windows.Forms.ComboBox();
            this.equipBottle1Combobox = new System.Windows.Forms.ComboBox();
            this.equipGlovescomboBox = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.equipMailcomboBox = new System.Windows.Forms.ComboBox();
            this.equipShieldcomboBox = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.equipMoonpearlCheckbox = new System.Windows.Forms.CheckBox();
            this.equipFlippersCheckbox = new System.Windows.Forms.CheckBox();
            this.equipSwordcomboBox = new System.Windows.Forms.ComboBox();
            this.equipBootsCheckbox = new System.Windows.Forms.CheckBox();
            this.equipMirrorCheckbox = new System.Windows.Forms.CheckBox();
            this.equipByrnaCheckbox = new System.Windows.Forms.CheckBox();
            this.equipCapeCheckbox = new System.Windows.Forms.CheckBox();
            this.equipSomariaCheckbox = new System.Windows.Forms.CheckBox();
            this.equipFluteactiveCheckbox = new System.Windows.Forms.CheckBox();
            this.equipFluteCheckbox = new System.Windows.Forms.CheckBox();
            this.equipQuakeCheckbox = new System.Windows.Forms.CheckBox();
            this.equipEtherCheckbox = new System.Windows.Forms.CheckBox();
            this.equipBookCheckbox = new System.Windows.Forms.CheckBox();
            this.equipNetCheckbox = new System.Windows.Forms.CheckBox();
            this.equipShovelCheckbox = new System.Windows.Forms.CheckBox();
            this.equipHammerCheckbox = new System.Windows.Forms.CheckBox();
            this.equipLanternCheckbox = new System.Windows.Forms.CheckBox();
            this.equipPowderCheckbox = new System.Windows.Forms.CheckBox();
            this.equipBombosCheckbox = new System.Windows.Forms.CheckBox();
            this.equipIcerodCheckbox = new System.Windows.Forms.CheckBox();
            this.equipFirerodCheckbox = new System.Windows.Forms.CheckBox();
            this.equipMushroomCheckbox = new System.Windows.Forms.CheckBox();
            this.equipBombsCheckbox = new System.Windows.Forms.CheckBox();
            this.equipHookshotCheckbox = new System.Windows.Forms.CheckBox();
            this.equipBoomerangredCheckbox = new System.Windows.Forms.CheckBox();
            this.equipBoomerangCheckbox = new System.Windows.Forms.CheckBox();
            this.equipSilverarrowCheckBox = new System.Windows.Forms.CheckBox();
            this.equipBowCheckbox = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.spritesListbox = new System.Windows.Forms.ListBox();
            this.searchspriteTextbox = new System.Windows.Forms.TextBox();
            this.spritePreviewBox = new System.Windows.Forms.PictureBox();
            this.OverworldPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.owMapList = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.propertyGrid3 = new System.Windows.Forms.PropertyGrid();
            this.selectedGroupbox = new System.Windows.Forms.GroupBox();
            this.selectedZUpDown = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.spritepropertyPanel = new System.Windows.Forms.Panel();
            this.spriteoverlordCheckbox = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.spritesubtypeUpDown = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.selectedLayerNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.selectedSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.selectedYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.selectedXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.doorselectPanel = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.potitemobjectPanel = new System.Windows.Forms.Panel();
            this.selecteditemobjectCombobox = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.searchobjectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewObjectPicturebox)).BeginInit();
            this.settingstabPage.SuspendLayout();
            this.palettestabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).BeginInit();
            this.gfxtabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gfxPicturebox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gfx8NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx7NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx6NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx5NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfxgroupindexUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx4NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx3NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx2NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx1NumericUpDown)).BeginInit();
            this.texttabPage.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageUpDown)).BeginInit();
            this.randoPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rupeeNumericupdown)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritePreviewBox)).BeginInit();
            this.OverworldPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.selectedGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedZUpDown)).BeginInit();
            this.spritepropertyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritesubtypeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedLayerNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedXNumericUpDown)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(844, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createProjectFromROMToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.exportProjectAsROMToolStripMenuItem,
            this.changeBaseROMToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // createProjectFromROMToolStripMenuItem
            // 
            this.createProjectFromROMToolStripMenuItem.Name = "createProjectFromROMToolStripMenuItem";
            this.createProjectFromROMToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.createProjectFromROMToolStripMenuItem.Text = "Create new Project";
            this.createProjectFromROMToolStripMenuItem.Click += new System.EventHandler(this.createProjectFromROMToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openToolStripMenuItem.Text = "Open Project";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.saveToolStripMenuItem.Text = "Save Project";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveasToolStripMenuItem
            // 
            this.saveasToolStripMenuItem.Enabled = false;
            this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            this.saveasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveasToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.saveasToolStripMenuItem.Text = "Save Project As...";
            this.saveasToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
            // 
            // exportProjectAsROMToolStripMenuItem
            // 
            this.exportProjectAsROMToolStripMenuItem.Name = "exportProjectAsROMToolStripMenuItem";
            this.exportProjectAsROMToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.exportProjectAsROMToolStripMenuItem.Text = "Patch a ROM";
            this.exportProjectAsROMToolStripMenuItem.Click += new System.EventHandler(this.exportProjectAsROMToolStripMenuItem_Click);
            // 
            // changeBaseROMToolStripMenuItem
            // 
            this.changeBaseROMToolStripMenuItem.Name = "changeBaseROMToolStripMenuItem";
            this.changeBaseROMToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.changeBaseROMToolStripMenuItem.Text = "Change Base ROM";
            this.changeBaseROMToolStripMenuItem.Click += new System.EventHandler(this.changeBaseROMToolStripMenuItem_Click);
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
            this.bringToBackToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(161, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Enabled = false;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(161, 6);
            // 
            // moveFrontToolStripMenuItem
            // 
            this.moveFrontToolStripMenuItem.Enabled = false;
            this.moveFrontToolStripMenuItem.Name = "moveFrontToolStripMenuItem";
            this.moveFrontToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.moveFrontToolStripMenuItem.Text = "Bring to Front";
            this.moveFrontToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // bringToBackToolStripMenuItem
            // 
            this.bringToBackToolStripMenuItem.Enabled = false;
            this.bringToBackToolStripMenuItem.Name = "bringToBackToolStripMenuItem";
            this.bringToBackToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.bringToBackToolStripMenuItem.Text = "Send to Back";
            this.bringToBackToolStripMenuItem.Click += new System.EventHandler(this.bringToBackToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoRoomToolStripMenuItem,
            this.importRoomToolStripMenuItem,
            this.globalOptionsToolStripMenuItem,
            this.exportRoomToolStripMenuItem,
            this.patchROMToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // gotoRoomToolStripMenuItem
            // 
            this.gotoRoomToolStripMenuItem.Enabled = false;
            this.gotoRoomToolStripMenuItem.Name = "gotoRoomToolStripMenuItem";
            this.gotoRoomToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.gotoRoomToolStripMenuItem.Text = "Goto Room";
            this.gotoRoomToolStripMenuItem.Click += new System.EventHandler(this.gotoRoomToolStripMenuItem_Click);
            // 
            // importRoomToolStripMenuItem
            // 
            this.importRoomToolStripMenuItem.Name = "importRoomToolStripMenuItem";
            this.importRoomToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.importRoomToolStripMenuItem.Text = "Import Room";
            this.importRoomToolStripMenuItem.Click += new System.EventHandler(this.importRoomToolStripMenuItem_Click);
            // 
            // globalOptionsToolStripMenuItem
            // 
            this.globalOptionsToolStripMenuItem.Name = "globalOptionsToolStripMenuItem";
            this.globalOptionsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.globalOptionsToolStripMenuItem.Text = "Global Options";
            this.globalOptionsToolStripMenuItem.Click += new System.EventHandler(this.globalOptionsToolStripMenuItem_Click);
            // 
            // exportRoomToolStripMenuItem
            // 
            this.exportRoomToolStripMenuItem.Name = "exportRoomToolStripMenuItem";
            this.exportRoomToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exportRoomToolStripMenuItem.Text = "Export Room";
            this.exportRoomToolStripMenuItem.Click += new System.EventHandler(this.exportRoomToolStripMenuItem_Click);
            // 
            // patchROMToolStripMenuItem
            // 
            this.patchROMToolStripMenuItem.Name = "patchROMToolStripMenuItem";
            this.patchROMToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.patchROMToolStripMenuItem.Text = "Patch ROM";
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
            this.rightSideToolboxToolStripMenuItem});
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
            this.showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
            this.showGridToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.showGridToolStripMenuItem.Text = "Show Grid";
            this.showGridToolStripMenuItem.Click += new System.EventHandler(this.showGridToolStripMenuItem_Click);
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
            this.animatedToolStripMenuItem.Click += new System.EventHandler(this.animatedToolStripMenuItem_Click);
            // 
            // darkThemeToolStripMenuItem
            // 
            this.darkThemeToolStripMenuItem.CheckOnClick = true;
            this.darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
            this.darkThemeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.darkThemeToolStripMenuItem.Text = "Dark Theme";
            this.darkThemeToolStripMenuItem.Click += new System.EventHandler(this.darkThemeToolStripMenuItem_Click);
            // 
            // rightSideToolboxToolStripMenuItem
            // 
            this.rightSideToolboxToolStripMenuItem.CheckOnClick = true;
            this.rightSideToolboxToolStripMenuItem.Name = "rightSideToolboxToolStripMenuItem";
            this.rightSideToolboxToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.rightSideToolboxToolStripMenuItem.Text = "Right side Toolbox";
            this.rightSideToolboxToolStripMenuItem.Click += new System.EventHandler(this.rightSideToolboxToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.howToUseToolStripMenuItem.Text = "How to Use";
            this.howToUseToolStripMenuItem.Click += new System.EventHandler(this.howToUseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 16;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
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
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(844, 25);
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
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Export selected as png";
            this.toolStripButton1.ToolTipText = "Export Map as png, Hold control and double click on the rooms you want to export";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            this.increaseZBy1ToolStripMenuItem.Name = "increaseZBy1ToolStripMenuItem";
            this.increaseZBy1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.increaseZBy1ToolStripMenuItem.Text = "Increase Z by 1";
            this.increaseZBy1ToolStripMenuItem.Click += new System.EventHandler(this.increaseZToolStripMenuItem_Click);
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
            this.decreaseZBy1ToolStripMenuItem.Name = "decreaseZBy1ToolStripMenuItem";
            this.decreaseZBy1ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.decreaseZBy1ToolStripMenuItem.Text = "Decrease Z by 1";
            this.decreaseZBy1ToolStripMenuItem.Click += new System.EventHandler(this.decreaseZToolStripMenuItem_Click);
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
            this.tabControl1.Controls.Add(this.settingstabPage);
            this.tabControl1.Controls.Add(this.palettestabPage);
            this.tabControl1.Controls.Add(this.gfxtabPage);
            this.tabControl1.Controls.Add(this.texttabPage);
            this.tabControl1.Controls.Add(this.randoPage);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.OverworldPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(300, 592);
            this.tabControl1.TabIndex = 12;
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
            this.splitContainer2.Panel2.Controls.Add(this.mapPropertyGrid);
            this.splitContainer2.Size = new System.Drawing.Size(286, 542);
            this.splitContainer2.SplitterDistance = 320;
            this.splitContainer2.TabIndex = 0;
            // 
            // mapPicturebox
            // 
            this.mapPicturebox.Location = new System.Drawing.Point(-3, 29);
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
            this.roomListView.Size = new System.Drawing.Size(269, 307);
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
            // mapPropertyGrid
            // 
            this.mapPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.mapPropertyGrid.Name = "mapPropertyGrid";
            this.mapPropertyGrid.Size = new System.Drawing.Size(286, 218);
            this.mapPropertyGrid.TabIndex = 14;
            this.mapPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
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
            this.splitContainer3.Panel2.Controls.Add(this.propertyGrid2);
            this.splitContainer3.Size = new System.Drawing.Size(292, 476);
            this.splitContainer3.SplitterDistance = 242;
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
            this.entrancetreeView.Size = new System.Drawing.Size(292, 242);
            this.entrancetreeView.TabIndex = 0;
            this.entrancetreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entrancetreeView_AfterSelect);
            this.entrancetreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.entrancetreeView_NodeMouseDoubleClick);
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid2.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(292, 230);
            this.propertyGrid2.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cameraboxCheckbox);
            this.groupBox2.Controls.Add(this.entranceposCheckbox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 476);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 72);
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
            this.entranceposCheckbox.Location = new System.Drawing.Point(6, 42);
            this.entranceposCheckbox.Name = "entranceposCheckbox";
            this.entranceposCheckbox.Size = new System.Drawing.Size(139, 17);
            this.entranceposCheckbox.TabIndex = 2;
            this.entranceposCheckbox.Text = "Show Entrance Position";
            this.entranceposCheckbox.UseVisualStyleBackColor = true;
            // 
            // objectstabPage
            // 
            this.objectstabPage.Controls.Add(this.splitContainer4);
            this.objectstabPage.Location = new System.Drawing.Point(4, 40);
            this.objectstabPage.Name = "objectstabPage";
            this.objectstabPage.Size = new System.Drawing.Size(292, 548);
            this.objectstabPage.TabIndex = 4;
            this.objectstabPage.Text = "Objects";
            this.objectstabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.objectsListbox);
            this.splitContainer4.Panel1.Controls.Add(this.searchobjectPanel);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.previewObjectPicturebox);
            this.splitContainer4.Size = new System.Drawing.Size(292, 548);
            this.splitContainer4.SplitterDistance = 329;
            this.splitContainer4.TabIndex = 0;
            // 
            // objectsListbox
            // 
            this.objectsListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectsListbox.FormattingEnabled = true;
            this.objectsListbox.Location = new System.Drawing.Point(0, 26);
            this.objectsListbox.Name = "objectsListbox";
            this.objectsListbox.Size = new System.Drawing.Size(292, 303);
            this.objectsListbox.TabIndex = 0;
            this.objectsListbox.SelectedIndexChanged += new System.EventHandler(this.objectsListbox_SelectedIndexChanged);
            // 
            // searchobjectPanel
            // 
            this.searchobjectPanel.Controls.Add(this.label17);
            this.searchobjectPanel.Controls.Add(this.searchTextbox);
            this.searchobjectPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchobjectPanel.Location = new System.Drawing.Point(0, 0);
            this.searchobjectPanel.Name = "searchobjectPanel";
            this.searchobjectPanel.Size = new System.Drawing.Size(292, 26);
            this.searchobjectPanel.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Find :";
            // 
            // searchTextbox
            // 
            this.searchTextbox.Location = new System.Drawing.Point(42, 3);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(247, 20);
            this.searchTextbox.TabIndex = 0;
            this.searchTextbox.TextChanged += new System.EventHandler(this.searchTextbox_TextChanged);
            // 
            // previewObjectPicturebox
            // 
            this.previewObjectPicturebox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.previewObjectPicturebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewObjectPicturebox.Location = new System.Drawing.Point(0, 0);
            this.previewObjectPicturebox.Name = "previewObjectPicturebox";
            this.previewObjectPicturebox.Size = new System.Drawing.Size(292, 215);
            this.previewObjectPicturebox.TabIndex = 0;
            this.previewObjectPicturebox.TabStop = false;
            // 
            // settingstabPage
            // 
            this.settingstabPage.Controls.Add(this.DEBUGMirrorCheckbox);
            this.settingstabPage.Controls.Add(this.DEBUGWallCheckbox);
            this.settingstabPage.Controls.Add(this.checkBox6);
            this.settingstabPage.Controls.Add(this.DEBUGEquipmentCheckbox);
            this.settingstabPage.Controls.Add(this.checkBox5);
            this.settingstabPage.Controls.Add(this.checkBox4);
            this.settingstabPage.Controls.Add(this.checkBox3);
            this.settingstabPage.Controls.Add(this.objectinfoLabel);
            this.settingstabPage.Controls.Add(this.checkBox2);
            this.settingstabPage.Controls.Add(this.checkBox1);
            this.settingstabPage.Controls.Add(this.button4);
            this.settingstabPage.Controls.Add(this.label13);
            this.settingstabPage.Controls.Add(this.button5);
            this.settingstabPage.Location = new System.Drawing.Point(4, 40);
            this.settingstabPage.Name = "settingstabPage";
            this.settingstabPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingstabPage.Size = new System.Drawing.Size(292, 548);
            this.settingstabPage.TabIndex = 1;
            this.settingstabPage.Text = "Debug";
            this.settingstabPage.UseVisualStyleBackColor = true;
            // 
            // DEBUGMirrorCheckbox
            // 
            this.DEBUGMirrorCheckbox.AutoSize = true;
            this.DEBUGMirrorCheckbox.Checked = true;
            this.DEBUGMirrorCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DEBUGMirrorCheckbox.Location = new System.Drawing.Point(9, 55);
            this.DEBUGMirrorCheckbox.Name = "DEBUGMirrorCheckbox";
            this.DEBUGMirrorCheckbox.Size = new System.Drawing.Size(104, 17);
            this.DEBUGMirrorCheckbox.TabIndex = 17;
            this.DEBUGMirrorCheckbox.Text = "Mirror both world";
            this.DEBUGMirrorCheckbox.UseVisualStyleBackColor = true;
            // 
            // DEBUGWallCheckbox
            // 
            this.DEBUGWallCheckbox.AutoSize = true;
            this.DEBUGWallCheckbox.Checked = true;
            this.DEBUGWallCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DEBUGWallCheckbox.Location = new System.Drawing.Point(9, 32);
            this.DEBUGWallCheckbox.Name = "DEBUGWallCheckbox";
            this.DEBUGWallCheckbox.Size = new System.Drawing.Size(169, 17);
            this.DEBUGWallCheckbox.TabIndex = 16;
            this.DEBUGWallCheckbox.Text = "Walk Through Wall (R Button)";
            this.DEBUGWallCheckbox.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(9, 78);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(154, 17);
            this.checkBox6.TabIndex = 15;
            this.checkBox6.Text = "Start in room opened (WIP)";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // DEBUGEquipmentCheckbox
            // 
            this.DEBUGEquipmentCheckbox.AutoSize = true;
            this.DEBUGEquipmentCheckbox.Checked = true;
            this.DEBUGEquipmentCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DEBUGEquipmentCheckbox.Location = new System.Drawing.Point(9, 9);
            this.DEBUGEquipmentCheckbox.Name = "DEBUGEquipmentCheckbox";
            this.DEBUGEquipmentCheckbox.Size = new System.Drawing.Size(95, 17);
            this.DEBUGEquipmentCheckbox.TabIndex = 14;
            this.DEBUGEquipmentCheckbox.Text = "All Equipments";
            this.DEBUGEquipmentCheckbox.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(10, 265);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(77, 17);
            this.checkBox5.TabIndex = 13;
            this.checkBox5.Text = "Bomb door";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.Visible = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(94, 242);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(83, 17);
            this.checkBox4.TabIndex = 12;
            this.checkBox4.Text = "Curtain door";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(94, 219);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(82, 17);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "Layer2 door";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            // 
            // objectinfoLabel
            // 
            this.objectinfoLabel.AutoSize = true;
            this.objectinfoLabel.Location = new System.Drawing.Point(110, 300);
            this.objectinfoLabel.Name = "objectinfoLabel";
            this.objectinfoLabel.Size = new System.Drawing.Size(58, 13);
            this.objectinfoLabel.TabIndex = 7;
            this.objectinfoLabel.Text = "description";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(10, 242);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(67, 17);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Exit door";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 219);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Trap door";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(227, 261);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Swap BG";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 3);
            this.label13.MaximumSize = new System.Drawing.Size(300, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(113, 404);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "DEBUG";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
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
            this.splitContainer6.Panel1.Controls.Add(this.label7);
            this.splitContainer6.Panel1.Controls.Add(this.palettesTreeview);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.button2);
            this.splitContainer6.Panel2.Controls.Add(this.button1);
            this.splitContainer6.Panel2.Controls.Add(this.palettePicturebox);
            this.splitContainer6.Size = new System.Drawing.Size(292, 548);
            this.splitContainer6.SplitterDistance = 302;
            this.splitContainer6.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 26);
            this.label7.TabIndex = 1;
            this.label7.Text = "Hold right click to turn color temporary to Fuschia\r\nDouble click the color the c" +
    "hange it";
            this.label7.Visible = false;
            // 
            // palettesTreeview
            // 
            this.palettesTreeview.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.palettesTreeview.Size = new System.Drawing.Size(292, 302);
            this.palettesTreeview.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(280, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save to YY-CHR Palettes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generate a Random Palette";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // palettePicturebox
            // 
            this.palettePicturebox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.palettePicturebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palettePicturebox.Location = new System.Drawing.Point(0, 0);
            this.palettePicturebox.Name = "palettePicturebox";
            this.palettePicturebox.Size = new System.Drawing.Size(292, 242);
            this.palettePicturebox.TabIndex = 0;
            this.palettePicturebox.TabStop = false;
            // 
            // gfxtabPage
            // 
            this.gfxtabPage.AutoScroll = true;
            this.gfxtabPage.Controls.Add(this.gfxPicturebox);
            this.gfxtabPage.Controls.Add(this.groupBox3);
            this.gfxtabPage.Location = new System.Drawing.Point(4, 40);
            this.gfxtabPage.Name = "gfxtabPage";
            this.gfxtabPage.Size = new System.Drawing.Size(292, 548);
            this.gfxtabPage.TabIndex = 6;
            this.gfxtabPage.Text = "Gfx";
            this.gfxtabPage.UseVisualStyleBackColor = true;
            // 
            // gfxPicturebox
            // 
            this.gfxPicturebox.Dock = System.Windows.Forms.DockStyle.Top;
            this.gfxPicturebox.Location = new System.Drawing.Point(0, 145);
            this.gfxPicturebox.Name = "gfxPicturebox";
            this.gfxPicturebox.Size = new System.Drawing.Size(275, 512);
            this.gfxPicturebox.TabIndex = 12;
            this.gfxPicturebox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gfx8NumericUpDown);
            this.groupBox3.Controls.Add(this.gfx7NumericUpDown);
            this.groupBox3.Controls.Add(this.gfx6NumericUpDown);
            this.groupBox3.Controls.Add(this.gfx5NumericUpDown);
            this.groupBox3.Controls.Add(this.gfxgroupindexUpDown);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.gfxfromroomButton);
            this.groupBox3.Controls.Add(this.gfx4NumericUpDown);
            this.groupBox3.Controls.Add(this.gfx3NumericUpDown);
            this.groupBox3.Controls.Add(this.gfx2NumericUpDown);
            this.groupBox3.Controls.Add(this.gfx1NumericUpDown);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.gfxgroupCombobox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 145);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gfx Groups";
            // 
            // gfx8NumericUpDown
            // 
            this.gfx8NumericUpDown.Location = new System.Drawing.Point(177, 89);
            this.gfx8NumericUpDown.Maximum = new decimal(new int[] {
            223,
            0,
            0,
            0});
            this.gfx8NumericUpDown.Name = "gfx8NumericUpDown";
            this.gfx8NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.gfx8NumericUpDown.TabIndex = 12;
            this.gfx8NumericUpDown.ValueChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx7NumericUpDown
            // 
            this.gfx7NumericUpDown.Location = new System.Drawing.Point(120, 89);
            this.gfx7NumericUpDown.Maximum = new decimal(new int[] {
            223,
            0,
            0,
            0});
            this.gfx7NumericUpDown.Name = "gfx7NumericUpDown";
            this.gfx7NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.gfx7NumericUpDown.TabIndex = 11;
            this.gfx7NumericUpDown.ValueChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx6NumericUpDown
            // 
            this.gfx6NumericUpDown.Location = new System.Drawing.Point(63, 89);
            this.gfx6NumericUpDown.Maximum = new decimal(new int[] {
            223,
            0,
            0,
            0});
            this.gfx6NumericUpDown.Name = "gfx6NumericUpDown";
            this.gfx6NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.gfx6NumericUpDown.TabIndex = 10;
            this.gfx6NumericUpDown.ValueChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx5NumericUpDown
            // 
            this.gfx5NumericUpDown.Location = new System.Drawing.Point(6, 89);
            this.gfx5NumericUpDown.Maximum = new decimal(new int[] {
            223,
            0,
            0,
            0});
            this.gfx5NumericUpDown.Name = "gfx5NumericUpDown";
            this.gfx5NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.gfx5NumericUpDown.TabIndex = 9;
            this.gfx5NumericUpDown.ValueChanged += new System.EventHandler(this.gfxsinglechanged);
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
            this.gfxgroupindexUpDown.Size = new System.Drawing.Size(108, 20);
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
            this.gfxfromroomButton.Location = new System.Drawing.Point(6, 116);
            this.gfxfromroomButton.Name = "gfxfromroomButton";
            this.gfxfromroomButton.Size = new System.Drawing.Size(258, 23);
            this.gfxfromroomButton.TabIndex = 6;
            this.gfxfromroomButton.Text = "Load Index from selected room";
            this.gfxfromroomButton.UseVisualStyleBackColor = true;
            this.gfxfromroomButton.Click += new System.EventHandler(this.gfxfromroomButton_Click);
            // 
            // gfx4NumericUpDown
            // 
            this.gfx4NumericUpDown.Location = new System.Drawing.Point(177, 63);
            this.gfx4NumericUpDown.Maximum = new decimal(new int[] {
            223,
            0,
            0,
            0});
            this.gfx4NumericUpDown.Name = "gfx4NumericUpDown";
            this.gfx4NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.gfx4NumericUpDown.TabIndex = 5;
            this.gfx4NumericUpDown.ValueChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx3NumericUpDown
            // 
            this.gfx3NumericUpDown.Location = new System.Drawing.Point(120, 63);
            this.gfx3NumericUpDown.Maximum = new decimal(new int[] {
            223,
            0,
            0,
            0});
            this.gfx3NumericUpDown.Name = "gfx3NumericUpDown";
            this.gfx3NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.gfx3NumericUpDown.TabIndex = 4;
            this.gfx3NumericUpDown.ValueChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx2NumericUpDown
            // 
            this.gfx2NumericUpDown.Location = new System.Drawing.Point(63, 63);
            this.gfx2NumericUpDown.Maximum = new decimal(new int[] {
            223,
            0,
            0,
            0});
            this.gfx2NumericUpDown.Name = "gfx2NumericUpDown";
            this.gfx2NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.gfx2NumericUpDown.TabIndex = 3;
            this.gfx2NumericUpDown.ValueChanged += new System.EventHandler(this.gfxsinglechanged);
            // 
            // gfx1NumericUpDown
            // 
            this.gfx1NumericUpDown.Location = new System.Drawing.Point(6, 63);
            this.gfx1NumericUpDown.Maximum = new decimal(new int[] {
            223,
            0,
            0,
            0});
            this.gfx1NumericUpDown.Name = "gfx1NumericUpDown";
            this.gfx1NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.gfx1NumericUpDown.TabIndex = 2;
            this.gfx1NumericUpDown.ValueChanged += new System.EventHandler(this.gfxsinglechanged);
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
            "Palettes",
            "Room Vram"});
            this.gfxgroupCombobox.Location = new System.Drawing.Point(6, 36);
            this.gfxgroupCombobox.Name = "gfxgroupCombobox";
            this.gfxgroupCombobox.Size = new System.Drawing.Size(108, 21);
            this.gfxgroupCombobox.TabIndex = 0;
            this.gfxgroupCombobox.Text = "Main Blockset";
            this.gfxgroupCombobox.SelectedIndexChanged += new System.EventHandler(this.gfxgroupCombobox_SelectedIndexChanged);
            // 
            // texttabPage
            // 
            this.texttabPage.Controls.Add(this.tabControl2);
            this.texttabPage.Controls.Add(this.textpreviewButton);
            this.texttabPage.Controls.Add(this.label16);
            this.texttabPage.Controls.Add(this.messageUpDown);
            this.texttabPage.Controls.Add(this.label14);
            this.texttabPage.Controls.Add(this.messagetextBox);
            this.texttabPage.Location = new System.Drawing.Point(4, 40);
            this.texttabPage.Name = "texttabPage";
            this.texttabPage.Padding = new System.Windows.Forms.Padding(3);
            this.texttabPage.Size = new System.Drawing.Size(292, 548);
            this.texttabPage.TabIndex = 7;
            this.texttabPage.Text = "Texts";
            this.texttabPage.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(3, 199);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(302, 346);
            this.tabControl2.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.commandstextBox);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(294, 320);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Commands";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // commandstextBox
            // 
            this.commandstextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandstextBox.Location = new System.Drawing.Point(3, 16);
            this.commandstextBox.Multiline = true;
            this.commandstextBox.Name = "commandstextBox";
            this.commandstextBox.ReadOnly = true;
            this.commandstextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commandstextBox.Size = new System.Drawing.Size(288, 301);
            this.commandstextBox.TabIndex = 2;
            this.commandstextBox.Text = resources.GetString("commandstextBox.Text");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(3, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(246, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Command Format : [CMD XX] arguments are in hex";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.searchtextListbox);
            this.tabPage3.Controls.Add(this.searchtextTextbox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(294, 320);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Search";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // searchtextListbox
            // 
            this.searchtextListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchtextListbox.FormattingEnabled = true;
            this.searchtextListbox.Location = new System.Drawing.Point(3, 23);
            this.searchtextListbox.Name = "searchtextListbox";
            this.searchtextListbox.Size = new System.Drawing.Size(288, 294);
            this.searchtextListbox.TabIndex = 1;
            this.searchtextListbox.SelectedIndexChanged += new System.EventHandler(this.searchtextListbox_SelectedIndexChanged);
            // 
            // searchtextTextbox
            // 
            this.searchtextTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchtextTextbox.Location = new System.Drawing.Point(3, 3);
            this.searchtextTextbox.Name = "searchtextTextbox";
            this.searchtextTextbox.Size = new System.Drawing.Size(288, 20);
            this.searchtextTextbox.TabIndex = 0;
            this.searchtextTextbox.TextChanged += new System.EventHandler(this.searchtextTextbox_TextChanged);
            // 
            // textpreviewButton
            // 
            this.textpreviewButton.Location = new System.Drawing.Point(9, 170);
            this.textpreviewButton.Name = "textpreviewButton";
            this.textpreviewButton.Size = new System.Drawing.Size(148, 23);
            this.textpreviewButton.TabIndex = 6;
            this.textpreviewButton.Text = "Show Preview";
            this.textpreviewButton.UseVisualStyleBackColor = true;
            this.textpreviewButton.Click += new System.EventHandler(this.textpreviewButton_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(163, 142);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Address : ";
            // 
            // messageUpDown
            // 
            this.messageUpDown.Location = new System.Drawing.Point(82, 140);
            this.messageUpDown.Name = "messageUpDown";
            this.messageUpDown.Size = new System.Drawing.Size(75, 20);
            this.messageUpDown.TabIndex = 2;
            this.messageUpDown.ValueChanged += new System.EventHandler(this.messageUpDown_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 142);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Message id : ";
            // 
            // messagetextBox
            // 
            this.messagetextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messagetextBox.Location = new System.Drawing.Point(6, 6);
            this.messagetextBox.Multiline = true;
            this.messagetextBox.Name = "messagetextBox";
            this.messagetextBox.Size = new System.Drawing.Size(280, 131);
            this.messagetextBox.TabIndex = 0;
            this.messagetextBox.TextChanged += new System.EventHandler(this.messagetextBox_TextChanged);
            // 
            // randoPage
            // 
            this.randoPage.AutoScroll = true;
            this.randoPage.Controls.Add(this.pictureBox1);
            this.randoPage.Controls.Add(this.button3);
            this.randoPage.Controls.Add(this.numericUpDown1);
            this.randoPage.Controls.Add(this.button7);
            this.randoPage.Controls.Add(this.button8);
            this.randoPage.Location = new System.Drawing.Point(4, 40);
            this.randoPage.Name = "randoPage";
            this.randoPage.Size = new System.Drawing.Size(292, 548);
            this.randoPage.TabIndex = 8;
            this.randoPage.Text = "Rando";
            this.randoPage.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 231);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(146, 329);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Open";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(79, 271);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(124, 242);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 5;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(205, 242);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 6;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(292, 548);
            this.tabPage1.TabIndex = 9;
            this.tabPage1.Text = "Starting Equip.";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rupeeNumericupdown);
            this.groupBox5.Controls.Add(this.label41);
            this.groupBox5.Controls.Add(this.label49);
            this.groupBox5.Controls.Add(this.label50);
            this.groupBox5.Controls.Add(this.equipBottle4Combobox);
            this.groupBox5.Controls.Add(this.equipBottle3Combobox);
            this.groupBox5.Controls.Add(this.label48);
            this.groupBox5.Controls.Add(this.label47);
            this.groupBox5.Controls.Add(this.equipBottle2Combobox);
            this.groupBox5.Controls.Add(this.equipBottle1Combobox);
            this.groupBox5.Controls.Add(this.equipGlovescomboBox);
            this.groupBox5.Controls.Add(this.label46);
            this.groupBox5.Controls.Add(this.label45);
            this.groupBox5.Controls.Add(this.equipMailcomboBox);
            this.groupBox5.Controls.Add(this.equipShieldcomboBox);
            this.groupBox5.Controls.Add(this.label44);
            this.groupBox5.Controls.Add(this.label43);
            this.groupBox5.Controls.Add(this.equipMoonpearlCheckbox);
            this.groupBox5.Controls.Add(this.equipFlippersCheckbox);
            this.groupBox5.Controls.Add(this.equipSwordcomboBox);
            this.groupBox5.Controls.Add(this.equipBootsCheckbox);
            this.groupBox5.Controls.Add(this.equipMirrorCheckbox);
            this.groupBox5.Controls.Add(this.equipByrnaCheckbox);
            this.groupBox5.Controls.Add(this.equipCapeCheckbox);
            this.groupBox5.Controls.Add(this.equipSomariaCheckbox);
            this.groupBox5.Controls.Add(this.equipFluteactiveCheckbox);
            this.groupBox5.Controls.Add(this.equipFluteCheckbox);
            this.groupBox5.Controls.Add(this.equipQuakeCheckbox);
            this.groupBox5.Controls.Add(this.equipEtherCheckbox);
            this.groupBox5.Controls.Add(this.equipBookCheckbox);
            this.groupBox5.Controls.Add(this.equipNetCheckbox);
            this.groupBox5.Controls.Add(this.equipShovelCheckbox);
            this.groupBox5.Controls.Add(this.equipHammerCheckbox);
            this.groupBox5.Controls.Add(this.equipLanternCheckbox);
            this.groupBox5.Controls.Add(this.equipPowderCheckbox);
            this.groupBox5.Controls.Add(this.equipBombosCheckbox);
            this.groupBox5.Controls.Add(this.equipIcerodCheckbox);
            this.groupBox5.Controls.Add(this.equipFirerodCheckbox);
            this.groupBox5.Controls.Add(this.equipMushroomCheckbox);
            this.groupBox5.Controls.Add(this.equipBombsCheckbox);
            this.groupBox5.Controls.Add(this.equipHookshotCheckbox);
            this.groupBox5.Controls.Add(this.equipBoomerangredCheckbox);
            this.groupBox5.Controls.Add(this.equipBoomerangCheckbox);
            this.groupBox5.Controls.Add(this.equipSilverarrowCheckBox);
            this.groupBox5.Controls.Add(this.equipBowCheckbox);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(292, 548);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Initial Equipement (on file create)";
            // 
            // rupeeNumericupdown
            // 
            this.rupeeNumericupdown.Location = new System.Drawing.Point(6, 411);
            this.rupeeNumericupdown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.rupeeNumericupdown.Name = "rupeeNumericupdown";
            this.rupeeNumericupdown.Size = new System.Drawing.Size(93, 20);
            this.rupeeNumericupdown.TabIndex = 41;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(3, 395);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(45, 13);
            this.label41.TabIndex = 40;
            this.label41.Text = "Rupee :";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(198, 395);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(52, 13);
            this.label49.TabIndex = 57;
            this.label49.Text = "Bottle 4 : ";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(101, 395);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(52, 13);
            this.label50.TabIndex = 56;
            this.label50.Text = "Bottle 3 : ";
            // 
            // equipBottle4Combobox
            // 
            this.equipBottle4Combobox.FormattingEnabled = true;
            this.equipBottle4Combobox.Items.AddRange(new object[] {
            "No Bottle",
            "Mushroom?",
            "Red Potion",
            "Green Potion",
            "Blue Potion",
            "Fairy",
            "Bee",
            "Gold Bee"});
            this.equipBottle4Combobox.Location = new System.Drawing.Point(201, 411);
            this.equipBottle4Combobox.Name = "equipBottle4Combobox";
            this.equipBottle4Combobox.Size = new System.Drawing.Size(93, 21);
            this.equipBottle4Combobox.TabIndex = 55;
            this.equipBottle4Combobox.Text = "No Bottle";
            // 
            // equipBottle3Combobox
            // 
            this.equipBottle3Combobox.FormattingEnabled = true;
            this.equipBottle3Combobox.Items.AddRange(new object[] {
            "No Bottle",
            "Mushroom?",
            "Red Potion",
            "Green Potion",
            "Blue Potion",
            "Fairy",
            "Bee",
            "Gold Bee"});
            this.equipBottle3Combobox.Location = new System.Drawing.Point(104, 411);
            this.equipBottle3Combobox.Name = "equipBottle3Combobox";
            this.equipBottle3Combobox.Size = new System.Drawing.Size(93, 21);
            this.equipBottle3Combobox.TabIndex = 54;
            this.equipBottle3Combobox.Text = "No Bottle";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(198, 355);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(52, 13);
            this.label48.TabIndex = 53;
            this.label48.Text = "Bottle 2 : ";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(101, 355);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(52, 13);
            this.label47.TabIndex = 52;
            this.label47.Text = "Bottle 1 : ";
            // 
            // equipBottle2Combobox
            // 
            this.equipBottle2Combobox.FormattingEnabled = true;
            this.equipBottle2Combobox.Items.AddRange(new object[] {
            "No Bottle",
            "Mushroom?",
            "Red Potion",
            "Green Potion",
            "Blue Potion",
            "Fairy",
            "Bee",
            "Gold Bee"});
            this.equipBottle2Combobox.Location = new System.Drawing.Point(201, 371);
            this.equipBottle2Combobox.Name = "equipBottle2Combobox";
            this.equipBottle2Combobox.Size = new System.Drawing.Size(93, 21);
            this.equipBottle2Combobox.TabIndex = 51;
            this.equipBottle2Combobox.Text = "No Bottle";
            // 
            // equipBottle1Combobox
            // 
            this.equipBottle1Combobox.FormattingEnabled = true;
            this.equipBottle1Combobox.Items.AddRange(new object[] {
            "No Bottle",
            "Mushroom?",
            "Red Potion",
            "Green Potion",
            "Blue Potion",
            "Fairy",
            "Bee",
            "Gold Bee"});
            this.equipBottle1Combobox.Location = new System.Drawing.Point(104, 371);
            this.equipBottle1Combobox.Name = "equipBottle1Combobox";
            this.equipBottle1Combobox.Size = new System.Drawing.Size(93, 21);
            this.equipBottle1Combobox.TabIndex = 50;
            this.equipBottle1Combobox.Text = "No Bottle";
            // 
            // equipGlovescomboBox
            // 
            this.equipGlovescomboBox.FormattingEnabled = true;
            this.equipGlovescomboBox.Items.AddRange(new object[] {
            "No Gloves",
            "Power Gloves",
            "Titan Mitts"});
            this.equipGlovescomboBox.Location = new System.Drawing.Point(6, 371);
            this.equipGlovescomboBox.Name = "equipGlovescomboBox";
            this.equipGlovescomboBox.Size = new System.Drawing.Size(93, 21);
            this.equipGlovescomboBox.TabIndex = 49;
            this.equipGlovescomboBox.Text = "No Gloves";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(3, 355);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(49, 13);
            this.label46.TabIndex = 48;
            this.label46.Text = "Gloves : ";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(198, 315);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(43, 13);
            this.label45.TabIndex = 47;
            this.label45.Text = "Armor : ";
            // 
            // equipMailcomboBox
            // 
            this.equipMailcomboBox.FormattingEnabled = true;
            this.equipMailcomboBox.Items.AddRange(new object[] {
            "Green Mail",
            "Blue Mail",
            "Red Mail"});
            this.equipMailcomboBox.Location = new System.Drawing.Point(201, 331);
            this.equipMailcomboBox.Name = "equipMailcomboBox";
            this.equipMailcomboBox.Size = new System.Drawing.Size(93, 21);
            this.equipMailcomboBox.TabIndex = 46;
            this.equipMailcomboBox.Text = "Green Mail";
            // 
            // equipShieldcomboBox
            // 
            this.equipShieldcomboBox.FormattingEnabled = true;
            this.equipShieldcomboBox.Items.AddRange(new object[] {
            "No Shield",
            "Fighter Shield",
            "Fire Shield",
            "Mirror Shield"});
            this.equipShieldcomboBox.Location = new System.Drawing.Point(104, 331);
            this.equipShieldcomboBox.Name = "equipShieldcomboBox";
            this.equipShieldcomboBox.Size = new System.Drawing.Size(93, 21);
            this.equipShieldcomboBox.TabIndex = 45;
            this.equipShieldcomboBox.Text = "No Shield";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(101, 315);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(45, 13);
            this.label44.TabIndex = 44;
            this.label44.Text = "Shield : ";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(3, 315);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(46, 13);
            this.label43.TabIndex = 43;
            this.label43.Text = "Sword : ";
            // 
            // equipMoonpearlCheckbox
            // 
            this.equipMoonpearlCheckbox.AutoSize = true;
            this.equipMoonpearlCheckbox.Location = new System.Drawing.Point(208, 19);
            this.equipMoonpearlCheckbox.Name = "equipMoonpearlCheckbox";
            this.equipMoonpearlCheckbox.Size = new System.Drawing.Size(80, 17);
            this.equipMoonpearlCheckbox.TabIndex = 32;
            this.equipMoonpearlCheckbox.Text = "Moon Pearl";
            this.equipMoonpearlCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipFlippersCheckbox
            // 
            this.equipFlippersCheckbox.AutoSize = true;
            this.equipFlippersCheckbox.Location = new System.Drawing.Point(104, 295);
            this.equipFlippersCheckbox.Name = "equipFlippersCheckbox";
            this.equipFlippersCheckbox.Size = new System.Drawing.Size(62, 17);
            this.equipFlippersCheckbox.TabIndex = 31;
            this.equipFlippersCheckbox.Text = "Flippers";
            this.equipFlippersCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipSwordcomboBox
            // 
            this.equipSwordcomboBox.FormattingEnabled = true;
            this.equipSwordcomboBox.Items.AddRange(new object[] {
            "No Sword",
            "Fighter Sword",
            "Master Sword",
            "Tempered Sword",
            "Golden Sword"});
            this.equipSwordcomboBox.Location = new System.Drawing.Point(6, 331);
            this.equipSwordcomboBox.Name = "equipSwordcomboBox";
            this.equipSwordcomboBox.Size = new System.Drawing.Size(93, 21);
            this.equipSwordcomboBox.TabIndex = 42;
            this.equipSwordcomboBox.Text = "No Sword";
            // 
            // equipBootsCheckbox
            // 
            this.equipBootsCheckbox.AutoSize = true;
            this.equipBootsCheckbox.Location = new System.Drawing.Point(6, 295);
            this.equipBootsCheckbox.Name = "equipBootsCheckbox";
            this.equipBootsCheckbox.Size = new System.Drawing.Size(53, 17);
            this.equipBootsCheckbox.TabIndex = 30;
            this.equipBootsCheckbox.Text = "Boots";
            this.equipBootsCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipMirrorCheckbox
            // 
            this.equipMirrorCheckbox.AutoSize = true;
            this.equipMirrorCheckbox.Location = new System.Drawing.Point(105, 203);
            this.equipMirrorCheckbox.Name = "equipMirrorCheckbox";
            this.equipMirrorCheckbox.Size = new System.Drawing.Size(52, 17);
            this.equipMirrorCheckbox.TabIndex = 27;
            this.equipMirrorCheckbox.Text = "Mirror";
            this.equipMirrorCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipByrnaCheckbox
            // 
            this.equipByrnaCheckbox.AutoSize = true;
            this.equipByrnaCheckbox.Location = new System.Drawing.Point(6, 272);
            this.equipByrnaCheckbox.Name = "equipByrnaCheckbox";
            this.equipByrnaCheckbox.Size = new System.Drawing.Size(93, 17);
            this.equipByrnaCheckbox.TabIndex = 26;
            this.equipByrnaCheckbox.Text = "Cane of Byrna";
            this.equipByrnaCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipCapeCheckbox
            // 
            this.equipCapeCheckbox.AutoSize = true;
            this.equipCapeCheckbox.Location = new System.Drawing.Point(104, 272);
            this.equipCapeCheckbox.Name = "equipCapeCheckbox";
            this.equipCapeCheckbox.Size = new System.Drawing.Size(51, 17);
            this.equipCapeCheckbox.TabIndex = 22;
            this.equipCapeCheckbox.Text = "Cape";
            this.equipCapeCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipSomariaCheckbox
            // 
            this.equipSomariaCheckbox.AutoSize = true;
            this.equipSomariaCheckbox.Location = new System.Drawing.Point(105, 249);
            this.equipSomariaCheckbox.Name = "equipSomariaCheckbox";
            this.equipSomariaCheckbox.Size = new System.Drawing.Size(104, 17);
            this.equipSomariaCheckbox.TabIndex = 21;
            this.equipSomariaCheckbox.Text = "Cane of Somaria";
            this.equipSomariaCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipFluteactiveCheckbox
            // 
            this.equipFluteactiveCheckbox.AutoSize = true;
            this.equipFluteactiveCheckbox.Location = new System.Drawing.Point(106, 111);
            this.equipFluteactiveCheckbox.Name = "equipFluteactiveCheckbox";
            this.equipFluteactiveCheckbox.Size = new System.Drawing.Size(82, 17);
            this.equipFluteactiveCheckbox.TabIndex = 19;
            this.equipFluteactiveCheckbox.Text = "Flute Active";
            this.equipFluteactiveCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipFluteCheckbox
            // 
            this.equipFluteCheckbox.AutoSize = true;
            this.equipFluteCheckbox.Location = new System.Drawing.Point(106, 88);
            this.equipFluteCheckbox.Name = "equipFluteCheckbox";
            this.equipFluteCheckbox.Size = new System.Drawing.Size(49, 17);
            this.equipFluteCheckbox.TabIndex = 18;
            this.equipFluteCheckbox.Text = "Flute";
            this.equipFluteCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipQuakeCheckbox
            // 
            this.equipQuakeCheckbox.AutoSize = true;
            this.equipQuakeCheckbox.Location = new System.Drawing.Point(106, 180);
            this.equipQuakeCheckbox.Name = "equipQuakeCheckbox";
            this.equipQuakeCheckbox.Size = new System.Drawing.Size(58, 17);
            this.equipQuakeCheckbox.TabIndex = 17;
            this.equipQuakeCheckbox.Text = "Quake";
            this.equipQuakeCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipEtherCheckbox
            // 
            this.equipEtherCheckbox.AutoSize = true;
            this.equipEtherCheckbox.Location = new System.Drawing.Point(106, 157);
            this.equipEtherCheckbox.Name = "equipEtherCheckbox";
            this.equipEtherCheckbox.Size = new System.Drawing.Size(51, 17);
            this.equipEtherCheckbox.TabIndex = 16;
            this.equipEtherCheckbox.Text = "Ether";
            this.equipEtherCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipBookCheckbox
            // 
            this.equipBookCheckbox.AutoSize = true;
            this.equipBookCheckbox.Location = new System.Drawing.Point(6, 249);
            this.equipBookCheckbox.Name = "equipBookCheckbox";
            this.equipBookCheckbox.Size = new System.Drawing.Size(102, 17);
            this.equipBookCheckbox.TabIndex = 15;
            this.equipBookCheckbox.Text = "Book of Mudora";
            this.equipBookCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipNetCheckbox
            // 
            this.equipNetCheckbox.AutoSize = true;
            this.equipNetCheckbox.Location = new System.Drawing.Point(105, 225);
            this.equipNetCheckbox.Name = "equipNetCheckbox";
            this.equipNetCheckbox.Size = new System.Drawing.Size(43, 17);
            this.equipNetCheckbox.TabIndex = 14;
            this.equipNetCheckbox.Text = "Net";
            this.equipNetCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipShovelCheckbox
            // 
            this.equipShovelCheckbox.AutoSize = true;
            this.equipShovelCheckbox.Location = new System.Drawing.Point(6, 226);
            this.equipShovelCheckbox.Name = "equipShovelCheckbox";
            this.equipShovelCheckbox.Size = new System.Drawing.Size(59, 17);
            this.equipShovelCheckbox.TabIndex = 13;
            this.equipShovelCheckbox.Text = "Shovel";
            this.equipShovelCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipHammerCheckbox
            // 
            this.equipHammerCheckbox.AutoSize = true;
            this.equipHammerCheckbox.Location = new System.Drawing.Point(6, 203);
            this.equipHammerCheckbox.Name = "equipHammerCheckbox";
            this.equipHammerCheckbox.Size = new System.Drawing.Size(65, 17);
            this.equipHammerCheckbox.TabIndex = 12;
            this.equipHammerCheckbox.Text = "Hammer";
            this.equipHammerCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipLanternCheckbox
            // 
            this.equipLanternCheckbox.AutoSize = true;
            this.equipLanternCheckbox.Location = new System.Drawing.Point(6, 180);
            this.equipLanternCheckbox.Name = "equipLanternCheckbox";
            this.equipLanternCheckbox.Size = new System.Drawing.Size(62, 17);
            this.equipLanternCheckbox.TabIndex = 11;
            this.equipLanternCheckbox.Text = "Lantern";
            this.equipLanternCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipPowderCheckbox
            // 
            this.equipPowderCheckbox.AutoSize = true;
            this.equipPowderCheckbox.Location = new System.Drawing.Point(106, 65);
            this.equipPowderCheckbox.Name = "equipPowderCheckbox";
            this.equipPowderCheckbox.Size = new System.Drawing.Size(94, 17);
            this.equipPowderCheckbox.TabIndex = 10;
            this.equipPowderCheckbox.Text = "Magic Powder";
            this.equipPowderCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipBombosCheckbox
            // 
            this.equipBombosCheckbox.AutoSize = true;
            this.equipBombosCheckbox.Location = new System.Drawing.Point(6, 157);
            this.equipBombosCheckbox.Name = "equipBombosCheckbox";
            this.equipBombosCheckbox.Size = new System.Drawing.Size(64, 17);
            this.equipBombosCheckbox.TabIndex = 9;
            this.equipBombosCheckbox.Text = "Bombos";
            this.equipBombosCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipIcerodCheckbox
            // 
            this.equipIcerodCheckbox.AutoSize = true;
            this.equipIcerodCheckbox.Location = new System.Drawing.Point(106, 134);
            this.equipIcerodCheckbox.Name = "equipIcerodCheckbox";
            this.equipIcerodCheckbox.Size = new System.Drawing.Size(64, 17);
            this.equipIcerodCheckbox.TabIndex = 8;
            this.equipIcerodCheckbox.Text = "Ice Rod";
            this.equipIcerodCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipFirerodCheckbox
            // 
            this.equipFirerodCheckbox.AutoSize = true;
            this.equipFirerodCheckbox.Location = new System.Drawing.Point(6, 134);
            this.equipFirerodCheckbox.Name = "equipFirerodCheckbox";
            this.equipFirerodCheckbox.Size = new System.Drawing.Size(66, 17);
            this.equipFirerodCheckbox.TabIndex = 7;
            this.equipFirerodCheckbox.Text = "Fire Rod";
            this.equipFirerodCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipMushroomCheckbox
            // 
            this.equipMushroomCheckbox.AutoSize = true;
            this.equipMushroomCheckbox.Location = new System.Drawing.Point(6, 111);
            this.equipMushroomCheckbox.Name = "equipMushroomCheckbox";
            this.equipMushroomCheckbox.Size = new System.Drawing.Size(75, 17);
            this.equipMushroomCheckbox.TabIndex = 6;
            this.equipMushroomCheckbox.Text = "Mushroom";
            this.equipMushroomCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipBombsCheckbox
            // 
            this.equipBombsCheckbox.AutoSize = true;
            this.equipBombsCheckbox.Location = new System.Drawing.Point(6, 88);
            this.equipBombsCheckbox.Name = "equipBombsCheckbox";
            this.equipBombsCheckbox.Size = new System.Drawing.Size(58, 17);
            this.equipBombsCheckbox.TabIndex = 5;
            this.equipBombsCheckbox.Text = "Bombs";
            this.equipBombsCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipHookshotCheckbox
            // 
            this.equipHookshotCheckbox.AutoSize = true;
            this.equipHookshotCheckbox.Location = new System.Drawing.Point(6, 65);
            this.equipHookshotCheckbox.Name = "equipHookshotCheckbox";
            this.equipHookshotCheckbox.Size = new System.Drawing.Size(72, 17);
            this.equipHookshotCheckbox.TabIndex = 4;
            this.equipHookshotCheckbox.Text = "Hookshot";
            this.equipHookshotCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipBoomerangredCheckbox
            // 
            this.equipBoomerangredCheckbox.AutoSize = true;
            this.equipBoomerangredCheckbox.Location = new System.Drawing.Point(106, 42);
            this.equipBoomerangredCheckbox.Name = "equipBoomerangredCheckbox";
            this.equipBoomerangredCheckbox.Size = new System.Drawing.Size(103, 17);
            this.equipBoomerangredCheckbox.TabIndex = 3;
            this.equipBoomerangredCheckbox.Text = "Red Boomerang";
            this.equipBoomerangredCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipBoomerangCheckbox
            // 
            this.equipBoomerangCheckbox.AutoSize = true;
            this.equipBoomerangCheckbox.Location = new System.Drawing.Point(6, 42);
            this.equipBoomerangCheckbox.Name = "equipBoomerangCheckbox";
            this.equipBoomerangCheckbox.Size = new System.Drawing.Size(80, 17);
            this.equipBoomerangCheckbox.TabIndex = 2;
            this.equipBoomerangCheckbox.Text = "Boomerang";
            this.equipBoomerangCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipSilverarrowCheckBox
            // 
            this.equipSilverarrowCheckBox.AutoSize = true;
            this.equipSilverarrowCheckBox.Location = new System.Drawing.Point(106, 19);
            this.equipSilverarrowCheckBox.Name = "equipSilverarrowCheckBox";
            this.equipSilverarrowCheckBox.Size = new System.Drawing.Size(82, 17);
            this.equipSilverarrowCheckBox.TabIndex = 1;
            this.equipSilverarrowCheckBox.Text = "Silver Arrow";
            this.equipSilverarrowCheckBox.UseVisualStyleBackColor = true;
            // 
            // equipBowCheckbox
            // 
            this.equipBowCheckbox.AutoSize = true;
            this.equipBowCheckbox.Location = new System.Drawing.Point(6, 19);
            this.equipBowCheckbox.Name = "equipBowCheckbox";
            this.equipBowCheckbox.Size = new System.Drawing.Size(47, 17);
            this.equipBowCheckbox.TabIndex = 0;
            this.equipBowCheckbox.Text = "Bow";
            this.equipBowCheckbox.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.splitContainer5);
            this.tabPage4.Location = new System.Drawing.Point(4, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(292, 548);
            this.tabPage4.TabIndex = 10;
            this.tabPage4.Text = "Sprites";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.spritesListbox);
            this.splitContainer5.Panel1.Controls.Add(this.searchspriteTextbox);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.spritePreviewBox);
            this.splitContainer5.Size = new System.Drawing.Size(292, 548);
            this.splitContainer5.SplitterDistance = 343;
            this.splitContainer5.TabIndex = 0;
            // 
            // spritesListbox
            // 
            this.spritesListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spritesListbox.Enabled = false;
            this.spritesListbox.FormattingEnabled = true;
            this.spritesListbox.Location = new System.Drawing.Point(0, 20);
            this.spritesListbox.Name = "spritesListbox";
            this.spritesListbox.Size = new System.Drawing.Size(292, 323);
            this.spritesListbox.TabIndex = 0;
            this.spritesListbox.SelectedIndexChanged += new System.EventHandler(this.spritesListbox_SelectedIndexChanged);
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
            // spritePreviewBox
            // 
            this.spritePreviewBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.spritePreviewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spritePreviewBox.Location = new System.Drawing.Point(0, 0);
            this.spritePreviewBox.Name = "spritePreviewBox";
            this.spritePreviewBox.Size = new System.Drawing.Size(292, 201);
            this.spritePreviewBox.TabIndex = 0;
            this.spritePreviewBox.TabStop = false;
            // 
            // OverworldPage
            // 
            this.OverworldPage.Controls.Add(this.splitContainer1);
            this.OverworldPage.Location = new System.Drawing.Point(4, 40);
            this.OverworldPage.Name = "OverworldPage";
            this.OverworldPage.Size = new System.Drawing.Size(292, 548);
            this.OverworldPage.TabIndex = 11;
            this.OverworldPage.Text = "Overworld";
            this.OverworldPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.owMapList);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid3);
            this.splitContainer1.Size = new System.Drawing.Size(292, 548);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 16;
            // 
            // owMapList
            // 
            this.owMapList.AllowDrop = true;
            this.owMapList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.owMapList.HideSelection = false;
            this.owMapList.LabelEdit = true;
            this.owMapList.Location = new System.Drawing.Point(0, 27);
            this.owMapList.Name = "owMapList";
            this.owMapList.Size = new System.Drawing.Size(292, 296);
            this.owMapList.TabIndex = 8;
            this.owMapList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.owMapList_NodeMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 27);
            this.panel1.TabIndex = 14;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(82, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 1;
            this.button9.Text = "Import .tmx";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "Export .tmx";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // propertyGrid3
            // 
            this.propertyGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid3.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid3.Name = "propertyGrid3";
            this.propertyGrid3.Size = new System.Drawing.Size(292, 221);
            this.propertyGrid3.TabIndex = 14;
            this.propertyGrid3.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid3_PropertyValueChanged);
            // 
            // selectedGroupbox
            // 
            this.selectedGroupbox.BackColor = System.Drawing.SystemColors.Control;
            this.selectedGroupbox.Controls.Add(this.selectedZUpDown);
            this.selectedGroupbox.Controls.Add(this.label24);
            this.selectedGroupbox.Controls.Add(this.spritepropertyPanel);
            this.selectedGroupbox.Controls.Add(this.selectedLayerNumericUpDown);
            this.selectedGroupbox.Controls.Add(this.label22);
            this.selectedGroupbox.Controls.Add(this.label21);
            this.selectedGroupbox.Controls.Add(this.selectedSizeNumericUpDown);
            this.selectedGroupbox.Controls.Add(this.label19);
            this.selectedGroupbox.Controls.Add(this.selectedYNumericUpDown);
            this.selectedGroupbox.Controls.Add(this.label18);
            this.selectedGroupbox.Controls.Add(this.selectedXNumericUpDown);
            this.selectedGroupbox.Controls.Add(this.doorselectPanel);
            this.selectedGroupbox.Controls.Add(this.potitemobjectPanel);
            this.selectedGroupbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectedGroupbox.Location = new System.Drawing.Point(300, 49);
            this.selectedGroupbox.Name = "selectedGroupbox";
            this.selectedGroupbox.Size = new System.Drawing.Size(544, 69);
            this.selectedGroupbox.TabIndex = 0;
            this.selectedGroupbox.TabStop = false;
            this.selectedGroupbox.Text = "Selected Object : ";
            // 
            // selectedZUpDown
            // 
            this.selectedZUpDown.Location = new System.Drawing.Point(213, 43);
            this.selectedZUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.selectedZUpDown.Name = "selectedZUpDown";
            this.selectedZUpDown.Size = new System.Drawing.Size(59, 20);
            this.selectedZUpDown.TabIndex = 11;
            this.selectedZUpDown.ValueChanged += new System.EventHandler(this.selectedZUpDown_ValueChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(210, 27);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(49, 13);
            this.label24.TabIndex = 10;
            this.label24.Text = "Z Order :";
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
            this.spritepropertyPanel.Size = new System.Drawing.Size(240, 50);
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
            this.comboBox1.Size = new System.Drawing.Size(57, 21);
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
            // selectedLayerNumericUpDown
            // 
            this.selectedLayerNumericUpDown.Location = new System.Drawing.Point(145, 43);
            this.selectedLayerNumericUpDown.Name = "selectedLayerNumericUpDown";
            this.selectedLayerNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.selectedLayerNumericUpDown.TabIndex = 7;
            this.selectedLayerNumericUpDown.ValueChanged += new System.EventHandler(this.selectedXNumericUpDown_ValueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(100, 45);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 13);
            this.label22.TabIndex = 6;
            this.label22.Text = "Layer :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(100, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "Size :";
            // 
            // selectedSizeNumericUpDown
            // 
            this.selectedSizeNumericUpDown.Location = new System.Drawing.Point(145, 17);
            this.selectedSizeNumericUpDown.Name = "selectedSizeNumericUpDown";
            this.selectedSizeNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.selectedSizeNumericUpDown.TabIndex = 4;
            this.selectedSizeNumericUpDown.ValueChanged += new System.EventHandler(this.selectedXNumericUpDown_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Y :";
            // 
            // selectedYNumericUpDown
            // 
            this.selectedYNumericUpDown.Location = new System.Drawing.Point(35, 43);
            this.selectedYNumericUpDown.Name = "selectedYNumericUpDown";
            this.selectedYNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.selectedYNumericUpDown.TabIndex = 2;
            this.selectedYNumericUpDown.ValueChanged += new System.EventHandler(this.selectedXNumericUpDown_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "X :";
            // 
            // selectedXNumericUpDown
            // 
            this.selectedXNumericUpDown.Location = new System.Drawing.Point(35, 19);
            this.selectedXNumericUpDown.Name = "selectedXNumericUpDown";
            this.selectedXNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.selectedXNumericUpDown.TabIndex = 0;
            this.selectedXNumericUpDown.ValueChanged += new System.EventHandler(this.selectedXNumericUpDown_ValueChanged);
            // 
            // doorselectPanel
            // 
            this.doorselectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doorselectPanel.Controls.Add(this.comboBox2);
            this.doorselectPanel.Controls.Add(this.label25);
            this.doorselectPanel.Location = new System.Drawing.Point(301, 16);
            this.doorselectPanel.Name = "doorselectPanel";
            this.doorselectPanel.Size = new System.Drawing.Size(240, 50);
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
            this.comboBox2.Size = new System.Drawing.Size(225, 21);
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
            this.potitemobjectPanel.Size = new System.Drawing.Size(240, 50);
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
            this.selecteditemobjectCombobox.Size = new System.Drawing.Size(225, 21);
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
            // zscreamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(844, 641);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.selectedGroupbox);
            this.Controls.Add(this.toolboxPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "zscreamForm";
            this.Text = "ZScream Magic";
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPicturebox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.entrancetabPage.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.objectstabPage.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.searchobjectPanel.ResumeLayout(false);
            this.searchobjectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewObjectPicturebox)).EndInit();
            this.settingstabPage.ResumeLayout(false);
            this.settingstabPage.PerformLayout();
            this.palettestabPage.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).EndInit();
            this.gfxtabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gfxPicturebox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gfx8NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx7NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx6NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx5NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfxgroupindexUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx4NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx3NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx2NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx1NumericUpDown)).EndInit();
            this.texttabPage.ResumeLayout(false);
            this.texttabPage.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageUpDown)).EndInit();
            this.randoPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rupeeNumericupdown)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spritePreviewBox)).EndInit();
            this.OverworldPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.selectedGroupbox.ResumeLayout(false);
            this.selectedGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedZUpDown)).EndInit();
            this.spritepropertyPanel.ResumeLayout(false);
            this.spritepropertyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritesubtypeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedLayerNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedXNumericUpDown)).EndInit();
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
        private System.Windows.Forms.ToolStripButton allbgsButton;
        private System.Windows.Forms.ToolStripButton bg2modeButton;
        private System.Windows.Forms.ToolStripButton bg3modeButton;
        private System.Windows.Forms.ToolStripButton spritemodeButton;
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
        private System.Windows.Forms.ToolStripButton bg1modeButton;
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
        private System.Windows.Forms.ToolStripMenuItem createProjectFromROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportProjectAsROMToolStripMenuItem;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage roomtabPage;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView roomListView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TabPage entrancetabPage;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView entrancetreeView;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cameraboxCheckbox;
        private System.Windows.Forms.CheckBox entranceposCheckbox;
        private System.Windows.Forms.TabPage objectstabPage;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Panel searchobjectPanel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.PictureBox previewObjectPicturebox;
        private System.Windows.Forms.TabPage settingstabPage;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        public System.Windows.Forms.Label objectinfoLabel;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabPage palettestabPage;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TreeView palettesTreeview;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox palettePicturebox;
        private System.Windows.Forms.TabPage gfxtabPage;
        private System.Windows.Forms.PictureBox gfxPicturebox;
        private System.Windows.Forms.TabPage texttabPage;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox commandstextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox searchtextListbox;
        private System.Windows.Forms.TextBox searchtextTextbox;
        private System.Windows.Forms.Button textpreviewButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown messageUpDown;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox messagetextBox;
        private System.Windows.Forms.TabPage randoPage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown rupeeNumericupdown;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.ComboBox equipBottle4Combobox;
        private System.Windows.Forms.ComboBox equipBottle3Combobox;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ComboBox equipBottle2Combobox;
        private System.Windows.Forms.ComboBox equipBottle1Combobox;
        private System.Windows.Forms.ComboBox equipGlovescomboBox;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox equipMailcomboBox;
        private System.Windows.Forms.ComboBox equipShieldcomboBox;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.CheckBox equipMoonpearlCheckbox;
        private System.Windows.Forms.CheckBox equipFlippersCheckbox;
        private System.Windows.Forms.ComboBox equipSwordcomboBox;
        private System.Windows.Forms.CheckBox equipBootsCheckbox;
        private System.Windows.Forms.CheckBox equipMirrorCheckbox;
        private System.Windows.Forms.CheckBox equipByrnaCheckbox;
        private System.Windows.Forms.CheckBox equipCapeCheckbox;
        private System.Windows.Forms.CheckBox equipSomariaCheckbox;
        private System.Windows.Forms.CheckBox equipFluteactiveCheckbox;
        private System.Windows.Forms.CheckBox equipFluteCheckbox;
        private System.Windows.Forms.CheckBox equipQuakeCheckbox;
        private System.Windows.Forms.CheckBox equipEtherCheckbox;
        private System.Windows.Forms.CheckBox equipBookCheckbox;
        private System.Windows.Forms.CheckBox equipNetCheckbox;
        private System.Windows.Forms.CheckBox equipShovelCheckbox;
        private System.Windows.Forms.CheckBox equipHammerCheckbox;
        private System.Windows.Forms.CheckBox equipLanternCheckbox;
        private System.Windows.Forms.CheckBox equipPowderCheckbox;
        private System.Windows.Forms.CheckBox equipBombosCheckbox;
        private System.Windows.Forms.CheckBox equipIcerodCheckbox;
        private System.Windows.Forms.CheckBox equipFirerodCheckbox;
        private System.Windows.Forms.CheckBox equipMushroomCheckbox;
        private System.Windows.Forms.CheckBox equipBombsCheckbox;
        private System.Windows.Forms.CheckBox equipHookshotCheckbox;
        private System.Windows.Forms.CheckBox equipBoomerangredCheckbox;
        private System.Windows.Forms.CheckBox equipBoomerangCheckbox;
        private System.Windows.Forms.CheckBox equipSilverarrowCheckBox;
        private System.Windows.Forms.CheckBox equipBowCheckbox;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.TextBox searchspriteTextbox;
        private System.Windows.Forms.PictureBox spritePreviewBox;
        public System.Windows.Forms.GroupBox selectedGroupbox;
        public System.Windows.Forms.Panel doorselectPanel;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Panel potitemobjectPanel;
        public System.Windows.Forms.ComboBox selecteditemobjectCombobox;
        public System.Windows.Forms.Label label31;
        public System.Windows.Forms.Panel spritepropertyPanel;
        private System.Windows.Forms.CheckBox spriteoverlordCheckbox;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.NumericUpDown spritesubtypeUpDown;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label label23;
        public System.Windows.Forms.NumericUpDown selectedZUpDown;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.NumericUpDown selectedLayerNumericUpDown;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.NumericUpDown selectedSizeNumericUpDown;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.NumericUpDown selectedYNumericUpDown;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.NumericUpDown selectedXNumericUpDown;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem rightSideToolboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animatedToolStripMenuItem;
        public System.Windows.Forms.ListBox objectsListbox;
        public System.Windows.Forms.ListBox spritesListbox;
        private System.Windows.Forms.ToolStripMenuItem importRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchROMToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown gfx4NumericUpDown;
        private System.Windows.Forms.NumericUpDown gfx3NumericUpDown;
        private System.Windows.Forms.NumericUpDown gfx2NumericUpDown;
        private System.Windows.Forms.NumericUpDown gfx1NumericUpDown;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox gfxgroupCombobox;
        private System.Windows.Forms.NumericUpDown gfx8NumericUpDown;
        private System.Windows.Forms.NumericUpDown gfx7NumericUpDown;
        private System.Windows.Forms.NumericUpDown gfx6NumericUpDown;
        private System.Windows.Forms.NumericUpDown gfx5NumericUpDown;
        private System.Windows.Forms.NumericUpDown gfxgroupindexUpDown;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button gfxfromroomButton;
        public System.Windows.Forms.PictureBox mapPicturebox;
        private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBaseROMToolStripMenuItem;
        private System.Windows.Forms.CheckBox DEBUGEquipmentCheckbox;
        private System.Windows.Forms.CheckBox DEBUGWallCheckbox;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox DEBUGMirrorCheckbox;
        private System.Windows.Forms.TabPage OverworldPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView owMapList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.PropertyGrid mapPropertyGrid;
        public System.Windows.Forms.PropertyGrid propertyGrid3;
    }
}

