namespace ZeldaFullEditor.ALTTP.Underworld;

public class LayerCollisionType : IEntityType<LayerCollisionType>
{
	public byte ID { get; }
	public int ListID => ID;
	public string Name { get; init; }

	private LayerCollisionType(byte id, string name)
	{
		ID = id;
		Name = name;
	}

	public override string ToString() => Name;

	public static ImmutableArray<LayerCollisionType> ListOf { get; }

	// Need to use static constructor for reflection to work properly
	static LayerCollisionType()
	{
		ListOf = Utils.GetSortedListOfPredefinedFields<LayerCollisionType>();
	}
	public static LayerCollisionType GetTypeFromID(byte id) => ListOf.GetTypeFromID(id);

	[PredefinedInstance] public static readonly LayerCollisionType LayerCollision00 = new(0x00, "One");
	[PredefinedInstance] public static readonly LayerCollisionType LayerCollision01 = new(0x01, "Both");
	[PredefinedInstance] public static readonly LayerCollisionType LayerCollision02 = new(0x02, "Both with scroll");
	[PredefinedInstance] public static readonly LayerCollisionType LayerCollision03 = new(0x03, "Moving floor");
	[PredefinedInstance] public static readonly LayerCollisionType LayerCollision04 = new(0x04, "Moving water");

}
