namespace ZeldaFullEditor.Gui
{
    partial class OverworldEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverworldEditor));
            this.owToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.owPropertyPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stateCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tilePictureBox = new System.Windows.Forms.PictureBox();
            this.openfileButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.debugtestButton = new System.Windows.Forms.ToolStripButton();
            this.runtestButton = new System.Windows.Forms.ToolStripButton();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.penModeButton = new System.Windows.Forms.ToolStripButton();
            this.fillModeButton = new System.Windows.Forms.ToolStripButton();
            this.entranceModeButton = new System.Windows.Forms.ToolStripButton();
            this.exitModeButton = new System.Windows.Forms.ToolStripButton();
            this.itemModeButton = new System.Windows.Forms.ToolStripButton();
            this.spriteModeButton = new System.Windows.Forms.ToolStripButton();
            this.transportModeButton = new System.Windows.Forms.ToolStripButton();
            this.mapGroupbox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gfxTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sprgfxTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.paletteTextbox = new System.Windows.Forms.TextBox();
            this.sprpaletteTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.selectedTileLabel = new System.Windows.Forms.Label();
            this.owToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.owPropertyPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilePictureBox)).BeginInit();
            this.mapGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // owToolStrip
            // 
            this.owToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openfileButton,
            this.saveButton,
            this.toolStripSeparator1,
            this.debugtestButton,
            this.runtestButton,
            this.undoButton,
            this.redoButton,
            this.toolStripSeparator2,
            this.penModeButton,
            this.fillModeButton,
            this.toolStripSeparator3,
            this.entranceModeButton,
            this.exitModeButton,
            this.itemModeButton,
            this.spriteModeButton,
            this.transportModeButton});
            this.owToolStrip.Location = new System.Drawing.Point(0, 0);
            this.owToolStrip.Name = "owToolStrip";
            this.owToolStrip.Size = new System.Drawing.Size(953, 25);
            this.owToolStrip.TabIndex = 0;
            this.owToolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 100);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tilePictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(953, 619);
            this.splitContainer1.SplitterDistance = 149;
            this.splitContainer1.TabIndex = 1;
            // 
            // owPropertyPanel
            // 
            this.owPropertyPanel.Controls.Add(this.mapGroupbox);
            this.owPropertyPanel.Controls.Add(this.groupBox1);
            this.owPropertyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.owPropertyPanel.Location = new System.Drawing.Point(0, 25);
            this.owPropertyPanel.Name = "owPropertyPanel";
            this.owPropertyPanel.Size = new System.Drawing.Size(953, 75);
            this.owPropertyPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectedTileLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.stateCombobox);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Global Settings";
            // 
            // stateCombobox
            // 
            this.stateCombobox.FormattingEnabled = true;
            this.stateCombobox.Items.AddRange(new object[] {
            "0,1 (Rescue Zelda)",
            "2 (Zelda Saved)",
            "3 (Agah. Dead)"});
            this.stateCombobox.Location = new System.Drawing.Point(6, 31);
            this.stateCombobox.Name = "stateCombobox";
            this.stateCombobox.Size = new System.Drawing.Size(138, 21);
            this.stateCombobox.TabIndex = 1;
            this.stateCombobox.Text = "0,1 (Rescue Zelda)";
            this.stateCombobox.SelectedIndexChanged += new System.EventHandler(this.stateCombobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game State (7EF3C5) : ";
            // 
            // tilePictureBox
            // 
            this.tilePictureBox.Location = new System.Drawing.Point(3, 3);
            this.tilePictureBox.Name = "tilePictureBox";
            this.tilePictureBox.Size = new System.Drawing.Size(128, 4096);
            this.tilePictureBox.TabIndex = 0;
            this.tilePictureBox.TabStop = false;
            this.tilePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.tilePictureBox_Paint);
            this.tilePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tilePictureBox_MouseClick);
            // 
            // openfileButton
            // 
            this.openfileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openfileButton.Image = ((System.Drawing.Image)(resources.GetObject("openfileButton.Image")));
            this.openfileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openfileButton.Name = "openfileButton";
            this.openfileButton.Size = new System.Drawing.Size(23, 22);
            this.openfileButton.Text = "Open ROM";
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Enabled = false;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 22);
            this.saveButton.Text = "Save ROM";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // debugtestButton
            // 
            this.debugtestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.debugtestButton.Enabled = false;
            this.debugtestButton.Image = ((System.Drawing.Image)(resources.GetObject("debugtestButton.Image")));
            this.debugtestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debugtestButton.Name = "debugtestButton";
            this.debugtestButton.Size = new System.Drawing.Size(23, 22);
            this.debugtestButton.Text = "Save and Debug in emulator";
            // 
            // runtestButton
            // 
            this.runtestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.runtestButton.Enabled = false;
            this.runtestButton.Image = ((System.Drawing.Image)(resources.GetObject("runtestButton.Image")));
            this.runtestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runtestButton.Name = "runtestButton";
            this.runtestButton.Size = new System.Drawing.Size(23, 22);
            this.runtestButton.Text = "Save and Run in emulator";
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Enabled = false;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(23, 22);
            this.undoButton.Text = "Undo";
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Enabled = false;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(23, 22);
            this.redoButton.Text = "Redo";
            // 
            // penModeButton
            // 
            this.penModeButton.Checked = true;
            this.penModeButton.CheckOnClick = true;
            this.penModeButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.penModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.penModeButton.Image = ((System.Drawing.Image)(resources.GetObject("penModeButton.Image")));
            this.penModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.penModeButton.Name = "penModeButton";
            this.penModeButton.Size = new System.Drawing.Size(23, 22);
            this.penModeButton.Text = "Tile Mode";
            this.penModeButton.Click += new System.EventHandler(this.ModeButton_Click);
            // 
            // fillModeButton
            // 
            this.fillModeButton.CheckOnClick = true;
            this.fillModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fillModeButton.Image = ((System.Drawing.Image)(resources.GetObject("fillModeButton.Image")));
            this.fillModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillModeButton.Name = "fillModeButton";
            this.fillModeButton.Size = new System.Drawing.Size(23, 22);
            this.fillModeButton.Text = "toolStripButton2";
            this.fillModeButton.Click += new System.EventHandler(this.ModeButton_Click);
            // 
            // entranceModeButton
            // 
            this.entranceModeButton.CheckOnClick = true;
            this.entranceModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.entranceModeButton.Image = ((System.Drawing.Image)(resources.GetObject("entranceModeButton.Image")));
            this.entranceModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.entranceModeButton.Name = "entranceModeButton";
            this.entranceModeButton.Size = new System.Drawing.Size(23, 22);
            this.entranceModeButton.Text = "toolStripButton4";
            this.entranceModeButton.Click += new System.EventHandler(this.ModeButton_Click);
            // 
            // exitModeButton
            // 
            this.exitModeButton.CheckOnClick = true;
            this.exitModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitModeButton.Image = ((System.Drawing.Image)(resources.GetObject("exitModeButton.Image")));
            this.exitModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitModeButton.Name = "exitModeButton";
            this.exitModeButton.Size = new System.Drawing.Size(23, 22);
            this.exitModeButton.Text = "toolStripButton5";
            this.exitModeButton.Click += new System.EventHandler(this.ModeButton_Click);
            // 
            // itemModeButton
            // 
            this.itemModeButton.CheckOnClick = true;
            this.itemModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.itemModeButton.Image = ((System.Drawing.Image)(resources.GetObject("itemModeButton.Image")));
            this.itemModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itemModeButton.Name = "itemModeButton";
            this.itemModeButton.Size = new System.Drawing.Size(23, 22);
            this.itemModeButton.Text = "toolStripButton6";
            this.itemModeButton.Click += new System.EventHandler(this.ModeButton_Click);
            // 
            // spriteModeButton
            // 
            this.spriteModeButton.CheckOnClick = true;
            this.spriteModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.spriteModeButton.Image = ((System.Drawing.Image)(resources.GetObject("spriteModeButton.Image")));
            this.spriteModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.spriteModeButton.Name = "spriteModeButton";
            this.spriteModeButton.Size = new System.Drawing.Size(23, 22);
            this.spriteModeButton.Text = "toolStripButton7";
            this.spriteModeButton.Click += new System.EventHandler(this.ModeButton_Click);
            // 
            // transportModeButton
            // 
            this.transportModeButton.CheckOnClick = true;
            this.transportModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.transportModeButton.Image = ((System.Drawing.Image)(resources.GetObject("transportModeButton.Image")));
            this.transportModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.transportModeButton.Name = "transportModeButton";
            this.transportModeButton.Size = new System.Drawing.Size(23, 22);
            this.transportModeButton.Text = "toolStripButton8";
            this.transportModeButton.Click += new System.EventHandler(this.ModeButton_Click);
            // 
            // mapGroupbox
            // 
            this.mapGroupbox.Controls.Add(this.label5);
            this.mapGroupbox.Controls.Add(this.sprpaletteTextbox);
            this.mapGroupbox.Controls.Add(this.paletteTextbox);
            this.mapGroupbox.Controls.Add(this.label4);
            this.mapGroupbox.Controls.Add(this.sprgfxTextbox);
            this.mapGroupbox.Controls.Add(this.label3);
            this.mapGroupbox.Controls.Add(this.gfxTextbox);
            this.mapGroupbox.Controls.Add(this.label2);
            this.mapGroupbox.Location = new System.Drawing.Point(160, 3);
            this.mapGroupbox.Name = "mapGroupbox";
            this.mapGroupbox.Size = new System.Drawing.Size(290, 60);
            this.mapGroupbox.TabIndex = 1;
            this.mapGroupbox.TabStop = false;
            this.mapGroupbox.Text = "Selected Map - ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gfx : ";
            // 
            // gfxTextbox
            // 
            this.gfxTextbox.Location = new System.Drawing.Point(9, 32);
            this.gfxTextbox.Name = "gfxTextbox";
            this.gfxTextbox.Size = new System.Drawing.Size(60, 20);
            this.gfxTextbox.TabIndex = 3;
            this.gfxTextbox.TextChanged += new System.EventHandler(this.gfxTextbox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Spr. Gfx : ";
            // 
            // sprgfxTextbox
            // 
            this.sprgfxTextbox.Location = new System.Drawing.Point(141, 32);
            this.sprgfxTextbox.Name = "sprgfxTextbox";
            this.sprgfxTextbox.Size = new System.Drawing.Size(60, 20);
            this.sprgfxTextbox.TabIndex = 5;
            this.sprgfxTextbox.TextChanged += new System.EventHandler(this.gfxTextbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Palette : ";
            // 
            // paletteTextbox
            // 
            this.paletteTextbox.Location = new System.Drawing.Point(75, 32);
            this.paletteTextbox.Name = "paletteTextbox";
            this.paletteTextbox.Size = new System.Drawing.Size(60, 20);
            this.paletteTextbox.TabIndex = 7;
            this.paletteTextbox.TextChanged += new System.EventHandler(this.gfxTextbox_TextChanged);
            // 
            // sprpaletteTextbox
            // 
            this.sprpaletteTextbox.Location = new System.Drawing.Point(207, 32);
            this.sprpaletteTextbox.Name = "sprpaletteTextbox";
            this.sprpaletteTextbox.Size = new System.Drawing.Size(60, 20);
            this.sprpaletteTextbox.TabIndex = 8;
            this.sprpaletteTextbox.TextChanged += new System.EventHandler(this.gfxTextbox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Spr. Palette : ";
            // 
            // selectedTileLabel
            // 
            this.selectedTileLabel.AutoSize = true;
            this.selectedTileLabel.Location = new System.Drawing.Point(3, 55);
            this.selectedTileLabel.Name = "selectedTileLabel";
            this.selectedTileLabel.Size = new System.Drawing.Size(78, 13);
            this.selectedTileLabel.TabIndex = 2;
            this.selectedTileLabel.Text = "Selected Tile : ";
            // 
            // OverworldEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.owPropertyPanel);
            this.Controls.Add(this.owToolStrip);
            this.Name = "OverworldEditor";
            this.Size = new System.Drawing.Size(953, 719);
            this.owToolStrip.ResumeLayout(false);
            this.owToolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.owPropertyPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilePictureBox)).EndInit();
            this.mapGroupbox.ResumeLayout(false);
            this.mapGroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip owToolStrip;
        private System.Windows.Forms.Panel owPropertyPanel;
        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton openfileButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton debugtestButton;
        private System.Windows.Forms.ToolStripButton runtestButton;
        public System.Windows.Forms.ToolStripButton undoButton;
        public System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton penModeButton;
        private System.Windows.Forms.ToolStripButton fillModeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton entranceModeButton;
        private System.Windows.Forms.ToolStripButton exitModeButton;
        private System.Windows.Forms.ToolStripButton itemModeButton;
        private System.Windows.Forms.ToolStripButton spriteModeButton;
        private System.Windows.Forms.ToolStripButton transportModeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox stateCombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.GroupBox mapGroupbox;
        public System.Windows.Forms.TextBox gfxTextbox;
        public System.Windows.Forms.TextBox sprpaletteTextbox;
        public System.Windows.Forms.TextBox paletteTextbox;
        public System.Windows.Forms.TextBox sprgfxTextbox;
        public System.Windows.Forms.PictureBox tilePictureBox;
        private System.Windows.Forms.Label selectedTileLabel;
    }
}
