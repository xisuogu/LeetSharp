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
            // first iteration, from left to right, a[i] = prices[0..i]'s max profit
            int[] firstWave = new int[prices.Length];
            int currentMax = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                currentMax += (prices[i] - prices[i - 1]);
                firstWave[i] = Math.Max(firstWave[i - 1], currentMax);
                currentMax = currentMax < 0 ? 0 : currentMax;
            }
            // second iteration, from right to left, a[i] = prices[i..n]'s max profit
            int[] secondWave = new int[prices.Length];
            currentMax = 0;
            for (int i = prices.Length - 2; i >= 0; i--)
            {
                currentMax += (prices[i + 1] - prices[i]);
                secondWave[i] = Math.Max(secondWave[i + 1], currentMax);
                currentMax = currentMax < 0 ? 0 : currentMax;
            }
            // combine
            int answer = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                answer = Math.Max(answer, firstWave[i] + secondWave[i]);
            }
            return answer;
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
