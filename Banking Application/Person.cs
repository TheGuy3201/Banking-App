using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class Person
    {
        private string password;
        public event EventHandler OnLogin;

        public string Sin { get; }
        public string Name { get; }
        public bool IsAuthenticated { get; private set; }

        public Person(string name, string sin)
        {
            Name = name;
            Sin = sin;
        }
    }
}
