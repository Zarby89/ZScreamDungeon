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
            this.openfileButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.debugtestButton = new System.Windows.Forms.ToolStripButton();
            this.runtestButton = new System.Windows.Forms.ToolStripButton();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.penModeButton = new System.Windows.Forms.ToolStripButton();
            this.fillModeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.entranceModeButton = new System.Windows.Forms.ToolStripButton();
            this.exitModeButton = new System.Windows.Forms.ToolStripButton();
            this.itemModeButton = new System.Windows.Forms.ToolStripButton();
            this.spriteModeButton = new System.Windows.Forms.ToolStripButton();
            this.transportModeButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tilePictureBox = new System.Windows.Forms.PictureBox();
            this.owPropertyPanel = new System.Windows.Forms.Panel();
            this.owToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilePictureBox)).BeginInit();
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
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // tilePictureBox
            // 
            this.tilePictureBox.Location = new System.Drawing.Point(3, 3);
            this.tilePictureBox.Name = "tilePictureBox";
            this.tilePictureBox.Size = new System.Drawing.Size(128, 4096);
            this.tilePictureBox.TabIndex = 0;
            this.tilePictureBox.TabStop = false;
            // 
            // owPropertyPanel
            // 
            this.owPropertyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.owPropertyPanel.Location = new System.Drawing.Point(0, 25);
            this.owPropertyPanel.Name = "owPropertyPanel";
            this.owPropertyPanel.Size = new System.Drawing.Size(953, 75);
            this.owPropertyPanel.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.tilePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip owToolStrip;
        private System.Windows.Forms.Panel owPropertyPanel;
        private System.Windows.Forms.PictureBox tilePictureBox;
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
    }
}
