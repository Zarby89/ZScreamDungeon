using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	/// <summary>
	/// This class is essentially an immutable array of tiles with a more direct name.
	/// <br/>
	/// New definitions must be created with a ROM using one of the factory methods.
	/// </summary>
	[Serializable]
	public class TilesList
	{
		private readonly Tile[] _list;

		public Tile this[int i] => _list[i];

		private TilesList(Tile[] list)
		{
			_list = list;
		}

		public static readonly TilesList EmptySet = new TilesList(new Tile[] { Tile.Empty, Tile.Empty, Tile.Empty, Tile.Empty });

		public static TilesList CreateNewDefinition(ZScreamer ZS, int position, int count)
		{
			if (count <= 0)
			{
				return EmptySet;
			}

			Tile[] list = new Tile[count];

			for (int i = 0; i < count; i++)
			{
				list[i] = new Tile(ZS.ROM.Read16(position + i * 2));
			}

			return new TilesList(list);
		}

		public static TilesList CreateNewDefinitionFromMultipleAddresses(ZScreamer ZS, params (int address, int count)[] sources)
		{
			int count = 0;

			foreach ((int, int) s in sources)
			{
				count += s.Item2;
			}

			if (count <= 0)
			{
				return EmptySet;
			}

			Tile[] list = new Tile[count];

			int i = 0;

			foreach ((int, int) s in sources)
			{
				for (int j = 0; j < s.Item2; j++, i++)
				{
					list[i] = new Tile(ZS.ROM.Read16(s.Item1 + i * 2));
				}
			}

			return new TilesList(list);
		}
	}
}
