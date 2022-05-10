namespace ZeldaFullEditor.Gui
{
	public partial class EntranceForm : Form
	{
		public EntranceForm()
		{
			InitializeComponent();
		}

		public ushort x;
		public ushort y;
		public ushort mapPos;
		public byte entranceId;
		public ushort mapId;
		public bool isHole = false;

		private void EntranceForm_Load(object sender, EventArgs e)
		{
			textBox1.Text = entranceId.ToString("X2");
			textBox2.Text = mapId.ToString();
			textBox3.Text = mapPos.ToString();
			textBox4.Text = x.ToString();
			textBox5.Text = y.ToString();
			checkBox1.Checked = isHole;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int v;
			v = textBox1.HexValue; // Entrance ID
			if (v > 132 || v < 0)
			{
				MessageBox.Show("Entrance ID is out of range; max value is 132");
				return;
			}

			entranceId = (byte) v;

			int.TryParse(textBox2.Text, out v); // Map Id

			if (v > 128 || v < 0)
			{
				MessageBox.Show("Map ID is out of range; max value is 128");
				return;
			}

			mapId = (ushort) v;
			int.TryParse(textBox3.Text, out _); // Map Pos (read only)

			int.TryParse(textBox4.Text, out v); // X
			if (v > 4096 || v < 0)
			{
				MessageBox.Show("X is out of range; max value is 4096");
				return;
			}

			x = (ushort) v;
			int.TryParse(textBox5.Text, out v); // Y
			if (v > 4096 || v < 0)
			{
				MessageBox.Show("Y is out of range; max value is 4096");
				return;
			}

			y = (ushort) v;

			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
