namespace ZeldaFullEditor.Utility;

/// <summary>
/// Provides extended functionality for simple operations on integer value types.
/// </summary>
public static class IntFunctions
{
	/// <summary>
	/// Tests whether any of the bits in <paramref name="b"/> are contained in <paramref name="test"/>.
	/// </summary>
	/// <returns><see langword="true"/> if the logical and of <paramref name="b"/> and <paramref name="test"/> is nonzero;
	/// otherwise <see langword="false"/></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BitIsOn(this byte b, byte test) => (b & test) != 0;


	/// <summary>
	/// Tests an operand to see if it fully contains a specified bitmask.
	/// </summary>
	/// <param name="b">Value to test</param>
	/// <param name="test">Bitmask to test</param>
	/// <returns><see langword="true"/> if <c><paramref name="b"/> &amp; <paramref name="test"/> = <paramref name="test"/></c>;
	/// otherwise <see langword="false"/></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BitsAllSet(this byte b, byte test) => (b & test) == test;

	/// <inheritdoc cref="BitIsOn(byte, byte)"/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BitIsOn(this int b, int test) => (b & test) != 0;

	/// <inheritdoc cref="BitsAllSet(byte, byte)"/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BitsAllSet(this int b, int test) => (b & test) == test;


	/// <inheritdoc cref="BitIsOn(byte, byte)"/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BitIsOn(this short b, short test) => (b & test) != 0;

	/// <inheritdoc cref="BitsAllSet(byte, byte)"/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BitsAllSet(this short b, short test) => (b & test) == test;

	/// <inheritdoc cref="BitIsOn(byte, byte)"/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BitIsOn(this ushort b, ushort test) => (b & test) != 0;

	/// <inheritdoc cref="BitsAllSet(byte, byte)"/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
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

	public static byte SetFieldBits(byte baseval = 0,
		bool bit0 = false, bool bit1 = false, bool bit2 = false, bool bit3 = false,
		bool bit4 = false, bool bit5 = false, bool bit6 = false, bool bit7 = false)
	{
		return (byte) (baseval |
			(bit0 ? 1 << 0 : 0) |
			(bit1 ? 1 << 1 : 0) |
			(bit2 ? 1 << 2 : 0) |
			(bit3 ? 1 << 3 : 0) |
			(bit4 ? 1 << 4 : 0) |
			(bit5 ? 1 << 5 : 0) |
			(bit6 ? 1 << 6 : 0) |
			(bit7 ? 1 << 7 : 0)
		);
	}

	/// <summary>
	/// Clamps value <paramref name="v"/> to be within the range [<paramref name="min"/>, <paramref name="max"/>].
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Clamp(this int v, int min, int max)
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

	/// <inheritdoc cref="Clamp(int, int, int)"/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ushort Clamp(this ushort v, ushort min, ushort max)
	{
		if (v >= max)
		{
			v = max;
		}
		else if (v <= min)
		{
			v = min;
		}

		return v;
	}

	/// <inheritdoc cref="Clamp(int, int, int)"/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte Clamp(this byte v, byte min, byte max)
	{
		if (v >= max)
		{
			v = max;
		}
		else if (v <= min)
		{
			v = min;
		}

		return v;
	}
}
