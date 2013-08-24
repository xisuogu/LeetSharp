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
            double result = 1f;
            bool negative = n < 0;
            n = negative ? 0 - n : n;

            result = PowRecursive(x, n);

            return negative ? 1f / result : result;
        }

        public double PowRecursive(double x, int n)
        {
            if (n == 0)
                return 1f;
            
            if (n == 1)
                return x;

            double result = PowRecursive(x, n / 2);
            result *= result;
            if (n % 2 == 1)
                result *= x;

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
