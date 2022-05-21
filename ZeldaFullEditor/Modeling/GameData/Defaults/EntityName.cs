namespace ZeldaFullEditor.Modeling.GameData.Defaults
{
	/// <summary>
	/// Base class for defining names and IDs of reusable entities and concepts.
	/// </summary>
	public abstract record EntityName(int ID, string Name)
	{
		public override string ToString() => $"{ID:X2} {Name}";
	}

	public record DungeonName(int ID, string Name) : EntityName(ID, Name);

	public record OverworldScreenName(int ID, string Name) : EntityName(ID, Name);

	public record RoomName(int ID, string Name) : EntityName(ID, Name)
	{
		public override string ToString() => $"{ID:X3} {Name}";
	}

	public record SpriteName(int ID, string Name) : EntityName(ID, Name);

	public record TileTypeName(int ID, string Name) : EntityName(ID, Name);

	public record ItemReceiptName(int ID, string Name) : EntityName(ID, Name);

	public record SecretsName(int ID, string Name) : EntityName(ID, Name);

	public record RoomObjectName(int ID, string Name) : EntityName(ID, Name)
	{
		public override string ToString() => $"{ID:X3} {Name}";
	}

	public record RoomTagName(int ID, string Name) : EntityName(ID, Name)
{
		public override string ToString() => Name;
	}

	public record MusicName(int ID, string Name) : EntityName(ID, Name)
{
		public override string ToString() => Name;
	}
}
