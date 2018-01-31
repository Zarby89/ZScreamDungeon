namespace ZeldaFullEditor
{
    partial class PickObject
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nonscalableCheckbox = new System.Windows.Forms.CheckBox();
            this.verticalCheckbox = new System.Windows.Forms.CheckBox();
            this.horizontalCheckbox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sortingCombobox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tileobjectsListview = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nonscalableCheckbox);
            this.panel1.Controls.Add(this.verticalCheckbox);
            this.panel1.Controls.Add(this.horizontalCheckbox);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sortingCombobox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 52);
            this.panel1.TabIndex = 1;
            // 
            // nonscalableCheckbox
            // 
            this.nonscalableCheckbox.AutoSize = true;
            this.nonscalableCheckbox.Checked = true;
            this.nonscalableCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nonscalableCheckbox.Location = new System.Drawing.Point(365, 8);
            this.nonscalableCheckbox.Name = "nonscalableCheckbox";
            this.nonscalableCheckbox.Size = new System.Drawing.Size(90, 17);
            this.nonscalableCheckbox.TabIndex = 5;
            this.nonscalableCheckbox.Text = "Non-Scalable";
            this.nonscalableCheckbox.UseVisualStyleBackColor = true;
            this.nonscalableCheckbox.CheckedChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // verticalCheckbox
            // 
            this.verticalCheckbox.AutoSize = true;
            this.verticalCheckbox.Checked = true;
            this.verticalCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.verticalCheckbox.Location = new System.Drawing.Point(298, 8);
            this.verticalCheckbox.Name = "verticalCheckbox";
            this.verticalCheckbox.Size = new System.Drawing.Size(61, 17);
            this.verticalCheckbox.TabIndex = 4;
            this.verticalCheckbox.Text = "Vertical";
            this.verticalCheckbox.UseVisualStyleBackColor = true;
            this.verticalCheckbox.CheckedChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // horizontalCheckbox
            // 
            this.horizontalCheckbox.AutoSize = true;
            this.horizontalCheckbox.Checked = true;
            this.horizontalCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.horizontalCheckbox.Location = new System.Drawing.Point(219, 8);
            this.horizontalCheckbox.Name = "horizontalCheckbox";
            this.horizontalCheckbox.Size = new System.Drawing.Size(73, 17);
            this.horizontalCheckbox.TabIndex = 3;
            this.horizontalCheckbox.Text = "Horizontal";
            this.horizontalCheckbox.UseVisualStyleBackColor = true;
            this.horizontalCheckbox.CheckedChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Find : ";
            // 
            // sortingCombobox
            // 
            this.sortingCombobox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sortingCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortingCombobox.FormattingEnabled = true;
            this.sortingCombobox.Location = new System.Drawing.Point(0, 31);
            this.sortingCombobox.Name = "sortingCombobox";
            this.sortingCombobox.Size = new System.Drawing.Size(640, 21);
            this.sortingCombobox.TabIndex = 1;
            this.sortingCombobox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(380, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 260);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tileobjectsListview
            // 
            this.tileobjectsListview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tileobjectsListview.LargeImageList = this.imageList1;
            this.tileobjectsListview.Location = new System.Drawing.Point(6, 58);
            this.tileobjectsListview.MultiSelect = false;
            this.tileobjectsListview.Name = "tileobjectsListview";
            this.tileobjectsListview.Size = new System.Drawing.Size(374, 296);
            this.tileobjectsListview.TabIndex = 3;
            this.tileobjectsListview.TileSize = new System.Drawing.Size(370, 16);
            this.tileobjectsListview.UseCompatibleStateImageBehavior = false;
            this.tileobjectsListview.View = System.Windows.Forms.View.Tile;
            this.tileobjectsListview.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.tileobjectsListview.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(553, 324);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(472, 324);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PickObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 354);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tileobjectsListview);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PickObject";
            this.Text = "PickObject";
            this.Load += new System.EventHandler(this.PickObject_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sortingCombobox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox verticalCheckbox;
        private System.Windows.Forms.CheckBox horizontalCheckbox;
        private System.Windows.Forms.CheckBox nonscalableCheckbox;
        public System.Windows.Forms.ListView tileobjectsListview;
    }
}