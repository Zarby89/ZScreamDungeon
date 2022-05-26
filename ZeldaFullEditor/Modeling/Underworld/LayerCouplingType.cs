namespace ZeldaFullEditor.Modeling.Underworld
{
	public class LayerCouplingType : IEntityType<LayerCouplingType>
	{
		public byte ID { get; init; }
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

		public static readonly LayerCouplingType LayerCoupling00 = new(0x00, "Layer 2 off", true, false, false);
		public static readonly LayerCouplingType LayerCoupling01 = new(0x01, "Parallax", true, false, false);
		public static readonly LayerCouplingType LayerCoupling02 = new(0x02, "Dark", true, true, true);
		public static readonly LayerCouplingType LayerCoupling03 = new(0x03, "Layer 2 on top", true, true, false);
		public static readonly LayerCouplingType LayerCoupling04 = new(0x04, "Translucent", true, true, true);
		public static readonly LayerCouplingType LayerCoupling05 = new(0x05, "Addition", true, true, true);
		public static readonly LayerCouplingType LayerCoupling06 = new(0x06, "Layer 1 on top", true, false, false);
		public static readonly LayerCouplingType LayerCoupling07 = new(0x07, "Transparent", true, true, true);

		public static readonly LayerCouplingType[] ListOf =
		{
			LayerCoupling00,
			LayerCoupling01,
			LayerCoupling02,
			LayerCoupling03,
			LayerCoupling04,
			LayerCoupling05,
			LayerCoupling06,
			LayerCoupling07
		};

		public static LayerCouplingType GetTypeFromID(int id) => id switch
		{
			0x00 => LayerCoupling00,
			0x01 => LayerCoupling01,
			0x02 => LayerCoupling02,
			0x03 => LayerCoupling03,
			0x04 => LayerCoupling04,
			0x05 => LayerCoupling05,
			0x06 => LayerCoupling06,
			0x07 => LayerCoupling07,
			_ => null,
		};
	}
}
