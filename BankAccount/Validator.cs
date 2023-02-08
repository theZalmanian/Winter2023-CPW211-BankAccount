using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankAccount
{
    public static class Validator
    {
        /// <summary>
        /// Checks if the given value is within the given range (inclusive)
        /// </summary>
        /// <param name="value">The number to be checked</param>
        /// <param name="minValue">The lowest number in the range</param>
        /// <param name="maxValue">The highest number in the range</param>
        /// <returns>True if number is within given range; otherwise False</returns>
        public static bool IsValueWithinRange(double value, double minValue, double maxValue)
        {
            // Check if number is within range
            if (value >= minValue && value <= maxValue)
            {
                return true;
            }

            // Otherwise
            return false;
        }
    }
}
