using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

// The robot can only move either down or right at any point in time. 
// The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

// How many possible unique paths are there?

namespace LeetSharp
{
    [TestClass]
    public class Q062_UniquePaths
    {
        public int UniquePaths(int m, int n)
        {
            if (m == 1 || n == 1)
            {
                return 1;
            }
            int[] temp = new int[n];
            for (int i = 0; i < m; i++)
            {
                temp[0] = 1;
                for (int j = 1; j < n; j++)
                {
                    temp[j] += temp[j - 1];
                }
            }
            return temp[n - 1];
        }

        public string SolveQuestion(string input)
        {
            return UniquePaths(input.GetToken(0).ToInt(), input.GetToken(1).ToInt()).ToString();
        }

        [TestMethod]
        public void Q062_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q062_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
