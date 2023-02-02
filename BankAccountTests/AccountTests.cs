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
        [DataRow(100)]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance(double depositAmount)
        {
            // Setup expected return amount
            double expectedReturnAmount = 100;

            // Act
            // Deposit $100 into the test account
            double returnAmount = testAccount.Deposit(depositAmount);

            // Assert 
            // Make sure the return value was $100
            Assert.AreEqual(expectedReturnAmount, returnAmount);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentOutOfRangeException(double invalidDepositAmount)
        {
            // Assert => Act
            // Attempt to deposit $-1 into the test account
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => testAccount.Deposit(invalidDepositAmount));
        }

        [TestMethod]
        [DataRow(100, 50)]
        [DataRow(1000, 500)]
        public void Withdraw_PositiveAmount_DecreasesBalance(double depositAmount, double withdrawalAmount)
        {
            // Arrange
            // Setup expected balance
            double expectedBalance = depositAmount - withdrawalAmount;

            // Act
            // Deposit the specified amount
            testAccount.Deposit(depositAmount);

            // Withdraw the specified amount
            testAccount.Withdraw(withdrawalAmount);

            // Get the current balance
            double actualBalance = testAccount.Balance;

            // Assert
            // Check if the withdrawal was successful
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        [DataRow(100, 50)]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance()
        {
            Assert.Fail();
        }

        [TestMethod]
        [DataRow(-100)]
        [DataRow(-.01)]
        [DataRow(0)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double invalidWithdrawalAmount)
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            Assert.Fail();
        }
    }
}