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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DungeonMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Entrances");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Spawn points");
            updateTimer = new System.Windows.Forms.Timer(components);
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            openfileButton = new System.Windows.Forms.ToolStripButton();
            saveButton = new System.Windows.Forms.ToolStripButton();
            debugtestButton = new System.Windows.Forms.ToolStripButton();
            runtestButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            undoButton = new System.Windows.Forms.ToolStripButton();
            redoButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            allbgsButton = new System.Windows.Forms.ToolStripButton();
            bg1modeButton = new System.Windows.Forms.ToolStripButton();
            bg2modeButton = new System.Windows.Forms.ToolStripButton();
            bg3modeButton = new System.Windows.Forms.ToolStripButton();
            spritemodeButton = new System.Windows.Forms.ToolStripButton();
            blockmodeButton = new System.Windows.Forms.ToolStripButton();
            torchmodeButton = new System.Windows.Forms.ToolStripButton();
            chestmodeButton = new System.Windows.Forms.ToolStripButton();
            potmodeButton = new System.Windows.Forms.ToolStripButton();
            doormodeButton = new System.Windows.Forms.ToolStripButton();
            warpmodeButton = new System.Windows.Forms.ToolStripButton();
            collisionModeButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            saveLayoutButton = new System.Windows.Forms.ToolStripButton();
            loadlayoutButton = new System.Windows.Forms.ToolStripButton();
            searchButton = new System.Windows.Forms.ToolStripButton();
            toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            debugToolStripButton = new System.Windows.Forms.ToolStripButton();
            spriteImageList = new System.Windows.Forms.ImageList(components);
            colorDialog1 = new System.Windows.Forms.ColorDialog();
            nothingselectedcontextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            insertToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            singleselectedcontextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            increaseZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            bringToFrontToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            increaseZBy1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            decreaseZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sendToBackToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            decreaseZBy1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sendToBg1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sendToBg1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            sendToBg1ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            editGfxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            groupselectedcontextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            insertToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            cutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            bringToFrontToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            sendToBackToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            sendToBg1ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            sendToBg1ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            sendToBg1ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            roomProperty_sortsprite = new System.Windows.Forms.CheckBox();
            EntranceProperties_Music = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            toolboxPanel = new System.Windows.Forms.Panel();
            tabControl1 = new System.Windows.Forms.TabControl();
            entrancetabPage = new System.Windows.Forms.TabPage();
            splitContainer3 = new System.Windows.Forms.SplitContainer();
            panel2 = new System.Windows.Forms.Panel();
            dooryHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            doorxHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            facedownCheckbox = new System.Windows.Forms.CheckBox();
            EntranceProperties_FloorSel = new System.Windows.Forms.ComboBox();
            EntranceProperties_Blockset = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperties_DungeonID = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperties_CameraTriggerY = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperties_CameraTriggerX = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            label46 = new System.Windows.Forms.Label();
            label45 = new System.Windows.Forms.Label();
            EntranceProperties_CameraX = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperties_CameraY = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperties_PlayerY = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperties_PlayerX = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            label41 = new System.Windows.Forms.Label();
            label38 = new System.Windows.Forms.Label();
            EntranceProperties_RoomID = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            EntranceProperty_BoundaryFE = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperty_BoundaryFW = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperty_BoundaryQE = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperty_BoundaryQW = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperty_BoundaryFS = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperty_BoundaryFN = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperty_BoundaryQS = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            EntranceProperty_BoundaryQN = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            label37 = new System.Windows.Forms.Label();
            label36 = new System.Windows.Forms.Label();
            label35 = new System.Windows.Forms.Label();
            label34 = new System.Windows.Forms.Label();
            label32 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            doorCheckbox = new System.Windows.Forms.CheckBox();
            label27 = new System.Windows.Forms.Label();
            entranceProperty_quadbr = new System.Windows.Forms.RadioButton();
            entranceProperty_quadtr = new System.Windows.Forms.RadioButton();
            entranceProperty_quadbl = new System.Windows.Forms.RadioButton();
            entranceProperty_quadtl = new System.Windows.Forms.RadioButton();
            label42 = new System.Windows.Forms.Label();
            entranceProperty_vscroll = new System.Windows.Forms.CheckBox();
            entranceProperty_hscroll = new System.Windows.Forms.CheckBox();
            label44 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            gridEntranceCheckbox = new System.Windows.Forms.CheckBox();
            label21 = new System.Windows.Forms.Label();
            mouseEntranceButton = new System.Windows.Forms.Button();
            entranceProperty_bg = new System.Windows.Forms.CheckBox();
            label22 = new System.Windows.Forms.Label();
            label40 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            entrancetreeView = new System.Windows.Forms.TreeView();
            objectstabPage = new System.Windows.Forms.TabPage();
            panel1 = new CustomPanel();
            objectViewer1 = new ObjectViewer();
            favoriteCheckbox = new System.Windows.Forms.CheckBox();
            showNameObjectCheckbox = new System.Windows.Forms.CheckBox();
            searchTextbox = new System.Windows.Forms.TextBox();
            tabPage4 = new System.Windows.Forms.TabPage();
            customPanel1 = new CustomPanel();
            panel4 = new System.Windows.Forms.Panel();
            spritesView1 = new SpritesView();
            searchspriteTextbox = new System.Windows.Forms.TextBox();
            edit8x8 = new System.Windows.Forms.TabPage();
            edit8x8Panel = new System.Windows.Forms.Panel();
            editBox8x8 = new System.Windows.Forms.PictureBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            edit8x8palettebox = new System.Windows.Forms.PictureBox();
            edit8x8myCheckbox = new System.Windows.Forms.CheckBox();
            edit8x8mxCheckbox = new System.Windows.Forms.CheckBox();
            label20 = new System.Windows.Forms.Label();
            roomProperty_pit = new System.Windows.Forms.CheckBox();
            roomProperty_tag2 = new System.Windows.Forms.ComboBox();
            label12 = new System.Windows.Forms.Label();
            roomProperty_tag1 = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            roomProperty_effect = new System.Windows.Forms.ComboBox();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            roomProperty_collision = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            roomProperty_bg2 = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            splitter1 = new System.Windows.Forms.Splitter();
            headerGroupbox = new System.Windows.Forms.GroupBox();
            overlayPanel = new System.Windows.Forms.Panel();
            overlayCombobox = new System.Windows.Forms.ComboBox();
            label39 = new System.Windows.Forms.Label();
            selectedGroupbox = new System.Windows.Forms.GroupBox();
            SelectedObjectDataHEX = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            SelectedObjectDataLayer = new System.Windows.Forms.Label();
            SelectedObjectDataSize = new System.Windows.Forms.Label();
            SelectedObjectDataY = new System.Windows.Forms.Label();
            SelectedObjectDataX = new System.Windows.Forms.Label();
            object_size_label = new System.Windows.Forms.Label();
            object_x_label = new System.Windows.Forms.Label();
            object_y_label = new System.Windows.Forms.Label();
            object_layer_label = new System.Windows.Forms.Label();
            roomHeaderPanel = new System.Windows.Forms.Panel();
            RoomProperty_DestinationStair4 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            RoomProperty_DestinationStair3 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            RoomProperty_DestinationStair2 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            RoomProperty_DestinationStair1 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            RoomProperty_DestinationPit = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            RoomProperty_MessageID = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            RoomProperty_SpriteSet = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            RoomProperty_Palette = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            RoomProperty_Floor2 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            RoomProperty_Floor1 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            RoomProperty_Blockset = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            RoomProperty_Layout = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            label16 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            bg2checkbox5 = new System.Windows.Forms.CheckBox();
            label33 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            bg2checkbox4 = new System.Windows.Forms.CheckBox();
            bg2checkbox3 = new System.Windows.Forms.CheckBox();
            bg2checkbox2 = new System.Windows.Forms.CheckBox();
            bg2checkbox1 = new System.Windows.Forms.CheckBox();
            litCheckbox = new System.Windows.Forms.CheckBox();
            doorselectPanel = new System.Windows.Forms.Panel();
            comboBox2 = new System.Windows.Forms.ComboBox();
            label25 = new System.Windows.Forms.Label();
            potitemobjectPanel = new System.Windows.Forms.Panel();
            selecteditemobjectCombobox = new System.Windows.Forms.ComboBox();
            label31 = new System.Windows.Forms.Label();
            spritepropertyPanel = new System.Windows.Forms.Panel();
            spriteoverlordCheckbox = new System.Windows.Forms.CheckBox();
            label26 = new System.Windows.Forms.Label();
            spritesubtypeUpDown = new System.Windows.Forms.NumericUpDown();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label23 = new System.Windows.Forms.Label();
            collisionMapPanel = new System.Windows.Forms.Panel();
            tileTypeCombobox = new System.Windows.Forms.ComboBox();
            collisionMapLabel = new System.Windows.Forms.Label();
            x256ToolStripMenuItemOW = new System.Windows.Forms.ToolStripMenuItem();
            uploadVanillaCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editorsTabControl = new System.Windows.Forms.TabControl();
            dungeonPage = new System.Windows.Forms.TabPage();
            overworldPage = new System.Windows.Forms.TabPage();
            GfxEditorPage = new System.Windows.Forms.TabPage();
            textPage = new System.Windows.Forms.TabPage();
            ScreenEditor = new System.Windows.Forms.TabPage();
            MusicEditor = new System.Windows.Forms.TabPage();
            SpriteEditor = new System.Windows.Forms.TabPage();
            NamingEditor = new System.Windows.Forms.TabPage();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            recentROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToNewROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            buildROMwithASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            moveFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            bringToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            decreaseObjectSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            increaseObjectSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            selectAllRoomsForExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deselectedAllRoomsForExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            lockoverworldToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            loadNamesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            memoryManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            applyFastROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            debugRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            roomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            gotoRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            removeMaskObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printRoomObjectsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            clearSelectedRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearAllRoomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportAsASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportAllRoomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportSpritesAsBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showRoomsInHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            selectedObjectInHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            autoDoorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportSelectedRoomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importDungeonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dungeonViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            darkThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            x8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            x16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            x32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            x64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            x256ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showMapIndexInHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            xScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            showBG1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showBG2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            unselectedBGTransparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showBG2MaskOutlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            hideSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            boxesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            graphicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            hideItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            hideChestItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            textSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            textChestItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            invisibleObjectsTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            textPotItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            showSpriteIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showChestsIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showDoorIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showStairIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            disableEntranceGFXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            entrancePositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            entranceCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rightSideToolboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            naviguateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moveToRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moveToLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moveToUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moveToDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            openRightRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openLeftRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openUpRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openDownRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            overworldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveZeldaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            zeldaSavedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            agahDeadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearEntrancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearAllHolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearExitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearAllOverlaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            exportAllTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importAllTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            clearDWTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyLWToDWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showTiles32CountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showUniqueTile32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            setUnusedTiles16ToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            areaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearSpritesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            saveZeldaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            zeldaSavedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            agahDeadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            clearItemsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            clearEntrancesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            clearHolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearExitsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            clearOverlaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportOverlayAsASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportOverlayAnimationAsASMInClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            overworldViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showEntrancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showExitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showTransportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showEntranceExitPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showGravesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            overworldOverlayVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showGridToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            x8ToolStripMenuItemOW = new System.Windows.Forms.ToolStripMenuItem();
            x16ToolStripMenuItemOW = new System.Windows.Forms.ToolStripMenuItem();
            x32ToolStripMenuItemOW = new System.Windows.Forms.ToolStripMenuItem();
            noneToolStripMenuItemOW = new System.Windows.Forms.ToolStripMenuItem();
            useAreaSpecificBGColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showScratchPadGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showOverlayTextsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            vramViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            cGramViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            gfxGroupsetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            palettesEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            jPDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mapDataFromJPdoNotUseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            captureMapJPdoNotUseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            exportMapJPdoNotUseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ExperimentalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            flipMapHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveMapsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveVRAMAsPngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moveRoomsToOtherROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportImageMapMultipleROMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            generatePaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            useExpandedOWPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            patchNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            godownButton = new System.Windows.Forms.Button();
            goleftButton = new System.Windows.Forms.Button();
            gorightButton = new System.Windows.Forms.Button();
            goupButton = new System.Windows.Forms.Button();
            panel3 = new System.Windows.Forms.Panel();
            panel5 = new System.Windows.Forms.Panel();
            hexbox4 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            hexbox3 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            hexbox2 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            hexbox1 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            thumbnailBox = new System.Windows.Forms.PictureBox();
            warningLabel = new System.Windows.Forms.Label();
            mapPicturebox = new System.Windows.Forms.PictureBox();
            maphoverCheckbox = new System.Windows.Forms.CheckBox();
            mapInfosLabel = new System.Windows.Forms.Label();
            DunRoomTabControl = new System.Windows.Forms.TabControl();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            customPanel3 = new CustomPanel();
            networkBgWorker = new System.ComponentModel.BackgroundWorker();
            networkBgWorker2 = new System.ComponentModel.BackgroundWorker();
            loadTimer = new System.Windows.Forms.Timer(components);
            crc32timer = new System.Windows.Forms.Timer(components);
            exportPNGTimer = new System.Windows.Forms.Timer(components);
            toolStrip1.SuspendLayout();
            nothingselectedcontextMenu.SuspendLayout();
            singleselectedcontextMenu.SuspendLayout();
            groupselectedcontextMenu.SuspendLayout();
            toolboxPanel.SuspendLayout();
            tabControl1.SuspendLayout();
            entrancetabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            objectstabPage.SuspendLayout();
            panel1.SuspendLayout();
            tabPage4.SuspendLayout();
            customPanel1.SuspendLayout();
            panel4.SuspendLayout();
            edit8x8.SuspendLayout();
            edit8x8Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)editBox8x8).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)edit8x8palettebox).BeginInit();
            headerGroupbox.SuspendLayout();
            overlayPanel.SuspendLayout();
            selectedGroupbox.SuspendLayout();
            roomHeaderPanel.SuspendLayout();
            doorselectPanel.SuspendLayout();
            potitemobjectPanel.SuspendLayout();
            spritepropertyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spritesubtypeUpDown).BeginInit();
            collisionMapPanel.SuspendLayout();
            editorsTabControl.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)thumbnailBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mapPicturebox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { openfileButton, saveButton, debugtestButton, runtestButton, toolStripSeparator1, undoButton, redoButton, toolStripSeparator2, allbgsButton, bg1modeButton, bg2modeButton, bg3modeButton, spritemodeButton, blockmodeButton, torchmodeButton, chestmodeButton, potmodeButton, doormodeButton, warpmodeButton, collisionModeButton, toolStripSeparator3, saveLayoutButton, loadlayoutButton, searchButton, toolStripButton1, debugToolStripButton });
            toolStrip1.Location = new System.Drawing.Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(1373, 25);
            toolStrip1.TabIndex = 9;
            toolStrip1.Text = "toolStrip1";
            // 
            // openfileButton
            // 
            openfileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            openfileButton.Image = (System.Drawing.Image)resources.GetObject("openfileButton.Image");
            openfileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            openfileButton.Name = "openfileButton";
            openfileButton.Size = new System.Drawing.Size(23, 22);
            openfileButton.Text = "Open ROM…";
            openfileButton.Click += OpenToolStripMenuItem_Click;
            // 
            // saveButton
            // 
            saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            saveButton.Enabled = false;
            saveButton.Image = (System.Drawing.Image)resources.GetObject("saveButton.Image");
            saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(23, 22);
            saveButton.Text = "Save ROM";
            saveButton.Click += SaveToolStripMenuItem_Click;
            // 
            // debugtestButton
            // 
            debugtestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            debugtestButton.Enabled = false;
            debugtestButton.Image = (System.Drawing.Image)resources.GetObject("debugtestButton.Image");
            debugtestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            debugtestButton.Name = "debugtestButton";
            debugtestButton.Size = new System.Drawing.Size(23, 22);
            debugtestButton.Text = "Save and Debug in Emulator";
            debugtestButton.Click += debugtestButton_Click;
            // 
            // runtestButton
            // 
            runtestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            runtestButton.Enabled = false;
            runtestButton.Image = (System.Drawing.Image)resources.GetObject("runtestButton.Image");
            runtestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            runtestButton.Name = "runtestButton";
            runtestButton.Size = new System.Drawing.Size(23, 22);
            runtestButton.Text = "Save and Run in Emulator";
            runtestButton.Click += runtestButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // undoButton
            // 
            undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            undoButton.Enabled = false;
            undoButton.Image = (System.Drawing.Image)resources.GetObject("undoButton.Image");
            undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            undoButton.Name = "undoButton";
            undoButton.Size = new System.Drawing.Size(23, 22);
            undoButton.Text = "Undo";
            undoButton.Click += undoButton_Click;
            // 
            // redoButton
            // 
            redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            redoButton.Enabled = false;
            redoButton.Image = (System.Drawing.Image)resources.GetObject("redoButton.Image");
            redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            redoButton.Name = "redoButton";
            redoButton.Size = new System.Drawing.Size(23, 22);
            redoButton.Text = "Redo";
            redoButton.Click += redoButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // allbgsButton
            // 
            allbgsButton.CheckOnClick = true;
            allbgsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            allbgsButton.Enabled = false;
            allbgsButton.Image = (System.Drawing.Image)resources.GetObject("allbgsButton.Image");
            allbgsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            allbgsButton.Name = "allbgsButton";
            allbgsButton.Size = new System.Drawing.Size(23, 22);
            allbgsButton.Text = "All Layers";
            allbgsButton.Click += Update_modes_buttons;
            // 
            // bg1modeButton
            // 
            bg1modeButton.Checked = true;
            bg1modeButton.CheckOnClick = true;
            bg1modeButton.CheckState = System.Windows.Forms.CheckState.Checked;
            bg1modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            bg1modeButton.Enabled = false;
            bg1modeButton.Image = (System.Drawing.Image)resources.GetObject("bg1modeButton.Image");
            bg1modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            bg1modeButton.Name = "bg1modeButton";
            bg1modeButton.Size = new System.Drawing.Size(23, 22);
            bg1modeButton.Text = "Layer 1";
            bg1modeButton.Click += Update_modes_buttons;
            // 
            // bg2modeButton
            // 
            bg2modeButton.CheckOnClick = true;
            bg2modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            bg2modeButton.Enabled = false;
            bg2modeButton.Image = (System.Drawing.Image)resources.GetObject("bg2modeButton.Image");
            bg2modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            bg2modeButton.Name = "bg2modeButton";
            bg2modeButton.Size = new System.Drawing.Size(23, 22);
            bg2modeButton.Text = "Layer 2";
            bg2modeButton.Click += Update_modes_buttons;
            // 
            // bg3modeButton
            // 
            bg3modeButton.CheckOnClick = true;
            bg3modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            bg3modeButton.Enabled = false;
            bg3modeButton.Image = (System.Drawing.Image)resources.GetObject("bg3modeButton.Image");
            bg3modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            bg3modeButton.Name = "bg3modeButton";
            bg3modeButton.Size = new System.Drawing.Size(23, 22);
            bg3modeButton.Text = "Layer 3";
            bg3modeButton.Click += Update_modes_buttons;
            // 
            // spritemodeButton
            // 
            spritemodeButton.CheckOnClick = true;
            spritemodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            spritemodeButton.Enabled = false;
            spritemodeButton.Image = (System.Drawing.Image)resources.GetObject("spritemodeButton.Image");
            spritemodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            spritemodeButton.Name = "spritemodeButton";
            spritemodeButton.Size = new System.Drawing.Size(23, 22);
            spritemodeButton.Text = "Object Mode";
            spritemodeButton.Click += Update_modes_buttons;
            // 
            // blockmodeButton
            // 
            blockmodeButton.CheckOnClick = true;
            blockmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            blockmodeButton.Enabled = false;
            blockmodeButton.Image = (System.Drawing.Image)resources.GetObject("blockmodeButton.Image");
            blockmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            blockmodeButton.Name = "blockmodeButton";
            blockmodeButton.Size = new System.Drawing.Size(23, 22);
            blockmodeButton.Text = "Block Mode";
            blockmodeButton.Click += Update_modes_buttons;
            // 
            // torchmodeButton
            // 
            torchmodeButton.CheckOnClick = true;
            torchmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            torchmodeButton.Enabled = false;
            torchmodeButton.Image = (System.Drawing.Image)resources.GetObject("torchmodeButton.Image");
            torchmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            torchmodeButton.Name = "torchmodeButton";
            torchmodeButton.Size = new System.Drawing.Size(23, 22);
            torchmodeButton.Text = "Torch Mode";
            torchmodeButton.Click += Update_modes_buttons;
            // 
            // chestmodeButton
            // 
            chestmodeButton.CheckOnClick = true;
            chestmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            chestmodeButton.Enabled = false;
            chestmodeButton.Image = (System.Drawing.Image)resources.GetObject("chestmodeButton.Image");
            chestmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            chestmodeButton.Name = "chestmodeButton";
            chestmodeButton.Size = new System.Drawing.Size(23, 22);
            chestmodeButton.Text = "Chest Mode";
            chestmodeButton.Click += Update_modes_buttons;
            // 
            // potmodeButton
            // 
            potmodeButton.CheckOnClick = true;
            potmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            potmodeButton.Enabled = false;
            potmodeButton.Image = (System.Drawing.Image)resources.GetObject("potmodeButton.Image");
            potmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            potmodeButton.Name = "potmodeButton";
            potmodeButton.Size = new System.Drawing.Size(23, 22);
            potmodeButton.Text = "Pot Item Mode";
            potmodeButton.Click += Update_modes_buttons;
            // 
            // doormodeButton
            // 
            doormodeButton.CheckOnClick = true;
            doormodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            doormodeButton.Enabled = false;
            doormodeButton.Image = (System.Drawing.Image)resources.GetObject("doormodeButton.Image");
            doormodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            doormodeButton.Name = "doormodeButton";
            doormodeButton.Size = new System.Drawing.Size(23, 22);
            doormodeButton.Text = "Door Mode";
            doormodeButton.Click += Update_modes_buttons;
            // 
            // warpmodeButton
            // 
            warpmodeButton.CheckOnClick = true;
            warpmodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            warpmodeButton.Enabled = false;
            warpmodeButton.Image = (System.Drawing.Image)resources.GetObject("warpmodeButton.Image");
            warpmodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            warpmodeButton.Name = "warpmodeButton";
            warpmodeButton.Size = new System.Drawing.Size(23, 22);
            warpmodeButton.Text = "Destination Mode";
            warpmodeButton.Click += Update_modes_buttons;
            // 
            // collisionModeButton
            // 
            collisionModeButton.CheckOnClick = true;
            collisionModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            collisionModeButton.Enabled = false;
            collisionModeButton.Image = (System.Drawing.Image)resources.GetObject("collisionModeButton.Image");
            collisionModeButton.ImageTransparentColor = System.Drawing.Color.White;
            collisionModeButton.Name = "collisionModeButton";
            collisionModeButton.Size = new System.Drawing.Size(23, 22);
            collisionModeButton.Text = "Collision Mode";
            collisionModeButton.Click += Update_modes_buttons;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // saveLayoutButton
            // 
            saveLayoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            saveLayoutButton.Enabled = false;
            saveLayoutButton.Image = (System.Drawing.Image)resources.GetObject("saveLayoutButton.Image");
            saveLayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveLayoutButton.Name = "saveLayoutButton";
            saveLayoutButton.Size = new System.Drawing.Size(23, 22);
            saveLayoutButton.Text = "Save Layout";
            saveLayoutButton.Click += saveLayoutButton_Click;
            // 
            // loadlayoutButton
            // 
            loadlayoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            loadlayoutButton.Enabled = false;
            loadlayoutButton.Image = (System.Drawing.Image)resources.GetObject("loadlayoutButton.Image");
            loadlayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            loadlayoutButton.Name = "loadlayoutButton";
            loadlayoutButton.Size = new System.Drawing.Size(23, 22);
            loadlayoutButton.Text = "Load Layout…";
            loadlayoutButton.Click += loadlayoutButton_Click;
            // 
            // searchButton
            // 
            searchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            searchButton.Enabled = false;
            searchButton.Image = (System.Drawing.Image)resources.GetObject("searchButton.Image");
            searchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            searchButton.Name = "searchButton";
            searchButton.Size = new System.Drawing.Size(23, 22);
            searchButton.Text = "toolStripButton2";
            searchButton.Click += SearchButton_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButton1.Enabled = false;
            toolStripButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new System.Drawing.Size(23, 22);
            toolStripButton1.Text = "Export Selected Rooms As PNG";
            toolStripButton1.ToolTipText = "Export map as png; Hold control and double click on the rooms you want to export.";
            toolStripButton1.Click += ExportDungeonPNGToolStripClick;
            // 
            // debugToolStripButton
            // 
            debugToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            debugToolStripButton.Enabled = false;
            debugToolStripButton.Image = (System.Drawing.Image)resources.GetObject("debugToolStripButton.Image");
            debugToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            debugToolStripButton.Name = "debugToolStripButton";
            debugToolStripButton.Size = new System.Drawing.Size(23, 22);
            debugToolStripButton.Text = "Debug";
            // 
            // spriteImageList
            // 
            spriteImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            spriteImageList.ImageSize = new System.Drawing.Size(32, 32);
            spriteImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // nothingselectedcontextMenu
            // 
            nothingselectedcontextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { insertToolStripMenuItem1, pasteToolStripMenuItem3, deleteToolStripMenuItem2, clearAllToolStripMenuItem });
            nothingselectedcontextMenu.Name = "nothingselectedcontextMenu";
            nothingselectedcontextMenu.Size = new System.Drawing.Size(125, 92);
            // 
            // insertToolStripMenuItem1
            // 
            insertToolStripMenuItem1.Name = "insertToolStripMenuItem1";
            insertToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            insertToolStripMenuItem1.Text = "Insert";
            insertToolStripMenuItem1.Click += InsertToolStripMenuItem1_Click;
            // 
            // pasteToolStripMenuItem3
            // 
            pasteToolStripMenuItem3.Name = "pasteToolStripMenuItem3";
            pasteToolStripMenuItem3.Size = new System.Drawing.Size(124, 22);
            pasteToolStripMenuItem3.Text = "Paste";
            pasteToolStripMenuItem3.Click += PasteToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem2
            // 
            deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            deleteToolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            deleteToolStripMenuItem2.Text = "Delete";
            deleteToolStripMenuItem2.Click += DeleteToolStripMenuItem2_Click;
            // 
            // clearAllToolStripMenuItem
            // 
            clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            clearAllToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            clearAllToolStripMenuItem.Text = "Delete All";
            clearAllToolStripMenuItem.Click += ClearAllToolStripMenuItem_Click;
            // 
            // singleselectedcontextMenu
            // 
            singleselectedcontextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { insertToolStripMenuItem, cutToolStripMenuItem1, copyToolStripMenuItem1, pasteToolStripMenuItem1, deleteToolStripMenuItem1, increaseZToolStripMenuItem, decreaseZToolStripMenuItem, sendToBg1ToolStripMenuItem, sendToBg1ToolStripMenuItem1, sendToBg1ToolStripMenuItem2, editGfxToolStripMenuItem });
            singleselectedcontextMenu.Name = "nothingselectedcontextMenu";
            singleselectedcontextMenu.Size = new System.Drawing.Size(155, 246);
            // 
            // insertToolStripMenuItem
            // 
            insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            insertToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            insertToolStripMenuItem.Text = "Insert";
            insertToolStripMenuItem.Click += InsertToolStripMenuItem_Click_1;
            // 
            // cutToolStripMenuItem1
            // 
            cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            cutToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            cutToolStripMenuItem1.Text = "Cut";
            cutToolStripMenuItem1.Click += CutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem1
            // 
            copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            copyToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            copyToolStripMenuItem1.Text = "Copy";
            copyToolStripMenuItem1.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem1
            // 
            pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            pasteToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            pasteToolStripMenuItem1.Text = "Paste";
            pasteToolStripMenuItem1.Click += PasteToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem1
            // 
            deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            deleteToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            deleteToolStripMenuItem1.Text = "Delete";
            deleteToolStripMenuItem1.Click += DeleteToolStripMenuItem_Click;
            // 
            // increaseZToolStripMenuItem
            // 
            increaseZToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { bringToFrontToolStripMenuItem2, increaseZBy1ToolStripMenuItem });
            increaseZToolStripMenuItem.Name = "increaseZToolStripMenuItem";
            increaseZToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            increaseZToolStripMenuItem.Text = "Increase Z";
            // 
            // bringToFrontToolStripMenuItem2
            // 
            bringToFrontToolStripMenuItem2.Name = "bringToFrontToolStripMenuItem2";
            bringToFrontToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            bringToFrontToolStripMenuItem2.Text = "Send to Front";
            bringToFrontToolStripMenuItem2.Click += SendSelectedToFront;
            // 
            // increaseZBy1ToolStripMenuItem
            // 
            increaseZBy1ToolStripMenuItem.Enabled = false;
            increaseZBy1ToolStripMenuItem.Name = "increaseZBy1ToolStripMenuItem";
            increaseZBy1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            increaseZBy1ToolStripMenuItem.Text = "Increase Z by 1";
            // 
            // decreaseZToolStripMenuItem
            // 
            decreaseZToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { sendToBackToolStripMenuItem2, decreaseZBy1ToolStripMenuItem });
            decreaseZToolStripMenuItem.Name = "decreaseZToolStripMenuItem";
            decreaseZToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            decreaseZToolStripMenuItem.Text = "Decrease Z";
            // 
            // sendToBackToolStripMenuItem2
            // 
            sendToBackToolStripMenuItem2.Name = "sendToBackToolStripMenuItem2";
            sendToBackToolStripMenuItem2.Size = new System.Drawing.Size(156, 22);
            sendToBackToolStripMenuItem2.Text = "Send to Back";
            sendToBackToolStripMenuItem2.Click += SendSelectedToBack;
            // 
            // decreaseZBy1ToolStripMenuItem
            // 
            decreaseZBy1ToolStripMenuItem.Enabled = false;
            decreaseZBy1ToolStripMenuItem.Name = "decreaseZBy1ToolStripMenuItem";
            decreaseZBy1ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            decreaseZBy1ToolStripMenuItem.Text = "Decrease Z by 1";
            // 
            // sendToBg1ToolStripMenuItem
            // 
            sendToBg1ToolStripMenuItem.Name = "sendToBg1ToolStripMenuItem";
            sendToBg1ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            sendToBg1ToolStripMenuItem.Text = "Send to Layer 1";
            sendToBg1ToolStripMenuItem.Click += sendToBg1ToolStripMenuItem_Click;
            // 
            // sendToBg1ToolStripMenuItem1
            // 
            sendToBg1ToolStripMenuItem1.Name = "sendToBg1ToolStripMenuItem1";
            sendToBg1ToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            sendToBg1ToolStripMenuItem1.Text = "Send to Layer 2";
            sendToBg1ToolStripMenuItem1.Click += sendToBg1ToolStripMenuItem1_Click;
            // 
            // sendToBg1ToolStripMenuItem2
            // 
            sendToBg1ToolStripMenuItem2.Name = "sendToBg1ToolStripMenuItem2";
            sendToBg1ToolStripMenuItem2.Size = new System.Drawing.Size(154, 22);
            sendToBg1ToolStripMenuItem2.Text = "Send to Layer 3";
            sendToBg1ToolStripMenuItem2.Click += sendToBg1ToolStripMenuItem2_Click;
            // 
            // editGfxToolStripMenuItem
            // 
            editGfxToolStripMenuItem.Enabled = false;
            editGfxToolStripMenuItem.Name = "editGfxToolStripMenuItem";
            editGfxToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            editGfxToolStripMenuItem.Text = "Edit Graphics";
            // 
            // groupselectedcontextMenu
            // 
            groupselectedcontextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { insertToolStripMenuItem2, cutToolStripMenuItem2, copyToolStripMenuItem2, pasteToolStripMenuItem2, toolStripMenuItem3, bringToFrontToolStripMenuItem1, sendToBackToolStripMenuItem1, toolStripMenuItem4, sendToBg1ToolStripMenuItem3, sendToBg1ToolStripMenuItem4, sendToBg1ToolStripMenuItem5 });
            groupselectedcontextMenu.Name = "nothingselectedcontextMenu";
            groupselectedcontextMenu.Size = new System.Drawing.Size(190, 246);
            // 
            // insertToolStripMenuItem2
            // 
            insertToolStripMenuItem2.Name = "insertToolStripMenuItem2";
            insertToolStripMenuItem2.Size = new System.Drawing.Size(189, 22);
            insertToolStripMenuItem2.Text = "Insert";
            insertToolStripMenuItem2.Click += InsertToolStripMenuItem2_Click;
            // 
            // cutToolStripMenuItem2
            // 
            cutToolStripMenuItem2.Name = "cutToolStripMenuItem2";
            cutToolStripMenuItem2.Size = new System.Drawing.Size(189, 22);
            cutToolStripMenuItem2.Text = "Cut";
            cutToolStripMenuItem2.Click += CutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem2
            // 
            copyToolStripMenuItem2.Name = "copyToolStripMenuItem2";
            copyToolStripMenuItem2.Size = new System.Drawing.Size(189, 22);
            copyToolStripMenuItem2.Text = "Copy";
            copyToolStripMenuItem2.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem2
            // 
            pasteToolStripMenuItem2.Name = "pasteToolStripMenuItem2";
            pasteToolStripMenuItem2.Size = new System.Drawing.Size(189, 22);
            pasteToolStripMenuItem2.Text = "Paste";
            pasteToolStripMenuItem2.Click += PasteToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(189, 22);
            toolStripMenuItem3.Text = "Delete";
            toolStripMenuItem3.Click += DeleteToolStripMenuItem_Click;
            // 
            // bringToFrontToolStripMenuItem1
            // 
            bringToFrontToolStripMenuItem1.Name = "bringToFrontToolStripMenuItem1";
            bringToFrontToolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            bringToFrontToolStripMenuItem1.Text = "Send to Front";
            bringToFrontToolStripMenuItem1.Click += SendSelectedToFront;
            // 
            // sendToBackToolStripMenuItem1
            // 
            sendToBackToolStripMenuItem1.Name = "sendToBackToolStripMenuItem1";
            sendToBackToolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            sendToBackToolStripMenuItem1.Text = "Send to Back";
            sendToBackToolStripMenuItem1.Click += SendSelectedToBack;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new System.Drawing.Size(189, 22);
            toolStripMenuItem4.Text = "Save As New Layout…";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // sendToBg1ToolStripMenuItem3
            // 
            sendToBg1ToolStripMenuItem3.Name = "sendToBg1ToolStripMenuItem3";
            sendToBg1ToolStripMenuItem3.Size = new System.Drawing.Size(189, 22);
            sendToBg1ToolStripMenuItem3.Text = "Send to Layer 1";
            sendToBg1ToolStripMenuItem3.Click += sendToBg1ToolStripMenuItem_Click;
            // 
            // sendToBg1ToolStripMenuItem4
            // 
            sendToBg1ToolStripMenuItem4.Name = "sendToBg1ToolStripMenuItem4";
            sendToBg1ToolStripMenuItem4.Size = new System.Drawing.Size(189, 22);
            sendToBg1ToolStripMenuItem4.Text = "Send to Layer 2";
            sendToBg1ToolStripMenuItem4.Click += sendToBg1ToolStripMenuItem1_Click;
            // 
            // sendToBg1ToolStripMenuItem5
            // 
            sendToBg1ToolStripMenuItem5.Name = "sendToBg1ToolStripMenuItem5";
            sendToBg1ToolStripMenuItem5.Size = new System.Drawing.Size(189, 22);
            sendToBg1ToolStripMenuItem5.Text = "Send to Layer 3";
            sendToBg1ToolStripMenuItem5.Click += sendToBg1ToolStripMenuItem2_Click;
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 100;
            // 
            // roomProperty_sortsprite
            // 
            roomProperty_sortsprite.AutoSize = true;
            roomProperty_sortsprite.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            roomProperty_sortsprite.Location = new System.Drawing.Point(348, 77);
            roomProperty_sortsprite.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            roomProperty_sortsprite.Name = "roomProperty_sortsprite";
            roomProperty_sortsprite.Size = new System.Drawing.Size(98, 19);
            roomProperty_sortsprite.TabIndex = 52;
            roomProperty_sortsprite.Text = "Layered OAM";
            toolTip1.SetToolTip(roomProperty_sortsprite, "This property should be set in rooms where the upper and lower layers have overlapping areas in bounds.");
            roomProperty_sortsprite.UseVisualStyleBackColor = true;
            roomProperty_sortsprite.CheckedChanged += RoomPropertyChanged;
            // 
            // EntranceProperties_Music
            // 
            EntranceProperties_Music.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperties_Music.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperties_Music.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperties_Music.Decimal = false;
            EntranceProperties_Music.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            EntranceProperties_Music.ForeColor = System.Drawing.Color.White;
            EntranceProperties_Music.HexValue = 0;
            EntranceProperties_Music.Location = new System.Drawing.Point(138, 33);
            EntranceProperties_Music.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperties_Music.MaxLength = 2;
            EntranceProperties_Music.MaxValue = 255;
            EntranceProperties_Music.MinValue = 0;
            EntranceProperties_Music.Name = "EntranceProperties_Music";
            EntranceProperties_Music.Size = new System.Drawing.Size(58, 23);
            EntranceProperties_Music.TabIndex = 137;
            EntranceProperties_Music.Text = "00";
            EntranceProperties_Music.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            toolTip1.SetToolTip(EntranceProperties_Music, "Music");
            EntranceProperties_Music.TextChanged += entranceProperty_room_TextChanged;
            // 
            // toolboxPanel
            // 
            toolboxPanel.Controls.Add(tabControl1);
            toolboxPanel.Dock = System.Windows.Forms.DockStyle.Left;
            toolboxPanel.Location = new System.Drawing.Point(0, 49);
            toolboxPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            toolboxPanel.Name = "toolboxPanel";
            toolboxPanel.Size = new System.Drawing.Size(350, 811);
            toolboxPanel.TabIndex = 14;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(entrancetabPage);
            tabControl1.Controls.Add(objectstabPage);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(edit8x8);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Enabled = false;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(350, 811);
            tabControl1.TabIndex = 12;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // entrancetabPage
            // 
            entrancetabPage.Controls.Add(splitContainer3);
            entrancetabPage.Location = new System.Drawing.Point(4, 24);
            entrancetabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            entrancetabPage.Name = "entrancetabPage";
            entrancetabPage.Size = new System.Drawing.Size(342, 783);
            entrancetabPage.TabIndex = 5;
            entrancetabPage.Text = "Rooms";
            entrancetabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer3.IsSplitterFixed = true;
            splitContainer3.Location = new System.Drawing.Point(0, 0);
            splitContainer3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(panel2);
            splitContainer3.Panel1MinSize = 372;
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.AutoScroll = true;
            splitContainer3.Panel2.Controls.Add(entrancetreeView);
            splitContainer3.Panel2MinSize = 0;
            splitContainer3.Size = new System.Drawing.Size(342, 783);
            splitContainer3.SplitterDistance = 429;
            splitContainer3.SplitterWidth = 5;
            splitContainer3.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Controls.Add(dooryHexbox);
            panel2.Controls.Add(doorxHexbox);
            panel2.Controls.Add(facedownCheckbox);
            panel2.Controls.Add(EntranceProperties_FloorSel);
            panel2.Controls.Add(EntranceProperties_Blockset);
            panel2.Controls.Add(EntranceProperties_Music);
            panel2.Controls.Add(EntranceProperties_DungeonID);
            panel2.Controls.Add(EntranceProperties_CameraTriggerY);
            panel2.Controls.Add(EntranceProperties_CameraTriggerX);
            panel2.Controls.Add(label46);
            panel2.Controls.Add(label45);
            panel2.Controls.Add(EntranceProperties_CameraX);
            panel2.Controls.Add(EntranceProperties_CameraY);
            panel2.Controls.Add(EntranceProperties_PlayerY);
            panel2.Controls.Add(EntranceProperties_PlayerX);
            panel2.Controls.Add(label41);
            panel2.Controls.Add(label38);
            panel2.Controls.Add(EntranceProperties_RoomID);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(label30);
            panel2.Controls.Add(doorCheckbox);
            panel2.Controls.Add(label27);
            panel2.Controls.Add(entranceProperty_quadbr);
            panel2.Controls.Add(entranceProperty_quadtr);
            panel2.Controls.Add(entranceProperty_quadbl);
            panel2.Controls.Add(entranceProperty_quadtl);
            panel2.Controls.Add(label42);
            panel2.Controls.Add(entranceProperty_vscroll);
            panel2.Controls.Add(entranceProperty_hscroll);
            panel2.Controls.Add(label44);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(gridEntranceCheckbox);
            panel2.Controls.Add(label21);
            panel2.Controls.Add(mouseEntranceButton);
            panel2.Controls.Add(entranceProperty_bg);
            panel2.Controls.Add(label22);
            panel2.Controls.Add(label40);
            panel2.Controls.Add(label24);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.MinimumSize = new System.Drawing.Size(341, 414);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(342, 429);
            panel2.TabIndex = 61;
            // 
            // dooryHexbox
            // 
            dooryHexbox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            dooryHexbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dooryHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            dooryHexbox.Decimal = false;
            dooryHexbox.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            dooryHexbox.ForeColor = System.Drawing.Color.White;
            dooryHexbox.HexValue = 0;
            dooryHexbox.Location = new System.Drawing.Point(136, 228);
            dooryHexbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dooryHexbox.MaxLength = 2;
            dooryHexbox.MaxValue = 255;
            dooryHexbox.MinValue = 0;
            dooryHexbox.Name = "dooryHexbox";
            dooryHexbox.Size = new System.Drawing.Size(51, 23);
            dooryHexbox.TabIndex = 142;
            dooryHexbox.Text = "00";
            dooryHexbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            dooryHexbox.TextChanged += entranceProperty_room_TextChanged;
            // 
            // doorxHexbox
            // 
            doorxHexbox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            doorxHexbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            doorxHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            doorxHexbox.Decimal = false;
            doorxHexbox.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            doorxHexbox.ForeColor = System.Drawing.Color.White;
            doorxHexbox.HexValue = 0;
            doorxHexbox.Location = new System.Drawing.Point(78, 228);
            doorxHexbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            doorxHexbox.MaxLength = 2;
            doorxHexbox.MaxValue = 255;
            doorxHexbox.MinValue = 0;
            doorxHexbox.Name = "doorxHexbox";
            doorxHexbox.Size = new System.Drawing.Size(51, 23);
            doorxHexbox.TabIndex = 141;
            doorxHexbox.Text = "00";
            doorxHexbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            doorxHexbox.TextChanged += entranceProperty_room_TextChanged;
            // 
            // facedownCheckbox
            // 
            facedownCheckbox.AutoSize = true;
            facedownCheckbox.Location = new System.Drawing.Point(245, 63);
            facedownCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            facedownCheckbox.Name = "facedownCheckbox";
            facedownCheckbox.Size = new System.Drawing.Size(83, 19);
            facedownCheckbox.TabIndex = 140;
            facedownCheckbox.Text = "Face down";
            facedownCheckbox.UseVisualStyleBackColor = true;
            facedownCheckbox.CheckedChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperties_FloorSel
            // 
            EntranceProperties_FloorSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            EntranceProperties_FloorSel.FormattingEnabled = true;
            EntranceProperties_FloorSel.Location = new System.Drawing.Point(266, 33);
            EntranceProperties_FloorSel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperties_FloorSel.Name = "EntranceProperties_FloorSel";
            EntranceProperties_FloorSel.Size = new System.Drawing.Size(63, 23);
            EntranceProperties_FloorSel.TabIndex = 139;
            EntranceProperties_FloorSel.SelectedIndexChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperties_Blockset
            // 
            EntranceProperties_Blockset.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperties_Blockset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperties_Blockset.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperties_Blockset.Decimal = false;
            EntranceProperties_Blockset.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            EntranceProperties_Blockset.ForeColor = System.Drawing.Color.White;
            EntranceProperties_Blockset.HexValue = 0;
            EntranceProperties_Blockset.Location = new System.Drawing.Point(203, 33);
            EntranceProperties_Blockset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperties_Blockset.MaxLength = 2;
            EntranceProperties_Blockset.MaxValue = 255;
            EntranceProperties_Blockset.MinValue = 0;
            EntranceProperties_Blockset.Name = "EntranceProperties_Blockset";
            EntranceProperties_Blockset.Size = new System.Drawing.Size(58, 23);
            EntranceProperties_Blockset.TabIndex = 138;
            EntranceProperties_Blockset.Text = "00";
            EntranceProperties_Blockset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperties_Blockset.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperties_DungeonID
            // 
            EntranceProperties_DungeonID.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperties_DungeonID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperties_DungeonID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperties_DungeonID.Decimal = false;
            EntranceProperties_DungeonID.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            EntranceProperties_DungeonID.ForeColor = System.Drawing.Color.White;
            EntranceProperties_DungeonID.HexValue = 0;
            EntranceProperties_DungeonID.Location = new System.Drawing.Point(72, 33);
            EntranceProperties_DungeonID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperties_DungeonID.MaxLength = 2;
            EntranceProperties_DungeonID.MaxValue = 255;
            EntranceProperties_DungeonID.MinValue = 0;
            EntranceProperties_DungeonID.Name = "EntranceProperties_DungeonID";
            EntranceProperties_DungeonID.Size = new System.Drawing.Size(58, 23);
            EntranceProperties_DungeonID.TabIndex = 136;
            EntranceProperties_DungeonID.Text = "00";
            EntranceProperties_DungeonID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperties_DungeonID.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperties_CameraTriggerY
            // 
            EntranceProperties_CameraTriggerY.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperties_CameraTriggerY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperties_CameraTriggerY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperties_CameraTriggerY.Decimal = false;
            EntranceProperties_CameraTriggerY.Digits = Gui.ExtraForms.Hexbox.HexDigits.Four;
            EntranceProperties_CameraTriggerY.ForeColor = System.Drawing.Color.White;
            EntranceProperties_CameraTriggerY.HexValue = 0;
            EntranceProperties_CameraTriggerY.Location = new System.Drawing.Point(153, 164);
            EntranceProperties_CameraTriggerY.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperties_CameraTriggerY.MaxLength = 4;
            EntranceProperties_CameraTriggerY.MaxValue = 65535;
            EntranceProperties_CameraTriggerY.MinValue = 0;
            EntranceProperties_CameraTriggerY.Name = "EntranceProperties_CameraTriggerY";
            EntranceProperties_CameraTriggerY.Size = new System.Drawing.Size(51, 23);
            EntranceProperties_CameraTriggerY.TabIndex = 134;
            EntranceProperties_CameraTriggerY.Text = "0000";
            EntranceProperties_CameraTriggerY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperties_CameraTriggerY.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperties_CameraTriggerX
            // 
            EntranceProperties_CameraTriggerX.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperties_CameraTriggerX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperties_CameraTriggerX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperties_CameraTriggerX.Decimal = false;
            EntranceProperties_CameraTriggerX.Digits = Gui.ExtraForms.Hexbox.HexDigits.Four;
            EntranceProperties_CameraTriggerX.ForeColor = System.Drawing.Color.White;
            EntranceProperties_CameraTriggerX.HexValue = 0;
            EntranceProperties_CameraTriggerX.Location = new System.Drawing.Point(79, 164);
            EntranceProperties_CameraTriggerX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperties_CameraTriggerX.MaxLength = 4;
            EntranceProperties_CameraTriggerX.MaxValue = 65535;
            EntranceProperties_CameraTriggerX.MinValue = 0;
            EntranceProperties_CameraTriggerX.Name = "EntranceProperties_CameraTriggerX";
            EntranceProperties_CameraTriggerX.Size = new System.Drawing.Size(51, 23);
            EntranceProperties_CameraTriggerX.TabIndex = 133;
            EntranceProperties_CameraTriggerX.Text = "0000";
            EntranceProperties_CameraTriggerX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperties_CameraTriggerX.TextChanged += entranceProperty_room_TextChanged;
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new System.Drawing.Point(22, 141);
            label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label46.Name = "label46";
            label46.Size = new System.Drawing.Size(48, 15);
            label46.TabIndex = 132;
            label46.Text = "Camera";
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new System.Drawing.Point(30, 112);
            label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label45.Name = "label45";
            label45.Size = new System.Drawing.Size(39, 15);
            label45.TabIndex = 131;
            label45.Text = "Player";
            // 
            // EntranceProperties_CameraX
            // 
            EntranceProperties_CameraX.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperties_CameraX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperties_CameraX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperties_CameraX.Decimal = false;
            EntranceProperties_CameraX.Digits = Gui.ExtraForms.Hexbox.HexDigits.Four;
            EntranceProperties_CameraX.ForeColor = System.Drawing.Color.White;
            EntranceProperties_CameraX.HexValue = 0;
            EntranceProperties_CameraX.Location = new System.Drawing.Point(79, 135);
            EntranceProperties_CameraX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperties_CameraX.MaxLength = 4;
            EntranceProperties_CameraX.MaxValue = 65535;
            EntranceProperties_CameraX.MinValue = 0;
            EntranceProperties_CameraX.Name = "EntranceProperties_CameraX";
            EntranceProperties_CameraX.Size = new System.Drawing.Size(51, 23);
            EntranceProperties_CameraX.TabIndex = 130;
            EntranceProperties_CameraX.Text = "0000";
            EntranceProperties_CameraX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperties_CameraX.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperties_CameraY
            // 
            EntranceProperties_CameraY.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperties_CameraY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperties_CameraY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperties_CameraY.Decimal = false;
            EntranceProperties_CameraY.Digits = Gui.ExtraForms.Hexbox.HexDigits.Four;
            EntranceProperties_CameraY.ForeColor = System.Drawing.Color.White;
            EntranceProperties_CameraY.HexValue = 0;
            EntranceProperties_CameraY.Location = new System.Drawing.Point(153, 135);
            EntranceProperties_CameraY.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperties_CameraY.MaxLength = 4;
            EntranceProperties_CameraY.MaxValue = 65535;
            EntranceProperties_CameraY.MinValue = 0;
            EntranceProperties_CameraY.Name = "EntranceProperties_CameraY";
            EntranceProperties_CameraY.Size = new System.Drawing.Size(51, 23);
            EntranceProperties_CameraY.TabIndex = 129;
            EntranceProperties_CameraY.Text = "0000";
            EntranceProperties_CameraY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperties_CameraY.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperties_PlayerY
            // 
            EntranceProperties_PlayerY.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperties_PlayerY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperties_PlayerY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperties_PlayerY.Decimal = false;
            EntranceProperties_PlayerY.Digits = Gui.ExtraForms.Hexbox.HexDigits.Four;
            EntranceProperties_PlayerY.ForeColor = System.Drawing.Color.White;
            EntranceProperties_PlayerY.HexValue = 0;
            EntranceProperties_PlayerY.Location = new System.Drawing.Point(153, 107);
            EntranceProperties_PlayerY.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperties_PlayerY.MaxLength = 4;
            EntranceProperties_PlayerY.MaxValue = 65535;
            EntranceProperties_PlayerY.MinValue = 0;
            EntranceProperties_PlayerY.Name = "EntranceProperties_PlayerY";
            EntranceProperties_PlayerY.Size = new System.Drawing.Size(51, 23);
            EntranceProperties_PlayerY.TabIndex = 128;
            EntranceProperties_PlayerY.Text = "0000";
            EntranceProperties_PlayerY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperties_PlayerY.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperties_PlayerX
            // 
            EntranceProperties_PlayerX.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperties_PlayerX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperties_PlayerX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperties_PlayerX.Decimal = false;
            EntranceProperties_PlayerX.Digits = Gui.ExtraForms.Hexbox.HexDigits.Four;
            EntranceProperties_PlayerX.ForeColor = System.Drawing.Color.White;
            EntranceProperties_PlayerX.HexValue = 0;
            EntranceProperties_PlayerX.Location = new System.Drawing.Point(79, 107);
            EntranceProperties_PlayerX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperties_PlayerX.MaxLength = 4;
            EntranceProperties_PlayerX.MaxValue = 65535;
            EntranceProperties_PlayerX.MinValue = 0;
            EntranceProperties_PlayerX.Name = "EntranceProperties_PlayerX";
            EntranceProperties_PlayerX.Size = new System.Drawing.Size(51, 23);
            EntranceProperties_PlayerX.TabIndex = 127;
            EntranceProperties_PlayerX.Text = "0000";
            EntranceProperties_PlayerX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperties_PlayerX.TextChanged += entranceProperty_room_TextChanged;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new System.Drawing.Point(168, 88);
            label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label41.Name = "label41";
            label41.Size = new System.Drawing.Size(14, 15);
            label41.TabIndex = 126;
            label41.Text = "Y";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new System.Drawing.Point(98, 88);
            label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label38.Name = "label38";
            label38.Size = new System.Drawing.Size(14, 15);
            label38.TabIndex = 125;
            label38.Text = "X";
            // 
            // EntranceProperties_RoomID
            // 
            EntranceProperties_RoomID.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperties_RoomID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperties_RoomID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperties_RoomID.Decimal = false;
            EntranceProperties_RoomID.Digits = Gui.ExtraForms.Hexbox.HexDigits.Three;
            EntranceProperties_RoomID.ForeColor = System.Drawing.Color.White;
            EntranceProperties_RoomID.HexValue = 0;
            EntranceProperties_RoomID.Location = new System.Drawing.Point(7, 33);
            EntranceProperties_RoomID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperties_RoomID.MaxLength = 3;
            EntranceProperties_RoomID.MaxValue = 4095;
            EntranceProperties_RoomID.MinValue = 0;
            EntranceProperties_RoomID.Name = "EntranceProperties_RoomID";
            EntranceProperties_RoomID.Size = new System.Drawing.Size(58, 23);
            EntranceProperties_RoomID.TabIndex = 124;
            EntranceProperties_RoomID.Text = "000";
            EntranceProperties_RoomID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperties_RoomID.TextChanged += entranceProperty_room_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(EntranceProperty_BoundaryFE);
            groupBox2.Controls.Add(EntranceProperty_BoundaryFW);
            groupBox2.Controls.Add(EntranceProperty_BoundaryQE);
            groupBox2.Controls.Add(EntranceProperty_BoundaryQW);
            groupBox2.Controls.Add(EntranceProperty_BoundaryFS);
            groupBox2.Controls.Add(EntranceProperty_BoundaryFN);
            groupBox2.Controls.Add(EntranceProperty_BoundaryQS);
            groupBox2.Controls.Add(EntranceProperty_BoundaryQN);
            groupBox2.Controls.Add(label37);
            groupBox2.Controls.Add(label36);
            groupBox2.Controls.Add(label35);
            groupBox2.Controls.Add(label34);
            groupBox2.Controls.Add(label32);
            groupBox2.Controls.Add(label29);
            groupBox2.Location = new System.Drawing.Point(4, 270);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(332, 111);
            groupBox2.TabIndex = 123;
            groupBox2.TabStop = false;
            groupBox2.Text = "Camera boundaries";
            // 
            // EntranceProperty_BoundaryFE
            // 
            EntranceProperty_BoundaryFE.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperty_BoundaryFE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperty_BoundaryFE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperty_BoundaryFE.Decimal = false;
            EntranceProperty_BoundaryFE.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            EntranceProperty_BoundaryFE.ForeColor = System.Drawing.Color.White;
            EntranceProperty_BoundaryFE.HexValue = 0;
            EntranceProperty_BoundaryFE.Location = new System.Drawing.Point(262, 70);
            EntranceProperty_BoundaryFE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperty_BoundaryFE.MaxLength = 2;
            EntranceProperty_BoundaryFE.MaxValue = 255;
            EntranceProperty_BoundaryFE.MinValue = 0;
            EntranceProperty_BoundaryFE.Name = "EntranceProperty_BoundaryFE";
            EntranceProperty_BoundaryFE.Size = new System.Drawing.Size(45, 23);
            EntranceProperty_BoundaryFE.TabIndex = 133;
            EntranceProperty_BoundaryFE.Text = "00";
            EntranceProperty_BoundaryFE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperty_BoundaryFE.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperty_BoundaryFW
            // 
            EntranceProperty_BoundaryFW.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperty_BoundaryFW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperty_BoundaryFW.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperty_BoundaryFW.Decimal = false;
            EntranceProperty_BoundaryFW.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            EntranceProperty_BoundaryFW.ForeColor = System.Drawing.Color.White;
            EntranceProperty_BoundaryFW.HexValue = 0;
            EntranceProperty_BoundaryFW.Location = new System.Drawing.Point(197, 70);
            EntranceProperty_BoundaryFW.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperty_BoundaryFW.MaxLength = 2;
            EntranceProperty_BoundaryFW.MaxValue = 255;
            EntranceProperty_BoundaryFW.MinValue = 0;
            EntranceProperty_BoundaryFW.Name = "EntranceProperty_BoundaryFW";
            EntranceProperty_BoundaryFW.Size = new System.Drawing.Size(45, 23);
            EntranceProperty_BoundaryFW.TabIndex = 132;
            EntranceProperty_BoundaryFW.Text = "00";
            EntranceProperty_BoundaryFW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperty_BoundaryFW.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperty_BoundaryQE
            // 
            EntranceProperty_BoundaryQE.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperty_BoundaryQE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperty_BoundaryQE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperty_BoundaryQE.Decimal = false;
            EntranceProperty_BoundaryQE.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            EntranceProperty_BoundaryQE.ForeColor = System.Drawing.Color.White;
            EntranceProperty_BoundaryQE.HexValue = 0;
            EntranceProperty_BoundaryQE.Location = new System.Drawing.Point(262, 40);
            EntranceProperty_BoundaryQE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperty_BoundaryQE.MaxLength = 2;
            EntranceProperty_BoundaryQE.MaxValue = 255;
            EntranceProperty_BoundaryQE.MinValue = 0;
            EntranceProperty_BoundaryQE.Name = "EntranceProperty_BoundaryQE";
            EntranceProperty_BoundaryQE.Size = new System.Drawing.Size(45, 23);
            EntranceProperty_BoundaryQE.TabIndex = 131;
            EntranceProperty_BoundaryQE.Text = "00";
            EntranceProperty_BoundaryQE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperty_BoundaryQE.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperty_BoundaryQW
            // 
            EntranceProperty_BoundaryQW.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperty_BoundaryQW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperty_BoundaryQW.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperty_BoundaryQW.Decimal = false;
            EntranceProperty_BoundaryQW.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            EntranceProperty_BoundaryQW.ForeColor = System.Drawing.Color.White;
            EntranceProperty_BoundaryQW.HexValue = 0;
            EntranceProperty_BoundaryQW.Location = new System.Drawing.Point(197, 40);
            EntranceProperty_BoundaryQW.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperty_BoundaryQW.MaxLength = 2;
            EntranceProperty_BoundaryQW.MaxValue = 255;
            EntranceProperty_BoundaryQW.MinValue = 0;
            EntranceProperty_BoundaryQW.Name = "EntranceProperty_BoundaryQW";
            EntranceProperty_BoundaryQW.Size = new System.Drawing.Size(45, 23);
            EntranceProperty_BoundaryQW.TabIndex = 130;
            EntranceProperty_BoundaryQW.Text = "00";
            EntranceProperty_BoundaryQW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperty_BoundaryQW.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperty_BoundaryFS
            // 
            EntranceProperty_BoundaryFS.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperty_BoundaryFS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperty_BoundaryFS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperty_BoundaryFS.Decimal = false;
            EntranceProperty_BoundaryFS.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            EntranceProperty_BoundaryFS.ForeColor = System.Drawing.Color.White;
            EntranceProperty_BoundaryFS.HexValue = 0;
            EntranceProperty_BoundaryFS.Location = new System.Drawing.Point(135, 70);
            EntranceProperty_BoundaryFS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperty_BoundaryFS.MaxLength = 2;
            EntranceProperty_BoundaryFS.MaxValue = 255;
            EntranceProperty_BoundaryFS.MinValue = 0;
            EntranceProperty_BoundaryFS.Name = "EntranceProperty_BoundaryFS";
            EntranceProperty_BoundaryFS.Size = new System.Drawing.Size(45, 23);
            EntranceProperty_BoundaryFS.TabIndex = 129;
            EntranceProperty_BoundaryFS.Text = "00";
            EntranceProperty_BoundaryFS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperty_BoundaryFS.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperty_BoundaryFN
            // 
            EntranceProperty_BoundaryFN.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperty_BoundaryFN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperty_BoundaryFN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperty_BoundaryFN.Decimal = false;
            EntranceProperty_BoundaryFN.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            EntranceProperty_BoundaryFN.ForeColor = System.Drawing.Color.White;
            EntranceProperty_BoundaryFN.HexValue = 0;
            EntranceProperty_BoundaryFN.Location = new System.Drawing.Point(70, 70);
            EntranceProperty_BoundaryFN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperty_BoundaryFN.MaxLength = 2;
            EntranceProperty_BoundaryFN.MaxValue = 255;
            EntranceProperty_BoundaryFN.MinValue = 0;
            EntranceProperty_BoundaryFN.Name = "EntranceProperty_BoundaryFN";
            EntranceProperty_BoundaryFN.Size = new System.Drawing.Size(45, 23);
            EntranceProperty_BoundaryFN.TabIndex = 128;
            EntranceProperty_BoundaryFN.Text = "00";
            EntranceProperty_BoundaryFN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperty_BoundaryFN.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperty_BoundaryQS
            // 
            EntranceProperty_BoundaryQS.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperty_BoundaryQS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperty_BoundaryQS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperty_BoundaryQS.Decimal = false;
            EntranceProperty_BoundaryQS.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            EntranceProperty_BoundaryQS.ForeColor = System.Drawing.Color.White;
            EntranceProperty_BoundaryQS.HexValue = 0;
            EntranceProperty_BoundaryQS.Location = new System.Drawing.Point(135, 40);
            EntranceProperty_BoundaryQS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperty_BoundaryQS.MaxLength = 2;
            EntranceProperty_BoundaryQS.MaxValue = 255;
            EntranceProperty_BoundaryQS.MinValue = 0;
            EntranceProperty_BoundaryQS.Name = "EntranceProperty_BoundaryQS";
            EntranceProperty_BoundaryQS.Size = new System.Drawing.Size(45, 23);
            EntranceProperty_BoundaryQS.TabIndex = 127;
            EntranceProperty_BoundaryQS.Text = "00";
            EntranceProperty_BoundaryQS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperty_BoundaryQS.TextChanged += entranceProperty_room_TextChanged;
            // 
            // EntranceProperty_BoundaryQN
            // 
            EntranceProperty_BoundaryQN.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            EntranceProperty_BoundaryQN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EntranceProperty_BoundaryQN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            EntranceProperty_BoundaryQN.Decimal = false;
            EntranceProperty_BoundaryQN.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            EntranceProperty_BoundaryQN.ForeColor = System.Drawing.Color.White;
            EntranceProperty_BoundaryQN.HexValue = 0;
            EntranceProperty_BoundaryQN.Location = new System.Drawing.Point(70, 40);
            EntranceProperty_BoundaryQN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EntranceProperty_BoundaryQN.MaxLength = 2;
            EntranceProperty_BoundaryQN.MaxValue = 255;
            EntranceProperty_BoundaryQN.MinValue = 0;
            EntranceProperty_BoundaryQN.Name = "EntranceProperty_BoundaryQN";
            EntranceProperty_BoundaryQN.Size = new System.Drawing.Size(45, 23);
            EntranceProperty_BoundaryQN.TabIndex = 126;
            EntranceProperty_BoundaryQN.Text = "00";
            EntranceProperty_BoundaryQN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            EntranceProperty_BoundaryQN.TextChanged += entranceProperty_room_TextChanged;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new System.Drawing.Point(16, 74);
            label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label37.Name = "label37";
            label37.Size = new System.Drawing.Size(58, 15);
            label37.TabIndex = 125;
            label37.Text = "Full room";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new System.Drawing.Point(14, 44);
            label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(57, 15);
            label36.TabIndex = 124;
            label36.Text = "Quadrant";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new System.Drawing.Point(268, 22);
            label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(28, 15);
            label35.TabIndex = 123;
            label35.Text = "East";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new System.Drawing.Point(204, 22);
            label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(33, 15);
            label34.TabIndex = 122;
            label34.Text = "West";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new System.Drawing.Point(140, 22);
            label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(38, 15);
            label32.TabIndex = 121;
            label32.Text = "South";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(77, 22);
            label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(38, 15);
            label29.TabIndex = 120;
            label29.Text = "North";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new System.Drawing.Point(16, 195);
            label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(53, 15);
            label30.TabIndex = 122;
            label30.Text = "Scrolling";
            // 
            // doorCheckbox
            // 
            doorCheckbox.AutoSize = true;
            doorCheckbox.Location = new System.Drawing.Point(115, 63);
            doorCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            doorCheckbox.Name = "doorCheckbox";
            doorCheckbox.Size = new System.Drawing.Size(73, 19);
            doorCheckbox.TabIndex = 105;
            doorCheckbox.Text = "Use door";
            doorCheckbox.UseVisualStyleBackColor = true;
            doorCheckbox.CheckedChanged += entranceProperty_room_TextChanged;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(13, 232);
            label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(55, 15);
            label27.TabIndex = 101;
            label27.Text = "OW door";
            // 
            // entranceProperty_quadbr
            // 
            entranceProperty_quadbr.AutoSize = true;
            entranceProperty_quadbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            entranceProperty_quadbr.Location = new System.Drawing.Point(284, 160);
            entranceProperty_quadbr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            entranceProperty_quadbr.Name = "entranceProperty_quadbr";
            entranceProperty_quadbr.Size = new System.Drawing.Size(42, 28);
            entranceProperty_quadbr.TabIndex = 93;
            entranceProperty_quadbr.TabStop = true;
            entranceProperty_quadbr.Text = "◲";
            entranceProperty_quadbr.UseVisualStyleBackColor = true;
            entranceProperty_quadbr.CheckedChanged += entranceProperty_room_TextChanged;
            // 
            // entranceProperty_quadtr
            // 
            entranceProperty_quadtr.AutoSize = true;
            entranceProperty_quadtr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            entranceProperty_quadtr.Location = new System.Drawing.Point(284, 134);
            entranceProperty_quadtr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            entranceProperty_quadtr.Name = "entranceProperty_quadtr";
            entranceProperty_quadtr.Size = new System.Drawing.Size(42, 28);
            entranceProperty_quadtr.TabIndex = 92;
            entranceProperty_quadtr.TabStop = true;
            entranceProperty_quadtr.Text = "◳";
            entranceProperty_quadtr.UseVisualStyleBackColor = true;
            entranceProperty_quadtr.CheckedChanged += entranceProperty_room_TextChanged;
            // 
            // entranceProperty_quadbl
            // 
            entranceProperty_quadbl.AutoSize = true;
            entranceProperty_quadbl.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            entranceProperty_quadbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            entranceProperty_quadbl.Location = new System.Drawing.Point(218, 160);
            entranceProperty_quadbl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            entranceProperty_quadbl.Name = "entranceProperty_quadbl";
            entranceProperty_quadbl.Size = new System.Drawing.Size(42, 28);
            entranceProperty_quadbl.TabIndex = 91;
            entranceProperty_quadbl.TabStop = true;
            entranceProperty_quadbl.Text = "◱";
            entranceProperty_quadbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            entranceProperty_quadbl.UseVisualStyleBackColor = true;
            entranceProperty_quadbl.CheckedChanged += entranceProperty_room_TextChanged;
            // 
            // entranceProperty_quadtl
            // 
            entranceProperty_quadtl.AutoSize = true;
            entranceProperty_quadtl.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            entranceProperty_quadtl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            entranceProperty_quadtl.Location = new System.Drawing.Point(218, 134);
            entranceProperty_quadtl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            entranceProperty_quadtl.Name = "entranceProperty_quadtl";
            entranceProperty_quadtl.Size = new System.Drawing.Size(42, 28);
            entranceProperty_quadtl.TabIndex = 90;
            entranceProperty_quadtl.TabStop = true;
            entranceProperty_quadtl.Text = "◰";
            entranceProperty_quadtl.UseVisualStyleBackColor = true;
            entranceProperty_quadtl.CheckedChanged += entranceProperty_room_TextChanged;
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new System.Drawing.Point(245, 115);
            label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label42.Name = "label42";
            label42.Size = new System.Drawing.Size(57, 15);
            label42.TabIndex = 89;
            label42.Text = "Quadrant";
            // 
            // entranceProperty_vscroll
            // 
            entranceProperty_vscroll.AutoSize = true;
            entranceProperty_vscroll.Location = new System.Drawing.Point(153, 194);
            entranceProperty_vscroll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            entranceProperty_vscroll.Name = "entranceProperty_vscroll";
            entranceProperty_vscroll.Size = new System.Drawing.Size(57, 19);
            entranceProperty_vscroll.TabIndex = 88;
            entranceProperty_vscroll.Text = "Y-axis";
            entranceProperty_vscroll.UseVisualStyleBackColor = true;
            entranceProperty_vscroll.CheckedChanged += entranceProperty_room_TextChanged;
            // 
            // entranceProperty_hscroll
            // 
            entranceProperty_hscroll.AutoSize = true;
            entranceProperty_hscroll.Location = new System.Drawing.Point(79, 194);
            entranceProperty_hscroll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            entranceProperty_hscroll.Name = "entranceProperty_hscroll";
            entranceProperty_hscroll.Size = new System.Drawing.Size(57, 19);
            entranceProperty_hscroll.TabIndex = 87;
            entranceProperty_hscroll.Text = "X-axis";
            entranceProperty_hscroll.UseVisualStyleBackColor = true;
            entranceProperty_hscroll.CheckedChanged += entranceProperty_room_TextChanged;
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new System.Drawing.Point(20, 167);
            label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label44.Name = "label44";
            label44.Size = new System.Drawing.Size(49, 15);
            label44.TabIndex = 83;
            label44.Text = "Scroll at";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label18.Location = new System.Drawing.Point(6, 0);
            label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(171, 13);
            label18.TabIndex = 0;
            label18.Text = "Selected entrance properties";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(9, 15);
            label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(53, 15);
            label19.TabIndex = 1;
            label19.Text = "Room ID";
            // 
            // gridEntranceCheckbox
            // 
            gridEntranceCheckbox.AutoSize = true;
            gridEntranceCheckbox.Checked = true;
            gridEntranceCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            gridEntranceCheckbox.Location = new System.Drawing.Point(258, 397);
            gridEntranceCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gridEntranceCheckbox.Name = "gridEntranceCheckbox";
            gridEntranceCheckbox.Size = new System.Drawing.Size(71, 19);
            gridEntranceCheckbox.TabIndex = 59;
            gridEntranceCheckbox.Text = "8x8 snap";
            gridEntranceCheckbox.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(288, 15);
            label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(34, 15);
            label21.TabIndex = 2;
            label21.Text = "Floor";
            // 
            // mouseEntranceButton
            // 
            mouseEntranceButton.Location = new System.Drawing.Point(9, 392);
            mouseEntranceButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            mouseEntranceButton.Name = "mouseEntranceButton";
            mouseEntranceButton.Size = new System.Drawing.Size(246, 27);
            mouseEntranceButton.TabIndex = 58;
            mouseEntranceButton.Text = "Set entrance position with mouse";
            mouseEntranceButton.UseVisualStyleBackColor = true;
            mouseEntranceButton.Click += MouseEntranceButton_Click;
            // 
            // entranceProperty_bg
            // 
            entranceProperty_bg.AutoSize = true;
            entranceProperty_bg.Location = new System.Drawing.Point(7, 65);
            entranceProperty_bg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            entranceProperty_bg.Name = "entranceProperty_bg";
            entranceProperty_bg.Size = new System.Drawing.Size(63, 19);
            entranceProperty_bg.TabIndex = 41;
            entranceProperty_bg.Text = "Layer 2";
            entranceProperty_bg.UseVisualStyleBackColor = true;
            entranceProperty_bg.CheckStateChanged += entranceProperty_vscroll_CheckedChanged;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(66, 15);
            label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(70, 15);
            label22.TabIndex = 12;
            label22.Text = "Dungeon ID";
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new System.Drawing.Point(203, 15);
            label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label40.Name = "label40";
            label40.Size = new System.Drawing.Size(51, 15);
            label40.TabIndex = 15;
            label40.Text = "Blockset";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(144, 15);
            label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(39, 15);
            label24.TabIndex = 13;
            label24.Text = "Music";
            // 
            // entrancetreeView
            // 
            entrancetreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            entrancetreeView.HideSelection = false;
            entrancetreeView.Location = new System.Drawing.Point(0, 0);
            entrancetreeView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            entrancetreeView.Name = "entrancetreeView";
            treeNode1.Name = "EntranceNode";
            treeNode1.Text = "Entrances";
            treeNode2.Name = "StartingEntranceNode";
            treeNode2.Text = "Spawn points";
            entrancetreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode1, treeNode2 });
            entrancetreeView.Size = new System.Drawing.Size(342, 349);
            entrancetreeView.TabIndex = 0;
            entrancetreeView.AfterSelect += entrancetreeView_AfterSelect;
            entrancetreeView.NodeMouseDoubleClick += entrancetreeView_NodeMouseDoubleClick;
            // 
            // objectstabPage
            // 
            objectstabPage.Controls.Add(panel1);
            objectstabPage.Controls.Add(favoriteCheckbox);
            objectstabPage.Controls.Add(showNameObjectCheckbox);
            objectstabPage.Controls.Add(searchTextbox);
            objectstabPage.Location = new System.Drawing.Point(4, 24);
            objectstabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            objectstabPage.Name = "objectstabPage";
            objectstabPage.Size = new System.Drawing.Size(342, 783);
            objectstabPage.TabIndex = 4;
            objectstabPage.Text = "Objects";
            objectstabPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(objectViewer1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 61);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(342, 722);
            panel1.TabIndex = 1;
            // 
            // objectViewer1
            // 
            objectViewer1.Dock = System.Windows.Forms.DockStyle.Top;
            objectViewer1.Location = new System.Drawing.Point(0, 0);
            objectViewer1.Margin = new System.Windows.Forms.Padding(7);
            objectViewer1.MinimumSize = new System.Drawing.Size(0, 208);
            objectViewer1.Name = "objectViewer1";
            objectViewer1.Size = new System.Drawing.Size(342, 438);
            objectViewer1.TabIndex = 0;
            objectViewer1.SelectedIndexChanged += objectViewer1_SelectedIndexChanged;
            // 
            // favoriteCheckbox
            // 
            favoriteCheckbox.AutoSize = true;
            favoriteCheckbox.Dock = System.Windows.Forms.DockStyle.Top;
            favoriteCheckbox.Location = new System.Drawing.Point(0, 42);
            favoriteCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            favoriteCheckbox.Name = "favoriteCheckbox";
            favoriteCheckbox.Size = new System.Drawing.Size(342, 19);
            favoriteCheckbox.TabIndex = 2;
            favoriteCheckbox.Text = "Show favorites";
            favoriteCheckbox.UseVisualStyleBackColor = true;
            favoriteCheckbox.CheckedChanged += FavoriteCheckbox_CheckedChanged;
            // 
            // showNameObjectCheckbox
            // 
            showNameObjectCheckbox.AutoSize = true;
            showNameObjectCheckbox.Dock = System.Windows.Forms.DockStyle.Top;
            showNameObjectCheckbox.Location = new System.Drawing.Point(0, 23);
            showNameObjectCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            showNameObjectCheckbox.Name = "showNameObjectCheckbox";
            showNameObjectCheckbox.Size = new System.Drawing.Size(342, 19);
            showNameObjectCheckbox.TabIndex = 1;
            showNameObjectCheckbox.Text = "Show names";
            showNameObjectCheckbox.UseVisualStyleBackColor = true;
            showNameObjectCheckbox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // searchTextbox
            // 
            searchTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            searchTextbox.Location = new System.Drawing.Point(0, 0);
            searchTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            searchTextbox.Name = "searchTextbox";
            searchTextbox.Size = new System.Drawing.Size(342, 23);
            searchTextbox.TabIndex = 0;
            searchTextbox.TextChanged += searchTextbox_TextChanged;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(customPanel1);
            tabPage4.Location = new System.Drawing.Point(4, 24);
            tabPage4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new System.Drawing.Size(342, 783);
            tabPage4.TabIndex = 10;
            tabPage4.Text = "Sprites";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // customPanel1
            // 
            customPanel1.AutoScroll = true;
            customPanel1.Controls.Add(panel4);
            customPanel1.Controls.Add(searchspriteTextbox);
            customPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            customPanel1.Location = new System.Drawing.Point(0, 0);
            customPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new System.Drawing.Size(342, 783);
            customPanel1.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.Controls.Add(spritesView1);
            panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            panel4.Location = new System.Drawing.Point(0, 23);
            panel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(342, 760);
            panel4.TabIndex = 24;
            // 
            // spritesView1
            // 
            spritesView1.Dock = System.Windows.Forms.DockStyle.Top;
            spritesView1.Location = new System.Drawing.Point(0, 0);
            spritesView1.Margin = new System.Windows.Forms.Padding(7);
            spritesView1.Name = "spritesView1";
            spritesView1.Size = new System.Drawing.Size(342, 432);
            spritesView1.TabIndex = 0;
            spritesView1.SelectedIndexChanged += spritesView1_SelectedIndexChanged;
            // 
            // searchspriteTextbox
            // 
            searchspriteTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            searchspriteTextbox.Location = new System.Drawing.Point(0, 0);
            searchspriteTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            searchspriteTextbox.Name = "searchspriteTextbox";
            searchspriteTextbox.Size = new System.Drawing.Size(342, 23);
            searchspriteTextbox.TabIndex = 1;
            searchspriteTextbox.TextChanged += searchspriteTextbox_TextChanged;
            // 
            // edit8x8
            // 
            edit8x8.AutoScroll = true;
            edit8x8.Controls.Add(edit8x8Panel);
            edit8x8.Controls.Add(groupBox1);
            edit8x8.Location = new System.Drawing.Point(4, 24);
            edit8x8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            edit8x8.Name = "edit8x8";
            edit8x8.Size = new System.Drawing.Size(342, 783);
            edit8x8.TabIndex = 11;
            edit8x8.Text = "8x8 tiles";
            edit8x8.UseVisualStyleBackColor = true;
            // 
            // edit8x8Panel
            // 
            edit8x8Panel.AutoScroll = true;
            edit8x8Panel.Controls.Add(editBox8x8);
            edit8x8Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            edit8x8Panel.Location = new System.Drawing.Point(0, 0);
            edit8x8Panel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            edit8x8Panel.Name = "edit8x8Panel";
            edit8x8Panel.Size = new System.Drawing.Size(342, 548);
            edit8x8Panel.TabIndex = 2;
            // 
            // editBox8x8
            // 
            editBox8x8.Location = new System.Drawing.Point(9, 5);
            editBox8x8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            editBox8x8.Name = "editBox8x8";
            editBox8x8.Size = new System.Drawing.Size(299, 1182);
            editBox8x8.TabIndex = 0;
            editBox8x8.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(edit8x8palettebox);
            groupBox1.Controls.Add(edit8x8myCheckbox);
            groupBox1.Controls.Add(edit8x8mxCheckbox);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            groupBox1.Location = new System.Drawing.Point(0, 548);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(342, 235);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tile properties";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(89, 22);
            checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(64, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Priority";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // edit8x8palettebox
            // 
            edit8x8palettebox.Location = new System.Drawing.Point(7, 75);
            edit8x8palettebox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            edit8x8palettebox.Name = "edit8x8palettebox";
            edit8x8palettebox.Size = new System.Drawing.Size(299, 148);
            edit8x8palettebox.TabIndex = 2;
            edit8x8palettebox.TabStop = false;
            edit8x8palettebox.Paint += Edit8x8palettebox_Paint;
            // 
            // edit8x8myCheckbox
            // 
            edit8x8myCheckbox.AutoSize = true;
            edit8x8myCheckbox.Location = new System.Drawing.Point(9, 48);
            edit8x8myCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            edit8x8myCheckbox.Name = "edit8x8myCheckbox";
            edit8x8myCheckbox.Size = new System.Drawing.Size(55, 19);
            edit8x8myCheckbox.TabIndex = 1;
            edit8x8myCheckbox.Text = "Flip Y";
            edit8x8myCheckbox.UseVisualStyleBackColor = true;
            // 
            // edit8x8mxCheckbox
            // 
            edit8x8mxCheckbox.AutoSize = true;
            edit8x8mxCheckbox.Location = new System.Drawing.Point(9, 22);
            edit8x8mxCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            edit8x8mxCheckbox.Name = "edit8x8mxCheckbox";
            edit8x8mxCheckbox.Size = new System.Drawing.Size(55, 19);
            edit8x8mxCheckbox.TabIndex = 0;
            edit8x8mxCheckbox.Text = "Flip X";
            edit8x8mxCheckbox.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label20.Location = new System.Drawing.Point(352, 7);
            label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(53, 15);
            label20.TabIndex = 29;
            label20.Text = "Message";
            // 
            // roomProperty_pit
            // 
            roomProperty_pit.AutoSize = true;
            roomProperty_pit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            roomProperty_pit.Location = new System.Drawing.Point(348, 55);
            roomProperty_pit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            roomProperty_pit.Name = "roomProperty_pit";
            roomProperty_pit.Size = new System.Drawing.Size(86, 19);
            roomProperty_pit.TabIndex = 28;
            roomProperty_pit.Text = "Pit damage";
            roomProperty_pit.UseVisualStyleBackColor = true;
            roomProperty_pit.CheckedChanged += RoomPropertyChanged;
            // 
            // roomProperty_tag2
            // 
            roomProperty_tag2.BackColor = System.Drawing.SystemColors.Window;
            roomProperty_tag2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            roomProperty_tag2.DropDownWidth = 200;
            roomProperty_tag2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            roomProperty_tag2.FormattingEnabled = true;
            roomProperty_tag2.Location = new System.Drawing.Point(288, 117);
            roomProperty_tag2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            roomProperty_tag2.Name = "roomProperty_tag2";
            roomProperty_tag2.Size = new System.Drawing.Size(122, 23);
            roomProperty_tag2.TabIndex = 22;
            roomProperty_tag2.SelectedIndexChanged += RoomPropertyChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label12.Location = new System.Drawing.Point(285, 98);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(35, 15);
            label12.TabIndex = 21;
            label12.Text = "Tag 2";
            // 
            // roomProperty_tag1
            // 
            roomProperty_tag1.BackColor = System.Drawing.SystemColors.Window;
            roomProperty_tag1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            roomProperty_tag1.DropDownWidth = 200;
            roomProperty_tag1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            roomProperty_tag1.FormattingEnabled = true;
            roomProperty_tag1.Location = new System.Drawing.Point(159, 117);
            roomProperty_tag1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            roomProperty_tag1.Name = "roomProperty_tag1";
            roomProperty_tag1.Size = new System.Drawing.Size(122, 23);
            roomProperty_tag1.TabIndex = 20;
            roomProperty_tag1.SelectedIndexChanged += RoomPropertyChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label13.Location = new System.Drawing.Point(155, 98);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(35, 15);
            label13.TabIndex = 19;
            label13.Text = "Tag 1";
            // 
            // roomProperty_effect
            // 
            roomProperty_effect.BackColor = System.Drawing.SystemColors.Window;
            roomProperty_effect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            roomProperty_effect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            roomProperty_effect.FormattingEnabled = true;
            roomProperty_effect.Location = new System.Drawing.Point(7, 70);
            roomProperty_effect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            roomProperty_effect.Name = "roomProperty_effect";
            roomProperty_effect.Size = new System.Drawing.Size(144, 23);
            roomProperty_effect.TabIndex = 18;
            roomProperty_effect.SelectedIndexChanged += RoomPropertyChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label11.Location = new System.Drawing.Point(4, 52);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(78, 15);
            label11.TabIndex = 17;
            label11.Text = "Layer 2 mode";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label10.Location = new System.Drawing.Point(285, 7);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(55, 15);
            label10.TabIndex = 15;
            label10.Text = "Sprite set";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label9.Location = new System.Drawing.Point(155, 7);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(43, 15);
            label9.TabIndex = 13;
            label9.Text = "Layout";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label8.Location = new System.Drawing.Point(285, 52);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(43, 15);
            label8.TabIndex = 12;
            label8.Text = "Palette";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label6.Location = new System.Drawing.Point(218, 7);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(51, 15);
            label6.TabIndex = 11;
            label6.Text = "Blockset";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label5.Location = new System.Drawing.Point(218, 52);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(43, 15);
            label5.TabIndex = 6;
            label5.Text = "Floor 2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label4.Location = new System.Drawing.Point(155, 52);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(43, 15);
            label4.TabIndex = 5;
            label4.Text = "Floor 1";
            // 
            // roomProperty_collision
            // 
            roomProperty_collision.BackColor = System.Drawing.SystemColors.Window;
            roomProperty_collision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            roomProperty_collision.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            roomProperty_collision.FormattingEnabled = true;
            roomProperty_collision.Location = new System.Drawing.Point(7, 117);
            roomProperty_collision.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            roomProperty_collision.Name = "roomProperty_collision";
            roomProperty_collision.Size = new System.Drawing.Size(144, 23);
            roomProperty_collision.TabIndex = 4;
            roomProperty_collision.SelectedIndexChanged += RoomPropertyChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label3.Location = new System.Drawing.Point(4, 98);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(53, 15);
            label3.TabIndex = 3;
            label3.Text = "Collision";
            // 
            // roomProperty_bg2
            // 
            roomProperty_bg2.BackColor = System.Drawing.SystemColors.Window;
            roomProperty_bg2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            roomProperty_bg2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            roomProperty_bg2.FormattingEnabled = true;
            roomProperty_bg2.Location = new System.Drawing.Point(7, 25);
            roomProperty_bg2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            roomProperty_bg2.Name = "roomProperty_bg2";
            roomProperty_bg2.Size = new System.Drawing.Size(144, 23);
            roomProperty_bg2.TabIndex = 2;
            roomProperty_bg2.SelectedIndexChanged += RoomPropertyChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label2.Location = new System.Drawing.Point(4, 7);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Layer 2 type";
            // 
            // splitter1
            // 
            splitter1.Location = new System.Drawing.Point(350, 49);
            splitter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitter1.Name = "splitter1";
            splitter1.Size = new System.Drawing.Size(4, 811);
            splitter1.TabIndex = 15;
            splitter1.TabStop = false;
            // 
            // headerGroupbox
            // 
            headerGroupbox.BackColor = System.Drawing.SystemColors.Control;
            headerGroupbox.Controls.Add(overlayPanel);
            headerGroupbox.Controls.Add(selectedGroupbox);
            headerGroupbox.Controls.Add(roomHeaderPanel);
            headerGroupbox.Controls.Add(litCheckbox);
            headerGroupbox.Controls.Add(doorselectPanel);
            headerGroupbox.Controls.Add(potitemobjectPanel);
            headerGroupbox.Controls.Add(spritepropertyPanel);
            headerGroupbox.Controls.Add(collisionMapPanel);
            headerGroupbox.Dock = System.Windows.Forms.DockStyle.Top;
            headerGroupbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            headerGroupbox.Location = new System.Drawing.Point(354, 49);
            headerGroupbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            headerGroupbox.Name = "headerGroupbox";
            headerGroupbox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            headerGroupbox.Size = new System.Drawing.Size(1019, 170);
            headerGroupbox.TabIndex = 0;
            headerGroupbox.TabStop = false;
            headerGroupbox.Text = "Room header";
            // 
            // overlayPanel
            // 
            overlayPanel.BackColor = System.Drawing.SystemColors.Control;
            overlayPanel.Controls.Add(overlayCombobox);
            overlayPanel.Controls.Add(label39);
            overlayPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            overlayPanel.Location = new System.Drawing.Point(592, 18);
            overlayPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            overlayPanel.Name = "overlayPanel";
            overlayPanel.Size = new System.Drawing.Size(424, 58);
            overlayPanel.TabIndex = 22;
            overlayPanel.Visible = false;
            // 
            // overlayCombobox
            // 
            overlayCombobox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            overlayCombobox.BackColor = System.Drawing.SystemColors.Window;
            overlayCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            overlayCombobox.FormattingEnabled = true;
            overlayCombobox.Items.AddRange(new object[] { "Holes 0x00", "Holes 0x01", "Holes 0x02", "Holes 0x03", "Holes 0x04", "Holes 0x05", "Holes 0x06", "Holes 0x07", "Holes 0x08", "Holes 0x09", "Holes 0x0A", "Holes 0x0B", "Holes 0x0C", "Holes 0x0D", "Holes 0x0E", "Holes 0x0F", "Holes 0x10", "Holes 0x11", "Holes 0x12", "Dam Water flood overlay" });
            overlayCombobox.Location = new System.Drawing.Point(7, 27);
            overlayCombobox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            overlayCombobox.Name = "overlayCombobox";
            overlayCombobox.Size = new System.Drawing.Size(405, 23);
            overlayCombobox.TabIndex = 8;
            overlayCombobox.SelectedIndexChanged += overlayCombobox_SelectedIndexChanged;
            // 
            // label39
            // 
            label39.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label39.AutoSize = true;
            label39.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label39.Location = new System.Drawing.Point(4, 9);
            label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label39.Name = "label39";
            label39.Size = new System.Drawing.Size(100, 15);
            label39.TabIndex = 9;
            label39.Text = "Overlay Selected :";
            // 
            // selectedGroupbox
            // 
            selectedGroupbox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            selectedGroupbox.BackColor = System.Drawing.SystemColors.Control;
            selectedGroupbox.Controls.Add(SelectedObjectDataHEX);
            selectedGroupbox.Controls.Add(label17);
            selectedGroupbox.Controls.Add(SelectedObjectDataLayer);
            selectedGroupbox.Controls.Add(SelectedObjectDataSize);
            selectedGroupbox.Controls.Add(SelectedObjectDataY);
            selectedGroupbox.Controls.Add(SelectedObjectDataX);
            selectedGroupbox.Controls.Add(object_size_label);
            selectedGroupbox.Controls.Add(object_x_label);
            selectedGroupbox.Controls.Add(object_y_label);
            selectedGroupbox.Controls.Add(object_layer_label);
            selectedGroupbox.Location = new System.Drawing.Point(593, 83);
            selectedGroupbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            selectedGroupbox.Name = "selectedGroupbox";
            selectedGroupbox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            selectedGroupbox.Size = new System.Drawing.Size(419, 83);
            selectedGroupbox.TabIndex = 21;
            selectedGroupbox.TabStop = false;
            selectedGroupbox.Text = "Selected object";
            // 
            // SelectedObjectDataHEX
            // 
            SelectedObjectDataHEX.AutoSize = true;
            SelectedObjectDataHEX.Location = new System.Drawing.Point(58, 61);
            SelectedObjectDataHEX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            SelectedObjectDataHEX.Name = "SelectedObjectDataHEX";
            SelectedObjectDataHEX.Size = new System.Drawing.Size(12, 15);
            SelectedObjectDataHEX.TabIndex = 12;
            SelectedObjectDataHEX.Text = "-";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(4, 61);
            label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(31, 15);
            label17.TabIndex = 11;
            label17.Text = "Data";
            // 
            // SelectedObjectDataLayer
            // 
            SelectedObjectDataLayer.AutoSize = true;
            SelectedObjectDataLayer.Location = new System.Drawing.Point(119, 39);
            SelectedObjectDataLayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            SelectedObjectDataLayer.Name = "SelectedObjectDataLayer";
            SelectedObjectDataLayer.Size = new System.Drawing.Size(12, 15);
            SelectedObjectDataLayer.TabIndex = 10;
            SelectedObjectDataLayer.Text = "-";
            // 
            // SelectedObjectDataSize
            // 
            SelectedObjectDataSize.AutoSize = true;
            SelectedObjectDataSize.Location = new System.Drawing.Point(119, 20);
            SelectedObjectDataSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            SelectedObjectDataSize.Name = "SelectedObjectDataSize";
            SelectedObjectDataSize.Size = new System.Drawing.Size(12, 15);
            SelectedObjectDataSize.TabIndex = 9;
            SelectedObjectDataSize.Text = "-";
            // 
            // SelectedObjectDataY
            // 
            SelectedObjectDataY.AutoSize = true;
            SelectedObjectDataY.Location = new System.Drawing.Point(24, 40);
            SelectedObjectDataY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            SelectedObjectDataY.Name = "SelectedObjectDataY";
            SelectedObjectDataY.Size = new System.Drawing.Size(12, 15);
            SelectedObjectDataY.TabIndex = 8;
            SelectedObjectDataY.Text = "-";
            // 
            // SelectedObjectDataX
            // 
            SelectedObjectDataX.AutoSize = true;
            SelectedObjectDataX.Location = new System.Drawing.Point(24, 18);
            SelectedObjectDataX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            SelectedObjectDataX.Name = "SelectedObjectDataX";
            SelectedObjectDataX.Size = new System.Drawing.Size(12, 15);
            SelectedObjectDataX.TabIndex = 7;
            SelectedObjectDataX.Text = "-";
            // 
            // object_size_label
            // 
            object_size_label.AutoSize = true;
            object_size_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            object_size_label.Location = new System.Drawing.Point(77, 18);
            object_size_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            object_size_label.Name = "object_size_label";
            object_size_label.Size = new System.Drawing.Size(30, 15);
            object_size_label.TabIndex = 5;
            object_size_label.Text = "Size:";
            // 
            // object_x_label
            // 
            object_x_label.AutoSize = true;
            object_x_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            object_x_label.Location = new System.Drawing.Point(4, 18);
            object_x_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            object_x_label.Name = "object_x_label";
            object_x_label.Size = new System.Drawing.Size(17, 15);
            object_x_label.TabIndex = 1;
            object_x_label.Text = "X:";
            // 
            // object_y_label
            // 
            object_y_label.AutoSize = true;
            object_y_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            object_y_label.Location = new System.Drawing.Point(4, 40);
            object_y_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            object_y_label.Name = "object_y_label";
            object_y_label.Size = new System.Drawing.Size(17, 15);
            object_y_label.TabIndex = 3;
            object_y_label.Text = "Y:";
            // 
            // object_layer_label
            // 
            object_layer_label.AutoSize = true;
            object_layer_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            object_layer_label.Location = new System.Drawing.Point(70, 39);
            object_layer_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            object_layer_label.Name = "object_layer_label";
            object_layer_label.Size = new System.Drawing.Size(38, 15);
            object_layer_label.TabIndex = 6;
            object_layer_label.Text = "Layer:";
            // 
            // roomHeaderPanel
            // 
            roomHeaderPanel.BackColor = System.Drawing.SystemColors.Control;
            roomHeaderPanel.Controls.Add(RoomProperty_DestinationStair4);
            roomHeaderPanel.Controls.Add(RoomProperty_DestinationStair3);
            roomHeaderPanel.Controls.Add(RoomProperty_DestinationStair2);
            roomHeaderPanel.Controls.Add(RoomProperty_DestinationStair1);
            roomHeaderPanel.Controls.Add(RoomProperty_DestinationPit);
            roomHeaderPanel.Controls.Add(RoomProperty_MessageID);
            roomHeaderPanel.Controls.Add(RoomProperty_SpriteSet);
            roomHeaderPanel.Controls.Add(RoomProperty_Palette);
            roomHeaderPanel.Controls.Add(RoomProperty_Floor2);
            roomHeaderPanel.Controls.Add(RoomProperty_Floor1);
            roomHeaderPanel.Controls.Add(RoomProperty_Blockset);
            roomHeaderPanel.Controls.Add(RoomProperty_Layout);
            roomHeaderPanel.Controls.Add(label16);
            roomHeaderPanel.Controls.Add(label15);
            roomHeaderPanel.Controls.Add(label7);
            roomHeaderPanel.Controls.Add(label1);
            roomHeaderPanel.Controls.Add(bg2checkbox5);
            roomHeaderPanel.Controls.Add(label33);
            roomHeaderPanel.Controls.Add(label14);
            roomHeaderPanel.Controls.Add(label28);
            roomHeaderPanel.Controls.Add(bg2checkbox4);
            roomHeaderPanel.Controls.Add(bg2checkbox3);
            roomHeaderPanel.Controls.Add(bg2checkbox2);
            roomHeaderPanel.Controls.Add(bg2checkbox1);
            roomHeaderPanel.Controls.Add(label11);
            roomHeaderPanel.Controls.Add(roomProperty_effect);
            roomHeaderPanel.Controls.Add(roomProperty_sortsprite);
            roomHeaderPanel.Controls.Add(label2);
            roomHeaderPanel.Controls.Add(roomProperty_bg2);
            roomHeaderPanel.Controls.Add(label3);
            roomHeaderPanel.Controls.Add(roomProperty_collision);
            roomHeaderPanel.Controls.Add(label9);
            roomHeaderPanel.Controls.Add(roomProperty_pit);
            roomHeaderPanel.Controls.Add(label10);
            roomHeaderPanel.Controls.Add(label6);
            roomHeaderPanel.Controls.Add(label5);
            roomHeaderPanel.Controls.Add(label4);
            roomHeaderPanel.Controls.Add(label8);
            roomHeaderPanel.Controls.Add(label13);
            roomHeaderPanel.Controls.Add(label20);
            roomHeaderPanel.Controls.Add(roomProperty_tag1);
            roomHeaderPanel.Controls.Add(label12);
            roomHeaderPanel.Controls.Add(roomProperty_tag2);
            roomHeaderPanel.Enabled = false;
            roomHeaderPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            roomHeaderPanel.Location = new System.Drawing.Point(14, 18);
            roomHeaderPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            roomHeaderPanel.Name = "roomHeaderPanel";
            roomHeaderPanel.Size = new System.Drawing.Size(572, 148);
            roomHeaderPanel.TabIndex = 20;
            // 
            // RoomProperty_DestinationStair4
            // 
            RoomProperty_DestinationStair4.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RoomProperty_DestinationStair4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RoomProperty_DestinationStair4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            RoomProperty_DestinationStair4.Decimal = false;
            RoomProperty_DestinationStair4.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            RoomProperty_DestinationStair4.ForeColor = System.Drawing.Color.White;
            RoomProperty_DestinationStair4.HexValue = 0;
            RoomProperty_DestinationStair4.Location = new System.Drawing.Point(499, 118);
            RoomProperty_DestinationStair4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RoomProperty_DestinationStair4.MaxLength = 2;
            RoomProperty_DestinationStair4.MaxValue = 255;
            RoomProperty_DestinationStair4.MinValue = 0;
            RoomProperty_DestinationStair4.Name = "RoomProperty_DestinationStair4";
            RoomProperty_DestinationStair4.Size = new System.Drawing.Size(28, 23);
            RoomProperty_DestinationStair4.TabIndex = 97;
            RoomProperty_DestinationStair4.Text = "00";
            RoomProperty_DestinationStair4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            RoomProperty_DestinationStair4.TextChanged += RoomPropertyChanged;
            // 
            // RoomProperty_DestinationStair3
            // 
            RoomProperty_DestinationStair3.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RoomProperty_DestinationStair3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RoomProperty_DestinationStair3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            RoomProperty_DestinationStair3.Decimal = false;
            RoomProperty_DestinationStair3.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            RoomProperty_DestinationStair3.ForeColor = System.Drawing.Color.White;
            RoomProperty_DestinationStair3.HexValue = 0;
            RoomProperty_DestinationStair3.Location = new System.Drawing.Point(499, 95);
            RoomProperty_DestinationStair3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RoomProperty_DestinationStair3.MaxLength = 2;
            RoomProperty_DestinationStair3.MaxValue = 255;
            RoomProperty_DestinationStair3.MinValue = 0;
            RoomProperty_DestinationStair3.Name = "RoomProperty_DestinationStair3";
            RoomProperty_DestinationStair3.Size = new System.Drawing.Size(28, 23);
            RoomProperty_DestinationStair3.TabIndex = 96;
            RoomProperty_DestinationStair3.Text = "00";
            RoomProperty_DestinationStair3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            RoomProperty_DestinationStair3.TextChanged += RoomPropertyChanged;
            // 
            // RoomProperty_DestinationStair2
            // 
            RoomProperty_DestinationStair2.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RoomProperty_DestinationStair2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RoomProperty_DestinationStair2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            RoomProperty_DestinationStair2.Decimal = false;
            RoomProperty_DestinationStair2.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            RoomProperty_DestinationStair2.ForeColor = System.Drawing.Color.White;
            RoomProperty_DestinationStair2.HexValue = 0;
            RoomProperty_DestinationStair2.Location = new System.Drawing.Point(499, 72);
            RoomProperty_DestinationStair2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RoomProperty_DestinationStair2.MaxLength = 2;
            RoomProperty_DestinationStair2.MaxValue = 255;
            RoomProperty_DestinationStair2.MinValue = 0;
            RoomProperty_DestinationStair2.Name = "RoomProperty_DestinationStair2";
            RoomProperty_DestinationStair2.Size = new System.Drawing.Size(28, 23);
            RoomProperty_DestinationStair2.TabIndex = 95;
            RoomProperty_DestinationStair2.Text = "00";
            RoomProperty_DestinationStair2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            RoomProperty_DestinationStair2.TextChanged += RoomPropertyChanged;
            // 
            // RoomProperty_DestinationStair1
            // 
            RoomProperty_DestinationStair1.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RoomProperty_DestinationStair1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RoomProperty_DestinationStair1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            RoomProperty_DestinationStair1.Decimal = false;
            RoomProperty_DestinationStair1.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            RoomProperty_DestinationStair1.ForeColor = System.Drawing.Color.White;
            RoomProperty_DestinationStair1.HexValue = 0;
            RoomProperty_DestinationStair1.Location = new System.Drawing.Point(499, 48);
            RoomProperty_DestinationStair1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RoomProperty_DestinationStair1.MaxLength = 2;
            RoomProperty_DestinationStair1.MaxValue = 255;
            RoomProperty_DestinationStair1.MinValue = 0;
            RoomProperty_DestinationStair1.Name = "RoomProperty_DestinationStair1";
            RoomProperty_DestinationStair1.Size = new System.Drawing.Size(28, 23);
            RoomProperty_DestinationStair1.TabIndex = 94;
            RoomProperty_DestinationStair1.Text = "00";
            RoomProperty_DestinationStair1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            RoomProperty_DestinationStair1.TextChanged += RoomPropertyChanged;
            // 
            // RoomProperty_DestinationPit
            // 
            RoomProperty_DestinationPit.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RoomProperty_DestinationPit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RoomProperty_DestinationPit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            RoomProperty_DestinationPit.Decimal = false;
            RoomProperty_DestinationPit.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            RoomProperty_DestinationPit.ForeColor = System.Drawing.Color.White;
            RoomProperty_DestinationPit.HexValue = 0;
            RoomProperty_DestinationPit.Location = new System.Drawing.Point(499, 25);
            RoomProperty_DestinationPit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RoomProperty_DestinationPit.MaxLength = 2;
            RoomProperty_DestinationPit.MaxValue = 255;
            RoomProperty_DestinationPit.MinValue = 0;
            RoomProperty_DestinationPit.Name = "RoomProperty_DestinationPit";
            RoomProperty_DestinationPit.Size = new System.Drawing.Size(28, 23);
            RoomProperty_DestinationPit.TabIndex = 93;
            RoomProperty_DestinationPit.Text = "00";
            RoomProperty_DestinationPit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            RoomProperty_DestinationPit.TextChanged += RoomPropertyChanged;
            // 
            // RoomProperty_MessageID
            // 
            RoomProperty_MessageID.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RoomProperty_MessageID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RoomProperty_MessageID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            RoomProperty_MessageID.Decimal = false;
            RoomProperty_MessageID.Digits = Gui.ExtraForms.Hexbox.HexDigits.Three;
            RoomProperty_MessageID.ForeColor = System.Drawing.Color.White;
            RoomProperty_MessageID.HexValue = 0;
            RoomProperty_MessageID.Location = new System.Drawing.Point(350, 25);
            RoomProperty_MessageID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RoomProperty_MessageID.MaxLength = 3;
            RoomProperty_MessageID.MaxValue = 4095;
            RoomProperty_MessageID.MinValue = 0;
            RoomProperty_MessageID.Name = "RoomProperty_MessageID";
            RoomProperty_MessageID.Size = new System.Drawing.Size(57, 23);
            RoomProperty_MessageID.TabIndex = 92;
            RoomProperty_MessageID.Text = "000";
            RoomProperty_MessageID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            RoomProperty_MessageID.TextChanged += RoomPropertyChanged;
            // 
            // RoomProperty_SpriteSet
            // 
            RoomProperty_SpriteSet.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RoomProperty_SpriteSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RoomProperty_SpriteSet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            RoomProperty_SpriteSet.Decimal = false;
            RoomProperty_SpriteSet.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            RoomProperty_SpriteSet.ForeColor = System.Drawing.Color.White;
            RoomProperty_SpriteSet.HexValue = 0;
            RoomProperty_SpriteSet.Location = new System.Drawing.Point(286, 25);
            RoomProperty_SpriteSet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RoomProperty_SpriteSet.MaxLength = 2;
            RoomProperty_SpriteSet.MaxValue = 255;
            RoomProperty_SpriteSet.MinValue = 0;
            RoomProperty_SpriteSet.Name = "RoomProperty_SpriteSet";
            RoomProperty_SpriteSet.Size = new System.Drawing.Size(57, 23);
            RoomProperty_SpriteSet.TabIndex = 91;
            RoomProperty_SpriteSet.Text = "00";
            RoomProperty_SpriteSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            RoomProperty_SpriteSet.TextChanged += RoomPropertyChanged;
            // 
            // RoomProperty_Palette
            // 
            RoomProperty_Palette.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RoomProperty_Palette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RoomProperty_Palette.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            RoomProperty_Palette.Decimal = false;
            RoomProperty_Palette.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            RoomProperty_Palette.ForeColor = System.Drawing.Color.White;
            RoomProperty_Palette.HexValue = 0;
            RoomProperty_Palette.Location = new System.Drawing.Point(287, 72);
            RoomProperty_Palette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RoomProperty_Palette.MaxLength = 2;
            RoomProperty_Palette.MaxValue = 255;
            RoomProperty_Palette.MinValue = 0;
            RoomProperty_Palette.Name = "RoomProperty_Palette";
            RoomProperty_Palette.Size = new System.Drawing.Size(57, 23);
            RoomProperty_Palette.TabIndex = 90;
            RoomProperty_Palette.Text = "00";
            RoomProperty_Palette.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            RoomProperty_Palette.TextChanged += RoomPropertyChanged;
            // 
            // RoomProperty_Floor2
            // 
            RoomProperty_Floor2.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RoomProperty_Floor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RoomProperty_Floor2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            RoomProperty_Floor2.Decimal = false;
            RoomProperty_Floor2.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            RoomProperty_Floor2.ForeColor = System.Drawing.Color.White;
            RoomProperty_Floor2.HexValue = 0;
            RoomProperty_Floor2.Location = new System.Drawing.Point(222, 72);
            RoomProperty_Floor2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RoomProperty_Floor2.MaxLength = 1;
            RoomProperty_Floor2.MaxValue = 15;
            RoomProperty_Floor2.MinValue = 0;
            RoomProperty_Floor2.Name = "RoomProperty_Floor2";
            RoomProperty_Floor2.Size = new System.Drawing.Size(57, 23);
            RoomProperty_Floor2.TabIndex = 89;
            RoomProperty_Floor2.Text = "00";
            RoomProperty_Floor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            RoomProperty_Floor2.TextChanged += RoomPropertyChanged;
            // 
            // RoomProperty_Floor1
            // 
            RoomProperty_Floor1.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RoomProperty_Floor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RoomProperty_Floor1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            RoomProperty_Floor1.Decimal = false;
            RoomProperty_Floor1.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            RoomProperty_Floor1.ForeColor = System.Drawing.Color.White;
            RoomProperty_Floor1.HexValue = 0;
            RoomProperty_Floor1.Location = new System.Drawing.Point(158, 72);
            RoomProperty_Floor1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RoomProperty_Floor1.MaxLength = 2;
            RoomProperty_Floor1.MaxValue = 15;
            RoomProperty_Floor1.MinValue = 0;
            RoomProperty_Floor1.Name = "RoomProperty_Floor1";
            RoomProperty_Floor1.Size = new System.Drawing.Size(57, 23);
            RoomProperty_Floor1.TabIndex = 88;
            RoomProperty_Floor1.Text = "00";
            RoomProperty_Floor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            RoomProperty_Floor1.TextChanged += RoomPropertyChanged;
            // 
            // RoomProperty_Blockset
            // 
            RoomProperty_Blockset.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RoomProperty_Blockset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RoomProperty_Blockset.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            RoomProperty_Blockset.Decimal = false;
            RoomProperty_Blockset.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            RoomProperty_Blockset.ForeColor = System.Drawing.Color.White;
            RoomProperty_Blockset.HexValue = 0;
            RoomProperty_Blockset.Location = new System.Drawing.Point(222, 25);
            RoomProperty_Blockset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RoomProperty_Blockset.MaxLength = 2;
            RoomProperty_Blockset.MaxValue = 255;
            RoomProperty_Blockset.MinValue = 0;
            RoomProperty_Blockset.Name = "RoomProperty_Blockset";
            RoomProperty_Blockset.Size = new System.Drawing.Size(57, 23);
            RoomProperty_Blockset.TabIndex = 87;
            RoomProperty_Blockset.Text = "00";
            RoomProperty_Blockset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            RoomProperty_Blockset.TextChanged += RoomPropertyChanged;
            // 
            // RoomProperty_Layout
            // 
            RoomProperty_Layout.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            RoomProperty_Layout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RoomProperty_Layout.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            RoomProperty_Layout.Decimal = false;
            RoomProperty_Layout.Digits = Gui.ExtraForms.Hexbox.HexDigits.One;
            RoomProperty_Layout.ForeColor = System.Drawing.Color.White;
            RoomProperty_Layout.HexValue = 0;
            RoomProperty_Layout.Location = new System.Drawing.Point(158, 25);
            RoomProperty_Layout.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RoomProperty_Layout.MaxLength = 1;
            RoomProperty_Layout.MaxValue = 7;
            RoomProperty_Layout.MinValue = 0;
            RoomProperty_Layout.Name = "RoomProperty_Layout";
            RoomProperty_Layout.Size = new System.Drawing.Size(57, 23);
            RoomProperty_Layout.TabIndex = 86;
            RoomProperty_Layout.Text = "0";
            RoomProperty_Layout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            RoomProperty_Layout.TextChanged += RoomPropertyChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label16.Location = new System.Drawing.Point(531, 7);
            label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(28, 15);
            label16.TabIndex = 85;
            label16.Text = "BG2";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label15.Location = new System.Drawing.Point(453, 7);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(72, 15);
            label15.TabIndex = 84;
            label15.Text = "Destinations";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(453, 125);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(39, 15);
            label7.TabIndex = 83;
            label7.Text = "Stair 4";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(453, 100);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 15);
            label1.TabIndex = 82;
            label1.Text = "Stair 3";
            // 
            // bg2checkbox5
            // 
            bg2checkbox5.AutoSize = true;
            bg2checkbox5.Location = new System.Drawing.Point(539, 123);
            bg2checkbox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            bg2checkbox5.Name = "bg2checkbox5";
            bg2checkbox5.Size = new System.Drawing.Size(15, 14);
            bg2checkbox5.TabIndex = 78;
            bg2checkbox5.UseVisualStyleBackColor = true;
            bg2checkbox5.CheckedChanged += RoomPropertyChanged;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new System.Drawing.Point(453, 76);
            label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(39, 15);
            label33.TabIndex = 81;
            label33.Text = "Stair 2";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(474, 28);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(21, 15);
            label14.TabIndex = 79;
            label14.Text = "Pit";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(453, 52);
            label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(39, 15);
            label28.TabIndex = 80;
            label28.Text = "Stair 1";
            // 
            // bg2checkbox4
            // 
            bg2checkbox4.AutoSize = true;
            bg2checkbox4.Location = new System.Drawing.Point(539, 100);
            bg2checkbox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            bg2checkbox4.Name = "bg2checkbox4";
            bg2checkbox4.Size = new System.Drawing.Size(15, 14);
            bg2checkbox4.TabIndex = 77;
            bg2checkbox4.UseVisualStyleBackColor = true;
            bg2checkbox4.CheckedChanged += RoomPropertyChanged;
            // 
            // bg2checkbox3
            // 
            bg2checkbox3.AutoSize = true;
            bg2checkbox3.Location = new System.Drawing.Point(539, 76);
            bg2checkbox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            bg2checkbox3.Name = "bg2checkbox3";
            bg2checkbox3.Size = new System.Drawing.Size(15, 14);
            bg2checkbox3.TabIndex = 76;
            bg2checkbox3.UseVisualStyleBackColor = true;
            bg2checkbox3.CheckedChanged += RoomPropertyChanged;
            // 
            // bg2checkbox2
            // 
            bg2checkbox2.AutoSize = true;
            bg2checkbox2.Location = new System.Drawing.Point(539, 52);
            bg2checkbox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            bg2checkbox2.Name = "bg2checkbox2";
            bg2checkbox2.Size = new System.Drawing.Size(15, 14);
            bg2checkbox2.TabIndex = 75;
            bg2checkbox2.UseVisualStyleBackColor = true;
            bg2checkbox2.CheckedChanged += RoomPropertyChanged;
            // 
            // bg2checkbox1
            // 
            bg2checkbox1.AutoSize = true;
            bg2checkbox1.Location = new System.Drawing.Point(539, 28);
            bg2checkbox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            bg2checkbox1.Name = "bg2checkbox1";
            bg2checkbox1.Size = new System.Drawing.Size(15, 14);
            bg2checkbox1.TabIndex = 74;
            bg2checkbox1.UseVisualStyleBackColor = true;
            bg2checkbox1.CheckedChanged += RoomPropertyChanged;
            // 
            // litCheckbox
            // 
            litCheckbox.AutoSize = true;
            litCheckbox.Location = new System.Drawing.Point(600, 53);
            litCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            litCheckbox.Name = "litCheckbox";
            litCheckbox.Size = new System.Drawing.Size(67, 19);
            litCheckbox.TabIndex = 19;
            litCheckbox.Text = "Prelight";
            litCheckbox.UseVisualStyleBackColor = true;
            litCheckbox.Visible = false;
            litCheckbox.CheckedChanged += litCheckbox_CheckedChanged;
            // 
            // doorselectPanel
            // 
            doorselectPanel.BackColor = System.Drawing.SystemColors.Control;
            doorselectPanel.Controls.Add(comboBox2);
            doorselectPanel.Controls.Add(label25);
            doorselectPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            doorselectPanel.Location = new System.Drawing.Point(593, 18);
            doorselectPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            doorselectPanel.Name = "doorselectPanel";
            doorselectPanel.Size = new System.Drawing.Size(424, 58);
            doorselectPanel.TabIndex = 18;
            doorselectPanel.Visible = false;
            // 
            // comboBox2
            // 
            comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            comboBox2.BackColor = System.Drawing.SystemColors.Window;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(7, 30);
            comboBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(405, 23);
            comboBox2.TabIndex = 8;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label25
            // 
            label25.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label25.AutoSize = true;
            label25.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label25.Location = new System.Drawing.Point(4, 9);
            label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(70, 15);
            label25.TabIndex = 9;
            label25.Text = "Door Type : ";
            // 
            // potitemobjectPanel
            // 
            potitemobjectPanel.Controls.Add(selecteditemobjectCombobox);
            potitemobjectPanel.Controls.Add(label31);
            potitemobjectPanel.Location = new System.Drawing.Point(593, 18);
            potitemobjectPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            potitemobjectPanel.Name = "potitemobjectPanel";
            potitemobjectPanel.Size = new System.Drawing.Size(424, 58);
            potitemobjectPanel.TabIndex = 17;
            potitemobjectPanel.Visible = false;
            // 
            // selecteditemobjectCombobox
            // 
            selecteditemobjectCombobox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            selecteditemobjectCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            selecteditemobjectCombobox.FormattingEnabled = true;
            selecteditemobjectCombobox.Items.AddRange(new object[] { "Nothing", "Green Rupee", "Rock hoarder", "Bee", "Health pack", "Bomb", "Heart ", "Blue Rupee", "Key", "Arrow", "Bomb", "Heart", "Magic", "Full Magic", "Cucco", "Green Soldier", "Bush Stal", "Blue Soldier", "Landmine", "Heart", "Fairy", "Heart", "Nothing ", "Hole", "Warp", "Staircase", "Bombable", "Switch" });
            selecteditemobjectCombobox.Location = new System.Drawing.Point(7, 30);
            selecteditemobjectCombobox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            selecteditemobjectCombobox.Name = "selecteditemobjectCombobox";
            selecteditemobjectCombobox.Size = new System.Drawing.Size(405, 23);
            selecteditemobjectCombobox.TabIndex = 8;
            selecteditemobjectCombobox.SelectedIndexChanged += selecteditemobjectCombobox_SelectedIndexChanged;
            // 
            // label31
            // 
            label31.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label31.AutoSize = true;
            label31.Location = new System.Drawing.Point(4, 12);
            label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(37, 15);
            label31.TabIndex = 9;
            label31.Text = "Item :";
            // 
            // spritepropertyPanel
            // 
            spritepropertyPanel.Controls.Add(spriteoverlordCheckbox);
            spritepropertyPanel.Controls.Add(label26);
            spritepropertyPanel.Controls.Add(spritesubtypeUpDown);
            spritepropertyPanel.Controls.Add(comboBox1);
            spritepropertyPanel.Controls.Add(label23);
            spritepropertyPanel.Location = new System.Drawing.Point(593, 18);
            spritepropertyPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            spritepropertyPanel.Name = "spritepropertyPanel";
            spritepropertyPanel.Size = new System.Drawing.Size(424, 58);
            spritepropertyPanel.TabIndex = 12;
            spritepropertyPanel.Visible = false;
            // 
            // spriteoverlordCheckbox
            // 
            spriteoverlordCheckbox.AutoSize = true;
            spriteoverlordCheckbox.Location = new System.Drawing.Point(211, 32);
            spriteoverlordCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            spriteoverlordCheckbox.Name = "spriteoverlordCheckbox";
            spriteoverlordCheckbox.Size = new System.Drawing.Size(72, 19);
            spriteoverlordCheckbox.TabIndex = 16;
            spriteoverlordCheckbox.Text = "Overlord";
            spriteoverlordCheckbox.UseVisualStyleBackColor = true;
            spriteoverlordCheckbox.Visible = false;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(4, 12);
            label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(50, 15);
            label26.TabIndex = 15;
            label26.Text = "Subtype";
            // 
            // spritesubtypeUpDown
            // 
            spritesubtypeUpDown.Location = new System.Drawing.Point(7, 31);
            spritesubtypeUpDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            spritesubtypeUpDown.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            spritesubtypeUpDown.Name = "spritesubtypeUpDown";
            spritesubtypeUpDown.Size = new System.Drawing.Size(66, 23);
            spritesubtypeUpDown.TabIndex = 14;
            spritesubtypeUpDown.ValueChanged += SpritesubtypeUpDown_ValueChanged;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            comboBox1.Enabled = false;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "None", "Small key", "Big key" });
            comboBox1.Location = new System.Drawing.Point(89, 30);
            comboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(103, 23);
            comboBox1.TabIndex = 8;
            comboBox1.Text = "None";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // label23
            // 
            label23.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(85, 12);
            label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(54, 15);
            label23.TabIndex = 9;
            label23.Text = "Key drop";
            // 
            // collisionMapPanel
            // 
            collisionMapPanel.BackColor = System.Drawing.SystemColors.Control;
            collisionMapPanel.Controls.Add(tileTypeCombobox);
            collisionMapPanel.Controls.Add(collisionMapLabel);
            collisionMapPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            collisionMapPanel.Location = new System.Drawing.Point(593, 18);
            collisionMapPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            collisionMapPanel.Name = "collisionMapPanel";
            collisionMapPanel.Size = new System.Drawing.Size(424, 58);
            collisionMapPanel.TabIndex = 19;
            collisionMapPanel.Visible = false;
            // 
            // tileTypeCombobox
            // 
            tileTypeCombobox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tileTypeCombobox.BackColor = System.Drawing.SystemColors.Window;
            tileTypeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            tileTypeCombobox.FormattingEnabled = true;
            tileTypeCombobox.Location = new System.Drawing.Point(7, 29);
            tileTypeCombobox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tileTypeCombobox.Name = "tileTypeCombobox";
            tileTypeCombobox.Size = new System.Drawing.Size(405, 23);
            tileTypeCombobox.TabIndex = 8;
            // 
            // collisionMapLabel
            // 
            collisionMapLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            collisionMapLabel.AutoSize = true;
            collisionMapLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            collisionMapLabel.Location = new System.Drawing.Point(4, 9);
            collisionMapLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            collisionMapLabel.Name = "collisionMapLabel";
            collisionMapLabel.Size = new System.Drawing.Size(96, 15);
            collisionMapLabel.TabIndex = 9;
            collisionMapLabel.Text = "Selected tile type";
            // 
            // x256ToolStripMenuItemOW
            // 
            x256ToolStripMenuItemOW.Name = "x256ToolStripMenuItemOW";
            x256ToolStripMenuItemOW.Size = new System.Drawing.Size(32, 19);
            // 
            // uploadVanillaCopyToolStripMenuItem
            // 
            uploadVanillaCopyToolStripMenuItem.Name = "uploadVanillaCopyToolStripMenuItem";
            uploadVanillaCopyToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            uploadVanillaCopyToolStripMenuItem.Text = "Upload Vanilla Copy…";
            uploadVanillaCopyToolStripMenuItem.Click += uploadVanillaCopyToolStripMenuItem_Click;
            // 
            // editorsTabControl
            // 
            editorsTabControl.Controls.Add(dungeonPage);
            editorsTabControl.Controls.Add(overworldPage);
            editorsTabControl.Controls.Add(GfxEditorPage);
            editorsTabControl.Controls.Add(textPage);
            editorsTabControl.Controls.Add(ScreenEditor);
            editorsTabControl.Controls.Add(MusicEditor);
            editorsTabControl.Controls.Add(SpriteEditor);
            editorsTabControl.Controls.Add(NamingEditor);
            editorsTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            editorsTabControl.Enabled = false;
            editorsTabControl.Location = new System.Drawing.Point(0, 860);
            editorsTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            editorsTabControl.Name = "editorsTabControl";
            editorsTabControl.SelectedIndex = 0;
            editorsTabControl.Size = new System.Drawing.Size(1373, 25);
            editorsTabControl.TabIndex = 22;
            editorsTabControl.SelectedIndexChanged += EditorsTabControl_SelectedIndexChanged;
            // 
            // dungeonPage
            // 
            dungeonPage.Location = new System.Drawing.Point(4, 24);
            dungeonPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dungeonPage.Name = "dungeonPage";
            dungeonPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dungeonPage.Size = new System.Drawing.Size(1365, 0);
            dungeonPage.TabIndex = 0;
            dungeonPage.Text = "Dungeon Editor";
            dungeonPage.UseVisualStyleBackColor = true;
            // 
            // overworldPage
            // 
            overworldPage.Location = new System.Drawing.Point(4, 24);
            overworldPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            overworldPage.Name = "overworldPage";
            overworldPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            overworldPage.Size = new System.Drawing.Size(1365, 0);
            overworldPage.TabIndex = 1;
            overworldPage.Text = "Overworld Editor";
            overworldPage.UseVisualStyleBackColor = true;
            // 
            // GfxEditorPage
            // 
            GfxEditorPage.Location = new System.Drawing.Point(4, 24);
            GfxEditorPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            GfxEditorPage.Name = "GfxEditorPage";
            GfxEditorPage.Size = new System.Drawing.Size(1365, 0);
            GfxEditorPage.TabIndex = 2;
            GfxEditorPage.Text = "Graphics Manager";
            GfxEditorPage.UseVisualStyleBackColor = true;
            // 
            // textPage
            // 
            textPage.Location = new System.Drawing.Point(4, 24);
            textPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textPage.Name = "textPage";
            textPage.Size = new System.Drawing.Size(1365, 0);
            textPage.TabIndex = 4;
            textPage.Text = "Text Editor";
            textPage.UseVisualStyleBackColor = true;
            // 
            // ScreenEditor
            // 
            ScreenEditor.Location = new System.Drawing.Point(4, 24);
            ScreenEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ScreenEditor.Name = "ScreenEditor";
            ScreenEditor.Size = new System.Drawing.Size(1365, 0);
            ScreenEditor.TabIndex = 5;
            ScreenEditor.Text = "Screen Editor";
            ScreenEditor.UseVisualStyleBackColor = true;
            // 
            // MusicEditor
            // 
            MusicEditor.Location = new System.Drawing.Point(4, 24);
            MusicEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MusicEditor.Name = "MusicEditor";
            MusicEditor.Size = new System.Drawing.Size(1365, 0);
            MusicEditor.TabIndex = 6;
            MusicEditor.Text = "Music Viewer";
            MusicEditor.UseVisualStyleBackColor = true;
            // 
            // SpriteEditor
            // 
            SpriteEditor.Location = new System.Drawing.Point(4, 24);
            SpriteEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            SpriteEditor.Name = "SpriteEditor";
            SpriteEditor.Size = new System.Drawing.Size(1365, 0);
            SpriteEditor.TabIndex = 7;
            SpriteEditor.Text = "Sprite Properties";
            SpriteEditor.UseVisualStyleBackColor = true;
            // 
            // NamingEditor
            // 
            NamingEditor.Location = new System.Drawing.Point(4, 24);
            NamingEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NamingEditor.Name = "NamingEditor";
            NamingEditor.Size = new System.Drawing.Size(1365, 0);
            NamingEditor.TabIndex = 8;
            NamingEditor.Text = "Names Editor";
            NamingEditor.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, projectToolStripMenuItem, testToolStripMenuItem, roomToolStripMenuItem, dungeonViewToolStripMenuItem, naviguateToolStripMenuItem, overworldToolStripMenuItem, areaToolStripMenuItem, overworldViewToolStripMenuItem, windowToolStripMenuItem, jPDebugToolStripMenuItem, ExperimentalToolStripMenuItem1, helpToolStripMenuItem, discordToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(1373, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openToolStripMenuItem, recentROMToolStripMenuItem, saveToolStripMenuItem, saveasToolStripMenuItem, saveToNewROMToolStripMenuItem, buildROMwithASMToolStripMenuItem, uploadVanillaCopyToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            openToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            openToolStripMenuItem.Text = "Open ROM…";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // recentROMToolStripMenuItem
            // 
            recentROMToolStripMenuItem.Name = "recentROMToolStripMenuItem";
            recentROMToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            recentROMToolStripMenuItem.Text = "Open Recent ROM…";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            saveToolStripMenuItem.Text = "Save ROM";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // saveasToolStripMenuItem
            // 
            saveasToolStripMenuItem.Enabled = false;
            saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            saveasToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            saveasToolStripMenuItem.Text = "Save ROM As…";
            saveasToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // saveToNewROMToolStripMenuItem
            // 
            saveToNewROMToolStripMenuItem.Enabled = false;
            saveToNewROMToolStripMenuItem.Name = "saveToNewROMToolStripMenuItem";
            saveToNewROMToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            saveToNewROMToolStripMenuItem.Text = "Save to New ROM";
            saveToNewROMToolStripMenuItem.Click += SaveToNewROMToolStripMenuItem_Click;
            // 
            // buildROMwithASMToolStripMenuItem
            // 
            buildROMwithASMToolStripMenuItem.Name = "buildROMwithASMToolStripMenuItem";
            buildROMwithASMToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            buildROMwithASMToolStripMenuItem.Text = "Build and Pre-patch ROM";
            buildROMwithASMToolStripMenuItem.Click += buildROMwithASMToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator4, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem, toolStripSeparator5, selectAllToolStripMenuItem, toolStripSeparator6, moveFrontToolStripMenuItem, bringToBackToolStripMenuItem, toolStripSeparator7, decreaseObjectSizeToolStripMenuItem, increaseObjectSizeToolStripMenuItem, toolStripSeparator9, selectAllRoomsForExportToolStripMenuItem, deselectedAllRoomsForExportToolStripMenuItem, toolStripSeparator10, lockoverworldToolStripItem });
            editToolStripMenuItem.Enabled = false;
            editToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z;
            undoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y;
            redoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(232, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Enabled = false;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X;
            cutToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += CutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C;
            copyToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V;
            pasteToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += PasteToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            deleteToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(232, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A;
            selectAllToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            selectAllToolStripMenuItem.Text = "Select All";
            selectAllToolStripMenuItem.Click += SelectAllToolStripMenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(232, 6);
            // 
            // moveFrontToolStripMenuItem
            // 
            moveFrontToolStripMenuItem.Enabled = false;
            moveFrontToolStripMenuItem.Name = "moveFrontToolStripMenuItem";
            moveFrontToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            moveFrontToolStripMenuItem.Text = "Send to Front";
            moveFrontToolStripMenuItem.Click += SendSelectedToFront;
            // 
            // bringToBackToolStripMenuItem
            // 
            bringToBackToolStripMenuItem.Enabled = false;
            bringToBackToolStripMenuItem.Name = "bringToBackToolStripMenuItem";
            bringToBackToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            bringToBackToolStripMenuItem.Text = "Send to Back";
            bringToBackToolStripMenuItem.Click += SendSelectedToBack;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new System.Drawing.Size(232, 6);
            // 
            // decreaseObjectSizeToolStripMenuItem
            // 
            decreaseObjectSizeToolStripMenuItem.Name = "decreaseObjectSizeToolStripMenuItem";
            decreaseObjectSizeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R;
            decreaseObjectSizeToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            decreaseObjectSizeToolStripMenuItem.Text = "Decrease Object Size";
            decreaseObjectSizeToolStripMenuItem.Click += DecreaseObjectSizeToolStripMenuItem_Click;
            // 
            // increaseObjectSizeToolStripMenuItem
            // 
            increaseObjectSizeToolStripMenuItem.Name = "increaseObjectSizeToolStripMenuItem";
            increaseObjectSizeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T;
            increaseObjectSizeToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            increaseObjectSizeToolStripMenuItem.Text = "Increase Object Size";
            increaseObjectSizeToolStripMenuItem.Click += IncreaseObjectSizeToolStripMenuItem_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new System.Drawing.Size(232, 6);
            // 
            // selectAllRoomsForExportToolStripMenuItem
            // 
            selectAllRoomsForExportToolStripMenuItem.Name = "selectAllRoomsForExportToolStripMenuItem";
            selectAllRoomsForExportToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            selectAllRoomsForExportToolStripMenuItem.Text = "Select All Rooms for Export";
            selectAllRoomsForExportToolStripMenuItem.Click += SelectAllRoomsForExportToolStripMenuItem_Click;
            // 
            // deselectedAllRoomsForExportToolStripMenuItem
            // 
            deselectedAllRoomsForExportToolStripMenuItem.Name = "deselectedAllRoomsForExportToolStripMenuItem";
            deselectedAllRoomsForExportToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            deselectedAllRoomsForExportToolStripMenuItem.Text = "Deselect All Rooms";
            deselectedAllRoomsForExportToolStripMenuItem.Click += DeselectedAllRoomsForExportToolStripMenuItem_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new System.Drawing.Size(232, 6);
            toolStripSeparator10.Visible = false;
            // 
            // lockoverworldToolStripItem
            // 
            lockoverworldToolStripItem.Name = "lockoverworldToolStripItem";
            lockoverworldToolStripItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L;
            lockoverworldToolStripItem.Size = new System.Drawing.Size(235, 22);
            lockoverworldToolStripItem.Text = "Lock Overworld Screen";
            lockoverworldToolStripItem.Visible = false;
            // 
            // projectToolStripMenuItem
            // 
            projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveSettingsToolStripMenuItem, loadNamesFileToolStripMenuItem, memoryManagementToolStripMenuItem, pluginsToolStripMenuItem, toolStripMenuItem8, applyFastROMToolStripMenuItem });
            projectToolStripMenuItem.Enabled = false;
            projectToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            projectToolStripMenuItem.Text = "Project";
            // 
            // saveSettingsToolStripMenuItem
            // 
            saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            saveSettingsToolStripMenuItem.Text = "Save Enable/Disable Settings…";
            saveSettingsToolStripMenuItem.Click += SaveSettingsToolStripMenuItem_Click;
            // 
            // loadNamesFileToolStripMenuItem
            // 
            loadNamesFileToolStripMenuItem.Name = "loadNamesFileToolStripMenuItem";
            loadNamesFileToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            loadNamesFileToolStripMenuItem.Text = "Load Names File…";
            loadNamesFileToolStripMenuItem.Click += LoadNamesFileToolStripMenuItem_Click;
            // 
            // memoryManagementToolStripMenuItem
            // 
            memoryManagementToolStripMenuItem.Name = "memoryManagementToolStripMenuItem";
            memoryManagementToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            memoryManagementToolStripMenuItem.Text = "Memory Management";
            memoryManagementToolStripMenuItem.Click += MemoryManagementToolStripMenuItem_Click;
            // 
            // pluginsToolStripMenuItem
            // 
            pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            pluginsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            pluginsToolStripMenuItem.Text = "ROM Patches";
            pluginsToolStripMenuItem.Click += pluginsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new System.Drawing.Size(233, 22);
            toolStripMenuItem8.Text = "Import player sprite .zspr";
            toolStripMenuItem8.Click += toolStripMenuItem8_Click;
            // 
            // applyFastROMToolStripMenuItem
            // 
            applyFastROMToolStripMenuItem.Enabled = false;
            applyFastROMToolStripMenuItem.Name = "applyFastROMToolStripMenuItem";
            applyFastROMToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            applyFastROMToolStripMenuItem.Text = "Apply Fast ROM";
            applyFastROMToolStripMenuItem.Click += applyFastROMToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { runToolStripMenuItem, debugRunToolStripMenuItem });
            testToolStripMenuItem.Enabled = false;
            testToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            testToolStripMenuItem.Text = "Test";
            // 
            // runToolStripMenuItem
            // 
            runToolStripMenuItem.Name = "runToolStripMenuItem";
            runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            runToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            runToolStripMenuItem.Text = "Run…";
            runToolStripMenuItem.Click += RunToolStripMenuItem_Click;
            // 
            // debugRunToolStripMenuItem
            // 
            debugRunToolStripMenuItem.Name = "debugRunToolStripMenuItem";
            debugRunToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5;
            debugRunToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            debugRunToolStripMenuItem.Text = "Debug Run…";
            // 
            // roomToolStripMenuItem
            // 
            roomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { gotoRoomToolStripMenuItem, toolStripMenuItem2, toolStripMenuItem1, removeMaskObjectsToolStripMenuItem, printRoomObjectsToolStripMenuItem1, clearSelectedRoomToolStripMenuItem, clearAllRoomsToolStripMenuItem, exportAsASMToolStripMenuItem, exportAllRoomsToolStripMenuItem, exportSpritesAsBinaryToolStripMenuItem, importRoomToolStripMenuItem, showRoomsInHexToolStripMenuItem, selectedObjectInHexToolStripMenuItem, autoDoorsToolStripMenuItem, exportSelectedRoomsToolStripMenuItem, importDungeonToolStripMenuItem, propertiesToolStripMenuItem });
            roomToolStripMenuItem.Enabled = false;
            roomToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            roomToolStripMenuItem.Name = "roomToolStripMenuItem";
            roomToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            roomToolStripMenuItem.Text = "Dungeon";
            // 
            // gotoRoomToolStripMenuItem
            // 
            gotoRoomToolStripMenuItem.Name = "gotoRoomToolStripMenuItem";
            gotoRoomToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            gotoRoomToolStripMenuItem.Text = "Go to Room";
            gotoRoomToolStripMenuItem.Click += GotoRoomToolStripMenuItem_Click_1;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(213, 22);
            toolStripMenuItem2.Text = "Dungeons Properties";
            toolStripMenuItem2.Click += DungeonsPropertiesToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(213, 22);
            toolStripMenuItem1.Text = "Advanced Chest Editor";
            toolStripMenuItem1.Click += AdvancedChestEditorToolStripMenuItem_Click;
            // 
            // removeMaskObjectsToolStripMenuItem
            // 
            removeMaskObjectsToolStripMenuItem.Name = "removeMaskObjectsToolStripMenuItem";
            removeMaskObjectsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            removeMaskObjectsToolStripMenuItem.Text = "Remove Mask Objects";
            removeMaskObjectsToolStripMenuItem.Click += RemoveMasksObjectsToolStripMenuItem_Click;
            // 
            // printRoomObjectsToolStripMenuItem1
            // 
            printRoomObjectsToolStripMenuItem1.Name = "printRoomObjectsToolStripMenuItem1";
            printRoomObjectsToolStripMenuItem1.Size = new System.Drawing.Size(213, 22);
            printRoomObjectsToolStripMenuItem1.Text = "Print Room Objects";
            printRoomObjectsToolStripMenuItem1.Click += PrintRoomObjectsToolStripMenuItem_Click;
            // 
            // clearSelectedRoomToolStripMenuItem
            // 
            clearSelectedRoomToolStripMenuItem.Name = "clearSelectedRoomToolStripMenuItem";
            clearSelectedRoomToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            clearSelectedRoomToolStripMenuItem.Text = "Clear Selected Room";
            clearSelectedRoomToolStripMenuItem.Click += ClearSelectedRoomToolStripMenuItem_Click;
            // 
            // clearAllRoomsToolStripMenuItem
            // 
            clearAllRoomsToolStripMenuItem.Name = "clearAllRoomsToolStripMenuItem";
            clearAllRoomsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            clearAllRoomsToolStripMenuItem.Text = "Clear All Rooms";
            clearAllRoomsToolStripMenuItem.Click += ClearAllRoomsToolStripMenuItem_Click;
            // 
            // exportAsASMToolStripMenuItem
            // 
            exportAsASMToolStripMenuItem.Name = "exportAsASMToolStripMenuItem";
            exportAsASMToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            exportAsASMToolStripMenuItem.Text = "Export As Binary";
            exportAsASMToolStripMenuItem.Click += ExportAsASMToolStripMenuItem_Click;
            // 
            // exportAllRoomsToolStripMenuItem
            // 
            exportAllRoomsToolStripMenuItem.Name = "exportAllRoomsToolStripMenuItem";
            exportAllRoomsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            exportAllRoomsToolStripMenuItem.Text = "Export All Rooms";
            exportAllRoomsToolStripMenuItem.Click += ExportAllRoomsToolStripMenuItem_Click;
            // 
            // exportSpritesAsBinaryToolStripMenuItem
            // 
            exportSpritesAsBinaryToolStripMenuItem.Name = "exportSpritesAsBinaryToolStripMenuItem";
            exportSpritesAsBinaryToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            exportSpritesAsBinaryToolStripMenuItem.Text = "Export Sprites As Binary";
            exportSpritesAsBinaryToolStripMenuItem.Click += ExportSpritesAsBinaryToolStripMenuItem_Click;
            // 
            // importRoomToolStripMenuItem
            // 
            importRoomToolStripMenuItem.Name = "importRoomToolStripMenuItem";
            importRoomToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            importRoomToolStripMenuItem.Text = "Import Room";
            importRoomToolStripMenuItem.Click += ImportRoomToolStripMenuItem_Click;
            // 
            // showRoomsInHexToolStripMenuItem
            // 
            showRoomsInHexToolStripMenuItem.CheckOnClick = true;
            showRoomsInHexToolStripMenuItem.Enabled = false;
            showRoomsInHexToolStripMenuItem.Name = "showRoomsInHexToolStripMenuItem";
            showRoomsInHexToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            showRoomsInHexToolStripMenuItem.Text = "Display Room IDs in Hex";
            showRoomsInHexToolStripMenuItem.Click += ShowRoomsInHexToolStripMenuItem_Click;
            // 
            // selectedObjectInHexToolStripMenuItem
            // 
            selectedObjectInHexToolStripMenuItem.Name = "selectedObjectInHexToolStripMenuItem";
            selectedObjectInHexToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            selectedObjectInHexToolStripMenuItem.Text = "Display Object Data in Hex";
            // 
            // autoDoorsToolStripMenuItem
            // 
            autoDoorsToolStripMenuItem.Name = "autoDoorsToolStripMenuItem";
            autoDoorsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            autoDoorsToolStripMenuItem.Text = "Auto sort Doors";
            autoDoorsToolStripMenuItem.Click += AutoDoorButton_Click_1;
            // 
            // exportSelectedRoomsToolStripMenuItem
            // 
            exportSelectedRoomsToolStripMenuItem.Name = "exportSelectedRoomsToolStripMenuItem";
            exportSelectedRoomsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            exportSelectedRoomsToolStripMenuItem.Text = "Export Dungeon";
            exportSelectedRoomsToolStripMenuItem.Click += exportSelectedRoomsToolStripMenuItem_Click;
            // 
            // importDungeonToolStripMenuItem
            // 
            importDungeonToolStripMenuItem.Name = "importDungeonToolStripMenuItem";
            importDungeonToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            importDungeonToolStripMenuItem.Text = "Import Dungeon";
            importDungeonToolStripMenuItem.Click += importDungeonToolStripMenuItem_Click;
            // 
            // propertiesToolStripMenuItem
            // 
            propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            propertiesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            propertiesToolStripMenuItem.Text = "ZS Properties";
            propertiesToolStripMenuItem.Click += propertiesToolStripMenuItem_Click;
            // 
            // dungeonViewToolStripMenuItem
            // 
            dungeonViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { darkThemeToolStripMenuItem, showGridToolStripMenuItem, showMapIndexInHexToolStripMenuItem, xScreenToolStripMenuItem, toolStripSeparator12, showBG1ToolStripMenuItem, showBG2ToolStripMenuItem, unselectedBGTransparentToolStripMenuItem, showBG2MaskOutlineToolStripMenuItem, toolStripSeparator13, hideSpritesToolStripMenuItem, hideItemsToolStripMenuItem, hideChestItemsToolStripMenuItem, toolStripSeparator14, textSpriteToolStripMenuItem, textChestItemToolStripMenuItem, invisibleObjectsTextToolStripMenuItem, textPotItemToolStripMenuItem, toolStripSeparator11, showSpriteIndexToolStripMenuItem, showChestsIDsToolStripMenuItem, showDoorIDsToolStripMenuItem, showStairIndexToolStripMenuItem, toolStripSeparator15, disableEntranceGFXToolStripMenuItem, entrancePositionToolStripMenuItem, entranceCameraToolStripMenuItem, rightSideToolboxToolStripMenuItem });
            dungeonViewToolStripMenuItem.Enabled = false;
            dungeonViewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dungeonViewToolStripMenuItem.Name = "dungeonViewToolStripMenuItem";
            dungeonViewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            dungeonViewToolStripMenuItem.Text = "View";
            // 
            // darkThemeToolStripMenuItem
            // 
            darkThemeToolStripMenuItem.CheckOnClick = true;
            darkThemeToolStripMenuItem.Enabled = false;
            darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
            darkThemeToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            darkThemeToolStripMenuItem.Text = "Dark Theme";
            darkThemeToolStripMenuItem.Click += DarkThemeToolStripMenuItem_Click;
            // 
            // showGridToolStripMenuItem
            // 
            showGridToolStripMenuItem.CheckOnClick = true;
            showGridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { x8ToolStripMenuItem, x16ToolStripMenuItem, x32ToolStripMenuItem, x64ToolStripMenuItem, x256ToolStripMenuItem });
            showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
            showGridToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            showGridToolStripMenuItem.Text = "Show Grid";
            showGridToolStripMenuItem.Click += showGridToolStripMenuItem_Click;
            // 
            // x8ToolStripMenuItem
            // 
            x8ToolStripMenuItem.CheckOnClick = true;
            x8ToolStripMenuItem.Name = "x8ToolStripMenuItem";
            x8ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            x8ToolStripMenuItem.Text = "8x8";
            x8ToolStripMenuItem.Click += X8ToolStripMenuItem_Click;
            // 
            // x16ToolStripMenuItem
            // 
            x16ToolStripMenuItem.CheckOnClick = true;
            x16ToolStripMenuItem.Name = "x16ToolStripMenuItem";
            x16ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            x16ToolStripMenuItem.Text = "16x16";
            x16ToolStripMenuItem.Click += X8ToolStripMenuItem_Click;
            // 
            // x32ToolStripMenuItem
            // 
            x32ToolStripMenuItem.CheckOnClick = true;
            x32ToolStripMenuItem.Name = "x32ToolStripMenuItem";
            x32ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            x32ToolStripMenuItem.Text = "32x32";
            x32ToolStripMenuItem.Click += X8ToolStripMenuItem_Click;
            // 
            // x64ToolStripMenuItem
            // 
            x64ToolStripMenuItem.CheckOnClick = true;
            x64ToolStripMenuItem.Name = "x64ToolStripMenuItem";
            x64ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            x64ToolStripMenuItem.Text = "64x64";
            x64ToolStripMenuItem.Click += X8ToolStripMenuItem_Click;
            // 
            // x256ToolStripMenuItem
            // 
            x256ToolStripMenuItem.CheckOnClick = true;
            x256ToolStripMenuItem.Name = "x256ToolStripMenuItem";
            x256ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            x256ToolStripMenuItem.Text = "256x256";
            x256ToolStripMenuItem.Click += X8ToolStripMenuItem_Click;
            // 
            // showMapIndexInHexToolStripMenuItem
            // 
            showMapIndexInHexToolStripMenuItem.Checked = true;
            showMapIndexInHexToolStripMenuItem.CheckOnClick = true;
            showMapIndexInHexToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showMapIndexInHexToolStripMenuItem.Enabled = false;
            showMapIndexInHexToolStripMenuItem.Name = "showMapIndexInHexToolStripMenuItem";
            showMapIndexInHexToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            showMapIndexInHexToolStripMenuItem.Text = "Display Map IDs in Hex";
            showMapIndexInHexToolStripMenuItem.Click += ShowMapIndexInHexToolStripMenuItem_Click;
            // 
            // xScreenToolStripMenuItem
            // 
            xScreenToolStripMenuItem.CheckOnClick = true;
            xScreenToolStripMenuItem.Name = "xScreenToolStripMenuItem";
            xScreenToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            xScreenToolStripMenuItem.Text = "2X Zoom";
            xScreenToolStripMenuItem.CheckStateChanged += HideSpritesToolStripMenuItem_CheckStateChanged;
            xScreenToolStripMenuItem.Click += XScreenToolStripMenuItem_Click;
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new System.Drawing.Size(274, 6);
            // 
            // showBG1ToolStripMenuItem
            // 
            showBG1ToolStripMenuItem.Checked = true;
            showBG1ToolStripMenuItem.CheckOnClick = true;
            showBG1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showBG1ToolStripMenuItem.Name = "showBG1ToolStripMenuItem";
            showBG1ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            showBG1ToolStripMenuItem.Text = "Show Layer 1";
            showBG1ToolStripMenuItem.Click += showBG1ToolStripMenuItem_Click;
            // 
            // showBG2ToolStripMenuItem
            // 
            showBG2ToolStripMenuItem.Checked = true;
            showBG2ToolStripMenuItem.CheckOnClick = true;
            showBG2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showBG2ToolStripMenuItem.Name = "showBG2ToolStripMenuItem";
            showBG2ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            showBG2ToolStripMenuItem.Text = "Show Layer 2";
            showBG2ToolStripMenuItem.Click += showBG2ToolStripMenuItem_Click;
            // 
            // unselectedBGTransparentToolStripMenuItem
            // 
            unselectedBGTransparentToolStripMenuItem.Checked = true;
            unselectedBGTransparentToolStripMenuItem.CheckOnClick = true;
            unselectedBGTransparentToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            unselectedBGTransparentToolStripMenuItem.Name = "unselectedBGTransparentToolStripMenuItem";
            unselectedBGTransparentToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            unselectedBGTransparentToolStripMenuItem.Text = "Display Unselected Layer Translucently";
            unselectedBGTransparentToolStripMenuItem.Click += unselectedBGTransparentToolStripMenuItem_Click;
            // 
            // showBG2MaskOutlineToolStripMenuItem
            // 
            showBG2MaskOutlineToolStripMenuItem.Checked = true;
            showBG2MaskOutlineToolStripMenuItem.CheckOnClick = true;
            showBG2MaskOutlineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showBG2MaskOutlineToolStripMenuItem.Name = "showBG2MaskOutlineToolStripMenuItem";
            showBG2MaskOutlineToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            showBG2MaskOutlineToolStripMenuItem.Text = "Outline Layer Masks";
            showBG2MaskOutlineToolStripMenuItem.Click += ShowBG2MaskOutlineToolStripMenuItem_Click;
            // 
            // toolStripSeparator13
            // 
            toolStripSeparator13.Name = "toolStripSeparator13";
            toolStripSeparator13.Size = new System.Drawing.Size(274, 6);
            // 
            // hideSpritesToolStripMenuItem
            // 
            hideSpritesToolStripMenuItem.Checked = true;
            hideSpritesToolStripMenuItem.CheckOnClick = true;
            hideSpritesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            hideSpritesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { boxesToolStripMenuItem, graphicsToolStripMenuItem });
            hideSpritesToolStripMenuItem.Name = "hideSpritesToolStripMenuItem";
            hideSpritesToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            hideSpritesToolStripMenuItem.Text = "Show Sprites";
            hideSpritesToolStripMenuItem.CheckStateChanged += HideSpritesToolStripMenuItem_CheckStateChanged;
            // 
            // boxesToolStripMenuItem
            // 
            boxesToolStripMenuItem.Name = "boxesToolStripMenuItem";
            boxesToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            boxesToolStripMenuItem.Text = "Boxes";
            boxesToolStripMenuItem.Click += SpriteDisplayMenuItem_Click;
            // 
            // graphicsToolStripMenuItem
            // 
            graphicsToolStripMenuItem.Checked = true;
            graphicsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            graphicsToolStripMenuItem.Name = "graphicsToolStripMenuItem";
            graphicsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            graphicsToolStripMenuItem.Text = "Graphics";
            graphicsToolStripMenuItem.Click += SpriteDisplayMenuItem_Click;
            // 
            // hideItemsToolStripMenuItem
            // 
            hideItemsToolStripMenuItem.Checked = true;
            hideItemsToolStripMenuItem.CheckOnClick = true;
            hideItemsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            hideItemsToolStripMenuItem.Name = "hideItemsToolStripMenuItem";
            hideItemsToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            hideItemsToolStripMenuItem.Text = "Show Items";
            hideItemsToolStripMenuItem.CheckStateChanged += HideSpritesToolStripMenuItem_CheckStateChanged;
            // 
            // hideChestItemsToolStripMenuItem
            // 
            hideChestItemsToolStripMenuItem.Checked = true;
            hideChestItemsToolStripMenuItem.CheckOnClick = true;
            hideChestItemsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            hideChestItemsToolStripMenuItem.Name = "hideChestItemsToolStripMenuItem";
            hideChestItemsToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            hideChestItemsToolStripMenuItem.Text = "Show Chest Items";
            hideChestItemsToolStripMenuItem.CheckStateChanged += HideSpritesToolStripMenuItem_CheckStateChanged;
            // 
            // toolStripSeparator14
            // 
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new System.Drawing.Size(274, 6);
            // 
            // textSpriteToolStripMenuItem
            // 
            textSpriteToolStripMenuItem.CheckOnClick = true;
            textSpriteToolStripMenuItem.Name = "textSpriteToolStripMenuItem";
            textSpriteToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            textSpriteToolStripMenuItem.Text = "Show Sprite Names";
            textSpriteToolStripMenuItem.CheckStateChanged += HideSpritesToolStripMenuItem_CheckStateChanged;
            // 
            // textChestItemToolStripMenuItem
            // 
            textChestItemToolStripMenuItem.CheckOnClick = true;
            textChestItemToolStripMenuItem.Name = "textChestItemToolStripMenuItem";
            textChestItemToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            textChestItemToolStripMenuItem.Text = "Show Chest Item Names";
            textChestItemToolStripMenuItem.CheckStateChanged += HideSpritesToolStripMenuItem_CheckStateChanged;
            // 
            // invisibleObjectsTextToolStripMenuItem
            // 
            invisibleObjectsTextToolStripMenuItem.Checked = true;
            invisibleObjectsTextToolStripMenuItem.CheckOnClick = true;
            invisibleObjectsTextToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            invisibleObjectsTextToolStripMenuItem.Name = "invisibleObjectsTextToolStripMenuItem";
            invisibleObjectsTextToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            invisibleObjectsTextToolStripMenuItem.Text = "Show Text for Invisible Objects";
            // 
            // textPotItemToolStripMenuItem
            // 
            textPotItemToolStripMenuItem.CheckOnClick = true;
            textPotItemToolStripMenuItem.Name = "textPotItemToolStripMenuItem";
            textPotItemToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            textPotItemToolStripMenuItem.Text = "Show Secret Item Names";
            textPotItemToolStripMenuItem.CheckStateChanged += HideSpritesToolStripMenuItem_CheckStateChanged;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new System.Drawing.Size(274, 6);
            // 
            // showSpriteIndexToolStripMenuItem
            // 
            showSpriteIndexToolStripMenuItem.CheckOnClick = true;
            showSpriteIndexToolStripMenuItem.Name = "showSpriteIndexToolStripMenuItem";
            showSpriteIndexToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            showSpriteIndexToolStripMenuItem.Text = "Show Sprite Index";
            showSpriteIndexToolStripMenuItem.CheckStateChanged += HideSpritesToolStripMenuItem_CheckStateChanged;
            // 
            // showChestsIDsToolStripMenuItem
            // 
            showChestsIDsToolStripMenuItem.Checked = true;
            showChestsIDsToolStripMenuItem.CheckOnClick = true;
            showChestsIDsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showChestsIDsToolStripMenuItem.Name = "showChestsIDsToolStripMenuItem";
            showChestsIDsToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            showChestsIDsToolStripMenuItem.Text = "Show Chest Index";
            showChestsIDsToolStripMenuItem.CheckStateChanged += HideSpritesToolStripMenuItem_CheckStateChanged;
            // 
            // showDoorIDsToolStripMenuItem
            // 
            showDoorIDsToolStripMenuItem.Checked = true;
            showDoorIDsToolStripMenuItem.CheckOnClick = true;
            showDoorIDsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showDoorIDsToolStripMenuItem.Name = "showDoorIDsToolStripMenuItem";
            showDoorIDsToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            showDoorIDsToolStripMenuItem.Text = "Show Door Index";
            showDoorIDsToolStripMenuItem.CheckStateChanged += HideSpritesToolStripMenuItem_CheckStateChanged;
            // 
            // showStairIndexToolStripMenuItem
            // 
            showStairIndexToolStripMenuItem.Checked = true;
            showStairIndexToolStripMenuItem.CheckOnClick = true;
            showStairIndexToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showStairIndexToolStripMenuItem.Name = "showStairIndexToolStripMenuItem";
            showStairIndexToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            showStairIndexToolStripMenuItem.Text = "Show Stair Index";
            showStairIndexToolStripMenuItem.CheckStateChanged += HideSpritesToolStripMenuItem_CheckStateChanged;
            showStairIndexToolStripMenuItem.Click += ShowStairIndexToolStripMenuItem_Click;
            // 
            // toolStripSeparator15
            // 
            toolStripSeparator15.Name = "toolStripSeparator15";
            toolStripSeparator15.Size = new System.Drawing.Size(274, 6);
            // 
            // disableEntranceGFXToolStripMenuItem
            // 
            disableEntranceGFXToolStripMenuItem.Checked = true;
            disableEntranceGFXToolStripMenuItem.CheckOnClick = true;
            disableEntranceGFXToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            disableEntranceGFXToolStripMenuItem.Name = "disableEntranceGFXToolStripMenuItem";
            disableEntranceGFXToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            disableEntranceGFXToolStripMenuItem.Text = "Show Entrance GFX";
            disableEntranceGFXToolStripMenuItem.CheckStateChanged += HideSpritesToolStripMenuItem_CheckStateChanged;
            // 
            // entrancePositionToolStripMenuItem
            // 
            entrancePositionToolStripMenuItem.CheckOnClick = true;
            entrancePositionToolStripMenuItem.Name = "entrancePositionToolStripMenuItem";
            entrancePositionToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            entrancePositionToolStripMenuItem.Text = "Show Entrance Position";
            entrancePositionToolStripMenuItem.Click += EntrancePositionToolStripMenuItem_Click;
            // 
            // entranceCameraToolStripMenuItem
            // 
            entranceCameraToolStripMenuItem.CheckOnClick = true;
            entranceCameraToolStripMenuItem.Name = "entranceCameraToolStripMenuItem";
            entranceCameraToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            entranceCameraToolStripMenuItem.Text = "Show Entrance Camera Box";
            entranceCameraToolStripMenuItem.Click += EntranceCameraToolStripMenuItem_Click;
            // 
            // rightSideToolboxToolStripMenuItem
            // 
            rightSideToolboxToolStripMenuItem.CheckOnClick = true;
            rightSideToolboxToolStripMenuItem.Name = "rightSideToolboxToolStripMenuItem";
            rightSideToolboxToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            rightSideToolboxToolStripMenuItem.Text = "Show Entrance Properties Beneath";
            rightSideToolboxToolStripMenuItem.Click += rightSideToolboxToolStripMenuItem_Click;
            // 
            // naviguateToolStripMenuItem
            // 
            naviguateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { moveToRightToolStripMenuItem, moveToLeftToolStripMenuItem, moveToUpToolStripMenuItem, moveToDownToolStripMenuItem, toolStripSeparator8, openRightRoomToolStripMenuItem, openLeftRoomToolStripMenuItem, openUpRoomToolStripMenuItem, openDownRoomToolStripMenuItem });
            naviguateToolStripMenuItem.Enabled = false;
            naviguateToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            naviguateToolStripMenuItem.Name = "naviguateToolStripMenuItem";
            naviguateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            naviguateToolStripMenuItem.Text = "Navigate";
            // 
            // moveToRightToolStripMenuItem
            // 
            moveToRightToolStripMenuItem.Enabled = false;
            moveToRightToolStripMenuItem.Name = "moveToRightToolStripMenuItem";
            moveToRightToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Right;
            moveToRightToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            moveToRightToolStripMenuItem.Text = "Move 1 Room to the East";
            // 
            // moveToLeftToolStripMenuItem
            // 
            moveToLeftToolStripMenuItem.Enabled = false;
            moveToLeftToolStripMenuItem.Name = "moveToLeftToolStripMenuItem";
            moveToLeftToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Left;
            moveToLeftToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            moveToLeftToolStripMenuItem.Text = "Move 1 Room to the West";
            // 
            // moveToUpToolStripMenuItem
            // 
            moveToUpToolStripMenuItem.Enabled = false;
            moveToUpToolStripMenuItem.Name = "moveToUpToolStripMenuItem";
            moveToUpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up;
            moveToUpToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            moveToUpToolStripMenuItem.Text = "Move 1 Room to the North";
            // 
            // moveToDownToolStripMenuItem
            // 
            moveToDownToolStripMenuItem.Enabled = false;
            moveToDownToolStripMenuItem.Name = "moveToDownToolStripMenuItem";
            moveToDownToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down;
            moveToDownToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            moveToDownToolStripMenuItem.Text = "Move 1 Room to the South";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new System.Drawing.Size(274, 6);
            // 
            // openRightRoomToolStripMenuItem
            // 
            openRightRoomToolStripMenuItem.Name = "openRightRoomToolStripMenuItem";
            openRightRoomToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right;
            openRightRoomToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            openRightRoomToolStripMenuItem.Text = "Open Room to the East";
            openRightRoomToolStripMenuItem.Click += openRightRoomToolStripMenuItem_Click;
            // 
            // openLeftRoomToolStripMenuItem
            // 
            openLeftRoomToolStripMenuItem.Name = "openLeftRoomToolStripMenuItem";
            openLeftRoomToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left;
            openLeftRoomToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            openLeftRoomToolStripMenuItem.Text = "Open Room to the West";
            openLeftRoomToolStripMenuItem.Click += OpenLeftRoomToolStripMenuItem_Click;
            // 
            // openUpRoomToolStripMenuItem
            // 
            openUpRoomToolStripMenuItem.Name = "openUpRoomToolStripMenuItem";
            openUpRoomToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up;
            openUpRoomToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            openUpRoomToolStripMenuItem.Text = "Open Room to the North";
            openUpRoomToolStripMenuItem.Click += OpenUpRoomToolStripMenuItem_Click;
            // 
            // openDownRoomToolStripMenuItem
            // 
            openDownRoomToolStripMenuItem.Name = "openDownRoomToolStripMenuItem";
            openDownRoomToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down;
            openDownRoomToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            openDownRoomToolStripMenuItem.Text = "Open Room to the South";
            openDownRoomToolStripMenuItem.Click += OpenDownRoomToolStripMenuItem_Click;
            // 
            // overworldToolStripMenuItem
            // 
            overworldToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { clearSpritesToolStripMenuItem, clearItemsToolStripMenuItem, clearEntrancesToolStripMenuItem, clearAllHolesToolStripMenuItem, clearExitsToolStripMenuItem, clearAllOverlaysToolStripMenuItem, toolStripMenuItem6, toolStripMenuItem5, exportAllTilesToolStripMenuItem, importAllTilesToolStripMenuItem, toolStripMenuItem7, clearDWTilesToolStripMenuItem, copyLWToDWToolStripMenuItem, showTiles32CountToolStripMenuItem, showUniqueTile32ToolStripMenuItem, setUnusedTiles16ToToolStripMenuItem });
            overworldToolStripMenuItem.Enabled = false;
            overworldToolStripMenuItem.Name = "overworldToolStripMenuItem";
            overworldToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            overworldToolStripMenuItem.Text = "Overworld";
            overworldToolStripMenuItem.Visible = false;
            // 
            // clearSpritesToolStripMenuItem
            // 
            clearSpritesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveZeldaToolStripMenuItem, zeldaSavedToolStripMenuItem, agahDeadToolStripMenuItem });
            clearSpritesToolStripMenuItem.Name = "clearSpritesToolStripMenuItem";
            clearSpritesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            clearSpritesToolStripMenuItem.Text = "Clear All Sprites";
            // 
            // saveZeldaToolStripMenuItem
            // 
            saveZeldaToolStripMenuItem.Name = "saveZeldaToolStripMenuItem";
            saveZeldaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            saveZeldaToolStripMenuItem.Text = "1. (Save Zelda)";
            saveZeldaToolStripMenuItem.Click += ClearPhase1OWSpritesToolStripMenuItem_Click;
            // 
            // zeldaSavedToolStripMenuItem
            // 
            zeldaSavedToolStripMenuItem.Name = "zeldaSavedToolStripMenuItem";
            zeldaSavedToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            zeldaSavedToolStripMenuItem.Text = "2. (Zelda Saved)";
            zeldaSavedToolStripMenuItem.Click += ClearPhase2OWSpritesToolStripMenuItem_Click;
            // 
            // agahDeadToolStripMenuItem
            // 
            agahDeadToolStripMenuItem.Name = "agahDeadToolStripMenuItem";
            agahDeadToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            agahDeadToolStripMenuItem.Text = "3. (Agah. Dead)";
            agahDeadToolStripMenuItem.Click += ClearPhase3OWSpritesToolStripMenuItem_Click;
            // 
            // clearItemsToolStripMenuItem
            // 
            clearItemsToolStripMenuItem.Name = "clearItemsToolStripMenuItem";
            clearItemsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            clearItemsToolStripMenuItem.Text = "Clear All Items";
            clearItemsToolStripMenuItem.Click += ClearAllOWItemsToolStripMenuItem_Click;
            // 
            // clearEntrancesToolStripMenuItem
            // 
            clearEntrancesToolStripMenuItem.Name = "clearEntrancesToolStripMenuItem";
            clearEntrancesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            clearEntrancesToolStripMenuItem.Text = "Clear All Entrances";
            clearEntrancesToolStripMenuItem.Click += ClearAllOWEntrancesToolStripMenuItem_Click;
            // 
            // clearAllHolesToolStripMenuItem
            // 
            clearAllHolesToolStripMenuItem.Name = "clearAllHolesToolStripMenuItem";
            clearAllHolesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            clearAllHolesToolStripMenuItem.Text = "Clear All Holes";
            clearAllHolesToolStripMenuItem.Click += ClearAllOWHolesToolStripMenuItem_Click;
            // 
            // clearExitsToolStripMenuItem
            // 
            clearExitsToolStripMenuItem.Name = "clearExitsToolStripMenuItem";
            clearExitsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            clearExitsToolStripMenuItem.Text = "Clear All Exits";
            clearExitsToolStripMenuItem.Click += ClearAllOWExitsToolStripMenuItem_Click;
            // 
            // clearAllOverlaysToolStripMenuItem
            // 
            clearAllOverlaysToolStripMenuItem.Name = "clearAllOverlaysToolStripMenuItem";
            clearAllOverlaysToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            clearAllOverlaysToolStripMenuItem.Text = "Clear All Overlays";
            clearAllOverlaysToolStripMenuItem.Click += ClearAllOverworldOverlaysToolStripMenuItem_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new System.Drawing.Size(184, 22);
            toolStripMenuItem6.Text = "Export All Areas";
            toolStripMenuItem6.Click += ExportAllMapsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new System.Drawing.Size(184, 22);
            toolStripMenuItem5.Text = "Import All Areas";
            toolStripMenuItem5.Click += ImportAllMapsToolStripMenuItem_Click;
            // 
            // exportAllTilesToolStripMenuItem
            // 
            exportAllTilesToolStripMenuItem.Name = "exportAllTilesToolStripMenuItem";
            exportAllTilesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            exportAllTilesToolStripMenuItem.Text = "Export All Tiles";
            exportAllTilesToolStripMenuItem.Click += ExportAllTilesToolStripMenuItem_Click;
            // 
            // importAllTilesToolStripMenuItem
            // 
            importAllTilesToolStripMenuItem.Name = "importAllTilesToolStripMenuItem";
            importAllTilesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            importAllTilesToolStripMenuItem.Text = "Import All Tiles";
            importAllTilesToolStripMenuItem.Click += ImportAllTilesToolStripMenuItem_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Enabled = false;
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new System.Drawing.Size(184, 22);
            toolStripMenuItem7.Text = "Import from ROM";
            // 
            // clearDWTilesToolStripMenuItem
            // 
            clearDWTilesToolStripMenuItem.Name = "clearDWTilesToolStripMenuItem";
            clearDWTilesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            clearDWTilesToolStripMenuItem.Text = "Clear DW Tiles";
            clearDWTilesToolStripMenuItem.Click += ClearDWTilesToolStripMenuItem_Click;
            // 
            // copyLWToDWToolStripMenuItem
            // 
            copyLWToDWToolStripMenuItem.Name = "copyLWToDWToolStripMenuItem";
            copyLWToDWToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            copyLWToDWToolStripMenuItem.Text = "Copy LW to DW";
            copyLWToDWToolStripMenuItem.Click += CopyLWToDWToolStripMenuItem_Click;
            // 
            // showTiles32CountToolStripMenuItem
            // 
            showTiles32CountToolStripMenuItem.Name = "showTiles32CountToolStripMenuItem";
            showTiles32CountToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            showTiles32CountToolStripMenuItem.Text = "Show Tiles32 Count";
            showTiles32CountToolStripMenuItem.Click += ShowTiles32CountToolStripMenuItem_Click;
            // 
            // showUniqueTile32ToolStripMenuItem
            // 
            showUniqueTile32ToolStripMenuItem.CheckOnClick = true;
            showUniqueTile32ToolStripMenuItem.Name = "showUniqueTile32ToolStripMenuItem";
            showUniqueTile32ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            showUniqueTile32ToolStripMenuItem.Text = "Show Unique Tile32";
            showUniqueTile32ToolStripMenuItem.Click += showUniqueTile32ToolStripMenuItem_Click;
            // 
            // setUnusedTiles16ToToolStripMenuItem
            // 
            setUnusedTiles16ToToolStripMenuItem.CheckOnClick = true;
            setUnusedTiles16ToToolStripMenuItem.Name = "setUnusedTiles16ToToolStripMenuItem";
            setUnusedTiles16ToToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            setUnusedTiles16ToToolStripMenuItem.Text = "Show unused Tiles16";
            setUnusedTiles16ToToolStripMenuItem.Click += setUnusedTiles16ToToolStripMenuItem_Click;
            // 
            // areaToolStripMenuItem
            // 
            areaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { clearSpritesToolStripMenuItem1, clearItemsToolStripMenuItem1, clearEntrancesToolStripMenuItem1, clearHolesToolStripMenuItem, clearExitsToolStripMenuItem1, clearOverlaysToolStripMenuItem, exportOverlayAsASMToolStripMenuItem, exportOverlayAnimationAsASMInClipboardToolStripMenuItem });
            areaToolStripMenuItem.Enabled = false;
            areaToolStripMenuItem.Name = "areaToolStripMenuItem";
            areaToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            areaToolStripMenuItem.Text = "Area";
            areaToolStripMenuItem.Visible = false;
            // 
            // clearSpritesToolStripMenuItem1
            // 
            clearSpritesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveZeldaToolStripMenuItem1, zeldaSavedToolStripMenuItem1, agahDeadToolStripMenuItem1 });
            clearSpritesToolStripMenuItem1.Name = "clearSpritesToolStripMenuItem1";
            clearSpritesToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            clearSpritesToolStripMenuItem1.Text = "Clear Area Sprites";
            // 
            // saveZeldaToolStripMenuItem1
            // 
            saveZeldaToolStripMenuItem1.Name = "saveZeldaToolStripMenuItem1";
            saveZeldaToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            saveZeldaToolStripMenuItem1.Text = "1. (Save Zelda)";
            saveZeldaToolStripMenuItem1.Click += ClearPhase1AreaSpritesToolStripMenuItem_Click;
            // 
            // zeldaSavedToolStripMenuItem1
            // 
            zeldaSavedToolStripMenuItem1.Name = "zeldaSavedToolStripMenuItem1";
            zeldaSavedToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            zeldaSavedToolStripMenuItem1.Text = "2. (Zelda Saved)";
            zeldaSavedToolStripMenuItem1.Click += ClearPhase2AreaSpritesToolStripMenuItem_Click;
            // 
            // agahDeadToolStripMenuItem1
            // 
            agahDeadToolStripMenuItem1.Name = "agahDeadToolStripMenuItem1";
            agahDeadToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            agahDeadToolStripMenuItem1.Text = "3. (Agah. Dead)";
            agahDeadToolStripMenuItem1.Click += ClearPhase3AreaSpritesToolStripMenuItem_Click;
            // 
            // clearItemsToolStripMenuItem1
            // 
            clearItemsToolStripMenuItem1.Name = "clearItemsToolStripMenuItem1";
            clearItemsToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            clearItemsToolStripMenuItem1.Text = "Clear Area Items";
            clearItemsToolStripMenuItem1.Click += ClearAllAreaItemsToolStripMenuItem_Click;
            // 
            // clearEntrancesToolStripMenuItem1
            // 
            clearEntrancesToolStripMenuItem1.Name = "clearEntrancesToolStripMenuItem1";
            clearEntrancesToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            clearEntrancesToolStripMenuItem1.Text = "Clear Area Entrances";
            clearEntrancesToolStripMenuItem1.Click += ClearAllAreaEntrancesToolStripMenuItem_Click;
            // 
            // clearHolesToolStripMenuItem
            // 
            clearHolesToolStripMenuItem.Name = "clearHolesToolStripMenuItem";
            clearHolesToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            clearHolesToolStripMenuItem.Text = "Clear Area Holes";
            clearHolesToolStripMenuItem.Click += ClearAllAreaHolesToolStripMenuItem_Click;
            // 
            // clearExitsToolStripMenuItem1
            // 
            clearExitsToolStripMenuItem1.Name = "clearExitsToolStripMenuItem1";
            clearExitsToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            clearExitsToolStripMenuItem1.Text = "Clear Area Exits";
            clearExitsToolStripMenuItem1.Click += ClearAllAreaExitsToolStripMenuItem_Click;
            // 
            // clearOverlaysToolStripMenuItem
            // 
            clearOverlaysToolStripMenuItem.Name = "clearOverlaysToolStripMenuItem";
            clearOverlaysToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            clearOverlaysToolStripMenuItem.Text = "Clear Area Overlays";
            clearOverlaysToolStripMenuItem.Click += ClearAllAreaOverlaysToolStripMenuItem_Click;
            // 
            // exportOverlayAsASMToolStripMenuItem
            // 
            exportOverlayAsASMToolStripMenuItem.Name = "exportOverlayAsASMToolStripMenuItem";
            exportOverlayAsASMToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            exportOverlayAsASMToolStripMenuItem.Text = "Export overlay as ASM in clipboard";
            exportOverlayAsASMToolStripMenuItem.Click += exportOverlayAsASMToolStripMenuItem_Click;
            // 
            // exportOverlayAnimationAsASMInClipboardToolStripMenuItem
            // 
            exportOverlayAnimationAsASMInClipboardToolStripMenuItem.Name = "exportOverlayAnimationAsASMInClipboardToolStripMenuItem";
            exportOverlayAnimationAsASMInClipboardToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            exportOverlayAnimationAsASMInClipboardToolStripMenuItem.Text = "Export overlay Animation";
            exportOverlayAnimationAsASMInClipboardToolStripMenuItem.Click += exportOverlayAnimationAsASMInClipboardToolStripMenuItem_Click;
            // 
            // overworldViewToolStripMenuItem
            // 
            overworldViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { showSpritesToolStripMenuItem, showEntrancesToolStripMenuItem, showExitsToolStripMenuItem, showTransportsToolStripMenuItem, showItemsToolStripMenuItem, showEntranceExitPreviewToolStripMenuItem, showGravesToolStripMenuItem, overworldOverlayVisibleToolStripMenuItem, showGridToolStripMenuItem1, useAreaSpecificBGColorToolStripMenuItem, showScratchPadGridToolStripMenuItem, showOverlayTextsToolStripMenuItem });
            overworldViewToolStripMenuItem.Enabled = false;
            overworldViewToolStripMenuItem.Name = "overworldViewToolStripMenuItem";
            overworldViewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            overworldViewToolStripMenuItem.Text = "View";
            overworldViewToolStripMenuItem.Visible = false;
            // 
            // showSpritesToolStripMenuItem
            // 
            showSpritesToolStripMenuItem.Checked = true;
            showSpritesToolStripMenuItem.CheckOnClick = true;
            showSpritesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showSpritesToolStripMenuItem.Name = "showSpritesToolStripMenuItem";
            showSpritesToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            showSpritesToolStripMenuItem.Text = "Show Sprites";
            showSpritesToolStripMenuItem.CheckedChanged += ShowSpritesToolStripMenuItem_CheckedChanged;
            // 
            // showEntrancesToolStripMenuItem
            // 
            showEntrancesToolStripMenuItem.Checked = true;
            showEntrancesToolStripMenuItem.CheckOnClick = true;
            showEntrancesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showEntrancesToolStripMenuItem.Name = "showEntrancesToolStripMenuItem";
            showEntrancesToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            showEntrancesToolStripMenuItem.Text = "Show Entrances";
            showEntrancesToolStripMenuItem.CheckedChanged += ShowSpritesToolStripMenuItem_CheckedChanged;
            // 
            // showExitsToolStripMenuItem
            // 
            showExitsToolStripMenuItem.Checked = true;
            showExitsToolStripMenuItem.CheckOnClick = true;
            showExitsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showExitsToolStripMenuItem.Name = "showExitsToolStripMenuItem";
            showExitsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            showExitsToolStripMenuItem.Text = "Show Exits";
            showExitsToolStripMenuItem.CheckedChanged += ShowSpritesToolStripMenuItem_CheckedChanged;
            // 
            // showTransportsToolStripMenuItem
            // 
            showTransportsToolStripMenuItem.Checked = true;
            showTransportsToolStripMenuItem.CheckOnClick = true;
            showTransportsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showTransportsToolStripMenuItem.Name = "showTransportsToolStripMenuItem";
            showTransportsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            showTransportsToolStripMenuItem.Text = "Show Transports";
            showTransportsToolStripMenuItem.CheckedChanged += ShowSpritesToolStripMenuItem_CheckedChanged;
            // 
            // showItemsToolStripMenuItem
            // 
            showItemsToolStripMenuItem.Checked = true;
            showItemsToolStripMenuItem.CheckOnClick = true;
            showItemsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showItemsToolStripMenuItem.Name = "showItemsToolStripMenuItem";
            showItemsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            showItemsToolStripMenuItem.Text = "Show Items";
            showItemsToolStripMenuItem.CheckedChanged += ShowSpritesToolStripMenuItem_CheckedChanged;
            // 
            // showEntranceExitPreviewToolStripMenuItem
            // 
            showEntranceExitPreviewToolStripMenuItem.Checked = true;
            showEntranceExitPreviewToolStripMenuItem.CheckOnClick = true;
            showEntranceExitPreviewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showEntranceExitPreviewToolStripMenuItem.Name = "showEntranceExitPreviewToolStripMenuItem";
            showEntranceExitPreviewToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            showEntranceExitPreviewToolStripMenuItem.Text = "Show Entrance/Exit Previews";
            showEntranceExitPreviewToolStripMenuItem.CheckedChanged += ShowSpritesToolStripMenuItem_CheckedChanged;
            // 
            // showGravesToolStripMenuItem
            // 
            showGravesToolStripMenuItem.Checked = true;
            showGravesToolStripMenuItem.CheckOnClick = true;
            showGravesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showGravesToolStripMenuItem.Name = "showGravesToolStripMenuItem";
            showGravesToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            showGravesToolStripMenuItem.Text = "Show Graves";
            showGravesToolStripMenuItem.CheckedChanged += ShowSpritesToolStripMenuItem_CheckedChanged;
            // 
            // overworldOverlayVisibleToolStripMenuItem
            // 
            overworldOverlayVisibleToolStripMenuItem.CheckOnClick = true;
            overworldOverlayVisibleToolStripMenuItem.Name = "overworldOverlayVisibleToolStripMenuItem";
            overworldOverlayVisibleToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            overworldOverlayVisibleToolStripMenuItem.Text = "Always Show Overworld Overlay";
            // 
            // showGridToolStripMenuItem1
            // 
            showGridToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { x8ToolStripMenuItemOW, x16ToolStripMenuItemOW, x32ToolStripMenuItemOW, noneToolStripMenuItemOW });
            showGridToolStripMenuItem1.Name = "showGridToolStripMenuItem1";
            showGridToolStripMenuItem1.Size = new System.Drawing.Size(244, 22);
            showGridToolStripMenuItem1.Text = "Show Grid";
            // 
            // x8ToolStripMenuItemOW
            // 
            x8ToolStripMenuItemOW.Name = "x8ToolStripMenuItemOW";
            x8ToolStripMenuItemOW.Size = new System.Drawing.Size(103, 22);
            x8ToolStripMenuItemOW.Text = "8x8";
            x8ToolStripMenuItemOW.Click += GridSizeToolStripMenuItem_Click;
            // 
            // x16ToolStripMenuItemOW
            // 
            x16ToolStripMenuItemOW.Name = "x16ToolStripMenuItemOW";
            x16ToolStripMenuItemOW.Size = new System.Drawing.Size(103, 22);
            x16ToolStripMenuItemOW.Text = "16x16";
            x16ToolStripMenuItemOW.Click += GridSizeToolStripMenuItem_Click;
            // 
            // x32ToolStripMenuItemOW
            // 
            x32ToolStripMenuItemOW.Name = "x32ToolStripMenuItemOW";
            x32ToolStripMenuItemOW.Size = new System.Drawing.Size(103, 22);
            x32ToolStripMenuItemOW.Text = "32x32";
            x32ToolStripMenuItemOW.Click += GridSizeToolStripMenuItem_Click;
            // 
            // noneToolStripMenuItemOW
            // 
            noneToolStripMenuItemOW.Checked = true;
            noneToolStripMenuItemOW.CheckState = System.Windows.Forms.CheckState.Checked;
            noneToolStripMenuItemOW.Name = "noneToolStripMenuItemOW";
            noneToolStripMenuItemOW.Size = new System.Drawing.Size(103, 22);
            noneToolStripMenuItemOW.Text = "None";
            noneToolStripMenuItemOW.Click += GridSizeToolStripMenuItem_Click;
            // 
            // useAreaSpecificBGColorToolStripMenuItem
            // 
            useAreaSpecificBGColorToolStripMenuItem.Checked = true;
            useAreaSpecificBGColorToolStripMenuItem.CheckOnClick = true;
            useAreaSpecificBGColorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            useAreaSpecificBGColorToolStripMenuItem.Name = "useAreaSpecificBGColorToolStripMenuItem";
            useAreaSpecificBGColorToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            useAreaSpecificBGColorToolStripMenuItem.Text = "Show Area Specific BG Color";
            useAreaSpecificBGColorToolStripMenuItem.ToolTipText = "For this to work in game, the \"Area Specific BG Color\" setting in project settings needs to be enabled.";
            useAreaSpecificBGColorToolStripMenuItem.CheckedChanged += UseAreaSpecificBGColorToolStripMenuItem_CheckedChanged;
            // 
            // showScratchPadGridToolStripMenuItem
            // 
            showScratchPadGridToolStripMenuItem.CheckOnClick = true;
            showScratchPadGridToolStripMenuItem.Name = "showScratchPadGridToolStripMenuItem";
            showScratchPadGridToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            showScratchPadGridToolStripMenuItem.Text = "Show Scratch Pad Grid";
            showScratchPadGridToolStripMenuItem.Click += ShowScratchPadGridToolStripMenuItem_Click;
            // 
            // showOverlayTextsToolStripMenuItem
            // 
            showOverlayTextsToolStripMenuItem.Checked = true;
            showOverlayTextsToolStripMenuItem.CheckOnClick = true;
            showOverlayTextsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showOverlayTextsToolStripMenuItem.Name = "showOverlayTextsToolStripMenuItem";
            showOverlayTextsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            showOverlayTextsToolStripMenuItem.Text = "Show Overlay Texts";
            showOverlayTextsToolStripMenuItem.CheckedChanged += ShowSpritesToolStripMenuItem_CheckedChanged;
            // 
            // windowToolStripMenuItem
            // 
            windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { vramViewerToolStripMenuItem, cGramViewerToolStripMenuItem, gfxGroupsetsToolStripMenuItem, palettesEditorToolStripMenuItem });
            windowToolStripMenuItem.Enabled = false;
            windowToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            windowToolStripMenuItem.Text = "Window";
            // 
            // vramViewerToolStripMenuItem
            // 
            vramViewerToolStripMenuItem.Name = "vramViewerToolStripMenuItem";
            vramViewerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            vramViewerToolStripMenuItem.Text = "VRAM Viewer";
            vramViewerToolStripMenuItem.Click += VRAMViewerToolStripMenuItem_Click;
            // 
            // cGramViewerToolStripMenuItem
            // 
            cGramViewerToolStripMenuItem.Name = "cGramViewerToolStripMenuItem";
            cGramViewerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            cGramViewerToolStripMenuItem.Text = "CGRAM Viewer";
            cGramViewerToolStripMenuItem.Click += CGRAMViewerToolStripMenuItem_Click;
            // 
            // gfxGroupsetsToolStripMenuItem
            // 
            gfxGroupsetsToolStripMenuItem.Name = "gfxGroupsetsToolStripMenuItem";
            gfxGroupsetsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            gfxGroupsetsToolStripMenuItem.Text = "Graphics Groups";
            gfxGroupsetsToolStripMenuItem.Click += GFXGroupsetsToolStripMenuItem_Click;
            // 
            // palettesEditorToolStripMenuItem
            // 
            palettesEditorToolStripMenuItem.Name = "palettesEditorToolStripMenuItem";
            palettesEditorToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            palettesEditorToolStripMenuItem.Text = "Palettes Editor";
            palettesEditorToolStripMenuItem.Click += PalettesEditorToolStripMenuItem_Click;
            // 
            // jPDebugToolStripMenuItem
            // 
            jPDebugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mapDataFromJPdoNotUseToolStripMenuItem1, captureMapJPdoNotUseToolStripMenuItem1, exportMapJPdoNotUseToolStripMenuItem1 });
            jPDebugToolStripMenuItem.Enabled = false;
            jPDebugToolStripMenuItem.Name = "jPDebugToolStripMenuItem";
            jPDebugToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            jPDebugToolStripMenuItem.Text = "JP Debug";
            jPDebugToolStripMenuItem.Visible = false;
            // 
            // mapDataFromJPdoNotUseToolStripMenuItem1
            // 
            mapDataFromJPdoNotUseToolStripMenuItem1.Name = "mapDataFromJPdoNotUseToolStripMenuItem1";
            mapDataFromJPdoNotUseToolStripMenuItem1.Size = new System.Drawing.Size(232, 22);
            mapDataFromJPdoNotUseToolStripMenuItem1.Text = "MapData from JP (do not use)";
            mapDataFromJPdoNotUseToolStripMenuItem1.Click += mapDataFromJPdoNotUseToolStripMenuItem_Click;
            // 
            // captureMapJPdoNotUseToolStripMenuItem1
            // 
            captureMapJPdoNotUseToolStripMenuItem1.Name = "captureMapJPdoNotUseToolStripMenuItem1";
            captureMapJPdoNotUseToolStripMenuItem1.Size = new System.Drawing.Size(232, 22);
            captureMapJPdoNotUseToolStripMenuItem1.Text = "Capture Map JP (do not use)";
            captureMapJPdoNotUseToolStripMenuItem1.Click += CaptureMapJPdoNotUseToolStripMenuItem_Click;
            // 
            // exportMapJPdoNotUseToolStripMenuItem1
            // 
            exportMapJPdoNotUseToolStripMenuItem1.Name = "exportMapJPdoNotUseToolStripMenuItem1";
            exportMapJPdoNotUseToolStripMenuItem1.Size = new System.Drawing.Size(232, 22);
            exportMapJPdoNotUseToolStripMenuItem1.Text = "Export Map JP (do not use)";
            exportMapJPdoNotUseToolStripMenuItem1.Click += ExportMapJPdoNotUseToolStripMenuItem_Click;
            // 
            // ExperimentalToolStripMenuItem1
            // 
            ExperimentalToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { flipMapHorizontallyToolStripMenuItem, saveMapsOnlyToolStripMenuItem, saveVRAMAsPngToolStripMenuItem, moveRoomsToOtherROMToolStripMenuItem, exportImageMapMultipleROMsToolStripMenuItem, generatePaletteToolStripMenuItem, useExpandedOWPaletteToolStripMenuItem });
            ExperimentalToolStripMenuItem1.Enabled = false;
            ExperimentalToolStripMenuItem1.Name = "ExperimentalToolStripMenuItem1";
            ExperimentalToolStripMenuItem1.Size = new System.Drawing.Size(134, 20);
            ExperimentalToolStripMenuItem1.Text = "Experimental Features";
            ExperimentalToolStripMenuItem1.Visible = false;
            // 
            // flipMapHorizontallyToolStripMenuItem
            // 
            flipMapHorizontallyToolStripMenuItem.Name = "flipMapHorizontallyToolStripMenuItem";
            flipMapHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            flipMapHorizontallyToolStripMenuItem.Text = "Flip Map Horizontally";
            flipMapHorizontallyToolStripMenuItem.Click += flipMapHorizontallyToolStripMenuItem_Click;
            // 
            // saveMapsOnlyToolStripMenuItem
            // 
            saveMapsOnlyToolStripMenuItem.Name = "saveMapsOnlyToolStripMenuItem";
            saveMapsOnlyToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            saveMapsOnlyToolStripMenuItem.Text = "Save Maps Only";
            saveMapsOnlyToolStripMenuItem.Click += SaveMapsOnlyToolStripMenuItem_Click;
            // 
            // saveVRAMAsPngToolStripMenuItem
            // 
            saveVRAMAsPngToolStripMenuItem.Name = "saveVRAMAsPngToolStripMenuItem";
            saveVRAMAsPngToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            saveVRAMAsPngToolStripMenuItem.Text = "Save VRAM as PNG";
            saveVRAMAsPngToolStripMenuItem.Click += SaveVRAMAsPngToolStripMenuItem_Click;
            // 
            // moveRoomsToOtherROMToolStripMenuItem
            // 
            moveRoomsToOtherROMToolStripMenuItem.Name = "moveRoomsToOtherROMToolStripMenuItem";
            moveRoomsToOtherROMToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            moveRoomsToOtherROMToolStripMenuItem.Text = "Move Rooms to Another ROM…";
            moveRoomsToOtherROMToolStripMenuItem.Click += MoveRoomsToOtherROMToolStripMenuItem_Click;
            // 
            // exportImageMapMultipleROMsToolStripMenuItem
            // 
            exportImageMapMultipleROMsToolStripMenuItem.Name = "exportImageMapMultipleROMsToolStripMenuItem";
            exportImageMapMultipleROMsToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            exportImageMapMultipleROMsToolStripMenuItem.Text = "Export Image Map (Multiple ROMs)";
            exportImageMapMultipleROMsToolStripMenuItem.Click += ExportImageMapMultipleROMsToolStripMenuItem_Click;
            // 
            // generatePaletteToolStripMenuItem
            // 
            generatePaletteToolStripMenuItem.Name = "generatePaletteToolStripMenuItem";
            generatePaletteToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            generatePaletteToolStripMenuItem.Text = "Generate Palette";
            generatePaletteToolStripMenuItem.Click += generatePaletteToolStripMenuItem_Click;
            // 
            // useExpandedOWPaletteToolStripMenuItem
            // 
            useExpandedOWPaletteToolStripMenuItem.Name = "useExpandedOWPaletteToolStripMenuItem";
            useExpandedOWPaletteToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            useExpandedOWPaletteToolStripMenuItem.Text = "Use Expanded OW Palette";
            useExpandedOWPaletteToolStripMenuItem.Click += useExpandedOWPaletteToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { howToUseToolStripMenuItem, patchNotesToolStripMenuItem, aboutToolStripMenuItem });
            helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // howToUseToolStripMenuItem
            // 
            howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            howToUseToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            howToUseToolStripMenuItem.Text = "How to Use";
            howToUseToolStripMenuItem.Click += HowToUseToolStripMenuItem_Click;
            // 
            // patchNotesToolStripMenuItem
            // 
            patchNotesToolStripMenuItem.Name = "patchNotesToolStripMenuItem";
            patchNotesToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            patchNotesToolStripMenuItem.Text = "Patch Notes";
            patchNotesToolStripMenuItem.Click += PatchNotesToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // discordToolStripMenuItem
            // 
            discordToolStripMenuItem.Name = "discordToolStripMenuItem";
            discordToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            discordToolStripMenuItem.Text = "Discord";
            discordToolStripMenuItem.Click += DiscordToolStripMenuItem_Click;
            // 
            // godownButton
            // 
            godownButton.Image = Properties.Resources.arrow_Down_16xLG;
            godownButton.Location = new System.Drawing.Point(134, 494);
            godownButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            godownButton.Name = "godownButton";
            godownButton.Size = new System.Drawing.Size(27, 27);
            godownButton.TabIndex = 68;
            godownButton.UseVisualStyleBackColor = true;
            godownButton.Click += OpenDownRoomToolStripMenuItem_Click;
            // 
            // goleftButton
            // 
            goleftButton.Image = Properties.Resources.arrow_previous_16xLG;
            goleftButton.Location = new System.Drawing.Point(110, 470);
            goleftButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            goleftButton.Name = "goleftButton";
            goleftButton.Size = new System.Drawing.Size(27, 27);
            goleftButton.TabIndex = 67;
            goleftButton.UseVisualStyleBackColor = true;
            goleftButton.Click += OpenLeftRoomToolStripMenuItem_Click;
            // 
            // gorightButton
            // 
            gorightButton.Image = Properties.Resources.arrow_Next_16xLG;
            gorightButton.Location = new System.Drawing.Point(159, 470);
            gorightButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gorightButton.Name = "gorightButton";
            gorightButton.Size = new System.Drawing.Size(27, 27);
            gorightButton.TabIndex = 66;
            gorightButton.UseVisualStyleBackColor = true;
            gorightButton.Click += openRightRoomToolStripMenuItem_Click;
            // 
            // goupButton
            // 
            goupButton.Image = Properties.Resources.arrow_Up_16xLG;
            goupButton.Location = new System.Drawing.Point(134, 445);
            goupButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            goupButton.Name = "goupButton";
            goupButton.Size = new System.Drawing.Size(27, 27);
            goupButton.TabIndex = 65;
            goupButton.UseVisualStyleBackColor = true;
            goupButton.Click += OpenUpRoomToolStripMenuItem_Click;
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.SystemColors.Control;
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(thumbnailBox);
            panel3.Controls.Add(warningLabel);
            panel3.Controls.Add(godownButton);
            panel3.Controls.Add(goleftButton);
            panel3.Controls.Add(gorightButton);
            panel3.Controls.Add(goupButton);
            panel3.Controls.Add(mapPicturebox);
            panel3.Controls.Add(maphoverCheckbox);
            panel3.Controls.Add(mapInfosLabel);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(313, 641);
            panel3.TabIndex = 64;
            panel3.Paint += panel3_Paint;
            // 
            // panel5
            // 
            panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel5.Controls.Add(hexbox4);
            panel5.Controls.Add(hexbox3);
            panel5.Controls.Add(hexbox2);
            panel5.Controls.Add(hexbox1);
            panel5.Location = new System.Drawing.Point(2, 581);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(164, 42);
            panel5.TabIndex = 69;
            // 
            // hexbox4
            // 
            hexbox4.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            hexbox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            hexbox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            hexbox4.Decimal = false;
            hexbox4.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            hexbox4.ForeColor = System.Drawing.Color.White;
            hexbox4.HexValue = 0;
            hexbox4.Location = new System.Drawing.Point(125, 9);
            hexbox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            hexbox4.MaxLength = 2;
            hexbox4.MaxValue = 255;
            hexbox4.MinValue = 0;
            hexbox4.Name = "hexbox4";
            hexbox4.Size = new System.Drawing.Size(32, 23);
            hexbox4.TabIndex = 91;
            hexbox4.Text = "00";
            hexbox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hexbox3
            // 
            hexbox3.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            hexbox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            hexbox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            hexbox3.Decimal = false;
            hexbox3.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            hexbox3.ForeColor = System.Drawing.Color.White;
            hexbox3.HexValue = 0;
            hexbox3.Location = new System.Drawing.Point(85, 9);
            hexbox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            hexbox3.MaxLength = 2;
            hexbox3.MaxValue = 255;
            hexbox3.MinValue = 0;
            hexbox3.Name = "hexbox3";
            hexbox3.Size = new System.Drawing.Size(32, 23);
            hexbox3.TabIndex = 90;
            hexbox3.Text = "00";
            hexbox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hexbox2
            // 
            hexbox2.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            hexbox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            hexbox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            hexbox2.Decimal = false;
            hexbox2.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            hexbox2.ForeColor = System.Drawing.Color.White;
            hexbox2.HexValue = 0;
            hexbox2.Location = new System.Drawing.Point(45, 9);
            hexbox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            hexbox2.MaxLength = 2;
            hexbox2.MaxValue = 255;
            hexbox2.MinValue = 0;
            hexbox2.Name = "hexbox2";
            hexbox2.Size = new System.Drawing.Size(32, 23);
            hexbox2.TabIndex = 89;
            hexbox2.Text = "00";
            hexbox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hexbox1
            // 
            hexbox1.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            hexbox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            hexbox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            hexbox1.Decimal = false;
            hexbox1.Digits = Gui.ExtraForms.Hexbox.HexDigits.Two;
            hexbox1.ForeColor = System.Drawing.Color.White;
            hexbox1.HexValue = 0;
            hexbox1.Location = new System.Drawing.Point(5, 9);
            hexbox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            hexbox1.MaxLength = 2;
            hexbox1.MaxValue = 255;
            hexbox1.MinValue = 0;
            hexbox1.Name = "hexbox1";
            hexbox1.Size = new System.Drawing.Size(32, 23);
            hexbox1.TabIndex = 88;
            hexbox1.Text = "00";
            hexbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // thumbnailBox
            // 
            thumbnailBox.Location = new System.Drawing.Point(0, 420);
            thumbnailBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            thumbnailBox.Name = "thumbnailBox";
            thumbnailBox.Size = new System.Drawing.Size(28, 28);
            thumbnailBox.TabIndex = 21;
            thumbnailBox.TabStop = false;
            thumbnailBox.Visible = false;
            thumbnailBox.Paint += ThumbnailBox_Paint;
            // 
            // warningLabel
            // 
            warningLabel.AutoSize = true;
            warningLabel.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            warningLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            warningLabel.ForeColor = System.Drawing.Color.OrangeRed;
            warningLabel.Location = new System.Drawing.Point(0, 626);
            warningLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            warningLabel.MinimumSize = new System.Drawing.Size(327, 0);
            warningLabel.Name = "warningLabel";
            warningLabel.Size = new System.Drawing.Size(327, 15);
            warningLabel.TabIndex = 64;
            // 
            // mapPicturebox
            // 
            mapPicturebox.Location = new System.Drawing.Point(4, 7);
            mapPicturebox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            mapPicturebox.Name = "mapPicturebox";
            mapPicturebox.Size = new System.Drawing.Size(299, 360);
            mapPicturebox.TabIndex = 61;
            mapPicturebox.TabStop = false;
            mapPicturebox.Paint += MapPicturebox_Paint;
            mapPicturebox.MouseDoubleClick += mapPicturebox_MouseDoubleClick_1;
            mapPicturebox.MouseDown += MapPicturebox_MouseDown;
            mapPicturebox.MouseLeave += MapPicturebox_MouseLeave;
            mapPicturebox.MouseMove += MapPicturebox_MouseMove;
            mapPicturebox.MouseUp += MapPicturebox_MouseUp;
            // 
            // maphoverCheckbox
            // 
            maphoverCheckbox.AutoSize = true;
            maphoverCheckbox.ForeColor = System.Drawing.Color.Black;
            maphoverCheckbox.Location = new System.Drawing.Point(44, 378);
            maphoverCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            maphoverCheckbox.Name = "maphoverCheckbox";
            maphoverCheckbox.Size = new System.Drawing.Size(181, 19);
            maphoverCheckbox.TabIndex = 63;
            maphoverCheckbox.Text = "Show room preview on hover";
            maphoverCheckbox.UseVisualStyleBackColor = true;
            // 
            // mapInfosLabel
            // 
            mapInfosLabel.AutoSize = true;
            mapInfosLabel.ForeColor = System.Drawing.Color.Black;
            mapInfosLabel.Location = new System.Drawing.Point(9, 402);
            mapInfosLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            mapInfosLabel.Name = "mapInfosLabel";
            mapInfosLabel.Size = new System.Drawing.Size(268, 15);
            mapInfosLabel.TabIndex = 62;
            mapInfosLabel.Text = "Double click to open room; right click for preview";
            // 
            // DunRoomTabControl
            // 
            DunRoomTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            DunRoomTabControl.HotTrack = true;
            DunRoomTabControl.ItemSize = new System.Drawing.Size(48, 18);
            DunRoomTabControl.Location = new System.Drawing.Point(0, 0);
            DunRoomTabControl.Margin = new System.Windows.Forms.Padding(0);
            DunRoomTabControl.Multiline = true;
            DunRoomTabControl.Name = "DunRoomTabControl";
            DunRoomTabControl.Padding = new System.Drawing.Point(3, 3);
            DunRoomTabControl.SelectedIndex = 0;
            DunRoomTabControl.Size = new System.Drawing.Size(701, 23);
            DunRoomTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            DunRoomTabControl.TabIndex = 17;
            DunRoomTabControl.DrawItem += DrawOnTab;
            DunRoomTabControl.SelectedIndexChanged += DunRoomTabControl_SelectedIndexChanged;
            DunRoomTabControl.Deselecting += DunRoomTabControl_Deselecting;
            DunRoomTabControl.ControlAdded += DunRoomTabControl_ControlAdded;
            DunRoomTabControl.ControlRemoved += DunRoomTabControl_ControlRemoved;
            DunRoomTabControl.MouseClick += DunRoomTabControl_MouseClick;
            DunRoomTabControl.MouseDown += DunRoomTabControl_MouseDown;
            DunRoomTabControl.MouseEnter += DunRoomTabControl_MouseEnter;
            DunRoomTabControl.MouseLeave += DunRoomTabControl_MouseLeave;
            DunRoomTabControl.MouseMove += DunRoomTabControl_MouseMove;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(354, 219);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(customPanel3);
            splitContainer1.Panel1.Controls.Add(DunRoomTabControl);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Panel2MinSize = 267;
            splitContainer1.Size = new System.Drawing.Size(1019, 641);
            splitContainer1.SplitterDistance = 701;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 23;
            // 
            // customPanel3
            // 
            customPanel3.AutoScroll = true;
            customPanel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            customPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            customPanel3.ForeColor = System.Drawing.Color.FromArgb(240, 240, 240);
            customPanel3.Location = new System.Drawing.Point(0, 23);
            customPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customPanel3.Name = "customPanel3";
            customPanel3.Size = new System.Drawing.Size(701, 618);
            customPanel3.TabIndex = 19;
            // 
            // networkBgWorker
            // 
            networkBgWorker.DoWork += NetworkBgWorker_DoWork;
            // 
            // networkBgWorker2
            // 
            networkBgWorker2.WorkerSupportsCancellation = true;
            networkBgWorker2.DoWork += NetworkBgWorker2_DoWork;
            // 
            // loadTimer
            // 
            loadTimer.Interval = 1000;
            loadTimer.Tick += LoadTimer_Tick;
            // 
            // crc32timer
            // 
            crc32timer.Enabled = true;
            crc32timer.Interval = 10000;
            crc32timer.Tick += CRC32timer_Tick;
            // 
            // exportPNGTimer
            // 
            exportPNGTimer.Interval = 2000;
            exportPNGTimer.Tick += ExportPNGTimer_Tick;
            // 
            // DungeonMain
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(1373, 885);
            Controls.Add(splitContainer1);
            Controls.Add(headerGroupbox);
            Controls.Add(splitter1);
            Controls.Add(toolboxPanel);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(editorsTabControl);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "DungeonMain";
            Text = "ThisTextIsHandledByTheConstructorAndWillShowThisInTheDesigner";
            FormClosing += zscreamForm_FormClosing_1;
            FormClosed += DungeonMain_FormClosed;
            Load += Form1_Load;
            LocationChanged += DungeonMain_LocationChanged;
            SizeChanged += DungeonMain_SizeChanged;
            DragDrop += DungeonMain_DragDrop;
            DragEnter += DungeonMain_DragEnter;
            KeyDown += DungeonMain_KeyDown;
            KeyUp += DungeonMain_KeyUp;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            nothingselectedcontextMenu.ResumeLayout(false);
            singleselectedcontextMenu.ResumeLayout(false);
            groupselectedcontextMenu.ResumeLayout(false);
            toolboxPanel.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            entrancetabPage.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            objectstabPage.ResumeLayout(false);
            objectstabPage.PerformLayout();
            panel1.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            customPanel1.ResumeLayout(false);
            customPanel1.PerformLayout();
            panel4.ResumeLayout(false);
            edit8x8.ResumeLayout(false);
            edit8x8Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editBox8x8).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)edit8x8palettebox).EndInit();
            headerGroupbox.ResumeLayout(false);
            headerGroupbox.PerformLayout();
            overlayPanel.ResumeLayout(false);
            overlayPanel.PerformLayout();
            selectedGroupbox.ResumeLayout(false);
            selectedGroupbox.PerformLayout();
            roomHeaderPanel.ResumeLayout(false);
            roomHeaderPanel.PerformLayout();
            doorselectPanel.ResumeLayout(false);
            doorselectPanel.PerformLayout();
            potitemobjectPanel.ResumeLayout(false);
            potitemobjectPanel.PerformLayout();
            spritepropertyPanel.ResumeLayout(false);
            spritepropertyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)spritesubtypeUpDown).EndInit();
            collisionMapPanel.ResumeLayout(false);
            collisionMapPanel.PerformLayout();
            editorsTabControl.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)thumbnailBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)mapPicturebox).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

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
        public System.Windows.Forms.ToolStripMenuItem hideItemsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hideChestItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem selectAllRoomsForExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectedAllRoomsForExportToolStripMenuItem;
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
        public System.Windows.Forms.ComboBox roomProperty_collision;
        public System.Windows.Forms.ComboBox roomProperty_bg2;
        public System.Windows.Forms.ComboBox roomProperty_effect;
        public System.Windows.Forms.ComboBox roomProperty_tag2;
        public System.Windows.Forms.ComboBox roomProperty_tag1;
        public System.Windows.Forms.CheckBox roomProperty_sortsprite;
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
        private System.Windows.Forms.Label label40;
        public System.Windows.Forms.CheckBox entranceProperty_bg;
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
        private System.Windows.Forms.ToolStripMenuItem exportAllRoomsToolStripMenuItem;
        private System.Windows.Forms.TabPage ScreenEditor;
        private System.Windows.Forms.ToolStripButton debugToolStripButton;
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
        private System.Windows.Forms.TabPage edit8x8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox edit8x8myCheckbox;
        private System.Windows.Forms.CheckBox edit8x8mxCheckbox;
        private System.Windows.Forms.PictureBox editBox8x8;
        private System.Windows.Forms.Panel edit8x8Panel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox edit8x8palettebox;
        private System.Windows.Forms.ToolStripMenuItem moveRoomsToOtherROMToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem x8ToolStripMenuItemOW;
        private System.Windows.Forms.ToolStripMenuItem x16ToolStripMenuItemOW;
        private System.Windows.Forms.ToolStripMenuItem x32ToolStripMenuItemOW;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItemOWOW;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem lockoverworldToolStripItem;
        private System.Windows.Forms.PictureBox thumbnailBox;
        private System.Windows.Forms.ToolStripButton collisionModeButton;
        public System.Windows.Forms.Panel collisionMapPanel;
        public System.Windows.Forms.ComboBox tileTypeCombobox;
        public System.Windows.Forms.Label collisionMapLabel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label28;
        public System.Windows.Forms.CheckBox bg2checkbox5;
        public System.Windows.Forms.CheckBox bg2checkbox4;
        public System.Windows.Forms.CheckBox bg2checkbox3;
        public System.Windows.Forms.CheckBox bg2checkbox2;
        public System.Windows.Forms.CheckBox bg2checkbox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label42;
        public System.Windows.Forms.CheckBox entranceProperty_vscroll;
        public System.Windows.Forms.CheckBox entranceProperty_hscroll;
        private System.Windows.Forms.Label label44;
        public System.Windows.Forms.RadioButton entranceProperty_quadbr;
        public System.Windows.Forms.RadioButton entranceProperty_quadtr;
        public System.Windows.Forms.RadioButton entranceProperty_quadbl;
        public System.Windows.Forms.RadioButton entranceProperty_quadtl;
        private System.Windows.Forms.CheckBox doorCheckbox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl DunRoomTabControl;
        private CustomPanel customPanel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
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
        private System.Windows.Forms.ToolStripMenuItem autoDoorsToolStripMenuItem;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label29;
        public System.Windows.Forms.ToolStripMenuItem overworldOverlayVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discordToolStripMenuItem;
        private Gui.ExtraForms.Hexbox RoomProperty_Layout;
        private Gui.ExtraForms.Hexbox RoomProperty_Blockset;
        private Gui.ExtraForms.Hexbox RoomProperty_MessageID;
        private Gui.ExtraForms.Hexbox RoomProperty_SpriteSet;
        private Gui.ExtraForms.Hexbox RoomProperty_Palette;
        private Gui.ExtraForms.Hexbox RoomProperty_Floor2;
        private Gui.ExtraForms.Hexbox RoomProperty_Floor1;
        private Gui.ExtraForms.Hexbox RoomProperty_DestinationStair1;
        private Gui.ExtraForms.Hexbox RoomProperty_DestinationPit;
        private Gui.ExtraForms.Hexbox RoomProperty_DestinationStair4;
        private Gui.ExtraForms.Hexbox RoomProperty_DestinationStair3;
        private Gui.ExtraForms.Hexbox RoomProperty_DestinationStair2;
        private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryFE;
        private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryFW;
        private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryQE;
        private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryQW;
        private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryFS;
        private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryFN;
        private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryQS;
        private Gui.ExtraForms.Hexbox EntranceProperty_BoundaryQN;
        private Gui.ExtraForms.Hexbox EntranceProperties_CameraTriggerY;
        private Gui.ExtraForms.Hexbox EntranceProperties_CameraTriggerX;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private Gui.ExtraForms.Hexbox EntranceProperties_CameraX;
        private Gui.ExtraForms.Hexbox EntranceProperties_CameraY;
        private Gui.ExtraForms.Hexbox EntranceProperties_PlayerY;
        private Gui.ExtraForms.Hexbox EntranceProperties_PlayerX;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label38;
        private Gui.ExtraForms.Hexbox EntranceProperties_RoomID;
        private Gui.ExtraForms.Hexbox EntranceProperties_Blockset;
        private Gui.ExtraForms.Hexbox EntranceProperties_Music;
        private Gui.ExtraForms.Hexbox EntranceProperties_DungeonID;
        private System.Windows.Forms.ComboBox EntranceProperties_FloorSel;
        public System.Windows.Forms.Label SelectedObjectDataLayer;
        public System.Windows.Forms.Label SelectedObjectDataSize;
        public System.Windows.Forms.Label SelectedObjectDataY;
        public System.Windows.Forms.Label SelectedObjectDataX;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label SelectedObjectDataHEX;
        private System.Windows.Forms.ToolStripMenuItem clearDWTilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLWToDWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTiles32CountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useAreaSpecificBGColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showScratchPadGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStairIndexToolStripMenuItem;
        private System.Windows.Forms.TabPage MusicEditor;
        private System.ComponentModel.BackgroundWorker networkBgWorker;
        private System.ComponentModel.BackgroundWorker networkBgWorker2;
        private System.Windows.Forms.Timer crc32timer;
        private System.Windows.Forms.ToolStripMenuItem exportImageMapMultipleROMsToolStripMenuItem;
        private System.Windows.Forms.Timer exportPNGTimer;
        public System.Windows.Forms.Timer loadTimer;
        private System.Windows.Forms.ToolStripMenuItem saveToNewROMToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadVanillaCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyFastROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildROMwithASMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedRoomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDungeonToolStripMenuItem;
        private System.Windows.Forms.TabPage SpriteEditor;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportOverlayAsASMToolStripMenuItem;
        private System.Windows.Forms.TabPage NamingEditor;
        public System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.ToolStripMenuItem exportOverlayAnimationAsASMInClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOverlayTextsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showUniqueTile32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUnusedTiles16ToToolStripMenuItem;
        private System.Windows.Forms.CheckBox facedownCheckbox;
        private Gui.ExtraForms.Hexbox doorxHexbox;
        private Gui.ExtraForms.Hexbox dooryHexbox;
        private System.Windows.Forms.ToolStripMenuItem generatePaletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useExpandedOWPaletteToolStripMenuItem;
        public System.Windows.Forms.Panel overlayPanel;
        public System.Windows.Forms.ComboBox overlayCombobox;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItemOW;
        public System.Windows.Forms.Label label39;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        public System.Windows.Forms.ToolStripMenuItem hideSpritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boxesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem showSpriteIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem x512ToolStripMenuItemOW;
        private System.Windows.Forms.ToolStripMenuItem showGravesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x256ToolStripMenuItemOW;
        private System.Windows.Forms.Button goupButton;
        private System.Windows.Forms.Button gorightButton;
        private System.Windows.Forms.Button goleftButton;
        private System.Windows.Forms.Button godownButton;
        private System.Windows.Forms.Panel panel5;
        private Gui.ExtraForms.Hexbox hexbox4;
        private Gui.ExtraForms.Hexbox hexbox3;
        private Gui.ExtraForms.Hexbox hexbox2;
        private Gui.ExtraForms.Hexbox hexbox1;
    }
}

