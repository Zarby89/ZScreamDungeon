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
            this.tileTypeBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tileUpDown = new System.Windows.Forms.NumericUpDown();
            this.paletteUpDown = new System.Windows.Forms.NumericUpDown();
            this.inFrontCheckbox = new System.Windows.Forms.CheckBox();
            this.mirrorYCheckbox = new System.Windows.Forms.CheckBox();
            this.mirrorXCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gridcheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile16)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile8)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paletteUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureboxTile16
            // 
            this.pictureboxTile16.Location = new System.Drawing.Point(1, 1);
            this.pictureboxTile16.Name = "pictureboxTile16";
            this.pictureboxTile16.Size = new System.Drawing.Size(256, 16000);
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
            this.panel1.Size = new System.Drawing.Size(275, 578);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureboxTile8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(275, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 578);
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
            this.groupBox1.Controls.Add(this.tileTypeBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tileUpDown);
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
            this.groupBox1.Text = "Selected Tile8";
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
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tile Type* : ";
            // 
            // tileUpDown
            // 
            this.tileUpDown.Location = new System.Drawing.Point(9, 32);
            this.tileUpDown.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.tileUpDown.Name = "tileUpDown";
            this.tileUpDown.Size = new System.Drawing.Size(120, 20);
            this.tileUpDown.TabIndex = 6;
            this.tileUpDown.ValueChanged += new System.EventHandler(this.mirrorXCheckbox_CheckedChanged);
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
            this.inFrontCheckbox.Size = new System.Drawing.Size(62, 17);
            this.inFrontCheckbox.TabIndex = 4;
            this.inFrontCheckbox.Text = "In Front";
            this.inFrontCheckbox.UseVisualStyleBackColor = true;
            // 
            // mirrorYCheckbox
            // 
            this.mirrorYCheckbox.AutoSize = true;
            this.mirrorYCheckbox.Location = new System.Drawing.Point(9, 132);
            this.mirrorYCheckbox.Name = "mirrorYCheckbox";
            this.mirrorYCheckbox.Size = new System.Drawing.Size(62, 17);
            this.mirrorYCheckbox.TabIndex = 3;
            this.mirrorYCheckbox.Text = "Mirror Y";
            this.mirrorYCheckbox.UseVisualStyleBackColor = true;
            this.mirrorYCheckbox.CheckedChanged += new System.EventHandler(this.mirrorXCheckbox_CheckedChanged);
            // 
            // mirrorXCheckbox
            // 
            this.mirrorXCheckbox.AutoSize = true;
            this.mirrorXCheckbox.Location = new System.Drawing.Point(9, 100);
            this.mirrorXCheckbox.Name = "mirrorXCheckbox";
            this.mirrorXCheckbox.Size = new System.Drawing.Size(62, 17);
            this.mirrorXCheckbox.TabIndex = 2;
            this.mirrorXCheckbox.Text = "Mirror X";
            this.mirrorXCheckbox.UseVisualStyleBackColor = true;
            this.mirrorXCheckbox.CheckedChanged += new System.EventHandler(this.mirrorXCheckbox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Palette : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tile ID : ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(680, 548);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(599, 548);
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
            this.gridcheckBox.Size = new System.Drawing.Size(75, 17);
            this.gridcheckBox.TabIndex = 9;
            this.gridcheckBox.Text = "Show Grid";
            this.gridcheckBox.UseVisualStyleBackColor = true;
            this.gridcheckBox.CheckedChanged += new System.EventHandler(this.gridcheckBox_CheckedChanged);
            // 
            // Tile16Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 578);
            this.Controls.Add(this.gridcheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Tile16Editor";
            this.Text = "Tiles 16 Editor (X2 View)";
            this.Load += new System.EventHandler(this.Tile16Editor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile16)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile8)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paletteUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureboxTile16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureboxTile8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown tileUpDown;
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
    }
}