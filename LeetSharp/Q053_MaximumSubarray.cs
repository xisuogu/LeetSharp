using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

// For example, given the array [−2,1,−3,4,−1,2,1,−5,4],
// the contiguous subarray [4,−1,2,1] has the largest sum = 6.

// http://rerun.me/blog/2012/08/30/maximum-continuous-subarray-problem-kandanes-algorithm/

namespace LeetSharp
{
    [TestClass]
    public class Q053_MaximumSubarray
    {
        public int MaxSubArray(int[] input)
        {
            int cumSum = 0;
            int maxSum = int.MinValue;
            
            for (int i = 0; i < input.Length; i++)
            {
                cumSum += input[i];
                maxSum = Math.Max(cumSum, maxSum);

                if (cumSum < 0)
                    cumSum = 0;
            }

            return maxSum;
        }

        public int MaxSubArray2(int[] input)
        {
            int cumSum = 0;
            int maxSum = int.MinValue;
            int startIndex = 0;
            int endIndex = 0;
            int index = 0;

            for (int i = 0; i < input.Length; i++)
            {
                cumSum += input[i];
                if (cumSum > maxSum)
                {
                    maxSum = cumSum;
                    startIndex = index;
                    endIndex = i;
                }
                if (cumSum < 0)
                {
                    cumSum = 0;
                    index = i + 1; 
                }
            }

            return maxSum;
        }

        public string SolveQuestion(string input)
        {
            return MaxSubArray(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q053_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q053_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
