namespace ZeldaFullEditor.Modeling.GameData.GraphicsData
{
	[Serializable]
	public class DoorTilesList
	{
		public TilesList North { get; }
		public TilesList South { get; }
		public TilesList East { get; }
		public TilesList West { get; }

		private const int TilesPerDoor = 24;

		public Tile this[DoorDirection d, int i] => d switch
		{
			DoorDirection.North => North[i],
			DoorDirection.South => South[i],
			DoorDirection.West => West[i],
			DoorDirection.East => East[i],
			_ => Tile.Empty,
		};

		public TilesList this[DoorDirection d] => d switch
		{
			DoorDirection.North => North,
			DoorDirection.South => South,
			DoorDirection.West => West,
			DoorDirection.East => East,
			_ => null,
		};

		public static readonly DoorTilesList EmptySet =
			new(TilesList.EmptySet, TilesList.EmptySet, TilesList.EmptySet, TilesList.EmptySet);


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
