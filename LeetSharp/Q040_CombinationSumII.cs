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
            candidates = candidates.OrderBy(n => n).ToArray();
            var result = CombinationSumInternal(candidates, target, 0);
            return result.ToArray();
        }

        public List<int[]> CombinationSumInternal(int[] candidates, int target, int startIndex)
        {
            List<int[]> result = new List<int[]>();
            for (int i = startIndex; i < candidates.Length; i++)
            {
                if (i > startIndex && candidates[i] == candidates[i-1])
                {
                    continue;
                }
                if (candidates[i] < target)
                {
                    var nextLevelResults = CombinationSumInternal(candidates, target - candidates[i], i + 1);
                    foreach (var nlresult in nextLevelResults)
                    {
                        result.Add((new[] { candidates[i] }).Concat(nlresult).ToArray());
                    }
                }
                else if (candidates[i] == target)
                {
                    result.Add(new[] { candidates[i] });
                }
            }
            return result;
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
