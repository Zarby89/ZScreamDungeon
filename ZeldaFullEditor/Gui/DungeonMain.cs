namespace ZeldaFullEditor
{
	public partial class ZScreamForm : Form
	{
		// Registers a hot key with Windows.
		[DllImport("user32.dll")]
		private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
		// Unregisters the hot key with Windows.
		[DllImport("user32.dll")]
		private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool LockWindowUpdate(IntPtr hWnd);

		private readonly Object_Designer objDesigner;
		public GfxImportExport gfxEditor;
		private readonly DungeonViewer dungeonViewer;
		private string projectFilename = "";
		public bool projectLoaded { get; set; }
		public bool anychange { get; set; }
		public ChestPicker chestPicker;
		private PaletteEditor paletteForm;
		public ScreenEditor screenEditor;
		public string loadFromExported = "";

		// Groups of options for the Scene
		public bool ShowSprites => showSpritesToolStripMenuItem.Checked;
		public bool showChest => hideChestItemsToolStripMenuItem.Checked;
		public bool showItems => hideItemsToolStripMenuItem.Checked;
		public bool showDoorsIDs => showDoorIDsToolStripMenuItem.Checked;
		public bool showChestIDs => showChestsIDsToolStripMenuItem.Checked;
		public bool showSpriteText => textSpriteToolStripMenuItem.Checked;
		public bool showChestText => textChestItemToolStripMenuItem.Checked;
		public bool showItemsText => textPotItemToolStripMenuItem.Checked;
		public bool canSelectUnselectedBG => unselectedBGTransparentToolStripMenuItem.Checked;
		public bool ShowUWGrid => showGridToolStripMenuItem.Checked;
		public bool visibleEntranceGFX => disableEntranceGFXToolStripMenuItem.Checked;
		public bool x2zoom => xScreenToolStripMenuItem.Checked;
		public bool ShowBG2Outline => showBG2MaskOutlineToolStripMenuItem.Checked;
		public bool showEntrances => showEntrancesToolStripMenuItem.Checked;
		public bool showExits => showExitsToolStripMenuItem.Checked;
		public bool showFlute => showTransportsToolStripMenuItem.Checked;

		public bool ShowLayer1 => showBG1ToolStripMenuItem.Checked;
		public bool ShowLayer2 => showBG2ToolStripMenuItem.Checked;


		public GfxGroupsForm gfxGroupsForm;

		// TODO move this?
		public int lastRoomID = -1;

		// TODO: save this in a config file and load the values into this array on startup
		public bool[] saveSettingsArr = new[]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true
		};

		public ZScreamForm()
		{
			InitializeComponent();

			Text = $"{UIText.APPNAME} - {UIText.VERSION}";

			objDesigner = new Object_Designer();
			dungeonViewer = new DungeonViewer();
			chestPicker = new ChestPicker();
			screenEditor = new ScreenEditor();

			allbgsButton.Tag = DungeonEditMode.LayerAll;
			bg1modeButton.Tag = DungeonEditMode.Layer1;
			bg2modeButton.Tag = DungeonEditMode.Layer2;
			bg3modeButton.Tag = DungeonEditMode.Layer3;
			spritemodeButton.Tag = DungeonEditMode.Sprites;
			blockmodeButton.Tag = DungeonEditMode.Blocks;
			torchmodeButton.Tag = DungeonEditMode.Torches;
			potmodeButton.Tag = DungeonEditMode.Secrets;
			doormodeButton.Tag = DungeonEditMode.Doors;
			collisionModeButton.Tag = DungeonEditMode.CollisionMap;

			penModeButton.Tag = OverworldEditMode.Tile16;
			fillModeButton.Tag = OverworldEditMode.Tile16Fill;
			entranceModeButton.Tag = OverworldEditMode.Entrances;
			exitModeButton.Tag = OverworldEditMode.Exits;
			itemModeButton.Tag = OverworldEditMode.Secrets;
			owSpriteModeButton.Tag = OverworldEditMode.Sprites;
			transportModeButton.Tag = OverworldEditMode.Transports;
			overlayButton.Tag = OverworldEditMode.Overlay;
			gravestoneButton.Tag = OverworldEditMode.Gravestones;
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			ZScreamer.ActiveGraphicsManager.fontgfx16Ptr = Marshal.AllocHGlobal((256 * 256));
			ZScreamer.ActiveGraphicsManager.currentfontgfx16Ptr = Marshal.AllocHGlobal(172 * 20000);
			ZScreamer.ActiveGraphicsManager.overworldMapPointer = Marshal.AllocHGlobal(0x40000);
			ZScreamer.ActiveGraphicsManager.owactualMapPointer = Marshal.AllocHGlobal(0x40000);

			// TODO load all settings
			//if (Settings.Default.favoriteObjects.Count < 0xFFF)
			//{
			//	while (Settings.Default.favoriteObjects.Count < 0xFFF)
			//	{
			//		Settings.Default.favoriteObjects.Add("false");
			//	}
			//}

			//layoutForm = new RoomLayout(ZS);
			gfxEditor = new GfxImportExport();
			ZScreamer.ActiveGraphicsManager.initGfx();

			refreshRecentsFiles();
			objDesigner.Visible = false;
			gfxEditor.Visible = false;
			dungeonViewer.Visible = false;
			screenEditor.Visible = false;

			objDesigner.Dock = DockStyle.Fill;
			gfxEditor.Dock = DockStyle.Fill;
			dungeonViewer.Dock = DockStyle.Fill;
			screenEditor.Dock = DockStyle.Fill;

			Controls.Add(objDesigner);
			Controls.Add(gfxEditor);
			Controls.Add(dungeonViewer);
			Controls.Add(screenEditor);

			// If we are in a debug version, show the Experimental Features drop down menu.
#if DEBUG
			ExperimentalToolStripMenuItem1.Visible = true;
			jPDebugToolStripMenuItem.Visible = true;
#endif
		}

		private void ModeButton_Click(object sender, EventArgs e)
		{
			switch (sender)
			{
				case DungeonToolStripButton d:
					ZScreamer.ActiveScreamer.CurrentUWMode = (DungeonEditMode) d.Tag;
					UpdateEverythingForUnderworldMode();
					break;

				case OverworldToolStripButton d:
					ZScreamer.ActiveScreamer.CurrentOWMode = (OverworldEditMode) d.Tag;
					UpdateEverythingForOverworldMode();
					break;
			}
		}

		public void UpdateEverythingForUnderworldMode()
		{
			foreach (var o in toolStrip1.Items)
			{
				if (o is DungeonToolStripButton d && d.Tag is DungeonEditMode m)
				{
					d.Checked = m == ZScreamer.ActiveUWMode;
				}
			}
		}

		public void UpdateEverythingForOverworldMode()
		{
			foreach (var o in toolStrip1.Items)
			{
				if (o is OverworldToolStripButton d && d.Tag is OverworldEditMode m)
				{
					d.Checked = m == ZScreamer.ActiveOWMode;
				}
			}
		}

		public void AdjustContextMenuForSelectionChange()
		{
			bool theresASelection = (ZScreamer.ActiveUWScene?.Room?.SelectedObjects.Count ?? 0) > 0;

			var mode = ZScreamer.ActiveUWMode;

			UWContextSendToBack.Enabled = theresASelection;
			UWContextSendToFront.Enabled = theresASelection;

			UWContextSendToLayer1.Enabled = theresASelection && mode != DungeonEditMode.Layer1;
			UWContextSendToLayer2.Enabled = theresASelection && mode != DungeonEditMode.Layer2;
			UWContextSendToLayer3.Enabled = theresASelection && mode != DungeonEditMode.Layer3;

			UWContextCopy.Enabled = theresASelection;
			UWContextCut.Enabled = theresASelection;
			UWContextSelectNone.Enabled = theresASelection;
		}

		public void AdjustContextMenu()
		{
			var mode = ZScreamer.ActiveUWMode;
			switch (mode)
			{
				case DungeonEditMode.Layer1:
				case DungeonEditMode.Layer2:
				case DungeonEditMode.Layer3:
				case DungeonEditMode.LayerAll:
					UWContextInsert.Visible = false;
					UWContextSendToBack.Visible = true;
					UWContextSendToFront.Visible = true;
					UWContextSendToLayer1.Visible = true;
					UWContextSendToLayer2.Visible = true;
					UWContextSendToLayer3.Visible = true;
					break;

				case DungeonEditMode.Doors:
					UWContextInsert.Visible = true;
					UWContextSendToBack.Visible = true;
					UWContextSendToFront.Visible = true;
					UWContextSendToLayer1.Visible = false;
					UWContextSendToLayer2.Visible = false;
					UWContextSendToLayer3.Visible = false;
					break;

				case DungeonEditMode.Sprites:
					UWContextInsert.Visible = false;
					UWContextSendToBack.Visible = true;
					UWContextSendToFront.Visible = true;
					UWContextSendToLayer1.Visible = true;
					UWContextSendToLayer2.Visible = true;
					UWContextSendToLayer3.Visible = false;
					break;

				case DungeonEditMode.CollisionMap:
					UWContextInsert.Visible = false;
					UWContextSendToBack.Visible = false;
					UWContextSendToFront.Visible = false;
					UWContextSendToLayer1.Visible = false;
					UWContextSendToLayer2.Visible = false;
					UWContextSendToLayer3.Visible = false;
					break;

				default:
					UWContextInsert.Visible = true;
					UWContextSendToBack.Visible = false;
					UWContextSendToFront.Visible = false;
					UWContextSendToLayer1.Visible = true;
					UWContextSendToLayer2.Visible = true;
					UWContextSendToLayer3.Visible = false;
					break;
			}

			AdjustContextMenuForSelectionChange();
		}

		//Stopwatch sw = new Stopwatch();
		// TODO : Move that to the save class
		// TODO move saves to ZScreamer.cs
		public void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Save Functions
			// Expand ROM to 2MB

			//sw.Reset();
			//sw.Start();

			DungeonEditor.SaveRooms();

			anychange = false;
			//tabControl2.Refresh();
			//sw.Stop();
			//Console.WriteLine("Saved all unsaved rooms - " + sw.ElapsedMilliseconds.ToString() + "ms");

			//sw.Reset();
			//sw.Start();
			byte[] romBackup = ZScreamer.ActiveROM.DataStream.DeepCopy();

			// TODO move to ZS
			//sw.Stop();
			//Console.WriteLine("Saved all rooms - " + sw.ElapsedMilliseconds.ToString() + "ms");

			//sw.Reset();
			//sw.Start();

			// TODO:
			// from save settings not found ?: 
			// 15: Group tiles
			// 17: dungeon auto doors
			// 18: adv chests
			// 19: misc dungeon properties
			// 20: load texts
			// 21: load Dung. items
			// 22: load Dung. sprites
			// 26: load Dung. blocks
			// 27: load Dung. torches
			// 29: load Over. sprites
			// 30: load Over. items

			try
			{
				if (saveSettingsArr[0]) ZScreamer.ActiveScreamer.SaveUnderworldSprites();
				if (saveSettingsArr[1]) ZScreamer.ActiveScreamer.SaveUnderworldSecrets();
				if (saveSettingsArr[2]) ZScreamer.ActiveScreamer.SaveUnderworldChests();
				if (saveSettingsArr[3]) ZScreamer.ActiveScreamer.saveAllObjects();
				if (saveSettingsArr[4]) ZScreamer.ActiveScreamer.saveBlocks();
				if (saveSettingsArr[5]) ZScreamer.ActiveScreamer.saveTorches();
				if (saveSettingsArr[6]) ZScreamer.ActiveScreamer.saveAllPits();
				if (saveSettingsArr[7]) ZScreamer.ActiveScreamer.saveRoomsHeaders();
				if (saveSettingsArr[8]) ZScreamer.ActiveScreamer.saveEntrances();
				if (saveSettingsArr[9]) ZScreamer.ActiveScreamer.SaveOverworldSprites();
				if (saveSettingsArr[10]) ZScreamer.ActiveScreamer.SaveOverworldSecrets();
				if (saveSettingsArr[11]) ZScreamer.ActiveScreamer.SaveOverworldEntrances();
				if (saveSettingsArr[12]) ZScreamer.ActiveScreamer.saveOWTransports();
				if (saveSettingsArr[13]) ZScreamer.ActiveScreamer.SaveOverworldExits();
				if (saveSettingsArr[14]) ZScreamer.ActiveOWScene.SaveTiles();
				// 15

				if (saveSettingsArr[16]) ZScreamer.ActiveScreamer.saveMapProperties();

				// 17
				// 18
				// 19
				// 20
				// 21
				// 22

				if (saveSettingsArr[23]) ZScreamer.ActiveGraphicsManager.SaveGroupsToROM();
				if (saveSettingsArr[24]) ZScreamer.ActivePaletteManager.SavePalettesToROM();
				if (saveSettingsArr[25]) TextEditor.Save();

				// 17

				if (saveSettingsArr[28]) ZScreamer.ActiveScreamer.saveCustomCollision();
				if (saveSettingsArr[31]) ZScreamer.ActiveScreamer.saveMapOverlays();
				if (saveSettingsArr[32]) ZScreamer.ActiveScreamer.saveOverworldMusics();
				if (saveSettingsArr[33]) ZScreamer.ActiveScreamer.SaveTitleScreen();
				if (saveSettingsArr[34]) ZScreamer.ActiveScreamer.SaveOverworldMiniMap();
				if (saveSettingsArr[35]) ZScreamer.ActiveScreamer.saveOverworldTilesType();
				if (saveSettingsArr[36]) ZScreamer.ActiveScreamer.SaveOverworldScreens();
				if (saveSettingsArr[37]) ZScreamer.ActiveScreamer.SaveGravestones();
				if (saveSettingsArr[38]) ZScreamer.ActiveScreamer.SaveDungeonMaps();
				if (saveSettingsArr[39]) ZScreamer.ActiveScreamer.SaveTriforce();
				if (saveSettingsArr[40]) ZScreamer.ActiveScreamer.SaveOverworldMessageIDs();

				ZScreamer.ActiveROM[0x5D4E] = 0x00;

				gfxEditor.SaveAllGfx();

				//sw.Stop();
				//Console.WriteLine("Saved Overworld- " + sw.ElapsedMilliseconds.ToString() + "ms");
				//Console.WriteLine("ROMDATA[" + (ZScreamer.ActiveOffsets.overworldMapPalette + 2).ToString("X6") + "]" + " : " + ROM.DATA[ZScreamer.ActiveOffsets.overworldMapPalette + 2]);
				//AsarCLR.Asar.init();
				//AsarCLR.Asar.patch("titlescreen.asm", ref ROM.DATA);
				//ZScreamer.ActiveOW.SaveMap16Tiles();

				OverworldEditor.saveScratchPad();

				anychange = false;

				//ROMStructure.saveProjectFile(version, projectFilename);
				//ZScreamer.ActiveROM.SaveLogs();

				FileStream fs = null;

				try
				{
					fs = new FileStream(projectFilename, FileMode.OpenOrCreate, FileAccess.Write);
					fs.Write(ZScreamer.ActiveROM.DataStream, 0, ZScreamer.ActiveROM.Length);
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					fs?.Close();
					fs?.Dispose();
				}
			}
			catch (ZeldaException z)
			{
				UIText.CryAboutSaving(z.Message);
			}
			catch (Exception) // TODO bad
			{
				UIText.CryAboutSaving("Something wrong with your file");
			}
			finally
			{
				ZScreamer.ActiveROM.OhShitLastResortBackup(romBackup);
			}
		}

		// TODO: move more of the failure stuff here


		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog projectFile = new OpenFileDialog()
			{
				Filter = UIText.USROMType,
				DefaultExt = UIText.ROMExtension,
			};

			if (projectFile.ShowDialog() == DialogResult.OK)
			{
				projectFilename = projectFile.FileName;
				LoadProject(projectFile.FileName);
				//openToolStripMenuItem.Enabled = false;
				//openfileButton.Enabled = false;
				//recentROMToolStripMenuItem.Enabled = false;
			}
		}



		// TODO magic numbers
		public void LoadProject(string filename)
		{
			// TODO : Add Headered ROM

			ZScreamer.ActiveScreamer.LoadNewROM(filename);

			if (loadFromExported != "")
			{
				loadFromExported = Path.GetDirectoryName(projectFilename);
			}

			OnProjectLoad();

			Text = $"{filename} - {UIText.APPNAME}";
		}

		public void OnProjectLoad()
		{
			projectLoaded = true;

			editorsTabControl.Enabled = true;

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

			gfxGroupsForm = new GfxGroupsForm();
			gfxGroupsForm.CreateTempGfx();
			gfxGroupsForm.Location = Constants.OriginPoint;

			paletteForm = new PaletteEditor
			{
				Location = Constants.OriginPoint
			};
			refreshRecentsFiles();

			DungeonEditor.OnProjectLoad();
			OverworldEditor.OnProjectLoad();
			TextEditor.OnProjectLoad();
			screenEditor.OnProjectLoad();
			paletteForm.OnProjectLoad();
			Refresh();
			//InitDungeonViewer();
		}

		private void InitDungeonViewer()
		{
			Bitmap b = new Bitmap(8192, 10752);

			using (Graphics gb = Graphics.FromImage(b))
			{
				for (int i = 0; i < Constants.NumberOfRooms; i++)
				{
					//ZScreamer.ActiveUWScene.Room = ZScreamer.ActiveScreamer.all_rooms[i];
					//
					//ZScreamer.ActiveUWScene.Refresh();
					//
					//gb.DrawImage(ZScreamer.ActiveUWScene.tempBitmap, new Point((i % 16) * 512, (i / 16) * 512));
					//activeScene.DrawToBitmap(b, new Rectangle(cx * 512, cy * 512, 512, 512));
				}
			}

			dungeonViewer.pictureBox1.Image = b;
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

		private readonly AboutBox1 aboutBox = new();
		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aboutBox.ShowDialog();
		}

		private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show
			(
				"Sorry this section does not exist yet. :)\n" +
				"However, you can find shortcuts not mentioned\n" +
				"- Mouse Wheel is used to resize objects for now\n" +
				"- Mouse Wheel Button is used to close rooms tabs"
			);
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				UWDelete(sender, e);
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				ZScreamer.ActiveOWScene.Delete();
			}
			else if (editorsTabControl.SelectedIndex == 3) // Text editor
			{
				TextEditor.delete();
			}
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				UWSelectAll(sender, e);
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				ZScreamer.ActiveOWScene.SelectAll();
			}
			else if (editorsTabControl.SelectedIndex == 3) // Text editor
			{
				TextEditor.selectAll();
			}
		}

		private void cutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				UWCut(sender, e);
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				ZScreamer.ActiveOWScene.Cut();
			}
			else if (editorsTabControl.SelectedIndex == 3) // Text editor
			{
				TextEditor.cut();
			}
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				UWPaste(sender, e);
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				ZScreamer.ActiveOWScene.Paste();
			}
			else if (editorsTabControl.SelectedIndex == 2) // gfx editor
			{
				gfxEditor.paste();
			}
			else if (editorsTabControl.SelectedIndex == 3) // Text editor
			{
				TextEditor.paste();
			}
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				UWCopy(sender, e);
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				ZScreamer.ActiveOWScene.Copy();
			}
			else if (editorsTabControl.SelectedIndex == 2) // gfx editor
			{
				gfxEditor.copy();
			}
			else if (editorsTabControl.SelectedIndex == 3) // Text editor
			{
				TextEditor.copy();
			}
		}

		public void undoButton_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				ZScreamer.ActiveUWScene.Undo();
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				ZScreamer.ActiveOWScene.Undo();
			}
		}

		public void redoButton_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				ZScreamer.ActiveUWScene.Redo();
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				ZScreamer.ActiveOWScene.Redo();
			}
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				ZScreamer.ActiveUWScene.Undo();
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				ZScreamer.ActiveOWScene.Undo();
			}
			else if (editorsTabControl.SelectedIndex == 3) // Text editor
			{
				TextEditor.undo();
			}
		}

		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0)
			{
				ZScreamer.ActiveUWScene.Redo();
			}
			else if (editorsTabControl.SelectedIndex == 1)
			{
				ZScreamer.ActiveOWScene.Redo();
			}
		}

		private void showBG1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				ZScreamer.ActiveUWScene.Refresh();
			}
		}

		private void saveLayoutButton_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(UIText.LayoutFolder))
			{
				Directory.CreateDirectory(UIText.LayoutFolder);
			}

			saveLayout();
		}

		public void saveLayout(bool clipboard = true)
		{
			throw new NotImplementedException();
			//List<SaveObject> data = new List<SaveObject>();
			//if (clipboard)
			//{
			//	data = (List<SaveObject>) Clipboard.GetData(Constants.ObjectZClipboardData);
			//}
			//else
			//{
			//	foreach (var o in ZScreamer.ActiveUWScene.room.selectedObject)
			//	{
			//		if (selectedLayer >= 0)
			//		{
			//			data.Add(new SaveObject((Room_Object) o));
			//		}
			//		else if (spritemodeButton.Checked)
			//		{
			//			data.Add(new SaveObject((Sprite) o));
			//		}
			//		else if (potmodeButton.Checked)
			//		{
			//			data.Add(new SaveObject((PotItem) o));
			//		}
			//	}
			//}
			//
			//if (data?.Count > 0)
			//{
			//	// Name that layout
			//	string name = "Room_Object";
			//	if (data[0].type == typeof(Room_Object))
			//	{
			//		name = "Room_Object";
			//	}
			//
			//	string f = Interaction.InputBox("Name of the new layout", "Name?", "Layout00");
			//	if (f != "")
			//	{
			//		BinaryWriter bw = new BinaryWriter(new FileStream(
			//			UIText.GetFileName(UIText.LayoutFolder, f),
			//			FileMode.OpenOrCreate,
			//			FileAccess.Write));
			//		bw.Write(name);
			//		foreach (SaveObject o in data)
			//		{
			//			o.saveToFile(bw);
			//		}
			//
			//		bw.Close();
			//	}
			//}
		}

		private void loadlayoutButton_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//scene.loadLayout();
			//if (!Directory.Exists(UIText.LayoutFolder))
			//{
			//	Directory.CreateDirectory(UIText.LayoutFolder);
			//}
			//
			//// this is bad
			//if ((byte) ZScreamer.ActiveScreamer.CurrentUWMode > 3)
			//{
			//	UpdateUnderworldMode(DungeonEditMode.Layer1);
			//	//scene.selectedMode = ObjectMode.Bg1mode;
			//}
			//
			//layoutForm.scene.Room = (Room) ZScreamer.ActiveUWScene.room.Clone();
			//ZScreamer.ActiveUWScene.room.selectedObject.Clear();
			//if (layoutForm.ShowDialog() == DialogResult.OK)
			//{
			//	int most_x = 512;
			//	int most_y = 512;
			//	foreach (Room_Object o in layoutForm.scene.room.tilesObjects)
			//	{
			//		if (layoutForm.scene.room.tilesObjects.Count > 0)
			//		{
			//			if (o.x < most_x)
			//			{
			//				most_x = o.x;
			//			}
			//			if (o.y < most_y)
			//			{
			//				most_y = o.y;
			//			}
			//		}
			//		else
			//		{
			//			most_x = 0;
			//			most_y = 0;
			//		}
			//	}
			//
			//	foreach (Room_Object o in layoutForm.scene.room.tilesObjects)
			//	{
			//		o.x = (byte) (o.x - most_x);
			//		o.y = (byte) (o.y - most_y);
			//		ZScreamer.ActiveUWScene.room.tilesObjects.Add(o);
			//		ZScreamer.ActiveUWScene.room.selectedObject.Add(o);
			//	}
			//
			//	ZScreamer.ActiveUWScene.dragx = 0;
			//	ZScreamer.ActiveUWScene.dragy = 0;
			//	ZScreamer.ActiveUWScene.mouse_down = true;
			//	ZScreamer.ActiveUWScene.NeedsRefreshing = true;
			//	if (!visibleEntranceGFX)
			//	{
			//		ZScreamer.ActiveUWScene.room.reloadGfx(DungeonsData.entrances[int.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
			//	}
			//	else
			//	{
			//		ZScreamer.ActiveUWScene.room.reloadGfx();
			//	}
			//}
		}

		private void zscreamForm_FormClosing_1(object sender, FormClosingEventArgs e)
		{
			if (projectLoaded)
			{
				//Properties.Settings.Default.ViewParameters;
				//Settings.Default.spriteText = textSpriteToolStripMenuItem.Checked;
				//Settings.Default.chestText = textChestItemToolStripMenuItem.Checked;
				//Settings.Default.itemText = textPotItemToolStripMenuItem.Checked;
				//Settings.Default.transparentBG = unselectedBGTransparentToolStripMenuItem.Checked;
				//Settings.Default.rightToolbox = rightSideToolboxToolStripMenuItem.Checked;
				//Settings.Default.spriteShow = hideSpritesToolStripMenuItem.Checked;
				//Settings.Default.itemsShow = hideItemsToolStripMenuItem.Checked;
				//Settings.Default.chestitemShow = hideChestItemsToolStripMenuItem.Checked;
				//Settings.Default.dooridShow = showDoorIDsToolStripMenuItem.Checked;
				//Settings.Default.chestidShow = showChestsIDsToolStripMenuItem.Checked;
				//Settings.Default.disableentranceGfx = disableEntranceGFXToolStripMenuItem.Checked;
				//Settings.Default.bg2maskShow = showBG2MaskOutlineToolStripMenuItem.Checked;
				//Settings.Default.entrancePos = entrancePositionToolStripMenuItem.Checked;
				Settings.Default.Save();
			}

			if (anychange || (ZScreamer.ActiveOWScene?.HasUnsavedChanges ?? false))
			{
				anychange = false;

				switch (UIText.WarnAboutSaving())
				{
					case DialogResult.Yes:
						foreach (var r in ZScreamer.ActiveScreamer.all_rooms)
						{
							r.FlushChanges();
						}
						saveToolStripMenuItem_Click(this, new EventArgs());
						break;

					case DialogResult.Cancel:
						e.Cancel = true;
						Activate();
						break;
				}
			}
		}

		private void showBG2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Refresh();
		}
		//private void exportProjectAsROMToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//	saveToolStripMenuItem_Click(sender, e);
		//	SaveFileDialog saveFile = new SaveFileDialog();
		//	saveFile.Filter = UIText.SNESROMType;
		//
		//	if (saveFile.ShowDialog() == DialogResult.OK)
		//	{
		//		FileStream fs = new FileStream(saveFile.FileName, FileMode.OpenOrCreate, FileAccess.Write);
		//		fs.Write(ZScreamer.ActiveROM.DATA, 0, ZScreamer.ActiveROM.DATA.Length);
		//		fs.Close();
		//	}
		//}

		private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Added refresh here so that the grid will appear when the checkbox is clicked.
			ZScreamer.ActiveUWScene.Refresh();
		}

		public void runtestButton_Click(object sender, EventArgs e)
		{
			/*
            if (File.Exists("temp.sfc"))
            {
                File.Delete("temp.sfc");
            }

            FileStream brom = new FileStream(baseROM, FileMode.Open, FileAccess.Read);
            brom.Read(ZScreamer.ActiveROM.DATA, 0, (int)brom.Length);
            brom.Close();

            saveToolStripMenuItem_Click(sender, e);
            
            FileStream fs = new FileStream("temp.sfc", FileMode.CreateNew, FileAccess.Write);

            fs.Write(ZScreamer.ActiveROM.DATA, 0, ROM.DATA.Length);
            fs.Close();
            Process p = Process.Start("temp.sfc");
            */
			saveToolStripMenuItem_Click(saveToolStripMenuItem, new EventArgs());
			Process.Start(projectFilename);
		}

		private void debugtestButton_Click(object sender, EventArgs e)
		{
			if (File.Exists(UIText.TestROM))
			{
				File.Delete(UIText.TestROM);
			}

			//Console.WriteLine(Path.GetDirectoryName(projectFilename));
			//return;
			ROMFile testrom = ZScreamer.ActiveROM.Clone();
			saveToolStripMenuItem_Click(sender, e);

			if (File.Exists(Path.GetDirectoryName(projectFilename) + "\\Main.asm"))
			{
				testrom.ApplyPatch(Path.GetDirectoryName(projectFilename) + "\\Main.asm");
			}

			foreach (AsarCLR.Asarerror error in AsarCLR.Asar.geterrors())
			{
				Console.WriteLine(error.Fullerrdata.ToString());
			}

			var selectedEntrance = ZGUI.DungeonEditor.selectedEntrance;

			testrom.Write16(ZScreamer.ActiveOffsets.startingentrance_room, selectedEntrance.RoomID);
			testrom.Write16(ZScreamer.ActiveOffsets.startingentrance_yposition, selectedEntrance.YPosition);
			testrom.Write16(ZScreamer.ActiveOffsets.startingentrance_xposition, selectedEntrance.XPosition);
			testrom.Write16(ZScreamer.ActiveOffsets.startingentrance_camerax, selectedEntrance.CameraX);
			testrom.Write16(ZScreamer.ActiveOffsets.startingentrance_cameray, selectedEntrance.CameraY);
			testrom.Write16(ZScreamer.ActiveOffsets.startingentrance_cameraxtrigger, selectedEntrance.CameraTriggerX);
			testrom.Write16(ZScreamer.ActiveOffsets.startingentrance_cameraytrigger, selectedEntrance.CameraTriggerY);
			testrom.Write16(ZScreamer.ActiveOffsets.startingentrance_exit, selectedEntrance.OverworldEntranceLocation);
			testrom[ZScreamer.ActiveOffsets.startingentrance_blockset] = selectedEntrance.Blockset;
			testrom[ZScreamer.ActiveOffsets.startingentrance_music] = (byte) selectedEntrance.Music.ID;
			testrom[ZScreamer.ActiveOffsets.startingentrance_dungeon] = selectedEntrance.Dungeon;
			testrom[ZScreamer.ActiveOffsets.startingentrance_floor] = selectedEntrance.Floor;
			testrom[ZScreamer.ActiveOffsets.startingentrance_ladderbg] = selectedEntrance.Ladderbg;
			testrom[ZScreamer.ActiveOffsets.startingentrance_scrolling] = selectedEntrance.Scrolling;
			testrom[ZScreamer.ActiveOffsets.startingentrance_scrollquadrant] = selectedEntrance.Scrollquadrant;

			testrom.Write(ZScreamer.ActiveOffsets.startingentrance_scrolledge,
				selectedEntrance.cameraBoundaryQN, selectedEntrance.cameraBoundaryFN,
				selectedEntrance.cameraBoundaryQS, selectedEntrance.cameraBoundaryFS,
				selectedEntrance.cameraBoundaryQW, selectedEntrance.cameraBoundaryFW,
				selectedEntrance.cameraBoundaryQE, selectedEntrance.cameraBoundaryFE);

			FileStream fs = new FileStream(UIText.TestROM, FileMode.CreateNew, FileAccess.Write);
			fs.Write(testrom.DataStream, 0, testrom.Length);
			fs.Close();
			Process.Start(UIText.TestROM);
		}

		// TODO going away with projects (or being changed drastically)
		private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sf = new SaveFileDialog
			{
				DefaultExt = ".sfc",
				Filter = "ZScream Project File .sfc|*.sfc",
			};

			if (sf.ShowDialog() == DialogResult.OK)
			{
				projectFilename = sf.FileName;
				saveToolStripMenuItem_Click(sender, e);
			}
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
			ZScreamer.ActiveUWScene.Refresh();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			ZGUI.DungeonEditor.ExportMaps();
		}

		// TODO move to constants
		private void patchNotesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/Zarby89/ZScreamDungeon/blob/master/ZeldaFullEditor/PatchNotes.txt");
		}

		private void advancedChestEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AdvancedChestEditorForm chestEditorForm = new AdvancedChestEditorForm();
			chestEditorForm.ShowDialog();
		}


		public void RefreshOnZoom()
		{
			//if (x2zoom)
			//{
			//	ZScreamer.ActiveUWScene.Size = Constants.Size1024x1024;
			//	//panel3.Location = new Point(1032, -1);
			//}
			//else
			//{
			//	ZScreamer.ActiveUWScene.Size = Constants.Size512x512;
			//	//panel3.Location = new Point(520, -1);
			//}

			ZScreamer.ActiveUWScene.Refresh();
		}

		private void hideSpritesToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
		{
			RefreshOnZoom();
		}

		private void dungeonsPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DungeonPropertiesForm propertiesEditorForm = new DungeonPropertiesForm();
			propertiesEditorForm.ShowDialog();
		}

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

		// TODO remove
		private void printRoomObjectsToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void removeMasksObjectsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (var list in ZScreamer.ActiveUWScene.Room.AllObjects)
			{
				foreach (RoomObject r in list)
				{
					if (r.ObjectType.Specialness == ObjectSpecialType.LayerMask)
					{
						list.Remove(r);
					}
				}
			}
		}

		private void gotoRoomToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			GotoRoom gotoRoom = new GotoRoom();
			if (gotoRoom.ShowDialog() == DialogResult.OK)
			{
				ZGUI.DungeonEditor.addRoomTab((ushort) gotoRoom.SelectedRoom);
			}
		}

		private void clearSelectedRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Room.ClearAll();
			ZScreamer.ActiveUWScene.Refresh();
		}

		private void clearAllRoomsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to clear every room's data?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				foreach (var r in ZScreamer.ActiveScreamer.all_rooms)
				{
					r.ClearAll();
				}

				ZScreamer.ActiveUWScene.Refresh();
			}
		}

		private void mouseEntranceButton_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveScreamer.CurrentUWMode = DungeonEditMode.Entrances;
		}

		private void exportAsASMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using SaveFileDialog sf = new SaveFileDialog();
			sf.Filter = UIText.ExportedRoomDataType;
			if (sf.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(sf.FileName, FileMode.OpenOrCreate, FileAccess.Write);
				byte[] roomdata = new RoomSaveEntry(ZScreamer.ActiveUWScene.Room).Data;
				fs.Write(roomdata, 0, roomdata.Length);
				fs.Close();
			}
		}

		private void vramViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			// do we need a new one every time?
			//vramViewer = new VramViewer();
			//WindowPanel wp = new WindowPanel
			//{
			//	Location = Constants.Point_512_0
			//};
			//wp.containerPanel.Controls.Add(vramViewer);
			//wp.Tag = "VRAM Viewer";
			//wp.Size = new Size(vramViewer.Size.Width + 2, vramViewer.Size.Height + 26);
			//customPanel3.Controls.Add(wp);
			//wp.BringToFront();
		}

		private void showBG2MaskOutlineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Refresh();
		}

		private void entranceCameraToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Refresh();
		}

		private void entrancePositionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Refresh();
		}

		// TODO delete when projects
		private void loadNamesFileToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		// TODO simplify and stuff, etc
		private void cGramViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//cgramViewer = new CGRamViewer();
			//WindowPanel wp = new WindowPanel
			//{
			//	Tag = "CGRAM Viewer - Right click to export palettes",
			//	Location = Constants.Point_512_0
			//};
			//wp.containerPanel.Controls.Add(cgramViewer);
			//wp.Size = new Size(cgramViewer.Size.Width + 2, cgramViewer.Size.Height + 26);
			//customPanel3.Controls.Add(wp);
			//wp.BringToFront();
		}

		private void gfxGroupsetsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//if (editorsTabControl.SelectedTab.Name == "dungeonPage")
			//{
			//	WindowPanel wp = new WindowPanel
			//	{
			//		Tag = "Gfx Groupset Editor",
			//		Location = Constants.Point_512_0
			//	};
			//	wp.containerPanel.Controls.Add(gfxGroupsForm);
			//	wp.Size = new Size(gfxGroupsForm.Size.Width + 2, gfxGroupsForm.Size.Height + 26);
			//	customPanel3.Controls.Add(wp);
			//	wp.BringToFront();
			//}
			//else if (editorsTabControl.SelectedTab.Name == "overworldPage")
			//{
			//	WindowPanel wp = new WindowPanel
			//	{
			//		Tag = "GFX Groups Editor",
			//		Location = Constants.Point_512_0
			//	};
			//	wp.containerPanel.Controls.Add(new GfxGroupsForm());
			//	wp.Size = new Size(gfxGroupsForm.Size.Width + 2, gfxGroupsForm.Size.Height + 26);
			//	ZGUI.OverworldEditor.splitContainer1.Panel2.Controls.Add(wp);
			//	wp.BringToFront();
			//}
		}

		private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Insert();
		}

		// This is called when the delete option in the chest item editor option is selected.
		// TODO garbage?
		private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
		{

		}

		private void palettesEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//if (editorsTabControl.SelectedTab.Name == "dungeonPage" || editorsTabControl.SelectedTab.Name == "overworldPage")
			//{
			//	WindowPanel wp = new WindowPanel
			//	{
			//		Tag = "Palettes Editor",
			//		Location = Constants.Point_512_0,
			//		Size = new Size(paletteForm.Size.Width + 2, paletteForm.Size.Height + 26)
			//	};
			//
			//	if (editorsTabControl.SelectedTab.Name == "dungeonPage")
			//	{
			//		wp.containerPanel.Controls.Add(paletteForm);
			//		customPanel3.Controls.Add(wp);
			//	}
			//	else
			//	{
			//		wp.containerPanel.Controls.Add(new PaletteEditor());
			//		ZGUI.OverworldEditor.splitContainer1.Panel2.Controls.Add(wp);
			//	}
			//
			//	paletteForm.BringToFront();
			//	wp.BringToFront();
			//
			//}
		}

		// Export Palette to YY-CHR Palette Format
		/*            

        */

		private void openRightRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ZScreamer.ActiveUWScene.Room != null)
			{
				int id = ZScreamer.ActiveUWScene.Room.RoomID + 1;
				if (id < Constants.NumberOfRooms)
				{
					DungeonEditor.addRoomTab((ushort) id);
				}
				else
				{
					DungeonEditor.addRoomTab(0);
				}
			}
		}

		private void openLeftRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ZScreamer.ActiveUWScene.Room != null)
			{
				int id = ZScreamer.ActiveUWScene.Room.RoomID - 1;
				if (id >= 0)
				{
					DungeonEditor.addRoomTab((ushort) id);
				}
				else
				{
					DungeonEditor.addRoomTab(295);
				}
			}
		}

		private void openUpRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ZScreamer.ActiveUWScene.Room != null)
			{
				int id = (ZScreamer.ActiveUWScene.Room.RoomID - 16);
				if (id >= 0)
				{
					DungeonEditor.addRoomTab((ushort) id);
				}
				else
				{
					if (304 + id > 295)
					{
						DungeonEditor.addRoomTab(295);
					}
					else
					{
						DungeonEditor.addRoomTab((ushort) (304 + id));
					}
				}
			}
		}

		private void openDownRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ZScreamer.ActiveUWScene.Room != null)
			{
				int id = ZScreamer.ActiveUWScene.Room.RoomID + 16;
				if (id < Constants.NumberOfRooms)
				{
					DungeonEditor.addRoomTab((ushort) id);
				}
				else
				{
					if (id > 304)
					{
						DungeonEditor.addRoomTab((ushort) (id - 304));
					}
					else
					{
						DungeonEditor.addRoomTab((ushort) (id - 288));
					}
				}
			}
		}

		private void DungeonMain_LocationChanged(object sender, EventArgs e)
		{
			Refresh();
		}

		private void editorsTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (var o in toolStrip1.Items)
			{
				if (o is DungeonToolStripButton ub)
				{
					ub.Visible = editorsTabControl.SelectedIndex == (int) TabSelection.DungeonEditor;
				}
				else if (o is OverworldToolStripButton ob)
				{
					ob.Visible = editorsTabControl.SelectedIndex == (int) TabSelection.OverworldEditor;
				}
			}
		}

		private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new SaveSettings().ShowDialog();
		}

		public void UpdateFormForSelectedObject(IHaveInfo o)
		{
			if (o is null)
			{
				SelectedObjectNameLabel.Visible = true;
				SelectedObjectNameLabel.Text = "No selection";
			}
			else
			{
				SelectedObjectNameLabel.Visible = true;
				SelectedObjectNameLabel.Text = o.Name;
			}


			if (o is IFreelyPlaceable f)
			{
				SelectedObjectXLabel.Visible = true;
				SelectedObjectYLabel.Visible = true;

				SelectedObjectXLabel.Text = $"X: {f.GridX:X2}";
				SelectedObjectYLabel.Text = $"X: {f.GridY:X2}";
			}
			else
			{
				SelectedObjectXLabel.Visible = false;
				SelectedObjectYLabel.Visible = false;
			}

			if (o is IMultilayered l)
			{
				SelectedObjectLayerLabel.Visible = true;
				SelectedObjectLayerLabel.Text = $"Layer: {l.Layer.ToLayerString()}";
			}
			else
			{
				SelectedObjectLayerLabel.Visible = false;
			}

			if (o is RoomObject r && r.Resizable)
			{
				SelectedObjectSizeLabel.Visible = true;
				SelectedObjectSizeLabel.Text = $"Size: {r.Size}";
			}
			else
			{
				SelectedObjectSizeLabel.Visible = false;
			}

			if (o is IByteable b)
			{
				SelectedObjectDataLabel.Visible = true;
				SelectedObjectDataLabel.Text = $"Data: {b.GetByteData().ToSimpleListing()}";
			}
			else
			{
				SelectedObjectDataLabel.Visible = false;
			}
		}


		private void searchButton_Click(object sender, EventArgs e)
		{
			new SearchForm().ShowDialog();
		}

		private void exportAllRoomsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//int[] doorsoffset = new int[Constants.NumberOfRooms];
			//StringBuilder sb = new StringBuilder();
			//sb.Append("lorom\r\n");
			SaveFileDialog sf = new SaveFileDialog
			{
				Filter = UIText.ExportedRoomDataType
			};

			if (sf.ShowDialog() == DialogResult.OK)
			{
				string path = Path.GetDirectoryName(sf.FileName);
				Directory.CreateDirectory(path + "//ExportedRooms");
				for (int i = 0; i < Constants.NumberOfRooms; i++)
				{
					// TODO system specific path separators
					byte[] roomBytes = new RoomSaveEntry(ZScreamer.ActiveScreamer.all_rooms[i]).Data;
					using FileStream fs = new FileStream(path + "//ExportedRooms//room" + i.ToString("D3") + ".zrd", FileMode.OpenOrCreate, FileAccess.Write);
					fs.Write(roomBytes, 0, roomBytes.Length);
					fs.Close();
				}

				/*
                int doorPos = roomBytes.Length - 2;
                if (roomBytes.Length < 10)
                {
                    continue;
                }

                sb.Append("org $1F8000+$" + (i * 3).ToString("X2") + "\r\n");
                sb.Append("dl room" + (i.ToString("D3")) + "\r\n\r\n");
                while (true)
                {
                    if (doorPos >= 04)
                    {
                        if (roomBytes[doorPos] == 0xF0 && roomBytes[doorPos + 1] == 0xFF)
                        {
                            doorPos += 2;
                            break;
                        }
                        doorPos -= 2;
                    }
                    else
                    {
                        break;
                    }
                }

                doorsoffset[i] = doorPos;
                sb.Append("org $1F83C0+$" + (i * 3).ToString("X2") + "\r\n");
                sb.Append("dl !door" + (i.ToString("D3")) + "\r\n\r\n");
                */

				/*
                if (File.Exists("Rooms/room" + i.ToString("D3")))
                {
                    FileStream fs = File.Open("Rooms/room" + i.ToString("D3"), FileMode.Open, FileAccess.Read);
                    Console.WriteLine("" + i.ToString("D3") + " O:" + roomBytes.Length.ToString("X4") + " D:" + fs.Length.ToString("X4"));
                }*/
			}

			/*
            sb.Append("org $218000 \r\n");
            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                byte[] roomBytes = DungeonsData.all_rooms[i].getTilesBytes();
                if (roomBytes.Length < 10)
                {
                    continue;
                }

                sb.Append("room" + (i.ToString("D3")) + ":\r\n");
                sb.Append("incbin \"Rooms/room" + (i.ToString("D3")) + "\"\r\n");

                sb.Append("!door" + (i.ToString("D3")) + " = room" + (i.ToString("D3"))+"+$"+doorsoffset[i].ToString("X4")+"\r\n\r\n");
            }

            File.WriteAllText("rooms.asm", sb.ToString());
            */
		}

		private void runToolStripMenuItem_Click(object sender, EventArgs e)
		{
			runtestButton_Click(sender, e);
		}

		private void mapDataFromJPdoNotUseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/*
			Constants.Init_Jp();
			OpenFileDialog projectFile = new OpenFileDialog();
			projectFile.Filter = UIText.JPROMType;
			projectFile.DefaultExt = UIText.ROMExtension;

			if (projectFile.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(projectFile.FileName, FileMode.Open, FileAccess.Read);
				ROM.TEMPDATA = new byte[ROM.DATA.Length];
				ROM.DATA.CopyTo(ZScreamer.ActiveROM.TEMPDATA, 0);
				byte[] data = new byte[ROM.DATA.Length];
				ROM.DATA = new byte[ROM.DATA.Length];
				fs.Read(data, 0, (int) fs.Length);
				data.CopyTo(ZScreamer.ActiveROM.DATA, 0x00);
				oweditor2 = new OverworldEditor();
				oweditor2.InitOpen(this);
				overworldEditor.Visible = false;
				oweditor2.Dock = DockStyle.Fill;
				Controls.Remove(overworldEditor);
				Controls.Add(oweditor2);
				oweditor2.BringToFront();
				oweditor2.Visible = true;
				overworldEditor.splitContainer1.Panel2.AutoScroll = true;
				//ROM.TEMPDATA.CopyTo(ZScreamer.ActiveROM.DATA, 0x00);

				fs.Close();
			}
			*/
		}
		private void exportMapJPdoNotUseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/*
			int selectedMap = oweditor2.scene.selectedMap;
			if (selectedMap >= 64)
			{
				selectedMap -= 64;
			}

			Console.WriteLine("Exporting map : " + ZScreamer.ActiveOWScene.selectedMap);
			int sx = (selectedMap % 8);
			int sy = (selectedMap / 8);
			string s = "Map" + selectedMap.ToString("D2") + ":\r\n";
			int length = 32;

			for (int i = 0; i < (length * length); i++)
			{
				if (oweditor2.scene.selectedMap >= 64)
				{
					int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2);
					if (oweditor2.scene.ow.allmapsTilesDW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
						dwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
					{
						s += "LDA #$" + oweditor2.scene.ow.allmapsTilesDW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
						s += "STA $" + addr.ToString("X4") + "\r\n";
					}
				}
				else
				{
					int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2);
					if (oweditor2.scene.ow.allmapsTilesLW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
						lwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
					{
						s += "LDA #$" + oweditor2.scene.ow.allmapsTilesLW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
						s += "STA $" + addr.ToString("X4") + "\r\n";
					}
				}
			}

			if (oweditor2.scene.ow.allmaps[oweditor2.scene.selectedMap].largeMap)
			{
				Console.Write("Is large map");
				selectedMap = oweditor2.scene.selectedMap + 1;
				sx = (selectedMap % 8);
				sy = (selectedMap / 8);

				for (int i = 0; i < (length * length); i++)
				{
					if (oweditor2.scene.selectedMap >= 64)
					{
						int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2) + 0x40;
						if (oweditor2.scene.ow.allmapsTilesDW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
							dwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
						{
							s += "LDA #$" + oweditor2.scene.ow.allmapsTilesDW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
							s += "STA $" + addr.ToString("X4") + "\r\n";
						}
					}
					else
					{
						int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2);
						if (oweditor2.scene.ow.allmapsTilesLW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
							lwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
						{
							s += "LDA #$" + oweditor2.scene.ow.allmapsTilesLW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
							s += "STA $" + addr.ToString("X4") + "\r\n";
						}
					}
				}

				selectedMap = oweditor2.scene.selectedMap + 16;
				sx = (selectedMap % 8);
				sy = (selectedMap / 8);

				for (int i = 0; i < (length * length); i++)
				{
					if (oweditor2.scene.selectedMap >= 64)
					{
						int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2) + 0x1000;
						if (oweditor2.scene.ow.allmapsTilesDW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
							dwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
						{
							s += "LDA #$" + oweditor2.scene.ow.allmapsTilesDW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
							s += "STA $" + addr.ToString("X4") + "\r\n";
						}
					}
					else
					{
						int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2);
						if (oweditor2.scene.ow.allmapsTilesLW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
							lwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
						{
							s += "LDA #$" + oweditor2.scene.ow.allmapsTilesLW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
							s += "STA $" + addr.ToString("X4") + "\r\n";
						}
					}
				}

				selectedMap = oweditor2.scene.selectedMap + 17;
				sx = (selectedMap % 8);
				sy = (selectedMap / 8);

				for (int i = 0; i < (length * length); i++)
				{
					if (oweditor2.scene.selectedMap >= 64)
					{
						int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2) + 0x1040;
						if (oweditor2.scene.ow.allmapsTilesDW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
							dwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
						{
							s += "LDA #$" + oweditor2.scene.ow.allmapsTilesDW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
							s += "STA $" + addr.ToString("X4") + "\r\n";
						}
					}
					else
					{
						int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2);
						if (oweditor2.scene.ow.allmapsTilesLW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
							lwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
						{
							s += "LDA #$" + oweditor2.scene.ow.allmapsTilesLW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
							s += "STA $" + addr.ToString("X4") + "\r\n";
						}
					}
				}
			}

			s += "RTS";

			using (SaveFileDialog sf = new SaveFileDialog())
			{
				sf.DefaultExt = ".asm";
				if (sf.ShowDialog() == DialogResult.OK)
				{
					File.WriteAllText(sf.FileName, s);
				}
			}
			*/
		}
		private void captureMapJPdoNotUseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/*
			lwmdata = new ushort[512, 512];
			dwmdata = new ushort[512, 512];
			for (int x = 0; x < 512; x++)
			{
				for (int y = 0; y < 512; y++)
				{
					lwmdata[x, y] = oweditor2.scene.ow.allmapsTilesLW[x, y];
					dwmdata[x, y] = oweditor2.scene.ow.allmapsTilesDW[x, y];
				}
			}
			*/
		}

		private void exportSpritesAsBinaryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			byte[] sprdata = ZScreamer.ActiveScreamer.all_rooms[ZScreamer.ActiveUWScene.Room.RoomID].SpritesList.GetByteData();
			byte[] sprites_buffer = new byte[sprdata.Length + 2];

			sprites_buffer[0] = 0x00;
			sprites_buffer[sprdata.Length + 1] = Constants.SpriteSentinel;

			sprdata.CopyTo(sprites_buffer, 1);

			using SaveFileDialog ofd = new SaveFileDialog();
			ofd.Filter = UIText.ExportedSpriteDataType;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
				fs.Write(sprites_buffer, 0, sprites_buffer.Length);
				fs.Close();
			}
		}

		private void exportAllMapsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int sx = 0;
			int sy = 0;
			int p = 0;

			byte[] mapArrayData = new byte[0x50000];
			using SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = UIText.ExportedOWMapDataType;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
				for (int i = 0; i < 64; i++)
				{
					for (int y = 0; y < 32; y++)
					{
						for (int x = 0; x < 32; x ++)
						{
							mapArrayData[p++] = (byte) ZScreamer.ActiveOW.allmapsTilesLW[x + sx, y + sy];
							mapArrayData[p++] = (byte) (ZScreamer.ActiveOW.allmapsTilesLW[x + sx, y + sy] >> 8);
							mapArrayData[p++] = (byte) ZScreamer.ActiveOW.allmapsTilesDW[x + sx, y + sy];
							mapArrayData[p++] = (byte) (ZScreamer.ActiveOW.allmapsTilesDW[x + sx, y + sy] >> 8);

							if (i < 32)
							{
								mapArrayData[p++] = (byte) ZScreamer.ActiveOW.allmapsTilesSP[x + sx, y + sy];
								mapArrayData[p++] = (byte) (ZScreamer.ActiveOW.allmapsTilesSP[x + sx, y + sy] >> 8);
							}
						}
					}

					sx += 32;
					if (sx >= (8 * 32))
					{
						sy += 32;
						sx = 0;
					}
				}

				fileStreamMap.Write(mapArrayData, 0, mapArrayData.Length);
				fileStreamMap.Close();
			}
		}

		private void importAllMapsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int sx = 0;
			int sy = 0;
			int p = 0;

			byte[] mapArrayData = new byte[0x50000];
			using OpenFileDialog sfd = new OpenFileDialog();
			sfd.Filter = UIText.ExportedOWMapDataType;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.Open, FileAccess.Read);
				fileStreamMap.Read(mapArrayData, 0, mapArrayData.Length);

				for (int i = 0; i < 64; i++)
				{
					for (int y = 0; y < 32; y += 1)
					{
						for (int x = 0; x < 32; x += 1)
						{
							ZScreamer.ActiveOW.allmapsTilesLW[x + sx, y + sy] = (ushort) ((mapArrayData[p + 1] << 8) | mapArrayData[p]);
							p += 2;

							ZScreamer.ActiveOW.allmapsTilesDW[x + sx, y + sy] = (ushort) ((mapArrayData[p + 1] << 8) | mapArrayData[p]);
							p += 2;

							if (i < 32)
							{
								ZScreamer.ActiveOW.allmapsTilesSP[x + sx, y + sy] = (ushort) ((mapArrayData[p + 1] << 8) | mapArrayData[p]);
								p += 2;
							}
						}
					}

					sx += 32;
					if (sx >= (8 * 32))
					{
						sy += 32;
						sx = 0;
					}
				}

				fileStreamMap.Close();
			}
		}

		private void exportAllTilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int p = 0;
			byte[] mapArrayData = new byte[0x8000]; // Real amount: 0x7540
			using SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = UIText.ExportedTileDataType;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);

				for (int i = 0; i < 3752; i++) // 3600
				{
					ulong v = ZScreamer.ActiveOW.Tile16Sheet.GetTile16At(i).getLongValue();

					for (int j = 0; j < 8; j++)
					{
						mapArrayData[p++] = (byte) v;
						v >>= 8;
					}
				}

				fileStreamMap.Write(mapArrayData, 0, mapArrayData.Length);
				fileStreamMap.Close();
			}
		}

		private void importAllTilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int p = 0;
			byte[] mapArrayData = new byte[0x8000]; // Real amount: 0x7540
			using OpenFileDialog sfd = new OpenFileDialog();
			sfd.Filter = UIText.ExportedTileDataType;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.Open, FileAccess.Read);
				fileStreamMap.Read(mapArrayData, 0, mapArrayData.Length);

				for (int i = 0; i < Constants.NumberOfUniqueTile16Definitions; i++)
				{

					// Tile 0
					ushort t0 = (ushort) (
						(mapArrayData[p + 1] << 8) |
						(mapArrayData[p + 0])
					);

					// Tile 1
					ushort t1 = (ushort)
					(
						(mapArrayData[p + 3] << 8) |
						(mapArrayData[p + 2])
					);

					// Tile 2
					ushort t2 = (ushort)
					(
						(mapArrayData[p + 5] << 8) |
						(mapArrayData[p + 4])
					);

					// Tile 3
					ushort t3 = (ushort)
					(
						(mapArrayData[p + 7] << 8) |
						(mapArrayData[p + 6])
					);

					ZScreamer.ActiveOW.Tile16Sheet.SetTile16At(i, new Tile16(t0, t1, t2, t3));

					p += 8;
				}

				fileStreamMap.Close();
			}
		}

		private void flipMapHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<ushort> tile8ids = new List<ushort>();
			ushort[,] map16 = new ushort[32, 32];

			// Flip all tile8 tiles
			for (int x = 0; x < 32; x++)
			{
				for (int y = 0; y < 32; y++)
				{
					if (!tile8ids.Contains(ZScreamer.ActiveOW.allmaps[44].tilesUsed[x + (4 * 32), y + (5 * 32)]))
					{
						tile8ids.Add(ZScreamer.ActiveOW.allmaps[44].tilesUsed[x + (4 * 32), y + (5 * 32)]);
					}
					map16[x, y] = ZScreamer.ActiveOW.allmaps[44].tilesUsed[x + (4 * 32), y + (5 * 32)];
				}
			}

			for (int i = 0; i < tile8ids.Count; i++)
			{

				//ZScreamer.ActiveOW.Tile16List[tile8ids[i]].tile0.HFlip ^= true;
				//ZScreamer.ActiveOW.Tile16List[tile8ids[i]].tile1.HFlip ^= true;
				//ZScreamer.ActiveOW.Tile16List[tile8ids[i]].tile2.HFlip ^= true;
				//ZScreamer.ActiveOW.Tile16List[tile8ids[i]].tile3.HFlip ^= true;
				//
				//ushort t0 = ZScreamer.ActiveOW.Tile16List[i].tile0.ID;
				//ushort t2 = ZScreamer.ActiveOW.Tile16List[i].tile2.ID;
				//
				//ZScreamer.ActiveOW.Tile16List[i].tile0.ID = ZScreamer.ActiveOW.Tile16List[i].tile1.ID;
				//ZScreamer.ActiveOW.Tile16List[i].tile1.ID = t0;
				//ZScreamer.ActiveOW.Tile16List[i].tile2.ID = ZScreamer.ActiveOW.Tile16List[i].tile3.ID;
				//ZScreamer.ActiveOW.Tile16List[i].tile3.ID = t2;

				for (int x = 0, mx = 31; x < 32; x++, mx--)
				{
					for (int y = 0; y < 32; y++)
					{
						ZScreamer.ActiveOW.allmaps[44].tilesUsed[x + (4 * 32), y + (5 * 32)] = map16[mx, y];
					}
				}
			}

			// ZScreamer.ActiveOW.allmaps[44].BuildMap();
		}

		// TODO magic string
		private void exportRoomDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//ZScreamer.ActiveUWScene.room.CloneToFile("TestRoomData.dat");
		}

		private void importRoomDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//using (var ms = new FileStream("TestRoomData.dat", FileMode.Open, FileAccess.Read))
			//{
			//	var formatter = new BinaryFormatter();
			//	DungeonRoom r = (DungeonRoom) formatter.Deserialize(ms);
			//	ZScreamer.ActiveUWScene.Room = r;
			//	DungeonRoom rtc = r;
			//
			//	foreach (DungeonRoom ro in opened_rooms)
			//	{
			//		if (ro.RoomID == ZScreamer.ActiveUWScene.Room.RoomID)
			//		{
			//			rtc = ro;
			//		}
			//	}
			//
			//	// TODO should this be rtc?
			//	DungeonsData.all_rooms[ZScreamer.ActiveUWScene.Room.RoomID] = r;
			//	ZScreamer.ActiveUWScene.NeedsRefreshing = true;
			//	ZScreamer.ActiveUWScene.Refresh();
			//}
		}

		// TODO system specific path separators, etc
		private void importRoomsFromFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// TODO change logic
			//if (UIText.WarnAboutSaving(UIText.RoomWarning) == DialogResult.Yes)
			//{
			//	OpenFileDialog ofd = new OpenFileDialog();
			//
			//	if (ofd.ShowDialog() == DialogResult.OK)
			//	{
			//		string path = Path.GetDirectoryName(ofd.FileName);
			//
			//		for (int i = 0; i < Constants.NumberOfRooms; i++)
			//		{
			//			if (File.Exists(path + "// room" + i.ToString("D3") + ".bin"))
			//			{
			//				using (FileStream fs = new FileStream(path + "// room" + i.ToString("D3") + ".bin", FileMode.Open, FileAccess.Read))
			//				{
			//					DungeonsData.all_rooms[i].tilesObjects.Clear(); //Empty the room first
			//					byte[] data = new byte[fs.Length];
			//					fs.Read(data, 0, data.Length);
			//					DungeonsData.all_rooms[i].loadTilesObjectsFromArray(data, true);
			//					fs.Close();
			//				}
			//			}
			//		}
			//	}
			//}
		}

		//Jared_Brian_: changed so that nothing will write to the ROM if the SaveTiles() function fails.
		/// <summary>
		/// Runs when the save only maps button is clicked.
		/// </summary>
		private void saveMapsOnlyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				ZScreamer.ActiveOWScene.SaveTiles();
				ZScreamer.ActiveScreamer.SaveOverworldScreens();

				FileStream fs = new FileStream(projectFilename, FileMode.OpenOrCreate, FileAccess.Write);
				fs.Write(ZScreamer.ActiveROM.DataStream, 0, ZScreamer.ActiveROM.Length);
				fs.Close();
			}
			catch (ZeldaException a)
			{
				UIText.CryAboutSaving(a.Message);
			}
		}

		private void importRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog
			{
				Filter = UIText.ExportedRoomDataType
			};

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
				byte[] data = new byte[(int) fs.Length];
				fs.Read(data, 0, data.Length);
				fs.Close();

				ZScreamer.ActiveUWScene.Refresh();
			}
		}

		private void showRoomsInHexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//string dotFormat = showRoomsInHexToolStripMenuItem.Checked ? "X3" : "D3";
			//foreach (TabPage tp in tabControl2.TabPages)
			//{
			//	tp.Text = (tp.Tag as DungeonRoom).RoomID.ToString(dotFormat);
			//}
		}

		private void saveVRAMAsPngToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveGraphicsManager.currentgfx16Bitmap.Save("vram.png");
		}

		private void edit8x8palettebox_Paint(object sender, PaintEventArgs e)
		{
			ColorPalette cp = RoomEditingArtist.Layer1Canvas.Palette;
			for (int i = 0; i < 128; i++)
			{
				e.Graphics.FillRectangle(new SolidBrush(cp.Entries[i]), new Rectangle((i % 16) * 16, i & ~0xF, 16, 16));
			}
		}

		private void moveRoomsToOtherROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UIText.WarnAboutSaving(UIText.CloseROMWarning);
			//RoomMover rm = new RoomMover();
			//if (rm.ShowDialog() == DialogResult.OK)
			//{
			//	List<short> listofrooms = new List<short>();
			//	for (int i = 0; i < Constants.NumberOfRooms; i++)
			//	{
			//		if (rm.checkedListBox1.GetItemChecked(i))
			//		{
			//			listofrooms.Add((short) i);
			//		}
			//	}
			//
			//	FileStream fs = new FileStream(rm.textBox1.Text, FileMode.Open, FileAccess.Read);
			//	int size = (int) fs.Length;
			//
			//	if (fs.Length < Constants.ROMSize)
			//	{
			//		size = Constants.ROMSize;
			//	}
			//
			//	ZScreamer.ActiveROM.DATA2 = new byte[size];
			//	if ((fs.Length & Constants.ROMHeaderSize) == Constants.ROMHeaderSize)
			//	{
			//		size = (int) (fs.Length - Constants.ROMHeaderSize);
			//		byte[] tempRomData = new byte[fs.Length];
			//		fs.Read(tempRomData, 0, (int) fs.Length);
			//		Array.Copy(tempRomData, Constants.ROMHeaderSize, ZScreamer.ActiveROM.DATA2, 0, size);
			//	}
			//	else
			//	{
			//		fs.Read(ZScreamer.ActiveROM.DATA2, 0, (int) fs.Length);
			//	}
			//
			//	fs.Close();
			//
			//	ZScreamer.ActiveROM.TEMPDATA = new byte[Constants.ROMSize];
			//	for (int i = 0; i < Constants.ROMSize; i++)
			//	{
			//		ZScreamer.ActiveROM.TEMPDATA[i] = ZScreamer.ActiveROM.DATA[i];
			//		ZScreamer.ActiveROM.DATA[i] = ZScreamer.ActiveROM.DATA2[i];
			//	}
			//
			//	for (int i = 0; i < Constants.NumberOfRooms; i++)
			//	{
			//		DungeonsData.all_rooms_moved[i] = new Room(ZS, i);
			//	}
			//
			//	ZScreamer.ActiveROM.TEMPDATA = new byte[Constants.ROMSize];
			//	for (int i = 0; i < Constants.ROMSize; i++)
			//	{
			//		ZScreamer.ActiveROM.DATA2[i] = ZScreamer.ActiveROM.DATA[i];
			//		ZScreamer.ActiveROM.DATA[i] = ZScreamer.ActiveROM.TEMPDATA[i]; // Restore to original rom
			//	}
			//
			//	Save save = new Save(ZS, DungeonsData.all_rooms);
			//
			//	//if (rm.checkBox7.Checked)
			//	//{
			//
			//	if (ZScreamer.ActiveScreamer.saveRoomsHeaders2()) // No protection always the same size so we don't care :)
			//	{
			//		//MessageBox.Show("Failed to save, there is too many chest items", "Bad Error", MessageBoxButtons.OK);
			//	}
			//	//}
			//
			//	if (rm.checkBox6.Checked)
			//	{
			//		if (ZScreamer.ActiveScreamer.saveallChests2()) // Chest there's a protection when there's too many chest - tested it works fine
			//		{
			//			UIText.CryAboutSaving("there are too many chest items");
			//			return;
			//		}
			//	}
			//
			//	if (rm.checkBox5.Checked)
			//	{
			//		if (ZScreamer.ActiveScreamer.saveallSprites2(listofrooms.ToArray())) // Sprites, there's a protection
			//		{
			//			UIText.CryAboutSaving("there are too many sprites");
			//			return;
			//		}
			//	}
			//
			//	if (rm.checkBox1.Checked)
			//	{
			//		if (ZScreamer.ActiveScreamer.saveAllObjects2(listofrooms.ToArray())) // There is a protection - Tested
			//		{
			//			UIText.CryAboutSaving("there are too many tiles objects");
			//			return;
			//		}
			//	}
			//
			//	if (rm.checkBox2.Checked)
			//	{
			//		if (ZScreamer.ActiveScreamer.saveallPots2(listofrooms.ToArray())) // There is a protection - Tested
			//		{
			//			UIText.CryAboutSaving("there are too many pot items");
			//			return;
			//		}
			//	}
			//
			//	/*
			//    if (rm.checkBox3.Checked)
			//    {
			//        if (ZScreamer.ActiveScreamer.saveBlocks2())//There is a protection - Tested
			//        {
			//            UIText.CryAboutSaving("there are too many pushable blocks");
			//            return;
			//        }
			//    }
			//    if (rm.checkBox4.Checked)
			//    {
			//        if (ZScreamer.ActiveScreamer.saveTorches2())//There is a protection Tested
			//        {
			//            UIText.CryAboutSaving("there are too many torches");
			//            return;
			//        }
			//    }
			//    */
			//
			//	fs = new FileStream(rm.textBox1.Text, FileMode.Open, FileAccess.Write);
			//	fs.Write(ZScreamer.ActiveROM.DATA2, 0, Constants.ROMSize);
			//
			//	fs.Close();
			//
			//	MessageBox.Show("Selected data successfully moved to selected ROM.\n" +
			//		"Please restart the application.");
			//}
		}

		private void showSpritesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			OverworldEditor.Refresh();
		}

		private void increaseObjectSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.IncreaseSizeOfSelectedObject();
		}

		private void decreaseObjectSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.DecreaseSizeOfSelectedObject();
		}

		private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChangeTheme(Controls);
		}

		// TODO Magic colors
		// make a ThemeZScreamer.ActiveOffsets.cs file?
		public void ChangeTheme(Control.ControlCollection container)
		{
			foreach (Control component in container)
			{
				if (component.Controls.Count != 0)
				{
					ChangeTheme(component.Controls);
					component.BackColor = Color.FromArgb(37, 37, 38);
					component.ForeColor = Color.FromArgb(220, 220, 220);
				}
				else if (component is Button)
				{
					component.BackColor = Color.FromArgb(30, 30, 30);
					component.ForeColor = Color.FromArgb(220, 220, 220);
				}
				else if (component is TextBox)
				{
					component.BackColor = Color.FromArgb(51, 51, 51);
					component.ForeColor = Color.FromArgb(220, 220, 220);
				}
				else
				{
					component.BackColor = Color.FromArgb(51, 51, 51);
					component.ForeColor = Color.FromArgb(220, 220, 220);
				}
			}
		}

		private void x8ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			x8ToolStripMenuItem1.Checked = false;
			x16ToolStripMenuItem1.Checked = false;
			x32ToolStripMenuItem1.Checked = false;
			noneToolStripMenuItem.Checked = false;

			if (sender == x8ToolStripMenuItem1)
			{
				x8ToolStripMenuItem1.Checked = true;
				OverworldEditor.gridDisplay = 8;
			}
			else if (sender == x16ToolStripMenuItem1)
			{
				x16ToolStripMenuItem1.Checked = true;
				OverworldEditor.gridDisplay = 16;
			}
			else if (sender == x32ToolStripMenuItem1)
			{
				x32ToolStripMenuItem1.Checked = true;
				OverworldEditor.gridDisplay = 32;
			}
			else
			{
				noneToolStripMenuItem.Checked = true;
				OverworldEditor.gridDisplay = 0;
			}

			ZScreamer.ActiveOWScene.Refresh();
		}

		private void autodoorButton_Click_1(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Room.AutoSortDoors();

			ZScreamer.ActiveUWScene.Refresh();
		}

		// TODO magic points and merge identical functions
		private void DungeonMain_SizeChanged(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//if (x2zoom)
			//{
			//	panel3.Location = new Point(1032, -1);
			//}
			//else
			//{
			//	panel3.Location = new Point(520, -1);
			//}
		}

		private void memoryManagementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Need to find one empty byte in the ROM to write the bank pointer!
			// Bank XX is used for all the expanded pointers!
			// XX8000-XX8500 : RESERVED FOR EDITOR USE DATA/POINTERS
			// XX8501-XX88C1 : Rooms Header Pointers (0x3C0 length)
			// XX88C1-XX8A41 :  Overworld Overlay Pointers
			// XX8A41-XX8E01 :  Collision Map Dungeon Pointers

			ExpandedManagement em = new ExpandedManagement();
			em.ShowDialog();
		}

		/// <summary>
		/// is triggered when the clear all custom collision button is pressed
		/// </summary>
		private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.clearCustomCollisionMap();
		}

		/// <summary>
		/// is triggered when the clear all overworld sprites phase 1 button is pressed
		/// </summary>
		private void clearPhase1OWSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld sprites for phase 1 (Rescue Zelda)"))
			{
				OverworldEditor.clearOverworldSprites(GameState.RainState);
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld sprites phase 2 button is pressed
		/// </summary>
		private void clearPhase2OWSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld sprites for phase 2 (Zelda rescued)"))
			{
				OverworldEditor.clearOverworldSprites(GameState.RescueState);
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld sprites phase 3 button is pressed
		/// </summary>
		private void clearPhase3OWSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld sprites for phase 3 (Agahnim defeated)"))
			{
				OverworldEditor.clearOverworldSprites(GameState.AgaState);
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld items button is pressed
		/// </summary>
		public void clearAllOWItemsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld items"))
			{
				OverworldEditor.clearOverworldItems();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld entrances button is pressed
		/// </summary>
		public void clearAllOWEntrancesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld entrances"))
			{
				OverworldEditor.clearOverworldEntrances();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld holes button is pressed
		/// </summary>
		public void clearAllOWHolesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("hole entrances"))
			{
				OverworldEditor.clearOverworldHoles();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld exits button is pressed
		/// </summary>
		public void clearAllOWExitsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld exits"))
			{
				OverworldEditor.clearOverworldExits();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld overlays button is pressed
		/// </summary>
		public void clearAllOverworldOverlaysToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld overlays"))
			{
				ZGUI.OverworldEditor.clearOverworldOverlays();
			}
		}

		private void selectAllRoomsForExportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DungeonEditor.SelectAllRooms();

			//loadRoomList(Constants.NumberOfRooms);
		}

		private void deselectedAllRoomsForExportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZGUI.DungeonEditor.DeselectAllRooms();

			//loadRoomList(Constants.NumberOfRooms);
		}

		/// <summary>
		/// is triggered when the clear all overworld sprites phase 1 button is pressed
		/// </summary>
		private void clearPhase1AreaSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("sprites for phase 1 (Rescue Zelda)"))
			{
				OverworldEditor.clearAreaSprites(GameState.RainState);
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld sprites phase 2 button is pressed
		/// </summary>
		private void clearPhase2AreaSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("sprites for phase 2 (Zelda rescued)"))
			{
				OverworldEditor.clearAreaSprites(GameState.RescueState);
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld sprites phase 3 button is pressed
		/// </summary>
		private void clearPhase3AreaSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("sprites for phase 3 (Agahnim defeated)"))
			{
				OverworldEditor.clearAreaSprites(GameState.AgaState);
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld items button is pressed
		/// </summary>
		public void clearAllAreaItemsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("secret items"))
			{
				OverworldEditor.clearAreaItems();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld entrances button is pressed
		/// </summary>
		public void clearAllAreaEntrancesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("entrances"))
			{
				OverworldEditor.clearAreaEntrances();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld holes button is pressed
		/// </summary>
		public void clearAllAreaHolesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("hole entrances"))
			{
				OverworldEditor.clearAreaHoles();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld exits button is pressed
		/// </summary>
		public void clearAllAreaExitsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("exits"))
			{
				OverworldEditor.clearAreaExits();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld overlays button is pressed
		/// </summary>
		public void clearAllAreaOverlaysToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("overlay tiles"))
			{
				OverworldEditor.clearAreaOverlays();
			}
		}

		/// <summary>
		/// Gives a message box saying "You wanna delete <paramref name="w"/>?"
		/// </summary>
		private bool ConfirmDeletion(string w)
		{
			return UIText.VerifyWarning($"You are about to delete all {w}");
		}

		/// <summary>
		/// Gives a message box saying "You wanna delete <paramref name="w"/> from OW screen X?"
		/// </summary>
		private bool ConfirmDeletionOWArea(string w)
		{
			return ConfirmDeletion($"{w} from OW screen {ZScreamer.ActiveOWScene.CurrentParentMapID:X2}");
		}

		private void discordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(UIText.DISCORD);
		}

		public (int x, int y) GetXYMouseBasedOnZoom(MouseEventArgs e)
		{
			if (x2zoom)
			{
				return (e.X / 2, e.Y / 2);
			}

			return (e.X, e.Y);
		}

		private void UWInsert(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Insert();
		}

		private void UWDelete(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Delete();
		}

		private void UWCopy(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Copy();
		}

		private void UWCut(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Cut();
		}

		private void UWPaste(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Paste();
		}

		private void UWSelectAll(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.SelectAll();
		}

		private void UWAddToSelection(object sender, EventArgs e)
		{

		}

		private void UWSelectNone(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Room.ClearSelectedList();
		}


		/// <summary>
		/// Sends an object to the front in the list when using one of the 3 "send to front" options
		/// </summary>
		private void SendSelectedToFront(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Room.SendAllSelectedToFront();
		}

		/// <summary>
		/// Sends an object to the back in the list when using one of the 3 "send to back" options
		/// </summary>
		public void SendSelectedToBack(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Room.SendAllSelectedToBack();
		}

		public void UWSendSelectedToLayer1(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Room.SendAllSelectedToLayer(RoomLayer.Layer1);
		}

		public void UWSendSelectedToLayer2(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Room.SendAllSelectedToLayer(RoomLayer.Layer2);
		}

		public void UWSendSelectedToLayer3(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Room.SendAllSelectedToLayer(RoomLayer.Layer3);
		}
	}
}
