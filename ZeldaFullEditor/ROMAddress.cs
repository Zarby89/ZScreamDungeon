using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents a location in code or data that contains a precalculated conversion from lorom SNES addressing to file offset.
	/// </summary>
	public struct ROMAddress
	{
		private readonly int snesj, snesu, pcj, pcu;

		/// <summary>
		/// Gets the SNES address for the JP1.0 version.
		/// </summary>
		public int JPAddress { get => snesj; }

		/// <summary>
		/// Gets the ROM file offset (PC address) for the JP1.0 version.
		/// </summary>
		public int JPOffset { get => pcj; }

		/// <summary>
		/// Gets the SNES address for the US version.
		/// </summary>
		public int USAddress { get => snesu; }

		/// <summary>
		/// Gets the ROM file offset (PC address) for the US version.
		/// </summary>
		public int USOffset { get => pcu; }

		/// <summary>
		/// Initializes an address with values for both the JP1.0 and US versions.
		/// The input parameters are under SNES mapping.<br/>
		/// </summary>
		/// <param name="jp">JP1.0 SNES address</param>
		/// <param name="us">US SNES address</param>
		public ROMAddress(int jp, int us)
		{
			snesj = jp & 0xFFFFFF;
			pcj = (jp & 0x7FFF) | ((jp & 0x7F0000) >> 1);
			snesu = us & 0xFFFFFF;
			pcu = (us & 0x7FFF) | ((us & 0x7F0000) >> 1);
		}

		/// <summary>
		/// Initializes an address with values for both the JP1.0 and US versions,
		/// with the assumption that the address is the same for both versions.<br/>
		/// The input parameters are under SNES mapping.
		/// </summary>
		/// <param name="jp">JP1.0 SNES address</param>
		/// <param name="us">US SNES address</param>
		public ROMAddress(int addr)
		{
			snesu = snesj = addr & 0xFFFFFF;
			pcu = pcj = (snesj & 0x7FFF) | ((snesj & 0x7F0000) >> 1);
		}

		public static ROMAddress operator +(ROMAddress r, int offset) => new ROMAddress(r.snesj + offset, r.snesu + offset);
		public static ROMAddress operator -(ROMAddress r, int offset) => new ROMAddress(r.snesj - offset, r.snesu - offset);

		/// <summary>
		/// Inspects the given address to confirm they are valid ROM addresses.s
		/// </summary>
		public bool CheckIfValidROMAddress(SNESFunctions.ROMVersion? version = null)
		{
			switch (version)
			{
				case SNESFunctions.ROMVersion.JP: return (snesj & 0xFFFF) >= 0x8000;
				case SNESFunctions.ROMVersion.US: return (snesu & 0xFFFF) >= 0x8000;
				default: return ((snesj & 0xFFFF) >= 0x8000) && ((snesu & 0xFFFF) >= 0x8000);
			}
		}

		/// <summary>
		/// Inspects the given address for being in a fast ROM bank.
		/// </summary>
		/// <returns></returns>
		public bool CheckIfFastROM(SNESFunctions.ROMVersion? version = null)
		{
			switch (version)
			{
				case SNESFunctions.ROMVersion.JP: return (snesj & 0x800000) == 0x800000;
				case SNESFunctions.ROMVersion.US: return (snesu & 0x800000) == 0x800000;
				default: return ((snesj & 0x800000) >= 0x800000) && ((snesu & 0x800000) == 0x800000);
			}
		}

		/// <summary>
		/// Returns <see langword="true"/> if the addresses between versions differ.
		/// </summary>
		public bool CheckForVersionDifferences() => snesj != snesu;
	}

	public static class SNESFunctions
	{
		public static int SNEStoPC(this int addr) => (addr & 0x7FFF) | ((addr & 0x7F0000) >> 1);
		public static int PCtoSNES(this int addr) => (addr & 0x7FFF) | 0x8000 | ((addr & 0x78000) << 1);
		public static int GetBank(this int addr) => addr & 0xFF0000;
		public static byte GetBankAsByte(this int addr) => (byte) ((addr & 0xFF0000) >> 16);

		public static int GetBank(this ROMAddress r, ROMVersion version)
		{
			switch (version)
			{
				case ROMVersion.JP:
					return r.JPAddress & 0xFF0000;

				case ROMVersion.US:
					return r.USAddress & 0xFF0000;

				default:
					return 0x00;
			}
		}

		public static byte GetBankAsByte(this ROMAddress r, ROMVersion version)
		{
			switch (version)
			{
				case ROMVersion.JP:
					return (byte) ((r.JPAddress & 0xFF0000) >> 16);

				case ROMVersion.US:
					return (byte) ((r.USAddress & 0xFF0000) >> 16);

				default:
					return 0x00;
			}
		}

		public enum ROMVersion
		{
			JP,
			US
		}
	}
}
