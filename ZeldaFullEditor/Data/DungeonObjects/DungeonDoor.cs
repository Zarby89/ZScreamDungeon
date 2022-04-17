using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	[Serializable]
	public unsafe class DungeonDoorObject : DungeonObject, IByteable
	{
		public byte ID { get; set; }
		public byte X { get; set; }
		public byte Y { get; set; }

		public override byte[] Data => new byte[] { ID, DoorPosition.Token };

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
	}
}
