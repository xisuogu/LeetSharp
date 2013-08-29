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
            int carry = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i] += carry;
                carry = digits[i] / 10;
                digits[i] %= 10;
            }
            if (carry != 0)
            {
                List<int> digitList = digits.ToList();
                digitList.Insert(0, carry);
                digits = digitList.ToArray();
            }

            return digits;
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
