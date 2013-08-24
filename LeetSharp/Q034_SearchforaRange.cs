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
            int min = int.MaxValue, max = int.MinValue;
            SearchRange(A, 0, A.Length - 1, target, ref min, ref max);

            if (min == int.MaxValue)
                min = -1;
            if (max == int.MinValue)
                max = -1;

            return new int[] { min, max };
        }

        private void SearchRange(int[] A, int start, int end, int target, ref int min, ref int max)
        {
            if (start >= end)
            {
                if (start == end && A[start] == target)
                    min = max = start;
                return;
            }

            int tempMin = int.MaxValue, tempMax = int.MinValue;
            int middle = (start + end) / 2;
            if (A[middle] > target)
            {
                SearchRange(A, start, middle - 1, target, ref tempMin, ref tempMax);
            }
            else if (A[middle] < target)
            {
                SearchRange(A, middle + 1, end, target, ref tempMin, ref tempMax);
            }
            else
            {
                int ignorableValue = -1;
                SearchRange(A, start, middle - 1, target, ref tempMin, ref ignorableValue);
                SearchRange(A, middle + 1, end, target, ref ignorableValue, ref tempMax);

                max = Math.Max(max, middle);
                min = Math.Min(min, middle);
            }

            min = Math.Min(tempMin, min);
            max = Math.Max(tempMax, max);
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
