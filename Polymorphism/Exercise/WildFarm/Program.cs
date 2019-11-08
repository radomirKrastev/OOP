namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Animals;
    using Foods;

    public class Program
    {
        public static void Main()
        {
            var counter = 0;

            var command = Console.ReadLine();
            var animals = new List<Animal>();

            while (command != "End")
            {
                var commandParts = command.Split(" ");

                if (counter++ % 2 == 0)
                {
                    animals.Add(AnimalFactory.InitializeAnimal(commandParts));
                    var currentAnimal = animals.Where(x => x.GetType().Name == commandParts[0]).LastOrDefault();

                    Console.WriteLine(currentAnimal.Speak());
                }
                else
                {
                    var foodType = commandParts[0];
                    var foodQuantity = int.Parse(commandParts[1]);

                    var food = new Food(foodQuantity, foodType);

                    try
                    {
                        var currentAnimal = animals.LastOrDefault();

                        currentAnimal?.Eat(food);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
