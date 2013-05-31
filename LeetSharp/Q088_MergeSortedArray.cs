using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given two sorted integer arrays A and B, merge B into A as one sorted array.

// Note:
// You may assume that A has enough space to hold additional elements from B. 
// The number of elements initialized in A and B are m and n respectively.

namespace LeetSharp
{
    [TestClass]
    public class Q088_MergeSortedArray
    {
        public int[] Merge(int[] a, int[] b)
        {
            if (b.Length == 0)
            {
                return a;
            }
            if (a.Length == 0)
            {
                return b;
            }
            int[] answer = new int[a.Length + b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                answer[answer.Length - 1 - i] = a[a.Length - 1 - i];
            }
            int write = 0;
            int aIndex = b.Length;
            int bIndex = 0;
            while (write < answer.Length && aIndex < answer.Length && bIndex < b.Length)
            {
                if (answer[aIndex] <= b[bIndex])
                {
                    answer[write++] = answer[aIndex++];
                }
                else
                {
                    answer[write++] = b[bIndex++];
                }
            }
            while (aIndex < answer.Length)
            {
                answer[write++] = answer[aIndex++];
            }
            while (bIndex < b.Length)
            {
                answer[write++] = b[bIndex++];
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Merge(input.GetToken(0).ToIntArray(), input.GetToken(1).ToIntArray()));
        }

        [TestMethod]
        public void Q088_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q088_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
