namespace TheRace.Tests
{
    using System;
    using NUnit.Framework;
    
    public class RaceEntryTests
    {
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            this.race = new RaceEntry();
        }

        [Test]
        public void ConstructorCreatesEmptyDictionary()
        {
            Assert.AreEqual(0, this.race.Counter);
        }

        [Test]
        public void AddRiderCounterWorksCorrectly()
        {
            var motorcycle = new UnitMotorcycle("Yamaha", 150, 250);
            var rider = new UnitRider("Stich", motorcycle);

            this.race.AddRider(rider);

            Assert.AreEqual(1, this.race.Counter);
        }

        [Test]
        public void AddRiderReturnsCorrectString()
        {
            var motorcycle = new UnitMotorcycle("Yamaha", 150, 250);
            var rider = new UnitRider("Stich", motorcycle);

            Assert.AreEqual("Rider Stich added in race.", this.race.AddRider(rider));
        }

        [Test]
        public void AddFunctionalityThrowsInvalidOperationExceptionIfRiderIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.race.AddRider(null));
        }

        [Test]
        public void AddFunctionalityThrowsInvalidOperationExceptionIfRiderExists()
        {
            var motorcycle = new UnitMotorcycle("Yamaha", 150, 250);
            var rider = new UnitRider("Stich", motorcycle);

            this.race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => this.race.AddRider(rider));
        }

        [Test]
        public void CalculateAverageHorsePowerThrowsInvalidOperationExceptionIfRidersAreLessThanTwo()
        {
            var motorcycle = new UnitMotorcycle("Yamaha", 150, 250);
            var rider = new UnitRider("Stich", motorcycle);

            this.race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => this.race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerWorksCorrectly()
        {
            var motorcycle = new UnitMotorcycle("Yamaha", 150, 250);
            var secondMotorcycle = new UnitMotorcycle("Honda", 200, 250);
            var rider = new UnitRider("Stich", motorcycle);
            var secondRider = new UnitRider("Mich", secondMotorcycle);

            this.race.AddRider(rider);
            this.race.AddRider(secondRider);

            Assert.AreEqual(175, this.race.CalculateAverageHorsePower());
        }
    }
}