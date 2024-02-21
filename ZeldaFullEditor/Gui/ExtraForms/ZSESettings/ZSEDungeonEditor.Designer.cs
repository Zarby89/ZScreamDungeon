namespace ZeldaFullEditor.Gui.ExtraForms.ZSESettings
{
    partial class ZSEDungeon
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
            this.roommapGroupbox = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.selectedopenedroomexportLabel = new System.Windows.Forms.Label();
            this.openedroomexportColorPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.selectforexportLabel = new System.Windows.Forms.Label();
            this.selectedforexportColorPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.openedroomscolorLabel = new System.Windows.Forms.Label();
            this.openedroomColorPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openedroomColorLabel = new System.Windows.Forms.Label();
            this.openedselectedroomColorPanel = new System.Windows.Forms.Panel();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.roommapGroupbox.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // roommapGroupbox
            // 
            this.roommapGroupbox.Controls.Add(this.panel5);
            this.roommapGroupbox.Controls.Add(this.panel2);
            this.roommapGroupbox.Controls.Add(this.panel3);
            this.roommapGroupbox.Controls.Add(this.panel1);
            this.roommapGroupbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.roommapGroupbox.Location = new System.Drawing.Point(0, 0);
            this.roommapGroupbox.Name = "roommapGroupbox";
            this.roommapGroupbox.Size = new System.Drawing.Size(473, 184);
            this.roommapGroupbox.TabIndex = 0;
            this.roommapGroupbox.TabStop = false;
            this.roommapGroupbox.Text = "Dungeon rooms map colors";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.selectedopenedroomexportLabel);
            this.panel5.Controls.Add(this.openedroomexportColorPanel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 88);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(467, 24);
            this.panel5.TabIndex = 5;
            // 
            // selectedopenedroomexportLabel
            // 
            this.selectedopenedroomexportLabel.AutoSize = true;
            this.selectedopenedroomexportLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedopenedroomexportLabel.Location = new System.Drawing.Point(24, 0);
            this.selectedopenedroomexportLabel.MinimumSize = new System.Drawing.Size(0, 22);
            this.selectedopenedroomexportLabel.Name = "selectedopenedroomexportLabel";
            this.selectedopenedroomexportLabel.Size = new System.Drawing.Size(226, 22);
            this.selectedopenedroomexportLabel.TabIndex = 2;
            this.selectedopenedroomexportLabel.Text = "Selected opened room for image export outline";
            this.selectedopenedroomexportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openedroomexportColorPanel
            // 
            this.openedroomexportColorPanel.BackColor = System.Drawing.Color.SeaGreen;
            this.openedroomexportColorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.openedroomexportColorPanel.Location = new System.Drawing.Point(0, 0);
            this.openedroomexportColorPanel.Name = "openedroomexportColorPanel";
            this.openedroomexportColorPanel.Size = new System.Drawing.Size(24, 24);
            this.openedroomexportColorPanel.TabIndex = 3;
            this.openedroomexportColorPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Colors_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.selectforexportLabel);
            this.panel2.Controls.Add(this.selectedforexportColorPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(467, 24);
            this.panel2.TabIndex = 3;
            // 
            // selectforexportLabel
            // 
            this.selectforexportLabel.AutoSize = true;
            this.selectforexportLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectforexportLabel.Location = new System.Drawing.Point(24, 0);
            this.selectforexportLabel.MinimumSize = new System.Drawing.Size(0, 22);
            this.selectforexportLabel.Name = "selectforexportLabel";
            this.selectforexportLabel.Size = new System.Drawing.Size(187, 22);
            this.selectforexportLabel.TabIndex = 2;
            this.selectforexportLabel.Text = "Selected room for image export outline";
            this.selectforexportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selectedforexportColorPanel
            // 
            this.selectedforexportColorPanel.BackColor = System.Drawing.Color.DarkTurquoise;
            this.selectedforexportColorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.selectedforexportColorPanel.Location = new System.Drawing.Point(0, 0);
            this.selectedforexportColorPanel.Name = "selectedforexportColorPanel";
            this.selectedforexportColorPanel.Size = new System.Drawing.Size(24, 24);
            this.selectedforexportColorPanel.TabIndex = 2;
            this.selectedforexportColorPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Colors_MouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.openedroomscolorLabel);
            this.panel3.Controls.Add(this.openedroomColorPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(467, 24);
            this.panel3.TabIndex = 4;
            // 
            // openedroomscolorLabel
            // 
            this.openedroomscolorLabel.AutoSize = true;
            this.openedroomscolorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openedroomscolorLabel.Location = new System.Drawing.Point(24, 0);
            this.openedroomscolorLabel.MinimumSize = new System.Drawing.Size(0, 22);
            this.openedroomscolorLabel.Name = "openedroomscolorLabel";
            this.openedroomscolorLabel.Size = new System.Drawing.Size(136, 22);
            this.openedroomscolorLabel.TabIndex = 2;
            this.openedroomscolorLabel.Text = "Opened rooms color outline";
            this.openedroomscolorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openedroomColorPanel
            // 
            this.openedroomColorPanel.BackColor = System.Drawing.Color.LimeGreen;
            this.openedroomColorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.openedroomColorPanel.Location = new System.Drawing.Point(0, 0);
            this.openedroomColorPanel.Name = "openedroomColorPanel";
            this.openedroomColorPanel.Size = new System.Drawing.Size(24, 24);
            this.openedroomColorPanel.TabIndex = 1;
            this.openedroomColorPanel.Tag = "";
            this.openedroomColorPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Colors_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.openedroomColorLabel);
            this.panel1.Controls.Add(this.openedselectedroomColorPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 24);
            this.panel1.TabIndex = 0;
            // 
            // openedroomColorLabel
            // 
            this.openedroomColorLabel.AutoSize = true;
            this.openedroomColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openedroomColorLabel.Location = new System.Drawing.Point(24, 0);
            this.openedroomColorLabel.MinimumSize = new System.Drawing.Size(0, 22);
            this.openedroomColorLabel.Name = "openedroomColorLabel";
            this.openedroomColorLabel.Size = new System.Drawing.Size(174, 22);
            this.openedroomColorLabel.TabIndex = 2;
            this.openedroomColorLabel.Text = "Opened selected room color outline";
            this.openedroomColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openedselectedroomColorPanel
            // 
            this.openedselectedroomColorPanel.BackColor = System.Drawing.Color.Lime;
            this.openedselectedroomColorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.openedselectedroomColorPanel.Location = new System.Drawing.Point(0, 0);
            this.openedselectedroomColorPanel.Name = "openedselectedroomColorPanel";
            this.openedselectedroomColorPanel.Size = new System.Drawing.Size(24, 24);
            this.openedselectedroomColorPanel.TabIndex = 0;
            this.openedselectedroomColorPanel.Tag = "";
            this.openedselectedroomColorPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.openedroomColorPanel_Paint);
            this.openedselectedroomColorPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Colors_MouseDoubleClick);
            // 
            // ZSEDungeon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roommapGroupbox);
            this.Name = "ZSEDungeon";
            this.Size = new System.Drawing.Size(473, 407);
            this.Load += new System.EventHandler(this.ZSEDungeon_Load);
            this.roommapGroupbox.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox roommapGroupbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.Panel openedselectedroomColorPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label selectforexportLabel;
        private System.Windows.Forms.Panel selectedforexportColorPanel;
        private System.Windows.Forms.Label openedroomColorLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label openedroomscolorLabel;
        private System.Windows.Forms.Panel openedroomColorPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label selectedopenedroomexportLabel;
        private System.Windows.Forms.Panel openedroomexportColorPanel;
    }
}
