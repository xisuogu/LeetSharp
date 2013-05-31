using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string s, partition s such that every substring of the partition is a palindrome.
   
// Return all possible palindrome partitioning of s.
   
// For example, given s = "aab",
// Return
   
//   [
//     ["aa","b"],
//     ["a","a","b"]
//   ]

namespace LeetSharp
{
    [TestClass]
    public class Q131_PalindromePartitioning
    {
        public string[][] Partition(string input)
        {
            List<string[]> result = new List<string[]>();
            // dp[i, j] = true -> s[i] to s[j] is palindrome
            bool[,] dp = new bool[input.Length, input.Length]; // dp[i,j] means s[i]...s[j] is palindrom or not
            for (int s = input.Length - 1; s >= 0; s--)
            {
                for (int e = s; e < input.Length; e++)
                {
                    if (input[s] == input[e] && (e - s <= 2 || dp[s + 1, e - 1]))
                    {
                        dp[s, e] = true;
                    }
                }
            }
            // then use backtracking to get answer
            GenerateAnswer(dp, result, 0, new List<string>(), input);
            return result.ToArray();
        }

        private void GenerateAnswer(bool[,] dp, List<string[]> result, int start, List<string> cur, string input)
        {
            for (int end = start; end < input.Length; end++)
            {
                if (dp[start, end])
                {
                    cur.Add(input.Substring(start, end - start + 1));
                    if (end == input.Length - 1)
                    {
                        result.Add(cur.ToArray());
                    }
                    else
                    {
                        GenerateAnswer(dp, result, end + 1, cur, input);
                    }
                    cur.RemoveAt(cur.Count - 1);
                }
            }
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Partition(input.Deserialize()));
        }

        [TestMethod]
        public void Q131_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q131_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
