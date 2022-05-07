using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
	public class LayerCollisionType : IEntityType<LayerCollisionType>
	{
		public byte ID { get; }
		public string Name { get; }

		private LayerCollisionType(byte id, string name)
		{
			ID = id;
			Name = name;
		}

		public override string ToString() => Name;

		public static readonly LayerCollisionType LayerCollision00 = new LayerCollisionType(0x00, "One");
		public static readonly LayerCollisionType LayerCollision01 = new LayerCollisionType(0x01, "Both");
		public static readonly LayerCollisionType LayerCollision02 = new LayerCollisionType(0x02, "Both with scroll");
		public static readonly LayerCollisionType LayerCollision03 = new LayerCollisionType(0x03, "Moving floor");
		public static readonly LayerCollisionType LayerCollision04 = new LayerCollisionType(0x04, "Moving water");

		public static readonly LayerCollisionType[] ListOf =
		{
			LayerCollision00,
			LayerCollision01,
			LayerCollision02,
			LayerCollision03,
			LayerCollision04
		};

		public static LayerCollisionType GetTypeFromID(int id)
		{
			switch (id)
			{
				case 0x00: return LayerCollision00;
				case 0x01: return LayerCollision01;
				case 0x02: return LayerCollision02;
				case 0x03: return LayerCollision03;
				case 0x04: return LayerCollision04;
			}
			return null;
		}
	}
}
