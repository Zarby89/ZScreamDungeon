using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    class ChestDraw
    {
        public int x, y;
        public bool mx, my;

        public ChestDraw(int x, int y, bool mx = false, bool my = false)
        {
            this.x = x;
            this.y = y;
            this.mx = mx;
            this.my = my;
        }
    }
}
