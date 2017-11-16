using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public static class Addresses
    {
        //Convert Snes Address in PC Address - Mirrored Format
        public static int snestopc(int addr)
        {
            int temp = (addr & 0x7FFF) + ((addr / 2) & 0xFF8000);
            return (temp + 0x0);
        }

        //Convert PC Address to Snes Address
        public static int pctosnes(int addr)
        {
            byte[] b = BitConverter.GetBytes(addr);
            b[2] = (byte)(b[2] * 2);
            if (b[1] >= 0x80)
            {
                b[2] += 1;
            }
            else
            {
                b[1] += 0x80;
            }
            return BitConverter.ToInt32(b, 0);
        }

        
    }
}
