using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Account_Balance;

namespace UnitTestAccount
{
    [TestClass]
    public class UnitTestAccount
    {
        [TestMethod]
        public void CashDepositTest()
        {
            //Arrange
            Account account = new Account
            {
                AccountId = 417,
                AccountHolderName = "Amani",
                DailyWireTransferLimit = 1000,
                OverdraftLimit = 800,
                Funds = 1600,
                state = "unblocked"
            };

            double result = account.CashDeposit(200);

            //assert
            Assert.AreEqual(1800, result);

        }

        [TestMethod]
        public void CashWithdrawTest()
        {
            //Arrange
            Account account = new Account
            {
                AccountId = 415,
                AccountHolderName = "Rim",
                DailyWireTransferLimit = 1000,
                OverdraftLimit = 800,
                Funds = 1600,
                state = "unblocked"
            };

            double result = account.CashWithdraw(200);

            //assert
            Assert.AreEqual(1400, result);

        }

        [TestMethod]
        public void WireTransferTest()
        {
            //Arrange
            Account account = new Account
            {
                AccountId = 415,
                AccountHolderName = "Rim",
                DailyWireTransferLimit = 1000,
                OverdraftLimit = 800,
                Funds = 1600,
                state = "unblocked"
            };

            double result = account.WireTransfer(1000);

            //assert
            Assert.AreEqual(600, result);

        }

        [TestMethod]
        public void WithdrawTest()
        {
            //Arrange
            Account account = new Account
            {
                AccountId = 413,
                AccountHolderName = "Rami",
                DailyWireTransferLimit = 1000,
                OverdraftLimit = 500,
                Funds = 1000,
                state = "unblocked"
            };

            account.Withdraw(600);

            //assert
            Assert.AreEqual(400, account.Funds);

        }

        [TestMethod]
        public void ChequeDepositTest()
        {
            //Arrange
            Account account = new Account
            {
                AccountId = 413,
                AccountHolderName = "Rami",
                DailyWireTransferLimit = 1000,
                OverdraftLimit = 500,
                Funds = 1000,
                state = "unblocked"
            };

            account.ChequeDeposit(600);

            //assert
            Assert.AreEqual(1600, account.Funds);

        }
    }
}
