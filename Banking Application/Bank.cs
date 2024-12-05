using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Web.Script.Serialization;

namespace Banking_Application
{
    public static class Bank
    {
        public static readonly Dictionary<string, Account> ACCOUNTS = new Dictionary<string, Account>();
        public static readonly Dictionary<string, Person> USERS = new Dictionary<string, Person>();

        static Bank()
        {
            //Copy and pasted code from proffesor
             //initialize the USERS collection
               AddUser("Narendra", "1234-5678");    //0
               AddUser("Ilia", "2345-6789");        //1
               AddUser("Mehrdad", "3456-7890");     //2
               AddUser("Vinay", "4567-8901");       //3
               AddUser("Arben", "5678-9012");       //4
               AddUser("Patrick", "6789-0123");     //5
               AddUser("Yin", "7890-1234");         //6
               AddUser("Hao", "8901-2345");         //7
               AddUser("Jake", "9012-3456");        //8
               AddUser("Mayy", "1224-5678");        //9
               AddUser("Nicoletta", "2344-6789");   //10


               //initialize the ACCOUNTS collection
               AddAccount(new VisaAccount());              //VS-100000
               AddAccount(new VisaAccount(150, -500));     //VS-100001
               AddAccount(new SavingAccount(5000));        //SV-100002
               AddAccount(new SavingAccount());            //SV-100003
               AddAccount(new CheckingAccount(2000));      //CK-100004
               AddAccount(new CheckingAccount(1500, true));//CK-100005
               AddAccount(new VisaAccount(50, -550));      //VS-100006
               AddAccount(new SavingAccount(1000));        //SV-100007 

               //associate users with accounts
               string number = "VS-100000";
               AddUserToAccount(number, "Narendra");
               AddUserToAccount(number, "Ilia");
               AddUserToAccount(number, "Mehrdad");

               number = "VS-100001";
               AddUserToAccount(number, "Vinay");
               AddUserToAccount(number, "Arben");
               AddUserToAccount(number, "Patrick");

               number = "SV-100002";
               AddUserToAccount(number, "Yin");
               AddUserToAccount(number, "Hao");
               AddUserToAccount(number, "Jake");

               number = "SV-100003";
               AddUserToAccount(number, "Mayy");
               AddUserToAccount(number, "Nicoletta");

               number = "CK-100004";
               AddUserToAccount(number, "Mehrdad");
               AddUserToAccount(number, "Arben");
               AddUserToAccount(number, "Yin");

               number = "CK-100005";
               AddUserToAccount(number, "Jake");
               AddUserToAccount(number, "Nicoletta");

               number = "VS-100006";
               AddUserToAccount(number, "Vinay");

               number = "SV-100007";
               AddUserToAccount(number, "Patrick");
               AddUserToAccount(number, "Hao");

        }
        public static void SaveAccounts(string filename)
        {
         string savedAccount = new JavaScriptSerializer().Serialize(ACCOUNTS);
         File.WriteAllText(filename, savedAccount);
        }
        public static void SaveUsers(string filename) 
        {
         string savedUser = new JavaScriptSerializer().Serialize(USERS);
         File.WriteAllText(filename, savedUser);
        }
        public static Person GetUser(string name) 
        {
            if (USERS.TryGetValue(name, out Person user))
            {  return user; }
            else
            { throw new AccountException(ExceptionType.USER_DOES_NOT_EXIST); }
       
        }
        public static Account GetAccount(string number)
        {
            if (ACCOUNTS.TryGetValue(number, out Account account))
            { return account; }
            else
            { throw new AccountException(ExceptionType.ACCOUNT_DOES_NOT_EXIST); }

        }
        public static void AddUser(string name, string sin) 
        {
            Person user = new Person(name, sin);
            user.OnLogin += Logger.LoginHandler;
            USERS.Add(name, user);
        }
        public static void AddAccount(Account account) 
        {
            account.OnTransaction += Logger.TransactionHandler;
            ACCOUNTS.Add(account.Number, account);
        }

        public static void AddUserToAccount(string number, string name) 
        {
            if (ACCOUNTS.TryGetValue(number, out var account))
                //throw new AccountException(ExceptionType.ACCOUNT_DOES_NOT_EXIST);

            if (USERS.TryGetValue(name, out var user))
                //throw new AccountException(ExceptionType.USER_DOES_NOT_EXIST);

            account.AddUser(user);
        }

        
       
    }
}
