namespace ZeldaFullEditor.Gui.ExtraForms
{
    partial class ZSUWProperties
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
			this.detaiItems = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.itemsInfosTextbox = new System.Windows.Forms.TextBox();
			this.basicchestLabel = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// detaiItems
			// 
			this.detaiItems.AutoSize = true;
			this.detaiItems.Dock = System.Windows.Forms.DockStyle.Top;
			this.detaiItems.Location = new System.Drawing.Point(0, 13);
			this.detaiItems.Name = "detaiItems";
			this.detaiItems.Size = new System.Drawing.Size(519, 17);
			this.detaiItems.TabIndex = 1;
			this.detaiItems.Text = "Detailed chest item info";
			this.detaiItems.UseVisualStyleBackColor = true;
			this.detaiItems.CheckedChanged += new System.EventHandler(this.detaiItems_CheckedChanged);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(525, 366);
			this.panel1.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.AutoSize = true;
			this.panel2.Controls.Add(this.itemsInfosTextbox);
			this.panel2.Controls.Add(this.basicchestLabel);
			this.panel2.Controls.Add(this.detaiItems);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(519, 360);
			this.panel2.TabIndex = 2;
			// 
			// itemsInfosTextbox
			// 
			this.itemsInfosTextbox.Dock = System.Windows.Forms.DockStyle.Top;
			this.itemsInfosTextbox.Location = new System.Drawing.Point(0, 43);
			this.itemsInfosTextbox.Multiline = true;
			this.itemsInfosTextbox.Name = "itemsInfosTextbox";
			this.itemsInfosTextbox.ReadOnly = true;
			this.itemsInfosTextbox.Size = new System.Drawing.Size(519, 20);
			this.itemsInfosTextbox.TabIndex = 2;
			// 
			// basicchestLabel
			// 
			this.basicchestLabel.AutoSize = true;
			this.basicchestLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.basicchestLabel.Location = new System.Drawing.Point(0, 30);
			this.basicchestLabel.Name = "basicchestLabel";
			this.basicchestLabel.Size = new System.Drawing.Size(35, 13);
			this.basicchestLabel.TabIndex = 3;
			this.basicchestLabel.Text = "label2";
			// 
			// ZSUWProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(525, 366);
			this.Controls.Add(this.panel1);
			this.Name = "ZSUWProperties";
			this.Text = "Underworld Properties";
			this.Load += new System.EventHandler(this.ZSUWProperties_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox detaiItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox itemsInfosTextbox;
        private System.Windows.Forms.Label basicchestLabel;
    }
}