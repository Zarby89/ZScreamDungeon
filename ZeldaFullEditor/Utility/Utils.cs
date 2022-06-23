namespace ZeldaFullEditor.Utility
{
	/// <summary>
	/// Contains methods for general purpose operations.
	/// </summary>
	internal static class Utils
	{
		public static int AddressFromBytes(byte addr1, byte addr2, byte addr3)
		{
			return (addr1 << 16) | (addr2 << 8) | addr3;
		}

		/// <summary>
		/// Creates a new copy of this structure array.
		/// </summary>
		public static T[] DeepCopy<T>(this T[] a) where T : struct
		{
			T[] ret = new T[a.Length];
			int i = 0;
			foreach (var b in a)
			{
				ret[i++] = b;
			}

			return ret;
		}

		/// <summary>
		/// Adds a little-endian short to the list as individual bytes.
		/// </summary>
		public static void Add16(this List<byte> me, ushort val)
		{
			me.Add((byte) val);
			me.Add((byte) (val >> 8));
		}

		/// <summary>
		/// Changes the given variable by a given magnitude based on the scroll wheel's delta.
		/// </summary>
		public static void ScrollByValue(this MouseEventArgs e, ref int value, int change)
		{
			if (e.Delta > 0)
			{
				value += change;
			}
			else
			{
				value -= change;
			}
		}

		/// <summary>
		/// Changes the given variable by a given magnitude based on the scroll wheel's delta.
		/// </summary>
		public static int ScrollByValue(this MouseEventArgs e, int value, int change)
		{
			if (e.Delta > 0)
			{
				value += change;
			}
			else
			{
				value -= change;
			}

			return value;
		}

		public static void DrawFilledRectangleWithOutline(this Graphics g, int x, int y, int w, int h, Pen outline, Brush fill)
		{
			var r = new Rectangle(x, y, w, h);
			g.FillRectangle(fill, r);
			g.DrawRectangle(outline, r);
		}

		public static void DrawFilledRectangleWithOutline(this Graphics g, Rectangle r, Pen outline, Brush fill)
		{
			g.FillRectangle(fill, r);
			g.DrawRectangle(outline, r);
		}

		/// <summary>
		/// Specific 
		/// <see cref="Graphics.DrawImage(Image, Rectangle, int, int, int, int, GraphicsUnit, ImageAttributes?)">Graphics.DrawImage</see>
		/// call for a 512 by 512 screen with <see cref="GraphicsUnit.Pixel"/> as the graphics unit.
		/// </summary>
		public static void DrawScreen(this Graphics g, Image image, ImageAttributes imageAttr = null)
		{
			g.DrawImage(image, Constants.ScreenSizedRectangle, 0, 0, 512, 512, GraphicsUnit.Pixel, imageAttr);
		}



		public static void DrawText(this Graphics g, int x, int y, string text, ImageAttributes ai = null, bool x2 = false)
		{
			text = text.ToUpper();
			int cpos = 0;
			int size = (ai == null && !x2) ? 8 : 16;
			int spacingmult = x2 ? 2 : 1;

			foreach (char c in text)
			{
				byte arrayPos = (byte) (c - 32);
				if ((byte) c == 10)
				{
					y += 10;
					cpos = 0;
					continue;
				}

				g.DrawImage(GraphicsManager.spriteFont,
					new Rectangle(x + cpos, y, size, size), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel, ai);

				if (arrayPos >= Constants.FontSpacings.Length)
				{
					cpos += 8;
					continue;
				}

				cpos += Constants.FontSpacings[arrayPos] * spacingmult;
			}
		}

		public static TOut GetOrMakeListForKey<TKey, TOut>(this Dictionary<TKey, TOut> d, TKey key) where TOut : new()
		{
			if (d.ContainsKey(key))
			{
				return d[key];
			}

			d[key] = new();
			return d[key];
		}

		public static ImmutableArray<T> GetListOfPredefinedFields<T>() where T : class
		{
			return CreateListOfFields<T>().ToImmutableArray();
		}

		internal static ImmutableArray<T> GetSortedListOfPredefinedFields<T>() where T : class, IEntityType<T>
		{
			return GetSortedListOfPredefinedFields<T>((o, p) => o.ListID - p.ListID);
		}

		public static ImmutableArray<T> GetSortedListOfPredefinedFields<T>(Comparison<T> sort) where T : class
		{
			var ret = CreateListOfFields<T>();
			ret.Sort(sort);
			return ret.ToImmutableArray();
		}

		private static List<T> CreateListOfFields<T>() where T : class
		{
			List<T> ret = new();

			var t = typeof(T);

			var list = t.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.ExactBinding);

			foreach (var o in list)
			{
				if (o.GetCustomAttribute(typeof(PredefinedInstanceAttribute)) is not null)
				{
					if (o.FieldType == t)
					{
						ret.Add(o.GetValue(null) as T);
					}
				}
			}

			return ret;
		}

		internal static List<T> GetAllObjectsFromListByName<T>(this ICollection<T> list, string match) where T : IEntityType<T>
		{
			var ret = list.Where(s => s.Name.Contains(match, StringComparison.CurrentCultureIgnoreCase)).ToList();
			ret.Sort((o, p) => o.ListID - p.ListID);
			return ret;
		}


		internal static T GetTypeFromID<T>(this IEnumerable<T> list, int id) where T : IEntityType<T>
		{
			return list.FirstOrDefault(o => o.ListID == id);
		}


		public static void AddMany<T>(this List<T> list, params T[] add)
		{
			list.AddRange(add);
		}
	}
}
