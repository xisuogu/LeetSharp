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
        public bool IsFirstCharMatch(string input, string pattern)
        {
            return input.Length > 0 && (pattern[0] == input[0] || pattern[0] == '.');
        }

        public bool IsMatch(string input, string pattern)
        {
            if (pattern.Length == 0)
            {
                return input.Length == 0;
            }

            // next if is to process cases like "a" or "aab" 
            if (pattern.Length == 1 || pattern[1] != '*')
            {
                if (IsFirstCharMatch(input, pattern))
                {
                    return IsMatch(input.Substring(1), pattern.Substring(1));
                }
                else
                {
                    return false;
                }
            }

            // following 2 if is to process cases like "a*ab" or ".*ab" 
            if (IsMatch(input, pattern.Substring(2)))
            {
                return true;
            }

            if (IsFirstCharMatch(input, pattern))
            {
                return IsMatch(input.Substring(1), pattern);
            }

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
