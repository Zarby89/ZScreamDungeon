namespace ZeldaFullEditor
{
	/// <summary>
	///     A class to contain individual Tile32 data.
	/// </summary>
	public class Tile32
	{
		/// <summary>
		///      Gets or sets the 1st 16x16 tile of the Tile32.
		/// </summary>
		public ushort Tile0 { get; set; }

		/// <summary>
		///      Gets or sets the 2nd 16x16 tile of the Tile32.
		/// </summary>
		public ushort Tile1 { get; set; }

		/// <summary>
		///      Gets or sets the 3rd 16x16 tile of the Tile32.
		/// </summary>
		public ushort Tile2 { get; set; }

		/// <summary>
		///     Gets or sets the 4th 16x16 tile of the Tile32.
		/// </summary>
		public ushort Tile3 { get; set; }

		/// <summary>
		///     Initializes a new instance of the <see cref="Tile32"/> class.
		///     [0,1]
		///     [2,3].
		/// </summary>
		/// <param name="tile0"> The 1st tile. </param>
		/// <param name="tile1"> The 2nd tile. </param>
		/// <param name="tile2"> The 3rd tile. </param>
		/// <param name="tile3"> The 4th tile. </param>
		public Tile32(ushort tile0, ushort tile1, ushort tile2, ushort tile3)
		{
			this.Tile0 = tile0;
			this.Tile1 = tile1;
			this.Tile2 = tile2;
			this.Tile3 = tile3;
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="Tile32"/> class.
		/// </summary>
		/// <param name="tiles"> All 4 tiles together as a ulong. </param>
		public Tile32(ulong tiles)
		{
			this.Tile0 = (ushort) tiles;
			this.Tile1 = (ushort) (tiles >> 16);
			this.Tile2 = (ushort) (tiles >> 32);
			this.Tile3 = (ushort) (tiles >> 48);
		}

		/// <summary>
		///     Returns the 4 sub tiles as a long.
		/// </summary>
		/// <returns> A long. </returns>
		public ulong GetLongValue()
		{
			return ((ulong) this.Tile3) << 48 | (((ulong) this.Tile2) << 32) | (((ulong) this.Tile1) << 16) | this.Tile0;
		}
	}
}
