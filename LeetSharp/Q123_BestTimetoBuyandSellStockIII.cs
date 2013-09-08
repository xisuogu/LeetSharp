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
            int[] profit1 = new int[prices.Length];
            int[] profit2 = new int[prices.Length];

            int maxSum = 0;
            int currentSum = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                currentSum += (prices[i] - prices[i - 1]);
                maxSum = Math.Max(maxSum, currentSum);
                if (currentSum < 0)
                    currentSum = 0;
                profit1[i] = maxSum;
            }

            maxSum = 0;
            currentSum = 0;
            for (int i = prices.Length - 2; i >= 0; i--)
            {
                currentSum += prices[i + 1] - prices[i];
                maxSum = Math.Max(maxSum, currentSum);
                if (currentSum < 0)
                    currentSum = 0;
                profit2[i] = maxSum;
            }

            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                maxProfit = Math.Max(maxProfit, profit1[i] + profit2[i]);
            }
            return maxProfit;
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
