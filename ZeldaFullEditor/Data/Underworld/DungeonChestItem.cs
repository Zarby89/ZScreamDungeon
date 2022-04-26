using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.Underworld
{
	public unsafe class DungeonChestItem : IDelegatedDraw, ITypeID
	{
		public ItemReceipt ReceiptType { get; set; }

		public int RealX => AssociatedChest?.RealX ?? 0;
		public int RealY => AssociatedChest?.RealY ?? 0;

		public bool IsAssociated => AssociatedChest != null;

		public byte ID => ReceiptType?.ID ?? 0xFF;
		public int TypeID => ReceiptType?.ID ?? -1;

		public RoomObject AssociatedChest { get; set; }

		public DungeonChestItem(ItemReceipt s)
		{
			ReceiptType = s;
		}

		public void Draw(ZScreamer ZS)
		{

		}
	}
}
