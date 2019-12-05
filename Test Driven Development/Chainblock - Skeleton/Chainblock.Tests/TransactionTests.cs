namespace Chainblock.Tests
{
    using Chainblock.Contracts;    
    using Chainblock.Models;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void TransactionConstructorWorksCorrectly()
        {
            ITransaction transaction = new Transaction(123, TransactionStatus.Unauthorized, "Batman", "Robin", 2.5);

            Assert.AreEqual(123, transaction.Id);
            Assert.AreEqual(TransactionStatus.Unauthorized, transaction.Status);
            Assert.AreEqual("Batman", transaction.From);
            Assert.AreEqual("Robin", transaction.To);
            Assert.AreEqual(2.5, transaction.Amount);
        }
    }
}
