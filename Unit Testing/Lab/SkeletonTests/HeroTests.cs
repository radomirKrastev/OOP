namespace SkeletonTests
{
    using Moq;
    using NUnit.Framework;
    using Skeleton.Interfaces;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroTakesExperienceWhenTargetDies()
        {
            Mock<IWeapon> mockWeapon = new Mock<IWeapon>();
            Mock<ITarget> mockTarget = new Mock<ITarget>();
            mockTarget.Setup(t => t.IsDead()).Returns(true);
            mockTarget.Setup(t => t.GiveExperience()).Returns(10);
                       
            Hero hero = new Hero("Jikata", mockWeapon.Object);
            hero.Attack(mockTarget.Object);

            Assert.AreEqual(10, hero.Experience);
        }
    }
}
