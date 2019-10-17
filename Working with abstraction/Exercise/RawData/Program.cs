namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());


            for (int i = 0; i < lines; i++)
            {
                var information = Console.ReadLine();
                var informationParser = new InformationParser();
                informationParser.Parse(information, cars);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.TireSet.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
