namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var foodBuyersCount = int.Parse(Console.ReadLine());

            var foodBuyers = new List<IBuyer>();
            CreateFoodBuyers(foodBuyersCount, foodBuyers);

            BuyFood(foodBuyers);

            var totalFoodBought = foodBuyers.Select(x => x.Food).Sum();
            Console.WriteLine(totalFoodBought);
        }

        private static void CreateFoodBuyers(int foodBuyersCount, List<IBuyer> foodBuyers)
        {
            for (int i = 0; i < foodBuyersCount; i++)
            {
                var dataParts = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var name = dataParts[0];
                var age = int.Parse(dataParts[1]);

                if (dataParts.Length == 3)
                {
                    var group = dataParts[2];

                    foodBuyers.Add(new Rebel(name, age, group));
                }
                else if (dataParts.Length == 4)
                {
                    var id = dataParts[2];
                    var birthdate = DateTime
                        .ParseExact(dataParts[3], "dd'/'MM'/'yyyy", CultureInfo.InvariantCulture);

                    foodBuyers.Add(new Citizen(name, age, id, birthdate));
                }
            }
        }

        private static void BuyFood(List<IBuyer> foodBuyers)
        {
            var name = Console.ReadLine();

            while (name != "End")
            {
                var foodBuyer = foodBuyers.Where(x => x.Name == name).FirstOrDefault();

                foodBuyer?.BuyFood();

                name = Console.ReadLine();
            }
        }
    }
}
