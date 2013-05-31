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
            if (matrix.Length == 0)
            {
                return new int[0];
            }
            List<int> res = new List<int>();
            int left = 0;
            int right = matrix[0].Length - 1;
            int top = 0;
            int bottom = matrix.Length - 1;
            while (left < right & top < bottom)
            {
                int horiLength = right - left;
                int verticalLength = bottom - top;
                for (int i = 0; i < horiLength; i++)
                {
                    res.Add(matrix[top][left + i]);
                }
                for (int i = 0; i < verticalLength; i++)
                {
                    res.Add(matrix[top + i][right]);
                }
                for (int i = 0; i < horiLength; i++)
                {
                    res.Add(matrix[bottom][right - i]);
                }
                for (int i = 0; i < verticalLength; i++)
                {
                    res.Add(matrix[bottom - i][left]);
                }
                left += 1;
                right -= 1;
                top += 1;
                bottom -= 1;
            }
            if (left == right)
            {
                for (int i = top; i <= bottom; i++)
                {
                    res.Add(matrix[i][left]);
                }
            }
            else if (top == bottom)
            {
                for (int i = left; i <= right; i++)
                {
                    res.Add(matrix[top][i]);
                }
            }
            return res.ToArray();
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
