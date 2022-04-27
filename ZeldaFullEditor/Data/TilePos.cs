using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public readonly struct TilePos
	{
		public byte MapX { get; }
		public byte MapY { get; }
		public ushort Map16Value { get; }

		public bool IsGarbage => Map16Value == 0xFFFF;

		public TilePos(byte x, byte y, ushort tileId)
		{
			MapX = x;
			MapY = y;
			Map16Value = tileId;
		}

		public static TilePos GarbageTile = new TilePos(0xFF, 0xFF, 0xFFFF);
	}
}
