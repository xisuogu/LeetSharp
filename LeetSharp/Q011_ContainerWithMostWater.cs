using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given n non-negative integers a1, a2, ..., an, 
// where each represents a point at coordinate (i, ai). n vertical lines are drawn 
// such that the two endpoints of line i is at (i, ai) and (i, 0). 
// Find two lines, which together with x-axis forms a container, such that the container contains the most water.

// Note: You may not slant the container.

namespace LeetSharp
{
    [TestClass]
    public class Q011_ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            // O(n), start with head and tail
            int left = 0;
            int right = height.Length - 1;
            int answer = Math.Min(height[left], height[right]) * (right - left);
            while (left < right)
            {
                // if h[left] < h[right], then answer(left, right -1) must be smaller than answer(left, right)
                // so only scan left++ in this case
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
                int newAnswer = Math.Min(height[left], height[right]) * (right - left);
                answer = newAnswer > answer ? newAnswer : answer;
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return MaxArea(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q011_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q011_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
