﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class ValidatorTests
    {
        [TestMethod()]
        [DataRow(0, 0, 100)]
        [DataRow(100, 0, 100)]
        [DataRow(49.99, 0, 100)]
        [TestCategory("Is Within Range")]
        public void IsValueWithinRangeTest_InclusiveRange_ReturnsTrue(double value, 
                                                                      double minValue, 
                                                                      double maxValue)
        {
            // Check if the given value is within the given range
            bool result = Validator.IsValueWithinRange(value, minValue, maxValue);

            // See if the result was True
            Assert.IsTrue(result);
        }
    }
}