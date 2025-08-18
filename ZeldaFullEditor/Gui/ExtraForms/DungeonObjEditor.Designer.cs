namespace ZeldaFullEditor.Gui.ExtraForms
{
    partial class DungeonObjEditor
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
            this.tileobjectPicturebox = new System.Windows.Forms.PictureBox();
            this.tilesetPicturebox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tileobjectPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetPicturebox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileobjectPicturebox
            // 
            this.tileobjectPicturebox.Location = new System.Drawing.Point(12, 12);
            this.tileobjectPicturebox.Name = "tileobjectPicturebox";
            this.tileobjectPicturebox.Size = new System.Drawing.Size(512, 512);
            this.tileobjectPicturebox.TabIndex = 0;
            this.tileobjectPicturebox.TabStop = false;
            // 
            // tilesetPicturebox
            // 
            this.tilesetPicturebox.Location = new System.Drawing.Point(3, 3);
            this.tilesetPicturebox.Name = "tilesetPicturebox";
            this.tilesetPicturebox.Size = new System.Drawing.Size(256, 1024);
            this.tilesetPicturebox.TabIndex = 1;
            this.tilesetPicturebox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tilesetPicturebox);
            this.panel1.Location = new System.Drawing.Point(530, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 546);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(813, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 514);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tile Properties";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(934, 535);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(853, 535);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(137, 530);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(387, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 533);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Draw Type (Subtype1) :";
            // 
            // DungeonObjEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 570);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tileobjectPicturebox);
            this.Name = "DungeonObjEditor";
            this.Text = "Dungeon Object Editor";
            ((System.ComponentModel.ISupportInitialize)(this.tileobjectPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetPicturebox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox tileobjectPicturebox;
        private System.Windows.Forms.PictureBox tilesetPicturebox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}