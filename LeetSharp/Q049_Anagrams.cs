using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array of strings, return all groups of strings that are anagrams.

// Note: All inputs will be in lower-case.

namespace LeetSharp
{
    [TestClass]
    public class Q049_Anagrams
    {
        public string[] Anagrams(string[] strs)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Anagrams(input.ToStringArray()));
        }

        private bool AreStringsEqual(string expected, string actual)
        {
            var arrExp = expected.ToStringArray().OrderBy(s => s).ToArray();
            var arrActual = actual.ToStringArray().OrderBy(s => s).ToArray();
            if (arrExp.Length != arrActual.Length)
            {
                return false;
            }
            for (int i = 0; i < arrExp.Length; i++)
            {
                if (arrExp[i] != arrActual[i])
                {
                    return false;
                }
            }
            return true;
        }

        [TestMethod]
        public void Q049_Small()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreStringsEqual);
        }
        [TestMethod]
        public void Q049_Large()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreStringsEqual);
        }
    }
}
