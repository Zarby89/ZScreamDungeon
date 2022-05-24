namespace ZeldaFullEditor.Gui
{
    partial class PaletteEditor
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
			this.palettesTreeView = new System.Windows.Forms.TreeView();
			this.applyButton = new System.Windows.Forms.Button();
			this.restoreallButton = new System.Windows.Forms.Button();
			this.restoreselButton = new System.Windows.Forms.Button();
			this.palettePicturebox = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).BeginInit();
			this.SuspendLayout();
			// 
			// palettesTreeView
			// 
			this.palettesTreeView.Dock = System.Windows.Forms.DockStyle.Left;
			this.palettesTreeView.Location = new System.Drawing.Point(0, 0);
			this.palettesTreeView.Name = "palettesTreeView";
			this.palettesTreeView.Size = new System.Drawing.Size(200, 324);
			this.palettesTreeView.TabIndex = 0;
			this.palettesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.palettesTreeView_AfterSelect);
			// 
			// applyButton
			// 
			this.applyButton.Location = new System.Drawing.Point(387, 265);
			this.applyButton.Name = "applyButton";
			this.applyButton.Size = new System.Drawing.Size(75, 23);
			this.applyButton.TabIndex = 2;
			this.applyButton.Text = "Apply";
			this.applyButton.UseVisualStyleBackColor = true;
			this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
			// 
			// restoreallButton
			// 
			this.restoreallButton.Location = new System.Drawing.Point(306, 265);
			this.restoreallButton.Name = "restoreallButton";
			this.restoreallButton.Size = new System.Drawing.Size(75, 23);
			this.restoreallButton.TabIndex = 3;
			this.restoreallButton.Text = "Restore All";
			this.restoreallButton.UseVisualStyleBackColor = true;
			this.restoreallButton.Click += new System.EventHandler(this.restoreallButton_Click);
			// 
			// restoreselButton
			// 
			this.restoreselButton.Location = new System.Drawing.Point(206, 264);
			this.restoreselButton.Name = "restoreselButton";
			this.restoreselButton.Size = new System.Drawing.Size(94, 23);
			this.restoreselButton.TabIndex = 4;
			this.restoreselButton.Text = "Restore Select.";
			this.restoreselButton.UseVisualStyleBackColor = true;
			this.restoreselButton.Click += new System.EventHandler(this.restoreselButton_Click);
			// 
			// palettePicturebox
			// 
			this.palettePicturebox.Location = new System.Drawing.Point(206, 3);
			this.palettePicturebox.Name = "palettePicturebox";
			this.palettePicturebox.Size = new System.Drawing.Size(256, 256);
			this.palettePicturebox.TabIndex = 1;
			this.palettePicturebox.TabStop = false;
			this.palettePicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.palettePicturebox_Paint);
			this.palettePicturebox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseDoubleClick);
			this.palettePicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseDown);
			this.palettePicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseUp);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(206, 293);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Export Palettes";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.exportAllPalettes);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(306, 293);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(94, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "Import Palettes";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.importAllPalettes);
			// 
			// PaletteEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.restoreselButton);
			this.Controls.Add(this.restoreallButton);
			this.Controls.Add(this.applyButton);
			this.Controls.Add(this.palettePicturebox);
			this.Controls.Add(this.palettesTreeView);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Name = "PaletteEditor";
			this.Size = new System.Drawing.Size(468, 324);
			this.Load += new System.EventHandler(this.PaletteEditor_Load);
			((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView palettesTreeView;
        private System.Windows.Forms.PictureBox palettePicturebox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button restoreallButton;
        private System.Windows.Forms.Button restoreselButton;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}
