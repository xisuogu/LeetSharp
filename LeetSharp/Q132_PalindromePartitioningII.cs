using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string s, partition s such that every substring of the partition is a palindrome.

// Return the minimum cuts needed for a palindrome partitioning of s.

// For example, given s = "aab",
// Return 1 since the palindrome partitioning ["aa","b"] could be produced using 1 cut.

namespace LeetSharp
{
    [TestClass]
    public class Q132_PalindromePartitioningII
    {
        public int MinCut(string input)
        {
            int[] answer = new int[input.Length + 1];
            for (int i = 0; i <= input.Length; i++)
            {
                answer[i] = input.Length - i - 1;
            }

            bool[,] dp = new bool[input.Length, input.Length];
            for (int start = input.Length - 1; start >= 0; start--)
            {
                for (int end = start; end < input.Length; end++)
                {
                    if (input[start] == input[end])
                    {
                        if (end - start <= 2 || dp[start + 1, end - 1])
                        {
                            dp[start, end] = true;
                            answer[start] = Math.Min(answer[start], answer[end + 1] + 1);
                        }
                    }
                }
            }
            return answer[0];
        }


        public int MinCut2(string input)
        {
            var cache = new Dictionary<string, int>();
            return MinCutRec(input, cache);
        }

        private int MinCutRec(string input, Dictionary<string, int> cache)
        {
            if (cache.ContainsKey(input))
                return cache[input];

            int minCut = int.MaxValue;
            for (int i = 1; i <= input.Length; i++)
            {
                string firstPart = input.Substring(0, i);
                if (IsPalindrome(firstPart))
                {
                    string secondPart = input.Substring(i);

                    int tempMinCut;
                    if (secondPart.Length > 0)
                    {
                        tempMinCut = MinCutRec(secondPart, cache) + 1;
                    }
                    else
                    {
                        tempMinCut = 0;
                    }
                    minCut = Math.Min(tempMinCut, minCut);
                }
            }
            cache[input] = minCut;
            return minCut;
        }

        private bool IsPalindrome(string input)
        {
            int start = 0, end = input.Length - 1;
            while (start < end)
            {
                if (input[start] != input[end])
                    return false;

                start++;
                end--;
            }
            return true;
        }

        public string SolveQuestion(string input)
        {
            return MinCut(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q132_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q132_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
