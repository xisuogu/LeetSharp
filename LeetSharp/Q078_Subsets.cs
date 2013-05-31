using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a set of distinct integers, S, return all possible subsets.

// Note:
//  Elements in a subset must be in non-descending order.
//  The solution set must not contain duplicate subsets.
//  For example,
//  If S = [1,2,3], a solution is:

// [
//  [3],
//  [1],
//  [2],
//  [1,2,3],
//  [1,3],
//  [2,3],
//  [1,2],
//  []
// ]

namespace LeetSharp
{
    [TestClass]
    public class Q078_Subsets
    {
        public int[][] Subsets(int[] input)
        {
            List<int[]> result = new List<int[]>();
            result.Add(new int[0]);
            input = input.OrderBy(i => i).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                int current = input[i];
                int existingCount = result.Count;
                for (int j = 0; j < existingCount; j++)
                {
                    result.Add(result[j].Concat(new[] { current }).ToArray());
                }
            }
            return result.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Subsets(input.ToIntArray()));
        }

        private bool AreIntArrayArrayEqual(string s1, string s2)
        {
            if (s1 == s2)
            {
                return true;
            }
            if (s1.Length != s2.Length)
            {
                return false;
            }
            int[][] a1 = s1.ToIntArrayArray();
            int[][] a2 = s2.ToIntArrayArray();
            a1 = a1.OrderBy(a => a.Length).ThenBy(a => String.Join("", a)).ToArray();
            a2 = a2.OrderBy(a => a.Length).ThenBy(a => String.Join("", a)).ToArray();
            return TestHelper.Serialize(a1) == TestHelper.Serialize(a2);
        }

        [TestMethod]
        public void Q078_Small()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreIntArrayArrayEqual);
        }
        [TestMethod]
        public void Q078_Large()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreIntArrayArrayEqual);
        }
    }
}
