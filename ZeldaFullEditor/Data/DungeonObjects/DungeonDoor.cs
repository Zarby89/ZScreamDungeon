using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	[Serializable]
	public unsafe class DungeonDoorObject : DungeonPlaceable, IByteable, IMouseCollidable
	{
		public byte ID => DoorType.ID;
		public byte X { get; set; }
		public byte Y { get; set; }

		private byte nx, ny;
		public byte NX
		{
			get => nx;
			set => nx = value.Clamp(0, 63);
		}
		public byte NY
		{
			get => ny;
			set => ny = value.Clamp(0, 63);
		}

		public byte[] Data => new byte[] { ID, DoorPosition.Token };

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

		public DungeonDoorObject(DungeonDoorDraw position, DoorTilesList tiles)
		{
			this.position = position;
			DoorTiles = tiles;
		}

		public override void Draw(ZScreamer ZS)
		{
			DoorPosition.Draw(ZS, this);
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}
