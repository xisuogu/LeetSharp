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
            Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();
            for (int i = 0; i < strs.Length; i++)
			{
                string normalizedStr = new string(strs[i].OrderBy(c => c).ToArray());
                if (dic.ContainsKey(normalizedStr))
                {
                    dic[normalizedStr].Add(i);
                }
                else
                {
                    dic[normalizedStr] = new List<int>() { i };
                }
            }
            List<int> answerIndexes = new List<int>();
            foreach (var kvp in dic)
            {
                if (kvp.Value.Count > 1)
                {
                    answerIndexes.AddRange(kvp.Value);
                }
            }
            return answerIndexes.Select(i => strs[i]).ToArray();
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
