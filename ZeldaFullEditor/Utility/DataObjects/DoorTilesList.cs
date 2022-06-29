using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	[Serializable]
	public class DoorTilesList
	{
		public TilesList North { get; }
		public TilesList South { get; }
		public TilesList East { get; }
		public TilesList West { get; }

		private const int TilesPerDoor = 24;

		public Tile this[DoorDirection d, int i]
		{
			get
			{
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

		public TilesList this[DoorDirection d]
		{
			get
			{
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
