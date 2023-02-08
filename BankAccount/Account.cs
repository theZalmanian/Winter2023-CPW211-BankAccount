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
        private string owner;

        /// <summary>
        /// The full legal name of the account holders
        /// </summary>
        public string Owner 
        {
            get { return owner; }
            set 
            { 
                // Make sure the given name is not null
                if(value == null)
                {
                    throw new ArgumentNullException($"{nameof(owner)} may not be null");
                }

                // Make sure the given name is not an empty string or white space
                if(value.Trim() == string.Empty)
                {
                    throw new ArgumentException($"{nameof(owner)} field may not be blank or composed of whitespace");
                }

                // If the given name is valid
                if(OwnerNameIsValid(value))
                {
                    // Set the account owner's name
                    owner = value; 
                }
                else
                {
                    throw new ArgumentException($"{nameof(owner)} can be up to 20 characters. No numbers or special characters allowed" );
                }
            } 
        }

        /// <summary>
        /// Checks if the given name is <= 20 characters, 
        /// and made up of only A - Z, along with whitespace
        /// </summary>
        /// <returns>True if the given name is valid; otherwise False</returns>
        private bool OwnerNameIsValid(string givenName)
        {
            throw new NotImplementedException();
        }

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
            if (depositAmount <= 0)
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
            // Make sure withdrawal amount is present in account
            if (withdrawalAmount > Balance)
            {
                throw new ArgumentException($"{nameof(withdrawalAmount)} cannot be greater than {nameof(Balance)}");
            }

            // Make sure withdrawal amount is more than zero
            if (withdrawalAmount <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(withdrawalAmount)} must be more than 0");
            }

            // Withdraw the specified amount
            Balance -= withdrawalAmount;

            // Return the balance
            return Balance;
        }
    }
}
