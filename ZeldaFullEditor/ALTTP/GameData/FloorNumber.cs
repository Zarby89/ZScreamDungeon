namespace ZeldaFullEditor.ALTTP.GameData;

/// <summary>
/// Encapsulates the in-game name and value of the 16 floor levels.
/// </summary>
public class FloorNumber
{
	/// <summary>
	/// This floor's 2-letter indicator, where
	/// #F represents floor # above ground, and
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
	public static FloorNumber FindFloor(byte b) => ListOf.FirstOrDefault(floor => floor.Value == b) ?? Floor1F;


	public static ImmutableArray<FloorNumber> ListOf { get; }

	// Need to use static constructor for reflection to work properly
	static FloorNumber()
	{
		ListOf = Utils.GetSortedListOfPredefinedFields<FloorNumber>((f1, f2) => (f1.Value + 16) - (f2.Value + 16));
	}

	[PredefinedInstance] public static readonly FloorNumber FloorB8 = new("B8", 0xF8);
	[PredefinedInstance] public static readonly FloorNumber FloorB7 = new("B7", 0xF9);
	[PredefinedInstance] public static readonly FloorNumber FloorB6 = new("B6", 0xFA);
	[PredefinedInstance] public static readonly FloorNumber FloorB5 = new("B5", 0xFB);
	[PredefinedInstance] public static readonly FloorNumber FloorB4 = new("B4", 0xFC);
	[PredefinedInstance] public static readonly FloorNumber FloorB3 = new("B3", 0xFD);
	[PredefinedInstance] public static readonly FloorNumber FloorB2 = new("B2", 0xFE);
	[PredefinedInstance] public static readonly FloorNumber FloorB1 = new("B1", 0xFF);

	[PredefinedInstance] public static readonly FloorNumber Floor1F = new("1F", 0x00);
	[PredefinedInstance] public static readonly FloorNumber Floor2F = new("2F", 0x01);
	[PredefinedInstance] public static readonly FloorNumber Floor3F = new("3F", 0x02);
	[PredefinedInstance] public static readonly FloorNumber Floor4F = new("4F", 0x03);
	[PredefinedInstance] public static readonly FloorNumber Floor5F = new("5F", 0x04);
	[PredefinedInstance] public static readonly FloorNumber Floor6F = new("6F", 0x05);
	[PredefinedInstance] public static readonly FloorNumber Floor7F = new("7F", 0x06);
	[PredefinedInstance] public static readonly FloorNumber Floor8F = new("8F", 0x07);
}
