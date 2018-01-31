using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class DataRoom
    {
        public short id;
        public byte dungeonId;
        public string name;
        public DataRoom(short id, byte dungeonId, string name)
        {
            this.id = id;
            this.dungeonId = dungeonId;
            this.name = name;
        }
    }
}
