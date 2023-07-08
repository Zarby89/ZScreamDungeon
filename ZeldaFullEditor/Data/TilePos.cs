using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class TilePos
    {
        public byte x, y;
        public ushort tileId;

        public TilePos(byte x, byte y, ushort tileId)
        {
            this.x = x;
            this.y = y;
            this.tileId = tileId;
        }
    }
}
