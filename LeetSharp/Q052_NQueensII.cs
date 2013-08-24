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
        public int SolveNQueensII(int n)
        {
            return SolveNQueensII(n, 0, 0, 0, 0);
        }

        public int SolveNQueensII(int n, int columnState, int slashState, int blackSlashState, int row)
        {
            if (row == n)
                return 1;

            int mask = (1 << n) - 1;
            int possiblePos = (~(columnState | slashState | blackSlashState)) & mask;

            int result = 0;
            int currentPos = 1;
            while (possiblePos > 0)
            {
                if ((possiblePos & 1) == 1)
                {
                    result += SolveNQueensII(n,
                        (columnState | currentPos),
                        (slashState | currentPos) << 1,
                        (blackSlashState | currentPos) >> 1,
                        row + 1);
                }
                currentPos = currentPos << 1;
                possiblePos = possiblePos >> 1;
            }
            return result;
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
