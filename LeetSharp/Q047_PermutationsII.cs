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

        public int[][] PermuteUnique(int[] num)
        {
            Array.Sort(num);

            List<int[]> results = new List<int[]>();
            do
            {
                results.Add((int[])num.Clone());
            } while (NextPermutation(ref num));

            return results.ToArray();
        }


        private bool NextPermutation(ref int[] num)
        {
            int i = num.Length - 2;
            for (; i >= 0; i--)
            {
                if (num[i] < num[i + 1])
                {
                    int min = int.MaxValue, minPos = 0;
                    for (int j = num.Length - 1; j > i; j--)
                    {
                        if (num[j] > num[i] && num[j] < min)
                        {
                            min = num[j];
                            minPos = j;
                        }
                    }
                    int temp = num[i];
                    num[i] = min;
                    num[minPos] = temp;

                    break;
                }
            }

            if (i == -1)
                return false;

            int start = i + 1, end = num.Length - 1;
            while (start < end)
            {
                int temp = num[start];
                num[start++] = num[end];
                num[end--] = temp;
            }
            return true;
        }


        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(PermuteUnique(input.ToIntArray()));
        }

        [TestMethod]
        public void Q047_Small()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreIntArrayArrayEqual);
        }
        [TestMethod]
        public void Q047_Large()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreIntArrayArrayEqual);
        }
    }
}
