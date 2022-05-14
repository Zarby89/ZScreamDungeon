using System.Collections.Generic;
using System.Linq;

namespace ZeldaFullEditor
{
    partial class DungeonMain : System.Windows.Forms.Form
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
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Entrances");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Spawn points");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DungeonMain));
			this.updateTimer = new System.Windows.Forms.Timer(this.components);
			this.spriteImageList = new System.Windows.Forms.ImageList(this.components);
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.nothingselectedcontextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.insertToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.roomProperty_sortsprite = new System.Windows.Forms.CheckBox();
			this.editorsTabControl = new System.Windows.Forms.TabControl();
			this.dungeonPage = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.entrancetabPage = new System.Windows.Forms.TabPage();
			this.entrancetreeView = new System.Windows.Forms.TreeView();
			this.mouseEntranceButton = new System.Windows.Forms.Button();
			this.gridEntranceCheckbox = new System.Windows.Forms.CheckBox();
			this.EntranceMusicBox = new System.Windows.Forms.ComboBox();
			this.EntranceProperties_FloorSel = new System.Windows.Forms.ComboBox();
			this.EntranceProperties_Blockset = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperties_DungeonID = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperties_Entrance = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperties_CameraTriggerY = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperties_CameraTriggerX = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperties_CameraY = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperties_CameraX = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperties_PlayerY = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperties_PlayerX = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperties_RoomID = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.dooryTextbox = new System.Windows.Forms.TextBox();
			this.doorxTextbox = new System.Windows.Forms.TextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.EntranceProperty_BoundaryFE = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperty_BoundaryFW = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperty_BoundaryQE = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperty_BoundaryQW = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperty_BoundaryFS = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperty_BoundaryFN = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperty_BoundaryQS = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.EntranceProperty_BoundaryQN = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.label37 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.doorCheckbox = new System.Windows.Forms.CheckBox();
			this.label27 = new System.Windows.Forms.Label();
			this.entranceProperty_quadbr = new System.Windows.Forms.RadioButton();
			this.entranceProperty_quadtr = new System.Windows.Forms.RadioButton();
			this.entranceProperty_quadbl = new System.Windows.Forms.RadioButton();
			this.entranceProperty_quadtl = new System.Windows.Forms.RadioButton();
			this.label42 = new System.Windows.Forms.Label();
			this.entranceProperty_vscroll = new System.Windows.Forms.CheckBox();
			this.entranceProperty_hscroll = new System.Windows.Forms.CheckBox();
			this.label44 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.entranceProperty_bg = new System.Windows.Forms.CheckBox();
			this.label39 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.objectstabPage = new System.Windows.Forms.TabPage();
			this.favoriteCheckbox = new System.Windows.Forms.CheckBox();
			this.showNameObjectCheckbox = new System.Windows.Forms.CheckBox();
			this.panel1 = new ZeldaFullEditor.CustomPanel();
			this.searchTextbox = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.customPanel1 = new ZeldaFullEditor.CustomPanel();
			this.searchspriteTextbox = new System.Windows.Forms.TextBox();
			this.edit8x8 = new System.Windows.Forms.TabPage();
			this.edit8x8Panel = new System.Windows.Forms.Panel();
			this.editBox8x8 = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.edit8x8palettebox = new System.Windows.Forms.PictureBox();
			this.edit8x8myCheckbox = new System.Windows.Forms.CheckBox();
			this.edit8x8mxCheckbox = new System.Windows.Forms.CheckBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.customPanel3 = new ZeldaFullEditor.CustomPanel();
			this.RoomTabControl = new System.Windows.Forms.TabControl();
			this.panel3 = new System.Windows.Forms.Panel();
			this.mapPicturebox = new System.Windows.Forms.PictureBox();
			this.maphoverCheckbox = new System.Windows.Forms.CheckBox();
			this.mapInfosLabel = new System.Windows.Forms.Label();
			this.thumbnailBox = new System.Windows.Forms.PictureBox();
			this.headerGroupbox = new System.Windows.Forms.GroupBox();
			this.roomHeaderPanel = new System.Windows.Forms.Panel();
			this.label43 = new System.Windows.Forms.Label();
			this.RoomProperties_PreferredEntrance = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.RoomProperty_IsDark = new System.Windows.Forms.CheckBox();
			this.RoomProperty_DestinationStair4 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.RoomProperty_DestinationStair3 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.RoomProperty_DestinationStair2 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.label20 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.RoomProperty_DestinationStair1 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.RoomProperty_DestinationPit = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.RoomProperty_MessageID = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.RoomProperty_SpriteSet = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.RoomProperty_Palette = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.RoomProperty_Floor2 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.RoomProperty_Floor1 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.RoomProperty_Blockset = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.RoomProperty_Layout = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.bg2checkbox5 = new System.Windows.Forms.CheckBox();
			this.label33 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.bg2checkbox4 = new System.Windows.Forms.CheckBox();
			this.bg2checkbox3 = new System.Windows.Forms.CheckBox();
			this.bg2checkbox2 = new System.Windows.Forms.CheckBox();
			this.bg2checkbox1 = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.roomProperty_effect = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.roomPropertyLayerMerge = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.roomProperty_collision = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.roomProperty_pit = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.roomProperty_tag1 = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.roomProperty_tag2 = new System.Windows.Forms.ComboBox();
			this.DoorTypeComboBox = new System.Windows.Forms.ComboBox();
			this.spritepropertyPanel = new System.Windows.Forms.Panel();
			this.spriteoverlordCheckbox = new System.Windows.Forms.CheckBox();
			this.label26 = new System.Windows.Forms.Label();
			this.doorselectPanel = new System.Windows.Forms.Panel();
			this.collisionMapPanel = new System.Windows.Forms.Panel();
			this.tileTypeCombobox = new System.Windows.Forms.ComboBox();
			this.collisionMapLabel = new System.Windows.Forms.Label();
			this.litCheckbox = new System.Windows.Forms.CheckBox();
			this.label25 = new System.Windows.Forms.Label();
			this.spritesubtypeUpDown = new System.Windows.Forms.NumericUpDown();
			this.potitemobjectPanel = new System.Windows.Forms.Panel();
			this.selecteditemobjectCombobox = new System.Windows.Forms.ComboBox();
			this.label31 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label23 = new System.Windows.Forms.Label();
			this.overworldPage = new System.Windows.Forms.TabPage();
			this.OverworldSplitContainer = new System.Windows.Forms.SplitContainer();
			this.OverworldAuxSideTabs = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tilePictureBox = new System.Windows.Forms.PictureBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.scratchPicturebox = new System.Windows.Forms.PictureBox();
			this.Tiles8 = new System.Windows.Forms.TabPage();
			this.panel2 = new System.Windows.Forms.Panel();
			this.Tile8PicBox = new System.Windows.Forms.PictureBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.priorityCheckbox = new System.Windows.Forms.CheckBox();
			this.currentTile8Box = new System.Windows.Forms.PictureBox();
			this.mirrorYCheckbox = new System.Windows.Forms.CheckBox();
			this.palette8Box = new System.Windows.Forms.PictureBox();
			this.mirrorXCheckbox = new System.Windows.Forms.CheckBox();
			this.OWTabExitProps = new System.Windows.Forms.TabPage();
			this.OWExitPanel = new System.Windows.Forms.Panel();
			this.OWExitDisabled = new System.Windows.Forms.Label();
			this.OWExitPropY = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.OWExitPropX = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.OWExitPropID = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.label56 = new System.Windows.Forms.Label();
			this.label57 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.OWTabEntranceProps = new System.Windows.Forms.TabPage();
			this.OWEntrancePanel = new System.Windows.Forms.Panel();
			this.OWEntranceDisabled = new System.Windows.Forms.Label();
			this.OWEntrancePropY = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.OWEntrancePropX = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.OWEntrancePropID = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.label59 = new System.Windows.Forms.Label();
			this.label60 = new System.Windows.Forms.Label();
			this.label61 = new System.Windows.Forms.Label();
			this.OWTabTransportProps = new System.Windows.Forms.TabPage();
			this.OWTransportPanel = new System.Windows.Forms.Panel();
			this.OWTransportDisabled = new System.Windows.Forms.Label();
			this.OWTransportPropY = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.OWTransportPropX = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.OWTransportPropID = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.label62 = new System.Windows.Forms.Label();
			this.label63 = new System.Windows.Forms.Label();
			this.label64 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.owPropertyPanel = new System.Windows.Forms.Panel();
			this.objectGroupbox = new System.Windows.Forms.GroupBox();
			this.OverworldObjectCombobox = new System.Windows.Forms.ComboBox();
			this.mapGroupbox = new System.Windows.Forms.GroupBox();
			this.previewTextPicturebox = new System.Windows.Forms.PictureBox();
			this.OWProperty_MessageID = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.OWProperty_SPRPalette = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.OWProperty_SPRGFX = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.OWProperty_BGPalette = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.OWProperty_BGGFX = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.areaBGColorPictureBox = new System.Windows.Forms.PictureBox();
			this.label49 = new System.Windows.Forms.Label();
			this.largemapCheckbox = new System.Windows.Forms.CheckBox();
			this.OverworldTextButton = new System.Windows.Forms.Button();
			this.musicButton = new System.Windows.Forms.Button();
			this.label50 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.label52 = new System.Windows.Forms.Label();
			this.label53 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.selectedTileLabel = new System.Windows.Forms.Label();
			this.label55 = new System.Windows.Forms.Label();
			this.stateCombobox = new System.Windows.Forms.ComboBox();
			this.GfxEditorPage = new System.Windows.Forms.TabPage();
			this.textPage = new System.Windows.Forms.TabPage();
			this.panel5 = new System.Windows.Forms.Panel();
			this.textListbox = new System.Windows.Forms.ListBox();
			this.label65 = new System.Windows.Forms.Label();
			this.TextSearchTextbox = new System.Windows.Forms.TextBox();
			this.label66 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.ParamsBox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
			this.fontGridBox = new System.Windows.Forms.CheckBox();
			this.BytesDDD = new System.Windows.Forms.Button();
			this.label67 = new System.Windows.Forms.Label();
			this.label68 = new System.Windows.Forms.Label();
			this.label69 = new System.Windows.Forms.Label();
			this.TextCommandList = new System.Windows.Forms.ListBox();
			this.label70 = new System.Windows.Forms.Label();
			this.MessageTextEntry = new System.Windows.Forms.TextBox();
			this.label71 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.SpecialsList = new System.Windows.Forms.ListBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.BigCharPreviewBox = new System.Windows.Forms.PictureBox();
			this.SelectedTileASCII = new System.Windows.Forms.Label();
			this.SelectedTileID = new System.Windows.Forms.Label();
			this.FontWidthUpDown = new System.Windows.Forms.NumericUpDown();
			this.label72 = new System.Windows.Forms.Label();
			this.label73 = new System.Windows.Forms.Label();
			this.label74 = new System.Windows.Forms.Label();
			this.ListDictionaryButton = new System.Windows.Forms.Button();
			this.ImportFontGraphicsButton = new System.Windows.Forms.Button();
			this.ExportFontGraphicsButton = new System.Windows.Forms.Button();
			this.label75 = new System.Windows.Forms.Label();
			this.FontPreviewBox = new System.Windows.Forms.PictureBox();
			this.MessagePreviewBox = new System.Windows.Forms.PictureBox();
			this.ScreenEditor = new System.Windows.Forms.TabPage();
			this.spritesPage = new System.Windows.Forms.TabPage();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.saveButton = new System.Windows.Forms.ToolStripButton();
			this.debugtestButton = new System.Windows.Forms.ToolStripButton();
			this.runtestButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.undoButton = new System.Windows.Forms.ToolStripButton();
			this.redoButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.allbgsButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.bg1modeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.bg2modeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.bg3modeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.underworldSpriteModeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.blockmodeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.torchmodeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.potmodeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.doormodeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.collisionModeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.saveLayoutButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.loadlayoutButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.searchButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.exportuwmapStripButton1 = new ZeldaFullEditor.DungeonToolStripButton();
			this.debugToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.entranceModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.exitModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.itemModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.owSpriteModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.transportModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.overlayButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.gravestoneButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.searchtilesButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.refreshToolStrip = new ZeldaFullEditor.OverworldToolStripButton();
			this.clearmapbutton = new ZeldaFullEditor.OverworldToolStripButton();
			this.fillModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.penModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.spButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.dwButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.lwButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.SelectedObjectNameLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.SelectedObjectXLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.SelectedObjectYLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.SelectedObjectLayerLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.SelectedObjectSizeLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.SelectedObjectDataLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.recentROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.decreaseObjectSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.increaseObjectSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllRoomsForExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deselectedAllRoomsForExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.lockoverworldToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadNamesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.memoryManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.debugRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.roomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gotoRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.removeMaskObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printRoomObjectsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.clearSelectedRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearAllRoomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportAsASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportAllRoomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportSpritesAsBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showRoomsInHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectedObjectInHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoDoorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dungeonViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textChestItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textPotItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.showGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x256ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showBG2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showBG1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unselectedBGTransparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.darkThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.hideSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hideItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hideChestItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showDoorIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showChestsIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disableEntranceGFXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showBG2MaskOutlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.entrancePositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.invisibleObjectsTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showMapIndexInHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.overworldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveZeldaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zeldaSavedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.agahDeadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearEntrancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearAllHolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearExitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearAllOverlaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
			this.areaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearSpritesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.saveZeldaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.zeldaSavedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.agahDeadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.clearItemsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.clearEntrancesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.clearHolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearExitsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.clearOverlaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.overworldViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showEntrancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showExitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTransportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showEntranceExitPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.overworldOverlayVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showGridToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.x8ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.x16ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.x32ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.naviguateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveToRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveToLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveToUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveToDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.openRightRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openLeftRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openUpRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openDownRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.vramViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cGramViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gfxGroupsetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.palettesEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.jPDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mapDataFromJPdoNotUseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.captureMapJPdoNotUseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.exportMapJPdoNotUseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.ExperimentalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.flipMapHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveMapsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveVRAMAsPngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveRoomsToOtherROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.patchNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.UWContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.UWContextInsert = new System.Windows.Forms.ToolStripMenuItem();
			this.UWContextDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.UWContextCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.UWContextCut = new System.Windows.Forms.ToolStripMenuItem();
			this.UWContextPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.UWContextAddToSelection = new System.Windows.Forms.ToolStripMenuItem();
			this.UWContextSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.UWContextSelectNone = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.UWContextSendToFront = new System.Windows.Forms.ToolStripMenuItem();
			this.UWContextSendToBack = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.UWContextSendToLayer1 = new System.Windows.Forms.ToolStripMenuItem();
			this.UWContextSendToLayer2 = new System.Windows.Forms.ToolStripMenuItem();
			this.UWContextSendToLayer3 = new System.Windows.Forms.ToolStripMenuItem();
			this.roomProperty_bg2 = new System.Windows.Forms.ComboBox();
			this.nothingselectedcontextMenu.SuspendLayout();
			this.editorsTabControl.SuspendLayout();
			this.dungeonPage.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.entrancetabPage.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.objectstabPage.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.edit8x8.SuspendLayout();
			this.edit8x8Panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.editBox8x8)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.edit8x8palettebox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mapPicturebox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.thumbnailBox)).BeginInit();
			this.headerGroupbox.SuspendLayout();
			this.roomHeaderPanel.SuspendLayout();
			this.spritepropertyPanel.SuspendLayout();
			this.doorselectPanel.SuspendLayout();
			this.collisionMapPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spritesubtypeUpDown)).BeginInit();
			this.potitemobjectPanel.SuspendLayout();
			this.overworldPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.OverworldSplitContainer)).BeginInit();
			this.OverworldSplitContainer.Panel1.SuspendLayout();
			this.OverworldSplitContainer.Panel2.SuspendLayout();
			this.OverworldSplitContainer.SuspendLayout();
			this.OverworldAuxSideTabs.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tilePictureBox)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scratchPicturebox)).BeginInit();
			this.Tiles8.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Tile8PicBox)).BeginInit();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.currentTile8Box)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.palette8Box)).BeginInit();
			this.OWTabExitProps.SuspendLayout();
			this.OWExitPanel.SuspendLayout();
			this.OWTabEntranceProps.SuspendLayout();
			this.OWEntrancePanel.SuspendLayout();
			this.OWTabTransportProps.SuspendLayout();
			this.OWTransportPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.owPropertyPanel.SuspendLayout();
			this.objectGroupbox.SuspendLayout();
			this.mapGroupbox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.previewTextPicturebox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.areaBGColorPictureBox)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.textPage.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BigCharPreviewBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FontWidthUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FontPreviewBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MessagePreviewBox)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.UWContextMenu.SuspendLayout();
			this.SuspendLayout();
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
            this.insertToolStripMenuItem1,
            this.pasteToolStripMenuItem3,
            this.deleteToolStripMenuItem2,
            this.clearAllToolStripMenuItem});
			this.nothingselectedcontextMenu.Name = "nothingselectedcontextMenu";
			this.nothingselectedcontextMenu.Size = new System.Drawing.Size(125, 92);
			// 
			// insertToolStripMenuItem1
			// 
			this.insertToolStripMenuItem1.Name = "insertToolStripMenuItem1";
			this.insertToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
			this.insertToolStripMenuItem1.Text = "Insert";
			this.insertToolStripMenuItem1.Click += new System.EventHandler(this.insertToolStripMenuItem1_Click);
			// 
			// pasteToolStripMenuItem3
			// 
			this.pasteToolStripMenuItem3.Name = "pasteToolStripMenuItem3";
			this.pasteToolStripMenuItem3.Size = new System.Drawing.Size(124, 22);
			this.pasteToolStripMenuItem3.Text = "Paste";
			this.pasteToolStripMenuItem3.Click += new System.EventHandler(this.PerformPaste);
			// 
			// deleteToolStripMenuItem2
			// 
			this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
			this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
			this.deleteToolStripMenuItem2.Text = "Delete";
			this.deleteToolStripMenuItem2.Click += new System.EventHandler(this.deleteToolStripMenuItem2_Click);
			// 
			// clearAllToolStripMenuItem
			// 
			this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
			this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.clearAllToolStripMenuItem.Text = "Delete All";
			this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 5000;
			this.toolTip1.InitialDelay = 100;
			this.toolTip1.ReshowDelay = 100;
			// 
			// roomProperty_sortsprite
			// 
			this.roomProperty_sortsprite.AutoSize = true;
			this.roomProperty_sortsprite.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.roomProperty_sortsprite.Location = new System.Drawing.Point(302, 62);
			this.roomProperty_sortsprite.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.roomProperty_sortsprite.Name = "roomProperty_sortsprite";
			this.roomProperty_sortsprite.Size = new System.Drawing.Size(91, 17);
			this.roomProperty_sortsprite.TabIndex = 52;
			this.roomProperty_sortsprite.Text = "Layered OAM";
			this.toolTip1.SetToolTip(this.roomProperty_sortsprite, "Must be used in rooms with bridges where sprites can be on top or under bridges\r\n" +
        "also called Sort Sprites in HM");
			this.roomProperty_sortsprite.UseVisualStyleBackColor = true;
			this.roomProperty_sortsprite.CheckedChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// editorsTabControl
			// 
			this.editorsTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.editorsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.editorsTabControl.Controls.Add(this.dungeonPage);
			this.editorsTabControl.Controls.Add(this.overworldPage);
			this.editorsTabControl.Controls.Add(this.GfxEditorPage);
			this.editorsTabControl.Controls.Add(this.textPage);
			this.editorsTabControl.Controls.Add(this.ScreenEditor);
			this.editorsTabControl.Controls.Add(this.spritesPage);
			this.editorsTabControl.Location = new System.Drawing.Point(0, 52);
			this.editorsTabControl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.editorsTabControl.Multiline = true;
			this.editorsTabControl.Name = "editorsTabControl";
			this.editorsTabControl.SelectedIndex = 0;
			this.editorsTabControl.Size = new System.Drawing.Size(1158, 768);
			this.editorsTabControl.TabIndex = 22;
			this.editorsTabControl.TabStop = false;
			this.editorsTabControl.SelectedIndexChanged += new System.EventHandler(this.editorsTabControl_SelectedIndexChanged);
			// 
			// dungeonPage
			// 
			this.dungeonPage.BackColor = System.Drawing.SystemColors.Control;
			this.dungeonPage.Controls.Add(this.tabControl1);
			this.dungeonPage.Controls.Add(this.splitContainer1);
			this.dungeonPage.Controls.Add(this.headerGroupbox);
			this.dungeonPage.Location = new System.Drawing.Point(4, 4);
			this.dungeonPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dungeonPage.Name = "dungeonPage";
			this.dungeonPage.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dungeonPage.Size = new System.Drawing.Size(1150, 742);
			this.dungeonPage.TabIndex = 0;
			this.dungeonPage.Text = "Dungeon Editor";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tabControl1.Controls.Add(this.entrancetabPage);
			this.tabControl1.Controls.Add(this.objectstabPage);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.edit8x8);
			this.tabControl1.Location = new System.Drawing.Point(2, 6);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(298, 740);
			this.tabControl1.TabIndex = 26;
			// 
			// entrancetabPage
			// 
			this.entrancetabPage.Controls.Add(this.entrancetreeView);
			this.entrancetabPage.Controls.Add(this.mouseEntranceButton);
			this.entrancetabPage.Controls.Add(this.gridEntranceCheckbox);
			this.entrancetabPage.Controls.Add(this.EntranceMusicBox);
			this.entrancetabPage.Controls.Add(this.EntranceProperties_FloorSel);
			this.entrancetabPage.Controls.Add(this.EntranceProperties_Blockset);
			this.entrancetabPage.Controls.Add(this.EntranceProperties_DungeonID);
			this.entrancetabPage.Controls.Add(this.EntranceProperties_Entrance);
			this.entrancetabPage.Controls.Add(this.EntranceProperties_CameraTriggerY);
			this.entrancetabPage.Controls.Add(this.EntranceProperties_CameraTriggerX);
			this.entrancetabPage.Controls.Add(this.EntranceProperties_CameraY);
			this.entrancetabPage.Controls.Add(this.EntranceProperties_CameraX);
			this.entrancetabPage.Controls.Add(this.EntranceProperties_PlayerY);
			this.entrancetabPage.Controls.Add(this.EntranceProperties_PlayerX);
			this.entrancetabPage.Controls.Add(this.EntranceProperties_RoomID);
			this.entrancetabPage.Controls.Add(this.dooryTextbox);
			this.entrancetabPage.Controls.Add(this.doorxTextbox);
			this.entrancetabPage.Controls.Add(this.label46);
			this.entrancetabPage.Controls.Add(this.label45);
			this.entrancetabPage.Controls.Add(this.label41);
			this.entrancetabPage.Controls.Add(this.label38);
			this.entrancetabPage.Controls.Add(this.groupBox2);
			this.entrancetabPage.Controls.Add(this.label30);
			this.entrancetabPage.Controls.Add(this.doorCheckbox);
			this.entrancetabPage.Controls.Add(this.label27);
			this.entrancetabPage.Controls.Add(this.entranceProperty_quadbr);
			this.entrancetabPage.Controls.Add(this.entranceProperty_quadtr);
			this.entrancetabPage.Controls.Add(this.entranceProperty_quadbl);
			this.entrancetabPage.Controls.Add(this.entranceProperty_quadtl);
			this.entrancetabPage.Controls.Add(this.label42);
			this.entrancetabPage.Controls.Add(this.entranceProperty_vscroll);
			this.entrancetabPage.Controls.Add(this.entranceProperty_hscroll);
			this.entrancetabPage.Controls.Add(this.label44);
			this.entrancetabPage.Controls.Add(this.label18);
			this.entrancetabPage.Controls.Add(this.label19);
			this.entrancetabPage.Controls.Add(this.label21);
			this.entrancetabPage.Controls.Add(this.entranceProperty_bg);
			this.entrancetabPage.Controls.Add(this.label39);
			this.entrancetabPage.Controls.Add(this.label22);
			this.entrancetabPage.Controls.Add(this.label40);
			this.entrancetabPage.Controls.Add(this.label24);
			this.entrancetabPage.Location = new System.Drawing.Point(4, 22);
			this.entrancetabPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.entrancetabPage.Name = "entrancetabPage";
			this.entrancetabPage.Size = new System.Drawing.Size(290, 714);
			this.entrancetabPage.TabIndex = 5;
			this.entrancetabPage.Text = "Rooms";
			this.entrancetabPage.UseVisualStyleBackColor = true;
			// 
			// entrancetreeView
			// 
			this.entrancetreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.entrancetreeView.HideSelection = false;
			this.entrancetreeView.Location = new System.Drawing.Point(2, 372);
			this.entrancetreeView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.entrancetreeView.Name = "entrancetreeView";
			treeNode3.Name = "EntranceNode";
			treeNode3.Text = "Entrances";
			treeNode4.Name = "StartingEntranceNode";
			treeNode4.Text = "Spawn points";
			this.entrancetreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
			this.entrancetreeView.Size = new System.Drawing.Size(282, 285);
			this.entrancetreeView.TabIndex = 0;
			this.entrancetreeView.TabStop = false;
			// 
			// mouseEntranceButton
			// 
			this.mouseEntranceButton.Location = new System.Drawing.Point(64, 229);
			this.mouseEntranceButton.Name = "mouseEntranceButton";
			this.mouseEntranceButton.Size = new System.Drawing.Size(133, 23);
			this.mouseEntranceButton.TabIndex = 134;
			this.mouseEntranceButton.Text = "Position with mouse";
			this.mouseEntranceButton.UseVisualStyleBackColor = true;
			// 
			// gridEntranceCheckbox
			// 
			this.gridEntranceCheckbox.AutoSize = true;
			this.gridEntranceCheckbox.Location = new System.Drawing.Point(200, 233);
			this.gridEntranceCheckbox.Name = "gridEntranceCheckbox";
			this.gridEntranceCheckbox.Size = new System.Drawing.Size(83, 17);
			this.gridEntranceCheckbox.TabIndex = 179;
			this.gridEntranceCheckbox.Text = "Snap to 8x8";
			this.gridEntranceCheckbox.UseVisualStyleBackColor = true;
			// 
			// EntranceMusicBox
			// 
			this.EntranceMusicBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EntranceMusicBox.FormattingEnabled = true;
			this.EntranceMusicBox.Location = new System.Drawing.Point(64, 202);
			this.EntranceMusicBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceMusicBox.Name = "EntranceMusicBox";
			this.EntranceMusicBox.Size = new System.Drawing.Size(220, 21);
			this.EntranceMusicBox.TabIndex = 178;
			// 
			// EntranceProperties_FloorSel
			// 
			this.EntranceProperties_FloorSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EntranceProperties_FloorSel.FormattingEnabled = true;
			this.EntranceProperties_FloorSel.Location = new System.Drawing.Point(173, 38);
			this.EntranceProperties_FloorSel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperties_FloorSel.Name = "EntranceProperties_FloorSel";
			this.EntranceProperties_FloorSel.Size = new System.Drawing.Size(54, 21);
			this.EntranceProperties_FloorSel.TabIndex = 177;
			// 
			// EntranceProperties_Blockset
			// 
			this.EntranceProperties_Blockset.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperties_Blockset.HexValue = 0;
			this.EntranceProperties_Blockset.Location = new System.Drawing.Point(117, 38);
			this.EntranceProperties_Blockset.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperties_Blockset.MaxLength = 2;
			this.EntranceProperties_Blockset.Name = "EntranceProperties_Blockset";
			this.EntranceProperties_Blockset.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.EntranceProperties_Blockset.Size = new System.Drawing.Size(50, 20);
			this.EntranceProperties_Blockset.TabIndex = 176;
			this.EntranceProperties_Blockset.Text = "00";
			this.EntranceProperties_Blockset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperties_DungeonID
			// 
			this.EntranceProperties_DungeonID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperties_DungeonID.HexValue = 0;
			this.EntranceProperties_DungeonID.Location = new System.Drawing.Point(61, 38);
			this.EntranceProperties_DungeonID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperties_DungeonID.MaxLength = 2;
			this.EntranceProperties_DungeonID.Name = "EntranceProperties_DungeonID";
			this.EntranceProperties_DungeonID.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.EntranceProperties_DungeonID.Size = new System.Drawing.Size(50, 20);
			this.EntranceProperties_DungeonID.TabIndex = 175;
			this.EntranceProperties_DungeonID.Text = "00";
			this.EntranceProperties_DungeonID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperties_Entrance
			// 
			this.EntranceProperties_Entrance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperties_Entrance.HexValue = 0;
			this.EntranceProperties_Entrance.Location = new System.Drawing.Point(234, 38);
			this.EntranceProperties_Entrance.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperties_Entrance.MaxLength = 2;
			this.EntranceProperties_Entrance.Name = "EntranceProperties_Entrance";
			this.EntranceProperties_Entrance.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.EntranceProperties_Entrance.Size = new System.Drawing.Size(50, 20);
			this.EntranceProperties_Entrance.TabIndex = 174;
			this.EntranceProperties_Entrance.Text = "00";
			this.EntranceProperties_Entrance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperties_CameraTriggerY
			// 
			this.EntranceProperties_CameraTriggerY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperties_CameraTriggerY.HexValue = 0;
			this.EntranceProperties_CameraTriggerY.Location = new System.Drawing.Point(130, 128);
			this.EntranceProperties_CameraTriggerY.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperties_CameraTriggerY.MaxLength = 4;
			this.EntranceProperties_CameraTriggerY.Name = "EntranceProperties_CameraTriggerY";
			this.EntranceProperties_CameraTriggerY.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 65535);
			this.EntranceProperties_CameraTriggerY.Size = new System.Drawing.Size(44, 20);
			this.EntranceProperties_CameraTriggerY.TabIndex = 173;
			this.EntranceProperties_CameraTriggerY.Text = "0000";
			this.EntranceProperties_CameraTriggerY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperties_CameraTriggerX
			// 
			this.EntranceProperties_CameraTriggerX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperties_CameraTriggerX.HexValue = 0;
			this.EntranceProperties_CameraTriggerX.Location = new System.Drawing.Point(67, 128);
			this.EntranceProperties_CameraTriggerX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperties_CameraTriggerX.MaxLength = 4;
			this.EntranceProperties_CameraTriggerX.Name = "EntranceProperties_CameraTriggerX";
			this.EntranceProperties_CameraTriggerX.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 65535);
			this.EntranceProperties_CameraTriggerX.Size = new System.Drawing.Size(44, 20);
			this.EntranceProperties_CameraTriggerX.TabIndex = 172;
			this.EntranceProperties_CameraTriggerX.Text = "0000";
			this.EntranceProperties_CameraTriggerX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperties_CameraY
			// 
			this.EntranceProperties_CameraY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperties_CameraY.HexValue = 0;
			this.EntranceProperties_CameraY.Location = new System.Drawing.Point(130, 103);
			this.EntranceProperties_CameraY.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperties_CameraY.MaxLength = 4;
			this.EntranceProperties_CameraY.Name = "EntranceProperties_CameraY";
			this.EntranceProperties_CameraY.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 65535);
			this.EntranceProperties_CameraY.Size = new System.Drawing.Size(44, 20);
			this.EntranceProperties_CameraY.TabIndex = 169;
			this.EntranceProperties_CameraY.Text = "0000";
			this.EntranceProperties_CameraY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperties_CameraX
			// 
			this.EntranceProperties_CameraX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperties_CameraX.HexValue = 0;
			this.EntranceProperties_CameraX.Location = new System.Drawing.Point(67, 103);
			this.EntranceProperties_CameraX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperties_CameraX.MaxLength = 4;
			this.EntranceProperties_CameraX.Name = "EntranceProperties_CameraX";
			this.EntranceProperties_CameraX.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 65535);
			this.EntranceProperties_CameraX.Size = new System.Drawing.Size(44, 20);
			this.EntranceProperties_CameraX.TabIndex = 168;
			this.EntranceProperties_CameraX.Text = "0000";
			this.EntranceProperties_CameraX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperties_PlayerY
			// 
			this.EntranceProperties_PlayerY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperties_PlayerY.HexValue = 0;
			this.EntranceProperties_PlayerY.Location = new System.Drawing.Point(130, 78);
			this.EntranceProperties_PlayerY.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperties_PlayerY.MaxLength = 4;
			this.EntranceProperties_PlayerY.Name = "EntranceProperties_PlayerY";
			this.EntranceProperties_PlayerY.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 65535);
			this.EntranceProperties_PlayerY.Size = new System.Drawing.Size(44, 20);
			this.EntranceProperties_PlayerY.TabIndex = 167;
			this.EntranceProperties_PlayerY.Text = "0000";
			this.EntranceProperties_PlayerY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperties_PlayerX
			// 
			this.EntranceProperties_PlayerX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperties_PlayerX.HexValue = 0;
			this.EntranceProperties_PlayerX.Location = new System.Drawing.Point(67, 78);
			this.EntranceProperties_PlayerX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperties_PlayerX.MaxLength = 4;
			this.EntranceProperties_PlayerX.Name = "EntranceProperties_PlayerX";
			this.EntranceProperties_PlayerX.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 65535);
			this.EntranceProperties_PlayerX.Size = new System.Drawing.Size(44, 20);
			this.EntranceProperties_PlayerX.TabIndex = 166;
			this.EntranceProperties_PlayerX.Text = "0000";
			this.EntranceProperties_PlayerX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperties_RoomID
			// 
			this.EntranceProperties_RoomID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperties_RoomID.HexValue = 0;
			this.EntranceProperties_RoomID.Location = new System.Drawing.Point(5, 38);
			this.EntranceProperties_RoomID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperties_RoomID.MaxLength = 2;
			this.EntranceProperties_RoomID.Name = "EntranceProperties_RoomID";
			this.EntranceProperties_RoomID.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.EntranceProperties_RoomID.Size = new System.Drawing.Size(50, 20);
			this.EntranceProperties_RoomID.TabIndex = 163;
			this.EntranceProperties_RoomID.Text = "00";
			this.EntranceProperties_RoomID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// dooryTextbox
			// 
			this.dooryTextbox.Location = new System.Drawing.Point(130, 177);
			this.dooryTextbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dooryTextbox.Name = "dooryTextbox";
			this.dooryTextbox.Size = new System.Drawing.Size(44, 20);
			this.dooryTextbox.TabIndex = 159;
			this.dooryTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// doorxTextbox
			// 
			this.doorxTextbox.Location = new System.Drawing.Point(67, 177);
			this.doorxTextbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.doorxTextbox.Name = "doorxTextbox";
			this.doorxTextbox.Size = new System.Drawing.Size(44, 20);
			this.doorxTextbox.TabIndex = 158;
			this.doorxTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label46
			// 
			this.label46.AutoSize = true;
			this.label46.Location = new System.Drawing.Point(17, 105);
			this.label46.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(43, 13);
			this.label46.TabIndex = 171;
			this.label46.Text = "Camera";
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.Location = new System.Drawing.Point(24, 84);
			this.label45.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(36, 13);
			this.label45.TabIndex = 170;
			this.label45.Text = "Player";
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(143, 62);
			this.label41.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(14, 13);
			this.label41.TabIndex = 165;
			this.label41.Text = "Y";
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(83, 62);
			this.label38.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(14, 13);
			this.label38.TabIndex = 164;
			this.label38.Text = "X";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.EntranceProperty_BoundaryFE);
			this.groupBox2.Controls.Add(this.EntranceProperty_BoundaryFW);
			this.groupBox2.Controls.Add(this.EntranceProperty_BoundaryQE);
			this.groupBox2.Controls.Add(this.EntranceProperty_BoundaryQW);
			this.groupBox2.Controls.Add(this.EntranceProperty_BoundaryFS);
			this.groupBox2.Controls.Add(this.EntranceProperty_BoundaryFN);
			this.groupBox2.Controls.Add(this.EntranceProperty_BoundaryQS);
			this.groupBox2.Controls.Add(this.EntranceProperty_BoundaryQN);
			this.groupBox2.Controls.Add(this.label37);
			this.groupBox2.Controls.Add(this.label36);
			this.groupBox2.Controls.Add(this.label35);
			this.groupBox2.Controls.Add(this.label34);
			this.groupBox2.Controls.Add(this.label32);
			this.groupBox2.Controls.Add(this.label29);
			this.groupBox2.Location = new System.Drawing.Point(4, 266);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupBox2.Size = new System.Drawing.Size(280, 94);
			this.groupBox2.TabIndex = 162;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Camera boundaries";
			// 
			// EntranceProperty_BoundaryFE
			// 
			this.EntranceProperty_BoundaryFE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperty_BoundaryFE.HexValue = 0;
			this.EntranceProperty_BoundaryFE.Location = new System.Drawing.Point(226, 62);
			this.EntranceProperty_BoundaryFE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperty_BoundaryFE.MaxLength = 2;
			this.EntranceProperty_BoundaryFE.Name = "EntranceProperty_BoundaryFE";
			this.EntranceProperty_BoundaryFE.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.EntranceProperty_BoundaryFE.Size = new System.Drawing.Size(39, 20);
			this.EntranceProperty_BoundaryFE.TabIndex = 133;
			this.EntranceProperty_BoundaryFE.Text = "00";
			this.EntranceProperty_BoundaryFE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperty_BoundaryFW
			// 
			this.EntranceProperty_BoundaryFW.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperty_BoundaryFW.HexValue = 0;
			this.EntranceProperty_BoundaryFW.Location = new System.Drawing.Point(169, 62);
			this.EntranceProperty_BoundaryFW.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperty_BoundaryFW.MaxLength = 2;
			this.EntranceProperty_BoundaryFW.Name = "EntranceProperty_BoundaryFW";
			this.EntranceProperty_BoundaryFW.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.EntranceProperty_BoundaryFW.Size = new System.Drawing.Size(39, 20);
			this.EntranceProperty_BoundaryFW.TabIndex = 132;
			this.EntranceProperty_BoundaryFW.Text = "00";
			this.EntranceProperty_BoundaryFW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperty_BoundaryQE
			// 
			this.EntranceProperty_BoundaryQE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperty_BoundaryQE.HexValue = 0;
			this.EntranceProperty_BoundaryQE.Location = new System.Drawing.Point(226, 36);
			this.EntranceProperty_BoundaryQE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperty_BoundaryQE.MaxLength = 2;
			this.EntranceProperty_BoundaryQE.Name = "EntranceProperty_BoundaryQE";
			this.EntranceProperty_BoundaryQE.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.EntranceProperty_BoundaryQE.Size = new System.Drawing.Size(39, 20);
			this.EntranceProperty_BoundaryQE.TabIndex = 131;
			this.EntranceProperty_BoundaryQE.Text = "00";
			this.EntranceProperty_BoundaryQE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperty_BoundaryQW
			// 
			this.EntranceProperty_BoundaryQW.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperty_BoundaryQW.HexValue = 0;
			this.EntranceProperty_BoundaryQW.Location = new System.Drawing.Point(169, 36);
			this.EntranceProperty_BoundaryQW.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperty_BoundaryQW.MaxLength = 2;
			this.EntranceProperty_BoundaryQW.Name = "EntranceProperty_BoundaryQW";
			this.EntranceProperty_BoundaryQW.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.EntranceProperty_BoundaryQW.Size = new System.Drawing.Size(39, 20);
			this.EntranceProperty_BoundaryQW.TabIndex = 130;
			this.EntranceProperty_BoundaryQW.Text = "00";
			this.EntranceProperty_BoundaryQW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperty_BoundaryFS
			// 
			this.EntranceProperty_BoundaryFS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperty_BoundaryFS.HexValue = 0;
			this.EntranceProperty_BoundaryFS.Location = new System.Drawing.Point(116, 62);
			this.EntranceProperty_BoundaryFS.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperty_BoundaryFS.MaxLength = 2;
			this.EntranceProperty_BoundaryFS.Name = "EntranceProperty_BoundaryFS";
			this.EntranceProperty_BoundaryFS.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.EntranceProperty_BoundaryFS.Size = new System.Drawing.Size(39, 20);
			this.EntranceProperty_BoundaryFS.TabIndex = 129;
			this.EntranceProperty_BoundaryFS.Text = "00";
			this.EntranceProperty_BoundaryFS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperty_BoundaryFN
			// 
			this.EntranceProperty_BoundaryFN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperty_BoundaryFN.HexValue = 0;
			this.EntranceProperty_BoundaryFN.Location = new System.Drawing.Point(60, 62);
			this.EntranceProperty_BoundaryFN.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperty_BoundaryFN.MaxLength = 2;
			this.EntranceProperty_BoundaryFN.Name = "EntranceProperty_BoundaryFN";
			this.EntranceProperty_BoundaryFN.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.EntranceProperty_BoundaryFN.Size = new System.Drawing.Size(39, 20);
			this.EntranceProperty_BoundaryFN.TabIndex = 128;
			this.EntranceProperty_BoundaryFN.Text = "00";
			this.EntranceProperty_BoundaryFN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperty_BoundaryQS
			// 
			this.EntranceProperty_BoundaryQS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperty_BoundaryQS.HexValue = 0;
			this.EntranceProperty_BoundaryQS.Location = new System.Drawing.Point(116, 36);
			this.EntranceProperty_BoundaryQS.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperty_BoundaryQS.MaxLength = 2;
			this.EntranceProperty_BoundaryQS.Name = "EntranceProperty_BoundaryQS";
			this.EntranceProperty_BoundaryQS.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.EntranceProperty_BoundaryQS.Size = new System.Drawing.Size(39, 20);
			this.EntranceProperty_BoundaryQS.TabIndex = 127;
			this.EntranceProperty_BoundaryQS.Text = "00";
			this.EntranceProperty_BoundaryQS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EntranceProperty_BoundaryQN
			// 
			this.EntranceProperty_BoundaryQN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.EntranceProperty_BoundaryQN.HexValue = 0;
			this.EntranceProperty_BoundaryQN.Location = new System.Drawing.Point(60, 36);
			this.EntranceProperty_BoundaryQN.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.EntranceProperty_BoundaryQN.MaxLength = 2;
			this.EntranceProperty_BoundaryQN.Name = "EntranceProperty_BoundaryQN";
			this.EntranceProperty_BoundaryQN.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.EntranceProperty_BoundaryQN.Size = new System.Drawing.Size(39, 20);
			this.EntranceProperty_BoundaryQN.TabIndex = 126;
			this.EntranceProperty_BoundaryQN.Text = "00";
			this.EntranceProperty_BoundaryQN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(11, 64);
			this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(49, 13);
			this.label37.TabIndex = 125;
			this.label37.Text = "Full room";
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.Location = new System.Drawing.Point(9, 38);
			this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(51, 13);
			this.label36.TabIndex = 124;
			this.label36.Text = "Quadrant";
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Location = new System.Drawing.Point(227, 18);
			this.label35.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(28, 13);
			this.label35.TabIndex = 123;
			this.label35.Text = "East";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(172, 18);
			this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(32, 13);
			this.label34.TabIndex = 122;
			this.label34.Text = "West";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(117, 18);
			this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(35, 13);
			this.label32.TabIndex = 121;
			this.label32.Text = "South";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(63, 18);
			this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(33, 13);
			this.label29.TabIndex = 120;
			this.label29.Text = "North";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(13, 155);
			this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(47, 13);
			this.label30.TabIndex = 161;
			this.label30.Text = "Scrolling";
			// 
			// doorCheckbox
			// 
			this.doorCheckbox.AutoSize = true;
			this.doorCheckbox.Location = new System.Drawing.Point(191, 179);
			this.doorCheckbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.doorCheckbox.Name = "doorCheckbox";
			this.doorCheckbox.Size = new System.Drawing.Size(69, 17);
			this.doorCheckbox.TabIndex = 160;
			this.doorCheckbox.Text = "Use door";
			this.doorCheckbox.UseVisualStyleBackColor = true;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(10, 180);
			this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(50, 13);
			this.label27.TabIndex = 157;
			this.label27.Text = "OW door";
			// 
			// entranceProperty_quadbr
			// 
			this.entranceProperty_quadbr.AutoSize = true;
			this.entranceProperty_quadbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.entranceProperty_quadbr.Location = new System.Drawing.Point(241, 149);
			this.entranceProperty_quadbr.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.entranceProperty_quadbr.Name = "entranceProperty_quadbr";
			this.entranceProperty_quadbr.Size = new System.Drawing.Size(42, 28);
			this.entranceProperty_quadbr.TabIndex = 156;
			this.entranceProperty_quadbr.TabStop = true;
			this.entranceProperty_quadbr.Text = "◲";
			this.entranceProperty_quadbr.UseVisualStyleBackColor = true;
			// 
			// entranceProperty_quadtr
			// 
			this.entranceProperty_quadtr.AutoSize = true;
			this.entranceProperty_quadtr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.entranceProperty_quadtr.Location = new System.Drawing.Point(241, 125);
			this.entranceProperty_quadtr.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.entranceProperty_quadtr.Name = "entranceProperty_quadtr";
			this.entranceProperty_quadtr.Size = new System.Drawing.Size(42, 28);
			this.entranceProperty_quadtr.TabIndex = 155;
			this.entranceProperty_quadtr.TabStop = true;
			this.entranceProperty_quadtr.Text = "◳";
			this.entranceProperty_quadtr.UseVisualStyleBackColor = true;
			// 
			// entranceProperty_quadbl
			// 
			this.entranceProperty_quadbl.AutoSize = true;
			this.entranceProperty_quadbl.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.entranceProperty_quadbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.entranceProperty_quadbl.Location = new System.Drawing.Point(186, 149);
			this.entranceProperty_quadbl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.entranceProperty_quadbl.Name = "entranceProperty_quadbl";
			this.entranceProperty_quadbl.Size = new System.Drawing.Size(42, 28);
			this.entranceProperty_quadbl.TabIndex = 154;
			this.entranceProperty_quadbl.TabStop = true;
			this.entranceProperty_quadbl.Text = "◱";
			this.entranceProperty_quadbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.entranceProperty_quadbl.UseVisualStyleBackColor = true;
			// 
			// entranceProperty_quadtl
			// 
			this.entranceProperty_quadtl.AutoSize = true;
			this.entranceProperty_quadtl.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.entranceProperty_quadtl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.entranceProperty_quadtl.Location = new System.Drawing.Point(186, 125);
			this.entranceProperty_quadtl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.entranceProperty_quadtl.Name = "entranceProperty_quadtl";
			this.entranceProperty_quadtl.Size = new System.Drawing.Size(42, 28);
			this.entranceProperty_quadtl.TabIndex = 153;
			this.entranceProperty_quadtl.TabStop = true;
			this.entranceProperty_quadtl.Text = "◰";
			this.entranceProperty_quadtl.UseVisualStyleBackColor = true;
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.Location = new System.Drawing.Point(209, 110);
			this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(51, 13);
			this.label42.TabIndex = 152;
			this.label42.Text = "Quadrant";
			// 
			// entranceProperty_vscroll
			// 
			this.entranceProperty_vscroll.AutoSize = true;
			this.entranceProperty_vscroll.Location = new System.Drawing.Point(130, 154);
			this.entranceProperty_vscroll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.entranceProperty_vscroll.Name = "entranceProperty_vscroll";
			this.entranceProperty_vscroll.Size = new System.Drawing.Size(54, 17);
			this.entranceProperty_vscroll.TabIndex = 151;
			this.entranceProperty_vscroll.Text = "Y-axis";
			this.entranceProperty_vscroll.UseVisualStyleBackColor = true;
			// 
			// entranceProperty_hscroll
			// 
			this.entranceProperty_hscroll.AutoSize = true;
			this.entranceProperty_hscroll.Location = new System.Drawing.Point(67, 154);
			this.entranceProperty_hscroll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.entranceProperty_hscroll.Name = "entranceProperty_hscroll";
			this.entranceProperty_hscroll.Size = new System.Drawing.Size(54, 17);
			this.entranceProperty_hscroll.TabIndex = 150;
			this.entranceProperty_hscroll.Text = "X-axis";
			this.entranceProperty_hscroll.UseVisualStyleBackColor = true;
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(15, 130);
			this.label44.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(45, 13);
			this.label44.TabIndex = 149;
			this.label44.Text = "Scroll at";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label18.Location = new System.Drawing.Point(7, 2);
			this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(171, 13);
			this.label18.TabIndex = 141;
			this.label18.Text = "Selected entrance properties";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(7, 22);
			this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(49, 13);
			this.label19.TabIndex = 142;
			this.label19.Text = "Room ID";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(173, 22);
			this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(30, 13);
			this.label21.TabIndex = 143;
			this.label21.Text = "Floor";
			// 
			// entranceProperty_bg
			// 
			this.entranceProperty_bg.AutoSize = true;
			this.entranceProperty_bg.Location = new System.Drawing.Point(213, 69);
			this.entranceProperty_bg.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.entranceProperty_bg.Name = "entranceProperty_bg";
			this.entranceProperty_bg.Size = new System.Drawing.Size(61, 17);
			this.entranceProperty_bg.TabIndex = 148;
			this.entranceProperty_bg.Text = "Layer 2";
			this.entranceProperty_bg.UseVisualStyleBackColor = true;
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(237, 23);
			this.label39.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(50, 13);
			this.label39.TabIndex = 147;
			this.label39.Text = "Entrance";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(57, 22);
			this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(65, 13);
			this.label22.TabIndex = 144;
			this.label22.Text = "Dungeon ID";
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Location = new System.Drawing.Point(119, 22);
			this.label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(48, 13);
			this.label40.TabIndex = 146;
			this.label40.Text = "Blockset";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(21, 205);
			this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(35, 13);
			this.label24.TabIndex = 145;
			this.label24.Text = "Music";
			// 
			// objectstabPage
			// 
			this.objectstabPage.Controls.Add(this.favoriteCheckbox);
			this.objectstabPage.Controls.Add(this.showNameObjectCheckbox);
			this.objectstabPage.Controls.Add(this.panel1);
			this.objectstabPage.Controls.Add(this.searchTextbox);
			this.objectstabPage.Location = new System.Drawing.Point(4, 24);
			this.objectstabPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.objectstabPage.Name = "objectstabPage";
			this.objectstabPage.Size = new System.Drawing.Size(290, 710);
			this.objectstabPage.TabIndex = 4;
			this.objectstabPage.Text = "Objects";
			this.objectstabPage.UseVisualStyleBackColor = true;
			// 
			// favoriteCheckbox
			// 
			this.favoriteCheckbox.AutoSize = true;
			this.favoriteCheckbox.Dock = System.Windows.Forms.DockStyle.Top;
			this.favoriteCheckbox.Location = new System.Drawing.Point(0, 37);
			this.favoriteCheckbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.favoriteCheckbox.Name = "favoriteCheckbox";
			this.favoriteCheckbox.Size = new System.Drawing.Size(290, 17);
			this.favoriteCheckbox.TabIndex = 2;
			this.favoriteCheckbox.Text = "Show favorites";
			this.favoriteCheckbox.UseVisualStyleBackColor = true;
			// 
			// showNameObjectCheckbox
			// 
			this.showNameObjectCheckbox.AutoSize = true;
			this.showNameObjectCheckbox.Dock = System.Windows.Forms.DockStyle.Top;
			this.showNameObjectCheckbox.Location = new System.Drawing.Point(0, 20);
			this.showNameObjectCheckbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.showNameObjectCheckbox.Name = "showNameObjectCheckbox";
			this.showNameObjectCheckbox.Size = new System.Drawing.Size(290, 17);
			this.showNameObjectCheckbox.TabIndex = 1;
			this.showNameObjectCheckbox.Text = "Show names";
			this.showNameObjectCheckbox.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 20);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(292, 600);
			this.panel1.TabIndex = 1;
			// 
			// searchTextbox
			// 
			this.searchTextbox.Dock = System.Windows.Forms.DockStyle.Top;
			this.searchTextbox.Location = new System.Drawing.Point(0, 0);
			this.searchTextbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.searchTextbox.Name = "searchTextbox";
			this.searchTextbox.Size = new System.Drawing.Size(290, 20);
			this.searchTextbox.TabIndex = 0;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.customPanel1);
			this.tabPage4.Controls.Add(this.searchspriteTextbox);
			this.tabPage4.Location = new System.Drawing.Point(4, 24);
			this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(290, 710);
			this.tabPage4.TabIndex = 10;
			this.tabPage4.Text = "Sprites";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// customPanel1
			// 
			this.customPanel1.AutoScroll = true;
			this.customPanel1.Location = new System.Drawing.Point(0, 20);
			this.customPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.customPanel1.Name = "customPanel1";
			this.customPanel1.Size = new System.Drawing.Size(292, 600);
			this.customPanel1.TabIndex = 2;
			// 
			// searchspriteTextbox
			// 
			this.searchspriteTextbox.Dock = System.Windows.Forms.DockStyle.Top;
			this.searchspriteTextbox.Location = new System.Drawing.Point(0, 0);
			this.searchspriteTextbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.searchspriteTextbox.Name = "searchspriteTextbox";
			this.searchspriteTextbox.Size = new System.Drawing.Size(290, 20);
			this.searchspriteTextbox.TabIndex = 1;
			// 
			// edit8x8
			// 
			this.edit8x8.AutoScroll = true;
			this.edit8x8.Controls.Add(this.edit8x8Panel);
			this.edit8x8.Controls.Add(this.groupBox1);
			this.edit8x8.Location = new System.Drawing.Point(4, 24);
			this.edit8x8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.edit8x8.Name = "edit8x8";
			this.edit8x8.Size = new System.Drawing.Size(290, 710);
			this.edit8x8.TabIndex = 11;
			this.edit8x8.Text = "8x8 tiles";
			this.edit8x8.UseVisualStyleBackColor = true;
			// 
			// edit8x8Panel
			// 
			this.edit8x8Panel.AutoScroll = true;
			this.edit8x8Panel.Controls.Add(this.editBox8x8);
			this.edit8x8Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edit8x8Panel.Location = new System.Drawing.Point(0, 0);
			this.edit8x8Panel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.edit8x8Panel.Name = "edit8x8Panel";
			this.edit8x8Panel.Size = new System.Drawing.Size(290, 924);
			this.edit8x8Panel.TabIndex = 2;
			// 
			// editBox8x8
			// 
			this.editBox8x8.Location = new System.Drawing.Point(8, 3);
			this.editBox8x8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.editBox8x8.Name = "editBox8x8";
			this.editBox8x8.Size = new System.Drawing.Size(256, 624);
			this.editBox8x8.TabIndex = 0;
			this.editBox8x8.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this.edit8x8palettebox);
			this.groupBox1.Controls.Add(this.edit8x8myCheckbox);
			this.groupBox1.Controls.Add(this.edit8x8mxCheckbox);
			this.groupBox1.Location = new System.Drawing.Point(0, 719);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupBox1.Size = new System.Drawing.Size(290, 205);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tile properties";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(74, 18);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(57, 17);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Priority";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// edit8x8palettebox
			// 
			this.edit8x8palettebox.Location = new System.Drawing.Point(6, 65);
			this.edit8x8palettebox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.edit8x8palettebox.Name = "edit8x8palettebox";
			this.edit8x8palettebox.Size = new System.Drawing.Size(256, 128);
			this.edit8x8palettebox.TabIndex = 2;
			this.edit8x8palettebox.TabStop = false;
			// 
			// edit8x8myCheckbox
			// 
			this.edit8x8myCheckbox.AutoSize = true;
			this.edit8x8myCheckbox.Location = new System.Drawing.Point(6, 42);
			this.edit8x8myCheckbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.edit8x8myCheckbox.Name = "edit8x8myCheckbox";
			this.edit8x8myCheckbox.Size = new System.Drawing.Size(52, 17);
			this.edit8x8myCheckbox.TabIndex = 1;
			this.edit8x8myCheckbox.Text = "Flip Y";
			this.edit8x8myCheckbox.UseVisualStyleBackColor = true;
			// 
			// edit8x8mxCheckbox
			// 
			this.edit8x8mxCheckbox.AutoSize = true;
			this.edit8x8mxCheckbox.Location = new System.Drawing.Point(6, 18);
			this.edit8x8mxCheckbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.edit8x8mxCheckbox.Name = "edit8x8mxCheckbox";
			this.edit8x8mxCheckbox.Size = new System.Drawing.Size(52, 17);
			this.edit8x8mxCheckbox.TabIndex = 0;
			this.edit8x8mxCheckbox.Text = "Flip X";
			this.edit8x8mxCheckbox.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Location = new System.Drawing.Point(302, 149);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.customPanel3);
			this.splitContainer1.Panel1.Controls.Add(this.RoomTabControl);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel3);
			this.splitContainer1.Panel2MinSize = 267;
			this.splitContainer1.Size = new System.Drawing.Size(845, 541);
			this.splitContainer1.SplitterDistance = 536;
			this.splitContainer1.TabIndex = 25;
			// 
			// customPanel3
			// 
			this.customPanel3.AutoScroll = true;
			this.customPanel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.customPanel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.customPanel3.Location = new System.Drawing.Point(16, 24);
			this.customPanel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.customPanel3.Name = "customPanel3";
			this.customPanel3.Size = new System.Drawing.Size(512, 512);
			this.customPanel3.TabIndex = 19;
			// 
			// RoomTabControl
			// 
			this.RoomTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.RoomTabControl.HotTrack = true;
			this.RoomTabControl.ItemSize = new System.Drawing.Size(48, 18);
			this.RoomTabControl.Location = new System.Drawing.Point(14, 0);
			this.RoomTabControl.Margin = new System.Windows.Forms.Padding(0);
			this.RoomTabControl.Name = "RoomTabControl";
			this.RoomTabControl.Padding = new System.Drawing.Point(3, 3);
			this.RoomTabControl.SelectedIndex = 0;
			this.RoomTabControl.Size = new System.Drawing.Size(522, 21);
			this.RoomTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.RoomTabControl.TabIndex = 17;
			this.RoomTabControl.SelectedIndexChanged += new System.EventHandler(this.RoomTabControl_SelectedIndexChanged);
			this.RoomTabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RoomTabControl_MouseClick);
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BackColor = System.Drawing.SystemColors.Control;
			this.panel3.Controls.Add(this.mapPicturebox);
			this.panel3.Controls.Add(this.maphoverCheckbox);
			this.panel3.Controls.Add(this.mapInfosLabel);
			this.panel3.Controls.Add(this.thumbnailBox);
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(305, 514);
			this.panel3.TabIndex = 64;
			// 
			// mapPicturebox
			// 
			this.mapPicturebox.Location = new System.Drawing.Point(2, 5);
			this.mapPicturebox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.mapPicturebox.Name = "mapPicturebox";
			this.mapPicturebox.Size = new System.Drawing.Size(256, 312);
			this.mapPicturebox.TabIndex = 61;
			this.mapPicturebox.TabStop = false;
			this.mapPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPicturebox_Paint);
			this.mapPicturebox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mapPicturebox_MouseDoubleClick);
			this.mapPicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPicturebox_MouseDown);
			this.mapPicturebox.MouseLeave += new System.EventHandler(this.mapPicturebox_MouseLeave);
			this.mapPicturebox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPicturebox_MouseMove);
			this.mapPicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapPicturebox_MouseUp);
			// 
			// maphoverCheckbox
			// 
			this.maphoverCheckbox.AutoSize = true;
			this.maphoverCheckbox.Checked = true;
			this.maphoverCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.maphoverCheckbox.ForeColor = System.Drawing.Color.Black;
			this.maphoverCheckbox.Location = new System.Drawing.Point(38, 328);
			this.maphoverCheckbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.maphoverCheckbox.Name = "maphoverCheckbox";
			this.maphoverCheckbox.Size = new System.Drawing.Size(164, 17);
			this.maphoverCheckbox.TabIndex = 63;
			this.maphoverCheckbox.Text = "Show room preview on hover";
			this.maphoverCheckbox.UseVisualStyleBackColor = true;
			// 
			// mapInfosLabel
			// 
			this.mapInfosLabel.AutoSize = true;
			this.mapInfosLabel.ForeColor = System.Drawing.Color.Black;
			this.mapInfosLabel.Location = new System.Drawing.Point(8, 348);
			this.mapInfosLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.mapInfosLabel.Name = "mapInfosLabel";
			this.mapInfosLabel.Size = new System.Drawing.Size(237, 13);
			this.mapInfosLabel.TabIndex = 62;
			this.mapInfosLabel.Text = "Double click to open room; right click for preview";
			// 
			// thumbnailBox
			// 
			this.thumbnailBox.Location = new System.Drawing.Point(0, 364);
			this.thumbnailBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.thumbnailBox.Name = "thumbnailBox";
			this.thumbnailBox.Size = new System.Drawing.Size(24, 24);
			this.thumbnailBox.TabIndex = 21;
			this.thumbnailBox.TabStop = false;
			this.thumbnailBox.Visible = false;
			// 
			// headerGroupbox
			// 
			this.headerGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.headerGroupbox.BackColor = System.Drawing.SystemColors.Control;
			this.headerGroupbox.Controls.Add(this.roomHeaderPanel);
			this.headerGroupbox.Controls.Add(this.DoorTypeComboBox);
			this.headerGroupbox.Controls.Add(this.spritepropertyPanel);
			this.headerGroupbox.Controls.Add(this.spritesubtypeUpDown);
			this.headerGroupbox.Controls.Add(this.potitemobjectPanel);
			this.headerGroupbox.Controls.Add(this.comboBox1);
			this.headerGroupbox.Controls.Add(this.label23);
			this.headerGroupbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.headerGroupbox.Location = new System.Drawing.Point(301, 6);
			this.headerGroupbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.headerGroupbox.Name = "headerGroupbox";
			this.headerGroupbox.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.headerGroupbox.Size = new System.Drawing.Size(844, 146);
			this.headerGroupbox.TabIndex = 11;
			this.headerGroupbox.TabStop = false;
			this.headerGroupbox.Text = "Room header";
			// 
			// roomHeaderPanel
			// 
			this.roomHeaderPanel.BackColor = System.Drawing.SystemColors.Control;
			this.roomHeaderPanel.Controls.Add(this.label43);
			this.roomHeaderPanel.Controls.Add(this.RoomProperties_PreferredEntrance);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_IsDark);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_DestinationStair4);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_DestinationStair3);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_DestinationStair2);
			this.roomHeaderPanel.Controls.Add(this.label20);
			this.roomHeaderPanel.Controls.Add(this.label5);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_DestinationStair1);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_DestinationPit);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_MessageID);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_SpriteSet);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_Palette);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_Floor2);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_Floor1);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_Blockset);
			this.roomHeaderPanel.Controls.Add(this.RoomProperty_Layout);
			this.roomHeaderPanel.Controls.Add(this.label16);
			this.roomHeaderPanel.Controls.Add(this.label15);
			this.roomHeaderPanel.Controls.Add(this.label7);
			this.roomHeaderPanel.Controls.Add(this.label1);
			this.roomHeaderPanel.Controls.Add(this.bg2checkbox5);
			this.roomHeaderPanel.Controls.Add(this.label33);
			this.roomHeaderPanel.Controls.Add(this.label14);
			this.roomHeaderPanel.Controls.Add(this.label28);
			this.roomHeaderPanel.Controls.Add(this.bg2checkbox4);
			this.roomHeaderPanel.Controls.Add(this.bg2checkbox3);
			this.roomHeaderPanel.Controls.Add(this.bg2checkbox2);
			this.roomHeaderPanel.Controls.Add(this.bg2checkbox1);
			this.roomHeaderPanel.Controls.Add(this.label11);
			this.roomHeaderPanel.Controls.Add(this.roomProperty_effect);
			this.roomHeaderPanel.Controls.Add(this.roomProperty_sortsprite);
			this.roomHeaderPanel.Controls.Add(this.label2);
			this.roomHeaderPanel.Controls.Add(this.roomPropertyLayerMerge);
			this.roomHeaderPanel.Controls.Add(this.label3);
			this.roomHeaderPanel.Controls.Add(this.roomProperty_collision);
			this.roomHeaderPanel.Controls.Add(this.label9);
			this.roomHeaderPanel.Controls.Add(this.roomProperty_pit);
			this.roomHeaderPanel.Controls.Add(this.label10);
			this.roomHeaderPanel.Controls.Add(this.label6);
			this.roomHeaderPanel.Controls.Add(this.label4);
			this.roomHeaderPanel.Controls.Add(this.label8);
			this.roomHeaderPanel.Controls.Add(this.label13);
			this.roomHeaderPanel.Controls.Add(this.roomProperty_tag1);
			this.roomHeaderPanel.Controls.Add(this.label12);
			this.roomHeaderPanel.Controls.Add(this.roomProperty_tag2);
			this.roomHeaderPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.roomHeaderPanel.Location = new System.Drawing.Point(12, 16);
			this.roomHeaderPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.roomHeaderPanel.Name = "roomHeaderPanel";
			this.roomHeaderPanel.Size = new System.Drawing.Size(490, 128);
			this.roomHeaderPanel.TabIndex = 20;
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.Location = new System.Drawing.Point(300, 5);
			this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(71, 13);
			this.label43.TabIndex = 100;
			this.label43.Text = "Pref entrance";
			// 
			// RoomProperties_PreferredEntrance
			// 
			this.RoomProperties_PreferredEntrance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperties_PreferredEntrance.HexValue = 0;
			this.RoomProperties_PreferredEntrance.Location = new System.Drawing.Point(302, 23);
			this.RoomProperties_PreferredEntrance.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperties_PreferredEntrance.MaxLength = 2;
			this.RoomProperties_PreferredEntrance.Name = "RoomProperties_PreferredEntrance";
			this.RoomProperties_PreferredEntrance.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.RoomProperties_PreferredEntrance.Size = new System.Drawing.Size(50, 20);
			this.RoomProperties_PreferredEntrance.TabIndex = 99;
			this.RoomProperties_PreferredEntrance.Text = "00";
			this.RoomProperties_PreferredEntrance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperties_PreferredEntrance.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// RoomProperty_IsDark
			// 
			this.RoomProperty_IsDark.AutoSize = true;
			this.RoomProperty_IsDark.Location = new System.Drawing.Point(302, 78);
			this.RoomProperty_IsDark.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_IsDark.Name = "RoomProperty_IsDark";
			this.RoomProperty_IsDark.Size = new System.Drawing.Size(75, 17);
			this.RoomProperty_IsDark.TabIndex = 98;
			this.RoomProperty_IsDark.Text = "Dark room";
			this.RoomProperty_IsDark.UseVisualStyleBackColor = true;
			this.RoomProperty_IsDark.CheckedChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// RoomProperty_DestinationStair4
			// 
			this.RoomProperty_DestinationStair4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperty_DestinationStair4.HexValue = 0;
			this.RoomProperty_DestinationStair4.Location = new System.Drawing.Point(428, 102);
			this.RoomProperty_DestinationStair4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_DestinationStair4.MaxLength = 2;
			this.RoomProperty_DestinationStair4.Name = "RoomProperty_DestinationStair4";
			this.RoomProperty_DestinationStair4.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.RoomProperty_DestinationStair4.Size = new System.Drawing.Size(24, 20);
			this.RoomProperty_DestinationStair4.TabIndex = 97;
			this.RoomProperty_DestinationStair4.Text = "00";
			this.RoomProperty_DestinationStair4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperty_DestinationStair4.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// RoomProperty_DestinationStair3
			// 
			this.RoomProperty_DestinationStair3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperty_DestinationStair3.HexValue = 0;
			this.RoomProperty_DestinationStair3.Location = new System.Drawing.Point(428, 81);
			this.RoomProperty_DestinationStair3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_DestinationStair3.MaxLength = 2;
			this.RoomProperty_DestinationStair3.Name = "RoomProperty_DestinationStair3";
			this.RoomProperty_DestinationStair3.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.RoomProperty_DestinationStair3.Size = new System.Drawing.Size(24, 20);
			this.RoomProperty_DestinationStair3.TabIndex = 96;
			this.RoomProperty_DestinationStair3.Text = "00";
			this.RoomProperty_DestinationStair3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperty_DestinationStair3.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// RoomProperty_DestinationStair2
			// 
			this.RoomProperty_DestinationStair2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperty_DestinationStair2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.RoomProperty_DestinationStair2.HexValue = 0;
			this.RoomProperty_DestinationStair2.Location = new System.Drawing.Point(428, 62);
			this.RoomProperty_DestinationStair2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_DestinationStair2.MaxLength = 2;
			this.RoomProperty_DestinationStair2.Name = "RoomProperty_DestinationStair2";
			this.RoomProperty_DestinationStair2.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.RoomProperty_DestinationStair2.Size = new System.Drawing.Size(24, 20);
			this.RoomProperty_DestinationStair2.TabIndex = 95;
			this.RoomProperty_DestinationStair2.Text = "00";
			this.RoomProperty_DestinationStair2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperty_DestinationStair2.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label20.Location = new System.Drawing.Point(250, 47);
			this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(50, 13);
			this.label20.TabIndex = 29;
			this.label20.Text = "Message";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label5.Location = new System.Drawing.Point(170, 47);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(39, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Floor 2";
			// 
			// RoomProperty_DestinationStair1
			// 
			this.RoomProperty_DestinationStair1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperty_DestinationStair1.HexValue = 0;
			this.RoomProperty_DestinationStair1.Location = new System.Drawing.Point(428, 42);
			this.RoomProperty_DestinationStair1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_DestinationStair1.MaxLength = 2;
			this.RoomProperty_DestinationStair1.Name = "RoomProperty_DestinationStair1";
			this.RoomProperty_DestinationStair1.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.RoomProperty_DestinationStair1.Size = new System.Drawing.Size(24, 20);
			this.RoomProperty_DestinationStair1.TabIndex = 94;
			this.RoomProperty_DestinationStair1.Text = "00";
			this.RoomProperty_DestinationStair1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperty_DestinationStair1.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// RoomProperty_DestinationPit
			// 
			this.RoomProperty_DestinationPit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperty_DestinationPit.HexValue = 0;
			this.RoomProperty_DestinationPit.Location = new System.Drawing.Point(428, 23);
			this.RoomProperty_DestinationPit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_DestinationPit.MaxLength = 2;
			this.RoomProperty_DestinationPit.Name = "RoomProperty_DestinationPit";
			this.RoomProperty_DestinationPit.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.RoomProperty_DestinationPit.Size = new System.Drawing.Size(24, 20);
			this.RoomProperty_DestinationPit.TabIndex = 93;
			this.RoomProperty_DestinationPit.Text = "00";
			this.RoomProperty_DestinationPit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperty_DestinationPit.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// RoomProperty_MessageID
			// 
			this.RoomProperty_MessageID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperty_MessageID.HexValue = 0;
			this.RoomProperty_MessageID.Location = new System.Drawing.Point(256, 62);
			this.RoomProperty_MessageID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_MessageID.MaxLength = 3;
			this.RoomProperty_MessageID.Name = "RoomProperty_MessageID";
			this.RoomProperty_MessageID.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 4095);
			this.RoomProperty_MessageID.Size = new System.Drawing.Size(38, 20);
			this.RoomProperty_MessageID.TabIndex = 92;
			this.RoomProperty_MessageID.Text = "000";
			this.RoomProperty_MessageID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperty_MessageID.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// RoomProperty_SpriteSet
			// 
			this.RoomProperty_SpriteSet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperty_SpriteSet.HexValue = 0;
			this.RoomProperty_SpriteSet.Location = new System.Drawing.Point(214, 23);
			this.RoomProperty_SpriteSet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_SpriteSet.MaxLength = 2;
			this.RoomProperty_SpriteSet.Name = "RoomProperty_SpriteSet";
			this.RoomProperty_SpriteSet.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.RoomProperty_SpriteSet.Size = new System.Drawing.Size(38, 20);
			this.RoomProperty_SpriteSet.TabIndex = 91;
			this.RoomProperty_SpriteSet.Text = "00";
			this.RoomProperty_SpriteSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperty_SpriteSet.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// RoomProperty_Palette
			// 
			this.RoomProperty_Palette.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperty_Palette.HexValue = 0;
			this.RoomProperty_Palette.Location = new System.Drawing.Point(214, 62);
			this.RoomProperty_Palette.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_Palette.MaxLength = 2;
			this.RoomProperty_Palette.Name = "RoomProperty_Palette";
			this.RoomProperty_Palette.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.RoomProperty_Palette.Size = new System.Drawing.Size(38, 20);
			this.RoomProperty_Palette.TabIndex = 90;
			this.RoomProperty_Palette.Text = "00";
			this.RoomProperty_Palette.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperty_Palette.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// RoomProperty_Floor2
			// 
			this.RoomProperty_Floor2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperty_Floor2.HexValue = 0;
			this.RoomProperty_Floor2.Location = new System.Drawing.Point(174, 62);
			this.RoomProperty_Floor2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_Floor2.MaxLength = 1;
			this.RoomProperty_Floor2.Name = "RoomProperty_Floor2";
			this.RoomProperty_Floor2.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 15);
			this.RoomProperty_Floor2.Size = new System.Drawing.Size(38, 20);
			this.RoomProperty_Floor2.TabIndex = 89;
			this.RoomProperty_Floor2.Text = "0";
			this.RoomProperty_Floor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperty_Floor2.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// RoomProperty_Floor1
			// 
			this.RoomProperty_Floor1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperty_Floor1.HexValue = 0;
			this.RoomProperty_Floor1.Location = new System.Drawing.Point(134, 62);
			this.RoomProperty_Floor1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_Floor1.MaxLength = 1;
			this.RoomProperty_Floor1.Name = "RoomProperty_Floor1";
			this.RoomProperty_Floor1.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 15);
			this.RoomProperty_Floor1.Size = new System.Drawing.Size(38, 20);
			this.RoomProperty_Floor1.TabIndex = 88;
			this.RoomProperty_Floor1.Text = "0";
			this.RoomProperty_Floor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperty_Floor1.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// RoomProperty_Blockset
			// 
			this.RoomProperty_Blockset.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperty_Blockset.HexValue = 0;
			this.RoomProperty_Blockset.Location = new System.Drawing.Point(174, 23);
			this.RoomProperty_Blockset.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_Blockset.MaxLength = 2;
			this.RoomProperty_Blockset.Name = "RoomProperty_Blockset";
			this.RoomProperty_Blockset.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.RoomProperty_Blockset.Size = new System.Drawing.Size(38, 20);
			this.RoomProperty_Blockset.TabIndex = 87;
			this.RoomProperty_Blockset.Text = "00";
			this.RoomProperty_Blockset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperty_Blockset.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// RoomProperty_Layout
			// 
			this.RoomProperty_Layout.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RoomProperty_Layout.HexValue = 0;
			this.RoomProperty_Layout.Location = new System.Drawing.Point(134, 23);
			this.RoomProperty_Layout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RoomProperty_Layout.MaxLength = 1;
			this.RoomProperty_Layout.Name = "RoomProperty_Layout";
			this.RoomProperty_Layout.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 7);
			this.RoomProperty_Layout.Size = new System.Drawing.Size(38, 20);
			this.RoomProperty_Layout.TabIndex = 86;
			this.RoomProperty_Layout.Text = "0";
			this.RoomProperty_Layout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.RoomProperty_Layout.TextChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label16.Location = new System.Drawing.Point(455, 5);
			this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(28, 13);
			this.label16.TabIndex = 85;
			this.label16.Text = "BG2";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label15.Location = new System.Drawing.Point(388, 5);
			this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(65, 13);
			this.label15.TabIndex = 84;
			this.label15.Text = "Destinations";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(388, 107);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(37, 13);
			this.label7.TabIndex = 83;
			this.label7.Text = "Stair 4";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(388, 88);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 82;
			this.label1.Text = "Stair 3";
			// 
			// bg2checkbox5
			// 
			this.bg2checkbox5.AutoSize = true;
			this.bg2checkbox5.Location = new System.Drawing.Point(462, 107);
			this.bg2checkbox5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.bg2checkbox5.Name = "bg2checkbox5";
			this.bg2checkbox5.Size = new System.Drawing.Size(15, 14);
			this.bg2checkbox5.TabIndex = 78;
			this.bg2checkbox5.UseVisualStyleBackColor = true;
			this.bg2checkbox5.CheckedChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(388, 66);
			this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(37, 13);
			this.label33.TabIndex = 81;
			this.label33.Text = "Stair 2";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(406, 24);
			this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(19, 13);
			this.label14.TabIndex = 79;
			this.label14.Text = "Pit";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(388, 44);
			this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(37, 13);
			this.label28.TabIndex = 80;
			this.label28.Text = "Stair 1";
			// 
			// bg2checkbox4
			// 
			this.bg2checkbox4.AutoSize = true;
			this.bg2checkbox4.Location = new System.Drawing.Point(462, 88);
			this.bg2checkbox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.bg2checkbox4.Name = "bg2checkbox4";
			this.bg2checkbox4.Size = new System.Drawing.Size(15, 14);
			this.bg2checkbox4.TabIndex = 77;
			this.bg2checkbox4.UseVisualStyleBackColor = true;
			this.bg2checkbox4.CheckedChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// bg2checkbox3
			// 
			this.bg2checkbox3.AutoSize = true;
			this.bg2checkbox3.Location = new System.Drawing.Point(462, 66);
			this.bg2checkbox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.bg2checkbox3.Name = "bg2checkbox3";
			this.bg2checkbox3.Size = new System.Drawing.Size(15, 14);
			this.bg2checkbox3.TabIndex = 76;
			this.bg2checkbox3.UseVisualStyleBackColor = true;
			this.bg2checkbox3.CheckedChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// bg2checkbox2
			// 
			this.bg2checkbox2.AutoSize = true;
			this.bg2checkbox2.Location = new System.Drawing.Point(462, 44);
			this.bg2checkbox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.bg2checkbox2.Name = "bg2checkbox2";
			this.bg2checkbox2.Size = new System.Drawing.Size(15, 14);
			this.bg2checkbox2.TabIndex = 75;
			this.bg2checkbox2.UseVisualStyleBackColor = true;
			this.bg2checkbox2.CheckedChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// bg2checkbox1
			// 
			this.bg2checkbox1.AutoSize = true;
			this.bg2checkbox1.Location = new System.Drawing.Point(462, 24);
			this.bg2checkbox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.bg2checkbox1.Name = "bg2checkbox1";
			this.bg2checkbox1.Size = new System.Drawing.Size(15, 14);
			this.bg2checkbox1.TabIndex = 74;
			this.bg2checkbox1.UseVisualStyleBackColor = true;
			this.bg2checkbox1.CheckedChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label11.Location = new System.Drawing.Point(2, 47);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(71, 13);
			this.label11.TabIndex = 17;
			this.label11.Text = "Layer 2 mode";
			// 
			// roomProperty_effect
			// 
			this.roomProperty_effect.BackColor = System.Drawing.SystemColors.Window;
			this.roomProperty_effect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.roomProperty_effect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.roomProperty_effect.FormattingEnabled = true;
			this.roomProperty_effect.Location = new System.Drawing.Point(6, 62);
			this.roomProperty_effect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.roomProperty_effect.Name = "roomProperty_effect";
			this.roomProperty_effect.Size = new System.Drawing.Size(124, 21);
			this.roomProperty_effect.TabIndex = 18;
			this.roomProperty_effect.SelectedIndexChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label2.Location = new System.Drawing.Point(6, 5);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Layer 2 merge";
			// 
			// roomPropertyLayerMerge
			// 
			this.roomPropertyLayerMerge.BackColor = System.Drawing.SystemColors.Window;
			this.roomPropertyLayerMerge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.roomPropertyLayerMerge.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.roomPropertyLayerMerge.FormattingEnabled = true;
			this.roomPropertyLayerMerge.Location = new System.Drawing.Point(6, 23);
			this.roomPropertyLayerMerge.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.roomPropertyLayerMerge.Name = "roomPropertyLayerMerge";
			this.roomPropertyLayerMerge.Size = new System.Drawing.Size(124, 21);
			this.roomPropertyLayerMerge.TabIndex = 2;
			this.roomPropertyLayerMerge.SelectedIndexChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label3.Location = new System.Drawing.Point(2, 86);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Collision";
			// 
			// roomProperty_collision
			// 
			this.roomProperty_collision.BackColor = System.Drawing.SystemColors.Window;
			this.roomProperty_collision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.roomProperty_collision.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.roomProperty_collision.FormattingEnabled = true;
			this.roomProperty_collision.Location = new System.Drawing.Point(6, 101);
			this.roomProperty_collision.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.roomProperty_collision.Name = "roomProperty_collision";
			this.roomProperty_collision.Size = new System.Drawing.Size(124, 21);
			this.roomProperty_collision.TabIndex = 4;
			this.roomProperty_collision.SelectedIndexChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label9.Location = new System.Drawing.Point(133, 5);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(39, 13);
			this.label9.TabIndex = 13;
			this.label9.Text = "Layout";
			// 
			// roomProperty_pit
			// 
			this.roomProperty_pit.AutoSize = true;
			this.roomProperty_pit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.roomProperty_pit.Location = new System.Drawing.Point(302, 43);
			this.roomProperty_pit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.roomProperty_pit.Name = "roomProperty_pit";
			this.roomProperty_pit.Size = new System.Drawing.Size(79, 17);
			this.roomProperty_pit.TabIndex = 28;
			this.roomProperty_pit.Text = "Pit damage";
			this.roomProperty_pit.UseVisualStyleBackColor = true;
			this.roomProperty_pit.CheckedChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label10.Location = new System.Drawing.Point(210, 5);
			this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(39, 13);
			this.label10.TabIndex = 15;
			this.label10.Text = "Sprites";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label6.Location = new System.Drawing.Point(170, 5);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(38, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Tileset";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label4.Location = new System.Drawing.Point(133, 47);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Floor 1";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label8.Location = new System.Drawing.Point(210, 47);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 12;
			this.label8.Text = "Palette";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label13.Location = new System.Drawing.Point(133, 86);
			this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(35, 13);
			this.label13.TabIndex = 19;
			this.label13.Text = "Tag 1";
			// 
			// roomProperty_tag1
			// 
			this.roomProperty_tag1.BackColor = System.Drawing.SystemColors.Window;
			this.roomProperty_tag1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.roomProperty_tag1.DropDownWidth = 200;
			this.roomProperty_tag1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.roomProperty_tag1.FormattingEnabled = true;
			this.roomProperty_tag1.Location = new System.Drawing.Point(136, 101);
			this.roomProperty_tag1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.roomProperty_tag1.Name = "roomProperty_tag1";
			this.roomProperty_tag1.Size = new System.Drawing.Size(105, 21);
			this.roomProperty_tag1.TabIndex = 20;
			this.roomProperty_tag1.SelectedIndexChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label12.Location = new System.Drawing.Point(244, 86);
			this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(35, 13);
			this.label12.TabIndex = 21;
			this.label12.Text = "Tag 2";
			// 
			// roomProperty_tag2
			// 
			this.roomProperty_tag2.BackColor = System.Drawing.SystemColors.Window;
			this.roomProperty_tag2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.roomProperty_tag2.DropDownWidth = 200;
			this.roomProperty_tag2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.roomProperty_tag2.FormattingEnabled = true;
			this.roomProperty_tag2.Location = new System.Drawing.Point(247, 101);
			this.roomProperty_tag2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.roomProperty_tag2.Name = "roomProperty_tag2";
			this.roomProperty_tag2.Size = new System.Drawing.Size(105, 21);
			this.roomProperty_tag2.TabIndex = 22;
			this.roomProperty_tag2.SelectedIndexChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// DoorTypeComboBox
			// 
			this.DoorTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DoorTypeComboBox.BackColor = System.Drawing.SystemColors.Window;
			this.DoorTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DoorTypeComboBox.FormattingEnabled = true;
			this.DoorTypeComboBox.Location = new System.Drawing.Point(696, 109);
			this.DoorTypeComboBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.DoorTypeComboBox.Name = "DoorTypeComboBox";
			this.DoorTypeComboBox.Size = new System.Drawing.Size(127, 21);
			this.DoorTypeComboBox.TabIndex = 8;
			// 
			// spritepropertyPanel
			// 
			this.spritepropertyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.spritepropertyPanel.Controls.Add(this.spriteoverlordCheckbox);
			this.spritepropertyPanel.Controls.Add(this.label26);
			this.spritepropertyPanel.Controls.Add(this.doorselectPanel);
			this.spritepropertyPanel.Location = new System.Drawing.Point(509, 16);
			this.spritepropertyPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.spritepropertyPanel.Name = "spritepropertyPanel";
			this.spritepropertyPanel.Size = new System.Drawing.Size(173, 50);
			this.spritepropertyPanel.TabIndex = 12;
			this.spritepropertyPanel.Visible = false;
			// 
			// spriteoverlordCheckbox
			// 
			this.spriteoverlordCheckbox.AutoSize = true;
			this.spriteoverlordCheckbox.Location = new System.Drawing.Point(79, 28);
			this.spriteoverlordCheckbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.spriteoverlordCheckbox.Name = "spriteoverlordCheckbox";
			this.spriteoverlordCheckbox.Size = new System.Drawing.Size(66, 17);
			this.spriteoverlordCheckbox.TabIndex = 16;
			this.spriteoverlordCheckbox.Text = "Overlord";
			this.spriteoverlordCheckbox.UseVisualStyleBackColor = true;
			this.spriteoverlordCheckbox.Visible = false;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(2, 10);
			this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(46, 13);
			this.label26.TabIndex = 15;
			this.label26.Text = "Subtype";
			// 
			// doorselectPanel
			// 
			this.doorselectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.doorselectPanel.BackColor = System.Drawing.SystemColors.Control;
			this.doorselectPanel.Controls.Add(this.collisionMapPanel);
			this.doorselectPanel.Controls.Add(this.label25);
			this.doorselectPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.doorselectPanel.Location = new System.Drawing.Point(0, 0);
			this.doorselectPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.doorselectPanel.Name = "doorselectPanel";
			this.doorselectPanel.Size = new System.Drawing.Size(0, 50);
			this.doorselectPanel.TabIndex = 18;
			this.doorselectPanel.Visible = false;
			// 
			// collisionMapPanel
			// 
			this.collisionMapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.collisionMapPanel.BackColor = System.Drawing.SystemColors.Control;
			this.collisionMapPanel.Controls.Add(this.tileTypeCombobox);
			this.collisionMapPanel.Controls.Add(this.collisionMapLabel);
			this.collisionMapPanel.Controls.Add(this.litCheckbox);
			this.collisionMapPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.collisionMapPanel.Location = new System.Drawing.Point(0, 0);
			this.collisionMapPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.collisionMapPanel.Name = "collisionMapPanel";
			this.collisionMapPanel.Size = new System.Drawing.Size(0, 50);
			this.collisionMapPanel.TabIndex = 19;
			this.collisionMapPanel.Visible = false;
			// 
			// tileTypeCombobox
			// 
			this.tileTypeCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tileTypeCombobox.BackColor = System.Drawing.SystemColors.Window;
			this.tileTypeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tileTypeCombobox.FormattingEnabled = true;
			this.tileTypeCombobox.Location = new System.Drawing.Point(6, 25);
			this.tileTypeCombobox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.tileTypeCombobox.Name = "tileTypeCombobox";
			this.tileTypeCombobox.Size = new System.Drawing.Size(0, 23);
			this.tileTypeCombobox.TabIndex = 8;
			// 
			// collisionMapLabel
			// 
			this.collisionMapLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.collisionMapLabel.AutoSize = true;
			this.collisionMapLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.collisionMapLabel.Location = new System.Drawing.Point(2, 9);
			this.collisionMapLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.collisionMapLabel.Name = "collisionMapLabel";
			this.collisionMapLabel.Size = new System.Drawing.Size(88, 13);
			this.collisionMapLabel.TabIndex = 9;
			this.collisionMapLabel.Text = "Selected tile type";
			// 
			// litCheckbox
			// 
			this.litCheckbox.AutoSize = true;
			this.litCheckbox.Location = new System.Drawing.Point(151, 27);
			this.litCheckbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.litCheckbox.Name = "litCheckbox";
			this.litCheckbox.Size = new System.Drawing.Size(61, 17);
			this.litCheckbox.TabIndex = 19;
			this.litCheckbox.Text = "Prelight";
			this.litCheckbox.UseVisualStyleBackColor = true;
			this.litCheckbox.Visible = false;
			// 
			// label25
			// 
			this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label25.AutoSize = true;
			this.label25.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label25.Location = new System.Drawing.Point(2, 9);
			this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(66, 13);
			this.label25.TabIndex = 9;
			this.label25.Text = "Door Type : ";
			// 
			// spritesubtypeUpDown
			// 
			this.spritesubtypeUpDown.Location = new System.Drawing.Point(586, 107);
			this.spritesubtypeUpDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.spritesubtypeUpDown.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.spritesubtypeUpDown.Name = "spritesubtypeUpDown";
			this.spritesubtypeUpDown.Size = new System.Drawing.Size(58, 20);
			this.spritesubtypeUpDown.TabIndex = 14;
			// 
			// potitemobjectPanel
			// 
			this.potitemobjectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.potitemobjectPanel.Controls.Add(this.selecteditemobjectCombobox);
			this.potitemobjectPanel.Controls.Add(this.label31);
			this.potitemobjectPanel.Location = new System.Drawing.Point(509, 16);
			this.potitemobjectPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.potitemobjectPanel.Name = "potitemobjectPanel";
			this.potitemobjectPanel.Size = new System.Drawing.Size(173, 50);
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
            "Green Rupee",
            "Rock hoarder",
            "Bee",
            "Health pack",
            "Bomb",
            "Heart ",
            "Blue Rupee",
            "Key",
            "Arrow",
            "Bomb",
            "Heart",
            "Magic",
            "Full Magic",
            "Cucco",
            "Green Soldier",
            "Bush Stal",
            "Blue Soldier",
            "Landmine",
            "Heart",
            "Fairy",
            "Heart",
            "Nothing ",
            "Hole",
            "Warp",
            "Staircase",
            "Bombable",
            "Switch"});
			this.selecteditemobjectCombobox.Location = new System.Drawing.Point(6, 26);
			this.selecteditemobjectCombobox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.selecteditemobjectCombobox.Name = "selecteditemobjectCombobox";
			this.selecteditemobjectCombobox.Size = new System.Drawing.Size(0, 23);
			this.selecteditemobjectCombobox.TabIndex = 8;
			// 
			// label31
			// 
			this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(2, 10);
			this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(33, 13);
			this.label31.TabIndex = 9;
			this.label31.Text = "Item :";
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.Enabled = false;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "None",
            "Small key",
            "Big key"});
			this.comboBox1.Location = new System.Drawing.Point(562, 94);
			this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(0, 23);
			this.comboBox1.TabIndex = 8;
			this.comboBox1.Text = "None";
			// 
			// label23
			// 
			this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(509, 97);
			this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(49, 13);
			this.label23.TabIndex = 9;
			this.label23.Text = "Key drop";
			// 
			// overworldPage
			// 
			this.overworldPage.BackColor = System.Drawing.SystemColors.Control;
			this.overworldPage.Controls.Add(this.OverworldSplitContainer);
			this.overworldPage.Controls.Add(this.owPropertyPanel);
			this.overworldPage.Location = new System.Drawing.Point(4, 4);
			this.overworldPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.overworldPage.Name = "overworldPage";
			this.overworldPage.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.overworldPage.Size = new System.Drawing.Size(1150, 742);
			this.overworldPage.TabIndex = 1;
			this.overworldPage.Text = "Overworld Editor";
			// 
			// OverworldSplitContainer
			// 
			this.OverworldSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OverworldSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.OverworldSplitContainer.IsSplitterFixed = true;
			this.OverworldSplitContainer.Location = new System.Drawing.Point(2, 78);
			this.OverworldSplitContainer.Name = "OverworldSplitContainer";
			// 
			// OverworldSplitContainer.Panel1
			// 
			this.OverworldSplitContainer.Panel1.AutoScroll = true;
			this.OverworldSplitContainer.Panel1.Controls.Add(this.OverworldAuxSideTabs);
			// 
			// OverworldSplitContainer.Panel2
			// 
			this.OverworldSplitContainer.Panel2.AutoScroll = true;
			this.OverworldSplitContainer.Panel2.Controls.Add(this.pictureBox2);
			this.OverworldSplitContainer.Size = new System.Drawing.Size(1146, 661);
			this.OverworldSplitContainer.SplitterDistance = 288;
			this.OverworldSplitContainer.TabIndex = 3;
			// 
			// OverworldAuxSideTabs
			// 
			this.OverworldAuxSideTabs.Controls.Add(this.tabPage1);
			this.OverworldAuxSideTabs.Controls.Add(this.tabPage2);
			this.OverworldAuxSideTabs.Controls.Add(this.Tiles8);
			this.OverworldAuxSideTabs.Controls.Add(this.OWTabExitProps);
			this.OverworldAuxSideTabs.Controls.Add(this.OWTabEntranceProps);
			this.OverworldAuxSideTabs.Controls.Add(this.OWTabTransportProps);
			this.OverworldAuxSideTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OverworldAuxSideTabs.Location = new System.Drawing.Point(0, 0);
			this.OverworldAuxSideTabs.Multiline = true;
			this.OverworldAuxSideTabs.Name = "OverworldAuxSideTabs";
			this.OverworldAuxSideTabs.SelectedIndex = 0;
			this.OverworldAuxSideTabs.Size = new System.Drawing.Size(288, 661);
			this.OverworldAuxSideTabs.TabIndex = 1;
			this.OverworldAuxSideTabs.SelectedIndexChanged += new System.EventHandler(this.UnderWorldTabControlChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.AutoScroll = true;
			this.tabPage1.Controls.Add(this.tilePictureBox);
			this.tabPage1.Location = new System.Drawing.Point(4, 40);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(280, 617);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Tile 16";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tilePictureBox
			// 
			this.tilePictureBox.Location = new System.Drawing.Point(3, 3);
			this.tilePictureBox.Name = "tilePictureBox";
			this.tilePictureBox.Size = new System.Drawing.Size(256, 4096);
			this.tilePictureBox.TabIndex = 0;
			this.tilePictureBox.TabStop = false;
			this.tilePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.tilePictureBox_Paint);
			this.tilePictureBox.DoubleClick += new System.EventHandler(this.tilePictureBox_DoubleClick);
			this.tilePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tilePictureBox_MouseClick);
			this.tilePictureBox.MouseEnter += new System.EventHandler(this.tilePictureBox_MouseEnter);
			// 
			// tabPage2
			// 
			this.tabPage2.AutoScroll = true;
			this.tabPage2.Controls.Add(this.scratchPicturebox);
			this.tabPage2.Location = new System.Drawing.Point(4, 44);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(280, 611);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Tile 16 scratchpad";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// scratchPicturebox
			// 
			this.scratchPicturebox.Location = new System.Drawing.Point(3, 3);
			this.scratchPicturebox.Name = "scratchPicturebox";
			this.scratchPicturebox.Size = new System.Drawing.Size(256, 3600);
			this.scratchPicturebox.TabIndex = 1;
			this.scratchPicturebox.TabStop = false;
			this.scratchPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.scratchPicturebox_Paint);
			this.scratchPicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scratchPicturebox_MouseDown);
			this.scratchPicturebox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scratchPicturebox_MouseMove);
			this.scratchPicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scratchPicturebox_MouseUp);
			// 
			// Tiles8
			// 
			this.Tiles8.Controls.Add(this.panel2);
			this.Tiles8.Controls.Add(this.panel4);
			this.Tiles8.Location = new System.Drawing.Point(4, 44);
			this.Tiles8.Name = "Tiles8";
			this.Tiles8.Size = new System.Drawing.Size(280, 611);
			this.Tiles8.TabIndex = 2;
			this.Tiles8.Text = "Tile 8";
			this.Tiles8.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.AutoScroll = true;
			this.panel2.Controls.Add(this.Tile8PicBox);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 217);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(280, 394);
			this.panel2.TabIndex = 3;
			// 
			// Tile8PicBox
			// 
			this.Tile8PicBox.Location = new System.Drawing.Point(3, 3);
			this.Tile8PicBox.Name = "Tile8PicBox";
			this.Tile8PicBox.Size = new System.Drawing.Size(256, 1024);
			this.Tile8PicBox.TabIndex = 1;
			this.Tile8PicBox.TabStop = false;
			this.Tile8PicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Tile8PicBox_Paint);
			this.Tile8PicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tile8PicBox_MouseDown);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.priorityCheckbox);
			this.panel4.Controls.Add(this.currentTile8Box);
			this.panel4.Controls.Add(this.mirrorYCheckbox);
			this.panel4.Controls.Add(this.palette8Box);
			this.panel4.Controls.Add(this.mirrorXCheckbox);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(280, 217);
			this.panel4.TabIndex = 2;
			// 
			// priorityCheckbox
			// 
			this.priorityCheckbox.AutoSize = true;
			this.priorityCheckbox.Location = new System.Drawing.Point(75, 59);
			this.priorityCheckbox.Name = "priorityCheckbox";
			this.priorityCheckbox.Size = new System.Drawing.Size(57, 17);
			this.priorityCheckbox.TabIndex = 5;
			this.priorityCheckbox.Text = "Priority";
			this.priorityCheckbox.UseVisualStyleBackColor = true;
			this.priorityCheckbox.CheckedChanged += new System.EventHandler(this.mirrorXCheckbox_CheckedChanged);
			// 
			// currentTile8Box
			// 
			this.currentTile8Box.Location = new System.Drawing.Point(5, 13);
			this.currentTile8Box.Name = "currentTile8Box";
			this.currentTile8Box.Size = new System.Drawing.Size(64, 64);
			this.currentTile8Box.TabIndex = 3;
			this.currentTile8Box.TabStop = false;
			this.currentTile8Box.Paint += new System.Windows.Forms.PaintEventHandler(this.currentTile8Box_Paint);
			// 
			// mirrorYCheckbox
			// 
			this.mirrorYCheckbox.AutoSize = true;
			this.mirrorYCheckbox.Location = new System.Drawing.Point(75, 36);
			this.mirrorYCheckbox.Name = "mirrorYCheckbox";
			this.mirrorYCheckbox.Size = new System.Drawing.Size(52, 17);
			this.mirrorYCheckbox.TabIndex = 4;
			this.mirrorYCheckbox.Text = "Flip Y";
			this.mirrorYCheckbox.UseVisualStyleBackColor = true;
			this.mirrorYCheckbox.CheckedChanged += new System.EventHandler(this.mirrorXCheckbox_CheckedChanged);
			// 
			// palette8Box
			// 
			this.palette8Box.Location = new System.Drawing.Point(3, 83);
			this.palette8Box.Name = "palette8Box";
			this.palette8Box.Size = new System.Drawing.Size(256, 128);
			this.palette8Box.TabIndex = 2;
			this.palette8Box.TabStop = false;
			this.palette8Box.Paint += new System.Windows.Forms.PaintEventHandler(this.palette8Box_Paint);
			this.palette8Box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.palette8Box_MouseDown);
			// 
			// mirrorXCheckbox
			// 
			this.mirrorXCheckbox.AutoSize = true;
			this.mirrorXCheckbox.Location = new System.Drawing.Point(75, 13);
			this.mirrorXCheckbox.Name = "mirrorXCheckbox";
			this.mirrorXCheckbox.Size = new System.Drawing.Size(52, 17);
			this.mirrorXCheckbox.TabIndex = 3;
			this.mirrorXCheckbox.Text = "Flip X";
			this.mirrorXCheckbox.UseVisualStyleBackColor = true;
			this.mirrorXCheckbox.CheckedChanged += new System.EventHandler(this.mirrorXCheckbox_CheckedChanged);
			// 
			// OWTabExitProps
			// 
			this.OWTabExitProps.Controls.Add(this.OWExitPanel);
			this.OWTabExitProps.Location = new System.Drawing.Point(4, 44);
			this.OWTabExitProps.Name = "OWTabExitProps";
			this.OWTabExitProps.Size = new System.Drawing.Size(280, 611);
			this.OWTabExitProps.TabIndex = 3;
			this.OWTabExitProps.Text = "Exit";
			this.OWTabExitProps.UseVisualStyleBackColor = true;
			// 
			// OWExitPanel
			// 
			this.OWExitPanel.Controls.Add(this.OWExitDisabled);
			this.OWExitPanel.Controls.Add(this.OWExitPropY);
			this.OWExitPanel.Controls.Add(this.OWExitPropX);
			this.OWExitPanel.Controls.Add(this.OWExitPropID);
			this.OWExitPanel.Controls.Add(this.label56);
			this.OWExitPanel.Controls.Add(this.label57);
			this.OWExitPanel.Controls.Add(this.label58);
			this.OWExitPanel.Location = new System.Drawing.Point(17, 4);
			this.OWExitPanel.Name = "OWExitPanel";
			this.OWExitPanel.Size = new System.Drawing.Size(205, 220);
			this.OWExitPanel.TabIndex = 9;
			// 
			// OWExitDisabled
			// 
			this.OWExitDisabled.AutoSize = true;
			this.OWExitDisabled.Location = new System.Drawing.Point(8, 7);
			this.OWExitDisabled.Name = "OWExitDisabled";
			this.OWExitDisabled.Size = new System.Drawing.Size(83, 13);
			this.OWExitDisabled.TabIndex = 8;
			this.OWExitDisabled.Text = "No exit selected";
			// 
			// OWExitPropY
			// 
			this.OWExitPropY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWExitPropY.HexValue = 0;
			this.OWExitPropY.Location = new System.Drawing.Point(55, 78);
			this.OWExitPropY.MaxLength = 2;
			this.OWExitPropY.Name = "OWExitPropY";
			this.OWExitPropY.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWExitPropY.Size = new System.Drawing.Size(56, 20);
			this.OWExitPropY.TabIndex = 7;
			this.OWExitPropY.Text = "00";
			this.OWExitPropY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// OWExitPropX
			// 
			this.OWExitPropX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWExitPropX.HexValue = 0;
			this.OWExitPropX.Location = new System.Drawing.Point(55, 52);
			this.OWExitPropX.MaxLength = 2;
			this.OWExitPropX.Name = "OWExitPropX";
			this.OWExitPropX.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWExitPropX.Size = new System.Drawing.Size(55, 20);
			this.OWExitPropX.TabIndex = 6;
			this.OWExitPropX.Text = "00";
			this.OWExitPropX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// OWExitPropID
			// 
			this.OWExitPropID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWExitPropID.HexValue = 0;
			this.OWExitPropID.Location = new System.Drawing.Point(55, 26);
			this.OWExitPropID.MaxLength = 2;
			this.OWExitPropID.Name = "OWExitPropID";
			this.OWExitPropID.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWExitPropID.Size = new System.Drawing.Size(55, 20);
			this.OWExitPropID.TabIndex = 5;
			this.OWExitPropID.Text = "00";
			this.OWExitPropID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.Location = new System.Drawing.Point(35, 81);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(14, 13);
			this.label56.TabIndex = 4;
			this.label56.Text = "Y";
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.Location = new System.Drawing.Point(35, 55);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(14, 13);
			this.label57.TabIndex = 2;
			this.label57.Text = "X";
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.Location = new System.Drawing.Point(11, 29);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(38, 13);
			this.label58.TabIndex = 0;
			this.label58.Text = "Exit ID";
			// 
			// OWTabEntranceProps
			// 
			this.OWTabEntranceProps.Controls.Add(this.OWEntrancePanel);
			this.OWTabEntranceProps.Location = new System.Drawing.Point(4, 44);
			this.OWTabEntranceProps.Name = "OWTabEntranceProps";
			this.OWTabEntranceProps.Size = new System.Drawing.Size(280, 611);
			this.OWTabEntranceProps.TabIndex = 4;
			this.OWTabEntranceProps.Text = "Entrance";
			this.OWTabEntranceProps.UseVisualStyleBackColor = true;
			// 
			// OWEntrancePanel
			// 
			this.OWEntrancePanel.Controls.Add(this.OWEntranceDisabled);
			this.OWEntrancePanel.Controls.Add(this.OWEntrancePropY);
			this.OWEntrancePanel.Controls.Add(this.OWEntrancePropX);
			this.OWEntrancePanel.Controls.Add(this.OWEntrancePropID);
			this.OWEntrancePanel.Controls.Add(this.label59);
			this.OWEntrancePanel.Controls.Add(this.label60);
			this.OWEntrancePanel.Controls.Add(this.label61);
			this.OWEntrancePanel.Location = new System.Drawing.Point(17, 18);
			this.OWEntrancePanel.Name = "OWEntrancePanel";
			this.OWEntrancePanel.Size = new System.Drawing.Size(205, 220);
			this.OWEntrancePanel.TabIndex = 10;
			// 
			// OWEntranceDisabled
			// 
			this.OWEntranceDisabled.AutoSize = true;
			this.OWEntranceDisabled.Location = new System.Drawing.Point(8, 7);
			this.OWEntranceDisabled.Name = "OWEntranceDisabled";
			this.OWEntranceDisabled.Size = new System.Drawing.Size(109, 13);
			this.OWEntranceDisabled.TabIndex = 8;
			this.OWEntranceDisabled.Text = "No entrance selected";
			// 
			// OWEntrancePropY
			// 
			this.OWEntrancePropY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWEntrancePropY.HexValue = 0;
			this.OWEntrancePropY.Location = new System.Drawing.Point(55, 78);
			this.OWEntrancePropY.MaxLength = 2;
			this.OWEntrancePropY.Name = "OWEntrancePropY";
			this.OWEntrancePropY.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWEntrancePropY.Size = new System.Drawing.Size(56, 20);
			this.OWEntrancePropY.TabIndex = 7;
			this.OWEntrancePropY.Text = "00";
			this.OWEntrancePropY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// OWEntrancePropX
			// 
			this.OWEntrancePropX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWEntrancePropX.HexValue = 0;
			this.OWEntrancePropX.Location = new System.Drawing.Point(55, 52);
			this.OWEntrancePropX.MaxLength = 2;
			this.OWEntrancePropX.Name = "OWEntrancePropX";
			this.OWEntrancePropX.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWEntrancePropX.Size = new System.Drawing.Size(55, 20);
			this.OWEntrancePropX.TabIndex = 6;
			this.OWEntrancePropX.Text = "00";
			this.OWEntrancePropX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// OWEntrancePropID
			// 
			this.OWEntrancePropID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWEntrancePropID.HexValue = 0;
			this.OWEntrancePropID.Location = new System.Drawing.Point(55, 26);
			this.OWEntrancePropID.MaxLength = 2;
			this.OWEntrancePropID.Name = "OWEntrancePropID";
			this.OWEntrancePropID.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWEntrancePropID.Size = new System.Drawing.Size(55, 20);
			this.OWEntrancePropID.TabIndex = 5;
			this.OWEntrancePropID.Text = "00";
			this.OWEntrancePropID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.Location = new System.Drawing.Point(35, 81);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(14, 13);
			this.label59.TabIndex = 4;
			this.label59.Text = "Y";
			// 
			// label60
			// 
			this.label60.AutoSize = true;
			this.label60.Location = new System.Drawing.Point(35, 55);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(14, 13);
			this.label60.TabIndex = 2;
			this.label60.Text = "X";
			// 
			// label61
			// 
			this.label61.AutoSize = true;
			this.label61.Location = new System.Drawing.Point(31, 29);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(18, 13);
			this.label61.TabIndex = 0;
			this.label61.Text = "ID";
			// 
			// OWTabTransportProps
			// 
			this.OWTabTransportProps.Controls.Add(this.OWTransportPanel);
			this.OWTabTransportProps.Location = new System.Drawing.Point(4, 44);
			this.OWTabTransportProps.Name = "OWTabTransportProps";
			this.OWTabTransportProps.Size = new System.Drawing.Size(280, 611);
			this.OWTabTransportProps.TabIndex = 5;
			this.OWTabTransportProps.Text = "Transport";
			this.OWTabTransportProps.UseVisualStyleBackColor = true;
			// 
			// OWTransportPanel
			// 
			this.OWTransportPanel.Controls.Add(this.OWTransportDisabled);
			this.OWTransportPanel.Controls.Add(this.OWTransportPropY);
			this.OWTransportPanel.Controls.Add(this.OWTransportPropX);
			this.OWTransportPanel.Controls.Add(this.OWTransportPropID);
			this.OWTransportPanel.Controls.Add(this.label62);
			this.OWTransportPanel.Controls.Add(this.label63);
			this.OWTransportPanel.Controls.Add(this.label64);
			this.OWTransportPanel.Location = new System.Drawing.Point(17, 18);
			this.OWTransportPanel.Name = "OWTransportPanel";
			this.OWTransportPanel.Size = new System.Drawing.Size(205, 220);
			this.OWTransportPanel.TabIndex = 10;
			// 
			// OWTransportDisabled
			// 
			this.OWTransportDisabled.AutoSize = true;
			this.OWTransportDisabled.Location = new System.Drawing.Point(8, 7);
			this.OWTransportDisabled.Name = "OWTransportDisabled";
			this.OWTransportDisabled.Size = new System.Drawing.Size(108, 13);
			this.OWTransportDisabled.TabIndex = 8;
			this.OWTransportDisabled.Text = "No transport selected";
			// 
			// OWTransportPropY
			// 
			this.OWTransportPropY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWTransportPropY.HexValue = 0;
			this.OWTransportPropY.Location = new System.Drawing.Point(55, 78);
			this.OWTransportPropY.MaxLength = 2;
			this.OWTransportPropY.Name = "OWTransportPropY";
			this.OWTransportPropY.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWTransportPropY.Size = new System.Drawing.Size(56, 20);
			this.OWTransportPropY.TabIndex = 7;
			this.OWTransportPropY.Text = "00";
			this.OWTransportPropY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// OWTransportPropX
			// 
			this.OWTransportPropX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWTransportPropX.HexValue = 0;
			this.OWTransportPropX.Location = new System.Drawing.Point(55, 52);
			this.OWTransportPropX.MaxLength = 2;
			this.OWTransportPropX.Name = "OWTransportPropX";
			this.OWTransportPropX.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWTransportPropX.Size = new System.Drawing.Size(55, 20);
			this.OWTransportPropX.TabIndex = 6;
			this.OWTransportPropX.Text = "00";
			this.OWTransportPropX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// OWTransportPropID
			// 
			this.OWTransportPropID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWTransportPropID.HexValue = 0;
			this.OWTransportPropID.Location = new System.Drawing.Point(55, 26);
			this.OWTransportPropID.MaxLength = 2;
			this.OWTransportPropID.Name = "OWTransportPropID";
			this.OWTransportPropID.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWTransportPropID.Size = new System.Drawing.Size(55, 20);
			this.OWTransportPropID.TabIndex = 5;
			this.OWTransportPropID.Text = "00";
			this.OWTransportPropID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label62
			// 
			this.label62.AutoSize = true;
			this.label62.Location = new System.Drawing.Point(35, 81);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(14, 13);
			this.label62.TabIndex = 4;
			this.label62.Text = "Y";
			// 
			// label63
			// 
			this.label63.AutoSize = true;
			this.label63.Location = new System.Drawing.Point(35, 55);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(14, 13);
			this.label63.TabIndex = 2;
			this.label63.Text = "X";
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.Location = new System.Drawing.Point(31, 29);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(18, 13);
			this.label64.TabIndex = 0;
			this.label64.Text = "ID";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(3, 3);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(24, 24);
			this.pictureBox2.TabIndex = 22;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Visible = false;
			// 
			// owPropertyPanel
			// 
			this.owPropertyPanel.Controls.Add(this.objectGroupbox);
			this.owPropertyPanel.Controls.Add(this.mapGroupbox);
			this.owPropertyPanel.Controls.Add(this.groupBox3);
			this.owPropertyPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.owPropertyPanel.Location = new System.Drawing.Point(2, 3);
			this.owPropertyPanel.Name = "owPropertyPanel";
			this.owPropertyPanel.Size = new System.Drawing.Size(1146, 75);
			this.owPropertyPanel.TabIndex = 2;
			// 
			// objectGroupbox
			// 
			this.objectGroupbox.Controls.Add(this.OverworldObjectCombobox);
			this.objectGroupbox.Location = new System.Drawing.Point(631, 3);
			this.objectGroupbox.Name = "objectGroupbox";
			this.objectGroupbox.Size = new System.Drawing.Size(273, 66);
			this.objectGroupbox.TabIndex = 10;
			this.objectGroupbox.TabStop = false;
			this.objectGroupbox.Text = "Selected object";
			// 
			// OverworldObjectCombobox
			// 
			this.OverworldObjectCombobox.FormattingEnabled = true;
			this.OverworldObjectCombobox.Location = new System.Drawing.Point(6, 28);
			this.OverworldObjectCombobox.Name = "OverworldObjectCombobox";
			this.OverworldObjectCombobox.Size = new System.Drawing.Size(156, 21);
			this.OverworldObjectCombobox.TabIndex = 1;
			// 
			// mapGroupbox
			// 
			this.mapGroupbox.Controls.Add(this.previewTextPicturebox);
			this.mapGroupbox.Controls.Add(this.OWProperty_MessageID);
			this.mapGroupbox.Controls.Add(this.OWProperty_SPRPalette);
			this.mapGroupbox.Controls.Add(this.OWProperty_SPRGFX);
			this.mapGroupbox.Controls.Add(this.OWProperty_BGPalette);
			this.mapGroupbox.Controls.Add(this.OWProperty_BGGFX);
			this.mapGroupbox.Controls.Add(this.areaBGColorPictureBox);
			this.mapGroupbox.Controls.Add(this.label49);
			this.mapGroupbox.Controls.Add(this.largemapCheckbox);
			this.mapGroupbox.Controls.Add(this.OverworldTextButton);
			this.mapGroupbox.Controls.Add(this.musicButton);
			this.mapGroupbox.Controls.Add(this.label50);
			this.mapGroupbox.Controls.Add(this.label51);
			this.mapGroupbox.Controls.Add(this.label52);
			this.mapGroupbox.Controls.Add(this.label53);
			this.mapGroupbox.Controls.Add(this.label54);
			this.mapGroupbox.Location = new System.Drawing.Point(160, 3);
			this.mapGroupbox.Name = "mapGroupbox";
			this.mapGroupbox.Size = new System.Drawing.Size(465, 66);
			this.mapGroupbox.TabIndex = 1;
			this.mapGroupbox.TabStop = false;
			this.mapGroupbox.Text = "Selected map";
			// 
			// previewTextPicturebox
			// 
			this.previewTextPicturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.previewTextPicturebox.Location = new System.Drawing.Point(328, 41);
			this.previewTextPicturebox.Name = "previewTextPicturebox";
			this.previewTextPicturebox.Size = new System.Drawing.Size(16, 16);
			this.previewTextPicturebox.TabIndex = 4;
			this.previewTextPicturebox.TabStop = false;
			this.previewTextPicturebox.Visible = false;
			this.previewTextPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.previewTextPicturebox_Paint);
			// 
			// OWProperty_MessageID
			// 
			this.OWProperty_MessageID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWProperty_MessageID.HexValue = 0;
			this.OWProperty_MessageID.Location = new System.Drawing.Point(270, 32);
			this.OWProperty_MessageID.MaxLength = 3;
			this.OWProperty_MessageID.Name = "OWProperty_MessageID";
			this.OWProperty_MessageID.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 4095);
			this.OWProperty_MessageID.Size = new System.Drawing.Size(45, 20);
			this.OWProperty_MessageID.TabIndex = 28;
			this.OWProperty_MessageID.Text = "000";
			this.OWProperty_MessageID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// OWProperty_SPRPalette
			// 
			this.OWProperty_SPRPalette.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWProperty_SPRPalette.HexValue = 0;
			this.OWProperty_SPRPalette.Location = new System.Drawing.Point(204, 32);
			this.OWProperty_SPRPalette.MaxLength = 2;
			this.OWProperty_SPRPalette.Name = "OWProperty_SPRPalette";
			this.OWProperty_SPRPalette.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWProperty_SPRPalette.Size = new System.Drawing.Size(60, 20);
			this.OWProperty_SPRPalette.TabIndex = 27;
			this.OWProperty_SPRPalette.Text = "00";
			this.OWProperty_SPRPalette.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.OWProperty_SPRPalette.TextChanged += new System.EventHandler(this.gfxTextbox_TextChanged);
			// 
			// OWProperty_SPRGFX
			// 
			this.OWProperty_SPRGFX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWProperty_SPRGFX.HexValue = 0;
			this.OWProperty_SPRGFX.Location = new System.Drawing.Point(138, 32);
			this.OWProperty_SPRGFX.MaxLength = 2;
			this.OWProperty_SPRGFX.Name = "OWProperty_SPRGFX";
			this.OWProperty_SPRGFX.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWProperty_SPRGFX.Size = new System.Drawing.Size(60, 20);
			this.OWProperty_SPRGFX.TabIndex = 26;
			this.OWProperty_SPRGFX.Text = "00";
			this.OWProperty_SPRGFX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.OWProperty_SPRGFX.TextChanged += new System.EventHandler(this.gfxTextbox_TextChanged);
			// 
			// OWProperty_BGPalette
			// 
			this.OWProperty_BGPalette.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWProperty_BGPalette.HexValue = 0;
			this.OWProperty_BGPalette.Location = new System.Drawing.Point(72, 32);
			this.OWProperty_BGPalette.MaxLength = 2;
			this.OWProperty_BGPalette.Name = "OWProperty_BGPalette";
			this.OWProperty_BGPalette.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWProperty_BGPalette.Size = new System.Drawing.Size(60, 20);
			this.OWProperty_BGPalette.TabIndex = 25;
			this.OWProperty_BGPalette.Text = "00";
			this.OWProperty_BGPalette.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.OWProperty_BGPalette.TextChanged += new System.EventHandler(this.gfxTextbox_TextChanged);
			// 
			// OWProperty_BGGFX
			// 
			this.OWProperty_BGGFX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.OWProperty_BGGFX.HexValue = 0;
			this.OWProperty_BGGFX.Location = new System.Drawing.Point(6, 32);
			this.OWProperty_BGGFX.MaxLength = 2;
			this.OWProperty_BGGFX.Name = "OWProperty_BGGFX";
			this.OWProperty_BGGFX.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.OWProperty_BGGFX.Size = new System.Drawing.Size(60, 20);
			this.OWProperty_BGGFX.TabIndex = 24;
			this.OWProperty_BGGFX.Text = "00";
			this.OWProperty_BGGFX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.OWProperty_BGGFX.TextChanged += new System.EventHandler(this.gfxTextbox_TextChanged);
			// 
			// areaBGColorPictureBox
			// 
			this.areaBGColorPictureBox.Location = new System.Drawing.Point(426, 28);
			this.areaBGColorPictureBox.Name = "areaBGColorPictureBox";
			this.areaBGColorPictureBox.Size = new System.Drawing.Size(24, 24);
			this.areaBGColorPictureBox.TabIndex = 23;
			this.areaBGColorPictureBox.TabStop = false;
			this.areaBGColorPictureBox.Visible = false;
			this.areaBGColorPictureBox.Click += new System.EventHandler(this.AreaBGColorPicturebox_MouseDoubleClick);
			this.areaBGColorPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.AreaBGColorPicturebox_Paint);
			// 
			// label49
			// 
			this.label49.AutoSize = true;
			this.label49.Location = new System.Drawing.Point(415, 9);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(48, 13);
			this.label49.TabIndex = 15;
			this.label49.Text = "BG color";
			this.label49.Visible = false;
			// 
			// largemapCheckbox
			// 
			this.largemapCheckbox.AutoSize = true;
			this.largemapCheckbox.Location = new System.Drawing.Point(335, 8);
			this.largemapCheckbox.Name = "largemapCheckbox";
			this.largemapCheckbox.Size = new System.Drawing.Size(76, 17);
			this.largemapCheckbox.TabIndex = 14;
			this.largemapCheckbox.Text = "Large map";
			this.largemapCheckbox.UseVisualStyleBackColor = true;
			this.largemapCheckbox.Click += new System.EventHandler(this.largemapCheckbox_Clicked);
			// 
			// OverworldTextButton
			// 
			this.OverworldTextButton.Image = ((System.Drawing.Image)(resources.GetObject("OverworldTextButton.Image")));
			this.OverworldTextButton.Location = new System.Drawing.Point(321, 31);
			this.OverworldTextButton.Name = "OverworldTextButton";
			this.OverworldTextButton.Size = new System.Drawing.Size(23, 23);
			this.OverworldTextButton.TabIndex = 13;
			this.OverworldTextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.OverworldTextButton.UseVisualStyleBackColor = true;
			this.OverworldTextButton.Click += new System.EventHandler(this.OverworldTextButton_Click);
			// 
			// musicButton
			// 
			this.musicButton.Location = new System.Drawing.Point(350, 31);
			this.musicButton.Name = "musicButton";
			this.musicButton.Size = new System.Drawing.Size(61, 23);
			this.musicButton.TabIndex = 12;
			this.musicButton.Text = "Music";
			this.musicButton.UseVisualStyleBackColor = true;
			this.musicButton.Click += new System.EventHandler(this.musicButton_Click);
			// 
			// label50
			// 
			this.label50.AutoSize = true;
			this.label50.Location = new System.Drawing.Point(270, 16);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(64, 13);
			this.label50.TabIndex = 11;
			this.label50.Text = "Message ID";
			// 
			// label51
			// 
			this.label51.AutoSize = true;
			this.label51.Location = new System.Drawing.Point(201, 16);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(61, 13);
			this.label51.TabIndex = 9;
			this.label51.Text = "Spr. palette";
			// 
			// label52
			// 
			this.label52.AutoSize = true;
			this.label52.Location = new System.Drawing.Point(69, 16);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(40, 13);
			this.label52.TabIndex = 6;
			this.label52.Text = "Palette";
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.Location = new System.Drawing.Point(135, 16);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(50, 13);
			this.label53.TabIndex = 4;
			this.label53.Text = "Spr. GFX";
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.Location = new System.Drawing.Point(3, 16);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(28, 13);
			this.label54.TabIndex = 2;
			this.label54.Text = "GFX";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.selectedTileLabel);
			this.groupBox3.Controls.Add(this.label55);
			this.groupBox3.Controls.Add(this.stateCombobox);
			this.groupBox3.Location = new System.Drawing.Point(3, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(151, 66);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Global settings";
			// 
			// selectedTileLabel
			// 
			this.selectedTileLabel.AutoSize = true;
			this.selectedTileLabel.Location = new System.Drawing.Point(3, 55);
			this.selectedTileLabel.Name = "selectedTileLabel";
			this.selectedTileLabel.Size = new System.Drawing.Size(65, 13);
			this.selectedTileLabel.TabIndex = 2;
			this.selectedTileLabel.Text = "Selected tile";
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(6, 16);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(61, 13);
			this.label55.TabIndex = 1;
			this.label55.Text = "Game state";
			// 
			// stateCombobox
			// 
			this.stateCombobox.FormattingEnabled = true;
			this.stateCombobox.Items.AddRange(new object[] {
            "0,1 Rescue Zelda",
            "2 Zelda rescued",
            "3 Agahnim defeated"});
			this.stateCombobox.Location = new System.Drawing.Point(6, 31);
			this.stateCombobox.Name = "stateCombobox";
			this.stateCombobox.Size = new System.Drawing.Size(138, 21);
			this.stateCombobox.TabIndex = 1;
			this.stateCombobox.Text = "0,1 Rescue Zelda";
			this.stateCombobox.SelectedIndexChanged += new System.EventHandler(this.stateCombobox_SelectedIndexChanged);
			// 
			// GfxEditorPage
			// 
			this.GfxEditorPage.Location = new System.Drawing.Point(4, 4);
			this.GfxEditorPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.GfxEditorPage.Name = "GfxEditorPage";
			this.GfxEditorPage.Size = new System.Drawing.Size(1150, 742);
			this.GfxEditorPage.TabIndex = 2;
			this.GfxEditorPage.Text = "Graphics Manager";
			this.GfxEditorPage.UseVisualStyleBackColor = true;
			// 
			// textPage
			// 
			this.textPage.Controls.Add(this.panel5);
			this.textPage.Controls.Add(this.panel6);
			this.textPage.Location = new System.Drawing.Point(4, 4);
			this.textPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.textPage.Name = "textPage";
			this.textPage.Size = new System.Drawing.Size(1150, 742);
			this.textPage.TabIndex = 4;
			this.textPage.Text = "Text Editor";
			this.textPage.UseVisualStyleBackColor = true;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.textListbox);
			this.panel5.Controls.Add(this.label65);
			this.panel5.Controls.Add(this.TextSearchTextbox);
			this.panel5.Controls.Add(this.label66);
			this.panel5.Location = new System.Drawing.Point(8, 3);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(433, 736);
			this.panel5.TabIndex = 24;
			// 
			// textListbox
			// 
			this.textListbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textListbox.FormattingEnabled = true;
			this.textListbox.Location = new System.Drawing.Point(0, 46);
			this.textListbox.Name = "textListbox";
			this.textListbox.ScrollAlwaysVisible = true;
			this.textListbox.Size = new System.Drawing.Size(433, 690);
			this.textListbox.TabIndex = 1;
			this.textListbox.SelectedIndexChanged += new System.EventHandler(this.textListbox_SelectedIndexChanged);
			// 
			// label65
			// 
			this.label65.AutoSize = true;
			this.label65.Dock = System.Windows.Forms.DockStyle.Top;
			this.label65.Location = new System.Drawing.Point(0, 33);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(86, 13);
			this.label65.TabIndex = 2;
			this.label65.Text = "Available dialogs";
			// 
			// TextSearchTextbox
			// 
			this.TextSearchTextbox.Dock = System.Windows.Forms.DockStyle.Top;
			this.TextSearchTextbox.Location = new System.Drawing.Point(0, 13);
			this.TextSearchTextbox.Name = "TextSearchTextbox";
			this.TextSearchTextbox.Size = new System.Drawing.Size(433, 20);
			this.TextSearchTextbox.TabIndex = 9;
			this.TextSearchTextbox.TextChanged += new System.EventHandler(this.TextSearchTextbox_TextChanged);
			// 
			// label66
			// 
			this.label66.AutoSize = true;
			this.label66.Dock = System.Windows.Forms.DockStyle.Top;
			this.label66.Location = new System.Drawing.Point(0, 0);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(76, 13);
			this.label66.TabIndex = 10;
			this.label66.Text = "Search for text";
			// 
			// panel6
			// 
			this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel6.Controls.Add(this.ParamsBox);
			this.panel6.Controls.Add(this.fontGridBox);
			this.panel6.Controls.Add(this.BytesDDD);
			this.panel6.Controls.Add(this.label67);
			this.panel6.Controls.Add(this.label68);
			this.panel6.Controls.Add(this.label69);
			this.panel6.Controls.Add(this.TextCommandList);
			this.panel6.Controls.Add(this.label70);
			this.panel6.Controls.Add(this.MessageTextEntry);
			this.panel6.Controls.Add(this.label71);
			this.panel6.Controls.Add(this.button5);
			this.panel6.Controls.Add(this.button6);
			this.panel6.Controls.Add(this.SpecialsList);
			this.panel6.Controls.Add(this.groupBox4);
			this.panel6.Controls.Add(this.ListDictionaryButton);
			this.panel6.Controls.Add(this.ImportFontGraphicsButton);
			this.panel6.Controls.Add(this.ExportFontGraphicsButton);
			this.panel6.Controls.Add(this.label75);
			this.panel6.Controls.Add(this.FontPreviewBox);
			this.panel6.Controls.Add(this.MessagePreviewBox);
			this.panel6.Location = new System.Drawing.Point(447, 2);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(520, 739);
			this.panel6.TabIndex = 25;
			// 
			// ParamsBox
			// 
			this.ParamsBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.ParamsBox.HexValue = 0;
			this.ParamsBox.Location = new System.Drawing.Point(483, 153);
			this.ParamsBox.MaxLength = 2;
			this.ParamsBox.Name = "ParamsBox";
			this.ParamsBox.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 255);
			this.ParamsBox.Size = new System.Drawing.Size(32, 20);
			this.ParamsBox.TabIndex = 35;
			this.ParamsBox.Text = "00";
			this.ParamsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// fontGridBox
			// 
			this.fontGridBox.AutoSize = true;
			this.fontGridBox.Location = new System.Drawing.Point(411, 596);
			this.fontGridBox.Name = "fontGridBox";
			this.fontGridBox.Size = new System.Drawing.Size(73, 17);
			this.fontGridBox.TabIndex = 34;
			this.fontGridBox.Text = "Show grid";
			this.fontGridBox.UseVisualStyleBackColor = true;
			this.fontGridBox.CheckedChanged += new System.EventHandler(this.fontGridBox_CheckedChanged);
			// 
			// BytesDDD
			// 
			this.BytesDDD.Location = new System.Drawing.Point(408, 413);
			this.BytesDDD.Name = "BytesDDD";
			this.BytesDDD.Size = new System.Drawing.Size(105, 28);
			this.BytesDDD.TabIndex = 33;
			this.BytesDDD.Text = "View text data";
			this.BytesDDD.UseVisualStyleBackColor = true;
			// 
			// label67
			// 
			this.label67.AutoSize = true;
			this.label67.Location = new System.Drawing.Point(398, 156);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(86, 13);
			this.label67.TabIndex = 32;
			this.label67.Text = "Parameter (HEX)";
			// 
			// label68
			// 
			this.label68.AutoSize = true;
			this.label68.Location = new System.Drawing.Point(349, 1);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(82, 13);
			this.label68.TabIndex = 24;
			this.label68.Text = "Text commands";
			// 
			// label69
			// 
			this.label69.AutoSize = true;
			this.label69.Location = new System.Drawing.Point(3, 1);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(94, 13);
			this.label69.TabIndex = 4;
			this.label69.Text = "Message contents";
			// 
			// TextCommandList
			// 
			this.TextCommandList.FormattingEnabled = true;
			this.TextCommandList.Location = new System.Drawing.Point(352, 17);
			this.TextCommandList.Name = "TextCommandList";
			this.TextCommandList.Size = new System.Drawing.Size(163, 134);
			this.TextCommandList.TabIndex = 25;
			this.TextCommandList.SelectedIndexChanged += new System.EventHandler(this.TextCommandList_SelectedIndexChanged);
			this.TextCommandList.DoubleClick += new System.EventHandler(this.InsertCommandButton_Click);
			// 
			// label70
			// 
			this.label70.AutoSize = true;
			this.label70.Location = new System.Drawing.Point(3, 177);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(45, 13);
			this.label70.TabIndex = 5;
			this.label70.Text = "Preview";
			// 
			// MessageTextEntry
			// 
			this.MessageTextEntry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.MessageTextEntry.Location = new System.Drawing.Point(6, 17);
			this.MessageTextEntry.Multiline = true;
			this.MessageTextEntry.Name = "MessageTextEntry";
			this.MessageTextEntry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.MessageTextEntry.Size = new System.Drawing.Size(340, 152);
			this.MessageTextEntry.TabIndex = 20;
			this.MessageTextEntry.TextChanged += new System.EventHandler(this.MessageTextEntry_TextChanged);
			// 
			// label71
			// 
			this.label71.AutoSize = true;
			this.label71.Location = new System.Drawing.Point(349, 183);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(118, 13);
			this.label71.TabIndex = 30;
			this.label71.Text = "Hard-to-type characters";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(411, 648);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 23);
			this.button5.TabIndex = 17;
			this.button5.Text = "Save VWF font";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(411, 619);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 23);
			this.button6.TabIndex = 4;
			this.button6.Text = "Auto width";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// SpecialsList
			// 
			this.SpecialsList.FormattingEnabled = true;
			this.SpecialsList.Location = new System.Drawing.Point(352, 199);
			this.SpecialsList.Name = "SpecialsList";
			this.SpecialsList.Size = new System.Drawing.Size(163, 186);
			this.SpecialsList.TabIndex = 29;
			this.SpecialsList.DoubleClick += new System.EventHandler(this.InsertSpecialButton_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.BigCharPreviewBox);
			this.groupBox4.Controls.Add(this.SelectedTileASCII);
			this.groupBox4.Controls.Add(this.SelectedTileID);
			this.groupBox4.Controls.Add(this.FontWidthUpDown);
			this.groupBox4.Controls.Add(this.label72);
			this.groupBox4.Controls.Add(this.label73);
			this.groupBox4.Controls.Add(this.label74);
			this.groupBox4.Location = new System.Drawing.Point(265, 407);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(137, 206);
			this.groupBox4.TabIndex = 14;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Selected tile";
			// 
			// BigCharPreviewBox
			// 
			this.BigCharPreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BigCharPreviewBox.Location = new System.Drawing.Point(35, 70);
			this.BigCharPreviewBox.MaximumSize = new System.Drawing.Size(64, 128);
			this.BigCharPreviewBox.MinimumSize = new System.Drawing.Size(64, 128);
			this.BigCharPreviewBox.Name = "BigCharPreviewBox";
			this.BigCharPreviewBox.Size = new System.Drawing.Size(64, 128);
			this.BigCharPreviewBox.TabIndex = 6;
			this.BigCharPreviewBox.TabStop = false;
			this.BigCharPreviewBox.Paint += new System.Windows.Forms.PaintEventHandler(this.BigCharPreviewBox_Paint);
			// 
			// SelectedTileASCII
			// 
			this.SelectedTileASCII.AutoSize = true;
			this.SelectedTileASCII.Location = new System.Drawing.Point(57, 29);
			this.SelectedTileASCII.Name = "SelectedTileASCII";
			this.SelectedTileASCII.Size = new System.Drawing.Size(0, 13);
			this.SelectedTileASCII.TabIndex = 5;
			// 
			// SelectedTileID
			// 
			this.SelectedTileID.AutoSize = true;
			this.SelectedTileID.Location = new System.Drawing.Point(57, 16);
			this.SelectedTileID.Name = "SelectedTileID";
			this.SelectedTileID.Size = new System.Drawing.Size(0, 13);
			this.SelectedTileID.TabIndex = 4;
			// 
			// FontWidthUpDown
			// 
			this.FontWidthUpDown.Location = new System.Drawing.Point(87, 45);
			this.FontWidthUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.FontWidthUpDown.Name = "FontWidthUpDown";
			this.FontWidthUpDown.Size = new System.Drawing.Size(44, 20);
			this.FontWidthUpDown.TabIndex = 3;
			this.FontWidthUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.FontWidthUpDown.ValueChanged += new System.EventHandler(this.FontWidthUpDown_ValueChanged);
			// 
			// label72
			// 
			this.label72.AutoSize = true;
			this.label72.Location = new System.Drawing.Point(6, 47);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(35, 13);
			this.label72.TabIndex = 2;
			this.label72.Text = "Width";
			// 
			// label73
			// 
			this.label73.AutoSize = true;
			this.label73.Location = new System.Drawing.Point(6, 29);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(34, 13);
			this.label73.TabIndex = 1;
			this.label73.Text = "ASCII";
			// 
			// label74
			// 
			this.label74.AutoSize = true;
			this.label74.Location = new System.Drawing.Point(6, 16);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(18, 13);
			this.label74.TabIndex = 0;
			this.label74.Text = "ID";
			// 
			// ListDictionaryButton
			// 
			this.ListDictionaryButton.Location = new System.Drawing.Point(408, 447);
			this.ListDictionaryButton.Name = "ListDictionaryButton";
			this.ListDictionaryButton.Size = new System.Drawing.Size(105, 28);
			this.ListDictionaryButton.TabIndex = 21;
			this.ListDictionaryButton.Text = "Dictionary entries";
			this.ListDictionaryButton.UseVisualStyleBackColor = true;
			this.ListDictionaryButton.Click += new System.EventHandler(this.ListDictionaryButton_Click);
			// 
			// ImportFontGraphicsButton
			// 
			this.ImportFontGraphicsButton.Location = new System.Drawing.Point(265, 619);
			this.ImportFontGraphicsButton.Name = "ImportFontGraphicsButton";
			this.ImportFontGraphicsButton.Size = new System.Drawing.Size(140, 23);
			this.ImportFontGraphicsButton.TabIndex = 16;
			this.ImportFontGraphicsButton.Text = "Import GFX+Width (2BPP)";
			this.ImportFontGraphicsButton.UseVisualStyleBackColor = true;
			this.ImportFontGraphicsButton.Click += new System.EventHandler(this.ImportFontGraphicsButton_Click);
			// 
			// ExportFontGraphicsButton
			// 
			this.ExportFontGraphicsButton.Location = new System.Drawing.Point(265, 648);
			this.ExportFontGraphicsButton.Name = "ExportFontGraphicsButton";
			this.ExportFontGraphicsButton.Size = new System.Drawing.Size(140, 23);
			this.ExportFontGraphicsButton.TabIndex = 15;
			this.ExportFontGraphicsButton.Text = "Export GFX+Width (2BPP)";
			this.ExportFontGraphicsButton.UseVisualStyleBackColor = true;
			this.ExportFontGraphicsButton.Click += new System.EventHandler(this.ExportFontGraphicsButton_Click);
			// 
			// label75
			// 
			this.label75.AutoSize = true;
			this.label75.Location = new System.Drawing.Point(3, 397);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(71, 13);
			this.label75.TabIndex = 10;
			this.label75.Text = "Font graphics";
			// 
			// FontPreviewBox
			// 
			this.FontPreviewBox.Location = new System.Drawing.Point(6, 413);
			this.FontPreviewBox.MinimumSize = new System.Drawing.Size(256, 244);
			this.FontPreviewBox.Name = "FontPreviewBox";
			this.FontPreviewBox.Size = new System.Drawing.Size(256, 258);
			this.FontPreviewBox.TabIndex = 11;
			this.FontPreviewBox.TabStop = false;
			this.FontPreviewBox.Paint += new System.Windows.Forms.PaintEventHandler(this.FontPreviewBox_Paint);
			this.FontPreviewBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FontPreviewBox_MouseDown);
			// 
			// MessagePreviewBox
			// 
			this.MessagePreviewBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.MessagePreviewBox.Location = new System.Drawing.Point(6, 193);
			this.MessagePreviewBox.MaximumSize = new System.Drawing.Size(340, 192);
			this.MessagePreviewBox.MinimumSize = new System.Drawing.Size(0, 96);
			this.MessagePreviewBox.Name = "MessagePreviewBox";
			this.MessagePreviewBox.Size = new System.Drawing.Size(340, 192);
			this.MessagePreviewBox.TabIndex = 6;
			this.MessagePreviewBox.TabStop = false;
			this.MessagePreviewBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MessagePreviewBox_Paint);
			// 
			// ScreenEditor
			// 
			this.ScreenEditor.Location = new System.Drawing.Point(4, 4);
			this.ScreenEditor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.ScreenEditor.Name = "ScreenEditor";
			this.ScreenEditor.Size = new System.Drawing.Size(1150, 742);
			this.ScreenEditor.TabIndex = 5;
			this.ScreenEditor.Text = "Screen Editor";
			this.ScreenEditor.UseVisualStyleBackColor = true;
			// 
			// spritesPage
			// 
			this.spritesPage.Location = new System.Drawing.Point(4, 4);
			this.spritesPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.spritesPage.Name = "spritesPage";
			this.spritesPage.Size = new System.Drawing.Size(1150, 742);
			this.spritesPage.TabIndex = 6;
			this.spritesPage.Text = "Sprites Editor";
			this.spritesPage.UseVisualStyleBackColor = true;
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.underworldSpriteModeButton,
            this.blockmodeButton,
            this.torchmodeButton,
            this.potmodeButton,
            this.doormodeButton,
            this.collisionModeButton,
            this.toolStripSeparator3,
            this.saveLayoutButton,
            this.loadlayoutButton,
            this.searchButton,
            this.exportuwmapStripButton1,
            this.debugToolStripButton,
            this.entranceModeButton,
            this.exitModeButton,
            this.itemModeButton,
            this.owSpriteModeButton,
            this.transportModeButton,
            this.overlayButton,
            this.gravestoneButton,
            this.searchtilesButton,
            this.refreshToolStrip,
            this.clearmapbutton,
            this.fillModeButton,
            this.penModeButton,
            this.spButton,
            this.dwButton,
            this.lwButton});
			this.toolStrip1.Location = new System.Drawing.Point(4, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
			this.toolStrip1.Size = new System.Drawing.Size(888, 25);
			this.toolStrip1.Stretch = true;
			this.toolStrip1.TabIndex = 10;
			this.toolStrip1.Text = "toolStrip1";
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
			this.saveButton.Click += new System.EventHandler(this.PerformSave);
			// 
			// debugtestButton
			// 
			this.debugtestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.debugtestButton.Enabled = false;
			this.debugtestButton.Image = ((System.Drawing.Image)(resources.GetObject("debugtestButton.Image")));
			this.debugtestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.debugtestButton.Name = "debugtestButton";
			this.debugtestButton.Size = new System.Drawing.Size(23, 22);
			this.debugtestButton.Text = "Save and Debug in Emulator";
			// 
			// runtestButton
			// 
			this.runtestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.runtestButton.Enabled = false;
			this.runtestButton.Image = ((System.Drawing.Image)(resources.GetObject("runtestButton.Image")));
			this.runtestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.runtestButton.Name = "runtestButton";
			this.runtestButton.Size = new System.Drawing.Size(23, 22);
			this.runtestButton.Text = "Save and Run in Emulator";
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
			this.undoButton.Click += new System.EventHandler(this.PerformUndo);
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
			this.redoButton.Click += new System.EventHandler(this.PerformRedo);
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
			this.allbgsButton.Image = ((System.Drawing.Image)(resources.GetObject("allbgsButton.Image")));
			this.allbgsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.allbgsButton.Name = "allbgsButton";
			this.allbgsButton.Size = new System.Drawing.Size(23, 22);
			this.allbgsButton.Tag = ZeldaFullEditor.DungeonEditMode.LayerAll;
			this.allbgsButton.Text = "All Layers";
			this.allbgsButton.Click += new System.EventHandler(this.UpdateUnderworldMode);
			// 
			// bg1modeButton
			// 
			this.bg1modeButton.Checked = true;
			this.bg1modeButton.CheckOnClick = true;
			this.bg1modeButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.bg1modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bg1modeButton.Image = ((System.Drawing.Image)(resources.GetObject("bg1modeButton.Image")));
			this.bg1modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bg1modeButton.Name = "bg1modeButton";
			this.bg1modeButton.Size = new System.Drawing.Size(23, 22);
			this.bg1modeButton.Tag = ZeldaFullEditor.DungeonEditMode.Layer1;
			this.bg1modeButton.Text = "Layer 1";
			this.bg1modeButton.Click += new System.EventHandler(this.UpdateUnderworldMode);
			// 
			// bg2modeButton
			// 
			this.bg2modeButton.CheckOnClick = true;
			this.bg2modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bg2modeButton.Image = ((System.Drawing.Image)(resources.GetObject("bg2modeButton.Image")));
			this.bg2modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bg2modeButton.Name = "bg2modeButton";
			this.bg2modeButton.Size = new System.Drawing.Size(23, 22);
			this.bg2modeButton.Tag = ZeldaFullEditor.DungeonEditMode.Layer2;
			this.bg2modeButton.Text = "Layer 2";
			this.bg2modeButton.Click += new System.EventHandler(this.UpdateUnderworldMode);
			// 
			// bg3modeButton
			// 
			this.bg3modeButton.CheckOnClick = true;
			this.bg3modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bg3modeButton.Image = ((System.Drawing.Image)(resources.GetObject("bg3modeButton.Image")));
			this.bg3modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bg3modeButton.Name = "bg3modeButton";
			this.bg3modeButton.Size = new System.Drawing.Size(23, 22);
			this.bg3modeButton.Tag = ZeldaFullEditor.DungeonEditMode.Layer3;
			this.bg3modeButton.Text = "Layer 3";
			this.bg3modeButton.Click += new System.EventHandler(this.UpdateUnderworldMode);
			// 
			// underworldSpriteModeButton
			// 
			this.underworldSpriteModeButton.CheckOnClick = true;
			this.underworldSpriteModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.underworldSpriteModeButton.Image = ((System.Drawing.Image)(resources.GetObject("underworldSpriteModeButton.Image")));
			this.underworldSpriteModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.underworldSpriteModeButton.Name = "underworldSpriteModeButton";
			this.underworldSpriteModeButton.Size = new System.Drawing.Size(23, 22);
			this.underworldSpriteModeButton.Tag = ZeldaFullEditor.DungeonEditMode.Sprites;
			this.underworldSpriteModeButton.Text = "Object Mode";
			this.underworldSpriteModeButton.Click += new System.EventHandler(this.UpdateUnderworldMode);
			// 
			// blockmodeButton
			// 
			this.blockmodeButton.CheckOnClick = true;
			this.blockmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.blockmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("blockmodeButton.Image")));
			this.blockmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.blockmodeButton.Name = "blockmodeButton";
			this.blockmodeButton.Size = new System.Drawing.Size(23, 22);
			this.blockmodeButton.Tag = ZeldaFullEditor.DungeonEditMode.Blocks;
			this.blockmodeButton.Text = "Block Mode";
			this.blockmodeButton.Click += new System.EventHandler(this.UpdateUnderworldMode);
			// 
			// torchmodeButton
			// 
			this.torchmodeButton.CheckOnClick = true;
			this.torchmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.torchmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("torchmodeButton.Image")));
			this.torchmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.torchmodeButton.Name = "torchmodeButton";
			this.torchmodeButton.Size = new System.Drawing.Size(23, 22);
			this.torchmodeButton.Tag = ZeldaFullEditor.DungeonEditMode.Torches;
			this.torchmodeButton.Text = "Torch Mode";
			this.torchmodeButton.Click += new System.EventHandler(this.UpdateUnderworldMode);
			// 
			// potmodeButton
			// 
			this.potmodeButton.CheckOnClick = true;
			this.potmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.potmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("potmodeButton.Image")));
			this.potmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.potmodeButton.Name = "potmodeButton";
			this.potmodeButton.Size = new System.Drawing.Size(23, 22);
			this.potmodeButton.Tag = ZeldaFullEditor.DungeonEditMode.Secrets;
			this.potmodeButton.Text = "Secrets Mode";
			this.potmodeButton.Click += new System.EventHandler(this.UpdateUnderworldMode);
			// 
			// doormodeButton
			// 
			this.doormodeButton.CheckOnClick = true;
			this.doormodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.doormodeButton.Image = ((System.Drawing.Image)(resources.GetObject("doormodeButton.Image")));
			this.doormodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.doormodeButton.Name = "doormodeButton";
			this.doormodeButton.Size = new System.Drawing.Size(23, 22);
			this.doormodeButton.Tag = ZeldaFullEditor.DungeonEditMode.Doors;
			this.doormodeButton.Text = "Door Mode";
			this.doormodeButton.Click += new System.EventHandler(this.UpdateUnderworldMode);
			// 
			// collisionModeButton
			// 
			this.collisionModeButton.CheckOnClick = true;
			this.collisionModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.collisionModeButton.Image = ((System.Drawing.Image)(resources.GetObject("collisionModeButton.Image")));
			this.collisionModeButton.ImageTransparentColor = System.Drawing.Color.White;
			this.collisionModeButton.Name = "collisionModeButton";
			this.collisionModeButton.Size = new System.Drawing.Size(23, 22);
			this.collisionModeButton.Tag = ZeldaFullEditor.DungeonEditMode.CollisionMap;
			this.collisionModeButton.Text = "Collision Mode";
			this.collisionModeButton.Click += new System.EventHandler(this.UpdateUnderworldMode);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// saveLayoutButton
			// 
			this.saveLayoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveLayoutButton.Image = ((System.Drawing.Image)(resources.GetObject("saveLayoutButton.Image")));
			this.saveLayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveLayoutButton.Name = "saveLayoutButton";
			this.saveLayoutButton.Size = new System.Drawing.Size(23, 22);
			this.saveLayoutButton.Text = "Save Layout";
			// 
			// loadlayoutButton
			// 
			this.loadlayoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.loadlayoutButton.Image = ((System.Drawing.Image)(resources.GetObject("loadlayoutButton.Image")));
			this.loadlayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.loadlayoutButton.Name = "loadlayoutButton";
			this.loadlayoutButton.Size = new System.Drawing.Size(23, 22);
			this.loadlayoutButton.Text = "Load Layout…";
			// 
			// searchButton
			// 
			this.searchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
			this.searchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(23, 22);
			this.searchButton.Text = "toolStripButton2";
			// 
			// exportuwmapStripButton1
			// 
			this.exportuwmapStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.exportuwmapStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("exportuwmapStripButton1.Image")));
			this.exportuwmapStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.exportuwmapStripButton1.Name = "exportuwmapStripButton1";
			this.exportuwmapStripButton1.Size = new System.Drawing.Size(23, 22);
			this.exportuwmapStripButton1.Text = "Export Selected Rooms as PNG";
			this.exportuwmapStripButton1.ToolTipText = "Export map as png; Hold control and double click on the rooms you want to export." +
    "";
			this.exportuwmapStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
			// 
			// debugToolStripButton
			// 
			this.debugToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.debugToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("debugToolStripButton.Image")));
			this.debugToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.debugToolStripButton.Name = "debugToolStripButton";
			this.debugToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.debugToolStripButton.Text = "Debug";
			// 
			// entranceModeButton
			// 
			this.entranceModeButton.CheckOnClick = true;
			this.entranceModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.entranceModeButton.Image = ((System.Drawing.Image)(resources.GetObject("entranceModeButton.Image")));
			this.entranceModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.entranceModeButton.Name = "entranceModeButton";
			this.entranceModeButton.Size = new System.Drawing.Size(23, 22);
			this.entranceModeButton.Text = "Entrance mode";
			this.entranceModeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// exitModeButton
			// 
			this.exitModeButton.CheckOnClick = true;
			this.exitModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.exitModeButton.Image = ((System.Drawing.Image)(resources.GetObject("exitModeButton.Image")));
			this.exitModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.exitModeButton.Name = "exitModeButton";
			this.exitModeButton.Size = new System.Drawing.Size(23, 22);
			this.exitModeButton.Text = "Exit mode";
			this.exitModeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// itemModeButton
			// 
			this.itemModeButton.CheckOnClick = true;
			this.itemModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.itemModeButton.Image = ((System.Drawing.Image)(resources.GetObject("itemModeButton.Image")));
			this.itemModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.itemModeButton.Name = "itemModeButton";
			this.itemModeButton.Size = new System.Drawing.Size(23, 22);
			this.itemModeButton.Text = "Item mode";
			this.itemModeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// owSpriteModeButton
			// 
			this.owSpriteModeButton.CheckOnClick = true;
			this.owSpriteModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.owSpriteModeButton.Image = ((System.Drawing.Image)(resources.GetObject("owSpriteModeButton.Image")));
			this.owSpriteModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.owSpriteModeButton.Name = "owSpriteModeButton";
			this.owSpriteModeButton.Size = new System.Drawing.Size(23, 22);
			this.owSpriteModeButton.Text = "Sprite mode";
			this.owSpriteModeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// transportModeButton
			// 
			this.transportModeButton.CheckOnClick = true;
			this.transportModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.transportModeButton.Image = ((System.Drawing.Image)(resources.GetObject("transportModeButton.Image")));
			this.transportModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.transportModeButton.Name = "transportModeButton";
			this.transportModeButton.Size = new System.Drawing.Size(23, 22);
			this.transportModeButton.Text = "Transport mode";
			this.transportModeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// overlayButton
			// 
			this.overlayButton.CheckOnClick = true;
			this.overlayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.overlayButton.Image = ((System.Drawing.Image)(resources.GetObject("overlayButton.Image")));
			this.overlayButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.overlayButton.Name = "overlayButton";
			this.overlayButton.Size = new System.Drawing.Size(23, 22);
			this.overlayButton.Text = "Overlay";
			this.overlayButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// gravestoneButton
			// 
			this.gravestoneButton.CheckOnClick = true;
			this.gravestoneButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.gravestoneButton.Image = ((System.Drawing.Image)(resources.GetObject("gravestoneButton.Image")));
			this.gravestoneButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.gravestoneButton.Name = "gravestoneButton";
			this.gravestoneButton.Size = new System.Drawing.Size(23, 22);
			this.gravestoneButton.Text = "Overlay";
			this.gravestoneButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// searchtilesButton
			// 
			this.searchtilesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.searchtilesButton.Image = ((System.Drawing.Image)(resources.GetObject("searchtilesButton.Image")));
			this.searchtilesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.searchtilesButton.Name = "searchtilesButton";
			this.searchtilesButton.Size = new System.Drawing.Size(23, 22);
			this.searchtilesButton.Text = "Search for tiles";
			this.searchtilesButton.Click += new System.EventHandler(this.searchtilesButton_Click);
			// 
			// refreshToolStrip
			// 
			this.refreshToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.refreshToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStrip.Image")));
			this.refreshToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.refreshToolStrip.Name = "refreshToolStrip";
			this.refreshToolStrip.Size = new System.Drawing.Size(82, 22);
			this.refreshToolStrip.Text = "Refresh maps";
			this.refreshToolStrip.Click += new System.EventHandler(this.refreshToolStrip_Click);
			// 
			// clearmapbutton
			// 
			this.clearmapbutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.clearmapbutton.Image = ((System.Drawing.Image)(resources.GetObject("clearmapbutton.Image")));
			this.clearmapbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.clearmapbutton.Name = "clearmapbutton";
			this.clearmapbutton.Size = new System.Drawing.Size(65, 22);
			this.clearmapbutton.Text = "Clear map";
			this.clearmapbutton.Visible = false;
			// 
			// fillModeButton
			// 
			this.fillModeButton.CheckOnClick = true;
			this.fillModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fillModeButton.Image = ((System.Drawing.Image)(resources.GetObject("fillModeButton.Image")));
			this.fillModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fillModeButton.Name = "fillModeButton";
			this.fillModeButton.Size = new System.Drawing.Size(23, 22);
			this.fillModeButton.Text = "Fill mode";
			this.fillModeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// penModeButton
			// 
			this.penModeButton.Checked = true;
			this.penModeButton.CheckOnClick = true;
			this.penModeButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.penModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.penModeButton.Image = ((System.Drawing.Image)(resources.GetObject("penModeButton.Image")));
			this.penModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.penModeButton.Name = "penModeButton";
			this.penModeButton.Size = new System.Drawing.Size(23, 22);
			this.penModeButton.Text = "Tile mode";
			this.penModeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// spButton
			// 
			this.spButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.spButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.spButton.Image = ((System.Drawing.Image)(resources.GetObject("spButton.Image")));
			this.spButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.spButton.Name = "spButton";
			this.spButton.Size = new System.Drawing.Size(28, 22);
			this.spButton.Text = "SW";
			this.spButton.Click += new System.EventHandler(this.spButton_Click);
			// 
			// dwButton
			// 
			this.dwButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.dwButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.dwButton.Image = ((System.Drawing.Image)(resources.GetObject("dwButton.Image")));
			this.dwButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.dwButton.Name = "dwButton";
			this.dwButton.Size = new System.Drawing.Size(30, 22);
			this.dwButton.Text = "DW";
			this.dwButton.Click += new System.EventHandler(this.dwButton_Click);
			// 
			// lwButton
			// 
			this.lwButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.lwButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.lwButton.Image = ((System.Drawing.Image)(resources.GetObject("lwButton.Image")));
			this.lwButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.lwButton.Name = "lwButton";
			this.lwButton.Size = new System.Drawing.Size(27, 22);
			this.lwButton.Text = "LW";
			this.lwButton.Click += new System.EventHandler(this.lwButton_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectedObjectNameLabel,
            this.SelectedObjectXLabel,
            this.SelectedObjectYLabel,
            this.SelectedObjectLayerLabel,
            this.SelectedObjectSizeLabel,
            this.SelectedObjectDataLabel});
			this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.statusStrip1.Location = new System.Drawing.Point(306, 823);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(93, 18);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.Stretch = false;
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// SelectedObjectNameLabel
			// 
			this.SelectedObjectNameLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectedObjectNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.SelectedObjectNameLabel.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
			this.SelectedObjectNameLabel.Name = "SelectedObjectNameLabel";
			this.SelectedObjectNameLabel.Size = new System.Drawing.Size(68, 13);
			this.SelectedObjectNameLabel.Spring = true;
			this.SelectedObjectNameLabel.Text = "No Selection";
			// 
			// SelectedObjectXLabel
			// 
			this.SelectedObjectXLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectedObjectXLabel.Margin = new System.Windows.Forms.Padding(0, 3, 6, 2);
			this.SelectedObjectXLabel.Name = "SelectedObjectXLabel";
			this.SelectedObjectXLabel.Size = new System.Drawing.Size(10, 13);
			this.SelectedObjectXLabel.Text = "-";
			this.SelectedObjectXLabel.Visible = false;
			// 
			// SelectedObjectYLabel
			// 
			this.SelectedObjectYLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectedObjectYLabel.Margin = new System.Windows.Forms.Padding(0, 3, 6, 2);
			this.SelectedObjectYLabel.Name = "SelectedObjectYLabel";
			this.SelectedObjectYLabel.Size = new System.Drawing.Size(10, 13);
			this.SelectedObjectYLabel.Text = "-";
			this.SelectedObjectYLabel.Visible = false;
			// 
			// SelectedObjectLayerLabel
			// 
			this.SelectedObjectLayerLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectedObjectLayerLabel.Margin = new System.Windows.Forms.Padding(0, 3, 6, 2);
			this.SelectedObjectLayerLabel.Name = "SelectedObjectLayerLabel";
			this.SelectedObjectLayerLabel.Size = new System.Drawing.Size(10, 13);
			this.SelectedObjectLayerLabel.Text = "-";
			this.SelectedObjectLayerLabel.Visible = false;
			// 
			// SelectedObjectSizeLabel
			// 
			this.SelectedObjectSizeLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectedObjectSizeLabel.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
			this.SelectedObjectSizeLabel.Name = "SelectedObjectSizeLabel";
			this.SelectedObjectSizeLabel.Size = new System.Drawing.Size(10, 13);
			this.SelectedObjectSizeLabel.Text = "-";
			this.SelectedObjectSizeLabel.Visible = false;
			// 
			// SelectedObjectDataLabel
			// 
			this.SelectedObjectDataLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectedObjectDataLabel.Name = "SelectedObjectDataLabel";
			this.SelectedObjectDataLabel.Size = new System.Drawing.Size(10, 13);
			this.SelectedObjectDataLabel.Spring = true;
			this.SelectedObjectDataLabel.Text = "-";
			this.SelectedObjectDataLabel.Visible = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.testToolStripMenuItem,
            this.roomToolStripMenuItem,
            this.dungeonViewToolStripMenuItem,
            this.overworldToolStripMenuItem,
            this.areaToolStripMenuItem,
            this.overworldViewToolStripMenuItem,
            this.naviguateToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.jPDebugToolStripMenuItem,
            this.ExperimentalToolStripMenuItem1,
            this.helpToolStripMenuItem,
            this.discordToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(523, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.recentROMToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveasToolStripMenuItem});
			this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.openToolStripMenuItem.Text = "Open ROM…";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// recentROMToolStripMenuItem
			// 
			this.recentROMToolStripMenuItem.Name = "recentROMToolStripMenuItem";
			this.recentROMToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.recentROMToolStripMenuItem.Text = "Open recent ROM…";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.saveToolStripMenuItem.Text = "Save ROM";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.PerformSave);
			// 
			// saveasToolStripMenuItem
			// 
			this.saveasToolStripMenuItem.Enabled = false;
			this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
			this.saveasToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.saveasToolStripMenuItem.Text = "Save ROM as…";
			this.saveasToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
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
            this.decreaseObjectSizeToolStripMenuItem,
            this.increaseObjectSizeToolStripMenuItem,
            this.toolStripSeparator9,
            this.selectAllRoomsForExportToolStripMenuItem,
            this.deselectedAllRoomsForExportToolStripMenuItem,
            this.toolStripSeparator10,
            this.lockoverworldToolStripItem});
			this.editToolStripMenuItem.Enabled = false;
			this.editToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.undoToolStripMenuItem.Text = "Undo";
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.PerformUndo);
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.redoToolStripMenuItem.Text = "Redo";
			this.redoToolStripMenuItem.Click += new System.EventHandler(this.PerformRedo);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(232, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Enabled = false;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.cutToolStripMenuItem.Text = "Cut";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.PerformCut);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Enabled = false;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.PerformCopy);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Enabled = false;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PerformPaste);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Enabled = false;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.PerformDelete);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(232, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Enabled = false;
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.selectAllToolStripMenuItem.Text = "Select All";
			this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.PerformSelectAll);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(232, 6);
			// 
			// moveFrontToolStripMenuItem
			// 
			this.moveFrontToolStripMenuItem.Enabled = false;
			this.moveFrontToolStripMenuItem.Name = "moveFrontToolStripMenuItem";
			this.moveFrontToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.moveFrontToolStripMenuItem.Text = "Send to Front";
			this.moveFrontToolStripMenuItem.Click += new System.EventHandler(this.SendSelectedToFront);
			// 
			// bringToBackToolStripMenuItem
			// 
			this.bringToBackToolStripMenuItem.Enabled = false;
			this.bringToBackToolStripMenuItem.Name = "bringToBackToolStripMenuItem";
			this.bringToBackToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.bringToBackToolStripMenuItem.Text = "Send to Back";
			this.bringToBackToolStripMenuItem.Click += new System.EventHandler(this.SendSelectedToBack);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(232, 6);
			// 
			// decreaseObjectSizeToolStripMenuItem
			// 
			this.decreaseObjectSizeToolStripMenuItem.Name = "decreaseObjectSizeToolStripMenuItem";
			this.decreaseObjectSizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.decreaseObjectSizeToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.decreaseObjectSizeToolStripMenuItem.Text = "Decrease Object Size";
			this.decreaseObjectSizeToolStripMenuItem.Click += new System.EventHandler(this.decreaseObjectSizeToolStripMenuItem_Click);
			// 
			// increaseObjectSizeToolStripMenuItem
			// 
			this.increaseObjectSizeToolStripMenuItem.Name = "increaseObjectSizeToolStripMenuItem";
			this.increaseObjectSizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
			this.increaseObjectSizeToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.increaseObjectSizeToolStripMenuItem.Text = "Increase Object Size";
			this.increaseObjectSizeToolStripMenuItem.Click += new System.EventHandler(this.increaseObjectSizeToolStripMenuItem_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(232, 6);
			// 
			// selectAllRoomsForExportToolStripMenuItem
			// 
			this.selectAllRoomsForExportToolStripMenuItem.Name = "selectAllRoomsForExportToolStripMenuItem";
			this.selectAllRoomsForExportToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.selectAllRoomsForExportToolStripMenuItem.Text = "Select All Rooms for Export";
			this.selectAllRoomsForExportToolStripMenuItem.Click += new System.EventHandler(this.selectAllRoomsForExportToolStripMenuItem_Click);
			// 
			// deselectedAllRoomsForExportToolStripMenuItem
			// 
			this.deselectedAllRoomsForExportToolStripMenuItem.Name = "deselectedAllRoomsForExportToolStripMenuItem";
			this.deselectedAllRoomsForExportToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.deselectedAllRoomsForExportToolStripMenuItem.Text = "Deselect All Rooms";
			this.deselectedAllRoomsForExportToolStripMenuItem.Click += new System.EventHandler(this.deselectedAllRoomsForExportToolStripMenuItem_Click);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(232, 6);
			this.toolStripSeparator10.Visible = false;
			// 
			// lockoverworldToolStripItem
			// 
			this.lockoverworldToolStripItem.Name = "lockoverworldToolStripItem";
			this.lockoverworldToolStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
			this.lockoverworldToolStripItem.Size = new System.Drawing.Size(235, 22);
			this.lockoverworldToolStripItem.Text = "Lock Overworld Screen";
			this.lockoverworldToolStripItem.Visible = false;
			// 
			// projectToolStripMenuItem
			// 
			this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSettingsToolStripMenuItem,
            this.loadNamesFileToolStripMenuItem,
            this.memoryManagementToolStripMenuItem});
			this.projectToolStripMenuItem.Enabled = false;
			this.projectToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
			this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.projectToolStripMenuItem.Text = "Project";
			// 
			// saveSettingsToolStripMenuItem
			// 
			this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
			this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.saveSettingsToolStripMenuItem.Text = "Save Enable/Disable Settings…";
			this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
			// 
			// loadNamesFileToolStripMenuItem
			// 
			this.loadNamesFileToolStripMenuItem.Name = "loadNamesFileToolStripMenuItem";
			this.loadNamesFileToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.loadNamesFileToolStripMenuItem.Text = "Load Names File…";
			this.loadNamesFileToolStripMenuItem.Click += new System.EventHandler(this.loadNamesFileToolStripMenuItem_Click);
			// 
			// memoryManagementToolStripMenuItem
			// 
			this.memoryManagementToolStripMenuItem.Name = "memoryManagementToolStripMenuItem";
			this.memoryManagementToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.memoryManagementToolStripMenuItem.Text = "Memory Management";
			this.memoryManagementToolStripMenuItem.Click += new System.EventHandler(this.memoryManagementToolStripMenuItem_Click);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.debugRunToolStripMenuItem});
			this.testToolStripMenuItem.Enabled = false;
			this.testToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.testToolStripMenuItem.Text = "Test";
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.runToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.runToolStripMenuItem.Text = "Run…";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
			// 
			// debugRunToolStripMenuItem
			// 
			this.debugRunToolStripMenuItem.Name = "debugRunToolStripMenuItem";
			this.debugRunToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
			this.debugRunToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.debugRunToolStripMenuItem.Text = "Debug Run…";
			// 
			// roomToolStripMenuItem
			// 
			this.roomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoRoomToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.removeMaskObjectsToolStripMenuItem,
            this.printRoomObjectsToolStripMenuItem1,
            this.clearSelectedRoomToolStripMenuItem,
            this.clearAllRoomsToolStripMenuItem,
            this.exportAsASMToolStripMenuItem,
            this.exportAllRoomsToolStripMenuItem,
            this.exportSpritesAsBinaryToolStripMenuItem,
            this.importRoomToolStripMenuItem,
            this.showRoomsInHexToolStripMenuItem,
            this.selectedObjectInHexToolStripMenuItem,
            this.autoDoorsToolStripMenuItem});
			this.roomToolStripMenuItem.Enabled = false;
			this.roomToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.roomToolStripMenuItem.Name = "roomToolStripMenuItem";
			this.roomToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
			this.roomToolStripMenuItem.Text = "Dungeon";
			// 
			// gotoRoomToolStripMenuItem
			// 
			this.gotoRoomToolStripMenuItem.Name = "gotoRoomToolStripMenuItem";
			this.gotoRoomToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.gotoRoomToolStripMenuItem.Text = "Goto Room";
			this.gotoRoomToolStripMenuItem.Click += new System.EventHandler(this.gotoRoomToolStripMenuItem_Click_1);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(196, 22);
			this.toolStripMenuItem2.Text = "Dungeons Properties";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.dungeonsPropertiesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
			this.toolStripMenuItem1.Text = "Advanced Chest Editor";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.advancedChestEditorToolStripMenuItem_Click);
			// 
			// removeMaskObjectsToolStripMenuItem
			// 
			this.removeMaskObjectsToolStripMenuItem.Name = "removeMaskObjectsToolStripMenuItem";
			this.removeMaskObjectsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.removeMaskObjectsToolStripMenuItem.Text = "Remove Mask Objects";
			this.removeMaskObjectsToolStripMenuItem.Click += new System.EventHandler(this.removeMasksObjectsToolStripMenuItem_Click);
			// 
			// printRoomObjectsToolStripMenuItem1
			// 
			this.printRoomObjectsToolStripMenuItem1.Name = "printRoomObjectsToolStripMenuItem1";
			this.printRoomObjectsToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
			this.printRoomObjectsToolStripMenuItem1.Text = "Print Room Objects";
			this.printRoomObjectsToolStripMenuItem1.Click += new System.EventHandler(this.printRoomObjectsToolStripMenuItem_Click);
			// 
			// clearSelectedRoomToolStripMenuItem
			// 
			this.clearSelectedRoomToolStripMenuItem.Name = "clearSelectedRoomToolStripMenuItem";
			this.clearSelectedRoomToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.clearSelectedRoomToolStripMenuItem.Text = "Clear Selected Room";
			this.clearSelectedRoomToolStripMenuItem.Click += new System.EventHandler(this.clearSelectedRoomToolStripMenuItem_Click);
			// 
			// clearAllRoomsToolStripMenuItem
			// 
			this.clearAllRoomsToolStripMenuItem.Name = "clearAllRoomsToolStripMenuItem";
			this.clearAllRoomsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.clearAllRoomsToolStripMenuItem.Text = "Clear All Rooms";
			this.clearAllRoomsToolStripMenuItem.Click += new System.EventHandler(this.clearAllRoomsToolStripMenuItem_Click);
			// 
			// exportAsASMToolStripMenuItem
			// 
			this.exportAsASMToolStripMenuItem.Name = "exportAsASMToolStripMenuItem";
			this.exportAsASMToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.exportAsASMToolStripMenuItem.Text = "Export as Binary";
			this.exportAsASMToolStripMenuItem.Click += new System.EventHandler(this.exportAsASMToolStripMenuItem_Click);
			// 
			// exportAllRoomsToolStripMenuItem
			// 
			this.exportAllRoomsToolStripMenuItem.Name = "exportAllRoomsToolStripMenuItem";
			this.exportAllRoomsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.exportAllRoomsToolStripMenuItem.Text = "Export All Rooms";
			this.exportAllRoomsToolStripMenuItem.Click += new System.EventHandler(this.exportAllRoomsToolStripMenuItem_Click);
			// 
			// exportSpritesAsBinaryToolStripMenuItem
			// 
			this.exportSpritesAsBinaryToolStripMenuItem.Name = "exportSpritesAsBinaryToolStripMenuItem";
			this.exportSpritesAsBinaryToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.exportSpritesAsBinaryToolStripMenuItem.Text = "Export Sprites as Binary";
			this.exportSpritesAsBinaryToolStripMenuItem.Click += new System.EventHandler(this.exportSpritesAsBinaryToolStripMenuItem_Click);
			// 
			// importRoomToolStripMenuItem
			// 
			this.importRoomToolStripMenuItem.Name = "importRoomToolStripMenuItem";
			this.importRoomToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.importRoomToolStripMenuItem.Text = "Import Room";
			this.importRoomToolStripMenuItem.Click += new System.EventHandler(this.importRoomToolStripMenuItem_Click);
			// 
			// showRoomsInHexToolStripMenuItem
			// 
			this.showRoomsInHexToolStripMenuItem.CheckOnClick = true;
			this.showRoomsInHexToolStripMenuItem.Enabled = false;
			this.showRoomsInHexToolStripMenuItem.Name = "showRoomsInHexToolStripMenuItem";
			this.showRoomsInHexToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.showRoomsInHexToolStripMenuItem.Text = "Show Rooms in Hex";
			this.showRoomsInHexToolStripMenuItem.Click += new System.EventHandler(this.showRoomsInHexToolStripMenuItem_Click);
			// 
			// selectedObjectInHexToolStripMenuItem
			// 
			this.selectedObjectInHexToolStripMenuItem.Name = "selectedObjectInHexToolStripMenuItem";
			this.selectedObjectInHexToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.selectedObjectInHexToolStripMenuItem.Text = "Selected Object in Hex";
			// 
			// autoDoorsToolStripMenuItem
			// 
			this.autoDoorsToolStripMenuItem.Name = "autoDoorsToolStripMenuItem";
			this.autoDoorsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.autoDoorsToolStripMenuItem.Text = "Auto. Doors";
			this.autoDoorsToolStripMenuItem.Click += new System.EventHandler(this.autodoorButton_Click_1);
			// 
			// dungeonViewToolStripMenuItem
			// 
			this.dungeonViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textSpriteToolStripMenuItem,
            this.textChestItemToolStripMenuItem,
            this.textPotItemToolStripMenuItem,
            this.toolStripSeparator11,
            this.showGridToolStripMenuItem,
            this.showBG2ToolStripMenuItem,
            this.showBG1ToolStripMenuItem,
            this.unselectedBGTransparentToolStripMenuItem,
            this.darkThemeToolStripMenuItem,
            this.toolStripSeparator12,
            this.hideSpritesToolStripMenuItem,
            this.hideItemsToolStripMenuItem,
            this.hideChestItemsToolStripMenuItem,
            this.showDoorIDsToolStripMenuItem,
            this.showChestsIDsToolStripMenuItem,
            this.disableEntranceGFXToolStripMenuItem,
            this.xScreenToolStripMenuItem,
            this.showBG2MaskOutlineToolStripMenuItem,
            this.entrancePositionToolStripMenuItem,
            this.invisibleObjectsTextToolStripMenuItem,
            this.showMapIndexInHexToolStripMenuItem});
			this.dungeonViewToolStripMenuItem.Enabled = false;
			this.dungeonViewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dungeonViewToolStripMenuItem.Name = "dungeonViewToolStripMenuItem";
			this.dungeonViewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.dungeonViewToolStripMenuItem.Text = "View";
			// 
			// textSpriteToolStripMenuItem
			// 
			this.textSpriteToolStripMenuItem.CheckOnClick = true;
			this.textSpriteToolStripMenuItem.Name = "textSpriteToolStripMenuItem";
			this.textSpriteToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.textSpriteToolStripMenuItem.Text = "Show Sprite Text";
			this.textSpriteToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
			// 
			// textChestItemToolStripMenuItem
			// 
			this.textChestItemToolStripMenuItem.CheckOnClick = true;
			this.textChestItemToolStripMenuItem.Name = "textChestItemToolStripMenuItem";
			this.textChestItemToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.textChestItemToolStripMenuItem.Text = "Show Chest Item Text";
			this.textChestItemToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
			// 
			// textPotItemToolStripMenuItem
			// 
			this.textPotItemToolStripMenuItem.CheckOnClick = true;
			this.textPotItemToolStripMenuItem.Name = "textPotItemToolStripMenuItem";
			this.textPotItemToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.textPotItemToolStripMenuItem.Text = "Show Secrets Text";
			this.textPotItemToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(273, 6);
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
			this.showGridToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.showGridToolStripMenuItem.Text = "Show Grid";
			this.showGridToolStripMenuItem.Click += new System.EventHandler(this.showGridToolStripMenuItem_Click);
			// 
			// x8ToolStripMenuItem
			// 
			this.x8ToolStripMenuItem.CheckOnClick = true;
			this.x8ToolStripMenuItem.Name = "x8ToolStripMenuItem";
			this.x8ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.x8ToolStripMenuItem.Text = "8x8";
			this.x8ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
			// 
			// x16ToolStripMenuItem
			// 
			this.x16ToolStripMenuItem.CheckOnClick = true;
			this.x16ToolStripMenuItem.Name = "x16ToolStripMenuItem";
			this.x16ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.x16ToolStripMenuItem.Text = "16x16";
			this.x16ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
			// 
			// x32ToolStripMenuItem
			// 
			this.x32ToolStripMenuItem.CheckOnClick = true;
			this.x32ToolStripMenuItem.Name = "x32ToolStripMenuItem";
			this.x32ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.x32ToolStripMenuItem.Text = "32x32";
			this.x32ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
			// 
			// x64ToolStripMenuItem
			// 
			this.x64ToolStripMenuItem.CheckOnClick = true;
			this.x64ToolStripMenuItem.Name = "x64ToolStripMenuItem";
			this.x64ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.x64ToolStripMenuItem.Text = "64x64";
			this.x64ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
			// 
			// x256ToolStripMenuItem
			// 
			this.x256ToolStripMenuItem.CheckOnClick = true;
			this.x256ToolStripMenuItem.Name = "x256ToolStripMenuItem";
			this.x256ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.x256ToolStripMenuItem.Text = "256x256";
			this.x256ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
			// 
			// showBG2ToolStripMenuItem
			// 
			this.showBG2ToolStripMenuItem.Checked = true;
			this.showBG2ToolStripMenuItem.CheckOnClick = true;
			this.showBG2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showBG2ToolStripMenuItem.Name = "showBG2ToolStripMenuItem";
			this.showBG2ToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.showBG2ToolStripMenuItem.Text = "Show Layer 2";
			this.showBG2ToolStripMenuItem.Click += new System.EventHandler(this.showBG2ToolStripMenuItem_Click);
			// 
			// showBG1ToolStripMenuItem
			// 
			this.showBG1ToolStripMenuItem.Checked = true;
			this.showBG1ToolStripMenuItem.CheckOnClick = true;
			this.showBG1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showBG1ToolStripMenuItem.Name = "showBG1ToolStripMenuItem";
			this.showBG1ToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.showBG1ToolStripMenuItem.Text = "Show Layer 1";
			this.showBG1ToolStripMenuItem.Click += new System.EventHandler(this.showBG1ToolStripMenuItem_Click);
			// 
			// unselectedBGTransparentToolStripMenuItem
			// 
			this.unselectedBGTransparentToolStripMenuItem.Checked = true;
			this.unselectedBGTransparentToolStripMenuItem.CheckOnClick = true;
			this.unselectedBGTransparentToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.unselectedBGTransparentToolStripMenuItem.Name = "unselectedBGTransparentToolStripMenuItem";
			this.unselectedBGTransparentToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.unselectedBGTransparentToolStripMenuItem.Text = "Display Unselected Layer Translucently";
			// 
			// darkThemeToolStripMenuItem
			// 
			this.darkThemeToolStripMenuItem.CheckOnClick = true;
			this.darkThemeToolStripMenuItem.Enabled = false;
			this.darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
			this.darkThemeToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.darkThemeToolStripMenuItem.Text = "Dark Theme";
			this.darkThemeToolStripMenuItem.Click += new System.EventHandler(this.darkThemeToolStripMenuItem_Click);
			// 
			// toolStripSeparator12
			// 
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(273, 6);
			// 
			// hideSpritesToolStripMenuItem
			// 
			this.hideSpritesToolStripMenuItem.Checked = true;
			this.hideSpritesToolStripMenuItem.CheckOnClick = true;
			this.hideSpritesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.hideSpritesToolStripMenuItem.Name = "hideSpritesToolStripMenuItem";
			this.hideSpritesToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.hideSpritesToolStripMenuItem.Text = "Show Sprites";
			this.hideSpritesToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
			// 
			// hideItemsToolStripMenuItem
			// 
			this.hideItemsToolStripMenuItem.Checked = true;
			this.hideItemsToolStripMenuItem.CheckOnClick = true;
			this.hideItemsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.hideItemsToolStripMenuItem.Name = "hideItemsToolStripMenuItem";
			this.hideItemsToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.hideItemsToolStripMenuItem.Text = "Show Items";
			this.hideItemsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
			// 
			// hideChestItemsToolStripMenuItem
			// 
			this.hideChestItemsToolStripMenuItem.Checked = true;
			this.hideChestItemsToolStripMenuItem.CheckOnClick = true;
			this.hideChestItemsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.hideChestItemsToolStripMenuItem.Name = "hideChestItemsToolStripMenuItem";
			this.hideChestItemsToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.hideChestItemsToolStripMenuItem.Text = "Show Chest Items";
			this.hideChestItemsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
			// 
			// showDoorIDsToolStripMenuItem
			// 
			this.showDoorIDsToolStripMenuItem.Checked = true;
			this.showDoorIDsToolStripMenuItem.CheckOnClick = true;
			this.showDoorIDsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showDoorIDsToolStripMenuItem.Name = "showDoorIDsToolStripMenuItem";
			this.showDoorIDsToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.showDoorIDsToolStripMenuItem.Text = "Show Door Index";
			this.showDoorIDsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
			// 
			// showChestsIDsToolStripMenuItem
			// 
			this.showChestsIDsToolStripMenuItem.Checked = true;
			this.showChestsIDsToolStripMenuItem.CheckOnClick = true;
			this.showChestsIDsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showChestsIDsToolStripMenuItem.Name = "showChestsIDsToolStripMenuItem";
			this.showChestsIDsToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.showChestsIDsToolStripMenuItem.Text = "Show Chest Index";
			this.showChestsIDsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
			// 
			// disableEntranceGFXToolStripMenuItem
			// 
			this.disableEntranceGFXToolStripMenuItem.CheckOnClick = true;
			this.disableEntranceGFXToolStripMenuItem.Name = "disableEntranceGFXToolStripMenuItem";
			this.disableEntranceGFXToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.disableEntranceGFXToolStripMenuItem.Text = "Use current entrance graphics";
			this.disableEntranceGFXToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
			// 
			// xScreenToolStripMenuItem
			// 
			this.xScreenToolStripMenuItem.CheckOnClick = true;
			this.xScreenToolStripMenuItem.Name = "xScreenToolStripMenuItem";
			this.xScreenToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.xScreenToolStripMenuItem.Text = "2X Zoom";
			this.xScreenToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
			this.xScreenToolStripMenuItem.Click += new System.EventHandler(this.DungeonMain_SizeChanged);
			// 
			// showBG2MaskOutlineToolStripMenuItem
			// 
			this.showBG2MaskOutlineToolStripMenuItem.Checked = true;
			this.showBG2MaskOutlineToolStripMenuItem.CheckOnClick = true;
			this.showBG2MaskOutlineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showBG2MaskOutlineToolStripMenuItem.Name = "showBG2MaskOutlineToolStripMenuItem";
			this.showBG2MaskOutlineToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.showBG2MaskOutlineToolStripMenuItem.Text = "Outline Layer Masks";
			this.showBG2MaskOutlineToolStripMenuItem.Click += new System.EventHandler(this.showBG2MaskOutlineToolStripMenuItem_Click);
			// 
			// entrancePositionToolStripMenuItem
			// 
			this.entrancePositionToolStripMenuItem.Checked = true;
			this.entrancePositionToolStripMenuItem.CheckOnClick = true;
			this.entrancePositionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.entrancePositionToolStripMenuItem.Name = "entrancePositionToolStripMenuItem";
			this.entrancePositionToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.entrancePositionToolStripMenuItem.Text = "Show Entrance Cameras";
			this.entrancePositionToolStripMenuItem.Click += new System.EventHandler(this.entrancePositionToolStripMenuItem_Click);
			// 
			// invisibleObjectsTextToolStripMenuItem
			// 
			this.invisibleObjectsTextToolStripMenuItem.Checked = true;
			this.invisibleObjectsTextToolStripMenuItem.CheckOnClick = true;
			this.invisibleObjectsTextToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.invisibleObjectsTextToolStripMenuItem.Name = "invisibleObjectsTextToolStripMenuItem";
			this.invisibleObjectsTextToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.invisibleObjectsTextToolStripMenuItem.Text = "Show Text for Invisible Objects";
			// 
			// showMapIndexInHexToolStripMenuItem
			// 
			this.showMapIndexInHexToolStripMenuItem.Checked = true;
			this.showMapIndexInHexToolStripMenuItem.CheckOnClick = true;
			this.showMapIndexInHexToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showMapIndexInHexToolStripMenuItem.Enabled = false;
			this.showMapIndexInHexToolStripMenuItem.Name = "showMapIndexInHexToolStripMenuItem";
			this.showMapIndexInHexToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.showMapIndexInHexToolStripMenuItem.Text = "Display Map ID in Hexadecimal";
			this.showMapIndexInHexToolStripMenuItem.Click += new System.EventHandler(this.showMapIndexInHexToolStripMenuItem_Click);
			// 
			// overworldToolStripMenuItem
			// 
			this.overworldToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearSpritesToolStripMenuItem,
            this.clearItemsToolStripMenuItem,
            this.clearEntrancesToolStripMenuItem,
            this.clearAllHolesToolStripMenuItem,
            this.clearExitsToolStripMenuItem,
            this.clearAllOverlaysToolStripMenuItem,
            this.toolStripMenuItem6,
            this.toolStripMenuItem5,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem7});
			this.overworldToolStripMenuItem.Enabled = false;
			this.overworldToolStripMenuItem.Name = "overworldToolStripMenuItem";
			this.overworldToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
			this.overworldToolStripMenuItem.Text = "Overworld";
			this.overworldToolStripMenuItem.Visible = false;
			// 
			// clearSpritesToolStripMenuItem
			// 
			this.clearSpritesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveZeldaToolStripMenuItem,
            this.zeldaSavedToolStripMenuItem,
            this.agahDeadToolStripMenuItem});
			this.clearSpritesToolStripMenuItem.Name = "clearSpritesToolStripMenuItem";
			this.clearSpritesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.clearSpritesToolStripMenuItem.Text = "Clear All Sprites";
			// 
			// saveZeldaToolStripMenuItem
			// 
			this.saveZeldaToolStripMenuItem.Name = "saveZeldaToolStripMenuItem";
			this.saveZeldaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.saveZeldaToolStripMenuItem.Text = "1. (Save Zelda)";
			this.saveZeldaToolStripMenuItem.Click += new System.EventHandler(this.clearPhase1OWSpritesToolStripMenuItem_Click);
			// 
			// zeldaSavedToolStripMenuItem
			// 
			this.zeldaSavedToolStripMenuItem.Name = "zeldaSavedToolStripMenuItem";
			this.zeldaSavedToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.zeldaSavedToolStripMenuItem.Text = "2. (Zelda Saved)";
			this.zeldaSavedToolStripMenuItem.Click += new System.EventHandler(this.clearPhase2OWSpritesToolStripMenuItem_Click);
			// 
			// agahDeadToolStripMenuItem
			// 
			this.agahDeadToolStripMenuItem.Name = "agahDeadToolStripMenuItem";
			this.agahDeadToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.agahDeadToolStripMenuItem.Text = "3. (Agah. Dead)";
			this.agahDeadToolStripMenuItem.Click += new System.EventHandler(this.clearPhase3OWSpritesToolStripMenuItem_Click);
			// 
			// clearItemsToolStripMenuItem
			// 
			this.clearItemsToolStripMenuItem.Name = "clearItemsToolStripMenuItem";
			this.clearItemsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.clearItemsToolStripMenuItem.Text = "Clear All Items";
			this.clearItemsToolStripMenuItem.Click += new System.EventHandler(this.clearAllOWItemsToolStripMenuItem_Click);
			// 
			// clearEntrancesToolStripMenuItem
			// 
			this.clearEntrancesToolStripMenuItem.Name = "clearEntrancesToolStripMenuItem";
			this.clearEntrancesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.clearEntrancesToolStripMenuItem.Text = "Clear All Entrances";
			this.clearEntrancesToolStripMenuItem.Click += new System.EventHandler(this.clearAllOWEntrancesToolStripMenuItem_Click);
			// 
			// clearAllHolesToolStripMenuItem
			// 
			this.clearAllHolesToolStripMenuItem.Name = "clearAllHolesToolStripMenuItem";
			this.clearAllHolesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.clearAllHolesToolStripMenuItem.Text = "Clear All Holes";
			this.clearAllHolesToolStripMenuItem.Click += new System.EventHandler(this.clearAllOWHolesToolStripMenuItem_Click);
			// 
			// clearExitsToolStripMenuItem
			// 
			this.clearExitsToolStripMenuItem.Name = "clearExitsToolStripMenuItem";
			this.clearExitsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.clearExitsToolStripMenuItem.Text = "Clear All Exits";
			this.clearExitsToolStripMenuItem.Click += new System.EventHandler(this.clearAllOWExitsToolStripMenuItem_Click);
			// 
			// clearAllOverlaysToolStripMenuItem
			// 
			this.clearAllOverlaysToolStripMenuItem.Name = "clearAllOverlaysToolStripMenuItem";
			this.clearAllOverlaysToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.clearAllOverlaysToolStripMenuItem.Text = "Clear All Overlays";
			this.clearAllOverlaysToolStripMenuItem.Click += new System.EventHandler(this.clearAllOverworldOverlaysToolStripMenuItem_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(172, 22);
			this.toolStripMenuItem6.Text = "Export All Areas";
			this.toolStripMenuItem6.Click += new System.EventHandler(this.exportAllMapsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(172, 22);
			this.toolStripMenuItem5.Text = "Import All Areas";
			this.toolStripMenuItem5.Click += new System.EventHandler(this.importAllMapsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem9
			// 
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new System.Drawing.Size(172, 22);
			this.toolStripMenuItem9.Text = "Export All Tiles";
			this.toolStripMenuItem9.Click += new System.EventHandler(this.exportAllTilesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem10
			// 
			this.toolStripMenuItem10.Name = "toolStripMenuItem10";
			this.toolStripMenuItem10.Size = new System.Drawing.Size(172, 22);
			this.toolStripMenuItem10.Text = "Import All Tiles";
			this.toolStripMenuItem10.Click += new System.EventHandler(this.importAllTilesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Enabled = false;
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(172, 22);
			this.toolStripMenuItem7.Text = "Import from ROM";
			// 
			// areaToolStripMenuItem
			// 
			this.areaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearSpritesToolStripMenuItem1,
            this.clearItemsToolStripMenuItem1,
            this.clearEntrancesToolStripMenuItem1,
            this.clearHolesToolStripMenuItem,
            this.clearExitsToolStripMenuItem1,
            this.clearOverlaysToolStripMenuItem});
			this.areaToolStripMenuItem.Enabled = false;
			this.areaToolStripMenuItem.Name = "areaToolStripMenuItem";
			this.areaToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.areaToolStripMenuItem.Text = "Area";
			this.areaToolStripMenuItem.Visible = false;
			// 
			// clearSpritesToolStripMenuItem1
			// 
			this.clearSpritesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveZeldaToolStripMenuItem1,
            this.zeldaSavedToolStripMenuItem1,
            this.agahDeadToolStripMenuItem1});
			this.clearSpritesToolStripMenuItem1.Name = "clearSpritesToolStripMenuItem1";
			this.clearSpritesToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
			this.clearSpritesToolStripMenuItem1.Text = "Clear Area Sprites";
			// 
			// saveZeldaToolStripMenuItem1
			// 
			this.saveZeldaToolStripMenuItem1.Name = "saveZeldaToolStripMenuItem1";
			this.saveZeldaToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
			this.saveZeldaToolStripMenuItem1.Text = "1. (Save Zelda)";
			this.saveZeldaToolStripMenuItem1.Click += new System.EventHandler(this.clearPhase1AreaSpritesToolStripMenuItem_Click);
			// 
			// zeldaSavedToolStripMenuItem1
			// 
			this.zeldaSavedToolStripMenuItem1.Name = "zeldaSavedToolStripMenuItem1";
			this.zeldaSavedToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
			this.zeldaSavedToolStripMenuItem1.Text = "2. (Zelda Saved)";
			this.zeldaSavedToolStripMenuItem1.Click += new System.EventHandler(this.clearPhase2AreaSpritesToolStripMenuItem_Click);
			// 
			// agahDeadToolStripMenuItem1
			// 
			this.agahDeadToolStripMenuItem1.Name = "agahDeadToolStripMenuItem1";
			this.agahDeadToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
			this.agahDeadToolStripMenuItem1.Text = "3. (Agah. Dead)";
			this.agahDeadToolStripMenuItem1.Click += new System.EventHandler(this.clearPhase3AreaSpritesToolStripMenuItem_Click);
			// 
			// clearItemsToolStripMenuItem1
			// 
			this.clearItemsToolStripMenuItem1.Name = "clearItemsToolStripMenuItem1";
			this.clearItemsToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
			this.clearItemsToolStripMenuItem1.Text = "Clear Area Items";
			this.clearItemsToolStripMenuItem1.Click += new System.EventHandler(this.clearAllAreaItemsToolStripMenuItem_Click);
			// 
			// clearEntrancesToolStripMenuItem1
			// 
			this.clearEntrancesToolStripMenuItem1.Name = "clearEntrancesToolStripMenuItem1";
			this.clearEntrancesToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
			this.clearEntrancesToolStripMenuItem1.Text = "Clear Area Entrances";
			this.clearEntrancesToolStripMenuItem1.Click += new System.EventHandler(this.clearAllAreaEntrancesToolStripMenuItem_Click);
			// 
			// clearHolesToolStripMenuItem
			// 
			this.clearHolesToolStripMenuItem.Name = "clearHolesToolStripMenuItem";
			this.clearHolesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.clearHolesToolStripMenuItem.Text = "Clear Area Holes";
			this.clearHolesToolStripMenuItem.Click += new System.EventHandler(this.clearAllAreaHolesToolStripMenuItem_Click);
			// 
			// clearExitsToolStripMenuItem1
			// 
			this.clearExitsToolStripMenuItem1.Name = "clearExitsToolStripMenuItem1";
			this.clearExitsToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
			this.clearExitsToolStripMenuItem1.Text = "Clear Area Exits";
			this.clearExitsToolStripMenuItem1.Click += new System.EventHandler(this.clearAllAreaExitsToolStripMenuItem_Click);
			// 
			// clearOverlaysToolStripMenuItem
			// 
			this.clearOverlaysToolStripMenuItem.Name = "clearOverlaysToolStripMenuItem";
			this.clearOverlaysToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.clearOverlaysToolStripMenuItem.Text = "Clear Area Overlays";
			this.clearOverlaysToolStripMenuItem.Click += new System.EventHandler(this.clearAllAreaOverlaysToolStripMenuItem_Click);
			// 
			// overworldViewToolStripMenuItem
			// 
			this.overworldViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSpritesToolStripMenuItem,
            this.showEntrancesToolStripMenuItem,
            this.showExitsToolStripMenuItem,
            this.showTransportsToolStripMenuItem,
            this.showItemsToolStripMenuItem,
            this.showEntranceExitPreviewToolStripMenuItem,
            this.overworldOverlayVisibleToolStripMenuItem,
            this.showGridToolStripMenuItem1});
			this.overworldViewToolStripMenuItem.Enabled = false;
			this.overworldViewToolStripMenuItem.Name = "overworldViewToolStripMenuItem";
			this.overworldViewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.overworldViewToolStripMenuItem.Text = "View";
			this.overworldViewToolStripMenuItem.Visible = false;
			// 
			// showSpritesToolStripMenuItem
			// 
			this.showSpritesToolStripMenuItem.Checked = true;
			this.showSpritesToolStripMenuItem.CheckOnClick = true;
			this.showSpritesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showSpritesToolStripMenuItem.Name = "showSpritesToolStripMenuItem";
			this.showSpritesToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.showSpritesToolStripMenuItem.Text = "Show sSprites";
			this.showSpritesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showSpritesToolStripMenuItem_CheckedChanged);
			// 
			// showEntrancesToolStripMenuItem
			// 
			this.showEntrancesToolStripMenuItem.Checked = true;
			this.showEntrancesToolStripMenuItem.CheckOnClick = true;
			this.showEntrancesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showEntrancesToolStripMenuItem.Name = "showEntrancesToolStripMenuItem";
			this.showEntrancesToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.showEntrancesToolStripMenuItem.Text = "Show Entrances";
			this.showEntrancesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showSpritesToolStripMenuItem_CheckedChanged);
			// 
			// showExitsToolStripMenuItem
			// 
			this.showExitsToolStripMenuItem.Checked = true;
			this.showExitsToolStripMenuItem.CheckOnClick = true;
			this.showExitsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showExitsToolStripMenuItem.Name = "showExitsToolStripMenuItem";
			this.showExitsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.showExitsToolStripMenuItem.Text = "Show Exits";
			this.showExitsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showSpritesToolStripMenuItem_CheckedChanged);
			// 
			// showTransportsToolStripMenuItem
			// 
			this.showTransportsToolStripMenuItem.Checked = true;
			this.showTransportsToolStripMenuItem.CheckOnClick = true;
			this.showTransportsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showTransportsToolStripMenuItem.Name = "showTransportsToolStripMenuItem";
			this.showTransportsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.showTransportsToolStripMenuItem.Text = "Show Transports";
			this.showTransportsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showSpritesToolStripMenuItem_CheckedChanged);
			// 
			// showItemsToolStripMenuItem
			// 
			this.showItemsToolStripMenuItem.Checked = true;
			this.showItemsToolStripMenuItem.CheckOnClick = true;
			this.showItemsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showItemsToolStripMenuItem.Name = "showItemsToolStripMenuItem";
			this.showItemsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.showItemsToolStripMenuItem.Text = "Show Items";
			this.showItemsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showSpritesToolStripMenuItem_CheckedChanged);
			// 
			// showEntranceExitPreviewToolStripMenuItem
			// 
			this.showEntranceExitPreviewToolStripMenuItem.Checked = true;
			this.showEntranceExitPreviewToolStripMenuItem.CheckOnClick = true;
			this.showEntranceExitPreviewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showEntranceExitPreviewToolStripMenuItem.Name = "showEntranceExitPreviewToolStripMenuItem";
			this.showEntranceExitPreviewToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.showEntranceExitPreviewToolStripMenuItem.Text = "Show Entrance/Exit Previews";
			this.showEntranceExitPreviewToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showSpritesToolStripMenuItem_CheckedChanged);
			// 
			// overworldOverlayVisibleToolStripMenuItem
			// 
			this.overworldOverlayVisibleToolStripMenuItem.CheckOnClick = true;
			this.overworldOverlayVisibleToolStripMenuItem.Name = "overworldOverlayVisibleToolStripMenuItem";
			this.overworldOverlayVisibleToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.overworldOverlayVisibleToolStripMenuItem.Text = "Always Show Overworld Overlay";
			// 
			// showGridToolStripMenuItem1
			// 
			this.showGridToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x8ToolStripMenuItem1,
            this.x16ToolStripMenuItem1,
            this.x32ToolStripMenuItem1,
            this.noneToolStripMenuItem});
			this.showGridToolStripMenuItem1.Name = "showGridToolStripMenuItem1";
			this.showGridToolStripMenuItem1.Size = new System.Drawing.Size(244, 22);
			this.showGridToolStripMenuItem1.Text = "Show Grid";
			// 
			// x8ToolStripMenuItem1
			// 
			this.x8ToolStripMenuItem1.Name = "x8ToolStripMenuItem1";
			this.x8ToolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
			this.x8ToolStripMenuItem1.Text = "8x8";
			this.x8ToolStripMenuItem1.Click += new System.EventHandler(this.x8ToolStripMenuItem1_Click);
			// 
			// x16ToolStripMenuItem1
			// 
			this.x16ToolStripMenuItem1.Name = "x16ToolStripMenuItem1";
			this.x16ToolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
			this.x16ToolStripMenuItem1.Text = "16x16";
			this.x16ToolStripMenuItem1.Click += new System.EventHandler(this.x8ToolStripMenuItem1_Click);
			// 
			// x32ToolStripMenuItem1
			// 
			this.x32ToolStripMenuItem1.Name = "x32ToolStripMenuItem1";
			this.x32ToolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
			this.x32ToolStripMenuItem1.Text = "32x32";
			this.x32ToolStripMenuItem1.Click += new System.EventHandler(this.x8ToolStripMenuItem1_Click);
			// 
			// noneToolStripMenuItem
			// 
			this.noneToolStripMenuItem.Checked = true;
			this.noneToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
			this.noneToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
			this.noneToolStripMenuItem.Text = "None";
			this.noneToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem1_Click);
			// 
			// naviguateToolStripMenuItem
			// 
			this.naviguateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToRightToolStripMenuItem,
            this.moveToLeftToolStripMenuItem,
            this.moveToUpToolStripMenuItem,
            this.moveToDownToolStripMenuItem,
            this.toolStripSeparator8,
            this.openRightRoomToolStripMenuItem,
            this.openLeftRoomToolStripMenuItem,
            this.openUpRoomToolStripMenuItem,
            this.openDownRoomToolStripMenuItem});
			this.naviguateToolStripMenuItem.Enabled = false;
			this.naviguateToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.naviguateToolStripMenuItem.Name = "naviguateToolStripMenuItem";
			this.naviguateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.naviguateToolStripMenuItem.Text = "Navigate";
			// 
			// moveToRightToolStripMenuItem
			// 
			this.moveToRightToolStripMenuItem.Enabled = false;
			this.moveToRightToolStripMenuItem.Name = "moveToRightToolStripMenuItem";
			this.moveToRightToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Right)));
			this.moveToRightToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
			this.moveToRightToolStripMenuItem.Text = "Move 1 Room to the East";
			// 
			// moveToLeftToolStripMenuItem
			// 
			this.moveToLeftToolStripMenuItem.Enabled = false;
			this.moveToLeftToolStripMenuItem.Name = "moveToLeftToolStripMenuItem";
			this.moveToLeftToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Left)));
			this.moveToLeftToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
			this.moveToLeftToolStripMenuItem.Text = "Move 1 Room to the West";
			// 
			// moveToUpToolStripMenuItem
			// 
			this.moveToUpToolStripMenuItem.Enabled = false;
			this.moveToUpToolStripMenuItem.Name = "moveToUpToolStripMenuItem";
			this.moveToUpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
			this.moveToUpToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
			this.moveToUpToolStripMenuItem.Text = "Move 1 Room to the North";
			// 
			// moveToDownToolStripMenuItem
			// 
			this.moveToDownToolStripMenuItem.Enabled = false;
			this.moveToDownToolStripMenuItem.Name = "moveToDownToolStripMenuItem";
			this.moveToDownToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
			this.moveToDownToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
			this.moveToDownToolStripMenuItem.Text = "Move 1 Room to the South";
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(274, 6);
			// 
			// openRightRoomToolStripMenuItem
			// 
			this.openRightRoomToolStripMenuItem.Name = "openRightRoomToolStripMenuItem";
			this.openRightRoomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
			this.openRightRoomToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
			this.openRightRoomToolStripMenuItem.Text = "Open Room to the East";
			this.openRightRoomToolStripMenuItem.Click += new System.EventHandler(this.openRightRoomToolStripMenuItem_Click);
			// 
			// openLeftRoomToolStripMenuItem
			// 
			this.openLeftRoomToolStripMenuItem.Name = "openLeftRoomToolStripMenuItem";
			this.openLeftRoomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
			this.openLeftRoomToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
			this.openLeftRoomToolStripMenuItem.Text = "Open Room to the West";
			this.openLeftRoomToolStripMenuItem.Click += new System.EventHandler(this.openLeftRoomToolStripMenuItem_Click);
			// 
			// openUpRoomToolStripMenuItem
			// 
			this.openUpRoomToolStripMenuItem.Name = "openUpRoomToolStripMenuItem";
			this.openUpRoomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
			this.openUpRoomToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
			this.openUpRoomToolStripMenuItem.Text = "Open Room to the North";
			this.openUpRoomToolStripMenuItem.Click += new System.EventHandler(this.openUpRoomToolStripMenuItem_Click);
			// 
			// openDownRoomToolStripMenuItem
			// 
			this.openDownRoomToolStripMenuItem.Name = "openDownRoomToolStripMenuItem";
			this.openDownRoomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
			this.openDownRoomToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
			this.openDownRoomToolStripMenuItem.Text = "Open Room to the South";
			this.openDownRoomToolStripMenuItem.Click += new System.EventHandler(this.openDownRoomToolStripMenuItem_Click);
			// 
			// windowToolStripMenuItem
			// 
			this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vramViewerToolStripMenuItem,
            this.cGramViewerToolStripMenuItem,
            this.gfxGroupsetsToolStripMenuItem,
            this.palettesEditorToolStripMenuItem});
			this.windowToolStripMenuItem.Enabled = false;
			this.windowToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
			this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.windowToolStripMenuItem.Text = "Window";
			// 
			// vramViewerToolStripMenuItem
			// 
			this.vramViewerToolStripMenuItem.Name = "vramViewerToolStripMenuItem";
			this.vramViewerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.vramViewerToolStripMenuItem.Text = "VRAM Viewer";
			this.vramViewerToolStripMenuItem.Click += new System.EventHandler(this.vramViewerToolStripMenuItem_Click);
			// 
			// cGramViewerToolStripMenuItem
			// 
			this.cGramViewerToolStripMenuItem.Name = "cGramViewerToolStripMenuItem";
			this.cGramViewerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.cGramViewerToolStripMenuItem.Text = "CGRAM Viewer";
			this.cGramViewerToolStripMenuItem.Click += new System.EventHandler(this.cGramViewerToolStripMenuItem_Click);
			// 
			// gfxGroupsetsToolStripMenuItem
			// 
			this.gfxGroupsetsToolStripMenuItem.Name = "gfxGroupsetsToolStripMenuItem";
			this.gfxGroupsetsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.gfxGroupsetsToolStripMenuItem.Text = "Graphics Groups";
			this.gfxGroupsetsToolStripMenuItem.Click += new System.EventHandler(this.gfxGroupsetsToolStripMenuItem_Click);
			// 
			// palettesEditorToolStripMenuItem
			// 
			this.palettesEditorToolStripMenuItem.Name = "palettesEditorToolStripMenuItem";
			this.palettesEditorToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.palettesEditorToolStripMenuItem.Text = "Palettes Editor";
			this.palettesEditorToolStripMenuItem.Click += new System.EventHandler(this.palettesEditorToolStripMenuItem_Click);
			// 
			// jPDebugToolStripMenuItem
			// 
			this.jPDebugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapDataFromJPdoNotUseToolStripMenuItem1,
            this.captureMapJPdoNotUseToolStripMenuItem1,
            this.exportMapJPdoNotUseToolStripMenuItem1});
			this.jPDebugToolStripMenuItem.Enabled = false;
			this.jPDebugToolStripMenuItem.Name = "jPDebugToolStripMenuItem";
			this.jPDebugToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
			this.jPDebugToolStripMenuItem.Text = "JP Debug";
			this.jPDebugToolStripMenuItem.Visible = false;
			// 
			// mapDataFromJPdoNotUseToolStripMenuItem1
			// 
			this.mapDataFromJPdoNotUseToolStripMenuItem1.Name = "mapDataFromJPdoNotUseToolStripMenuItem1";
			this.mapDataFromJPdoNotUseToolStripMenuItem1.Size = new System.Drawing.Size(232, 22);
			this.mapDataFromJPdoNotUseToolStripMenuItem1.Text = "MapData from JP (do not use)";
			this.mapDataFromJPdoNotUseToolStripMenuItem1.Click += new System.EventHandler(this.mapDataFromJPdoNotUseToolStripMenuItem_Click);
			// 
			// captureMapJPdoNotUseToolStripMenuItem1
			// 
			this.captureMapJPdoNotUseToolStripMenuItem1.Name = "captureMapJPdoNotUseToolStripMenuItem1";
			this.captureMapJPdoNotUseToolStripMenuItem1.Size = new System.Drawing.Size(232, 22);
			this.captureMapJPdoNotUseToolStripMenuItem1.Text = "Capture Map JP (do not use)";
			this.captureMapJPdoNotUseToolStripMenuItem1.Click += new System.EventHandler(this.captureMapJPdoNotUseToolStripMenuItem_Click);
			// 
			// exportMapJPdoNotUseToolStripMenuItem1
			// 
			this.exportMapJPdoNotUseToolStripMenuItem1.Name = "exportMapJPdoNotUseToolStripMenuItem1";
			this.exportMapJPdoNotUseToolStripMenuItem1.Size = new System.Drawing.Size(232, 22);
			this.exportMapJPdoNotUseToolStripMenuItem1.Text = "Export Map JP (do not use)";
			this.exportMapJPdoNotUseToolStripMenuItem1.Click += new System.EventHandler(this.exportMapJPdoNotUseToolStripMenuItem_Click);
			// 
			// ExperimentalToolStripMenuItem1
			// 
			this.ExperimentalToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flipMapHorizontallyToolStripMenuItem,
            this.saveMapsOnlyToolStripMenuItem,
            this.saveVRAMAsPngToolStripMenuItem,
            this.moveRoomsToOtherROMToolStripMenuItem});
			this.ExperimentalToolStripMenuItem1.Enabled = false;
			this.ExperimentalToolStripMenuItem1.Name = "ExperimentalToolStripMenuItem1";
			this.ExperimentalToolStripMenuItem1.Size = new System.Drawing.Size(135, 20);
			this.ExperimentalToolStripMenuItem1.Text = "Experimental Features";
			this.ExperimentalToolStripMenuItem1.Visible = false;
			// 
			// flipMapHorizontallyToolStripMenuItem
			// 
			this.flipMapHorizontallyToolStripMenuItem.Name = "flipMapHorizontallyToolStripMenuItem";
			this.flipMapHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.flipMapHorizontallyToolStripMenuItem.Text = "Flip Map Horizontally";
			this.flipMapHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.flipMapHorizontallyToolStripMenuItem_Click);
			// 
			// saveMapsOnlyToolStripMenuItem
			// 
			this.saveMapsOnlyToolStripMenuItem.Name = "saveMapsOnlyToolStripMenuItem";
			this.saveMapsOnlyToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.saveMapsOnlyToolStripMenuItem.Text = "Save Maps Only";
			this.saveMapsOnlyToolStripMenuItem.Click += new System.EventHandler(this.saveMapsOnlyToolStripMenuItem_Click);
			// 
			// saveVRAMAsPngToolStripMenuItem
			// 
			this.saveVRAMAsPngToolStripMenuItem.Name = "saveVRAMAsPngToolStripMenuItem";
			this.saveVRAMAsPngToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.saveVRAMAsPngToolStripMenuItem.Text = "Save VRAM as PNG";
			this.saveVRAMAsPngToolStripMenuItem.Click += new System.EventHandler(this.saveVRAMAsPngToolStripMenuItem_Click);
			// 
			// moveRoomsToOtherROMToolStripMenuItem
			// 
			this.moveRoomsToOtherROMToolStripMenuItem.Name = "moveRoomsToOtherROMToolStripMenuItem";
			this.moveRoomsToOtherROMToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.moveRoomsToOtherROMToolStripMenuItem.Text = "Move Rooms to Another ROM…";
			this.moveRoomsToOtherROMToolStripMenuItem.Click += new System.EventHandler(this.moveRoomsToOtherROMToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem,
            this.patchNotesToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
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
			// discordToolStripMenuItem
			// 
			this.discordToolStripMenuItem.Name = "discordToolStripMenuItem";
			this.discordToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.discordToolStripMenuItem.Text = "Discord";
			this.discordToolStripMenuItem.Click += new System.EventHandler(this.discordToolStripMenuItem_Click);
			// 
			// UWContextMenu
			// 
			this.UWContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UWContextInsert,
            this.UWContextDelete,
            this.toolStripSeparator13,
            this.UWContextCopy,
            this.UWContextCut,
            this.UWContextPaste,
            this.toolStripSeparator14,
            this.UWContextAddToSelection,
            this.UWContextSelectAll,
            this.UWContextSelectNone,
            this.toolStripSeparator15,
            this.UWContextSendToFront,
            this.UWContextSendToBack,
            this.toolStripSeparator16,
            this.UWContextSendToLayer1,
            this.UWContextSendToLayer2,
            this.UWContextSendToLayer3});
			this.UWContextMenu.Name = "UWContextMenu";
			this.UWContextMenu.Size = new System.Drawing.Size(162, 314);
			// 
			// UWContextInsert
			// 
			this.UWContextInsert.Name = "UWContextInsert";
			this.UWContextInsert.Size = new System.Drawing.Size(161, 22);
			this.UWContextInsert.Text = "Insert";
			this.UWContextInsert.Click += new System.EventHandler(this.UWInsert);
			// 
			// UWContextDelete
			// 
			this.UWContextDelete.Name = "UWContextDelete";
			this.UWContextDelete.Size = new System.Drawing.Size(161, 22);
			this.UWContextDelete.Text = "Delete";
			this.UWContextDelete.Click += new System.EventHandler(this.UWDelete);
			// 
			// toolStripSeparator13
			// 
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(158, 6);
			// 
			// UWContextCopy
			// 
			this.UWContextCopy.Name = "UWContextCopy";
			this.UWContextCopy.Size = new System.Drawing.Size(161, 22);
			this.UWContextCopy.Text = "Copy";
			this.UWContextCopy.Click += new System.EventHandler(this.UWCopy);
			// 
			// UWContextCut
			// 
			this.UWContextCut.Name = "UWContextCut";
			this.UWContextCut.Size = new System.Drawing.Size(161, 22);
			this.UWContextCut.Text = "Cut";
			this.UWContextCut.Click += new System.EventHandler(this.UWCut);
			// 
			// UWContextPaste
			// 
			this.UWContextPaste.Name = "UWContextPaste";
			this.UWContextPaste.Size = new System.Drawing.Size(161, 22);
			this.UWContextPaste.Text = "Paste";
			this.UWContextPaste.Click += new System.EventHandler(this.UWPaste);
			// 
			// toolStripSeparator14
			// 
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(158, 6);
			// 
			// UWContextAddToSelection
			// 
			this.UWContextAddToSelection.Name = "UWContextAddToSelection";
			this.UWContextAddToSelection.Size = new System.Drawing.Size(161, 22);
			this.UWContextAddToSelection.Text = "Add to Selection";
			this.UWContextAddToSelection.Click += new System.EventHandler(this.UWAddToSelection);
			// 
			// UWContextSelectAll
			// 
			this.UWContextSelectAll.Name = "UWContextSelectAll";
			this.UWContextSelectAll.Size = new System.Drawing.Size(161, 22);
			this.UWContextSelectAll.Text = "Select All";
			this.UWContextSelectAll.Click += new System.EventHandler(this.UWSelectAll);
			// 
			// UWContextSelectNone
			// 
			this.UWContextSelectNone.Name = "UWContextSelectNone";
			this.UWContextSelectNone.Size = new System.Drawing.Size(161, 22);
			this.UWContextSelectNone.Text = "Select None";
			this.UWContextSelectNone.Click += new System.EventHandler(this.UWSelectNone);
			// 
			// toolStripSeparator15
			// 
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(158, 6);
			// 
			// UWContextSendToFront
			// 
			this.UWContextSendToFront.Name = "UWContextSendToFront";
			this.UWContextSendToFront.Size = new System.Drawing.Size(161, 22);
			this.UWContextSendToFront.Text = "Send to Front";
			this.UWContextSendToFront.Click += new System.EventHandler(this.SendSelectedToFront);
			// 
			// UWContextSendToBack
			// 
			this.UWContextSendToBack.Name = "UWContextSendToBack";
			this.UWContextSendToBack.Size = new System.Drawing.Size(161, 22);
			this.UWContextSendToBack.Text = "Send to Back";
			this.UWContextSendToBack.Click += new System.EventHandler(this.SendSelectedToBack);
			// 
			// toolStripSeparator16
			// 
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(158, 6);
			// 
			// UWContextSendToLayer1
			// 
			this.UWContextSendToLayer1.Name = "UWContextSendToLayer1";
			this.UWContextSendToLayer1.Size = new System.Drawing.Size(161, 22);
			this.UWContextSendToLayer1.Text = "Send to Layer 1";
			// 
			// UWContextSendToLayer2
			// 
			this.UWContextSendToLayer2.Name = "UWContextSendToLayer2";
			this.UWContextSendToLayer2.Size = new System.Drawing.Size(161, 22);
			this.UWContextSendToLayer2.Text = "Send to Layer 2";
			// 
			// UWContextSendToLayer3
			// 
			this.UWContextSendToLayer3.Name = "UWContextSendToLayer3";
			this.UWContextSendToLayer3.Size = new System.Drawing.Size(161, 22);
			this.UWContextSendToLayer3.Text = "Send to Layer 3";
			// 
			// roomProperty_bg2
			// 
			this.roomProperty_bg2.BackColor = System.Drawing.SystemColors.Window;
			this.roomProperty_bg2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.roomProperty_bg2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.roomProperty_bg2.FormattingEnabled = true;
			this.roomProperty_bg2.Location = new System.Drawing.Point(6, 22);
			this.roomProperty_bg2.Name = "roomProperty_bg2";
			this.roomProperty_bg2.Size = new System.Drawing.Size(124, 23);
			this.roomProperty_bg2.TabIndex = 2;
			this.roomProperty_bg2.SelectedIndexChanged += new System.EventHandler(this.RoomPropertyChanged);
			// 
			// DungeonMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1157, 846);
			this.Controls.Add(this.editorsTabControl);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "DungeonMain";
			this.Text = "ZScream";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.zscreamForm_FormClosing_1);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.LocationChanged += new System.EventHandler(this.DungeonMain_LocationChanged);
			this.SizeChanged += new System.EventHandler(this.DungeonMain_SizeChanged);
			this.nothingselectedcontextMenu.ResumeLayout(false);
			this.editorsTabControl.ResumeLayout(false);
			this.dungeonPage.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.entrancetabPage.ResumeLayout(false);
			this.entrancetabPage.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.objectstabPage.ResumeLayout(false);
			this.objectstabPage.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.edit8x8.ResumeLayout(false);
			this.edit8x8Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.editBox8x8)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.edit8x8palettebox)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mapPicturebox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.thumbnailBox)).EndInit();
			this.headerGroupbox.ResumeLayout(false);
			this.headerGroupbox.PerformLayout();
			this.roomHeaderPanel.ResumeLayout(false);
			this.roomHeaderPanel.PerformLayout();
			this.spritepropertyPanel.ResumeLayout(false);
			this.spritepropertyPanel.PerformLayout();
			this.doorselectPanel.ResumeLayout(false);
			this.doorselectPanel.PerformLayout();
			this.collisionMapPanel.ResumeLayout(false);
			this.collisionMapPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.spritesubtypeUpDown)).EndInit();
			this.potitemobjectPanel.ResumeLayout(false);
			this.potitemobjectPanel.PerformLayout();
			this.overworldPage.ResumeLayout(false);
			this.OverworldSplitContainer.Panel1.ResumeLayout(false);
			this.OverworldSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.OverworldSplitContainer)).EndInit();
			this.OverworldSplitContainer.ResumeLayout(false);
			this.OverworldAuxSideTabs.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tilePictureBox)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scratchPicturebox)).EndInit();
			this.Tiles8.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Tile8PicBox)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.currentTile8Box)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.palette8Box)).EndInit();
			this.OWTabExitProps.ResumeLayout(false);
			this.OWExitPanel.ResumeLayout(false);
			this.OWExitPanel.PerformLayout();
			this.OWTabEntranceProps.ResumeLayout(false);
			this.OWEntrancePanel.ResumeLayout(false);
			this.OWEntrancePanel.PerformLayout();
			this.OWTabTransportProps.ResumeLayout(false);
			this.OWTransportPanel.ResumeLayout(false);
			this.OWTransportPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.owPropertyPanel.ResumeLayout(false);
			this.objectGroupbox.ResumeLayout(false);
			this.mapGroupbox.ResumeLayout(false);
			this.mapGroupbox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.previewTextPicturebox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.areaBGColorPictureBox)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.textPage.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BigCharPreviewBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FontWidthUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FontPreviewBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MessagePreviewBox)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.UWContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dungeonViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textChestItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textPotItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBG2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBG1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.ImageList spriteImageList;
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
        private System.Windows.Forms.ToolStripMenuItem unselectedBGTransparentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem3;
        public System.Windows.Forms.ContextMenuStrip nothingselectedcontextMenu;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem darkThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hideSpritesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hideItemsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hideChestItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem selectAllRoomsForExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectedAllRoomsForExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x64ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x256ToolStripMenuItem;
        public ObjectViewer objectViewer1;
        public SpritesView spritesView1;
        private System.Windows.Forms.ToolStripMenuItem patchNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDoorIDsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showChestsIDsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableEntranceGFXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeMaskObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printRoomObjectsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearSelectedRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllRoomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsASMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vramViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cGramViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBG2MaskOutlineToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem entrancePositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadNamesFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gfxGroupsetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem palettesEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem naviguateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem openRightRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLeftRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openUpRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDownRoomToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.TabPage dungeonPage;
        private System.Windows.Forms.TabPage overworldPage;
        private System.Windows.Forms.TabPage GfxEditorPage;
        private System.Windows.Forms.TabPage textPage;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsToolStripMenuItem;
        public System.Windows.Forms.TabControl editorsTabControl;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllRoomsToolStripMenuItem;
        private System.Windows.Forms.TabPage ScreenEditor;
        private System.Windows.Forms.ToolStripMenuItem exportSpritesAsBinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExperimentalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem flipMapHorizontallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jPDebugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapDataFromJPdoNotUseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem captureMapJPdoNotUseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportMapJPdoNotUseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveMapsOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importRoomToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem invisibleObjectsTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRoomsInHexToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem showMapIndexInHexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveVRAMAsPngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveRoomsToOtherROMToolStripMenuItem;
        private System.Windows.Forms.TabPage spritesPage;
        private System.Windows.Forms.ToolStripMenuItem selectedObjectInHexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overworldViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSpritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showEntrancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showExitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTransportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showEntranceExitPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem increaseObjectSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseObjectSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGridToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem x8ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem x16ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem x32ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem lockoverworldToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem memoryManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overworldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSpritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zeldaSavedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agahDeadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveZeldaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearEntrancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearExitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllHolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllOverlaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSpritesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveZeldaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zeldaSavedToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem agahDeadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearItemsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearEntrancesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearHolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearExitsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearOverlaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem exportAllTilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importAllTilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem autoDoorsToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem overworldOverlayVisibleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem discordToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ContextMenuStrip UWContextMenu;
		private System.Windows.Forms.ToolStripMenuItem UWContextInsert;
		private System.Windows.Forms.ToolStripMenuItem UWContextDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
		private System.Windows.Forms.ToolStripMenuItem UWContextCopy;
		private System.Windows.Forms.ToolStripMenuItem UWContextCut;
		private System.Windows.Forms.ToolStripMenuItem UWContextPaste;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
		private System.Windows.Forms.ToolStripMenuItem UWContextAddToSelection;
		private System.Windows.Forms.ToolStripMenuItem UWContextSelectAll;
		private System.Windows.Forms.ToolStripMenuItem UWContextSelectNone;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
		private System.Windows.Forms.ToolStripMenuItem UWContextSendToFront;
		private System.Windows.Forms.ToolStripMenuItem UWContextSendToBack;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
		private System.Windows.Forms.ToolStripMenuItem UWContextSendToLayer1;
		private System.Windows.Forms.ToolStripMenuItem UWContextSendToLayer2;
		private System.Windows.Forms.ToolStripMenuItem UWContextSendToLayer3;
		public System.Windows.Forms.ComboBox roomProperty_bg2;
		private SplitContainer splitContainer1;
		private CustomPanel customPanel3;
		private TabControl RoomTabControl;
		private Panel panel3;
		public PictureBox mapPicturebox;
		private CheckBox maphoverCheckbox;
		private Label mapInfosLabel;
		private PictureBox thumbnailBox;
		public GroupBox headerGroupbox;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel SelectedObjectNameLabel;
		private ToolStripStatusLabel SelectedObjectXLabel;
		private ToolStripStatusLabel SelectedObjectYLabel;
		private ToolStripStatusLabel SelectedObjectLayerLabel;
		private ToolStripStatusLabel SelectedObjectSizeLabel;
		private ToolStripStatusLabel SelectedObjectDataLabel;
		private Panel roomHeaderPanel;
		private Label label43;
		private Gui.ExtraForms.Hexbox RoomProperties_PreferredEntrance;
		private CheckBox RoomProperty_IsDark;
		private Gui.ExtraForms.Hexbox RoomProperty_DestinationStair4;
		private Gui.ExtraForms.Hexbox RoomProperty_DestinationStair3;
		private Gui.ExtraForms.Hexbox RoomProperty_DestinationStair2;
		private Label label20;
		private Label label5;
		private Gui.ExtraForms.Hexbox RoomProperty_DestinationStair1;
		private Gui.ExtraForms.Hexbox RoomProperty_DestinationPit;
		private Gui.ExtraForms.Hexbox RoomProperty_MessageID;
		private Gui.ExtraForms.Hexbox RoomProperty_SpriteSet;
		private Gui.ExtraForms.Hexbox RoomProperty_Palette;
		private Gui.ExtraForms.Hexbox RoomProperty_Floor2;
		private Gui.ExtraForms.Hexbox RoomProperty_Floor1;
		private Gui.ExtraForms.Hexbox RoomProperty_Blockset;
		private Gui.ExtraForms.Hexbox RoomProperty_Layout;
		private Label label16;
		private Label label15;
		private Label label7;
		private Label label1;
		public CheckBox bg2checkbox5;
		private Label label33;
		private Label label14;
		private Label label28;
		public CheckBox bg2checkbox4;
		public CheckBox bg2checkbox3;
		public CheckBox bg2checkbox2;
		public CheckBox bg2checkbox1;
		private Label label11;
		public ComboBox roomProperty_effect;
		public CheckBox roomProperty_sortsprite;
		private Label label2;
		public ComboBox roomPropertyLayerMerge;
		private Label label3;
		public ComboBox roomProperty_collision;
		private Label label9;
		public CheckBox roomProperty_pit;
		private Label label10;
		private Label label6;
		private Label label4;
		private Label label8;
		private Label label13;
		public ComboBox roomProperty_tag1;
		private Label label12;
		public ComboBox roomProperty_tag2;
		public Panel spritepropertyPanel;
		public CheckBox spriteoverlordCheckbox;
		private Label label26;
		public NumericUpDown spritesubtypeUpDown;
		public Panel doorselectPanel;
		public Panel collisionMapPanel;
		public ComboBox tileTypeCombobox;
		public Label collisionMapLabel;
		public CheckBox litCheckbox;
		public ComboBox DoorTypeComboBox;
		public Label label25;
		public ComboBox comboBox1;
		public Label label23;
		public Panel potitemobjectPanel;
		public ComboBox selecteditemobjectCombobox;
		public Label label31;
		private ToolStrip toolStrip1;
		private ToolStripButton saveButton;
		private ToolStripButton debugtestButton;
		private ToolStripButton runtestButton;
		private ToolStripSeparator toolStripSeparator1;
		public ToolStripButton undoButton;
		public ToolStripButton redoButton;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripButton debugToolStripButton;
		private Panel owPropertyPanel;
		public GroupBox objectGroupbox;
		public ComboBox OverworldObjectCombobox;
		public GroupBox mapGroupbox;
		public Gui.ExtraForms.Hexbox OWProperty_MessageID;
		private Gui.ExtraForms.Hexbox OWProperty_SPRPalette;
		private Gui.ExtraForms.Hexbox OWProperty_SPRGFX;
		private Gui.ExtraForms.Hexbox OWProperty_BGPalette;
		private Gui.ExtraForms.Hexbox OWProperty_BGGFX;
		public PictureBox areaBGColorPictureBox;
		private Label label49;
		public CheckBox largemapCheckbox;
		private Button OverworldTextButton;
		private Button musicButton;
		private Label label50;
		private Label label51;
		private Label label52;
		private Label label53;
		private Label label54;
		private GroupBox groupBox3;
		public Label selectedTileLabel;
		private Label label55;
		private ComboBox stateCombobox;
		public SplitContainer OverworldSplitContainer;
		private TabControl OverworldAuxSideTabs;
		private TabPage tabPage1;
		public PictureBox tilePictureBox;
		private TabPage tabPage2;
		public PictureBox scratchPicturebox;
		private TabPage Tiles8;
		private Panel panel2;
		public PictureBox Tile8PicBox;
		private Panel panel4;
		private CheckBox priorityCheckbox;
		private PictureBox currentTile8Box;
		private CheckBox mirrorYCheckbox;
		private PictureBox palette8Box;
		private CheckBox mirrorXCheckbox;
		private TabPage OWTabExitProps;
		private Panel OWExitPanel;
		private Label OWExitDisabled;
		private Gui.ExtraForms.Hexbox OWExitPropY;
		private Gui.ExtraForms.Hexbox OWExitPropX;
		private Gui.ExtraForms.Hexbox OWExitPropID;
		private Label label56;
		private Label label57;
		private Label label58;
		private TabPage OWTabEntranceProps;
		private Panel OWEntrancePanel;
		private Label OWEntranceDisabled;
		private Gui.ExtraForms.Hexbox OWEntrancePropY;
		private Gui.ExtraForms.Hexbox OWEntrancePropX;
		private Gui.ExtraForms.Hexbox OWEntrancePropID;
		private Label label59;
		private Label label60;
		private Label label61;
		private TabPage OWTabTransportProps;
		private Panel OWTransportPanel;
		private Label OWTransportDisabled;
		private Gui.ExtraForms.Hexbox OWTransportPropY;
		private Gui.ExtraForms.Hexbox OWTransportPropX;
		private Gui.ExtraForms.Hexbox OWTransportPropID;
		private Label label62;
		private Label label63;
		private Label label64;
		public PictureBox pictureBox2;
		public PictureBox previewTextPicturebox;
		public TabControl tabControl1;
		private TabPage entrancetabPage;
		public TreeView entrancetreeView;
		private Button mouseEntranceButton;
		public CheckBox gridEntranceCheckbox;
		private ComboBox EntranceMusicBox;
		private ComboBox EntranceProperties_FloorSel;
		private Gui.ExtraForms.Hexbox EntranceProperties_Blockset;
		private Gui.ExtraForms.Hexbox EntranceProperties_DungeonID;
		private Gui.ExtraForms.Hexbox EntranceProperties_Entrance;
		private Gui.ExtraForms.Hexbox EntranceProperties_CameraTriggerY;
		private Gui.ExtraForms.Hexbox EntranceProperties_CameraTriggerX;
		private Gui.ExtraForms.Hexbox EntranceProperties_CameraY;
		private Gui.ExtraForms.Hexbox EntranceProperties_CameraX;
		private Gui.ExtraForms.Hexbox EntranceProperties_PlayerY;
		private Gui.ExtraForms.Hexbox EntranceProperties_PlayerX;
		private Gui.ExtraForms.Hexbox EntranceProperties_RoomID;
		public TextBox dooryTextbox;
		public TextBox doorxTextbox;
		private Label label46;
		private Label label45;
		private Label label41;
		private Label label38;
		private GroupBox groupBox2;
		private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryFE;
		private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryFW;
		private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryQE;
		private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryQW;
		private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryFS;
		private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryFN;
		private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryQS;
		private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryQN;
		private Label label37;
		private Label label36;
		private Label label35;
		private Label label34;
		private Label label32;
		private Label label29;
		private Label label30;
		private CheckBox doorCheckbox;
		private Label label27;
		public RadioButton entranceProperty_quadbr;
		public RadioButton entranceProperty_quadtr;
		public RadioButton entranceProperty_quadbl;
		public RadioButton entranceProperty_quadtl;
		private Label label42;
		public CheckBox entranceProperty_vscroll;
		public CheckBox entranceProperty_hscroll;
		private Label label44;
		private Label label18;
		private Label label19;
		private Label label21;
		public CheckBox entranceProperty_bg;
		private Label label39;
		private Label label22;
		private Label label40;
		private Label label24;
		private TabPage objectstabPage;
		private CheckBox favoriteCheckbox;
		private CheckBox showNameObjectCheckbox;
		private CustomPanel panel1;
		private TextBox searchTextbox;
		private TabPage tabPage4;
		private CustomPanel customPanel1;
		private TextBox searchspriteTextbox;
		private TabPage edit8x8;
		private Panel edit8x8Panel;
		private PictureBox editBox8x8;
		private GroupBox groupBox1;
		private CheckBox checkBox1;
		private PictureBox edit8x8palettebox;
		private CheckBox edit8x8myCheckbox;
		private CheckBox edit8x8mxCheckbox;
		private Panel panel5;
		public ListBox textListbox;
		private Label label65;
		private TextBox TextSearchTextbox;
		private Label label66;
		private Panel panel6;
		private Gui.ExtraForms.Hexbox ParamsBox;
		private CheckBox fontGridBox;
		private Button BytesDDD;
		private Label label67;
		private Label label68;
		private Label label69;
		private ListBox TextCommandList;
		private Label label70;
		private TextBox MessageTextEntry;
		private Label label71;
		private Button button5;
		private Button button6;
		private ListBox SpecialsList;
		private GroupBox groupBox4;
		private PictureBox BigCharPreviewBox;
		private Label SelectedTileASCII;
		private Label SelectedTileID;
		private NumericUpDown FontWidthUpDown;
		private Label label72;
		private Label label73;
		private Label label74;
		private Button ListDictionaryButton;
		private Button ImportFontGraphicsButton;
		private Button ExportFontGraphicsButton;
		private Label label75;
		private PictureBox FontPreviewBox;
		public PictureBox MessagePreviewBox;
		public DungeonToolStripButton allbgsButton;
		public DungeonToolStripButton bg1modeButton;
		public DungeonToolStripButton bg2modeButton;
		public DungeonToolStripButton bg3modeButton;
		public DungeonToolStripButton underworldSpriteModeButton;
		public DungeonToolStripButton blockmodeButton;
		public DungeonToolStripButton torchmodeButton;
		public DungeonToolStripButton potmodeButton;
		public DungeonToolStripButton doormodeButton;
		public DungeonToolStripButton collisionModeButton;
		private DungeonToolStripButton saveLayoutButton;
		private DungeonToolStripButton loadlayoutButton;
		private DungeonToolStripButton searchButton;
		private DungeonToolStripButton exportuwmapStripButton1;
		private OverworldToolStripButton entranceModeButton;
		private OverworldToolStripButton exitModeButton;
		private OverworldToolStripButton itemModeButton;
		private OverworldToolStripButton owSpriteModeButton;
		private OverworldToolStripButton transportModeButton;
		private OverworldToolStripButton overlayButton;
		private OverworldToolStripButton gravestoneButton;
		private OverworldToolStripButton searchtilesButton;
		private OverworldToolStripButton refreshToolStrip;
		private OverworldToolStripButton fillModeButton;
		private OverworldToolStripButton penModeButton;
		private OverworldToolStripButton spButton;
		private OverworldToolStripButton dwButton;
		private OverworldToolStripButton lwButton;
		private OverworldToolStripButton clearmapbutton;
	}
}

