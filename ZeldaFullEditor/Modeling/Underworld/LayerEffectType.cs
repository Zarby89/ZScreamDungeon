namespace ZeldaFullEditor.Modeling.Underworld
{
	public class LayerEffectType : IEntityType<LayerEffectType>
	{
		public byte ID { get; }
		public string Name { get; init; }

		private LayerEffectType(byte id, string name)
		{
			ID = id;
			Name = name;
		}
		public override string ToString() => Name;


		public static LayerEffectType LayerEffect00 { get; } = new(0x00, "Nothing");
		public static LayerEffectType LayerEffect01 { get; } = new(0x01, "Nothing");
		public static LayerEffectType LayerEffect02 { get; } = new(0x02, "Moving Floor");
		public static LayerEffectType LayerEffect03 { get; } = new(0x03, "Moving Water");
		public static LayerEffectType LayerEffect04 { get; } = new(0x04, "Trinexx Shell");
		public static LayerEffectType LayerEffect05 { get; } = new(0x05, "Red Flashes");
		public static LayerEffectType LayerEffect06 { get; } = new(0x06, "Light Torch to See Floor");
		public static LayerEffectType LayerEffect07 { get; } = new(0x07, "Ganon's Darkness");

		public static readonly LayerEffectType[] ListOf =
		{
			LayerEffect00,
			LayerEffect01,
			LayerEffect02,
			LayerEffect03,
			LayerEffect04,
			LayerEffect05,
			LayerEffect06,
			LayerEffect07
		};

		public static LayerEffectType GetTypeFromID(int id) => id switch
		{
			0x00 => LayerEffect00,
			0x01 => LayerEffect01,
			0x02 => LayerEffect02,
			0x03 => LayerEffect03,
			0x04 => LayerEffect04,
			0x05 => LayerEffect05,
			0x06 => LayerEffect06,
			0x07 => LayerEffect07,
			_ => null,
		};
	}
}
