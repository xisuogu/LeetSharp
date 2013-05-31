using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a collection of numbers, return all possible permutations.

// For example,
// [1,2,3] have the following permutations:
// [1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1].

namespace LeetSharp
{
    [TestClass]
    public class Q046_Permutations
    {
        public int[][] Permute(int[] num)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Permute(input.ToIntArray()));
        }

        [TestMethod]
        public void Q046_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q046_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
