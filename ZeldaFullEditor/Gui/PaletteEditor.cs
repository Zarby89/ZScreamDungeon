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
    public partial class PaletteEditor : UserControl
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

        Color[] overworld_GrassPal = new Color[3];
        Color[][] object3D_Pal = new Color[2][];
        Color[][] overworld_Maps_Pal = new Color[2][];

        Color tempColor;
        int tempIndex = -1;

        ColorDialog cd = new ColorDialog();

        DungeonMain mainForm;
        Color[] selectedPalette = null;
        int selectedX = 16;

        public PaletteEditor(DungeonMain mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

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

            palettesTreeView.Nodes["OverworldGrassPal"].Nodes.Add("Overworld Grass");

            palettesTreeView.Nodes["Objects3DPal"].Nodes.Add("Triforce");
            palettesTreeView.Nodes["Objects3DPal"].Nodes.Add("Crystal");

            for (int i = 0; i < 2; i++)
            {
                palettesTreeView.Nodes["OverworldMapsPal"].Nodes.Add("Overworld Maps  " + i.ToString("D2"));
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
            GFX.loadedPalettes = GFX.LoadDungeonPalette(mainForm.activeScene.room.palette);
            GFX.loadedSprPalettes = GFX.LoadSpritesPalette(mainForm.activeScene.room.palette);
            mainForm.activeScene.room.reloadGfx();
            mainForm.activeScene.DrawRoom();
            mainForm.activeScene.Refresh();
            palettePicturebox.Refresh();
        }

        private void palettesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["HudPal"])
            {
                selectedPalette = Palettes.HudPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 16;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldMainPal"])
            {
                selectedPalette = Palettes.OverworldMainPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldAuxPal"])
            {
                selectedPalette = Palettes.OverworldAuxPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldAnimatedPal"])
            {
                selectedPalette = Palettes.OverworldAnimatedPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["DungeonMainPal"])
            {
                selectedPalette = Palettes.DungeonsMainPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 15;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["GlobalSpritesPal"])
            {
                selectedPalette = Palettes.GlobalSpritePalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 15;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux1Pal"])
            {
                selectedPalette = Palettes.SpritesAux1Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux2Pal"])
            {
                selectedPalette = Palettes.SpritesAux2Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux3Pal"])
            {
                selectedPalette = Palettes.SpritesAux3Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["ShieldsPal"])
            {
                selectedPalette = Palettes.ShieldsPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 4;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SwordsPal"])
            {
                selectedPalette = Palettes.SwordsPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 3;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["ArmorsPal"])
            {
                selectedPalette = Palettes.ArmorPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 15;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldGrassPal"])
            {
                selectedPalette = Palettes.OverworldGrassPalettes;
                selectedX = 3;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["Objects3DPal"])
            {
                selectedPalette = Palettes.Object3DPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 8;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldMapsPal"])
            {
                selectedPalette = Palettes.OverworldMiniMapPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 16;
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
                for (int i = 0; i < Palettes.HudPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.HudPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(HudPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldMainPal"])
            {
                for (int i = 0; i < Palettes.OverworldMainPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.OverworldMainPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(OverworldMainPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldAuxPal"])
            {
                for (int i = 0; i < Palettes.OverworldAuxPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.OverworldAuxPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(OverworldAuxPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldAnimatedPal"])
            {
                for (int i = 0; i < Palettes.OverworldAnimatedPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.OverworldAnimatedPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(OverworldAnimatedPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["DungeonMainPal"])
            {
                for (int i = 0; i < Palettes.DungeonsMainPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.DungeonsMainPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(DungeonMainPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["GlobalSpritesPal"])
            {
                for (int i = 0; i < Palettes.GlobalSpritePalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.GlobalSpritePalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(GlobalSpritesPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux1Pal"])
            {
                for (int i = 0; i < Palettes.SpritesAux1Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.SpritesAux1Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(SpritesAux1Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux2Pal"])
            {
                for (int i = 0; i < Palettes.SpritesAux2Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.SpritesAux2Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(SpritesAux2Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux3Pal"])
            {
                for (int i = 0; i < Palettes.SpritesAux3Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.SpritesAux3Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(SpritesAux3Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["ShieldsPal"])
            {
                for (int i = 0; i < Palettes.ShieldsPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.ShieldsPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(ShieldsPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SwordsPal"])
            {
                for (int i = 0; i < Palettes.SwordsPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.SwordsPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(SwordsPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["ArmorsPal"])
            {
                for (int i = 0; i < Palettes.ArmorPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.ArmorPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(ArmorsPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["object3D_Pal"])
            {
                for (int i = 0; i < Palettes.Object3DPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.Object3DPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(object3D_Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["overworld_Maps_Pal"])
            {
                for (int i = 0; i < Palettes.OverworldMiniMapPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.OverworldMiniMapPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(overworld_Maps_Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
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
                HudPal[i] = new Color[Palettes.HudPalettes[i].Length];
                for (int j = 0; j < Palettes.HudPalettes[i].Length; j++)
                {
                    HudPal[i][j] = Color.FromArgb(Palettes.HudPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 6; i++)
            {
                OverworldMainPal[i] = new Color[Palettes.OverworldMainPalettes[i].Length];
                for (int j = 0; j < Palettes.OverworldMainPalettes[i].Length; j++)
                {
                    OverworldMainPal[i][j] = Color.FromArgb(Palettes.OverworldMainPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 20; i++)
            {
                OverworldAuxPal[i] = new Color[Palettes.OverworldAuxPalettes[i].Length];
                for (int j = 0; j < Palettes.OverworldAuxPalettes[i].Length; j++)
                {
                    OverworldAuxPal[i][j] = Color.FromArgb(Palettes.OverworldAuxPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 14; i++)
            {
                OverworldAnimatedPal[i] = new Color[Palettes.OverworldAnimatedPalettes[i].Length];
                for (int j = 0; j < Palettes.OverworldAnimatedPalettes[i].Length; j++)
                {
                    OverworldAnimatedPal[i][j] = Color.FromArgb(Palettes.OverworldAnimatedPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 20; i++)
            {

                DungeonMainPal[i] = new Color[Palettes.DungeonsMainPalettes[i].Length];
                for (int j = 0; j < Palettes.DungeonsMainPalettes[i].Length; j++)
                {
                    DungeonMainPal[i][j] = Color.FromArgb(Palettes.DungeonsMainPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 2; i++)
            {
                GlobalSpritesPal[i] = new Color[Palettes.GlobalSpritePalettes[i].Length];
                for (int j = 0; j < Palettes.GlobalSpritePalettes[i].Length; j++)
                {
                    GlobalSpritesPal[i][j] = Color.FromArgb(Palettes.GlobalSpritePalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 12; i++)
            {
                SpritesAux1Pal[i] = new Color[Palettes.SpritesAux1Palettes[i].Length];
                for (int j = 0; j < Palettes.SpritesAux1Palettes[i].Length; j++)
                {
                    SpritesAux1Pal[i][j] = Color.FromArgb(Palettes.SpritesAux1Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 11; i++)
            {
                SpritesAux2Pal[i] = new Color[Palettes.SpritesAux2Palettes[i].Length];
                for (int j = 0; j < Palettes.SpritesAux2Palettes[i].Length; j++)
                {
                    SpritesAux2Pal[i][j] = Color.FromArgb(Palettes.SpritesAux2Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 24; i++)
            {
                SpritesAux3Pal[i] = new Color[Palettes.SpritesAux3Palettes[i].Length];
                for (int j = 0; j < Palettes.SpritesAux3Palettes[i].Length; j++)
                {
                    SpritesAux3Pal[i][j] = Color.FromArgb(Palettes.SpritesAux3Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 3; i++)
            {
                ShieldsPal[i] = new Color[Palettes.ShieldsPalettes[i].Length];
                for (int j = 0; j < Palettes.ShieldsPalettes[i].Length; j++)
                {
                    ShieldsPal[i][j] = Color.FromArgb(Palettes.ShieldsPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 4; i++)
            {
                SwordsPal[i] = new Color[Palettes.SwordsPalettes[i].Length];
                for (int j = 0; j < Palettes.SwordsPalettes[i].Length; j++)
                {
                    SwordsPal[i][j] = Color.FromArgb(Palettes.SwordsPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 5; i++)
            {
                ArmorsPal[i] = new Color[Palettes.ArmorPalettes[i].Length];
                for (int j = 0; j < Palettes.ArmorPalettes[i].Length; j++)
                {
                    ArmorsPal[i][j] = Color.FromArgb(Palettes.ArmorPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 2; i++)
            {
                object3D_Pal[i] = new Color[Palettes.Object3DPalettes[i].Length];
                for (int j = 0; j < Palettes.Object3DPalettes[i].Length; j++)
                {
                    object3D_Pal[i][j] = Color.FromArgb(Palettes.Object3DPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 2; i++)
            {
                overworld_Maps_Pal[i] = new Color[Palettes.OverworldMiniMapPalettes[i].Length];
                for (int j = 0; j < Palettes.OverworldMiniMapPalettes[i].Length; j++)
                {
                    overworld_Maps_Pal[i][j] = Color.FromArgb(Palettes.OverworldMiniMapPalettes[i][j].ToArgb());
                }
            }
        }

        private void RestoreallPalettes()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < Palettes.HudPalettes[i].Length; j++)
                {
                    Palettes.HudPalettes[i][j] = Color.FromArgb(HudPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < Palettes.OverworldMainPalettes[i].Length; j++)
                {
                    Palettes.OverworldMainPalettes[i][j] = Color.FromArgb(OverworldMainPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < Palettes.OverworldAuxPalettes[i].Length; j++)
                {
                    Palettes.OverworldAuxPalettes[i][j] = Color.FromArgb(OverworldAuxPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < Palettes.OverworldAnimatedPalettes[i].Length; j++)
                {
                    Palettes.OverworldAnimatedPalettes[i][j] = Color.FromArgb(OverworldAnimatedPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < Palettes.DungeonsMainPalettes[i].Length; j++)
                {
                    Palettes.DungeonsMainPalettes[i][j] = Color.FromArgb(DungeonMainPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < Palettes.GlobalSpritePalettes[i].Length; j++)
                {
                    Palettes.GlobalSpritePalettes[i][j] = Color.FromArgb(GlobalSpritesPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < Palettes.SpritesAux1Palettes[i].Length; j++)
                {
                    Palettes.SpritesAux1Palettes[i][j] = Color.FromArgb(SpritesAux1Pal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < Palettes.SpritesAux2Palettes[i].Length; j++)
                {
                    Palettes.SpritesAux2Palettes[i][j] = Color.FromArgb(SpritesAux2Pal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < Palettes.SpritesAux3Palettes[i].Length; j++)
                {
                    Palettes.SpritesAux3Palettes[i][j] = Color.FromArgb(SpritesAux3Pal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < Palettes.ShieldsPalettes[i].Length; j++)
                {
                    Palettes.ShieldsPalettes[i][j] = Color.FromArgb(ShieldsPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < Palettes.SwordsPalettes[i].Length; j++)
                {
                    Palettes.SwordsPalettes[i][j] = Color.FromArgb(SwordsPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < Palettes.ArmorPalettes[i].Length; j++)
                {
                    Palettes.ArmorPalettes[i][j] = Color.FromArgb(ArmorsPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < Palettes.Object3DPalettes[i].Length; j++)
                {
                    Palettes.Object3DPalettes[i][j] = Color.FromArgb(object3D_Pal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < Palettes.OverworldMiniMapPalettes[i].Length; j++)
                {
                    Palettes.OverworldMiniMapPalettes[i][j] = Color.FromArgb(overworld_Maps_Pal[i][j].ToArgb());
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
                        mainForm.overworldEditor.overworld.AllMaps[i].LoadPalette();
                    }

                    mainForm.overworldEditor.scene.Refresh();
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
                    mainForm.overworldEditor.overworld.AllMaps[i].LoadPalette();
                }

                mainForm.overworldEditor.scene.Refresh();
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
                    mainForm.overworldEditor.overworld.AllMaps[i].LoadPalette();
                }

                refreshallGfx();
            }
        }

        // Is called when the export palettes button is clicked, writes a .zpd file with all the palette colors.
        private void exportAllPalettes(object sender, EventArgs e)
        {
            byte[] colorArrayData = new byte[Constants.NumberOfColors * 4]; // 3415 total colors * 4 for 4 bytes
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = UIText.ExportedPaletteDataType;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);

                    int count = 0;

                    foreach (Color[] _palette in Palettes.HudPalettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color[] _palette in Palettes.OverworldMainPalettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color[] _palette in Palettes.OverworldAuxPalettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color[] _palette in Palettes.OverworldAnimatedPalettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color _color in Palettes.OverworldGrassPalettes)
                    {
                        byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                        for (int i = buffer.Length - 1; i >= 0; i--)
                        {
                            colorArrayData[count] = buffer[i];
                            count++;
                        }
                    }
                    foreach (Color[] _palette in Palettes.GlobalSpritePalettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color[] _palette in Palettes.ArmorPalettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color[] _palette in Palettes.SwordsPalettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color[] _palette in Palettes.SpritesAux1Palettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color[] _palette in Palettes.SpritesAux2Palettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color[] _palette in Palettes.SpritesAux3Palettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color[] _palette in Palettes.ShieldsPalettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color[] _palette in Palettes.DungeonsMainPalettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color[] _palette in Palettes.Object3DPalettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }
                    foreach (Color[] _palette in Palettes.OverworldMiniMapPalettes)
                    {
                        foreach (Color _color in _palette)
                        {
                            byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                            for (int i = buffer.Length - 1; i >= 0; i--)
                            {
                                colorArrayData[count] = buffer[i];
                                count++;
                            }
                        }
                    }

                    Console.WriteLine("Total color count: " + count);

                    fileStreamMap.Write(colorArrayData, 0, colorArrayData.Length);
                    fileStreamMap.Close();
                }
            }
        }

        private void importAllPalettes(object sender, EventArgs e)
        {
            byte[] colorArrayData = new byte[Constants.NumberOfColors * 4]; // 3415 total colors * 4 for 4 bytes
            using (OpenFileDialog sfd = new OpenFileDialog())
            {
                sfd.Filter = UIText.ExportedPaletteDataType;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.Open, FileAccess.Read);
                    fileStreamMap.Read(colorArrayData, 0, colorArrayData.Length);

                    int count = 0;

                    for (int i = 0; i < Palettes.HudPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.HudPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.HudPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.OverworldMainPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.OverworldMainPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.OverworldMainPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.OverworldAuxPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.OverworldAuxPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.OverworldAuxPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.OverworldAnimatedPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.OverworldAnimatedPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.OverworldAnimatedPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.OverworldGrassPalettes.Length; i++)
                    {
                        byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                        Palettes.OverworldGrassPalettes[i] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                        count += 4;
                    }
                    for (int i = 0; i < Palettes.GlobalSpritePalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.GlobalSpritePalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.GlobalSpritePalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.ArmorPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.ArmorPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.ArmorPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.SwordsPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.SwordsPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.SwordsPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.SpritesAux1Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.SpritesAux1Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.SpritesAux1Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.SpritesAux2Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.SpritesAux2Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.SpritesAux2Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.SpritesAux3Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.SpritesAux3Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.SpritesAux3Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.ShieldsPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.ShieldsPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.ShieldsPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.DungeonsMainPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.DungeonsMainPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.DungeonsMainPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.Object3DPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.Object3DPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.Object3DPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.OverworldMiniMapPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.OverworldMiniMapPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.OverworldMiniMapPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            byte[] selectedcolorbytes = new byte[selectedPalette.Length*3];
            int i = 0;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(fd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                foreach(Color c in selectedPalette)
                {
                    selectedcolorbytes[i] = c.R;
                    selectedcolorbytes[i+1] = c.G;
                    selectedcolorbytes[i+2] = c.B;
                    i += 3;
                }
                fs.Write(selectedcolorbytes,0, selectedcolorbytes.Length);
                fs.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            byte[] selectedcolorbytes = new byte[selectedPalette.Length * 3];
            int i = 0;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(fd.FileName, FileMode.Open, FileAccess.Read);
                fs.Read(selectedcolorbytes, 0, selectedcolorbytes.Length);
                foreach (Color c in selectedPalette)
                {
                    selectedPalette[i/3] = Color.FromArgb(selectedcolorbytes[i], selectedcolorbytes[i + 1], selectedcolorbytes[i + 2]);
                    i += 3;
                }
                
                fs.Close();
                refreshallGfx();
                
            }
        }
    }
}
