using ZeldaFullEditor.Modeling.Underworld;

namespace ZeldaFullEditor.Handler
{
	/// <summary>
	/// Creates a room's object save data with meta properties to help optimize saving.
	/// </summary>
	public class RoomSaveEntry
	{
		public ushort ID { get; }
		public int TableIndex => ID * 3;
		public int DoorOffset { get; }
		public byte[] Data { get; }
		public int Length => Data.Length;

		public RoomSaveEntry(DungeonRoom room)
		{
			var ret = new List<byte>();

			ID = room.RoomID;

			ret.Add((byte) ((room.Floor1Graphics & 0x0F) << 4 | room.Floor2Graphics & 0x0F));
			ret.Add((byte) (room.Layout << 2));

			ret.AddRange(room.Layer1Objects.GetByteData());
			ret.Add(Constants.ObjectSentinel);

			ret.AddRange(room.Layer2Objects.GetByteData());
			ret.Add(Constants.ObjectSentinel);

			ret.AddRange(room.Layer3Objects.GetByteData());

			if (room.DoorsList.Count > 0)
			{
				ret.Add(0xFFF0);
				DoorOffset = ret.Count;

				ret.AddRange(room.DoorsList.GetByteData());
			}
			else
			{
				DoorOffset = ret.Count;
			}

			ret.Add(Constants.ObjectSentinel);

			Data = ret.ToArray();
		}
	}
}
