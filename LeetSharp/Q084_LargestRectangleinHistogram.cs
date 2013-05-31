using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.

// Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].

// The largest rectangle is shown in the shaded area, which has area = 10 unit.

// For example,
// Given height = [2,1,5,6,2,3],
// return 10.

namespace LeetSharp
{
    [TestClass]
    public class Q084_LargestRectangleinHistogram
    {
        public int LargestRectangleArea(int[] height)
        {
            // Binary solution may stack overflow
            // Linear is beset
            return LargestRectangleAreaLinear(height);
        }

        // suppose answer area contains h[i], means answer = h[i] * (1 + Li + Ri)
        // where Li means: how many left adjacents are GE h[i]
        // where Ri means: how many right adjacents are GE h[i]
        private int LargestRectangleAreaLinear(int[] height)
        {
            int[] answers = new int[height.Length];
            Stack<int> s = new Stack<int>(); // store index
            // pass1: get Li, store in answers
            for (int i = 0; i < height.Length; i++)
            {
                // pop the stack until the top is lower than h[i]
                while (s.Count > 0 && height[s.Peek()] >= height[i])
                {
                    s.Pop();
                }
                int leftEdge = s.Count == 0 ? -1 : s.Peek();
                answers[i] = i - leftEdge - 1;
                s.Push(i);
            }
            // pass2: get Ri, store in answers
            s.Clear();
            for (int i = height.Length - 1; i >= 0; i--)
            {
                // pop the stack until the top is lower than h[i]
                while (s.Count > 0 && height[s.Peek()] >= height[i])
                {
                    s.Pop();
                }
                int rightEdge = s.Count == 0 ? height.Length : s.Peek();
                answers[i] += rightEdge - i - 1;
                s.Push(i);
            }
            // pass3: scan answers[i] and get answer
            int max = 0;
            for (int i = 0; i < answers.Length; i++)
            {
                max = Math.Max(max, (answers[i] + 1) * height[i]);
            }
            return max;
        }

        private int LargestRectangleAreaBinary(int[] height, int left, int right)
        {
            if (left > right)
            {
                return 0;
            }
            if (left == right)
            {
                return height[left];
            }
            // find the lowest one, and recursively calculate left part and right part
            int lowestIndex = left;
            for (int i = left + 1; i <= right; i++)
            {
                lowestIndex = height[lowestIndex] > height[i] ? i : lowestIndex;
            }

            int answerLeftThroughRight = height[lowestIndex] * (right - left + 1);
            int answerLeft = LargestRectangleAreaBinary(height, left, lowestIndex - 1);
            int answerRight = LargestRectangleAreaBinary(height, lowestIndex + 1, right);
            return Math.Max(Math.Max(answerLeft, answerRight), answerLeftThroughRight);
        }

        public string SolveQuestion(string input)
        {
            return LargestRectangleArea(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q084_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q084_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
