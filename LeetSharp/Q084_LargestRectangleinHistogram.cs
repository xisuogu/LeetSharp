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
        // http://tech-queries.blogspot.com/2011/03/maximum-area-rectangle-in-histogram.html
        // suppose answer area contains h[i], means answer = h[i] * (1 + Li + Ri)
        // where Li means: how many left adjacents are GE h[i]
        // where Ri means: how many right adjacents are GE h[i]
        public int LargestRectangleArea(int[] height)
        {
            int[] answers = new int[height.Length];
            Stack<int> stack = new Stack<int>();

            // pass1: get Li, store in answers
            for (int i = 0; i < height.Length; i++)
            {
                while (stack.Count > 0 && height[stack.Peek()] >= height[i])
                {
                    stack.Pop();
                }
                int leftEdge = stack.Count > 0 ? stack.Peek() : -1;
                answers[i] = i - leftEdge - 1;
                stack.Push(i);
            }
            // pass2: get Ri, store in answers
            stack.Clear();
            for (int i = height.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && height[stack.Peek()] >= height[i])
                {
                    stack.Pop();
                }
                int rightEdge = stack.Count > 0 ? stack.Peek() : height.Length;
                answers[i] += rightEdge - i - 1;
                stack.Push(i);
            }
            // pass3: scan answers[i] and get answer
            int max = 0;
            for (int i = 0; i < height.Length; i++)
            {
                int current = height[i] * (answers[i] + 1);
                max = Math.Max(current, max);
            }

            return max;
        }

        public int LargestRectangleAreaBinary(int[] height)
        {
            int max = int.MinValue;
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            stack.Push(Tuple.Create(0, height.Length - 1));
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                int left = current.Item1;
                int right = current.Item2;

                int tempResult;
                if (left > right)
                {
                    tempResult = 0;
                }
                else if (left == right)
                {
                    tempResult = height[left];
                }
                else
                {
                    int lowest = left;
                    for (int i = left + 1; i <= right; i++)
                    {
                        lowest = (height[i] < height[lowest]) ? i : lowest;
                    }

                    tempResult = height[lowest] * (right - left + 1);
                    stack.Push(Tuple.Create(left, lowest - 1));
                    stack.Push(Tuple.Create(lowest + 1, right));
                }
                max = Math.Max(max, tempResult);
            }
            return max;
        }

        public int LargestRectangleAreaBinary2(int[] height)
        {
            return LargestRectangleAreaBinaryRec(height, 0, height.Length - 1);
        }


        // stack overflow in large testing data
        public int LargestRectangleAreaBinaryRec(int[] height, int left, int right)
        {
            if (left > right)
                return 0;
            if (left == right)
                return height[left];

            int lowest = left;
            for (int i = left + 1; i <= right; i++)
            {
                lowest = (height[i] < height[lowest]) ? i : lowest;
            }

            int areaFromLeftToRight = height[lowest] * (right - left + 1);
            int areaLeft = LargestRectangleAreaBinaryRec(height, left, lowest - 1);
            int areaRight = LargestRectangleAreaBinaryRec(height, lowest + 1, right);
            return Math.Max(areaFromLeftToRight, Math.Max(areaLeft, areaRight));
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
