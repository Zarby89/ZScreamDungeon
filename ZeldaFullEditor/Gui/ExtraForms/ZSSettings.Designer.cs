namespace ZeldaFullEditor.Gui.ExtraForms
{
	partial class ZSSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.emulatorpathTextbox = new System.Windows.Forms.TextBox();
            this.emulatorPathButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Emulator Path :  ( If none is set will use default window application for .sfc fi" +
    "les)";
            // 
            // emulatorpathTextbox
            // 
            this.emulatorpathTextbox.Location = new System.Drawing.Point(15, 25);
            this.emulatorpathTextbox.Name = "emulatorpathTextbox";
            this.emulatorpathTextbox.Size = new System.Drawing.Size(392, 20);
            this.emulatorpathTextbox.TabIndex = 1;
            this.emulatorpathTextbox.TextChanged += new System.EventHandler(this.emulatorpathTextbox_TextChanged);
            // 
            // emulatorPathButton
            // 
            this.emulatorPathButton.Location = new System.Drawing.Point(409, 23);
            this.emulatorPathButton.Name = "emulatorPathButton";
            this.emulatorPathButton.Size = new System.Drawing.Size(29, 23);
            this.emulatorPathButton.TabIndex = 2;
            this.emulatorPathButton.Text = "...";
            this.emulatorPathButton.UseVisualStyleBackColor = true;
            this.emulatorPathButton.Click += new System.EventHandler(this.emulatorPathButton_Click);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(454, 220);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(373, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ZSSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 255);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.emulatorPathButton);
            this.Controls.Add(this.emulatorpathTextbox);
            this.Controls.Add(this.label1);
            this.Name = "ZSSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.ZSSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox emulatorpathTextbox;
		private System.Windows.Forms.Button emulatorPathButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button button1;
	}
}