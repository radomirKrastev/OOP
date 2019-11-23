namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Toyota", "Land Cruiser", 11, 150);
        }

        [Test]
        public void ConstructorSetsCarCorrectly()
        {
            Assert.AreEqual("Land Cruiser", this.car.Model);
            Assert.AreEqual("Toyota", this.car.Make);
            Assert.AreEqual(11, this.car.FuelConsumption);
            Assert.AreEqual(150, this.car.FuelCapacity);
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void MakePropertyThrowsArgumentExceptionWithNullOrEmptyParameter(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "Land Cruiser", 11, 150)); 
        }

        [Test]
        public void MakePropertyGetterWorksCorrectly()
        {
            Assert.AreEqual("Toyota", this.car.Make);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ModelPropertyThrowsArgumentExceptionWithNullOrEmptyParameter(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("Toyota", model, 11, 150));
        }

        [Test]
        public void ModelPropertyGetterWorksCorrectly()
        {
            Assert.AreEqual("Land Cruiser", this.car.Model);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionPropertyThrowsArgumentExceptionWithZeroOrNegaviteParameterValue(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Toyota", "Land Cruiser", fuelConsumption, 150));
        }

        [Test]
        public void FuelConsumptionGetterWorksCorrectly()
        {
            Assert.AreEqual(11, this.car.FuelConsumption);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacityPropertyThrowsArgumentExceptionWithZeroOrNegaviteParameterValue(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("Toyota", "Land Cruiser", 11, fuelCapacity));
        }

        [Test]
        public void FuelCapacityGetterWorksCorrectly()
        {
            Assert.AreEqual(150, this.car.FuelCapacity);
        }

        [Test]
        public void FuelAmountGetterWorksCorrectly()
        {
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        [TestCase(40, 40)]
        [TestCase(150, 150)]
        [TestCase(200, 150)]
        public void RefuelFunctionalityWorksCorrectly(double filledFuel, double expectedFuelAmount)
        {
            this.car.Refuel(filledFuel);

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelFunctionalityThrowsArgumentExceptionWhenFuelParameterIsZeroOrNegative(double filledFuel)
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(filledFuel));
        }

        [Test]
        public void DriveMethodReturnsCorrectFueldAmount()
        {
            this.car.Refuel(150);
            this.car.Drive(500);

            Assert.AreEqual(95, this.car.FuelAmount);
        }

        [Test]
        public void DriveMethodThrowsInvalidOperationExceptionIfDistanceIsTooLarge()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(1500));
        }
    }
}