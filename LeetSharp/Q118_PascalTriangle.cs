using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given numRows, generate the first numRows of Pascal's triangle.
   
// For example, given numRows = 5,
// Return
   
// [
//      [1],
//     [1,1],
//    [1,2,1],
//   [1,3,3,1],
//  [1,4,6,4,1]
// ]

namespace LeetSharp
{
    [TestClass]
    public class Q118_PascalTriangle
    {
        public int[][] Generate(int numRows)
        {
            List<int[]> result = new List<int[]>();
            for (int i = 0; i < numRows; i++)
            {
                int[] currentRow = new int[i + 1];
                currentRow[0] = 1;
                for (int j = 1; j <= i - 1; j++)
                {
                    currentRow[j] = result[i - 1][j - 1] + result[i - 1][j];
                }
                currentRow[i] = 1; // last
                result.Add(currentRow);
            }
            return result.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Generate(input.ToInt()));
        }

        [TestMethod]
        public void Q118_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q118_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
