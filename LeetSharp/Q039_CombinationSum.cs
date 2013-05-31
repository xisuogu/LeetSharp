using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a set of candidate numbers (C) and a target number (T), 
// find all unique combinations in C where the candidate numbers sums to T.

// The same repeated number may be chosen from C unlimited number of times.

// Note:

// All numbers (including target) will be positive integers.
// Elements in a combination (a1, a2, � , ak) must be in non-descending order. (ie, a1 ? a2 ? � ? ak).
// The solution set must not contain duplicate combinations.
// For example, given candidate set 2,3,6,7 and target 7, 
// A solution set is: 
// [7] 
// [2, 2, 3] 

namespace LeetSharp
{
    [TestClass]
    public class Q039_CombinationSum
    {
        public int[][] CombinationSum(int[] candidates, int target)
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
                if (candidates[i] < target)
                {
                    var nextLevelResults = CombinationSumInternal(candidates, target - candidates[i], i);
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
            return TestHelper.Serialize(CombinationSum(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q039_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q039_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
