using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Divide two integers without using multiplication, division and mod operator.

namespace LeetSharp
{
    [TestClass]
    public class Q029_DivideTwoIntegers
    {
        public int Divide(int dividend, int divisor)
        {
            bool neg = false;
            long a = dividend;
            long b = divisor;
            int answer = 0;
            if (a < 0)
            {
                b = 0 - b;
                a = 0 - a;
            }
            if (b < 0)
            {
                b = 0 - b;
                neg = true;
            }
            int shift = 0;
            while (b << shift < a)
            {
                shift++;
            }
            // now b<<shift >= a
            while (shift >= 0)
            {
                if (b << shift <= a)
                {
                    answer |= 1 << shift;
                    a -= b << shift;
                }
                shift--;
            }
            return neg ? 0 - answer : answer;
        }

        public string SolveQuestion(string input)
        {
            return Divide(input.GetToken(0).ToInt(), input.GetToken(1).ToInt()).ToString();
        }

        [TestMethod]
        public void Q029_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q029_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
