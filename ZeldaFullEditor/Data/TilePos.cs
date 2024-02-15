namespace ZeldaFullEditor
{
    public class TilePos
    {
        public byte x, y;
        public ushort tileId;

        public TilePos(byte x, byte y, ushort tileId)
        {
            this.x = x;
            this.y = y;
            this.tileId = tileId;
        }
    }
}
