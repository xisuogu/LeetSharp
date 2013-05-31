using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Implement pow(x, n).

namespace LeetSharp
{
    [TestClass]
    public class Q050_PowXN
    {
        public double Pow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            if (x == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return x;
            }
            bool neg = false;
            if (n < 0)
            {
                n = 0 - n;
                neg = true;
            }
            // Pow(x, n) = Pow(x, n/2) * Pow(x, n/2) * Pow(x, n%2)
            double result = Pow(x, n / 2);
            result *= result;
            result *= Pow(x, n % 2);
            if (neg)
            {
                result = 1 / result;
            }
            return result;
        }

        public string SolveQuestion(string input)
        {
            return Pow(input.GetToken(0).ToDouble(), input.GetToken(1).ToInt()).ToString("f5");
        }

        [TestMethod]
        public void Q050_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q050_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
