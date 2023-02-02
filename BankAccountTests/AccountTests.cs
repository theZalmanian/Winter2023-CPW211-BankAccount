using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass]
    public class AccountTests
    {
        /// <summary>
        /// The default test account
        /// </summary>
        private Account testAccount;

        /// <summary>
        /// Initializes the default test account
        /// </summary>
        [TestInitialize]
        public void CreateDefaultAccount()
        {
            testAccount = new("Reality Redefined");
        }

        [TestMethod]
        [DataRow(9_999.99)]
        [DataRow(100)]
        [DataRow(1.99)]
        [DataRow(.01)]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            // Deposit $100 into the test account
            testAccount.Deposit(depositAmount);

            // Check if the deposit was successful
            Assert.AreEqual(depositAmount, testAccount.Balance);
        }

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // Setup deposit amount, and expected return amount
            double depositAmount = 100;
            double expectedReturnValue = 100;

            // Act
            // Deposit $100 into the test account
            double returnValue = testAccount.Deposit(depositAmount);

            // Assert 
            // Make sure the return value was $100
            Assert.AreEqual(expectedReturnValue, returnValue);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Assert => Act
            // Attempt to deposit $-1 into the test account
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => testAccount.Deposit(invalidDepositAmount));
        }
    }
}