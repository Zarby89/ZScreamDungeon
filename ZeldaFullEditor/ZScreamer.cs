using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Gui;
using ZeldaFullEditor.Data.Underworld;
using System.Text.RegularExpressions;
using ZeldaFullEditor.Data;

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


		private Scene active;
		public Scene ActiveScene
		{
			get => active;
			set => SetActiveScene(value);
		}

		public AddressSet Offsets { get; }
		public RoomObjectTileLister TileLister { get; }
		public RoomLayoutLister LayoutLister { get; private set; }

		public Overworld OverworldManager { get; }
		public PaletteHandler PaletteManager { get; }

		public TabSelection curtab;
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

		public SceneOW OverworldScene;
		private OverworldEditMode owmode;

		public OverworldEditMode CurrentOWMode
		{
			get => owmode;
			set
			{
				Program.OverworldForm.UpdateForMode(value);
				OverworldScene.UpdateForMode(value);
			}
		}

		public GfxGroups GFXGroups;
		public GraphicsManager GFXManager;

		private ROMFile rom;
		public ROMFile ROM { get => rom; }

		public ZScreamer(int _)
		{

		}

		public void SetAsActiveScreamer()
		{
			ActiveScreamer = this;
		}

		// TODO things needs to be split from Dungeon main
		public ZScreamer()
		{
			rom = new ROMFile();

			Offsets = new AddressSet(SNESFunctions.ROMVersion.US);

			TileLister = new RoomObjectTileLister(this);

			GFXGroups = new GfxGroups(this);
			GFXManager = new GraphicsManager(this);
			OverworldScene = new SceneOW(this);
			OverworldManager = new Overworld(this);
			UnderworldScene = new SceneUW(this);
			PaletteManager = new PaletteHandler(this);

			// MainForm.SetForms(DungeonForm, OverworldForm)
		}

		public void OnRomLoad()
		{
			LayoutLister = RoomLayoutLister.CreateLayoutsFromROM(this);
		}


		public void SetActiveScene(Scene s)
		{
			active = s;
		}

		public void SelectTab(TabSelection st)
		{
			Program.MainForm.editorsTabControl.SelectTab((int) st);
			switch (st)
			{
				case TabSelection.DungeonEditor:
					active = UnderworldScene;
					break;
			}
		}

		public void SetDungeonEditMode(DungeonEditMode em)
		{
			uwmode = em;
			Program.DungeonForm.allbgsButton.Checked = em == DungeonEditMode.LayerAll;
			Program.DungeonForm.bg1modeButton.Checked = em == DungeonEditMode.Layer1;
			Program.DungeonForm.bg2modeButton.Checked = em == DungeonEditMode.Layer2;
			Program.DungeonForm.bg3modeButton.Checked = em == DungeonEditMode.Layer3;
			Program.DungeonForm.spritemodeButton.Checked = em == DungeonEditMode.Sprites;
			Program.DungeonForm.potmodeButton.Checked = em == DungeonEditMode.Secrets;
			Program.DungeonForm.torchmodeButton.Checked = em == DungeonEditMode.Torches;
			Program.DungeonForm.blockmodeButton.Checked = em == DungeonEditMode.Blocks;
			Program.DungeonForm.doormodeButton.Checked = em == DungeonEditMode.Doors;
			Program.DungeonForm.collisionModeButton.Checked = em == DungeonEditMode.CollisionMap;
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
		Sprites,
		Secrets,
		Blocks,
		Torches,
		Doors,
		CollisionMap,
		Entrances
	}
	//Exits, Entrances, OWDoor, Flute, EntrancePlacing, Overlay, Gravestone, CollisionMap
	public enum OverworldEditMode
	{
		Tile16,
		Sprites,
		Secrets,
		Entrances,
		Exits,
		Transports,
		Overlay,
		Gravestones,
		Doors,
	}
}
