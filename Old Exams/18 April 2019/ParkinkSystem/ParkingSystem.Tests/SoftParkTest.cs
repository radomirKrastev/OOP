namespace ParkingSystem.Tests
{
    using System;
    using NUnit.Framework;
    
    public class SoftParkTest
    {
        private SoftPark softPark;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Toyota", "W0808WW");
            this.softPark = new SoftPark();
        }

        [Test]
        public void ConstructorWorksAndSetsParkingLotCorrectly()
        {
            Assert.AreEqual(12, this.softPark.Parking.Count);
        }

        [Test]
        public void ParkCarFunctionallityWorksCorrectly()
        {
            this.softPark.ParkCar("A1", this.car);

            Assert.AreEqual(this.car, this.softPark.Parking["A1"]);            
        }

        [Test]
        public void ParkCarFuntionalityPrintsMessageCorrectly()
        {
            string confirmationMessage = $"Car:{this.car.RegistrationNumber} parked successfully!";

            Assert.AreEqual(confirmationMessage, this.softPark.ParkCar("A1", this.car));
        }

        [Test]
        public void ParkCarThrowsArgumentExceptionIfParkingSpotDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("ParkLot500", this.car));
        }

        [Test]
        public void ParkCarThrowsArgumentExceptionIfParkingSpotIsOccupied()
        {
            Car bmw = new Car("BMW", "W5555WW");
            this.softPark.ParkCar("A1", bmw);

            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("A1", this.car));
        }

        [Test]
        public void ParkCarThrowsInvalidOperationExceptionIfTheCarIsAlreadyParked()
        {
            this.softPark.ParkCar("A1", this.car);

            Assert.Throws<InvalidOperationException>(() => this.softPark.ParkCar("A2", this.car));
        }

        [Test]
        public void RemoveCarFunctionalityWorksCorrectly()
        {
            this.softPark.ParkCar("A1", this.car);
            this.softPark.RemoveCar("A1", this.car);

            Assert.AreEqual(null, this.softPark.Parking["A1"]);
        }

        [Test]
        public void RemoveCarFunctionalityPrintsCorrectMessage()
        {
            this.softPark.ParkCar("A1", this.car);
            string expectedMessage = $"Remove car:{this.car.RegistrationNumber} successfully!";

            Assert.AreEqual(expectedMessage, this.softPark.RemoveCar("A1", this.car));
        }

        [Test]
        public void RemoveCarThrowsArgumentExceptionIfParkingSpotDoesNotExist()
        {
            this.softPark.ParkCar("A1", this.car);

            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("WakandaForever", this.car));
        }

        [Test]
        public void RemoveCarThrowsArgumentExceptionIfCarIsWrong()
        {
            this.softPark.ParkCar("A1", this.car);
            Car bmw = new Car("M5", "M5555MM");

            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("A1", bmw));
        }
    }
}