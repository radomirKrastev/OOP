namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;
        private Astronaut astroboy;

        [SetUp]
        public void Setup()
        {
            this.astroboy = new Astronaut("Toy", 12.3);
            this.spaceship = new Spaceship("Space Station", 19);
        }

       [Test]
       public void ConstructorWorksCorrectly()
       {
            Assert.AreEqual("Space Station", this.spaceship.Name);
            Assert.AreEqual(19, this.spaceship.Capacity);
            Assert.AreEqual(0, this.spaceship.Count);
       }

        [TestCase(null)]
        [TestCase("")]
        public void NameSetterThrowsArgumentNullExceptionIfNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(name, 12));
        }

        [Test]
        public void CapacitySetterThrowsArgumentExceptionIfLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Station", -1));
        }

        [Test]
        public void AddFunctionalityThrowsInvalidOperationExceptionIfCapacityIsFull()
        {
            for (int i = 0; i < 19; i++)
            {
                this.spaceship.Add(new Astronaut((i + 1).ToString(), i + 0.5));
            }

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(this.astroboy));
        }

        [Test]
        public void AddFunctionalityThrowsInvalidOperationExceptionIfAstronautIsAlreadyOnBoard()
        {
            this.spaceship.Add(this.astroboy);

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(this.astroboy));
        }

        [Test]
        public void AddFunctionalityWorksCorrectly()
        {
            for (int i = 0; i < 19; i++)
            {
                this.spaceship.Add(new Astronaut((i + 1).ToString(), i + 0.5));
            }

            Assert.AreEqual(19, this.spaceship.Count);
        }

        [TestCase("Toy")]
        [TestCase("Moy")]
        public void RemoveFunctionalityWorksCorrectly(string name)
        {
            this.spaceship.Add(this.astroboy);

            if (name == "Toy")
            {
                Assert.AreEqual(true, this.spaceship.Remove(name));
            }
            else
            {
                Assert.AreEqual(false, this.spaceship.Remove(name));
            }
        }
    }
}