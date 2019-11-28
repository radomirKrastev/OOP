namespace Telecom.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class PhoneTests
    {
        private Phone phone;

        [SetUp]
        public void Setup()
        {
            this.phone = new Phone("Samsung", "S10");
        }

        [Test]
        public void PhoneConstructorWorksCorrectly()
        {
            FieldInfo phonebookField = typeof(Phone).GetField("phonebook", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, string> phonebook = (Dictionary<string, string>)phonebookField.GetValue(this.phone);

            Assert.AreEqual("Samsung", this.phone.Make);
            Assert.AreEqual("S10", this.phone.Model);
            Assert.IsTrue(phonebookField != null);
        }

        [Test]
        [TestCase("", "S10")]
        [TestCase(null, "A70")]
        public void MakeSetterThrowsArgumentExceptionWhenParameterValueIsNullOrEmpty(string make, string model)
        {
            Assert.Throws<ArgumentException>(() => new Phone(make, model)); 
        }

        [Test]
        [TestCase("Samsung", "")]
        [TestCase("Samsung", null)]
        public void ModelSetterThrowsArgumentExceptionWhenParameterValueIsNullOrEmpty(string make, string model)
        {
            Assert.Throws<ArgumentException>(() => new Phone(make, model));
        }
        
        [Test]
        [TestCase("Stamat", "0831273213")]
        [TestCase("Apostol Popov", "0831273214")]
        public void AddContactAddsContactToPhonebookCorrectly(string name, string phone)
        {
            this.phone.AddContact(name, phone);

            Assert.AreEqual(1, this.phone.Count);
        }

        [Test]
        [TestCase("Stamat", "0831273213")]
        [TestCase("Stamat", "0789775627")]
        public void AddContactThrowsInvalidOperationExceptionIfTheContactNameIsAlreadyAdded(string name, string phone)
        {
            this.phone.AddContact(name, phone);

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact(name, phone));
        }

        [Test]
        public void CallReturnsCorrectlyCallingMessage()
        {
            this.phone.AddContact("Stamat", "0831273213");

            this.phone.Call("Stamat");

            Assert.AreEqual("Calling Stamat - 0831273213...", this.phone.Call("Stamat"));            
        }

        [Test]
        public void CallThrowsInvalidOperationExceptionIfContactNameDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Stamat"));
        }
    }
}