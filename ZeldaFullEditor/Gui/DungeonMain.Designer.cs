﻿using System.Collections.Generic;
using System.Linq;

namespace ZeldaFullEditor
{
    partial class DungeonMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DungeonMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Entrances");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Starting Entrances");
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
            this.collisionModeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveLayoutButton = new System.Windows.Forms.ToolStripButton();
            this.loadlayoutButton = new System.Windows.Forms.ToolStripButton();
            this.searchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.debugToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.autodoorButton = new System.Windows.Forms.ToolStripButton();
            this.spriteImageList = new System.Windows.Forms.ImageList(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.nothingselectedcontextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.singleselectedcontextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.insertToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.roomProperty_sortsprite = new System.Windows.Forms.CheckBox();
            this.toolboxPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.entrancetabPage = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.entrancetreeView = new System.Windows.Forms.TreeView();
            this.gridEntranceCheckbox = new System.Windows.Forms.CheckBox();
            this.mouseEntranceButton = new System.Windows.Forms.Button();
            this.entranceProperty_bg = new System.Windows.Forms.CheckBox();
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
            this.objectstabPage = new System.Windows.Forms.TabPage();
            this.favoriteCheckbox = new System.Windows.Forms.CheckBox();
            this.showNameObjectCheckbox = new System.Windows.Forms.CheckBox();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.searchspriteTextbox = new System.Windows.Forms.TextBox();
            this.edit8x8 = new System.Windows.Forms.TabPage();
            this.edit8x8Panel = new System.Windows.Forms.Panel();
            this.editBox8x8 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.edit8x8palettebox = new System.Windows.Forms.PictureBox();
            this.edit8x8myCheckbox = new System.Windows.Forms.CheckBox();
            this.edit8x8mxCheckbox = new System.Windows.Forms.CheckBox();
            this.roomProperty_msgid = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.roomProperty_pit = new System.Windows.Forms.CheckBox();
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.headerGroupbox = new System.Windows.Forms.GroupBox();
            this.collisionMapPanel = new System.Windows.Forms.Panel();
            this.tileTypeCombobox = new System.Windows.Forms.ComboBox();
            this.collisionMapLabel = new System.Windows.Forms.Label();
            this.selectedGroupbox = new System.Windows.Forms.GroupBox();
            this.object_size_label = new System.Windows.Forms.Label();
            this.object_x_label = new System.Windows.Forms.Label();
            this.object_y_label = new System.Windows.Forms.Label();
            this.object_layer_label = new System.Windows.Forms.Label();
            this.roomHeaderPanel = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bg2checkbox5 = new System.Windows.Forms.CheckBox();
            this.roomProperty_stair4 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.bg2checkbox4 = new System.Windows.Forms.CheckBox();
            this.bg2checkbox3 = new System.Windows.Forms.CheckBox();
            this.bg2checkbox2 = new System.Windows.Forms.CheckBox();
            this.bg2checkbox1 = new System.Windows.Forms.CheckBox();
            this.roomProperty_stair3 = new System.Windows.Forms.TextBox();
            this.roomProperty_stair1 = new System.Windows.Forms.TextBox();
            this.roomProperty_stair2 = new System.Windows.Forms.TextBox();
            this.roomProperty_hole = new System.Windows.Forms.TextBox();
            this.doorselectPanel = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.litCheckbox = new System.Windows.Forms.CheckBox();
            this.spritepropertyPanel = new System.Windows.Forms.Panel();
            this.spriteoverlordCheckbox = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.spritesubtypeUpDown = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.potitemobjectPanel = new System.Windows.Forms.Panel();
            this.selecteditemobjectCombobox = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.editorsTabControl = new System.Windows.Forms.TabControl();
            this.dungeonPage = new System.Windows.Forms.TabPage();
            this.overworldPage = new System.Windows.Forms.TabPage();
            this.GfxEditorPage = new System.Windows.Forms.TabPage();
            this.textPage = new System.Windows.Forms.TabPage();
            this.ScreenEditor = new System.Windows.Forms.TabPage();
            this.spritesPage = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.increaseObjectSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseObjectSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.lockoverworldToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedChestEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dungeonsPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNamesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importAllMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.openDungeonTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOverwolrdTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGfxTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.darkThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightSideToolboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideChestItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDoorIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showChestsIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableEntranceGFXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBG2MaskOutlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entranceCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entrancePositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invisibleObjectsTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overworldOverlayVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMapIndexInHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overworldViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showEntrancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showExitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTransportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showEntranceExitPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x8ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x16ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x32ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vramViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cGramViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gfxGroupsetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.palettesEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapDataFromJPdoNotUseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.captureMapJPdoNotUseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMapJPdoNotUseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.flipMapHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveVRAMAsPngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveRoomsToOtherROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thumbnailBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
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
            this.entranceProperty_quadbr = new System.Windows.Forms.RadioButton();
            this.entranceProperty_quadtr = new System.Windows.Forms.RadioButton();
            this.entranceProperty_quadbl = new System.Windows.Forms.RadioButton();
            this.entranceProperty_quadtl = new System.Windows.Forms.RadioButton();
            this.dooryTextbox = new System.Windows.Forms.TextBox();
            this.doorxTextbox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.doorCheckbox = new System.Windows.Forms.CheckBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.entranceProperty_FR = new System.Windows.Forms.TextBox();
            this.entranceProperty_HR = new System.Windows.Forms.TextBox();
            this.entranceProperty_FL = new System.Windows.Forms.TextBox();
            this.entranceProperty_HL = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.entranceProperty_FD = new System.Windows.Forms.TextBox();
            this.entranceProperty_HD = new System.Windows.Forms.TextBox();
            this.entranceProperty_FU = new System.Windows.Forms.TextBox();
            this.entranceProperty_HU = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mapPicturebox = new System.Windows.Forms.PictureBox();
            this.maphoverCheckbox = new System.Windows.Forms.CheckBox();
            this.mapInfosLabel = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.customPanel3 = new ZeldaFullEditor.CustomPanel();
            this.panel1 = new ZeldaFullEditor.CustomPanel();
            this.objectViewer1 = new ZeldaFullEditor.ObjectViewer();
            this.customPanel1 = new ZeldaFullEditor.CustomPanel();
            this.spritesView1 = new ZeldaFullEditor.SpritesView();
            this.toolStrip1.SuspendLayout();
            this.nothingselectedcontextMenu.SuspendLayout();
            this.singleselectedcontextMenu.SuspendLayout();
            this.groupselectedcontextMenu.SuspendLayout();
            this.toolboxPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.entrancetabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.objectstabPage.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.edit8x8.SuspendLayout();
            this.edit8x8Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editBox8x8)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edit8x8palettebox)).BeginInit();
            this.headerGroupbox.SuspendLayout();
            this.collisionMapPanel.SuspendLayout();
            this.selectedGroupbox.SuspendLayout();
            this.roomHeaderPanel.SuspendLayout();
            this.doorselectPanel.SuspendLayout();
            this.spritepropertyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritesubtypeUpDown)).BeginInit();
            this.potitemobjectPanel.SuspendLayout();
            this.editorsTabControl.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
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
            this.collisionModeButton,
            this.toolStripSeparator3,
            this.saveLayoutButton,
            this.loadlayoutButton,
            this.searchButton,
            this.toolStripButton1,
            this.debugToolStripButton,
            this.autodoorButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1177, 25);
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
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
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
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
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
            // collisionModeButton
            // 
            this.collisionModeButton.CheckOnClick = true;
            this.collisionModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.collisionModeButton.Enabled = false;
            this.collisionModeButton.Image = ((System.Drawing.Image)(resources.GetObject("collisionModeButton.Image")));
            this.collisionModeButton.ImageTransparentColor = System.Drawing.Color.White;
            this.collisionModeButton.Name = "collisionModeButton";
            this.collisionModeButton.Size = new System.Drawing.Size(23, 22);
            this.collisionModeButton.Text = "Collision Mode";
            this.collisionModeButton.Click += new System.EventHandler(this.update_modes_buttons);
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
            // searchButton
            // 
            this.searchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchButton.Enabled = false;
            this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
            this.searchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(23, 22);
            this.searchButton.Text = "toolStripButton2";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
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
            // debugToolStripButton
            // 
            this.debugToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.debugToolStripButton.Enabled = false;
            this.debugToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("debugToolStripButton.Image")));
            this.debugToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debugToolStripButton.Name = "debugToolStripButton";
            this.debugToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.debugToolStripButton.Text = "debug";
            this.debugToolStripButton.Click += new System.EventHandler(this.debugToolStripButton_Click);
            // 
            // autodoorButton
            // 
            this.autodoorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.autodoorButton.Image = ((System.Drawing.Image)(resources.GetObject("autodoorButton.Image")));
            this.autodoorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autodoorButton.Name = "autodoorButton";
            this.autodoorButton.Size = new System.Drawing.Size(74, 22);
            this.autodoorButton.Text = "Auto. Doors";
            this.autodoorButton.Click += new System.EventHandler(this.autodoorButton_Click_1);
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
            this.pasteToolStripMenuItem3});
            this.nothingselectedcontextMenu.Name = "nothingselectedcontextMenu";
            this.nothingselectedcontextMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // insertToolStripMenuItem1
            // 
            this.insertToolStripMenuItem1.Name = "insertToolStripMenuItem1";
            this.insertToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.insertToolStripMenuItem1.Text = "Insert";
            this.insertToolStripMenuItem1.Click += new System.EventHandler(this.insertToolStripMenuItem1_Click);
            // 
            // pasteToolStripMenuItem3
            // 
            this.pasteToolStripMenuItem3.Name = "pasteToolStripMenuItem3";
            this.pasteToolStripMenuItem3.Size = new System.Drawing.Size(103, 22);
            this.pasteToolStripMenuItem3.Text = "Paste";
            this.pasteToolStripMenuItem3.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // singleselectedcontextMenu
            // 
            this.singleselectedcontextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
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
            this.singleselectedcontextMenu.Size = new System.Drawing.Size(138, 246);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.insertToolStripMenuItem.Text = "Insert";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click_1);
            // 
            // cutToolStripMenuItem1
            // 
            this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            this.cutToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.cutToolStripMenuItem1.Text = "Cut";
            this.cutToolStripMenuItem1.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // increaseZToolStripMenuItem
            // 
            this.increaseZToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bringToFrontToolStripMenuItem2,
            this.increaseZBy1ToolStripMenuItem});
            this.increaseZToolStripMenuItem.Name = "increaseZToolStripMenuItem";
            this.increaseZToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
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
            this.decreaseZToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
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
            // 
            // sendToBg1ToolStripMenuItem
            // 
            this.sendToBg1ToolStripMenuItem.Name = "sendToBg1ToolStripMenuItem";
            this.sendToBg1ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.sendToBg1ToolStripMenuItem.Text = "Send to Bg1";
            this.sendToBg1ToolStripMenuItem.Click += new System.EventHandler(this.sendToBg1ToolStripMenuItem_Click);
            // 
            // sendToBg1ToolStripMenuItem1
            // 
            this.sendToBg1ToolStripMenuItem1.Name = "sendToBg1ToolStripMenuItem1";
            this.sendToBg1ToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.sendToBg1ToolStripMenuItem1.Text = "Send to Bg2";
            this.sendToBg1ToolStripMenuItem1.Click += new System.EventHandler(this.sendToBg1ToolStripMenuItem1_Click);
            // 
            // sendToBg1ToolStripMenuItem2
            // 
            this.sendToBg1ToolStripMenuItem2.Name = "sendToBg1ToolStripMenuItem2";
            this.sendToBg1ToolStripMenuItem2.Size = new System.Drawing.Size(137, 22);
            this.sendToBg1ToolStripMenuItem2.Text = "Send to Bg3";
            this.sendToBg1ToolStripMenuItem2.Click += new System.EventHandler(this.sendToBg1ToolStripMenuItem2_Click);
            // 
            // editGfxToolStripMenuItem
            // 
            this.editGfxToolStripMenuItem.Enabled = false;
            this.editGfxToolStripMenuItem.Name = "editGfxToolStripMenuItem";
            this.editGfxToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.editGfxToolStripMenuItem.Text = "Edit gfx";
            // 
            // groupselectedcontextMenu
            // 
            this.groupselectedcontextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem2,
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
            // insertToolStripMenuItem2
            // 
            this.insertToolStripMenuItem2.Name = "insertToolStripMenuItem2";
            this.insertToolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            this.insertToolStripMenuItem2.Text = "Insert";
            this.insertToolStripMenuItem2.Click += new System.EventHandler(this.insertToolStripMenuItem2_Click);
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
            // roomProperty_sortsprite
            // 
            this.roomProperty_sortsprite.AutoSize = true;
            this.roomProperty_sortsprite.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roomProperty_sortsprite.Location = new System.Drawing.Point(298, 64);
            this.roomProperty_sortsprite.Name = "roomProperty_sortsprite";
            this.roomProperty_sortsprite.Size = new System.Drawing.Size(79, 17);
            this.roomProperty_sortsprite.TabIndex = 52;
            this.roomProperty_sortsprite.Text = "Layer OAM";
            this.toolTip1.SetToolTip(this.roomProperty_sortsprite, "Must be used in rooms with bridges where sprites can be on top or under bridges\r\n" +
        "also called Sort Sprites in HM");
            this.roomProperty_sortsprite.UseVisualStyleBackColor = true;
            this.roomProperty_sortsprite.CheckedChanged += new System.EventHandler(this.roomProperty_pit_CheckedChanged);
            // 
            // toolboxPanel
            // 
            this.toolboxPanel.Controls.Add(this.tabControl1);
            this.toolboxPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolboxPanel.Location = new System.Drawing.Point(0, 49);
            this.toolboxPanel.Name = "toolboxPanel";
            this.toolboxPanel.Size = new System.Drawing.Size(300, 690);
            this.toolboxPanel.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.entrancetabPage);
            this.tabControl1.Controls.Add(this.objectstabPage);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.edit8x8);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(300, 690);
            this.tabControl1.TabIndex = 12;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // entrancetabPage
            // 
            this.entrancetabPage.Controls.Add(this.splitContainer3);
            this.entrancetabPage.Location = new System.Drawing.Point(4, 22);
            this.entrancetabPage.Name = "entrancetabPage";
            this.entrancetabPage.Size = new System.Drawing.Size(292, 664);
            this.entrancetabPage.TabIndex = 5;
            this.entrancetabPage.Text = "Rooms";
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
            this.splitContainer3.Panel1.Controls.Add(this.panel2);
            this.splitContainer3.Panel1MinSize = 359;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Panel2.Controls.Add(this.entrancetreeView);
            this.splitContainer3.Size = new System.Drawing.Size(292, 664);
            this.splitContainer3.SplitterDistance = 359;
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
            this.entrancetreeView.Size = new System.Drawing.Size(292, 301);
            this.entrancetreeView.TabIndex = 0;
            this.entrancetreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entrancetreeView_AfterSelect);
            this.entrancetreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.entrancetreeView_NodeMouseDoubleClick);
            // 
            // gridEntranceCheckbox
            // 
            this.gridEntranceCheckbox.AutoSize = true;
            this.gridEntranceCheckbox.Checked = true;
            this.gridEntranceCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridEntranceCheckbox.Location = new System.Drawing.Point(226, 313);
            this.gridEntranceCheckbox.Name = "gridEntranceCheckbox";
            this.gridEntranceCheckbox.Size = new System.Drawing.Size(63, 17);
            this.gridEntranceCheckbox.TabIndex = 59;
            this.gridEntranceCheckbox.Text = "8x8 grid";
            this.gridEntranceCheckbox.UseVisualStyleBackColor = true;
            // 
            // mouseEntranceButton
            // 
            this.mouseEntranceButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mouseEntranceButton.Location = new System.Drawing.Point(0, 336);
            this.mouseEntranceButton.Name = "mouseEntranceButton";
            this.mouseEntranceButton.Size = new System.Drawing.Size(292, 23);
            this.mouseEntranceButton.TabIndex = 58;
            this.mouseEntranceButton.Text = "Set Entrance position with Mouse";
            this.mouseEntranceButton.UseVisualStyleBackColor = true;
            this.mouseEntranceButton.Click += new System.EventHandler(this.mouseEntranceButton_Click);
            // 
            // entranceProperty_bg
            // 
            this.entranceProperty_bg.AutoSize = true;
            this.entranceProperty_bg.Location = new System.Drawing.Point(138, 71);
            this.entranceProperty_bg.Name = "entranceProperty_bg";
            this.entranceProperty_bg.Size = new System.Drawing.Size(47, 17);
            this.entranceProperty_bg.TabIndex = 41;
            this.entranceProperty_bg.Text = "BG2";
            this.entranceProperty_bg.UseVisualStyleBackColor = true;
            this.entranceProperty_bg.CheckStateChanged += new System.EventHandler(this.entranceProperty_vscroll_CheckedChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(69, 52);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(36, 13);
            this.label39.TabIndex = 20;
            this.label39.Text = "Exit? :";
            // 
            // entranceProperty_exit
            // 
            this.entranceProperty_exit.Location = new System.Drawing.Point(72, 68);
            this.entranceProperty_exit.Name = "entranceProperty_exit";
            this.entranceProperty_exit.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_exit.TabIndex = 18;
            this.entranceProperty_exit.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_blockset
            // 
            this.entranceProperty_blockset.Location = new System.Drawing.Point(6, 68);
            this.entranceProperty_blockset.Name = "entranceProperty_blockset";
            this.entranceProperty_blockset.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_blockset.TabIndex = 17;
            this.entranceProperty_blockset.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(3, 52);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(54, 13);
            this.label40.TabIndex = 15;
            this.label40.Text = "Blockset :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(204, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 13;
            this.label24.Text = "Music :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(135, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "Dungeon :";
            // 
            // entranceProperty_music
            // 
            this.entranceProperty_music.Location = new System.Drawing.Point(204, 29);
            this.entranceProperty_music.Name = "entranceProperty_music";
            this.entranceProperty_music.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_music.TabIndex = 11;
            this.entranceProperty_music.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_dungeon
            // 
            this.entranceProperty_dungeon.Location = new System.Drawing.Point(138, 29);
            this.entranceProperty_dungeon.Name = "entranceProperty_dungeon";
            this.entranceProperty_dungeon.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_dungeon.TabIndex = 10;
            this.entranceProperty_dungeon.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_floor
            // 
            this.entranceProperty_floor.Location = new System.Drawing.Point(72, 29);
            this.entranceProperty_floor.Name = "entranceProperty_floor";
            this.entranceProperty_floor.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_floor.TabIndex = 9;
            this.entranceProperty_floor.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // entranceProperty_room
            // 
            this.entranceProperty_room.Location = new System.Drawing.Point(6, 29);
            this.entranceProperty_room.Name = "entranceProperty_room";
            this.entranceProperty_room.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_room.TabIndex = 8;
            this.entranceProperty_room.TextChanged += new System.EventHandler(this.entranceProperty_room_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(69, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(36, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Floor :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Room Id :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(5, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(173, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Selected Entrance Properties";
            // 
            // objectstabPage
            // 
            this.objectstabPage.Controls.Add(this.panel1);
            this.objectstabPage.Controls.Add(this.favoriteCheckbox);
            this.objectstabPage.Controls.Add(this.showNameObjectCheckbox);
            this.objectstabPage.Controls.Add(this.searchTextbox);
            this.objectstabPage.Location = new System.Drawing.Point(4, 22);
            this.objectstabPage.Name = "objectstabPage";
            this.objectstabPage.Size = new System.Drawing.Size(292, 664);
            this.objectstabPage.TabIndex = 4;
            this.objectstabPage.Text = "Objects";
            this.objectstabPage.UseVisualStyleBackColor = true;
            // 
            // favoriteCheckbox
            // 
            this.favoriteCheckbox.AutoSize = true;
            this.favoriteCheckbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.favoriteCheckbox.Location = new System.Drawing.Point(0, 37);
            this.favoriteCheckbox.Name = "favoriteCheckbox";
            this.favoriteCheckbox.Size = new System.Drawing.Size(292, 17);
            this.favoriteCheckbox.TabIndex = 2;
            this.favoriteCheckbox.Text = "Show Favorite";
            this.favoriteCheckbox.UseVisualStyleBackColor = true;
            this.favoriteCheckbox.CheckedChanged += new System.EventHandler(this.favoriteCheckbox_CheckedChanged);
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
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(292, 664);
            this.tabPage4.TabIndex = 10;
            this.tabPage4.Text = "Sprites";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            // edit8x8
            // 
            this.edit8x8.AutoScroll = true;
            this.edit8x8.Controls.Add(this.edit8x8Panel);
            this.edit8x8.Controls.Add(this.groupBox1);
            this.edit8x8.Location = new System.Drawing.Point(4, 22);
            this.edit8x8.Name = "edit8x8";
            this.edit8x8.Size = new System.Drawing.Size(292, 664);
            this.edit8x8.TabIndex = 11;
            this.edit8x8.Text = "8x8 Tiles";
            this.edit8x8.UseVisualStyleBackColor = true;
            // 
            // edit8x8Panel
            // 
            this.edit8x8Panel.AutoScroll = true;
            this.edit8x8Panel.Controls.Add(this.editBox8x8);
            this.edit8x8Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edit8x8Panel.Location = new System.Drawing.Point(0, 0);
            this.edit8x8Panel.Name = "edit8x8Panel";
            this.edit8x8Panel.Size = new System.Drawing.Size(292, 460);
            this.edit8x8Panel.TabIndex = 2;
            // 
            // editBox8x8
            // 
            this.editBox8x8.Location = new System.Drawing.Point(8, 4);
            this.editBox8x8.Name = "editBox8x8";
            this.editBox8x8.Size = new System.Drawing.Size(256, 1024);
            this.editBox8x8.TabIndex = 0;
            this.editBox8x8.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.edit8x8palettebox);
            this.groupBox1.Controls.Add(this.edit8x8myCheckbox);
            this.groupBox1.Controls.Add(this.edit8x8mxCheckbox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 460);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 204);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tile Properties";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(76, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "On Top?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // edit8x8palettebox
            // 
            this.edit8x8palettebox.Location = new System.Drawing.Point(6, 65);
            this.edit8x8palettebox.Name = "edit8x8palettebox";
            this.edit8x8palettebox.Size = new System.Drawing.Size(256, 128);
            this.edit8x8palettebox.TabIndex = 2;
            this.edit8x8palettebox.TabStop = false;
            this.edit8x8palettebox.Paint += new System.Windows.Forms.PaintEventHandler(this.edit8x8palettebox_Paint);
            // 
            // edit8x8myCheckbox
            // 
            this.edit8x8myCheckbox.AutoSize = true;
            this.edit8x8myCheckbox.Location = new System.Drawing.Point(8, 42);
            this.edit8x8myCheckbox.Name = "edit8x8myCheckbox";
            this.edit8x8myCheckbox.Size = new System.Drawing.Size(62, 17);
            this.edit8x8myCheckbox.TabIndex = 1;
            this.edit8x8myCheckbox.Text = "Mirror Y";
            this.edit8x8myCheckbox.UseVisualStyleBackColor = true;
            // 
            // edit8x8mxCheckbox
            // 
            this.edit8x8mxCheckbox.AutoSize = true;
            this.edit8x8mxCheckbox.Location = new System.Drawing.Point(8, 19);
            this.edit8x8mxCheckbox.Name = "edit8x8mxCheckbox";
            this.edit8x8mxCheckbox.Size = new System.Drawing.Size(62, 17);
            this.edit8x8mxCheckbox.TabIndex = 0;
            this.edit8x8mxCheckbox.Text = "Mirror X";
            this.edit8x8mxCheckbox.UseVisualStyleBackColor = true;
            // 
            // roomProperty_msgid
            // 
            this.roomProperty_msgid.BackColor = System.Drawing.SystemColors.Window;
            this.roomProperty_msgid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomProperty_msgid.ForeColor = System.Drawing.SystemColors.WindowText;
            this.roomProperty_msgid.Location = new System.Drawing.Point(298, 22);
            this.roomProperty_msgid.Name = "roomProperty_msgid";
            this.roomProperty_msgid.Size = new System.Drawing.Size(48, 20);
            this.roomProperty_msgid.TabIndex = 30;
            this.roomProperty_msgid.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label20.Location = new System.Drawing.Point(295, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 13);
            this.label20.TabIndex = 29;
            this.label20.Text = "Msg ID :";
            // 
            // roomProperty_pit
            // 
            this.roomProperty_pit.AutoSize = true;
            this.roomProperty_pit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roomProperty_pit.Location = new System.Drawing.Point(298, 48);
            this.roomProperty_pit.Name = "roomProperty_pit";
            this.roomProperty_pit.Size = new System.Drawing.Size(61, 17);
            this.roomProperty_pit.TabIndex = 28;
            this.roomProperty_pit.Text = "Pit Hurt";
            this.roomProperty_pit.UseVisualStyleBackColor = true;
            this.roomProperty_pit.CheckedChanged += new System.EventHandler(this.roomProperty_pit_CheckedChanged);
            // 
            // roomProperty_tag2
            // 
            this.roomProperty_tag2.BackColor = System.Drawing.SystemColors.Window;
            this.roomProperty_tag2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomProperty_tag2.DropDownWidth = 200;
            this.roomProperty_tag2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roomProperty_tag2.FormattingEnabled = true;
            this.roomProperty_tag2.Location = new System.Drawing.Point(247, 101);
            this.roomProperty_tag2.Name = "roomProperty_tag2";
            this.roomProperty_tag2.Size = new System.Drawing.Size(105, 21);
            this.roomProperty_tag2.TabIndex = 22;
            this.roomProperty_tag2.SelectedIndexChanged += new System.EventHandler(this.roomProperty_bg2_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(244, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Tag 2 :";
            // 
            // roomProperty_tag1
            // 
            this.roomProperty_tag1.BackColor = System.Drawing.SystemColors.Window;
            this.roomProperty_tag1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomProperty_tag1.DropDownWidth = 200;
            this.roomProperty_tag1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roomProperty_tag1.FormattingEnabled = true;
            this.roomProperty_tag1.Location = new System.Drawing.Point(136, 101);
            this.roomProperty_tag1.Name = "roomProperty_tag1";
            this.roomProperty_tag1.Size = new System.Drawing.Size(105, 21);
            this.roomProperty_tag1.TabIndex = 20;
            this.roomProperty_tag1.SelectedIndexChanged += new System.EventHandler(this.roomProperty_bg2_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(133, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Tag 1 :";
            // 
            // roomProperty_effect
            // 
            this.roomProperty_effect.BackColor = System.Drawing.SystemColors.Window;
            this.roomProperty_effect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomProperty_effect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roomProperty_effect.FormattingEnabled = true;
            this.roomProperty_effect.Location = new System.Drawing.Point(6, 101);
            this.roomProperty_effect.Name = "roomProperty_effect";
            this.roomProperty_effect.Size = new System.Drawing.Size(124, 21);
            this.roomProperty_effect.TabIndex = 18;
            this.roomProperty_effect.SelectedIndexChanged += new System.EventHandler(this.roomProperty_bg2_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(3, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Effect :";
            // 
            // roomProperty_spriteset
            // 
            this.roomProperty_spriteset.BackColor = System.Drawing.SystemColors.Window;
            this.roomProperty_spriteset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomProperty_spriteset.ForeColor = System.Drawing.SystemColors.WindowText;
            this.roomProperty_spriteset.Location = new System.Drawing.Point(136, 61);
            this.roomProperty_spriteset.Name = "roomProperty_spriteset";
            this.roomProperty_spriteset.Size = new System.Drawing.Size(48, 20);
            this.roomProperty_spriteset.TabIndex = 16;
            this.roomProperty_spriteset.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(133, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Spr. Set :";
            // 
            // roomProperty_layout
            // 
            this.roomProperty_layout.BackColor = System.Drawing.SystemColors.Window;
            this.roomProperty_layout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomProperty_layout.ForeColor = System.Drawing.SystemColors.WindowText;
            this.roomProperty_layout.Location = new System.Drawing.Point(136, 22);
            this.roomProperty_layout.Name = "roomProperty_layout";
            this.roomProperty_layout.Size = new System.Drawing.Size(48, 20);
            this.roomProperty_layout.TabIndex = 14;
            this.roomProperty_layout.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(133, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Layout :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(187, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Palette :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(187, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Blockset :";
            // 
            // roomProperty_palette
            // 
            this.roomProperty_palette.BackColor = System.Drawing.SystemColors.Window;
            this.roomProperty_palette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomProperty_palette.ForeColor = System.Drawing.SystemColors.WindowText;
            this.roomProperty_palette.Location = new System.Drawing.Point(190, 61);
            this.roomProperty_palette.Name = "roomProperty_palette";
            this.roomProperty_palette.Size = new System.Drawing.Size(48, 20);
            this.roomProperty_palette.TabIndex = 10;
            this.roomProperty_palette.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // roomProperty_blockset
            // 
            this.roomProperty_blockset.BackColor = System.Drawing.SystemColors.Window;
            this.roomProperty_blockset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomProperty_blockset.ForeColor = System.Drawing.SystemColors.WindowText;
            this.roomProperty_blockset.Location = new System.Drawing.Point(190, 22);
            this.roomProperty_blockset.Name = "roomProperty_blockset";
            this.roomProperty_blockset.Size = new System.Drawing.Size(48, 20);
            this.roomProperty_blockset.TabIndex = 9;
            this.roomProperty_blockset.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // roomProperty_floor2
            // 
            this.roomProperty_floor2.BackColor = System.Drawing.SystemColors.Window;
            this.roomProperty_floor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomProperty_floor2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.roomProperty_floor2.Location = new System.Drawing.Point(244, 61);
            this.roomProperty_floor2.Name = "roomProperty_floor2";
            this.roomProperty_floor2.Size = new System.Drawing.Size(48, 20);
            this.roomProperty_floor2.TabIndex = 8;
            this.roomProperty_floor2.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // roomProperty_floor1
            // 
            this.roomProperty_floor1.BackColor = System.Drawing.SystemColors.Window;
            this.roomProperty_floor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomProperty_floor1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.roomProperty_floor1.Location = new System.Drawing.Point(244, 22);
            this.roomProperty_floor1.Name = "roomProperty_floor1";
            this.roomProperty_floor1.Size = new System.Drawing.Size(48, 20);
            this.roomProperty_floor1.TabIndex = 7;
            this.roomProperty_floor1.TextChanged += new System.EventHandler(this.roomProperty_layout_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(241, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Floor 2 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(241, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Floor 1 :";
            // 
            // roomProperty_collision
            // 
            this.roomProperty_collision.BackColor = System.Drawing.SystemColors.Window;
            this.roomProperty_collision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomProperty_collision.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roomProperty_collision.FormattingEnabled = true;
            this.roomProperty_collision.Location = new System.Drawing.Point(6, 60);
            this.roomProperty_collision.Name = "roomProperty_collision";
            this.roomProperty_collision.Size = new System.Drawing.Size(124, 21);
            this.roomProperty_collision.TabIndex = 4;
            this.roomProperty_collision.SelectedIndexChanged += new System.EventHandler(this.roomProperty_bg2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Collision :";
            // 
            // roomProperty_bg2
            // 
            this.roomProperty_bg2.BackColor = System.Drawing.SystemColors.Window;
            this.roomProperty_bg2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomProperty_bg2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roomProperty_bg2.FormattingEnabled = true;
            this.roomProperty_bg2.Location = new System.Drawing.Point(6, 20);
            this.roomProperty_bg2.Name = "roomProperty_bg2";
            this.roomProperty_bg2.Size = new System.Drawing.Size(124, 21);
            this.roomProperty_bg2.TabIndex = 2;
            this.roomProperty_bg2.SelectedIndexChanged += new System.EventHandler(this.roomProperty_bg2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Background 2 Type :";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(300, 49);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 690);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // headerGroupbox
            // 
            this.headerGroupbox.BackColor = System.Drawing.SystemColors.Control;
            this.headerGroupbox.Controls.Add(this.collisionMapPanel);
            this.headerGroupbox.Controls.Add(this.selectedGroupbox);
            this.headerGroupbox.Controls.Add(this.roomHeaderPanel);
            this.headerGroupbox.Controls.Add(this.doorselectPanel);
            this.headerGroupbox.Controls.Add(this.litCheckbox);
            this.headerGroupbox.Controls.Add(this.spritepropertyPanel);
            this.headerGroupbox.Controls.Add(this.potitemobjectPanel);
            this.headerGroupbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerGroupbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.headerGroupbox.Location = new System.Drawing.Point(303, 49);
            this.headerGroupbox.Name = "headerGroupbox";
            this.headerGroupbox.Size = new System.Drawing.Size(874, 147);
            this.headerGroupbox.TabIndex = 0;
            this.headerGroupbox.TabStop = false;
            this.headerGroupbox.Text = "Room Header : ";
            // 
            // collisionMapPanel
            // 
            this.collisionMapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.collisionMapPanel.BackColor = System.Drawing.SystemColors.Control;
            this.collisionMapPanel.Controls.Add(this.tileTypeCombobox);
            this.collisionMapPanel.Controls.Add(this.collisionMapLabel);
            this.collisionMapPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.collisionMapPanel.Location = new System.Drawing.Point(508, 17);
            this.collisionMapPanel.Name = "collisionMapPanel";
            this.collisionMapPanel.Size = new System.Drawing.Size(363, 50);
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
            this.tileTypeCombobox.Items.AddRange(new object[] {
            "$00 Nothing (standard floor)",
            "$01 Collision",
            "$02 Collision",
            "$03 Collision",
            "$04 Collision",
            "$05 Nothing (unused?)",
            "$06 Nothing (unused?)",
            "$07 Nothing (unused?)",
            "$08 Deep water",
            "$09 Shallow water",
            "$0A Unknown? Possibly unused",
            "$0B Collision (different in Overworld and unknown)",
            "$0C Overlay mask",
            "$0D Spike floor",
            "$0E GT ice",
            "$0F Ice palace ice",
            "$10 Slope ◤",
            "$11 Slope ◥",
            "$12 Slope ◣",
            "$13 Slope ◢",
            "$14 Nothing (unused?)",
            "$15 Nothing (unused?)",
            "$16 Nothing (unused?)",
            "$17 Nothing (unused?)",
            "$18 Slope ◤",
            "$19 Slope ◥",
            "$1A Slope ◣",
            "$1B Slope ◢",
            "$1C Layer 2 overlay",
            "$1D North single-layer auto stairs",
            "$1E North layer-swap auto stairs",
            "$1F North layer-swap auto stairs",
            "$20 Pit",
            "$21 Nothing (unused?)",
            "$22 Manual stairs",
            "$23 Pot switch",
            "$24 Pressure switch",
            "$25 Nothing (unused but referenced by somaria blocks)",
            "$26 Collision (near stairs?)",
            "$27 Brazier/Fence/Statue/Block/General hookable things",
            "$28 North ledge",
            "$29 South ledge",
            "$2A East ledge",
            "$2B West ledge",
            "$2C ◤ ledge",
            "$2D ◣ ledge",
            "$2E ◥ ledge",
            "$2F ◢ ledge",
            "$30 Straight inter-room stairs south/up 0",
            "$31 Straight inter-room stairs south/up 1",
            "$32 Straight inter-room stairs south/up 2",
            "$33 Straight inter-room stairs south/up 3",
            "$34 Straight inter-room stairs north/down 0",
            "$35 Straight inter-room stairs north/down 1",
            "$36 Straight inter-room stairs north/down 2",
            "$37 Straight inter-room stairs north/down 3",
            "$38 Straight inter-room stairs north/down edge",
            "$39 Straight inter-room stairs south/up edge",
            "$3A Star tile (inactive on load)",
            "$3B Star tile (active on load)",
            "$3C Nothing (unused?)",
            "$3D South single-layer auto stairs",
            "$3E South layer-swap auto stairs",
            "$3F South layer-swap auto stairs",
            "$40 Thick grass",
            "$41 Nothing (unused?)",
            "$42 Gravestone / Tower of hera ledge shadows??",
            "$43 Skull Woods entrance/Hera columns???",
            "$44 Spike",
            "$45 Nothing (unused?)",
            "$46 Desert Tablet",
            "$47 Nothing (unused?)",
            "$48 Diggable ground",
            "$49 Nothing (unused?)",
            "$4A Diggable ground",
            "$4B Warp tile",
            "$4C Nothing (unused?) | Something unknown in overworld",
            "$4D Nothing (unused?) | Something unknown in overworld",
            "$4E Square corners in EP overworld",
            "$4F Square corners in EP overworld",
            "$50 Green bush",
            "$51 Dark bush",
            "$52 Gray rock",
            "$53 Black rock",
            "$54 Hint tile/Sign",
            "$55 Big gray rock",
            "$56 Big black rock",
            "$57 Bonk rocks",
            "$58 Chest 0",
            "$59 Chest 1",
            "$5A Chest 2",
            "$5B Chest 3",
            "$5C Chest 4",
            "$5D Chest 5",
            "$5E Spiral stairs",
            "$5F Spiral stairs",
            "$60 Rupee tile",
            "$61 Nothing (unused?)",
            "$62 Bombable floor",
            "$63 Minigame chest",
            "$64 Nothing (unused?)",
            "$65 Nothing (unused?)",
            "$66 Crystal peg down",
            "$67 Crystal peg up",
            "$68 Upwards conveyor",
            "$69 Downwards conveyor",
            "$6A Leftwards conveyor",
            "$6B Rightwards conveyor",
            "$6C North vines",
            "$6D South vines",
            "$6E West vines",
            "$6F East vines",
            "$70 Pot/Hammer peg/Push block 00",
            "$71 Pot/Hammer peg/Push block 01",
            "$72 Pot/Hammer peg/Push block 02",
            "$73 Pot/Hammer peg/Push block 03",
            "$74 Pot/Hammer peg/Push block 04",
            "$75 Pot/Hammer peg/Push block 05",
            "$76 Pot/Hammer peg/Push block 06",
            "$77 Pot/Hammer peg/Push block 07",
            "$78 Pot/Hammer peg/Push block 08",
            "$79 Pot/Hammer peg/Push block 09",
            "$7A Pot/Hammer peg/Push block 0A",
            "$7B Pot/Hammer peg/Push block 0B",
            "$7C Pot/Hammer peg/Push block 0C",
            "$7D Pot/Hammer peg/Push block 0D",
            "$7E Pot/Hammer peg/Push block 0E",
            "$7F Pot/Hammer peg/Push block 0F",
            "$80 North/South door",
            "$81 East/West door",
            "$82 North/South shutter door",
            "$83 East/West shutter door",
            "$84 North/South layer 2 door",
            "$85 East/West layer 2 door",
            "$86 North/South layer 2 shutter door",
            "$87 East/West layer 2 shutter door",
            "$88 Some type of door (?)",
            "$89 East/West transport door",
            "$8A Some type of door (?)",
            "$8B Some type of door (?)",
            "$8C Some type of door (?)",
            "$8D Some type of door (?)",
            "$8E Entrance door",
            "$8F Entrance door",
            "$90 Layer toggle shutter door (?)",
            "$91 Layer toggle shutter door (?)",
            "$92 Layer toggle shutter door (?)",
            "$93 Layer toggle shutter door (?)",
            "$94 Layer toggle shutter door (?)",
            "$95 Layer toggle shutter door (?)",
            "$96 Layer toggle shutter door (?)",
            "$97 Layer toggle shutter door (?)",
            "$98 Layer+Dungeon toggle shutter door (?)",
            "$99 Layer+Dungeon toggle shutter door (?)",
            "$9A Layer+Dungeon toggle shutter door (?)",
            "$9B Layer+Dungeon toggle shutter door (?)",
            "$9C Layer+Dungeon toggle shutter door (?)",
            "$9D Layer+Dungeon toggle shutter door (?)",
            "$9E Layer+Dungeon toggle shutter door (?)",
            "$9F Layer+Dungeon toggle shutter door (?)",
            "$A0 North/South Dungeon swap door",
            "$A1 Dungeon toggle door (?)",
            "$A2 Dungeon toggle door (?)",
            "$A3 Dungeon toggle door (?)",
            "$A4 Dungeon toggle door (?)",
            "$A5 Dungeon toggle door (?)",
            "$A6 Nothing (unused?)",
            "$A7 Nothing (unused?)",
            "$A8 Layer+Dungeon toggle shutter door (?)",
            "$A9 Layer+Dungeon toggle shutter door (?)",
            "$AA Layer+Dungeon toggle shutter door (?)",
            "$AB Layer+Dungeon toggle shutter door (?)",
            "$AC Layer+Dungeon toggle shutter door (?)",
            "$AD Layer+Dungeon toggle shutter door (?)",
            "$AE Layer+Dungeon toggle shutter door (?)",
            "$AF Layer+Dungeon toggle shutter door (?)",
            "$B0 Somaria ─",
            "$B1 Somaria │",
            "$B2 Somaria ┌",
            "$B3 Somaria └",
            "$B4 Somaria ┐",
            "$B5 Somaria ┘",
            "$B6 Somaria ⍰ 1 way",
            "$B7 Somaria ┬",
            "$B8 Somaria ┴",
            "$B9 Somaria ├",
            "$BA Somaria ┤",
            "$BB Somaria ┼",
            "$BC Somaria ⍰ 2 way",
            "$BD Somaria ┼ crossover",
            "$BE Pipe entrance",
            "$BF Nothing (unused?)",
            "$C0 Torch 00",
            "$C1 Torch 01",
            "$C2 Torch 02",
            "$C3 Torch 03",
            "$C4 Torch 04",
            "$C5 Torch 05",
            "$C6 Torch 06",
            "$C7 Torch 07",
            "$C8 Torch 08",
            "$C9 Torch 09",
            "$CA Torch 0A",
            "$CB Torch 0B",
            "$CC Torch 0C",
            "$CD Torch 0D",
            "$CE Torch 0E",
            "$CF Torch 0F",
            "$D0 Nothing (unused?)",
            "$D1 Nothing (unused?)",
            "$D2 Nothing (unused?)",
            "$D3 Nothing (unused?)",
            "$D4 Nothing (unused?)",
            "$D5 Nothing (unused?)",
            "$D6 Nothing (unused?)",
            "$D7 Nothing (unused?)",
            "$D8 Nothing (unused?)",
            "$D9 Nothing (unused?)",
            "$DA Nothing (unused?)",
            "$DB Nothing (unused?)",
            "$DC Nothing (unused?)",
            "$DD Nothing (unused?)",
            "$DE Nothing (unused?)",
            "$DF Nothing (unused?)",
            "$E0 Nothing (unused?)",
            "$E1 Nothing (unused?)",
            "$E2 Nothing (unused?)",
            "$E3 Nothing (unused?)",
            "$E4 Nothing (unused?)",
            "$E5 Nothing (unused?)",
            "$E6 Nothing (unused?)",
            "$E7 Nothing (unused?)",
            "$E8 Nothing (unused?)",
            "$E9 Nothing (unused?)",
            "$EA Nothing (unused?)",
            "$EB Nothing (unused?)",
            "$EC Nothing (unused?)",
            "$ED Nothing (unused?)",
            "$EE Nothing (unused?)",
            "$EF Nothing (unused?)",
            "$F0 Door 0 bottom",
            "$F1 Door 1 bottom",
            "$F2 Door 2 bottom",
            "$F3 Door 3 bottom",
            "$F4 Door X bottom? (unused?)",
            "$F5 Door X bottom? (unused?)",
            "$F6 Door X bottom? (unused?)",
            "$F7 Door X bottom? (unused?)",
            "$F8 Door 0 top",
            "$F9 Door 1 top",
            "$FA Door 2 top",
            "$FB Door 3 top",
            "$FC Door X top? (unused?)",
            "$FD Door X top? (unused?)",
            "$FE Door X top? (unused?)",
            "$FF Door X top? (unused?)"});
            this.tileTypeCombobox.Location = new System.Drawing.Point(6, 25);
            this.tileTypeCombobox.Name = "tileTypeCombobox";
            this.tileTypeCombobox.Size = new System.Drawing.Size(348, 21);
            this.tileTypeCombobox.TabIndex = 8;
            // 
            // collisionMapLabel
            // 
            this.collisionMapLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.collisionMapLabel.AutoSize = true;
            this.collisionMapLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.collisionMapLabel.Location = new System.Drawing.Point(3, 8);
            this.collisionMapLabel.Name = "collisionMapLabel";
            this.collisionMapLabel.Size = new System.Drawing.Size(215, 13);
            this.collisionMapLabel.TabIndex = 9;
            this.collisionMapLabel.Text = "Selected Tile Type (WIP -Not working yet) : ";
            // 
            // selectedGroupbox
            // 
            this.selectedGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedGroupbox.BackColor = System.Drawing.SystemColors.Control;
            this.selectedGroupbox.Controls.Add(this.object_size_label);
            this.selectedGroupbox.Controls.Add(this.object_x_label);
            this.selectedGroupbox.Controls.Add(this.object_y_label);
            this.selectedGroupbox.Controls.Add(this.object_layer_label);
            this.selectedGroupbox.Location = new System.Drawing.Point(508, 72);
            this.selectedGroupbox.Name = "selectedGroupbox";
            this.selectedGroupbox.Size = new System.Drawing.Size(360, 72);
            this.selectedGroupbox.TabIndex = 21;
            this.selectedGroupbox.TabStop = false;
            this.selectedGroupbox.Text = "Selected Object";
            // 
            // object_size_label
            // 
            this.object_size_label.AutoSize = true;
            this.object_size_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.object_size_label.Location = new System.Drawing.Point(56, 28);
            this.object_size_label.Name = "object_size_label";
            this.object_size_label.Size = new System.Drawing.Size(33, 13);
            this.object_size_label.TabIndex = 5;
            this.object_size_label.Text = "Size :";
            // 
            // object_x_label
            // 
            this.object_x_label.AutoSize = true;
            this.object_x_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.object_x_label.Location = new System.Drawing.Point(4, 28);
            this.object_x_label.Name = "object_x_label";
            this.object_x_label.Size = new System.Drawing.Size(20, 13);
            this.object_x_label.TabIndex = 1;
            this.object_x_label.Text = "X :";
            // 
            // object_y_label
            // 
            this.object_y_label.AutoSize = true;
            this.object_y_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.object_y_label.Location = new System.Drawing.Point(4, 47);
            this.object_y_label.Name = "object_y_label";
            this.object_y_label.Size = new System.Drawing.Size(20, 13);
            this.object_y_label.TabIndex = 3;
            this.object_y_label.Text = "Y :";
            // 
            // object_layer_label
            // 
            this.object_layer_label.AutoSize = true;
            this.object_layer_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.object_layer_label.Location = new System.Drawing.Point(56, 47);
            this.object_layer_label.Name = "object_layer_label";
            this.object_layer_label.Size = new System.Drawing.Size(39, 13);
            this.object_layer_label.TabIndex = 6;
            this.object_layer_label.Text = "Layer :";
            // 
            // roomHeaderPanel
            // 
            this.roomHeaderPanel.BackColor = System.Drawing.SystemColors.Control;
            this.roomHeaderPanel.Controls.Add(this.label16);
            this.roomHeaderPanel.Controls.Add(this.label15);
            this.roomHeaderPanel.Controls.Add(this.label7);
            this.roomHeaderPanel.Controls.Add(this.label1);
            this.roomHeaderPanel.Controls.Add(this.bg2checkbox5);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_stair4);
            this.roomHeaderPanel.Controls.Add(this.label33);
            this.roomHeaderPanel.Controls.Add(this.label14);
            this.roomHeaderPanel.Controls.Add(this.label28);
            this.roomHeaderPanel.Controls.Add(this.bg2checkbox4);
            this.roomHeaderPanel.Controls.Add(this.bg2checkbox3);
            this.roomHeaderPanel.Controls.Add(this.bg2checkbox2);
            this.roomHeaderPanel.Controls.Add(this.bg2checkbox1);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_stair3);
            this.roomHeaderPanel.Controls.Add(this.label11);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_effect);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_stair1);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_stair2);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_sortsprite);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_hole);
            this.roomHeaderPanel.Controls.Add(this.label2);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_bg2);
            this.roomHeaderPanel.Controls.Add(this.label3);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_collision);
            this.roomHeaderPanel.Controls.Add(this.label9);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_layout);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_pit);
            this.roomHeaderPanel.Controls.Add(this.label10);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_spriteset);
            this.roomHeaderPanel.Controls.Add(this.label6);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_floor2);
            this.roomHeaderPanel.Controls.Add(this.label5);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_floor1);
            this.roomHeaderPanel.Controls.Add(this.label4);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_blockset);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_palette);
            this.roomHeaderPanel.Controls.Add(this.label8);
            this.roomHeaderPanel.Controls.Add(this.label13);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_msgid);
            this.roomHeaderPanel.Controls.Add(this.label20);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_tag1);
            this.roomHeaderPanel.Controls.Add(this.label12);
            this.roomHeaderPanel.Controls.Add(this.roomProperty_tag2);
            this.roomHeaderPanel.Enabled = false;
            this.roomHeaderPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roomHeaderPanel.Location = new System.Drawing.Point(12, 16);
            this.roomHeaderPanel.Name = "roomHeaderPanel";
            this.roomHeaderPanel.Size = new System.Drawing.Size(490, 128);
            this.roomHeaderPanel.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(455, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 13);
            this.label16.TabIndex = 85;
            this.label16.Text = "BG2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(402, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 84;
            this.label15.Text = "Warps";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(388, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 83;
            this.label7.Text = "Stair4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "Stair3";
            // 
            // bg2checkbox5
            // 
            this.bg2checkbox5.AutoSize = true;
            this.bg2checkbox5.Location = new System.Drawing.Point(462, 107);
            this.bg2checkbox5.Name = "bg2checkbox5";
            this.bg2checkbox5.Size = new System.Drawing.Size(15, 14);
            this.bg2checkbox5.TabIndex = 78;
            this.bg2checkbox5.UseVisualStyleBackColor = true;
            // 
            // roomProperty_stair4
            // 
            this.roomProperty_stair4.Location = new System.Drawing.Point(428, 105);
            this.roomProperty_stair4.Name = "roomProperty_stair4";
            this.roomProperty_stair4.Size = new System.Drawing.Size(24, 20);
            this.roomProperty_stair4.TabIndex = 74;
            this.roomProperty_stair4.TextChanged += new System.EventHandler(this.roomProperty_hole_TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(388, 66);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(34, 13);
            this.label33.TabIndex = 81;
            this.label33.Text = "Stair2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(388, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 79;
            this.label14.Text = "Hole";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(388, 45);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(34, 13);
            this.label28.TabIndex = 80;
            this.label28.Text = "Stair1";
            // 
            // bg2checkbox4
            // 
            this.bg2checkbox4.AutoSize = true;
            this.bg2checkbox4.Location = new System.Drawing.Point(462, 87);
            this.bg2checkbox4.Name = "bg2checkbox4";
            this.bg2checkbox4.Size = new System.Drawing.Size(15, 14);
            this.bg2checkbox4.TabIndex = 77;
            this.bg2checkbox4.UseVisualStyleBackColor = true;
            // 
            // bg2checkbox3
            // 
            this.bg2checkbox3.AutoSize = true;
            this.bg2checkbox3.Location = new System.Drawing.Point(462, 66);
            this.bg2checkbox3.Name = "bg2checkbox3";
            this.bg2checkbox3.Size = new System.Drawing.Size(15, 14);
            this.bg2checkbox3.TabIndex = 76;
            this.bg2checkbox3.UseVisualStyleBackColor = true;
            // 
            // bg2checkbox2
            // 
            this.bg2checkbox2.AutoSize = true;
            this.bg2checkbox2.Location = new System.Drawing.Point(462, 45);
            this.bg2checkbox2.Name = "bg2checkbox2";
            this.bg2checkbox2.Size = new System.Drawing.Size(15, 14);
            this.bg2checkbox2.TabIndex = 75;
            this.bg2checkbox2.UseVisualStyleBackColor = true;
            // 
            // bg2checkbox1
            // 
            this.bg2checkbox1.AutoSize = true;
            this.bg2checkbox1.Location = new System.Drawing.Point(462, 24);
            this.bg2checkbox1.Name = "bg2checkbox1";
            this.bg2checkbox1.Size = new System.Drawing.Size(15, 14);
            this.bg2checkbox1.TabIndex = 74;
            this.bg2checkbox1.UseVisualStyleBackColor = true;
            // 
            // roomProperty_stair3
            // 
            this.roomProperty_stair3.Location = new System.Drawing.Point(428, 84);
            this.roomProperty_stair3.Name = "roomProperty_stair3";
            this.roomProperty_stair3.Size = new System.Drawing.Size(24, 20);
            this.roomProperty_stair3.TabIndex = 73;
            this.roomProperty_stair3.TextChanged += new System.EventHandler(this.roomProperty_hole_TextChanged);
            // 
            // roomProperty_stair1
            // 
            this.roomProperty_stair1.Location = new System.Drawing.Point(428, 42);
            this.roomProperty_stair1.Name = "roomProperty_stair1";
            this.roomProperty_stair1.Size = new System.Drawing.Size(24, 20);
            this.roomProperty_stair1.TabIndex = 71;
            this.roomProperty_stair1.TextChanged += new System.EventHandler(this.roomProperty_hole_TextChanged);
            // 
            // roomProperty_stair2
            // 
            this.roomProperty_stair2.Location = new System.Drawing.Point(428, 63);
            this.roomProperty_stair2.Name = "roomProperty_stair2";
            this.roomProperty_stair2.Size = new System.Drawing.Size(24, 20);
            this.roomProperty_stair2.TabIndex = 72;
            this.roomProperty_stair2.TextChanged += new System.EventHandler(this.roomProperty_hole_TextChanged);
            // 
            // roomProperty_hole
            // 
            this.roomProperty_hole.Location = new System.Drawing.Point(428, 21);
            this.roomProperty_hole.Name = "roomProperty_hole";
            this.roomProperty_hole.Size = new System.Drawing.Size(24, 20);
            this.roomProperty_hole.TabIndex = 70;
            this.roomProperty_hole.TextChanged += new System.EventHandler(this.roomProperty_hole_TextChanged);
            // 
            // doorselectPanel
            // 
            this.doorselectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doorselectPanel.BackColor = System.Drawing.SystemColors.Control;
            this.doorselectPanel.Controls.Add(this.comboBox2);
            this.doorselectPanel.Controls.Add(this.label25);
            this.doorselectPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.doorselectPanel.Location = new System.Drawing.Point(508, 16);
            this.doorselectPanel.Name = "doorselectPanel";
            this.doorselectPanel.Size = new System.Drawing.Size(363, 50);
            this.doorselectPanel.TabIndex = 18;
            this.doorselectPanel.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 26);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(348, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label25.Location = new System.Drawing.Point(3, 8);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 13);
            this.label25.TabIndex = 9;
            this.label25.Text = "Door Type : ";
            // 
            // litCheckbox
            // 
            this.litCheckbox.AutoSize = true;
            this.litCheckbox.Location = new System.Drawing.Point(618, 46);
            this.litCheckbox.Name = "litCheckbox";
            this.litCheckbox.Size = new System.Drawing.Size(81, 17);
            this.litCheckbox.TabIndex = 19;
            this.litCheckbox.Text = "Already Lit?";
            this.litCheckbox.UseVisualStyleBackColor = true;
            this.litCheckbox.Visible = false;
            this.litCheckbox.CheckedChanged += new System.EventHandler(this.litCheckbox_CheckedChanged);
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
            this.spritepropertyPanel.Location = new System.Drawing.Point(508, 16);
            this.spritepropertyPanel.Name = "spritepropertyPanel";
            this.spritepropertyPanel.Size = new System.Drawing.Size(363, 50);
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
            this.comboBox1.Size = new System.Drawing.Size(125, 21);
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
            // potitemobjectPanel
            // 
            this.potitemobjectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.potitemobjectPanel.Controls.Add(this.selecteditemobjectCombobox);
            this.potitemobjectPanel.Controls.Add(this.label31);
            this.potitemobjectPanel.Location = new System.Drawing.Point(508, 16);
            this.potitemobjectPanel.Name = "potitemobjectPanel";
            this.potitemobjectPanel.Size = new System.Drawing.Size(363, 50);
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
            "Rupee",
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
            this.selecteditemobjectCombobox.Size = new System.Drawing.Size(348, 21);
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
            // editorsTabControl
            // 
            this.editorsTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.editorsTabControl.Controls.Add(this.dungeonPage);
            this.editorsTabControl.Controls.Add(this.overworldPage);
            this.editorsTabControl.Controls.Add(this.GfxEditorPage);
            this.editorsTabControl.Controls.Add(this.textPage);
            this.editorsTabControl.Controls.Add(this.ScreenEditor);
            this.editorsTabControl.Controls.Add(this.spritesPage);
            this.editorsTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editorsTabControl.Enabled = false;
            this.editorsTabControl.Location = new System.Drawing.Point(0, 739);
            this.editorsTabControl.Name = "editorsTabControl";
            this.editorsTabControl.SelectedIndex = 0;
            this.editorsTabControl.Size = new System.Drawing.Size(1177, 22);
            this.editorsTabControl.TabIndex = 22;
            this.editorsTabControl.SelectedIndexChanged += new System.EventHandler(this.editorsTabControl_SelectedIndexChanged);
            // 
            // dungeonPage
            // 
            this.dungeonPage.Location = new System.Drawing.Point(4, 25);
            this.dungeonPage.Name = "dungeonPage";
            this.dungeonPage.Padding = new System.Windows.Forms.Padding(3);
            this.dungeonPage.Size = new System.Drawing.Size(1169, 0);
            this.dungeonPage.TabIndex = 0;
            this.dungeonPage.Text = "Dungeon Editor";
            this.dungeonPage.UseVisualStyleBackColor = true;
            // 
            // overworldPage
            // 
            this.overworldPage.Location = new System.Drawing.Point(4, 25);
            this.overworldPage.Name = "overworldPage";
            this.overworldPage.Padding = new System.Windows.Forms.Padding(3);
            this.overworldPage.Size = new System.Drawing.Size(1169, 0);
            this.overworldPage.TabIndex = 1;
            this.overworldPage.Text = "Overworld Editor";
            this.overworldPage.UseVisualStyleBackColor = true;
            // 
            // GfxEditorPage
            // 
            this.GfxEditorPage.Location = new System.Drawing.Point(4, 25);
            this.GfxEditorPage.Name = "GfxEditorPage";
            this.GfxEditorPage.Size = new System.Drawing.Size(1169, 0);
            this.GfxEditorPage.TabIndex = 2;
            this.GfxEditorPage.Text = "Gfx Import/Export";
            this.GfxEditorPage.UseVisualStyleBackColor = true;
            // 
            // textPage
            // 
            this.textPage.Location = new System.Drawing.Point(4, 25);
            this.textPage.Name = "textPage";
            this.textPage.Size = new System.Drawing.Size(1169, 0);
            this.textPage.TabIndex = 4;
            this.textPage.Text = "Text Editor";
            this.textPage.UseVisualStyleBackColor = true;
            // 
            // ScreenEditor
            // 
            this.ScreenEditor.Location = new System.Drawing.Point(4, 25);
            this.ScreenEditor.Name = "ScreenEditor";
            this.ScreenEditor.Size = new System.Drawing.Size(1169, 0);
            this.ScreenEditor.TabIndex = 5;
            this.ScreenEditor.Text = "Screen Editor";
            this.ScreenEditor.UseVisualStyleBackColor = true;
            // 
            // spritesPage
            // 
            this.spritesPage.Location = new System.Drawing.Point(4, 25);
            this.spritesPage.Name = "spritesPage";
            this.spritesPage.Size = new System.Drawing.Size(1169, 0);
            this.spritesPage.TabIndex = 6;
            this.spritesPage.Text = "Sprites Editor";
            this.spritesPage.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.roomToolStripMenuItem,
            this.testToolStripMenuItem,
            this.naviguateToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.overworldViewToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.jPDebugToolStripMenuItem,
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1177, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.recentROMToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.openToolStripMenuItem.Text = "Open ROM";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveToolStripMenuItem.Text = "Save ROM";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveasToolStripMenuItem
            // 
            this.saveasToolStripMenuItem.Enabled = false;
            this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            this.saveasToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveasToolStripMenuItem.Text = "Save ROM As...";
            this.saveasToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
            // 
            // recentROMToolStripMenuItem
            // 
            this.recentROMToolStripMenuItem.Name = "recentROMToolStripMenuItem";
            this.recentROMToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.recentROMToolStripMenuItem.Text = "Recent ROM";
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
            this.deselectedAllMapForExportToolStripMenuItem,
            this.toolStripSeparator9,
            this.increaseObjectSizeToolStripMenuItem,
            this.decreaseObjectSizeToolStripMenuItem,
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
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(237, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(237, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Enabled = false;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(237, 6);
            // 
            // moveFrontToolStripMenuItem
            // 
            this.moveFrontToolStripMenuItem.Enabled = false;
            this.moveFrontToolStripMenuItem.Name = "moveFrontToolStripMenuItem";
            this.moveFrontToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.moveFrontToolStripMenuItem.Text = "Bring to Front";
            this.moveFrontToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // bringToBackToolStripMenuItem
            // 
            this.bringToBackToolStripMenuItem.Enabled = false;
            this.bringToBackToolStripMenuItem.Name = "bringToBackToolStripMenuItem";
            this.bringToBackToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.bringToBackToolStripMenuItem.Text = "Send to Back";
            this.bringToBackToolStripMenuItem.Click += new System.EventHandler(this.bringToBackToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(237, 6);
            // 
            // selectAllMapForExportToolStripMenuItem
            // 
            this.selectAllMapForExportToolStripMenuItem.Name = "selectAllMapForExportToolStripMenuItem";
            this.selectAllMapForExportToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.selectAllMapForExportToolStripMenuItem.Text = "Select All Map (For Export)";
            this.selectAllMapForExportToolStripMenuItem.Click += new System.EventHandler(this.selectAllMapForExportToolStripMenuItem_Click);
            // 
            // deselectedAllMapForExportToolStripMenuItem
            // 
            this.deselectedAllMapForExportToolStripMenuItem.Name = "deselectedAllMapForExportToolStripMenuItem";
            this.deselectedAllMapForExportToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.deselectedAllMapForExportToolStripMenuItem.Text = "Deselected All Map (For Export)";
            this.deselectedAllMapForExportToolStripMenuItem.Click += new System.EventHandler(this.deselectedAllMapForExportToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(237, 6);
            // 
            // increaseObjectSizeToolStripMenuItem
            // 
            this.increaseObjectSizeToolStripMenuItem.Name = "increaseObjectSizeToolStripMenuItem";
            this.increaseObjectSizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.increaseObjectSizeToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.increaseObjectSizeToolStripMenuItem.Text = "Increase Object Size";
            this.increaseObjectSizeToolStripMenuItem.Click += new System.EventHandler(this.increaseObjectSizeToolStripMenuItem_Click);
            // 
            // decreaseObjectSizeToolStripMenuItem
            // 
            this.decreaseObjectSizeToolStripMenuItem.Name = "decreaseObjectSizeToolStripMenuItem";
            this.decreaseObjectSizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.decreaseObjectSizeToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.decreaseObjectSizeToolStripMenuItem.Text = "Decrease Object Size";
            this.decreaseObjectSizeToolStripMenuItem.Click += new System.EventHandler(this.decreaseObjectSizeToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(237, 6);
            // 
            // lockoverworldToolStripItem
            // 
            this.lockoverworldToolStripItem.Name = "lockoverworldToolStripItem";
            this.lockoverworldToolStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.lockoverworldToolStripItem.Size = new System.Drawing.Size(240, 22);
            this.lockoverworldToolStripItem.Text = "Lock Overworld Screen";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advancedChestEditorToolStripMenuItem,
            this.dungeonsPropertiesToolStripMenuItem,
            this.loadNamesFileToolStripMenuItem,
            this.saveSettingsToolStripMenuItem,
            this.exportAllMapsToolStripMenuItem,
            this.importAllMapsToolStripMenuItem,
            this.importFromROMToolStripMenuItem});
            this.projectToolStripMenuItem.Enabled = false;
            this.projectToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // advancedChestEditorToolStripMenuItem
            // 
            this.advancedChestEditorToolStripMenuItem.Name = "advancedChestEditorToolStripMenuItem";
            this.advancedChestEditorToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.advancedChestEditorToolStripMenuItem.Text = "Advanced Chest Editor";
            this.advancedChestEditorToolStripMenuItem.Click += new System.EventHandler(this.advancedChestEditorToolStripMenuItem_Click);
            // 
            // dungeonsPropertiesToolStripMenuItem
            // 
            this.dungeonsPropertiesToolStripMenuItem.Name = "dungeonsPropertiesToolStripMenuItem";
            this.dungeonsPropertiesToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.dungeonsPropertiesToolStripMenuItem.Text = "Dungeons Properties";
            this.dungeonsPropertiesToolStripMenuItem.Click += new System.EventHandler(this.dungeonsPropertiesToolStripMenuItem_Click);
            // 
            // loadNamesFileToolStripMenuItem
            // 
            this.loadNamesFileToolStripMenuItem.Name = "loadNamesFileToolStripMenuItem";
            this.loadNamesFileToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.loadNamesFileToolStripMenuItem.Text = "Load Names File";
            this.loadNamesFileToolStripMenuItem.Click += new System.EventHandler(this.loadNamesFileToolStripMenuItem_Click);
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.saveSettingsToolStripMenuItem.Text = "Save Enable/Disable Settings";
            this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
            // 
            // exportAllMapsToolStripMenuItem
            // 
            this.exportAllMapsToolStripMenuItem.Name = "exportAllMapsToolStripMenuItem";
            this.exportAllMapsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.exportAllMapsToolStripMenuItem.Text = "Export All Maps";
            this.exportAllMapsToolStripMenuItem.Click += new System.EventHandler(this.exportAllMapsToolStripMenuItem_Click);
            // 
            // importAllMapsToolStripMenuItem
            // 
            this.importAllMapsToolStripMenuItem.Name = "importAllMapsToolStripMenuItem";
            this.importAllMapsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.importAllMapsToolStripMenuItem.Text = "Import All Maps";
            this.importAllMapsToolStripMenuItem.Click += new System.EventHandler(this.importAllMapsToolStripMenuItem_Click);
            // 
            // importFromROMToolStripMenuItem
            // 
            this.importFromROMToolStripMenuItem.Name = "importFromROMToolStripMenuItem";
            this.importFromROMToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.importFromROMToolStripMenuItem.Text = "Import from ROM";
            this.importFromROMToolStripMenuItem.Click += new System.EventHandler(this.importFromROMToolStripMenuItem_Click);
            // 
            // roomToolStripMenuItem
            // 
            this.roomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoRoomToolStripMenuItem,
            this.removeMaskObjectsToolStripMenuItem,
            this.printRoomObjectsToolStripMenuItem1,
            this.clearSelectedRoomToolStripMenuItem,
            this.clearAllRoomsToolStripMenuItem,
            this.exportAsASMToolStripMenuItem,
            this.exportAllRoomsToolStripMenuItem,
            this.exportSpritesAsBinaryToolStripMenuItem,
            this.importRoomToolStripMenuItem,
            this.showRoomsInHexToolStripMenuItem,
            this.selectedObjectInHexToolStripMenuItem});
            this.roomToolStripMenuItem.Enabled = false;
            this.roomToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roomToolStripMenuItem.Name = "roomToolStripMenuItem";
            this.roomToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.roomToolStripMenuItem.Text = "Room";
            // 
            // gotoRoomToolStripMenuItem
            // 
            this.gotoRoomToolStripMenuItem.Name = "gotoRoomToolStripMenuItem";
            this.gotoRoomToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.gotoRoomToolStripMenuItem.Text = "Goto Room";
            this.gotoRoomToolStripMenuItem.Click += new System.EventHandler(this.gotoRoomToolStripMenuItem_Click_1);
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
            this.selectedObjectInHexToolStripMenuItem.Click += new System.EventHandler(this.selectedObjectInHexToolStripMenuItem_Click);
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
            this.runToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // debugRunToolStripMenuItem
            // 
            this.debugRunToolStripMenuItem.Name = "debugRunToolStripMenuItem";
            this.debugRunToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.debugRunToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.debugRunToolStripMenuItem.Text = "Debug Run";
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
            this.openDownRoomToolStripMenuItem,
            this.openDungeonTabToolStripMenuItem,
            this.openOverwolrdTabToolStripMenuItem,
            this.openGfxTabToolStripMenuItem});
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
            this.moveToRightToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.moveToRightToolStripMenuItem.Text = "Move to Right Room";
            // 
            // moveToLeftToolStripMenuItem
            // 
            this.moveToLeftToolStripMenuItem.Enabled = false;
            this.moveToLeftToolStripMenuItem.Name = "moveToLeftToolStripMenuItem";
            this.moveToLeftToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Left)));
            this.moveToLeftToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.moveToLeftToolStripMenuItem.Text = "Move to Left Room";
            // 
            // moveToUpToolStripMenuItem
            // 
            this.moveToUpToolStripMenuItem.Enabled = false;
            this.moveToUpToolStripMenuItem.Name = "moveToUpToolStripMenuItem";
            this.moveToUpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.moveToUpToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.moveToUpToolStripMenuItem.Text = "Move to Up Room";
            // 
            // moveToDownToolStripMenuItem
            // 
            this.moveToDownToolStripMenuItem.Enabled = false;
            this.moveToDownToolStripMenuItem.Name = "moveToDownToolStripMenuItem";
            this.moveToDownToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.moveToDownToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.moveToDownToolStripMenuItem.Text = "Move to Down Room";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(245, 6);
            // 
            // openRightRoomToolStripMenuItem
            // 
            this.openRightRoomToolStripMenuItem.Name = "openRightRoomToolStripMenuItem";
            this.openRightRoomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.openRightRoomToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.openRightRoomToolStripMenuItem.Text = "Open Right Room";
            this.openRightRoomToolStripMenuItem.Click += new System.EventHandler(this.openRightRoomToolStripMenuItem_Click);
            // 
            // openLeftRoomToolStripMenuItem
            // 
            this.openLeftRoomToolStripMenuItem.Name = "openLeftRoomToolStripMenuItem";
            this.openLeftRoomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.openLeftRoomToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.openLeftRoomToolStripMenuItem.Text = "Open Left Room";
            this.openLeftRoomToolStripMenuItem.Click += new System.EventHandler(this.openLeftRoomToolStripMenuItem_Click);
            // 
            // openUpRoomToolStripMenuItem
            // 
            this.openUpRoomToolStripMenuItem.Name = "openUpRoomToolStripMenuItem";
            this.openUpRoomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.openUpRoomToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.openUpRoomToolStripMenuItem.Text = "Open Up Room";
            this.openUpRoomToolStripMenuItem.Click += new System.EventHandler(this.openUpRoomToolStripMenuItem_Click);
            // 
            // openDownRoomToolStripMenuItem
            // 
            this.openDownRoomToolStripMenuItem.Name = "openDownRoomToolStripMenuItem";
            this.openDownRoomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.openDownRoomToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.openDownRoomToolStripMenuItem.Text = "Open Down Room";
            this.openDownRoomToolStripMenuItem.Click += new System.EventHandler(this.openDownRoomToolStripMenuItem_Click);
            // 
            // openDungeonTabToolStripMenuItem
            // 
            this.openDungeonTabToolStripMenuItem.Name = "openDungeonTabToolStripMenuItem";
            this.openDungeonTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.openDungeonTabToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.openDungeonTabToolStripMenuItem.Text = "Open Dungeon Tab";
            this.openDungeonTabToolStripMenuItem.Click += new System.EventHandler(this.openDungeonTabToolStripMenuItem_Click);
            // 
            // openOverwolrdTabToolStripMenuItem
            // 
            this.openOverwolrdTabToolStripMenuItem.Name = "openOverwolrdTabToolStripMenuItem";
            this.openOverwolrdTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.openOverwolrdTabToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.openOverwolrdTabToolStripMenuItem.Text = "Open Overwolrd Tab";
            this.openOverwolrdTabToolStripMenuItem.Click += new System.EventHandler(this.openOverwolrdTabToolStripMenuItem_Click);
            // 
            // openGfxTabToolStripMenuItem
            // 
            this.openGfxTabToolStripMenuItem.Name = "openGfxTabToolStripMenuItem";
            this.openGfxTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.openGfxTabToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.openGfxTabToolStripMenuItem.Text = "Open Gfx Tab";
            this.openGfxTabToolStripMenuItem.Click += new System.EventHandler(this.openGfxTabToolStripMenuItem_Click);
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
            this.darkThemeToolStripMenuItem,
            this.rightSideToolboxToolStripMenuItem,
            this.hideSpritesToolStripMenuItem,
            this.hideItemsToolStripMenuItem,
            this.hideChestItemsToolStripMenuItem,
            this.showDoorIDsToolStripMenuItem,
            this.showChestsIDsToolStripMenuItem,
            this.disableEntranceGFXToolStripMenuItem,
            this.xScreenToolStripMenuItem,
            this.showBG2MaskOutlineToolStripMenuItem,
            this.entranceCameraToolStripMenuItem,
            this.entrancePositionToolStripMenuItem,
            this.invisibleObjectsTextToolStripMenuItem,
            this.overworldOverlayVisibleToolStripMenuItem,
            this.showMapIndexInHexToolStripMenuItem});
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // textSpriteToolStripMenuItem
            // 
            this.textSpriteToolStripMenuItem.CheckOnClick = true;
            this.textSpriteToolStripMenuItem.Name = "textSpriteToolStripMenuItem";
            this.textSpriteToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.textSpriteToolStripMenuItem.Text = "Text Sprite";
            this.textSpriteToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
            // 
            // textChestItemToolStripMenuItem
            // 
            this.textChestItemToolStripMenuItem.CheckOnClick = true;
            this.textChestItemToolStripMenuItem.Name = "textChestItemToolStripMenuItem";
            this.textChestItemToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.textChestItemToolStripMenuItem.Text = "Text ChestItem";
            this.textChestItemToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
            // 
            // textPotItemToolStripMenuItem
            // 
            this.textPotItemToolStripMenuItem.CheckOnClick = true;
            this.textPotItemToolStripMenuItem.Name = "textPotItemToolStripMenuItem";
            this.textPotItemToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.textPotItemToolStripMenuItem.Text = "Text PotItem";
            this.textPotItemToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
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
            this.showGridToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
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
            this.showBG2ToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showBG2ToolStripMenuItem.Text = "Show BG2";
            this.showBG2ToolStripMenuItem.Click += new System.EventHandler(this.showBG2ToolStripMenuItem_Click);
            // 
            // showBG1ToolStripMenuItem
            // 
            this.showBG1ToolStripMenuItem.Checked = true;
            this.showBG1ToolStripMenuItem.CheckOnClick = true;
            this.showBG1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBG1ToolStripMenuItem.Name = "showBG1ToolStripMenuItem";
            this.showBG1ToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showBG1ToolStripMenuItem.Text = "Show BG1";
            this.showBG1ToolStripMenuItem.Click += new System.EventHandler(this.showBG1ToolStripMenuItem_Click);
            // 
            // unselectedBGTransparentToolStripMenuItem
            // 
            this.unselectedBGTransparentToolStripMenuItem.Checked = true;
            this.unselectedBGTransparentToolStripMenuItem.CheckOnClick = true;
            this.unselectedBGTransparentToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.unselectedBGTransparentToolStripMenuItem.Name = "unselectedBGTransparentToolStripMenuItem";
            this.unselectedBGTransparentToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.unselectedBGTransparentToolStripMenuItem.Text = "Unselected BG Transparent";
            this.unselectedBGTransparentToolStripMenuItem.Click += new System.EventHandler(this.unselectedBGTransparentToolStripMenuItem_Click);
            // 
            // darkThemeToolStripMenuItem
            // 
            this.darkThemeToolStripMenuItem.CheckOnClick = true;
            this.darkThemeToolStripMenuItem.Enabled = false;
            this.darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
            this.darkThemeToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.darkThemeToolStripMenuItem.Text = "Dark Theme";
            this.darkThemeToolStripMenuItem.Click += new System.EventHandler(this.darkThemeToolStripMenuItem_Click);
            // 
            // rightSideToolboxToolStripMenuItem
            // 
            this.rightSideToolboxToolStripMenuItem.CheckOnClick = true;
            this.rightSideToolboxToolStripMenuItem.Name = "rightSideToolboxToolStripMenuItem";
            this.rightSideToolboxToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.rightSideToolboxToolStripMenuItem.Text = "Entrance Properties Below";
            this.rightSideToolboxToolStripMenuItem.Click += new System.EventHandler(this.rightSideToolboxToolStripMenuItem_Click);
            // 
            // hideSpritesToolStripMenuItem
            // 
            this.hideSpritesToolStripMenuItem.Checked = true;
            this.hideSpritesToolStripMenuItem.CheckOnClick = true;
            this.hideSpritesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideSpritesToolStripMenuItem.Name = "hideSpritesToolStripMenuItem";
            this.hideSpritesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.hideSpritesToolStripMenuItem.Text = "Show Sprites";
            this.hideSpritesToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
            // 
            // hideItemsToolStripMenuItem
            // 
            this.hideItemsToolStripMenuItem.Checked = true;
            this.hideItemsToolStripMenuItem.CheckOnClick = true;
            this.hideItemsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideItemsToolStripMenuItem.Name = "hideItemsToolStripMenuItem";
            this.hideItemsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.hideItemsToolStripMenuItem.Text = "Show Items";
            this.hideItemsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
            // 
            // hideChestItemsToolStripMenuItem
            // 
            this.hideChestItemsToolStripMenuItem.Checked = true;
            this.hideChestItemsToolStripMenuItem.CheckOnClick = true;
            this.hideChestItemsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideChestItemsToolStripMenuItem.Name = "hideChestItemsToolStripMenuItem";
            this.hideChestItemsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.hideChestItemsToolStripMenuItem.Text = "Show Chest Items";
            this.hideChestItemsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
            // 
            // showDoorIDsToolStripMenuItem
            // 
            this.showDoorIDsToolStripMenuItem.Checked = true;
            this.showDoorIDsToolStripMenuItem.CheckOnClick = true;
            this.showDoorIDsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showDoorIDsToolStripMenuItem.Name = "showDoorIDsToolStripMenuItem";
            this.showDoorIDsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showDoorIDsToolStripMenuItem.Text = "Show Door IDs";
            this.showDoorIDsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
            // 
            // showChestsIDsToolStripMenuItem
            // 
            this.showChestsIDsToolStripMenuItem.Checked = true;
            this.showChestsIDsToolStripMenuItem.CheckOnClick = true;
            this.showChestsIDsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showChestsIDsToolStripMenuItem.Name = "showChestsIDsToolStripMenuItem";
            this.showChestsIDsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showChestsIDsToolStripMenuItem.Text = "Show Chests IDs";
            this.showChestsIDsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
            // 
            // disableEntranceGFXToolStripMenuItem
            // 
            this.disableEntranceGFXToolStripMenuItem.CheckOnClick = true;
            this.disableEntranceGFXToolStripMenuItem.Name = "disableEntranceGFXToolStripMenuItem";
            this.disableEntranceGFXToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.disableEntranceGFXToolStripMenuItem.Text = "Disable Entrance GFX";
            this.disableEntranceGFXToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
            // 
            // xScreenToolStripMenuItem
            // 
            this.xScreenToolStripMenuItem.CheckOnClick = true;
            this.xScreenToolStripMenuItem.Name = "xScreenToolStripMenuItem";
            this.xScreenToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.xScreenToolStripMenuItem.Text = "2X Screen";
            this.xScreenToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideSpritesToolStripMenuItem_CheckStateChanged);
            this.xScreenToolStripMenuItem.Click += new System.EventHandler(this.xScreenToolStripMenuItem_Click);
            // 
            // showBG2MaskOutlineToolStripMenuItem
            // 
            this.showBG2MaskOutlineToolStripMenuItem.Checked = true;
            this.showBG2MaskOutlineToolStripMenuItem.CheckOnClick = true;
            this.showBG2MaskOutlineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBG2MaskOutlineToolStripMenuItem.Name = "showBG2MaskOutlineToolStripMenuItem";
            this.showBG2MaskOutlineToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showBG2MaskOutlineToolStripMenuItem.Text = "Show BG2 Mask Outline";
            this.showBG2MaskOutlineToolStripMenuItem.Click += new System.EventHandler(this.showBG2MaskOutlineToolStripMenuItem_Click);
            // 
            // entranceCameraToolStripMenuItem
            // 
            this.entranceCameraToolStripMenuItem.Checked = true;
            this.entranceCameraToolStripMenuItem.CheckOnClick = true;
            this.entranceCameraToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entranceCameraToolStripMenuItem.Name = "entranceCameraToolStripMenuItem";
            this.entranceCameraToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.entranceCameraToolStripMenuItem.Text = "Entrance Camera";
            this.entranceCameraToolStripMenuItem.Click += new System.EventHandler(this.entranceCameraToolStripMenuItem_Click);
            // 
            // entrancePositionToolStripMenuItem
            // 
            this.entrancePositionToolStripMenuItem.Checked = true;
            this.entrancePositionToolStripMenuItem.CheckOnClick = true;
            this.entrancePositionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entrancePositionToolStripMenuItem.Name = "entrancePositionToolStripMenuItem";
            this.entrancePositionToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.entrancePositionToolStripMenuItem.Text = "Entrance Position";
            this.entrancePositionToolStripMenuItem.Click += new System.EventHandler(this.entrancePositionToolStripMenuItem_Click);
            // 
            // invisibleObjectsTextToolStripMenuItem
            // 
            this.invisibleObjectsTextToolStripMenuItem.Checked = true;
            this.invisibleObjectsTextToolStripMenuItem.CheckOnClick = true;
            this.invisibleObjectsTextToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.invisibleObjectsTextToolStripMenuItem.Name = "invisibleObjectsTextToolStripMenuItem";
            this.invisibleObjectsTextToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.invisibleObjectsTextToolStripMenuItem.Text = "Invisible Objects Text";
            // 
            // overworldOverlayVisibleToolStripMenuItem
            // 
            this.overworldOverlayVisibleToolStripMenuItem.CheckOnClick = true;
            this.overworldOverlayVisibleToolStripMenuItem.Name = "overworldOverlayVisibleToolStripMenuItem";
            this.overworldOverlayVisibleToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.overworldOverlayVisibleToolStripMenuItem.Text = "Overworld Overlay Visible";
            // 
            // showMapIndexInHexToolStripMenuItem
            // 
            this.showMapIndexInHexToolStripMenuItem.Checked = true;
            this.showMapIndexInHexToolStripMenuItem.CheckOnClick = true;
            this.showMapIndexInHexToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMapIndexInHexToolStripMenuItem.Enabled = false;
            this.showMapIndexInHexToolStripMenuItem.Name = "showMapIndexInHexToolStripMenuItem";
            this.showMapIndexInHexToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showMapIndexInHexToolStripMenuItem.Text = "Show Map Index in Hex";
            this.showMapIndexInHexToolStripMenuItem.Click += new System.EventHandler(this.showMapIndexInHexToolStripMenuItem_Click);
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
            this.showGridToolStripMenuItem1});
            this.overworldViewToolStripMenuItem.Enabled = false;
            this.overworldViewToolStripMenuItem.Name = "overworldViewToolStripMenuItem";
            this.overworldViewToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.overworldViewToolStripMenuItem.Text = "Overworld View";
            // 
            // showSpritesToolStripMenuItem
            // 
            this.showSpritesToolStripMenuItem.Checked = true;
            this.showSpritesToolStripMenuItem.CheckOnClick = true;
            this.showSpritesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showSpritesToolStripMenuItem.Name = "showSpritesToolStripMenuItem";
            this.showSpritesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.showSpritesToolStripMenuItem.Text = "Show Sprites";
            this.showSpritesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showSpritesToolStripMenuItem_CheckedChanged);
            // 
            // showEntrancesToolStripMenuItem
            // 
            this.showEntrancesToolStripMenuItem.Checked = true;
            this.showEntrancesToolStripMenuItem.CheckOnClick = true;
            this.showEntrancesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showEntrancesToolStripMenuItem.Name = "showEntrancesToolStripMenuItem";
            this.showEntrancesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.showEntrancesToolStripMenuItem.Text = "Show Entrances";
            this.showEntrancesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showSpritesToolStripMenuItem_CheckedChanged);
            // 
            // showExitsToolStripMenuItem
            // 
            this.showExitsToolStripMenuItem.Checked = true;
            this.showExitsToolStripMenuItem.CheckOnClick = true;
            this.showExitsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showExitsToolStripMenuItem.Name = "showExitsToolStripMenuItem";
            this.showExitsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.showExitsToolStripMenuItem.Text = "Show Exits";
            this.showExitsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showSpritesToolStripMenuItem_CheckedChanged);
            // 
            // showTransportsToolStripMenuItem
            // 
            this.showTransportsToolStripMenuItem.Checked = true;
            this.showTransportsToolStripMenuItem.CheckOnClick = true;
            this.showTransportsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTransportsToolStripMenuItem.Name = "showTransportsToolStripMenuItem";
            this.showTransportsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.showTransportsToolStripMenuItem.Text = "Show Transports";
            this.showTransportsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showSpritesToolStripMenuItem_CheckedChanged);
            // 
            // showItemsToolStripMenuItem
            // 
            this.showItemsToolStripMenuItem.Checked = true;
            this.showItemsToolStripMenuItem.CheckOnClick = true;
            this.showItemsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showItemsToolStripMenuItem.Name = "showItemsToolStripMenuItem";
            this.showItemsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.showItemsToolStripMenuItem.Text = "Show Items";
            this.showItemsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showSpritesToolStripMenuItem_CheckedChanged);
            // 
            // showEntranceExitPreviewToolStripMenuItem
            // 
            this.showEntranceExitPreviewToolStripMenuItem.Checked = true;
            this.showEntranceExitPreviewToolStripMenuItem.CheckOnClick = true;
            this.showEntranceExitPreviewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showEntranceExitPreviewToolStripMenuItem.Name = "showEntranceExitPreviewToolStripMenuItem";
            this.showEntranceExitPreviewToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.showEntranceExitPreviewToolStripMenuItem.Text = "Show Entrance/Exit Preview";
            this.showEntranceExitPreviewToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showSpritesToolStripMenuItem_CheckedChanged);
            // 
            // showGridToolStripMenuItem1
            // 
            this.showGridToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x8ToolStripMenuItem1,
            this.x16ToolStripMenuItem1,
            this.x32ToolStripMenuItem1,
            this.noneToolStripMenuItem});
            this.showGridToolStripMenuItem1.Name = "showGridToolStripMenuItem1";
            this.showGridToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
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
            this.vramViewerToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.vramViewerToolStripMenuItem.Text = "Vram Viewer";
            this.vramViewerToolStripMenuItem.Click += new System.EventHandler(this.vramViewerToolStripMenuItem_Click);
            // 
            // cGramViewerToolStripMenuItem
            // 
            this.cGramViewerToolStripMenuItem.Name = "cGramViewerToolStripMenuItem";
            this.cGramViewerToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.cGramViewerToolStripMenuItem.Text = "CGram Viewer";
            this.cGramViewerToolStripMenuItem.Click += new System.EventHandler(this.cGramViewerToolStripMenuItem_Click);
            // 
            // gfxGroupsetsToolStripMenuItem
            // 
            this.gfxGroupsetsToolStripMenuItem.Name = "gfxGroupsetsToolStripMenuItem";
            this.gfxGroupsetsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.gfxGroupsetsToolStripMenuItem.Text = "Gfx Groupsets";
            this.gfxGroupsetsToolStripMenuItem.Click += new System.EventHandler(this.gfxGroupsetsToolStripMenuItem_Click);
            // 
            // palettesEditorToolStripMenuItem
            // 
            this.palettesEditorToolStripMenuItem.Name = "palettesEditorToolStripMenuItem";
            this.palettesEditorToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flipMapHorizontallyToolStripMenuItem,
            this.saveMapsOnlyToolStripMenuItem,
            this.saveVRAMAsPngToolStripMenuItem,
            this.moveRoomsToOtherROMToolStripMenuItem});
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem1.Text = "Tests";
            // 
            // flipMapHorizontallyToolStripMenuItem
            // 
            this.flipMapHorizontallyToolStripMenuItem.Name = "flipMapHorizontallyToolStripMenuItem";
            this.flipMapHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.flipMapHorizontallyToolStripMenuItem.Text = "Flip Map Horizontally";
            this.flipMapHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.flipMapHorizontallyToolStripMenuItem_Click);
            // 
            // saveMapsOnlyToolStripMenuItem
            // 
            this.saveMapsOnlyToolStripMenuItem.Name = "saveMapsOnlyToolStripMenuItem";
            this.saveMapsOnlyToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.saveMapsOnlyToolStripMenuItem.Text = "Save Maps Only";
            this.saveMapsOnlyToolStripMenuItem.Click += new System.EventHandler(this.saveMapsOnlyToolStripMenuItem_Click);
            // 
            // saveVRAMAsPngToolStripMenuItem
            // 
            this.saveVRAMAsPngToolStripMenuItem.Name = "saveVRAMAsPngToolStripMenuItem";
            this.saveVRAMAsPngToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.saveVRAMAsPngToolStripMenuItem.Text = "Save VRAM as png";
            this.saveVRAMAsPngToolStripMenuItem.Click += new System.EventHandler(this.saveVRAMAsPngToolStripMenuItem_Click);
            // 
            // moveRoomsToOtherROMToolStripMenuItem
            // 
            this.moveRoomsToOtherROMToolStripMenuItem.Name = "moveRoomsToOtherROMToolStripMenuItem";
            this.moveRoomsToOtherROMToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.moveRoomsToOtherROMToolStripMenuItem.Text = "Move Rooms to other ROM";
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
            // thumbnailBox
            // 
            this.thumbnailBox.Location = new System.Drawing.Point(3, 352);
            this.thumbnailBox.Name = "thumbnailBox";
            this.thumbnailBox.Size = new System.Drawing.Size(24, 24);
            this.thumbnailBox.TabIndex = 21;
            this.thumbnailBox.TabStop = false;
            this.thumbnailBox.Visible = false;
            this.thumbnailBox.Paint += new System.Windows.Forms.PaintEventHandler(this.thumbnailBox_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label52);
            this.panel2.Controls.Add(this.label53);
            this.panel2.Controls.Add(this.entranceProperty_FR);
            this.panel2.Controls.Add(this.entranceProperty_HR);
            this.panel2.Controls.Add(this.entranceProperty_FL);
            this.panel2.Controls.Add(this.entranceProperty_HL);
            this.panel2.Controls.Add(this.label54);
            this.panel2.Controls.Add(this.label55);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.label49);
            this.panel2.Controls.Add(this.entranceProperty_FD);
            this.panel2.Controls.Add(this.entranceProperty_HD);
            this.panel2.Controls.Add(this.entranceProperty_FU);
            this.panel2.Controls.Add(this.entranceProperty_HU);
            this.panel2.Controls.Add(this.label50);
            this.panel2.Controls.Add(this.label51);
            this.panel2.Controls.Add(this.doorCheckbox);
            this.panel2.Controls.Add(this.dooryTextbox);
            this.panel2.Controls.Add(this.doorxTextbox);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.entranceProperty_quadbr);
            this.panel2.Controls.Add(this.entranceProperty_quadtr);
            this.panel2.Controls.Add(this.entranceProperty_quadbl);
            this.panel2.Controls.Add(this.entranceProperty_quadtl);
            this.panel2.Controls.Add(this.label42);
            this.panel2.Controls.Add(this.entranceProperty_vscroll);
            this.panel2.Controls.Add(this.entranceProperty_hscroll);
            this.panel2.Controls.Add(this.entranceProperty_scrolly);
            this.panel2.Controls.Add(this.entranceProperty_scrollx);
            this.panel2.Controls.Add(this.label43);
            this.panel2.Controls.Add(this.label44);
            this.panel2.Controls.Add(this.label45);
            this.panel2.Controls.Add(this.label46);
            this.panel2.Controls.Add(this.entranceProperty_camy);
            this.panel2.Controls.Add(this.entranceProperty_camx);
            this.panel2.Controls.Add(this.entranceProperty_ypos);
            this.panel2.Controls.Add(this.entranceProperty_xpos);
            this.panel2.Controls.Add(this.label47);
            this.panel2.Controls.Add(this.label48);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.gridEntranceCheckbox);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.mouseEntranceButton);
            this.panel2.Controls.Add(this.entranceProperty_room);
            this.panel2.Controls.Add(this.entranceProperty_bg);
            this.panel2.Controls.Add(this.entranceProperty_floor);
            this.panel2.Controls.Add(this.label39);
            this.panel2.Controls.Add(this.entranceProperty_dungeon);
            this.panel2.Controls.Add(this.entranceProperty_exit);
            this.panel2.Controls.Add(this.entranceProperty_music);
            this.panel2.Controls.Add(this.entranceProperty_blockset);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label40);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.MinimumSize = new System.Drawing.Size(292, 359);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 359);
            this.panel2.TabIndex = 61;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(3, 172);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(57, 13);
            this.label42.TabIndex = 89;
            this.label42.Text = "Quadrant :";
            // 
            // entranceProperty_vscroll
            // 
            this.entranceProperty_vscroll.AutoSize = true;
            this.entranceProperty_vscroll.Location = new System.Drawing.Point(210, 146);
            this.entranceProperty_vscroll.Name = "entranceProperty_vscroll";
            this.entranceProperty_vscroll.Size = new System.Drawing.Size(65, 17);
            this.entranceProperty_vscroll.TabIndex = 88;
            this.entranceProperty_vscroll.Text = "V. Scroll";
            this.entranceProperty_vscroll.UseVisualStyleBackColor = true;
            // 
            // entranceProperty_hscroll
            // 
            this.entranceProperty_hscroll.AutoSize = true;
            this.entranceProperty_hscroll.Location = new System.Drawing.Point(138, 146);
            this.entranceProperty_hscroll.Name = "entranceProperty_hscroll";
            this.entranceProperty_hscroll.Size = new System.Drawing.Size(66, 17);
            this.entranceProperty_hscroll.TabIndex = 87;
            this.entranceProperty_hscroll.Text = "H. Scroll";
            this.entranceProperty_hscroll.UseVisualStyleBackColor = true;
            // 
            // entranceProperty_scrolly
            // 
            this.entranceProperty_scrolly.Location = new System.Drawing.Point(6, 144);
            this.entranceProperty_scrolly.Name = "entranceProperty_scrolly";
            this.entranceProperty_scrolly.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_scrolly.TabIndex = 86;
            // 
            // entranceProperty_scrollx
            // 
            this.entranceProperty_scrollx.Location = new System.Drawing.Point(72, 144);
            this.entranceProperty_scrollx.Name = "entranceProperty_scrollx";
            this.entranceProperty_scrollx.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_scrollx.TabIndex = 85;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(69, 128);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(49, 13);
            this.label43.TabIndex = 84;
            this.label43.Text = "Scroll Y :";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(3, 128);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(49, 13);
            this.label44.TabIndex = 83;
            this.label44.Text = "Scroll X :";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(204, 89);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(59, 13);
            this.label45.TabIndex = 82;
            this.label45.Text = "Camera Y :";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(135, 89);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 13);
            this.label46.TabIndex = 81;
            this.label46.Text = "Camera X :";
            // 
            // entranceProperty_camy
            // 
            this.entranceProperty_camy.Location = new System.Drawing.Point(204, 105);
            this.entranceProperty_camy.Name = "entranceProperty_camy";
            this.entranceProperty_camy.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_camy.TabIndex = 80;
            // 
            // entranceProperty_camx
            // 
            this.entranceProperty_camx.Location = new System.Drawing.Point(138, 105);
            this.entranceProperty_camx.Name = "entranceProperty_camx";
            this.entranceProperty_camx.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_camx.TabIndex = 79;
            // 
            // entranceProperty_ypos
            // 
            this.entranceProperty_ypos.Location = new System.Drawing.Point(72, 105);
            this.entranceProperty_ypos.Name = "entranceProperty_ypos";
            this.entranceProperty_ypos.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_ypos.TabIndex = 78;
            // 
            // entranceProperty_xpos
            // 
            this.entranceProperty_xpos.Location = new System.Drawing.Point(6, 105);
            this.entranceProperty_xpos.Name = "entranceProperty_xpos";
            this.entranceProperty_xpos.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_xpos.TabIndex = 77;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(69, 89);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(52, 13);
            this.label47.TabIndex = 76;
            this.label47.Text = "Player Y :";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(3, 89);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(52, 13);
            this.label48.TabIndex = 75;
            this.label48.Text = "Player X :";
            // 
            // entranceProperty_quadbr
            // 
            this.entranceProperty_quadbr.AutoSize = true;
            this.entranceProperty_quadbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entranceProperty_quadbr.Location = new System.Drawing.Point(210, 164);
            this.entranceProperty_quadbr.Name = "entranceProperty_quadbr";
            this.entranceProperty_quadbr.Size = new System.Drawing.Size(42, 28);
            this.entranceProperty_quadbr.TabIndex = 93;
            this.entranceProperty_quadbr.TabStop = true;
            this.entranceProperty_quadbr.Text = "◲";
            this.entranceProperty_quadbr.UseVisualStyleBackColor = true;
            // 
            // entranceProperty_quadtr
            // 
            this.entranceProperty_quadtr.AutoSize = true;
            this.entranceProperty_quadtr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entranceProperty_quadtr.Location = new System.Drawing.Point(114, 164);
            this.entranceProperty_quadtr.Name = "entranceProperty_quadtr";
            this.entranceProperty_quadtr.Size = new System.Drawing.Size(42, 28);
            this.entranceProperty_quadtr.TabIndex = 92;
            this.entranceProperty_quadtr.TabStop = true;
            this.entranceProperty_quadtr.Text = "◳";
            this.entranceProperty_quadtr.UseVisualStyleBackColor = true;
            // 
            // entranceProperty_quadbl
            // 
            this.entranceProperty_quadbl.AutoSize = true;
            this.entranceProperty_quadbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entranceProperty_quadbl.Location = new System.Drawing.Point(162, 164);
            this.entranceProperty_quadbl.Name = "entranceProperty_quadbl";
            this.entranceProperty_quadbl.Size = new System.Drawing.Size(42, 28);
            this.entranceProperty_quadbl.TabIndex = 91;
            this.entranceProperty_quadbl.TabStop = true;
            this.entranceProperty_quadbl.Text = "◱";
            this.entranceProperty_quadbl.UseVisualStyleBackColor = true;
            // 
            // entranceProperty_quadtl
            // 
            this.entranceProperty_quadtl.AutoSize = true;
            this.entranceProperty_quadtl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entranceProperty_quadtl.Location = new System.Drawing.Point(66, 164);
            this.entranceProperty_quadtl.Name = "entranceProperty_quadtl";
            this.entranceProperty_quadtl.Size = new System.Drawing.Size(42, 28);
            this.entranceProperty_quadtl.TabIndex = 90;
            this.entranceProperty_quadtl.TabStop = true;
            this.entranceProperty_quadtl.Text = "◰";
            this.entranceProperty_quadtl.UseVisualStyleBackColor = true;
            // 
            // dooryTextbox
            // 
            this.dooryTextbox.Location = new System.Drawing.Point(72, 211);
            this.dooryTextbox.Name = "dooryTextbox";
            this.dooryTextbox.Size = new System.Drawing.Size(60, 20);
            this.dooryTextbox.TabIndex = 104;
            // 
            // doorxTextbox
            // 
            this.doorxTextbox.Location = new System.Drawing.Point(6, 211);
            this.doorxTextbox.Name = "doorxTextbox";
            this.doorxTextbox.Size = new System.Drawing.Size(60, 20);
            this.doorxTextbox.TabIndex = 103;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(69, 195);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 102;
            this.label17.Text = "Door Y :";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 195);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(46, 13);
            this.label27.TabIndex = 101;
            this.label27.Text = "Door X :";
            // 
            // doorCheckbox
            // 
            this.doorCheckbox.AutoSize = true;
            this.doorCheckbox.Location = new System.Drawing.Point(138, 213);
            this.doorCheckbox.Name = "doorCheckbox";
            this.doorCheckbox.Size = new System.Drawing.Size(77, 17);
            this.doorCheckbox.TabIndex = 105;
            this.doorCheckbox.Text = "Use Door?";
            this.doorCheckbox.UseVisualStyleBackColor = true;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(206, 273);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(49, 13);
            this.label52.TabIndex = 121;
            this.label52.Text = "Edge FR";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(137, 273);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(51, 13);
            this.label53.TabIndex = 120;
            this.label53.Text = "Edge HR";
            // 
            // entranceProperty_FR
            // 
            this.entranceProperty_FR.Location = new System.Drawing.Point(206, 289);
            this.entranceProperty_FR.Name = "entranceProperty_FR";
            this.entranceProperty_FR.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_FR.TabIndex = 119;
            // 
            // entranceProperty_HR
            // 
            this.entranceProperty_HR.Location = new System.Drawing.Point(140, 289);
            this.entranceProperty_HR.Name = "entranceProperty_HR";
            this.entranceProperty_HR.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_HR.TabIndex = 118;
            // 
            // entranceProperty_FL
            // 
            this.entranceProperty_FL.Location = new System.Drawing.Point(74, 289);
            this.entranceProperty_FL.Name = "entranceProperty_FL";
            this.entranceProperty_FL.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_FL.TabIndex = 117;
            // 
            // entranceProperty_HL
            // 
            this.entranceProperty_HL.Location = new System.Drawing.Point(8, 289);
            this.entranceProperty_HL.Name = "entranceProperty_HL";
            this.entranceProperty_HL.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_HL.TabIndex = 116;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(71, 273);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(47, 13);
            this.label54.TabIndex = 115;
            this.label54.Text = "Edge FL";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(5, 273);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(49, 13);
            this.label55.TabIndex = 114;
            this.label55.Text = "Edge HL";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(206, 234);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(49, 13);
            this.label29.TabIndex = 113;
            this.label29.Text = "Edge FD";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(137, 234);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(51, 13);
            this.label49.TabIndex = 112;
            this.label49.Text = "Edge HD";
            // 
            // entranceProperty_FD
            // 
            this.entranceProperty_FD.Location = new System.Drawing.Point(206, 250);
            this.entranceProperty_FD.Name = "entranceProperty_FD";
            this.entranceProperty_FD.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_FD.TabIndex = 111;
            // 
            // entranceProperty_HD
            // 
            this.entranceProperty_HD.Location = new System.Drawing.Point(140, 250);
            this.entranceProperty_HD.Name = "entranceProperty_HD";
            this.entranceProperty_HD.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_HD.TabIndex = 110;
            // 
            // entranceProperty_FU
            // 
            this.entranceProperty_FU.Location = new System.Drawing.Point(74, 250);
            this.entranceProperty_FU.Name = "entranceProperty_FU";
            this.entranceProperty_FU.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_FU.TabIndex = 109;
            // 
            // entranceProperty_HU
            // 
            this.entranceProperty_HU.Location = new System.Drawing.Point(8, 250);
            this.entranceProperty_HU.Name = "entranceProperty_HU";
            this.entranceProperty_HU.Size = new System.Drawing.Size(60, 20);
            this.entranceProperty_HU.TabIndex = 108;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(71, 234);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(49, 13);
            this.label50.TabIndex = 107;
            this.label50.Text = "Edge FU";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(5, 234);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(51, 13);
            this.label51.TabIndex = 106;
            this.label51.Text = "Edge HU";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.mapPicturebox);
            this.panel3.Controls.Add(this.maphoverCheckbox);
            this.panel3.Controls.Add(this.mapInfosLabel);
            this.panel3.Controls.Add(this.thumbnailBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 543);
            this.panel3.TabIndex = 64;
            // 
            // mapPicturebox
            // 
            this.mapPicturebox.Location = new System.Drawing.Point(3, 6);
            this.mapPicturebox.Name = "mapPicturebox";
            this.mapPicturebox.Size = new System.Drawing.Size(256, 304);
            this.mapPicturebox.TabIndex = 61;
            this.mapPicturebox.TabStop = false;
            this.mapPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPicturebox_Paint);
            this.mapPicturebox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mapPicturebox_MouseDoubleClick_1);
            this.mapPicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPicturebox_MouseDown);
            this.mapPicturebox.MouseLeave += new System.EventHandler(this.mapPicturebox_MouseLeave);
            this.mapPicturebox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPicturebox_MouseMove);
            this.mapPicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapPicturebox_MouseUp);
            // 
            // maphoverCheckbox
            // 
            this.maphoverCheckbox.AutoSize = true;
            this.maphoverCheckbox.ForeColor = System.Drawing.Color.Black;
            this.maphoverCheckbox.Location = new System.Drawing.Point(41, 316);
            this.maphoverCheckbox.Name = "maphoverCheckbox";
            this.maphoverCheckbox.Size = new System.Drawing.Size(180, 17);
            this.maphoverCheckbox.TabIndex = 63;
            this.maphoverCheckbox.Text = "Show preview on room Hovering";
            this.maphoverCheckbox.UseVisualStyleBackColor = true;
            // 
            // mapInfosLabel
            // 
            this.mapInfosLabel.AutoSize = true;
            this.mapInfosLabel.ForeColor = System.Drawing.Color.Black;
            this.mapInfosLabel.Location = new System.Drawing.Point(11, 336);
            this.mapInfosLabel.Name = "mapInfosLabel";
            this.mapInfosLabel.Size = new System.Drawing.Size(237, 13);
            this.mapInfosLabel.TabIndex = 62;
            this.mapInfosLabel.Text = "Double click to open room, right click for preview";
            // 
            // tabControl2
            // 
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl2.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl2.HotTrack = true;
            this.tabControl2.ItemSize = new System.Drawing.Size(48, 18);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Padding = new System.Drawing.Point(3, 3);
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(603, 20);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 17;
            this.tabControl2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawOnTab);
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            this.tabControl2.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl2_Deselecting);
            this.tabControl2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl2_MouseClick);
            this.tabControl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl2_MouseDown);
            this.tabControl2.MouseEnter += new System.EventHandler(this.tabControl2_MouseEnter);
            this.tabControl2.MouseLeave += new System.EventHandler(this.tabControl2_MouseLeave);
            this.tabControl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl2_MouseMove);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(303, 196);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl2);
            this.splitContainer1.Panel1.Controls.Add(this.customPanel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2MinSize = 267;
            this.splitContainer1.Size = new System.Drawing.Size(874, 543);
            this.splitContainer1.SplitterDistance = 603;
            this.splitContainer1.TabIndex = 23;
            // 
            // customPanel3
            // 
            this.customPanel3.AutoScroll = true;
            this.customPanel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.customPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.customPanel3.Location = new System.Drawing.Point(0, 0);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(603, 543);
            this.customPanel3.TabIndex = 19;
            this.customPanel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customPanel3_MouseMove);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.objectViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 610);
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
            // 
            // customPanel1
            // 
            this.customPanel1.AutoScroll = true;
            this.customPanel1.Controls.Add(this.spritesView1);
            this.customPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel1.Location = new System.Drawing.Point(0, 20);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(292, 644);
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
            // 
            // DungeonMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1177, 761);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.headerGroupbox);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolboxPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.editorsTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DungeonMain";
            this.Text = "ZScream Magic - 2.8.7 Beta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.zscreamForm_FormClosing_1);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LocationChanged += new System.EventHandler(this.DungeonMain_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.DungeonMain_SizeChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.nothingselectedcontextMenu.ResumeLayout(false);
            this.singleselectedcontextMenu.ResumeLayout(false);
            this.groupselectedcontextMenu.ResumeLayout(false);
            this.toolboxPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.entrancetabPage.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
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
            this.headerGroupbox.ResumeLayout(false);
            this.headerGroupbox.PerformLayout();
            this.collisionMapPanel.ResumeLayout(false);
            this.collisionMapPanel.PerformLayout();
            this.selectedGroupbox.ResumeLayout(false);
            this.selectedGroupbox.PerformLayout();
            this.roomHeaderPanel.ResumeLayout(false);
            this.roomHeaderPanel.PerformLayout();
            this.doorselectPanel.ResumeLayout(false);
            this.doorselectPanel.PerformLayout();
            this.spritepropertyPanel.ResumeLayout(false);
            this.spritepropertyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritesubtypeUpDown)).EndInit();
            this.potitemobjectPanel.ResumeLayout(false);
            this.potitemobjectPanel.PerformLayout();
            this.editorsTabControl.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPicturebox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.customPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton blockmodeButton;
        private System.Windows.Forms.ToolStripButton torchmodeButton;
        private System.Windows.Forms.ToolStripButton chestmodeButton;
        private System.Windows.Forms.ToolStripButton potmodeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
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
        private System.Windows.Forms.ToolStripButton doormodeButton;
        private System.Windows.Forms.ToolStripButton saveLayoutButton;
        private System.Windows.Forms.ToolStripButton loadlayoutButton;
        private System.Windows.Forms.ToolStripMenuItem unselectedBGTransparentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editGfxToolStripMenuItem;
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
        private System.Windows.Forms.TabPage entrancetabPage;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabPage objectstabPage;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox searchspriteTextbox;
        public System.Windows.Forms.GroupBox headerGroupbox;
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
        private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hideSpritesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hideItemsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hideChestItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem selectAllMapForExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectedAllMapForExportToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
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
        public System.Windows.Forms.TextBox roomProperty_msgid;
        public System.Windows.Forms.CheckBox roomProperty_pit;
        private System.Windows.Forms.ToolStripMenuItem x8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x64ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x256ToolStripMenuItem;
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
        private System.Windows.Forms.Label label39;
        public System.Windows.Forms.TextBox entranceProperty_exit;
        public System.Windows.Forms.TextBox entranceProperty_blockset;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.CheckBox entranceProperty_bg;
        private CustomPanel panel1;
        public ObjectViewer objectViewer1;
        private System.Windows.Forms.CheckBox showNameObjectCheckbox;
        private CustomPanel customPanel1;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.ToolStripButton allbgsButton;
        public System.Windows.Forms.ToolStripButton bg2modeButton;
        public System.Windows.Forms.ToolStripButton bg3modeButton;
        public System.Windows.Forms.ToolStripButton spritemodeButton;
        public System.Windows.Forms.ToolStripButton bg1modeButton;
        public SpritesView spritesView1;
        public System.Windows.Forms.CheckBox litCheckbox;
        private System.Windows.Forms.ToolStripMenuItem patchNotesToolStripMenuItem;
        public System.Windows.Forms.CheckBox spriteoverlordCheckbox;
        private System.Windows.Forms.ToolStripMenuItem advancedChestEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDoorIDsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showChestsIDsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dungeonsPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableEntranceGFXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeMaskObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printRoomObjectsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearSelectedRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllRoomsToolStripMenuItem;
        private System.Windows.Forms.Button mouseEntranceButton;
        public System.Windows.Forms.CheckBox gridEntranceCheckbox;
        private System.Windows.Forms.ToolStripMenuItem exportAsASMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vramViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cGramViewerToolStripMenuItem;
        private System.Windows.Forms.Panel roomHeaderPanel;
        private System.Windows.Forms.ToolStripMenuItem showBG2MaskOutlineToolStripMenuItem;
        public System.Windows.Forms.PictureBox mapPicturebox;
        public System.Windows.Forms.GroupBox selectedGroupbox;
        public System.Windows.Forms.ToolStripMenuItem entranceCameraToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem entrancePositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadNamesFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gfxGroupsetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem2;
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
        private System.Windows.Forms.CheckBox maphoverCheckbox;
        private System.Windows.Forms.Label mapInfosLabel;
        public System.Windows.Forms.ToolStripButton undoButton;
        public System.Windows.Forms.ToolStripButton redoButton;
        public System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.TabPage dungeonPage;
        private System.Windows.Forms.TabPage overworldPage;
        private System.Windows.Forms.TabPage GfxEditorPage;
        private System.Windows.Forms.TabPage textPage;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsToolStripMenuItem;
        public System.Windows.Forms.TabControl editorsTabControl;
        public System.Windows.Forms.TreeView entrancetreeView;
        private System.Windows.Forms.ToolStripButton searchButton;
        private System.Windows.Forms.CheckBox favoriteCheckbox;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDungeonTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openOverwolrdTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openGfxTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllRoomsToolStripMenuItem;
        private System.Windows.Forms.TabPage ScreenEditor;
        private System.Windows.Forms.ToolStripButton debugToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem exportSpritesAsBinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllMapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importAllMapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem flipMapHorizontallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jPDebugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapDataFromJPdoNotUseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem captureMapJPdoNotUseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportMapJPdoNotUseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importFromROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapsOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importRoomToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem invisibleObjectsTextToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem overworldOverlayVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRoomsInHexToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem showMapIndexInHexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveVRAMAsPngToolStripMenuItem;
        private System.Windows.Forms.TabPage edit8x8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox edit8x8myCheckbox;
        private System.Windows.Forms.CheckBox edit8x8mxCheckbox;
        private System.Windows.Forms.PictureBox editBox8x8;
        private System.Windows.Forms.Panel edit8x8Panel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox edit8x8palettebox;
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
        private System.Windows.Forms.PictureBox thumbnailBox;
        private System.Windows.Forms.ToolStripButton collisionModeButton;
        public System.Windows.Forms.Panel collisionMapPanel;
        public System.Windows.Forms.ComboBox tileTypeCombobox;
        public System.Windows.Forms.Label collisionMapLabel;
        public System.Windows.Forms.TextBox roomProperty_stair4;
        public System.Windows.Forms.TextBox roomProperty_stair3;
        public System.Windows.Forms.TextBox roomProperty_stair1;
        public System.Windows.Forms.TextBox roomProperty_stair2;
        public System.Windows.Forms.TextBox roomProperty_hole;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ToolStripButton autodoorButton;
        public System.Windows.Forms.CheckBox bg2checkbox5;
        public System.Windows.Forms.CheckBox bg2checkbox4;
        public System.Windows.Forms.CheckBox bg2checkbox3;
        public System.Windows.Forms.CheckBox bg2checkbox2;
        public System.Windows.Forms.CheckBox bg2checkbox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label42;
        public System.Windows.Forms.CheckBox entranceProperty_vscroll;
        public System.Windows.Forms.CheckBox entranceProperty_hscroll;
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
        public System.Windows.Forms.RadioButton entranceProperty_quadbr;
        public System.Windows.Forms.RadioButton entranceProperty_quadtr;
        public System.Windows.Forms.RadioButton entranceProperty_quadbl;
        public System.Windows.Forms.RadioButton entranceProperty_quadtl;
        private System.Windows.Forms.CheckBox doorCheckbox;
        public System.Windows.Forms.TextBox dooryTextbox;
        public System.Windows.Forms.TextBox doorxTextbox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        public System.Windows.Forms.TextBox entranceProperty_FR;
        public System.Windows.Forms.TextBox entranceProperty_HR;
        public System.Windows.Forms.TextBox entranceProperty_FL;
        public System.Windows.Forms.TextBox entranceProperty_HL;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label49;
        public System.Windows.Forms.TextBox entranceProperty_FD;
        public System.Windows.Forms.TextBox entranceProperty_HD;
        public System.Windows.Forms.TextBox entranceProperty_FU;
        public System.Windows.Forms.TextBox entranceProperty_HU;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl2;
        private CustomPanel customPanel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

