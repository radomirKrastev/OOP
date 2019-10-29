namespace PizzaCalories
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            try
            {
                var pizzaName = Console.ReadLine()
                .Split();

                var pizza = new Pizza(pizzaName.Length > 1 ? pizzaName[1] : string.Empty);

                var doughData = Console.ReadLine()
                    .Split()
                    .Skip(1)
                    .ToArray();

                var dough = new Dough(doughData[0], doughData[1], double.Parse(doughData[2]));
                pizza.Dough = dough;
                
                var toppingData = Console.ReadLine();

                while (toppingData != "END")
                {
                    var toppingSpecifications = toppingData
                        .Split()
                        .Skip(1)
                        .ToArray();

                    var topping = new Topping(toppingSpecifications[0], double.Parse(toppingSpecifications[1]));
                    pizza.AddTopping(topping);
                    toppingData = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
