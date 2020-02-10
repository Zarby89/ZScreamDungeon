namespace ZeldaFullEditor
{
    partial class VramViewer
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
            this.vramPicturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.vramPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // vramPicturebox
            // 
            this.vramPicturebox.Location = new System.Drawing.Point(0, 0);
            this.vramPicturebox.Name = "vramPicturebox";
            this.vramPicturebox.Size = new System.Drawing.Size(256, 1024);
            this.vramPicturebox.TabIndex = 0;
            this.vramPicturebox.TabStop = false;
            this.vramPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.vramPicturebox_Paint);
            // 
            // VramViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(273, 511);
            this.Controls.Add(this.vramPicturebox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VramViewer";
            this.Text = "VramViewer";
            ((System.ComponentModel.ISupportInitialize)(this.vramPicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox vramPicturebox;
    }
}