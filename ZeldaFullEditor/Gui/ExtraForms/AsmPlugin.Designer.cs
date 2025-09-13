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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsmPlugin));
            this.AcceptButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PatchPanel = new System.Windows.Forms.Panel();
            this.propertyGroupbox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.patchAuthorLabel = new System.Windows.Forms.Label();
            this.patchDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.patchListbox = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RemoveDirectoryButton = new System.Windows.Forms.Button();
            this.AddDirectoryButton = new System.Windows.Forms.Button();
            this.removePluginButton = new System.Windows.Forms.Button();
            this.addPluginButton = new System.Windows.Forms.Button();
            this.patchFolderTabcontrol = new System.Windows.Forms.TabControl();
            this.refreshPluginButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.morepatchButton = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.PatchPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.panel4.Controls.Add(this.patchFolderTabcontrol);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(856, 527);
            this.panel4.TabIndex = 8;
            // 
            // PatchPanel
            // 
            this.PatchPanel.Controls.Add(this.propertyGroupbox);
            this.PatchPanel.Controls.Add(this.label1);
            this.PatchPanel.Controls.Add(this.panel3);
            this.PatchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatchPanel.Location = new System.Drawing.Point(194, 26);
            this.PatchPanel.Name = "PatchPanel";
            this.PatchPanel.Size = new System.Drawing.Size(662, 501);
            this.PatchPanel.TabIndex = 6;
            // 
            // propertyGroupbox
            // 
            this.propertyGroupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGroupbox.Location = new System.Drawing.Point(0, 94);
            this.propertyGroupbox.Name = "propertyGroupbox";
            this.propertyGroupbox.Size = new System.Drawing.Size(662, 381);
            this.propertyGroupbox.TabIndex = 9;
            this.propertyGroupbox.TabStop = false;
            this.propertyGroupbox.Text = "Patch configuration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = resources.GetString("label1.Text");
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
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 501);
            this.panel1.TabIndex = 1;
            // 
            // patchListbox
            // 
            this.patchListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patchListbox.FormattingEnabled = true;
            this.patchListbox.Location = new System.Drawing.Point(0, 0);
            this.patchListbox.Name = "patchListbox";
            this.patchListbox.Size = new System.Drawing.Size(194, 409);
            this.patchListbox.TabIndex = 2;
            this.patchListbox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.patchListbox_ItemCheck);
            this.patchListbox.SelectedIndexChanged += new System.EventHandler(this.patchListbox_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RemoveDirectoryButton);
            this.panel2.Controls.Add(this.AddDirectoryButton);
            this.panel2.Controls.Add(this.removePluginButton);
            this.panel2.Controls.Add(this.addPluginButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 409);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 92);
            this.panel2.TabIndex = 1;
            // 
            // RemoveDirectoryButton
            // 
            this.RemoveDirectoryButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.RemoveDirectoryButton.Location = new System.Drawing.Point(0, 69);
            this.RemoveDirectoryButton.Name = "RemoveDirectoryButton";
            this.RemoveDirectoryButton.Size = new System.Drawing.Size(194, 23);
            this.RemoveDirectoryButton.TabIndex = 5;
            this.RemoveDirectoryButton.Text = "Remove directory tab";
            this.RemoveDirectoryButton.UseVisualStyleBackColor = true;
            this.RemoveDirectoryButton.Click += new System.EventHandler(this.RemoveDirectoryButton_Click);
            // 
            // AddDirectoryButton
            // 
            this.AddDirectoryButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddDirectoryButton.Location = new System.Drawing.Point(0, 46);
            this.AddDirectoryButton.Name = "AddDirectoryButton";
            this.AddDirectoryButton.Size = new System.Drawing.Size(194, 23);
            this.AddDirectoryButton.TabIndex = 4;
            this.AddDirectoryButton.Text = "Add directory tab";
            this.AddDirectoryButton.UseVisualStyleBackColor = true;
            this.AddDirectoryButton.Click += new System.EventHandler(this.AddDirectoryButton_Click);
            // 
            // removePluginButton
            // 
            this.removePluginButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.removePluginButton.Location = new System.Drawing.Point(0, 23);
            this.removePluginButton.Name = "removePluginButton";
            this.removePluginButton.Size = new System.Drawing.Size(194, 23);
            this.removePluginButton.TabIndex = 3;
            this.removePluginButton.Text = "Remove selected patch";
            this.removePluginButton.UseVisualStyleBackColor = true;
            this.removePluginButton.Click += new System.EventHandler(this.removePluginButton_Click);
            // 
            // addPluginButton
            // 
            this.addPluginButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addPluginButton.Location = new System.Drawing.Point(0, 0);
            this.addPluginButton.Name = "addPluginButton";
            this.addPluginButton.Size = new System.Drawing.Size(194, 23);
            this.addPluginButton.TabIndex = 2;
            this.addPluginButton.Text = "Add ASM Patch(es)";
            this.addPluginButton.UseVisualStyleBackColor = true;
            this.addPluginButton.Click += new System.EventHandler(this.addPluginButton_Click);
            // 
            // patchFolderTabcontrol
            // 
            this.patchFolderTabcontrol.Dock = System.Windows.Forms.DockStyle.Top;
            this.patchFolderTabcontrol.Location = new System.Drawing.Point(0, 0);
            this.patchFolderTabcontrol.Name = "patchFolderTabcontrol";
            this.patchFolderTabcontrol.SelectedIndex = 0;
            this.patchFolderTabcontrol.Size = new System.Drawing.Size(856, 26);
            this.patchFolderTabcontrol.TabIndex = 10;
            this.patchFolderTabcontrol.SelectedIndexChanged += new System.EventHandler(this.patchFolderTabcontrol_SelectedIndexChanged);
            // 
            // refreshPluginButton
            // 
            this.refreshPluginButton.Location = new System.Drawing.Point(115, 1);
            this.refreshPluginButton.Name = "refreshPluginButton";
            this.refreshPluginButton.Size = new System.Drawing.Size(106, 23);
            this.refreshPluginButton.TabIndex = 4;
            this.refreshPluginButton.Text = "Refresh patches";
            this.refreshPluginButton.UseVisualStyleBackColor = true;
            this.refreshPluginButton.Click += new System.EventHandler(this.refreshPluginButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.morepatchButton);
            this.panel5.Controls.Add(this.refreshPluginButton);
            this.panel5.Controls.Add(this.UpdateButton);
            this.panel5.Controls.Add(this.CancelButton);
            this.panel5.Controls.Add(this.AcceptButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 527);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(856, 24);
            this.panel5.TabIndex = 9;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UpdateButton.Location = new System.Drawing.Point(274, 0);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(106, 23);
            this.UpdateButton.TabIndex = 11;
            this.UpdateButton.Text = "Check for update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Visible = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
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
            // AsmPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 551);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Name = "AsmPlugin";
            this.Text = "ROM Patches";
            this.Load += new System.EventHandler(this.AsmPlugin_Load);
            this.panel4.ResumeLayout(false);
            this.PatchPanel.ResumeLayout(false);
            this.PatchPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TabControl patchFolderTabcontrol;
        private System.Windows.Forms.Panel PatchPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox patchDescriptionTextbox;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label patchAuthorLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button refreshPluginButton;
        private System.Windows.Forms.Button removePluginButton;
        private System.Windows.Forms.Button addPluginButton;
        private System.Windows.Forms.CheckedListBox patchListbox;
        private System.Windows.Forms.GroupBox propertyGroupbox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button RemoveDirectoryButton;
        private System.Windows.Forms.Button AddDirectoryButton;
        private System.Windows.Forms.Button morepatchButton;
    }
}
