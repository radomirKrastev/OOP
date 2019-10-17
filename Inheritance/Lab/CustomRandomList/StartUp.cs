namespace CustomRandomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var customList = new RandomList() { "Petio", "Gosho", "Apostol Popov", "Kircata" };
            Console.WriteLine(customList.RandomString());
        }
    }
}
