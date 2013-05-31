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
            return -1;
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
