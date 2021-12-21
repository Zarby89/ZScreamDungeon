using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class LogInfos
    {
        public int address = 0;
        public string text = "";

        public LogInfos(int address, string text)
        {
            this.address = address;
            this.text = text;
        }
    }
}
