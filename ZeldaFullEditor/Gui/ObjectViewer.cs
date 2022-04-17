using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using ZeldaFullEditor.Properties;
using ZeldaFullEditor.Data.DungeonObjects;

namespace ZeldaFullEditor
{
	public partial class ObjectViewer : Gui.ScreamControl
	{
		public List<RoomObject> items = new List<RoomObject>();

		ColorPalette palettes = null;
		public bool showName = false;

		public int selectedIndex = -1;
		public event EventHandler SelectedIndexChanged;

		public RoomObject selectedObject = null;

		public ObjectViewer(ZScreamer parent) : base(parent)
		{
			InitializeComponent();
		}

		private void ObjectViewer_Paint(object sender, PaintEventArgs e)
		{
			// TODO: Add something here?
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.Clear(Color.Black);
			int w = (this.Size.Width / 64);
			int h = (((items.Count / w) + 1) * 64);
			int xpos = 0;
			int ypos = 0;

			foreach (RoomObject o in items)
			{
				e.Graphics.DrawImage(ZS.GFXManager.previewObjectsBitmap[o.ID], new Point(xpos * 64, ypos * 64));

				if (Settings.Default.favoriteObjects[o.ID] == "true")
				{
					e.Graphics.DrawImage(ZS.GFXManager.favStar2, new Rectangle((xpos * 64) + 40, (ypos * 64) + 40, 16, 16));
				}
				else
				{
					e.Graphics.DrawImage(ZS.GFXManager.favStar1, new Rectangle((xpos * 64) + 40, (ypos * 64) + 40, 16, 16));
				}

				if (selectedObject == o)
				{
					e.Graphics.FillRectangle(Constants.FifthBlueBrush, new Rectangle(xpos * 64, (ypos * 64), 64, 64));
				}

				e.Graphics.DrawRectangle(Pens.DarkGray, new Rectangle(xpos * 64, ypos * 64, 64, 64));
				if (!showName)
				{
					e.Graphics.DrawString(o.ID.ToString("X3"), this.Font, Brushes.White, new Rectangle(xpos * 64, (ypos * 64) + 48, 64, 64));
				}
				else
				{
					e.Graphics.DrawString(o.ID.ToString("X3") + o.ObjectType.VanillaName.ToString(), this.Font, Brushes.White, new Rectangle(xpos * 64, (ypos * 64) + 24, 64, 40));
				}

				xpos++;
				if (xpos >= w)
				{
					xpos = 0;
					ypos++;
				}
			}

			base.OnPaint(e);
		}

		protected virtual void OnValueChanged(EventArgs e)
		{
			SelectedIndexChanged?.Invoke(this, e);
		}

		public override void Refresh()
		{
			base.Refresh();
		}

		private void ObjectViewer_SizeChanged(object sender, EventArgs e)
		{
			Refresh();
		}

		public void updateSize()
		{
			int w = (this.Size.Width / 64);
			int h = (((items.Count / w) + 1) * 64);
			this.Size = new Size(this.Size.Width, h);

			if (items.Count > 0)
			{
				palettes = ZS.GFXManager.previewObjectsBitmap[items[0].ID].Palette;

				int pindex = 0;
				for (int y = 0; y < ZS.GFXManager.loadedPalettes.GetLength(1); y++)
				{
					for (int x = 0; x < ZS.GFXManager.loadedPalettes.GetLength(0); x++)
					{
						palettes.Entries[pindex] = ZS.GFXManager.loadedPalettes[x, y];
						pindex++;
					}
				}

				for (int y = 0; y < ZS.GFXManager.loadedSprPalettes.GetLength(1); y++)
				{
					for (int x = 0; x < ZS.GFXManager.loadedSprPalettes.GetLength(0); x++)
					{
						if (pindex < 256)
						{
							palettes.Entries[pindex++] = ZS.GFXManager.loadedSprPalettes[x, y];
						}
					}
				}

				for (int i = 0; i < 16; i++)
				{
					palettes.Entries[i * 16] = Color.Transparent;
					palettes.Entries[(i * 16) + 8] = Color.Transparent;
				}
			}

			foreach (RoomObject o in items)
			{
				o.Size = 5;
				unsafe
				{
					byte* ptr = (byte*) ZS.GFXManager.previewObjectsPtr[o.ID].ToPointer();
					for (int i = 0; i < (64 * 64); i++)
					{
						ptr[i] = 0;
					}
				}

				o.Draw(ZS);
				if (palettes != null)
				{
					ZS.GFXManager.previewObjectsBitmap[o.ID].Palette = palettes;
				}
			}
		}

		private void ObjectViewer_Load(object sender, EventArgs e)
		{
			// TODO: Add something here?
		}

		private void ObjectViewer_MouseClick(object sender, MouseEventArgs e)
		{
			int w = (this.Size.Width / 64);
			int h = (((items.Count / w) + 1) * 64);
			int xpos = 0;
			int ypos = 0;
			int index = 0;
			this.Size = new Size(this.Size.Width, h);
			foreach (RoomObject o in items)
			{
				if (index < items.Count)
				{
					Rectangle itemRect = new Rectangle(xpos * 64, ypos * 64, 64, 64);
					Rectangle itemstarRect = new Rectangle((xpos * 64) + 44, (ypos * 64) + 44, 16, 16);
					if (itemRect.Contains(new Point(e.X, e.Y)))
					{
						selectedIndex = index;
						selectedObject = o;
						if (itemstarRect.Contains((new Point(e.X, e.Y))))
						{
							// Make Favourite or not
							if (Settings.Default.favoriteObjects[o.ID] == "true")
							{
								Settings.Default.favoriteObjects[o.ID] = "false";
							}
							else
							{
								Settings.Default.favoriteObjects[o.ID] = "true";
							}
						}

						OnValueChanged(new EventArgs());
						Refresh();
						return;
					}

					xpos++;
					if (xpos >= w)
					{
						xpos = 0;
						ypos++;

					}

					index++;
				}
			}
		}
	}
}
