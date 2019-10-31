namespace Telephony
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split();

            var smartphone = new Smartphone();

            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(smartphone.Call(number)); 
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        
            var sites = Console.ReadLine().Split();

            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(site)); 
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
