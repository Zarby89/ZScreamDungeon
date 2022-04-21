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
		/// True if high priority
		/// </summary>
		public bool Priority { get; }

		/// <summary>
		/// True if h flip
		/// </summary>
		public bool HFlip { get; }

		/// <summary>
		/// True if v flip
		/// </summary>
		public bool VFlip { get; }

		/// <summary>
		/// 0x0001 if high priority
		/// </summary>
		public byte PriorityShort { get; }
		/// <summary>
		/// 0x0001 if h flip
		/// </summary>
		public byte HFlipByte { get; }

		/// <summary>
		/// 0x0001 if v flip
		/// </summary>
		public byte VFlipByte { get; }

		public byte[] Data
		{
			get
			{
				ushort s = ToUnsignedShort();
				return new byte[] { (byte) s, (byte) (s >> 8) };
			}
		}
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
			PriorityShort = (byte) (Priority ? 1 : 0);

			Palette = (byte) ((b2 >> 2) & 0x07);
		}

		public Tile(ushort id, byte palette, bool priority, bool hflip, bool vflip) // Custom tile
		{
			ID = id;

			HFlip = hflip;
			HFlipByte = (byte) (HFlip ? 1 : 0);

			VFlip = vflip;
			VFlipByte = (byte) (VFlip ? 1 : 0);

			Priority = priority;
			PriorityShort = (byte) (Priority ? 1 : 0);

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
			PriorityShort = (byte) (Priority ? 1 : 0);

			Palette = (byte) ((v >> 10) & 0x07);
		}

		public ushort GetModifiedUnsignedShort(bool? hflip = null, bool? vflip = null)
		{
			ushort value = (ushort) (((Palette << 10) & 0x1C00) | (ID & Constants.TileNameMask));

			if (hflip ?? HFlip)
			{
				value |= Constants.TileHFlipBit;
			}
			if (vflip ?? HFlip)
			{
				value |= Constants.TileVFlipBit;
			}

			return value;
		}
		
		public Tile Clone()
		{
			return new Tile(ID, Palette, Priority, HFlip, VFlip);
		}
		
		public Tile CloneModified(bool? hflip = null, bool? vflip = null)
		{
			return new Tile(ID, Palette, Priority, hflip ?? HFlip, vflip ?? VFlip);
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
