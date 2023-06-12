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
                selectedPalette = Palettes.overworld_MainPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldAuxPal"])
            {
                selectedPalette = Palettes.overworld_AuxPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldAnimatedPal"])
            {
                selectedPalette = Palettes.overworld_AnimatedPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["DungeonMainPal"])
            {
                selectedPalette = Palettes.dungeonsMain_Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 15;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["GlobalSpritesPal"])
            {
                selectedPalette = Palettes.globalSprite_Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 15;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux1Pal"])
            {
                selectedPalette = Palettes.spritesAux1_Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux2Pal"])
            {
                selectedPalette = Palettes.spritesAux2_Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux3Pal"])
            {
                selectedPalette = Palettes.spritesAux3_Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["ShieldsPal"])
            {
                selectedPalette = Palettes.shields_Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 4;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SwordsPal"])
            {
                selectedPalette = Palettes.swords_Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 3;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["ArmorsPal"])
            {
                selectedPalette = Palettes.armors_Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 15;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldGrassPal"])
            {
                selectedPalette = Palettes.overworld_GrassPalettes;
                selectedX = 3;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["Objects3DPal"])
            {
                selectedPalette = Palettes.object3D_Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 8;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldMapsPal"])
            {
                selectedPalette = Palettes.overworld_Mini_Map_Palettes[palettesTreeView.SelectedNode.Index];
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
                for (int i = 0; i < Palettes.overworld_MainPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.overworld_MainPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(OverworldMainPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldAuxPal"])
            {
                for (int i = 0; i < Palettes.overworld_AuxPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.overworld_AuxPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(OverworldAuxPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["OverworldAnimatedPal"])
            {
                for (int i = 0; i < Palettes.overworld_AnimatedPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.overworld_AnimatedPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(OverworldAnimatedPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["DungeonMainPal"])
            {
                for (int i = 0; i < Palettes.dungeonsMain_Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.dungeonsMain_Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(DungeonMainPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["GlobalSpritesPal"])
            {
                for (int i = 0; i < Palettes.globalSprite_Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.globalSprite_Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(GlobalSpritesPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux1Pal"])
            {
                for (int i = 0; i < Palettes.spritesAux1_Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.spritesAux1_Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(SpritesAux1Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux2Pal"])
            {
                for (int i = 0; i < Palettes.spritesAux2_Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.spritesAux2_Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(SpritesAux2Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SpritesAux3Pal"])
            {
                for (int i = 0; i < Palettes.spritesAux3_Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.spritesAux3_Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(SpritesAux3Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["ShieldsPal"])
            {
                for (int i = 0; i < Palettes.shields_Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.shields_Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(ShieldsPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["SwordsPal"])
            {
                for (int i = 0; i < Palettes.swords_Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.swords_Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(SwordsPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["ArmorsPal"])
            {
                for (int i = 0; i < Palettes.armors_Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.armors_Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(ArmorsPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["object3D_Pal"])
            {
                for (int i = 0; i < Palettes.object3D_Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.object3D_Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(object3D_Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes["overworld_Maps_Pal"])
            {
                for (int i = 0; i < Palettes.overworld_Mini_Map_Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.overworld_Mini_Map_Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(overworld_Maps_Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
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
                OverworldMainPal[i] = new Color[Palettes.overworld_MainPalettes[i].Length];
                for (int j = 0; j < Palettes.overworld_MainPalettes[i].Length; j++)
                {
                    OverworldMainPal[i][j] = Color.FromArgb(Palettes.overworld_MainPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 20; i++)
            {
                OverworldAuxPal[i] = new Color[Palettes.overworld_AuxPalettes[i].Length];
                for (int j = 0; j < Palettes.overworld_AuxPalettes[i].Length; j++)
                {
                    OverworldAuxPal[i][j] = Color.FromArgb(Palettes.overworld_AuxPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 14; i++)
            {
                OverworldAnimatedPal[i] = new Color[Palettes.overworld_AnimatedPalettes[i].Length];
                for (int j = 0; j < Palettes.overworld_AnimatedPalettes[i].Length; j++)
                {
                    OverworldAnimatedPal[i][j] = Color.FromArgb(Palettes.overworld_AnimatedPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 20; i++)
            {

                DungeonMainPal[i] = new Color[Palettes.dungeonsMain_Palettes[i].Length];
                for (int j = 0; j < Palettes.dungeonsMain_Palettes[i].Length; j++)
                {
                    DungeonMainPal[i][j] = Color.FromArgb(Palettes.dungeonsMain_Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 2; i++)
            {
                GlobalSpritesPal[i] = new Color[Palettes.globalSprite_Palettes[i].Length];
                for (int j = 0; j < Palettes.globalSprite_Palettes[i].Length; j++)
                {
                    GlobalSpritesPal[i][j] = Color.FromArgb(Palettes.globalSprite_Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 12; i++)
            {
                SpritesAux1Pal[i] = new Color[Palettes.spritesAux1_Palettes[i].Length];
                for (int j = 0; j < Palettes.spritesAux1_Palettes[i].Length; j++)
                {
                    SpritesAux1Pal[i][j] = Color.FromArgb(Palettes.spritesAux1_Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 11; i++)
            {
                SpritesAux2Pal[i] = new Color[Palettes.spritesAux2_Palettes[i].Length];
                for (int j = 0; j < Palettes.spritesAux2_Palettes[i].Length; j++)
                {
                    SpritesAux2Pal[i][j] = Color.FromArgb(Palettes.spritesAux2_Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 24; i++)
            {
                SpritesAux3Pal[i] = new Color[Palettes.spritesAux3_Palettes[i].Length];
                for (int j = 0; j < Palettes.spritesAux3_Palettes[i].Length; j++)
                {
                    SpritesAux3Pal[i][j] = Color.FromArgb(Palettes.spritesAux3_Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 3; i++)
            {
                ShieldsPal[i] = new Color[Palettes.shields_Palettes[i].Length];
                for (int j = 0; j < Palettes.shields_Palettes[i].Length; j++)
                {
                    ShieldsPal[i][j] = Color.FromArgb(Palettes.shields_Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 4; i++)
            {
                SwordsPal[i] = new Color[Palettes.swords_Palettes[i].Length];
                for (int j = 0; j < Palettes.swords_Palettes[i].Length; j++)
                {
                    SwordsPal[i][j] = Color.FromArgb(Palettes.swords_Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 5; i++)
            {
                ArmorsPal[i] = new Color[Palettes.armors_Palettes[i].Length];
                for (int j = 0; j < Palettes.armors_Palettes[i].Length; j++)
                {
                    ArmorsPal[i][j] = Color.FromArgb(Palettes.armors_Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 2; i++)
            {
                object3D_Pal[i] = new Color[Palettes.object3D_Palettes[i].Length];
                for (int j = 0; j < Palettes.object3D_Palettes[i].Length; j++)
                {
                    object3D_Pal[i][j] = Color.FromArgb(Palettes.object3D_Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 2; i++)
            {
                overworld_Maps_Pal[i] = new Color[Palettes.overworld_Mini_Map_Palettes[i].Length];
                for (int j = 0; j < Palettes.overworld_Mini_Map_Palettes[i].Length; j++)
                {
                    overworld_Maps_Pal[i][j] = Color.FromArgb(Palettes.overworld_Mini_Map_Palettes[i][j].ToArgb());
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
                for (int j = 0; j < Palettes.overworld_MainPalettes[i].Length; j++)
                {
                    Palettes.overworld_MainPalettes[i][j] = Color.FromArgb(OverworldMainPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < Palettes.overworld_AuxPalettes[i].Length; j++)
                {
                    Palettes.overworld_AuxPalettes[i][j] = Color.FromArgb(OverworldAuxPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < Palettes.overworld_AnimatedPalettes[i].Length; j++)
                {
                    Palettes.overworld_AnimatedPalettes[i][j] = Color.FromArgb(OverworldAnimatedPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < Palettes.dungeonsMain_Palettes[i].Length; j++)
                {
                    Palettes.dungeonsMain_Palettes[i][j] = Color.FromArgb(DungeonMainPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < Palettes.globalSprite_Palettes[i].Length; j++)
                {
                    Palettes.globalSprite_Palettes[i][j] = Color.FromArgb(GlobalSpritesPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < Palettes.spritesAux1_Palettes[i].Length; j++)
                {
                    Palettes.spritesAux1_Palettes[i][j] = Color.FromArgb(SpritesAux1Pal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < Palettes.spritesAux2_Palettes[i].Length; j++)
                {
                    Palettes.spritesAux2_Palettes[i][j] = Color.FromArgb(SpritesAux2Pal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < Palettes.spritesAux3_Palettes[i].Length; j++)
                {
                    Palettes.spritesAux3_Palettes[i][j] = Color.FromArgb(SpritesAux3Pal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < Palettes.shields_Palettes[i].Length; j++)
                {
                    Palettes.shields_Palettes[i][j] = Color.FromArgb(ShieldsPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < Palettes.swords_Palettes[i].Length; j++)
                {
                    Palettes.swords_Palettes[i][j] = Color.FromArgb(SwordsPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < Palettes.armors_Palettes[i].Length; j++)
                {
                    Palettes.armors_Palettes[i][j] = Color.FromArgb(ArmorsPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < Palettes.object3D_Palettes[i].Length; j++)
                {
                    Palettes.object3D_Palettes[i][j] = Color.FromArgb(object3D_Pal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < Palettes.overworld_Mini_Map_Palettes[i].Length; j++)
                {
                    Palettes.overworld_Mini_Map_Palettes[i][j] = Color.FromArgb(overworld_Maps_Pal[i][j].ToArgb());
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
                        mainForm.overworldEditor.overworld.allmaps[i].LoadPalette();
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
                    mainForm.overworldEditor.overworld.allmaps[i].LoadPalette();
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
                    mainForm.overworldEditor.overworld.allmaps[i].LoadPalette();
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
                    foreach (Color[] _palette in Palettes.overworld_MainPalettes)
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
                    foreach (Color[] _palette in Palettes.overworld_AuxPalettes)
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
                    foreach (Color[] _palette in Palettes.overworld_AnimatedPalettes)
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
                    foreach (Color _color in Palettes.overworld_GrassPalettes)
                    {
                        byte[] buffer = BitConverter.GetBytes(_color.ToArgb());
                        for (int i = buffer.Length - 1; i >= 0; i--)
                        {
                            colorArrayData[count] = buffer[i];
                            count++;
                        }
                    }
                    foreach (Color[] _palette in Palettes.globalSprite_Palettes)
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
                    foreach (Color[] _palette in Palettes.armors_Palettes)
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
                    foreach (Color[] _palette in Palettes.swords_Palettes)
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
                    foreach (Color[] _palette in Palettes.spritesAux1_Palettes)
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
                    foreach (Color[] _palette in Palettes.spritesAux2_Palettes)
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
                    foreach (Color[] _palette in Palettes.spritesAux3_Palettes)
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
                    foreach (Color[] _palette in Palettes.shields_Palettes)
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
                    foreach (Color[] _palette in Palettes.dungeonsMain_Palettes)
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
                    foreach (Color[] _palette in Palettes.object3D_Palettes)
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
                    foreach (Color[] _palette in Palettes.overworld_Mini_Map_Palettes)
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
                    for (int i = 0; i < Palettes.overworld_MainPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.overworld_MainPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.overworld_MainPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.overworld_AuxPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.overworld_AuxPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.overworld_AuxPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.overworld_AnimatedPalettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.overworld_AnimatedPalettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.overworld_AnimatedPalettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.overworld_GrassPalettes.Length; i++)
                    {
                        byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                        Palettes.overworld_GrassPalettes[i] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                        count += 4;
                    }
                    for (int i = 0; i < Palettes.globalSprite_Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.globalSprite_Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.globalSprite_Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.armors_Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.armors_Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.armors_Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.swords_Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.swords_Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.swords_Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.spritesAux1_Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.spritesAux1_Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.spritesAux1_Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.spritesAux2_Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.spritesAux2_Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.spritesAux2_Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.spritesAux3_Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.spritesAux3_Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.spritesAux3_Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.shields_Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.shields_Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.shields_Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.dungeonsMain_Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.dungeonsMain_Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.dungeonsMain_Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.object3D_Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.object3D_Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.object3D_Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }
                    for (int i = 0; i < Palettes.overworld_Mini_Map_Palettes.Length; i++)
                    {
                        for (int j = 0; j < Palettes.overworld_Mini_Map_Palettes[i].Length; j++)
                        {
                            byte[] buffer = { colorArrayData[count + 3], colorArrayData[count + 2], colorArrayData[count + 1], colorArrayData[count] };
                            Palettes.overworld_Mini_Map_Palettes[i][j] = Color.FromArgb(BitConverter.ToInt32(buffer, 0));

                            count += 4;
                        }
                    }

                }
            }
        }
    }
}
