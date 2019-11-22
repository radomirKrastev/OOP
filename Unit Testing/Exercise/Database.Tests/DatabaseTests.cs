namespace Database.Tests
{   
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        //[SetUp]
        //public void Setup()
        //{   
        //}

        [Test]
        public void DatabaseConstructorSetsTheCorrectCountOfIntegers()
        {
            this.database = new Database(1, 2, 3);

            Assert.AreEqual(3, this.database.Count);
        }

        [Test]
        public void AddFunctionalityAddElement()
        {
            this.database = new Database(1, 2, 3);

            this.database.Add(4);

            Assert.AreEqual(4, this.database.Count);
        }

        [Test]
        public void AddMoreThanSixteenElementsThrowsInvalidOperationException()
        {
            int[] arr = new int[16];
            this.database = new Database(arr);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(1));
        }

        [Test]
        public void RemoveMethodRemovesOneElement()
        {
            this.database = new Database(1, 2, 3);

            this.database.Remove();

            Assert.AreEqual(2, this.database.Count);
        }

        [Test]
        public void RemoveFromEmptyArrayShouldThrowInvalidOperationException()
        {
            this.database = new Database();
                       
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void FetchMethodReturnsArrayCorrectly()
        {
            int[] arr = new int[4] { 1, 2, 3, 4 };
            this.database = new Database(1, 2, 3, 4);

            int[] fetchedArray = this.database.Fetch();

            Assert.IsTrue(fetchedArray.SequenceEqual(arr)); 
        }
    }
}