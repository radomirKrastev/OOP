namespace INStock.Tests
{
    using NUnit.Framework;
    using INStock.Models;

    public class ProductTests
    {
        [Test]
        public void ProductConstructorWorksCorrectly()
        {
            Product whiskey = new Product("Jack Daniels", 45.55m, 1);

            Assert.AreEqual("Jack Daniels", whiskey.Label);
            Assert.AreEqual(45.55, whiskey.Price);
            Assert.AreEqual(1, whiskey.Quantity);
        }

        [Test]
        public void ProductCompareToFunctionalityWorksCorrectly()
        {
            Product jack = new Product("Jack Daniels", 45.55m, 1);
            Product sameJack = new Product("Jack Daniels", 45.55m, 1);            

            Assert.AreEqual(0, jack.CompareTo(sameJack));
        }
    }
}