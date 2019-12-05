namespace Chainblock.Tests
{
    using System;
    using System.Collections.Generic;
    using Chainblock.Contracts;
    using Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private Mock<ITransaction> transaction;

        [SetUp]
        public void Setup()
        {
            this.transaction = new Mock<ITransaction>();
            this.transaction.SetupGet(x => x.Id).Returns(123);
            this.transaction.SetupGet(x => x.Status).Returns(TransactionStatus.Unauthorized);
            this.chainblock = new Chainblock();
        }

        [Test]
        public void AddTransactionWorksCorrectly()
        {
            this.chainblock.Add(this.transaction.Object);

            Assert.AreEqual(1, this.chainblock.Count);
            Assert.AreEqual(true, this.chainblock.Contains(this.transaction.Object));
        }

        [Test]
        public void AddSameTransactionWorksThrowsInvalidOperationException()
        {
            this.chainblock.Add(this.transaction.Object);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.Add(this.transaction.Object));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ContainsTransactionWorksCorrectly(bool expectedResult)
        {
            Mock<ITransaction> secondTransaction = new Mock<ITransaction>();
            secondTransaction.SetupGet(x => x.Id).Returns(145);

            if (expectedResult)
            {
                this.chainblock.Add(this.transaction.Object);
                this.chainblock.Add(secondTransaction.Object);
            }
            else
            {
                this.chainblock.Add(this.transaction.Object);
            }

            Assert.AreEqual(expectedResult, this.chainblock.Contains(secondTransaction.Object));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ContainsTransactionIdWorksCorrectly(bool expectedResult)
        {
            Mock<ITransaction> secondTransaction = new Mock<ITransaction>();
            secondTransaction.SetupGet(x => x.Id).Returns(145);

            if (expectedResult)
            {
                this.chainblock.Add(this.transaction.Object);
                this.chainblock.Add(secondTransaction.Object);
            }
            else
            {
                this.chainblock.Add(this.transaction.Object);
            }

            Assert.AreEqual(expectedResult, this.chainblock.Contains(145));
        }

        [Test]
        public void ChangeTransactionStatusWorksCorrectly()
        {
            this.chainblock.Add(this.transaction.Object);
            this.chainblock.ChangeTransactionStatus(123, TransactionStatus.Successfull);

            Assert.AreEqual(TransactionStatus.Successfull, this.chainblock.GetById(123).Status);
        }

        [Test]
        public void ChangeTransactionStatusThrowsArgumentExceptionIfNoSuchTransactionExists()
        {
            Assert.Throws<ArgumentException>(() => this.chainblock.ChangeTransactionStatus(123, TransactionStatus.Successfull));
        }

        [Test]
        public void RemoveTransactionByIdWorksCorrectly()
        {
            this.chainblock.Add(this.transaction.Object);
            this.chainblock.RemoveTransactionById(123);

            Assert.AreEqual(false, this.chainblock.Contains(123));
        }

        [Test]
        public void RemoveTransactionByIdThrowsInvalidOperationExceptionIfNoSuchTransactionExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.RemoveTransactionById(123));
        }

        [Test]
        public void GetByIdThrowsInvalidOperationExceptionIfNoSuchTransactionExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetById(123));
        }

        [Test]
        public void GetByTransactionStatusReturnsCorrectCollection()
        {
            this.transaction.SetupGet(x => x.Amount).Returns(500);

            Mock<ITransaction> secondTransaction = new Mock<ITransaction>();
            secondTransaction.SetupGet(x => x.Status).Returns(TransactionStatus.Unauthorized);
            secondTransaction.SetupGet(x => x.Amount).Returns(550);

            Mock<ITransaction> thirdTransaction = new Mock<ITransaction>();
            thirdTransaction.SetupGet(x => x.Status).Returns(TransactionStatus.Unauthorized);
            thirdTransaction.SetupGet(x => x.Amount).Returns(350);

            Mock<ITransaction> fourthTransaction = new Mock<ITransaction>();
            fourthTransaction.SetupGet(x => x.Status).Returns(TransactionStatus.Successfull);
            fourthTransaction.SetupGet(x => x.Amount).Returns(550);

            IEnumerable<ITransaction> expectedCollection = new List<ITransaction> 
            { 
                secondTransaction.Object,
                this.transaction.Object,
                thirdTransaction.Object
            };

            this.chainblock.Add(fourthTransaction.Object);
            this.chainblock.Add(this.transaction.Object);
            this.chainblock.Add(thirdTransaction.Object);
            this.chainblock.Add(secondTransaction.Object);

            Assert.AreEqual(expectedCollection, this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void GetByTransactionStatusThrowsInvalidOperationExceptionIfNoSuchTransactionsExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusReturnsCorrectCollectionOfNames()
        {
            this.transaction.SetupGet(x => x.Amount).Returns(500);
            this.transaction.SetupGet(x => x.From).Returns("Maikal");

            Mock<ITransaction> secondTransaction = new Mock<ITransaction>();
            secondTransaction.SetupGet(x => x.Status).Returns(TransactionStatus.Unauthorized);
            secondTransaction.SetupGet(x => x.Amount).Returns(550);
            secondTransaction.SetupGet(x => x.From).Returns("Tonkata");

            Mock<ITransaction> thirdTransaction = new Mock<ITransaction>();
            thirdTransaction.SetupGet(x => x.Status).Returns(TransactionStatus.Unauthorized);
            thirdTransaction.SetupGet(x => x.Amount).Returns(350);
            thirdTransaction.SetupGet(x => x.From).Returns("Jamal");

            Mock<ITransaction> fourthTransaction = new Mock<ITransaction>();
            fourthTransaction.SetupGet(x => x.Status).Returns(TransactionStatus.Unauthorized);
            fourthTransaction.SetupGet(x => x.Amount).Returns(275);
            fourthTransaction.SetupGet(x => x.From).Returns("Jamal");

            IEnumerable<string> expectedCollection = new List<string> { "Tonkata", "Maikal", "Jamal", "Jamal" };

            this.chainblock.Add(this.transaction.Object);
            this.chainblock.Add(secondTransaction.Object);
            this.chainblock.Add(thirdTransaction.Object);
            this.chainblock.Add(fourthTransaction.Object);

            Assert.AreEqual(expectedCollection, this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusThrowsInvalidOperationExceptionIfNoSuchTransactionsExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void GetAllReceiverWithTransactionStatusReturnsCorrectCollectionOfNames()
        {
            this.transaction.SetupGet(x => x.Amount).Returns(500);
            this.transaction.SetupGet(x => x.To).Returns("Maikal");

            Mock<ITransaction> secondTransaction = new Mock<ITransaction>();
            secondTransaction.SetupGet(x => x.Status).Returns(TransactionStatus.Unauthorized);
            secondTransaction.SetupGet(x => x.Amount).Returns(550);
            secondTransaction.SetupGet(x => x.To).Returns("Tonkata");

            Mock<ITransaction> thirdTransaction = new Mock<ITransaction>();
            thirdTransaction.SetupGet(x => x.Status).Returns(TransactionStatus.Unauthorized);
            thirdTransaction.SetupGet(x => x.Amount).Returns(350);
            thirdTransaction.SetupGet(x => x.To).Returns("Jamal");

            Mock<ITransaction> fourthTransaction = new Mock<ITransaction>();
            fourthTransaction.SetupGet(x => x.Status).Returns(TransactionStatus.Unauthorized);
            fourthTransaction.SetupGet(x => x.Amount).Returns(275);
            fourthTransaction.SetupGet(x => x.To).Returns("Jamal");

            IEnumerable<string> expectedCollection = new List<string> { "Tonkata", "Maikal", "Jamal", "Jamal" };

            this.chainblock.Add(this.transaction.Object);
            this.chainblock.Add(secondTransaction.Object);
            this.chainblock.Add(thirdTransaction.Object);
            this.chainblock.Add(fourthTransaction.Object);

            Assert.AreEqual(expectedCollection, this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusThrowsInvalidOperationExceptionIfNoSuchTransactionsExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdReturnsCorrectCollectionOfTransactions()
        {
            this.transaction.SetupGet(x => x.Amount).Returns(500);

            Mock<ITransaction> secondTransaction = new Mock<ITransaction>();
            secondTransaction.SetupGet(x => x.Amount).Returns(550);
            secondTransaction.SetupGet(x => x.Id).Returns(125);

            Mock<ITransaction> fourthTransaction = new Mock<ITransaction>();
            fourthTransaction.SetupGet(x => x.Amount).Returns(550);
            fourthTransaction.SetupGet(x => x.Id).Returns(150);

            IEnumerable<ITransaction> expectedCollection = new List<ITransaction> 
            { 
                fourthTransaction.Object,
                secondTransaction.Object,
                this.transaction.Object,
            };

            this.chainblock.Add(this.transaction.Object);
            this.chainblock.Add(fourthTransaction.Object);
            this.chainblock.Add(secondTransaction.Object);

            Assert.AreEqual(expectedCollection, this.chainblock.GetAllOrderedByAmountDescendingThenById());
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingReturnsCorrectCollectionOfNames()
        {
            this.transaction.SetupGet(x => x.Amount).Returns(500);
            this.transaction.SetupGet(x => x.From).Returns("Maikal");

            Mock<ITransaction> thirdTransaction = new Mock<ITransaction>();
            thirdTransaction.SetupGet(x => x.Amount).Returns(250);
            thirdTransaction.SetupGet(x => x.From).Returns("Jamal");

            Mock<ITransaction> fourthTransaction = new Mock<ITransaction>();
            fourthTransaction.SetupGet(x => x.Amount).Returns(275);
            fourthTransaction.SetupGet(x => x.From).Returns("Jamal");

            IEnumerable<ITransaction> expectedCollection = new List<ITransaction> 
            { 
                thirdTransaction.Object,
                fourthTransaction.Object,
            };

            this.chainblock.Add(this.transaction.Object);
            this.chainblock.Add(thirdTransaction.Object);
            this.chainblock.Add(fourthTransaction.Object);

            Assert.AreEqual(expectedCollection, this.chainblock.GetBySenderOrderedByAmountDescending("Jamal"));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingThrowsInvalidOperationExceptionIfNoSuchTransactionsExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderOrderedByAmountDescending("Mumbai"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdReturnsCorrectCollectionOfTransactions()
        {
            this.transaction.SetupGet(x => x.Amount).Returns(500);
            this.transaction.SetupGet(x => x.To).Returns("Anton");

            Mock<ITransaction> secondTransaction = new Mock<ITransaction>();
            secondTransaction.SetupGet(x => x.Amount).Returns(500);
            secondTransaction.SetupGet(x => x.To).Returns("Anton");
            secondTransaction.SetupGet(x => x.Id).Returns(120);

            Mock<ITransaction> fourthTransaction = new Mock<ITransaction>();
            fourthTransaction.SetupGet(x => x.Amount).Returns(550);
            fourthTransaction.SetupGet(x => x.To).Returns("Jikata");
            fourthTransaction.SetupGet(x => x.Id).Returns(150);

            IEnumerable<ITransaction> expectedCollection = new List<ITransaction> 
            {  
                secondTransaction.Object,
                this.transaction.Object,
            };

            this.chainblock.Add(this.transaction.Object);
            this.chainblock.Add(fourthTransaction.Object);
            this.chainblock.Add(secondTransaction.Object);

            Assert.AreEqual(expectedCollection, this.chainblock.GetByReceiverOrderedByAmountThenById("Anton"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdThrowsInvalidOperationExceptionIfNoSuchTransactionsExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverOrderedByAmountThenById("Mumbai"));
        }
        
        [Test]
        [TestCase(500)]
        [TestCase(498)]
        public void GetByTransactionStatusAndMaximumAmountReturnsCorrectCollectionOfTransactions(double maximumAmount)
        {
            this.transaction.SetupGet(x => x.Amount).Returns(499);

            Mock<ITransaction> secondTransaction = new Mock<ITransaction>();
            secondTransaction.SetupGet(x => x.Amount).Returns(500);
            secondTransaction.SetupGet(x => x.Status).Returns(TransactionStatus.Unauthorized);

            Mock<ITransaction> fourthTransaction = new Mock<ITransaction>();
            fourthTransaction.SetupGet(x => x.Amount).Returns(550);
            fourthTransaction.SetupGet(x => x.Status).Returns(TransactionStatus.Unauthorized);

            IEnumerable<ITransaction> expectedCollection = new List<ITransaction>();

            if (maximumAmount == 500)
            {
                expectedCollection = new List<ITransaction> { secondTransaction.Object, this.transaction.Object };
            }

            this.chainblock.Add(this.transaction.Object);
            this.chainblock.Add(fourthTransaction.Object);
            this.chainblock.Add(secondTransaction.Object);

            Assert.AreEqual(expectedCollection, this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Unauthorized, maximumAmount));
        }

        [Test]
        [TestCase(500.01)]
        public void GetBySenderAndMinimumAmountDescendingReturnsCorrectCollectionOfTransactions(double minimumAmount)
        {
            this.transaction.SetupGet(x => x.Amount).Returns(500.01);
            this.transaction.SetupGet(x => x.From).Returns("Mane");

            Mock<ITransaction> secondTransaction = new Mock<ITransaction>();
            secondTransaction.SetupGet(x => x.Amount).Returns(500);
            secondTransaction.SetupGet(x => x.From).Returns("Mane");

            Mock<ITransaction> fourthTransaction = new Mock<ITransaction>();
            fourthTransaction.SetupGet(x => x.Amount).Returns(550);
            fourthTransaction.SetupGet(x => x.From).Returns("Mane");

            IEnumerable<ITransaction> expectedCollection = new List<ITransaction> { fourthTransaction.Object, this.transaction.Object };

            this.chainblock.Add(this.transaction.Object);
            this.chainblock.Add(fourthTransaction.Object);
            this.chainblock.Add(secondTransaction.Object);

            Assert.AreEqual(expectedCollection, this.chainblock.GetBySenderAndMinimumAmountDescending("Mane", minimumAmount));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingThrowsInvalidOperationExceptionIfNoSuchTransactionsExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderAndMinimumAmountDescending("Mumbai", 500));
        }
        
        [Test]
        [TestCase(500.01, 547)]
        public void GetByReceiverAndAmountRangeReturnsCorrectCollectionOfTransactions(double minimumAmount, double maximumAmount)
        {
            this.transaction.SetupGet(x => x.Amount).Returns(500.01);
            this.transaction.SetupGet(x => x.To).Returns("Mane");

            Mock<ITransaction> secondTransaction = new Mock<ITransaction>();
            secondTransaction.SetupGet(x => x.Amount).Returns(500.1);
            secondTransaction.SetupGet(x => x.Id).Returns(136);
            secondTransaction.SetupGet(x => x.To).Returns("Mane");

            Mock<ITransaction> fourthTransaction = new Mock<ITransaction>();
            fourthTransaction.SetupGet(x => x.Amount).Returns(547);
            fourthTransaction.SetupGet(x => x.Id).Returns(150);
            fourthTransaction.SetupGet(x => x.To).Returns("Mane");

            IEnumerable<ITransaction> expectedCollection = new List<ITransaction> { secondTransaction.Object, this.transaction.Object };

            this.chainblock.Add(this.transaction.Object);
            this.chainblock.Add(fourthTransaction.Object);
            this.chainblock.Add(secondTransaction.Object);

            Assert.AreEqual(expectedCollection, this.chainblock.GetByReceiverAndAmountRange("Mane", minimumAmount, maximumAmount));
        }

        [Test]
        public void GetByReceiverAndAmountRangeThrowsInvalidOperationExceptionIfNoSuchTransactionsExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverAndAmountRange("Mumbai", 500, 600));
        }

        [Test]
        [TestCase(500, 550)]
        [TestCase(475, 499)]
        public void GetAllInAmountRangeReturnsCorrectCollectionOfTransactions(double minimumAmount, double maximumAmount)
        {
            this.transaction.SetupGet(x => x.Amount).Returns(500);

            Mock<ITransaction> secondTransaction = new Mock<ITransaction>();
            secondTransaction.SetupGet(x => x.Amount).Returns(5550);

            Mock<ITransaction> fourthTransaction = new Mock<ITransaction>();
            fourthTransaction.SetupGet(x => x.Amount).Returns(550);

            IEnumerable<ITransaction> expectedCollection = new List<ITransaction>();

            if (minimumAmount == 500 && maximumAmount == 550)
            {
                expectedCollection = new List<ITransaction> { this.transaction.Object, fourthTransaction.Object };
            }

            this.chainblock.Add(this.transaction.Object);
            this.chainblock.Add(fourthTransaction.Object);
            this.chainblock.Add(secondTransaction.Object);

            Assert.AreEqual(expectedCollection, this.chainblock.GetAllInAmountRange(maximumAmount, maximumAmount));
        }
    }
}
