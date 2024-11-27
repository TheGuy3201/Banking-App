using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class LoginEventArgs : EventArgs
    {
        //Properties
        public string PersonName { get; }
        public bool Success { get; }

        //Methods
        public LoginEventArgs(string personName, bool success) : base()
        {
            PersonName = personName;
            Success = success;
        }
    }
}
