namespace ZeldaFullEditor.Modeling.GameData.GraphicsData
{
	/// <summary>
	/// Represents a background tile as used by the SNES PPU.
	/// </summary>
	[Serializable]
	public readonly struct Tile : IByteable, IPaletteFlip
	{
		/// <summary>
		/// 10-bit tile name
		/// </summary>
		public ushort ID { get; }

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

		public byte Palette { get; }

		public static readonly Tile Empty = new(0);

		public Tile(ushort id, byte palette, bool priority, bool hflip, bool vflip)
		{
			ID = (ushort) (id & Constants.TileNameMask);

			HFlip = hflip;
			VFlip = vflip;
			Priority = priority;
			Palette = palette;
		}

		public Tile(ushort v)
		{
			ID = (ushort) (v & Constants.TileNameMask);

			VFlip = v.BitIsOn(Constants.TileVFlipBit);

			HFlip = v.BitIsOn(Constants.TileHFlipBit);

			Priority = v.BitIsOn(Constants.TilePriorityBit);

			Palette = (byte) (v >> 10 & 0x07);
		}

		public byte[] GetByteData()
		{
			var s = ToUnsignedShort();
			return new byte[] { (byte) s, (byte) (s >> 8) };
		}

		public ushort GetModifiedUnsignedShort(
			FlipBehavior hflip = FlipBehavior.LeaveAlone,
			FlipBehavior vflip = FlipBehavior.LeaveAlone)
		{
			var value = (ushort) (Palette << 10 & 0x1C00 | ID & Constants.TileNameMask);

			var fliph = hflip switch
			{
				FlipBehavior.ForcedToFalse => false,
				FlipBehavior.ForcedToTrue => true,
				FlipBehavior.InvertFlip => !HFlip,
				_ => HFlip
			};

			if (fliph)
			{
				value |= Constants.TileHFlipBit;
			}

			var flipv = vflip switch
			{
				FlipBehavior.ForcedToFalse => false,
				FlipBehavior.ForcedToTrue => true,
				FlipBehavior.InvertFlip => !VFlip,
				_ => VFlip
			};

			if (flipv)
			{
				value |= Constants.TileHFlipBit;
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
		public Tile CloneModified(FlipBehavior hflip = FlipBehavior.LeaveAlone,
			FlipBehavior vflip = FlipBehavior.LeaveAlone)
		{

			var fliph = hflip switch
			{
				FlipBehavior.ForcedToFalse => false,
				FlipBehavior.ForcedToTrue => true,
				FlipBehavior.InvertFlip => !HFlip,
				_ => HFlip
			};

			var flipv = vflip switch
			{
				FlipBehavior.ForcedToFalse => false,
				FlipBehavior.ForcedToTrue => true,
				FlipBehavior.InvertFlip => !VFlip,
				_ => VFlip
			};

			return new Tile(ID, Palette, Priority, fliph, flipv);
		}

		public ushort ToUnsignedShort()
		{
			ushort value = 0;
			// vhopppcc cccccccc
			if (Priority) { value |= Constants.TilePriorityBit; };
			if (HFlip) { value |= Constants.TileHFlipBit; };
			if (VFlip) { value |= Constants.TileVFlipBit; };
			value |= (ushort) (Palette << 10 & 0x1C00);
			value |= (ushort) (ID & Constants.TileNameMask);
			return value;
		}
	}
}
