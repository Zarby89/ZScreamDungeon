using System;

namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents a background tile as used by the SNES PPU.
	/// </summary>
	[Serializable]
	public readonly struct Tile : IByteable
	{
		/// <summary>
		/// <see langword="true"/> if high priority
		/// </summary>
		public bool Priority { get; }

		/// <summary>
		/// <see langword="true"/> if flipped horizontally across the Y axis
		/// </summary>
		public bool HFlip { get; }

		/// <summary>
		/// <see langword="true"/> if flipped vertically across the X axis
		/// </summary>
		public bool VFlip { get; }

		/// <summary>
		/// 0x01 if high priority
		/// </summary>
		public byte PriorityByte { get; }

		/// <summary>
		/// 0x01 if flipped horizontally across the Y axis
		/// </summary>
		public byte HFlipByte { get; }

		/// <summary>
		/// 0x01 if flipped vertically across the X axis
		/// </summary>
		public byte VFlipByte { get; }

		public ushort ID { get; }

		public byte Palette { get; }


		public static readonly Tile Empty = new Tile(0);

		public Tile(byte b1, byte b2) // Tile from game data
		{
			ID = (ushort) (((b2 & 0x01) << 8) | b1);

			VFlip = (b2 & 0x80) == 0x80;
			VFlipByte = (byte) (VFlip ? 1 : 0);

			HFlip = (b2 & 0x40) == 0x40;
			HFlipByte = (byte) (HFlip ? 1 : 0);

			Priority = (b2 & 0x20) == 0x20;
			PriorityByte = (byte) (Priority ? 1 : 0);

			Palette = (byte) ((b2 >> 2) & 0x07);
		}

		public Tile(ushort id, byte palette, bool priority, bool hflip, bool vflip) // Custom tile
		{
			ID = (ushort) (id & Constants.TileNameMask);

			HFlip = hflip;
			HFlipByte = (byte) (HFlip ? 1 : 0);

			VFlip = vflip;
			VFlipByte = (byte) (VFlip ? 1 : 0);

			Priority = priority;
			PriorityByte = (byte) (Priority ? 1 : 0);

			Palette = palette;
		}

		public Tile(ushort v)
		{
			ID = (ushort) (v & Constants.TileNameMask);

			VFlip = v.BitIsOn(Constants.TileVFlipBit);
			VFlipByte = (byte) (VFlip ? 1 : 0);

			HFlip = v.BitIsOn(Constants.TileHFlipBit);
			HFlipByte = (byte) (HFlip ? 1 : 0);

			Priority = v.BitIsOn(Constants.TilePriorityBit);
			PriorityByte = (byte) (Priority ? 1 : 0);

			Palette = (byte) ((v >> 10) & 0x07);
		}
		public byte[] GetByteData()
		{
			ushort s = ToUnsignedShort();
			return new byte[] { (byte) s, (byte) (s >> 8) };
		}
		public ushort GetModifiedUnsignedShort(bool? hflip = null, bool? vflip = null, bool hox = false, bool vox = false)
		{
			ushort value = (ushort) (((Palette << 10) & 0x1C00) | (ID & Constants.TileNameMask));

			if (hflip ?? (HFlip ^ hox))
			{
				value |= Constants.TileHFlipBit;
			}
			if (vflip ?? (VFlip ^ vox))
			{
				value |= Constants.TileVFlipBit;
			}
			if (Priority)
			{
				value |= Constants.TilePriorityBit;
			}

			return value;
		}
		
		/// <summary>
		/// Returns a copy of this tile with the specified properties changed.
		/// Properties set to <see langword="null"/> are left alone.
		/// </summary>
		public Tile CloneModified(bool? hflip = null, bool? vflip = null, bool hox = false, bool vox = false)
		{
			return new Tile(ID, Palette, Priority, hflip ?? (HFlip ^ hox), vflip ?? (VFlip ^ vox));
		}

		public ushort ToUnsignedShort()
		{
			ushort value = 0;
			// vhopppcc cccccccc
			if (Priority) { value |= Constants.TilePriorityBit; };
			if (HFlip) { value |= Constants.TileHFlipBit; };
			if (VFlip) { value |= Constants.TileVFlipBit; };
			value |= (ushort) ((Palette << 10) & 0x1C00);
			value |= (ushort) (ID & Constants.TileNameMask);
			return value;
		}
	}
}
