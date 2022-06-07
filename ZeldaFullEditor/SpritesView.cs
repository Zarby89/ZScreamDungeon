namespace ZeldaFullEditor
{
	public partial class SpritesView : UserControl
	{
		private readonly ImmutableList<SpritePreview> items;
		private ImmutableList<SpritePreview> displayeditems;

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

		private List<SpriteCategory> cats = null;
		public List<SpriteCategory> SearchedCategories
		{
			get => cats;
			set
			{
				if (cats == value) return;
				cats = value;
				Refilter();
			}
		}


		public int selectedIndex = -1;
		public event EventHandler SelectedIndexChanged;

		public SpritePreview selectedObject = null;

		public SpritesView()
		{
		}

		public SpritesView(ICollection<SpritePreview> list)
		{
			items = list.ToImmutableList();
			displayeditems = items;
			InitializeComponent();
		}

		public DungeonSprite CreateSelectedSprite()
		{
			return new DungeonSprite(selectedObject.Species)
			{
				RoomID = ZScreamer.ActiveUWScene.Room.RoomID,
			};
		}

		private void Refilter()
		{
			displayeditems = items.FindAll(sprite =>
			{
				if (SearchedText != null && !sprite.Name.Contains(SearchedText, StringComparison.CurrentCultureIgnoreCase))
				{
					return false;
				}

				if (SearchedGFX?.CheckIfSpriteWillLookGood(sprite.Species) ?? false)
				{
					return false;
				}

				if (SearchedCategories is not null)
				{
					foreach (var cat in cats)
					{
						if (sprite.Species.Categories.Contains(cat))
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
			e.Graphics.Clear(Color.FromArgb(48, 48, 48));
			int w = Size.Width / 68;
			int h = ((displayeditems.Count / w) + 1) * 68;
			int xpos = 0;
			int ypos = 0;

			foreach (var o in displayeditems)
			{
				e.Graphics.DrawImage(UXPreviewArtist.GetImageForEntry(o).Bitmap, new Point((xpos * 64) + (xpos * 4), (ypos * 64) + (ypos * 4)));

				if (selectedObject == o)
				{
					e.Graphics.FillRectangle(Constants.FifthBlueBrush, new Rectangle(xpos * 64 + (xpos * 4), (ypos * 64) + (ypos * 4), 64, 64));
				}

				e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(xpos * 64 + (xpos * 4), ypos * 64 + (ypos * 4), 64, 64));
				e.Graphics.DrawString(o.Name, Constants.Arial7, Brushes.White, new Rectangle(xpos * 64 + (xpos * 4), (ypos * 64) + (ypos * 4) + 40, 64, 24));

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

		private void SpritesView_SizeChanged(object sender, EventArgs e)
		{
			Refresh();
		}

		public void updateSize()
		{
			int w = Size.Width / 64;
			int h = ((displayeditems.Count / w) + 1) * 64;
			Size = new Size(Size.Width, h);

			Refresh();
		}

		private void SpritesView_MouseClick(object sender, MouseEventArgs e)
		{
			int w = Size.Width / 64;
			int h = ((displayeditems.Count / w) + 1) * 64;
			int xpos = 0;
			int ypos = 0;
			int index = 0;
			Size = new Size(Size.Width, h);

			foreach (var o in displayeditems)
			{
				if (index < displayeditems.Count)
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
	}
}
