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
using ZeldaFullEditor.Gui;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor
{
	public partial class Chestviewer : UserControl
	{
		ColorPalette palettes = null;
		public bool showName = false;

		public int selectedIndex = 0; // Setted on 0 by default
		public event EventHandler SelectedIndexChanged;

		public Chest selectedObject = null;

		public List<Chest> items = new List<Chest>();

		public Chestviewer()
		{
			InitializeComponent();
		}

		private void Chestviewer_Load(object sender, EventArgs e)
		{
			// TODO: add something here?
		}

		private void ObjectViewer_Paint(object sender, PaintEventArgs e)
		{
			// TODO: add something here?
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.Clear(Color.Black);
			int w = (this.Size.Width / 64);
			int h = (((items.Count / w) + 1) * 64);
			int xpos = 0;
			int ypos = 0;

			foreach (Chest o in items)
			{
				e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.previewChestsBitmap[o.item], new Point((xpos * 64) + 24, (ypos * 64) + 8));
				if (selectedObject == o)
				{
					e.Graphics.FillRectangle(Constants.FifthBlueBrush, new Rectangle(xpos * 64, (ypos * 64), 64, 64));
				}

				e.Graphics.DrawRectangle(Pens.DarkGray, new Rectangle(xpos * 64, ypos * 64, 64, 64));
				if (!showName)
				{
					e.Graphics.DrawString(ChestItems_Name.name[o.item], this.Font, Brushes.White, new Rectangle(xpos * 64, (ypos * 64) + 32, 64, 32));
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
				palettes = ZScreamer.ActiveGraphicsManager.previewChestsBitmap[items[0].item].Palette;

				int pindex = 0;
				for (int y = 0; y < ZScreamer.ActiveGraphicsManager.loadedPalettes.GetLength(1); y++)
				{
					for (int x = 0; x < ZScreamer.ActiveGraphicsManager.loadedPalettes.GetLength(0); x++)
					{
						palettes.Entries[pindex++] = ZScreamer.ActiveGraphicsManager.loadedPalettes[x, y];
					}
				}

				for (int y = 0; y < ZScreamer.ActiveGraphicsManager.loadedSprPalettes.GetLength(1); y++)
				{
					for (int x = 0; x < ZScreamer.ActiveGraphicsManager.loadedSprPalettes.GetLength(0); x++)
					{
						if (pindex < 256)
						{
							palettes.Entries[pindex++] = ZScreamer.ActiveGraphicsManager.loadedSprPalettes[x, y];
						}
					}
				}

				for (int i = 0; i < 16; i++)
				{
					palettes.Entries[i * 16] = Color.Transparent;
					palettes.Entries[(i * 16) + 8] = Color.Transparent;
				}
			}

			foreach (Chest o in items)
			{
				unsafe
				{
					byte* ptr = (byte*) ZScreamer.ActiveGraphicsManager.previewChestsPtr[o.item].ToPointer();
					for (int i = 0; i < (64 * 64); i++)
					{
						ptr[i] = 0;
					}
				}

				o.ItemsDraw(o.item, 0, 0);
				if (palettes != null)
				{
					ZScreamer.ActiveGraphicsManager.previewChestsBitmap[o.item].Palette = palettes;
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

			foreach (Chest o in items)
			{
				Rectangle itemRect = new Rectangle(xpos * 64, ypos * 64, 64, 64);
				if (itemRect.Contains(new Point(e.X, e.Y)))
				{
					selectedIndex = index;
					selectedObject = o;
				}

				xpos++;
				if (xpos >= w)
				{
					xpos = 0;
					ypos++;
				}

				index++;
			}

			OnValueChanged(new EventArgs());
			Refresh();
		}
	}
}
