using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	/// <summary>
	/// This class is essentually an immutable array of tiles with a more direct name.
	/// <br/>
	/// New definitions must be created with a ROM using one of the factory methods.
	/// </summary>
	[Serializable]
	public class TilesList
	{
		private readonly Tile[] _list;

		public ref Tile this[int i] => ref _list[i];

		private TilesList(Tile[] list)
		{
			_list = list;
		}

		public static readonly TilesList EmptySet = new TilesList(new Tile[]
			{
				new Tile(0, 0), new Tile(0, 0), new Tile(0, 0), new Tile(0, 0)
			});

		public static TilesList CreateNewDefinition(ZScreamer ZS, int position, int count)
		{
			if (count <= 0)
			{
				return EmptySet;
			}

			Tile[] list = new Tile[count];

			for (int i = 0; i < count; i++)
			{
				list[i] = new Tile(ZS.ROM[position + i * 2], ZS.ROM[position + (i * 2) + 1]);
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
					list[i] = new Tile(ZS.ROM[s.Item1 + i * 2], ZS.ROM[s.Item1 + (i * 2) + 1]);
				}
			}

			return new TilesList(list);
		}
	}

	[Serializable]
	public class DoorTilesList
	{
		public TilesList North { get; }
		public TilesList South { get; }
		public TilesList East { get; }
		public TilesList West { get; }

		private const int TilesPerDoor = 24;

		public Tile this[DoorDirection d, int i] {
			get {
				switch (d)
				{
					case DoorDirection.North: return North[i];
					case DoorDirection.South: return South[i];
					case DoorDirection.West: return West[i];
					case DoorDirection.East: return East[i];
				}
				return Tile.Empty;
			}
		}

		public TilesList this[DoorDirection d] {
			get {
				switch (d)
				{
					case DoorDirection.North: return North;
					case DoorDirection.South: return South;
					case DoorDirection.West: return West;
					case DoorDirection.East: return East;
				}
				return null;
			}
		}

		public static readonly DoorTilesList EmptySet =
			new DoorTilesList(TilesList.EmptySet, TilesList.EmptySet, TilesList.EmptySet, TilesList.EmptySet);


		private DoorTilesList(TilesList north, TilesList south, TilesList west, TilesList east)
		{
			North = north;
			South = south;
			West = west;
			East = east;
		}

		public static DoorTilesList CreateNewDefinition(ZScreamer ZS, int posN, int posS, int posW, int posE)
		{
			return new DoorTilesList(
				north: TilesList.CreateNewDefinition(ZS, posN, TilesPerDoor),
				south: TilesList.CreateNewDefinition(ZS, posS, TilesPerDoor),
				west: TilesList.CreateNewDefinition(ZS, posW, TilesPerDoor),
				east: TilesList.CreateNewDefinition(ZS, posE, TilesPerDoor)
			);
		}

	}
}
