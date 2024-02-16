using System;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui.ExtraForms
{
	public partial class ZSUWProperties : Form
	{
		public ZSUWProperties()
		{
			InitializeComponent();
		}
		public string Properties = string.Empty;
		public string chestItems = string.Empty;
		public string chestItemsInfos = string.Empty;
		public string chestItemsBasic = string.Empty;
		private void ZSUWProperties_Load(object sender, EventArgs e)
		{
			itemsInfosTextbox.Height = 1000;
			itemsInfosTextbox.Visible = false;
			detaiItems.Checked = false;
			label1.Text = Properties;
			detaiItems.Text = chestItems;
			itemsInfosTextbox.Text = chestItemsInfos;
			basicchestLabel.Text = chestItemsBasic;
		}

		private void detaiItems_CheckedChanged(object sender, EventArgs e)
		{
			itemsInfosTextbox.Visible = detaiItems.Checked;
		}
	}
}
