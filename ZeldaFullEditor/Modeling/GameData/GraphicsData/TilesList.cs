namespace ZeldaFullEditor.Modeling.GameData.GraphicsData
{
	/// <summary>
	/// This class is essentially an immutable array of tiles with a more direct name.
	/// <br/>
	/// New definitions must be created with a ROM using one of the factory methods.
	/// </summary>
	[Serializable]
	public class TilesList
	{
		protected readonly Tile[] _list;

		public virtual Tile this[int i] => _list[i];

		protected TilesList(Tile[] list)
		{
			_list = list;
		}

		public static readonly TilesList EmptySet = new(new Tile[16]);

		public virtual ushort[] ToUnsignedShorts()
		{
			var ret = new ushort[_list.Length];

			for (var i = 0; i < ret.Length; i++)
			{
				ret[i] = _list[i].ToUnsignedShort();
			}

			return ret;
		}

		public static TilesList CreateNewDefinition(ZScreamer ZS, int position, int count)
		{
			if (count <= 0)
			{
				return EmptySet;
			}

			var list = new Tile[count];

			for (var i = 0; i < count; i++)
			{
				list[i] = new Tile(ZS.ROM.Read16(position + i * 2));
			}

			return new TilesList(list);
		}

		public static TilesList CreateNewDefinitionFromMultipleAddresses(ZScreamer ZS, params (int address, int count)[] sources)
		{
			var count = 0;

			foreach (var s in sources)
			{
				count += s.Item2;
			}

			if (count <= 0)
			{
				return EmptySet;
			}

			var list = new Tile[count];

			var i = 0;

			foreach (var s in sources)
			{
				for (var j = 0; j < s.Item2; j++, i++)
				{
					list[i] = new Tile(ZS.ROM.Read16(s.Item1 + i * 2));
				}
			}

			return new TilesList(list);
		}

	}

	public class FloorsTileList : TilesList
	{
		private const int Count = 8 * 16;
		public override Tile this[int i] => base[i + 8 * Floor];

		public byte Floor { get; set; } = 0;

		private FloorsTileList(Tile[] list) : base(list) { }

		public override ushort[] ToUnsignedShorts()
		{
			var ret = new ushort[8];

			for (var i = 0; i < ret.Length; i++)
			{
				ret[i] = this[i].ToUnsignedShort();
			}

			return ret;
		}

		public static FloorsTileList CreateNewFloors(ZScreamer ZS, int position)
		{
			var list = new Tile[Count];

			for (var i = 0; i < Count; i++)
			{
				list[i] = new Tile(ZS.ROM.Read16(position + i * 2));
			}

			return new FloorsTileList(list);
		}

	}
}
