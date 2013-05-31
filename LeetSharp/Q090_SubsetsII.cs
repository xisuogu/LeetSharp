using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a collection of integers that might contain duplicates, S, return all possible subsets.

// Note:

// Elements in a subset must be in non-descending order.
// The solution set must not contain duplicate subsets.
// For example,
// If S = [1,2,2], a solution is:

// [
//   [2],
//   [1],
//   [1,2,2],
//   [2,2],
//   [1,2],
//   []
// ]

namespace LeetSharp
{
    [TestClass]
    public class Q090_SubsetsII
    {
        // for dup positions, margin bit to right like this:
        // 0,0,0 = 0
        // 0,0,1 = 1
        // 0,1,1 = 3
        // 1,1,1 = 7
        public int[][] SubsetsWithDup(int[] num)
        {
            List<int[]> result = new List<int[]>();
            num = num.OrderBy(i => i).ToArray();
            bool[] mask = new bool[num.Length];
            while (true)
            {
                // per mask status, add to result
                List<int> tmp = new List<int>();
                for (int i = 0; i < num.Length; i++)
                {
                    if (mask[i])
                    {
                        tmp.Add(num[i]);
                    }
                }
                result.Add(tmp.ToArray());
                // change mask to next position.
                bool carry = true;
                for (int i = 0; i < mask.Length && carry; i++)
                {
                    carry = mask[i]; // 1 -> 0, then continue
                    mask[i] = !mask[i];
                    // for dup element, push the bits to right
                    if (mask[i])
                    {
                        for (int j = i + 1; j < mask.Length; j++)
                        {
                            if (num[j - 1] == num[j] && !mask[j])
                            {
                                mask[j] = true;
                                mask[j - 1] = false;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                if (mask.All(m => m == false))
                {
                    break;
                }
            }
            return result.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(SubsetsWithDup(input.ToIntArray()));
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
        public void Q090_Small()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreIntArrayArrayEqual);
        }
        [TestMethod]
        public void Q090_Large()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreIntArrayArrayEqual);
        }
    }
}
