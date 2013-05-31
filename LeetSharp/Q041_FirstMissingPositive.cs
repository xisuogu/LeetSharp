using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an unsorted integer array, find the first missing positive integer.

// For example,
// Given [1,2,0] return 3,
// and [3,4,-1,1] return 2.

// Your algorithm should run in O(n) time and uses constant space.

namespace LeetSharp
{
    [TestClass]
    public class Q041_FirstMissingPositive
    {
        public int FirstMissingPositive(int[] A)
        {
            int totalLength = A.Length;
            int scan = 0;
            // scan the array, put every element to their correct position, e.g.
            // 3 should be at A[2], 4 should be at A[3]
            while (scan < totalLength)
            {
                // only if current element > 0 and can be put into correct position, do swap
                if (A[scan] != scan + 1 && A[scan] <= totalLength 
                    && A[scan] > 0 && A[scan] != A[A[scan] - 1])
                {
                    // swap A[scan] to correct position A[A[scan] -1]
                    int tmp = A[scan];
                    A[scan] = A[tmp - 1];
                    A[tmp - 1] = tmp;
                }
                else
                {
                    scan++; // only if cannot swap, step forward
                }
            }
            for (int i = 0; i < totalLength; i++)
            {
                if (A[i] != i + 1)
                {
                    return i + 1;
                }
            }
            return totalLength + 1;
        }

        public string SolveQuestion(string input)
        {
            return FirstMissingPositive(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q041_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q041_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
