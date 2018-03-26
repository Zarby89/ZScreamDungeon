using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class Tile16
    {

        public TileInfo tile0, tile1, tile2, tile3;
        //[0,1]
        //[2,3]
        public Tile16(TileInfo tile0, TileInfo tile1, TileInfo tile2, TileInfo tile3)
        {
            this.tile0 = tile0;
            this.tile1 = tile1;
            this.tile2 = tile2;
            this.tile3 = tile3;
        }
    }

}
