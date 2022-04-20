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


	public abstract class DungeonListing<T> : List<T> where T : DungeonPlaceable
	{

	}
	public abstract class DungeonLister<T> : DungeonListing<T>, IByteable where T : DungeonPlaceable, IByteable
	{
		public byte[] Data
		{
			get
			{
				List<byte> ret = new List<byte>();

				foreach (T r in this)
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
	public class DungeonBlocksList : DungeonListing<DungeonBlock> { }
	public class DungeonTorchList : DungeonLister<DungeonTorch>, IByteable { }
}
