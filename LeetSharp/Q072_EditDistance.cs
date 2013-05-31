using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2. 
// (each operation is counted as 1 step.)

// You have the following 3 operations permitted on a word:

// a) Insert a character
// b) Delete a character
// c) Replace a character

namespace LeetSharp
{
    [TestClass]
    public class Q072_EditDistance
    {
        // dynamic programing
        // dp[i, j] = MinDistance(word1.SubString(0, i), word2.SubString(0, j))
        // dp[i, j] = Min[ (dp[i-1, j] +1), (dp[i, j-1] +1), (dp[i-1, j-1] + 0 or 1)]
        // return dp[word1.Length, word2.Length]
        public int MinDistance(string word1, string word2)
        {
            int[,] dp = new int[word1.Length + 1, word2.Length + 1];
            for (int i = 0; i < word1.Length + 1; i++)
            {
                dp[i, 0] = i;
            }
            for (int i = 0; i < word2.Length + 1; i++)
            {
                dp[0, i] = i;
            }
            for (int w1 = 1; w1 <= word1.Length; w1++)
            {
                for (int w2 = 1; w2 <= word2.Length; w2++)
                {
                    int zeroOrOne = (word1[w1 - 1] == word2[w2 - 1]) ? 0 : 1;
                    dp[w1, w2] = Math.Min(dp[w1 - 1, w2] + 1, dp[w1, w2 - 1] + 1);
                    dp[w1, w2] = Math.Min(dp[w1, w2], dp[w1 - 1, w2 - 1] + zeroOrOne);
                }
            }
            return dp[word1.Length, word2.Length];
        }

        public string SolveQuestion(string input)
        {
            return MinDistance(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()).ToString();
        }

        [TestMethod]
        public void Q072_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q072_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
