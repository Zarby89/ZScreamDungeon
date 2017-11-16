using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class Chest
    {
        public byte x, y, item;
        public Chest(byte x,byte y, byte item)
        {
            this.x = x;
            this.y = y;
            this.item = item;
        }

    }
}
