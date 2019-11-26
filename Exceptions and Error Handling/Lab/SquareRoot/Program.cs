namespace SquareRoot
{
    using System;

    public class Program
    {
        public static void Main()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentException();
                }

                int squareRootNumber = (int)Math.Sqrt(number);
                Console.WriteLine(squareRootNumber);
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid number");                    
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
