using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ZeldaFullEditor
{
	// TODO move clamps to IntFunctions
	public static class Utils
	{
		/// <summary>
		/// Converts a SNES system bus address from lorom mapping to a binary file offset.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int SnesToPc(this int addr) => (addr & 0x7FFF) | ((addr & 0x7F0000) >> 1);


		/// <summary>
		/// Converts a binary file offset to a SNES system bus address for the lorom mapping.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int PcToSnes(this int addr) => 0x808000 | (addr & 0x7FFF) | ((addr & 0x7F8000) << 1);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetBank(this int addr) => addr & 0xFF0000;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte GetBankAsByte(this int addr) => (byte) (addr >> 16);

		public static Color ToColor(this ushort c)
		{
			return Color.FromArgb((c & 0x1F) << 3, (c >> 2) & 0xF8, (c >> 7) & 0xF8);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort ToSNESColor(this Color c)
		{
			return (ushort) ((c.R >> 3) | ((c.G & 0xF8) << 2) | ((c.B & 0xF8) << 7));
		}

		// gets a 24-bit address from the specified snes address, using the input's high byte as the bank
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Get24Local(int addr, bool pc = true)
		{
			int a = SnesToPc(addr);
			int ret = (addr & 0xFF0000) | (ROM.DATA[a + 1] << 8) | ROM.DATA[a];

			if (pc)
			{
				return SnesToPc(ret);
			}

			return ret;
		}

		// gets a 24-bit address from the specified snes address, using the input's high byte as the bank
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Get24LocalFromPC(int addr, bool pc = true)
		{
			int ret = (PcToSnes(addr) & 0xFF0000) |
						(ROM.DATA[addr + 1] << 8) |
						ROM.DATA[addr];
			if (pc)
			{
				return SnesToPc(ret);
			}

			return ret;
		}




		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int AddressFromBytes(byte addr1, byte addr2, byte addr3)
		{
			return (addr1 << 16) | (addr2 << 8) | addr3;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short AddressFromBytes(byte addr1, byte addr2)
		{
			return (short) ((addr1 << 8) | (addr2));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Clamp(int v, int min, int max)
		{
			if (v > max)
			{
				return max;
			}
			else if (v < min)
			{
				return min;
			}

			return v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short Clamp(short v, int min, int max)
		{
			if (v > max)
			{
				return (short) max;
			}
			else if (v < min)
			{
				return (short) min;
			}

			return v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort Clamp(ushort v, int min, int max)
		{
			if (v > max)
			{
				return (ushort) max;
			}
			else if (v < min)
			{
				return (ushort) min;
			}

			return v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte Clamp(byte v, int min, int max)
		{
			if (v > max)
			{
				return (byte) max;
			}
			else if (v < min)
			{
				return (byte) min;
			}

			return v;
		}

		public static string[] DeepCopyStrings(string[] a)
		{
			return a.Select(s => s.Substring(0)).ToArray();
		}

		public static byte[] DeepCopyBytes(byte[] a)
		{
			byte[] ret = new byte[a.Length];
			Array.Copy(a, ret, a.Length);

			return ret;
		}

		public static string[] CreateIndexedList(string[] a)
		{
			int i = 0;
			return a.Select(s => $"{i++:X2} - {s}").ToArray();
		}
	}
}
