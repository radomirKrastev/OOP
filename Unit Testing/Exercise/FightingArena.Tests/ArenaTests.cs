namespace FightingArena.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;    

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ArenaConstructorCreatesEmptyWarriorList()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void WarriorsGetterWorksCorrectly()
        {
            Warrior warrior = new Warrior("Maximus", 500, 500);
            this.arena.Enroll(warrior);

            List<Warrior> warriorGetter = (List<Warrior>)this.arena.Warriors;

            Assert.AreEqual(warrior, warriorGetter[0]);
            Assert.AreEqual(1, this.arena.Count);
        }

        [Test]
        public void CountGetterWorksCorrectly()
        {
            Warrior warrior = new Warrior("Maximus", 500, 500);

            this.arena.Enroll(warrior);

            Assert.AreEqual(1, this.arena.Count);
        }

        [Test]
        public void EnrollFunctionalityAddsWarriorToArenaListCorrectly()
        {
            Warrior warrior = new Warrior("Maximus", 500, 500);

            this.arena.Enroll(warrior);
            List<Warrior> warriorsList = (List<Warrior>)this.arena.Warriors;

            Assert.AreEqual(1, this.arena.Count);
            Assert.AreEqual(warrior, warriorsList[0]);
        }

        [Test]
        public void EnrollWarriorWithAlreadyExistingNameInTheArenaListThrowsInvalidOperationException()
        {
            Warrior firstWarrior = new Warrior("Maximus", 500, 500);
            Warrior secondWarrior = new Warrior("Maximus", 1000, 1000);

            this.arena.Enroll(firstWarrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(secondWarrior));
        }

        [Test]
        public void FightWorksCorrectlyBothWarriorsAttackEachOtherAndTheirHealthDecrease()
        {
            Warrior firstWarrior = new Warrior("Maximus", 100, 100);
            Warrior secondWarrior = new Warrior("Commodus", 100, 100);

            this.arena.Enroll(firstWarrior);
            this.arena.Enroll(secondWarrior);
            this.arena.Fight("Maximus", "Commodus");

            List<Warrior> warriorsList = (List<Warrior>)this.arena.Warriors;

            Assert.AreEqual(0, warriorsList[0].HP);
            Assert.AreEqual(0, warriorsList[1].HP);
        }

        [Test]
        public void FightThrowsInvalidOperationExceptionWhenOneOfTheWarriorsIsNotEnrolled()
        {
            Warrior firstWarrior = new Warrior("Maximus", 500, 500);
            Warrior secondWarrior = new Warrior("Commodus", 1000, 1000);
            Warrior thirdWarrior = new Warrior("Spartacus", 50000, 50000);

            this.arena.Enroll(firstWarrior);
            this.arena.Enroll(secondWarrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Maximus", "Spartacus"));
        }
    }
}
