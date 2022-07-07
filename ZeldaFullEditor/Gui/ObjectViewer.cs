namespace ZeldaFullEditor;

public partial class ObjectViewer<TPreview> : FlowLayoutPanel where TPreview : IPreview, ITypeID
{
	private readonly Selectable[] items;

	public bool showName = false;

	private Selectable selectedCell;

	private static readonly Brush SelectedObject = new SolidBrush(Color.FromArgb(150, 0, 50, 200));
	private class Selectable : UserControl
	{
		// TODO move this to dungeonmain
		bool showName = true;

		internal TPreview guy { get; init; }
		internal bool Selected { get; set; }

		private static readonly Font FF = new("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
		private static readonly Font Smaller = new("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point);

		private const int DimensionL = 56;
		public Selectable()
		{
			Width = DimensionL;
			Height = DimensionL;
			Margin = new(0, 0, 1, 1);
			Font = FF;
			
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.Clear(Color.Black);
			e.Graphics.DrawImage(UXPreviewArtist.GetImageForEntry(guy).Bitmap, new Point(0, 0));

			if (Selected)
			{
				e.Graphics.FillRectangle(SelectedObject, new Rectangle(0, 0, DimensionL, DimensionL));
			}

			e.Graphics.DrawString(guy.TypeID.ToString("X2"), Font, Brushes.White, new PointF(2F, 2F));
			if (showName)
			{
				e.Graphics.DrawString(guy.Name, Smaller, Brushes.White,
					new RectangleF(2F, 30F, DimensionL - 4, 30F));
			}
			//e.Graphics.DrawString(showName ? guy.EntityType.ToString() : guy.TypeID.ToString("X2"),
			//		Font, Brushes.White, new Rectangle(0, 48, 64, 64));

			base.OnPaint(e);
		}
	}


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

	private List<SearchCategory> cats = null;
	public List<SearchCategory> SearchedCategories
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

	public ObjectViewer(ICollection<TPreview> list)
	{
		List<Selectable> nlist = new(list.Count);
		foreach (var p in list)
		{
			Selectable add = new()
			{
				guy = p
			};
			nlist.Add(add);

			ZGUI.toolTip1.SetToolTip(add, $"{p.TypeID:X2} - {p.Name}");

			add.MouseClick += new((sender, e) =>
			{
				var ssss = (Selectable) sender;
				if (ssss is null) return;
				if (selectedCell is not null)
				{
					selectedCell.Selected = false;
					selectedCell.Invalidate();
				}
				ssss.Selected = true;
				selectedCell = ssss;
				ssss.Refresh();
			});
		}


		items = nlist.ToArray();
		InitializeComponent();
		AutoScroll = true;
		Controls.Clear();
		Controls.AddRange(items);
	}

	private void Add_MouseClick(object sender, MouseEventArgs e)
	{
		throw new NotImplementedException();
	}

	public object CreateSelectedObject()
	{
		return selectedCell.guy;
	}

	private void Refilter()
	{
		Controls.Clear();
		selectedCell.Selected = false;
		Controls.AddRange(Array.FindAll(items, sel =>
		{
			if (SearchedText != null && !sel.Name.Contains(SearchedText, StringComparison.CurrentCultureIgnoreCase))
			{
				return false;
			}

			if (SearchedGFX?.CheckIfEntityWillLookGood(sel.guy.EntityType) ?? false)
			{
				return false;
			}

			if (SearchedCategories is not null)
			{
				foreach (var cat in cats)
				{
					if (sel.guy.Categories.Contains(cat))
					{
						return true;
					}
				}

				return false;
			}

			return true;
		}));
	}

	private void ObjectViewer_SizeChanged(object sender, EventArgs e)
	{
		Refresh();
	}

	private void ObjectViewer_MouseClick(object sender, MouseEventArgs e)
	{
		//int w = (Size.Width / 64);
		//int h = (((displayeditems.Count / w) + 1) * 64);
		//int xpos = 0;
		//int ypos = 0;
		//int index = 0;
		//Size = new Size(Size.Width, h);
		//foreach (var o in displayeditems)
		//{
		//	if (index < displayeditems.Count)
		//	{
		//		Rectangle itemRect = new Rectangle(xpos * 64, ypos * 64, 64, 64);
		//		Rectangle itemstarRect = new Rectangle((xpos * 64) + 44, (ypos * 64) + 44, 16, 16);
		//		if (itemRect.Contains(new Point(e.X, e.Y)))
		//		{
		//			selectedIndex = index;
		//			selectedObject = o;
		//			if (itemstarRect.Contains((new Point(e.X, e.Y))))
		//			{
		//				// Make Favourite or not
		//				if (Settings.Default.favoriteObjects[o.ID] == "true")
		//				{
		//					Settings.Default.favoriteObjects[o.ID] = "false";
		//				}
		//				else
		//				{
		//					Settings.Default.favoriteObjects[o.ID] = "true";
		//				}
		//			}
		//
		//			Refresh();
		//			return;
		//		}
		//
		//		xpos++;
		//		if (xpos >= w)
		//		{
		//			xpos = 0;
		//			ypos++;
		//
		//		}
		//
		//		index++;
		//	}
		//}
	}
}
