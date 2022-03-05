namespace ZeldaFullEditor
{
    partial class ExitEditorForm
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
            this.roomUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.mapUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.xPosUpDown = new System.Windows.Forms.NumericUpDown();
            this.xCameraUpDown = new System.Windows.Forms.NumericUpDown();
            this.xScrollUpDown = new System.Windows.Forms.NumericUpDown();
            this.yScrollUpDown = new System.Windows.Forms.NumericUpDown();
            this.yCameraUpDown = new System.Windows.Forms.NumericUpDown();
            this.yPosUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nodoorradioButton = new System.Windows.Forms.RadioButton();
            this.wooddoorradioButton = new System.Windows.Forms.RadioButton();
            this.sancdoorButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.doorxUpDown = new System.Windows.Forms.NumericUpDown();
            this.dooryUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.setPositionButton = new System.Windows.Forms.Button();
            this.automaticcheckBox = new System.Windows.Forms.CheckBox();
            this.bombdoorradioButton = new System.Windows.Forms.RadioButton();
            this.castledoorradioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.roomUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPosUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xCameraUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xScrollUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yScrollUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCameraUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPosUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doorxUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dooryUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Room Exiting From";
            // 
            // roomUpDown
            // 
            this.roomUpDown.Location = new System.Drawing.Point(15, 25);
            this.roomUpDown.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.roomUpDown.Name = "roomUpDown";
            this.roomUpDown.Size = new System.Drawing.Size(92, 20);
            this.roomUpDown.TabIndex = 1;
            this.roomUpDown.ValueChanged += new System.EventHandler(this.xPosUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Map : ";
            // 
            // mapUpDown
            // 
            this.mapUpDown.Enabled = false;
            this.mapUpDown.Location = new System.Drawing.Point(113, 25);
            this.mapUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.mapUpDown.Name = "mapUpDown";
            this.mapUpDown.Size = new System.Drawing.Size(92, 20);
            this.mapUpDown.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "X Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "X Center Camera";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "X Scroll Camera";
            // 
            // xPosUpDown
            // 
            this.xPosUpDown.Location = new System.Drawing.Point(15, 64);
            this.xPosUpDown.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.xPosUpDown.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.xPosUpDown.Name = "xPosUpDown";
            this.xPosUpDown.Size = new System.Drawing.Size(92, 20);
            this.xPosUpDown.TabIndex = 7;
            this.xPosUpDown.ValueChanged += new System.EventHandler(this.xPosUpDown_ValueChanged);
            // 
            // xCameraUpDown
            // 
            this.xCameraUpDown.Location = new System.Drawing.Point(113, 64);
            this.xCameraUpDown.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.xCameraUpDown.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.xCameraUpDown.Name = "xCameraUpDown";
            this.xCameraUpDown.Size = new System.Drawing.Size(92, 20);
            this.xCameraUpDown.TabIndex = 8;
            this.xCameraUpDown.ValueChanged += new System.EventHandler(this.xPosUpDown_ValueChanged);
            // 
            // xScrollUpDown
            // 
            this.xScrollUpDown.Location = new System.Drawing.Point(211, 64);
            this.xScrollUpDown.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.xScrollUpDown.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.xScrollUpDown.Name = "xScrollUpDown";
            this.xScrollUpDown.Size = new System.Drawing.Size(92, 20);
            this.xScrollUpDown.TabIndex = 9;
            this.xScrollUpDown.ValueChanged += new System.EventHandler(this.xPosUpDown_ValueChanged);
            // 
            // yScrollUpDown
            // 
            this.yScrollUpDown.Location = new System.Drawing.Point(211, 103);
            this.yScrollUpDown.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.yScrollUpDown.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.yScrollUpDown.Name = "yScrollUpDown";
            this.yScrollUpDown.Size = new System.Drawing.Size(92, 20);
            this.yScrollUpDown.TabIndex = 15;
            this.yScrollUpDown.ValueChanged += new System.EventHandler(this.xPosUpDown_ValueChanged);
            // 
            // yCameraUpDown
            // 
            this.yCameraUpDown.Location = new System.Drawing.Point(113, 103);
            this.yCameraUpDown.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.yCameraUpDown.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.yCameraUpDown.Name = "yCameraUpDown";
            this.yCameraUpDown.Size = new System.Drawing.Size(92, 20);
            this.yCameraUpDown.TabIndex = 14;
            this.yCameraUpDown.ValueChanged += new System.EventHandler(this.xPosUpDown_ValueChanged);
            // 
            // yPosUpDown
            // 
            this.yPosUpDown.Location = new System.Drawing.Point(15, 103);
            this.yPosUpDown.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.yPosUpDown.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.yPosUpDown.Name = "yPosUpDown";
            this.yPosUpDown.Size = new System.Drawing.Size(92, 20);
            this.yPosUpDown.TabIndex = 13;
            this.yPosUpDown.ValueChanged += new System.EventHandler(this.xPosUpDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Y Scroll Camera";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Y Center Camera";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Y Position";
            // 
            // nodoorradioButton
            // 
            this.nodoorradioButton.AutoSize = true;
            this.nodoorradioButton.Location = new System.Drawing.Point(15, 129);
            this.nodoorradioButton.Name = "nodoorradioButton";
            this.nodoorradioButton.Size = new System.Drawing.Size(65, 17);
            this.nodoorradioButton.TabIndex = 16;
            this.nodoorradioButton.TabStop = true;
            this.nodoorradioButton.Text = "No Door";
            this.nodoorradioButton.UseVisualStyleBackColor = true;
            this.nodoorradioButton.CheckedChanged += new System.EventHandler(this.nodoorradioButton_CheckedChanged);
            // 
            // wooddoorradioButton
            // 
            this.wooddoorradioButton.AutoSize = true;
            this.wooddoorradioButton.Location = new System.Drawing.Point(86, 129);
            this.wooddoorradioButton.Name = "wooddoorradioButton";
            this.wooddoorradioButton.Size = new System.Drawing.Size(92, 17);
            this.wooddoorradioButton.TabIndex = 17;
            this.wooddoorradioButton.TabStop = true;
            this.wooddoorradioButton.Text = "Wooden Door";
            this.wooddoorradioButton.UseVisualStyleBackColor = true;
            this.wooddoorradioButton.CheckedChanged += new System.EventHandler(this.wooddoorradioButton_CheckedChanged);
            // 
            // sancdoorButton
            // 
            this.sancdoorButton.AutoSize = true;
            this.sancdoorButton.Location = new System.Drawing.Point(184, 129);
            this.sancdoorButton.Name = "sancdoorButton";
            this.sancdoorButton.Size = new System.Drawing.Size(99, 17);
            this.sancdoorButton.TabIndex = 18;
            this.sancdoorButton.TabStop = true;
            this.sancdoorButton.Text = "Sanctuary Door";
            this.sancdoorButton.UseVisualStyleBackColor = true;
            this.sancdoorButton.CheckedChanged += new System.EventHandler(this.wooddoorradioButton_CheckedChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(227, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(146, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Door Position X";
            // 
            // doorxUpDown
            // 
            this.doorxUpDown.Enabled = false;
            this.doorxUpDown.Location = new System.Drawing.Point(15, 188);
            this.doorxUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.doorxUpDown.Name = "doorxUpDown";
            this.doorxUpDown.Size = new System.Drawing.Size(92, 20);
            this.doorxUpDown.TabIndex = 22;
            this.doorxUpDown.ValueChanged += new System.EventHandler(this.xPosUpDown_ValueChanged);
            // 
            // dooryUpDown
            // 
            this.dooryUpDown.Enabled = false;
            this.dooryUpDown.Location = new System.Drawing.Point(113, 188);
            this.dooryUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.dooryUpDown.Name = "dooryUpDown";
            this.dooryUpDown.Size = new System.Drawing.Size(92, 20);
            this.dooryUpDown.TabIndex = 23;
            this.dooryUpDown.ValueChanged += new System.EventHandler(this.xPosUpDown_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(110, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Door PositionY";
            // 
            // setPositionButton
            // 
            this.setPositionButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.setPositionButton.Enabled = false;
            this.setPositionButton.Location = new System.Drawing.Point(215, 186);
            this.setPositionButton.Name = "setPositionButton";
            this.setPositionButton.Size = new System.Drawing.Size(87, 22);
            this.setPositionButton.TabIndex = 25;
            this.setPositionButton.Text = "Set Position";
            this.setPositionButton.UseVisualStyleBackColor = true;
            this.setPositionButton.Click += new System.EventHandler(this.setPositionButton_Click);
            // 
            // automaticcheckBox
            // 
            this.automaticcheckBox.AutoSize = true;
            this.automaticcheckBox.Location = new System.Drawing.Point(211, 25);
            this.automaticcheckBox.Name = "automaticcheckBox";
            this.automaticcheckBox.Size = new System.Drawing.Size(73, 17);
            this.automaticcheckBox.TabIndex = 26;
            this.automaticcheckBox.Text = "Automatic";
            this.automaticcheckBox.UseVisualStyleBackColor = true;
            this.automaticcheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // bombdoorradioButton
            // 
            this.bombdoorradioButton.AutoSize = true;
            this.bombdoorradioButton.Location = new System.Drawing.Point(86, 152);
            this.bombdoorradioButton.Name = "bombdoorradioButton";
            this.bombdoorradioButton.Size = new System.Drawing.Size(98, 17);
            this.bombdoorradioButton.TabIndex = 27;
            this.bombdoorradioButton.TabStop = true;
            this.bombdoorradioButton.Text = "Bombable Door";
            this.bombdoorradioButton.UseVisualStyleBackColor = true;
            this.bombdoorradioButton.CheckedChanged += new System.EventHandler(this.wooddoorradioButton_CheckedChanged);
            // 
            // castledoorradioButton
            // 
            this.castledoorradioButton.AutoSize = true;
            this.castledoorradioButton.Location = new System.Drawing.Point(184, 152);
            this.castledoorradioButton.Name = "castledoorradioButton";
            this.castledoorradioButton.Size = new System.Drawing.Size(80, 17);
            this.castledoorradioButton.TabIndex = 28;
            this.castledoorradioButton.TabStop = true;
            this.castledoorradioButton.Text = "Castle Door";
            this.castledoorradioButton.UseVisualStyleBackColor = true;
            this.castledoorradioButton.CheckedChanged += new System.EventHandler(this.wooddoorradioButton_CheckedChanged);
            // 
            // ExitEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 245);
            this.Controls.Add(this.castledoorradioButton);
            this.Controls.Add(this.bombdoorradioButton);
            this.Controls.Add(this.automaticcheckBox);
            this.Controls.Add(this.setPositionButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dooryUpDown);
            this.Controls.Add(this.doorxUpDown);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sancdoorButton);
            this.Controls.Add(this.wooddoorradioButton);
            this.Controls.Add(this.nodoorradioButton);
            this.Controls.Add(this.yScrollUpDown);
            this.Controls.Add(this.yCameraUpDown);
            this.Controls.Add(this.yPosUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.xScrollUpDown);
            this.Controls.Add(this.xCameraUpDown);
            this.Controls.Add(this.xPosUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mapUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.roomUpDown);
            this.Controls.Add(this.label1);
            this.Name = "ExitEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exit Editor";
            this.Load += new System.EventHandler(this.ExitEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPosUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xCameraUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xScrollUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yScrollUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCameraUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPosUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doorxUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dooryUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown roomUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown mapUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown xPosUpDown;
        private System.Windows.Forms.NumericUpDown xCameraUpDown;
        private System.Windows.Forms.NumericUpDown xScrollUpDown;
        private System.Windows.Forms.NumericUpDown yScrollUpDown;
        private System.Windows.Forms.NumericUpDown yCameraUpDown;
        private System.Windows.Forms.NumericUpDown yPosUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton nodoorradioButton;
        private System.Windows.Forms.RadioButton wooddoorradioButton;
        private System.Windows.Forms.RadioButton sancdoorButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown doorxUpDown;
        private System.Windows.Forms.NumericUpDown dooryUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button setPositionButton;
        private System.Windows.Forms.CheckBox automaticcheckBox;
        private System.Windows.Forms.RadioButton bombdoorradioButton;
        private System.Windows.Forms.RadioButton castledoorradioButton;
    }
}