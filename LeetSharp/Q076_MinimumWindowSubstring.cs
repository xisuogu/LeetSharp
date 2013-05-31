using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

// For example,
// S = "ADOBECODEBANC"
// T = "ABC"

// Minimum window is "BANC".

// Note:
// If there is no such window in S that covers all characters in T, return the emtpy string "".
// If there are multiple such windows, you are guaranteed that there will always be only one unique minimum window in S.

namespace LeetSharp
{
    [TestClass]
    public class Q076_MinimumWindowSubstring
    {
        public string MinWindow(string src, string target)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + MinWindow(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()) + "\"";
        }

        [TestMethod]
        public void Q076_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q076_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
