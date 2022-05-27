namespace ZeldaFullEditor.Modeling.Underworld
{
	public class LayerCouplingType : IEntityType<LayerCouplingType>
	{
		public byte ID { get; init; }
		public int ListID => ID;
		public string Name { get; init; }
		public bool Layer2OnTop { get; }
		public bool Layer2Translucent { get; }
		public bool Layer2Visible { get; }

		private LayerCouplingType(byte id, string name, bool see, bool top, bool trans)
		{
			ID = id;
			Name = name;
			Layer2OnTop = top;
			Layer2Translucent = trans;
			Layer2Visible = see;
		}

		public override string ToString() => Name;

		public static ImmutableArray<LayerCouplingType> ListOf { get; }

		// Need to use static constructor for reflection to work properly
		static LayerCouplingType()
		{
			ListOf = Utils.GetSortedListOfPredefinedFields<LayerCouplingType>();
		}

		public static LayerCouplingType GetTypeFromID(byte id) => ListOf.GetTypeFromID(id);

		[PredefinedInstance] public static readonly LayerCouplingType LayerCoupling00 = new(0x00, "Layer 2 off", true, false, false);
		[PredefinedInstance] public static readonly LayerCouplingType LayerCoupling01 = new(0x01, "Parallax", true, false, false);
		[PredefinedInstance] public static readonly LayerCouplingType LayerCoupling02 = new(0x02, "Dark", true, true, true);
		[PredefinedInstance] public static readonly LayerCouplingType LayerCoupling03 = new(0x03, "Layer 2 on top", true, true, false);
		[PredefinedInstance] public static readonly LayerCouplingType LayerCoupling04 = new(0x04, "Translucent", true, true, true);
		[PredefinedInstance] public static readonly LayerCouplingType LayerCoupling05 = new(0x05, "Addition", true, true, true);
		[PredefinedInstance] public static readonly LayerCouplingType LayerCoupling06 = new(0x06, "Layer 1 on top", true, false, false);
		[PredefinedInstance] public static readonly LayerCouplingType LayerCoupling07 = new(0x07, "Transparent", true, true, true);
	}
}
