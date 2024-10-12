namespace ZeldaFullEditor.Gui
{
    partial class Tile16Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureboxTile16 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureboxTile8 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tileUpDown = new System.Windows.Forms.TextBox();
            this.tileTypeBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.paletteUpDown = new System.Windows.Forms.NumericUpDown();
            this.inFrontCheckbox = new System.Windows.Forms.CheckBox();
            this.mirrorYCheckbox = new System.Windows.Forms.CheckBox();
            this.mirrorXCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gridcheckBox = new System.Windows.Forms.CheckBox();
            this.tile16searchTextbox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tile16GroupBox = new System.Windows.Forms.GroupBox();
            this.copiedTileLabel = new System.Windows.Forms.Label();
            this.Tile16PasteBtn = new System.Windows.Forms.Button();
            this.Tile16CopyBtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tilewidthimportHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tiledrawsizeHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile16)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile8)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteUpDown)).BeginInit();
            this.tile16GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureboxTile16
            // 
            this.pictureboxTile16.Location = new System.Drawing.Point(1, 1);
            this.pictureboxTile16.Name = "pictureboxTile16";
            this.pictureboxTile16.Size = new System.Drawing.Size(256, 15008);
            this.pictureboxTile16.TabIndex = 0;
            this.pictureboxTile16.TabStop = false;
            this.pictureboxTile16.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureboxTile16_Paint);
            this.pictureboxTile16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureboxTile16_MouseDown);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureboxTile16);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 608);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureboxTile8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(275, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 608);
            this.panel2.TabIndex = 2;
            // 
            // pictureboxTile8
            // 
            this.pictureboxTile8.Location = new System.Drawing.Point(0, 0);
            this.pictureboxTile8.Name = "pictureboxTile8";
            this.pictureboxTile8.Size = new System.Drawing.Size(256, 1024);
            this.pictureboxTile8.TabIndex = 0;
            this.pictureboxTile8.TabStop = false;
            this.pictureboxTile8.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureboxTile8_Paint);
            this.pictureboxTile8.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureboxTile8_MouseDoubleClick);
            this.pictureboxTile8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureboxTile8_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tileUpDown);
            this.groupBox1.Controls.Add(this.tileTypeBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.paletteUpDown);
            this.groupBox1.Controls.Add(this.inFrontCheckbox);
            this.groupBox1.Controls.Add(this.mirrorYCheckbox);
            this.groupBox1.Controls.Add(this.mirrorXCheckbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(555, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 274);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected tile 8";
            // 
            // tileUpDown
            // 
            this.tileUpDown.Location = new System.Drawing.Point(9, 32);
            this.tileUpDown.Name = "tileUpDown";
            this.tileUpDown.Size = new System.Drawing.Size(120, 20);
            this.tileUpDown.TabIndex = 9;
            this.tileUpDown.Text = "00";
            // 
            // tileTypeBox
            // 
            this.tileTypeBox.FormattingEnabled = true;
            this.tileTypeBox.Location = new System.Drawing.Point(9, 237);
            this.tileTypeBox.Name = "tileTypeBox";
            this.tileTypeBox.Size = new System.Drawing.Size(185, 21);
            this.tileTypeBox.TabIndex = 8;
            this.tileTypeBox.SelectedIndexChanged += new System.EventHandler(this.tileTypeBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Collision type";
            // 
            // paletteUpDown
            // 
            this.paletteUpDown.Location = new System.Drawing.Point(9, 69);
            this.paletteUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.paletteUpDown.Name = "paletteUpDown";
            this.paletteUpDown.Size = new System.Drawing.Size(120, 20);
            this.paletteUpDown.TabIndex = 5;
            this.paletteUpDown.ValueChanged += new System.EventHandler(this.mirrorXCheckbox_CheckedChanged);
            // 
            // inFrontCheckbox
            // 
            this.inFrontCheckbox.AutoSize = true;
            this.inFrontCheckbox.Location = new System.Drawing.Point(9, 164);
            this.inFrontCheckbox.Name = "inFrontCheckbox";
            this.inFrontCheckbox.Size = new System.Drawing.Size(57, 17);
            this.inFrontCheckbox.TabIndex = 4;
            this.inFrontCheckbox.Text = "Priority";
            this.inFrontCheckbox.UseVisualStyleBackColor = true;
            // 
            // mirrorYCheckbox
            // 
            this.mirrorYCheckbox.AutoSize = true;
            this.mirrorYCheckbox.Location = new System.Drawing.Point(9, 132);
            this.mirrorYCheckbox.Name = "mirrorYCheckbox";
            this.mirrorYCheckbox.Size = new System.Drawing.Size(52, 17);
            this.mirrorYCheckbox.TabIndex = 3;
            this.mirrorYCheckbox.Text = "Flip Y";
            this.mirrorYCheckbox.UseVisualStyleBackColor = true;
            this.mirrorYCheckbox.CheckedChanged += new System.EventHandler(this.mirrorXCheckbox_CheckedChanged);
            // 
            // mirrorXCheckbox
            // 
            this.mirrorXCheckbox.AutoSize = true;
            this.mirrorXCheckbox.Location = new System.Drawing.Point(9, 100);
            this.mirrorXCheckbox.Name = "mirrorXCheckbox";
            this.mirrorXCheckbox.Size = new System.Drawing.Size(52, 17);
            this.mirrorXCheckbox.TabIndex = 2;
            this.mirrorXCheckbox.Text = "Flip X";
            this.mirrorXCheckbox.UseVisualStyleBackColor = true;
            this.mirrorXCheckbox.CheckedChanged += new System.EventHandler(this.mirrorXCheckbox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Palette";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tile ID";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(680, 578);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(599, 578);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gridcheckBox
            // 
            this.gridcheckBox.AutoSize = true;
            this.gridcheckBox.Checked = true;
            this.gridcheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridcheckBox.Location = new System.Drawing.Point(555, 292);
            this.gridcheckBox.Name = "gridcheckBox";
            this.gridcheckBox.Size = new System.Drawing.Size(73, 17);
            this.gridcheckBox.TabIndex = 9;
            this.gridcheckBox.Text = "Show grid";
            this.gridcheckBox.UseVisualStyleBackColor = true;
            this.gridcheckBox.CheckedChanged += new System.EventHandler(this.gridcheckBox_CheckedChanged);
            // 
            // tile16searchTextbox
            // 
            this.tile16searchTextbox.Location = new System.Drawing.Point(555, 348);
            this.tile16searchTextbox.Name = "tile16searchTextbox";
            this.tile16searchTextbox.Size = new System.Drawing.Size(120, 20);
            this.tile16searchTextbox.TabIndex = 10;
            this.tile16searchTextbox.Text = "00";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(555, 315);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 27);
            this.button3.TabIndex = 11;
            this.button3.Text = "Go to tile";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tile16GroupBox
            // 
            this.tile16GroupBox.Controls.Add(this.copiedTileLabel);
            this.tile16GroupBox.Controls.Add(this.Tile16PasteBtn);
            this.tile16GroupBox.Controls.Add(this.Tile16CopyBtn);
            this.tile16GroupBox.Location = new System.Drawing.Point(549, 374);
            this.tile16GroupBox.Name = "tile16GroupBox";
            this.tile16GroupBox.Size = new System.Drawing.Size(200, 85);
            this.tile16GroupBox.TabIndex = 12;
            this.tile16GroupBox.TabStop = false;
            this.tile16GroupBox.Text = "Selected tile 16: ";
            // 
            // copiedTileLabel
            // 
            this.copiedTileLabel.AutoSize = true;
            this.copiedTileLabel.Location = new System.Drawing.Point(12, 54);
            this.copiedTileLabel.Name = "copiedTileLabel";
            this.copiedTileLabel.Size = new System.Drawing.Size(66, 13);
            this.copiedTileLabel.TabIndex = 14;
            this.copiedTileLabel.Text = "Copied Tile: ";
            // 
            // Tile16PasteBtn
            // 
            this.Tile16PasteBtn.Location = new System.Drawing.Point(103, 19);
            this.Tile16PasteBtn.Name = "Tile16PasteBtn";
            this.Tile16PasteBtn.Size = new System.Drawing.Size(91, 27);
            this.Tile16PasteBtn.TabIndex = 13;
            this.Tile16PasteBtn.Text = "Paste";
            this.Tile16PasteBtn.UseVisualStyleBackColor = true;
            this.Tile16PasteBtn.Click += new System.EventHandler(this.Tile16PasteBtn_Click);
            // 
            // Tile16CopyBtn
            // 
            this.Tile16CopyBtn.Location = new System.Drawing.Point(6, 19);
            this.Tile16CopyBtn.Name = "Tile16CopyBtn";
            this.Tile16CopyBtn.Size = new System.Drawing.Size(91, 27);
            this.Tile16CopyBtn.TabIndex = 12;
            this.Tile16CopyBtn.Text = "Copy";
            this.Tile16CopyBtn.UseVisualStyleBackColor = true;
            this.Tile16CopyBtn.Click += new System.EventHandler(this.Tile16CopyBtn_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(549, 549);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Import Tilemap (beta)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tilewidthimportHexbox
            // 
            this.tilewidthimportHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tilewidthimportHexbox.Decimal = true;
            this.tilewidthimportHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.tilewidthimportHexbox.HexValue = 8;
            this.tilewidthimportHexbox.Location = new System.Drawing.Point(549, 529);
            this.tilewidthimportHexbox.MaxLength = 2;
            this.tilewidthimportHexbox.MaxValue = 16;
            this.tilewidthimportHexbox.MinValue = 0;
            this.tilewidthimportHexbox.Name = "tilewidthimportHexbox";
            this.tilewidthimportHexbox.Size = new System.Drawing.Size(200, 20);
            this.tilewidthimportHexbox.TabIndex = 14;
            this.tilewidthimportHexbox.Text = "8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 513);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tilemap import width 8x8 (16 max decimal)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(546, 462);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tile draw size";
            // 
            // tiledrawsizeHexbox
            // 
            this.tiledrawsizeHexbox.Decimal = true;
            this.tiledrawsizeHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.One;
            this.tiledrawsizeHexbox.HexValue = 1;
            this.tiledrawsizeHexbox.Location = new System.Drawing.Point(549, 478);
            this.tiledrawsizeHexbox.MaxLength = 1;
            this.tiledrawsizeHexbox.MaxValue = 8;
            this.tiledrawsizeHexbox.MinValue = 1;
            this.tiledrawsizeHexbox.Name = "tiledrawsizeHexbox";
            this.tiledrawsizeHexbox.Size = new System.Drawing.Size(68, 20);
            this.tiledrawsizeHexbox.TabIndex = 17;
            this.tiledrawsizeHexbox.Text = "1";
            this.tiledrawsizeHexbox.TextChanged += new System.EventHandler(this.tiledrawsizeHexbox_TextChanged);
            // 
            // Tile16Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 608);
            this.Controls.Add(this.tiledrawsizeHexbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tilewidthimportHexbox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tile16GroupBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tile16searchTextbox);
            this.Controls.Add(this.gridcheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Tile16Editor";
            this.Text = "Tile 16 Editor";
            this.Load += new System.EventHandler(this.Tile16Editor_Load);
            this.Shown += new System.EventHandler(this.Tile16Editor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile16)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile8)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteUpDown)).EndInit();
            this.tile16GroupBox.ResumeLayout(false);
            this.tile16GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureboxTile16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureboxTile8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown paletteUpDown;
        private System.Windows.Forms.CheckBox inFrontCheckbox;
        private System.Windows.Forms.CheckBox mirrorYCheckbox;
        private System.Windows.Forms.CheckBox mirrorXCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tileTypeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox gridcheckBox;
        private System.Windows.Forms.TextBox tileUpDown;
        private System.Windows.Forms.TextBox tile16searchTextbox;
        private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox tile16GroupBox;
		private System.Windows.Forms.Label copiedTileLabel;
		private System.Windows.Forms.Button Tile16PasteBtn;
		private System.Windows.Forms.Button Tile16CopyBtn;
        private System.Windows.Forms.Button button4;
        private ExtraForms.Hexbox tilewidthimportHexbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ExtraForms.Hexbox tiledrawsizeHexbox;
    }
}