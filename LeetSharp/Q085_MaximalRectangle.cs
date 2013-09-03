using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing all ones and return its area.

// |   | X |   | X | X |   |                    | 0 | 1 | 0 | 1 | 1 | 0 |
// -------------------------                    -------------------------
// | X | X | X | X | X |   |                    | 1 | 2 | 1 | 2 | 2 | 0 |
// -------------------------                    -------------------------
// |   | X | X | X | X | X |                    | 0 | 3 | 2 | 3 | 3 | 1 |
// -------------------------                    -------------------------
// |   | X | X | X |   |   |                    | 0 | 4 | 3 | 4 | 0 | 0 |
// -------------------------    ============>   -------------------------
// |   | X | X | X | X | X |                    | 0 | 5 | 4 | 5 | 1 | 1 |
// -------------------------                    -------------------------
// |   | X | X | X | X |   |                    | 0 | 6 | 5 | 6 | 2 | 0 |
// -------------------------                    -------------------------
// | X | X | X |   | X | X |                    | 1 | 7 | 6 | 0 | 3 | 1 |
// -------------------------                    -------------------------
// |   | X | X | X |   |   |                    | 0 | 8 | 7 | 1 | 0 | 0 |

namespace LeetSharp
{
    [TestClass]
    public class Q085_MaximalRectangle
    {
        public int MaximalRectangle(string[] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
                return 0;

            int max = 0; 
            int[] height = new int[matrix[0].Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                string current = matrix[i];
                for (int j = 0; j < height.Length; j++)
                {
                    height[j] = current[j] == '0' ? 0 : height[j] + 1;
                }
                max = Math.Max(max, LargestRectangleArea(height));
            }
            return max;
        }

        private int LargestRectangleArea(int[] height)
        {
            int[] answers = new int[height.Length];
            Stack<int> stack = new Stack<int>();

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

            int max = 0;
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

                int current = height[i] * (answers[i] + 1);
                max = Math.Max(current, max);
            }

            return max;
        }
        public string SolveQuestion(string input)
        {
            return MaximalRectangle(input.ToStringArray()).ToString();
        }

        [TestMethod]
        public void Q085_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q085_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
