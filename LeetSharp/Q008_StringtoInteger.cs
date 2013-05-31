using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Implement atoi to convert a string to an integer.

namespace LeetSharp
{
    [TestClass]
    public class Q008_StringtoInteger
    {
        public int Atoi(string str)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return Atoi(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q008_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q008_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
