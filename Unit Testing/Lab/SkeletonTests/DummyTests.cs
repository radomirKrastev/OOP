namespace SkeletonTests
{
    using System;
    using NUnit.Framework;
    
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLoosesHealthWhenAttacked()
        {
            Axe axe = new Axe(2, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(8, dummy.Health, "Dummy does not loose health when attacked.");
        }

        [Test]
        ////[TestCase(2, 0)]
        ////[TestCase(2, -1)]
        ////[TestCase(2, 1)]
        public void DeadDummyThrowsInvalidOperationExceptionWhenAttacked()
        {
            Axe axe = new Axe(2, 10);
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }

        [Test]
        ////[TestCase(0)]
        ////[TestCase(-1)]
        ////[TestCase(1)]
        public void DeadDummyGivesExperience()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.AreEqual(10, dummy.GiveExperience());
        }

        [Test]
        ////[TestCase(0)]
        ////[TestCase(-1)]
        ////[TestCase(1)]
        public void AliveDummyDoesNotGiveExperienceInsteadShouldThrowInvalidOperationException()
        {
            Dummy dummy = new Dummy(1, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
