using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// A message containing letters from A-Z is being encoded to numbers using the following mapping:

// 'A' -> 1
// 'B' -> 2
// ...
// 'Z' -> 26
// Given an encoded message containing digits, determine the total number of ways to decode it.

// For example,
// Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).

// The number of ways decoding "12" is 2.

namespace LeetSharp
{
    [TestClass]
    public class Q091_DecodeWays
    {
        public int NumDecodings(string s)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return NumDecodings(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q091_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q091_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
