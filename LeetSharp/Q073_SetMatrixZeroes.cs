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
            int height = matrix.Length;
            int width = matrix[0].Length;
            bool firstRowZero = matrix[0].Any(i => i == 0);
            bool firstColumnZero = matrix.Any(c => c[0] == 0);
            // scan matrix except first line first column, set zero on first line first column
            for (int r = 1; r < height; r++)
            {
                for (int c = 1; c < width; c++)
                {
                    if (matrix[r][c] == 0)
                    {
                        matrix[0][c] = matrix[r][0] = 0;
                    }
                }
            }
            // use the data in first row and first column to set zero
            for (int r = 1; r < height; r++)
            {
                if (matrix[r][0] == 0)
                {
                    for (int c = 0; c < width; c++)
                    {
                        matrix[r][c] = 0;
                    }
                }
            }
            for (int c = 1; c < width; c++)
            {
                if (matrix[0][c] == 0)
                {
                    for (int r = 0; r < height; r++)
                    {
                        matrix[r][c] = 0;
                    }
                }
            }
            if (firstColumnZero)
            {
                for (int r = 0; r < height; r++)
                {
                    matrix[r][0] = 0;
                }
            }
            if (firstRowZero)
            {
                for (int c = 0; c < width; c++)
                {
                    matrix[0][c] = 0;
                }
            }
            return matrix;
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
