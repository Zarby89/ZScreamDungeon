namespace ZeldaFullEditor.Modeling.GameData
{
	/// <summary>
	/// Encapsulates the in-game name and value of the 16 floor levels.
	/// </summary>
	public class FloorNumber
	{
		/// <summary>
		/// This floor's 2-letter indicator, where
		/// #F represents floor # above ground and
		/// B# represents basement floor # below ground.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Gets the <see langword="byte"/> value for this floor.
		/// </summary>
		public byte Value { get; }

		private FloorNumber(string n, byte v)
		{
			Name = n;
			Value = v;
		}

		public override string ToString() => Name;

		/// <summary>
		/// Attempts to find the correct floor for the given value.
		/// </summary>
		/// <param name="b"></param>
		/// <returns>The correct floor; or <see cref="Floor1F"/>, if nothing is found.</returns>
		public static FloorNumber FindFloor(byte b)
		{
			return Array.Find(ListOf, f => f.Value == b) ?? Floor1F;
		}

		// Intentionally going overboard here, because I'm over bored

		/// <summary>
		/// Basement floor 8
		/// </summary>
		public static readonly FloorNumber FloorB8 = new("B8", 0xF8);

		/// <summary>
		/// Basement floor 7
		/// </summary>
		public static readonly FloorNumber FloorB7 = new("B7", 0xF9);

		/// <summary>
		/// Basement floor 6
		/// </summary>
		public static readonly FloorNumber FloorB6 = new("B6", 0xFA);

		/// <summary>
		/// Basement floor 5
		/// </summary>
		public static readonly FloorNumber FloorB5 = new("B5", 0xFB);

		/// <summary>
		/// Basement floor 4
		/// </summary>
		public static readonly FloorNumber FloorB4 = new("B4", 0xFC);

		/// <summary>
		/// Basement floor 3
		/// </summary>
		public static readonly FloorNumber FloorB3 = new("B3", 0xFD);

		/// <summary>
		/// Basement floor 2
		/// </summary>
		public static readonly FloorNumber FloorB2 = new("B2", 0xFE);

		/// <summary>
		/// Basement floor 1
		/// </summary>
		public static readonly FloorNumber FloorB1 = new("B1", 0xFF);

		/// <summary>
		/// Floor 1
		/// </summary>
		public static readonly FloorNumber Floor1F = new("1F", 0x00);

		/// <summary>
		/// Floor 2
		/// </summary>
		public static readonly FloorNumber Floor2F = new("2F", 0x01);

		/// <summary>
		/// Floor 3
		/// </summary>
		public static readonly FloorNumber Floor3F = new("3F", 0x02);

		/// <summary>
		/// Floor 4
		/// </summary>
		public static readonly FloorNumber Floor4F = new("4F", 0x03);

		/// <summary>
		/// Floor 5
		/// </summary>
		public static readonly FloorNumber Floor5F = new("5F", 0x04);

		/// <summary>
		/// Floor 6
		/// </summary>
		public static readonly FloorNumber Floor6F = new("6F", 0x05);

		/// <summary>
		/// Floor 7
		/// </summary>
		public static readonly FloorNumber Floor7F = new("7F", 0x06);

		/// <summary>
		/// Floor 8
		/// </summary>
		public static readonly FloorNumber Floor8F = new("8F", 0x07);

		public static readonly FloorNumber[] ListOf =
		{
			FloorB8,
			FloorB7,
			FloorB6,
			FloorB5,
			FloorB4,
			FloorB3,
			FloorB2,
			FloorB1,
			Floor1F,
			Floor2F,
			Floor3F,
			Floor4F,
			Floor5F,
			Floor6F,
			Floor7F,
			Floor8F,
		};
	}
}
