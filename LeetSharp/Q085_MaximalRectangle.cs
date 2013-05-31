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
            return -1;
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
