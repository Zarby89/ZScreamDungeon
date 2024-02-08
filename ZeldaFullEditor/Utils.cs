using System;
using System.Linq;
using System.Net;

namespace ZeldaFullEditor
{
    // TODO move clamps to IntFunctions
    public static class Utils
    {
        public static int SnesToPc(this int address)
		{
           return address & 0x7FFF | (address & 0x7F0000) >> 1;
		}

        public static int PcToSnes(this int addr)
        {
            return 0x800000 | (addr & 0x7FFF) | 0x8000 | ((addr & 0x7F8000) << 1);
            //save in fastrom
        }

        // gets a 24-bit address from the specified snes address, using the input's high byte as the bank
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

            return ret;
        }

        // gets a 24-bit address from the specified snes address, using the input's high byte as the bank
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




        public static int AddressFromBytes(byte addr1, byte addr2, byte addr3)
        {
            return (addr1 << 16) | (addr2 << 8) | addr3;
        }

        public static short AddressFromBytes(byte addr1, byte addr2)
        {
            return (short)((addr1 << 8) | (addr2));
        }

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
