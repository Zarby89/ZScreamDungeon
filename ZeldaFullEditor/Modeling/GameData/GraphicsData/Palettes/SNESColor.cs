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
		public Color RealColor { get; private init; }

		private readonly bool IsTransparent { get; init; } = false;

		public static readonly SNESColor Transparent = new(0, 0, 0)
		{
			RealColor = Color.Transparent,
			IsTransparent = true,
		};


		public SNESColor(byte r, byte g, byte b)
		{
			R = (byte) (r & 0x1F);
			G = (byte) (g & 0x1F);
			B = (byte) (b & 0x1F);
			RealColor = Color.FromArgb(From5BitTo8Bit(R), From5BitTo8Bit(G), From5BitTo8Bit(B));
		}

		public SNESColor(ushort col) : this((byte) (col & 0x1F), (byte) ((col >> 5) & 0x1F), (byte) ((col >> 10) & 0x1F)) { }

		private static byte From5BitTo8Bit(byte b)
		{
			return (byte) ((b << 3) | (b >> 2));
		}

		public static bool operator ==(SNESColor a, SNESColor b)
		{
			return a.R == b.R && a.G == b.G && a.B == a.B;
		}

		public static bool operator !=(SNESColor a, SNESColor b)
		{
			return a.R != b.R || a.G != b.G || a.B != b.B;
		}

		public static explicit operator ushort(SNESColor c) => c.CGRAMValue;

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
			return CGRAMValue | (IsTransparent ? 0x8000 : 0x0000);
		}
	}
}
