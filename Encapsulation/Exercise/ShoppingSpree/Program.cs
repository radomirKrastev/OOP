namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var peopleData = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            var productsData = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var people = new List<Person>();
            foreach (var person in peopleData)
            {
                var data = person.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    people.Add(new Person(data[0], int.Parse(data[1])));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            var products = new List<Product>();
            foreach (var product in productsData)
            {
                var data = product.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    products.Add(new Product(data[0], int.Parse(data[1])));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            var command = Console.ReadLine();

            while (command != "END")
            {
                CompleteCommand(command, people, products);

                command = Console.ReadLine();
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        private static void CompleteCommand(string command, List<Person> people, List<Product> products)
        {
            var data = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var person = people.Where(x => x.Name == data[0]).FirstOrDefault();
            var product = products.Where(x => x.Name == data[1]).FirstOrDefault();

            if (product != null)
            {
                person?.AddProduct(product);
            }
        }
    }
}
