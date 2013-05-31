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
            return -1;
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
