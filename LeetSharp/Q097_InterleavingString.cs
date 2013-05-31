using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.

// For example,
// Given:
// s1 = "aabcc",
// s2 = "dbbca",

// When s3 = "aadbbcbcac", return true.
// When s3 = "aadbbbaccc", return false.

namespace LeetSharp
{
    [TestClass]
    public class Q097_InterleavingString
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            return false;
        }

        public string SolveQuestion(string input)
        {
            return IsInterleave(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize(),
                input.GetToken(2).Deserialize()).ToString().ToLower();
        }

        [TestMethod]
        public void Q097_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q097_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
