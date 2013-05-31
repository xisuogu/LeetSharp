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
        // http://yyeclipse.blogspot.com/2012/11/solving-maximal-rectangle-problem-based.html
        // related to Q084, O(NM)
        public int MaximalRectangle(string[] matrix)
        {
            if (matrix.Length == 0)
            {
                return 0;
            }
            // from matrix, generate assistant matrix
            int height = matrix.Length;
            int width = matrix[0].Length;
            int[][] assistantMatrix = new int[height][];
            for (int i = 0; i < height; i++)
            {
                assistantMatrix[i] = new int[width];
            }
            for (int c = 0; c < width; c++)
            {
                int previousContinous = 0;
                for (int r = 0; r < height; r++)
                {
                    if (matrix[r][c] == '0')
                    {
                        previousContinous = 0;
                    }
                    else
                    {
                        assistantMatrix[r][c] = previousContinous + 1;
                        previousContinous++;
                    }
                }
            }
            // for each row, calculate histogram, via Q084
            int answer = 0;
            Q084_LargestRectangleinHistogram q = new Q084_LargestRectangleinHistogram();
            for (int r = 0; r < assistantMatrix.Length; r++)
            {
                answer = Math.Max(answer, q.LargestRectangleArea(assistantMatrix[r]));
            }
            return answer;
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
