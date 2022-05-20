namespace ZeldaFullEditor
{
	partial class ZScreamForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZScreamForm));
			this.updateTimer = new System.Windows.Forms.Timer(this.components);
			this.spriteImageList = new System.Windows.Forms.ImageList(this.components);
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.nothingselectedcontextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.insertToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.editorsTabControl = new System.Windows.Forms.TabControl();
			this.dungeonPage = new System.Windows.Forms.TabPage();
			this.DungeonEditor = new ZeldaFullEditor.View.PrimaryEditors.DungeonEditor();
			this.overworldPage = new System.Windows.Forms.TabPage();
			this.OverworldEditor = new ZeldaFullEditor.Gui.OverworldEditor();
			this.GfxEditorPage = new System.Windows.Forms.TabPage();
			this.textPage = new System.Windows.Forms.TabPage();
			this.TextEditor = new ZeldaFullEditor.TextEditor();
			this.ScreenEditor = new System.Windows.Forms.TabPage();
			this.spritesPage = new System.Windows.Forms.TabPage();
			this.SpriteEditor = new ZeldaFullEditor.Gui.MainTabs.SpriteEditor();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.openfileButton = new System.Windows.Forms.ToolStripButton();
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
			this.spritemodeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.blockmodeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.torchmodeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.potmodeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.doormodeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.collisionModeButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.penModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.fillModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.entranceModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.exitModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.itemModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.owSpriteModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.transportModeButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.overlayButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.gravestoneButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.debugToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.searchButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.loadlayoutButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.saveLayoutButton = new ZeldaFullEditor.DungeonToolStripButton();
			this.refreshToolStrip = new ZeldaFullEditor.OverworldToolStripButton();
			this.searchtilesButton = new ZeldaFullEditor.OverworldToolStripButton();
			this.toolStripButton3 = new ZeldaFullEditor.OverworldToolStripButton();
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
			this.overworldPage.SuspendLayout();
			this.textPage.SuspendLayout();
			this.spritesPage.SuspendLayout();
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
			this.pasteToolStripMenuItem3.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
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
			this.editorsTabControl.Enabled = false;
			this.editorsTabControl.Location = new System.Drawing.Point(0, 52);
			this.editorsTabControl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.editorsTabControl.Multiline = true;
			this.editorsTabControl.Name = "editorsTabControl";
			this.editorsTabControl.SelectedIndex = 0;
			this.editorsTabControl.Size = new System.Drawing.Size(1158, 722);
			this.editorsTabControl.TabIndex = 22;
			this.editorsTabControl.TabStop = false;
			this.editorsTabControl.SelectedIndexChanged += new System.EventHandler(this.editorsTabControl_SelectedIndexChanged);
			// 
			// dungeonPage
			// 
			this.dungeonPage.BackColor = System.Drawing.SystemColors.Control;
			this.dungeonPage.Controls.Add(this.DungeonEditor);
			this.dungeonPage.Location = new System.Drawing.Point(4, 4);
			this.dungeonPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dungeonPage.Name = "dungeonPage";
			this.dungeonPage.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dungeonPage.Size = new System.Drawing.Size(1150, 696);
			this.dungeonPage.TabIndex = 0;
			this.dungeonPage.Text = "Dungeon Editor";
			// 
			// DungeonEditor
			// 
			this.DungeonEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DungeonEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.DungeonEditor.Location = new System.Drawing.Point(2, 3);
			this.DungeonEditor.Name = "DungeonEditor";
			this.DungeonEditor.Size = new System.Drawing.Size(1146, 690);
			this.DungeonEditor.TabIndex = 0;
			// 
			// overworldPage
			// 
			this.overworldPage.Controls.Add(this.OverworldEditor);
			this.overworldPage.Location = new System.Drawing.Point(4, 4);
			this.overworldPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.overworldPage.Name = "overworldPage";
			this.overworldPage.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.overworldPage.Size = new System.Drawing.Size(1150, 694);
			this.overworldPage.TabIndex = 1;
			this.overworldPage.Text = "Overworld Editor";
			this.overworldPage.UseVisualStyleBackColor = true;
			// 
			// OverworldEditor
			// 
			this.OverworldEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OverworldEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.OverworldEditor.Location = new System.Drawing.Point(2, 3);
			this.OverworldEditor.Name = "OverworldEditor";
			this.OverworldEditor.Size = new System.Drawing.Size(1146, 688);
			this.OverworldEditor.TabIndex = 0;
			// 
			// GfxEditorPage
			// 
			this.GfxEditorPage.Location = new System.Drawing.Point(4, 4);
			this.GfxEditorPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.GfxEditorPage.Name = "GfxEditorPage";
			this.GfxEditorPage.Size = new System.Drawing.Size(1150, 694);
			this.GfxEditorPage.TabIndex = 2;
			this.GfxEditorPage.Text = "Graphics Manager";
			this.GfxEditorPage.UseVisualStyleBackColor = true;
			// 
			// textPage
			// 
			this.textPage.Controls.Add(this.TextEditor);
			this.textPage.Location = new System.Drawing.Point(4, 4);
			this.textPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.textPage.Name = "textPage";
			this.textPage.Size = new System.Drawing.Size(1150, 694);
			this.textPage.TabIndex = 4;
			this.textPage.Text = "Text Editor";
			this.textPage.UseVisualStyleBackColor = true;
			// 
			// TextEditor
			// 
			this.TextEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TextEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextEditor.Location = new System.Drawing.Point(0, 0);
			this.TextEditor.Name = "TextEditor";
			this.TextEditor.Size = new System.Drawing.Size(1150, 694);
			this.TextEditor.TabIndex = 0;
			// 
			// ScreenEditor
			// 
			this.ScreenEditor.Location = new System.Drawing.Point(4, 4);
			this.ScreenEditor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.ScreenEditor.Name = "ScreenEditor";
			this.ScreenEditor.Size = new System.Drawing.Size(1150, 694);
			this.ScreenEditor.TabIndex = 5;
			this.ScreenEditor.Text = "Screen Editor";
			this.ScreenEditor.UseVisualStyleBackColor = true;
			// 
			// spritesPage
			// 
			this.spritesPage.Controls.Add(this.SpriteEditor);
			this.spritesPage.Location = new System.Drawing.Point(4, 4);
			this.spritesPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.spritesPage.Name = "spritesPage";
			this.spritesPage.Size = new System.Drawing.Size(1150, 694);
			this.spritesPage.TabIndex = 6;
			this.spritesPage.Text = "Sprites Editor";
			this.spritesPage.UseVisualStyleBackColor = true;
			// 
			// SpriteEditor
			// 
			this.SpriteEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SpriteEditor.Location = new System.Drawing.Point(0, 0);
			this.SpriteEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.SpriteEditor.Name = "SpriteEditor";
			this.SpriteEditor.Size = new System.Drawing.Size(1150, 694);
			this.SpriteEditor.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
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
            this.potmodeButton,
            this.doormodeButton,
            this.collisionModeButton,
            this.penModeButton,
            this.fillModeButton,
            this.entranceModeButton,
            this.exitModeButton,
            this.itemModeButton,
            this.owSpriteModeButton,
            this.transportModeButton,
            this.overlayButton,
            this.gravestoneButton,
            this.toolStripSeparator3,
            this.debugToolStripButton,
            this.toolStripButton1,
            this.searchButton,
            this.loadlayoutButton,
            this.saveLayoutButton,
            this.refreshToolStrip,
            this.searchtilesButton,
            this.toolStripButton3,
            this.spButton,
            this.dwButton,
            this.lwButton});
			this.toolStrip1.Location = new System.Drawing.Point(4, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
			this.toolStrip1.Size = new System.Drawing.Size(911, 25);
			this.toolStrip1.Stretch = true;
			this.toolStrip1.TabIndex = 10;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// openfileButton
			// 
			this.openfileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openfileButton.Image = ((System.Drawing.Image)(resources.GetObject("openfileButton.Image")));
			this.openfileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openfileButton.Name = "openfileButton";
			this.openfileButton.Size = new System.Drawing.Size(23, 22);
			this.openfileButton.Text = "Open ROM…";
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
			this.allbgsButton.Tag = ZeldaFullEditor.Handler.DungeonEditMode.LayerAll;
			this.allbgsButton.Text = "All Layers";
			this.allbgsButton.Click += new System.EventHandler(this.ModeButton_Click);
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
			this.bg1modeButton.Tag = ZeldaFullEditor.Handler.DungeonEditMode.Layer1;
			this.bg1modeButton.Text = "Layer 1";
			this.bg1modeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// bg2modeButton
			// 
			this.bg2modeButton.CheckOnClick = true;
			this.bg2modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bg2modeButton.Image = ((System.Drawing.Image)(resources.GetObject("bg2modeButton.Image")));
			this.bg2modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bg2modeButton.Name = "bg2modeButton";
			this.bg2modeButton.Size = new System.Drawing.Size(23, 22);
			this.bg2modeButton.Tag = ZeldaFullEditor.Handler.DungeonEditMode.Layer2;
			this.bg2modeButton.Text = "Layer 2";
			this.bg2modeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// bg3modeButton
			// 
			this.bg3modeButton.CheckOnClick = true;
			this.bg3modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bg3modeButton.Image = ((System.Drawing.Image)(resources.GetObject("bg3modeButton.Image")));
			this.bg3modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bg3modeButton.Name = "bg3modeButton";
			this.bg3modeButton.Size = new System.Drawing.Size(23, 22);
			this.bg3modeButton.Tag = ZeldaFullEditor.Handler.DungeonEditMode.Layer3;
			this.bg3modeButton.Text = "Layer 3";
			this.bg3modeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// spritemodeButton
			// 
			this.spritemodeButton.CheckOnClick = true;
			this.spritemodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.spritemodeButton.Image = ((System.Drawing.Image)(resources.GetObject("spritemodeButton.Image")));
			this.spritemodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.spritemodeButton.Name = "spritemodeButton";
			this.spritemodeButton.Size = new System.Drawing.Size(23, 22);
			this.spritemodeButton.Tag = ZeldaFullEditor.Handler.DungeonEditMode.Sprites;
			this.spritemodeButton.Text = "Object Mode";
			this.spritemodeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// blockmodeButton
			// 
			this.blockmodeButton.CheckOnClick = true;
			this.blockmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.blockmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("blockmodeButton.Image")));
			this.blockmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.blockmodeButton.Name = "blockmodeButton";
			this.blockmodeButton.Size = new System.Drawing.Size(23, 22);
			this.blockmodeButton.Tag = ZeldaFullEditor.Handler.DungeonEditMode.Blocks;
			this.blockmodeButton.Text = "Block Mode";
			this.blockmodeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// torchmodeButton
			// 
			this.torchmodeButton.CheckOnClick = true;
			this.torchmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.torchmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("torchmodeButton.Image")));
			this.torchmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.torchmodeButton.Name = "torchmodeButton";
			this.torchmodeButton.Size = new System.Drawing.Size(23, 22);
			this.torchmodeButton.Tag = ZeldaFullEditor.Handler.DungeonEditMode.Torches;
			this.torchmodeButton.Text = "Torch Mode";
			this.torchmodeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// potmodeButton
			// 
			this.potmodeButton.CheckOnClick = true;
			this.potmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.potmodeButton.Image = ((System.Drawing.Image)(resources.GetObject("potmodeButton.Image")));
			this.potmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.potmodeButton.Name = "potmodeButton";
			this.potmodeButton.Size = new System.Drawing.Size(23, 22);
			this.potmodeButton.Tag = ZeldaFullEditor.Handler.DungeonEditMode.Secrets;
			this.potmodeButton.Text = "Secrets Mode";
			this.potmodeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// doormodeButton
			// 
			this.doormodeButton.CheckOnClick = true;
			this.doormodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.doormodeButton.Image = ((System.Drawing.Image)(resources.GetObject("doormodeButton.Image")));
			this.doormodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.doormodeButton.Name = "doormodeButton";
			this.doormodeButton.Size = new System.Drawing.Size(23, 22);
			this.doormodeButton.Tag = ZeldaFullEditor.Handler.DungeonEditMode.Doors;
			this.doormodeButton.Text = "Door Mode";
			this.doormodeButton.Click += new System.EventHandler(this.ModeButton_Click);
			// 
			// collisionModeButton
			// 
			this.collisionModeButton.CheckOnClick = true;
			this.collisionModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.collisionModeButton.Image = ((System.Drawing.Image)(resources.GetObject("collisionModeButton.Image")));
			this.collisionModeButton.ImageTransparentColor = System.Drawing.Color.White;
			this.collisionModeButton.Name = "collisionModeButton";
			this.collisionModeButton.Size = new System.Drawing.Size(23, 22);
			this.collisionModeButton.Tag = ZeldaFullEditor.Handler.DungeonEditMode.CollisionMap;
			this.collisionModeButton.Text = "Collision Mode";
			this.collisionModeButton.Click += new System.EventHandler(this.ModeButton_Click);
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
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Enabled = false;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "Export Selected Rooms as PNG";
			this.toolStripButton1.ToolTipText = "Export map as png; Hold control and double click on the rooms you want to export." +
    "";
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
			// loadlayoutButton
			// 
			this.loadlayoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.loadlayoutButton.Image = ((System.Drawing.Image)(resources.GetObject("loadlayoutButton.Image")));
			this.loadlayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.loadlayoutButton.Name = "loadlayoutButton";
			this.loadlayoutButton.Size = new System.Drawing.Size(23, 22);
			this.loadlayoutButton.Text = "Load Layout…";
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
			// refreshToolStrip
			// 
			this.refreshToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.refreshToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStrip.Image")));
			this.refreshToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.refreshToolStrip.Name = "refreshToolStrip";
			this.refreshToolStrip.Size = new System.Drawing.Size(82, 22);
			this.refreshToolStrip.Text = "Refresh maps";
			// 
			// searchtilesButton
			// 
			this.searchtilesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.searchtilesButton.Image = ((System.Drawing.Image)(resources.GetObject("searchtilesButton.Image")));
			this.searchtilesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.searchtilesButton.Name = "searchtilesButton";
			this.searchtilesButton.Size = new System.Drawing.Size(23, 22);
			this.searchtilesButton.Text = "Search for tiles";
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(65, 22);
			this.toolStripButton3.Text = "Clear map";
			this.toolStripButton3.Visible = false;
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
			this.statusStrip1.Location = new System.Drawing.Point(308, 777);
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
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
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
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.redoToolStripMenuItem.Text = "Redo";
			this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
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
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Enabled = false;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Enabled = false;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Enabled = false;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
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
			this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
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
            this.invisibleObjectsTextToolStripMenuItem});
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
			this.roomProperty_bg2.Location = new System.Drawing.Point(0, 0);
			this.roomProperty_bg2.Name = "roomProperty_bg2";
			this.roomProperty_bg2.Size = new System.Drawing.Size(121, 23);
			this.roomProperty_bg2.TabIndex = 0;
			// 
			// DungeonMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1157, 800);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.editorsTabControl);
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
			this.overworldPage.ResumeLayout(false);
			this.textPage.ResumeLayout(false);
			this.spritesPage.ResumeLayout(false);
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
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel SelectedObjectNameLabel;
		private ToolStripStatusLabel SelectedObjectXLabel;
		private ToolStripStatusLabel SelectedObjectYLabel;
		private ToolStripStatusLabel SelectedObjectLayerLabel;
		private ToolStripStatusLabel SelectedObjectSizeLabel;
		private ToolStripStatusLabel SelectedObjectDataLabel;
		private ToolStrip toolStrip1;
		private ToolStripButton openfileButton;
		private ToolStripButton saveButton;
		private ToolStripButton debugtestButton;
		private ToolStripButton runtestButton;
		private ToolStripSeparator toolStripSeparator1;
		public ToolStripButton undoButton;
		public ToolStripButton redoButton;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripButton toolStripButton1;
		private ToolStripButton debugToolStripButton;
		public DungeonToolStripButton allbgsButton;
		public DungeonToolStripButton bg1modeButton;
		public DungeonToolStripButton bg2modeButton;
		public DungeonToolStripButton bg3modeButton;
		public DungeonToolStripButton spritemodeButton;
		public DungeonToolStripButton blockmodeButton;
		public DungeonToolStripButton torchmodeButton;
		public DungeonToolStripButton potmodeButton;
		public DungeonToolStripButton doormodeButton;
		public DungeonToolStripButton collisionModeButton;
		private DungeonToolStripButton saveLayoutButton;
		private DungeonToolStripButton loadlayoutButton;
		private DungeonToolStripButton searchButton;
		private OverworldToolStripButton penModeButton;
		private OverworldToolStripButton fillModeButton;
		private OverworldToolStripButton entranceModeButton;
		private OverworldToolStripButton exitModeButton;
		private OverworldToolStripButton itemModeButton;
		private OverworldToolStripButton owSpriteModeButton;
		private OverworldToolStripButton transportModeButton;
		private OverworldToolStripButton overlayButton;
		private OverworldToolStripButton gravestoneButton;
		private OverworldToolStripButton searchtilesButton;
		private OverworldToolStripButton refreshToolStrip;
		private OverworldToolStripButton toolStripButton3;
		private OverworldToolStripButton lwButton;
		private OverworldToolStripButton dwButton;
		private OverworldToolStripButton spButton;
		internal OverworldEditor OverworldEditor;
		internal TextEditor TextEditor;
		internal DungeonEditor DungeonEditor;
		internal SpriteEditor SpriteEditor;
	}
}

