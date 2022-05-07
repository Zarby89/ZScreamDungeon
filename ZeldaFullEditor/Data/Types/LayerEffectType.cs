using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public static readonly LayerEffectType LayerEffect00 = new LayerEffectType(0x00, "Nothing");
		public static readonly LayerEffectType LayerEffect01 = new LayerEffectType(0x01, "Nothing");
		public static readonly LayerEffectType LayerEffect02 = new LayerEffectType(0x02, "Moving Floor");
		public static readonly LayerEffectType LayerEffect03 = new LayerEffectType(0x03, "Moving Water");
		public static readonly LayerEffectType LayerEffect04 = new LayerEffectType(0x04, "Trinexx Shell");
		public static readonly LayerEffectType LayerEffect05 = new LayerEffectType(0x05, "Red Flashes");
		public static readonly LayerEffectType LayerEffect06 = new LayerEffectType(0x06, "Light Torch to See Floor");
		public static readonly LayerEffectType LayerEffect07 = new LayerEffectType(0x07, "Ganon's Darkness");

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

		public static LayerEffectType GetTypeFromID(int id)
		{
			switch (id)
			{
				case 0x00: return LayerEffect00;
				case 0x01: return LayerEffect01;
				case 0x02: return LayerEffect02;
				case 0x03: return LayerEffect03;
				case 0x04: return LayerEffect04;
				case 0x05: return LayerEffect05;
				case 0x06: return LayerEffect06;
				case 0x07: return LayerEffect07;
			}
			return null;
		}
	}
}
