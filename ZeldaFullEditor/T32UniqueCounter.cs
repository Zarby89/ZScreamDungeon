using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class T32UniqueCounter
    {

        public int x = 0;
        public int y = 0;
        public int count = 0;
        public ulong tileid = 0;
        public T32UniqueCounter(int x, int y, int count, ulong tileid)
        {
            this.x = x;
            this.y = y;
            this.count = count;
            this.tileid = tileid;
        }
    }
}
