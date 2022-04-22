namespace ZeldaFullEditor
{
	public readonly struct UWTilemapPosition
	{
		public byte X { get; }
		public byte Y { get; }
		public byte Layer { get; }

		public ushort Position { get; }

		public byte Low => (byte) Position;
		public byte High => (byte) (Position >> 8);

		private UWTilemapPosition(byte low, byte high)
		{
			Position = (ushort) (low | (high << 8));
			int manip = (high & 0x1F) << 7 | (low >> 1);
			X = (byte) (manip % 64);
			Y = (byte) (manip >> 6);
			Layer = (byte) (high >> 5);
		}

		public static void CreateLowAndHighBytesFromXYZ(byte x, byte y, byte layer, out byte low, out byte high)
		{
			int manip = (layer << 14) | (y << 7) | (x << 1);
			low = (byte) manip;
			high = (byte) (manip >> 8);
		}

		public static void CreateXYZFromTileMap(byte low, byte high, out byte x, out byte y, out byte layer)
		{
			int manip = (high & 0x1F) << 7 | (low >> 1);
			x = (byte) (manip % 64);
			y = (byte) (manip >> 6);
			layer = (byte) (high >> 5);
		}

		public static void CreateXYZFromTileMap(ushort tmap, out byte x, out byte y, out byte layer)
		{
			CreateXYZFromTileMap((byte) tmap, (byte) (tmap >> 8), out x, out y, out layer);
		}

		public static UWTilemapPosition CreateFromTileMapPosition(ushort tmap)
		{
			return new UWTilemapPosition((byte) tmap, (byte) (tmap >> 8));
		}

		public static UWTilemapPosition CreateFromTileMapPosition(byte tlow, byte thigh)
		{
			return new UWTilemapPosition(tlow, thigh);
		}

		public static UWTilemapPosition CreateFromXYZ(byte x, byte y, byte layer)
		{
			CreateLowAndHighBytesFromXYZ(x, y, layer, out byte low, out byte high);
			return new UWTilemapPosition(low, high);
		}

	}
}
