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
using ZeldaFullEditor.Data.DungeonObjects;

namespace ZeldaFullEditor
{
	public partial class SpritesView : Gui.ScreamControl
	{
		public List<SomeSprite> items = new List<SomeSprite>();
		ColorPalette palettes = null;

		public int selectedIndex = -1;
		public event EventHandler SelectedIndexChanged;

		public SomeSprite selectedObject = null;

		public SpritesView(ZScreamer zs) : base(zs)
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.Clear(Color.FromArgb(48, 48, 48));
			int w = Size.Width / 68;
			int h = ((items.Count / w) + 1) * 68;
			int xpos = 0;
			int ypos = 0;

			foreach (var o in items)
			{
				unsafe
				{
					byte* ptr = (byte*) ZS.GFXManager.previewSpritesPtr[o.ID].ToPointer();
					for (int i = 0; i < (64 * 64); i++)
					{
						ptr[i] = 0;
					}
				}

				o.Draw(ZS);

				e.Graphics.DrawImage(ZS.GFXManager.previewSpritesBitmap[o.ID], new Point((xpos * 64) + (xpos * 4), (ypos * 64) + (ypos * 4)));

				if (selectedObject == o)
				{
					e.Graphics.FillRectangle(Constants.FifthBlueBrush, new Rectangle(xpos * 64 + (xpos * 4), (ypos * 64) + (ypos * 4), 64, 64));
				}

				e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(xpos * 64 + (xpos * 4), ypos * 64 + (ypos * 4), 64, 64));
				e.Graphics.DrawString(o.CurrentType.VanillaName, Constants.Arial7, Brushes.White, new Rectangle(xpos * 64 + (xpos * 4), (ypos * 64) + (ypos * 4) + 40, 64, 24));

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
				palettes = ZS.GFXManager.previewSpritesBitmap[items[0].ID].Palette;

				if (palettes == null) return;

				int pindex = 0;
				for (int y = 0; y < ZS.GFXManager.loadedPalettes.GetLength(1); y++)
				{
					for (int x = 0; x < ZS.GFXManager.loadedPalettes.GetLength(0); x++)
					{
						palettes.Entries[pindex++] = ZS.GFXManager.loadedPalettes[x, y];
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

				foreach (var o in items)
				{
					ZS.GFXManager.previewSpritesBitmap[o.ID].Palette = palettes;
				}
			}

			Refresh();
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

			foreach (var o in items)
			{
				if (index < items.Count)
				{
					Rectangle itemRect = new Rectangle(xpos * 64 + (xpos * 4), ypos * 64 + (ypos * 4), 64, 64);
					if (itemRect.Contains(new Point(e.X, e.Y)))
					{
						selectedIndex = index;
						selectedObject = o;
						OnValueChanged(new EventArgs());
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

			Refresh();
		}

		private void SpritesView_Load(object sender, EventArgs e)
		{
			// TODO: Add something here?
		}
	}
}
