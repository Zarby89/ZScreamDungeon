namespace ZeldaFullEditor.Gui
{
    partial class DamageClassControl
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
            this.components = new System.ComponentModel.Container();
            this.buttonStartTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonStartTimer
            // 
            this.buttonStartTimer.Interval = 200;
            this.buttonStartTimer.Tick += new System.EventHandler(this.buttonStartTimer_Tick);
            // 
            // buttonTimer
            // 
            this.buttonTimer.Interval = 30;
            this.buttonTimer.Tick += new System.EventHandler(this.buttonTimer_Tick);
            // 
            // DamageClassControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DamageClassControl";
            this.Size = new System.Drawing.Size(522, 408);
            this.Load += new System.EventHandler(this.DamageClassControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DamageClassControl_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DamageClassControl_MouseDown);
            this.MouseLeave += new System.EventHandler(this.DamageClassControl_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DamageClassControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DamageClassControl_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer buttonStartTimer;
        private System.Windows.Forms.Timer buttonTimer;
    }
}
