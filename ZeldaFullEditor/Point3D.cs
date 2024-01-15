namespace ZeldaFullEditor
{
    public class Point3D
    {
        public sbyte x, y, z = 0;

        public Point3D(sbyte x, sbyte y, sbyte z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public class Face3D
        {
            public sbyte[] vertex;

            public Face3D(sbyte[] vertex)
            {
                this.vertex = vertex;
            }
        }
    }
}
