namespace INStock.Models
{
    using Contracts;
    public class Product : IProduct
    {
        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label { get; }

        public decimal Price { get; }

        public int Quantity { get; }

        public int CompareTo(IProduct other)
        {
            var priceResult = this.Price.CompareTo(other.Price);            

            if (priceResult == 0)
            {
                int labelResult = this.Label.CompareTo(other.Label);

                if (labelResult == 0)
                {
                    return this.Quantity.CompareTo(other.Quantity);
                }

                return labelResult;
            }

            return priceResult;
        }
    }
}
