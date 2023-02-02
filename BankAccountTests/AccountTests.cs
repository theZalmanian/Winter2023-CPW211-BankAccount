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
        [TestMethod]
        public void Deposit_APositiveAmount_AddToBalance()
        {
            // Create a test account
            Account testAccount = new("Reality Undefined");

            // Deposit $100 into the account
            testAccount.Deposit(100);

            // Check if the deposit was successful
            Assert.AreEqual(100, testAccount.Balance);
        }

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA - Arrange, Act, Assert

            // Arrange
            // Create a test account
            Account testAccount = new("Reality Undefined");

            // Setup deposit amount, and expected return amount
            double depositAmount = 100;
            double expectedReturn = 100;

            // Act
            // Deposit $100 into the account
            double returnValue = testAccount.Deposit(100);

            // Assert 
            // Make sure the return value was $100
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        public void Deposit_ZeroOrLess_ThrowsArgumentException()
        {
            // Arrange
            // Create a test account
            Account testAccount = new("Reality Undefined");

            // Setup deposit amount
            double invalidDepositAmount = -1;

            // Assert => Act
            // Attempt to deposit $-1 into the account
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => testAccount.Deposit(invalidDepositAmount));
        }
    }
}