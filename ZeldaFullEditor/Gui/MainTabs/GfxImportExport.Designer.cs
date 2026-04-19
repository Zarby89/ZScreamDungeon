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
            panel1 = new System.Windows.Forms.Panel();
            allgfxPicturebox = new System.Windows.Forms.PictureBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            paste24bpp = new System.Windows.Forms.Button();
            copy24bpp = new System.Windows.Forms.Button();
            pasteIndexed = new System.Windows.Forms.Button();
            copyIndexed = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            infoLabel = new System.Windows.Forms.Label();
            button2 = new System.Windows.Forms.Button();
            radioButton1 = new System.Windows.Forms.RadioButton();
            radioButton2 = new System.Windows.Forms.RadioButton();
            palettePicturebox = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            selectedLabel = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)allgfxPicturebox).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)palettePicturebox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(allgfxPicturebox);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(324, 763);
            panel1.TabIndex = 1;
            // 
            // allgfxPicturebox
            // 
            allgfxPicturebox.Location = new System.Drawing.Point(4, 3);
            allgfxPicturebox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            allgfxPicturebox.Name = "allgfxPicturebox";
            allgfxPicturebox.Size = new System.Drawing.Size(299, 14272);
            allgfxPicturebox.TabIndex = 0;
            allgfxPicturebox.TabStop = false;
            allgfxPicturebox.Paint += allgfxPicturebox_Paint;
            allgfxPicturebox.MouseDown += allgfxPicturebox_MouseDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(paste24bpp);
            groupBox1.Controls.Add(copy24bpp);
            groupBox1.Location = new System.Drawing.Point(342, 370);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(299, 66);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Copy / Paste (Ctrl+C / Ctrl+V)";
            // 
            // paste24bpp
            // 
            paste24bpp.Location = new System.Drawing.Point(131, 22);
            paste24bpp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            paste24bpp.Name = "paste24bpp";
            paste24bpp.Size = new System.Drawing.Size(117, 27);
            paste24bpp.TabIndex = 3;
            paste24bpp.Text = "Paste";
            paste24bpp.UseVisualStyleBackColor = true;
            paste24bpp.Click += paste24bpp_Click;
            // 
            // copy24bpp
            // 
            copy24bpp.Location = new System.Drawing.Point(7, 22);
            copy24bpp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            copy24bpp.Name = "copy24bpp";
            copy24bpp.Size = new System.Drawing.Size(117, 27);
            copy24bpp.TabIndex = 1;
            copy24bpp.Text = "Copy 32bpp +Pal";
            copy24bpp.UseVisualStyleBackColor = true;
            copy24bpp.Click += copy24bpp_Click;
            // 
            // pasteIndexed
            // 
            pasteIndexed.Location = new System.Drawing.Point(465, 517);
            pasteIndexed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pasteIndexed.Name = "pasteIndexed";
            pasteIndexed.Size = new System.Drawing.Size(117, 27);
            pasteIndexed.TabIndex = 2;
            pasteIndexed.Text = "Paste Indexed";
            pasteIndexed.UseVisualStyleBackColor = true;
            pasteIndexed.Click += pasteIndexed_Click;
            // 
            // copyIndexed
            // 
            copyIndexed.Location = new System.Drawing.Point(342, 517);
            copyIndexed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            copyIndexed.Name = "copyIndexed";
            copyIndexed.Size = new System.Drawing.Size(117, 27);
            copyIndexed.TabIndex = 0;
            copyIndexed.Text = "Copy Indexed";
            copyIndexed.UseVisualStyleBackColor = true;
            copyIndexed.Click += copyIndexed_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(infoLabel);
            groupBox2.Location = new System.Drawing.Point(342, 443);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(299, 67);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Infos";
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Location = new System.Drawing.Point(7, 18);
            infoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new System.Drawing.Size(110, 30);
            infoLabel.TabIndex = 0;
            infoLabel.Text = "Compressed Size = \r\nAvailable Space = ";
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button2.Location = new System.Drawing.Point(858, 733);
            button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(117, 27);
            button2.TabIndex = 5;
            button2.Text = "Save GFX";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new System.Drawing.Point(342, 42);
            radioButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(156, 19);
            radioButton1.TabIndex = 6;
            radioButton1.TabStop = true;
            radioButton1.Text = "Current Dungeon Palette";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new System.Drawing.Point(514, 42);
            radioButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(127, 19);
            radioButton2.TabIndex = 7;
            radioButton2.Text = "Current OW Palette";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // palettePicturebox
            // 
            palettePicturebox.Location = new System.Drawing.Point(342, 68);
            palettePicturebox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            palettePicturebox.Name = "palettePicturebox";
            palettePicturebox.Size = new System.Drawing.Size(299, 295);
            palettePicturebox.TabIndex = 8;
            palettePicturebox.TabStop = false;
            palettePicturebox.Paint += palettePicturebox_Paint;
            palettePicturebox.MouseDown += palettePicturebox_MouseDown;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(331, 744);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(331, 15);
            label1.TabIndex = 9;
            label1.Text = "*Import .bin do not update the preview on the left or in editor";
            // 
            // panel2
            // 
            panel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel2.Location = new System.Drawing.Point(658, 7);
            panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(316, 719);
            panel2.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(342, 550);
            button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(117, 27);
            button1.TabIndex = 11;
            button1.Text = "Save sheet .bin";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(465, 550);
            button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(117, 27);
            button3.TabIndex = 12;
            button3.Text = "Import sheet .bin";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // selectedLabel
            // 
            selectedLabel.AutoSize = true;
            selectedLabel.Location = new System.Drawing.Point(338, 7);
            selectedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            selectedLabel.Name = "selectedLabel";
            selectedLabel.Size = new System.Drawing.Size(92, 15);
            selectedLabel.TabIndex = 13;
            selectedLabel.Text = "Sheet Selected : ";
            // 
            // GfxImportExport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(selectedLabel);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(pasteIndexed);
            Controls.Add(copyIndexed);
            Controls.Add(palettePicturebox);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(button2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "GfxImportExport";
            Size = new System.Drawing.Size(978, 763);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)allgfxPicturebox).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)palettePicturebox).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.PictureBox allgfxPicturebox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label selectedLabel;
    }
}
