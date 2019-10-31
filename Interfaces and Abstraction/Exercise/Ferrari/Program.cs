namespace Ferrari
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var driver = Console.ReadLine();
            ICar ferrari = new Ferrari(driver);
            Console.WriteLine(ferrari.ToString());
        }
    }
}
