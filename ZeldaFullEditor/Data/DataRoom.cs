using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public class DataRoom
	{
		public ushort id;
		public byte dungeonId;
		public string name;
		public DataRoom(ushort id, byte dungeonId, string name)
		{
			this.id = id;
			this.dungeonId = dungeonId;
			this.name = name;
		}
	}
}
