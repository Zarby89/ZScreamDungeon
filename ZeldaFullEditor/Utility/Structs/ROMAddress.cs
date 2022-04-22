using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ZeldaFullEditor.SNESFunctions;

namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents a location in code or data that contains a precalculated conversion from lorom SNES addressing to file offset.
	/// </summary>
	public readonly struct ROMAddress
	{
		/// <summary>
		/// Gets the SNES address for the JP1.0 version.
		/// </summary>
		public int JPAddress { get; }

		/// <summary>
		/// Gets the ROM file offset (PC address) for the JP1.0 version.
		/// </summary>
		public int JPOffset { get; }

		/// <summary>
		/// Gets the SNES address for the US version.
		/// </summary>
		public int USAddress { get; }

		/// <summary>
		/// Gets the ROM file offset (PC address) for the US version.
		/// </summary>
		public int USOffset { get; }

		/// <summary>
		/// Initializes an address with values for both the JP1.0 and US versions.
		/// The input parameters are under SNES mapping.<br/>
		/// </summary>
		/// <param name="jp">JP1.0 SNES address</param>
		/// <param name="us">US SNES address</param>
		public ROMAddress(int jp, int us)
		{
			JPAddress = jp & 0xFFFFFF;
			JPOffset = (jp & 0x7FFF) | ((jp & 0x7F0000) >> 1);
			USAddress = us & 0xFFFFFF;
			USOffset = (us & 0x7FFF) | ((us & 0x7F0000) >> 1);
		}

		/// <summary>
		/// Initializes an address with values for both the JP1.0 and US versions,
		/// with the assumption that the address is the same for both versions.<br/>
		/// The input parameters are under SNES mapping.
		/// </summary>
		public ROMAddress(int addr)
		{
			USAddress = JPAddress = addr & 0xFFFFFF;
			USOffset = JPOffset = (addr & 0x7FFF) | ((addr & 0x7F0000) >> 1);
		}

		public int GetAddressForVersion(ROMVersion v)
		{
			switch (v)
			{
				case ROMVersion.JP: return JPAddress;
				case ROMVersion.US: return USAddress;
			}
			return 0;
		}

		public int GetOffsetForVersion(ROMVersion v)
		{
			switch (v)
			{
				case ROMVersion.JP: return JPOffset;
				case ROMVersion.US: return USOffset;
			}
			return 0;
		}

		public static ROMAddress operator +(ROMAddress r, int offset) => new ROMAddress(r.JPAddress + offset, r.USAddress + offset);
		public static ROMAddress operator -(ROMAddress r, int offset) => new ROMAddress(r.JPAddress - offset, r.USAddress - offset);

		public static implicit operator ROMAddress(int jp) => new ROMAddress(jp);

		/// <summary>
		/// Inspects the given address to confirm they are valid ROM addresses.s
		/// </summary>
		public bool CheckIfValidROMAddress(ROMVersion? version = null)
		{
			switch (version)
			{
				case ROMVersion.JP: return (JPAddress & 0xFFFF) >= 0x8000;
				case ROMVersion.US: return (USAddress & 0xFFFF) >= 0x8000;
				default: return ((JPAddress & 0xFFFF) >= 0x8000) && ((USAddress & 0xFFFF) >= 0x8000);
			}
		}

		/// <summary>
		/// Inspects the given address for being in a fast ROM bank.
		/// </summary>
		public bool CheckIfFastROM(ROMVersion? version = null)
		{
			switch (version)
			{
				case ROMVersion.JP: return (JPAddress & 0x800000) == 0x800000;
				case ROMVersion.US: return (USAddress & 0x800000) == 0x800000;
				default: return ((JPAddress & 0x800000) >= 0x800000) && ((USAddress & 0x800000) == 0x800000);
			}
		}

		/// <summary>
		/// Returns <see langword="true"/> if the addresses between versions differ.
		/// </summary>
		public bool HasVersionDifferences => JPAddress != USAddress;
	}
}
