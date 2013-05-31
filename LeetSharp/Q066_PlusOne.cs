using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a number represented as an array of digits, plus one to the number.

namespace LeetSharp
{
    [TestClass]
    public class Q066_PlusOne
    {
        public int[] PlusOne(int[] digits)
        {
            digits = digits.Reverse().ToArray();
            List<int> res = new List<int>();
            int carry = 1;
            for (int i = 0; i < digits.Length; i++)
            {
                int newNumber = digits[i] + carry;
                res.Add(newNumber % 10);
                carry = newNumber / 10;
            }
            if (carry > 0)
            {
                res.Add(carry);
            }
            res.Reverse();
            return res.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(PlusOne(input.ToIntArray()));
        }

        [TestMethod]
        public void Q066_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q066_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
