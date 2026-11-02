namespace ZeldaFullEditor.Gui.TextEditorExtra
{
    partial class DictionariesForm
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
			this.DictionaryTable = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// DictionaryTable
			// 
			this.DictionaryTable.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
			this.DictionaryTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DictionaryTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.DictionaryTable.FullRowSelect = true;
			this.DictionaryTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.DictionaryTable.HideSelection = false;
			this.DictionaryTable.Location = new System.Drawing.Point(0, 0);
			this.DictionaryTable.MultiSelect = false;
			this.DictionaryTable.Name = "DictionaryTable";
			this.DictionaryTable.ShowGroups = false;
			this.DictionaryTable.Size = new System.Drawing.Size(424, 461);
			this.DictionaryTable.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.DictionaryTable.TabIndex = 3;
			this.DictionaryTable.UseCompatibleStateImageBehavior = false;
			this.DictionaryTable.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			this.columnHeader1.Width = 29;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Token";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 45;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Usage";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader3.Width = 43;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Text";
			this.columnHeader4.Width = 59;
			// 
			// DictionariesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 461);
			this.Controls.Add(this.DictionaryTable);
			this.MinimumSize = new System.Drawing.Size(440, 500);
			this.Name = "DictionariesForm";
			this.Text = "Dictionary Window";
			this.ResumeLayout(false);

        }

		#endregion

		public System.Windows.Forms.ListView DictionaryTable;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
	}
}