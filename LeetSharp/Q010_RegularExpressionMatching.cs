using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Implement regular expression matching with support for '.' and '*'.

// '.' Matches any single character.
// '*' Matches zero or more of the preceding element.

// The matching should cover the entire input string (not partial).

// The function prototype should be:
// bool isMatch(const char *s, const char *p)

// Some examples:
// isMatch("aa","a") ? false
// isMatch("aa","aa") ? true
// isMatch("aaa","aa") ? false
// isMatch("aa", "a*") ? true
// isMatch("aa", ".*") ? true
// isMatch("ab", ".*") ? true
// isMatch("aab", "c*a*b") ? true


namespace LeetSharp
{
    [TestClass]
    public class Q010_RegularExpressionMatching
    {
        public bool IsMatch(string input, string pattern)
        {
            return false;
        }

        public string SolveQuestion(string input)
        {
            return IsMatch(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize())
                .ToString().ToLower();
        }

        [TestMethod]
        public void Q010_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q010_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
