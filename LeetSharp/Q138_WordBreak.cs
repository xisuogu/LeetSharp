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
