using System;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	public partial class RoomMover : Form
	{
		string filePath = "";

		public RoomMover()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog of = new OpenFileDialog();
			of.Filter = UIText.USROMType;
			of.DefaultExt = UIText.ROMExtension;
			if (of.ShowDialog() == DialogResult.OK)
			{
				filePath = of.FileName;
				textBox1.Text = filePath;
			}
		}

		private void RoomMover_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < Constants.NumberOfRooms; i++)
			{
				checkedListBox1.Items.Add("Room " + i.ToString("X3") + " - " + Room_Name.room_name[i], true);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
