using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Lidgren.Network;
using Microsoft.VisualBasic;
using ZeldaFullEditor.Data;
using ZeldaFullEditor.Gui;
using ZeldaFullEditor.Gui.ExtraForms;
using ZeldaFullEditor.Gui.ExtraForms.ZSESettings;
using ZeldaFullEditor.Gui.MainTabs;
using ZeldaFullEditor.Properties;
using static ZeldaFullEditor.Room_Object;

namespace ZeldaFullEditor
{
	/// <summary>
	///		Main ZScream form, everything runs from here.
	/// </summary>
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

		// TODO : Move that to a data class.

		// TODO : Move that?
		public byte[] DoorIndex;

		public TextEditor textEditor = new TextEditor();
		public OverworldEditor overworldEditor = new OverworldEditor();
		private Object_Designer objDesigner = new Object_Designer();
		public GfxImportExport gfxEditor;
		private DungeonViewer dungeonViewer = new DungeonViewer();
		public string projectFilename = "";
		public bool projectLoaded = false;
		public bool anychange = false;
		public SceneUW activeScene;
		public List<Room> opened_rooms = new List<Room>();
		private bool saved_changed = false;
		public TreeNode lastNode = null;
		private RoomLayout layoutForm;
		private List<short> selectedMapPng = new List<short>();
		public ChestPicker chestPicker = new ChestPicker();
		public bool settingEntrance = false;
		public int selectedLayer = -1;
		public Entrance selectedEntrance = null;
		private PaletteEditor paletteForm;
		private Bitmap xTabButton;
		public Room previewRoom = null;
		public ScreenEditor screenEditor = new ScreenEditor();
		public MusicEditor musicEditor = new MusicEditor();
		public SpriteEditor spriteEditor = new SpriteEditor();
		public string loadFromExported = string.Empty;

		public List<Room_Object> listoftilesobjects = new List<Room_Object>();
		public List<Sprite> listofspritesobjects = new List<Sprite>();
		private List<Chest> listofchests = new List<Chest>();

		// Groups of options for the Scene.
		public bool showSprite = true;

		public bool showChest = true;
		public bool showItems = true;
		public bool showDoorsIDs = true;
		public bool showChestIDs = true;
		public bool showStairIDs = true;

		public bool showSpriteText = false;
		public bool showChestText = false;
		public bool showItemsText = false;

		public bool visibleEntranceGFX = false;
		public bool x2zoom = false;

		private VramViewer vramViewer = new VramViewer();
		public CGRamViewer cgramViewer = new CGRamViewer();
		public GfxGroupsForm gfxGroupsForm;

		private int tpHotTracked = -1;
		private int tpHotTrackedToClose = -1;
		private int tpHotTrackedToCloseLast = -2;
		private int lasttpHotTracked = -2;

		public int lastRoomID = -1;
		private int HoveredRoom = -1;
		private bool rightClickingRoom = false;

		private OverworldEditor oweditor2;

		private ushort[,] lwmdata = new ushort[512, 512];
		private ushort[,] dwmdata = new ushort[512, 512];

		private byte[] keysDoors = new byte[] { 0x1C, 0x26, 0x1E, 0x2E, 0x28, 0x32, 0x30, 0x22 };
		private byte[] shutterDoors = new byte[] { 0x44, 0x18, 0x36, 0x38, 0x48, 0x4A };

		public bool propertiesChangedFromForm = false;

		public int gridSize = 8;

		NetZS netZS;

		internal Label networkstatusLabel = new Label();
		internal Panel networkPanel;

		int romID = 00;

		// TODO: Save this in a config file and load the values into this array on startup.
		public bool[] saveSettingsArr = new bool[47]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true,
		};

		/// <summary>
		///     Initializes a new instance of the <see cref="DungeonMain"/> class.
		/// </summary>
		// TODO KAN REFACTOR - Move some of the string lists into the constructor.
		public DungeonMain()
		{
			this.InitializeComponent();
			this.Text = $"{UIText.APPNAME} - {UIText.VERSION}";

			this.tileTypeCombobox.Items.AddRange(Utils.CreateIndexedList(Constants.TileTypeNames));
			this.EntranceProperties_FloorSel.Items.AddRange(Constants.floors);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.DoorIndex = DefaultEntities.Doors.Keys.ToArray();
			this.comboBox2.Items.AddRange(
			DefaultEntities.Doors.Values.ToArray());

			GFX.fontgfx16Ptr = Marshal.AllocHGlobal(256 * 256);

			GFX.currentfontgfx16Ptr = Marshal.AllocHGlobal(172 * 20000);

			GFX.mapblockset16 = Marshal.AllocHGlobal(1048576);

			GFX.scratchblockset16 = Marshal.AllocHGlobal(1048576);

			GFX.OverworldMapPointer = Marshal.AllocHGlobal(0x40000);

			GFX.OWActualMapPointer = Marshal.AllocHGlobal(0x40000);

			if (Settings.Default.favoriteObjects.Count < 0xFFF)
			{
				while (Settings.Default.favoriteObjects.Count < 0xFFF)
				{
					Settings.Default.favoriteObjects.Add("false");
				}
			}

			this.xTabButton = new Bitmap(Resources.xbutton);
			this.layoutForm = new RoomLayout(this);
			this.gfxEditor = new GfxImportExport(this);
			this.Initialize_properties();
			GFX.initGfx();
			ROMStructure.loadDefaultProject();
			this.mapPicturebox.Image = new Bitmap(256, 304);
			this.thumbnailBox.Size = new Size(256, 256);

			this.RefreshRecentsFiles();
			this.textEditor.Visible = false;
			this.overworldEditor.Visible = false;
			this.objDesigner.Visible = false;
			this.gfxEditor.Visible = false;
			this.dungeonViewer.Visible = false;
			this.screenEditor.Visible = false;
			this.musicEditor.Visible = false;
			this.spriteEditor.Visible = false;

			this.objDesigner.Dock = DockStyle.Fill;
			this.overworldEditor.Dock = DockStyle.Fill;
			this.textEditor.Dock = DockStyle.Fill;
			this.gfxEditor.Dock = DockStyle.Fill;
			this.dungeonViewer.Dock = DockStyle.Fill;
			this.screenEditor.Dock = DockStyle.Fill;
			this.musicEditor.Dock = DockStyle.Fill;
			this.spriteEditor.Dock = DockStyle.Fill;

			this.Controls.Add(this.overworldEditor);
			this.Controls.Add(this.textEditor);
			this.Controls.Add(this.objDesigner);
			this.Controls.Add(this.gfxEditor);
			this.Controls.Add(this.dungeonViewer);
			this.Controls.Add(this.screenEditor);
			this.Controls.Add(this.musicEditor);
			this.Controls.Add(this.spriteEditor);

			// If we are in the debug version, show the Experimental Features drop down menu.
#if DEBUG
			this.ExperimentalToolStripMenuItem1.Visible = true;
			this.jPDebugToolStripMenuItem.Visible = true;
#endif
		}

		private void SceneUW_MouseWheel(object sender, MouseEventArgs e)
		{
			HandledMouseEventArgs ee = (HandledMouseEventArgs) e;
			ee.Handled = true;
		}

		// Need to stay here.
		public void Initialize_properties()
		{
			Background2[] bg2values = (Background2[]) Enum.GetValues(typeof(Background2));
			foreach (Background2 s in bg2values)
			{
				this.roomProperty_bg2.Items.Add(s.ToString());
			}

			CollisionKey[] collisionvalues = (CollisionKey[]) Enum.GetValues(typeof(CollisionKey));
			foreach (CollisionKey s in collisionvalues)
			{
				this.roomProperty_collision.Items.Add(s.ToString());
			}

			EffectKey[] effectvalues = (EffectKey[]) Enum.GetValues(typeof(EffectKey));
			foreach (EffectKey s in effectvalues)
			{
				this.roomProperty_effect.Items.Add(s.ToString());
			}

			TagKey[] tagvalues = (TagKey[]) Enum.GetValues(typeof(TagKey));
			foreach (TagKey s in tagvalues)
			{
				this.roomProperty_tag1.Items.Add(s.ToString());
				this.roomProperty_tag2.Items.Add(s.ToString());
			}
		}

		bool saveAs = false;
		/*
        Stopwatch sw = new Stopwatch();
        */

		// TODO : Move that to the save class.
		public void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Save Functions
			// Expand ROM to 2MB

			//sw.Reset();
			//sw.Start();
			if (!this.saveAs)
			{
				if (NetZS.connected)
				{
					if (this.netZS.host == false)
					{
						// Request a save to the server!
						NetZSBuffer buffer = new NetZSBuffer(4);
						buffer.Write((byte) 64); // Save request
						buffer.Write(NetZS.userID); // User ID

						NetOutgoingMessage message = NetZS.client.CreateMessage();
						message.Write(buffer.buffer);
						NetZS.client.SendMessage(message, NetDeliveryMethod.ReliableOrdered);
						NetZS.client.FlushSendQueue();
						return;
					}
				}
			}

			this.saveAs = false;

			if (!NetZS.connected)
			{
				foreach (Room room in this.opened_rooms)
				{
					if (room.has_changed)
					{
						foreach (TabPage tabPage in this.tabControl2.TabPages)
						{
							tabPage.Text = tabPage.Text.Trim('*');
						}

						DungeonsData.AllRooms[room.index] = (Room) room.Clone();
						room.has_changed = false;
						DungeonsData.AllRooms[room.index].has_changed = false;
					}
				}
			}

			this.anychange = false;
			//tabControl2.Refresh();
			//sw.Stop();
			//Console.WriteLine("Saved all unsaved rooms - " + sw.ElapsedMilliseconds.ToString() + "ms");

			//sw.Reset();
			//sw.Start();
			byte[] romBackup = (byte[]) ROM.DATA.Clone();


			Save save = new Save(DungeonsData.AllRooms, this);

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
			// And allows us to break out on failure cleanly to terminate the routine.
			bool badSave = true;
			do
			{
				// THIS SHOULD BE FIRST, BECAUSE IT SHOULD COME BEFORE ALL OTHER PATCHES
				// CAPSLOCK
				if (save.ApplyBasePatches())
				{
					break;
				}


				// MUST BE CALLED BEFORE SAVEALLSPRITES.
				if (this.saveSettingsArr[9] && save.SaveOWSprites(this.overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld sprites out of range");
					break;
				}

				if (this.saveSettingsArr[0] && save.SaveAllSprites())
				{
					UIText.CryAboutSaving("there are too many sprites");
					break;
				}

				if (this.saveSettingsArr[1] && save.SaveAllPots())
				{
					UIText.CryAboutSaving("there are too many pot items");
					break;
				}

				if (this.saveSettingsArr[2] && save.SaveAllChests())
				{
					UIText.CryAboutSaving("there are too many chest items");
					break;
				}

				if (this.saveSettingsArr[3] && save.SaveAllObjects())
				{
					UIText.CryAboutSaving("there are too many tiles objects");
					break;
				}

				if (this.saveSettingsArr[4] && save.SaveBlocks())
				{
					UIText.CryAboutSaving("there are too many pushable blocks");
					break;
				}

				if (this.saveSettingsArr[5] && save.SaveTorches())
				{
					UIText.CryAboutSaving("there are too many torches");
					break;
				}

				if (this.saveSettingsArr[6] && save.SaveAllPits())
				{
					UIText.CryAboutSaving("there are too many pits with damage");
					break;
				}

				if (this.saveSettingsArr[7] && save.SaveRoomsHeaders())
				{
					//UIText.CryAboutSaving("there are too many chest items);
					//break;
				}

				if (this.saveSettingsArr[8] && save.SaveEntrances(DungeonsData.Entrances, DungeonsData.StartingEntrances))
				{
					UIText.CryAboutSaving("something with entrances ?? no idea why LUL");
					break;
				}

				if (this.saveSettingsArr[10] && save.SaveOWItems(this.overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld items out of range");
					break;
				}

				if (this.saveSettingsArr[11] && save.SaveOWEntrances(this.overworldEditor.scene))
				{
					UIText.CryAboutSaving("??, no idea why LUL");
					break;
				}

				if (this.saveSettingsArr[12] && save.SaveOWTransports(this.overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld transports out of range");
					break;
				}

				if (this.saveSettingsArr[13] && save.SaveOWExits(this.overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld Exits or something IDK");
					break;
				}

				if (this.saveSettingsArr[14] && this.overworldEditor.scene.SaveTiles())
				{
					// No need for a message box here because its handeled within the SaveTiles() function itslef.
					break;
				}

				// 15

				if (this.saveSettingsArr[16] && save.SaveMapProperties(this.overworldEditor.scene))
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

				if (this.saveSettingsArr[23] && GfxGroups.SaveGroupsToROM())
				{
					UIText.CryAboutSaving("problem saving GFX Groups");
					break;
				}

				if (this.saveSettingsArr[24] && Palettes.SavePalettesToROM(ROM.DATA))
				{
					UIText.CryAboutSaving("problem saving palettes");
					break;
				}

				if (this.saveSettingsArr[25] && save.SaveAllText(this.textEditor))
				{
					UIText.CryAboutSaving("impossible to save text");
					break;
				}

				// 17

				if (this.saveSettingsArr[28] && save.SaveCustomCollision())
				{
					UIText.CryAboutSaving("there was an error saving the custom collision rectangles");
					break;
				}

				if (this.saveSettingsArr[31] && save.SaveMapOverlays(this.overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld map overlays ???");
					break;
				}

				if (this.saveSettingsArr[32] && save.SaveOverworldMusic(this.overworldEditor.scene))
				{
					UIText.CryAboutSaving("overworld map tile types ???");
					break;
				}

				if (this.saveSettingsArr[33] && save.SaveTitleScreen())
				{
					UIText.CryAboutSaving("overworld title screen?");
					break;
				}

				if (this.saveSettingsArr[34] && save.SaveOverworldMiniMap())
				{
					UIText.CryAboutSaving("problem saving overworld Minimap?");
					break;
				}

				if (this.saveSettingsArr[35] && save.SaveOverworldTilesType(this.overworldEditor.scene))
				{
					UIText.CryAboutSaving("problem saving overworld map tiles Types ???");
					break;
				}

				if (this.saveSettingsArr[36] && save.SaveOverworldMaps(this.overworldEditor.scene))
				{
					UIText.CryAboutSaving("problem saving overworld maps");
					break;
				}

				if (this.saveSettingsArr[37] && save.SaveGravestones(this.overworldEditor.scene))
				{
					UIText.CryAboutSaving("problem saving gravestones");
					break;
				}

				if (this.saveSettingsArr[38] && save.SaveDungeonMaps())
				{
					UIText.CryAboutSaving("problem saving dungeon maps");
					break;
				}

				if (this.saveSettingsArr[39] && save.SaveTriforce())
				{
					UIText.CryAboutSaving("problem saving triforce");
					break;
				}

				if (this.saveSettingsArr[40] && save.SaveOverworldMessagesIDs(this.overworldEditor.scene))
				{
					UIText.CryAboutSaving("problem saving overworld map tiles Types ???");
					break;
				}

				if (this.saveSettingsArr[45] && save.SaveSpritesDamages())
				{
					UIText.CryAboutSaving("problem saving sprites damages");
					return;
				}

				if (this.saveSettingsArr[46] && save.SaveSpritesProperties())
				{
					UIText.CryAboutSaving("problem saving sprites properties");
					return;
				}

				// The mosaic byte is hardcoded to true on purpose for now.
				if (save.SaveCustomOverworldASM(this.overworldEditor.scene, this.saveSettingsArr[41], this.saveSettingsArr[42], true, this.saveSettingsArr[43], this.saveSettingsArr[44]))
				{
					UIText.CryAboutSaving("problem saving ZS Custom Overworld ASM");
					break;
				}

				// If we made it here, everything was fine.
				badSave = false;
			}
			while (false);

			if (badSave)
			{
				ROM.DATA = (byte[]) romBackup.Clone(); // Restore previous rom data to prevent corrupting anything.
				return;
			}

			ROM.Write(0x5D4E, 0x00, true, "Fix sprite sheet 123 (should not be read compressed)"); // Fix for the sprite sheet 123.

			if (this.gfxEditor.SaveAllGfx())
			{
				ROM.DATA = (byte[]) romBackup.Clone(); // Restore previous rom data to prevent corrupting anything.
				return;
			}

			//sw.Stop();
			//Console.WriteLine("Saved Overworld- " + sw.ElapsedMilliseconds.ToString() + "ms");
			//Console.WriteLine("ROMDATA[" + (Constants.overworldMapPalette + 2).ToString("X6") + "]" + " : " + ROM.DATA[Constants.overworldMapPalette + 2]);
			//AsarCLR.Asar.init();
			//AsarCLR.Asar.patch("titlescreen.asm", ref ROM.DATA);
			//overworldEditor.overworld.SaveMap16Tiles();

			this.overworldEditor.saveScratchPad();

			this.anychange = false;
			this.saved_changed = false;

			//ROMStructure.saveProjectFile(version, projectFilename);
			ROM.SaveLogs();

			FileStream fs = new FileStream(this.projectFilename, FileMode.OpenOrCreate, FileAccess.Write);
			fs.Write(ROM.DATA, 0, ROM.DATA.Length);
			fs.Close();
		}

		// TODO: Move more of the failure stuff here.

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var projectFile = new OpenFileDialog();
			projectFile.Filter = UIText.USROMType;
			projectFile.DefaultExt = UIText.ROMExtension;

			if (projectFile.ShowDialog() == DialogResult.OK)
			{
				this.projectFilename = projectFile.FileName;
				this.LoadProject(projectFile.FileName);
				this.openToolStripMenuItem.Enabled = false;
				this.openfileButton.Enabled = false;
				this.recentROMToolStripMenuItem.Enabled = false;
			}
		}

		public void CheckAnyChanges()
		{
			foreach (TabPage p in this.tabControl2.TabPages)
			{
				if ((p.Tag as Room).has_changed)
				{
					this.anychange = true;
					if (!p.Text.Contains("*"))
					{
						p.Text += "*";
					}
				}
			}
		}

		public void LoadProject(string filename, bool fromdata = false)
		{
			ROMStructure.loadDefaultProject();

			// TODO : Add Headered ROM.
			if (!fromdata)
			{
				var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
				int size = (int) fileStream.Length;
				if (fileStream.Length < 0x200000)
				{
					size = 0x200000;
				}

				ROM.DATA = new byte[size];
				if ((fileStream.Length & 0x200) == 0x200)
				{
					size = (int) (fileStream.Length - 0x200);
					byte[] tempRomData = new byte[fileStream.Length];
					fileStream.Read(tempRomData, 0, (int) fileStream.Length);
					Array.Copy(tempRomData, 0x200, ROM.DATA, 0, size);
				}
				else
				{
					fileStream.Read(ROM.DATA, 0, (int) fileStream.Length);
				}

				fileStream.Close();
			}
			else
			{
				ROM.DATA = new byte[0x200000];
				Array.Copy(this.netZS.romData, 0, ROM.DATA, 0, this.netZS.romData.Length);
			}

			this.LoadPalettes();

			this.activeScene = new SceneUW(this);
			this.activeScene.Location = Constants.Point_0_0;
			this.activeScene.Size = new Size(512, 512);
			this.activeScene.MouseWheel += this.SceneUW_MouseWheel;

			if (this.loadFromExported != string.Empty)
			{
				this.loadFromExported = Path.GetDirectoryName(this.projectFilename);
				Console.WriteLine(Path.GetDirectoryName(this.projectFilename));
			}

			this.InitProject();

			openToolStripMenuItem.Enabled = false;
			openfileButton.Enabled = false;
			recentROMToolStripMenuItem.Enabled = false;
			applyFastROMToolStripMenuItem.Enabled = true;

			this.Text = $"{UIText.APPNAME} - {filename}";
		}

		// TODO : Move that to a data class.
		public void LoadPalettes()
		{
			Palettes.CreateAllPalettes(ROM.DATA);
		}

		public unsafe void InitProject()
		{
			this.tabControl1.Enabled = true;
			GfxGroups.LoadGfxGroups();
			GFX.CreateAllGfxData(ROM.DATA);

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				DungeonsData.AllRooms[i] = new Room(i, this.loadFromExported); // Create all rooms.
				DungeonsData.UndoRoom[i] = new List<Room>();
				DungeonsData.RedoRoom[i] = new List<Room>();
			}

			this.editorsTabControl.Enabled = true;

			this.InitEntrancesList();
			this.customPanel3.Controls.Add(this.activeScene);
			this.AddRoomTab(260);

			this.TabControl2_SelectedIndexChanged(this.tabControl2.TabPages[0], new EventArgs());
			this.EnableProjectButtons();
			foreach (ToolStripMenuItem menuItem in this.menuStrip1.Items)
			{
				menuItem.Enabled = true;
			}

			this.roomHeaderPanel.Enabled = true;

			// Initialize the map draw.
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

			this.InitObjectsList();
			this.spritesView1.items.Clear();

			foreach (Sprite sprite in this.listofspritesobjects)
			{
				this.spritesView1.items.Add((sprite));
			}

			this.objectViewer1.items.Clear();
			foreach (Room_Object roomObject in this.listoftilesobjects)
			{
				this.objectViewer1.items.Add((roomObject));
			}

			this.selecteditemobjectCombobox.Items.Clear();

			for (int i = 0; i < ItemsNames.name.Length; i++)
			{
				this.selecteditemobjectCombobox.Items.Add(ItemsNames.name[i]);
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

			GFX.loadedPalettes = GFX.LoadDungeonPalette(this.activeScene.room.palette);
			GFX.loadedSprPalettes = GFX.LoadSpritesPalette(this.activeScene.room.palette);
			this.objectViewer1.updateSize();
			this.spritesView1.updateSize();

			this.activeScene.DrawRoom();
			this.activeScene.Refresh();

			this.undoButton.Enabled = true;
			this.redoButton.Enabled = true;

			if (Settings.Default.recentFiles.Contains(this.projectFilename))
			{
				Settings.Default.recentFiles.Remove(this.projectFilename);
			}

			Settings.Default.recentFiles.Insert(0, this.projectFilename);
			while (Settings.Default.recentFiles.Count > 5)
			{
				Settings.Default.recentFiles.RemoveAt(4);
			}

			this.entrancetreeView_AfterSelect(null, null);
			this.gfxGroupsForm = new GfxGroupsForm(this);
			this.gfxGroupsForm.CreateTempGfx();
			this.gfxGroupsForm.Location = Constants.Point_0_0;

			this.paletteForm = new PaletteEditor(this)
			{
				Location = Constants.Point_0_0
			};
			this.RefreshRecentsFiles();
			this.overworldEditor.InitOpen(this);
			this.textEditor.InitializeOnOpen();
			this.screenEditor.Init();
			// InitDungeonViewer();
			this.mapPicturebox.Refresh();

			int compsize = 0;
			byte[] dcompData = ZCompressLibrary.Decompress.ALTTPDecompressOverworld(ROM.ReadBlock(Constants.Sprite_DamageTaken, 0x1000), 0, 0x1000, ref compsize);
			for (int i = 0; i < dcompData.Length; i++)
			{
				DungeonsData.SpriteDamageTaken[i] = dcompData[i];
			}

			for (int i = 0; i < 243; i++)
			{
				DungeonsData.SpriteProperties.Add(new SpriteProperty((byte) i));
			}

			DungeonsData.GlobalDamages = ROM.ReadBlock(Constants.DamageClass, 0x80);

			DungeonsData.BumpDamagesGroup = ROM.ReadBlock(Constants.BumpDamageGroups, 30);

			// TODO: We should probably move this to a better spot and include all the save settings but this will work for now.
			if (ROM.DATA[Constants.OverworldCustomAreaSpecificBGEnabled] != 0x00)
			{
				this.saveSettingsArr[41] = true;
			}

			if (ROM.DATA[Constants.OverworldCustomMainPaletteEnabled] != 0x00)
			{
				this.saveSettingsArr[42] = true;
			}

			if (ROM.DATA[Constants.OverworldCustomAnimatedGFXEnabled] != 0x00)
			{
				this.saveSettingsArr[43] = true;
			}

			if (ROM.DATA[Constants.OverworldCustomSubscreenOverlayEnabled] != 0x00)
			{
				this.saveSettingsArr[44] = true;
			}

			this.projectLoaded = true;

			this.mapPicturebox.Refresh();
		}

		private void InitDungeonViewer()
		{
			this.activeScene.forPreview = true;
			Bitmap bitmap = new Bitmap(8192, 10752);

			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				for (int i = 0; i < Constants.NumberOfRooms; i++)
				{
					this.activeScene.room = DungeonsData.AllRooms[i];
					this.activeScene.room.reloadGfx();
					GFX.loadedPalettes = GFX.LoadDungeonPalette(this.activeScene.room.palette);
					GFX.loadedSprPalettes = GFX.LoadSpritesPalette(this.activeScene.room.palette);
					this.activeScene.DrawRoom();

					this.activeScene.Refresh();

					graphics.DrawImage(this.activeScene.tempBitmap, new Point((i % 16) * 512, (i / 16) * 512));

					/*
                    activeScene.DrawToBitmap(b, new Rectangle(cx * 512, cy * 512, 512, 512));
                    */
				}
			}

			this.dungeonViewer.pictureBox1.Image = bitmap;
			this.activeScene.forPreview = false;
		}

		private void OpenRecentProject(object sender, EventArgs e)
		{
			this.projectFilename = (sender as ToolStripMenuItem).Text;
			this.LoadProject((sender as ToolStripMenuItem).Text);
		}

		private void RefreshRecentsFiles()
		{
			if (Settings.Default.recentFiles != null)
			{
				foreach (string s in Settings.Default.recentFiles)
				{
					ToolStripMenuItem menuItem = new ToolStripMenuItem(s);
					menuItem.Click += this.OpenRecentProject;
					this.recentROMToolStripMenuItem.DropDownItems.Add(menuItem);
				}
			}
		}

		// TODO: Copy and reconfiguring .
		public void InitEntrancesList()
		{
			// Entrances 
			for (int i = 0; i < 0x07; i++)
			{
				DungeonsData.StartingEntrances[i] = new Entrance((byte) i, true);
				string tname = "[" + i.ToString("X2") + "] -> ";
				foreach (DataRoom dataRoom in ROMStructure.dungeonsRoomList)
				{
					if (dataRoom.ID == DungeonsData.StartingEntrances[i].Room)
					{
						tname += "[" + dataRoom.ID.ToString("X2") + "]" + dataRoom.Name;
						break;
					}
				}

				var treeNode = new TreeNode(tname)
				{
					Tag = i,
				};

				this.entrancetreeView.Nodes[1].Nodes.Add(treeNode);
			}

			for (int i = 0; i < 0x85; i++)
			{
				DungeonsData.Entrances[i] = new Entrance((byte) i, false);
				string tname = "[" + i.ToString("X2") + "] -> ";
				foreach (DataRoom d in ROMStructure.dungeonsRoomList)
				{
					if (d.ID == DungeonsData.Entrances[i].Room)
					{
						tname += "[" + d.ID.ToString("X2") + "]" + d.Name;
						break;
					}
				}

				TreeNode tn = new TreeNode(tname)
				{
					Tag = i,
				};

				this.entrancetreeView.Nodes[0].Nodes.Add(tn);
			}

			this.entrancetreeView.SelectedNode = this.entrancetreeView.Nodes[0].Nodes[0];
			this.selectedEntrance = DungeonsData.Entrances[0];
		}

		public void EnableProjectButtons()
		{
			this.allbgsButton.Enabled = true;
			this.bg3modeButton.Enabled = true;
			this.bg2modeButton.Enabled = true;
			this.bg1modeButton.Enabled = true;
			this.chestmodeButton.Enabled = true;
			this.saveButton.Enabled = true;
			this.doormodeButton.Enabled = true; // Door mode changed on bg.
			this.blockmodeButton.Enabled = true;
			this.torchmodeButton.Enabled = true;
			this.spritemodeButton.Enabled = true;
			this.debugtestButton.Enabled = true;
			this.runtestButton.Enabled = true;
			this.potmodeButton.Enabled = true; // Can't change to sprite since sprites are using 16x16.
			this.saveToolStripMenuItem.Enabled = true;
			this.saveToNewROMToolStripMenuItem.Enabled = true;
			this.saveasToolStripMenuItem.Enabled = true;
			this.warpmodeButton.Enabled = true;
			this.saveLayoutButton.Enabled = true;
			this.loadlayoutButton.Enabled = true;
			this.toolStripButton1.Enabled = true;
			this.searchButton.Enabled = true;
			this.collisionModeButton.Enabled = true;

			foreach (object menuItem in this.editToolStripMenuItem.DropDownItems)
			{
				if (menuItem is ToolStripDropDownItem)
				{
					(menuItem as ToolStripDropDownItem).Enabled = true;
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

		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox1 aboutBox = new AboutBox1();
			aboutBox.ShowDialog();
		}

		public void SetmodeAllScene(ObjectMode mode)
		{
			this.activeScene.selectedMode = mode;
		}

		public void UpdateScenesMode()
		{
			this.spritepropertyPanel.Visible = false;
			this.potitemobjectPanel.Visible = false;
			this.doorselectPanel.Visible = false;
			this.litCheckbox.Visible = false;
			this.collisionMapPanel.Visible = false;
			foreach (Room room in this.opened_rooms)
			{
				room.selectedObject.Clear();
			}

			//objectsListbox.Enabled = false;
			this.SetmodeAllScene(ObjectMode.Bgallmode);

			if (this.allbgsButton.Checked)
			{
				this.SetmodeAllScene(ObjectMode.Bgallmode);
				this.selectedLayer = 3;
			}
			else if (this.bg1modeButton.Checked)
			{
				this.SetmodeAllScene(ObjectMode.Bg1mode);
				this.selectedLayer = 0;
				//objectsListbox.Enabled = true;
			}
			else if (this.bg2modeButton.Checked)
			{
				this.SetmodeAllScene(ObjectMode.Bg2mode);
				this.selectedLayer = 1;
				//objectsListbox.Enabled = true;
			}
			else if (this.bg3modeButton.Checked)
			{
				this.SetmodeAllScene(ObjectMode.Bg3mode);
				this.selectedLayer = 2;
				//objectsListbox.Enabled = true;
			}
			else if (this.spritemodeButton.Checked)
			{
				this.SetmodeAllScene(ObjectMode.Spritemode);
			}
			else if (this.potmodeButton.Checked)
			{
				this.SetmodeAllScene(ObjectMode.Itemmode);
			}
			else if (this.torchmodeButton.Checked)
			{
				this.SetmodeAllScene(ObjectMode.Torchmode);
			}
			else if (this.blockmodeButton.Checked)
			{
				this.SetmodeAllScene(ObjectMode.Blockmode);
			}
			else if (this.doormodeButton.Checked)
			{
				this.SetmodeAllScene(ObjectMode.Doormode);
			}
			else if (this.warpmodeButton.Checked)
			{
				this.SetmodeAllScene(ObjectMode.Warpmode);
			}
			else if (this.chestmodeButton.Checked)
			{
				this.SetmodeAllScene(ObjectMode.Chestmode);
			}
			else if (this.collisionModeButton.Checked)
			{
				this.SetmodeAllScene(ObjectMode.CollisionMap);
				this.xScreenToolStripMenuItem.Checked = true;
				this.HideSpritesToolStripMenuItem_CheckStateChanged(null, null);
				this.tileTypeCombobox.SelectedIndex = 0;
				this.collisionMapPanel.Visible = true;
			}
		}

		public void Update_modes_buttons(object sender, EventArgs e)
		{
			this.activeScene.selectedDragObject = null;
			this.activeScene.selectedDragSprite = null;

			for (int i = 8; i < 20; i++)
			{
				(this.toolStrip1.Items[i] as ToolStripButton).Checked = false;
			}

			this.selectedLayer = -1;
			(sender as ToolStripButton).Checked = true;
			this.UpdateScenesMode();

			this.activeScene.room.update();
			this.activeScene.need_refresh = true;
		}

		private void HowToUseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"Sorry this section does not exist yet. :)\n" +
				"However, you can find shortcuts not mentioned\n" +
				"- Mouse Wheel is used to resize objects for now\n" +
				"- Mouse Wheel Button is used to close rooms tabs");
		}

		private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				this.activeScene.mouse_down = false;
				this.activeScene.deleteSelected();
			}
			else if (this.editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				this.overworldEditor.scene.mouse_down = false;
				this.overworldEditor.scene.deleteSelected();
			}
			else if (this.editorsTabControl.SelectedIndex == 3) // Text editor
			{
				this.textEditor.Delete();
			}
		}

		private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				this.activeScene.mouse_down = false;
				this.activeScene.selectAll();
			}
			else if (this.editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				this.overworldEditor.scene.mouse_down = false;
				this.overworldEditor.scene.selectAll();
			}
			else if (this.editorsTabControl.SelectedIndex == 3) // Text editor
			{
				this.textEditor.SelectAll();
			}
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				this.activeScene.mouse_down = false;
				this.activeScene.cut();
			}
			else if (this.editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				this.overworldEditor.scene.mouse_down = false;
				this.overworldEditor.scene.cut();
			}
			else if (this.editorsTabControl.SelectedIndex == 3) // Text editor
			{
				this.textEditor.Cut();
			}
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				this.activeScene.paste();
			}
			else if (this.editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				this.overworldEditor.scene.paste();
			}
			else if (this.editorsTabControl.SelectedIndex == 2) // gfx editor
			{
				this.gfxEditor.paste();
			}
			else if (this.editorsTabControl.SelectedIndex == 3) // Text editor
			{
				this.textEditor.Paste();
			}
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				this.activeScene.mouse_down = false;
				this.activeScene.copy();
			}
			else if (this.editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				this.overworldEditor.scene.mouse_down = false;
				this.overworldEditor.scene.copy();
			}
			else if (this.editorsTabControl.SelectedIndex == 2) // gfx editor
			{
				this.gfxEditor.copy();
			}
			else if (this.editorsTabControl.SelectedIndex == 3) // Text editor
			{
				this.textEditor.Copy();
			}
		}

		public void undoButton_Click(object sender, EventArgs e)
		{
			if (this.editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				//activeScene.Undo();
			}
			else if (this.editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				this.overworldEditor.scene.Undo();
			}
		}

		public void redoButton_Click(object sender, EventArgs e)
		{
			if (this.editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				//activeScene.Redo();
			}
			else if (this.editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				this.overworldEditor.scene.Redo();
			}
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				//activeScene.Undo();
			}
			else if (this.editorsTabControl.SelectedIndex == 1) // Overworld editor
			{
				this.overworldEditor.scene.Undo();
			}
			else if (this.editorsTabControl.SelectedIndex == 3) // Text editor
			{
				this.textEditor.Undo();
			}
		}

		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				//activeScene.Redo();
			}
			else if (this.editorsTabControl.SelectedIndex == 1) //Ooverworld editor
			{
				this.overworldEditor.scene.Redo();
			}
		}

		private void showBG1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.editorsTabControl.SelectedIndex == 0) // Dungeon editor
			{
				this.activeScene.showLayer1 = this.showBG1ToolStripMenuItem.Checked;
				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
			}
		}

		private void saveLayoutButton_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(UIText.LayoutFolder))
			{
				Directory.CreateDirectory(UIText.LayoutFolder);
			}

			this.saveLayout();
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
				foreach (var o in this.activeScene.room.selectedObject)
				{
					if (this.selectedLayer >= 0)
					{
						data.Add(new SaveObject((Room_Object) o));
					}
					else if (this.spritemodeButton.Checked)
					{
						data.Add(new SaveObject((Sprite) o));
					}
					else if (this.potmodeButton.Checked)
					{
						data.Add(new SaveObject((PotItem) o));
					}
				}
			}

			if (data?.Count > 0)
			{
				// Name that layout.
				string name = "Room_Object";
				if (data[0].Type == typeof(Room_Object))
				{
					name = "Room_Object";
				}

				string f = Interaction.InputBox("Name of the new layout", "Name?", "Layout00");
				if (f != string.Empty)
				{
					BinaryWriter binaryWriter = new BinaryWriter(new FileStream(
						UIText.GetFileName(UIText.LayoutFolder, f),
						FileMode.OpenOrCreate,
						FileAccess.Write));

					binaryWriter.Write(name);

					foreach (SaveObject saveObject in data)
					{
						saveObject.SaveToFile(binaryWriter);
					}

					binaryWriter.Close();
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

			if ((byte) this.activeScene.selectedMode > 3)
			{
				this.bg1modeButton.Checked = true;
				this.Update_modes_buttons(this.bg1modeButton, new EventArgs());

				//scene.selectedMode = ObjectMode.Bg1mode;
			}

			this.layoutForm.scene.room = (Room) this.activeScene.room.Clone();
			this.activeScene.room.selectedObject.Clear();
			if (this.layoutForm.ShowDialog() == DialogResult.OK)
			{
				int most_x = 512;
				int most_y = 512;
				foreach (Room_Object roomObject in this.layoutForm.scene.room.tilesObjects)
				{
					if (this.layoutForm.scene.room.tilesObjects.Count > 0)
					{
						if (roomObject.X < most_x)
						{
							most_x = roomObject.X;
						}

						if (roomObject.Y < most_y)
						{
							most_y = roomObject.Y;
						}
					}
					else
					{
						most_x = 0;
						most_y = 0;
					}
				}

				foreach (Room_Object roomObject in layoutForm.scene.room.tilesObjects)
				{
					roomObject.X = (byte) (roomObject.X - most_x);
					roomObject.Y = (byte) (roomObject.Y - most_y);
					this.activeScene.room.tilesObjects.Add(roomObject);
					this.activeScene.room.selectedObject.Add(roomObject);
				}

				this.activeScene.dragx = 0;
				this.activeScene.dragy = 0;
				this.activeScene.mouse_down = true;
				this.activeScene.need_refresh = true;
				if (!this.visibleEntranceGFX)
				{
					this.activeScene.room.reloadGfx(DungeonsData.Entrances[int.Parse(this.entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
				}
				else
				{
					this.activeScene.room.reloadGfx();
				}
			}
		}

		/// <summary>
		///     Sends an object to the front in the list when using one of the 3 "send to front" options.
		/// </summary>
		private void SendSelectedToFront(object sender, EventArgs e)
		{
			this.activeScene.mouse_down = false;
			if (this.activeScene.room.selectedObject.Count > 0)
			{
				if (this.activeScene.room.selectedObject[0] is Room_Object)
				{
					foreach (Room_Object roomObject in this.activeScene.room.selectedObject)
					{
						for (int i = 0; i < this.activeScene.room.tilesObjects.Count; i++)
						{
							if (roomObject == this.activeScene.room.tilesObjects[i])
							{
								this.activeScene.room.tilesObjects.RemoveAt(i);
								this.activeScene.room.tilesObjects.Add(roomObject);

								break;
							}
						}
					}
				}
				else if (this.activeScene.room.selectedObject[0] is Sprite)
				{
					foreach (Sprite sprite in this.activeScene.room.selectedObject)
					{
						for (int i = 0; i < this.activeScene.room.sprites.Count; i++)
						{
							if (sprite == this.activeScene.room.sprites[i])
							{
								this.activeScene.room.sprites.RemoveAt(i);
								activeScene.room.sprites.Add(sprite);

								break;
							}
						}
					}
				}

				this.activeScene.SendObjectsData();
				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
				this.activeScene.mouse_down = false;
			}
		}

		/// <summary>
		///     Sends an object to the back in the list when using one of the 3 "send to back" options.
		/// </summary>
		public void SendSelectedToBack(object sender, EventArgs e)
		{
			this.activeScene.mouse_down = false;
			if (this.activeScene.room.selectedObject.Count > 0)
			{
				if (this.activeScene.room.selectedObject[0] is Room_Object)
				{
					foreach (Room_Object roomObject in this.activeScene.room.selectedObject)
					{
						for (int i = 0; i < this.activeScene.room.tilesObjects.Count; i++)
						{
							if (roomObject == this.activeScene.room.tilesObjects[i])
							{
								this.activeScene.room.tilesObjects.RemoveAt(i);
								this.activeScene.room.tilesObjects.Insert(0, roomObject);

								break;
							}
						}
					}
				}
				else if (this.activeScene.room.selectedObject[0] is Sprite)
				{
					foreach (Sprite sprite in this.activeScene.room.selectedObject)
					{
						for (int i = 0; i < this.activeScene.room.sprites.Count; i++)
						{
							if (sprite == this.activeScene.room.sprites[i])
							{
								this.activeScene.room.sprites.RemoveAt(i);
								this.activeScene.room.sprites.Insert(0, sprite);

								break;
							}
						}
					}
				}

				this.activeScene.SendObjectsData();
				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
				this.activeScene.mouse_down = false;
			}
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			this.saveLayout(false);
		}

		private void textSpriteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.activeScene.showSpriteText = this.textSpriteToolStripMenuItem.Checked;
			this.activeScene.need_refresh = true;
		}

		private void insertToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.activeScene.mouse_down = false;
			this.activeScene.insertNew();
		}

		private void sendToBg1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.activeScene.mouse_down = false;
			if (this.activeScene.room.selectedObject.Count > 0)
			{
				//debuglabel.Text = activeScene.room.selectedObject[0].GetType().ToString();
				if (this.activeScene.room.selectedObject[0] is Room_Object)
				{
					this.activeScene.updating_info = true;
					foreach (Room_Object roomObject in this.activeScene.room.selectedObject)
					{
						roomObject.Layer = (byte) LayerType.BG1;
					}

					this.activeScene.updating_info = false;
				}
				else if (this.activeScene.room.selectedObject[0] is Sprite)
				{
					this.activeScene.updating_info = true;
					foreach (Sprite sprite in this.activeScene.room.selectedObject)
					{
						sprite.layer = 0;
					}

					this.activeScene.updating_info = false;
				}
				else if (this.activeScene.room.selectedObject[0] is PotItem)
				{
					this.activeScene.updating_info = true;
					foreach (PotItem potItem in this.activeScene.room.selectedObject)
					{
						potItem.layer = 0;
					}

					this.activeScene.updating_info = false;
				}

				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
			}
		}

		private void sendToBg1ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.activeScene.mouse_down = false;
			if (this.activeScene.room.selectedObject.Count > 0)
			{
				if (this.activeScene.room.selectedObject[0] is Room_Object)
				{
					this.activeScene.updating_info = true;
					foreach (Room_Object roomObject in this.activeScene.room.selectedObject)
					{
						roomObject.Layer = LayerType.BG2;
					}

					this.activeScene.updating_info = false;
				}
				else if (this.activeScene.room.selectedObject[0] is Sprite)
				{
					this.activeScene.updating_info = true;
					foreach (Sprite sprite in this.activeScene.room.selectedObject)
					{
						sprite.layer = 1;
					}

					this.activeScene.updating_info = false;
				}
				else if (this.activeScene.room.selectedObject[0] is PotItem)
				{
					this.activeScene.updating_info = true;
					foreach (PotItem potItem in this.activeScene.room.selectedObject)
					{
						potItem.layer = 1;
					}

					this.activeScene.updating_info = false;
				}

				this.activeScene.SendObjectsData();
				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
			}
		}

		private void sendToBg1ToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			this.activeScene.mouse_down = false;
			if (this.activeScene.room.selectedObject.Count > 0)
			{
				if (this.activeScene.room.selectedObject[0] is Room_Object)
				{
					this.activeScene.updating_info = true;
					foreach (Room_Object roomObject in this.activeScene.room.selectedObject)
					{
						roomObject.Layer = LayerType.BG3;
					}

					this.activeScene.SendObjectsData();
					this.activeScene.updating_info = false;
				}

				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
			}
		}

		private void zscreamForm_FormClosing_1(object sender, FormClosingEventArgs e)
		{
			if (this.projectLoaded)
			{
				//Properties.Settings.Default.ViewParameters;
				Settings.Default.spriteText = this.textSpriteToolStripMenuItem.Checked;
				Settings.Default.chestText = this.textChestItemToolStripMenuItem.Checked;
				Settings.Default.itemText = this.textPotItemToolStripMenuItem.Checked;
				Settings.Default.transparentBG = this.unselectedBGTransparentToolStripMenuItem.Checked;
				Settings.Default.rightToolbox = this.rightSideToolboxToolStripMenuItem.Checked;
				Settings.Default.spriteShow = this.hideSpritesToolStripMenuItem.Checked;
				Settings.Default.itemsShow = this.hideItemsToolStripMenuItem.Checked;
				Settings.Default.chestitemShow = this.hideChestItemsToolStripMenuItem.Checked;
				Settings.Default.dooridShow = this.showDoorIDsToolStripMenuItem.Checked;
				Settings.Default.chestidShow = this.showChestsIDsToolStripMenuItem.Checked;
				Settings.Default.disableentranceGfx = this.disableEntranceGFXToolStripMenuItem.Checked;
				Settings.Default.bg2maskShow = this.showBG2MaskOutlineToolStripMenuItem.Checked;
				Settings.Default.entranceCamera = this.entranceCameraToolStripMenuItem.Checked;
				Settings.Default.entrancePos = this.entrancePositionToolStripMenuItem.Checked;
				Settings.Default.Save();
			}

			if (this.anychange)
			{
				DungeonsData.AllRooms[this.activeScene.room.index] = this.activeScene.room;

				this.saved_changed = true;
			}

			if (this.saved_changed)
			{
				this.anychange = false;

				switch (UIText.WarnAboutSaving())
				{
					case DialogResult.Yes:
						this.SaveToolStripMenuItem_Click(this, new EventArgs());
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
			this.activeScene.showLayer2 = this.showBG2ToolStripMenuItem.Checked;
			this.activeScene.DrawRoom();
			this.activeScene.Refresh();
		}

		private void exportProjectAsROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SaveToolStripMenuItem_Click(sender, e);
			SaveFileDialog saveFile = new SaveFileDialog();
			saveFile.Filter = UIText.SNESROMType;

			if (saveFile.ShowDialog() == DialogResult.OK)
			{
				FileStream fileStream = new FileStream(saveFile.FileName, FileMode.OpenOrCreate, FileAccess.Write);
				fileStream.Write(ROM.DATA, 0, ROM.DATA.Length);
				fileStream.Close();
			}
		}

		public void entrancetreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (!this.projectLoaded)
			{
				return;
			}
			if (e.Node.Parent == null)
			{
				return;
			}

			this.propertiesChangedFromForm = true;
			Entrance entrance = this.selectedEntrance;
			if (e?.Node.Tag != null)
			{
				entrance = DungeonsData.Entrances[(int) e.Node.Tag];
				if (e.Node.Parent?.Name == "StartingEntranceNode")
				{
					entrance = DungeonsData.StartingEntrances[(int) e.Node.Tag];
				}
			}

			this.setEntranceProperties(entrance, entrance.CameraTriggerX, entrance.CameraTriggerY);
		}

		/// <summary>
		///		Called when moving the mouse in the "set entrance position" mode.
		/// </summary>
		/// <param name="mouseX"> The adjusted X mouse position. </param>
		/// <param name="mouseY"> The adjusted Y mouse position. </param>
		public void entrancetreeView_AfterSelect(int mouseX, int mouseY)
		{
			if (!this.projectLoaded)
			{
				return;
			}

			this.propertiesChangedFromForm = true;
			Entrance entrance = this.selectedEntrance;

			// 128 - 383 is the valid X range where the camera can be placed and 112 - 392 is the valid Y range where the camera can be placed.
			// Any less or more than the valid would result in the camera showing outside of the room and the camera not clipping correctly to walls.
			int cameraTriggerX = Utils.Clamp((ushort) mouseX, Constants.CameraTriggerXLow, Constants.CameraTriggerXHigh);
			int cameraTriggerY = Utils.Clamp((ushort) mouseY, Constants.CameraTriggerYLow, Constants.CameraTriggerYHigh);

			// Add 7 so that it rounds correctly one block to the right.
			cameraTriggerX += 7;

			// Limit the positions to multiples of 8.
			cameraTriggerX &= ~0x7;
			cameraTriggerY &= ~0x7;

			// Subtract by one because in vanilla they always seem to end in 0x7 or 0xF.
			cameraTriggerX -= 1;
			cameraTriggerY -= 1;

			this.setEntranceProperties(entrance, cameraTriggerX, cameraTriggerY);
		}

		public void setEntranceProperties(Entrance entrance, int cameraTriggerX, int cameraTriggerY)
		{
			//propertyGrid2.SelectedObject = entrances[(int)e.Node.Tag];
			this.entranceProperty_bg.Checked = false;

			this.EntranceProperties_RoomID.HexValue = entrance.Room;
			this.EntranceProperties_DungeonID.HexValue = entrance.DungeonID;
			this.EntranceProperties_Blockset.HexValue = entrance.Blockset;
			this.EntranceProperties_Music.HexValue = entrance.Music;

			this.EntranceProperties_PlayerX.HexValue = entrance.XPosition;
			this.EntranceProperties_PlayerY.HexValue = entrance.YPosition;
			this.EntranceProperties_CameraY.HexValue = entrance.CameraX;
			this.EntranceProperties_CameraX.HexValue = entrance.CameraY;

			this.EntranceProperties_CameraTriggerX.HexValue = cameraTriggerX;
			this.EntranceProperties_CameraTriggerY.HexValue = cameraTriggerY;

			this.EntranceProperties_FloorSel.SelectedIndex = Constants.FloorNumber.FindFloorIndex(entrance.Floor);

			this.EntranceProperties_Exit.HexValue = entrance.Exit;

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

			if ((entrance.LadderBG & 0x10) == 0x10)
			{
				this.entranceProperty_bg.Checked = true;
			}

			if (this.activeScene.room != null)
			{
				this.selectedEntrance = entrance;
				if (!this.visibleEntranceGFX)
				{
					this.activeScene.room.reloadGfx(entrance.Blockset);
				}
				else
				{
					this.activeScene.room.reloadGfx();
				}

				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
			}

			this.entranceProperty_vscroll.Checked = false;
			this.entranceProperty_hscroll.Checked = false;
			this.entranceProperty_quadbr.Checked = false;
			this.entranceProperty_quadbl.Checked = false;
			this.entranceProperty_quadtl.Checked = false;
			this.entranceProperty_quadtr.Checked = false;

			this.EntranceProperty_BoundaryQN.HexValue = entrance.CameraBoundaryQN;
			this.EntranceProperty_BoundaryFN.HexValue = entrance.CameraBoundaryFN;
			this.EntranceProperty_BoundaryQS.HexValue = entrance.CameraBoundaryQS;
			this.EntranceProperty_BoundaryFS.HexValue = entrance.CameraBoundaryFS;
			this.EntranceProperty_BoundaryQW.HexValue = entrance.CameraBoundaryQW;
			this.EntranceProperty_BoundaryFW.HexValue = entrance.CameraBoundaryFW;
			this.EntranceProperty_BoundaryQE.HexValue = entrance.CameraBoundaryQE;
			this.EntranceProperty_BoundaryFE.HexValue = entrance.CameraBoundaryFE;

			int p = (entrance.Exit & 0x7FFF) >> 1;
			this.doorxTextbox.Text = (p % 64).ToString("X2");
			this.dooryTextbox.Text = (p >> 6).ToString("X2");

			if ((entrance.Scrolling & 0x20) == 0x20)
			{
				this.entranceProperty_hscroll.Checked = true;
			}

			if ((entrance.Scrolling & 0x02) == 0x02)
			{
				this.entranceProperty_vscroll.Checked = true;
			}

			if (entrance.ScrollQuadrant == 0x12) // Bottom right
			{
				this.entranceProperty_quadbr.Checked = true;
			}
			else if (entrance.ScrollQuadrant == 0x02) // Bottom left
			{
				this.entranceProperty_quadbl.Checked = true;
			}
			else if (entrance.ScrollQuadrant == 0x00) // Top left
			{
				this.entranceProperty_quadtl.Checked = true;
			}
			else if (entrance.ScrollQuadrant == 0x10) // Top right
			{
				this.entranceProperty_quadtr.Checked = true;
			}

			this.propertiesChangedFromForm = false;

			this.UpdateEntranceInfos();
		}

		public void sortObject()
		{
			//objectViewer1.BeginUpdate();
			this.objectViewer1.items.Clear();

			if (this.favoriteCheckbox.Checked)
			{
				// Sorting sort;
				string searchText = this.searchTextbox.Text.ToLower();

				// ListView1
				this.objectViewer1.items.AddRange(this.listoftilesobjects
					.Where(x => (x?.name ?? "").ToLower().Contains(searchText))
					.Where(x => Settings.Default.favoriteObjects[x.id] == "true")
					.OrderBy(x => x.id)
					);

				this.panel1.VerticalScroll.Value = 0;
				this.objectViewer1.Refresh();
			}
			else
			{
				// Sorting sort;
				string searchText = this.searchTextbox.Text.ToLower();

				// ListView1
				this.objectViewer1.items.AddRange(this.listoftilesobjects
					.Where(x => (x?.name ?? "").ToLower().Contains(searchText))
					.OrderBy(x => x.id)
					);
				this.objectViewer1.updateSize();
				this.panel1.VerticalScroll.Value = 0;
				this.objectViewer1.Refresh();
			}
		}

		public void sortSprite()
		{
			this.spritesView1.items.Clear();
			string searchText = this.searchspriteTextbox.Text.ToLower();

			this.spritesView1.items.AddRange(this.listofspritesobjects
				.Where(x => (x?.name ?? "").ToLower().Contains(searchText))
				.OrderBy(x => x.id)
				);

			this.customPanel1.VerticalScroll.Value = 0;

			if (searchText == string.Empty)
			{
				this.spritesView1.items.Clear();
				foreach (Sprite sprite in this.listofspritesobjects)
				{
					this.spritesView1.items.Add(sprite);
				}
			}

			this.spritesView1.Refresh();
		}

		private void searchTextbox_TextChanged(object sender, EventArgs e)
		{
			this.sortObject();
			this.objectViewer1.updateSize();
		}

		private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.activeScene.showGrid = this.showGridToolStripMenuItem.Checked;

			// Added refresh here so that the grid will appear when the checkbox is clicked.
			this.activeScene.Refresh();
		}

		private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			if (this.comboBox1.SelectedIndex != -1)
			{
				if (this.comboBox1.SelectedIndex > 0)
				{
					foreach (Sprite sprite in this.activeScene.room.sprites)
					{
						sprite.keyDrop = 0;
					}
				}

				(this.activeScene.room.selectedObject[0] as Sprite).keyDrop = (byte) this.comboBox1.SelectedIndex;
				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
			}
		}

		private void searchspriteTextbox_TextChanged(object sender, EventArgs e)
		{
			this.sortSprite();
		}

		private void selecteditemobjectCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.selecteditemobjectCombobox.SelectedIndex != -1)
			{
				if (this.activeScene.room.selectedObject.Count > 0)
				{
					if (this.activeScene.room.selectedObject[0] is PotItem potItem)
					{
						if (this.selecteditemobjectCombobox.SelectedIndex > 0x16)
						{
							potItem.id = (byte) (0x80 + ((this.selecteditemobjectCombobox.SelectedIndex - 0x17) * 2));
						}
						else
						{
							potItem.id = (byte) this.selecteditemobjectCombobox.SelectedIndex;
						}

						//scene.need_refresh = true;
					}

					this.activeScene.DrawRoom();
					this.activeScene.Refresh();
				}
			}
		}

		public void AddRoomTab(short roomId)
		{
			bool alreadyFound = false;
			foreach (Room room in this.opened_rooms)
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
				foreach (TabPage tabPage in this.tabControl2.TabPages)
				{
					if ((tabPage.Tag as Room).index == roomId)
					{
						this.tabControl2.SelectTab(tabPage);
						break;

						//tp.Select();
					}
				}

				return;
			}
			else
			{
				Room room;
				if (NetZS.connected)
				{
					room = DungeonsData.AllRooms[roomId];
				}
				else
				{
					room = (Room) DungeonsData.AllRooms[roomId].Clone();
				}

				this.opened_rooms.Add(room); // Add the double clicked room into rooms list.
				this.activeScene.room = room;

				//string tn = r.index.ToString("D3");
				//if (showRoomsInHexToolStripMenuItem.Checked)
				//{
				string tn = room.index.ToString("X3");
				//}

				TabPage tabPage = new TabPage(tn);
				tabPage.Tag = room;
				this.tabControl2.TabPages.Add(tabPage);
				//objectsListbox.ClearSelected();
				this.tabControl2.SelectedTab = tabPage;

				if (!this.visibleEntranceGFX)
				{
					this.activeScene.room.reloadGfx(DungeonsData.Entrances[int.Parse(this.entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
				}
				else
				{
					this.activeScene.room.reloadGfx();
				}

				GFX.loadedPalettes = GFX.LoadDungeonPalette(this.activeScene.room.palette);
				GFX.loadedSprPalettes = GFX.LoadSpritesPalette(this.activeScene.room.palette);
				this.activeScene.SetPalettesBlack();
				//paletteViewer.update();
				this.activeScene.DrawRoom();
				this.activeScene.Refresh();

				this.objectViewer1.updateSize();
				this.spritesView1.updateSize();
			}

			if (this.tabControl2.TabPages.Count > 0)
			{
				this.tabControl2.Visible = true;
				activeScene.Refresh();
			}

			this.cgramViewer.Refresh();

			this.activeScene.updateRoomInfos(this);
		}

		private void rightSideToolboxToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.splitContainer3.Panel1.Controls.Clear();
			this.splitContainer3.Panel2.Controls.Clear();

			if (this.rightSideToolboxToolStripMenuItem.Checked)
			{
				//toolboxPanel.Dock = DockStyle.Right;
				//splitter1.Dock = DockStyle.Right;
				this.splitContainer3.Panel2.Controls.Add(this.panel2);
				this.splitContainer3.Panel1.Controls.Add(this.entrancetreeView);
			}
			else
			{
				this.splitContainer3.Panel1.Controls.Add(this.panel2);
				this.splitContainer3.Panel2.Controls.Add(this.entrancetreeView);
				//toolboxPanel.Dock = DockStyle.Left;
				//splitter1.Dock = DockStyle.Left;
			}
		}

		private void entrancetreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Tag != null)
			{
				if (e.Node.Parent == this.entrancetreeView.Nodes[0])
				{
					this.AddRoomTab(DungeonsData.Entrances[(int) e.Node.Tag].Room);
				}
				else
				{
					this.AddRoomTab(DungeonsData.StartingEntrances[(int) e.Node.Tag].Room);
				}
			}
		}

		private void mapPicturebox_MouseDoubleClick_1(object sender, MouseEventArgs e)
		{
			if (HoveredRoom == -1)
			{
				return;
			}

			short roomId = (short) HoveredRoom;

			if (ModifierKeys == Keys.Control)
			{
				if (selectedMapPng.Contains(roomId))
				{
					selectedMapPng.Remove(roomId);
				}
				else
				{
					selectedMapPng.Add(roomId);
				}
			}
			else
			{
				AddRoomTab(roomId);
			}

			mapPicturebox.Refresh();
		}

		public void runtestButton_Click(object sender, EventArgs e)
		{
			this.SaveToolStripMenuItem_Click(this.saveToolStripMenuItem, new EventArgs());
			if (File.Exists(UIText.TestROM))
			{
				File.Delete(UIText.TestROM);
			}

			byte[] data = new byte[ROM.DATA.Length];
			ROM.DATA.CopyTo(data, 0);
			this.SaveToolStripMenuItem_Click(sender, e);
			AsarCLR.Asar.init();

			string ProjectPath = Path.GetDirectoryName(projectFilename);
			if (File.Exists(ProjectPath + "\\Patches\\main.asm"))
			{
				AsarCLR.Asar.patch(Path.GetDirectoryName(this.projectFilename) + "\\Patches\\main.asm", ref data);
			}

			if (File.Exists(ProjectPath + "\\Patches\\generated.asm"))
			{
				AsarCLR.Asar.patch(Path.GetDirectoryName(this.projectFilename) + "\\Patches\\generated.asm", ref data);
			}

			foreach (AsarCLR.Asarerror error in AsarCLR.Asar.geterrors())
			{
				Console.WriteLine(error.Fullerrdata.ToString());
			}

			FileStream fileStream = new FileStream(UIText.TestROM, FileMode.CreateNew, FileAccess.Write);
			fileStream.Write(data, 0, data.Length);
			fileStream.Close();

			if (Settings.Default.emulatorPath == string.Empty)
			{
				Process.Start(UIText.TestROM);
			}
			else
			{
				Process.Start(Settings.Default.emulatorPath, UIText.TestROM);
			}

		}

		private void unselectedBGTransparentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.activeScene.canSelectUnselectedBG = this.unselectedBGTransparentToolStripMenuItem.Checked;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Doors
			if (this.comboBox2.SelectedIndex != -1)
			{
				if (this.activeScene.room.selectedObject.Count == 1)
				{
					if (this.activeScene.room.selectedObject[0] is Room_Object roomObject)
					{
						if (roomObject.options == ObjectOption.Door)
						{
							(roomObject as object_door).door_type = this.DoorIndex[this.comboBox2.SelectedIndex];
							(roomObject as object_door).updateId();
							this.activeScene.room.has_changed = true;
							this.activeScene.DrawRoom();
							this.activeScene.Refresh();
						}
					}
				}
			}
		}

		private void debugtestButton_Click(object sender, EventArgs e)
		{
			//Console.WriteLine(Path.GetDirectoryName(projectFilename));
			//return;
			byte[] data = new byte[ROM.DATA.Length];
			ROM.DATA.CopyTo(data, 0);
			this.SaveToolStripMenuItem_Click(sender, e);

			if (File.Exists(UIText.TestROM))
			{
				File.Delete(UIText.TestROM);
			}

			AsarCLR.Asar.init();

			string ProjectPath = Path.GetDirectoryName(projectFilename);

			if (File.Exists(ProjectPath + "\\Patches\\main.asm"))
			{
				AsarCLR.Asar.patch(Path.GetDirectoryName(this.projectFilename) + "\\Patches\\main.asm", ref data);
			}

			if (File.Exists(ProjectPath + "\\Patches\\generated.asm"))
			{
				AsarCLR.Asar.patch(Path.GetDirectoryName(this.projectFilename) + "\\Patches\\generated.asm", ref data);
			}

			foreach (AsarCLR.Asarerror error in AsarCLR.Asar.geterrors())
			{
				Console.WriteLine(error.Fullerrdata.ToString());
			}

			data[Constants.startingentrance_room + 1] = (byte) (selectedEntrance.Room >> 8);
			data[Constants.startingentrance_room] = (byte) selectedEntrance.Room;

			data[Constants.startingentrance_yposition + 1] = (byte) (selectedEntrance.YPosition >> 8);
			data[Constants.startingentrance_yposition] = (byte) selectedEntrance.YPosition;

			data[Constants.startingentrance_xposition + 1] = (byte) (selectedEntrance.XPosition >> 8);
			data[Constants.startingentrance_xposition] = (byte) selectedEntrance.XPosition;

			data[Constants.startingentrance_camerax + 1] = (byte) (selectedEntrance.CameraX >> 8);
			data[Constants.startingentrance_camerax] = (byte) selectedEntrance.CameraX;

			data[Constants.startingentrance_cameray + 1] = (byte) (selectedEntrance.CameraY >> 8);
			data[Constants.startingentrance_cameray] = (byte) selectedEntrance.CameraY;

			data[Constants.startingentrance_cameraxtrigger + 1] = (byte) (selectedEntrance.CameraTriggerX >> 8);
			data[Constants.startingentrance_cameraxtrigger] = (byte) selectedEntrance.CameraTriggerX;

			data[Constants.startingentrance_cameraytrigger + 1] = (byte) (selectedEntrance.CameraTriggerY >> 8);
			data[Constants.startingentrance_cameraytrigger] = (byte) selectedEntrance.CameraTriggerY;

			data[Constants.startingentrance_exit + 1] = (byte) (selectedEntrance.Exit >> 8);
			data[Constants.startingentrance_exit] = (byte) selectedEntrance.Exit;

			data[Constants.startingentrance_blockset] = (byte) selectedEntrance.Blockset;
			data[Constants.startingentrance_music] = (byte) selectedEntrance.Music;
			data[Constants.startingentrance_dungeon] = (byte) selectedEntrance.DungeonID;
			//data[Constants.startingentrance_door] = (byte) (selectedEntrance.Door;
			data[Constants.startingentrance_floor] = (byte) selectedEntrance.Floor;
			data[Constants.startingentrance_ladderbg] = (byte) selectedEntrance.LadderBG;
			data[Constants.startingentrance_scrolling] = (byte) selectedEntrance.Scrolling;
			data[Constants.startingentrance_scrollquadrant] = (byte) selectedEntrance.ScrollQuadrant;
			data[Constants.startingentrance_scrolledge + 0] = selectedEntrance.CameraBoundaryQN; // 8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
			data[Constants.startingentrance_scrolledge + 1] = selectedEntrance.CameraBoundaryFN;
			data[Constants.startingentrance_scrolledge + 2] = selectedEntrance.CameraBoundaryQS;
			data[Constants.startingentrance_scrolledge + 3] = selectedEntrance.CameraBoundaryFS;
			data[Constants.startingentrance_scrolledge + 4] = selectedEntrance.CameraBoundaryQW;
			data[Constants.startingentrance_scrolledge + 5] = selectedEntrance.CameraBoundaryFW;
			data[Constants.startingentrance_scrolledge + 6] = selectedEntrance.CameraBoundaryQE;
			data[Constants.startingentrance_scrolledge + 7] = selectedEntrance.CameraBoundaryFE;

			FileStream fileStream = new FileStream(UIText.TestROM, FileMode.CreateNew, FileAccess.Write);
			fileStream.Write(data, 0, data.Length);
			fileStream.Close();

			if (Settings.Default.emulatorPath == string.Empty)
			{
				Process.Start(UIText.TestROM);
			}
			else
			{
				Process.Start(Settings.Default.emulatorPath, UIText.TestROM);
			}

			//Process p = Process.Start();
		}

		// TODO: Going away with projects (or being changed drastically).
		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFile = new SaveFileDialog();
			saveFile.DefaultExt = ".sfc";
			saveFile.Filter = "ZScream Project File .sfc|*.sfc";

			if (saveFile.ShowDialog() == DialogResult.OK)
			{
				this.projectFilename = saveFile.FileName;
				ROMStructure.ProjectName = saveFile.FileName;
				this.SaveToolStripMenuItem_Click(sender, e);
				this.saveAs = true;

				this.Text = string.Format("{0} - {1}", UIText.APPNAME, saveFile.FileName);
			}
		}

		private void X8ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.x8ToolStripMenuItem.Checked = false;
			this.x16ToolStripMenuItem.Checked = false;
			this.x32ToolStripMenuItem.Checked = false;
			this.x64ToolStripMenuItem.Checked = false;
			this.x256ToolStripMenuItem.Checked = false;
			(sender as ToolStripMenuItem).Checked = true;
			this.showGridToolStripMenuItem.Checked = true;

			if (this.x8ToolStripMenuItem.Checked)
			{
				this.gridSize = 8;
			}

			if (this.x16ToolStripMenuItem.Checked)
			{
				this.gridSize = 16;
			}

			if (this.x32ToolStripMenuItem.Checked)
			{
				this.gridSize = 32;
			}

			if (this.x64ToolStripMenuItem.Checked)
			{
				this.gridSize = 64;
			}

			if (this.x256ToolStripMenuItem.Checked)
			{
				this.gridSize = 256;
			}

			this.activeScene.showGrid = true;
			this.activeScene.Refresh();
		}

		public void UpdateUIForRoom(Room room, bool prevent = true)
		{
			this.propertiesChangedFromForm = prevent;

			this.roomProperty_bg2.SelectedIndex = (int) room.bg2;
			this.roomProperty_tag1.SelectedIndex = (int) room.tag1;
			this.roomProperty_tag2.SelectedIndex = (int) room.tag2;
			this.roomProperty_effect.SelectedIndex = (int) room.effect;
			this.roomProperty_collision.SelectedIndex = (int) room.collision;

			this.roomProperty_pit.Checked = room.damagepit;
			this.roomProperty_sortsprite.Checked = room.sortsprites;

			this.RoomProperty_Blockset.HexValue = room.blockset;
			this.RoomProperty_SpriteSet.HexValue = room.spriteset;
			this.RoomProperty_Floor1.HexValue = room.floor1;
			this.RoomProperty_Floor2.HexValue = room.floor2;
			this.RoomProperty_MessageID.HexValue = room.messageid;
			this.RoomProperty_Layout.HexValue = room.layout;
			this.RoomProperty_Palette.HexValue = room.palette;

			this.RoomProperty_DestinationPit.HexValue = room.holewarp;
			this.RoomProperty_DestinationStair1.HexValue = room.staircase1;
			this.RoomProperty_DestinationStair2.HexValue = room.staircase2;
			this.RoomProperty_DestinationStair3.HexValue = room.staircase3;
			this.RoomProperty_DestinationStair4.HexValue = room.staircase4;

			this.bg2checkbox1.Checked = room.holewarp_plane == 2;
			this.bg2checkbox2.Checked = room.staircase1Plane == 2;
			this.bg2checkbox3.Checked = room.staircase2Plane == 2;
			this.bg2checkbox4.Checked = room.staircase3Plane == 2;
			this.bg2checkbox5.Checked = room.staircase4Plane == 2;

			this.propertiesChangedFromForm = false;
		}

		public void UpdateRoomInfo()
		{
			if (!this.propertiesChangedFromForm && this.activeScene.room != null)
			{
				this.activeScene.room.bg2 = (Background2) this.roomProperty_bg2.SelectedIndex;
				this.activeScene.room.tag1 = (TagKey) this.roomProperty_tag1.SelectedIndex;
				this.activeScene.room.tag2 = (TagKey) this.roomProperty_tag2.SelectedIndex;
				this.activeScene.room.effect = (EffectKey) this.roomProperty_effect.SelectedIndex;
				this.activeScene.room.collision = (CollisionKey) this.roomProperty_collision.SelectedIndex;

				this.activeScene.room.blockset = (byte) this.RoomProperty_Blockset.HexValue;
				this.activeScene.room.floor1 = (byte) this.RoomProperty_Floor1.HexValue;
				this.activeScene.room.floor2 = (byte) this.RoomProperty_Floor2.HexValue;
				this.activeScene.room.layout = (byte) this.RoomProperty_Layout.HexValue;

				this.activeScene.room.messageid = (short) this.RoomProperty_MessageID.HexValue;
				this.activeScene.room.palette = (byte) this.RoomProperty_Palette.HexValue;

				this.activeScene.room.holewarp = (byte) this.RoomProperty_DestinationPit.HexValue;
				this.activeScene.room.staircase1 = (byte) this.RoomProperty_DestinationStair1.HexValue;
				this.activeScene.room.staircase2 = (byte) this.RoomProperty_DestinationStair2.HexValue;
				this.activeScene.room.staircase3 = (byte) this.RoomProperty_DestinationStair3.HexValue;
				this.activeScene.room.staircase4 = (byte) this.RoomProperty_DestinationStair4.HexValue;

				this.activeScene.room.holewarp_plane = (byte) (this.bg2checkbox1.Checked ? 2 : 0);
				this.activeScene.room.staircase1Plane = (byte) (this.bg2checkbox2.Checked ? 2 : 0);
				this.activeScene.room.staircase2Plane = (byte) (this.bg2checkbox3.Checked ? 2 : 0);
				this.activeScene.room.staircase3Plane = (byte) (this.bg2checkbox4.Checked ? 2 : 0);
				this.activeScene.room.staircase4Plane = (byte) (this.bg2checkbox5.Checked ? 2 : 0);

				this.activeScene.room.damagepit = this.roomProperty_pit.Checked;
				this.activeScene.room.sortsprites = this.roomProperty_sortsprite.Checked;

				this.activeScene.room.spriteset = (byte) this.RoomProperty_SpriteSet.HexValue;

				if (!this.visibleEntranceGFX)
				{
					this.activeScene.room.reloadGfx(DungeonsData.Entrances[int.Parse(this.entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
				}
				else
				{
					this.activeScene.room.reloadGfx();
				}

				/*
                undoRoom[activeScene.room.index].Add((Room)activeScene.room.Clone());
                redoRoom[activeScene.room.index].Clear();
                */

				GFX.loadedPalettes = GFX.LoadDungeonPalette(this.activeScene.room.palette);
				GFX.loadedSprPalettes = GFX.LoadSpritesPalette(this.activeScene.room.palette);
				this.activeScene.SetPalettesBlack();
				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
				this.activeScene.room.has_changed = true;
				this.CheckAnyChanges();
			}
		}

		public void UpdateEntranceInfos()
		{
			if (!this.propertiesChangedFromForm)
			{
				this.selectedEntrance.Blockset = (byte) this.EntranceProperties_Blockset.HexValue;
				this.selectedEntrance.Room = (short) this.EntranceProperties_RoomID.HexValue;

				if (this.EntranceProperties_FloorSel.SelectedIndex >= 0)
				{
					this.selectedEntrance.Floor = (this.EntranceProperties_FloorSel.SelectedItem as Constants.FloorNumber).ByteValue;
				}

				this.selectedEntrance.DungeonID = (byte) this.EntranceProperties_DungeonID.HexValue;
				this.selectedEntrance.Music = (byte) this.EntranceProperties_Music.HexValue;

				this.selectedEntrance.Exit = (byte) this.EntranceProperties_Exit.HexValue;

				this.selectedEntrance.LadderBG = (byte) (this.entranceProperty_bg.Checked ? 0x10 : 0x00);

				this.selectedEntrance.CameraBoundaryQN = (byte) this.EntranceProperty_BoundaryQN.HexValue;
				this.selectedEntrance.CameraBoundaryFN = (byte) this.EntranceProperty_BoundaryFN.HexValue;
				this.selectedEntrance.CameraBoundaryQS = (byte) this.EntranceProperty_BoundaryQS.HexValue;
				this.selectedEntrance.CameraBoundaryFS = (byte) this.EntranceProperty_BoundaryFS.HexValue;
				this.selectedEntrance.CameraBoundaryQW = (byte) this.EntranceProperty_BoundaryQW.HexValue;
				this.selectedEntrance.CameraBoundaryFW = (byte) this.EntranceProperty_BoundaryFW.HexValue;
				this.selectedEntrance.CameraBoundaryQE = (byte) this.EntranceProperty_BoundaryQE.HexValue;
				this.selectedEntrance.CameraBoundaryFE = (byte) this.EntranceProperty_BoundaryFE.HexValue;

				this.selectedEntrance.XPosition = (ushort) this.EntranceProperties_PlayerX.HexValue;
				this.selectedEntrance.YPosition = (ushort) this.EntranceProperties_PlayerY.HexValue;
				this.selectedEntrance.CameraX = (ushort) this.EntranceProperties_CameraY.HexValue;
				this.selectedEntrance.CameraY = (ushort) this.EntranceProperties_CameraX.HexValue;
				this.selectedEntrance.CameraTriggerX = (ushort) this.EntranceProperties_CameraTriggerX.HexValue;
				this.selectedEntrance.CameraTriggerY = (ushort) this.EntranceProperties_CameraTriggerY.HexValue;

				//Console.WriteLine("Pos X: " + EntranceProperties_PlayerX.HexValue.ToString() + " Pos Y: " + EntranceProperties_PlayerY.HexValue.ToString());
				//Console.WriteLine("Camera X: " + EntranceProperties_CameraX.HexValue.ToString() + " Camera Y: " + EntranceProperties_CameraY.HexValue.ToString());
				//Console.WriteLine("Camera trigger X: " + EntranceProperties_CameraTriggerX.HexValue.ToString() + " Camera trigger Y: " + EntranceProperties_CameraTriggerY.HexValue.ToString());

				if (int.TryParse(this.doorxTextbox.Text, NumberStyles.HexNumber, null, out int r))
				{
					if (int.TryParse(this.dooryTextbox.Text, NumberStyles.HexNumber, null, out int rr))
					{
						this.selectedEntrance.Exit = (short) (((rr << 6) + (r & 0x3F)) << 1);
					}
					else
					{
						this.selectedEntrance.Exit = 0;
					}
				}
				else
				{
					this.selectedEntrance.Exit = 0;
				}

				byte b = 0;
				if (this.entranceProperty_hscroll.Checked)
				{
					b |= 0x20;
				}

				if (this.entranceProperty_vscroll.Checked)
				{
					b |= 0x02;
				}

				if (this.entranceProperty_quadbr.Checked) // Bottom right
				{
					this.selectedEntrance.ScrollQuadrant = 0x12;
				}
				else if (this.entranceProperty_quadbl.Checked) // Bottom left
				{
					this.selectedEntrance.ScrollQuadrant = 0x02;
				}
				else if (this.entranceProperty_quadtl.Checked) // Top left
				{
					this.selectedEntrance.ScrollQuadrant = 0x00;
				}
				else if (this.entranceProperty_quadtr.Checked) // Top right
				{
					this.selectedEntrance.ScrollQuadrant = 0x10;
				}

				//if (entranceProperty_quadbl)

				this.selectedEntrance.Scrolling = b;

				GFX.loadedPalettes = GFX.LoadDungeonPalette(this.activeScene.room.palette);
				GFX.loadedSprPalettes = GFX.LoadSpritesPalette(this.activeScene.room.palette);
				this.activeScene.SetPalettesBlack();

				if (!this.visibleEntranceGFX)
				{
					this.activeScene.room.reloadGfx(DungeonsData.Entrances[int.Parse(this.entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
				}
				else
				{
					this.activeScene.room.reloadGfx();
				}

				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
				this.activeScene.room.has_changed = true;

				this.anychange = true;
			}
		}

		public void closeRoom(int index)
		{
			int closedRoom = -1;
			for (int j = 0; j < this.opened_rooms.Count; j++)
			{
				if (this.opened_rooms[j].index == index)
				{
					closedRoom = j;
					break;
				}
			}

			if (closedRoom != -1)
			{
				this.opened_rooms.RemoveAt(closedRoom);
			}
		}

		// TODO: Copy.
		private void CloseTab(int i)
		{
			if (NetZS.connected)
			{
				this.closeRoom((this.tabControl2.TabPages[i].Tag as Room).index);
				this.tabControl2.TabPages.RemoveAt(i);
				if (this.tabControl2.TabPages.Count == 0)
				{
					this.tabControl2.Visible = false;
					this.activeScene.Clear();
					this.activeScene.room = null;
					this.activeScene.Refresh();
				}

				return;
			}

			if (this.tabControl2.TabPages.Count == 1)
			{
				MessageBox.Show("You cannot close all rooms, you must have at least one room opened");
				return;
			}


			if ((this.tabControl2.TabPages[i].Tag as Room).has_changed)
			{
				switch (UIText.WarnAboutSaving(UIText.RoomWarning))
				{
					case DialogResult.Yes:
						DungeonsData.AllRooms[(this.tabControl2.TabPages[i].Tag as Room).index] = (Room) (this.tabControl2.TabPages[i].Tag as Room).Clone();
						this.closeRoom((this.tabControl2.TabPages[i].Tag as Room).index);
						this.tabControl2.TabPages.RemoveAt(i);

						// TODO: This needs to be made a function.
						if (this.tabControl2.TabPages.Count == 0)
						{
							this.activeScene.Clear();
							this.tabControl2.Visible = false;
							this.activeScene.Refresh();
						}

						break;

					case DialogResult.No:
						this.closeRoom((this.tabControl2.TabPages[i].Tag as Room).index);
						this.tabControl2.TabPages.RemoveAt(i);

						if (this.tabControl2.TabPages.Count == 0)
						{
							this.activeScene.Clear();
							this.tabControl2.Visible = false;
							this.activeScene.Refresh();
						}

						break;
				}
			}
			else
			{
				this.closeRoom((this.tabControl2.TabPages[i].Tag as Room).index);
				this.tabControl2.TabPages.RemoveAt(i);
				if (this.tabControl2.TabPages.Count == 0)
				{
					this.tabControl2.Visible = false;
					this.activeScene.Clear();
					this.activeScene.room = null;
					this.activeScene.Refresh();
				}
			}
			mapPicturebox.Refresh();
			this.tabControl2.Refresh();
		}

		private void TabControl2_MouseClick(object sender, MouseEventArgs e)
		{
			//loadRoomList(0);
		}

		private void TabControl2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tabControl2.TabPages.Count > 0)
			{
				this.activeScene.room = this.tabControl2.TabPages[this.tabControl2.SelectedIndex].Tag as Room;
				this.activeScene.updateRoomInfos(this);

				if (DungeonsData.UndoRoom[this.activeScene.room.index].Count > 0)
				{
					this.undoButton.Enabled = true;
					this.undoToolStripMenuItem.Enabled = true;
				}
				else
				{
					// TODO: Is this wrong?
					this.redoButton.Enabled = false;
					this.redoToolStripMenuItem.Enabled = false;
				}

				if (DungeonsData.RedoRoom[this.activeScene.room.index].Count > 0)
				{
					this.redoButton.Enabled = true;
					this.redoToolStripMenuItem.Enabled = true;
				}
				else
				{
					this.redoButton.Enabled = false;
					this.redoToolStripMenuItem.Enabled = false;
				}

				if (!this.visibleEntranceGFX)
				{
					this.activeScene.room.reloadGfx(DungeonsData.Entrances[int.Parse(this.entrancetreeView.SelectedNode.Tag.ToString())].Blockset);
				}
				else
				{
					this.activeScene.room.reloadGfx();
				}

				GFX.loadedPalettes = GFX.LoadDungeonPalette(this.activeScene.room.palette);
				GFX.loadedSprPalettes = GFX.LoadSpritesPalette(this.activeScene.room.palette);
				this.activeScene.SetPalettesBlack();

				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
				this.spritesView1.updateSize();
				this.spritesView1.Refresh();
				this.objectViewer1.updateSize();
				this.objectViewer1.Refresh();
			}
			else
			{
				this.activeScene.Clear();
			}

			this.mapPicturebox.Refresh();
		}

		public void InitObjectsList()
		{
			int index = 0;
			for (int i = 0; i < 0xF8; i++) // Type 1 objects
			{
				Room_Object roomObject = activeScene.room.addObject((short) i, 0, 0, 0, 0);
				roomObject.preview = true;
				roomObject.previewId = index;
				index++;
				roomObject.setRoom(activeScene.room);

				if (roomObject != null)
				{
					//objectsListbox.Items.Add(new dataObject((short)i,i.ToString("X3") +" "+ o.name));
					listoftilesobjects.Add(roomObject);
				}
			}

			for (int i = 0x100; i < 0x140; i++) // Type 2 objects
			{
				Room_Object roomObject = activeScene.room.addObject((short) i, 0, 0, 0, 0);
				roomObject.preview = true;
				roomObject.previewId = index;
				index++;
				roomObject.setRoom(activeScene.room);

				if (roomObject != null)
				{
					//objectsListbox.Items.Add(new dataObject((short)i, i.ToString("X3") + " " + o.name));
					listoftilesobjects.Add(roomObject);
				}
			}

			for (int i = 0xF80; i < 0xFFF; i++) // Type 3 objects
			{
				Room_Object roomObject = activeScene.room.addObject((short) i, 0, 0, 0, 0);
				roomObject.preview = true;
				roomObject.previewId = index;
				index++;
				roomObject.setRoom(activeScene.room);

				if (roomObject != null)
				{
					//objectsListbox.Items.Add(new dataObject((short)i, i.ToString("X3") + " " + o.name));
					listoftilesobjects.Add(roomObject);
				}
			}

			for (int i = 0; i < 0xF2; i++)
			{
				Sprite sprite = new Sprite(activeScene.room, (byte) i, 0, 0, 0, 0);
				sprite.preview = true;
				listofspritesobjects.Add(sprite);
			}

			for (int i = 1; i < 0x1B; i++)
			{
				Sprite sprite = new Sprite(activeScene.room, (byte) i, 0, 0, 7, 0);
				sprite.preview = true;
				listofspritesobjects.Add(sprite);
			}

			//sortObject();
		}

		private void objectViewer1_SelectedIndexChanged(object sender, EventArgs e)
		{
			activeScene.selectedDragObject = new SelectedObject(objectViewer1.selectedObject.id, objectViewer1.selectedObject.name);
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.objectViewer1.updateSize();
			this.spritesView1.updateSize();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			this.objectViewer1.showName = this.showNameObjectCheckbox.Checked;
			this.objectViewer1.updateSize();
			this.objectViewer1.Refresh();
		}

		// TODO: Merge identical events.
		private void entranceProperty_room_TextChanged(object sender, EventArgs e)
		{
			this.UpdateEntranceInfos();
		}

		private void entranceProperty_vscroll_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdateEntranceInfos();
		}

		private void entranceProperty_quadtl_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdateEntranceInfos();
		}

		private void spritesView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.activeScene.selectedDragSprite = new SelectedObject(spritesView1.selectedObject.id, spritesView1.selectedObject.name, spritesView1.selectedObject.subtype);
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			// Check what's the higher map and the left most, we don't care about right bottom.

			//(map / 16) = Y position
			//map - (Y*16) = X position
			int lowerX = 16; // What we need to remove from the image to the left.
			int lowerY = 16; // What we need to remove from the image to the right.
			int higherX = 0; // What we need to remove from the image to the left.
			int higherY = 0; // What we need to remove from the image to the right.
			Room savedRoom = this.activeScene.room;
			this.activeScene.forPreview = true;

			if (this.selectedMapPng.Count > 0)
			{
				Bitmap bitmap = new Bitmap(8192, 10752);

				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					foreach (short s in this.selectedMapPng)
					{
						if (s < DungeonsData.AllRooms.Length && DungeonsData.AllRooms[s] != null)
						{
							int cy = s / 16;
							int cx = s - (cy * 16);
							if (cx < lowerX)
							{
								lowerX = cx;
							}

							if (cy < lowerY)
							{
								lowerY = cy;
							}

							if (cx > higherX)
							{
								higherX = cx;
							}

							if (cy > higherY)
							{
								higherY = cy;
							}

							this.activeScene.room = DungeonsData.AllRooms[s];
							this.activeScene.room.reloadGfx();
							GFX.loadedPalettes = GFX.LoadDungeonPalette(this.activeScene.room.palette);
							GFX.loadedSprPalettes = GFX.LoadSpritesPalette(this.activeScene.room.palette);
							this.activeScene.DrawRoom();

							this.activeScene.Refresh();

							graphics.DrawImage(this.activeScene.tempBitmap, new Point(cx * 512, cy * 512));
							//activeScene.DrawToBitmap(b, new Rectangle(cx * 512, cy * 512, 512, 512));
						}
					}
				}

				int image_size_x = ((higherX - lowerX) * 512) + 512;
				int image_size_y = ((higherY - lowerY) * 512) + 512;
				int image_start_x = lowerX * 512;
				int image_start_y = lowerY * 512;
				Bitmap bitmap2 = new Bitmap(image_size_x, image_size_y);

				using (Graphics graphics = Graphics.FromImage(bitmap2))
				{
					graphics.DrawImage(bitmap, 0, 0, new Rectangle(image_start_x, image_start_y, image_size_x, image_size_y), GraphicsUnit.Pixel);
				}

				// TODO: Better names so we can have more than 1 map.
				bitmap2.Save("MapTest.png");
				bitmap.Dispose();
				bitmap = null;
				bitmap2.Dispose();
				bitmap2 = null;
			}
			else
			{
				Bitmap bitmap = new Bitmap(512, 512);
				this.activeScene.DrawToBitmap(bitmap, Constants.Rect_0_0_512_512);
				bitmap.Save("singlemap.png");
			}

			this.activeScene.forPreview = false;
			this.activeScene.room = savedRoom;
			this.activeScene.room.reloadGfx();
			GFX.loadedPalettes = GFX.LoadDungeonPalette(this.activeScene.room.palette);
			GFX.loadedSprPalettes = GFX.LoadSpritesPalette(this.activeScene.room.palette);
			this.activeScene.DrawRoom();
			this.activeScene.Refresh();
		}

		private void litCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			//if (activeScene.updating_info && activeScene.room.selectedObject[0] is Room_Object robj)
			//{
			Room_Object roomObject = (Room_Object) this.activeScene.room.selectedObject[0];
			roomObject.lit = this.litCheckbox.Checked;
			//}
		}

		// TODO: Move to constants.
		private void PatchNotesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/Zarby89/ZScreamDungeon/blob/master/ZeldaFullEditor/PatchNotes.txt");
		}

		private void SpritesubtypeUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (!this.activeScene.updating_info)
			{
				if (this.activeScene.room.selectedObject.Count != 0 && this.activeScene.room.selectedObject[0] is Sprite sprite)
				{
					sprite.subtype = (byte) this.spritesubtypeUpDown.Value;
				}

				Console.WriteLine("WTF?!?!?");
			}
		}

		private void GotoRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GotoRoom gotoRoom = new GotoRoom();
			if (gotoRoom.ShowDialog() == DialogResult.OK)
			{
				this.AddRoomTab((short) gotoRoom.SelectedRoom);
			}
		}

		private void AdvancedChestEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AdvancedChestEditorForm chestEditorForm = new AdvancedChestEditorForm();
			chestEditorForm.ShowDialog();
		}

		private static Pen SelectedRoomOutline = new Pen(Settings.Default.SelectedRoomOutline, Settings.Default.SelectedRoomOutlineSize);
		private static Pen OpenedRoomOutline = new Pen(Settings.Default.OpenedRoomOutline, Settings.Default.OpenedRoomOutlineSize);
		private static Pen ExportedRoomOutline = new Pen(Settings.Default.ExportedRoomOutline, Settings.Default.ExportedRoomOutlineSize);
		private static Pen OpenedExportedRoomOutline = new Pen(Settings.Default.OpenedExportedRoomOutline, Settings.Default.ExportedRoomOutlineSize);

		private static void updatePensColors()
		{
            SelectedRoomOutline = new Pen(Settings.Default.SelectedRoomOutline, Settings.Default.SelectedRoomOutlineSize);
			OpenedRoomOutline = new Pen(Settings.Default.OpenedRoomOutline, Settings.Default.OpenedRoomOutlineSize);
			ExportedRoomOutline = new Pen(Settings.Default.ExportedRoomOutline, Settings.Default.ExportedRoomOutlineSize);
			OpenedExportedRoomOutline = new Pen(Settings.Default.OpenedExportedRoomOutline, Settings.Default.OpenedExportedRoomOutlineSize);
		}

		private void MapPicturebox_Paint(object sender, PaintEventArgs e)
		{
			if (!projectLoaded)
			{
				return;
			}

			int xd = 0;
			int yd = 0;
			int yoff = 0;
			e.Graphics.Clear(SystemColors.ScrollBar);

			var selectedRoomID = (tabControl2.SelectedTab.Tag as Room)?.RoomID ?? -999;

			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				var room = DungeonsData.AllRooms[i];

				bool roomOpened = opened_rooms.Any(r => r.RoomID == room.RoomID);

				int alpha = roomOpened ? 255 : (HoveredRoom == i) ? 210 : 140;

				var boxColor = new SolidBrush(Color.FromArgb(alpha, room.IsEmpty ? Color.Black : room.RoomColor));

				e.Graphics.FillRectangle(boxColor, new Rectangle(xd, yd + yoff, 16, 16));
				e.Graphics.DrawRectangle(Pens.LightSlateGray, new Rectangle(xd, yd + yoff, 16, 16));

				Pen outline;

				if (selectedRoomID == room.RoomID)
				{
					outline = SelectedRoomOutline;
				}
				else
				{
					bool roomSelected = selectedMapPng.Contains(room.RoomID);
					if (roomOpened)
					{
						if (roomSelected)
						{
							outline = OpenedExportedRoomOutline;
						}
						else
						{
							outline = OpenedRoomOutline;
						}
					}
					else if (roomSelected)
					{
						outline = ExportedRoomOutline;
					}
					else
					{
						outline = null;
					}
				}

				if (outline != null)
				{
					e.Graphics.DrawRectangle(outline, xd + 1, yd + yoff + 1, 14, 14);
				}

				xd += 16;
				if (xd == 16 * 16)
				{
					yd += 16;
					yoff = (yd > 15 * 16) ? 8 : 0;
					xd = 0;
				}
			}
		}

		//			for (int i = 0; i < 16; i++)
		//			{
		//				e.Graphics.DrawLine(Pens.White, 0, i * 16, 256, i * 16);
		//				e.Graphics.DrawLine(Pens.White, i * 16, 0, i * 16, 256);
		//
		//				e.Graphics.DrawLine(Pens.White, i * 16, 264, i * 16, 312);
		//			}
		//
		//			for (int i = 0; i < 3; i++)
		//			{
		//				e.Graphics.DrawLine(Pens.White, 0, 264 + (i * 16), 256, 264 + (i * 16));
		//			}
		//
		//			for (int i = 0; i < Constants.NumberOfRooms; i++)
		//			{
		//				yoff = (i >= 256) ? 8 : 0;
		//
		//				foreach (TabPage tabPage in this.tabControl2.TabPages)
		//				{
		//					if ((tabPage.Tag as Room).index == (short) i)
		//					{
		//						e.Graphics.DrawRectangle(
		//								new Pen((this.tabControl2.SelectedTab == tabPage) ? Color.YellowGreen : Color.DarkGreen, 2),
		//								new Rectangle((i % 16) * 16, ((i / 16) * 16) + yoff, 16, 16));
		//					}
		//				}
		//			}

		private void HideSpritesToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
		{
			this.showSprite = this.hideSpritesToolStripMenuItem.Checked;
			this.showChest = this.hideChestItemsToolStripMenuItem.Checked;
			this.showItems = this.hideItemsToolStripMenuItem.Checked;
			this.showDoorsIDs = this.showDoorIDsToolStripMenuItem.Checked;
			this.showChestIDs = this.showChestsIDsToolStripMenuItem.Checked;
			this.showStairIDs = this.showStairIndexToolStripMenuItem.Checked;
			this.showSpriteText = this.textSpriteToolStripMenuItem.Checked;
			this.showChestText = this.textChestItemToolStripMenuItem.Checked;
			this.showItemsText = this.textPotItemToolStripMenuItem.Checked;
			this.visibleEntranceGFX = this.disableEntranceGFXToolStripMenuItem.Checked;
			this.x2zoom = this.xScreenToolStripMenuItem.Checked;

			if (this.x2zoom)
			{
				this.activeScene.Size = Constants.Size1024x1024;
				this.panel3.Location = new Point(1032, -1);
			}
			else
			{
				this.activeScene.Size = Constants.Size512x512;
				this.panel3.Location = new Point(520, -1);
			}

			this.activeScene.Refresh();
		}

		private void DungeonsPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Gui.DungeonPropertiesForm propertiesEditorForm = new Gui.DungeonPropertiesForm();
			propertiesEditorForm.ShowDialog();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (this.tabControl2.SelectedIndex != -1)
			{
				this.tabControl2.TabPages.RemoveAt(this.tabControl2.SelectedIndex);
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				const int WS_EX_COMPOSITED = 0x02000000;
				var createParams = base.CreateParams;
				createParams.ExStyle |= WS_EX_COMPOSITED;
				return createParams;
			}
		}

		private void PrintRoomObjectsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Room_Object roomObject in this.activeScene.room.tilesObjects)
			{
				if (roomObject.options == ObjectOption.Door)
				{
					if (roomObject is object_door doorObject)
					{
						Console.WriteLine($"n:{doorObject.name}door dir:{doorObject.door_dir}, door pos:{doorObject.door_pos}, door type:{doorObject.door_type}");
					}
				}
				else
				{
					Console.WriteLine($"n:{roomObject.name}, w:{roomObject.width}, h:{roomObject.height}, L:{roomObject.Layer}");
				}
			}
		}

		// TODO KAN REFACTOR replace the string based room object association with accessible member variables to represent object properties.
		private void RemoveMasksObjectsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<Room_Object> toRemove = new List<Room_Object>();
			foreach (Room_Object roomObject in this.activeScene.room.tilesObjects)
			{
				if (roomObject.name.ToLower().Contains("bg2"))
				{
					toRemove.Add(roomObject);
				}
				else if (roomObject.name.ToLower().Contains("mask"))
				{
					toRemove.Add(roomObject);
				}

				if (roomObject.id >= 0xA9 && roomObject.id <= 0xAC)
				{
					toRemove.Add(roomObject);
				}
			}

			foreach (Room_Object roomObject in toRemove)
			{
				this.activeScene.room.tilesObjects.Remove(roomObject);
			}
		}

		private void GotoRoomToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			GotoRoom gotoRoom = new GotoRoom();
			if (gotoRoom.ShowDialog() == DialogResult.OK)
			{
				this.AddRoomTab((short) gotoRoom.SelectedRoom);
			}
		}

		private void ClearSelectedRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.activeScene.room.tilesObjects.Clear();
			this.activeScene.room.pot_items.Clear();
			this.activeScene.room.sprites.Clear();
			this.activeScene.room.chest_list.Clear();
			this.activeScene.DrawRoom();
			this.activeScene.Refresh();
		}

		private void ClearAllRoomsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to clear every room's data?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				foreach (Room room in DungeonsData.AllRooms)
				{
					room.tilesObjects.Clear();
					room.pot_items.Clear();
					room.sprites.Clear();
					room.chest_list.Clear();
				}

				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
			}
		}

		private void MouseEntranceButton_Click(object sender, EventArgs e)
		{
			this.settingEntrance = true;
			this.activeScene.mouse_down = false;
			this.activeScene.selectedDragObject = null;
			this.activeScene.selectedDragSprite = null;
			this.activeScene.room.selectedObject.Clear();
			this.activeScene.selectedMode = ObjectMode.EntrancePlacing;
		}

		private void ExportAsASMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog saveFile = new SaveFileDialog())
			{
				saveFile.Filter = UIText.ExportedRoomDataType;
				if (saveFile.ShowDialog() == DialogResult.OK)
				{
					FileStream fileStream = new FileStream(saveFile.FileName, FileMode.OpenOrCreate, FileAccess.Write);
					byte[] roomdata = this.activeScene.room.getTilesBytes();
					fileStream.Write(roomdata, 0, roomdata.Length);
					fileStream.Close();
				}
			}
		}

		private void VRAMViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.vramViewer = new VramViewer();
			WindowPanel windowPanel = new WindowPanel();
			windowPanel.Location = Constants.Point_512_0;
			windowPanel.containerPanel.Controls.Add(this.vramViewer);
			windowPanel.Tag = "VRAM Viewer";
			windowPanel.Size = new Size(this.vramViewer.Size.Width + 2, this.vramViewer.Size.Height + 26);
			this.customPanel3.Controls.Add(windowPanel);
			windowPanel.BringToFront();
		}

		private void ShowBG2MaskOutlineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.activeScene.showBG2Outline = this.showBG2MaskOutlineToolStripMenuItem.Checked;
			this.activeScene.Refresh();
		}

		private void EntranceCameraToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.activeScene.Refresh();
		}

		private void EntrancePositionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.activeScene.Refresh();
		}

		// TODO: Delete when projects.
		private void LoadNamesFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFile = new OpenFileDialog())
			{
				openFile.Filter = "Default Names .txt|*.txt";
				if (openFile.ShowDialog() == DialogResult.OK)
				{
					Sprites_Names.loadFromFile(openFile.FileName);
					Room_Name.loadFromFile(openFile.FileName);
					ChestItems_Name.loadFromFile(openFile.FileName);
					ItemsNames.loadFromFile(openFile.FileName);
					this.selecteditemobjectCombobox.Items.Clear();

					for (int i = 0; i < ItemsNames.name.Length; i++)
					{
						this.selecteditemobjectCombobox.Items.Add(ItemsNames.name[i]);
					}
				}
			}
		}

		// TODO: Simplify and stuff, etc.
		private void CGRAMViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.cgramViewer = new CGRamViewer();
			WindowPanel windowPanel = new WindowPanel();
			windowPanel.Tag = "CGRAM Viewer - Right click to export palettes";
			windowPanel.Location = Constants.Point_512_0;
			windowPanel.containerPanel.Controls.Add(this.cgramViewer);
			windowPanel.Size = new Size(this.cgramViewer.Size.Width + 2, this.cgramViewer.Size.Height + 26);
			this.customPanel3.Controls.Add(windowPanel);
			windowPanel.BringToFront();
		}

		private void GFXGroupsetsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.editorsTabControl.SelectedTab.Name == "dungeonPage")
			{
				WindowPanel windowPanel = new WindowPanel();
				windowPanel.Tag = "Gfx Groupset Editor";
				windowPanel.Location = Constants.Point_512_0;
				windowPanel.containerPanel.Controls.Add(this.gfxGroupsForm);
				windowPanel.Size = new Size(this.gfxGroupsForm.Size.Width + 2, this.gfxGroupsForm.Size.Height + 26);
				this.customPanel3.Controls.Add(windowPanel);
				windowPanel.BringToFront();
			}
			else if (this.editorsTabControl.SelectedTab.Name == "overworldPage")
			{
				WindowPanel windowPanel = new WindowPanel();
				windowPanel.Tag = "GFX Groups Editor";
				windowPanel.Location = Constants.Point_512_0;
				windowPanel.containerPanel.Controls.Add(new GfxGroupsForm(this));
				windowPanel.Size = new Size(this.gfxGroupsForm.Size.Width + 2, this.gfxGroupsForm.Size.Height + 26);
				this.overworldEditor.splitContainer1.Panel2.Controls.Add(windowPanel);
				windowPanel.BringToFront();
			}
		}

		private void InsertToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			this.activeScene.mouse_down = false;
			this.activeScene.insertNew();
		}

		private void InsertToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.activeScene.mouse_down = false;
			this.activeScene.insertNew();
		}

		private void InsertToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			this.activeScene.mouse_down = false;
			this.activeScene.insertNew();
		}

		// This is called when the delete option in the chest item editor option is selected.
		private void DeleteToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			this.activeScene.mouse_down = false;

			if (this.activeScene.selectedMode == ObjectMode.Chestmode)
			{
				this.activeScene.deleteChestItem();
			}
			else if (this.activeScene.selectedMode == ObjectMode.CollisionMap)
			{
				this.activeScene.deleteCollisionMapTile();
			}
		}

		private void PalettesEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.editorsTabControl.SelectedTab.Name == "dungeonPage" || this.editorsTabControl.SelectedTab.Name == "overworldPage")
			{
				WindowPanel windowPanel = new WindowPanel();
				windowPanel.Tag = "Palettes Editor";
				windowPanel.Location = Constants.Point_512_0;
				windowPanel.Size = new Size(this.paletteForm.Size.Width + 2, this.paletteForm.Size.Height + 26);

				if (this.editorsTabControl.SelectedTab.Name == "dungeonPage")
				{
					windowPanel.containerPanel.Controls.Add(this.paletteForm);
					this.customPanel3.Controls.Add(windowPanel);
				}
				else
				{
					windowPanel.containerPanel.Controls.Add(new PaletteEditor(this));
					this.overworldEditor.splitContainer1.Panel2.Controls.Add(windowPanel);
				}

				this.paletteForm.BringToFront();
				windowPanel.BringToFront();
			}
		}

		// Export Palette to YY-CHR Palette Format

		private void DrawOnTab(object sender, DrawItemEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Font font = (sender as TabControl).Font;
			SolidBrush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
			SolidBrush solidBrush = new SolidBrush(Color.FromKnownColor(KnownColor.ControlLight));

			if (this.tpHotTracked == e.Index || e.State == DrawItemState.Selected)
			{
				graphics.FillRectangle(solidBrush, e.Bounds);
				graphics.DrawString(this.tabControl2.TabPages[e.Index].Text, font, Brushes.Blue, new Rectangle(e.Bounds.X, e.Bounds.Y + 2, 64, 24));

				if (this.tpHotTrackedToClose == e.Index)
				{
					graphics.DrawImage(this.xTabButton, new Rectangle(e.Bounds.X + 30, e.Bounds.Y, 16, 16), 16, 0, 16, 16, GraphicsUnit.Pixel);
				}
				else
				{
					graphics.DrawImage(this.xTabButton, new Rectangle(e.Bounds.X + 30, e.Bounds.Y, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel);
				}

				//g.DrawString("000", font, Brushes.Blue, new Rectangle(e.Bounds.X, e.Bounds.Y + 4, 64, 24));
			}
			else
			{
				graphics.FillRectangle(brush, e.Bounds);
				graphics.DrawString(this.tabControl2.TabPages[e.Index].Text, font, Brushes.Black, new Rectangle(e.Bounds.X, e.Bounds.Y + 2, 64, 24));
			}

			brush.Dispose();
			solidBrush.Dispose();
		}

		private void TabControl2_MouseMove(object sender, MouseEventArgs e)
		{
			this.tpHotTrackedToClose = -1;
			for (int i = 0; i < this.tabControl2.TabPages.Count; i++)
			{
				Rectangle itemRect = this.tabControl2.GetTabRect(i);

				if (itemRect.Contains(e.Location))
				{
					Rectangle xRect = this.tabControl2.GetTabRect(i);
					xRect.X += 30;
					xRect.Width = 16;

					this.tpHotTracked = i;
					if (xRect.Contains(e.Location))
					{
						this.tpHotTrackedToClose = i;
					}

					//tabControl2.TabPages[i].Refresh();
				}
			}

			if (this.lasttpHotTracked != this.tpHotTracked || this.tpHotTrackedToCloseLast != this.tpHotTrackedToClose)
			{
				this.tabControl2.Refresh();
			}

			this.tpHotTrackedToCloseLast = this.tpHotTrackedToClose;
			this.lasttpHotTracked = this.tpHotTracked;
		}

		private void TabControl2_MouseLeave(object sender, EventArgs e)
		{
			this.tpHotTracked = -1;
			this.lasttpHotTracked = -2;
			this.tpHotTrackedToClose = -1;
			this.tpHotTrackedToCloseLast = -2;
			this.tabControl2.Refresh();
		}

		private void TabControl2_MouseEnter(object sender, EventArgs e)
		{
			this.tpHotTracked = -1;
			this.lasttpHotTracked = -2;
			this.tpHotTrackedToClose = -1;
			this.tpHotTrackedToCloseLast = -2;
			this.tabControl2.Refresh();
		}

		private void TabControl2_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Middle)
			{
				for (int i = 0; i < this.tabControl2.TabCount; i++)
				{
					Rectangle r = this.tabControl2.GetTabRect(i);
					if (r.Contains(e.Location))
					{
						this.CloseTab(i);
					}
				}
			}
			else if (e.Button == MouseButtons.Left)
			{
				if (this.tpHotTrackedToClose != -1)
				{
					int ctab = this.tpHotTrackedToClose;
					if (this.tpHotTrackedToClose == this.tabControl2.SelectedIndex)
					{
						this.tpHotTrackedToClose = -1;
						this.tabControl2.SelectedIndex = 0;
					}

					this.CloseTab(ctab);
				}
			}
		}

		private void TabControl2_Deselecting(object sender, TabControlCancelEventArgs e)
		{
			if (this.tpHotTrackedToClose != -1)
			{
				e.Cancel = true;
			}
		}

		private void MapPicturebox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				rightClickingRoom = true;
                RecalculateHoveredRoom(e);
                RedrawPreviewRoom();
			}
			else if (e.Button == MouseButtons.Middle)
			{
				for(int i = 0; i < tabControl2.TabPages.Count; i++)
				{
					if ((tabControl2.TabPages[i].Tag as Room).index == HoveredRoom) 
					{
						CloseTab(i);
                        break; 
					}
				}
            }
			mapPicturebox.Refresh();
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
			if (this.previewRoom == null)
			{
				return;
			}

			//Tile t = new Tile(0, false, false, 0, 0);
			//t.Draw(0, 0);
			this.ClearBgGfx(); // Technically not required.

			this.previewRoom.DrawFloor1();

			if (this.previewRoom.bg2 != Background2.Off)
			{
				this.SetPalettesTransparent();
				this.previewRoom.DrawFloor2();
			}
			else
			{
				this.SetPalettesBlack();
			}

			this.previewRoom.reloadLayout();
			foreach (Room_Object roomObject in this.previewRoom.tilesLayoutObjects)
			{
				roomObject.Draw();
			}

			// Draw object on bitmap.
			foreach (Room_Object roomObject in this.previewRoom.tilesObjects)
			{
				// TODO: Can these ifs be merged?
				if (roomObject.Layer != LayerType.BG3)
				{
					roomObject.Draw();
				}
				else if (roomObject.options == ObjectOption.Door)
				{
					roomObject.Draw();
				}
			}

			foreach (Room_Object roomObject in this.previewRoom.tilesObjects)
			{
				// Draw doors here since they'll all be put on bg3 anyways.
				if (roomObject.Layer == LayerType.BG3)
				{
					roomObject.Draw();
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

		private void ThumbnailBox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.Bilinear;
			e.Graphics.Clear(Color.Black);
			if (this.previewRoom.bg2 != Background2.Translucent || this.previewRoom.bg2 != Background2.Transparent ||
				this.previewRoom.bg2 != Background2.OnTop || this.previewRoom.bg2 != Background2.Off)
			{
				e.Graphics.DrawImage(GFX.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			}

			//e.Graphics.DrawImage(GFX.roomBgLayoutBitmap,0,0);
			e.Graphics.DrawImage(GFX.roomBg1Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);

			if (this.previewRoom.bg2 == Background2.Translucent || this.previewRoom.bg2 == Background2.Transparent)
			{
				float[][] matrixItems =
				{
				   new float[] { 1f, 0, 0, 0, 0 },
				   new float[] { 0, 1f, 0, 0, 0 },
				   new float[] { 0, 0, 1f, 0, 0 },
				   new float[] { 0, 0, 0, 0.5f, 0 },
				   new float[] { 0, 0, 0, 0, 1 },
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
			else if (this.previewRoom.bg2 == Background2.OnTop)
			{
				e.Graphics.DrawImage(GFX.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			}

			this.activeScene.drawText(e.Graphics, 0, 0, $"ROOM: {previewRoom.index:X2}");
		}

		private void MapPicturebox_MouseUp(object sender, MouseEventArgs e)
		{
			rightClickingRoom = false;
			thumbnailBox.Visible = maphoverCheckbox.Checked;
		}

		private void RecalculateHoveredRoom(MouseEventArgs e)
		{
			HoveredRoom = -1;

			int yc = e.Y;

			if (yc >= 256)
			{
				if (yc <= 264)
				{
					return;
				}

				yc -= 8;
			}

			HoveredRoom = (e.X / 16) + (yc & ~0xF);

			if (HoveredRoom >= Constants.NumberOfRooms)
			{
				HoveredRoom = -1;
			}
		}


		private void MapPicturebox_MouseMove(object sender, MouseEventArgs e)
		{
			RecalculateHoveredRoom(e);

			if (HoveredRoom == -1)
			{
				thumbnailBox.Visible = false;
				mapPicturebox.Refresh();
				return;
			}

			if (lastRoomID != HoveredRoom)
			{
				RedrawPreviewRoom();
			}

			lastRoomID = HoveredRoom;

			mapPicturebox.Refresh();
		}

		private void RedrawPreviewRoom()
		{
			if (HoveredRoom == -1)
			{
				thumbnailBox.Visible = false;
				return;
			}

			if (!(thumbnailBox.Visible = maphoverCheckbox.Checked | rightClickingRoom))
			{
				return;
			}

			previewRoom = DungeonsData.AllRooms[HoveredRoom];
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


		private void MapPicturebox_MouseLeave(object sender, EventArgs e)
		{
			HoveredRoom = -1;
			thumbnailBox.Visible = false;
			rightClickingRoom = false;
			mapPicturebox.Refresh();
		}

		private void openRightRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (activeScene.room != null)
			{
				int id = activeScene.room.index + 1;
				if (id < Constants.NumberOfRooms)
				{
					AddRoomTab((short) id);
				}
				else
				{
					AddRoomTab(0);
				}
			}
		}

		private void OpenLeftRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.activeScene.room != null)
			{
				int id = this.activeScene.room.index - 1;
				if (id >= 0)
				{
					this.AddRoomTab((short) id);
				}
				else
				{
					this.AddRoomTab(295);
				}
			}
		}

		private void OpenUpRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.activeScene.room != null)
			{
				int id = this.activeScene.room.index - 16;
				if (id >= 0)
				{
					this.AddRoomTab((short) id);
				}
				else
				{
					if (304 + id > 295)
					{
						this.AddRoomTab(295);
					}
					else
					{
						this.AddRoomTab((short) (304 + id));
					}
				}
			}
		}

		private void OpenDownRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.activeScene.room != null)
			{
				int id = this.activeScene.room.index + 16;
				if (id < Constants.NumberOfRooms)
				{
					this.AddRoomTab((short) id);
				}
				else
				{
					if (id > 304)
					{
						this.AddRoomTab((short) (id - 304));
					}
					else
					{
						this.AddRoomTab((short) (id - 288));
					}
				}
			}
		}

		private void DungeonMain_LocationChanged(object sender, EventArgs e)
		{
			this.Refresh();
		}

		// TODO: :cry:
		private void EditorsTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			// copyToolStripMenuItem
			if (this.editorsTabControl.SelectedTab.Name == "textPage")
			{
				this.textEditor.BringToFront();
				this.textEditor.Visible = true;
			}
			else
			{
				this.textEditor.Visible = false;
			}

			if (this.editorsTabControl.SelectedTab.Name == "dungeonPage")
			{
				this.toolStrip1.Visible = true;
				this.panel1.Visible = true;
				this.toolboxPanel.Visible = true;
				this.customPanel3.Visible = true;
				this.headerGroupbox.Visible = true;
				this.tabControl2.Visible = true;

				this.roomToolStripMenuItem.Visible = true;
				this.dungeonViewToolStripMenuItem.Visible = true;
				this.naviguateToolStripMenuItem.Visible = true;

				this.toolStripSeparator6.Visible = true;
				this.moveFrontToolStripMenuItem.Visible = true;
				this.bringToBackToolStripMenuItem.Visible = true;

				this.toolStripSeparator9.Visible = true;
				this.selectAllRoomsForExportToolStripMenuItem.Visible = true;
				this.deselectedAllRoomsForExportToolStripMenuItem.Visible = true;

				this.toolStripSeparator7.Visible = true;
				this.increaseObjectSizeToolStripMenuItem.Visible = true;
				this.decreaseObjectSizeToolStripMenuItem.Visible = true;
			}
			else
			{
				this.toolStrip1.Visible = false;
				this.panel1.Visible = false;
				this.toolboxPanel.Visible = false;
				this.customPanel3.Visible = false;
				this.headerGroupbox.Visible = false;
				this.tabControl2.Visible = false;

				this.roomToolStripMenuItem.Visible = false;
				this.dungeonViewToolStripMenuItem.Visible = false;
				this.naviguateToolStripMenuItem.Visible = false;

				this.toolStripSeparator6.Visible = false;
				this.moveFrontToolStripMenuItem.Visible = false;
				this.bringToBackToolStripMenuItem.Visible = false;

				this.toolStripSeparator9.Visible = false;
				this.selectAllRoomsForExportToolStripMenuItem.Visible = false;
				this.deselectedAllRoomsForExportToolStripMenuItem.Visible = false;

				this.toolStripSeparator7.Visible = false;
				this.increaseObjectSizeToolStripMenuItem.Visible = false;
				this.decreaseObjectSizeToolStripMenuItem.Visible = false;
			}

			if (this.editorsTabControl.SelectedTab.Name == "objDesignerPage")
			{
				//objDesigner.BringToFront();
				//objDesigner.Visible = true;
			}
			else
			{
				this.objDesigner.Visible = false;
			}

			if (this.editorsTabControl.SelectedTab.Name == "overworldPage")
			{
				if (this.oweditor2 != null)
				{
					if (this.oweditor2.overworld.IsLoaded)
					{
						this.oweditor2.BringToFront();
						this.oweditor2.Visible = true;

						this.overworldViewToolStripMenuItem.Visible = true;
						this.overworldToolStripMenuItem.Visible = true;
						this.areaToolStripMenuItem.Visible = true;

						this.toolStripSeparator10.Visible = true;
						this.lockoverworldToolStripItem.Visible = true;
					}
					else
					{
						this.editorsTabControl.SelectedIndex = 0;
					}
				}
				else
				{
					if (this.overworldEditor.overworld.IsLoaded)
					{
						this.overworldEditor.BringToFront();
						this.overworldEditor.Visible = true;

						this.overworldViewToolStripMenuItem.Visible = true;
						this.overworldToolStripMenuItem.Visible = true;
						this.areaToolStripMenuItem.Visible = true;

						this.toolStripSeparator10.Visible = true;
						this.lockoverworldToolStripItem.Visible = true;
					}
					else
					{
						this.editorsTabControl.SelectedIndex = 0;
					}
				}
			}
			else
			{
				this.overworldEditor.Visible = false;

				this.overworldViewToolStripMenuItem.Visible = false;
				this.overworldToolStripMenuItem.Visible = false;
				this.areaToolStripMenuItem.Visible = false;

				this.toolStripSeparator10.Visible = false;
				this.lockoverworldToolStripItem.Visible = false;
			}

			if (this.editorsTabControl.SelectedTab.Name == "GfxEditorPage")
			{
				this.gfxEditor.BringToFront();
				this.gfxEditor.Visible = true;
			}
			else
			{
				this.gfxEditor.Visible = false;
			}

			if (this.editorsTabControl.SelectedTab.Name == "DungeonViewerPage")
			{
				this.dungeonViewer.BringToFront();
				this.dungeonViewer.Visible = true;
			}
			else
			{
				this.dungeonViewer.Visible = false;
			}

			if (this.editorsTabControl.SelectedTab.Name == "ScreenEditor")
			{
				this.screenEditor.ReLoadPalettes();
				GFX.UpdatePalette(this.screenEditor.darkWorld);
				this.screenEditor.BringToFront();
				this.screenEditor.Buildtileset();
				this.screenEditor.updateGFXGroup();
				this.screenEditor.Visible = true;
			}
			else
			{
				this.screenEditor.Visible = false;
			}

			if (this.editorsTabControl.SelectedTab.Name == "MusicEditor")
			{
				this.musicEditor.BringToFront();
				this.musicEditor.Visible = true;
			}
			else
			{
				this.musicEditor.Visible = false;
			}

			if (this.editorsTabControl.SelectedTab.Name == "SpriteEditor")
			{
				this.spriteEditor.BringToFront();
				this.spriteEditor.Visible = true;
			}
			else
			{
				this.spriteEditor.Visible = false;
			}
		}

		private void SaveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveSettings saveSettings = new SaveSettings(this);
			saveSettings.ShowDialog();
		}

		public enum Direction
		{
			gauche = 0x01,
			droit = 0x02,
			haut = 0x04,
			bas = 0x08,
		};

		private void SearchButton_Click(object sender, EventArgs e)
		{
			SearchForm searchFrom = new SearchForm(this);
			searchFrom.ShowDialog();
		}

		private void OpenDungeonTabToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.editorsTabControl.SelectTab(0);
		}

		private void OpenOverwolrdTabToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.editorsTabControl.SelectTab(1);
		}

		private void OpenGfxTabToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.editorsTabControl.SelectTab(2);
		}

		private void ExportAllRoomsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//int[] doorsoffset = new int[Constants.NumberOfRooms];
			//StringBuilder sb = new StringBuilder();
			//sb.Append("lorom\r\n");
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = UIText.ExportedRoomDataType;

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string path = Path.GetDirectoryName(saveFileDialog.FileName);
				Directory.CreateDirectory($"{path}//ExportedRooms");
				for (int i = 0; i < Constants.NumberOfRooms; i++)
				{
					// TODO: System specific path separators.
					byte[] roomBytes = DungeonsData.AllRooms[i].getTilesBytes();
					using (FileStream fs = new FileStream($"{path}//ExportedRooms//room{i:X3}.zrd", FileMode.OpenOrCreate, FileAccess.Write))
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

		private void FavoriteCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			this.sortObject();
		}

		private void RunToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.runtestButton_Click(sender, e);
		}

		private void mapDataFromJPdoNotUseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Constants.Init_Jp();
			OpenFileDialog projectFile = new OpenFileDialog();
			projectFile.Filter = UIText.JPROMType;
			projectFile.DefaultExt = UIText.ROMExtension;

			if (projectFile.ShowDialog() == DialogResult.OK)
			{
				FileStream fileStream = new FileStream(projectFile.FileName, FileMode.Open, FileAccess.Read);
				ROM.TEMPDATA = new byte[ROM.DATA.Length];
				ROM.DATA.CopyTo(ROM.TEMPDATA, 0);
				byte[] data = new byte[ROM.DATA.Length];
				ROM.DATA = new byte[ROM.DATA.Length];
				fileStream.Read(data, 0, (int) fileStream.Length);
				data.CopyTo(ROM.DATA, 0x00);
				this.oweditor2 = new OverworldEditor();
				this.oweditor2.InitOpen(this);
				this.overworldEditor.Visible = false;
				this.oweditor2.Dock = DockStyle.Fill;
				this.Controls.Remove(this.overworldEditor);
				this.Controls.Add(this.oweditor2);
				this.oweditor2.BringToFront();
				this.oweditor2.Visible = true;
				this.overworldEditor.splitContainer1.Panel2.AutoScroll = true;
				//ROM.TEMPDATA.CopyTo(ROM.DATA, 0x00);

				fileStream.Close();
			}
		}

		// TODO KAN REFACTOR this is the worst goddamn function ever and it can be greatly optimized for speed, size, and readability with local functions
		private void ExportMapJPdoNotUseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int selectedMap = this.oweditor2.scene.selectedMap;
			if (selectedMap >= 64)
			{
				selectedMap -= 64;
			}

			Console.WriteLine($"Exporting map : {overworldEditor.scene.selectedMap:X2}");
			int sx = selectedMap % 8;
			int sy = selectedMap / 8;
			string s = $"Map{selectedMap:X2}:\r\n";
			int length = 32;

			for (int i = 0; i < (length * length); i++)
			{
				if (this.oweditor2.scene.selectedMap >= 64)
				{
					int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2);
					if (this.oweditor2.scene.ow.AllMapTile32DW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
						this.dwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
					{
						s += "LDA #$" + this.oweditor2.scene.ow.AllMapTile32DW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
						s += "STA $" + addr.ToString("X4") + "\r\n";
					}
				}
				else
				{
					int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2);
					if (this.oweditor2.scene.ow.AllMapTile32LW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
						this.lwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
					{
						s += "LDA #$" + this.oweditor2.scene.ow.AllMapTile32LW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
						s += "STA $" + addr.ToString("X4") + "\r\n";
					}
				}
			}

			if (this.oweditor2.scene.ow.AllMaps[this.oweditor2.scene.selectedMap].LargeMap)
			{
				Console.Write("Is large map");
				selectedMap = this.oweditor2.scene.selectedMap + 1;
				sx = selectedMap % 8;
				sy = selectedMap / 8;

				for (int i = 0; i < (length * length); i++)
				{
					if (this.oweditor2.scene.selectedMap >= 64)
					{
						int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2) + 0x40;
						if (this.oweditor2.scene.ow.AllMapTile32DW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
							this.dwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
						{
							s += "LDA #$" + this.oweditor2.scene.ow.AllMapTile32DW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
							s += "STA $" + addr.ToString("X4") + "\r\n";
						}
					}
					else
					{
						int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2);
						if (this.oweditor2.scene.ow.AllMapTile32LW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
							this.lwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
						{
							s += "LDA #$" + this.oweditor2.scene.ow.AllMapTile32LW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
							s += "STA $" + addr.ToString("X4") + "\r\n";
						}
					}
				}

				selectedMap = this.oweditor2.scene.selectedMap + 16;
				sx = selectedMap % 8;
				sy = selectedMap / 8;

				for (int i = 0; i < (length * length); i++)
				{
					if (this.oweditor2.scene.selectedMap >= 64)
					{
						int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2) + 0x1000;
						if (this.oweditor2.scene.ow.AllMapTile32DW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
							this.dwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
						{
							s += "LDA #$" + this.oweditor2.scene.ow.AllMapTile32DW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
							s += "STA $" + addr.ToString("X4") + "\r\n";
						}
					}
					else
					{
						int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2);
						if (this.oweditor2.scene.ow.AllMapTile32LW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
							this.lwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
						{
							s += "LDA #$" + oweditor2.scene.ow.AllMapTile32LW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
							s += "STA $" + addr.ToString("X4") + "\r\n";
						}
					}
				}

				selectedMap = this.oweditor2.scene.selectedMap + 17;
				sx = selectedMap % 8;
				sy = selectedMap / 8;

				for (int i = 0; i < (length * length); i++)
				{
					if (this.oweditor2.scene.selectedMap >= 64)
					{
						int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2) + 0x1040;
						if (this.oweditor2.scene.ow.AllMapTile32DW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
							this.dwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
						{
							s += "LDA #$" + this.oweditor2.scene.ow.AllMapTile32DW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
							s += "STA $" + addr.ToString("X4") + "\r\n";
						}
					}
					else
					{
						int addr = 0x2000 + ((i / length) * 0x80) + ((i % length) * 2);
						if (this.oweditor2.scene.ow.AllMapTile32LW[(i % length) + (sx * length), (i / length) + (sy * length)] !=
							this.lwmdata[(i % length) + (sx * length), (i / length) + (sy * length)])
						{
							s += "LDA #$" + this.oweditor2.scene.ow.AllMapTile32LW[(i % length) + (sx * length), (i / length) + (sy * length)].ToString("X4") + " : ";
							s += "STA $" + addr.ToString("X4") + "\r\n";
						}
					}
				}
			}

			s += "RTS";

			using (SaveFileDialog saveFile = new SaveFileDialog())
			{
				saveFile.DefaultExt = ".asm";
				if (saveFile.ShowDialog() == DialogResult.OK)
				{
					File.WriteAllText(saveFile.FileName, s);
				}
			}
		}


		private void CaptureMapJPdoNotUseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.lwmdata = new ushort[512, 512];
			this.dwmdata = new ushort[512, 512];
			for (int x = 0; x < 512; x++)
			{
				for (int y = 0; y < 512; y++)
				{
					this.lwmdata[x, y] = this.oweditor2.scene.ow.AllMapTile32LW[x, y];
					this.dwmdata[x, y] = this.oweditor2.scene.ow.AllMapTile32DW[x, y];
				}
			}
		}

		private void ExportSpritesAsBinaryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			byte[] sprites_buffer = new byte[0x40];
			int pos = 1;
			sprites_buffer[0] = 0x00;

			foreach (Sprite spr in DungeonsData.AllRooms[this.activeScene.room.index].sprites) // 3bytes
			{
				sprites_buffer[pos++] = (byte) ((spr.layer << 7) + ((spr.subtype & 0x18) << 2) + spr.y);
				sprites_buffer[pos++] = (byte) (((spr.subtype & 0x07) << 5) + spr.x);
				sprites_buffer[pos++] = spr.id;
			}

			sprites_buffer[pos] = 0xFF;
			using (SaveFileDialog saveFile = new SaveFileDialog())
			{
				saveFile.Filter = UIText.ExportedSpriteDataType;
				if (saveFile.ShowDialog() == DialogResult.OK)
				{
					FileStream fileStream = new FileStream(saveFile.FileName, FileMode.OpenOrCreate, FileAccess.Write);
					fileStream.Write(sprites_buffer, 0, pos);
					fileStream.Close();
				}
			}
		}

		private void ExportAllMapsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int sx = 0;
			int sy = 0;
			int p = 0;

			byte[] mapArrayData = new byte[0x50000];
			using (SaveFileDialog saveFile = new SaveFileDialog())
			{
				saveFile.Filter = UIText.ExportedOWMapDataType;
				if (saveFile.ShowDialog() == DialogResult.OK)
				{
					FileStream fileStreamMap = new FileStream(saveFile.FileName, FileMode.OpenOrCreate, FileAccess.Write);
					for (int i = 0; i < 64; i++)
					{
						for (int y = 0; y < 32; y += 1)
						{
							for (int x = 0; x < 32; x += 1)
							{
								mapArrayData[p++] = (byte) overworldEditor.overworld.AllMapTile32LW[x + (sx * 32), y + (sy * 32)];
								mapArrayData[p++] = (byte) (overworldEditor.overworld.AllMapTile32LW[x + (sx * 32), y + (sy * 32)] >> 8);
								mapArrayData[p++] = (byte) overworldEditor.overworld.AllMapTile32DW[x + (sx * 32), y + (sy * 32)];
								mapArrayData[p++] = (byte) (overworldEditor.overworld.AllMapTile32DW[x + (sx * 32), y + (sy * 32)] >> 8);

								if (i < 32)
								{
									mapArrayData[p++] = (byte) overworldEditor.overworld.AllMapTile32SP[x + (sx * 32), y + (sy * 32)];
									mapArrayData[p++] = (byte) (overworldEditor.overworld.AllMapTile32SP[x + (sx * 32), y + (sy * 32)] >> 8);
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

		private void ImportAllMapsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int sx = 0;
			int sy = 0;
			int p = 0;

			byte[] mapArrayData1 = new byte[0x50000];
			using (OpenFileDialog opendFile = new OpenFileDialog())
			{
				opendFile.Filter = UIText.ExportedOWMapDataType;
				if (opendFile.ShowDialog() == DialogResult.OK)
				{
					FileStream fileStreamMap = new FileStream(opendFile.FileName, FileMode.Open, FileAccess.Read);
					fileStreamMap.Read(mapArrayData1, 0, (int) fileStreamMap.Length);
					fileStreamMap.Close();

					for (int i = 0; i < 64; i++)
					{
						for (int y = 0; y < 32; y += 1)
						{
							for (int x = 0; x < 32; x += 1)
							{
								this.overworldEditor.overworld.AllMapTile32LW[x + (sx * 32), y + (sy * 32)] = (ushort) ((mapArrayData1[p + 1] << 8) + mapArrayData1[p]);
								p += 2;
								this.overworldEditor.overworld.AllMapTile32DW[x + (sx * 32), y + (sy * 32)] = (ushort) ((mapArrayData1[p + 1] << 8) + mapArrayData1[p]);
								p += 2;

								if (i < 32)
								{
									this.overworldEditor.overworld.AllMapTile32SP[x + (sx * 32), y + (sy * 32)] = (ushort) ((mapArrayData1[p + 1] << 8) + mapArrayData1[p]);
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

		private void ExportAllTilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int p = 0;
			byte[] mapArrayData = new byte[0x8000]; // Real amount: 0x7540
			using (SaveFileDialog saveFile = new SaveFileDialog())
			{
				saveFile.Filter = UIText.ExportedTileDataType;
				if (saveFile.ShowDialog() == DialogResult.OK)
				{
					FileStream fileStreamMap = new FileStream(saveFile.FileName, FileMode.OpenOrCreate, FileAccess.Write);

					for (int i = 0; i < 3752; i++) // 3600
					{
						ulong v = this.overworldEditor.overworld.Tile16List[i].GetLongData();

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
		}

		private void ImportAllTilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int p = 0;
			byte[] mapArrayData = new byte[0x8000]; // Real amount: 0x7540
			using (OpenFileDialog openFile = new OpenFileDialog())
			{
				openFile.Filter = UIText.ExportedTileDataType;
				if (openFile.ShowDialog() == DialogResult.OK)
				{
					FileStream fileStreamMap = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read);
					fileStreamMap.Read(mapArrayData, 0, mapArrayData.Length);

					this.overworldEditor.overworld.Tile16List.Clear();
					for (int i = 0; i < Constants.NumberOfMap16; i++)
					{
						// Tile 0
						ulong t0 = (ulong) (
							(mapArrayData[p + 1] << 8) | mapArrayData[p + 0]);

						// Tile 1
						ulong t1 = (ulong) (
							(mapArrayData[p + 3] << 8) | mapArrayData[p + 2]);

						// Tile 2
						ulong t2 = (ulong) (
							(mapArrayData[p + 5] << 8) | mapArrayData[p + 4]);

						// Tile 3
						ulong t3 = (ulong) (
							(mapArrayData[p + 7] << 8) | mapArrayData[p + 6]);

						ulong v1 = t3 << 16 | t2;
						ulong v2 = t1 << 16 | t0;
						ulong v = v1 << 32 | v2;
						this.overworldEditor.overworld.Tile16List.Add(new Tile16(v));

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
					if (!tile8ids.Contains(this.overworldEditor.overworld.AllMaps[44].TilesUsed[x + (4 * 32), y + (5 * 32)]))
					{
						tile8ids.Add(this.overworldEditor.overworld.AllMaps[44].TilesUsed[x + (4 * 32), y + (5 * 32)]);
					}

					map16[x, y] = this.overworldEditor.overworld.AllMaps[44].TilesUsed[x + (4 * 32), y + (5 * 32)];
				}
			}

			for (int i = 0; i < tile8ids.Count; i++)
			{
				this.overworldEditor.overworld.Tile16List[tile8ids[i]].Tile0.HS ^= 1;
				this.overworldEditor.overworld.Tile16List[tile8ids[i]].Tile1.HS ^= 1;
				this.overworldEditor.overworld.Tile16List[tile8ids[i]].Tile2.HS ^= 1;
				this.overworldEditor.overworld.Tile16List[tile8ids[i]].Tile3.HS ^= 1;

				ushort t0 = this.overworldEditor.overworld.Tile16List[i].Tile0.id;
				ushort t2 = this.overworldEditor.overworld.Tile16List[i].Tile2.id;

				this.overworldEditor.overworld.Tile16List[i].Tile0.id = this.overworldEditor.overworld.Tile16List[i].Tile1.id;
				this.overworldEditor.overworld.Tile16List[i].Tile1.id = t0;
				this.overworldEditor.overworld.Tile16List[i].Tile2.id = this.overworldEditor.overworld.Tile16List[i].Tile3.id;
				this.overworldEditor.overworld.Tile16List[i].Tile3.id = t2;

				for (int x = 0, mx = 31; x < 32; x++, mx--)
				{
					for (int y = 0; y < 32; y++)
					{
						this.overworldEditor.overworld.AllMaps[44].TilesUsed[x + (4 * 32), y + (5 * 32)] = map16[mx, y];
					}
				}
			}

			// overworldEditor.overworld.allmaps[44].BuildMap();
		}

		// TODO: Magic string.
		private void ExportRoomDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.activeScene.room.CloneToFile("TestRoomData.dat");
		}

		private void ImportRoomDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var ms = new FileStream("TestRoomData.dat", FileMode.Open, FileAccess.Read))
			{
				var formatter = new BinaryFormatter();
				Room room = (Room) formatter.Deserialize(ms);
				this.activeScene.room = room;
				Room rtc = null;

				foreach (Room ro in this.opened_rooms)
				{
					if (ro.index == this.activeScene.room.index)
					{
						rtc = ro;
					}
				}

				// TODO: Is rtc unused?
				if (rtc != null)
				{
					rtc = room;
				}

				// TODO: Should this be rtc?
				DungeonsData.AllRooms[this.activeScene.room.index] = room;
				this.activeScene.DrawRoom();
				this.activeScene.Refresh();
			}
		}

		// TODO: System specific path separators, etc
		private void ImportRoomsFromFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Warning this will close all opened unsaved rooms do you wish to proceed?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				OpenFileDialog openFile = new OpenFileDialog();

				if (openFile.ShowDialog() == DialogResult.OK)
				{
					string path = Path.GetDirectoryName(openFile.FileName);

					for (int i = 0; i < Constants.NumberOfRooms; i++)
					{
						if (File.Exists(path + "// room" + i.ToString("X3") + ".bin"))
						{
							using (FileStream fileStream = new FileStream(path + "// room" + i.ToString("X3") + ".bin", FileMode.Open, FileAccess.Read))
							{
								DungeonsData.AllRooms[i].tilesObjects.Clear(); // Empty the room first.
								byte[] data = new byte[fileStream.Length];
								fileStream.Read(data, 0, data.Length);
								DungeonsData.AllRooms[i].loadTilesObjectsFromArray(data, true);
								fileStream.Close();
							}
						}
					}
				}
			}
		}

		/// <summary>
		///     Runs when the save only maps button is clicked.
		///     Jared_Brian_: changed so that nothing will write to the ROM if the SaveTiles() function fails.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveMapsOnlyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Save save = new Save(DungeonsData.AllRooms, this);
			if (this.overworldEditor.scene.SaveTiles())
			{
				Console.WriteLine("Tile save failed.");
			}
			else
			{
				if (save.SaveOverworldMaps(this.overworldEditor.scene))
				{
					Console.WriteLine("Too many maps out of bound error");
				}

				FileStream fileStream = new FileStream(this.projectFilename, FileMode.OpenOrCreate, FileAccess.Write);
				fileStream.Write(ROM.DATA, 0, ROM.DATA.Length);
				fileStream.Close();
			}
		}

		private void ImportRoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = UIText.ExportedRoomDataType;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
				byte[] data = new byte[(int) fileStream.Length];
				fileStream.Read(data, 0, data.Length);
				fileStream.Close();

				this.activeScene.room.loadTilesObjectsFromArray(data);
				this.activeScene.Refresh();
			}
		}

		private void ShowRoomsInHexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (TabPage tabPage in this.tabControl2.TabPages)
			{
				if (this.showRoomsInHexToolStripMenuItem.Checked)
				{
					tabPage.Text = (tabPage.Tag as Room).index.ToString("X3");
				}
				else
				{
					tabPage.Text = (tabPage.Tag as Room).index.ToString("D3");
				}
			}
		}

		private void ShowMapIndexInHexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.showMapIndexInHexToolStripMenuItem.Checked)
			{
				this.overworldEditor.mapGroupbox.Text = "Selected Map - " + overworldEditor.scene.selectedMapParent.ToString("X2") + " Properties : ";
			}
			else
			{
				this.overworldEditor.mapGroupbox.Text = "Selected Map - " + overworldEditor.scene.selectedMapParent.ToString() + " Properties : ";
			}
		}

		private void SaveVRAMAsPngToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GFX.currentgfx16Bitmap.Save("vram.png");
		}

		private void Edit8x8palettebox_Paint(object sender, PaintEventArgs e)
		{
			ColorPalette colorPalette = GFX.roomBg1Bitmap.Palette;
			for (int i = 0; i < 128; i++)
			{
				e.Graphics.FillRectangle(new SolidBrush(colorPalette.Entries[i]), new Rectangle((i % 16) * 16, (i / 16) * 16, 16, 16));
			}
		}

		private void MoveRoomsToOtherROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UIText.WarnAboutSaving(UIText.CloseROMWarning);
			RoomMover roomMover = new RoomMover();

			if (roomMover.ShowDialog() == DialogResult.OK)
			{
				List<short> listofrooms = new List<short>();
				for (int i = 0; i < Constants.NumberOfRooms; i++)
				{
					if (roomMover.checkedListBox1.GetItemChecked(i))
					{
						listofrooms.Add((short) i);
					}
				}

				FileStream fileStream = new FileStream(roomMover.textBox1.Text, FileMode.Open, FileAccess.Read);
				int size = (int) fileStream.Length;

				if (fileStream.Length < 0x200000)
				{
					size = 0x200000;
				}

				ROM.DATA2 = new byte[size];
				if ((fileStream.Length & 0x200) == 0x200)
				{
					size = (int) (fileStream.Length - 0x200);
					byte[] tempRomData = new byte[fileStream.Length];
					fileStream.Read(tempRomData, 0, (int) fileStream.Length);
					Array.Copy(tempRomData, 0x200, ROM.DATA2, 0, size);
				}
				else
				{
					fileStream.Read(ROM.DATA2, 0, (int) fileStream.Length);
				}

				fileStream.Close();

				ROM.TEMPDATA = new byte[0x200000];
				for (int i = 0; i < 0x200000; i++)
				{
					ROM.TEMPDATA[i] = ROM.DATA[i];
					ROM.DATA[i] = ROM.DATA2[i];
				}

				for (int i = 0; i < Constants.NumberOfRooms; i++)
				{
					DungeonsData.AllRoomsMoved[i] = new Room(i);
				}

				ROM.TEMPDATA = new byte[0x200000];
				for (int i = 0; i < 0x200000; i++)
				{
					ROM.DATA2[i] = ROM.DATA[i];
					ROM.DATA[i] = ROM.TEMPDATA[i]; // Restore to original ROM.
				}

				Save save = new Save(DungeonsData.AllRooms, this);

				// if (rm.checkBox7.Checked)
				// {
				if (save.SaveRoomsHeaders2()) // No protection always the same size so we don't care :).
				{
					// MessageBox.Show("Failed to save, there is too many chest items", "Bad Error", MessageBoxButtons.OK);
				}

				// }

				if (roomMover.checkBox6.Checked)
				{
					if (save.SaveallChests2()) // Chest there's a protection when there's too many chest - tested it works fine.
					{
						UIText.CryAboutSaving("there are too many chest items");
						return;
					}
				}

				if (roomMover.checkBox5.Checked)
				{
					if (save.SaveAllSprites2(listofrooms.ToArray())) // Sprites, there's a protection.
					{
						UIText.CryAboutSaving("there are too many sprites");
						return;
					}
				}

				if (roomMover.checkBox1.Checked)
				{
					if (save.SaveAllObjects2(listofrooms.ToArray())) // There is a protection - Tested.
					{
						UIText.CryAboutSaving("there are too many tiles objects");
						return;
					}
				}

				if (roomMover.checkBox2.Checked)
				{
					if (save.SaveAllPots2(listofrooms.ToArray())) // There is a protection - Tested.
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

				fileStream = new FileStream(roomMover.textBox1.Text, FileMode.Open, FileAccess.Write);
				fileStream.Write(ROM.DATA2, 0, 0x200000);

				fileStream.Close();

				MessageBox.Show("Selected data successfully moved to selected ROM.\n" +
					"Please restart the application.");
			}
		}

		private void ShowSpritesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			this.overworldEditor.scene.showSprites = this.showSpritesToolStripMenuItem.Checked;
			this.overworldEditor.scene.showEntrances = this.showEntrancesToolStripMenuItem.Checked;
			this.overworldEditor.scene.showExits = this.showExitsToolStripMenuItem.Checked;
			this.overworldEditor.scene.showFlute = this.showTransportsToolStripMenuItem.Checked;
			this.overworldEditor.scene.showItems = this.showItemsToolStripMenuItem.Checked;
			this.overworldEditor.Refresh();
		}

		private void IncreaseObjectSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.activeScene.room.selectedObject.Count > 0)
			{
				if (this.activeScene.room.selectedObject[0] is Room_Object roomObject)
				{
					Console.WriteLine(roomObject.Size);
					roomObject.UpdateSize();

					if (roomObject.Size < 15)
					{
						roomObject.Size++;
					}
					else
					{
						roomObject.Size = 1;
					}

					this.activeScene.updateSelectionObject(roomObject);
				}
			}

			this.activeScene.DrawRoom();
			this.activeScene.Refresh();
		}

		private void DecreaseObjectSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.activeScene.room.selectedObject.Count > 0)
			{
				if (this.activeScene.room.selectedObject[0] is Room_Object obj)
				{
					if (obj.Size > 0)
					{
						obj.UpdateSize();
						obj.Size--;
						this.activeScene.updateSelectionObject(obj);
					}
				}
			}

			this.activeScene.DrawRoom();
			this.activeScene.Refresh();
		}

		private void DarkThemeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeTheme(this.Controls);
		}

		// TODO: Magic colors.
		// Make a ThemeConstants.cs file?
		public void ChangeTheme(Control.ControlCollection container)
		{
			foreach (Control component in container)
			{
				if (component.Controls.Count != 0)
				{
					this.ChangeTheme(component.Controls);
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

		private void X8ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.x8ToolStripMenuItem1.Checked = false;
			this.x16ToolStripMenuItem1.Checked = false;
			this.x32ToolStripMenuItem1.Checked = false;
			this.noneToolStripMenuItem.Checked = false;

			if (sender == this.x8ToolStripMenuItem1)
			{
				this.x8ToolStripMenuItem1.Checked = true;
				this.overworldEditor.gridDisplay = 8;
			}
			else if (sender == this.x16ToolStripMenuItem1)
			{
				this.x16ToolStripMenuItem1.Checked = true;
				this.overworldEditor.gridDisplay = 16;
			}
			else if (sender == this.x32ToolStripMenuItem1)
			{
				this.x32ToolStripMenuItem1.Checked = true;
				this.overworldEditor.gridDisplay = 32;
			}
			else
			{
				this.noneToolStripMenuItem.Checked = true;
				this.overworldEditor.gridDisplay = 0;
			}

			this.overworldEditor.scene.Refresh();
		}

		private void AutoDoorButton_Click_1(object sender, EventArgs e)
		{
			List<Room_Object> shutterdoors = new List<Room_Object>();
			List<Room_Object> keydoors = new List<Room_Object>();
			List<Room_Object> normaldoors = new List<Room_Object>();

			keydoors.Clear();
			shutterdoors.Clear();
			normaldoors.Clear();

			foreach (Room_Object roomObject in this.activeScene.room.tilesObjects)
			{
				if (roomObject.options == ObjectOption.Door)
				{
					if (this.keysDoors.Contains((byte) (roomObject.id >> 8)))
					{
						if (!keydoors.Contains(roomObject))
						{
							keydoors.Add(roomObject);
						}
					}
					else if (this.shutterDoors.Contains((byte) (roomObject.id >> 8)))
					{
						if (!shutterdoors.Contains(roomObject))
						{
							shutterdoors.Add(roomObject);
						}
					}
					else
					{
						if (!normaldoors.Contains(roomObject))
						{
							normaldoors.Add(roomObject);
						}
					}
				}
			}

			foreach (Room_Object roomObject in keydoors)
			{
				this.activeScene.room.tilesObjects.Remove(roomObject);
				this.activeScene.room.tilesObjects.Add(roomObject);
			}

			foreach (Room_Object roomObject in shutterdoors)
			{
				this.activeScene.room.tilesObjects.Remove(roomObject);
				this.activeScene.room.tilesObjects.Add(roomObject);
			}

			foreach (Room_Object roomObject in normaldoors)
			{
				this.activeScene.room.tilesObjects.Remove(roomObject);
				this.activeScene.room.tilesObjects.Add(roomObject);
			}

			this.activeScene.DrawRoom();
			this.activeScene.Refresh();
		}

		// TODO: Magic points and merge identical functions.
		private void DungeonMain_SizeChanged(object sender, EventArgs e)
		{
			if (this.x2zoom)
			{
				this.panel3.Location = new Point(1032, -1);
			}
			else
			{
				this.panel3.Location = new Point(520, -1);
			}
		}

		private void XScreenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.x2zoom)
			{
				this.panel3.Location = new Point(1032, -1);
			}
			else
			{
				this.panel3.Location = new Point(520, -1);
			}
		}

		private void MemoryManagementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Need to find one empty byte in the ROM to write the bank pointer!
			// Bank XX is used for all the expanded pointers!
			// XX8000-XX8500 : RESERVED FOR EDITOR USE DATA/POINTERS
			// XX8501-XX88C1 : Rooms Header Pointers (0x3C0 length)
			// XX88C1-XX8A41 : Overworld Overlay Pointers
			// XX8A41-XX8E01 : Collision Map Dungeon Pointers
			ExpandedManagement expandedManagement = new ExpandedManagement();
			expandedManagement.ShowDialog();
		}

		/// <summary>
		///     Is triggered when the clear all custom collision button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClearAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.activeScene.clearCustomCollisionMap();
		}

		/// <summary>
		///     Is triggered when the clear all overworld sprites phase 1 button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClearPhase1OWSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletion("overworld sprites for phase 1 (Rescue Zelda)"))
			{
				this.overworldEditor.clearOverworldSprites(0);
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld sprites phase 2 button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClearPhase2OWSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletion("overworld sprites for phase 2 (Zelda rescued)"))
			{
				this.overworldEditor.clearOverworldSprites(1);
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld sprites phase 3 button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClearPhase3OWSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletion("overworld sprites for phase 3 (Agahnim defeated)"))
			{
				this.overworldEditor.clearOverworldSprites(2);
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld items button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ClearAllOWItemsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletion("overworld items"))
			{
				this.overworldEditor.clearOverworldItems();
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld entrances button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ClearAllOWEntrancesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletion("overworld entrances"))
			{
				this.overworldEditor.clearOverworldEntrances();
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld holes button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ClearAllOWHolesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletion("hole entrances"))
			{
				this.overworldEditor.clearOverworldHoles();
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld exits button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ClearAllOWExitsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletion("overworld exits"))
			{
				this.overworldEditor.clearOverworldExits();
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld overlays button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ClearAllOverworldOverlaysToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletion("overworld overlays"))
			{
				this.overworldEditor.clearOverworldOverlays();
			}
		}

		private void SelectAllRoomsForExportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				this.selectedMapPng.Add((short) i);
			}

			//loadRoomList(Constants.NumberOfRooms);
		}

		private void DeselectedAllRoomsForExportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.selectedMapPng.Clear();

			//loadRoomList(Constants.NumberOfRooms);
		}

		/// <summary>
		///     Is triggered when the clear all overworld sprites phase 1 button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClearPhase1AreaSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletionOWArea("sprites for phase 1 (Rescue Zelda)"))
			{
				this.overworldEditor.clearAreaSprites(0);
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld sprites phase 2 button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClearPhase2AreaSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletionOWArea("sprites for phase 2 (Zelda rescued)"))
			{
				this.overworldEditor.clearAreaSprites(1);
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld sprites phase 3 button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClearPhase3AreaSpritesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletionOWArea("sprites for phase 3 (Agahnim defeated)"))
			{
				this.overworldEditor.clearAreaSprites(2);
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld items button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ClearAllAreaItemsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletionOWArea("secret items"))
			{
				this.overworldEditor.clearAreaItems();
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld entrances button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ClearAllAreaEntrancesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletionOWArea("entrances"))
			{
				this.overworldEditor.clearAreaEntrances();
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld holes button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ClearAllAreaHolesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletionOWArea("hole entrances"))
			{
				this.overworldEditor.clearAreaHoles();
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld exits button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ClearAllAreaExitsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletionOWArea("exits"))
			{
				this.overworldEditor.clearAreaExits();
			}
		}

		/// <summary>
		///     Is triggered when the clear all overworld overlays button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ClearAllAreaOverlaysToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ConfirmDeletionOWArea("overlay tiles"))
			{
				this.overworldEditor.clearAreaOverlays();
			}
		}

		/// <summary>
		///     Gives a message box saying "You wanna delete <paramref name="w"/>?".
		/// </summary>
		/// <param name="w"></param>
		/// <returns> True if yes. </returns>
		private bool ConfirmDeletion(string w)
		{
			return MessageBox.Show(
				$"You are about to delete all {w}.\nDo you wish to continue?",
				"Warning",
				MessageBoxButtons.YesNo) == DialogResult.Yes;
		}

		/// <summary>
		///     Gives a message box saying "You wanna delete <paramref name="w"/> from OW screen X?".
		/// <param name="w"></param>
		/// <returns> True if yes. </returns>
		private bool ConfirmDeletionOWArea(string w)
		{
			return ConfirmDeletion($"{w} from OW screen {overworldEditor.scene.selectedMapParent:X2}");
		}

		private void DiscordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(UIText.DISCORD);
		}

		private void RoomPropertyChanged(object sender, EventArgs e)
		{
			this.UpdateRoomInfo();
		}

		public void GetXYMouseBasedOnZoom(MouseEventArgs e, out int x, out int y)
		{
			if (this.x2zoom)
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

		private void ClearDWTilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to clear all tiles in the Dark World?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				int sx = 0;
				int sy = 0;

				for (int i = 0; i < 64; i++)
				{
					for (int y = 0; y < 32; y += 1)
					{
						for (int x = 0; x < 32; x += 1)
						{
							this.overworldEditor.overworld.AllMapTile32DW[x + (sx * 32), y + (sy * 32)] = 0x34;
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

		private void CopyLWToDWToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to copy all Light World tiles to the Dark World?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				int sx = 0;
				int sy = 0;

				for (int i = 0; i < 64; i++)
				{
					for (int y = 0; y < 32; y += 1)
					{
						for (int x = 0; x < 32; x += 1)
						{
							this.overworldEditor.overworld.AllMapTile32DW[x + (sx * 32), y + (sy * 32)] = this.overworldEditor.overworld.AllMapTile32LW[x + (sx * 32), y + (sy * 32)];
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

		private void ShowTiles32CountToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.overworldEditor.overworld.CreateTile32Tilemap(true);
		}

		private void UseAreaSpecificBGColorToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			this.overworldEditor.UpdateBGColorVisibility(this.useAreaSpecificBGColorToolStripMenuItem.Checked);

			OverworldEditor.UseAreaSpecificBgColor = this.useAreaSpecificBGColorToolStripMenuItem.Checked;
			this.overworldEditor.Refresh();
		}

		private void ShowScratchPadGridToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OverworldEditor.scratchPadGrid = this.showScratchPadGridToolStripMenuItem.Checked;
			this.overworldEditor.Refresh();
		}

		private void ShowStairIndexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.activeScene.Refresh();
		}

		private void HostToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NetHost netHost = new NetHost();

			if (netHost.ShowDialog() == DialogResult.OK)
			{
				NetPeerConfiguration config = new NetPeerConfiguration("ZSCOOP");
				config.Port = Convert.ToInt32(netHost.port);
				config.MaximumConnections = 10;
				config.EnableMessageType(NetIncomingMessageType.Data);
				config.EnableMessageType(NetIncomingMessageType.WarningMessage);
				config.EnableMessageType(NetIncomingMessageType.VerboseDebugMessage);
				config.EnableMessageType(NetIncomingMessageType.ErrorMessage);
				config.EnableMessageType(NetIncomingMessageType.Error);
				config.EnableMessageType(NetIncomingMessageType.DebugMessage);
				config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);

				this.netZS = new NetZS(this, true);
				this.netZS.server = new NetServer(config);
				this.netZS.server.Start();
				NetZS.connected = true;

				if (this.netZS.server.Status == NetPeerStatus.Running)
				{
					Console.WriteLine("Server is running on port " + config.Port);
				}
				else
				{
					Console.WriteLine("Server not started...");
				}

				this.networkBgWorker.RunWorkerAsync();
				this.AddNetworkPanel();

				this.networkstatusLabel.Text = $"Network Status : {netZS.server.Status.ToString()}";
			}
		}

		private void AddNetworkPanel()
		{
			this.networkstatusLabel.Dock = DockStyle.Fill;

			this.networkPanel = new Panel();
			this.networkPanel.Height = 24;

			this.networkPanel.Dock = DockStyle.Top;
			this.networkPanel.Controls.Add(this.networkstatusLabel);
			this.Controls.Add(this.networkPanel);
			this.menuStrip1.SendToBack();
		}

		private void JoinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var config = new NetPeerConfiguration("ZSCOOP");

			config.AutoFlushSendQueue = false;
			config.EnableMessageType(NetIncomingMessageType.Data);
			config.EnableMessageType(NetIncomingMessageType.WarningMessage);
			config.EnableMessageType(NetIncomingMessageType.VerboseDebugMessage);
			config.EnableMessageType(NetIncomingMessageType.ErrorMessage);
			config.EnableMessageType(NetIncomingMessageType.Error);
			config.EnableMessageType(NetIncomingMessageType.DebugMessage);
			config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);

			NetworkForm nf = new NetworkForm();

			if (nf.ShowDialog() == DialogResult.OK)
			{
				this.netZS = new NetZS(this, false);
				NetZS.client = new NetClient(config);
				NetZS.client.Start();

				NetZS.client.Connect(new IPEndPoint(NetUtility.Resolve(nf.ip), Convert.ToInt32(nf.port)));
				this.networkBgWorker.RunWorkerAsync();
				NetZS.connected = true;
				this.networkstatusLabel.Text = $"Network Status : {NetZS.client.ConnectionStatus.ToString()}";
				this.AddNetworkPanel();
			}
		}

		private void NetworkBgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			if (NetZS.connected)
			{
				this.netZS.ReadIncomingMessages();
			}
		}

		private void NetworkBgWorker2_DoWork(object sender, DoWorkEventArgs e)
		{
		}

		private void LoadTimer_Tick(object sender, EventArgs e)
		{
			if (!NetZS.connected)
			{
				return;
			}

			Console.WriteLine("Attempt at loading project!");
			this.LoadProject(string.Empty, true);
			Console.WriteLine("AFTER project!");
			//this.Enabled = true;

			this.crc32timer.Enabled = true;
			this.crc32timer.Start();

			this.networkstatusLabel.Text = "Network Status : Connected";

			byte[] data = new byte[02] { 0x80, 0x01 }; // Send signal we are no longer waiting!
			NetOutgoingMessage netOutgoingMessage = NetZS.client.CreateMessage();
			netOutgoingMessage.Write(data);
			NetZS.client.SendMessage(netOutgoingMessage, NetDeliveryMethod.ReliableOrdered);
			NetZS.client.FlushSendQueue();
			Console.WriteLine("Sent No waiting signal anymore");

			this.loadTimer.Stop();
			this.loadTimer.Enabled = false;
		}

		private void CRC32timer_Tick(object sender, EventArgs e)
		{
			/*int checksum = 0;
			for(int x = 0; x < 256; x++ )
			{
				for (int y = 0; y < 256; y++)
				{
					checksum += overworldEditor.scene.ow.allmapsTilesLW[x, y];
				}
			}
			byte[] data = new byte[6] { 3, NetZS.userID, (byte) checksum, (byte) (checksum >> 8), (byte) (checksum >> 16), (byte) (checksum >> 24) };

			// write CRC
			NetOutgoingMessage msg = NetZS.client.CreateMessage();
			msg.Write(data);
			NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
			NetZS.client.FlushSendQueue();*/

			if (!NetZS.connected)
			{
				return;
			}

			if (this.netZS.host)
			{
				this.networkstatusLabel.Text = $"Network Status : {netZS.server.Status.ToString()}";
			}
			else
			{
				this.networkstatusLabel.Text = $"Network Status : {NetZS.client.ConnectionStatus.ToString()}";
			}
		}

		private void ExportImageMapMultipleROMsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/*	while(true)
			{
				string romDigit = romID.ToString("D2");
				Console.WriteLine("Starting ROM " + romDigit);
				if (romID >= 58)
				{
					exportPNGTimer.Stop();
					exportPNGTimer.Enabled = false;
					break;
				}

				FileStream fs = new FileStream(Path.GetDirectoryName(projectFilename) + "\\rom" + romDigit + ".sfc", FileMode.Open);
				fs.Read(ROM.DATA, 0, ROM.DATA.Length);
				fs.Close();

				overworldEditor.overworld = new Overworld();
				overworldEditor.InitOpen(this);

				overworldEditor.scene.Refresh();

				Thread.Sleep(500);

				Bitmap temp = new Bitmap(4096, 4096);
				Graphics g = Graphics.FromImage(temp);

				if (OverworldEditor.UseAreaSpecificBgColor)
				{
					for (int i = 0; i < 64; i++)
					{
						int x = (i % 8) * 512;
						int y = (i / 8) * 512;

						int k = overworldEditor.overworld.allmaps[i].parent;
						g.FillRectangle(new SolidBrush(Palettes.overworld_BackgroundPalette[k]), new Rectangle(x, y, 512, 512));
					}
				}
				else
				{
					g.FillRectangle(new SolidBrush(Palettes.overworld_GrassPalettes[0]), new Rectangle(0, 0, 4096, 4096));
				}

				for (int i = 0; i < 64; i++)
				{
					int x = (i % 8) * 512;
					int y = (i / 8) * 512;

					g.DrawImage(overworldEditor.overworld.allmaps[i].gfxBitmap, x, y, new Rectangle(0, 0, 512, 512), GraphicsUnit.Pixel);
				}

				temp.Save("MULTILW" + romDigit + ".png");
				romID++;
				Console.WriteLine("Starting exporting");

				for (int i = 0; i < 159; i++)
				{
					overworldEditor.scene.ow.allmaps[i].tilesUsed = null;
					overworldEditor.scene.ow.allmaps[i] = null;
				}

				overworldEditor.scene.ow.allBirds.Clear();
				overworldEditor.scene.ow.allBirds = null;
				overworldEditor.scene.ow.allentrances = null;
				overworldEditor.scene.ow.allexits = null;
				overworldEditor.scene.ow.allholes = null;
				overworldEditor.scene.ow.allmaps = null;
				overworldEditor.scene.ow.allmapsTilesDW = null;
				overworldEditor.scene.ow.allmapsTilesLW = null;
				overworldEditor.scene.ow.allmapsTilesSP = null;
				overworldEditor.scene.ow.alloverlays = null;
				overworldEditor.scene.ow.allWhirlpools = null;
				overworldEditor.scene.ow.allTilesTypes = null;
				overworldEditor.scene.ow.map16tiles = null;
				overworldEditor.scene.ow.tiles32 = null;
				overworldEditor.scene.ow = null;
				overworldEditor.scene = null;
			}*/
		}

		private void ExportPNGTimer_Tick(object sender, EventArgs e)
		{
			// TODO: This?
		}

		private void SaveToNewROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			byte[] ROMBACKUP = new byte[0x200000];
			Array.Copy(ROM.DATA, ROMBACKUP, 0x200000);

			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = UIText.USROMType;
				openFileDialog.DefaultExt = UIText.ROMExtension;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
					int size = 0x200000;
					ROM.DATA = new byte[size];
					if ((fileStream.Length & 0x200) == 0x200)
					{
						size = (int) (fileStream.Length - 0x200);
						byte[] tempRomData = new byte[fileStream.Length];
						fileStream.Read(tempRomData, 0, (int) fileStream.Length);
						Array.Copy(tempRomData, 0x200, ROM.DATA, 0, size);
					}
					else
					{
						fileStream.Read(ROM.DATA, 0, (int) fileStream.Length);
					}

					fileStream.Close();

					this.Text = $"{UIText.APPNAME} - {openFileDialog.FileName}";
				}
			}
		}

		private void pluginsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AsmPlugin windowPlugin = new AsmPlugin();
			windowPlugin.ProjectPath = Path.GetDirectoryName(projectFilename);
			windowPlugin.Show();
		}

		private void buildROMwithASMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SaveToolStripMenuItem_Click(this.saveToolStripMenuItem, new EventArgs());

			SaveFileDialog saveFile = new SaveFileDialog();
			saveFile.DefaultExt = ".sfc";
			saveFile.Filter = "ZScream Project File .sfc|*.sfc";

			if (saveFile.ShowDialog() == DialogResult.OK)
			{
				byte[] data = new byte[ROM.DATA.Length];
				ROM.DATA.CopyTo(data, 0);
				this.SaveToolStripMenuItem_Click(sender, e);
				AsarCLR.Asar.init();

				string ProjectPath = Path.GetDirectoryName(projectFilename);
				if (File.Exists(ProjectPath + "\\Patches\\main.asm"))
				{
					AsarCLR.Asar.patch(Path.GetDirectoryName(this.projectFilename) + "\\Patches\\main.asm", ref data);
				}

				if (File.Exists(ProjectPath + "\\Patches\\generated.asm"))
				{
					AsarCLR.Asar.patch(Path.GetDirectoryName(this.projectFilename) + "\\Patches\\generated.asm", ref data);
				}

				foreach (AsarCLR.Asarerror error in AsarCLR.Asar.geterrors())
				{
					Console.WriteLine(error.Fullerrdata.ToString());
				}

				FileStream fileStream = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write);
				fileStream.Write(data, 0, data.Length);
				fileStream.Close();
			}
		}

		private void exportSelectedRoomsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog saveFile = new SaveFileDialog())
			{
				if (saveFile.ShowDialog() == DialogResult.OK)
				{
					BinaryWriter binaryWriter = new BinaryWriter(new FileStream(saveFile.FileName, FileMode.OpenOrCreate));
					binaryWriter.Write(opened_rooms.Count);
					foreach (Room room in opened_rooms)
					{
						binaryWriter.Write(room.index);
						byte[] roomObjects = room.getTilesBytes();
						binaryWriter.Write(roomObjects.Length);
						binaryWriter.Write(roomObjects);

						byte sprCount = (byte) room.sprites.Count;
						binaryWriter.Write(sprCount);
						foreach (Sprite sprite in room.sprites)
						{
							binaryWriter.Write(sprite.roomid); // short
							binaryWriter.Write(sprite.id); // byte
							binaryWriter.Write(sprite.x); // byte
							binaryWriter.Write(sprite.y); // byte
							binaryWriter.Write(sprite.subtype); // byte
							binaryWriter.Write(sprite.layer); // byte
						}

						byte itemCount = (byte) room.pot_items.Count;
						binaryWriter.Write(itemCount);
						foreach (PotItem item in room.pot_items)
						{
							binaryWriter.Write(item.id); // byte
							binaryWriter.Write(item.x); // byte
							binaryWriter.Write(item.y); // byte
							binaryWriter.Write(item.bg2); // bool
						}

						byte chestItemCount = (byte) room.chest_list.Count;
						binaryWriter.Write(chestItemCount);
						foreach (Chest item in room.chest_list)
						{
							binaryWriter.Write(item.x); // byte
							binaryWriter.Write(item.y); // byte
							binaryWriter.Write(item.item); // byte
							binaryWriter.Write(item.bigChest); // bool
						}

						binaryWriter.Write(room.damagepit);
						binaryWriter.Write(room.holewarp);
						binaryWriter.Write(room.staircase1);
						binaryWriter.Write(room.staircase2);
						binaryWriter.Write(room.staircase3);
						binaryWriter.Write(room.staircase4);
						binaryWriter.Write(room.holewarp_plane);
						binaryWriter.Write(room.staircase1Plane);
						binaryWriter.Write(room.staircase2Plane);
						binaryWriter.Write(room.staircase3Plane);
						binaryWriter.Write(room.staircase4Plane);
						binaryWriter.Write((byte) room.tag1);
						binaryWriter.Write((byte) room.tag2);
						binaryWriter.Write((byte) room.bg2);
						binaryWriter.Write(room.spriteset);
						binaryWriter.Write(room.sortsprites);
						binaryWriter.Write(room.palette);
						binaryWriter.Write((byte) room.messageid);
						binaryWriter.Write((byte) room.effect);
						binaryWriter.Write(room.floor1);
						binaryWriter.Write(room.floor2);
						binaryWriter.Write((byte) room.collision);
						binaryWriter.Write(room.light);
						binaryWriter.Write(room.blockset);
						binaryWriter.Write(room.layout);
					}

					binaryWriter.Close();
				}
			}
		}

		private void importDungeonToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFile = new OpenFileDialog())
			{
				if (openFile.ShowDialog() == DialogResult.OK)
				{
					BinaryReader binaryReader = new BinaryReader(new FileStream(openFile.FileName, FileMode.Open));
					int roomCount = binaryReader.ReadInt32(); // Number of rooms

					for (int i = 0; i < roomCount; i++)
					{
						int rIndex = binaryReader.ReadInt32();

						int nbrObjects = binaryReader.ReadInt32();
						byte[] objectsData = binaryReader.ReadBytes(nbrObjects);

						DungeonsData.AllRooms[rIndex].tilesObjects.Clear();

						DungeonsData.AllRooms[rIndex].loadTilesObjectsFromArray(objectsData);

						DungeonsData.AllRooms[rIndex].sprites.Clear();
						int sprCount = binaryReader.ReadByte();
						for (int j = 0; j < sprCount; j++)
						{
							short roomindex = binaryReader.ReadInt16(); // room
							byte id = binaryReader.ReadByte(); // byte
							byte x = binaryReader.ReadByte(); // byte
							byte y = binaryReader.ReadByte();  // byte
							byte subtype = binaryReader.ReadByte();  // byte
							byte layer = binaryReader.ReadByte();  // byte
							DungeonsData.AllRooms[rIndex].sprites.Add(new Sprite(DungeonsData.AllRooms[rIndex], id, x, y, subtype, layer));
						}

						DungeonsData.AllRooms[rIndex].pot_items.Clear();
						int potCount = binaryReader.ReadByte();
						for (int j = 0; j < potCount; j++)
						{
							byte id = binaryReader.ReadByte(); // byte
							byte x = binaryReader.ReadByte(); // byte
							byte y = binaryReader.ReadByte();  // byte
							bool bg2 = binaryReader.ReadBoolean();
							DungeonsData.AllRooms[rIndex].pot_items.Add(new PotItem(id, x, y, bg2));
						}

						DungeonsData.AllRooms[rIndex].chest_list.Clear();
						int chestCount = binaryReader.ReadByte();
						for (int j = 0; j < chestCount; j++)
						{
							byte x = binaryReader.ReadByte(); // byte
							byte y = binaryReader.ReadByte();  // byte
							byte item = binaryReader.ReadByte(); // byte
							bool bigchest = binaryReader.ReadBoolean();
							DungeonsData.AllRooms[rIndex].chest_list.Add(new Chest(x, y, item, bigchest));
						}

						DungeonsData.AllRooms[rIndex].damagepit = binaryReader.ReadBoolean();
						DungeonsData.AllRooms[rIndex].holewarp = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].staircase1 = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].staircase2 = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].staircase3 = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].staircase4 = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].holewarp_plane = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].staircase1Plane = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].staircase2Plane = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].staircase3Plane = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].staircase4Plane = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].tag1 = (TagKey) binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].tag2 = (TagKey) binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].bg2 = (Background2) binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].spriteset = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].sortsprites = binaryReader.ReadBoolean();
						DungeonsData.AllRooms[rIndex].palette = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].messageid = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].effect = (EffectKey) binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].floor1 = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].floor2 = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].collision = (CollisionKey) binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].light = binaryReader.ReadBoolean();
						DungeonsData.AllRooms[rIndex].blockset = binaryReader.ReadByte();
						DungeonsData.AllRooms[rIndex].layout = binaryReader.ReadByte();
					}

					binaryReader.Close();
				}
			}
		}

		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			// TODO: This?
		}

		private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			byte[] bosses = { 0x09, 0x53, 0x54, 0x88, 0x8C, 0x92, 0xA2, 0xBD, 0xCB, 0xCE };

			// Calculate a bunch of stuff.
			int roomObjectsSize = 0;
			int roomObjectsCount = 0;
			int roomUsedCount = 0;
			int heartPiecesCount = 0;
			int heartContainerCount = 0;
			int bossContainer = 0;
			int potItems = 0;
			int potItemsSize = 2;
			int spriteCount = 0;
			int spriteSize = 2;
			int owspriteCount = 0;
			int owspriteSize = 2;
			int chestItemsCount = 0;
			int[] allChestItems = new int[76];
			string roomWTF = "";
			//byte[] items = 
			//chest count max = 168

			foreach (Room room in DungeonsData.AllRooms)
			{
				roomObjectsCount += room.tilesObjects.Count;

				roomObjectsSize += room.getTilesBytes().Length;
				if (room.tilesObjects.Count > 0)
				{
					// ROOM IS USED
					heartPiecesCount += room.chest_list.Count(x => x.item == 0x17);
					heartContainerCount += room.chest_list.Count(x => ((x.item == 0x26) || (x.item == 0x3E) || (x.item == 0x3F)));

					heartPiecesCount += room.sprites.Count(x => ((x.id == 0xEB) && (x.subtype & 7) != 7));

					if (room.tag1 != TagKey.Kill_boss_Again && room.tag2 != TagKey.Kill_boss_Again)
					{
						if (room.sprites.Where(x => bosses.Contains(x.id) && (x.subtype & 7) != 7).ToArray().Length > 0)
						{
							bossContainer += 1;
							//roomWTF += room.index;
						}
					}

					chestItemsCount += room.chest_list.Count;
					roomUsedCount += 1;
					//room.pot_items.Count = roomUsedCount;
					if (room.pot_items.Count > 0)
					{
						potItems += room.pot_items.Count;
						potItemsSize += (room.pot_items.Count * 3);
						potItemsSize += 2;
					}

					if (room.sprites.Count > 0)
					{
						spriteCount += room.sprites.Count;
						spriteSize += (room.sprites.Count * 3);
						spriteSize += 2;
					}

					foreach (Chest c in room.chest_list)
					{
						allChestItems[c.item] += 1;
					}
				}
				else
				{
					// EMTPY ROOM

					foreach (Chest c in room.chest_list)
					{
						allChestItems[c.item] += 1;
					}
				}
			}

			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 76; i++)
			{
				stringBuilder.AppendLine("0x" + i.ToString("X2") + " - " + ChestItems_Name.name[i] + " : " + allChestItems[i].ToString());
			}
			string allchestInfos = stringBuilder.ToString();

			stringBuilder.Clear();

			stringBuilder.AppendLine("Heart Pieces (including sprites) : " + heartPiecesCount.ToString() + "  (+1 if chest minigame is used)");
			stringBuilder.AppendLine("Heart Container : " + heartContainerCount.ToString());
			stringBuilder.AppendLine("Boss Container : " + bossContainer.ToString());
			string basicchestInfos = stringBuilder.ToString();

			stringBuilder.Clear();
			// 10000
			stringBuilder.AppendLine("Rooms Used : " + roomUsedCount + " / 296");
			stringBuilder.AppendLine("Rooms objects count: " + roomObjectsCount.ToString() + "  Size in bytes : 0x" + roomObjectsSize.ToString("X6") + " / 0x1C42B");


			int ptrOfPointers = Utils.SnesToPc(ROM.ReadLong(Constants.room_items_pointers_ptr));
			string maxSize = "0x08C9";
			if (ptrOfPointers != 0x00DB69)
			{
				maxSize = "[EXPANDED]";
			}

			stringBuilder.AppendLine("Pots items used : " + potItems + "  Size in bytes : 0x" + potItemsSize.ToString("X4") + " / " + maxSize);
			stringBuilder.AppendLine("Sprites used (UW) : " + spriteCount + "  Size (UW and OW) in bytes : 0x" + ((ROM.spaceUsedOWSprites + spriteSize + 0x250) - 0x04C881).ToString("X4") + " / 0x241D");
			stringBuilder.AppendLine("*Note must save to see the right Size used for the sprites");

			string propertiesInfos = stringBuilder.ToString();
			stringBuilder.Clear();

			ZSUWProperties zsPropForm = new ZSUWProperties();

			zsPropForm.chestItemsBasic = basicchestInfos;
			zsPropForm.chestItems = "Chests items total:" + (chestItemsCount).ToString() + " / 168";
			zsPropForm.chestItemsInfos = allchestInfos.ToString();
			zsPropForm.Properties = propertiesInfos;

			zsPropForm.ShowDialog();
		}

		private void uploadVanillaCopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			VanillaROM.SetVanillaROM();
		}

		private void applyFastROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!VanillaROM.CheckForVanillaROM())
			{
				return;
			}

			int count = FastRomifier.Fastify(ROM.DATA);

			if (count == 0)
			{
				UIText.ShowNotice(
					"No fastrom changes were performed.\r\n" +
					"Perhaps your ROM has already been adjusted."
				);
			}
			else
			{

				UIText.ShowNotice(
					$"Successfully adjusted {count} known address{(count == 1 ? "" : "es")} for FastROM",
					"Success"
				);
			}

		}

		private void ViewRoomDataButton_Click(object sender, EventArgs e)
		{
			var viewedRoom = activeScene.room;
			if (viewedRoom == null)
			{
				return;
			}
			var viewerRoom = new RoomDataViewer(viewedRoom);
			viewerRoom.ShowDialog();
		}

        private void zSEditorSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
			ZSEditorSettings settingsForm = new ZSEditorSettings();
			settingsForm.ShowDialog();
			updatePensColors();

        }
    }
}
