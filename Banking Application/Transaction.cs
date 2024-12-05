using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public struct Transaction
    {
        public string AccountNumber { get; }
        public decimal Amount { get; }
        public Person Originator { get; }
        public DayTime Time { get; }

        public Transaction(string accountNumber, decimal amount, Person person, DayTime time)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = time;
        }

        public override string ToString()
        {
            return $"    {AccountNumber} {Amount:C} {(Amount > 0 ? "deposited" : "withdrawn")} by {Originator.Name} on {Time}";
        }
    }
}
