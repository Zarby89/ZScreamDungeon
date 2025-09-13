namespace ZeldaFullEditor.Gui
{
    partial class GfxImportExport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.allgfxPicturebox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.paste24bpp = new System.Windows.Forms.Button();
            this.copy24bpp = new System.Windows.Forms.Button();
            this.pasteIndexed = new System.Windows.Forms.Button();
            this.copyIndexed = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.palettePicturebox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.selectedLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.allgfx2picturebox = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allgfxPicturebox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allgfx2picturebox)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.allgfxPicturebox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 712);
            this.panel1.TabIndex = 1;
            // 
            // allgfxPicturebox
            // 
            this.allgfxPicturebox.Location = new System.Drawing.Point(3, 3);
            this.allgfxPicturebox.Name = "allgfxPicturebox";
            this.allgfxPicturebox.Size = new System.Drawing.Size(256, 14272);
            this.allgfxPicturebox.TabIndex = 0;
            this.allgfxPicturebox.TabStop = false;
            this.allgfxPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.allgfxPicturebox_Paint);
            this.allgfxPicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allgfxPicturebox_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.paste24bpp);
            this.groupBox1.Controls.Add(this.copy24bpp);
            this.groupBox1.Location = new System.Drawing.Point(565, 321);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Copy / Paste (Ctrl+C / Ctrl+V)";
            // 
            // paste24bpp
            // 
            this.paste24bpp.Location = new System.Drawing.Point(112, 19);
            this.paste24bpp.Name = "paste24bpp";
            this.paste24bpp.Size = new System.Drawing.Size(100, 23);
            this.paste24bpp.TabIndex = 3;
            this.paste24bpp.Text = "Paste";
            this.paste24bpp.UseVisualStyleBackColor = true;
            this.paste24bpp.Click += new System.EventHandler(this.paste24bpp_Click);
            // 
            // copy24bpp
            // 
            this.copy24bpp.Location = new System.Drawing.Point(6, 19);
            this.copy24bpp.Name = "copy24bpp";
            this.copy24bpp.Size = new System.Drawing.Size(100, 23);
            this.copy24bpp.TabIndex = 1;
            this.copy24bpp.Text = "Copy 32bpp +Pal";
            this.copy24bpp.UseVisualStyleBackColor = true;
            this.copy24bpp.Click += new System.EventHandler(this.copy24bpp_Click);
            // 
            // pasteIndexed
            // 
            this.pasteIndexed.Location = new System.Drawing.Point(671, 448);
            this.pasteIndexed.Name = "pasteIndexed";
            this.pasteIndexed.Size = new System.Drawing.Size(100, 23);
            this.pasteIndexed.TabIndex = 2;
            this.pasteIndexed.Text = "Paste Indexed";
            this.pasteIndexed.UseVisualStyleBackColor = true;
            this.pasteIndexed.Click += new System.EventHandler(this.pasteIndexed_Click);
            // 
            // copyIndexed
            // 
            this.copyIndexed.Location = new System.Drawing.Point(565, 448);
            this.copyIndexed.Name = "copyIndexed";
            this.copyIndexed.Size = new System.Drawing.Size(100, 23);
            this.copyIndexed.TabIndex = 0;
            this.copyIndexed.Text = "Copy Indexed";
            this.copyIndexed.UseVisualStyleBackColor = true;
            this.copyIndexed.Click += new System.EventHandler(this.copyIndexed_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.infoLabel);
            this.groupBox2.Location = new System.Drawing.Point(565, 384);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 58);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Infos";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(6, 16);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(100, 26);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "Compressed Size = \r\nAvailable Space = ";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1129, 715);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save GFX";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(565, 36);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(142, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Current Dungeon Palette";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(713, 36);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(117, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "Current OW Palette";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // palettePicturebox
            // 
            this.palettePicturebox.Location = new System.Drawing.Point(565, 59);
            this.palettePicturebox.Name = "palettePicturebox";
            this.palettePicturebox.Size = new System.Drawing.Size(256, 256);
            this.palettePicturebox.TabIndex = 8;
            this.palettePicturebox.TabStop = false;
            this.palettePicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.palettePicturebox_Paint);
            this.palettePicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(847, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 703);
            this.panel2.TabIndex = 10;
            // 
            // selectedLabel
            // 
            this.selectedLabel.AutoSize = true;
            this.selectedLabel.Location = new System.Drawing.Point(562, 6);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(89, 13);
            this.selectedLabel.TabIndex = 13;
            this.selectedLabel.Text = "Sheet Selected : ";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.allgfx2picturebox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(278, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(278, 712);
            this.panel3.TabIndex = 14;
            // 
            // allgfx2picturebox
            // 
            this.allgfx2picturebox.Location = new System.Drawing.Point(3, 0);
            this.allgfx2picturebox.Name = "allgfx2picturebox";
            this.allgfx2picturebox.Size = new System.Drawing.Size(256, 14272);
            this.allgfx2picturebox.TabIndex = 0;
            this.allgfx2picturebox.TabStop = false;
            this.allgfx2picturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.allgfx2picturebox_Paint);
            this.allgfx2picturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allgfx2picturebox_MouseDown);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(556, 741);
            this.panel4.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(556, 29);
            this.panel5.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Overworld Gfx Sheets";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dungeon Gfx Sheets";
            // 
            // GfxImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.selectedLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pasteIndexed);
            this.Controls.Add(this.copyIndexed);
            this.Controls.Add(this.palettePicturebox);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GfxImportExport";
            this.Size = new System.Drawing.Size(1232, 741);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allgfxPicturebox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allgfx2picturebox)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button paste24bpp;
        private System.Windows.Forms.Button pasteIndexed;
        private System.Windows.Forms.Button copy24bpp;
        private System.Windows.Forms.Button copyIndexed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.PictureBox palettePicturebox;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.PictureBox allgfxPicturebox;
        private System.Windows.Forms.Label selectedLabel;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.PictureBox allgfx2picturebox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
