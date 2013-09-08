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
            if (prices.Length == 0)
                return 0;

            int currentSum = 0, maxSum = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                currentSum += (prices[i] - prices[i - 1]);
                maxSum = Math.Max(maxSum, currentSum);

                if (currentSum < 0)
                    currentSum = 0;
            }

            return maxSum;
        }

        public int MaxProfit2(int[] prices)
        {
            if (prices.Length == 0)
                return 0;

            int profit = 0;
            int min = prices[0], max = min;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < min)
                    min = prices[i];

                if (prices[i] > min)
                {
                    max = prices[i];
                    profit = Math.Max(profit, max - min);
                }
            }
            return profit; 
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
