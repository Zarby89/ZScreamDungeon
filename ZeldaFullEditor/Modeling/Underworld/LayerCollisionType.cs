namespace ZeldaFullEditor.Modeling.Underworld
{
	public class LayerCollisionType : IEntityType<LayerCollisionType>
	{
		public byte ID { get; }
		public string Name { get; init; }

		private LayerCollisionType(byte id, string name)
		{
			ID = id;
			Name = name;
		}

		public override string ToString() => Name;

		public static readonly LayerCollisionType LayerCollision00 = new(0x00, "One");
		public static readonly LayerCollisionType LayerCollision01 = new(0x01, "Both");
		public static readonly LayerCollisionType LayerCollision02 = new(0x02, "Both with scroll");
		public static readonly LayerCollisionType LayerCollision03 = new(0x03, "Moving floor");
		public static readonly LayerCollisionType LayerCollision04 = new(0x04, "Moving water");

		public static readonly LayerCollisionType[] ListOf =
		{
			LayerCollision00,
			LayerCollision01,
			LayerCollision02,
			LayerCollision03,
			LayerCollision04
		};

		public static LayerCollisionType GetTypeFromID(int id) => id switch
		{
			0x00 => LayerCollision00,
			0x01 => LayerCollision01,
			0x02 => LayerCollision02,
			0x03 => LayerCollision03,
			0x04 => LayerCollision04,
			_ => null,
		};
	}
}
