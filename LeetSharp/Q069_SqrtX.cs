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
            return -1;
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
