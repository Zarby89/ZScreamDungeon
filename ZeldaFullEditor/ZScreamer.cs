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

namespace ZeldaFullEditor.Gui
{
	public partial class ScreamControl : UserControl
	{
		protected readonly ZScreamer ZS;
		public ZScreamer Screamer { get => ZS; }
		public ScreamControl(ZScreamer zs = null)
		{
			ZS = zs ?? new ZScreamer(22);
		}

		public ScreamControl()
		{
			ZS = new ZScreamer(22); ;
		}
	}

	public partial class ScreamForm : Form
	{
		protected readonly ZScreamer ZS;
		public ZScreamer Screamer { get => ZS; }
		public ScreamForm(ZScreamer zs = null)
		{
			ZS = zs ?? new ZScreamer(22);
		}

		public ScreamForm()
		{
			ZS = new ZScreamer(22);
		}
	}
}



namespace ZeldaFullEditor
{
	/// <summary>
	/// Handles everything ever
	/// </summary>
	public partial class ZScreamer
	{
		private Scene active;
		public Scene ActiveScene
		{
			get => active;
			set => SetActiveScene(value);
		}

		public AddressSet Offsets { get; }

		public DungeonMain DungeonForm { get; }
		public DungeonMain MainForm { get; }
		public OverworldEditor OverworldForm { get; }
		public TextEditor TextForm { get; }
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
				OverworldForm.UpdateForMode(value);
				OverworldScene.UpdateForMode(value);
			}
		}

		public GfxGroups GFXGroups;
		public GFX GFXManager;

		private ROMFile rom;
		public ROMFile ROM { get => rom; }

		public ZScreamer(int _)
		{

		}


		// TODO things needs to be split from Dungeon main
		public ZScreamer()
		{
			rom = new ROMFile();

			Offsets = new AddressSet(SNESFunctions.ROMVersion.US);

			TileLister = new RoomObjectTileLister(this);

			GFXGroups = new GfxGroups(this);
			GFXManager = new GFX(this);
			OverworldScene = new SceneOW(this);
			OverworldManager = new Overworld(this);
			UnderworldScene = new SceneUW(this);

			DungeonForm = new DungeonMain(this);
			MainForm = DungeonForm;
			OverworldForm = new OverworldEditor(this);

			PaletteManager = new PaletteHandler(this);

			TextForm = new TextEditor(this);

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
			MainForm.editorsTabControl.SelectTab((int) st);
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
			DungeonForm.allbgsButton.Checked = em == DungeonEditMode.LayerAll;
			DungeonForm.bg1modeButton.Checked = em == DungeonEditMode.Layer1;
			DungeonForm.bg2modeButton.Checked = em == DungeonEditMode.Layer2;
			DungeonForm.bg3modeButton.Checked = em == DungeonEditMode.Layer3;
			DungeonForm.spritemodeButton.Checked = em == DungeonEditMode.Sprites;
			DungeonForm.potmodeButton.Checked = em == DungeonEditMode.Secrets;
			DungeonForm.torchmodeButton.Checked = em == DungeonEditMode.Torches;
			DungeonForm.blockmodeButton.Checked = em == DungeonEditMode.Blocks;
			DungeonForm.doormodeButton.Checked = em == DungeonEditMode.Doors;
			DungeonForm.chestmodeButton.Checked = em == DungeonEditMode.Chests;
			DungeonForm.collisionModeButton.Checked = em == DungeonEditMode.CollisionMap;
		}

		public void SetSelectedMessageID(int id)
		{
			TextForm.SelectMessageID(id);
			TextForm.Refresh();
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
		Chests,
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
