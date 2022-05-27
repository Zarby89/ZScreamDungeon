namespace ZeldaFullEditor.ALTTP.Underworld
{
	public class LayerEffectType : IEntityType<LayerEffectType>
	{
		public byte ID { get; }
		public int ListID => ID;
		public string Name { get; init; }

		private LayerEffectType(byte id, string name)
		{
			ID = id;
			Name = name;
		}
		public override string ToString() => Name;

		public static ImmutableArray<LayerEffectType> ListOf { get; }

		// Need to use static constructor for reflection to work properly
		static LayerEffectType()
		{
			ListOf = Utils.GetSortedListOfPredefinedFields<LayerEffectType>();
		}
		public static LayerEffectType GetTypeFromID(byte id) => ListOf.GetTypeFromID(id);

		[PredefinedInstance] public static readonly LayerEffectType LayerEffect00 = new(0x00, "Nothing");
		[PredefinedInstance] public static readonly LayerEffectType LayerEffect01 = new(0x01, "Nothing");
		[PredefinedInstance] public static readonly LayerEffectType LayerEffect02 = new(0x02, "Moving Floor");
		[PredefinedInstance] public static readonly LayerEffectType LayerEffect03 = new(0x03, "Moving Water");
		[PredefinedInstance] public static readonly LayerEffectType LayerEffect04 = new(0x04, "Trinexx Shell");
		[PredefinedInstance] public static readonly LayerEffectType LayerEffect05 = new(0x05, "Red Flashes");
		[PredefinedInstance] public static readonly LayerEffectType LayerEffect06 = new(0x06, "Light Torch to See Floor");
		[PredefinedInstance] public static readonly LayerEffectType LayerEffect07 = new(0x07, "Ganon's Darkness");
	}
}
