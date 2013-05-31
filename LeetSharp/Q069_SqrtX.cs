using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Implement int sqrt(int x).

// Compute and return the square root of x.

namespace LeetSharp
{
    [TestClass]
    public class Q069_SqrtX
    {
        public int Sqrt(int x)
        {
            if (x == 0)
            {
                return 0;
            }
            if (x < 4)
            {
                return 1;
            }
            long low = x >> 1;
            long high = low;
            while (low * low > x)
            {
                high = low;
                low = low >> 1;
            }
            if (low * low == x)
            {
                return (int)low;
            }
            while (high - low > 1)
            {
                long mid = (high + low) / 2;
                if (mid * mid > x)
                {
                    high = mid;
                }
                else if (mid * mid == x)
                {
                    return (int)mid;
                }
                else
                {
                    low = mid;
                }
            }
            return (int)low;
        }

        public string SolveQuestion(string input)
        {
            return Sqrt(input.ToInt()).ToString();
        }

        [TestMethod]
        public void Q069_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q069_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
