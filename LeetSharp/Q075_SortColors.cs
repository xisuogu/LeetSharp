using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent, 
// with the colors in the order red, white and blue.

// Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

// Note:
// You are not suppose to use the library's sort function for this problem.

// Follow up:
// A rather straight forward solution is a two-pass algorithm using counting sort.
// First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, 
// then 1's and followed by 2's.
// Could you come up with an one-pass algorithm using only constant space?

namespace LeetSharp
{
    [TestClass]
    public class Q075_SortColors
    {
        public int[] SortColors(int[] input)
        {
            int zeroWrite = 0;
            int twoWrite = input.Length - 1;
            int scan = 0;
            while (scan <= twoWrite)
            {
                if (input[scan] == 0)
                {
                    if (scan > zeroWrite)
                    {
                        input[scan] = input[zeroWrite];
                        input[zeroWrite++] = 0;
                    }
                    else
                    {
                        scan++;
                        zeroWrite++;
                    }
                }
                else if (input[scan] == 2)
                {
                    if (scan < twoWrite)
                    {
                        input[scan] = input[twoWrite];
                        input[twoWrite--] = 2;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    scan++;
                }
            }
            return input;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(SortColors(input.ToIntArray()));
        }

        [TestMethod]
        public void Q075_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q075_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
