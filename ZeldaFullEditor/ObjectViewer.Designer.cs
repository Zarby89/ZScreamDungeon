﻿namespace ZeldaFullEditor
{
    partial class ObjectViewer
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
            this.SuspendLayout();
            // 
            // ObjectViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(0, 180);
            this.Name = "ObjectViewer";
            this.Size = new System.Drawing.Size(356, 380);
            this.Load += new System.EventHandler(this.ObjectViewer_Load);
            this.SizeChanged += new System.EventHandler(this.ObjectViewer_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ObjectViewer_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ObjectViewer_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
