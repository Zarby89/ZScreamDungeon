namespace ZeldaFullEditor.ALTTP.Underworld;

internal delegate void DoorDrawFunction(TilemapArtist art, DungeonDoor door);

/// <summary>
/// Represents a door or door modifier that controls transitions in and out of dungeon rooms.
/// </summary>
[Serializable]
public class DungeonDoor : IDungeonPlaceable, IByteable, IDelegatedDraw, IHaveInfo
{
	public byte ID => DoorType.ID;

	public int RealX => position.RealX;
	public int RealY => position.RealY;

	// TODO need a way to change shape for the special door draws
	public Rectangle BoundingBox => position.BoundingBox;

	private DungeonDoorType doortype = DungeonDoorType.DoorType00;
	public DungeonDoorType DoorType {
		get => doortype;
		set
		{
			doortype = value;
			//FindNewTileSet();
		}
	}

	private DungeonDoorPosition position = DungeonDoorPosition.North00;
	public DungeonDoorPosition Position
	{
		get => position;
		set
		{
			position = value;
			//UpdateTilesForPosition();
		}
	}

	private DoorTilesList DoorTiles = DoorTilesList.EmptySet;

	public TilesList Tiles { get; private set; }

	public string Name => DoorType.Name;

	public DungeonDoor(DungeonDoorType type, DungeonDoorPosition position)
	{
		this.position = position;
		DoorType = type;
	}

	private void FindNewTileSet()
	{
		DoorTiles = ZScreamer.ActiveScreamer.TileLister.GetDoorTileSet(ID);
		UpdateTilesForPosition();
	}

	private void UpdateTilesForPosition()
	{
		Tiles = DoorTiles[Position.Direction];
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
		return new byte[] { ID, Position.Token };
	}
}

public class DungeonDoorPreview : DungeonDoor
{
	public DungeonDoorPreview(DungeonDoorType type, DungeonDoorPosition position) : base(type, position)
	{
	}
}
