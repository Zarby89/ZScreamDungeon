namespace ZeldaFullEditor.Gui.ExtraForms
{
    partial class OWMusicForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.music1Box = new System.Windows.Forms.ComboBox();
            this.music2Box = new System.Windows.Forms.ComboBox();
            this.music3Box = new System.Windows.Forms.ComboBox();
            this.music4Box = new System.Windows.Forms.ComboBox();
            this.ambient4Box = new System.Windows.Forms.ComboBox();
            this.ambient3Box = new System.Windows.Forms.ComboBox();
            this.ambient2Box = new System.Windows.Forms.ComboBox();
            this.ambient1Box = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ambient4Box);
            this.groupBox1.Controls.Add(this.ambient3Box);
            this.groupBox1.Controls.Add(this.ambient2Box);
            this.groupBox1.Controls.Add(this.ambient1Box);
            this.groupBox1.Controls.Add(this.music4Box);
            this.groupBox1.Controls.Add(this.music3Box);
            this.groupBox1.Controls.Add(this.music2Box);
            this.groupBox1.Controls.Add(this.music1Box);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 192);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beginning";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Zelda rescued";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Master sword obtained";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Agahnim defeated";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // music1Box
            // 
            this.music1Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.music1Box.FormattingEnabled = true;
            this.music1Box.Location = new System.Drawing.Point(171, 32);
            this.music1Box.Name = "music1Box";
            this.music1Box.Size = new System.Drawing.Size(121, 21);
            this.music1Box.TabIndex = 4;
            this.music1Box.SelectedIndexChanged += new System.EventHandler(this.music1Box_SelectedIndexChanged);
            // 
            // music2Box
            // 
            this.music2Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.music2Box.FormattingEnabled = true;
            this.music2Box.Location = new System.Drawing.Point(171, 59);
            this.music2Box.Name = "music2Box";
            this.music2Box.Size = new System.Drawing.Size(121, 21);
            this.music2Box.TabIndex = 5;
            this.music2Box.SelectedIndexChanged += new System.EventHandler(this.music1Box_SelectedIndexChanged);
            // 
            // music3Box
            // 
            this.music3Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.music3Box.FormattingEnabled = true;
            this.music3Box.Location = new System.Drawing.Point(171, 86);
            this.music3Box.Name = "music3Box";
            this.music3Box.Size = new System.Drawing.Size(121, 21);
            this.music3Box.TabIndex = 6;
            this.music3Box.SelectedIndexChanged += new System.EventHandler(this.music1Box_SelectedIndexChanged);
            // 
            // music4Box
            // 
            this.music4Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.music4Box.FormattingEnabled = true;
            this.music4Box.Location = new System.Drawing.Point(171, 113);
            this.music4Box.Name = "music4Box";
            this.music4Box.Size = new System.Drawing.Size(121, 21);
            this.music4Box.TabIndex = 7;
            this.music4Box.SelectedIndexChanged += new System.EventHandler(this.music1Box_SelectedIndexChanged);
            // 
            // ambient4Box
            // 
            this.ambient4Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ambient4Box.FormattingEnabled = true;
            this.ambient4Box.Location = new System.Drawing.Point(298, 112);
            this.ambient4Box.Name = "ambient4Box";
            this.ambient4Box.Size = new System.Drawing.Size(121, 21);
            this.ambient4Box.TabIndex = 11;
            this.ambient4Box.SelectedIndexChanged += new System.EventHandler(this.music1Box_SelectedIndexChanged);
            // 
            // ambient3Box
            // 
            this.ambient3Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ambient3Box.FormattingEnabled = true;
            this.ambient3Box.Location = new System.Drawing.Point(298, 86);
            this.ambient3Box.Name = "ambient3Box";
            this.ambient3Box.Size = new System.Drawing.Size(121, 21);
            this.ambient3Box.TabIndex = 10;
            this.ambient3Box.SelectedIndexChanged += new System.EventHandler(this.music1Box_SelectedIndexChanged);
            // 
            // ambient2Box
            // 
            this.ambient2Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ambient2Box.FormattingEnabled = true;
            this.ambient2Box.Location = new System.Drawing.Point(298, 59);
            this.ambient2Box.Name = "ambient2Box";
            this.ambient2Box.Size = new System.Drawing.Size(121, 21);
            this.ambient2Box.TabIndex = 9;
            this.ambient2Box.SelectedIndexChanged += new System.EventHandler(this.music1Box_SelectedIndexChanged);
            // 
            // ambient1Box
            // 
            this.ambient1Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ambient1Box.FormattingEnabled = true;
            this.ambient1Box.Location = new System.Drawing.Point(298, 32);
            this.ambient1Box.Name = "ambient1Box";
            this.ambient1Box.Size = new System.Drawing.Size(121, 21);
            this.ambient1Box.TabIndex = 8;
            this.ambient1Box.SelectedIndexChanged += new System.EventHandler(this.music1Box_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Main song";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(295, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ambient";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(344, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(263, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OWMusicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 192);
            this.Controls.Add(this.groupBox1);
            this.Name = "OWMusicForm";
            this.Text = "Music Selection";
            this.Load += new System.EventHandler(this.OWMusicForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ambient4Box;
        private System.Windows.Forms.ComboBox ambient3Box;
        private System.Windows.Forms.ComboBox ambient2Box;
        private System.Windows.Forms.ComboBox ambient1Box;
        private System.Windows.Forms.ComboBox music4Box;
        private System.Windows.Forms.ComboBox music3Box;
        private System.Windows.Forms.ComboBox music2Box;
        private System.Windows.Forms.ComboBox music1Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}