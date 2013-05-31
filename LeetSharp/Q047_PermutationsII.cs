using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a collection of numbers that might contain duplicates, return all possible unique permutations.

// For example,
// [1,1,2] have the following unique permutations:
// [1,1,2], [1,2,1], and [2,1,1].

namespace LeetSharp
{
    [TestClass]
    public class Q047_PermutationsII
    {
        public int[][] PermuteUnique(int[] num)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(PermuteUnique(input.ToIntArray()));
        }

        [TestMethod]
        public void Q047_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q047_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
