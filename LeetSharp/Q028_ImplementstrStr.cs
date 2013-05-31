using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Implement strStr().

// Returns a pointer to the first occurrence of needle in haystack, or null if needle is not part of haystack.

namespace LeetSharp
{
    [TestClass]
    public class Q028_ImplementstrStr
    {
        public string StrStr(string haystack, string needle)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return StrStr(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()).SerializeString();
        }

        [TestMethod]
        public void Q028_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q028_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
