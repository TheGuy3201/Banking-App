﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    
    internal interface ITransaction //if I make a class its different
    {
        void Withdraw(decimal amount, Person person)
        {
            
        }

        void Deposit(decimal amount, Person person)
        {

        }

    }
}
