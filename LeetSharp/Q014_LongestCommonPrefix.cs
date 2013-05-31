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
            if (strs.Length == 0)
            {
                return String.Empty;
            }
            int commonLength = strs[0].Length;
            for (int i = 1; i < strs.Length; i++)
            {
                int newCommonLength = 0;
                for (; newCommonLength < commonLength; newCommonLength++)
                {
                    if (newCommonLength >= strs[i].Length ||
                        strs[i - 1][newCommonLength] != strs[i][newCommonLength])
                    {
                        break;
                    }
                }
                commonLength = newCommonLength;
            }
            return strs[0].Substring(0, commonLength);
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
