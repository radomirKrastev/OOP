namespace Service.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Models.Contracts;
    using Models.Devices;
    using NUnit.Framework;

    [TestFixture]
    public class DeviceTests
    {
        private Assembly partAssembly;

        [SetUp]
        public void Setup()
        {
            this.partAssembly = typeof(Device).Assembly;
        }

        [Test]
        [TestCase("Laptop", "Lenovo")]
        [TestCase("PC", "HP")]
        [TestCase("Phone", "Samsung")]
        public void DeviceConstructorWorksCorrectly(string deviceTypeString, string deviceMake)
        {
            Type deviceType = this.partAssembly.GetTypes().First(x => x.Name == deviceTypeString);

            IRepairable deviceInstance = (IRepairable)Activator.CreateInstance(deviceType, deviceMake);

            Assert.AreEqual(deviceMake, deviceInstance.Make);
            Assert.IsNotNull(deviceInstance.Parts);
            Assert.AreEqual(0, deviceInstance.Parts.Count);
        }

        [Test]
        [TestCase("Laptop", "")]
        [TestCase("Laptop", null)]
        [TestCase("PC", "")]
        [TestCase("PC", null)]
        [TestCase("Phone", "")]
        [TestCase("Phone", null)]
        public void DeviceMakeSetterThrowsArgumentExceptionIfParameterValueIsNullOrEmpty(
            string deviceTypeString,
            string deviceMake)
        {
            Type deviceType = this.partAssembly.GetTypes().First(x => x.Name == deviceTypeString);

            try
            {
                Activator.CreateInstance(deviceType, deviceMake);
            }
            catch (TargetInvocationException e)
            {
                Assert.AreEqual(typeof(ArgumentException), e.InnerException.GetType());
            }
        }

        [Test]
        [TestCase("Laptop", "Lenovo", "LaptopPart")]
        [TestCase("PC", "HP", "PCPart")]
        [TestCase("Phone", "Samsung", "PhonePart")]
        public void AddPartFunctionalityWorksCorrectly(string deviceTypeString, string deviceMake, string partTypeString)
        {
            Type deviceType = this.partAssembly.GetTypes().First(x => x.Name == deviceTypeString);
            IRepairable deviceInstance = (IRepairable)Activator.CreateInstance(deviceType, deviceMake);
            Type partType = this.partAssembly.GetTypes().First(x => x.Name == partTypeString);
            IPart firstPart = (IPart)Activator.CreateInstance(partType, "processor", 350.97m, false);
            IPart secondPart = (IPart)Activator.CreateInstance(partType, "someOtherpart", 31220.97m, true);
            List<IPart> partsListExpected = new List<IPart> { firstPart, secondPart };

            deviceInstance.AddPart(firstPart);
            deviceInstance.AddPart(secondPart);

            Assert.IsTrue(partsListExpected.SequenceEqual(deviceInstance.Parts));
        }

        [Test]
        [TestCase("Laptop", "Lenovo", "LaptopPart")]
        [TestCase("PC", "HP", "PCPart")]
        [TestCase("Phone", "Samsung", "PhonePart")]
        public void AddAlreadyExistingPartThrowsInvalidOperationException(
            string deviceTypeString,
            string deviceMake,
            string partTypeString)
        {
            Type deviceType = this.partAssembly.GetTypes().First(x => x.Name == deviceTypeString);
            IRepairable deviceInstance = (IRepairable)Activator.CreateInstance(deviceType, deviceMake);
            Type partType = this.partAssembly.GetTypes().First(x => x.Name == partTypeString);
            IPart part = (IPart)Activator.CreateInstance(partType, "processor", 350.97m, false);
            deviceInstance.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => deviceInstance.AddPart(part));
        }

        [Test]
        [TestCase("Laptop", "Lenovo", "PCPart")]
        [TestCase("PC", "HP", "LaptopPart")]
        [TestCase("Phone", "Samsung", "LaptopPart")]
        public void AddWrongPartTypeThrowsInvalidOperationException(
            string deviceTypeString,
            string deviceMake,
            string partTypeString)
        {
            Type deviceType = this.partAssembly.GetTypes().First(x => x.Name == deviceTypeString);
            IRepairable deviceInstance = (IRepairable)Activator.CreateInstance(deviceType, deviceMake);
            Type partType = this.partAssembly.GetTypes().First(x => x.Name == partTypeString);
            IPart part = (IPart)Activator.CreateInstance(partType, "processor", 350.97m, false);

            Assert.Throws<InvalidOperationException>(() => deviceInstance.AddPart(part));
        }

        [Test]
        [TestCase("Laptop", "Lenovo", "LaptopPart")]
        [TestCase("PC", "HP", "PCPart")]
        [TestCase("Phone", "Samsung", "PhonePart")]
        public void RemovePartFunctionalityWorksCorrectly(string deviceTypeString, string deviceMake, string partTypeString)
        {
            Type deviceType = this.partAssembly.GetTypes().First(x => x.Name == deviceTypeString);
            IRepairable deviceInstance = (IRepairable)Activator.CreateInstance(deviceType, deviceMake);
            Type partType = this.partAssembly.GetTypes().First(x => x.Name == partTypeString);
            IPart firstPart = (IPart)Activator.CreateInstance(partType, "processor", 350.97m, false);
            IPart secondPart = (IPart)Activator.CreateInstance(partType, "someOtherpart", 31220.97m, true);
            List<IPart> expectedParts = new List<IPart> { firstPart };

            deviceInstance.AddPart(firstPart);
            deviceInstance.AddPart(secondPart);
            deviceInstance.RemovePart(secondPart.Name);

            Assert.IsTrue(expectedParts.SequenceEqual(deviceInstance.Parts));
        }

        [Test]
        [TestCase("Laptop", "Lenovo", "")]
        [TestCase("Laptop", "Lenovo", null)]
        [TestCase("PC", "HP", "")]
        [TestCase("PC", "HP", null)]
        [TestCase("Phone", "Samsung", "")]
        [TestCase("Phone", "Samsung", null)]
        public void RemovePartWithNullOrEmptyNameThrowsArgumentException(
            string deviceTypeString,
            string deviceMake,
            string partName)
        {
            Type deviceType = this.partAssembly.GetTypes().First(x => x.Name == deviceTypeString);
            IRepairable deviceInstance = (IRepairable)Activator.CreateInstance(deviceType, deviceMake);

            Assert.Throws<ArgumentException>(() => deviceInstance.RemovePart(partName));
        }

        [Test]
        [TestCase("Laptop", "Lenovo")]
        [TestCase("PC", "HP")]
        [TestCase("Phone", "Samsung")]
        public void RemovePartWhichHasNotBeenPreviouslyAddedThrowsInvalidOperationException(
            string deviceTypeString,
            string deviceMake)
        {
            Type deviceType = this.partAssembly.GetTypes().First(x => x.Name == deviceTypeString);
            IRepairable deviceInstance = (IRepairable)Activator.CreateInstance(deviceType, deviceMake);

            Assert.Throws<InvalidOperationException>(() => deviceInstance.RemovePart("CPU"));
        }

        [Test]
        [TestCase("Laptop", "Lenovo", "LaptopPart")]
        [TestCase("PC", "HP", "PCPart")]
        [TestCase("Phone", "Samsung", "PhonePart")]
        public void RepairPartFunctionalityWorksCorrectly(
            string deviceTypeString,
            string deviceMake,
            string partTypeString)
        {
            Type deviceType = this.partAssembly.GetTypes().First(x => x.Name == deviceTypeString);
            IRepairable deviceInstance = (IRepairable)Activator.CreateInstance(deviceType, deviceMake);
            Type partType = this.partAssembly.GetTypes().First(x => x.Name == partTypeString);
            IPart part = (IPart)Activator.CreateInstance(partType, "processor", 350.97m, true);
            deviceInstance.AddPart(part);

            deviceInstance.RepairPart(part.Name);
            List<IPart> deviceParts = (List<IPart>)deviceInstance.Parts;

            Assert.AreEqual(false, deviceParts[0].IsBroken);
        }

        [Test]
        [TestCase("Laptop", "Lenovo", "")]
        [TestCase("Laptop", "Lenovo", null)]
        [TestCase("PC", "HP", "")]
        [TestCase("PC", "HP", null)]
        [TestCase("Phone", "Samsung", "")]
        [TestCase("Phone", "Samsung", null)]
        public void RepairPartWithNullOrEmptyNameThrowsArgumentException(
            string deviceTypeString,
            string deviceMake,
            string partName)
        {
            Type deviceType = this.partAssembly.GetTypes().First(x => x.Name == deviceTypeString);
            IRepairable deviceInstance = (IRepairable)Activator.CreateInstance(deviceType, deviceMake);

            Assert.Throws<ArgumentException>(() => deviceInstance.RepairPart(partName));
        }

        [Test]
        [TestCase("Laptop", "Lenovo")]
        [TestCase("PC", "HP")]
        [TestCase("Phone", "Samsung")]
        public void RepairPartWhichHasNotBeenPreviouslyAddedThrowsInvalidOperationException(
            string deviceTypeString,
            string deviceMake)
        {
            Type deviceType = this.partAssembly.GetTypes().First(x => x.Name == deviceTypeString);
            IRepairable deviceInstance = (IRepairable)Activator.CreateInstance(deviceType, deviceMake);

            Assert.Throws<InvalidOperationException>(() => deviceInstance.RepairPart("CPU"));
        }

        [Test]
        [TestCase("Laptop", "Lenovo", "LaptopPart")]
        [TestCase("PC", "HP", "PCPart")]
        [TestCase("Phone", "Samsung", "PhonePart")]
        public void NotBrokenPartCannotBeRepairedRepairPartThrowsInvalidOperationException(
            string deviceTypeString,
            string deviceMake,
            string partTypeString)
        {
            Type deviceType = this.partAssembly.GetTypes().First(x => x.Name == deviceTypeString);
            IRepairable deviceInstance = (IRepairable)Activator.CreateInstance(deviceType, deviceMake);
            Type partType = this.partAssembly.GetTypes().First(x => x.Name == partTypeString);
            IPart part = (IPart)Activator.CreateInstance(partType, "processor", 350.97m, false);
            deviceInstance.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => deviceInstance.RepairPart(part.Name));
        }
    }
}
