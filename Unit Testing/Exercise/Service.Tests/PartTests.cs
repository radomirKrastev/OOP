namespace Service.Tests
{   
    using System;
    using System.Linq;
    using System.Reflection;    
    using Models.Contracts;
    using Models.Parts;
    using NUnit.Framework;

    [TestFixture]
    public class PartTests
    {
        private decimal partCostMultiplier = 1;
        private Assembly partAssembly;

        [SetUp]
        public void Setup()
        {
            this.partAssembly = typeof(Part).Assembly;
        }

        [Test]
        [TestCase("LaptopPart", "processor", 1000, true)]
        [TestCase("PCPart", "fan", 155.5, true)]
        [TestCase("PhonePart", "touchscreen", 357, false)]
        public void PartConstructorWorksCorrectlyWithThreeParameters(
            string partTypeString,
            string partName,
            decimal partCost,
            bool isPartBroken)
        {
            Type partType = this.partAssembly.GetTypes().First(x => x.Name == partTypeString);

            IPart partInstance = (IPart)Activator.CreateInstance(partType, partName, partCost, isPartBroken);
            this.GetMultiplier(partType, partInstance);

            Assert.AreEqual(partName, partInstance.Name);
            Assert.AreEqual(partCost * this.partCostMultiplier, partInstance.Cost);
            Assert.AreEqual(isPartBroken, partInstance.IsBroken);
        }

        [Test]
        [TestCase("LaptopPart", "processor", 1000)]
        [TestCase("PCPart", "fan", 155.5)]
        [TestCase("PhonePart", "touchscreen", 357)]
        public void PartConstructorWorksCorrectlyWithTwoParameters(
            string partTypeString,
            string partName,
            decimal partCost)
        {
            Type partType = this.partAssembly.GetTypes().First(x => x.Name == partTypeString);

            IPart partInstance = (IPart)Activator.CreateInstance(partType, partName, partCost);
            this.GetMultiplier(partType, partInstance);
                        
            Assert.AreEqual(partName, partInstance.Name);
            Assert.AreEqual(partCost * this.partCostMultiplier, partInstance.Cost);
            Assert.AreEqual(false, partInstance.IsBroken);
        }

        [Test]
        [TestCase("LaptopPart", "", 1000, true)]
        [TestCase("LaptopPart", null, 1000, true)]
        [TestCase("PCPart", "", 155.5, true)]
        [TestCase("PCPart", null, 155.5, true)]
        [TestCase("PhonePart", "", 357, false)]
        [TestCase("PhonePart", null, 357, false)]
        public void PartNameSetterThrowsArgumentExceptionIfParameterValueIsNullOrEmpty(
            string partTypeString,
            string partName,
            decimal partCost,
            bool isPartBroken)
        {
            Type partType = this.partAssembly.GetTypes().First(x => x.Name == partTypeString);

            try
            {
                Activator.CreateInstance(partType, partName, partCost, isPartBroken);
            }
            catch (TargetInvocationException e)
            {
                Assert.AreEqual(typeof(ArgumentException), e.InnerException.GetType());
            }
        }

        [Test]
        [TestCase("LaptopPart", "processor", 0, true)]
        [TestCase("LaptopPart", "processor", -1, true)]
        [TestCase("PCPart", "fan", 0, true)]
        [TestCase("PCPart", "fan", -1, true)]
        [TestCase("PhonePart", "touchscreen", 0, false)]
        [TestCase("PhonePart", "touchscreen", -1, false)]
        public void PartCostSetterThrowsArgumentExceptionIfParameterValueIsZeroOrNegative(
            string partTypeString,
            string partName,
            decimal partCost,
            bool isPartBroken)
        {
            Type partType = this.partAssembly.GetTypes().First(x => x.Name == partTypeString);

            try
            {
                Activator.CreateInstance(partType, partName, partCost, isPartBroken);
            }
            catch (TargetInvocationException e)
            {             
                Assert.AreEqual(typeof(ArgumentException), e.InnerException.GetType());
            }
        }

        [Test]
        [TestCase("LaptopPart", "processor", 1000, true)]
        [TestCase("PCPart", "fan", 155.5, true)]
        [TestCase("PhonePart", "touchscreen", 357, true)]
        public void RepairSetsIsBrokenProperyToFalse(
            string partTypeString,
            string partName,
            decimal partCost,
            bool isPartBroken)
        {
            Type partType = this.partAssembly.GetTypes().First(x => x.Name == partTypeString);
            IPart partInstance = (IPart)Activator.CreateInstance(partType, partName, partCost, isPartBroken);

            partInstance.Repair();

            Assert.AreEqual(false, partInstance.IsBroken);
        }

        [Test]
        [TestCase("LaptopPart", "processor", 1000, true)]
        [TestCase("PCPart", "fan", 155.5, false)]
        [TestCase("PhonePart", "touchscreen", 357, false)]
        public void ReportReturnsCorrectlyInformationAboutThePartAsString(
            string partTypeString,
            string partName,
            decimal partCost,
            bool isPartBroken)
        {
            Type partType = this.partAssembly.GetTypes().First(x => x.Name == partTypeString);
            IPart partInstance = (IPart)Activator.CreateInstance(partType, partName, partCost, isPartBroken);
            this.GetMultiplier(partType, partInstance);
            string expectedReportMessage = $"{partName} - {partCost * partCostMultiplier:f2}$"
                + Environment.NewLine
                + $"Broken: {isPartBroken}";

            Assert.AreEqual(expectedReportMessage, partInstance.Report());
        }

        private void GetMultiplier(Type partType, IPart partInstance)
        {
            if (partType != typeof(Part))
            {
                this.partCostMultiplier = (decimal)partType.GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                .Where(fi => fi.IsInitOnly)
                .First()
                .GetValue(partInstance);
            }
        }
    }
}