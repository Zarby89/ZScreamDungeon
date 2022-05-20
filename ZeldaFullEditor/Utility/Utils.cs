using ZeldaFullEditor.Handler;

namespace ZeldaFullEditor
{
	public static class Utils
	{
		public static int AddressFromBytes(byte addr1, byte addr2, byte addr3)
		{
			return (addr1 << 16) | (addr2 << 8) | addr3;
		}

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
		public static void Add(this List<byte> me, ushort val)
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
		/// call for a 512 by 512 screen with <see cref="GraphicsUnit.Pixel"/>
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


	}
}
