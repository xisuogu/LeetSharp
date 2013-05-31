using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Say you have an array for which the ith element is the price of a given stock on day i.

// If you were only permitted to complete at most one transaction 
// (ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.

namespace LeetSharp
{
    [TestClass]
    public class Q121_BestTimetoBuyandSellStock
    {
        public int MaxProfit(int[] prices)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return MaxProfit(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q121_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q121_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
