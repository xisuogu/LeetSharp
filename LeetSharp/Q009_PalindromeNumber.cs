using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Determine whether an integer is a palindrome. Do this without extra space.

namespace LeetSharp
{
    [TestClass]
    public class Q009_PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            // get x's length in string
            int length = 1;
            while (Math.Pow(10, length) <= x)
            {
                length++;
            }
            while (length > 1)
            {
                // first digit and last digit
                int lastDigit = x % 10;
                int firstDigit = x / (int)Math.Pow(10, length - 1);
                if (lastDigit == firstDigit)
                {
                    x = x - (int)Math.Pow(10, length - 1) * firstDigit;
                    x /= 10;
                    length -= 2;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public string SolveQuestion(string input)
        {
            return IsPalindrome(input.ToInt()).ToString().ToLower();
        }

        [TestMethod]
        public void Q009_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q009_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
