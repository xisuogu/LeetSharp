using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// The set [1,2,3,бн,n] contains a total of n! unique permutations.

// By listing and labeling all of the permutations in order,
// We get the following sequence (ie, for n = 3):

// "123"
// "132"
// "213"
// "231"
// "312"
// "321"
// Given n and k, return the kth permutation sequence.

// Note: Given n will be between 1 and 9 inclusive.

namespace LeetSharp
{
    [TestClass]
    public class Q060_PermutationSequence
    {
        public string GetPermutation(int n, int k)
        {
            List<int> num = Enumerable.Range(1, n).ToList();

            string result = string.Empty;
            for (int i = 0; i < n; i++)
            {
                int countOfRightPerm = Factorial(n - 1 - i);
                int index = (k - 1) / countOfRightPerm;
                result += num[index];
                num.RemoveAt(index);
                k -= countOfRightPerm * index;
            }
            return result;
        }

        private int Factorial(int n)
        {
            int res = 1;
            while (n > 0)
            {
                res *= n--;
            }
            return res;
        }

        public string GetPermutation2(int n, int k)
        {
            int[] num = Enumerable.Range(1, n).ToArray();

            while (--k > 0)
            {
                num = NextPermutation(num);
            }
            return string.Join("", num);
        }

        private int[] NextPermutation(int[] num)
        {
            int i = num.Length - 2;
            for (; i >= 0; i--)
            {
                if (num[i] < num[i + 1])
                {
                    int min = int.MaxValue, minPos = 0;
                    for (int j = num.Length - 1; j > i; j--)
                    {
                        if (num[j] > num[i] && num[j] < min)
                        {
                            min = num[j];
                            minPos = j;
                        }
                    }
                    int temp = num[i];
                    num[i] = min;
                    num[minPos] = temp;

                    break;
                }
            }

            int start = i + 1, end = num.Length - 1;
            while (start < end)
            {
                int temp = num[start];
                num[start++] = num[end];
                num[end--] = temp;
            }

            return num;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + GetPermutation(input.GetToken(0).ToInt(), input.GetToken(1).ToInt()) + "\"";
        }

        [TestMethod]
        public void Q060_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q060_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
