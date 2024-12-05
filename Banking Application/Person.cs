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
        public event EventHandler <LoginEventArgs> OnLogin;

        public string Sin { get; }
        public string Name { get; }
        public bool IsAuthenticated { get; private set; }

        public Person(string name, string sin)
        {
            Name = name;
            Sin = sin;
            password = sin.Substring(0,2);
        }

        public void Login(string pass)
        {
            if(pass != password)
            {
                IsAuthenticated = false;
                OnLogin(this, new LoginEventArgs(this.Name, IsAuthenticated));
                throw new AccountException(ExceptionType.PASSWORD_INCORRECT);
            }
            else if(pass == password)
            {
                IsAuthenticated = true;
                OnLogin(this, new LoginEventArgs(this.Name, IsAuthenticated));
            }
        }

        public void Logout()
        {
            IsAuthenticated = false;
        }

        public override string ToString()
        {
            return $"Username: {Name} {(IsAuthenticated ? "is authenticated!" : "isn't authenticated.")}";
        }
    }
}
