using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public static class SNESFunctions
	{
		public static int SNEStoPC(this int addr) => (addr & 0x7FFF) | ((addr & 0x7F0000) >> 1);
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
			/// United states
			/// </summary>
			US,
			/// <summary>
			/// French canada
			/// </summary>
			//FRCA
		}
	}
}
