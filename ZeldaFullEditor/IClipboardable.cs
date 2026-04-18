using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaFullEditor
{
    internal interface IClipboardable
    {
        public SaveObject MakeClipboardItem();

    }
}
