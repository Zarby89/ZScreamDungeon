using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
	public readonly struct UWTilemapPosition
	{
		public byte X { get; }
		public byte Y { get; }
		public byte Layer { get; }

		public ushort Position { get; }

		private UWTilemapPosition(byte low, byte high)
		{
			Position = (ushort) (low | (high << 8));
			int manip = (high & 0x1F) << 7 | (low >> 1);
			X = (byte) (manip % 64);
			Y = (byte) (manip >> 6);
			Layer = (byte) (high >> 5);

		}

		public static UWTilemapPosition CreateFromTileMapPosition(byte tlow, byte thigh)
		{
			return new UWTilemapPosition(tlow, thigh);
		}
		public static UWTilemapPosition CreateFromXYZ(byte x, byte y, byte layer)
		{
			int manip = (layer << 13) | (y << 6) | x;
			return new UWTilemapPosition((byte) manip, (byte) (manip >> 8));
		}

	}
}
