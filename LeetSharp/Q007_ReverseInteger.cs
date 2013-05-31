using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Reverse digits of an integer.

// Example1: x = 123, return 321
// Example2: x = -123, return -321

namespace LeetSharp
{
    [TestClass]
    public class Q007_ReverseInteger
    {
        public int ReverseInterger(int x)
        {
            int answer = 0;
            bool neg = x < 0;
            x = Math.Abs(x);
            while (x > 0)
            {
                int lastDigit = x % 10;
                answer = answer * 10 + lastDigit;
                x /= 10;
            }
            return neg ? 0 - answer : answer;
        }

        public string SolveQuestion(string input)
        {
            return ReverseInterger(input.ToInt()).ToString();
        }

        [TestMethod]
        public void Q007_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q007_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
