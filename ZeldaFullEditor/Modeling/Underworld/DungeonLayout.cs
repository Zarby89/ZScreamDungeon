namespace ZeldaFullEditor.Modeling.Underworld
{
	public class RoomLayoutLister
	{
		private readonly ImmutableArray<RoomObject> lay0;
		private readonly ImmutableArray<RoomObject> lay1;
		private readonly ImmutableArray<RoomObject> lay2;
		private readonly ImmutableArray<RoomObject> lay3;
		private readonly ImmutableArray<RoomObject> lay4;
		private readonly ImmutableArray<RoomObject> lay5;
		private readonly ImmutableArray<RoomObject> lay6;
		private readonly ImmutableArray<RoomObject> lay7;

		public ImmutableArray<RoomObject> this[int i] => i switch
		{
			0 => lay0,
			1 => lay1,
			2 => lay2,
			3 => lay3,
			4 => lay4,
			5 => lay5,
			6 => lay6,
			7 => lay7,
			_ => lay0,
		};

		private RoomLayoutLister(List<RoomObject> _0, List<RoomObject> _1, List<RoomObject> _2, List<RoomObject> _3,
			List<RoomObject> _4, List<RoomObject> _5, List<RoomObject> _6, List<RoomObject> _7)
		{
			lay0 = _0.ToImmutableArray();
			lay1 = _1.ToImmutableArray();
			lay2 = _2.ToImmutableArray();
			lay3 = _3.ToImmutableArray();
			lay4 = _4.ToImmutableArray();
			lay5 = _5.ToImmutableArray();
			lay6 = _6.ToImmutableArray();
			lay7 = _7.ToImmutableArray();
		}

		public static RoomLayoutLister CreateLayoutsFromROM(ZScreamer ZS)
		{
			return new RoomLayoutLister
				(
					CreateSingleLayoutFromROM(ZS, 0),
					CreateSingleLayoutFromROM(ZS, 1),
					CreateSingleLayoutFromROM(ZS, 2),
					CreateSingleLayoutFromROM(ZS, 3),
					CreateSingleLayoutFromROM(ZS, 4),
					CreateSingleLayoutFromROM(ZS, 5),
					CreateSingleLayoutFromROM(ZS, 6),
					CreateSingleLayoutFromROM(ZS, 7)
				);
		}

		private static List<RoomObject> CreateSingleLayoutFromROM(ZScreamer ZS, int layout)
		{
			var ret = new List<RoomObject>();

			var pointer = ZS.ROM.Read24(ZS.Offsets.room_object_layout_pointer).SNEStoPC();
			var pos = ZS.ROM.Read24(pointer + layout * 3).SNEStoPC();

			byte b1, b2, b3;

			while (true)
			{
				b1 = ZS.ROM[pos++];
				b2 = ZS.ROM[pos++];

				if ((b1 & b2) == 0xFF) break;

				b3 = ZS.ROM[pos++];

				var r = DungeonRoom.ParseRoomObject(ZS, b1, b2, b3);

				if (r != null)
				{
					r.Layer = RoomLayer.Layer1;
					ret.Add(r);
				}
			}

			return ret;
		}


	}
}
