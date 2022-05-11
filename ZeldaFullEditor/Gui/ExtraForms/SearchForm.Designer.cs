namespace ZeldaFullEditor.Gui
{
	partial class SearchForm
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.chestRadio = new System.Windows.Forms.RadioButton();
			this.itemRadio = new System.Windows.Forms.RadioButton();
			this.spriteRadio = new System.Windows.Forms.RadioButton();
			this.tileRadio = new System.Windows.Forms.RadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Location = new System.Drawing.Point(3, 296);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(508, 173);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			this.richTextBox1.WordWrap = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.chestRadio);
			this.panel1.Controls.Add(this.itemRadio);
			this.panel1.Controls.Add(this.spriteRadio);
			this.panel1.Controls.Add(this.tileRadio);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.richTextBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(514, 472);
			this.panel1.TabIndex = 1;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(15, 52);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(487, 21);
			this.comboBox1.TabIndex = 13;
			// 
			// chestRadio
			// 
			this.chestRadio.AutoSize = true;
			this.chestRadio.Location = new System.Drawing.Point(206, 29);
			this.chestRadio.Name = "chestRadio";
			this.chestRadio.Size = new System.Drawing.Size(75, 17);
			this.chestRadio.TabIndex = 12;
			this.chestRadio.TabStop = true;
			this.chestRadio.Text = "Chest Item";
			this.chestRadio.UseVisualStyleBackColor = true;
			this.chestRadio.CheckedChanged += new System.EventHandler(this.tileRadio_CheckedChanged);
			// 
			// itemRadio
			// 
			this.itemRadio.AutoSize = true;
			this.itemRadio.Location = new System.Drawing.Point(155, 29);
			this.itemRadio.Name = "itemRadio";
			this.itemRadio.Size = new System.Drawing.Size(63, 17);
			this.itemRadio.TabIndex = 11;
			this.itemRadio.TabStop = true;
			this.itemRadio.Text = "Pot item";
			this.itemRadio.UseVisualStyleBackColor = true;
			this.itemRadio.CheckedChanged += new System.EventHandler(this.tileRadio_CheckedChanged);
			// 
			// spriteRadio
			// 
			this.spriteRadio.AutoSize = true;
			this.spriteRadio.Location = new System.Drawing.Point(97, 29);
			this.spriteRadio.Name = "spriteRadio";
			this.spriteRadio.Size = new System.Drawing.Size(52, 17);
			this.spriteRadio.TabIndex = 10;
			this.spriteRadio.TabStop = true;
			this.spriteRadio.Text = "Sprite";
			this.spriteRadio.UseVisualStyleBackColor = true;
			this.spriteRadio.CheckedChanged += new System.EventHandler(this.tileRadio_CheckedChanged);
			// 
			// tileRadio
			// 
			this.tileRadio.AutoSize = true;
			this.tileRadio.Location = new System.Drawing.Point(15, 29);
			this.tileRadio.Name = "tileRadio";
			this.tileRadio.Size = new System.Drawing.Size(56, 17);
			this.tileRadio.TabIndex = 9;
			this.tileRadio.TabStop = true;
			this.tileRadio.Text = "Object";
			this.tileRadio.UseVisualStyleBackColor = true;
			this.tileRadio.CheckedChanged += new System.EventHandler(this.tileRadio_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(427, 79);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Search";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Search rooms for";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 277);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Logs";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(427, 267);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Clear logs";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// SearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 472);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Name = "SearchForm";
			this.Text = "Dungeon Entity Search";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.RadioButton chestRadio;
		private System.Windows.Forms.RadioButton itemRadio;
		private System.Windows.Forms.RadioButton spriteRadio;
		private System.Windows.Forms.RadioButton tileRadio;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
	}
}
