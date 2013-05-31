using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.

// For example,
// Given the following matrix:

// [
//  [ 1, 2, 3 ],
//  [ 4, 5, 6 ],
//  [ 7, 8, 9 ]
// ]
// You should return [1,2,3,6,9,8,7,4,5].

namespace LeetSharp
{
    [TestClass]
    public class Q054_SpiralMatrix
    {
        public int[] SpiralOrder(int[][] matrix)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(SpiralOrder(input.ToIntArrayArray()));
        }

        [TestMethod]
        public void Q054_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q054_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
