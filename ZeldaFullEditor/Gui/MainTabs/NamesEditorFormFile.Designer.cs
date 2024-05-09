namespace ZeldaFullEditor.Gui.MainTabs
{
    partial class NamesEditorFormFile
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.defaultnamesTextbox = new System.Windows.Forms.TextBox();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.defaultnamesTextbox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(639, 553);
            this.mainPanel.TabIndex = 0;
            // 
            // defaultnamesTextbox
            // 
            this.defaultnamesTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultnamesTextbox.Location = new System.Drawing.Point(0, 0);
            this.defaultnamesTextbox.Multiline = true;
            this.defaultnamesTextbox.Name = "defaultnamesTextbox";
            this.defaultnamesTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.defaultnamesTextbox.Size = new System.Drawing.Size(639, 553);
            this.defaultnamesTextbox.TabIndex = 0;
            this.defaultnamesTextbox.WordWrap = false;
            // 
            // NamesEditorFormFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "NamesEditorFormFile";
            this.Size = new System.Drawing.Size(639, 553);
            this.VisibleChanged += new System.EventHandler(this.NamesEditorFormFile_VisibleChanged);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        public System.Windows.Forms.TextBox defaultnamesTextbox;
    }
}
