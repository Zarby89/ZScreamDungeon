namespace ZeldaFullEditor
{
    public class TileInfo
    {
        private bool o, h, v;

        /// <summary>
        /// True if high priority
        /// </summary>
        public bool O { get => o; set => o = value; }

        /// <summary>
        /// True if h flip
        /// </summary>
        public bool H { get => h; set => h = value; }

        /// <summary>
        /// True if v flip
        /// </summary>
        public bool V { get => v; set => v = value; }

        /// <summary>
        /// 0x0001 if high priority
        /// </summary>
        public ushort OS
        {
            get
            {
                return (ushort)(o ? 1 : 0);
            }

            set
            {
                o = value == 0x0001;
            }
        }

        /// <summary>
        /// 0x0001 if h flip
        /// </summary>
        public ushort HS
        {
            get
            {
                return (ushort)(h ? 1 : 0);
            }

            set
            {
                h = value == 0x0001;
            }
        }

        /// <summary>
        /// 0x0001 if v flip
        /// </summary>
        public ushort VS
        {
            get
            {
                return (ushort)(v ? 1 : 0);
            }

            set
            {
                v = value == 0x0001;
            }
        }

        public byte palette;
        public ushort id;

        // vhopppcc cccccccc
        public TileInfo(ushort id, byte palette, bool o, bool h, bool v)
        {
            this.id = id;
            this.palette = palette;
            this.V = v;
            this.H = h;
            this.O = o;
        }

        public ushort toShort()
        {
            ushort value = 0;

            // vhopppcc cccccccc
            if (this.o) { value |= Constants.TilePriorityBit; };
            if (this.h) { value |= Constants.TileHFlipBit; };
            if (this.v) { value |= Constants.TileVFlipBit; };
            value |= (ushort)((this.palette << 10) & 0x1C00);
            value |= (ushort)(this.id & Constants.TileNameMask);
            return value;
        }
    }
}
