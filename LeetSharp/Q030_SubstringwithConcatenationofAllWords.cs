using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// You are given a string, S, and a list of words, L, that are all of the same length. 
// Find all starting indices of substring(s) in S that is a concatenation 
// of each word in L exactly once and without any intervening characters.

// For example, given:
// S: "barfoothefoobarman"
// L: ["foo", "bar"]

// You should return the indices: [0,9].
// (order does not matter).

namespace LeetSharp
{
    [TestClass]
    public class Q030_SubstringwithConcatenationofAllWords
    {
        public int[] FindSubstring(string s, string[] l)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(
                FindSubstring(input.GetToken(0).Deserialize(), input.GetToken(1).ToStringArray()));
        }

        [TestMethod]
        public void Q030_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q030_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
