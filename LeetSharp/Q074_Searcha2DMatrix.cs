using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

// Integers in each row are sorted from left to right.
// The first integer of each row is greater than the last integer of the previous row.
// For example,

// Consider the following matrix:
// [
//  [1,   3,  5,  7],
//  [10, 11, 16, 20],
//  [23, 30, 34, 50]
// ]
// Given target = 3, return true.

namespace LeetSharp
{
    [TestClass]
    public class Q074_Searcha2DMatrix
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int height = matrix.Length;
            int width = matrix[0].Length;
            // binary search
            return SearchMatrixRec(matrix, target, 0, height - 1, 0, width - 1);
        }

        private bool SearchMatrixRec(int[][] matrix, int target, int high, int low, int left, int right)
        {
            if (high > low || left > right)
            {
                return false;
            }
            int midRow = (high + low) / 2;
            int midCol = (left + right) / 2;
            int tmp = matrix[midRow][midCol];
            if (tmp == target)
            {
                return true;
            }
            else if (tmp > target) // discard right bottom part
            {
                return SearchMatrixRec(matrix, target, high, low, left, midCol - 1) ||
                    SearchMatrixRec(matrix, target, high, midRow - 1, midCol, right);
            }
            else // discaard the left top part
            {
                return SearchMatrixRec(matrix, target, midRow + 1, low, left, right) ||
                    SearchMatrixRec(matrix, target, high, midRow, midCol + 1, right);
            }
        }

        public string SolveQuestion(string input)
        {
            return SearchMatrix(input.GetToken(0).ToIntArrayArray(), input.GetToken(1).ToInt()).ToString()
                .ToLower();
        }

        [TestMethod]
        public void Q074_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q074_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
