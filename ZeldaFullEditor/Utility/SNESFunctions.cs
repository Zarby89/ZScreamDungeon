namespace ZeldaFullEditor.Utility;

public static class SNESFunctions
{
	/// <summary>
	/// Converts a SNES system bus address from lorom mapping to a binary file offset.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SNEStoPC(this int addr) => (addr & 0x7FFF) | ((addr & 0x7F0000) >> 1);

	/// <summary>
	/// Converts a binary file offset to a SNES system bus address for the lorom mapping.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int PCtoSNES(this int addr) => (addr & 0x7FFF) | 0x8000 | ((addr & 0x7F8000) << 1);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetBank(this int addr) => addr & 0xFF0000;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte GetBankAsByte(this int addr) => (byte) ((addr & 0xFF0000) >> 16);


	public static Color ToColor(this ushort c)
	{
		return Color.FromArgb((c & 0x1F) << 3, (c >> 2) & 0xF8, (c >> 7) & 0xF8);
	}

	public enum ROMVersion
	{
		/// <summary>
		/// Japanese 1.0
		/// </summary>
		JP,
		/// <summary>
		/// United States
		/// </summary>
		US,
		/// <summary>
		/// French canada
		/// </summary>
		//FRCA
	}
}
