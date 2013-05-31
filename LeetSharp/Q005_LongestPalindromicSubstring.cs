using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a string S, find the longest palindromic substring in S. 
// You may assume that the maximum length of S is 1000, and there exists one unique longest palindromic substring.

namespace LeetSharp
{
    [TestClass]
    public class Q005_LongestPalindromicSubstring
    {
        string LongestPalindrome(string input)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + LongestPalindrome(input.Deserialize()) + "\"";
        }

        [TestMethod]
        public void Q005_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q005_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
