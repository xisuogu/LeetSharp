using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in place.

// Follow up:
// Did you use extra space?
// A straight forward solution using O(mn) space is probably a bad idea.
// A simple improvement uses O(m + n) space, but still not the best solution.
// Could you devise a constant space solution?

namespace LeetSharp
{
    [TestClass]
    public class Q073_SetMatrixZeroes
    {
        public int[][] SetZeroes(int[][] matrix)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(SetZeroes(input.ToIntArrayArray()));
        }

        [TestMethod]
        public void Q073_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q073_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
