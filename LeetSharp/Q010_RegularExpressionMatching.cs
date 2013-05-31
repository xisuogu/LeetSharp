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
            return IsMatch(input, 0, pattern);
        }

        private bool IsMatch(string input, int startIndex, string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return startIndex == input.Length;
            }
            if (startIndex > input.Length)
            {
                return false;
            }

            if (pattern.Length > 1 && pattern[1] == '*')
            {
                if (pattern[0] == '.' || (startIndex < input.Length && pattern[0] == input[startIndex]))
                {
                    if (IsMatch(input, startIndex + 1, pattern))
                    {
                        return true;
                    }
                }
                return IsMatch(input, startIndex, pattern.Substring(2)); // let * mean 0 occurence
            }

            if (pattern[0] == '.' || (startIndex < input.Length && pattern[0] == input[startIndex]))
            {
                return IsMatch(input, startIndex + 1, pattern.Substring(1));
            }
            else
            {
                return false;
            }
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
