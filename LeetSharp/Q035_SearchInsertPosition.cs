using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a sorted array and a target value, return the index if the target is found.
// If not, return the index where it would be if it were inserted in order.

// You may assume no duplicates in the array.

// Here are few examples.
// [1,3,5,6], 5 ¡ú 2
// [1,3,5,6], 2 ¡ú 1
// [1,3,5,6], 7 ¡ú 4
// [1,3,5,6], 0 ¡ú 0

namespace LeetSharp
{
    [TestClass]
    public class Q035_SearchInsertPosition
    {
        public int SearchInsert(int[] input, int target)
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
                else
                {
                    return mid;
                }
            }
            return left;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(SearchInsert(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q035_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q035_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
