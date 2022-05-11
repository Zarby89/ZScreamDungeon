// Main 
namespace ZeldaFullEditor
{
	public partial class DungeonMain : Form
	{
		private static readonly Bitmap xTabButton = new(Resources.xbutton);

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
		private bool projectLoaded = false;
		private bool anychange = false;
		private readonly List<DungeonRoom> opened_rooms = new();
		private readonly List<ushort> selectedMapPng = new();
		public ChestPicker chestPicker;
		public Entrance selectedEntrance = null;
		private PaletteEditor paletteForm;
		public DungeonRoom previewRoom = null;
		public ScreenEditor screenEditor;
		public string loadFromExported = "";

		private readonly List<RoomObjectPreview> listoftilesobjects = new();
		private readonly List<SpritePreview> listofspritesobjects = new();

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








		OverworldEditor oweditor2;
		private VramViewer vramViewer;
		private CGRamViewer cgramViewer;
		public GfxGroupsForm gfxGroupsForm;

		int tpHotTracked = -1;
		int tpHotTrackedToClose = -1;
		int tpHotTrackedToCloseLast = -2;
		int lasttpHotTracked = -2;

		// TODO move this?
		public int lastRoomID = -1;

		readonly ushort[,] lwmdata = new ushort[512, 512];
		readonly ushort[,] dwmdata = new ushort[512, 512];

		private bool propertiesChangedFromForm = false;

		// TODO: save this in a config file and load the values into this array on startup
		public bool[] saveSettingsArr = new bool[]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true
		};

		public DungeonMain()
		{
			InitializeComponent();

			Text = $"{UIText.APPNAME} - {UIText.VERSION}";

			DoorTypeComboBox.DataSource = DungeonDoorType.ListOf;
			tileTypeCombobox.DataSource = DefaultEntities.ListOfTileTypes;
			EntranceProperties_FloorSel.DataSource = FloorNumber.floors;

			objDesigner = new Object_Designer();
			objectViewer1 = new ObjectViewer();
			spritesView1 = new SpritesView();
			dungeonViewer = new DungeonViewer();
			chestPicker = new ChestPicker();
			screenEditor = new ScreenEditor();
			vramViewer = new VramViewer();
			cgramViewer = new CGRamViewer();
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			ZScreamer.ActiveGraphicsManager.fontgfx16Ptr = Marshal.AllocHGlobal((256 * 256));
			ZScreamer.ActiveGraphicsManager.currentfontgfx16Ptr = Marshal.AllocHGlobal(172 * 20000);
			ZScreamer.ActiveGraphicsManager.mapblockset16 = Marshal.AllocHGlobal(1048576);
			ZScreamer.ActiveGraphicsManager.scratchblockset16 = Marshal.AllocHGlobal(1048576);
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
			initialize_properties();
			ZScreamer.ActiveGraphicsManager.initGfx();
			mapPicturebox.Image = new Bitmap(256, 304);
			thumbnailBox.Size = new Size(256, 256);

			refreshRecentsFiles();
			Program.TextForm.Visible = false;
			Program.OverworldForm.Visible = false;
			objDesigner.Visible = false;
			gfxEditor.Visible = false;
			dungeonViewer.Visible = false;
			screenEditor.Visible = false;

			objDesigner.Dock = DockStyle.Fill;
			Program.OverworldForm.Dock = DockStyle.Fill;
			Program.TextForm.Dock = DockStyle.Fill;
			gfxEditor.Dock = DockStyle.Fill;
			dungeonViewer.Dock = DockStyle.Fill;
			screenEditor.Dock = DockStyle.Fill;

			Controls.Add(Program.OverworldForm);
			Controls.Add(Program.TextForm);
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

		// Need to stay here
		public void initialize_properties()
		{
			roomPropertyLayerMerge.DataSource = LayerMergeType.ListOf;
			roomProperty_collision.DataSource = LayerCollisionType.ListOf;
			roomProperty_effect.DataSource = LayerEffectType.ListOf;
			roomProperty_tag1.DataSource = DefaultEntities.ListOfRoomTags;
			roomProperty_tag2.DataSource = DefaultEntities.ListOfRoomTags;
			EntranceMusicBox.DataSource = DefaultEntities.ListOfUnderworldMusics;
		}

		public void AdjustContextMenuForSelectionChange()
		{
			bool theresASelection = ZScreamer.ActiveUWScene.Room.SelectedObjects.Count > 0;

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

			foreach (TabPage tp in tabControl2.TabPages)
			{
				tp.Text = tp.Text.Trim('*');
			}

			foreach (DungeonRoom r in opened_rooms)
			{
				r.FlushChanges();
			}

			anychange = false;
			//tabControl2.Refresh();
			//sw.Stop();
			//Console.WriteLine("Saved all unsaved rooms - " + sw.ElapsedMilliseconds.ToString() + "ms");

			//sw.Reset();
			//sw.Start();
			byte[] romBackup = ZScreamer.ActiveScreamer.ROM.DataStream.DeepCopy();

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
				if (saveSettingsArr[25]) Program.TextForm.Save();

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

				ZScreamer.ActiveScreamer.ROM[0x5D4E] = 0x00;

				gfxEditor.SaveAllGfx();

				//sw.Stop();
				//Console.WriteLine("Saved Overworld- " + sw.ElapsedMilliseconds.ToString() + "ms");
				//Console.WriteLine("ROMDATA[" + (ZScreamer.ActiveScreamer.Offsets.overworldMapPalette + 2).ToString("X6") + "]" + " : " + ROM.DATA[ZScreamer.ActiveScreamer.Offsets.overworldMapPalette + 2]);
				//AsarCLR.Asar.init();
				//AsarCLR.Asar.patch("titlescreen.asm", ref ROM.DATA);
				//ZScreamer.ActiveScreamer.OverworldManager.SaveMap16Tiles();

				Program.OverworldForm.saveScratchPad();

				anychange = false;

				//ROMStructure.saveProjectFile(version, projectFilename);
				//ZScreamer.ActiveScreamer.ROM.SaveLogs();

				FileStream fs = null;

				try
				{
					fs = new FileStream(projectFilename, FileMode.OpenOrCreate, FileAccess.Write);
					fs.Write(ZScreamer.ActiveScreamer.ROM.DataStream, 0, ZScreamer.ActiveScreamer.ROM.Length);
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
			catch (Exception)
			{
				UIText.CryAboutSaving("Something wrong with your file");
			}
			finally
			{
				ZScreamer.ActiveScreamer.ROM.OhShitLastResortBackup(romBackup);
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

		public void checkAnyChanges()
		{
			foreach (TabPage p in tabControl2.TabPages)
			{
				if ((p.Tag as DungeonRoom).HasUnsavedChanges)
				{
					anychange = true;
					if (!p.Text.Contains('*'))
					{
						p.Text += "*";
					}
				}
			}
		}

		// TODO magic numbers
		public void LoadProject(string filename)
		{
			// TODO : Add Headered ROM

			ZScreamer.ActiveScreamer.LoadNewROM(filename);

			ZScreamer.ActiveUWScene.Location = Constants.Point_0_0;
			ZScreamer.ActiveUWScene.Size = Constants.Size512x512;

			if (loadFromExported != "")
			{
				loadFromExported = Path.GetDirectoryName(projectFilename);
			}

			initProject();

			Text = $"{filename} - {UIText.APPNAME}";
		}

		public void initProject()
		{
			tabControl1.Enabled = true;

			editorsTabControl.Enabled = true;

			initEntrancesList();
			customPanel3.Controls.Add(ZScreamer.ActiveUWScene);
			addRoomTab(0x0104);
			projectLoaded = true;

			//tabControl2_SelectedIndexChanged(tabControl2.TabPages[0], new EventArgs());
			enableProjectButtons();
			foreach (ToolStripMenuItem mi in menuStrip1.Items)
			{
				mi.Enabled = true;
			}

			roomHeaderPanel.Enabled = true;

			// Initialize the map draw


			initObjectsList();
			spritesView1.items.Clear();
			spritesView1.items.AddRange(listofspritesobjects);

			objectViewer1.items.Clear();
			objectViewer1.items.AddRange(listoftilesobjects);

			selecteditemobjectCombobox.DataSource = DefaultEntities.ListOfSecrets;

			objectViewer1.updateSize();
			spritesView1.updateSize();

			ZScreamer.ActiveUWScene.Refresh();

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
			gfxGroupsForm = new GfxGroupsForm();
			gfxGroupsForm.CreateTempGfx();
			gfxGroupsForm.Location = Constants.Point_0_0;

			paletteForm = new PaletteEditor
			{
				Location = Constants.Point_0_0
			};
			refreshRecentsFiles();
			Program.OverworldForm.InitOpen();
			Program.TextForm.InitializeOnOpen();
			screenEditor.Init();
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
					ZScreamer.ActiveUWScene.Room = ZScreamer.ActiveScreamer.all_rooms[i];

					ZScreamer.ActiveUWScene.Refresh();

					gb.DrawImage(ZScreamer.ActiveUWScene.tempBitmap, new Point((i % 16) * 512, (i / 16) * 512));
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

		// TODO copy and reconfiguring
		public void initEntrancesList()
		{
			// Entrances
			for (int i = 0; i < 0x07; i++)
			{
				ZScreamer.ActiveScreamer.starting_entrances[i] = new Entrance(ZScreamer.ActiveScreamer, (byte) i, true);
				string tname = $"[{i:X2}] > {DefaultEntities.ListOfRoomNames[ZScreamer.ActiveScreamer.starting_entrances[i].RoomID]:X3}";

				entrancetreeView.Nodes[1].Nodes.Add(
					new TreeNode(tname)
					{
						Tag = i,
					}
				);
			}

			for (int i = 0; i < Constants.NumberOfEntrances; i++)
			{
				ZScreamer.ActiveScreamer.entrances[i] = new Entrance(ZScreamer.ActiveScreamer, (byte) i, false);
				string tname = $"[{i:X2}] > {DefaultEntities.ListOfRoomNames[ZScreamer.ActiveScreamer.entrances[i].RoomID]:X3}";

				entrancetreeView.Nodes[0].Nodes.Add(
					new TreeNode(tname)
					{
						Tag = i,
					}
				);
			}

			entrancetreeView.SelectedNode = entrancetreeView.Nodes[0].Nodes[0];
			selectedEntrance = ZScreamer.ActiveScreamer.entrances[0];
		}

		public void enableProjectButtons()
		{
			allbgsButton.Enabled = true;
			bg3modeButton.Enabled = true;
			bg2modeButton.Enabled = true;
			bg1modeButton.Enabled = true;
			saveButton.Enabled = true;
			doormodeButton.Enabled = true;
			blockmodeButton.Enabled = true;
			torchmodeButton.Enabled = true;
			spritemodeButton.Enabled = true;
			debugtestButton.Enabled = true;
			runtestButton.Enabled = true;
			potmodeButton.Enabled = true;
			saveToolStripMenuItem.Enabled = true;
			saveasToolStripMenuItem.Enabled = true;
			saveLayoutButton.Enabled = true;
			loadlayoutButton.Enabled = true;
			toolStripButton1.Enabled = true;
			searchButton.Enabled = true;
			collisionModeButton.Enabled = true;

			foreach (var it in editToolStripMenuItem.DropDownItems)
			{
				if (it is ToolStripDropDownItem tt)
				{
					tt.Enabled = true;
				}
			}
		}

		private readonly AboutBox1 aboutBox = new();
		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aboutBox.ShowDialog();
		}

		private void UpdateUnderworldMode(object sender, EventArgs e)
		{
			ZScreamer.ActiveScreamer.CurrentUWMode = ((DungeonEditMode) ((ToolStripItem) sender).Tag);
		}

		private void UpdateUnderworldMode_Collision(object sender, EventArgs e)
		{
			ZScreamer.ActiveScreamer.CurrentUWMode = DungeonEditMode.CollisionMap;

			xScreenToolStripMenuItem.Checked = true;
			hideSpritesToolStripMenuItem_CheckStateChanged(null, null);
			tileTypeCombobox.SelectedIndex = 0;
			collisionMapPanel.Visible = true;
		}

		public void UpdateUnderworldMode(DungeonEditMode m)
		{
			allbgsButton.Checked = m == DungeonEditMode.LayerAll;
			bg1modeButton.Checked = m == DungeonEditMode.Layer1;
			bg2modeButton.Checked = m == DungeonEditMode.Layer2;
			bg3modeButton.Checked = m == DungeonEditMode.Layer3;
			spritemodeButton.Checked = m == DungeonEditMode.Sprites;
			blockmodeButton.Checked = m == DungeonEditMode.Blocks;
			torchmodeButton.Checked = m == DungeonEditMode.Torches;
			potmodeButton.Checked = m == DungeonEditMode.Secrets;
			doormodeButton.Checked = m == DungeonEditMode.Doors;
			collisionModeButton.Checked = m == DungeonEditMode.CollisionMap;
			collisionMapPanel.Visible = m == DungeonEditMode.CollisionMap;

			foreach (DungeonRoom room in opened_rooms)
			{
				room.ClearSelectedList(); // TODO necessary?
			}
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
				Program.TextForm.delete();
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
				Program.TextForm.selectAll();
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
				Program.TextForm.cut();
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
				Program.TextForm.paste();
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
				Program.TextForm.copy();
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
				Program.TextForm.undo();
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
				ZScreamer.ActiveUWScene.showLayer1 = showBG1ToolStripMenuItem.Checked;
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
			ZScreamer.ActiveUWScene.showLayer2 = showBG2ToolStripMenuItem.Checked;
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
		//		fs.Write(ZScreamer.ActiveScreamer.ROM.DATA, 0, ZScreamer.ActiveScreamer.ROM.DATA.Length);
		//		fs.Close();
		//	}
		//}

		public void entrancetreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (!projectLoaded)
			{
				return;
			}

			propertiesChangedFromForm = true;
			Entrance en = selectedEntrance;
			if (e?.Node.Tag != null)
			{
				// TODO gross
				en = ZScreamer.ActiveScreamer.entrances[(int) e.Node.Tag];
				if (e.Node.Parent?.Name == "StartingEntranceNode")
				{
					en = ZScreamer.ActiveScreamer.starting_entrances[(int) e.Node.Tag];
				}
			}

			//propertyGrid2.SelectedObject = entrances[(int)e.Node.Tag];
			entranceProperty_bg.Checked = false;

			EntranceProperties_RoomID.HexValue = en.RoomID;
			EntranceProperties_DungeonID.HexValue = en.Dungeon;
			EntranceProperties_Blockset.HexValue = en.Blockset;
			EntranceMusicBox.SelectedItem = en.Music;
			EntranceProperties_Entrance.HexValue = en.AssociatedEntrance;

			EntranceProperties_Entrance.Enabled = en.IsSpawnPoint;

			EntranceProperties_PlayerX.HexValue = en.XPosition;
			EntranceProperties_PlayerY.HexValue = en.YPosition;
			EntranceProperties_CameraX.HexValue = en.CameraX;
			EntranceProperties_CameraY.HexValue = en.CameraY;
			EntranceProperties_CameraTriggerX.HexValue = en.CameraTriggerX;
			EntranceProperties_CameraTriggerY.HexValue = en.CameraTriggerY;


			EntranceProperties_FloorSel.SelectedIndex = FloorNumber.FindFloorIndex(en.Floor);

			EntranceProperties_Entrance.HexValue = en.OverworldEntranceLocation;

			if (en.Ladderbg.BitIsOn(0x10))
			{
				entranceProperty_bg.Checked = true;
			}

			if (ZScreamer.ActiveUWScene.Room != null)
			{
				selectedEntrance = en;

				ZScreamer.ActiveUWScene.HardRefresh();
			}

			entranceProperty_vscroll.Checked = en.Scrolling.BitIsOn(0x02);
			entranceProperty_hscroll.Checked = en.Scrolling.BitIsOn(0x20);
			entranceProperty_quadbr.Checked = false;
			entranceProperty_quadbl.Checked = false;
			entranceProperty_quadtl.Checked = false;
			entranceProperty_quadtr.Checked = false;

			EntranceProperty_BoundaryQN.HexValue = en.cameraBoundaryQN;
			EntranceProperty_BoundaryFN.HexValue = en.cameraBoundaryFN;
			EntranceProperty_BoundaryQS.HexValue = en.cameraBoundaryQS;
			EntranceProperty_BoundaryFS.HexValue = en.cameraBoundaryFS;
			EntranceProperty_BoundaryQW.HexValue = en.cameraBoundaryQW;
			EntranceProperty_BoundaryFW.HexValue = en.cameraBoundaryFW;
			EntranceProperty_BoundaryQE.HexValue = en.cameraBoundaryQE;
			EntranceProperty_BoundaryFE.HexValue = en.cameraBoundaryFE;

			int p = (en.OverworldEntranceLocation & 0x7FFF) >> 1;
			doorxTextbox.Text = (p % 64).ToString("X2");
			dooryTextbox.Text = (p >> 6).ToString("X2");

			if (en.Scrollquadrant == 0x12) // Bottom right
			{
				entranceProperty_quadbr.Checked = true;
			}
			else if (en.Scrollquadrant == 0x02) // Bottom left
			{
				entranceProperty_quadbl.Checked = true;
			}
			else if (en.Scrollquadrant == 0x00) // Top left
			{
				entranceProperty_quadtl.Checked = true;
			}
			else if (en.Scrollquadrant == 0x10) // Top right
			{
				entranceProperty_quadtr.Checked = true;
			}

			propertiesChangedFromForm = false;
		}

		public void sortObject()
		{
			throw new NotImplementedException();
			//objectViewer1.BeginUpdate();
			//objectViewer1.items.Clear();
			//
			//if (favoriteCheckbox.Checked)
			//{
			//	// Sorting sort;
			//	string searchText = searchTextbox.Text.ToLower();
			//
			//	// ListView1
			//	objectViewer1.items.AddRange(listoftilesobjects
			//		.Where(x => x != null)
			//		.Where(x => x.name.ToLower().Contains(searchText))
			//		.Where(x => Settings.Default.favoriteObjects[x.id] == "true")
			//		.OrderBy(x => x.id)
			//		.Select(x => x) // ?
			//		.ToArray());
			//
			//	panel1.VerticalScroll.Value = 0;
			//	objectViewer1.Refresh();
			//}
			//else
			//{
			//	// Sorting sort;
			//	string searchText = searchTextbox.Text.ToLower();
			//
			//	// ListView1
			//	objectViewer1.items.AddRange(listoftilesobjects
			//		.Where(x => x != null)
			//		.Where(x => (x.name.ToLower().Contains(searchText)))
			//		.OrderBy(x => x.id)
			//		.Select(x => x) // ?
			//		.ToArray());
			//	objectViewer1.updateSize();
			//	panel1.VerticalScroll.Value = 0;
			//	objectViewer1.Refresh();
			//}
		}

		public void sortSprite()
		{
			throw new NotImplementedException();
			//spritesView1.items.Clear();
			//string searchText = searchspriteTextbox.Text.ToLower();
			//
			//spritesView1.items.AddRange(listofspritesobjects
			//	.Where(x => x != null)
			//	.Where(x => (x.name.ToLower().Contains(searchText)))
			//	.OrderBy(x => x.id)
			//	.Select(x => x) // ?
			//	.ToArray());
			//
			//customPanel1.VerticalScroll.Value = 0;
			//
			//if (searchText == "")
			//{
			//	spritesView1.items.Clear();
			//	foreach (Sprite o in listofspritesobjects)
			//	{
			//		spritesView1.items.Add((o));
			//	}
			//}
			//
			//spritesView1.Refresh();
		}

		private void searchTextbox_TextChanged(object sender, EventArgs e)
		{
			sortObject();
			objectViewer1.updateSize();
		}

		private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Added refresh here so that the grid will appear when the checkbox is clicked.
			ZScreamer.ActiveUWScene.Refresh();
		}

		private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex > 0 && ZScreamer.ActiveUWScene.Room?.OnlySelectedObject is DungeonSprite s)
			{
				foreach (DungeonSprite spr in ZScreamer.ActiveUWScene.Room.SpritesList)
				{
					spr.KeyDrop = 0;
				}
				s.KeyDrop = (byte) comboBox1.SelectedIndex;
				ZScreamer.ActiveUWScene.Refresh();
			}
		}

		private void searchspriteTextbox_TextChanged(object sender, EventArgs e)
		{
			sortSprite();
		}

		private void selecteditemobjectCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (selecteditemobjectCombobox.SelectedIndex != -1 && ZScreamer.ActiveUWScene.Room?.OnlySelectedObject is DungeonSecret p)
			{
				p.SecretType = SecretItemType.GetTypeFromID((byte) (selecteditemobjectCombobox.SelectedItem as SecretsName).ID);
				ZScreamer.ActiveUWScene.Refresh();
			}
		}

		public void addRoomTab(ushort roomId)
		{
			bool alreadyFound = false;
			foreach (DungeonRoom room in opened_rooms)
			{
				if (room.RoomID == roomId)
				{
					alreadyFound = true;
					break;
				}
			}

			if (alreadyFound)
			{
				// Display message error room already opened
				//MessageBox.Show("That room is already opened !");
				foreach (TabPage tp in tabControl2.TabPages)
				{
					if ((tp.Tag as DungeonRoom).RoomID == roomId)
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
				var r = ZScreamer.ActiveScreamer.all_rooms[roomId];

				/*
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
                */

				/*
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
                */

				//mapPropertyGrid.SelectedObject = r;

				opened_rooms.Add(r); // Add the double clicked room into rooms list     
				ZScreamer.ActiveUWScene.Room = r;

				//string tn = r.index.ToString("D3");
				//if (showRoomsInHexToolStripMenuItem.Checked)
				//{
				string tn = r.RoomID.ToString("X3");
				//}

				TabPage tp = new TabPage(tn)
				{
					Tag = r
				};
				tabControl2.TabPages.Add(tp);
				//objectsListbox.ClearSelected();
				tabControl2.SelectedTab = tp;

				//paletteViewer.update();
				ZScreamer.ActiveUWScene.HardRefresh();

				objectViewer1.updateSize();
				spritesView1.updateSize();
			}

			if (tabControl2.TabPages.Count > 0)
			{
				tabControl2.Visible = true;
				ZScreamer.ActiveUWScene.HardRefresh();
			}

			cgramViewer.Refresh();
		}

		private void entrancetreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Tag != null)
			{
				if (e.Node.Parent == entrancetreeView.Nodes[0])
				{
					addRoomTab(ZScreamer.ActiveScreamer.entrances[(int) e.Node.Tag].RoomID);
				}
				else
				{
					addRoomTab(ZScreamer.ActiveScreamer.starting_entrances[(int) e.Node.Tag].RoomID);
				}
			}
		}

		private void mapPicturebox_MouseDoubleClick_1(object sender, MouseEventArgs e)
		{

			if (e.Y >= 256 && e.Y <= 264)
			{
				return;
			}

			int yc = e.Y;

			if (e.Y > 256)
			{
				yc -= 8;
			}

			int x = e.X / 16;
			int y = yc / 16;
			ushort roomId = (ushort) (x + (y * 16));

			if (ModifierKeys == Keys.Control)
			{
				// Check if map is already in
				ushort? alreadyIn = null;
				foreach (ushort s in selectedMapPng)
				{
					// If it was already in delete it
					if (s == roomId)
					{
						alreadyIn = s;
					}
				}

				if (alreadyIn != null)
				{
					selectedMapPng.Remove((ushort) alreadyIn);
				}
				else
				{
					selectedMapPng.Add(roomId);
				}

				//loadRoomList(roomId);
			}
			else
			{
				if (roomId < Constants.NumberOfRooms)
				{
					addRoomTab(roomId);
					//loadRoomList(roomId);
				}
			}

			mapPicturebox.Refresh();
		}

		public void runtestButton_Click(object sender, EventArgs e)
		{
			/*
            if (File.Exists("temp.sfc"))
            {
                File.Delete("temp.sfc");
            }

            FileStream brom = new FileStream(baseROM, FileMode.Open, FileAccess.Read);
            brom.Read(ZScreamer.ActiveScreamer.ROM.DATA, 0, (int)brom.Length);
            brom.Close();

            saveToolStripMenuItem_Click(sender, e);
            
            FileStream fs = new FileStream("temp.sfc", FileMode.CreateNew, FileAccess.Write);

            fs.Write(ZScreamer.ActiveScreamer.ROM.DATA, 0, ROM.DATA.Length);
            fs.Close();
            Process p = Process.Start("temp.sfc");
            */
			saveToolStripMenuItem_Click(saveToolStripMenuItem, new EventArgs());
			Process.Start(projectFilename);
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Doors
			if (DoorTypeComboBox.SelectedIndex > 0 && ZScreamer.ActiveUWScene.Room?.OnlySelectedObject is DungeonDoor d)
			{
				var door = (DungeonDoorType) DoorTypeComboBox.SelectedItem;
				d.DoorTiles = ZScreamer.ActiveScreamer.TileLister.GetDoorTileSet(door.ID);
				d.DoorType = door;
				ZScreamer.ActiveUWScene.Room.HasUnsavedChanges = true;
				ZScreamer.ActiveUWScene.HardRefresh();
			}
		}

		private void debugtestButton_Click(object sender, EventArgs e)
		{
			if (File.Exists(UIText.TestROM))
			{
				File.Delete(UIText.TestROM);
			}

			//Console.WriteLine(Path.GetDirectoryName(projectFilename));
			//return;
			ROMFile testrom = ZScreamer.ActiveScreamer.ROM.Clone();
			saveToolStripMenuItem_Click(sender, e);

			if (File.Exists(Path.GetDirectoryName(projectFilename) + "\\Main.asm"))
			{
				testrom.ApplyPatch(Path.GetDirectoryName(projectFilename) + "\\Main.asm");
			}

			foreach (AsarCLR.Asarerror error in AsarCLR.Asar.geterrors())
			{
				Console.WriteLine(error.Fullerrdata.ToString());
			}

			testrom.Write16(ZScreamer.ActiveScreamer.Offsets.startingentrance_room, selectedEntrance.RoomID);
			testrom.Write16(ZScreamer.ActiveScreamer.Offsets.startingentrance_yposition, selectedEntrance.YPosition);
			testrom.Write16(ZScreamer.ActiveScreamer.Offsets.startingentrance_xposition, selectedEntrance.XPosition);
			testrom.Write16(ZScreamer.ActiveScreamer.Offsets.startingentrance_camerax, selectedEntrance.CameraX);
			testrom.Write16(ZScreamer.ActiveScreamer.Offsets.startingentrance_cameray, selectedEntrance.CameraY);
			testrom.Write16(ZScreamer.ActiveScreamer.Offsets.startingentrance_cameraxtrigger, selectedEntrance.CameraTriggerX);
			testrom.Write16(ZScreamer.ActiveScreamer.Offsets.startingentrance_cameraytrigger, selectedEntrance.CameraTriggerY);
			testrom.Write16(ZScreamer.ActiveScreamer.Offsets.startingentrance_exit, selectedEntrance.OverworldEntranceLocation);
			testrom[ZScreamer.ActiveScreamer.Offsets.startingentrance_blockset] = selectedEntrance.Blockset;
			testrom[ZScreamer.ActiveScreamer.Offsets.startingentrance_music] = (byte) selectedEntrance.Music.ID;
			testrom[ZScreamer.ActiveScreamer.Offsets.startingentrance_dungeon] = selectedEntrance.Dungeon;
			testrom[ZScreamer.ActiveScreamer.Offsets.startingentrance_floor] = selectedEntrance.Floor;
			testrom[ZScreamer.ActiveScreamer.Offsets.startingentrance_ladderbg] = selectedEntrance.Ladderbg;
			testrom[ZScreamer.ActiveScreamer.Offsets.startingentrance_scrolling] = selectedEntrance.Scrolling;
			testrom[ZScreamer.ActiveScreamer.Offsets.startingentrance_scrollquadrant] = selectedEntrance.Scrollquadrant;

			testrom.Write(ZScreamer.ActiveScreamer.Offsets.startingentrance_scrolledge,
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

		public void UpdateUIForRoom(DungeonRoom room, bool prevent = true)
		{
			if (room == null)
			{
				return;
			}

			propertiesChangedFromForm = prevent;

			roomPropertyLayerMerge.SelectedItem = room.LayerMerging;
			roomProperty_tag1.SelectedIndex = room.Tag1;
			roomProperty_tag2.SelectedIndex = room.Tag2;
			roomProperty_effect.SelectedItem = room.LayerEffect;
			roomProperty_collision.SelectedItem = room.LayerCollision;
			RoomProperty_IsDark.Checked = room.IsDark;

			roomProperty_pit.Checked = room.HasDamagingPits;
			roomProperty_sortsprite.Checked = room.MultiLayerOAM;

			RoomProperty_Blockset.HexValue = room.BackgroundTileset;
			RoomProperty_SpriteSet.HexValue = room.SpriteTileset;
			RoomProperty_Floor1.HexValue = room.Floor1Graphics;
			RoomProperty_Floor2.HexValue = room.Floor2Graphics;
			RoomProperty_MessageID.HexValue = room.MessageID;
			RoomProperty_Layout.HexValue = room.Layout;
			RoomProperty_Palette.HexValue = room.Palette;

			RoomProperty_DestinationPit.HexValue = room.Pits.Target;
			RoomProperty_DestinationStair1.HexValue = room.Stair1.Target;
			RoomProperty_DestinationStair2.HexValue = room.Stair2.Target;
			RoomProperty_DestinationStair3.HexValue = room.Stair3.Target;
			RoomProperty_DestinationStair4.HexValue = room.Stair4.Target;

			bg2checkbox1.Checked = room.Pits.TargetLayer == 2;
			bg2checkbox2.Checked = room.Stair1.TargetLayer == 2;
			bg2checkbox3.Checked = room.Stair2.TargetLayer == 2;
			bg2checkbox4.Checked = room.Stair3.TargetLayer == 2;
			bg2checkbox5.Checked = room.Stair4.TargetLayer == 2;

			propertiesChangedFromForm = false;
		}

		public void UpdateRoomInfo()
		{
			if (!propertiesChangedFromForm && ZScreamer.ActiveUWScene.Room != null)
			{
				var room = ZScreamer.ActiveUWScene.Room;

				room.LayerEffect = (LayerEffectType) roomProperty_effect.SelectedItem;
				room.Tag1 = (byte) (roomProperty_tag1.SelectedItem as RoomTagName).ID;
				room.Tag2 = (byte) (roomProperty_tag2.SelectedItem as RoomTagName).ID;
				room.LayerMerging = (LayerMergeType) roomPropertyLayerMerge.SelectedItem;
				room.LayerCollision = (LayerCollisionType) roomProperty_collision.SelectedItem;

				room.BackgroundTileset = (byte) RoomProperty_Blockset.HexValue;
				room.Floor1Graphics = (byte) RoomProperty_Floor1.HexValue;
				room.Floor2Graphics = (byte) RoomProperty_Floor2.HexValue;
				room.Layout = (byte) RoomProperty_Layout.HexValue;

				room.MessageID = (ushort) RoomProperty_MessageID.HexValue;
				room.Palette = (byte) RoomProperty_Palette.HexValue;

				room.Pits.Target = (byte) RoomProperty_DestinationPit.HexValue;
				room.Stair1.Target = (byte) RoomProperty_DestinationStair1.HexValue;
				room.Stair2.Target = (byte) RoomProperty_DestinationStair2.HexValue;
				room.Stair3.Target = (byte) RoomProperty_DestinationStair3.HexValue;
				room.Stair4.Target = (byte) RoomProperty_DestinationStair4.HexValue;

				room.Pits.TargetLayer = (byte) (bg2checkbox1.Checked ? 2 : 0);
				room.Stair1.TargetLayer = (byte) (bg2checkbox2.Checked ? 2 : 0);
				room.Stair2.TargetLayer = (byte) (bg2checkbox3.Checked ? 2 : 0);
				room.Stair3.TargetLayer = (byte) (bg2checkbox4.Checked ? 2 : 0);
				room.Stair4.TargetLayer = (byte) (bg2checkbox5.Checked ? 2 : 0);

				room.HasDamagingPits = roomProperty_pit.Checked;
				room.MultiLayerOAM = roomProperty_sortsprite.Checked;
				room.IsDark = RoomProperty_IsDark.Checked;

				room.SpriteTileset = (byte) RoomProperty_SpriteSet.HexValue;

				/*
                undoRoom[activeScene.room.index].Add((Room)activeScene.room.Clone());
                redoRoom[activeScene.room.index].Clear();
                */

				ZScreamer.ActiveUWScene.HardRefresh();
				ZScreamer.ActiveUWScene.Room.HasUnsavedChanges = true;
				checkAnyChanges();
			}
		}

		public void updateEntranceInfos()
		{
			if (!propertiesChangedFromForm)
			{
				selectedEntrance.Blockset = (byte) EntranceProperties_Blockset.HexValue;
				selectedEntrance.RoomID = (ushort) EntranceProperties_RoomID.HexValue;

				if (EntranceProperties_FloorSel.SelectedIndex >= 0)
				{
					selectedEntrance.Floor = (EntranceProperties_FloorSel.SelectedItem as FloorNumber).ByteValue;
				}

				selectedEntrance.Dungeon = (byte) EntranceProperties_DungeonID.HexValue;
				selectedEntrance.Music = (MusicName) EntranceMusicBox.SelectedItem;

				if (selectedEntrance.IsSpawnPoint)
				{
					selectedEntrance.AssociatedEntrance = (byte) EntranceProperties_Entrance.HexValue;
				}

				selectedEntrance.OverworldEntranceLocation = (byte) EntranceProperties_Entrance.HexValue;

				selectedEntrance.Ladderbg = (byte) (entranceProperty_bg.Checked ? 0x10 : 0x00);

				selectedEntrance.cameraBoundaryQN = (byte) EntranceProperty_BoundaryQN.HexValue;
				selectedEntrance.cameraBoundaryFN = (byte) EntranceProperty_BoundaryFN.HexValue;
				selectedEntrance.cameraBoundaryQS = (byte) EntranceProperty_BoundaryQS.HexValue;
				selectedEntrance.cameraBoundaryFS = (byte) EntranceProperty_BoundaryFS.HexValue;
				selectedEntrance.cameraBoundaryQW = (byte) EntranceProperty_BoundaryQW.HexValue;
				selectedEntrance.cameraBoundaryFW = (byte) EntranceProperty_BoundaryFW.HexValue;
				selectedEntrance.cameraBoundaryQE = (byte) EntranceProperty_BoundaryQE.HexValue;
				selectedEntrance.cameraBoundaryFE = (byte) EntranceProperty_BoundaryFE.HexValue;

				selectedEntrance.XPosition = (ushort) EntranceProperties_PlayerX.HexValue;
				selectedEntrance.YPosition = (ushort) EntranceProperties_PlayerY.HexValue;
				selectedEntrance.CameraX = (ushort) EntranceProperties_CameraTriggerX.HexValue;
				selectedEntrance.CameraY = (ushort) EntranceProperties_CameraTriggerY.HexValue;
				selectedEntrance.CameraTriggerX = (ushort) EntranceProperties_CameraTriggerX.HexValue;
				selectedEntrance.CameraTriggerY = (ushort) EntranceProperties_CameraTriggerY.HexValue;


				if (int.TryParse(doorxTextbox.Text, NumberStyles.HexNumber, null, out int r) &&
					int.TryParse(dooryTextbox.Text, NumberStyles.HexNumber, null, out int rr))
				{
					selectedEntrance.OverworldEntranceLocation = (ushort) (((rr << 6) + (r & 0x3F)) << 1);
				}
				else
				{
					selectedEntrance.OverworldEntranceLocation = 0;
				}

				if (entranceProperty_quadbr.Checked)
				{
					selectedEntrance.Scrollquadrant = 0x12;
				}
				else if (entranceProperty_quadbl.Checked)
				{
					selectedEntrance.Scrollquadrant = 0x02;
				}
				else if (entranceProperty_quadtl.Checked)
				{
					selectedEntrance.Scrollquadrant = 0x00;
				}
				else if (entranceProperty_quadtr.Checked)
				{
					selectedEntrance.Scrollquadrant = 0x10;
				}

				//if (entranceProperty_quadbl)

				selectedEntrance.Scrolling = IntFunctions.SetFieldBits(
					bit1: entranceProperty_vscroll.Checked,
					bit5: entranceProperty_hscroll.Checked
					);

				ZScreamer.ActiveUWScene.HardRefresh();
				ZScreamer.ActiveUWScene.Room.HasUnsavedChanges = true;
			}
		}

		public void closeRoom(int index)
		{
			for (int j = 0; j < opened_rooms.Count; j++)
			{
				if (opened_rooms[j].RoomID == index)
				{
					opened_rooms.RemoveAt(j);
					return;
				}
			}
		}

		// TODO copy
		private void CloseTab(int i)
		{
			var room = (DungeonRoom) tabControl2.TabPages[i].Tag;

			bool close;

			if (room.HasUnsavedChanges)
			{
				switch (UIText.WarnAboutSaving(UIText.RoomWarning))
				{
					case DialogResult.Yes:
						room.FlushChanges();
						close = true;
						break;

					case DialogResult.No:
						room.ClearChanges();
						close = true;
						break;

					default:
					case DialogResult.Cancel:
						close = false;
						break;
				}
			}
			else
			{
				close = true;
			}

			if (close)
			{
				closeRoom(room.RoomID);
				tabControl2.TabPages.RemoveAt(i);
				if (tabControl2.TabPages.Count == 0)
				{
					tabControl2.Visible = false;
					ZScreamer.ActiveUWScene.Clear();
					ZScreamer.ActiveUWScene.Room = null;
					ZScreamer.ActiveUWScene.Refresh();
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
				ZScreamer.ActiveUWScene.Room = tabControl2.TabPages[tabControl2.SelectedIndex].Tag as DungeonRoom;

				if (ZScreamer.ActiveScreamer.undoRoom[ZScreamer.ActiveUWScene.Room.RoomID].Count > 0)
				{
					undoButton.Enabled = true;
					undoToolStripMenuItem.Enabled = true;
				}
				else
				{
					// TODO is this wrong?
					redoButton.Enabled = false;
					redoToolStripMenuItem.Enabled = false;
				}

				if (ZScreamer.ActiveScreamer.redoRoom[ZScreamer.ActiveUWScene.Room.RoomID].Count > 0)
				{
					redoButton.Enabled = true;
					redoToolStripMenuItem.Enabled = true;
				}
				else
				{
					redoButton.Enabled = false;
					redoToolStripMenuItem.Enabled = false;
				}

				ZScreamer.ActiveUWScene.Refresh();
				spritesView1.updateSize();
				spritesView1.Refresh();
				objectViewer1.updateSize();
				objectViewer1.Refresh();
			}
			else
			{
				ZScreamer.ActiveUWScene.Clear();
			}

			mapPicturebox.Refresh();
		}

		public void initObjectsList()
		{
			for (ushort i = 0; i < 0x300; i++)
			{
				RoomObjectType o = RoomObjectType.GetTypeFromID(i);
				if (o != null)
				{
					listoftilesobjects.Add(new RoomObjectPreview(o, ZScreamer.ActiveScreamer.TileLister[i]));
				}
			}

			// TODO previews for sprites and overlords
			for (byte i = 0; i < 0xF2; i++)
			{
				listofspritesobjects.Add(new SpritePreview(SpriteType.GetTypeFromID(i)));
			}

			for (byte i = 1; i < 0x1B; i++)
			{
				listofspritesobjects.Add(new SpritePreview(OverlordType.GetTypeFromID(i)));
			}

			//sortObject();
		}

		private void objectViewer1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.ObjectToPlace = objectViewer1.CreateSelectedObject();
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
			objectViewer1.Refresh();
		}

		private void entranceProperty_vscroll_CheckedChanged(object sender, EventArgs e)
		{
			updateEntranceInfos();
		}

		private void spritesView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.ObjectToPlace = spritesView1.CreateSelectedSprite();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			// Check what's the higher map and the left most, we don't care about right bottom

			//(map / 16) = Y position
			//map - (Y*16) = X position
			int lowerX = 16; // What we need to remove from the image to the left
			int lowerY = 16; // What we need to remove from the image to the right
			int higherX = 0; // What we need to remove from the image to the left
			int higherY = 0; // What we need to remove from the image to the right

			if (selectedMapPng.Count > 0)
			{
				Bitmap b = new Bitmap(8192, 10752);

				using (Graphics gb = Graphics.FromImage(b))
				{
					foreach (ushort s in selectedMapPng)
					{
						if (s < ZScreamer.ActiveScreamer.all_rooms.Length && ZScreamer.ActiveScreamer.all_rooms[s] != null)
						{
							int cy = s / 16;
							int cx = s & 0xF;
							if (cx < lowerX) { lowerX = cx; }
							if (cy < lowerY) { lowerY = cy; }
							if (cx > higherX) { higherX = cx; }
							if (cy > higherY) { higherY = cy; }

							Program.RoomPreviewArtist.SetRoomAndDrawImmediately(ZScreamer.ActiveScreamer.all_rooms[s]);

							gb.DrawImage(Program.RoomPreviewArtist.FinalOutput, new Point(cx * 512, cy * 512));
						}
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

				// TODO better names so we can have more than 1 map
				nb.Save("MapTest.png");
				b.Dispose();
				nb.Dispose();
			}
			else
			{
				Bitmap b = new Bitmap(512, 512);
				ZScreamer.ActiveUWScene.DrawToBitmap(b, Constants.Rect_0_0_512_512);
				b.Save("singlemap.png");
			}
		}

		private void litCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (ZScreamer.ActiveUWScene.IsUpdating && ZScreamer.ActiveUWScene.Room?.OnlySelectedObject is DungeonTorch torch)
			{
				torch.Lit = litCheckbox.Checked;
			}
		}

		// TODO move to constants
		private void patchNotesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/Zarby89/ZScreamDungeon/blob/master/ZeldaFullEditor/PatchNotes.txt");
		}

		private void spritesubtypeUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (!ZScreamer.ActiveUWScene.IsUpdating && ZScreamer.ActiveUWScene.Room?.OnlySelectedObject is DungeonSprite spr)
			{
				spr.Subtype = (byte) spritesubtypeUpDown.Value;
			}
		}

		private void gotoRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GotoRoom gotoRoom = new GotoRoom();
			if (gotoRoom.ShowDialog() == DialogResult.OK)
			{
				addRoomTab((ushort) gotoRoom.SelectedRoom);
			}
		}

		private void advancedChestEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AdvancedChestEditorForm chestEditorForm = new AdvancedChestEditorForm();
			chestEditorForm.ShowDialog();
		}

		private void mapPicturebox_Paint(object sender, PaintEventArgs e)
		{
			if (!projectLoaded)
			{
				return;
			}

			int xd = 0;
			int yd = 0;
			int yoff = 0;
			e.Graphics.Clear(Color.Black);
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				if (!ZScreamer.ActiveScreamer.all_rooms[i].IsEmpty)
				{
					e.Graphics.FillRectangle(
						new SolidBrush(ZScreamer.ActivePaletteManager.LoadDungeonPalette(ZScreamer.ActiveScreamer.all_rooms[i].Palette)[4, 2]),
						new Rectangle(xd * 16, (yd * 16) + yoff,
						16,
						16));

					foreach (ushort s in selectedMapPng)
					{
						if (s == i)
						{
							e.Graphics.DrawRectangle(Constants.AquaPen2, new Rectangle(xd * 16, (yd * 16) + yoff, 16, 16));
						}
					}
				}

				xd++;
				if (xd == 16)
				{
					yd++;
					yoff = (yd > 15) ? 8 : 0;
					xd = 0;
				}
			}

			for (int i = 0; i < 16 * 16; i += 16)
			{
				e.Graphics.DrawLine(Pens.White, 0, i, 256, i);
				e.Graphics.DrawLine(Pens.White, i, 0, i, 256);
				e.Graphics.DrawLine(Pens.White, i, 264, i, 312);
			}

			e.Graphics.DrawLine(Pens.White, 0, 264 + 00, 256, 264 + 00);
			e.Graphics.DrawLine(Pens.White, 0, 264 + 16, 256, 264 + 16);
			e.Graphics.DrawLine(Pens.White, 0, 264 + 32, 256, 264 + 32);


			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				yoff = (i > 255) ? 8 : 0;

				foreach (TabPage tp in tabControl2.TabPages)
				{
					if ((tp.Tag as DungeonRoom).RoomID == (ushort) i)
					{
						e.Graphics.DrawRectangle(
								new Pen((tabControl2.SelectedTab == tp) ? Color.YellowGreen : Color.DarkGreen, 2),
								new Rectangle((i % 16) * 16, (i & ~0xF) + yoff, 16, 16));
					}
				}
			}
		}

		private void hideSpritesToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
		{
			if (x2zoom)
			{
				ZScreamer.ActiveUWScene.Size = Constants.Size1024x1024;
				panel3.Location = new Point(1032, -1);
			}
			else
			{
				ZScreamer.ActiveUWScene.Size = Constants.Size512x512;
				panel3.Location = new Point(520, -1);
			}

			ZScreamer.ActiveUWScene.Refresh();
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
					if (r.ObjectType.Specialness == SpecialObjectType.LayerMask)
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
				addRoomTab((ushort) gotoRoom.SelectedRoom);
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
			// do we need a new one every time?
			vramViewer = new VramViewer();
			WindowPanel wp = new WindowPanel
			{
				Location = Constants.Point_512_0
			};
			wp.containerPanel.Controls.Add(vramViewer);
			wp.Tag = "VRAM Viewer";
			wp.Size = new Size(vramViewer.Size.Width + 2, vramViewer.Size.Height + 26);
			customPanel3.Controls.Add(wp);
			wp.BringToFront();
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
			cgramViewer = new CGRamViewer();
			WindowPanel wp = new WindowPanel
			{
				Tag = "CGRAM Viewer - Right click to export palettes",
				Location = Constants.Point_512_0
			};
			wp.containerPanel.Controls.Add(cgramViewer);
			wp.Size = new Size(cgramViewer.Size.Width + 2, cgramViewer.Size.Height + 26);
			customPanel3.Controls.Add(wp);
			wp.BringToFront();
		}

		private void gfxGroupsetsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedTab.Name == "dungeonPage")
			{
				WindowPanel wp = new WindowPanel
				{
					Tag = "Gfx Groupset Editor",
					Location = Constants.Point_512_0
				};
				wp.containerPanel.Controls.Add(gfxGroupsForm);
				wp.Size = new Size(gfxGroupsForm.Size.Width + 2, gfxGroupsForm.Size.Height + 26);
				customPanel3.Controls.Add(wp);
				wp.BringToFront();
			}
			else if (editorsTabControl.SelectedTab.Name == "overworldPage")
			{
				WindowPanel wp = new WindowPanel
				{
					Tag = "GFX Groups Editor",
					Location = Constants.Point_512_0
				};
				wp.containerPanel.Controls.Add(new GfxGroupsForm());
				wp.Size = new Size(gfxGroupsForm.Size.Width + 2, gfxGroupsForm.Size.Height + 26);
				Program.OverworldForm.splitContainer1.Panel2.Controls.Add(wp);
				wp.BringToFront();
			}
		}

		// TODO WHY 3????
		private void insertToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Insert();
		}

		private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.Insert();
		}

		private void insertToolStripMenuItem2_Click(object sender, EventArgs e)
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
			if (editorsTabControl.SelectedTab.Name == "dungeonPage" || editorsTabControl.SelectedTab.Name == "overworldPage")
			{
				WindowPanel wp = new WindowPanel
				{
					Tag = "Palettes Editor",
					Location = Constants.Point_512_0,
					Size = new Size(paletteForm.Size.Width + 2, paletteForm.Size.Height + 26)
				};

				if (editorsTabControl.SelectedTab.Name == "dungeonPage")
				{
					wp.containerPanel.Controls.Add(paletteForm);
					customPanel3.Controls.Add(wp);
				}
				else
				{
					wp.containerPanel.Controls.Add(new PaletteEditor());
					Program.OverworldForm.splitContainer1.Panel2.Controls.Add(wp);
				}

				paletteForm.BringToFront();
				wp.BringToFront();

			}
		}

		// Export Palette to YY-CHR Palette Format
		/*            

        */

		private void DrawOnTab(object sender, DrawItemEventArgs e)
		{
			Graphics g = e.Graphics;
			Font font = (sender as TabControl).Font;
			SolidBrush b = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
			SolidBrush bs = new SolidBrush(Color.FromKnownColor(KnownColor.ControlLight));

			if (tpHotTracked == e.Index || e.State == DrawItemState.Selected)
			{
				g.FillRectangle(bs, e.Bounds);
				g.DrawString(tabControl2.TabPages[e.Index].Text, font, Brushes.Blue, new Rectangle(e.Bounds.X, e.Bounds.Y + 2, 64, 24));

				if (tpHotTrackedToClose == e.Index)
				{
					g.DrawImage(xTabButton, new Rectangle(e.Bounds.X + 30, e.Bounds.Y, 16, 16), 16, 0, 16, 16, GraphicsUnit.Pixel);
				}
				else
				{
					g.DrawImage(xTabButton, new Rectangle(e.Bounds.X + 30, e.Bounds.Y, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel);
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
					if (tabControl2.GetTabRect(i).Contains(e.Location))
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

		private void mapPicturebox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (e.Y >= 256 && e.Y <= 264)
				{
					return;
				}

				thumbnailBox.Visible = true;
				int yc = e.Y;
				if (e.Y > 256)
				{
					yc -= 8;
				}

				int x = (e.X / 16);
				int y = (yc / 16);
				int roomId = x + (y * 16);
				if (roomId > 295)
				{
					return;
				}

				thumbnailBox.Refresh();
			}
		}

		private void thumbnailBox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.Bilinear;
			e.Graphics.Clear(Color.Black);

			Program.RoomPreviewArtist.DrawSelfToImage(e.Graphics);
		}

		private void mapPicturebox_MouseUp(object sender, MouseEventArgs e)
		{
			thumbnailBox.Visible = false;
		}

		private void mapPicturebox_MouseMove(object sender, MouseEventArgs e)
		{
			if (maphoverCheckbox.Checked)
			{
				if (e.Y >= 256 && e.Y <= 264)
				{
					thumbnailBox.Visible = false;
					return;
				}

				thumbnailBox.Visible = true;
				int yc = 0;
				if (e.Y >= 256)
				{
					yc = 8;
				}

				int x = (e.X / 16);
				int y = ((e.Y - yc) / 16);
				int roomId = x + (y * 16);
				if (roomId >= Constants.NumberOfRooms)
				{
					thumbnailBox.Visible = false;
					return;
				}

				previewRoom = ZScreamer.ActiveScreamer.all_rooms[roomId];

				Program.RoomPreviewArtist.SetRoomAndDrawImmediately(previewRoom);
			}
		}

		private void mapPicturebox_MouseLeave(object sender, EventArgs e)
		{
			thumbnailBox.Visible = false;
		}

		private void openRightRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ZScreamer.ActiveUWScene.Room != null)
			{
				int id = ZScreamer.ActiveUWScene.Room.RoomID + 1;
				if (id < Constants.NumberOfRooms)
				{
					addRoomTab((ushort) id);
				}
				else
				{
					addRoomTab(0);
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
					addRoomTab((ushort) id);
				}
				else
				{
					addRoomTab(295);
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
					addRoomTab((ushort) id);
				}
				else
				{
					if (304 + id > 295)
					{
						addRoomTab(295);
					}
					else
					{
						addRoomTab((ushort) (304 + id));
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
					addRoomTab((ushort) id);
				}
				else
				{
					if (id > 304)
					{
						addRoomTab((ushort) (id - 304));
					}
					else
					{
						addRoomTab((ushort) (id - 288));
					}
				}
			}
		}

		private void DungeonMain_LocationChanged(object sender, EventArgs e)
		{
			Refresh();
		}

		// TODO :cry:
		private void editorsTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			//copyToolStripMenuItem
			if (editorsTabControl.SelectedTab.Name == "textPage")
			{
				Program.TextForm.BringToFront();
				Program.TextForm.Visible = true;
			}
			else
			{
				Program.TextForm.Visible = false;
			}

			if (editorsTabControl.SelectedTab.Name == "dungeonPage")
			{
				toolStrip1.Visible = true;
				panel1.Visible = true;
				toolboxPanel.Visible = true;
				customPanel3.Visible = true;
				headerGroupbox.Visible = true;
				tabControl2.Visible = true;

				roomToolStripMenuItem.Visible = true;
				dungeonViewToolStripMenuItem.Visible = true;
				naviguateToolStripMenuItem.Visible = true;

				toolStripSeparator6.Visible = true;
				moveFrontToolStripMenuItem.Visible = true;
				bringToBackToolStripMenuItem.Visible = true;

				toolStripSeparator9.Visible = true;
				selectAllRoomsForExportToolStripMenuItem.Visible = true;
				deselectedAllRoomsForExportToolStripMenuItem.Visible = true;

				toolStripSeparator7.Visible = true;
				increaseObjectSizeToolStripMenuItem.Visible = true;
				decreaseObjectSizeToolStripMenuItem.Visible = true;
			}
			else
			{
				toolStrip1.Visible = false;
				panel1.Visible = false;
				toolboxPanel.Visible = false;
				customPanel3.Visible = false;
				headerGroupbox.Visible = false;
				tabControl2.Visible = false;

				roomToolStripMenuItem.Visible = false;
				dungeonViewToolStripMenuItem.Visible = false;
				naviguateToolStripMenuItem.Visible = false;

				toolStripSeparator6.Visible = false;
				moveFrontToolStripMenuItem.Visible = false;
				bringToBackToolStripMenuItem.Visible = false;

				toolStripSeparator9.Visible = false;
				selectAllRoomsForExportToolStripMenuItem.Visible = false;
				deselectedAllRoomsForExportToolStripMenuItem.Visible = false;

				toolStripSeparator7.Visible = false;
				increaseObjectSizeToolStripMenuItem.Visible = false;
				decreaseObjectSizeToolStripMenuItem.Visible = false;
			}

			if (editorsTabControl.SelectedTab.Name == "objDesignerPage")
			{
				//objDesigner.BringToFront();
				//objDesigner.Visible = true;
			}
			else
			{
				objDesigner.Visible = false;
			}

			if (editorsTabControl.SelectedTab.Name == "overworldPage")
			{
				if (oweditor2 != null)
				{
					//if (oweditor2.WEWEWWE.isLoaded)
					if (true)
					{
						oweditor2.BringToFront();
						oweditor2.Visible = true;

						overworldViewToolStripMenuItem.Visible = true;
						overworldToolStripMenuItem.Visible = true;
						areaToolStripMenuItem.Visible = true;

						toolStripSeparator10.Visible = true;
						lockoverworldToolStripItem.Visible = true;
					}
					else
					{
						editorsTabControl.SelectedIndex = 0;
					}
				}
				else
				{
					if (ZScreamer.ActiveScreamer.OverworldManager.isLoaded)
					{
						Program.OverworldForm.BringToFront();
						Program.OverworldForm.Visible = true;

						overworldViewToolStripMenuItem.Visible = true;
						overworldToolStripMenuItem.Visible = true;
						areaToolStripMenuItem.Visible = true;

						toolStripSeparator10.Visible = true;
						lockoverworldToolStripItem.Visible = true;
					}
					else
					{
						editorsTabControl.SelectedIndex = 0;
					}
				}
			}
			else
			{
				Program.OverworldForm.Visible = false;

				overworldViewToolStripMenuItem.Visible = false;
				overworldToolStripMenuItem.Visible = false;
				areaToolStripMenuItem.Visible = false;

				toolStripSeparator10.Visible = false;
				lockoverworldToolStripItem.Visible = false;
			}

			if (editorsTabControl.SelectedTab.Name == "GfxEditorPage")
			{
				gfxEditor.BringToFront();
				gfxEditor.Visible = true;
			}
			else
			{
				gfxEditor.Visible = false;
			}

			if (editorsTabControl.SelectedTab.Name == "DungeonViewerPage")
			{
				dungeonViewer.BringToFront();
				dungeonViewer.Visible = true;
			}
			else
			{
				dungeonViewer.Visible = false;
			}

			if (editorsTabControl.SelectedTab.Name == "ScreenEditor")
			{
				screenEditor.BringToFront();
				screenEditor.Buildtileset();
				screenEditor.Visible = true;
			}
			else
			{
				screenEditor.Visible = false;
			}
		}

		private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new SaveSettings().ShowDialog();
		}

		public void UpdateFormForSelectedObject(IDungeonPlaceable o)
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

			if (o is DungeonSprite s)
			{
				spritesubtypeUpDown.Value = s.Subtype;
				spriteoverlordCheckbox.Checked = s.IsCurrentlyOverlord;
				comboBox1.SelectedIndex = s.KeyDrop;

				ZScreamer.ActiveUWScene.Refresh();
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

		private void favoriteCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			sortObject();
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
				ROM.DATA.CopyTo(ZScreamer.ActiveScreamer.ROM.TEMPDATA, 0);
				byte[] data = new byte[ROM.DATA.Length];
				ROM.DATA = new byte[ROM.DATA.Length];
				fs.Read(data, 0, (int) fs.Length);
				data.CopyTo(ZScreamer.ActiveScreamer.ROM.DATA, 0x00);
				oweditor2 = new OverworldEditor();
				oweditor2.InitOpen(this);
				overworldEditor.Visible = false;
				oweditor2.Dock = DockStyle.Fill;
				Controls.Remove(overworldEditor);
				Controls.Add(oweditor2);
				oweditor2.BringToFront();
				oweditor2.Visible = true;
				overworldEditor.splitContainer1.Panel2.AutoScroll = true;
				//ROM.TEMPDATA.CopyTo(ZScreamer.ActiveScreamer.ROM.DATA, 0x00);

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
					for (int y = 0; y < 32; y += 1)
					{
						for (int x = 0; x < 32; x += 1)
						{
							mapArrayData[p++] = (byte) (ZScreamer.ActiveScreamer.OverworldManager.allmapsTilesLW[x + (sx * 32), y + (sy * 32)] & 0xFF);
							mapArrayData[p++] = (byte) ((ZScreamer.ActiveScreamer.OverworldManager.allmapsTilesLW[x + (sx * 32), y + (sy * 32)] >> 8) & 0xFF);
							mapArrayData[p++] = (byte) (ZScreamer.ActiveScreamer.OverworldManager.allmapsTilesDW[x + (sx * 32), y + (sy * 32)] & 0xFF);
							mapArrayData[p++] = (byte) ((ZScreamer.ActiveScreamer.OverworldManager.allmapsTilesDW[x + (sx * 32), y + (sy * 32)] >> 8) & 0xFF);

							if (i < 32)
							{
								mapArrayData[p++] = (byte) (ZScreamer.ActiveScreamer.OverworldManager.allmapsTilesSP[x + (sx * 32), y + (sy * 32)] & 0xFF);
								mapArrayData[p++] = (byte) ((ZScreamer.ActiveScreamer.OverworldManager.allmapsTilesSP[x + (sx * 32), y + (sy * 32)] >> 8) & 0xFF);
							}
						}
					}

					sx++;
					if (sx >= 8)
					{
						sy++;
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
							ZScreamer.ActiveScreamer.OverworldManager.allmapsTilesLW[x + (sx * 32), y + (sy * 32)] = (ushort) ((mapArrayData[p + 1] << 8) + mapArrayData[p]);
							p += 2;

							ZScreamer.ActiveScreamer.OverworldManager.allmapsTilesDW[x + (sx * 32), y + (sy * 32)] = (ushort) ((mapArrayData[p + 1] << 8) + mapArrayData[p]);
							p += 2;

							if (i < 32)
							{
								ZScreamer.ActiveScreamer.OverworldManager.allmapsTilesSP[x + (sx * 32), y + (sy * 32)] = (ushort) ((mapArrayData[p + 1] << 8) + mapArrayData[p]);
								p += 2;
							}
						}
					}

					sx++;
					if (sx >= 8)
					{
						sy++;
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
					ulong v = ZScreamer.ActiveScreamer.OverworldManager.Tile16List.ListOf[i].getLongValue();

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

				ZScreamer.ActiveScreamer.OverworldManager.Tile16List.ListOf.Clear();
				for (int i = 0; i < Constants.NumberOfMap16; i++)
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

					ZScreamer.ActiveScreamer.OverworldManager.Tile16List.ListOf.Add(new Tile16(t0, t1, t2, t3));

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
					if (!tile8ids.Contains(ZScreamer.ActiveScreamer.OverworldManager.allmaps[44].tilesUsed[x + (4 * 32), y + (5 * 32)]))
					{
						tile8ids.Add(ZScreamer.ActiveScreamer.OverworldManager.allmaps[44].tilesUsed[x + (4 * 32), y + (5 * 32)]);
					}
					map16[x, y] = ZScreamer.ActiveScreamer.OverworldManager.allmaps[44].tilesUsed[x + (4 * 32), y + (5 * 32)];
				}
			}

			for (int i = 0; i < tile8ids.Count; i++)
			{

				//ZScreamer.ActiveScreamer.OverworldManager.Tile16List[tile8ids[i]].tile0.HFlip ^= true;
				//ZScreamer.ActiveScreamer.OverworldManager.Tile16List[tile8ids[i]].tile1.HFlip ^= true;
				//ZScreamer.ActiveScreamer.OverworldManager.Tile16List[tile8ids[i]].tile2.HFlip ^= true;
				//ZScreamer.ActiveScreamer.OverworldManager.Tile16List[tile8ids[i]].tile3.HFlip ^= true;
				//
				//ushort t0 = ZScreamer.ActiveScreamer.OverworldManager.Tile16List[i].tile0.ID;
				//ushort t2 = ZScreamer.ActiveScreamer.OverworldManager.Tile16List[i].tile2.ID;
				//
				//ZScreamer.ActiveScreamer.OverworldManager.Tile16List[i].tile0.ID = ZScreamer.ActiveScreamer.OverworldManager.Tile16List[i].tile1.ID;
				//ZScreamer.ActiveScreamer.OverworldManager.Tile16List[i].tile1.ID = t0;
				//ZScreamer.ActiveScreamer.OverworldManager.Tile16List[i].tile2.ID = ZScreamer.ActiveScreamer.OverworldManager.Tile16List[i].tile3.ID;
				//ZScreamer.ActiveScreamer.OverworldManager.Tile16List[i].tile3.ID = t2;

				for (int x = 0, mx = 31; x < 32; x++, mx--)
				{
					for (int y = 0; y < 32; y++)
					{
						ZScreamer.ActiveScreamer.OverworldManager.allmaps[44].tilesUsed[x + (4 * 32), y + (5 * 32)] = map16[mx, y];
					}
				}
			}

			// ZScreamer.ActiveScreamer.OverworldManager.allmaps[44].BuildMap();
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
				fs.Write(ZScreamer.ActiveScreamer.ROM.DataStream, 0, ZScreamer.ActiveScreamer.ROM.Length);
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
			string dotFormat = showRoomsInHexToolStripMenuItem.Checked ? "X3" : "D3";
			foreach (TabPage tp in tabControl2.TabPages)
			{
				tp.Text = (tp.Tag as DungeonRoom).RoomID.ToString(dotFormat);
			}
		}

		private void showMapIndexInHexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Program.OverworldForm.mapGroupbox.Text = "Selected Map - " +
				ZScreamer.ActiveOWScene.CurrentMapParent.ToString(showMapIndexInHexToolStripMenuItem.Checked ? "X2" : "D3")
				+ " Properties : ";
		}

		private void saveVRAMAsPngToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveGraphicsManager.currentgfx16Bitmap.Save("vram.png");
		}

		private void edit8x8palettebox_Paint(object sender, PaintEventArgs e)
		{
			ColorPalette cp = Program.RoomEditingArtist.Layer1Canvas.Palette;
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
			//	ZScreamer.ActiveScreamer.ROM.DATA2 = new byte[size];
			//	if ((fs.Length & Constants.ROMHeaderSize) == Constants.ROMHeaderSize)
			//	{
			//		size = (int) (fs.Length - Constants.ROMHeaderSize);
			//		byte[] tempRomData = new byte[fs.Length];
			//		fs.Read(tempRomData, 0, (int) fs.Length);
			//		Array.Copy(tempRomData, Constants.ROMHeaderSize, ZScreamer.ActiveScreamer.ROM.DATA2, 0, size);
			//	}
			//	else
			//	{
			//		fs.Read(ZScreamer.ActiveScreamer.ROM.DATA2, 0, (int) fs.Length);
			//	}
			//
			//	fs.Close();
			//
			//	ZScreamer.ActiveScreamer.ROM.TEMPDATA = new byte[Constants.ROMSize];
			//	for (int i = 0; i < Constants.ROMSize; i++)
			//	{
			//		ZScreamer.ActiveScreamer.ROM.TEMPDATA[i] = ZScreamer.ActiveScreamer.ROM.DATA[i];
			//		ZScreamer.ActiveScreamer.ROM.DATA[i] = ZScreamer.ActiveScreamer.ROM.DATA2[i];
			//	}
			//
			//	for (int i = 0; i < Constants.NumberOfRooms; i++)
			//	{
			//		DungeonsData.all_rooms_moved[i] = new Room(ZS, i);
			//	}
			//
			//	ZScreamer.ActiveScreamer.ROM.TEMPDATA = new byte[Constants.ROMSize];
			//	for (int i = 0; i < Constants.ROMSize; i++)
			//	{
			//		ZScreamer.ActiveScreamer.ROM.DATA2[i] = ZScreamer.ActiveScreamer.ROM.DATA[i];
			//		ZScreamer.ActiveScreamer.ROM.DATA[i] = ZScreamer.ActiveScreamer.ROM.TEMPDATA[i]; // Restore to original rom
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
			//	fs.Write(ZScreamer.ActiveScreamer.ROM.DATA2, 0, Constants.ROMSize);
			//
			//	fs.Close();
			//
			//	MessageBox.Show("Selected data successfully moved to selected ROM.\n" +
			//		"Please restart the application.");
			//}
		}

		private void showSpritesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			Program.OverworldForm.Refresh();
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
		// make a ThemeZScreamer.ActiveScreamer.Offsets.cs file?
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
				Program.OverworldForm.gridDisplay = 8;
			}
			else if (sender == x16ToolStripMenuItem1)
			{
				x16ToolStripMenuItem1.Checked = true;
				Program.OverworldForm.gridDisplay = 16;
			}
			else if (sender == x32ToolStripMenuItem1)
			{
				x32ToolStripMenuItem1.Checked = true;
				Program.OverworldForm.gridDisplay = 32;
			}
			else
			{
				noneToolStripMenuItem.Checked = true;
				Program.OverworldForm.gridDisplay = 0;
			}

			ZScreamer.ActiveOWScene.Refresh();
		}

		private void autodoorButton_Click_1(object sender, EventArgs e)
		{
			if (ZScreamer.ActiveUWScene.Room.AutoSortDoors())
			{
				UIText.GeneralWarning("The count of openable doors and shutter doors is too high and may result in weird behaviot");
			}

			ZScreamer.ActiveUWScene.Refresh();
		}

		// TODO magic points and merge identical functions
		private void DungeonMain_SizeChanged(object sender, EventArgs e)
		{
			if (x2zoom)
			{
				panel3.Location = new Point(1032, -1);
			}
			else
			{
				panel3.Location = new Point(520, -1);
			}
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
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveUWScene.clearCustomCollisionMap();
		}

		/// <summary>
		/// is triggered when the clear all overworld sprites phase 1 button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void clearPhase1OWSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld sprites for phase 1 (Rescue Zelda)"))
			{
				Program.OverworldForm.clearOverworldSprites(0);
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld sprites phase 2 button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void clearPhase2OWSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld sprites for phase 2 (Zelda rescued)"))
			{
				Program.OverworldForm.clearOverworldSprites(1);
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld sprites phase 3 button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void clearPhase3OWSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld sprites for phase 3 (Agahnim defeated)"))
			{
				Program.OverworldForm.clearOverworldSprites(2);
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld items button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void clearAllOWItemsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld items"))
			{
				Program.OverworldForm.clearOverworldItems();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld entrances button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void clearAllOWEntrancesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld entrances"))
			{
				Program.OverworldForm.clearOverworldEntrances();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld holes button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void clearAllOWHolesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("hole entrances"))
			{
				Program.OverworldForm.clearOverworldHoles();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld exits button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void clearAllOWExitsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld exits"))
			{
				Program.OverworldForm.clearOverworldExits();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld overlays button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void clearAllOverworldOverlaysToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletion("overworld overlays"))
			{
				Program.OverworldForm.clearOverworldOverlays();
			}
		}

		private void selectAllRoomsForExportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (ushort i = 0; i < Constants.NumberOfRooms; i++)
			{
				selectedMapPng.Add(i);
			}

			//loadRoomList(Constants.NumberOfRooms);
		}

		private void deselectedAllRoomsForExportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			selectedMapPng.Clear();
			//loadRoomList(Constants.NumberOfRooms);
		}

		/// <summary>
		/// is triggered when the clear all overworld sprites phase 1 button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void clearPhase1AreaSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("sprites for phase 1 (Rescue Zelda)"))
			{
				Program.OverworldForm.clearAreaSprites(0);
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld sprites phase 2 button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void clearPhase2AreaSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("sprites for phase 2 (Zelda rescued)"))
			{
				Program.OverworldForm.clearAreaSprites(1);
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld sprites phase 3 button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void clearPhase3AreaSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("sprites for phase 3 (Agahnim defeated)"))
			{
				Program.OverworldForm.clearAreaSprites(2);
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld items button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void clearAllAreaItemsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("secret items"))
			{
				Program.OverworldForm.clearAreaItems();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld entrances button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void clearAllAreaEntrancesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("entrances"))
			{
				Program.OverworldForm.clearAreaEntrances();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld holes button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void clearAllAreaHolesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("hole entrances"))
			{
				Program.OverworldForm.clearAreaHoles();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld exits button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void clearAllAreaExitsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("exits"))
			{
				Program.OverworldForm.clearAreaExits();
			}
		}

		/// <summary>
		/// is triggered when the clear all overworld overlays button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void clearAllAreaOverlaysToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ConfirmDeletionOWArea("overlay tiles"))
			{
				Program.OverworldForm.clearAreaOverlays();
			}
		}

		/// <summary>
		/// Gives a message box saying "You wanna delete <paramref name="w"/>?"
		/// </summary>
		/// <param name="w"></param>
		/// <returns>true if yes</returns>
		private bool ConfirmDeletion(string w)
		{
			return MessageBox.Show(
				$"You are about to delete all {w}.\nDo you wish to continue?",
				"Warning",
				MessageBoxButtons.YesNo) == DialogResult.Yes;
		}

		/// <summary>
		/// Gives a message box saying "You wanna delete <paramref name="w"/> from OW screen X?"
		/// </summary>
		/// <param name="w"></param>
		/// <returns>true if yes</returns>
		private bool ConfirmDeletionOWArea(string w)
		{
			return ConfirmDeletion($"{w} from OW screen {ZScreamer.ActiveOWScene.CurrentMapParent:X2}");
		}

		private void discordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(UIText.DISCORD);
		}

		private void RoomPropertyChanged(object sender, EventArgs e)
		{
			UpdateRoomInfo();
		}

		public void GetXYMouseBasedOnZoom(MouseEventArgs e, out int x, out int y)
		{
			if (x2zoom)
			{
				x = e.X / 2;
				y = e.Y / 2;
			}
			else
			{
				x = e.X;
				y = e.Y;
			}
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

		private void toolStripLabel1_Click(object sender, EventArgs e)
		{

		}
	}
}
