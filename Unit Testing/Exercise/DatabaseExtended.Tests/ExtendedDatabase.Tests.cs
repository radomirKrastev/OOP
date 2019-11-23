namespace ExtendedDatabase.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDatabase; 

        [SetUp]
        public void Setup()
        {
            Person personOne = new Person(123, "Mincho");
            Person personTwo = new Person(321, "Dimcho");

            this.extendedDatabase = new ExtendedDatabase(personOne, personTwo); 
        }

        [Test]
        public void DatabaseConstructorSetsCorrectly()
        {
            Person[] personData = new Person[2];

            personData[0] = new Person(123, "Mincho");
            personData[1] = new Person(321, "Dimcho");

            ExtendedDatabase extendedDatabaseInstance = new ExtendedDatabase(personData);

            Person[] extendedDatabaseArray = (Person[])typeof(ExtendedDatabase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.FieldType == typeof(Person[]))
                .First()
                .GetValue(extendedDatabaseInstance);

            Person[] extendedDatabasePersons = new Person[2];

            for (int i = 0; i < 2; i++)
            {
                extendedDatabasePersons[i] = extendedDatabaseArray[i];
            }

            Assert.IsTrue(extendedDatabasePersons.SequenceEqual(personData));
            Assert.AreEqual(2, extendedDatabaseInstance.Count);
        }

        [Test]
        public void GiveMoreThanSixteenElementsToConstructorThrowsArgumentException()
        {
            Person[] arr = new Person[17];
            
            for (int i = 0; i < 17; i++)
            {
                arr[i] = new Person(i, $"Name{i}");
            }            

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(arr));
        }

        [Test]
        public void AddFunctionalityAddsElementCorrectly()
        {
            Person personToAdd = new Person(555, "Joko");

            this.extendedDatabase.Add(personToAdd);

            Person[] extendedDatabasePersons = (Person[])typeof(ExtendedDatabase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.FieldType == typeof(Person[]))
                .First()
                .GetValue(this.extendedDatabase);

            Person extendedDatabaseLastPerson = extendedDatabasePersons[this.extendedDatabase.Count - 1];

            Assert.AreEqual(extendedDatabaseLastPerson, personToAdd);
            Assert.AreEqual(3, this.extendedDatabase.Count);
        }

        [Test]
        public void AddMSeventeenthElementThrowsInvalidOperationException()
        {
            for (int i = 0; i < 14; i++)
            {
                this.extendedDatabase.Add(new Person(i, $"Name{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(new Person(200, $"MaikalJordan")));
        }

        [Test]
        public void AddUserWithAlreadyExistingUsernameShouldThrowInvalidOperationException()
        {
            Person personOne = new Person(2013, "Mincho");

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(personOne));
        }

        [Test]
        public void AddUserWithAlreadyExistingIdShouldThrowInvalidOperationException()
        {
            Person personOne = new Person(123, "Anastasii");

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(personOne));
        }

        [Test]
        public void RemoveMethodWorksCorrectly()
        {
            this.extendedDatabase.Remove();
            this.extendedDatabase.Remove();
            Person personOne = new Person(123, "Mincho");
            this.extendedDatabase.Add(personOne);

            Person[] extendedDatabasePersons = (Person[])typeof(ExtendedDatabase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.FieldType == typeof(Person[]))
                .First()
                .GetValue(this.extendedDatabase);

            Person extendedDatabaseLastPerson = extendedDatabasePersons[this.extendedDatabase.Count - 1];

            Assert.AreEqual(extendedDatabaseLastPerson, personOne);
            Assert.AreEqual(1, this.extendedDatabase.Count);
        }

        [Test]
        public void RemoveFromEmptyExtendedDatabaseShouldThrowInvalidOperationException()
        {
            this.extendedDatabase.Remove();
            this.extendedDatabase.Remove();

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Remove());
        }

        [Test]
        public void FindByUsernameWorksCorrectly()
        {
            string personName = "Mincho";

            string extendedDatabaseName = this.extendedDatabase.FindByUsername(personName).UserName;

            Assert.AreEqual(personName, extendedDatabaseName);
        }

        [Test]
        public void FindByIdWorksCorrectly()
        {
            long personId = 123;

            long extendedDatabaseId = this.extendedDatabase.FindById(personId).Id;

            Assert.AreEqual(personId, extendedDatabaseId);
        }

        [Test]
        public void IfNoUserCanBeFoundByUsernameShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindByUsername("Petar"));
        }

        [Test]
        public void FindByUsernameShouldThrowArgumentNullExceptionIfUsernameParameterIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.extendedDatabase.FindByUsername(null));
        }

        [Test]
        public void IfNoUserCanBeFoundByIdShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindById(167));
        }

        [Test]
        public void FindByIdShouldThrowArgumentOutOfRangeExceptionIfIdParameterNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extendedDatabase.FindById(-1));
        }        
    }
}