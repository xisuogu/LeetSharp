using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.

// For example, 
// Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.

namespace LeetSharp
{
    [TestClass]
    public class Q042_TrappingRainWater
    {
        public int TrapWater(int[] inputs)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return TrapWater(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q042_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q042_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
