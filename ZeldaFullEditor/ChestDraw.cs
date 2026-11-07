namespace ZeldaFullEditor
{
    // TODO POST MIGRATION - turn fields into properties
    // TODO POST MIGRATION - clean up this.
    class ChestDraw
    {
        public int x, y;
        public bool mx, my;

        public ChestDraw(int x, int y, bool mx = false, bool my = false)
        {
            this.x = x;
            this.y = y;
            this.mx = mx;
            this.my = my;
        }
    }
}
