using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.UI.WebControls;

namespace Banking_Application
{
    static class Logger
    {
        private static List<string> loginEvents = new List<string>();
        private static List<string> transactionEvents = new List<string>();

        public static void LoginHandler(object sender, LoginEventArgs args)
        {
            LoginEventArgs loginArgs = args as LoginEventArgs;
            if (loginArgs != null)
            {
                string logEntry = $"Person: {loginArgs.PersonName}, Success: {loginArgs.Success}, Time: {Utils.Now}";
                loginEvents.Add(logEntry);
            }
        }
        public static void TransactionHandler(object sender, EventArgs args)
        {
            TransactionEventArgs transactionArgs = args as TransactionEventArgs;
            if (transactionArgs != null)
            {
                string operation;
                string logEntry = $"Person: {transactionArgs.PersonName} Amount: {transactionArgs.Amount} Operation: {operation = (transactionArgs.Amount > 0 ? "deposited" : "withdrawn")} Success: {transactionArgs.Success} Time: {Utils.Now}";
                transactionEvents.Add(logEntry);
            }
        }
        public static void ShowLoginEvents(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine($"Log Time: {Utils.Now}");
                for (int i = 0; i < loginEvents.Count; i++)
                {
                    writer.WriteLine($"{i + 1}. {loginEvents[i]}");
                }
            }
        }
        public static void ShowTransactionEvents()
        {
            Console.WriteLine(Utils.Now);
            for (int i = 0; i < loginEvents.Count; i++)
            {

                Console.WriteLine($"{i + 1}. {transactionEvents[i]}");
            }
        }
    }
}
