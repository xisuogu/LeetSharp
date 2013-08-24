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
                return string.Empty;

            int index = -1;
            while (++index < strs[0].Length)
            {
                bool stop = false;
                for (int i = 1; i < strs.Length; i++)
                {
                    if (index == strs[i].Length ||
                        strs[i][index] != strs[0][index])
                    {
                        stop = true;
                        break;
                    }
                }

                if (stop)
                    break;
            }

            return strs[0].Substring(0, index);
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
