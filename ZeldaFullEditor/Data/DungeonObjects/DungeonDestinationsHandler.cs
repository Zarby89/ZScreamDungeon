using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public class DungeonDestination
	{
		public byte Target { get; set; } = 0;

		public byte Layer { get; set; } = 0;

		public RoomObject AssociatedObject { get; set; } = null;

		public byte X => AssociatedObject?.X ?? 0;
		public byte Y => AssociatedObject?.Y ?? 0;

		public DungeonDestination() { }

		public void Clear()
		{
			AssociatedObject = null;
		}
		public void Draw(ZScreamer ZS)
		{

		}
	}

	public class DungeonDestinationsHandler
	{
		public DungeonDestination Pits { get; } = new DungeonDestination();
		public DungeonDestination Stair1 { get; } = new DungeonDestination();
		public DungeonDestination Stair2 { get; } = new DungeonDestination();
		public DungeonDestination Stair3 { get; } = new DungeonDestination();
		public DungeonDestination Stair4 { get; } = new DungeonDestination();

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
