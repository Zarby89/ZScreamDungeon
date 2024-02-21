namespace ZeldaFullEditor.Gui.ExtraForms.ZSESettings
{
    partial class ZSEditorSettings
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
            this.containerPanel = new System.Windows.Forms.Panel();
            this.settingPropertygrid = new System.Windows.Forms.PropertyGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.containerPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // containerPanel
            // 
            this.containerPanel.Controls.Add(this.panel1);
            this.containerPanel.Controls.Add(this.settingPropertygrid);
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 0);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(824, 549);
            this.containerPanel.TabIndex = 1;
            // 
            // settingPropertygrid
            // 
            this.settingPropertygrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingPropertygrid.HelpVisible = false;
            this.settingPropertygrid.Location = new System.Drawing.Point(0, 0);
            this.settingPropertygrid.Name = "settingPropertygrid";
            this.settingPropertygrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.settingPropertygrid.Size = new System.Drawing.Size(824, 549);
            this.settingPropertygrid.TabIndex = 0;
            this.settingPropertygrid.ToolbarVisible = false;
            this.settingPropertygrid.Paint += new System.Windows.Forms.PaintEventHandler(this.propertyGrid1_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(651, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Reset selected property";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 449);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 100);
            this.panel1.TabIndex = 1;
            // 
            // ZSEditorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 549);
            this.Controls.Add(this.containerPanel);
            this.Name = "ZSEditorSettings";
            this.Text = "ZSEditorSettings";
            this.Load += new System.EventHandler(this.ZSEditorSettings_Load);
            this.containerPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel containerPanel;
        private System.Windows.Forms.PropertyGrid settingPropertygrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}
