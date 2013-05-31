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
            int[] answer = new int[input.Length + 1]; // answer[i] means MinCut(s.SubString(i))
            bool[,] dp = new bool[input.Length, input.Length]; // dp[i,j] means s[i]...s[j] is palindrom or not
            // worst answer
            for (int i = 0; i <= input.Length; i++)
            {
                answer[i] = input.Length - i - 1;
            }
            // make answer better
            for (int s = input.Length - 2; s >= 0; s--)
            {
                for (int e = s; e < input.Length; e++)
                {
                    if (input[s] == input[e] && (e - s <= 2 || dp[s + 1, e - 1]))
                    {
                        dp[s, e] = true;
                        answer[s] = Math.Min(answer[s], answer[e + 1] + 1); // split to s,e | e+1,end
                    }
                }
            }

            return answer[0];
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
