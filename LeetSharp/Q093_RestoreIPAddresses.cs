using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string containing only digits, restore it by returning all possible valid IP address combinations.

// For example:
// Given "25525511135",

// return ["255.255.11.135", "255.255.111.35"]. (Order does not matter)

namespace LeetSharp
{
    [TestClass]
    public class Q093_RestoreIPAddresses
    {
        public string[] RestoreIpAddresses(string s)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(RestoreIpAddresses(input.Deserialize()));
        }

        [TestMethod]
        public void Q093_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q093_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
