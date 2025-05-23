﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ZeldaFullEditor.Gui
{
    public partial class PaletteEditor : UserControl
    {
        Color[][] HudPal;
        Color[][] OverworldMainPal;
        Color[][] OverworldAuxPal;
        Color[][] OverworldAnimatedPal;
        Color[][] DungeonMainPal;
        Color[][] GlobalSpritesPal;
        Color[][] SpritesAux1Pal;
        Color[][] SpritesAux2Pal;
        Color[][] SpritesAux3Pal;
        Color[][] ShieldsPal;
        Color[][] SwordsPal;
        Color[][] ArmorsPal;

        Color[] overworld_GrassPal;
        Color[][] object3D_Pal;
        Color[][] overworld_Maps_Pal;

        Color tempColor;
        int tempIndex = -1;

        ColorDialog cd = new ColorDialog();

        DungeonMain mainForm;
        Color[] selectedPalette = null;
        int selectedX = 16;

        public PaletteEditor(DungeonMain mainForm)
        {
            this.InitializeComponent();
            this.mainForm = mainForm;

            this.HudPal = new Color[Constants.HudPalettesMax][];
            this.OverworldMainPal = new Color[Constants.OverworldMainPalettesMax][];
            this.OverworldAuxPal = new Color[Constants.OverworldAuxPalettesMax][];
            this.OverworldAnimatedPal = new Color[Constants.OverworldAnimatedPalettesMax][];
            this.DungeonMainPal = new Color[Constants.DungeonsMainPalettesMax][];
            this.GlobalSpritesPal = new Color[Constants.GlobalSpritePalettesMax][];
            this.SpritesAux1Pal = new Color[Constants.SpritesAux1PalettesMax][];
            this.SpritesAux2Pal = new Color[Constants.SpritesAux2PalettesMax][];
            this.SpritesAux3Pal = new Color[Constants.SpritesAux3PalettesMax][];
            this.ShieldsPal = new Color[Constants.ShieldsPalettesMax][];
            this.SwordsPal = new Color[Constants.SwordsPalettesMax][];
            this.ArmorsPal = new Color[Constants.ArmorPalettesMax][];

            this.overworld_GrassPal = new Color[Constants.OverworldGrassPalettesMax];
            this.object3D_Pal = new Color[Constants.Object3DPalettesMax][];
            this.overworld_Maps_Pal = new Color[Constants.OverworldMiniMapPalettesMax][];

            // Create temp of all palettes.
            this.CreateTempPalettes();

            this.RedoPaletteTreeNodes();
        }

        public void ResetTreeNodes()
        {
            this.palettesTreeView.BeginUpdate();

            this.palettesTreeView.Nodes.Clear();

            var treeNode1 = new TreeNode(Constants.PalDisplayName_HUD);
            var treeNode2 = new TreeNode(Constants.PalDisplayName_OWMain);
            var treeNode3 = new TreeNode(Constants.PalDisplayName_OWAux); 
            var treeNode4 = new TreeNode(Constants.PalDisplayName_OWAni);
            var treeNode5 = new TreeNode(Constants.PalDisplayName_DunMain);
            var treeNode6 = new TreeNode(Constants.PalDisplayName_SprGlobal);
            var treeNode7 = new TreeNode(Constants.PalDisplayName_SprAux1);
            var treeNode8 = new TreeNode(Constants.PalDisplayName_SprAux2);
            var treeNode9 = new TreeNode(Constants.PalDisplayName_SprAux3);
            var treeNode10 = new TreeNode(Constants.PalDisplayName_Shield);
            var treeNode11 = new TreeNode(Constants.PalDisplayName_Sword);
            var treeNode12 = new TreeNode(Constants.PalDisplayName_Armor);
            var treeNode13 = new TreeNode(Constants.PalDisplayName_OWGrass);
            var treeNode14 = new TreeNode(Constants.PalDisplayName_Obj3D);
            var treeNode15 = new TreeNode(Constants.PalDisplayName_OWMap);
            
            treeNode1.Name = Constants.PalName_HUD;
            treeNode2.Name = Constants.PalName_OWMain;
            treeNode3.Name = Constants.PalName_OWAux;
            treeNode4.Name = Constants.PalName_OWAni;
            treeNode5.Name = Constants.PalName_DunMain;
            treeNode6.Name = Constants.PalName_SprGlobal;
            treeNode7.Name = Constants.PalName_SprAux1;
            treeNode8.Name = Constants.PalName_SprAux2;
            treeNode9.Name = Constants.PalName_SprAux3;
            treeNode10.Name = Constants.PalName_Shield;
            treeNode11.Name = Constants.PalName_Sword;
            treeNode12.Name = Constants.PalName_Armor;
            treeNode13.Name = Constants.PalName_OWGrass;
            treeNode14.Name = Constants.PalName_Obj3D;
            treeNode15.Name = Constants.PalName_OWMap;

            this.palettesTreeView.Nodes.Add(treeNode1);
            this.palettesTreeView.Nodes.Add(treeNode2);
            this.palettesTreeView.Nodes.Add(treeNode3);
            this.palettesTreeView.Nodes.Add(treeNode4);
            this.palettesTreeView.Nodes.Add(treeNode5);
            this.palettesTreeView.Nodes.Add(treeNode6);
            this.palettesTreeView.Nodes.Add(treeNode7);
            this.palettesTreeView.Nodes.Add(treeNode8);
            this.palettesTreeView.Nodes.Add(treeNode9);
            this.palettesTreeView.Nodes.Add(treeNode10);
            this.palettesTreeView.Nodes.Add(treeNode11);
            this.palettesTreeView.Nodes.Add(treeNode12);
            this.palettesTreeView.Nodes.Add(treeNode13);
            this.palettesTreeView.Nodes.Add(treeNode14);
            this.palettesTreeView.Nodes.Add(treeNode15);

            this.RedoPaletteTreeNodes();

            this.palettesTreeView.EndUpdate();

            this.palettesTreeView.Refresh();
            this.palettePicturebox.Refresh();
        }

        public void RedoPaletteTreeNodes()
        {
            for (int i = 0; i < Palettes.HudPalettes.Length; i++)
            {
                palettesTreeView.Nodes[Constants.PalName_HUD].Nodes.Add(Constants.PalDisplayName_HUD + " " + i.ToString("X2"));
            }

            for (int i = 0; i < Palettes.OverworldMainPalettes.Length; i++)
            {
                palettesTreeView.Nodes[Constants.PalName_OWMain].Nodes.Add(Constants.PalDisplayName_OWMain + " " + i.ToString("X2"));
            }

            for (int i = 0; i < Palettes.OverworldAuxPalettes.Length; i++)
            {
                string extra = "";
                if (i >= Constants.OverworldAuxPalettesMax)
                {
                    extra = " Expanded";
                }

                palettesTreeView.Nodes[Constants.PalName_OWAux].Nodes.Add(Constants.PalDisplayName_OWAux + " " + i.ToString("X2") + extra);
            }

            for (int i = 0; i < Palettes.OverworldAnimatedPalettes.Length; i++)
            {
                palettesTreeView.Nodes[Constants.PalName_OWAni].Nodes.Add(Constants.PalDisplayName_OWAni + " " + i.ToString("X2"));
            }

            for (int i = 0; i < Palettes.DungeonsMainPalettes.Length; i++)
            {
                palettesTreeView.Nodes[Constants.PalName_DunMain].Nodes.Add(Constants.PalDisplayName_DunMain + " " + i.ToString("X2"));
            }

            for (int i = 0; i < Palettes.GlobalSpritePalettes.Length; i++)
            {
                palettesTreeView.Nodes[Constants.PalName_SprGlobal].Nodes.Add(Constants.PalDisplayName_SprGlobal + " " + i.ToString("X2"));
            }

            for (int i = 0; i < Palettes.SpritesAux1Palettes.Length; i++)
            {
                palettesTreeView.Nodes[Constants.PalName_SprAux1].Nodes.Add(Constants.PalDisplayName_SprAux1 + " " + i.ToString("X2"));
            }

            for (int i = 0; i < Palettes.SpritesAux2Palettes.Length; i++)
            {
                palettesTreeView.Nodes[Constants.PalName_SprAux2].Nodes.Add(Constants.PalDisplayName_SprAux2 + " " + i.ToString("X2"));
            }

            for (int i = 0; i < Palettes.SpritesAux3Palettes.Length; i++)
            {
                palettesTreeView.Nodes[Constants.PalName_SprAux3].Nodes.Add(Constants.PalDisplayName_SprAux3 + " " + i.ToString("X2"));
            }

            for (int i = 0; i < Palettes.ShieldsPalettes.Length; i++)
            {
                palettesTreeView.Nodes[Constants.PalName_Shield].Nodes.Add(Constants.PalDisplayName_Shield + " " + i.ToString("X2"));
            }

            for (int i = 0; i < Palettes.SwordsPalettes.Length; i++)
            {
                palettesTreeView.Nodes[Constants.PalName_Sword].Nodes.Add(Constants.PalDisplayName_Sword + " " + i.ToString("X2"));
            }

            for (int i = 0; i < Palettes.ArmorPalettes.Length; i++)
            {
                palettesTreeView.Nodes[Constants.PalName_Armor].Nodes.Add(Constants.PalDisplayName_Armor + " " + i.ToString("X2"));
            }

            palettesTreeView.Nodes[Constants.PalName_OWGrass].Nodes.Add(Constants.PalDisplayName_OWGrass);

            palettesTreeView.Nodes[Constants.PalName_Obj3D].Nodes.Add(Constants.PalDisplayName_Triforce);
            palettesTreeView.Nodes[Constants.PalName_Obj3D].Nodes.Add(Constants.PalDisplayName_Crystals);

            for (int i = 0; i < Palettes.OverworldMiniMapPalettes.Length; i++)
            {
                palettesTreeView.Nodes[Constants.PalName_OWMap].Nodes.Add(Constants.PalDisplayName_OWMap + " " + i.ToString("X2"));
            }
        }

        private void PaletteEditor_VisibleChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            CreateTempPalettes();

            // Recreate temp of all palettes.
        }

        private void PaletteEditor_Load(object sender, EventArgs e)
        {
            // TODO: Add something here?
        }

        private void restoreallButton_Click(object sender, EventArgs e)
        {
            // Restore temp of all palettes.
            if (MessageBox.Show("Are you sure you want to restore all palettes " +
                "to the last applied values?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.RestoreallPalettes();
            }
        }

        private void restoreselButton_Click(object sender, EventArgs e)
        {
            this.restoreSelected();
            this.refreshallGfx();

            // Restore the temp selected palette only.
        }

        private void refreshallGfx()
        {
            GFX.loadedPalettes = GFX.LoadDungeonPalette(this.mainForm.activeScene.room.palette);
            GFX.loadedSprPalettes = GFX.LoadSpritesPalette(this.mainForm.activeScene.room.palette);
            this.mainForm.activeScene.room.reloadGfx();
            this.mainForm.activeScene.DrawRoom();
            this.mainForm.activeScene.Refresh();
            this.palettePicturebox.Refresh();
        }

        public void VerifyPaletteSizes()
        {
            if (HudPal.Length < Palettes.HudPalettes.Length)
            {
                Color[][] temp = new Color[Palettes.HudPalettes.Length][];

                int i = 0;
                while (i < HudPal.Length)
                {
                    temp[i] = HudPal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.HudPalettes[i];

                    i++;
                }

                HudPal = temp;
            }

            if (OverworldMainPal.Length < Palettes.OverworldMainPalettes.Length)
            {
                Color[][] temp = new Color[Palettes.OverworldMainPalettes.Length][];

                int i = 0;
                while (i < OverworldMainPal.Length)
                {
                    temp[i] = OverworldMainPal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.OverworldMainPalettes[i];

                    i++;
                }

                OverworldMainPal = temp;
            }

            if (OverworldAuxPal.Length < Palettes.OverworldAuxPalettes.Length)
            {
                Color[][] temp = new Color[Palettes.OverworldAuxPalettes.Length][];

                int i = 0;
                while (i < OverworldAuxPal.Length)
                {
                    temp[i] = OverworldAuxPal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.OverworldAuxPalettes[i];

                    i++;
                }

                OverworldAuxPal = temp;
            }

            if (OverworldAnimatedPal.Length < Palettes.OverworldAnimatedPalettes.Length)
            {
                Color[][] temp = new Color[Palettes.OverworldAnimatedPalettes.Length][];

                int i = 0;
                while (i < OverworldAnimatedPal.Length)
                {
                    temp[i] = OverworldAnimatedPal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.OverworldAnimatedPalettes[i];

                    i++;
                }

                OverworldAnimatedPal = temp;
            }

            if (DungeonMainPal.Length < Palettes.DungeonsMainPalettes.Length)
            {
                Color[][] temp = new Color[Palettes.DungeonsMainPalettes.Length][];

                int i = 0;
                while (i < DungeonMainPal.Length)
                {
                    temp[i] = DungeonMainPal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.DungeonsMainPalettes[i];

                    i++;
                }

                DungeonMainPal = temp;
            }

            if (GlobalSpritesPal.Length < Palettes.GlobalSpritePalettes.Length)
            {
                Color[][] temp = new Color[Palettes.GlobalSpritePalettes.Length][];

                int i = 0;
                while (i < GlobalSpritesPal.Length)
                {
                    temp[i] = GlobalSpritesPal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.GlobalSpritePalettes[i];

                    i++;
                }

                GlobalSpritesPal = temp;
            }

            if (SpritesAux1Pal.Length < Palettes.SpritesAux1Palettes.Length)
            {
                Color[][] temp = new Color[Palettes.SpritesAux1Palettes.Length][];

                int i = 0;
                while (i < SpritesAux1Pal.Length)
                {
                    temp[i] = SpritesAux1Pal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.SpritesAux1Palettes[i];

                    i++;
                }

                SpritesAux1Pal = temp;
            }

            if (SpritesAux2Pal.Length < Palettes.SpritesAux2Palettes.Length)
            {
                Color[][] temp = new Color[Palettes.SpritesAux2Palettes.Length][];

                int i = 0;
                while (i < SpritesAux2Pal.Length)
                {
                    temp[i] = SpritesAux2Pal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.SpritesAux2Palettes[i];

                    i++;
                }

                SpritesAux2Pal = temp;
            }

            if (SpritesAux3Pal.Length < Palettes.SpritesAux3Palettes.Length)
            {
                Color[][] temp = new Color[Palettes.SpritesAux3Palettes.Length][];

                int i = 0;
                while (i < SpritesAux3Pal.Length)
                {
                    temp[i] = SpritesAux3Pal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.SpritesAux3Palettes[i];

                    i++;
                }

                SpritesAux3Pal = temp;
            }

            if (ShieldsPal.Length < Palettes.ShieldsPalettes.Length)
            {
                Color[][] temp = new Color[Palettes.ShieldsPalettes.Length][];

                int i = 0;
                while (i < ShieldsPal.Length)
                {
                    temp[i] = ShieldsPal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.ShieldsPalettes[i];

                    i++;
                }

                ShieldsPal = temp;
            }

            if (SwordsPal.Length < Palettes.SwordsPalettes.Length)
            {
                Color[][] temp = new Color[Palettes.SwordsPalettes.Length][];

                int i = 0;
                while (i < SwordsPal.Length)
                {
                    temp[i] = SwordsPal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.SwordsPalettes[i];

                    i++;
                }

                SwordsPal = temp;
            }

            if (ArmorsPal.Length < Palettes.ArmorPalettes.Length)
            {
                Color[][] temp = new Color[Palettes.ArmorPalettes.Length][];

                int i = 0;
                while (i < ArmorsPal.Length)
                {
                    temp[i] = ArmorsPal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.ArmorPalettes[i];

                    i++;
                }

                ArmorsPal = temp;
            }

            if (object3D_Pal.Length < Palettes.Object3DPalettes.Length)
            {
                Color[][] temp = new Color[Palettes.Object3DPalettes.Length][];

                int i = 0;
                while (i < object3D_Pal.Length)
                {
                    temp[i] = object3D_Pal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.Object3DPalettes[i];

                    i++;
                }

                object3D_Pal = temp;
            }

            if (overworld_Maps_Pal.Length < Palettes.OverworldMiniMapPalettes.Length)
            {
                Color[][] temp = new Color[Palettes.OverworldMiniMapPalettes.Length][];

                int i = 0;
                while (i < overworld_Maps_Pal.Length)
                {
                    temp[i] = overworld_Maps_Pal[i];

                    i++;
                }

                while (i < temp.Length)
                {
                    temp[i] = Palettes.OverworldMiniMapPalettes[i];

                    i++;
                }

                overworld_Maps_Pal = temp;
            }
        }

        private void palettesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_HUD])
            {
                selectedPalette = Palettes.HudPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 16;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_OWMain])
            {
                selectedPalette = Palettes.OverworldMainPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_OWAux])
            {
                selectedPalette = Palettes.OverworldAuxPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_OWAni])
            {
                selectedPalette = Palettes.OverworldAnimatedPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_DunMain])
            {
                selectedPalette = Palettes.DungeonsMainPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 15;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_SprGlobal])
            {
                selectedPalette = Palettes.GlobalSpritePalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 15;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_SprAux1])
            {
                selectedPalette = Palettes.SpritesAux1Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_SprAux2])
            {
                selectedPalette = Palettes.SpritesAux2Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_SprAux3])
            {
                selectedPalette = Palettes.SpritesAux3Palettes[palettesTreeView.SelectedNode.Index];
                selectedX = 7;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_Shield])
            {
                selectedPalette = Palettes.ShieldsPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 4;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_Sword])
            {
                selectedPalette = Palettes.SwordsPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 3;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_Armor])
            {
                selectedPalette = Palettes.ArmorPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 15;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_OWGrass])
            {
                selectedPalette = Palettes.OverworldGrassPalettes;
                selectedX = 3;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_Obj3D])
            {
                selectedPalette = Palettes.Object3DPalettes[palettesTreeView.SelectedNode.Index];
                selectedX = 8;
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_OWMap])
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
            if (palettesTreeView.SelectedNode is null)
            {
                return;
            }

            this.VerifyPaletteSizes();

            if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_HUD])
            {
                for (int i = 0; i < Palettes.HudPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.HudPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(HudPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_OWMain])
            {
                for (int i = 0; i < Palettes.OverworldMainPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.OverworldMainPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(OverworldMainPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_OWAux])
            {
                for (int i = 0; i < Palettes.OverworldAuxPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.OverworldAuxPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(OverworldAuxPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_OWAni])
            {
                for (int i = 0; i < Palettes.OverworldAnimatedPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.OverworldAnimatedPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(OverworldAnimatedPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_DunMain])
            {
                for (int i = 0; i < Palettes.DungeonsMainPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.DungeonsMainPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(DungeonMainPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_SprGlobal])
            {
                for (int i = 0; i < Palettes.GlobalSpritePalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.GlobalSpritePalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(GlobalSpritesPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_SprAux1])
            {
                for (int i = 0; i < Palettes.SpritesAux1Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.SpritesAux1Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(SpritesAux1Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_SprAux2])
            {
                for (int i = 0; i < Palettes.SpritesAux2Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.SpritesAux2Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(SpritesAux2Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_SprAux3])
            {
                for (int i = 0; i < Palettes.SpritesAux3Palettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.SpritesAux3Palettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(SpritesAux3Pal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_Shield])
            {
                for (int i = 0; i < Palettes.ShieldsPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.ShieldsPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(ShieldsPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_Sword])
            {
                for (int i = 0; i < Palettes.SwordsPalettes[palettesTreeView.SelectedNode.Index].Length; i++)
                {
                    Palettes.SwordsPalettes[palettesTreeView.SelectedNode.Index][i] = Color.FromArgb(SwordsPal[palettesTreeView.SelectedNode.Index][i].ToArgb());
                }
            }
            else if (palettesTreeView.SelectedNode.Parent == palettesTreeView.Nodes[Constants.PalName_Armor])
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

            this.palettePicturebox.Refresh();
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
            this.VerifyPaletteSizes();

            for (int i = 0; i < Palettes.HudPalettes.Length; i++)
            {
                HudPal[i] = new Color[Palettes.HudPalettes[i].Length];
                for (int j = 0; j < Palettes.HudPalettes[i].Length; j++)
                {
                    HudPal[i][j] = Color.FromArgb(Palettes.HudPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.OverworldMainPalettes.Length; i++)
            {
                OverworldMainPal[i] = new Color[Palettes.OverworldMainPalettes[i].Length];
                for (int j = 0; j < Palettes.OverworldMainPalettes[i].Length; j++)
                {
                    OverworldMainPal[i][j] = Color.FromArgb(Palettes.OverworldMainPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.OverworldAuxPalettes.Length; i++)
            {
                OverworldAuxPal[i] = new Color[Palettes.OverworldAuxPalettes[i].Length];
                for (int j = 0; j < Palettes.OverworldAuxPalettes[i].Length; j++)
                {
                    OverworldAuxPal[i][j] = Color.FromArgb(Palettes.OverworldAuxPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.OverworldAnimatedPalettes.Length; i++)
            {
                OverworldAnimatedPal[i] = new Color[Palettes.OverworldAnimatedPalettes[i].Length];
                for (int j = 0; j < Palettes.OverworldAnimatedPalettes[i].Length; j++)
                {
                    OverworldAnimatedPal[i][j] = Color.FromArgb(Palettes.OverworldAnimatedPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.DungeonsMainPalettes.Length; i++)
            {
                DungeonMainPal[i] = new Color[Palettes.DungeonsMainPalettes[i].Length];
                for (int j = 0; j < Palettes.DungeonsMainPalettes[i].Length; j++)
                {
                    DungeonMainPal[i][j] = Color.FromArgb(Palettes.DungeonsMainPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.GlobalSpritePalettes.Length; i++)
            {
                GlobalSpritesPal[i] = new Color[Palettes.GlobalSpritePalettes[i].Length];
                for (int j = 0; j < Palettes.GlobalSpritePalettes[i].Length; j++)
                {
                    GlobalSpritesPal[i][j] = Color.FromArgb(Palettes.GlobalSpritePalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.SpritesAux1Palettes.Length; i++)
            {
                SpritesAux1Pal[i] = new Color[Palettes.SpritesAux1Palettes[i].Length];
                for (int j = 0; j < Palettes.SpritesAux1Palettes[i].Length; j++)
                {
                    SpritesAux1Pal[i][j] = Color.FromArgb(Palettes.SpritesAux1Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.SpritesAux2Palettes.Length; i++)
            {
                SpritesAux2Pal[i] = new Color[Palettes.SpritesAux2Palettes[i].Length];
                for (int j = 0; j < Palettes.SpritesAux2Palettes[i].Length; j++)
                {
                    SpritesAux2Pal[i][j] = Color.FromArgb(Palettes.SpritesAux2Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.SpritesAux3Palettes.Length; i++)
            {
                SpritesAux3Pal[i] = new Color[Palettes.SpritesAux3Palettes[i].Length];
                for (int j = 0; j < Palettes.SpritesAux3Palettes[i].Length; j++)
                {
                    SpritesAux3Pal[i][j] = Color.FromArgb(Palettes.SpritesAux3Palettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.ShieldsPalettes.Length; i++)
            {
                ShieldsPal[i] = new Color[Palettes.ShieldsPalettes[i].Length];
                for (int j = 0; j < Palettes.ShieldsPalettes[i].Length; j++)
                {
                    ShieldsPal[i][j] = Color.FromArgb(Palettes.ShieldsPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.SwordsPalettes.Length; i++)
            {
                SwordsPal[i] = new Color[Palettes.SwordsPalettes[i].Length];
                for (int j = 0; j < Palettes.SwordsPalettes[i].Length; j++)
                {
                    SwordsPal[i][j] = Color.FromArgb(Palettes.SwordsPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.ArmorPalettes.Length; i++)
            {
                ArmorsPal[i] = new Color[Palettes.ArmorPalettes[i].Length];
                for (int j = 0; j < Palettes.ArmorPalettes[i].Length; j++)
                {
                    ArmorsPal[i][j] = Color.FromArgb(Palettes.ArmorPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.Object3DPalettes.Length; i++)
            {
                object3D_Pal[i] = new Color[Palettes.Object3DPalettes[i].Length];
                for (int j = 0; j < Palettes.Object3DPalettes[i].Length; j++)
                {
                    object3D_Pal[i][j] = Color.FromArgb(Palettes.Object3DPalettes[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.OverworldMiniMapPalettes.Length; i++)
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
            this.VerifyPaletteSizes();

            for (int i = 0; i < Palettes.HudPalettes.Length; i++)
            {
                for (int j = 0; j < Palettes.HudPalettes[i].Length; j++)
                {
                    Palettes.HudPalettes[i][j] = Color.FromArgb(HudPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.OverworldMainPalettes.Length; i++)
            {
                for (int j = 0; j < Palettes.OverworldMainPalettes[i].Length; j++)
                {
                    Palettes.OverworldMainPalettes[i][j] = Color.FromArgb(OverworldMainPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.OverworldAuxPalettes.Length; i++)
            {
                for (int j = 0; j < Palettes.OverworldAuxPalettes[i].Length; j++)
                {
                    Palettes.OverworldAuxPalettes[i][j] = Color.FromArgb(OverworldAuxPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.OverworldAnimatedPalettes.Length; i++)
            {
                for (int j = 0; j < Palettes.OverworldAnimatedPalettes[i].Length; j++)
                {
                    Palettes.OverworldAnimatedPalettes[i][j] = Color.FromArgb(OverworldAnimatedPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.DungeonsMainPalettes.Length; i++)
            {
                for (int j = 0; j < Palettes.DungeonsMainPalettes[i].Length; j++)
                {
                    Palettes.DungeonsMainPalettes[i][j] = Color.FromArgb(DungeonMainPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.GlobalSpritePalettes.LongLength; i++)
            {
                for (int j = 0; j < Palettes.GlobalSpritePalettes[i].Length; j++)
                {
                    Palettes.GlobalSpritePalettes[i][j] = Color.FromArgb(GlobalSpritesPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.SpritesAux1Palettes.Length; i++)
            {
                for (int j = 0; j < Palettes.SpritesAux1Palettes[i].Length; j++)
                {
                    Palettes.SpritesAux1Palettes[i][j] = Color.FromArgb(SpritesAux1Pal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.SpritesAux2Palettes.Length; i++)
            {
                for (int j = 0; j < Palettes.SpritesAux2Palettes[i].Length; j++)
                {
                    Palettes.SpritesAux2Palettes[i][j] = Color.FromArgb(SpritesAux2Pal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.SpritesAux3Palettes.Length; i++)
            {
                for (int j = 0; j < Palettes.SpritesAux3Palettes[i].Length; j++)
                {
                    Palettes.SpritesAux3Palettes[i][j] = Color.FromArgb(SpritesAux3Pal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.ShieldsPalettes.Length; i++)
            {
                for (int j = 0; j < Palettes.ShieldsPalettes[i].Length; j++)
                {
                    Palettes.ShieldsPalettes[i][j] = Color.FromArgb(ShieldsPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.SwordsPalettes.Length; i++)
            {
                for (int j = 0; j < Palettes.SwordsPalettes[i].Length; j++)
                {
                    Palettes.SwordsPalettes[i][j] = Color.FromArgb(SwordsPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.ArmorPalettes.Length; i++)
            {
                for (int j = 0; j < Palettes.ArmorPalettes[i].Length; j++)
                {
                    Palettes.ArmorPalettes[i][j] = Color.FromArgb(ArmorsPal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.Object3DPalettes.Length; i++)
            {
                for (int j = 0; j < Palettes.Object3DPalettes[i].Length; j++)
                {
                    Palettes.Object3DPalettes[i][j] = Color.FromArgb(object3D_Pal[i][j].ToArgb());
                }
            }

            for (int i = 0; i < Palettes.OverworldMiniMapPalettes.Length; i++)
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
            if (this.tempIndex != -1)
            {
                this.selectedPalette[tempIndex] = this.tempColor;
                for (int i = 0; i < 159; i++)
                {
                    this.mainForm.overworldEditor.overworld.AllMaps[i].LoadPalette();
                }

                this.mainForm.overworldEditor.scene.Refresh();
                this.refreshallGfx();
                this.tempIndex = -1;
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
