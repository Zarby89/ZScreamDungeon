using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	public static class Utils
	{
		public static int AddressFromBytes(byte addr1, byte addr2, byte addr3)
		{
			return (addr1 << 16) | (addr2 << 8) | addr3;
		}

		public static string[] DeepCopy(this string[] a)
		{
			string[] ret = new string[a.Length];
			int i = 0;
			foreach (string s in a)
			{
				ret[i++] = s.Substring(0);
			}

			return ret;
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


		public static List<T> DeepCopy<T>(this List<T> me)
		{
			using (var ms = new System.IO.MemoryStream())
			{
				var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				formatter.Serialize(ms, me);
				ms.Position = 0;
				return (List<T>) formatter.Deserialize(ms);
			}
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

		public static void DrawFilledRectangleWithOutline(this Graphics g, int x, int y, int w, int h, Pen outline, Brush fill)
		{
			Rectangle r = new Rectangle(x, y, w, h);
			g.FillRectangle(fill, r);
			g.DrawRectangle(outline, r);
		}
	}
}
