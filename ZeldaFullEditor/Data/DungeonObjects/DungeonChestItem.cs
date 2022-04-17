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

		public byte X { get; set; }
		public byte Y { get; set; }

		public byte[] Data
		{
			get
			{
				throw new NotImplementedException();
				return null;
			}
		}



		public DungeonChestItem(ItemReceipt s)
		{

		}

		public void Draw(ZScreamer ZS)
		{

		}
	}
}
