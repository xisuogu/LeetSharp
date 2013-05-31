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
            // dp[i, j] means s[i]..s[j] is palindrome
            int inputLength = input.Length;
            char[] inputArr = input.ToCharArray();
            bool[,] dp = new bool[inputLength, inputLength];
            int answerStartIndex = 0;
            int answerLength = 1;
            for (int s = inputLength - 2; s >= 0; s--)
            {
                for (int e = s + 1; e < inputLength; e++)
                {
                    if (inputArr[s] == inputArr[e])
                    {
                        if (e - s <= 2 || dp[s + 1, e - 1])
                        {
                            dp[s, e] = true;
                            if (answerLength < e - s + 1)
                            {
                                answerLength = e - s + 1;
                                answerStartIndex = s;
                            }
                        }
                    }
                }
            }
            return input.Substring(answerStartIndex, answerLength);
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
