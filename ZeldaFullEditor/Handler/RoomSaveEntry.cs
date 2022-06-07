namespace ZeldaFullEditor.Handler
{
	/// <summary>
	/// Creates a room's object save data with meta properties to help optimize saving.
	/// </summary>
	internal class RoomSaveEntry
	{
		public ushort ID { get; }
		public int TableIndex => ID * 3;
		public int DoorOffset { get; }
		public byte[] Data { get; }
		public int Length => Data.Length;

		public RoomSaveEntry(Room room)
		{
			var ret = new List<byte>();

			ID = room.RoomID;

			ret.Add((byte) ((room.Floor1Graphics & 0x0F) << 4 | room.Floor2Graphics & 0x0F));
			ret.Add((byte) (room.Layout << 2));

			AddBytesIfNotEmpty(room.Layer1Objects);
			ret.Add16(Constants.ObjectSentinel);

			AddBytesIfNotEmpty(room.Layer2Objects);
			ret.Add16(Constants.ObjectSentinel);

			AddBytesIfNotEmpty(room.Layer3Objects);
			ret.Add16(0xFFF0);

			DoorOffset = ret.Count;

			AddBytesIfNotEmpty(room.DoorsList);
			ret.Add16(Constants.ObjectSentinel);

			Data = ret.ToArray();

			void AddBytesIfNotEmpty<T>(DungeonLister<T> list) where T : IDungeonPlaceable, IByteable
			{
				if (list.Count == 0) return;
				ret.AddRange(list.GetByteData());
			}
		}
	}
}
