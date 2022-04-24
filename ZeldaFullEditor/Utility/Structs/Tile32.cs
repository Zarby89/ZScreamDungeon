namespace ZeldaFullEditor
{
	public readonly struct Tile32
	{
		// 0 1
		// 2 3
		public ushort Tile0 { get; }
		public ushort Tile1 { get; }
		public ushort Tile2 { get; }
		public ushort Tile3 { get; }

		public Tile32(ushort tile0, ushort tile1, ushort tile2, ushort tile3)
		{
			Tile0 = tile0;
			Tile1 = tile1;
			Tile2 = tile2;
			Tile3 = tile3;
		}

		public Tile32(ulong tiles)
		{
			Tile0 = (ushort) tiles;
			Tile1 = (ushort) (tiles >> 16);
			Tile2 = (ushort) (tiles >> 32);
			Tile3 = (ushort) (tiles >> 48);
		}

		public ulong getLongValue()
		{
			return (ulong) Tile3 << 48 | ((ulong) Tile2 << 32) | ((ulong) Tile1 << 16) | Tile0;
		}
	}
}
