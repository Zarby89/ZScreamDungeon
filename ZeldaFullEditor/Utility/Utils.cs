using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	public static class Utils
	{
		public static int AddressFromBytes(byte addr1, byte addr2, byte addr3)
		{
			return (addr1 << 16) | (addr2 << 8) | addr3;
		}

		public static byte[] DeepCopy(this byte[] a)
		{
			byte[] ret = new byte[a.Length];
			int i = 0;
			foreach (byte b in a)
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
			Rectangle r = new Rectangle(x, y, w, h);
			g.FillRectangle(fill, r);
			g.DrawRectangle(outline, r);
		}
		
		public static void DrawFilledRectangleWithOutline(this Graphics g, Rectangle r, Pen outline, Brush fill)
		{
			g.FillRectangle(fill, r);
			g.DrawRectangle(outline, r);
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

				g.DrawImage(ZScreamer.ActiveGraphicsManager.spriteFont,
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
