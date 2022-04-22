using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.Underworld
{
	public class RoomLayoutObjects : ImmutableArray<RoomObject>
	{
		public byte ID { get; }
		public RoomLayoutObjects(List<RoomObject> list, byte id) : base(list)
		{
			ID = id;
		}
	}


	public class RoomLayoutLister
	{
		private readonly RoomLayoutObjects lay0;
		private readonly RoomLayoutObjects lay1;
		private readonly RoomLayoutObjects lay2;
		private readonly RoomLayoutObjects lay3;
		private readonly RoomLayoutObjects lay4;
		private readonly RoomLayoutObjects lay5;
		private readonly RoomLayoutObjects lay6;
		private readonly RoomLayoutObjects lay7;

		public RoomLayoutObjects this[int i]
		{
			get
			{
				switch (i)
				{
					case 0 : return lay0;
					case 1 : return lay1;
					case 2 : return lay2;
					case 3 : return lay3;
					case 4 : return lay4;
					case 5 : return lay5;
					case 6 : return lay6;
					case 7 : return lay7;
				}
				return null;
		}


		}

		private RoomLayoutLister(List<RoomObject> _0, List<RoomObject> _1, List<RoomObject> _2, List<RoomObject> _3,
			List<RoomObject> _4, List<RoomObject> _5, List<RoomObject> _6, List<RoomObject> _7)
		{
			lay0 = new RoomLayoutObjects(_0, 0);
			lay1 = new RoomLayoutObjects(_1, 1);
			lay2 = new RoomLayoutObjects(_2, 2);
			lay3 = new RoomLayoutObjects(_3, 3);
			lay4 = new RoomLayoutObjects(_4, 4);
			lay5 = new RoomLayoutObjects(_5, 5);
			lay6 = new RoomLayoutObjects(_6, 6);
			lay7 = new RoomLayoutObjects(_7, 7);
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

			int pointer = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.room_object_layout_pointer, 3]);
			int pos = SNESFunctions.SNEStoPC(ZS.ROM[pointer + (layout * 3), 3]);

			byte b1, b2, b3;

			while (true)
			{
				b1 = ZS.ROM[pos++];
				b2 = ZS.ROM[pos++];

				if ((b1 & b2) == 0xFF) break;

				b3 = ZS.ROM[pos++];

				RoomObject r = DungeonRoom.ParseRoomObject(ZS, b1, b2, b3);

				if (r != null)
				{
					r.Layer = 0;
					ret.Add(r);
				}
			}

			return ret;
		}


	}
}
