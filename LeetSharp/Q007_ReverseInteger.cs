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
            int result = 0;
            int flag = x < 0 ? -1 : 1;

            x = Math.Abs(x);
            while (x > 0)
            {
                result = x % 10 + result * 10;
                x = x / 10;
            }

            return flag * result;
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
