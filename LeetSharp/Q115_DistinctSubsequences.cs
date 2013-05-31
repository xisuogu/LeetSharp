using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string S and a string T, count the number of distinct subsequences of T in S.

// A subsequence of a string is a new string which is formed from the original string by deleting some 
// (can be none) of the characters without disturbing the relative positions of the remaining characters. 
// (ie, "ACE" is a subsequence of "ABCDE" while "AEC" is not).

// Here is an example:
// S = "rabbbit", T = "rabbit"

// Return 3.

namespace LeetSharp
{
    [TestClass]
    public class Q115_DistinctSubsequences
    {
        public int NumDistinct(string src, string tgt)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return NumDistinct(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()).ToString();
        }

        [TestMethod]
        public void Q115_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q115_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
