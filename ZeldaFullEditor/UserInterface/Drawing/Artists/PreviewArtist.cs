namespace ZeldaFullEditor.UserInterface.Drawing.Artists;

public class PreviewArtist : IDrawArt
{
	private readonly Dictionary<Type, Dictionary<int, ListImage>> AllPreviews = new();

	private class ListImage
	{
		internal readonly List<PreviewInfo> _list = new();
		internal readonly PointeredImage _img = new(PreviewDimensions, PreviewDimensions);

		public ListImage() { }

		public void Deconstruct(out List<PreviewInfo> list, out PointeredImage img)
		{
			img = _img;
			list = _list;
		}
	}

	public GraphicsSet LoadedGraphics
	{
		get => ZScreamer.ActiveUWScene?.Room?.LoadedGraphics;
	}

	public NeedsNewArt Redrawing { get; private set; }

	private const int PreviewDimensions = 56;


	public void ClearPreviews()
	{
		AllPreviews.Clear();
	}

	public PointeredImage GetImageForEntry<TType>(TType item) where TType : ITypeID
	{
		if (!AllPreviews.ContainsKey(typeof(TType)))
		{
			return new(PreviewDimensions, PreviewDimensions);
		}

		var entry = AllPreviews[typeof(TType)];
		if (!entry.ContainsKey(item.TypeID))
		{
			return new(PreviewDimensions, PreviewDimensions);
		}

		return entry[item.TypeID]._img;
	}

	public void AddToObjectsPreview<TType, TDraw>(TType item, IEnumerable<TDraw> info, bool global = false) where TType : ITypeID
	{
		var set = AllPreviews.GetOrMakeListForKey(typeof(TType));
		var (instr, _) = set.GetOrMakeListForKey(item.TypeID);

		switch (info)
		{
			case IEnumerable<PreviewInfo> dinfo:
				instr.AddRange(dinfo);
				break;


			case IEnumerable<OAMDrawInfo> oinfo:
				foreach (var oi in oinfo)
				{
					var x = oi.X;
					var y = oi.Y;
					if (oi.IsBig)
					{
						instr.Add(new(
							(ushort) (oi.ID + 0x200),
							oi.HFlip ? x : x + 8,
							oi.VFlip ? y : y + 8,
							oi.Palette,
							oi.HFlip,
							oi.VFlip,
							global
						));

						instr.Add(new(
							(ushort) (oi.ID + 1 + 0x200),
							oi.HFlip ? x + 8 : x,
							oi.VFlip ? y : y + 8,
							oi.Palette,
							oi.HFlip,
							oi.VFlip,
							global
						));

						instr.Add(new(
							(ushort) (oi.ID + 16 + 0x200),
							oi.HFlip ? x + 8 : x,
							oi.VFlip ? y + 8 : y,
							oi.Palette,
							oi.HFlip,
							oi.VFlip,
							global
						));

						instr.Add(new(
							(ushort) (oi.ID + 17 + 0x200),
							oi.HFlip ? x + 8 : x,
							oi.VFlip ? y + 8 : y,
							oi.Palette,
							oi.HFlip,
							oi.VFlip,
							global
						));
					}
					else
					{
						instr.Add(new(
							(ushort) (oi.ID + 0x200),
							oi.X,
							oi.Y,
							oi.Palette,
							oi.HFlip,
							oi.VFlip,
							global
						));
					}
				}
				break;
		}
	}

	private static readonly Bitmap dummy = new(1, 1, PixelFormat.Format8bppIndexed);
	public void RefreshPalettesFrom(FullPalette pal)
	{
		var copy = pal.ToColorArray();
		var palettes = dummy.Palette;

		for (int i = 0; i < copy.Length; i++)
		{
			palettes.Entries[i] = copy[i];
		}

		foreach (var (_, list) in AllPreviews)
		{
			foreach (var (_, (_, img)) in list)
			{
				img.Palette = palettes;
			}
		}
	}


	public void RedrawAllPreviews()
	{
		foreach (var (_, list) in AllPreviews)
		{
			foreach (var (_, (instr, img)) in list)
			{
				img.ClearBitmap();
				foreach (var oi in instr)
				{
					LoadedGraphics.DrawPreviewTileToCanvas(img, oi);
				}
			}
		}
	}

}
