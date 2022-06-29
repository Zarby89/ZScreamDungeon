namespace ZeldaFullEditor
{
	/// <summary>
	/// General class for defining names and properties of objects
	/// </summary>
	public abstract class EntityName
	{
		public int ID { get; }
		public string Name { get; }

		public EntityName(int id, string name)
		{
			ID = id;
			Name = name;
		}

		public override string ToString() => $"{ID:X2} {Name}";
	}

	public class DungeonName : EntityName
	{
		public DungeonName(int i, string n) : base(i, n) { }
	}
	public class OverworldScreenName : EntityName
	{
		public OverworldScreenName(int i, string n) : base(i, n) { }
	}

	public class RoomName : EntityName
	{
		public RoomName(int i, string n) : base(i, n) { }
		public override string ToString() => $"{ID:X3} {Name}";
	}

	public class SpriteName : EntityName
	{
		public SpriteName(int i, string n) : base(i, n) { }
	}

	public class TileTypeName : EntityName
	{
		public TileTypeName(int i, string n) : base(i, n) { }
	}

	public class ItemReceiptName : EntityName
	{
		public ItemReceiptName(int i, string n) : base(i, n) { }
	}

	public class SecretsName : EntityName
	{
		public SecretsName(int i, string n) : base(i, n) { }
	}

	public class RoomObjectName : EntityName
	{
		public RoomObjectName(int i, string n) : base(i, n) { }
		public override string ToString() => $"{ID:X3} {Name}";

	}
	public class DoorObjectName : EntityName
	{
		public DoorObjectName(int i, string n) : base(i, n) { }
	}

	public class RoomTagName : EntityName
	{
		public RoomTagName(int i, string n) : base(i, n) { }
		public override string ToString() => Name;
	}

	public class RoomEffectName : EntityName
	{
		public RoomEffectName(int i, string n) : base(i, n) { }
		public override string ToString() => Name;
	}

	public class RoomCollisionName : EntityName
	{
		public RoomCollisionName(int i, string n) : base(i, n) { }
		public override string ToString() => Name;
	}

	public class Layer2TypeName : EntityName
	{
		public Layer2TypeName(int i, string n) : base(i, n) { }
		public override string ToString() => Name;
	}
}
