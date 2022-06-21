namespace ZeldaFullEditor
{
	partial class ObjectViewer<TPreview>
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
			this.DoubleBuffered = true;
			this.MinimumSize = new System.Drawing.Size(0, 180);
			this.Name = "ObjectViewer";
			this.Size = new System.Drawing.Size(356, 380);
			this.SizeChanged += new System.EventHandler(this.ObjectViewer_SizeChanged);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ObjectViewer_MouseClick);
			this.ResumeLayout(false);
			this.Dock = DockStyle.Fill;
		}

		#endregion
	}
}
