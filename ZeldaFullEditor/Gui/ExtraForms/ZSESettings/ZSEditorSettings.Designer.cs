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
            this.sideviewPanel = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.zseDungeon1 = new ZeldaFullEditor.Gui.ExtraForms.ZSESettings.ZSEDungeon();
            this.sideviewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sideviewPanel
            // 
            this.sideviewPanel.Controls.Add(this.treeView1);
            this.sideviewPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideviewPanel.Location = new System.Drawing.Point(0, 0);
            this.sideviewPanel.Name = "sideviewPanel";
            this.sideviewPanel.Size = new System.Drawing.Size(237, 549);
            this.sideviewPanel.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(237, 549);
            this.treeView1.TabIndex = 1;
            // 
            // zseDungeon1
            // 
            this.zseDungeon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zseDungeon1.Location = new System.Drawing.Point(237, 0);
            this.zseDungeon1.Name = "zseDungeon1";
            this.zseDungeon1.Size = new System.Drawing.Size(587, 549);
            this.zseDungeon1.TabIndex = 1;
            // 
            // ZSEditorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 549);
            this.Controls.Add(this.zseDungeon1);
            this.Controls.Add(this.sideviewPanel);
            this.Name = "ZSEditorSettings";
            this.Text = "ZSEditorSettings";
            this.Load += new System.EventHandler(this.ZSEditorSettings_Load);
            this.sideviewPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sideviewPanel;
        private System.Windows.Forms.TreeView treeView1;
        private ZSEDungeon zseDungeon1;
    }
}