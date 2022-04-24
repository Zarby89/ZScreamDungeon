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

		public byte X => AssociatedChest?.X ?? 0;
		public byte Y => AssociatedChest?.Y ?? 0;

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
