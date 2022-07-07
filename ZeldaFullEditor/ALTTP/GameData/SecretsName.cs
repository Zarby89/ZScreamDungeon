namespace ZeldaFullEditor.ALTTP.GameData;
public record SecretsName(int ID, string Name) : EntityName(ID, Name)
{
	public override string ToString() => $"{ID:X2} {Name}";

	public static readonly SecretsName[] ListOfVanillaNames =
	{
		new(0x00, "Nothing"),
		new(0x01, "Green rupee"),
		new(0x02, "Hoarder"),
		new(0x03, "Bee"),
		new(0x04, "Health pack"),
		new(0x05, "Bomb"),
		new(0x06, "Heart"),
		new(0x07, "Blue rupee"),
		new(0x08, "Key"),
		new(0x09, "Arrow"),
		new(0x0A, "Bomb"),
		new(0x0B, "Heart"),
		new(0x0C, "Small magic"),
		new(0x0D, "Full magic"),
		new(0x0E, "Cucco"),
		new(0x0F, "Green soldier"),
		new(0x10, "Bush stal"),
		new(0x11, "Blue soldier"),
		new(0x12, "Landmine"),
		new(0x13, "Heart"),
		new(0x14, "Fairy"),
		new(0x15, "Heart"),
		new(0x16, "Nothing"),

		new(0x80, "Hole"),
		new(0x82, "Warp"),
		new(0x84, "Staircase"),
		new(0x86, "Bombable"),
		new(0x88, "Switch")
	};
}
