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
using ZeldaFullEditor.Gui.MainTabs;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

// Main 
namespace ZeldaFullEditor
{
	public partial class DungeonMain : Form
	{
		// Registers a hot key with Windows.
		[DllImport("user32.dll")]
		private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
		// Unregisters the hot key with Windows.
		[DllImport("user32.dll")]
		private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool LockWindowUpdate(IntPtr hWnd);

		// TODO : Move that to a data class

		// TODO : Move that?
		public byte[] door_index; //new byte[] { 0x00, 0x02, 0x04, 0x06, 0x08, 0x40, 0x1C, 0x26, 0x0C, 0x44, 0x18, 0x36, 0x38, 0x1E, 0x2E, 0x28, 0x46, 0x0E, 0x0A, 0x30, 0x12, 0x16, 0x32, 0x20, 0x14, 0x2A, 0x22, 0x10};

		public TextEditor textEditor = new TextEditor();
		public OverworldEditor overworldEditor = new OverworldEditor();
		Object_Designer objDesigner = new Object_Designer();
		public GfxImportExport gfxEditor;
		DungeonViewer dungeonViewer = new DungeonViewer();
		public string projectFilename = "";
		public bool projectLoaded = false;
		public bool anychange = false;
		public SceneUW activeScene;
		public List<Room> opened_rooms = new List<Room>();
		bool saved_changed = false;
		public TreeNode lastNode = null;
		RoomLayout layoutForm;
		List<short> selectedMapPng = new List<short>();
		public ChestPicker chestPicker = new ChestPicker();
		public bool settingEntrance = false;
		public int selectedLayer = -1;
		public Entrance selectedEntrance = null;
		PaletteEditor paletteForm;
		Bitmap xTabButton;
		public Room previewRoom = null;
		public ScreenEditor screenEditor = new ScreenEditor();
		public string loadFromExported = "";

		public List<Room_Object> listoftilesobjects = new List<Room_Object>();
		List<Sprite> listofspritesobjects = new List<Sprite>();
		List<Chest> listofchests = new List<Chest>();

		// Groups of options for the Scene
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

		VramViewer vramViewer = new VramViewer();
		public CGRamViewer cgramViewer = new CGRamViewer();
		public GfxGroupsForm gfxGroupsForm;

		int tpHotTracked = -1;
		int tpHotTrackedToClose = -1;
		int tpHotTrackedToCloseLast = -2;
		int lasttpHotTracked = -2;

		public int lastRoomID = -1;

		OverworldEditor oweditor2;

		ushort[,] lwmdata = new ushort[512, 512];
		ushort[,] dwmdata = new ushort[512, 512];

		byte[] keysDoors = new byte[] { 0x1C, 0x26, 0x1E, 0x2E, 0x28, 0x32, 0x30, 0x22 };
		byte[] shutterDoors = new byte[] { 0x44, 0x18, 0x36, 0x38, 0x48, 0x4A };

		public bool propertiesChangedFromForm = false;

		// TODO: save this in a config file and load the values into this array on startup
		public bool[] saveSettingsArr = new bool[]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true
		};

		// Constuctor 
		public DungeonMain()
		{
			InitializeComponent();
			this.tileTypeCombobox.Items.AddRange(Utils.CreateIndexedList(Constants.TileTypeNames));
			this.EntranceProperties_FloorSel.Items.AddRange(Constants.floors);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			door_index = DoorData.doors.Keys.ToArray();
			this.comboBox2.Items.AddRange(
			DoorData.doors.Values.ToArray());

			GFX.fontgfx16Ptr = Marshal.AllocHGlobal((256 * 256));

			GFX.currentfontgfx16Ptr = Marshal.AllocHGlobal(172 * 20000);

			GFX.mapblockset16 = Marshal.AllocHGlobal(1048576);

			GFX.scratchblockset16 = Marshal.AllocHGlobal(1048576);

			GFX.overworldMapPointer = Marshal.AllocHGlobal(0x40000);

			GFX.owactualMapPointer = Marshal.AllocHGlobal(0x40000);

			if (Settings.Default.favoriteObjects.Count < 0xFFF)
			{
				while (Settings.Default.favoriteObjects.Count < 0xFFF)
				{
					Settings.Default.favoriteObjects.Add("false");
				}
			}

			xTabButton = new Bitmap(Resources.xbutton);
			layoutForm = new RoomLayout(this);
			gfxEditor = new GfxImportExport(this);
			initialize_properties();
			GFX.initGfx();
			ROMStructure.loadDefaultProject();
			mapPicturebox.Image = new Bitmap(256, 304);
			thumbnailBox.Size = new Size(256, 256);

			refreshRecentsFiles();
			textEditor.Visible = false;
			overworldEditor.Visible = false;
			objDesigner.Visible = false;
			gfxEditor.Visible = false;
			dungeonViewer.Visible = false;
			screenEditor.Visible = false;

			objDesigner.Dock = DockStyle.Fill;
			overworldEditor.Dock = DockStyle.Fill;
			textEditor.Dock = DockStyle.Fill;
			gfxEditor.Dock = DockStyle.Fill;
			dungeonViewer.Dock = DockStyle.Fill;
			screenEditor.Dock = DockStyle.Fill;

			Controls.Add(overworldEditor);
			Controls.Add(textEditor);
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

		private void SceneUW_MouseWheel(object sender, MouseEventArgs e)
		{
			HandledMouseEventArgs ee = (HandledMouseEventArgs) e;
			ee.Handled = true;
		}

		// Need to stay here
		public void initialize_properties()
		{
			Background2[] bg2values = (Background2[]) Enum.GetValues(typeof(Background2));
			foreach (Background2 s in bg2values)
			{
				roomProperty_bg2.Items.Add(s.ToString());
			}

			CollisionKey[] collisionvalues = (CollisionKey[]) Enum.GetValues(typeof(CollisionKey));
			foreach (CollisionKey s in collisionvalues)
			{
				roomProperty_collision.Items.Add(s.ToString());
			}

			EffectKey[] effectvalues = (EffectKey[]) Enum.GetValues(typeof(EffectKey));
			foreach (EffectKey s in effectvalues)
			{
				roomProperty_effect.Items.Add(s.ToString());
			}

			TagKey[] tagvalues = (TagKey[]) Enum.GetValues(typeof(TagKey));
			foreach (TagKey s in tagvalues)
			{
				roomProperty_tag1.Items.Add(s.ToString());
				roomProperty_tag2.Items.Add(s.ToString());
			}
		}

		//Stopwatch sw = new Stopwatch();
		// TODO : Move that to the save class
		public void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Save Functions
			// Expand ROM to 2MB

			//sw.Reset();
			//sw.Start();
			foreach (Room r in opened_rooms)
			{
				if (r.has_changed)
				{
					foreach (TabPage tp in tabControl2.TabPages)
					{
						tp.Text = tp.Text.Trim('*');
					}

					DungeonsData.all_rooms[r.index] = (Room) r.Clone();
					r.has_changed = false;
					DungeonsData.all_rooms[r.index].has_changed = false;
				}
			}

			anychange = false;
			//tabControl2.Refresh();
			//sw.Stop();
			//Console.WriteLine("Saved all unsaved rooms - " + sw.ElapsedMilliseconds.ToString() + "ms");

			//sw.Reset();
			//sw.Start();
			byte[] romBackup = (byte[]) ROM.DATA.Clone();
			Save save = new Save(DungeonsData.all_rooms, this);
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

			// Probably a dumb hack, but this do-while makes everything execute exactly once
			// And allows us to break out on failure cleanly to terminate the routine
			bool badSave = true;
			do
			{
				if (saveSettingsArr[0] && save.saveallSprites())
				{
					UIText.CryAboutSaving("there are too many sprites");
					break;
				}
				if (saveSettingsArr[1] && save.saveallPots())
				{
					UIText.CryAboutSaving("there are too many pot items");
					break;
				}
				if (saveSettingsArr[2] && save.saveallChests())
				{
					UIText.CryAboutSaving("there are too many chest items");
					break;
				}
				if (saveSettingsArr[3] && save.saveAllObjects())
				{
					UIText.CryAboutSaving("there are too many tiles objects");
					break;
				}
				if (saveSettingsArr[4] && save.saveBlocks())
				{
					UIText.CryAboutSaving("there are too many pushable blocks");
					break;
				}
				if (saveSettingsArr[5] && save.saveTorches())
				{
					UIText.CryAboutSaving("there are too many torches");
					break;
				}
				if (saveSettingsArr[6] && save.saveAllPits())
				{
					UIText.CryAboutSaving("there are too many pits with damage");
					break;
				}
				if (saveSettingsArr[7] && save.saveRoomsHeaders())
				{
					//UIText.CryAboutSaving("there are too many chest items);
					//break;
				}
				if (saveSettingsArr[8] && save.saveEntrances(DungeonsData.entrances, DungeonsData.starting_entrances))
				{
					UIText.CryAboutSaving("something with entrances ?? no idea why LUL");
					break;
				}
				if (saveSettingsArr[9] && save.SaveOWSprites(overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld sprites out of range");
					break;
				}
				if (saveSettingsArr[10] && save.saveOWItems(overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld items out of range");
					break;
				}
				if (saveSettingsArr[11] && save.saveOWEntrances(overworldEditor.scene))
				{
					UIText.CryAboutSaving("??, no idea why LUL");
					break;
				}
				if (saveSettingsArr[12] && save.saveOWTransports(overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld transports out of range");
					break;
				}
				if (saveSettingsArr[13] && save.saveOWExits(overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld Exits or something IDK");
					break;
				}
				if (saveSettingsArr[14] && overworldEditor.scene.SaveTiles())
				{
					// No need for a message box here because its handeled within the SaveTiles() function itslef.
					break;
				}

				// 15

				if (saveSettingsArr[16] && save.saveMapProperties(overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld map properties ???");
					break;
				}

				// 17
				// 18
				// 19
				// 20
				// 21
				// 22

				if (saveSettingsArr[23] && GfxGroups.SaveGroupsToROM())
				{
					UIText.CryAboutSaving("problem saving GFX Groups");
					break;
				}
				if (saveSettingsArr[24] && Palettes.SavePalettesToROM(ROM.DATA))
				{
					UIText.CryAboutSaving("problem saving palettes");
					break;
				}
				if (saveSettingsArr[25] && save.saveAllText(textEditor))
				{
					UIText.CryAboutSaving("impossible to save text");
					break;
				}

				// 17

				if (saveSettingsArr[28] && save.saveCustomCollision())
				{
					UIText.CryAboutSaving("there was an error saving the custom collision rectangles");
					break;
				}
				if (saveSettingsArr[31] && save.saveMapOverlays(overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld map overlays ???");
					break;
				}
				if (saveSettingsArr[32] && save.saveOverworldMusics(overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld map tile types ???");
					break;
				}
				if (saveSettingsArr[33] && save.SaveTitleScreen())
				{
					UIText.CryAboutSaving("overworld title screen?");
					break;
				}
				if (saveSettingsArr[34] && save.SaveOverworldMiniMap())
				{
					UIText.CryAboutSaving("problem saving overworld Minimap?");
					break;
				}
				if (saveSettingsArr[35] && save.saveOverworldTilesType(overworldEditor.scene))
				{
					UIText.CryAboutSaving("problem saving overworld map tiles Types ???");
					break;
				}
				if (saveSettingsArr[36] && save.saveOverworldMaps(overworldEditor.scene))
				{
					UIText.CryAboutSaving("problem saving overworld maps");
					break;
				}
				if (saveSettingsArr[37] && save.SaveGravestones(overworldEditor.scene))
				{
					UIText.CryAboutSaving("problem saving gravestones");
					break;
				}
				if (saveSettingsArr[38] && save.SaveDungeonMaps())
				{
					UIText.CryAboutSaving("problem saving dungeon maps");
					break;
				}
				if (saveSettingsArr[39] && save.SaveTriforce())
				{
					UIText.CryAboutSaving("problem saving triforce");
					break;
				}
				if (saveSettingsArr[40] && save.saveOverworldMessagesIds(overworldEditor.scene))
				{
					UIText.CryAboutSaving("problem saving  overworld map tiles Types ???");
					break;
				}

				// If we made it here, everything was fine
				badSave = false;
			}
			while (false);

			if (badSave)
			{
				ROM.DATA = (byte[]) romBackup.Clone(); // Restore previous rom data to prevent corrupting anything
				return;
			}

			ROM.Write(0x5D4E, 0x00, true, "Fix sprite sheet 123 (should not be read compressed)"); // Fix for the sprite sheet 123
																								   //ROM.DATA[0x5D4E] = 0x00; 

			gfxEditor.SaveAllGfx();

			//sw.Stop();
			//Console.WriteLine("Saved Overworld- " + sw.ElapsedMilliseconds.ToString() + "ms");
			//Console.WriteLine("ROMDATA[" + (Constants.overworldMapPalette + 2).ToString("X6") + "]" + " : " + ROM.DATA[Constants.overworldMapPalette + 2]);
			//AsarCLR.Asar.init();
			//AsarCLR.Asar.patch("titlescreen.asm", ref ROM.DATA);
			//overworldEditor.overworld.SaveMap16Tiles();

			overworldEditor.saveScratchPad();

			anychange = false;
			saved_changed = false;

			//ROMStructure.saveProjectFile(version, projectFilename);
			ROM.SaveLogs();

			FileStream fs = new FileStream(projectFilename, FileMode.OpenOrCreate, FileAccess.Write);
			fs.Write(ROM.DATA, 0, ROM.DATA.Length);
			fs.Close();
		}

		// TODO: move more of the failure stuff here


		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog projectFile = new OpenFileDialog();
			projectFile.Filter = UIText.USROMType;
			projectFile.DefaultExt = UIText.ROMExtension;

			if (projectFile.ShowDialog() == DialogResult.OK)
			{
				projectFilename = projectFile.FileName;
				LoadProject(projectFile.FileName);
				openToolStripMenuItem.Enabled = false;
				openfileButton.Enabled = false;
				recentROMToolStripMenuItem.Enabled = false;
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

		public void LoadProject(string filename)
		{
			ROMStructure.loadDefaultProject();
			// TODO : Add Headered ROM

			FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
			int size = (int) fs.Length;
			if (fs.Length < 0x200000)
			{
				size = 0x200000;
			}

			ROM.DATA = new byte[size];
			if ((fs.Length & 0x200) == 0x200)
			{
				size = (int) (fs.Length - 0x200);
				byte[] tempRomData = new byte[fs.Length];
				fs.Read(tempRomData, 0, (int) fs.Length);
				Array.Copy(tempRomData, 0x200, ROM.DATA, 0, size);
			}
			else
			{
				fs.Read(ROM.DATA, 0, (int) fs.Length);
			}

			fs.Close();

			LoadPalettes();

			activeScene = new SceneUW(this);
			activeScene.Location = Constants.Point_0_0;
			activeScene.Size = new Size(512, 512);
			activeScene.MouseWheel += SceneUW_MouseWheel;

			if (loadFromExported != "")
			{
				loadFromExported = (Path.GetDirectoryName(projectFilename));
				Console.WriteLine(Path.GetDirectoryName(projectFilename));
			}

			initProject();

			this.Text = string.Format("{0} - {1}", UIText.APPNAME, filename);
		}

		// TODO : Move that to a data class
		public void LoadPalettes()
		{
			Palettes.CreateAllPalettes(ROM.DATA);
		}

		public unsafe void initProject()
		{
			tabControl1.Enabled = true;
			GfxGroups.LoadGfxGroups();
			GFX.CreateAllGfxData(ROM.DATA);

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				DungeonsData.all_rooms[i] = (new Room(i, loadFromExported)); // Create all rooms
				DungeonsData.undoRoom[i] = new List<Room>();
				DungeonsData.redoRoom[i] = new List<Room>();
			}

			editorsTabControl.Enabled = true;

			initEntrancesList();
			this.customPanel3.Controls.Add(activeScene);
			addRoomTab(260);

			projectLoaded = true;

			tabControl2_SelectedIndexChanged(tabControl2.TabPages[0], new EventArgs());
			enableProjectButtons();
			foreach (ToolStripMenuItem mi in menuStrip1.Items)
			{
				mi.Enabled = true;
			}

			roomHeaderPanel.Enabled = true;

			// Initialize the map draw
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

			Sprites_Names.loadFromFile();
			Room_Name.loadFromFile();
			ChestItems_Name.loadFromFile();
			ItemsNames.loadFromFile();

			initObjectsList();
			spritesView1.items.Clear();

			foreach (Sprite o in listofspritesobjects)
			{
				spritesView1.items.Add((o));
			}

			objectViewer1.items.Clear();
			foreach (Room_Object o in listoftilesobjects)
			{
				objectViewer1.items.Add((o));
			}

			selecteditemobjectCombobox.Items.Clear();

			for (int i = 0; i < ItemsNames.name.Length; i++)
			{
				selecteditemobjectCombobox.Items.Add(ItemsNames.name[i]);
			}

			/*
            string s = "";

            for (int i = 0; i < 0xF0; i++)
            {
                if (GFX.objects[i] != true)
                {
                    s +=  i.ToString("X3") + " - " + listoftilesobjects[i].name + "\r\n"; //Console.WriteLine();
                }
            }

            for (int i = 0xF80; i < 0xFFF; i++)
            {
                if (GFX.objects[i] != true)
                {
                    s += i.ToString("X3") + " - " + listoftilesobjects[(listoftilesobjects.Count - 0x7F) + (i-0xF80)].name + "\r\n";
                    //Console.WriteLine(i.ToString("X3"));
                }
            }

            File.WriteAllText("Unused.txt", s);
            */

			GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
			GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.palette);
			objectViewer1.updateSize();
			spritesView1.updateSize();

			activeScene.DrawRoom();
			activeScene.Refresh();

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
			gfxGroupsForm = new GfxGroupsForm(this);
			gfxGroupsForm.CreateTempGfx();
			gfxGroupsForm.Location = Constants.Point_0_0;

			paletteForm = new PaletteEditor(this);

			paletteForm.Location = Constants.Point_0_0;
			refreshRecentsFiles();
			overworldEditor.InitOpen(this);
			textEditor.InitializeOnOpen();
			screenEditor.Init();
			//InitDungeonViewer();
		}

		private void InitDungeonViewer()
		{
			activeScene.forPreview = true;
			Bitmap b = new Bitmap(8192, 10752);

			using (Graphics gb = Graphics.FromImage(b))
			{
				for (int i = 0; i < Constants.NumberOfRooms; i++)
				{
					activeScene.room = DungeonsData.all_rooms[i];
					activeScene.room.reloadGfx();
					GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
					GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.palette);
					activeScene.DrawRoom();

					activeScene.Refresh();

					gb.DrawImage(activeScene.tempBitmap, new Point((i % 16) * 512, (i / 16) * 512));
					//activeScene.DrawToBitmap(b, new Rectangle(cx * 512, cy * 512, 512, 512));
				}
			}

			dungeonViewer.pictureBox1.Image = b;
			activeScene.forPreview = false;
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
				DungeonsData.starting_entrances[i] = new Entrance((byte) i, true);
				string tname = "[" + i.ToString("X2") + "] -> ";
				foreach (DataRoom d in ROMStructure.dungeonsRoomList)
				{
					if (d.id == DungeonsData.starting_entrances[i].Room)
					{
						tname += "[" + d.id.ToString("X2") + "]" + d.name;
						break;
					}
				}

				TreeNode tn = new TreeNode(tname);
				tn.Tag = i;
				entrancetreeView.Nodes[1].Nodes.Add(tn);
			}

			for (int i = 0; i < 0x85; i++)
			{
				DungeonsData.entrances[i] = new Entrance((byte) i, false);
				string tname = "[" + i.ToString("X2") + "] -> ";
				foreach (DataRoom d in ROMStructure.dungeonsRoomList)
				{
					if (d.id == DungeonsData.entrances[i].Room)
					{
						tname += "[" + d.id.ToString("X2") + "]" + d.name;
						break;
					}
				}

				TreeNode tn = new TreeNode(tname);
				tn.Tag = i;

				entrancetreeView.Nodes[0].Nodes.Add(tn);
			}

			entrancetreeView.SelectedNode = entrancetreeView.Nodes[0].Nodes[0];
			selectedEntrance = DungeonsData.entrances[0];
		}

		public void enableProjectButtons()
		{
			allbgsButton.Enabled = true;
			bg3modeButton.Enabled = true;
			bg2modeButton.Enabled = true;
			bg1modeButton.Enabled = true;
			chestmodeButton.Enabled = true;
			saveButton.Enabled = true;
			doormodeButton.Enabled = true; // Door mode changed on bg
			blockmodeButton.Enabled = true;
			torchmodeButton.Enabled = true;
			spritemodeButton.Enabled = true;
			debugtestButton.Enabled = true;
			runtestButton.Enabled = true;
			potmodeButton.Enabled = true; // Can't change to sprite since sprites are using 16x16
			saveToolStripMenuItem.Enabled = true;
			saveasToolStripMenuItem.Enabled = true;
			warpmodeButton.Enabled = true;
			saveLayoutButton.Enabled = true;
			loadlayoutButton.Enabled = true;
			toolStripButton1.Enabled = true;
			searchButton.Enabled = true;
			collisionModeButton.Enabled = true;

			foreach (object ti in editToolStripMenuItem.DropDownItems)
			{
				if (ti is ToolStripDropDownItem)
				{
					(ti as ToolStripDropDownItem).Enabled = true;
				}
			}
		}

		/*
        public void clear_room()
        {
            if (activeScene.room != null)
            {
                activeScene.room.selectedObject.Clear();
            }
        }
        */

		/*
        public void save_room(int roomId)
        {
            DungeonsData.all_rooms[roomId] = (Room)activeScene.room.Clone();
        }
        */

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox1 aboutBox = new AboutBox1();
			aboutBox.ShowDialog();
		}

		public void setmodeAllScene(ObjectMode mode)
		{
			activeScene.selectedMode = mode;
		}

		public void updateScenesMode()
		{
			spritepropertyPanel.Visible = false;
			potitemobjectPanel.Visible = false;
			doorselectPanel.Visible = false;
			litCheckbox.Visible = false;
			collisionMapPanel.Visible = false;
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
				//objectsListbox.Enabled = true;
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
			else if (collisionModeButton.Checked)
			{
				setmodeAllScene(ObjectMode.CollisionMap);
				xScreenToolStripMenuItem.Checked = true;
				hideSpritesToolStripMenuItem_CheckStateChanged(null, null);
				tileTypeCombobox.SelectedIndex = 0;
				collisionMapPanel.Visible = true;
			}
		}

		public void update_modes_buttons(object sender, EventArgs e)
		{
			activeScene.selectedDragObject = null;
			activeScene.selectedDragSprite = null;

			for (int i = 8; i < 20; i++)
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
				activeScene.mouse_down = false;
				activeScene.deleteSelected();
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				overworldEditor.scene.mouse_down = false;
				overworldEditor.scene.deleteSelected();
			}
			else if (editorsTabControl.SelectedIndex == 3) // Text editor
			{
				textEditor.delete();
			}
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				activeScene.mouse_down = false;
				activeScene.selectAll();
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				overworldEditor.scene.mouse_down = false;
				overworldEditor.scene.selectAll();
			}
			else if (editorsTabControl.SelectedIndex == 3) // Text editor
			{
				textEditor.selectAll();
			}
		}

		private void cutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				activeScene.mouse_down = false;
				activeScene.cut();
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				overworldEditor.scene.mouse_down = false;
				overworldEditor.scene.cut();
			}
			else if (editorsTabControl.SelectedIndex == 3) // Text editor
			{
				textEditor.cut();
			}
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				activeScene.paste();
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				overworldEditor.scene.paste();
			}
			else if (editorsTabControl.SelectedIndex == 2) // gfx editor
			{
				gfxEditor.paste();
			}
			else if (editorsTabControl.SelectedIndex == 3) // Text editor
			{
				textEditor.paste();
			}
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				activeScene.mouse_down = false;
				activeScene.copy();
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				overworldEditor.scene.mouse_down = false;
				overworldEditor.scene.copy();
			}
			else if (editorsTabControl.SelectedIndex == 2) // gfx editor
			{
				gfxEditor.copy();
			}
			else if (editorsTabControl.SelectedIndex == 3) // Text editor
			{
				textEditor.copy();
			}
		}

		public void undoButton_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				//activeScene.Undo();
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				overworldEditor.scene.Undo();
			}
		}

		public void redoButton_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				//activeScene.Redo();
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				overworldEditor.scene.Redo();
			}
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				//activeScene.Undo();
			}
			else if (editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				overworldEditor.scene.Undo();
			}
			else if (editorsTabControl.SelectedIndex == 3) // Text editor
			{
				textEditor.undo();
			}
		}

		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				//activeScene.Redo();
			}
			else if (editorsTabControl.SelectedIndex == 1) //Ooverworld editor
			{
				overworldEditor.scene.Redo();
			}
		}

		private void showBG1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				activeScene.showLayer1 = showBG1ToolStripMenuItem.Checked;
				activeScene.DrawRoom();
				activeScene.Refresh();
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
			List<SaveObject> data = new List<SaveObject>();
			if (clipboard)
			{
				data = (List<SaveObject>) Clipboard.GetData("ObjectZ");
			}
			else
			{
				foreach (var o in activeScene.room.selectedObject)
				{
					if (selectedLayer >= 0)
					{
						data.Add(new SaveObject((Room_Object) o));
					}
					else if (spritemodeButton.Checked)
					{
						data.Add(new SaveObject((Sprite) o));
					}
					else if (potmodeButton.Checked)
					{
						data.Add(new SaveObject((PotItem) o));
					}
				}
			}

			if (data?.Count > 0)
			{
				// Name that layout
				string name = "Room_Object";
				if (data[0].type == typeof(Room_Object))
				{
					name = "Room_Object";
				}

				string f = Interaction.InputBox("Name of the new layout", "Name?", "Layout00");
				if (f != "")
				{
					BinaryWriter bw = new BinaryWriter(new FileStream(
						UIText.GetFileName(UIText.LayoutFolder, f),
						FileMode.OpenOrCreate,
						FileAccess.Write));
					bw.Write(name);
					foreach (SaveObject o in data)
					{
						o.saveToFile(bw);
					}

					bw.Close();
				}
			}
		}

		private void loadlayoutButton_Click(object sender, EventArgs e)
		{
			//scene.loadLayout();
			if (!Directory.Exists(UIText.LayoutFolder))
			{
				Directory.CreateDirectory(UIText.LayoutFolder);
			}

			if ((byte) activeScene.selectedMode > 3)
			{
				bg1modeButton.Checked = true;
				update_modes_buttons(bg1modeButton, new EventArgs());
				//scene.selectedMode = ObjectMode.Bg1mode;
			}

			layoutForm.scene.room = (Room) activeScene.room.Clone();
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
					o.x = (byte) (o.x - most_x);
					o.y = (byte) (o.y - most_y);
					activeScene.room.tilesObjects.Add(o);
					activeScene.room.selectedObject.Add(o);
				}

				activeScene.dragx = 0;
				activeScene.dragy = 0;
				activeScene.mouse_down = true;
				activeScene.need_refresh = true;
				if (!visibleEntranceGFX)
				{
					activeScene.room.reloadGfx(DungeonsData.entrances[Int32.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
				}
				else
				{
					activeScene.room.reloadGfx();
				}
			}
		}

		/// <summary>
		/// Sends an object to the front in the list when using one of the 3 "send to front" options
		/// </summary>
		private void SendSelectedToFront(object sender, EventArgs e)
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
				else if (activeScene.room.selectedObject[0] is Sprite)
				{
					foreach (Sprite s in activeScene.room.selectedObject)
					{
						for (int i = 0; i < activeScene.room.sprites.Count; i++)
						{
							if (s == activeScene.room.sprites[i])
							{
								activeScene.room.sprites.RemoveAt(i);
								activeScene.room.sprites.Add(s);

								break;
							}
						}
					}
				}

				activeScene.DrawRoom();
				activeScene.Refresh();
				activeScene.mouse_down = false;
			}
		}

		/// <summary>
		/// Sends an object to the back in the list when using one of the 3 "send to back" options
		/// </summary>
		public void SendSelectedToBack(object sender, EventArgs e)
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
								activeScene.room.tilesObjects.Insert(0, o);

								break;
							}
						}
					}
				}
				else if (activeScene.room.selectedObject[0] is Sprite)
				{
					foreach (Sprite s in activeScene.room.selectedObject)
					{
						for (int i = 0; i < activeScene.room.sprites.Count; i++)
						{
							if (s == activeScene.room.sprites[i])
							{
								activeScene.room.sprites.RemoveAt(i);
								activeScene.room.sprites.Insert(0, s);

								break;
							}
						}
					}
				}

				activeScene.DrawRoom();
				activeScene.Refresh();
				activeScene.mouse_down = false;
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

				activeScene.DrawRoom();
				activeScene.Refresh();
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

				activeScene.DrawRoom();
				activeScene.Refresh();
			}
		}

		private void zscreamForm_FormClosing_1(object sender, FormClosingEventArgs e)
		{
			if (projectLoaded)
			{
				//Properties.Settings.Default.ViewParameters;
				Settings.Default.spriteText = textSpriteToolStripMenuItem.Checked;
				Settings.Default.chestText = textChestItemToolStripMenuItem.Checked;
				Settings.Default.itemText = textPotItemToolStripMenuItem.Checked;
				Settings.Default.transparentBG = unselectedBGTransparentToolStripMenuItem.Checked;
				Settings.Default.rightToolbox = rightSideToolboxToolStripMenuItem.Checked;
				Settings.Default.spriteShow = hideSpritesToolStripMenuItem.Checked;
				Settings.Default.itemsShow = hideItemsToolStripMenuItem.Checked;
				Settings.Default.chestitemShow = hideChestItemsToolStripMenuItem.Checked;
				Settings.Default.dooridShow = showDoorIDsToolStripMenuItem.Checked;
				Settings.Default.chestidShow = showChestsIDsToolStripMenuItem.Checked;
				Settings.Default.disableentranceGfx = disableEntranceGFXToolStripMenuItem.Checked;
				Settings.Default.bg2maskShow = showBG2MaskOutlineToolStripMenuItem.Checked;
				Settings.Default.entranceCamera = entranceCameraToolStripMenuItem.Checked;
				Settings.Default.entrancePos = entrancePositionToolStripMenuItem.Checked;
				Settings.Default.Save();
			}

			if (anychange)
			{
				DungeonsData.all_rooms[activeScene.room.index] = activeScene.room;

				this.saved_changed = true;
			}

			if (saved_changed)
			{
				anychange = false;
				
				switch (UIText.WarnAboutSaving())
				{
					case DialogResult.Yes:
						saveToolStripMenuItem_Click(this, new EventArgs());
						break;

					case DialogResult.Cancel:
						e.Cancel = true;
						this.Activate();
						break;
				}
			}
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
			saveFile.Filter = UIText.SNESROMType;

			if (saveFile.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(saveFile.FileName, FileMode.OpenOrCreate, FileAccess.Write);
				fs.Write(ROM.DATA, 0, ROM.DATA.Length);
				fs.Close();
			}
		}

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
				en = DungeonsData.entrances[(int) e.Node.Tag];
				if (e.Node.Parent?.Name == "StartingEntranceNode")
				{
					en = DungeonsData.starting_entrances[(int) e.Node.Tag];
				}
			}

			//propertyGrid2.SelectedObject = entrances[(int)e.Node.Tag];
			entranceProperty_bg.Checked = false;

			EntranceProperties_RoomID.HexValue = en.Room;
			EntranceProperties_DungeonID.HexValue = en.Dungeon;
			EntranceProperties_Blockset.HexValue = en.Blockset;
			EntranceProperties_Music.HexValue = en.Music;


			EntranceProperties_PlayerX.HexValue = en.XPosition;
			EntranceProperties_PlayerY.HexValue = en.YPosition;
			EntranceProperties_CameraX.HexValue = en.CameraX;
			EntranceProperties_CameraY.HexValue = en.CameraY;
			EntranceProperties_CameraTriggerX.HexValue = en.CameraTriggerX;
			EntranceProperties_CameraTriggerY.HexValue = en.CameraTriggerY;


			EntranceProperties_FloorSel.SelectedIndex = Constants.FloorNumber.FindFloorIndex(en.Floor);

			EntranceProperties_Exit.HexValue = en.Exit;

			// Jared_Brian_: commented out because it is unused?
			/*
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
            */

			if ((en.Ladderbg & 0x10) == 0x10)
			{
				entranceProperty_bg.Checked = true;
			}

			if (activeScene.room != null)
			{
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
			}

			entranceProperty_vscroll.Checked = false;
			entranceProperty_hscroll.Checked = false;
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

			int p = (en.Exit & 0x7FFF) >> 1;
			doorxTextbox.Text = (p % 64).ToString("X2");
			dooryTextbox.Text = (p >> 6).ToString("X2");

			if ((en.Scrolling & 0x20) == 0x20)
			{
				entranceProperty_hscroll.Checked = true;
			}

			if ((en.Scrolling & 0x02) == 0x02)
			{
				entranceProperty_vscroll.Checked = true;
			}

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
			//objectViewer1.BeginUpdate();
			objectViewer1.items.Clear();

			if (favoriteCheckbox.Checked)
			{
				// Sorting sort;
				string searchText = searchTextbox.Text.ToLower();

				// ListView1
				objectViewer1.items.AddRange(listoftilesobjects
					.Where(x => x != null)
					.Where(x => x.name.ToLower().Contains(searchText))
					.Where(x => Settings.Default.favoriteObjects[x.id] == "true")
					.OrderBy(x => x.id)
					.Select(x => x) // ?
					.ToArray());

				panel1.VerticalScroll.Value = 0;
				objectViewer1.Refresh();
			}
			else
			{
				// Sorting sort;
				Sorting sortsizing = Sorting.All;
				string searchText = searchTextbox.Text.ToLower();

				// ListView1
				objectViewer1.items.AddRange(listoftilesobjects
					.Where(x => x != null)
					.Where(x => (x.name.ToLower().Contains(searchText)))
					.OrderBy(x => x.id)
					.Select(x => x) // ?
					.ToArray());
				objectViewer1.updateSize();
				panel1.VerticalScroll.Value = 0;
				objectViewer1.Refresh();
			}
		}

		public void sortSprite()
		{
			spritesView1.items.Clear();
			string searchText = searchspriteTextbox.Text.ToLower();

			spritesView1.items.AddRange(listofspritesobjects
				.Where(x => x != null)
				.Where(x => (x.name.ToLower().Contains(searchText)))
				.OrderBy(x => x.id)
				.Select(x => x) // ?
				.ToArray());

			customPanel1.VerticalScroll.Value = 0;

			if (searchText == "")
			{
				spritesView1.items.Clear();
				foreach (Sprite o in listofspritesobjects)
				{
					spritesView1.items.Add((o));
				}
			}

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
			// Added refresh here so that the grid will appear when the checkbox is clicked.
			activeScene.Refresh();
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

				(activeScene.room.selectedObject[0] as Sprite).keyDrop = (byte) comboBox1.SelectedIndex;
				activeScene.DrawRoom();
				activeScene.Refresh();
			}
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
					if (activeScene.room.selectedObject[0] is PotItem oo)
					{
						if (selecteditemobjectCombobox.SelectedIndex > 0x16)
						{
							oo.id = (byte) (0x80 + ((selecteditemobjectCombobox.SelectedIndex - 0x17) * 2));
						}
						else
						{
							oo.id = (byte) (selecteditemobjectCombobox.SelectedIndex);
						}

						//scene.need_refresh = true;
					}

					activeScene.DrawRoom();
					activeScene.Refresh();
				}
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

			if (alreadyFound)
			{
				// Display message error room already opened
				//MessageBox.Show("That room is already opened !");
				foreach (TabPage tp in tabControl2.TabPages)
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
				Room r = (Room) DungeonsData.all_rooms[roomId].Clone();

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
				activeScene.room = r;

				//string tn = r.index.ToString("D3");
				//if (showRoomsInHexToolStripMenuItem.Checked)
				//{
				string tn = r.index.ToString("X3");
				//}

				TabPage tp = new TabPage(tn);
				tp.Tag = r;
				tabControl2.TabPages.Add(tp);
				//objectsListbox.ClearSelected();
				tabControl2.SelectedTab = tp;

				if (!visibleEntranceGFX)
				{
					activeScene.room.reloadGfx(DungeonsData.entrances[int.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
				}
				else
				{
					activeScene.room.reloadGfx();
				}

				GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
				GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.palette);
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

			cgramViewer.Refresh();

			activeScene.updateRoomInfos(this);
		}

		private void rightSideToolboxToolStripMenuItem_Click(object sender, EventArgs e)
		{
			splitContainer3.Panel1.Controls.Clear();
			splitContainer3.Panel2.Controls.Clear();
			if (rightSideToolboxToolStripMenuItem.Checked)
			{
				//toolboxPanel.Dock = DockStyle.Right;
				//splitter1.Dock = DockStyle.Right;
				splitContainer3.Panel2.Controls.Add(panel2);
				splitContainer3.Panel1.Controls.Add(entrancetreeView);
			}
			else
			{
				splitContainer3.Panel1.Controls.Add(panel2);
				splitContainer3.Panel2.Controls.Add(entrancetreeView);
				//toolboxPanel.Dock = DockStyle.Left;
				//splitter1.Dock = DockStyle.Left;
			}
		}

		private void entrancetreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Tag != null)
			{
				if (e.Node.Parent == entrancetreeView.Nodes[0])
				{
					addRoomTab(DungeonsData.entrances[(int) e.Node.Tag].Room);
				}
				else
				{
					addRoomTab(DungeonsData.starting_entrances[(int) e.Node.Tag].Room);
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
			short roomId = (short) (x + (y * 16));

			if (ModifierKeys == Keys.Control)
			{
				// Check if map is already in
				short alreadyIn = -1;
				foreach (short s in selectedMapPng)
				{
					// If it was already in delete it
					if (s == roomId)
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

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Doors
			if (comboBox2.SelectedIndex != -1)
			{
				if (activeScene.room.selectedObject.Count == 1)
				{
					if (activeScene.room.selectedObject[0] is Room_Object o)
					{
						if (o.options == ObjectOption.Door)
						{
							(o as object_door).door_type = door_index[comboBox2.SelectedIndex];
							(o as object_door).updateId();
							activeScene.room.has_changed = true;
							activeScene.DrawRoom();
							activeScene.Refresh();
						}
					}
				}
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
			byte[] data = new byte[ROM.DATA.Length];
			ROM.DATA.CopyTo(data, 0);
			saveToolStripMenuItem_Click(sender, e);
			AsarCLR.Asar.init();

			if (File.Exists(Path.GetDirectoryName(projectFilename) + "\\Main.asm"))
			{
				AsarCLR.Asar.patch(Path.GetDirectoryName(projectFilename) + "\\Main.asm", ref data);
			}

			foreach (AsarCLR.Asarerror error in AsarCLR.Asar.geterrors())
			{
				Console.WriteLine(error.Fullerrdata.ToString());
			}

			data[(Constants.startingentrance_room + 1)] = (byte) ((selectedEntrance.Room >> 8) & 0xFF);
			data[Constants.startingentrance_room] = (byte) (selectedEntrance.Room & 0xFF);

			data[(Constants.startingentrance_yposition + 1)] = (byte) ((selectedEntrance.YPosition >> 8) & 0xFF);
			data[Constants.startingentrance_yposition] = (byte) (selectedEntrance.YPosition & 0xFF);

			data[(Constants.startingentrance_xposition + 1)] = (byte) ((selectedEntrance.XPosition >> 8) & 0xFF);
			data[Constants.startingentrance_xposition] = (byte) (selectedEntrance.XPosition & 0xFF);

			data[(Constants.startingentrance_camerax + 1)] = (byte) ((selectedEntrance.CameraX >> 8) & 0xFF);
			data[Constants.startingentrance_camerax] = (byte) (selectedEntrance.CameraX & 0xFF);

			data[(Constants.startingentrance_cameray + 1)] = (byte) ((selectedEntrance.CameraY >> 8) & 0xFF);
			data[Constants.startingentrance_cameray] = (byte) (selectedEntrance.CameraY & 0xFF);

			data[(Constants.startingentrance_cameraxtrigger + 1)] = (byte) ((selectedEntrance.CameraTriggerX >> 8) & 0xFF);
			data[Constants.startingentrance_cameraxtrigger] = (byte) (selectedEntrance.CameraTriggerX & 0xFF);

			data[(Constants.startingentrance_cameraytrigger) + 1] = (byte) ((selectedEntrance.CameraTriggerY >> 8) & 0xFF);
			data[Constants.startingentrance_cameraytrigger] = (byte) (selectedEntrance.CameraTriggerY & 0xFF);

			data[(Constants.startingentrance_exit + 1)] = (byte) ((selectedEntrance.Exit >> 8) & 0xFF);
			data[Constants.startingentrance_exit] = (byte) (selectedEntrance.Exit & 0xFF);

			data[Constants.startingentrance_blockset] = (byte) (selectedEntrance.Blockset & 0xFF);
			data[Constants.startingentrance_music] = (byte) (selectedEntrance.Music & 0xFF);
			data[Constants.startingentrance_dungeon] = (byte) (selectedEntrance.Dungeon & 0xFF);
			//data[Constants.startingentrance_door] = (byte)(selectedEntrance.Door & 0xFF);
			data[Constants.startingentrance_floor] = (byte) (selectedEntrance.Floor & 0xFF);
			data[Constants.startingentrance_ladderbg] = (byte) (selectedEntrance.Ladderbg & 0xFF);
			data[Constants.startingentrance_scrolling] = (byte) (selectedEntrance.Scrolling & 0xFF);
			data[Constants.startingentrance_scrollquadrant] = (byte) (selectedEntrance.Scrollquadrant & 0xFF);
			data[(Constants.startingentrance_scrolledge + 0)] = selectedEntrance.cameraBoundaryQN; // 8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
			data[(Constants.startingentrance_scrolledge + 1)] = selectedEntrance.cameraBoundaryFN;
			data[(Constants.startingentrance_scrolledge + 2)] = selectedEntrance.cameraBoundaryQS;
			data[(Constants.startingentrance_scrolledge + 3)] = selectedEntrance.cameraBoundaryFS;
			data[(Constants.startingentrance_scrolledge + 4)] = selectedEntrance.cameraBoundaryQW;
			data[(Constants.startingentrance_scrolledge + 5)] = selectedEntrance.cameraBoundaryFW;
			data[(Constants.startingentrance_scrolledge + 6)] = selectedEntrance.cameraBoundaryQE;
			data[(Constants.startingentrance_scrolledge + 7)] = selectedEntrance.cameraBoundaryFE;

			FileStream fs = new FileStream(UIText.TestROM, FileMode.CreateNew, FileAccess.Write);
			fs.Write(data, 0, data.Length);
			fs.Close();
			Process p = Process.Start(UIText.TestROM);
		}

		// TODO going away with projects (or being changed drastically)
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

		public void UpdateUIForRoom(Room room, bool prevent = true)
		{
			propertiesChangedFromForm = prevent;

			roomProperty_bg2.SelectedIndex = (int) room.bg2;
			roomProperty_tag1.SelectedIndex = (int) room.tag1;
			roomProperty_tag2.SelectedIndex = (int) room.tag2;
			roomProperty_effect.SelectedIndex = (int) room.effect;
			roomProperty_collision.SelectedIndex = (int) room.collision;

			roomProperty_pit.Checked = room.damagepit;
			roomProperty_sortsprite.Checked = room.sortsprites;

			RoomProperty_Blockset.HexValue = room.blockset;
			RoomProperty_SpriteSet.HexValue = room.spriteset;
			RoomProperty_Floor1.HexValue = room.floor1;
			RoomProperty_Floor2.HexValue = room.floor2;
			RoomProperty_MessageID.HexValue = room.messageid;
			RoomProperty_Layout.HexValue = room.layout;
			RoomProperty_Palette.HexValue = room.palette;

			RoomProperty_DestinationPit.HexValue = room.holewarp;
			RoomProperty_DestinationStair1.HexValue = room.staircase1;
			RoomProperty_DestinationStair2.HexValue = room.staircase2;
			RoomProperty_DestinationStair3.HexValue = room.staircase3;
			RoomProperty_DestinationStair4.HexValue = room.staircase4;

			bg2checkbox1.Checked = room.holewarp_plane == 2;
			bg2checkbox2.Checked = room.staircase1Plane == 2;
			bg2checkbox3.Checked = room.staircase2Plane == 2;
			bg2checkbox4.Checked = room.staircase3Plane == 2;
			bg2checkbox5.Checked = room.staircase4Plane == 2;

			propertiesChangedFromForm = false;
		}

		public void updateRoomInfo()
		{
			if (!propertiesChangedFromForm && activeScene.room != null)
			{
				activeScene.room.bg2 = (Background2) roomProperty_bg2.SelectedIndex;
				activeScene.room.tag1 = (TagKey) roomProperty_tag1.SelectedIndex;
				activeScene.room.tag2 = (TagKey) roomProperty_tag2.SelectedIndex;
				activeScene.room.effect = (EffectKey) roomProperty_effect.SelectedIndex;
				activeScene.room.collision = (CollisionKey) roomProperty_collision.SelectedIndex;


				activeScene.room.blockset = (byte) RoomProperty_Blockset.HexValue;
				activeScene.room.floor1 = (byte) RoomProperty_Floor1.HexValue;
				activeScene.room.floor2 = (byte) RoomProperty_Floor2.HexValue;
				activeScene.room.layout = (byte) RoomProperty_Layout.HexValue;

				activeScene.room.messageid = (short) RoomProperty_MessageID.HexValue;
				activeScene.room.palette = (byte) RoomProperty_Palette.HexValue;

				activeScene.room.holewarp = (byte) RoomProperty_DestinationPit.HexValue;
				activeScene.room.staircase1 = (byte) RoomProperty_DestinationStair1.HexValue;
				activeScene.room.staircase2 = (byte) RoomProperty_DestinationStair2.HexValue;
				activeScene.room.staircase3 = (byte) RoomProperty_DestinationStair3.HexValue;
				activeScene.room.staircase4 = (byte) RoomProperty_DestinationStair4.HexValue;

				activeScene.room.holewarp_plane = (byte) (bg2checkbox1.Checked ? 2 : 0);
				activeScene.room.staircase1Plane = (byte) (bg2checkbox2.Checked ? 2 : 0);
				activeScene.room.staircase2Plane = (byte) (bg2checkbox3.Checked ? 2 : 0);
				activeScene.room.staircase3Plane = (byte) (bg2checkbox4.Checked ? 2 : 0);
				activeScene.room.staircase4Plane = (byte) (bg2checkbox5.Checked ? 2 : 0);

				activeScene.room.damagepit = roomProperty_pit.Checked;
				activeScene.room.sortsprites = roomProperty_sortsprite.Checked;

				activeScene.room.spriteset = (byte) RoomProperty_SpriteSet.HexValue;

				if (!visibleEntranceGFX)
				{
					activeScene.room.reloadGfx(DungeonsData.entrances[int.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
				}
				else
				{
					activeScene.room.reloadGfx();
				}

				/*
                undoRoom[activeScene.room.index].Add((Room)activeScene.room.Clone());
                redoRoom[activeScene.room.index].Clear();
                */

				GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
				GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.palette);
				activeScene.SetPalettesBlack();
				activeScene.DrawRoom();
				activeScene.Refresh();
				activeScene.room.has_changed = true;
				checkAnyChanges();
			}
		}

		public void updateEntranceInfos()
		{
			if (!propertiesChangedFromForm)
			{
				selectedEntrance.Blockset = (byte) EntranceProperties_Blockset.HexValue;
				selectedEntrance.Room = (short) EntranceProperties_RoomID.HexValue;

				if (EntranceProperties_FloorSel.SelectedIndex >= 0)
				{
					selectedEntrance.Floor = (EntranceProperties_FloorSel.SelectedItem as Constants.FloorNumber).ByteValue;
				}

				selectedEntrance.Dungeon = (byte) EntranceProperties_DungeonID.HexValue;
				selectedEntrance.Music = (byte) EntranceProperties_Music.HexValue;

				selectedEntrance.Exit = (byte) EntranceProperties_Exit.HexValue;

				selectedEntrance.Ladderbg = (byte) ((entranceProperty_bg.Checked) ? 0x10 : 0x00);

				selectedEntrance.cameraBoundaryQN = (byte) EntranceProperty_BoundaryQN.HexValue;
				selectedEntrance.cameraBoundaryFN = (byte) EntranceProperty_BoundaryFN.HexValue;
				selectedEntrance.cameraBoundaryQS = (byte) EntranceProperty_BoundaryQS.HexValue;
				selectedEntrance.cameraBoundaryFS = (byte) EntranceProperty_BoundaryFS.HexValue;
				selectedEntrance.cameraBoundaryQW = (byte) EntranceProperty_BoundaryQW.HexValue;
				selectedEntrance.cameraBoundaryFW = (byte) EntranceProperty_BoundaryFW.HexValue;
				selectedEntrance.cameraBoundaryQE = (byte) EntranceProperty_BoundaryQE.HexValue;
				selectedEntrance.cameraBoundaryFE = (byte) EntranceProperty_BoundaryFE.HexValue;

				selectedEntrance.XPosition = (short) EntranceProperties_PlayerX.HexValue;
				selectedEntrance.YPosition = (short) EntranceProperties_PlayerY.HexValue;
				selectedEntrance.CameraX = (short) EntranceProperties_CameraX.HexValue;
				selectedEntrance.CameraY = (short) EntranceProperties_CameraY.HexValue;
				selectedEntrance.CameraTriggerX = (short) EntranceProperties_CameraTriggerX.HexValue;
				selectedEntrance.CameraTriggerY = (short) EntranceProperties_CameraTriggerY.HexValue;

				//Console.WriteLine("Pos X: " + EntranceProperties_PlayerX.HexValue.ToString() + " Pos Y: " + EntranceProperties_PlayerY.HexValue.ToString());
				//Console.WriteLine("Camera X: " + EntranceProperties_CameraX.HexValue.ToString() + " Camera Y: " + EntranceProperties_CameraY.HexValue.ToString());
				//Console.WriteLine("Camera trigger X: " + EntranceProperties_CameraTriggerX.HexValue.ToString() + " Camera trigger Y: " + EntranceProperties_CameraTriggerY.HexValue.ToString());

				if (int.TryParse(doorxTextbox.Text, NumberStyles.HexNumber, null, out int r))
				{
					if (int.TryParse(dooryTextbox.Text, NumberStyles.HexNumber, null, out int rr))
					{
						selectedEntrance.Exit = (short) (((rr << 6) + (r & 0x3F)) << 1);
					}
					else
					{
						selectedEntrance.Exit = 0;
					}
				}
				else
				{
					selectedEntrance.Exit = 0;
				}

				byte b = 0;
				if (entranceProperty_hscroll.Checked)
				{
					b |= 0x20;
				}
				if (entranceProperty_vscroll.Checked)
				{
					b |= 0x02;
				}

				if (entranceProperty_quadbr.Checked) // Bottom right
				{
					selectedEntrance.Scrollquadrant = 0x12;
				}
				else if (entranceProperty_quadbl.Checked) // Bottom left
				{
					selectedEntrance.Scrollquadrant = 0x02;
				}
				else if (entranceProperty_quadtl.Checked) // Top left
				{
					selectedEntrance.Scrollquadrant = 0x00;
				}
				else if (entranceProperty_quadtr.Checked) // Top right
				{
					selectedEntrance.Scrollquadrant = 0x10;
				}

				//if (entranceProperty_quadbl)

				selectedEntrance.Scrolling = b;

				GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
				GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.palette);
				activeScene.SetPalettesBlack();

				if (!visibleEntranceGFX)
				{
					activeScene.room.reloadGfx(DungeonsData.entrances[int.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
				}
				else
				{
					activeScene.room.reloadGfx();
				}

				activeScene.DrawRoom();
				activeScene.Refresh();
				activeScene.room.has_changed = true;

				anychange = true;
			}
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

		// TODO copy
		private void CloseTab(int i)
		{
			if ((tabControl2.TabPages[i].Tag as Room).has_changed)
			{

				switch (UIText.WarnAboutSaving(UIText.RoomWarning))
				{
					case DialogResult.Yes:
						DungeonsData.all_rooms[(tabControl2.TabPages[i].Tag as Room).index] = (Room) (tabControl2.TabPages[i].Tag as Room).Clone();
						closeRoom((tabControl2.TabPages[i].Tag as Room).index);
						this.tabControl2.TabPages.RemoveAt(i);

						// TODO this needs to be made a function
						if (tabControl2.TabPages.Count == 0)
						{
							activeScene.Clear();
							tabControl2.Visible = false;
							activeScene.Refresh();
						}
						break;

					case DialogResult.No:
						closeRoom((tabControl2.TabPages[i].Tag as Room).index);
						this.tabControl2.TabPages.RemoveAt(i);

						if (tabControl2.TabPages.Count == 0)
						{
							activeScene.Clear();
							tabControl2.Visible = false;
							activeScene.Refresh();
						}
						break;
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
				activeScene.room = (tabControl2.TabPages[tabControl2.SelectedIndex].Tag as Room);
				activeScene.updateRoomInfos(this);

				if (DungeonsData.undoRoom[activeScene.room.index].Count > 0)
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

				if (DungeonsData.redoRoom[activeScene.room.index].Count > 0)
				{
					redoButton.Enabled = true;
					redoToolStripMenuItem.Enabled = true;
				}
				else
				{
					redoButton.Enabled = false;
					redoToolStripMenuItem.Enabled = false;
				}

				if (!visibleEntranceGFX)
				{
					activeScene.room.reloadGfx(DungeonsData.entrances[int.Parse(entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
				}
				else
				{
					activeScene.room.reloadGfx();
				}

				GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
				GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.palette);
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

		public void initObjectsList()
		{
			int index = 0;
			for (int i = 0; i < 0xF8; i++) // Type 1 objects 
			{
				Room_Object o = activeScene.room.addObject((short) i, 0, 0, 0, 0);
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

			for (int i = 0x100; i < 0x140; i++) // Type 2 objects 
			{
				Room_Object o = activeScene.room.addObject((short) i, 0, 0, 0, 0);
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

			for (int i = 0xF80; i < 0xFFF; i++) // Type 3 objects 
			{
				Room_Object o = activeScene.room.addObject((short) i, 0, 0, 0, 0);
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
				Sprite s = new Sprite(activeScene.room, (byte) i, 0, 0, 0, 0);
				s.preview = true;
				listofspritesobjects.Add(s);
			}

			for (int i = 1; i < 0x1B; i++)
			{
				Sprite s = new Sprite(activeScene.room, (byte) i, 0, 0, 7, 0);
				s.preview = true;
				listofspritesobjects.Add(s);
			}

			//sortObject();
		}

		private void objectViewer1_SelectedIndexChanged(object sender, EventArgs e)
		{
			activeScene.selectedDragObject = new dataObject(objectViewer1.selectedObject.id, objectViewer1.selectedObject.name);
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

		// merge identical events
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

		private void spritesView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			activeScene.selectedDragSprite = new dataObject(spritesView1.selectedObject.id, spritesView1.selectedObject.name, spritesView1.selectedObject.subtype);
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
			Room savedRoom = activeScene.room;
			activeScene.forPreview = true;

			if (selectedMapPng.Count > 0)
			{
				Bitmap b = new Bitmap(8192, 10752);

				using (Graphics gb = Graphics.FromImage(b))
				{
					foreach (short s in selectedMapPng)
					{
						if (s < DungeonsData.all_rooms.Length && DungeonsData.all_rooms[s] != null)
						{
							int cy = (s / 16);
							int cx = s - (cy * 16);
							if (cx < lowerX) { lowerX = cx; }
							if (cy < lowerY) { lowerY = cy; }
							if (cx > higherX) { higherX = cx; }
							if (cy > higherY) { higherY = cy; }

							activeScene.room = DungeonsData.all_rooms[s];
							activeScene.room.reloadGfx();
							GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
							GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.palette);
							activeScene.DrawRoom();

							activeScene.Refresh();

							gb.DrawImage(activeScene.tempBitmap, new Point(cx * 512, cy * 512));
							//activeScene.DrawToBitmap(b, new Rectangle(cx * 512, cy * 512, 512, 512));
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
				b = null;
				nb.Dispose();
				nb = null;
			}
			else
			{
				Bitmap b = new Bitmap(512, 512);
				activeScene.DrawToBitmap(b, Constants.Rect_0_0_512_512);
				b.Save("singlemap.png");
			}

			activeScene.forPreview = false;
			activeScene.room = savedRoom;
			activeScene.room.reloadGfx();
			GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
			GFX.loadedSprPalettes = GFX.LoadSpritesPalette(activeScene.room.palette);
			activeScene.DrawRoom();
			activeScene.Refresh();
		}

		private void litCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (activeScene.updating_info && activeScene.room.selectedObject[0] is Room_Object robj)
			{
				robj.lit = litCheckbox.Checked;
			}
		}

		// TODO move to constants
		private void patchNotesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/Zarby89/ZScreamDungeon/blob/master/ZeldaFullEditor/PatchNotes.txt");
		}

		private void spritesubtypeUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (!activeScene.updating_info)
			{
				if (activeScene.room.selectedObject.Count != 0 && activeScene.room.selectedObject[0] is Sprite spr)
				{
					spr.subtype = (byte) spritesubtypeUpDown.Value;
				}

				Console.WriteLine("WTF?!?!?");
			}
		}

		private void gotoRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GotoRoom gotoRoom = new GotoRoom();
			if (gotoRoom.ShowDialog() == DialogResult.OK)
			{
				addRoomTab((short) gotoRoom.SelectedRoom);
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
			int yoff;
			e.Graphics.Clear(Color.Black);
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				yoff = (i >= 256) ? 8 : 0;

				if (DungeonsData.all_rooms[i].tilesObjects.Count > 0)
				{
					e.Graphics.FillRectangle(new SolidBrush(GFX.LoadDungeonPalette(DungeonsData.all_rooms[i].palette)[4, 2]), new Rectangle(xd * 16, (yd * 16) + yoff, 16, 16));

					foreach (short s in selectedMapPng)
					{
						if (s == i)
						{
							e.Graphics.DrawRectangle(Constants.AquaPen2, new Rectangle((xd * 16), (yd * 16) + yoff, 16, 16));
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

			for (int i = 0; i < 16; i++)
			{
				e.Graphics.DrawLine(Pens.White, 0, i * 16, 256, i * 16);
				e.Graphics.DrawLine(Pens.White, i * 16, 0, i * 16, 256);

				e.Graphics.DrawLine(Pens.White, i * 16, 264, i * 16, 312);
			}

			for (int i = 0; i < 3; i++)
			{
				e.Graphics.DrawLine(Pens.White, 0, 264 + (i * 16), 256, 264 + (i * 16));
			}

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				yoff = (i >= 256) ? 8 : 0;

				foreach (TabPage tp in tabControl2.TabPages)
				{
					if ((tp.Tag as Room).index == (short) i)
					{
						e.Graphics.DrawRectangle(
								new Pen((tabControl2.SelectedTab == tp) ? Color.YellowGreen : Color.DarkGreen, 2),
								new Rectangle((i % 16) * 16, ((i / 16) * 16) + yoff, 16, 16));
					}
				}
			}
		}

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
				activeScene.Size = Constants.Size1024x1024;
				panel3.Location = new Point(1032, -1);
			}
			else
			{
				activeScene.Size = Constants.Size512x512;
				panel3.Location = new Point(520, -1);
			}

			activeScene.Refresh();
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
			foreach (Room_Object o in activeScene.room.tilesObjects)
			{
				if (o.options == ObjectOption.Door)
				{
					if (o is object_door d)
					{
						Console.WriteLine("n:" + d.name + ", door dir:" + d.door_dir + ", door pos:" + d.door_pos + ", door type:" + d.door_type);
					}
				}
				else
				{
					Console.WriteLine("n:" + o.name + ", w:" + o.width + ", h:" + o.height + ", L:" + o.layer);
				}
			}
		}

		// TODO DISGUSTING, these "Contains" should instead become properties of the object itself
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
				addRoomTab((short) gotoRoom.SelectedRoom);
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
			if (MessageBox.Show("Are you sure you want to clear every room's data?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				foreach (Room r in DungeonsData.all_rooms)
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

		private void exportAsASMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog sf = new SaveFileDialog())
			{
				sf.Filter = UIText.ExportedRoomDataType;
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
			vramViewer = new VramViewer();
			WindowPanel wp = new WindowPanel();
			wp.Location = Constants.Point_512_0;
			wp.containerPanel.Controls.Add(vramViewer);
			wp.Tag = "VRAM Viewer";
			wp.Size = new Size(vramViewer.Size.Width + 2, vramViewer.Size.Height + 26);
			customPanel3.Controls.Add(wp);
			wp.BringToFront();
		}

		private void showBG2MaskOutlineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			activeScene.showBG2Outline = showBG2MaskOutlineToolStripMenuItem.Checked;
			activeScene.Refresh();
		}

		private void entranceCameraToolStripMenuItem_Click(object sender, EventArgs e)
		{
			activeScene.Refresh();
		}

		private void entrancePositionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			activeScene.Refresh();
		}

		// TODO delete when projects
		private void loadNamesFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Filter = "Default Names .txt|*.txt";
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					Sprites_Names.loadFromFile(ofd.FileName);
					Room_Name.loadFromFile(ofd.FileName);
					ChestItems_Name.loadFromFile(ofd.FileName);
					ItemsNames.loadFromFile(ofd.FileName);
					selecteditemobjectCombobox.Items.Clear();

					for (int i = 0; i < ItemsNames.name.Length; i++)
					{
						selecteditemobjectCombobox.Items.Add(ItemsNames.name[i]);
					}
				}
			}
		}

		// TODO simplify and stuff, etc
		private void cGramViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			cgramViewer = new CGRamViewer();
			WindowPanel wp = new WindowPanel();
			wp.Tag = "CGRAM Viewer - Right click to export palettes";
			wp.Location = Constants.Point_512_0;
			wp.containerPanel.Controls.Add(cgramViewer);
			wp.Size = new Size(cgramViewer.Size.Width + 2, cgramViewer.Size.Height + 26);
			customPanel3.Controls.Add(wp);
			wp.BringToFront();
		}

		private void gfxGroupsetsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedTab.Name == "dungeonPage")
			{
				WindowPanel wp = new WindowPanel();
				wp.Tag = "Gfx Groupset Editor";
				wp.Location = Constants.Point_512_0;
				wp.containerPanel.Controls.Add(gfxGroupsForm);
				wp.Size = new Size(gfxGroupsForm.Size.Width + 2, gfxGroupsForm.Size.Height + 26);
				customPanel3.Controls.Add(wp);
				wp.BringToFront();
			}
			else if (editorsTabControl.SelectedTab.Name == "overworldPage")
			{
				WindowPanel wp = new WindowPanel();
				wp.Tag = "GFX Groups Editor";
				wp.Location = Constants.Point_512_0;
				wp.containerPanel.Controls.Add(new GfxGroupsForm(this));
				wp.Size = new Size(gfxGroupsForm.Size.Width + 2, gfxGroupsForm.Size.Height + 26);
				overworldEditor.splitContainer1.Panel2.Controls.Add(wp);
				wp.BringToFront();
			}
		}

		private void insertToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			activeScene.mouse_down = false;
			activeScene.insertNew();
		}

		private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			activeScene.mouse_down = false;
			activeScene.insertNew();
		}

		private void insertToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			activeScene.mouse_down = false;
			activeScene.insertNew();
		}

		// This is called when the delete option in the chest item editor option is selected.
		private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			activeScene.mouse_down = false;

			if (activeScene.selectedMode == ObjectMode.Chestmode)
			{
				activeScene.deleteChestItem();
			}
			else if (activeScene.selectedMode == ObjectMode.CollisionMap)
			{
				activeScene.deleteCollisionMapTile();
			}
		}

		private void palettesEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editorsTabControl.SelectedTab.Name == "dungeonPage" || editorsTabControl.SelectedTab.Name == "overworldPage")
			{
				WindowPanel wp = new WindowPanel();
				wp.Tag = "Palettes Editor";
				wp.Location = Constants.Point_512_0;
				wp.Size = new Size(paletteForm.Size.Width + 2, paletteForm.Size.Height + 26);

				if (editorsTabControl.SelectedTab.Name == "dungeonPage")
				{
					wp.containerPanel.Controls.Add(paletteForm);
					customPanel3.Controls.Add(wp);
				}
				else
				{
					wp.containerPanel.Controls.Add(new PaletteEditor(this));
					overworldEditor.splitContainer1.Panel2.Controls.Add(wp);
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
					Rectangle r = tabControl2.GetTabRect(i);
					if (r.Contains(e.Location))
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

				previewRoom = DungeonsData.all_rooms[roomId];
				previewRoom.reloadGfx();
				GFX.loadedPalettes = GFX.LoadDungeonPalette(previewRoom.palette);
				DrawRoom();
				thumbnailBox.Refresh();

				if (activeScene.room != null)
				{
					GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
					activeScene.room.reloadGfx();
					activeScene.DrawRoom();
				}
			}
		}

		public unsafe void ClearBgGfx()
		{
			byte* bg1data = (byte*) GFX.roomBg1Ptr.ToPointer();
			byte* bg2data = (byte*) GFX.roomBg2Ptr.ToPointer();

			for (int i = 0; i < 512 * 512; i++)
			{
				bg1data[i] = 0;
				bg2data[i] = 0;
			}
		}

		public unsafe void DrawRoom()
		{
			if (previewRoom == null)
			{
				return;
			}

			//Tile t = new Tile(0, false, false, 0, 0);
			//t.Draw(0, 0);
			ClearBgGfx(); // Technically not required

			previewRoom.DrawFloor1();

			if (previewRoom.bg2 != Background2.Off)
			{
				SetPalettesTransparent();
				previewRoom.DrawFloor2();
			}
			else
			{
				SetPalettesBlack();

			}

			previewRoom.reloadLayout();
			foreach (Room_Object o in previewRoom.tilesLayoutObjects)
			{
				o.Draw();

			}
			// Draw object on bitmap

			foreach (Room_Object o in previewRoom.tilesObjects)
			{
				// TODO can these ifs be merged?
				if (o.layer != 2)
				{
					o.Draw();
				}
				else if (o.options == ObjectOption.Door)
				{
					o.Draw();
				}
			}
			foreach (Room_Object o in previewRoom.tilesObjects)
			{
				// Draw doors here since they'll all be put on bg3 anyways
				if (o.layer == 2)
				{
					o.Draw();
				}
			}

			GFX.DrawBG1();
			GFX.DrawBG2();
		}

		public void SetPalettesTransparent()
		{
			int pindex = 0;
			ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
			for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = GFX.loadedPalettes[x, y];
				}
			}

			for (int y = 0; y < GFX.loadedSprPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < GFX.loadedSprPalettes.GetLength(0); x++)
				{
					if (pindex < 256)
					{
						palettes.Entries[pindex++] = GFX.loadedSprPalettes[x, y];
					}
				}
			}

			for (int i = 0; i < 16 * 16; i += 16)
			{
				palettes.Entries[i] = Color.Transparent;
				palettes.Entries[i + 8] = Color.Transparent;
			}

			GFX.roomBg1Bitmap.Palette = palettes;
			GFX.roomBg2Bitmap.Palette = palettes;
			GFX.roomBgLayoutBitmap.Palette = palettes;
		}

		public void SetPalettesBlack()
		{
			int pindex = 0;
			ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
			for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = GFX.loadedPalettes[x, y];
				}
			}

			for (int i = 0; i < 16 * 16; i += 16)
			{
				palettes.Entries[i] = Color.Black;
				palettes.Entries[i + 8] = Color.Black;
			}

			GFX.roomBg1Bitmap.Palette = palettes;
			GFX.roomBg2Bitmap.Palette = palettes;
			GFX.roomBgLayoutBitmap.Palette = palettes;
		}

		private void thumbnailBox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.Bilinear;
			e.Graphics.Clear(Color.Black);
			if (previewRoom.bg2 != Background2.Translucent || previewRoom.bg2 != Background2.Transparent ||
				previewRoom.bg2 != Background2.OnTop || previewRoom.bg2 != Background2.Off)
			{
				e.Graphics.DrawImage(GFX.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			}

			//e.Graphics.DrawImage(GFX.roomBgLayoutBitmap,0,0);
			e.Graphics.DrawImage(GFX.roomBg1Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);

			if (previewRoom.bg2 == Background2.Translucent || previewRoom.bg2 == Background2.Transparent)
			{
				float[][] matrixItems ={
				   new float[] {1f, 0, 0, 0, 0},
				   new float[] {0, 1f, 0, 0, 0},
				   new float[] {0, 0, 1f, 0, 0},
				   new float[] {0, 0, 0, 0.5f, 0},
				   new float[] {0, 0, 0, 0, 1}
				};

				ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

				// Create an ImageAttributes object and set its color matrix.
				ImageAttributes imageAtt = new ImageAttributes();
				imageAtt.SetColorMatrix(
				   colorMatrix,
				   ColorMatrixFlag.Default,
				   ColorAdjustType.Bitmap
				);

				//GFX.roomBg2Bitmap.MakeTransparent(Color.Black);
				e.Graphics.DrawImage(GFX.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
			}
			else if (previewRoom.bg2 == Background2.OnTop)
			{
				e.Graphics.DrawImage(GFX.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			}

			activeScene.drawText(e.Graphics, 0, 0, "ROOM: " + previewRoom.index.ToString());
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

				if (lastRoomID != roomId)
				{
					previewRoom = DungeonsData.all_rooms[roomId];
					previewRoom.reloadGfx();
					GFX.loadedPalettes = GFX.LoadDungeonPalette(previewRoom.palette);
					DrawRoom();
					thumbnailBox.Refresh();

					if (activeScene.room != null)
					{
						GFX.loadedPalettes = GFX.LoadDungeonPalette(activeScene.room.palette);
						activeScene.room.reloadGfx();
						activeScene.DrawRoom();
					}
				}

				lastRoomID = roomId;
			}
		}

		private void mapPicturebox_MouseLeave(object sender, EventArgs e)
		{
			thumbnailBox.Visible = false;
		}

		private void openRightRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (activeScene.room != null)
			{
				int id = activeScene.room.index + 1;
				if (id < Constants.NumberOfRooms)
				{
					addRoomTab((short) id);
				}
				else
				{
					addRoomTab(0);
				}
			}
		}

		private void openLeftRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (activeScene.room != null)
			{
				int id = activeScene.room.index - 1;
				if (id >= 0)
				{
					addRoomTab((short) id);
				}
				else
				{
					addRoomTab(295);
				}
			}
		}

		private void openUpRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (activeScene.room != null)
			{
				int id = (activeScene.room.index - 16);
				if (id >= 0)
				{
					addRoomTab((short) id);
				}
				else
				{
					if (304 + id > 295)
					{
						addRoomTab(295);
					}
					else
					{
						addRoomTab((short) (304 + id));
					}
				}
			}
		}

		private void openDownRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (activeScene.room != null)
			{
				int id = activeScene.room.index + 16;
				if (id < Constants.NumberOfRooms)
				{
					addRoomTab((short) id);
				}
				else
				{
					if (id > 304)
					{
						addRoomTab((short) (id - 304));
					}
					else
					{
						addRoomTab((short) (id - 288));
					}
				}
			}
		}

		private void DungeonMain_LocationChanged(object sender, EventArgs e)
		{
			this.Refresh();
		}

		// TODO :cry:
		private void editorsTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			//copyToolStripMenuItem
			if (editorsTabControl.SelectedTab.Name == "textPage")
			{
				textEditor.BringToFront();
				textEditor.Visible = true;
			}
			else
			{
				textEditor.Visible = false;
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
					if (oweditor2.overworld.isLoaded)
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
					if (overworldEditor.overworld.isLoaded)
					{
						overworldEditor.BringToFront();
						overworldEditor.Visible = true;

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
				overworldEditor.Visible = false;

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
				GFX.UpdatePalette(screenEditor.darkWorld);
				screenEditor.BringToFront();
				screenEditor.Buildtileset();
				screenEditor.updateGFXGroup();
				screenEditor.Visible = true;
			}
			else
			{
				screenEditor.Visible = false;
			}
		}

		private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveSettings saveSettings = new SaveSettings(this);
			saveSettings.ShowDialog();
		}

		public enum Direction
		{
			gauche = 0x01,
			droit = 0x02,
			haut = 0x04,
			bas = 0x08
		};

		private void searchButton_Click(object sender, EventArgs e)
		{
			SearchForm sf = new SearchForm(this);
			sf.ShowDialog();
		}

		private void openDungeonTabToolStripMenuItem_Click(object sender, EventArgs e)
		{
			editorsTabControl.SelectTab(0);
		}

		private void openOverwolrdTabToolStripMenuItem_Click(object sender, EventArgs e)
		{
			editorsTabControl.SelectTab(1);
		}

		private void openGfxTabToolStripMenuItem_Click(object sender, EventArgs e)
		{
			editorsTabControl.SelectTab(2);
		}

		private void exportAllRoomsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//int[] doorsoffset = new int[Constants.NumberOfRooms];
			//StringBuilder sb = new StringBuilder();
			//sb.Append("lorom\r\n");
			SaveFileDialog sf = new SaveFileDialog();
			sf.Filter = UIText.ExportedRoomDataType;

			if (sf.ShowDialog() == DialogResult.OK)
			{
				string path = Path.GetDirectoryName(sf.FileName);
				Directory.CreateDirectory(path + "//ExportedRooms");
				for (int i = 0; i < Constants.NumberOfRooms; i++)
				{
					// TODO system specific path separators
					byte[] roomBytes = DungeonsData.all_rooms[i].getTilesBytes();
					using (FileStream fs = new FileStream(path + "//ExportedRooms//room" + i.ToString("X3") + ".zrd", FileMode.OpenOrCreate, FileAccess.Write))
					{
						fs.Write(roomBytes, 0, roomBytes.Length);
						fs.Close();
					}
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
			Constants.Init_Jp();
			OpenFileDialog projectFile = new OpenFileDialog();
			projectFile.Filter = UIText.JPROMType;
			projectFile.DefaultExt = UIText.ROMExtension;

			if (projectFile.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(projectFile.FileName, FileMode.Open, FileAccess.Read);
				ROM.TEMPDATA = new byte[ROM.DATA.Length];
				ROM.DATA.CopyTo(ROM.TEMPDATA, 0);
				byte[] data = new byte[ROM.DATA.Length];
				ROM.DATA = new byte[ROM.DATA.Length];
				fs.Read(data, 0, (int) fs.Length);
				data.CopyTo(ROM.DATA, 0x00);
				oweditor2 = new OverworldEditor();
				oweditor2.InitOpen(this);
				overworldEditor.Visible = false;
				oweditor2.Dock = DockStyle.Fill;
				Controls.Remove(overworldEditor);
				Controls.Add(oweditor2);
				oweditor2.BringToFront();
				oweditor2.Visible = true;
				overworldEditor.splitContainer1.Panel2.AutoScroll = true;
				//ROM.TEMPDATA.CopyTo(ROM.DATA, 0x00);

				fs.Close();
			}
		}

		private void exportMapJPdoNotUseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int selectedMap = oweditor2.scene.selectedMap;
			if (selectedMap >= 64)
			{
				selectedMap -= 64;
			}

			Console.WriteLine("Exporting map : " + overworldEditor.scene.selectedMap);
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
		}

		private void captureMapJPdoNotUseToolStripMenuItem_Click(object sender, EventArgs e)
		{
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
		}

		private void exportSpritesAsBinaryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			byte[] sprites_buffer = new byte[0x40];
			int pos = 1;
			sprites_buffer[0] = 0x00;

			foreach (Sprite spr in DungeonsData.all_rooms[activeScene.room.index].sprites) //3bytes
			{
				sprites_buffer[pos++] = (byte) ((spr.layer << 7) + ((spr.subtype & 0x18) << 2) + spr.y);
				sprites_buffer[pos++] = (byte) (((spr.subtype & 0x07) << 5) + spr.x);
				sprites_buffer[pos++] = (spr.id);
			}

			sprites_buffer[pos] = 0xFF;
			using (SaveFileDialog ofd = new SaveFileDialog())
			{
				ofd.Filter = UIText.ExportedSpriteDataType;
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
					fs.Write(sprites_buffer, 0, pos);
					fs.Close();
				}
			}
		}

		private void exportAllMapsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int sx = 0;
			int sy = 0;
			int p = 0;

			byte[] mapArrayData = new byte[0x50000];
			using (SaveFileDialog sfd = new SaveFileDialog())
			{
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
								mapArrayData[p++] = (byte) (overworldEditor.overworld.allmapsTilesLW[x + (sx * 32), y + (sy * 32)] & 0xFF);
								mapArrayData[p++] = (byte) ((overworldEditor.overworld.allmapsTilesLW[x + (sx * 32), y + (sy * 32)] >> 8) & 0xFF);
								mapArrayData[p++] = (byte) (overworldEditor.overworld.allmapsTilesDW[x + (sx * 32), y + (sy * 32)] & 0xFF);
								mapArrayData[p++] = (byte) ((overworldEditor.overworld.allmapsTilesDW[x + (sx * 32), y + (sy * 32)] >> 8) & 0xFF);

								if (i < 32)
								{
									mapArrayData[p++] = (byte) (overworldEditor.overworld.allmapsTilesSP[x + (sx * 32), y + (sy * 32)] & 0xFF);
									mapArrayData[p++] = (byte) ((overworldEditor.overworld.allmapsTilesSP[x + (sx * 32), y + (sy * 32)] >> 8) & 0xFF);
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
		}

		private void importAllMapsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int sx = 0;
			int sy = 0;
			int p = 0;

			byte[] mapArrayData1 = new byte[0x50000];
			using (OpenFileDialog sfd = new OpenFileDialog())
			{
				sfd.Filter = UIText.ExportedOWMapDataType;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.Open, FileAccess.Read);
					fileStreamMap.Read(mapArrayData1, 0, (int)fileStreamMap.Length);
					fileStreamMap.Close();

					for (int i = 0; i < 64; i++)
					{
						for (int y = 0; y < 32; y += 1)
						{
							for (int x = 0; x < 32; x += 1)
							{
								overworldEditor.overworld.allmapsTilesLW[x + (sx * 32), y + (sy * 32)] = (ushort) ((mapArrayData1[p + 1] << 8) + mapArrayData1[p]);
								p += 2;
								overworldEditor.overworld.allmapsTilesDW[x + (sx * 32), y + (sy * 32)] = (ushort) ((mapArrayData1[p + 1] << 8) + mapArrayData1[p]);
								p += 2;

								if (i < 32)
								{
									overworldEditor.overworld.allmapsTilesSP[x + (sx * 32), y + (sy * 32)] = (ushort) ((mapArrayData1[p + 1] << 8) + mapArrayData1[p]);
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
		}

		private void exportAllTilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int p = 0;
			byte[] mapArrayData = new byte[0x8000]; // Real amount: 0x7540
			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = UIText.ExportedTileDataType;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);

					for (int i = 0; i < 3752; i++) // 3600
					{
						ulong v = overworldEditor.overworld.tiles16[i].getLongValue();

						for (int j = 0; j < 8; j++)
						{
							mapArrayData[p++] = (byte) (v & 0xFF);
							v >>= 8;
						}
					}

					fileStreamMap.Write(mapArrayData, 0, mapArrayData.Length);
					fileStreamMap.Close();
				}
			}
		}

		private void importAllTilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int p = 0;
			byte[] mapArrayData = new byte[0x8000]; // Real amount: 0x7540
			using (OpenFileDialog sfd = new OpenFileDialog())
			{
				sfd.Filter = UIText.ExportedTileDataType;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.Open, FileAccess.Read);
					fileStreamMap.Read(mapArrayData, 0, mapArrayData.Length);

					overworldEditor.overworld.tiles16.Clear();
					for (int i = 0; i < Constants.NumberOfMap16; i++)
					{

						// Tile 0
						ulong t0 = (ulong) (
							(mapArrayData[p + 1] << 8) |
							(mapArrayData[p + 0])
						);

						// Tile 1
						ulong t1 = (ulong)
						(
							(mapArrayData[p + 3] << 8) |
							(mapArrayData[p + 2])
						);

						// Tile 2
						ulong t2 = (ulong)
						(
							(mapArrayData[p + 5] << 8) |
							(mapArrayData[p + 4])
						);

						// Tile 3
						ulong t3 = (ulong)
						(
							(mapArrayData[p + 7] << 8) |
							(mapArrayData[p + 6])
						);

						ulong v1 = t3 << 16 | t2;
						ulong v2 = t1 << 16 | t0;
						ulong v = v1 << 32 | v2;
						overworldEditor.overworld.tiles16.Add(new Tile16(v));

						p += 8;
					}

					fileStreamMap.Close();
				}
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
					if (!tile8ids.Contains(overworldEditor.overworld.allmaps[44].tilesUsed[x + (4 * 32), y + (5 * 32)]))
					{
						tile8ids.Add(overworldEditor.overworld.allmaps[44].tilesUsed[x + (4 * 32), y + (5 * 32)]);
					}
					map16[x, y] = overworldEditor.overworld.allmaps[44].tilesUsed[x + (4 * 32), y + (5 * 32)];
				}
			}

			for (int i = 0; i < tile8ids.Count; i++)
			{

				overworldEditor.overworld.tiles16[tile8ids[i]].tile0.HS ^= 1;
				overworldEditor.overworld.tiles16[tile8ids[i]].tile1.HS ^= 1;
				overworldEditor.overworld.tiles16[tile8ids[i]].tile2.HS ^= 1;
				overworldEditor.overworld.tiles16[tile8ids[i]].tile3.HS ^= 1;

				ushort t0 = overworldEditor.overworld.tiles16[i].tile0.id;
				ushort t2 = overworldEditor.overworld.tiles16[i].tile2.id;

				overworldEditor.overworld.tiles16[i].tile0.id = overworldEditor.overworld.tiles16[i].tile1.id;
				overworldEditor.overworld.tiles16[i].tile1.id = t0;
				overworldEditor.overworld.tiles16[i].tile2.id = overworldEditor.overworld.tiles16[i].tile3.id;
				overworldEditor.overworld.tiles16[i].tile3.id = t2;

				for (int x = 0, mx = 31; x < 32; x++, mx--)
				{
					for (int y = 0; y < 32; y++)
					{
						overworldEditor.overworld.allmaps[44].tilesUsed[x + (4 * 32), y + (5 * 32)] = map16[mx, y];
					}
				}
			}

			// overworldEditor.overworld.allmaps[44].BuildMap();
		}

		// TODO magic string
		private void exportRoomDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			activeScene.room.CloneToFile("TestRoomData.dat");
		}

		private void importRoomDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var ms = new FileStream("TestRoomData.dat", FileMode.Open, FileAccess.Read))
			{
				var formatter = new BinaryFormatter();
				Room r = (Room) formatter.Deserialize(ms);
				activeScene.room = r;
				Room rtc = null;

				foreach (Room ro in opened_rooms)
				{
					if (ro.index == activeScene.room.index)
					{
						rtc = ro;
					}
				}

				if (rtc != null)
				{
					rtc = r;
				}

				// TODO should this be rtc?
				DungeonsData.all_rooms[activeScene.room.index] = r;
				activeScene.DrawRoom();
				activeScene.Refresh();
			}
		}

		// TODO system specific path separators, etc
		private void importRoomsFromFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Warning this will close all opened unsaved rooms do you wish to proceed?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				OpenFileDialog ofd = new OpenFileDialog();

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					string path = Path.GetDirectoryName(ofd.FileName);

					for (int i = 0; i < Constants.NumberOfRooms; i++)
					{
						if (File.Exists(path + "// room" + i.ToString("D3") + ".bin"))
						{
							using (FileStream fs = new FileStream(path + "// room" + i.ToString("D3") + ".bin", FileMode.Open, FileAccess.Read))
							{
								DungeonsData.all_rooms[i].tilesObjects.Clear(); //Empty the room first
								byte[] data = new byte[fs.Length];
								fs.Read(data, 0, data.Length);
								DungeonsData.all_rooms[i].loadTilesObjectsFromArray(data, true);
								fs.Close();
							}
						}
					}
				}
			}
		}

		private void importFromROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// TODO: Add something here?
		}

		//Jared_Brian_: changed so that nothing will write to the ROM if the SaveTiles() function fails.
		/// <summary>
		/// Runs when the save only maps button is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveMapsOnlyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Save s = new Save(DungeonsData.all_rooms, this);
			if (overworldEditor.scene.SaveTiles())
			{
				Console.WriteLine("Tile save failed.");
			}
			else
			{
				if (s.saveOverworldMaps(overworldEditor.scene))
				{
					Console.WriteLine("too many maps out of bound error");
				}

				FileStream fs = new FileStream(projectFilename, FileMode.OpenOrCreate, FileAccess.Write);
				fs.Write(ROM.DATA, 0, ROM.DATA.Length);
				fs.Close();
			}
		}

		private void importRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = UIText.ExportedRoomDataType;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
				byte[] data = new byte[(int) fs.Length];
				fs.Read(data, 0, data.Length);
				fs.Close();

				activeScene.room.loadTilesObjectsFromArray(data);
				activeScene.Refresh();
			}
		}

		private void showRoomsInHexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (TabPage tp in tabControl2.TabPages)
			{
				if (showRoomsInHexToolStripMenuItem.Checked)
				{
					tp.Text = (tp.Tag as Room).index.ToString("X3");
				}
				else
				{
					tp.Text = (tp.Tag as Room).index.ToString("D3");
				}
			}
		}

		private void showMapIndexInHexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (showMapIndexInHexToolStripMenuItem.Checked)
			{
				overworldEditor.mapGroupbox.Text = "Selected Map - " + overworldEditor.scene.selectedMapParent.ToString("X2") + " Properties : ";
			}
			else
			{
				overworldEditor.mapGroupbox.Text = "Selected Map - " + overworldEditor.scene.selectedMapParent.ToString() + " Properties : ";
			}
		}

		private void saveVRAMAsPngToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GFX.currentgfx16Bitmap.Save("vram.png");
		}

		private void edit8x8palettebox_Paint(object sender, PaintEventArgs e)
		{
			ColorPalette cp = GFX.roomBg1Bitmap.Palette;
			for (int i = 0; i < 128; i++)
			{
				e.Graphics.FillRectangle(new SolidBrush(cp.Entries[i]), new Rectangle((i % 16) * 16, (i / 16) * 16, 16, 16));
			}
		}

		private void moveRoomsToOtherROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UIText.WarnAboutSaving(UIText.CloseROMWarning);
			RoomMover rm = new RoomMover();

			if (rm.ShowDialog() == DialogResult.OK)
			{
				List<short> listofrooms = new List<short>();
				for (int i = 0; i < Constants.NumberOfRooms; i++)
				{
					if (rm.checkedListBox1.GetItemChecked(i))
					{
						listofrooms.Add((short) i);
					}
				}

				FileStream fs = new FileStream(rm.textBox1.Text, FileMode.Open, FileAccess.Read);
				int size = (int) fs.Length;

				if (fs.Length < 0x200000)
				{
					size = 0x200000;
				}

				ROM.DATA2 = new byte[size];
				if ((fs.Length & 0x200) == 0x200)
				{
					size = (int) (fs.Length - 0x200);
					byte[] tempRomData = new byte[fs.Length];
					fs.Read(tempRomData, 0, (int) fs.Length);
					Array.Copy(tempRomData, 0x200, ROM.DATA2, 0, size);
				}
				else
				{
					fs.Read(ROM.DATA2, 0, (int) fs.Length);
				}

				fs.Close();

				ROM.TEMPDATA = new byte[0x200000];
				for (int i = 0; i < 0x200000; i++)
				{
					ROM.TEMPDATA[i] = ROM.DATA[i];
					ROM.DATA[i] = ROM.DATA2[i];
				}

				for (int i = 0; i < Constants.NumberOfRooms; i++)
				{
					DungeonsData.all_rooms_moved[i] = new Room(i);
				}

				ROM.TEMPDATA = new byte[0x200000];
				for (int i = 0; i < 0x200000; i++)
				{
					ROM.DATA2[i] = ROM.DATA[i];
					ROM.DATA[i] = ROM.TEMPDATA[i]; // Restore to original rom
				}

				Save save = new Save(DungeonsData.all_rooms, this);

				//if (rm.checkBox7.Checked)
				//{

				if (save.saveRoomsHeaders2()) // No protection always the same size so we don't care :)
				{
					//MessageBox.Show("Failed to save, there is too many chest items", "Bad Error", MessageBoxButtons.OK);
				}
				//}

				if (rm.checkBox6.Checked)
				{
					if (save.saveallChests2()) // Chest there's a protection when there's too many chest - tested it works fine
					{
						UIText.CryAboutSaving("there are too many chest items");
						return;
					}
				}

				if (rm.checkBox5.Checked)
				{
					if (save.saveallSprites2(listofrooms.ToArray())) // Sprites, there's a protection
					{
						UIText.CryAboutSaving("there are too many sprites");
						return;
					}
				}

				if (rm.checkBox1.Checked)
				{
					if (save.saveAllObjects2(listofrooms.ToArray())) // There is a protection - Tested
					{
						UIText.CryAboutSaving("there are too many tiles objects");
						return;
					}
				}

				if (rm.checkBox2.Checked)
				{
					if (save.saveallPots2(listofrooms.ToArray())) // There is a protection - Tested
					{
						UIText.CryAboutSaving("there are too many pot items");
						return;
					}
				}

				/*
                if (rm.checkBox3.Checked)
                {
                    if (save.saveBlocks2())//There is a protection - Tested
                    {
                        UIText.CryAboutSaving("there are too many pushable blocks");
                        return;
                    }
                }
                if (rm.checkBox4.Checked)
                {
                    if (save.saveTorches2())//There is a protection Tested
                    {
                        UIText.CryAboutSaving("there are too many torches");
                        return;
                    }
                }
                */

				fs = new FileStream(rm.textBox1.Text, FileMode.Open, FileAccess.Write);
				fs.Write(ROM.DATA2, 0, 0x200000);

				fs.Close();

				MessageBox.Show("Selected data successfully moved to selected ROM.\n" +
					"Please restart the application.");
			}
		}

		private void showSpritesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			overworldEditor.scene.showSprites = showSpritesToolStripMenuItem.Checked;
			overworldEditor.scene.showEntrances = showEntrancesToolStripMenuItem.Checked;
			overworldEditor.scene.showExits = showExitsToolStripMenuItem.Checked;
			overworldEditor.scene.showFlute = showTransportsToolStripMenuItem.Checked;
			overworldEditor.scene.showItems = showItemsToolStripMenuItem.Checked;
			overworldEditor.Refresh();
		}

		private void increaseObjectSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (activeScene.room.selectedObject.Count > 0)
			{
				if (activeScene.room.selectedObject[0] is Room_Object obj)
				{
					Console.WriteLine(obj.size);
					obj.UpdateSize();

					if (obj.size < 15)
					{
						obj.size++;
					}
					else
					{
						obj.size = 1;
					}

					activeScene.updateSelectionObject(obj);
				}
			}

			activeScene.DrawRoom();
			activeScene.Refresh();
		}

		private void decreaseObjectSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (activeScene.room.selectedObject.Count > 0)
			{
				if (activeScene.room.selectedObject[0] is Room_Object obj)
				{
					if (obj.size > 0)
					{
						obj.UpdateSize();
						obj.size--;
						activeScene.updateSelectionObject(obj);
					}
				}
			}

			activeScene.DrawRoom();
			activeScene.Refresh();
		}

		private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChangeTheme(Controls);
		}

		// TODO Magic colors
		// make a ThemeConstants.cs file?
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
				overworldEditor.gridDisplay = 8;
			}
			else if (sender == x16ToolStripMenuItem1)
			{
				x16ToolStripMenuItem1.Checked = true;
				overworldEditor.gridDisplay = 16;
			}
			else if (sender == x32ToolStripMenuItem1)
			{
				x32ToolStripMenuItem1.Checked = true;
				overworldEditor.gridDisplay = 32;
			}
			else
			{
				noneToolStripMenuItem.Checked = true;
				overworldEditor.gridDisplay = 0;
			}

			overworldEditor.scene.Refresh();
		}

		private void autodoorButton_Click_1(object sender, EventArgs e)
		{
			List<Room_Object> shutterdoors = new List<Room_Object>();
			List<Room_Object> keydoors = new List<Room_Object>();
			List<Room_Object> normaldoors = new List<Room_Object>();

			keydoors.Clear();
			shutterdoors.Clear();
			normaldoors.Clear();

			foreach (Room_Object o in activeScene.room.tilesObjects)
			{
				if (o.options == ObjectOption.Door)
				{
					if (keysDoors.Contains((byte) (o.id >> 8)))
					{
						if (!keydoors.Contains(o))
						{
							keydoors.Add(o);
						}
					}
					else if (shutterDoors.Contains((byte) (o.id >> 8)))
					{
						if (!shutterdoors.Contains(o))
						{
							shutterdoors.Add(o);
						}
					}
					else
					{
						if (!normaldoors.Contains(o))
						{
							normaldoors.Add(o);
						}
					}
				}
			}

			foreach (Room_Object o in keydoors)
			{
				activeScene.room.tilesObjects.Remove(o);
				activeScene.room.tilesObjects.Add(o);
			}

			foreach (Room_Object o in shutterdoors)
			{
				activeScene.room.tilesObjects.Remove(o);
				activeScene.room.tilesObjects.Add(o);
			}

			foreach (Room_Object o in normaldoors)
			{
				activeScene.room.tilesObjects.Remove(o);
				activeScene.room.tilesObjects.Add(o);
			}

			activeScene.DrawRoom();
			activeScene.Refresh();
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

		private void xScreenToolStripMenuItem_Click(object sender, EventArgs e)
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
			activeScene.clearCustomCollisionMap();
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
				overworldEditor.clearOverworldSprites(0);
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
				overworldEditor.clearOverworldSprites(1);
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
				overworldEditor.clearOverworldSprites(2);
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
				overworldEditor.clearOverworldItems();
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
				overworldEditor.clearOverworldEntrances();
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
				overworldEditor.clearOverworldHoles();
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
				overworldEditor.clearOverworldExits();
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
				overworldEditor.clearOverworldOverlays();
			}
		}

		private void selectAllRoomsForExportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				selectedMapPng.Add((short) i);
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
				overworldEditor.clearAreaSprites(0);
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
				overworldEditor.clearAreaSprites(1);
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
				overworldEditor.clearAreaSprites(2);
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
				overworldEditor.clearAreaItems();
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
				overworldEditor.clearAreaEntrances();
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
				overworldEditor.clearAreaHoles();
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
				overworldEditor.clearAreaExits();
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
				overworldEditor.clearAreaOverlays();
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
				string.Format("You are about to delete all {0}.\nDo you wish to continue?", w),
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
			return ConfirmDeletion(
				string.Format("{0} from OW screen {1:X2}", w, overworldEditor.scene.selectedMapParent));
		}

		private void discordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(UIText.DISCORD);
		}

		private void RoomPropertyChanged(object sender, EventArgs e)
		{
			updateRoomInfo();
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

		private void clearDWTilesToolStripMenuItem_Click(object sender, EventArgs e)
		{

			if (MessageBox.Show("Are you sure you want to clear all tiles of the Dark World?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				int sx = 0;
				int sy = 0;

				for (int i = 0; i < 64; i++)
				{
					for (int y = 0; y < 32; y += 1)
					{
						for (int x = 0; x < 32; x += 1)
						{
							overworldEditor.overworld.allmapsTilesDW[x + (sx * 32), y + (sy * 32)] = 0x34;
						}
					}

					sx++;
					if (sx >= 8)
					{
						sy++;
						sx = 0;
					}
				}
			}
		}

		private void copyLWToDWToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to copy Light World tiles to the Dark World?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				int sx = 0;
				int sy = 0;

				for (int i = 0; i < 64; i++)
				{
					for (int y = 0; y < 32; y += 1)
					{
						for (int x = 0; x < 32; x += 1)
						{
							overworldEditor.overworld.allmapsTilesDW[x + (sx * 32), y + (sy * 32)] = overworldEditor.overworld.allmapsTilesLW[x + (sx * 32), y + (sy * 32)];
						}
					}

					sx++;
					if (sx >= 8)
					{
						sy++;
						sx = 0;
					}
				}
			}
		}

		private void showTiles32CountToolStripMenuItem_Click(object sender, EventArgs e)
		{
			overworldEditor.overworld.showTile32Count();
		}

		private void useAreaSpecificBGColorToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			overworldEditor.UpdateBGColorVisibility(useAreaSpecificBGColorToolStripMenuItem.Checked);

			OverworldEditor.UseAreaSpecificBgColor = useAreaSpecificBGColorToolStripMenuItem.Checked;
			overworldEditor.Refresh();
		}
	}
}
