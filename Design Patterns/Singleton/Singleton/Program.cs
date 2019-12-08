using System;

namespace Singleton
{
    public class Program
    {
        public static void Main()
        {
            SingletonDataContainer db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Capital City"));

            SingletonDataContainer db1 = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Pliska"));

            SingletonDataContainer db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("London"));

            SingletonDataContainer db3 = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Mumbai"));
        }
    }
}
