﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public class AccountException : Exception
    {
        public AccountException(ExceptionType reason) : base(reason.ToString())
        { }
    }
}
