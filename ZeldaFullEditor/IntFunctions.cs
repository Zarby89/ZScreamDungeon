namespace ZeldaFullEditor
{
	/// <summary>
	/// Provides extended functionality for simple operations on integer value types.
	/// </summary>
	public static class IntFunctions
	{
		public static bool BitIsOn(this byte b, byte test) => (b & test) != 0;

		public static bool BitsAllSet(this byte b, byte test) => (b & test) == test;

        public static bool BitIsOn(this int b, int test) => (b & test) != 0;

        public static bool BitsAllSet(this int b, int test) => (b & test) == test;

		public static bool BitIsOn(this short b, short test) => (b & test) != 0;

		public static bool BitsAllSet(this short b, short test) => (b & test) == test;

		public static bool BitIsOn(this ushort b, ushort test) => (b & test) != 0;

		public static bool BitsAllSet(this ushort b, ushort test) => (b & test) == test;

		public static byte GetLowNibble(this int b) => (byte) (b & 0xF);
		public static byte GetHighNibble(this int b) => (byte) ((b >> 4) & 0xF);
		public static byte GetLowNibble(this byte b) => (byte) (b & 0xF);
		public static byte GetHighNibble(this byte b) => (byte) ((b >> 4) & 0xF);


		public static byte GetMaskWithLowSignificance(this byte b, byte mask)
		{
			int i = 0;
			for (; i < 8; i++)
			{
				if (mask.BitIsOn((byte) (1 << i))) break;
			}

			return (byte) ((b & mask) >> i);
		}

		public static byte MakeBitfield(
			bool bit7 = false, bool bit6 = false, bool bit5 = false, bool bit4 = false,
			bool bit3 = false, bool bit2 = false, bool bit1 = false, bool bit0 = false)
		{
			return (byte) (
				(bit0 ? (1 << 0) : 0) |
				(bit1 ? (1 << 1) : 0) |
				(bit2 ? (1 << 2) : 0) |
				(bit3 ? (1 << 3) : 0) |
				(bit4 ? (1 << 4) : 0) |
				(bit5 ? (1 << 5) : 0) |
				(bit6 ? (1 << 6) : 0) |
				(bit7 ? (1 << 7) : 0));
		}

		public static int Clamp(this int v, int min, int max)
		{
			if (v > max)
			{
				return max;
			}
			else if (v < min)
			{
				return min;
			}

			return v;
		}

		public static ushort Clamp(this ushort v, ushort min, ushort max)
		{
			if (v > max)
			{
				return max;
			}
			else if (v < min)
			{
				return min;
			}

			return v;
		}

		public static byte Clamp(this byte v, byte min, byte max)
		{
			if (v > max)
			{
				v = max;
			}
			else if (v < min)
			{
				v = min;
			}

			return v;
		}
	}
}
