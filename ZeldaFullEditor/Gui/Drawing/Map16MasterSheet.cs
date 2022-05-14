namespace ZeldaFullEditor
{
	public unsafe class Tile16MasterSheet : IByteable
	{
		private readonly IntPtr ptr;
		private byte* Pointer => (byte*) ptr.ToPointer();

		private readonly Tile16[] ListOf = new Tile16[Constants.NumberOfUniqueTile16Definitions];

		public GraphicsSet Graphics { get; set; }


		public Bitmap Bitmap { get; }

		public byte this[int i]
		{
			get => Pointer[i];
			set => Pointer[i] = value;
		}

		public ColorPalette Palette
		{
			get => Bitmap.Palette;
			set => Bitmap.Palette = value;
		}

		public Tile16MasterSheet()
		{
			ptr = Marshal.AllocHGlobal(128 * 7136 / 2);
			Bitmap = new Bitmap(128, 7136, 64, PixelFormat.Format4bppIndexed, ptr);
		}

		public void RedrawImageForGraphicsSet()
		{
			throw new NotImplementedException();
		}

		public void RedrawImageForPaletteChange()
		{
			throw new NotImplementedException();
		}

		public void SetTile16At(int id, Tile16 t)
		{
			throw new NotImplementedException();
		}

		public Tile16 GetTile16At(int id)
		{
			throw new NotImplementedException();
		}


		public byte[] GetByteData()
		{
			var ret = new List<byte>();

			foreach (var tile in ListOf)
			{
				ret.AddRange(tile.GetByteData());
			}

			return ret.ToArray();
		}
	}
}
