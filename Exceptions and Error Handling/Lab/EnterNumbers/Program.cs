namespace EnterNumbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            ReadNumber(1, 15);
        }

        public static void ReadNumber(int start, int end)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int result))
                    {
                        if (result < start || result > end)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    i = -1;
                }
                catch (ArithmeticException)
                {
                    i = -1;
                }
            }
        }
    }
}
