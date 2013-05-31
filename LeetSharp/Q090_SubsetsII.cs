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
        public int[][] SubsetsWithDup(int[] num)
        {
            return null;
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
