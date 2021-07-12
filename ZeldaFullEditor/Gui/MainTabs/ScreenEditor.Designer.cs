namespace ZeldaFullEditor.Gui.MainTabs
{
    partial class ScreenEditor
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uppersprCheckbox = new System.Windows.Forms.CheckBox();
            this.lockCheckbox = new System.Windows.Forms.CheckBox();
            this.movesprRadio = new System.Windows.Forms.RadioButton();
            this.editsprRadio = new System.Windows.Forms.RadioButton();
            this.oambgCheckbox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bg3Radio = new System.Windows.Forms.RadioButton();
            this.bg2Radio = new System.Windows.Forms.RadioButton();
            this.bg1Radio = new System.Windows.Forms.RadioButton();
            this.bg3Checkbox = new System.Windows.Forms.CheckBox();
            this.bg2Checkbox = new System.Windows.Forms.CheckBox();
            this.bg1checkbox = new System.Windows.Forms.CheckBox();
            this.onTopCheckbox = new System.Windows.Forms.CheckBox();
            this.mirrorYCheckbox = new System.Windows.Forms.CheckBox();
            this.mirrorXCheckbox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.paletteBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tilesBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.screenBox = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.owMapTilesBox = new System.Windows.Forms.PictureBox();
            this.mapPalettePicturebox = new System.Windows.Forms.PictureBox();
            this.overworldPanel = new System.Windows.Forms.Panel();
            this.mapPicturebox = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.owMapTilesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPalettePicturebox)).BeginInit();
            this.overworldPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1080, 800);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uppersprCheckbox);
            this.tabPage1.Controls.Add(this.lockCheckbox);
            this.tabPage1.Controls.Add(this.movesprRadio);
            this.tabPage1.Controls.Add(this.editsprRadio);
            this.tabPage1.Controls.Add(this.oambgCheckbox);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.bg3Radio);
            this.tabPage1.Controls.Add(this.bg2Radio);
            this.tabPage1.Controls.Add(this.bg1Radio);
            this.tabPage1.Controls.Add(this.bg3Checkbox);
            this.tabPage1.Controls.Add(this.bg2Checkbox);
            this.tabPage1.Controls.Add(this.bg1checkbox);
            this.tabPage1.Controls.Add(this.onTopCheckbox);
            this.tabPage1.Controls.Add(this.mirrorYCheckbox);
            this.tabPage1.Controls.Add(this.mirrorXCheckbox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.paletteBox);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.screenBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1072, 774);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Titlescreen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uppersprCheckbox
            // 
            this.uppersprCheckbox.AutoSize = true;
            this.uppersprCheckbox.Location = new System.Drawing.Point(519, 470);
            this.uppersprCheckbox.Name = "uppersprCheckbox";
            this.uppersprCheckbox.Size = new System.Drawing.Size(227, 17);
            this.uppersprCheckbox.TabIndex = 21;
            this.uppersprCheckbox.Text = "Use upper sprite section for the sprites tiles";
            this.uppersprCheckbox.UseVisualStyleBackColor = true;
            // 
            // lockCheckbox
            // 
            this.lockCheckbox.AutoSize = true;
            this.lockCheckbox.Checked = true;
            this.lockCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lockCheckbox.Location = new System.Drawing.Point(279, 516);
            this.lockCheckbox.Name = "lockCheckbox";
            this.lockCheckbox.Size = new System.Drawing.Size(87, 17);
            this.lockCheckbox.TabIndex = 20;
            this.lockCheckbox.Text = "Lock 8x8 spr";
            this.lockCheckbox.UseVisualStyleBackColor = true;
            // 
            // movesprRadio
            // 
            this.movesprRadio.AutoSize = true;
            this.movesprRadio.Location = new System.Drawing.Point(383, 493);
            this.movesprRadio.Name = "movesprRadio";
            this.movesprRadio.Size = new System.Drawing.Size(105, 17);
            this.movesprRadio.TabIndex = 19;
            this.movesprRadio.Text = "Move Spr Object";
            this.movesprRadio.UseVisualStyleBackColor = true;
            // 
            // editsprRadio
            // 
            this.editsprRadio.AutoSize = true;
            this.editsprRadio.Location = new System.Drawing.Point(279, 493);
            this.editsprRadio.Name = "editsprRadio";
            this.editsprRadio.Size = new System.Drawing.Size(98, 17);
            this.editsprRadio.TabIndex = 18;
            this.editsprRadio.Text = "Edit Sprite Tiles";
            this.editsprRadio.UseVisualStyleBackColor = true;
            // 
            // oambgCheckbox
            // 
            this.oambgCheckbox.AutoSize = true;
            this.oambgCheckbox.Checked = true;
            this.oambgCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.oambgCheckbox.Location = new System.Drawing.Point(279, 470);
            this.oambgCheckbox.Name = "oambgCheckbox";
            this.oambgCheckbox.Size = new System.Drawing.Size(88, 17);
            this.oambgCheckbox.TabIndex = 17;
            this.oambgCheckbox.Text = "Show Sprites";
            this.oambgCheckbox.UseVisualStyleBackColor = true;
            this.oambgCheckbox.CheckedChanged += new System.EventHandler(this.bg1checkbox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 552);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "PlayTest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bg3Radio
            // 
            this.bg3Radio.AutoSize = true;
            this.bg3Radio.Enabled = false;
            this.bg3Radio.Location = new System.Drawing.Point(196, 493);
            this.bg3Radio.Name = "bg3Radio";
            this.bg3Radio.Size = new System.Drawing.Size(67, 17);
            this.bg3Radio.TabIndex = 14;
            this.bg3Radio.Text = "Edit BG3";
            this.bg3Radio.UseVisualStyleBackColor = true;
            // 
            // bg2Radio
            // 
            this.bg2Radio.AutoSize = true;
            this.bg2Radio.Location = new System.Drawing.Point(101, 493);
            this.bg2Radio.Name = "bg2Radio";
            this.bg2Radio.Size = new System.Drawing.Size(67, 17);
            this.bg2Radio.TabIndex = 13;
            this.bg2Radio.Text = "Edit BG2";
            this.bg2Radio.UseVisualStyleBackColor = true;
            // 
            // bg1Radio
            // 
            this.bg1Radio.AutoSize = true;
            this.bg1Radio.Checked = true;
            this.bg1Radio.Location = new System.Drawing.Point(6, 493);
            this.bg1Radio.Name = "bg1Radio";
            this.bg1Radio.Size = new System.Drawing.Size(67, 17);
            this.bg1Radio.TabIndex = 12;
            this.bg1Radio.TabStop = true;
            this.bg1Radio.Text = "Edit BG1";
            this.bg1Radio.UseVisualStyleBackColor = true;
            // 
            // bg3Checkbox
            // 
            this.bg3Checkbox.AutoSize = true;
            this.bg3Checkbox.Checked = true;
            this.bg3Checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bg3Checkbox.Enabled = false;
            this.bg3Checkbox.Location = new System.Drawing.Point(196, 470);
            this.bg3Checkbox.Name = "bg3Checkbox";
            this.bg3Checkbox.Size = new System.Drawing.Size(77, 17);
            this.bg3Checkbox.TabIndex = 11;
            this.bg3Checkbox.Text = "Show BG3";
            this.bg3Checkbox.UseVisualStyleBackColor = true;
            // 
            // bg2Checkbox
            // 
            this.bg2Checkbox.AutoSize = true;
            this.bg2Checkbox.Checked = true;
            this.bg2Checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bg2Checkbox.Location = new System.Drawing.Point(101, 470);
            this.bg2Checkbox.Name = "bg2Checkbox";
            this.bg2Checkbox.Size = new System.Drawing.Size(77, 17);
            this.bg2Checkbox.TabIndex = 10;
            this.bg2Checkbox.Text = "Show BG2";
            this.bg2Checkbox.UseVisualStyleBackColor = true;
            this.bg2Checkbox.CheckedChanged += new System.EventHandler(this.bg1checkbox_CheckedChanged);
            // 
            // bg1checkbox
            // 
            this.bg1checkbox.AutoSize = true;
            this.bg1checkbox.Checked = true;
            this.bg1checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bg1checkbox.Location = new System.Drawing.Point(6, 470);
            this.bg1checkbox.Name = "bg1checkbox";
            this.bg1checkbox.Size = new System.Drawing.Size(77, 17);
            this.bg1checkbox.TabIndex = 9;
            this.bg1checkbox.Text = "Show BG1";
            this.bg1checkbox.UseVisualStyleBackColor = true;
            this.bg1checkbox.CheckedChanged += new System.EventHandler(this.bg1checkbox_CheckedChanged);
            // 
            // onTopCheckbox
            // 
            this.onTopCheckbox.AutoSize = true;
            this.onTopCheckbox.Location = new System.Drawing.Point(801, 324);
            this.onTopCheckbox.Name = "onTopCheckbox";
            this.onTopCheckbox.Size = new System.Drawing.Size(62, 17);
            this.onTopCheckbox.TabIndex = 8;
            this.onTopCheckbox.Text = "On Top";
            this.onTopCheckbox.UseVisualStyleBackColor = true;
            // 
            // mirrorYCheckbox
            // 
            this.mirrorYCheckbox.AutoSize = true;
            this.mirrorYCheckbox.Location = new System.Drawing.Point(801, 301);
            this.mirrorYCheckbox.Name = "mirrorYCheckbox";
            this.mirrorYCheckbox.Size = new System.Drawing.Size(62, 17);
            this.mirrorYCheckbox.TabIndex = 7;
            this.mirrorYCheckbox.Text = "Mirror Y";
            this.mirrorYCheckbox.UseVisualStyleBackColor = true;
            this.mirrorYCheckbox.CheckedChanged += new System.EventHandler(this.mirrorXCheckbox_CheckedChanged);
            // 
            // mirrorXCheckbox
            // 
            this.mirrorXCheckbox.AutoSize = true;
            this.mirrorXCheckbox.Location = new System.Drawing.Point(801, 278);
            this.mirrorXCheckbox.Name = "mirrorXCheckbox";
            this.mirrorXCheckbox.Size = new System.Drawing.Size(62, 17);
            this.mirrorXCheckbox.TabIndex = 6;
            this.mirrorXCheckbox.Text = "Mirror X";
            this.mirrorXCheckbox.UseVisualStyleBackColor = true;
            this.mirrorXCheckbox.CheckedChanged += new System.EventHandler(this.mirrorXCheckbox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(801, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Palettes:";
            // 
            // paletteBox
            // 
            this.paletteBox.Location = new System.Drawing.Point(801, 16);
            this.paletteBox.Name = "paletteBox";
            this.paletteBox.Size = new System.Drawing.Size(256, 256);
            this.paletteBox.TabIndex = 3;
            this.paletteBox.TabStop = false;
            this.paletteBox.Paint += new System.Windows.Forms.PaintEventHandler(this.paletteBox_Paint);
            this.paletteBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paletteBox_MouseDown);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tilesBox);
            this.panel1.Location = new System.Drawing.Point(519, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 448);
            this.panel1.TabIndex = 4;
            // 
            // tilesBox
            // 
            this.tilesBox.BackColor = System.Drawing.Color.Black;
            this.tilesBox.Location = new System.Drawing.Point(3, 3);
            this.tilesBox.Name = "tilesBox";
            this.tilesBox.Size = new System.Drawing.Size(256, 1024);
            this.tilesBox.TabIndex = 2;
            this.tilesBox.TabStop = false;
            this.tilesBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.tilesBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tilesBox_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tiles X2 Display (GFX. Tile=35, Spr = 125)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Screen X2 Display";
            // 
            // screenBox
            // 
            this.screenBox.BackColor = System.Drawing.Color.Black;
            this.screenBox.Location = new System.Drawing.Point(0, 16);
            this.screenBox.Name = "screenBox";
            this.screenBox.Size = new System.Drawing.Size(512, 448);
            this.screenBox.TabIndex = 0;
            this.screenBox.TabStop = false;
            this.screenBox.Paint += new System.Windows.Forms.PaintEventHandler(this.screenBox_Paint);
            this.screenBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.screenBox_MouseDown);
            this.screenBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.screenBox_MouseMove);
            this.screenBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.screenBox_MouseUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.owMapTilesBox);
            this.tabPage2.Controls.Add(this.mapPalettePicturebox);
            this.tabPage2.Controls.Add(this.overworldPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1072, 774);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Overworld Map";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(761, 527);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Switch";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09"});
            this.comboBox1.Location = new System.Drawing.Point(761, 576);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(256, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(761, 560);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Events (7EF3C7) : ";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(942, 527);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Import";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(861, 527);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Export";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // owMapTilesBox
            // 
            this.owMapTilesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.owMapTilesBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.owMapTilesBox.Location = new System.Drawing.Point(761, 3);
            this.owMapTilesBox.Name = "owMapTilesBox";
            this.owMapTilesBox.Size = new System.Drawing.Size(256, 256);
            this.owMapTilesBox.TabIndex = 3;
            this.owMapTilesBox.TabStop = false;
            this.owMapTilesBox.Paint += new System.Windows.Forms.PaintEventHandler(this.owMapTilesBox_Paint);
            this.owMapTilesBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.owMapTilesBox_MouseDown);
            // 
            // mapPalettePicturebox
            // 
            this.mapPalettePicturebox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mapPalettePicturebox.Location = new System.Drawing.Point(761, 265);
            this.mapPalettePicturebox.Name = "mapPalettePicturebox";
            this.mapPalettePicturebox.Size = new System.Drawing.Size(256, 256);
            this.mapPalettePicturebox.TabIndex = 2;
            this.mapPalettePicturebox.TabStop = false;
            this.mapPalettePicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPalettePicturebox_Paint);
            // 
            // overworldPanel
            // 
            this.overworldPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overworldPanel.AutoScroll = true;
            this.overworldPanel.Controls.Add(this.mapPicturebox);
            this.overworldPanel.Location = new System.Drawing.Point(3, 3);
            this.overworldPanel.Name = "overworldPanel";
            this.overworldPanel.Size = new System.Drawing.Size(752, 768);
            this.overworldPanel.TabIndex = 1;
            // 
            // mapPicturebox
            // 
            this.mapPicturebox.Location = new System.Drawing.Point(3, 3);
            this.mapPicturebox.Name = "mapPicturebox";
            this.mapPicturebox.Size = new System.Drawing.Size(1024, 1024);
            this.mapPicturebox.TabIndex = 0;
            this.mapPicturebox.TabStop = false;
            this.mapPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPicturebox_Paint);
            // 
            // ScreenEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ScreenEditor";
            this.Size = new System.Drawing.Size(1080, 800);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteBox)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tilesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.owMapTilesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPalettePicturebox)).EndInit();
            this.overworldPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox tilesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox screenBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox onTopCheckbox;
        private System.Windows.Forms.CheckBox mirrorYCheckbox;
        private System.Windows.Forms.CheckBox mirrorXCheckbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox paletteBox;
        private System.Windows.Forms.CheckBox bg2Checkbox;
        private System.Windows.Forms.CheckBox bg1checkbox;
        private System.Windows.Forms.RadioButton bg3Radio;
        private System.Windows.Forms.RadioButton bg2Radio;
        private System.Windows.Forms.RadioButton bg1Radio;
        private System.Windows.Forms.CheckBox bg3Checkbox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel overworldPanel;
        private System.Windows.Forms.PictureBox mapPicturebox;
        private System.Windows.Forms.PictureBox owMapTilesBox;
        private System.Windows.Forms.PictureBox mapPalettePicturebox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox oambgCheckbox;
        private System.Windows.Forms.RadioButton editsprRadio;
        private System.Windows.Forms.RadioButton movesprRadio;
        private System.Windows.Forms.CheckBox lockCheckbox;
        private System.Windows.Forms.CheckBox uppersprCheckbox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
    }
}
