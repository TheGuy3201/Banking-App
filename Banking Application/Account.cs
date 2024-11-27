using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    internal abstract class Account
    {
        private static int LAST_NUMBER = 100_000;
        protected readonly List<Person> users = new List<Person>();
        public readonly List<Transaction> transactions = new List<Transaction>();
        public event EventHandler OnTransaction;


    }
}
