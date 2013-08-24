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

            int numCnt = 1;
            while (Math.Pow(10, numCnt) < x)
            {
                numCnt++;
            }

            while (x > 9)
            {
                if (x % 10 != x / (int)Math.Pow(10, numCnt - 1))
                {
                    return false;
                }

                x = x % (int)Math.Pow(10, numCnt - 1);
                x = x / 10;

                numCnt -= 2;

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
