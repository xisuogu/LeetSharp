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
            List<int[]> res = new List<int[]>();
            int[] indexes = Enumerable.Range(0, num.Length).ToArray();
            AddToResult(res, num, indexes);
            while (NextPermute(indexes))
            {
                AddToResult(res, num, indexes);
            }
            return res.ToArray();
        }

        private void AddToResult(List<int[]> res, int[] num, int[] indexes)
        {
            int[] toAdd = new int[num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                toAdd[i] = num[indexes[i]];
            }
            res.Add(toAdd);
        }

        private bool NextPermute(int[] input)
        {
            // find the 1st element that is desending
            for (int i = input.Length - 1; i >= 1; i--)
            {
                if (input[i - 1] < input[i])
                {
                    // swap num[i-1] with the [smallest element in (elements that > num[i-1])]
                    for (int j = input.Length - 1; j >= i; j--)
                    {
                        if (input[j] > input[i - 1])
                        {
                            Swap(input, j, i - 1);
                            break;
                        }
                    }
                    // then reverse num[i.. last]
                    Reverse(input, i, input.Length - 1);
                    return true;
                }
            }
            return false;
        }

        private void Reverse(int[] num, int from, int to)
        {
            while (from < to)
            {
                Swap(num, from++, to--);
            }
        }

        private void Swap(int[] num, int i1, int i2)
        {
            if (i1 != i2)
            {
                int temp = num[i1];
                num[i1] = num[i2];
                num[i2] = temp;
            }
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
