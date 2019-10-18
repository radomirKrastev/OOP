using System;
using System.Collections.Generic;
using System.Linq;

namespace MordorCruelPlan.Food
{
    using Mood;

    public class Program
    {
        public static void Main()
        {
            var foodEaten = new List<Food>();
            
            var foodToEat = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var foodFactory = new FoodFactory();

            foreach (var food in foodToEat)
            {
                foodEaten.Add(foodFactory.GetFood(food.ToLower()));
            }
                        
            var happiness = foodEaten.Select(x => x.Happiness).Sum();
            Console.WriteLine(happiness);

            if (happiness < -5)
            {
                Console.WriteLine(nameof(Angry));
            }
            else if(happiness>=-5 && happiness <= 0)
            {
                Console.WriteLine(nameof(Sad));
            }
            else if (happiness > 0 && happiness <= 15)
            {
                Console.WriteLine(nameof(Happy));
            }
            else
            {
                Console.WriteLine(nameof(JavaScript));
            }
        }
    }
}
