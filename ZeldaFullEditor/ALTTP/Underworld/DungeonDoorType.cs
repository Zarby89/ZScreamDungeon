using static ZeldaFullEditor.ALTTP.Underworld.DoorCategory;

namespace ZeldaFullEditor.ALTTP.Underworld;

public class DungeonDoorType : IEntityType<DungeonDoorType>
{
	public byte ID { get; }
	public int ListID => ID;

	public DoorCategory Category { get; }
	public bool IsExit { get; init; }

	public string Name { get; init; }

	internal DoorDrawFunction Draw { get; init; } = DrawStandardDoor;

	internal DungeonDoorType OppositeDoor { get; }

	public bool LowerLayer { get; init; }

	private DungeonDoorType(byte id, string name, DoorCategory category)
	{
		ID = id;
		Name = name;
		Category = category;
	}

	public override string ToString() => $"{ID:X2} - {Name}";

	public static ImmutableArray<DungeonDoorType> ListOf { get; }

	// Need to use static constructor for reflection to work properly
	static DungeonDoorType()
	{
		ListOf = Utils.GetSortedListOfPredefinedFields<DungeonDoorType>();
	}

	public static DungeonDoorType GetTypeFromID(byte id) => ListOf.GetTypeFromID(id);


	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType00 = new(0x00, "Normal door", Unspecial);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType02 = new(0x02, "Normal door (lower layer)", Unspecial)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType04 = new(0x04, "Exit (lower layer)", Unspecial)
	{
		IsExit = true,
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType06 = new(0x06, "Unused cave exit (lower layer)", Unspecial)
	{
		IsExit = true,
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType08 = new(0x08, "Waterfall door", Unspecial);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType0A = new(0x0A, "Fancy dungeon exit", Fancy)
	{
		IsExit = true,
		Draw = DrawFancyEntrance,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType0C = new(0x0C, "Fancy dungeon exit (lower layer)", Fancy)
	{
		IsExit = true,
		LowerLayer = true,
		Draw = DrawFancyEntrance,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType0E = new(0x0E, "Cave exit", Unspecial)
	{
		IsExit = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType10 = new(0x10, "Lit cave exit (lower layer)", Unspecial)
	{
		LowerLayer = true,
		IsExit = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType12 = new(0x12, "Exit marker", Meta)
	{
		IsExit = true,
		Draw = DrawNothing,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType14 = new(0x14, "Dungeon swap marker", DungeonSwap)
	{
		Draw = DrawNothing,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType16 = new(0x16, "Layer swap marker", LayerSwap)
	{
		Draw = DrawNothing,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType18 = new(0x18, "Double sided shutter door", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType1A = new(0x1A, "Eye watch door", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType1C = new(0x1C, "Small key door", Openable);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType1E = new(0x1E, "Big key door", Openable);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType20 = new(0x20, "Small key stairs (upwards)", Openable)
	{
		Draw = DrawKeyStairs,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType22 = new(0x22, "Small key stairs (downwards)", Openable)
	{
		Draw = DrawKeyStairs,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType24 = new(0x24, "Small key stairs (lower layer; upwards)", Openable)
	{
		LowerLayer = true,
		Draw = DrawKeyStairs,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType26 = new(0x26, "Small key stairs (lower layer; downwards)", Openable)
	{
		LowerLayer = true,
		Draw = DrawKeyStairs,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType28 = new(0x28, "Dash wall", Openable);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType2A = new(0x2A, "Bombable cave exit", Openable)
	{
		IsExit = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType2C = new(0x2C, "Unopenable, double-sided big key door", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType2E = new(0x2E, "Bombable door", Openable);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType30 = new(0x30, "Exploding wall", Openable)
	{
		Draw = DrawExplodingWall,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType32 = new(0x32, "Curtain door", Openable);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType34 = new(0x34, "Unusable bottom-sided shutter door", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType36 = new(0x36, "Bottom-sided shutter door", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType38 = new(0x38, "Top-sided shutter door", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType3A = new(0x3A, "Unusable normal door (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType3C = new(0x3C, "Unusable normal door (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType3E = new(0x3E, "Unusable normal door (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType40 = new(0x40, "Normal door (lower layer; used with one-sided shutters)", Unspecial)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType42 = new(0x42, "Unused double-sided shutter", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType44 = new(0x44, "Double-sided shutter (lower layer)", Shutter)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType46 = new(0x46, "Explicit room door", Meta);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType48 = new(0x48, "Bottom-sided shutter door (lower layer)", Shutter)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType4A = new(0x4A, "Top-sided shutter door (lower layer)", Shutter)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType4C = new(0x4C, "Unusable normal door (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType4E = new(0x4E, "Unusable normal door (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType50 = new(0x50, "Unusable normal door (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType52 = new(0x52, "Unusable bombed-open door (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType54 = new(0x54, "Unusable glitchy door (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType56 = new(0x56, "Unusable glitchy door (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType58 = new(0x58, "Unusable normal door (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType5A = new(0x5A, "Unusable glitchy/stairs up (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType5C = new(0x5C, "Unusable glitchy/stairs up (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType5E = new(0x5E, "Unusable glitchy/stairs up (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType60 = new(0x60, "Unusable glitchy/stairs up (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType62 = new(0x62, "Unusable glitchy/stairs down (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType64 = new(0x64, "Unusable glitchy/stairs up (lower layer)", Garbage)
	{
		LowerLayer = true,
	};

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType66 = new(0x66, "Unusable glitchy/stairs down (lower layer)", Garbage)
	{
		LowerLayer = true,
	};



	private static void DrawNothing(TilemapArtist art, DungeonDoor door)
	{
		// this page left intentionally blank
	}

	private static void DrawOneStandard(TilemapArtist art, DungeonDoor door, DungeonDoorPosition position)
	{
		// TODO figure out
		bool trimLoc = false;

		switch (position?.Direction)
		{
			case DoorDirection.North:
				DrawTiles(art, position, door.DoorType, trimLoc, position.TilemapPosition, new DrawInfo(0, 0, 0),
					new DrawInfo(3, 8, 0),
					new DrawInfo(6, 16, 0),
					new DrawInfo(9, 24, 0)
				);

				DrawTiles(art, position, door.DoorType, door.DoorType.LowerLayer, position.TilemapPosition, new DrawInfo(1, 0, 8),
					new DrawInfo(4, 8, 8),
					new DrawInfo(7, 16, 8),
					new DrawInfo(10, 24, 8),

					new DrawInfo(2, 0, 16),
					new DrawInfo(5, 8, 16),
					new DrawInfo(8, 16, 16),
					new DrawInfo(11, 24, 16)
				);

				break;

			case DoorDirection.South:
				DrawTiles(art, position, door.DoorType, trimLoc, position.TilemapPosition, new DrawInfo(2, 0, 16),
					new DrawInfo(5, 8, 16),
					new DrawInfo(8, 16, 16),
					new DrawInfo(11, 24, 16)
				);

				DrawTiles(art, position, door.DoorType, door.DoorType.LowerLayer, position.TilemapPosition, new DrawInfo(0, 0, 0),
					new DrawInfo(3, 8, 0),
					new DrawInfo(6, 16, 0),
					new DrawInfo(9, 24, 0),

					new DrawInfo(1, 0, 8),
					new DrawInfo(4, 8, 8),
					new DrawInfo(7, 16, 8),
					new DrawInfo(10, 24, 8)
				);
				break;

			case DoorDirection.West:
				DrawTiles(art, position, door.DoorType, trimLoc, position.TilemapPosition, new DrawInfo(0, 0, 0),
					new DrawInfo(1, 0, 8),
					new DrawInfo(2, 0, 16),
					new DrawInfo(3, 0, 24)
				);

				DrawTiles(art, position, door.DoorType, door.DoorType.LowerLayer, position.TilemapPosition, new DrawInfo(4, 8, 0),
					new DrawInfo(5, 8, 8),
					new DrawInfo(6, 8, 16),
					new DrawInfo(7, 8, 24),

					new DrawInfo(8, 16, 0),
					new DrawInfo(9, 16, 8),
					new DrawInfo(10, 16, 16),
					new DrawInfo(11, 16, 24)
				);
				break;

			case DoorDirection.East:
				DrawTiles(art, position, door.DoorType, trimLoc, position.TilemapPosition, new DrawInfo(8, 16, 0),
					new DrawInfo(9, 16, 8),
					new DrawInfo(10, 16, 16),
					new DrawInfo(11, 16, 24)
				);

				DrawTiles(art, position, door.DoorType, door.DoorType.LowerLayer, position.TilemapPosition, new DrawInfo(0, 0, 0),
					new DrawInfo(1, 0, 8),
					new DrawInfo(2, 0, 16),
					new DrawInfo(3, 0, 24),

					new DrawInfo(4, 8, 0),
					new DrawInfo(5, 8, 8),
					new DrawInfo(6, 8, 16),
					new DrawInfo(7, 8, 24)
				);
				break;
		}
	}

	private static void DrawStandardDoor(TilemapArtist art, DungeonDoor door)
	{
		DrawOneStandard(art, door, door.Position);
		DrawOneStandard(art, door, door.Position.Partner);
	}

	private static void DrawFancyEntrance(TilemapArtist art, DungeonDoor door)
	{
		if (door.Position.Direction != DoorDirection.South)
		{
			DrawStandardDoor(art, door);
			return;
		}

		ushort tmap = (ushort) (door.Position.TilemapPosition - (64 * 5) - 3);
		var tiles = ZScreamer.ActiveScreamer.TileLister.FancyEntrance;

		var instructions = new DrawInfo[80];
		int i = 0;

		for (int y = 0; y < 8 * 8; y += 8)
		{
			for (int x = 0; x < 10 * 8; x += 8)
			{
				instructions[i] = new(i++, x, y);
			}
		}

		DrawTiles(art, tiles, door.DoorType.LowerLayer, tmap, instructions);
	}

	private static void DrawExplodingWall(TilemapArtist art, DungeonDoor door)
	{
		if (door.Position.Direction != DoorDirection.North)
		{
			DrawStandardDoor(art, door);
			return;
		}
	}

	private static void DrawKeyStairs(TilemapArtist art, DungeonDoor door)
	{

		DrawOneStandard(art, door, door.Position);

		if (door.Position.Direction == DoorDirection.North) return;

		DrawOneStandard(art, door, door.Position.Partner);
	}


	private static void DrawTiles(TilemapArtist art, DungeonDoorPosition pos, DungeonDoorType type, bool bg2, ushort tmap, params DrawInfo[] instructions)
	{
		var tiles = ZScreamer.ActiveScreamer.TileLister.GetDoorTileSet(type.ID)[pos.Direction];

		DrawTiles(art, tiles, bg2, tmap, instructions);
	}

	private static void DrawTiles(TilemapArtist art, TilesList tiles, bool bg2, ushort tmap, params DrawInfo[] instructions)
	{
		foreach (var d in instructions)
		{
			var tm = tmap + d.XOff / 8 + d.YOff / 8 * 64;

			if (tm is < Constants.TilesPerUnderworldRoom and >= 0)
			{
				var td = tiles[d.TileIndex].GetModifiedUnsignedShort(hflip: d.HFlip, vflip: d.VFlip);

				if (bg2)
				{
					art.Layer2TileMap[tm] = td;
				}
				else
				{
					art.Layer1TileMap[tm] = td;
				}
			}
		}
	}
}
