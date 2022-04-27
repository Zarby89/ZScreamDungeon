using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
	public class LayerMergeType
	{
		public byte ID { get; }
		public string Name { get; }
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

		public static readonly LayerMergeType LayerMerge00 = new LayerMergeType(0x00, "Off", true, false, false);
		public static readonly LayerMergeType LayerMerge01 = new LayerMergeType(0x01, "Parallax", true, false, false);
		public static readonly LayerMergeType LayerMerge02 = new LayerMergeType(0x02, "Dark", true, true, true);
		public static readonly LayerMergeType LayerMerge03 = new LayerMergeType(0x03, "On top", true, true, false);
		public static readonly LayerMergeType LayerMerge04 = new LayerMergeType(0x04, "Translucent", true, true, true);
		public static readonly LayerMergeType LayerMerge05 = new LayerMergeType(0x05, "Addition", true, true, true);
		public static readonly LayerMergeType LayerMerge06 = new LayerMergeType(0x06, "Normal", true, false, false);
		public static readonly LayerMergeType LayerMerge07 = new LayerMergeType(0x07, "Transparent", true, true, true);
		public static readonly LayerMergeType LayerMerge08 = new LayerMergeType(0x08, "Dark room", true, true, true);

		public static readonly LayerMergeType[] ListOf =
		{
			LayerMerge00,
			LayerMerge01,
			LayerMerge02,
			LayerMerge03,
			LayerMerge04,
			LayerMerge05,
			LayerMerge06,
			LayerMerge07,
			LayerMerge08
		};

		public static LayerMergeType GetMergeType(byte id)
		{
			switch (id)
			{
				case 0x00: return LayerMerge00;
				case 0x01: return LayerMerge01;
				case 0x02: return LayerMerge02;
				case 0x03: return LayerMerge03;
				case 0x04: return LayerMerge04;
				case 0x05: return LayerMerge05;
				case 0x06: return LayerMerge06;
				case 0x07: return LayerMerge07;
				case 0x08: return LayerMerge08;
			}
			return null;
		}
	}
}
