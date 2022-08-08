using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Balance
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountHolderName { get; set; }

        public double OverdraftLimit { get; set; }

        public double DailyWireTransferLimit { get; set; }

        public double Funds { get; set; }

        public string state { get; set; }

        public Account()
        {

        }

        public Account(int AccountId, string AccountHolderName, double OverdraftLimit, double DailyWireTransferLimit, double Funds, string state)
        {
            this.AccountId = AccountId;
            this.AccountHolderName = AccountHolderName;
            this.OverdraftLimit = OverdraftLimit;
            this.DailyWireTransferLimit = DailyWireTransferLimit;
            this.Funds = Funds;
            this.state = state;
        }

        public double CashDeposit(double amount)
        {
            return Funds + amount;
        }

        public double CashWithdraw(double amount)
        {
            return Funds - amount;
        }

        public double WireTransfer(double wiredTransferedAmount)
        {
            if (wiredTransferedAmount <= DailyWireTransferLimit)
            {
                return Funds - wiredTransferedAmount;
            }
            else
            {
                state = "blocked";
                return Funds;
            }
        }

        public void Withdraw(double withdrawAmount)
        {
            if (Funds - withdrawAmount < -OverdraftLimit)
            {
                state = "blocked";
                Console.WriteLine($"you've reached the limits of {-OverdraftLimit} DT of your overdraft limit and you're account is in {state} state");
            }
            else
            {
                Funds -= withdrawAmount;
                Console.WriteLine(Funds);
            }

        }

        public void ChequeDeposit(double chequeAmount)
        {
            DateTime dateTime = DateTime.UtcNow;
            Console.WriteLine(dateTime);

            Queue queue = new Queue();
            queue.Enqueue(chequeAmount);
            foreach (var obj in queue)
                Console.WriteLine(obj);

            //deposit on weekend days
            if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("Cheque is in an pending mode. It will be deposit on business days");
            }
            else
            {
                if (dateTime.Hour > 09 && dateTime.Hour < 17)
                {
                    Funds += chequeAmount;
                    queue.Dequeue();
                }
                else
                // add to tomorrow
                {
                    Console.WriteLine("Cheque will be deposited on working hours");
                }
            }
        }
    }
}
