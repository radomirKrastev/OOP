namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private int money;
        private List<Product> shoppingBag;

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            this.shoppingBag = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value == null || value.Replace(' ', '\0').Contains('\0') || value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public int Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public void AddProduct(Product product)
        {
            if (product.Cost > this.money)
            {
                Console.WriteLine($"{this.name} can't afford {product.Name}");
            }
            else
            {
                this.shoppingBag.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.name} bought {product.Name}");
            }
        }

        public override string ToString()
        {
            if (this.shoppingBag.Count > 0)
            {
                return $"{this.name} - {string.Join(", ", this.shoppingBag)}";
            }

            return $"{this.name} - Nothing bought";
        }
    }
}
