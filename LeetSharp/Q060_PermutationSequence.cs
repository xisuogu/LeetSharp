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
            string result = "";
            List<int> nums = Enumerable.Range(1, n).ToList();
            for (int i = 0; i < n; i++)
            {
                int countOfRightPerm = Factorial(n - i - 1);
                int index = (k - 1) / countOfRightPerm;
                result += nums[index];
                nums.RemoveAt(index);
                k -= countOfRightPerm * index;
            }
            return result;
        }

        public int Factorial(int n)
        {
            int res = 1;
            while (n > 0)
            {
                res *= n--;
            }
            return res;
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
