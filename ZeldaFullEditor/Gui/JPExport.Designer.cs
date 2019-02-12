namespace ZeldaFullEditor.Gui
{
    partial class JPExport
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
            this.button1 = new System.Windows.Forms.Button();
            this.tilesbox = new System.Windows.Forms.CheckBox();
            this.roomheaderbox = new System.Windows.Forms.CheckBox();
            this.blockbox = new System.Windows.Forms.CheckBox();
            this.entranceBox = new System.Windows.Forms.CheckBox();
            this.torchesbox = new System.Windows.Forms.CheckBox();
            this.itemsbox = new System.Windows.Forms.CheckBox();
            this.chestsbox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.spritebox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(134, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Export!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tilesbox
            // 
            this.tilesbox.AutoSize = true;
            this.tilesbox.Checked = true;
            this.tilesbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tilesbox.Location = new System.Drawing.Point(12, 31);
            this.tilesbox.Name = "tilesbox";
            this.tilesbox.Size = new System.Drawing.Size(108, 17);
            this.tilesbox.TabIndex = 1;
            this.tilesbox.Text = "Tiles Object Data";
            this.tilesbox.UseVisualStyleBackColor = true;
            // 
            // roomheaderbox
            // 
            this.roomheaderbox.AutoSize = true;
            this.roomheaderbox.Checked = true;
            this.roomheaderbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.roomheaderbox.Location = new System.Drawing.Point(12, 54);
            this.roomheaderbox.Name = "roomheaderbox";
            this.roomheaderbox.Size = new System.Drawing.Size(102, 17);
            this.roomheaderbox.TabIndex = 2;
            this.roomheaderbox.Text = "Rooms Headers";
            this.roomheaderbox.UseVisualStyleBackColor = true;
            // 
            // blockbox
            // 
            this.blockbox.AutoSize = true;
            this.blockbox.Checked = true;
            this.blockbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blockbox.Location = new System.Drawing.Point(12, 77);
            this.blockbox.Name = "blockbox";
            this.blockbox.Size = new System.Drawing.Size(84, 17);
            this.blockbox.TabIndex = 3;
            this.blockbox.Text = "Blocks Data";
            this.blockbox.UseVisualStyleBackColor = true;
            // 
            // entranceBox
            // 
            this.entranceBox.AutoSize = true;
            this.entranceBox.Checked = true;
            this.entranceBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entranceBox.Location = new System.Drawing.Point(12, 8);
            this.entranceBox.Name = "entranceBox";
            this.entranceBox.Size = new System.Drawing.Size(100, 17);
            this.entranceBox.TabIndex = 4;
            this.entranceBox.Text = "Entrances Data";
            this.entranceBox.UseVisualStyleBackColor = true;
            // 
            // torchesbox
            // 
            this.torchesbox.AutoSize = true;
            this.torchesbox.Checked = true;
            this.torchesbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.torchesbox.Location = new System.Drawing.Point(12, 100);
            this.torchesbox.Name = "torchesbox";
            this.torchesbox.Size = new System.Drawing.Size(91, 17);
            this.torchesbox.TabIndex = 5;
            this.torchesbox.Text = "Torches Data";
            this.torchesbox.UseVisualStyleBackColor = true;
            // 
            // itemsbox
            // 
            this.itemsbox.AutoSize = true;
            this.itemsbox.Checked = true;
            this.itemsbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemsbox.Location = new System.Drawing.Point(134, 8);
            this.itemsbox.Name = "itemsbox";
            this.itemsbox.Size = new System.Drawing.Size(77, 17);
            this.itemsbox.TabIndex = 6;
            this.itemsbox.Text = "Items Data";
            this.itemsbox.UseVisualStyleBackColor = true;
            // 
            // chestsbox
            // 
            this.chestsbox.AutoSize = true;
            this.chestsbox.Checked = true;
            this.chestsbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chestsbox.Location = new System.Drawing.Point(134, 31);
            this.chestsbox.Name = "chestsbox";
            this.chestsbox.Size = new System.Drawing.Size(84, 17);
            this.chestsbox.TabIndex = 7;
            this.chestsbox.Text = "Chests Data";
            this.chestsbox.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(134, 54);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Damage Pits";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // spritebox
            // 
            this.spritebox.AutoSize = true;
            this.spritebox.Checked = true;
            this.spritebox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.spritebox.Location = new System.Drawing.Point(134, 77);
            this.spritebox.Name = "spritebox";
            this.spritebox.Size = new System.Drawing.Size(84, 17);
            this.spritebox.TabIndex = 10;
            this.spritebox.Text = "Sprites Data";
            this.spritebox.UseVisualStyleBackColor = true;
            // 
            // JPExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 129);
            this.Controls.Add(this.spritebox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chestsbox);
            this.Controls.Add(this.itemsbox);
            this.Controls.Add(this.torchesbox);
            this.Controls.Add(this.entranceBox);
            this.Controls.Add(this.blockbox);
            this.Controls.Add(this.roomheaderbox);
            this.Controls.Add(this.tilesbox);
            this.Controls.Add(this.button1);
            this.Name = "JPExport";
            this.Text = "JPExport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.CheckBox tilesbox;
        public System.Windows.Forms.CheckBox roomheaderbox;
        public System.Windows.Forms.CheckBox blockbox;
        public System.Windows.Forms.CheckBox entranceBox;
        public System.Windows.Forms.CheckBox torchesbox;
        public System.Windows.Forms.CheckBox itemsbox;
        public System.Windows.Forms.CheckBox chestsbox;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.CheckBox spritebox;
    }
}