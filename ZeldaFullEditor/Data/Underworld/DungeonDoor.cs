﻿namespace ZeldaFullEditor.Data.Underworld
{
	[Serializable]
	public class DungeonDoor : IDungeonPlaceable, IByteable, IDelegatedDraw
	{
		public byte ID => DoorType.ID;

		public int RealX => NewX * 8;
		public int RealY => NewY * 8;

		public byte Grid { get; set; }
		public byte GridY { get; set; }

		public Rectangle SquareHitbox
		{
			get
			{
				if (DoorPosition.IsHorizontal)
				{
					return new Rectangle(RealX, RealY, 16, 24);
				}

				return new Rectangle(RealX, RealY, 24, 16);
			}
		}

		private byte nx, ny;
		public byte NewX
		{
			get => nx;
			set => nx = value.Clamp(0, 63);
		}
		public byte NewY
		{
			get => ny;
			set => ny = value.Clamp(0, 63);
		}

		public DungeonDoorType DoorType { get; set; } = DungeonDoorType.DoorType00;

		private DungeonDoorDraw position;
		public DungeonDoorDraw DoorPosition
		{
			get => position;
			set
			{
				position = value;
				Tiles = DoorTiles[DoorPosition.Direction];
			}
		}

		private DoorTilesList doorset;

		public DoorTilesList DoorTiles
		{
			get => doorset;
			set
			{
				doorset = value;
				Tiles = DoorTiles[DoorPosition.Direction];
			}
		}

		public TilesList Tiles { get; private set; }

		public DungeonDoor(DungeonDoorDraw position, DoorTilesList tiles)
		{
			this.position = position;
			DoorTiles = tiles;
		}

		public void Draw(Artist art)
		{
			DoorPosition.Draw(art, this);
		}

		public bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}

		public byte[] GetByteData()
		{
			return new byte[] { ID, DoorPosition.Token };
		}
	}

	public class DungeonDoorPreview : DungeonDoor
	{
		public DungeonDoorPreview(DungeonDoorDraw position, DoorTilesList tiles) : base(position, tiles)
		{
		}
	}
}
