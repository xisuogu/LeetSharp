using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// You are given a string, S, and a list of words, L, that are all of the same length. 
// Find all starting indices of substring(s) in S that is a concatenation 
// of each word in L exactly once and without any intervening characters.

// For example, given:
// S: "barfoothefoobarman"
// L: ["foo", "bar"]

// You should return the indices: [0,9].
// (order does not matter).

namespace LeetSharp
{
    [TestClass]
    public class Q030_SubstringwithConcatenationofAllWords
    {
        public int[] FindSubstring(string s, string[] l)
        {
            if (l.Length == 0 || l[0].Length == 0)
                return new int[] { };

            List<int> results = new List<int>();
            Dictionary<string, int> map = new Dictionary<string, int>();
            int length = l[0].Length;

            for (int i = 0; i < length; i++)
            {
                map.Clear();
                foreach (string str in l)
                {
                    if (map.ContainsKey(str))
                        map[str]++;
                    else 
                        map[str] = 1;
                }

                int start = i, end = i;

                while (end <= s.Length - length)
                {
                    string str = s.Substring(end, length);
                    if (map.ContainsKey(str) && map[str] != 0)
                    {
                        map[str]--;
                    }
                    else
                    {
                        while (start <= end && s.Substring(start, length) != str)
                        {
                            map[s.Substring(start, length)]++;
                            start += length;
                        }
                        start += length;
                    }
                    end += length;

                    if (map.Values.All(n => n == 0))
                        results.Add(start);
                }
            }

            return results.OrderBy(x => x).ToArray();
        }

        #region Permutation
        public int[] FindSubstring2(string s, string[] l)
        {
            List<int> indices = new List<int>();

            string[][] wordsPermutation = Permute(l);
            foreach (var words in wordsPermutation)
            {
                int index = 0;
                string search = string.Join(string.Empty, words);
                while (true)
                {
                    index = s.IndexOf(search, index);
                    if (index == -1)
                        break;
                    if (!indices.Contains(index))
                        indices.Add(index);
                    index++;
                }
            }

            return indices.OrderBy(i => i).ToArray();
        }

        private T[][] Permute<T>(T[] words)
        {
            List<T[]> results = new List<T[]>();
            T[] data = (T[])words.Clone();
            Permute(words, results, data, 0);
            return results.ToArray();
        }

        private void Permute<T>(T[] words, List<T[]> results, T[] data, int level)
        {
            if (level == words.Length - 1)
            {
                results.Add((T[])data.Clone());
                return;
            }
            for (int i = level; i < words.Length; i++)
            {
                Swap(ref data[level], ref data[i]);
                Permute(words, results, data, level + 1);
                Swap(ref data[level], ref data[i]);
            }
        }

        private void Swap<T>(ref T i1, ref T i2)
        {
            T temp = i1;
            i1 = i2;
            i2 = temp;
        }
        #endregion 

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(
                FindSubstring(input.GetToken(0).Deserialize(), input.GetToken(1).ToStringArray()));
        }

        [TestMethod]
        public void Q030_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q030_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
