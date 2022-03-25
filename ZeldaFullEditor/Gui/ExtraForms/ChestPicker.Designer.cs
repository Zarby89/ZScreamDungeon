namespace ZeldaFullEditor
{
    partial class ChestPicker
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.customPanel1 = new ZeldaFullEditor.CustomPanel();
            this.chestviewer1 = new ZeldaFullEditor.Chestviewer();
            this.idtextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(440, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(522, 383);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // customPanel1
            // 
            this.customPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel1.AutoScroll = true;
            this.customPanel1.Controls.Add(this.chestviewer1);
            this.customPanel1.Location = new System.Drawing.Point(0, 0);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(609, 377);
            this.customPanel1.TabIndex = 0;
            // 
            // chestviewer1
            // 
            this.chestviewer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chestviewer1.Location = new System.Drawing.Point(0, 0);
            this.chestviewer1.Name = "chestviewer1";
            this.chestviewer1.Size = new System.Drawing.Size(592, 410);
            this.chestviewer1.TabIndex = 0;
            this.chestviewer1.SelectedIndexChanged += new System.EventHandler(this.chestviewer1_SelectedIndexChanged);
            // 
            // idtextbox
            // 
            this.idtextbox.Location = new System.Drawing.Point(334, 385);
            this.idtextbox.Name = "idtextbox";
            this.idtextbox.Size = new System.Drawing.Size(100, 20);
            this.idtextbox.TabIndex = 3;
            this.idtextbox.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selected ID";
            // 
            // ChestPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 411);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idtextbox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.customPanel1);
            this.Name = "ChestPicker";
            this.Text = "Chest Picker";
            this.Load += new System.EventHandler(this.ChestPicker_Load);
            this.customPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomPanel customPanel1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button1;
        public Chestviewer chestviewer1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox idtextbox;
    }
}
