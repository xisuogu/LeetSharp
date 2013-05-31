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
            if (s1.Length + s2.Length != s3.Length)
            {
                return false;
            }
            if (new string((s1 + s2).OrderBy(c => c).ToArray()) != new string(s3.OrderBy(c => c).ToArray()))
            {
                return false;
            }
            bool?[,] dp = new bool?[s1.Length, s2.Length];
            return IsInterleaveDP(s1, s2, s3, 0, 0, dp);
        }

        private bool IsInterleaveDP(string s1, string s2, string s3, int indexS1, int indexS2, bool?[,] dp)
        {
            while (true)
            {
                int indexS3 = indexS1 + indexS2;
                if (indexS1 == s1.Length)
                {
                    bool res =  s2.Substring(indexS2) == s3.Substring(indexS3);
                    return res;
                }
                if (indexS2 == s2.Length)
                {
                    bool res = s1.Substring(indexS1) == s3.Substring(indexS3);
                    return res;
                }

                if (dp[indexS1, indexS2].HasValue)
                {
                    return dp[indexS1, indexS2].Value;
                }
                char curChar = s3[indexS3];
                if (curChar == s1[indexS1] && curChar == s2[indexS2])
                {
                    bool res = IsInterleaveDP(s1, s2, s3, indexS1 + 1, indexS2, dp) ||
                        IsInterleaveDP(s1, s2, s3, indexS1, indexS2 + 1, dp);
                    dp[indexS1, indexS2] = res;
                    return res;
                }
                else if (curChar == s1[indexS1])
                {
                    indexS1++;
                }
                else if (curChar == s2[indexS2])
                {
                    indexS2++;
                }
                else
                {
                    dp[indexS1, indexS2] = false;
                    return false;
                }
            }
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
