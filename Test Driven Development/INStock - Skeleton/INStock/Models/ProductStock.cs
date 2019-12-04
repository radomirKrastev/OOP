namespace INStock.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    public class ProductStock : IProductStock
    {
        private List<IProduct> productStock;

        public ProductStock()
        {
            this.productStock = new List<IProduct>();
        }

        public IProduct this[int index] 
        {
            get => this.productStock[index]; 
            set => this.productStock[index] = value; 
        }

        public int Count => this.productStock.Count;

        public void Add(IProduct product)
        {
            if(this.productStock.Any(x=>x.Label == product.Label))
            {
                throw new InvalidOperationException("Product with the same label already exists!");
            }

            this.productStock.Add(product);
        }

        public bool Contains(IProduct product)
        {
            return this.productStock.Contains(product);
        }

        public IProduct Find(int index)
        {
            if(index>this.Count-1 || index < 0)
            {
                throw new IndexOutOfRangeException("index out of range!");
            }

            return this.productStock[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            decimal decimalPrice = (decimal)price;
            List<IProduct> priceFilteredProducts = this.productStock.Where(x => x.Price == decimalPrice).ToList();
            return priceFilteredProducts;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            List<IProduct> quantityFilteredProducts = this.productStock.Where(x => x.Quantity == quantity).ToList();
            return quantityFilteredProducts;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            decimal start = (decimal)lo;
            decimal end = (decimal)hi;

            List<IProduct> priceRangeFilteredProducts = this.productStock
                .Where(x => x.Price >= start && x.Price<=end)
                .ToList();
            return priceRangeFilteredProducts;
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = this.productStock.First(x => x.Label == label);
            return product;
        }

        public IProduct FindMostExpensiveProduct()
        {
            return this.productStock.OrderByDescending(x => x.Price).First();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var IProduct in this.productStock)
            {
                yield return IProduct;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public bool Remove(IProduct product)
        {
            if (this.productStock.Contains(product))
            {
                this.productStock.Remove(product);
                return true;
            }

            return false;            
        }
    }
}
