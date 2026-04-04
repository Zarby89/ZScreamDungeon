namespace ZeldaFullEditor.Gui.ExtraForms
{
    partial class AsmPlugin
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
            this.AcceptButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PatchPanel = new System.Windows.Forms.Panel();
            this.propertyGroupbox = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.patchAuthorLabel = new System.Windows.Forms.Label();
            this.patchDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.patchListbox = new System.Windows.Forms.CheckedListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.morepatchButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addasmPatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedPatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4.SuspendLayout();
            this.PatchPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AcceptButton
            // 
            this.AcceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AcceptButton.Location = new System.Drawing.Point(781, 0);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 9;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.PatchPanel);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(856, 503);
            this.panel4.TabIndex = 8;
            // 
            // PatchPanel
            // 
            this.PatchPanel.Controls.Add(this.propertyGroupbox);
            this.PatchPanel.Controls.Add(this.panel3);
            this.PatchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatchPanel.Location = new System.Drawing.Point(194, 0);
            this.PatchPanel.Name = "PatchPanel";
            this.PatchPanel.Size = new System.Drawing.Size(662, 503);
            this.PatchPanel.TabIndex = 6;
            // 
            // propertyGroupbox
            // 
            this.propertyGroupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGroupbox.Location = new System.Drawing.Point(0, 94);
            this.propertyGroupbox.Name = "propertyGroupbox";
            this.propertyGroupbox.Size = new System.Drawing.Size(662, 409);
            this.propertyGroupbox.TabIndex = 9;
            this.propertyGroupbox.TabStop = false;
            this.propertyGroupbox.Text = "Patch configuration";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.patchAuthorLabel);
            this.panel3.Controls.Add(this.patchDescriptionTextbox);
            this.panel3.Controls.Add(this.labelDescription);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(662, 94);
            this.panel3.TabIndex = 7;
            // 
            // patchAuthorLabel
            // 
            this.patchAuthorLabel.AutoSize = true;
            this.patchAuthorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.patchAuthorLabel.Location = new System.Drawing.Point(0, 77);
            this.patchAuthorLabel.Name = "patchAuthorLabel";
            this.patchAuthorLabel.Size = new System.Drawing.Size(85, 13);
            this.patchAuthorLabel.TabIndex = 5;
            this.patchAuthorLabel.Text = "Patch author(s): ";
            // 
            // patchDescriptionTextbox
            // 
            this.patchDescriptionTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.patchDescriptionTextbox.Location = new System.Drawing.Point(0, 13);
            this.patchDescriptionTextbox.Multiline = true;
            this.patchDescriptionTextbox.Name = "patchDescriptionTextbox";
            this.patchDescriptionTextbox.ReadOnly = true;
            this.patchDescriptionTextbox.Size = new System.Drawing.Size(662, 64);
            this.patchDescriptionTextbox.TabIndex = 4;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDescription.Location = new System.Drawing.Point(0, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(89, 13);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "Patch description";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.patchListbox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 503);
            this.panel1.TabIndex = 1;
            // 
            // patchListbox
            // 
            this.patchListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patchListbox.FormattingEnabled = true;
            this.patchListbox.Location = new System.Drawing.Point(0, 0);
            this.patchListbox.Name = "patchListbox";
            this.patchListbox.Size = new System.Drawing.Size(194, 503);
            this.patchListbox.TabIndex = 2;
            this.patchListbox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.patchListbox_ItemCheck);
            this.patchListbox.SelectedIndexChanged += new System.EventHandler(this.patchListbox_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.morepatchButton);
            this.panel5.Controls.Add(this.CancelButton);
            this.panel5.Controls.Add(this.AcceptButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 527);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(856, 24);
            this.panel5.TabIndex = 9;
            // 
            // morepatchButton
            // 
            this.morepatchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.morepatchButton.Location = new System.Drawing.Point(3, 0);
            this.morepatchButton.Name = "morepatchButton";
            this.morepatchButton.Size = new System.Drawing.Size(106, 23);
            this.morepatchButton.TabIndex = 12;
            this.morepatchButton.Text = "Get more patches";
            this.morepatchButton.UseVisualStyleBackColor = true;
            this.morepatchButton.Click += new System.EventHandler(this.morepatchButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(703, 0);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(856, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addasmPatchToolStripMenuItem,
            this.deleteSelectedPatchToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addasmPatchToolStripMenuItem
            // 
            this.addasmPatchToolStripMenuItem.Name = "addasmPatchToolStripMenuItem";
            this.addasmPatchToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addasmPatchToolStripMenuItem.Text = "Add .asm patch";
            this.addasmPatchToolStripMenuItem.Click += new System.EventHandler(this.addasmPatchToolStripMenuItem_Click);
            // 
            // deleteSelectedPatchToolStripMenuItem
            // 
            this.deleteSelectedPatchToolStripMenuItem.Name = "deleteSelectedPatchToolStripMenuItem";
            this.deleteSelectedPatchToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.deleteSelectedPatchToolStripMenuItem.Text = "Delete selected patch";
            this.deleteSelectedPatchToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedPatchToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // AsmPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 551);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AsmPlugin";
            this.Text = "ROM Patches";
            this.Load += new System.EventHandler(this.AsmPlugin_Load);
            this.panel4.ResumeLayout(false);
            this.PatchPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Panel PatchPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox patchDescriptionTextbox;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label patchAuthorLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox patchListbox;
        private System.Windows.Forms.GroupBox propertyGroupbox;
        private System.Windows.Forms.Button morepatchButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addasmPatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedPatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}
