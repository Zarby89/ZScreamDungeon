using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class Tile32
    {
        public ushort tile0, tile1, tile2, tile3;
        //[0,1]
        //[2,3]

        public Tile32(ushort tile0, ushort tile1, ushort tile2, ushort tile3)
        {
            this.tile0 = tile0;
            this.tile1 = tile1;
            this.tile2 = tile2;
            this.tile3 = tile3;
        }

        public Tile32(ulong tiles)
        {
            this.tile0 = (ushort)tiles;
            this.tile1 = (ushort)(tiles >> 16);
            this.tile2 = (ushort)(tiles >> 32);
            this.tile3 = (ushort)(tiles >> 48);
        }

        public ulong getLongValue()
        {
            return (ulong)((ulong)tile3 << 48) | ((ulong)tile2 << 32) | ((ulong)tile1 << 16) | (ulong)(tile0); ;
        }
    }
}
