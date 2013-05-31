using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Follow up for "Unique Paths":
// Now consider if some obstacles are added to the grids. How many unique paths would there be?
// An obstacle and empty space is marked as 1 and 0 respectively in the grid.
// For example,

// There is one obstacle in the middle of a 3x3 grid as illustrated below.

// [
//   [0,0,0],
//   [0,1,0],
//   [0,0,0]
// ]
// The total number of unique paths is 2.

// Note: m and n will be at most 100.

namespace LeetSharp
{
    [TestClass]
    public class Q063_UniquePathsII
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int height = obstacleGrid.Length;
            int width = obstacleGrid[0].Length;
            int[] temp = new int[height];
            temp[0] = 1;
            for (int col = 0; col < width; col++)
            {
                if (obstacleGrid[0][col] == 1)
                {
                    temp[0] = 0;
                }
                for (int row = 1; row < height; row++)
                {
                    if (obstacleGrid[row][col] == 1)
                    {
                        temp[row] = 0;
                    }
                    else
                    {
                        temp[row] = temp[row] + temp[row - 1];
                    }
                }
            }
            return temp[height - 1];
        }

        public string SolveQuestion(string input)
        {
            return UniquePathsWithObstacles(input.ToIntArrayArray()).ToString();
        }

        [TestMethod]
        public void Q063_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q063_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
