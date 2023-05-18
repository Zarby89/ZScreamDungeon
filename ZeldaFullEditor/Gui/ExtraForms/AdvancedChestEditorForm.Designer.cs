namespace ZeldaFullEditor.Gui
{
	partial class AdvancedChestEditorForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gfxHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.label10 = new System.Windows.Forms.Label();
            this.paletteHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.widthHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.yHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.valueHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.xHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.addressHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.messageHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.alternateHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(158, 432);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of Chest Items :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 445);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item receipt if duplicate (FF for none)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.gfxHexbox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.paletteHexbox);
            this.groupBox1.Controls.Add(this.widthHexbox);
            this.groupBox1.Controls.Add(this.yHexbox);
            this.groupBox1.Controls.Add(this.valueHexbox);
            this.groupBox1.Controls.Add(this.xHexbox);
            this.groupBox1.Controls.Add(this.addressHexbox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 324);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced settings";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Gfx";
            // 
            // gfxHexbox
            // 
            this.gfxHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gfxHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.gfxHexbox.HexValue = 0;
            this.gfxHexbox.Location = new System.Drawing.Point(7, 266);
            this.gfxHexbox.MaxLength = 2;
            this.gfxHexbox.MaxValue = 255;
            this.gfxHexbox.MinValue = 0;
            this.gfxHexbox.Name = "gfxHexbox";
            this.gfxHexbox.Size = new System.Drawing.Size(86, 20);
            this.gfxHexbox.TabIndex = 25;
            this.gfxHexbox.Text = "00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Palette";
            // 
            // paletteHexbox
            // 
            this.paletteHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.paletteHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.paletteHexbox.HexValue = 0;
            this.paletteHexbox.Location = new System.Drawing.Point(7, 228);
            this.paletteHexbox.MaxLength = 2;
            this.paletteHexbox.MaxValue = 7;
            this.paletteHexbox.MinValue = 0;
            this.paletteHexbox.Name = "paletteHexbox";
            this.paletteHexbox.Size = new System.Drawing.Size(86, 20);
            this.paletteHexbox.TabIndex = 23;
            this.paletteHexbox.Text = "00";
            // 
            // widthHexbox
            // 
            this.widthHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.widthHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.widthHexbox.HexValue = 0;
            this.widthHexbox.Location = new System.Drawing.Point(7, 190);
            this.widthHexbox.MaxLength = 2;
            this.widthHexbox.MaxValue = 2;
            this.widthHexbox.MinValue = 0;
            this.widthHexbox.Name = "widthHexbox";
            this.widthHexbox.Size = new System.Drawing.Size(86, 20);
            this.widthHexbox.TabIndex = 22;
            this.widthHexbox.Text = "00";
            // 
            // yHexbox
            // 
            this.yHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.yHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.yHexbox.HexValue = 0;
            this.yHexbox.Location = new System.Drawing.Point(7, 151);
            this.yHexbox.MaxLength = 2;
            this.yHexbox.MaxValue = 255;
            this.yHexbox.MinValue = 0;
            this.yHexbox.Name = "yHexbox";
            this.yHexbox.Size = new System.Drawing.Size(86, 20);
            this.yHexbox.TabIndex = 21;
            this.yHexbox.Text = "00";
            // 
            // valueHexbox
            // 
            this.valueHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.valueHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.valueHexbox.HexValue = 0;
            this.valueHexbox.Location = new System.Drawing.Point(7, 73);
            this.valueHexbox.MaxLength = 2;
            this.valueHexbox.MaxValue = 255;
            this.valueHexbox.MinValue = 0;
            this.valueHexbox.Name = "valueHexbox";
            this.valueHexbox.Size = new System.Drawing.Size(86, 20);
            this.valueHexbox.TabIndex = 20;
            this.valueHexbox.Text = "00";
            // 
            // xHexbox
            // 
            this.xHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.xHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.xHexbox.HexValue = 0;
            this.xHexbox.Location = new System.Drawing.Point(7, 112);
            this.xHexbox.MaxLength = 2;
            this.xHexbox.MaxValue = 255;
            this.xHexbox.MinValue = 0;
            this.xHexbox.Name = "xHexbox";
            this.xHexbox.Size = new System.Drawing.Size(86, 20);
            this.xHexbox.TabIndex = 19;
            this.xHexbox.Text = "00";
            // 
            // addressHexbox
            // 
            this.addressHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.addressHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Four;
            this.addressHexbox.HexValue = 0;
            this.addressHexbox.Location = new System.Drawing.Point(7, 34);
            this.addressHexbox.MaxLength = 4;
            this.addressHexbox.MaxValue = 65535;
            this.addressHexbox.MinValue = 0;
            this.addressHexbox.Name = "addressHexbox";
            this.addressHexbox.Size = new System.Drawing.Size(86, 20);
            this.addressHexbox.TabIndex = 17;
            this.addressHexbox.Text = "0000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Y offset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "X offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "SRAM value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "SRAM Address";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.messageHexbox);
            this.panel2.Controls.Add(this.alternateHexbox);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(158, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(418, 416);
            this.panel2.TabIndex = 6;
            // 
            // messageHexbox
            // 
            this.messageHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.messageHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Four;
            this.messageHexbox.HexValue = 0;
            this.messageHexbox.Location = new System.Drawing.Point(6, 55);
            this.messageHexbox.MaxLength = 4;
            this.messageHexbox.MaxValue = 65535;
            this.messageHexbox.MinValue = 0;
            this.messageHexbox.Name = "messageHexbox";
            this.messageHexbox.Size = new System.Drawing.Size(86, 20);
            this.messageHexbox.TabIndex = 16;
            this.messageHexbox.Text = "0000";
            // 
            // alternateHexbox
            // 
            this.alternateHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.alternateHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.alternateHexbox.HexValue = 0;
            this.alternateHexbox.Location = new System.Drawing.Point(6, 19);
            this.alternateHexbox.MaxLength = 2;
            this.alternateHexbox.MaxValue = 255;
            this.alternateHexbox.MinValue = 0;
            this.alternateHexbox.Name = "alternateHexbox";
            this.alternateHexbox.Size = new System.Drawing.Size(86, 20);
            this.alternateHexbox.TabIndex = 9;
            this.alternateHexbox.Text = "00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Item Message ID :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(101, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(489, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(408, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // AdvancedChestEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 445);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdvancedChestEditorForm";
            this.Text = "Advanced Chest Editor";
            this.Load += new System.EventHandler(this.AdvancedChestEditorForm_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private ExtraForms.Hexbox alternateHexbox;
		private ExtraForms.Hexbox messageHexbox;
		private System.Windows.Forms.Label label10;
		private ExtraForms.Hexbox paletteHexbox;
		private ExtraForms.Hexbox widthHexbox;
		private ExtraForms.Hexbox yHexbox;
		private ExtraForms.Hexbox valueHexbox;
		private ExtraForms.Hexbox xHexbox;
		private ExtraForms.Hexbox addressHexbox;
		private System.Windows.Forms.Label label11;
		private ExtraForms.Hexbox gfxHexbox;
	}
}
