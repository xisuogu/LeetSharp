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
            long a = (long)dividend;
            long b = (long)divisor;

            bool neg = Math.Sign(a) != Math.Sign(b);
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (b == 1)
                return neg ? 0 - (int)a : (int)a;

            int shift = 0;
            while (b << shift < a)
            {
                shift++;
            }

            long result = 1L << shift;
            long sum = b * result;
            while (sum > a)
            {
                sum -= b;
                result--;
            }

            return neg ? 0 - (int)result : (int)result;
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
