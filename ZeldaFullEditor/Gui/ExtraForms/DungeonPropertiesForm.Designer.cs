namespace ZeldaFullEditor.Gui
{
    partial class DungeonPropertiesForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startroomTextbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.endroomTextbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.bossroomTextbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 250);
            this.panel1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(205, 237);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dungeon list";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(337, 215);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(256, 215);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lobby room ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ending room ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Boss room ID";
            // 
            // startroomTextbox
            // 
            this.startroomTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.startroomTextbox.Decimal = false;
            this.startroomTextbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Three;
            this.startroomTextbox.HexValue = 0;
            this.startroomTextbox.Location = new System.Drawing.Point(214, 29);
            this.startroomTextbox.MaxLength = 3;
            this.startroomTextbox.MaxValue = 295;
            this.startroomTextbox.MinValue = 0;
            this.startroomTextbox.Name = "startroomTextbox";
            this.startroomTextbox.Size = new System.Drawing.Size(100, 20);
            this.startroomTextbox.TabIndex = 87;
            this.startroomTextbox.Text = "000";
            this.startroomTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startroomTextbox.TextChanged += new System.EventHandler(this.bossroomTextbox_TextChanged);
            // 
            // endroomTextbox
            // 
            this.endroomTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.endroomTextbox.Decimal = false;
            this.endroomTextbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Three;
            this.endroomTextbox.HexValue = 0;
            this.endroomTextbox.Location = new System.Drawing.Point(214, 68);
            this.endroomTextbox.MaxLength = 3;
            this.endroomTextbox.MaxValue = 295;
            this.endroomTextbox.MinValue = 0;
            this.endroomTextbox.Name = "endroomTextbox";
            this.endroomTextbox.Size = new System.Drawing.Size(100, 20);
            this.endroomTextbox.TabIndex = 88;
            this.endroomTextbox.Text = "000";
            this.endroomTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.endroomTextbox.TextChanged += new System.EventHandler(this.bossroomTextbox_TextChanged);
            // 
            // bossroomTextbox
            // 
            this.bossroomTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bossroomTextbox.Decimal = false;
            this.bossroomTextbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Three;
            this.bossroomTextbox.HexValue = 0;
            this.bossroomTextbox.Location = new System.Drawing.Point(214, 107);
            this.bossroomTextbox.MaxLength = 3;
            this.bossroomTextbox.MaxValue = 295;
            this.bossroomTextbox.MinValue = 0;
            this.bossroomTextbox.Name = "bossroomTextbox";
            this.bossroomTextbox.Size = new System.Drawing.Size(100, 20);
            this.bossroomTextbox.TabIndex = 89;
            this.bossroomTextbox.Text = "000";
            this.bossroomTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bossroomTextbox.TextChanged += new System.EventHandler(this.bossroomTextbox_TextChanged);
            // 
            // DungeonPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 250);
            this.Controls.Add(this.bossroomTextbox);
            this.Controls.Add(this.endroomTextbox);
            this.Controls.Add(this.startroomTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.panel1);
            this.Name = "DungeonPropertiesForm";
            this.Text = "Dungeons properties - Decimal Values";
            this.Load += new System.EventHandler(this.DungeonPropertiesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ExtraForms.Hexbox startroomTextbox;
        private ExtraForms.Hexbox endroomTextbox;
        private ExtraForms.Hexbox bossroomTextbox;
    }
}
