using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

// If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).

// The replacement must be in-place, do not allocate extra memory.

// Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
// 1,2,3 ¡ú 1,3,2
// 3,2,1 ¡ú 1,2,3
// 1,1,5 ¡ú 1,5,1

namespace LeetSharp
{
    [TestClass]
    public class Q031_NextPermutation
    {
        public int[] NextPermutation(int[] num)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(NextPermutation(input.ToIntArray()));
        }

        [TestMethod]
        public void Q031_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q031_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
