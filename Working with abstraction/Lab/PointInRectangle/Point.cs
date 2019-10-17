namespace PointInRectangle
{
    public class Point
    {
        public int CoordinateX { get; private set; }
        public int CoordinateY { get; private set; }

        public Point(int x, int y)
        {
            this.CoordinateX = x;
            this.CoordinateY = y;
        }
    }
}
