using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public abstract class Account
    {
        private static int LAST_NUMBER = 100_000;
        protected readonly List<Person> users = new List<Person>();
        public readonly List<Transaction> transactions = new List<Transaction>();
        public event EventHandler OnTransaction;

        public string Number { get; }
        public decimal Balance { get; protected set; }
        public decimal LowestBalance { get; protected set; }

        public Account(string type, decimal balance)
        {
            Number = $"{type}{LAST_NUMBER++}";
            Balance = balance;
            LowestBalance = balance;
        }
        public void Deposit(decimal amount, Person person)
        {
            Balance += amount;
            if (Balance < LowestBalance)
                LowestBalance = Balance;

            transactions.Add(new Transaction(Number, amount, person, Utils.Now));
            OnTransaction(this, new EventArgs());
        }

        public void AddUser(Person person)
        {
            users.Add(person);
        }

        public bool IsUser(string name)
        {
            foreach (Person p in users) 
            {
                if (name == p.Name)
                { 
                    return true;
                }
            }
            return false;
        }

        public abstract void PrepareMonthlyReport();

        public virtual void OnTransactionOccur(object sender, EventArgs e)
        {
            OnTransaction?.Invoke(sender, e);
        }

        public override string ToString() 
        { 
            return $"{Number} {string.Join(", ",users)} {Balance:C} \n{string.Join("\n    ", transactions)}";
        }
    }
}
