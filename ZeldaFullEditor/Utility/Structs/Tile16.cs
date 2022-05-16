namespace ZeldaFullEditor
{
	public readonly struct Tile16 : IByteable
	{
		/// <summary>
		/// The <see cref="Tile"/> in the top-left corner
		/// </summary>
		public Tile Tile0 { get; }

		/// <summary>
		/// The <see cref="Tile"/> in the top-right corner
		/// </summary>
		public Tile Tile1 { get; }

		/// <summary>
		/// The <see cref="Tile"/> in the bottom-left corner
		/// </summary>
		public Tile Tile2 { get; }

		/// <summary>
		/// The <see cref="Tile"/> in the bottom-right corner
		/// </summary>
		public Tile Tile3 { get; }

		public Tile this[int i] => i switch
		{
			0 => Tile0,
			1 => Tile1,
			2 => Tile2,
			3 => Tile3,
			_ => Tile0,
		};


		public Tile16(Tile tile0, Tile tile1, Tile tile2, Tile tile3)
		{
			Tile0 = tile0;
			Tile1 = tile1;
			Tile2 = tile2;
			Tile3 = tile3;
		}

		public Tile16(ulong tiles)
		{
			Tile0 = new Tile((ushort) tiles);
			Tile1 = new Tile((ushort) (tiles >> 16));
			Tile2 = new Tile((ushort) (tiles >> 32));
			Tile3 = new Tile((ushort) (tiles >> 48));
		}

		public Tile16(ushort a, ushort b, ushort c, ushort d)
		{
			Tile0 = new Tile(a);
			Tile1 = new Tile(b);
			Tile2 = new Tile(c);
			Tile3 = new Tile(d);
		}

		public Tile16 Clone()
		{
			return new Tile16(Tile0, Tile1, Tile2, Tile3);
		}

		public Tile16 ChangeTiles(Tile? tile0 = null, Tile? tile1 = null, Tile? tile2 = null, Tile? tile3 = null)
		{
			return new Tile16(tile0 ?? Tile0, tile1 ?? Tile1, tile2 ?? Tile2, tile3 ?? Tile3);
		}


		public ulong getLongValue()
		{
			return (ulong) Tile3.ToUnsignedShort() << 48 | ((ulong) Tile2.ToUnsignedShort() << 32) | ((ulong) Tile1.ToUnsignedShort() << 16) | Tile0.ToUnsignedShort();
		}

		public static ulong CreateLongValue(ushort a, ushort b, ushort c, ushort d)
		{
			return (ulong) a << 48 | ((ulong) b << 32) | ((ulong) c << 16) | d;
		}

		public byte[] GetByteData()
		{
			byte[] b0 = Tile0.GetByteData();
			byte[] b1 = Tile1.GetByteData();
			byte[] b2 = Tile2.GetByteData();
			byte[] b3 = Tile3.GetByteData();

			return new byte[]
			{
				b0[0], b0[1],
				b1[0], b1[1],
				b2[0], b2[1],
				b3[0], b3[1]
			};
		}
	}
}
