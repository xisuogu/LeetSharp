using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given two binary strings, return their sum (also a binary string).

// For example,
// a = "11"
// b = "1"
// Return "100".

namespace LeetSharp
{
    [TestClass]
    public class Q067_AddBinary
    {
        public string AddBinary(string a, string b)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + AddBinary(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()) + "\"";
        }

        [TestMethod]
        public void Q067_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q067_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
