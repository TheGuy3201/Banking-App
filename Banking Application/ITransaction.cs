using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    
    interface ITransaction //if I make a class its different (replace interface with class :moyai:
    {
        void Withdraw(decimal amount, Person person);
        void Deposit(decimal amount, Person person);
        
        /*All I had to do is simply remove the brackets. Why?:
         *Since we're working with interfaces, we only just need to declare methods
         *The reason why is because the Account Classes look back on this interface to use
         *I'll be proved wrong later when it matters, but think of it as a constant, but your applying it to a whole class- 
         *so henceforth, its a interface.
         */

    }
}
