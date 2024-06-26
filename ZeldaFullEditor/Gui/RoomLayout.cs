﻿using System;
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
    public partial class RoomLayout : Form
    {
        public SceneUW scene;

        public RoomLayout(DungeonMain f)
        {
            InitializeComponent();
            /*
            foreach (string s in Directory.EnumerateDirectories("Layout\\"))
            {
                tabControl1.TabPages.Add(Path.GetFileName(s));
            }
            */

            scene = new SceneUW(f);
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
            scene.need_refresh = true;
            scene.room.chest_list.Clear();
            scene.room.layout = 7;
            scene.room.tilesObjects.Clear();
            scene.room.sprites.Clear();
            scene.room.pot_items.Clear();
            scene.room.selectedObject.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearRoom();
            // Add layout objects !
            string f = (string)listBox1.Items[listBox1.SelectedIndex];
            BinaryReader br = new BinaryReader(new FileStream("Layout\\" + f, FileMode.Open, FileAccess.Read));

            string type = br.ReadString();
            List<SaveObject> data = new List<SaveObject>();
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                data.Add(new SaveObject(br, typeof(Room_Object)));
            }

            foreach (SaveObject o in data)
            {
                if (o.Type == typeof(Room_Object))
                {
                    Room_Object ro = scene.room.addObject(o.TileID, o.X, o.Y, o.Size, o.Layer);
                    if (ro != null)
                    {
                        ro.setRoom(scene.room);
                        ro.options = o.Options;
                        scene.room.tilesObjects.Add(ro);
                    }
                }
            }

            scene.room.reloadGfx();

            scene.DrawRoom();
            scene.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: Add something here?
        }
    }
}
