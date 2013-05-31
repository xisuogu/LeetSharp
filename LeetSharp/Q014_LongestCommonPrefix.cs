using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Write a function to find the longest common prefix string amongst an array of strings.

namespace LeetSharp
{
    [TestClass]
    public class Q014_LongestCommonPrefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + LongestCommonPrefix(input.ToStringArray()) + "\"";
        }

        [TestMethod]
        public void Q014_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q014_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
