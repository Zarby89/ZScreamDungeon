using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class dataObject
    {
        public short id;
        public string Name { get; set; }
        public byte option = 0;

        public dataObject(short id, string name, byte option = 0)
        {
            this.Name = name;
            this.id = id;
            this.option = option;
        }
    }
}
