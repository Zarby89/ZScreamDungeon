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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pluginListbox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.refreshPluginButton = new System.Windows.Forms.Button();
            this.removePluginButton = new System.Windows.Forms.Button();
            this.addPluginButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pluginDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pluginAuthorLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.propertiesPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pluginListbox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 552);
            this.panel1.TabIndex = 1;
            // 
            // pluginListbox
            // 
            this.pluginListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pluginListbox.FormattingEnabled = true;
            this.pluginListbox.Location = new System.Drawing.Point(0, 0);
            this.pluginListbox.Name = "pluginListbox";
            this.pluginListbox.Size = new System.Drawing.Size(194, 479);
            this.pluginListbox.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.refreshPluginButton);
            this.panel2.Controls.Add(this.removePluginButton);
            this.panel2.Controls.Add(this.addPluginButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 479);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 73);
            this.panel2.TabIndex = 1;
            // 
            // refreshPluginButton
            // 
            this.refreshPluginButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.refreshPluginButton.Location = new System.Drawing.Point(0, 46);
            this.refreshPluginButton.Name = "refreshPluginButton";
            this.refreshPluginButton.Size = new System.Drawing.Size(194, 23);
            this.refreshPluginButton.TabIndex = 4;
            this.refreshPluginButton.Text = "Refresh Plugins";
            this.refreshPluginButton.UseVisualStyleBackColor = true;
            // 
            // removePluginButton
            // 
            this.removePluginButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.removePluginButton.Location = new System.Drawing.Point(0, 23);
            this.removePluginButton.Name = "removePluginButton";
            this.removePluginButton.Size = new System.Drawing.Size(194, 23);
            this.removePluginButton.TabIndex = 3;
            this.removePluginButton.Text = "Remove Plugin";
            this.removePluginButton.UseVisualStyleBackColor = true;
            // 
            // addPluginButton
            // 
            this.addPluginButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addPluginButton.Location = new System.Drawing.Point(0, 0);
            this.addPluginButton.Name = "addPluginButton";
            this.addPluginButton.Size = new System.Drawing.Size(194, 23);
            this.addPluginButton.TabIndex = 2;
            this.addPluginButton.Text = "Add Plugin";
            this.addPluginButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(194, 526);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(537, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "The Add Plugin button is only copying the asm in the Plugins folder of your proje" +
    "ct, this can be done manually too\r\nremoving the plugin from the project will rem" +
    "ove all settings for it too";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Plugin Description : ";
            // 
            // pluginDescriptionTextbox
            // 
            this.pluginDescriptionTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pluginDescriptionTextbox.Enabled = false;
            this.pluginDescriptionTextbox.Location = new System.Drawing.Point(0, 13);
            this.pluginDescriptionTextbox.Multiline = true;
            this.pluginDescriptionTextbox.Name = "pluginDescriptionTextbox";
            this.pluginDescriptionTextbox.Size = new System.Drawing.Size(662, 74);
            this.pluginDescriptionTextbox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Plugin Settings : ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pluginDescriptionTextbox);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.pluginAuthorLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(194, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(662, 100);
            this.panel3.TabIndex = 7;
            // 
            // pluginAuthorLabel
            // 
            this.pluginAuthorLabel.AutoSize = true;
            this.pluginAuthorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pluginAuthorLabel.Location = new System.Drawing.Point(0, 87);
            this.pluginAuthorLabel.Name = "pluginAuthorLabel";
            this.pluginAuthorLabel.Size = new System.Drawing.Size(79, 13);
            this.pluginAuthorLabel.TabIndex = 5;
            this.pluginAuthorLabel.Text = "Plugin Author : ";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.propertiesPanel);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(194, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(662, 426);
            this.panel4.TabIndex = 8;
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesPanel.Location = new System.Drawing.Point(0, 13);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Size = new System.Drawing.Size(662, 413);
            this.propertiesPanel.TabIndex = 6;
            // 
            // AsmPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 552);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "AsmPlugin";
            this.Text = "Asm Plugins";
            this.Load += new System.EventHandler(this.AsmPlugin_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button removePluginButton;
        private System.Windows.Forms.Button addPluginButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pluginDescriptionTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label pluginAuthorLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button refreshPluginButton;
        private System.Windows.Forms.ListBox pluginListbox;
        private System.Windows.Forms.Panel propertiesPanel;
    }
}