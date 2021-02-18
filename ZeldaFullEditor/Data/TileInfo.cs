using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class TileInfo
    {
        public ushort o, v, h; //o = over, v = vertical mirror, h = horizontal mirror
        public byte palette;
        public ushort id;
        //vhopppcc cccccccc
        public TileInfo(ushort id, byte palette, ushort v, ushort h, ushort o)
        {
            this.id = id;
            this.palette = palette;
            this.v = v;
            this.h = h;
            this.o = o;
        }



        public ushort toShort()
        {
            ushort value = 0;
            //vhopppcc cccccccc
            if (this.o == 1) { value |= 0x2000; };
            if (this.h == 1) { value |= 0x4000; };
            if (this.v == 1) { value |= 0x8000; };
            value |= (ushort)((this.palette << 10) & 0x1C00);
            value |= (ushort)(this.id & 0x3FF);
            return value;
        }
    }
}
