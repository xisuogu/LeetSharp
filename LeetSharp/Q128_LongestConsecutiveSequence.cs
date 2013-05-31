using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an unsorted array of integers, find the length of the longest consecutive elements sequence.

// For example,
// Given [100, 4, 200, 1, 3, 2],
// The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.

// Your algorithm should run in O(n) complexity.

namespace LeetSharp
{
    [TestClass]
    public class Q128_LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] num)
        {
            HashSet<int> hset = new HashSet<int>(num);
            int answer = 1;
            for (int i = 0; i < num.Length; i++)
            {
                int current = num[i];
                if (hset.Remove(current))
                {
                    int tmp = 1;
                    int higher = current +1;
                    while (hset.Remove(higher++))
                    {
                        tmp++;
                    }
                    int lower = current - 1;
                    while (hset.Remove(lower--))
                    {
                        tmp++;
                    }
                    answer = Math.Max(answer, tmp);
                }
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return LongestConsecutive(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q128_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q128_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
