using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// You are climbing a stair case. It takes n steps to reach to the top.

// Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

namespace LeetSharp
{
    [TestClass]
    public class Q070_ClimbingStairs
    {
        public int ClimbStairs(int n)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return ClimbStairs(input.ToInt()).ToString();
        }

        [TestMethod]
        public void Q070_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q070_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
