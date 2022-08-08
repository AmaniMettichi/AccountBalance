using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(417, "Amani", 1000, 500, 1200, "unblocked");
            Console.WriteLine(account.Funds);
            account.ChequeDeposit(100);
            Console.WriteLine(account.Funds);


            Console.ReadLine();
        }
    }
}
