namespace ZeldaFullEditor.Modeling.GameData.GraphicsData.Palettes
{
	/// <summary>
	/// Represents a 15-bit color on the SNES
	/// </summary>
	public readonly struct SNESColor
	{
		/// <summary>
		/// Gets the 5-bit red component.
		/// </summary>
		public byte R { get; }

		/// <summary>
		/// Gets the 5-bit green component.
		/// </summary>
		public byte G { get; }

		/// <summary>
		/// Gets the 5-bit blue component.
		/// </summary>
		public byte B { get; }

		public ushort CGRAMValue => (ushort) (R | (G << 5) | (B << 10));

		/// <summary>
		/// Gets the color as a <see cref="Color"/> structure with 8-bit color components and 255 alpha.
		/// </summary>
		public Color RealColor { get; }


		public SNESColor(byte r, byte g, byte b)
		{
			R = (byte) (r & 0x1F);
			G = (byte) (g & 0x1F);
			B = (byte) (b & 0x1F);
			RealColor = Color.FromArgb(From5BitTo8Bit(R), From5BitTo8Bit(G), From5BitTo8Bit(B));

			static int From5BitTo8Bit(byte v) => (v << 3) | (v >> 2);
		}

		public static SNESColor FromColor(Color color)
		{
			return new SNESColor((byte) (color.R >> 3), (byte) (color.G >> 3), (byte) (color.B >> 3));
		}

		public static bool operator ==(SNESColor a, SNESColor b)
		{
			return a.R == b.R && a.G == b.G && a.B == a.B;
		}

		public static bool operator !=(SNESColor a, SNESColor b)
		{
			return a.R != b.R || a.G != b.G || a.B != b.B;
		}

		public override bool Equals(object obj)
		{
			if (obj is SNESColor b)
			{
				return R == b.R && G == b.G && B == b.B;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (R << 16) | (G << 8) | B;
		}
	}
}
