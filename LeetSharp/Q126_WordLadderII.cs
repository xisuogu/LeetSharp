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
            //return FindLaddersS1(start, end, dict);
            return FindLaddersS2(start, end, dict);
        }

        // use another dictionary to record path
        private string[][] FindLaddersS2(string start, string end, string[] dict)
        {
            List<string[]> result = new List<string[]>();
            HashSet<string> hset = new HashSet<string>(dict);
            FindLaddersSolution2Internal(start, end, hset, result);
            return result.ToArray();
        }

        private void FindLaddersSolution2Internal(string start, string end, HashSet<string> dic, List<string[]> result)
        {
            HashSet<string> currentStarts = new HashSet<string>() { start };
            HashSet<string> visited = new HashSet<string>();
            Dictionary<string, List<string>> path = new Dictionary<string, List<string>>(); // reverse path
            while (currentStarts.Count > 0 && !currentStarts.Contains(end))
            {
                currentStarts.ToList().ForEach(s => visited.Add(s));
                HashSet<string> nextStarts = new HashSet<string>();
                foreach (var starting in currentStarts)
                {
                    foreach (var nextToken in GetValidMoves(starting, dic))
                    {
                        if (!visited.Contains(nextToken) && !currentStarts.Contains(nextToken))
                        {
                            if (path.ContainsKey(nextToken))
                            {
                                path[nextToken].Add(starting);
                            }
                            else
                            {
                                path[nextToken] = new List<string>() { starting };
                            }
                            nextStarts.Add(nextToken);
                        }
                    }
                }
                currentStarts = nextStarts;
            }
            if (path.ContainsKey(end)) // construct the path according to path
            {
                Queue<List<string>> q = new Queue<List<string>>();
                q.Enqueue(new List<string>() { end });
                while (q.Peek().First() != start)
                {
                    var tmp = q.Dequeue();
                    foreach (var next in path[tmp.First()])
                    {
                        q.Enqueue(new [] { next }.Concat(tmp).ToList());
                    }
                }
                q.ToList().ForEach(res => result.Add(res.ToArray()));
            }
        }

        // by removing entries from original dict, and pass the path down
        private string[][] FindLaddersS1(string start, string end, string[] dict)
        {
            List<string[]> result = new List<string[]>();
            HashSet<string> hset = new HashSet<string>(dict);
            FindLaddersSolution1Internal(start, end, hset, result);
            return result.ToArray();
        }

        private void FindLaddersSolution1Internal(string start, string end, HashSet<string> dic, List<string[]> result)
        {
            if (!dic.Contains(start))
            {
                return;
            }
            List<List<string>> currentStarts = new List<List<string>> { new List<string>(new[] { start }) };
            bool foundEnd = false;
            while (true)
            {
                List<List<string>> nextStarts = new List<List<string>>();
                foreach (var starting in currentStarts)
                {
                    var tailInStart = starting.Last();
                    if (tailInStart == end)
                    {
                        result.Add(starting.ToArray());
                        foundEnd = true;
                    }
                    if (!foundEnd)
                    {
                        foreach (var nextToken in GetValidMoves(tailInStart, dic))
                        {
                            nextStarts.Add(starting.Concat(new[] { nextToken }).ToList());
                        }
                    }
                }
                if (nextStarts.Count > 0 && !foundEnd)
                {
                    currentStarts = nextStarts;
                    currentStarts.ForEach(s => dic.Remove(s.Last()));
                }
                else
                {
                    return;
                }
            }
        }

        private string letters = "abcdefghijklmnopqrstuvwxyz";
        private string[] GetValidMoves(string from, HashSet<string> dic)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < from.Length; i++)
            {
                var attempt = from.ToCharArray();
                for (int j = 0; j < 26; j++)
                {
                    attempt[i] = letters[j];
                    string s = new string(attempt);
                    if (dic.Contains(s))
                    {
                        result.Add(s);
                    }
                }
            }
            return result.ToArray();
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
