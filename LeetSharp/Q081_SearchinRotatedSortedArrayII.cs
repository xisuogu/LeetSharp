using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Follow up for "Search in Rotated Sorted Array": Q033
// What if duplicates are allowed?

// Would this affect the run-time complexity? How and why?

// Write a function to determine if a given target is in the array.

namespace LeetSharp
{
    [TestClass]
    public class Q081_SearchinRotatedSortedArrayII
    {
        public bool SearchRotated(int[] input, int target)
        {
            return SearchInternal(input, target, 0, input.Length - 1);
        }

        private bool SearchInternal(int[] a, int target, int left, int right)
        {
            if (left > right)
            {
                return false;
            }
            bool isForSureNormal = false;
            if (a[left] < a[right])
            {
                isForSureNormal = true;
            }
            if (isForSureNormal && (target < a[left] || target > a[right]))
            {
                return false;
            }
            int mid = (left + right) / 2;
            if (a[mid] == target)
            {
                return true;
            }
            bool answerRight = SearchInternal(a, target, mid + 1, right);
            if (answerRight)
            {
                return true;
            }
            return SearchInternal(a, target, left, mid - 1); // answerLeft
        }

        public string SolveQuestion(string input)
        {
            return SearchRotated(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()).ToString().ToLower();
        }

        [TestMethod]
        public void Q081_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q081_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
