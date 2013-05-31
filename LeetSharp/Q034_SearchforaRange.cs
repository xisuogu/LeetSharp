using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a sorted array of integers, find the starting and ending position of a given target value.

// Your algorithm's runtime complexity must be in the order of O(log n).

// If the target is not found in the array, return [-1, -1].

// For example,
// Given [5, 7, 7, 8, 8, 10] and target value 8,
// return [3, 4].

namespace LeetSharp
{
    [TestClass]
    public class Q034_SearchforaRange
    {
        public int[] SearchRange(int[] A, int target)
        {
            return new int[] { FindEdge(A, target, true), FindEdge(A, target, false) };
        }

        private int FindEdge(int[] input, int target, bool leftMost)
        {
            int left = 0;
            int right = input.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (input[mid] < target)
                {
                    left = mid + 1;
                }
                else if (input[mid] > target)
                {
                    right = mid - 1;
                }
                else // found
                {
                    if (leftMost)
                    {
                        if (mid == 0 || input[mid - 1] < target)
                        {
                            return mid;
                        }
                        right = mid - 1;
                    }
                    else
                    {
                        if (mid == input.Length - 1 || input[mid + 1] > target)
                        {
                            return mid;
                        }
                        left = mid + 1;
                    }
                }
            }
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(SearchRange(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q034_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q034_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
