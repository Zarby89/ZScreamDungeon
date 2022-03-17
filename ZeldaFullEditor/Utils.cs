using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	// TODO function for ByteBitIsSet(), etc
	public static class Utils
	{
		public static int SnesToPc(int addr)
		{
			if (addr >= 0x808000) { addr -= 0x808000; }
			int temp = (addr & 0x7FFF) + ((addr / 2) & 0xFF8000);
			return (temp + 0x0);
		}

		public static int PcToSnes(int addr)
		{
			byte[] b = BitConverter.GetBytes(addr);
			b[2] = (byte) (b[2] * 2);

			if (b[1] >= 0x80)
			{
				b[2] += 1;
			}
			else
			{
				b[1] += 0x80;
			}

			return BitConverter.ToInt32(b, 0);
			// SNES always have + 0x8000 no matter what, the bank on pc is always / 2

			//return ((addr * 2) & 0xFF0000) + (addr & 0x7FFF) + 0x8000;
		}

		/// gets a 24-bit address from the specified snes address, using the input's high byte as the bank
		public static int Get24Local(int addr, bool pc = true)
		{
			int a = SnesToPc(addr);
			int ret = (addr & 0xFF0000) |
					   (ROM.DATA[a + 1] << 8) |
					   ROM.DATA[a];
			if (pc)
			{
				return SnesToPc(ret);
			}
			else
			{
				return ret;
			}
		}

		/// gets a 24-bit address from the specified snes address, using the input's high byte as the bank
		public static int Get24LocalFromPC(int addr, bool pc = true)
		{
			int ret = (PcToSnes(addr) & 0xFF0000) |
					   (ROM.DATA[addr + 1] << 8) |
					   ROM.DATA[addr];
			if (pc)
			{
				return SnesToPc(ret);
			}
			else
			{
				return ret;
			}
		}


		public static int AddressFromBytes(byte addr1, byte addr2, byte addr3)
		{
			return (addr1 << 16) | (addr2 << 8) | addr3;
		}

		public static short AddressFromBytes(byte addr1, byte addr2)
		{
			return (short) ((addr1 << 8) | (addr2));
		}

		public static int Clamp(int v, int min, int max)
		{
			if (v >= max)
			{
				v = max;
			}
			if (v <= min)
			{
				v = min;
			}

			return (v);
		}

		public static short Clamp(short v, int min, int max)
		{
			if (v >= max)
			{
				v = (short) max;
			}
			if (v <= min)
			{
				v = (short) min;
			}

			return (v);
		}

		public static byte Clamp(byte v, int min, int max)
		{
			if (v >= max)
			{
				v = (byte) max;
			}
			if (v <= min)
			{
				v = (byte) min;
			}

			return (v);
		}

		public static string[] DeepCopyStrings(string[] a)
		{
			string[] ret = new string[a.Length];
			int i = 0;
			foreach (string s in a)
			{
				ret[i++] = s.Substring(0);
			}

			return ret;
		}

		public static byte[] DeepCopyBytes(byte[] a)
		{
			byte[] ret = new byte[a.Length];
			int i = 0;
			foreach (byte b in a)
			{
				ret[i++] = b;
			}

			return ret;
		}

		public static string[] CreateIndexedList(string[] a)
		{
			string[] ret = new string[a.Length];
			int i = 0;
			foreach (string s in a)
			{
				ret[i++] = string.Format("{0:X2} - {1}", i, s);
			}

			return ret;
		}
	}
}
