﻿namespace ZeldaFullEditor.Utility
{
	public static class SNESFunctions
	{
		/// <summary>
		/// Converts a SNES system bus address from lorom mapping to a binary file offset.
		/// </summary>
		public static int SNEStoPC(this int addr) => (addr & 0x7FFF) | ((addr & 0x7F0000) >> 1);

		/// <summary>
		/// Converts a binary file offset to a SNES system bus address for the lorom mapping.
		/// </summary>
		public static int PCtoSNES(this int addr) => (addr & 0x7FFF) | 0x8000 | ((addr & 0x7F8000) << 1);

		public static int GetBank(this int addr) => addr & 0xFF0000;

		public static byte GetBankAsByte(this int addr) => (byte) ((addr & 0xFF0000) >> 16);

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
}
