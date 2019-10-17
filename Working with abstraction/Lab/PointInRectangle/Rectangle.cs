namespace PointInRectangle 
{
    public class Rectangle
    {
        private Point bottomLeft;
        private Point topRight;

        public Rectangle(Point left, Point right)
        {
            this.bottomLeft = left;
            this.topRight = right;
        }

        public bool Contains(Point point )
        {
            var validXaxis = point.CoordinateX >= this.bottomLeft.CoordinateX && point.CoordinateX <= this.topRight.CoordinateX;
            var validYaxis = point.CoordinateY <= this.topRight.CoordinateY && point.CoordinateY >= this.bottomLeft.CoordinateY;

            if ( validXaxis && validYaxis)
            {
                return true;
            }

            return false;
        }
    }
}
