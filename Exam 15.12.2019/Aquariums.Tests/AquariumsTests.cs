namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;
    
    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish shark;

        [SetUp]
        public void Setup()
        {
            this.aquarium = new Aquarium("Underworld", 500);
            this.shark = new Fish("Mincho");
        }

        [Test]
        public void ConstructorWorksCorrectly()
        {
            Assert.AreEqual("Underworld", this.aquarium.Name);
            Assert.AreEqual(500, this.aquarium.Capacity);
            Assert.AreEqual(0, this.aquarium.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameSetterThrowsArgumentNullExceptionIfParameterIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 500));
        }

        [Test]
        public void CapacitySetterThrowsArgumentExceptionIfParameterIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("BlueTank", -1));
        }

        [Test]
        public void AddFishAddsSuccessfulyFishInTheCollection()
        {
            for (int i = 1; i <= 100; i++)
            {
                this.aquarium.Add(new Fish(i.ToString()));
            }

            Assert.AreEqual(100, this.aquarium.Count);
        }

        [Test]
        public void AddFishThrowsInvalidOperationExceptionIfTankIsFull()
        {
            for (int i = 1; i <= 500; i++)
            {
                this.aquarium.Add(new Fish(i.ToString()));
            }

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(new Fish("Whale")));
        }

        [Test]
        public void RemoveFishRemovesFishFromCollection()
        {
            this.aquarium.Add(this.shark);

            this.aquarium.RemoveFish("Mincho");

            Assert.AreEqual(0, this.aquarium.Count);
        }

        [Test]
        public void RemoveFishThrowsInvalidOperationExceptionIfFishDoesNotExist()
        {
            this.aquarium.Add(this.shark);

            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Pinokio"));
        }

        [Test]
        public void SellChangesFishAvailableStatusToFalseAndReturnsTheFish()
        {
            this.aquarium.Add(this.shark);

            Assert.AreEqual(false, this.aquarium.SellFish("Mincho").Available);
        }

        [Test]
        public void SellThrowsInvalidOperationExceptionIfFIshDoesNotExist()
        {
            this.aquarium.Add(this.shark);

            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish("Pinokio"));
        }

        [Test]
        public void ReportReturnsCorrectMessage()
        {
            this.aquarium.Add(this.shark);
            this.aquarium.Add(new Fish("Tiger"));
            var expectedMessage = $"Fish available at {this.aquarium.Name}: Mincho, Tiger";

            Assert.AreEqual(expectedMessage, this.aquarium.Report());
        }
    }
}
