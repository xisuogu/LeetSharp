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
            List<int[]> res = new List<int[]>();
            num = num.OrderBy(i => i).ToArray();
            res.Add(num.ToArray());
            while (NextPermute(num))
            {
                res.Add(num.ToArray());
            }
            return res.ToArray();
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
