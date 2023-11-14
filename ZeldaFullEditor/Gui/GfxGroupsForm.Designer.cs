using ZeldaFullEditor.Gui.ExtraForms;

namespace ZeldaFullEditor.Gui
{
    partial class GfxGroupsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GfxGroupsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.mainTab = new System.Windows.Forms.TabPage();
            this.mainGroupbox = new System.Windows.Forms.GroupBox();
            this.main8Box = new Hexbox();
            this.main7Box = new Hexbox();
            this.main6Box = new Hexbox();
            this.main5Box = new Hexbox();
            this.main4Box = new Hexbox();
            this.main3Box = new Hexbox();
            this.main2Box = new Hexbox();
            this.main1Box = new Hexbox();
            this.mainBlocksetUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.roomTab = new System.Windows.Forms.TabPage();
            this.roomGroupbox = new System.Windows.Forms.GroupBox();
            this.room4Box = new Hexbox();
            this.room3Box = new Hexbox();
            this.room2Box = new Hexbox();
            this.room1Box = new Hexbox();
            this.roomUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.spriteTab = new System.Windows.Forms.TabPage();
            this.spritesGroupbox = new System.Windows.Forms.GroupBox();
            this.sprite4Box = new Hexbox();
            this.sprite3Box = new Hexbox();
            this.sprite2Box = new Hexbox();
            this.sprite1Box = new Hexbox();
            this.spriteUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.paletteTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.palette4Box = new Hexbox();
            this.palette3Box = new Hexbox();
            this.palette2Box = new Hexbox();
            this.palette1Box = new Hexbox();
            this.paletteUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.paletteRadioButton = new System.Windows.Forms.RadioButton();
            this.grayscaleRadioButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.mainGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainBlocksetUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.roomTab.SuspendLayout();
            this.roomGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.spriteTab.SuspendLayout();
            this.spritesGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.paletteTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.mainTab);
            this.tabControl1.Controls.Add(this.roomTab);
            this.tabControl1.Controls.Add(this.spriteTab);
            this.tabControl1.Controls.Add(this.paletteTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(382, 288);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.mainGroupbox);
            this.mainTab.Controls.Add(this.mainBlocksetUpDown);
            this.mainTab.Controls.Add(this.label2);
            this.mainTab.Controls.Add(this.label1);
            this.mainTab.Controls.Add(this.pictureBox1);
            this.mainTab.Location = new System.Drawing.Point(4, 22);
            this.mainTab.Name = "mainTab";
            this.mainTab.Padding = new System.Windows.Forms.Padding(3);
            this.mainTab.Size = new System.Drawing.Size(374, 262);
            this.mainTab.TabIndex = 0;
            this.mainTab.Text = "Main";
            this.mainTab.UseVisualStyleBackColor = true;
            // 
            // mainGroupbox
            // 
            this.mainGroupbox.Controls.Add(this.main8Box);
            this.mainGroupbox.Controls.Add(this.main7Box);
            this.mainGroupbox.Controls.Add(this.main6Box);
            this.mainGroupbox.Controls.Add(this.main5Box);
            this.mainGroupbox.Controls.Add(this.main4Box);
            this.mainGroupbox.Controls.Add(this.main3Box);
            this.mainGroupbox.Controls.Add(this.main2Box);
            this.mainGroupbox.Controls.Add(this.main1Box);
            this.mainGroupbox.Location = new System.Drawing.Point(11, 35);
            this.mainGroupbox.Name = "mainGroupbox";
            this.mainGroupbox.Size = new System.Drawing.Size(223, 82);
            this.mainGroupbox.TabIndex = 8;
            this.mainGroupbox.TabStop = false;
            this.mainGroupbox.Text = "Values - 8 subset";
            // 
            // main8Box
            // 
            this.main8Box.Location = new System.Drawing.Point(168, 45);
            this.main8Box.Name = "main8Box";
            this.main8Box.Size = new System.Drawing.Size(48, 20);
            this.main8Box.TabIndex = 7;
            this.main8Box.MaxValue = 223;
            this.main8Box.Digits = Hexbox.HexDigits.Two;
            this.main8Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            // 
            // main7Box
            // 
            this.main7Box.Location = new System.Drawing.Point(114, 45);
            this.main7Box.Name = "main7Box";
            this.main7Box.Size = new System.Drawing.Size(48, 20);
            this.main7Box.MaxValue = 223;
            this.main7Box.TabIndex = 6;
            this.main7Box.Digits = Hexbox.HexDigits.Two;
            this.main7Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            // 
            // main6Box
            // 
            this.main6Box.Location = new System.Drawing.Point(60, 45);
            this.main6Box.Name = "main6Box";
            this.main6Box.Size = new System.Drawing.Size(48, 20);
            this.main6Box.TabIndex = 5;
            this.main6Box.MaxValue = 223;
            this.main6Box.Digits = Hexbox.HexDigits.Two;
            this.main6Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            // 
            // main5Box
            // 
            this.main5Box.Location = new System.Drawing.Point(6, 45);
            this.main5Box.Name = "main5Box";
            this.main5Box.Size = new System.Drawing.Size(48, 20);
            this.main5Box.TabIndex = 4;
            this.main5Box.MaxValue = 223;
            this.main5Box.Digits = Hexbox.HexDigits.Two;
            this.main5Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            // 
            // main4Box
            // 
            this.main4Box.Location = new System.Drawing.Point(168, 19);
            this.main4Box.Name = "main4Box";
            this.main4Box.Size = new System.Drawing.Size(48, 20);
            this.main4Box.TabIndex = 3;
            this.main4Box.MaxValue = 223;
            this.main4Box.Digits = Hexbox.HexDigits.Two;
            this.main4Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            // 
            // main3Box
            // 
            this.main3Box.Location = new System.Drawing.Point(114, 19);
            this.main3Box.Name = "main3Box";
            this.main3Box.Size = new System.Drawing.Size(48, 20);
            this.main3Box.TabIndex = 2;
            this.main3Box.MaxValue = 223;
            this.main3Box.Digits = Hexbox.HexDigits.Two;
            this.main3Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            // 
            // main2Box
            // 
            this.main2Box.Location = new System.Drawing.Point(60, 19);
            this.main2Box.Name = "main2Box";
            this.main2Box.Size = new System.Drawing.Size(48, 20);
            this.main2Box.TabIndex = 1;
            this.main2Box.MaxValue = 223;
            this.main2Box.Digits = Hexbox.HexDigits.Two;
            this.main2Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            // 
            // main1Box
            // 
            this.main1Box.Location = new System.Drawing.Point(6, 19);
            this.main1Box.Name = "main1Box";
            this.main1Box.Size = new System.Drawing.Size(48, 20);
            this.main1Box.TabIndex = 0;
            this.main1Box.MaxValue = 223;
            this.main1Box.Digits = Hexbox.HexDigits.Two;
            this.main1Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            // 
            // mainBlocksetUpDown
            // 
            this.mainBlocksetUpDown.Location = new System.Drawing.Point(116, 9);
            this.mainBlocksetUpDown.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.mainBlocksetUpDown.Name = "mainBlocksetUpDown";
            this.mainBlocksetUpDown.Size = new System.Drawing.Size(118, 20);
            this.mainBlocksetUpDown.TabIndex = 9;
            this.mainBlocksetUpDown.Increment = 0.33m;
            this.mainBlocksetUpDown.ValueChanged += new System.EventHandler(this.blocksetchanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Selected Blockset : ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 39);
            this.label1.TabIndex = 11;
            this.label1.Text = "Main groupset is the gfx set on overworld\r\nand the gfx set in the rooms for dunge" +
    "ons\r\nthey are only reloaded on warp, stairs, hole";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(238, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 256);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.allpreviewPaint);
            // 
            // roomTab
            // 
            this.roomTab.Controls.Add(this.roomGroupbox);
            this.roomTab.Controls.Add(this.roomUpDown);
            this.roomTab.Controls.Add(this.label3);
            this.roomTab.Controls.Add(this.label4);
            this.roomTab.Controls.Add(this.pictureBox2);
            this.roomTab.Location = new System.Drawing.Point(4, 22);
            this.roomTab.Name = "roomTab";
            this.roomTab.Padding = new System.Windows.Forms.Padding(3);
            this.roomTab.Size = new System.Drawing.Size(374, 262);
            this.roomTab.TabIndex = 1;
            this.roomTab.Text = "Rooms";
            this.roomTab.UseVisualStyleBackColor = true;
            // 
            // roomGroupbox
            // 
            this.roomGroupbox.Controls.Add(this.room4Box);
            this.roomGroupbox.Controls.Add(this.room3Box);
            this.roomGroupbox.Controls.Add(this.room2Box);
            this.roomGroupbox.Controls.Add(this.room1Box);
            this.roomGroupbox.Location = new System.Drawing.Point(11, 35);
            this.roomGroupbox.Name = "roomGroupbox";
            this.roomGroupbox.Size = new System.Drawing.Size(223, 50);
            this.roomGroupbox.TabIndex = 10;
            this.roomGroupbox.TabStop = false;
            this.roomGroupbox.Text = "Values - 4 subset (overwrite 4 of main)";
            // 
            // room4Box
            // 
            this.room4Box.Location = new System.Drawing.Point(168, 19);
            this.room4Box.Name = "room4Box";
            this.room4Box.Size = new System.Drawing.Size(48, 20);
            this.room4Box.TabIndex = 7;
            this.room4Box.Click += new System.EventHandler(this.allbox_click);
            this.room4Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            this.room4Box.MaxValue = 223;
            this.room4Box.Digits = Hexbox.HexDigits.Two;
            // 
            // room3Box
            // 
            this.room3Box.Location = new System.Drawing.Point(114, 19);
            this.room3Box.Name = "room3Box";
            this.room3Box.Size = new System.Drawing.Size(48, 20);
            this.room3Box.TabIndex = 6;
            this.room3Box.Click += new System.EventHandler(this.allbox_click);
            this.room3Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            this.room3Box.MaxValue = 223;
            this.room3Box.Digits = Hexbox.HexDigits.Two;
            // 
            // room2Box
            // 
            this.room2Box.Location = new System.Drawing.Point(60, 19);
            this.room2Box.Name = "room2Box";
            this.room2Box.Size = new System.Drawing.Size(48, 20);
            this.room2Box.TabIndex = 5;
            this.room2Box.Click += new System.EventHandler(this.allbox_click);
            this.room2Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            this.room2Box.MaxValue = 223;
            this.room2Box.Digits = Hexbox.HexDigits.Two;
            // 
            // room1Box
            // 
            this.room1Box.Location = new System.Drawing.Point(6, 19);
            this.room1Box.Name = "room1Box";
            this.room1Box.Size = new System.Drawing.Size(48, 20);
            this.room1Box.TabIndex = 4;
            this.room1Box.Click += new System.EventHandler(this.allbox_click);
            this.room1Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            this.room1Box.MaxValue = 223;
            this.room1Box.Digits = Hexbox.HexDigits.Two;
            // 
            // roomUpDown
            // 
            this.roomUpDown.Location = new System.Drawing.Point(116, 9);
            this.roomUpDown.Maximum = new decimal(new int[] {
            81,
            0,
            0,
            0});
            this.roomUpDown.Name = "roomUpDown";
            this.roomUpDown.Size = new System.Drawing.Size(118, 20);
            this.roomUpDown.TabIndex = 9;
            this.roomUpDown.ValueChanged += new System.EventHandler(this.blocksetchanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Selected Blockset : ";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Entrance blockset is the blockset used by entrances\r\nto load walls, and other gfx" +
    " on top of the main gfx\r\n";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(238, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 128);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.allpreviewPaint);
            // 
            // spriteTab
            // 
            this.spriteTab.Controls.Add(this.spritesGroupbox);
            this.spriteTab.Controls.Add(this.spriteUpDown);
            this.spriteTab.Controls.Add(this.label5);
            this.spriteTab.Controls.Add(this.label6);
            this.spriteTab.Controls.Add(this.pictureBox3);
            this.spriteTab.Location = new System.Drawing.Point(4, 22);
            this.spriteTab.Name = "spriteTab";
            this.spriteTab.Size = new System.Drawing.Size(374, 262);
            this.spriteTab.TabIndex = 2;
            this.spriteTab.Text = "Sprites";
            this.spriteTab.UseVisualStyleBackColor = true;
            // 
            // spritesGroupbox
            // 
            this.spritesGroupbox.Controls.Add(this.sprite4Box);
            this.spritesGroupbox.Controls.Add(this.sprite3Box);
            this.spritesGroupbox.Controls.Add(this.sprite2Box);
            this.spritesGroupbox.Controls.Add(this.sprite1Box);
            this.spritesGroupbox.Location = new System.Drawing.Point(11, 35);
            this.spritesGroupbox.Name = "spritesGroupbox";
            this.spritesGroupbox.Size = new System.Drawing.Size(223, 50);
            this.spritesGroupbox.TabIndex = 15;
            this.spritesGroupbox.TabStop = false;
            

            this.spritesGroupbox.Text = "Values - 4 subset";
            // 
            // sprite4Box
            // 
            this.sprite4Box.Location = new System.Drawing.Point(168, 19);
            this.sprite4Box.Name = "sprite4Box";
            this.sprite4Box.Size = new System.Drawing.Size(48, 20);
            this.sprite4Box.TabIndex = 7;
            this.sprite4Box.Click += new System.EventHandler(this.allbox_click);
            this.sprite4Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            this.sprite4Box.MaxValue = 255;
            this.sprite4Box.Digits = Hexbox.HexDigits.Two;
            // 
            // sprite3Box
            // 
            this.sprite3Box.Location = new System.Drawing.Point(114, 19);
            this.sprite3Box.Name = "sprite3Box";
            this.sprite3Box.Size = new System.Drawing.Size(48, 20);
            this.sprite3Box.TabIndex = 6;
            this.sprite3Box.Click += new System.EventHandler(this.allbox_click);
            this.sprite3Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            this.sprite3Box.MaxValue = 255;
            this.sprite3Box.Digits = Hexbox.HexDigits.Two;
            // 
            // sprite2Box
            // 
            this.sprite2Box.Location = new System.Drawing.Point(60, 19);
            this.sprite2Box.Name = "sprite2Box";
            this.sprite2Box.Size = new System.Drawing.Size(48, 20);
            this.sprite2Box.TabIndex = 5;
            this.sprite2Box.Click += new System.EventHandler(this.allbox_click);
            this.sprite2Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            this.sprite2Box.MaxValue = 255;
            this.sprite2Box.Digits = Hexbox.HexDigits.Two;
            // 
            // sprite1Box
            // 
            this.sprite1Box.Location = new System.Drawing.Point(6, 19);
            this.sprite1Box.Name = "sprite1Box";
            this.sprite1Box.Size = new System.Drawing.Size(48, 20);
            this.sprite1Box.TabIndex = 4;
            this.sprite1Box.Click += new System.EventHandler(this.allbox_click);
            this.sprite1Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            this.sprite1Box.MaxValue = 255;
            this.sprite1Box.Digits = Hexbox.HexDigits.Two;
            // 
            // spriteUpDown
            // 
            this.spriteUpDown.Location = new System.Drawing.Point(116, 9);
            this.spriteUpDown.Maximum = new decimal(new int[] {
            143,
            0,
            0,
            0});
            this.spriteUpDown.Name = "spriteUpDown";
            this.spriteUpDown.Size = new System.Drawing.Size(118, 20);
            this.spriteUpDown.TabIndex = 14;
            this.spriteUpDown.Increment = 0.33m;
            this.spriteUpDown.ValueChanged += new System.EventHandler(this.blocksetchanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Selected Blockset : ";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 39);
            this.label6.TabIndex = 12;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Location = new System.Drawing.Point(238, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(128, 128);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.allpreviewPaint);
            // 
            // paletteTab
            // 
            this.paletteTab.Controls.Add(this.groupBox1);
            this.paletteTab.Controls.Add(this.paletteUpDown);
            this.paletteTab.Controls.Add(this.label7);
            this.paletteTab.Controls.Add(this.pictureBox4);
            this.paletteTab.Location = new System.Drawing.Point(4, 22);
            this.paletteTab.Name = "paletteTab";
            this.paletteTab.Size = new System.Drawing.Size(374, 262);
            this.paletteTab.TabIndex = 3;
            this.paletteTab.Text = "Palettes";
            this.paletteTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.palette4Box);
            this.groupBox1.Controls.Add(this.palette3Box);
            this.groupBox1.Controls.Add(this.palette2Box);
            this.groupBox1.Controls.Add(this.palette1Box);
            this.groupBox1.Location = new System.Drawing.Point(11, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 126);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Values - 4 subset";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Dungeon Sprite Pal3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Dungeon Sprite Pal2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Dungeon Sprite Pal1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Dungeon Main";
            // 
            // palette4Box
            // 
            this.palette4Box.Location = new System.Drawing.Point(169, 95);
            this.palette4Box.Name = "palette4Box";
            this.palette4Box.Size = new System.Drawing.Size(48, 20);
            this.palette4Box.TabIndex = 7;
            this.palette4Box.Click += new System.EventHandler(this.allbox_click);
            this.palette4Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            this.palette4Box.MaxValue = 255;
            this.palette4Box.Digits = Hexbox.HexDigits.Two;
            // 
            // palette3Box
            // 
            this.palette3Box.Location = new System.Drawing.Point(169, 69);
            this.palette3Box.Name = "palette3Box";
            this.palette3Box.Size = new System.Drawing.Size(48, 20);
            this.palette3Box.TabIndex = 6;
            this.palette3Box.Click += new System.EventHandler(this.allbox_click);
            this.palette3Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            this.palette3Box.MaxValue = 255;
            this.palette3Box.Digits = Hexbox.HexDigits.Two;
            // 
            // palette2Box
            // 
            this.palette2Box.Location = new System.Drawing.Point(169, 43);
            this.palette2Box.Name = "palette2Box";
            this.palette2Box.Size = new System.Drawing.Size(48, 20);
            this.palette2Box.TabIndex = 5;
            this.palette2Box.Click += new System.EventHandler(this.allbox_click);
            this.palette2Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            this.palette2Box.MaxValue = 255;
            this.palette2Box.Digits = Hexbox.HexDigits.Two;
            // 
            // palette1Box
            // 
            this.palette1Box.Location = new System.Drawing.Point(169, 17);
            this.palette1Box.Name = "palette1Box";
            this.palette1Box.Size = new System.Drawing.Size(48, 20);
            this.palette1Box.TabIndex = 4;
            this.palette1Box.Click += new System.EventHandler(this.allbox_click);
            this.palette1Box.TextChanged += new System.EventHandler(this.allBox_TextChanged);
            this.palette1Box.MaxValue = 255;
            this.palette1Box.Digits = Hexbox.HexDigits.Two;
            // 
            // paletteUpDown
            // 
            this.paletteUpDown.Location = new System.Drawing.Point(116, 9);
            this.paletteUpDown.Maximum = new decimal(new int[] {
            71,
            0,
            0,
            0});
            this.paletteUpDown.Name = "paletteUpDown";
            this.paletteUpDown.Size = new System.Drawing.Size(118, 20);
            this.paletteUpDown.TabIndex = 19;
            this.paletteUpDown.ValueChanged += new System.EventHandler(this.blocksetchanged);
            this.paletteUpDown.Increment = 0.33m;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Selected Paletteset : ";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Location = new System.Drawing.Point(238, 9);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(128, 128);
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Paint += new System.Windows.Forms.PaintEventHandler(this.palettepreviewPaint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.paletteRadioButton);
            this.panel1.Controls.Add(this.grayscaleRadioButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 40);
            this.panel1.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(151, 17);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.blocksetchanged);
            this.numericUpDown1.Increment = 0.33m;
            // 
            // paletteRadioButton
            // 
            this.paletteRadioButton.AutoSize = true;
            this.paletteRadioButton.Location = new System.Drawing.Point(4, 20);
            this.paletteRadioButton.Name = "paletteRadioButton";
            this.paletteRadioButton.Size = new System.Drawing.Size(141, 17);
            this.paletteRadioButton.TabIndex = 3;
            this.paletteRadioButton.Text = "Use Palettes Tab index :";
            this.paletteRadioButton.UseVisualStyleBackColor = true;
            // 
            // grayscaleRadioButton
            // 
            this.grayscaleRadioButton.AutoSize = true;
            this.grayscaleRadioButton.Checked = true;
            this.grayscaleRadioButton.Location = new System.Drawing.Point(4, 3);
            this.grayscaleRadioButton.Name = "grayscaleRadioButton";
            this.grayscaleRadioButton.Size = new System.Drawing.Size(113, 17);
            this.grayscaleRadioButton.TabIndex = 2;
            this.grayscaleRadioButton.TabStop = true;
            this.grayscaleRadioButton.Text = "Grayscale Palettes";
            this.grayscaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(214, 6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Restore";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(295, 6);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Apply";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // GfxGroupsForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Size = new System.Drawing.Size(386, 332);
            this.Text = "Gfx Groups Form";
            this.VisibleChanged += new System.EventHandler(this.GfxGroupsForm_VisibleChanged);
            this.tabControl1.ResumeLayout(false);
            this.mainTab.ResumeLayout(false);
            this.mainTab.PerformLayout();
            this.mainGroupbox.ResumeLayout(false);
            this.mainGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainBlocksetUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.roomTab.ResumeLayout(false);
            this.roomTab.PerformLayout();
            this.roomGroupbox.ResumeLayout(false);
            this.roomGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.spriteTab.ResumeLayout(false);
            this.spriteTab.PerformLayout();
            this.spritesGroupbox.ResumeLayout(false);
            this.spritesGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.paletteTab.ResumeLayout(false);
            this.paletteTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage mainTab;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage roomTab;
        private System.Windows.Forms.TabPage spriteTab;
        private System.Windows.Forms.TabPage paletteTab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown mainBlocksetUpDown;
        private System.Windows.Forms.GroupBox mainGroupbox;
        private Hexbox main8Box;
        private Hexbox main7Box;
        private Hexbox main6Box;
        private Hexbox main5Box;
        private Hexbox main4Box;
        private Hexbox main3Box;
        private Hexbox main2Box;
        private Hexbox main1Box;
        private System.Windows.Forms.GroupBox roomGroupbox;
        private Hexbox room4Box;
        private Hexbox room3Box;
        private Hexbox room2Box;
        private Hexbox room1Box;
        private System.Windows.Forms.NumericUpDown roomUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox spritesGroupbox;
        private Hexbox sprite4Box;
        private Hexbox sprite3Box;
        private Hexbox sprite2Box;
        private Hexbox sprite1Box;
        private System.Windows.Forms.NumericUpDown spriteUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private Hexbox palette4Box;
        private Hexbox palette3Box;
        private Hexbox palette2Box;
        private Hexbox palette1Box;
        private System.Windows.Forms.NumericUpDown paletteUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RadioButton paletteRadioButton;
        private System.Windows.Forms.RadioButton grayscaleRadioButton;
    }
}
