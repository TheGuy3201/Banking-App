using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class TransactionEventArgs : LoginEventArgs
    {
        public decimal Amount { get; }
        public TransactionEventArgs(string name, decimal amount, bool success)
            : base (name, success)
        {
            Amount = amount;
        }
    }
}
