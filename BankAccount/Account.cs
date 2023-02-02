using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single customer's bank account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// The full legal name of the account holders
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// The amount of money stored in the account
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Creates an account with the given owner, and a default balance of 0
        /// </summary>
        /// <param name="accountOwner">The full legal name of the customer who owns the account</param>
        public Account(string accountOwner) 
        {
            Owner = accountOwner;
        }

        /// <summary>
        /// Adds a specified amount of money to the account, and returns the updated balance
        /// </summary>
        /// <param name="depositAmount">The positive amount to deposit into the account</param>
        /// <returns>The updated balance after the deposit was made</returns>
        public double Deposit(double depositAmount)
        {
            // Make sure deposit amount is more than zero
            if(depositAmount <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(depositAmount)} must be more than 0");
            }

            // Add the given amount to the balance
            Balance += depositAmount;  
            
            // Return the balance
            return Balance;
        }

        /// <summary>
        /// Removes a specified amount of money from the account, as long as that amount is present in the account,
        /// and returns the updated balance
        /// </summary>
        /// <param name="withdrawlAmount">The positive amount to withdraw from the account balance</param>
        /// <returns>The updated balance after the withdrawal was made</returns>
        public double Withdraw(double withdrawalAmount)
        {
            // Withdraw the specified amount
            Balance -= withdrawalAmount;

            // Return the balance
            return Balance;
        }
    }
}
