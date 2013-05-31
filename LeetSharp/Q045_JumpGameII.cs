using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array of non-negative integers, you are initially positioned at the first index of the array.

// Each element in the array represents your maximum jump length at that position.

// Your goal is to reach the last index in the minimum number of jumps.

// For example:
// Given array A = [2,3,1,1,4]

// The minimum number of jumps to reach the last index is 2. (Jump 1 step from index 0 to 1, then 3 steps to the last index.)

namespace LeetSharp
{
    [TestClass]
    public class Q045_JumpGameII
    {
        public int Jump(int[] input)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return Jump(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q045_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q045_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
