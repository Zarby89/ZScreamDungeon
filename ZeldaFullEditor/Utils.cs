using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	public static class IntFunctions
	{
		public static bool BitIsOn(this byte b, byte test) => (b & test) != 0;
		public static bool BitsAllSet(this byte b, byte test) => (b & test) == test;
		public static bool BitIsOn(this int b, int test) => (b & test) != 0;
		public static bool BitsAllSet(this int b, int test) => (b & test) == test;
		public static bool BitIsOn(this short b, short test) => (b & test) != 0;
		public static bool BitsAllSet(this short b, short test) => (b & test) == test;
		public static bool BitIsOn(this ushort b, ushort test) => (b & test) != 0;
		public static bool BitsAllSet(this ushort b, ushort test) => (b & test) == test;

		public static byte SetFieldBits(byte baseval = 0,
			bool bit0 = false, bool bit1 = false, bool bit2 = false, bool bit3 = false,
			bool bit4 = false, bool bit5 = false, bool bit6 = false, bool bit7 = false)
		{
			return (byte) (baseval | 
				(bit0 ? 1 << 0 : 0) |
				(bit1 ? 1 << 1 : 0) |
				(bit2 ? 1 << 2 : 0) |
				(bit3 ? 1 << 3 : 0) |
				(bit4 ? 1 << 4 : 0) |
				(bit5 ? 1 << 5 : 0) |
				(bit6 ? 1 << 6 : 0) |
				(bit7 ? 1 << 7 : 0));
		}


		public static int Clamp(this int v, int min, int max)
		{
			if (v >= max)
			{
				v = max;
			}
			else if (v <= min)
			{
				v = min;
			}

			return v;
		}

		public static ushort Clamp(this ushort v, ushort min, ushort max)
		{
			if (v >= max)
			{
				v = max;
			}
			else if (v <= min)
			{
				v = min;
			}

			return v;
		}

		public static byte Clamp(this byte v, byte min, byte max)
		{
			if (v >= max)
			{
				v = max;
			}
			else if (v <= min)
			{
				v = min;
			}

			return v;
		}
	}
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
	}
}
