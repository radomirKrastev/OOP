using NUnit.Framework;
using System;

namespace SkeletonTests
{
    [TestFixture]
    public class AxeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert

            Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void BrokenAxeAttack()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(20, 20);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}