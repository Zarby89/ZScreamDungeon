using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
	public partial class DungeonPropertiesForm : Gui.ScreamForm
	{
		DungeonProperty[] properties = new DungeonProperty[12];

		bool changedFromForm = false;
		public DungeonPropertiesForm(ZScreamer parent) : base(parent)
		{
			InitializeComponent();
		}

		// TODO move elsewhere for consistency
		private void DungeonPropertiesForm_Load(object sender, EventArgs e)
		{
			listBox1.Items.Add("Pendant 1 - Green (Eastern)");
			listBox1.Items.Add("Pendant 2 - Blue (Desert)");
			listBox1.Items.Add("Pendant 3 - Red (Hera)");
			listBox1.Items.Add("Agahnim 1");
			listBox1.Items.Add("Crystal 2 (Swamp)");
			listBox1.Items.Add("Crystal 1 (Darkness)");
			listBox1.Items.Add("Crystal 3 (Skullswood)");
			listBox1.Items.Add("Crystal 6 (Mire)");
			listBox1.Items.Add("Crystal 5 (Ice)");
			listBox1.Items.Add("Crystal 7 (Turtle)");
			listBox1.Items.Add("Crystal 4 (Thieves)");
			listBox1.Items.Add("Agahnim 2");

			for (int i = 0; i < 12; i++)
			{
				properties[i] = new DungeonProperty
				(
					ZS.ROM[ZS.Offsets.dungeons_startrooms + i],
					ZS.ROM[ZS.Offsets.dungeons_endrooms + i],
					ZS.ROM[ZS.Offsets.dungeons_bossrooms + (i * 2), 2]
				);
			}

			listBox1.SelectedIndex = 0;
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			changedFromForm = true;
			startroomTextbox.Text = properties[listBox1.SelectedIndex].startroom.ToString();
			endroomTextbox.Text = properties[listBox1.SelectedIndex].endroom.ToString();
			bossroomTextbox.Text = properties[listBox1.SelectedIndex].bossroom.ToString();
			changedFromForm = false;
		}

		private void bossroomTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!changedFromForm)
			{
				if (int.TryParse(startroomTextbox.Text, out int r))
				{
					properties[listBox1.SelectedIndex].startroom = (byte) r;
				}
				if (int.TryParse(endroomTextbox.Text, out r))
				{
					properties[listBox1.SelectedIndex].endroom = (byte) r;
				}
				if (int.TryParse(bossroomTextbox.Text, out r))
				{
					properties[listBox1.SelectedIndex].bossroom = (ushort) r;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 12; i++)
			{
				ZS.ROM[ZS.Offsets.dungeons_startrooms + i] = properties[i].startroom;
				ZS.ROM[ZS.Offsets.dungeons_endrooms + i] = properties[i].endroom;
				ZS.ROM[ZS.Offsets.dungeons_bossrooms + (i * 2), 2] = properties[i].bossroom;
			}

			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}
	}

	public class DungeonProperty
	{
		public byte startroom = 0;
		public byte endroom = 0;
		public ushort bossroom = 0;

		public DungeonProperty(byte startroom, byte endroom, ushort bossroom)
		{
			this.startroom = startroom;
			this.endroom = endroom;
			this.bossroom = bossroom;
		}
	}
}
