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

        public int[][] Permute(int[] num)
        {
            List<int[]> results = new List<int[]>();
            int[] data = (int[])num.Clone();
            Permute(num, results, data, 0);
            return results.ToArray();
        }

        private void Permute(int[] num, List<int[]> results, int[] data, int level)
        {
            if (level == num.Length - 1)
            {
                results.Add((int[])data.Clone());
                return;
            }
            for (int i = level; i < num.Length; i++)
            {
                Swap(ref data[level], ref data[i]);
                Permute(num, results, data, level + 1);
                Swap(ref data[level], ref data[i]);
            }
        }

        private void Swap(ref int i1, ref int i2)
        {
            int temp = i1;
            i1 = i2;
            i2 = temp;
        }

        #region Insert
        public int[][] Permute_Insert(int[] num)
        {
            List<int[]> results = new List<int[]>();
            Permute_Insert(num, ref results, num.Length);
            return results.ToArray();
        }

        private void Permute_Insert(int[] num, ref List<int[]> results, int level)
        {
            if (level == 1)
            {
                results.Add(new int[] { num[level - 1] });
                return;
            }

            Permute_Insert(num, ref results, level - 1);

            List<int[]> tempResults = new List<int[]>();
            foreach (var result in results)
            {
                for (int i = 0; i <= result.Length; i++)
                {
                    List<int> list = result.ToList();
                    list.Insert(i, num[level - 1]);

                    tempResults.Add(list.ToArray());
                }
            }
            results = tempResults;
        }
        #endregion

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Permute(input.ToIntArray()));
        }

        [TestMethod]
        public void Q046_Small()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreIntArrayArrayEqual);
        }
        [TestMethod]
        public void Q046_Large()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreIntArrayArrayEqual);
        }
    }
}
