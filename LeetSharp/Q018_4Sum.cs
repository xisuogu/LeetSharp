using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array S of n integers, are there elements a, b, c, and d in S such that a + b + c + d = target? 
// Find all unique quadruplets in the array which gives the sum of target.

// Note:
// Elements in a quadruplet (a,b,c,d) must be in non-descending order. (ie, a ? b ? c ? d)
// The solution set must not contain duplicate quadruplets.
//    For example, given array S = {1 0 -1 0 -2 2}, and target = 0.

//    A solution set is:
//    (-1,  0, 0, 1)
//    (-2, -1, 1, 2)
//    (-2,  0, 0, 2)

namespace LeetSharp
{
    [TestClass]
    public class Q018_4Sum
    {
        public int[][] FourSum(int[] num, int target)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(FourSum(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q018_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q018_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
