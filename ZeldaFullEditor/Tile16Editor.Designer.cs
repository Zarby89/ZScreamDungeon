namespace ZeldaFullEditor
{
    partial class Tile16Editor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureboxTile8 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureboxTile16 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tile8Textbox = new System.Windows.Forms.TextBox();
            this.mirrorXCheckbox = new System.Windows.Forms.CheckBox();
            this.mirrorYCheckbox = new System.Windows.Forms.CheckBox();
            this.infrontCheckbox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.paletteTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile8)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile16)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureboxTile8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(534, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 561);
            this.panel1.TabIndex = 0;
            // 
            // pictureboxTile8
            // 
            this.pictureboxTile8.Location = new System.Drawing.Point(0, 0);
            this.pictureboxTile8.Name = "pictureboxTile8";
            this.pictureboxTile8.Size = new System.Drawing.Size(512, 2048);
            this.pictureboxTile8.TabIndex = 0;
            this.pictureboxTile8.TabStop = false;
            this.pictureboxTile8.Click += new System.EventHandler(this.pictureboxTile8_Click);
            this.pictureboxTile8.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureboxTile8_Paint);
            this.pictureboxTile8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureboxTile8_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureboxTile16);
            this.panel2.Location = new System.Drawing.Point(581, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(72, 72);
            this.panel2.TabIndex = 1;
            // 
            // pictureboxTile16
            // 
            this.pictureboxTile16.Location = new System.Drawing.Point(2, 2);
            this.pictureboxTile16.Name = "pictureboxTile16";
            this.pictureboxTile16.Size = new System.Drawing.Size(64, 64);
            this.pictureboxTile16.TabIndex = 2;
            this.pictureboxTile16.TabStop = false;
            this.pictureboxTile16.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureboxTile16_Paint);
            this.pictureboxTile16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureboxTile16_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(540, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selected Tile 8 : ";
            // 
            // tile8Textbox
            // 
            this.tile8Textbox.Location = new System.Drawing.Point(543, 130);
            this.tile8Textbox.Name = "tile8Textbox";
            this.tile8Textbox.Size = new System.Drawing.Size(100, 20);
            this.tile8Textbox.TabIndex = 3;
            this.tile8Textbox.Text = "0";
            // 
            // mirrorXCheckbox
            // 
            this.mirrorXCheckbox.AutoSize = true;
            this.mirrorXCheckbox.Location = new System.Drawing.Point(543, 195);
            this.mirrorXCheckbox.Name = "mirrorXCheckbox";
            this.mirrorXCheckbox.Size = new System.Drawing.Size(62, 17);
            this.mirrorXCheckbox.TabIndex = 4;
            this.mirrorXCheckbox.Text = "Mirror X";
            this.mirrorXCheckbox.UseVisualStyleBackColor = true;
            this.mirrorXCheckbox.CheckStateChanged += new System.EventHandler(this.mirrorXCheckbox_CheckStateChanged);
            // 
            // mirrorYCheckbox
            // 
            this.mirrorYCheckbox.AutoSize = true;
            this.mirrorYCheckbox.Location = new System.Drawing.Point(543, 218);
            this.mirrorYCheckbox.Name = "mirrorYCheckbox";
            this.mirrorYCheckbox.Size = new System.Drawing.Size(62, 17);
            this.mirrorYCheckbox.TabIndex = 5;
            this.mirrorYCheckbox.Text = "Mirror Y";
            this.mirrorYCheckbox.UseVisualStyleBackColor = true;
            this.mirrorYCheckbox.CheckStateChanged += new System.EventHandler(this.mirrorXCheckbox_CheckStateChanged);
            // 
            // infrontCheckbox
            // 
            this.infrontCheckbox.AutoSize = true;
            this.infrontCheckbox.Location = new System.Drawing.Point(543, 241);
            this.infrontCheckbox.Name = "infrontCheckbox";
            this.infrontCheckbox.Size = new System.Drawing.Size(62, 17);
            this.infrontCheckbox.TabIndex = 6;
            this.infrontCheckbox.Text = "In Front";
            this.infrontCheckbox.UseVisualStyleBackColor = true;
            this.infrontCheckbox.CheckStateChanged += new System.EventHandler(this.mirrorXCheckbox_CheckStateChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(621, 526);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(540, 526);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // paletteTextbox
            // 
            this.paletteTextbox.Location = new System.Drawing.Point(543, 169);
            this.paletteTextbox.Name = "paletteTextbox";
            this.paletteTextbox.Size = new System.Drawing.Size(100, 20);
            this.paletteTextbox.TabIndex = 10;
            this.paletteTextbox.Text = "0";
            this.paletteTextbox.TextChanged += new System.EventHandler(this.paletteTextbox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(540, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Selected Palette :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "That Tile is Used :";
            // 
            // Tile16Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 561);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.paletteTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.infrontCheckbox);
            this.Controls.Add(this.mirrorYCheckbox);
            this.Controls.Add(this.mirrorXCheckbox);
            this.Controls.Add(this.tile8Textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(724, 600);
            this.Name = "Tile16Editor";
            this.Text = "Tile 16 Editor - Tile 0000";
            this.Load += new System.EventHandler(this.Tile16Editor_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile8)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxTile16)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureboxTile8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureboxTile16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tile8Textbox;
        private System.Windows.Forms.CheckBox mirrorXCheckbox;
        private System.Windows.Forms.CheckBox mirrorYCheckbox;
        private System.Windows.Forms.CheckBox infrontCheckbox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox paletteTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}