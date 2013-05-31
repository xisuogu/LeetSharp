using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Say you have an array for which the ith element is the price of a given stock on day i.

// Design an algorithm to find the maximum profit. You may complete at most two transactions.

// Note:
// You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).

namespace LeetSharp
{
    [TestClass]
    public class Q123_BestTimetoBuyandSellStockIII
    {
        public int MaxProfitIII(int[] prices)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return MaxProfitIII(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q123_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q123_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
