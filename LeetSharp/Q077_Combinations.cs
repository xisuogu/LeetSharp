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
            List<int[]> result = new List<int[]>();
            int[] tmp = new int[k];
            CombinationRec(n, k, 1, 0, result, tmp);
            return result.ToArray();
        }

        private void CombinationRec(int n, int k, int currentN, int currentPossion, List<int[]> result, int[] tmp)
        {
            if (currentPossion == k)
            {
                return;
            }
            tmp[currentPossion] = currentN;
            if (currentPossion == k - 1) // filled in last element, add this to result
            {
                result.Add(tmp.ToArray());
            }
            else
            {
                CombinationRec(n, k, currentN + 1, currentPossion + 1, result, tmp);
            }
            if ((n - currentN) > (k - 1 - currentPossion)) // still have chance to SayNO
            {
                CombinationRec(n, k, currentN + 1, currentPossion, result, tmp);
            }
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
