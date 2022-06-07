﻿namespace ZeldaFullEditor
{
	public partial class ObjectViewer : UserControl
	{
		private readonly ImmutableList<RoomObjectPreview> items;
		private ImmutableList<RoomObjectPreview> displayeditems;

		public bool showName = false;

		public int selectedIndex = -1;
		public event EventHandler SelectedIndexChanged;

		public RoomObjectPreview selectedObject = null;


		private string text = null;
		public string SearchedText
		{
			get => text;
			set
			{
				if (text == value) return;
				text = value;
				Refilter();
			}
		}

		private GraphicsSet gfx = null;
		public GraphicsSet SearchedGFX
		{
			get => gfx;
			set
			{
				if (gfx == value) return;
				gfx = value;
				Refilter();
			}
		}

		private List<RoomObjectCategory> cats = null;
		public List<RoomObjectCategory> SearchedCategories
		{
			get => cats;
			set
			{
				if (cats == value) return;
				cats = value;
				Refilter();
			}
		}



		public ObjectViewer()
		{
			InitializeComponent();
		}

		public ObjectViewer(ICollection<RoomObjectPreview> list)
		{
			items = list.ToImmutableList();
			displayeditems = items;
			InitializeComponent();
		}



		public RoomObject CreateSelectedObject()
		{
			return new RoomObject(selectedObject.ObjectType, ZScreamer.ActiveScreamer.TileLister[selectedObject.ID]);
		}

		private void Refilter()
		{
			displayeditems = items.FindAll(obj =>
			{
				if (SearchedText != null && !obj.Name.Contains(SearchedText, StringComparison.CurrentCultureIgnoreCase))
				{
					return false;
				}

				if (SearchedGFX?.CheckIfObjectWillLookGood(obj.ObjectType) ?? false)
				{
					return false;
				}

				if (SearchedCategories is not null)
				{
					foreach (var cat in cats)
					{
						if (obj.ObjectType.Categories.Contains(cat))
						{
							return true;
						}
					}

					return false;
				}

				return true;
			});
		}


		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.Clear(Color.Black);
			int w = Size.Width & ~0x3F;
			int xpos = 0;
			int ypos = 0;

			foreach (var o in displayeditems)
			{
				e.Graphics.DrawImage(UXPreviewArtist.GetImageForEntry(o).Bitmap, new Point(xpos, ypos));

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

		private void ObjectViewer_SizeChanged(object sender, EventArgs e)
		{
			Refresh();
		}

		public void updateSize()
		{
			int w = Size.Width / 64;
			int h = ((displayeditems.Count / w) + 1) * 64;
			Size = new Size(Size.Width, h);
		}

		private void ObjectViewer_MouseClick(object sender, MouseEventArgs e)
		{
			int w = (Size.Width / 64);
			int h = (((displayeditems.Count / w) + 1) * 64);
			int xpos = 0;
			int ypos = 0;
			int index = 0;
			Size = new Size(Size.Width, h);
			foreach (RoomObjectPreview o in displayeditems)
			{
				if (index < displayeditems.Count)
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
