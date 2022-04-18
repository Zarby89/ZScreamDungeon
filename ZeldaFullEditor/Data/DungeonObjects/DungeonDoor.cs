using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	[Serializable]
	public unsafe class DungeonDoorObject : DungeonObject, IByteable, IMouseCollidable
	{
		public byte ID { get; set; }
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

		public override byte[] Data => new byte[] { ID, DoorPosition.Token };

		public DungeonDoorType DoorType { get; set; }

		private DungeonDoorDraw position;
		public DungeonDoorDraw DoorPosition
		{
			get => position;
			set
			{
				position = value;
				_tiles = DoorTiles[DoorPosition.Direction];
			}
		}

		private DoorTilesList doorset;

		public DoorTilesList DoorTiles
		{
			get => doorset;
			set
			{
				doorset = value;
				_tiles = DoorTiles[DoorPosition.Direction];
			}
		}

		private TilesList _tiles;
		public override TilesList Tiles => _tiles;

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
