namespace ZeldaFullEditor.Modeling.Underworld
{
	public class LayerMergeType : IEntityType<LayerMergeType>
	{
		public byte ID { get; init; }
		public string Name { get; init; }
		public bool Layer2OnTop { get; }
		public bool Layer2Translucent { get; }
		public bool Layer2Visible { get; }

		private LayerMergeType(byte id, string name, bool see, bool top, bool trans)
		{
			ID = id;
			Name = name;
			Layer2OnTop = top;
			Layer2Translucent = trans;
			Layer2Visible = see;
		}

		public override string ToString() => Name;

		public static readonly LayerMergeType LayerMerge00 = new(0x00, "Off", true, false, false);
		public static readonly LayerMergeType LayerMerge01 = new(0x01, "Parallax", true, false, false);
		public static readonly LayerMergeType LayerMerge02 = new(0x02, "Dark", true, true, true);
		public static readonly LayerMergeType LayerMerge03 = new(0x03, "On top", true, true, false);
		public static readonly LayerMergeType LayerMerge04 = new(0x04, "Translucent", true, true, true);
		public static readonly LayerMergeType LayerMerge05 = new(0x05, "Addition", true, true, true);
		public static readonly LayerMergeType LayerMerge06 = new(0x06, "Normal", true, false, false);
		public static readonly LayerMergeType LayerMerge07 = new(0x07, "Transparent", true, true, true);

		public static readonly LayerMergeType[] ListOf =
		{
			LayerMerge00,
			LayerMerge01,
			LayerMerge02,
			LayerMerge03,
			LayerMerge04,
			LayerMerge05,
			LayerMerge06,
			LayerMerge07
		};

		public static LayerMergeType GetTypeFromID(int id) => id switch
		{
			0x00 => LayerMerge00,
			0x01 => LayerMerge01,
			0x02 => LayerMerge02,
			0x03 => LayerMerge03,
			0x04 => LayerMerge04,
			0x05 => LayerMerge05,
			0x06 => LayerMerge06,
			0x07 => LayerMerge07,
			_ => null,
		};
	}
}
