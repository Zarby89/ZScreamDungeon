namespace ZeldaFullEditor.Data.Underworld
{
	public abstract class DungeonListing<T> : List<T>, IList<T> where T : IDungeonPlaceable
	{

	}

	public abstract class DungeonLister<T> : DungeonListing<T>, IList<T>, IByteable where T : IDungeonPlaceable, IByteable
	{
		public byte[] GetByteData()
		{
			List<byte> ret = new List<byte>();

			foreach (T r in this)
			{
				ret.AddRange(r.GetByteData());
			}

			return ret.ToArray();
		}
	}





	public class DungeonObjectsList : DungeonLister<RoomObject>, IByteable, IList<RoomObject> { }
	public class DungeonDoorsList : DungeonLister<DungeonDoor>, IByteable { }
	public class DungeonSecretsList : DungeonLister<DungeonSecret>, IByteable { }
	public class DungeonSpritesList : DungeonLister<DungeonSprite>, IByteable { }
	public class DungeonBlocksList : DungeonListing<DungeonBlock> { }
	public class DungeonTorchList : DungeonLister<DungeonTorch>, IByteable { }
}
