namespace ConvertToDouble
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            try
            {
                double number = Convert.ToDouble(input);
                Console.WriteLine(number*2);
            }
            catch (OverflowException)
            {
                Console.WriteLine(typeof(OverflowException).Name);
            }
            catch (FormatException)
            {
                Console.WriteLine(typeof(FormatException).Name);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine(typeof(InvalidCastException).Name);
            }

            Console.ReadLine();
        }
    }
}
