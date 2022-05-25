namespace ZeldaFullEditor.Modeling.GameData
{
	/// <summary>
	/// Provides methods for converting to and from tilemap positions in the underworld.
	/// </summary>
	public static class UWTilemapPosition
	{
		public static (byte low, byte high) CreateLowAndHighBytesFromXYZ(byte x, byte y, byte layer)
		{
			int manip = (layer << 14) | (y << 7) | (x << 1);
			byte low = (byte) manip;
			byte high = (byte) (manip >> 8);
			return (low, high);
		}

		public static (byte x, byte y, byte layer) CreateXYZFromTileMap(byte low, byte high)
		{
			int manip = (high & 0x1F) << 7 | (low >> 1);
			byte x = (byte) (manip % 64);
			byte y = (byte) (manip >> 6);
			byte layer = (byte) (high >> 5);

			return (x, y, layer);
		}

		public static (byte x, byte y, byte layer) CreateXYZFromTileMap(ushort tmap)
		{
			return CreateXYZFromTileMap((byte) tmap, (byte) (tmap >> 8));
		}
	}
}
