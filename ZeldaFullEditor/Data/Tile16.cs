using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public class Tile16
	{
		public Tile tile0, tile1, tile2, tile3;
		public Tile[] tilesinfos = new Tile[4];
		// [0,1]
		// [2,3]

		public Tile16(Tile tile0, Tile tile1, Tile tile2, Tile tile3)
		{
			this.tile0 = tile0;
			this.tile1 = tile1;
			this.tile2 = tile2;
			this.tile3 = tile3;
			this.tilesinfos = new Tile[] { this.tile0, this.tile1, this.tile2, this.tile3 };
		}

		public Tile16(ulong tiles)
		{
			tile0 = new Tile((ushort) tiles);
			tile1 = new Tile((ushort) (tiles >> 16));
			tile2 = new Tile((ushort) (tiles >> 32));
			tile3 = new Tile((ushort) (tiles >> 48));
			tilesinfos = new Tile[] { tile0, tile1, tile2, tile3 };
		}

		public Tile16(ushort a, ushort b, ushort c, ushort d)
		{
			tile0 = new Tile(a);
			tile1 = new Tile(b);
			tile2 = new Tile(c);
			tile3 = new Tile(d);
			tilesinfos = new Tile[] { tile0, tile1, tile2, tile3 };
		}

		public Tile16 Clone()
		{
			return new Tile16(tile0, tile1, tile2, tile3);
		}

		public ulong getLongValue()
		{
			return (ulong) (tile3.ToUnsignedShort()) << 48 | ((ulong) (tile2.ToUnsignedShort()) << 32) | ((ulong) (tile1.ToUnsignedShort()) << 16) | (tile0.ToUnsignedShort());
		}

		public static ulong CreateLongValue(ushort a, ushort b, ushort c, ushort d)
		{
			return (ulong) a << 48 | ((ulong) b << 32) | ((ulong) c << 16) | d;

		}
	}
}
