namespace ZeldaFullEditor.Gui
{
    partial class CGRamViewer
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
            this.cgramPicturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cgramPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // cgramPicturebox
            // 
            this.cgramPicturebox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cgramPicturebox.Location = new System.Drawing.Point(0, 0);
            this.cgramPicturebox.Name = "cgramPicturebox";
            this.cgramPicturebox.Size = new System.Drawing.Size(256, 256);
            this.cgramPicturebox.TabIndex = 0;
            this.cgramPicturebox.TabStop = false;
            this.cgramPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.cgramPicturebox_Paint);
            // 
            // CGRamViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 256);
            this.Controls.Add(this.cgramPicturebox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CGRamViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CGRamViewer";
            ((System.ComponentModel.ISupportInitialize)(this.cgramPicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox cgramPicturebox;
    }
}