namespace ZeldaFullEditor.Gui.MainTabs
{
    partial class NamesEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NamesEditorForm));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.NamingMainPanel = new System.Windows.Forms.Panel();
            this.RoomMainPanel = new System.Windows.Forms.Panel();
            this.RoomSubPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.SpriteMainPanel = new System.Windows.Forms.Panel();
            this.SpriteSubPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemsMainPanel = new System.Windows.Forms.Panel();
            this.ItemsSubPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.ChestItemsMainPanel = new System.Windows.Forms.Panel();
            this.ChestItemsSubPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.NamingMainPanel.SuspendLayout();
            this.RoomMainPanel.SuspendLayout();
            this.SpriteMainPanel.SuspendLayout();
            this.ItemsMainPanel.SuspendLayout();
            this.ChestItemsMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 609);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 45);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(679, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Apply Changes";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // NamingMainPanel
            // 
            this.NamingMainPanel.AutoScroll = true;
            this.NamingMainPanel.Controls.Add(this.ChestItemsMainPanel);
            this.NamingMainPanel.Controls.Add(this.ItemsMainPanel);
            this.NamingMainPanel.Controls.Add(this.RoomMainPanel);
            this.NamingMainPanel.Controls.Add(this.SpriteMainPanel);
            this.NamingMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NamingMainPanel.Location = new System.Drawing.Point(0, 0);
            this.NamingMainPanel.Name = "NamingMainPanel";
            this.NamingMainPanel.Size = new System.Drawing.Size(789, 609);
            this.NamingMainPanel.TabIndex = 3;
            // 
            // RoomMainPanel
            // 
            this.RoomMainPanel.AutoScroll = true;
            this.RoomMainPanel.Controls.Add(this.RoomSubPanel);
            this.RoomMainPanel.Controls.Add(this.label3);
            this.RoomMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RoomMainPanel.Location = new System.Drawing.Point(0, 285);
            this.RoomMainPanel.Name = "RoomMainPanel";
            this.RoomMainPanel.Size = new System.Drawing.Size(772, 287);
            this.RoomMainPanel.TabIndex = 5;
            // 
            // RoomSubPanel
            // 
            this.RoomSubPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RoomSubPanel.Location = new System.Drawing.Point(0, 15);
            this.RoomSubPanel.Name = "RoomSubPanel";
            this.RoomSubPanel.Size = new System.Drawing.Size(755, 285);
            this.RoomSubPanel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Rooms Names";
            // 
            // SpriteMainPanel
            // 
            this.SpriteMainPanel.AutoScroll = true;
            this.SpriteMainPanel.Controls.Add(this.SpriteSubPanel);
            this.SpriteMainPanel.Controls.Add(this.label2);
            this.SpriteMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SpriteMainPanel.Location = new System.Drawing.Point(0, 0);
            this.SpriteMainPanel.Name = "SpriteMainPanel";
            this.SpriteMainPanel.Size = new System.Drawing.Size(772, 285);
            this.SpriteMainPanel.TabIndex = 4;
            // 
            // SpriteSubPanel
            // 
            this.SpriteSubPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SpriteSubPanel.Location = new System.Drawing.Point(0, 15);
            this.SpriteSubPanel.Name = "SpriteSubPanel";
            this.SpriteSubPanel.Size = new System.Drawing.Size(755, 285);
            this.SpriteSubPanel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sprites Names";
            // 
            // ItemsMainPanel
            // 
            this.ItemsMainPanel.AutoScroll = true;
            this.ItemsMainPanel.Controls.Add(this.ItemsSubPanel);
            this.ItemsMainPanel.Controls.Add(this.label4);
            this.ItemsMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemsMainPanel.Location = new System.Drawing.Point(0, 572);
            this.ItemsMainPanel.Name = "ItemsMainPanel";
            this.ItemsMainPanel.Size = new System.Drawing.Size(772, 177);
            this.ItemsMainPanel.TabIndex = 6;
            // 
            // ItemsSubPanel
            // 
            this.ItemsSubPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemsSubPanel.Location = new System.Drawing.Point(0, 15);
            this.ItemsSubPanel.Name = "ItemsSubPanel";
            this.ItemsSubPanel.Size = new System.Drawing.Size(772, 159);
            this.ItemsSubPanel.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Items Names";
            // 
            // ChestItemsMainPanel
            // 
            this.ChestItemsMainPanel.AutoScroll = true;
            this.ChestItemsMainPanel.Controls.Add(this.ChestItemsSubPanel);
            this.ChestItemsMainPanel.Controls.Add(this.label5);
            this.ChestItemsMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChestItemsMainPanel.Location = new System.Drawing.Point(0, 749);
            this.ChestItemsMainPanel.Name = "ChestItemsMainPanel";
            this.ChestItemsMainPanel.Size = new System.Drawing.Size(772, 177);
            this.ChestItemsMainPanel.TabIndex = 7;
            // 
            // ChestItemsSubPanel
            // 
            this.ChestItemsSubPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChestItemsSubPanel.Location = new System.Drawing.Point(0, 15);
            this.ChestItemsSubPanel.Name = "ChestItemsSubPanel";
            this.ChestItemsSubPanel.Size = new System.Drawing.Size(772, 159);
            this.ChestItemsSubPanel.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Chests Items Names";
            // 
            // NamesEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NamingMainPanel);
            this.Controls.Add(this.panel1);
            this.Name = "NamesEditorForm";
            this.Size = new System.Drawing.Size(789, 654);
            this.Load += new System.EventHandler(this.NamesEditorForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.NamingMainPanel.ResumeLayout(false);
            this.RoomMainPanel.ResumeLayout(false);
            this.RoomMainPanel.PerformLayout();
            this.SpriteMainPanel.ResumeLayout(false);
            this.SpriteMainPanel.PerformLayout();
            this.ItemsMainPanel.ResumeLayout(false);
            this.ItemsMainPanel.PerformLayout();
            this.ChestItemsMainPanel.ResumeLayout(false);
            this.ChestItemsMainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel NamingMainPanel;
        private System.Windows.Forms.Panel RoomMainPanel;
        private System.Windows.Forms.Panel RoomSubPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel SpriteMainPanel;
        private System.Windows.Forms.Panel SpriteSubPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel ChestItemsMainPanel;
        private System.Windows.Forms.Panel ChestItemsSubPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel ItemsMainPanel;
        private System.Windows.Forms.Panel ItemsSubPanel;
        private System.Windows.Forms.Label label4;
    }
}
