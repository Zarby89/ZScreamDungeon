using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.OWSceneModes.ClipboardData
{
    [Serializable]
    public class TileData
    {
        public ushort[] tiles;
        public int length;

        public TileData(ushort[] tiles, int length)
        {
            this.tiles = tiles;
            this.length = length;
        }
    }
}
