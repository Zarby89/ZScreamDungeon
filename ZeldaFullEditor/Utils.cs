using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
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
            b[2] = (byte)(b[2] * 2);
            if (b[1] >= 0x80)

                b[2] += 1;
            else b[1] += 0x80;

            return BitConverter.ToInt32(b, 0);
            //snes always have + 0x8000 no matter what, the bank on pc is always / 2

            //return ((addr * 2) & 0xFF0000) + (addr & 0x7FFF) + 0x8000;
        }

        public static int AddressFromBytes(byte addr1, byte addr2, byte addr3)
        {
            return (addr1 << 16) | (addr2 << 8) | addr3;
        }

        public static short AddressFromBytes(byte addr1, byte addr2)
        {
            return (short)((addr1 << 8) | (addr2));
        }

    }



    
}
