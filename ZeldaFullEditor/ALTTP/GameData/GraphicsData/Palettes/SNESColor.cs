namespace ZeldaFullEditor.ALTTP.GameData.GraphicsData.Palettes
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

		/// <summary>
		/// Gets the 15-bit value that represents this color in SNES CGRAM
		/// </summary>
		public ushort CGRAMValue => (ushort) (R | (G << 5) | (B << 10));

		/// <summary>
		/// Gets the color as a <see cref="Color"/> structure with 8-bit color components and 255 alpha.
		/// </summary>
		public Color RealColor { get; }

		/// <summary>
		/// 
		/// </summary>
		private SNESColor(int r, int g, int b)
		{
			R = (byte) (r & 0x1F);
			G = (byte) (g & 0x1F);
			B = (byte) (b & 0x1F);
			RealColor = Color.FromArgb(From5BitTo8Bit(R), From5BitTo8Bit(G), From5BitTo8Bit(B));

			static int From5BitTo8Bit(byte v) => (v << 3) | (v >> 2);
		}

		/// <summary>
		/// Creates a <see cref="SNESColor"/> structure from the specified 8-bit color values.
		/// </summary>
		/// <returns>The <see cref="SNESColor"/> this method creates.</returns>
		public static SNESColor FromRGB(int r, int g, int b)
		{
			return new SNESColor(r >> 3, g >> 3, b >> 3);
		}

		/// <summary>
		/// Creates a <see cref="SNESColor"/> structure from the specified <see langword="ushort"/> by treating
		/// the value as a 15-bit color in the SNES CGRAM data format.
		/// </summary>
		/// <returns>The <see cref="SNESColor"/> this method creates.</returns>
		public static SNESColor FromUnsignedShort(ushort s)
		{
			return new SNESColor(s, s >> 5, s >> 10);
		}

		/// <summary>
		/// Creates a <see cref="SNESColor"/> structure from the specified <see cref="Color"/> by shifting
		/// each 8-bit component in the original color rightwards to create a 5-bit value.
		/// </summary>
		/// <returns>The <see cref="SNESColor"/> this method creates.</returns>
		public static SNESColor FromColor(Color color)
		{
			return new SNESColor(color.R >> 3, color.G >> 3, color.B >> 3);
		}

		public static bool operator ==(SNESColor a, SNESColor b)
		{
			return a.R == b.R && a.G == b.G && a.B == a.B;
		}

		public static bool operator !=(SNESColor a, SNESColor b)
		{
			return a.R != b.R || a.G != b.G || a.B != b.B;
		}

		public override bool Equals(object obj) => obj switch
		{
			SNESColor b => R == b.R && G == b.G && B == b.B,
			_ => false
		};

		public override int GetHashCode()
		{
			return (R << 16) | (G << 8) | B;
		}
	}
}
