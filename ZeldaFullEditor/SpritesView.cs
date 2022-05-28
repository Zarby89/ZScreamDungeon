namespace ZeldaFullEditor
{
	public partial class SpritesView : UserControl
	{
		private readonly ImmutableList<SpritePreview> items;
		private ImmutableList<SpritePreview> displayeditems;

		ColorPalette palettes = null;

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
				unsafe
				{
					byte* ptr = (byte*) ZScreamer.ActiveGraphicsManager.previewSpritesPtr[o.ID].ToPointer();
					for (int i = 0; i < (64 * 64); i++)
					{
						ptr[i] = 0;
					}
				}

				o.Draw(RoomEditingArtist);

				e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.previewSpritesBitmap[o.ID], new Point((xpos * 64) + (xpos * 4), (ypos * 64) + (ypos * 4)));

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
			int h = (((displayeditems.Count / w) + 1) * 64);
			this.Size = new Size(this.Size.Width, h);

			if (displayeditems.Count > 0)
			{
				palettes = ZScreamer.ActiveGraphicsManager.previewSpritesBitmap[displayeditems[0].ID].Palette;

				if (palettes == null) return;

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

				foreach (var o in displayeditems)
				{
					ZScreamer.ActiveGraphicsManager.previewSpritesBitmap[o.ID].Palette = palettes;
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
			int h = (((displayeditems.Count / w) + 1) * 64);
			int xpos = 0;
			int ypos = 0;
			int index = 0;
			this.Size = new Size(this.Size.Width, h);

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

		private void SpritesView_Load(object sender, EventArgs e)
		{
			// TODO: Add something here?
		}
	}
}
