namespace ZeldaFullEditor
{
	public partial class ChestPicker : Form
	{
		public ChestPicker()
		{
			InitializeComponent();
		}

		private void ChestPicker_Load(object sender, EventArgs e)
		{
			chestviewer1.items.Clear();

			for (int i = 0; i < 76; i++)
			{
				//Chest c = new Chest(ZS, 0, 0, (byte) i, false, true);
				//chestviewer1.items.Add(c);
			}

			chestviewer1.updateSize();
		}

		private void chestviewer1_SelectedIndexChanged(object sender, EventArgs e)
		{
			idtextbox.Text = chestviewer1.selectedIndex.ToString();
		}
	}
}
