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
            int height = word1.Length;
            int width = word2.Length;
            int[,] matrix = new int[height + 1, width + 1];

            for (int i = 1; i <= height; i++)
                matrix[i, 0] = i;
            for (int j = 1; j <= width; j++)
                matrix[0, j] = j;

            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),                         
                        matrix[i - 1, j - 1] + (word1[i - 1] == word2[j - 1] ? 0 : 1));
                }
            }

            return matrix[height, width];
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
