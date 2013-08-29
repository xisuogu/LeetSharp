using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Follow up for "Remove Duplicates": Q026
// What if duplicates are allowed at most twice?

// For example,
// Given sorted array A = [1,1,1,2,2,3],

// Your function should return length = 5, and A is now [1,1,2,2,3].

namespace LeetSharp
{
    [TestClass]
    public class Q080_RemoveDuplicatesfromSortedArrayII
    {
        public int[] RemoveDuplicates(int[] a)
        {
            if (a == null || a.Length == 0)
                return new int[0];

            int dupCount = 1;
            int flag = a[0];
            int read = 1, write = 1;
            for (; read < a.Length; read++)
            {
                if (a[read] != flag || dupCount < 2)
                {
                    dupCount = (a[read] == flag) ? dupCount + 1 : 1;
                    flag = a[read];
                    a[write++] = flag;                    
                }
            }

            return a.Take(write).ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(RemoveDuplicates(input.ToIntArray()));
        }

        [TestMethod]
        public void Q080_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q080_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
