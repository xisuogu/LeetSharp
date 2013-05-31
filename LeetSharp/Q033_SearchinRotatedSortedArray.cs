using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Suppose a sorted array is rotated at some pivot unknown to you beforehand.

// (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

// You are given a target value to search. If found in the array return its index, otherwise return -1.

// You may assume no duplicate exists in the array.

namespace LeetSharp
{
    [TestClass]
    public class Q033_SearchinRotatedSortedArray
    {
        public int Search(int[] a, int target)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return Search(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()).ToString();
        }

        [TestMethod]
        public void Q033_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q033_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
