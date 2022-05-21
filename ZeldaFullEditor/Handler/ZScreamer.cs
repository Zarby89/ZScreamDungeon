namespace ZeldaFullEditor.Handler
{
	/// <summary>
	/// Handles everything ever.
	/// </summary>
	public partial class ZScreamer
	{
		private static readonly ZScreamer dummy = new(1);

		public static ZScreamer ActiveScreamer { get; private set; } = dummy;

		/// <summary>
		/// Returns <see langword="true"/> if an actual, usable <see cref="ZScreamer"/> is active.
		/// </summary>
		public static bool Active => ActiveScreamer != dummy;

		public static ROMFile ActiveROM => ActiveROM;
		public static AddressSet ActiveOffsets => ActiveScreamer.Offsets;
		public static GraphicsManager ActiveGraphicsManager => ActiveScreamer.GFXManager;
		public static SceneOW ActiveOWScene => ActiveScreamer.OverworldScene;
		public static SceneUW ActiveUWScene => ActiveScreamer.UnderworldScene;
		public static Overworld ActiveOW => ActiveScreamer.OverworldManager;
		public static PaletteHandler ActivePaletteManager => ActiveScreamer.PaletteManager;

		public static DungeonEditMode ActiveUWMode => ActiveScreamer.CurrentUWMode;
		public static OverworldEditMode ActiveOWMode => ActiveScreamer.CurrentOWMode;

		//----------------------------------------------------------------------------------------//

		public AddressSet Offsets { get; }
		public RoomObjectTileLister TileLister { get; private set; }
		public RoomLayoutLister LayoutLister { get; private set; }

		public Overworld OverworldManager { get; }
		public PaletteHandler PaletteManager { get; }

		public SceneUW UnderworldScene { get; }

		private DungeonEditMode uwmode = DungeonEditMode.LayerAll;
		public DungeonEditMode CurrentUWMode
		{
			get => uwmode;
			set => SetDungeonEditMode(value);
		}

		public SceneOW OverworldScene { get; }
		private OverworldEditMode owmode = OverworldEditMode.Tile16;

		public OverworldEditMode CurrentOWMode
		{
			get => owmode;
			set => SetOverworldEditMode(value);
		}

		public GraphicsManager GFXManager { get; }

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
			ROM = new();

			Offsets = new(SNESFunctions.ROMVersion.US);
			GFXManager = new(this);
			OverworldScene = new(this);
			OverworldManager = new(this);
			UnderworldScene = new(this);
			PaletteManager = new(this);
		}

		public void LoadNewROM(string filename)
		{
			ROM = new(filename);
			OnROMLoad();
		}

		public void OnROMLoad()
		{
			PaletteManager.CreateAllPalettes();
			TileLister = RoomObjectTileLister.CreateTileListingsFromROM(this);
			LayoutLister = RoomLayoutLister.CreateLayoutsFromROM(this);

			GFXManager.OnROMLoad();

			OverworldManager.Init();

			SpriteProps = SpriteProperties.MakeNewSpriteListFromROM(this);

			for (ushort i = 0; i < Constants.NumberOfRooms; i++)
			{
				all_rooms[i] = Room.BuildRoomFromROM(this, i);
				//DungeonsData.undoRoom[i] = new List<Room>();
				//DungeonsData.redoRoom[i] = new List<Room>();
			}
		}

		public void SetDungeonEditMode(DungeonEditMode em)
		{
			uwmode = em;
			ZGUI.AdjustContextMenu();
			ZGUI.DungeonEditor.UpdateUnderworldMode(em);
			UnderworldScene.UpdateForMode(em);
		}

		private void SetOverworldEditMode(OverworldEditMode om)
		{
			owmode = om;
			ZGUI.OverworldEditor.UpdateForMode(om);
			OverworldScene.UpdateForMode(om);
		}

		public void SetSelectedMessageID(int id)
		{
			ZGUI.TextEditor.SelectMessageID(id);
			ZGUI.TextEditor.Refresh();
		}
	}
}
