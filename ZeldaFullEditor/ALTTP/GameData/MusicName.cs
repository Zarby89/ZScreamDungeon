namespace ZeldaFullEditor.ALTTP.GameData;
public record MusicName(int ID, string Name) : EntityName(ID, Name)
{
	public override string ToString() => Name;

	private static readonly MusicName Music0x01 = new(0x01, "Triforce opening");
	private static readonly MusicName Music0x02 = new(0x02, "Light World");
	private static readonly MusicName Music0x03 = new(0x03, "Legend theme (rain state)");
	private static readonly MusicName Music0x04 = new(0x04, "Bunny Link");
	private static readonly MusicName Music0x05 = new(0x05, "Lost Woods");
	private static readonly MusicName Music0x06 = new(0x06, "Legend theme (attract mode)");
	private static readonly MusicName Music0x07 = new(0x07, "Kakariko Village");
	private static readonly MusicName Music0x08 = new(0x08, "Mirror warp");
	private static readonly MusicName Music0x09 = new(0x09, "Dark World");
	private static readonly MusicName Music0x0A = new(0x0A, "Restoring the Master Sword");
	private static readonly MusicName Music0x0B = new(0x0B, "Faerie theme");
	private static readonly MusicName Music0x0C = new(0x0C, "Chase theme");
	private static readonly MusicName Music0x0D = new(0x0D, "Skull Woods");
	private static readonly MusicName Music0x0E = new(0x0E, "Game theme");
	private static readonly MusicName Music0x0F = new(0x0F, "Intro no Triforce");
	private static readonly MusicName Music0x10 = new(0x10, "Hyrule Castle");
	private static readonly MusicName Music0x11 = new(0x11, "Light World dungeon");
	private static readonly MusicName Music0x12 = new(0x12, "Caves");
	private static readonly MusicName Music0x13 = new(0x13, "Fanfare");
	private static readonly MusicName Music0x14 = new(0x14, "Sanctuary");
	private static readonly MusicName Music0x15 = new(0x15, "Boss theme");
	private static readonly MusicName Music0x16 = new(0x16, "Dark World dungeon");
	private static readonly MusicName Music0x17 = new(0x17, "Fortune teller");
	private static readonly MusicName Music0x18 = new(0x18, "Caves");
	private static readonly MusicName Music0x19 = new(0x19, "Zelda rescue");
	private static readonly MusicName Music0x1A = new(0x1A, "Crystal theme");
	private static readonly MusicName Music0x1B = new(0x1B, "Faerie theme w/ arpeggio");
	private static readonly MusicName Music0x1C = new(0x1C, "Pre-Agahnim theme");
	private static readonly MusicName Music0x1D = new(0x1D, "Agahnim escape");
	private static readonly MusicName Music0x1E = new(0x1E, "Pre-Ganon theme");
	private static readonly MusicName Music0x1F = new(0x1F, "Ganondorf the Thief");
	private static readonly MusicName Music0xF2 = new(0xF2, "Half volume");
	private static readonly MusicName Music0xFF = new(0xFF, "Do nothing");

	public static readonly MusicName[] ListOfOverworldMusics =
	{
		Music0x01,
		Music0x02,
		Music0x03,
		Music0x04,
		Music0x05,
		Music0x06,
		Music0x07,
		Music0x08,
		Music0x09,
		Music0x0A,
		Music0x0B,
		Music0x0C,
		Music0x0D,
		Music0x0E,
		Music0x0F,
	};

	public static readonly MusicName[] ListOfUnderworldMusics =
	{
		Music0x01,
		Music0x02,
		Music0x03,
		Music0x04,
		Music0x05,
		Music0x06,
		Music0x07,
		Music0x08,
		Music0x09,
		Music0x0A,
		Music0x0B,
		Music0x0C,
		Music0x0D,
		Music0x0E,
		Music0x0F,
		Music0x10,
		Music0x11,
		Music0x12,
		Music0x13,
		Music0x14,
		Music0x15,
		Music0x16,
		Music0x17,
		Music0x18,
		Music0x19,
		Music0x1A,
		Music0x1B,
		Music0x1C,
		Music0x1D,
		Music0x1E,
		Music0x1F,
		Music0xF2,
		Music0xFF,
	};
}
