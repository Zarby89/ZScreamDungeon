namespace ZeldaFullEditor.ALTTP.GameData.GraphicsData
{
	public readonly struct Tile32
	{
		/// <summary>
		/// The tile16 in the top-left corner
		/// </summary>
		public ushort Tile0 { get; }

		/// <summary>
		/// The tile16 in the top-right corner
		/// </summary>
		public ushort Tile1 { get; }

		/// <summary>
		/// The tile16 in the bottom-left corner
		/// </summary>
		public ushort Tile2 { get; }

		/// <summary>
		/// The tile16 in the bottom-right corner
		/// </summary>
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
			return (ulong) Tile3 << 48 | (ulong) Tile2 << 32 | (ulong) Tile1 << 16 | Tile0;
		}

		public static readonly Tile32 Empty = new(0, 0, 0, 0);
	}
}
