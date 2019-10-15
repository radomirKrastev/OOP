namespace JediGalaxy
{
    using System;

    public class Program
    {
        static void Main()
        {
            var dimensionParser = new DimensionParser();

            var dimensions = dimensionParser.Parse(Console.ReadLine());
            var rows = dimensions[0];
            var cols = dimensions[1];
            var galaxyMatrix = CreateMatrix(rows, cols);

            string command = Console.ReadLine();

            var ivo = new Ivo { CollectedStarsValue = 0 };
            var evil = new Evil();

            while (command != "Let the Force be with you")
            {
                var startPointIvo = dimensionParser.Parse(command);
                var startPointEvil = dimensionParser.Parse(Console.ReadLine());

                evil.Row= startPointEvil[0];
                evil.Col= startPointEvil[1];
                evil.Move(galaxyMatrix, rows, cols);

                ivo.Row=startPointIvo[0];
                ivo.Col=startPointIvo[1];
                ivo.Move(galaxyMatrix, rows, cols);

                command = Console.ReadLine();
            }

            Console.WriteLine(ivo.CollectedStarsValue);
        }

        private static int [,] CreateMatrix(int rows, int cols)
        {
            var galaxyMatrix = new int[rows, cols];

            var starValue = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    galaxyMatrix[i, j] = starValue++;
                }
            }

            return galaxyMatrix;
        }        
    }
}
