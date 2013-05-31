using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Follow up for N-Queens problem.

// Now, instead outputting board configurations, return the total number of distinct solutions.

namespace LeetSharp
{
    [TestClass]
    public class Q052_NQueensII
    {
        // normal solution is not fast enough.
        // use 3 status values: columnState, slashState, backslashState 
        // every time put in a queen, update these 3 values and continue
        // difference is normal solution check after putting queen, this solution check before putting
        // reduce the computation
        // http://polythinking.wordpress.com/2013/02/27/leetcoden-queens-i-and-ii/
        public int SolveNQueensII(int n)
        {
            return CountOfNQueens(n, 0, 0, 0, 0);
        }

        private int CountOfNQueens(int n, int columnState, int slashState, int backslashState, int row)
        {
            if (row == n)
            {
                return 1;
            }
            int answer = 0;
            int mask = (1 << n) - 1;
            int possibleSlots = (~(columnState | slashState | backslashState)) & mask; // possible places in current row
            int currentPossition = 1; // right most
            while (possibleSlots > 0)
            {
                if ((possibleSlots & 1) == 1) // current bit can put a queen
                {
                    answer += CountOfNQueens(n, (columnState | currentPossition),
                        ((slashState | currentPossition) << 1) & mask,
                        ((backslashState | currentPossition) >> 1),
                        row + 1);
                }
                possibleSlots = possibleSlots >> 1;
                currentPossition = currentPossition << 1; // step left and detect next position
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return SolveNQueensII(input.ToInt()).ToString();
        }

        [TestMethod]
        public void Q052_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q052_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
