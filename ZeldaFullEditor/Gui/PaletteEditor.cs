using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZeldaFullEditor.Gui
{
	public partial class PaletteEditor : ScreamControl
	{
		Color[][] HudPal = new Color[2][];
		Color[][] OverworldMainPal = new Color[6][];
		Color[][] OverworldAuxPal = new Color[20][];
		Color[][] OverworldAnimatedPal = new Color[14][];
		Color[][] DungeonMainPal = new Color[20][];
		Color[][] GlobalSpritesPal = new Color[2][];
		Color[][] SpritesAux1Pal = new Color[12][];
		Color[][] SpritesAux2Pal = new Color[11][];
		Color[][] SpritesAux3Pal = new Color[24][];
		Color[][] ShieldsPal = new Color[3][];
		Color[][] SwordsPal = new Color[4][];
		Color[][] ArmorsPal = new Color[5][];

		Color tempColor;
		int tempIndex = -1;

		ColorDialog cd = new ColorDialog();

		Color[] selectedPalette = null;
		int selectedX = 16;

		public PaletteEditor(ZScreamer parent) : base(parent)
		{
			InitializeComponent();

			CreateTempPalettes();
			// Create temp of all palettes
			for (int i = 0; i < 2; i++)
			{
				palettesTreeView.Nodes["HudPal"].Nodes.Add("Hud " + i.ToString("D2"));
			}

			for (int i = 0; i < 6; i++)
			{
				palettesTreeView.Nodes["OverworldMainPal"].Nodes.Add("Main " + i.ToString("D2"));
			}

			for (int i = 0; i < 20; i++)
			{
				palettesTreeView.Nodes["OverworldAuxPal"].Nodes.Add("Aux " + i.ToString("D2"));
			}

			for (int i = 0; i < 14; i++)
			{
				palettesTreeView.Nodes["OverworldAnimatedPal"].Nodes.Add("Animated " + i.ToString("D2"));
			}

			for (int i = 0; i < 20; i++)
			{
				palettesTreeView.Nodes["DungeonMainPal"].Nodes.Add("Main " + i.ToString("D2"));
			}

			for (int i = 0; i < 2; i++)
			{
				palettesTreeView.Nodes["GlobalSpritesPal"].Nodes.Add("Global " + i.ToString("D2"));
			}

			for (int i = 0; i < 12; i++)
			{
				palettesTreeView.Nodes["SpritesAux1Pal"].Nodes.Add("Aux " + i.ToString("D2"));
			}

			for (int i = 0; i < 11; i++)
			{
				palettesTreeView.Nodes["SpritesAux2Pal"].Nodes.Add("Aux " + i.ToString("D2"));
			}

			for (int i = 0; i < 24; i++)
			{
				palettesTreeView.Nodes["SpritesAux3Pal"].Nodes.Add("Aux " + i.ToString("D2"));
			}

			for (int i = 0; i < 3; i++)
			{
				palettesTreeView.Nodes["ShieldsPal"].Nodes.Add("Shields " + i.ToString("D2"));
			}

			for (int i = 0; i < 4; i++)
			{
				palettesTreeView.Nodes["SwordsPal"].Nodes.Add("Swords " + i.ToString("D2"));
			}

			for (int i = 0; i < 5; i++)
			{
				palettesTreeView.Nodes["ArmorsPal"].Nodes.Add("Armors " + i.ToString("D2"));
			}
		}

		private void PaletteEditor_VisibleChanged(object sender, EventArgs e)
		{
			this.BackColor = Color.FromKnownColor(KnownColor.Control);
		}

		private void applyButton_Click(object sender, EventArgs e)
		{
			CreateTempPalettes();

			// Recreate temp of all palettes
		}

		private void PaletteEditor_Load(object sender, EventArgs e)
		{
			// TODO: Add something here?
		}

		private void restoreallButton_Click(object sender, EventArgs e)
		{
			// Restore temp of all palettes
			if (MessageBox.Show("Are you sure you want to restore all palettes " +
				"to the last applied values?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				RestoreallPalettes();
			}
		}

		private void restoreselButton_Click(object sender, EventArgs e)
		{
			restoreSelected();
			refreshallGfx();

			// Restore the temp selected palette only
		}

		private void refreshallGfx()
		{
			ZS.GFXManager.loadedPalettes = ZS.GFXManager.LoadDungeonPalette(ZS.UnderworldScene.Room.palette);
			ZS.GFXManager.loadedSprPalettes = ZS.GFXManager.LoadSpritesPalette(ZS.UnderworldScene.Room.palette);
			ZS.UnderworldScene.Room.reloadGfx();
			ZS.UnderworldScene.DrawRoom();
			ZS.UnderworldScene.Refresh();
			palettePicturebox.Refresh();
		}

		private void palettesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["HudPal"])
			{
				selectedPalette = ZS.PaletteManager.HUD[palettesTreeView.SelectedNode.Index];
				selectedX = 16;
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldMainPal"])
			{
				selectedPalette = ZS.PaletteManager.OverworldMain[palettesTreeView.SelectedNode.Index];
				selectedX = 7;
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldAuxPal"])
			{
				selectedPalette = ZS.PaletteManager.OverworldAux[palettesTreeView.SelectedNode.Index];
				selectedX = 7;
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldAnimatedPal"])
			{
				selectedPalette = ZS.PaletteManager.OverworldAnimated[palettesTreeView.SelectedNode.Index];
				selectedX = 7;
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["DungeonMainPal"])
			{
				selectedPalette = ZS.PaletteManager.UnderworldMain[palettesTreeView.SelectedNode.Index];
				selectedX = 15;
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["GlobalSpritesPal"])
			{
				selectedPalette = ZS.PaletteManager.SpriteGlobal[palettesTreeView.SelectedNode.Index];
				selectedX = 15;
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux1Pal"])
			{
				selectedPalette = ZS.PaletteManager.SpriteAux1[palettesTreeView.SelectedNode.Index];
				selectedX = 7;
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux2Pal"])
			{
				selectedPalette = ZS.PaletteManager.SpriteAux2[palettesTreeView.SelectedNode.Index];
				selectedX = 7;
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux3Pal"])
			{
				selectedPalette = ZS.PaletteManager.SpriteAux3[palettesTreeView.SelectedNode.Index];
				selectedX = 7;
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["ShieldsPal"])
			{
				selectedPalette = ZS.PaletteManager.PlayerShield[palettesTreeView.SelectedNode.Index];
				selectedX = 4;
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SwordsPal"])
			{
				selectedPalette = ZS.PaletteManager.PlayerSword[palettesTreeView.SelectedNode.Index];
				selectedX = 3;
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["ArmorsPal"])
			{
				selectedPalette = ZS.PaletteManager.PlayerMail[palettesTreeView.SelectedNode.Index];
				selectedX = 15;
			}
			else
			{
				selectedPalette = null;
			}

			palettePicturebox.Refresh();
		}

		private void restoreSelected()
		{
			if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["HudPal"])
			{
				for (int i = 0; i < ZS.PaletteManager.HUD[palettesTreeView.SelectedNode.Index].Length; i++)
				{
					ZS.PaletteManager.HUD[palettesTreeView.SelectedNode.Index][i] = HudPal[palettesTreeView.SelectedNode.Index][i].NewCopy();
				}
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldMainPal"])
			{
				for (int i = 0; i < ZS.PaletteManager.OverworldMain[palettesTreeView.SelectedNode.Index].Length; i++)
				{
					ZS.PaletteManager.OverworldMain[palettesTreeView.SelectedNode.Index][i] = OverworldMainPal[palettesTreeView.SelectedNode.Index][i].NewCopy();
				}
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldAuxPal"])
			{
				for (int i = 0; i < ZS.PaletteManager.OverworldAux[palettesTreeView.SelectedNode.Index].Length; i++)
				{
					ZS.PaletteManager.OverworldAux[palettesTreeView.SelectedNode.Index][i] = OverworldAuxPal[palettesTreeView.SelectedNode.Index][i].NewCopy();
				}
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldAnimatedPal"])
			{
				for (int i = 0; i < ZS.PaletteManager.OverworldAnimated[palettesTreeView.SelectedNode.Index].Length; i++)
				{
					ZS.PaletteManager.OverworldAnimated[palettesTreeView.SelectedNode.Index][i] = OverworldAnimatedPal[palettesTreeView.SelectedNode.Index][i].NewCopy();
				}
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["DungeonMainPal"])
			{
				for (int i = 0; i < ZS.PaletteManager.UnderworldMain[palettesTreeView.SelectedNode.Index].Length; i++)
				{
					ZS.PaletteManager.UnderworldMain[palettesTreeView.SelectedNode.Index][i] = DungeonMainPal[palettesTreeView.SelectedNode.Index][i].NewCopy();
				}
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["GlobalSpritesPal"])
			{
				for (int i = 0; i < ZS.PaletteManager.SpriteGlobal[palettesTreeView.SelectedNode.Index].Length; i++)
				{
					ZS.PaletteManager.SpriteGlobal[palettesTreeView.SelectedNode.Index][i] = GlobalSpritesPal[palettesTreeView.SelectedNode.Index][i].NewCopy();
				}
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux1Pal"])
			{
				for (int i = 0; i < ZS.PaletteManager.SpriteAux1[palettesTreeView.SelectedNode.Index].Length; i++)
				{
					ZS.PaletteManager.SpriteAux1[palettesTreeView.SelectedNode.Index][i] = SpritesAux1Pal[palettesTreeView.SelectedNode.Index][i].NewCopy();
				}
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux2Pal"])
			{
				for (int i = 0; i < ZS.PaletteManager.SpriteAux2[palettesTreeView.SelectedNode.Index].Length; i++)
				{
					ZS.PaletteManager.SpriteAux2[palettesTreeView.SelectedNode.Index][i] = SpritesAux2Pal[palettesTreeView.SelectedNode.Index][i].NewCopy();
				}
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux3Pal"])
			{
				for (int i = 0; i < ZS.PaletteManager.SpriteAux3[palettesTreeView.SelectedNode.Index].Length; i++)
				{
					ZS.PaletteManager.SpriteAux3[palettesTreeView.SelectedNode.Index][i] = SpritesAux3Pal[palettesTreeView.SelectedNode.Index][i].NewCopy();
				}
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["ShieldsPal"])
			{
				for (int i = 0; i < ZS.PaletteManager.PlayerShield[palettesTreeView.SelectedNode.Index].Length; i++)
				{
					ZS.PaletteManager.PlayerShield[palettesTreeView.SelectedNode.Index][i] = ShieldsPal[palettesTreeView.SelectedNode.Index][i].NewCopy();
				}
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SwordsPal"])
			{
				for (int i = 0; i < ZS.PaletteManager.PlayerSword[palettesTreeView.SelectedNode.Index].Length; i++)
				{
					ZS.PaletteManager.PlayerSword[palettesTreeView.SelectedNode.Index][i] = SwordsPal[palettesTreeView.SelectedNode.Index][i].NewCopy();
				}
			}
			else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["ArmorsPal"])
			{
				for (int i = 0; i < ZS.PaletteManager.PlayerMail[palettesTreeView.SelectedNode.Index].Length; i++)
				{
					ZS.PaletteManager.PlayerMail[palettesTreeView.SelectedNode.Index][i] = ArmorsPal[palettesTreeView.SelectedNode.Index][i].NewCopy();
				}
			}

			palettePicturebox.Refresh();
		}

		private void palettePicturebox_Paint(object sender, PaintEventArgs e)
		{
			if (selectedPalette != null)
			{
				for (int i = 0; i < selectedPalette.Length; i++)
				{
					e.Graphics.FillRectangle(new SolidBrush(selectedPalette[i]), new Rectangle(((i % selectedX) * 16), (i / selectedX) * 16, 16, 16));
				}
			}
			else
			{
				e.Graphics.Clear(Color.FromKnownColor(KnownColor.Control));
			}
		}

		private void CreateTempPalettes()
		{
			for (int i = 0; i < 2; i++)
			{
				HudPal[i] = new Color[ZS.PaletteManager.HUD[i].Length];
				for (int j = 0; j < ZS.PaletteManager.HUD[i].Length; j++)
				{
					HudPal[i][j] = ZS.PaletteManager.HUD[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 6; i++)
			{
				OverworldMainPal[i] = new Color[ZS.PaletteManager.OverworldMain[i].Length];
				for (int j = 0; j < ZS.PaletteManager.OverworldMain[i].Length; j++)
				{
					OverworldMainPal[i][j] = ZS.PaletteManager.OverworldMain[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 20; i++)
			{
				OverworldAuxPal[i] = new Color[ZS.PaletteManager.OverworldAux[i].Length];
				for (int j = 0; j < ZS.PaletteManager.OverworldAux[i].Length; j++)
				{
					OverworldAuxPal[i][j] = ZS.PaletteManager.OverworldAux[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 14; i++)
			{
				OverworldAnimatedPal[i] = new Color[ZS.PaletteManager.OverworldAnimated[i].Length];
				for (int j = 0; j < ZS.PaletteManager.OverworldAnimated[i].Length; j++)
				{
					OverworldAnimatedPal[i][j] = ZS.PaletteManager.OverworldAnimated[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 20; i++)
			{

				DungeonMainPal[i] = new Color[ZS.PaletteManager.UnderworldMain[i].Length];
				for (int j = 0; j < ZS.PaletteManager.UnderworldMain[i].Length; j++)
				{
					DungeonMainPal[i][j] = ZS.PaletteManager.UnderworldMain[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 2; i++)
			{
				GlobalSpritesPal[i] = new Color[ZS.PaletteManager.SpriteGlobal[i].Length];
				for (int j = 0; j < ZS.PaletteManager.SpriteGlobal[i].Length; j++)
				{
					GlobalSpritesPal[i][j] = ZS.PaletteManager.SpriteGlobal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 12; i++)
			{
				SpritesAux1Pal[i] = new Color[ZS.PaletteManager.SpriteAux1[i].Length];
				for (int j = 0; j < ZS.PaletteManager.SpriteAux1[i].Length; j++)
				{
					SpritesAux1Pal[i][j] = ZS.PaletteManager.SpriteAux1[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 11; i++)
			{
				SpritesAux2Pal[i] = new Color[ZS.PaletteManager.SpriteAux2[i].Length];
				for (int j = 0; j < ZS.PaletteManager.SpriteAux2[i].Length; j++)
				{
					SpritesAux2Pal[i][j] = ZS.PaletteManager.SpriteAux2[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 24; i++)
			{
				SpritesAux3Pal[i] = new Color[ZS.PaletteManager.SpriteAux3[i].Length];
				for (int j = 0; j < ZS.PaletteManager.SpriteAux3[i].Length; j++)
				{
					SpritesAux3Pal[i][j] = ZS.PaletteManager.SpriteAux3[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 3; i++)
			{

				ShieldsPal[i] = new Color[ZS.PaletteManager.PlayerShield[i].Length];
				for (int j = 0; j < ZS.PaletteManager.PlayerShield[i].Length; j++)
				{
					ShieldsPal[i][j] = ZS.PaletteManager.PlayerShield[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 4; i++)
			{
				SwordsPal[i] = new Color[ZS.PaletteManager.PlayerSword[i].Length];
				for (int j = 0; j < ZS.PaletteManager.PlayerSword[i].Length; j++)
				{
					SwordsPal[i][j] = ZS.PaletteManager.PlayerSword[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 5; i++)
			{
				ArmorsPal[i] = new Color[ZS.PaletteManager.PlayerMail[i].Length];
				for (int j = 0; j < ZS.PaletteManager.PlayerMail[i].Length; j++)
				{
					ArmorsPal[i][j] = ZS.PaletteManager.PlayerMail[i][j].NewCopy();
				}
			}
		}

		private void RestoreallPalettes()
		{
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < ZS.PaletteManager.HUD[i].Length; j++)
				{
					ZS.PaletteManager.HUD[i][j] = HudPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < ZS.PaletteManager.OverworldMain[i].Length; j++)
				{
					ZS.PaletteManager.OverworldMain[i][j] = OverworldMainPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < ZS.PaletteManager.OverworldAux[i].Length; j++)
				{
					ZS.PaletteManager.OverworldAux[i][j] = OverworldAuxPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 14; i++)
			{
				for (int j = 0; j < ZS.PaletteManager.OverworldAnimated[i].Length; j++)
				{
					ZS.PaletteManager.OverworldAnimated[i][j] = OverworldAnimatedPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < ZS.PaletteManager.UnderworldMain[i].Length; j++)
				{
					ZS.PaletteManager.UnderworldMain[i][j] = DungeonMainPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < ZS.PaletteManager.SpriteGlobal[i].Length; j++)
				{
					ZS.PaletteManager.SpriteGlobal[i][j] = GlobalSpritesPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 12; i++)
			{
				for (int j = 0; j < ZS.PaletteManager.SpriteAux1[i].Length; j++)
				{
					ZS.PaletteManager.SpriteAux1[i][j] = SpritesAux1Pal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 11; i++)
			{
				for (int j = 0; j < ZS.PaletteManager.SpriteAux2[i].Length; j++)
				{
					ZS.PaletteManager.SpriteAux2[i][j] = SpritesAux2Pal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 24; i++)
			{
				for (int j = 0; j < ZS.PaletteManager.SpriteAux3[i].Length; j++)
				{
					ZS.PaletteManager.SpriteAux3[i][j] = SpritesAux3Pal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < ZS.PaletteManager.PlayerShield[i].Length; j++)
				{
					ZS.PaletteManager.PlayerShield[i][j] = ShieldsPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < ZS.PaletteManager.PlayerSword[i].Length; j++)
				{
					ZS.PaletteManager.PlayerSword[i][j] = SwordsPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < ZS.PaletteManager.PlayerMail[i].Length; j++)
				{
					
					ZS.PaletteManager.PlayerMail[i][j] = ArmorsPal[i][j].NewCopy();
				}
			}

			refreshallGfx();
		}

		private void palettePicturebox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if ((e.X / 16) < selectedX && ((e.Y / 16) * selectedX) < selectedPalette.Length)
				{
					int cindex = (e.X / 16) + ((e.Y / 16) * selectedX);
					tempIndex = cindex;
					tempColor = selectedPalette[cindex];
					selectedPalette[cindex] = Color.Fuchsia;

					for (int i = 0; i < 159; i++)
					{
						ZS.OverworldManager.allmaps[i].ReloadPalettes();

					}

					ZS.OverworldScene.Refresh();
					refreshallGfx();
				}
			}
		}

		private void palettePicturebox_MouseUp(object sender, MouseEventArgs e)
		{
			if (tempIndex != -1)
			{
				selectedPalette[tempIndex] = tempColor;
				for (int i = 0; i < 159; i++)
				{
					ZS.OverworldManager.allmaps[i].ReloadPalettes();

				}

				ZS.OverworldScene.Refresh();
				refreshallGfx();
				tempIndex = -1;
			}
		}

		private void palettePicturebox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int cindex = -1;
			if ((e.X / 16) < selectedX && ((e.Y / 16) * selectedX) < selectedPalette.Length)
			{
				cindex = (e.X / 16) + ((e.Y / 16) * selectedX);
			}

			if (cindex != -1)
			{
				cd.Color = selectedPalette[cindex];
				if (cd.ShowDialog() == DialogResult.OK)
				{
					selectedPalette[cindex] = cd.Color;
				}

				for (int i = 0; i < 159; i++)
				{
					ZS.OverworldManager.allmaps[i].ReloadPalettes();
				}

				refreshallGfx();
			}
		}

		private static void ExportSinglePaletteBlock(Color[][] paletteBlock, byte[] buffer, ref int count)
		{
			foreach (Color[] palette in paletteBlock)
			{
				ExportSinglePalette(palette, buffer, ref count);
			}
		}

		private static void ExportSinglePalette(Color[] palette, byte[] buffer, ref int count)
		{
			foreach (Color color in palette)
			{
				buffer[count++] = color.R;
				buffer[count++] = color.G;
				buffer[count++] = color.B;
			}
		}

		// Is called when the export palettes button is clicked, writes a .zpd file with all the palette colors.
		private void exportAllPalettes(object sender, EventArgs e)
		{
			
			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = UIText.ExportedPaletteDataType;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					byte[] colorArrayData = new byte[Constants.NumberOfColors * 3];
					ImportOrExportAllPalettes(export: true, colorArrayData);

					FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);

					fileStreamMap.Write(colorArrayData, 0, colorArrayData.Length);
					fileStreamMap.Close();
				}
			}
		}

		private void importAllPalettes(object sender, EventArgs e)
		{
			using (OpenFileDialog sfd = new OpenFileDialog())
			{
				sfd.Filter = UIText.ExportedPaletteDataType;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					byte[] colorArrayData = new byte[Constants.NumberOfColors * 3];

					FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.Open, FileAccess.Read);
					fileStreamMap.Read(colorArrayData, 0, colorArrayData.Length);

					ImportOrExportAllPalettes(export: false, colorArrayData);
				}
			}
		}

		private void ImportSinglePaletteBlock(Color[][] paletteBlock, byte[] buffer, ref int count)
		{
			for (int i = 0; i < paletteBlock.Length; i++)
			{
				ImportSinglePalette(paletteBlock[i], buffer, ref count);
			}
		}

		private void ImportSinglePalette(Color[] palette, byte[] buffer, ref int count)
		{
			for (int i = 0; i < palette.Length; i++)
			{
				palette[i] = Color.FromArgb(255, buffer[count++], buffer[count++], buffer[count++]);
			}
		}

		private void ImportOrExportAllPalettes(bool export, byte[] buffer)
		{
			object[] order =
			{
					ZS.PaletteManager.HUD,
					ZS.PaletteManager.OverworldMain,
					ZS.PaletteManager.OverworldAux,
					ZS.PaletteManager.OverworldAnimated,
					ZS.PaletteManager.OverworldGrass,
					ZS.PaletteManager.SpriteGlobal,
					ZS.PaletteManager.PlayerMail,
					ZS.PaletteManager.PlayerSword,
					ZS.PaletteManager.PlayerShield,
					ZS.PaletteManager.SpriteAux1,
					ZS.PaletteManager.SpriteAux2,
					ZS.PaletteManager.SpriteAux3,
					ZS.PaletteManager.UnderworldMain
			};
			int count = 0;
			foreach (object o in order)
			{
				if (o is Color[][] block)
				{
					if (export)
					{
						ExportSinglePaletteBlock(block, buffer, ref count);
					}
					else
					{
						ImportSinglePaletteBlock(block, buffer, ref count);
					}
				}
				else if (o is Color[] palette)
				{
					if (export)
					{
						ExportSinglePalette(palette, buffer, ref count);
					}
					else
					{
						ImportSinglePalette(palette, buffer, ref count);
					}
				}
			}
		}
	}
}
