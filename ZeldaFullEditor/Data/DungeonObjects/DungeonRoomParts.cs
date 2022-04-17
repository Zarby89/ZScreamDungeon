using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public class DungeonRoomHeader : IByteable
	{
		public byte[] Data => null;
	}


	public abstract class DungeonLister<T> : List<T>, IByteable where T : IByteable
	{
		public byte[] Data
		{
			get
			{
				List<byte> ret = new List<byte>();

				foreach (var r in this)
				{
					ret.AddRange(r.Data);
				}

				return ret.ToArray();
			}
		}
	}





	public class DungeonObjectsList : DungeonLister<RoomObject>, IByteable { }
	public class DungeonDoorsList : DungeonLister<DungeonDoorObject>, IByteable { }
	public class DungeonSecretsList : DungeonLister<DungeonSecret>, IByteable { }
	public class DungeonSpritesList : DungeonLister<DungeonSprite>, IByteable { }
	public class DungeonChestsList : List<DungeonChestItem> { }
	public class DungeonBlocksList : List<DungeonBlock> { }
}
