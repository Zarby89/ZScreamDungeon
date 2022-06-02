namespace ZeldaFullEditor.UserInterface.PrimaryEditors
{
	partial class GraphicsManagerForm
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.GFXSheetsTab = new System.Windows.Forms.TabPage();
			this.ExportSheetPNGButton = new System.Windows.Forms.Button();
			this.ExportSheetBinaryButton = new System.Windows.Forms.Button();
			this.ImportSheetButton = new System.Windows.Forms.Button();
			this.BigPreviewPane = new System.Windows.Forms.Panel();
			this.GoToSheetField = new ZeldaFullEditor.UserInterface.GeneralControls.Hexbox();
			this.SheetsPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.GFXGroupsTab = new System.Windows.Forms.TabPage();
			this.PalettesTab = new System.Windows.Forms.TabPage();
			this.tabControl1.SuspendLayout();
			this.GFXSheetsTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.GFXSheetsTab);
			this.tabControl1.Controls.Add(this.GFXGroupsTab);
			this.tabControl1.Controls.Add(this.PalettesTab);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1100, 700);
			this.tabControl1.TabIndex = 0;
			// 
			// GFXSheetsTab
			// 
			this.GFXSheetsTab.Controls.Add(this.ExportSheetPNGButton);
			this.GFXSheetsTab.Controls.Add(this.ExportSheetBinaryButton);
			this.GFXSheetsTab.Controls.Add(this.ImportSheetButton);
			this.GFXSheetsTab.Controls.Add(this.BigPreviewPane);
			this.GFXSheetsTab.Controls.Add(this.GoToSheetField);
			this.GFXSheetsTab.Controls.Add(this.SheetsPanel);
			this.GFXSheetsTab.Controls.Add(this.label1);
			this.GFXSheetsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.GFXSheetsTab.Location = new System.Drawing.Point(4, 22);
			this.GFXSheetsTab.Name = "GFXSheetsTab";
			this.GFXSheetsTab.Padding = new System.Windows.Forms.Padding(3);
			this.GFXSheetsTab.Size = new System.Drawing.Size(1092, 674);
			this.GFXSheetsTab.TabIndex = 0;
			this.GFXSheetsTab.Text = "Graphics sheets";
			this.GFXSheetsTab.UseVisualStyleBackColor = true;
			// 
			// ExportSheetPNGButton
			// 
			this.ExportSheetPNGButton.Location = new System.Drawing.Point(349, 229);
			this.ExportSheetPNGButton.Name = "ExportSheetPNGButton";
			this.ExportSheetPNGButton.Size = new System.Drawing.Size(186, 23);
			this.ExportSheetPNGButton.TabIndex = 5;
			this.ExportSheetPNGButton.Text = "Export as PNG";
			this.ExportSheetPNGButton.UseVisualStyleBackColor = true;
			// 
			// ExportSheetBinaryButton
			// 
			this.ExportSheetBinaryButton.Location = new System.Drawing.Point(349, 200);
			this.ExportSheetBinaryButton.Name = "ExportSheetBinaryButton";
			this.ExportSheetBinaryButton.Size = new System.Drawing.Size(186, 23);
			this.ExportSheetBinaryButton.TabIndex = 4;
			this.ExportSheetBinaryButton.Text = "Export as binary";
			this.ExportSheetBinaryButton.UseVisualStyleBackColor = true;
			// 
			// ImportSheetButton
			// 
			this.ImportSheetButton.Location = new System.Drawing.Point(349, 171);
			this.ImportSheetButton.Name = "ImportSheetButton";
			this.ImportSheetButton.Size = new System.Drawing.Size(186, 23);
			this.ImportSheetButton.TabIndex = 3;
			this.ImportSheetButton.Text = "Import graphics";
			this.ImportSheetButton.UseVisualStyleBackColor = true;
			// 
			// BigPreviewPane
			// 
			this.BigPreviewPane.BackgroundImage = global::ZeldaFullEditor.Properties.Resources.trans;
			this.BigPreviewPane.Location = new System.Drawing.Point(350, 3);
			this.BigPreviewPane.Name = "BigPreviewPane";
			this.BigPreviewPane.Size = new System.Drawing.Size(512, 128);
			this.BigPreviewPane.TabIndex = 2;
			this.BigPreviewPane.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// GoToSheetField
			// 
			this.GoToSheetField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GoToSheetField.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.GoToSheetField.HexValue = 0;
			this.GoToSheetField.Location = new System.Drawing.Point(417, 145);
			this.GoToSheetField.MaxLength = 2;
			this.GoToSheetField.Name = "GoToSheetField";
			this.GoToSheetField.Range = new ZeldaFullEditor.Gui.ExtraForms.ValueRange(0, 222);
			this.GoToSheetField.Size = new System.Drawing.Size(30, 20);
			this.GoToSheetField.TabIndex = 1;
			this.GoToSheetField.Text = "00";
			this.GoToSheetField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SheetsPanel
			// 
			this.SheetsPanel.AutoScroll = true;
			this.SheetsPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.SheetsPanel.Location = new System.Drawing.Point(3, 3);
			this.SheetsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.SheetsPanel.MinimumSize = new System.Drawing.Size(340, 668);
			this.SheetsPanel.Name = "SheetsPanel";
			this.SheetsPanel.Size = new System.Drawing.Size(340, 668);
			this.SheetsPanel.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(349, 148);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Go to sheet";
			// 
			// GFXGroupsTab
			// 
			this.GFXGroupsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.GFXGroupsTab.Location = new System.Drawing.Point(4, 22);
			this.GFXGroupsTab.Name = "GFXGroupsTab";
			this.GFXGroupsTab.Padding = new System.Windows.Forms.Padding(3);
			this.GFXGroupsTab.Size = new System.Drawing.Size(1092, 674);
			this.GFXGroupsTab.TabIndex = 1;
			this.GFXGroupsTab.Text = "Graphics groups";
			this.GFXGroupsTab.UseVisualStyleBackColor = true;
			// 
			// PalettesTab
			// 
			this.PalettesTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.PalettesTab.Location = new System.Drawing.Point(4, 22);
			this.PalettesTab.Name = "PalettesTab";
			this.PalettesTab.Size = new System.Drawing.Size(1092, 674);
			this.PalettesTab.TabIndex = 2;
			this.PalettesTab.Text = "Palettes";
			this.PalettesTab.UseVisualStyleBackColor = true;
			// 
			// GraphicsManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl1);
			this.Name = "GraphicsManagerForm";
			this.Size = new System.Drawing.Size(1100, 700);
			this.tabControl1.ResumeLayout(false);
			this.GFXSheetsTab.ResumeLayout(false);
			this.GFXSheetsTab.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private TabControl tabControl1;
		private TabPage GFXSheetsTab;
		private TabPage GFXGroupsTab;
		private TabPage PalettesTab;
		private Panel SheetsPanel;
		private Hexbox GoToSheetField;
		private Label label1;
		private Panel BigPreviewPane;
		private Button ExportSheetPNGButton;
		private Button ExportSheetBinaryButton;
		private Button ImportSheetButton;
	}
}
