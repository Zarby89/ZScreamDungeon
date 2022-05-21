namespace ZeldaFullEditor.Modeling.GameData
{
	/// <summary>
	/// Provides methods for converting to and from tilemap positions in the underworld.
	/// </summary>
	public static class UWTilemapPosition
	{
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
	}
}
