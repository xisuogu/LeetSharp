using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

// If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).

// The replacement must be in-place, do not allocate extra memory.

// Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
// 1,2,3 ¡ú 1,3,2
// 3,2,1 ¡ú 1,2,3
// 1,1,5 ¡ú 1,5,1

namespace LeetSharp
{
    [TestClass]
    public class Q031_NextPermutation
    {
        public int[] NextPermutation(int[] num)
        {
            int reverseStart = 0;
            for (int j = num.Length - 1; j >= 1; j--) // from right to left, find first descending one
            {
                if (num[j] > num[j - 1]) // then j-1 should increase 1 step first
                {
                    reverseStart = j;
                    for (int k = num.Length - 1; k >= j; k--) // find the 1st ele, which is larger than num[j-1]
                    {
                        if (num[k] > num[j - 1])
                        {
                            int temp = num[k];
                            num[k] = num[j - 1];
                            num[j - 1] = temp;
                            break;
                        }
                    }
                    break;
                }
            }
            PartialReverse(ref num, reverseStart, num.Length - 1);
            return num;
        }

        private void PartialReverse(ref int[] num, int start, int end)
        {
            while (start < end)
            {
                int temp = num[start];
                num[start++] = num[end];
                num[end--] = temp;
            }
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(NextPermutation(input.ToIntArray()));
        }

        [TestMethod]
        public void Q031_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q031_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
