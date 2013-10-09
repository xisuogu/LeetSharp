using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSharp
{
    [TestClass]
    public class Q139_WordBreakII
    {
        public string[][] WordBreak(string s, string[] dict)
        {
            var dictSet = new HashSet<string>(dict);
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
            return WordBreakRec(s, 0, s.Length - 1, dictSet, segment).ToArray();
        }

        private List<string[]> WordBreakRec(string s, int start, int end, HashSet<string> dict, bool[,] segment)
        {
            List<string[]> results = new List<string[]>();

            for (int i = 1; i <= s.Length; i++)
            {
                if (segment[start, start + i] == false ||
                    segment[start + i + 1, end] == false)
                    continue;

                string firstPart = s.Substring(0, i);
                if (dict.Contains(firstPart))
                {
                    string secondPart = s.Substring(i);

                    if (secondPart.Length > 0)
                    {
                        var secondResults = WordBreakRec(secondPart, i, end, dict, segment);

                        foreach (var secondResult in secondResults)
                        {
                            results.Add(new string[] { firstPart }.Concat(secondResult).ToArray());
                        }
                    }
                    else
                    {
                        results.Add(new string[] { firstPart });
                    }
                }
            }
            return results;
        }

        public string[][] WordBreakSlow(string s, string[] dict)
        {
            int min = int.MaxValue, max = int.MinValue;
            dict.ToList().ForEach(w =>
            {
                min = Math.Min(min, w.Length);
                max = Math.Max(max, w.Length);
            });
            var dictSet = new HashSet<string>(dict);
            var cache = new Dictionary<string, List<string[]>>();
            return WordBreakRec(s, dictSet, min, max, cache).ToArray();
        }

        private List<string[]> WordBreakRec(string s, HashSet<string> dict, 
            int min, int max, Dictionary<string, List<string[]>> cache)
        {
            if (cache.ContainsKey(s))
                return cache[s];

            List<string[]> results = new List<string[]>();

            for (int i = min; i <= Math.Min(s.Length, max); i++)
            {
                string firstPart = s.Substring(0, i);
                if (dict.Contains(firstPart))
                {
                    string secondPart = s.Substring(i);

                    if (secondPart.Length > 0)
                    {
                        var secondResults = WordBreakRec(secondPart, dict, min, max, cache);

                        foreach (var secondResult in secondResults)
                        {
                            results.Add(new string[] { firstPart }.Concat(secondResult).ToArray());
                        }
                    }
                    else
                    {
                        results.Add(new string[] { firstPart });
                    }
                }
            }

            cache[s] = results;
            return results;
        }
        
        private int CompareStringArray(string[] arr1, string[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                int res = arr1[i].CompareTo(arr2[i]);
                if (res != 0)
                {
                    return res;
                }
            }
            return 0;
        }

        private bool AreStringArrayArrayEqual(string expected, string actual)
        {
            var arrExp = expected.ToStringArrayArray().ToList();
            var arrActual = actual.ToStringArrayArray().ToList();
            arrExp.Sort(CompareStringArray);
            arrActual.Sort(CompareStringArray);
            return TestHelper.Serialize(arrExp.ToArray()) ==
                TestHelper.Serialize(arrActual.ToArray());
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(WordBreak(input.GetToken(0).ToString(), input.GetToken(1).ToStringArray()));
        }

        [TestMethod]
        public void Q139_Small()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreStringArrayArrayEqual);
        }

    }
}
