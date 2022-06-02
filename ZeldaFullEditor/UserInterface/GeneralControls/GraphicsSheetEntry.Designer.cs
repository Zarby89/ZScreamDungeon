namespace ZeldaFullEditor.UserInterface.GeneralControls
{
	partial class GraphicsSheetEntry
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.IDLabel = new System.Windows.Forms.Label();
			this.SheetPreview = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.SheetPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// IDLabel
			// 
			this.IDLabel.AutoSize = true;
			this.IDLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.IDLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.IDLabel.Location = new System.Drawing.Point(0, 0);
			this.IDLabel.Name = "IDLabel";
			this.IDLabel.Size = new System.Drawing.Size(30, 22);
			this.IDLabel.TabIndex = 0;
			this.IDLabel.Text = "00";
			// 
			// SheetPreview
			// 
			this.SheetPreview.BackgroundImage = global::ZeldaFullEditor.Properties.Resources.trans;
			this.SheetPreview.Location = new System.Drawing.Point(37, 0);
			this.SheetPreview.MaximumSize = new System.Drawing.Size(256, 64);
			this.SheetPreview.MinimumSize = new System.Drawing.Size(256, 64);
			this.SheetPreview.Name = "SheetPreview";
			this.SheetPreview.Size = new System.Drawing.Size(256, 64);
			this.SheetPreview.TabIndex = 1;
			this.SheetPreview.TabStop = false;
			this.SheetPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.SheetPreview_Paint);
			this.SheetPreview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AllMouseClick);
			// 
			// GraphicsSheetEntry
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.SheetPreview);
			this.Controls.Add(this.IDLabel);
			this.Name = "GraphicsSheetEntry";
			this.Size = new System.Drawing.Size(293, 72);
			((System.ComponentModel.ISupportInitialize)(this.SheetPreview)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label IDLabel;
		private PictureBox SheetPreview;
	}
}
