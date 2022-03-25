using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.Underworld
{
	public class DungeonDestination
	{
		public byte Index { get; }

		public byte Target { get; set; } = 0;

		public byte Layer { get; set; } = 0;

		public override string ToString() => $"{Index}: To {Target:X2}";

		public RoomObject AssociatedObject { get; set; } = null;
		public bool IsAssociated => AssociatedObject != null;

		public int RealX => AssociatedObject?.RealX ?? 0;
		public int RealY => AssociatedObject?.RealY ?? 0;

		public DungeonDestination(byte i)
		{
			Index = i;
		}

		public void Clear()
		{
			AssociatedObject = null;
		}
	}

	public class DungeonDestinationsHandler
	{
		public DungeonDestination Pits { get; } = new DungeonDestination(0);
		public DungeonDestination Stair1 { get; } = new DungeonDestination(1);
		public DungeonDestination Stair2 { get; } = new DungeonDestination(2);
		public DungeonDestination Stair3 { get; } = new DungeonDestination(3);
		public DungeonDestination Stair4 { get; } = new DungeonDestination(4);

		public DungeonDestinationsHandler()
		{

		}

		public void Clear()
		{
			Pits.Clear();
			Stair1.Clear();
			Stair2.Clear();
			Stair3.Clear();
			Stair4.Clear();
		}
	}
}
