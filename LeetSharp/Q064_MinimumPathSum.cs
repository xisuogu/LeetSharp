using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a m x n grid filled with non-negative numbers, 
// find a path from top left to bottom right which minimizes the sum of all numbers along its path.

// Note: You can only move either down or right at any point in time.

namespace LeetSharp
{
    [TestClass]
    public class Q064_MinimumPathSum
    {
        public int MinPathSum(int[][] grid)
        {
            int height = grid.Length;
            int width = grid[0].Length;
            int[] temp = new int[height];
            for (int i = 0; i < height; i++)
            {
                temp[i] = int.MaxValue;
            }
            temp[0] = 0;
            for (int c = 0; c < width; c++)
            {
                temp[0] = temp[0] + grid[0][c];
                for (int r = 1; r < height; r++)
                {
                    temp[r] = Math.Min(temp[r - 1], temp[r]) + grid[r][c];
                }
            }
            return temp[height - 1];
        }

        public string SolveQuestion(string input)
        {
            return MinPathSum(input.ToIntArrayArray()).ToString();
        }

        [TestMethod]
        public void Q064_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q064_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
