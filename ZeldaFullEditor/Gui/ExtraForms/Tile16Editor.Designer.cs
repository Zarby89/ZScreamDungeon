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
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.gridcheckBox = new System.Windows.Forms.CheckBox();
            this.tile16searchTextbox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tile16GroupBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.copyrangeUpdown = new System.Windows.Forms.NumericUpDown();
            this.pasteRangeButton = new System.Windows.Forms.Button();
            this.copyRangeButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.collisionsheetPicturebox = new System.Windows.Forms.PictureBox();
            this.showcollisionCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectedsheetUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.tiletypesheetCombobox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.vanillacopycolButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tiledrawsizeHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.tilewidthimportHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.sheetLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile16)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile8)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteUpDown)).BeginInit();
            this.tile16GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copyrangeUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collisionsheetPicturebox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedsheetUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureboxTile16
            // 
            this.pictureboxTile16.Location = new System.Drawing.Point(1, 1);
            this.pictureboxTile16.Name = "pictureboxTile16";
            this.pictureboxTile16.Size = new System.Drawing.Size(256, 16384);
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
            this.panel1.Size = new System.Drawing.Size(275, 619);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.sheetLabel);
            this.panel2.Controls.Add(this.pictureboxTile8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(275, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 619);
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
            this.pictureboxTile8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureboxTile8_MouseUp);
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
            this.groupBox1.Location = new System.Drawing.Point(589, 12);
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
            this.tileTypeBox.Enabled = false;
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
            this.label3.Enabled = false;
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
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(1252, 589);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(1171, 589);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // gridcheckBox
            // 
            this.gridcheckBox.AutoSize = true;
            this.gridcheckBox.Checked = true;
            this.gridcheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridcheckBox.Location = new System.Drawing.Point(589, 292);
            this.gridcheckBox.Name = "gridcheckBox";
            this.gridcheckBox.Size = new System.Drawing.Size(73, 17);
            this.gridcheckBox.TabIndex = 9;
            this.gridcheckBox.Text = "Show grid";
            this.gridcheckBox.UseVisualStyleBackColor = true;
            this.gridcheckBox.CheckedChanged += new System.EventHandler(this.gridcheckBox_CheckedChanged);
            // 
            // tile16searchTextbox
            // 
            this.tile16searchTextbox.Location = new System.Drawing.Point(589, 348);
            this.tile16searchTextbox.Name = "tile16searchTextbox";
            this.tile16searchTextbox.Size = new System.Drawing.Size(120, 20);
            this.tile16searchTextbox.TabIndex = 10;
            this.tile16searchTextbox.Text = "00";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(589, 315);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 27);
            this.button3.TabIndex = 11;
            this.button3.Text = "Go to tile";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tile16GroupBox
            // 
            this.tile16GroupBox.Controls.Add(this.label6);
            this.tile16GroupBox.Controls.Add(this.copyrangeUpdown);
            this.tile16GroupBox.Controls.Add(this.pasteRangeButton);
            this.tile16GroupBox.Controls.Add(this.copyRangeButton);
            this.tile16GroupBox.Location = new System.Drawing.Point(583, 374);
            this.tile16GroupBox.Name = "tile16GroupBox";
            this.tile16GroupBox.Size = new System.Drawing.Size(200, 91);
            this.tile16GroupBox.TabIndex = 12;
            this.tile16GroupBox.TabStop = false;
            this.tile16GroupBox.Text = "Selected tile 16: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Number of tiles :";
            // 
            // copyrangeUpdown
            // 
            this.copyrangeUpdown.Location = new System.Drawing.Point(103, 52);
            this.copyrangeUpdown.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.copyrangeUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.copyrangeUpdown.Name = "copyrangeUpdown";
            this.copyrangeUpdown.Size = new System.Drawing.Size(91, 20);
            this.copyrangeUpdown.TabIndex = 17;
            this.copyrangeUpdown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pasteRangeButton
            // 
            this.pasteRangeButton.Location = new System.Drawing.Point(103, 19);
            this.pasteRangeButton.Name = "pasteRangeButton";
            this.pasteRangeButton.Size = new System.Drawing.Size(91, 27);
            this.pasteRangeButton.TabIndex = 16;
            this.pasteRangeButton.Text = "Paste Range";
            this.pasteRangeButton.UseVisualStyleBackColor = true;
            this.pasteRangeButton.Click += new System.EventHandler(this.pasteRangeButton_Click);
            // 
            // copyRangeButton
            // 
            this.copyRangeButton.Location = new System.Drawing.Point(6, 19);
            this.copyRangeButton.Name = "copyRangeButton";
            this.copyRangeButton.Size = new System.Drawing.Size(91, 27);
            this.copyRangeButton.TabIndex = 15;
            this.copyRangeButton.Text = "Copy Range";
            this.copyRangeButton.UseVisualStyleBackColor = true;
            this.copyRangeButton.Click += new System.EventHandler(this.copyRangeButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(583, 555);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Import Tilemap (beta)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(586, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tilemap import width 8x8 (16 max decimal)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(580, 468);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tile draw size";
            // 
            // collisionsheetPicturebox
            // 
            this.collisionsheetPicturebox.Location = new System.Drawing.Point(6, 43);
            this.collisionsheetPicturebox.Name = "collisionsheetPicturebox";
            this.collisionsheetPicturebox.Size = new System.Drawing.Size(512, 128);
            this.collisionsheetPicturebox.TabIndex = 18;
            this.collisionsheetPicturebox.TabStop = false;
            this.collisionsheetPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.collisionsheetPicturebox_Paint);
            this.collisionsheetPicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.collisionsheetPicturebox_MouseDown);
            this.collisionsheetPicturebox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.collisionsheetPicturebox_MouseMove);
            this.collisionsheetPicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.collisionsheetPicturebox_MouseUp);
            // 
            // showcollisionCheckbox
            // 
            this.showcollisionCheckbox.AutoSize = true;
            this.showcollisionCheckbox.Checked = true;
            this.showcollisionCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showcollisionCheckbox.Location = new System.Drawing.Point(668, 292);
            this.showcollisionCheckbox.Name = "showcollisionCheckbox";
            this.showcollisionCheckbox.Size = new System.Drawing.Size(94, 17);
            this.showcollisionCheckbox.TabIndex = 19;
            this.showcollisionCheckbox.Text = "Show Collision";
            this.showcollisionCheckbox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectedsheetUpDown);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tiletypesheetCombobox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.vanillacopycolButton);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.collisionsheetPicturebox);
            this.groupBox2.Location = new System.Drawing.Point(795, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 274);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Individual Collision Sheet for Overworld";
            // 
            // selectedsheetUpDown
            // 
            this.selectedsheetUpDown.Hexadecimal = true;
            this.selectedsheetUpDown.Location = new System.Drawing.Point(101, 16);
            this.selectedsheetUpDown.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.selectedsheetUpDown.Name = "selectedsheetUpDown";
            this.selectedsheetUpDown.Size = new System.Drawing.Size(80, 20);
            this.selectedsheetUpDown.TabIndex = 25;
            this.selectedsheetUpDown.ValueChanged += new System.EventHandler(this.selectedsheetUpDown_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Selected Sheet : ";
            // 
            // tiletypesheetCombobox
            // 
            this.tiletypesheetCombobox.FormattingEnabled = true;
            this.tiletypesheetCombobox.Location = new System.Drawing.Point(93, 177);
            this.tiletypesheetCombobox.Name = "tiletypesheetCombobox";
            this.tiletypesheetCombobox.Size = new System.Drawing.Size(425, 21);
            this.tiletypesheetCombobox.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Collision Type : ";
            // 
            // vanillacopycolButton
            // 
            this.vanillacopycolButton.Location = new System.Drawing.Point(134, 245);
            this.vanillacopycolButton.Name = "vanillacopycolButton";
            this.vanillacopycolButton.Size = new System.Drawing.Size(75, 23);
            this.vanillacopycolButton.TabIndex = 20;
            this.vanillacopycolButton.Text = "Copy!";
            this.vanillacopycolButton.UseVisualStyleBackColor = true;
            this.vanillacopycolButton.Click += new System.EventHandler(this.vanillacopycolButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Copy from old collisions: ";
            // 
            // tiledrawsizeHexbox
            // 
            this.tiledrawsizeHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tiledrawsizeHexbox.Decimal = true;
            this.tiledrawsizeHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.One;
            this.tiledrawsizeHexbox.HexValue = 1;
            this.tiledrawsizeHexbox.Location = new System.Drawing.Point(583, 484);
            this.tiledrawsizeHexbox.MaxLength = 1;
            this.tiledrawsizeHexbox.MaxValue = 8;
            this.tiledrawsizeHexbox.MinValue = 1;
            this.tiledrawsizeHexbox.Name = "tiledrawsizeHexbox";
            this.tiledrawsizeHexbox.Size = new System.Drawing.Size(68, 20);
            this.tiledrawsizeHexbox.TabIndex = 17;
            this.tiledrawsizeHexbox.Text = "1";
            this.tiledrawsizeHexbox.TextChanged += new System.EventHandler(this.tiledrawsizeHexbox_TextChanged);
            // 
            // tilewidthimportHexbox
            // 
            this.tilewidthimportHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tilewidthimportHexbox.Decimal = true;
            this.tilewidthimportHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.tilewidthimportHexbox.HexValue = 8;
            this.tilewidthimportHexbox.Location = new System.Drawing.Point(583, 535);
            this.tilewidthimportHexbox.MaxLength = 2;
            this.tilewidthimportHexbox.MaxValue = 16;
            this.tilewidthimportHexbox.MinValue = 0;
            this.tilewidthimportHexbox.Name = "tilewidthimportHexbox";
            this.tilewidthimportHexbox.Size = new System.Drawing.Size(200, 20);
            this.tilewidthimportHexbox.TabIndex = 14;
            this.tilewidthimportHexbox.Text = "8";
            // 
            // sheetLabel
            // 
            this.sheetLabel.AutoSize = true;
            this.sheetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheetLabel.Location = new System.Drawing.Point(257, 28);
            this.sheetLabel.Name = "sheetLabel";
            this.sheetLabel.Size = new System.Drawing.Size(21, 13);
            this.sheetLabel.TabIndex = 1;
            this.sheetLabel.Text = "00";
            this.sheetLabel.Visible = false;
            // 
            // Tile16Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 619);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.showcollisionCheckbox);
            this.Controls.Add(this.tiledrawsizeHexbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tilewidthimportHexbox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tile16GroupBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tile16searchTextbox);
            this.Controls.Add(this.gridcheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Tile16Editor";
            this.Text = "Tile 16 Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tile16Editor_FormClosing);
            this.Load += new System.EventHandler(this.Tile16Editor_Load);
            this.Shown += new System.EventHandler(this.Tile16Editor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile16)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile8)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteUpDown)).EndInit();
            this.tile16GroupBox.ResumeLayout(false);
            this.tile16GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copyrangeUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.collisionsheetPicturebox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedsheetUpDown)).EndInit();
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
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox gridcheckBox;
        private System.Windows.Forms.TextBox tileUpDown;
        private System.Windows.Forms.TextBox tile16searchTextbox;
        private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox tile16GroupBox;
        private System.Windows.Forms.Button button4;
        private ExtraForms.Hexbox tilewidthimportHexbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ExtraForms.Hexbox tiledrawsizeHexbox;
        private System.Windows.Forms.NumericUpDown copyrangeUpdown;
        private System.Windows.Forms.Button pasteRangeButton;
        private System.Windows.Forms.Button copyRangeButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox collisionsheetPicturebox;
        private System.Windows.Forms.CheckBox showcollisionCheckbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button vanillacopycolButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox tiletypesheetCombobox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown selectedsheetUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label sheetLabel;
    }
}