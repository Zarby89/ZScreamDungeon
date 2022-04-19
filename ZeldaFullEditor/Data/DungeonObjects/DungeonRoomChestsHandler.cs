using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public class DungeonRoomChestsHandler : IByteable
	{
		public DungeonRoom Room { get; }

		private List<DungeonChestItem> chests = new List<DungeonChestItem>();

		public int Count => chests.Count;

		public byte[] Data
		{
			get
			{
				bool[] arebigs = Room.GetBigChestListing(chests.Count);
				byte[] ret = new byte[chests.Count * 3];

				int pos = 0;
				int i = 0;
				foreach (DungeonChestItem c in chests)
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

		public void Add(DungeonChestItem d)
		{
			chests.Add(d);
		}

		public void Remove(DungeonChestItem d)
		{
			chests.Remove(d);
		}
		public void Clear()
		{
			chests.Clear();
		}
	}
}
