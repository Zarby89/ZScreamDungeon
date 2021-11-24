using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class StringByte
    {
        public string s = "";
        public byte[] bytes;
        public StringByte(string s, byte[] bytes)
        {
            this.s = s;
            this.bytes = bytes;
        }
    }
}
