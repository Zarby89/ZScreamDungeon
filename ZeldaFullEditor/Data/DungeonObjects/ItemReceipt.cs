using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public class ItemReceipt
	{
		public delegate void DrawReceipt(ZScreamer ZS, ItemReceipt s);


		public byte ID { get; }
		public string VanillaName { get; }

		public DrawReceipt Draw { get; }

		private ItemReceipt(byte id, DrawReceipt d)
		{
			ID = id;
			VanillaName = DefaultEntities.ListOfSecrets.GetNameFromVanillaList(id);
			Draw = d;
		}
	}
}
