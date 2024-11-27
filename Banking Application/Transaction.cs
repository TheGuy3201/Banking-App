using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    
    struct Transaction
    {
        public string AccountNumber { get; }
        public double Amount { get; }
        public Person Originator { get; }
        public DayTime Time { get; }

        public Transaction(string accountNumber, double amount, Person person, DayTime time)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = time;
        }

        public override string ToString()
        {
            return $"bs";
        }
    }
}
