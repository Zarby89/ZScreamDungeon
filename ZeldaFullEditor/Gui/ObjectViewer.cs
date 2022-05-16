namespace ZeldaFullEditor
{
	public partial class ObjectViewer : UserControl
	{
		public List<RoomObjectPreview> items = new();

		ColorPalette palettes = null;
		public bool showName = false;

		public int selectedIndex = -1;
		public event EventHandler SelectedIndexChanged;

		public RoomObjectPreview selectedObject = null;

		public ObjectViewer()
		{
			InitializeComponent();
		}

		public RoomObject CreateSelectedObject()
		{
			return new RoomObject(selectedObject.ObjectType, ZScreamer.ActiveScreamer.TileLister[selectedObject.ID]);
		}


		private void ObjectViewer_Paint(object sender, PaintEventArgs e)
		{
			// TODO: Add something here?
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.Clear(Color.Black);
			int w = Size.Width & ~0x3F;
			int xpos = 0;
			int ypos = 0;

			foreach (RoomObject o in items)
			{
				e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.previewObjectsBitmap[o.ID], new Point(xpos, ypos));

				e.Graphics.DrawImage(
					Settings.Default.favoriteObjects[o.ID] == "true" ?
					GraphicsManager.favStar2 : GraphicsManager.favStar1,
					new Rectangle(xpos + 40, ypos + 40, 16, 16)
				);

				if (selectedObject == o)
				{
					e.Graphics.FillRectangle(Constants.FifthBlueBrush, new Rectangle(xpos, ypos, 64, 64));
				}

				e.Graphics.DrawRectangle(Pens.DarkGray, new Rectangle(xpos, ypos, 64, 64));

				e.Graphics.DrawString(showName ? o.ObjectType.ToString() : o.ID.ToString("X3"),
						Font, Brushes.White, new Rectangle(xpos, ypos + 48, 64, 64));

				xpos += 64;
				if (xpos >= w)
				{
					xpos = 0;
					ypos += 64;
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
			int w = Size.Width / 64;
			int h = ((items.Count / w) + 1) * 64;
			Size = new Size(Size.Width, h);

			if (items.Count > 0)
			{
				palettes = ZScreamer.ActiveGraphicsManager.previewObjectsBitmap[items[0].ID].Palette;

				int pindex = 0;
				for (int y = 0; y < ZScreamer.ActiveGraphicsManager.loadedPalettes.GetLength(1); y++)
				{
					for (int x = 0; x < ZScreamer.ActiveGraphicsManager.loadedPalettes.GetLength(0); x++)
					{
						palettes.Entries[pindex] = ZScreamer.ActiveGraphicsManager.loadedPalettes[x, y];
						pindex++;
					}
				}

				for (int y = 0; y < ZScreamer.ActiveGraphicsManager.loadedSprPalettes.GetLength(1); y++)
				{
					for (int x = 0; x < ZScreamer.ActiveGraphicsManager.loadedSprPalettes.GetLength(0); x++)
					{
						if (pindex < Constants.TotalPaletteSize)
						{
							palettes.Entries[pindex++] = ZScreamer.ActiveGraphicsManager.loadedSprPalettes[x, y];
						}
					}
				}

				Palettes.FillInHalfPaletteZeros(palettes.Entries, Color.Transparent);
			}

			foreach (RoomObject o in items)
			{
				o.Size = 5;
				unsafe
				{
					byte* ptr = (byte*) ZScreamer.ActiveGraphicsManager.previewObjectsPtr[o.ID].ToPointer();
					for (int i = 0; i < (64 * 64); i++)
					{
						ptr[i] = 0;
					}
				}

				o.Draw(RoomEditingArtist);
				if (palettes != null)
				{
					ZScreamer.ActiveGraphicsManager.previewObjectsBitmap[o.ID].Palette = palettes;
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
			foreach (RoomObjectPreview o in items)
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
