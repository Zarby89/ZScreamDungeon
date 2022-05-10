namespace ZeldaFullEditor.Gui
{
	public partial class SearchForm : Form
	{

		public SearchForm()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			richTextBox1.Clear();
		}

		private void tileRadio_CheckedChanged(object sender, EventArgs e)
		{
			comboBox1.Items.Clear();
			if (tileRadio.Checked)
			{
				var list = new List<RoomObjectName>();
				list.Concat(DefaultEntities.ListOfSubtype1RoomObjects);
				list.Concat(DefaultEntities.ListOfSubtype2RoomObjects);
				list.Concat(DefaultEntities.ListOfSubtype3RoomObjects);
				comboBox1.DataSource = list;
			}
			else if (spriteRadio.Checked)
			{
				comboBox1.DataSource = DefaultEntities.ListOfSprites;
			}
			else if (itemRadio.Checked)
			{
				comboBox1.DataSource = DefaultEntities.ListOfSecrets;
			}
			else if (chestRadio.Checked)
			{
				comboBox1.DataSource = DefaultEntities.ListOfItemReceipts;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var v = (EntityName) comboBox1.SelectedItem;

			var f = new Func<ITypeID, bool>(o => o.TypeID == v.ID);

			if (tileRadio.Checked)
			{
				foreach (var r in ZScreamer.ActiveScreamer.all_rooms)
				{
					int l = r.Layer1Objects.Count(f);
					l += r.Layer2Objects.Count(f);
					l += r.Layer3Objects.Count(f);
					if (l > 0)
					{
						richTextBox1.AppendText($"Found in room {r.RoomID:X4} : {l} x object {v.ID:X3}\r\n");
					}
				}
			}
			else if (spriteRadio.Checked)
			{
				foreach (var r in ZScreamer.ActiveScreamer.all_rooms)
				{
					int l = r.SpritesList.Count(f);
					if (l > 0)
					{
						richTextBox1.AppendText($"Found in room {r.RoomID:X4} : {l} x sprite {v.ID:X2}\r\n");
					}
				}
			}
			else if (itemRadio.Checked)
			{
				foreach (var r in ZScreamer.ActiveScreamer.all_rooms)
				{
					int l = r.SecretsList.Count(f);
					if (l > 0)
					{
						richTextBox1.AppendText($"Found in room {r.RoomID:X4} : {l} x secret {v.ID:X2}\r\n");
					}
				}
			}
			else if (chestRadio.Checked)
			{
				foreach (var r in ZScreamer.ActiveScreamer.all_rooms)
				{
					int l = r.ChestList.Count(f);
					if (l > 0)
					{
						richTextBox1.AppendText($"Found in room {r.RoomID:X4} : {l} x item receipt {v.ID:X2}\r\n");
					}
				}
			}
		}
	}
}
