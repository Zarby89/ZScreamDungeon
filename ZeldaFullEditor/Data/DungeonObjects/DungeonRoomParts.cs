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








	public class DungeonObjectsList : List<RoomObject>, IByteable
	{
		public byte[] Data
		{
			get
			{
				List<byte> ret = new List<byte>();

				foreach (RoomObject r in this)
				{
					ret.AddRange(r.Data);
				}

				return ret.ToArray();
			}
		}

	}
	public class DungeonDoorsList : List<DungeonDoorObject>, IByteable
	{
		public byte[] Data
		{
			get
			{
				List<byte> ret = new List<byte>();

				foreach (DungeonDoorObject r in this)
				{
					ret.AddRange(r.Data);
				}

				return ret.ToArray();
			}
		}

	}


	public class DungeonChestsList : List<Chest>, IByteable
	{
		public byte[] Data
		{
			get
			{
				List<byte> ret = new List<byte>();

				foreach (Chest r in this)
				{
					throw new NotImplementedException();
					//ret.AddRange(r.Data);
				}

				return ret.ToArray();
			}
		}
	}

	public class DungeonSecretsList : List<PotItem>, IByteable
	{
		public byte[] Data
		{
			get
			{
				List<byte> ret = new List<byte>();

				foreach (PotItem r in this)
				{
					throw new NotImplementedException();
					//ret.AddRange(r.Data);
				}

				return ret.ToArray();
			}
		}
	}

	public class DungeonSpritesList : List<DungeonSprite>, IByteable
	{
		public byte[] Data
		{
			get
			{
				List<byte> ret = new List<byte>();

				foreach (DungeonSprite r in this)
				{
					throw new NotImplementedException();
					//ret.AddRange(r.Data);
				}

				return ret.ToArray();
			}
		}
	}
}
