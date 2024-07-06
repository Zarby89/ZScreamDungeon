namespace ZeldaFullEditor
{
    partial class GotoRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GotoRoom));
            this.btnGo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkParseAsHex = new System.Windows.Forms.CheckBox();
            this.gbxRoomNumber = new System.Windows.Forms.GroupBox();
            this.tbxRoomNumber = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.gbxRoomNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            resources.ApplyResources(this.btnGo, "btnGo");
            this.btnGo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGo.Name = "btnGo";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkParseAsHex
            // 
            resources.ApplyResources(this.chkParseAsHex, "chkParseAsHex");
            this.chkParseAsHex.Checked = true;
            this.chkParseAsHex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkParseAsHex.Name = "chkParseAsHex";
            this.chkParseAsHex.UseVisualStyleBackColor = true;
            this.chkParseAsHex.CheckedChanged += new System.EventHandler(this.ParseAsHex_CheckedChanged);
            // 
            // gbxRoomNumber
            // 
            resources.ApplyResources(this.gbxRoomNumber, "gbxRoomNumber");
            this.gbxRoomNumber.Controls.Add(this.tbxRoomNumber);
            this.gbxRoomNumber.Controls.Add(this.chkParseAsHex);
            this.gbxRoomNumber.Name = "gbxRoomNumber";
            this.gbxRoomNumber.TabStop = false;
            // 
            // tbxRoomNumber
            // 
            this.tbxRoomNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxRoomNumber.Decimal = false;
            this.tbxRoomNumber.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Three;
            this.tbxRoomNumber.HexValue = 0;
            resources.ApplyResources(this.tbxRoomNumber, "tbxRoomNumber");
            this.tbxRoomNumber.MaxValue = 320;
            this.tbxRoomNumber.MinValue = 0;
            this.tbxRoomNumber.Name = "tbxRoomNumber";
            // 
            // GotoRoom
            // 
            this.AcceptButton = this.btnGo;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.gbxRoomNumber);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GotoRoom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.gbxRoomNumber.ResumeLayout(false);
            this.gbxRoomNumber.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkParseAsHex;
        private System.Windows.Forms.GroupBox gbxRoomNumber;
        private Gui.ExtraForms.Hexbox tbxRoomNumber;
    }
}