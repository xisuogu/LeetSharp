using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an integer n, generate a square matrix filled with elements from 1 to n2 in spiral order.

// For example,
// Given n = 3,

// You should return the following matrix:
// [
//  [ 1, 2, 3 ],
//  [ 8, 9, 4 ],
//  [ 7, 6, 5 ]
// ]

namespace LeetSharp
{
    [TestClass]
    public class Q059_SpiralMatrixII
    {
        public int[][] GenerateMatrix(int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }
            int low = 0;
            int high = n - 1;
            int currentEle = 1;
            while (low < high)
            {
                int edge = high - low;
                for (int i = 0; i < edge; i++)
                {
                    result[low][low + i] = currentEle++;
                }
                for (int i = 0; i < edge; i++)
                {
                    result[low + i][high] = currentEle++;
                }
                for (int i = 0; i < edge; i++)
                {
                    result[high][high - i] = currentEle++;
                }
                for (int i = 0; i < edge; i++)
                {
                    result[high - i][low] = currentEle++;
                }
                low += 1;
                high -= 1;
            }
            if (low == high)
            {
                result[low][low] = currentEle;
            }
            return result;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(GenerateMatrix(input.ToInt()));
        }

        [TestMethod]
        public void Q059_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q059_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
