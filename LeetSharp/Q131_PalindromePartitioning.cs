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
            return PartitionRec(input).ToArray();
        }

        private List<string[]> PartitionRec(string input)
        {
            List<string[]> results = new List<string[]>();

            for (int i = 1; i <= input.Length; i++)
            {
                string firstPart = input.Substring(0, i);
                if (IsPalindrome(firstPart))
                {
                    string secondPart = input.Substring(i);

                    if (secondPart.Length > 0)
                    {
                        var secondResults = PartitionRec(secondPart);

                        foreach (var secondResult in secondResults)
                        {
                            results.Add(new string[] { firstPart }.Concat(secondResult).ToArray());
                        }
                    }
                    else
                    {
                        results.Add(new string[] { firstPart });
                    }
                }
            }
            return results;
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
