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
            // rotate layer by layer, from outer most to inner most
            int length = matrix[0].Length;
            int lower = 0;
            int higher = length - 1; // e.g, 4*4 matrix, starting from 0, 3, then 1, 2
            while (lower < higher)
            {
                for (int c = lower; c < higher; c++)
                {
                    // swap 4 elements
                    int tmp = matrix[lower][c];
                    matrix[lower][c] = matrix[length - 1 - c][lower];
                    matrix[length - 1 - c][lower] = matrix[higher][length - 1 - c];
                    matrix[higher][length - 1 - c] = matrix[c][higher];
                    matrix[c][higher] = tmp;
                }
                lower++;
                higher--;
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
