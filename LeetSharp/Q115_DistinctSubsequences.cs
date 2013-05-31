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
        // dp[x, y] means NumDistinct(src.SubString(0, x), tgt.SubString(0, y))
        // then dp[x, 0] = 1
        // dp[x, y] = src[x-1] == tgt[y-1] ? dp[x-1, y-1] + dp[x-1, y] : dp[x-1, y]
        // dp[0, 0] = 1
        // if y > x then dp[x, y] = 0, so: dp[y, y] = src[y-1] == tgt[y-1] ? dp[y-1, y-1] : 0
        // To reduce memory, layer by layer, just need to keep 1 row (staring from (x, 0))
        public int NumDistinct(string src, string tgt)
        {
            int srcLength = src.Length;
            int targetLength = tgt.Length;
            if (srcLength < targetLength)
            {
                return 0;
            }
            int[] dp = new int[src.Length + 1];
            for (int i = 0; i <= src.Length; i++)
            {
                dp[i] = 1; // dp[x, 0] = 1;
            }
            // compute row by row
            for (int r = 1; r <= tgt.Length; r++)
            {
                int tmp = dp[r-1]; // store dp[x-1, y-1]
                dp[r - 1] = 0; // dp[y-1, y] = 0
                for (int c = r; c <= src.Length; c++)
                {
                    if (src[c - 1] == tgt[r - 1]) // dp[x, y] = dp[x-1, y-1] + dp[x-1, y]
                    {
                        int nextTmp = dp[c];
                        dp[c] = tmp + dp[c - 1];
                        tmp = nextTmp;
                    }
                    else // dp[x, y] = dp[x-1, y]
                    {
                        tmp = dp[c];
                        dp[c] = dp[c - 1];
                    }
                }
            }
            return dp[src.Length];
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
