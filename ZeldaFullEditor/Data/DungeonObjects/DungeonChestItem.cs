using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public unsafe class DungeonChestItem
	{
		public SecretItemType ReceiptType { get; set; }

		public byte X => AssociatedChest?.X ?? 0;
		public byte Y => AssociatedChest?.Y ?? 0;

		public RoomObject AssociatedChest { get; set; }

		public DungeonChestItem(ItemReceipt s)
		{

		}

		public void Draw(ZScreamer ZS)
		{

		}
	}
}
