namespace ZeldaFullEditor.ALTTP.Underworld;

internal delegate void DoorDrawFunction(TilemapArtist art, DungeonDoor door);

/// <summary>
/// Represents a door or door modifier that controls transitions in and out of dungeon rooms.
/// </summary>
[Serializable]
public class DungeonDoor : IDungeonPlaceable, IByteable, IDelegatedDraw, IHaveInfo
{
	public byte ID => DoorType.ID;

	public int RealX => Position.RealX;
	public int RealY => Position.RealY;

	// TODO need a way to change shape for the special door draws
	public Rectangle BoundingBox => Position.BoundingBox;

	public DungeonDoorType DoorType { get; set; } = DungeonDoorType.DoorType00;
	public DungeonDoorPosition Position { get; set; } = DungeonDoorPosition.North00;

	public ushort CurrentObjectListIndex => Position.Direction switch
	{
		DoorDirection.North => DoorType.TileIndexNorth,
		DoorDirection.South => DoorType.TileIndexSouth,
		DoorDirection.West => DoorType.TileIndexWest,
		DoorDirection.East => DoorType.TileIndexEast,
		_ => 0x0000,
	};

	public string Name => DoorType.Name;

	public DungeonDoor(DungeonDoorType type, DungeonDoorPosition position)
	{
		Position = position;
		DoorType = type;
	}

	public void Draw(IDrawArt artist)
	{
		var art = (TilemapArtist) artist;

		if (art is null) return;

		DoorType.Draw(art, this);
	}

	public bool PointIsInHitbox(int x, int y)
	{
		return Position.BoundingBox.Contains(x, y);
	}

	public byte[] GetByteData()
	{
		return new byte[] { Position.Token, ID };
	}
}
