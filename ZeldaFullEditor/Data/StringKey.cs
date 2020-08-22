using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    class StringKey
    {
        public string text;
        public byte[] keys;
        public StringKey(string text, byte[] keys)
        {
            this.text = text;
            this.keys = keys;
        }
    }
}
