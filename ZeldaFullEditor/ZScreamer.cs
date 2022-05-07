using ZeldaFullEditor.Data;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor
{
	/// <summary>
	/// Handles everything ever
	/// </summary>
	public partial class ZScreamer
	{
		public static ZScreamer ActiveScreamer { get; private set; } = new ZScreamer(1);
		public static ROMFile ActiveROM => ActiveScreamer.ROM;
		public static AddressSet ActiveOffsets => ActiveScreamer.Offsets;
		public static GraphicsManager ActiveGraphicsManager => ActiveScreamer.GFXManager;
		public static SceneOW ActiveOWScene => ActiveScreamer.OverworldScene;
		public static SceneUW ActiveUWScene => ActiveScreamer.UnderworldScene;
		public static Overworld ActiveOW => ActiveScreamer.OverworldManager;
		public static PaletteHandler ActivePaletteManager => ActiveScreamer.PaletteManager;

		public static DungeonEditMode ActiveUWMode => ActiveScreamer.CurrentUWMode;
		public static OverworldEditMode ActiveOWMode => ActiveScreamer.CurrentOWMode;

		//----------------------------------------------------------------------------------------//

		private Scene active;
		public Scene ActiveScene
		{
			get => active;
			set => SetActiveScene(value);
		}

		public AddressSet Offsets { get; }
		public RoomObjectTileLister TileLister { get; private set; }
		public RoomLayoutLister LayoutLister { get; private set; }

		public Overworld OverworldManager { get; }
		public PaletteHandler PaletteManager { get; }

		private TabSelection curtab;
		public TabSelection CurrentTab
		{
			get => curtab;
			set => SelectTab(value);
		}

		public SceneUW UnderworldScene { get; }

		private DungeonEditMode uwmode;
		public DungeonEditMode CurrentUWMode
		{
			get => uwmode;
			set => SetDungeonEditMode(value);
		}

		public SceneOW OverworldScene { get; }
		private OverworldEditMode owmode;

		public OverworldEditMode CurrentOWMode
		{
			get => owmode;
			set => SetOverworldEditMode(value);
		}

		public GfxGroups GFXGroups;
		public GraphicsManager GFXManager;

		public ROMFile ROM { get; private set; }

		// Dummy constructor just to make something that does literally nothing for the designer
		private ZScreamer(int _) { }

		public void SetAsActiveScreamer()
		{
			ActiveScreamer = this;
		}

		// TODO things needs to be split from Dungeon main
		public ZScreamer()
		{
			ROM = new ROMFile();

			Offsets = new AddressSet(SNESFunctions.ROMVersion.US);

			GFXGroups = new GfxGroups(this);
			GFXManager = new GraphicsManager(this);
			OverworldScene = new SceneOW(this);
			OverworldManager = new Overworld(this);
			UnderworldScene = new SceneUW(this);
			PaletteManager = new PaletteHandler(this);
		}

		public void LoadNewROM(string filename)
		{
			ROM = new ROMFile(filename);
			OnROMLoad();
		}

		public void OnROMLoad()
		{
			PaletteManager.CreateAllPalettes();
			TileLister = RoomObjectTileLister.CreateTileListingsFromROM(this);
			LayoutLister = RoomLayoutLister.CreateLayoutsFromROM(this);

			GFXGroups.LoadGfxGroups();
			GFXManager.OnROMLoad();

			OverworldManager.Init();

			SpriteProps = SpriteProperties.MakeNewSpriteListFromROM(this);

			for (ushort i = 0; i < Constants.NumberOfRooms; i++)
			{
				all_rooms[i] = DungeonRoom.BuildRoomFromROM(this, i);
				//DungeonsData.undoRoom[i] = new List<Room>();
				//DungeonsData.redoRoom[i] = new List<Room>();
			}
		}


		public void SetActiveScene(Scene s)
		{
			active = s;
		}

		public void SelectTab(TabSelection st)
		{
			curtab = st;
			Program.MainForm.editorsTabControl.SelectTab((int) st);
			switch (st)
			{
				case TabSelection.DungeonEditor:
					active = UnderworldScene;
					break;

				case TabSelection.OverworldEditor:
					active = OverworldScene;
					break;

				default:
					active = null;
					break;
			}
		}

		public void SetDungeonEditMode(DungeonEditMode em)
		{
			uwmode = em;
			Program.DungeonForm.UpdateUnderworldMode(em);
			UnderworldScene.UpdateForMode(em);
		}

		private void SetOverworldEditMode(OverworldEditMode om)
		{
			owmode = om;
			Program.OverworldForm.UpdateForMode(om);
			OverworldScene.UpdateForMode(om);
		}

		public void SetSelectedMessageID(int id)
		{
			Program.TextForm.SelectMessageID(id);
			Program.TextForm.Refresh();
		}
	}

	public enum TabSelection
	{
		DungeonEditor = 0,
		OverworldEditor = 1,
		TextEditor = 3,
	}

	public enum DungeonEditMode
	{
		Layer1 = 0,
		Layer2 = 1,
		Layer3 = 2,
		LayerAll = 3,
		Doors,
		Sprites,
		Secrets,
		Blocks,
		Torches,
		Entrances,
		CollisionMap,
	}

	public enum OverworldEditMode
	{
		Tile16,
		Overlay,
		Sprites,
		Secrets,
		Entrances,
		Exits,
		Transports,
		Gravestones,
		Doors,
	}
}
