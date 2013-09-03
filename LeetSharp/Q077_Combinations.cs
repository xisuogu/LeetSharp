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
            int[] input = Enumerable.Range(1, n).ToArray();
            List<int[]> results = new List<int[]>();
            List<int> temp = new List<int>();
            CombinationsRec(input, k, results, temp, 0);
            return results.ToArray();
        }

        public void CombinationsRec(int[] input, int k, List<int[]> results, List<int> temp, int level)
        {
            if (temp.Count == k)
            {
                results.Add(temp.ToArray());
                return;
            }

            if (k - temp.Count > input.Length - level) // bail out
            {
                return;
            }

            List<int> current = new List<int>(temp);
            current.Add(input[level]);
            CombinationsRec(input, k, results, current, level + 1);

            CombinationsRec(input, k, results, temp, level + 1);
        }

        public int[][] Combinations2(int n, int k)
        {
            int[] input = Enumerable.Range(1, n).ToArray();

            List<int[]> results = new List<int[]>();
            int max = 1 << input.Length;
            for (int i = 0; i < max; i++)
            {
                ConvertIntValueToCombination(i, input, k, results);
            }
            return results.ToArray();
        }

        private void ConvertIntValueToCombination(int val, int[] input, int k, List<int[]> results)
        {
            List<int> inputList = new List<int>();
            int index = 0;
            for (int i = val; i > 0; i >>= 1)
            {
                if ((i & 1) == 1)
                {
                    inputList.Add(input[index]);
                }
                index++;
            }
            if (inputList.Count == k)
                results.Add(inputList.ToArray());
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
