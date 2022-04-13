using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public class Tile16
	{
		public Tile tile0 { get; set; }
		public Tile tile1 { get; set; }
		public Tile tile2 { get; set; }
		public Tile tile3 { get; set; }
		// [0,1]
		// [2,3]

		public Tile this[int i]
		{
			get
			{
				switch (i)
				{
					case 0: return tile0;
					case 1: return tile1;
					case 2: return tile2;
					case 3: return tile3;
				}
				return tile0;
			}
			
		}


		public Tile16(Tile tile0, Tile tile1, Tile tile2, Tile tile3)
		{
			this.tile0 = tile0;
			this.tile1 = tile1;
			this.tile2 = tile2;
			this.tile3 = tile3;
		}

		public Tile16(ulong tiles)
		{
			tile0 = new Tile((ushort) tiles);
			tile1 = new Tile((ushort) (tiles >> 16));
			tile2 = new Tile((ushort) (tiles >> 32));
			tile3 = new Tile((ushort) (tiles >> 48));
		}

		public Tile16(ushort a, ushort b, ushort c, ushort d)
		{
			tile0 = new Tile(a);
			tile1 = new Tile(b);
			tile2 = new Tile(c);
			tile3 = new Tile(d);
		}

		public Tile16 Clone()
		{
			return new Tile16(tile0, tile1, tile2, tile3);
		}

		public ulong getLongValue()
		{
			return (ulong) tile3.ToUnsignedShort() << 48 | ((ulong) tile2.ToUnsignedShort() << 32) | ((ulong) tile1.ToUnsignedShort() << 16) | tile0.ToUnsignedShort();
		}

		public static ulong CreateLongValue(ushort a, ushort b, ushort c, ushort d)
		{
			return (ulong) a << 48 | ((ulong) b << 32) | ((ulong) c << 16) | d;
		}
	}
}
