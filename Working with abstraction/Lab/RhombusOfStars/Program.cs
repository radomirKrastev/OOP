using System;

namespace RhombusOfStars
{
    public class Program
    {
        public static void Main()
        {
            var rhombusSize = int.Parse(Console.ReadLine());

            PrintFigure(rhombusSize);
        }

        private static void PrintFigure(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                PrintLine(i, size);
            }

            for (int i = size-1; i >= 0; i--)
            {
                PrintLine(i, size);
            }
        }

        private static void PrintLine(int line, int size)
        {
            var borderSpace = new string(' ', size - line);
            var middleFigure = string.Empty;

            for (int i = 0; i < line; i++)
            {
                if (i + 1 == line)
                {
                    middleFigure += "*";
                }
                else
                {
                    middleFigure += "* ";
                }                
            }

            var currentLine = borderSpace + middleFigure + borderSpace;

            Console.WriteLine(currentLine);
        }
    }
}
