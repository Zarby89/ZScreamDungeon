namespace ZeldaFullEditor.Gui.TextEditorExtra {
	partial class MessageAsBytes {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.PrefixChoose = new System.Windows.Forms.ComboBox();
			this.SeparatorChoose = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SizeOfMessage = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(2, 26);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(471, 226);
			this.textBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 264);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Prefix";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(220, 264);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Separator";
			// 
			// PrefixChoose
			// 
			this.PrefixChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PrefixChoose.FormattingEnabled = true;
			this.PrefixChoose.Items.AddRange(new object[] {
            "None",
            "0x",
            "$"});
			this.PrefixChoose.Location = new System.Drawing.Point(71, 261);
			this.PrefixChoose.Name = "PrefixChoose";
			this.PrefixChoose.Size = new System.Drawing.Size(121, 21);
			this.PrefixChoose.TabIndex = 3;
			this.PrefixChoose.SelectedIndexChanged += new System.EventHandler(this.PrefixChoose_SelectedIndexChanged);
			// 
			// SeparatorChoose
			// 
			this.SeparatorChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SeparatorChoose.FormattingEnabled = true;
			this.SeparatorChoose.Items.AddRange(new object[] {
            "None",
            "Space",
            "Comma"});
			this.SeparatorChoose.Location = new System.Drawing.Point(279, 261);
			this.SeparatorChoose.Name = "SeparatorChoose";
			this.SeparatorChoose.Size = new System.Drawing.Size(121, 21);
			this.SeparatorChoose.TabIndex = 4;
			this.SeparatorChoose.SelectedIndexChanged += new System.EventHandler(this.SeparatorChoose_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Message size:";
			// 
			// SizeOfMessage
			// 
			this.SizeOfMessage.AutoSize = true;
			this.SizeOfMessage.Location = new System.Drawing.Point(92, 10);
			this.SizeOfMessage.Name = "SizeOfMessage";
			this.SizeOfMessage.Size = new System.Drawing.Size(0, 13);
			this.SizeOfMessage.TabIndex = 6;
			// 
			// MessageAsBytes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(475, 290);
			this.Controls.Add(this.SizeOfMessage);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SeparatorChoose);
			this.Controls.Add(this.PrefixChoose);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MessageAsBytes";
			this.Text = "Message Data Output";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox PrefixChoose;
		private System.Windows.Forms.ComboBox SeparatorChoose;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label SizeOfMessage;
	}
}