namespace ZeldaFullEditor.ALTTP.GameData;

public record DungeonName(int ID, string Name) : EntityName(ID, Name)
{
	public override string ToString() => $"{ID:X2} {Name}";

	public static readonly DungeonName[] ListOfVanillaNames =
	{
		new(0x00, "Sewers"),
		new(0x02, "Hyrule Castle"),
		new(0x04, "Eastern Palace"),
		new(0x06, "Desert Palace"),
		new(0x08, "Agahnim's Tower"),
		new(0x0A, "Swamp Palace"),
		new(0x0C, "Palace of Darkness"),
		new(0x0E, "Misery Mire"),
		new(0x10, "Skull Woods"),
		new(0x12, "Ice Palace"),
		new(0x14, "Tower of Hera"),
		new(0x16, "Thieves' Town"),
		new(0x18, "Turtle Rock"),
		new(0x1A, "Ganon's Tower"),
		new(0xFF, "Cave"),
	};
}
