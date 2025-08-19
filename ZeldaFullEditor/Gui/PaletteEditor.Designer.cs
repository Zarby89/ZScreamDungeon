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
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Hud");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Overworld Main");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Overworld Aux");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Overworld Animated");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Dungeon Main");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Global Sprites");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Sprites Aux1");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Sprites Aux2");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Sprites Aux3");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Shields");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Swords");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Armors");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Overworld Grass");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("3D Objects");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("OverworldMaps");
            this.applyButton = new System.Windows.Forms.Button();
            this.restoreallButton = new System.Windows.Forms.Button();
            this.restoreselButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.palettesTreeView = new System.Windows.Forms.TreeView();
            this.palettePicturebox = new System.Windows.Forms.PictureBox();
            this.selectedColorPanel = new System.Windows.Forms.Panel();
            this.hexbox1 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.hexbox2 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.hexbox3 = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.greenHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.blueHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.redHex = new System.Windows.Forms.NumericUpDown();
            this.greenHex = new System.Windows.Forms.NumericUpDown();
            this.blueHex = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redHex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenHex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueHex)).BeginInit();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(387, 191);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // restoreallButton
            // 
            this.restoreallButton.Location = new System.Drawing.Point(306, 191);
            this.restoreallButton.Name = "restoreallButton";
            this.restoreallButton.Size = new System.Drawing.Size(75, 23);
            this.restoreallButton.TabIndex = 3;
            this.restoreallButton.Text = "Restore All";
            this.restoreallButton.UseVisualStyleBackColor = true;
            this.restoreallButton.Click += new System.EventHandler(this.RestoreAllButton_Click);
            // 
            // restoreselButton
            // 
            this.restoreselButton.Location = new System.Drawing.Point(206, 190);
            this.restoreselButton.Name = "restoreselButton";
            this.restoreselButton.Size = new System.Drawing.Size(94, 23);
            this.restoreselButton.TabIndex = 4;
            this.restoreselButton.Text = "Restore Select.";
            this.restoreselButton.UseVisualStyleBackColor = true;
            this.restoreselButton.Click += new System.EventHandler(this.RestoreSelectedlButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Export Palettes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.exportAllPalettes);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(306, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Import Palettes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.importAllPalettes);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(206, 248);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Export Selected";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(306, 248);
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
            treeNode31.Name = "HudPal";
            treeNode31.Text = "Hud";
            treeNode32.Name = "OverworldMainPal";
            treeNode32.Text = "Overworld Main";
            treeNode33.Name = "OverworldAuxPal";
            treeNode33.Text = "Overworld Aux";
            treeNode34.Name = "OverworldAnimatedPal";
            treeNode34.Text = "Overworld Animated";
            treeNode35.Name = "DungeonMainPal";
            treeNode35.Text = "Dungeon Main";
            treeNode36.Name = "GlobalSpritesPal";
            treeNode36.Text = "Global Sprites";
            treeNode37.Name = "SpritesAux1Pal";
            treeNode37.Text = "Sprites Aux1";
            treeNode38.Name = "SpritesAux2Pal";
            treeNode38.Text = "Sprites Aux2";
            treeNode39.Name = "SpritesAux3Pal";
            treeNode39.Text = "Sprites Aux3";
            treeNode40.Name = "ShieldsPal";
            treeNode40.Text = "Shields";
            treeNode41.Name = "SwordsPal";
            treeNode41.Text = "Swords";
            treeNode42.Name = "ArmorsPal";
            treeNode42.Text = "Armors";
            treeNode43.Name = "OverworldGrassPal";
            treeNode43.Text = "Overworld Grass";
            treeNode44.Name = "Objects3DPal";
            treeNode44.Text = "3D Objects";
            treeNode45.Name = "OverworldMapsPal";
            treeNode45.Text = "OverworldMaps";
            this.palettesTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37,
            treeNode38,
            treeNode39,
            treeNode40,
            treeNode41,
            treeNode42,
            treeNode43,
            treeNode44,
            treeNode45});
            this.palettesTreeView.Size = new System.Drawing.Size(200, 274);
            this.palettesTreeView.TabIndex = 0;
            this.palettesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.palettesTreeView_AfterSelect);
            // 
            // palettePicturebox
            // 
            this.palettePicturebox.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.palettePicturebox.Location = new System.Drawing.Point(206, 3);
            this.palettePicturebox.Name = "palettePicturebox";
            this.palettePicturebox.Size = new System.Drawing.Size(256, 128);
            this.palettePicturebox.TabIndex = 1;
            this.palettePicturebox.TabStop = false;
            this.palettePicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.palettePicturebox_Paint);
            this.palettePicturebox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseDoubleClick);
            this.palettePicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseDown);
            this.palettePicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseUp);
            // 
            // selectedColorPanel
            // 
            this.selectedColorPanel.Location = new System.Drawing.Point(206, 137);
            this.selectedColorPanel.Name = "selectedColorPanel";
            this.selectedColorPanel.Size = new System.Drawing.Size(51, 47);
            this.selectedColorPanel.TabIndex = 9;
            // 
            // hexbox1
            // 
            this.hexbox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hexbox1.Decimal = false;
            this.hexbox1.HexValue = 0;
            this.hexbox1.Location = new System.Drawing.Point(263, 151);
            this.hexbox1.MaxValue = 0;
            this.hexbox1.MinValue = 0;
            this.hexbox1.Name = "hexbox1";
            this.hexbox1.Size = new System.Drawing.Size(37, 20);
            this.hexbox1.TabIndex = 10;
            // 
            // hexbox2
            // 
            this.hexbox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hexbox2.Decimal = false;
            this.hexbox2.HexValue = 0;
            this.hexbox2.Location = new System.Drawing.Point(306, 151);
            this.hexbox2.MaxValue = 0;
            this.hexbox2.MinValue = 0;
            this.hexbox2.Name = "hexbox2";
            this.hexbox2.Size = new System.Drawing.Size(37, 20);
            this.hexbox2.TabIndex = 11;
            // 
            // hexbox3
            // 
            this.hexbox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hexbox3.Decimal = false;
            this.hexbox3.HexValue = 0;
            this.hexbox3.Location = new System.Drawing.Point(349, 151);
            this.hexbox3.MaxValue = 0;
            this.hexbox3.MinValue = 0;
            this.hexbox3.Name = "hexbox3";
            this.hexbox3.Size = new System.Drawing.Size(37, 20);
            this.hexbox3.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "B";
            // 
            // greenHexbox
            // 
            this.greenHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.greenHexbox.Decimal = false;
            this.greenHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.greenHexbox.HexValue = 0;
            this.greenHexbox.Location = new System.Drawing.Point(306, 151);
            this.greenHexbox.MaxLength = 2;
            this.greenHexbox.MaxValue = 31;
            this.greenHexbox.MinValue = 0;
            this.greenHexbox.Name = "greenHexbox";
            this.greenHexbox.Size = new System.Drawing.Size(37, 20);
            this.greenHexbox.TabIndex = 11;
            this.greenHexbox.Text = "00";
            // 
            // blueHexbox
            // 
            this.blueHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.blueHexbox.Decimal = false;
            this.blueHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.blueHexbox.HexValue = 0;
            this.blueHexbox.Location = new System.Drawing.Point(349, 151);
            this.blueHexbox.MaxLength = 2;
            this.blueHexbox.MaxValue = 31;
            this.blueHexbox.MinValue = 0;
            this.blueHexbox.Name = "blueHexbox";
            this.blueHexbox.Size = new System.Drawing.Size(37, 20);
            this.blueHexbox.TabIndex = 12;
            this.blueHexbox.Text = "00";
            // 
            // redHex
            // 
            this.redHex.Hexadecimal = true;
            this.redHex.Location = new System.Drawing.Point(263, 152);
            this.redHex.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.redHex.Name = "redHex";
            this.redHex.Size = new System.Drawing.Size(37, 20);
            this.redHex.TabIndex = 16;
            this.redHex.ValueChanged += new System.EventHandler(this.RGBHexBoxChanged);
            // 
            // greenHex
            // 
            this.greenHex.Hexadecimal = true;
            this.greenHex.Location = new System.Drawing.Point(306, 152);
            this.greenHex.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.greenHex.Name = "greenHex";
            this.greenHex.Size = new System.Drawing.Size(37, 20);
            this.greenHex.TabIndex = 17;
            this.greenHex.ValueChanged += new System.EventHandler(this.RGBHexBoxChanged);
            // 
            // blueHex
            // 
            this.blueHex.Hexadecimal = true;
            this.blueHex.Location = new System.Drawing.Point(349, 152);
            this.blueHex.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.blueHex.Name = "blueHex";
            this.blueHex.Size = new System.Drawing.Size(37, 20);
            this.blueHex.TabIndex = 18;
            this.blueHex.ValueChanged += new System.EventHandler(this.RGBHexBoxChanged);
            // 
            // PaletteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.blueHex);
            this.Controls.Add(this.greenHex);
            this.Controls.Add(this.redHex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectedColorPanel);
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
            this.Size = new System.Drawing.Size(468, 274);
            this.Load += new System.EventHandler(this.PaletteEditor_Load);
            this.VisibleChanged += new System.EventHandler(this.PaletteEditor_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redHex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenHex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueHex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel selectedColorPanel;
        private ExtraForms.Hexbox hexbox1;
        private ExtraForms.Hexbox hexbox2;
        private ExtraForms.Hexbox hexbox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ExtraForms.Hexbox greenHexbox;
        private ExtraForms.Hexbox blueHexbox;
        private System.Windows.Forms.NumericUpDown redHex;
        private System.Windows.Forms.NumericUpDown greenHex;
        private System.Windows.Forms.NumericUpDown blueHex;
    }
}
