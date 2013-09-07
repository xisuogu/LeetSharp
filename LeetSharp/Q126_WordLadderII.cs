using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given two words (start and end), and a dictionary, find all shortest transformation 
// sequence(s) from start to end, such that:

// Only one letter can be changed at a time
// Each intermediate word must exist in the dictionary
// For example,

// Given:
// start = "hit"
// end = "cog"
// dict = ["hot","dot","dog","lot","log"]

// Return

//   [
//     ["hit","hot","dot","dog","cog"],
//     ["hit","hot","lot","log","cog"]
//   ]
// Note:

// All words have the same length.
// All words contain only lowercase alphabetic characters.

namespace LeetSharp
{
    [TestClass]
    public class Q126_WordLadderII
    {
        public string[][] FindLadders(string start, string end, string[] dict)
        {
            HashSet<string> dictionary = new HashSet<string>(dict);
            HashSet<string> currentStarts = new HashSet<string>() { start };

            List<string[]> results = new List<string[]>();
            Dictionary<string, List<string>> backtrackMap = new Dictionary<string, List<string>>();

            while (currentStarts.Count > 0)
            {
                currentStarts.ToList().ForEach(x => dictionary.Remove(x));
                HashSet<string> nextStarts = new HashSet<string>();

                foreach (string word in currentStarts)
                {
                    if (word == end)
                    {
                        AddPathToResults(backtrackMap, start, end, results);
                    }
                    GetAllValidNextWords(word, dictionary, nextStarts, backtrackMap);
                }

                currentStarts = nextStarts;
            }

            return results.ToArray();
        }

        private void AddPathToResults(Dictionary<string, List<string>> backtrackMap, 
            string start, string end, List<string[]> results)
        {
            Queue<List<string>> queue = new Queue<List<string>>();
            queue.Enqueue(new List<string>() { end });
            while (queue.Peek().First() != start)
            {
                List<string> item = queue.Dequeue();

                foreach (string word in backtrackMap[item.First()])
                {
                    queue.Enqueue(new string[] { word }.Concat(item).ToList());
                }
            }
            queue.ToList().ForEach(x => results.Add(x.ToArray()));
        }

        private void GetAllValidNextWords(string current, HashSet<string> dict, 
            HashSet<string> nextWordSet, Dictionary<string, List<string>> backtrackMap)
        {
            for (int i = 0; i < current.Length; i++)
            {
                char[] wordCharArray = current.ToCharArray();
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (current[i] != c)
                    {
                        wordCharArray[i] = c;
                        string nextWord = new string(wordCharArray);
                        if (dict.Contains(nextWord))
                        {
                            nextWordSet.Add(nextWord);

                            if (backtrackMap.ContainsKey(nextWord))
                            {
                                backtrackMap[nextWord].Add(current);
                            }
                            else
                            {
                                backtrackMap[nextWord] = new List<string>() { current };
                            }                            
                        }                        
                    }
                }
            }
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
            return TestHelper.Serialize(FindLadders(input.GetToken(0).Deserialize(),
                input.GetToken(1).Deserialize(), input.GetToken(2).ToStringArray()));
        }

        [TestMethod]
        public void Q126_Small()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreStringArrayArrayEqual);
        }
        [TestMethod]
        public void Q126_Large()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreStringArrayArrayEqual);
        }
    }
}
