using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an unsorted integer array, find the first missing positive integer.

// For example,
// Given [1,2,0] return 3,
// and [3,4,-1,1] return 2.

// Your algorithm should run in O(n) time and uses constant space.

namespace LeetSharp
{
    [TestClass]
    public class Q041_FirstMissingPositive
    {
        public int FirstMissingPositive(int[] A)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return FirstMissingPositive(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q041_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q041_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
