using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public class VisaAccount : Account, ITransaction
    {
        private decimal creditLimit;
        private static decimal INTEREST_RATE = 0.1995m;

        public VisaAccount(decimal balance = 0, decimal creditLimit = 1200)
            : base("VS- ", balance)
        { }   

        public void DoPayment(decimal amount, Person person)
        {
            base.Deposit(amount, person);
            base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }

        public void DoPurchase(decimal amount, Person person)
        {
            if (!users.Contains(person))
                throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);

            if (!person.IsAuthenticated)
                throw new AccountException(ExceptionType.USER_NOT_LOGGED_IN);

            if (amount > Balance+amount && amount > creditLimit)
                throw new AccountException(ExceptionType.NO_OVERDRAFT_FOR_THIS_ACCOUNT);

            base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, true));
            base.Deposit(-amount, person);
        }

        public override void PrepareMonthlyReport()
        {
            decimal interest = LowestBalance * INTEREST_RATE / 12;
            Balance -= interest;
            transactions.Clear();
        }

        public void Withdraw(decimal amount, Person person)
        { }
    }
}
