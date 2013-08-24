using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// You are given an n x n 2D matrix representing an image.

// Rotate the image by 90 degrees (clockwise).

// Follow up:
// Could you do this in-place?

namespace LeetSharp
{
    [TestClass]
    public class Q048_RotateImage
    {
        public int[][] Rotate(int[][] matrix)
        {
            for (int layer = 0; layer < matrix.Length / 2; layer++)
            {
                for (int i = layer; i < matrix.Length - 1 - layer; i++)
                {
                    int temp = matrix[layer][i];
                    matrix[layer][i] = matrix[matrix.Length - 1 - i][layer];
                    matrix[matrix.Length - 1 - i][layer] = matrix[matrix.Length - 1 - layer][matrix.Length - 1 - i];
                    matrix[matrix.Length - 1 - layer][matrix.Length - 1 - i] = matrix[i][matrix.Length - 1 - layer];
                    matrix[i][matrix.Length - 1 - layer] = temp;

                }
            }
            return matrix;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Rotate(input.ToIntArrayArray()));
        }

        [TestMethod]
        public void Q048_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q048_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
