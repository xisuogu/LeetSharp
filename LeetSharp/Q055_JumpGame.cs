using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array of non-negative integers, you are initially positioned at the first index of the array.

// Each element in the array represents your maximum jump length at that position.
// Determine if you are able to reach the last index.

// For example:
// A = [2,3,1,1,4], return true.
// A = [3,2,1,0,4], return false.

namespace LeetSharp
{
    [TestClass]
    public class Q055_JumpGame
    {
        public bool CanJump(int[] input)
        {
            int end = input.Length - 1;
            while (end > 0)
            {
                bool moveBack = false;
                for (int i = end - 1; i >= 0; i--)
                {
                    if (input[i] >= end - i) // from i can jump to end
                    {
                        end = i;
                        moveBack = true;
                        break;
                    }
                }
                if (!moveBack)
                {
                    return false;
                }
            }
            return true;
        }

        public string SolveQuestion(string input)
        {
            return CanJump(input.ToIntArray()).ToString().ToLower();
        }

        [TestMethod]
        public void Q055_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q055_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
