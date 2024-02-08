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
			bool b7 = false, bool b6 = false, bool b5 = false, bool b4 = false,
			bool b3 = false, bool b2 = false, bool b1 = false, bool b0 = false)
		{
			return (byte)(
				(b0 ? (1 << 0) : 0) |
				(b1 ? (1 << 1) : 0) |
				(b2 ? (1 << 2) : 0) |
				(b3 ? (1 << 3) : 0) |
				(b4 ? (1 << 4) : 0) |
				(b5 ? (1 << 5) : 0) |
				(b6 ? (1 << 6) : 0) |
                (b7 ? (1 << 7) : 0));
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
