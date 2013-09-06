using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an index k, return the kth row of the Pascal's triangle.

// For example, given k = 3,
// Return [1,3,3,1].

// Note:
// Could you optimize your algorithm to use only O(k) extra space?

namespace LeetSharp
{
    [TestClass]
    public class Q119_PascalTriangleII
    {
        public int[] GetRow(int rowIndex)
        {
            int[] currentRow = new int[rowIndex + 1];
            for (int i = 0; i <= rowIndex; i++)
            {
                currentRow[i] = 1;
           
                for (int j = i - 1; j >= 1; j--)
                {
                    currentRow[j] = currentRow[j - 1] + currentRow[j];
                }
                currentRow[0] = 1;
            }
            return currentRow;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(GetRow(input.ToInt()));
        }

        [TestMethod]
        public void Q119_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q119_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
