using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. 
// Return the sum of the three integers. You may assume that each input would have exactly one solution.

//    For example, given array S = {-1 2 1 -4}, and target = 1.

//    The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

namespace LeetSharp
{
    [TestClass]
    public class Q016_3SumClosest
    {
        public int ThreeSumClosest(int[] num, int target)
        {
            Array.Sort(num);

            int diff = int.MaxValue;
            for (int i = 0; i < num.Length - 2; i++)
            {
                for (int j = i + 1, k = num.Length - 1; j < k; )
                {
                    int sum = num[i] + num[j] + num[k];
                    if (sum == target)
                    {
                        return target;
                    }
                    else
                    {
                        if (sum < target)
                        {
                            j++;
                        }
                        else
                        {
                            k--;
                        }
                        if (Math.Abs(sum - target) < Math.Abs(diff))
                        {
                            diff = sum - target;
                        }
                    }
                }
            }

            return target + diff;
        }

        public string SolveQuestion(string input)
        {
            return ThreeSumClosest(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()).ToString();
        }

        [TestMethod]
        public void Q016_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q016_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
