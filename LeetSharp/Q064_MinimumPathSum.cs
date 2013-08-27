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
            for (int i = grid.Length - 2; i >= 0; i--)
                grid[i][grid[0].Length - 1] += grid[i + 1][grid[0].Length - 1];

            for (int j = grid[0].Length - 2; j >= 0; j--)
                grid[grid.Length - 1][j] += grid[grid.Length - 1][j + 1];

            for (int i = grid.Length - 2; i >= 0; i--)
            {
                for (int j = grid[0].Length - 2; j >= 0; j--)
                {
                    grid[i][j] += Math.Min(grid[i + 1][j], grid[i][j + 1]);
                }
            }
            return grid[0][0];
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
