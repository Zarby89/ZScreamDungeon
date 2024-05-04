namespace ZeldaFullEditor.Gui.MainTabs
{
	partial class MusicEditor
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
            this.songListbox = new System.Windows.Forms.ListBox();
            this.songLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hexPicturebox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hexPicturebox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // songListbox
            // 
            this.songListbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.songListbox.FormattingEnabled = true;
            this.songListbox.Location = new System.Drawing.Point(0, 13);
            this.songListbox.Name = "songListbox";
            this.songListbox.Size = new System.Drawing.Size(197, 695);
            this.songListbox.TabIndex = 0;
            this.songListbox.SelectedIndexChanged += new System.EventHandler(this.songListbox_SelectedIndexChanged);
            // 
            // songLabel
            // 
            this.songLabel.AutoSize = true;
            this.songLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.songLabel.Location = new System.Drawing.Point(0, 0);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(46, 13);
            this.songLabel.TabIndex = 1;
            this.songLabel.Text = "Songs : ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.songListbox);
            this.panel1.Controls.Add(this.songLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 708);
            this.panel1.TabIndex = 2;
            // 
            // hexPicturebox
            // 
            this.hexPicturebox.Location = new System.Drawing.Point(3, 3);
            this.hexPicturebox.Name = "hexPicturebox";
            this.hexPicturebox.Size = new System.Drawing.Size(336, 512);
            this.hexPicturebox.TabIndex = 3;
            this.hexPicturebox.TabStop = false;
            this.hexPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.hexPicturebox_Paint);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.hexPicturebox);
            this.panel2.Location = new System.Drawing.Point(206, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 516);
            this.panel2.TabIndex = 4;
            // 
            // MusicEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MusicEditor";
            this.Size = new System.Drawing.Size(1420, 708);
            this.Load += new System.EventHandler(this.MusicEditor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hexPicturebox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox songListbox;
		private System.Windows.Forms.Label songLabel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox hexPicturebox;
		private System.Windows.Forms.Panel panel2;
	}
}
