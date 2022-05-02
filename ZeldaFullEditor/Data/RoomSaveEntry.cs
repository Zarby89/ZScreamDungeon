using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor
{
	public class RoomSaveEntry : IComparer<RoomSaveEntry>
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

			ret.Add(0x00); // TODO write floor
			ret.Add(0x00); // TODO write layout

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
				DoorOffset = ret.Count();
			}

			ret.Add(Constants.ObjectSentinel);

			Data = ret.ToArray();
		}

		public int CompareTo(RoomSaveEntry other)
		{
			return Length - other.Length;
		}

		public int Compare(RoomSaveEntry x, RoomSaveEntry y)
		{
			return x.Length - y.Length;
		}
	}
}
