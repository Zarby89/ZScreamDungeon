﻿using System.Collections.Generic;
using System.Linq;

namespace ZeldaFullEditor
{
    class ScreenStrip
    {
        public List<ushort> data = new List<ushort>();
        readonly int startAddr = 0;
        readonly bool fix = false;

        public ScreenStrip(ushort[] data, int startAddr, bool fix = false)
        {
            this.data = data.ToList();
            this.startAddr = startAddr;
        }

        public byte[] GetData()
        {
            byte[] d;
            if (!fix)
            {
                d = new byte[4 + (data.Count * 2)];
                d[0] = (byte)((startAddr & 0xFF00) >> 8);
                d[1] = (byte)((startAddr & 0xFF));

                d[2] = (byte)((((data.Count * 2) - 1) & 0xFF00) >> 8);
                d[3] = (byte)((((data.Count * 2) - 1) & 0xFF));

                for (int i = 0; i < data.Count; i++)
                {
                    d[(i * 2) + 4] = (byte)(data[i] & 0xFF);
                    d[(i * 2) + 5] = (byte)((data[i] & 0xFF00) >> 8);
                }
            }
            else
            {
                d = new byte[6];
                d[0] = (byte)((startAddr & 0xFF00) >> 8);
                d[1] = (byte)((startAddr & 0xFF));

                d[2] = (byte)(((((data.Count * 2) - 1) & 0xFF00) >> 8) + 0x40);
                d[3] = (byte)((((data.Count * 2) - 1) & 0xFF));
                d[4] = (byte)(data[0] & 0xFF);
                d[5] = (byte)((data[0] & 0xFF00) >> 8);
            }

            return d;
        }
    }

    class DataStrip
    {
        public int pos = 0;
        public ushort value = 0;
        public int count = 0;
        public bool same = false;

        public DataStrip(int pos, ushort value, int count, bool same)
        {
            this.pos = pos;
            this.value = value;
            this.count = count;
            this.same = same;
        }
    }
}
