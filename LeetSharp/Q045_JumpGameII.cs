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
        // dp for this is still too slow, use greedy
        public int Jump(int[] input)
        {
            int currentLow = 0;
            int currentHigh = 0;
            int answer = 0;
            if (input.Length == 1)
            {
                return 0;
            }
            while (currentHigh < input.Length - 1)
            {
                answer++; // jump ahead
                int nextHigh = currentHigh + 1;
                for (int i = currentLow; i <= currentHigh; i++)
                {
                    if (i + input[i] >= input.Length - 1)
                    {
                        return answer;
                    }
                    nextHigh = Math.Max(nextHigh, i + input[i]);
                }
                currentLow = currentHigh + 1;
                currentHigh = nextHigh;
            }
            return answer;
        }

        private int JumpDP(int[] input)
        {
            int[] dp = new int[input.Length]; // dp[i] = from i to end, min jump count
            dp[input.Length - 1] = 0;
            for (int i = input.Length - 2; i >= 0; i--)
            {
                int maxJumpLength = input[i];
                if (maxJumpLength >= (input.Length - 1 - i))
                {
                    dp[i] = 1;
                }
                else
                {
                    int tmpAnswer = int.MaxValue;
                    for (int j = maxJumpLength; j > 0; j--)
                    {
                        tmpAnswer = Math.Min(tmpAnswer, dp[i + j]);
                    }
                    dp[i] = tmpAnswer == int.MaxValue ? int.MaxValue : tmpAnswer + 1;
                }
            }
            return dp[0];
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
