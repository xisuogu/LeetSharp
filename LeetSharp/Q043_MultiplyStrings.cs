using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given two numbers represented as strings, return multiplication of the numbers as a string.

// Note: The numbers can be arbitrarily large and are non-negative.

namespace LeetSharp
{
    [TestClass]
    public class Q043_MultiplyStrings
    {
        public string Multiply(string num1, string num2)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + Multiply(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()) + "\"";
        }

        [TestMethod]
        public void Q043_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q043_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
