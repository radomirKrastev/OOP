namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;    

    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Maximus", 100, 100);
        }

        [Test]
        public void WarriorConstructorWorksCorrectly()
        {
            Assert.AreEqual("Maximus", this.warrior.Name);
            Assert.AreEqual(100, this.warrior.Damage);
            Assert.AreEqual(100, this.warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("\t")]
        [TestCase("\n")]
        [TestCase(" ")]
        [TestCase("     ")]
        [TestCase("")]
        public void NameSetterThrowsArgumentsExceptionWhenParameterValueIsNullOrWhitespace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 100, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void DamageSetterThrowsArgumentsExceptionWhenParameterValueIsZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Maximus", damage, 100));
        }

        [Test]
        [TestCase(-1)]
        public void HPSetterThrowsArgumentsExceptionWhenParameterValueIsNegative(int healthPoints)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Maximus", 100, healthPoints));
        }

        [Test]
        [TestCase(100, 100, 0, 0)]
        [TestCase(200, 50, 50, 100)]
        [TestCase(99, 20, 80, 0)]
        public void AttackDecreasesAttackingAndAttackedWarriorsHPCorrectly(
            int attackedWarriorHP, 
            int attackedWarriorDamage, 
            int attackingWarriorExpectedHP,
            int attackedWarriorExpectedHP)
        {
            Warrior attackedWarrior = new Warrior("Commodus", attackedWarriorDamage, attackedWarriorHP);

            this.warrior.Attack(attackedWarrior);

            Assert.AreEqual(attackingWarriorExpectedHP, this.warrior.HP);
            Assert.AreEqual(attackedWarriorExpectedHP, attackedWarrior.HP);
        }

        [Test]
        [TestCase(30)]
        [TestCase(29)]
        public void WarriorAttackWith30HPOrLessThrowsInvalidOperationException(int healthPoints)
        {
            Warrior attackingWarrior = new Warrior("Max", 50000, healthPoints);
            Warrior attackedWarrior = new Warrior("Com", 50, 5000);

            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(attackedWarrior));
        }

        [Test]
        [TestCase(30)]
        [TestCase(29)]
        public void AttackedWarriorWith30HPOrLessThrowsInvalidOperationException(int healthPoints)
        {
            Warrior attackingWarrior = new Warrior("Max", 50, 5000);
            Warrior attackedWarrior = new Warrior("Com", 50, healthPoints);

            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(attackedWarrior));
        }

        [Test]
        public void AttackWarriorTargetWithMoreDamageThanTheAttackingWarriorHPThrowsInvalidOperationException()
        {
            Warrior attackingWarrior = new Warrior("Max", 50, 50);
            Warrior attackedWarrior = new Warrior("Com", 51, 500);

            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(attackedWarrior));
        }
    }
}