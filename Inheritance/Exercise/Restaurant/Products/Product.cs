namespace Restaurant.Products
{
    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
    }
}
