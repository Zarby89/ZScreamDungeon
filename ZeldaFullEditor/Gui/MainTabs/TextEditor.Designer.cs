namespace ZeldaFullEditor
{
    partial class TextEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEditor));
			this.panel1 = new System.Windows.Forms.Panel();
			this.textListbox = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.searchTextbox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TextCommandList = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.ParamsBox = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.SpecialsList = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.upButton = new System.Windows.Forms.Button();
			this.downButton = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.SelectedTileID = new System.Windows.Forms.Label();
			this.SelectedTileASCII = new System.Windows.Forms.Label();
			this.MessageAddress = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.BytesDDD = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.textListbox);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.searchTextbox);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Enabled = false;
			this.panel1.Location = new System.Drawing.Point(3, 29);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(433, 714);
			this.panel1.TabIndex = 22;
			// 
			// textListbox
			// 
			this.textListbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textListbox.FormattingEnabled = true;
			this.textListbox.Location = new System.Drawing.Point(0, 46);
			this.textListbox.Name = "textListbox";
			this.textListbox.Size = new System.Drawing.Size(433, 668);
			this.textListbox.TabIndex = 1;
			this.textListbox.SelectedIndexChanged += new System.EventHandler(this.textListbox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Available dialogs";
			// 
			// searchTextbox
			// 
			this.searchTextbox.Dock = System.Windows.Forms.DockStyle.Top;
			this.searchTextbox.Location = new System.Drawing.Point(0, 13);
			this.searchTextbox.Name = "searchTextbox";
			this.searchTextbox.Size = new System.Drawing.Size(433, 20);
			this.searchTextbox.TabIndex = 9;
			this.searchTextbox.TextChanged += new System.EventHandler(this.searchTextbox_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Location = new System.Drawing.Point(0, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Search for text";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.BytesDDD);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.MessageAddress);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.label10);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.TextCommandList);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.textBox1);
			this.panel2.Controls.Add(this.ParamsBox);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Controls.Add(this.button5);
			this.panel2.Controls.Add(this.button6);
			this.panel2.Controls.Add(this.SpecialsList);
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Controls.Add(this.button4);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.upButton);
			this.panel2.Controls.Add(this.downButton);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.pictureBox2);
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Location = new System.Drawing.Point(442, 28);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(520, 715);
			this.panel2.TabIndex = 23;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(247, 1);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(45, 13);
			this.label9.TabIndex = 22;
			this.label9.Text = "Address";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(375, 1);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(82, 13);
			this.label10.TabIndex = 24;
			this.label10.Text = "Text commands";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Message contents";
			// 
			// TextCommandList
			// 
			this.TextCommandList.FormattingEnabled = true;
			this.TextCommandList.Location = new System.Drawing.Point(381, 17);
			this.TextCommandList.Name = "TextCommandList";
			this.TextCommandList.Size = new System.Drawing.Size(134, 134);
			this.TextCommandList.TabIndex = 25;
			this.TextCommandList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			this.TextCommandList.DoubleClick += new System.EventHandler(this.InsertCommandButton_Click_1);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 177);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Preview";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(6, 17);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(340, 152);
			this.textBox1.TabIndex = 20;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// ParamsBox
			// 
			this.ParamsBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.ParamsBox.Location = new System.Drawing.Point(487, 153);
			this.ParamsBox.MaxLength = 2;
			this.ParamsBox.Name = "ParamsBox";
			this.ParamsBox.Size = new System.Drawing.Size(26, 20);
			this.ParamsBox.TabIndex = 26;
			this.ParamsBox.Text = "00";
			this.ParamsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ParamsBox.TextChanged += new System.EventHandler(this.ParamsBox_TextChanged);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(378, 183);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(118, 13);
			this.label12.TabIndex = 30;
			this.label12.Text = "Hard-to-type characters";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(411, 648);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 23);
			this.button5.TabIndex = 17;
			this.button5.Text = "Save VWF font";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(411, 619);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 23);
			this.button6.TabIndex = 4;
			this.button6.Text = "Auto width";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// SpecialsList
			// 
			this.SpecialsList.FormattingEnabled = true;
			this.SpecialsList.Location = new System.Drawing.Point(378, 199);
			this.SpecialsList.Name = "SpecialsList";
			this.SpecialsList.Size = new System.Drawing.Size(137, 186);
			this.SpecialsList.TabIndex = 29;
			this.SpecialsList.DoubleClick += new System.EventHandler(this.InsertSpecialButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.SelectedTileASCII);
			this.groupBox1.Controls.Add(this.SelectedTileID);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(265, 407);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(137, 99);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Selected tile";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(78, 71);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(53, 20);
			this.numericUpDown1.TabIndex = 3;
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(5, 73);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "Width";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 29);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(37, 13);
			this.label7.TabIndex = 1;
			this.label7.Text = "ASCII:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(21, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "ID:";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(408, 447);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(105, 28);
			this.button4.TabIndex = 21;
			this.button4.Text = "Dictionary entries";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(265, 619);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(140, 23);
			this.button3.TabIndex = 16;
			this.button3.Text = "Import GFX+Width (2BPP)";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(265, 648);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(140, 23);
			this.button2.TabIndex = 15;
			this.button2.Text = "Export GFX+Width (2BPP)";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// upButton
			// 
			this.upButton.Enabled = false;
			this.upButton.Location = new System.Drawing.Point(349, 193);
			this.upButton.Name = "upButton";
			this.upButton.Size = new System.Drawing.Size(23, 23);
			this.upButton.TabIndex = 12;
			this.upButton.Text = "🡅";
			this.upButton.UseVisualStyleBackColor = true;
			this.upButton.Click += new System.EventHandler(this.upButton_Click);
			// 
			// downButton
			// 
			this.downButton.Enabled = false;
			this.downButton.Location = new System.Drawing.Point(349, 362);
			this.downButton.Name = "downButton";
			this.downButton.Size = new System.Drawing.Size(23, 23);
			this.downButton.TabIndex = 13;
			this.downButton.Text = "🡇";
			this.downButton.UseVisualStyleBackColor = true;
			this.downButton.Click += new System.EventHandler(this.downButton_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 397);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Font graphics";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(3, 413);
			this.pictureBox2.MinimumSize = new System.Drawing.Size(256, 244);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(256, 258);
			this.pictureBox2.TabIndex = 11;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
			this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pictureBox1.Location = new System.Drawing.Point(6, 193);
			this.pictureBox1.MaximumSize = new System.Drawing.Size(340, 192);
			this.pictureBox1.MinimumSize = new System.Drawing.Size(0, 96);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(340, 192);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(981, 25);
			this.toolStrip1.TabIndex = 24;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "Export text";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "Import text";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// SelectedTileID
			// 
			this.SelectedTileID.AutoSize = true;
			this.SelectedTileID.Location = new System.Drawing.Point(57, 16);
			this.SelectedTileID.Name = "SelectedTileID";
			this.SelectedTileID.Size = new System.Drawing.Size(0, 13);
			this.SelectedTileID.TabIndex = 4;
			// 
			// SelectedTileASCII
			// 
			this.SelectedTileASCII.AutoSize = true;
			this.SelectedTileASCII.Location = new System.Drawing.Point(57, 29);
			this.SelectedTileASCII.Name = "SelectedTileASCII";
			this.SelectedTileASCII.Size = new System.Drawing.Size(0, 13);
			this.SelectedTileASCII.TabIndex = 5;
			// 
			// MessageAddress
			// 
			this.MessageAddress.AutoSize = true;
			this.MessageAddress.Location = new System.Drawing.Point(305, 1);
			this.MessageAddress.Name = "MessageAddress";
			this.MessageAddress.Size = new System.Drawing.Size(0, 13);
			this.MessageAddress.TabIndex = 31;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(395, 156);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(86, 13);
			this.label11.TabIndex = 32;
			this.label11.Text = "Parameter (HEX)";
			// 
			// BytesDDD
			// 
			this.BytesDDD.Location = new System.Drawing.Point(408, 413);
			this.BytesDDD.Name = "BytesDDD";
			this.BytesDDD.Size = new System.Drawing.Size(105, 28);
			this.BytesDDD.TabIndex = 33;
			this.BytesDDD.Text = "Show text data";
			this.BytesDDD.UseVisualStyleBackColor = true;
			this.BytesDDD.Click += new System.EventHandler(this.BytesDDD_Click);
			// 
			// TextEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Name = "TextEditor";
			this.Size = new System.Drawing.Size(981, 758);
			this.Load += new System.EventHandler(this.TextEditor_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        public System.Windows.Forms.ListBox textListbox;
        public System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ListBox TextCommandList;
		private System.Windows.Forms.TextBox ParamsBox;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ListBox SpecialsList;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label SelectedTileASCII;
		private System.Windows.Forms.Label SelectedTileID;
		private System.Windows.Forms.Label MessageAddress;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button BytesDDD;
	}
}
