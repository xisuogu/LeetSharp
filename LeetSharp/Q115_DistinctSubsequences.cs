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
        // This is a difficult problem , hard to understand DP solution 
        public int NumDistinct(string src, string tgt)
        {
            int[] dp = new int[tgt.Length + 1];
            dp[0] = 1;
            
            for (int i = 1; i <= src.Length; i++)
            {
                for (int j = tgt.Length; j >= 1; j--)
                {
                    if (src[i - 1] == tgt[j - 1])
                    {
                        dp[j] += dp[j - 1];
                    }
                }
            }
            return dp[tgt.Length];
        }

        public int NumDistinct_DP2(string src, string tgt)
        {
            int[,] dp = new int[src.Length + 1, tgt.Length + 1];

            for (int j = 0; j <= tgt.Length; j++)
                dp[0, j] = 0;

            for (int i = 0; i <= src.Length; i++)
                dp[i, 0] = 1;

            for (int i = 1; i <= src.Length; i++)
            {
                for (int j = 1; j <= tgt.Length; j++)
                {
                    if (src[i - 1] == tgt[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }
            return dp[src.Length, tgt.Length];
        }

        public int NumDistinct_Rec(string src, string tgt)
        {
            if (tgt == string.Empty) // notice, this condition check need to happen first 
                return 1;

            if (src == string.Empty || src.Length < tgt.Length)
                return 0;

            if (src[0] == tgt[0])
            {
                return NumDistinct_Rec(src.Substring(1), tgt)
                    + NumDistinct_Rec(src.Substring(1), tgt.Substring(1));
            }
            else if (src.Length > tgt.Length)
            {
                return NumDistinct_Rec(src.Substring(1), tgt);
            }
            else
            {
                return 0;
            }
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
