using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSharp
{
    [TestClass]
    public class Q138_WordBreak
    {
        public bool WordBreak(string s, string[] dict)
        {
            // Given a string s with length n. We use segment(i, j) to indicate whether sub-string t
            // (starting at s[i] and end at s[j]) can be segmented into dictionary words. 
            // Therefore segment(i, j) = true if 
            // 1): sub-string t is a word in the dictionary; or
            // 2): there is a pos k (i < k < j - 1) such that both segment(i, k) and segment(k + 1, j) are true

            HashSet<string> dictSet = new HashSet<string>(dict);

            bool[,] segment = new bool[s.Length, s.Length];
            for (int start = s.Length - 1; start >= 0; start--)
            {
                for (int end = start; end < s.Length; end++)
                {
                    string t = s.Substring(start, end - start + 1);
                    if (dictSet.Contains(t))
                    {
                        segment[start, end] = true;
                    }
                    else
                    {
                        for (int k = start + 1; k < end - 1; k++)
                        {
                            if (segment[start, k] && segment[k + 1, end])
                            {
                                segment[start, end] = true;
                                break;
                            }
                        }
                    }
                }
            }

            return segment[0, s.Length - 1];
        }


        public bool WordBreakSlow(string s, string[] dict)
        {
            var cache = new Dictionary<string, bool>();
            var dictSet = new HashSet<string>(dict);
            return WordBreak(s, dictSet, cache);
        }

        private bool WordBreak(string s, HashSet<string> dict, Dictionary<string, bool> cache)
        {
            if (cache.ContainsKey(s))
                return cache[s];

            bool retValue = false;
            if (dict.Contains(s))
            {
                retValue = true;
            }
            else
            {
                for (int i = 1; i < s.Length; i++)
                {
                    string firstPart = s.Substring(0, i);
                    if (!dict.Contains(firstPart))
                        continue;

                    if (WordBreak(s.Substring(i), dict, cache))
                    {
                        retValue = true;
                        break;
                    }
                }
            }

            cache[s] = retValue;
            return retValue;
        }

        public string SolveQuestion(string input)
        {
            return WordBreak(input.GetToken(0).ToString(), input.GetToken(1).ToStringArray()).ToString().ToLower();
        }

        [TestMethod]
        public void Q138_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
