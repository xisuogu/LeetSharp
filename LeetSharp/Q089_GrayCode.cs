using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// The gray code is a binary numeral system where two successive values differ in only one bit.

// Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code. 
// A gray code sequence must begin with 0.

// For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:

// 00 - 0
// 01 - 1
// 11 - 3
// 10 - 2
// Note:
// For a given n, a gray code sequence is not uniquely defined.
// For example, [0,2,3,1] is also a valid gray code sequence according to the above definition.
// For now, the judge is able to judge based on one instance of gray code sequence. Sorry about that.

namespace LeetSharp
{
    [TestClass]
    public class Q089_GrayCode
    {
        public int[] GrayCode(int n)
        {
            List<int> list = new List<int>();
            list.Add(0);            

            for (int i = 0; i < n; i++)
            {
                int offset = 1 << i;
                for (int j = list.Count - 1; j >= 0; j--)
                {
                    list.Add(list[j] | offset);
                }
            }
            return list.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(GrayCode(input.ToInt()));
        }

        [TestMethod]
        public void Q089_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q089_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
