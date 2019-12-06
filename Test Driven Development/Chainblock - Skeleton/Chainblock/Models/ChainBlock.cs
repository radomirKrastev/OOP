namespace Chainblock.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class ChainBlock : IChainblock
    {
        private List<ITransaction> transactions;

        public ChainBlock()
        {
            this.transactions = new List<ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.transactions.Any(x => x.Id == tx.Id))
            {
                throw new InvalidOperationException("Transaction already added!");
            }

            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(x => x.Id == id);

            if (transaction == null)
            {
                throw new ArgumentException("No transaction found with this id.");
            }

            double amount = transaction.Amount;
            string sender = transaction.From;
            string receiver = transaction.To;
            int index = this.transactions.FindIndex(x => x.Id == id);

            this.transactions[index] = new Transaction(id, newStatus, sender, receiver, amount);
        }

        public bool Contains(ITransaction tx)
        {
            return this.transactions.Any(x => x.Id == tx.Id);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(x => x.Id == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this.transactions.Where(x => x.Amount >= lo && x.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions.OrderByDescending(x => x.Amount).ThenByDescending(x => x.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (!this.transactions.Any(x => x.Status == status))
            {
                throw new InvalidOperationException("Transactions with such status does not exist!");
            }

            IOrderedEnumerable<ITransaction> receiversTransactions = this.transactions
                .Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount);

            IEnumerable<string> names = receiversTransactions.Select(x => x.To);

            return names;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (!this.transactions.Any(x => x.Status == status))
            {
                throw new InvalidOperationException("Transactions with such status does not exist!");
            }

            IOrderedEnumerable<ITransaction> sendersTransactions = this.transactions
                .Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount);

            IEnumerable<string> names = sendersTransactions.Select(x => x.From);

            return names;
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(x => x.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException("Cannot remove transaction that does not exists!");
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            if (!this.transactions.Any(x => x.To == receiver && x.Amount >= lo && x.Amount < hi))
            {
                throw new InvalidOperationException("No transactions exist with these parameters!");
            }

            return this.transactions
                .Where(x => x.To == receiver && x.Amount >= lo && x.Amount < hi)
                .OrderByDescending(x => x.Amount)
                .ThenByDescending(x => x.Id);
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            if (!this.transactions.Any(x => x.To == receiver))
            {
                throw new InvalidOperationException("No receiver with this name exists!");
            }

            return this.transactions.Where(x => x.To == receiver).OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            if (!this.transactions.Any(x => x.From == sender && x.Amount >= amount))
            {
                throw new InvalidOperationException("No transactions exist with these parameters!");
            }

            return this.transactions.Where(x => x.From == sender && x.Amount >= amount).OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (!this.transactions.Any(x => x.From == sender))
            {
                throw new InvalidOperationException("No sender with this name exists!");
            }

            return this.transactions.Where(x => x.From == sender).OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!this.transactions.Any(x => x.Status == status))
            {
                throw new InvalidOperationException("Transactions with such status does not exist!");
            }

            return this.transactions.Where(x => x.Status == status).OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.transactions.Where(x => x.Status == status && x.Amount <= amount).OrderByDescending(x => x.Amount);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(x => x.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException("Cannot remove transaction that does not exists!");
            }

            this.transactions.Remove(transaction);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
