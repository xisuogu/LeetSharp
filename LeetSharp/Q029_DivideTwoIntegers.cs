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
            return -1;
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
