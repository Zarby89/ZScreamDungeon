using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	public partial class RoomLayout : Gui.ScreamForm
	{
		public readonly SceneUW scene;

		public RoomLayout(ZScreamer parent) : base(parent)
		{
			InitializeComponent();
			/*
            foreach (string s in Directory.EnumerateDirectories("Layout\\"))
            {
                tabControl1.TabPages.Add(Path.GetFileName(s));
            }
            */

			scene = new SceneUW(ZS);
			Controls.Add(scene);
			scene.Size = new Size(512, 512);
			scene.Location = new Point(176, 23);
			scene.Enabled = false;
		}

		private void RoomLayout_Load(object sender, EventArgs e)
		{
			clearRoom();
			scene.DrawRoom();
			scene.Refresh();
			listBox1.Items.Clear();

			string[] files = Directory.GetFiles("Layout");
			foreach (string s in files)
			{
				listBox1.Items.Add(Path.GetFileName(s));
			}
		}

		public void clearRoom()
		{
			scene.NeedsRefreshing = true;
			scene.Room.chest_list.Clear();
			scene.Room.layout = 7;
			scene.Room.tilesObjects.Clear();
			scene.Room.SpritesList.Clear();
			scene.Room.pot_items.Clear();
			scene.Room.selectedObject.Clear();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			clearRoom();
			// Add layout objects !
			string f = (string) listBox1.Items[listBox1.SelectedIndex];
			BinaryReader br = new BinaryReader(new FileStream("Layout\\" + f, FileMode.Open, FileAccess.Read));

			string type = br.ReadString();

			List<SaveObject> data = new List<SaveObject>();
			while (br.BaseStream.Position != br.BaseStream.Length)
			{
				data.Add(new SaveObject(br, typeof(Room_Object)));
			}

			foreach (SaveObject o in data)
			{
				if (o.type == typeof(Room_Object))
				{
					Room_Object ro = scene.Room.addObject(o.tid, o.x, o.y, o.size, o.layer);
					if (ro != null)
					{
						ro.setRoom(scene.Room);
						ro.options = o.options;
						scene.Room.tilesObjects.Add(ro);
					}
				}
			}

			scene.Room.reloadGfx();

			scene.DrawRoom();
			scene.Refresh();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			// TODO: Add something here?
		}
	}
}
