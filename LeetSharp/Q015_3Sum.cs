using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? 
// Find all unique triplets in the array which gives the sum of zero.

// Note:
// Elements in a triplet (a,b,c) must be in non-descending order. (ie, a ? b ? c)
// The solution set must not contain duplicate triplets.
//    For example, given array S = {-1 0 1 2 -1 -4},

//    A solution set is:
//    (-1, 0, 1)
//    (-1, -1, 2)

namespace LeetSharp
{
    [TestClass]
    public class Q015_3Sum
    {
        public int[][] ThreeSum(int[] num)
        {
            List<int[]> result = new List<int[]>();
            var sortedNums = num.OrderBy(n => n).ToArray(); // sort first
            for (int i = 0; i < sortedNums.Length - 2; i++)
            {
                int left = i + 1;
                int right = sortedNums.Length - 1;
                while (left < right)
                {
                    int tmp = sortedNums[i] + sortedNums[left] + sortedNums[right];
                    if (tmp > 0)
                    {
                        right--;
                    }
                    else if (tmp < 0)
                    {
                        left++;
                    }
                    else
                    {
                        if (!result.Any(r => r[0] == sortedNums[i] && r[1] == sortedNums[left] && r[2] == sortedNums[right]))
                        {
                            result.Add(new[] { sortedNums[i], sortedNums[left], sortedNums[right] });
                        }
                        right--;
                        left++;
                    }
                }
            }
            return result.ToArray();
        }

        public string SolveQuestion(string input)
        {
            var result = ThreeSum(input.ToIntArray());
            return TestHelper.Serialize(result);
        }

        [TestMethod]
        public void Q015_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q015_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
