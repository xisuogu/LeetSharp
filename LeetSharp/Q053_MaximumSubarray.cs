using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

// For example, given the array [−2,1,−3,4,−1,2,1,−5,4],
// the contiguous subarray [4,−1,2,1] has the largest sum = 6.

namespace LeetSharp
{
    [TestClass]
    public class Q053_MaximumSubarray
    {
        public int MaxSubArray(int[] input)
        {
            int answer = int.MinValue;
            int tmp = 0;
            for (int i = 0; i < input.Length; i++)
            {
                tmp += input[i];
                answer = Math.Max(answer, tmp);
                if (tmp < 0)
                {
                    tmp = 0;
                }
            }
            return answer;
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
