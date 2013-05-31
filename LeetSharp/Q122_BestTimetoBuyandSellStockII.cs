using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Say you have an array for which the ith element is the price of a given stock on day i.

// Design an algorithm to find the maximum profit. You may complete as many transactions as you like 
// (ie, buy one and sell one share of the stock multiple times). 
// However, you may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).

namespace LeetSharp
{
    [TestClass]
    public class Q122_BestTimetoBuyandSellStockII
    {
        public int MaxProfitII(int[] prices)
        {
            int answer = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    answer += prices[i] - prices[i - 1];
                }
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return MaxProfitII(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q122_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q122_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
