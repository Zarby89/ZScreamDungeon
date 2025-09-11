namespace ZeldaFullEditor.Gui.ExtraForms
{
    partial class TransportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.mapDestinationBox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.worldComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Map Destination: (Only for Whirlpools)";
            // 
            // mapDestinationBox
            // 
            this.mapDestinationBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mapDestinationBox.Decimal = false;
            this.mapDestinationBox.HexValue = 0;
            this.mapDestinationBox.Location = new System.Drawing.Point(15, 72);
            this.mapDestinationBox.MaxValue = 160;
            this.mapDestinationBox.MinValue = 0;
            this.mapDestinationBox.Name = "mapDestinationBox";
            this.mapDestinationBox.Size = new System.Drawing.Size(194, 20);
            this.mapDestinationBox.TabIndex = 16;
            this.mapDestinationBox.Text = "00";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(53, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(134, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // worldComboBox
            // 
            this.worldComboBox.FormattingEnabled = true;
            this.worldComboBox.Items.AddRange(new object[] {
            "LW",
            "DW",
            "SW"});
            this.worldComboBox.Location = new System.Drawing.Point(15, 28);
            this.worldComboBox.MaxDropDownItems = 3;
            this.worldComboBox.Name = "worldComboBox";
            this.worldComboBox.Size = new System.Drawing.Size(194, 21);
            this.worldComboBox.TabIndex = 20;
            this.worldComboBox.Text = "LW";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "World:";
            // 
            // TransportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 146);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.worldComboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mapDestinationBox);
            this.Controls.Add(this.label1);
            this.Name = "TransportForm";
            this.Text = "TransportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public Hexbox mapDestinationBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox worldComboBox;
        private System.Windows.Forms.Label label2;
    }
}