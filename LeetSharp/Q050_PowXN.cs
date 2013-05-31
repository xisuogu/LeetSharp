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
            return -1f;
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
