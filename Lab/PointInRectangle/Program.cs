using System;
using System.Linq;

namespace PointInRectangle
{
    public class Program
    {
        public static void Main()
        {
            var rectangleCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var pointsCount = int.Parse(Console.ReadLine());

            var rectangle = CreateRectangle(rectangleCoordinates);

            PrintResultForEachPoint(pointsCount, rectangle);
        }

        private static void PrintResultForEachPoint(int pointsCount, Rectangle rectangle)
        {
            for (int i = 0; i < pointsCount; i++)
            {
                var pointCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var point = new Point(pointCoordinates[0], pointCoordinates[1]);
                Console.WriteLine(rectangle.Contains(point));
            }
        }

        private static Rectangle CreateRectangle(int [] coordinates)
        {
            
            var bottomLeftX = coordinates[0];
            var bottomLeftY = coordinates[1];
            var topRightX = coordinates[2];
            var topRightY = coordinates[3];

            return new Rectangle(new Point(bottomLeftX, bottomLeftY), new Point(topRightX, topRightY));
        }
    }
}
