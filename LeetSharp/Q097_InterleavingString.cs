using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.

// For example,
// Given:
// s1 = "aabcc",
// s2 = "dbbca",

// When s3 = "aadbbcbcac", return true.
// When s3 = "aadbbbaccc", return false.

namespace LeetSharp
{
    [TestClass]
    public class Q097_InterleavingString
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            Dictionary<string, bool> cache = new Dictionary<string, bool>();
            return IsInterleave(s1, s2, s3, cache);
        }

        private bool IsInterleave(string s1, string s2, string s3, Dictionary<string, bool> cache)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;

            if (s1 == string.Empty)
                return s2 == s3;

            if (s2 == string.Empty)
                return s1 == s3;

            string key = s1.Length + ":" + s2.Length + ":" + s3.Length;
            if (cache.ContainsKey(key))
                return cache[key];

            bool result = false;
            if (s1[0] == s3[0])
            {
                result |= IsInterleave(s1.Substring(1), s2, s3.Substring(1), cache);
            }
            if (!result && s2[0] == s3[0])
            {
                result |= IsInterleave(s1, s2.Substring(1), s3.Substring(1), cache);
            }

            cache[key] = result;
            return result;
        }

        public string SolveQuestion(string input)
        {
            return IsInterleave(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize(),
                input.GetToken(2).Deserialize()).ToString().ToLower();
        }

        [TestMethod]
        public void Q097_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q097_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
