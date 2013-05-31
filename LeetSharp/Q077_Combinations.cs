using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.
// For example,
// If n = 4 and k = 2, a solution is:

// [
//  [2,4],
//  [3,4],
//  [2,3],
//  [1,2],
//  [1,3],
//  [1,4],
// ]

namespace LeetSharp
{
    [TestClass]
    public class Q077_Combinations
    {
        public int[][] Combinations(int n, int k)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Combinations(input.GetToken(0).ToInt(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q077_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q077_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
