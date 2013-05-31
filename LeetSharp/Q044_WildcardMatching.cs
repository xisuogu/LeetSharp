using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// '?' Matches any single character.
// '*' Matches any sequence of characters (including the empty sequence).

// The matching should cover the entire input string (not partial).

// The function prototype should be:
// bool isMatch(const char *s, const char *p)

// Some examples:
// isMatch("aa","a") ? false
// isMatch("aa","aa") ? true
// isMatch("aaa","aa") ? false
// isMatch("aa", "*") ? true
// isMatch("aa", "a*") ? true
// isMatch("ab", "?*") ? true
// isMatch("aab", "c*a*b") ? false

namespace LeetSharp
{
    [TestClass]
    public class Q044_WildcardMatching
    {
        public bool IsMatch(string input, string pattern)
        {
            return false;
        }

        public string SolveQuestion(string input)
        {
            return IsMatch(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()).ToString().ToLower();
        }

        [TestMethod]
        public void Q044_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q044_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
