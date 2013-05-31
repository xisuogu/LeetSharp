using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a collection of candidate numbers (C) and a target number (T), 
// find all unique combinations in C where the candidate numbers sums to T.

// Each number in C may only be used once in the combination.

// Note:

// All numbers (including target) will be positive integers.
// Elements in a combination (a1, a2, � , ak) must be in non-descending order. (ie, a1 ? a2 ? � ? ak).
// The solution set must not contain duplicate combinations.
// For example, given candidate set 10,1,2,7,6,1,5 and target 8, 
// A solution set is: 
// [1, 7] 
// [1, 2, 5] 
// [2, 6] 
// [1, 1, 6] 

namespace LeetSharp
{
    [TestClass]
    public class Q040_CombinationSumII
    {
        public int[][] CombinationSum2(int[] candidates, int target)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(CombinationSum2(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q040_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q040_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
