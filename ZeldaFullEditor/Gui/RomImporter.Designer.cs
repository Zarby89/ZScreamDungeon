namespace ZeldaFullEditor.Gui
{
    partial class RomImporter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.entrancescheckBox = new System.Windows.Forms.CheckBox();
            this.exitscheckBox = new System.Windows.Forms.CheckBox();
            this.spritescheckBox = new System.Windows.Forms.CheckBox();
            this.itemscheckBox = new System.Windows.Forms.CheckBox();
            this.transportscheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.propertiescheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.propertiescheckbox);
            this.groupBox1.Controls.Add(this.transportscheckBox);
            this.groupBox1.Controls.Add(this.itemscheckBox);
            this.groupBox1.Controls.Add(this.spritescheckBox);
            this.groupBox1.Controls.Add(this.exitscheckBox);
            this.groupBox1.Controls.Add(this.entrancescheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Overworld";
            // 
            // entrancescheckBox
            // 
            this.entrancescheckBox.AutoSize = true;
            this.entrancescheckBox.Location = new System.Drawing.Point(6, 19);
            this.entrancescheckBox.Name = "entrancescheckBox";
            this.entrancescheckBox.Size = new System.Drawing.Size(74, 17);
            this.entrancescheckBox.TabIndex = 0;
            this.entrancescheckBox.Text = "Entrances";
            this.entrancescheckBox.UseVisualStyleBackColor = true;
            // 
            // exitscheckBox
            // 
            this.exitscheckBox.AutoSize = true;
            this.exitscheckBox.Location = new System.Drawing.Point(6, 42);
            this.exitscheckBox.Name = "exitscheckBox";
            this.exitscheckBox.Size = new System.Drawing.Size(48, 17);
            this.exitscheckBox.TabIndex = 1;
            this.exitscheckBox.Text = "Exits";
            this.exitscheckBox.UseVisualStyleBackColor = true;
            // 
            // spritescheckBox
            // 
            this.spritescheckBox.AutoSize = true;
            this.spritescheckBox.Location = new System.Drawing.Point(6, 65);
            this.spritescheckBox.Name = "spritescheckBox";
            this.spritescheckBox.Size = new System.Drawing.Size(58, 17);
            this.spritescheckBox.TabIndex = 2;
            this.spritescheckBox.Text = "Sprites";
            this.spritescheckBox.UseVisualStyleBackColor = true;
            // 
            // itemscheckBox
            // 
            this.itemscheckBox.AutoSize = true;
            this.itemscheckBox.Location = new System.Drawing.Point(6, 88);
            this.itemscheckBox.Name = "itemscheckBox";
            this.itemscheckBox.Size = new System.Drawing.Size(51, 17);
            this.itemscheckBox.TabIndex = 3;
            this.itemscheckBox.Text = "Items";
            this.itemscheckBox.UseVisualStyleBackColor = true;
            // 
            // transportscheckBox
            // 
            this.transportscheckBox.AutoSize = true;
            this.transportscheckBox.Location = new System.Drawing.Point(119, 19);
            this.transportscheckBox.Name = "transportscheckBox";
            this.transportscheckBox.Size = new System.Drawing.Size(76, 17);
            this.transportscheckBox.TabIndex = 4;
            this.transportscheckBox.Text = "Transports";
            this.transportscheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Import!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // propertiescheckbox
            // 
            this.propertiescheckbox.AutoSize = true;
            this.propertiescheckbox.Location = new System.Drawing.Point(119, 42);
            this.propertiescheckbox.Name = "propertiescheckbox";
            this.propertiescheckbox.Size = new System.Drawing.Size(73, 17);
            this.propertiescheckbox.TabIndex = 5;
            this.propertiescheckbox.Text = "Properties";
            this.propertiescheckbox.UseVisualStyleBackColor = true;
            // 
            // RomImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 164);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "RomImporter";
            this.Text = "RomImporter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox transportscheckBox;
        private System.Windows.Forms.CheckBox itemscheckBox;
        private System.Windows.Forms.CheckBox spritescheckBox;
        private System.Windows.Forms.CheckBox exitscheckBox;
        private System.Windows.Forms.CheckBox entrancescheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox propertiescheckbox;
    }
}