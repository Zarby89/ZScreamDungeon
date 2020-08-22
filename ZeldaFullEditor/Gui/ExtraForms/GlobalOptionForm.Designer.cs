namespace ZeldaFullEditor
{
    partial class GlobalOptionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.romsizeComboxbox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.roomheaderTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.roomobjectlocationTextbox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ROM Size :";
            // 
            // romsizeComboxbox
            // 
            this.romsizeComboxbox.FormattingEnabled = true;
            this.romsizeComboxbox.Items.AddRange(new object[] {
            "2MB",
            "3MB",
            "4MB"});
            this.romsizeComboxbox.Location = new System.Drawing.Point(15, 25);
            this.romsizeComboxbox.Name = "romsizeComboxbox";
            this.romsizeComboxbox.Size = new System.Drawing.Size(81, 21);
            this.romsizeComboxbox.TabIndex = 1;
            this.romsizeComboxbox.Text = "2MB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(PC Hex) New Room Headers Location :";
            // 
            // roomheaderTextbox
            // 
            this.roomheaderTextbox.Location = new System.Drawing.Point(102, 25);
            this.roomheaderTextbox.Name = "roomheaderTextbox";
            this.roomheaderTextbox.Size = new System.Drawing.Size(249, 20);
            this.roomheaderTextbox.TabIndex = 3;
            this.roomheaderTextbox.Text = "120090";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "(PC Hex) Expanded Region for room objects (can be empty) :";
            // 
            // roomobjectlocationTextbox
            // 
            this.roomobjectlocationTextbox.Location = new System.Drawing.Point(15, 64);
            this.roomobjectlocationTextbox.Name = "roomobjectlocationTextbox";
            this.roomobjectlocationTextbox.Size = new System.Drawing.Size(336, 20);
            this.roomobjectlocationTextbox.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(336, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "(PC Hex) Expanded Region for GFX (can be empty) :";
            // 
            // GlobalOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 319);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.roomobjectlocationTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.roomheaderTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.romsizeComboxbox);
            this.Controls.Add(this.label1);
            this.Name = "GlobalOptionForm";
            this.Text = "GlobalOptionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox romsizeComboxbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox roomheaderTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox roomobjectlocationTextbox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
    }
}