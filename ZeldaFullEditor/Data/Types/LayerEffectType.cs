namespace ZeldaFullEditor.Data
{
	public class LayerEffectType : IEntityType<LayerEffectType>
	{
		public byte ID { get; }
		public string Name { get; }

		private LayerEffectType(byte id, string name)
		{
			ID = id;
			Name = name;
		}

		public override string ToString() => Name;

		public static readonly LayerEffectType LayerEffect00 = new(0x00, "Nothing");
		public static readonly LayerEffectType LayerEffect01 = new(0x01, "Nothing");
		public static readonly LayerEffectType LayerEffect02 = new(0x02, "Moving Floor");
		public static readonly LayerEffectType LayerEffect03 = new(0x03, "Moving Water");
		public static readonly LayerEffectType LayerEffect04 = new(0x04, "Trinexx Shell");
		public static readonly LayerEffectType LayerEffect05 = new(0x05, "Red Flashes");
		public static readonly LayerEffectType LayerEffect06 = new(0x06, "Light Torch to See Floor");
		public static readonly LayerEffectType LayerEffect07 = new(0x07, "Ganon's Darkness");

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
