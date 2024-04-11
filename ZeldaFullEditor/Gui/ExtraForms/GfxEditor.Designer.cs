namespace ZeldaFullEditor.Gui.ExtraForms
{
    partial class GfxEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GfxEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.penButton = new System.Windows.Forms.ToolStripButton();
            this.selButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cutButton = new System.Windows.Forms.ToolStripButton();
            this.copyButton = new System.Windows.Forms.ToolStripButton();
            this.pasteButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.fliphButton = new System.Windows.Forms.ToolStripButton();
            this.flipvButton = new System.Windows.Forms.ToolStripButton();
            this.rotleftButton = new System.Windows.Forms.ToolStripButton();
            this.rotrightButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomCombobox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.mainPicturebox = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.palettePicturebox = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicturebox)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.penButton,
            this.selButton,
            this.toolStripSeparator1,
            this.undoButton,
            this.redoButton,
            this.toolStripSeparator2,
            this.cutButton,
            this.copyButton,
            this.pasteButton,
            this.deleteButton,
            this.toolStripSeparator3,
            this.fliphButton,
            this.flipvButton,
            this.rotleftButton,
            this.rotrightButton,
            this.toolStripSeparator4,
            this.zoomCombobox,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1193, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // penButton
            // 
            this.penButton.CheckOnClick = true;
            this.penButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.penButton.Image = ((System.Drawing.Image)(resources.GetObject("penButton.Image")));
            this.penButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.penButton.Name = "penButton";
            this.penButton.Size = new System.Drawing.Size(23, 22);
            this.penButton.Text = "penButton";
            this.penButton.Click += new System.EventHandler(this.penButton_Click);
            // 
            // selButton
            // 
            this.selButton.CheckOnClick = true;
            this.selButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selButton.Image = ((System.Drawing.Image)(resources.GetObject("selButton.Image")));
            this.selButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selButton.Name = "selButton";
            this.selButton.Size = new System.Drawing.Size(23, 22);
            this.selButton.Text = "toolStripButton2";
            this.selButton.Click += new System.EventHandler(this.penButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(23, 22);
            this.undoButton.Text = "toolStripButton3";
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(23, 22);
            this.redoButton.Text = "toolStripButton4";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cutButton
            // 
            this.cutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutButton.Image = ((System.Drawing.Image)(resources.GetObject("cutButton.Image")));
            this.cutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(23, 22);
            this.cutButton.Text = "toolStripButton5";
            // 
            // copyButton
            // 
            this.copyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyButton.Image = ((System.Drawing.Image)(resources.GetObject("copyButton.Image")));
            this.copyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(23, 22);
            this.copyButton.Text = "toolStripButton6";
            // 
            // pasteButton
            // 
            this.pasteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteButton.Image")));
            this.pasteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(23, 22);
            this.pasteButton.Text = "toolStripButton7";
            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(23, 22);
            this.deleteButton.Text = "toolStripButton8";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // fliphButton
            // 
            this.fliphButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fliphButton.Image = ((System.Drawing.Image)(resources.GetObject("fliphButton.Image")));
            this.fliphButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fliphButton.Name = "fliphButton";
            this.fliphButton.Size = new System.Drawing.Size(23, 22);
            this.fliphButton.Text = "toolStripButton9";
            this.fliphButton.Click += new System.EventHandler(this.fliphButton_Click);
            // 
            // flipvButton
            // 
            this.flipvButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.flipvButton.Image = ((System.Drawing.Image)(resources.GetObject("flipvButton.Image")));
            this.flipvButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.flipvButton.Name = "flipvButton";
            this.flipvButton.Size = new System.Drawing.Size(23, 22);
            this.flipvButton.Text = "toolStripButton10";
            this.flipvButton.Click += new System.EventHandler(this.flipvButton_Click);
            // 
            // rotleftButton
            // 
            this.rotleftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotleftButton.Image = ((System.Drawing.Image)(resources.GetObject("rotleftButton.Image")));
            this.rotleftButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotleftButton.Name = "rotleftButton";
            this.rotleftButton.Size = new System.Drawing.Size(23, 22);
            this.rotleftButton.Text = "toolStripButton11";
            // 
            // rotrightButton
            // 
            this.rotrightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotrightButton.Image = ((System.Drawing.Image)(resources.GetObject("rotrightButton.Image")));
            this.rotrightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotrightButton.Name = "rotrightButton";
            this.rotrightButton.Size = new System.Drawing.Size(23, 22);
            this.rotrightButton.Text = "toolStripButton12";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // zoomCombobox
            // 
            this.zoomCombobox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.zoomCombobox.Items.AddRange(new object[] {
            "x1",
            "x2",
            "x4",
            "x8",
            "x16"});
            this.zoomCombobox.Name = "zoomCombobox";
            this.zoomCombobox.Size = new System.Drawing.Size(121, 25);
            this.zoomCombobox.Text = "x1";
            this.zoomCombobox.SelectedIndexChanged += new System.EventHandler(this.zoomCombobox_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel1.Text = "Zoom : ";
            // 
            // mainPicturebox
            // 
            this.mainPicturebox.BackColor = System.Drawing.Color.Transparent;
            this.mainPicturebox.Location = new System.Drawing.Point(3, 3);
            this.mainPicturebox.Name = "mainPicturebox";
            this.mainPicturebox.Size = new System.Drawing.Size(128, 32);
            this.mainPicturebox.TabIndex = 8;
            this.mainPicturebox.TabStop = false;
            this.mainPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPicturebox_Paint);
            this.mainPicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPicturebox_MouseDown);
            this.mainPicturebox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPicturebox_MouseMove);
            this.mainPicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPicturebox_MouseUp);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mainPanel.Controls.Add(this.mainPicturebox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 57);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1193, 872);
            this.mainPanel.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.palettePicturebox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1193, 32);
            this.panel1.TabIndex = 10;
            // 
            // palettePicturebox
            // 
            this.palettePicturebox.Location = new System.Drawing.Point(0, 0);
            this.palettePicturebox.Name = "palettePicturebox";
            this.palettePicturebox.Size = new System.Drawing.Size(256, 32);
            this.palettePicturebox.TabIndex = 9;
            this.palettePicturebox.TabStop = false;
            this.palettePicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.palettePicturebox_Paint);
            this.palettePicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.palettePicturebox_MouseDown);
            // 
            // GfxEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 929);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "GfxEditor";
            this.Text = "Gfx Sheet Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GfxEditor_FormClosing);
            this.Load += new System.EventHandler(this.GfxEditor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicturebox)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palettePicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton penButton;
        private System.Windows.Forms.ToolStripButton selButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton cutButton;
        private System.Windows.Forms.ToolStripButton copyButton;
        private System.Windows.Forms.ToolStripButton pasteButton;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton fliphButton;
        private System.Windows.Forms.ToolStripButton flipvButton;
        private System.Windows.Forms.ToolStripButton rotleftButton;
        private System.Windows.Forms.ToolStripButton rotrightButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripComboBox zoomCombobox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.PictureBox mainPicturebox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox palettePicturebox;
    }
}