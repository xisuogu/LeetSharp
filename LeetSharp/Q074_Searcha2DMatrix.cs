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
            int width = matrix[0].Length;
            int height = matrix.Length;

            return SearchMatrixRec(matrix, target, 0, height - 1, 0, width - 1);
        }

        private bool SearchMatrixRec(int[][] matrix, int target, int top, int bottom, int left, int right)
        {
            if (top > bottom || left > right)
                return false;

            int midRow = (top + bottom) / 2;
            int midCol = (left + right) / 2;
            int temp = matrix[midRow][midCol];

            if (temp == target)
            {
                return true;
            }
            else if (temp < target) // discard the left top part
            {
                return SearchMatrixRec(matrix, target, midRow + 1, bottom, left, right)
                    || SearchMatrixRec(matrix, target, top, midRow, midCol + 1, right);
            }
            else // discard right bottom part
            {
                return SearchMatrixRec(matrix, target, top, midRow - 1, left, right)
                    || SearchMatrixRec(matrix, target, midRow, bottom, left, midCol - 1);
            }
        }

        public bool SearchMatrix2(int[][] matrix, int target)
        {
            int i = matrix.Length - 1, j = 0;

            while (i >= 0 && j < matrix[0].Length)
            {
                if (matrix[i][j] == target)
                {
                    return true; 
                }
                else if (matrix[i][j] < target)
                {
                    j++;
                }
                else
                {
                    i--;
                }
            }

            return false;
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
