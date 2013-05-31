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
            return null;
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
