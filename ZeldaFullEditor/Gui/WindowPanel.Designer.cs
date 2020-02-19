namespace ZeldaFullEditor.Gui
{
    partial class WindowPanel
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
            this.containerPanel = new System.Windows.Forms.Panel();
            this.titleBarPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // containerPanel
            // 
            this.containerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 24);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(292, 289);
            this.containerPanel.TabIndex = 0;
            // 
            // titleBarPanel
            // 
            this.titleBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBarPanel.Location = new System.Drawing.Point(0, 0);
            this.titleBarPanel.Name = "titleBarPanel";
            this.titleBarPanel.Size = new System.Drawing.Size(292, 24);
            this.titleBarPanel.TabIndex = 1;
            this.titleBarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.titleBarPanel_Paint);
            this.titleBarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBarPanel_MouseDown);
            this.titleBarPanel.MouseLeave += new System.EventHandler(this.titleBarPanel_MouseLeave);
            this.titleBarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBarPanel_MouseMove);
            this.titleBarPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleBarPanel_MouseUp);
            // 
            // WindowPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.titleBarPanel);
            this.Name = "WindowPanel";
            this.Size = new System.Drawing.Size(292, 313);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel containerPanel;
        public System.Windows.Forms.Panel titleBarPanel;
    }
}
