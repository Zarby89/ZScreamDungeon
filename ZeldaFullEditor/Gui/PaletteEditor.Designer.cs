namespace ZeldaFullEditor.Gui
{
    partial class PaletteEditor
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Hud");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Overworld Main");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Overworld Aux");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Overworld Animated");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Dungeon Main");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Global Sprites");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Sprites Aux1");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Sprites Aux2");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Sprites Aux3");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Shields");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Swords");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Armors");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Overworld Grass");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("3D Objects");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("OverworldMaps");
            this.applyButton = new System.Windows.Forms.Button();
            this.restoreallButton = new System.Windows.Forms.Button();
            this.restoreselButton = new System.Windows.Forms.Button();
            this.palettePicturebox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.palettesTreeView = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(387, 265);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // restoreallButton
            // 
            this.restoreallButton.Location = new System.Drawing.Point(306, 265);
            this.restoreallButton.Name = "restoreallButton";
            this.restoreallButton.Size = new System.Drawing.Size(75, 23);
            this.restoreallButton.TabIndex = 3;
            this.restoreallButton.Text = "Restore All";
            this.restoreallButton.UseVisualStyleBackColor = true;
            this.restoreallButton.Click += new System.EventHandler(this.restoreallButton_Click);
            // 
            // restoreselButton
            // 
            this.restoreselButton.Location = new System.Drawing.Point(206, 264);
            this.restoreselButton.Name = "restoreselButton";
            this.restoreselButton.Size = new System.Drawing.Size(94, 23);
            this.restoreselButton.TabIndex = 4;
            this.restoreselButton.Text = "Restore Select.";
            this.restoreselButton.UseVisualStyleBackColor = true;
            this.restoreselButton.Click += new System.EventHandler(this.restoreselButton_Click);
            // 
            // palettePicturebox
            // 
            this.palettePicturebox.Location = new System.Drawing.Point(206, 3);
            this.palettePicturebox.Name = "palettePicturebox";
            this.palettePicturebox.Size = new System.Drawing.Size(256, 256);
            this.palettePicturebox.TabIndex = 1;
            this.palettePicturebox.TabStop = false;
            this.palettePicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.palettePicturebox_Paint);
            this.palettePicturebox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseDoubleClick);
            this.palettePicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseDown);
            this.palettePicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Export Palettes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.exportAllPalettes);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(306, 293);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Import Palettes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.importAllPalettes);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(206, 322);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Export Selected";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(306, 322);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Import Selected";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // palettesTreeView
            // 
            this.palettesTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.palettesTreeView.Location = new System.Drawing.Point(0, 0);
            this.palettesTreeView.Name = "palettesTreeView";
            treeNode1.Name = "HudPal";
            treeNode1.Text = "Hud";
            treeNode2.Name = "OverworldMainPal";
            treeNode2.Text = "Overworld Main";
            treeNode3.Name = "OverworldAuxPal";
            treeNode3.Text = "Overworld Aux";
            treeNode4.Name = "OverworldAnimatedPal";
            treeNode4.Text = "Overworld Animated";
            treeNode5.Name = "DungeonMainPal";
            treeNode5.Text = "Dungeon Main";
            treeNode6.Name = "GlobalSpritesPal";
            treeNode6.Text = "Global Sprites";
            treeNode7.Name = "SpritesAux1Pal";
            treeNode7.Text = "Sprites Aux1";
            treeNode8.Name = "SpritesAux2Pal";
            treeNode8.Text = "Sprites Aux2";
            treeNode9.Name = "SpritesAux3Pal";
            treeNode9.Text = "Sprites Aux3";
            treeNode10.Name = "ShieldsPal";
            treeNode10.Text = "Shields";
            treeNode11.Name = "SwordsPal";
            treeNode11.Text = "Swords";
            treeNode12.Name = "ArmorsPal";
            treeNode12.Text = "Armors";
            treeNode13.Name = "OverworldGrassPal";
            treeNode13.Text = "Overworld Grass";
            treeNode14.Name = "Objects3DPal";
            treeNode14.Text = "3D Objects";
            treeNode15.Name = "OverworldMapsPal";
            treeNode15.Text = "OverworldMaps";
            this.palettesTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            this.palettesTreeView.Size = new System.Drawing.Size(200, 360);
            this.palettesTreeView.TabIndex = 0;
            this.palettesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.palettesTreeView_AfterSelect);
            // 
            // PaletteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.restoreselButton);
            this.Controls.Add(this.restoreallButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.palettePicturebox);
            this.Controls.Add(this.palettesTreeView);
            this.Name = "PaletteEditor";
            this.Size = new System.Drawing.Size(468, 360);
            this.Load += new System.EventHandler(this.PaletteEditor_Load);
            this.VisibleChanged += new System.EventHandler(this.PaletteEditor_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox palettePicturebox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button restoreallButton;
        private System.Windows.Forms.Button restoreselButton;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.TreeView palettesTreeView;
    }
}
