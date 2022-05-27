namespace ZeldaFullEditor.ALTTP.Underworld
{
	public class ChestItemsHandler : List<ChestItem>, IByteable
	{
		public Room Room { get; }

		public ChestItemsHandler(Room room)
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

		public byte[] GetByteData()
		{
			var arebigs = Room.GetBigChestListing(Count);
			var ret = new byte[Count * 3];

			var pos = 0;
			var i = 0;
			foreach (var c in this)
			{
				var e = Room.RoomID;
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
}
