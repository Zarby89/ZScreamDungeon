namespace ZeldaFullEditor.Gui
{
    partial class AddSprite
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
			this.spriteListBox = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// spriteListBox
			// 
			this.spriteListBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.spriteListBox.FormattingEnabled = true;
			this.spriteListBox.Location = new System.Drawing.Point(0, 0);
			this.spriteListBox.Name = "spriteListBox";
			this.spriteListBox.Size = new System.Drawing.Size(255, 479);
			this.spriteListBox.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(261, 444);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(115, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point(261, 415);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(115, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// AddSprite
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(388, 479);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.spriteListBox);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Name = "AddSprite";
			this.Text = "Add sprite";
			this.Load += new System.EventHandler(this.AddSprite_Load);
			this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox spriteListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}