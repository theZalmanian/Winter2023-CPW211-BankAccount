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
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            // Deposit the given amount into the test account
            testAccount.Deposit(depositAmount);

            // Check if the deposit was successful
            Assert.AreEqual(depositAmount, testAccount.Balance);
        }

        [TestMethod]
        [DataRow(100)]
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance(double depositAmount)
        {
            // Setup expected return amount
            double expectedReturnAmount = depositAmount;

            // Act
            // Deposit the given amount into the test account
            double returnAmount = testAccount.Deposit(depositAmount);

            // Assert 
            // Make sure the return value was as expected
            Assert.AreEqual(expectedReturnAmount, returnAmount);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [TestCategory("Deposit")]
        public void Deposit_ZeroOrLess_ThrowsArgumentOutOfRangeException(double invalidDepositAmount)
        {
            // Assert => Act
            // Attempt to deposit an invalid amount into the test account
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => testAccount.Deposit(invalidDepositAmount));
        }

        [TestMethod]
        [DataRow(100, 50)]
        [DataRow(125.17, 33.99)]
        [DataRow(1000, 500)]
        [TestCategory("Withdraw")]
        public void Withdraw_PositiveAmount_DecreasesBalance(double depositAmount, double withdrawalAmount)
        {
            // Arrange
            // Setup expected balance
            double expectedBalance = depositAmount - withdrawalAmount;

            // Deposit the specified amount
            testAccount.Deposit(depositAmount);

            // Act
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
        [DataRow(199.99, 50.31)]
        [TestCategory("Withdraw")]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance(double depositAmount, double withdrawalAmount)
        {
            // Arrange
            // Setup expected return amount
            double expectedReturnAmount = depositAmount - withdrawalAmount;

            // Deposit the specified amount
            testAccount.Deposit(depositAmount);

            // Act 
            // Withdraw the specified amount
            double returnAmount = testAccount.Withdraw(withdrawalAmount);

            // Assert
            // Make sure the return value was as expected
            Assert.AreEqual(expectedReturnAmount, returnAmount);
        }

        [TestMethod]
        [DataRow(-100)]
        [DataRow(-.01)]
        [DataRow(0)]
        [TestCategory("Withdraw")]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double invalidWithdrawalAmount)
        {
            // Assert => Act
            // Attempt to withdraw an invalid amount from the test account
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => testAccount.Withdraw(invalidWithdrawalAmount));
        }

        [TestMethod]
        [DataRow(10, 10.01)]
        [DataRow(10, 50)]
        [DataRow(1000, 5000)]
        [TestCategory("Withdraw")]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException(double depositAmount, double withdrawalAmount)
        {
            // Arrange
            // Deposit the specified amount
            testAccount.Deposit(depositAmount);

            // Assert => Act
            // Attempt to withdraw an unavailable amount from the test account
            Assert.ThrowsException<ArgumentException>
                (() => testAccount.Withdraw(withdrawalAmount));
        }

        [TestMethod]
        [TestCategory("Owner")]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            // Assert => Act
            // Attempt to set the test account's Owner name to null
            Assert.ThrowsException<ArgumentNullException>
                (() => testAccount.Owner = null);
        }

        [TestMethod]
        [TestCategory("Owner")]
        public void Owner_SetAsWhiteSpaceOrEmptyString_ThrowsArgumentException()
        {
            // Attempt to set the test account's Owner name as an empty string
            Assert.ThrowsException<ArgumentException>
                (() => testAccount.Owner = string.Empty);

            // Attempt to set the test account's Owner name as white space
            Assert.ThrowsException<ArgumentException>
                (() => testAccount.Owner = "   "); 
        }

        [TestMethod]
        [DataRow("Reality U")]
        [DataRow("Reality Undefined")]
        [DataRow("Reality Undefined Sr")]
        [TestCategory("Owner")]
        public void Owner_SetAsUpto20Characters_SetsSuccessfully(string givenName)
        {
            // Set the owner name of the test account as the given name
            testAccount.Owner = givenName;

            // Check if the name was set successfully
            Assert.AreEqual(givenName, testAccount.Owner);
        }

        [TestMethod]
        [TestCategory("Owner")]
        public void Owner_InvalidOwnerName_ThrowsArgumentException()
        {
            Assert.Fail();
        }
    }
}