namespace INStock.Tests
{
    using NUnit.Framework;
    using Moq;
    using INStock.Contracts;
    using INStock.Models;
    using System;
    using System.Collections.Generic;

    public class ProductStockTests
    {
        private Mock<IProduct> product;
        private IProductStock productStock;

        [SetUp]
        public void SetUp()
        {
            this.product = new Mock<IProduct>();
            this.product.SetupGet(x => x.Label).Returns("Jack Daniels");
            this.product.SetupGet(x => x.Price).Returns(45.55m);
            this.product.SetupGet(x => x.Quantity).Returns(1);

            this.productStock = new ProductStock();
        }

        [Test]
        public void AddFunctionalityWorksCorrectly()
        {
            this.productStock.Add(this.product.Object);

            Assert.AreEqual(1, this.productStock.Count);
            Assert.AreEqual(this.product.Object, this.productStock[0]);
        }

        [Test]
        public void AddThrowsInvalidOperationExceptionIfProductLabelExists()
        {
            this.productStock.Add(this.product.Object);

            Assert.Throws<InvalidOperationException>(() => this.productStock.Add(this.product.Object));
        }

        [Test]
        public void RemoveReturnsTrueIfRemovingIsSuccessful()
        {
            Mock<IProduct> anotherProduct = new Mock<IProduct>();

            this.productStock.Add(this.product.Object);
            this.productStock.Add(anotherProduct.Object);
            this.productStock.Remove(this.product.Object);

            Assert.AreEqual(1, this.productStock.Count);
            Assert.AreEqual(anotherProduct.Object, this.productStock[0]);
            Assert.AreEqual(true, this.productStock.Remove(anotherProduct.Object));
        }

        [Test]
        public void RemoveReturnsFalseIfProductToBeRemovedDoesNotExist()
        {
            Mock<IProduct> anotherProduct = new Mock<IProduct>();
            
            this.productStock.Add(anotherProduct.Object);
            
            Assert.AreEqual(false, this.productStock.Remove(this.product.Object));
        }

        [Test]
        public void ContainsFunctionalityWorksCorrectly()
        {
            this.productStock.Add(this.product.Object);

            Assert.AreEqual(true, this.productStock.Contains(this.product.Object));
        }

        [Test]
        public void FindFunctionalityWorksCorrectly()
        {
            Mock<IProduct> anotherProduct = new Mock<IProduct>();
            
            this.productStock.Add(this.product.Object);
            this.productStock.Add(anotherProduct.Object);

            Assert.AreEqual(this.product.Object, this.productStock.Find(0));
            Assert.AreEqual(anotherProduct.Object, this.productStock.Find(1));
        }

        [TestCase(1)]
        [TestCase(-1)]
        public void FindThrowsIndexOutOfRangeExceptionIfIndexParameterIsInvalid(int index)
        {
            this.productStock.Add(this.product.Object);

            Assert.Throws<IndexOutOfRangeException>(() => this.productStock.Find(index));
        }

        [Test]
        public void FindByLabelFunctionalityWorksCorrectly()
        {
            Mock<IProduct> anotherProduct = new Mock<IProduct>();
            anotherProduct.SetupGet(x => x.Label).Returns("Jameson");

            this.productStock.Add(this.product.Object);
            this.productStock.Add(anotherProduct.Object);

            Assert.AreEqual(anotherProduct.Object, this.productStock.FindByLabel("Jameson"));
            Assert.AreEqual(this.product.Object, this.productStock.FindByLabel("Jack Daniels"));
        }

        [Test]
        public void FindByLabelThrowsInvalidOperationExceptionIfNoSuchProductIsInProductStock()
        {
            this.productStock.Add(this.product.Object);

            Assert.Throws<InvalidOperationException>(() => this.productStock.FindByLabel("Jameson"));
        }

        [Test]
        public void FindAllInRangeFunctionalityReturnsCorrectCollection()
        {
            Mock<IProduct> jameson = new Mock<IProduct>();
            jameson.SetupGet(x => x.Label).Returns("Jameson");
            jameson.SetupGet(x => x.Price).Returns(34.58m);
            jameson.SetupGet(x => x.Quantity).Returns(12);

            Mock<IProduct> teachers = new Mock<IProduct>();
            teachers.SetupGet(x => x.Label).Returns("Teachers");
            teachers.SetupGet(x => x.Price).Returns(34.59m);
            teachers.SetupGet(x => x.Quantity).Returns(500);

            Mock<IProduct> mcAllan = new Mock<IProduct>();
            mcAllan.SetupGet(x => x.Label).Returns("McAllan");
            mcAllan.SetupGet(x => x.Price).Returns(10000.536m);
            mcAllan.SetupGet(x => x.Quantity).Returns(1);
            
            IEnumerable<IProduct> expectedCollection = new List<IProduct> { mcAllan.Object,
                teachers.Object,
                this.product.Object 
            };

            this.productStock.Add(mcAllan.Object);
            this.productStock.Add(teachers.Object);
            this.productStock.Add(jameson.Object);
            this.productStock.Add(this.product.Object);

            Assert.AreEqual(expectedCollection, this.productStock.FindAllInRange(34.59, 10000.536));
        }

        [Test]
        public void FindAllInRangeReturnsEmptyCollectionIfNoProductsArePresentInRangeParameters()
        {
            Mock<IProduct> jameson = new Mock<IProduct>();
            jameson.SetupGet(x => x.Label).Returns("Jameson");
            jameson.SetupGet(x => x.Price).Returns(34.58m);
            jameson.SetupGet(x => x.Quantity).Returns(12);

            Mock<IProduct> teachers = new Mock<IProduct>();
            teachers.SetupGet(x => x.Label).Returns("Teachers");
            teachers.SetupGet(x => x.Price).Returns(34.59m);
            teachers.SetupGet(x => x.Quantity).Returns(500);

            Mock<IProduct> mcAllan = new Mock<IProduct>();
            mcAllan.SetupGet(x => x.Label).Returns("McAllan");
            mcAllan.SetupGet(x => x.Price).Returns(10000.536m);
            mcAllan.SetupGet(x => x.Quantity).Returns(1);

            IEnumerable<IProduct> expectedCollection = new List<IProduct>();

            this.productStock.Add(mcAllan.Object);
            this.productStock.Add(teachers.Object);
            this.productStock.Add(jameson.Object);
            this.productStock.Add(this.product.Object);

            Assert.AreEqual(expectedCollection, this.productStock.FindAllInRange(-1, 34.57));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(34.58)]
        public void FindAllByPriceRangeFunctionalityReturnsCorrectCollection(double price)
        {
            Mock<IProduct> jameson = new Mock<IProduct>();
            jameson.SetupGet(x => x.Label).Returns("Jameson");
            jameson.SetupGet(x => x.Price).Returns(34.58m);
            jameson.SetupGet(x => x.Quantity).Returns(12);

            Mock<IProduct> teachers = new Mock<IProduct>();
            teachers.SetupGet(x => x.Label).Returns("Teachers");
            teachers.SetupGet(x => x.Price).Returns(34.58m);
            teachers.SetupGet(x => x.Quantity).Returns(500);

            Mock<IProduct> mcAllan = new Mock<IProduct>();
            mcAllan.SetupGet(x => x.Label).Returns("McAllan");
            mcAllan.SetupGet(x => x.Price).Returns(10000.536m);
            mcAllan.SetupGet(x => x.Quantity).Returns(1);

            IEnumerable<IProduct> expectedCollection = new List<IProduct>();

            this.productStock.Add(mcAllan.Object);
            this.productStock.Add(teachers.Object);
            this.productStock.Add(jameson.Object);
            this.productStock.Add(this.product.Object);
                        
            if (price == 34.58)
            {
                expectedCollection = new List<IProduct> { teachers.Object, jameson.Object};
            }

            Assert.AreEqual(expectedCollection, this.productStock.FindAllByPrice(price));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(12)]
        public void FindAllByQuantityFunctionalityReturnsCorrectCollection(int quantity)
        {
            Mock<IProduct> jameson = new Mock<IProduct>();
            jameson.SetupGet(x => x.Label).Returns("Jameson");
            jameson.SetupGet(x => x.Price).Returns(34.58m);
            jameson.SetupGet(x => x.Quantity).Returns(12);

            Mock<IProduct> teachers = new Mock<IProduct>();
            teachers.SetupGet(x => x.Label).Returns("Teachers");
            teachers.SetupGet(x => x.Price).Returns(34.58m);
            teachers.SetupGet(x => x.Quantity).Returns(12);

            Mock<IProduct> mcAllan = new Mock<IProduct>();
            mcAllan.SetupGet(x => x.Label).Returns("McAllan");
            mcAllan.SetupGet(x => x.Price).Returns(10000.536m);
            mcAllan.SetupGet(x => x.Quantity).Returns(1);

            IEnumerable<IProduct> expectedCollection = new List<IProduct>();

            this.productStock.Add(mcAllan.Object);
            this.productStock.Add(teachers.Object);
            this.productStock.Add(jameson.Object);
            this.productStock.Add(this.product.Object);

            if (quantity == 12)
            {
                expectedCollection = new List<IProduct> { teachers.Object, jameson.Object };
            }

            Assert.AreEqual(expectedCollection, this.productStock.FindAllByQuantity(quantity));
        }

        [Test]
        public void FindMostExpensiveProductWorksCorrectly()
        {
            Mock<IProduct> jameson = new Mock<IProduct>();
            jameson.SetupGet(x => x.Label).Returns("Jameson");
            jameson.SetupGet(x => x.Price).Returns(34.58m);
            jameson.SetupGet(x => x.Quantity).Returns(12);

            Mock<IProduct> teachers = new Mock<IProduct>();
            teachers.SetupGet(x => x.Label).Returns("Teachers");
            teachers.SetupGet(x => x.Price).Returns(34.58m);
            teachers.SetupGet(x => x.Quantity).Returns(12);

            Mock<IProduct> mcAllan = new Mock<IProduct>();
            mcAllan.SetupGet(x => x.Label).Returns("McAllan");
            mcAllan.SetupGet(x => x.Price).Returns(10000.536m);
            mcAllan.SetupGet(x => x.Quantity).Returns(1);

            IEnumerable<IProduct> expectedCollection = new List<IProduct>();

            this.productStock.Add(teachers.Object);
            this.productStock.Add(mcAllan.Object);
            this.productStock.Add(jameson.Object);
            this.productStock.Add(this.product.Object);
            Assert.AreEqual(mcAllan.Object, this.productStock.FindMostExpensiveProduct());
        }
    }
}
