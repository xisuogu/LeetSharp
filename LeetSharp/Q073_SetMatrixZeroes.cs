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
            bool firstRow = false, firstColumn = false;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    firstColumn = true;
                    break;
                }
            }
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                {
                    firstRow = true;
                    break;
                }
            }

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    for (int j = 1; j < matrix[0].Length; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                {
                    for (int i = 1; i < matrix.Length; i++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            if (firstRow)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    matrix[0][j] = 0;
                }
            }
            if (firstColumn)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][0] = 0;
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
