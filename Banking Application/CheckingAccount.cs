using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    internal class CheckingAccount : Account, ITransaction
    {
        private const decimal COST_PER_TRANSACTION = 0.05m;
        private const decimal INTEREST_RATE = 0.005m;
        private bool hasOverdraft;

        public CheckingAccount(decimal balance = 0, bool hasOverdraft = false)
            : base("CK-", balance)
        {
            this.hasOverdraft = hasOverdraft;
        }

        public new void Deposit(decimal amount, Person person)
        {
            base.Deposit(amount, person);
            //OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }

        public void Withdraw(decimal amount, Person person)
        {
            if (!users.Contains(person))
                throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);

            if (!person.IsAuthenticated)
                throw new AccountException(ExceptionType.USER_NOT_LOGGED_IN);

            if (Balance - amount < 0 && !hasOverdraft)
                throw new AccountException(ExceptionType.NO_OVERDRAFT_FOR_THIS_ACCOUNT);

            base.Deposit(-amount, person);
            //OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, true));
        }

        public override void PrepareMonthlyReport()
        {
            decimal serviceCharge = transactions.Count * COST_PER_TRANSACTION;
            decimal interest = (LowestBalance * INTEREST_RATE) / 12;

            Balance += interest - serviceCharge;
            transactions.Clear();
        }
    }
}
