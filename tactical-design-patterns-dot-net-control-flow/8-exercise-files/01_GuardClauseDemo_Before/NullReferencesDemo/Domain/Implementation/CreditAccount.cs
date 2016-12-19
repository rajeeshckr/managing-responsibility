using System;
using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Domain.Implementation
{
    public class CreditAccount: AccountBase
    {

        private readonly IList<MoneyTransaction> pendingTransactions = new List<MoneyTransaction>();

        private readonly bool strictTransactionOrder;

        public CreditAccount(bool strictTransactionsOrder)
        {
            this.strictTransactionOrder = strictTransactionsOrder;
        }

        public override decimal Balance
        {
            get
            {
                return base.Balance + this.pendingTransactions.Sum(trans => trans.Amount);
            }
        }

        public override Option<MoneyTransaction> TryWithdraw(decimal amount)
        {

            if (amount <= 0)
                throw new ArgumentException("Amount to withdraw must be positive.", nameof(amount));

            MoneyTransaction transaction = new MoneyTransaction(-amount);

            if (this.Balance >= amount)
                base.RegisterTransaction(transaction);
            else
                this.pendingTransactions.Add(transaction);

            return Option<MoneyTransaction>.Create(transaction);

        }

        public override MoneyTransaction Deposit(decimal amount)
        {

            if (amount <= 0)
                throw new ArgumentException("Amount to deposit must be positive.", nameof(amount));

            MoneyTransaction transaction = new MoneyTransaction(amount);
            base.RegisterTransaction(transaction);

            this.ProcessPendingWithdrawals();
            
            return transaction;

        }

        private void ProcessPendingWithdrawals()
        {

            Option<MoneyTransaction> option = Option<MoneyTransaction>.CreateEmpty();

            do
            {
                option = this.TrySelectPendingTransaction();
                ProcessPendingWithdrawal(option);
            }
            while (option.Any());

        }

        private Option<MoneyTransaction> TrySelectPendingTransaction()
        {
            if (this.strictTransactionOrder)
                return this.TrySelectFirstPendingTransaction();
            else
                return this.TrySelectConformingPendingTransaction();
        }

        private void ProcessPendingWithdrawal(Option<MoneyTransaction> option)
        {

            if (!option.Any())
                return;

            MoneyTransaction transaction = option.Single();

            base.RegisterTransaction(transaction);
            this.pendingTransactions.Remove(transaction);

        }

        private Option<MoneyTransaction> TrySelectFirstPendingTransaction()
        {

            if (!this.pendingTransactions.Any())
                return Option<MoneyTransaction>.CreateEmpty();

            MoneyTransaction candidate = this.pendingTransactions.First();

            if (base.Balance + candidate.Amount < 0)
                return Option<MoneyTransaction>.CreateEmpty();

            return Option<MoneyTransaction>.Create(candidate);

        }

        private Option<MoneyTransaction> TrySelectConformingPendingTransaction()
        {
            return
                this.pendingTransactions
                    .Where(trans => base.Balance + trans.Amount >= 0)
                    .Take(1)
                    .Select(trans => Option<MoneyTransaction>.Create(trans))
                    .DefaultIfEmpty(Option<MoneyTransaction>.CreateEmpty())
                    .Single();
        }

    }
}
