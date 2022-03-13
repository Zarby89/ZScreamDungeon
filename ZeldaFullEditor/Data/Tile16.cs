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
		public TileInfo[] tilesinfos = new TileInfo[4];
		// [0,1]
		// [2,3]

		public Tile16(TileInfo tile0, TileInfo tile1, TileInfo tile2, TileInfo tile3)
		{
			this.tile0 = tile0;
			this.tile1 = tile1;
			this.tile2 = tile2;
			this.tile3 = tile3;
			this.tilesinfos = new TileInfo[] { this.tile0, this.tile1, this.tile2, this.tile3 };
		}

		public Tile16(ulong tiles)
		{
			this.tile0 = GFX.gettilesinfo((ushort) tiles);
			this.tile1 = GFX.gettilesinfo((ushort) (tiles >> 16));
			this.tile2 = GFX.gettilesinfo((ushort) (tiles >> 32));
			this.tile3 = GFX.gettilesinfo((ushort) (tiles >> 48));
			this.tilesinfos = new TileInfo[] { this.tile0, this.tile1, this.tile2, this.tile3 };
		}

		public ulong getLongValue()
		{
			return (ulong) (tile3.toShort()) << 48 | ((ulong) (tile2.toShort()) << 32) | ((ulong) (tile1.toShort()) << 16) | (tile0.toShort()); ;
		}
	}
}
