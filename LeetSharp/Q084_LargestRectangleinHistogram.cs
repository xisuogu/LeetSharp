using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.

// Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].

// The largest rectangle is shown in the shaded area, which has area = 10 unit.

// For example,
// Given height = [2,1,5,6,2,3],
// return 10.

namespace LeetSharp
{
    [TestClass]
    public class Q084_LargestRectangleinHistogram
    {
        public int LargestRectangleArea(int[] height)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return LargestRectangleArea(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q084_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q084_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
