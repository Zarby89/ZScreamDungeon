using System;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
	public partial class EntranceForm : Form
	{
		public EntranceForm()
		{
			InitializeComponent();
		}

		public int x;
		public int y;
		public ushort mapPos;
		public byte entranceId;
		public short mapId;
		public bool isHole;

		private void EntranceForm_Load(object sender, EventArgs e)
		{
			textBox1.HexValue = entranceId;
			textBox2.Text = mapId.ToString();
			textBox3.Text = mapPos.ToString();
			textBox4.Text = x.ToString();
			textBox5.Text = y.ToString();
			checkBox1.Checked = isHole;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int v = 0;

			entranceId = (byte) textBox1.HexValue;

			int.TryParse(textBox2.Text, out v); // Map Id

			if (v > 128 || v < 0)
			{
				MessageBox.Show("Map ID is out of range; max value is 128");
				return;
			}

			mapId = (short) v;
			int.TryParse(textBox3.Text, out v); // Map Pos (read only)

			int.TryParse(textBox4.Text, out v); // X
			if (v > 4096 || v < 0)
			{
				MessageBox.Show("X is out of range; max value is 4096");
				return;
			}

			x = (short) v;
			int.TryParse(textBox5.Text, out v); // Y
			if (v > 4096 || v < 0)
			{
				MessageBox.Show("Y is out of range; max value is 4096");
				return;
			}

			y = (short) v;

			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
