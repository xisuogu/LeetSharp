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
            if (prices.Length <= 1)
            {
                return 0;
            }
            int answer = 0;
            int temp = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                temp += prices[i] - prices[i - 1];
                answer = Math.Max(answer, temp);
                if (temp < 0)
                {
                    temp = 0;
                }
            }
            return answer;
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
