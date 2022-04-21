using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public class DungeonRoomChestsHandler : List<DungeonChestItem>, IByteable
	{
		public DungeonRoom Room { get; }

		public byte[] Data
		{
			get
			{
				bool[] arebigs = Room.GetBigChestListing(Count);
				byte[] ret = new byte[Count * 3];

				int pos = 0;
				int i = 0;
				foreach (var c in this)
				{
					ushort e = Room.RoomID;
					if (arebigs[i++])
					{
						e |= 0x8000;
					}

					ret[pos++] = (byte) e;
					ret[pos++] = (byte) (e >> 8);
					ret[pos++] = c.ReceiptType.ID;
				}

				return ret;
			}
		}

		public DungeonRoomChestsHandler(DungeonRoom room)
		{
			Room = room;
		}

		public void ResetAssociations()
		{
			foreach (var c in this)
			{
				c.AssociatedChest = null;
			}
		}
	}
}
