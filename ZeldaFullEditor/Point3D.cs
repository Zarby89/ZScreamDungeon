namespace ZeldaFullEditor
{
    public class Point3D
    {
        public sbyte X { get; set; }
        public sbyte Y { get; set; }
        public sbyte Z { get; set; }

        public Point3D(sbyte x, sbyte y, sbyte z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class Face3D
    {
        public sbyte[] Vertex { get; set; }

        public Face3D(sbyte[] vertex)
        {
            Vertex = vertex;
        }
    }
}
