using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Gui;

namespace ZeldaFullEditor.Gui
{
	public partial class ScreamControl : UserControl
	{
		protected readonly ZScreamer ZS;
		public ZScreamer Screamer { get => ZS; }
		public ScreamControl(ZScreamer parent = null)
		{
			ZS = parent ?? new ZScreamer(22);
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
		public ScreamForm(ZScreamer parent = null)
		{
			ZS = parent ?? new ZScreamer(22);
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
	public class ZScreamer
	{
		private Scene active;
		public Scene ActiveScene
		{
			get => active;
			set => SetActiveScene(value);
		}

		public DungeonMain DungeonForm;
		public DungeonMain MainForm;
		public OverworldEditor OverworldForm;
		public TextEditor TextForm;

		public Overworld OverworldManager;
		public PaletteHandler PaletteManager;

		public TabSelection curtab;
		public TabSelection CurrentTab
		{
			get => curtab;
			set => SelectTab(value);
		}

		public SceneUW UnderworldScene;
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
			set => SetOverworldEditMode(value);
		}

		public GfxGroups GFXGroups;
		public GFX GFXManager;

		private ROMFile rom;
		public ROMFile ROM { get => rom; }

		public ZScreamer(int dummy)
		{

		}


		// TODO things needs to be split from Dungeon main
		public ZScreamer()
		{
			rom = new ROMFile();

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

		public void SetOverworldEditMode(OverworldEditMode em)
		{
			owmode = em;
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
