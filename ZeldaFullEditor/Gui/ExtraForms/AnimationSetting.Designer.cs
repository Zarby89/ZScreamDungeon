namespace ZeldaFullEditor.Gui.ExtraForms
{
    partial class AnimationSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimationSetting));
            this.label1 = new System.Windows.Forms.Label();
            this.numberframeHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportzsaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importzsaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateASMInClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.framesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTimerOfAllFramesToValueOfFrame00ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.screenshakeCheckbox = new System.Windows.Forms.CheckBox();
            this.sfx1Combobox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sfx2Combobox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sfx3Combobox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.waitHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.persistCheckbox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of frames to export (up to 255)";
            // 
            // numberframeHexbox
            // 
            this.numberframeHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numberframeHexbox.Decimal = true;
            this.numberframeHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Three;
            this.numberframeHexbox.HexValue = 0;
            this.numberframeHexbox.Location = new System.Drawing.Point(181, 54);
            this.numberframeHexbox.MaxLength = 3;
            this.numberframeHexbox.MaxValue = 255;
            this.numberframeHexbox.MinValue = 0;
            this.numberframeHexbox.Name = "numberframeHexbox";
            this.numberframeHexbox.Size = new System.Drawing.Size(52, 20);
            this.numberframeHexbox.TabIndex = 1;
            this.numberframeHexbox.Text = "0";
            this.numberframeHexbox.TextChanged += new System.EventHandler(this.numberframeHexbox_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(160, 394);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "List of animation frames";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.framesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(563, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportzsaToolStripMenuItem,
            this.importzsaToolStripMenuItem,
            this.generateASMInClipboardToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportzsaToolStripMenuItem
            // 
            this.exportzsaToolStripMenuItem.Name = "exportzsaToolStripMenuItem";
            this.exportzsaToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.exportzsaToolStripMenuItem.Text = "Export .zsa";
            this.exportzsaToolStripMenuItem.Click += new System.EventHandler(this.exportzsaToolStripMenuItem_Click);
            // 
            // importzsaToolStripMenuItem
            // 
            this.importzsaToolStripMenuItem.Name = "importzsaToolStripMenuItem";
            this.importzsaToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.importzsaToolStripMenuItem.Text = "Import .zsa";
            this.importzsaToolStripMenuItem.Click += new System.EventHandler(this.importzsaToolStripMenuItem_Click);
            // 
            // generateASMInClipboardToolStripMenuItem
            // 
            this.generateASMInClipboardToolStripMenuItem.Name = "generateASMInClipboardToolStripMenuItem";
            this.generateASMInClipboardToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.generateASMInClipboardToolStripMenuItem.Text = "Generate ASM in clipboard";
            this.generateASMInClipboardToolStripMenuItem.Click += new System.EventHandler(this.generateASMInClipboardToolStripMenuItem_Click);
            // 
            // framesToolStripMenuItem
            // 
            this.framesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setTimerOfAllFramesToValueOfFrame00ToolStripMenuItem});
            this.framesToolStripMenuItem.Name = "framesToolStripMenuItem";
            this.framesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.framesToolStripMenuItem.Text = "Frames";
            // 
            // setTimerOfAllFramesToValueOfFrame00ToolStripMenuItem
            // 
            this.setTimerOfAllFramesToValueOfFrame00ToolStripMenuItem.Name = "setTimerOfAllFramesToValueOfFrame00ToolStripMenuItem";
            this.setTimerOfAllFramesToValueOfFrame00ToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.setTimerOfAllFramesToValueOfFrame00ToolStripMenuItem.Text = "Set timer of all frames to value of frame00";
            this.setTimerOfAllFramesToValueOfFrame00ToolStripMenuItem.Click += new System.EventHandler(this.setTimerOfAllFramesToValueOfFrame00ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.screenshakeCheckbox);
            this.groupBox1.Controls.Add(this.sfx1Combobox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.sfx2Combobox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.sfx3Combobox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.waitHexbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(181, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 333);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frame step infos";
            // 
            // screenshakeCheckbox
            // 
            this.screenshakeCheckbox.AutoSize = true;
            this.screenshakeCheckbox.Location = new System.Drawing.Point(9, 139);
            this.screenshakeCheckbox.Name = "screenshakeCheckbox";
            this.screenshakeCheckbox.Size = new System.Drawing.Size(180, 17);
            this.screenshakeCheckbox.TabIndex = 10;
            this.screenshakeCheckbox.Text = "Screen shake during that frame?";
            this.screenshakeCheckbox.UseVisualStyleBackColor = true;
            this.screenshakeCheckbox.CheckedChanged += new System.EventHandler(this.screenshakeCheckbox_CheckedChanged);
            // 
            // sfx1Combobox
            // 
            this.sfx1Combobox.FormattingEnabled = true;
            this.sfx1Combobox.Items.AddRange(new object[] {
            "00 NO SFX",
            "01 Rain / Zora area",
            "02 Rain / Zora area (packaged with $01)",
            "03 Rain",
            "04 Rain (packaged with $03)",
            "05 Silence",
            "06 Silence (packaged with $05)",
            "07 The Rumbling",
            "08 The Rumbling (packaged with $08)",
            "09 Wind",
            "0A Wind (packaged with $09 by APU)",
            "0B Flute song by flute boy",
            "0C Flute song by flute boy (packaged with $0B)",
            "0D Magic jingle",
            "0E Magic jingle (packaged with $0D)",
            "0F Crystal / Save and quit",
            "10 Crystal / Save and quit (packaged with $0F)",
            "11 Choir melody",
            "12 Choir countermelody (packaged with $11)",
            "13 Large boss swoosh",
            "14 Large boss swoosh (packaged with $13)",
            "15 Triforce door / Pyramid hole opening",
            "16 VOMP (packaged with $15)",
            "17 Flute song for weathervane",
            "18 Flute song for weathervane (packaged with $17)",
            "19 Nothing (unused)",
            "1A Nothing (unused; packaged with $19)",
            "1B Flute song by flute boy duplicate (unused)",
            "1C Flute song by flute boy duplicate (unused; packaged with $1B)",
            "1D Magic jingle duplicate (unused)",
            "1E Magic jingle duplicate (unused; packaged with $1D)",
            "1F Crystal / Save and quit duplicate (unused)",
            "20 Crystal / Save and quit duplicate (unused; packaged with $1F)"});
            this.sfx1Combobox.Location = new System.Drawing.Point(108, 59);
            this.sfx1Combobox.Name = "sfx1Combobox";
            this.sfx1Combobox.Size = new System.Drawing.Size(235, 21);
            this.sfx1Combobox.TabIndex = 9;
            this.sfx1Combobox.SelectedIndexChanged += new System.EventHandler(this.sfx1Combobox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "- Play SFX ($012D)";
            // 
            // sfx2Combobox
            // 
            this.sfx2Combobox.FormattingEnabled = true;
            this.sfx2Combobox.Items.AddRange(new object[] {
            "00 NO SFX",
            "01 Slash",
            "02 Slash",
            "03 Slash",
            "04 Slash",
            "05 Clink",
            "06 Bombable door clink",
            "07 Fwoosh",
            "08 Arrow smash",
            "09 Boomerang fwish",
            "0A Hookshot clink",
            "0B Placing bomb",
            "0C Explosion",
            "0D Powder (paired $0D→$3F)",
            "0E Fire rod shot",
            "0F Ice rod shot",
            "10 Hammer use",
            "11 Hammering peg",
            "12 Digging",
            "13 Flute (paired $13→$3E)",
            "14 Cape on",
            "15 Cape off / Wallmaster grab",
            "16 Staircase",
            "17 Staircase",
            "18 Staircase",
            "19 Staircase",
            "1A Tall grass / Hammer hitting bush",
            "1B Shallow water",
            "1C Mire shallow water",
            "1D Lifting object",
            "1E Cutting grass",
            "1F Item breaking",
            "20 Item falling in pit",
            "21 Bomb hitting ground / General thud",
            "22 Pushing object / Armos bounce",
            "23 Boots dust",
            "24 Splashing (paired $24→$3D)",
            "25 Mire shallow water again?",
            "26 Link taking damage",
            "27 Fainting",
            "28 Item splash",
            "29 Rupee refill (paired $29→$3B)",
            "2A Fire splash / Bombos spell",
            "2B Heart beep / Text box",
            "2C Sword up (paired $2C→$3A) (also uses instrument $17)",
            "2D Magic drain",
            "2E GT opening (paired $2E→$39)",
            "2F GT opening / Water drain (paired $2F→$38)",
            "30 Cucco",
            "31 Fairy",
            "32 Bug net",
            "33 Teleport (paired $34→$33)",
            "34 Teleport (paired $34→$33)",
            "35 Shaking",
            "36 Mire entrance (extends above; paired $35→$36)",
            "37 Spin charged",
            "38 Water sound (paired $2F→$38)",
            "39 Thunder (paired $2E→$39)",
            "3A Sword up (paired $2C→$3A)",
            "3B Rupee refill (paired $29→$3B)",
            "3C Error beep",
            "3D Big splash (paired $24→$3D)",
            "3E Flute (paired $13→$3E)",
            "3F Powder (paired $0D→$3F)"});
            this.sfx2Combobox.Location = new System.Drawing.Point(108, 83);
            this.sfx2Combobox.Name = "sfx2Combobox";
            this.sfx2Combobox.Size = new System.Drawing.Size(235, 21);
            this.sfx2Combobox.TabIndex = 7;
            this.sfx2Combobox.SelectedIndexChanged += new System.EventHandler(this.sfx2Combobox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "- Play SFX ($012E)";
            // 
            // sfx3Combobox
            // 
            this.sfx3Combobox.FormattingEnabled = true;
            this.sfx3Combobox.Items.AddRange(new object[] {
            "00 NO SFX",
            "01 Sword beam",
            "02 TR opening",
            "03 Pyramid hole",
            "04 Angry soldier",
            "05 Lynel shot / Javelin toss",
            "06 Swoosh",
            "07 Cannon fire",
            "08 Damage to enemy; $0BEX.4=1",
            "09 Enemy death",
            "0A Collecting rupee",
            "0B Collecting heart",
            "0C Non-blank text character",
            "0D HUD heart",
            "0E Opening chest",
            "0F ♪Do do do doooooo♫ (paired $0F→$3C→$3D→$3E→$3F)",
            "10 Map (paired $10→$3B)",
            "11 Opening item menu / Bomb shop guy breathing",
            "12 Closing item menu / Bomb shop guy breathing",
            "13 Throwing object / Stalfos jump",
            "14 Key door",
            "15 Door / Chest (used with SFX2.29)",
            "16 Armos Knight thud",
            "17 Rat squeak",
            "18 Dragging",
            "19 Fireball / Laser shot",
            "1A Chest reveal jingle (paired $1A→$38)",
            "1B Puzzle jingle (paired $1B→$3A)",
            "1C Damage to enemy",
            "1D Magic meter",
            "1E Wing flapping",
            "1F Link falling",
            "20 Menu / Text cursor moved",
            "21 Damage to boss",
            "22 Boss dying / Deleting file",
            "23 Spin attack swoosh (paired $23→$39)",
            "24 OW map perspective change",
            "25 Pressure switch (also uses instrument $06)",
            "26 Lightning / Game over / Laser / Ganon bat / Trinexx lunge",
            "27 Agahnim charge",
            "28 Agahnim / Ganon teleport",
            "29 Agahnim shot",
            "2A Somaria / Byrna / Ether spell / Helma fire ball",
            "2B Electrocution",
            "2C Bees",
            "2D Milestone jingle (paired $2D→$37)",
            "2E Heart container jingle (paired $2E→$35→$34)",
            "2F Key jingle (paired $2F→$33)",
            "30 Magic zap / Plop",
            "31 Sprite falling / Moldorm shuffle",
            "32 BOING",
            "33 Key jingle (paired $2F→$33)",
            "34 Heart container jingle (paired $2E→$35→$34)",
            "35 Heart container jingle (paired $2E→$35→$34)",
            "36 Magic attack",
            "37 Milestone jingle (paired $2D→$37)",
            "38 Chest reveal jingle (paired $1A→$38)",
            "39 Swish (paired $23→$39)",
            "3A Puzzle jingle (paired $1B→$3A)",
            "3B Map (paired $10→$3B)",
            "3C Item jingle (paired $0F→$3C→$3D→$3E→$3F)",
            "3D Item jingle ($0F→$3C→$3D→$3E→$3F)",
            "3E Item jingle (paired $0F→$3C→$3D→$3E→$3F)",
            "3F Item jingle (paired $0F→$3C→$3D→$3E→$3F)"});
            this.sfx3Combobox.Location = new System.Drawing.Point(108, 108);
            this.sfx3Combobox.Name = "sfx3Combobox";
            this.sfx3Combobox.Size = new System.Drawing.Size(235, 21);
            this.sfx3Combobox.TabIndex = 5;
            this.sfx3Combobox.SelectedIndexChanged += new System.EventHandler(this.sfx3Combobox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "- Play SFX ($012F)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Game frames before next animation frame (60 = 1sec)";
            // 
            // waitHexbox
            // 
            this.waitHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.waitHexbox.Decimal = true;
            this.waitHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Three;
            this.waitHexbox.HexValue = 0;
            this.waitHexbox.Location = new System.Drawing.Point(47, 35);
            this.waitHexbox.MaxLength = 3;
            this.waitHexbox.MaxValue = 255;
            this.waitHexbox.MinValue = 0;
            this.waitHexbox.Name = "waitHexbox";
            this.waitHexbox.Size = new System.Drawing.Size(36, 20);
            this.waitHexbox.TabIndex = 2;
            this.waitHexbox.Text = "0";
            this.waitHexbox.TextChanged += new System.EventHandler(this.waitHexbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "- Wait";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "- Draw this frame tiles";
            // 
            // persistCheckbox
            // 
            this.persistCheckbox.AutoSize = true;
            this.persistCheckbox.Location = new System.Drawing.Point(181, 418);
            this.persistCheckbox.Name = "persistCheckbox";
            this.persistCheckbox.Size = new System.Drawing.Size(335, 17);
            this.persistCheckbox.TabIndex = 6;
            this.persistCheckbox.Text = "Persist (set the overlay bit) so the overlay is displayed on transition";
            this.persistCheckbox.UseVisualStyleBackColor = true;
            this.persistCheckbox.CheckedChanged += new System.EventHandler(this.persistCheckbox_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 438);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(530, 26);
            this.label9.TabIndex = 7;
            this.label9.Text = resources.GetString("label9.Text");
            // 
            // AnimationSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 479);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.persistCheckbox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.numberframeHexbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnimationSetting";
            this.Text = "Animation Setting";
            this.Load += new System.EventHandler(this.AnimationSetting_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Hexbox numberframeHexbox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportzsaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importzsaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateASMInClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem framesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setTimerOfAllFramesToValueOfFrame00ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private Hexbox waitHexbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox sfx3Combobox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox sfx1Combobox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox sfx2Combobox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox screenshakeCheckbox;
        private System.Windows.Forms.CheckBox persistCheckbox;
        private System.Windows.Forms.Label label9;
    }
}